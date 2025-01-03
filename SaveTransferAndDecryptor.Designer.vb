<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SaveTransferAndDecryptor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaveTransferAndDecryptor))
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PSportTxt = New System.Windows.Forms.TextBox()
        Me.PSIPtxt = New System.Windows.Forms.TextBox()
        Me.StatLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GetUsersBtn = New System.Windows.Forms.Button()
        Me.processesComboBox = New System.Windows.Forms.ComboBox()
        Me.setupButton = New System.Windows.Forms.Button()
        Me.userComboBox = New System.Windows.Forms.ComboBox()
        Me.fwVersionComboBox = New System.Windows.Forms.ComboBox()
        Me.dirsComboBox = New System.Windows.Forms.ComboBox()
        Me.searchButton = New System.Windows.Forms.Button()
        Me.mountButton = New System.Windows.Forms.Button()
        Me.unmountButton = New System.Windows.Forms.Button()
        Me.Line1 = New System.Windows.Forms.Label()
        Me.Line2 = New System.Windows.Forms.Label()
        Me.FetchMntDir = New System.Windows.Forms.Button()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(198, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "FTP Port"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "IP Address"
        '
        'PSportTxt
        '
        Me.PSportTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PSportTxt.Location = New System.Drawing.Point(201, 36)
        Me.PSportTxt.Name = "PSportTxt"
        Me.PSportTxt.Size = New System.Drawing.Size(100, 22)
        Me.PSportTxt.TabIndex = 5
        Me.PSportTxt.Text = "2121"
        '
        'PSIPtxt
        '
        Me.PSIPtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PSIPtxt.Location = New System.Drawing.Point(12, 36)
        Me.PSIPtxt.Name = "PSIPtxt"
        Me.PSIPtxt.Size = New System.Drawing.Size(183, 22)
        Me.PSIPtxt.TabIndex = 4
        Me.PSIPtxt.Text = "192.168.29.146"
        '
        'StatLabel
        '
        Me.StatLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatLabel.Location = New System.Drawing.Point(27, 391)
        Me.StatLabel.Name = "StatLabel"
        Me.StatLabel.Size = New System.Drawing.Size(338, 24)
        Me.StatLabel.TabIndex = 1
        Me.StatLabel.Text = "Not Connected."
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(4, 391)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'GetUsersBtn
        '
        Me.GetUsersBtn.BackColor = System.Drawing.Color.Honeydew
        Me.GetUsersBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GetUsersBtn.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GetUsersBtn.Image = Global.SaveTrfr.My.Resources.Resources.directory_sync_FILL0_wght400_GRAD0_opsz24
        Me.GetUsersBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.GetUsersBtn.Location = New System.Drawing.Point(16, 93)
        Me.GetUsersBtn.Name = "GetUsersBtn"
        Me.GetUsersBtn.Size = New System.Drawing.Size(180, 32)
        Me.GetUsersBtn.TabIndex = 8
        Me.GetUsersBtn.Text = "Connect"
        Me.GetUsersBtn.UseVisualStyleBackColor = False
        '
        'processesComboBox
        '
        Me.processesComboBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.processesComboBox.FormattingEnabled = True
        Me.processesComboBox.Location = New System.Drawing.Point(174, 145)
        Me.processesComboBox.Name = "processesComboBox"
        Me.processesComboBox.Size = New System.Drawing.Size(180, 25)
        Me.processesComboBox.TabIndex = 9
        Me.processesComboBox.Text = "Select Process"
        Me.processesComboBox.Visible = False
        '
        'setupButton
        '
        Me.setupButton.BackColor = System.Drawing.Color.MistyRose
        Me.setupButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.setupButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.setupButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.setupButton.Location = New System.Drawing.Point(12, 174)
        Me.setupButton.Name = "setupButton"
        Me.setupButton.Size = New System.Drawing.Size(156, 27)
        Me.setupButton.TabIndex = 10
        Me.setupButton.Text = "Get Users"
        Me.setupButton.UseVisualStyleBackColor = False
        '
        'userComboBox
        '
        Me.userComboBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.userComboBox.FormattingEnabled = True
        Me.userComboBox.Location = New System.Drawing.Point(174, 176)
        Me.userComboBox.Name = "userComboBox"
        Me.userComboBox.Size = New System.Drawing.Size(180, 25)
        Me.userComboBox.TabIndex = 11
        Me.userComboBox.Text = "Select User"
        Me.userComboBox.Visible = False
        '
        'fwVersionComboBox
        '
        Me.fwVersionComboBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fwVersionComboBox.FormattingEnabled = True
        Me.fwVersionComboBox.Location = New System.Drawing.Point(15, 64)
        Me.fwVersionComboBox.Name = "fwVersionComboBox"
        Me.fwVersionComboBox.Size = New System.Drawing.Size(180, 25)
        Me.fwVersionComboBox.TabIndex = 12
        Me.fwVersionComboBox.Text = "Select Firmware"
        '
        'dirsComboBox
        '
        Me.dirsComboBox.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dirsComboBox.FormattingEnabled = True
        Me.dirsComboBox.Location = New System.Drawing.Point(174, 209)
        Me.dirsComboBox.Name = "dirsComboBox"
        Me.dirsComboBox.Size = New System.Drawing.Size(180, 25)
        Me.dirsComboBox.TabIndex = 14
        Me.dirsComboBox.Text = "Select Save Directory"
        Me.dirsComboBox.Visible = False
        '
        'searchButton
        '
        Me.searchButton.BackColor = System.Drawing.Color.Bisque
        Me.searchButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.searchButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.searchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.searchButton.Location = New System.Drawing.Point(12, 207)
        Me.searchButton.Name = "searchButton"
        Me.searchButton.Size = New System.Drawing.Size(156, 27)
        Me.searchButton.TabIndex = 13
        Me.searchButton.Text = "Search Save Folders"
        Me.searchButton.UseVisualStyleBackColor = False
        Me.searchButton.Visible = False
        '
        'mountButton
        '
        Me.mountButton.BackColor = System.Drawing.Color.YellowGreen
        Me.mountButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.mountButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mountButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.mountButton.Location = New System.Drawing.Point(24, 264)
        Me.mountButton.Name = "mountButton"
        Me.mountButton.Size = New System.Drawing.Size(156, 27)
        Me.mountButton.TabIndex = 15
        Me.mountButton.Text = "Mount"
        Me.mountButton.UseVisualStyleBackColor = False
        Me.mountButton.Visible = False
        '
        'unmountButton
        '
        Me.unmountButton.BackColor = System.Drawing.Color.LightPink
        Me.unmountButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.unmountButton.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.unmountButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.unmountButton.Location = New System.Drawing.Point(186, 264)
        Me.unmountButton.Name = "unmountButton"
        Me.unmountButton.Size = New System.Drawing.Size(156, 27)
        Me.unmountButton.TabIndex = 16
        Me.unmountButton.Text = "Unmount"
        Me.unmountButton.UseVisualStyleBackColor = False
        Me.unmountButton.Visible = False
        '
        'Line1
        '
        Me.Line1.BackColor = System.Drawing.Color.Black
        Me.Line1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Line1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Line1.Location = New System.Drawing.Point(-10, 245)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(388, 5)
        Me.Line1.TabIndex = 5
        Me.Line1.Visible = False
        '
        'Line2
        '
        Me.Line2.BackColor = System.Drawing.Color.Black
        Me.Line2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Line2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Line2.Location = New System.Drawing.Point(-11, 303)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(388, 5)
        Me.Line2.TabIndex = 18
        Me.Line2.Visible = False
        '
        'FetchMntDir
        '
        Me.FetchMntDir.BackColor = System.Drawing.Color.MidnightBlue
        Me.FetchMntDir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.FetchMntDir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FetchMntDir.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.FetchMntDir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.FetchMntDir.Location = New System.Drawing.Point(24, 311)
        Me.FetchMntDir.Name = "FetchMntDir"
        Me.FetchMntDir.Size = New System.Drawing.Size(318, 27)
        Me.FetchMntDir.TabIndex = 19
        Me.FetchMntDir.Text = "Download / Upload"
        Me.FetchMntDir.UseVisualStyleBackColor = False
        Me.FetchMntDir.Visible = False
        '
        'SaveTransferAndDecryptor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(366, 415)
        Me.Controls.Add(Me.FetchMntDir)
        Me.Controls.Add(Me.Line2)
        Me.Controls.Add(Me.Line1)
        Me.Controls.Add(Me.unmountButton)
        Me.Controls.Add(Me.mountButton)
        Me.Controls.Add(Me.dirsComboBox)
        Me.Controls.Add(Me.searchButton)
        Me.Controls.Add(Me.fwVersionComboBox)
        Me.Controls.Add(Me.userComboBox)
        Me.Controls.Add(Me.setupButton)
        Me.Controls.Add(Me.processesComboBox)
        Me.Controls.Add(Me.StatLabel)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.GetUsersBtn)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PSportTxt)
        Me.Controls.Add(Me.PSIPtxt)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "SaveTransferAndDecryptor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Save Transfer And Decryptor"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents PSportTxt As TextBox
    Friend WithEvents PSIPtxt As TextBox
    Friend WithEvents GetUsersBtn As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents StatLabel As Label
    Friend WithEvents processesComboBox As ComboBox
    Friend WithEvents setupButton As Button
    Friend WithEvents userComboBox As ComboBox
    Friend WithEvents fwVersionComboBox As ComboBox
    Friend WithEvents dirsComboBox As ComboBox
    Friend WithEvents searchButton As Button
    Friend WithEvents mountButton As Button
    Friend WithEvents unmountButton As Button
    Friend WithEvents Line1 As Label
    Friend WithEvents Line2 As Label
    Friend WithEvents FetchMntDir As Button
End Class
