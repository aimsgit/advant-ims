Imports Microsoft.VisualBasic

Public Class BLUserManagement
    Public Function GetAccessTypesDDL() As Data.DataTable
        Return DLUserManagement.GetAccessLevels()
    End Function
    Public Function GetRolesDDL(ByVal U As String) As Data.DataTable
        Dim U1 As New UserManagement
        U1.BranchID = U
        Return DLUserManagement.GetRoles(U1)
    End Function
    Public Function InsertRecord(ByVal g As UserManagement) As Integer
        Return DLUserManagement.InsertUserManagement(g)
    End Function
    Public Function GetUserDetails(ByVal U As UserManagement) As Data.DataTable
        Return DLUserManagement.GetUserDetails(U)
    End Function
    Public Function GetSearchUserDetails(ByVal U As String, ByVal E As String) As Data.DataTable
        Return DLUserManagement.GetSearchResults(U, E)
    End Function
    Public Function UpdateRecord(ByVal g As UserManagement) As Integer
        Return DLUserManagement.UpdateUserDetails(g)
    End Function
    Public Function DeleteRecord(ByVal g As UserManagement) As Integer
        Return DLUserManagement.DeleteUserDetails(g)
    End Function
    Public Function GetRolesDetails(ByVal g As String) As String
        Return DLUserManagement.GetRolesFromUserDetails(g)
    End Function
    Public Function GetRolesDetailsForUpdate(ByVal g As String) As String
        Return DLUserManagement.GetRolesFromUserDetailsForUpdate(g)
    End Function
    Public Function GetBranchName(ByVal g As String) As DataTable
        Return DLUserManagement.GetBranchName(g)
    End Function
End Class
