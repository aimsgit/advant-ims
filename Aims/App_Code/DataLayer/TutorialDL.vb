Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.VisualBasic

Public Class TutorialDL
    Shared Function InsertTutorialEL(ByVal Tutorial As TutorialEL) As String
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0

        Dim params() As SqlParameter = New SqlParameter(7) {}
        params(0) = New SqlParameter("@Subject", Data.SqlDbType.Int)
        params(0).Value = Tutorial.Subject
        params(1) = New SqlParameter("@Course", Data.SqlDbType.Int)
        params(1).Value = Tutorial.Course


        params(2) = New SqlParameter("@Duration", Data.SqlDbType.Float)
        params(2).Value = Tutorial.Duration

        params(3) = New SqlParameter("@Link_Name", Data.SqlDbType.VarChar, 50)
        params(3).Value = Tutorial.Link_Name

        params(4) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        params(4).Value = HttpContext.Current.Session("BranchCode")

        params(5) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        params(5).Value = HttpContext.Current.Session("UserCode")

        params(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        params(6).Value = HttpContext.Current.Session("EmpCode")
        params(7) = New SqlParameter("@Minute", Data.SqlDbType.Int)
        params(7).Value = Tutorial.Minute
        rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "[Exam_InsertTutorialMaster]", params)

        'Command = CommandType.StoredProcedure, "procd_InsertTestDetails", Params
        Return rowsaffected

    End Function
    'Shared Function GetTutorialSubjectDDL() As DataTable

    '    Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
    '    Dim ds As New DataSet
    '    Dim para() As SqlParameter = New SqlParameter(0) {}

    '    para(0) = New SqlParameter("@SID", Data.SqlDbType.Int)
    '    para(0).Value = 0

    '    Try
    '        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Proc_GetTutorialSubjectDDL]", para)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)
    'End Function
    Shared Function DisplayGridview(ByVal id As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        'Dim para() As SqlParameter = New SqlParameter(2) {}
        Dim Params() As SqlParameter = New SqlParameter(2) {}
        Params(0) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(0).Value = id


        Params(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Params(1).Value = HttpContext.Current.Session("BranchCode")

        Params(2) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        Params(2).Value = HttpContext.Current.Session("Office")


        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Exam_GetTutorialMaster", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function DeleteTutorialEL(ByVal Tutorial As TutorialEL) As String

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsaffected As Integer = 0

        Dim Params() As SqlParameter = New SqlParameter(0) {}

        Params(0) = New SqlParameter("@id", Data.SqlDbType.Int)
        Params(0).Value = Tutorial.id



        Try
            rowsaffected = SqlHelper.ExecuteNonQuery(ConnectionString, CommandType.StoredProcedure, "[proc_DeleteExamTutorialMaster]", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'Command = CommandType.StoredProcedure, "proc_InsertPatientDetails", Params
        Return rowsaffected
    End Function
    Shared Function UpdateTutorialEL(ByVal Tutorial As TutorialEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim params() As SqlParameter = New SqlParameter(8) {}
        params(0) = New SqlParameter("@Subject", Data.SqlDbType.Int)
        params(0).Value = Tutorial.Subject
        params(1) = New SqlParameter("@Course", Data.SqlDbType.Int)
        params(1).Value = Tutorial.Course


        params(2) = New SqlParameter("@Duration", Data.SqlDbType.Int)
        params(2).Value = Tutorial.Duration

        params(3) = New SqlParameter("@Linkname", Data.SqlDbType.VarChar, 50)
        params(3).Value = Tutorial.Link_Name

        params(4) = New SqlParameter("@id", Data.SqlDbType.Int)
        params(4).Value = Tutorial.id
        params(5) = New SqlParameter("@Minute", Data.SqlDbType.Int)
        params(5).Value = Tutorial.Minute
        params(6) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        params(6).Value = HttpContext.Current.Session("BranchCode")

        params(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        params(7).Value = HttpContext.Current.Session("UserCode")

        params(8) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        params(8).Value = HttpContext.Current.Session("EmpCode")


        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "[Exam_UpdateTutorialMaster]", params)
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
