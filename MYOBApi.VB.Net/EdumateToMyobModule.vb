Imports System
Imports System.IO
Public Class edumateDataFeed
    'edumate data feed is a class construct for the data we are pulling out of the odbc connection to edumate

    Public TRANSACTIONS_ID As Int32       'the edumate transaction id. This is not acually used other than for testing purposes
    Public AMOUNT As Double               'amount of the transaction. From the edumate table column transactions.amount
    Public DESCRIPTION As String          'description of the edumate transaction. Not used other than for testing and debugging
    Public TRANSACTION_DATE As String     'the date of the transaction. This should all be the same day as specified by the input to the query. This is only used for testing & debugging purposes
    Public EFFECTIVE_DATE As String       'effective date of transaction isnt used, but may be useful for troubleshooting
    Public GLCODE As String               'GL code for transactions.
    Public itemCode As String             'not used
    Public GL_ACCOUNT_TYPE As String      'not used
    Public ITEM_TYPE As String            'not used
    Public TAX_TYPE As String             'tax type is not used as all entries should be of type no tax, but the construct is here for later implementation
    Public PAYMENT_TYPE As String         'the payment type (e.g. bpay, amex, etc). We will group and sum these seperately for each GL account
    Public BANK_ACCOUNT_GL_CODE As String 'the bank account GL code. 
End Class

Public Class myobInputFeed
    Public glAccount As String               'gl account the line 
    Public memo As String                    'memo is payment type from SP feed eg amex, bpay etc
    Public taxCode As String                 'not used
    Public amount As Double                  'total amount for the line (absolute value)
    Public isCredit As Boolean               'credit if true, debit if not
    Public taxAmount As Double               'not used
    Public isOverriddenTaxAmount As Boolean  'not used (always false)
End Class


