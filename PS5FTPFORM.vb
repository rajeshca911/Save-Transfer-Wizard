Imports System.IO
Imports System.Security.Authentication
Imports FluentFTP

Public Class PS5FTPFORM
    Private PSip = SaveTransferAndDecryptor.PSIPtxt.Text.Trim()
    Private PortNo = SaveTransferAndDecryptor.PSportTxt.Text.Trim()

    Private Sub DirCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles DirCombo.SelectedIndexChanged

    End Sub

    Private Sub ComboMountedPath_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboMountedPath.SelectedIndexChanged
        If ComboMountedPath.SelectedItem Is Nothing Then
            Mystatus(3, "Select Mount Folder")
            Exit Sub
        End If
        DirCombo.Items.Clear()
        Mystatus(2, "Fetching Foldes..Pls Wait !!")
        Try

            Using conn As New FtpClient(PSip, "anonymous", "anonymous", PortNo)

                conn.Config.EncryptionMode = FtpEncryptionMode.None
                conn.Config.SslProtocols = SslProtocols.None
                conn.Config.DataConnectionEncryption = False

                conn.Connect()
                Mystatus(2, "Listing folders")

                Dim directoryPath As String = ComboMountedPath.SelectedItem.ToString

                Dim subdirectories() As FtpListItem = conn.GetListing(directoryPath, FtpListOption.Modify)

                DirCombo.Items.Clear()

                For Each item As FtpListItem In subdirectories
                    If item.Type = FtpObjectType.Directory Then
                        'Console.WriteLine("Directory!  " & item.FullName)
                        DirCombo.Items.Add(item.Name)

                    End If
                Next

                conn.Disconnect()
                Mystatus(1)
            End Using
        Catch ex As Exception

            MessageBox.Show("Error Code: " & Err.Number & vbNewLine & ex.Message, "Can't Fetch Mounted Directories", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        End Try
    End Sub

    Private Sub PS5FTPFORM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim filePath As String = "ComboMountedPaths.txt"
        PopulateComboMountedPath(ComboMountedPath, filePath)

        ComboMountedPath.SelectedIndex = 0
    End Sub

    Private Sub PS5FTPFORM_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub

    Private Sub BtnDownload_Click(sender As Object, e As EventArgs) Handles BtnDownload.Click

        Try
            If ComboMountedPath.SelectedItem Is Nothing Or DirCombo.SelectedItem Is Nothing Then
                MessageBox.Show("Select Path & Directory")
                Return
            End If

            Dim fpath As String = ComboMountedPath.SelectedItem.ToString.TrimEnd("/"c)
            Dim dirname As String = DirCombo.SelectedItem.ToString.Trim()

            If String.IsNullOrEmpty(dirname) OrElse dirname.Contains("/") OrElse dirname.Contains("\") Then
                MessageBox.Show("Invalid directory name.")
                Return
            End If

            If String.IsNullOrEmpty(dirname) Then
                MessageBox.Show("Directory name cannot be empty.")
                Return
            End If

            Dim remotePath As String = Path.Combine(fpath, dirname).Replace("\", "/")
            Dim localpath As String = Path.Combine(saveTransferImportPath, "sandbox0")

            If Not Directory.Exists(localpath) Then
                Directory.CreateDirectory(localpath)
            End If

            localpath = Path.Combine(localpath, dirname)

            Console.WriteLine($"Remote Path: {remotePath}")
            Console.WriteLine($"Local Path: {localpath}")

            Dim Psip As String = SaveTransferAndDecryptor.PSIPtxt.Text.Trim()
            Dim psport As String = SaveTransferAndDecryptor.PSportTxt.Text.Trim()

            DownloadRemoteFolder(remotePath, localpath, Psip, psport)
            My.Settings.PSIP = Psip
            My.Settings.PSPORT = psport
            My.Settings.Save()
        Catch ex As Exception
            MessageBox.Show($"Error while downloading:{vbCrLf}{vbTab}{ex.Message}")
        End Try

    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click

        Try
            Using folderBrowser As New FolderBrowserDialog()
                Dim result As DialogResult = folderBrowser.ShowDialog()

                If result = DialogResult.OK Then
                    Dim selectedDirectory As String = folderBrowser.SelectedPath
                    Dim selectedFolderName As String = Path.GetFileName(selectedDirectory.TrimEnd(Path.DirectorySeparatorChar))

                    Console.WriteLine($"Selected folder: {selectedFolderName}")
                    UploadDirectorytoPS(selectedDirectory, selectedFolderName, PSip, PortNo)
                    My.Settings.PSIP = PSip
                    My.Settings.PSPORT = PortNo
                    My.Settings.Save()
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error while uploading: {ex.Message}", "Can't Upload", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class