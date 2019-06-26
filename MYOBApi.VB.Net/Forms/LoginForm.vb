Public Class LoginForm

    ''' <summary>
    ''' Public property to set and get Username
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Username As String
        Get
            Username = txtUsername.Text
        End Get
        Set(value As String)
            txtUsername.Text = Username
        End Set
    End Property

    ''' <summary>
    ''' Public property to set and get Password
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Password As String
        Get
            Password = txtPassword.Text
        End Get
        Set(value As String)
            txtPassword.Text = Password
        End Set
    End Property

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Me.Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        txtUsername.Text = ""
        txtPassword.Text = ""
        Me.Close()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        txtUsername.Text = "Administrator"
    End Sub
End Class
