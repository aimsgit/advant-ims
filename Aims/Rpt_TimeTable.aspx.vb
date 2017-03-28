
Partial Class Rpt_TimeTable
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim QS As String
        Dim course As Integer = ddlCourseName.SelectedValue
        Dim Batch As Integer = ddlBatchName.SelectedValue
        Dim Semester As Integer = ddlSemester.SelectedValue
        Dim WeekNo As Integer = ddlWeekNo.SelectedValue
        Dim Subject As Integer = ddlSubject.SelectedValue
        Dim Teacher As Integer = ddlTeacher.SelectedValue

        QS = Request.QueryString.Get("QS")
        If ddlSubject.SelectedValue = 0 And ddlTeacher.SelectedValue = 0 Then



            'If QS = "Rpt58" Then
            If ddlCourseName.SelectedItem.Text = "Select" Or ddlBatchName.SelectedItem.Text = "Select" Or ddlSemester.SelectedItem.Text = "Select" Or ddlSemester.SelectedValue = 0 Then
                lblMsg.Text = "Please enter all Mandatory Fields."
                Exit Sub
            Else
                Dim qrystring As String = "Rpt_TimeTableV.aspx?" & QueryStr.Querystring() & "&Course=" & course & "&Batch=" & Batch & "&Semester=" & Semester & "&Subject=" & Subject & "&Teacher=" & Teacher & "&WeekNo=" & WeekNo
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                lblMsg.Text = ""
                'End If
            End If
        Else
            'If QS = "Rpt58" Then
            'WeekNo = ddlWeekNo.SelectedValue
            If ddlCourseName.SelectedItem.Text = "Select" Or ddlBatchName.SelectedItem.Text = "Select" Or ddlSemester.SelectedItem.Text = "Select" Or ddlSemester.SelectedValue = 0 Then
                lblMsg.Text = "Please enter all Mandatory Fields."
                Exit Sub
            Else
                Dim qrystring As String = "Rpt_TimeTablTeacherV.aspx?" & QueryStr.Querystring() & "&Course=" & course & "&Batch=" & Batch & "&Semester=" & Semester & "&Subject=" & Subject & "&Teacher=" & Teacher & "&WeekNo=" & WeekNo
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                lblMsg.Text = ""
                'End If
            End If

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
