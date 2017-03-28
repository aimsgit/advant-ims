Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Public Class LeaveManager
    Dim ld As New leavedb
    Public Function GetLeave(ByVal Leave As Leave) As DataTable
        'Dim leave As New List(Of Leave)
        'Dim ds As DataSet = LeaveDB.GetLeave(id)
        'Dim row As DataRow
        'For Each row In ds.Tables(0).Rows
        '    leave.Add(New Leave(row("LM_ID"), row("E_ID"), row("Emp_Name"), row("Leave_Type"), row("LeaveType"), row("BalanceLeave"), row("Remarks")))
        'Next
        Return LeaveDB.GetLeave(Leave)
    End Function
    'Public Function GetLeave() As List(Of Leave)
    '    Dim leave As New List(Of Leave)
    '    Dim ds As DataSet = LeaveDB.GetLeave(0)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        leave.Add(New Leave(row("LM_ID"), row("E_ID"), row("Emp_Name"), row("Leave_Type"), row("LeaveType"), row("BalanceLeave"), row("Remarks")))
    '    Next
    '    Return leave
    'End Function
    'Public Function GetLeaveByLM_ID(ByVal id As Long) As Leave
    '    Dim ds As DataSet = LeaveDB.GetLeave(id)
    '    Dim row As DataRow = ds.Tables(0).Rows(0)
    '    Dim leave As Leave = New Leave(row("LM_ID"), row("E_ID"), row("Emp_Name"), row("Leave_Type"), row("LeaveType"), row("BalanceLeave"), row("Remarks"))
    '    Return leave
    'End Function
    Public Function InsertRecord(ByVal l As Leave) As Integer
        'If l.BalanceLeave = Nothing Then
        '    l.BalanceLeave = 0
        'End If
        'If l.Remarks = Nothing Then
        '    l.Remarks = ""
        'End If
        Return LeaveDB.Insert(l)
    End Function
    Public Function InsertRecordAll(ByVal l As Leave) As Integer
        'If l.BalanceLeave = Nothing Then
        '    l.BalanceLeave = 0
        'End If
        'If l.Remarks = Nothing Then
        '    l.Remarks = ""
        'End If
        Return LeaveDB.InsertAll(l)
    End Function
    Public Function UpdateRecord(ByVal l As Leave) As Integer
        'If l.BalanceLeave = Nothing Then
        '    l.BalanceLeave = 0
        'End If
        'If l.Remarks = Nothing Then
        '    l.Remarks = ""
        'End If
        Return ld.Update(l)
    End Function
    'Public Function ChangeFlag(ByVal l As Leave) As Integer
    '    'Dim Status As Boolean
    '    'Status = globalcnn.Del_Validation(l.Id, "Leave")
    '    'If Status = True Then
    '    ''Return 0
    '    ''Else
    '    Return LeaveDB.ChangeFlag(l.EId)
    '    ''End If
    'End Function
    Public Function GetReport(ByVal insid As Int64, ByVal brnId As Int64) As Data.DataTable
        Return LeaveDB.GetReport(insid, brnId)
    End Function
    Public Function Delete(ByVal leave As Leave) As Integer
        'Dim rowsaffected As Integer
        'rowsaffected = )
        Return ld.Delete(leave)
    End Function
    Public Function GetDuplicateLeaveDetails(ByVal Leave As Leave) As DataTable
        Return ld.GetDuplicateLeaveDtl(Leave)
    End Function
    
End Class
