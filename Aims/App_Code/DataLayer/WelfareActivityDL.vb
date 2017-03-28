Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class WelfareActivityDL
    Shared Function GetBatchDDL() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}

        Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        Parms(0).Value = HttpContext.Current.Session("BranchCode")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_getBtchddl1", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GetScholarshipDDL() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Parms() As SqlParameter = New SqlParameter(0) {}
       
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetScholarLookupDDL")
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function WelfareActivityLoadGridView(ByVal BatchId As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(0).Value = BatchId

            Parms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar)
            Parms(1).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_WelfareActivityLoadGridView", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    
    Shared Function ApproveWelfareActivity(ByVal BatchId As Integer, ByVal id As String, ByVal Scholar As Integer) As Integer
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
             Dim Parms() As SqlParameter = New SqlParameter(3) {}

            Parms(0) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(0).Value = BatchId
            Parms(1) = New SqlParameter("@id", SqlDbType.VarChar, 4000)
            Parms(1).Value = id
            Parms(2) = New SqlParameter("@Scholar", SqlDbType.Int)
            Parms(2).Value = Scholar
            Parms(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(3).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ApproveWelfareActivity", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return Nothing
    End Function
    Shared Function RptWelfareActivity(ByVal BatchId As Integer, ByVal Scholar As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BatchId", SqlDbType.Int)
            Parms(0).Value = BatchId
            Parms(1) = New SqlParameter("@Scholarship", SqlDbType.Int)
            Parms(1).Value = Scholar
            Parms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(2).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_WefareActivityReport", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
