
Partial Class Mfg_frmPurchaseInvoice
    Inherits BasePage
    Dim EL As New Mfg_ELPurchaseInvoice
    Dim dt As DataTable
    Dim BLL As New Mfg_BLPurchaseInvoice
    Dim DL As New Mfg_DLPurchaseInvoice


    Protected Sub ddlSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSupplier.SelectedIndexChanged
        lblRed.Text = ""
        lblGreen.Text = ""

        EL.Supplier = ddlSupplier.SelectedValue
        dt = Mfg_DLPurchaseInvoice.GetSupplierAutoFill(EL)
        If dt.Rows.Count > 0 Then
            'ViewState("ProductAutoNo") = dt.Rows(0).Item("Opening_Balance_CR").ToString
            If dt.Rows(0).Item("Opening_Balance_CR").ToString = "" Then
                txtBalance.Text = 0
            Else
                txtBalance.Text = Format(dt.Rows(0).Item("Opening_Balance_CR"), "0.00")
            End If
            If dt.Rows(0).Item("Credit_Limit").ToString = "" Then
                txtCreditLimitM.Text = 0
            Else
                txtCreditLimitM.Text = Format(dt.Rows(0).Item("Credit_Limit"), "0.00")
            End If
            If dt.Rows(0).Item("Credit_Period").ToString = "" Then
                txtCreditPeroidM.Text = ""
            Else
                txtCreditPeroidM.Text = Format(dt.Rows(0).Item("Credit_Period"))
            End If
        End If
        If HIDPURCHINVOICEID.Text = "" Then
            dt = Mfg_DLPurchaseInvoice.GetInvoiceNo()
            HIDPURCHINVOICEID.Text = dt.Rows(0).Item("InvoiceId").ToString
            txtPurchInvoiceM.Text = dt.Rows(0).Item("InvoiceNo").ToString
            txtGRN.Text = dt.Rows(0).Item("GRN").ToString
        End If
    End Sub
    Public Sub displaytotal()

    End Sub


    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                EL.Supplier = ddlSupplier.SelectedValue
                EL.PurchaseInvoiceNo = txtPurchInvoiceM.Text
                If txtInvoiceDateM.Text = "" Then
                    EL.InvoiceDate = "01/01/1900"
                Else
                    EL.InvoiceDate = txtInvoiceDateM.Text
                End If
                EL.Invoice_Type = ddlIVType.SelectedValue
                If txtEntryDateM.Text = "" Then
                    EL.ReceiptDate = "01/01/1900"
                Else
                    EL.ReceiptDate = txtEntryDateM.Text
                End If

                'EL.PaymentType = ddlPaymentMethod.SelectedValue
                'If txtGRN.Text = "" Then
                '    EL.GRN = 0
                'Else
                EL.GRN = txtGRN.Text
                'End If
                EL.Remarks = txtRemarksM.Text
                If txtMRPValueM.Text = "" Then
                    EL.MRPValue = 0
                Else
                    EL.MRPValue = txtMRPValueM.Text
                End If
                If txtMiscExpM.Text = "" Then
                    EL.MiscExpValue = 0
                Else
                    EL.MiscExpValue = txtMiscExpM.Text
                End If
                If txtFlatDiscM.Text = "" Then
                    EL.FlatDiscount = 0
                Else
                    EL.FlatDiscount = txtFlatDiscM.Text
                End If
                If txtFlatDiscAmtM.Text = "" Then
                    EL.FlatDiscountAmt = 0
                Else
                    EL.FlatDiscountAmt = txtFlatDiscAmtM.Text
                End If
                If txtDiffAmtM.Text = "" Then
                    EL.DiffAmt = 0
                Else
                    EL.DiffAmt = txtDiffAmtM.Text
                End If
                If txtTaxDiffM.Text = "" Then
                    EL.TaxDiff = 0
                Else
                    EL.TaxDiff = txtTaxDiffM.Text
                End If
                If txtDiscDiffM.Text = "" Then
                    EL.DiscDiff = 0
                Else
                    EL.DiscDiff = txtDiscDiffM.Text
                End If
                If txtExciseDiff.Text = "" Then
                    EL.ExiciseDiff = 0
                Else
                    EL.ExiciseDiff = txtExciseDiff.Text
                End If
                If txtRoundOffM.Text = "" Then
                    EL.RoundOff = 0
                Else
                    EL.RoundOff = txtRoundOffM.Text
                End If
                If HIDPURCHINVOICEID.Text = "" Then
                    EL.PurchaseInvoiceID = 0
                Else
                    EL.PurchaseInvoiceID = HIDPURCHINVOICEID.Text
                End If
                EL.PONO = ddlPOM.SelectedValue
                EL.DispatchFrom = txtDispatchM.Text
                EL.DispatchTo = txtDispatchToM.Text
                EL.TransporatationId = ddlShipment.SelectedValue
                EL.TransportationNo = txtTransportation.Text
                EL.ReceivedBy = txtReceivedByM.Text
                EL.ReceivedAddress = txtRecvdAddM.Text
                If txtPaymentDateM.Text = "" Then
                    EL.PaymentDate = "01/01/1900"
                Else
                    EL.PaymentDate = txtPaymentDateM.Text
                End If


                txtTotalDiffAmt.Text = EL.DiffAmt
                txtTotalRoundOff.Text = EL.RoundOff
                If txtTotalAmount.Text = "" Then
                    EL.TotalAmount = 0.0
                Else
                    EL.TotalAmount = txtTotalAmount.Text
                End If
                If txtTotalDicAmt.Text = "" Then
                    EL.TradeDiscAmount = 0.0
                Else
                    EL.TradeDiscAmount = txtTotalDicAmt.Text
                End If
                If txtTotalCSTAmt.Text = "" Then

                End If
                If txtTotalCSTAmt.Text = "" Then
                    EL.TotalCSTAmount = 0.0
                Else

                    EL.TotalCSTAmount = txtTotalCSTAmt.Text
                End If
                If txtTotalVatAmt.Text = "" Then
                    EL.TotalVATAmount = 0.0
                Else
                    EL.TotalVATAmount = txtTotalVatAmt.Text
                End If
                If txtTotalFinalAmt.Text = "" Then
                    EL.TotalFinalAmount = 0.0
                Else
                    EL.TotalFinalAmount = txtTotalFinalAmt.Text
                End If
                If txtTotalExcise.Text = "" Then
                    EL.ExciseDuty = 0.0
                Else
                    EL.ExciseDuty = txtTotalExcise.Text
                End If
                If txtMRPValueM.Text = "" Then
                    EL.MRPTotalValue = 0.0
                Else
                    EL.MRPTotalValue = txtMRPValueM.Text
                End If
                'Me.FlatDiscount = (Me.FLatDiscAmt * 100) / (Me.TotalAmount - Me.Calculation_Of_Amount_FinalAmount_Subform!ExciseDuty1 - Me.Calculation_Of_Amount_FinalAmount_Subform![Trade Discount Amount1])
                If txtFlatDiscM.Text <> "" And txtFlatDiscAmtM.Text <> "" Then
                    lblRedM.Text = "Please Enter Flat Discount or Flat Discount Amount."
                    lblGreenM.Text = ""
                    Exit Sub
                End If
                If EL.FlatDiscount <> 0 Then
                    EL.FlatDiscountAmt = (CDbl(txtTotalAmount.Text) - CDbl(txtTotalExcise.Text) - CDbl(txtTotalDicAmt.Text)) * (EL.FlatDiscount / 100)

                ElseIf EL.FlatDiscountAmt <> 0 Then
                    'Me.FlatDiscount = (Me.FLatDiscAmt * 100) / (Me.TotalAmount - Me.Calculation_Of_Amount_FinalAmount_Subform!ExciseDuty1 - Me.Calculation_Of_Amount_FinalAmount_Subform![Trade Discount Amount1])
                    EL.FlatDiscount = (EL.FlatDiscountAmt * 100) / (EL.TotalAmount - EL.ExciseDuty - EL.TradeDiscAmount)

                Else
                    EL.FlatDiscount = 0
                    EL.FlatDiscountAmt = 0
                End If
                txtFlatDiscM.Text = EL.FlatDiscount
                txtTotalFlatDiscAmt.Text = EL.FlatDiscountAmt
                txtTotalExcise.Text = txtExciseDiff.Text
                txtTotalDiffAmt.Text = txtDiffAmtM.Text

                txtTotalRoundOff.Text = txtRoundOffM.Text
                txtTotalGrandFinalAmt.Text = EL.DiffAmt + EL.RoundOff + EL.TotalFinalAmount
                If txtTotalFinalAmt.Text = "" Then
                    txtTotalFinalAmt.Text = 0
                End If
                If txtTotalFlatDiscAmt.Text = "" Then
                    txtTotalFlatDiscAmt.Text = 0
                End If
                If txtTotalExcise.Text = "" Then
                    txtTotalExcise.Text = 0
                End If
                If txtTotalDiffAmt.Text = "" Then
                    txtTotalDiffAmt.Text = 0
                End If
                If txtTotalRoundOff.Text = "" Then
                    txtTotalRoundOff.Text = 0
                End If
                txtTotalGrandFinalAmt.Text = IIf(txtTotalDiffAmt.Text = "", 0, CDbl(txtTotalDiffAmt.Text)) + IIf(txtTotalRoundOff.Text = "", 0, CDbl(txtTotalRoundOff.Text)) + IIf(txtTotalFinalAmt.Text = "", 0, CDbl(txtTotalFinalAmt.Text))
                EL.GrandFinalAmount = txtTotalGrandFinalAmt.Text
                If btnAdd.Text = "ADD" Then
                    If HIDPurchaseInvoice.Text <> "" Then
                        dt = BLL.CheckDuplicate(EL)
                        If dt.Rows.Count > 0 Then
                            lblRedM.Text = "Data already exists."
                            lblGreenM.Text = " "
                        Else
                            BLL.InsertRecord(EL)
                            lblRedM.Text = ""
                            lblGreenM.Text = "Data Saved Successfully."
                            btnAdddet.Text = "ADD"
                            lblRed.Text = ""
                            display()
                            ClearM()
                            HIDPURCHINVOICEID.Text = ""
                            HIDPurchaseInvoice.Text = ""
                        End If
                    Else
                        lblRedM.Text = "Please Enter Some Product First."
                        lblGreenM.Text = ""
                        TabPanel2.Enabled = False
                    End If
                ElseIf btnAdd.Text = "UPDATE" Then
                    EL.PID = ViewState("PurchMain")
                    dt = BLL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        lblRedM.Text = "Data already exists."
                        lblGreenM.Text = " "
                    Else
                        If ViewState("PostStatus") <> "Posted" Then
                            BLL.UpdatePurchase(EL)
                            lblGreenM.Text = "Data Updated Successfully."
                            lblRedM.Text = ""
                            HIDPurchaseInvoice.Text = ""
                            HIDPURCHINVOICEID.Text = ""
                            display()
                            btnAdd.Text = "ADD"
                            BtnView.Text = "VIEW"
                            ViewState("PostStatus") = ""
                            btnAdddet.Enabled = True
                        Else
                            lblRedM.Text = "Cannot update the posted record."
                            lblGreenM.Text = ""
                            'ViewState("PostStatus") = ""
                        End If
                    End If
                End If
            Catch ex As Exception
                lblRedM.Text = "Enter Correct Data."
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
            EL.PID = 0
            ViewState("PageIndex") = 0
            display()
            'ClearM()
            lblRedM.Text = ""
            lblGreenM.Text = ""
            'GridPurchaseInvoiceM.Visible = True
            ' btnDetails.Visible = False
            ' txtPONo.Enabled = True
            'clear()
        Else
            'ddlSupplier.Enabled = True
            'lblSupplier.Enabled = True
            'btnPost.Enabled = True
            EL.PID = 0
            HIDPurchaseInvoice.Text = ""
            HIDPURCHINVOICEID.Text = ""
            lblRedM.Text = ""
            lblGreenM.Text = ""
            display()
            ClearM()
            GridPurchaseInvoiceM.PageIndex = ViewState("PageIndex")
            'GridPurchaseInvoiceM.Visible = False
            'btnDetails.Visible = False
            'GVPurchaseOrderDetails.Enabled = True
            'txtPONo.Enabled = True
            btnAdd.Text = "ADD"
            BtnView.Text = "VIEW"
            ViewState("PostStatus") = ""
            btnAdddet.Enabled = True

            'clear()
        End If
    End Sub
    Public Sub display()
        EL.PID = 0
        dt = BLL.GetPurchaseInvoiceM(EL)
        If dt.Rows.Count > 0 Then
            GridPurchaseInvoiceM.Enabled = True
            GridPurchaseInvoiceM.Visible = True
            GridPurchaseInvoiceM.DataSource = dt
            GridPurchaseInvoiceM.DataBind()
        Else
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
            GridPurchaseInvoiceM.Visible = False
        End If
        ' ClearM()
    End Sub

    Protected Sub DDLProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLProduct.SelectedIndexChanged
        Try
            Dim dt1 As DataTable
            Dim product As Integer = DDLProduct.SelectedValue
            If DDLProduct.SelectedValue = 0 Then
                txtPurchase.Text = ""
                txtPurchase1.Text = ""
                ddlUnitS.SelectedValue = 0
                txtPurchRateS.Text = ""
                txtMRP.Text = ""
                txtBatch.Text = ""
                txtExpiryS.Text = ""
                ddlTaxPlan.SelectedValue = 0
                txtVAT.Text = ""
                txtCST.Text = ""
            Else
                dt1 = Mfg_DLPurchaseInvoice.GetfillProduct(product)
                dt = Mfg_DLPurchaseInvoice.fillProduct(product)

                If dt1.Rows(0).Item("New_Deal_Qty").ToString = "" Then
                    txtPurchase.Text = 0
                Else
                    txtPurchase.Text = Format(dt1.Rows(0).Item("New_Deal_Qty"), "0.0")
                End If
                If dt1.Rows(0).Item("New_Deal_Free").ToString = "" Then
                    txtPurchase1.Text = 0
                Else
                    txtPurchase1.Text = Format(dt1.Rows(0).Item("New_Deal_Free"), "0.0")
                End If
                If dt1.Rows(0).Item("Case_Factor_In_Strip").ToString = "" Then
                    ddlUnitS.SelectedValue = 0
                Else
                    ddlUnitS.SelectedValue = dt1.Rows(0).Item("Case_Factor_In_Strip").ToString
                End If
                If dt1.Rows(0).Item("New_Purchase_Rate").ToString = "" Then
                    txtPurchRateS.Text = 0
                Else
                    txtPurchRateS.Text = Format(dt1.Rows(0).Item("New_Purchase_Rate"), "0.00")
                End If
                If dt1.Rows(0).Item("New_Sale_Rate").ToString = "" Then
                    txtSaleRate.Text = 0
                Else
                    txtSaleRate.Text = Format(dt1.Rows(0).Item("New_Sale_Rate"), "0.00")
                    EL.SaleRate = Format(dt1.Rows(0).Item("New_Sale_Rate"), "0.00")
                End If

                If dt1.Rows(0).Item("New_Sale_MRP").ToString = "" Then
                    txtMRP.Text = ""
                Else
                    txtMRP.Text = Format(dt1.Rows(0).Item("New_Sale_MRP"), "0.00")

                End If
                If ddlTaxPlan.SelectedValue = "" Then
                    ddlTaxPlan.SelectedValue = 0
                Else
                    ddlTaxPlan.SelectedValue = dt1.Rows(0).Item("PurchTaxPlan").ToString
                    EL.TaxPlan = ddlTaxPlan.SelectedValue
                End If

                If dt1.Rows(0).Item("Packing_Details").ToString = "" Then
                    txtPackingS.Text = ""
                Else
                    txtPackingS.Text = dt1.Rows(0).Item("Packing_Details").ToString
                End If
                If dt1.Rows(0).Item("VAT_On_Free_percent").ToString <> 0 And dt1.Rows(0).Item("VAT_On_Free_percent").ToString <> "" Then
                    HIDFlatRate.Text = dt1.Rows(0).Item("VAT_On_Free_percent").ToString
                End If
                dt1 = Mfg_DLPurchaseInvoice.filltax(EL)
                If dt1.Rows.Count > 0 Then
                    txtCST.Text = dt1.Rows(0).Item("CST").ToString
                    txtVAT.Text = dt1.Rows(0).Item("State_VAT").ToString
                End If
                txtBatch.Text = dt.Rows(0).Item("Batch").ToString
                HIDBatch.Text = dt.Rows(0).Item("Batch_ID").ToString
                If dt.Rows(0).Item("Expiry").ToString = "" Or dt.Rows(0).Item("Expiry").ToString = "1/1/1900" Then
                    txtExpiryS.Text = ""
                Else
                    txtExpiryS.Text = Format(dt.Rows(0).Item("Expiry"), "dd-MMM-yyyy")
                    If txtExpiryS.Text = "01-Jan-1900" Then
                        txtExpiryS.Text = ""
                    End If
                End If
            End If
        Catch ex As Exception
            'lblRed.Text = "Enter Correct Data."
            'lblGreen.Text = ""
        End Try
    End Sub

    Protected Sub btnAdddet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdddet.Click
        If ViewState("PostStatus") <> "Posted" Then
            EL.ProductType = RbProduct.SelectedValue
            EL.ProductId = DDLProduct.SelectedValue
            If HIDBatch.Text = "" Then
                EL.BatchID = 0
            Else
                EL.BatchID = HIDBatch.Text
            End If
            EL.Batch = txtBatch.Text
            If txtExpiryS.Text = "" Then
                EL.Expiry = "1/1/1900"
            Else
                EL.Expiry = txtExpiryS.Text
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
            If txtQtyrecvd.Text = "" Then
                EL.QtyRecd = 0.0
            Else
                EL.QtyRecd = txtQtyrecvd.Text
            End If
            If txtQtyAccept.Text = "" Then
                EL.QtyAccept = 0.0
            Else
                EL.QtyAccept = txtQtyAccept.Text
            End If

            If EL.QtyRecd < EL.QtyAccept Then
                lblRed.Text = "Quantity Receive must be greater than Quantity Accept."
                lblGreen.Text = ""
                Exit Sub
            End If
            EL.Unit = ddlUnitS.SelectedValue
            EL.Packing = txtPackingS.Text
            EL.MFG = ddlMFG.SelectedValue
            EL.MKT = ddlMKT.SelectedValue
            EL.RemarksProduct = txtRemarks.Text
            If txtVAT.Text = "" Then
                EL.VAT = 0.0
            Else
                EL.VAT = txtVAT.Text
            End If
            If txtCST.Text = "" Then
                EL.CST = 0.0
            Else
                EL.CST = txtCST.Text
            End If
            EL.Currency = ddlCurrency.SelectedValue
            If txtExRate.Text = "" Then
                EL.ExchangeRate = 0.0
            Else
                EL.ExchangeRate = txtExRate.Text
            End If

            If txtPurchRateS.Text = "" Then
                EL.PurchRate = 0.0
            Else
                EL.PurchRate = txtPurchRateS.Text
            End If

            EL.PurchRateIV = ddlPurchRate.SelectedItem.Text
            If txtExcise.Text = "" Then
                EL.Excise = 0.0
            Else
                EL.Excise = txtExcise.Text
            End If

            If txtSaleRate.Text = "" Then
                EL.SaleRate = 0.0
            Else
                EL.SaleRate = txtSaleRate.Text
            End If

            If txtMRP.Text = "" Then
                EL.MRP = 0.0
            Else
                EL.MRP = txtMRP.Text
            End If

            If txtDiscount.Text = "" Then
                EL.Discount = 0
            Else
                EL.Discount = txtDiscount.Text
            End If

            If txtDiscountAmt.Text = "" Then
                EL.Discountamt = 0.0
            Else
                EL.Discountamt = txtDiscountAmt.Text
            End If

            If txtMRPValueM.Text = "" Then
                EL.MRPTotalValue = 0.0
            Else
                EL.MRPTotalValue = txtMRPValueM.Text
            End If
            If txtDiscount.Text <> "" And txtDiscountAmt.Text <> "" Then
                lblRed.Text = "Please Enter Discount or Discount Amount."
                lblGreen.Text = ""
                Exit Sub
            End If
            '---------------------------------------------------------------------------------------------------------
            '-- this block is use to seperate the qty and free from total qty or Accepted qty.
            EL.Qty = EL.PurchaseDeal / (EL.PurchaseDeal + EL.PurchaseDeal1) * EL.QtyAccept
            EL.free = EL.PurchaseDeal1 / (EL.PurchaseDeal + EL.PurchaseDeal1) * EL.QtyAccept
            '----------------------------------------------------------------------------------------------
            EL.PRate = (EL.PurchRate * EL.ExchangeRate) + IIf(EL.PurchRateIV = "With Excise-I", EL.Excise, 0) * EL.ExchangeRate
            If EL.PRate - EL.Excise <> 0 Then
                If EL.Discount <> 0 Then
                    EL.Discountamt = ((EL.PRate - EL.Excise) * EL.Qty) * EL.Discount / 100
                ElseIf EL.Discountamt <> 0 Then
                    EL.Discount = (EL.Discountamt * 100) / ((EL.PRate - EL.Excise) * EL.Qty)
                Else
                    EL.Discount = 0
                    EL.Discountamt = 0
                End If
            End If
            EL.Amount = EL.Qty * EL.PurchRate
            If txtVAT.Text <> "0.0" Or txtVAT.Text = "0" Then
                EL.FinalAmount = EL.Amount + (EL.Amount * EL.VAT / 100)
            ElseIf txtCST.Text <> "0.0" Or txtCST.Text = "0" Then
                EL.FinalAmount = EL.Amount + (EL.Amount * EL.CST / 100)
            End If
            EL.Taxon = ddlTaxOn.SelectedItem.Text
            EL.TaxAB = ddlTaxAB.SelectedItem.Text
            EL.TaxPlan = ddlTaxPlan.SelectedValue

            If HIDFlatRate.Text = "" Then
                EL.FlatRate = 0
            Else
                EL.FlatRate = HIDFlatRate.Text
            End If

            HIDPurchaseInvoice.Text = HIDPURCHINVOICEID.Text
            If HIDPurchaseInvoice.Text = "" Then
                EL.HIDPurchaseInvoice = 0.0
            Else
                EL.HIDPurchaseInvoice = HIDPurchaseInvoice.Text
            End If

            '--------------------------------------------------------------------------------------------------'

            EL.sngPurchRate = EL.PurchRate - EL.Excise
            EL.sngTradeDiscount = EL.sngPurchRate * EL.Qty * EL.Discount / 100
            EL.sngFlatDiscount = (EL.sngPurchRate * EL.Qty - EL.sngTradeDiscount) * EL.FlatDiscount / 100

            EL.Amount = EL.PurchRate * EL.Qty
            Dim sngTax As Double
            If EL.Taxon = "MRP with tax on free goods" Then
                If EL.TaxAB = "B" Then
                    sngTax = EL.MRP * (EL.Qty + EL.free) * (EL.VAT + EL.CST) / 100
                Else
                    sngTax = EL.MRP * (EL.Qty + EL.free) * (EL.VAT + EL.CST) / 100
                End If

            ElseIf EL.Taxon = "MRP without tax on free goods" Then

                If EL.TaxAB = "B" Then
                    sngTax = EL.MRP * EL.Qty * (EL.VAT + EL.CST) / 100
                ElseIf EL.TaxAB = "A" Then
                    sngTax = EL.MRP * EL.Qty * (EL.VAT + EL.CST) / 100
                End If

            ElseIf EL.Taxon = "Purchase Price with tax on free goods" Then

                If EL.TaxAB = "B" Then

                    sngTax = EL.PurchRate * (EL.Qty + EL.free) * (EL.VAT + EL.CST) / 100

                ElseIf EL.TaxAB = "A" Then

                    sngTax = (EL.PurchRate * (EL.Qty + EL.free) - EL.sngTradeDiscount - EL.FlatDiscount) * (EL.VAT + EL.CST) / 100
                End If


            ElseIf EL.Taxon = "Purchase Price without tax on free goods" Then

                If EL.TaxAB = "B" Then

                    sngTax = EL.PurchRate * EL.Qty * (EL.VAT + EL.CST) / 100

                ElseIf EL.TaxAB = "A" Then

                    'sngTax = (EL.PurchRate * (EL.Qty + EL.free) - Discount - EL.sngTradeDiscount - EL.FlatDiscount) * (EL.VAT + EL.CST) / 100
                    sngTax = (EL.PurchRate * EL.Qty - EL.sngTradeDiscount - EL.FlatDiscount) * (EL.VAT + EL.CST) / 100
                End If
            End If
            EL.MRPValue = (EL.QtyAccept * EL.MRP)
            EL.VATRate = IIf(EL.VAT > 0, sngTax, 0)
            EL.CSTRate = IIf(EL.CST > 0, sngTax, 0)
            EL.FinalAmount = EL.Amount - EL.sngTradeDiscount - EL.sngFlatDiscount + sngTax
            EL.FlatRate = (EL.Amount - EL.sngTradeDiscount - EL.sngFlatDiscount + sngTax) / EL.QtyAccept

            '--------------------------------------------------------------------------------------------------'
            If btnAdddet.Text = "ADD" Then
                BLL.Insert(EL)
                lblGreen.Text = "Data Saved Successfully."
                lblRed.Text = ""
                ClearS()
                displayDetails()
                displaytotal()
            ElseIf btnAdddet.Text = "UPDATE" Then
                EL.id = ViewState("PRD_ID")
                BLL.UpdatePurchaseInvoiceDetails(EL)
                lblGreen.Text = "Data Updated Successfully."
                lblRed.Text = ""
                ClearS()
                btnAdddet.Text = "ADD"
                BtnViewDetails.Text = "VIEW"
                displayDetails()
                BtnClose.Enabled = True

            End If
        Else
            lblRed.Text = "Cannot update the posted record."
            lblGreen.Text = ""
        End If
    End Sub
    Public Sub ClearM()
        ddlSupplier.ClearSelection()
        txtPurchInvoiceM.Text = ""
        txtBalance.Text = ""
        txtCreditLimitM.Text = ""
        txtCreditPeroidM.Text = ""
        HIDPURCHINVOICEID.Text = ""
        txtInvoiceDateM.Text = Format(Today, "dd-MMM-yyyy")
        txtEntryDateM.Text = Format(Today, "dd-MMM-yyyy")
        ddlPaymentMethod.ClearSelection()
        txtGRN.Text = ""
        txtRemarksM.Text = ""
        txtFlatDiscM.Text = ""
        txtFlatDiscAmtM.Text = ""
        txtDiffAmtM.Text = ""
        txtTaxDiffM.Text = ""
        txtDiscDiffM.Text = ""
        txtExciseDiff.Text = ""
        txtRoundOffM.Text = ""
        ddlPOM.ClearSelection()
        txtDispatchM.Text = ""
        txtDispatchToM.Text = ""
        txtTransportation.Text = ""
        txtReceivedByM.Text = ""
        txtRecvdAddM.Text = ""
        txtPaymentDateM.Text = Format(Today, "dd-MMM-yyyy")
        txtTotalAmount.Text = ""
        txtTotalCSTAmt.Text = ""
        txtTotalDicAmt.Text = ""
        txtTotalDiffAmt.Text = ""
        txtTotalExcise.Text = ""
        txtTotalFinalAmt.Text = ""
        txtTotalFlatDiscAmt.Text = ""
        txtTotalGrandFinalAmt.Text = ""
        txtTotalRoundOff.Text = ""
        txtTotalVatAmt.Text = ""
        txtMRPValueM.Text = ""
        txtitemsM.Text = ""

        txtitemsM2.Text = ""
        txtMRPValueM2.Text = ""
        txtMiscExpM2.Text = ""
        txtFlatDiscM2.Text = ""
        txtFlatDiscAmtM2.Text = ""
        txtTaxDiffM2.Text = ""
        txtDiffAmtM2.Text = ""
        txtDiscDiffM2.Text = ""
        txtExciseDiff2.Text = ""
        txtRoundOffM2.Text = ""
        txtTotalAmount2.Text = ""
        txtTotalDicAmt2.Text = ""
        txtTotalFlatDiscAmt2.Text = ""
        txtTotalExcise2.Text = ""
        txtTotalVatAmt2.Text = ""
        txtTotalCSTAmt2.Text = ""
        txtTotalFinalAmt2.Text = ""
        txtTotalDiffAmt2.Text = ""
        txtTotalRoundOff2.Text = ""
        txtTotalGrandFinalAmt2.Text = ""


    End Sub
    Public Sub ClearS()
        DDLProduct.ClearSelection()
        txtBatch.Text = ""
        txtExpiryS.Text = ""
        txtPurchase.Text = ""
        txtPurchase1.Text = ""
        txtQtyAccept.Text = ""
        txtQtyrecvd.Text = ""
        txtExcise.Text = ""
        txtRemarks.Text = ""
        'ddlUnit.SelectedValue = 0
        'ddlMFG.SelectedValue = 0
        'ddlMKT.SelectedValue = 0
        txtPackingS.Text = ""
        txtSaleRate.Text = ""
        txtPurchRateS.Text = ""
        txtMRP.Text = ""
        txtDiscount.Text = ""
        txtDiscountAmt.Text = ""
        'ddlTaxOn.SelectedItem.Text = "Select"
        'ddlTaxAB.SelectedItem.Text = "Select"
        'ddlTaxPlan.SelectedValue = 0
        HIDFlatRate.Text = ""
        txtVAT.Text = ""
        txtCST.Text = ""
        txtTotalFinalAmt2.Text = ""
        txtTotalGrandFinalAmt2.Text = ""
        txtitemsM2.Text = ""
        txtVAT.Text = ""
        txtCST.Text = ""
        txtTotalRoundOff2.Text = ""
        txtTotalDiffAmt2.Text = ""
        txtRoundOffM2.Text = ""
        txtTotalDicAmt2.Text = ""
        
    End Sub
    Public Sub displayDetails()
        If HIDPurchaseInvoice.Text = "" Then
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
            GVPODetails.Visible = False
        Else
            Dim count As Integer = 0
            Dim totalqty As Integer = 0
            EL.PurchaseInvoiceID = HIDPurchaseInvoice.Text
            EL.TotalAmount = 0
            EL.TradeDiscAmount = 0
            EL.TotalExcise = 0
            EL.TotalCSTAmount = 0
            EL.TotalVATAmount = 0
            EL.TotalMRP = 0
            EL.MRPTotalValue = 0
            EL.TotalFinalAmount = 0
            dt = BLL.GetPurchaseInvoiceIDDetails(EL)
            If dt.Rows.Count > 0 Then
                GVPODetails.Enabled = True
                GVPODetails.Visible = True
                GVPODetails.DataSource = dt
                GVPODetails.DataBind()
                For Each rows As GridViewRow In GVPODetails.Rows
                    If CType(rows.FindControl("lblGVExpiry"), Label).Text = "01-Jan-1900" Then
                        CType(rows.FindControl("lblGVExpiry"), Label).Text = ""
                    End If
                Next
                For Each rows As GridViewRow In GVPODetails.Rows
                    count = count + 1
                    txtitemsM.Text = count
                    txtitemsM2.Text = count
                    If CType(rows.FindControl("lblamount"), Label).Text = "" Then
                        EL.TotalAmount = EL.TotalAmount + 0
                    Else
                        EL.TotalAmount = EL.TotalAmount + CType(rows.FindControl("lblamount"), Label).Text
                    End If

                    If CType(rows.FindControl("lblGVDiscountAmt"), Label).Text = "" Then
                        EL.TradeDiscAmount = EL.TradeDiscAmount + 0
                    Else
                        EL.TradeDiscAmount = EL.TradeDiscAmount + CType(rows.FindControl("lblGVDiscountAmt"), Label).Text
                    End If

                    If CType(rows.FindControl("lblExciseId"), Label).Text = "" Then
                        EL.TotalExcise = EL.TotalExcise + 0
                    Else
                        EL.TotalExcise = EL.TotalExcise + CType(rows.FindControl("lblExciseId"), Label).Text
                    End If
                    If CType(rows.FindControl("lblMRP"), Label).Text = "" Then
                        EL.TotalMRP = EL.TotalMRP + 0
                    Else
                        EL.TotalMRP = EL.TotalMRP + CType(rows.FindControl("lblMRP"), Label).Text
                    End If

                    If CType(rows.FindControl("lblGVVATAmount"), Label).Text = "" Then
                        EL.TotalVATAmount = EL.TotalVATAmount + 0
                    Else
                        EL.TotalVATAmount = EL.TotalVATAmount + CType(rows.FindControl("lblGVVATAmount"), Label).Text
                    End If

                    If CType(rows.FindControl("lblGVCSTAmount"), Label).Text = "" Then
                        EL.TotalCSTAmount = EL.TotalCSTAmount + 0
                    Else
                        EL.TotalCSTAmount = EL.TotalCSTAmount + CType(rows.FindControl("lblGVCSTAmount"), Label).Text
                    End If
                    If CType(rows.FindControl("lblGVFinalAmount"), Label).Text = "" Then
                        EL.TotalFinalAmount = EL.TotalFinalAmount + 0
                    Else
                        EL.TotalFinalAmount = EL.TotalFinalAmount + CType(rows.FindControl("lblGVFinalAmount"), Label).Text
                    End If

                    If CType(rows.FindControl("lblMRPValue"), Label).Text = "" Then
                        EL.MRPTotalValue = EL.MRPTotalValue + 0
                    Else
                        EL.MRPTotalValue = EL.MRPTotalValue + CType(rows.FindControl("lblMRPValue"), Label).Text
                    End If
                    If CType(rows.FindControl("lblQtyAccept"), Label).Text = "" Then
                        totalqty = totalqty + 0
                    Else
                        totalqty = totalqty + CType(rows.FindControl("lblQtyAccept"), Label).Text
                    End If
                Next
                txtTotalAmount.Text = EL.TotalAmount
                txtTotalAmount2.Text = EL.TotalAmount
                txtTotalDicAmt.Text = EL.TradeDiscAmount
                txtTotalDicAmt2.Text = EL.TradeDiscAmount
                txtTotalCSTAmt.Text = EL.TotalCSTAmount
                txtTotalCSTAmt2.Text = EL.TotalCSTAmount
                txtTotalVatAmt.Text = EL.TotalVATAmount
                txtTotalVatAmt2.Text = EL.TotalVATAmount
                txtTotalFinalAmt.Text = EL.TotalFinalAmount
                txtTotalFinalAmt2.Text = EL.TotalFinalAmount
                '  txtTotalExcise.Text = EL.ExciseDuty
                txtMRPValueM.Text = EL.MRPTotalValue
                txtMRPValueM2.Text = EL.MRPTotalValue
                txtTotalExcise.Text = EL.TotalExcise * totalqty
                txtTotalExcise2.Text = EL.TotalExcise * totalqty

            Else
                lblGreen.Text = ""
                lblRed.Text = "No records to display."
                GVPODetails.Visible = False
            End If
        End If
    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnViewDetails.Click
        If BtnViewDetails.Text = "VIEW" Then
            EL.id = 0

            lblGreen.Text = ""
            lblRed.Text = ""
            ViewState("PageIndex") = 0
            displayDetails()
            'ClearS()

        Else
            EL.id = 0
            displayDetails()
            lblGreen.Text = ""
            lblRed.Text = ""
            BtnClose.Enabled = True
            GVPODetails.PageIndex = ViewState("PageIndex")
            btnAdddet.Text = "ADD"
            BtnViewDetails.Text = "VIEW"
            ClearS()
        End If
    End Sub
    Protected Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
        Dim MC1 As New MultiCurrencyManager
        Dim MCD As MultiCurrency = MC1.GetMulticurrencyRate(CInt(IIf(ddlCurrency.SelectedValue.ToString = "", 0, ddlCurrency.SelectedValue.ToString)))
        txtExRate.Text = MCD.BuyConversionRate
    End Sub
    Protected Sub GVPODetails_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVPODetails.PageIndexChanging
        GVPODetails.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVPODetails.PageIndex
        displayDetails()
        GVPODetails.Visible = True
        lblRed.Text = " "
        lblGreen.Text = " "
    End Sub
    Protected Sub GVPODetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVPODetails.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If ViewState("PostStatus") <> "Posted" Then
                EL.id = CType(GVPODetails.Rows(e.RowIndex).FindControl("ID"), HiddenField).Value
                BLL.DeletePurchaseInvoiceS(EL)
                GVPODetails.DataBind()
                'lblGreen.Visible = True
                lblRed.Text = " "
                lblGreen.Text = "Data Deleted Successfully."
                ClearS()
                GVPODetails.PageIndex = ViewState("PageIndex")
                'EL.PID = ViewState(" HiddenField1")
                'EL.id = 0
                displayDetails()
                'dt = BLL.GetPurchaseInvoiceIDDetails(EL)
                'GVPODetails.Enabled = True
                'GVPODetails.Visible = True
                'GVPODetails.DataSource = dt
                'GVPODetails.DataBind()
            Else
                lblRed.Text = "Cannot delete the posted record.."
                lblGreen.Text = ""
            End If
        Else
            lblRedM.Text = "You do not belong to this branch, Cannot delete data."
            lblGreenM.Text = ""
        End If
    End Sub
    Protected Sub GVPODetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVPODetails.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblRed.Text = ""
            lblGreen.Text = ""
            Try
                ViewState("PRD_ID") = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("ID"), HiddenField).Value
                ddlCurrency.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("HIDCurrency"), HiddenField).Value
                txtExRate.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("HIDExRate"), HiddenField).Value
                txtExpiryS.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVExpiry"), Label).Text
                If CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVExpiry"), Label).Text = "01-Jan-3000" Then
                    txtExpiryS.Text = ""
                Else
                    txtExpiryS.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVExpiry"), Label).Text
                End If
                DDLProduct.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblProductID"), HiddenField).Value
                txtBatch.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblBatchID"), Label).Text

                HIDBatch.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVBatchID"), Label).Text
                txtPurchase.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVQty"), Label).Text
                txtPurchase1.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVFree"), Label).Text
                txtQtyrecvd.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblQtyRecvdID"), Label).Text
                txtQtyAccept.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblQtyAccept"), Label).Text
                ddlUnitS.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblUnitId"), Label).Text
                txtPackingS.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVPacking"), Label).Text
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
                txtRemarks.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVRemarks"), Label).Text
                txtPurchRateS.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblPRate"), Label).Text
                txtExcise.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblExciseId"), Label).Text
                txtSaleRate.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblSrate"), Label).Text
                txtMRP.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblMRP"), Label).Text
                txtDiscount.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVDiscount"), Label).Text
                txtDiscountAmt.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVDiscountAmt"), Label).Text
                If txtDiscountAmt.Text = "0.00" Then
                    txtDiscountAmt.Text = ""
                End If
                ddlTaxOn.SelectedItem.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVTaxon"), Label).Text
                ddlTaxAB.SelectedItem.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVTaxAB"), Label).Text
                If CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVTax"), Label).Text = "" Then
                    ddlTaxPlan.SelectedValue = 0
                Else
                    ddlTaxPlan.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblGVTax"), Label).Text
                End If
                txtVAT.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblVat"), Label).Text
                txtCST.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblCST"), Label).Text
                dt = Mfg_DLPurchaseInvoice.filltax(EL)
                If dt.Rows.Count > 0 Then
                    txtCST.Text = dt.Rows(0).Item("CST").ToString
                    txtVAT.Text = dt.Rows(0).Item("State_VAT").ToString
                End If
                EL.id = ViewState("PRD_ID")
                dt = BLL.GetPurchaseInvoiceDetails(EL)
                GVPODetails.DataSource = dt
                GVPODetails.DataBind()
                For Each rows As GridViewRow In GVPODetails.Rows
                    If CType(rows.FindControl("lblGVExpiry"), Label).Text = "01-Jan-1900" Then
                        CType(rows.FindControl("lblGVExpiry"), Label).Text = ""
                    End If
                Next
                GVPODetails.Enabled = False
                GVPODetails.Visible = True
                BtnClose.Enabled = False
                btnAdddet.Text = "UPDATE"
                BtnViewDetails.Text = "BACK"
            Catch ex As Exception
                lblRed.Text = "Enter Correct Data."
                lblGreen.Text = ""
            End Try
        Else
            lblRed.Text = "You do not belong to this branch, Cannot edit data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub GridPurchaseInvoiceM_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridPurchaseInvoiceM.PageIndexChanging
        GridPurchaseInvoiceM.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridPurchaseInvoiceM.PageIndex
        display()
        GridPurchaseInvoiceM.Visible = True
        lblRedM.Text = " "
        lblGreenM.Text = " "

    End Sub

    Protected Sub GridPurchaseInvoiceM_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridPurchaseInvoiceM.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("PostStatus") = CType(GridPurchaseInvoiceM.Rows(e.RowIndex).FindControl("lblGVPost"), Label).Text
            If ViewState("PostStatus") <> "Posted" Then
                EL.PID = CType(GridPurchaseInvoiceM.Rows(e.RowIndex).FindControl("ID"), HiddenField).Value
                BLL.DeletePurchaseInvoice(EL)
                GridPurchaseInvoiceM.DataBind()
                'lblGreen.Visible = True
                lblRedM.Text = " "
                lblGreenM.Text = "Data Deleted Successfully."
                ClearM()
                GridPurchaseInvoiceM.PageIndex = ViewState("PageIndex")
                'EL.PID = ViewState(" HiddenField1")
                display()
            Else
                lblRedM.Text = "Cannot delete the posted record."
                lblGreenM.Text = ""
                ViewState("PostStatus") = ""
            End If

        Else
            lblRedM.Text = "You do not belong to this branch, Cannot delete data."
            lblGreenM.Text = ""
        End If
    End Sub

    Protected Sub GridPurchaseInvoiceM_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridPurchaseInvoiceM.RowEditing

        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("PostStatus") = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVPost"), Label).Text
            lblRedM.Text = ""
            lblGreenM.Text = ""
            ViewState("PurchMain") = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("ID"), HiddenField).Value
            ddlSupplier.SelectedValue = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblSupppId"), Label).Text
            txtPurchInvoiceM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblPurchInvNo"), Label).Text
            HIDPURCHINVOICEID.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblPurchInvId"), Label).Text
            txtInvoiceDateM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblInvoiceDateGV"), Label).Text
            txtEntryDateM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblEntryDateGV"), Label).Text
            ddlPaymentMethod.SelectedValue = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblPaymentTypeGV"), Label).Text
            txtGRN.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGRNGV"), Label).Text
            txtRemarksM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVRemarksM"), Label).Text
            txtFlatDiscM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVflatDisc"), Label).Text
            'txtFlatDiscAmtM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVFlatDiscAmt"), Label).Text
            txtDiffAmtM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVDiffAmt"), Label).Text
            txtTaxDiffM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTaxDiff"), Label).Text
            txtDiscDiffM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVDiscountDiff"), Label).Text
            txtExciseDiff.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVExciseDiff"), Label).Text
            txtRoundOffM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblRoundOFFGV"), Label).Text
            '---------------------------------------------------------------------------------------------------
            'Details Tab details
            txtFlatDiscM2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVflatDisc"), Label).Text
            'txtFlatDiscAmtM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVFlatDiscAmt"), Label).Text
            txtDiffAmtM2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVDiffAmt"), Label).Text
            txtTaxDiffM2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTaxDiff"), Label).Text
            txtDiscDiffM2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVDiscountDiff"), Label).Text
            txtExciseDiff2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVExciseDiff"), Label).Text
            txtRoundOffM2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblRoundOFFGV"), Label).Text
            '---------------------------------------------------------------------------------------------------------------------------------
            If CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVPOM"), Label).Text = "" Then
                ddlPOM.SelectedValue = 0
            Else

                ddlPOM.SelectedValue = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVPOM"), Label).Text
            End If
            txtDispatchM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVDispatchFrom"), Label).Text
            txtDispatchToM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVDispatchTo"), Label).Text
            ddlShipment.SelectedValue = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTransporation"), Label).Text
            txtTransportation.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTransportNo"), Label).Text
            txtReceivedByM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVRecievedBy"), Label).Text
            txtRecvdAddM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVRecievedAddress"), Label).Text
            txtPaymentDateM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVPaymentDate"), Label).Text

            txtTotalAmount.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalAmountM"), Label).Text
            txtTotalDicAmt.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalDiscountAmt"), Label).Text
            txtTotalFlatDiscAmt.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVFlatDiscAmt"), Label).Text
            txtTotalExcise.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalExciseDuty"), Label).Text
            txtTotalVatAmt.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalVATAmount"), Label).Text
            txtTotalCSTAmt.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalCSTAmount"), Label).Text
            txtTotalFinalAmt.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalFinalAmount"), Label).Text
            txtTotalRoundOff.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblRoundOFFGV"), Label).Text
            txtTotalGrandFinalAmt.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalGrandFinalAmt"), Label).Text
            txtTotalDiffAmt.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVDiffAmt"), Label).Text

            txtTotalAmount2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalAmountM"), Label).Text
            txtTotalDicAmt2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalDiscountAmt"), Label).Text
            txtTotalFlatDiscAmt2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVFlatDiscAmt"), Label).Text
            txtTotalExcise2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalExciseDuty"), Label).Text
            txtTotalVatAmt2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalVATAmount"), Label).Text
            txtTotalCSTAmt2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalCSTAmount"), Label).Text
            txtTotalFinalAmt2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalFinalAmount"), Label).Text
            txtTotalRoundOff2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblRoundOFFGV"), Label).Text
            txtTotalGrandFinalAmt2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalGrandFinalAmt"), Label).Text
            txtTotalDiffAmt2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVDiffAmt"), Label).Text


            txtMRPValueM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalMRPValue"), Label).Text
            txtMRPValueM2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVTotalMRPValue"), Label).Text

            If txtPaymentDateM.Text = "01-Jan-1900" Then
                txtPaymentDateM.Text = ""
            End If
            ' txtFlatDiscAmtM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVFlatDiscAmtRATE"), Label).Text
            txtTotalFlatDiscAmt.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVFlatDiscAmtRATE"), Label).Text
            txtFlatDiscAmtM.Text = txtTotalFlatDiscAmt.Text
            txtTotalFlatDiscAmt2.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVFlatDiscAmtRATE"), Label).Text
            txtFlatDiscAmtM2.Text = txtTotalFlatDiscAmt.Text
            ddlIVType.SelectedValue = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblInvType"), Label).Text
            If txtFlatDiscAmtM.Text = "0.00" Then
                txtFlatDiscAmtM.Text = ""
            End If
            EL.Supplier = ddlSupplier.SelectedValue
            dt = Mfg_DLPurchaseInvoice.GetSupplierAutoFill(EL)
            If dt.Rows.Count > 0 Then
                'ViewState("ProductAutoNo") = dt.Rows(0).Item("Opening_Balance_CR").ToString
                If dt.Rows(0).Item("Opening_Balance_CR").ToString = "" Then
                    txtBalance.Text = 0
                Else
                    txtBalance.Text = Format(dt.Rows(0).Item("Opening_Balance_CR"), "0.00")
                End If
                If dt.Rows(0).Item("Credit_Limit").ToString = "" Then
                    txtCreditLimitM.Text = 0
                Else
                    txtCreditLimitM.Text = Format(dt.Rows(0).Item("Credit_Limit"), "0.00")
                End If
                If dt.Rows(0).Item("Credit_Period").ToString = "" Then
                    txtCreditPeroidM.Text = ""
                Else
                    txtCreditPeroidM.Text = Format(dt.Rows(0).Item("Credit_Period"))
                End If
            End If
            HIDPurchaseInvoice.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblPurchInvId"), Label).Text
            EL.PID = ViewState("PurchMain")
            dt = BLL.GetPurchaseInvoiceM(EL)
            GridPurchaseInvoiceM.DataSource = dt
            GridPurchaseInvoiceM.DataBind()
            For Each rows As GridViewRow In GridPurchaseInvoiceM.Rows
                If CType(rows.FindControl("lblInvoiceDateGV"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblInvoiceDateGV"), Label).Text = ""
                End If
            Next
            For Each rows As GridViewRow In GridPurchaseInvoiceM.Rows
                If CType(rows.FindControl("lblEntryDateGV"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblEntryDateGV"), Label).Text = ""
                End If
            Next

            GridPurchaseInvoiceM.Enabled = False
            GridPurchaseInvoiceM.Visible = True
            btnAdd.Text = "UPDATE"
            BtnView.Text = "BACK"
            If ViewState("PostStatus") = "Posted" Then

                btnAdddet.Enabled = False
            End If
        Else
            lblGreenM.Text = "You do not belong to this branch, Cannot edit data."
            lblRedM.Text = ""
        End If
    End Sub
    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Try
            Dim id As String = ""
            Dim check As String = ""

            Dim count As Integer
            count = 0
            For Each grid As GridViewRow In GridPurchaseInvoiceM.Rows
                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    EL.Supplier = CType(grid.FindControl("lblSupppId"), Label).Text
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
                lblRedM.Text = "Select Atleast One Record to Post."
                lblGreenM.Text = ""
            Else

                EL.ChkID = id
                If ddlIVType.SelectedValue = "CASH Invoice" And ddlIVType.SelectedValue = "Cash Tax Invoice" Then
                    BLL.PaymentRecPaidPurchaseInvoice(EL)
                Else
                    BLL.PaymentRecPaidPurchaseInvoice1(EL)
                End If
                BLL.PostPurchaseInvoice(EL)
                lblGreenM.Text = "Record posted successfully."
                lblRedM.Text = ""
                display()
                'dt = DL.GetChkID(EL)
                'EL.PurchaseInvoiceID = dt.Rows(0).Item("Purchase_Invoice_ID")

                'dt = DL.GetPurchaseInvoiceIDDetails(EL)
                'EL.HIDPurchaseInvoice = dt.Rows(0).Item("Purchase_Invoice_ID")
                'BLL.InsertToPost(EL)
            End If

        Catch ex As Exception
            lblRedM.Text = "Record Not Posted."
            lblGreenM.Text = ""
        End Try

    End Sub
    Sub CheckAll()
        If CType(GridPurchaseInvoiceM.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GridPurchaseInvoiceM.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GridPurchaseInvoiceM.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If ddlSupplier.SelectedValue <> 0 Then

            TabContainer1.ActiveTab = TabPanel2
            'TabPanel2.Enabled = True
            'TabPanel1.Enabled = False
            RbProduct.Focus()
            lblGreenM.Text = ""
            lblRedM.Text = ""
        Else
            lblRedM.Text = "Please Select Supplier First."
            lblGreenM.Text = ""
            TabPanel2.Enabled = False
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'TabPanel2.Enabled = False
            lblGreenM.Text = ""
            lblRedM.Text = ""
            txtInvoiceDateM.Text = Format(Today, "dd-MMM-yyyy")
            txtEntryDateM.Text = Format(Today, "dd-MMM-yyyy")
            txtExRate.Text = "1.00"
        End If
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        TabContainer1.ActiveTab = TabPanel1
        TabPanel1.Enabled = True
        GVPODetails.Visible = "false"
        lblRed.Text = ""
        lblGreen.Text = ""
        txtFlatDiscM.Text = txtFlatDiscM2.Text
        txtFlatDiscAmtM.Text = txtFlatDiscAmtM2.Text
        'txtFlatDiscAmtM.Text = CType(GridPurchaseInvoiceM.Rows(e.NewEditIndex).FindControl("lblGVFlatDiscAmt"), Label).Text
        txtDiffAmtM.Text = txtDiffAmtM2.Text
        txtTaxDiffM.Text = txtTaxDiffM2.Text
        txtDiscDiffM.Text = txtDiscDiffM2.Text
        txtExciseDiff.Text = txtExciseDiff2.Text
        txtRoundOffM.Text = txtRoundOffM2.Text

        'TabPanel2.Enabled = False
    End Sub

    Protected Sub ddlTaxPlan_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTaxPlan.SelectedIndexChanged
        EL.TaxPlan = ddlTaxPlan.SelectedValue
        dt = Mfg_DLPurchaseInvoice.filltax(EL)
        If dt.Rows.Count > 0 Then
            txtCST.Text = dt.Rows(0).Item("CST").ToString
            txtVAT.Text = dt.Rows(0).Item("State_VAT").ToString
        End If
    End Sub

    Protected Sub btnReceipt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceipt.Click

        Dim check2 As String
        Dim check As String = ""
        Dim id As String = ""
        Dim Count1 As Integer = 0
        Dim checkedCount As Integer = 0
        For Each Grid As GridViewRow In GridPurchaseInvoiceM.Rows
            If CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                checkedCount = checkedCount + 1
            End If
        Next
        If checkedCount = 0 Then
            lblRedM.Text = "Please select the records to print."
            lblGreenM.Text = ""
            Exit Sub
        End If

        For Each Grid As GridViewRow In GridPurchaseInvoiceM.Rows
            check2 = CType(Grid.FindControl("lblGVPost"), Label).Text
            If check2 = "Posted" Then

                If CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(Grid.FindControl("lblPurchInvId"), Label).Text
                    id = check + "," + id
                    Count1 = Count1 + 1
                End If
            End If
        Next


        If id = "" Then
            id = 0
        Else
            id = Left(id, id.Length - 1)
        End If
        If id = 0 Then
            lblRedM.Text = "Please Post the records to print."
        End If

        If Count1 > 0 Then

            Dim qrystring As String = "Mfg_Rpt_PurchaseInvoice.aspx?" & "&Id=" & id
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblGreenM.Text = ""
            lblRedM.Text = ""

        End If


    End Sub

    Protected Sub btngrn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngrn.Click

        Dim check2 As String
        Dim check As String = ""
        Dim id As String = ""
        Dim Count1 As Integer = 0
        Dim checkedCount As Integer = 0
        For Each Grid As GridViewRow In GridPurchaseInvoiceM.Rows
            If CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                checkedCount = checkedCount + 1
            End If
        Next
        If checkedCount = 0 Then
            lblRedM.Text = "Please select the records to print."
            lblGreenM.Text = ""
            Exit Sub
        End If

        For Each Grid As GridViewRow In GridPurchaseInvoiceM.Rows

            check2 = CType(Grid.FindControl("lblGVPost"), Label).Text
            If check2 = "Posted" Then

                If CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(Grid.FindControl("lblPurchInvId"), Label).Text
                    id = check + "," + id
                    Count1 = Count1 + 1
                End If
            End If
        Next
        If id = "" Then
            id = 0
        Else
            id = Left(id, id.Length - 1)
        End If
        If id = 0 Then
            lblRedM.Text = "Please Post the records to print GRN."
        End If


        If Count1 > 0 Then

            Dim qrystring As String = "Mfg_Rpt_PurchaseInvoiceGRN.aspx?" & "&Id=" & id
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblGreenM.Text = ""
            lblRedM.Text = ""
        End If

       
    End Sub

End Class
