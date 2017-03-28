Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class Mfg_SalesReportDL
    Shared Function Get_ProductName() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Get_ProductName", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GenerateSalesReport(ByVal ProductName As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Params() As SqlParameter = New SqlParameter(3) {}

        Params(0) = New SqlParameter("@ProductId", Data.SqlDbType.Int)
        Params(0).Value = ProductName

        Params(1) = New SqlParameter("@Startdate", Data.SqlDbType.DateTime)
        Params(1).Value = StartDate

        Params(2) = New SqlParameter("@EndDate", Data.SqlDbType.DateTime)
        Params(2).Value = EndDate

        Params(3) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar)
        Params(3).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GenerateSalesReport", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function PosteddatedeCheque(ByVal BankId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Params() As SqlParameter = New SqlParameter(4) {}

        Params(0) = New SqlParameter("@BankId", Data.SqlDbType.Int)
        Params(0).Value = BankId

        Params(1) = New SqlParameter("@Startdate", Data.SqlDbType.DateTime)
        Params(1).Value = StartDate

        Params(2) = New SqlParameter("@EndDate", Data.SqlDbType.DateTime)
        Params(2).Value = EndDate

        Params(3) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar)
        Params(3).Value = HttpContext.Current.Session("BranchCode")

        Params(4) = New SqlParameter("@Office", Data.SqlDbType.VarChar)
        Params(4).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_PostDatedChequeRegisterReport", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function ReturnedChequeRegister(ByVal BankId As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Params() As SqlParameter = New SqlParameter(4) {}

        Params(0) = New SqlParameter("@BankId", Data.SqlDbType.Int)
        Params(0).Value = BankId

        Params(1) = New SqlParameter("@Startdate", Data.SqlDbType.DateTime)
        Params(1).Value = StartDate

        Params(2) = New SqlParameter("@EndDate", Data.SqlDbType.DateTime)
        Params(2).Value = EndDate

        Params(3) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar)
        Params(3).Value = HttpContext.Current.Session("BranchCode")

        Params(4) = New SqlParameter("@Office", Data.SqlDbType.VarChar)
        Params(4).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_ReturnChequeRegisterReport", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
