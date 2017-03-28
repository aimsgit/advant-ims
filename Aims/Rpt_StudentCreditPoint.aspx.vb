
Partial Class Rpt_StudentCreditPoint
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim QS As String
        Dim Batch As Integer = ddlBatchName.SelectedValue
        Dim Semester As Integer = ddlSemester.SelectedValue
        QS = Request.QueryString.Get("QS")
        'If ddlCourseName.SelectedValue = 0 Or ddlBatchName.SelectedValue = 0 Or ddlSemester.SelectedValue = 0 Then
        '    lblMsg.Text = "Please Select all Mandatory Fields."
        'Else
        Dim qrystring As String = "Rpt_StudentCreditV.aspx?" & QueryStr.Querystring() & "&Batch=" & Batch & "&Semester=" & Semester
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        lblMsg.Text = ""
        'End If

    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

End Class
