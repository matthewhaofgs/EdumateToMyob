'  Author:      Matthew Harding
'  E-mail:      matthewha@ofgs.nsw.edu.au

Imports System.Net
Imports System.IO
Imports MYOB.AccountRight.SDK
Imports MYOB.AccountRight.SDK.Services
Imports MYOB.AccountRight.SDK.Contracts

Public Class CompanyFilesForm

    ' This delegate enables asynchronous calls for setting
    ' the text property on a TextBox control.
    Delegate Sub SetDataSourceCallback(companyFiles() As CompanyFile)

    Private Const LocalApiUrl As String = "http://localhost:8080/accountright"

	Private Const useCloud As Boolean = True

    Private _configurationCloud As IApiConfiguration
    Private _configurationLocal As IApiConfiguration
    Private _oAuthKeyService As IOAuthKeyService

    ''' <summary>
    ''' Event that is called when the form loads
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub CompanyFiles_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        Try
            ShowSpinner()

            'If developer key  enable (see above) and set useCVloud to true the following section manages OAuth token and accessing cloud service 
            If useCloud Then
				_configurationCloud = New ApiConfiguration(readTextFile("DeveloperKey.txt"), readTextFile("DeveloperSecret.txt"), "http://desktop")
				_oAuthKeyService = New OAuthKeyService()

                'Get tokens if not stored
                If _oAuthKeyService.OAuthResponse Is Nothing Then
                    Dim oauthService As New OAuthService(_configurationCloud)
                    _oAuthKeyService.OAuthResponse = oauthService.GetTokens(OAuthLogin.GetAuthorizationCode(_configurationCloud))
                End If

                ' Load all files from cloud and local simultaneously
                Dim cfsCloud = New CompanyFileService(_configurationCloud, Nothing, _oAuthKeyService)
                cfsCloud.GetRange(AddressOf OnComplete, AddressOf OnError)

            End If

            '***** comment out this for cloud only ****
            '_configurationLocal = New ApiConfiguration(LocalApiUrl)
            'Dim cfsLocal = New CompanyFileService(_configurationLocal)
            'cfsLocal.GetRange(AddressOf OnComplete, AddressOf OnError)
            '*** end ***

            '' The following two lines can be called to run synchronously rather than async
            '   _companyFiles = cfs.GetRange()
            '    dgvCompanyFiles.DataSource = _companyFiles
            '
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Method to handle onComplete Event
    ''' </summary>
    ''' <param name="companyFiles"></param>
    ''' <remarks>see http://msdn.microsoft.com/en-us/library/ms171728(v=vs.85).aspx </remarks>
    Private Sub OnComplete(statusCode As System.Net.HttpStatusCode, companyFiles() As CompanyFile)
        'Invoke the SetDataSource method on the UI thread
        Dim d As New SetDataSourceCallback(AddressOf SetDataSource)
        Me.Invoke(d, New Object() {companyFiles})
    End Sub

    ''' <summary>
    ''' Method to set the datasource
    ''' </summary>
    ''' <param name="companyFiles">CompanyFiles Array</param>
    ''' <remarks></remarks>
    Private Sub SetDataSource(companyFiles() As CompanyFile)

        'Filter the list to show only files that are supported by v2 of the API
        Dim filteredList = companyFiles.Where(Function(x) New Version(x.ProductVersion) >= New Version(2013.3)).ToArray

        If dgvCompanyFiles.DataSource Is Nothing Then
            dgvCompanyFiles.DataSource = filteredList
            HideSpinner()
            If Not useCloud Then
                HideSpinner()
            End If
        Else
            '***********
            'dgvCompanyFiles.DataSource = CType(dgvCompanyFiles.DataSource, CompanyFile()).Union(filteredList).ToArray()
            '*************
            HideSpinner()

        End If
    End Sub

    ''' <summary>
    ''' Callback if there is an error
    ''' </summary>
    ''' <param name="uri"></param>
    ''' <param name="ex"></param>
    ''' <remarks></remarks>
    Private Sub OnError(uri As System.Uri, ex As System.Exception)
        MessageBox.Show(ex.Message)
    End Sub


    Private Sub dgvCompanyFiles_CellContentDoubleClick(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCompanyFiles.CellContentDoubleClick

        'Get the selected company file
        Dim companyFile As CompanyFile = CType(dgvCompanyFiles.DataSource, CompanyFile())(e.RowIndex)

        'Get configuration that matches server where file is
        Dim config As IApiConfiguration
        If companyFile.Uri.GetLeftPart(UriPartial.Path).ToLower().Contains(LocalApiUrl) Then
            config = _configurationLocal
        Else
            config = _configurationCloud
        End If

        'Get the credentials for the database
        Dim frmLogin As New LoginForm
        frmLogin.ShowDialog(Me)
        If frmLogin.Username.Length > 0 Then
            Dim credentials As ICompanyFileCredentials = New CompanyFileCredentials(frmLogin.Username, frmLogin.Password)

            'load the Invoice List
            Dim frmInvoiceList As New InvoiceListForm()
            frmInvoiceList.Initialise(config, companyFile, credentials, _oAuthKeyService)
            frmInvoiceList.Show()
        End If
    End Sub


    Protected Sub ShowSpinner()
        picSpinner.BringToFront()
        picSpinner.Show()
    End Sub

	Protected Sub HideSpinner()
		picSpinner.Hide()
	End Sub

	Function readTextFile(filename As String)
		Dim directory As String = My.Application.Info.DirectoryPath

		Dim strKey

		Using sr As New StreamReader(directory & "\Resources\" & filename)
			Dim line As String
			While Not sr.EndOfStream
				line = sr.ReadLine
				If Not IsNothing(line) Then
					strKey = line
				End If
			End While
		End Using

		readTextFile = strKey

	End Function

End Class
