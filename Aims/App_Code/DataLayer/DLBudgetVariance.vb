Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLBudgetVariance
    Shared Function Get_ProjectName() As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Try
            Dim Parms() As SqlParameter = New SqlParameter(0) {}

            Parms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
            Parms(0).Value = HttpContext.Current.Session("BranchCode")

            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_Get_ProjectName", Parms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Shared Function GenerateBudgetVarianceReport(ByVal ProjectId As Integer, ByVal ReportDate As DateTime) As DataTable
        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim Params() As SqlParameter = New SqlParameter(2) {}

        Params(0) = New SqlParameter("@ProjectId", Data.SqlDbType.Int)
        Params(0).Value = ProjectId

        Params(1) = New SqlParameter("@ReportDate", Data.SqlDbType.DateTime)
        Params(1).Value = ReportDate


        Params(2) = New SqlParameter("@BranchCode", Data.SqlDbType.VarChar)
        Params(2).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "proc_GenerateBudgetVarianceReport", Params)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
