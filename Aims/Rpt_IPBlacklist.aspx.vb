
Partial Class Rpt_IPBlacklist
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreport.Click
        Try

            Dim Country As String = ddlCountry.SelectedItem.Text
            Dim User As String = ddlUser.SelectedValue
            Dim S_date As DateTime
            Dim E_date As DateTime
            If txtSdate.Text = "" Then
                S_date = "01/01/1900"
            Else
                S_date = txtSdate.Text
            End If
            If txtEdate.Text = "" Then
                E_date = "01/01/3000"
            Else
                E_date = txtEdate.Text
            End If
            lblRed.Text = ""
            lblGreen.Text = ""
            Dim qrystring As String = "Rpt_IPBlacklistV.aspx?" & "&Country=" & Country & "&User=" & User & "&Sdate=" & S_date & "&Edate=" & E_date
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
          

        Catch ex As Exception
            lblRed.Text = "Please enter correct data."
        End Try
    End Sub
End Class
