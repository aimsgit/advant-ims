Imports System.IO
Partial Class DayBook
    Inherits BasePage
    Dim prop As New DayBookEL
    Dim dbDB As New DayBookDB
    Dim dt, dt1, dt2 As New DataTable
    Dim DayBookManagerO As New DayBookManager
    Dim Acct As New AccountHeadManager
    Dim Amt As Double
    Dim DBM As New DayBookManager
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
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        Dim path As String
        dt = DayBookDB.GetPrintPath()
        path = dt.Rows(0).Item("Config_Value")
        Session("path") = path
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If IsPostBack = False Then
            Session("DayBkPType") = 1
            HidPartyTypeId.Value = 0
            HidBank.Value = 0
            'HidChequeBank.Value = 0
            txtEDate.Text = Today.ToString("dd-MMM-yyyy")
            txtBDate.Text = Today.ToString("dd-MMM-yyyy")
            txtAcctDate.Text = Today.ToString("dd-MMM-yyyy")
            txtExRate.Text = "1.00"
            ViewState("PageIndex") = 0
            'cmbAccHead.Focus()
            dt = DayBookManagerO.GetCurrency()
            If dt.Rows.Count > 0 Then
                cmbCurrency.SelectedValue = dt.Rows(0).Item("Config_Value")
            Else
                cmbCurrency.SelectedValue = 3
            End If
            payment()
            prop.AGOne = cmbAGOne.SelectedValue
            prop.ATOne = cmbAOT.SelectedValue
            If ChkWithCode.Checked = True Then
                prop.Code = "Y"
            Else
                prop.Code = "N"
            End If
            dt = Acct.GetAccountHeadByIdGroup(prop)
            cmbAccHead.DataSource = dt
            cmbAccHead.DataBind()
        End If
        If txtParty.Text <> "" Then
            SplitName(txtParty.Text)
        Else
            txtParty.AutoPostBack = True

            SplitName(txtParty.Text)
        End If
        If txtBank.Text <> "" Then
            SplitBank(txtBank.Text)
        Else
            txtBank.AutoPostBack = True
            SplitBank(txtBank.Text)
        End If
        
    End Sub

    Protected Sub cmbPType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPType.SelectedIndexChanged
        Session("DayBkPType") = cmbPType.SelectedValue
        txtParty.Text = ""
        txtParty.Focus()
    End Sub
    Protected Sub cmbCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCurrency.SelectedIndexChanged
        Dim MC1 As New MultiCurrencyManager
        Dim MCD As MultiCurrency = MC1.GetMulticurrencyRate(CInt(IIf(cmbCurrency.SelectedValue.ToString = "", 0, cmbCurrency.SelectedValue.ToString)))
        dt = DayBookManagerO.GetCurrency()
        If dt.Rows.Count > 0 Then
            prop.Currency = dt.Rows(0).Item("Config_Value")
            dt1 = DayBookManagerO.GetCurrencyRate(prop)
            prop.Currency = dt1.Rows(0).Item("Buy_Conversion_Rate")
            txtExRate.Text = (MCD.BuyConversionRate / prop.Currency)
        Else
            txtExRate.Text = MCD.BuyConversionRate
        End If
        payment()
    End Sub
    Protected Sub GVDayBook_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVDayBook.PageIndexChanging
        GVDayBook.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVDayBook.PageIndex
        AssignEntitySearch()
        display1()
    End Sub
    Protected Sub GVDayBook_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVDayBook.RowDeleting
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then
                DayBookManagerO.ChangeFlag(CType(GVDayBook.Rows(e.RowIndex).FindControl("Label6"), Label).Text)
                ViewState("PageIndex") = GVDayBook.PageIndex
                AssignEntitySearch()
                display1()
                lblErrorMsg.Text = ""
                Lblmsg.Text = "Data Deleted Successfully."
                cmbAccHead.Focus()
                If ddlPaymentMethod.SelectedValue = 1 Then
                    txtRemarks1.Visible = True
                    Label18.Visible = True
                    txtRemarks.Visible = False
                    Label14.Visible = False
                Else
                    txtRemarks1.Visible = False
                    Label18.Visible = False
                    txtRemarks.Visible = True
                    Label14.Visible = True
                End If
            End If
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
            'lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            'Lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GVDayBook_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVDayBook.RowEditing
        If Session("Privilages").ToString.Contains("W") Then

            'If (Session("BranchCode") = Session("ParentBranch")) Then
            Lblmsg.Text = ""
            lblErrorMsg.Text = ""
            ViewState("DayBookExpense_ID") = (CType(GVDayBook.Rows(e.NewEditIndex).FindControl("Label6"), Label).Text)
            AssignEntityIndividual()
            dt = DayBookManagerO.GetDayBookGVDaybook(prop)
            If dt.Rows(0).Item("Field3") = "D" Then
                Session("DayBookExpense_ID") = dt.Rows(0).Item("Exp_Ref_ID")
                Response.Redirect("FrmAccountDoubleEntry.aspx")
            Else
                cmbAccHead.SelectedValue = dt.Rows(0).Item("Account_Code")
                'ObjAccHead.DataBind()
                ViewState("DayBookExpense_ID") = dt.Rows(0).Item("Exp_Ref_ID").ToString
                txtEDate.Text = Format(dt.Rows(0).Item("Entry_Date"), "dd-MMM-yyyy").ToString
                txtBillNo.Text = dt.Rows(0).Item("Bill_No").ToString
                If dt.Rows(0).Item("Bill_Date") Is DBNull.Value Then
                    txtBDate.Text = ""
                Else
                    txtBDate.Text = Format(dt.Rows(0).Item("Bill_Date"), "dd-MMM-yyyy").ToString
                End If
                txtItemDesc.Text = dt.Rows(0).Item("Item").ToString
                cmbCurrency.SelectedValue = dt.Rows(0).Item("Currency_Code").ToString
                txtExRate.Text = Format(dt.Rows(0).Item("ExchangeRate"), "F2").ToString
                txtAmt.Text = Format(dt.Rows(0).Item("Amount"), "F2").ToString / Format(dt.Rows(0).Item("ExchangeRate"), "F2").ToString
                txtChk.Text = dt.Rows(0).Item("Cheque_No").ToString
                If dt.Rows(0).Item("ChequeDate") Is DBNull.Value Then
                    txtBillDate.Text = ""
                Else
                    txtBillDate.Text = Format(dt.Rows(0).Item("ChequeDate"), "dd-MMM-yyyy").ToString
                End If
                HidBank.Value = dt.Rows(0).Item("Bank_ID").ToString
                txtBank.Text = dt.Rows(0).Item("Bank_Name").ToString
                txtBank.Text = dt.Rows(0).Item("Bank_Name").ToString
                'HidChequeBank.Value = dt.Rows(0).Item("DDBank_ID").ToString
                txtChequeBank.Text = dt.Rows(0).Item("DDBank_Name").ToString
                HidPartyTypeId.Value = dt.Rows(0).Item("Party_Id_Name").ToString
                txtParty.Text = dt.Rows(0).Item("PartyName").ToString
                cmbPType.SelectedValue = dt.Rows(0).Item("Party_Type")
                txtRemarks.Text = dt.Rows(0).Item("Remarks").ToString
                txtRemarks1.Text = dt.Rows(0).Item("Remarks").ToString
                txtBranch.Text = dt.Rows(0).Item("Branch").ToString
                DDLProjectName.SelectedValue = dt.Rows(0).Item("ProjectID_Auto").ToString
                If dt.Rows(0).Item("Accounting_Date") Is DBNull.Value Then
                    txtAcctDate.Text = ""
                Else
                    txtAcctDate.Text = Format(dt.Rows(0).Item("Accounting_Date"), "dd-MMM-yyyy").ToString
                End If
                ddlPaymentMethod.SelectedValue = dt.Rows(0).Item("PaymethodId").ToString
                GVDayBook.DataSource = dt
                GVDayBook.DataBind()
                GVDayBook.Enabled = False
                btnSave.Text = "UPDATE"
                e.Cancel = True
                btnDetails.Text = "BACK"
                btnDetails.Visible = True
                payment()
            End If
            'Else
            'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
            'Lblmsg.Text = ""
            'End If
        Else
            lblErrorMsg.Text = "You do not have Write Privilage"
        End If
    End Sub
    Sub display1()
        AssignEntitySearch()
        dt = DayBookManagerO.GetDayBookGVDaybook(prop)
        If dt.Rows.Count > 0 Then
            GVDayBook.DataSource = dt
            GVDayBook.DataBind()
            GVDayBook.Visible = True
            GVDayBook.Enabled = True
            LinkButton.Focus()

        Else
            Lblmsg.Text = ""
            lblErrorMsg.Text = "No records to display."
            GVDayBook.Visible = False
        End If
        payment()
    End Sub
    Sub display2()
        AssignEntityIndividual()
        dt = DayBookManagerO.GetDayBookGVDaybook(prop)
        If dt.Rows.Count > 0 Then
            GVDayBook.DataSource = dt
            GVDayBook.DataBind()
            GVDayBook.Visible = True
            GVDayBook.Enabled = True
        Else
            lblErrorMsg.Text = "No records to display."
            Lblmsg.Text = ""
            GVDayBook.Visible = False
        End If
        payment()
    End Sub
    Sub AssignEntitySearch()
        prop.Expense_ID = 0
        If cmbAccHead.SelectedValue = "Select" Then
            prop.Account_Head = "0"
        Else
            prop.Account_Head = cmbAccHead.SelectedValue
        End If
        If txtItemDesc.Text = "" Then
            prop.Item = "0"
        Else
            prop.Item = txtItemDesc.Text
        End If
        If cmbPType.SelectedValue = "1" Then
            prop.Party_Type = "0"
        Else
            prop.Party_Type = cmbPType.SelectedValue
        End If
        If txtParty.Text = "" Then
            prop.Party_Name = "0"
        Else
            prop.Party_Name = txtParty.Text
        End If
        If txtBillNo.Text = "" Or txtBillNo.Text = "New Voucher/Receipt" Then
            prop.Bill_No = "0"
        Else
            prop.Bill_No = txtBillNo.Text
        End If
        prop.ProjectName = DDLProjectName.SelectedValue
        prop.Cheque_No = txtChk.Text

    End Sub
    Sub AssignEntityIndividual()
        prop.Expense_ID = ViewState("DayBookExpense_ID")
        prop.Account_Head = "0"
        prop.Item = "0"
        prop.Party_Type = "0"
        prop.Party_Name = "0"
        prop.Bill_No = "0"
        prop.ProjectName = "0"
        prop.Cheque_No = "0"
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("Privilages").ToString.Contains("W") Then
            Try

                cmbAccHead.Focus()
                If (Session("BranchCode") = Session("ParentBranch")) Then

                    Amt = Val(txtAmt.Text) * Val(txtExRate.Text) 'To convert foreign currency to Indian(Local) currency

                    prop.Account_Head = cmbAccHead.SelectedValue
                    prop.Item = txtItemDesc.Text
                    prop.Currency_Code = cmbCurrency.SelectedValue
                    prop.ExchangeRate = txtExRate.Text
                    prop.Party_Type = cmbPType.SelectedValue
                    prop.Party_Id_Name = HidPartyTypeId.Value
                    prop.ProjectName = DDLProjectName.SelectedValue
                    prop.Entry_Date = txtEDate.Text
                    If txtBDate.Text = "" Then
                        prop.Bill_Date = txtBDate.Text
                    Else
                        prop.Bill_Date = txtBDate.Text
                    End If
                    prop.PaymentMethod_Id = ddlPaymentMethod.SelectedValue
                    prop.Amount = Amt
                    prop.Bank_ID = HidBank.Value
                    prop.Branch = txtBranch.Text
                    'prop.ChequeBank_ID = HidChequeBank.Value
                    prop.Cheque_No = txtChk.Text
                    If txtBillDate.Text = "" Then
                        prop.ChequeDate = "1/1/3000"
                    Else
                        prop.ChequeDate = txtBillDate.Text
                    End If
                    If txtAcctDate.Text = "" Then
                        prop.Accounting_Date = "1/1/3000"
                    Else
                        prop.Accounting_Date = txtAcctDate.Text
                    End If

                    prop.Remarks = txtRemarks.Text
                    prop.Remarks = txtRemarks1.Text
                    If txtRemarks.Text = "" Then
                        prop.Remarks = txtRemarks1.Text
                    Else
                        prop.Remarks = txtRemarks.Text
                    End If
                    If txtRemarks1.Text = "" Then
                        prop.Remarks = txtRemarks.Text
                    Else
                        prop.Remarks = txtRemarks1.Text
                    End If
                    Try
                        If btnSave.Text = "UPDATE" Then
                            prop.Bill_No = txtBillNo.Text
                            prop.Expense_ID = ViewState("DayBookExpense_ID")
                            DBM.UpdateRecord(prop)
                            Lblmsg.Text = "Data Updated Successfully."
                            lblErrorMsg.Text = ""
                            btnSave.Text = "ADD"
                            btnDetails.Text = "VIEW"
                            AssignEntityIndividual()
                            display2()
                            clear()
                            'dt = DayBookManagerO.GetCurrency()
                            'If dt.Rows.Count > 0 Then
                            '    cmbCurrency.SelectedValue = dt.Rows(0).Item("Config_Value")
                            'Else
                            '    cmbCurrency.SelectedValue = 3
                            'End If
                        ElseIf btnSave.Text = "ADD" Then
                            Try
                                cmbAccHead.Focus()
                                Dim Type, type1, treat, Treat1 As String
                                prop.Account_Head = cmbAccHead.SelectedValue
                                dt = DayBookManagerO.GetTypeAcct(prop)
                                Type = dt.Rows(0).Item("Acct_One")
                                treat = dt.Rows(0).Item("Acct_One_treatment")
                                type1 = dt.Rows(0).Item("Acct_two")
                                Treat1 = dt.Rows(0).Item("Acct_Two_treatment")
                                If Type = 102 And treat = 1 Then
                                    dt = DayBookManagerO.GetBillSerialNoCV(prop)
                                End If
                                If Type = 102 And treat = -1 Then
                                    dt = DayBookManagerO.GetBillSerialNoCR(prop)
                                End If
                                If type1 = 102 And Treat1 = 1 Then
                                    dt = DayBookManagerO.GetBillSerialNoCV(prop)
                                End If
                                If type1 = 102 And Treat1 = -1 Then
                                    dt = DayBookManagerO.GetBillSerialNoCR(prop)
                                End If
                                If Type = 103 And treat = 1 Then
                                    dt = DayBookManagerO.GetBillSerialNoBV(prop)
                                    'dt2 = DayBookManagerO.GetChequeNo(prop)
                                End If
                                If type1 = 103 And Treat1 = 1 Then
                                    dt = DayBookManagerO.GetBillSerialNoBV(prop)
                                    'dt2 = DayBookManagerO.GetChequeNo(prop)
                                End If
                                If type1 = 103 And Treat1 = -1 Then
                                    dt = DayBookManagerO.GetBillSerialNoBR(prop)
                                    'dt2 = DayBookManagerO.GetChequeNo(prop)
                                End If
                                If Type = 103 And treat = -1 Then
                                    dt = DayBookManagerO.GetBillSerialNoBR(prop)
                                    'dt2 = DayBookManagerO.GetChequeNo(prop)
                                End If
                                If Type <> 102 And Type <> 103 And type1 <> 102 And type1 <> 103 Then
                                    dt = DayBookManagerO.GetBillSerialNoJV(prop)
                                End If
                                If dt.Rows.Count > 0 Then
                                    prop.Bill_No = dt.Rows(0).Item("BillNo").ToString
                                Else
                                    txtBillNo.Text = ""
                                End If
                                If dt2.Rows.Count > 0 Then
                                    prop.Cheque_No = dt2.Rows(0).Item("BillNo").ToString
                                Else
                                    txtBillNo.Text = ""
                                End If
                            Catch ex As Exception
                            End Try
                            DBM.InsertRecord(prop)
                            Lblmsg.Text = "Data Saved Successfully."
                            lblErrorMsg.Text = ""
                            ViewState("DayBookExpense_ID") = DBM.InsertIntoDayBook(prop)
                            AssignEntityIndividual()
                            display2()
                            clear()
                            'dt = DayBookManagerO.GetCurrency()
                            'If dt.Rows.Count > 0 Then
                            '    cmbCurrency.SelectedValue = dt.Rows(0).Item("Config_Value")
                            'Else
                            '    cmbCurrency.SelectedValue = 3
                            'End If
                        End If
                    Catch ex As Exception
                        Lblmsg.Text = "Unable to Save data."
                        lblErrorMsg.Text = ""
                    End Try

                Else
                    lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
                    Lblmsg.Text = ""
                End If

            Catch ex As Exception
                lblErrorMsg.Text = "Date is not valid."
                Lblmsg.Text = ""
            End Try
        Else
            lblErrorMsg.Text = "You do not have Write Privilage. "

        End If
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If Session("Privilages").ToString.Contains("R") Or Session("Privilages").ToString.Contains("W") Then

            lblErrorMsg.Text = ""

            Lblmsg.Text = ""
            If btnDetails.Text <> "BACK" Then
                GVDayBook.PageIndex = ViewState("PageIndex")
                AssignEntitySearch()
                display1()
            Else
                btnSave.Text = "ADD"
                btnDetails.Text = "VIEW"
                clear()
                GVDayBook.PageIndex = ViewState("PageIndex")
                AssignEntitySearch()
                display1()
            End If
        Else
            lblErrorMsg.Text = "You do not have Read  Privilage."
        End If
    End Sub
    Sub clear()
        txtItemDesc.Text = ""
        'txtExRate.Text = "1.00"
        cmbPType.SelectedItem.Selected = False
        txtAmt.Text = ""
        txtBillNo.Text = ""
        txtChk.Text = ""
        txtBillDate.Text = ""
        txtRemarks.Text = ""
        txtRemarks1.Text = ""
        'cmbCurrency.ClearSelection()
        'cmbPType.ClearSelection()
        txtChequeBank.Text = ""
        HidPartyTypeId.Value = 0
        HidBank.Value = 0
        'HidChequeBank.Value = 0
        txtBank.Text = ""
        txtBranch.Text = ""
        txtChequeBank.Text = ""
        txtBillDate.Text = ""
        txtBDate.Text = Today.ToString("dd-MMM-yyyy")
        txtEDate.Text = Today.ToString("dd-MMM-yyyy")
        txtAcctDate.Text = Today.ToString("dd-MMM-yyyy")

        txtParty.Text = ""
        cmbAccHead.ClearSelection()
        DDLProjectName.ClearSelection()

    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub cmbAccHead_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAccHead.TextChanged
        txtBillNo.Text = "New Voucher/Receipt"
    End Sub

    Protected Sub cmbCurrency_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCurrency.TextChanged
        cmbCurrency.Focus()

    End Sub

    Protected Sub cmbPType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPType.TextChanged
        cmbPType.Focus()
    End Sub

    Protected Sub DDLProjectName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLProjectName.TextChanged
        DDLProjectName.Focus()

    End Sub

    Protected Sub Btnposttostock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnposttostock.Click
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim id As String = ""
                Dim check As String = ""

                Dim count As New Integer
                count = 0
                For Each grid As GridViewRow In GVDayBook.Rows
                    If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                        check = CType(grid.FindControl("Label6"), Label).Text
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
                    lblErrorMsg.Text = "Select Atleast One Record to Post."
                    Lblmsg.Text = ""
                Else
                    prop.ChkID = id
                    DayBookManagerO.PostToDayBook(prop)
                    Lblmsg.Text = "Record posted successfully."
                    lblErrorMsg.Text = ""
                    display1()
                End If
                'Else
                '    lblErrorMsg.Text = "Not Authorized to Post."
                '    Lblmsg.Text = ""
                'End If
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot post data."
                Lblmsg.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
        End If

    End Sub
    Sub CheckAll()
        If CType(GVDayBook.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVDayBook.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVDayBook.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Protected Sub BtnShowNotPosted_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShowNotPosted.Click
        If Session("Privilages").ToString.Contains("R") Or Session("Privilages").ToString.Contains("W") Then

            lblErrorMsg.Text = ""
            Lblmsg.Text = ""
            If btnDetails.Text <> "BACK" Then
                GVDayBook.PageIndex = ViewState("PageIndex")
                AssignEntitySearch()
                displayNotPosted()
            Else
                btnSave.Text = "ADD"
                btnDetails.Text = "VIEW"
                clear()
                GVDayBook.PageIndex = ViewState("PageIndex")
                AssignEntitySearch()
                displayNotPosted()
            End If
        Else
            lblErrorMsg.Text = "You do not have Read Privilage"
        End If
    End Sub
    Sub displayNotPosted()
        AssignEntityIndividual()
        dt = DayBookManagerO.GetDayBookGVDaybook1(prop)
        If dt.Rows.Count > 0 Then
            GVDayBook.DataSource = dt
            GVDayBook.DataBind()
            GVDayBook.Visible = True
            GVDayBook.Enabled = True
        Else
            lblErrorMsg.Text = "No records to display."
            Lblmsg.Text = ""
            GVDayBook.Visible = False
        End If
        payment()
    End Sub
    Protected Sub Btnreceipt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreceipt.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("P") Then

            Dim id As String = ""
            Dim check As String = ""
            Dim id1 As String = ""
            Dim count As New Integer
            count = 0
            For Each grid As GridViewRow In GVDayBook.Rows
                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("Label6"), Label).Text
                    id = check + "," + id
                    count = count + 1
                Else
                    lblErrorMsg.Text = ""
                    Lblmsg.Text = ""
                End If
            Next
            If id = "" Then
                id = "0"
                count = 0
            Else
                id = Left(id, id.Length - 1)
            End If
            dt = DayBookDB.GetCheckPost(id)
            If dt.Rows.Count > 0 Then
                lblErrorMsg.Text = "Records are not posted cannot Print."
                Lblmsg.Text = ""
                Exit Sub
            End If
            If count <> 0 Then


                Dim qrystring As String = "RptReceiptsV.aspx?" & QueryStr.Querystring() & "&id=" & id
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            Else

                lblErrorMsg.Text = "Select Atleast one record to print Receipt."
                Lblmsg.Text = ""
            End If
            'Response.Redirect("RptReceiptsV.aspx")
        Else
            lblErrorMsg.Text = "You do not have Print Privilage."
        End If
    End Sub


    Protected Sub BtnVoucher_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnVoucher.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("P") Then
            Dim id As String = ""
            Dim check As String = ""
            Dim id1 As String = ""
            Dim count As New Integer
            count = 0
            For Each grid As GridViewRow In GVDayBook.Rows
                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("Label6"), Label).Text
                    id = check + "," + id
                    count = count + 1
                Else
                    lblErrorMsg.Text = ""
                    Lblmsg.Text = ""
                End If
            Next
            If id = "" Then
                id = "0"
                count = 0
            Else
                id = Left(id, id.Length - 1)
            End If
            dt = DayBookDB.GetCheckPost(id)
            If dt.Rows.Count > 0 Then
                lblErrorMsg.Text = "Records are not posted cannot Print Voucher."
                Lblmsg.Text = ""
                Exit Sub
            End If
            If count <> 0 Then


                Dim qrystring As String = "RptVoucherV.aspx?" & QueryStr.Querystring() & "&id=" & id
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            Else

                lblErrorMsg.Text = "Select Atleast one record to print."
                Lblmsg.Text = ""
            End If

            'Response.Redirect("RptReceiptsV.aspx")
        Else
            lblErrorMsg.Text = "You do not have Print Privilage."
        End If
    End Sub

    Protected Sub ddlPaymentMethod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentMethod.SelectedIndexChanged
        payment()
        txtAmt.Focus()
    End Sub
    Sub payment()
        If ddlPaymentMethod.SelectedValue = 1 Then
            txtBank.Visible = False
            txtBranch.Visible = False
            txtChk.Visible = False
            txtBillDate.Visible = False
            Label12.Visible = False
            Label15.Visible = False
            Label13.Visible = False
            Label11.Visible = False
            txtChequeBank.Visible = False
            Label17.Visible = False
            txtRemarks1.Visible = True
            txtRemarks.Visible = False
            Label18.Visible = True
            Label14.Visible = False
        Else
            txtBank.Visible = True
            txtBranch.Visible = True
            txtChk.Visible = True
            txtBillDate.Visible = True
            Label12.Visible = True
            Label15.Visible = True
            Label13.Visible = True
            Label11.Visible = True
            txtRemarks1.Visible = False
            txtRemarks.Visible = True
            Label18.Visible = False
            Label14.Visible = True
        End If

    End Sub

    Protected Sub btnCheque_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCheque.Click
        Dim path, FName As String
        Lblmsg.Text = ""
        lblErrorMsg.Text = ""
        dt = DayBookDB.GetPrintPath()
        If dt.Rows.Count > 0 Then
            Path = dt.Rows(0).Item("Config_Value")
            FName = IO.Path.GetFileName(path)
            If IO.File.Exists(path) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "callFunctionsStartupScript", "RunExe();", True)
            Else
                lblErrorMsg.Text = "PrintCheque.exe file not found."
            End If
        Else
            lblErrorMsg.Text = "No records to display."
        End If

    End Sub

    Protected Sub ChkWithCode_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkWithCode.CheckedChanged
        prop.AGOne = cmbAGOne.SelectedValue
        prop.ATOne = cmbAOT.SelectedValue
        If ChkWithCode.Checked = True Then
            prop.Code = "Y"
        Else
            prop.Code = "N"
        End If
        dt = Acct.GetAccountHeadByIdGroup(prop)
        cmbAccHead.DataSource = dt
        cmbAccHead.DataBind()
    End Sub

    Protected Sub cmbAGOne_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAGOne.SelectedIndexChanged
        prop.AGOne = cmbAGOne.SelectedValue
        prop.ATOne = cmbAOT.SelectedValue
        If ChkWithCode.Checked = True Then
            prop.Code = "Y"
        Else
            prop.Code = "N"
        End If
        dt = Acct.GetAccountHeadByIdGroup(prop)
        cmbAccHead.DataSource = dt
        cmbAccHead.DataBind()
    End Sub

    Protected Sub cmbAOT_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAOT.SelectedIndexChanged
        prop.AGOne = cmbAGOne.SelectedValue
        prop.ATOne = cmbAOT.SelectedValue
        If ChkWithCode.Checked = True Then
            prop.Code = "Y"
        Else
            prop.Code = "N"
        End If
        dt = Acct.GetAccountHeadByIdGroup(prop)
        cmbAccHead.DataSource = dt
        cmbAccHead.DataBind()
    End Sub
End Class