Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.WebControls
Imports System.Data.SqlClient

Public Class DLExamDashBoard
    Shared Function GetExamBatch() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(1) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_ddlExamBatchforExamDashboard", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
    Public Function GetExamBatchDetails(ByVal ExamBatch As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(2) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            Parms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
            Parms(1).Value = HttpContext.Current.Session("Office")

            Parms(2) = New SqlParameter("@ExamBatch", SqlDbType.Int)
            Parms(2).Value = ExamBatch

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "proc_GetExamDashborad", Parms)
            Return ds.Tables(0)
        Catch ex As Exception
            Return Nothing
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
