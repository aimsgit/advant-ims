Imports Microsoft.VisualBasic

Public Class BLBatchSemester
    Dim DL As New DLBatchSemester
    Public Function GetGridData(ByVal batchId As Integer, ByVal sem As Integer, ByVal Assesment As Integer) As DataTable
        Return DLBatchSemester.GetGridData(batchId, sem, Assesment)
    End Function
    Public Function Subject(ByVal batchId As Integer, ByVal sem As Integer) As DataTable
        Return DLBatchSemester.Subject(batchId, sem)
    End Function
    Public Function UpdateMarks(ByVal El As ELBatchSemester) As Integer
        Return DLBatchSemester.UpdateMarks(El)
    End Function
    Public Function UpdateResult(ByVal El As ELBatchSemester) As Integer
        Return DLBatchSemester.UpdateResult(El)
    End Function
    Public Function GetGridData1(ByVal batchId As Integer, ByVal sem As Integer, ByVal Assesment As Integer, ByVal Subject As String) As DataTable
        Return DLBatchSemester.GetGridData1(batchId, sem, Assesment, Subject)
    End Function
    Public Function UpdateCredit(ByVal batchId As Integer, ByVal Subject As String) As DataTable
        Return DL.UpdateCredit(batchId, Subject)
    End Function
    Public Function DuplicateSemResult(ByVal EL As ELBatchSemester) As DataTable
        Return DL.DuplicateSemResult(EL)
    End Function
    Public Function SelectTotalMarks(ByVal batchId As Integer, ByVal sem As Integer, ByVal Stdid As Integer, ByVal Assesment As Integer) As DataTable
        Return DLBatchSemester.SelectTotalMarks(batchId, sem, Stdid, Assesment)
    End Function
    Public Function UpdateGrade(ByVal A As Double, ByVal Course As Integer) As DataTable
        Return DLBatchSemester.UpdateGrade(A, Course)
    End Function
End Class
