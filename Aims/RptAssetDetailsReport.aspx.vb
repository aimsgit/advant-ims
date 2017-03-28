
Partial Class RptAssetDetailsReport
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            msginfo.Text = ""
            Dim AT As String = ddlassetType.SelectedValue
            Dim SUP As Integer = ddlsupplier.SelectedValue
            Dim MAN As Integer = ddlmanufacturer.SelectedValue
            Dim GRN As String = ddlgrnno.SelectedValue
            Dim FromDate As Date
            Dim ToDate As Date
            If txtFromDate.Text = "" Then
                FromDate = "01/01/1900"
            Else
                FromDate = txtFromDate.Text
                txtFromDate.Text = Format(FromDate, "dd-MMM-yyyy")
            End If
            If txtToDate.Text = "" Then
                ToDate = Format(Today.Date(), "dd-MMM-yyyy")
            Else
                ToDate = txtToDate.Text
            End If
            If txtFromDate.Text <> "" And txtToDate.Text <> "" Then
                If FromDate > ToDate Then
                    lblmsg.Text = ""
                    msginfo.Text = "From date should not be greater than To date."
                    txtToDate.Focus()
                    Exit Sub
                End If
            End If
            Dim qrystring As String = "RptAssetDetailsReportV.aspx?" & "&AssetType=" & AT & "&Supplier=" & SUP & "&Manufacturer=" & MAN & "&Grnno=" & GRN & "&FromDate=" & FromDate & "&ToDate=" & ToDate
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
        Catch ex As Exception
            msginfo.Text = "Date is Not Valid."
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
