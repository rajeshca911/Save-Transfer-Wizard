Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports libdebug
Imports SaveTrfr.PS4Saves
Imports System.Reflection
Imports System.Text

Public Class PS5Console

    Private ps5 As PS4DBG

    Public Sub New(ipAddress As String)

        ps5 = New PS4DBG(ipAddress)
    End Sub

    Public Function GetCVversion() As String
        Try
            ps5.Connect()

            If Not ps5.IsConnected Then
                Mystatus(3, "Not Connected")
                Throw New Exception("Failed to connect to PS5.")
            End If
            'MxSize()
            Mystatus(1, "Playstation Connected")
            Dim dbugversion As String = ps5.GetConsoleDebugVersion()
            Dim libversion As String = ps5.GetLibraryDebugVersion()
            Mystatus(1, $"Debug Version: {dbugversion}, Library Version: {libversion}")
            'Return $"Debug Version: {dbugversion}, Library Version: {libversion}"
            STANDARDSIZE(382, 350)
            With SaveTransferAndDecryptor
                .processesComboBox.DataSource = Filter(ps5.GetProcessList())

                .processesComboBox.Location = New Point(174, 145)
                .processesComboBox.Visible = True

                .userComboBox.Location = New Point(174, 176)
                .userComboBox.Visible = True

            End With

            Mystatus(1, $"Select Process")
        Catch ex As Exception
            Mystatus(3, "Connection Failed.!")
            MnSize()

            MessageBox.Show(ex.Message, "Error While Connecting to PlayStation", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return $"Error: {ex.Message}"
        Finally

            If ps5 IsNot Nothing AndAlso ps5.IsConnected Then
                ps5.Disconnect()

            End If
        End Try
        Mystatus(1)
    End Function

    Private Function Filter(list As ProcessList) As Process()
        Dim procs As New List(Of Process)()

        For i As Integer = 0 To list.processes.Length - 1
            Dim processE As Process = list.processes(i)
            If list.processes(i).name = "eboot.bin" OrElse list.processes(i).name.EndsWith(".elf") Then
                procs.Add(list.processes(i))

                'If list.processes(i).name = "eboot.bin" Then

                '    'tried something
                '    Try
                '        Dim gameID As String = Nothing
                '        Dim gameVer As String = Nothing

                '        Dim pMap As ProcessMap = ps5.GetProcessMaps(list.processes(i).pid.ToString)
                '        For eIdx As Integer = 0 To pMap.entries.Length - 1
                '            Dim entry As MemoryEntry = pMap.entries(eIdx)
                '            If (entry.prot And &H1) <> &H1 Then Continue For
                '            If (entry.name <> "libSceCdlgUtilServer.sprx" AndAlso entry.name <> "libSceCdlgUtilServer.sprx" & "[0]") OrElse entry.prot <> 3 Then Continue For

                '            gameID = ps5.ReadMemory(pMap.pid, entry.start + Offsets.SelectedFirmware, 16)
                '            gameID = gameID.Trim(Chr(0)) ' Trim null characters

                '            gameVer = ps5.ReadMemory(pMap.pid, entry.start + &HC8, 16)
                '            gameVer = gameVer.Trim(Chr(0)) ' Trim null characters
                '        Next

                '        Console.WriteLine(gameID, gameVer)
                '    Catch ex As Exception

                '        Console.WriteLine(ex.Message)
                '    End Try
                'End If

            End If
        Next

        Return procs.ToArray()
    End Function

End Class