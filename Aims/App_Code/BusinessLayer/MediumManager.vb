Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class MediumManager
    Dim MDB As New MediumDB
    Public Shared Function GetMediumById(ByVal id As Long) As List(Of Medium)
        Dim mediumname As New List(Of Medium)
        Dim ds As DataSet = MediumDB.GetMedium(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            mediumname.Add(New Medium(row("Medium_ID"), row("MediumName")))
        Next
        Return mediumname
    End Function
    Public Function GetMediumByMediumId(ByVal id As Long) As Medium
        Dim medium As Medium
        Dim ds As DataSet = MediumDB.GetMedium(id)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        medium = New Medium(row("Medium_ID"), row("MediumName"))
        Return medium
    End Function

    Public Function GetMedium() As List(Of Medium)
        Dim mediumname As New List(Of Medium)
        Dim ds As DataSet = MediumDB.GetMedium(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            mediumname.Add(New Medium(row("Medium_ID"), row("MediumName")))
        Next
        Return mediumname
    End Function
    Public Function GetMediumRpt(ByVal md As Medium) As DataTable
        Dim ds As DataSet = MediumDB.GetMediumRpt(md)
        Return ds.Tables(0)
    End Function
    Public Function InsertRecord(ByVal md As String) As Integer
        Return MediumDB.Insert(md)
    End Function
    Public Function UpdateRecord(ByVal md As Medium) As Integer
        'If md.Name = Nothing Then
        '    md.Name = ""
        'End If
        Return MediumDB.Update(md)
    End Function
    Public Function ChangeFlag(ByVal md As Medium) As Integer
        Return MediumDB.ChangeFlag(md)
    End Function
    'Public Function GetMedium() As List(Of Medium)
    '    Dim medium As New List(Of Medium)
    '    Dim ds As DataSet = MediumDB.GetMedium(0)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        medium.Add(New Medium(row("Medium_ID"), row("MediumName")))
    '    Next
    '    Return medium
    'End Function
    'Public Function GetMediumByMediumId(ByVal id As Long) As Medium
    '    Dim medium As Medium
    '    Dim ds As DataSet = MediumDB.GetMedium(id)
    '    Dim row As DataRow = ds.Tables(0).Rows(0)
    '    medium = New Medium(row("Medium_ID"), row("MediumName"))
    '    Return medium
    'End Function
    Public Function GetDuplicateMediumType(ByVal md As Medium) As DataTable
        Return MDB.GetDuplicateMediumType(md)
    End Function
End Class
