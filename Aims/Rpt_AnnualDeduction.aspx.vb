
Partial Class Rpt_AnnualDeduction
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Try
            If ddlYear.SelectedItem.Text > ddlYearTo.SelectedItem.Text Then

                lblRed.Text = "From Year should be less than To Year. "
                lblGreen.Text = ""
                Exit Sub
            Else
                lblRed.Text = ""
                lblGreen.Text = ""

                Dim qrystring As String = "Rpt_AnnualDeductionView.aspx?" & QueryStr.Querystring() & "&FromYear=" & ddlYear.SelectedItem.Text & "&ToYear=" & ddlYearTo.SelectedItem.Text & "&DeptID=" & ddlDept.SelectedValue & "&EmpId=" & DdlEmpName.SelectedValue & "&FromMonth=" & ddlFrom.SelectedValue & "&ToMonth=" & ddlTo.SelectedValue
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

           
            End If
        Catch ex As Exception
            lblRed.Text = "Enter correct Data."
            lblGreen.Text = ""

        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class

