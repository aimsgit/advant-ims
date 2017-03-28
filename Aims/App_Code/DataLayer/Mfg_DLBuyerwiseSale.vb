﻿Imports Microsoft.VisualBasic
Imports System.Data.SqlClient
Public Class Mfg_DLBuyerwiseSale

    Public Function RptGetBuyerWiseSale(ByVal PartyId As Integer, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(4) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(1).Value = HttpContext.Current.Session("Office")

        arParms(2) = New SqlParameter("@PartyId", SqlDbType.NVarChar, 50)
        arParms(2).Value = PartyId

        arParms(3) = New SqlParameter("@FromDate", SqlDbType.Date)
        arParms(3).Value = FromDate

        arParms(4) = New SqlParameter("@ToDate", SqlDbType.Date)
        arParms(4).Value = ToDate
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptBuyerWiseSaleReport", arParms)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
    Public Function BuyerComboAll() As DataTable
        Dim ds As New DataSet
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim param() As SqlParameter = New SqlParameter(1) {}
        param(0) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(0).Value = HttpContext.Current.Session("Office")
        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Proc_GetBuyerComboAll", param)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Function
End Class
