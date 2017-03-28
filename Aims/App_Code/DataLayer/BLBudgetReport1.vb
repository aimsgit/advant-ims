Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class BLBudgetReport1
    Shared Function RptBudgetReport() As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim dt As New DataSet
        Dim para() As SqlParameter = New SqlParameter(1) {}
        para(0) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        para(0).Value = HttpContext.Current.Session("Office")
        para(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 30)
        para(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            dt = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_Budget", para)
        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
        End Try
        Return dt.Tables(0)
    End Function
End Class
