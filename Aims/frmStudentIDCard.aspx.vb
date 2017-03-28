
Partial Class frmStudentIDCard
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Dim Batch As Integer
        Dim Course As Integer
        Dim Student As String
        Try
            Batch = ddlBatch.SelectedValue
            Course = ddlCourseName.SelectedValue
            Student = ddlStudent.SelectedValue

            Dim qrystring As String = "StudentIDCardV.aspx?" & QueryStr.Querystring() & "&Batch=" & Batch & "&Course=" & Course & "&Student=" & Student
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
