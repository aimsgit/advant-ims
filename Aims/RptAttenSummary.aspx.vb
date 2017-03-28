
Partial Class RptAttenSummary
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim QS As String
        Dim Batch As Integer = ddlBatchName.SelectedValue
        Dim Semester As Integer = ddlSemester.SelectedValue
        Dim Subject As Integer = cmbSubject.SelectedValue
        Dim Sort As Integer = ddlSort.SelectedValue

        QS = Request.QueryString.Get("QS")
        If ddlBatchName.SelectedValue = 0 And DDLSemester.SelectedValue = 0 Then
            lblMsg.Text = "Please enter all Mandatory Fields."
        Else
            Dim qrystring As String = "RptAttenSummayV.aspx?" & QueryStr.Querystring() & "&Batch=" & Batch & "&Semester=" & Semester & "&Subject=" & Subject & "&Sort=" & Sort
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblMsg.Text = ""
        End If

    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
