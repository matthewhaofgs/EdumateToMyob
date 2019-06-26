<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBase
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBase))
        Me.CloseBtn = New System.Windows.Forms.Button()
        Me.picSpinner = New System.Windows.Forms.PictureBox()
        CType(Me.picSpinner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CloseBtn
        '
        Me.CloseBtn.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseBtn.Location = New System.Drawing.Point(697, 527)
        Me.CloseBtn.Name = "CloseBtn"
        Me.CloseBtn.Size = New System.Drawing.Size(75, 23)
        Me.CloseBtn.TabIndex = 2
        Me.CloseBtn.Text = "&Close"
        Me.CloseBtn.UseVisualStyleBackColor = True
        '
        'picSpinner
        '
        Me.picSpinner.BackColor = System.Drawing.Color.White
        Me.picSpinner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picSpinner.Image = Global.MYOBApi.VB.Net.My.Resources.Resources.spinnerLarge
        Me.picSpinner.Location = New System.Drawing.Point(362, 251)
        Me.picSpinner.Name = "picSpinner"
        Me.picSpinner.Padding = New System.Windows.Forms.Padding(5)
        Me.picSpinner.Size = New System.Drawing.Size(72, 72)
        Me.picSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picSpinner.TabIndex = 3
        Me.picSpinner.TabStop = False
        '
        'FormBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.picSpinner)
        Me.Controls.Add(Me.CloseBtn)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormBase"
        Me.Text = "FormBase"
        CType(Me.picSpinner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CloseBtn As System.Windows.Forms.Button
    Friend WithEvents picSpinner As System.Windows.Forms.PictureBox
End Class
