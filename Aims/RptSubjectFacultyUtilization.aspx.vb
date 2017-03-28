
Partial Class RptSubjectFacultyUtilization

    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim EMPID As Integer
        Dim CourseID, BatchID, SemesterID, SubjectID As Integer
        EMPID = DdlFaculty.SelectedValue
        CourseID = ddlCourse.SelectedValue
        BatchID = ddlBatch.SelectedValue
        SemesterID = cmbSemester.SelectedValue
        SubjectID = ddlSubject.SelectedValue
        Dim qrystring As String = "RptSubjectFacultyUtilizationV.aspx?" & QueryStr.Querystring() & "&EMPID=" & EMPID & "&CourseID=" & CourseID & "&BatchID=" & BatchID & "&SemesterID=" & SemesterID & "&SubjectID=" & SubjectID
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
