
Partial Class Rpt_frmBudgetVariance
    Inherits BasePage
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim ProjectId As Integer
        Dim ReportDate As DateTime

        Try
            If ddlCompany.SelectedValue = "" Then
                lblErrorMsg.Text = "Please select Company name."
            Else
                ProjectId = ddlCompany.SelectedValue
            End If
            If txtStartDate.Text = "" Then
                ReportDate = "01/01/1900"
            Else
                ReportDate = txtStartDate.Text
            End If


            If ddlCompany.SelectedValue = "" And txtStartDate.Text = "" Then

                lblErrorMsg.Text = "Please enter all Mandatory Fields"
            Else
                Dim qrystring As String = "Rpt_frmBudgetVarianceV.aspx?" & "&ProjectId=" & ProjectId & "&ReportDate=" & ReportDate
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                lblErrorMsg.Text = ""
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Please enter correct data."
        End Try

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        ddlCompany.Focus()
        If Not IsPostBack Then
            txtStartDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
End Class
 