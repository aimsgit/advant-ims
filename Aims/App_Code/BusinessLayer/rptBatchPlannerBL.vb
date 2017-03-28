Imports Microsoft.VisualBasic

Public Class rptBatchPlannerBL
    Dim DAL As New rptBatchPlannerDB
    Public Function GetResultByStdCode(ByVal batch As Integer, ByVal sem As Integer) As System.Data.DataTable
        Return DAL.GetResultByStdCode(batch, sem)
    End Function
    Public Function GetSemester() As DataTable
        Return rptBatchPlannerDB.GetSemester()
    End Function
End Class
