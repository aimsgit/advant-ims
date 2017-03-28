Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLBatchSemester

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

    Shared Function GetGridData(ByVal batchId As Integer, ByVal sem As Integer, ByVal Assesment As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = batchId

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = sem

        arParms(4) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        arParms(4).Value = Assesment



        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBatchSemesterResult", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Subject(ByVal batchId As Integer, ByVal sem As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = batchId

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = sem
        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_SubjectForBatchSemesterResult", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function SelectTotalMarks(ByVal batchId As Integer, ByVal sem As Integer, ByVal Stdid As Integer, ByVal Assesment As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@batchid", SqlDbType.Int)
        arParms(2).Value = batchId

        arParms(3) = New SqlParameter("@Semid", SqlDbType.Int)
        arParms(3).Value = sem

        arParms(4) = New SqlParameter("@Stdid", SqlDbType.Int)
        arParms(4).Value = Stdid

        arParms(5) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        arParms(5).Value = Assesment

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SelectTotalMarks", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function UpdateGrade(ByVal a As Double, ByVal Course As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(2) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Percent", SqlDbType.Float)
        Parms(1).Value = a

        Parms(2) = New SqlParameter("@Course", SqlDbType.Int)
        Parms(2).Value = Course

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_UpdateGrade", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function UpdateCredit(ByVal Batch As Double, ByVal Subject As String) As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(2) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@Batch", SqlDbType.Int)
        para(1).Value = Batch
        para(2) = New SqlParameter("@Subject", SqlDbType.VarChar, 200)
        para(2).Value = Subject

        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "New_UpdateCredit", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetGridData1(ByVal batchId As Integer, ByVal sem As Integer, ByVal Assesment As Integer, ByVal Subject As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = batchId

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = sem

        arParms(4) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        arParms(4).Value = Assesment

        arParms(5) = New SqlParameter("@SubjectCode", SqlDbType.VarChar, 80)
        arParms(5).Value = Subject

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBatchSemesterResult1", arParms)
        Catch ex As Exception
            'MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function filltextbox(ByVal El As ELBatchSemester) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
        para(0) = New SqlParameter("@Batch_No", SqlDbType.VarChar, 50)
        para(0).Value = El.batchId
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
    Shared Function DuplicateSemResult(ByVal El As ELBatchSemester) As Data.DataTable

        Dim con As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(3) {}
        para(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")
        para(1) = New SqlParameter("@batchID", SqlDbType.Int)
        para(1).Value = El.batchId
        para(2) = New SqlParameter("@SemId", SqlDbType.Int)
        para(2).Value = El.sem
        para(3) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(3).Value = HttpContext.Current.Session("office")
        Try
            ds = SqlHelper.ExecuteDataset(con, CommandType.StoredProcedure, "SelectLock", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function UpdateMarks(ByVal EL As ELBatchSemester) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(7) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        Parms(1).Value = EL.batchId

        Parms(2) = New SqlParameter("@Result", SqlDbType.VarChar, 50)
        Parms(2).Value = EL.Result

        Parms(3) = New SqlParameter("@SemId", SqlDbType.Int)
        Parms(3).Value = EL.sem

        Parms(4) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(4).Value = EL.StdId

        Parms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        Parms(5).Value = HttpContext.Current.Session("EmpCode")

        Parms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(6).Value = HttpContext.Current.Session("UserCode")

        Parms(7) = New SqlParameter("@AssesmentId", SqlDbType.Int)
        Parms(7).Value = EL.Assesmentid



        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InsertBatchSemesterResult", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function UpdateResult(ByVal EL As ELBatchSemester) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim Parms() As SqlParameter = New SqlParameter(12) {}
        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        Parms(1).Value = EL.batchId

        Parms(2) = New SqlParameter("@Percentage", SqlDbType.Float)
        Parms(2).Value = EL.Result

        Parms(3) = New SqlParameter("@SemId", SqlDbType.Int)
        Parms(3).Value = EL.sem

        Parms(4) = New SqlParameter("@StdId", SqlDbType.Int)
        Parms(4).Value = EL.StdId

        Parms(5) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        Parms(5).Value = HttpContext.Current.Session("EmpCode")

        Parms(6) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        Parms(6).Value = HttpContext.Current.Session("UserCode")

        Parms(7) = New SqlParameter("@AssesmentId", SqlDbType.Int)
        Parms(7).Value = EL.Assesmentid
        If EL.TotalMarks = 0 Then
            Parms(8) = New SqlParameter("@TotalMarks", SqlDbType.Float)
            Parms(8).Value = DBNull.Value
        Else
            Parms(8) = New SqlParameter("@TotalMarks", SqlDbType.Float)
            Parms(8).Value = EL.TotalMarks
        End If
        Parms(9) = New SqlParameter("@Division", SqlDbType.VarChar, 50)
        Parms(9).Value = EL.Division

        Parms(10) = New SqlParameter("@Rank", SqlDbType.VarChar, 50)
        Parms(10).Value = EL.Rank

        Parms(11) = New SqlParameter("@MaxMarks", SqlDbType.Float)
        Parms(11).Value = EL.MaxMarks

        Parms(12) = New SqlParameter("@TotalMarkswithGrace", SqlDbType.Float)
        Parms(12).Value = EL.TotalMarkswithGrace

       
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "UpdateBatchSemesterResult", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
End Class
