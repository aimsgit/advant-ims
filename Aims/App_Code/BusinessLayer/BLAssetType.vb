Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System
Public Class BLAssetType
    Dim el As New ELAssetType

    Public Function GetAssetType(ByVal el As ELAssetType) As Data.DataTable
        Return DLAssetType.GetAssetType(el)
    End Function
    Public Function InsertRecord(ByVal el As ELAssetType) As Integer
        Return DLAssetType.Insert(el)
    End Function
    Public Function UpdateRecord(ByVal el As ELAssetType) As Integer
        Return DLAssetType.Update(el)
    End Function
    Public Function ChangeFlag(ByVal id As Integer) As Integer
        Return DLAssetType.ChangeFlag(id)
    End Function
    Public Function CheckDuplicate(ByVal el As ELAssetType) As Data.DataTable
        Return DLAssetType.CheckDuplicate(el)
    End Function
End Class
