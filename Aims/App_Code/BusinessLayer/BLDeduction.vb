Imports Microsoft.VisualBasic

Public Class BLDeduction
    Public Function InsertRecord(ByVal EL As ELDeduction) As Integer
        Return DLDeduction.Insert(EL)
    End Function
    'Public Function GetDuplicateCurrentYear(ByVal id As Integer) As DataTable
    '    Return DLDeduction.GetDuplicateCurrentYear(id)
    'End Function

    Public Function UpdateRecord(ByVal EL As ELDeduction) As Integer
        Return DLDeduction.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As ELDeduction) As Integer
        Return DLDeduction.ChangeFlag(EL)
    End Function
    'Public Function GetReportData() As DataTable
    '    Return PerformanceAppraisalDL.GetReportData()
    'End Function
    Public Function GetGridData(ByVal EL As ELDeduction) As DataTable
        Return DLDeduction.GetGridData(EL)
    End Function
 
End Class
