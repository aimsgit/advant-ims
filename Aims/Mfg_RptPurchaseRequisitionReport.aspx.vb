
Partial Class Mfg_RptPurchaseRequisitionReport
    Inherits BasePage

    Protected Sub btRpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btRpt.Click
        Try
            Dim PurchaseReqNo As String
            PurchaseReqNo = ddlPurchaseReqNo.SelectedValue
            Dim qrystring As String = "Mfg_RptPurchaseRequisitionReportV.aspx?" & QueryStr.Querystring() & "&StartDate=" & CDate(txtfromdate.Text) & "&EndDate=" & CDate(txttodate.Text) & "&PurchaseReqNo=" & PurchaseReqNo
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        Catch ex As Exception
            lblErrorMsg.Text = "Date is not valid."
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtfromdate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txttodate.Text = Format(Date.Today(), "dd-MMM-yyyy")
        End If
    End Sub
End Class
