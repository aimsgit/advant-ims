Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data


Public Class DepartmentManager
    Dim dm As New DepartmentDB
    'Public Function GetDepartment() As List(Of Department)
    '    Dim department As New List(Of Department)
    '    Dim ds As DataSet = DepartmentDB.getDepartment()
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        department.Add(New Department(row("Dept_ID"), row("DeptName"), row("DeptCode")))
    '    Next
    '    Return department
    'End Function
    'Public Function GetDepartmentRpt() As DataTable

    '    Dim ds As DataSet = DepartmentDB.getDepartment()
    '    Return ds.Tables(0)
    'End Function

    'Public Function GetDepartmentByDepartmentId(ByVal id As Long) As Department
    '    Dim department As New Department
    '    Dim ds As DataSet = DepartmentDB.getDepartment()
    '    If ds.Tables(0).Rows.Count > 0 Then
    '        Dim row As DataRow = ds.Tables(0).Rows(0)
    '        department = New Department(row("Dept_ID"), row("DeptName"), row("DeptCode"))
    '    End If
    '    Return department
    'End Function
    Public Function GetDepartmentDtls(ByVal Department As Department) As System.Data.DataTable
        'Dim dt As New DataTable
        Return DepartmentDB.getDepartmentDtls(Department)
        'dataSet = DepartmentDB.getDepartmentDtls(Department)
        'Return dataSet.Tables(0)
    End Function
    Public Function InsertRecord(ByVal c As Department) As Integer

        Return DepartmentDB.Insert(c)
    End Function
    Public Function UpdateRecord(ByVal c As Department) As Integer
        Return DepartmentDB.Update(c)
    End Function
    Public Function ChangeFlag(ByVal c As Department) As Integer
        'Dim Status As Boolean
        'Status = globalcnn.Del_Validation(c.Id, "DeptMaster")
        'If (Status) = True Then
        '    Exit Function
        'End If
        Return DepartmentDB.ChangeFlag(c.Id)
    End Function
    Public Function CheckDuplicate(ByVal s As Department) As System.Data.DataTable
        Return dm.CheckDuplicate(s)
    End Function

    'Public Function getDepartmentDtls(ByVal Inst As Int64, ByVal Brch As Int64) As Data.DataTable
    '    Return DepartmentDB.getDepartmentDtls(Inst, Brch)
    'End Function
End Class
