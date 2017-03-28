Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class DLRptStudParenUserMgmt

    Shared Function GetCourseAll() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataTable
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")

        Try
            Dim ds As DataSet
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "GetCourseAll", arParms)
            dt = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        Return dt
    End Function
    Shared Function GetBatchAll(ByVal CourseID As Integer) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")


        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@CourseID", SqlDbType.Int, 50)
        arParms(2).Value = CourseID


        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_NewBatchAll", arParms)
        Return ds.Tables(0)
    End Function
    Public Function RptGetUserDetails(ByVal CourseID As Integer, ByVal Batch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(3) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@CourseID", SqlDbType.Int, 50)
        arParms(2).Value = CourseID

        arParms(3) = New SqlParameter("@BatchID", SqlDbType.Int, 50)
        arParms(3).Value = Batch

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_StudParentUserMgmt", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

End Class
