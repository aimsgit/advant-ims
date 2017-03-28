Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLStudAttendBySub
    'Code By Jina - Select Branch from Access Level
    Shared Function SelectBranch() As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")

        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        arParms(2) = New SqlParameter("@AccessLevel", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("AccessLevel")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_BranchDDLAccess", arParms)
        Return ds.Tables(0)
    End Function

    Shared Function GetSubjectAll1(ByVal BranchCode As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = BranchCode

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "SubjectAllDDL", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetStudentNameCombo1(ByVal BranchCode As String) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(1) {}

        param(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(0).Value = BranchCode
        param(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Office")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_StudentAll", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetCategoryALL() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetCategory_ALL", arParms)
        Return ds.Tables(0)
    End Function

    Public Function BatchAccess(ByVal Subj As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(2) {}
        param(0) = New SqlParameter("@SubjectId", SqlDbType.Int)
        param(0).Value = Subj

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("Branchcode")

        param(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Office")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_BatchAccessBySubject", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function

    Public Function SemAccess(ByVal Subj As Integer, ByVal Batch As String, ByVal fromdate As Date, ByVal todate As Date) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(5) {}
        param(0) = New SqlParameter("@BatchId", SqlDbType.VarChar, 50)
        param(0).Value = Batch

        param(1) = New SqlParameter("@SubjectId", SqlDbType.Int)
        param(1).Value = Subj

        param(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Branchcode")

        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")

        param(4) = New SqlParameter("@fromdate", SqlDbType.Date)
        param(4).Value = fromdate

        param(5) = New SqlParameter("@todate", SqlDbType.Date)
        param(5).Value = todate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_SemAccessBySubject", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
    Public Function GetStudentDtlsForParent() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, HttpContext.Current.Session("BranchCode").length)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@BatchId", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BatchID")

        arParms(2) = New SqlParameter("@StdCode", SqlDbType.VarChar, HttpContext.Current.Session("StudentCode").length)
        arParms(2).Value = HttpContext.Current.Session("StudentCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudentDetForParent", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetStdSemester(ByVal BatchId As String, ByVal fromdate As Date, ByVal todate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BatchId", SqlDbType.VarChar, 50)
        arParms(0).Value = BatchId

        arParms(1) = New SqlParameter("@fromdate", SqlDbType.Date)
        arParms(1).Value = fromdate

        arParms(2) = New SqlParameter("@todate", SqlDbType.Date)
        arParms(2).Value = todate

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetStudCurrentSem", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function GetStudentReportWitElecSub(ByVal BranchCode As String, ByVal Bat As String, ByVal Sem As String, ByVal Subj As Integer, ByVal StdId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal Min As Integer, ByVal Max As Integer, ByVal SortBy As Integer, ByVal Category As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(10) {}
        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = BranchCode
        param(1) = New SqlParameter("@batch", SqlDbType.VarChar, 50)
        param(1).Value = Bat
        param(2) = New SqlParameter("@semid", SqlDbType.VarChar, 50)
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentAttendanceRptWitSub", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try


        Return ds.Tables(0)
    End Function

    Public Function GetStudentDetailedReportWitElecSub(ByVal BR As String, ByVal Bat As String, ByVal Sem As String, ByVal Subj As Integer, ByVal StdId As Integer, ByVal fromdate As DateTime, ByVal todate As DateTime, ByVal SortBy As Integer, ByVal category As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(9) {}
        param(0) = New SqlParameter("@branchCode", SqlDbType.VarChar, 50)
        param(0).Value = BR
        param(1) = New SqlParameter("@batch", SqlDbType.VarChar, 50)
        param(1).Value = Bat
        param(2) = New SqlParameter("@semid", SqlDbType.VarChar, 50)
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
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudentAttendanceDetailedWitSubRpt", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try

        Return ds.Tables(0)
    End Function
End Class
