Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class LateralEntryB
    Public Function InsertRecord(ByVal l As LateralEntry) As Integer
        Return LateralEntryDB.Insert(l)
    End Function
    Public Function UpdateRecord(ByVal l As LateralEntry) As Integer
        Return LateralEntryDB.Insert(l)
    End Function
    Public Function ChangeFlag(ByVal Id As Int32) As Integer
        Return LateralEntryDB.ChangeFlag(id)
    End Function
    Public Function GetLateralEntry(ByVal stdcode As String) As List(Of LateralEntry)
        Dim lateral As New List(Of LateralEntry)
        Dim ds As DataSet = LateralEntryDB.GetLateralDetails(stdcode)
        Dim row As DataRow
        For Each row In ds.Tables(0).Rows
            lateral.Add(New LateralEntry(row("ID"), row("STUDENT_CODE"), row("ADMISSION_YEAR"), row("FEE_PAID"), row("ATTENDED_EXAM")))
        Next
        Return lateral
    End Function
End Class

