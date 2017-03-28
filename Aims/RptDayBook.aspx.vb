﻿Partial Class RptDayBook
    Inherits BasePage
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        If ddlReportType.SelectedValue <> 0 And ddlS1.SelectedItem.Text = " All" And ddlS2.SelectedItem.Text = " All" Then
            msginfo.Text = "Select From No and To No."
            Exit Sub
        Else

        End If
        If ddlReportType.SelectedValue <> 0 And ddlS1.SelectedItem.Text <> " All" And ddlS2.SelectedItem.Text = " All" Then
            msginfo.Text = "Select From No and To No."
            Exit Sub
        End If
        If ddlReportType.SelectedValue <> 0 And ddlS1.SelectedItem.Text = " All" And ddlS2.SelectedItem.Text <> " All" Then
            msginfo.Text = "Select From No and To No."
            Exit Sub
        End If
        If txtEndDate.Text < txtStartDate.Text Then
            msginfo.Text = "Start Date cannot be greater than End Date."
        Else
            msginfo.Text = ""
            Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "RptDayBookV.aspx?" & QueryStr.Querystring() & "&FinStartDate=" & txtStartDate.Text & "&FinEndDate=" & txtEndDate.Text & "&S1=" & ddlS1.SelectedValue & "&S2=" & ddlS2.SelectedValue & "&ReportType=" & ddlReportType.SelectedValue
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

        End If
        'Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "RptDayBookV.aspx?" & QueryStr.Querystring() & "&FinStartDate=" & txtStartDate.Text & "&FinEndDate=" & txtEndDate.Text
        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Session("GStatus") = ""
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
        Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
End Class
