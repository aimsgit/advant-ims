Imports Microsoft.VisualBasic


Public Class BLExamResources
    Public Function InsertRecord(ByVal EL As ELExamResources) As Integer
        Return DLExamResources.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As ELExamResources) As Integer
        Return DLExamResources.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As ELExamResources) As Integer
        Return DLExamResources.ChangeFlag(EL)
    End Function
    Public Function GetGridData(ByVal El As ELExamResources, ByVal Id As Integer) As DataTable
        Return DLExamResources.GetGridData(El, Id)
    End Function

    'Public Function GetDuplicateYear(ByVal EL As String, ByVal id As Integer) As DataTable
    '    Return acy.GetDuplicateAcademicYear(EL, id)
    'End Function

End Class
