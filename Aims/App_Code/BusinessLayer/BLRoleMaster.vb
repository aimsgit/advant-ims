Imports Microsoft.VisualBasic
Imports System.Data

Public Class BLRoleMaster
    Public Function InsertRecord(ByVal p As RoleMaster) As Integer
        Return DLRoleMaster.InsertRoleMaster(p)
    End Function
    Public Function UpdateRecord(ByVal p As RoleMaster) As Integer
        Return DLRoleMaster.UpdateRoleMaster(p)
    End Function
    Public Function DeleteRecord(ByVal p As RoleMaster) As Integer
        Return DLRoleMaster.DeleteRoleMaster(p)
    End Function
    Public Function GetRoleMasterRecords(ByVal p As RoleMaster) As DataTable
        Return DLRoleMaster.GetAllRoleMaster(p)
    End Function
    Public Function GetDuplicateRoleMaster(ByVal p As String, ByVal Id As Integer) As DataTable
        Return DLRoleMaster.GetDuplicateRoleMaster(p, Id)
    End Function
End Class
