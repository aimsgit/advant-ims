Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BLSystemConfiguration
    Public Function InsertRecord(ByVal C As SystemConfiguration) As Integer
        Return DLSystemConfiguration.Insert(C)
    End Function
    Public Function UpdateRecord(ByVal C As SystemConfiguration) As Integer
        Return DLSystemConfiguration.Update(C)
    End Function
    Public Function DisplayRecord(ByVal C As SystemConfiguration) As Data.DataTable
        Dim dt As DataTable = DLSystemConfiguration.Display(C)
        Return dt
    End Function
    Public Function DisplayBranchRecord(ByVal C As SystemConfiguration) As Data.DataTable
        Dim dt As DataTable = DLSystemConfiguration.DisplayBranch(C)
        Return dt
    End Function
    Public Function ChangeFlag(ByVal C As SystemConfiguration) As Integer
        Return DLSystemConfiguration.ChangeFlag(C)
    End Function
    Public Function UpdateBranchRecord(ByVal C As SystemConfiguration) As Integer
        Return DLSystemConfiguration.UpdateBranch(C)
    End Function
End Class
