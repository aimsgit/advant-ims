Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class Mfg_RptPurchaseReturnDL
    Shared Function GetPurRet(ByVal supp_id As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(2) {}

        arParms(0) = New SqlParameter("@office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@Supplier_Id", SqlDbType.Int)
        arParms(2).Value = supp_id
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_ddlPurRetsuppwise]", arParms)
        Return ds.Tables(0)
    End Function
    Shared Function GetPurchaseReturnRpt(ByVal SuppID As Integer, ByVal PurRetID As Integer, ByVal StartDate As Date, ByVal EndDate As Date) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim arParms() As SqlParameter = New SqlParameter(5) {}

        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 2)
        arParms(0).Value = HttpContext.Current.Session("office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        arParms(2) = New SqlParameter("@SupplierId", SqlDbType.Int)
        arParms(2).Value = SuppID
        arParms(3) = New SqlParameter("@PurRetID", SqlDbType.Int)
        arParms(3).Value = PurRetID
        arParms(4) = New SqlParameter("@StartDate", SqlDbType.DateTime)
        arParms(4).Value = StartDate
        arParms(5) = New SqlParameter("@EndDate", SqlDbType.DateTime)
        arParms(5).Value = EndDate
        Dim ds As DataSet
        ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "[Mfg_Rpt_PurchaseReturn]", arParms)
        Return ds.Tables(0)
    End Function
End Class
