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

Imports MYOB.AccountRight.SDK
Imports MYOB.AccountRight.SDK.Contracts
Imports System.IO
Imports System.IO.IsolatedStorage
Imports Newtonsoft.Json

Public Class OAuthKeyService
    Implements IOAuthKeyService

    Private Const csTokensFile As String = "Tokens.json"
    Private tokens As OAuthTokens = Nothing


    ''' <summary>
    ''' On creation read any settings from file
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        ReadFromFile()
    End Sub

    ''' <summary>
    ''' Implements the property for OAuthResponse which holdes theTokens
    ''' </summary>
    ''' <value>object containing OAuthTokens</value>
    ''' <returns>Contracts.OAuthTokens</returns>
    ''' <remarks>Saves to isolated storage when set</remarks>
    Public Property OAuthResponse As OAuthTokens Implements IOAuthKeyService.OAuthResponse
        Get
            OAuthResponse = tokens
        End Get
        Set(value As OAuthTokens)
            tokens = value
            SaveToFile()
        End Set
    End Property


    ''' <summary>
    ''' Method to read Tokens from Isolated storage
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ReadFromFile()
        Try
            ' Get an isolated store for user and application 
            Dim isoStore As IsolatedStorageFile
            isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
                IsolatedStorageScope.Domain Or IsolatedStorageScope.Assembly, Nothing, Nothing)

            Dim isoStream As New IsolatedStorageFileStream(csTokensFile, FileMode.Open, FileAccess.Read, FileShare.Read)

            Dim reader As New StreamReader(isoStream)
            ' Read the data.

            tokens = JsonConvert.DeserializeObject(Of OAuthTokens)(reader.ReadToEnd)
            reader.Close()

            isoStore.Dispose()
            isoStore.Close()

        Catch ex As System.IO.FileNotFoundException
            ' Expected exception if a file cannot be found. This indicates that we have a new user.
            tokens = Nothing
        End Try

    End Sub


    ''' <summary>
    ''' Method to save tokens to isolated storage
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveToFile()
        ' Get an isolated store for user and application 
        Dim isoStore As IsolatedStorageFile
        isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User Or _
            IsolatedStorageScope.Domain Or IsolatedStorageScope.Assembly, Nothing, Nothing)

        ' Create a file
        Dim isoStream As New IsolatedStorageFileStream(csTokensFile, FileMode.OpenOrCreate, FileAccess.Write, isoStore)
        isoStream.SetLength(0) 'Position to overwrite the old data.

        ' Write tokens to file
        Dim writer As New StreamWriter(isoStream)
        writer.Write(JsonConvert.SerializeObject(tokens))
        writer.Close()

        isoStore.Dispose()
        isoStore.Close()
    End Sub

End Class
