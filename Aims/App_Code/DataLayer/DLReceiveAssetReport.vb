Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLReceiveAssetReport

    Public Function ReceiveAssetReport(ByVal AT As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@AssetType", SqlDbType.Int)
        param(0).Value = AT
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Office")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_ReceiveAssetReport", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
