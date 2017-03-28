Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLBankBookReport
    'Function For Bank Book Report
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

    Public Function BankBookReport1(ByVal PR As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal RT As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = StartDate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = EndDate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")

        arParms(4) = New SqlParameter("@Project", SqlDbType.Int)
        arParms(4).Value = PR

        arParms(5) = New SqlParameter("@RT", SqlDbType.Int)
        arParms(5).Value = RT
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_BankBook_Qry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function AccountingBudget(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_AccountingBudget", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function AccountingBudgetDetailed(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal AccHead As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = StartDate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = EndDate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")

        arParms(4) = New SqlParameter("@AccHead", SqlDbType.Int)
        arParms(4).Value = AccHead

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_AccountingBudgetDetailed", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
