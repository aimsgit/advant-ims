
Partial Class FrmStudentAttendanceSheet
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim QS As String
        Dim SemId As Integer = ddlSemester.SelectedValue
        Dim Batch As Integer = ddlBatchName.SelectedValue
        Dim Subject As Integer = ddlSubjectName.SelectedValue
        QS = Request.QueryString.Get("QS")
        If ddlBatchName.SelectedItem.Value = "0" Or ddlSemester.SelectedItem.Value = "0" Or ddlSubjectName.SelectedItem.Value = "0" Then
            lblMsg.Text = "Please enter all Mandatory Fields."
        Else
            Dim qrystring As String = "RptStudentAttendanceSheetV.aspx?" & QueryStr.Querystring() & "&Batch=" & Batch & "&Semester=" & SemId & "&Subject=" & Subject
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblMsg.Text = ""
        End If

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
