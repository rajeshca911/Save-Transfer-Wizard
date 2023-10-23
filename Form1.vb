Imports System.IO
Imports System.Net
Imports System.Security.Authentication
Imports FluentFTP


Public Class Form1
    Public PSip As String = ""
    Public PortNo As Integer = 0
    Private constat As Boolean = False
    Private desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    Private saveTransferImportPath As String = Path.Combine(desktopPath, "SaveTransfer\Import")
    Private saveTransferExportPath As String = Path.Combine(desktopPath, "SaveTransfer\Export")

    Private Sub GetUsersBtn_Click(sender As Object, e As EventArgs) Handles GetUsersBtn.Click
        Try
            Dim ConnId As String = ""
            PSip = Me.PSIPtxt.Text.ToString.Trim
            PortNo = CInt(Me.PSportTxt.Text.ToString.Trim)

            ConnId = String.Format("ftp://{0}:{1}/", PSip, PortNo)

            Me.Statlbl.Text = "Connecting.."
            Me.Statlbl.ForeColor = Color.Maroon
            Using conn As New FtpClient(PSip, "anonymous", "anonymous", PortNo)
                'Configurate the FTP connection
                conn.Config.EncryptionMode = FtpEncryptionMode.None
                conn.Config.SslProtocols = SslProtocols.None
                conn.Config.DataConnectionEncryption = False

                'Connect
                conn.Connect()
                'get users
                Me.Statlbl.Text = "Connection Success & Getting Users"
                Me.Statlbl.ForeColor = Color.Green

                ' Get immediate subdirectories in /user/home/
                Dim directoryPath As String = "/user/home/"

                Dim subdirectories() As FtpListItem = conn.GetListing(directoryPath, FtpListOption.Modify)

                ' Iterate through the array of items and add directory names to the ComboBox
                UserCmbBox.Items.Clear()

                For Each item As FtpListItem In subdirectories
                    If item.Type = FtpObjectType.Directory Then
                        'Console.WriteLine("Directory!  " & item.FullName)
                        UserCmbBox.Items.Add(item.Name)
                    End If
                Next

                constat = True
                'Disconnect
                conn.Disconnect()
                BtnDownload.Enabled = True
                BtnUpload.Enabled = True


            End Using

            Me.Statlbl.Text = "Done !. Now Select Profile"
            Me.Statlbl.ForeColor = Color.Green

        Catch ex As Exception
            constat = False

            MessageBox.Show("Error Code: " & Err.Number & vbNewLine & ex.Message, "Can't Connect", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            With Me.Statlbl
                .ForeColor = Color.Red
                .Text = "Status: Not Connected"
            End With

        End Try

        BtnDownload.Enabled = constat
        BtnUpload.Enabled = constat

    End Sub

    Private Sub BtnDownload_Click(sender As Object, e As EventArgs) Handles BtnDownload.Click
        Try
            DownloadDirectory()
        Catch ex As Exception
            MessageBox.Show("Error Code: " & Err.Number & vbNewLine & ex.Message, "Can't Download", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        End Try
    End Sub
    Sub DownloadDirectory()
        Dim pssave As String = ""
        Dim UserProfilePath As String = ""

        If Me.CmbSave.SelectedItem IsNot Nothing Then
            pssave = Me.CmbSave.SelectedItem.ToString()
        Else
            ' Handle missing Save Folder selection
            Throw New Exception("Please Select Save Folder!")
        End If

        If Me.UserCmbBox.SelectedItem IsNot Nothing Then
            UserProfilePath = String.Format("\user\home\{0}\savedata\{1}", Me.UserCmbBox.SelectedItem.ToString, pssave)
        Else
            ' Handle missing Profile selection
            Throw New Exception("Please Select Profile!")
        End If


        ' Dim UserProfilePath As String = String.Format("\user\home\{0}\savedata\{1}", Me.UserCmbBox.SelectedItem.ToString, pssave)
        Using dftp = New FtpClient(PSip, "anonymous", "anonymous", PortNo)
            dftp.Connect()

            ' download a folder And all its files
            If Not Directory.Exists(saveTransferImportPath & "\" & pssave) Then
                ' Create the directory if it doesn't exist
                Directory.CreateDirectory(saveTransferImportPath & "\" & pssave)
            End If



            dftp.DownloadDirectory(saveTransferImportPath & "\" & pssave, UserProfilePath, FtpFolderSyncMode.Update)

            '' download a folder And all its files, And delete extra files on disk
            'dftp.DownloadDirectory(saveTransferImportPath, UserProfilePath, FtpFolderSyncMode.Mirror)
            dftp.Disconnect()
            MessageBox.Show("Save Downloaded to " & vbNewLine & saveTransferImportPath & "\" & pssave)
        End Using
    End Sub
    Sub UploadDirectory(sourcepath As String)
        'Dim pssave As String = Me.CmbSave.SelectedItem.ToString
        Dim UserProfilePath As String = String.Format("\user\home\{0}\savedata\", Me.UserCmbBox.SelectedItem.ToString)


        If Not Me.UserCmbBox.SelectedItem.ToString Is Nothing Then


            Using ftp = New FtpClient(PSip, "anonymous", "anonymous", PortNo)
                ftp.Connect()


                ' upload a folder and all its files
                'ftp.UploadDirectory(sourcepath, UserProfilePath, FtpFolderSyncMode.Update)
                ftp.UploadDirectory(sourcepath, UserProfilePath, FtpFolderSyncMode.Update, FtpRemoteExists.Overwrite)
                '' upload a folder and all its files, and delete extra files on the server
                'ftp.UploadDirectory("C:\website\assets\", "/public_html/assets", FtpFolderSyncMode.Mirror)

            End Using
            MessageBox.Show("Save Uploaded successfully !")
        Else
            MessageBox.Show("Select Profile and Try Again")
        End If

    End Sub

    Private Sub UserCmbBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles UserCmbBox.SelectedIndexChanged
        'Select User Profile
        If Not Me.UserCmbBox.SelectedItem.ToString = "Select User Profile" Or Nothing Then
            'MessageBox.Show(Me.UserCmbBox.SelectedItem.ToString)
            Try
                Using conn As New FtpClient(PSip, "anonymous", "anonymous", PortNo)
                    'Configurate the FTP connection
                    conn.Config.EncryptionMode = FtpEncryptionMode.None
                    conn.Config.SslProtocols = SslProtocols.None
                    conn.Config.DataConnectionEncryption = False

                    'Connect
                    conn.Connect()
                    'get users
                    Me.Statlbl.Text = "Getting.. Game savedata "
                    Me.Statlbl.ForeColor = Color.Green

                    ' Get immediate subdirectories in /user/home/
                    Dim directoryPath As String = "/user/home/" & Me.UserCmbBox.SelectedItem.ToString & "/savedata/"

                    Dim subdirectories() As FtpListItem = conn.GetListing(directoryPath, FtpListOption.Modify)

                    ' Iterate through the array of items and add directory names to the ComboBox
                    CmbSave.Items.Clear()

                    For Each item As FtpListItem In subdirectories
                        If item.Type = FtpObjectType.Directory Then
                            'Console.WriteLine("Directory!  " & item.FullName)
                            CmbSave.Items.Add(item.Name)
                        End If
                    Next

                    constat = True
                    'Disconnect
                    conn.Disconnect()
                    BtnDownload.Enabled = True
                    BtnUpload.Enabled = True

                    Me.Statlbl.Text = "Now Dowload Or Upload Saves "
                End Using
            Catch ex As Exception

                MessageBox.Show("Error Code: " & Err.Number & vbNewLine & ex.Message, "Can't Fetch Saves", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            End Try

        End If
    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
        Dim selectedDirectory As String = ""
        Try
            ' Create a new instance of FolderBrowserDialog
            Using folderBrowser As New FolderBrowserDialog()
                ' Set the initial directory for the folder browser (optional)
                'folderBrowser.SelectedPath = "C:\"

                ' Show the folder browser dialog to the user
                Dim result As DialogResult = folderBrowser.ShowDialog()

                ' Check if the user selected a folder
                If result = DialogResult.OK Then
                    ' Set the selected folder path in the TextBox
                    selectedDirectory = folderBrowser.SelectedPath
                    UploadDirectory(selectedDirectory)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error Code: " & Err.Number & vbNewLine & ex.Message, "Can't Upload", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Verlbl.Text = "Version:" & My.Application.Info.Version.ToString
    End Sub
End Class
