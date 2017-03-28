
Partial Class RptStudentAttendanceSummMonthWise
    Inherits BasePage
    Dim id1 As String = ""

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim SemId, BatchId As Integer
        Dim batchName As String
        BatchId = ddlBatchName.SelectedValue
        If BatchId = 0 Then
            lblerrormsg.Text = "Batch Field is Mandatory."
            Exit Sub
        End If
        batchName = ddlBatchName.SelectedItem.Text
        SemId = ddlSemester.SelectedValue
        Dim qrystring As String = "RptStudentAttendanceSummMonthWiseV.aspx?" & "&BatchId=" & BatchId & "&SemId=" & SemId & "&batchName=" & batchName
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        lblerrormsg.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.SelectedIndexChanged
        ddlSemester.Focus()
    End Sub

  
End Class
