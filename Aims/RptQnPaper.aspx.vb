
Partial Class RptQnPaper
    Inherits BasePage


    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If ddlCourseName.SelectedValue = "0" Or ddlBatchName.SelectedValue = "0" Or ddlSemester.SelectedValue = "0" Or ddlSubject.SelectedValue = "0" Then
            lblErrorMsg.Text = "Enter all Mandatory feilds."
        Else
            lblErrorMsg.Text = ""
            Dim Crs As Integer = ddlCourseName.SelectedValue
            Dim Batch As Integer = ddlBatchName.SelectedValue
            Dim Sem As Integer = ddlSemester.SelectedValue
            Dim subj As Integer = ddlSubject.SelectedValue
            Dim qrystring As String = "RptQnPaperV.aspx?" & QueryStr.Querystring() & "&Crs=" & Crs & "&Batch=" & Batch & "&Sem=" & Sem & "&subj=" & subj
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        End If

    End Sub


    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
