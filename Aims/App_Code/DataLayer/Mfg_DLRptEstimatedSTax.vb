Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Mfg_DLRptEstimatedSTax
    Shared Function GetRptEstimatedSTax(ByVal Fromdate As DateTime, ByVal Todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@FromDate", SqlDbType.Date)
        para(2).Value = Fromdate
        para(3) = New SqlParameter("@ToDate", SqlDbType.Date)
        para(3).Value = Todate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_GetEstimatedTax", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
