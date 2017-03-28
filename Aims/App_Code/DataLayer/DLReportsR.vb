Imports Microsoft.VisualBasic

Imports System.Data.SqlClient
Imports System.IO

Public Class DLReportsR
    Public Function Rpt_BatchReportCard(ByVal BranchCode As String, ByVal course As Integer, ByVal BatchNo As String, ByVal Sem As String, ByVal AsstType As String, ByVal Subject As String, ByVal ClassType As Integer, ByVal SortBy As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(8) {}
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

        arParms(6) = New SqlParameter("@ClassType", SqlDbType.Int)
        arParms(6).Value = ClassType

        arParms(7) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(7).Value = HttpContext.Current.Session("Office")

        arParms(8) = New SqlParameter("@SortBy", SqlDbType.Int)
        arParms(8).Value = SortBy

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_BatchReportCard", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetSubjectComboAll(ByVal Batchid As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = Batchid
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubjectAll", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ManagementDashboard(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate
            'Filtering through Batch Wise
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ManagementDashBoard", Parms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ManagementDashboardCourseWise(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate
            'Filtering through Batch Wise
            'ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ManagementDashBoard", Parms)

            'Code By JinaPriya 8/4/2015 - Filtering through Course Wise 
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ManagementDashBoardBasedOnCourse", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function ManagementDashboard1(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(1).Value = FromDate

            Parms(2) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(2).Value = ToDate
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ManagementDashBoard", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Rpt_StudentPerformanceRpt(ByVal Batch As Integer, ByVal StdId As Integer, ByVal SemId As Integer, ByVal SubId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = Batch

        arParms(2) = New SqlParameter("@StdId", SqlDbType.Int)
        arParms(2).Value = StdId

        arParms(3) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(3).Value = SemId

        arParms(4) = New SqlParameter("@SubId", SqlDbType.Int)
        arParms(4).Value = SubId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StdPerformance", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Rpt_BatchPerformanceRpt(ByVal Batch1 As Integer, ByVal Batch2 As Integer, ByVal courseid As Integer, ByVal subid As Integer, ByVal SemId As Integer, ByVal AssessmentId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@Batch1", SqlDbType.Int)
        arParms(2).Value = Batch1

        arParms(3) = New SqlParameter("@Batch2", SqlDbType.Int)
        arParms(3).Value = Batch2

        arParms(4) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(4).Value = courseid

        arParms(5) = New SqlParameter("@SubId", SqlDbType.Int)
        arParms(5).Value = subid

        arParms(6) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(6).Value = SemId

        arParms(7) = New SqlParameter("@AssessmentId", SqlDbType.Int)
        arParms(7).Value = AssessmentId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_BatchPerformanceRpt", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetBranchCourse(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBranchCourse", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function EnquiryDetails(ByVal FromDate As DateTime, ByVal ToDate As DateTime, ByVal BranchCode As String, ByVal Courseid As String, ByVal Fname As String, ByVal AdmitFlag As String, ByVal Source As String, ByVal ERealatedTo As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(9) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")

        If BranchCode = "0" Or BranchCode = " All" Then
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Else
            arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(1).Value = BranchCode
        End If

        arParms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(2).Value = FromDate

        arParms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
        arParms(3).Value = ToDate

        arParms(4) = New SqlParameter("@BranchCodeDDL", SqlDbType.VarChar, 50)
        arParms(4).Value = BranchCode

        arParms(5) = New SqlParameter("@Courseid", SqlDbType.Int)
        arParms(5).Value = Courseid

        arParms(6) = New SqlParameter("@Fname", SqlDbType.VarChar, 50)
        arParms(6).Value = Fname

        arParms(7) = New SqlParameter("@AdmitFlag", SqlDbType.VarChar, 2)
        arParms(7).Value = AdmitFlag

        arParms(8) = New SqlParameter("@Source", SqlDbType.VarChar, 50)
        arParms(8).Value = Source

        arParms(9) = New SqlParameter("@ERealatedTo", SqlDbType.VarChar, 50)
        arParms(9).Value = ERealatedTo

        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_EnquiryDetails", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function insertBranch() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectBranchCombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetYear() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelAcademicYear", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetCourse(ByVal Branchcode As String) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = Branchcode

        arParms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BranchCourseCombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertCourse(ByVal Branchcode As String) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        If Branchcode = "0" Then
            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("Branchcode")
        Else
            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = Branchcode
        End If
        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_CourseComboAll", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertBatch(ByVal Aid As Integer, ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@AYear", SqlDbType.Int)
        arParms(1).Value = Aid

        arParms(2) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(2).Value = CourseID

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BatchComboRPT1", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertOpenBatch(ByVal Aid As Integer, ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@AYear", SqlDbType.Int)
        arParms(1).Value = Aid

        arParms(1) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(1).Value = CourseID

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BatchComboWithCourse&AYReport", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertOpenBatch1(ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        'arParms(1) = New SqlParameter("@AYear", SqlDbType.Int)
        'arParms(1).Value = Aid

        arParms(1) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(1).Value = CourseID

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BatchComboWithCourse", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetSemester(ByVal BatchID As Integer, ByVal BranchCode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(1).Value = BatchID

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[proc_StudentRegisterSemesterCombo]", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetStudentReportCombo(ByVal BatchID As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(2).Value = BatchID

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdByBatch", arParms)
        Return ds.Tables(0)
    End Function
    Public Function Rpt_TimeTable(ByVal Course As Integer, ByVal Batch As Integer, ByVal Semester As Integer, ByVal Subject As Integer, ByVal Teacher As Integer, ByVal WeekNo As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(2).Value = Course

        arParms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(3).Value = Batch

        arParms(4) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(4).Value = Semester

        arParms(5) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(5).Value = Subject

        arParms(6) = New SqlParameter("@TeacherId", SqlDbType.Int)
        arParms(6).Value = Teacher

        arParms(7) = New SqlParameter("@WeekNo", SqlDbType.Int)
        arParms(7).Value = WeekNo
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_TimeTable", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function stddetails() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim rowsAffected As Integer = 0
        Dim dt As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Studentcode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("StudentCode")



        '  dt = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "Proc_StudentDashboard", arParms)
        dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_StudentDetails", arParms)


        Return dt.Tables(0)
    End Function
    Public Function Rpt_TimeTableTeacher(ByVal Course As Integer, ByVal Batch As Integer, ByVal Semester As Integer, ByVal Subject As Integer, ByVal Teacher As Integer, ByVal WeekNo As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(2).Value = Course

        arParms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(3).Value = Batch

        arParms(4) = New SqlParameter("@SemId", SqlDbType.Int)
        arParms(4).Value = Semester

        arParms(5) = New SqlParameter("@SubjectId", SqlDbType.Int)
        arParms(5).Value = Subject

        arParms(6) = New SqlParameter("@TeacherId", SqlDbType.Int)
        arParms(6).Value = Teacher

        arParms(7) = New SqlParameter("@WeekNo", SqlDbType.Int)
        arParms(7).Value = WeekNo
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_NewTimeTableTeacher", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSubject(ByVal BatchId As Integer, ByVal SemCode As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = BatchId

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemCode

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SubjectAll", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectMeritList(ByVal Batchid As String, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.VarChar, 500)
            Parms(2).Value = Batchid

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SubjectAll_MeritList", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetStudentDtlsForParent() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, HttpContext.Current.Session("BranchCode").length)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("BatchID")

        arParms(2) = New SqlParameter("@StdCode", SqlDbType.VarChar, HttpContext.Current.Session("StudentCode").length)
        arParms(2).Value = HttpContext.Current.Session("StudentCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentDtlsForParent", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetBranch() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BranchComboAll", arParms)
        Return ds.Tables(0)
    End Function
    Public Function TimeTableTeacherRpt(ByVal Teacher As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@TeacherId", SqlDbType.Int)
        arParms(2).Value = Teacher
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_TimeTableTeacherNew", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetStudentNameCombo(ByVal Batch As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = Batch

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_StudentAll", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function insertBranchCombo() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectBranchComboAll", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertBranchCombo1() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectBranchComboMinistry", arParms)
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Shared Function insertBranchComboMinistry() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "BranchComboMinistry", arParms)
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Shared Function insertBranchComboUniversity() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "BranchComboUniversity", arParms)
        If ds.Tables.Count = 0 Then
            Return Nothing
        Else
            Return ds.Tables(0)
        End If
    End Function
    Shared Function BranchCombo() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@Accesslevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectBranch", arParms)
        Return ds.Tables(0)
    End Function

    Public Function TransportRegRpt(ByVal A_code As Integer, ByVal RouteId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@A_code", SqlDbType.Int)
        arParms(2).Value = A_code

        arParms(3) = New SqlParameter("@RouteId", SqlDbType.Int)
        arParms(3).Value = RouteId
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_TransportRegistration", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function SelectBranch() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_BranchCombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function SelectAcademicYear() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_AcademicYearCombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function SelectCourse(ByVal Branchcode As String) As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = Branchcode



        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_BranchCourseCombo", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function SelectBatch(ByVal Aid As Integer, ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@AYear", SqlDbType.Int)
        arParms(1).Value = Aid

        arParms(2) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(2).Value = CourseID

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BatchComboRPT", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function SelectCountry() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_CountryCombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertBatch(ByVal Courseid As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        'arParms(2) = New SqlParameter("@A_Year", SqlDbType.Int)
        'arParms(2).Value = A_Code

        arParms(2) = New SqlParameter("@Crs", SqlDbType.Int)
        arParms(2).Value = Courseid

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BatchDDL", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetSubjectAll(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
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
    Shared Function SelectAcademicYear1(ByVal BranchCode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = BranchCode

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_AcademicYearCombo1", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetStudentNameCombo1(ByVal BranchCode As String, ByVal Batch As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = BranchCode
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = Batch

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_StudentAll", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetYear1(ByVal BranchCode As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = BranchCode

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelAcademicYear", arParms)
        Return ds.Tables(0)
    End Function
    Public Function GetStudentReportCombo1(ByVal BranchCode As String, ByVal BatchID As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = BranchCode
        arParms(2) = New SqlParameter("@BatchID", SqlDbType.Int)
        arParms(2).Value = BatchID

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdByBatch", arParms)
        Return ds.Tables(0)
    End Function
    'Multilingual for Report Headings.
    Shared Function EnquiryDetailsHeading(ByVal FormName As String, ByVal LanguageID As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim arParms() As SqlParameter = New SqlParameter(1) {}


        arParms(0) = New SqlParameter("@FormName", SqlDbType.VarChar)
        arParms(0).Value = FormName

        arParms(1) = New SqlParameter("@LanguageID", SqlDbType.Int)
        arParms(1).Value = LanguageID


        Dim ds As DataSet
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_EnquiryDetailsHeading]", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSubjectAll1(ByVal BranchCode As String, ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
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
    Public Function Rpt_StudentPerformanceRptOverall(ByVal Batch As Integer, ByVal StdId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = Batch

        arParms(2) = New SqlParameter("@StdId", SqlDbType.Int)
        arParms(2).Value = StdId


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentPercentageOverall", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetStudentDtlsForParent1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, HttpContext.Current.Session("BranchCode").length)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("BatchID")

        arParms(2) = New SqlParameter("@StdCode", SqlDbType.VarChar, HttpContext.Current.Session("StudentCode").length)
        arParms(2).Value = HttpContext.Current.Session("StudentCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetStdCurrentSem", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetSubjectSelect(ByVal BranchCode As String, ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubjectNew", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetStudentDtlsforStudlogin() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, HttpContext.Current.Session("BranchCode").length)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("BatchID")

        arParms(2) = New SqlParameter("@StdCode", SqlDbType.VarChar, HttpContext.Current.Session("StudentCode").length)
        arParms(2).Value = HttpContext.Current.Session("StudentCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_GetStdCurrentDetails", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetTopStuds(ByVal Batch As String, ByVal Sem As Integer, ByVal Top As Integer, ByVal Bottom As Integer, ByVal Gender As Integer, ByVal RBType As Integer) As Data.DataTable
        Try

            Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim para() As SqlParameter = New SqlParameter(7) {}

            para(0) = New SqlParameter("@Batch", SqlDbType.VarChar, 500)
            para(0).Value = Batch

            para(1) = New SqlParameter("@Semester", SqlDbType.Int)
            para(1).Value = Sem

            'para(2) = New SqlParameter("@Subject", SqlDbType.Int)
            'para(2).Value = Subject

            'para(3) = New SqlParameter("@AssessmentType", SqlDbType.Int)
            'para(3).Value = AssessmentType

            para(2) = New SqlParameter("@Top", SqlDbType.Int)
            para(2).Value = Top

            para(3) = New SqlParameter("@Bottom", SqlDbType.Int)
            para(3).Value = Bottom

            para(4) = New SqlParameter("@Gender", SqlDbType.Int)
            para(4).Value = Gender

            para(5) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(5).Value = HttpContext.Current.Session("BranchCode")

            para(6) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            para(6).Value = HttpContext.Current.Session("Office")

            para(7) = New SqlParameter("@RBtype", SqlDbType.Int)
            para(7).Value = RBType

            Try
                ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "[Rpt_MeritListTpBtm]", para)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        Catch e As Exception

        End Try
    End Function
    Public Function GetTopStudents(ByVal Batch As String, ByVal Sem As Integer, ByVal Top As Integer, ByVal Bottom As Integer, ByVal Gender As Integer, ByVal RBType As Integer) As Data.DataTable
        Dim dt As DataTable
        Dim dl As New DLReportsR
        dt = dl.GetTopStuds(Batch, Sem, Top, Bottom, Gender, RBType)
        Dim i As Integer = dt.Rows.Count - 1
        While (i >= 0)
            If dt.Rows(i)("Std_Photo").ToString <> "" Then
                Dim s As String = HttpContext.Current.Server.MapPath(dt.Rows(i)("Std_Photo").ToString)
                If File.Exists(s) Then
                    LoadImage(dt.Rows(i), "image_stream", s)
                Else
                    LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
                End If
            Else
                LoadImage(dt.Rows(i), "image_stream", "~/Images/imageupload.gif")
            End If

            If dt.Rows(i)("Std_PhotoB").ToString <> "" Then
                Dim s As String = HttpContext.Current.Server.MapPath(dt.Rows(i)("Std_PhotoB").ToString)
                If File.Exists(s) Then
                    LoadImage(dt.Rows(i), "image_streamB", s)
                Else
                    LoadImage(dt.Rows(i), "image_streamB", "~/Images/imageupload.gif")
                End If
            Else
                LoadImage(dt.Rows(i), "image_streamB", "~/Images/imageupload.gif")
            End If
            i = i - 1
        End While
        Return dt
    End Function
    Shared Sub LoadImage(ByVal objDataRow As DataRow, ByVal strImageField As String, ByVal FilePath As String)
        Try
            Dim fs As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
            Dim Image(fs.Length) As Byte
            fs.Read(Image, 0, CInt(fs.Length))
            fs.Close()
            objDataRow(strImageField) = Image
        Catch ex As Exception
            'Response.Write("<font color=red>" + ex.Message + "</font>")
        End Try
    End Sub

    Public Function GetBottomStuds(ByVal Batch As String, ByVal Sem As Integer, ByVal Subject As Integer, ByVal AssessmentType As Integer, ByVal Top As Integer, ByVal Bottom As Integer, ByVal Gender As Integer) As Data.DataTable
        Try

            Dim connectionstring As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            Dim ds As New DataSet

            Dim para() As SqlParameter = New SqlParameter(8) {}

            para(0) = New SqlParameter("@Batch", SqlDbType.VarChar, 500)
            para(0).Value = Batch

            para(1) = New SqlParameter("@Semester", SqlDbType.Int)
            para(1).Value = Sem

            para(2) = New SqlParameter("@Subject", SqlDbType.Int)
            para(2).Value = Subject

            para(3) = New SqlParameter("@AssessmentType", SqlDbType.Int)
            para(3).Value = AssessmentType

            para(4) = New SqlParameter("@Top", SqlDbType.Int)
            para(4).Value = Top

            para(5) = New SqlParameter("@Bottom", SqlDbType.Int)
            para(5).Value = Bottom

            para(6) = New SqlParameter("@Gender", SqlDbType.Int)
            para(6).Value = Gender

            para(7) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            para(7).Value = HttpContext.Current.Session("BranchCode")

            para(8) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            para(8).Value = HttpContext.Current.Session("Office")

            Try
                ds = SqlHelper.ExecuteDataset(connectionstring, CommandType.StoredProcedure, "[Rpt_MeritListBottom]", para)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
            Return ds.Tables(0)
        Catch e As Exception

        End Try
    End Function
    Public Function Rpt_ManagementDashboard(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Rpt_ManagementDashBoard", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Rpt_ManagementDashboardUniv(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_ManagementDashBoardUniv", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Rpt_ManagementDashboardMin(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_ManagementDashBoardMin", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Rpt_ManagementDashboardMinGraph(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_ManagementDashBoardMinGraph", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function Rpt_StreamwiseDashboard(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StreamwiseEnrol_Dashboard", Parms)
            'Old Procedure Name : Rpt_Streamwise_Enrol_Dashboard
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetWeekNo() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Try
            Dim arParms() As SqlParameter = New SqlParameter(1) {}

            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")

            arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            arParms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetWeekNoNew", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            'MsgBox(ex.ToString)
        End Try

    End Function
    Public Function Rpt_EmployeeTransfer(ByVal BranchCode As String, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@SessionBranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
            Parms(2).Value = FromDate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.DateTime)
            Parms(3).Value = ToDate
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_EmployeeTransfer", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Shared Function GetSubjectforPublish(ByVal BatchId As Integer, ByVal SemId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@batchid", SqlDbType.Int)
            Parms(2).Value = BatchId

            Parms(3) = New SqlParameter("@SemesterId", SqlDbType.Int)
            Parms(3).Value = SemId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SubjectAll", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class

