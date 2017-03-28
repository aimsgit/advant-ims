Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DataMonthlySalary
    Shared Function GenerateSalary(ByVal Prop As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@WD_InMonth", SqlDbType.Int)
        arParms(0).Value = Prop.WD_InMonth

        arParms(1) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(1).Value = Prop.Month

        arParms(2) = New SqlParameter("@PayDate", SqlDbType.DateTime)
        arParms(2).Value = Prop.PayDate

        arParms(3) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(3).Value = Prop.Year

        arParms(4) = New SqlParameter("@WorkDay", SqlDbType.Int)
        arParms(4).Value = Prop.WorkDays

        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(5).Value = HttpContext.Current.Session("Office")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(9).Value = Prop.Dept
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_Payroll_Generate_Salary", arParms)
        Catch e As Exception
        End Try
        Return rowsAffected
    End Function
    Shared Function GenerateSalary1(ByVal Prop As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(10) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@WD_InMonth", SqlDbType.Int)
        arParms(0).Value = Prop.WD_InMonth

        arParms(1) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(1).Value = Prop.Month

        arParms(2) = New SqlParameter("@PayDate", SqlDbType.DateTime)
        arParms(2).Value = Prop.PayDate

        arParms(3) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(3).Value = Prop.Year

        arParms(4) = New SqlParameter("@WorkDay", SqlDbType.Int)
        arParms(4).Value = Prop.WorkDays

        arParms(5) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(5).Value = HttpContext.Current.Session("Office")

        arParms(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("BranchCode")

        arParms(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("UserCode")

        arParms(8) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("EmpCode")

        arParms(9) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(9).Value = Prop.Dept

        arParms(10) = New SqlParameter("@MonthNo", SqlDbType.Int)
        arParms(10).Value = Prop.MonthNo


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_Payroll_Generate_Salary1", arParms)
        Catch e As Exception
        End Try
        Return rowsAffected
    End Function
   

    Shared Function updateloan(ByVal Prop As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.Int)
        arParms(3).Value = Prop.Empcode

        arParms(4) = New SqlParameter("@MD", SqlDbType.Money)
        arParms(4).Value = Prop.MA1

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateLoanInLoanMaster", arParms)
        Catch e As Exception
        End Try
        Return rowsAffected
    End Function
    Shared Function updateloan1(ByVal Prop As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.Int)
        arParms(3).Value = Prop.Empcode

        arParms(4) = New SqlParameter("@MD", SqlDbType.Money)
        arParms(4).Value = Prop.MA1

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateLoanInLoanMaster1", arParms)
        Catch e As Exception
        End Try
        Return rowsAffected
    End Function
    Shared Function RptSalSlip(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(4).Value = Prop.Dept

        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_PayRoll_SalarySlip", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function RptSalSlip2(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(4).Value = Prop.Dept

        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_PayRoll_SalarySlip2", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function GetLoanDetails(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Emp_Id", SqlDbType.Int)
        arParms(4).Value = Prop.EMPid

        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLoanDetailsFroEmp", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function RptSalSlip3(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(4).Value = Prop.Dept

        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_PayRoll_SalarySlip2", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function RptSalSlip4(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(4).Value = Prop.Dept

        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_PayRoll_SalarySlip4", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function GetPayrollRules(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Formula", SqlDbType.Int)
        arParms(2).Value = Prop.Formula

        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPayrollRules", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function GetAmount(ByVal Prop As ELPayrollRulesEngine) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(2).Value = Prop.Year

        arParms(3) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(3).Value = Prop.Month

        arParms(4) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(4).Value = Prop.iMS_id

        arParms(5) = New SqlParameter("@Field", SqlDbType.Int)
        arParms(5).Value = Prop.ItemField

        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAmountEaringDeduction", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function GetGrossNet(ByVal Prop As ELPayrollRulesEngine) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(2).Value = Prop.Year

        arParms(3) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(3).Value = Prop.Month

        arParms(4) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(4).Value = Prop.iMS_id

        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetAmountGrossNet", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function RptSalSlip1(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(4).Value = Prop.Dept

        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_PayRoll_SalarySlip1", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function SelectPF(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(4).Value = Prop.Dept

        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SelectPF", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function RptMySalSlip(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpID")


        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_PayRoll_MySalarySlip", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function RptMySalSlipRegister(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("EmpID")


        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetMonthlyPayroll1", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function DeleteSalary(ByVal Prop As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        Try
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_PayRoll_DeleteSalary1", arParms)
        Catch e As Exception
            MsgBox(e)
        End Try
    End Function
    Shared Function DeleteSalary1(ByVal Prop As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        Try
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_PayRoll_DeleteSalaryNew", arParms)
        Catch e As Exception
            MsgBox(e)
        End Try
    End Function
    Shared Function LockSalary(ByVal Prop As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Lock", SqlDbType.VarChar, Prop.Lock.Length)
        arParms(4).Value = Prop.Lock

        Try
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_PayRoll_LockOrUnlockMonthlySalary", arParms)
        Catch e As Exception
            MsgBox(e)
        End Try
    End Function
    Shared Function LockSalary1(ByVal Prop As EntPayroll) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Lock", SqlDbType.VarChar, Prop.Lock.Length)
        arParms(4).Value = Prop.Lock

        Try
            SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_PayRoll_LockOrUnlockMonthlySalaryNew", arParms)
        Catch e As Exception
            MsgBox(e)
        End Try
    End Function
    Shared Function LockStatus(ByVal Prop As EntPayroll) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim lock As String = ""
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(4).Value = Prop.Dept

        Try
            lock = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_PayRoll_LockCheckMonthlySalary", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return lock

    End Function
    Shared Function RptMySalSlipNew(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(4).Value = HttpContext.Current.Session("EmpID")


        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_MySalarySlip_New", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function RptMySalSlipNew1(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

      
        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_MySalarySlip_New1", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function RptMySalSlipNew2(ByVal Prop As EntPayroll) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")


        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_MySalarySlip_New2", arParms)
        Return DS.Tables(0)
    End Function
    Shared Function LockStatus1(ByVal Prop As EntPayroll) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim lock As String = ""
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, Prop.Month.Length)
        arParms(0).Value = Prop.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(1).Value = Prop.Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("BranchCode")

        arParms(4) = New SqlParameter("@Dept", SqlDbType.Int)
        arParms(4).Value = Prop.Dept

        Try
            lock = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "Proc_PayRoll_LockCheckMonthlySalary1", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return lock

    End Function

    'Commented by Nethra during Build 13-Apr-2012

    'Shared Function GetMonthlySalary(ByVal MSid As Long) As System.Data.DataSet
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet
    '    Try
    '        If HttpContext.Current.Session("UserRole") = 1 Then
    '            If MSid = 0 Then
    '                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select * from View_GetDataMonthlySalary where Institute_ID=" & HttpContext.Current.Session("InstituteID") & " and Branch_ID=" & HttpContext.Current.Session("BranchID"))
    '            Else
    '                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select * from View_GetDataMonthlySalary where MS_ID=" & MSid & " and Institute_ID=" & HttpContext.Current.Session("InstituteID") & " and Branch_ID=" & HttpContext.Current.Session("BranchID"))
    '            End If
    '        Else
    '            If MSid = 0 Then
    '                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select * from View_GetDataMonthlySalary where EMP_ID= " & HttpContext.Current.Session("EMPID") & " and Institute_ID=" & HttpContext.Current.Session("InstituteID") & " and Branch_ID=" & HttpContext.Current.Session("BranchID"))
    '            Else
    '                ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Select * from View_GetDataMonthlySalary where MS_ID=" & MSid & " and EMP_ID= " & HttpContext.Current.Session("EMPID") & " and Institute_ID=" & HttpContext.Current.Session("InstituteID") & " and Branch_ID=" & HttpContext.Current.Session("BranchID"))
    '            End If
    '        End If
    '    Catch e As Exception
    '        ds = New DataSet
    '    End Try
    '    Return ds
    'End Function
    'Shared Function Insert(ByVal i As EntMonthlySalary) As Integer
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim rowsAffected As Integer = 0

    '    Dim arParms() As SqlParameter = New SqlParameter(20) {}

    '    arParms(0) = New SqlParameter("@EMPID", SqlDbType.Int)
    '    arParms(0).Value = i.EMPid

    '    arParms(1) = New SqlParameter("@PaymentDate", SqlDbType.DateTime)
    '    arParms(1).Value = i.PaymentDate

    '    arParms(2) = New SqlParameter("@EntryDate", SqlDbType.DateTime)
    '    arParms(2).Value = i.EntryDate

    '    arParms(3) = New SqlParameter("@BasicPay", SqlDbType.Float)
    '    arParms(3).Value = i.BasicPay

    '    arParms(4) = New SqlParameter("@SpecialAllowance", SqlDbType.Float)
    '    arParms(4).Value = i.SpecialAllowance

    '    arParms(5) = New SqlParameter("@HRA", SqlDbType.Float)
    '    arParms(5).Value = i.HRA

    '    arParms(6) = New SqlParameter("@Medical", SqlDbType.Float)
    '    arParms(6).Value = i.Medical

    '    arParms(7) = New SqlParameter("@TransportAllowance", SqlDbType.Float)
    '    arParms(7).Value = i.TransportAllowance

    '    arParms(8) = New SqlParameter("@OtherAllowance", SqlDbType.Float)
    '    arParms(8).Value = i.OtherAllowance

    '    arParms(9) = New SqlParameter("@Incentives", SqlDbType.Float)
    '    arParms(9).Value = i.Incentives

    '    arParms(10) = New SqlParameter("@MiscellaneousPay", SqlDbType.Float)
    '    arParms(10).Value = i.MiscellaneousPay

    '    arParms(11) = New SqlParameter("@TaxDeduction", SqlDbType.Float)
    '    arParms(11).Value = i.TaxDeduction

    '    arParms(12) = New SqlParameter("@ITTaxDeduction", SqlDbType.Float)
    '    arParms(12).Value = i.ITTaxDeduction

    '    arParms(13) = New SqlParameter("@AdvStlDeduction", SqlDbType.Float)
    '    arParms(13).Value = i.AdvStlDeduction

    '    arParms(14) = New SqlParameter("@OtherDeduction", SqlDbType.Float)
    '    arParms(14).Value = i.OtherDeduction

    '    arParms(15) = New SqlParameter("@GrossSalary", SqlDbType.Money)
    '    arParms(15).Value = i.GrossSalary

    '    arParms(16) = New SqlParameter("@NetSalary", SqlDbType.Money)
    '    arParms(16).Value = i.NetSalary

    '    arParms(17) = New SqlParameter("@LOPay", SqlDbType.Float)
    '    arParms(17).Value = i.LOPay

    '    arParms(18) = New SqlParameter("@OtherPay", SqlDbType.Float)
    '    arParms(18).Value = i.OtherPay

    '    arParms(19) = New SqlParameter("@institute", SqlDbType.Int)
    '    arParms(19).Value = HttpContext.Current.Session("InstituteID")

    '    arParms(20) = New SqlParameter("@branch", SqlDbType.Int)
    '    arParms(20).Value = HttpContext.Current.Session("BranchID")
    '    Try
    '        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveMonthlySalary", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return rowsAffected
    'End Function
    Shared Function UpdatePF(ByVal Id As Double, ByVal PF As Double, ByVal Netsalary As Double) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = Id

        arParms(1) = New SqlParameter("@NetSalary", SqlDbType.Money)
        arParms(1).Value = Netsalary

        arParms(2) = New SqlParameter("@PF", SqlDbType.Money)
        arParms(2).Value = PF

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(3).Value = HttpContext.Current.Session("Office")

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdatePF", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    ''Commented by Nethra during Build 13-Apr-2012
    ''Shared Function UpdateGen_Salary(ByVal i As EntPayroll) As Integer
    ''    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    ''    Dim rowsAffected As Integer = 0

    ''    Dim arParms() As SqlParameter = New SqlParameter(17) {}

    ''    arParms(0) = New SqlParameter("@EMPID", SqlDbType.Int)
    ''    arParms(0).Value = i.EMPid

    ''    arParms(1) = New SqlParameter("@BasicPay", SqlDbType.Float)
    ''    arParms(1).Value = i.BasicPay

    ''    arParms(2) = New SqlParameter("@SpecialAllowance", SqlDbType.Float)
    ''    arParms(2).Value = i.SpecialAllowance

    ''    arParms(3) = New SqlParameter("@HRA", SqlDbType.Float)
    ''    arParms(3).Value = i.HRA

    ''    arParms(4) = New SqlParameter("@Medical", SqlDbType.Float)
    ''    arParms(4).Value = i.Medical

    ''    arParms(5) = New SqlParameter("@TransportAllowance", SqlDbType.Float)
    ''    arParms(5).Value = i.TransportAllowance

    ''    arParms(6) = New SqlParameter("@OtherAllowance", SqlDbType.Float)
    ''    arParms(6).Value = i.OtherAllowance

    ''    arParms(7) = New SqlParameter("@Incentives", SqlDbType.Float)
    ''    arParms(7).Value = i.Incentive

    ''    arParms(8) = New SqlParameter("@MiscellaneousPay", SqlDbType.Float)
    ''    arParms(8).Value = i.MiscellaneousPay

    ''    arParms(9) = New SqlParameter("@TaxDeduction", SqlDbType.Float)
    ''    arParms(9).Value = i.TaxDeduction

    ''    arParms(10) = New SqlParameter("@ITTaxDeduction", SqlDbType.Float)
    ''    arParms(10).Value = i.ITTaxDeduction

    ''    arParms(11) = New SqlParameter("@AdvStlDeduction", SqlDbType.Float)
    ''    arParms(11).Value = i.AdvStdDedu

    ''    arParms(12) = New SqlParameter("@OtherDeduction", SqlDbType.Float)
    ''    arParms(12).Value = i.OtherAllowance

    ''    arParms(13) = New SqlParameter("@GrossSalary", SqlDbType.Money)
    ''    arParms(13).Value = i.GrossSalary

    ''    arParms(14) = New SqlParameter("@NetSalary", SqlDbType.Money)
    ''    arParms(14).Value = i.NetSalary

    ''    arParms(15) = New SqlParameter("@LOPay", SqlDbType.Float)
    ''    arParms(15).Value = i.LOP

    ''    arParms(16) = New SqlParameter("@OtherPay", SqlDbType.Float)
    ''    arParms(16).Value = i.OtherPay

    ''    arParms(17) = New SqlParameter("@MSid", SqlDbType.Int)
    ''    arParms(17).Value = i.MS_id

    ''    Try
    ''        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateMonthlySalary_Gen", arParms)
    ''    Catch ex As Exception
    ''        MsgBox(ex.ToString)
    ''    End Try
    ''    Return rowsAffected
    ''End Function
    'Shared Function ChangeFlag(ByVal Id As Long) As Integer
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim rowsAffected As Integer = 0
    '    Dim arParms As SqlParameter = New SqlParameter

    '    arParms = New SqlParameter("@MSid", SqlDbType.BigInt)
    '    arParms.Value = Id
    '    Try
    '        rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteMonthlySalary", arParms)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return rowsAffected
    'End Function
    'Public Function GetMonthly_Details() As Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet
    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select * from Qry_Calculation  where Institute_ID=" & HttpContext.Current.Session("InstituteID") & " and Branch_ID=" & HttpContext.Current.Session("BranchID"))
    '    Catch e As Exception
    '        ds = New DataSet
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    'Public Sub Delete()
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    SqlHelper.ExecuteNonQuery(connectionString, CommandType.Text, "Delete  From Month_Details_Payroll")
    'End Sub

    'Public Function ChkGenSal(ByVal Prop As EntPayroll) As Boolean
    '    Dim Bool As Boolean
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet
    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "SELECT DISTINCT BasicPay FROM MonthlySalary WHERE MonthNo=" & Prop.Month & " AND Year=" & Prop.Year)
    '        If ds.Tables(0).Rows.Count > 0 Then
    '            Bool = False
    '        Else
    '            Bool = True
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return Bool
    'End Function

    'Public Function GetMonthlySalary(ByVal prop As EntPayroll) As Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet
    '    Dim arParms() As SqlParameter = New SqlParameter(3) {}

    '    arParms(0) = New SqlParameter("@institute", SqlDbType.Int)
    '    arParms(0).Value = HttpContext.Current.Session("InstituteID")

    '    arParms(1) = New SqlParameter("@branch", SqlDbType.Int)
    '    arParms(1).Value = HttpContext.Current.Session("BranchID")

    '    arParms(2) = New SqlParameter("@Month", SqlDbType.Int)
    '    arParms(2).Value = prop.Month

    '    arParms(3) = New SqlParameter("@Year", SqlDbType.Int)
    '    arParms(3).Value = prop.Year
    '    ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Get_Qry_MonthlySalary", arParms)
    '    'ds = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "select * from View_Qry_MonthlySalary where MonthNo=" & prop.Month & " and Year=" & prop.Year & " and Institute_ID=" & HttpContext.Current.Session("InstituteID") & " and Branch_ID=" & HttpContext.Current.Session("BranchID"))
    '    Return ds.Tables(0)
    'End Function
    'Shared Function GetInstBrch(ByVal E_ID As Long) As System.Data.DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As DataSet
    '    Dim arParms() As SqlParameter = New SqlParameter(0) {}

    '    arParms(0) = New SqlParameter("@E_ID", SqlDbType.Int)
    '    arParms(0).Value = E_ID

    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetMonthlyPayrollId", arParms)
    '    Catch e As Exception
    '        ds = New DataSet
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    'Shared Function DelMonthlyDetPayroll(ByVal E_ID As Long)
    'Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    SqlHelper.ExecuteDataset(connectionString, CommandType.Text, "Delete from Month_Details_Payroll where E_ID= " & E_ID)
    'End Function
    Shared Function Salaryslip() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim DS As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        DS = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_salaryslip", arParms)
        Return DS.Tables(0)
    End Function
End Class
Namespace GlobalDataSetTableAdapters
    'Partial Public Class Month_Details_PayrollTableAdapter
    '    Dim dt As Data.DataTable
    '    Dim str As String
    '    ' Dim da As OleDb.OleDbDataAdapter
    '    Private _transaction As SqlTransaction
    '    Private Property Transaction() As SqlClient.SqlTransaction
    '        Get
    '            Return Me._transaction
    '        End Get
    '        Set(ByVal Value As SqlTransaction)
    '            Me._transaction = Value
    '        End Set
    '    End Property
    '    'Public Sub BeginTransaction()
    '    '    ' Open the connection, if needed
    '    '    If Me.Connection.State <> ConnectionState.Open Then
    '    '        Me.Connection.Open()
    '    '    End If
    '    '    ' Create the transaction and assign it to the Transaction property
    '    '    Me.Transaction = Me.Connection.BeginTransaction()
    '    '    ' Attach the transaction to the Adapters
    '    '    For Each command As SqlCommand In Me.CommandCollection
    '    '        command.Transaction = Me.Transaction
    '    '    Next
    '    '    Me.Adapter.InsertCommand.Transaction = Me.Transaction
    '    '    Me.Adapter.UpdateCommand.Transaction = Me.Transaction
    '    '    Me.Adapter.DeleteCommand.Transaction = Me.Transaction
    '    'End Sub
    '    'Public Sub CommitTransaction()
    '    '    ' Commit the transaction
    '    '    Me.Transaction.Commit()
    '    '    ' Close the connection
    '    '    Me.Connection.Close()
    '    'End Sub
    '    'Public Sub RollbackTransaction()
    '    '    ' Rollback the transaction
    '    '    Me.Transaction.Rollback()
    '    '    ' Close the connection
    '    '    Me.Connection.Close()
    '    'End Sub
    '    'Public Function UpdateWithTransaction(ByVal dataTable As GlobalDataSet.Month_Details_PayrollDataTable) As Integer
    '    '    Me.BeginTransaction()
    '    '    Try                ' Perform the update on the DataTable
    '    '        Dim returnValue As Integer = Me.Adapter.Update(dataTable)
    '    '        ' If we reach here, no errors, so commit the transaction
    '    '        Me.CommitTransaction()
    '    '        Return returnValue
    '    '    Catch
    '    '        ' If we reach here, there was an error, so rollback the transaction
    '    '        Me.RollbackTransaction()
    '    '        Throw
    '    '    End Try
    '    'End Function
    'End Class

End Namespace