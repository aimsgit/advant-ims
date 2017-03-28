Imports Microsoft.VisualBasic

Public Class BLAssesmentResult
    Dim DL As New DLAssesmentResult
    Public Function GetGridData1(ByVal batchId As Integer, ByVal sem As Integer, ByVal Subject As Integer, ByVal Asses As String) As DataTable
        Return DLAssesmentResult.GetGridData1(batchId, sem, Subject, Asses)
    End Function
    Public Function CountAssessment(ByVal batchId As Integer, ByVal sem As Integer, ByVal Asses As String) As DataTable
        Return DLAssesmentResult.CountAssessment(batchId, sem, Asses)
    End Function
    Public Function GetAss(ByVal ID As String) As DataTable
        Return DLAssesmentResult.GetAss(ID)
    End Function
    Public Function GetGridData(ByVal batchId As Integer, ByVal sem As Integer, ByVal Subject As Integer, ByVal Asses As String) As DataTable
        Return DLAssesmentResult.GetGridData(batchId, sem, Subject, Asses)
    End Function

    Public Function BEstOF(ByVal p1 As Double, ByVal p2 As Double, ByVal p3 As Double, ByVal p4 As Double, ByVal p5 As Double, ByVal p6 As Double, ByVal p7 As Double, ByVal p8 As Double, ByVal p9 As Double, ByVal BestOfM As Integer) As DataTable
        Return DLAssesmentResult.BEstOF(p1, p2, p3, p4, p5, p6, p7, p8, p9, BestOfM)
    End Function
    
    Public Function Insert(ByVal El As ELAssesmentResult) As Integer
        Return DLAssesmentResult.Insert(El)
    End Function
    Public Function UpdateGrade(ByVal El As ELAssesmentResult) As DataTable
        Return DLAssesmentResult.UpdateGrade(El)
    End Function
    Public Function AcademicYear(ByVal El As ELAssesmentResult) As DataTable
        Return DLAssesmentResult.AcademicYear(El)
    End Function
    Public Function Duplicate(ByVal El As ELAssesmentResult) As DataTable
        Return DLAssesmentResult.Duplicate(El)
    End Function
    Public Function GetMarks(ByVal El As ELAssesmentResult) As DataTable
        Return DLAssesmentResult.GetMarks(El)
    End Function
End Class
