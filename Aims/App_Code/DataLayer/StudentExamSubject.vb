Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class StudentExamSubject
    Public Function ViewSubject() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(5) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = HttpContext.Current.Session("BatchID")
        param(3) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("StudentCode")
        param(4) = New SqlParameter("@CourseID", SqlDbType.Int)
        param(4).Value = HttpContext.Current.Session("CourseID")
        param(5) = New SqlParameter("@SemesterID", SqlDbType.Int)
        param(5).Value = HttpContext.Current.Session("SemesterID")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_ViewSubjectSelectionforExam", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function UpdateSubject(ByVal Subject As String) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(8) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = HttpContext.Current.Session("BatchID")
        param(3) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("StudentCode")
        param(4) = New SqlParameter("@CourseID", SqlDbType.Int)
        param(4).Value = HttpContext.Current.Session("CourseID")
        param(5) = New SqlParameter("@SemesterID", SqlDbType.Int)
        param(5).Value = HttpContext.Current.Session("SemesterID")
        param(6) = New SqlParameter("@SubjectId", SqlDbType.VarChar, 50)
        param(6).Value = Subject
        param(7) = New SqlParameter("@Empcode", SqlDbType.VarChar, 50)
        param(7).Value = HttpContext.Current.Session("StudentCode")
        param(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(8).Value = HttpContext.Current.Session("UserName")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_UpdateSubjectSelectionforExam", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Nothing
    End Function

    Shared Function StudentCurrentSem() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(0).Value = HttpContext.Current.Session("BatchID")
            Parms(1) = New SqlParameter("@StudentCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("StudentCode")
            Parms(2) = New SqlParameter("@CourseID", SqlDbType.Int)
            Parms(2).Value = HttpContext.Current.Session("CourseID")
            Parms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(3).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_NewStudentSem", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
