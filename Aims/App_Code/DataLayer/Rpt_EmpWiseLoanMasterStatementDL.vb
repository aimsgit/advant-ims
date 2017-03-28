Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class Rpt_EmpWiseLoanMasterStatementDL
    Shared Function GenerateEmpWiseLoanMasterStatementReport(ByVal CompanyName As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Params() As SqlParameter = New SqlParameter(3) {}

        Params(0) = New SqlParameter("@EmpId", Data.SqlDbType.Int)
        Params(0).Value = CompanyName

        Params(1) = New SqlParameter("@FDate", Data.SqlDbType.DateTime)
        Params(1).Value = StartDate

        Params(2) = New SqlParameter("@TDate", Data.SqlDbType.DateTime)
        Params(2).Value = EndDate

        Params(3) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar, 50)
        Params(3).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_EmpWiseLoanMasterStatementReport", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GenerateLoanTypeWiseLoanMasterStatementReport(ByVal CompanyName As Integer, ByVal StartDate As DateTime, ByVal EndDate As DateTime) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Params() As SqlParameter = New SqlParameter(3) {}

        Params(0) = New SqlParameter("@loanTypeId", Data.SqlDbType.Int)
        Params(0).Value = CompanyName

        Params(1) = New SqlParameter("@FDate", Data.SqlDbType.DateTime)
        Params(1).Value = StartDate

        Params(2) = New SqlParameter("@TDate", Data.SqlDbType.DateTime)
        Params(2).Value = EndDate

        Params(3) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar, 50)
        Params(3).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_LoanTypeWiseLoanMasterStatementReport", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpNameDDL() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLoanEmpNameLoanMasterDDL", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetLoanTypeDDL() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLoanType1LookupDDL")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
