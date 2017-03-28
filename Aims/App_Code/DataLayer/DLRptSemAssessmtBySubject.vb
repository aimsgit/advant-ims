Imports Microsoft.VisualBasic

Imports System.Data.SqlClient

Public Class DLRptSemAssessmtBySubject
    Shared Function getassessmentAll() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "[Proc_AssesmentddlAll]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetSubject() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")



            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_NewSubjectddl", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Shared Function GetSemAssessmtRpt(ByVal SubId As Integer, ByVal AsstId As Integer, ByVal id As Integer, ByVal Batch As String, ByVal SemesterId As String, ByVal StudId As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(6) {}

        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("BranchCode")

        param(1) = New SqlParameter("@SubId", SqlDbType.Int)
        param(1).Value = SubId
        param(2) = New SqlParameter("@AsstId", SqlDbType.Int)
        param(2).Value = AsstId
        'param(3) = New SqlParameter("@ReportType", SqlDbType.Int)
        'param(3).Value = ReportType

        param(3) = New SqlParameter("@id", SqlDbType.Int)
        param(3).Value = id

        param(4) = New SqlParameter("@SemesterId", SqlDbType.VarChar, 50)
        param(4).Value = SemesterId

        param(5) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(5).Value = Batch
        param(6) = New SqlParameter("@StudId", SqlDbType.Int)
        param(6).Value = StudId


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Rpt_NewSemAssessmt]", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function
    Public Function BatchAccess(ByVal SubId As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@SubId", SqlDbType.Int)
        param(0).Value = SubId

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Branchcode")

        param(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_NewBatchAccessBySub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function SemAccess(ByVal BatchId As String, ByVal SubId As Integer, ByVal FromDate As Date, ByVal ToDate As Date) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(5) {}
        param(0) = New SqlParameter("@BatchId", SqlDbType.VarChar, 50)
        param(0).Value = BatchId

        param(1) = New SqlParameter("@SubId", SqlDbType.Int)
        param(1).Value = SubId

        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")
        param(4) = New SqlParameter("@FromDate", SqlDbType.Date)
        param(4).Value = FromDate

        param(5) = New SqlParameter("@ToDate", SqlDbType.Date)
        param(5).Value = ToDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_NewSemAccessBySub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function GetStudentNameCombo1(ByVal Batch As String, ByVal SubId As Integer, ByVal SemesterId As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(4) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Branchcode")
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")
        param(2) = New SqlParameter("@Batch", SqlDbType.VarChar, 50)
        param(2).Value = Batch
        param(3) = New SqlParameter("@SubId", SqlDbType.Int)
        param(3).Value = SubId
        param(4) = New SqlParameter("@SemesterId", SqlDbType.VarChar, 50)
        param(4).Value = SemesterId

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "New_Studentddl", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
