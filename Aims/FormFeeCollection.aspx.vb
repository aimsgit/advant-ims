Imports System.IO
Imports System.Data
Imports System.Collections.Generic

'Author-->Ajit Kumar Singh
'Date---->23-FEB-2012
Partial Class FormFeeCollection
    Inherits BasePage
    Dim Bl As New FeeCollectionBL
    Dim a As String
    Dim sem As Integer
    Dim El As New FeeCollectionEl
    Dim dt As New DataTable
    Dim paid, discount, total1 As New Integer
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        ddlbatch1.Focus()
        lblS.Text = ""
        lblE.Text = ""
        lblGreen1.Text = ""
        lblRed1.Text = ""
        lblTotalFee.Visible = True
        txtTotalFee.Visible = True
        a = ddlbatch1.SelectedValue
        'sem = ddlSemester.SelectedValue
        ViewState("PageIndex") = 0
        GridView1.PageIndex = 0

        DispGrid(a)

        dt = Bl.TotalFeePaid(HidStudentId.Value, ddlAYear.SelectedValue)
        If dt.Rows.Count > 0 Then
            paid = dt.Rows(0).Item("TotalFeePaid")
            discount = dt.Rows(0).Item("Discount")

            'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
            'paid = cdbl(txtTotalFee.Text) - paid
            'txtBalance.Text = CDbl(txtTotalFee.Text) + discount - paid
            'txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
        Else
            paid = 0
            'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
            'paid = cdbl(txtTotalFee.Text) - paid

            ' txtBalance.Text = CDbl(IIf(txtTotalFee.Text = "", 0, txtTotalFee.Text)) + discount - paid
            ' txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
        End If
        paid = 0
        btnView.Focus()
    End Sub
    Sub DispGrid(ByVal a As Integer)
        dt.Clear()
        a = ddlbatch1.SelectedValue
        dt = Bl.getGrd1(a, ddlAYear.SelectedValue, HidCategory.Value)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("Label15"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("Label15"), Label).Text = ""
                End If
            Next
            Dim indamt As Integer = 0
            For Each Indsum As DataRow In dt.Rows
                indamt = indamt + Indsum.Item("Amount").ToString()
            Next
            txtTotalFee.Text = indamt
            txtTotalFee.Text = Format(CDbl(txtTotalFee.Text), "0.00")
            dt = Bl.getFeecollection(HidStudentId.Value, ddlAYear.SelectedValue)
            If dt.Rows.Count > 0 Then
                txtFeeCollected.Text = Format(dt.Rows(0).Item("Amount"), "0.00").ToString
            Else
                txtFeeCollected.Text = "0.00"
            End If

            'txtBalanceFee.Text = CDbl(txtTotalFee.Text) - CDbl(Format(dt.Rows(0).Item("total"), "0.00"))
            txtBalance.Text = ""
            txtTotalDiscount.Text = Format(dt.Rows(0).Item("Discount"), "0.00")
            'If dt.Rows(0).Item("fine").ToString = "" Then
            '    txtTotalFine.Text = "0.00"
            'Else
            txtTotalFine.Text = Format(dt.Rows(0).Item("fine"), "0.00")
            'End If
            txtBalanceFee.Text = Format((txtTotalFee.Text - txtFeeCollected.Text + txtTotalDiscount.Text), "0.00")

            GridView1.Visible = True

            LinkButton.Focus()
        Else
            GridView1.Visible = False
            lblRed1.Text = "No Records Found."
            lblE.Text = ""
            lblGreen1.Text = ""
            lblS.Text = ""
            txtTotalFee.Text = ""
            txtFeeCollected.Text = ""
            txtBalanceFee.Text = ""
            txtBalance.Text = ""
        End If

    End Sub
    Sub DispGrid1(ByVal El As FeeCollectionEl)
        dt.Clear()
        dt = Bl.getGrd2(El)
        If dt.Rows.Count > 0 Then
            GridView2.DataSource = dt
            GridView2.DataBind()
            GridView1.Visible = True
            GridView2.Visible = True
            For Each rows As GridViewRow In GridView2.Rows
                If CType(rows.FindControl("lblChequeDate"), Label).Text = "01-Jan-9100" Then
                    CType(rows.FindControl("lblChequeDate"), Label).Text = ""
                End If
            Next
        Else
            panel1.Visible = False
            GridView2.Visible = False
            lblE.Text = "No Records Found."
            lblS.Text = ""
            lblRed1.Text = ""
            lblGreen1.Text = ""
        End If

    End Sub

    Protected Sub btnADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnADD.Click
        ddlbatch1.Focus()
        Dim ab As Integer
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If (txtStudentCode.Text = "") Then
                lblS.Text = ""
                lblE.Text = "Student Code field is mandatory."
                Exit Sub
            End If
            If txtAmountPaid.Text = "" Then
                lblS.Text = ""
                lblE.Text = "New Amount Paid is mandatory."
                Exit Sub
            End If
            If ddlPaymentMethod.SelectedItem.Text = "Select" Then
                lblS.Text = ""
                lblE.Text = "Payment Method is Mandatory."
                Exit Sub
            End If
            Try

                If ddlBank.SelectedValue = "0" Then
                    El.Bankid = -1
                ElseIf ddlBank.SelectedValue = "*" Then
                    El.Bankid = -1
                Else
                    El.Bankid = ddlBank.SelectedValue
                End If
                If ddlPaymentMethod.SelectedValue = "Cash" Then
                    El.Dd = 0
                End If
                El.Amountpaid = txtAmountPaid.Text
                If txtDiscount.Text = "" Then
                    El.Discount = 0
                Else
                    El.Discount = CDbl("-" + txtDiscount.Text)
                End If
                If txtFine.Text = "" Then
                    El.Fine = "0.00"
                Else
                    El.Fine = txtFine.Text
                End If

                El.Discount = El.Discount
                If txtBalance.Text = "" Then
                    txtBalance.Text = "0.00"
                End If
                El.Dd = txtDd.Text
                El.Totalfee = txtTotalFee.Text
                El.Paymentmethodid = ddlPaymentMethod.SelectedValue
                El.Remarks = txtRemarks.Text
                El.PaymentDate = txtPaymentDate.Text
                El.SID = HidStudentId.Value
                If txtChequeDate.Text = "" Then
                    El.Chequedate = "#1/1/9100#"
                Else
                    El.Chequedate = txtChequeDate.Text
                End If
                El.SID = HidStudentId.Value
                El.Id = ViewState("id")
                El.SemId = ddlAYear.SelectedValue
                'If txtDiscount.Text <> "" And txtDiscount.Text <> "0.00" And txtFine.Text <> "" And txtFine.Text <> "0.00" Then
                '    lblE.Text = "Please  Enter Either Discount Allowed or Fine."
                '    lblS.Text = ""
                '    Exit Sub
                'End If
                If btnADD.Text = "UPDATE" Then
                    'If txtBalance.Text < 0 Then
                    '    lblE.Text = "Exceeding Total Fee."
                    '    txtAmountPaid.Focus()
                    '    lblS.Text = ""
                    'Else


                    'If CDbl(txtAmountPaid.Text) + IIf(txtFeeCollected.Text = "", "0.00", CDbl(txtFeeCollected.Text) + CDbl(txtDiscount.Text)) > CDbl(txtTotalFee.Text) Then
                    '    lblE.Text = "Exceeding Total Fee."
                    '    txtAmountPaid.Focus()
                    '    lblS.Text = ""
                    '    Exit Sub
                    'End If
                    Bl.UpdateRecord(El)
                    lblE.Text = ""
                    lblS.Text = "Data Updated Successfully."
                    El.Id = 0
                    'ddlBank.Enabled = True
                    'txtChequeDate.Enabled = True
                    'txtDd.Enabled = True
                    If ddlPaymentMethod.SelectedItem.ToString = "Cash" Then
                        txtChequeDate.Enabled = False
                        txtDd.Enabled = False
                        ddlBank.Enabled = False
                        ddlBank.SelectedValue = 0
                        lblE.Text = ""
                        ddlPaymentMethod.Focus()
                    Else
                        txtChequeDate.Enabled = True
                        txtDd.Enabled = True
                        ddlBank.Enabled = True
                        lblE.Text = ""
                        ddlPaymentMethod.Focus()
                    End If
                    GridView1.PageIndex = ViewState("PageIndex")

                    El.SemId = ddlAYear.SelectedValue 'changes done by shailesh 25-02-2013
                    El.SID = HidStudentId.Value 'changes done by shailesh 25-02-2013
                    ab = ddlbatch1.SelectedValue
                    DispGrid(ab)
                    DispGrid1(El)
                    GridView2.Visible = True
                    GridView2.Enabled = True
                    dt = Bl.TotalFeePaid(HidStudentId.Value, ddlAYear.SelectedValue)

                    If dt.Rows.Count > 0 Then

                        paid = dt.Rows(0).Item("TotalFeePaid")
                        discount = dt.Rows(0).Item("Discount")
                        txtBalance.Text = ""
                        'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
                        'paid = cdbl(txtTotalFee.Text) - paid
                        'txtBalance.Text = CDbl(txtTotalFee.Text) + discount - paid
                        ' txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                    Else
                        paid = 0

                        txtBalance.Text = ""
                        'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
                        'paid = cdbl(txtTotalFee.Text) - paid
                        'txtBalance.Text = CDbl(txtTotalFee.Text) + discount - paid
                        txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                    End If
                    paid = 0
                    btnADD.Text = "ADD"
                    btnView1.Text = "VIEW"
                    Clear()
                    'End If
                ElseIf btnADD.Text = "ADD" Then

                'If txtBalance.Text < 0 Then
                '    lblE.Text = "Exceeding Total Fee."
                '    txtAmountPaid.Focus()
                '    lblS.Text = ""
                'Else




                'If txtFine.Text = "" And txtDiscount.Text = "" Then
                '    Bl.InsertRecord(El)
                'End If
                'If txtFine.Text = "" And txtDiscount.Text <> "" Then
                '    Bl.InsertRecord(El)
                'End If
                'If txtFine.Text <> "" And txtDiscount.Text = "" Then
                '    El.Discount = txtFine.Text
                '    Bl.InsertRecord(El)
                'End If
                'If txtFine.Text <> "" And txtDiscount.Text <> "" Then
                Bl.InsertRecord(El)
                'El.Discount = txtFine.Text
                'El.Amountpaid = 0
                'Bl.InsertRecord(El)
                'End If
                lblE.Text = ""
                lblS.Text = "Data Added Successfully."
                ab = ddlbatch1.SelectedValue
                El.Id = 0
                DispGrid(ab)
                Clear()
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0

                El.SemId = ddlAYear.SelectedValue 'changes done by shailesh 25-02-2013
                El.SID = HidStudentId.Value 'changes done by shailesh 25-02-2013

                DispGrid1(El)
                GridView2.Visible = True
                dt = Bl.TotalFeePaid(HidStudentId.Value, ddlAYear.SelectedValue)
                If dt.Rows.Count > 0 Then
                    paid = dt.Rows(0).Item("TotalFeePaid")
                    discount = dt.Rows(0).Item("Discount")

                    'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
                    'paid = cdbl(txtTotalFee.Text) - paid
                    'txtBalance.Text = CDbl(txtTotalFee.Text) + discount - paid
                    'txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                Else
                    paid = 0
                    'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
                    'paid = cdbl(txtTotalFee.Text) - paid
                    txtBalance.Text = CDbl(txtTotalFee.Text) + CDbl(discount) - CDbl(paid)
                    txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                End If
                paid = 0
                End If



            Catch ex As Exception
                lblE.Text = "Enter correct data"
            End Try
        Else
            lblE.Text = "You do not belong to this branch, Cannot add/update data."
            lblS.Text = ""
        End If

    End Sub

    Protected Sub btnView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView1.Click
        lblE.Text = ""
        lblS.Text = ""
        If btnView1.Text = "BACK" Then
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid1(El)
            btnView1.Text = "VIEW"
            btnADD.Text = "ADD"
            Clear()
            ddlBank.Enabled = True
            txtChequeDate.Enabled = True
            txtDd.Enabled = True
            txtBalance.Text = ""
            dt = Bl.TotalFeePaid(HidStudentId.Value, ddlAYear.SelectedValue)
            If dt.Rows.Count > 0 Then
                paid = dt.Rows(0).Item("TotalFeePaid")
                discount = dt.Rows(0).Item("Discount")
                'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
                'paid = cdbl(IIf(txtTotalFee.Text = "", 0, txtTotalFee.Text)) - paid
                If txtTotalFee.Text = "" Then
                    txtTotalFee.Text = "0.00"
                Else
                    txtTotalFee.Text = Format(CDbl(txtTotalFee.Text), "0.00")
                End If

                If txtBalance.Text = "" Then
                    txtBalance.Text = "0.00"
                End If
                'txtBalance.Text = CDbl(txtTotalFee.Text) + discount - paid
                txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
            Else
                paid = 0
                'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
                'paid = cdbl(IIf(txtTotalFee.Text = "", 0, txtTotalFee.Text)) - paid
                'txtBalance.Text = CDbl(txtTotalFee.Text) + discount - paid
                txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
            End If
            lblS.Text = ""
            lblE.Text = ""
            GridView2.Enabled = True
        End If
        If (txtStudentCode.Text = "") Then
            lblS.Text = ""
            lblE.Text = "Student Code field is mandatory."
            Exit Sub
        End If
        If ddlAYear.SelectedValue = "0" Then
            El.SemId = 0
        Else
            El.SemId = ddlAYear.SelectedValue
        End If
        El.SID = HidStudentId.Value
        ViewState("PageIndex") = 0
        GridView1.PageIndex = 0

        DispGrid1(El)
        panel1.Visible = True
        'GridView2.Visible = True
        'GridView2.Enabled = True
        dt = Bl.TotalFeePaid(HidStudentId.Value, ddlAYear.SelectedValue)
        If dt.Rows.Count > 0 Then
            paid = dt.Rows(0).Item("TotalFeePaid")
            discount = dt.Rows(0).Item("Discount")
            'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
            'paid = cdbl(IIf(txtTotalFee.Text = "", 0, txtTotalFee.Text)) - paid
            If txtTotalFee.Text = "" Then
                txtTotalFee.Text = "0.00"
            Else
                txtTotalFee.Text = Format(CDbl(txtTotalFee.Text), "0.00")
            End If

            'txtBalance.Text = CDbl(txtTotalFee.Text) + discount - paid
            'txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
        Else
            paid = 0
            'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
            'paid = cdbl(IIf(txtTotalFee.Text = "", 0, txtTotalFee.Text)) - paid
            If txtTotalFee.Text = "" Then
                'lblE.Text = ""
                ''lblE.Text = "No Records to display."
                'lblS.Text = ""
            Else
                'txtBalance.Text = CDbl(txtTotalFee.Text) + discount - paid
                'txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
            End If

        End If
    End Sub
    Sub Clear()
        txtAmountPaid.Text = ""
        txtDiscount.Text = ""
        txtFine.Text = ""
        txtDd.Text = ""
        txtRemarks.Text = ""
        txtChequeDate.Text = ""
        txtPaymentDate.Text = Format(Date.Today, "dd-MMM-yyyy")
    End Sub
    Sub ClearM()
        txtAmountPaid2.Text = ""
        txtDiscount2.Text = ""
        txtFine2.Text = ""
        txtDd2.Text = ""
        txtRemarks2.Text = ""
        txtChequeDate2.Text = ""
        txtBalance2.Text = ""
        txtPaymentDate2.Text = Format(Date.Today, "dd-MMM-yyyy")
    End Sub

    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Dim ab As Integer
        If (Session("BranchCode") = Session("ParentBranch")) Then
            El.Id = CType(GridView2.Rows(e.RowIndex).FindControl("HidId"), HiddenField).Value
            Bl.ChangeFlag(El)

            ddlbatch1.Focus()
            El.Id = 0
            El.SID = HidStudentId.Value
            El.SemId = ddlAYear.SelectedValue
            dt.Clear()
            GridView1.PageIndex = ViewState("PageIndex")
            dt = Bl.getGrd2(El)
            GridView2.DataSource = dt
            GridView2.DataBind()

            ab = ddlbatch1.SelectedValue
            DispGrid(ab)
            dt = Bl.TotalFeePaid(HidStudentId.Value, ddlAYear.SelectedValue)
            If dt.Rows.Count > 0 Then
                paid = dt.Rows(0).Item("TotalFeePaid")
                discount = dt.Rows(0).Item("Discount")

                'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
                'paid = cdbl(txtTotalFee.Text) - paid
                txtBalance.Text = CDbl(txtTotalFee.Text) + CDbl(discount) - CDbl(paid)
                txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
            Else
                paid = 0
                'paid = (paid + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0))))
                'paid = cdbl(txtTotalFee.Text) - paid
                txtBalance.Text = CDbl(txtTotalFee.Text) + CDbl(discount) - CDbl(paid)
                txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
            End If
            txtBalance.Text = "0.00"
            paid = 0
            lblE.Text = ""
            lblS.Text = "Data deleted Successfully."
        Else
            lblE.Text = "You do not belong to this branch, Cannot delete data."
            lblS.Text = ""
        End If
    End Sub

    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        lblE.Text = ""
        lblS.Text = ""
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Try
            'dt.Clear()
            'If ddlSemester.SelectedValue = 0 Then
            '    lblE.Text = ""
            '    Exit Sub
            'Else
            '    El.SemId = ddlSemester.SelectedValue
            'End If
            Dim x As Integer
            x = CType(GridView2.Rows(e.NewEditIndex).FindControl("HidB"), HiddenField).Value
            If x = -1 Then
                ddlBank.SelectedValue = 0
            Else
                ddlBank.SelectedValue = CType(GridView2.Rows(e.NewEditIndex).FindControl("HidB"), HiddenField).Value
            End If
            ddlPaymentMethod.SelectedValue = CType(GridView2.Rows(e.NewEditIndex).FindControl("HidP"), HiddenField).Value
            If CType(GridView2.Rows(e.NewEditIndex).FindControl("Label133"), Label).Text < 0 Then
                txtDiscount.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("Label133"), Label).Text
            Else
                txtFine.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("Label133"), Label).Text
            End If
            txtRemarks.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
            txtAmountPaid.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("Label134"), Label).Text
            ViewState("CurrentAmt") = CType(GridView2.Rows(e.NewEditIndex).FindControl("Label134"), Label).Text
            dt.Clear()
            dt = Bl.TotalFeePaid(HidStudentId.Value, ddlAYear.SelectedValue)
            If dt.Rows.Count > 0 Then
                paid = dt.Rows(0).Item("TotalFeePaid")
                ViewState("Paid") = paid
                'paid = cdbl(txtTotalFee.Text) + paid
                'txtBalance.Text = paid
                ' txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
            Else
                paid = 0
                'paid = cdbl(txtTotalFee.Text) + paid
                'txtBalance.Text = paid
                'txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
            End If
            paid = 0
            txtDd.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("Label137"), Label).Text
            txtPaymentDate.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("Label138"), Label).Text
            ViewState("id") = CType(GridView2.Rows(e.NewEditIndex).FindControl("HidId"), HiddenField).Value
            If CType(GridView2.Rows(e.NewEditIndex).FindControl("lblChequeDate"), Label).Text = "01-Jan-9100" Then
                txtChequeDate.Text = ""
            Else
                txtChequeDate.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblChequeDate"), Label).Text
            End If

            If txtChequeDate.Text = "01/01/1900" Then
                txtChequeDate.Text = ""
            End If
            If ddlPaymentMethod.SelectedItem.Text = "Cash" Then
                ddlBank.Enabled = False
                txtChequeDate.Enabled = False
                txtDd.Enabled = False
            End If
            btnADD.Text = "UPDATE"
            btnView1.Text = "BACK"
            'Dim total As Double = (total + CDbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0)) - CDbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0)))
            ''paid = CDbl(txtTotalFee.Text) - total
            'paid = CDbl(txtBalanceFee.Text) - CDbl(txtAmountPaid.Text)
            'txtBalance.Text = paid
            txtBalance.Text = "0.00"
            El.SID = HidStudentId.Value
            El.Id = ViewState("id")
            DispGrid1(El)
            GridView2.Visible = True
            GridView2.Enabled = False
            'btnReceipt.Enabled = False
        Catch ex As Exception

        End Try
        'Else
        'lblE.Text = "You do not belong to this branch, Cannot edit data."
        'lblS.Text = ""
        'End If

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlbatch1.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If txtStudentCode.Text <> "" Then
            splitterstudentcode(txtStudentCode.Text)
        Else
            txtStudentCode.AutoPostBack = True
        End If
        If Not IsPostBack Then
            txtPaymentDate.Text = Format(Date.Today, "dd-MMM-yyyy")
            dt = feeCollectionDL.GetCurrentAcademicYear()
            Try
                ddlAYear.SelectedValue = dt.Rows(0).Item("A_Code")
                ddlAYear2.SelectedValue = dt.Rows(0).Item("A_Code")
            Catch ex As Exception

            End Try
        End If

        If txtStudentCode2.Text <> "" Then
            splitterstudentcode2(txtStudentCode2.Text)
        Else
            txtStudentCode2.AutoPostBack = True
        End If
        If Not IsPostBack Then
            txtPaymentDate2.Text = Format(Date.Today, "dd-MMM-yyyy")
        End If
        
    End Sub
    Sub splitterstudentcode(ByVal str As String)
        Dim parts As String() = str.Split(New Char() {":"})
        If parts.Length > 1 Then
            txtStudentCode.Text = parts(0).ToString
            HidStudentId.Value = parts(2).ToString
            Hidbatchid.Value = parts(3).ToString
            HidCategory.Value = parts(4).ToString
            'DDLStudent.SelectedItem.Selected = False
            ddlbatch1.SelectedValue = Hidbatchid.Value
            DDLStudent.Items.Clear()
            DDLStudent.DataSourceID = "ObjStudent"
            DDLStudent.SelectedValue = HidStudentId.Value
        Else
            txtStudentCode.AutoPostBack = True
        End If
        dt = feeCollectionDL.GetStudentFee(txtStudentCode.Text)
    End Sub
    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex

        DispGrid(0)
    End Sub
    Protected Sub GridView2_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView2.PageIndex
        DispGrid1(El)
    End Sub


    'Protected Sub txtBalance_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountPaid.TextChanged, txtDiscount.TextChanged
    '    If txtTotalFee.Text <> "" Then
    '        dt = Bl.TotalFeePaid(HidStudentId.Value, ddlSemester.SelectedValue)
    '        Dim total As New Integer
    '        If dt.Rows.Count > 0 Then
    '            paid = dt.Rows(0).Item("TotalFeePaid")
    '            discount = dt.Rows(0).Item("Discount")
    '            total = paid
    '            total = (total + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0)) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0)))
    '            paid = cdbl(txtTotalFee.Text) - total
    '            txtBalance.Text = cdbl(txtTotalFee.Text) + (discount) - total
    '            txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
    '        Else
    '            paid = 0
    '            discount = 0
    '            total = paid + discount
    '            total = (total + cdbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0)) - cdbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0)))
    '            paid = cdbl(txtTotalFee.Text) - total
    '            txtBalance.Text = cdbl(txtTotalFee.Text) + discount - paid
    '            txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
    '        End If
    '        paid = 0
    '    Else
    '        lblE.Text = "First get the total fee."
    '        lblS.Text = ""
    '    End If
    'End Sub

    Protected Sub btnReceipt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceipt.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim id As String = ""
            Dim check As String = ""
            Dim id1 As String = ""
            lblS.Text = ""
            lblE.Text = ""
            Dim count As New Integer
            For Each grid As GridViewRow In GridView2.Rows
                If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("HidId"), HiddenField).Value.ToString
                    id = check + "," + id
                    count = count + 1
                Else
                    lblS.Text = ""
                    lblE.Text = ""
                End If
            Next
            Try
                id = Left(id, id.Length - 1)
                If txtStudentCode.Text <> "" Then
                    Dim qrystring As String = "rptReceiptV.aspx?" & QueryStr.Querystring() & "&Std=" & HidStudentId.Value & "&ID=" & id
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                Else
                    lblE.Text = "Enter Student Code"
                    lblS.Text = ""
                End If
            Catch ex As ArgumentException
                lblE.Text = "Select Atleast one record."
                lblS.Text = ""
            End Try
        Else
            lblE.Text = "You do not belong to this branch, Cannot generate receipt."
            lblS.Text = ""
        End If

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub DDLStudent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLStudent.SelectedIndexChanged
        dt.Clear()
        dt = feeCollectionDL.GetStudent1(DDLStudent.SelectedValue)
        Try
            txtTotalFee.Text = ""
            lblE.Text = ""
            lblS.Text = ""
            GridView2.Visible = False
            GridView1.Visible = False
            txtBatch.Text = dt.Rows(0)("Batch_No")
            txtStudentCode.Text = dt.Rows(0)("StdCode")
            txtStudentName.Text = dt.Rows(0)("StdName")
            Hidbatchid.Value = dt.Rows(0)("BatchID")
            HidStudentId.Value = dt.Rows(0)("StdId")
            HidCategory.Value = dt.Rows(0)("categoryid")
            DDLStudent.Focus()
        Catch ex As Exception
            lblS.Text = ""
        End Try
    End Sub

    Protected Sub ddlbatch1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch1.SelectedIndexChanged
        Session("Batch") = ddlbatch1.SelectedValue
        Clear()
        Hidbatchid.Value = 0
        HidCategory.Value = 0
        HidStudentId.Value = 0
        txtStudentCode.Text = ""
        txtStudentName.Text = ""
        txtBatch.Text = ""
        txtTotalFee.Text = ""
        txtFeeCollected.Text = ""
        txtBalanceFee.Text = ""
        lblE.Text = ""
        lblS.Text = ""
        GridView2.Visible = False
        GridView1.Visible = False
    End Sub

    'Protected Sub ddlSemester_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.PreRender
    '    If ddlSemester.Items.Count > 0 Then
    '        If ddlSemester.Items(0).Text <> "Select" Then
    '            ddlSemester.Items.Insert(0, "Select")
    '        End If
    '    Else
    '        ddlSemester.Items.Insert(0, "Select")
    '    End If
    'End Sub
    Protected Sub ddlAYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAYear.SelectedIndexChanged
        txtTotalFee.Text = ""
        lblE.Text = ""
        lblS.Text = ""
        GridView2.Visible = False
        GridView1.Visible = False

    End Sub

    Protected Sub txtAmountPaid_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountPaid.TextChanged
        lblE.Text = ""
        lblGreen.Text = ""
        lblRed.Text = ""
        lblS.Text = ""
        Try
            If btnADD.Text <> "UPDATE" Then
                If txtTotalFee.Text <> "" Then
                    dt = Bl.TotalFeePaid(HidStudentId.Value, ddlAYear.SelectedValue)
                    Dim total, txtAmount As New Integer
                    If dt.Rows.Count > 0 Then
                        If txtAmountPaid.Text <> "" Then
                            If txtAmountPaid.Text = "." Then
                                txtAmount = 0
                            Else
                                txtAmount = txtAmountPaid.Text
                            End If
                        Else
                            txtAmount = 0
                        End If
                        paid = dt.Rows(0).Item("TotalFeePaid")
                        discount = dt.Rows(0).Item("Discount")
                        total1 = paid - discount
                        total = (total1 + txtAmount)
                        paid = CDbl(txtTotalFee.Text) - total
                        'txtBalance.Text = CDbl(txtTotalFee.Text) - total
                        If txtAmountPaid.Text = "" Then
                            txtAmountPaid.Text = "0.00"
                        End If
                        If txtDiscount.Text = "" Then
                            txtDiscount.Text = "0.00"
                        End If
                        If txtFine.Text = "" Then
                            txtFine.Text = "0.00"
                        End If
                        ' txtBalance.Text = ((txtTotalFee.Text - (ViewState("Paid") - ViewState("CurrentAmt"))) - txtAmountPaid.Text) + txtDiscount.Text
                        txtBalance.Text = CDbl(txtBalanceFee.Text) - CDbl(txtAmountPaid.Text) - CDbl(El.Discount) + IIf(txtFine.Text <> "", CDbl(txtFine.Text), "0.00")

                        txtBalance.Text = Format(CDbl(IIf(txtBalance.Text = "", 0, txtBalance.Text)), "0.00")
                        ddlBank.Focus()
                        If txtAmountPaid.Text = "0.00" Then
                            txtAmountPaid.Text = ""
                        End If
                        If txtDiscount.Text = "0.00" Then
                            txtDiscount.Text = ""
                        End If
                        If txtFine.Text = "0.00" Or txtFine.Text = "0" Then
                            txtFine.Text = ""
                        End If
                        'txtBalance.Text = CDbl(txtBalanceFee.Text) - CDbl(IIf(txtAmountPaid.Text = ".", 0, txtAmountPaid.Text))
                        'txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                        'ddlBank.Focus()


                        'If txtBalance.Text < 0 Then
                        '    lblE.Text = "Exceeding Total Fee."
                        '    lblS.Text = ""
                        'End If
                    Else
                        paid = 0
                        discount = 0
                        total = paid + discount
                        total = (total + CDbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0)) - CDbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0)))
                        'paid = CDbl(txtTotalFee.Text) - total
                        paid = CDbl(IIf(txtBalanceFee.Text <> "", txtBalanceFee.Text, 0)) - CDbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0))
                        txtBalance.Text = paid
                        txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                        ddlBank.Focus()
                        'If txtBalance.Text < 0 Then
                        '    lblE.Text = "Exceeding Total Fee."
                        '    ddlbatch1.Focus()
                        '    lblS.Text = ""
                        'End If
                    End If
                    paid = 0
                Else
                    lblE.Text = "First get the total fee."
                    lblS.Text = ""
                End If
            Else
                If txtAmountPaid.Text = "" Then
                    txtAmountPaid.Text = "0.00"
                End If
                If txtDiscount.Text = "" Then
                    txtDiscount.Text = "0.00"
                End If
                If txtFine.Text = "" Then
                    txtFine.Text = "0.00"
                End If
                ' txtBalance.Text = ((txtTotalFee.Text - (ViewState("Paid") - ViewState("CurrentAmt"))) - txtAmountPaid.Text) + txtDiscount.Text
                'txtBalance.Text = txtBalance.Text = CDbl(txtBalanceFee.Text) - CDbl(txtAmountPaid.Text) - CDbl(El.Discount) + IIf(txtFine.Text <> "", CDbl(txtFine.Text), "0.00")

                txtBalance.Text = Format(CDbl(IIf(txtBalance.Text = "", 0, txtBalance.Text)), "0.00")
                ddlBank.Focus()
                If txtAmountPaid.Text = "0.00" Then
                    txtAmountPaid.Text = ""
                End If
                If txtDiscount.Text = "0.00" Then
                    txtDiscount.Text = ""
                End If
                If txtFine.Text = "0.00" Then
                    txtFine.Text = ""
                End If
                'If txtBalance.Text < 0 Then
                '    lblE.Text = "Exceeding Total Fee."
                '    ddlbatch1.Focus()
                '    lblS.Text = ""
                'End If
            End If

        Catch ex As Exception
            lblE.Text = "Enter Correct Data."
            lblS.Text = ""
        End Try
    End Sub
    Protected Sub txtDiscount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscount.TextChanged
        Try
            lblE.Text = ""
            lblGreen.Text = ""
            lblRed.Text = ""
            lblS.Text = ""
            If btnADD.Text <> "UPDATE" Then
                If txtTotalFee.Text <> "" Then
                    dt = Bl.TotalFeePaid(HidStudentId.Value, ddlAYear.SelectedValue)
                    Dim total, txtAmount As New Integer
                    If dt.Rows.Count > 0 Then
                        If txtAmountPaid.Text <> "" Then
                            txtAmount = txtAmountPaid.Text
                        Else
                            txtAmount = "0.00"
                        End If
                        If txtDiscount.Text = "" Then
                            El.Discount = "0.00"
                        End If
                        If El.Discount > 0 Then
                            If txtAmountPaid.Text <> "" Then
                                txtAmount = txtAmountPaid.Text
                            Else
                                txtAmount = "0.00"
                            End If
                            If txtDiscount.Text = "" Then
                                El.Discount = 0
                            Else
                                El.Discount = CDbl("-" + txtDiscount.Text)
                            End If
                            paid = dt.Rows(0).Item("TotalFeePaid")
                            discount = dt.Rows(0).Item("Discount")
                            total1 = paid - discount
                            total = (total1 + txtAmount)
                            paid = CDbl(txtTotalFee.Text) - total
                            'txtBalance.Text = CDbl(txtTotalFee.Text) - total
                            If txtAmountPaid.Text = "" Then
                                txtAmountPaid.Text = 0.0
                            End If
                            If txtDiscount.Text = "" Then
                                El.Discount = 0.0
                            End If
                            If txtBalanceFee.Text = "" Then
                                txtBalanceFee.Text = 0.0
                            End If
                            If txtFine.Text = "" Then
                                El.Fine = "0.00"
                            Else
                                El.Fine = txtFine.Text

                            End If
                            txtBalance.Text = CDbl(txtBalanceFee.Text) - CDbl(txtAmountPaid.Text) - CDbl(El.Discount) + El.Fine
                            'IIf(txtFine.Text <> "", CDbl(txtFine.Text), "0.00")

                            txtBalance.Text = Format(CDbl(IIf(txtBalance.Text = "", 0, txtBalance.Text)), "0.00")

                            If txtAmountPaid.Text = "0.00" Then
                                txtAmountPaid.Text = ""
                            End If
                            If txtDiscount.Text = "0.00" Then
                                txtDiscount.Text = ""
                            End If
                            If txtFine.Text = "0.00" Or txtFine.Text = "0" Then
                                txtFine.Text = ""
                            End If
                            ddlPaymentMethod.Focus()
                            If txtBalance.Text < 0 Then
                                lblE.Text = "Exceeding Total Fee."
                                txtAmountPaid.Focus()
                                lblS.Text = ""
                            End If
                        Else
                            paid = dt.Rows(0).Item("TotalFeePaid")
                            discount = dt.Rows(0).Item("Discount")
                            discount = (discount) + (CDbl(El.Discount))
                            total1 = paid - discount
                            total = (total1 + txtAmount)
                            paid = CDbl(txtTotalFee.Text) - total
                            If txtAmountPaid.Text = "" Then
                                txtAmountPaid.Text = 0.0
                            Else
                                El.Amountpaid = txtAmountPaid.Text
                            End If
                            If txtDiscount.Text = "" Then
                                El.Discount = 0.0
                            Else
                                El.Discount = txtDiscount.Text
                            End If
                            If txtBalanceFee.Text = "" Then
                                txtBalanceFee.Text = 0.0
                            End If
                            If txtFine.Text = "" Then
                                El.Fine = "0.00"
                            Else
                                El.Fine = txtFine.Text
                            End If
                            ' txtBalance.Text = CDbl(txtTotalFee.Text) - total
                            txtBalance.Text = CDbl(txtBalanceFee.Text) - CDbl(El.Amountpaid) - CDbl(El.Discount) + El.Fine 'IIf(txtFine.Text <> "", CDbl(txtFine.Text), "0.00")
                            ddlPaymentMethod.Focus()
                            txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                            If txtBalance.Text < 0 Then
                                lblE.Text = "Exceeding Total Fee."
                                txtAmountPaid.Focus()
                                lblS.Text = ""
                            End If
                        End If
                    Else
                        paid = 0
                        discount = 0
                        total = paid + discount
                        total = (total + CDbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0)) + CDbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0)))
                        paid = CDbl(txtTotalFee.Text) - total
                        txtBalance.Text = paid + discount
                        '-CDbl(txtTotalFee.Text)
                        txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                    End If
                    paid = 0
                Else
                    lblE.Text = "First get the total fee."
                    lblS.Text = ""
                End If
            Else
                If txtAmountPaid.Text = "" Then
                    txtAmountPaid.Text = 0.0
                End If
                If txtDiscount.Text = "" Then
                    El.Discount = 0.0
                End If
                If txtBalanceFee.Text = "" Then
                    txtBalanceFee.Text = 0.0
                End If
                'txtBalance.Text = ((txtTotalFee.Text - (ViewState("Paid") - ViewState("CurrentAmt"))) - txtAmountPaid.Text) + txtDiscount.Text
                'txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                'If txtBalance.Text < 0 Then
                '    lblE.Text = "Exceeding Total Fee."
                '    ddlbatch1.Focus()
                '    lblS.Text = ""
                'End If
            End If
        Catch ex As Exception
            lblE.Text = "Enter Correct Data."
            lblS.Text = ""
        End Try
    End Sub

    Protected Sub ddlbatch1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch1.TextChanged
        ddlbatch1.Focus()
    End Sub
    Protected Sub ddlBank_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBank.TextChanged
        ddlBank.Focus()
    End Sub
    Protected Sub ddlPaymentMethod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentMethod.SelectedIndexChanged
        If ddlPaymentMethod.SelectedItem.ToString = "Cash" Then
            txtChequeDate.Enabled = False
            txtDd.Enabled = False
            ddlBank.Enabled = False
            ddlBank.SelectedValue = 0
            lblE.Text = ""
            ddlPaymentMethod.Focus()
        Else
            txtChequeDate.Enabled = True
            txtDd.Enabled = True
            ddlBank.Enabled = True
            lblE.Text = ""
            ddlPaymentMethod.Focus()
        End If
    End Sub

    Protected Sub ddlPaymentMethod_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentMethod.TextChanged
        ddlPaymentMethod.Focus()

    End Sub
    Protected Sub ddlAYear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAYear.TextChanged
        ddlAYear.Focus()
    End Sub

    Protected Sub DDLStudent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLStudent.TextChanged
        DDLStudent.Focus()
    End Sub

    Protected Sub txtStudentCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStudentCode.TextChanged
        GridView1.Visible = False
        txtTotalFee.Visible = False
        lblTotalFee.Visible = False
        GridView2.Visible = False
        txtStudentCode.Focus()
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

    Protected Sub GridView2_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView2.Sorting
        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        El.SID = HidStudentId.Value
        El.SemId = ddlAYear.SelectedValue

        dt = Bl.getGrd2(El)
        Dim sortedView As New DataView(dt)
        panel1.Visible = True
        GridView2.Visible = True
        GridView2.Enabled = True
        dt = Bl.TotalFeePaid(HidStudentId.Value, ddlAYear.SelectedValue)
        If dt.Rows.Count > 0 Then
            paid = dt.Rows(0).Item("TotalFeePaid")
            discount = dt.Rows(0).Item("Discount")

            If txtTotalFee.Text = "" Then
                txtTotalFee.Text = "0.00"
            Else
                txtTotalFee.Text = Format(CDbl(txtTotalFee.Text), "0.00")
            End If

        Else
            paid = 0

            If txtTotalFee.Text = "" Then
                lblE.Text = ""

                lblS.Text = ""
            Else

            End If

        End If

        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView2.DataSource = sortedView
        GridView2.DataBind()
    End Sub

    Protected Sub ddlStdName2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStdName2.SelectedIndexChanged
        dt.Clear()
        dt = feeCollectionDL.GetStudent1(ddlStdName2.SelectedValue)
        Try
            'txtTotalFee2.Text = ""
            lblRed.Text = ""
            lblGreen.Text = ""
            GridFeecollection.Visible = False

            txtBatch2.Text = dt.Rows(0)("Batch_No")
            txtStudentCode2.Text = dt.Rows(0)("StdCode")
            txtStudentName2.Text = dt.Rows(0)("StdName")
            Hidbatchid2.Value = dt.Rows(0)("BatchID")
            HidStudentId2.Value = dt.Rows(0)("StdId")
            HidCategory2.Value = dt.Rows(0)("categoryid")
            ddlStdName2.Focus()
        Catch ex As Exception
            lblS.Text = ""
        End Try
    End Sub


    Sub DispGrid2(ByVal El As FeeCollectionEl)
        dt.Clear()
        dt = Bl.getAdhocFeecollection(El)
        If dt.Rows.Count > 0 Then
            GridFeecollection.DataSource = dt
            GridFeecollection.DataBind()
            GridFeecollection.Visible = True
            GridFeecollection.Visible = True
            For Each rows As GridViewRow In GridFeecollection.Rows
                If CType(rows.FindControl("lblGVChequeDate"), Label).Text = "01-Jan-9100" Then
                    CType(rows.FindControl("lblGVChequeDate"), Label).Text = ""
                End If
            Next

        Else
            ' panel2.Visible = False
            GridFeecollection.Visible = False
            lblRed.Text = "No Records Found."
            lblGreen.Text = ""
            lblRed1.Text = ""
            lblGreen1.Text = ""

        End If

    End Sub

    Protected Sub btnView2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView2.Click
        lblRed.Text = ""
        lblGreen.Text = ""
        If btnView2.Text = "BACK" Then
            GridFeecollection.PageIndex = ViewState("PageIndex")
            El.SID = HidStudentId2.Value
            El.SemId = ddlAYear2.SelectedValue
            DispGrid2(El)
            btnView2.Text = "VIEW"
            btnAdd2.Text = "ADD"
            ClearM()
            ddlBank2.Enabled = True
            txtChequeDate2.Enabled = True
            txtDd2.Enabled = True

            lblRed.Text = ""
            lblGreen.Text = ""
            GridFeecollection.Visible = True
            GridFeecollection.Enabled = True
        Else
            If ddlStdName2.SelectedValue = 0 Then
                lblGreen.Text = ""
                lblRed.Text = "Student Name field is mandatory."
                Exit Sub
            End If
            If (txtStudentCode2.Text = "") Then
                lblGreen.Text = ""
                lblRed.Text = "Student Code field is mandatory."
                Exit Sub
            End If
            If ddlAYear2.SelectedValue = "0" Then
                El.SemId = 0
                'lblRed.Text = "Semester field is mandatory."
                'lblGreen.Text = ""
                'Exit Sub
            Else
                El.SemId = ddlAYear2.SelectedValue
            End If
            El.SID = HidStudentId2.Value
            ViewState("PageIndex") = 0
            GridFeecollection.PageIndex = 0
            'btnReceipt.Enabled = True
            DispGrid2(El)

            panel2.Visible = True
        End If
    End Sub




    Protected Sub GridFeecollection_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridFeecollection.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            El.Id = CType(GridFeecollection.Rows(e.RowIndex).FindControl("HidGVId"), HiddenField).Value
            Bl.ChangeFlag(El)

            ddlBatch2.Focus()
            El.Id = 0
            El.SID = HidStudentId2.Value
            El.SemId = ddlAYear2.SelectedValue
            dt.Clear()
            GridFeecollection.PageIndex = ViewState("PageIndex")
            dt = Bl.getAdhocFeecollection(El)
            GridFeecollection.DataSource = dt
            GridFeecollection.DataBind()
            lblRed.Text = ""
            lblGreen.Text = "Data deleted Successfully."
            txtBalance.Text = ""

        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub GridFeecollection_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridFeecollection.RowEditing
        lblRed.Text = ""
        lblGreen.Text = ""
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Try
            'dt.Clear()
            'If ddlAYear2.SelectedValue = 0 Then
            '    lblRed.Text = ""
            '    Exit Sub
            'Else
            '    El.SemId = ddlAYear2.SelectedValue
            'End If
            Dim x As Integer
            x = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVBankId"), HiddenField).Value
            If x = -1 Then
                ddlBank2.SelectedValue = 0
            Else
                ddlBank2.SelectedValue = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVBankId"), HiddenField).Value
            End If
            ddlPaymentMethod2.SelectedValue = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVPaymentMethodId"), HiddenField).Value
            ' txtDiscount2.Text = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVDiscount"), Label).Text
            If CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVDiscount"), Label).Text < 0 Then
                txtDiscount2.Text = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVDiscount"), Label).Text
            Else
                txtFine2.Text = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVDiscount"), Label).Text
            End If
            txtRemarks2.Text = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVRemarks"), Label).Text
            txtAmountPaid2.Text = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVAmountPaid"), Label).Text
            ViewState("CurrentAmt") = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVAmountPaid"), Label).Text

            txtDd2.Text = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVChequeNo"), Label).Text
            txtPaymentDate2.Text = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVFee_Date"), Label).Text
            ViewState("id") = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("HidGVId"), HiddenField).Value
            If CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVChequeDate"), Label).Text = "01-Jan-9100" Then
                txtChequeDate2.Text = ""
            Else
                txtChequeDate2.Text = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVChequeDate"), Label).Text
            End If
            ddlfee_head.SelectedValue = CType(GridFeecollection.Rows(e.NewEditIndex).FindControl("lblGVFeeheadId"), Label).Text
            If txtAmountPaid2.Text = "" Then
                txtAmountPaid2.Text = "0.00"
            End If
            If txtDiscount2.Text = "" Then
                txtDiscount2.Text = "0.00"
            End If
            If txtFine2.Text = "" Then
                txtFine2.Text = "0.00"
            End If
            txtBalance2.Text = CDbl(txtAmountPaid2.Text) + CDbl(txtDiscount2.Text) - CDbl(txtFine2.Text)
            If ddlPaymentMethod2.SelectedItem.Text = "Cash" Then
                ddlBank2.Enabled = False
                txtChequeDate2.Enabled = False
                txtDd2.Enabled = False
            End If
            btnAdd2.Text = "UPDATE"
            btnView2.Text = "BACK"
            El.SID = HidStudentId2.Value
            El.Id = ViewState("id")
            DispGrid2(El)
            GridFeecollection.Visible = True
            GridFeecollection.Enabled = False
        Catch ex As Exception

        End Try
        'Else
        'lblE.Text = "You do not belong to this branch, Cannot edit data."
        'lblS.Text = ""
        'End If
    End Sub

    Protected Sub ddlBatch2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch2.SelectedIndexChanged
        Session("Batch") = ddlBatch2.SelectedValue
        Clear()
        Hidbatchid2.Value = 0
        HidCategory2.Value = 0
        HidStudentId2.Value = 0
        txtStudentCode2.Text = ""
        txtStudentName2.Text = ""
        txtBatch2.Text = ""

        lblRed.Text = ""
        lblGreen.Text = ""
        GridFeecollection.Visible = False
    End Sub

    Protected Sub txtStudentCode2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStudentCode2.TextChanged
        GridFeecollection.Visible = False
        txtStudentCode2.Focus()
        GridFeecollection.Visible = False
    End Sub

    'Protected Sub ddlAYear2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAYear2.PreRender
    '    If ddlAYear2.Items.Count > 0 Then
    '        If ddlAYear2.Items(0).Text <> "Select" Then
    '            ddlAYear2.Items.Insert(0, "Select")
    '        End If
    '    Else
    '        ddlAYear2.Items.Insert(0, "Select")
    '    End If
    'End Sub

    Protected Sub ddlAYear2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAYear2.SelectedIndexChanged
        lblRed.Text = ""
        lblGreen.Text = ""
        GridFeecollection.Visible = False
        GridFeecollection.Visible = False
    End Sub

    Protected Sub ddlAYear2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAYear2.TextChanged
        ddlAYear2.Focus()
    End Sub

    Protected Sub ddlStdName2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStdName2.TextChanged
        ddlStdName2.Focus()
    End Sub

    Protected Sub ddlPaymentMethod2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentMethod2.SelectedIndexChanged
        If ddlPaymentMethod2.SelectedItem.ToString = "Cash" Then
            txtChequeDate2.Enabled = False
            txtDd2.Enabled = False
            ddlBank2.Enabled = False
            ddlBank2.SelectedValue = 0
            lblRed.Text = ""
        Else
            txtChequeDate2.Enabled = True
            txtDd2.Enabled = True
            ddlBank2.Enabled = True
            lblRed.Text = ""
        End If
    End Sub

    Protected Sub ddlPaymentMethod2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentMethod2.TextChanged
        ddlPaymentMethod2.Focus()
    End Sub

    Protected Sub btnAdd2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd2.Click
        ddlBatch2.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If (txtStudentCode2.Text = "") Then
                lblGreen.Text = ""
                lblRed.Text = "Student Code field is mandatory."
                Exit Sub
            End If
            If txtAmountPaid2.Text = "" Then
                lblGreen.Text = ""
                lblRed.Text = "New Amount Paid is mandatory."
                Exit Sub
            End If
            If ddlPaymentMethod2.SelectedItem.Text = "Select" Then
                lblGreen.Text = ""
                lblRed.Text = "Payment Method is Mandatory."
                Exit Sub
            End If
            Try
                If ddlBank2.SelectedValue = "0" Then
                    El.Bankid = -1
                ElseIf ddlBank2.SelectedValue = "*" Then
                    El.Bankid = -1
                Else
                    El.Bankid = ddlBank2.SelectedValue
                End If
                If ddlPaymentMethod2.SelectedValue = "Cash" Then
                    El.Dd = 0
                End If
                El.Amountpaid = txtAmountPaid2.Text

                If txtDiscount2.Text = "" Then
                    El.Discount = 0
                Else
                    El.Discount = CDbl("-" + txtDiscount2.Text)
                End If
                If txtFine2.Text = "" Then
                    El.Fine = 0
                Else
                    El.Fine = txtFine2.Text
                End If
                El.Discount = El.Discount + El.Fine

                El.Dd = txtDd2.Text
                ' El.Totalfee = txtTotalFee2.Text
                El.Paymentmethodid = ddlPaymentMethod2.SelectedValue
                El.Remarks = txtRemarks2.Text
                El.PaymentDate = txtPaymentDate2.Text
                El.SID = HidStudentId2.Value
                If txtChequeDate2.Text = "" Then
                    El.Chequedate = "#1/1/9100#"
                Else
                    El.Chequedate = txtChequeDate2.Text
                End If
                El.SID = HidStudentId2.Value
                El.Id = 0
                El.SemId = ddlAYear2.SelectedValue
                El.Fee = ddlfee_head.SelectedValue
                If txtDiscount2.Text <> "" And txtDiscount2.Text <> "0.00" And txtFine2.Text <> "" And txtFine2.Text <> "0.00" Then
                    lblRed.Text = "Please Enter Either Discount Allowed or Fine."
                    lblGreen.Text = ""
                    Exit Sub
                End If
                If btnAdd2.Text = "UPDATE" Then
                    El.Id = ViewState("id")
                    Bl.Update(El)
                    lblRed.Text = ""
                    lblGreen.Text = "Data Updated Successfully."
                    El.Id = 0
                    ddlBank2.Enabled = True
                    txtChequeDate2.Enabled = True
                    txtDd2.Enabled = True
                    GridFeecollection.PageIndex = ViewState("PageIndex")
                    'btnReceipt.Enabled = True

                    DispGrid2(El)
                    GridFeecollection.Visible = True
                    GridFeecollection.Enabled = True

                    btnAdd2.Text = "ADD"
                    btnView2.Text = "VIEW"
                    ClearM()

                ElseIf btnAdd2.Text = "ADD" Then

                    Bl.insert(El)
                    lblRed.Text = ""
                    lblGreen.Text = "Data Added Successfully."


                    ViewState("PageIndex") = 0
                    GridFeecollection.PageIndex = 0

                    DispGrid2(El)
                    GridFeecollection.Visible = True
                    paid = 0
                    ClearM()
                End If
            Catch ex As Exception
                lblRed.Text = "Enter correct data."
                lblGreen.Text = ""
            End Try
        Else
            lblRed.Text = "You do not belong to this branch, Cannot add/update data."
            lblGreen.Text = ""
        End If

    End Sub

    Protected Sub btnReceipt2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReceipt2.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblRed.Text = ""
            lblGreen.Text = ""
            Dim id As String = ""
            Dim check As String = ""
            Dim id1 As String = ""
            Dim count As New Integer
            For Each grid As GridViewRow In GridFeecollection.Rows
                If CType(grid.FindControl("CheckBx"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("HidGVId"), HiddenField).Value.ToString
                    id = check + "," + id
                    count = count + 1
                Else
                    lblRed.Text = ""
                    lblGreen.Text = ""
                End If
            Next
            Try
                id = Left(id, id.Length - 1)
                If txtStudentCode2.Text <> "" Then
                    Dim qrystring As String = "RptAdhocFeeCollectionV.aspx?" & QueryStr.Querystring() & "&Std=" & HidStudentId2.Value & "&ID=" & id
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                Else
                    lblRed.Text = "Enter Student Code."
                    lblGreen.Text = ""
                End If
            Catch ex As ArgumentException
                lblRed.Text = "Select Atleast one record."
                lblGreen.Text = ""
            End Try
        Else
            lblRed.Text = "You do not belong to this branch, Cannot Print Receipt."
            lblGreen.Text = ""
        End If

    End Sub

    Protected Sub txtAmountPaid2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmountPaid2.TextChanged

        Try
            If txtAmountPaid2.Text = "" Then
                txtAmountPaid2.Text = "0.00"
            End If
            If txtDiscount2.Text = "" Then
                txtDiscount2.Text = "0.00"
            End If
            If txtFine2.Text = "" Then
                txtFine2.Text = "0.00"
            End If
            ddlBank2.Focus()
            txtBalance2.Text = CDbl(txtAmountPaid2.Text) - CDbl(txtDiscount2.Text) + CDbl(txtFine2.Text)
        Catch ex As Exception
            lblRed.Text = "Enter Correct Data."
            lblGreen.Text = ""
            txtAmountPaid2.Focus()
        End Try
    End Sub

    Protected Sub txtDiscount2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiscount2.TextChanged
        If txtAmountPaid2.Text = "" Then
            txtAmountPaid2.Text = "0.00"
        End If
        If txtDiscount2.Text = "" Then
            txtDiscount2.Text = "0.00"
        End If
        If txtFine2.Text = "" Then
            txtFine2.Text = "0.00"
        End If
        ddlPaymentMethod2.Focus()
        'txtBalance2.Text = txtAmountPaid2.Text + txtDiscount2.Text
        txtBalance2.Text = CDbl(txtAmountPaid2.Text) - CDbl(txtDiscount2.Text) + CDbl(txtFine2.Text)
    End Sub
    Sub splitterstudentcode2(ByVal str As String)
        Dim parts As String() = str.Split(New Char() {":"})
        If parts.Length > 1 Then
            txtStudentCode2.Text = parts(0).ToString
            HidStudentId2.Value = parts(2).ToString
            Hidbatchid2.Value = parts(3).ToString
            HidCategory2.Value = parts(4).ToString
            'DDLStudent.SelectedItem.Selected = False
            ddlBatch2.SelectedValue = Hidbatchid2.Value
            ddlStdName2.Items.Clear()
            ddlStdName2.DataSourceID = "ObjStudent2"
            ddlStdName2.SelectedValue = HidStudentId2.Value
        Else
            txtStudentCode2.AutoPostBack = True
        End If
        dt = feeCollectionDL.GetStudentFee(txtStudentCode2.Text)
    End Sub
    Protected Sub ddlBatch2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch2.TextChanged
        ddlBatch2.Focus()

    End Sub
    Protected Sub ddlBank2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBank2.SelectedIndexChanged
        ddlBank2.Focus()
    End Sub

    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim id As String = ""
        Dim check As String = ""
        Dim ab As Integer
        Dim ChkID As String
        Dim count As New Integer
        Dim dt As New DataTable
        count = 0
        For Each grid As GridViewRow In GridView2.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                check = CType(grid.FindControl("HidId"), HiddenField).Value
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
        'dt = feeCollectionDL.PostCheck(role)
        'If dt.Rows.Count > 0 Then

        If Session("SecurityCheck") = "Security Check" Then

            dt = feeCollectionDL.PostAuthorizeCheck(role)
            If dt.Rows.Count < 1 Then
                lblE.Text = "You don't have Post Permission."
                lblS.Text = ""
                'ControlsPanel.Visible = True
                'PasswordPanel.Visible = False
                'GVSubjectSubGrpMapping.Enabled = False
                'Image1.Visible = True
                'Image2.Visible = True
            Else
                check = dt.Rows(0)("Result").ToString.Trim

                'check = dt.Rows(0)("Result").ToString.Trim
                If check = "" Then
                    lblE.Text = "You don't have Post Permission."
                    lblS.Text = ""


                    'Image1.Visible = True
                    'Image2.Visible = True
                Else

                    If count = 0 Then
                        lblE.Text = "Select Atleast One Record to Post."
                        lblS.Text = ""
                    Else
                        ChkID = id
                        Bl.PostFeeCollection(ChkID)
                        lblS.Text = "Data posted successfully."
                        lblE.Text = ""
                        El.Id = 0
                        El.SID = HidStudentId.Value
                        El.SemId = ddlAYear.SelectedValue
                        dt.Clear()
                        GridView1.PageIndex = ViewState("PageIndex")
                        dt = Bl.getGrd2(El)
                        GridView2.DataSource = dt
                        GridView2.DataBind()
                        ab = ddlbatch1.SelectedValue
                        DispGrid(ab)
                    End If
                End If
            End If
        Else
            If count = 0 Then
                lblE.Text = "Select Atleast One Record to Post."
                lblS.Text = ""
            Else
                ChkID = id
                Bl.PostFeeCollection(ChkID)
                lblS.Text = "Data posted successfully."
                lblE.Text = ""
                El.Id = 0
                El.SID = HidStudentId.Value
                El.SemId = ddlAYear.SelectedValue
                dt.Clear()
                GridView1.PageIndex = ViewState("PageIndex")
                dt = Bl.getGrd2(El)
                GridView2.DataSource = dt
                GridView2.DataBind()
                ab = ddlbatch1.SelectedValue
                DispGrid(ab)
            End If
        End If



        'Else
        '    lblE.Text = "Not Authorized to Post."
        '    lblS.Text = ""
        'End If
    End Sub

    Protected Sub btnPost2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost2.Click
        Dim id As String = ""
        Dim check As String = ""
        Dim ab As Integer
        Dim ChkID As String
        Dim count As New Integer
        count = 0
        For Each grid As GridViewRow In GridFeecollection.Rows
            If CType(grid.FindControl("CheckBx"), CheckBox).Checked = True Then
                check = CType(grid.FindControl("HidGVId"), HiddenField).Value
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
        'Dim role As String
        'role = Session("UserRole")
        'dt = feeCollectionDL.PostCheck(role)
        'If dt.Rows.Count > 0 Then
        If count = 0 Then
            lblRed.Text = "Select Atleast One Record to Post."
            lblGreen.Text = ""
        Else
            ChkID = id
            Bl.PostFeeCollection(ChkID)
            lblGreen.Text = "Data posted successfully."
            lblRed.Text = ""
            El.Id = 0
            El.SID = HidStudentId2.Value
            El.SemId = ddlAYear2.SelectedValue
            dt.Clear()
            GridFeecollection.PageIndex = ViewState("PageIndex")
            ' dt = Bl.getGrd2(El)
            DispGrid2(El)
            GridFeecollection.DataSource = dt
            GridFeecollection.DataBind()
            ab = ddlbatch1.SelectedValue
        End If
        'Else
        '    lblRed.Text = "Not Authorized to Post."
        '    lblGreen.Text = ""
        'End If
    End Sub

    Protected Sub txtFine_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFine.TextChanged
        Try
            lblE.Text = ""
            lblGreen.Text = ""
            lblRed.Text = ""
            lblS.Text = ""
            If txtFine.Text = "" Then
                El.Fine = "0.00"
            End If
            If txtDiscount.Text = "" Then
                El.Discount = 0
            End If
            If btnADD.Text <> "UPDATE" Then
                If txtTotalFee.Text <> "" Then
                    dt = Bl.TotalFeePaid(HidStudentId.Value, ddlAYear.SelectedValue)
                    Dim total, txtAmount As New Integer
                    If dt.Rows.Count > 0 Then
                        If txtAmountPaid.Text <> "" Then
                            txtAmount = txtAmountPaid.Text
                        Else
                            txtAmount = 0
                        End If
                        If txtDiscount.Text = "" Then
                            txtDiscount.Text = "0.00"
                        End If
                        If txtDiscount.Text > 0 Then
                            If txtAmountPaid.Text <> "" Then
                                txtAmount = txtAmountPaid.Text
                            Else
                                txtAmount = 0
                            End If
                            If txtDiscount.Text = "" Then
                                El.Discount = 0
                            Else
                                El.Discount = CDbl("-" + txtDiscount.Text)
                            End If
                            paid = dt.Rows(0).Item("TotalFeePaid")
                            'discount = dt.Rows(0).Item("Discount")
                            total1 = paid - discount
                            total = (total1 + txtAmount)
                            paid = CDbl(txtTotalFee.Text) - total
                            'txtBalance.Text = CDbl(txtTotalFee.Text) - total
                            If txtAmountPaid.Text = "" Then
                                txtAmountPaid.Text = 0.0
                                El.Amountpaid = 0
                            Else
                                El.Amountpaid = txtAmountPaid.Text
                            End If
                            If txtDiscount.Text = "" Then
                                El.Discount = 0.0
                            Else
                                El.Discount = txtDiscount.Text
                            End If
                            If txtBalanceFee.Text = "" Then
                                txtBalanceFee.Text = 0.0
                            End If
                            If txtFine.Text = "" Then
                                El.Fine = "0.00"
                            Else
                                El.Fine = txtFine.Text
                            End If
                            txtBalance.Text = CDbl(txtBalanceFee.Text) - CDbl(txtAmountPaid.Text) - CDbl(El.Discount) + El.Fine
                            ddlPaymentMethod.Focus()
                            txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                            If txtBalance.Text < 0 Then
                                lblE.Text = "Exceeding Total Fee."
                                txtAmountPaid.Focus()
                                lblS.Text = ""
                            End If
                        Else
                            paid = dt.Rows(0).Item("TotalFeePaid")
                            discount = dt.Rows(0).Item("Discount")
                            discount = (discount) + (CDbl(txtDiscount.Text))
                            total1 = paid - discount
                            total = (total1 + txtAmount)
                            paid = CDbl(txtTotalFee.Text) - total
                            If txtAmountPaid.Text = "" Then
                                txtAmountPaid.Text = 0.0
                            End If
                            If txtDiscount.Text = "" Then
                                El.Discount = 0.0
                            End If
                            If txtBalanceFee.Text = "" Then
                                txtBalanceFee.Text = 0.0
                            End If
                            If txtFine.Text = "" Then
                                El.Fine = "0.00"
                            End If
                            ' txtBalance.Text = CDbl(txtTotalFee.Text) - total
                            txtBalance.Text = CDbl(txtBalanceFee.Text) - IIf(txtAmountPaid.Text <> "", CDbl(txtAmountPaid.Text), "0.00") - IIf(txtDiscount.Text <> "", CDbl(txtDiscount.Text), "0.00") + IIf(txtFine.Text <> "", CDbl(txtFine.Text), "0.00")
                            ddlPaymentMethod.Focus()
                            txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                            If txtBalance.Text < 0 Then
                                lblE.Text = "Exceeding Total Fee."
                                txtAmountPaid.Focus()
                                lblS.Text = ""
                            End If
                        End If
                    Else
                        paid = 0
                        discount = 0
                        total = paid + discount
                        total = (total + CDbl(IIf(txtAmountPaid.Text <> "", txtAmountPaid.Text, 0)) + CDbl(IIf(txtDiscount.Text <> "", txtDiscount.Text, 0)) - CDbl(IIf(txtFine.Text <> "", txtFine.Text, 0)))
                        paid = CDbl(txtTotalFee.Text) - total
                        txtBalance.Text = paid + discount
                        '-CDbl(txtTotalFee.Text)
                        txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                    End If
                    paid = 0
                Else
                    lblE.Text = "First get the total fee."
                    lblS.Text = ""
                End If
            Else
                If txtAmountPaid.Text = "" Then
                    txtAmountPaid.Text = 0.0
                End If
                If txtDiscount.Text = "" Then
                    El.Discount = 0.0
                End If
                If txtBalanceFee.Text = "" Then
                    txtBalanceFee.Text = 0.0
                End If
                'txtBalance.Text = ((txtTotalFee.Text - (ViewState("Paid") - ViewState("CurrentAmt"))) - txtAmountPaid.Text) + txtDiscount.Text
                'txtBalance.Text = Format(CDbl(txtBalance.Text), "0.00")
                'If txtBalance.Text < 0 Then
                '    lblE.Text = "Exceeding Total Fee."
                '    ddlbatch1.Focus()
                '    lblS.Text = ""
                'End If
            End If
        Catch ex As Exception
            lblE.Text = "Enter Correct Data."
            lblS.Text = ""
        End Try
    End Sub

    Protected Sub txtFine2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFine2.TextChanged
        If txtAmountPaid2.Text = "" Then
            txtAmountPaid.Text = "0.00"
        End If
        If txtDiscount2.Text = "" Then
            txtDiscount2.Text = "0.00"
        End If
        If txtFine2.Text = "" Then
            txtFine2.Text = "0.00"
        End If
        ddlPaymentMethod2.Focus()
        'txtBalance2.Text = txtAmountPaid2.Text + txtDiscount2.Text
        txtBalance2.Text = CDbl(txtAmountPaid2.Text) - CDbl(txtDiscount2.Text) + CDbl(txtFine2.Text)
        lblE.Text = ""
        lblS.Text = ""

    End Sub

    Protected Sub btnFeeSumrecpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFeeSumrecpt.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim id As String = ""
            Dim check As String = ""
            Dim id1 As String = ""
            lblS.Text = ""
            lblE.Text = ""
            Dim count As New Integer
            Dim Pdate As String
            Dim dt2 As New DataTable
            dt.Clear()
            a = ddlbatch1.SelectedValue
            Dim stdcode As String = txtStudentCode.Text
            'Pdate = txtPaymentDate.Text
            dt = Bl.getGrd1(a, ddlAYear.SelectedValue, HidCategory.Value)
            'If dt.Rows.Count > 0 Then
            '    GridView1.DataSource = dt
            '    GridView1.DataBind()
            '    For Each rows As GridViewRow In GridView1.Rows
            '        If CType(rows.FindControl("Label15"), Label).Text = "01-Jan-3000" Then
            '            CType(rows.FindControl("Label15"), Label).Text = ""
            '        End If
            '    Next
            Dim indamt As Integer = 0
            For Each Indsum As DataRow In dt.Rows
                indamt = indamt + Indsum.Item("Amount").ToString()
            Next
            txtTotalFee.Text = indamt
            txtTotalFee.Text = Format(CDbl(txtTotalFee.Text), "0.00")
            dt = Bl.getFeecollection(HidStudentId.Value, ddlAYear.SelectedValue)
            If dt.Rows.Count > 0 Then
                txtFeeCollected.Text = Format(dt.Rows(0).Item("Amount"), "0.00").ToString
            Else
                txtFeeCollected.Text = "0.00"
            End If

            'txtBalanceFee.Text = CDbl(txtTotalFee.Text) - CDbl(Format(dt.Rows(0).Item("total"), "0.00"))
            txtBalance.Text = ""
            txtTotalDiscount.Text = Format(dt.Rows(0).Item("Discount"), "0.00")
            'If dt.Rows(0).Item("fine").ToString = "" Then
            '    txtTotalFine.Text = "0.00"
            'Else
            txtTotalFine.Text = Format(dt.Rows(0).Item("fine"), "0.00")
            'End If
            txtBalanceFee.Text = Format((txtTotalFee.Text - txtFeeCollected.Text + txtTotalDiscount.Text), "0.00")
            Dim balance As String = txtBalanceFee.Text

            dt2 = feeCollectionDL.getsemesterFeeSummary(a, stdcode)
            Dim Sem As String = dt2.Rows(0).Item("SemName")

            For Each grid As GridViewRow In GridView2.Rows
                If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("HidId"), HiddenField).Value.ToString
                    id = check + "," + id
                    count = count + 1
                Else
                    lblS.Text = ""
                    lblE.Text = ""
                End If
            Next
            Try
                id = Left(id, id.Length - 1)
                If txtStudentCode.Text <> "" Then
                    Dim qrystring As String = "RptFeeSummaryReciept.aspx?" & QueryStr.Querystring() & "&Std=" & HidStudentId.Value & "&ID=" & id & "&balance=" & balance & "&Sem=" & Sem
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                Else
                    lblE.Text = "Enter Student Code"
                    lblS.Text = ""
                End If
            Catch ex As ArgumentException
                lblE.Text = "Select Atleast one record."
                lblS.Text = ""
            End Try
        Else
            lblE.Text = "You do not belong to this branch, Cannot generate receipt."
            lblS.Text = ""
        End If

    End Sub
End Class
