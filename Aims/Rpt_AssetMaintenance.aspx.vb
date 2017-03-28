
Partial Class Rpt_AssetMaintenance
    Inherits BasePage
    Dim EL As New Asset

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim FromDate As Date
        Dim ToDate As Date
        If txtStartDate.Text = "" Then
            FromDate = "01/01/1900"
        Else
            FromDate = txtStartDate.Text
            txtStartDate.Text = Format(FromDate, "dd-MMM-yyyy")
        End If
        If txtEndDate.Text = "" Then
            ToDate = Format(Today.Date(), "dd-MMM-yyyy")
        Else
            ToDate = txtEndDate.Text
        End If
        If txtStartDate.Text <> "" And txtEndDate.Text <> "" Then
            If FromDate > ToDate Then

                msginfo.Text = "From date should not be greater than To date."
                txtEndDate.Focus()
                Exit Sub
            End If
        End If
        Dim qrystring As String = "Rpt_AssetMaintenanceV.aspx?" & QueryStr.Querystring() & "&assetType=" & ddlassetType.SelectedValue & "&AssetName=" & ddlAssetName.SelectedValue & "&FromDate=" & FromDate & "&ToDate=" & ToDate
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtStartDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
End Class
