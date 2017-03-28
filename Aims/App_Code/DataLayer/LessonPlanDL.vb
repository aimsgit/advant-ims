Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient

Public Class LessonPlanDL
    Dim dt As New DataTable
    Dim query As String
    Dim ds As New DataSet
    Shared Function GetEmployeeCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_LessonPlanEmployeeName", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function GetBatchCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_LessonPlanBatchCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function SemesterComboD2(ByVal Course As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@Course", SqlDbType.VarChar, 50)
            Parms(2).Value = Course

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_LessonPlanSemesterCombo1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_LessonPlanSemesterCombo", param)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubject(ByVal Batch As Integer, ByVal Sem As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = Sem

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_LessonPlanSubjectCombo", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubject1(ByVal Course As Integer, ByVal Sem As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Courseid", SqlDbType.Int)
            Parms(2).Value = Course

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = Sem

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_LessonPlanSubjectCombo1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubject12(ByVal Course As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@Courseid", SqlDbType.Int)
            Parms(2).Value = Course

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_CourseWiseSubject", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function Insert(ByVal LP As LessonPlanEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(13) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(3).Value = LP.EmpID

        arParms(4) = New SqlParameter("@Courseid", SqlDbType.Int)
        arParms(4).Value = LP.Courseid

        arParms(5) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(5).Value = LP.SemesterID

        arParms(6) = New SqlParameter("@SubjectID", SqlDbType.Int)
        arParms(6).Value = LP.SubjectID

        arParms(7) = New SqlParameter("@Topic", SqlDbType.VarChar, LP.Topic.Length)
        arParms(7).Value = LP.Topic

        arParms(8) = New SqlParameter("@Hours", SqlDbType.Float)
        arParms(8).Value = LP.TopicHrs

        arParms(9) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(9).Value = LP.FromDate

        arParms(10) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(10).Value = LP.ToDate

        arParms(11) = New SqlParameter("@Week", SqlDbType.VarChar, 50)
        arParms(11).Value = LP.Week

        arParms(12) = New SqlParameter("@Portion", SqlDbType.Float)
        arParms(12).Value = LP.Portion

        arParms(13) = New SqlParameter("@Unit", SqlDbType.VarChar, 250)
        arParms(13).Value = LP.Unit
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_InsertLessonPlan", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    Shared Function GetLessonPlan(ByVal LP As LessonPlanEL) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@LPAutoID", SqlDbType.Int)
        arParms(2).Value = LP.ID

        'arParms(3) = New SqlParameter("@EmpID", SqlDbType.Int)
        'arParms(3).Value = LP.EmpID

        arParms(3) = New SqlParameter("@Courseid", SqlDbType.Int)
        arParms(3).Value = LP.Courseid

        arParms(4) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(4).Value = LP.SemesterID

        arParms(5) = New SqlParameter("@SubjectID", SqlDbType.Int)
        arParms(5).Value = LP.SubjectID

        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetLessonPlan", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function Update(ByVal LP As LessonPlanEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(14) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("EmpCode")

        arParms(2) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("UserCode")

        arParms(3) = New SqlParameter("@EmpID", SqlDbType.Int)
        arParms(3).Value = LP.EmpID

        arParms(4) = New SqlParameter("@Courseid", SqlDbType.Int)
        arParms(4).Value = LP.Courseid

        arParms(5) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(5).Value = LP.SemesterID

        arParms(6) = New SqlParameter("@SubjectID", SqlDbType.Int)
        arParms(6).Value = LP.SubjectID

        arParms(7) = New SqlParameter("@Topic", SqlDbType.VarChar, LP.Topic.Length)
        arParms(7).Value = LP.Topic

        arParms(8) = New SqlParameter("@Hours", SqlDbType.Float)
        arParms(8).Value = LP.TopicHrs

        arParms(9) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(9).Value = LP.FromDate

        arParms(10) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(10).Value = LP.ToDate

        arParms(11) = New SqlParameter("@LPID", SqlDbType.Int)
        arParms(11).Value = LP.ID

        arParms(12) = New SqlParameter("@Week", SqlDbType.VarChar, 50)
        arParms(12).Value = LP.Week
        arParms(13) = New SqlParameter("@Portion", SqlDbType.Float)
        arParms(13).Value = LP.Portion

        arParms(14) = New SqlParameter("@Unit", SqlDbType.VarChar, 250)
        arParms(14).Value = LP.Unit
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_UpdateLessonPlan", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function

    Shared Function ChangeFlag(ByVal LP As LessonPlanEL) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@ID", SqlDbType.Int)
        arParms(0).Value = LP.ID
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_ChangeFlagLessonPlan", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return rowsAffected
    End Function
    '-----Functions for Report
    Shared Function GetRptLessonPlan(ByVal courseid As Integer, ByVal SemID As Integer, ByVal SubjectID As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@courseid", SqlDbType.Int)
        arParms(2).Value = courseid

        arParms(3) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(3).Value = SemID

        arParms(4) = New SqlParameter("@SubjectID", SqlDbType.Int)
        arParms(4).Value = SubjectID


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_RptLessonPlan", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBatchComboR() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_LessonPlanBatchComboR", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    
    Public Function SemesterComboD1R(ByVal batch As Integer) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_LessonPlanSemesterComboR", param)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectR(ByVal Batch As Integer, ByVal Sem As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batch

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = Sem

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_LessonPlanSubjectComboR", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetRptLessonPlanVSTimesheet(ByVal BatchID As Integer, ByVal SemID As Integer, ByVal SubjectID As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(2).Value = BatchID

        arParms(3) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(3).Value = SemID

        arParms(4) = New SqlParameter("@SubjectID", SqlDbType.Int)
        arParms(4).Value = SubjectID


        Dim ds As New DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_LsnplanvsTimesheet", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
