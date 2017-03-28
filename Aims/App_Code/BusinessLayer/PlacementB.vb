Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class PlacementB
    Dim dal As New PlacementDB
    Public Function InsertRecord(ByVal p As PlacementDetails) As Integer
        Return PlacementDB.Insert(p)
    End Function
    Public Function UpdateRecord(ByVal p As PlacementDetails) As Integer
        'If p.Remark = Nothing Then
        '    p.Remark = ""
        'End If
        Return PlacementDB.Update(p)
    End Function
    'Public Function ChangeFlag(ByVal p As PlacementDetails) As Integer
    '    Dim Status As Boolean
    '    Status = globalcnn.Del_Validation(p.Id, "PlacementDetails")
    '    If (Status) = True Then
    '        Return 0
    '    Else
    '        Return PlacementDB.ChangeFlag(p.Id)
    '    End If
    'End Function
    Public Function GetPlacementdetailsbyradio(ByVal ELL As PlacementDetails) As DataTable
        Dim dt As New DataTable
        dt = dal.GetPlacementdetailsbyradio(ELL)
        Return dt
    End Function
    Public Function GetStdnameByCode(ByVal code As Integer) As String
        Dim dt As New DataTable
        dt = dal.GetStdnameByCode(code)
        Return dt.Rows(0).Item(1)
    End Function
    'Public Function GetCourse(ByVal el As PlacementDetails) As DataTable
    '    Dim dt As New DataTable
    '    dt = dal.GetCourse(el)
    '    Return dt
    'End Function
    Public Function GetBatch(ByVal el As PlacementDetails) As DataTable
        Dim dt As New DataTable
        dt = dal.GetBatch(el)
        Return dt
    End Function

    Public Function GetInstitute() As DataTable
        Dim dt As New DataTable
        dt = dal.GetInstitute()
        Return dt
    End Function
    Public Function GetBranch(ByVal id As Integer) As DataTable
        Dim dt As New DataTable
        dt = dal.GetBranch(id)
        Return dt
    End Function
    'Public Function GetAcademicCombo() As DataTable
    '    Return PlacementDB.GetAcademicCombo()
    'End Function
    Public Function GetcompanyCombo() As DataTable
        Return PlacementDB.GetcompanyCombo()
    End Function
    Public Function ChangeFlag(ByVal p As Integer) As Integer
        'Dim Status As Boolean
        'Status = globalcnn.Del_Validation(c.Id, "DeptMaster")
        'If (Status) = True Then
        '    Exit Function
        'End If
        Return PlacementDB.ChangeFlag(p)
    End Function
    Shared Function CheckDuplicate(ByVal s As PlacementDetails) As Data.DataTable
        Return PlacementDB.CheckDuplicate(s)
    End Function
End Class
