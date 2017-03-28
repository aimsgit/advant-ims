
Partial Class Mfg_FrmStockAudit
    Inherits BasePage
    Dim dt As New DataTable
    Dim EL As New Mfg_ELStockAudit
    Dim Bl As New Mfg_BLStockAudit
    Dim Dl As New Mfg_DLStockAudit

    Protected Sub btnAddDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetails.Click
        lblGreen.Text = ""
        lblRed.Text = ""
        btnAddSaleInvoiceDetails.Text = "ADD"
        btnViewSaleInvoiceDetails.Text = "VIEW"
       
        TabContainer1.ActiveTab = TabPanel3
        TabPanel3.Enabled = True
        TabPanel3.Visible = True
        TabPanel1.Enabled = False
        lblMsg.Text = ""
        lblErrorMsg.Text = ""

        'btnAdddet.Enabled = True
        GVProdDetails.Visible = False
        If HidInvoice.Text = "" Then
            dt = Bl.GetInvoiceNo()
            'HidInvoice.Text = dt.Rows(0).Item("AuditId").ToString
            HidInvoiceNO.Text = dt.Rows(0).Item("AuditNo").ToString
        Else
            EL.AuditID = HidInvoice.Text
        End If
        EL.Supp_ID = ddlSupplier.SelectedValue
        EL.AuditNo = txtStockAuditNo.Text
        EL.Stock_Date = txtDate.Text
        Dim dt1 As DataTable
        dt1 = Dl.ProductComboD(EL.Supp_ID)
        DDLRM.Items.Clear()
        If dt1.Rows.Count > 0 Then
            DDLRM.DataSource = dt1
            DDLRM.DataBind()
        End If
        'dt1 = Mfg_DLStockAudit.InsertSuppliersDetails(EL)
        'If dt1.Rows.Count > 0 Then
        '    lblMsg.Text = "Data Saved Successfully."
        '    lblErrorMsg.Text = ""
        'Else
        '    lblErrorMsg.Text = "No Record To Display. "
        '    lblMsg.Text = ""
        'End If

        'Dim Supplier As Integer, id As Integer
        'Supplier = ddlSupplier.SelectedValue
        'clearS()
        ''ddlCurrency.Items.Clear()
        ''ddlCurrency.SelectedValue = 0
        'txtExRate.Text = 1
        'If ddlSupplier.SelectedValue <> 0 Then
        '    TabContainer1.ActiveTab = TabPanel2
        '    TabPanel2.Enabled = True
        '    TabPanel1.Enabled = False
        '    RbProduct.Focus()
        '    lblGreenM.Text = ""
        '    lblRedM.Text = ""
        '    If RbProduct.SelectedValue = "" Then
        '        id = 0
        '    Else
        '        id = RbProduct.SelectedValue
        '        dt = BLL.SelectProductName(Supplier, id)
        '        DDLProduct.Items.Clear()
        '        If dt.Rows.Count > 0 Then
        '            DDLProduct.DataSource = dt
        '            DDLProduct.DataBind()
        '        End If
        '    End If
        '    'If HidReturnId.Text = "" Then
        '    '    dt = Mfg_DLPurchaseReturn.GetReturnNo()
        '    '    HidReturnId.Text = dt.Rows(0).Item("ReturnId").ToString
        '    '    txtReturnNo.Text = dt.Rows(0).Item("ReturnNo").ToString
        '    'End If

        'Else
        '    lblRedM.Text = "Please Select Supplier First."
        '    lblGreenM.Text = ""
        '    TabPanel2.Enabled = False
        'End If

    End Sub

    Protected Sub ddlSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSupplier.SelectedIndexChanged
        dt = Bl.AutoGenerateNo(EL)

        If dt.Rows.Count > 0 Then
            txtStockAuditNo.Text = dt.Rows(0).Item("AuditNo").ToString
            If txtStockAuditNo.Text = "" Then
                txtStockAuditNo.Text = 1
            End If
            'HidInvoice.Text = dt.Rows(0).Item("AuditId").ToString
            'If HidInvoice.Text = "" Then
            '    HidInvoice.Text = 1
            'End If
        Else
            lblErrorMsg.Text = "No records to display."
            lblMsg.Text = ""
        End If
        TabPanel1.Enabled = True
        TabPanel3.Enabled = False
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        panel1.Visible = True
        TabPanel1.Visible = True
        'If ddlSupplier.SelectedValue = "0" Then

        '    txtStockAuditNo.Text = ""
        '    'Clear()
        'Else
        '    EL.Supp_ID = ddlSupplier.SelectedValue


        '    dt = Bl.AutoGenerateNo(EL)

        '    If dt.Rows.Count > 0 Then
        '        txtStockAuditNo.Text = dt.Rows(0).Item("AuditNo").ToString
        '        If txtStockAuditNo.Text = "" Then
        '            txtStockAuditNo.Text = 1
        '        End If
        '        HidInvoice.Text = dt.Rows(0).Item("AuditId").ToString
        '        If HidInvoice.Text = "" Then
        '            HidInvoice.Text = 1
        '        End If
        '    Else
        '        lblErrorMsg.Text = "No records to display."
        '        lblMsg.Text = ""
        '    End If
        'End If
    End Sub

    Protected Sub btnAddSaleInvoiceDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddSaleInvoiceDetails.Click

        TabPanel1.Enabled = False
        TabPanel3.Enabled = True

        If (Session("BranchCode") = Session("ParentBranch")) Then
            'Dim batch As String()
            Try
                EL.AuditNo = txtStockAuditNo.Text
                EL.Supp_ID = ddlSupplier.SelectedValue
                EL.Stock_Date = txtDate.Text
                EL.ProductID = DDLRM.SelectedValue

                Dim parts As String() = DDLBatch.SelectedValue.Split(New Char() {":"})
                EL.Batch = parts(0).ToString


                'EL.QtyIn = txtQtyStock.Text
                EL.Countsign = txtcount.Text
                If EL.Countsign = "+" Then
                    EL.QtyIn = CDbl(txtCountDiff.Text)
                Else
                    EL.QtyIn = 0
                End If
                If EL.Countsign = "-" Then
                    EL.QtyOut = CDbl(txtCountDiff.Text)
                Else
                    EL.QtyOut = 0
                End If

                EL.CountDiff = txtCountDiff.Text

                EL.QtyinStk = txtQtyStock.Text
                EL.Remarks = ddlRemarks.SelectedValue
                If ddlRemarks.SelectedValue = "Select" Then
                    EL.Remarks = ""
                Else
                    EL.Remarks = ddlRemarks.SelectedValue
                End If
                Dim dt1 As DataTable
                dt1 = Dl.GetProdDetails(EL)
                EL.Purchaseinvoiceid = dt1.Rows(0).Item("Purchase_Invoice_ID")
                EL.PRDID = dt1.Rows(0).Item("PRD_ID")
                EL.Packingdetails = dt1.Rows(0).Item("Packing_Details")
                EL.RefDate = dt1.Rows(0).Item("Ref_Date")
                EL.PurchaseRate = dt1.Rows(0).Item("Purchase_Rate")
                EL.TradeDisc = dt1.Rows(0).Item("Trade_discount")
                EL.FlatDisc = dt1.Rows(0).Item("Flat_Discount")
                EL.PurchseTaxstrid = dt1.Rows(0).Item("PurchaseTax_Str_ID")
                EL.PurchseTaxBeforafterDisc = dt1.Rows(0).Item("PurchaseTax_BeforeAfter_Discount")
                EL.PurchseTaxPlan = dt1.Rows(0).Item("PurchaseTax_Plan")
                EL.PurchseVAT = dt1.Rows(0).Item("Purchase_VAT")
                EL.PurchseCAT = dt1.Rows(0).Item("Purchase_CST")
                EL.FlatRate = dt1.Rows(0).Item("Flat_Rate")
                EL.SaleRate = dt1.Rows(0).Item("Sale_Rate")
                EL.MRP = dt1.Rows(0).Item("MRP")
                If dt1.Rows(0).Item("ExpiryDate").ToString = "" Then
                    EL.ExpiryDate = "01-01-1900"
                Else
                    EL.ExpiryDate = dt1.Rows(0).Item("ExpiryDate")
                End If

                EL.MRP = dt1.Rows(0).Item("MRP")
                If dt1.Rows(0).Item("Currency_Rate").ToString = "" Then
                    EL.CurrencyRate = "0.00"
                Else
                    EL.CurrencyRate = dt1.Rows(0).Item("Currency_Rate")

                End If

                EL.PurchaseVAT_Amount = dt1.Rows(0).Item("PurchaseVAT_Amount")
                EL.PurchaseCST_Amount = dt1.Rows(0).Item("PurchaseCST_Amount")
                EL.Id = 0
                If btnAddSaleInvoiceDetails.Text = "UPDATE" Then
                    EL.Id = ViewState("Stk_Id")
                    Mfg_DLStockAudit.Update(EL)
                    lblGreen.Text = ""
                    btnAddSaleInvoiceDetails.Text = "ADD"
                    btnViewSaleInvoiceDetails.Text = "VIEW"
                    lblGreen.Text = "Data Updated Successfully."
                    lblRed.Text = ""
                    BtnClose.Enabled = True
                    clear()
                    GVProdDetails.PageIndex = ViewState("PageIndex")
                    displayDetails(EL)

                ElseIf btnAddSaleInvoiceDetails.Text = "ADD" Then
                    'HidMInvoice.Text = HidInvoice.Text
                    'If HidMInvoice.Text = "" Then
                    '    EL.AuditID = 0
                    'Else
                    '    EL.AuditID = HidMInvoice.Text
                    'End If
                    'EL.Id = 0
                    EL.Batch = DDLBatch.SelectedValue
                    EL.ProductID = DDLRM.SelectedValue
                    'Dim parts As String() = DDLBatch.SelectedValue.Split(New Char() {":"})
                    EL.Batch = DDLBatch.SelectedValue
                    'EL.QtyIn = parts(1).ToString
                    txtQtyStock.Enabled = False
                    dt = Bl.Qty(EL)

                    txtQtyStock.Text = dt.Rows(0).Item("QtyInStock").ToString

                    If EL.QtyinStk < EL.QtyIn Or EL.QtyinStk < EL.QtyOut Then
                        lblRed.Text = "Quantity in stock is less."
                        lblGreen.Text = ""
                        Exit Sub
                    End If
                    Bl.InsertSaleInvoiceDetails(EL)
                    lblGreen.Text = ""
                    btnAddSaleInvoiceDetails.Text = "ADD"
                    lblGreen.Text = "Data Saved successfully."
                    lblRed.Text = ""
                    clear()
                    DDLBatch.SelectedValue = 0
                    ViewState("PageIndex") = 0
                    GVProdDetails.PageIndex = 0
                    displayDetails(EL)

                End If
            Catch ex As Exception
                lblRed.Text = "There is no product in the stock."
                lblGreen.Text = ""
            End Try
        Else
            lblRed.Text = "You do not belong to this branch, Cannot add data."
            lblGreen.Text = ""
        End If
    End Sub

    Sub clear()
        txtQtyStock.Text = ""
        txtCountDiff.Text = ""
    End Sub
    Sub displayDetails(ByVal El As Mfg_ELStockAudit)
        Dim dt2 As DataTable
        El.AuditNo = txtStockAuditNo.Text
        El.Supp_ID = ddlSupplier.SelectedValue
        dt2 = Dl.GetProdAddDetails(El)

        If dt2.Rows.Count > 0 Then
            GVProdDetails.Enabled = True
            GVProdDetails.Visible = True
            GVProdDetails.DataSource = dt2
            GVProdDetails.DataBind()

        Else
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
            GVProdDetails.Visible = False
        End If
        For Each grid In GVProdDetails.Rows
            If CType(grid.FindControl("lblExpiry"), Label).Text = "01-Jan-1900" Or CType(grid.FindControl("lblExpiry"), Label).Text = "01-Jan-3000" Then
                CType(grid.FindControl("lblExpiry"), Label).Text = ""
            End If

        Next
    End Sub

    Protected Sub DDLBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLBatch.SelectedIndexChanged
        EL.Batch = DDLBatch.SelectedValue
        EL.ProductID = DDLRM.SelectedValue
        'Dim parts As String() = DDLBatch.SelectedValue.Split(New Char() {":"})
        EL.Batch = DDLBatch.SelectedValue
        'EL.QtyIn = parts(1).ToString
        txtQtyStock.Enabled = False
        dt = Bl.Qty(EL)

        txtQtyStock.Text = dt.Rows(0).Item("QtyInStock").ToString
        'If txtQtyStock.Text = "" Then
        '    txtQtyStock.Text = 0
        '    EL.QtyIn = 0
        'Else
        '    EL.QtyIn = txtQtyStock.Text
        'End If

    End Sub

    'Protected Sub btnADDSaleInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnADDSaleInvoice.Click
    '    lblGreen.Text = ""
    '    lblRed.Text = ""
    '    If ddlSupplier.SelectedValue = 0 Then
    '        lblErrorMsg.Text = "Please select Supplier first."
    '        lblMsg.Text = ""
    '        Exit Sub
    '    Else
    '        TabContainer1.ActiveTab = TabPanel3
    '        TabPanel3.Enabled = True
    '        TabPanel3.Visible = True
    '        TabPanel1.Enabled = False
    '        lblMsg.Text = ""
    '        lblErrorMsg.Text = ""

    '        'btnAdddet.Enabled = True
    '        GVSaleInvoiceDetails.Visible = False
    '        'If HidInvoice.Text = "" Then
    '        '    dt = Bl.GetInvoiceNo()
    '        '    HidInvoice.Text = dt.Rows(0).Item("AuditId").ToString
    '        '    HidInvoiceNO.Text = dt.Rows(0).Item("AuditNo").ToString
    '        'Else
    '        '    EL.AuditID = HidInvoice.Text
    '        'End If
    '        EL.Supp_ID = ddlSupplier.SelectedValue
    '        EL.AuditNo = txtStockAuditNo.Text
    '        EL.Stock_Date = txtDate.Text
    '        Dim dt1 As DataTable
    '        dt1 = Mfg_DLStockAudit.InsertSuppliersDetails(EL)
    '        If dt1.Rows.Count > 0 Then
    '            lblMsg.Text = "Data Saved Successfully."
    '            lblErrorMsg.Text = ""
    '        Else
    '            lblErrorMsg.Text = "No Record To Display. "
    '            lblMsg.Text = ""
    '        End If

    '    End If
    'End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtStockAuditNo.Enabled = False
        If Not IsPostBack Then
            txtDate.Text = Format(Today(), "dd-MMM-yyyy")
            TabPanel3.Enabled = False
            dt = Bl.AutoGenerateNo(EL)

            If dt.Rows.Count > 0 Then
                txtStockAuditNo.Text = dt.Rows(0).Item("AuditNo").ToString
                If txtStockAuditNo.Text = "" Then
                    txtStockAuditNo.Text = 1
                End If
            End If
        End If
    End Sub
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        TabContainer1.ActiveTab = TabPanel1
        TabPanel1.Enabled = True
        GVProdDetails.Visible = "false"
        lblRed.Text = ""
        lblGreen.Text = ""
        TabPanel3.Enabled = False
        'GvSaleInvoice.Visible = False
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        ddlSupplier.SelectedValue = 0
        'txtDate.Text = ""
        txtStockAuditNo.Text = ""
        Dim dt3 As DataTable
        EL.AuditNo = 0
        EL.Supp_ID = 0
        dt3 = Dl.GetSuppAuditDetails(EL)
        GvSaleInvoice.DataSource = dt3
        GvSaleInvoice.DataBind()
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        dt = Bl.AutoGenerateNo(EL)

        If dt.Rows.Count > 0 Then
            txtStockAuditNo.Text = dt.Rows(0).Item("AuditNo").ToString
            If txtStockAuditNo.Text = "" Then
                txtStockAuditNo.Text = 1
            End If
        End If
    End Sub

    Protected Sub GVProdDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVProdDetails.RowDeleting

        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Id = CType(GVProdDetails.Rows(e.RowIndex).FindControl("lblStkId"), HiddenField).Value
            Dl.DeleteProdDetails(EL)
            GVProdDetails.DataBind()
            'lblGreen.Visible = True
            lblRed.Text = " "
            lblGreen.Text = "Data Deleted Successfully."

            GVProdDetails.PageIndex = ViewState("PageIndex")
            EL.Id = 0
            displayDetails(EL)

        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If

    End Sub



    Protected Sub GVProdDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVProdDetails.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblRed.Text = ""
            lblGreen.Text = ""
            Try
                ViewState("Stk_Id") = CType(GVProdDetails.Rows(e.NewEditIndex).FindControl("lblStkId"), HiddenField).Value
                DDLRM.SelectedValue = CType(GVProdDetails.Rows(e.NewEditIndex).FindControl("lblProdId"), HiddenField).Value
                DDLBatch.Items.Clear()
                DDLBatch.DataSourceID = "ObjBatch"
                DDLBatch.DataBind()
                DDLBatch.SelectedValue = (CType(GVProdDetails.Rows(e.NewEditIndex).FindControl("lblBatchId"), HiddenField).Value)
                txtQtyStock.Text = CType(GVProdDetails.Rows(e.NewEditIndex).FindControl("QtyinStk"), HiddenField).Value
                If CType(GVProdDetails.Rows(e.NewEditIndex).FindControl("lblQtyIn"), Label).Text = 0 Then
                    txtCountDiff.Text = CType(GVProdDetails.Rows(e.NewEditIndex).FindControl("lblQtyOut"), Label).Text
                Else
                    txtCountDiff.Text = CType(GVProdDetails.Rows(e.NewEditIndex).FindControl("lblQtyIn"), Label).Text
                End If
                ddlRemarks.SelectedValue = CType(GVProdDetails.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text

                'If CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVMFG"), Label).Text = "" Then
                '    ddlMFG.SelectedValue = 0
                'Else
                '    ddlMFG.Items.Clear()
                '    ddlMFG.DataSourceID = "ObjMFG"
                '    ddlMFG.DataBind()
                '    ddlMFG.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVMFG"), Label).Text
                'End If


                EL.AuditNo = txtStockAuditNo.Text
                EL.Supp_ID = ddlSupplier.SelectedValue
                EL.Id = ViewState("Stk_Id")
                dt = Dl.GetProdAddDetails(EL)
                GVProdDetails.DataSource = dt
                GVProdDetails.DataBind()

                GVProdDetails.Enabled = False
                GVProdDetails.Visible = True
                txtQtyStock.Enabled = False
                BtnClose.Enabled = False
                btnAddSaleInvoiceDetails.Text = "UPDATE"
                btnViewSaleInvoiceDetails.Text = "BACK"
                For Each grid In GVProdDetails.Rows
                    If CType(grid.FindControl("lblExpiry"), Label).Text = "01-Jan-1900" Then
                        CType(grid.FindControl("lblExpiry"), Label).Text = ""
                    End If

                Next
            Catch ex As Exception
                lblRed.Text = "Enter Correct Data."
                lblGreen.Text = ""
            End Try
        Else
            lblRed.Text = "You do not belong to this branch, Cannot edit data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub btnViewSaleInvoiceDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewSaleInvoiceDetails.Click
        LinkButton1.Focus()
        If btnViewSaleInvoiceDetails.Text = "VIEW" Then
            EL.AuditNo = txtStockAuditNo.Text
            EL.Supp_ID = ddlSupplier.SelectedValue
            EL.Id = 0
            displayDetails(EL)
            lblGreen.Text = ""
            lblRed.Text = ""
            BtnClose.Enabled = True
            ViewState("PageIndex") = 0
            DDLRM.SelectedValue = 0
            DDLBatch.SelectedValue = 0
            txtQtyStock.Text = ""


        Else
            EL.AuditNo = txtStockAuditNo.Text
            EL.Supp_ID = DDLRM.SelectedValue
            EL.Id = 0
            displayDetails(EL)
            lblGreen.Text = ""
            lblRed.Text = ""
            BtnClose.Enabled = True
            GVProdDetails.PageIndex = ViewState("PageIndex")
            btnAddSaleInvoiceDetails.Text = "ADD"
            btnViewSaleInvoiceDetails.Text = "VIEW"
            DDLRM.SelectedValue = 0
            DDLBatch.SelectedValue = 0
            txtQtyStock.Text = ""

        End If

    End Sub

    Protected Sub btnViewSaleInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewSaleInvoice.Click
        LinkButton1.Focus()
        Dim dt3 As DataTable
        EL.AuditNo = 0
        EL.Supp_ID = ddlSupplier.SelectedValue

        dt3 = Dl.GetSuppAuditDetails(EL)

        If dt3.Rows.Count > 0 Then
            GvSaleInvoice.Enabled = True
            GvSaleInvoice.Visible = True
            GvSaleInvoice.DataSource = dt3
            GvSaleInvoice.DataBind()
            lblErrorMsg.Text = ""
            lblMsg.Text = ""
        Else
            lblMsg.Text = ""
            lblErrorMsg.Text = "No records to display."
            GvSaleInvoice.Visible = False
        End If
    End Sub

    Protected Sub GvSaleInvoice_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvSaleInvoice.RowEditing

        txtStockAuditNo.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblAuditNo"), Label).Text
        ddlSupplier.SelectedValue = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblsuppid"), Label).Text
        txtDate.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblDate"), Label).Text
        Dim dt3 As DataTable

        EL.AuditNo = txtStockAuditNo.Text
        EL.Supp_ID = ddlSupplier.SelectedValue
        EL.Stock_Date = txtDate.Text
        dt3 = Dl.GetSuppAuditDetail(EL)

        If dt3.Rows.Count > 0 Then
            GvSaleInvoice.Enabled = True
            GvSaleInvoice.Visible = True
            GvSaleInvoice.DataSource = dt3
            GvSaleInvoice.DataBind()
            lblErrorMsg.Text = ""
            lblMsg.Text = ""
        Else
            lblMsg.Text = ""
            lblErrorMsg.Text = "No records to display."
            GvSaleInvoice.Visible = False
        End If


    End Sub

End Class
