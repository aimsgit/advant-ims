
Partial Class FrmAccountDoubleEntry
    Inherits BasePage
    Dim EL As New ELDoubleEntry
    Dim BL As New BLDoubleEntry
    Dim dt, dt1, dt2 As New DataTable
    Dim BLL As New AccountHeadManager
    Dim DBM As New DayBookManager
    Dim prop As New DayBookEL
    Dim dbDB As New DayBookDB
    Dim DayBookManagerO As New DayBookManager
    Sub SplitName(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("Party") = parts(0).ToString()
            txtParty.Text = parts(0).ToString()
            HidPartyTypeId.Value = parts(1).ToString()

        Else
            txtParty.AutoPostBack = True
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
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'txtAcdYear.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                dt.Columns.Add("Id")
                dt.Columns.Add("Account_Group_Name")
                dt.Columns.Add("Item")
                dt.Columns.Add("Credit")
                dt.Columns.Add("Debit")
                dt.Columns.Add("Party_Type")
                dt.Columns.Add("Acct_SubGroup_ID")
                dt.Columns.Add("Account_Group")
                dt.Columns.Add("Party_Id_Name")
                dt.Columns.Add("Currency_Code")
                dt.Columns.Add("ExchangeRate")
                dt.Columns.Add("ChequeDate")
                dt.Columns.Add("Bill_Date")
                dt.Columns.Add("Bill_No")
                dt.Columns.Add("Entry_Date")
                dt.Columns.Add("Accounting_Date")
                dt.Columns.Add("Bank_ID")
                dt.Columns.Add("Cheque_No")
                dt.Columns.Add("ProjectID_Auto")
                dt.Columns.Add("Remarks")
                If GV1.Rows.Count > 0 Then
                    'Session("dt") = GV1.DataSource
                    dt = Session("dt")
                    Dim i As Integer
                    i = 0
                    For Each grid As GridViewRow In GV1.Rows
                        dt.Rows(i).Item("Item") = CType(grid.FindControl("lblItem"), TextBox).Text
                        dt.Rows(i).Item("Credit") = CType(grid.FindControl("lblCredit"), TextBox).Text
                        dt.Rows(i).Item("Debit") = CType(grid.FindControl("lblDebit"), TextBox).Text
                        i = i + 1
                    Next

                End If
                Dim newRow As DataRow = dt.NewRow()
                newRow("Id") = dt.Rows.Count + 1
                newRow("Item") = ""
                newRow("Credit") = ""
                newRow("Debit") = ""
                newRow("Account_Group_Name") = cmbAcctOne.SelectedItem.Text
                newRow("Party_Type") = cmbPType.SelectedValue
                newRow("Acct_SubGroup_ID") = cmbAcctOne.SelectedValue
                newRow("Account_Group") = cmbAccountGroup.SelectedValue
                newRow("Party_Id_Name") = HidPartyTypeId.Value
                newRow("Currency_Code") = cmbCurrency.SelectedValue
                newRow("ExchangeRate") = txtExRate.Text
                newRow("ChequeDate") = txtBillDate.Text
                newRow("Bill_Date") = txtBDate.Text
                newRow("Bill_No") = txtBillNo.Text
                newRow("Entry_Date") = txtEDate.Text
                newRow("Accounting_Date") = txtAcctDate.Text
                newRow("Bank_ID") = HidBank.Value
                newRow("Cheque_No") = txtChk.Text
                newRow("ProjectID_Auto") = DDLProjectName.SelectedValue
                newRow("Remarks") = txtRemarks1.Text
                'Add it to the table
                dt.Rows.Add(newRow)
                'Add.newRow(cmbAccountGroup.SelectedItem.Text, cmbAccountGroup.SelectedValue, cmbAcctOne.SelectedItem.Text, cmbAcctOne.SelectedValue, txtItemDesc.Text, txtAmt.Text)
                'GV1.PageIndex = 0
                'dt = AcademicYearDB.GetGridDataById(ViewState("dispId "))
                Session("dt") = dt
                Session("dt2") = dt
                GV1.Visible = True
                GV1.DataSource = dt
                GV1.DataBind()
                clear()
                lblmsgifo.Text = ""
                lblerrmsg.Text = ""

            Catch ex As Exception
                lblerrmsg.Text = ""
            End Try
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
    Protected Sub BtnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSubmit.Click
        If BtnSubmit.Text = "SUBMIT" Then
            If GV1.Rows.Count = 0 Then
                lblerrmsg.Text = "Add Records before submit."
                lblmsgifo.Text = ""
                Exit Sub
            End If
        Else
            If GV1.Rows.Count = 0 Then
                lblerrmsg.Text = "Add Records before update."
                lblmsgifo.Text = ""
                Exit Sub
            End If
        End If
        For Each grid As GridViewRow In GV1.Rows
            Dim c As String
            Dim D As String
            If CType(grid.FindControl("lblCredit"), TextBox).Text = "0.00" Or CType(grid.FindControl("lblCredit"), TextBox).Text = "" Then
                c = 0
            Else
                c = CType(grid.FindControl("lblCredit"), TextBox).Text
            End If
            If CType(grid.FindControl("lblDebit"), TextBox).Text = "0.00" Or CType(grid.FindControl("lblDebit"), TextBox).Text = "" Then
                D = 0
            Else
                D = CType(grid.FindControl("lblDebit"), TextBox).Text
            End If
            If CType(grid.FindControl("lblItem"), TextBox).Text = "" Then
                lblerrmsg.Text = "Item Field is mandatory"
                lblmsgifo.Text = ""
                Exit Sub
            End If
            If c = "" And D = "" Then
                lblerrmsg.Text = "Enter either credit or debit."
                lblmsgifo.Text = ""
                Exit Sub
            End If
            If c = "0" And D = "0" Then
                lblerrmsg.Text = "Enter either credit or debit."
                lblmsgifo.Text = ""
                Exit Sub
            End If
            If c <> "0" And D <> "0" Then
                lblerrmsg.Text = "Enter either credit or debit."
                lblmsgifo.Text = ""
                Exit Sub
            End If
        Next
        Dim Credit As Double
        Dim Debit As Double
        Credit = 0
        Debit = 0
        For Each grid As GridViewRow In GV1.Rows
            Credit = IIf(CType(grid.FindControl("lblCredit"), TextBox).Text = "", 0, CType(grid.FindControl("lblCredit"), TextBox).Text) + Credit
            Debit = IIf(CType(grid.FindControl("lblDebit"), TextBox).Text = "", 0, CType(grid.FindControl("lblDebit"), TextBox).Text) + Debit
        Next
        If Credit <> Debit Then
            lblerrmsg.Text = "Sum Of Credit and Debit should be same."
            lblmsgifo.Text = ""
            Exit Sub
        End If
        dt = BL.GetNo()
        EL.id = dt.Rows(0).Item("Id")
        For Each grid As GridViewRow In GV1.Rows
            EL.AccountGroup = CType(grid.FindControl("lblAccSubGrpId"), Label).Text
            EL.Account = CType(grid.FindControl("lblAccGrp"), Label).Text
            EL.Item = CType(grid.FindControl("lblItem"), TextBox).Text
            If CType(grid.FindControl("lblCredit"), TextBox).Text = "" Then
                EL.Amount = 0
            Else
                EL.Amount = CType(grid.FindControl("lblCredit"), TextBox).Text
            End If
            If CType(grid.FindControl("lblDebit"), TextBox).Text = "" Then
                EL.Amount_Out = 0
            Else
                EL.Amount_Out = CType(grid.FindControl("lblDebit"), TextBox).Text
            End If
            EL.ProjectName = CType(grid.FindControl("lblProjectId"), Label).Text
            EL.Currency = CType(grid.FindControl("lblCurrencyCode"), Label).Text
            EL.Party_Type = CType(grid.FindControl("lblPartyType"), Label).Text
            If CType(grid.FindControl("lblPartyId"), Label).Text = "" Then
                EL.Party_Id_Name = 0
            Else
                EL.Party_Id_Name = CType(grid.FindControl("lblPartyId"), Label).Text
            End If
            EL.Entry_Date = CType(grid.FindControl("lblEntryDate"), Label).Text
            If CType(grid.FindControl("lblBillDate"), Label).Text = "" Then
                EL.Bill_Date = "1/1/3000"
            Else
                EL.Bill_Date = CType(grid.FindControl("lblBillDate"), Label).Text
            End If
            If CType(grid.FindControl("lblAccountingDate"), Label).Text = "" Then
                EL.Accounting_Date = "1/1/3000"
            Else
                EL.Accounting_Date = CType(grid.FindControl("lblAccountingDate"), Label).Text
            End If
            EL.Bill_No = CType(grid.FindControl("lblBillNo"), Label).Text
            If CType(grid.FindControl("lblBankId"), Label).Text = "" Then
                EL.Bank_ID = 0
            Else
                EL.Bank_ID = CType(grid.FindControl("lblBankId"), Label).Text
            End If
            EL.Cheque_No = CType(grid.FindControl("lblChequeNo"), Label).Text
            If CType(grid.FindControl("lblChequeDate"), Label).Text = "" Then
                EL.ChequeDate = "1/1/3000"
            Else
                EL.ChequeDate = CType(grid.FindControl("lblChequeDate"), Label).Text
            End If
            EL.Remarks = CType(grid.FindControl("lblRemarks"), Label).Text
            If BtnSubmit.Text = "SUBMIT" Then

                If CType(grid.FindControl("lblCredit"), TextBox).Text <> "" And CType(grid.FindControl("lblDebit"), TextBox).Text <> "" Then
                    lblerrmsg.Text = "Enter either credit or debit."
                    Exit Sub
                End If
                BL.InsertRecord(EL)
                dt = BL.GetGridData(0)
                GV3.DataSource = dt
                GV3.DataBind()
                lblmsgifo.Text = "Data Saved Successfully."
                lblerrmsg.Text = ""
                GV1.Visible = False
                clear()
                GV1.DataSource = ""
                GV1.Columns.Clear()
            Else
                ''EL.AccountGroup = cmbAccountGroup.SelectedValue
                ''EL.Account = cmbAcctOne.SelectedValue
                'EL.Item = CType(grid.FindControl("lblItem"), TextBox).Text
                'If CType(grid.FindControl("lblCredit"), TextBox).Text = "" Then
                '    EL.Amount = 0
                'Else
                '    EL.Amount = CType(grid.FindControl("lblCredit"), TextBox).Text
                'End If
                'If CType(grid.FindControl("lblDebit"), TextBox).Text = "" Then
                '    EL.Amount_Out = 0
                'Else
                '    EL.Amount_Out = CType(grid.FindControl("lblDebit"), TextBox).Text
                'End If
                'EL.ProjectName = DDLProjectName.SelectedValue
                'EL.Currency = cmbCurrency.SelectedValue
                'EL.Party_Type = cmbPType.SelectedValue
                'If HidPartyTypeId.Value = "" Then
                '    EL.Party_Id_Name = 0
                'Else
                '    EL.Party_Id_Name = HidPartyTypeId.Value
                'End If
                'EL.Entry_Date = CType(grid.FindControl("lblEntryDate"), Label).Text
                'If txtBDate.Text = "" Then
                '    EL.Bill_Date = "1/1/3000"
                'Else
                '    EL.Bill_Date = txtBDate.Text
                'End If
                'If txtAcctDate.Text = "" Then
                '    EL.Accounting_Date = "1/1/3000"
                'Else
                '    EL.Accounting_Date = txtAcctDate.Text
                'End If
                'EL.Bill_No = txtBillNo.Text
                'If HidBank.Value = "" Then
                '    EL.Bank_ID = 0
                'Else
                '    EL.Bank_ID = HidBank.Value
                'End If
                'EL.Cheque_No = txtChk.Text
                'If txtBillDate.Text = "" Then
                '    EL.ChequeDate = "1/1/3000"
                'Else
                '    EL.ChequeDate = txtBillDate.Text
                'End If
                'EL.Remarks = txtRemarks1.Text
                EL.id1 = ViewState("DayBookId")
                'BL.UpdateRecord(EL)
                BL.InsertRecord1(EL)
                dt = BL.GetGridData(0)
                GV3.DataSource = dt
                GV3.DataBind()
                lblmsgifo.Text = "Data Updated Successfully."
                lblerrmsg.Text = ""
                GV1.Visible = False
                clear()
                GV1.DataSource = Nothing
                GV1.DataBind()
                GV3.Enabled = True
            End If

        Next
        BtnSubmit.Text = "SUBMIT"
        BtnView.Text = "VIEW"

    End Sub

    Protected Sub cmbCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCurrency.SelectedIndexChanged
        Dim MC1 As New MultiCurrencyManager
        Dim MCD As MultiCurrency = MC1.GetMulticurrencyRate(CInt(IIf(cmbCurrency.SelectedValue.ToString = "", 0, cmbCurrency.SelectedValue.ToString)))
        dt = DBM.GetCurrency()
        If dt.Rows.Count > 0 Then
            prop.Currency = dt.Rows(0).Item("Config_Value")
            dt1 = DBM.GetCurrencyRate(prop)
            prop.Currency = dt1.Rows(0).Item("Buy_Conversion_Rate")
            txtExRate.Text = (MCD.BuyConversionRate / prop.Currency)
        Else
            txtExRate.Text = MCD.BuyConversionRate
        End If
    End Sub
    Protected Sub GV3_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GV3.PageIndexChanging
        GV3.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GV3.PageIndex
        dt = BL.GetGridData(0)
        GV3.DataSource = dt
        GV3.DataBind()
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        If IsPostBack = False Then
            If Session("DayBookExpense_ID") = Nothing Then
            Else
                dt = BL.GetGridData1(Session("DayBookExpense_ID"))
                GV3.DataSource = dt
                GV3.DataBind()
            End If
            dt = DBM.GetCurrency()
            If dt.Rows.Count > 0 Then
                cmbCurrency.SelectedValue = dt.Rows(0).Item("Config_Value")
            Else
                cmbCurrency.SelectedValue = 3
            End If
            txtExRate.Text = "1.00"
            txtEDate.Text = Today.ToString("dd-MMM-yyyy")
            txtBDate.Text = Today.ToString("dd-MMM-yyyy")
            txtAcctDate.Text = Today.ToString("dd-MMM-yyyy")
            GV1.DataSource = Nothing
            GV1.DataBind()
        End If
    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        If BtnView.Text = "BACK" Then
            BtnView.Text = "VIEW"
            BtnSubmit.Text = "SUBMIT"
            GV1.Visible = False
            clear()
            GV1.DataSource = Nothing
            GV1.DataBind()
            GV3.Enabled = True
        End If
        dt = BL.GetGridData(0)
        GV3.DataSource = dt
        GV3.DataBind()
        lblmsgifo.Text = ""
        lblerrmsg.Text = ""
        GV3.Enabled = True
    End Sub
    Sub clear()
        cmbPType.SelectedItem.Selected = False
        txtBillNo.Text = ""
        txtChk.Text = ""
        txtBillDate.Text = ""
        txtRemarks1.Text = ""
        HidPartyTypeId.Value = 0
        HidBank.Value = 0
        txtBank.Text = ""
        txtBranch.Text = ""
        txtBillDate.Text = ""
        txtBDate.Text = Today.ToString("dd-MMM-yyyy")
        txtEDate.Text = Today.ToString("dd-MMM-yyyy")
        txtAcctDate.Text = Today.ToString("dd-MMM-yyyy")
        txtParty.Text = ""
    End Sub

    Protected Sub GV3_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GV3.RowDeleting
        If Session("Privilages").ToString.Contains("W") Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                EL.id = CType(GV3.Rows(e.RowIndex).FindControl("lblDayBookId"), Label).Text
                BL.ChangeFlag(EL)
                ViewState("PageIndex") = GV3.PageIndex
                dt = BL.GetGridData(0)
                GV3.DataSource = dt
                GV3.DataBind()
                lblerrmsg.Text = ""
                lblmsgifo.Text = "Data Deleted Successfully."
            End If
        Else
            lblerrmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub GV3_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GV3.RowEditing
        ViewState("DayBookId") = (CType(GV3.Rows(e.NewEditIndex).FindControl("lblDayBookId"), Label).Text)

        dt = BL.GetGridData(ViewState("DayBookId"))
        GV3.DataSource = dt
        GV3.DataBind()
        dt2.Columns.Add("Id")
        dt2.Columns.Add("Account_Group_Name")
        dt2.Columns.Add("Item")
        dt2.Columns.Add("Credit")
        dt2.Columns.Add("Debit")
        dt2.Columns.Add("Party_Type")
        dt2.Columns.Add("Acct_SubGroup_ID")
        dt2.Columns.Add("Account_Group")
        dt2.Columns.Add("Party_Id_Name")
        dt2.Columns.Add("Currency_Code")
        dt2.Columns.Add("ExchangeRate")
        dt2.Columns.Add("ChequeDate")
        dt2.Columns.Add("Bill_Date")
        dt2.Columns.Add("Bill_No")
        dt2.Columns.Add("Entry_Date")
        dt2.Columns.Add("Accounting_Date")
        dt2.Columns.Add("Bank_ID")
        dt2.Columns.Add("Cheque_No")
        dt2.Columns.Add("ProjectID_Auto")
        dt2.Columns.Add("Remarks")
        Dim I As Integer
        I = 0
        While dt.Rows.Count > I
            
            Dim newRow As DataRow = dt2.NewRow()
            newRow("Id") = I + 1
            newRow("Account_Group_Name") = dt.Rows(I).Item("Account_Group").ToString
            newRow("Item") = dt.Rows(I).Item("Item").ToString
            newRow("Credit") = Format(dt.Rows(I).Item("Amt_In"), "0.00")
            newRow("Debit") = Format(dt.Rows(I).Item("Amt_Out"), "0.00")
            newRow("Party_Type") = dt.Rows(I).Item("Party_Type").ToString
            newRow("Acct_SubGroup_ID") = dt.Rows(I).Item("AcctOneId").ToString
            newRow("Account_Group") = dt.Rows(I).Item("Account_Group_Id").ToString
            newRow("Party_Id_Name") = dt.Rows(I).Item("Party_Id_Name").ToString
            newRow("Currency_Code") = dt.Rows(I).Item("Currency_Code").ToString
            newRow("ExchangeRate") = dt.Rows(I).Item("ExchangeRate")
            newRow("ChequeDate") = dt.Rows(I).Item("ChequeDate")
            newRow("Bill_Date") = dt.Rows(I).Item("Bill_Date")
            newRow("Bill_No") = dt.Rows(I).Item("Bill_No").ToString
            newRow("Entry_Date") = dt.Rows(I).Item("Entry_Date")
            newRow("Accounting_Date") = dt.Rows(I).Item("Accounting_Date")
            newRow("Bank_ID") = dt.Rows(I).Item("Bank_ID").ToString
            newRow("Cheque_No") = dt.Rows(I).Item("Cheque_No").ToString
            newRow("ProjectID_Auto") = dt.Rows(I).Item("ProjectID_Auto").ToString
            newRow("Remarks") = dt.Rows(I).Item("Remarks").ToString
            'cmbPType.SelectedValue = dt.Rows(0).Item("Party_Type").ToString
            'cmbAccountGroup.SelectedValue = dt.Rows(0).Item("Account_Group_Id").ToString
            'cmbAcctOne_fill(cmbAccountGroup.SelectedValue)
            'cmbAcctOne.SelectedValue = dt.Rows(0).Item("AcctOneId").ToString
            'txtParty.Text = dt.Rows(0).Item("PartyName").ToString
            'cmbCurrency.SelectedValue = dt.Rows(0).Item("Currency_Code").ToString
            'txtEDate.Text = dt.Rows(0).Item("ExchangeRate")
            I = I + 1
            dt2.Rows.Add(newRow)
        End While
        'If dt.Rows(0).Item("ChequeDate").ToString = "" Then
        '    txtBillDate.Text = ""
        'Else
        '    txtBillDate.Text = dt.Rows(0).Item("ChequeDate")
        'End If
        'If dt.Rows(0).Item("Bill_Date").ToString = "" Then
        '    txtBDate.Text = ""
        'Else
        '    txtBDate.Text = dt.Rows(0).Item("Bill_Date")
        'End If
        'If dt.Rows(0).Item("Entry_Date").ToString = "" Then
        '    txtEDate.Text = ""
        'Else
        '    txtEDate.Text = dt.Rows(0).Item("Entry_Date")
        'End If
        'txtBillNo.Text = dt.Rows(0).Item("Bill_No").ToString
        'If dt.Rows(0).Item("Accounting_Date").ToString = "" Then
        '    txtAcctDate.Text = ""
        'Else
        '    txtAcctDate.Text = dt.Rows(0).Item("Accounting_Date")
        'End If
        'txtBank.Text = dt.Rows(0).Item("Bank_Name").ToString
        'txtChk.Text = dt.Rows(0).Item("Cheque_No").ToString
        'DDLProjectName.SelectedValue = dt.Rows(0).Item("ProjectID_Auto").ToString
        'txtRemarks1.Text = dt.Rows(0).Item("Remarks").ToString
        'Add it to the table

        'Add.newRow(cmbAccountGroup.SelectedItem.Text, cmbAccountGroup.SelectedValue, cmbAcctOne.SelectedItem.Text, cmbAcctOne.SelectedValue, txtItemDesc.Text, txtAmt.Text)
        'GV1.PageIndex = 0
        'dt = AcademicYearDB.GetGridDataById(ViewState("dispId "))
        Session("dt2") = dt2
        GV1.Visible = True
        GV1.DataSource = dt2
        GV1.DataBind()
        Session("dt") = dt2
        BtnSubmit.Text = "UPDATE"
        BtnView.Text = "BACK"
        lblmsgifo.Text = ""
        lblerrmsg.Text = ""
        GV3.Enabled = False
    End Sub

    Protected Sub GV1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GV1.RowDeleting
        Dim id As Integer
        id = CType(GV1.Rows(e.RowIndex).FindControl("lblId"), Label).Text
        'GV1.Rows(id).Dispose()
        dt2 = Session("dt2")
        dt2.Rows(id - 1).Delete()
        GV1.DataSource = dt2
        GV1.DataBind()
        Session("dt") = dt2
        Dim i, j As Integer
        i = 0
        j = 1
        For Each grid As GridViewRow In GV1.Rows
            dt2.Rows(i).Item("Id") = j
            j = j + 1
            i = i + 1
        Next
        GV1.DataSource = dt2
        GV1.DataBind()
        Session("dt") = dt2
        lblerrmsg.Text = ""
        lblmsgifo.Text = "Data Deleted Successfully."
    End Sub

    Protected Sub Btnposttostock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnposttostock.Click
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim id As String = ""
                Dim check As String = ""

                Dim count As New Integer
                count = 0
                For Each grid As GridViewRow In GV3.Rows
                    If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                        check = CType(grid.FindControl("lblDayBookId"), Label).Text
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
                Dim role As String
                role = Session("UserRole")
                'dt = DayBookDB.PostCheck(role)
                'If dt.Rows.Count > 0 Then
                If count = 0 Then
                    lblerrmsg.Text = "Select Atleast One Record to Post."
                    lblmsgifo.Text = ""
                Else
                    prop.ChkID = id
                    DayBookManagerO.PostToDayBook(prop)
                    lblmsgifo.Text = "Record posted successfully."
                    lblerrmsg.Text = ""
                    dt = BL.GetGridData(0)
                    GV3.DataSource = dt
                    GV3.DataBind()
                End If
                'Else
                '    lblErrorMsg.Text = "Not Authorized to Post."
                '    Lblmsg.Text = ""
                'End If
            Else
                lblerrmsg.Text = "You do not belong to this branch, Cannot post data."
                lblmsgifo.Text = ""
            End If
        Else
            lblerrmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Sub CheckAll()
        If CType(GV3.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GV3.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GV3.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
            Next
        End If
    End Sub
End Class
