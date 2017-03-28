Imports Microsoft.VisualBasic

Public Class BLGradePointResult
    Dim DL As New DLGradePointResult
    Public Function GetGridData(ByVal batchId As Integer, ByVal sem As Integer, ByVal Assesment As Integer) As DataTable
        Return DLGradePointResult.GetGridData(batchId, sem, Assesment)
    End Function
    Public Function Subject(ByVal batchId As Integer, ByVal sem As Integer) As DataTable
        Return DLGradePointResult.Subject(batchId, sem)
    End Function
    Public Function UpdateMarks(ByVal El As ELGradePointResult) As Integer
        Return DLGradePointResult.UpdateMarks(El)
    End Function
    Public Function UpdateResult(ByVal El As ELGradePointResult) As Integer
        Return DLGradePointResult.UpdateResult(El)
    End Function
    Public Function getsem(ByVal El As ELGradePointResult) As DataTable
        Return DLGradePointResult.getsem(El)
    End Function
    Public Function SearchCourse(ByVal Course As Integer) As DataTable
        Return DLGradePointResult.SearchCourse(Course)
    End Function
    Public Function GetGridData1(ByVal batchId As Integer, ByVal sem As Integer, ByVal Assesment As Integer, ByVal Subject As String) As DataTable
        Return DLGradePointResult.GetGridData1(batchId, sem, Assesment, Subject)
    End Function
    Public Function GetTotalCredit(ByVal batchId As Integer, ByVal sem As Integer, ByVal Subject As String) As DataTable
        Return DLGradePointResult.GetTotalCredit(batchId, sem, Subject)
    End Function
    Public Function DuplicateSemResult(ByVal EL As ELGradePointResult) As DataTable
        Return DL.DuplicateSemResult(EL)
    End Function
    Public Function SelectTotalMarks(ByVal batchId As Integer, ByVal sem As Integer, ByVal Stdid As Integer, ByVal Assesment As Integer) As DataTable
        Return DLGradePointResult.SelectTotalMarks(batchId, sem, Stdid, Assesment)
    End Function
    Public Function UpdateGrade(ByVal A As Double, ByVal course As Integer) As DataTable
        Return DLGradePointResult.UpdateGrade(A, course)
    End Function
    Public Function UpdateDivision(ByVal A As Double, ByVal course As Integer) As DataTable
        Return DLGradePointResult.UpdateDivision(A, course)
    End Function
End Class

