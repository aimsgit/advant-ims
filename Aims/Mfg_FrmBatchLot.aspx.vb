
Partial Class Mfg_FrmBatchLot
    Inherits BasePage
    Dim EL As New Mfg_ELBatchLot
    Dim BL As New Mfg_BLBatchLot
    Dim dt As New datatable
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        'txtArea.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Batch = txtBatch.Text
            EL.Productid = DDLProduct.Selectedvalue
            EL.Processid = ddlProcess.Selectedvalue
            EL.Issueid = DdlIssueNo.Selectedvalue
            EL.MfgDate = txtMfgDate.Text
            EL.Remarks = txtRemarks.Text
            If btnadd.Text = "UPDATE" Then
                EL.id = ViewState("IID")
                'dt = BL.GetDuplicateShift(EL)
                If dt.Rows.Count > 0 Then
                    'DisplayGrid()
                    lblGreen.Text = ""
                    lblRed.Text = "Data already exists."
                Else
                    BL.UpdateRecord(EL)
                    btnadd.Text = "ADD"
                    btnDet.Text = "VIEW"
                    Clear()
                    GVShiftMaster.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    lblRed.Text = ""
                    lblGreen.Text = "Data Updated Successfully."
                End If
            ElseIf btnadd.Text = "ADD" Then
                If dt.Rows.Count > 0 Then
                    DisplayGrid()
                    Clear()
                    lblGreen.Text = ""
                    lblRed.Text = "Data already exists."
                Else
                    EL.id = 0
                    'dt = BL.GetDuplicateShift(EL)
                    BL.InsertRecord(EL)
                    lblRed.Text = ""
                    ViewState("PageIndex") = 0
                    GVShiftMaster.PageIndex = 0
                    DisplayGrid()
                    Clear()
                    lblRed.Text = ""
                    lblGreen.Text = "Data Saved Successfully."
                End If
            End If
        Else
            lblRed.Text = "You do not belong to this branch, Cannot add data."
            lblGreen.Text = ""
        End If
    End Sub
    Sub Clear()
        txtbatch.Text = ""
        txtRemarks.Text = ""
    End Sub
    Sub DisplayGrid()
        EL.id = 0
        dt = BL.GetGridData(EL.id)
        If dt.Rows.Count = 0 Then
            GVShiftMaster.DataSource = Nothing
            GVShiftMaster.DataBind()
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
        Else
            GVShiftMaster.DataSource = dt
            GVShiftMaster.DataBind()
            GVShiftMaster.Enabled = True
            GVShiftMaster.Visible = True
        End If
    End Sub

    Protected Sub btnDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click
        'LinkButton1.Focus()
        lblRed.Text = ""
        lblGreen.Text = ""
        If btnDet.Text <> "BACK" Then
            ViewState("PageIndex") = 0
            GVShiftMaster.PageIndex = 0
            DisplayGrid()
            GVShiftMaster.Visible = True
        Else
            Clear()
            btnDet.Text = "VIEW"
            btnadd.Text = "ADD"
            GVShiftMaster.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        End If
    End Sub

    Protected Sub GVShiftMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVShiftMaster.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("IID") = CType(GVShiftMaster.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            EL.id = ViewState("IID")
            If BL.ChangeFlag(EL) Then
                lblRed.Text = ""
                lblGreen.Text = "Data Deleted Successfully."
                txtBatch.Focus()
                GVShiftMaster.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                GVShiftMaster.Enabled = True
            End If
        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub GVShiftMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVShiftMaster.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblRed.Text = ""
            lblGreen.Text = ""
            txtBatch.Text = CType(GVShiftMaster.Rows(e.NewEditIndex).FindControl("lblBatch"), Label).Text
            ViewState("IID") = CType(GVShiftMaster.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
            DDLProduct.SelectedValue = CType(GVShiftMaster.Rows(e.NewEditIndex).FindControl("lblPID"), Label).Text
            txtMfgDate.Text = CType(GVShiftMaster.Rows(e.NewEditIndex).FindControl("lblMfgDate"), Label).Text
            ddlProcess.SelectedValue = CType(GVShiftMaster.Rows(e.NewEditIndex).FindControl("lblProcessId"), Label).Text
            DdlIssueNo.SelectedValue = CType(GVShiftMaster.Rows(e.NewEditIndex).FindControl("lblStockIssueId"), Label).Text
            txtRemarks.Text = CType(GVShiftMaster.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
            btnadd.Text = "UPDATE"
            btnDet.Text = "BACK"
            EL.id = ViewState("IID")
            dt = BL.GetGridData(EL.id)
            GVShiftMaster.DataSource = dt
            GVShiftMaster.DataBind()
            GVShiftMaster.Enabled = False
        Else
            lblRed.Text = "You do not belong to this branch, Cannot edit data."
            lblGreen.Text = ""
        End If
    End Sub
End Class
