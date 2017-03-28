
Partial Class RptPrincipleDashboard
    Inherits BasePage


    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click


        Dim AID As Integer = cmbAcademic.SelectedValue
       
        If cmbAcademic.SelectedItem.Value = "0" Then
            lblE.Text = " Select Mandatory Field."
            cmbAcademic.Focus()
        Else
            Dim qrystring As String = "RptPrincipleDashboardV.aspx?" & QueryStr.Querystring() & "&AID=" & AID
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblE.Text = ""
        End If
       

    End Sub


    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
