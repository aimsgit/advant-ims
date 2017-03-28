Imports Microsoft.VisualBasic

Imports System.Data.SqlClient

Public Class DLBatchReportCardElect
    Public Function Rpt_BatchReportCardElect(ByVal BranchCode As String, ByVal course As Integer, ByVal BatchNo As String, ByVal Sem As String, ByVal AsstType As String, ByVal Subject As String, ByVal SortBy As Integer, ByVal FrmMarks As String, ByVal Tomarks As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(9) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@course", SqlDbType.Int)
        arParms(1).Value = course

        arParms(2) = New SqlParameter("@BatchNo", SqlDbType.VarChar)
        arParms(2).Value = BatchNo

        arParms(3) = New SqlParameter("@Sem", SqlDbType.VarChar)
        arParms(3).Value = Sem

        arParms(4) = New SqlParameter("@AsstType", SqlDbType.VarChar)
        arParms(4).Value = AsstType

        arParms(5) = New SqlParameter("@Subject", SqlDbType.VarChar)
        arParms(5).Value = Subject

        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(6).Value = HttpContext.Current.Session("Office")

        arParms(7) = New SqlParameter("@SortBy", SqlDbType.Int)
        arParms(7).Value = SortBy

        arParms(8) = New SqlParameter("@FrmMarks", SqlDbType.VarChar)
        arParms(8).Value = FrmMarks

        arParms(9) = New SqlParameter("@ToMarks", SqlDbType.VarChar)
        arParms(9).Value = Tomarks


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_BatchReportCardElect", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Rpt_BatchReportMarksAnalysis(ByVal BranchCode As String, ByVal course As Integer, ByVal BatchNo As String, ByVal Sem As String, ByVal AsstType As String, ByVal Subject As String, ByVal Frm1 As Integer, ByVal Frm2 As Integer, ByVal Frm3 As Integer, ByVal Frm4 As Integer, ByVal To1 As Integer, ByVal To2 As Integer, ByVal To3 As Integer, ByVal To4 As Integer, ByVal RBMarks As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(14) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(1).Value = course

        arParms(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 200)
        arParms(2).Value = BatchNo

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = Sem

        arParms(4) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        arParms(4).Value = AsstType

        arParms(5) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(5).Value = Subject

        arParms(6) = New SqlParameter("@Frm1", SqlDbType.Int)
        arParms(6).Value = Frm1

        arParms(7) = New SqlParameter("@Frm2", SqlDbType.Int)
        arParms(7).Value = Frm2

        arParms(8) = New SqlParameter("@Frm3", SqlDbType.Int)
        arParms(8).Value = Frm3

        arParms(9) = New SqlParameter("@Frm4", SqlDbType.Int)
        arParms(9).Value = Frm4

        arParms(10) = New SqlParameter("@To1", SqlDbType.Int)
        arParms(10).Value = To1

        arParms(11) = New SqlParameter("@To2", SqlDbType.Int)
        arParms(11).Value = To2

        arParms(12) = New SqlParameter("@To3", SqlDbType.Int)
        arParms(12).Value = To3

        arParms(13) = New SqlParameter("@To4", SqlDbType.Int)
        arParms(13).Value = To4

        arParms(14) = New SqlParameter("@RBMarks", SqlDbType.Int)
        arParms(14).Value = RBMarks



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_BatMarksAnalysis", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ExamDashboard(ByVal Batch As String, ByVal Sem As Integer, ByVal AsstType As Integer, ByVal Subject As Integer, ByVal Frm1 As Integer, ByVal Frm2 As Integer, ByVal Frm3 As Integer, ByVal Frm4 As Integer, ByVal To1 As Integer, ByVal To2 As Integer, ByVal To3 As Integer, ByVal To4 As Integer, ByVal RBMarks As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(13) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@RBMarks", SqlDbType.Int)
        arParms(1).Value = RBMarks

        arParms(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 200)
        arParms(2).Value = Batch

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = Sem

        arParms(4) = New SqlParameter("@AssesmentType", SqlDbType.Int)
        arParms(4).Value = AsstType

        arParms(5) = New SqlParameter("@Subject", SqlDbType.Int)
        arParms(5).Value = Subject

        arParms(6) = New SqlParameter("@Frm1", SqlDbType.Int)
        arParms(6).Value = Frm1

        arParms(7) = New SqlParameter("@Frm2", SqlDbType.Int)
        arParms(7).Value = Frm2

        arParms(8) = New SqlParameter("@Frm3", SqlDbType.Int)
        arParms(8).Value = Frm3

        arParms(9) = New SqlParameter("@Frm4", SqlDbType.Int)
        arParms(9).Value = Frm4

        arParms(10) = New SqlParameter("@To1", SqlDbType.Int)
        arParms(10).Value = To1

        arParms(11) = New SqlParameter("@To2", SqlDbType.Int)
        arParms(11).Value = To2

        arParms(12) = New SqlParameter("@To3", SqlDbType.Int)
        arParms(12).Value = To3

        arParms(13) = New SqlParameter("@To4", SqlDbType.Int)
        arParms(13).Value = To4

       


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ExamDashboard", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function insertBranch() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BranchCombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertCourse(ByVal Branchcode As String) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        If Branchcode = "0" Then
            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Branchcode")
        Else
            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = Branchcode
        End If

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_CourseComboRPT", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertYear(ByVal Courseid As Integer, ByVal Branchcode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = Branchcode

        arParms(1) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(1).Value = Courseid

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_AYearComboRPT", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function insertBatch(ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode


        arParms(1) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(1).Value = CourseID

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_BatchComboForReport", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function FillBatch(ByVal CourseID As Integer, ByVal Year As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Branchcode")

        arParms(2) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(2).Value = CourseID

        arParms(3) = New SqlParameter("@Year", SqlDbType.Int)
        arParms(3).Value = Year

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_GetBatch", arParms)
        Return ds.Tables(0)
    End Function
    Public Function SemesterCombo(ByVal batch As Integer) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_SemesterAllDDL", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectCombo(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_BatchSubjectAll", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectComboAll(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SubjectAllDDL", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function getassessment() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectAssesmentRPT", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function Selectassessment() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_AssessmentSelectDdl", arParms)
        Return ds.Tables(0)
    End Function
    Public Function SemesterCombo1(ByVal BranchCode As String, ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = BranchCode
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_SemesterAllDDL", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectComboAll1(ByVal BranchCode As String, ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batchid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SubjectAllDDL", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectComboAllNew(ByVal BranchCode As String, ByVal Batchid As String, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.VarChar, 200)
            Parms(2).Value = Batchid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SubjectAllNew", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function getassessment1(ByVal BranchCode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectAssesmentRPT", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function getassessmentAll() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[New_SelectAssesmentAll]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function SelectCourseSemester(ByVal CourseId As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(2).Value = CourseId

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectCourseSemester", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function SelectNewAssessment() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectAssessment", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function SelectCourseSemSubject(ByVal Courseid As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@CourseId", SqlDbType.Int)
            Parms(2).Value = Courseid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CourseSemSubject", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function insertBatchReport(ByVal CourseID As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")


        arParms(1) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(1).Value = CourseID

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_BatchComboForReport", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function BatchComboReport(ByVal BranchCode As String, ByVal CourseID As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode


        arParms(1) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(1).Value = CourseID

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_BatchComboForReport", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetStudentNameCombo(ByVal BranchCode As String, ByVal BatchId As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = BranchCode
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = BatchId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_StudentAll", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function SemesterComboSelect(ByVal BranchCode As String, ByVal batch As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = BranchCode
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = batch
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee1", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
