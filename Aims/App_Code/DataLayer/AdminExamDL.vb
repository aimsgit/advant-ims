Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports System.Data
Public Class AdminExamDL
    Shared Function InsertAdminExamEL(ByVal Exam As AdminExamEL) As String
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0

        Dim params() As SqlParameter = New SqlParameter(9) {}
        params(0) = New SqlParameter("@Course", Data.SqlDbType.Int)
        params(0).Value = Exam.Course

        params(1) = New SqlParameter("@Subject", Data.SqlDbType.Int)
        params(1).Value = Exam.Subject

        params(2) = New SqlParameter("@Duration", Data.SqlDbType.Int)
        params(2).Value = Exam.Duration

        params(3) = New SqlParameter("@AnswerLength", Data.SqlDbType.VarChar, 200)
        params(3).Value = Exam.AnswerLength

        params(4) = New SqlParameter("@QuestionsName", Data.SqlDbType.VarChar, 50)
        params(4).Value = Exam.QuestionsName

        params(5) = New SqlParameter("@Answer", Data.SqlDbType.VarChar, 200)
        params(5).Value = Exam.Answer
        params(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        params(6).Value = HttpContext.Current.Session("BranchCode")

        params(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        params(7).Value = HttpContext.Current.Session("UserCode")

        params(8) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        params(8).Value = HttpContext.Current.Session("EmpCode")
        params(9) = New SqlParameter("@Minute", Data.SqlDbType.Int)
        params(9).Value = Exam.Minute



        rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "[proc_InsertSubjectExam]", params)

        'Command = CommandType.StoredProcedure, "procd_InsertTestDetails", Params
        Return rowsaffected

    End Function
    'Shared Function GetCourseSelectDDL() As DataTable

    '    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    'Dim para() As SqlParameter = New SqlParameter(2) {}


    '    Try
    '        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Proc_GetCourseSelect]")
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    'Shared Function GetSubjectSelectDDL(ByVal CID As Integer) As DataTable

    '    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim para() As SqlParameter = New SqlParameter(0) {}

    '    para(0) = New SqlParameter("@CID", Data.SqlDbType.Int)
    '    para(0).Value = CID

    '    Try
    '        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Proc_GetSubjectSelect]", para)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    Shared Function DisplayGridview(ByVal Exam As AdminExamEL) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Params() As SqlParameter = New SqlParameter(2) {}
        Params(0) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(0).Value = Exam.id
        Params(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Params(1).Value = HttpContext.Current.Session("BranchCode")

        Params(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Params(2).Value = HttpContext.Current.Session("Office")


        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Proc_ExamSubGridview]", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeleteAdminExamEL(ByVal Exam As AdminExamEL) As String

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0

        Dim Params() As SqlParameter = New SqlParameter(0) {}

        Params(0) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(0).Value = Exam.id



        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "[Proc_DeleteExamSubjective]", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'Command = CommandType.StoredProcedure, "proc_InsertPatientDetails", Params
        Return rowsaffected
    End Function
    Shared Function UpdateAdminExamEL(ByVal Exam As AdminExamEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim params() As SqlParameter = New SqlParameter(10) {}
        params(0) = New SqlParameter("@Course", Data.SqlDbType.Int)
        params(0).Value = Exam.Course

        params(1) = New SqlParameter("@Subject", Data.SqlDbType.Int)
        params(1).Value = Exam.Subject

        params(2) = New SqlParameter("@Duration", Data.SqlDbType.Int)
        params(2).Value = Exam.Duration

        params(3) = New SqlParameter("@AnswerLength", Data.SqlDbType.VarChar, 200)
        params(3).Value = Exam.AnswerLength

        params(4) = New SqlParameter("@QuestionsName", Data.SqlDbType.VarChar, 50)
        params(4).Value = Exam.QuestionsName
        params(5) = New SqlParameter("@id", Data.SqlDbType.Int)
        params(5).Value = Exam.id

        params(6) = New SqlParameter("@Answer", Data.SqlDbType.VarChar, 200)
        params(6).Value = Exam.Answer

        params(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        params(7).Value = HttpContext.Current.Session("BranchCode")

        params(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        params(8).Value = HttpContext.Current.Session("UserCode")

        params(9) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        params(9).Value = HttpContext.Current.Session("EmpCode")
        params(10) = New SqlParameter("@Minute", Data.SqlDbType.Int)
        params(10).Value = Exam.Minute


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UpdateSubjectExam", params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function
    Shared Function GetSubjectCombo(ByVal Courseid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@CourseId", Data.SqlDbType.Int)
            Parms(2).Value = Courseid

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SubjectComboForExam", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
