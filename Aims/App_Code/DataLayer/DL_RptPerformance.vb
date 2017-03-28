Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DL_RptPerformance
    Public Shared Function StudentPerformanceAtt(ByVal batch As Integer, ByVal subject As Integer, ByVal Assmt As Integer, ByVal fromdate As Date, ByVal todate As Date) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(5) {}

        para(0) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@batch", SqlDbType.Int)
        para(2).Value = batch

        para(3) = New SqlParameter("@subId", SqlDbType.Int)
        para(3).Value = subject



      

        para(4) = New SqlParameter("@Fromdate ", SqlDbType.DateTime)
        para(4).Value = fromdate

        para(5) = New SqlParameter("@Todate ", SqlDbType.DateTime)
        para(5).Value = todate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_StudentPerformAttndModi", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function StudentPerformanceMarks(ByVal batch As Integer, ByVal subject As Integer, ByVal Assmt As Integer, ByVal fromdate As Date, ByVal todate As Date) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}

        para(0) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@batch", SqlDbType.Int)
        para(2).Value = batch

        para(3) = New SqlParameter("@subId", SqlDbType.Int)
        para(3).Value = subject

        para(4) = New SqlParameter("@Assmnt", SqlDbType.Int)
        para(4).Value = Assmt

        para(5) = New SqlParameter("@Fromdate ", SqlDbType.DateTime)
        para(5).Value = fromdate

        para(6) = New SqlParameter("@Todate ", SqlDbType.DateTime)
        para(6).Value = todate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_StudentPerformMarksModi", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function BestfacultyonAttend(ByVal batch As Integer, ByVal subject As Integer, ByVal Assmt As Integer, ByVal fromdate As Date, ByVal todate As Date) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}

        para(0) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@Batch", SqlDbType.Int)
        para(2).Value = batch

        para(3) = New SqlParameter("@Subject", SqlDbType.Int)
        para(3).Value = subject

        para(4) = New SqlParameter("@Assesment", SqlDbType.Int)
        para(4).Value = Assmt

        para(5) = New SqlParameter("@Fromdate ", SqlDbType.DateTime)
        para(5).Value = fromdate

        para(6) = New SqlParameter("@Todate ", SqlDbType.DateTime)
        para(6).Value = todate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "RptTopFaculty", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Shared Function Bestfacultyonmarks(ByVal batch As Integer, ByVal subject As Integer, ByVal Assmt As Integer, ByVal fromdate As Date, ByVal todate As Date) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(6) {}

        para(0) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@Batch", SqlDbType.Int)
        para(2).Value = batch

        para(3) = New SqlParameter("@Subject", SqlDbType.Int)
        para(3).Value = subject

        para(4) = New SqlParameter("@Assesment", SqlDbType.Int)
        para(4).Value = Assmt

        para(5) = New SqlParameter("@Fromdate ", SqlDbType.DateTime)
        para(5).Value = fromdate

        para(6) = New SqlParameter("@Todate ", SqlDbType.DateTime)
        para(6).Value = todate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "RptTopFacultywithMarks", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function


    Shared Function GetBestSubjAtten(ByVal Batch As Integer, ByVal fromdate As Date, ByVal todate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(1).Value = Batch

            Parms(2) = New SqlParameter("@FrmDate", SqlDbType.Date)
            Parms(2).Value = fromdate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.Date)
            Parms(3).Value = todate

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_BestSubject]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function

    Shared Function GetBestSubjMarks(ByVal Batch As Integer, ByVal fromdate As Date, ByVal todate As Date, ByVal AssessmentType As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(4) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Batch", SqlDbType.Int)
            Parms(1).Value = Batch

            Parms(2) = New SqlParameter("@FrmDate", SqlDbType.Date)
            Parms(2).Value = fromdate

            Parms(3) = New SqlParameter("@ToDate", SqlDbType.Date)
            Parms(3).Value = todate

            Parms(4) = New SqlParameter("@AssessmentType", SqlDbType.Int)
            Parms(4).Value = AssessmentType

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_BestSubjectMarks]", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Shared Function GetBestProgramOnMarks(ByVal Assmt As Integer, ByVal fromdate As Date, ByVal todate As Date) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}

        para(0) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@Fromdate ", SqlDbType.DateTime)
        para(2).Value = fromdate

        para(3) = New SqlParameter("@Todate ", SqlDbType.DateTime)
        para(3).Value = todate

        para(4) = New SqlParameter("@Assmt", SqlDbType.Int)
        para(4).Value = Assmt
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_BestProgramWithMarks", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Public Shared Function GetBestProgramOnAttend(ByVal fromdate As Date, ByVal todate As Date) As Data.DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim para() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}

        para(0) = New SqlParameter("@Branchcode", SqlDbType.VarChar, 50)
        para(0).Value = HttpContext.Current.Session("BranchCode")

        para(1) = New SqlParameter("@office", SqlDbType.VarChar, 50)
        para(1).Value = HttpContext.Current.Session("Office")

        para(2) = New SqlParameter("@Fromdate ", SqlDbType.DateTime)
        para(2).Value = fromdate

        para(3) = New SqlParameter("@Todate ", SqlDbType.DateTime)
        para(3).Value = todate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_BestProgramWithAttend", para)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
