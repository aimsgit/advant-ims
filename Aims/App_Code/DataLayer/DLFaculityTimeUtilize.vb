Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data.Sql

Public Class DLFaculityTimeUtilize
    Shared Function GetSubject(ByVal Batchid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batch", SqlDbType.Int)
            Parms(2).Value = Batchid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getSubjectBatch", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function


    Public Function Insert(ByVal i As ELFaculityTimeUtilization) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(0).Value = i.Eid

        arParms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(1).Value = i.Batch

        arParms(2) = New SqlParameter("@Hours", SqlDbType.Float)
        arParms(2).Value = i.Hours

        arParms(3) = New SqlParameter("@SubjectID", SqlDbType.Int)
        arParms(3).Value = i.Subject

        arParms(4) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(4).Value = i.Dates

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        arParms(8) = New SqlParameter("@CourseID", SqlDbType.Float)
        arParms(8).Value = i.Course

        arParms(9) = New SqlParameter("@semesterID", SqlDbType.Int)
        arParms(9).Value = i.Semester
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "InsertFacultyTimeUtilization", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Public Function Update(ByVal i As ELFaculityTimeUtilization) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(10) {}
        Dim rowsAffected As Integer = 0
        arParms(0) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(0).Value = i.Eid

        arParms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(1).Value = i.Batch

        arParms(2) = New SqlParameter("@Hours", SqlDbType.Float)
        arParms(2).Value = i.Hours

        arParms(3) = New SqlParameter("@SubjectID", SqlDbType.Int)
        arParms(3).Value = i.Subject

        arParms(4) = New SqlParameter("@Date", SqlDbType.DateTime)
        arParms(4).Value = i.Dates

        arParms(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(5).Value = HttpContext.Current.Session("UserCode")

        arParms(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("EmpCode")

        arParms(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(7).Value = HttpContext.Current.Session("BranchCode")

        arParms(8) = New SqlParameter("@FTUIDAuto", SqlDbType.Int)
        arParms(8).Value = i.id

        arParms(9) = New SqlParameter("@CourseID", SqlDbType.Float)
        arParms(9).Value = i.Course

        arParms(10) = New SqlParameter("@semesterID", SqlDbType.Int)
        arParms(10).Value = i.Semester

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "UpdateFacultyTimeUtilization", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Public Function getFaculityTime(ByVal s As ELFaculityTimeUtilization) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Id", SqlDbType.Int)
        arParms(2).Value = s.id

        arParms(3) = New SqlParameter("@EmpID", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("EmpID")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetFacultyTimeUtilization", arParms)
        Return ds.Tables(0)
    End Function
    Public Function DeleteFaculityTime(ByVal s As ELFaculityTimeUtilization) As Int16
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = s.id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        rowsaffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "DeleteFacultyTime", arParms)
        Return rowsaffected
    End Function
    Public Function CheckDuplicate(ByVal s As ELFaculityTimeUtilization) As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim para() As SqlParameter = New SqlParameter(7) {}
        para(0) = New SqlParameter("@id", SqlDbType.Int)
        para(0).Value = s.id
        para(1) = New SqlParameter("@Eid", SqlDbType.Int)
        para(1).Value = s.Eid
        para(2) = New SqlParameter("@Dates", SqlDbType.DateTime)
        para(2).Value = s.Dates
        para(3) = New SqlParameter("@Batch", SqlDbType.Int)
        para(3).Value = s.Batch
        para(4) = New SqlParameter("@Subject", SqlDbType.Int)
        para(4).Value = s.Subject
        para(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        para(5).Value = HttpContext.Current.Session("BranchCode")
        para(6) = New SqlParameter("@CourseID", SqlDbType.VarChar, 50)
        para(6).Value = s.Course
        para(7) = New SqlParameter("@semesterID", SqlDbType.VarChar, 50)
        para(7).Value = s.Semester
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "DuplicateFacultyTimeUtilize", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function

    Shared Function GetBatchCombo() As Data.DataTable
        Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim Para() As SqlParameter = New SqlParameter(1) {}
        Para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        Para(0).Value = HttpContext.Current.Session("Office")
        Para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "Proc_FacultyTimeBatch", Para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
