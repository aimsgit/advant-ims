Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLPrinicipalDashBoard
    Shared Function GetCategoryyyALL1() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetCategoryALL", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetAcademicCombo() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}
           
            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")


            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "NewAcademicYearforPrinicipalDashboard", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCourseComboAdmission() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CourseComboPrinicipalDash", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetCourseComboAdmission1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_CourseComboPrinicipalDash1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSemComboAdmission1() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SemComboPrinicipalDash1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function


    Shared Function getassessmentDDL() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "AssessmentTypeDDLForRptMarks", arParms)
        Return ds.Tables(0)
    End Function
    'Rpt_PrinciDashMarksDetail

    Public Function RptMarksSummaryReport(ByVal AcademicYear As Integer, ByVal Course As Integer, ByVal Category As Integer, ByVal AssessmentType As Integer, ByVal FromPer As Integer, ByVal ToPer As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(6) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
            Parms(1).Value = AcademicYear

            Parms(2) = New SqlParameter("@Course", SqlDbType.Int)
            Parms(2).Value = Course

            Parms(3) = New SqlParameter("@S_Category", SqlDbType.Int)
            Parms(3).Value = Category

            Parms(4) = New SqlParameter("@Assessment", SqlDbType.Int)
            Parms(4).Value = AssessmentType

            Parms(5) = New SqlParameter("@FromPer", SqlDbType.Int)
            Parms(5).Value = FromPer

            Parms(6) = New SqlParameter("@ToPer", SqlDbType.Int)
            Parms(6).Value = ToPer


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_MarksSummaryReportDB", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

   
    Public Function GetMArksDetails(ByVal AcademicYear As Integer, ByVal Course As Integer, ByVal Category As Integer, ByVal FromPer As Integer, ByVal ToPer As Integer, ByVal AssessmentType As Integer, ByVal Sem As Integer, ByVal Caste As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(9) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@AYear", SqlDbType.Int)
            Parms(2).Value = AcademicYear
            Parms(3) = New SqlParameter("@Course", SqlDbType.Int)
            Parms(3).Value = Course
            Parms(4) = New SqlParameter("@SCatogry", SqlDbType.Int)
            Parms(4).Value = Category
            Parms(5) = New SqlParameter("@FromP", SqlDbType.Int)
            Parms(5).Value = FromPer
            Parms(6) = New SqlParameter("@Topercent", SqlDbType.Int)
            Parms(6).Value = ToPer
            Parms(7) = New SqlParameter("@AssessmentType", SqlDbType.Int)
            Parms(7).Value = AssessmentType
            Parms(8) = New SqlParameter("@Sem", SqlDbType.Int)
            Parms(8).Value = Sem
            Parms(9) = New SqlParameter("@Caste", SqlDbType.Int)
            Parms(9).Value = Caste

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_PrinicipalDashMarksDetails", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetAdmissionSum(ByVal AcademicYear As Integer, ByVal Course As Integer, ByVal Category As Integer, ByVal A_Race As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(5) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@AcademicYear", SqlDbType.Int)
            Parms(2).Value = AcademicYear
            Parms(3) = New SqlParameter("@Course", SqlDbType.Int)
            Parms(3).Value = Course
            Parms(4) = New SqlParameter("@Category", SqlDbType.Int)
            Parms(4).Value = Category
            Parms(5) = New SqlParameter("@A_Race", SqlDbType.Int)
            Parms(5).Value = A_Race

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetPrinicipalDashAdmissionSumm", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetAdmissionDet(ByVal AcademicYear As Integer, ByVal Course As Integer, ByVal Category As Integer, ByVal A_Race As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(5) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@AcademicYear", SqlDbType.Int)
            Parms(2).Value = AcademicYear
            Parms(3) = New SqlParameter("@Course", SqlDbType.Int)
            Parms(3).Value = Course
            Parms(4) = New SqlParameter("@Category", SqlDbType.Int)
            Parms(4).Value = Category
            Parms(5) = New SqlParameter("@A_Race", SqlDbType.Int)
            Parms(5).Value = A_Race


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetPrinicipalDashAdmissionDet", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Public Function GetFeeCollectionSum(ByVal AcademicYear As Integer, ByVal Course As Integer, ByVal Category As Integer, ByVal FCaste As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Ayear", SqlDbType.Int)
            Parms(1).Value = AcademicYear
            Parms(2) = New SqlParameter("@Course", SqlDbType.Int)
            Parms(2).Value = Course
            Parms(3) = New SqlParameter("@Category", SqlDbType.Int)
            Parms(3).Value = Category
            Parms(4) = New SqlParameter("@Caste", SqlDbType.Int)
            Parms(4).Value = FCaste

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_PrincipalDashFeesummaryReport", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
 
    Public Function GetFeeCollectionDetails(ByVal AcademicYear As Integer, ByVal Course As Integer, ByVal Category As Integer, ByVal FCaste As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Ayear", SqlDbType.Int)
            Parms(1).Value = AcademicYear
            Parms(2) = New SqlParameter("@Course", SqlDbType.Int)
            Parms(2).Value = Course
            Parms(3) = New SqlParameter("@Category", SqlDbType.Int)
            Parms(3).Value = Category
            Parms(4) = New SqlParameter("@Caste", SqlDbType.Int)
            Parms(4).Value = FCaste
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_PrincipalDashFeeDetails", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetWorlFlowReport(ByVal AcademicYear As Integer, ByVal Course As Integer, ByVal percentage As Integer, ByVal category As Integer, ByVal caste As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(6) {}


        para(0) = New SqlParameter("@Office", SqlDbType.VarChar)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@Course", SqlDbType.Int)
        para(2).Value = Course

        para(3) = New SqlParameter("@category", SqlDbType.Int)
        para(3).Value = category

        para(4) = New SqlParameter("@Percentage", SqlDbType.Int)
        para(4).Value = percentage



        para(5) = New SqlParameter("@AYear", SqlDbType.Int)
        para(5).Value = AcademicYear

        para(6) = New SqlParameter("@caste", SqlDbType.Int)
        para(6).Value = caste


        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_AttenDashBoard", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetWorlFlowReportSumm(ByVal AcademicYear As Integer, ByVal Course As Integer, ByVal percentage As Integer, ByVal category As Integer, ByVal caste As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim para() As SqlParameter = New SqlParameter(6) {}


        para(0) = New SqlParameter("@Office", SqlDbType.VarChar)
        para(0).Value = HttpContext.Current.Session("Office")

        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
        para(1).Value = HttpContext.Current.Session("BranchCode")

        para(2) = New SqlParameter("@Course", SqlDbType.Int)
        para(2).Value = Course


        para(3) = New SqlParameter("@Percentage", SqlDbType.Int)
        para(3).Value = percentage



        para(4) = New SqlParameter("@AYear", SqlDbType.Int)
        para(4).Value = AcademicYear

        para(5) = New SqlParameter("@category", SqlDbType.Int)
        para(5).Value = category

        para(6) = New SqlParameter("@caste", SqlDbType.Int)
        para(6).Value = caste

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_AttenDashBoardSumm", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function CasteCombo() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlClient.SqlParameter("@Office", SqlDbType.VarChar)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetCasteDDLPrincDash", arParms)
        Return ds.Tables(0)
    End Function
End Class