Module EdumateToMyob

	Public Function edumateTyMyobMain(strDate As String)
        'the main function of this module. It takes a date and returns an object with all the data for a general journal entry
        edumateTyMyobMain = edumateDataToMyob(ConnectToOdbc(strDate))
    End Function


    Private Function ConnectToOdbc(asatdate As String)
        'This function connects to edumate via an ODBC connection. The odbc connection needs to be set up on the computer beforehand

        'read the ODBC connection string from a text file 'connectionString.txt' in the program resources folder
        'it should look something like Dsn=EdumateODBC;uid=ofgsodbc;hst=intdc_odbcro.edumate.net;prt=19996;db=saas;pwd=123456
        Dim ConnectionString As String = readConnectionString()

        'the SQL query to pull the transaction data from edumate 
        'we need to pull both transaction data and payment data, and then combine them with a full outer join
        Dim commandstring = "
        select
        a.transactionz_id as id,
        a.amount,
        a.description,
        a.transaction_date,
        a.effective_date,
        a.gl_account_code,
        a.expr1,
        null as gl_account_type,
        a.item_type,
        a.tax_type,
        payment_type.payment_type,
        bank_account.gl_code as bank_gl

        from payment
        inner join batch on payment.batch_id = batch.batch_id
        inner join batch_transaction on batch.batch_id = batch_transaction.batch_id
        inner join bank_account on payment.bank_account_id = bank_account.bank_account_id
        inner join payment_type on payment.payment_type_id = payment_type.payment_type_id

        FULL OUTER JOIN 
        (
            select 
            TRANSACTIONS.transactions_id as transactionz_id,
            transactions.amount,
            TRANSACTIONS.DESCRIPTION as description, 
            TRANSACTIONS.TRANSACTION_DATE as transaction_date, 
            TRANSACTIONS.EFFECTIVE_DATE as effective_date, 
            GL_ACCOUNT.CODE as gl_account_code, 
            item.code AS Expr1,
            item_type.item_type as item_type, 
            tax_type.tax_type as tax_type

            FROM transactions
            inner join item on transactions.item_id = item.item_id
            inner join gl_account on item.gl_account_id = gl_account.gl_account_id
            inner join tax_type on item.tax_type_id = tax_type.tax_type_id
            inner join item_type on item.item_type_id = item_type.item_type_id

        ) as a
        on batch_transaction.transactions_id = a.transactionz_id


        WHERE a.TRANSACTION_DATE = '" & asatdate & "'"

        'connect to the database
        Using conn As New IBM.Data.DB2.DB2Connection(ConnectionString)
            conn.Open()

            'define the command object to execute
            Dim command As New IBM.Data.DB2.DB2Command(commandstring, conn)
            command.Connection = conn
            command.CommandText = commandstring

            'read the data to our edumate data feed object
            Dim dataReader As IBM.Data.DB2.DB2DataReader
            dataReader = command.ExecuteReader
            Dim objEdumateDataFeed As New List(Of edumateDataFeed)
            Dim counter As Integer = 0
            While dataReader.Read()
                objEdumateDataFeed.Add(New edumateDataFeed)
                If Not dataReader.IsDBNull(0) Then objEdumateDataFeed(counter).TRANSACTIONS_ID = dataReader.GetValue(0)
                If Not dataReader.IsDBNull(1) Then objEdumateDataFeed(counter).AMOUNT = dataReader.GetValue(1)
                If Not dataReader.IsDBNull(2) Then objEdumateDataFeed(counter).DESCRIPTION = dataReader.GetValue(2)
                If Not dataReader.IsDBNull(3) Then objEdumateDataFeed(counter).TRANSACTION_DATE = dataReader.GetValue(3)
                If Not dataReader.IsDBNull(4) Then objEdumateDataFeed(counter).EFFECTIVE_DATE = dataReader.GetValue(4)
                If Not dataReader.IsDBNull(5) Then objEdumateDataFeed(counter).GLCODE = dataReader.GetValue(5)
                If Not dataReader.IsDBNull(6) Then objEdumateDataFeed(counter).itemCode = dataReader.GetValue(6)
                If Not dataReader.IsDBNull(7) Then objEdumateDataFeed(counter).GL_ACCOUNT_TYPE = dataReader.GetValue(7)
                If Not dataReader.IsDBNull(8) Then objEdumateDataFeed(counter).ITEM_TYPE = dataReader.GetValue(8)
                If Not dataReader.IsDBNull(9) Then objEdumateDataFeed(counter).TAX_TYPE = dataReader.GetValue(9)
                If Not dataReader.IsDBNull(10) Then objEdumateDataFeed(counter).PAYMENT_TYPE = dataReader.GetValue(10)
                If Not dataReader.IsDBNull(11) Then objEdumateDataFeed(counter).BANK_ACCOUNT_GL_CODE = dataReader.GetValue(11)
                counter = counter + 1
            End While

            'close the connection
            conn.Close()

			'return the data feed object 
			ConnectToOdbc = objEdumateDataFeed
		End Using
    End Function


    Private Function edumateDataToMyob(objEdumateDataFeed As List(Of edumateDataFeed))
        'this function takes the edumate input feed and sums the transactions grouped by GL account and payment type
        'each line needs to be processed twice, once for the transaction GL account and once for the bank GL account
        'any transactions without a bank GL account are also summed together to form a 'balancing line'

        Dim objMyobInputFeed As New List(Of myobInputFeed)
        Dim foundGlPaymentMatch As Boolean
        Dim foundBankGlPaymentMatch As Boolean
		Dim gstTotal As Integer = 0


		'loop through all the lines in the edumate data
		For Each e As edumateDataFeed In objEdumateDataFeed
            foundGlPaymentMatch = False
            foundBankGlPaymentMatch = False

            If objMyobInputFeed.Count > 0 Then

                'loop through all the lines that have been put into the myob data to see if there is one already existing for this gl/payment type
                'if there is, we can just add the amounts together
                For Each m As myobInputFeed In objMyobInputFeed
					'transaction GL accounts
					If e.GLCODE = m.glAccount And e.PAYMENT_TYPE = m.memo Then
						foundGlPaymentMatch = True
						If e.BANK_ACCOUNT_GL_CODE = "" Then
							m.amount = m.amount + (e.AMOUNT * -1)
						Else
							m.amount = m.amount + e.AMOUNT
						End If

						If e.TAX_TYPE = "GST" Then
							m.taxAmount = m.taxAmount + (e.AMOUNT / 11)
						End If

					End If

						'bank GL accounts
						If e.BANK_ACCOUNT_GL_CODE = m.glAccount And e.PAYMENT_TYPE = m.memo Then
                        foundBankGlPaymentMatch = True
						If e.BANK_ACCOUNT_GL_CODE = "" Then
							m.amount = m.amount + e.AMOUNT
						Else
							m.amount = m.amount + (e.AMOUNT * -1)
						End If

					End If
                Next
            End If

            'if a gl account / payment type is not already in our myob data, then we add a new line object to it
            'transaction gl accounts
            If Not foundGlPaymentMatch Then
                Dim objMyobInput As New myobInputFeed
                objMyobInput.glAccount = e.GLCODE
                objMyobInput.memo = e.PAYMENT_TYPE
				objMyobInput.taxCode = translateTaxTypes(e.TAX_TYPE)


				If e.BANK_ACCOUNT_GL_CODE = "" Then
					objMyobInput.amount = (e.AMOUNT * -1)
				Else
					objMyobInput.amount = e.AMOUNT
				End If



				If e.TAX_TYPE = "GST" Then
					objMyobInput.taxAmount = (e.AMOUNT / 11)
				End If


				objMyobInput.isOverriddenTaxAmount = False
				objMyobInputFeed.Add(objMyobInput)
			End If



			'bank gl accounts
			If Not foundBankGlPaymentMatch Then
                Dim objMyobInput As New myobInputFeed
                objMyobInput.glAccount = e.BANK_ACCOUNT_GL_CODE
                objMyobInput.memo = e.PAYMENT_TYPE
				objMyobInput.taxCode = "N-T" 'translateTaxTypes(e.TAX_TYPE)

				If e.BANK_ACCOUNT_GL_CODE = "" Then
					objMyobInput.amount = e.AMOUNT
				Else
					objMyobInput.amount = (e.AMOUNT * -1)
				End If



				objMyobInput.taxAmount = 0


				objMyobInput.isOverriddenTaxAmount = False

                objMyobInputFeed.Add(objMyobInput)
            End If
        Next

		'add a line for the GST
		'Dim objMyobGSTInput As New myobInputFeed
		'objMyobGSTInput.glAccount = "2-1310"
		'objMyobGSTInput.memo = "GST"
		'objMyobGSTInput.taxCode = "N-T"
		'objMyobGSTInput.amount = gstTotal
		'objMyobGSTInput.isOverriddenTaxAmount = False
		'objMyobGSTInput.taxAmount = 0
		'objMyobInputFeed.Add(objMyobGSTInput)

		'return our myob feed from this function

		edumateDataToMyob = objMyobInputFeed
	End Function

    Private Function readConnectionString()
        Try
            ' Open the file using a stream reader.
            Dim directory As String = My.Application.Info.DirectoryPath
			Using sr As New StreamReader(directory & "\Resources\connectionString.txt")
				Dim line As String
				line = sr.ReadToEnd()
				readConnectionString = line
			End Using
		Catch e As Exception
            MsgBox(e.Message)
        End Try
    End Function

	Private Function translateTaxTypes(edumateTaxCode As String)
		'FRE = N-T
		'GST = GST
		'E-S = E

		Select Case edumateTaxCode
			Case Is = "FRE"
				translateTaxTypes = "N-T"
			Case Is = "GST"
				translateTaxTypes = "GST"
			Case Is = "E-S"
				translateTaxTypes = "E"
			Case Else
				MsgBox("Unhandeled tax code, please contact IT - Tax code:" & edumateTaxCode)
		End Select


	End Function

End Module
