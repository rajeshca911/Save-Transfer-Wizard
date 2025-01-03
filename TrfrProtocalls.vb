Imports System.IO
Imports FluentFTP
Imports FluentFTP.Exceptions

Module TrfrProtocalls
    Public desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    Public saveTransferImportPath As String = Path.Combine(desktopPath, "SaveTransfer\Import")
    Public saveTransferExportPath As String = Path.Combine(desktopPath, "SaveTransfer\Export")


    Public Sub DownloadRemoteFolder(remoteDir As String, localBasePath As String, PSip As String, PortNo As String)
        Using dftp As New FtpClient(PSip, "anonymous", "anonymous", PortNo)
            Try
                Mystatus(2, "Connecting using FTP...")
                dftp.Connect()
                Mystatus(2, "Connected!")


                remoteDir = remoteDir.TrimEnd("/"c) & "/"

                If Not dftp.DirectoryExists(remoteDir) Then
                    Throw New Exception($"Remote directory does not exist: {remoteDir}")
                End If

                ' List all files and directories
                Dim items As FtpListItem() = dftp.GetListing(remoteDir, FtpListOption.Recursive)
                Mystatus(2, $"Found {items.Length} items to download.")

                For Each item As FtpListItem In items

                    Console.WriteLine($"Processing item: {item.FullName}")

                    Dim relativePath As String = item.FullName.Substring(remoteDir.Length).TrimStart("/"c)


                    Console.WriteLine($"Relative Path: {relativePath}")

                    Dim localPath As String = Path.Combine(localBasePath, relativePath)

                    If item.Type = FtpObjectType.Directory Then
                        ' Create local directory if it doesn't exist
                        If Not Directory.Exists(localPath) Then
                            Directory.CreateDirectory(localPath)
                            Mystatus(2, $"Created directory: {localPath}")
                            Console.WriteLine($"Created directory: {localPath}")
                        End If
                    ElseIf item.Type = FtpObjectType.File Then
                        ' Ensure parent directory exists
                        Dim localDir As String = Path.GetDirectoryName(localPath)
                        If Not Directory.Exists(localDir) Then
                            Directory.CreateDirectory(localDir)
                        End If

                        ' Download file
                        Try
                            Mystatus(2, $"Downloading: {item.FullName} to {localPath}")
                            dftp.DownloadFile(localPath, item.FullName)
                        Catch ex As Exception
                            Mystatus(3, $"Error downloading {item.FullName}: {ex.Message}")
                        End Try
                    End If
                Next

                Mystatus(1, "Downloads complete.")
                MessageBox.Show($"Files downloaded to: {localBasePath}")
                Process.Start(localBasePath)
            Catch ex As Exception
                Mystatus(3, $"An error occurred: {ex.Message}")
            Finally

                If dftp.IsConnected Then
                    dftp.Disconnect()
                End If
            End Try
        End Using
    End Sub

    Sub DeleteFolder()
        Dim PSip As String = SaveTransferAndDecryptor.PSIPtxt.Text.Trim
        Dim PortNo As Integer = SaveTransferAndDecryptor.PSportTxt.Text.Trim
        Using dftp As New FtpClient(PSip, "anonymous", "anonymous")
            dftp.Port = PortNo
            Try
                dftp.Connect()

                Dim targetDirectory As String = "/mnt/pfs/"

                Dim items = dftp.GetListing(targetDirectory)

                For Each item In items
                    If item.Type = FtpObjectType.Directory Then
                        If Not item.Name.Equals("trophy", StringComparison.OrdinalIgnoreCase) Then

                            dftp.DeleteDirectory(item.FullName)
                            Console.WriteLine($"Deleted directory: {item.FullName}")
                        Else
                            Console.WriteLine($"Skipped directory: {item.FullName}")
                        End If
                    End If
                Next
            Catch ex As Exception
                Console.WriteLine($"Error: {ex.Message}")
            Finally
                dftp.Disconnect()
            End Try
        End Using
    End Sub

    Public Sub UploadDirectorytoPS(sourcePath As String, selectedfoldername As String, psip As String, portNo As String)
        If PS5FTPFORM.ComboMountedPath.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a remote path.")
            PS5FTPFORM.ComboMountedPath.DroppedDown = True
            Return
        End If

        Dim uploadPath As String = PS5FTPFORM.ComboMountedPath.SelectedItem.ToString().Trim()

        If Not Directory.Exists(sourcePath) Then
            MessageBox.Show("The selected source directory does not exist.")
            Return

        End If

        Mystatus(2, "Connecting to FTP server...")

        Try
            Dim pno As Integer = CInt(portNo)
            Using ftp As New FtpClient(psip, "anonymous", "anonymous", pno)
                ftp.Connect()

                If Not ftp.DirectoryExists(uploadPath & "/" & selectedfoldername) Then
                    ftp.CreateDirectory(uploadPath & "/" & selectedfoldername)
                    Console.WriteLine($"Created remote directory: {uploadPath & "/" & selectedfoldername}")
                    Mystatus(2, $"Created remote directory: {uploadPath & "/" & selectedfoldername}")
                End If

                Mystatus(2, "Uploading files...")
                Console.WriteLine($"IP {psip}")
                Console.WriteLine($"port {pno}")
                Console.WriteLine($"source {sourcePath}")
                Console.WriteLine($"upload {uploadPath & "/" & selectedfoldername}")

                ftp.UploadDirectory(sourcePath & "\", uploadPath & "\" & selectedfoldername, FtpFolderSyncMode.Update)
                'ftp.UploadDirectory(sourcePath & "\*", "\data" & "\" & selectedfoldername & "\", FtpFolderSyncMode.Update)

                Mystatus(3, "Upload completed successfully.")
                MessageBox.Show("Files uploaded successfully!")
            End Using
        Catch ex As FtpException
            MessageBox.Show($"FTP error: {ex.Message}", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show($"An error occurred: {ex.Message}", "Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module