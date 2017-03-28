
Partial Class RptSemMarksAttendList
    Inherits BasePage

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        Dim BatchID, Semester, Assessmentid, id As Integer
        Dim Strtdate, EndDate, AssessmentType As String

        BatchID = ddlBatchName.SelectedValue
        Semester = DDLSemester.SelectedValue
        Assessmentid = ddlassessment.SelectedValue
        Dim parts As String() = ddlassessment.SelectedItem.Text.Split(New Char() {":"})
        AssessmentType = parts(0).ToString
        id = ddlSort.SelectedValue

        Dim dt As DataTable
        

        If ddlBatchName.SelectedValue = "0" Or DDLSemester.SelectedValue = "0" Or ddlassessment.SelectedValue = "0" Then
            msginfo.Text = "Enter all Mandatory Fields."
        Else
            dt = DLNew_StudentMarks.GetAssesmentTypeWitDateCombo(BatchID, Semester)
            EndDate = Right(ddlassessment.SelectedItem.Text, 11)
            Strtdate = dt.Rows(0).Item("SrtDate")
            'If id = 0 Then
            msginfo.Text = ""
            Dim qrystring As String = "RptSemMarksAttendListV.aspx?" & QueryStr.Querystring() & "&BatchID=" & BatchID & "&Semester=" & Semester & "&Assessmentid=" & Assessmentid & "&id=" & id & "&Strtdate=" & Strtdate & "&EndDate=" & EndDate & "&AssessmentType=" & AssessmentType
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            'Else
            '    msginfo.Text = ""
            '    Dim qrystring As String = "RptSemMarksAttendListV1.aspx?" & QueryStr.Querystring() & "&BatchID=" & BatchID & "&Semester=" & Semester & "&Assessmentid=" & Assessmentid
            '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

            'End If

        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    'Protected Sub ddlBatchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.SelectedIndexChanged
    '    ddlBatchName.Focus()
    'End Sub
    'Protected Sub DDLSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLSemester.SelectedIndexChanged
    '    DDLSemester.Focus()
    'End Sub
    'Protected Sub ddlassessment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassessment.SelectedIndexChanged
    '    ddlassessment.Focus()
    'End Sub

End Class
