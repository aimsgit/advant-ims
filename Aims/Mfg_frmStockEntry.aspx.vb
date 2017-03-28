
Partial Class Mfg_frmStockEntry

    Inherits BasePage
    Dim temp As Integer
    Dim item As Double
    Dim dt As DataTable
    Dim EL As New Mfg_ELStockEntry
    Dim BLL As New Mfg_BLStockEntry
    Dim DLL As New Mfg_DLStockEntry

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        LinkButton1.Focus()
        'dt = DLL.getStockEntry(EL)
        ''GridPO.Visible = True
        'If dt.Rows.Count > 0 Then
        '    GVPODetails.Enabled = True
        '    GVPODetails.Visible = True
        '    GVPODetails.DataSource = dt
        '    GVPODetails.DataBind()
        'Else
        '    lblmsg.Text = ""
        '    msginfo.Text = "No records to display."
        '    GVPODetails.Visible = False
        'End If



        If btnView.Text = "VIEW" Then
            GVPODetails.Enabled = True

            lblGreen.Text = ""
            lblRed.Text = ""

            ViewState("PageIndex") = 0
            GVPODetails.PageIndex = 0
            Dispgrid()
            'clear()
        ElseIf btnView.Text = "BACK" Then
            GVPODetails.Enabled = True
            lblGreen.Text = " "
            lblRed.Text = " "
            BtnClose.Enabled = True
            btnAdddet.Text = "ADD"
            btnView.Text = "VIEW"
            clear()
            GVPODetails.PageIndex = ViewState("PageIndex")
            Dispgrid()
        End If

    End Sub

    Protected Sub GVPODetails_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GVPODetails.RowCancelingEdit
        GVPODetails.EditIndex = -1
        Dispgrid()
        GVPODetails.Visible = True
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub

    Protected Sub GVPODetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVPODetails.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GVPODetails.Rows(e.RowIndex).FindControl("ID"), HiddenField).Value
            BLL.DeleteStock(EL)
            GVPODetails.DataBind()
            'lblGreen.Visible = True
            lblRed.Text = ""
            lblGreen.Text = "Data Deleted Successfully."
            ' clear()
            GVPODetails.PageIndex = ViewState("PageIndex")
            Dispgrid()
        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub
    Protected Sub GVPODetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVPODetails.RowEditing

        If (Session("BranchCode") = Session("ParentBranch")) Then

            lblmsg.Text = ""
            msginfo.Text = ""
            lblGreen.Text = ""
            lblRed.Text = ""
            btnAdddet.Text = "UPDATE"
            btnAdddet.Enabled = True
            btnView.Visible = True
            btnView.Text = "BACK"
            BtnClose.Enabled = False
            GVPODetails.Visible = True
            Dim exrate As Double
            ViewState("PRD_ID") = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("ID"), HiddenField).Value
            ddlCurrency.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("HIDCurrency"), HiddenField).Value
            exrate = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("HIDExRate"), HiddenField).Value
            txtExRate.Text = Format(exrate, "0.00")
            ' RbProduct.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("Producttype"), Label).Text
            'DDLProduct.Items.Clear()
            'DDLProduct.DataSourceID = "ObjProduct"
            'DDLProduct.DataBind()
            txtExpiry.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVExpiry"), Label).Text
            If CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVExpiry"), Label).Text = "01-Jan-3000" Then
                txtExpiry.Text = ""
            Else
                txtExpiry.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVExpiry"), Label).Text
            End If


            txtBatch.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVBatch"), Label).Text
            HIDBatch.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVBatchID"), Label).Text
            DDLProduct.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblProductID"), HiddenField).Value
            txtPurchase.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVQty"), Label).Text
            txtPurchase1.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVFree"), Label).Text
            txtquantity.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblTotalQty"), Label).Text
            ddlUnit.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblUnitId"), Label).Text
            If CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVMFG"), Label).Text = "" Then
                ddlMFG.SelectedValue = 0
            Else
                ddlMFG.Items.Clear()
                ddlMFG.DataSourceID = "ObjMFG"
                ddlMFG.DataBind()
                ddlMFG.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVMFG"), Label).Text
            End If
            If CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVMKT"), Label).Text = "" Then
                ddlMKT.SelectedValue = 0
            Else
                ddlMKT.Items.Clear()
                ddlMKT.DataSourceID = "ObjMkt"
                ddlMKT.DataBind()
                ddlMKT.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVMKT"), Label).Text
            End If

            txtPacking.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVPacking"), Label).Text
            txtSaleRate.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblSrate"), Label).Text
            TextBox2.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblPRate"), Label).Text
            txtMRP.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblMRP"), Label).Text
            txtDiscount.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVDiscount"), Label).Text
            'txtDiscountAmt.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVDiscountAmt"), Label).Text
            ddlTaxOn.SelectedItem.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVTaxon"), Label).Text
            ddlTaxAB.SelectedItem.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVTaxAB"), Label).Text
            ddlTaxPlan.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVTax"), Label).Text
            txtVAT.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVVAT"), Label).Text
            txtCST.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVCST"), Label).Text

            HidFlatRate.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVFlatRate"), Label).Text
            EL.id = ViewState("PRD_ID")

            dt = DLL.getStockEntry(EL)
            GVPODetails.DataSource = dt
            GVPODetails.DataBind()
            GVPODetails.Enabled = False
            GVPODetails.Visible = True

        Else
            lblmsg.Text = "You do not belong to this branch, Cannot edit data."
            msginfo.Text = ""
        End If
    End Sub
    Public Sub Dispgrid()
        Dim i As New Integer
        Dim count As New Integer

        If HidInvoice.Text = "" Then
            EL.id = 0
            dt = DLL.getStockEntry(EL)
            If dt.Rows.Count > 0 Then
                GVPODetails.Enabled = True
                GVPODetails.Visible = True
                GVPODetails.DataSource = dt
                GVPODetails.DataBind()
              
            Else
                lblGreen.Text = ""
                lblRed.Text = "No records to display."
                GVPODetails.Visible = False
            End If
        Else

            EL.InvoiceID = HidInvoice.Text
            dt = DLL.getStockEntryInvoice(EL)
            i = dt.Rows.Count
            If dt.Rows.Count > 0 Then
                GVPODetails.Enabled = True
                GVPODetails.Visible = True
                GVPODetails.DataSource = dt
                GVPODetails.DataBind()

                For Each rows As GridViewRow In GVPODetails.Rows
                    count = count + 1
                    If CType(rows.FindControl("lblamount"), Label).Text = "" Then
                        EL.Amount = EL.Amount + 0
                    Else
                        EL.Amount = EL.Amount + CType(rows.FindControl("lblamount"), Label).Text
                    End If

                Next
                For Each rows As GridViewRow In GVPODetails.Rows
                    count = count + 1
                    If CType(rows.FindControl("lblVatAMT"), Label).Text = "" Then
                        EL.VAT = EL.VAT + 0
                    Else
                        EL.VAT = EL.VAT + CType(rows.FindControl("lblVatAMT"), Label).Text
                    End If

                Next
                For Each rows As GridViewRow In GVPODetails.Rows
                    count = count + 1
                    If CType(rows.FindControl("lblGVFinalAmount"), Label).Text = "" Then
                        EL.FinalAmt = EL.FinalAmt + 0
                    Else
                        EL.FinalAmt = EL.FinalAmt + CType(rows.FindControl("lblGVFinalAmount"), Label).Text
                    End If

                Next

                For Each rows As GridViewRow In GVPODetails.Rows
                    count = count + 1
                    If CType(rows.FindControl("lblDescAmt"), Label).Text = "" Then
                        EL.Discount = EL.Discount + 0
                    Else
                        EL.Discount = EL.Discount + CType(rows.FindControl("lblDescAmt"), Label).Text
                    End If

                Next

                Dim finalround As Double = EL.FinalAmt
                Dim roundoff As Double
                Dim Roundoff1 As Double
                Dim Total As Double

                roundoff = Math.Round(finalround, 0)
                Roundoff1 = roundoff - EL.FinalAmt
                txtRound.Text = Format(Roundoff1, "0.00")

                txtLessDiscAmt.Text = EL.Discount.ToString("###,###,##.##")
                txtTotalAmt.Text = EL.Amount.ToString("###,###,##.##")
                txtAddVatAmt.Text = EL.VAT.ToString("###,###,##.##")
                txtFinlAmt.Text = EL.FinalAmt.ToString("###,###,##.##")

                Total = EL.FinalAmt + Roundoff1
                txtGrand.Text = Total.ToString("###,###,##.##")
               



                While (i > 0)

                    If dt.Rows(i - 1).Item("PostStatus") = "Posted" Then
                        GVPODetails.Columns(0).Visible = False
                    Else
                        GVPODetails.Columns(0).Visible = True

                    End If
                    i = i - 1
                End While




            Else
                lblGreen.Text = ""
                lblRed.Text = "No records to display."
                GVPODetails.Visible = False
            End If
        End If
    End Sub
    Public Sub DispgridM()

        EL.id = 0

        If txtEntryDate.Text = "" Then
            EL.EntryDate = "1/1/3000"
        Else
            EL.EntryDate = txtEntryDate.Text
        End If

        If ddlTranscation.SelectedValue = 0 Then
            EL.TranscationTypeid = 0
        Else
            EL.TranscationTypeid = ddlTranscation.SelectedValue
        End If

        If ddlSO.SelectedValue = 0 Then
            EL.SO = 0
        Else
            EL.SO = ddlSO.SelectedValue
        End If

        dt = BLL.GetStockEntryM(EL)
        If dt.Rows.Count > 0 Then
            GridStockEntryM.Enabled = True
            GridStockEntryM.Visible = True
            GridStockEntryM.DataSource = dt
            GridStockEntryM.DataBind()
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
            GridStockEntryM.Visible = False
        End If

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtEntryDate.Text = Format(Today, "dd-MMM-yyyy")
            Details.Visible = False
            'GridPO.Visible = False
            txtExRate.Text = "1.00"
            txtEntryDate.Focus()
            txtPurchase.Text = 1
            txtPurchase1.Text = 0
            'dt = BLL.GetInvoiceNo()
            'HidInvoice.Text = dt.Rows(0).Item("InvoiceId").ToString
            'EL.InvoiceNo = dt.Rows(0).Item("InvoiceNo").ToString
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        Details.Visible = True
        lblmsg.Text = ""
        msginfo.Text = ""
        btnAdddet.Enabled = True
        GVPODetails.Visible = False
        If HidInvoice.Text = "" Then
            dt = BLL.GetInvoiceNo()
            HidInvoice.Text = dt.Rows(0).Item("InvoiceId").ToString
            HidInvoiceNO.Text = dt.Rows(0).Item("InvoiceNo").ToString
        Else
            EL.InvoiceID = HidInvoice.Text
            dt = BLL.GetCurrency(EL)
            ddlCurrency.Focus()
            'If dt.Rows(0).Item("Currency").ToString = Nothing Then
            '    ddlCurrency.SelectedValue = 0
            'Else
            '    ddlCurrency.SelectedValue = dt.Rows(0).Item("Currency").ToString
            'End If

            'txtExRate.Text = dt.Rows(0).Item("FlatRate_AD").ToString
        End If
        'clear()
        lblRed.Text = ""
        lblGreen.Text = ""

    End Sub
    Protected Sub DDLProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLProduct.SelectedIndexChanged
        lblRed.Text = ""
        lblGreen.Text = ""
        If DDLProduct.SelectedValue <> 0 Then
            temp = DDLProduct.SelectedValue
            dt = Mfg_DLStockEntry.fillProduct(temp)
            If dt.Rows.Count > 0 Then
                ViewState("Product_Id") = dt.Rows(0).Item("Product_Id").ToString
                If dt.Rows(0).Item("New_Deal_Qty").ToString = "" Then
                    txtPurchase.Text = 0
                Else
                    txtPurchase.Text = Format(dt.Rows(0).Item("New_Deal_Qty"), "0.0")
                End If
                If dt.Rows(0).Item("New_Deal_Free").ToString = "" Then
                    txtPurchase1.Text = 0
                Else
                    txtPurchase1.Text = Format(dt.Rows(0).Item("New_Deal_Free"), "0.0")
                End If
                If dt.Rows(0).Item("Case_Factor_In_Strip").ToString = "" Then
                    ddlUnit.SelectedValue = 0
                Else
                    ddlUnit.SelectedValue = dt.Rows(0).Item("Case_Factor_In_Strip").ToString
                End If
                txtPacking.Text = dt.Rows(0).Item("Packing_Details").ToString
                If dt.Rows(0).Item("New_Sale_MRP").ToString = "" Then
                    txtMRP.Text = 0
                Else
                    txtMRP.Text = Format(dt.Rows(0).Item("New_Sale_MRP"), "0.00")
                End If

                If dt.Rows(0).Item("New_Purchase_Rate").ToString = "" Then
                    TextBox2.Text = 0
                Else
                    TextBox2.Text = Format(dt.Rows(0).Item("New_Purchase_Rate"), "0.00")
                End If

                If dt.Rows(0).Item("New_Sale_Rate").ToString = "" Then

                    txtSaleRate.Text = 0

                Else
                    txtSaleRate.Text = Format(dt.Rows(0).Item("New_Sale_Rate"), "0.00")
                End If
                txtBatch.Text = dt.Rows(0).Item("Batch").ToString
                If dt.Rows(0).Item("Batch_ID").ToString = "" Then
                    EL.BatchId = 0
                Else
                    HIDBatch.Text = dt.Rows(0).Item("Batch_ID").ToString
                End If
                If dt.Rows(0).Item("Expiry").ToString = "" Then
                    txtExpiry.Text = ""
                Else
                    txtExpiry.Text = Format(dt.Rows(0).Item("Expiry"), "dd-MMM-yyyy")
                End If

                If ddlTaxPlan.SelectedValue = "" Then
                    ddlTaxPlan.SelectedValue = 0
                Else
                    ddlTaxPlan.SelectedValue = dt.Rows(0).Item("PurchTaxPlan").ToString
                End If

                If dt.Rows(0).Item("Purchase_Discount_Percent").ToString = "" Then
                    txtDiscount.Text = 0
                Else
                    txtDiscount.Text = Format(dt.Rows(0).Item("Purchase_Discount_Percent"), "0.00")
                End If
                If dt.Rows(0).Item("VAT_On_Free_percent").ToString <> 0 And dt.Rows(0).Item("VAT_On_Free_percent").ToString <> "" Then
                    HidFlatRate.Text = dt.Rows(0).Item("VAT_On_Free_percent").ToString
                End If
                EL.TaxPlan = ddlTaxPlan.SelectedValue
                dt = DLL.filltax(EL)
                If dt.Rows.Count > 0 Then
                    txtCST.Text = dt.Rows(0).Item("CST").ToString
                    txtVAT.Text = dt.Rows(0).Item("State_VAT").ToString
                End If

            End If
        Else
            txtSaleRate.Text = ""
            txtPurchase.Text = ""
            txtPurchase1.Text = ""
            ddlUnit.SelectedValue = 0
            txtPacking.Text = ""
            txtSaleRate.Text = ""
            TextBox2.Text = ""
            txtMRP.Text = ""
            txtBatch.Text = ""
            txtExpiry.Text = ""
            ddlTaxPlan.SelectedValue = 0
            txtCST.Text = ""
            txtVAT.Text = ""

        End If
    End Sub
    Protected Sub ddlTaxPlan_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTaxPlan.SelectedIndexChanged
        EL.TaxPlan = ddlTaxPlan.SelectedValue
        dt = DLL.filltax(EL)
        If dt.Rows.Count > 0 Then
            txtCST.Text = dt.Rows(0).Item("CST").ToString
            txtVAT.Text = dt.Rows(0).Item("State_VAT").ToString
        End If
    End Sub

    Protected Sub btnAdddet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdddet.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Try
                EL.ProductType = RbProduct.SelectedValue
                EL.Currency = ddlCurrency.SelectedValue
                If txtExRate.Text = "" Then
                    EL.ExchangeRate = 1.0
                Else
                    EL.ExchangeRate = txtExRate.Text
                End If
                EL.Productid = DDLProduct.SelectedValue

                EL.Batch = txtBatch.Text
                If HIDBatch.Text = "" Then
                    EL.BatchId = 0
                Else
                    EL.BatchId = HIDBatch.Text
                End If
                If txtExpiry.Text = "" Then
                    EL.Expiry = "1/1/3000"
                Else
                    EL.Expiry = txtExpiry.Text
                End If
                If txtPurchase.Text = "" Then
                    EL.PurchaseDeal = 0.0
                Else
                    EL.PurchaseDeal = txtPurchase.Text
                End If
                If txtPurchase1.Text = "" Then
                    EL.PurchaseDeal1 = 0.0
                Else
                    EL.PurchaseDeal1 = txtPurchase1.Text
                End If

                If txtquantity.Text = "" Then
                    EL.Qty = 0.0
                Else
                    EL.Qty = txtquantity.Text
                End If
                '---------------------------------------------------------------------------------------------------------
                '-- this block is use to seperate the qty and free from total qty or Accepted qty.
                EL.Deal = EL.PurchaseDeal / (EL.PurchaseDeal + EL.PurchaseDeal1) * EL.Qty
                EL.Free = EL.PurchaseDeal1 / (EL.PurchaseDeal + EL.PurchaseDeal1) * EL.Qty
                '----------------------------------------------------------------------------------------------

                EL.Unit = ddlUnit.SelectedValue
                EL.MFG = ddlMFG.SelectedValue
                EL.MKT = ddlMKT.SelectedValue
                EL.Packing = txtPacking.Text
                If txtSaleRate.Text = "" Then
                    EL.SaleRate = 0.0
                Else
                    EL.SaleRate = txtSaleRate.Text * EL.ExchangeRate
                End If
                If TextBox2.Text = "" Then
                    EL.PurchRate = 0.0
                Else
                    EL.PurchRate = TextBox2.Text * EL.ExchangeRate
                End If

                EL.Amount = EL.Qty * EL.PurchRate
                If txtMRP.Text = "" Then
                    EL.MRP = 0.0
                Else
                    EL.MRP = txtMRP.Text * EL.ExchangeRate
                End If
                If txtDiscount.Text <> "" And txtDiscountAmt.Text = "" Then
                    EL.Discount = txtDiscount.Text
                    EL.Discountamt = (EL.PurchRate * EL.Qty) * EL.Discount / 100
                    txtDiscountAmt.Text = Format(EL.Discountamt, "0.0")
                ElseIf txtDiscountAmt.Text <> "" And txtDiscount.Text = "" Then
                    EL.Discountamt = txtDiscountAmt.Text
                    EL.Discount = (EL.Discountamt * 100) / ((EL.PurchRate) * EL.Qty)
                    txtDiscount.Text = Format(EL.Discount, "0.0")
                Else
                    lblRed.Text = "Please Enter Discount or Discount Amount"
                    lblGreen.Text = ""
                    Exit Sub
                End If
                EL.Taxon = ddlTaxOn.SelectedItem.Text
                EL.TaxAB = ddlTaxAB.SelectedItem.Text
                EL.TaxPlan = ddlTaxPlan.SelectedValue
                If HidFlatRate.Text = "" Then
                    EL.flatRate = 0
                Else
                    EL.flatRate = HidFlatRate.Text
                End If
                If txtVAT.Text = "" Then
                    EL.VAT = 0
                Else
                    EL.VAT = txtVAT.Text
                End If
                If txtCST.Text = "" Then
                    EL.CST = 0
                Else
                    EL.CST = txtCST.Text
                End If
                If txtVAT.Text <> "0" Then
                    EL.FinalAmt = EL.Amount - (EL.Amount * EL.Discount / 100)
                    EL.FinalAmt = EL.FinalAmt + (EL.FinalAmt * EL.VAT / 100)
                ElseIf txtCST.Text <> "0" Then
                    EL.FinalAmt = EL.Amount - (EL.Amount * EL.Discount / 100)
                    EL.FinalAmt = EL.FinalAmt + (EL.FinalAmt * EL.CST / 100)
                End If

                '------------------------------------------------------------------------------------------------------------------------------

                EL.sngPurchRate = EL.PurchRate
                EL.sngTradeDiscount = EL.sngPurchRate * EL.Qty * EL.Discount / 100
                EL.sngFlatDiscount = 0

                EL.Amount = EL.PurchRate * EL.Deal
                Dim sngTax As Double
                If EL.Taxon = "MRP with tax on free goods" Then
                    If EL.TaxAB = "B" Then
                        sngTax = EL.MRP * (EL.Deal + EL.Free) * (EL.VAT + EL.CST) / 100
                    Else
                        sngTax = EL.MRP * (EL.Deal + EL.Free) * (EL.VAT + EL.CST) / 100
                    End If

                ElseIf EL.Taxon = "MRP without tax on free goods" Then

                    If EL.TaxAB = "B" Then
                        sngTax = EL.MRP * EL.Deal * (EL.VAT + EL.CST) / 100
                    ElseIf EL.TaxAB = "A" Then
                        sngTax = EL.MRP * EL.Deal * (EL.VAT + EL.CST) / 100
                    End If

                ElseIf EL.Taxon = "Purchase Price with tax on free goods" Then

                    If EL.TaxAB = "B" Then

                        sngTax = EL.PurchRate * (EL.Deal + EL.Free) * (EL.VAT + EL.CST) / 100

                    ElseIf EL.TaxAB = "A" Then

                        sngTax = (EL.PurchRate * (EL.Deal + EL.Free) - EL.sngTradeDiscount - 0) * (EL.VAT + EL.CST) / 100
                    End If


                ElseIf EL.Taxon = "Purchase Price without tax on free goods" Then

                    If EL.TaxAB = "B" Then

                        sngTax = EL.PurchRate * EL.Deal * (EL.VAT + EL.CST) / 100

                    ElseIf EL.TaxAB = "A" Then

                        'sngTax = (EL.PurchRate * (EL.Qty + EL.free) - Discount - EL.sngTradeDiscount - EL.FlatDiscount) * (EL.VAT + EL.CST) / 100
                        sngTax = (EL.PurchRate * EL.Qty - EL.sngTradeDiscount - 0) * (EL.VAT + EL.CST) / 100
                    End If
                End If
                EL.MRPValue = (EL.Qty * EL.MRP)
                EL.VATRate = IIf(EL.VAT > 0, sngTax, 0)
                EL.CSTRate = IIf(EL.CST > 0, sngTax, 0)
                EL.FinalAmt = EL.Amount - EL.sngTradeDiscount - EL.sngFlatDiscount + sngTax
                EL.flatRate = (EL.Amount - EL.sngTradeDiscount - EL.sngFlatDiscount + sngTax) / EL.Qty
                If btnAdddet.Text = "ADD" Then

                    HidMInvoice.Text = HidInvoice.Text
                    If HidMInvoice.Text = "" Then
                        EL.InvoiceID = 0
                    Else
                        EL.InvoiceID = HidMInvoice.Text
                    End If

                    BLL.InsertRecord(EL)
                    msginfo.Text = ""
                    lblGreen.Text = "Data Saved Successfully."
                    btnAdddet.Text = "ADD"
                    lblRed.Text = ""

                    clear()
                    'HidInvoice.Text = dt.Rows(0).Item("Purchase_Invoice_ID").ToString
                    Dispgrid()
                ElseIf btnAdddet.Text = "UPDATE" Then
                    EL.id = ViewState("PRD_ID")
                    BLL.UpdateRecord(EL)
                    lblGreen.Text = "Data Updated Successfully."
                    lblRed.Text = ""
                    btnAdddet.Text = "ADD"
                    BtnClose.Enabled = True
                    btnView.Text = "VIEW"
                    clear()
                    Dispgrid()
                End If
            Catch ex As Exception
                msginfo.Text = "Enter correct data."
                lblmsg.Text = ""
            End Try
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                Details.Visible = False

                If txtEntryDate.Text = "" Then
                    EL.EntryDate = "01-Jan-3000"
                Else
                    EL.EntryDate = txtEntryDate.Text
                End If
                EL.TranscationType = ddlTranscation.SelectedItem.ToString
                EL.SO = ddlSO.SelectedValue
                EL.Remarks = txtRemarks.Text
                EL.TranscationTypeid = ddlTranscation.SelectedValue
                If HidInvoice.Text = "" Then
                    EL.InvoiceID = 0
                Else
                    EL.InvoiceID = HidInvoice.Text
                End If
                If HidInvoiceNO.Text = "" Then

                    EL.InvoiceNo = ""
                Else
                    EL.InvoiceNo = HidInvoiceNO.Text
                End If

                If btnAdd.Text = "ADD" Then
                    If HidMInvoice.Text <> "0" And HidMInvoice.Text <> "" Then
                        BLL.InsertStockEntry(EL)
                        msginfo.Text = ""
                        lblmsg.Text = "Data Saved Successfully."
                        btnAdd.Text = "ADD"
                        HidInvoice.Text = ""
                        HidMInvoice.Text = ""
                        DispgridM()
                        ClearM()
                    Else
                        msginfo.Text = "First Add Product Details."
                        lblmsg.Text = ""
                    End If
                ElseIf btnAdd.Text = "UPDATE" Then
                    EL.PID = ViewState("PurchMain")
                    'EL.InvoiceID = ViewState("Purchase_Invoice_ID")
                    dt = BLL.PostStatus(EL)
                    If dt.Rows.Count = 0 Then
                        msginfo.Text = ""
                        BLL.UpdateRecordM(EL)
                        lblmsg.Text = "Data Updated Successfully."
                        HidInvoice.Text = ""
                        btnAdd.Text = "ADD"
                        btnDetails.Visible = True
                        BtnStockView.Text = "VIEW"
                        EL.id = 0
                        DispgridM()
                        btnPost.Enabled = True
                        HidInvoice.Text = ""
                        ClearM()
                    Else
                        msginfo.Text = "Stock is Already Posted"
                        lblmsg.Text = ""
                        HidInvoice.Text = ""
                        DispgridM()



                    End If

                End If

            Catch ex As Exception
                msginfo.Text = "Enter correct data."
                lblmsg.Text = ""
            End Try
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub ClearM()
        txtEntryDate.Text = Format(Today, "dd-MMM-yyyy")
        txtTotalAmt.Text = ""
        txtRound.Text = ""
        txtAddVatAmt.Text = ""
        txtFinlAmt.Text = ""
        txtGrand.Text = ""
        txtLessDiscAmt.Text = ""

    End Sub
    'Public Function GetMulticurrencyRate(ByVal id As Long) As MultiCurrency
    '    Dim mcurrencyname As New MultiCurrency
    '    Dim ds As DataSet = MultiCurrencyDB.GetMultiCurrencyRate(id)
    '    Dim row As DataRow
    '    For Each row In ds.Tables(0).Rows
    '        mcurrencyname = New MultiCurrency(row("Currency_Code"), row("Currency_Name"), row("Buy_Conversion_Rate"))
    '    Next
    '    Return mcurrencyname
    'End Function


    Protected Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
        Dim MC1 As New MultiCurrencyManager
        Dim MCD As MultiCurrency = MC1.GetMulticurrencyRate(CInt(IIf(ddlCurrency.SelectedValue.ToString = "", 0, ddlCurrency.SelectedValue.ToString)))
        txtExRate.Text = MCD.BuyConversionRate
    End Sub

    Protected Sub BtnStockView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnStockView.Click
        If BtnStockView.Text = "VIEW" Then
            GridStockEntryM.Enabled = True
            Details.Visible = False
            lblmsg.Text = " "
            msginfo.Text = " "
            EL.id = 0
            ViewState("PageIndex") = 0
            GridStockEntryM.PageIndex = 0
            DispgridM()
            'clear()
        ElseIf BtnStockView.Text = "BACK" Then
            GridStockEntryM.Enabled = True
            lblmsg.Text = " "
            msginfo.Text = " "
            btnAdd.Text = "ADD"
            BtnStockView.Text = "VIEW"
            btnPost.Enabled = True
            HidInvoice.Text = ""
            clear()
            Details.Visible = False
            GridStockEntryM.PageIndex = ViewState("PageIndex")
            DispgridM()
        End If
    End Sub

    Protected Sub GridStockEntryM_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridStockEntryM.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GridStockEntryM.Rows(e.RowIndex).FindControl("ID"), HiddenField).Value
            BLL.DeleteStockM(EL)
            GridStockEntryM.DataBind()
            'lblGreen.Visible = True
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            ' clear()
            GridStockEntryM.PageIndex = ViewState("PageIndex")
            DispgridM()
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot delete data."
            msginfo.Text = ""
        End If
    End Sub

    Protected Sub GridStockEntryM_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridStockEntryM.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblmsg.Text = ""
            msginfo.Text = ""
            btnAdd.Text = "UPDATE"
            btnView.Visible = True
            BtnStockView.Text = "BACK"
            'btnDetails.Visible = False
            GridStockEntryM.Visible = True
            ViewState("PurchMain") = CType(GridStockEntryM.Rows(e.NewEditIndex).FindControl("ID"), HiddenField).Value


            ddlTranscation.SelectedValue = CType(GridStockEntryM.Rows(e.NewEditIndex).FindControl("lblGVTranscationID"), Label).Text

            txtEntryDate.Text = CType(GridStockEntryM.Rows(e.NewEditIndex).FindControl("lblGVEntrydate"), Label).Text

            If CType(GridStockEntryM.Rows(e.NewEditIndex).FindControl("lblGVSOID"), Label).Text = "" Then
                ddlSO.SelectedValue = 0
            Else
                ddlSO.SelectedValue = CType(GridStockEntryM.Rows(e.NewEditIndex).FindControl("lblGVSOID"), Label).Text
            End If

            txtRemarks.Text = CType(GridStockEntryM.Rows(e.NewEditIndex).FindControl("lblGVRemarks"), Label).Text
            HidInvoice.Text = CType(GridStockEntryM.Rows(e.NewEditIndex).FindControl("lblgvinvoiceId"), Label).Text
            HidPost.Text = CType(GridStockEntryM.Rows(e.NewEditIndex).FindControl("lblGVPost"), Label).Text
           
            EL.PID = ViewState("PurchMain")
            If txtEntryDate.Text = "" Then
                EL.EntryDate = "1/1/3000"
            Else
                EL.EntryDate = txtEntryDate.Text
            End If

            If ddlTranscation.SelectedValue = 0 Then
                EL.TranscationTypeid = 0
            Else
                EL.TranscationTypeid = ddlTranscation.SelectedValue
            End If

            If ddlSO.SelectedValue = 0 Then
                EL.SO = 0
            Else
                EL.SO = ddlSO.SelectedValue
            End If
            btnPost.Enabled = False
            dt = BLL.GetStockEntryM(EL)
            GridStockEntryM.DataSource = dt
            GridStockEntryM.DataBind()
            GridStockEntryM.Enabled = False
            GridStockEntryM.Visible = True
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot edit data."
            msginfo.Text = ""
        End If
    End Sub
    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim id As String = ""
        Dim check As String = ""

        Dim count As New Integer
        count = 0
        For Each grid As GridViewRow In GridStockEntryM.Rows
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
            msginfo.Text = "Select Atleast One Stock to Post"
            lblmsg.Text = ""
        Else
            EL.ChkID = id
            BLL.PostPurchaseOrder(EL)
            lblmsg.Text = "Stock posted successfully."
            msginfo.Text = ""
            DispgridM()
        End If


        'Dim check As String = ""
        'Dim count As New Integer
        'Dim id As String = ""
        'For Each Grid As GridViewRow In GridViewSO.Rows
        '    If CType(Grid.FindControl("chkbox"), CheckBox).Checked = True Then
        '        check = CType(Grid.FindControl("lblSales_Order_ID1"), Label).Text
        '        id = check + "," + id
        '        count = count + 1
        '        ELSaleOrderMfg.Sale_Order_Number = check
        '        BLSalesorderMfg.UpdatePostFlag(ELSaleOrderMfg)
        '        lblmsg.Text = "Posted successfully."
        '        lblErrorMsg.Text = ""
        '    Else
        '        lblErrorMsg.Text = "Please select atleast one buyer."
        '        lblmsg.Text = ""
        '    End If
        'Next
    End Sub
    Sub CheckAll()
        If CType(GridStockEntryM.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GridStockEntryM.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GridStockEntryM.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Details.Visible = "false"
        btnAdddet.Enabled = True
        btnDetails.Enabled = True
        btnView.Enabled = True
        GVPODetails.Visible = False
    End Sub
    Sub clear()
        DDLProduct.ClearSelection()
        txtBatch.Text = ""
        txtExpiry.Text = ""
        txtPurchase.Text = ""
        txtPurchase1.Text = ""
        txtquantity.Text = ""
        'ddlUnit.SelectedValue = 0
        'ddlMFG.SelectedValue = 0
        'ddlMKT.SelectedValue = 0
        txtPacking.Text = ""
        txtSaleRate.Text = ""
        TextBox2.Text = ""
        txtMRP.Text = ""
        txtDiscount.Text = ""
        txtDiscountAmt.Text = ""
        'ddlTaxOn.SelectedItem.Text = "Select"
        'ddlTaxAB.SelectedItem.Text = "Select"
        'ddlTaxPlan.SelectedValue = 0
        HidFlatRate.Text = ""
        txtVAT.Text = ""
        txtCST.Text = ""
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            Dim check As String = ""
            Dim id As String = ""

            Dim Count1 As Integer = 0
            For Each Grid As GridViewRow In GridStockEntryM.Rows

                If CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(Grid.FindControl("lblgvinvoiceId"), Label).Text
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

                Dim qrystring As String = "Mfg_Rpt_StockEntry.aspx?" & "&id=" & id
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Else
                lblmsg.Text = "Please select the records to print."
                msginfo.Text = ""
            End If

        Catch ex As Exception
            msginfo.Text = "Please select the records from gridview. "
        End Try
    End Sub
    Protected Sub GridStockEntryM_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridStockEntryM.PageIndexChanging
        GridStockEntryM.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVPODetails.PageIndex
        DispgridM()
        GridStockEntryM.Visible = True
        lblmsg.Text = " "
        msginfo.Text = " "
    End Sub
End Class
