Imports System.Data.SqlClient
Imports System.Data
Imports System.Data.Sql
Partial Class RptFrmWorkFlowReport
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim FormName As Integer
        Dim FormName1 As String
        Dim r As String
        Dim emp As Integer


        Dim StartDate As DateTime
        Dim EndDate As DateTime

        FormName = ddlform.SelectedValue
        FormName1 = ddlform.SelectedItem.Text
        r = ddlStatus.SelectedValue
        emp = ddlEmp.SelectedValue

        If txtstartdate.Text = "" Then
            StartDate = "1/1/1900"
        Else
            StartDate = txtstartdate.Text
        End If
        If txtenddate.Text = "" Then
            EndDate = "1/1/3000"
        Else
            EndDate = txtenddate.Text
        End If
        If StartDate > EndDate Then
            msginfo.Text = "Start date should not be greater than End date."
            txtenddate.Focus()
            Exit Sub
        End If
        Dim qrystring As String = "RptFrmWorkFlowReportV.aspx?" & QueryStr.Querystring() & "&StartDate=" & StartDate & "&EndDate=" & EndDate & "&FormName=" & FormName & "&FormName1=" & FormName1 & "&r=" & r & "&emp=" & emp
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)


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
