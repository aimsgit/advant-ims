Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Public Class DiaryEntryManager
    Public Function GetDiaryEntry(ByVal id As Long) As List(Of DiaryEntry)
        Dim DE As New List(Of DiaryEntry)
        Dim ds As DataSet = DiaryEntryDB.GVDetails(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            DE.Add(New DiaryEntry(row("DiaryEntryId"), row("EntryText"), row("EntryTitle")))
        Next
        Return DE
    End Function
    Public Function GetContactByID(ByVal DEID As Long) As DiaryEntry
        Dim de As DiaryEntry
        Dim ds As DataSet = DiaryEntryDB.GVDetails(DEID)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        de = New DiaryEntry(row("DiaryEntryId"), row("EntryText"), row("EntryTitle"))
        Return de
    End Function
    Public Function InsertRecord(ByVal de As DiaryEntry) As Integer
        Return DiaryEntryDB.Insert(de)
    End Function
    Public Function UpdateRecord(ByVal de As DiaryEntry) As Integer
        Return DiaryEntryDB.Insert(de)
    End Function
    Public Function DeleteRecord(ByVal de As DiaryEntry) As Integer
        Return DiaryEntryDB.Delete(de.DiaryEntryId)
    End Function
End Class
