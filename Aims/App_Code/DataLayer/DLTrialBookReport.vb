Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLTrialBookReport
    Public Function BankBookReport(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = StartDate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = EndDate


        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBankBookReport", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function TrialBookReport1(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = StartDate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = EndDate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_TrialBalanceSheet", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function TrialBookReport12(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = StartDate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = EndDate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_TrialBalanceSheet1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function DisplayGridview(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim rowsAffected As Integer = 0
        Dim Params() As SqlParameter = New SqlParameter(3) {}
        'Params(0) = New SqlParameter("@id", Data.SqlDbType.Int)
        'Params(0).Value = id


        Params(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Params(0).Value = HttpContext.Current.Session("BranchCode")

        Params(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Params(1).Value = HttpContext.Current.Session("Office")
        Params(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        Params(2).Value = StartDate

        Params(3) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        Params(3).Value = EndDate

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Test_TrialBalanceSheet2", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function FirstDrillDown(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal accsubgrpId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = StartDate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = EndDate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(3).Value = HttpContext.Current.Session("Office")

        arParms(4) = New SqlParameter("@accsubgrpId", SqlDbType.Int)
        arParms(4).Value = accsubgrpId



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "TrialBalanceDrillDown", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function TrialBalanceSheet(ByVal fromdate As DateTime, ByVal todate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = fromdate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = todate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(3).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_BalanceSheet", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
