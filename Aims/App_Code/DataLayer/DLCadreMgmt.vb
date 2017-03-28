Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLCadreMgmt
    'Shared Function GetCapacityPlan(ByVal EL As ELCadreMgmt) As DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim dt As New DataTable
    '    Dim arParms() As SqlParameter = New SqlParameter(3) {}
    '    arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '    arParms(0).Value = HttpContext.Current.Session("Office")

    '    arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    arParms(1).Value = HttpContext.Current.Session("BranchCode")

    '    arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
    '    arParms(2).Value = EL.Id

    '    arParms(3) = New SqlParameter("@Dept", SqlDbType.Int)
    '    arParms(3).Value = EL.Dept
    '    Try
    '        Dim ds As DataSet
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCadreMgmt", arParms)
    '        dt = ds.Tables(0)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try

    '    Return dt
    'End Function
    Shared Function Insert(ByVal EL As ELCadreMgmt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(14) {}


        arParms(0) = New SqlParameter("@University", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.University

        arParms(1) = New SqlParameter("@Program", SqlDbType.Int)
        arParms(1).Value = EL.Program

        arParms(2) = New SqlParameter("@Project", SqlDbType.Int)
        arParms(2).Value = EL.Project

        arParms(3) = New SqlParameter("@Department", SqlDbType.VarChar, 250)
        arParms(3).Value = EL.Department

        arParms(4) = New SqlParameter("@SalaryCode", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.SalaryCode

        arParms(5) = New SqlParameter("@Designation", SqlDbType.Int)
        arParms(5).Value = EL.Designation

        arParms(6) = New SqlParameter("@ApprovedYear", SqlDbType.VarChar, 50)
        arParms(6).Value = EL.ApprovedYear

        arParms(7) = New SqlParameter("@ApprovedNo", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.ApprovedNo

        arParms(8) = New SqlParameter("@RequiredYear", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.RequiredYear

        arParms(9) = New SqlParameter("@RequiredNo", SqlDbType.VarChar, 50)
        arParms(9).Value = EL.RequiredNo

        arParms(10) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(10).Value = EL.Remarks

        arParms(11) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("EmpCode")

        arParms(12) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("UserCode")

        arParms(13) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(13).Value = HttpContext.Current.Session("BranchCode")

        arParms(14) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        arParms(14).Value = HttpContext.Current.Session("Office")



        Try


            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_SaveCadreManagement", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function Update(ByVal EL As ELCadreMgmt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(15) {}

        arParms(0) = New SqlParameter("@University", SqlDbType.VarChar, 50)
        arParms(0).Value = EL.University

        arParms(1) = New SqlParameter("@Program", SqlDbType.Int)
        arParms(1).Value = EL.Program

        arParms(2) = New SqlParameter("@Project", SqlDbType.Int)
        arParms(2).Value = EL.Project

        arParms(3) = New SqlParameter("@Department", SqlDbType.VarChar, 250)
        arParms(3).Value = EL.Department

        arParms(4) = New SqlParameter("@SalaryCode", SqlDbType.VarChar, 50)
        arParms(4).Value = EL.SalaryCode

        arParms(5) = New SqlParameter("@Designation", SqlDbType.Int)
        arParms(5).Value = EL.Designation

        arParms(6) = New SqlParameter("@ApprovedYear", SqlDbType.VarChar, 50)
        arParms(6).Value = EL.ApprovedYear

        arParms(7) = New SqlParameter("@ApprovedNo", SqlDbType.VarChar, 50)
        arParms(7).Value = EL.ApprovedNo

        arParms(8) = New SqlParameter("@RequiredYear", SqlDbType.VarChar, 50)
        arParms(8).Value = EL.RequiredYear

        arParms(9) = New SqlParameter("@RequiredNo", SqlDbType.VarChar, 50)
        arParms(9).Value = EL.RequiredNo

        arParms(10) = New SqlParameter("@Remarks", SqlDbType.VarChar, 250)
        arParms(10).Value = EL.Remarks

        arParms(11) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(11).Value = HttpContext.Current.Session("EmpCode")

        arParms(12) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(12).Value = HttpContext.Current.Session("UserCode")

        arParms(13) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(13).Value = HttpContext.Current.Session("BranchCode")

        arParms(14) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
        arParms(14).Value = HttpContext.Current.Session("Office")


        arParms(15) = New SqlParameter("@CadreID", SqlDbType.Int)
        arParms(15).Value = EL.Id



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateCadreMgmtNew", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChangeFlag(ByVal EL As ELCadreMgmt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = EL.Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("EmpCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_DeleteCadreMgmtNew", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function ChkLockSummaryId(ByVal El As ELCadreMgmt) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Dt As DataSet
        Try
            Dim Para() As SqlParameter = New SqlParameter(2) {}

            Para(0) = New SqlParameter("@id", SqlDbType.Int)
            Para(0).Value = El.Id

            Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(2).Value = HttpContext.Current.Session("BranchCode")

            Dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_CheckLockCadreMgmtId]", Para)
            Return Dt
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function CheckDuplicate(ByVal EL As ELCadreMgmt) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(2) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")
        Para(1) = New SqlParameter("@ProgramID", SqlDbType.Int)
        Para(1).Value = EL.Program
        Para(2) = New SqlParameter("@Projectid", SqlDbType.Int)
        Para(2).Value = EL.Project

        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "proc_getCadreMgmtDup", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function insertBranchCombo_CadreMgmtRpt() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectBranchComboAll", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function insertBranchCombo_CadreMgmt() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectBranchComboAll", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function insertPrgm_CadreMgmt() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectPrgm_CadreMgmt", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function DDLPrgmCombo() As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectPrgm_CadreMgmt", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function DDLPrgmComboRpt() As DataTable
        '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Office")

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectPrgm_CadreMgmtGrid", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function DDLProjCombo(ByVal Program As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@ProgramID", SqlDbType.Int)
            arParms(0).Value = Program

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectProj_CadreMgmt", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function

    Public Function DDLProjComborpt(ByVal Program As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@ProgramID", SqlDbType.Int)
            arParms(0).Value = Program

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectProj_CadreMgmtddl", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    'Shared Function DDLDeptComborpt() As DataTable
    '    '24-11-2010 Kusum.C.Akki. Function for Inserting the data into DDL
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Try
    '        Dim arParms() As SqlParameter = New SqlParameter(1) {}

    '        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '        arParms(0).Value = HttpContext.Current.Session("Office")

    '        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '        arParms(1).Value = HttpContext.Current.Session("BranchCode")


    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectDept_CadreMgmtGrid", arParms)

    '        Return ds.Tables(0)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    'End Function


    Public Function DDLDesigCombo(ByVal SalaryCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@salarycode", SqlDbType.VarChar, 100)
            arParms(0).Value = SalaryCode

            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")

            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSalaryCodeDesignation", arParms)

            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function ApproveToCadre(ByVal EL As ELCadreMgmt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@PostCode ", SqlDbType.NVarChar, 4000)
        arParms(3).Value = EL.ChkID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "ApproveCadreChk", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function LockToCadre(ByVal EL As ELCadreMgmt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@PostCode ", SqlDbType.NVarChar, 4000)
        arParms(3).Value = EL.ChkID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "LockCadreChk", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UnLockToCadre(ByVal EL As ELCadreMgmt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        Dim rowsAffected As Integer = 0

        arParms(0) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("UserCode")
        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")
        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")
        arParms(3) = New SqlParameter("@PostCode ", SqlDbType.NVarChar, 4000)
        arParms(3).Value = EL.ChkID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "UnLockCadreChk", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetCadreMgmt(ByVal EL As ELCadreMgmt) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(7) {}
        Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("BranchCode")

        Para(1) = New SqlParameter("@CadreMgmtId", SqlDbType.Int)
        Para(1).Value = EL.Id
        ''Para(1).Value = HttpContext.Current.Session("Emp_Id")

        Para(2) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        Para(2).Value = HttpContext.Current.Session("Office")

        Para(3) = New SqlParameter("@University", SqlDbType.VarChar, 50)
        Para(3).Value = EL.University

        Para(4) = New SqlParameter("@Program", SqlDbType.Int)
        Para(4).Value = EL.Program

        Para(5) = New SqlParameter("@Project", SqlDbType.Int)
        Para(5).Value = EL.Project

        Para(6) = New SqlParameter("@Dept", SqlDbType.VarChar, 250)
        Para(6).Value = EL.Department

        Para(7) = New SqlParameter("@SalaryCode", SqlDbType.VarChar, 50)
        Para(7).Value = EL.SalaryCode


        'Para(8) = New SqlParameter("@designation", SqlDbType.VarChar, 50)
        'Para(8).Value = EL.Designation


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCadreMgmtGridForm234", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function ChkLockSummary(ByVal El As ELCadreMgmt) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Dt As DataSet
        Try
            Dim Para() As SqlParameter = New SqlParameter(6) {}


            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@University", SqlDbType.VarChar, 50)
            Para(2).Value = El.University

            Para(3) = New SqlParameter("@Program", SqlDbType.Int)
            Para(3).Value = El.Program

            Para(4) = New SqlParameter("@Project", SqlDbType.Int)
            Para(4).Value = El.Project

            Para(5) = New SqlParameter("@Dept", SqlDbType.VarChar, 250)
            Para(5).Value = El.Department

            Para(6) = New SqlParameter("@SalaryCode", SqlDbType.VarChar, 50)
            Para(6).Value = El.SalaryCode


            Dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_CheckLockCadreMgmt]", Para)
            Return Dt
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function ChkLockSummary1(ByVal El As ELCadreMgmt) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Dt As DataSet
        Try
            Dim Para() As SqlParameter = New SqlParameter(6) {}


            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@University", SqlDbType.VarChar, 50)
            Para(2).Value = El.University

            Para(3) = New SqlParameter("@Program", SqlDbType.Int)
            Para(3).Value = El.Program

            Para(4) = New SqlParameter("@Project", SqlDbType.Int)
            Para(4).Value = El.Project

            Para(5) = New SqlParameter("@Dept", SqlDbType.VarChar, 250)
            Para(5).Value = El.Department

            Para(6) = New SqlParameter("@SalaryCode", SqlDbType.VarChar, 50)
            Para(6).Value = El.SalaryCode


            Dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_CheckLockCadreMgmt1]", Para)
            Return Dt
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function ChkLockSummary2(ByVal El As ELCadreMgmt) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Dt As DataSet
        Try
            Dim Para() As SqlParameter = New SqlParameter(6) {}


            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@University", SqlDbType.VarChar, 50)
            Para(2).Value = El.University

            Para(3) = New SqlParameter("@Program", SqlDbType.Int)
            Para(3).Value = El.Program

            Para(4) = New SqlParameter("@Project", SqlDbType.Int)
            Para(4).Value = El.Project

            Para(5) = New SqlParameter("@Dept", SqlDbType.VarChar, 250)
            Para(5).Value = El.Department

            Para(6) = New SqlParameter("@SalaryCode", SqlDbType.VarChar, 50)
            Para(6).Value = El.SalaryCode


            Dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_CheckLockCadreMgmt2]", Para)
            Return Dt
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function ChkApproveStatus(ByVal El As ELCadreMgmt) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Dt As DataSet
        Try
            Dim Para() As SqlParameter = New SqlParameter(6) {}


            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@University", SqlDbType.VarChar, 50)
            Para(2).Value = El.University

            Para(3) = New SqlParameter("@Program", SqlDbType.Int)
            Para(3).Value = El.Program

            Para(4) = New SqlParameter("@Project", SqlDbType.Int)
            Para(4).Value = El.Project

            Para(5) = New SqlParameter("@Dept", SqlDbType.VarChar, 250)
            Para(5).Value = El.Department

            Para(6) = New SqlParameter("@SalaryCode", SqlDbType.VarChar, 50)
            Para(6).Value = El.SalaryCode


            Dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_CheckApproveStatus]", Para)
            Return Dt
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function ChkApproveStatusChk(ByVal El As ELCadreMgmt) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Dt As DataSet
        Try
            Dim Para() As SqlParameter = New SqlParameter(2) {}


            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@ID", SqlDbType.BigInt)
            Para(2).Value = El.ChkID

            Dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_CheckApproveStatusChk]", Para)
            Return Dt
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function ChkLockStatusChk(ByVal El As ELCadreMgmt) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Dt As DataSet
        Try
            Dim Para() As SqlParameter = New SqlParameter(2) {}


            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@ID", SqlDbType.BigInt)
            Para(2).Value = El.ChkID

            Dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[New_CheckLockStatusChk]", Para)
            Return Dt
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function LockSummary(ByVal EL As ELCadreMgmt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Para() As SqlParameter = New SqlParameter(6) {}


            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@University", SqlDbType.VarChar, 50)
            Para(2).Value = EL.University

            Para(3) = New SqlParameter("@Program", SqlDbType.Int)
            Para(3).Value = EL.Program

            Para(4) = New SqlParameter("@Project", SqlDbType.Int)
            Para(4).Value = EL.Project

            Para(5) = New SqlParameter("@Dept", SqlDbType.VarChar, 250)
            Para(5).Value = EL.Department

            Para(6) = New SqlParameter("@SalaryCode", SqlDbType.VarChar, 50)
            Para(6).Value = EL.SalaryCode

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_LockCadreMgmt]", Para)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function UnLockSummary(ByVal EL As ELCadreMgmt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Para() As SqlParameter = New SqlParameter(6) {}


            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@University", SqlDbType.VarChar, 50)
            Para(2).Value = EL.University

            Para(3) = New SqlParameter("@Program", SqlDbType.Int)
            Para(3).Value = EL.Program

            Para(4) = New SqlParameter("@Project", SqlDbType.Int)
            Para(4).Value = EL.Project

            Para(5) = New SqlParameter("@Dept", SqlDbType.VarChar, 250)
            Para(5).Value = EL.Department

            Para(6) = New SqlParameter("@SalaryCode", SqlDbType.VarChar, 50)
            Para(6).Value = EL.SalaryCode

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_UnLockCadreMgmt]", Para)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ApproveCadre(ByVal EL As ELCadreMgmt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Para() As SqlParameter = New SqlParameter(6) {}


            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@University", SqlDbType.VarChar, 50)
            Para(2).Value = EL.University

            Para(3) = New SqlParameter("@Program", SqlDbType.Int)
            Para(3).Value = EL.Program

            Para(4) = New SqlParameter("@Project", SqlDbType.Int)
            Para(4).Value = EL.Project

            Para(5) = New SqlParameter("@Dept", SqlDbType.VarChar, 250)
            Para(5).Value = EL.Department

            Para(6) = New SqlParameter("@SalaryCode", SqlDbType.VarChar, 50)
            Para(6).Value = EL.SalaryCode

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_ApproveCadreMgmt]", Para)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
    Shared Function UnApproveCadre(ByVal EL As ELCadreMgmt) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Try
            Dim Para() As SqlParameter = New SqlParameter(6) {}


            Para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Para(0).Value = HttpContext.Current.Session("BranchCode")

            Para(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Para(1).Value = HttpContext.Current.Session("Office")

            Para(2) = New SqlParameter("@University", SqlDbType.VarChar, 50)
            Para(2).Value = EL.University

            Para(3) = New SqlParameter("@Program", SqlDbType.Int)
            Para(3).Value = EL.Program

            Para(4) = New SqlParameter("@Project", SqlDbType.Int)
            Para(4).Value = EL.Project

            Para(5) = New SqlParameter("@Dept", SqlDbType.VarChar, 250)
            Para(5).Value = EL.Department

            Para(6) = New SqlParameter("@SalaryCode", SqlDbType.VarChar, 50)
            Para(6).Value = EL.SalaryCode

            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[New_UnApproveCadreMgmt]", Para)
            Return Rowseffected
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
    End Function
End Class
