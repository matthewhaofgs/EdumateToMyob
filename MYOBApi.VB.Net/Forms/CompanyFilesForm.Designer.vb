<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompanyFilesForm
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
        Me.dgvCompanyFiles = New System.Windows.Forms.DataGridView()
        Me.CF_Id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CF_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CF_ProductVersion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CF_LibraryPath = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.picSpinner = New System.Windows.Forms.PictureBox()
        CType(Me.dgvCompanyFiles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picSpinner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgvCompanyFiles
        '
        Me.dgvCompanyFiles.AllowUserToAddRows = False
        Me.dgvCompanyFiles.AllowUserToDeleteRows = False
        Me.dgvCompanyFiles.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvCompanyFiles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells
        Me.dgvCompanyFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCompanyFiles.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CF_Id, Me.CF_Name, Me.CF_ProductVersion, Me.CF_LibraryPath})
        Me.dgvCompanyFiles.Location = New System.Drawing.Point(13, 13)
        Me.dgvCompanyFiles.MultiSelect = False
        Me.dgvCompanyFiles.Name = "dgvCompanyFiles"
        Me.dgvCompanyFiles.ReadOnly = True
        Me.dgvCompanyFiles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCompanyFiles.Size = New System.Drawing.Size(938, 418)
        Me.dgvCompanyFiles.TabIndex = 2
        '
        'CF_Id
        '
        Me.CF_Id.DataPropertyName = "Id"
        Me.CF_Id.HeaderText = "Id"
        Me.CF_Id.Name = "CF_Id"
        Me.CF_Id.ReadOnly = True
        Me.CF_Id.Width = 41
        '
        'CF_Name
        '
        Me.CF_Name.DataPropertyName = "Name"
        Me.CF_Name.HeaderText = "Name"
        Me.CF_Name.Name = "CF_Name"
        Me.CF_Name.ReadOnly = True
        Me.CF_Name.Width = 60
        '
        'CF_ProductVersion
        '
        Me.CF_ProductVersion.DataPropertyName = "ProductVersion"
        Me.CF_ProductVersion.HeaderText = "ProductVersion"
        Me.CF_ProductVersion.Name = "CF_ProductVersion"
        Me.CF_ProductVersion.ReadOnly = True
        Me.CF_ProductVersion.Width = 104
        '
        'CF_LibraryPath
        '
        Me.CF_LibraryPath.DataPropertyName = "LibraryPath"
        Me.CF_LibraryPath.HeaderText = "LibraryPath"
        Me.CF_LibraryPath.Name = "CF_LibraryPath"
        Me.CF_LibraryPath.ReadOnly = True
        Me.CF_LibraryPath.Visible = False
        Me.CF_LibraryPath.Width = 85
        '
        'picSpinner
        '
        Me.picSpinner.BackColor = System.Drawing.Color.White
        Me.picSpinner.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picSpinner.Image = Global.MYOBApi.VB.Net.My.Resources.Resources.spinnerLarge
        Me.picSpinner.Location = New System.Drawing.Point(445, 207)
        Me.picSpinner.Name = "picSpinner"
        Me.picSpinner.Padding = New System.Windows.Forms.Padding(5)
        Me.picSpinner.Size = New System.Drawing.Size(72, 72)
        Me.picSpinner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picSpinner.TabIndex = 4
        Me.picSpinner.TabStop = False
        '
        'CompanyFilesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 486)
        Me.Controls.Add(Me.picSpinner)
        Me.Controls.Add(Me.dgvCompanyFiles)
        Me.Name = "CompanyFilesForm"
        Me.Text = "Company Files"
        CType(Me.dgvCompanyFiles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picSpinner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvCompanyFiles As System.Windows.Forms.DataGridView
    Friend WithEvents CF_Id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CF_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CF_ProductVersion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CF_LibraryPath As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents picSpinner As System.Windows.Forms.PictureBox

End Class
