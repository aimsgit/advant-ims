Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLAccountHeadLedgerRpt
    Shared Function RptGetAccountHeadLedger(ByVal AH As Integer, ByVal PR As Integer, ByVal FromDate As DateTime, ByVal ToDate As DateTime) As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(2).Value = FromDate

        arParms(3) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(3).Value = ToDate

        arParms(4) = New SqlParameter("@AccountGroup", SqlDbType.Int)
        arParms(4).Value = AH

        arParms(5) = New SqlParameter("@Project", SqlDbType.Int)
        arParms(5).Value = PR


        Dim ds As New DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_AcctHeadLedger_Qry", arParms)
        Return ds.Tables(0)

    End Function
End Class
