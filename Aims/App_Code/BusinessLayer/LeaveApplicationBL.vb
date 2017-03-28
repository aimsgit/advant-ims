Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data


Public Class LeaveApplicationBL
    Dim DL As New LeaveApplicationDL
    Public Function getEmpName() As Data.DataTable
        Return LeaveApplicationDL.getEmpName()
    End Function
    Public Function InsertRecord(ByVal El As LeaveApplicationEL) As Integer
        Return LeaveApplicationDL.InsertRecord(El)
    End Function
    Public Function DispGrid(ByVal id As Integer) As Data.DataTable
        Return LeaveApplicationDL.DispGrid(id)
    End Function
    Public Function DispGrid1(ByVal id As Integer, ByVal Empid As Integer) As Data.DataTable
        Return LeaveApplicationDL.DispGrid1(id, Empid)
    End Function

    Public Function balanceleave(ByVal leavetype As Integer, ByVal empid As Integer) As Data.DataTable
        Return LeaveApplicationDL.balanceleave(leavetype, empid)
    End Function
    Public Function email(ByVal El As LeaveApplicationEL) As Data.DataTable
        Dim dll As New LeaveApplicationDL
        Return dll.email(El)
    End Function

    Public Function CheckDuplicate(ByVal leaveApp As LeaveApplicationEL)
        Return LeaveApplicationDL.CheckDuplicate(leaveApp)
    End Function

    Public Function HRemail(ByVal El As LeaveApplicationEL) As Data.DataTable
        Dim dll As New LeaveApplicationDL
        Return dll.HRemail(El)
    End Function

    Public Function InsertRecordforOtherEmployee(ByVal El As LeaveApplicationEL) As Integer
        Return LeaveApplicationDL.InsertRecordforOtherEmployee(El)
    End Function

    Public Function CheckDuplicateforOtherEmployee(ByVal leaveApp As LeaveApplicationEL)
        Return LeaveApplicationDL.CheckDuplicateforOtherEmployee(leaveApp)
    End Function
    Public Function HRemailforCancel(ByVal El As LeaveApplicationEL) As Data.DataTable
        Dim dll As New LeaveApplicationDL
        Return dll.HRemailforCancel(El)
    End Function
    Public Function emailforCancel(ByVal El As LeaveApplicationEL) As Data.DataTable
        Dim dll As New LeaveApplicationDL
        Return dll.emailforCancel(El)
    End Function

    Public Function delegatename(ByVal empid As Integer) As Data.DataTable
        Return LeaveApplicationDL.delegatename(empid)
    End Function

    Public Function DelegateMail(ByVal El As LeaveApplicationEL) As Data.DataTable
        Dim dll As New LeaveApplicationDL
        Return dll.DelegateMail(El)
    End Function
End Class
