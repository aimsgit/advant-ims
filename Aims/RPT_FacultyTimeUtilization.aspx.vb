Imports System.Data.SqlClient
Partial Class RPT_FacultyTimeUtilization

    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim EMPID As Integer
        Dim CourseID, BatchID, SemesterID, SubjectID As Integer
        EMPID = DdlFaculty.SelectedValue
        CourseID = ddlCourse.SelectedValue
        BatchID = ddlBatch.SelectedValue
        SemesterID = cmbSemester.SelectedValue
        SubjectID = DDLSubject.SelectedValue
        Dim EMP_Name As String = DdlFaculty.SelectedItem.Text
        Dim qrystring As String = "RptFacultyTimeUtilizationV.aspx?" & QueryStr.Querystring() & "&EMPID=" & EMPID & "&CourseID=" & CourseID & "&BatchID=" & BatchID & "&SemesterID=" & SemesterID & "&SubjectID=" & SubjectID & "&Emp_Name=" & EMP_Name
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
    End Sub



    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub DdlFaculty_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlFaculty.SelectedIndexChanged
        DdlFaculty.Focus()
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        ddlCourse.Focus()
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        ddlBatch.Focus()
    End Sub

    Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
        cmbSemester.Focus()
    End Sub

    Protected Sub DDLSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLSubject.SelectedIndexChanged
        DDLSubject.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
