Partial Class UserRequest
    Inherits BasePage
    Dim prop As New UserRequestE
    Dim bal As New UserRequestB
    Dim dt As New Data.DataTable
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
        prop.UserId = Session("UserName")
        prop.UserName = txtUserName.Text
        prop.RequestDate = CDate(txtDate.Text)
        prop.Priority = ddlPriority.SelectedItem.Text
        prop.DescOfRequest = txtDscReq.Text
        UserRequestB.Insert(prop)
        msginfo.Text = "Your request is registered."
        grdUserReq.Visible = False
        txtUserName.Text = ""
        txtDate.Text = ""
        ddlPriority.Text = ""
            txtDscReq.Text = ""
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add data."
            msginfo.Text = ""
        End If
    End Sub

    Protected Sub btnStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        Dim UserID As String = Session("UserName")
        If UserID.Length = 0 Then
            msginfo.Text = "You are not logged in."
        Else
            dt.Clear()
            dt = UserRequestB.GetData(UserID)
            grdUserReq.DataSource = dt
            grdUserReq.DataBind()
            grdUserReq.Visible = True
            txtUserName.Text = ""
            txtDate.Text = ""
            ddlPriority.Text = ""
            txtDscReq.Text = ""
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        grdUserReq.Visible = False
        txtUserName.Text = ""
        txtDate.Text = ""
        ddlPriority.Text = ""
        txtDscReq.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
