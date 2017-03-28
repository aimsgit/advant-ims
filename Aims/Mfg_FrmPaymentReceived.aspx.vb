
Partial Class Mfg_FrmPaymentReceived
    Inherits BasePage
    Dim Bl As New Mfg_BLPaymentReceived
    Dim EL As New Mfg_ElPaymentMade
    Dim dt, dt1 As New DataTable
    Dim DayBookManagerO As New DayBookManager
    Dim EN As DayBookEL

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Txtexchangerate.Text = "1.00"
        txtEntryDate.Text = Today.ToString("dd-MMM-yyyy")
        Txtexchangerate.Enabled = False
        Txtpayable.Enabled = False
        Txtpayable1.Enabled = False
        Txttotalpaid.Enabled = False
        Txttotalpaid1.Enabled = False
        Txtbalance.Enabled = False
        Txtbalance1.Enabled = False
        dt = DayBookManagerO.GetCurrency()
        If dt.Rows.Count > 0 Then
            cmbCurrency.SelectedValue = dt.Rows(0).Item("Config_Value")
        Else
            cmbCurrency.SelectedValue = 3
        End If
    End Sub
    Protected Sub cmbCurrency_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCurrency.SelectedIndexChanged
        If Txtpayable.Text = "" Then
            Dim MC1 As New MultiCurrencyManager
            Dim MCD As MultiCurrency = MC1.GetMulticurrencyRate(CInt(IIf(cmbCurrency.SelectedValue.ToString = "", 0, cmbCurrency.SelectedValue.ToString)))
            dt = DayBookManagerO.GetCurrency()
            If dt.Rows.Count > 0 Then
                EN.Currency = dt.Rows(0).Item("Config_Value")
                dt1 = DayBookManagerO.GetCurrencyRate(EN)
                EN.Currency = dt1.Rows(0).Item("Buy_Conversion_Rate")
                Txtexchangerate.Text = (MCD.BuyConversionRate / EN.Currency)
            Else
                Txtexchangerate.Text = MCD.BuyConversionRate
            End If
        Else
            Dim MC1 As New MultiCurrencyManager
            Dim MCD As MultiCurrency = MC1.GetMulticurrencyRate(CInt(IIf(cmbCurrency.SelectedValue.ToString = "", 0, cmbCurrency.SelectedValue.ToString)))
            dt = DayBookManagerO.GetCurrency()
            If dt.Rows.Count > 0 Then
                EN.Currency = dt.Rows(0).Item("Config_Value")
                dt1 = DayBookManagerO.GetCurrencyRate(EN)
                EN.Currency = dt1.Rows(0).Item("Buy_Conversion_Rate")
                Txtexchangerate.Text = (MCD.BuyConversionRate / EN.Currency)
            Else
                Txtexchangerate.Text = MCD.BuyConversionRate
            End If

            EL.supplier = DdlBuyer.SelectedValue

            dt = Bl.Getbuyerdetails(EL)
            dt1 = Bl.amtpaid(EL)
            If dt.Rows.Count > 0 Then
                Dim Amttotal As New Integer
                Amttotal = 0
                For Each rows As GridViewRow In GridView1.Rows
                    Amttotal = Amttotal + CType(rows.FindControl("Lblamtrec1"), Label).Text
                Next
                Txttotalpaid.Text = Amttotal

                Txtpayable.Text = Format(dt.Rows(0).Item("FinalAmount"), "0.00")
                Txtpayable.Text = Format(Txtpayable.Text * Txtexchangerate.Text, "0.00")
                Txttotalpaid.Text = Format(Txttotalpaid.Text * Txtexchangerate.Text, "0.00")
                Txtbalance.Text = Format(Txtpayable.Text - Txttotalpaid.Text, "0.00")
            Else
                Txtpayable.Text = "0.00"
                Txttotalpaid.Text = "0.00"
                Txtbalance.Text = "0.00"
            End If
        End If
          
    End Sub


    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim PR As String
        If Session("Privilages").ToString.Contains("W") Then
            Try


                EL.currency = cmbCurrency.SelectedValue
                If txtEntryDate.Text = "" Then
                    EL.entrydate = "#1/1/3000#"
                Else
                    EL.entrydate = txtEntryDate.Text
                End If
                EL.ExchangeRate = Txtexchangerate.Text
                EL.supplier = DdlBuyer.SelectedValue
                EL.Address = txtAddress.Text
                EL.InvoiceNo = ddlInvoiceNo.SelectedValue

                EL.AmtPaid = txtAmntReceived.Text

                If TxtRdate.Text = "" Then
                    EL.RecDate = "#1/1/3000#"
                Else
                    EL.RecDate = TxtRdate.Text
                End If

                EL.PaymentMethod = ddlPaymentMethod.SelectedValue
                If TxtVno.Text = "" Then
                    EL.VoucherNo = 0
                Else
                    EL.VoucherNo = TxtVno.Text
                End If

                EL.ChequeNo = txtChqno.Text
                EL.Bank = ddlBank.SelectedValue
                EL.Branch = Txtbranch.Text
                EL.Remarks = TxtRemarks.Text
                TxtPR.Text = "PR"
                PR = TxtPR.Text
                If btnAdd.Text = "UPDATE" Then

                    EL.id = ViewState("Payments_Id")

                    If dt.Rows.Count > 0 Then
                        'DisplayGrid()
                        lblmsg.Text = ""
                        msginfo.Text = "Data already exists."
                    Else
                        Bl.UpdateRecord(EL)
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"
                        clear()
                        GVPaymentMade.PageIndex = ViewState("PageIndex")
                        DisplayGrid()
                        msginfo.Text = ""
                        lblmsg.Text = "Data Updated Successfully."
                        DdlBuyer.Items.Clear()
                        DdlBuyer.DataSourceID = "objBuyer"
                        DdlBuyer.DataBind()
                        Txtpayable.Text = ""
                        Txtpayable1.Text = ""
                        Txttotalpaid.Text = ""
                        Txttotalpaid1.Text = ""
                        Txtbalance.Text = ""
                        Txtbalance1.Text = ""
                    End If
                ElseIf btnAdd.Text = "ADD" Then

                    'dt = BL.GetDuplicateYear(EL.Area, EL.id)
                    If dt.Rows.Count > 0 Then
                        DisplayGrid()
                        clear()
                        lblmsg.Text = ""
                        msginfo.Text = "Data already exists."
                    Else
                        Bl.InsertRecord(EL, PR)


                        ViewState("PageIndex") = 0
                        GVPaymentMade.PageIndex = 0
                        DisplayGrid()
                        clear()
                        msginfo.Text = ""
                        lblmsg.Text = "Data Saved Successfully."
                        DdlBuyer.Items.Clear()
                        DdlBuyer.DataSourceID = "objBuyer"
                        DdlBuyer.DataBind()
                        Txtpayable.Text = ""
                        Txtpayable1.Text = ""
                        Txttotalpaid.Text = ""
                        Txttotalpaid1.Text = ""
                        Txtbalance.Text = ""
                        Txtbalance1.Text = ""
                    End If
                End If
            Catch ex As Exception
                msginfo.Text = "Date is not valid."
            End Try
        Else
            msginfo.Text = "You do not have Write Privilage."
        End If
    End Sub
    Sub clear()
        txtAddress.Text = ""
        txtAmntReceived.Text = ""
        TxtVno.Text = ""
        txtChqno.Text = ""
        Txtbranch.Text = ""
        TxtRemarks.Text = ""
    End Sub
    Sub DisplayGrid()
        Dim dt As New DataTable
        EL.id = 0
        GVPaymentMade.Enabled = True
        dt = Bl.getDetails(EL)
        If dt.Rows.Count > 0 Then
            GVPaymentMade.DataSource = dt
            GVPaymentMade.DataBind()
            GVPaymentMade.Visible = True
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
            GVPaymentMade.Visible = False
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then
            LinkButton1.Focus()
            If btnView.Text = "VIEW" Then
                msginfo.Text = ""
                lblmsg.Text = ""
                ViewState("PageIndex") = 0
                GVPaymentMade.PageIndex = 0
                DisplayGrid()
            ElseIf btnView.Text = "BACK" Then
                btnAdd.Text = "ADD"
                btnView.Text = "VIEW"
                msginfo.Text = ""
                clear()
                GVPaymentMade.PageIndex = ViewState("PageIndex")
                DisplayGrid()
            End If
        Else
            msginfo.Text = "You do not have Read Privilage."
        End If
    End Sub

    Protected Sub ddlPaymentMethod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentMethod.SelectedIndexChanged
        If ddlPaymentMethod.SelectedItem.Value = "1" Then
            txtChqno.Enabled = False
            ddlBank.Enabled = False
            Txtbranch.Enabled = False
        Else
            txtChqno.Enabled = True
            ddlBank.Enabled = True
            Txtbranch.Enabled = True
        End If

    End Sub

    Protected Sub GVPaymentMade_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVPaymentMade.RowDeleting
        If Session("Privilages").ToString.Contains("W") Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                ViewState("Payments_Id") = CType(GVPaymentMade.Rows(e.RowIndex).Cells(1).FindControl("GID"), HiddenField).Value
                EL.id = ViewState("Payments_Id")
                Bl.DeleteRecord(EL.id)
                lblmsg.Text = "Data Deleted Successfully."
                DisplayGrid()
                cmbCurrency.Focus()
                GVPaymentMade.PageIndex = ViewState("PageIndex")
                Txtpayable.Text = ""
                Txtpayable1.Text = ""
                Txttotalpaid.Text = ""
                Txttotalpaid1.Text = ""
                Txtbalance.Text = ""
                Txtbalance1.Text = ""
                DdlBuyer.Items.Clear()
                DdlBuyer.DataSourceID = "objBuyer"
                DdlBuyer.DataBind()
            Else
                msginfo.Text = "You do not belong to this branch, Cannot delete data."
                lblmsg.Text = ""
            End If
        Else
            msginfo.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub GVPaymentMade_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVPaymentMade.RowEditing
        If Session("Privilages").ToString.Contains("W") Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                lblmsg.Text = ""
                msginfo.Text = ""

                cmbCurrency.SelectedValue = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lblcurrency"), Label).Text

                txtEntryDate.Text = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lblentrydate"), Label).Text
                DdlBuyer.SelectedValue = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lblsupname"), Label).Text
                txtAddress.Text = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lbladdress"), Label).Text
                ddlInvoiceNo.Items.Clear()
                ddlInvoiceNo.DataSourceID = "objInvoiceNo"
                ddlInvoiceNo.DataBind()
                ddlInvoiceNo.SelectedValue = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lblinvno"), Label).Text
                txtAmntReceived.Text = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lblamtpaid"), Label).Text
                TxtRdate.Text = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lbldaterec"), Label).Text
                ddlPaymentMethod.SelectedValue = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lblpmethod"), Label).Text
                TxtVno.Text = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lblvno"), Label).Text
                txtChqno.Text = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lblchqno"), Label).Text
                If ddlBank.SelectedValue = "0" Then
                    ddlBank.Items.Clear()

                    'ddlCourse.Items.Add("Select")
                    ddlBank.DataSourceID = "ObjBank"
                    ddlBank.DataBind()
                Else
                    ddlBank.SelectedValue = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lblbankname"), Label).Text
                End If


                Txtbranch.Text = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lblbranch"), Label).Text
                TxtRemarks.Text = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("Lblremarks"), Label).Text

                ViewState("Payments_Id") = CType(GVPaymentMade.Rows(e.NewEditIndex).FindControl("GID"), HiddenField).Value
                btnAdd.Text = "UPDATE"
                EL.id = ViewState("Payments_Id")

                dt = Bl.getDetails(EL)
                GVPaymentMade.DataSource = dt
                GVPaymentMade.DataBind()
                e.Cancel = True
                GVPaymentMade.Enabled = False
                btnView.Text = "BACK"
                btnView.Visible = True
                Txtpayable.Text = ""
                Txtpayable1.Text = ""
                Txttotalpaid.Text = ""
                Txttotalpaid1.Text = ""
                Txtbalance.Text = ""
                Txtbalance1.Text = ""
            Else
                msginfo.Text = "You do not belong to this branch, Cannot edit data."
                lblmsg.Text = ""
            End If
        Else
            msginfo.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub DdlBuyer_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlBuyer.SelectedIndexChanged
        Dim Amttotal As New Integer

        EL.supplier = DdlBuyer.SelectedValue
        dt = Bl.Getbuyerdetails(EL)
        If dt.Rows.Count > 0 Then
            lblmsg.Text = ""
            msginfo.Text = ""

            EL.ExchangeRate = Txtexchangerate.Text
            If dt.Rows(0).Item("TotalGrandFinalAmount").ToString = Nothing Then
                Txtpayable.Text = "0"
            Else
                Txtpayable.Text = Format(dt.Rows(0).Item("TotalGrandFinalAmount"), "0.00")
            End If
            If dt.Rows(0).Item("TotalGrandFinalAmount").ToString = Nothing Then
                Txtpayable1.Text = "0"
            Else
                Txtpayable1.Text = Format(dt.Rows(0).Item("TotalGrandFinalAmount"), "0.00")
            End If

            'Txttotalpaid1.Text = Format(dt1.Rows(0).Item("Amt_Paid"), "0.00").ToString
            dt1 = Bl.amtpaid(EL)
            GridView1.DataSource = dt1
            GridView1.DataBind()
            Amttotal = 0
            For Each rows As GridViewRow In GridView1.Rows
                Amttotal = Amttotal + CType(rows.FindControl("Lblamtrec1"), Label).Text
            Next
            Txttotalpaid.Text = Amttotal
            Txttotalpaid1.Text = Amttotal
            Txtbalance.Text = Format(Txtpayable.Text - Txttotalpaid.Text, "0.00")
            Txtbalance1.Text = Format(Txtpayable1.Text - Txttotalpaid1.Text, "0.00")
        Else
            Txtpayable1.Text = "0.00"
            Txtpayable.Text = "0.00"
            Txttotalpaid.Text = "0.00"
            Txttotalpaid1.Text = "0.00"
            Txtbalance.Text = "0.00"
            Txtbalance1.Text = "0.00"


        End If


    End Sub
End Class
