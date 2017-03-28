
Partial Class mfg_frmPurchaseOrder
    Inherits BasePage
    Dim SupplierId As New Integer
    Dim PONo As String
    Dim dt As New DataTable
    Dim BL As New mfg_PurchaseOrderBL
    Dim El As New mfg_PurchaseOrderEL
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            txtPOVALDate.Text = Format(Today, "dd-MMM-yyyy")
            txtPODate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub LinkAddDtls_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkAddDtls.Click
        El.PurchaseRequisition = ddlPurchaseReqNo.SelectedValue

        'Dim CurrencyIdTemp As Integer
        'Dim ExchangeRate As Double
        txtQuantity.Text = ""
        txtUnitRate.Text = ""
        If GVPurchaseOrderDetails.Visible = True Then
            lblmsg2.Text = ""
            msginfo2.Text = ""
            If ddlSupplier.SelectedValue = 0 Then
                msginfo.Text = "Please select a supplier before adding product."
                lblmsg.Text = ""
            ElseIf txtPONo.Text = "" Then
                msginfo.Text = "PO No is mandatory."
                lblmsg.Text = ""
            ElseIf txtPODate.Text = "" Then
                msginfo.Text = "PO Date is mandatory."
                lblmsg.Text = ""
            ElseIf CDate(IIf(txtPODate.Text <> "", txtPODate.Text, "1/1/9100")) > CDate(IIf(txtPOVALDate.Text <> "", txtPOVALDate.Text, "1/1/9100")) Then
                msginfo.Text = "PO Validity Date cannot be greater than PO Date."
                lblmsg.Text = ""
            Else
                'GV1Panel.Visible = False
                'GVPurchaseOrderDetails.Visible = False
                'displaygridview()
                '-------------- new changes-----------------------
                If ViewState("PostStatus") Is Nothing Then
                    BtnADD2.Enabled = True
                Else
                    El.PONo = ViewState("PostStatus")
                    dt = BL.PostStatus(El)
                    If dt.Rows(0).Item("Posted_To_Stock") = "Y" Then
                        BtnADD2.Enabled = False
                        'lblmsg2.Text = ""
                        GVPODetails.Columns(0).Visible = False
                    Else
                        GVPODetails.Columns(0).Visible = True
                        BtnADD2.Enabled = True
                    End If
                End If
                If ViewState("PostStatusNew") Is Nothing Then
                    BtnADD2.Enabled = True
                Else

                End If

                GVPODetails.Visible = False
                AddDetails.Visible = True
                Currency()
                msginfo.Text = ""
                lblmsg.Text = ""
            End If
        Else
            lblmsg2.Text = ""
            msginfo2.Text = ""
            If ddlSupplier.SelectedValue = 0 Then
                msginfo.Text = "Please select a supplier before adding product."
                lblmsg.Text = ""
            ElseIf txtPONo.Text = "" Then
                msginfo.Text = "PO No is mandatory."
                lblmsg.Text = ""
            ElseIf txtPODate.Text = "" Then
                msginfo.Text = "PO Date is mandatory."
                lblmsg.Text = ""
            ElseIf CDate(IIf(txtPODate.Text <> "", txtPODate.Text, "1/1/9100")) > CDate(IIf(txtPOVALDate.Text <> "", txtPOVALDate.Text, "1/1/9100")) Then
                msginfo.Text = "PO Validity Date cannot be greater than PO Date."
                lblmsg.Text = ""
            Else
                If ViewState("PostStatus") Is Nothing Then

                Else
                    El.PONo = ViewState("PostStatus")
                    dt = BL.PostStatus(El)
                    If dt.Rows(0).Item("Posted_To_Stock") = "Y" Then
                        BtnADD2.Enabled = False
                        'lblmsg2.Text = ""
                        GVPODetails.Columns(0).Visible = False
                    Else
                        GVPODetails.Columns(0).Visible = True
                        BtnADD2.Enabled = True
                    End If
                End If
                GV1Panel.Visible = False
                GVPurchaseOrderDetails.Visible = True
                'displaygridview()
                GVPODetails.Visible = False
                AddDetails.Visible = True
                Currency()
                msginfo.Text = ""
                lblmsg.Text = ""

            End If
        End If

    End Sub
    Sub CheckAll()
        If CType(GVPurchaseOrderDetails.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVPurchaseOrderDetails.Rows
                CType(grid.FindControl("ChkPO"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVPurchaseOrderDetails.Rows
                CType(grid.FindControl("ChkPO"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If btnView.Text = "VIEW PO" Then
            El.Id = 0
            displaygridview2()
            GVPODetails.Visible = False
            AddDetails.Visible = False
            txtPONo.Enabled = True
            'clear()
        Else
            ddlSupplier.Enabled = True
            lblSupplier.Enabled = True
            btnPost.Enabled = True
            El.Id = 0
            displaygridview2()
            GVPODetails.Visible = False
            AddDetails.Visible = False
            GVPurchaseOrderDetails.Enabled = True
            txtPONo.Enabled = True
            btnAdd.Text = "ADD PO"
            btnView.Text = "VIEW PO"
            clear()
        End If
    End Sub
    Sub Currency()
        El.PONo = txtPONo.Text
        dt = BL.GetProductforPONo(El)
        If dt.Rows.Count > 0 Then
            lblCurrency.Enabled = False
            lblExchRate.Enabled = False
            ddlCurrency.SelectedValue = dt.Rows(0).Item("Currency_Code")
            txtExRate.Text = Format(dt.Rows(0).Item("Currency_Factor"), "N")
            txtExRate.Enabled = False
            ddlCurrency.Enabled = False
        Else
            ddlCurrency.Items.Clear()
            ddlCurrency.DataSourceID = "ObjMC"
            ddlCurrency.DataBind()
            txtExRate.Text = Format(1, "N")
            lblCurrency.Enabled = True
            lblExchRate.Enabled = True
            txtExRate.Enabled = True
            ddlCurrency.Enabled = True
        End If
    End Sub

    Sub displaygridview2()
        Dim dt As New DataTable
        El.Id = 0
        El.SupplierId = ddlSupplier.SelectedValue
        If txtPODate.Text = "" Then
            El.PODate = "1/1/9100"
        Else
            El.PODate = txtPODate.Text
        End If
        If txtPONo.Text = "" Then
            El.PONo = 0
        Else
            El.PONo = txtPONo.Text
        End If
        dt = BL.getPurchaseOrderforEdit(El)
        msginfo.Text = ""
        lblmsg.Text = ""
        GVPurchaseOrderDetails.DataSource = dt
        GVPurchaseOrderDetails.DataBind()
        GV1Panel.Visible = True
        GVPurchaseOrderDetails.Visible = True

        If dt.Rows.Count = 0 Then
            msginfo.Text = "No records to display."
            lblmsg.Text = ""
            GVPODetails.Visible = False
            'GVPurchaseOrderDetails.Visible = False
        Else
            'For Each rows As GridViewRow In GVPurchaseOrderDetails.Rows
            '    If CType(rows.FindControl("HIDTransportMode"), HiddenField).Value = "1" Then
            '        CType(rows.FindControl("lblTransportMode"), Label).Text = "Rail"

            '    ElseIf CType(rows.FindControl("HIDTransportMode"), HiddenField).Value = "2" Then
            '        CType(rows.FindControl("lblTransportMode"), Label).Text = "Ship"

            '    ElseIf CType(rows.FindControl("HIDTransportMode"), HiddenField).Value = "3" Then
            '        CType(rows.FindControl("lblTransportMode"), Label).Text = "Road"
            '    End If
            'Next
            For Each rows As GridViewRow In GVPurchaseOrderDetails.Rows
                If CType(rows.FindControl("HIDPost"), HiddenField).Value = "Y" Then
                    CType(rows.FindControl("lblPost"), Label).Text = "Posted"

                ElseIf CType(rows.FindControl("HIDPost"), HiddenField).Value = "N" Then
                    CType(rows.FindControl("lblPost"), Label).Text = "Not Posted"

                End If
            Next
        End If
    End Sub

    Protected Sub ddlSupplier_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSupplier.SelectedIndexChanged
        Dim dt As New DataTable
        dt = BL.GetPONo()
        If ddlSupplier.SelectedValue = 0 Then
            txtPONo.Text = ""
        Else
            txtPONo.Text = dt.Rows(0).Item("PurchNo")
            msginfo.Text = ""
            lblmsg.Text = ""
        End If

        El.Id = ddlSupplier.SelectedValue
        dt = BL.GetSupplierAutoFill(El)
        If dt.Rows.Count > 0 Then
            txtAddress.Text = dt.Rows(0).Item("Supp_Address")
            txtEmail.Text = dt.Rows(0).Item("Email")
        Else
            txtAddress.Text = ""
            txtEmail.Text = ""
        End If
        'GVPurchaseOrderDetails.Visible = False
        AddDetails.Visible = False
        GVPODetails.Visible = False
    End Sub
    Sub clear()
        txtPONo.Text = ""
        txtDivideOrder.Text = ""
        txtEmail.Text = ""
        txtRemarks.Text = ""
        txtShipment.Text = ""
        txtAddress.Text = ""
        ddlSupplier.ClearSelection()
        txtPODate.Text = Format(Today, "dd-MMM-yyyy")
        txtPOVALDate.Text = Format(Today, "dd-MMM-yyyy")
    End Sub
    Protected Sub GVPODetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVPODetails.RowDeleting
        Dim a As Integer
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If GVPODetails.EditIndex <> -1 Then
                msginfo2.Text = "First Cancel Edit."
                lblmsg2.Text = ""
            Else
                a = CType(GVPODetails.Rows(e.RowIndex).FindControl("ID"), HiddenField).Value
                BL.DeletePODetails(a)
                displaygridview()
                lblmsg2.Text = "Product Deleted Successfully."
                msginfo2.Text = ""
                'GVPODetails.PageIndex = ViewState("PageIndex")
            End If
        Else
            msginfo2.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg2.Text = ""
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim dt As DataTable
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnAdd.Text = "ADD PO" Then
                El.PONo = txtPONo.Text
                dt = BL.getProductforSupplierId(El)
                If dt.Rows.Count > 0 Then
                    If CDate(IIf(txtPODate.Text <> "", txtPODate.Text, "1/1/9100")) > CDate(IIf(txtPOVALDate.Text <> "", txtPOVALDate.Text, "1/1/9100")) Then
                        msginfo.Text = "PO Validity Date cannot be greater than PO Date."
                        lblmsg.Text = ""
                    Else
                        El.SupplierId = ddlSupplier.SelectedValue
                        El.Address = txtAddress.Text
                        El.PONo = txtPONo.Text
                        El.PODate = txtPODate.Text
                        El.POValidityDate = txtPOVALDate.Text
                        If ddlPaymentMethod.SelectedValue = 0 Then
                            El.PaymentMethodId = 0
                        Else
                            El.PaymentMethodId = ddlPaymentMethod.SelectedValue
                        End If
                        If txtDivideOrder.Text = "" Then
                            El.DivideOrder = 0
                        Else
                            El.DivideOrder = txtDivideOrder.Text
                        End If
                        El.Remarks = txtRemarks.Text
                        El.TransportationMode = ddlShipment.SelectedValue
                        El.ShipmentAddress = txtShipment.Text
                        dt = BL.DuplicatePurchaseOrder(El)
                        If dt.Rows.Count > 0 Then
                            msginfo.Text = "PO already saved."
                            lblmsg.Text = ""
                        Else
                            BL.AddPurchaseOrder(El)
                            lblmsg.Text = "PO saved Successfully."
                            AddDetails.Visible = False
                            GVPODetails.Visible = False
                            msginfo.Text = ""
                            El.Id = 0
                            displaygridview2()
                            clear()
                        End If
                    End If
                Else
                    msginfo.Text = "Enter Product before adding PO."
                    lblmsg.Text = ""
                    GVPODetails.Visible = False
                End If
            ElseIf btnAdd.Text = "UPDATE" Then
                ddlSupplier.Enabled = True
                lblSupplier.Enabled = True
                AddDetails.Visible = False
                El.PONo = ViewState("PostStatus")
                dt = BL.PostStatus(El)
                If dt.Rows(0).Item("Posted_To_Stock") = "Y" Then
                    msginfo.Text = "Cannot update, PO already posted."
                    lblmsg.Text = ""
                ElseIf CDate(IIf(txtPODate.Text <> "", txtPODate.Text, "1/1/9100")) > CDate(IIf(txtPOVALDate.Text <> "", txtPOVALDate.Text, "1/1/9100")) Then
                    msginfo.Text = "PO Validity Date cannot be greater than PO Date."
                    lblmsg.Text = ""
                Else
                    El.SupplierId = ddlSupplier.SelectedValue
                    El.Address = txtAddress.Text
                    El.PONo = txtPONo.Text
                    El.PODate = txtPODate.Text
                    El.POValidityDate = txtPOVALDate.Text
                    If ddlPaymentMethod.SelectedValue = 0 Then
                        El.PaymentMethodId = 0
                    Else
                        El.PaymentMethodId = ddlPaymentMethod.SelectedValue
                    End If
                    El.DivideOrder = txtDivideOrder.Text
                    El.Remarks = txtRemarks.Text
                    El.TransportationMode = ddlShipment.SelectedValue
                    El.ShipmentAddress = txtShipment.Text
                    El.Id = ViewState("PurchaseOrderId")
                    dt = BL.DuplicatePurchaseOrder(El)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = "PO already saved."
                        lblmsg.Text = ""
                    Else
                        El.Id = ViewState("PurchaseOrderId")
                        BL.UpdatePurchaseOrder(El)
                        displaygridview2()
                        lblmsg.Text = "PO updated Successfully."
                        msginfo.Text = ""
                        El.Id = 0
                        btnAdd.Text = "ADD PO"
                        btnView.Text = "VIEW PO"
                        GVPODetails.Visible = False
                        GVPurchaseOrderDetails.Enabled = True
                        txtPONo.Enabled = True
                        btnPost.Enabled = True
                        clear()
                    End If
                    txtPONo.Enabled = True
                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub BtnADD2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnADD2.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If BtnADD2.Text = "ADD PRODUCT" Then

                'El.PONo = ViewState("PostStatus")
                'dt = BL.PostStatus(El)
                'If dt.Rows(0).Item("Posted_To_Stock") = "Y" Then
                '    msginfo2.Text = "Cannot update, PO already posted."
                '    lblmsg2.Text = ""
                'Else
                El.SupplierId = ddlSupplier.SelectedValue
                El.PONo = txtPONo.Text
                El.CurrencyID = ddlCurrency.SelectedValue
                El.ExchangeRate = txtExRate.Text
                El.ProductID = DDLProduct.SelectedValue
                El.Quantity = txtQuantity.Text
                El.UnitID = ddlUnit.SelectedValue
                El.UnitRate = txtUnitRate.Text
                El.EstimatedPrice = ViewState("PurchaseRate")
                'El.EstimatedValue = El.EstimatedPrice * El.Quantity
                El.EstimatedValue = txtUnitRate.Text * El.Quantity
                El.ProductType = RbProduct.SelectedValue
                El.Id = 0

                If ddlPurchaseReqNo.SelectedValue <> "0" Then
                    If txtQtyReq.Text > txtQuantity.Text Then
                        msginfo2.Text = "Quantity should be less than or equal to Requested quantity."
                        lblmsg2.Text = ""
                        Exit Sub
                    End If
                End If
                dt = BL.DuplicateProductPO(El)
                If dt.Rows.Count > 0 Then
                    msginfo2.Text = "Date already saved."
                    lblmsg2.Text = ""
                Else
                    BL.AddPODetails(El)
                    displaygridview()
                    lblmsg2.Text = "Data saved successfully."
                    msginfo2.Text = ""
                    txtExRate.Text = ""
                    ddlCurrency.ClearSelection()
                    DDLProduct.ClearSelection()
                    txtQuantity.Text = ""
                    ddlUnit.ClearSelection()
                    txtUnitRate.Text = ""
                    Currency()
                    GVPODetails.Visible = True
                    'End If
                End If
            Else
                El.PONo = txtPONo.Text
                dt = BL.GetProductforPO(El)
                If dt.Rows.Count > 1 Then
                    ddlCurrency.Enabled = False
                    txtExRate.Enabled = False
                    lblCurrency.Enabled = False
                    lblExchRate.Enabled = False
                ElseIf dt.Rows.Count <= 1 Then
                    ddlCurrency.Enabled = True
                    txtExRate.Enabled = True
                    lblCurrency.Enabled = True
                    lblExchRate.Enabled = True
                End If
                El.PONo = ViewState("PostStatus")
                If El.PONo IsNot Nothing Then
                    dt = BL.PostStatus(El)
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0).Item("Posted_To_Stock") = "Y" Then
                            msginfo2.Text = "Cannot update, PO already posted."
                            lblmsg2.Text = ""
                        End If
                    End If
                Else
                    El.SupplierId = ddlSupplier.SelectedValue
                    El.PONo = txtPONo.Text
                    El.CurrencyID = ddlCurrency.SelectedValue
                    El.ExchangeRate = txtExRate.Text
                    El.ProductID = DDLProduct.SelectedValue
                    El.Quantity = txtQuantity.Text
                    El.UnitID = ddlUnit.SelectedValue
                    El.UnitRate = txtUnitRate.Text
                    El.EstimatedPrice = ViewState("PurchaseRate")
                    'El.EstimatedValue = El.EstimatedPrice * El.Quantity
                    El.EstimatedValue = txtUnitRate.Text * El.Quantity
                    El.ProductType = RbProduct.SelectedValue
                    El.Id = ViewState("ProductId")
                    dt = BL.DuplicateProductPO(El)
                    If dt.Rows.Count > 0 Then
                        msginfo2.Text = "Data already saved."
                        lblmsg2.Text = ""
                    Else
                        El.Id = ViewState("ProductId")
                        BL.UpdateProductPO(El)
                        El.Id = 0
                        El.PONo = txtPONo.Text
                        displaygridview()
                        lblmsg2.Text = "Data updated successfully."
                        msginfo2.Text = ""
                        txtExRate.Text = ""
                        ddlCurrency.ClearSelection()
                        DDLProduct.ClearSelection()
                        txtQuantity.Text = ""
                        ddlUnit.ClearSelection()
                        txtUnitRate.Text = ""
                        Currency()
                        GVPODetails.Visible = True
                        BtnADD2.Text = "ADD PRODUCT"
                        BtnViewProduct.Text = "VIEW PRODUCT"
                        BtnClose.Enabled = True
                    End If
                End If
                End If

        Else
                msginfo2.Text = "You do not belong to this branch, Cannot delete data."
                lblmsg2.Text = ""
            End If
    End Sub
    Sub displaygridview()
        Dim dt As New DataTable
        El.SupplierId = ddlSupplier.SelectedValue
        El.PONo = txtPONo.Text
        dt = BL.GetPODetails(El)
        GVPODetails.DataSource = dt
        GVPODetails.DataBind()
        If dt.Rows.Count = 0 Then
            msginfo2.Text = "No records to display."
            lblmsg2.Text = ""
            GVPODetails.Visible = False
        Else
            msginfo2.Text = ""
            lblmsg2.Text = ""
            For Each rows As GridViewRow In GVPODetails.Rows
                If CType(rows.FindControl("lblProdTypeCode"), Label).Text = "1" Then
                    CType(rows.FindControl("lblProdType"), Label).Text = "Raw Materials"

                ElseIf CType(rows.FindControl("lblProdTypeCode"), Label).Text = "2" Then
                    CType(rows.FindControl("lblProdType"), Label).Text = "ReadyMade"

                ElseIf CType(rows.FindControl("lblProdTypeCode"), Label).Text = "3" Then
                    CType(rows.FindControl("lblProdType"), Label).Text = "Finished Goods"
                End If
            Next
            GVPODetails.Enabled = True
        End If
    End Sub
    Protected Sub RbProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbProduct.SelectedIndexChanged
        txtUnitRate.Text = ""
    End Sub
    Protected Sub ddlCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCurrency.SelectedIndexChanged
        Dim MC1 As New MultiCurrencyManager
        Dim MCD As MultiCurrency = MC1.GetMulticurrencyRate(CInt(IIf(ddlCurrency.SelectedValue.ToString = "", 0, ddlCurrency.SelectedValue.ToString)))
        txtExRate.Text = Format(MCD.BuyConversionRate, "N")
        Dim rate As Double
        Dim PurchaseRate As Double
        Dim Id As New Integer
        If DDLProduct.SelectedValue = "0" Then
            txtUnitRate.Text = ""
        Else
            rate = txtExRate.Text
            Id = DDLProduct.SelectedValue
            dt = BL.getPurchaseRate(Id)
            PurchaseRate = dt.Rows(0).Item("New_Purchase_Rate")
            txtUnitRate.Text = Format((PurchaseRate / rate), "N")
        End If
    End Sub
    Protected Sub DDLProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLProduct.SelectedIndexChanged
        Dim rate As Double
        Dim PurchaseRate As Double
        Dim Id As New Integer
        If DDLProduct.SelectedValue = "0" Then
            txtUnitRate.Text = ""
            txtQtyReq.Text = ""
        Else
            rate = txtExRate.Text
            Id = DDLProduct.SelectedValue
            dt = BL.getPurchaseRate(Id)
            PurchaseRate = dt.Rows(0).Item("New_Purchase_Rate")
            ViewState("PurchaseRate") = PurchaseRate
            txtUnitRate.Text = Format((PurchaseRate / rate), "N")
            If ddlPurchaseReqNo.SelectedValue <> "0" Then
                dt = BL.getPurchaseQtyReceived(Id, ddlPurchaseReqNo.SelectedValue)
                txtQtyReq.Text = dt.Rows(0).Item("Quantity")
                ddlUnit.SelectedValue = dt.Rows(0).Item("Unit")
            End If
       End If
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        AddDetails.Visible = False
        GVPODetails.Visible = False
        GVPurchaseOrderDetails.Visible = True
    End Sub

    Protected Sub GVPODetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVPODetails.RowEditing
        AddDetails.Visible = True
        msginfo2.Text = ""
        lblmsg2.Text = ""
        RbProduct.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("HIDProdType"), HiddenField).Value
        DDLProduct.Items.Clear()
        DDLProduct.DataSourceID = "ObjProduct"
        DDLProduct.DataBind()
        DDLProduct.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("HIDProductID"), HiddenField).Value
        ddlUnit.SelectedValue = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("HIDUnit_ID"), HiddenField).Value
        txtQuantity.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblQuantity"), Label).Text
        txtUnitRate.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblUnitRate"), Label).Text
        ViewState("ProductId") = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("ID"), HiddenField).Value
        txtExRate.Text = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("lblExchRate"), Label).Text
        ViewState("ProdId") = CType(GVPODetails.Rows(e.NewEditIndex).FindControl("HIDProductID"), HiddenField).Value
        El.Id = ViewState("ProductId")
        displaygridview()
        El.PONo = txtPONo.Text
        dt = BL.GetProductforPO(El)
        If dt.Rows.Count > 1 Then
            ddlCurrency.Enabled = False
            txtExRate.Enabled = False
            lblCurrency.Enabled = False
            lblExchRate.Enabled = False
        ElseIf dt.Rows.Count <= 1 Then
            ddlCurrency.Enabled = True
            txtExRate.Enabled = True
            lblCurrency.Enabled = True
            lblExchRate.Enabled = True
        End If
        BtnADD2.Text = "UPDATE"
        BtnViewProduct.Text = "BACK"
        BtnClose.Enabled = False
        GVPODetails.Enabled = False
    End Sub

    Protected Sub GVPurchaseOrderDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVPurchaseOrderDetails.RowDeleting
        Dim a As New Integer
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If GVPurchaseOrderDetails.EditIndex <> -1 Then
                msginfo.Text = "First Cancel Edit."
                lblmsg.Text = ""
            Else
                ViewState("PostStatusNew") = CType(GVPurchaseOrderDetails.Rows(e.RowIndex).FindControl("lblPost"), Label).Text

                If ViewState("PostStatusNew") = "Posted" Then
                    lblmsg.Text = ""
                    msginfo.Text = ""
                    'ViewState("PostStatus") = ""
                    lblmsg.Text = ""
                    msginfo.Text = "Posted Record cannot be deleted."
                Else
                    a = CType(GVPurchaseOrderDetails.Rows(e.RowIndex).FindControl("POMainID"), HiddenField).Value
                    BL.DeletePurchaseOrder(a)
                    lblmsg.Text = "PO Deleted Successfully."
                    msginfo.Text = ""
                    displaygridview2()
                End If

            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GVPurchaseOrderDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVPurchaseOrderDetails.RowEditing
        Dim dt As New DataTable
        btnPost.Enabled = False
        ViewState("PostStatusNew") = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("lblPost"), Label).Text

        ViewState("PostStatus") = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("lblPONo"), Label).Text
        ddlSupplier.SelectedValue = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("HIDSUPPID"), HiddenField).Value
        txtAddress.Text = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("HIDAddress"), HiddenField).Value
        txtPONo.Text = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("lblPONo"), Label).Text
        txtPODate.Text = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("lblPODate"), Label).Text
        txtPOVALDate.Text = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("lblValid"), Label).Text
        ddlPaymentMethod.SelectedValue = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("HIDPayment_ID"), HiddenField).Value
        txtDivideOrder.Text = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("lblDivideOrder"), Label).Text
        txtEmail.Text = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("lblEMail"), Label).Text
        txtRemarks.Text = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
        ddlShipment.SelectedValue = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("HIDTransportMode"), HiddenField).Value
        txtShipment.Text = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("lblShipmentAdd"), Label).Text
        ViewState("PurchaseOrderId") = CType(GVPurchaseOrderDetails.Rows(e.NewEditIndex).FindControl("POMainID"), HiddenField).Value
        txtPONo.Enabled = False
        btnAdd.Text = "UPDATE"
        btnView.Text = "BACK"
        El.Id = ViewState("PurchaseOrderId")
        El.PODate = txtPODate.Text
        El.PONo = txtPONo.Text
        El.SupplierId = ddlSupplier.SelectedValue
        dt = BL.getPurchaseOrderforEdit(El)
        msginfo.Text = ""
        lblmsg.Text = ""
        ddlSupplier.Enabled = False
        lblSupplier.Enabled = False
        GVPurchaseOrderDetails.DataSource = dt
        GVPurchaseOrderDetails.DataBind()
        GV1Panel.Visible = True
        GVPurchaseOrderDetails.Visible = True
        GVPurchaseOrderDetails.Enabled = False
    End Sub

    Protected Sub BtnViewProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnViewProduct.Click
        If btnView.Text = "VIEW PRODUCT" Then
            El.PONo = txtPONo.Text
            El.Id = 0
            displaygridview()
            GVPurchaseOrderDetails.Visible = False
            AddDetails.Visible = True
            GVPODetails.Visible = True
            msginfo2.Text = ""
            lblmsg2.Text = ""
            El.PONo = txtPONo.Text
            dt = BL.GetProductforPO(El)
            If dt.Rows.Count > 1 Then
                ddlCurrency.Enabled = False
                txtExRate.Enabled = False
                lblCurrency.Enabled = False
                lblExchRate.Enabled = False
            ElseIf dt.Rows.Count <= 1 Then
                ddlCurrency.Enabled = True
                txtExRate.Enabled = True
                lblCurrency.Enabled = True
                lblExchRate.Enabled = True
            End If
        Else
            ddlCurrency.Enabled = False
            txtExRate.Enabled = False
            lblCurrency.Enabled = False
            lblExchRate.Enabled = False
            txtQuantity.Text = ""
            DDLProduct.SelectedValue = 0
            ddlUnit.SelectedValue = 0
            txtUnitRate.Text = ""
            msginfo2.Text = ""
            lblmsg2.Text = ""
            El.Id = 0
            El.PONo = txtPONo.Text
            displaygridview()
            GVPurchaseOrderDetails.Visible = False
            AddDetails.Visible = True
            GVPODetails.Visible = True
            GVPODetails.Enabled = True
            BtnADD2.Text = "ADD PRODUCT"
            BtnViewProduct.Text = "VIEW PRODUCT"
            BtnClose.Enabled = True
        End If
    End Sub

    Protected Sub txtPONo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPONo.TextChanged
        GVPurchaseOrderDetails.Visible = False
        AddDetails.Visible = False
        GVPODetails.Visible = False
    End Sub

    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim id As String = ""
        Dim check As String = ""

        Dim count As New Integer
        count = 0
        For Each grid As GridViewRow In GVPurchaseOrderDetails.Rows
            If CType(grid.FindControl("ChkPO"), CheckBox).Checked = True Then
                check = CType(grid.FindControl("lblPONo"), Label).Text.ToString
                El.PONo = check
                dt = BL.PostStatus(El)
                If dt.Rows(0).Item("Posted_To_Stock") = "Y" Then
                    msginfo.Text = "Uncheck the PO which is already Posted."
                    lblmsg.Text = ""
                    Exit Sub
                Else
                    id = check + "," + id
                    count = count + 1
                End If
            End If
        Next
        If id = "" Then
            id = "0"
            count = 0
        Else
            id = Left(id, id.Length - 1)
        End If

        If count = 0 Then
            msginfo.Text = "Select atleast one PO to Post."
            lblmsg.Text = ""
        Else
            El.PONo = id
            BL.PostPurchaseOrder(El)
            displaygridview2()
            lblmsg.Text = "PO posted successfully."
            msginfo.Text = ""
        End If
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            Dim check As String = ""
            Dim id As String = ""

            Dim Count1 As Integer = 0
            For Each Grid As GridViewRow In GVPurchaseOrderDetails.Rows

                If CType(Grid.FindControl("ChkPO"), CheckBox).Checked = True Then
                    check = CType(Grid.FindControl("lblPONo"), Label).Text
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

                Dim qrystring As String = "Mfg_Rpt_PurchaseOrder.aspx?" & "&id=" & id
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Else
                lblmsg.Text = "Please select the records to print."
                msginfo.Text = ""
            End If

        Catch ex As Exception
            msginfo.Text = "Please select the records from gridview. "
        End Try
    End Sub
End Class
