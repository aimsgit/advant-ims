Imports Microsoft.VisualBasic
Imports System.Data

Public Class BLAimsUsageAnalytics
    Public Function GetTableNames(ByVal p As TableMaster) As DataTable
        Return DLAimsUsageAnalytics.GetTableNames(p)
    End Function
    Public Function GetTableDetails(ByVal EL As ELAimsUsageAnalytics) As Data.DataTable

        Return DLAimsUsageAnalytics.GetTableDetails(EL)
    End Function
End Class
