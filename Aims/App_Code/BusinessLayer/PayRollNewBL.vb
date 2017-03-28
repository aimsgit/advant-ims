Imports Microsoft.VisualBasic

Public Class PayRollNewBL
    Public Function Insert(ByVal EL As PayRollNewEL) As Integer
        Return PayRollNewDL.Insert(EL)
    End Function
    Public Function DisplayGridview(ByVal Id As Integer, ByVal EmpId As Integer) As DataTable
        Return PayRollNewDL.DisplayGridview(Id, EmpId)
    End Function
    Public Function DisplayGridviewDeduction(ByVal Id As Integer, ByVal EmpId As Integer) As DataTable
        Return PayRollNewDL.DisplayGridviewDeduction(Id, EmpId)
    End Function
    Public Function Update(ByVal EL As PayRollNewEL) As Integer
        Return PayRollNewDL.Update(EL)
    End Function
    Public Function Delete(ByVal EL As PayRollNewEL) As Integer
        Return PayRollNewDL.Delete(EL)
    End Function

    Public Function GetDuplicatePayrollDetailsNew(ByVal EL As PayRollNewEL) As Data.DataTable
        Return PayRollNewDL.GetDuplicatePayrollDetailsNew(EL)
    End Function

End Class
