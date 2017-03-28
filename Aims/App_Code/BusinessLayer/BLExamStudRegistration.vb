Imports Microsoft.VisualBasic

Public Class BLExamStudRegistration
    Public Function InsertRecord(ByVal EL As ELExamStudRegistration) As Integer
        Return DLExamStudRegistration.Insert(EL)
    End Function

    Public Function UpdateRecord(ByVal EL As ELExamStudRegistration) As Integer
        Return DLExamStudRegistration.Update(EL)
    End Function
    Public Function ChangeFlag(ByVal EL As ELExamStudRegistration) As Integer
        Return DLExamStudRegistration.ChangeFlag(EL)
    End Function
    Public Function GetGridData(ByVal El As ELExamStudRegistration, ByVal Id As Integer) As DataTable
        Return DLExamStudRegistration.GetGridData(El, Id)
    End Function

    'Public Function GetDuplicateYear(ByVal EL As String, ByVal id As Integer) As DataTable
    '    Return acy.GetDuplicateAcademicYear(EL, id)
    'End Function

    Public Function ChangeRegFlag(ByVal EL As ELExamStudRegistration) As Integer
        Return DLExamStudRegistration.ChangeFlagReg(EL)
    End Function
End Class
