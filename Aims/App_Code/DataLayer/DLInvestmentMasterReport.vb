Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLInvestmentMasterReport
    Public Function Rpt_Investment(ByVal FromDate As Date, ByVal ToDate As Date, ByVal Investment As String, ByVal Bank As String, ByVal ROI As String, ByVal BalAmt As String) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(7) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@FromDate", SqlDbType.Date)
        arParms(2).Value = FromDate

        arParms(3) = New SqlParameter("@ToDate", SqlDbType.Date)
        arParms(3).Value = ToDate

        arParms(4) = New SqlParameter("@InvestmentType", SqlDbType.VarChar, 50)
        arParms(4).Value = Investment

        arParms(5) = New SqlParameter("@Bank", SqlDbType.VarChar, 50)
        arParms(5).Value = Bank

        arParms(6) = New SqlParameter("@RateofInterest", SqlDbType.VarChar, 50)
        arParms(6).Value = ROI

        arParms(7) = New SqlParameter("@BalanceAmount", SqlDbType.VarChar, 50)
        arParms(7).Value = BalAmt
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_InvestmentMaster", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function

    Shared Function GetBank() As System.Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(1) {}
        arParms(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("Office")
        arParms(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Endo_ddlBank", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class