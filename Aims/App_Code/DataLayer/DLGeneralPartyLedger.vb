Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLGeneralPartyLedger
    Public Function GeneralPartyLedger(ByVal StartDate As DateTime, ByVal EndDate As DateTime, ByVal PartyName As String, ByVal PartyType As String, ByVal PR As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet

        Dim arParms() As SqlParameter = New SqlParameter(6) {}

        arParms(0) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(0).Value = StartDate

        arParms(1) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(1).Value = EndDate

        arParms(2) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(2).Value = HttpContext.Current.Session("BranchCode")

        arParms(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(3).Value = HttpContext.Current.Session("Office")

        arParms(4) = New SqlParameter("@PartyName", SqlDbType.VarChar, 50)
        arParms(4).Value = PartyName


        arParms(5) = New SqlParameter("@PartyType", SqlDbType.VarChar, 50)
        arParms(5).Value = PartyType

        arParms(6) = New SqlParameter("@Project", SqlDbType.Int)
        arParms(6).Value = PR



        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Test_Acct_GenParty_Ledgers", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
