﻿Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Class PayRollRptDL
    Public Function PayrollDetailsRpt(ByVal Employee As Integer, ByVal EarningDeduction As Integer) As Data.DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        Dim ds As New DataSet
        Dim param() As SqlParameter = New SqlParameter(3) {}
        param(0) = New SqlParameter("@Employee", SqlDbType.Int)
        param(0).Value = Employee

        param(1) = New SqlParameter("@BranchCode", SqlDbType.VarChar, 50)
        param(1).Value = HttpContext.Current.Session("BranchCode")

        param(2) = New SqlParameter("@EarningDeduction", SqlDbType.VarChar, 50)
        param(2).Value = EarningDeduction
                
        param(3) = New SqlParameter("@Office", SqlDbType.VarChar, 50)
        param(3).Value = HttpContext.Current.Session("Office")
        
        Try
            ds = SqlHelper.ExecuteDataset(connectionString, CommandType.StoredProcedure, "Rpt_PayrollDetails", param)
        Catch ex As Exception
            MsgBox(ex.Data.ToString)
        End Try
        Return ds.Tables(0)
    End Function
End Class
