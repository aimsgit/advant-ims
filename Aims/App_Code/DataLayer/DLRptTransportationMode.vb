﻿Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class DLRptTransportationMode
    Public Function GetTransport(ByVal ShippingID As Integer) As DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        Dim ds As New DataSet
        Dim arParms() As SqlParameter = New SqlParameter(2) {}
        arParms(0) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        arParms(0).Value = HttpContext.Current.Session("BranchCode")

        arParms(1) = New SqlParameter("@Shipping_ID", SqlDbType.Int)
        arParms(1).Value = ShippingID

        arParms(2) = New SqlParameter("@Office", SqlDbType.VarChar, 20)
        arParms(2).Value = HttpContext.Current.Session("Office")


        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Mfg_RptTransportationMode", arParms)

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
