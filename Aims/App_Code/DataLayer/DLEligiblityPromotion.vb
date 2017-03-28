Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLEligiblityPromotion
    Public Function getBatchPlannerCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchCombofill", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function getduplicate(ByVal EL As ELEligiblityPromotion) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.SBatchid
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.Semid
        param(2) = New SqlClient.SqlParameter("@SemesterId", SqlDbType.Int)
        param(2).Value = EL.TBatchid
        param(3) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")
        param(4) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(4).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_DuplicateFacultyAllocation]", param)
        Return ds.Tables(0)
    End Function
    Shared Function generate(ByVal EL As ELEligiblityPromotion) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}
        param(0) = New SqlClient.SqlParameter("@SBatch", SqlDbType.Int)
        param(0).Value = EL.SBatchid
        param(1) = New SqlClient.SqlParameter("@SemId", SqlDbType.Int)
        param(1).Value = EL.Semid
        param(2) = New SqlClient.SqlParameter("@NoOfSubjectFailed", SqlDbType.Int)
        param(2).Value = EL.SFailed
        param(3) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("EmpCode")
        param(4) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("UserCode")
        param(5) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(5).Value = HttpContext.Current.Session("BranchCode")
        param(6) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(6).Value = HttpContext.Current.Session("Office")
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_GeneratestudentPromotion", param)
        Return AffectedRows
    End Function

    Shared Function InsertStudent(ByVal EL As ELEligiblityPromotion) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
        param(0) = New SqlClient.SqlParameter("@StdId", SqlDbType.VarChar, 2000)
        param(0).Value = EL.StdId
        param(1) = New SqlClient.SqlParameter("@StdCode", SqlDbType.VarChar, 2000)
        param(1).Value = EL.StdCode
        param(2) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("EmpCode")
        param(3) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("UserCode")
        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        param(5) = New SqlClient.SqlParameter("@BatchID", SqlDbType.Int)
        param(5).Value = EL.TBatchid
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_PromotionTransfer", param)
        Return AffectedRows
    End Function

    Shared Function UndoStudent(ByVal EL As ELEligiblityPromotion) As Integer
        Dim AffectedRows As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}
        param(0) = New SqlClient.SqlParameter("@StdId", SqlDbType.VarChar, 2000)
        param(0).Value = EL.StdId
        param(1) = New SqlClient.SqlParameter("@StdCode", SqlDbType.VarChar, 2000)
        param(1).Value = EL.StdCode
        param(2) = New SqlClient.SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("EmpCode")
        param(3) = New SqlClient.SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("UserCode")
        param(4) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("BranchCode")
        param(5) = New SqlClient.SqlParameter("@BatchID", SqlDbType.Int)
        param(5).Value = EL.TBatchid
        AffectedRows = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UndoPromotionTransfer", param)
        Return AffectedRows
    End Function
    Shared Function GetData(ByVal EL As ELEligiblityPromotion) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
        param(0) = New SqlClient.SqlParameter("@CourseId", SqlDbType.Int)
        param(0).Value = EL.SBatchid
        param(1) = New SqlClient.SqlParameter("@BatchId", SqlDbType.Int)
        param(1).Value = EL.Semid
        param(2) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("BranchCode")
        param(3) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(3).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_GetFacultyAllocation]", param)
        Return ds.Tables(0)
    End Function

    Shared Function GetResult(ByVal EL As ELEligiblityPromotion) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}
        param(0) = New SqlClient.SqlParameter("@Batchid", SqlDbType.Int)
        param(0).Value = EL.SBatchid
        param(1) = New SqlClient.SqlParameter("@Semester", SqlDbType.Int)
        param(1).Value = EL.Semid
        param(2) = New SqlClient.SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("BranchCode")
        param(3) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(3).Value = HttpContext.Current.Session("Office")
        param(4) = New SqlClient.SqlParameter("@AssesmentType", SqlDbType.Int)
        param(4).Value = EL.Assisment
        param(5) = New SqlClient.SqlParameter("@NoofSubjects", SqlDbType.Int)
        param(5).Value = EL.NoofSubject
        param(6) = New SqlClient.SqlParameter("@Semester1", SqlDbType.Int)
        param(6).Value = EL.Semid2
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetPromotionSemesterResult", param)
        Return ds.Tables(0)
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_ddlBatchSemester_fee1", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function Drilldown(ByVal StdId As Integer, ByVal BatchId As Integer, ByVal sem As Integer, ByVal sem1 As Integer, ByVal assesment As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(6) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batchid", SqlDbType.Int)
        param(2).Value = BatchId
        param(3) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        param(3).Value = assesment
        param(4) = New SqlParameter("@Semester1", SqlDbType.Int)
        param(4).Value = sem1
        param(5) = New SqlParameter("@Semester", SqlDbType.Int)
        param(5).Value = sem
        param(6) = New SqlParameter("@STDID", SqlDbType.Int)
        param(6).Value = StdId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_DrilldownEligibility", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function RptPromotionEligibility(ByVal Batch As Integer, ByVal sem1 As Integer, ByVal sem2 As Integer, ByVal Assisment As Integer, ByVal NoofSubject As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(7) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batchid", SqlDbType.Int)
        param(2).Value = Batch
        param(3) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        param(3).Value = Assisment
        param(4) = New SqlParameter("@Semester1", SqlDbType.Int)
        param(4).Value = sem2
        param(5) = New SqlParameter("@Semester", SqlDbType.Int)
        param(5).Value = sem1
        param(6) = New SqlParameter("@STDID", SqlDbType.Int)
        param(6).Value = 0
        param(7) = New SqlParameter("@NoofSubject", SqlDbType.Int)
        param(7).Value = NoofSubject
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_RptPromotionAndEligibility", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
