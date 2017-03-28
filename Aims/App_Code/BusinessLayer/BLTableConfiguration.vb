Imports Microsoft.VisualBasic
Imports System.Data

Public Class BLTableConfiguration
    Public Function InsertRecord(ByVal p As TableConfiguration) As Integer
        Return DLTableConfiguration.InsertTableConfig(p)
    End Function
    Public Function UpdateRecord(ByVal p As TableConfiguration) As Integer
        Return DLTableConfiguration.UpdateTableConfig(p)
    End Function
    Public Function DeleteRecord(ByVal p As TableConfiguration) As Integer
        Return DLTableConfiguration.DeleteTableConfig(p)
    End Function
    Public Function GetEmpName(ByVal p As String) As String
        Return DLTableConfiguration.GetEmpName(p)
    End Function
    Public Function GetBranchTypeName(ByVal p As String) As String
        Return DLTableConfiguration.GetBranchTypeName(p)
    End Function
    Public Function GetTableConfigRecords(ByVal p As TableConfiguration) As DataTable
        Return DLTableConfiguration.GetTableConfigDetails(p)
    End Function
    Public Function GetBranchTypes() As DataTable
        Return DLTableConfiguration.GetBranchtype()
    End Function
    Public Function CheckDuplicate(ByVal rnd As String) As Data.DataTable
        Return DLTableConfiguration.CheckDupli(rnd)
    End Function
End Class
