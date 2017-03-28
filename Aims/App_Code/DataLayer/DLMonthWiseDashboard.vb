Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLMonthWiseDashboard
    Public Function MonthWisePurchaseSales(ByVal Year As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Year", SqlDbType.VarChar, 30)
            Parms(1).Value = Year

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_MonthWisePurchaseSales", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function MonthWiseStock(ByVal Year As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Year", SqlDbType.VarChar, 30)
            Parms(1).Value = Year

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_MonthWiseStockDashboard", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function MonthWisePurchaseSalesReturn(ByVal Year As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Year", SqlDbType.VarChar, 30)
            Parms(1).Value = Year

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_MonthWisePurchaseSalesReturn", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function MonthWisePayablesPaid(ByVal Year As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Year", SqlDbType.VarChar, 30)
            Parms(1).Value = Year

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_MonthWisePayablePaid", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function MonthWiseReceivableReceived(ByVal Year As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Year", SqlDbType.VarChar, 30)
            Parms(1).Value = Year

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_MonthWiseReceivableReceived", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function MonthWiseCashFlow(ByVal Year As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Year", SqlDbType.VarChar, 30)
            Parms(1).Value = Year

            Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 30)
            Parms(2).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_MonthWisecashFlowDashboard", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
