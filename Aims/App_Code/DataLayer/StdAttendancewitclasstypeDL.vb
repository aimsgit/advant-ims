Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports Attendance


Public Class StdAttendancewitclasstypeDL
    Public Function InsertAttandanceCT(ByVal a As StdAttendanceP) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(10) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = a.Academic
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = a.Batch
        param(3) = New SqlParameter("@Semester", SqlDbType.Int)
        param(3).Value = a.SemesterId
        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = a.SubjectId
        param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        param(5).Value = a.ClassType
        param(6) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(6).Value = a.AttendanceDate
        param(7) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        param(7).Value = a.SessionCountDay
        param(8) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(8).Value = HttpContext.Current.Session("UserCode")
        param(9) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(9).Value = HttpContext.Current.Session("EmpCode")
        param(10) = New SqlParameter("@SubGrp", SqlDbType.Int)
        param(10).Value = a.SubGrp


        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_InsertStudentAttendanceCT", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Return Rowseffected
    End Function
    Public Function GetBatch(ByVal a As StdAttendanceP) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = a.Academic
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = a.Batch
        param(3) = New SqlParameter("@Semester", SqlDbType.Int)
        param(3).Value = a.SemesterId
        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = a.SubjectId
        'param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        'param(5).Value = a.ClassType
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = a.ElecSub
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBatchStatus", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function

    Public Function GetByGVStdAttdCT(ByVal a As StdAttendanceP) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(9) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = a.Academic
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = a.Batch
        param(3) = New SqlParameter("@Semester", SqlDbType.Int)
        param(3).Value = a.SemesterId
        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = a.SubjectId
        param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        param(5).Value = a.ClassType
        param(6) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(6).Value = a.AttendanceDate
        param(7) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        param(7).Value = a.SessionCountDay
        param(8) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(8).Value = HttpContext.Current.Session("Office")
        param(9) = New SqlParameter("@SubGrp", SqlDbType.Int)
        param(9).Value = a.SubGrp

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_ViewStudentAttendanceCT", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function
    Public Function AttendanceduplicateCT(ByVal a As StdAttendanceP) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(8) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = a.Academic
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = a.Batch
        param(3) = New SqlParameter("@Semester", SqlDbType.Int)
        param(3).Value = a.SemesterId
        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = a.SubjectId
        param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        param(5).Value = a.ClassType
        param(6) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(6).Value = a.AttendanceDate
        param(7) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        param(7).Value = a.SessionCountDay
        param(8) = New SqlParameter("@SubGrp", SqlDbType.Int)
        param(8).Value = a.SubGrp

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_AttendanceDuplicateCT", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Public Function GetStudentReport(ByVal AT As Integer, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal CT As Integer, ByVal StdId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Min As Integer, ByVal Max As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(10) {}
        param(0) = New SqlParameter("@ayear", SqlDbType.Int)
        param(0).Value = AT
        param(1) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@batch", SqlDbType.Int)
        param(2).Value = Bat
        param(3) = New SqlParameter("@semid", SqlDbType.Int)
        param(3).Value = Sem
        param(4) = New SqlParameter("@subid", SqlDbType.Int)
        param(4).Value = Subj
        param(5) = New SqlParameter("@classid", SqlDbType.Int)
        param(5).Value = CT
        param(6) = New SqlParameter("@StdId", SqlDbType.Int)
        param(6).Value = StdId
        param(7) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        param(7).Value = fromdate
        param(8) = New SqlParameter("@todate", SqlDbType.DateTime)
        param(8).Value = todate
        param(9) = New SqlParameter("@Min", SqlDbType.Int)
        param(9).Value = Min
        param(10) = New SqlParameter("@Max", SqlDbType.Int)
        param(10).Value = Max
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentAttendanceRpt", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Public Function GetStudentDetailedReport(ByVal BR As String, ByVal AT As Integer, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal CT As Integer, ByVal StdId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(9) {}
        param(0) = New SqlParameter("@ayear", SqlDbType.Int)
        param(0).Value = AT
        param(1) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@batch", SqlDbType.Int)
        param(2).Value = Bat
        param(3) = New SqlParameter("@semid", SqlDbType.Int)
        param(3).Value = Sem
        param(4) = New SqlParameter("@subid", SqlDbType.Int)
        param(4).Value = Subj
        param(5) = New SqlParameter("@classid", SqlDbType.Int)
        param(5).Value = CT
        param(6) = New SqlParameter("@StdId", SqlDbType.Int)
        param(6).Value = StdId
        param(7) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        param(7).Value = fromdate
        param(8) = New SqlParameter("@todate", SqlDbType.DateTime)
        param(8).Value = todate
        param(9) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(9).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentAttendanceDetailedRpt", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Shared Function StudentStartEndDate(ByVal batch As Integer, ByVal sem As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@batch", SqlDbType.Int)
        arParms(0).Value = batch

        arParms(1) = New SqlParameter("@sem", SqlDbType.Int)
        arParms(1).Value = sem

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetStartEndDate", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
            Return Nothing
        End Try
    End Function


    Public Function UpdateCollectionVerificationCT(ByVal a As StdAttendanceP) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0

        Dim param() As SqlParameter = New SqlParameter(9) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = a.Academic
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.Int)
        param(2).Value = a.Batch
        param(3) = New SqlParameter("@Semester", SqlDbType.Int)
        param(3).Value = a.SemesterId
        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = a.SubjectId
        param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        param(5).Value = a.ClassType
        param(6) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(6).Value = a.AttendanceDate
        param(7) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        param(7).Value = a.SessionCountDay

        param(8) = New SqlParameter("@Present", SqlDbType.VarChar, 2)
        param(8).Value = a.Present
        param(9) = New SqlParameter("@SubGrp", SqlDbType.Int)
        param(9).Value = a.SubGrp
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateAllAttendanceCT", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return Rowseffected
    End Function
    Public Function CheckLockAttendance(ByVal id As String) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As String = ""

        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        Try
            Rowseffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "proc_CheckLockAttendance", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
    Public Function SendMessage(ByVal id As String, ByVal service As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        param(1) = New SqlParameter("@service", SqlDbType.VarChar, 50)
        param(1).Value = service
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_AttendanceSendMessage", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
            Return Nothing
        End Try
    End Function
    Public Function LockAttendance(ByVal id As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0

        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_LockAttendance", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
    Public Function UnLockAttendance(ByVal id As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0

        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UnLockAttendance", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
    Public Function ClearAttendance(ByVal id As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0

        Dim param() As SqlParameter = New SqlParameter(0) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_ClearAttendance", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
    Public Function UpdateRecord(ByVal a As StdAttendanceP) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(3) {}
        param(0) = New SqlParameter("@id", SqlDbType.Int)
        param(0).Value = a.Id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Present", SqlDbType.VarChar, 2)
        param(2).Value = a.Present
        param(3) = New SqlParameter("@Remarks", SqlDbType.VarChar, 20)
        param(3).Value = a.Remarks
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateAttendance1", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Return Rowseffected
    End Function
    Shared Function ChangeFlag(ByVal El As StdAttendanceP) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = El.Id

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_StdAttdance", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return rowsAffected
    End Function

    Public Function GetStdAttendanceforParent(ByVal ayear As Integer, ByVal Semester As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, HttpContext.Current.Session("BranchCode").length)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@A_year", SqlDbType.Int)
        arParms(1).Value = ayear

        arParms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(2).Value = HttpContext.Current.Session("Batch")

        arParms(3) = New SqlParameter("@Semester", SqlDbType.Int)
        arParms(3).Value = Semester

        arParms(4) = New SqlParameter("@StdId", SqlDbType.VarChar, HttpContext.Current.Session("StudentCode").length)
        arParms(4).Value = HttpContext.Current.Session("StudentID")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdAttendanceforParent", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function GetStdSemester(ByVal BatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(0) {}

        arParms(0) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(0).Value = BatchId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdCurrentSem", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetNewStudentAttendanceReport(ByVal BR As String, ByVal AT As Integer, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal CT As Integer, ByVal StdId As Integer, ByVal Month As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(8) {}


        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = BR

        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")

        param(2) = New SqlParameter("@ayear", SqlDbType.Int)
        param(2).Value = AT

        param(3) = New SqlParameter("@batch", SqlDbType.Int)
        param(3).Value = Bat

        param(4) = New SqlParameter("@semid", SqlDbType.Int)
        param(4).Value = Sem

        param(5) = New SqlParameter("@subid", SqlDbType.Int)
        param(5).Value = Subj

        param(6) = New SqlParameter("@classid", SqlDbType.Int)
        param(6).Value = CT

        param(7) = New SqlParameter("@StdId", SqlDbType.Int)
        param(7).Value = StdId

        param(8) = New SqlParameter("@month", SqlDbType.Int)
        param(8).Value = Month


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_NewStudAttendance", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function

    Public Function GetNewSemAttendListReport(ByVal Bat As Integer, ByVal Sem As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(3) {}

        param(0) = New SqlParameter("@Batch", SqlDbType.Int)
        param(0).Value = Bat

        param(1) = New SqlParameter("@Semester", SqlDbType.Int)
        param(1).Value = Sem

        param(2) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_SemAttenMap", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function GetNewSemAttendListReport1(ByVal Bat As Integer, ByVal Sem As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(3) {}

        param(0) = New SqlParameter("@Batch", SqlDbType.Int)
        param(0).Value = Bat

        param(1) = New SqlParameter("@Semester", SqlDbType.Int)
        param(1).Value = Sem

        param(2) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_SemAttenMap1", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Shared Function PostCheck(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(0) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetUnlockStdAttendance", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Function
    Public Function GetNewSemMarksAttendListReport(ByVal Bat As Integer, ByVal Sem As Integer, ByVal Aid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}

        param(0) = New SqlParameter("@Batch", SqlDbType.Int)
        param(0).Value = Bat

        param(1) = New SqlParameter("@Semester", SqlDbType.Int)
        param(1).Value = Sem

        param(2) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        param(4) = New SqlParameter("@Assessmentid", SqlDbType.Int)
        param(4).Value = Aid


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_SemMarksAttenMap]", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function

    Public Function GetNewSemMarksAttendListReport1(ByVal Bat As Integer, ByVal Sem As Integer, ByVal Aid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}

        param(0) = New SqlParameter("@Batch", SqlDbType.Int)
        param(0).Value = Bat

        param(1) = New SqlParameter("@Semester", SqlDbType.Int)
        param(1).Value = Sem

        param(2) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        param(4) = New SqlParameter("@Assessmentid", SqlDbType.Int)
        param(4).Value = Aid


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_SemMarksAttenMap1]", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Shared Function UnlockCheckStdAttendance(ByVal role As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        Dim ds As New DataSet

        arParms(0) = New SqlParameter("@id ", SqlDbType.NVarChar, 4000)
        arParms(0).Value = role
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_UnlockCheckStdAttendance", arParms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class


