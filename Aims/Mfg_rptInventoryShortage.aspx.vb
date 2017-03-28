
Partial Class Mfg_rptInventoryShortage
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim QS As String
        Dim ProductId As Integer
        Try
            If ddlProduct.SelectedValue = "" Then
                ProductId = 0
            Else
                ProductId = ddlProduct.SelectedValue
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "Mfg_rptInventoryShortageV.aspx?" & QueryStr.Querystring() & "&ProductId=" & ProductId
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class

