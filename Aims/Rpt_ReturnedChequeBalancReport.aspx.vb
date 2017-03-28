
Partial Class Rpt_ReturnedChequeBalancReport
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try

            Dim BankId As Integer
            Dim StartDate As DateTime
            Dim EndDate As DateTime

            If ddlBank.SelectedValue = "" Then
                lblErrorMsg.Text = "Please select Bank name."
            Else
                BankId = ddlBank.SelectedValue
            End If
            If txtStartDate.Text = "" Then
                StartDate = "01/01/1900"
            Else
                StartDate = txtStartDate.Text
            End If
            If txtEndDate.Text = "" Then
                EndDate = "12/31/3000"
            Else
                EndDate = txtEndDate.Text
            End If

            If ddlBank.SelectedValue = "" And txtStartDate.Text = "" Then

                lblErrorMsg.Text = "Please enter all Mandatory Fields"
            Else
                Dim qrystring As String = "Rpt_ReturnedChequeBalanceReportV.aspx?" & "&BankId=" & BankId & "&StartDate=" & StartDate & "&EndDate=" & EndDate
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                lblErrorMsg.Text = ""
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Please enter correct data."
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

End Class
