<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PS5FTPFORM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PS5FTPFORM))
        Me.ComboMountedPath = New System.Windows.Forms.ComboBox()
        Me.DirCombo = New System.Windows.Forms.ComboBox()
        Me.BtnDownload = New System.Windows.Forms.Button()
        Me.BtnUpload = New System.Windows.Forms.Button()
        Me.StatLabel = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboMountedPath
        '
        Me.ComboMountedPath.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboMountedPath.FormattingEnabled = True
        Me.ComboMountedPath.Location = New System.Drawing.Point(29, 12)
        Me.ComboMountedPath.Name = "ComboMountedPath"
        Me.ComboMountedPath.Size = New System.Drawing.Size(218, 25)
        Me.ComboMountedPath.TabIndex = 0
        Me.ComboMountedPath.Text = "Select Mounted Path"
        '
        'DirCombo
        '
        Me.DirCombo.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DirCombo.FormattingEnabled = True
        Me.DirCombo.Location = New System.Drawing.Point(29, 43)
        Me.DirCombo.Name = "DirCombo"
        Me.DirCombo.Size = New System.Drawing.Size(218, 25)
        Me.DirCombo.TabIndex = 1
        Me.DirCombo.Text = "Select Folder"
        '
        'BtnDownload
        '
        Me.BtnDownload.BackColor = System.Drawing.Color.DarkSlateGray
        Me.BtnDownload.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDownload.ForeColor = System.Drawing.Color.White
        Me.BtnDownload.Location = New System.Drawing.Point(29, 84)
        Me.BtnDownload.Name = "BtnDownload"
        Me.BtnDownload.Size = New System.Drawing.Size(218, 31)
        Me.BtnDownload.TabIndex = 2
        Me.BtnDownload.Text = "Download To PC"
        Me.BtnDownload.UseVisualStyleBackColor = False
        '
        'BtnUpload
        '
        Me.BtnUpload.BackColor = System.Drawing.Color.Indigo
        Me.BtnUpload.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUpload.ForeColor = System.Drawing.Color.White
        Me.BtnUpload.Location = New System.Drawing.Point(29, 121)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.Size = New System.Drawing.Size(218, 31)
        Me.BtnUpload.TabIndex = 3
        Me.BtnUpload.Text = "Upload To Playstation"
        Me.BtnUpload.UseVisualStyleBackColor = False
        '
        'StatLabel
        '
        Me.StatLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.StatLabel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StatLabel.Location = New System.Drawing.Point(29, 184)
        Me.StatLabel.Name = "StatLabel"
        Me.StatLabel.Size = New System.Drawing.Size(260, 24)
        Me.StatLabel.TabIndex = 4
        Me.StatLabel.Text = "Not Connected."
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(3, 184)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(20, 20)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'PS5FTPFORM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(289, 209)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.StatLabel)
        Me.Controls.Add(Me.BtnUpload)
        Me.Controls.Add(Me.BtnDownload)
        Me.Controls.Add(Me.DirCombo)
        Me.Controls.Add(Me.ComboMountedPath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "PS5FTPFORM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PS5FTPFORM"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboMountedPath As ComboBox
    Friend WithEvents DirCombo As ComboBox
    Friend WithEvents BtnDownload As Button
    Friend WithEvents BtnUpload As Button
    Friend WithEvents StatLabel As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
