
Partial Class Rpt_StudentTransport
    Inherits BasePage
   
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim FDate As Date = txtFDate.Text
        Dim TDate As Date = txtTDate.Text
        If (FDate > TDate) Then
            lblmsg.Text = "From Date Should be less than To Date."
            txtFDate.Focus()
            Exit Sub
        End If
        Dim qrystring As String = "Rpt_StudentTransportV.aspx?" & QueryStr.Querystring() & "&FromDate=" & txtFDate.Text & "&ToDate=" & txtTDate.Text & "&Route=" & ddlRouteName.SelectedValue & "&Student=" & ddlStudent.SelectedValue
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("LoginType").Equals("Others")) Then
            ddlRouteName.Enabled = False
            ddlStudent.Enabled = False
        Else
            ddlRouteName.Enabled = True
            ddlStudent.Enabled = True
        End If
    End Sub
End Class
