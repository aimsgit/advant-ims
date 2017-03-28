Imports Microsoft.VisualBasic

Public Class BLDocUpload
    Public Function InsertRecord(ByVal EL As ELDocUpload) As Integer
        Return DLDocUpload.Insert(EL)
    End Function
    'Public Function GetDuplicateCurrentYear(ByVal id As Integer) As DataTable
    '    Return DLDocUpload.GetDuplicateCurrentYear(id)
    'End Function

    Public Function UpdateRecord(ByVal EL As ELDocUpload) As Integer
        Return DLDocUpload.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As ELDocUpload) As Integer
        Return DLDocUpload.ChangeFlag(EL)
    End Function
    'Public Function GetReportData() As DataTable
    '    Return PerformanceAppraisalDL.GetReportData()
    'End Function
    Public Function GetGridData(ByVal EL As ELDocUpload) As DataTable
        Return DLDocUpload.GetGridData(EL)
    End Function
    Public Function DeleteDoc(ByVal EL As ELDocUpload) As Integer
        Return DLDocUpload.DeleteDoc(EL)
    End Function
End Class
