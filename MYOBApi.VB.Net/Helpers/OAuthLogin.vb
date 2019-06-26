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


'' NOTE:
'' This file requires .Net framework 4 full profile and a 
'' reference to System.Web to be added to project
Imports System.Web
Imports System.Text.RegularExpressions
Imports MYOB.AccountRight.SDK

Module OAuthLogin

    Private Const csOAuthServer As String = "https://secure.myob.com/oauth2/account/authorize/"
    Private Const csOAuthScope As String = "CompanyFile"

    ''' <summary>
    ''' Function to return the OAuth code
    ''' </summary>
    ''' <param name="config">Contains the API configuration such as ClientId and Redirect URL</param>
    ''' <returns>OAuth code</returns>
    ''' <remarks></remarks>
    Public Function GetAuthorizationCode(config As IApiConfiguration) As String
        'Format the URL so  User can login to OAuth server
        Dim url As String = String.Format("{0}?client_id={1}&redirect_uri={2}&scope={3}&response_type=code",
                                          csOAuthServer, config.ClientId, HttpUtility.UrlEncode(config.RedirectUrl), csOAuthScope)

        ' Create a new form with a web browser to display OAuth login page
        Dim frm As Form = New Form()
        Dim webB As WebBrowser = New WebBrowser()
        frm.Controls.Add(webB)
        webB.Dock = DockStyle.Fill

        ' Add a handler for the web browser to capture content change 
        AddHandler webB.DocumentTitleChanged, AddressOf webB_DocumentTitleChanged

        ' navigat to url and display form
        webB.Navigate(url)
        frm.Size = New Size(800, 600)
        frm.ShowDialog()

        'Retrieve the code from the returned HTML
        GetAuthorizationCode = ExtractSubstring(webB.DocumentText, "code=", "<")
    End Function


    ''' <summary>
    ''' Handler that is called when HTML title is changed in browser (i.e. content is reloaded)
    ''' Once user has signed in to OAth page and authorised this app the OAuth code is returned in the HTML content 
    ''' </summary>
    ''' <param name="sender">The web browser control</param>
    ''' <param name="e">The event</param>
    ''' <remarks>This assumes redirect URL is http://desktop</remarks>
    Private Sub webB_DocumentTitleChanged(sender As Object, e As EventArgs)
        Dim webB As WebBrowser = TryCast(sender, WebBrowser)
        Dim frm As Form = TryCast(webB.Parent, Form)

        'Check if OAuth code is returned
        If webB.DocumentText.Contains("code=") Then
            frm.Close()
        End If

    End Sub

    ''' <summary>
    ''' Function to retrieve content from a string based on begining and ending pattern
    ''' </summary>
    ''' <param name="input">input string</param>
    ''' <param name="startsWith">start pattern</param>
    ''' <param name="endsWith">end pattern</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function ExtractSubstring(input As String, startsWith As String, endsWith As String) As String
        Dim match As Match = Regex.Match(input, startsWith + "(.*)" + endsWith)
        Dim code As String = match.Groups(1).Value
        Return code
    End Function
End Module
