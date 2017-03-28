Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLDailyBalanceRpt
    Shared Function RptGetDailyBalance(ByVal FromDate As Date, ByVal ReportType As Integer) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(3) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@FromDate", SqlDbType.DateTime)
        arParms(2).Value = FromDate

        arParms(3) = New SqlParameter("@ReportType", SqlDbType.Int)
        arParms(3).Value = ReportType

        Dim ds As New DataSet

        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_DailyBalance_Rpt", arParms)
        Return ds.Tables(0)

    End Function
End Class
