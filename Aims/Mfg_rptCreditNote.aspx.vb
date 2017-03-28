﻿
Partial Class Mfg_rptCreditNote
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblmsg.Text = ""
        lblerrmsg.Text = ""
        Dim QS As String
        Dim SupplierId As Integer
        Dim InvoiceNo As Integer
        Dim fromdate As DateTime
        Dim enddate As DateTime
        Try

            If ddlSupplier.SelectedValue = "" Then
                SupplierId = 0
            Else
                SupplierId = ddlSupplier.SelectedValue
            End If
            If ddlinvoice.SelectedValue = "" Then
                InvoiceNo = 0
            Else
                InvoiceNo = ddlinvoice.SelectedValue
            End If
            If txtstartdate.Text = "" Then
                fromdate = "1/1/1990"
            Else
                fromdate = txtstartdate.Text
            End If
            If txtenddate.Text = "" Then
                enddate = "1/1/3000"
            Else
                enddate = txtenddate.Text
            End If


            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "Mfg_rptCreditNoteV.aspx?" & QueryStr.Querystring() & "&SupplierId=" & SupplierId & "&InvoiceNo=" & InvoiceNo & "&StartDate=" & fromdate & "&EndDate=" & enddate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblerrmsg.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            lblerrmsg.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtstartdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtenddate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
End Class

