Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class AttendenceEligibilityCriteriaBL
    Dim Dl As New AttendenceEligibilityCriteriaDL
    Public Function getGrid(ByVal El As AttendenceEligibilityCriteriaEL) As Data.DataTable
        Return Dl.getGrid(El)
    End Function
    Public Function UpdateRecord(ByVal El As AttendenceEligibilityCriteriaEL) As Integer
        Return Dl.UpdateRecord(El)
    End Function
    Public Function InsertStudent(ByVal EL As AttendenceEligibilityCriteriaEL) As Integer
        Return Dl.InsertStudent(EL)
    End Function
    Public Function UndoStudent(ByVal EL As AttendenceEligibilityCriteriaEL) As Integer
        Return Dl.UndoStudent(EL)
    End Function
    Public Function GetSubjectDetails(ByVal BatchId As Integer, ByVal SemId As Integer) As Data.DataTable
        Return Dl.GetSubjectDetails(BatchId, SemId)
    End Function
End Class
