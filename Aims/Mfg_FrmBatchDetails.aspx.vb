
Partial Class Mfg_FrmBatchDetails
    Inherits BasePage
    Dim Bl As New Mfg_BLBatchDetails
    Dim El As New Mfg_ELBatchDetails
    Dim dt As New DataTable

    Protected Sub DDLProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLProduct.SelectedIndexChanged
        Txtexpirtdate.Focus()
        If DDLProduct.SelectedValue <> 0 Then


            El.Productid = DDLProduct.SelectedValue
            dt = Bl.getDetails(El)
            If dt.Rows(0).Item("New_Deal_Qty").ToString = "" Then
                txtDealQty.Text = ""
            Else
                txtDealQty.Text = Format(dt.Rows(0).Item("New_Deal_Qty"), "0.00")
            End If

            If dt.Rows(0).Item("New_Deal_Free").ToString = "" Then
                TxtDealFree.Text = ""
            Else
                TxtDealFree.Text = Format(dt.Rows(0).Item("New_Deal_Free"), "0.00")
            End If
            txtpacking.Text = dt.Rows(0).Item("Packing_Details").ToString
            El.Packing = txtpacking.Text

            If dt.Rows(0).Item("New_Purchase_Rate").ToString = "" Then
                TxtPurchaseRate.Text = ""
            Else
                TxtPurchaseRate.Text = Format(dt.Rows(0).Item("New_Purchase_Rate"), "0.00")
            End If
            If dt.Rows(0).Item("Purchase_VAT_Percent").ToString = "" Then
                txtvat.Text = 0.0
            Else
                txtvat.Text = Format(dt.Rows(0).Item("Purchase_VAT_Percent"), "0.00")
            End If
            If dt.Rows(0).Item("Purchase_CST_Percent").ToString = "" Then
                Txtcst.Text = 0.0
            Else
                Txtcst.Text = Format(dt.Rows(0).Item("Purchase_CST_Percent"), "0.00")
            End If
            If dt.Rows(0).Item("Purchase_Discount_Percent").ToString = "" Then
                TxtDiscount.Text = ""
            Else
                TxtDiscount.Text = Format(dt.Rows(0).Item("Purchase_Discount_Percent"), "0.00")
            End If
            If dt.Rows(0).Item("New_Sale_Rate").ToString = "" Then
                TxtSaleRate.Text = ""
            Else
                TxtSaleRate.Text = Format(dt.Rows(0).Item("New_Sale_Rate"), "0.00")
            End If
            If dt.Rows(0).Item("New_Sale_MRP").ToString = "" Then
                Txtmrp.Text = ""
            Else
                Txtmrp.Text = Format(dt.Rows(0).Item("New_Sale_MRP"), "0.00")
            End If
        Else
            txtDealQty.Text = ""
            TxtDealFree.Text = ""
            txtpacking.Text = ""
            TxtPurchaseRate.Text = ""
            txtvat.Text = ""
            Txtcst.Text = ""
            TxtDiscount.Text = ""
            TxtSaleRate.Text = ""
            Txtmrp.Text = ""
            Txtexpirtdate.Text = ""
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        TxtBatch.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                El.Batch = TxtBatch.Text
                El.Productid = DDLProduct.SelectedValue
                If TxtMfgdate.Text = "" Then
                    El.Mfgdate = "#1/1/3000#"
                Else
                    El.Mfgdate = TxtMfgdate.Text
                End If
                If Txtexpirtdate.Text = "" Then
                    El.Expiry = "#1/1/3000#"
                Else
                    El.Expiry = Txtexpirtdate.Text
                    If CType(TxtMfgdate.Text, Date) > CType(Txtexpirtdate.Text, Date) Then
                        msginfo.Text = ""
                        msginfo.Text = "'Mfg' date should be lesser than 'Expiry' date."
                        TxtMfgdate.Focus()
                        Exit Sub
                    End If
                End If
                
                El.Packing = txtpacking.Text
                AssignEntity()
                El.Hold = ddlHold.SelectedValue
                If btnAdd.Text = "UPDATE" Then
                    El.id = ViewState("Batch_ID")
                    dt = Bl.GetDuplicate(El)

                    If dt.Rows.Count > 0 Then
                        lblmsg.Text = ""
                        msginfo.Text = "Data already exists"

                        TxtBatch.Focus()
                    Else
                        Bl.UpdateRecord(El)
                        GVBatchDetails.Visible = True
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"
                        clear()
                        msginfo.Text = ""
                        GVBatchDetails.PageIndex = ViewState("PageIndex")
                        display()
                        lblmsg.Text = "Data Updated Successfully."
                        TxtMfgdate.Text = Format(Today, "dd-MMM-yyyy")
                        TxtBatch.Focus()
                        display()
                    End If

                ElseIf btnAdd.Text = "ADD" Then
                    El.id = 0
                    dt = Bl.GetDuplicate(El)
                    If dt.Rows.Count > 0 Then
                        lblmsg.Text = ""
                        msginfo.Text = "Data already exists"

                        TxtBatch.Focus()
                    Else

                        Bl.InsertRecord(El)
                        btnAdd.Text = "ADD"
                        display()
                        clear()
                        msginfo.Text = ""
                        ViewState("PageIndex") = 0
                        GVBatchDetails.PageIndex = 0
                        lblmsg.Text = "Data Saved Successfully."
                        TxtMfgdate.Text = Format(Today, "dd-MMM-yyyy")
                        TxtBatch.Focus()


                    End If
                End If
            Catch ex As Exception
                msginfo.Text = "Date is Not valid Date."
            End Try

        Else
            lblmsg.Text = "You do not belong to this branch, Cannot add data."
            msginfo.Text = ""
        End If
    End Sub
    Sub AssignEntity()
        If txtDealQty.Text = "" Then
            El.DealQty = 0
        Else
            El.DealQty = txtDealQty.Text
        End If
        If TxtDealFree.Text = "" Then
            El.DealFree = 0
        Else
            El.DealFree = TxtDealFree.Text
        End If
        If TxtPurchaseRate.Text = "" Then
            El.PRate = 0
        Else
            El.PRate = TxtPurchaseRate.Text
        End If
        If txtvat.Text = "" Then
            El.vat = 0
        Else
            El.vat = txtvat.Text
        End If
        If Txtcst.Text = "" Then
            El.cst = 0
        Else
            El.cst = Txtcst.Text
        End If
        If TxtDiscount.Text = "" Then
            El.PurchaseDis = 0
        Else
            El.PurchaseDis = TxtDiscount.Text
        End If
        If TxtSaleRate.Text = "" Then
            El.SaleRate = 0
        Else
            El.SaleRate = TxtSaleRate.Text
        End If
        If Txtmrp.Text = "" Then
            El.MPR = 0
        Else
            El.MPR = Txtmrp.Text
        End If


    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVBatchDetails.PageIndexChanging
        GVBatchDetails.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVBatchDetails.PageIndex
        display()
        GVBatchDetails.Visible = True
        msginfo.Text = ""
        lblmsg.Text = ""
    End Sub

    'code by Anchala on 08-08-12
    'method for display 
    Sub display()
        El.id = 0
        El.Productid = DDLProduct.SelectedValue
        dt = Bl.GetBatchDetails(El)

        If dt.Rows.Count <> 0 Then
            GVBatchDetails.DataSource = dt
            GVBatchDetails.DataBind()
            For Each rows As GridViewRow In GVBatchDetails.Rows
                If CType(rows.FindControl("lbledate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lbledate"), Label).Text = ""
                End If
                If CType(rows.FindControl("lbledate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lbledate"), Label).Text = ""
                End If
            Next
            GVBatchDetails.Visible = True
            GVBatchDetails.Enabled = True
        Else
            lblmsg.Text = ""
            msginfo.Text = "No Records to display."
            GVBatchDetails.Visible = False
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        LinkButton1.Focus()
        If btnView.Text <> "BACK" Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GVBatchDetails.PageIndex = 0

            display()
        Else
            display()
            lblmsg.Text = ""
            msginfo.Text = ""
            GVBatchDetails.Enabled = True
            GVBatchDetails.PageIndex = ViewState("PageIndex")
            clear()
            TxtMfgdate.Text = Format(Today, "dd-MMM-yyyy")
            btnView.Text = "VIEW"
            btnAdd.Text = "ADD"
        End If
    End Sub
    Sub clear()
        TxtBatch.Text = ""
        txtDealQty.Text = ""
        TxtDealFree.Text = ""
        txtpacking.Text = ""
        TxtPurchaseRate.Text = ""
        txtvat.Text = ""
        Txtcst.Text = ""
        TxtDiscount.Text = ""
        TxtSaleRate.Text = ""
        Txtmrp.Text = ""
        Txtexpirtdate.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtBatch.Focus()
        If Not Page.IsPostBack Then
            TxtMfgdate.Text = Format(Today, "dd-MMM-yyyy")
            ViewState("status") = "load"
            TxtBatch.Focus()
        End If

    End Sub

    Protected Sub GVBatchDetails_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVBatchDetails.PageIndexChanging

        GVBatchDetails.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVBatchDetails.PageIndex
       
        display()
        GVBatchDetails.Visible = True
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub

   
    'code by Anchala on 08-08-12
    'method for page deleting
    Protected Sub GVBatchDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVBatchDetails.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Batch_ID") = CType(GVBatchDetails.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            El.id = ViewState("Batch_ID")
            Bl.DeleteRecord(El.id)
            lblmsg.Text = "Data Deleted Successfully."
            display()
            TxtBatch.Focus()
            GVBatchDetails.PageIndex = ViewState("PageIndex")
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub
   
    'code by Anchala on 08-08-12
    'method for editing

    Protected Sub GVBatchDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVBatchDetails.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblmsg.Text = ""
            msginfo.Text = ""
            TxtBatch.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lblbatch"), Label).Text

            If DDLProduct.SelectedValue = "Select" Then
                DDLProduct.SelectedValue = El.Productid
            Else
                DDLProduct.SelectedValue = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lblproduct"), Label).Text
            End If

            TxtMfgdate.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lblmdate"), Label).Text
            Txtexpirtdate.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lbledate"), Label).Text
            txtDealQty.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lbldealqty"), Label).Text
            TxtDealFree.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lbldealfree"), Label).Text
           
            txtpacking.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lblpacking"), Label).Text
            
            TxtPurchaseRate.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lblprate"), Label).Text
            txtvat.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lblvat"), Label).Text
            Txtcst.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lblcst"), Label).Text
            TxtDiscount.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lblpdiscount"), Label).Text
            TxtSaleRate.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lblsrate"), Label).Text
            Txtmrp.Text = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lblmrp"), Label).Text
            If ddlHold.SelectedValue = "0" Then
                ddlHold.SelectedValue = El.Hold
            Else
                ddlHold.SelectedItem.Value = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("lblhold"), Label).Text
            End If
            ViewState("Batch_ID") = CType(GVBatchDetails.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
            btnAdd.Text = "UPDATE"
            El.id = ViewState("Batch_ID")
           
            dt = Bl.GetBatchDetails(El)
            GVBatchDetails.DataSource = dt
            GVBatchDetails.DataBind()
            e.Cancel = True

            GVBatchDetails.Enabled = False
            btnView.Text = "BACK"
            btnView.Visible = True
            For Each rows As GridViewRow In GVBatchDetails.Rows
                If CType(rows.FindControl("lbledate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lbledate"), Label).Text = ""
                End If
            Next

        Else
            msginfo.Text = "You do not belong to this branch, Cannot edit data."
            lblmsg.Text = ""
        End If
    End Sub
    'code by Anchala on 08-08-12
    'method for page indexing

    Protected Sub GVBatchDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVBatchDetails.SelectedIndexChanged
        GVBatchDetails.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVBatchDetails.PageIndex
        display()
        GVBatchDetails.DataBind()
        GVBatchDetails.Visible = True
    End Sub
    <System.Web.Services.WebMethod()> _
 Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
