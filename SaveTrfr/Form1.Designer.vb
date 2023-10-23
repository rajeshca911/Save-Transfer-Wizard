<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PSIPtxt = New System.Windows.Forms.TextBox()
        Me.PSportTxt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UserCmbBox = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Statlbl = New System.Windows.Forms.Label()
        Me.CmbSave = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Verlbl = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.BtnUpload = New System.Windows.Forms.Button()
        Me.BtnDownload = New System.Windows.Forms.Button()
        Me.GetUsersBtn = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'PSIPtxt
        '
        Me.PSIPtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PSIPtxt.Location = New System.Drawing.Point(36, 29)
        Me.PSIPtxt.Name = "PSIPtxt"
        Me.PSIPtxt.Size = New System.Drawing.Size(183, 22)
        Me.PSIPtxt.TabIndex = 0
        Me.PSIPtxt.Text = "192.168.0.100"
        '
        'PSportTxt
        '
        Me.PSportTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PSportTxt.Location = New System.Drawing.Point(225, 29)
        Me.PSportTxt.Name = "PSportTxt"
        Me.PSportTxt.Size = New System.Drawing.Size(100, 22)
        Me.PSportTxt.TabIndex = 1
        Me.PSportTxt.Text = "1337"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(36, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "IP Address"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(222, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Port"
        '
        'UserCmbBox
        '
        Me.UserCmbBox.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UserCmbBox.FormattingEnabled = True
        Me.UserCmbBox.Location = New System.Drawing.Point(36, 134)
        Me.UserCmbBox.Name = "UserCmbBox"
        Me.UserCmbBox.Size = New System.Drawing.Size(191, 25)
        Me.UserCmbBox.TabIndex = 4
        Me.UserCmbBox.Text = "Select User Profile"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(36, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(60, 17)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Profile(s)"
        '
        'Statlbl
        '
        Me.Statlbl.Font = New System.Drawing.Font("Segoe UI", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Statlbl.ForeColor = System.Drawing.Color.Maroon
        Me.Statlbl.Location = New System.Drawing.Point(2, 225)
        Me.Statlbl.Name = "Statlbl"
        Me.Statlbl.Size = New System.Drawing.Size(355, 27)
        Me.Statlbl.TabIndex = 9
        Me.Statlbl.Text = "Status : Not Connected"
        '
        'CmbSave
        '
        Me.CmbSave.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbSave.FormattingEnabled = True
        Me.CmbSave.Location = New System.Drawing.Point(36, 187)
        Me.CmbSave.Name = "CmbSave"
        Me.CmbSave.Size = New System.Drawing.Size(191, 25)
        Me.CmbSave.TabIndex = 10
        Me.CmbSave.Text = "Select Save Folder"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(36, 167)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Save Directories"
        '
        'Verlbl
        '
        Me.Verlbl.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Verlbl.ForeColor = System.Drawing.Color.DarkBlue
        Me.Verlbl.Location = New System.Drawing.Point(2, 250)
        Me.Verlbl.Name = "Verlbl"
        Me.Verlbl.Size = New System.Drawing.Size(313, 24)
        Me.Verlbl.TabIndex = 12
        Me.Verlbl.Text = "Save Directories"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(21, 275)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(394, 8)
        Me.ProgressBar1.TabIndex = 13
        Me.ProgressBar1.Value = 10
        Me.ProgressBar1.Visible = False
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.MistyRose
        Me.BtnDelete.Enabled = False
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnDelete.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.Image = Global.SaveTrfr.My.Resources.Resources.delete_FILL0_wght400_GRAD0_opsz24
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete.Location = New System.Drawing.Point(257, 167)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(140, 36)
        Me.BtnDelete.TabIndex = 14
        Me.BtnDelete.Text = "Delete"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'BtnUpload
        '
        Me.BtnUpload.BackColor = System.Drawing.Color.Orange
        Me.BtnUpload.Enabled = False
        Me.BtnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnUpload.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpload.Image = Global.SaveTrfr.My.Resources.Resources.upload_FILL0_wght400_GRAD0_opsz24
        Me.BtnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnUpload.Location = New System.Drawing.Point(257, 119)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(140, 36)
        Me.BtnUpload.TabIndex = 8
        Me.BtnUpload.Text = "Upload"
        Me.BtnUpload.UseVisualStyleBackColor = False
        '
        'BtnDownload
        '
        Me.BtnDownload.BackColor = System.Drawing.Color.LightCyan
        Me.BtnDownload.Enabled = False
        Me.BtnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnDownload.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDownload.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnDownload.Image = Global.SaveTrfr.My.Resources.Resources.download_FILL0_wght400_GRAD0_opsz24
        Me.BtnDownload.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDownload.Location = New System.Drawing.Point(257, 73)
        Me.BtnDownload.Name = "BtnDownload"
        Me.BtnDownload.Size = New System.Drawing.Size(140, 36)
        Me.BtnDownload.TabIndex = 7
        Me.BtnDownload.Text = "Download"
        Me.BtnDownload.UseVisualStyleBackColor = False
        '
        'GetUsersBtn
        '
        Me.GetUsersBtn.BackColor = System.Drawing.Color.Honeydew
        Me.GetUsersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GetUsersBtn.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetUsersBtn.Image = Global.SaveTrfr.My.Resources.Resources.directory_sync_FILL0_wght400_GRAD0_opsz24
        Me.GetUsersBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.GetUsersBtn.Location = New System.Drawing.Point(36, 74)
        Me.GetUsersBtn.Name = "GetUsersBtn"
        Me.GetUsersBtn.Size = New System.Drawing.Size(180, 32)
        Me.GetUsersBtn.TabIndex = 6
        Me.GetUsersBtn.Text = "Get Users"
        Me.GetUsersBtn.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(383, 287)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(56, 22)
        Me.Button1.TabIndex = 15
        Me.Button1.Text = "Credits"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(443, 309)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnDelete)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Verlbl)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CmbSave)
        Me.Controls.Add(Me.Statlbl)
        Me.Controls.Add(Me.BtnUpload)
        Me.Controls.Add(Me.BtnDownload)
        Me.Controls.Add(Me.GetUsersBtn)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.UserCmbBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PSportTxt)
        Me.Controls.Add(Me.PSIPtxt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(459, 348)
        Me.MinimumSize = New System.Drawing.Size(459, 348)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Save Transfer Wizard"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PSIPtxt As TextBox
    Friend WithEvents PSportTxt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents UserCmbBox As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents GetUsersBtn As Button
    Friend WithEvents BtnDownload As Button
    Friend WithEvents BtnUpload As Button
    Friend WithEvents Statlbl As Label
    Friend WithEvents CmbSave As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Verlbl As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents BtnDelete As Button
    Friend WithEvents Button1 As Button
End Class
