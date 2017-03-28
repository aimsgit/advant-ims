Imports Microsoft.VisualBasic

Public Class PerformanceCycleBL
    Public Function InsertRecord(ByVal EL As PerformanceCycleEL) As Integer
        Return PerformanceAppraisalDL.Insert(EL)
    End Function
    Public Function GetDuplicateCurrentYear(ByVal id As Integer) As DataTable
        Return PerformanceAppraisalDL.GetDuplicateCurrentYear(id)
    End Function

    Public Function UpdateRecord(ByVal EL As PerformanceCycleEL) As Integer
        Return PerformanceAppraisalDL.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As PerformanceCycleEL) As Integer
        Return PerformanceAppraisalDL.ChangeFlag(EL)
    End Function
    'Public Function GetReportData() As DataTable
    '    Return PerformanceAppraisalDL.GetReportData()
    'End Function
    Public Function GetGridData(ByVal Id As Integer) As DataTable
        Return PerformanceAppraisalDL.GetGridData(Id)
    End Function
End Class
