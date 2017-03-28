
Partial Class FrmSaleOrderMfg
    Inherits BasePage
    Dim ELSaleOrderMfg As New ELSaleorderMfg
    Dim BLSalesorderMfg As New BLSalesOrderMfg
    Dim dt As New DataTable
    'Dim BLAddsaleorderDetailsMfg As New BLAddsaleorderDetailsMfg
    Sub Display()
        'Code for Display grid By Nitin 14/08/2012
        If txtSO_NO.Text = "" Then
            ELSaleOrderMfg.Sale_Order_Number = 0
        Else
            ELSaleOrderMfg.Sale_Order_Number = txtSO_NO.Text
        End If
        dt = BLSalesorderMfg.GetSaleOrderView(ELSaleOrderMfg)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
        Else
            lblErrorMsg1.Text = " No records to display."
            LblMsg1.Text = ""
            cmbCurrency.Enabled = True
            txtExRate.Enabled = True
            GridView1.Visible = False
        End If
    End Sub
    'Code for clear field By Nitin 14/08/2012
    Sub Clear()
        txtSOValidity.Text = ""
        txtRemarkss.Text = ""
        txtInvoiceNo.Text = ""
        txtTransportDate.Text = ""
        txtShippingAddress.Text = ""
    End Sub
    Sub Clear1()
        txtQuantity.Text = ""
        txtEstimatedprice.Text = ""
    End Sub
    Sub DisplayRBPdocuts()
        'Code for Display grid By Nitin 14/08/2012
        ELSaleOrderMfg.Sale_Order_Number = txtSO_NO.Text
        dt = BLSalesorderMfg.GetproductEdit(ELSaleOrderMfg)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
        Else
            lblErrorMsg1.Text = " No records to display."
            LblMsg1.Text = ""
            GridView1.Visible = False
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Display()
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        'Code for Delete sale order form By Nitin 14/08/2012
        If (Session("BranchCode") = Session("ParentBranch")) Then
            BLSalesorderMfg.DeleteSaleOrder(CType(GridView1.Rows(e.RowIndex).FindControl("lblSODetailSubID"), Label).Text)
            GridView1.DataBind()
            ELSaleOrderMfg.SODetailSubID = ViewState("id")
            Display()
            LblMsg1.Text = "Data Deleted Successfully."
            lblErrorMsg1.Text = ""
        Else
            lblErrorMsg1.Text = "You do not belong to this branch, Cannot delete data."
            LblMsg1.Text = ""
        End If
    End Sub
    Protected Sub DDlBuyer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDlBuyer.SelectedIndexChanged
        'Code for Fill Address based on buyer By Nitin 14/08/2012
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        panel1.Visible = False
        If DDlBuyer.SelectedValue = "0" Then
            txtBuyerAddress.Text = ""
            txtSO_NO.Text = ""
            Clear()
        Else
            ELSaleOrderMfg.PartyAutoNo = DDlBuyer.SelectedValue
            dt = BLSalesorderMfg.filltextbox(ELSaleOrderMfg)
            Try
                If dt.Rows.Count > 0 Then
                    txtBuyerAddress.Text = dt.Rows(0).Item("Party_Address").ToString
                Else
                    lblErrorMsg.Text = ""
                    lblMsg.Text = ""
                End If
            Catch ex As Exception
                lblErrorMsg.Text = "Address not found."
                lblMsg.Text = ""
            End Try
            'Code for AutoGenerate By Nitin 14/08/2012
            dt = BLSalesorderMfg.AutoGenerateNo(ELSaleOrderMfg)
            Try
                If dt.Rows.Count > 0 Then
                    txtSO_NO.Text = dt.Rows(0).Item("SONo").ToString
                    If txtSO_NO.Text = "" Then
                        txtSO_NO.Text = 1
                    End If
                Else
                    lblErrorMsg.Text = "No records to display."
                    lblMsg.Text = ""
                End If
            Catch ex As Exception
                lblErrorMsg.Text = "Address not found."
                lblMsg.Text = ""
            End Try
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            txtSODate.Text = Format(Today(), "dd-MMM-yyyy")
            txtSOValidity.Text = Format(Today(), "dd-MMM-yyyy")
            txtTransportDate.Text = Format(Today(), "dd-MMM-yyyy")
            panel1.Visible = False
            GridView1.Visible = True
            txtExRate.Text = "1.00"
            lblSaleorderHeader.Visible = False
            Btnposttostock.Visible = True
        End If
    End Sub
    'Code for add and update Button By Nitin 14/08/2012
    Protected Sub btnADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnADD.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                panel1.Visible = False
                lblQuotation.Visible = False
                lblSaleorderHeader.Visible = True
                ELSaleOrderMfg.Party_ID = DDlBuyer.SelectedValue
                ELSaleOrderMfg.Sale_Order_Number = txtSO_NO.Text
                If txtSODate.Text = "" Then
                    ELSaleOrderMfg.Sale_Order_Date = "1/1/1900"
                Else
                    ELSaleOrderMfg.Sale_Order_Date = txtSODate.Text
                End If
                ELSaleOrderMfg.PaymentMethod = DDlPaymentMethod.SelectedValue
                ELSaleOrderMfg.Remarks = txtRemarkss.Text
                ELSaleOrderMfg.Ship_Address = txtShippingAddress.Text
                ELSaleOrderMfg.Ship_Method = DdlTransportBy.SelectedValue
                If txtTransportDate.Text = "" Then
                    ELSaleOrderMfg.Ship_Date = "1/1/1900"
                Else
                    ELSaleOrderMfg.Ship_Date = txtTransportDate.Text
                End If
                If txtSOValidity.Text = "" Then
                    ELSaleOrderMfg.Valid_Upto = "1/1/1900"
                Else
                    ELSaleOrderMfg.Valid_Upto = txtSOValidity.Text
                End If
                If btnADD.Text = "ADD" Then
                    'Code for get Sales_Order_ID By Nitin 16/08/2012
                    dt = BLSalesorderMfg.GetSaleOrderId(ELSaleOrderMfg)
                    If dt.Rows.Count > 0 Then
                        Dim SaleOrderId As Integer
                        SaleOrderId = dt.Rows(0).Item("Sales_Order_ID")
                        ELSaleOrderMfg.ID = SaleOrderId
                    End If
                    If ELSaleOrderMfg.Valid_Upto = "1/1/1900" Then
                        dt = BLSalesorderMfg.CheckDuplicateforBuyer(ELSaleOrderMfg)
                        If dt.Rows.Count > 0 Then
                            lblErrorMsg.Text = "Data already exists."
                            lblMsg.Text = ""
                        Else
                            dt = BLSalesorderMfg.getsaleorderidField(ELSaleOrderMfg)
                            If dt.Rows.Count > 0 Then
                                ELSaleOrderMfg.Sale_Invoice_No = txtInvoiceNo.Text
                                BLSalesorderMfg.InsertSaleOrder(ELSaleOrderMfg)
                                BLSalesorderMfg.Sale_Invoice_Rev2(ELSaleOrderMfg)
                                lblMsg.Text = "Data Saved Successfully."
                                lblErrorMsg.Text = ""
                                ViewState("PageIndex") = 0
                                GridViewSO.PageIndex = 0
                                DispGrid()
                                Clear()
                                panel1.Visible = False
                                Btnposttostock.Enabled = True
                            Else
                                lblErrorMsg.Text = "Enter products before adding SO."
                            End If
                        End If
                    ElseIf ELSaleOrderMfg.Sale_Order_Date > ELSaleOrderMfg.Valid_Upto Then
                        lblErrorMsg.Text = "SO Date should not be greater than SO Validity."
                        lblMsg.Text = ""
                    Else
                        dt = BLSalesorderMfg.CheckDuplicateforBuyer(ELSaleOrderMfg)
                        If dt.Rows.Count > 0 Then
                            lblErrorMsg.Text = "Data already exists."
                            lblMsg.Text = ""
                        Else
                            dt = BLSalesorderMfg.getsaleorderidField(ELSaleOrderMfg)
                            If dt.Rows.Count > 0 Then
                                ELSaleOrderMfg.Sale_Invoice_No = txtInvoiceNo.Text
                                BLSalesorderMfg.InsertSaleOrder(ELSaleOrderMfg)
                                BLSalesorderMfg.Sale_Invoice_Rev2(ELSaleOrderMfg)
                                lblMsg.Text = "Data Saved Successfully."
                                lblErrorMsg.Text = ""
                                ViewState("PageIndex") = 0
                                GridViewSO.PageIndex = 0
                                DispGrid()
                                Clear()
                                panel1.Visible = False
                                Btnposttostock.Enabled = True
                                DDlBuyer.SelectedValue = 0
                                txtSO_NO.Text = ""
                            Else
                                lblErrorMsg.Text = "Enter products before adding SO."
                            End If
                        End If
                    End If
                ElseIf btnADD.Text = "UPDATE" Then
                    dt = BLSalesorderMfg.GetSOPostStatus(ELSaleOrderMfg)
                    If dt.Rows.Count > 0 Then
                        Dim POST As String = dt.Rows(0).Item("Posted_To_Stock")
                        If POST = "Y" Then
                            lblErrorMsg.Text = "SO already posted,Cannot update."
                        Else
                            panel1.Visible = False
                            ELSaleOrderMfg.Sale_Invoice_No = txtInvoiceNo.Text
                            ELSaleOrderMfg.Sales_Order_ID = ViewState("Sales_Order_ID")
                            BLSalesorderMfg.UpdateSaleOrder(ELSaleOrderMfg)
                            'dt = BLSalesorderMfg.GetSaleInvoiceNO(ELSaleOrderMfg)
                            'If dt.Rows.Count > 0 Then
                            '    Dim Sale_InvoiceNO As Integer = dt.Rows(0).Item("SaleMain_ID")
                            '    ELSaleOrderMfg.SaleMain_ID = Sale_InvoiceNO
                            '    BLSalesorderMfg.UpdateSale_Invoice_Rev2(ELSaleOrderMfg)
                            'End If
                            lblMsg.Text = "Data Updated Successfully."
                            panel1.Visible = False
                            Btnposttostock.Enabled = True
                            lblErrorMsg.Text = ""
                            btnADD.Text = "ADD"
                            btnView.Text = "VIEW"
                            GridView1.Visible = False
                            Btnadd1.Enabled = True
                            Btnposttostock.Visible = True
                            ViewState("PageIndex") = 0
                            GridViewSO.PageIndex = 0
                            DispGrid()
                            Clear()
                            DDlBuyer.SelectedValue = 0
                            txtSO_NO.Text = ""
                        End If
                    End If
                End If
            Catch ex As Exception
                lblErrorMsg.Text = "Enter correct data."
            End Try
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
            lblMsg.Text = ""
        End If
    End Sub
    Sub DispGrid()
        If DDlBuyer.SelectedValue = "0" Then
            ELSaleOrderMfg.Party_ID = 0
        Else
            ELSaleOrderMfg.Party_ID = DDlBuyer.SelectedValue
        End If
        If txtSO_NO.Text = "" Then
            ELSaleOrderMfg.Sales_Order_ID = 0
        Else
            ELSaleOrderMfg.Sale_Order_Number = txtSO_NO.Text
        End If
        If txtSODate.Text = "" Then
            ELSaleOrderMfg.Sale_Order_Date = "01/01/1900"
        Else
            ELSaleOrderMfg.Sale_Order_Date = txtSODate.Text
        End If
        dt = BLSalesorderMfg.EditSaleOrder(ELSaleOrderMfg)
        If dt.Rows.Count > 0 Then
            GridViewSO.DataSource = dt
            GridViewSO.DataBind()
            GridViewSO.Visible = True
            GridViewSO.Enabled = True
        Else
            lblErrorMsg.Text = " No records to display."
            lblMsg.Text = ""
            GridViewSO.Visible = False
        End If
    End Sub

    Protected Sub GridViewSO_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridViewSO.PageIndexChanging
        GridViewSO.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridViewSO.PageIndex
        DispGrid()
    End Sub
    'Code for Row deleting By Nitin 14/08/2012
    Protected Sub GridViewSO_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridViewSO.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            BLSalesorderMfg.DeleteSaleOrder1(CType(GridViewSO.Rows(e.RowIndex).FindControl("lblSales_Order_ID"), Label).Text)
            GridView1.DataBind()
            lblMsg.Text = "Data Deleted Successfully."
            lblErrorMsg.Text = ""
            DispGrid()
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblMsg.Text = ""
        End If
    End Sub
    'Code for Row editing By Nitin 14/08/2012
    Protected Sub GridViewSO_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridViewSO.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblErrorMsg.Text = ""
            lblMsg.Text = ""
            ViewState("Sales_Order_ID") = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblSales_Order_ID"), Label).Text
            DDlBuyer.SelectedValue = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblParty_ID"), Label).Text
            ViewState("Sales_Order_IDD") = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblParty_ID"), Label).Text
            txtBuyerAddress.Text = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblParty_Address"), Label).Text
            txtSO_NO.Text = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblSales_Order_ID1"), Label).Text
            txtSODate.Text = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblSODate"), Label).Text
            txtSOValidity.Text = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblValid_Upto"), Label).Text
            DDlPaymentMethod.SelectedValue = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblPaymentMethodIDAuto"), Label).Text
            txtRemarkss.Text = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
            txtInvoiceNo.Text = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblSale_Invoice_No"), Label).Text
            txtShippingAddress.Text = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblShip_Address"), Label).Text
            DDlPaymentMethod.SelectedValue = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblPaymentMethodIDAuto"), Label).Text
            txtTransportDate.Text = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("lblShip_Date"), Label).Text
            DdlTransportBy.SelectedValue = CType(GridViewSO.Rows(e.NewEditIndex).FindControl("LBLShip_Method"), Label).Text
            ELSaleOrderMfg.Sales_Order_ID = ViewState("Sales_Order_ID")
            'dt = BLSalesorderMfg.EditSaleOrder(ELSaleOrderMfg)
            Btnposttostock.Enabled = False
            DispGrid()
            ELSaleOrderMfg.SODetailSubID = ViewState("Sales_Order_IDD")
            GridViewSO.Enabled = False
            btnADD.Text = "UPDATE"
            btnView.Text = "BACK"
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
            lblMsg.Text = ""
        End If
    End Sub
    'Code for Row editing By Nitin 14/08/2012
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblErrorMsg1.Text = ""
            LblMsg1.Text = ""
            BtnClose.Enabled = False
            ELSaleOrderMfg.SODetailSubID = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSODetailSubID"), Label).Text
            ELSaleOrderMfg.Sale_Order_Number = txtSO_NO.Text
            dt = BLSalesorderMfg.GetproductEditMorethanOne(ELSaleOrderMfg)
            If dt.Rows.Count > 1 Then
                dt = BLSalesorderMfg.GetproductEdit(ELSaleOrderMfg)
                If dt.Rows.Count > 0 Then
                    Dim RBP As Integer = dt.Rows(0).Item("Field2")
                    If RBP = "1" Then
                        RbProduct.SelectedValue = 1
                        EditProducts()
                        cmbCurrency.Enabled = False
                        txtExRate.Enabled = False
                    Else
                        If RBP = "2" Then
                            cmbCurrency.Enabled = False
                            txtExRate.Enabled = False
                            RbProduct.SelectedValue = 2
                            EditProducts()
                        ElseIf RBP = "3" Then
                            cmbCurrency.Enabled = False
                            txtExRate.Enabled = False
                            RbProduct.SelectedValue = 3
                            EditProducts()
                        End If
                    End If
                End If
            Else
                dt = BLSalesorderMfg.GetproductEdit(ELSaleOrderMfg)
                If dt.Rows.Count > 0 Then
                    Dim RBProducts As Integer = dt.Rows(0).Item("Field2")
                    If RBProducts = "1" Then
                        RbProduct.SelectedValue = 1
                        EditProducts()
                        cmbCurrency.Enabled = True
                        txtExRate.Enabled = True
                    ElseIf RBProducts = "2" Then
                        RbProduct.SelectedValue = 2
                        EditProducts()
                        cmbCurrency.Enabled = True
                        txtExRate.Enabled = True
                    ElseIf RBProducts = "3" Then
                        RbProduct.SelectedValue = 3
                        EditProducts()
                        cmbCurrency.Enabled = True
                        txtExRate.Enabled = True
                    End If
                End If
            End If

        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
            lblMsg.Text = ""
        End If
    End Sub
    Sub EditProducts()
        DDLProduct.Items.Clear()
        DDLProduct.DataSourceID = "ObjProduct"
        DDLProduct.DataBind()
        DDLProduct.SelectedValue = dt.Rows(0).Item("Product_ID").ToString
        txtQuantity.Text = dt.Rows(0).Item("Quantity_Ordered").ToString
        txtEstimatedprice.Text = dt.Rows(0).Item("Currency_Rate")
        cmbCurrency.SelectedValue = dt.Rows(0).Item("Currency_Code").ToString
        txtExRate.Text = Format(dt.Rows(0).Item("Currency_Factor"), "F").ToString
        ViewState("SO_Detail_ID") = dt.Rows(0).Item("SO_Detail_ID").ToString
        ViewState("SODetailSubID") = dt.Rows(0).Item("SODetailSubID").ToString
        ViewState("Sales_Order_ID") = dt.Rows(0).Item("Sales_Order_ID").ToString
        DisplayRBPdocuts()
        GridView1.Enabled = False
        Btnadd1.Text = "UPDATE"
        BtnView1.Text = "BACK"
    End Sub
    'Code for view and back button By Nitin 14/08/2012
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        LinkButton1.Focus()
        If DDlBuyer.SelectedValue = 0 Then
            lblErrorMsg.Text = "Buyer field is Mandatory."
            lblMsg.Text = ""
            GridViewSO.Visible = False
            Exit Sub
        End If
        If btnView.Text = "BACK" Then
            lblErrorMsg.Text = ""
            lblMsg.Text = ""
            GridViewSO.PageIndex = ViewState("PageIndex")
            DispGrid()
            Clear()
            GridView1.Visible = True
            Btnposttostock.Enabled = True
            btnView.Text = "VIEW"
            btnADD.Text = "ADD"
            Btnadd1.Enabled = True
            Btnposttostock.Visible = True
            panel1.Visible = False
            Btnposttostock.Visible = True
        ElseIf btnView.Text = "VIEW" Then
            lblErrorMsg.Text = ""
            lblMsg.Text = ""
            Btnposttostock.Enabled = True
            ViewState("PageIndex") = 0
            GridViewSO.PageIndex = 0
            DispGrid()
        End If
    End Sub
    'code for Post button by nitin 11/10/12
    Protected Sub Btnposttostock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnposttostock.Click
        Try
            ELSaleOrderMfg.Sale_Order_Number = txtSO_NO.Text
            dt = BLSalesorderMfg.GetSOPostStatus(ELSaleOrderMfg)
            If dt.Rows.Count > 0 Then
                Dim POST As String = dt.Rows(0).Item("Posted_To_Stock")
                If POST = "Y" Then
                    Btnadd1.Enabled = False
                End If
            End If
            Dim check As String = ""
            Dim count As New Integer
            Dim id As String = ""
            For Each Grid1 As GridViewRow In GridViewSO.Rows
                If CType(Grid1.FindControl("chkbox"), CheckBox).Checked = False Then
                    lblErrorMsg.Text = "Select any SO which you want to post."
                    lblMsg.Text = ""
                    Exit For
                End If
            Next
            For Each Grid As GridViewRow In GridViewSO.Rows
                If CType(Grid.FindControl("chkbox"), CheckBox).Checked = True Then
                    If CType(Grid.FindControl("lblpost"), Label).Text = "Posted" Then
                        lblErrorMsg.Text = "Sale Order already Posted."
                        lblMsg.Text = ""
                    ElseIf CType(Grid.FindControl("chkbox"), CheckBox).Checked = True Then
                        check = CType(Grid.FindControl("lblSales_Order_ID1"), Label).Text
                        id = check + "," + id
                        count = count + 1
                        ELSaleOrderMfg.Sale_Order_Number = check
                        BLSalesorderMfg.UpdatePostFlag(ELSaleOrderMfg)
                        lblMsg.Text = "Sale Order Posted successfully."
                        lblErrorMsg.Text = ""
                        DispGrid()
                    End If
                End If
            Next
        Catch ex As Exception
            lblErrorMsg.Text = "Select any SO which you want to post."
            lblMsg.Text = ""
        End Try
    End Sub

    Protected Sub btnAddDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetails.Click
        'Code for link to add sale order form By Nitin 14/08/2012
        Try
            lblErrorMsg1.Text = ""
            LblMsg1.Text = ""
            ELSaleOrderMfg.Sale_Order_Number = txtSO_NO.Text
            dt = BLSalesorderMfg.GetSOPostStatus(ELSaleOrderMfg)
            If dt.Rows.Count > 0 Then
                Dim Posted As String = dt.Rows(0).Item("Posted_To_Stock")
                If Posted = "Y" Then
                    GridView1.Columns(0).Visible = False
                    Btnadd1.Enabled = False
                    panel1.Visible = True
                ElseIf Posted = "N" Then
                    If txtSO_NO.Text = "" Then
                        ELSaleOrderMfg.Sale_Order_Number = 0
                    Else
                        ELSaleOrderMfg.Sale_Order_Number = txtSO_NO.Text
                    End If
                    dt = BLSalesorderMfg.GetSaleOrderView(ELSaleOrderMfg)
                    If dt.Rows.Count > 0 Then
                        If cmbCurrency.SelectedValue = "3" Then
                            cmbCurrency.SelectedValue = dt.Rows(0).Item("Currency_Code")
                            txtExRate.Text = Format(dt.Rows(0).Item("Currency_Factor"), "F2").ToString
                        Else
                            cmbCurrency.DataSourceID = "ObjMC"
                            cmbCurrency.DataBind()
                            cmbCurrency.SelectedValue = dt.Rows(0).Item("Currency_Code")
                            txtExRate.Text = Format(dt.Rows(0).Item("Currency_Factor"), "F2").ToString
                        End If
                        panel1.Visible = True
                        cmbCurrency.Enabled = False
                        txtExRate.Enabled = False
                    End If
                    lblErrorMsg.Text = ""
                    lblMsg.Text = ""
                    Btnadd1.Enabled = True
                    cmbCurrency.Enabled = False
                    txtExRate.Enabled = False
                    GridView1.Columns(0).Visible = True
                    If DDlBuyer.SelectedValue = "0" Then
                        lblErrorMsg.Text = "Buyer Field is Mandatory."
                        lblMsg.Text = ""
                        DDlBuyer.Focus()
                    Else
                        panel1.Visible = True
                    End If
                End If
            Else
                
                lblErrorMsg.Text = ""
                lblMsg.Text = ""
                If DDlBuyer.SelectedValue = "0" Then
                    lblErrorMsg.Text = "Buyer Field is Mandatory."
                    lblMsg.Text = ""
                Else
                    RbProduct.Focus()
                    If txtSO_NO.Text = "" Then
                        ELSaleOrderMfg.Sale_Order_Number = 0
                    Else
                        ELSaleOrderMfg.Sale_Order_Number = txtSO_NO.Text
                    End If
                    dt = BLSalesorderMfg.GetSaleOrderView(ELSaleOrderMfg)
                    If dt.Rows.Count > 0 Then
                        panel1.Visible = True
                        cmbCurrency.Enabled = False
                        txtExRate.Enabled = False
                        Btnadd1.Enabled = True
                    Else
                        panel1.Visible = True
                        GridView1.Visible = False
                        cmbCurrency.Enabled = True
                        txtExRate.Enabled = True
                        GridView1.Columns(0).Visible = True
                        Btnadd1.Enabled = True
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub CheckAll()
        If CType(GridViewSO.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GridViewSO.Rows
                CType(grid.FindControl("chkbox"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GridViewSO.Rows
                CType(grid.FindControl("chkbox"), CheckBox).Checked = False
            Next
        End If
    End Sub
    'Code for add product to a buyer by Nitin 08/10/2012
    Protected Sub Btnadd1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd1.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                lblErrorMsg1.Text = ""
                LblMsg1.Text = ""
                ELSaleOrderMfg.RBProduct = RbProduct.SelectedValue
                ELSaleOrderMfg.Product_ID1 = DDLProduct.SelectedValue
                ELSaleOrderMfg.Sale_Order_Number = txtSO_NO.Text
                ViewState("Product_ID") = DDLProduct.SelectedValue
                If txtQuantity.Text = "" Then
                    ELSaleOrderMfg.Quantity_Ordered1 = 0.0
                Else
                    ELSaleOrderMfg.Quantity_Ordered1 = txtQuantity.Text
                End If
                If txtEstimatedprice.Text = "" Then
                    ELSaleOrderMfg.Currency_Rate = 0.0
                Else
                    ELSaleOrderMfg.Currency_Rate = txtEstimatedprice.Text
                End If
                ELSaleOrderMfg.EstimatedValue = ELSaleOrderMfg.Quantity_Ordered1 * ELSaleOrderMfg.Currency_Rate

                ELSaleOrderMfg.Currency_Code = cmbCurrency.SelectedValue
                ELSaleOrderMfg.Currency_Factor = txtExRate.Text
                If Btnadd1.Text = "ADD PRODUCT" Then
                    dt = BLSalesorderMfg.CheckDuplicateforProduct(ELSaleOrderMfg)
                    If dt.Rows.Count > 0 Then
                        lblErrorMsg1.Text = "Data already exists."
                        LblMsg1.Text = ""
                    Else
                        BLSalesorderMfg.InsertSODetails(ELSaleOrderMfg)
                        LblMsg1.Text = "Data Saved Successfully."
                        lblErrorMsg1.Text = ""
                        cmbCurrency.Enabled = False
                        txtExRate.Enabled = False
                        BtnClose.Enabled = True
                        Clear1()
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        Display()
                    End If
                ElseIf Btnadd1.Text = "UPDATE" Then
                    ELSaleOrderMfg.SODetailSubID = ViewState("SODetailSubID")
                    ELSaleOrderMfg.Sales_Order_ID1 = ViewState("Sales_Order_ID")
                    BLSalesorderMfg.Update(ELSaleOrderMfg)
                    LblMsg1.Text = "Data Updated Successfully."
                    lblErrorMsg1.Text = ""
                    cmbCurrency.Enabled = True
                    txtExRate.Enabled = True
                    BtnClose.Enabled = True
                    Clear1()
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    Display()
                    Btnadd1.Text = "ADD PRODUCT"
                    BtnClose.Text = "CLOSE"
                    BtnView1.Text = "VIEW PRODUCT"
                    BtnClose.Enabled = True
                    cmbCurrency.Enabled = False
                    txtExRate.Enabled = False
                End If
            Catch ex As Exception
                lblErrorMsg1.Text = "Enter correct data."
            End Try
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
            lblMsg.Text = ""
        End If
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        If BtnClose.Text = "BACK" Then
            Display()
            Btnadd1.Text = "ADD"
            BtnClose.Text = "CLOSE"
            lblErrorMsg1.Text = ""
            LblMsg1.Text = ""
            Clear1()
        ElseIf BtnClose.Text = "CLOSE" Then
            panel1.Visible = False
            lblErrorMsg1.Text = ""
            LblMsg1.Text = ""
        End If
    End Sub
    'Code for auto fill exchange rate  By Nitin 14/08/2012
    Protected Sub cmbCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCurrency.SelectedIndexChanged
        Dim MC1 As New MultiCurrencyManager
        Dim MCD As MultiCurrency = MC1.GetMulticurrencyRate(CInt(IIf(cmbCurrency.SelectedValue.ToString = "", 0, cmbCurrency.SelectedValue.ToString)))
        txtExRate.Text = MCD.BuyConversionRate
    End Sub
    Protected Sub BtnView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView1.Click
        If BtnView1.Text = "BACK" Then
            lblErrorMsg1.Text = ""
            LblMsg1.Text = ""
            GridView1.PageIndex = ViewState("PageIndex")
            Display()
            Clear1()
            GridView1.Visible = True
            BtnView1.Text = "VIEW PRODUCT"
            Btnadd1.Text = "ADD PRODUCT"
            cmbCurrency.Enabled = False
            txtExRate.Enabled = False
            BtnClose.Enabled = True
        ElseIf BtnView1.Text = "VIEW PRODUCT" Then
            lblErrorMsg1.Text = ""
            LblMsg1.Text = ""
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            Display()
            BtnClose.Enabled = True
        End If
    End Sub

    Protected Sub DDLProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLProduct.SelectedIndexChanged
        Try
            ELSaleOrderMfg.Product_ID = DDLProduct.SelectedValue
            dt = BLSalesorderMfg.EstimatedRate(ELSaleOrderMfg)
            If dt.Rows(0).Item("New_Sale_Rate").ToString = "" Then
                txtEstimatedprice.Text = ""
            Else
                txtEstimatedprice.Text = Format(dt.Rows(0).Item("New_Sale_Rate"), "0.00").ToString
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub RbProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbProduct.SelectedIndexChanged
        txtEstimatedprice.Text = ""
        txtQuantity.Text = ""
    End Sub

    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try

            Dim check As String = ""
            Dim id As String = ""

            Dim Count1 As Integer = 0
            For Each Grid As GridViewRow In GridViewSO.Rows

                If CType(Grid.FindControl("Chkbox"), CheckBox).Checked = True Then
                    check = CType(Grid.FindControl("lblSales_Order_ID"), Label).Text
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

                Dim qrystring As String = "Mfg_Rpt_SaleOrder.aspx?" & "&id=" & id
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Else
                lblErrorMsg1.Text = "Please select the records to print."
                lblMsg.Text = ""
            End If

        Catch ex As Exception
            lblErrorMsg1.Text = "Please select the records from gridview. "
        End Try
    End Sub
End Class
