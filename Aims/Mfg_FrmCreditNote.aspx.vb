
Partial Class Mfg_FrmCreditNote
    Inherits BasePage
    Dim el As New Mfg_ELCreditNote
    Dim bl As New Mfg_BLCreditNote

    Dim dt, dt1 As New Data.DataTable

    Protected Sub ddlinvoice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlinvoice.SelectedIndexChanged
        Dim s As String
        s = ddlinvoice.SelectedItem.Text
        el.Invoiveid = ddlinvoice.SelectedValue
        'el.InvoiveType = ddlinvoice.SelectedItem.Text
        Dim parts As String() = s.Split(New Char() {":"})
        el.InvoiveType = parts(1).ToString()
        dt = bl.GetDetails(el)
        If dt.Rows.Count > 0 Then
            txtName.Text = dt.Rows(0).Item("Currency_Name")
            txtExchnageRate.Text = dt.Rows(0).Item("Buy_Conversion_Rate")
            txtSupplierBuyer.Text = dt.Rows(0).Item("Name")
            el.Supplier_Buyer = dt.Rows(0).Item("PartyAutoNo")
            el.Currency = dt.Rows(0).Item("Currency_Code")
        Else
            txtName.Text = ""
            txtExchnageRate.Text = ""
            txtSupplierBuyer.Text = ""
            el.Supplier_Buyer = 0
            el.Currency = 0
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Display()
    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblGreen.Text = " "
            lblRed.Text = " "
            Dim s As String
            s = ddlinvoice.SelectedItem.Text
            el.Invoiveid = ddlinvoice.SelectedValue
            'el.InvoiveType = ddlinvoice.SelectedItem.Text
            Dim parts As String() = s.Split(New Char() {":"})
            el.InvoiveType = parts(1).ToString()
            dt = bl.GetDetails(el)
            txtName.Text = dt.Rows(0).Item("Currency_Name")
            txtExchnageRate.Text = dt.Rows(0).Item("Buy_Conversion_Rate")
            txtSupplierBuyer.Text = dt.Rows(0).Item("Name")
            el.Supplier_Buyer = dt.Rows(0).Item("PartyAutoNo")
            el.Currency = dt.Rows(0).Item("Currency_Code")
            el.Amount = txtAmount.Text
            el.Remarks = TxtRemarks.Text
            el.ExchangeRate = txtExchnageRate.Text
            If btnadd.Text = "UPDATE" Then
                el.id = ViewState("Payments_Id")
                'dt = bl.CheckDuplicate(s)
                'If dt.Rows.Count > 0 Then
                '    lblRed.Text = "Data already exists."
                '    lblGreen.Text = " "
                '    'clear()
                'Else
                bl.Update(el)
                btnadd.Text = "ADD"
                GridView1.Visible = True
                btnDet.Text = "VIEW"
                'lblGreen.Visible = True
                lblRed.Text = " "
                clear()
                lblGreen.Text = "Data Updated Successfully."
                txtName.ReadOnly = False
                txtName.Focus()
                GridView1.PageIndex = ViewState("PageIndex")
                Display()
                'End If
            ElseIf btnadd.Text = "ADD" Then

                'dt = bl.CheckDuplicate(s)
                'If dt.Rows.Count > 0 Then
                '    'lblRed.Visible = True
                '    lblRed.Text = "Data already exists."
                '    lblGreen.Text = " "
                '    'clear()
                'Else
                bl.Insert(el)
                btnadd.Text = "ADD"
                lblRed.Text = " "
                'lblGreen.Visible = True
                lblGreen.Text = "Data Saved Successfully."
                txtName.ReadOnly = False
                clear()

                'End If
                GridView1.Enabled = True
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                Display()
            End If

        Else
            lblRed.Text = "You do not belong to this branch, Cannot add/update data."
            lblGreen.Text = ""
        End If
        
       
    End Sub
    Sub Display()
        el.id = 0
        dt = bl.GetGridData(el)
        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
        Else
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
        End If
    End Sub
    Sub clear()
        txtAmount.Text = ""
        TxtRemarks.Text = ""

    End Sub

    Protected Sub btnDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click
        'LinkButton1.Focus()
        lblGreen.Text = ""
        lblRed.Text = ""
        If btnDet.Text <> "BACK" Then
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            Display()
            GridView1.Visible = True
        Else
            clear()
            btnDet.Text = "VIEW"
            btnadd.Text = "ADD"
            GridView1.PageIndex = ViewState("PageIndex")
            Display()
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Payments_Id") = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            el.id = ViewState("Payments_Id")
            If bl.ChangeFlag(el) Then
                lblRed.Text = ""
                lblGreen.Text = "Data Deleted Successfully."
                ddlinvoice.Focus()
                GridView1.PageIndex = ViewState("PageIndex")
                Display()
                GridView1.Enabled = True
            End If
        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblRed.Text = ""
            lblGreen.Text = ""
            ddlinvoice.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblInvoiceId"), Label).Text
            ViewState("Payments_Id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
            txtName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCurrencyName"), Label).Text
            txtExchnageRate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblExrate"), Label).Text
            txtAmount.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAmt"), Label).Text
            txtSupplierBuyer.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblName"), Label).Text
            TxtRemarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
            btnadd.Text = "UPDATE"
            btnDet.Text = "BACK"
            el.id = ViewState("Payments_Id")
            dt = bl.GetGridData(el)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = False
        Else
            lblRed.Text = "You do not belong to this branch, Cannot edit data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlinvoice.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        lblRed.Text = ""
        lblGreen.Text = ""
    End Sub
End Class
