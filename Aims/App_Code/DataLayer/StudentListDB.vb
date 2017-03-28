Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class StudentListDB

    Dim e As StudentE
    Dim BranchCode As String
    Shared Function insertBranch() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BranchCombo", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetAdmissionReport(ByVal Branch As String, ByVal Course As Integer, ByVal Batch As Integer, ByVal AYear As Integer, ByVal Gender As String, ByVal State As Integer, ByVal Feecollected As String, ByVal Country As String, ByVal District As String, ByVal FromAge As Integer, ByVal ToAge As Integer, ByVal categry As Integer, ByVal Caste As Integer, ByVal Hostel As String, ByVal Transport As String, ByVal CurrentDate As DateTime) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(16) {}
        If Branch = "0" Then
            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")
        Else
            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = Branch
        End If
        arParms(1) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(1).Value = Course
        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = Batch
        arParms(3) = New SqlParameter("@AYear", SqlDbType.Int)
        arParms(3).Value = AYear
        arParms(4) = New SqlParameter("@Gender", SqlDbType.VarChar, 50)
        arParms(4).Value = Gender
        arParms(5) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(5).Value = State
        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")
        arParms(7) = New SqlParameter("@Feecollected", SqlDbType.VarChar, 50)
        arParms(7).Value = Feecollected
        arParms(8) = New SqlParameter("@country", SqlDbType.VarChar, 50)
        arParms(8).Value = Country
        arParms(9) = New SqlParameter("@District", SqlDbType.VarChar, 50)
        arParms(9).Value = District
        arParms(10) = New SqlParameter("@FromAge", SqlDbType.VarChar, 50)
        arParms(10).Value = FromAge
        arParms(11) = New SqlParameter("@ToAge", SqlDbType.VarChar, 50)
        arParms(11).Value = ToAge
        arParms(12) = New SqlParameter("@StdCategory", SqlDbType.Int)
        arParms(12).Value = categry
        arParms(13) = New SqlParameter("@Caste", SqlDbType.Int)
        arParms(13).Value = Caste
        arParms(14) = New SqlParameter("@Hostel", SqlDbType.VarChar, 50)
        arParms(14).Value = Hostel
        arParms(15) = New SqlParameter("@Transport", SqlDbType.VarChar, 50)
        arParms(15).Value = Transport
        arParms(16) = New SqlParameter("@CurrentDate", SqlDbType.DateTime)
        arParms(16).Value = CurrentDate

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_AdmissionDetails", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetAdmissionReport1(ByVal Branch As String, ByVal Course As Integer, ByVal Batch As Integer, ByVal AYear As Integer, ByVal Gender As String, ByVal State As Integer, ByVal Feecollected As String, ByVal Country As String, ByVal District As String, ByVal FromAge As Integer, ByVal ToAge As Integer, ByVal categry As Integer, ByVal Caste As Integer, ByVal Hostel As String, ByVal Transport As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(15) {}
        If Branch = "0" Then
            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = HttpContext.Current.Session("BranchCode")
        Else
            arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            arParms(0).Value = Branch
        End If
        arParms(1) = New SqlParameter("@Course", SqlDbType.Int)
        arParms(1).Value = Course
        arParms(2) = New SqlParameter("@Batch", SqlDbType.Int)
        arParms(2).Value = Batch
        arParms(3) = New SqlParameter("@AYear", SqlDbType.Int)
        arParms(3).Value = AYear
        arParms(4) = New SqlParameter("@Gender", SqlDbType.VarChar, 50)
        arParms(4).Value = Gender
        arParms(5) = New SqlParameter("@State", SqlDbType.VarChar, 50)
        arParms(5).Value = State
        arParms(6) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(6).Value = HttpContext.Current.Session("Office")
        arParms(7) = New SqlParameter("@Feecollected", SqlDbType.VarChar, 50)
        arParms(7).Value = Feecollected
        arParms(8) = New SqlParameter("@country", SqlDbType.VarChar, 50)
        arParms(8).Value = Country
        arParms(9) = New SqlParameter("@District", SqlDbType.VarChar, 50)
        arParms(9).Value = District
        arParms(10) = New SqlParameter("@FromAge", SqlDbType.VarChar, 50)
        arParms(10).Value = FromAge
        arParms(11) = New SqlParameter("@ToAge", SqlDbType.VarChar, 50)
        arParms(11).Value = ToAge
        arParms(12) = New SqlParameter("@StdCategory", SqlDbType.Int)
        arParms(12).Value = categry
        arParms(13) = New SqlParameter("@Caste", SqlDbType.Int)
        arParms(13).Value = Caste
        arParms(14) = New SqlParameter("@Hostel", SqlDbType.VarChar, 50)
        arParms(14).Value = Hostel
        arParms(15) = New SqlParameter("@Transport", SqlDbType.VarChar, 50)
        arParms(15).Value = Transport

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_AdmissionDetail", arParms)
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


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetNewBatchSelect", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertBatchOpen(ByVal BranchCode As String, ByVal Aid As Integer, ByVal CourseID As Integer) As DataTable

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


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BatchComboWithCourse&AYReport", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function BatchOpen(ByVal A_Year As Integer, ByVal Course As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        arParms(1).Value = A_Year

        arParms(2) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(2).Value = Course

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Proc_GetBatchAll]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertOpenBatch(ByVal Aid As Integer, ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable

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


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_OpenBatchComboRPT", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertBatch1(ByVal Aid As Integer, ByVal CourseID As Integer, ByVal BranchCode As String) As DataTable

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
    Shared Function insertSemester() As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectSemester", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function summaryRpt(ByVal BranchCode As String, ByVal CId As Integer, ByVal BNo As Integer, ByVal doj As Integer, ByVal fromdate As Date, ByVal todate As Date, ByVal SemID As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(1).Value = CId

        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = BNo

        'arParms(3) = New SqlParameter("@Ayear", SqlDbType.VarChar, 50)
        'arParms(3).Value = Ayear

        arParms(3) = New SqlParameter("@DojDol", SqlDbType.Int)
        arParms(3).Value = doj

        If fromdate = "1/1/1900" Then
            arParms(4) = New SqlParameter("@fromdate", SqlDbType.DateTime)
            arParms(4).Value = System.DBNull.Value
        Else
            arParms(4) = New SqlParameter("@fromdate", SqlDbType.DateTime)
            arParms(4).Value = fromdate
            fromdate = Format(fromdate, "dd-MMM-yyyy")
        End If

        arParms(5) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(5).Value = todate
        todate = Format(todate, "dd-MMM-yyyy")

        arParms(6) = New SqlParameter("@SemID", SqlDbType.Int)
        arParms(6).Value = SemID

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_StdSummary", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function detailedRpt(ByVal BranchCode As String, ByVal CId As Integer, ByVal BNo As Integer, ByVal doj As Integer, ByVal fromdate As Date, ByVal todate As Date, ByVal semid As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = BranchCode

        arParms(2) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(2).Value = CId

        arParms(3) = New SqlParameter("@BatchNo", SqlDbType.Int)
        arParms(3).Value = BNo

        'arParms(4) = New SqlParameter("@Ayear", SqlDbType.VarChar, 50)
        'arParms(4).Value = Ayear

        arParms(4) = New SqlParameter("@DojDol", SqlDbType.Int)
        arParms(4).Value = doj

        arParms(5) = New SqlParameter("@semid", SqlDbType.Int)
        arParms(5).Value = semid

        If fromdate = "1/1/1900" Then
            arParms(6) = New SqlParameter("@fromdate", SqlDbType.DateTime)
            arParms(6).Value = System.DBNull.Value
        Else
            arParms(6) = New SqlParameter("@fromdate", SqlDbType.DateTime)
            arParms(6).Value = fromdate
            fromdate = Format(fromdate, "dd-MMM-yyyy")
        End If

        arParms(7) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(7).Value = todate
        todate = Format(todate, "dd-MMM-yyyy")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_STDRegisterDetail", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function detailedRptSort(ByVal BranchCode As String, ByVal CId As Integer, ByVal BNo As Integer, ByVal doj As Integer, ByVal fromdate As Date, ByVal todate As Date, ByVal semid As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(7) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = BranchCode

        arParms(2) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(2).Value = CId

        arParms(3) = New SqlParameter("@BatchNo", SqlDbType.Int)
        arParms(3).Value = BNo

        'arParms(4) = New SqlParameter("@Ayear", SqlDbType.VarChar, 50)
        'arParms(4).Value = Ayear

        arParms(4) = New SqlParameter("@DojDol", SqlDbType.Int)
        arParms(4).Value = doj

        If fromdate = "1/1/1900" Then
            arParms(5) = New SqlParameter("@fromdate", SqlDbType.DateTime)
            arParms(5).Value = System.DBNull.Value
        Else
            arParms(5) = New SqlParameter("@fromdate", SqlDbType.DateTime)
            arParms(5).Value = fromdate
            fromdate = Format(fromdate, "dd-MMM-yyyy")
        End If

        arParms(6) = New SqlParameter("@todate", SqlDbType.DateTime)
        arParms(6).Value = todate
        todate = Format(todate, "dd-MMM-yyyy")

        arParms(7) = New SqlParameter("@semid", SqlDbType.Int)
        arParms(7).Value = semid


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_STDRegisterDetailSort", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function finalExamRpt(ByVal Brid As String, ByVal Cid As Integer, ByVal Aid As Integer, ByVal Bid As Integer, ByVal Sid As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = Brid

        arParms(1) = New SqlParameter("@CourseId", SqlDbType.Int)
        arParms(1).Value = Cid

        arParms(2) = New SqlParameter("@AcademicYearId", SqlDbType.Int)
        arParms(2).Value = Aid

        arParms(3) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(3).Value = Bid

        arParms(4) = New SqlParameter("@SemesterId", SqlDbType.Int)
        arParms(4).Value = Sid

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Rpt_FinalExaminationResult", arParms)
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

    Shared Function BatchOpen1(ByVal BranchCode As String, ByVal A_Year As Integer, ByVal Course As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = BranchCode

        arParms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        arParms(1).Value = A_Year

        arParms(2) = New SqlParameter("@CourseID", SqlDbType.Int)
        arParms(2).Value = Course

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Proc_GetBatchAll]", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function insertBatchOpenN(ByVal BranchCode As String, ByVal CourseID As Integer) As DataTable

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


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_BatchComboWithCourse&AYNew", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function insertSemesterGvsSub() As Data.DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "New_SelectSemester1", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function BatchAcademic(ByVal A_Year As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        arParms(1).Value = A_Year

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Proc_GetBatchAcademicYear]", arParms)
        Return ds.Tables(0)

    End Function
    Shared Function BatchAcademicStudent(ByVal A_Year As Integer, ByVal batch As Integer) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@A_Year", SqlDbType.Int)
        arParms(1).Value = A_Year

        arParms(2) = New SqlParameter("@batchId", SqlDbType.Int)
        arParms(2).Value = batch

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Proc_GetBatchAcademicYearStudent]", arParms)
        Return ds.Tables(0)
    End Function
End Class
