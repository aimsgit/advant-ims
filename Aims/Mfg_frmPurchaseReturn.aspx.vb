
Partial Class Mfg_frmPurchaseReturn
    Inherits BasePage
    Dim dt As DataTable
    Dim EL As New Mfg_ELPurchaseReturn
    Dim BLL As New Mfg_BLPurchaseReturn

    Protected Sub ddlSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSupplier.SelectedIndexChanged
        If HidReturnId.Text = "" Then
            dt = Mfg_DLPurchaseReturn.GetReturnNo()
            HidReturnId.Text = dt.Rows(0).Item("ReturnId").ToString
            txtReturnNo.Text = dt.Rows(0).Item("ReturnNo").ToString
        End If
    End Sub


    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                EL.Supplier = ddlSupplier.SelectedValue
                EL.ReturnNo = txtReturnNo.Text
                If HidReturnId.Text = "" Then
                    EL.ReturnId = 0
                Else
                    EL.ReturnId = HidReturnId.Text
                End If
                EL.Remarks = txtRemaks.Text
                If txtReturnDate.Text = "" Then
                    EL.ReturnDate = "01/01/1900"
                Else
                    EL.ReturnDate = txtReturnDate.Text
                End If

                If btnAdd.Text = "ADD" Then
                    If DDLProduct.SelectedValue <> 0 Then
                        If HidReturnId.Text <> "" Then
                            BLL.insert(EL)
                            lblGreenM.Text = "Data Saved Successfully."
                            lblRedM.Text = ""
                            DispGridM()
                            Clear()
                            HidReturnId.Text = ""
                            txtReturnNo.Text = ""
                        Else
                            lblRedM.Text = "Enter Correct Data."
                            lblGreenM.Text = ""
                        End If
                    Else
                        lblRedM.Text = "Please Enter Some Product First."
                        lblGreenM.Text = ""
                        TabPanel2.Enabled = "false"
                        Exit Sub
                    End If
                ElseIf btnAdd.Text = "UPDATE" Then


                    If ViewState("PostStatus") <> "Posted" Then
                        EL.id = ViewState("PurchaseReturnID")
                        BLL.update(EL)
                        lblGreenM.Text = "Data Updated Successfully."
                        lblRedM.Text = ""
                        btnAdd.Text = "ADD"
                        BtnView.Text = "VIEW"
                        DispGridM()
                        Clear()
                        HidReturnId.Text = ""
                        txtReturnNo.Text = ""
                        ViewState("PostStatus") = ""
                        btnAdddet.Enabled = True

                    Else

                        lblRedM.Text = "Cannot update the Posted Record."
                        lblGreenM.Text = ""
                    End If

                End If
            Catch ex As Exception
                lblRedM.Text = "Enter Correct Data"
                lblGreenM.Text = ""
            End Try
        Else
            lblRedM.Text = "You do not belong to this branch, Cannot add data."
            lblGreenM.Text = ""
        End If
    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        LinkButton1.Focus()
        If BtnView.Text = "VIEW" Then
            GridPurchaseReturnM.Enabled = True
            lblGreenM.Text = " "
            lblRedM.Text = " "
            ViewState("PageIndex") = 0
            GridPurchaseReturnM.PageIndex = 0
            DispGridM()
            Clear()
        ElseIf BtnView.Text = "BACK" Then
            GridPurchaseReturnM.Enabled = True
            lblGreenM.Text = " "
            lblRedM.Text = " "
            ViewState("PageIndex") = 0
            GridPurchaseReturnM.PageIndex = 0
            HidReturnId.Text = ""
            txtReturnNo.Text = ""
            DispGridM()
            btnAdd.Text = "ADD"
            BtnView.Text = "VIEW"
            ViewState("PostStatus") = ""
            btnAdddet.Enabled = True

            Clear()
            GridPurchaseReturnM.PageIndex = ViewState("PageIndex")

        End If
    End Sub
    Public Sub Clear()
        txtReturnDate.Text = Format(Today, "dd-MMM-yyyy")
        txtRemaks.Text = ""
        txtReturnNo.Text = ""
        HidReturnId.Text = ""
        'RbProduct.Items.Clear()
        DDLProduct.Items.Clear()
        ddlBatch.Items.Clear()
    End Sub
    Public Sub clearS()

        txtReturnedQty.Text = ""
        txtRemarks.Text = ""

        txtExRate.Text = ""
        txtInvoiceNO.Text = ""
        txtInvoiceDate.Text = ""
        txtMfg.Text = ""
        txtMKT.Text = ""
        txtExpiryDate.Text = ""
        txtFlatRate.Text = ""
        txtQtyIn.Text = ""
        txtUsedQty.Text = ""
        txtNetUsableQty.Text = ""
    End Sub

    Public Sub DispGridM()
        EL.id = 0

        dt = BLL.getPurchaseReturnM(EL)
        If dt.Rows.Count > 0 Then
            GridPurchaseReturnM.Enabled = True
            GridPurchaseReturnM.Visible = True
            GridPurchaseReturnM.DataSource = dt
            GridPurchaseReturnM.DataBind()

        Else
            lblGreenM.Text = ""
            lblRedM.Text = "No records to display."
            GridPurchaseReturnM.Visible = False
        End If
    End Sub

    Protected Sub GridPurchaseReturnM_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridPurchaseReturnM.PageIndexChanging
        GridPurchaseReturnM.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridPurchaseReturnM.PageIndex
        DispGridM()
        GridPurchaseReturnM.Visible = True
        lblRedM.Text = " "
        lblGreenM.Text = " "

    End Sub
    Protected Sub GridPurchaseReturnM_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridPurchaseReturnM.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("PostStatus") = CType(GridPurchaseReturnM.Rows(e.RowIndex).FindControl("lblGVPost"), Label).Text
            If ViewState("PostStatus") <> "Posted" Then
                EL.id = CType(GridPurchaseReturnM.Rows(e.RowIndex).FindControl("ID"), HiddenField).Value
                BLL.DeletePurchasReturn(EL)
                GridPurchaseReturnM.DataBind()
                'lblGreen.Visible = True
                lblRedM.Text = " "
                lblGreenM.Text = "Data Deleted Successfully."
                Clear()
                GridPurchaseReturnM.PageIndex = ViewState("PageIndex")
                'EL.PID = ViewState(" HiddenField1")
                DispGridM()
            Else
                lblRedM.Text = "Cannot deleted the Posted Record."
                lblGreenM.Text = ""
                ViewState("PostStatus") = ""
            End If

        Else
            lblRedM.Text = "You do not belong to this branch, Cannot delete data."
            lblGreenM.Text = ""
        End If
    End Sub

    Protected Sub GridPurchaseInvoiceM_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridPurchaseReturnM.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                lblRedM.Text = ""
                lblGreenM.Text = ""
                ViewState("PostStatus") = CType(GridPurchaseReturnM.Rows(e.NewEditIndex).FindControl("lblGVPost"), Label).Text
                ViewState("PurchaseReturnID") = CType(GridPurchaseReturnM.Rows(e.NewEditIndex).FindControl("ID"), HiddenField).Value
                ddlSupplier.SelectedValue = CType(GridPurchaseReturnM.Rows(e.NewEditIndex).FindControl("lblSupppId"), Label).Text
                HidReturnId.Text = CType(GridPurchaseReturnM.Rows(e.NewEditIndex).FindControl("lblPurchReturnId"), Label).Text
                txtReturnNo.Text = CType(GridPurchaseReturnM.Rows(e.NewEditIndex).FindControl("lblPurchReturnNo"), Label).Text
                txtReturnDate.Text = CType(GridPurchaseReturnM.Rows(e.NewEditIndex).FindControl("lblReturnInvoiceDateGV"), Label).Text
                txtRemaks.Text = CType(GridPurchaseReturnM.Rows(e.NewEditIndex).FindControl("lblRemarksGV"), Label).Text
                EL.id = ViewState("PurchaseReturnID")
                dt = BLL.getPurchaseReturnM(EL)
                GridPurchaseReturnM.DataSource = dt
                GridPurchaseReturnM.DataBind()
                GridPurchaseReturnM.Enabled = False
                GridPurchaseReturnM.Visible = True
                btnAdd.Text = "UPDATE"
                BtnView.Text = "BACK"
                If ViewState("PostStatus") = "Posted" Then
                    btnAdddet.Enabled = False
                End If
            Catch ex As Exception
                lblRedM.Text = "Enter Correct Data"
                lblGreenM.Text = ""
            End Try
        Else
            lblRedM.Text = "You do not belong to this branch, Cannot add data."
            lblGreenM.Text = ""
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        Dim Supplier As Integer, id As Integer
        Supplier = ddlSupplier.SelectedValue
        clearS()
        'ddlCurrency.Items.Clear()
        'ddlCurrency.SelectedValue = 0
        txtExRate.Text = 1
        If ddlSupplier.SelectedValue <> 0 Then
            TabContainer1.ActiveTab = TabPanel2
            TabPanel2.Enabled = True
            TabPanel1.Enabled = False
            RbProduct.Focus()
            lblGreenM.Text = ""
            lblRedM.Text = ""
            If RbProduct.SelectedValue = "" Then
                id = 0
            Else
                id = RbProduct.SelectedValue
                dt = BLL.SelectProductName(Supplier, id)
                DDLProduct.Items.Clear()
                If dt.Rows.Count > 0 Then
                    DDLProduct.DataSource = dt
                    DDLProduct.DataBind()
                End If
            End If
            'If HidReturnId.Text = "" Then
            '    dt = Mfg_DLPurchaseReturn.GetReturnNo()
            '    HidReturnId.Text = dt.Rows(0).Item("ReturnId").ToString
            '    txtReturnNo.Text = dt.Rows(0).Item("ReturnNo").ToString
            'End If

        Else
            lblRedM.Text = "Please Select Supplier First."
            lblGreenM.Text = ""
            TabPanel2.Enabled = False
        End If
    End Sub

    Protected Sub RbProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbProduct.SelectedIndexChanged
        Dim Supplier As Integer, id As Integer
        Supplier = ddlSupplier.SelectedValue
        id = RbProduct.SelectedValue
        dt = BLL.SelectProductName(Supplier, id)
        DDLProduct.Items.Clear()
        If dt.Rows.Count > 0 Then
            DDLProduct.DataSource = dt
            DDLProduct.DataBind()
        End If
    End Sub
    Sub Splitter(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            EL.Batch = parts(0).ToString()
            EL.InvoiceID = parts(1).ToString()
            HidTxtInvoiceId.Text = parts(1).ToString()
        End If
    End Sub
    Sub Splitter1(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            EL.BatchName = parts(0).ToString()
            EL.InvoiceNo = parts(1).ToString()
            txtInvoiceNO.Text = parts(1).ToString()
        End If
    End Sub
    Protected Sub ddlBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.TextChanged
        Splitter(ddlBatch.SelectedValue)
        Splitter1(ddlBatch.SelectedItem.ToString)
        EL.Product = DDLProduct.SelectedValue
        dt = BLL.BatchAutofill(EL)
        If dt.Rows.Count > 0 Then

            EL.StockId = dt.Rows(0).Item("Stock_ID").ToString
            txtInvoiceNO.Text = EL.InvoiceNo
            txtInvoiceDate.Text = Format(dt.Rows(0).Item("Ref_Date"), "dd-MMM-yyyy")
            txtMfg.Text = dt.Rows(0).Item("MFG").ToString
            txtMKT.Text = dt.Rows(0).Item("MKT").ToString
            'If dt.Rows(0).Item("Expiry").ToString = "" Then
            '    txtExpiryDate.Text = ""
            'Else
            '    txtExpiryDate.Text = Format(dt.Rows(0).Item("Expiry"), "dd-MMM-yyyy")
            'End If
            If dt.Rows(0).Item("Expiry").ToString() = "" Then
                txtExpiryDate.Text = ""
            Else
                If dt.Rows(0).Item("Expiry").ToString = "01/01/1900" Then
                    txtExpiryDate.Text = ""
                Else
                    txtExpiryDate.Text = Format(CDate(dt.Rows(0).Item("Expiry")), "dd-MMM-yyyy")
                End If

            End If

            txtFlatRate.Text = Format(dt.Rows(0).Item("Flat_Rate").ToString, "0.00")
            txtQtyIn.Text = dt.Rows(0).Item("Qty_In").ToString
            txtUsedQty.Text = 0
            txtNetUsableQty.Text = dt.Rows(0).Item("Qty_In").ToString
            txtExRate.Text = dt.Rows(0).Item("Buy_Conversion_Rate").ToString
            If txtExRate.Text = "" Then
                txtExRate.Text = 1
            End If
            txtstockid.Text = dt.Rows(0).Item("Stock_ID").ToString
            txtPrd_id.Text = dt.Rows(0).Item("PRD_ID").ToString
        Else
            ddlBatch.SelectedValue = 0
        End If

    End Sub
    Public Sub batchfieldchanges(ByVal EL As Mfg_ELPurchaseReturn)
        dt = BLL.BatchAutofill(EL)
        EL.StockId = dt.Rows(0).Item("Stock_ID").ToString
        txtInvoiceNO.Text = EL.InvoiceNo
        txtInvoiceDate.Text = Format(dt.Rows(0).Item("Ref_Date"), "dd-MMM-yyyy")
        txtMfg.Text = dt.Rows(0).Item("MFG").ToString
        txtMKT.Text = dt.Rows(0).Item("MKT").ToString
        If dt.Rows(0).Item("Expiry").ToString = "" Then
            txtExpiryDate.Text = ""
        Else
            txtExpiryDate.Text = Format(dt.Rows(0).Item("Expiry"), "dd-MMM-yyyy")
        End If
        txtFlatRate.Text = dt.Rows(0).Item("Flat_Rate").ToString
        txtQtyIn.Text = dt.Rows(0).Item("Qty_In").ToString
        txtUsedQty.Text = 0
        txtNetUsableQty.Text = dt.Rows(0).Item("Qty_In").ToString
        txtExRate.Text = dt.Rows(0).Item("Buy_Conversion_Rate").ToString
        txtstockid.Text = dt.Rows(0).Item("Stock_ID").ToString
        txtPrd_id.Text = dt.Rows(0).Item("PRD_ID").ToString

    End Sub

    Protected Sub btnAdddet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdddet.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If ViewState("PostStatus") <> "Posted" Then
                    EL.ProductType = RbProduct.SelectedValue
                    EL.Product = DDLProduct.SelectedValue
                    EL.Supplier = ddlSupplier.SelectedValue
                    If HidReturnId.Text = "" Then
                        EL.HidPurchaseReturnId = 0
                    Else
                        EL.HidPurchaseReturnId = HidReturnId.Text
                    End If

                    Splitter(ddlBatch.SelectedValue)
                    ' EL.Batch = ddlBatch.SelectedValue
                    If txtReturnedQty.Text = "" Then
                        EL.ReturnedQty = "0.00"
                    Else
                        EL.ReturnedQty = txtReturnedQty.Text
                    End If
                    EL.RemarksS = txtRemarks.Text
                    EL.Currency = ddlCurrency.SelectedValue
                    If txtExRate.Text = "" Then
                        EL.ExchRate = 1
                    Else
                        EL.ExchRate = txtExRate.Text
                    End If

                    EL.InvoiceNo = txtInvoiceNO.Text
                    EL.InvoiceID = HidTxtInvoiceId.Text
                    If txtReturnDate.Text = "" Then
                        EL.ReturnDate = "1/1/1900"
                    Else
                        EL.ReturnDate = txtReturnDate.Text
                    End If
                    If txtPrd_id.Text = "" Then
                        EL.PRD_ID = 0
                    Else
                        EL.PRD_ID = txtPrd_id.Text
                    End If
                    If txtstockid.Text = "" Then
                        EL.StockId = 0
                    Else
                        EL.StockId = txtstockid.Text
                    End If
                    If txtFlatRate.Text = "" Then
                        EL.FlatRate = 0
                    Else
                        EL.FlatRate = txtFlatRate.Text
                    End If

                    If btnAdddet.Text = "ADD" Then
                        BLL.Insertrecord(EL)
                        lblGreen.Text = "Data Saved Successfully."
                        lblRed.Text = ""
                        clearS()
                        displayDetails()
                    ElseIf btnAdddet.Text = "UPDATE" Then
                        EL.PID = ViewState("PRID")
                        BLL.UpdateRecord(EL)
                        lblGreen.Text = "Data Updated Successfully."
                        lblRed.Text = ""
                        displayDetails()
                        clearS()
                        btnAdddet.Text = "ADD"
                        BtnViewDetails.Text = "VIEW"
                    End If
                Else

                    lblRed.Text = "Cannot update the Posted Record."
                    lblGreen.Text = ""
                End If

            Catch ex As Exception
                lblRed.Text = "Enter Correct Data"
                lblGreen.Text = ""
            End Try
        Else
            lblRed.Text = "You do not belong to this branch, Cannot add data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub GVPRDetails_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVPRDetails.PageIndexChanging
        GVPRDetails.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVPRDetails.PageIndex
        displayDetails()
        GVPRDetails.Visible = True
        lblRed.Text = " "
        lblGreen.Text = " "
    End Sub
    Protected Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
        Dim MC1 As New MultiCurrencyManager
        Dim MCD As MultiCurrency = MC1.GetMulticurrencyRate(CInt(IIf(ddlCurrency.SelectedValue.ToString = "", 0, ddlCurrency.SelectedValue.ToString)))
        txtExRate.Text = MCD.BuyConversionRate
    End Sub

    Protected Sub GVPRDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVPRDetails.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If ViewState("PostStatus") <> "Posted" Then

                EL.PID = CType(GVPRDetails.Rows(e.RowIndex).FindControl("GVPRID"), HiddenField).Value
                BLL.DeletePurchaseReturnS(EL)
                GVPRDetails.DataBind()
                'lblGreen.Visible = True
                lblRed.Text = " "
                lblGreen.Text = "Data Deleted Successfully."
                clearS()
                GVPRDetails.PageIndex = ViewState("PageIndex")
                'EL.PID = ViewState(" HiddenField1")
                'EL.id = 0
                displayDetails()
                'dt = BLL.GetPurchaseInvoiceIDDetails(EL)

                'GVPODetails.Enabled = True
                'GVPODetails.Visible = True
                'GVPODetails.DataSource = dt
                'GVPODetails.DataBind()
            Else

                lblRed.Text = "Cannot delete the Posted Record."
                lblGreen.Text = ""
            End If

        Else
            lblRedM.Text = "You do not belong to this branch, Cannot delete data."
            lblGreenM.Text = ""
        End If
    End Sub

    Protected Sub GVPRDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVPRDetails.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblRed.Text = ""
            lblGreen.Text = ""
            Dim supplier As Integer

            ViewState("PRID") = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("GVPRID"), HiddenField).Value
            ddlCurrency.SelectedValue = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("GVCurrencycode"), Label).Text
            RbProduct.SelectedValue = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("Producttype"), HiddenField).Value
            txtExRate.Text = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("GVlblExchangeRate"), Label).Text
            'If CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVExpiry"), Label).Text = "01-Jan-3000" Then
            '    txtExpiryS.Text = ""
            'Else
            '    txtExpiryS.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVExpiry"), Label).Text
            'End If

            supplier = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("GVSupplier"), HiddenField).Value
            DDLProduct.ClearSelection()
            DDLProduct.Items.Clear()
            ID = RbProduct.SelectedValue
            dt = BLL.SelectProductName(Supplier, ID)
            DDLProduct.Items.Clear()
            If dt.Rows.Count > 0 Then
                DDLProduct.DataSource = dt
                DDLProduct.DataBind()
            End If
            DDLProduct.SelectedValue = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("lblProductID"), HiddenField).Value
            'If dt.Rows.Count > 0 Then
            '    DDLProduct.DataSource = dt
            '    DDLProduct.DataBind()
            'End If
            ddlBatch.Items.Clear()
            ddlBatch.DataSourceID = "ObjBatch"
            ddlBatch.DataBind()
            ddlBatch.SelectedValue = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("GVlblBatchID"), Label).Text

            txtReturnedQty.Text = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("lblQtyRecvdID"), Label).Text
            txtRemarks.Text = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("GVRemarks"), Label).Text
            Splitter(ddlBatch.SelectedValue)
            Splitter1(ddlBatch.SelectedItem.ToString)
            batchfieldchanges(EL)
            EL.PID = ViewState("PRID")
            dt = BLL.GetPurchaserReturnS(EL)
            GVPRDetails.DataSource = dt
            GVPRDetails.DataBind()
            For Each rows As GridViewRow In GVPRDetails.Rows
                If CType(rows.FindControl("lblGVExpiry"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblGVExpiry"), Label).Text = ""
                End If
            Next
            GVPRDetails.Enabled = False
            GVPRDetails.Visible = True
            btnAdddet.Text = "UPDATE"
            BtnViewDetails.Text = "BACK"
        Else
            'lblmsg.Text = "You do not belong to this branch, Cannot edit data."
            'msginfo.Text = ""
        End If
    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnViewDetails.Click
        If BtnViewDetails.Text = "VIEW" Then
            EL.id = 0

            lblGreen.Text = ""
            lblRed.Text = ""
            ViewState("PageIndex") = 0
            displayDetails()
        Else
            EL.id = 0
            displayDetails()
            lblGreen.Text = ""
            lblRed.Text = ""
            GVPRDetails.PageIndex = ViewState("PageIndex")
            btnAdddet.Text = "ADD"
            BtnViewDetails.Text = "VIEW"
            clearS()
        End If
    End Sub
    Public Sub displayDetails()
        If HidReturnId.Text = "" Then
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
            GVPRDetails.Visible = False
        Else
            EL.HidPurchaseReturnId = HidReturnId.Text

            dt = BLL.GetPurchaseReturnIDDetails(EL)
            If dt.Rows.Count > 0 Then
                GVPRDetails.Enabled = True
                GVPRDetails.Visible = True
                GVPRDetails.DataSource = dt
                GVPRDetails.DataBind()
                For Each rows As GridViewRow In GVPRDetails.Rows
                    If CType(rows.FindControl("lblGVExpiry"), Label).Text = "01-Jan-1900" Then
                        CType(rows.FindControl("lblGVExpiry"), Label).Text = ""
                    End If
                Next

            Else
                lblGreen.Text = ""
                lblRed.Text = "No records to display."
                GVPRDetails.Visible = False
            End If
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            '    TabPanel2.Enabled = False
            lblGreenM.Text = ""
            lblRedM.Text = ""
            txtReturnDate.Text = Format(Today, "dd-MMM-yyyy")
            txtExRate.Text = "1.00"
        End If
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        TabContainer1.ActiveTab = TabPanel1
        TabPanel1.Enabled = True
        GVPRDetails.Visible = "false"
        lblRed.Text = ""
        lblGreen.Text = ""
        TabPanel2.Enabled = False
    End Sub

    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Try
            Dim id As String = ""
            Dim check As String = ""

            Dim count As Integer
            count = 0
            For Each grid As GridViewRow In GridPurchaseReturnM.Rows
                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("ID"), HiddenField).Value
                    id = check + "," + id
                    count = count + 1
                End If
            Next
            If id = "" Then
                id = "0"
                count = 0
            Else
                id = Left(id, id.Length - 1)
            End If

            If count = 0 Then
                lblRedM.Text = "Select Atleast One Stock to Post."
                lblGreenM.Text = ""
            Else
                EL.ChkID = id
                BLL.PostPurchaseReturn(EL)
                lblGreenM.Text = "Data posted successfully."
                lblRedM.Text = ""
                DispGridM()
                'dt = DL.GetChkID(EL)
                'EL.PurchaseInvoiceID = dt.Rows(0).Item("Purchase_Invoice_ID")

                'dt = DL.GetPurchaseInvoiceIDDetails(EL)
                'EL.HIDPurchaseInvoice = dt.Rows(0).Item("Purchase_Invoice_ID")
                'BLL.InsertToPost(EL)
            End If

        Catch ex As Exception
            lblRedM.Text = ""
            lblGreenM.Text = "Data posted successfully."
        End Try
    End Sub
    Sub CheckAll()
        If CType(GridPurchaseReturnM.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GridPurchaseReturnM.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GridPurchaseReturnM.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub btnprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprint.Click
        Try
            Dim check As String = ""
            Dim id As String = ""

            Dim Count1 As Integer = 0
            For Each Grid As GridViewRow In GridPurchaseReturnM.Rows

                If CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(Grid.FindControl("lblPurchReturnId"), Label).Text
                    id = check + "," + id
                    Count1 = Count1 + 1
                End If
            Next

            If id = "" Then
                id = 0
            Else
                id = Left(id, id.Length - 1)
            End If


            If Count1 > 0 Then

                Dim qrystring As String = "Mfg_Rpt_PurchaseReturnreport.aspx?" & "&Id=" & id
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                lblGreen.Text = ""

            Else
                lblRed.Text = "Please select the records to print."
                lblGreen.Text = ""
            End If

        Catch ex As Exception
            lblRed.Text = "Please select the records from gridview. "
        End Try
    End Sub
End Class
