Imports System.Data.SqlClient

Public Class DLSubjectFacultyUtilization
    Shared Function GetFacultyCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_FacultyCombo]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetFacultyReport(ByVal EMPID As Integer, ByVal CourseID As Integer, ByVal BatchID As Integer, ByVal SemesterID As Integer, ByVal SubjectID As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(6) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            '           @CourseID as int,
            '@BatchID as int,
            '@SemesterID as int,
            '@TeacherID1 as int
            Parms(2) = New SqlParameter("@TeacherID1", SqlDbType.Int)
            Parms(2).Value = EMPID
            Parms(3) = New SqlParameter("@CourseID", SqlDbType.Int)
            Parms(3).Value = CourseID
            Parms(4) = New SqlParameter("@BatchID", SqlDbType.Int)
            Parms(4).Value = BatchID
            Parms(5) = New SqlParameter("@SemesterID", SqlDbType.Int)
            Parms(5).Value = SemesterID
            Parms(6) = New SqlParameter("@SubjectID", SqlDbType.Int)
            Parms(6).Value = SubjectID

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "RPT_StudentWiseFacultyUtilization", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubject(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batchid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubject1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function


End Class
