
Partial Class MfgFrmStockIssue
    Inherits BasePage
    Dim EL As New Mfg_ElStockIssue
    Dim dt As New DataTable
    Dim BL As New Mfg_BLStockIssue

    Protected Sub btnAdddet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdddet.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'EL.EntryDate = txtDate.Text
            EL.CV = txtConvNo.Text
            EL.PID = DDLPRODUCT.SelectedValue
            If txtDate.Text = "" Then
                EL.EntryDate = "01-01-1900"
            Else
                EL.EntryDate = txtDate.Text
            End If
            'txtExpiryDate.Text = Format("Expiry", "dd-MMM-yyyy")
            'dt = BL.getProductExpiry(EL)
            'If dt.Rows.Count > 0 Then
            '    txtExpiryDate.Text = ViewState("Expiry")
            'Else   
            '    txtExpiryDate.Text = ""
            'End If
            EL.PartyName = ddlPName.SelectedValue
            If txtReturnedQty.Text = "" Then
                EL.QtyReturned = 0
            Else
                EL.QtyReturned = txtReturnedQty.Text
            End If
            If txtQtyIssued.Text = "" Then
                EL.QtyIssued = 0
            Else
                EL.QtyIssued = txtQtyIssued.Text
            End If

            If btnAdddet.Text = "UPDATE" Then
                EL.id = ViewState("ID")
                'dt = BL.GetDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    lblGreen.Text = ""
                    lblRed.Text = "Data already exists"
                Else
                    BL.UpdateProductReceipe(EL)
                    GVStockIssueDetails.Visible = True
                    btnAdddet.Text = "ADD"
                    BtnViewDetails.Text = "VIEW"
                    clear()
                    lblRed.Text = ""
                    GVStockIssueDetails.PageIndex = ViewState("PageIndex")
                    display()
                    lblGreen.Text = "Data Updated Successfully."
                    display()
                End If
            ElseIf btnAdddet.Text = "ADD" Then
                EL.id = 0
                'dt = BL.GetDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    lblGreen.Text = ""
                    lblRed.Text = "Data already exists"
                Else
                    BL.InsertProductReceipe(EL)
                    btnAdddet.Text = "ADD"
                    btnView.Text = "VIEW"
                    display()
                    clear()
                    lblRed.Text = ""
                    ViewState("PageIndex") = 0
                    GVStockIssueDetails.PageIndex = 0
                    lblGreen.Text = "Data Saved Successfully."
                    TabPanel2.Enabled = True
                    TabPanel1.Enabled = False
                End If
            End If
        Else
            lblRed.Text = "You do not belong to this branch, Cannot add data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If ddlPName.SelectedValue = 0 Then
            lblRedM.Text = "Please select Party Type first."
            lblGreenM.Text = ""
            Exit Sub
        Else
            TabContainer1.ActiveTab = TabPanel2
            TabPanel2.Enabled = True
            TabPanel1.Enabled = False
            lblGreenM.Text = ""
            lblRedM.Text = ""
            txtConvNo.Text = "1.00"
            txtReturnedQty.Visible = False
            lblReturnQty.Visible = False
            'btnAdddet.Enabled = True
            GVStockIssueDetails.Visible = False

            'If HidInvoice.Text = "" Then
            '    dt = BL.GetInvoiceNo()
            '    HidInvoice.Text = dt.Rows(0).Item("InvoiceId").ToString
            '    HidInvoiceNO.Text = dt.Rows(0).Item("InvoiceNo").ToString
            'Else
            '    EL.InvoiceID = HidInvoice.Text
            'End If

        End If
    End Sub
    Sub display()
        Dim dt As New DataTable
        EL.id = 0
        EL.PartyType = cmbPType.SelectedValue
        EL.PartyName = ddlPName.SelectedValue
        dt = BL.getProductDetailsReceipe(EL)
        If dt.Rows.Count <> 0 Then
            GVStockIssueDetails.DataSource = dt
            GVStockIssueDetails.DataBind()
            GVStockIssueDetails.Visible = True
            GVStockIssueDetails.Enabled = True
            TabPanel2.Enabled = True
            TabPanel1.Enabled = False
            btnDetails.Text = "ADD DETAILS"
        Else
            lblGreen.Text = ""
            lblRed.Text = "No Records to display."
            GVStockIssue.Visible = False
            TabPanel2.Enabled = True
            TabPanel1.Enabled = False
        End If
    End Sub
   

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If btnView.Text <> "BACK" Then
            lblGreenM.Text = ""
            lblRedM.Text = ""
            ViewState("PageIndex") = 0
            GVStockIssue.PageIndex = 0
            display1()
            'TabPanel2.Enabled = True
            'TabPanel1.Enabled = False
          
        Else
            display1()
            lblGreenM.Text = ""
            lblRedM.Text = ""
            GVStockIssue.Enabled = True
            GVStockIssue.PageIndex = ViewState("PageIndex")
            clear()
            'TabPanel2.Enabled = True
            'TabPanel1.Enabled = False

        End If
    End Sub
    Sub Display1()
        Dim dt As New DataTable
        EL.id = 0
        EL.PartyType = cmbPType.SelectedValue
        EL.PartyName = ddlPName.SelectedValue
        dt = BL.getProductReceipe(EL)
        If dt.Rows.Count <> 0 Then
            GVStockIssue.DataSource = dt
            GVStockIssue.DataBind()
            GVStockIssue.Visible = True
            GVStockIssue.Enabled = True
            lblGreenM.Text = ""
            lblRedM.Text = ""
        Else
            lblGreenM.Text = ""
            lblRedM.Text = "No Records to display."
            GVStockIssue.Visible = False
            'TabPanel2.Enabled = False
            'TabPanel1.Enabled = True
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtConvNo.Text = "1.00"
        txtReturnedQty.Visible = False
        lblReturnQty.Visible = False
    End Sub

    Protected Sub DDLPRODUCT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLPRODUCT.SelectedIndexChanged
        Try
            EL.PID = DDLPRODUCT.SelectedValue
            dt = BL.getProductExpiry(EL)
            txtExpiryDate.Text = Format(dt.Rows(0).Item("Expiry"), "dd-MMM-yyy")
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnViewDetails.Click
        If BtnViewDetails.Text <> "BACK" Then
            lblGreen.Text = ""
            lblRed.Text = ""
            ViewState("PageIndex") = 0
            GVStockIssue.PageIndex = 0
            display()
            TabPanel2.Enabled = True
            TabPanel1.Enabled = False
        Else
            display()
            lblGreen.Text = ""
            lblRed.Text = ""
            GVStockIssue.Enabled = True
            GVStockIssue.PageIndex = ViewState("PageIndex")
            clear()
            BtnViewDetails.Text = "VIEW"
            btnAdddet.Text = "ADD"
            TabPanel2.Enabled = True
            TabPanel1.Enabled = False
        End If
    End Sub
    Sub clear()
        txtConvNo.Text = ""
        txtQtyIssued.Text = ""
        txtReturnedQty.Text = ""
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        TabPanel2.Enabled = False
        TabPanel1.Enabled = True
    End Sub

    Protected Sub GVStockIssueDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVStockIssueDetails.RowDeleting
        Dim rowsaffected As Integer
        lblGreen.Text = ""
        lblRed.Text = ""
        EL.id = CType(GVStockIssueDetails.Rows(e.RowIndex).FindControl("ID"), HiddenField).Value
        rowsaffected = BL.DeteteProductReceipe(EL)
        display()
        lblGreen.Text = "Record(s) Deleted Successfully."
    End Sub

    Protected Sub GVStockIssueDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVStockIssueDetails.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'Dim ID As Integer
            lblGreen.Text = ""
            lblRed.Text = ""
            DDLPRODUCT.SelectedValue = CType(GVStockIssueDetails.Rows(e.NewEditIndex).FindControl("lblPurchReturnId2"), Label).Text
            txtConvNo.Text = CType(GVStockIssueDetails.Rows(e.NewEditIndex).FindControl("lblConvNo"), Label).Text
            txtQtyIssued.Text = CType(GVStockIssueDetails.Rows(e.NewEditIndex).FindControl("lblIssuedQty"), Label).Text
            txtReturnedQty.Text = CType(GVStockIssueDetails.Rows(e.NewEditIndex).FindControl("lblReturnedQty"), Label).Text
            EL.PID = DDLPRODUCT.SelectedValue
            dt = BL.getProductExpiry(EL)
            If dt.Rows.Count > 0 Then
                txtExpiryDate.Text = Format(dt.Rows(0).Item("Expiry"), "dd-MMM-yyy")
            Else
                txtExpiryDate.Text = ""
            End If

            ViewState("ID") = CType(GVStockIssueDetails.Rows(e.NewEditIndex).FindControl("ID"), HiddenField).Value
            btnAdddet.Text = "UPDATE"
            EL.id = ViewState("ID")
            EL.PartyName = ddlPName.SelectedValue
            EL.PartyType = cmbPType.SelectedValue
            dt = BL.getProductDetailsReceipe(EL)
            GVStockIssueDetails.DataSource = dt
            GVStockIssueDetails.DataBind()
            e.Cancel = True
            GVStockIssueDetails.Enabled = False
            GVStockIssueDetails.Visible = True
            BtnViewDetails.Text = "BACK"
            BtnViewDetails.Visible = True
            TabPanel2.Visible = True
            TabPanel1.Enabled = False
            txtReturnedQty.Visible = True
            lblReturnQty.Visible = True

        Else
            lblRed.Text = "You do not belong to this branch, Cannot edit data."
            lblGreen.Text = ""
        End If
    End Sub

    Sub CheckAll()
        If CType(GVStockIssue.HeaderRow.FindControl("chkhdr"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVStockIssue.Rows
                CType(grid.FindControl("chkChild"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVStockIssue.Rows
                CType(grid.FindControl("chkChild"), CheckBox).Checked = False
            Next
        End If
    End Sub
 
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Try
            Dim check As String = ""
            Dim id As String = ""

            Dim Count1 As Integer = 0
            Dim PartyType As String
            Dim Partyname As String



            PartyType = cmbPType.SelectedValue
            Partyname = ddlPName.SelectedValue
            For Each Grid As GridViewRow In GVStockIssue.Rows

                If CType(Grid.FindControl("chkChild"), CheckBox).Checked = True Then
                    check = CType(Grid.FindControl("ID1"), HiddenField).Value
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

                Dim qrystring As String = "Mfg_Rpt_StockIssueReport.aspx?" & "&id=" & id & "&PartyType=" & PartyType & "&Partyname=" & Partyname
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                lblGreenM.Text = ""

            Else
                lblRedM.Text = ""
                lblGreenM.Text = "Please select the records to print."
            End If
        Catch ex As Exception
            lblRed.Text = "Please enter the valid date."
            lblGreen.Text = ""


        End Try



    End Sub
End Class
