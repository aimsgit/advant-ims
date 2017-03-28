
Partial Class FrmOpeningBalanceEntry
    Inherits BasePage
    Dim dt As New DataTable
    Dim EL As New ELOpeningBalanceEntry
    Dim BL As New BLOpeningBalanceEntry
    Dim BLL As New AccountHeadManager()

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("Privilages").ToString.Contains("W") Then
            txtItemDesc.Focus()
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Try
                    EL.Account_Group = cmbAccountGroup.SelectedValue
                    EL.Account = cmbAcctOne.SelectedValue
                    EL.Account_Treatment = cmbAOT.SelectedValue
                    If txtDate.Text = "" Then
                        EL.Acct_date = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
                    Else
                        EL.Acct_date = txtDate.Text
                    End If

                    EL.Item = txtItemDesc.Text
                    EL.Amount = txtAmt.Text
                    If txtBank.Text = "" Then
                        EL.Bank = 0
                    Else
                        EL.Bank = HidBank.Value
                    End If
                    EL.Remarks = txtRemarks.Text
                    If btnSave.Text = "UPDATE" Then
                        EL.Id = ViewState("DayBook_ID")
                        BL.Update(EL)
                        lblmsgifo.Text = "Data Updated Successfully."
                        lblerrmsg.Text = ""
                        btnSave.Text = "ADD"
                        btnDetails.Text = "VIEW"
                        display()
                        clear()
                    ElseIf btnSave.Text = "ADD" Then
                        BL.Insert(EL)
                        lblmsgifo.Text = "Data Saved Successfully."
                        lblerrmsg.Text = ""
                        display()
                        clear()
                    End If
                Catch ex As Exception
                    lblerrmsg.Text = "Date is valid."
                End Try

            Else
                lblerrmsg.Text = "You do not belong to this branch, Cannot add/update data."
                lblmsgifo.Text = ""

            End If
        Else
            lblerrmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Sub clear()
        txtAmt.Text = ""
        txtDate.Text = ""
        txtItemDesc.Text = ""
        txtBank.Text = ""
        HidBank.Value = 0
        txtRemarks.Text = ""
    End Sub
    Sub display()
        EL.Id = 0
        dt = BL.GetOpeningBalanceEntry(EL)
        
        If dt.Rows.Count > 0 Then
            GrdOpeningEntry.DataSource = dt
            GrdOpeningEntry.DataBind()
            GrdOpeningEntry.Visible = True
            GrdOpeningEntry.Enabled = True
            LinkButton.Focus()
        Else
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
            GrdOpeningEntry.Visible = False
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then
            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            If btnDetails.Text <> "BACK" Then
                GrdOpeningEntry.PageIndex = ViewState("PageIndex")
                display()
            Else
                btnSave.Text = "ADD"
                btnDetails.Text = "VIEW"
                clear()
                GrdOpeningEntry.PageIndex = ViewState("PageIndex")
                display()

            End If
        Else
            lblerrmsg.Text = "You do not have Read Privilage."
        End If
    End Sub

    Protected Sub GrdOpeningEntry_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdOpeningEntry.RowDeleting
        If Session("Privilages").ToString.Contains("W") Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                BL.ChangeFlag(CType(GrdOpeningEntry.Rows(e.RowIndex).FindControl("Label5"), Label).Text)
                ViewState("PageIndex") = GrdOpeningEntry.PageIndex
                dt = BL.GetOpeningBalanceEntry(EL)
                GrdOpeningEntry.DataSource = dt
                GrdOpeningEntry.DataBind()
                GrdOpeningEntry.Visible = True
                GrdOpeningEntry.Enabled = True
                LinkButton.Focus()
                lblerrmsg.Text = ""
                lblmsgifo.Text = "Data Deleted Successfully."
                txtItemDesc.Focus()
            Else
                lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
                lblmsgifo.Text = ""
            End If
        Else
            lblerrmsg.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub GrdOpeningEntry_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdOpeningEntry.RowEditing
        If Session("Privilages").ToString.Contains("W") Then
            lblmsgifo.Text = ""
            lblerrmsg.Text = ""

            txtItemDesc.Text = CType(GrdOpeningEntry.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
            cmbAccountGroup.SelectedValue = Trim(CType(GrdOpeningEntry.Rows(e.NewEditIndex).FindControl("Label15"), Label).Text)
            cmbAcctOne_fill(cmbAccountGroup.SelectedValue)
            cmbAcctOne.SelectedValue = Trim(CType(GrdOpeningEntry.Rows(e.NewEditIndex).FindControl("lblAcctSubGrpId"), Label).Text)
            cmbAOT.SelectedValue = Trim(CType(GrdOpeningEntry.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text)
            txtDate.Text = CType(GrdOpeningEntry.Rows(e.NewEditIndex).FindControl("lblBillDate"), Label).Text
            txtAmt.Text = CType(GrdOpeningEntry.Rows(e.NewEditIndex).FindControl("lblAmt"), Label).Text
            txtBank.Text = CType(GrdOpeningEntry.Rows(e.NewEditIndex).FindControl("lblBank"), Label).Text
            HidBank.Value = CType(GrdOpeningEntry.Rows(e.NewEditIndex).FindControl("LabelBankId"), Label).Text
            'txtAmt.Text = Format(txtAmt.Text, "0.00")
            ViewState("DayBook_ID") = CType(GrdOpeningEntry.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
            txtRemarks.Text = CType(GrdOpeningEntry.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
            EL.Id = ViewState("DayBook_ID")
            dt = BL.GetOpeningBalanceEntry(EL)
            GrdOpeningEntry.DataSource = dt
            GrdOpeningEntry.DataBind()
            GrdOpeningEntry.Enabled = False
            btnSave.Text = "UPDATE"
            e.Cancel = True
            btnDetails.Text = "BACK"
            btnDetails.Visible = True
        Else
            lblerrmsg.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub cmbAccountGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAccountGroup.SelectedIndexChanged
        cmbAcctOne_fill(cmbAccountGroup.SelectedValue)
        cmbAcctOne.Focus()
    End Sub
    Sub cmbAcctOne_fill(ByVal Id As Int32)
        If cmbAccountGroup.SelectedIndex > -1 Then
            cmbAcctOne.DataSource = BLL.GetAcctsubgroupByAcctgroupID(Id)
            cmbAcctOne.DataBind()
        End If
    End Sub
    Sub SplitBank(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("Bank") = parts(0).ToString()
            HidBank.Value = parts(0).ToString()
            txtBank.Text = parts(1).ToString()

        Else
            txtBank.AutoPostBack = True
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtItemDesc.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            cmbAcctOne_fill(cmbAccountGroup.SelectedValue)
            txtDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
        End If
        If txtBank.Text <> "" Then
            SplitBank(txtBank.Text)
        Else
            txtBank.AutoPostBack = True
            SplitBank(txtBank.Text)
        End If
        
    End Sub

End Class
