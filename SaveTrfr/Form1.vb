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
        constat = False
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
                conn.Config.ConnectTimeout = 5000

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
                SelectFirstItem(Me.UserCmbBox)

                My.Settings.IPadd = PSip
                My.Settings.PortNo = PortNo
                My.Settings.Save()

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

        ENDISBTN(constat)

    End Sub

    Private Sub BtnDownload_Click(sender As Object, e As EventArgs) Handles BtnDownload.Click
        Try
            Me.Statlbl.Text = "Downloading..!"
            DownloadDirectory()
        Catch ex As Exception
            MessageBox.Show("Error Code: " & Err.Number & vbNewLine & ex.Message, "Can't Download", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ENDISBTN(False)
        End Try
        ProgressBar1.Visible = False
        ProgressBar1.Value = 0
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

        Dim Slocation As String = SAVETYPE()
        If Not Slocation = "" Then


            ' Get immediate subdirectories in /user/home/
            Dim directoryPath As String = "/user/home/" & Me.UserCmbBox.SelectedItem.ToString & "/" & Slocation

            If Me.UserCmbBox.SelectedItem IsNot Nothing Then
                UserProfilePath = String.Format("\user\home\{0}\{2}\{1}", Me.UserCmbBox.SelectedItem.ToString, pssave, Slocation)
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

                ProgressBar1.Visible = True
                ProgressBar1.Value = 0
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Dim progress As Action(Of FtpProgress) =
                  Sub(ByVal p As FtpProgress)
                      If p.Progress = 1 Then
                          ' all done!
                      Else
                          ' percent done = (p.Progress * 100)
                          ProgressBar1.Value = Math.Min(100, Math.Max(0, CInt(p.Progress * 100)))
                      End If
                  End Sub

                dftp.DownloadDirectory(saveTransferImportPath & "\" & pssave, UserProfilePath, FtpFolderSyncMode.Update, FtpLocalExists.Overwrite, progress:=progress)

                '' download a folder And all its files, And delete extra files on disk
                'dftp.DownloadDirectory(saveTransferImportPath, UserProfilePath, FtpFolderSyncMode.Mirror)
                dftp.Disconnect()
                MessageBox.Show("Save Downloaded to " & vbNewLine & saveTransferImportPath & "\" & pssave)
            End Using
        End If
        Me.Statlbl.Text = "Idle.."


    End Sub
    Sub UploadDirectory(sourcepath As String, foldername As String)
        'Dim pssave As String = Me.CmbSave.SelectedItem.ToString
        '/user/home/12675175/savedata/
        Dim sdataloc As String = SAVETYPE()

        If sdataloc = "" Then

            ' Handle missing selected item
            Throw New Exception("Please Select  SAVETYPE!")
        End If


        Dim UserProfilePath As String = String.Format("\user\home\{0}\{2}\{1}", Me.UserCmbBox.SelectedItem.ToString, foldername, sdataloc)

        'MessageBox.Show(UserProfilePath)
        If Not Me.UserCmbBox.SelectedItem.ToString Is Nothing Then


            Using ftp = New FtpClient(PSip, "anonymous", "anonymous", PortNo)
                ftp.Connect()
                ProgressBar1.Visible = True
                ProgressBar1.Value = 0
                ProgressBar1.Style = ProgressBarStyle.Marquee
                Dim progress As Action(Of FtpProgress) =
                      Sub(ByVal p As FtpProgress)
                          If p.Progress = 1 Then
                              ' all done!
                          Else
                              ' percent done = (p.Progress * 100)
                              ProgressBar1.Value = Math.Min(100, Math.Max(0, CInt(p.Progress * 100)))
                          End If
                      End Sub

                ' upload a folder and all its files
                'ftp.UploadDirectory(sourcepath, UserProfilePath, FtpFolderSyncMode.Update)
                ftp.UploadDirectory(sourcepath, UserProfilePath, FtpFolderSyncMode.Update, FtpRemoteExists.Overwrite, progress:=progress)
                '' upload a folder and all its files, and delete extra files on the server
                'ftp.UploadDirectory("C:\website\assets\", "/public_html/assets", FtpFolderSyncMode.Mirror)

            End Using
            MessageBox.Show("Save Uploaded successfully !")
        Else
            MessageBox.Show("Select Profile and Try Again")
        End If

        Me.Statlbl.Text = "Idle.."
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
                    Me.CmbPs45.SelectedIndex = 0
                    Dim subdirectories() As FtpListItem = conn.GetListing(directoryPath, FtpListOption.Modify)

                    ' Iterate through the array of items and add directory names to the ComboBox
                    CmbSave.Items.Clear()
                    CmbSave.Text = "Select Save Folder"
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
                SelectFirstItem(Me.CmbSave)
            Catch ex As Exception

                MessageBox.Show("Error Code: " & Err.Number & vbNewLine & ex.Message, "Can't Fetch Saves", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)

            End Try

        End If

    End Sub

    Private Sub BtnUpload_Click(sender As Object, e As EventArgs) Handles BtnUpload.Click
        Dim selectedDirectory As String = ""
        Me.Statlbl.Text = "Uploading might require some time..."
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
                    Dim foldername As String = Path.GetFileName(selectedDirectory)

                    UploadDirectory(selectedDirectory, foldername)
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show("Error Code: " & Err.Number & vbNewLine & ex.Message, "Can't Upload", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            ENDISBTN(False)
        End Try
        ProgressBar1.Visible = False
        ProgressBar1.Value = 0
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ENDISBTN(False)
        Verlbl.Text = "Version : " & My.Application.Info.Version.ToString
        Try
            PSIPtxt.Text = My.Settings.IPadd.ToString
            PSportTxt.Text = My.Settings.PortNo.ToString
        Catch ex As Exception
            PSIPtxt.Text = "192.168.0.100"
            PSportTxt.Text = 1337
        End Try

    End Sub

    Sub DeleteDirectory(psipadd As String, portno As Integer, dpath As String)

        Using conn As New FtpClient(psipadd, "anonymous", "anonymous", portno)
            conn.Connect()

            ' Remove the directory And all files And subdirectories inside it
            conn.DeleteDirectory(dpath)
            MessageBox.Show("Deleted", "Its Done!")
        End Using
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Try
            Dim pssave As String = ""
            Dim UserProfilePath As String = ""

            If Me.CmbSave.SelectedItem IsNot Nothing Then
                pssave = Me.CmbSave.SelectedItem.ToString()
            Else
                ' Handle missing Save Folder selection
                Throw New Exception("Please Select Save Folder!")
            End If
            'SAVE TYPE
            Dim sdataloc As String = SAVETYPE()

            If sdataloc = "" Then

                Throw New Exception("Please Select Save Type!")
            End If

            'SAVE TYPE*** 
            If Me.UserCmbBox.SelectedItem IsNot Nothing Then
                UserProfilePath = String.Format("\user\home\{0}\{2}\{1}", Me.UserCmbBox.SelectedItem.ToString, pssave, sdataloc)
            Else
                ' Handle missing Profile selection
                Throw New Exception("Please Select Profile!")
            End If
            Dim resp As DialogResult = MessageBox.Show("Are You Sure  ?", "Delete ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If resp = vbYes Then
                DeleteDirectory(PSip, PortNo, UserProfilePath)
                CmbSave.Items.Clear()
                UserCmbBox.SelectedIndex = 0
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cant Delete")
            ENDISBTN(False)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Credits.ShowDialog()
        Me.Show()
    End Sub

    Private Sub CmbSave_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbSave.SelectedIndexChanged

    End Sub

    Private Sub CmbPs45_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CmbPs45.SelectedIndexChanged
        SelectUserProfile()
    End Sub
    Sub SelectUserProfile()
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
                    Dim Slocation As String = SAVETYPE()

                    ' Get immediate subdirectories in /user/home/
                    Dim directoryPath As String = "/user/home/" & Me.UserCmbBox.SelectedItem.ToString & "/" & Slocation

                    Dim subdirectories() As FtpListItem = conn.GetListing(directoryPath, FtpListOption.Modify)

                    ' Iterate through the array of items and add directory names to the ComboBox
                    CmbSave.Items.Clear()
                    CmbSave.Text = "Select Save Folder"
                    For Each item As FtpListItem In subdirectories
                        If item.Type = FtpObjectType.Directory Then
                            'Console.WriteLine("Directory!  " & item.FullName)
                            CmbSave.Items.Add(item.Name)
                        End If
                    Next

                    SelectFirstItem(Me.CmbSave)
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
    Sub SelectFirstItem(cmbox As ComboBox)
        On Error Resume Next
        If cmbox.Items.Count > 0 Then
            cmbox.SelectedIndex = 0
        End If
    End Sub
    Function SAVETYPE() As String
        Dim sdataloc As String = ""
        Try

            'If Me.CmbPs45.SelectedItem IsNot Nothing Then
            '    sdataloc = Me.CmbPs45.SelectedItem.ToString()
            'Else
            '    ' Handle missing selected item
            '    Throw New Exception("Please Select Save Type!" & vbNewLine & "PS4 = Savedata" & vbNewLine & "PS5 = Savedata_prospero")
            'End If
            Select Case Me.CmbPs45.SelectedItem.ToString
                Case "PS5"
                    sdataloc = "savedata_prospero"
                Case "PS4"
                    sdataloc = "savedata"
                Case Else
                    sdataloc = ""

            End Select



        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return sdataloc
    End Function

    Sub ENDISBTN(T As Boolean)
        On Error Resume Next
        CmbPs45.Enabled = T
        UserCmbBox.Enabled = T
        CmbSave.Enabled = T
        BtnDownload.Enabled = T
        BtnUpload.Enabled = T
        BtnDelete.Enabled = T
    End Sub
End Class
