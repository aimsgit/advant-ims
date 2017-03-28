Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLClassTeacher
    Public Function TeacherDashboard(ByVal Lecturer As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Lecturer", SqlDbType.Int)
            Parms(1).Value = Lecturer

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ClassTeacherdashboard", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function SubjectHours(ByVal Lecturer As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@Lecturer", SqlDbType.Int)
            Parms(1).Value = Lecturer

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ClassTeacherdashboardSubjectHours", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function TimeTable(ByVal Lecturer As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@branchcode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")
            Parms(1) = New SqlParameter("@TeacherId", SqlDbType.Int)
            Parms(1).Value = Lecturer
            Parms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_TimeTableTeacherNew", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
