Imports Microsoft.VisualBasic

Imports System.Data.SqlClient
Imports System.IO

Public Class DLReportStudAtt

    'Public Function RptStudentAttendanceSheetV(ByVal AYear As Integer, ByVal Batch As String, ByVal Semester As String, ByVal Subject As Integer, ByVal AttenDate As Date, ByVal SubGrp As Integer, ByVal SessionCountDay As String) As DataTable
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim ds As New DataSet
    '    Dim param() As SqlParameter = New SqlParameter(4) {}
    '    param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
    '    param(0).Value = AYear
    '    param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
    '    param(1).Value = HttpContext.Current.Session("BranchCode")
    '    param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
    '    param(2).Value = Batch
    '    param(3) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
    '    param(3).Value = Semester
    '    param(4) = New SqlParameter("@Subject", SqlDbType.Int)
    '    param(4).Value = Subject
    '    'param(5) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
    '    'param(5).Value = AttenDate
    '    'param(6) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
    '    'param(6).Value = SessionCountDay
    '    'param(7) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
    '    'param(7).Value = HttpContext.Current.Session("Office")
    '    'param(8) = New SqlParameter("@SubGrp", SqlDbType.Int)
    '    'param(8).Value = SubGrp

    '    Try
    '        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudAttendance", param)
    '    Catch ex As Exception
    '        MsgBox(ex.ToString)
    '    End Try
    '    Return ds.Tables(0)

    'End Function

    Public Function RptStudentAttendanceSheetV(ByVal Batch As String, ByVal Semester As String, ByVal Subject As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}
        'param(0) = New SqlParameter("@A_Year", SqlDbType.Int)
        'param(0).Value = AYear
        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")
        param(1) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(1).Value = Batch
        param(2) = New SqlParameter("@Semester", SqlDbType.VarChar, 50)
        param(2).Value = Semester
        param(3) = New SqlParameter("@Subject", SqlDbType.Int)
        param(3).Value = Subject
        'param(5) = New SqlParameter("@AttendanceDate", SqlDbType.DateTime)
        'param(5).Value = AttenDate
        'param(6) = New SqlParameter("@PeriodNo", SqlDbType.VarChar, 50)
        'param(6).Value = SessionCountDay
        param(4) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(4).Value = HttpContext.Current.Session("Office")
        'param(8) = New SqlParameter("@SubGrp", SqlDbType.Int)
        'param(8).Value = SubGrp

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudAttendance", param)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)

    End Function

    Shared Function GetSubject(ByVal Batchid As Integer, ByVal SemId As Integer) As DataTable
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
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetBatchComboForum() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("EmpID")

            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(3).Value = HttpContext.Current.Session("UserRole")

            Parms(4) = New SqlParameter("@DeptId", SqlDbType.Int)
            Parms(4).Value = HttpContext.Current.Session("DeptId")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchPlannerComboAll", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try

    End Function
    Shared Function getBatchPlannerComboSelectAll() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("Office")
            Parms(2) = New SqlParameter("@EmpCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("EmpID")

            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar, 50)
            Parms(3).Value = HttpContext.Current.Session("UserRole")

            Parms(4) = New SqlParameter("@DeptId", SqlDbType.Int)
            Parms(4).Value = HttpContext.Current.Session("DeptId")
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBatchPlannerComboAll", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_getSemester_fee11", param)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
