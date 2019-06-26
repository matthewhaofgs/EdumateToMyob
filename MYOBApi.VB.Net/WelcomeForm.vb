Public Class WelcomeForm
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub lnkGetStarted_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkGetStarted.LinkClicked
        Dim frmCompanyFiles As New CompanyFilesForm
        frmCompanyFiles.Show()

    End Sub

    Private Sub welcomeform_load() Handles Me.Load
        Try
            With System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion
                lblVersion.Text = "V" & .Major & "." & .Minor & "." & .Build & "." & .Revision
            End With
        Catch
        End Try
    End Sub
End Class
