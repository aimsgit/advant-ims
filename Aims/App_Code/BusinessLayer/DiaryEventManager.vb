Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Public Class DiaryEventManager
    Public Function GetDiaryEvent(ByVal id As Long) As List(Of DiaryEvent)
        Dim DE As New List(Of DiaryEvent)
        Dim ds As DataSet = DiaryEventDB.GVDetails(id)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            DE.Add(New DiaryEvent(row("DiaryId"), row("EventName"), row("EventDescription"), row("EventDate"), row("EventDuration")))
        Next
        Return DE
    End Function
    Public Function GetDiaryEvent() As List(Of DiaryEvent)
        Dim DE As New List(Of DiaryEvent)
        Dim ds As DataSet = DiaryEventDB.GVDetails(0)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            DE.Add(New DiaryEvent(row("DiaryId"), row("EventName"), row("EventDescription"), row("EventDate"), row("EventDuration")))
        Next
        Return DE
    End Function
    Public Function GetContactByID(ByVal DEID As Long) As DiaryEvent
        Dim de As DiaryEvent
        Dim ds As DataSet = DiaryEventDB.GVDetails(DEID)
        Dim row As DataRow = ds.Tables(0).Rows(0)
        de = New DiaryEvent(row("DiaryId"), row("EventName"), row("EventDescription"), row("EventDate"), row("EventDuration"))
        Return de
    End Function
    Public Function InsertRecord(ByVal de As DiaryEvent) As Integer
        Return DiaryEventDB.Insert(de)
    End Function
    Public Function UpdateRecord(ByVal de As DiaryEvent) As Integer
        Return DiaryEventDB.Insert(de)
    End Function
    Public Function DeleteRecord(ByVal de As DiaryEvent) As Integer
        Return DiaryEventDB.Delete(de.DiaryId)
    End Function
End Class
