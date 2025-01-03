Imports System.Net

Public Class FileDownloader
    Public Sub DownloadFile(url As String, destinationPath As String)
        Try

            Using client As New WebClient()

                client.DownloadFile(url, destinationPath)
                MessageBox.Show("Download completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Using
        Catch ex As Exception

            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class


