Imports System.Web.UI.WebControls
Partial Class loanmaster
    Inherits BasePage
    Private Bll As New loanmasterB
    Private Prop As New loanmasterE
    Private DAL As New loanmasterDA
    Dim dt As New DataTable
    Public LoanId As Int64

    Dim GlobalFunction As New GlobalFunction
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Click
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then
                lblmsg.Text = ""
                msginfo.Text = ""
                If BtnAdd.Text = "ADD" Then
                    Try
                        'Prop.Empid = HidempId.Value
                        If ddlEmpName.SelectedValue = 0 Then
                            lblmsg.Text = "Select Employee Name."
                            ddlEmpName.Focus()
                            Exit Sub
                        Else
                            Prop.Empname = ddlEmpName.SelectedValue
                            lblmsg.Text = ""
                        End If

                        If txtBank.Text = "" Then
                            Prop.bank = 0
                        Else
                            Prop.bank = HidBank.Value
                        End If

                        Prop.branch = txtBranch.Text
                        If RBType.SelectedValue.ToString = "L" Then
                            If txtLoanno.Text = "" Then
                                lblmsg.Text = "Enter Loan Number."
                                msginfo.Text = ""
                                txtLoanno.Focus()
                                Exit Sub
                            Else
                                Prop.Loanidcode = txtLoanno.Text
                                lblmsg.Text = ""
                                msginfo.Text = ""
                            End If
                        Else
                            lblLoanno.Visible = False
                            lblLoanType.Visible = False
                            lblLoandate.Visible = False
                            lblLoanamount.Visible = False

                            lblAdvanceno.Visible = True
                            lblAdvanceType.Visible = True
                            lblAdvancedate.Visible = True
                            lblAdvanceAmount.Visible = True
                            If txtLoanno.Text = "" Then
                                lblmsg.Text = "Enter Advance Number."
                                msginfo.Text = ""
                                txtLoanno.Focus()
                                Exit Sub
                            Else
                                Prop.Loanidcode = txtLoanno.Text
                                lblmsg.Text = ""
                                msginfo.Text = ""
                            End If
                        End If
                        If RBType.SelectedValue.ToString = "L" Then
                            If ddlLoanType.SelectedValue = 0 Then
                                lblmsg.Text = "Select Loan Type."
                                msginfo.Text = ""
                                ddlLoanType.Focus()
                                Exit Sub
                            Else
                                Prop.Loantype = ddlLoanType.SelectedValue
                                lblmsg.Text = ""
                                msginfo.Text = ""
                            End If
                        Else
                            If ddlLoanType.SelectedValue = 0 Then
                                lblmsg.Text = "Select Advance Type."
                                ddlLoanType.Focus()
                                Exit Sub
                            Else
                                Prop.Loantype = ddlLoanType.SelectedValue
                                lblmsg.Text = ""
                            End If
                        End If

                        If RBType.SelectedValue.ToString = "L" Then
                            If txtLoandate.Text = "" Then
                                lblmsg.Text = "Enter Loan Date."
                                txtLoandate.Focus()
                                Exit Sub
                            Else
                                Prop.Loandate = txtLoandate.Text
                                lblmsg.Text = ""
                            End If
                        Else
                            If txtLoandate.Text = "" Then
                                lblmsg.Text = "Enter Advance Date."
                                txtLoandate.Focus()
                                Exit Sub
                            Else
                                Prop.Loandate = txtLoandate.Text
                                lblmsg.Text = ""
                            End If
                        End If
                        If RBType.SelectedValue.ToString = "L" Then
                            If txtLoanamount.Text = "" Then
                                lblmsg.Text = "Enter Loan Amount."
                                txtLoanamount.Focus()
                                Exit Sub
                            Else
                                Prop.Loanamount = txtLoanamount.Text
                                lblmsg.Text = ""
                            End If
                        Else
                            If txtLoanamount.Text = "" Then
                                lblmsg.Text = "Enter Advance Amount."
                                txtLoanamount.Focus()
                                Exit Sub
                            Else
                                Prop.Loanamount = txtLoanamount.Text
                                lblmsg.Text = ""
                            End If
                        End If


                        If txtInterestrate.Text = "" Then
                            Prop.Interestrate = 0.0
                        Else
                            Prop.Interestrate = txtInterestrate.Text
                        End If
                        Prop.PaymentMethod = ddlPaymentMethod.SelectedValue
                        Prop.ChqNo = txtchqno.Text
                        If txtChequedate.Text = "" Then
                            Prop.Chequedate = CDate("1/1/1900")
                        Else
                            Prop.Chequedate = txtChequedate.Text
                        End If
                        If txtMonthlydeduction.Text = "" Then
                            Prop.monthlyded = 0.0
                        Else
                            Prop.monthlyded = txtMonthlydeduction.Text
                        End If

                        If txtBalanceloan.Text = "" Then
                            Prop.Balanceloan = 0.0
                        Else
                            Prop.Balanceloan = txtBalanceloan.Text
                        End If
                        If txtInstallments.Text = "" Then
                            Prop.TotalInstallment = 0
                        Else
                            Prop.TotalInstallment = txtInstallments.Text
                        End If
                        If txtInstallmentCollected.Text = "" Then
                            Prop.InstallmentCollected = 0
                        Else
                            Prop.InstallmentCollected = txtInstallmentCollected.Text
                        End If
                        If txtCurrentMonthDedu.Text = "" Then
                            Prop.CurrentMonthDedu = 0
                        Else
                            Prop.CurrentMonthDedu = txtCurrentMonthDedu.Text
                        End If
                        If txtOpeningBal.Text = "" Then
                            Prop.OpeningBalance = 0
                        Else
                            Prop.OpeningBalance = txtOpeningBal.Text
                        End If
                        Prop.Startdate = txtStartdate.Text
                        Prop.GuaranteedBy1 = txtGuaranteedBy1.Text
                        Prop.GuaranteedBy2 = txtGuaranteedBy2.Text
                        Prop.Remarks = txtRemarks.Text
                        If chkRecovered.Checked = True Then
                            Prop.Recovered = "Y"
                        Else
                            Prop.Recovered = "N"
                        End If
                        GridView1.Enabled = True
                        msginfo.Text = ""
                        If RBType.SelectedValue.ToString = "L" Then
                            Prop.AmountType = "L"
                        Else
                            Prop.AmountType = "A"
                        End If
                        dt = Bll.GetDuplicateLoanMaster(Prop)
                        If dt.Rows.Count > 0 Then
                            If RBType.SelectedValue.ToString = "L" Then
                                AlertEnterAllFields("Loan Number already exists.")
                                txtLoanno.Focus()
                                Exit Sub
                            Else
                                AlertEnterAllFields("Advance Number already exists.")
                                txtLoanno.Focus()
                                Exit Sub
                            End If

                        ElseIf (Val(txtMonthlydeduction.Text) > Val(txtLoanamount.Text)) Then
                            If RBType.SelectedValue.ToString = "L" Then
                                lblmsg.Text = "Monthly Deduction cannot be more than Loan Amount."
                                txtMonthlydeduction.Focus()
                                Exit Sub
                            Else
                                lblmsg.Text = "Monthly Deduction cannot be more than Advance Amount."
                                txtMonthlydeduction.Focus()
                                Exit Sub
                            End If
                        ElseIf (Val(txtBalanceloan.Text) > Val(txtLoanamount.Text)) Then
                            If RBType.SelectedValue.ToString = "L" Then
                                lblmsg.Text = "Closing Balance cannot be more than Loan Amount."
                                txtBalanceloan.Focus()
                                Exit Sub
                            Else
                                lblmsg.Text = "Closing Balance cannot be more than Advance Amount."
                                txtBalanceloan.Focus()
                                Exit Sub
                            End If
                        ElseIf (CDate(txtStartdate.Text) < CDate(txtLoandate.Text)) Then
                            If RBType.SelectedValue.ToString = "L" Then
                                lblmsg.Text = "Start Date cannot be Smaller than Loan Date."
                                txtStartdate.Focus()
                                Exit Sub
                            Else
                                lblmsg.Text = "Start Date cannot be Smaller than Advance Date."
                                txtStartdate.Focus()
                                Exit Sub
                            End If
                        Else
                            If RBType.SelectedValue.ToString = "L" Then
                                Prop.AmountType = "L"
                            Else
                                Prop.AmountType = "A"
                            End If

                            msginfo.Text = ""
                            Bll.insertRecord(Prop)
                            AlertEnterAllField("Data Saved Successfully.")
                            txtChequedate.Text = Format(Today(), "dd-MMM-yyyy")

                            'Prop.Empid = 0
                            ViewState("PageIndex") = 0
                            GridView1.PageIndex = 0
                            GridView2.PageIndex = 0
                            Binddata(Prop)
                            btn_enabled()
                            clear()
                            If RBType.SelectedValue = "A" Then
                                GridView2.Visible = True
                                GridView1.Visible = False
                            Else
                                GridView1.Visible = True
                                GridView2.Visible = False
                            End If
                            ddlEmpName.Focus()
                            txtStartdate.Text = Format(Today, "dd-MMM-yyyy")
                        End If
                    Catch ex As Exception
                        lblmsg.Text = "Enter Correct data."
                        ddlEmpName.Focus()
                    End Try
                ElseIf BtnAdd.Text = "UPDATE" Then
                    Try
                        Prop.Loanid = ViewState("LoanID")
                        'Prop.Empid = ViewState("EmpId")
                        'Prop.Empid = HidempId.Value
                        If ddlEmpName.SelectedValue = 0 Then
                            lblmsg.Text = "Select Employee Name."
                            Exit Sub
                        Else
                            Prop.Empname = ddlEmpName.SelectedValue
                            lblmsg.Text = ""
                        End If
                        If RBType.SelectedValue.ToString = "L" Then
                            If txtLoanno.Text = "" Then
                                lblmsg.Text = "Enter Loan Number."
                                Exit Sub
                            Else
                                Prop.Loanidcode = txtLoanno.Text
                                lblmsg.Text = ""
                            End If
                        Else
                            If txtLoanno.Text = "" Then
                                lblmsg.Text = "Enter Advance Number."
                                Exit Sub
                            Else
                                Prop.Loanidcode = txtLoanno.Text
                                lblmsg.Text = ""
                            End If
                        End If

                        If RBType.SelectedValue.ToString = "L" Then
                            If ddlLoanType.SelectedValue = 0 Then
                                lblmsg.Text = "Select Loan Type."
                                Exit Sub
                            Else
                                Prop.Loantype = ddlLoanType.SelectedValue
                                lblmsg.Text = ""
                            End If
                        Else
                            If ddlLoanType.SelectedValue = 0 Then
                                lblmsg.Text = "Select Advance Type."
                                Exit Sub
                            Else
                                Prop.Loantype = ddlLoanType.SelectedValue
                                lblmsg.Text = ""
                            End If
                        End If
                        Prop.PaymentMethod = ddlPaymentMethod.SelectedValue
                        Prop.bank = HidBank.Value
                        Prop.branch = txtBranch.Text
                        If RBType.SelectedValue.ToString = "L" Then
                            If txtLoandate.Text = "" Then
                                lblmsg.Text = "Enter Loan date."
                                Exit Sub
                            Else
                                Prop.Loandate = txtLoandate.Text
                            End If

                        Else
                            If txtLoandate.Text = "" Then
                                lblmsg.Text = "Enter Advance date."
                                Exit Sub
                            Else
                                Prop.Loandate = txtLoandate.Text
                            End If
                        End If

                        If RBType.SelectedValue.ToString = "L" Then
                            If txtLoanamount.Text = "" Then
                                lblmsg.Text = "Enter Loan Amount."
                                Exit Sub
                            Else
                                Prop.Loanamount = txtLoanamount.Text
                                lblmsg.Text = ""
                            End If
                        Else
                            If txtLoanamount.Text = "" Then
                                lblmsg.Text = "Enter Advance Amount."
                            Else
                                Prop.Loanamount = txtLoanamount.Text
                                lblmsg.Text = ""
                            End If
                        End If
                        If txtInterestrate.Text = "" Then
                            Prop.Interestrate = 0.0
                        Else
                            Prop.Interestrate = txtInterestrate.Text
                        End If
                        Prop.ChqNo = txtchqno.Text
                        If txtChequedate.Text = "" Then
                            Prop.Chequedate = CDate("1/1/1900")
                        Else
                            Prop.Chequedate = txtChequedate.Text
                        End If

                        If txtMonthlydeduction.Text = "" Then
                            Prop.monthlyded = 0.0
                        Else
                            Prop.monthlyded = txtMonthlydeduction.Text
                        End If

                        If txtBalanceloan.Text = "" Then
                            Prop.Balanceloan = 0.0
                        Else
                            Prop.Balanceloan = txtBalanceloan.Text
                        End If
                        If txtInstallments.Text = "" Then
                            Prop.TotalInstallment = 0
                        Else
                            Prop.TotalInstallment = txtInstallments.Text
                        End If
                        If txtInstallmentCollected.Text = "" Then
                            Prop.InstallmentCollected = 0
                        Else
                            Prop.InstallmentCollected = txtInstallmentCollected.Text
                        End If
                        If txtCurrentMonthDedu.Text = "" Then
                            Prop.CurrentMonthDedu = 0
                        Else
                            Prop.CurrentMonthDedu = txtCurrentMonthDedu.Text
                        End If
                        If txtOpeningBal.Text = "" Then
                            Prop.OpeningBalance = 0
                        Else
                            Prop.OpeningBalance = txtOpeningBal.Text
                        End If
                        Prop.Startdate = txtStartdate.Text
                        Prop.GuaranteedBy1 = txtGuaranteedBy1.Text
                        Prop.GuaranteedBy2 = txtGuaranteedBy2.Text
                        Prop.Remarks = txtRemarks.Text
                        If chkRecovered.Checked = True Then
                            Prop.Recovered = "Y"
                        Else
                            Prop.Recovered = "N"
                        End If

                        If (Val(txtMonthlydeduction.Text) > Val(txtLoanamount.Text)) Then
                            If RBType.SelectedValue.ToString = "L" Then
                                lblmsg.Text = "Monthly Deduction cannot be more than Loan Amount."
                                txtMonthlydeduction.Focus()
                                Exit Sub
                            Else
                                lblmsg.Text = "Monthly Deduction cannot be more than Advance Amount."
                                txtMonthlydeduction.Focus()
                                Exit Sub
                            End If

                        ElseIf (Val(txtBalanceloan.Text) > Val(txtLoanamount.Text)) Then
                            If RBType.SelectedValue.ToString = "L" Then
                                lblmsg.Text = "Closing Balance cannot be more than Loan Amount."
                                txtBalanceloan.Focus()
                            Else
                                lblmsg.Text = "Closing Balance cannot be more than Advance Amount."
                                txtBalanceloan.Focus()
                            End If
                        ElseIf (CDate(txtStartdate.Text) < CDate(txtLoandate.Text)) Then
                            If RBType.SelectedValue.ToString = "L" Then

                                lblmsg.Text = "Start Date cannot be Smaller than Loan Date."
                                txtStartdate.Focus()
                                Exit Sub
                            Else
                                lblmsg.Text = "Start Date cannot be Smaller than Advance Date."
                                txtStartdate.Focus()
                                Exit Sub
                            End If
                        Else
                            If RBType.SelectedValue.ToString = "L" Then
                                Prop.AmountType = "L"
                            Else
                                Prop.AmountType = "A"
                            End If

                            Dim i As Int64 = Bll.update(Prop)
                            If i > 0 Then
                                AlertEnterAllField("Data Updated Successfully.")
                                txtChequedate.Text = Format(Today(), "dd-MMM-yyyy")
                                GridView1.Enabled = True
                                GridView2.Enabled = True

                                Prop.Loanid = 0
                                GridView1.PageIndex = ViewState("PageIndex")
                                GridView2.PageIndex = ViewState("PageIndex")
                                Binddata1(Prop)
                                btn_enabled()
                                clear()
                                If RBType.SelectedValue = "A" Then
                                    GridView2.Visible = True
                                Else
                                    GridView1.Visible = True
                                End If

                                txtStartdate.Text = Format(Today, "dd-MMM-yyyy")
                            Else
                                AlertEnterAllFields("Data Cannot be Updated.")
                            End If
                        End If
                    Catch ex As Exception
                        lblmsg.Text = "Enter Correct data."
                    End Try
                End If
            Else
                lblmsg.Text = "You do not belong to this branch, Cannot add/update data."
                msginfo.Text = ""
            End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Sub clear()
        'ddlEmpName.SelectedValue = 0
        txtLoanno.Text = ""
        txtLoandate.Text = Format(Today(), "dd-MMM-yyyy")
        txtInterestrate.Text = ""
        txtBank.Text = ""
        txtBranch.Text = ""
        txtMonthlydeduction.Text = ""
        txtchqno.Text = ""
        txtStartdate.Text = Format(Today(), "dd-MMM-yyyy")
        'ddlLoanType.SelectedValue = 0
        txtLoanamount.Text = ""
        txtChequedate.Text = Format(Today(), "dd-MMM-yyyy")
        txtBalanceloan.Text = ""
        HidBank.Value = 0
        txtBank.Text = ""
        txtInstallments.Text = ""
        txtInstallmentCollected.Text = ""
        txtCurrentMonthDedu.Text = ""
        txtOpeningBal.Text = ""
        txtGuaranteedBy1.Text = ""
        txtGuaranteedBy2.Text = ""
        txtRemarks.Text = ""
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading

        lblLoanno.Visible = True
        lblLoanType.Visible = True
        lblLoandate.Visible = True
        lblLoanamount.Visible = True

        lblAdvanceno.Visible = False
        lblAdvanceType.Visible = False
        lblAdvancedate.Visible = False
        lblAdvanceAmount.Visible = False

        If Not Page.IsPostBack Then
            txtLoandate.Text = Format(Today(), "dd-MMM-yyyy")
            txtStartdate.Text = Format(Today(), "dd-MMM-yyyy")
            txtChequedate.Text = Format(Today(), "dd-MMM-yyyy")
        End If
        If txtBank.Text <> "" Then
            SplitBank(txtBank.Text)
        Else
            txtBank.AutoPostBack = True
            SplitBank(txtBank.Text)
        End If
        ddlEmpName.Focus()
    End Sub
    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then

            If BtnView.Text = "VIEW" Then
                If ddlEmpName.SelectedItem.Text = "Select" Then
                    Prop.Empid = 0
                Else
                    Prop.Empid = ddlEmpName.SelectedValue
                End If
                If txtLoanno.Text = "" Then
                    Prop.Loanidcode = 0
                Else
                    Prop.Loanidcode = txtLoanno.Text
                End If
                If ddlLoanType.SelectedItem.Text = "Select" Then
                    Prop.Loantype = 0
                Else
                    Prop.Loantype = ddlLoanType.SelectedValue
                End If
                If RBType.SelectedValue = "A" Then
                    lblLoanno.Visible = False
                    lblLoanType.Visible = False
                    lblLoandate.Visible = False
                    lblLoanamount.Visible = False

                    lblAdvanceno.Visible = True
                    lblAdvanceType.Visible = True
                    lblAdvancedate.Visible = True
                    lblAdvanceAmount.Visible = True

                Else
                    lblLoanno.Visible = True
                    lblLoanType.Visible = True
                    lblLoandate.Visible = True
                    lblLoanamount.Visible = True

                    lblAdvanceno.Visible = False
                    lblAdvanceType.Visible = False
                    lblAdvancedate.Visible = False
                    lblAdvanceAmount.Visible = False
                End If
                Prop.AmountType = RBType.SelectedValue
                GridView1.Enabled = True
                GridView2.Enabled = True
                lblmsg.Text = ""
                msginfo.Text = ""
                'Prop.Empid = 0
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                GridView2.PageIndex = 0
                Binddata(Prop)
                btn_enabled()
                If RBType.SelectedValue = "A" Then
                    GridView2.Visible = True
                Else
                    GridView1.Visible = True
                End If
            ElseIf BtnView.Text = "BACK" Then
                clear()
                GridView1.Enabled = True
                GridView2.Enabled = True
                lblmsg.Text = ""
                msginfo.Text = ""
                Prop.Empid = 0
                Prop.AmountType = RBType.SelectedValue
                GridView1.PageIndex = ViewState("PageIndex")
                Binddata(Prop)
                btn_enabled()
                If RBType.SelectedValue = "A" Then
                    GridView2.Visible = True
                Else
                    GridView1.Visible = True
                End If
            End If
        Else
            lblmsg.Text = "You do not have Read Privilage."
        End If
    End Sub
    Protected Sub GrdLoan_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.Enabled = True
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Binddata(Prop)
    End Sub
    Protected Sub GrdLoan_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then

                Dim id As Int64 = Int64.Parse(GridView1.DataKeys(e.RowIndex).Value.ToString)
                Prop.AmountType = RBType.SelectedValue
                GridView1.Enabled = True
                Bll.delete(id)
                GridView1.PageIndex = ViewState("PageIndex")
                Binddata(Prop)
                AlertEnterAllField("Data Deleted Successfully.")
                ddlEmpName.Focus()
            Else
                lblmsg.Text = "You do not belong to this branch, Cannot delete data."
                msginfo.Text = ""
            End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub


    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        If Session("Privilages").ToString.Contains("W") Then

            'If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim dt As New DataTable
            lblmsg.Text = ""
            msginfo.Text = ""
            btn_disabled()
            ddlEmpName.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Labelempid"), Label).Text
            txtLoanno.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(2).FindControl("Label2"), Label).Text
            ddlLoanType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).Cells(3).FindControl("Label3"), Label).Text
            txtLoandate.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(4).FindControl("Label4"), Label).Text
            txtLoanamount.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(5).FindControl("Label5"), Label).Text
            txtInterestrate.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(6).FindControl("Label6"), Label).Text
            ddlPaymentMethod.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelPaymentMethod"), Label).Text

            txtBank.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("lblBnk"), Label).Text.Trim()
            HidBank.Value = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Label13"), Label).Text.Trim()
            txtBranch.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(6).FindControl("lblBrnch"), Label).Text
            txtchqno.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(7).FindControl("Label7"), Label).Text
            txtChequedate.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(8).FindControl("Label8"), Label).Text
            txtMonthlydeduction.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(9).FindControl("Label9"), Label).Text
            txtBalanceloan.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(10).FindControl("Label10"), Label).Text
            txtStartdate.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(11).FindControl("Label11"), Label).Text
            ViewState("LoanID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HidLoanId"), HiddenField).Value
            ViewState("EmpId") = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Labelempid"), Label).Text
            HidempId.Value = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Labelempid"), Label).Text
            txtInstallments.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(11).FindControl("lblInstallment"), Label).Text
            txtInstallmentCollected.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(11).FindControl("lblInstallmentCollected"), Label).Text
            txtCurrentMonthDedu.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(11).FindControl("lblCurrentMonthlyDedu"), Label).Text
            txtOpeningBal.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(11).FindControl("lblOpeningBal"), Label).Text

            txtGuaranteedBy1.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelGB1"), Label).Text
            txtGuaranteedBy2.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelGB2"), Label).Text
            txtRemarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelRemarks"), Label).Text
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelRecovered"), Label).Text = "Y" Then
                chkRecovered.Checked = True
            Else
                chkRecovered.Checked = False
            End If
            BtnAdd.Text = "UPDATE"
            Prop.Loanid = ViewState("LoanID")
            Prop.AmountType = RBType.SelectedValue
            Binddata(Prop)
            GridView1.Enabled = False
            'Else
            'msginfo.Text = "You do not belong to this branch, Cannot edit data."
            'lblmsg.Text = ""
            'End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub GrdAdvances_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.Enabled = True
        GridView2.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView2.PageIndex
        Binddata(Prop)
    End Sub
    Protected Sub GrdAdvances_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then

                Dim id As Int64 = Int64.Parse(GridView2.DataKeys(e.RowIndex).Value.ToString)
                Prop.AmountType = RBType.SelectedValue
                GridView2.Enabled = True
                Bll.delete(id)
                GridView2.PageIndex = ViewState("PageIndex")
                Binddata(Prop)
                AlertEnterAllField("Data Deleted Successfully.")
                ddlEmpName.Focus()
            Else
                lblmsg.Text = "You do not belong to this branch, Cannot delete data."
                msginfo.Text = ""
            End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub


    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        If Session("Privilages").ToString.Contains("W") Then

            'If (Session("BranchCode") = Session("ParentBranch")) Then

            lblmsg.Text = ""
            msginfo.Text = ""
            btn_disabled()
            ddlEmpName.SelectedValue = CType(GridView2.Rows(e.NewEditIndex).Cells(1).FindControl("Labelempid"), Label).Text
            txtLoanno.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(2).FindControl("Label2"), Label).Text
            ddlLoanType.SelectedValue = CType(GridView2.Rows(e.NewEditIndex).Cells(3).FindControl("Label3"), Label).Text
            txtLoandate.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(4).FindControl("Label4"), Label).Text
            txtLoanamount.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(5).FindControl("Label5"), Label).Text
            txtInterestrate.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(6).FindControl("Label6"), Label).Text
            ddlPaymentMethod.SelectedValue = CType(GridView2.Rows(e.NewEditIndex).FindControl("LabelPaymentMethod"), Label).Text

            txtBank.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(1).FindControl("lblBnk"), Label).Text.Trim()
            HidBank.Value = CType(GridView2.Rows(e.NewEditIndex).Cells(1).FindControl("Label13"), Label).Text.Trim()
            txtBranch.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(6).FindControl("lblBrnch"), Label).Text
            txtchqno.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(7).FindControl("Label7"), Label).Text
            txtChequedate.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(8).FindControl("Label8"), Label).Text
            txtMonthlydeduction.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(9).FindControl("Label9"), Label).Text
            txtBalanceloan.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(10).FindControl("Label10"), Label).Text
            txtStartdate.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(11).FindControl("Label11"), Label).Text
            ViewState("LoanID") = CType(GridView2.Rows(e.NewEditIndex).FindControl("HidLoanId"), HiddenField).Value
            ViewState("EmpId") = CType(GridView2.Rows(e.NewEditIndex).Cells(1).FindControl("Labelempid"), Label).Text
            HidempId.Value = CType(GridView2.Rows(e.NewEditIndex).Cells(1).FindControl("Labelempid"), Label).Text
            txtInstallments.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(11).FindControl("lblInstallment"), Label).Text
            txtInstallmentCollected.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(11).FindControl("lblInstallmentCollected"), Label).Text
            txtCurrentMonthDedu.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(11).FindControl("lblCurrentMonthlyDedu"), Label).Text
            txtOpeningBal.Text = CType(GridView2.Rows(e.NewEditIndex).Cells(11).FindControl("lblOpeningBal"), Label).Text

            txtGuaranteedBy1.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("LabelGB1"), Label).Text
            txtGuaranteedBy2.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("LabelGB2"), Label).Text
            txtRemarks.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("LabelRemarks"), Label).Text
            If CType(GridView2.Rows(e.NewEditIndex).FindControl("LabelRecovered"), Label).Text = "Y" Then
                chkRecovered.Checked = True
            Else
                chkRecovered.Checked = False
            End If
            BtnAdd.Text = "UPDATE"
            Prop.Loanid = ViewState("LoanID")
            Prop.AmountType = RBType.SelectedValue
            Binddata(Prop)
            GridView2.Enabled = False
            'Else
            'msginfo.Text = "You do not belong to this branch, Cannot edit data."
            'lblmsg.Text = ""
            'End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Sub btn_enabled()
        BtnAdd.Text = "ADD"
        BtnView.Text = "VIEW"
        'txtEmp.Text = ""
        'txtLoanno.Text = ""
        'txtloantype.Text = ""
        'txtLoandate.Text = ""
        'txtLoanamount.Text = ""
        'txtInterestrate.Text = ""
        'txtMonthlydeduction.Text = ""
        'txtChequedate.Text = ""
        'txtBalanceloan.Text = ""
        'txtchqno.Text = ""
        'txtStartdate.Text = ""

    End Sub
    Sub btn_disabled()
        BtnAdd.Text = "UPDATE"
        BtnView.Text = "BACK"
        'ddlEmpName.SelectedValue = ""
        'txtLoanno.Text = ""
        'ddlLoanType.SelectedItem.Text = ""
        'txtLoandate.Text = ""
        'txtLoanamount.Text = ""
        'txtInterestrate.Text = ""
        'txtMonthlydeduction.Text = ""
        'txtChequedate.Text = ""
        'txtBalanceloan.Text = ""
        'txtchqno.Text = ""
        'txtStartdate.Text = ""

    End Sub
    Sub AlertEnterAllFields(ByVal str As String)
        msginfo.Text = ""
        lblmsg.Text = str
    End Sub
    Sub AlertEnterAllField(ByVal str As String)
        lblmsg.Text = ""
        msginfo.Text = str
    End Sub
    Sub Binddata(ByVal id1 As loanmasterE)
        LinkButton1.Focus()
        Dim dt As Data.DataTable
        If ddlEmpName.SelectedItem.Text = "Select" Then
            Prop.Empname = 0
        Else
            Prop.Empname = ddlEmpName.SelectedValue
        End If
        If txtLoanno.Text = "" Then
            Prop.Loanidcode = 0
        Else
            Prop.Loanidcode = txtLoanno.Text
        End If
        If ddlLoanType.SelectedItem.Text = "Select" Then
            Prop.Loantype = 0
        Else
            Prop.Loantype = ddlLoanType.SelectedValue
        End If
        If RBType.SelectedValue = "A" Then
            GridView1.Visible = False
            dt = Bll.GetEmp(id1)
            If dt.Rows.Count > 0 Then
                GridView2.DataSource = dt
                GridView2.DataBind()
            Else
                GridView2.DataSource = Nothing
                GridView2.DataBind()
                AlertEnterAllFields("No records to display.")
                ddlEmpName.Focus()
            End If
        Else
            GridView2.Visible = False
            dt = Bll.GetEmp(id1)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
            Else
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                AlertEnterAllFields("No records to display.")
                ddlEmpName.Focus()
            End If
        End If
    End Sub
    Sub Binddata1(ByVal id1 As loanmasterE)
        Dim dt As Data.DataTable
        If ddlEmpName.SelectedItem.Text = "Select" Then
            Prop.Empname = 0

        End If
        If txtLoanno.Text <> "" Then
            Prop.Loanidcode = 0

        End If
        'If txtloantype.Text <> "" Then
        '    Prop.Loantype = 0

        'End If
        If RBType.SelectedValue = "A" Then
            GridView1.Visible = False
            dt = Bll.GetEmp(id1)
            If dt.Rows.Count > 0 Then
                GridView2.DataSource = dt
                GridView2.DataBind()
            Else
                GridView2.DataSource = Nothing
                GridView2.DataBind()
                AlertEnterAllFields("No records to display.")
                ddlEmpName.Focus()
            End If
        Else
            GridView2.Visible = False
            dt = Bll.GetEmp(id1)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
            Else
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                AlertEnterAllFields("No records to display.")
                ddlEmpName.Focus()
            End If
        End If
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub


    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        LinkButton1.Focus()
        Dim dt As Data.DataTable
        If ddlEmpName.SelectedItem.Text = "Select" Then
            Prop.Empname = 0
        Else
            Prop.Empname = ddlEmpName.SelectedValue
        End If
        If txtLoanno.Text = "" Then
            Prop.Loanidcode = 0
        Else
            Prop.Loanidcode = txtLoanno.Text
        End If
        If ddlLoanType.SelectedItem.Text = "Select" Then
            Prop.Loantype = 0
        Else
            Prop.Loantype = ddlLoanType.SelectedValue
        End If
        Prop.AmountType = RBType.SelectedValue     
        dt = Bll.GetEmp(Prop)

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
    End Sub
    Protected Sub GridView2_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView2.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        LinkButton1.Focus()
        Dim dt As Data.DataTable
        If ddlEmpName.SelectedItem.Text = "Select" Then
            Prop.Empname = 0
        Else
            Prop.Empname = ddlEmpName.SelectedValue
        End If
        If txtLoanno.Text = "" Then
            Prop.Loanidcode = 0
        Else
            Prop.Loanidcode = txtLoanno.Text
        End If
        If ddlLoanType.SelectedItem.Text = "Select" Then
            Prop.Loantype = 0
        Else
            Prop.Loantype = ddlLoanType.SelectedValue
        End If
        Prop.AmountType = RBType.SelectedValue
        dt = Bll.GetEmp(Prop)


        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView2.DataSource = sortedView
        GridView2.DataBind()
    End Sub
    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = value
        End Set
    End Property
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

    Protected Sub RBType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBType.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
        If RBType.SelectedValue = "A" Then
            ddlEmpName.SelectedValue = 0
            ddlLoanType.SelectedValue = 0
            ddlPaymentMethod.SelectedValue = 0
            GridView1.Visible = False
            lblLoanno.Visible = False
            lblLoanType.Visible = False
            lblLoandate.Visible = False
            lblLoanamount.Visible = False

            lblAdvanceno.Visible = True
            lblAdvanceType.Visible = True
            lblAdvancedate.Visible = True
            lblAdvanceAmount.Visible = True

        Else
            ddlEmpName.SelectedValue = 0
            ddlLoanType.SelectedValue = 0
            ddlPaymentMethod.SelectedValue = 0
            GridView2.Visible = False
            lblLoanno.Visible = True
            lblLoanType.Visible = True
            lblLoandate.Visible = True
            lblLoanamount.Visible = True

            lblAdvanceno.Visible = False
            lblAdvanceType.Visible = False
            lblAdvancedate.Visible = False
            lblAdvanceAmount.Visible = False
        End If
    End Sub

    Protected Sub ddlEmpName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpName.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
        If RBType.SelectedValue = "A" Then
            GridView1.Visible = False
            lblLoanno.Visible = False
            lblLoanType.Visible = False
            lblLoandate.Visible = False
            lblLoanamount.Visible = False

            lblAdvanceno.Visible = True
            lblAdvanceType.Visible = True
            lblAdvancedate.Visible = True
            lblAdvanceAmount.Visible = True

        Else
            GridView2.Visible = False
            lblLoanno.Visible = True
            lblLoanType.Visible = True
            lblLoandate.Visible = True
            lblLoanamount.Visible = True

            lblAdvanceno.Visible = False
            lblAdvanceType.Visible = False
            lblAdvancedate.Visible = False
            lblAdvanceAmount.Visible = False
        End If
    End Sub

    Protected Sub txtLoanno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLoanno.TextChanged
        If RBType.SelectedValue = "A" Then
            GridView1.Visible = False
            lblLoanno.Visible = False
            lblLoanType.Visible = False
            lblLoandate.Visible = False
            lblLoanamount.Visible = False

            lblAdvanceno.Visible = True
            lblAdvanceType.Visible = True
            lblAdvancedate.Visible = True
            lblAdvanceAmount.Visible = True

        Else
            GridView2.Visible = False
            lblLoanno.Visible = True
            lblLoanType.Visible = True
            lblLoandate.Visible = True
            lblLoanamount.Visible = True

            lblAdvanceno.Visible = False
            lblAdvanceType.Visible = False
            lblAdvancedate.Visible = False
            lblAdvanceAmount.Visible = False
        End If
    End Sub

    Protected Sub ddlPaymentMethod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentMethod.SelectedIndexChanged
        If IsPostBack = True Then
            payment()
            'txtInstallmentCollected.Focus()
        End If
    End Sub
    Sub payment()
        If ddlPaymentMethod.SelectedValue = 1 Then
            txtBank.Visible = False
            txtBranch.Visible = False
            txtchqno.Visible = False
            txtChequedate.Visible = False
            lblBank.Visible = False
            lblBranch.Visible = False
            lblChqno.Visible = False
            lblChequedate.Visible = False
        Else
            txtBank.Visible = True
            txtBranch.Visible = True
            txtchqno.Visible = True
            txtChequedate.Visible = True
            lblBank.Visible = True
            lblBranch.Visible = True
            lblChqno.Visible = True
            lblChequedate.Visible = True
        End If
    End Sub
End Class
