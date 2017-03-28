
Partial Class RptAssetTransfer
    Inherits BasePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtToDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try

            Dim AssetType As Integer = ddlassetType.SelectedValue
            Dim AssetName As Integer = ddlAssetName.SelectedValue
            Dim FromDate As Date
            Dim ToDate As Date
            If txtFrmDate.Text = "" Then
                FromDate = "01/01/1900"
            Else
                FromDate = txtFrmDate.Text
                txtFrmDate.Text = Format(FromDate, "dd-MMM-yyyy")
            End If
            If txtToDate.Text = "" Then
                ToDate = Format(Today.Date(), "dd-MMM-yyyy")
            Else
                ToDate = txtToDate.Text
            End If
            If txtFrmDate.Text <> "" And txtToDate.Text <> "" Then
                If FromDate > ToDate Then

                    lblErrorMsg.Text = "From date should not be greater than To date."
                    txtToDate.Focus()
                    Exit Sub
                End If
            End If
            Dim qrystring As String = "RptAssetTransfrV.aspx?" & "&AssetType=" & AssetType & "&AssetName=" & AssetName & "&FromDate=" & FromDate & "&ToDate=" & ToDate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblErrorMsg.Text = ""
        Catch ex As Exception
            lblErrorMsg.Text = "Date is Not Valid."
        End Try
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
