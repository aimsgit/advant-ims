Imports Microsoft.VisualBasic


Public Class BLDeptDashboard

    Public Function GetDept() As Data.DataTable
        Return DLDeptDashboard.GetDept()
    End Function


    Public Function GetDeptEmpDetails(ByVal Deptid As Integer) As Data.DataTable
        Return DLDeptDashboard.GetDeptEmpDetails(Deptid)
    End Function
End Class
