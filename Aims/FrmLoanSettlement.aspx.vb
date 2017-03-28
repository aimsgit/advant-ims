
Partial Class FrmLoanSettlement
    Inherits BasePage
    Dim EL As New LoanSettlementEL
    Dim BL As New BLOverTime
    Dim dt, dt1 As DataTable
    
    Protected Sub ddlEmployeeCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmployeeCode.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
        EL.EmpNo = ddlEmployeeCode.SelectedValue
        dt = BL.AutoGenerateNo1(EL)
        If (ddlEmployeeCode.SelectedValue = 0) Then
            txtEmpName.Text = ""
        Else
            txtEmpName.Text = dt.Rows(0).Item("Emp_Name").ToString
        End If
    End Sub

    Protected Sub ddlLoanTypeCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlLoanTypeCode.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
        Dim LoanGivendate As DateTime
        If (ddlEmployeeCode.SelectedValue = 0) Then
            msginfo.Text = "Employee code field is mandatory."
        Else
            EL.EmpNo = ddlEmployeeCode.SelectedValue
        End If
        If (ddlLoanTypeCode.SelectedValue = 0) Then
            EL.LoanTypeCode = 0
        Else
            EL.LoanTypeCode = ddlLoanTypeCode.SelectedValue

        End If

        dt1 = BL.AutoGenerateLoanDetails(EL)
        If (ddlLoanTypeCode.SelectedValue = 0) Then
            txtDescription.Text = " "
        Else
            txtDescription.Text = dt1.Rows(0).Item("LoanType").ToString
        End If
        LoanGivendate = dt1.Rows(0).Item("LoanDate").ToString
        txtLoanGivenDate.Text = Format(LoanGivendate, "dd-MMM-yyyy")
        txtLoanAmount.Text = dt1.Rows(0).Item("LoanAmt").ToString
        txtBalanceAmount.Text = dt1.Rows(0).Item("BalanceLoan").ToString
        txtPaidAmount.Text = dt1.Rows(0).Item("PaidAmount").ToString
        txtNoOfInstallments.Text = dt1.Rows(0).Item("Installment").ToString
        txtBalanceInstallment.Text = dt1.Rows(0).Item("InstallmentCollected").ToString
    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If (btnadd.Text = "ADD") Then

            EL.EmpNo = ddlEmployeeCode.SelectedValue
            EL.LoanTypeCode = ddlLoanTypeCode.SelectedValue
            EL.SType = ddlStype.SelectedItem.Text
            EL.SMethod = ddlSMethod.SelectedItem.Text
            EL.SAmount = txtAmount.Text
            EL.NoOfInstl = txtNoOfInstallment.Text
            EL.LoanSettlementDate = txtSettlementDate.Text
            BL.InsertLoanSettlement(EL)
            Binddata()
            clear()

            Binddata()
            msginfo.Text = ""
            lblmsg.Text = "Data Added Successfully."
            btndetails.Text = "VIEW"
            btnadd.Text = "ADD"
        End If
        If btnadd.Text = "UPDATE" Then
            EL.EmpNo = ddlEmployeeCode.SelectedValue
            EL.LoanTypeCode = ddlLoanTypeCode.SelectedValue
            EL.SType = ddlStype.SelectedItem.Text
            EL.SMethod = ddlSMethod.SelectedItem.Text
            EL.SAmount = txtAmount.Text
            EL.NoOfInstl = txtNoOfInstallment.Text
            EL.LoanSettlementDate = txtSettlementDate.Text
            EL.ID = ViewState("LoanId_Auto")
           
            BL.UpdateLoanSettlement(EL)
            btndetails.Text = "VIEW"
            btnadd.Text = "ADD"
            GridView1.PageIndex = ViewState("PageIndex")
            Binddata()
            clear()
            lblmsg.Text = "Data Updated Successfully."
            msginfo.Text = ""
        End If
    End Sub
    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click
   
        msginfo.Text = ""
        LinkButton.Focus()
        If btndetails.Text <> "BACK" Then
            EL.EmpNo = ddlEmployeeCode.SelectedValue
            EL.LoanTypeCode = ddlLoanTypeCode.SelectedValue
            EL.SType = ddlStype.SelectedItem.Text
            EL.SMethod = ddlSMethod.SelectedItem.Text
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            Binddata()
            GridView1.Visible = True

        Else
            lblmsg.Text = ""
            msginfo.Text = ""

            btndetails.Text = "VIEW"
            btnadd.Text = "ADD"
            clear()
            GridView1.Visible = True
            GridView1.PageIndex = ViewState("PageIndex")
            Binddata()
        End If
    End Sub
    Sub Binddata()
        LinkButton.Focus()
        Dim dt As Data.DataTable
        EL.ID = 0
        EL.EmpNo = ddlEmployeeCode.SelectedValue
        EL.LoanTypeCode = ddlLoanTypeCode.SelectedValue
        EL.SType = ddlStype.SelectedItem.Text
        EL.SMethod = ddlSMethod.SelectedItem.Text

        GridView1.Visible = False
        dt = BL.GetEmp(EL)
        If (dt.Rows.Count > 0) Then

            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
            LinkButton.Focus()
            lblmsg.Text = ""
            msginfo.Text = ""

        ElseIf dt.Rows.Count = 0 Then
            lblmsg.Text = ""
            msginfo.Text = "No Records to Display."
        End If
    End Sub

    Sub clear()
        txtAmount.Text = ""
        txtBalanceAmount.Text = ""
        txtBalanceInstallment.Text = ""
        txtDescription.Text = ""
        txtEmpName.Text = ""
        txtLoanAmount.Text = ""
        txtNoOfInstallment.Text = ""
        txtPaidAmount.Text = ""

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        If Session("Privilages").ToString.Contains("W") Then

            'If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim dt As New DataTable
            lblmsg.Text = ""
            msginfo.Text = ""
            btnadd.Text = "UPDATE"
            btndetails.Text = "BACK"
            'btn_disabled()
            ddlEmployeeCode.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Labelempid"), Label).Text
            Dim Ex As Integer
            Ex = ddlLoanTypeCode.SelectedValue
            'ddlLoanTypeCode.SelectedItem.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(2).FindControl("lblLoanTpeCode"), Label).Text
            Ex = CType(GridView1.Rows(e.NewEditIndex).Cells(2).FindControl("Label3"), Label).Text
            ddlLoanTypeCode.SelectedValue = Ex

            ddlStype.SelectedItem.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(3).FindControl("LabelLoanSType"), Label).Text
            ddlSMethod.SelectedItem.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(4).FindControl("LabelLoanSettMethod"), Label).Text
            txtSettlementDate.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(5).FindControl("Label9"), Label).Text
            txtNoOfInstallments.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(5).FindControl("lblInstallmentCollected"), Label).Text
            txtEmpName.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(5).FindControl("Label1"), Label).Text
            txtLoanAmount.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(6).FindControl("Label5"), Label).Text
            txtDescription.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(6).FindControl("lbldata"), Label).Text
            txtLoanGivenDate.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(6).FindControl("Label4"), Label).Text
            txtPaidAmount.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(6).FindControl("Label10"), Label).Text
            txtBalanceInstallment.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(6).FindControl("lblInstallmentBalance"), Label).Text
            txtNoOfInstallment.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(6).FindControl("lblInstallmentBalance"), Label).Text
            txtAmount.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(6).FindControl("lblSettlementAmount"), Label).Text
            txtBalanceInstallment.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(6).FindControl("lblInstallmentBalance"), Label).Text
            txtBalanceAmount.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(6).FindControl("Label10"), Label).Text
            txtLoanBalance.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(10).FindControl("Label10"), Label).Text
            ViewState("LoanId_Auto") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HidLoanId"), HiddenField).Value
            ViewState("EmpId") = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Labelempid"), Label).Text
         
            btnadd.Text = "UPDATE"
            EL.ID = ViewState("LoanId_Auto")
            'Prop.AmountType = RBType.SelectedValue
            Binddata()
            GridView1.Enabled = False
            'Else
            'msginfo.Text = "You do not belong to this branch, Cannot edit data."
            'lblmsg.Text = ""
            'End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub txtAmount_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.TextChanged
        Dim BalanceLoan As String
        If (ddlEmployeeCode.SelectedValue = 0) Then
            msginfo.Text = "Employee code field is mandatory."
        Else
            EL.EmpNo = ddlEmployeeCode.SelectedValue
        End If
        If (ddlLoanTypeCode.SelectedValue = 0) Then
            EL.LoanTypeCode = 0
        Else
            EL.LoanTypeCode = ddlLoanTypeCode.SelectedValue

        End If

        dt1 = BL.AutoGenerateLoanDetails(EL)

        BalanceLoan = dt1.Rows(0).Item("BalanceLoan").ToString
        If txtAmount.Text = "" Then
            txtAmount.Text = 0
        Else
            EL.SAmount = txtAmount.Text
        End If

        txtLoanBalance.Text = BalanceLoan - (EL.SAmount)
    End Sub

    Protected Sub ddlStype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStype.SelectedIndexChanged
        If (ddlEmployeeCode.SelectedValue = 0) Then
            msginfo.Text = "Employee code field is mandatory."
            Exit Sub
        Else
            EL.EmpNo = ddlEmployeeCode.SelectedValue
        End If
        If (ddlLoanTypeCode.SelectedValue = 0) Then
            msginfo.Text = "Loan Type code field is mandatory."
            Exit Sub
        Else
            EL.LoanTypeCode = ddlLoanTypeCode.SelectedValue
        End If
        dt1 = BL.AutoGenerateSType(EL)
        If (ddlStype.SelectedItem.Text = "Full") Then
            Dim NoOfBal As Integer
            NoOfBal = dt1.Rows(0).Item("BalanceInstallment").ToString
            'If dt1.Rows(0).Item("BalanceInstallment").ToString Then
            txtNoOfInstallment.Text = dt1.Rows(0).Item("BalanceInstallment").ToString
            txtAmount.Text = dt1.Rows(0).Item("BalanceLoan").ToString
            txtLoanBalance.Text = 0
        Else
            txtNoOfInstallment.Text = ""
            txtAmount.Text = ""
            txtLoanBalance.Text = ""
            'End If
            'Else
            'Exit Sub
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Binddata()
        GridView1.Visible = True
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
        EL.ID = 0
        EL.EmpNo = ddlEmployeeCode.SelectedValue
        EL.LoanTypeCode = ddlLoanTypeCode.SelectedValue
        EL.SType = ddlStype.SelectedItem.Text
        EL.SMethod = ddlSMethod.SelectedItem.Text
        dt = BL.GetEmp(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Visible = True
        LinkButton.Focus()

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

End Class





