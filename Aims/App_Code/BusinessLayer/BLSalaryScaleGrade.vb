Imports Microsoft.VisualBasic

Public Class BLSalaryScaleGrade
    Dim DL As New DLSalaryScaleGrade
    Public Function InsertSalaryScale(ByVal EL As ELSalaryScaleGrade) As Integer
        Return DL.InsertSalaryScale(EL)
    End Function
    Public Function DeleteSalryScale(ByVal EL As ELSalaryScaleGrade) As Integer
        Return DL.DeleteSalryScale(EL)
    End Function
    Public Function DisplayGridview(ByVal id As Integer) As DataTable
        Return DLSalaryScaleGrade.DisplayGridview(id)
    End Function
    Public Function UpdateSalaryScale(ByVal EL As ELSalaryScaleGrade) As String
        Return DLSalaryScaleGrade.UpdateSalaryScale(EL)
    End Function
    Public Function CheckDuplicate(ByVal EL As ELSalaryScaleGrade) As System.Data.DataTable
        Return DL.CheckDuplicate(EL)
    End Function
End Class
