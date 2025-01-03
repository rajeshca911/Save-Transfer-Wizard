<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartupForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StartupForm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SimpleFTPbutton = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Verlabel = New System.Windows.Forms.Label()
        Me.DecryptedButton = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(457, 69)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = resources.GetString("Label1.Text")
        '
        'SimpleFTPbutton
        '
        Me.SimpleFTPbutton.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.SimpleFTPbutton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleFTPbutton.Location = New System.Drawing.Point(81, 92)
        Me.SimpleFTPbutton.Name = "SimpleFTPbutton"
        Me.SimpleFTPbutton.Size = New System.Drawing.Size(130, 58)
        Me.SimpleFTPbutton.TabIndex = 1
        Me.SimpleFTPbutton.Text = "Encrypted Saves"
        Me.SimpleFTPbutton.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(457, 45)
        Me.Panel1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(134, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 25)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Save Transfer Menu"
        '
        'Verlabel
        '
        Me.Verlabel.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Verlabel.Location = New System.Drawing.Point(0, 164)
        Me.Verlabel.Name = "Verlabel"
        Me.Verlabel.Size = New System.Drawing.Size(457, 23)
        Me.Verlabel.TabIndex = 3
        Me.Verlabel.Text = "Label3"
        Me.Verlabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DecryptedButton
        '
        Me.DecryptedButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(198, Byte), Integer))
        Me.DecryptedButton.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DecryptedButton.Location = New System.Drawing.Point(246, 92)
        Me.DecryptedButton.Name = "DecryptedButton"
        Me.DecryptedButton.Size = New System.Drawing.Size(130, 58)
        Me.DecryptedButton.TabIndex = 4
        Me.DecryptedButton.Text = "Decrypted Saves"
        Me.DecryptedButton.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(123, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(-10, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(476, 29)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Select Save File Type"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'StartupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(457, 261)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.DecryptedButton)
        Me.Controls.Add(Me.Verlabel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.SimpleFTPbutton)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "StartupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Menu"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents SimpleFTPbutton As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Verlabel As Label
    Friend WithEvents DecryptedButton As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents ToolTip1 As ToolTip
End Class
