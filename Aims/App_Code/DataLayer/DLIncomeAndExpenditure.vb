Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLIncomeAndExpenditure
    Public Function IncomeAndExpenditure(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal PR As Integer) As DataTable
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

        arParms(4) = New SqlParameter("@Project", SqlDbType.Int)
        arParms(4).Value = PR


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_IncAndExp_Qry", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function IncomeAndExpenditure1(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_IncAndExp_Qry1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function IncomeAndExpenditureGridView(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_IncAndExp_QryGridView", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ReceiptsPaymentsStatement(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_ReceiptsPaymentsStatement", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Rpt_AccountsPayable(ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_AccountsPayable", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
