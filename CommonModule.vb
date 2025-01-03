Imports System.IO

Module CommonModule
    Public GTitleId As String = ""

    Public Sub FixSize()
        With SaveTransferAndDecryptor
            .MaximumSize = New Size(.Size)
            .MinimumSize = New Size(.Size)

        End With
    End Sub

    Public Sub MnSize()
        With SaveTransferAndDecryptor
            .MaximumSize = New Size(382, 197)
            .MinimumSize = New Size(382, 197)
            '.StartPosition = FormStartPosition.CenterScreen

        End With
    End Sub

    Public Sub STANDARDSIZE(X As Integer, Y As Integer)
        With SaveTransferAndDecryptor

            .MinimumSize = New Size(X, Y)
            .MaximumSize = New Size(X, Y)
            .Size = New Size(X, Y)

        End With

    End Sub

    Public Sub MxSize()
        With SaveTransferAndDecryptor
            .MaximumSize = New Size(699, 399)
            .MinimumSize = New Size(699, 399)
            ' .StartPosition = FormStartPosition.WindowsDefaultLocation

        End With
    End Sub

    Public Sub Mystatus(Optional ByVal St As Integer = 1, Optional ByVal Txt As String = "Idle..")
        With SaveTransferAndDecryptor
            Select Case St
                Case 1
                    .PictureBox1.Image = My.Resources.GREEN
                    .StatLabel.Text = Txt
                Case 2
                    .PictureBox1.Image = My.Resources.blue
                    .StatLabel.Text = Txt
                Case 3
                    .PictureBox1.Image = My.Resources.RED
                    .StatLabel.Text = Txt
                Case Else
                    .PictureBox1.Image = My.Resources.GREEN
                    .StatLabel.Text = "Idle.."
            End Select
            .Refresh()
        End With
        With PS5FTPFORM
            Select Case St
                Case 1
                    .PictureBox1.Image = My.Resources.GREEN
                    .StatLabel.Text = Txt
                Case 2
                    .PictureBox1.Image = My.Resources.blue
                    .StatLabel.Text = Txt
                Case 3
                    .PictureBox1.Image = My.Resources.RED
                    .StatLabel.Text = Txt
                Case Else
                    .PictureBox1.Image = My.Resources.GREEN
                    .StatLabel.Text = "Idle.."
            End Select
            .Refresh()
        End With
    End Sub

    Public Sub dropdownvisible(v As Boolean)
        With SaveTransferAndDecryptor
            .dirsComboBox.Visible = v
            .processesComboBox.Visible = v
            .searchButton.Visible = v
            .mountButton.Visible = v
            .unmountButton.Visible = v
            .Line1.Visible = v
            .Line2.Visible = v
            .FetchMntDir.Visible = v

        End With
        MnSize()
    End Sub

    Public Sub PopulateComboMountedPath(comboBox As ComboBox, filePath As String)

        If Not File.Exists(filePath) Then

            Using writer As StreamWriter = New StreamWriter(filePath)
                writer.WriteLine("mnt/pfs")
                writer.WriteLine("mnt/sandbox")
            End Using
        End If

        comboBox.Items.Clear()

        Using reader As StreamReader = New StreamReader(filePath)
            While Not reader.EndOfStream
                Dim line As String = reader.ReadLine()
                If Not String.IsNullOrWhiteSpace(line) Then
                    comboBox.Items.Add(line.Trim())
                End If
            End While
        End Using

        If comboBox.Items.Count > 0 Then
            comboBox.SelectedIndex = 0
        End If
    End Sub

End Module