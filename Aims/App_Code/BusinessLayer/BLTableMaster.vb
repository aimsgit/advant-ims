Imports Microsoft.VisualBasic
Imports System.Data

Public Class BLTableMaster
    Public Function InsertRecord(ByVal p As TableMaster) As Integer
        Return DLTableMaster.InsertTableMaster(p)
    End Function
    Public Function UpdateRecord(ByVal p As TableMaster) As Integer
        Return DLTableMaster.UpdateTableMaster(p)
    End Function
    Public Function DeleteRecord(ByVal p As TableMaster) As Integer
        Return DLTableMaster.DeleteTableMaster(p)
    End Function
    Public Function GetTableMasterRecords(ByVal p As TableMaster) As DataTable
        Return DLTableMaster.GetAllTableMaster(p)
    End Function
    Public Function GetTableNames(ByVal p As TableMaster) As DataTable
        Return DLTableMaster.GetTableNames(p)
    End Function
    Public Function GetTableNamesApprove(ByVal p As TableMaster) As DataTable
        Return DLTableMaster.GetTableNamesApprove(p)
    End Function
End Class
