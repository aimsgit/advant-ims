
Partial Class Rpt_SubjectSubgroup
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        ddlBatch.Focus()
        Dim BatchId As Integer = ddlBatch.SelectedValue
        Dim SemId As Integer = cmbSemester.SelectedValue
        Dim SubjectId As Integer = cmbSubject.SelectedValue
        Dim SubjectSubGrpId As Integer = ddlSubjectSubGrp.SelectedValue

        If cmbSubject.SelectedValue = " " Then
            SubjectId = 0
        Else
            SubjectId = cmbSubject.SelectedValue
        End If
        If ddlSubjectSubGrp.SelectedValue = " " Then
            SubjectSubGrpId = 0
        Else
            SubjectSubGrpId = ddlSubjectSubGrp.SelectedValue
        End If
        Try

            Dim qrystring As String = "Rpt_SubjectSubgroupV.aspx?" & QueryStr.Querystring() & "&BatchId=" & BatchId & "&SemId=" & SemId & "&SubjectId=" & SubjectId & "&SubjectSubGrpId=" & SubjectSubGrpId
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
