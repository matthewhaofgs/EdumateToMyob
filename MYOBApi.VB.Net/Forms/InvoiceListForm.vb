
Imports System.Web
Imports System.Net
Imports MYOB.AccountRight.SDK
Imports MYOB.AccountRight.SDK.Services
Imports MYOB.AccountRight.SDK.Contracts

Public Class InvoiceListForm
    Inherits FormBase

#Region "Designer code"
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnPageRight As System.Windows.Forms.Button
    Friend WithEvents textPage As System.Windows.Forms.TextBox
    Friend WithEvents tabAll As TabPage
    Friend WithEvents gridAllInvoices As DataGridView
    Friend WithEvents UID As DataGridViewTextBoxColumn
    Friend WithEvents DisplayID As DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents dtpDateFrom As DateTimePicker
    Friend WithEvents addNew As Button
    Friend WithEvents dtpDateTo As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPageLeft As System.Windows.Forms.Button




    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnPageRight = New System.Windows.Forms.Button()
        Me.textPage = New System.Windows.Forms.TextBox()
        Me.btnPageLeft = New System.Windows.Forms.Button()
        Me.tabAll = New System.Windows.Forms.TabPage()
        Me.gridAllInvoices = New System.Windows.Forms.DataGridView()
        Me.UID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DisplayID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.dtpDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.addNew = New System.Windows.Forms.Button()
        Me.dtpDateTo = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.tabAll.SuspendLayout()
        CType(Me.gridAllInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnPageRight)
        Me.Panel1.Controls.Add(Me.textPage)
        Me.Panel1.Controls.Add(Me.btnPageLeft)
        Me.Panel1.Location = New System.Drawing.Point(16, 528)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(147, 22)
        Me.Panel1.TabIndex = 4
        '
        'btnPageRight
        '
        Me.btnPageRight.Location = New System.Drawing.Point(115, 0)
        Me.btnPageRight.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPageRight.Name = "btnPageRight"
        Me.btnPageRight.Size = New System.Drawing.Size(30, 20)
        Me.btnPageRight.TabIndex = 2
        Me.btnPageRight.Text = ">"
        Me.btnPageRight.UseVisualStyleBackColor = True
        '
        'textPage
        '
        Me.textPage.BackColor = System.Drawing.Color.White
        Me.textPage.Location = New System.Drawing.Point(31, 0)
        Me.textPage.Name = "textPage"
        Me.textPage.ReadOnly = True
        Me.textPage.Size = New System.Drawing.Size(84, 20)
        Me.textPage.TabIndex = 1
        Me.textPage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPageLeft
        '
        Me.btnPageLeft.Location = New System.Drawing.Point(0, 0)
        Me.btnPageLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.btnPageLeft.Name = "btnPageLeft"
        Me.btnPageLeft.Size = New System.Drawing.Size(30, 20)
        Me.btnPageLeft.TabIndex = 0
        Me.btnPageLeft.Text = "<"
        Me.btnPageLeft.UseVisualStyleBackColor = True
        '
        'tabAll
        '
        Me.tabAll.Controls.Add(Me.gridAllInvoices)
        Me.tabAll.Location = New System.Drawing.Point(4, 22)
        Me.tabAll.Name = "tabAll"
        Me.tabAll.Padding = New System.Windows.Forms.Padding(3)
        Me.tabAll.Size = New System.Drawing.Size(752, 483)
        Me.tabAll.TabIndex = 0
        Me.tabAll.Text = "All Invoices"
        Me.tabAll.UseVisualStyleBackColor = True
        '
        'gridAllInvoices
        '
        Me.gridAllInvoices.AllowUserToAddRows = False
        Me.gridAllInvoices.AllowUserToDeleteRows = False
        Me.gridAllInvoices.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridAllInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.gridAllInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridAllInvoices.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.UID, Me.DisplayID})
        Me.gridAllInvoices.Location = New System.Drawing.Point(3, 3)
        Me.gridAllInvoices.Name = "gridAllInvoices"
        Me.gridAllInvoices.Size = New System.Drawing.Size(746, 477)
        Me.gridAllInvoices.TabIndex = 0
        '
        'UID
        '
        Me.UID.DataPropertyName = "UID"
        Me.UID.HeaderText = "UID"
        Me.UID.Name = "UID"
        Me.UID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.UID.Visible = False
        Me.UID.Width = 30
        '
        'DisplayID
        '
        Me.DisplayID.DataPropertyName = "DisplayID"
        Me.DisplayID.HeaderText = "DisplayID"
        Me.DisplayID.Name = "DisplayID"
        Me.DisplayID.Width = 75
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.tabAll)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(760, 509)
        Me.TabControl1.TabIndex = 0
        '
        'dtpDateFrom
        '
        Me.dtpDateFrom.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDateFrom.CustomFormat = "yyyy/MM/dd"
        Me.dtpDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateFrom.Location = New System.Drawing.Point(337, 529)
        Me.dtpDateFrom.Name = "dtpDateFrom"
        Me.dtpDateFrom.Size = New System.Drawing.Size(100, 20)
        Me.dtpDateFrom.TabIndex = 8
        Me.dtpDateFrom.Value = New Date(2016, 6, 30, 0, 0, 0, 0)
        '
        'addNew
        '
        Me.addNew.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.addNew.Location = New System.Drawing.Point(620, 527)
        Me.addNew.Name = "addNew"
        Me.addNew.Size = New System.Drawing.Size(71, 23)
        Me.addNew.TabIndex = 5
        Me.addNew.Text = "Add Data"
        Me.addNew.UseVisualStyleBackColor = True
        '
        'dtpDateTo
        '
        Me.dtpDateTo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpDateTo.CustomFormat = "yyyy/MM/dd"
        Me.dtpDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpDateTo.Location = New System.Drawing.Point(500, 529)
        Me.dtpDateTo.Name = "dtpDateTo"
        Me.dtpDateTo.Size = New System.Drawing.Size(100, 20)
        Me.dtpDateTo.TabIndex = 9
        Me.dtpDateTo.Value = New Date(2016, 6, 30, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(276, 532)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Date From:"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(450, 532)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Date To:"
        '
        'InvoiceListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtpDateTo)
        Me.Controls.Add(Me.dtpDateFrom)
        Me.Controls.Add(Me.addNew)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "InvoiceListForm"
        Me.Text = "Invoice List"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.addNew, 0)
        Me.Controls.SetChildIndex(Me.dtpDateFrom, 0)
        Me.Controls.SetChildIndex(Me.dtpDateTo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabAll.ResumeLayout(False)
        CType(Me.gridAllInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub
#End Region

    ' This delegate enables asynchronous calls to return to UI thread
    Delegate Sub SetDataSourceCallback(invoices As Version2.PagedCollection(Of Version2.GeneralLedger.GeneralJournal))

    Private PageSize As Integer = 500
    Private CurrentPage As Integer = 1
    Private TotalPages As Integer = 0

    ''' <summary>
    ''' On Form load event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub InvoiceListForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        dtpDateFrom.Value = Now
        dtpDateTo.Value = Now
        RefreshData()
    End Sub

    ''' <summary>
    ''' Refresh the data from the API by sending Async calls
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub RefreshData()
        Me.ShowSpinner()
        Dim pageFilter As String = String.Format("$top={0}&$skip={1}&$orderby=DateOccurred desc", PageSize, PageSize * (CurrentPage - 1))

        Dim glInvoiceSvc = New GeneralLedger.GeneralJournalService(myConfiguration, Nothing, myOAuthKeyService)

        glInvoiceSvc.GetRange(myCompanyFile, pageFilter, myCredentials, AddressOf OnComplete, AddressOf OnError)

    End Sub

    'Set the GL code of the main school bank account here (should probably move this to a text file or something)
    Const mainSchoolBankAccount As String = "1-6201"
    Private Sub inputMyobData(inputdate As Date)
        'this function takes a date, calls some other functions to get the edumate data and then inserts the data using the myob API






        If Not isDateAlreadyProcessed(inputdate) Then

            'declare a myob input feed and then call the edumateToMyob main function to populate it with data
            Dim objmyobinputfeed As List(Of myobInputFeed)
            objmyobinputfeed = EdumateToMyob.edumateTyMyobMain(inputdate.ToString("MM/dd/yyyy"))

            'declare our myob API objects
            Dim glInvoiceSvc = New GeneralLedger.GeneralJournalService(myConfiguration, Nothing, myOAuthKeyService)
            Dim glInvoice = New Version2.GeneralLedger.GeneralJournal
            Dim Lines = New List(Of Version2.GeneralLedger.GeneralJournalLine)

            'set the details of the general journal entry
            glInvoice.DateOccurred = inputdate
            glInvoice.GSTReportingMethod = "0"   '0 = sale 1 = purchase
			glInvoice.IsTaxInclusive = True
			glInvoice.Memo = "Edumate payment and transactions"
            glInvoice.IsYearEndAdjustment = False

            'loop through all the lines in our myob input object to set the lines in the myob general journal object
            For Each i As myobInputFeed In objmyobinputfeed

                'if the total on a line is 0, then we exclude it as myob wont accept journal lines without a value
                If i.amount = 0 Then
                    'do nothing
                Else

                    'declare a new line within the journal entry
                    Dim line = New Version2.GeneralLedger.GeneralJournalLine
                    With line

                        'if the GL account is blank, then this must be a transaction line without a corresponding payment, thus it needs a balancing entry against the main bank account
                        If i.glAccount = "" Then
                            .Account = AccountNameToGuid(mainSchoolBankAccount)
                            .Memo = ("Balancing line")
                        Else
                            .Account = AccountNameToGuid(i.glAccount)
                            .Memo = i.memo
                        End If

						'tax code is always N-T (no tax) as tax hasn't been implemented yet
						.TaxCode = TaxCodetoGuid(i.taxCode)
						'.TaxCode = TaxCodetoGuid("N-T")

						'myob seperates values by calling them credits and debits rather than having negative / positive numbers, so we need to take the absolute value for the amount
						' and then set the 'is credit' value based on whether the original amount was positive or negative
						.Amount = Math.Abs(i.amount)
                        If i.amount > 0 Then
                            .IsCredit = False
                        Else
                            .IsCredit = True
                        End If

						'tax always 0 as this hasnt been implemented
						.TaxAmount = i.taxAmount
						'.TaxAmount = 0
						.IsOverriddenTaxAmount = False
                    End With
                    'add the line to the list of lines
                    Lines.Add(line)
                End If
            Next
            'add the list of lines to the journal entry
            glInvoice.Lines = Lines

            'insert the journal entry into myob
            glInvoiceSvc.Insert(myCompanyFile, glInvoice, myCredentials, AddressOf onSaveComplete, AddressOf OnError)
        Else
            MsgBox(inputdate.ToString("dd/MM/yyyy") & " is already processed")
        End If
    End Sub




    ''' <summary>
    ''' Method called on Async complete
    ''' </summary>
    ''' <param name="statusCode"></param>
    ''' <param name="invoices"></param>
    ''' <remarks></remarks>
    Private Sub OnComplete(statusCode As System.Net.HttpStatusCode, invoices As Version2.PagedCollection(Of Version2.GeneralLedger.GeneralJournal))
        'Private Sub OnComplete(statusCode As System.Net.HttpStatusCode, invoices As Version2.PagedCollection(Of Version2.Sale.Invoice))
        'Invoke the SetDataSource method on the UI thread
        Dim d As New SetDataSourceCallback(AddressOf SetDataSource)
        Me.Invoke(d, New Object() {invoices})
    End Sub


    ''' <summary>
    ''' Method to set the datasource
    ''' </summary>
    ''' <param name="invoices">Pages collection of invoices</param>
    ''' <remarks></remarks>
    Private Sub SetDataSource(invoices As Version2.PagedCollection(Of Version2.GeneralLedger.GeneralJournal))

        TotalPages = Math.Ceiling(CDbl(invoices.Count / PageSize))

        btnPageLeft.Enabled = (CurrentPage > 1)
        btnPageRight.Enabled = (CurrentPage < TotalPages)
        textPage.Text = String.Format("Page {0} of {1}", CurrentPage, TotalPages)

        gridAllInvoices.DataSource = invoices.Items

        Me.HideSpinner()
    End Sub

    Private Sub btnPageLeft_Click(sender As System.Object, e As System.EventArgs) Handles btnPageLeft.Click
        CurrentPage -= 1
        RefreshData()
    End Sub

    Private Sub btnPageRight_Click(sender As System.Object, e As System.EventArgs) Handles btnPageRight.Click
        CurrentPage += 1
        RefreshData()
    End Sub



    Private Sub addNew_Click(sender As Object, e As EventArgs) Handles addNew.Click
        'this handles the 'add new' button click

        'show a spinner and lock the button to prevent double clicking
        Me.addNew.Enabled = False
        Me.ShowSpinner()

        'check our date range makes logical sence before trying to run anything
        If dtpDateFrom.Value <= dtpDateTo.Value Then

            'get all the dates between the ranges specified into individual items as a list
            Dim dateRange As List(Of Date) = GetDateRange(dtpDateFrom.Value, dtpDateTo.Value)

            'for each date in the list, call the main input sub
            For Each i In dateRange
                inputMyobData(i)
            Next

        Else
            'error message if our dates arn't logical
            MsgBox("'From Date' must be less than 'To Date'")
        End If

        'hide the spinner and re-enable the button as everything should be done
        Me.HideSpinner()
        Me.addNew.Enabled = True
    End Sub

    ''' <summary>
    ''' Method called on Async complete
    ''' </summary>
    ''' <param name="statusCode"></param>
    ''' <param name="newURI"></param>
    ''' <remarks></remarks>
    Private Sub onSaveComplete(statusCode As System.Net.HttpStatusCode, newURI As String)
        'Invoke the SetDataSource method on the UI thread
        Dim d As New SetSaveCallback(AddressOf SaveCallback)
        Me.Invoke(d, New Object() {newURI})
    End Sub
    Private Sub SaveCallback(newURI As String)
        MessageBox.Show("Saved: " + vbCrLf + newURI)
        HideSpinner()

        If Not IsNothing(Me.Owner) Then
            CType(Me.Owner, InvoiceListForm).RefreshData()
        End If
        Me.Close()
    End Sub
    Delegate Sub SetSaveCallback(newURI As String)


    Private Function AccountNameToGuid(accountCode As String)
        'this function takes an account code as a string, and then returns the account object

        'account service object to pull data with
        Dim accountSvc = New GeneralLedger.AccountService(myConfiguration, Nothing, myOAuthKeyService)

        'the oData filter to use with the API url. We only need to pull down the GL code for the account we're interested in
        Dim strFilter = "$filter=DisplayID eq '" & accountCode & "'"

        'pull the gl accounts into an object
        Dim objAccounts = accountSvc.GetRange(myCompanyFile, strFilter, myCredentials)

        'the account link object will return an account object from its UID
        Dim objAccountLink = New Version2.GeneralLedger.AccountLink

        Dim stopflag As Boolean = True
        Dim count As Int32 = 0

        'look through the list of accounts we pulled for a match on the display ID (there should now only be one object pulled, but the filter was originally pulling all the accounts)
        For Each i In objAccounts.Items

            If i.DisplayID = accountCode Then
                objAccountLink.UID = i.UID

                'return the account object
                AccountNameToGuid = objAccountLink
                stopflag = False
            End If
            count = count + 1
        Next


        If stopflag And accountCode IsNot "" Then
            MsgBox("GL Account " & accountCode & " not found in MYOB")
        Else

        End If
    End Function

    Private Function TaxCodetoGuid(taxCode As String)
        'this function takes a tax code as a string and returns the tax code as an object 

        'tax service object to pull data with
        Dim taxSvc = New GeneralLedger.TaxCodeService(myConfiguration, Nothing, myOAuthKeyService)

        'pull all the tax types into an object 
        Dim objTaxCodes = taxSvc.GetRange(myCompanyFile, Nothing, myCredentials)

        'the tax link object will return an account object from its UID
        Dim objTaxLink = New Version2.GeneralLedger.TaxCodeLink

        Dim stopflag As Boolean = True
        Dim count As Int32 = 0

        'look through all the tax codes until we find a match
        While stopflag And count < objTaxCodes.Count
            If objTaxCodes.Items(count).Code = taxCode Then
                objTaxLink.UID = objTaxCodes.Items(count).UID
                'return the account object
                TaxCodetoGuid = objTaxLink
                stopflag = False
            End If
            count = count + 1
        End While

        If stopflag Then
            MsgBox("Tax code not found")
        End If
    End Function


    Private Function GetDateRange(dateFrom As Date, dateTo As Date)
        'takes two dates and returns all the dates in-between (inclusive) as a list of dates 

        Dim dateRange As New List(Of Date)
        While dateFrom <= dateTo
            dateRange.Add(dateFrom)
            dateFrom = dateFrom.AddDays(1)
        End While

        GetDateRange = dateRange

    End Function

    Private Function isDateAlreadyProcessed(inputdate As Date)
        'takes a date, and returns true or false to indicate whether the date has already been processed

        Dim boolFound As Boolean = False
        Dim objGLAccountSvc As New GeneralLedger.GeneralJournalService(myConfiguration, Nothing, myOAuthKeyService)


        Dim strFilter As String = "$top=10000000&$orderby=DisplayID&$filter=day(DateOccurred) eq " & inputdate.ToString("dd") & " and month(DateOccurred) eq " & inputdate.ToString("MM") & " and year(DateOccurred) eq " & inputdate.ToString("yyyy")

        Dim objGLJournalEntries = objGLAccountSvc.GetRange(myCompanyFile, strFilter, myCredentials)

        For Each i In objGLJournalEntries.Items
            If i.Memo = "Edumate payment and transactions" Then
                boolFound = True
            End If
        Next

        isDateAlreadyProcessed = boolFound
    End Function




End Class
