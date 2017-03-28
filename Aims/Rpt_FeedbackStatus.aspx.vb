
Partial Class Rpt_FeedbackStatus
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try

            Dim CourseId As Integer
            Dim BatchId As Integer
            Dim SemId As Integer
            lblmsg.Text = ""
            Dim QS As String


            CourseId = ddlcourse.SelectedValue
            If cmbBatch.SelectedValue = "" Then
                BatchId = 0
            Else
                BatchId = cmbBatch.SelectedValue
            End If
            If ddlsem.SelectedValue = "" Then
                SemId = 0
            Else
                SemId = ddlsem.SelectedValue
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "Rpt_FeedbackStatusV.aspx?" & QueryStr.Querystring() & "&CourseId=" & CourseId & "&BatchId=" & BatchId & "&SemId=" & SemId
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct data."
        End Try

    End Sub
    
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
