Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Imports Attendance1

Public Class stdAttndanceBySubject

    Public Function InsertAttandance(ByVal a As ELStdAttendancePBySubject) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(9) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = a.Academic
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = a.Batch
        param(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        param(3).Value = a.SemesterId
        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = a.SubjectId
        'param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        'param(5).Value = a.ClassType
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = a.ElecSub
        param(5) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(5).Value = a.AttendanceDate
        param(6) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        param(6).Value = a.SessionCountDay
        param(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(7).Value = HttpContext.Current.Session("UserCode")
        param(8) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(8).Value = HttpContext.Current.Session("EmpCode")
        param(9) = New SqlParameter("@SubGrp", SqlDbType.Int)
        param(9).Value = a.SubGrp
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_InsertStudAttendanceBySub", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Return Rowseffected
    End Function
    Public Function InsertAttandance1(ByVal a As ELStdAttendancePBySubject) As Integer
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
        'param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        'param(5).Value = a.ClassType
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = a.ElecSub
        param(5) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(5).Value = a.AttendanceDate
        param(6) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        param(6).Value = a.SessionCountDay
        param(7) = New SqlParameter("@UserCode", SqlDbType.VarChar, 50)
        param(7).Value = HttpContext.Current.Session("UserCode")
        param(8) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(8).Value = HttpContext.Current.Session("EmpCode")
        param(9) = New SqlParameter("@SubGrp", SqlDbType.Int)
        param(9).Value = a.SubGrp
        param(10) = New SqlParameter("@Std_Id", SqlDbType.Int)
        param(10).Value = a.StdId



        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_InsertStudAttendanceBySub1", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Return Rowseffected
    End Function


    Public Function GetByGVStdAttd(ByVal a As ELStdAttendancePBySubject) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(8) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = a.Academic
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = a.Batch
        param(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        param(3).Value = a.SemesterId
        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = a.SubjectId
        'param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        'param(5).Value = a.ClassType
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = a.ElecSub
        param(5) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(5).Value = a.AttendanceDate
        param(6) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        param(6).Value = a.SessionCountDay
        param(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(7).Value = HttpContext.Current.Session("Office")
        param(8) = New SqlParameter("@SubGrp", SqlDbType.Int)
        param(8).Value = a.SubGrp

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_ViewStudAttendanceBySub", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function
    Public Function GetByGVStdAttdRpt(ByVal AYear As Integer, ByVal Batch As String, ByVal Semester As String, ByVal Subject As Integer, ByVal AttenDate As Date, ByVal SubGrp As Integer, ByVal SessionCountDay As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(8) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = AYear
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = Batch
        param(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        param(3).Value = Semester
        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = Subject
        'param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        'param(5).Value = a.ClassType
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = a.ElecSub
        param(5) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(5).Value = AttenDate
        param(6) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        param(6).Value = SessionCountDay
        param(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(7).Value = HttpContext.Current.Session("Office")
        param(8) = New SqlParameter("@SubGrp", SqlDbType.Int)
        param(8).Value = SubGrp

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_ViewStudAttendanceBySub1", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
    End Function
    Public Function Attendanceduplicate1(ByVal a As ELStdAttendancePBySubject) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(8) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = a.Academic
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = a.Batch
        param(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        param(3).Value = a.SemesterId
        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = a.SubjectId
        'param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        'param(5).Value = a.ClassType
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = a.ElecSub
        param(5) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(5).Value = a.AttendanceDate
        param(6) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        param(6).Value = a.SessionCountDay
        param(7) = New SqlParameter("@SubGrp", SqlDbType.Int)
        param(7).Value = a.SubGrp
        param(8) = New SqlParameter("@Std_Id", SqlDbType.Int)
        param(8).Value = a.StdId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_AttendDuplicate", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Public Function Attendanceduplicate(ByVal a As ELStdAttendancePBySubject) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(7) {}
        param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        param(0).Value = a.Academic

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = a.Batch

        param(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        param(3).Value = a.SemesterId

        param(4) = New SqlParameter("@Subject", SqlDbType.Int)
        param(4).Value = a.SubjectId

        'param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        'param(5).Value = a.ClassType
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = a.ElecSub
        param(5) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(5).Value = a.AttendanceDate

        param(6) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        param(6).Value = a.SessionCountDay

        param(7) = New SqlParameter("@SubGrp", SqlDbType.Int)
        param(7).Value = a.SubGrp

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_AttendDuplicate1", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Public Function GetBatch(ByVal a As ELStdAttendancePBySubject) As Data.DataTable
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetBatchStatus1", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Public Function GetStudentReport(ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal CT As Integer, ByVal StdId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Min As Integer, ByVal Max As Integer, ByVal SortBy As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(10) {}
        'param(0) = New SqlParameter("@ayear", SqlDbType.Int)
        'param(0).Value = AT
        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@batch", SqlDbType.Int)
        param(1).Value = Bat
        param(2) = New SqlParameter("@semid", SqlDbType.Int)
        param(2).Value = Sem
        param(3) = New SqlParameter("@subid", SqlDbType.Int)
        param(3).Value = Subj
        param(4) = New SqlParameter("@classid", SqlDbType.Int)
        param(4).Value = CT
        param(5) = New SqlParameter("@StdId", SqlDbType.Int)
        param(5).Value = StdId
        param(6) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        param(6).Value = fromdate
        param(7) = New SqlParameter("@todate", SqlDbType.DateTime)
        param(7).Value = todate
        param(8) = New SqlParameter("@Min", SqlDbType.Int)
        param(8).Value = Min
        param(9) = New SqlParameter("@Max", SqlDbType.Int)
        param(9).Value = Max
        param(10) = New SqlParameter("@SortBy", SqlDbType.Int)
        param(10).Value = SortBy
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentAttendanceRpt", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Public Function GetStudentDetailedReport(ByVal BR As String, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal CT As Integer, ByVal StdId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal SortBy As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(9) {}
        'param(0) = New SqlParameter("@ayear", SqlDbType.Int)
        'param(0).Value = AT
        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@batch", SqlDbType.Int)
        param(1).Value = Bat
        param(2) = New SqlParameter("@semid", SqlDbType.Int)
        param(2).Value = Sem
        param(3) = New SqlParameter("@subid", SqlDbType.Int)
        param(3).Value = Subj
        param(4) = New SqlParameter("@classid", SqlDbType.Int)
        param(4).Value = CT
        param(5) = New SqlParameter("@StdId", SqlDbType.Int)
        param(5).Value = StdId
        param(6) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        param(6).Value = fromdate
        param(7) = New SqlParameter("@todate", SqlDbType.DateTime)
        param(7).Value = todate
        param(8) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(8).Value = HttpContext.Current.Session("Office")
        param(9) = New SqlParameter("@SortBy", SqlDbType.Int)
        param(9).Value = SortBy
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


    Public Function UpdateCollectionVerification(ByVal a As ELStdAttendancePBySubject) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0

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
        'param(5) = New SqlParameter("@ClassType", SqlDbType.Int)
        'param(5).Value = a.ClassType
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = a.ElecSub
        param(5) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(5).Value = a.AttendanceDate
        param(6) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        param(6).Value = a.SessionCountDay

        param(7) = New SqlParameter("@Present", SqlDbType.VarChar, 2)
        param(7).Value = a.Present
        param(8) = New SqlParameter("@SubGrp", SqlDbType.Int)
        param(8).Value = a.SubGrp
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateAllAttend", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return Rowseffected
    End Function
    Public Function CheckLockAttendance(ByVal id As String) As String
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As String = ""

        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            Rowseffected = SqlHelper.ExecuteScalar(connectionString, CommandType.StoredProcedure, "proc_CheckLockAttendance1", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
    Public Function SendMessage(ByVal id As String, ByVal service As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        param(1) = New SqlParameter("@service", SqlDbType.VarChar, 50)
        param(1).Value = service
        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_AttendSendMessage", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
            Return Nothing
        End Try
    End Function
    Public Function LockAttendance(ByVal id As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0

        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_LockAttendanceBySub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
    Public Function UnLockAttendance(ByVal id As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0

        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_UnLockAttendanceBySub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
    Public Function ClearAttendance(ByVal id As String) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim Rowseffected As Integer = 0

        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@id", SqlDbType.VarChar, 5000)
        param(0).Value = id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "proc_ClearAttendanceBySub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return Rowseffected
    End Function
    Public Function UpdateRecord(ByVal a As ELStdAttendancePBySubject) As Integer
        Dim Rowseffected As Integer = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(6) {}
        param(0) = New SqlParameter("@id", SqlDbType.Int)
        param(0).Value = a.Id
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        param(2) = New SqlParameter("@Present", SqlDbType.VarChar, 2)
        param(2).Value = a.Present
        param(3) = New SqlParameter("@Remarks", SqlDbType.VarChar, 20)
        param(3).Value = a.Remarks
        param(4) = New SqlParameter("@SessionCountDay", SqlDbType.VarChar, 50)
        param(4).Value = a.SessionCountDay
        param(5) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        param(5).Value = a.AttendanceDate
        param(6) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
        param(6).Value = HttpContext.Current.Session("EmpCode")
        Try
            Rowseffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_UpdateAttendanceBySub", param)
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Return Rowseffected
    End Function
    Shared Function ChangeFlag(ByVal El As ELStdAttendancePBySubject) As Integer

        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim rowsAffected As Integer = 0

        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@id", SqlDbType.Int)
        arParms(0).Value = El.Id
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            rowsAffected = SqlHelper.ExecuteNonQuery(connectionString, CommandType.StoredProcedure, "New_StdAttdanceBySub", arParms)
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdAttendforParent", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Function GetStdSemester(ByVal BatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BatchId", SqlDbType.Int)
        arParms(0).Value = BatchId
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStdCurrentSem", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetNewStudentAttendanceReport(ByVal BR As String, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal CT As Integer, ByVal StdId As Integer, ByVal Month As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(7) {}


        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = BR

        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")

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

        param(7) = New SqlParameter("@month", SqlDbType.Int)
        param(7).Value = Month


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_NewStudAttendance", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function

    Public Function GetNewSemAttendListReport(ByVal Bat As Integer, ByVal Sem As Integer, ByVal id As Integer, ByVal Frmdate As Date, ByVal Todate As Date, ByVal Subject As String, ByVal SubSubgrp As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(8) {}

        param(0) = New SqlParameter("@Batch", SqlDbType.Int)
        param(0).Value = Bat

        param(1) = New SqlParameter("@Semester", SqlDbType.Int)
        param(1).Value = Sem

        param(2) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        param(4) = New SqlParameter("@id", SqlDbType.Int)
        param(4).Value = id

        param(5) = New SqlParameter("@Frmdate", SqlDbType.Date)
        param(5).Value = Frmdate

        param(6) = New SqlParameter("@Todate", SqlDbType.Date)
        param(6).Value = Todate

        param(7) = New SqlParameter("@Subject", SqlDbType.VarChar, 50)
        param(7).Value = Subject

        param(8) = New SqlParameter("@SubSubgrp", SqlDbType.VarChar, 50)
        param(8).Value = SubSubgrp


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_SemAttenMap", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function

    Public Function GetNewSemAttendListParentReport(ByVal Bat As Integer, ByVal Sem As Integer, ByVal id As Integer, ByVal Frmdate As Date, ByVal Todate As Date, ByVal Subject As String, ByVal SubSubgrp As String, ByVal Stdid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(9) {}

        param(0) = New SqlParameter("@Batch", SqlDbType.Int)
        param(0).Value = Bat

        param(1) = New SqlParameter("@Semester", SqlDbType.Int)
        param(1).Value = Sem

        param(2) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        param(4) = New SqlParameter("@id", SqlDbType.Int)
        param(4).Value = id

        param(5) = New SqlParameter("@Frmdate", SqlDbType.Date)
        param(5).Value = Frmdate

        param(6) = New SqlParameter("@Todate", SqlDbType.Date)
        param(6).Value = Todate

        param(7) = New SqlParameter("@Subject", SqlDbType.VarChar, 50)
        param(7).Value = Subject

        param(8) = New SqlParameter("@SubSubgrp", SqlDbType.VarChar, 50)
        param(8).Value = SubSubgrp

        param(9) = New SqlParameter("@Stdid", SqlDbType.Int)
        param(9).Value = Stdid



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_SemAttenMapParentLogin", param)
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
    Public Function GetNewSemMarksAttendListReport(ByVal Bat As Integer, ByVal Sem As Integer, ByVal Aid As Integer, ByVal id As Integer, ByVal Srtdate As String, ByVal EndDate As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(7) {}

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

        param(5) = New SqlParameter("@id", SqlDbType.Int)
        param(5).Value = id

        param(6) = New SqlParameter("@SrtDate", SqlDbType.Date)
        param(6).Value = Srtdate

        param(7) = New SqlParameter("@EndDate", SqlDbType.Date)
        param(7).Value = EndDate


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_SemMarksAttenMap]", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function GetNewSemMarksAttendListStudLoginReport(ByVal Bat As Integer, ByVal Sem As Integer, ByVal Aid As Integer, ByVal id As Integer, ByVal Srtdate As String, ByVal EndDate As String, ByVal Stdid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(8) {}

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

        param(5) = New SqlParameter("@id", SqlDbType.Int)
        param(5).Value = id

        param(6) = New SqlParameter("@SrtDate", SqlDbType.Date)
        param(6).Value = Srtdate

        param(7) = New SqlParameter("@EndDate", SqlDbType.Date)
        param(7).Value = EndDate

        param(8) = New SqlParameter("@Stdid", SqlDbType.Int)
        param(8).Value = Stdid



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_SemMarksAttenMapStudLogin]", param)
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
    Shared Function ddlElecSub(ByVal Batch As Integer, ByVal Sem As Integer, ByVal Elecid As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        param(0) = New SqlParameter("@BatchId", SqlDbType.Int)
        param(0).Value = Batch

        param(1) = New SqlParameter("@SemesterId", SqlDbType.Int)
        param(1).Value = Sem

        param(2) = New SqlParameter("@ElectiveId", SqlDbType.Int)
        param(2).Value = Elecid

        param(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")

        param(4) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(4).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[ddlElectiveSub]", param)
        Return ds.Tables(0)
    End Function
    Public Function GetNewStudentAttendanceReportwitDate(ByVal BR As String, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal FromDate As Date, ByVal ToDate As Date, ByVal SortBy As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(7) {}


        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = BR

        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 10)
        param(1).Value = HttpContext.Current.Session("Office")

        'param(2) = New SqlParameter("@ayear", SqlDbType.Int)
        'param(2).Value = AT

        param(2) = New SqlParameter("@batch", SqlDbType.Int)
        param(2).Value = Bat

        param(3) = New SqlParameter("@semid", SqlDbType.Int)
        param(3).Value = Sem

        param(4) = New SqlParameter("@SubId", SqlDbType.Int)
        param(4).Value = Subj

        param(5) = New SqlParameter("@Fromdate", SqlDbType.DateTime)
        param(5).Value = FromDate

        param(6) = New SqlParameter("@Todate", SqlDbType.DateTime)
        param(6).Value = ToDate

        param(7) = New SqlParameter("@SortBy", SqlDbType.Int)
        param(7).Value = SortBy

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_NewStudAttendancewitDate", param)
        Return ds.Tables(0)
    End Function
    Shared Function GetSubjectSelect(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubject", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
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

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_SelectSubjectNew", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function ddlElecSub1(ByVal Batch As Integer, ByVal Sem As Integer, ByVal Subid As Integer) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        param(0) = New SqlParameter("@BatchId", SqlDbType.Int)
        param(0).Value = Batch

        param(1) = New SqlParameter("@SemesterId", SqlDbType.Int)
        param(1).Value = Sem

        param(2) = New SqlParameter("@ElectiveId", SqlDbType.Int)
        param(2).Value = Subid

        param(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")

        param(4) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        param(4).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[ddlElectiveSub]", param)
        Return ds.Tables(0)
    End Function
    Public Function GetStudentElecSubReport(ByVal AT As Integer, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal ES As Integer, ByVal StdId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Min As Integer, ByVal Max As Integer, ByVal SortBy As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(11) {}
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
        param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        param(5).Value = ES
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
        param(11) = New SqlParameter("@SortBy", SqlDbType.Int)
        param(11).Value = SortBy
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentAttendanceElecSub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function

    Public Function GetStudentDetailedReportWitElecSub(ByVal BR As String, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal StdId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal SortBy As Integer, ByVal category As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(9) {}

        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = BR
        param(1) = New SqlParameter("@batch", SqlDbType.Int)
        param(1).Value = Bat
        param(2) = New SqlParameter("@semid", SqlDbType.Int)
        param(2).Value = Sem
        param(3) = New SqlParameter("@subid", SqlDbType.Int)
        param(3).Value = Subj
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = ES
        param(4) = New SqlParameter("@StdId", SqlDbType.Int)
        param(4).Value = StdId
        param(5) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        param(5).Value = fromdate
        param(6) = New SqlParameter("@todate", SqlDbType.DateTime)
        param(6).Value = todate
        param(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(7).Value = HttpContext.Current.Session("Office")
        param(8) = New SqlParameter("@SortBy", SqlDbType.Int)
        param(8).Value = SortBy
        param(9) = New SqlParameter("@category", SqlDbType.Int)
        param(9).Value = category
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentAttendanceDetailedWitElecSubRpt", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function

    Public Function GetNewStudentAttendanceReportWitElecSub(ByVal BR As String, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal StdId As Integer, ByVal Month As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(6) {}


        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = BR

        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")

        param(2) = New SqlParameter("@batch", SqlDbType.Int)
        param(2).Value = Bat

        param(3) = New SqlParameter("@semid", SqlDbType.Int)
        param(3).Value = Sem

        param(4) = New SqlParameter("@subid", SqlDbType.Int)
        param(4).Value = Subj

        'param(6) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(6).Value = ES

        param(5) = New SqlParameter("@StdId", SqlDbType.Int)
        param(5).Value = StdId

        param(6) = New SqlParameter("@month", SqlDbType.Int)
        param(6).Value = Month


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_NewStudAttendanceWitElecSub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function GetStudentReportWitElecSub(ByVal BranchCode As String, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal StdId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Min As Integer, ByVal Max As Integer, ByVal SortBy As Integer, ByVal Category As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(10) {}
        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = BranchCode
        param(1) = New SqlParameter("@batch", SqlDbType.Int)
        param(1).Value = Bat
        param(2) = New SqlParameter("@semid", SqlDbType.Int)
        param(2).Value = Sem
        param(3) = New SqlParameter("@subid", SqlDbType.Int)
        param(3).Value = Subj
        'param(5) = New SqlParameter("@ElecSub", SqlDbType.Int)
        'param(5).Value = ES
        param(4) = New SqlParameter("@StdId", SqlDbType.Int)
        param(4).Value = StdId
        param(5) = New SqlParameter("@fromdate", SqlDbType.DateTime)
        param(5).Value = fromdate
        param(6) = New SqlParameter("@todate", SqlDbType.DateTime)
        param(6).Value = todate
        param(7) = New SqlParameter("@Min", SqlDbType.Int)
        param(7).Value = Min
        param(8) = New SqlParameter("@Max", SqlDbType.Int)
        param(8).Value = Max
        param(9) = New SqlParameter("@SortBy", SqlDbType.Int)
        param(9).Value = SortBy
        param(10) = New SqlParameter("@category", SqlDbType.Int)
        param(10).Value = Category
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentAttendanceRptWitElecSub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Public Function GetSemAssessmtRpt(ByVal Crs As Integer, ByVal Bat As Integer, ByVal Sem As Integer, ByVal Subj As Integer, ByVal StdId As Integer, ByVal SortBy As Integer, ByVal AsstId As Integer, ByVal EmpStudLog As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(8) {}

        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@batch", SqlDbType.Int)
        param(1).Value = Bat

        param(2) = New SqlParameter("@semid", SqlDbType.Int)
        param(2).Value = Sem

        param(3) = New SqlParameter("@subid", SqlDbType.Int)
        param(3).Value = Subj

        param(4) = New SqlParameter("@Course", SqlDbType.Int)
        param(4).Value = Crs

        param(5) = New SqlParameter("@StdId", SqlDbType.Int)
        param(5).Value = StdId

        param(6) = New SqlParameter("@SortBy", SqlDbType.Int)
        param(6).Value = SortBy

        param(7) = New SqlParameter("@AsstId", SqlDbType.Int)
        param(7).Value = AsstId

        param(8) = New SqlParameter("@EmpStudLog", SqlDbType.Int)
        param(8).Value = EmpStudLog
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_SemAssessmt]", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Shared Function ViewDataStatus(ByVal Batch As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(1) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")

        Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
        Parms(1).Value = Batch

        'Parms(2) = New SqlParameter("@Semester", SqlDbType.Int)
        'Parms(2).Value = Semester

        'Parms(3) = New SqlParameter("@Subject", SqlDbType.Int)
        'Parms(3).Value = Subject


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_ViewAttendDataEntryStatus]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetNewSemAttendListParentIndReport(ByVal Bat As Integer, ByVal Sem As Integer, ByVal id As Integer, ByVal Frmdate As Date, ByVal Todate As Date, ByVal Subject As String, ByVal SubSubgrp As String, ByVal Stdid As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(9) {}

        param(0) = New SqlParameter("@Batch", SqlDbType.Int)
        param(0).Value = Bat

        param(1) = New SqlParameter("@Semester", SqlDbType.Int)
        param(1).Value = Sem

        param(2) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        param(4) = New SqlParameter("@id", SqlDbType.Int)
        param(4).Value = id

        param(5) = New SqlParameter("@Frmdate", SqlDbType.Date)
        param(5).Value = Frmdate

        param(6) = New SqlParameter("@Todate", SqlDbType.Date)
        param(6).Value = Todate

        param(7) = New SqlParameter("@Subject", SqlDbType.VarChar, 50)
        param(7).Value = Subject

        param(8) = New SqlParameter("@SubSubgrp", SqlDbType.VarChar, 50)
        param(8).Value = SubSubgrp

        param(9) = New SqlParameter("@Stdid", SqlDbType.Int)
        param(9).Value = Stdid



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_SemAttenMapParentLoginNew", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function GetNewSemAttendListIndReport(ByVal Bat As Integer, ByVal Sem As Integer, ByVal id As Integer, ByVal Frmdate As Date, ByVal Todate As Date, ByVal Subject As String, ByVal SubSubgrp As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(8) {}

        param(0) = New SqlParameter("@Batch", SqlDbType.Int)
        param(0).Value = Bat

        param(1) = New SqlParameter("@Semester", SqlDbType.Int)
        param(1).Value = Sem

        param(2) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        param(4) = New SqlParameter("@id", SqlDbType.Int)
        param(4).Value = id

        param(5) = New SqlParameter("@Frmdate", SqlDbType.Date)
        param(5).Value = Frmdate

        param(6) = New SqlParameter("@Todate", SqlDbType.Date)
        param(6).Value = Todate

        param(7) = New SqlParameter("@Subject", SqlDbType.VarChar, 50)
        param(7).Value = Subject

        param(8) = New SqlParameter("@SubSubgrp", SqlDbType.VarChar, 50)
        param(8).Value = SubSubgrp


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_SemAttenMapNew", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function GetNewSemMarksAttendListNewReport(ByVal Bat As Integer, ByVal Sem As Integer, ByVal Aid As Integer, ByVal id As Integer, ByVal Srtdate As String, ByVal EndDate As String) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(7) {}

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

        param(5) = New SqlParameter("@id", SqlDbType.Int)
        param(5).Value = id

        param(6) = New SqlParameter("@SrtDate", SqlDbType.Date)
        param(6).Value = Srtdate

        param(7) = New SqlParameter("@EndDate", SqlDbType.Date)
        param(7).Value = EndDate



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_SemMarksAttenMapNew1]", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    'Code By JINA --> Accessing Batch & SemId through SubjectId
    Public Function BatchAccess(ByVal El As ELStdAttendancePBySubject) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@SubjectId", SqlDbType.Int)
        param(0).Value = El.SubjectId

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Branchcode")

        param(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_BatchAccessBySub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function SemAccess(ByVal El As ELStdAttendancePBySubject) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(3) {}
        param(0) = New SqlParameter("@BatchId", SqlDbType.VarChar, 50)
        param(0).Value = El.Batch

        param(1) = New SqlParameter("@SubjectId", SqlDbType.Int)
        param(1).Value = El.SubjectId

        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SemAccessBySub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
End Class
