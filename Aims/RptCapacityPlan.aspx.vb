
Partial Class RptCapacityPlan
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim QS As String
        Dim Branch As String
        Dim Year As String
        Dim Department As String = ddldept.SelectedValue
        QS = Request.QueryString.Get("QS")
        'If ddlBrch.SelectedValue = 0 Then
        '    lblMsg.Text = "Please select branch."
        'Else
        '    Branch = ddlBrch.SelectedValue
        'End If
        'If ddlYear.SelectedValue = 0 Then
        '    lblMsg.Text = "Please select Year."
        'Else
        '    Year = ddlYear.SelectedItem.Text
        'End If

        If ddlBrch.SelectedValue = 0 Or ddlYear.SelectedValue = 0 Then
            lblMsg.Text = "Please Select Mandetory Fields."
        Else
            Branch = ddlBrch.SelectedValue
            Year = ddlYear.SelectedItem.Text
            Dim qrystring As String = "RptCapacityPlanV.aspx?" & QueryStr.Querystring() & "&Branch=" & Branch & "&Year=" & Year & "&Department=" & Department
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            'lblMsg.Text = ""
        End If

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ddlBrch.SelectedValue = Session("BranchCode")
        End If
    End Sub
End Class
