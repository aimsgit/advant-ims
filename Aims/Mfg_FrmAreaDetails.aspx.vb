
Partial Class Mfg_FrmAreaDetails
    Inherits BasePage
    Dim EL As New Mfg_ELAreaDetails
    Dim BL As New Mfg_BLAreaDetails
    Dim dt As New DataTable

    'code by Anchala on 11-08-12
    '    'method for insert and update
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtArea.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Area = txtArea.Text
            EL.City = txtcity.Text
            EL.State = txtstate.Text
            If btnSave.Text = "UPDATE" Then
               EL.id = ViewState("AreaAutoNo")
                'dt = BL.GetDuplicateYear(EL.Area, EL.id)
                If dt.Rows.Count > 0 Then
                    'DisplayGrid()
                    lblmsgifo.Text = ""
                    lblerrmsg.Text = "Data already exists."
                Else
                    BL.UpdateRecord(EL)
                    btnSave.Text = "ADD"
                    btnDetails.Text = "VIEW"
                    Clear()
                    GrdArea.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    lblerrmsg.Text = ""
                    lblmsgifo.Text = "Data Updated Successfully."
                End If
            ElseIf btnSave.Text = "ADD" Then
                EL.Area = txtArea.Text
                'dt = BL.GetDuplicateYear(EL.Area, EL.id)
                If dt.Rows.Count > 0 Then
                    DisplayGrid()
                    Clear()
                    lblmsgifo.Text = ""
                    lblerrmsg.Text = "Data already exists."
                Else
                    BL.InsertRecord(EL)
                    lblerrmsg.Text = ""
                    ViewState("PageIndex") = 0
                    GrdArea.PageIndex = 0
                    DisplayGrid()
                    Clear()
                    lblerrmsg.Text = ""
                    lblmsgifo.Text = "Data Saved Successfully."
                End If
            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add data."
            lblmsgifo.Text = ""
        End If
    End Sub
    Sub DisplayGrid()
        EL.id = 0
        dt = BL.GetGridData(EL.id)
        If dt.Rows.Count = 0 Then
            GrdArea.DataSource = Nothing
            GrdArea.DataBind()
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
        Else
            GrdArea.DataSource = dt
            GrdArea.DataBind()
            GrdArea.Enabled = True
            GrdArea.Visible = True
        End If
    End Sub
    Sub Clear()
        txtArea.Text = ""
        txtcity.Text = ""
        txtstate.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> _
   Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
    'code by Anchala on 11-08-12
    '    'method for display
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        LinkButton1.Focus()
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        If btnDetails.Text <> "BACK" Then
            ViewState("PageIndex") = 0
            GrdArea.PageIndex = 0
            DisplayGrid()
            GrdArea.Visible = True
        Else
            Clear()
            btnDetails.Text = "VIEW"
            btnSave.Text = "ADD"
            GrdArea.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        End If
    End Sub
    'code by Anchala on 11-08-12
    '    'method for delete
    Protected Sub GrdArea_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdArea.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("AreaAutoNo") = CType(GrdArea.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            EL.id = ViewState("AreaAutoNo")
            If BL.ChangeFlag(EL) Then
                lblerrmsg.Text = ""
                lblmsgifo.Text = "Data Deleted Successfully."
                txtArea.Focus()
                GrdArea.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                GrdArea.Enabled = True
            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If
    End Sub
    Protected Sub GrdArea_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdArea.PageIndexChanging
        GrdArea.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GrdArea.PageIndex
        DisplayGrid()
    End Sub
    'code by Anchala on 11-08-12
    '    'method for edit
    Protected Sub GrdArea_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdArea.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            txtArea.Text = CType(GrdArea.Rows(e.NewEditIndex).FindControl("LblArea"), Label).Text
            ViewState("AreaAutoNo") = CType(GrdArea.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
            txtcity.Text = CType(GrdArea.Rows(e.NewEditIndex).FindControl("lblcity"), Label).Text
            txtstate.Text = CType(GrdArea.Rows(e.NewEditIndex).FindControl("lblstate"), Label).Text


            btnSave.Text = "UPDATE"
            btnDetails.Text = "BACK"
            EL.id = ViewState("AreaAutoNo")
            dt = BL.GetGridData(EL.id)
            GrdArea.DataSource = dt
            GrdArea.DataBind()
            GrdArea.Enabled = False
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtArea.Focus()
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
    End Sub
End Class
