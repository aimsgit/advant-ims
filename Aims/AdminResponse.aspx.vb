Partial Class AdminResponse
    Inherits BasePage
    Dim BAL As New UserRequestB
    Dim Prop As New UserRequestE
    Dim dt As New Data.DataTable
    Dim rowsAffected As Int16
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Session("UserName") = Nothing Then
            msginfo.Text = "You are not Logged In"
        Else
            If txtID.Text = "" Then
                Prop.UserId = ""
            Else
                Prop.UserId = txtID.Text
            End If
            Prop.Status = ddlFilterStatus.SelectedItem.Text
            Prop.Priority = ddlFilterPriority.SelectedItem.Text
            Prop.RequestDate = CDate(txtFilterDate.Text)
            dt.Clear()
            dt = UserRequestB.GetData(Prop)
            grdUserReq.DataSource = dt
            grdUserReq.DataBind()
            grdUserReq.Visible = True
            grdUserReq.SelectedIndex = -1
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Prop.Id = CInt(hdnReqID.Value)
        Prop.ApprovedBy = txtAprName.Text
        Prop.Status = ddlStatus.SelectedItem.Text
        Prop.Remarks = txtRemarks.Text
        Prop.ClosedDate = CDate(txtDate.Text)
        txtAprName.Text = txtAprName.Text
        rowsAffected = UserRequestB.Update(Prop)
        If (rowsAffected <> 0) Then
            msginfo.Text = "The request status is updated."
            txtAprName.Text = ""
            txtRemarks.Text = ""
            btnCancel.Text = "OK"
            btnSearch_Click(sender, e)
        Else
            msginfo.Text = "Error occured while Processing your request."
        End If
        grdUserReq.SelectedIndex = -1
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PanelResponse.Visible = False
        PanelFilter.Visible = True
        txtFilterDate.Text = System.DateTime.Now
        txtRemarks.Text = ""
        txtAprName.Text = ""
    End Sub

    Protected Sub grdUserReq_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdUserReq.SelectedIndexChanged
        PanelFilter.Visible = False
        PanelResponse.Visible = True
        hdnReqID.Value = CInt(grdUserReq.SelectedRow.Cells(1).Text)
        txtAprName.Text = ""
        txtRemarks.Text = ""
        '-----Kusum
        'If grdUserReq.SelectedRow.Cells(7).Text <> Nothing Then
        '    txtAprName.Text = grdUserReq.SelectedRow.Cells(7).Text
        '    txtRemarks.Text = grdUserReq.SelectedRow.Cells(10).Text
        'End If
        grdUserReq.SelectedIndex = -1
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        PanelResponse.Visible = False
        PanelFilter.Visible = True
        txtFilterDate.Text = System.DateTime.Now
        grdUserReq.Visible = False
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click

    End Sub
    <System.Web.Services.WebMethod()> _
        Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
