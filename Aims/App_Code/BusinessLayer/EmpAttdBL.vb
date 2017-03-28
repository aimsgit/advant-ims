Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class EmpAttdBL
    Public Function getTimeIn(ByVal EL As Employee) As String
        Return EmpAttdDL.getTimeIn(EL)
    End Function
    Public Function getTimeout(ByVal EL As Employee) As String
        Return EmpAttdDL.getTimeOut(EL)
    End Function
    Public Function getDetails(ByVal EL As Employee) As Data.DataTable
        Return EmpAttdDL.getDetails(EL)
    End Function
    Public Function EmpAttd(ByVal EL As Employee) As Data.DataTable
        Dim a As New EmpAttdDL
        Return a.EmpAttd(EL)
    End Function
    Public Function GetByDeleteEmp(ByVal El As Employee) As Int16
        Dim Dl As New EmpAttdDL
        Return Dl.UpdateDel(El)
    End Function
    Public Function getEmpName() As Data.DataTable
        Return EmpAttdDL.GetEmpName()
    End Function
    Public Function EmpAttendanceduplicate(ByVal El As Employee) As Data.DataTable
        Return EmpAttdDL.EmpAttendanceduplicate(El)
    End Function

End Class
