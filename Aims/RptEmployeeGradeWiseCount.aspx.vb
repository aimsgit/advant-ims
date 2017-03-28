
Partial Class RptEmployeeGradeWiseCount
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblMsg.Text = ""
        Dim BranchCode As String
        If ddlBrch.SelectedValue = "" Then
            BranchCode = 0
        Else
            BranchCode = ddlBrch.SelectedValue
        End If

        Dim qrystring As String = "RptEmployeeGradeWiseCountV.aspx?" & QueryStr.Querystring() & "&BranchCode=" & BranchCode
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub ddlBrch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBrch.SelectedIndexChanged
        ddlBrch.Focus()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ddlBrch.SelectedValue = Session("BranchCode")

        End If
    End Sub

End Class
