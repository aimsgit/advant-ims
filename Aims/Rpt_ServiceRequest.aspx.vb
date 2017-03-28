Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class Rpt_ServiceRequest
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Try

            Dim Fromdate As DateTime
            Dim Todate As DateTime
            Dim Status As String

            Status = ddlStatus.SelectedItem.Text
            If txtStartingDate.Text = "" Then
                Fromdate = "1/1/1900"
            Else
                Fromdate = txtStartingDate.Text
                lblerrmsg.Text = ""
            End If

            If txtEndDate.Text = "" Then
                Todate = "1/1/3000"
            Else
                Todate = txtEndDate.Text
                lblerrmsg.Text = ""
            End If

            If Fromdate > Todate Then
                lblerrmsg.Text = "Start date should not be greater than End date."
                txtEndDate.Focus()
            End If

            Dim qrystring As String = "Rpt_ServiceRequest_View.aspx?" & QueryStr.Querystring() & "&Fromdate=" & Fromdate & "&Todate=" & Todate & "&Status=" & Status
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            lblerrmsg.Text = "Please enter the valid date."
            lblmsgifo.Text = ""
        End Try

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtStartingDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
End Class
