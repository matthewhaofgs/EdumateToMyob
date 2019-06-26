'  Copyright:   Copyright 2013 MYOB Technology Pty Ltd. All rights reserved.
'  Website:     http://www.myob.com
'  Author:      MYOB
'  E-mail:      info@myob.com
'
' Documentation, code and sample applications provided by MYOB Australia are for 
' information purposes only. MYOB Technology Pty Ltd and its suppliers make no 
' warranties, either express or implied, in this document. 
'
' Information in this document or code, including website references, is subject
' to change without notice. Unless otherwise noted, the example companies, 
' organisations, products, domain names, email addresses, people, places, and 
' events are fictitious. 
'
' The entire risk of the use of this documentation or code remains with the user. 
' Complying with all applicable copyright laws is the responsibility of the user. 
'
' Copyright 2013 MYOB Technology Pty Ltd. All rights reserved.

Imports System.Net
Imports System.IO
Imports System.Text
Imports MYOB.AccountRight.SDK
Imports MYOB.AccountRight.SDK.Contracts

Public Class FormBase

    ' This delegate enables asynchronous calls to return to UI thread
    Delegate Sub SetHideSpinnerCallback()

    Protected myConfiguration As IApiConfiguration
    Protected myCompanyFile As CompanyFile
    Protected myCredentials As ICompanyFileCredentials
    Protected myOAuthKeyService As IOAuthKeyService

    Public Sub Initialise(configuration As IApiConfiguration, companyFile As CompanyFile, _
                          credentials As ICompanyFileCredentials, oAuthKeyService As IOAuthKeyService)

        ' Add any initialization after the InitializeComponent() call.
        myConfiguration = configuration
        myCompanyFile = companyFile
        myCredentials = credentials
        myOAuthKeyService = oAuthKeyService

        Me.Text = companyFile.Name + " - " + companyFile.Uri.ToString
    End Sub

    Private Sub CloseBtn_Click(sender As System.Object, e As System.EventArgs) Handles CloseBtn.Click
        Me.Close()
    End Sub


#Region "Error callback"
    ''' <summary>
    ''' Callback if there is an error
    ''' </summary>
    ''' <param name="uri"></param>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    Protected Sub OnError(uri As System.Uri, ex As System.Exception)

        'Display thr formatted message
        Select Case ex.GetType()
            Case GetType(System.Net.WebException)
                MessageBox.Show(FormatMessage(CType(ex, System.Net.WebException)))
            Case GetType(MYOB.AccountRight.SDK.ApiCommunicationException)
                MessageBox.Show(FormatMessage(CType(ex.InnerException, System.Net.WebException)))
            Case GetType(MYOB.AccountRight.SDK.ApiOperationException)
                MessageBox.Show(ex.Message)
            Case Else
                MessageBox.Show(ex.Message)
        End Select

        HideSpinner()
    End Sub


    Private Function FormatMessage(webEx As System.Net.WebException) As String

        Dim responseText As New StringBuilder()
        responseText.AppendLine(webEx.Message)
        responseText.AppendLine()

        ' Call method 'GetResponseStream' to obtain stream associated with the response object 
        Dim response As WebResponse = webEx.Response
        Dim ReceiveStream As Stream = response.GetResponseStream()

        Dim encode As Encoding = System.Text.Encoding.GetEncoding("utf-8")

        ' Pipe the stream to a higher level stream reader with the required encoding format. 
        Dim readStream As New StreamReader(ReceiveStream, encode)
        Dim read(256) As [Char]

        ' Read 256 charcters at a time    . 
        Dim count As Integer = readStream.Read(read, 0, 256)
        responseText.AppendLine("HTML...")
        While count > 0

            ' Dump the 256 characters on a string and display the string onto the console. 
            Dim str As New [String](read, 0, count)
            responseText.Append(str)
            count = readStream.Read(read, 0, 256)

        End While
        responseText.Append("")

        ' Release the resources of stream object.
        readStream.Close()

        ' Release the resources of response object.
        response.Close()

        Return responseText.ToString

    End Function
#End Region


    Protected Sub ShowSpinner()

        If picSpinner.InvokeRequired Then
            'Invoke the SetDataSource method on the UI thread
            Dim d As New SetHideSpinnerCallback(AddressOf HideSpinner)
            Me.Invoke(d, New Object())
        Else
            picSpinner.BringToFront()
            picSpinner.Show()
        End If

    End Sub

    Protected Sub HideSpinner()
        If picSpinner.InvokeRequired Then
            'Invoke the SetDataSource method on the UI thread
            Dim d As New SetHideSpinnerCallback(AddressOf HideSpinner)
            Me.Invoke(d)
        Else
            picSpinner.Hide()
        End If
    End Sub

End Class

