
Partial Class rptTimeTableTeacher
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim Teacher As Integer = ddlTeacher.SelectedValue
        Dim TeacherName As String = ddlTeacher.SelectedItem.Text

        If ddlTeacher.SelectedItem.Value = "0" Then
            lblMsg.Visible = True
            lblMsg.Text = "Please select Teacher Field."
        Else
            lblMsg.Visible = False
            Dim qrystring As String = "rptTimeTableTeacherV.aspx?" & QueryStr.Querystring() & "&Teacher=" & Teacher & "&TeacherName=" & TeacherName
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
