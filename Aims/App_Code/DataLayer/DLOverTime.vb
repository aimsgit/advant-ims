Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.IO

Public Class DLOverTime
    Shared Function GetDepartment() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "ddlDeptOT", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDepartmentF() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "ddlDeptOTF", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Shared Function GetEmpCodeCombo(ByVal DeptId As String) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Para(2) = New SqlParameter("@DeptId", SqlDbType.VarChar, 50)
        Para(2).Value = DeptId
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "ddlEmpOverTime", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function AutoGenerateNo(ByVal EL As ELOverTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        para(2).Value = EL.EmpNo

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlEmpOT", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function InsertRecordOT(ByVal El As ELOverTime) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(13) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(0).Value = El.Month


        arParms(1) = New SqlParameter("@DeptName", SqlDbType.Int)
        arParms(1).Value = El.DeptName


        arParms(2) = New SqlParameter("@BasicSal", SqlDbType.Money)
        arParms(2).Value = El.BasicSal

        arParms(3) = New SqlParameter("@EmpName", SqlDbType.VarChar, 200)
        arParms(3).Value = El.EmpName

        arParms(4) = New SqlParameter("@EmpNo", SqlDbType.Int)
        arParms(4).Value = El.EmpNo

        arParms(5) = New SqlParameter("@OTRate", SqlDbType.Float)
        arParms(5).Value = El.OTRate

        arParms(6) = New SqlParameter("@VoucherNo", SqlDbType.VarChar, 200)
        arParms(6).Value = El.VoucherNo

        arParms(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        arParms(9) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("BranchCode")

        arParms(10) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("Office")

        arParms(11) = New SqlParameter("@TotalAmount", SqlDbType.Money)
        arParms(11).Value = El.TotAmount

        arParms(12) = New SqlParameter("@NoOfHours", SqlDbType.Int)
        arParms(12).Value = El.NoOfHours

        arParms(13) = New SqlParameter("@NoOfMinutes", SqlDbType.Int)
        arParms(13).Value = El.NoOfMinutes


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertOT", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetGridDataOT(ByVal EL As ELOverTime) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = EL.ID

        arParms(3) = New SqlParameter("@EmpNo", SqlDbType.VarChar, 50)
        arParms(3).Value = EL.EmpNo

        arParms(4) = New SqlParameter("@DeptName", SqlDbType.Int)
        arParms(4).Value = EL.DeptName



        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDetailOT", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function UpdateOT(ByVal El As ELOverTime) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(14) {}

        arParms(0) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(0).Value = El.Month


        arParms(1) = New SqlParameter("@DeptName", SqlDbType.Int)
        arParms(1).Value = El.DeptName


        arParms(2) = New SqlParameter("@BasicSal", SqlDbType.Money)
        arParms(2).Value = El.BasicSal

        arParms(3) = New SqlParameter("@EmpName", SqlDbType.VarChar, 200)
        arParms(3).Value = El.EmpName

        arParms(4) = New SqlParameter("@EmpNo", SqlDbType.Int)
        arParms(4).Value = El.EmpNo

        arParms(5) = New SqlParameter("@OTRate", SqlDbType.Float)
        arParms(5).Value = El.OTRate

        arParms(6) = New SqlParameter("@VoucherNo", SqlDbType.VarChar, 200)
        arParms(6).Value = El.VoucherNo



        arParms(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("EmpCode")

        arParms(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("UserCode")

        arParms(9) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(9).Value = HttpContext.Current.Session("BranchCode")

        arParms(10) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(10).Value = HttpContext.Current.Session("Office")

        arParms(11) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(11).Value = El.ID

        arParms(12) = New SqlParameter("@TotalAmount", SqlDbType.Money)
        arParms(12).Value = El.TotAmount

        arParms(13) = New SqlParameter("@NoOfHours", SqlDbType.Int)
        arParms(13).Value = El.NoOfHours

        arParms(14) = New SqlParameter("@NoOfMinutes", SqlDbType.Int)
        arParms(14).Value = El.NoOfMinutes
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateOT", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function ChangeFlagOT(ByVal EL As ELOverTime) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(0).Value = EL.ID

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteOTDetail", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetDupplicateOT(ByVal El As ELOverTime) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@VoucherNo", SqlDbType.VarChar, 50)
        arParms(2).Value = El.VoucherNo

        arParms(3) = New SqlParameter("@EmpName", SqlDbType.VarChar, 200)
        arParms(3).Value = El.EmpName

        arParms(4) = New SqlParameter("@EmpNo", SqlDbType.Int)
        arParms(4).Value = El.EmpNo

        arParms(5) = New SqlParameter("@OTRate", SqlDbType.Float)
        arParms(5).Value = El.OTRate


        arParms(6) = New SqlParameter("@id", SqlDbType.Int)
        arParms(6).Value = El.ID

        arParms(7) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(7).Value = El.Month
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDuplicateOT", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDepartmentR() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "ddlDeptOT", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetEmpNameR(ByVal DeptId As String) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Para(2) = New SqlParameter("@DeptId", SqlDbType.VarChar, 50)
        Para(2).Value = DeptId
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "ddlEmpNameOverTime", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetOverTimeEntryR(ByVal DeptId As Integer, ByVal EmpId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@DeptId", SqlDbType.Int)
        arParms(2).Value = DeptId
        arParms(3) = New SqlParameter("@EmpId", SqlDbType.Int)
        arParms(3).Value = EmpId


        arParms(4) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        arParms(4).Value = fromdate

        arParms(5) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(5).Value = todate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptOverTimeEnrtyR", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function AutoGenerateNo1(ByVal EL As LoanSettlementEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        para(2).Value = EL.EmpNo

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "ddlEmpOT", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function AutoGenerateLoanDetails(ByVal EL As LoanSettlementEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@EmpCode", SqlDbType.Int)
        para(2).Value = EL.EmpNo
        para(3) = New SqlParameter("@LoanTypeCode", SqlDbType.Int)
        para(3).Value = EL.LoanTypeCode

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLoanDetailsAuto", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function UpdateLoanSettlement(ByVal El As LoanSettlementEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@EmpNo", SqlDbType.Int)
        arParms(0).Value = El.EmpNo
        arParms(1) = New SqlParameter("@LoanTypeCode", SqlDbType.Int)
        arParms(1).Value = El.LoanTypeCode


        arParms(2) = New SqlParameter("@SType", SqlDbType.VarChar, 50)
        arParms(2).Value = El.SType

        arParms(3) = New SqlParameter("@SMethod", SqlDbType.VarChar, 200)
        arParms(3).Value = El.SMethod

        arParms(4) = New SqlParameter("@NoOfInstallment", SqlDbType.Int)
        arParms(4).Value = El.NoOfInstl


        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        arParms(8) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("Office")

        arParms(9) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(9).Value = El.ID
        arParms(10) = New SqlParameter("@SDate", SqlDbType.Date)
        arParms(10).Value = El.LoanSettlementDate
        arParms(11) = New SqlParameter("@SAmount", SqlDbType.Money)
        arParms(11).Value = El.SAmount

       
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateLoanSettlement", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function getRecords(ByVal id As LoanSettlementEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = id.ID

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 30)
        arParms(3).Value = id.EmpNo

        arParms(4) = New SqlParameter("@LoanNo", SqlDbType.VarChar, 30)
        arParms(4).Value = id.LoanTypeCode

        arParms(5) = New SqlParameter("@SMethod", SqlDbType.VarChar, 200)
        arParms(5).Value = id.SMethod

        arParms(6) = New SqlParameter("@SType", SqlDbType.VarChar, 50)
        arParms(6).Value = id.SType
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLoanSettlementRecord", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function InsertLoanSettlement(ByVal El As LoanSettlementEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(11) {}

        arParms(0) = New SqlParameter("@EmpNo", SqlDbType.Int)
        arParms(0).Value = El.EmpNo
        arParms(1) = New SqlParameter("@LoanTypeCode", SqlDbType.Int)
        arParms(1).Value = El.LoanTypeCode


        arParms(2) = New SqlParameter("@SType", SqlDbType.VarChar, 50)
        arParms(2).Value = El.SType

        arParms(3) = New SqlParameter("@SMethod", SqlDbType.VarChar, 200)
        arParms(3).Value = El.SMethod

        arParms(4) = New SqlParameter("@NoOfInstallment", SqlDbType.Int)
        arParms(4).Value = El.NoOfInstl


        arParms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("EmpCode")

        arParms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("UserCode")

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        arParms(8) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(8).Value = HttpContext.Current.Session("Office")

        arParms(9) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(9).Value = El.ID
        arParms(10) = New SqlParameter("@SDate", SqlDbType.Date)
        arParms(10).Value = El.LoanSettlementDate
        arParms(11) = New SqlParameter("@SAmount", SqlDbType.Money)
        arParms(11).Value = El.SAmount


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_InsertLoanSettlement", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function AutoGenerateSType(ByVal EL As LoanSettlementEL) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")
        para(2) = New SqlParameter("@EmpCode", SqlDbType.Int)
        para(2).Value = EL.EmpNo
        para(3) = New SqlParameter("@LoanTypeCode", SqlDbType.Int)
        para(3).Value = EL.LoanTypeCode

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetLoanBalanceAuto", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDistributionOfGrdVsSub(ByVal Course As Integer, ByVal Semester As Integer, ByVal AssesmentType As Integer, ByVal branch As String, ByVal AcdYear As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(2).Value = Course
        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = Semester

        arParms(4) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        arParms(4).Value = AssesmentType
        arParms(5) = New SqlParameter("@Branch", SqlDbType.VarChar, 50)
        arParms(5).Value = branch
        arParms(6) = New SqlParameter("@AcademicYear", SqlDbType.Int)
        arParms(6).Value = AcdYear

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_DistributionOfGrade", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetDupplicateVoucher(ByVal El As ELOverTime) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@VoucherNo", SqlDbType.VarChar, 50)
        arParms(2).Value = El.VoucherNo

        arParms(3) = New SqlParameter("@EmpName", SqlDbType.VarChar, 200)
        arParms(3).Value = El.EmpName

        arParms(4) = New SqlParameter("@EmpNo", SqlDbType.Int)
        arParms(4).Value = El.EmpNo

        arParms(5) = New SqlParameter("@OTRate", SqlDbType.Float)
        arParms(5).Value = El.OTRate


        arParms(6) = New SqlParameter("@id", SqlDbType.Int)
        arParms(6).Value = El.ID

        arParms(7) = New SqlParameter("@Month", SqlDbType.VarChar, 50)
        arParms(7).Value = El.Month
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetDuplicateVoucher", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
