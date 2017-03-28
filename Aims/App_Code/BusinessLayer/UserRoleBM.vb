Imports Microsoft.VisualBasic
Imports System.Collections.generic

Public Class UserRoleBM
    'Public Function GetUserRole(ByVal URoleID As Long) As List(Of UserRole)
    '    Dim URole As New List(Of UserRole)
    '    Dim ds As DataSet = UserRoleDB.UserRole(URoleID)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        URole.Add(New UserRole(row("UserRoleID"), row("UserRole"), row("Access_Permission_Forms"), row("Del_Flag")))
    '    Next
    '    Return URole
    'End Function
    'Public Function GetUserRoleByID(ByVal URoleID As Long) As UserRole
    '    Dim URole As New UserRole
    '    Dim ds As DataSet = UserRoleDB.UserRole(URoleID)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        URole = New UserRole(row("UserRoleID"), row("UserRole"), row("Access_Permission_Forms"), row("Del_Flag"))
    '    Next
    '    Return URole
    'End Function
    'Public Shared Function GetUserRoleCombo(ByVal id As Long) As List(Of UserRoleCombo)
    '    Dim URole As New List(Of UserRoleCombo)
    '    Dim ds As DataSet = UserRoleDB.GVComboUser(id)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        URole.Add(New UserRoleCombo(row("UserRoleID"), row("UserRole")))
    '    Next
    '    Return URole
    'End Function
End Class
