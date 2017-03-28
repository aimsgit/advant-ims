Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic

Imports Microsoft.Reporting.WebForms


Partial Class Mfg_frmSaleInvoiceNew
    Inherits BasePage
    Dim EL As New Mfg_ELSaleInvoice
    Dim BL As New Mfg_BLSaleInvoice
    Dim dt As New DataTable
    Dim dt1, dt2 As New DataTable
    Dim DL As New MfgSaleInvoiceDL
    Dim temp As Integer

    Protected Sub btnADDSaleInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnADDSaleInvoice.Click
        Try

            'TabPanel3.Enabled = False
            'TabPanel1.Enabled = True
            If (Session("BranchCode") = Session("ParentBranch")) Then
                EL.Buyer_ID = DDlBuyer.SelectedValue
                If txtSaleInvNo.Text = "" Then
                    EL.Sale_Invoice_No = ""
                Else
                    EL.Sale_Invoice_No = txtSaleInvNo.Text
                End If

                EL.Invoice_Date = txtInvDate.Text

                EL.Invoice_Type = ddlIVType.SelectedValue
                EL.SE = DdlSE.SelectedValue
                EL.Payment_Method = ddlPaymentMethod.SelectedValue
                EL.Bank = ddlBank.SelectedValue
                EL.Branch = txtBranch.Text
                If txtFlatDiscAmt.Text = "" Then
                    EL.Flat_disc_Amt = 0
                Else
                    EL.Flat_disc_Amt = txtFlatDiscAmt.Text
                End If

                EL.Entry_Date = txtEntryDate.Text
                EL.SO_NO = ddlSO.SelectedValue
                EL.Transaction_Type = ddlTransaction.SelectedValue
                If txtFlatDisc.Text = "" Then
                    EL.Flat_Disc = 0
                Else
                    EL.Flat_Disc = txtFlatDisc.Text
                End If
                If txtCurRecAmt.Text = "" Then
                    EL.Curr_rec_Amt = 0
                Else
                    EL.Curr_rec_Amt = txtCurRecAmt.Text
                End If
                If txtNoOfItem.Text = "" Then
                    EL.NO_Of_Item = 0
                Else
                    EL.NO_Of_Item = txtNoOfItem.Text
                End If
                If txtFreightChrg.Text = "" Then
                    EL.Freight_charges = 0
                Else
                    EL.Freight_charges = txtFreightChrg.Text
                End If
                If txtCreditNote.Text = "" Then
                    EL.Credit = 0
                Else
                    EL.Credit = txtCreditNote.Text
                End If
                If txtDebitNote.Text = "" Then
                    EL.Debit = 0
                Else
                    EL.Debit = txtDebitNote.Text
                End If
                'If txtCreditNote.Text = "" And txtDebitNote.Text = "" Then
                '    lblErrorMsg.Text = "Please Enter Either Credit or Debit Note."
                '    lblMsg.Text = ""
                '    Exit Sub
                'End If
                If txtDd.Text = "" Then
                    EL.Cheque_No = 0
                Else
                    EL.Cheque_No = txtDd.Text
                End If
                EL.Remarks = txtRemarks.Text
                If txtchallan.Text = "" Then
                    EL.Challan_NO = 0
                Else
                    EL.Challan_NO = txtchallan.Text
                End If

                EL.Note = txtRemarksodr.Text
                If txtTransport.Text = "" Then
                    EL.Transport_NO = 0
                Else
                    EL.Transport_NO = txtTransport.Text
                End If
                If txtTotalAmount.Text = "" Then
                    EL.TotalAmount = 0
                Else
                    EL.TotalAmount = txtTotalAmount.Text

                End If

                If txtTotalDicAmt.Text = "" Then
                    EL.TradeDiscAmount = 0
                Else
                    EL.TradeDiscAmount = txtTotalDicAmt.Text
                End If

                If txtTotalFinalAmt.Text = "" Then
                    EL.TotalFinalAmount = 0
                Else
                    EL.TotalFinalAmount = txtTotalFinalAmt.Text
                End If

                If txtvatAmt.Text = "" Then
                    EL.TotalVATAmount = 0
                Else
                    EL.TotalVATAmount = txtvatAmt.Text
                End If

                If txtTotalcstAmt.Text = "" Then
                    EL.TotalCSTValue = 0
                Else
                    EL.TotalCSTValue = txtTotalcstAmt.Text
                End If

                If txtafc.Text = "" Then
                    EL.AddFriCharges = 0
                Else
                    EL.AddFriCharges = txtafc.Text
                End If
                'txtafc.Text = EL.TotalExcise * EL.TotalMRP

                If txtTotalFinalAmt.Text = "" Then
                    EL.TotalFinalAmount = 0
                Else
                    EL.TotalFinalAmount = txtTotalFinalAmt.Text
                End If
                If txtTotalRoundOff.Text = "" Then
                    txtTotalRoundOff.Text = "0.00"
                Else
                    EL.RoundOff = txtTotalRoundOff.Text
                End If

                EL.RoundOff = IIf(txtTotalRoundOff.Text = "", 0, CDbl(txtTotalRoundOff.Text))
                EL.RoundOff = txtTotalRoundOff.Text
                If txtProfitLoss.Text = "" Then
                    EL.profitLoss = 0
                Else
                    EL.profitLoss = txtProfitLoss.Text
                End If
                txtTotalGrandFinalAmt.Text = EL.Freight_charges + EL.RoundOff + EL.TotalFinalAmount
                txtTotalGrandFinalAmt.Text = IIf(txtFreightChrg.Text = "", 0, CDbl(EL.Freight_charges)) + IIf(txtTotalRoundOff.Text = "", 0, CDbl(EL.RoundOff)) + IIf(txtTotalFinalAmt.Text = "", 0, CDbl(EL.TotalFinalAmount))
                EL.TotalGrandFinalAmt = txtTotalGrandFinalAmt.Text
                EL.Sent_By = txtSentBy.Text
                EL.Dispatched_From = txtdispatchdfrom.Text
                EL.Dispatched_To = txtDispatchdTo.Text


                EL.Transportation_Mode = 0
                If txtReceivedDate.Text = "" Then
                    EL.Received_Date = "01-Jan-3000"
                Else
                    EL.Received_Date = txtReceivedDate.Text
                End If

                If HidInvoice.Text = "" Then
                    EL.InvoiceID = 0
                Else
                    EL.InvoiceID = HidInvoice.Text
                End If
                EL.Id = ViewState("SaleMain_ID")
                dt = BL.CheckDuplicateSaleInvoice(EL)
                If dt.Rows.Count > 0 Then
                    lblErrorMsg.Text = "Data already exists."
                    lblMsg.Text = ""
                ElseIf btnADDSaleInvoice.Text = "UPDATE" Then

                    EL.Id = ViewState("SaleMain_ID")
                    BL.UpdateSaleInvoice(EL)
                    lblErrorMsg.Text = ""
                    btnADDSaleInvoice.Text = "ADD"
                    btnViewSaleInvoice.Text = "VIEW"
                    lblMsg.Text = "Data Updated Successfully."
                    clear1()
                    GvSaleInvoice.PageIndex = ViewState("PageIndex")
                    DisplaySaleInvoice()
                    ddlPaymentMethod.Items.Clear()
                    ddlPaymentMethod.DataSourceID = "ObjPaymentMethod"
                    ddlPaymentMethod.DataBind()
                    ddlBank.Items.Clear()
                    ddlBank.DataSourceID = "ObjBank"
                    ddlBank.DataBind()


                ElseIf btnADDSaleInvoice.Text = "ADD" Then
                    If HidMInvoice.Text <> "0" And HidMInvoice.Text <> "" Then
                        EL.Id = 0
                        BL.InsertSaleInvoice(EL)
                        lblErrorMsg.Text = ""
                        btnADDSaleInvoice.Text = "ADD"
                        lblMsg.Text = "Data Saved successfully."
                        clear1()
                        ViewState("PageIndex") = 0
                        GvSaleInvoice.PageIndex = 0
                        'TabPanel1.Visible = True
                        panel1.Visible = True
                        GvSaleInvoice.Visible = True
                        DisplaySaleInvoice()
                        'ddlPaymentMethod.Items.Clear()
                        'ddlPaymentMethod.DataSourceID = "ObjPaymentMethod"
                        'ddlPaymentMethod.DataBind()
                        'ddlBank.Items.Clear()
                        'ddlBank.DataSourceID = "ObjBank"
                        'ddlBank.DataBind()

                    Else
                        lblErrorMsg.Text = "First Add SIN Details."
                        lblMsg.Text = ""
                    End If
                End If


            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
                lblMsg.Text = ""
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Date is not valid."
        End Try
    End Sub
    Sub DisplaySaleInvoice()
        'TabPanel3.Enabled = False
        'TabPanel3.Enabled = True
        Dim dt As New DataTable
        EL.Id = 0
        dt = BL.GetSaleInvoice(EL)
        GvSaleInvoice.DataSource = dt
        GvSaleInvoice.DataBind()
        GvSaleInvoice.Visible = True
        GvSaleInvoice.Enabled = True
        If dt.Rows.Count = 0 Then
            lblMsg.Text = ""
            lblErrorMsg.Text = "No records to display."
            'msginfo.Visible = True
        End If
    End Sub

    Protected Sub btnViewSaleInvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewSaleInvoice.Click
        LinkButton1.Focus()
        'TabPanel3.Enabled = False
        'TabPanel1.Enabled = True
        If btnViewSaleInvoice.Text = "VIEW" Then
            GvSaleInvoice.Enabled = True
            'Details.Visible = False
            lblMsg.Text = " "
            lblErrorMsg.Text = " "
            EL.Id = 0
            ViewState("PageIndex") = 0
            GvSaleInvoice.PageIndex = 0
            DisplaySaleInvoice()
            'TabPanel1.Visible = True
            panel1.Visible = True
            GvSaleInvoice.Visible = True
            'clear()
        ElseIf btnViewSaleInvoice.Text = "BACK" Then
            GvSaleInvoice.Enabled = True
            lblMsg.Text = " "
            lblErrorMsg.Text = " "
            btnADDSaleInvoice.Text = "ADD"
            btnViewSaleInvoice.Text = "VIEW"
            'btnPost.Enabled = True
            'HidInvoice.Text = ""
            clear1()
            'TabPanel1.Visible = True
            panel1.Visible = True
            'Details.Visible = False
            GvSaleInvoice.PageIndex = ViewState("PageIndex")
            DisplaySaleInvoice()
        End If
    End Sub

    Protected Sub GvSaleInvoice_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvSaleInvoice.RowDeleting
        'TabPanel3.Enabled = False
        'TabPanel1.Enabled = True
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Id = CType(GvSaleInvoice.Rows(e.RowIndex).FindControl("SSID"), HiddenField).Value
            BL.DeleteSaleInvoice(EL)
            GvSaleInvoice.DataBind()
            lblErrorMsg.Text = ""
            lblMsg.Text = "Data Deleted Successfully."
            GvSaleInvoice.PageIndex = ViewState("PageIndex")
            DisplaySaleInvoice()
        Else
            lblMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblErrorMsg.Text = ""
        End If
    End Sub
    Sub clear1()
        txtSaleInvNo.Text = ""
        txtInvDate.Text = ""
        txtEntryDate.Text = ""
        txtchallan.Text = ""
        txtBranch.Text = ""
        txtFlatDiscAmt.Text = ""
        txtMRP.Text = ""
        txtDd.Text = ""
        txtRemarks.Text = ""
        txtRemarksodr.Text = ""
        txtTransport.Text = ""
        txtSentBy.Text = ""
        txtFlatDisc.Text = ""
        txtCurRecAmt.Text = ""
        txtNoOfItem.Text = ""
        txtFreightChrg.Text = ""
        txtCreditNote.Text = ""
        txtDebitNote.Text = ""
        txtdispatchdfrom.Text = ""
        txtDispatchdTo.Text = ""
        txtReceivdAddress.Text = ""
        txtTransport.Text = ""
        txtReceivedDate.Text = ""
        txtTotalAmount.Text = ""
        txtTotalDicAmt.Text = ""
        txtFlatDiscAmt.Text = ""
        txtvatAmt.Text = ""
        txtTotalcstAmt.Text = ""
        txtafc.Text = ""
        txtTotalFinalAmt.Text = ""
        txtTotalRoundOff.Text = ""
        txtProfitLoss.Text = ""
        txtTotalGrandFinalAmt.Text = ""
        txtTotalAmount1.Text = ""
        txtNoItems.Text = ""
        txtTotalDiscAmount.Text = ""
        txtTotalQtyPOS.Text = ""

    End Sub
    Protected Sub GvSaleInvoice_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvSaleInvoice.RowEditing
        'TabPanel3.Enabled = False
        'TabPanel1.Enabled = True
        If (Session("BranchCode") = Session("ParentBranch")) Then

            lblMsg.Text = ""
            lblErrorMsg.Text = ""
            btnADDSaleInvoice.Text = "UPDATE"
            btnADDSaleInvoice.Enabled = True
            btnViewSaleInvoice.Visible = True
            btnViewSaleInvoice.Text = "BACK"
            GvSaleInvoice.Visible = True
            ViewState("SaleMain_ID") = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("SSID"), HiddenField).Value
            DDlBuyer.SelectedValue = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblBuyer"), Label).Text
            txtSaleInvNo.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblSaleInvoiceNo"), Label).Text
            txtInvDate.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblInvoiceDate"), Label).Text
            ddlIVType.SelectedValue = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblInvoiceType"), Label).Text
            DdlSE.SelectedValue = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblSE"), Label).Text
            'If CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("IDPaymentMethod"), HiddenField).Value = "" Then


            '    ddlPaymentMethod.Items.Clear()
            '    ddlPaymentMethod.DataSourceID = "ObjPaymentMethod"
            '    ddlPaymentMethod.DataBind()
            'Else
            'EL.Id = ddlPaymentMethod.SelectedValue
            ddlPaymentMethod.SelectedValue = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("IDPaymentMethod"), Label).Text

            'End If
            txtDd.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblChequeNo"), Label).Text
            If CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblBank"), HiddenField).Value = "" Then
                ddlBank.Items.Clear()
                ddlBank.DataSourceID = "ObjBank"
                ddlBank.DataBind()
            Else
                ddlBank.SelectedValue = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblBank"), HiddenField).Value
            End If

            txtBranch.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("HIDBranch"), HiddenField).Value
            txtFlatDiscAmt.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("HIDField1"), HiddenField).Value
            txtEntryDate.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblEntryDate1"), Label).Text
            ddlSO.SelectedValue = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblSOID"), Label).Text
            ddlTransaction.SelectedValue = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblTransactionType"), Label).Text
            txtFlatDisc.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblFlatDiscountSale"), Label).Text
            txtCurRecAmt.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblCurrReceivedAmt"), Label).Text
            txtFreightChrg.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("HFreightCharge"), HiddenField).Value
            txtCreditNote.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblMultiDiscount"), Label).Text
            txtDebitNote.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("HidReceivedAmount"), HiddenField).Value
            txtRemarks.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblremarks1"), Label).Text
            txtchallan.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("HidChallanNo"), HiddenField).Value
            txtRemarksodr.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("HidNote"), HiddenField).Value
            txtTransport.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("HidTransportNo"), HiddenField).Value
            txtSentBy.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblSentBy"), Label).Text
            txtdispatchdfrom.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("HidShipmentFrom"), HiddenField).Value
            txtDispatchdTo.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("HidShipmentTo"), HiddenField).Value
            txtReceivdAddress.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("HidShipAddress"), HiddenField).Value
            DdlTransportBy.SelectedValue = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblShipMethod"), Label).Text
            txtReceivedDate.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblReceiptDate"), Label).Text
            txtTotalAmount.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblTotalAmt"), Label).Text
            txtTotalDicAmt.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblTradeDiscAmt"), Label).Text
            txtFlatDiscAmt.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblFlatDiscAmt"), Label).Text
            txtvatAmt.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblVatAmt"), Label).Text
            txtTotalcstAmt.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblCSTAmt"), Label).Text
            txtafc.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblAddFC"), Label).Text
            txtTotalFinalAmt.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblTotFinalAmt"), Label).Text
            txtTotalRoundOff.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblRoundOff"), Label).Text
            txtProfitLoss.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblProfitLoss"), Label).Text
            txtTotalGrandFinalAmt.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblCurrentRate"), Label).Text
            EL.Id = ViewState("SaleMain_ID")
            HidInvoice.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblsaleinvoiceID"), Label).Text

            HidMInvoice.Text = CType(GvSaleInvoice.Rows(e.NewEditIndex).FindControl("lblsaleinvoiceID"), Label).Text

            If ddlPaymentMethod.SelectedItem.ToString = "Cash" Then
                txtDd.Enabled = False
                txtBranch.Enabled = False
                ddlBank.Enabled = False
                ddlBank.SelectedValue = 0
            Else
                txtDd.Enabled = True
                txtBranch.Enabled = True
                ddlBank.Enabled = True
            End If

            dt = BL.GetSaleInvoice(EL)
            GvSaleInvoice.DataSource = dt
            GvSaleInvoice.DataBind()
            GvSaleInvoice.Enabled = False
            GvSaleInvoice.Visible = True
        Else
            lblMsg.Text = "You do not belong to this branch, Cannot edit data."
            lblErrorMsg.Text = ""
        End If

    End Sub

    Protected Sub btnAddSaleInvoiceDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddSaleInvoiceDetails.Click
        'TabPanel1.Enabled = False
        'TabPanel3.Enabled = True
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'EL.ProductID = DDLRM.SelectedValue
            EL.ProductID = HidProductId.Value
            EL.Batch = DDLBatch.SelectedValue
            If txtTotalQty1.Text = "" Then
                EL.TotalQty = 0
            Else
                EL.TotalQty = txtTotalQty1.Text
            End If
            If EL.TotalQty > ViewState("totalqty") Then
                lblGreen.Text = "Insuficient Quantity."
                lblRed.Text = ""
                Exit Sub
            End If

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
            EL.Deal = txtDeal.Text
            EL.Deal1 = txtDeal1.Text
            If txtTradeRate.Text = "" Then
                EL.Trade_Rate = 0
            Else
                EL.Trade_Rate = txtTradeRate.Text
            End If
            If txtpurchRate.Text = "" Then
                EL.PurchaseRate = 0
            Else
                EL.PurchaseRate = txtpurchRate.Text
            End If
            EL.Amount = EL.TotalQty * EL.PurchaseRate
            If txtDiscount.Text <> "" And txtDiscountAmt.Text <> "" Then
                lblRed.Text = "Please Enter Discount or Discount Amount."
                lblGreen.Text = ""
                Exit Sub
            End If

            If txtDiscount.Text <> "" Then
                EL.DiscPer = txtDiscount.Text
                EL.Disc_Amt = (EL.Trade_Rate * EL.TotalQty) * EL.DiscPer / 100
                txtDiscountAmt.Text = Format(EL.Disc_Amt, "0.0")
            ElseIf txtDiscountAmt.Text <> "" And txtDiscount.Text = "" Then
                EL.Disc_Amt = txtDiscountAmt.Text
                EL.DiscPer = (EL.Disc_Amt * 100) / ((EL.Trade_Rate) * EL.TotalQty)
                txtDiscount.Text = Format(EL.DiscPer, "0.0")
            Else
                EL.DiscPer = 0
                EL.Disc_Amt = 0
            End If

            If txtVAT.Text <> "0.0" Or txtVAT.Text = "0" Then
                EL.FinalAmount = EL.Amount + (EL.Amount * EL.VAT / 100)
            ElseIf txtCST.Text <> "0.0" Or txtCST.Text = "0" Then
                EL.FinalAmount = EL.Amount + (EL.Amount * EL.CST / 100)
            End If
            If txtMRP.Text = "" Then
                EL.MRP = 0
            Else
                EL.MRP = txtMRP.Text
            End If

            If txtmargin.Text = "" Then
                EL.Margin = 0
            Else
                EL.Margin = txtmargin.Text
            End If

            EL.TaxAB = ddlTaxAB.SelectedValue
            EL.TaxON = ddlTaxOn.SelectedValue
            EL.TaxPlan = ddlTaxDesc.SelectedValue
            If ddlCurrency.SelectedValue = "" Then
                EL.Currency = 0
            Else
                EL.Currency = ddlCurrency.SelectedValue
            End If
            If txtExchRate.Text = "" Then
                EL.ExchangeRate = 1
            Else
                EL.ExchangeRate = txtExchRate.Text
            End If


            '--------------------------------------------------------------------------------------------------'

            EL.Qty = EL.Deal / (EL.Deal + EL.Deal1) * EL.TotalQty
            EL.free = EL.Deal1 / (EL.Deal + EL.Deal1) * EL.TotalQty
            'EL.sngPurchRate = EL.PurchRate - EL.Excise
            'EL.sngTradeDiscount = EL.sngPurchRate * EL.Qty * EL.Discount / 100
            'EL.sngFlatDiscount = (EL.sngPurchRate * EL.Qty - EL.sngTradeDiscount) * EL.FlatDiscount / 100
            'EL.sngAmount = rst!Sale_Rate * rst!Qty_Sale
            EL.sngTradeDiscount = EL.Trade_Rate * EL.Qty * EL.DiscPer / 100
            'EL.sngFlatDiscount = EL.Trade_Rate * EL.TotalQty * (1 - EL.DiscPer / 100) * rst!Sale_Flat_Discount / 100
            EL.sngFlatDiscount = EL.Trade_Rate * EL.TotalQty * (1 - EL.DiscPer / 100) * 0
            EL.Amount = EL.Trade_Rate * EL.Qty
            Dim sngTax As Double
            If EL.TaxON = 1 Then
                If EL.TaxAB = 2 Then
                    sngTax = EL.MRP * (EL.Qty + EL.free) * (EL.VAT + EL.CST) / 100
                Else
                    sngTax = EL.MRP * (EL.Qty + EL.free) * (EL.VAT + EL.CST) / 100
                End If

            ElseIf EL.TaxON = 2 Then

                If EL.TaxAB = 2 Then
                    sngTax = EL.MRP * EL.Qty * (EL.VAT + EL.CST) / 100
                ElseIf EL.TaxAB = 1 Then
                    sngTax = EL.MRP * EL.Qty * (EL.VAT + EL.CST) / 100
                End If

            ElseIf EL.TaxON = 3 Then

                If EL.TaxAB = 2 Then

                    sngTax = EL.Trade_Rate * (EL.Qty + EL.free) * (EL.VAT + EL.CST) / 100

                ElseIf EL.TaxAB = 1 Then

                    sngTax = (EL.Trade_Rate * (EL.Qty + EL.free) - EL.sngTradeDiscount - EL.sngFlatDiscount) * (EL.VAT + EL.CST) / 100
                End If


            ElseIf EL.TaxON = 4 Then

                If EL.TaxAB = 2 Then

                    sngTax = EL.Trade_Rate * EL.Qty * (EL.VAT + EL.CST) / 100

                ElseIf EL.TaxAB = 1 Then

                    'sngTax = (EL.PurchRate * (EL.Qty + EL.free) - Discount - EL.sngTradeDiscount - EL.FlatDiscount) * (EL.VAT + EL.CST) / 100
                    sngTax = (EL.Trade_Rate * EL.Qty - EL.sngTradeDiscount - EL.sngFlatDiscount) * (EL.VAT + EL.CST) / 100
                End If
            End If
            'EL.MRPValue = (EL.QtyAccept * EL.MRP)
            EL.VATRate = IIf(EL.VAT > 0, sngTax, 0)
            EL.CSTRate = IIf(EL.CST > 0, sngTax, 0)
            ' Dim HIDELFlatRate As Double
            If HIDFlatRate.Text = "" Then
                EL.HIDELFlatRate = 0
            Else
                EL.HIDELFlatRate = HIDFlatRate.Text
            End If
            EL.FinalAmount = EL.Amount - EL.sngTradeDiscount - EL.sngFlatDiscount + sngTax
            EL.FlatRate = (EL.Amount - EL.sngTradeDiscount - EL.sngFlatDiscount + sngTax) / EL.TotalQty
            EL.Margin = EL.TotalQty * (EL.FlatRate - CDbl(EL.HIDELFlatRate))

            '--------------------------------------------------------------------------------------------------'
            If btnAddSaleInvoiceDetails.Text = "UPDATE" Then
                EL.Id = ViewState("SaleSub_ID")
                'dt = BL.CheckDuplicateCompanyRegister(EL)
                If dt.Rows.Count > 0 Then
                    lblGreen.Text = "Data already exists."
                    lblRed.Text = ""
                Else
                    BL.UpdateSaleInvoiceDetails(EL)
                    lblGreen.Text = ""
                    btnAddSaleInvoiceDetails.Text = "ADD"
                    btnViewSaleInvoiceDetails.Text = "VIEW"
                    lblRed.Text = "Data Updated Successfully."
                    clear()
                    GVSaleInvoiceDetails.PageIndex = ViewState("PageIndex")
                    'DisplaySaleInvoiceDeatils()
                    displayDetails()
                End If
            ElseIf btnAddSaleInvoiceDetails.Text = "ADD" Then
                HidMInvoice.Text = HidSaleInvoiceNo.Value
                If HidMInvoice.Text = "" Then
                    EL.InvoiceID = 0
                Else
                    EL.InvoiceID = HidMInvoice.Text
                End If
                EL.Id = 0

                BL.InsertSaleInvoiceDetails(EL)
                lblGreen.Text = ""
                btnAddSaleInvoiceDetails.Text = "ADD"
                lblRed.Text = "Data Saved successfully."
                clear()
                DDLBatch.Items.Clear()
                txtProduct.Text = ""
                HidProductId.Value = 0
                txtProduct.Focus()
                ' HidProductId.Value = 0
                ViewState("PageIndex") = 0
                GVSaleInvoiceDetails.PageIndex = 0
                displayDetails()
                DisplaySaleInvoiceDeatils()
            End If
        Else
            lblRed.Text = "You do not belong to this branch, Cannot add data."
            lblGreen.Text = ""
        End If
    End Sub
    Sub clear()
        txtTotalQty1.Text = ""
        txtTradeRate.Text = ""
        txtDiscountAmt.Text = ""
        txtDiscount.Text = ""
        txtMRP.Text = ""
        DDLBatch.ClearSelection()
        DDLBatch.Items.Clear()
        'DDLBatch.SelectedValue = 0
        'DDLRM.SelectedValue = 0
        'ddlTaxAB.ClearSelection()
        ddlTaxDesc.ClearSelection()
        txtDeal.Text = ""
        txtDeal1.Text = ""
        txtPackint.Text = ""
        txtMFG.Text = ""
        txtMKT.Text = ""
        txtCnvFact.Text = ""
        txtPurchRate1.Text = ""
        txtExpenses.Text = ""
        txtMRP1.Text = ""
        txtTotalQty1.Text = ""
        txtVAT1.Text = ""
        txtCST1.Text = ""
        txtOffrPeriod.Text = ""
        txtCurrentRate.Text = ""

    End Sub
    Protected Sub btnViewSaleInvoiceDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewSaleInvoiceDetails.Click
        'TabPanel1.Enabled = False
        'TabPanel3.Enabled = True
        If btnViewSaleInvoiceDetails.Text = "VIEW" Then
            GVSaleInvoiceDetails.Enabled = True
            'Details.Visible = False
            lblRed.Text = " "
            lblGreen.Text = " "
            EL.Id = 0
            ViewState("PageIndex") = 0
            GVSaleInvoiceDetails.PageIndex = 0
            displayDetails()
            'DisplaySaleInvoiceDeatils()
            'clear()
        ElseIf btnViewSaleInvoiceDetails.Text = "BACK" Then
            GVSaleInvoiceDetails.Enabled = True
            lblRed.Text = " "
            lblGreen.Text = " "
            btnAddSaleInvoiceDetails.Text = "ADD"
            btnViewSaleInvoiceDetails.Text = "VIEW"
            'btnPost.Enabled = True
            'HidInvoice.Text = ""
            txtProduct.Text = ""
            clear()
            'Details.Visible = False
            GVSaleInvoiceDetails.PageIndex = ViewState("PageIndex")
            'DisplaySaleInvoiceDeatils()
            displayDetails()
        End If
    End Sub
    Sub DisplaySaleInvoiceDeatils()
        'TabPanel1.Enabled = False
        'TabPanel3.Enabled = True
        If HidMInvoice.Text = "" Then
            lblGreen.Text = "No records to display."
            lblRed.Text = ""
            GVSaleInvoiceDetails.Visible = False
        Else


            EL.InvoiceID = HidMInvoice.Text
            dt = DL.GetSaleInvoiceID(EL)
            If dt.Rows.Count > 0 Then
                GVSaleInvoiceDetails.Enabled = True
                GVSaleInvoiceDetails.Visible = True
                GVSaleInvoiceDetails.DataSource = dt
                GVSaleInvoiceDetails.DataBind()
            Else
                lblGreen.Text = "No records to display."
                lblRed.Text = ""
                GVSaleInvoiceDetails.Visible = False
            End If
        End If

    End Sub

    Protected Sub GVSaleInvoiceDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSaleInvoiceDetails.RowDeleting
        'TabPanel1.Enabled = False
        'TabPanel3.Enabled = True
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Id = CType(GVSaleInvoiceDetails.Rows(e.RowIndex).FindControl("SSID"), HiddenField).Value
            BL.DeleteSaleInvoiceDetails(EL)
            GVSaleInvoiceDetails.DataBind()
            lblRed.Text = ""
            lblGreen.Text = "Data Deleted Successfully."
            GVSaleInvoiceDetails.PageIndex = ViewState("PageIndex")
            'DisplaySaleInvoiceDeatils()
            displayDetails()
        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub GVSaleInvoiceDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSaleInvoiceDetails.RowEditing
        'TabPanel1.Enabled = False
        'TabPanel3.Enabled = True
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblGreen.Text = ""
            lblRed.Text = ""
            btnAddSaleInvoiceDetails.Text = "UPDATE"
            btnAddSaleInvoiceDetails.Enabled = True
            btnViewSaleInvoiceDetails.Visible = True
            btnViewSaleInvoiceDetails.Text = "BACK"
            GVSaleInvoiceDetails.Visible = True

            ViewState("SaleSub_ID") = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("SSID"), HiddenField).Value
            HidProductId.Value = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
            txtProduct.Text = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("lblProduct"), Label).Text
            txtTotalQty1.Text = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("lblTotQty"), Label).Text
            DDLBatch.ClearSelection()
            DDLBatch.Items.Clear()

            Dim ProductId As Integer = HidProductId.Value
            dt = MfgSaleInvoiceDL.SelectBatchName(ProductId)
            DDLBatch.Items.Clear()
            If dt.Rows.Count > 0 Then
                DDLBatch.DataSource = dt
                DDLBatch.DataBind()
                batchAssign()
                DDLBatch.Focus()

            End If
            DDLBatch.SelectedValue = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("lblBatchID"), Label).Text
            txtDeal.Text = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("lblDeal"), Label).Text
            txtDeal1.Text = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("lblFree"), Label).Text
            txtTradeRate.Text = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("lblTradeRate"), Label).Text
            txtDiscount.Text = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("lblDiscount"), Label).Text
            'txtDd.Text = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("lblChequeNo"), Label).Text
            'txtDiscountAmt.Text = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
            ddlTaxAB.SelectedValue = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
            ddlTaxOn.SelectedValue = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
            ddlTaxDesc.Items.Clear()
            ddlTaxDesc.ClearSelection()
            ddlTaxDesc.DataSourceID = "ObjTax"
            ddlTaxDesc.DataBind()
            ddlTaxDesc.SelectedValue = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("Label6"), Label).Text
            txtmargin.Text = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("lblMargin"), Label).Text
            txtMRP.Text = CType(GVSaleInvoiceDetails.Rows(e.NewEditIndex).FindControl("lblMRP"), Label).Text
            EL.Id = ViewState("SaleSub_ID")
            dt = BL.GetSaleInvoiceDetails(EL)
            GVSaleInvoiceDetails.DataSource = dt
            GVSaleInvoiceDetails.DataBind()
            GVSaleInvoiceDetails.Enabled = False
            GVSaleInvoiceDetails.Visible = True
            ' displayDetails()
        Else
            lblRed.Text = "You do not belong to this branch, Cannot edit data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub DDlBuyer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDlBuyer.SelectedIndexChanged
        'TabPanel1.Enabled = True
        'TabPanel3.Enabled = False
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        panel1.Visible = True
        'TabPanel1.Visible = True
        If DDlBuyer.SelectedValue = "0" Then

            txtSaleInvNo.Text = ""
            'Clear()
        Else
            EL.Buyer_ID = DDlBuyer.SelectedValue


            dt = BL.AutoGenerateNo(EL)

            If dt.Rows.Count > 0 Then
                txtSaleInvNo.Text = dt.Rows(0).Item("InvoiceNo").ToString
                If txtSaleInvNo.Text = "" Then
                    txtSaleInvNo.Text = 1
                End If
                HidInvoice.Text = dt.Rows(0).Item("InvoiceId").ToString
                If HidInvoice.Text = "" Then
                    HidInvoice.Text = 1
                End If
            Else
                lblErrorMsg.Text = "No records to display."
                lblMsg.Text = ""
            End If
            dt1 = BL.Credit(EL)
            If dt.Rows.Count > 0 Then
                If dt1.Rows(0).Item("balance").ToString = "" Then
                    txtbal.Text = 0
                Else
                    txtbal.Text = Format(dt1.Rows(0).Item("balance"), "0.00")
                End If

                If dt1.Rows(0).Item("Credit_Limit").ToString = "" Then
                    txtCreditLim.Text = 0
                Else
                    txtCreditLim.Text = Format(dt1.Rows(0).Item("Credit_Limit"), "0.00")
                End If
                If dt1.Rows(0).Item("Credit_Period").ToString = "" Then
                    txtCreditPer.Text = 0
                Else
                    txtCreditPer.Text = Format(dt1.Rows(0).Item("Credit_Period"), "0.00")
                End If

            Else
                txtbal.Text = ""
                txtCreditLim.Text = ""
                txtCreditPer.Text = ""
            End If
        End If
    End Sub

    
    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        'TabContainer1.ActiveTab = TabPanel1
        'TabPanel3.Enabled = False
        'TabPanel1.Enabled = True
        MfgSaleInvoiceDL.SaleDelete(HidSaleInvoiceNo.Value)
        txtTotalAmount1.Text = ""
        txtTotalDiscAmount.Text = ""
        txtNoItems.Text = ""
        txtTotalQtyPOS.Text = ""
        GVSaleInvoiceDetails.Visible = "false"
        lblRed.Text = "Invoice Cancelled."
        lblGreen.Text = ""
        dt = BL.AutoGenerateNo(EL)
        Session("ProductNameAutocomplete") = RBProduct.SelectedValue
        If dt.Rows.Count > 0 Then
            txtSaleInvoiceNO.Text = dt.Rows(0).Item("InvoiceNo").ToString
            If txtSaleInvNo.Text = "" Then
                txtSaleInvNo.Text = 1
            End If
            HidSaleInvoiceNo.Value = dt.Rows(0).Item("InvoiceId").ToString
            If HidInvoice.Text = "" Then
                HidInvoice.Text = 1
            End If
        Else

        End If
    End Sub
    Protected Sub btnAddDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetails.Click
        'TabPanel1.Enabled = False
        'TabPanel3.Enabled = True
        lblGreen.Text = ""
        lblRed.Text = ""
        If DDlBuyer.SelectedValue = 0 Then
            lblErrorMsg.Text = "Please select buyer first."
            lblMsg.Text = ""
            Exit Sub
        Else
            TabContainer1.ActiveTab = TabPanel3
            'TabPanel3.Enabled = True
            'TabPanel3.Visible = True
            'TabPanel1.Enabled = False
            lblMsg.Text = ""
            lblErrorMsg.Text = ""

            'btnAdddet.Enabled = True
            GVSaleInvoiceDetails.Visible = False
            If HidInvoice.Text = "" Then
                dt = BL.GetInvoiceNo()
                HidInvoice.Text = dt.Rows(0).Item("InvoiceId").ToString
                HidInvoiceNO.Text = dt.Rows(0).Item("InvoiceNo").ToString
            Else
                EL.InvoiceID = HidInvoice.Text
            End If

        End If
    End Sub
    Protected Sub ddlPaymentMethod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentMethod.SelectedIndexChanged
        'TabPanel1.Enabled = True
        'TabPanel3.Enabled = False
        If ddlPaymentMethod.SelectedItem.ToString = "Cash" Then
            txtDd.Enabled = False
            txtBranch.Enabled = False
            ddlBank.Enabled = False
            ddlBank.SelectedValue = 0
        Else
            txtDd.Enabled = True
            txtBranch.Enabled = True
            ddlBank.Enabled = True
        End If
    End Sub
    Sub CheckAll()
        'TabPanel1.Enabled = True
        'TabPanel3.Enabled = False
        If CType(GvSaleInvoice.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GvSaleInvoice.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GvSaleInvoice.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Protected Sub Btnposttostock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnposttostock.Click
        Dim id As String = ""
        Dim check As String = ""

        Dim count As New Integer
        count = 0
        For Each grid As GridViewRow In GvSaleInvoice.Rows
            If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                check = CType(grid.FindControl("SSID"), HiddenField).Value
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
            lblErrorMsg.Text = "Select Atleast One Stock to Post"
            lblMsg.Text = ""

        Else
            EL.Id = id
            dt = BL.PostStatus(EL)
            If dt.Rows.Count = 0 Then

                EL.ChkID = id
                BL.PaymentRecPaidPurchaseInvoice(EL)
                BL.PostsaleInvoice(EL)
                lblMsg.Text = "Stock posted successfully."
                lblErrorMsg.Text = ""
                DisplaySaleInvoice()
            Else
                lblErrorMsg.Text = "Stock is Already Posted"
                lblMsg.Text = ""
                HidInvoice.Text = ""
                DisplaySaleInvoice()
                Btnposttostock.Enabled = True
            End If
        End If
        'dt = BL.GetSaleInvoiceDetails(EL)
        'HidMInvoice.Text = dt.Rows(0).Item("Sale_Invoice_Id").ToString
        'EL.InvoiceID = HidMInvoice.Text
        'BL.Pushtostock(EL)

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'auto()

        If Not IsPostBack Then
            'txtProduct.Focus()
            Dim strJ As String = "document.getElementById('" & txtProduct.ClientID & "').select();"
            ClientScript.RegisterClientScriptBlock(Me.GetType(), "onload", "window.onload = function() { " & strJ & " }", True)
            txtInvDate.Text = Format(Today, "dd-MMM-yyyy")
            txtEntryDate.Text = Format(Today, "dd-MMM-yyyy")
            txtReceivedDate.Text = Format(Today, "dd-MMM-yyyy")
            txtInvoiceDate.Text = Format(Today, "dd-MMM-yyyy")
            txtcashRecv.Text = 0
            Dim produt As String = HidProductId.Value
            'TabPanel3.Enabled = False
            TabContainer1.ActiveTab = TabPanel3
            txtProduct.Focus()
            otherdetails.Visible = False
            TAXTable.Visible = False
            DetailsHide.Visible = False
            DetailsHide1.Visible = False
            EL.Currency = 1
            EL.ExchangeRate = "1.00"
            dt = BL.AutoGenerateNo(EL)
            Session("ProductNameAutocomplete") = RBProduct.SelectedValue
            If dt.Rows.Count > 0 Then
                txtSaleInvoiceNO.Text = dt.Rows(0).Item("InvoiceNo").ToString
                If txtSaleInvNo.Text = "" Then
                    txtSaleInvNo.Text = 1
                End If
                HidSaleInvoiceNo.Value = dt.Rows(0).Item("InvoiceId").ToString
                If HidInvoice.Text = "" Then
                    HidInvoice.Text = 1
                End If
            Else
                lblErrorMsg.Text = ""
                lblMsg.Text = ""
            End If

        Else
            txtProduct.Focus()
        End If
    End Sub
    Sub Splitter(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("ProductName") = parts(0).ToString()
            txtProduct.Text = parts(0).ToString()

            HidProductId.Value = parts(1).ToString()
            'txtTotalQty1.Focus()
            DDLBatch.Focus()

            'ViewState("StdID") = StdId
        Else
            'txtProduct.AutoPostBack = True
            HidProductId.Value = 0

        End If
    End Sub

    Public Sub displayDetails()
        If HidSaleInvoiceNo.Value = "" Then
            lblRed.Text = ""
            lblGreen.Text = "No records to display."
            GVSaleInvoiceDetails.Visible = False
        Else
            'EL.Id = HidInvoice.Text
            EL.TotalAmount = 0
            EL.TradeDiscAmount = 0
            Dim count As Integer = 0
            Dim qty As Double = 0
            EL.TotalCSTAmount = 0
            EL.TotalVATAmount = 0
            EL.AddFriCharges = 0
            EL.TotalCSTValue = 0
            EL.TotalFinalAmount = 0
            EL.InvoiceID = HidSaleInvoiceNo.Value
            Dim VATtaxamount As Double
            Dim CSTtaxamount As Double

            dt = DL.GetSaleInvoiceID(EL)
            'dt = BL.GetSaleInvoiceIDDetails(EL)
            If dt.Rows.Count > 0 Then
                GVSaleInvoiceDetails.Enabled = True
                GVSaleInvoiceDetails.Visible = True
                GVSaleInvoiceDetails.DataSource = dt
                GVSaleInvoiceDetails.DataBind()
                For Each rows As GridViewRow In GVSaleInvoiceDetails.Rows
                    If CType(rows.FindControl("lblamount"), Label).Text = "" Then
                        EL.TotalAmount = EL.TotalAmount + 0
                    Else
                        EL.TotalAmount = EL.TotalAmount + CType(rows.FindControl("lblamount"), Label).Text
                    End If

                    If CType(rows.FindControl("lblTradeDiscAmt"), Label).Text = "" Then
                        EL.TradeDiscAmount = EL.TradeDiscAmount + 0
                    Else
                        EL.TradeDiscAmount = EL.TradeDiscAmount + CType(rows.FindControl("lblTradeDiscAmt"), Label).Text
                    End If

                    If CType(rows.FindControl("lblFlatdiscAmt"), Label).Text = "" Then
                        EL.FlatDiscAmount = EL.FlatDiscAmount + 0
                    Else
                        EL.FlatDiscAmount = EL.FlatDiscAmount + CType(rows.FindControl("lblFlatdiscAmt"), Label).Text
                    End If
                    If CType(rows.FindControl("lblMRP"), Label).Text = "" Then
                        EL.AddFriCharges = EL.AddFriCharges + 0
                    Else
                        EL.AddFriCharges = EL.AddFriCharges + CType(rows.FindControl("lblMRP"), Label).Text
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
                    If CType(rows.FindControl("lblTotFinalAmt"), Label).Text = "" Then
                        EL.TotalFinalAmount = EL.TotalFinalAmount + 0
                    Else
                        EL.TotalFinalAmount = EL.TotalFinalAmount + CType(rows.FindControl("lblTotFinalAmt"), Label).Text
                    End If
                    If CType(rows.FindControl("lblMargin"), Label).Text = "" Then
                        EL.TotalMargin = EL.TotalMargin + 0
                    Else
                        EL.TotalMargin = EL.TotalMargin + CType(rows.FindControl("lblMargin"), Label).Text
                    End If
                    'If CType(rows.FindControl("lblMRPValue"), Label).Text = "" Then
                    '    EL.TotalCSTValue = EL.TotalCSTValue + 0
                    'Else
                    '    EL.TotalCSTValue = EL.TotalCSTValue + CType(rows.FindControl("lblMRPValue"), Label).Text
                    'End If
                    count = count + 1

                    If CType(rows.FindControl("lblTotQty"), Label).Text = "" Then
                        qty = qty + 0
                    Else
                        qty = qty + CType(rows.FindControl("lblTotQty"), Label).Text
                    End If
                    If CType(rows.FindControl("lblGVVATAmount"), Label).Text = "" Then
                        VATtaxamount = VATtaxamount + 0
                    Else
                        VATtaxamount = VATtaxamount + CType(rows.FindControl("lblGVVATAmount"), Label).Text
                    End If
                    If CType(rows.FindControl("lblGVCSTAmount"), Label).Text = "" Then
                        CSTtaxamount = CSTtaxamount + 0
                    Else
                        CSTtaxamount = CSTtaxamount + CType(rows.FindControl("lblGVCSTAmount"), Label).Text
                    End If


                    'Session("InvDate11") = CType(rows.FindControl("Label18"), Label).Text
                    HidInvD.Value = CType(rows.FindControl("Label18"), Label).Text

                Next
                txtTotalAmount.Text = EL.TotalAmount
                txtTotalAmount1.Text = EL.TotalAmount
                txtTotalDicAmt.Text = EL.TradeDiscAmount
                txtTotalDiscAmount.Text = EL.TradeDiscAmount
                txtFlatDiscAmt.Text = EL.FlatDiscAmount
                txtvatAmt.Text = EL.TotalVATAmount
                txtTotalcstAmt.Text = EL.TotalCSTValue
                txtafc.Text = EL.AddFriCharges
                txtTotalFinalAmt.Text = EL.TotalFinalAmount
                txtTotalRoundOff.Text = EL.RoundOff
                txtProfitLoss.Text = EL.profitLoss
                txtTotalGrandFinalAmt.Text = EL.TotalGrandFinalAmt
                txtProfitLoss.Text = EL.TotalMargin
                txtNoItems.Text = count
                txtTotalQtyPOS.Text = qty
                Session("TAXAmount") = VATtaxamount + CSTtaxamount
            Else
                lblRed.Text = ""
                lblGreen.Text = "No records to display."
                GVSaleInvoiceDetails.Visible = False
            End If
        End If
    End Sub
    Public Sub batchAssign()
        Dim batch As Integer = DDLBatch.SelectedValue
        Dim temp As Integer = HidProductId.Value
        dt = Mfg_DLStockEntry.fillProductBatch(temp, batch)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item("Packing_Details").ToString = "" Then
                txtPackint.Text = ""
            Else
                txtPackint.Text = dt.Rows(0).Item("Packing_Details").ToString
            End If

            If dt.Rows(0).Item("TaxPlan_Id").ToString = "" Then
                ddlTaxDesc.SelectedValue = 0
            Else
                ddlTaxDesc.Items.Clear()
                ddlTaxDesc.ClearSelection()
                ddlTaxDesc.DataSourceID = "ObjTax"
                ddlTaxDesc.DataBind()
                ddlTaxDesc.SelectedValue = dt.Rows(0).Item("TaxPlan_Id")

            End If
            txtMKT.Text = dt.Rows(0).Item("Manufaturer_Name").ToString
            'txtMFG.Text = dt.Rows(0).Item("Manufaturer_Name").ToString
            txtMFG.Text = ""

            If dt.Rows(0).Item("Case_Factor_In_Strip").ToString = "" Then
                txtCnvFact.Text = "0.00"
            Else
                txtCnvFact.Text = Format(dt.Rows(0).Item("Case_Factor_In_Strip"), "0.00")
            End If
            If dt.Rows(0).Item("New_Purchase_Rate").ToString = "" Then
                txtPurchRate1.Text = ""
            Else
                txtPurchRate1.Text = Format(dt.Rows(0).Item("New_Purchase_Rate"), "0.00")
            End If
            txtExpenses.Text = "0.00"
            If dt.Rows(0).Item("New_Sale_MRP").ToString = "" Then
                txtMRP.Text = "0.00"
            Else
                txtMRP.Text = Format(dt.Rows(0).Item("New_Sale_MRP"), "0.00")
            End If
            If dt.Rows(0).Item("totalqty").ToString = "" Then
                txtQty.Text = "0.00"
            Else
                txtQty.Text = Format(dt.Rows(0).Item("totalqty"), "0.00")
                ViewState("totalqty") = Format(dt.Rows(0).Item("totalqty"), "0.00")
            End If
            If dt.Rows(0).Item("totalqty").ToString = "" Then
                txtBatchQty.Text = "0.00"
            Else
                txtBatchQty.Text = Format(dt.Rows(0).Item("totalqty"), "0.00")

                ViewState("totalqty") = Format(dt.Rows(0).Item("totalqty"), "0.00")
            End If
            If dt.Rows(0).Item("Sale_Deal_qty").ToString = "" Then
                txtDeal.Text = 0
            Else
                txtDeal.Text = Format(dt.Rows(0).Item("Sale_Deal_qty"), "0.00")
            End If

            If dt.Rows(0).Item("Sale_Deal_Free").ToString = "" Then
                txtDeal1.Text = 0
            Else
                txtDeal1.Text = Format(dt.Rows(0).Item("Sale_Deal_Free"), "0.00")
            End If
            If dt.Rows(0).Item("Purchase_VAT_Percent").ToString = "" Then
                txtVAT1.Text = "0.00"

            Else
                txtVAT1.Text = Format(dt.Rows(0).Item("Purchase_VAT_Percent"), "0.00")
            End If
            If dt.Rows(0).Item("Purchase_CST_Percent").ToString = "" Then
                txtCST1.Text = "0.00"
            Else
                txtCST1.Text = Format(dt.Rows(0).Item("Purchase_CST_Percent"), "0.00")
            End If
            If dt.Rows(0).Item("OfferPeriod").ToString = "" Then
                txtOffrPeriod.Text = "01-01-1900"
            Else
                txtOffrPeriod.Text = Format(dt.Rows(0).Item("OfferPeriod"), "dd-MMM-yyyy")
            End If
            If dt.Rows(0).Item("New_Sale_Rate").ToString = "" Then
                txtTradeRate.Text = 0
            Else
                txtTradeRate.Text = Format(dt.Rows(0).Item("New_Sale_Rate"), "0.00")
            End If
            txtmargin.Text = (dt.Rows(0).Item("Margin").ToString)
            If dt.Rows(0).Item("VAT_On_Free_percent").ToString <> 0 And dt.Rows(0).Item("VAT_On_Free_percent").ToString <> "" Then
                HIDFlatRate.Text = dt.Rows(0).Item("VAT_On_Free_percent").ToString
            End If
            txtCurrentRate.Text = "0.00"
            txtExchRate.Text = "1.00"

        End If
    End Sub


    Protected Sub txtProduct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProduct.TextChanged
        Dim ProductId As Integer

        Try
            ''This Code use for reading from Bar Code Reader and search the product name and id and bind th data with respective field.
            Dim dt1 As New DataTable
            Dim ItemCode As String = txtProduct.Text
            dt1 = StudentDB.GetProductName(ItemCode)
            If dt1.Rows.Count > 0 Then
                txtProduct.Text = dt1.Rows(0).Item("Product_Name")
                HidProductId.Value = dt1.Rows(0).Item("Product_Id")

                'System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, GetType(Page), "Script", "KeyPQty();", True)

                ProductId = HidProductId.Value
                'RBProduct.SelectedValue = HidProductId.Value 
                dt = MfgSaleInvoiceDL.SelectBatchName(ProductId)
                DDLBatch.Items.Clear()
                If dt.Rows.Count > 0 Then
                    DDLBatch.DataSource = dt
                    DDLBatch.DataBind()
                    batchAssign()
                    DDLBatch.Focus()

                End If
            Else

                HidProductId.Value = 0
                txtProduct.Text = "Item not found."

                txtProduct.Focus()

                'Dim strJS As String = "document.getElementById('" & txtProduct.ClientID & "').select();"
                'ClientScript.RegisterClientScriptBlock(Me.GetType(), "onload", "window.onload = function() { " & strJS & " }", True)
                'Dim scriptKey As String = "UniqueKeyForThisScript"
                'Dim javaScript As String = "<script type='text/javascript'>KeyPressTextbox();</script>"
                'ClientScript.RegisterStartupScript(Me.GetType(), scriptKey, javaScript)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Protected Sub DDLBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLBatch.SelectedIndexChanged
        DDLBatch.Focus()
        Try

            'temp = DDLRM.SelectedValue
            temp = HidProductId.Value
            Dim batch As Integer = DDLBatch.SelectedValue
            dt = Mfg_DLStockEntry.fillProductBatch(temp, batch)
            If dt.Rows.Count > 0 Then
                txtQty.Focus()
                If dt.Rows(0).Item("Packing_Details").ToString = "" Then
                    txtPackint.Text = ""
                Else
                    txtPackint.Text = dt.Rows(0).Item("Packing_Details").ToString
                End If

                txtMKT.Text = dt.Rows(0).Item("Manufaturer_Name").ToString
                'txtMFG.Text = dt.Rows(0).Item("Manufaturer_Name").ToString
                txtMFG.Text = ""

                If dt.Rows(0).Item("Case_Factor_In_Strip").ToString = "" Then
                    txtCnvFact.Text = "0.00"
                Else
                    txtCnvFact.Text = Format(dt.Rows(0).Item("Case_Factor_In_Strip"), "0.00")
                End If
                If dt.Rows(0).Item("New_Purchase_Rate").ToString = "" Then
                    txtPurchRate1.Text = ""
                Else
                    txtPurchRate1.Text = Format(dt.Rows(0).Item("New_Purchase_Rate"), "0.00")
                End If
                txtExpenses.Text = "0.00"
                If dt.Rows(0).Item("New_Sale_MRP").ToString = "" Then
                    txtMRP.Text = "0.00"
                Else
                    txtMRP.Text = Format(dt.Rows(0).Item("New_Sale_MRP"), "0.00")
                End If
                If dt.Rows(0).Item("totalqty").ToString = "" Then
                    txtQty.Text = "0.00"
                Else
                    txtQty.Text = Format(dt.Rows(0).Item("totalqty"), "0.00")
                    ViewState("totalqty") = Format(dt.Rows(0).Item("totalqty"), "0.00")
                End If
                If dt.Rows(0).Item("totalqty").ToString = "" Then
                    txtBatchQty.Text = "0.00"
                Else
                    txtBatchQty.Text = Format(dt.Rows(0).Item("totalqty"), "0.00")

                    ViewState("totalqty") = Format(dt.Rows(0).Item("totalqty"), "0.00")
                End If
                If dt.Rows(0).Item("Purchase_VAT_Percent").ToString = "" Then
                    txtVAT1.Text = "0.00"
                Else
                    txtVAT1.Text = Format(dt.Rows(0).Item("Purchase_VAT_Percent"), "0.00")
                End If
                If dt.Rows(0).Item("Purchase_CST_Percent").ToString = "" Then
                    txtCST1.Text = "0.00"
                Else
                    txtCST1.Text = Format(dt.Rows(0).Item("Purchase_CST_Percent"), "0.00")
                End If
                If dt.Rows(0).Item("OfferPeriod").ToString = "" Then
                    txtOffrPeriod.Text = "01-01-1900"
                Else
                    txtOffrPeriod.Text = Format(dt.Rows(0).Item("OfferPeriod"), "dd-MMM-yyyy")
                End If
                txtmargin.Text = (dt.Rows(0).Item("Margin").ToString)
                If dt.Rows(0).Item("VAT_On_Free_percent").ToString <> 0 And dt.Rows(0).Item("VAT_On_Free_percent").ToString <> "" Then
                    HIDFlatRate.Text = dt.Rows(0).Item("VAT_On_Free_percent").ToString
                End If
                txtCurrentRate.Text = "0.00"
                txtExchRate.Text = "1.00"
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlTaxDesc_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTaxDesc.TextChanged
        EL.TaxPlan = ddlTaxDesc.SelectedValue

        dt = DL.filltax(EL)
        If dt.Rows.Count > 0 Then
            txtCST.Text = Format(dt.Rows(0).Item("CST"), "0.00")
            txtVAT.Text = Format(dt.Rows(0).Item("State_VAT"), "0.00")
        End If
    End Sub


    Protected Sub btnreceipt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreceipt.Click
        Try
            Dim check As String = ""
            Dim id As String = ""

            Dim Count1 As Integer = 0
            For Each Grid As GridViewRow In GvSaleInvoice.Rows
                If CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(Grid.FindControl("lblsaleinvoiceID"), Label).Text
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

                Dim qrystring As String = "Mfg_Rpt_SaleInvoice.aspx?" & "&Id=" & id
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

    'Protected Sub btnProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProduct.Click
    '    dt = Mfg_DLBatchDetails.ProductComboCode()
    '    DDLRM.Items.Clear()
    '    If dt.Rows.Count > 0 Then
    '        DDLRM.DataSource = dt
    '        DDLRM.DataBind()
    '    End If
    'End Sub
    Public Sub autono()

        dt = BL.AutoGenerateNo(EL)
        Session("ProductNameAutocomplete") = RBProduct.SelectedValue
        If dt.Rows.Count > 0 Then
            txtSaleInvoiceNO.Text = dt.Rows(0).Item("InvoiceNo").ToString
            If txtSaleInvNo.Text = "" Then
                txtSaleInvNo.Text = 1
            End If
            HidSaleInvoiceNo.Value = dt.Rows(0).Item("InvoiceId").ToString
            If HidInvoice.Text = "" Then
                HidInvoice.Text = 1
            End If

        End If
        txtTotalAmount1.Text = ""
        txtTotalDiscAmount.Text = ""
        txtNoItems.Text = ""
        txtTotalQtyPOS.Text = ""
        GVSaleInvoiceDetails.Visible = "false"
        lblGreen.Text = ""
        lblRed.Text = ""
        txtProduct.Text = ""
        HidProductId.Value = 0
        txtProduct.Focus()
        DDLBatch.ClearSelection()
        DDLBatch.Items.Clear()
        clear()
    End Sub
    Protected Sub btnAddMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddMain.Click
        Try

            'TabPanel3.Enabled = False
            'TabPanel1.Enabled = True
            If (Session("BranchCode") = Session("ParentBranch")) Then

                dt = BL.AutoGenerateNo(EL)
                Session("ProductNameAutocomplete") = RBProduct.SelectedValue
                If dt.Rows.Count > 0 Then
                    txtSaleInvoiceNO.Text = dt.Rows(0).Item("InvoiceNo").ToString
                    If txtSaleInvNo.Text = "" Then
                        txtSaleInvNo.Text = 1
                    End If
                    HidSaleInvoiceNo.Value = dt.Rows(0).Item("InvoiceId").ToString
                    If HidInvoice.Text = "" Then
                        HidInvoice.Text = 1
                    End If

                End If
                txtTotalAmount1.Text = ""
                txtTotalDiscAmount.Text = ""
                txtNoItems.Text = ""
                txtTotalQtyPOS.Text = ""
                GVSaleInvoiceDetails.Visible = "false"
                lblGreen.Text = ""
                lblRed.Text = ""
                txtProduct.Text = ""
                HidProductId.Value = 0
                txtProduct.Focus()
                DDLBatch.ClearSelection()
                DDLBatch.Items.Clear()
                clear()
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
                lblMsg.Text = ""
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Date is not valid."
        End Try
    End Sub
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            'TabPanel3.Enabled = False
            'TabPanel1.Enabled = True
            If (Session("BranchCode") = Session("ParentBranch")) Then
                EL.Buyer_ID = 0
                If txtSaleInvNo.Text = "" Then
                    EL.Sale_Invoice_No = ""
                Else
                    EL.Sale_Invoice_No = txtSaleInvoiceNO.Text
                End If
                If txtInvoiceDate.Text = "" Then
                    EL.Invoice_Date = "01-Jan-3000"
                Else
                    EL.Invoice_Date = txtInvoiceDate.Text
                End If
                EL.Invoice_Type = "CASH Invoice"
                EL.SE = 0
                EL.Payment_Method = ddlPaymentMethod.SelectedValue
                EL.Bank = 0
                EL.Branch = ""
                If txtFlatDiscAmt.Text = "" Then
                    EL.Flat_disc_Amt = 0
                Else
                    EL.Flat_disc_Amt = 0
                End If
                If txtEntryDate.Text = "" Then
                    EL.Entry_Date = "01-Jan-3000"
                Else
                    EL.Entry_Date = txtEntryDate.Text
                End If
                EL.SO_NO = 0
                EL.Transaction_Type = 1
                If txtFlatDisc.Text = "" Then
                    EL.Flat_Disc = 0
                Else
                    EL.Flat_Disc = 0
                End If
                If txtCurRecAmt.Text = "" Then
                    EL.Curr_rec_Amt = 0
                Else
                    EL.Curr_rec_Amt = 0
                End If
                If txtNoOfItem.Text = "" Then
                    EL.NO_Of_Item = 0
                Else
                    EL.NO_Of_Item = txtNoOfItem.Text    'NEED TO DO SOMETHING
                End If
                If txtFreightChrg.Text = "" Then
                    EL.Freight_charges = 0
                Else
                    EL.Freight_charges = 0
                End If
                If txtCreditNote.Text = "" Then
                    EL.Credit = 0
                Else
                    EL.Credit = 0
                End If
                If txtDebitNote.Text = "" Then
                    EL.Debit = 0
                Else
                    EL.Debit = 0
                End If
                'If txtCreditNote.Text = "" And txtDebitNote.Text = "" Then
                '    lblErrorMsg.Text = "Please Enter Either Credit or Debit Note."
                '    lblMsg.Text = ""
                '    Exit Sub
                'End If
                If txtDd.Text = "" Then
                    EL.Cheque_No = 0
                Else
                    EL.Cheque_No = 0
                End If
                EL.Remarks = txtRemarks.Text
                If txtchallan.Text = "" Then
                    EL.Challan_NO = 0
                Else
                    EL.Challan_NO = 0
                End If

                EL.Note = txtRemarksodr.Text
                If txtTransport.Text = "" Then
                    EL.Transport_NO = 0
                Else
                    EL.Transport_NO = 0
                End If
                If txtTotalAmount.Text = "" Then
                    EL.TotalAmount = 0
                Else
                    EL.TotalAmount = txtTotalAmount.Text

                End If

                If txtTotalDicAmt.Text = "" Then
                    EL.TradeDiscAmount = 0
                Else
                    EL.TradeDiscAmount = txtTotalDicAmt.Text
                End If

                If txtTotalFinalAmt.Text = "" Then
                    EL.TotalFinalAmount = 0
                Else
                    EL.TotalFinalAmount = txtTotalFinalAmt.Text
                End If

                If txtvatAmt.Text = "" Then
                    EL.TotalVATAmount = 0
                Else
                    EL.TotalVATAmount = txtvatAmt.Text
                End If

                If txtTotalcstAmt.Text = "" Then
                    EL.TotalCSTValue = 0
                Else
                    EL.TotalCSTValue = txtTotalcstAmt.Text
                End If

                If txtafc.Text = "" Then
                    EL.AddFriCharges = 0
                Else
                    EL.AddFriCharges = 0
                End If
                'txtafc.Text = EL.TotalExcise * EL.TotalMRP

                If txtTotalFinalAmt.Text = "" Then
                    EL.TotalFinalAmount = 0
                Else
                    EL.TotalFinalAmount = txtTotalFinalAmt.Text
                End If
                If txtTotalRoundOff.Text = "" Then
                    txtTotalRoundOff.Text = "0.00"
                Else
                    EL.RoundOff = txtTotalRoundOff.Text
                End If

                EL.RoundOff = IIf(txtTotalRoundOff.Text = "", 0, CDbl(txtTotalRoundOff.Text))
                EL.RoundOff = txtTotalRoundOff.Text
                If txtProfitLoss.Text = "" Then
                    EL.profitLoss = 0
                Else
                    EL.profitLoss = txtProfitLoss.Text
                End If
                txtTotalGrandFinalAmt.Text = EL.Freight_charges + EL.RoundOff + EL.TotalFinalAmount
                txtTotalGrandFinalAmt.Text = IIf(txtFreightChrg.Text = "", 0, CDbl(EL.Freight_charges)) + IIf(txtTotalRoundOff.Text = "", 0, CDbl(EL.RoundOff)) + IIf(txtTotalFinalAmt.Text = "", 0, CDbl(EL.TotalFinalAmount))
                EL.TotalGrandFinalAmt = txtTotalGrandFinalAmt.Text
                EL.Sent_By = txtSentBy.Text
                EL.Dispatched_From = txtdispatchdfrom.Text
                EL.Dispatched_To = txtDispatchdTo.Text


                EL.Transportation_Mode = 0
                If txtReceivedDate.Text = "" Then
                    EL.Received_Date = "01-Jan-3000"
                Else
                    EL.Received_Date = "01-Jan-3000"
                End If

                If HidInvoice.Text = "" Then
                    EL.InvoiceID = 0
                Else
                    EL.InvoiceID = HidSaleInvoiceNo.Value
                End If
                EL.Id = ViewState("SaleMain_ID")
                dt = BL.CheckDuplicateSaleInvoice(EL)
                If dt.Rows.Count > 0 Then
                    'lblGreen.Text = "Data already exists."
                    'lblRed.Text = ""
                ElseIf btnADDSaleInvoice.Text = "UPDATE" Then

                    EL.Id = ViewState("SaleMain_ID")
                    BL.UpdateSaleInvoice(EL)
                    lblErrorMsg.Text = ""
                    btnADDSaleInvoice.Text = "ADD"
                    btnViewSaleInvoice.Text = "VIEW"
                    lblMsg.Text = "Data Updated Successfully."
                    clear1()
                    'GvSaleInvoice.PageIndex = ViewState("PageIndex")
                    'DisplaySaleInvoice()
                    'ddlPaymentMethod.Items.Clear()
                    'ddlPaymentMethod.DataSourceID = "ObjPaymentMethod"
                    'ddlPaymentMethod.DataBind()
                    'ddlBank.Items.Clear()
                    'ddlBank.DataSourceID = "ObjBank"
                    'ddlBank.DataBind()
                    dt = BL.AutoGenerateNo(EL)
                    Session("ProductNameAutocomplete") = RBProduct.SelectedValue
                    If dt.Rows.Count > 0 Then
                        txtSaleInvoiceNO.Text = dt.Rows(0).Item("InvoiceNo").ToString
                        If txtSaleInvNo.Text = "" Then
                            txtSaleInvNo.Text = 1
                        End If
                        HidSaleInvoiceNo.Value = dt.Rows(0).Item("InvoiceId").ToString
                        If HidInvoice.Text = "" Then
                            HidInvoice.Text = 1
                        End If
                    Else
                        lblErrorMsg.Text = "No records to display."
                        lblMsg.Text = ""
                    End If

                ElseIf btnADDSaleInvoice.Text = "ADD" Then
                    If HidInvoice.Text <> "0" And HidInvoice.Text <> "" Then
                        EL.Id = 0
                        BL.InsertSaleInvoice(EL)
                        lblErrorMsg.Text = ""
                        btnADDSaleInvoice.Text = "ADD"
                        'lblMsg.Text = "Data Saved successfully."
                        lblMsg.Text = ""
                        lblGreen.Text = ""
                        lblRed.Text = ""
                        clear1()
                        Dim invId As String = HidSaleInvoiceNo.Value
                        BL.PaymentRecPaidPurchaseInvoice2(invId)
                        dt = MfgSaleInvoiceDL.PostStatusCheck(invId)
                        invId = invId
                        If dt.Rows.Count = 0 Then
                            EL.ChkID = invId
                            MfgSaleInvoiceDL.PostSI(EL)

                        Else

                        End If
                        ViewState("PageIndex") = 0
                        'GvSaleInvoice.PageIndex = 0
                        'TabPanel1.Visible = True
                        panel1.Visible = True
                        'GvSaleInvoice.Visible = True
                        ' DisplaySaleInvoice()
                        'ddlPaymentMethod.Items.Clear()
                        'ddlPaymentMethod.DataSourceID = "ObjPaymentMethod"
                        'ddlPaymentMethod.DataBind()
                        'ddlBank.Items.Clear()
                        'ddlBank.DataSourceID = "ObjBank"
                        'ddlBank.DataBind()
                        'dt = BL.AutoGenerateNo(EL)
                        '    Session("ProductNameAutocomplete") = RBProduct.SelectedValue
                        '    If dt.Rows.Count > 0 Then
                        '        txtSaleInvoiceNO.Text = dt.Rows(0).Item("InvoiceNo").ToString
                        '        If txtSaleInvNo.Text = "" Then
                        '            txtSaleInvNo.Text = 1
                        '        End If
                        '        HidSaleInvoiceNo.Value = dt.Rows(0).Item("InvoiceId").ToString
                        '        If HidInvoice.Text = "" Then
                        '            HidInvoice.Text = 1
                        '        End If
                        '    End If
                        autono()
                    Else
                        lblErrorMsg.Text = "First Add SIN Details."
                        lblMsg.Text = ""
                    End If
                End If
                'Dim User As String = Request.QueryString.Get("User")
                ''Dim PrintinvoiceNo As String
                'EL.Id = HidSaleInvoiceNo.Value
                ''PrintinvoiceNo = check + ","
                'Dim report As New LocalReport()
                'dt1 = MfgSaleInvoiceDL.GetSaleInvoiceDetailsFORPrint(EL)
                'report.ReportPath = "RptSaleInvoice.rdlc"
                'report.DataSources.Add(New ReportDataSource("GlobalDataSet_Mfg_Rpt_SaleInvoiceRecpt", dt1))
                'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'txtBalCash.Text = CDbl(IIf(txtcashRecv.Text = "", 0, txtcashRecv.Text)) - CDbl(IIf(txtTotalAmount1.Text = "", 0, txtTotalAmount1.Text)) - CDbl(IIf(txtTotalDicAmt.Text = "", 0, txtTotalDicAmt.Text))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalReceived", CDbl(IIf(txtcashRecv.Text = "", 0, txtcashRecv.Text)), False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalItems", CDbl(IIf(txtNoItems.Text = "", 0, txtNoItems.Text)), False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("User", Session("EmpName").ToString, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalBalance", CDbl(IIf(txtBalCash.Text = "", 0, txtBalCash.Text)), False))
                ''paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", EndDate, False))
                'report.SetParameters(paramList)

                'dt2 = obj.RPT_GetSelfDeatilsByBranch(0)
                'AddHandler report.SubreportProcessing, AddressOf SubreportProcessingEvent
                'Export(report)
                'Print()

            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
                lblMsg.Text = ""
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Date is not valid."
        End Try
    End Sub


    Protected Sub RBProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBProduct.SelectedIndexChanged
        Session("ProductNameAutocomplete") = RBProduct.SelectedValue
        txtProduct.Text = ""
        HidProductId.Value = ""

    End Sub



    Protected Sub txtSaleInvoiceNO_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSaleInvoiceNO.TextChanged
        Dim search As String
        search = txtSaleInvoiceNO.Text
        dt = MfgSaleInvoiceDL.SearchInvoice(search)
        Session("ProductNameAutocomplete") = RBProduct.SelectedValue
        If dt.Rows.Count > 0 Then
            txtSaleInvoiceNO.Text = dt.Rows(0).Item("InvoiceNo").ToString
            If txtSaleInvoiceNO.Text = "" Then
                txtSaleInvoiceNO.Text = 1
            End If
            HidSaleInvoiceNo.Value = dt.Rows(0).Item("InvoiceId").ToString
            If HidSaleInvoiceNo.Value = "" Then
                HidSaleInvoiceNo.Value = 1
            End If
        Else
            lblErrorMsg.Text = "No records to display."
            lblMsg.Text = ""
        End If
    End Sub

    Protected Sub BtnCheck_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCheck.Click
        txtBalCash.Text = CDbl(IIf(txtcashRecv.Text = "", 0, txtcashRecv.Text)) - CDbl(IIf(txtTotalAmount1.Text = "", 0, txtTotalAmount1.Text)) + CDbl(IIf(txtTotalDicAmt.Text = "", 0, txtTotalDicAmt.Text))
    End Sub

    Protected Sub txtcashRecv_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtcashRecv.TextChanged
        txtBalCash.Text = CDbl(IIf(txtcashRecv.Text = "", 0, txtcashRecv.Text)) - CDbl(IIf(txtTotalAmount1.Text = "", 0, txtTotalAmount1.Text)) - CDbl(IIf(txtTotalDicAmt.Text = "", 0, txtTotalDicAmt.Text))

    End Sub


End Class
