
Partial Class RptHostelRoomDetails
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblMsg.Text = ""

        Dim BranchCode As String
        If ddlBranchName.SelectedValue = "" Then
            BranchCode = 0
        Else
            BranchCode = ddlBranchName.SelectedValue
        End If
        Dim HID As Integer = cmbHosName.SelectedValue
        Dim RID As Integer = cmbRoomType.SelectedValue

        Dim qrystring As String = "RptHostelRoomDetailsV.aspx?" & QueryStr.Querystring() & "&HID=" & HID & "&RID=" & RID & "&BranchCode=" & BranchCode
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
