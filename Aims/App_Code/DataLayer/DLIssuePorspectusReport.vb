Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLIssuePorspectusReport
    Shared Function Get_Convaction(ByVal Sdate As Date, ByVal Edate As Date) As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(3) {}

        param(0) = New SqlParameter("@Sdate", SqlDbType.Date)
        param(0).Value = Sdate


        param(1) = New SqlParameter("@Edate", SqlDbType.Date)
        param(1).Value = Edate

        param(2) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(2).Value = HttpContext.Current.Session("Office")


        param(3) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("BranchCode")

        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Proc_ReportProspBalance]", param)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
