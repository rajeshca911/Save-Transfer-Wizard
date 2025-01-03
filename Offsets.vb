Imports System.Runtime.InteropServices

Namespace PS4Saves

    Public Class Offsets
        Public Shared ReadOnly Firmwares As String() = {"4.03", "4.50", "5.xx"}
        Public Shared Property SelectedFirmware As String = String.Empty ' updated by fwVersionComboBox

        Public Shared ReadOnly Property sceUserServiceGetInitialUser As ULong
            Get
                Select Case SelectedFirmware
                    Case "4.03", "4.50"
                        Return &H3290
                    Case "5.xx"
                        Return &H33B0
                    Case Else
                        Throw New Exception("Unsupported firmware (did you select an item from the dropdown?)")
                End Select
            End Get
        End Property

        Public Shared ReadOnly Property sceUserServiceGetLoginUserIdList As ULong
            Get
                Select Case SelectedFirmware
                    Case "4.03", "4.50"
                        Return &H2A50
                    Case "5.xx"
                        Return &H2B00
                    Case Else
                        Throw New Exception("Unsupported firmware (did you select an item from the dropdown?)")
                End Select
            End Get
        End Property

        Public Shared ReadOnly Property sceUserServiceGetUserName As ULong
            Get
                Select Case SelectedFirmware
                    Case "4.03", "4.50"
                        Return &H46E0
                    Case "5.xx"
                        Return &H4830
                    Case Else
                        Throw New Exception("Unsupported firmware (did you select an item from the dropdown?)")
                End Select
            End Get
        End Property

        Public Shared ReadOnly Property sceSaveDataMount2 As ULong
            Get
                Select Case SelectedFirmware
                    Case "4.03", "4.50"
                        Return &H31470
                    Case "5.xx"
                        Return &H321B0
                    Case Else
                        Throw New Exception("Unsupported firmware (did you select an item from the dropdown?)")
                End Select
            End Get
        End Property

        Public Shared ReadOnly Property sceSaveDataUmount As ULong
            Get
                Select Case SelectedFirmware
                    Case "4.03", "4.50"
                        Return &H31940
                    Case "5.xx"
                        Return &H32680
                    Case Else
                        Throw New Exception("Unsupported firmware (did you select an item from the dropdown?)")
                End Select
            End Get
        End Property

        Public Shared ReadOnly Property sceSaveDataDirNameSearch As ULong
            Get
                Select Case SelectedFirmware
                    Case "4.03", "4.50"
                        Return &H32720
                    Case "5.xx"
                        Return &H33460
                    Case Else
                        Throw New Exception("Unsupported firmware (did you select an item from the dropdown?)")
                End Select
            End Get
        End Property

        Public Shared ReadOnly Property sceSaveDataTransferringMount As ULong
            Get
                Select Case SelectedFirmware
                    Case "4.03", "4.50"
                        Return &H317F0
                    Case "5.xx"
                        Return &H32530
                    Case Else
                        Throw New Exception("Unsupported firmware (did you select an item from the dropdown?)")
                End Select
            End Get
        End Property

        Public Shared ReadOnly Property sceSaveDataInitialize3 As ULong
            Get
                Select Case SelectedFirmware
                    Case "4.03", "4.50"
                        Return &H30FE0
                    Case "5.xx"
                        Return &H31D20
                    Case Else
                        Throw New Exception("Unsupported firmware (did you select an item from the dropdown?)")
                End Select
            End Get
        End Property

    End Class

    <StructLayout(LayoutKind.Explicit, Size:=64)>
    Public Structure SceSaveDataMount2
        <FieldOffset(0)> Public userId As Integer
        <FieldOffset(8)> Public dirName As ULong
        <FieldOffset(16)> Public blocks As ULong
        <FieldOffset(24)> Public mountMode As UInteger
    End Structure

    <StructLayout(LayoutKind.Explicit, Size:=64)>
    Public Structure SceSaveDataMountResult
        <FieldOffset(0)> Public mountPoint As SceSaveDataMountPoint
        <FieldOffset(32)> Public requiredBlocks As ULong
        <FieldOffset(40)> Public mountStatus As UInteger

    End Structure

    <StructLayout(LayoutKind.Sequential, Size:=16)>
    Public Structure SceSaveDataMountPoint

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=16)>
        Public data As String

    End Structure

    <StructLayout(LayoutKind.Sequential, Size:=64)>
    Public Structure SceSaveDataTransferringMount
        Public userId As Integer
        Public titleId As ULong
        Public dirName As ULong
        Public fingerprint As ULong
    End Structure

    <StructLayout(LayoutKind.Sequential, Size:=16)>
    Public Structure SceSaveDataTitleId

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=10)>
        Public data As String

    End Structure

    <StructLayout(LayoutKind.Sequential, Size:=32)>
    Public Structure SceSaveDataDirName

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=32)>
        Public data As String

    End Structure

    <StructLayout(LayoutKind.Sequential, Size:=80)>
    Public Structure SceSaveDataFingerprint

        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=65)>
        Public data As Byte()

    End Structure

    <StructLayout(LayoutKind.Explicit, Size:=64)>
    Public Structure SceSaveDataDirNameSearchCond
        <FieldOffset(0)> Public userId As Integer
        <FieldOffset(8)> Public titleId As ULong
        <FieldOffset(16)> Public dirName As ULong
        <FieldOffset(24)> Public key As UInteger
        <FieldOffset(28)> Public order As UInteger
    End Structure

    <StructLayout(LayoutKind.Explicit, Size:=56)>
    Public Structure SceSaveDataDirNameSearchResult
        <FieldOffset(0)> Public hitNum As UInteger
        <FieldOffset(8)> Public dirNames As ULong
        <FieldOffset(16)> Public dirNamesNum As UInteger
        <FieldOffset(20)> Public setNum As UInteger
        <FieldOffset(24)> Public param As ULong
        <FieldOffset(32)> Public infos As ULong
    End Structure

    <StructLayout(LayoutKind.Explicit, Size:=1328)>
    Public Structure SceSaveDataParam

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
        <FieldOffset(0)> Public title As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=128)>
        <FieldOffset(128)> Public subTitle As String

        <MarshalAs(UnmanagedType.ByValTStr, SizeConst:=1024)>
        <FieldOffset(256)> Public detail As String

        <FieldOffset(1280)> Public userParam As UInteger
        <FieldOffset(1288)> Public mtime As Long
    End Structure

    <StructLayout(LayoutKind.Sequential, Size:=48)>
    Public Structure SceSaveDataSearchInfo
        Public blocks As ULong
        Public freeBlocks As ULong
    End Structure

End Namespace