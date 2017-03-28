
Partial Class Rpt_MFg_Saleorder
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim str As String
        Dim QS As String
        Dim Buyer_ID As Integer
        Dim SO_No As Integer
        Dim StartDate As Date
        Dim EndDate As Date
        Try
            Buyer_ID = DDlBuyer.SelectedValue
            SO_No = ddlSO.SelectedValue
            If txtStartDate.Text = "" Then
                StartDate = "1/1/1900"
            Else
                StartDate = txtStartDate.Text
            End If
            If txtEndDate.Text = "" Then
                EndDate = "1/1/3000"
            Else
                EndDate = txtEndDate.Text
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "Rpt_Mfg_SO.aspx?" & QueryStr.Querystring() & "&Buyer_ID=" & Buyer_ID & "&SO_No=" & SO_No & "&StartDate=" & StartDate & "&EndDate=" & EndDate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ddlSO.Enabled = False

        If IsPostBack Then
            If DDlBuyer.SelectedValue = 0 Then
                ddlSO.Enabled = False
                txtEndDate.Enabled = True
                txtStartDate.Enabled = True
            Else
                ddlSO.Enabled = True
                If ddlSO.SelectedValue = 0 Then
                    txtEndDate.Enabled = True
                    txtStartDate.Enabled = True
                Else
                    txtEndDate.Enabled = False
                    
                    txtStartDate.Enabled = False
                End If

            End If

        End If

    End Sub
End Class
