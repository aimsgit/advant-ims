
Partial Class RptStudentLeaveApplicaion
    Inherits BasePage

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        Try
            Dim qrystring As String = "RptStudentLeaveApplicaionV.aspx?" & "&BranchCode=" & Session("BranchCode") & "&Batch=" & DdlBatchPlanner.SelectedValue & "&Batch_no=" & DdlBatchPlanner.SelectedItem.Text & "&Semester=" & 0 & "&StudentID=" & ddlStudent.SelectedValue
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            lblRed.Text = "Error in Processing Data."
            lblGreen.Text = ""
        End Try
    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
