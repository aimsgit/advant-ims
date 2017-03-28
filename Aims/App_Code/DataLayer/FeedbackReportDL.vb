Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class FeedbackReportDL
    Shared Function FeedBackBatchDDL() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FeedBackBatchAll", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function FeedBackSemesterDDL(ByVal BatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(2).Value = BatchId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_FeedBackSemesterAllDDL", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function FeedBackFacultyDDL() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@EmpID", SqlDbType.VarChar)
            Parms(2).Value = HttpContext.Current.Session("EmpID")


            Parms(3) = New SqlParameter("@UserRole", SqlDbType.VarChar)
            Parms(3).Value = HttpContext.Current.Session("UserRole")

            Parms(4) = New SqlParameter("@AccessLevel", SqlDbType.Int)
            Parms(4).Value = HttpContext.Current.Session("AccessLevel")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetFacultyDDL", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function FeedBackReport(ByVal BatchId As Integer, ByVal SemId As Integer, ByVal EmpId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            Parms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(2).Value = BatchId

            Parms(3) = New SqlParameter("@SemId", SqlDbType.Int)
            Parms(3).Value = SemId

            Parms(4) = New SqlParameter("@EmpId", SqlDbType.Int)
            Parms(4).Value = EmpId

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_FeedBackReport", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function FacultywiseFeedBackReport() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 5)
            Parms(0).Value = HttpContext.Current.Session("Office")

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            'Parms(2) = New SqlParameter("@BatchId", SqlDbType.Int)
            'Parms(2).Value = BatchId

            'Parms(3) = New SqlParameter("@SemId", SqlDbType.Int)
            'Parms(3).Value = SemId

            Parms(2) = New SqlParameter("@EmpId", SqlDbType.Int)
            Parms(2).Value = HttpContext.Current.Session("EmpId")


            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_FacultywiseFeedBackReport", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
