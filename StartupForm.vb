Public Class StartupForm

    Private Sub StartupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximumSize = New Size(Me.Size)
        Me.MinimumSize = New Size(Me.Size)
        Verlabel.Text = "Version: " & My.Application.Info.Version.ToString()
        ToolTip1.SetToolTip(SimpleFTPbutton, $"Click here to simly transfer save files from Playstation to PC{vbCrLf}from user profiles")
        ToolTip1.SetToolTip(DecryptedButton, "Click here to transfer decrypted and mounted saves using the Idlesauce method." & vbCrLf & "Ensure that debugging is enabled in the console.")
    End Sub

    Private Sub SimpleFTPbutton_Click(sender As Object, e As EventArgs) Handles SimpleFTPbutton.Click
        Me.Hide()
        Form1.ShowDialog()
        Me.Show()
    End Sub

    Private Sub DecryptedButton_Click(sender As Object, e As EventArgs) Handles DecryptedButton.Click
        Me.Hide()
        SaveTransferAndDecryptor.ShowDialog()
        Me.Show()
    End Sub

End Class