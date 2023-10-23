Public Class Credits
    Private Sub Credits_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        RichTextBox1.Text = "Scene Devs:" & vbNewLine &
"@theflow0, @SpecterDev, ChendoChap, @Znullptr, @sleirsgoevy," & vbNewLine &
"@psxdev, @flat_z, @notzecoxao, @SocraticBliss, laureeeeeee" & vbNewLine & vbNewLine &
"Ftp  : robinrodricks [dotnet]" & vbNewLine & vbNewLine &
"If I forgot to mention any developer names, please send me a message on Discord at Rajesh#7267. I'll provide credits to those developers."

        RichTextBox1.Select(0, 10)
        RichTextBox1.SelectionFont = New Font("Segoe UI", 11, FontStyle.Bold Or FontStyle.Underline)


    End Sub
End Class