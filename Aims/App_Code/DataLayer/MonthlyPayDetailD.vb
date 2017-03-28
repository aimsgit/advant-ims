Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class MonthlyPayDetailD
    Public Function generate(ByVal month As String, ByVal year As Integer, ByVal Dept As Integer) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(6) {}

        param(0) = New SqlParameter("@Month", SqlDbType.VarChar, month.Length)
        param(0).Value = month

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        param(2) = New SqlParameter("@Year", SqlDbType.Int)
        param(2).Value = year


        param(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("EmpCode")

        param(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("UserCode")

        param(5) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("Office")

        param(6) = New SqlParameter("@Dept", SqlDbType.Int)
        param(6).Value = Dept


        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_GenerateMonthlyPayDetails]", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Function
    Public Function update(ByVal m As MonthlyPayDetailsE) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(15) {}

        param(0) = New SqlParameter("@MD_ID", SqlDbType.Int)
        param(0).Value = m.MD_ID

        param(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("EmpCode")

        param(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("UserCode")

        param(3) = New SqlParameter("@DaysWorked", SqlDbType.Int)
        param(3).Value = m.DaysWorked

        param(4) = New SqlParameter("@MonthlyIncentive", SqlDbType.Money)
        param(4).Value = m.MonthlyIncentive

        param(5) = New SqlParameter("@Bonus", SqlDbType.Money)
        param(5).Value = m.Bonus

        param(6) = New SqlParameter("@Reimbursements", SqlDbType.Money)
        param(6).Value = m.Reimbursements

        param(7) = New SqlParameter("@OthMonthlyPayments", SqlDbType.Money)
        param(7).Value = m.OtherMonthlyPayments

        param(8) = New SqlParameter("@ITTaxDeduction", SqlDbType.Money)
        param(8).Value = m.ITDeduction

        param(9) = New SqlParameter("@LoanDeduction", SqlDbType.Money)
        param(9).Value = m.LoanDeduction

        param(10) = New SqlParameter("@TransportDeduction", SqlDbType.Money)
        param(10).Value = m.TransportDeduction

        param(11) = New SqlParameter("@OtherDeduction", SqlDbType.Money)
        param(11).Value = m.OtherDeduction

        param(12) = New SqlParameter("@Remarks", SqlDbType.VarChar, m.Remarks.Length)
        param(12).Value = m.Remarks

        param(13) = New SqlParameter("@SaleryAdv", SqlDbType.Money)
        param(13).Value = m.Saladv

        param(14) = New SqlParameter("@AdvStlDeduction", SqlDbType.VarChar, m.Remarks.Length)
        param(14).Value = m.Advsalded

        param(15) = New SqlParameter("@PLDays", SqlDbType.Money)
        param(15).Value = m.PLDays


        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Proc_UpdateMonthlyPayDetails]", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Function
    Public Function updateLoannDedc(ByVal m As MonthlyPayDetailsE) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(4) {}

        param(0) = New SqlParameter("@MD_ID", SqlDbType.Int)
        param(0).Value = m.MD_ID

        param(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("EmpCode")

        param(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("UserCode")

        param(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")

        param(4) = New SqlParameter("@EmpId", SqlDbType.Int)
        param(4).Value = m.EmpCode
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetLoanDeduction]", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function ClearMarks(ByVal month As String, ByVal year As Integer, ByVal Dept As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim param() As SqlParameter = New SqlParameter(3) {}

        param(0) = New SqlParameter("@Month", SqlDbType.VarChar, month.Length)
        param(0).Value = month

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        param(2) = New SqlParameter("@Year", SqlDbType.Int)
        param(2).Value = year

        param(3) = New SqlParameter("@Dept", SqlDbType.Int)
        param(3).Value = Dept

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_ClearMonthlyPayDetails", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Public Function getgrid(ByVal month As String, ByVal year As Integer, ByVal Dept As Integer) As DataTable

        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        param(2).Value = month
        param(3) = New SqlParameter("@Year", SqlDbType.Int)
        param(3).Value = year
        param(4) = New SqlParameter("@Dept", SqlDbType.Int)
        param(4).Value = Dept
        'param(2) = New SqlParameter("@StdCode", SqlDbType.VarChar, 50)
        'param(2).Value = b
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetMonthlyPayDetails]", param)
            Return ds.Tables(0)
        Catch ex As Exception

        End Try

    End Function
    Public Function getgrid1(ByVal month As String, ByVal year As Integer, ByVal Dept As Integer) As DataTable

        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        param(2).Value = month
        param(3) = New SqlParameter("@Year", SqlDbType.Int)
        param(3).Value = year
        param(4) = New SqlParameter("@Dept", SqlDbType.Int)
        param(4).Value = Dept
        'param(2) = New SqlParameter("@StdCode", SqlDbType.VarChar, 50)
        'param(2).Value = b
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetMonthlyPayDetails1]", param)
            Return ds.Tables(0)
        Catch ex As Exception

        End Try

    End Function
    Public Function duplicate(ByVal month As String, ByVal year As Integer, ByVal Dept As Integer) As DataTable

        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        param(2).Value = month
        param(3) = New SqlParameter("@Year", SqlDbType.Int)
        param(3).Value = year
        param(4) = New SqlParameter("@Dept", SqlDbType.Int)
        param(4).Value = Dept
        'param(2) = New SqlParameter("@StdCode", SqlDbType.VarChar, 50)
        'param(2).Value = b
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetDupliacteMonthlyPayDetails]", param)
            Return ds.Tables(0)
        Catch ex As Exception

        End Try

    End Function
End Class
