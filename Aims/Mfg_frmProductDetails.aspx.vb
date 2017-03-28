
Partial Class Mfg_frmProductDetails
    Inherits BasePage
    Dim EL As New Mfg_ELProductDetails
    Dim BLL As New Mfg_BLProductDetails
    Dim dt As New DataTable


    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtProduct.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If RbTYPE.SelectedValue = "1" Then
                    EL.Type = 1
                ElseIf RbTYPE.SelectedValue = "2" Then
                    EL.Type = 2
                Else
                    EL.Type = 3
                End If
                EL.Product = txtProduct.Text
                EL.Code = txtCode.Text
                EL.Category = DropDownList1.SelectedValue
                EL.Description = ddlDescription.SelectedValue
                EL.Packing = txtPacking.Text
                EL.Supplier = ddlSupplier.SelectedValue
                EL.Company = ddlCompany.SelectedValue
                EL.Remarks = txtRemarks.Text
                If txtReorder.Text = "" Then
                    EL.Reorder = 0
                Else

                    EL.Reorder = txtReorder.Text
                End If
                EL.Unit = ddlUnit.SelectedValue
                EL.Purchase = ddlPurchase.SelectedValue
                If txtPurchase.Text = "" Then
                    EL.PDeal1 = 1
                Else
                    EL.PDeal1 = txtPurchase.Text
                End If
                If txtPurchase1.Text = "" Then
                    EL.PDeal2 = 0
                Else
                    EL.PDeal2 = txtPurchase1.Text
                End If
                If txtPurchaseRate.Text = "" Then
                    EL.PRate = 0
                Else
                    EL.PRate = txtPurchaseRate.Text
                End If
                If txtMRP.Text = "" Then
                    EL.MPR = 0
                Else
                    EL.MPR = txtMRP.Text
                End If

                If txtSales.Text = "" Then
                    EL.SaleRate = 0
                Else
                    EL.SaleRate = txtSales.Text
                End If

                If txtpurch.Text = "" Then
                    EL.PurchRate = 0
                Else
                    EL.PurchRate = txtpurch.Text
                End If
                If txtDiscount.Text = "" Then
                    EL.PurchaseDis = 0
                Else
                    EL.PurchaseDis = txtDiscount.Text
                End If

                EL.SalePlan = ddlsaletax.SelectedValue
                If txtoffperiod.Text = "" Then
                    EL.OfferPeriod = "1/1/9100"
                Else
                    EL.OfferPeriod = txtoffperiod.Text
                End If
                If Chkdislock.Checked = True Then
                    EL.Discount = "Y"
                Else
                    EL.Discount = "N"
                End If
                If txtsaleDiscount.Text = "" Then
                    EL.SaleDiscount = 0
                Else
                    EL.SaleDiscount = txtsaleDiscount.Text
                End If
                If txtsaleDeal.Text = "" Then
                    EL.SaleDeal1 = 1
                Else
                    EL.SaleDeal1 = txtsaleDeal.Text
                End If
                If txtSaleDeal1.Text = "" Then
                    EL.SaleDeal2 = 0
                Else
                    EL.SaleDeal2 = txtSaleDeal1.Text
                End If

                If btnSave.Text = "ADD" Then
                    dt = BLL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        lblerrmsg.Text = "Data already exists."
                        lblmsgifo.Text = " "
                    Else
                        BLL.InsertRecord(EL)
                        Clear()
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Saved Successfully."
                        btnSave.Text = "ADD"
                        GridProduct.Enabled = True
                        ViewState("PageIndex") = 0
                        GridProduct.PageIndex = 0
                        DispGrid()
                    End If
                ElseIf btnSave.Text = "UPDATE" Then
                    EL.id = ViewState("Product_Id")
                    dt = BLL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        lblerrmsg.Text = "Data already exists."
                        lblmsgifo.Text = " "
                    Else
                        BLL.UpdateRecord(EL)
                        lblerrmsg.Text = ""

                        lblmsgifo.Text = "Data Updated Successfully."
                        Clear()
                        btnSave.Text = "ADD"
                        GridProduct.Visible = True
                        btnDetails.Text = "VIEW"
                        Clear()
                        GridProduct.PageIndex = ViewState("PageIndex")
                        DispGrid()
                    End If
                End If
            Catch ex As Exception
                lblerrmsg.Text = "Enter correct Date."
                txtoffperiod.Focus()
                lblmsgifo.Text = ""
            End Try
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        LinkButton1.Focus()


      


        If btnDetails.Text = "VIEW" Then
            GridProduct.Enabled = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            'If txtName.Text = "" Then
            '    s.Name = 0
            'Else
            '    s.Name = txtName.Text
            'End If
            ViewState("PageIndex") = 0
            GridProduct.PageIndex = 0
            DispGrid()
        

            'Clear()
        ElseIf btnDetails.Text = "BACK" Then
            GridProduct.Enabled = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            Clear()
            GridProduct.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub

    Sub DispGrid()
        EL.id = 0
        EL.Product = txtProduct.Text
        dt = BLL.getProduct(EL)
        If dt.Rows.Count > 0 Then
            GridProduct.Enabled = True
            GridProduct.Visible = True
            GridProduct.DataSource = dt
            GridProduct.DataBind()
            For Each rows As GridViewRow In GridProduct.Rows
                If CType(rows.FindControl("lbloffer"), Label).Text = "01-Jan-9100" Then
                    CType(rows.FindControl("lbloffer"), Label).Text = ""
                End If
            Next
        Else
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
            GridProduct.Visible = False
        End If
    End Sub
    Sub dispProduct()
        EL.Product = txtProduct.Text
        dt = BLL.getProduct(EL)
        If dt.Rows.Count > 0 Then
            GridProduct.Enabled = True
            GridProduct.Visible = True
            GridProduct.DataSource = dt
            GridProduct.DataBind()
            For Each rows As GridViewRow In GridProduct.Rows
                If CType(rows.FindControl("lbloffer"), Label).Text = "01-Jan-9100" Then
                    CType(rows.FindControl("lbloffer"), Label).Text = ""
                End If
            Next
        Else
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
            GridProduct.Visible = False
        End If

    End Sub
    Sub Clear()
        txtProduct.Text = ""
        txtCode.Text = ""
        DropDownList1.ClearSelection()

        Chkdislock.Checked = False
        txtPacking.Text = ""
        txtReorder.Text = ""
        txtRemarks.Text = ""
      
        txtPurchaseRate.Text = ""
        txtMRP.Text = ""
        txtSales.Text = ""
        txtpurch.Text = ""
        txtDiscount.Text = ""
        'txtoffperiod.Text = ""
        txtsaleDiscount.Text = ""
       
    End Sub
   

    Protected Sub GridProduct_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridProduct.PageIndexChanging
        GridProduct.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridProduct.PageIndex
        DispGrid()
        GridProduct.Visible = True
        lblmsgifo.Text = " "
        lblerrmsg.Text = " "
    End Sub

    Protected Sub GridProduct_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridProduct.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GridProduct.Rows(e.RowIndex).FindControl("Label5"), HiddenField).Value
            BLL.DeleteProduct(EL)

            'lblGreen.Visible = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = "Data Deleted Successfully."
            Clear()
            GridProduct.PageIndex = ViewState("PageIndex")
            DispGrid()
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        RbTYPE.Focus()
        If Not IsPostBack Then
            txtoffperiod.Text = Format(Today, "dd-MMM-yyyy")
           
        End If
        txtsaleDeal.Text = "1"
        txtPurchase.Text = "1"
        txtSaleDeal1.Text = "0"
        txtPurchase1.Text = "0"

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

 
    Protected Sub GridProduct_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridProduct.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then

            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            btnSave.Text = "UPDATE"
            btnDetails.Visible = True
            btnDetails.Text = "BACK"
            GridProduct.Visible = True

            ViewState("Product_Id") = CType(GridProduct.Rows(e.NewEditIndex).FindControl("Label5"), HiddenField).Value
            txtProduct.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text


            txtCode.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblCode"), Label).Text
            If CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblCategory"), Label).Text = "" Then
                DropDownList1.SelectedValue = 0
            Else
                DropDownList1.SelectedValue = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblCategory"), Label).Text
            End If
            Dim a As String

            ddlDescription.SelectedValue = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lbldescId"), Label).Text
            txtPacking.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblpacking"), Label).Text
            CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblSupp"), Label).Text = a
            If CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblSupp"), Label).Text = "" Then
                ddlSupplier.SelectedValue = 0
            Else
                ddlSupplier.SelectedValue = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblSupp"), Label).Text
            End If

            ddlCompany.SelectedValue = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblManuf"), Label).Text
            txtReorder.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblReorder"), Label).Text
            txtRemarks.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
            ddlUnit.SelectedValue = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblUnitid"), Label).Text
            ddlPurchase.SelectedValue = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblPurchtxtplan"), Label).Text
            txtPurchase.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblpdeal1"), Label).Text
            txtPurchase1.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblpdeal2"), Label).Text
            txtPurchaseRate.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblPurchaseRate"), Label).Text
            txtMRP.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblMrp"), Label).Text
            txtSales.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblsales"), Label).Text
            txtpurch.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblpurch"), Label).Text
            txtDiscount.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblDiscount"), Label).Text
            ddlsaletax.SelectedValue = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lbltaxplan"), Label).Text
            txtoffperiod.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lbloffer"), Label).Text
            EL.Discount = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblDiscountlock"), Label).Text
            If EL.Discount = "Yes" Then
                Chkdislock.Checked = True
            Else
                Chkdislock.Checked = False
            End If
            txtsaleDiscount.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblsalediscount"), Label).Text
            txtsaleDeal.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblsdeal1"), Label).Text
            txtSaleDeal1.Text = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblsdeal2"), Label).Text
            EL.Type = CType(GridProduct.Rows(e.NewEditIndex).FindControl("lblType"), Label).Text
            If EL.Type = 1 Then
                RbTYPE.SelectedValue = 1
            ElseIf EL.Type = 2 Then
                RbTYPE.SelectedValue = 2
            ElseIf EL.Type = 3 Then
                RbTYPE.SelectedValue = 3
            End If
            If Chkdislock.Checked = True Then
                txtsaleDiscount.Enabled = False
            Else
                txtsaleDiscount.Enabled = True
            End If
            EL.id = ViewState("Product_Id")
            EL.Product = txtProduct.Text
            dt = BLL.getProduct(EL)
            GridProduct.DataSource = dt
            GridProduct.DataBind()
            GridProduct.Enabled = False
            GridProduct.Visible = True
            For Each rows As GridViewRow In GridProduct.Rows
                If CType(rows.FindControl("lbloffer"), Label).Text = "01-Jan-9100" Then
                    CType(rows.FindControl("lbloffer"), Label).Text = ""
                End If
            Next

        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
            lblmsgifo.Text = ""
        End If
    End Sub

   
    Protected Sub ddlDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDescription.TextChanged
        ddlDescription.Focus()
    End Sub

    Protected Sub ddlSupplier_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSupplier.TextChanged
        ddlSupplier.Focus()
    End Sub

    Protected Sub ddlCompany_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCompany.TextChanged
        ddlCompany.Focus()
    End Sub

    Protected Sub ddlUnit_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUnit.TextChanged
        ddlUnit.Focus()
    End Sub

    Protected Sub ddlPurchase_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPurchase.TextChanged
        ddlPurchase.Focus()
    End Sub

    Protected Sub ddlsaletax_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsaletax.TextChanged
        ddlsaletax.Focus()
    End Sub

    Protected Sub txtoffperiod_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtoffperiod.TextChanged
        txtoffperiod.Focus()
    End Sub

    Protected Sub Chkdislock_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkdislock.CheckedChanged
        Chkdislock.Focus()
        If Chkdislock.Checked = True Then
            txtsaleDiscount.Enabled = False
        Else
            txtsaleDiscount.Enabled = True
        End If
    End Sub
End Class
