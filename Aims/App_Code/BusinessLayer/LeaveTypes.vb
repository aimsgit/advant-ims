Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class LeaveTypes
    Public Function GetLeavTypes(ByVal id As ELLeavTypes) As Data.DataTable

        Return LeaveTypesDB.GetLeavTypes(id)
        'Dim row As DataRow
        'For Each row In ds.Tables(0).Rows
        '    LeavTypes.Add(New LeavTypes(row("TY_ID"), row("Leave_Type"), row("LeaveDescription")))
        'Next
        'Return LeavTypes
    End Function
    'Public Function GetLeavTypes(ByVal id As Long) As Data.DataTable
    '    'Dim leave As New List(Of LeavTypes)
    '    Return LeaveTypesDB.GetLeavTypes(id)
    '    'Dim row As DataRow
    '    'For Each row In ds.Tables(0).Rows
    '    '    leave.Add(New LeavTypes(row("TY_ID"), row("Leave_Type"), row("LeaveDescription")))
    '    'Next
    '    'Return leave
    'End Function
    'Public Function GetLeaveTypeById(ByVal id As Long) As Data.DataTable
    '    'Dim leave As LeavTypes
    '    Return LeaveTypesDB.GetLeavTypes(id)
    '    'Dim row As DataRow = ds.Tables(0).Rows(0)
    '    'leave = New LeavTypes(row("TY_ID"), row("Leave_Type"), row("LeaveDescription"))
    '    'Return leave
    'End Function
    Public Function InsertRecord(ByVal el As ELLeavTypes) As Integer
        'If LT.LeaveDescription = Nothing Then
        '    LT.LeaveDescription = ""
        'End If
        Return LeaveTypesDB.Insert(el)
    End Function
    Public Function UpdateRecord(ByVal el As ELLeavTypes) As Integer
        'If LT.LeaveDescription = Nothing Then
        '    LT.LeaveDescription = ""
        'End If
        Return LeaveTypesDB.Update(el)
    End Function
    Public Function GetDuplicateLeaveType(ByVal el As ELLeavTypes) As Data.DataTable
        Return LeaveTypesDB.GetDuplicateLeaveType(el)
    End Function
    Public Function ChangeFlag(ByVal el As ELLeavTypes) As Integer
        'Dim Status As Boolean
        'Status = globalcnn.Del_Validation(i.Id, "Institute")
        'If (Status) = True Then
        '    Exit Function
        'End If
        Return LeaveTypesDB.ChangeFlag(el.TY_ID)
    End Function
End Class
