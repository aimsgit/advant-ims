
Partial Class Mfg_frmStockIssue
    Inherits BasePage
    Dim EL As New Mfg_StockIssue
    Dim BL As New Mfg_BLRStockIssue
    Dim dt, dt1 As New DataTable
    Dim ProductId, BatchId As Integer
    Dim PostStatus As String

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            dt = BL.GetStockIssueNo()
            dt1 = BL.GetDelivaryChallanNo()
            txtIssueNo.Text = dt.Rows(0).Item("StockIssueNo")
            txtDCNo.Text = dt1.Rows(0).Item("DCNo")

            txtDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            EL.IssueNo = txtIssueNo.Text
            EL.DCNo = txtDCNo.Text
            EL.EntryDate = txtDate.Text
            EL.WorkOrder = ddlWorkOrder.SelectedValue
            EL.IndentNo = txtIndentNo.Text
            EL.DONo = txtDONo.Text
            EL.PartyType = cmbPType.SelectedValue
            EL.PartyName = ddlPName.SelectedValue
            If BtnAdd.Text = "UPDATE" Then
                EL.id = ViewState("StockId")
                dt = BL.CheckStockIssuePostStatusMain(EL)
                PostStatus = dt.Rows(0).Item("PostToStk").ToString
                If PostStatus = "Y" Then
                    lblRedM.Text = "Record is already Posted, so data cannot be Updated."
                    lblGreenM.Text = ""
                Else
                    BL.UpdateStockIssue(EL)
                    GVStockIssue.Visible = True
                    BtnAdd.Text = "ADD"
                    btnView.Text = "VIEW"
                    ClearMain()
                    lblRedM.Text = ""

                    DisplayMain()
                    lblGreenM.Text = "Data Updated Successfully."
                    GetStockIssueNo()
                End If
            ElseIf BtnAdd.Text = "ADD" Then
                EL.id = 0
                BL.InsertStockIssue(EL)
                BtnAdd.Text = "ADD"
                btnView.Text = "VIEW"
                DisplayMain()
                ClearMain()
                lblRedM.Text = ""
                'ViewState("PageIndex") = 0
                ''GVStockIssueDetails.PageIndex = 0
                lblGreenM.Text = "Data Saved Successfully."
                GetStockIssueNo()
                'TabPanel2.Enabled = True
                'TabPanel1.Enabled = False
                'End If
            End If
        Else
            lblRedM.Text = "You do not belong to this branch, Cannot add data."
            lblGreenM.Text = ""
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If btnView.Text <> "BACK" Then
            lblGreenM.Text = ""
            lblRedM.Text = ""
            ViewState("PageIndex") = 0
            'GVStockIssue.PageIndex = 0
            DisplayMain()
        Else
            DisplayMain()
            lblGreenM.Text = ""
            lblRedM.Text = ""
            'GVStockIssue.Enabled = True
            'GVStockIssue.PageIndex = ViewState("PageIndex")
            ClearMain()
            btnView.Text = "VIEW"
            BtnAdd.Text = "ADD"
            GetStockIssueNo()
        End If
    End Sub
    Sub DisplayMain()
        EL.id = 0
        dt = BL.GridviewStockIssueMain(EL)
        If dt.Rows.Count <> 0 Then
            GVStockIssue.DataSource = dt
            GVStockIssue.DataBind()
            GVStockIssue.Visible = True
            GVStockIssue.Enabled = True
            txtIssueNo.Enabled = True
        Else
            lblGreenM.Text = ""
            lblRedM.Text = "No Records to display."
            GVStockIssue.Visible = False
        End If
    End Sub
    Sub ClearMain()
        txtIndentNo.Text = ""
        ddlPName.ClearSelection()
        cmbPType.ClearSelection()
        ddlWorkOrder.ClearSelection()
        txtDONo.Text = ""
    End Sub
    Sub CheckAll()
        If CType(GVStockIssue.HeaderRow.FindControl("chkhdr"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVStockIssue.Rows
                CType(grid.FindControl("chkChild"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVStockIssue.Rows
                CType(grid.FindControl("chkChild"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub GVStockIssue_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVStockIssue.PageIndexChanging
        GVStockIssue.PageIndex = e.NewPageIndex
        DisplayMain()
    End Sub
    Protected Sub GVStockIssue_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVStockIssue.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'Dim ID As Integer
            lblGreenM.Text = ""
            lblRedM.Text = ""
            txtIssueNo.Text = CType(GVStockIssue.Rows(e.NewEditIndex).FindControl("lblStockIssueNo"), Label).Text
            txtDCNo.Text = CType(GVStockIssue.Rows(e.NewEditIndex).FindControl("lblDCNo"), Label).Text
            txtDate.Text = CType(GVStockIssue.Rows(e.NewEditIndex).FindControl("lblIssueDate"), Label).Text
            txtIndentNo.Text = CType(GVStockIssue.Rows(e.NewEditIndex).FindControl("lblIndentNo"), Label).Text
            txtDONo.Text = CType(GVStockIssue.Rows(e.NewEditIndex).FindControl("lblDONo"), Label).Text
            ddlWorkOrder.SelectedValue = CType(GVStockIssue.Rows(e.NewEditIndex).FindControl("lblSaleOrder"), Label).Text
            cmbPType.SelectedValue = CType(GVStockIssue.Rows(e.NewEditIndex).FindControl("lblPartyTypeId"), Label).Text
            ddlPName.ClearSelection()
            ddlPName.Items.Clear()
            ddlPName.DataSourceID = "ObjParty_Name"
            ddlPName.DataBind()
            ddlPName.SelectedValue = CType(GVStockIssue.Rows(e.NewEditIndex).FindControl("lblPartyNameId"), Label).Text
            ViewState("StockId") = CType(GVStockIssue.Rows(e.NewEditIndex).FindControl("StockId"), HiddenField).Value
            BtnAdd.Text = "UPDATE"
            EL.id = ViewState("StockId")
            EL.PartyName = ddlPName.SelectedValue
            EL.PartyType = cmbPType.SelectedValue
            dt = BL.GridviewStockIssueMain(EL)
            GVStockIssue.DataSource = dt
            GVStockIssue.DataBind()
            GVStockIssue.Enabled = False
            txtIssueNo.Enabled = False
            btnView.Text = "BACK"
            btnView.Visible = True

        Else
            lblRedM.Text = "You do not belong to this branch, Cannot edit data."
            lblGreenM.Text = ""
        End If
    End Sub
    Protected Sub GVStockIssue_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVStockIssue.RowDeleting
        Dim rowsaffected As Integer
        lblGreenM.Text = ""
        lblRedM.Text = ""
        EL.id = CType(GVStockIssue.Rows(e.RowIndex).FindControl("StockId"), HiddenField).Value
        dt = BL.CheckStockIssuePostStatusMain(EL)
        PostStatus = dt.Rows(0).Item("PostToStk").ToString
        If PostStatus = "Y" Then
            lblRedM.Text = "Record is already Posted, so data cannot be Deleted."
            lblGreenM.Text = ""
        Else
            rowsaffected = BL.DeteteStockIssue(EL)
            lblGreenM.Text = "Record Deleted Successfully."
            EL.id = 0
            dt = BL.GridviewStockIssueMain(EL)
            GVStockIssue.DataSource = dt
            GVStockIssue.DataBind()
        End If
    End Sub
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        TabPanel2.Enabled = False
        TabPanel1.Enabled = True
    End Sub
    Sub GetStockIssueNo()
        dt = BL.GetStockIssueNo()
        dt1 = BL.GetDelivaryChallanNo()
        txtIssueNo.Text = dt.Rows(0).Item("StockIssueNo")
        txtDCNo.Text = dt1.Rows(0).Item("DCNo")
    End Sub

    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim Count As Integer = 0

        For Each Grid As GridViewRow In GVStockIssue.Rows
            If CType(Grid.FindControl("chkChild"), CheckBox).Checked = True Then
                Count = Count + 1
            End If
        Next

        If Count = 0 Then
            lblRedM.Text = "Please select a Record to Post."
            lblGreenM.Text = ""
            Exit Sub
        End If

        

        For Each Grid As GridViewRow In GVStockIssue.Rows
            If CType(Grid.FindControl("chkChild"), CheckBox).Checked = True And CType(Grid.FindControl("lblPost"), Label).Text = "Not Posted" Then
                EL.StockIssueId = CType(Grid.FindControl("StockId"), HiddenField).Value
                BL.PostToStockIssue(EL)
                lblGreenM.Text = "Record Posted Successfully."
                lblRedM.Text = ""
            ElseIf CType(Grid.FindControl("chkChild"), CheckBox).Checked = True And CType(Grid.FindControl("lblPost"), Label).Text = "Posted" Then
                lblRedM.Text = "Record is already Posted."
                lblGreenM.Text = ""
            End If
        Next

        DisplayMain()
    End Sub
    Protected Sub btnAdddet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdddet.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            EL.ProductId = DDLPRODUCT.SelectedValue
            EL.BatchId = ddlBatch.SelectedValue
            EL.PartyName = ddlPName.SelectedValue
            If txtQtyIssued.Text = "" Then
                EL.QtyIssued = 0
            Else
                EL.QtyIssued = txtQtyIssued.Text
            End If
            EL.Remarks = txtRemarks.Text
            EL.IssueNo = txtIssueNo.Text
            If btnAdddet.Text = "UPDATE" Then
                EL.id = ViewState("Id")
                dt = BL.CheckStockIssuePostStatus(EL)
                PostStatus = dt.Rows(0).Item("PostToStk").ToString
                If PostStatus = "Y" Then
                    lblRed.Text = "Record is already Posted, so data cannot be Updated."
                    lblGreen.Text = ""
                Else
                    BL.UpdateStockIssueDetails(EL)
                    GVStockIssueDetails.Visible = True
                    btnAdddet.Text = "ADD"
                    BtnViewDetails.Text = "VIEW"
                    ClearDetails()
                    lblRed.Text = ""
                    GVStockIssueDetails.PageIndex = ViewState("PageIndex")
                    DisplayDetails()
                    lblGreen.Text = "Data Updated Successfully."
                End If
            ElseIf btnAdddet.Text = "ADD" Then

                If CInt(txtQtyIssued.Text) > CInt(txtQtyAvailable.Text) Then
                    lblRed.Text = "Issued Quantity cannot be greater the Available Quantity."
                    lblGreen.Text = ""
                    Exit Sub
                End If

                EL.id = 0
                BL.InsertStockIssueDetails(EL)
                btnAdddet.Text = "ADD"
                btnView.Text = "VIEW"
                DisplayDetails()
                ClearDetails()
                lblRed.Text = ""
                ViewState("PageIndex") = 0
                'GVStockIssueDetails.PageIndex = 0
                lblGreen.Text = "Data Saved Successfully."
                TabPanel2.Enabled = True
                TabPanel1.Enabled = False
                'End If
            End If
        Else
            lblRed.Text = "You do not belong to this branch, Cannot add data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub ddlBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.TextChanged

        ProductId = DDLPRODUCT.SelectedValue
        BatchId = ddlBatch.SelectedValue
        dt = Mfg_DLStockIssueR.ProductBatchAvailability(ProductId, BatchId)
        If dt.Rows.Count > 0 Then
            txtQtyAvailable.Text = dt.Rows(0).Item("Balance").ToString()
        Else
            txtQtyAvailable.Text = 0
        End If

    End Sub

   

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnViewDetails.Click
        If BtnViewDetails.Text <> "BACK" Then
            lblGreen.Text = ""
            lblRed.Text = ""
            ViewState("PageIndex") = 0
            'GVStockIssue.PageIndex = 0
            DisplayDetails()
            TabPanel2.Enabled = True
            TabPanel1.Enabled = False
        Else
            DisplayDetails()
            lblGreen.Text = ""
            lblRed.Text = ""
            'GVStockIssue.Enabled = True
            'GVStockIssue.PageIndex = ViewState("PageIndex")
            ClearDetails()
            BtnViewDetails.Text = "VIEW"
            btnAdddet.Text = "ADD"
            TabPanel2.Enabled = True
            TabPanel1.Enabled = False
        End If
    End Sub

    Sub ClearDetails()
        DDLPRODUCT.ClearSelection()
        ddlBatch.ClearSelection()

        txtQtyIssued.Text = ""
        txtRemarks.Text = ""
        txtQtyAvailable.Text = ""

    End Sub

    Sub DisplayDetails()
        EL.id = 0
        EL.IssueNo = txtIssueNo.Text
        dt = BL.GridviewStockIssueDetails(EL)
        If dt.Rows.Count <> 0 Then
            GVStockIssueDetails.DataSource = dt
            GVStockIssueDetails.DataBind()
            GVStockIssueDetails.Visible = True
            GVStockIssueDetails.Enabled = True
            TabPanel2.Enabled = True
            TabPanel1.Enabled = False
            btnDetails.Text = "ADD DETAILS"
        Else
            lblGreen.Text = ""
            lblRed.Text = "No Records to display."
            GVStockIssueDetails.Visible = False
            TabPanel2.Enabled = True
            TabPanel1.Enabled = False
        End If
    End Sub
    Protected Sub GVStockIssueDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVStockIssueDetails.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'Dim ID As Integer
            lblGreen.Text = ""
            lblRed.Text = ""
            DDLPRODUCT.SelectedValue = CType(GVStockIssueDetails.Rows(e.NewEditIndex).FindControl("lblProductId"), Label).Text
            ddlBatch.ClearSelection()
            ddlBatch.Items.Clear()
            ddlBatch.DataSourceID = "ObjBatch"
            ddlBatch.DataBind()
            ddlBatch.SelectedValue = CType(GVStockIssueDetails.Rows(e.NewEditIndex).FindControl("lblBatchId"), Label).Text
            txtQtyIssued.Text = CType(GVStockIssueDetails.Rows(e.NewEditIndex).FindControl("lblQtyIssued"), Label).Text
            txtRemarks.Text = CType(GVStockIssueDetails.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
            ViewState("Id") = CType(GVStockIssueDetails.Rows(e.NewEditIndex).FindControl("ID"), HiddenField).Value
            btnAdddet.Text = "UPDATE"
            EL.id = ViewState("Id")
            EL.PartyName = ddlPName.SelectedValue
            EL.PartyType = cmbPType.SelectedValue
            EL.IssueNo = txtIssueNo.Text
            dt = BL.GridviewStockIssueDetails(EL)
            GVStockIssueDetails.DataSource = dt
            GVStockIssueDetails.DataBind()
            GVStockIssueDetails.Enabled = False
            BtnViewDetails.Text = "BACK"
            BtnViewDetails.Visible = True
            TabPanel2.Visible = True
            TabPanel1.Enabled = False

            'To Bind the Qty available textbox at the time of edit
            ProductId = DDLPRODUCT.SelectedValue
            BatchId = ddlBatch.SelectedValue
            dt = Mfg_DLStockIssueR.ProductBatchAvailability(ProductId, BatchId)
            If dt.Rows.Count > 0 Then
                txtQtyAvailable.Text = dt.Rows(0).Item("Balance").ToString()
            Else
                txtQtyAvailable.Text = 0
            End If


        Else
            lblRed.Text = "You do not belong to this branch, Cannot edit data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub GVStockIssueDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVStockIssueDetails.RowDeleting
        Dim rowsaffected As Integer
        lblGreen.Text = ""
        lblRed.Text = ""
        EL.id = CType(GVStockIssueDetails.Rows(e.RowIndex).FindControl("ID"), HiddenField).Value
        dt = BL.CheckStockIssuePostStatus(EL)
        PostStatus = dt.Rows(0).Item("PostToStk").ToString
        If PostStatus = "Y" Then
            lblRed.Text = "Record is already Posted, so data cannot be Deleted."
            lblGreen.Text = ""
        Else
            rowsaffected = BL.DeteteStockIssueDetails(EL)
            lblGreen.Text = "Record Deleted Successfully."
            EL.id = 0
            EL.IssueNo = txtIssueNo.Text
            dt = BL.GridviewStockIssueDetails(EL)
            GVStockIssueDetails.DataSource = dt
            GVStockIssueDetails.DataBind()
        End If

    End Sub


    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        TabPanel2.Enabled = True
        TabPanel1.Enabled = False
        lblRed.Text = ""
        lblGreen.Text = ""
        DisplayDetails()
    End Sub
    Protected Sub DDLPRODUCT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLPRODUCT.TextChanged
        Dim ProductId As Integer
        ProductId = DDLPRODUCT.SelectedValue
        dt = Mfg_DLStockIssueR.ProductUnit(ProductId)
        lblUnit.Text = dt.Rows(0).Item("Unit").ToString()
        If lblUnit.Text <> "" Then
            lblUnit.Text = "(In " & lblUnit.Text & ")"
        End If
    End Sub

   
    Protected Sub BtnIssueNote_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnIssueNote.Click
        Dim Count As Integer = 0

        For Each Grid As GridViewRow In GVStockIssue.Rows
            If CType(Grid.FindControl("chkChild"), CheckBox).Checked = True Then
                Count = Count + 1
            End If
        Next

        If Count = 0 Then
            lblRedM.Text = "Please select a Record to Print Issue Note."
            lblGreenM.Text = ""
            Exit Sub
        ElseIf Count > 1 Then
            lblRedM.Text = "Please select only one Record to Print Issue Note."
            lblGreenM.Text = ""
            Exit Sub
        End If


        For Each Grid As GridViewRow In GVStockIssue.Rows
            If CType(Grid.FindControl("chkChild"), CheckBox).Checked = True Then
                EL.IssueNo = CType(Grid.FindControl("lblStockIssueNo"), Label).Text
                Dim qrystring As String = "Mfg_RptStockIssueNoteV.aspx?" & QueryStr.Querystring() & "&IssueNo=" & EL.IssueNo
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                lblGreenM.Text = ""
                lblRedM.Text = ""
            End If
        Next
    End Sub
End Class
