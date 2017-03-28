Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_RptComp_Buyersal

    Shared Function GetProductwise(ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal RbId As Integer, ByVal Mfg As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@FromDate", SqlDbType.Date)
        para(2).Value = Fromdate
        para(3) = New SqlParameter("@ToDate", SqlDbType.Date)
        para(3).Value = Todate
        para(4) = New SqlParameter("@RbId", SqlDbType.Int)
        para(4).Value = RbId
        para(5) = New SqlParameter("@Mfg", SqlDbType.Int)
        para(5).Value = Mfg


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_rptMfg_Productwisesale", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBuyerwise(ByVal Fromdate As DateTime, ByVal Todate As DateTime, ByVal RbId As Integer, ByVal Mfg As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@FromDate", SqlDbType.Date)
        para(2).Value = Fromdate
        para(3) = New SqlParameter("@ToDate", SqlDbType.Date)
        para(3).Value = Todate
        para(4) = New SqlParameter("@RbId", SqlDbType.Int)
        para(4).Value = RbId
        para(5) = New SqlParameter("@Mfg", SqlDbType.Int)
        para(5).Value = Mfg


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_rptMfg_Buyerwisesale", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
