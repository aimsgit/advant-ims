Imports Microsoft.VisualBasic

Public Class BLCreateExamBatch
    Public Function InsertRecord(ByVal EL As ELCreateExamBatch) As Integer
        Return DLCreateExamBatch.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As ELCreateExamBatch) As Integer
        Return DLCreateExamBatch.Update(EL)
    End Function
    'Public Function ChangeFlag(ByVal EL As AcademicYear) As Integer
    '    Return AcademicYearDB.ChangeFlag(EL)
    'End Function
    Public Function GetGridData(ByVal Id As Integer, ByVal prefix As String) As DataTable
        Return DLCreateExamBatch.GetGridData(Id, prefix)
    End Function

    'Public Function GetDuplicateYear(ByVal EL As String, ByVal id As Integer) As DataTable
    '    Return acy.GetDuplicateAcademicYear(EL, id)
    'End Function
    Public Function ChangeFlagBatch(ByVal EN As Integer) As Integer
        Return DLCreateExamBatch.ChangeFlagBatch(EN)
    End Function

End Class
