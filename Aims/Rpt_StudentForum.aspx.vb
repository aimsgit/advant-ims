
Partial Class Rpt_StudentForum
    Inherits BasePage
    Dim dt As New DataTable
    Dim dlrollover As New DLRollOver
    Dim Batch As New Integer
    Protected Sub ddlBatchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.SelectedIndexChanged
        Batch = ddlBatchName.SelectedValue
        dt = dlrollover.getCourseName(Batch)
        If dt.Rows.Count > 0 Then
            txtCourse.Text = dt.Rows(0).Item("CourseName")
        End If
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            
            Dim qrystring As String = "Rpt_StudentForumV.aspx?" & QueryStr.Querystring() & "&Batch=" & ddlBatchName.SelectedValue
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        Catch ex As Exception
            lblRed.Text = "Enter correct Data."
            lblGreen.Text = ""
        End Try
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
