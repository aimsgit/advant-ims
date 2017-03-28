Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class PartyLedgerDB
    Shared Function GetGenPartyLedgRpt() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As DataSet

        Dim arParms() As SqlParameter = New SqlParameter(5) {}
        arParms(0) = New SqlParameter("@Institute_ID", SqlDbType.Int)
        arParms(0).Value = HttpContext.Current.Session("InstituteID")

        arParms(1) = New SqlParameter("@Branch_ID", SqlDbType.Int)
        arParms(1).Value = HttpContext.Current.Session("BranchID")

        arParms(2) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(2).Value = CDate(HttpContext.Current.Session("FinStartDate"))

        arParms(3) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(3).Value = CDate(HttpContext.Current.Session("FinEndDate"))

        arParms(4) = New SqlParameter("@Party_Type", SqlDbType.VarChar)
        arParms(4).Value = IIf(HttpContext.Current.Session("sesPartyType").ToString <> "None", HttpContext.Current.Session("sesPartyType").ToString, "")

        arParms(5) = New SqlParameter("@Party_Id_Name", SqlDbType.Int)
        arParms(5).Value = HttpContext.Current.Session("sesPartyId")


        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_GenParty_Ledgers", arParms)
        Return ds.Tables(0)
    End Function
End Class
