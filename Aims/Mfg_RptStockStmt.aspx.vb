
Partial Class Mfg_RptStockStmt
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim QS As String
        Dim Company_Id As Integer
        Try
            Company_Id = ddlCompany.SelectedValue
            QS = Request.QueryString.Get("QS")
            Dim StartDate As String
            Dim EndDate As String
            If txtstartdate.Text = "" Then
                StartDate = "1/1/1900"
            Else
                StartDate = txtstartdate.Text
            End If
            If txtenddate.Text = "" Then
                EndDate = "1/1/3000"
            Else
                EndDate = txtenddate.Text
            End If
            If StartDate > EndDate Then
                msginfo.Text = "Start date should not be greater than End date."
                txtenddate.Focus()
                Exit Sub
            End If
            Dim qrystring As String = "Mfg_RptStockStmrV.aspx?" & QueryStr.Querystring() & "&Company_Id=" & Company_Id & "&StartDate=" & StartDate & "&EndDate=" & EndDate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtstartdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtenddate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
