﻿Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class frmProductWiseNearestExp
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Try
            Dim Fromdate As DateTime
            Dim Todate As DateTime
            Dim product As Integer
            Dim PurchaseInvNo As Integer

            product = ddlProduct.SelectedValue
            PurchaseInvNo = dllPurchaseInvNo.SelectedValue

            If txtStartingDate.Text = "" Then
                Fromdate = "1/1/1900"
            Else
                Fromdate = txtStartingDate.Text

            End If

            If txtEndDate.Text = "" Then
                Todate = "1/1/3000"
            Else
                Todate = txtEndDate.Text
            End If

            If Fromdate > Todate Then
                lblerrmsg.Text = "Start date should not be greater than End date."
                txtEndDate.Focus()
            End If

            Dim qrystring As String = "Rpt_ProductWiseNearestEx.aspx?" & QueryStr.Querystring() & "&Fromdate=" & Fromdate & "&Todate=" & Todate & "&product=" & product & "&PurchaseInvNo=" & PurchaseInvNo
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            lblerrmsg.Text = "Please enter the valid date."
            lblmsgifo.Text = ""
        End Try

        Exit Sub
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim TDate As Date
        Dim Cd As String
        If Not IsPostBack Then
            TDate = System.DateTime.Now
            Cd = TDate.ToString("dd-MMM-yyyy")
            txtStartingDate.Text = Cd
            txtEndDate.Text = Cd
        End If
    End Sub
End Class
