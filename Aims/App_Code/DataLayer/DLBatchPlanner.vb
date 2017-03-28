Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLBatchPlanner
    Shared Function GetBatchPlanner(ByVal p As BatchPlanner) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(4) {}
        para(0) = New SqlParameter("@BatchID", SqlDbType.Int)
        para(0).Value = p.BatchID
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        para(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("EmpCode")
        para(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        para(4).Value = HttpContext.Current.Session("UserCode")
        Try
            ds = SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "Proc_GenereateBatch", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function CheckLockBatchPl(ByVal p As BatchPlanner) As DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(2) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(1).Value = p.BatchID

        Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Parms(2).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CheckLockBatchplanner", Parms)
            Return ds
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function PostCheck(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetUnlockBatchPlanner", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function CheckLockBatchPln(ByVal p As BatchPlanner) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")


        Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(1).Value = p.BatchID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_CheckLockBatchplannerStatus", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UNLockBatchPl(ByVal p As BatchPlanner) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(1) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")


        Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(1).Value = p.BatchID

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateLockBatchplannerStatus", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetAcedemicYear(ByVal p As BatchPlanner) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(4) {}
        para(0) = New SqlParameter("@BatchID", SqlDbType.Int)
        para(0).Value = p.BatchID
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        para(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("EmpCode")
        para(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        para(4).Value = HttpContext.Current.Session("UserCode")
        Try
            ds = SqlHelper.ExecuteScalar(con, CommandType.StoredProcedure, "Proc_GenereateBatch", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds
    End Function
    Shared Function InsertBatchPlanner(ByVal p As BatchPlanner) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(9) {}


        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(2).Value = p.BatchID

        arParms(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpCode")

        arParms(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(4).Value = HttpContext.Current.Session("UserCode")

        arParms(5) = New SqlParameter("@Subid", SqlDbType.Int)
        arParms(5).Value = p.Subject

        arParms(6) = New SqlParameter("@TotHours", SqlDbType.Float)
        arParms(6).Value = p.TotalHours

        arParms(7) = New SqlParameter("@Semid", SqlDbType.Int)
        arParms(7).Value = p.Semester


        arParms(8) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(8).Value = p.Course

        arParms(9) = New SqlParameter("@Credit", SqlDbType.Float)
        arParms(9).Value = p.Credit

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertSubintoBatch", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function UpdateBatchPlanner(ByVal p As BatchPlanner) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(0).Value = p.BatchID

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateCreateBatch", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function DeleteBatchPlanner(ByVal id As Integer) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@ID", SqlDbType.Int)
        para(0).Value = id
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Proc_DeleteBatchplanner2", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function getBatchPlannerCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchPlannerCombofill", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getBatchPlannerDDL() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchPlannerDDLfill", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getBatchBestPerformerDDL() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchForBastPerformer", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetLecturercombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_LecturerCombo1", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetCreateBatchAcademicYearCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetCreateBatchAcademicYearCombo", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function filltextbox(ByVal p As BatchPlanner) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
        para(0) = New SqlParameter("@Batch_No", SqlDbType.VarChar, 50)
        para(0).Value = p.Batch_No
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBatchPlannerFiltter", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBatchPlannerView(ByVal p As BatchPlanner) As Data.DataTable
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(4) {}
        para(0) = New SqlParameter("@Gid", SqlDbType.Int)
        para(0).Value = p.Gid
        para(1) = New SqlParameter("@ID", SqlDbType.Int)
        para(1).Value = p.id
        para(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("BranchCode")
        para(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("Office")
        para(4) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        para(4).Value = p.Semester
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "GetBatchPlannerView", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Shared Function GetEmpUpdate(ByVal p As BatchPlanner) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(6) {}

        para(0) = New SqlParameter("@Lecturer", SqlDbType.VarChar, 50)
        para(0).Value = p.Lecturer

        para(1) = New SqlParameter("@ID", SqlDbType.Int)
        para(1).Value = p.id

        para(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("UserCode")

        para(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("EmpCode")

        para(4) = New SqlParameter("@Sequence", SqlDbType.Int)
        para(4).Value = p.Sequence

        para(5) = New SqlParameter("@Elective", SqlDbType.VarChar, 2)
        para(5).Value = p.Elective_Status

        para(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(6).Value = HttpContext.Current.Session("BranchCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateEmployee", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function DeleteBatchPlanner1(ByVal id As Integer) As Integer
        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@ID", SqlDbType.Int)
        para(0).Value = id
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(con, CommandType.StoredProcedure, "Proc_DeleteBatchplanner", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsaffected
    End Function
    Shared Function GetLecturercombo1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_LecturerCombo", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Updatebatchplannergrid(ByVal m As BatchPlanner) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(6) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.NVarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Semester", SqlDbType.Int)
        Parms(1).Value = m.Semester

        Parms(2) = New SqlParameter("@subject", SqlDbType.Int)
        Parms(2).Value = m.Subject

        Parms(3) = New SqlParameter("@theory", SqlDbType.VarChar, 50)
        Parms(3).Value = m.TotalHours

        Parms(4) = New SqlParameter("@id", SqlDbType.Int)
        Parms(4).Value = m.id

        Parms(5) = New SqlParameter("@Credit", SqlDbType.Float)
        Parms(5).Value = m.Credit

        Parms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        Parms(6).Value = HttpContext.Current.Session("EmpCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdatebatchPlanner", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function DuplicateBatchPlanner(ByVal v As BatchPlanner) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(2).Value = v.BatchID

            Parms(3) = New SqlParameter("@Sem", SqlDbType.Int)
            Parms(3).Value = v.Semester

            Parms(4) = New SqlParameter("@sub", SqlDbType.Int)
            Parms(4).Value = v.Subject


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_DuplicateBatchPlanner", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function SemesterComboD1(ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee1", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function getBatchPlannerComboSelectAll() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("EmpID")

            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(3).Value = HttpContext.Current.Session("UserRole")

            Parms(4) = New SqlParameter("@DeptId", SqlDbType.Int)
            Parms(4).Value = HttpContext.Current.Session("DeptId")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchPlannerComboAll", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    'Code By Jina
    Shared Function getBatchPlanComboSelectAll() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(5) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("EmpID")

            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(3).Value = HttpContext.Current.Session("UserRole")

            Parms(4) = New SqlParameter("@DeptId", SqlDbType.Int)
            Parms(4).Value = HttpContext.Current.Session("DeptId")
            Parms(5) = New SqlParameter("@EmpID", SqlDbType.Int)
            Parms(5).Value = HttpContext.Current.Session("EmpID")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchPlanComboAll", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getBatchPlannerComboSelect() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@EmpID", SqlDbType.Int)
            Parms(2).Value = HttpContext.Current.Session("EmpID")
            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(3).Value = HttpContext.Current.Session("UserRole")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchPlannerCombo", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getBatchPlannerComboSelect1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchPlannerCombo1", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function UpdateCollectionVerification(ByVal p As BatchPlanner) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0
        Dim para() As SqlParameter = New SqlParameter(5) {}

        para(0) = New SqlParameter("@BatchID", SqlDbType.Int)
        para(0).Value = p.BatchID
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        para(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        para(2).Value = HttpContext.Current.Session("Office")
        para(3) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("EmpCode")
        para(4) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        para(4).Value = HttpContext.Current.Session("UserCode")
        para(5) = New SqlParameter("@Elective", SqlDbType.VarChar, 2)
        para(5).Value = p.Elective_Status

        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateAllElective", para)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function

    'Code By Jina
    Shared Function getBatchPlanComboSelectAll1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("EmpID")

            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(3).Value = HttpContext.Current.Session("UserRole")

            Parms(4) = New SqlParameter("@DeptId", SqlDbType.Int)
            Parms(4).Value = HttpContext.Current.Session("DeptId")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchPlanComboAll1", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getBatchPlannerAceess() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[BatchPlanneraccess]", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
