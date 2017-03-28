Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data

Public Class BLBranchAccessLevel
    Public Function GetBranchByUID() As Data.DataTable
        Return DLBranchAccessLevel.FillBranchByUID()
    End Function
    Public Function GetBranch() As DataTable
        Return DLBranchAccessLevel.insertBranch()
    End Function
End Class
