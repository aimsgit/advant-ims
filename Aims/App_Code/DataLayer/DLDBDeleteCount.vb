Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLDBDeleteCount
    Shared Function GetDeleteCount() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DeleteAllJunkDataCount")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
