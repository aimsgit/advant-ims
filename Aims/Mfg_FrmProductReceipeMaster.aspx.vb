
Partial Class Mfg_FrmProductReceipeMaster
    Inherits BasePage
    Dim EL As New Mfg_ELProductReceipeMaster
    Dim BL As New Mfg_BLProductReceipe
    Dim dt As New DataTable

    Protected Sub InsertAddDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertAddDetails.Click
        If DDLProduct.SelectedValue = 0 Then
            msginfo.Text = "Please Select the Product Field."
            lblmsg.Text = ""
            lblGreen.Text = ""
            lblRed.Text = ""
        Else
            panel2.Visible = True
            GvPRD.Visible = False
            panel5.Visible = False
            DDLProduct.Enabled = False
            msginfo.Text = ""
            lblmsg.Text = ""
            lblGreen.Text = ""
            lblRed.Text = ""
        End If
       
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        panel2.Visible = False
    End Sub
    Protected Sub InsertPRD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertPRD.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Product = DDLProduct.SelectedValue
            EL.RMPart = DDLRM.SelectedValue
            EL.Unit = ddlUnit.SelectedValue
            EL.CF = TxtConv.Text
            EL.Quantity = txtQuantity.Text
            EL.Sequence = txtSequence.Text
            If txtwastage.Text = "" Then
                EL.Wastage = 0
            Else
                EL.Wastage = txtwastage.Text
            End If

            If InsertPRD.Text = "UPDATE" Then
                EL.Id = ViewState("Recepe_Code")
                'dt = BL.GetDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    lblGreen.Text = ""
                    lblRed.Text = "Data already exists"
                Else
                    BL.UpdateProductReceipe(EL)
                    GvPRD.Visible = True
                    InsertPRD.Text = "ADD"
                    ViewPRD.Text = "VIEW"
                    clear()
                    lblRed.Text = ""
                    GvPRD.PageIndex = ViewState("PageIndex")
                    display()
                    lblGreen.Text = "Data Updated Successfully."

                    display()
                End If
            ElseIf InsertPRD.Text = "ADD" Then
                EL.Id = 0
                'dt = BL.GetDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    lblGreen.Text = ""
                    lblRed.Text = "Data already exists"
                Else
                    BL.InsertProductReceipe(EL)
                    InsertPRD.Text = "ADD"
                    display()
                    clear()
                    lblRed.Text = ""
                    ViewState("PageIndex") = 0
                    GvPRD.PageIndex = 0
                    lblGreen.Text = "Data Saved Successfully."
                    panel2.Visible = True
                End If
            End If
        Else
            lblRed.Text = "You do not belong to this branch, Cannot add data."
            lblGreen.Text = ""
        End If
    End Sub
    'code by Anchala on 19-10-12
    'method for display 
    Sub display()
        Dim dt As New DataTable
        EL.Id = 0
        EL.Product = DDLProduct.SelectedValue
        dt = BL.getProductReceipe(EL)
        If dt.Rows.Count <> 0 Then
            GvPRD.DataSource = dt
            GvPRD.DataBind()
            GvPRD.Visible = True
            GvPRD.Enabled = True
            panel2.Visible = True
        Else
            lblGreen.Text = ""
            lblRed.Text = "No Records to display."
            GvPRD.Visible = False
            panel2.Visible = True
        End If
    End Sub
    Sub clear()
        TxtConv.Text = ""
        txtQuantity.Text = ""
        txtSequence.Text = ""
        txtwastage.Text = ""
    End Sub

    Protected Sub ViewPRD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewPRD.Click
        LinkButton1.Focus()
        If ViewPRD.Text <> "BACK" Then
            lblGreen.Text = ""
            lblRed.Text = ""
            ViewState("PageIndex") = 0
            GvPRD.PageIndex = 0
            display()
            panel2.Visible = True
        Else
            display()
            lblGreen.Text = ""
            lblRed.Text = ""
            GvPRD.Enabled = True
            GvPRD.PageIndex = ViewState("PageIndex")
            clear()
            ViewPRD.Text = "VIEW"
            InsertPRD.Text = "ADD"
            panel2.Visible = True
        End If
    End Sub

    Protected Sub GvPRD_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvPRD.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Recepe_Code") = CType(GvPRD.Rows(e.RowIndex).Cells(1).FindControl("HiddenField1"), HiddenField).Value
            EL.Id = ViewState("Recepe_Code")
            BL.DeteteProductReceipe(EL)
            lblGreen.Text = "Data Deleted Successfully."
            display()

            GvPRD.PageIndex = ViewState("PageIndex")
        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
            panel2.Visible = True
        End If
    End Sub

    Protected Sub GvPRD_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvPRD.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblGreen.Text = ""
            lblRed.Text = ""
            DDLRM.SelectedValue = CType(GvPRD.Rows(e.NewEditIndex).FindControl("lblARM1"), Label).Text
            ddlUnit.SelectedValue = CType(GvPRD.Rows(e.NewEditIndex).FindControl("lblUnit1"), Label).Text
            TxtConv.Text = CType(GvPRD.Rows(e.NewEditIndex).FindControl("lblConv1"), Label).Text
            txtQuantity.Text = CType(GvPRD.Rows(e.NewEditIndex).FindControl("lblQuantity1"), Label).Text
            txtSequence.Text = CType(GvPRD.Rows(e.NewEditIndex).FindControl("lblSequence1"), Label).Text
            txtwastage.Text = CType(GvPRD.Rows(e.NewEditIndex).FindControl("lblWastage1"), Label).Text
            ViewState("Recepe_Code") = CType(GvPRD.Rows(e.NewEditIndex).FindControl("HiddenField1"), HiddenField).Value
            InsertPRD.Text = "UPDATE"
            EL.Id = ViewState("Recepe_Code")
            EL.Product = DDLProduct.SelectedValue
            dt = BL.getProductReceipe(EL)
            GvPRD.DataSource = dt
            GvPRD.DataBind()
            e.Cancel = True
            GvPRD.Enabled = False
            GvPRD.Visible = True
            ViewPRD.Text = "BACK"
            ViewPRD.Visible = True
            panel2.Visible = True

        Else
            lblRed.Text = "You do not belong to this branch, Cannot edit data."
            lblGreen.Text = ""
        End If
    End Sub



    Protected Sub ViewProducyReceipe_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewProducyReceipe.Click
        If ViewProducyReceipe.Text <> "BACK" Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GvAddPRD.PageIndex = 0
            displayProductreceipe()
            panel2.Visible = False
            panel5.Visible = True
            DDLProduct.Enabled = True
        Else
            displayProductreceipe()
            lblmsg.Text = ""
            msginfo.Text = ""
            GvAddPRD.Enabled = True
            GvAddPRD.PageIndex = ViewState("PageIndex")
            clear()
            ViewProducyReceipe.Text = "VIEW"
            InsertProducyReceipe.Text = "ADD"
            panel2.Visible = False
            panel5.Visible = True
            DDLProduct.Enabled = True
        End If
    End Sub
    Sub displayProductReceipe()
        Dim dt As New DataTable
        EL.Id = 0
        EL.Product = DDLProduct.SelectedValue
        dt = BL.getProductDetailsReceipe(EL)
        If dt.Rows.Count <> 0 Then
            GvAddPRD.DataSource = dt
            GvAddPRD.DataBind()
            GvAddPRD.Visible = True
            GvAddPRD.Enabled = True
            panel2.Visible = False
        Else
            lblmsg.Text = ""
            msginfo.Text = "No Records to display."
            GvAddPRD.Visible = False
            panel2.Visible = False
        End If
    End Sub

    Protected Sub DDLProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLProduct.SelectedIndexChanged
        panel2.Visible = False
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        panel5.Visible = False
        panel2.Visible = False
        DDLProduct.Focus()
        DDLProduct.Enabled = True
    End Sub
End Class
