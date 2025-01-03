Imports System.IO
Imports System.Runtime.InteropServices
Imports libdebug
Imports Microsoft.VisualBasic.ApplicationServices
Imports SaveTrfr.PS4Saves

Public Class SaveTransferAndDecryptor
    Public pid As Integer = 0
    Private ps5 As PS4DBG
    Private stub As ULong
    Private libSceUserServiceBase As ULong = &H0
    Private libSceSaveDataBase As ULong = &H0
    Private user As Integer = &H0
    Private mp As String = ""
    Private log As Boolean = False

    Private Sub SaveTransferAndDecryptor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MnSize()
        Dim psip As String = My.Settings.PSIP.ToString.Trim()
        Dim psport As String = My.Settings.PSPORT.ToString.Trim()
        If Not String.IsNullOrEmpty(psip) Then
            Me.PSIPtxt.Text = psip
        End If

        If Not String.IsNullOrEmpty(psport) Then
            Me.PSportTxt.Text = psport
        End If

        fwVersionComboBox.Items.AddRange(Offsets.Firmwares)
        ' fwVersionComboBox.SelectedItem = Offsets.SelectedFirmware
        AddHandler fwVersionComboBox.SelectedValueChanged, Sub(eventSender As Object, eventArgs As EventArgs)
                                                               Offsets.SelectedFirmware = fwVersionComboBox.SelectedItem.ToString()
                                                           End Sub
        Mystatus(1, "Idle..zzz")
    End Sub

    Private Sub GetUsersBtn_Click(sender As Object, e As EventArgs) Handles GetUsersBtn.Click
        'PS5FTPFORM.ShowDialog()
        'Exit Sub

        dropdownvisible(False)

        If fwVersionComboBox.SelectedItem Is Nothing Then

            Mystatus(3, "No firmware selected")
            MessageBox.Show("Select firmware first", "No Firmware Selected", MessageBoxButtons.OK, MessageBoxIcon.Information)
            setupButton.Visible = False
            fwVersionComboBox.DroppedDown = True
            Return

        End If
        Mystatus(2, "Connecting..")

        Try
            Dim ipAddress As String = PSIPtxt.Text.ToString.Trim()
            Dim ps5Console As New PS5Console(ipAddress)

            Dim firmwareVersion As String = ps5Console.GetCVversion()
            Console.WriteLine(firmwareVersion)
            My.Settings.PSIP = ipAddress
            My.Settings.Save()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub setupButton_Click(sender As Object, e As EventArgs) Handles setupButton.Click
        GETPUsers()
        FetchMntDir.Visible = True
    End Sub

    Private Sub processesComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles processesComboBox.SelectedIndexChanged
        pid = CType(processesComboBox.SelectedItem, Process).pid
        If processesComboBox.SelectedItem Is Nothing Then
            Mystatus(1, "Select Process")
            setupButton.Enabled = False
        Else
            Mystatus(1, $"Click Setup Button")
            setupButton.Enabled = True
        End If
    End Sub

    Private Function GetLoginList() As Integer()
        Try

            Mystatus(2, "Getting Login List..")
            Dim bufferAddr = ps5.AllocateMemory(pid, Len(New Integer) * 4)

            ps5.Call(pid, stub, libSceUserServiceBase + Offsets.sceUserServiceGetLoginUserIdList, bufferAddr)

            Dim id = ps5.ReadMemory(pid, bufferAddr, Len(New Integer) * 4)
            Dim size = id.Length \ Len(New Integer)
            Dim ints(size - 1) As Integer
            For index As Integer = 0 To size - 1
                ints(index) = BitConverter.ToInt32(id, index * Len(New Integer))
            Next

            ps5.FreeMemory(pid, bufferAddr, Len(New Integer))

            Return ints
        Catch ex As Exception
            MessageBox.Show($"Error:{vbCrLf}{vbTab}{ex.Message}", "Error at GetLogInList Function")
        End Try
    End Function

    Private Function GetUserName(userid As Integer) As String
        Mystatus(2, "Getting Users..")

        Dim bufferAddr = ps5.AllocateMemory(pid, 17)

        ps5.Call(pid, stub, libSceUserServiceBase + Offsets.sceUserServiceGetUserName, userid, bufferAddr, 17)

        Dim str = ps5.ReadMemory(Of String)(pid, bufferAddr)

        ps5.FreeMemory(pid, bufferAddr, 17)

        Return str
    End Function

    Private Function GetUser() As Integer
        If user <> 0 Then
            Return user
        Else
            Return InitialUser()
        End If
    End Function

    Private Function InitialUser() As Integer
        Dim bufferAddr As Integer = ps5.AllocateMemory(pid, Marshal.SizeOf(GetType(Integer)))

        ps5.Call(pid, stub, libSceUserServiceBase + Offsets.sceUserServiceGetInitialUser, bufferAddr)

        Dim id As Integer = ps5.ReadMemory(Of Integer)(pid, bufferAddr)

        ps5.FreeMemory(pid, bufferAddr, Marshal.SizeOf(GetType(Integer)))

        Return id
    End Function

    Private Sub userComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles userComboBox.SelectedIndexChanged
        user = CType(userComboBox.SelectedItem, User).id
        If userComboBox.SelectedItem Is Nothing Then

            dirsComboBox.Visible = False
        Else
            'searchButton.Visible = True
            dirsComboBox.Visible = True
            SearchDirectories()

        End If
    End Sub

    Private Sub searchButton_Click(sender As Object, e As EventArgs) Handles searchButton.Click

        SearchDirectories()
    End Sub

    Private Sub dirsComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dirsComboBox.SelectedIndexChanged
        If dirsComboBox.SelectedItem Is Nothing Then
            Line1.Visible = False
            Line2.Visible = False
            mountButton.Visible = False
            unmountButton.Visible = False
        Else
            mountButton.Visible = True
            unmountButton.Visible = True
            Line1.Visible = True
            Line2.Visible = True
        End If
    End Sub

    Private Function Find(searchCond As SceSaveDataDirNameSearchCond, searchResult As SceSaveDataDirNameSearchResult) As SearchEntry()
        Dim searchCondAddr = ps5.AllocateMemory(pid, Marshal.SizeOf(GetType(SceSaveDataDirNameSearchCond)))
        Dim searchResultAddr = ps5.AllocateMemory(pid, Marshal.SizeOf(GetType(SceSaveDataDirNameSearchResult)))
        Mystatus(2, "Finding..")
        ps5.WriteMemory(pid, searchCondAddr, searchCond)
        ps5.WriteMemory(pid, searchResultAddr, searchResult)

        Dim ret = ps5.Call(pid, stub, libSceSaveDataBase + Offsets.sceSaveDataDirNameSearch, searchCondAddr, searchResultAddr)

        If ret = 0 Then
            searchResult = ps5.ReadMemory(Of SceSaveDataDirNameSearchResult)(pid, searchResultAddr)

            Dim sEntries(searchResult.hitNum - 1) As SearchEntry

            For i As UInteger = 0 To searchResult.hitNum - 1
                Dim tmp As SceSaveDataParam = ps5.ReadMemory(Of SceSaveDataParam)(pid, searchResult.param + i * CType(Marshal.SizeOf(GetType(SceSaveDataParam)), ULong))
                sEntries(i) = New SearchEntry With {
                .dirName = ps5.ReadMemory(Of String)(pid, searchResult.dirNames + i * 32),
                .title = tmp.title,
                .subtitle = tmp.subTitle,
                .detail = tmp.detail,
                .time = (New DateTime(1970, 1, 1)).ToLocalTime().AddSeconds(tmp.mtime).ToString()
            }
            Next

            ps5.FreeMemory(pid, searchCondAddr, Marshal.SizeOf(GetType(SceSaveDataDirNameSearchCond)))
            ps5.FreeMemory(pid, searchResultAddr, Marshal.SizeOf(GetType(SceSaveDataDirNameSearchResult)))

            Return sEntries
        End If

        ps5.FreeMemory(pid, searchCondAddr, Marshal.SizeOf(GetType(SceSaveDataDirNameSearchCond)))
        ps5.FreeMemory(pid, searchResultAddr, Marshal.SizeOf(GetType(SceSaveDataDirNameSearchResult)))

        Return New SearchEntry() {}
    End Function

    Private Sub mountButton_Click(sender As Object, e As EventArgs) Handles mountButton.Click

        DeleteFolder()

        If dirsComboBox.Items.Count = 0 Then
            Return
        End If

        Dim dirNameAddr = ps5.AllocateMemory(pid, Marshal.SizeOf(GetType(SceSaveDataDirName)))
        Dim dirName As New SceSaveDataDirName With {
        .data = dirsComboBox.Text
    }

        Dim mountMode As Integer = &H8 Or &H2
        Mystatus(2, "Getting Users..")
        Dim mount As New SceSaveDataMount2 With {
        .userId = GetUser(),
        .dirName = dirNameAddr,
        .blocks = 32768,
        .mountMode = mountMode
    }

        Dim mountResult As New SceSaveDataMountResult()
        'log
        Console.WriteLine($"User ID: {mount.userId}")
        Console.WriteLine($"Directory Name Address: {mount.dirName}")
        Console.WriteLine($"Blocks: {mount.blocks}")
        Console.WriteLine($"Mount Mode: {mount.mountMode}")

        ps5.WriteMemory(pid, dirNameAddr, dirName)
        mp = Mount1(mount, mountResult)

        ps5.FreeMemory(pid, dirNameAddr, Marshal.SizeOf(GetType(SceSaveDataDirName)))

        If Not String.IsNullOrEmpty(mp) Then
            Console.WriteLine($"Mounted point: {mountResult.mountPoint.ToString}")
            Console.WriteLine($"Mounted block: {mountResult.requiredBlocks.ToString}")

            Mystatus(1, $"Save Mounted in {mp}")
            '382, 454
            STANDARDSIZE(382, 454)
            FetchMntDir.Visible = True
            Try

                Dim psip As String = Me.PSIPtxt.Text.ToString.Trim()
                Dim psport As String = Me.PSportTxt.ToString.Trim()
                Dim profilename As String = Me.userComboBox.SelectedItem.ToString.Trim()
                If String.IsNullOrEmpty(psip) Or String.IsNullOrEmpty(psport) Then
                    MessageBox.Show("Both IP and Ports are Mandatory", "FTP")
                    Exit Sub
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, "FTP")
                Mystatus(3, "Save Mounted but Ftp connection failed.")
            End Try
            Console.WriteLine($"Save Mounted in {mp}")
        Else
            Mystatus(3, "Mounting Failed")
        End If
    End Sub

    Private Sub GETPUsers()
        If pid = 0 Then
            Mystatus(3, "No Process Selected")
            Return
        End If

        Dim ipAddress As String = PSIPtxt.Text.ToString.Trim()
        ps5 = New PS4DBG(ipAddress)
        ps5.Connect()

        Dim pm = ps5.GetProcessMaps(pid)
        Dim tmp = pm.FindEntry("libSceSaveData.sprx")?.start
        If tmp Is Nothing Then
            MessageBox.Show("savedata lib not found", "Error")
            Return
        End If
        libSceSaveDataBase = CType(tmp, ULong)

        tmp = pm.FindEntry("libSceUserService.sprx")?.start
        If tmp Is Nothing Then
            MessageBox.Show("user service lib not found", "Error")
            Return
        End If
        libSceUserServiceBase = CType(tmp, ULong)

        ' Install RPC (dummy in ps5debug)
        stub = ps5.InstallRPC(pid)
        If Not ps5.IsConnected Then
            Mystatus(3, "Not Connected")
            Throw New Exception("Failed to connect to PS5.")
        End If
        STANDARDSIZE(382, 420)
        ' Get user IDs and populate user list
        Dim ids = GetLoginList()
        Dim users As New List(Of User)()
        For i As Integer = 0 To ids.Length - 1
            If ids(i) = -1 Then
                Continue For
            End If
            users.Add(New User With {.id = ids(i), .name = GetUserName(ids(i))})

        Next
        userComboBox.DataSource = users.ToArray()

        ' Call Save Data Initialize
        Dim ret = ps5.Call(pid, stub, libSceSaveDataBase + Offsets.sceSaveDataInitialize3)

    End Sub

    Private Function Mount1(mount As SceSaveDataMount2, mountResult As SceSaveDataMountResult) As String
        Try

            Mystatus(2, "Mounting.")
            Dim mountAddr = ps5.AllocateMemory(pid, Marshal.SizeOf(GetType(SceSaveDataMount2)))
            Dim mountResultAddr = ps5.AllocateMemory(pid, Marshal.SizeOf(GetType(SceSaveDataMountResult)))

            ps5.WriteMemory(pid, mountAddr, mount)
            ps5.WriteMemory(pid, mountResultAddr, mountResult)

            Dim ret As Integer = ps5.Call(pid, stub, libSceSaveDataBase + Offsets.sceSaveDataMount2, mountAddr, mountResultAddr)


            If ret = 0 Then
                mountResult = ps5.ReadMemory(Of SceSaveDataMountResult)(pid, mountResultAddr)

                ps5.FreeMemory(pid, mountAddr, Marshal.SizeOf(GetType(SceSaveDataMount2)))
                ps5.FreeMemory(pid, mountResultAddr, Marshal.SizeOf(GetType(SceSaveDataMountResult)))

                Return mountResult.mountPoint.data
            End If

            ps5.FreeMemory(pid, mountAddr, Marshal.SizeOf(GetType(SceSaveDataMount2)))
            ps5.FreeMemory(pid, mountResultAddr, Marshal.SizeOf(GetType(SceSaveDataMountResult)))

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error at Mount", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return ""
    End Function

    Private Sub unmountButton_Click(sender As Object, e As EventArgs) Handles unmountButton.Click
        If String.IsNullOrEmpty(mp) Then
            Mystatus(3, "No save mounted")
            Return
        End If

        Dim mountPoint As New SceSaveDataMountPoint With {
            .data = mp
        }

        Unmount(mountPoint)

        mp = Nothing
        Mystatus(1, "Save Unmounted")

    End Sub

    Private Sub Unmount(mountPoint As SceSaveDataMountPoint)
        Mystatus(2, "Unmounting..")

        Dim mountPointAddr = ps5.AllocateMemory(pid, Marshal.SizeOf(GetType(SceSaveDataMountPoint)))

        ps5.WriteMemory(pid, mountPointAddr, mountPoint)

        Dim ret As Integer = ps5.Call(pid, stub, libSceSaveDataBase + Offsets.sceSaveDataUmount, mountPointAddr)

        ps5.FreeMemory(pid, mountPointAddr, Marshal.SizeOf(GetType(SceSaveDataMountPoint)))

        mp = Nothing
    End Sub

    Private Sub fwVersionComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles fwVersionComboBox.SelectedIndexChanged
        If fwVersionComboBox.SelectedItem Is Nothing Then
            setupButton.Visible = False
            Mystatus(3, "No firmware selected")
        Else
            setupButton.Visible = True
            Mystatus(1, $"Selected firmwae : {fwVersionComboBox.SelectedItem.ToString}")
        End If
    End Sub

    Private Sub SearchDirectories()
        If pid = 0 Then
            Mystatus(3, "No Process Selected")
            Return
        End If

        Dim pm = ps5.GetProcessMaps(pid)

        Dim dirNameAddr = ps5.AllocateMemory(pid, Marshal.SizeOf(GetType(SceSaveDataDirName)) * 1024)
        Dim paramAddr = ps5.AllocateMemory(pid, Marshal.SizeOf(GetType(SceSaveDataParam)) * 1024)

        Dim searchCond As New SceSaveDataDirNameSearchCond With {
            .userId = GetUser()
        }

        Dim searchResult As New SceSaveDataDirNameSearchResult With {
            .dirNames = dirNameAddr,
            .dirNamesNum = 1024,
            .param = paramAddr
        }

        dirsComboBox.DataSource = Find(searchCond, searchResult)

        ps5.FreeMemory(pid, dirNameAddr, Marshal.SizeOf(GetType(SceSaveDataDirName)) * 1024)
        ps5.FreeMemory(pid, paramAddr, Marshal.SizeOf(GetType(SceSaveDataParam)) * 1024)

        If dirsComboBox.Items.Count > 0 Then
            Mystatus(1, $"Found {dirsComboBox.Items.Count} Save Directories :D")
        Else
            Mystatus(3, "Found 0 Save Directories :(")
        End If
    End Sub

    Private Sub FetchMntDir_Click(sender As Object, e As EventArgs) Handles FetchMntDir.Click
        Me.Hide()
        PS5FTPFORM.ShowDialog()
        Me.Show()
    End Sub

End Class

Public Class User
    Public id As Integer
    Public name As String

    Public Overrides Function ToString() As String
        Return name
    End Function

End Class

Public Class SearchEntry
    Public Property dirName As String
    Public Property title As String
    Public Property subtitle As String
    Public Property detail As String
    Public Property time As String

    Public Overrides Function ToString() As String
        Return dirName
    End Function

End Class