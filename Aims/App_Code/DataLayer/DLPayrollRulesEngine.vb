Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Data.SqlClient
Public Class DLPayrollRulesEngine

    Shared Function EarningDeduction() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EarningDeduction", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function EarningDeduction1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_EarningDeduction1", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function Update1(ByVal EL As ELPayrollRulesEngine) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(10) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@Field", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.Field

        arParms(1) = New SqlParameter("@Fixed", SqlDbType.Int)
        arParms(1).Value = EL.Fixed

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        arParms(5).Value = EL.iMS_id

        arParms(6) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(6).Value = EL.Month

        arParms(7) = New SqlParameter("@Year", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.Year

        arParms(8) = New SqlParameter("@Grade", SqlDbType.Int)
        arParms(8).Value = EL.Grade

        arParms(9) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("Office")

        arParms(10) = New SqlParameter("@MonthNo", SqlDbType.VarChar, 50)
        arParms(10).Value = EL.MonthNo


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_Payroll_Generate_Salary2", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal EL As ELPayrollRulesEngine) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@Field", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.Field

        arParms(1) = New SqlParameter("@Fixed", SqlDbType.Int)
        arParms(1).Value = EL.Fixed

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        arParms(5).Value = EL.iMS_id

        arParms(6) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(6).Value = EL.Month

        arParms(7) = New SqlParameter("@Year", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.Year

        arParms(8) = New SqlParameter("@Grade", SqlDbType.Int)
        arParms(8).Value = EL.Grade


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdatePayrollRulesEngine", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function clearupdate(ByVal EL As ELPayrollRulesEngine) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@Field", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.Field

        arParms(1) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.Month

        arParms(2) = New SqlParameter("@Year", SqlDbType.VarChar, 50)
        arParms(2).Value = EL.Year

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_ClearPayrollRulesEngine", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function updateNetGross(ByVal EL As ELPayrollRulesEngine) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.Year

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        arParms(5).Value = EL.iMS_id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_updateNetGross", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function updateNetGross1(ByVal EL As ELPayrollRulesEngine) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.Year

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        arParms(5).Value = EL.iMS_id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_updateNetGross1", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function SaveFormula(ByVal EL As ELPayrollRulesEngine) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(19) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.Year

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@SelectOption", SqlDbType.VarChar, 50)
        arParms(5).Value = EL.SelectOption

        arParms(6) = New SqlParameter("@Fixed", SqlDbType.Money)
        arParms(6).Value = EL.Fixed

        arParms(7) = New SqlParameter("@Field", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.Field

        arParms(8) = New SqlParameter("@OnGross", SqlDbType.Money)
        arParms(8).Value = EL.OnGross

        arParms(9) = New SqlParameter("@OnNet", SqlDbType.Money)
        arParms(9).Value = EL.OnNet

        arParms(10) = New SqlParameter("@ItemField", SqlDbType.VarChar, 50)
        arParms(10).Value = EL.ItemField

        arParms(11) = New SqlParameter("@ItemValue", SqlDbType.Money)
        arParms(11).Value = EL.ItemValue

        arParms(12) = New SqlParameter("@Criteria", SqlDbType.VarChar, 2)
        arParms(12).Value = EL.Criteria

        arParms(13) = New SqlParameter("@CriteriaField", SqlDbType.VarChar, 50)
        arParms(13).Value = EL.CriteriaField

        arParms(14) = New SqlParameter("@Criteria1", SqlDbType.VarChar, 50)
        arParms(14).Value = EL.Criteria1

        arParms(15) = New SqlParameter("@Criteria2", SqlDbType.VarChar, 50)
        arParms(15).Value = EL.Criteria2

        arParms(16) = New SqlParameter("@CriteriaV1", SqlDbType.Money)
        arParms(16).Value = EL.CriteriaV1

        arParms(17) = New SqlParameter("@CriteriaV2", SqlDbType.Money)
        arParms(17).Value = EL.CriteriaV2

        arParms(18) = New SqlParameter("@FormulaGroup", SqlDbType.Int)
        arParms(18).Value = EL.Fromula

        arParms(19) = New SqlParameter("@Grade", SqlDbType.Int)
        arParms(19).Value = EL.Grade

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_saveFormulaPayrollRules", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateFormula(ByVal EL As ELPayrollRulesEngine) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(20) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.Year

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@SelectOption", SqlDbType.VarChar, 50)
        arParms(5).Value = EL.SelectOption

        arParms(6) = New SqlParameter("@Fixed", SqlDbType.Money)
        arParms(6).Value = EL.Fixed

        arParms(7) = New SqlParameter("@Field", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.Field

        arParms(8) = New SqlParameter("@OnGross", SqlDbType.Money)
        arParms(8).Value = EL.OnGross

        arParms(9) = New SqlParameter("@OnNet", SqlDbType.Money)
        arParms(9).Value = EL.OnNet

        arParms(10) = New SqlParameter("@ItemField", SqlDbType.VarChar, 50)
        arParms(10).Value = EL.ItemField

        arParms(11) = New SqlParameter("@ItemValue", SqlDbType.Money)
        arParms(11).Value = EL.ItemValue

        arParms(12) = New SqlParameter("@Criteria", SqlDbType.VarChar, 2)
        arParms(12).Value = EL.Criteria

        arParms(13) = New SqlParameter("@CriteriaField", SqlDbType.VarChar, 50)
        arParms(13).Value = EL.CriteriaField

        arParms(14) = New SqlParameter("@Criteria1", SqlDbType.VarChar, 50)
        arParms(14).Value = EL.Criteria1

        arParms(15) = New SqlParameter("@Criteria2", SqlDbType.VarChar, 50)
        arParms(15).Value = EL.Criteria2

        arParms(16) = New SqlParameter("@CriteriaV1", SqlDbType.Money)
        arParms(16).Value = EL.CriteriaV1

        arParms(17) = New SqlParameter("@CriteriaV2", SqlDbType.Money)
        arParms(17).Value = EL.CriteriaV2

        arParms(18) = New SqlParameter("@Id", SqlDbType.Money)
        arParms(18).Value = EL.iMS_id

        arParms(19) = New SqlParameter("@FormulaGroup", SqlDbType.Int)
        arParms(19).Value = EL.Fromula

        arParms(20) = New SqlParameter("@Grade", SqlDbType.Int)
        arParms(20).Value = EL.Grade

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateFormulaPayrollRules", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Public Sub delete(ByVal EL As ELPayrollRulesEngine)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms As SqlParameter = New SqlParameter
        arParms = New SqlParameter("@Id", SqlDbType.Int)
        arParms.Value = EL.iMS_id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeletePayrollrules", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Shared Function updateMonthPayClear(ByVal EL As ELPayrollRulesEngine) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.Month

        arParms(1) = New SqlParameter("@Year", SqlDbType.VarChar, 50)
        arParms(1).Value = EL.Year

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("BranchCode")

        arParms(5) = New SqlParameter("@id", SqlDbType.Int)
        arParms(5).Value = EL.iMS_id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_updateClearRun_MonthPay", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    
End Class
