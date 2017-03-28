
Partial Class ViewMsgStatusPopUp
    Inherits BasePage
    Dim bl As New BLCommunication

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim dt As New DataTable
        dt = bl.GetViewStatus()
        If dt.Rows.Count > 0 Then
            GvViewStatus.DataSource = dt
            GvViewStatus.DataBind()
            GvViewStatus.Visible = True
            GvViewStatus.Enabled = True
        Else
            lblError.Text = "No records to display."
            lblMsg.Text = ""
            GvViewStatus.Visible = "false"
        End If
    End Sub

    Protected Sub GvViewStatus_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvViewStatus.PageIndexChanging
        GvViewStatus.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GvViewStatus.PageIndex

        GvViewStatus.Visible = True
    End Sub
End Class
