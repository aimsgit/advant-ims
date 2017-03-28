Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class CadreMgmtDL
    Shared Function CadreMgmtRpt(ByVal Aid As String, ByVal Bid As String, ByVal Cid As String) As DataTable

        Dim ConnectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}

        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@University", SqlDbType.VarChar, 50)
        arParms(1).Value = Aid

        arParms(2) = New SqlParameter("@Program", SqlDbType.Int)
        arParms(2).Value = Bid

        arParms(3) = New SqlParameter("@Project", SqlDbType.Int)
        arParms(3).Value = Cid

        arParms(4) = New SqlParameter("@office", SqlDbType.VarChar, 10)
        arParms(4).Value = HttpContext.Current.Session("office")

        ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "Proc_GetCadreMgmtGrid", arParms)
        Return ds.Tables(0)
    End Function
End Class
