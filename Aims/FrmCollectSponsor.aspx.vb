Imports System.IO
Imports System.Data
Imports System.Collections.Generic


Partial Class FrmCollectSponsor
    Inherits BasePage
    Dim a As Integer
    Dim BL As New BLFrmCollectSponsor
    Dim DL As New DLFrmCollectSponsor
    Dim El As New ELFrmCollectSponsor
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim TotPayable As Double
    Dim TotPaid As Double



    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If txtStudentCode.Text <> "" Then
            splitterstudentcode(txtStudentCode.Text)
            dt1 = DLFrmCollectSponsor.GetStudentCategory(HidCategory.Value)
            txtCategory.Text = dt1.Rows(0).Item("Std_CategoryName")
        Else
            txtStudentCode.AutoPostBack = True
            txtCategory.Text = ""
        End If

        If Not IsPostBack Then
            txtdate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
    Sub DispGridPaid(ByVal a As Integer)
        dt1.Clear()
        a = ddlbatch1.SelectedValue

        dt1 = BL.DisplayGridviewPaid(ddlAYear.SelectedValue, a, HidStudentId.Value, HidCategory.Value)
        If dt1.Rows.Count > 0 Then
            GVPaid.DataSource = dt1
            GVPaid.DataBind()
            GVPaid.Visible = True
            LinkButton.Focus()
        Else
            GVPaid.Visible = False
            lblGreen1.Text = ""
        End If

    End Sub

    Sub DispGridPayable(ByVal a As Integer)
        dt2.Clear()
        a = ddlbatch1.SelectedValue

        dt2 = BL.DisplayGridviewPayable(ddlAYear.SelectedValue, a, HidStudentId.Value, HidCategory.Value)
        If dt2.Rows.Count > 0 Then
            GVPayable.DataSource = dt2
            GVPayable.DataBind()
            GVPayable.Visible = True
            LinkButton.Focus()
        Else
            GVPayable.Visible = False
            lblGreen1.Text = ""
        End If

    End Sub

    Sub DispGrid()

        El.id = 0

        dt = BL.DisplayGridview(El.id, HidStudentId.Value)
        If dt.Rows.Count > 0 Then
            GVsponsor.DataSource = dt
            GVsponsor.DataBind()
            GVsponsor.Visible = True
            GVsponsor.Enabled = True

        Else
            lblG1.Text = ""
            lblR1.Text = "No record display."
            lblR2.Text = ""
            lblG2.Text = ""
            lblRed1.Text = ""
            lblGreen1.Text = ""
            GVsponsor.Visible = False
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
        dt = DLFrmCollectSponsor.GetStudentAutoComplete(txtStudentCode.Text)
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub DDLStudent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLStudent.SelectedIndexChanged
        If DDLStudent.SelectedValue = 0 Then
            txtStudentCode.Text = ""
            txtCategory.Text = ""
            panel1.Visible = "false"
            GVsponsor.Visible = "False"
        End If
        panel1.Visible = "false"
        GVsponsor.Visible = "false"
        txtTotalPaid.Text = ""
        TxtTotalPayable.Text = ""
        txtBalance.Text = ""
        txtexcess.Text = ""
        dt.Clear()
        dt = DLFrmCollectSponsor.GetStudentByDDL(DDLStudent.SelectedValue)
        Try
            'txtTotalFee.Text = ""
            lblGreen1.Text = ""
            lblRed1.Text = ""
            GVPayable.Visible = False
            GVPaid.Visible = False
            txtBatch.Text = dt.Rows(0)("Batch_No")
            txtStudentCode.Text = dt.Rows(0)("StdCode")
            txtStudentName.Text = dt.Rows(0)("StdName")
            Hidbatchid.Value = dt.Rows(0)("BatchID")
            HidStudentId.Value = dt.Rows(0)("StdId")
            HidCategory.Value = dt.Rows(0)("categoryid")
            dt1 = DLFrmCollectSponsor.GetStudentCategory(HidCategory.Value)
            txtCategory.Text = dt1.Rows(0).Item("Std_CategoryName")
            'ddlAYear.SelectedValue = dt.Rows(0)("A_Year")
            DDLStudent.Focus()
        Catch ex As Exception
            lblGreen1.Text = ""
        End Try
    End Sub

    Protected Sub ddlbatch1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch1.SelectedIndexChanged
        Session("Batch") = ddlbatch1.SelectedValue

        If ddlbatch1.SelectedValue = 0 Then
            DDLStudent.SelectedValue = 0
            txtStudentCode.Text = ""
            txtCategory.Text = ""
            panel1.Visible = "false"
        End If

        lblGreen1.Text = ""
        lblRed1.Text = ""
        Hidbatchid.Value = 0
        HidCategory.Value = 0
        HidStudentId.Value = 0
        txtStudentCode.Text = ""
        txtStudentName.Text = ""
        txtCategory.Text = ""
        txtBatch.Text = ""
        txtTotalPaid.Text = ""
        TxtTotalPayable.Text = ""
        txtBalance.Text = ""
        txtexcess.Text = ""
        lblR1.Text = ""
        lblG1.Text = ""
        lblR2.Text = ""
        lblG2.Text = ""
        GVPayable.Visible = True
        GVPaid.Visible = False
        panel1.Visible = "false"
        GVsponsor.Visible = "false"
    End Sub
    Protected Sub ddlAYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAYear.SelectedIndexChanged
        'txtTotalFee.Text = ""
        lblGreen1.Text = ""
        lblRed1.Text = ""
        GVPayable.Visible = False
        GVPaid.Visible = False

    End Sub

    Protected Sub ddlAYear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAYear.TextChanged
        ddlAYear.Focus()
    End Sub

    Protected Sub DDLStudent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLStudent.TextChanged
        DDLStudent.Focus()
    End Sub

    Protected Sub txtStudentCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStudentCode.TextChanged

        If txtStudentCode.Text = "" Then
            ddlbatch1.SelectedValue = 0
            DDLStudent.SelectedValue = 0
            lblGreen1.Text = ""
            lblRed1.Text = ""
        End If
        'GridView1.Visible = False
        'txtTotalFee.Visible = False
        'lblTotalFee.Visible = False
        'GridView2.Visible = False
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
    Sub Clear()
        'txtStudentCode.Text = ""
        txtamount.Text = ""
        txtremarks.Text = ""
        txtchequeno.Text = ""
        txtChequedate.Text = ""
        txtdate.Text = ""
        chqno.Text = ""
        chqdate.Text = ""
        txtamt.Text = ""
        txtamount.Text = ""
    End Sub

    Protected Sub Btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                lblR1.Text = ""
                lblG1.Text = ""
                lblG2.Text = ""
                lblR2.Text = ""
                lblRed1.Text = ""
                lblGreen1.Text = ""
                El.SpId = ddlsponsor.SelectedValue
                If txtamount.Text = "" Then
                    El.amount = 0
                Else
                    El.amount = txtamount.Text
                End If
                El.mode = ddlPaymentMethod.SelectedValue
                If ddlPaymentMethod.SelectedItem.Text = "Cheque" Then
                    If txtchequeno.Text = "" Then
                        lblR1.Text = "Cheque No is Mandatory."
                        lblG1.Text = ""
                        lblG2.Text = ""
                        lblR2.Text = ""
                        lblRed1.Text = ""
                        lblGreen1.Text = ""
                        Exit Sub
                    Else
                        El.chqno = txtchequeno.Text
                    End If
                    If txtChequedate.Text = "" Then
                        txtChequedate.Text = Format(Today, "dd-MMM-yyyy")
                        El.chqdate = txtChequedate.Text
                    Else
                        El.chqdate = txtChequedate.Text
                    End If
                Else
                    El.chqno = ""
                    txtChequedate.Text = "01-Jan-3000"
                    El.chqdate = txtChequedate.Text
                End If
                El.remarks = txtremarks.Text
                El.SId = DDLStudent.SelectedValue
                El.Batch = ddlbatch1.SelectedValue
                El.academic = ddlAYear.SelectedValue
                If txtdate.Text = "" Then
                    txtdate.Text = Format(Today, "dd-MMM-yyyy")
                    El.date1 = txtdate.Text
                Else
                    El.date1 = txtdate.Text
                End If
                If Btnadd.CommandName = "ADD" Then

                    El.id = 0
                    'Dim dt As New DataTable
                    'dt = BL.CheckDuplicate(El)
                    'If dt.Rows.Count > 0 Then
                    '    'lblRed.Visible = True
                    '    lblR1.Text = "Data already exists."
                    '    lblG1.Text = ""
                    '    lblG2.Text = ""
                    '    lblR2.Text = ""
                    '    lblRed1.Text = ""
                    '    lblGreen1.Text = ""
                    '    DispGrid()
                    '    Exit Sub
                    'End If

                    BL.InsertSponsor(El)
                    lblG1.Text = "Data Saved Sucessfully"
                    lblR1.Text = ""
                    lblG2.Text = ""
                    lblR2.Text = ""
                    lblRed1.Text = ""
                    lblGreen1.Text = ""
                    ViewState("PageIndex") = 0
                    GVsponsor.PageIndex = 0
                    DispGrid()
                    GetAmount()
                    Clear()
                Else

                    El.id = CInt(ViewState("id"))
                    ''Dim dt As New DataTable
                    ''dt = BL.CheckDuplicate(El)
                    ''If dt.Rows.Count > 0 Then
                    ''    'lblRed.Visible = True
                    ''    lblR1.Text = "Data already exists."
                    ''    lblG1.Text = ""
                    ''    lblG2.Text = ""
                    ''    lblR2.Text = ""
                    ''    lblRed1.Text = ""
                    ''    lblGreen1.Text = ""
                    ''    DispGrid()
                    ''    Exit Sub
                    ''End If

                    BL.UpdateSponsor(El)
                    lblG1.Text = "Data Updated Sucessfully"
                    lblR1.Text = ""
                    lblG2.Text = ""
                    lblR2.Text = ""
                    lblRed1.Text = ""
                    lblGreen1.Text = ""
                    Clear()
                    Btnadd.CommandName = "ADD"
                    btnView1.CommandName = "VIEW"
                    Btnadd.Text = "ADD"
                    btnView1.Visible = True
                    btnView1.Text = "VIEW"
                    GVsponsor.PageIndex = ViewState("PageIndex")
                    DispGrid()
                    GetAmount()

                End If

            Catch e1 As Exception
                lblR1.Text = "Enter Correct Details."
                lblG1.Text = ""
                lblG2.Text = ""
                lblR2.Text = ""
                lblRed1.Text = ""
                lblGreen1.Text = ""
            End Try
        Else
            lblR1.Text = "You do not belong to this branch, Cannot add/update data."
            lblG1.Text = ""
            lblG2.Text = ""
            lblR2.Text = ""
            lblRed1.Text = ""
            lblGreen1.Text = ""

        End If
    End Sub

    Protected Sub GVsponsor_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVsponsor.PageIndexChanging
        GVsponsor.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVsponsor.PageIndex
        DispGrid()
        GVsponsor.Visible = True
    End Sub

    'Protected Sub GVsponsor_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVsponsor.RowDeleting
    '    Dim rowsaffected As Integer
    '    If (Session("BranchCode") = Session("ParentBranch")) Then
    '        El.id = CType(GVsponsor.Rows(e.RowIndex).FindControl("lblid"), Label).Text
    '        rowsaffected = BL.DeleteSponsor(El)
    '        lblG1.Text = "Data Deleted Sucessfully."
    '        lblR1.Text = ""
    '        lblG2.Text = ""
    '        lblR2.Text = ""
    '        lblRed1.Text = ""
    '        lblGreen1.Text = ""
    '        DispGrid()
    '        dt = BL.DisplayGridview(El.id, HidStudentId.Value)
    '        GVsponsor.DataSource = dt
    '        GVsponsor.DataBind()
    '        lblR1.Text = ""
    '    End If

    'End Sub

    Protected Sub GVsponsor_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVsponsor.RowEditing
        ViewState("id") = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblid"), Label).Text
        El.id = ViewState("id")
        dt = DLFrmCollectSponsor.GetRef(El)
        'dt1 = DLFrmCollectSponsor.GetTransfer(El)
        If (dt.Rows(0).Item("Refund") = "Y" Or dt.Rows(0).Item("TransferToFee") = "Y") Then
            btnRTOStu.CommandName = "UPDATE"
            btnTTFee.CommandName = "BACK"
            btnTTFee.Visible = True
            btnRTOStu.Visible = True
            btnRTOStu.Text = "UPDATE"
            btnTTFee.Text = "BACK"
            lblG1.Text = ""
            lblR1.Text = ""
            lblR2.Text = ""
            lblG2.Text = ""
            lblRed1.Text = ""
            lblGreen1.Text = ""
            txtamt.Text = (-1) * CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblamount"), Label).Text
            DDLModeRefund.SelectedValue = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblMode"), Label).Text
            chqno.Text = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblchqno"), Label).Text
            chqdate.Text = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblchqdate"), Label).Text
            ViewState("Amount") = txtamt.Text
            dt = BL.DisplayGridview(El.id, HidStudentId.Value)
            GVsponsor.DataSource = dt
            GVsponsor.DataBind()
            
            GVsponsor.Enabled = False
            lblG1.Text = ""
            lblR1.Text = ""
            lblR2.Text = ""
            lblG2.Text = ""
            lblRed1.Text = ""
            lblGreen1.Text = ""
        Else

            Btnadd.CommandName = "UPDATE"
            btnView1.CommandName = "BACK"
            Btnadd.Text = "UPDATE"
            btnView1.Text = "BACK"
            lblG1.Text = ""
            lblR1.Text = ""
            lblR2.Text = ""
            lblG2.Text = ""
            lblRed1.Text = ""
            lblGreen1.Text = ""
            ddlsponsor.SelectedValue = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblsponsor"), Label).Text
            txtamount.Text = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblamount"), Label).Text
            ddlPaymentMethod.SelectedValue = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblMode"), Label).Text
            txtchequeno.Text = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblchqno"), Label).Text
            txtChequedate.Text = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblchqdate"), Label).Text
            txtdate.Text = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lbldate"), Label).Text
            txtremarks.Text = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblremarks"), Label).Text
            ViewState("id") = CType(GVsponsor.Rows(e.NewEditIndex).FindControl("lblid"), Label).Text
            dt = BL.DisplayGridview(El.id, HidStudentId.Value)
            GVsponsor.DataSource = dt
            GVsponsor.DataBind()
            
            GVsponsor.Enabled = False
            lblG1.Text = ""
            lblR1.Text = ""
            lblR2.Text = ""
            lblG2.Text = ""
            lblRed1.Text = ""
            lblGreen1.Text = ""
        End If
    End Sub

    Protected Sub btnView1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView1.Click
        lblG1.Text = ""
        lblR1.Text = ""
        lblR2.Text = ""
        lblG2.Text = ""
        lblRed1.Text = ""
        lblGreen1.Text = ""
        If btnView1.CommandName <> "BACK" Then
            El.id = 0
            'dt = BL.DisplayGridview(EL.id)
            DispGrid()
            GVsponsor.Visible = "true"

        Else
            Clear()
            Btnadd.CommandName = "ADD"
            btnView1.CommandName = "VIEW"

            Btnadd.Text = "ADD"
            btnView1.Visible = True
            btnView1.Text = "VIEW"
            DispGrid()
        End If
    End Sub

    Protected Sub GVPaid_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVPaid.PageIndexChanging
        GVPaid.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVPaid.PageIndex
        a = ddlbatch1.SelectedValue
        DispGridPaid(a)

    End Sub

    Protected Sub GVPayable_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVPayable.PageIndexChanging
        GVPayable.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVPayable.PageIndex
        a = ddlbatch1.SelectedValue
        DispGridPayable(a)
    End Sub

    Protected Sub GVPaid_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVPaid.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        a = ddlbatch1.SelectedValue

        dt1 = BL.DisplayGridviewPaid(ddlAYear.SelectedValue, a, HidStudentId.Value, HidCategory.Value)

        Dim sortedView As New DataView(dt1)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVPaid.DataSource = sortedView
        GVPaid.DataBind()
        GVPaid.Enabled = True
        GVPaid.Visible = True
        'LinkButton.Focus()
    End Sub

    Protected Sub GVPayable_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVPayable.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        a = ddlbatch1.SelectedValue

        dt2 = BL.DisplayGridviewPayable(ddlAYear.SelectedValue, a, HidStudentId.Value, HidCategory.Value)

        Dim sortedView As New DataView(dt2)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVPayable.DataSource = sortedView
        GVPayable.DataBind()
        GVPayable.Enabled = True
        GVPayable.Visible = True
        'LinkButton.Focus()
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess1"), Label).Text = Session("Process")
    End Sub

   
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click

        panel1.Visible = "True"
        ddlbatch1.Focus()
        lblG1.Text = ""
        lblR1.Text = ""
        lblR2.Text = ""
        lblG2.Text = ""
        lblRed1.Text = ""
        lblGreen1.Text = ""

        a = ddlbatch1.SelectedValue
        'sem = ddlSemester.SelectedValue
        ViewState("PageIndex") = 0
        GVPayable.PageIndex = 0
        GVPaid.PageIndex = 0
        DispGridPaid(a)
        DispGridPayable(a)

        dt1 = BL.DisplayGridviewPaid(ddlAYear.SelectedValue, a, HidStudentId.Value, HidCategory.Value)
        dt2 = BL.DisplayGridviewPayable(ddlAYear.SelectedValue, a, HidStudentId.Value, HidCategory.Value)

        If dt1.Rows.Count = 0 And dt2.Rows.Count = 0 Then

            lblRed1.Text = "No records to display"
            lblG1.Text = ""
            lblR1.Text = ""
            lblR2.Text = ""
            lblG2.Text = ""
            lblGreen1.Text = ""
            GVPaid.Visible = False
            GVPayable.Visible = False
            panel1.Visible = False
            Exit Sub
        Else
            lblRed1.Text = ""
            lblG1.Text = ""
            lblR1.Text = ""
            lblR2.Text = ""
            lblG2.Text = ""
            lblGreen1.Text = ""

        End If
        GetAmount()
        btnView.Focus()

    End Sub

    Sub GetAmount()
        a = ddlbatch1.SelectedValue
        dt1 = BL.DisplayGridviewPaid(ddlAYear.SelectedValue, a, HidStudentId.Value, HidCategory.Value)
        dt2 = BL.DisplayGridviewPayable(ddlAYear.SelectedValue, a, HidStudentId.Value, HidCategory.Value)

        Dim indamtPayable As Double = 0.0
        For Each TotFeePay As DataRow In dt2.Rows
            indamtPayable = indamtPayable + TotFeePay.Item("Amount")
        Next
        TotPayable = indamtPayable
        'TotPayable = Format(CDbl(TotPayable), "0.00")

        Dim indamtPaid As Double = 0.0
        For Each TotFeePay As DataRow In dt1.Rows
            indamtPaid = indamtPaid + TotFeePay.Item("Amount")
        Next
        TotPaid = indamtPaid
        'TotPaid = Format(CDbl(TotPaid), "0.00")

        Dim SpAmt As Double
        dt = BL.GetSponsorAmt(HidStudentId.Value)
        If dt.Rows.Count > 0 Then

            SpAmt = dt.Rows(0).Item("Amount")
        Else
            SpAmt = 0.0
        End If
        'SpAmt = Format(CDbl(SpAmt), "0.00")
        If (TotPaid - TotPayable + SpAmt) = 0.0 Then
            txtexcess.Text = "0.00"
        Else
            txtexcess.Text = Format((TotPaid - TotPayable + SpAmt), "###,###,###.#0")
        End If
        TxtTotalPayable.Text = Format(TotPayable, "###,###,###0.#0")
        txtTotalPaid.Text = Format(TotPaid, "###,###,###0.#0")
        If (TotPayable - TotPaid) = 0.0 Then
            txtBalance.Text = "0.00"
        Else
            txtBalance.Text = Format((TotPayable - TotPaid), "###,###,###.#0")
        End If
    End Sub
    Protected Sub ddlPaymentMethod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentMethod.SelectedIndexChanged
        If ddlPaymentMethod.SelectedItem.Text = "Cash" Then
            txtchequeno.Enabled = False
            txtChequedate.Enabled = False
        Else
            If ddlPaymentMethod.SelectedItem.Text = "Cheque" Then
                txtchequeno.Enabled = True
                txtChequedate.Enabled = True
            Else
                If ddlPaymentMethod.SelectedItem.Text = "Credit Card" Then

                    txtchequeno.Text = "Credit No"
                    txtChequedate.Text = "Credit Date"
                    txtchequeno.Enabled = True
                    txtChequedate.Enabled = True
                End If

            End If
        End If

    End Sub

    Protected Sub DDLModeRefund_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLModeRefund.SelectedIndexChanged
        If DDLModeRefund.SelectedItem.Text = "Cash" Then
            chqno.Enabled = False
            chqdate.Enabled = False
        Else
            chqno.Enabled = True
            chqdate.Enabled = True

        End If

    End Sub

    Protected Sub btnRTOStu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRTOStu.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim Excess As Double = txtexcess.Text
            'Dim RefAmt As Double
            Dim ROAmount As Double = ViewState("Amount")
            'Dim RefTot As Double
            Dim ExRes As Double
            Dim BalTot As Double
            Dim BalAmt As Double = txtBalance.Text
            If DDLModeRefund.SelectedValue = 0 Then
                lblR2.Text = "Mode Field is Mandatory."
                lblG2.Text = ""
                lblG1.Text = ""
                lblR1.Text = ""
                lblRed1.Text = ""
                lblGreen1.Text = ""
                DDLModeRefund.Focus()
                Exit Sub
            End If

            Try
                lblG1.Text = ""
                lblR1.Text = ""
                lblR2.Text = ""
                lblG2.Text = ""
                lblRed1.Text = ""
                lblGreen1.Text = ""

                El.id = 0
                GetAmount()
                If btnRTOStu.Text = "UPDATE" Then
                    El.id = CInt(ViewState("id"))
                    El.id = ViewState("id")
                    dt = DLFrmCollectSponsor.GetRef(El)
                    dt1 = DLFrmCollectSponsor.GetTransfer(El)
                    If (dt.Rows(0).Item("Refund") = "Y") Then

                        'dt = DLFrmCollectSponsor.GetRefundtot(HidStudentId.Value)
                        'If dt.Rows.Count > 0 Then

                        '    RefAmt = dt.Rows(0).Item("Amount")
                        'Else
                        '    RefAmt = 0.0
                        'End If
                        'RefAmt = Format(CDbl(RefAmt), "0.00")
                        'RefTot = RefAmt + ROAmount

                        'RefTot = (-1) * RefTot
                        ExRes = Excess + ROAmount
                        If ExRes > 0 Then
                            If ExRes < txtamt.Text Then
                                lblR2.Text = "Refund amount cannot be greater than Excess Amount."
                                Clear()
                                txtamt.Focus()
                                Exit Sub
                            End If
                        Else
                            lblR2.Text = "Refund is not possible."
                            Exit Sub
                        End If
                        El.mode = DDLModeRefund.SelectedValue
                        If DDLModeRefund.SelectedItem.Text = "Cheque" Then
                            If chqno.Text = "" Then
                                lblG2.Text = ""
                                lblR2.Text = "Cheque No is Mandatory."
                                lblRed1.Text = ""
                                lblGreen1.Text = ""
                                lblG1.Text = ""
                                lblR1.Text = ""
                                Exit Sub
                            Else
                                El.chqno = chqno.Text
                            End If
                            If chqdate.Text = "" Then
                                chqdate.Text = Format(Today, "dd-MMM-yyyy")
                                El.chqdate = chqdate.Text
                            Else
                                El.chqdate = chqdate.Text
                            End If
                        Else
                            El.chqno = ""
                            chqdate.Text = "01-Jan-3000"
                            El.chqdate = chqdate.Text
                        End If
                        El.amount = txtamt.Text
                        BL.UpdateRefund(El)
                        lblG2.Text = "Data Updated Sucessfully"
                        lblR2.Text = ""
                        lblRed1.Text = ""
                        lblGreen1.Text = ""
                        lblG1.Text = ""
                        lblR1.Text = ""

                        Clear()
                        btnRTOStu.Text = "REFUND TO STUDENT"
                        btnTTFee.Visible = True
                        btnTTFee.Text = "TRANSFER TO FEE"
                        DispGridPayable(ddlbatch1.SelectedValue)
                        DispGridPaid(ddlbatch1.SelectedValue)
                        GVsponsor.PageIndex = ViewState("PageIndex")
                        DispGrid()
                        GetAmount()

                    ElseIf dt1.Rows(0).Item("TransferFeeFlag") <> "N" Then
                        Dim SOAmount As Double = ViewState("Amount")
                        BalTot = BalAmt + SOAmount
                        If BalTot > 0 Then
                            If BalTot < txtamt.Text Then
                                lblR2.Text = "Transfer amount cannot be greater Balance Amount."
                                lblG2.Text = ""
                                lblR1.Text = ""
                                lblG1.Text = ""
                                lblRed1.Text = ""
                                lblGreen1.Text = ""
                                Exit Sub
                            End If

                        Else
                            lblR2.Text = "Cannot transfer money to fee"
                            lblG2.Text = ""
                            lblR1.Text = ""
                            lblG1.Text = ""
                            lblRed1.Text = ""
                            lblGreen1.Text = ""
                            Exit Sub
                        End If
                        Dim SponsorAmt As Double = 0
                        'Dim SOAmount As Double
                        Dim SBalAmount As Double
                        Dim amt As Double
                        If txtamt.Text = "" Then
                            amt = 0.0
                        Else
                            amt = txtamt.Text

                        End If
                        'SOAmount = ViewState("Amount")
                        dt = DLFrmCollectSponsor.GetSponsorAmt(HidStudentId.Value)
                        SponsorAmt = dt.Rows(0).Item("Amount")
                        'For Each rows As GridViewRow In GVsponsor.Rows
                        '    Dim Label As Label = rows.FindControl("lblamount")
                        '    SponsorAmt = SponsorAmt + Label.Text
                        'Next

                        SBalAmount = SponsorAmt + SOAmount
                        If SBalAmount > 0 Then

                            If SBalAmount < amt Then

                                lblR2.Text = "Transfer amount can't be greater than Sponsor Amount."
                                Exit Sub
                            End If
                        Else
                            lblR2.Text = "No Sponsor amount to  transfer."
                            Exit Sub
                        End If
                        El.mode = DDLModeRefund.SelectedValue
                        If DDLModeRefund.SelectedItem.Text = "Cheque" Then
                            If chqno.Text = "" Then
                                lblG2.Text = ""
                                lblR2.Text = "Cheque No is Mandatory."
                                lblRed1.Text = ""
                                lblGreen1.Text = ""
                                lblG1.Text = ""
                                lblR1.Text = ""
                                Exit Sub
                            Else
                                El.chqno = chqno.Text
                            End If
                            If chqdate.Text = "" Then
                                chqdate.Text = Format(Today, "dd-MMM-yyyy")
                                El.chqdate = chqdate.Text
                            Else
                                El.chqdate = chqdate.Text
                            End If
                        Else
                            El.chqno = ""
                            chqdate.Text = "01-Jan-3000"
                            El.chqdate = chqdate.Text
                        End If
                        El.amount = amt
                        BL.UpdateTransfer(El)
                        lblG2.Text = "Data Updated Sucessfully"
                        lblR2.Text = ""
                        lblRed1.Text = ""
                        lblGreen1.Text = ""
                        lblG1.Text = ""
                        lblR1.Text = ""

                        Clear()
                        btnRTOStu.Text = "REFUND TO STUDENT"
                        btnTTFee.Visible = True
                        btnTTFee.Text = "TRANSFER TO FEE"
                        DispGridPayable(ddlbatch1.SelectedValue)
                        DispGridPaid(ddlbatch1.SelectedValue)
                        GVsponsor.PageIndex = ViewState("PageIndex")
                        DispGrid()
                        GetAmount()
                    End If
                Else

                    dt = BL.DisplayGridview(El.id, HidStudentId.Value)
                    If dt.Rows.Count > 0 Then
                        El.STDID = dt.Rows(0).Item("StdId")
                        El.academic = dt.Rows(0).Item("Academic_Year")
                        El.Batch = dt.Rows(0).Item("Batch")
                        El.SpId = dt.Rows(0).Item("SponsorId")
                        El.date1 = dt.Rows(0).Item("SDate")
                        El.mode = DDLModeRefund.SelectedValue
                    End If

                    'If Excess < 0 Then
                    '    Excess = -1 * Excess
                    'End If
                    'dt = DLFrmCollectSponsor.GetRefundtot(HidStudentId.Value)
                    'If dt.Rows.Count > 0 Then

                    '    RefAmt = dt.Rows(0).Item("Amount")
                    'Else
                    '    RefAmt = 0.0
                    'End If
                    'RefAmt = Format(CDbl(RefAmt), "0.00")
                    ''RefTot = RefAmt
                    ''RefTot = (-1) * RefTot
                    'ExRes = Excess - RefTot
                    If Excess > 0 Then
                        If Excess < txtamt.Text Then
                            lblR2.Text = "Refund amount cannot be greater than excess amount"
                            Clear()
                            txtamt.Focus()
                            Exit Sub
                        End If
                    Else
                        lblR2.Text = "No Sponsor amount to refund."
                        Exit Sub
                    End If

                    If txtamt.Text = "" Then
                        El.amount = 0
                    Else
                        El.amount = (-1) * txtamt.Text
                    End If
                    If DDLModeRefund.SelectedItem.Text = "Cheque" Then
                        If chqno.Text = "" Then
                            lblG2.Text = ""
                            lblR2.Text = "Cheque No is Mandatory."
                            lblRed1.Text = ""
                            lblGreen1.Text = ""
                            lblG1.Text = ""
                            lblR1.Text = ""
                            Exit Sub
                        Else
                            El.chqno = chqno.Text
                        End If
                        If chqdate.Text = "" Then
                            chqdate.Text = Format(Today, "dd-MMM-yyyy")
                            El.chqdate = chqdate.Text
                        Else
                            El.chqdate = chqdate.Text
                        End If
                    Else
                        El.chqno = ""
                        chqdate.Text = "01-Jan-3000"
                        El.chqdate = chqdate.Text
                    End If

                    'El.ref = dt.Rows(0).Item("Refund")

                    'dt3 = BL.CheckDuplicateRef(El)
                    'If dt3.Rows.Count > 0 Then
                    '    'lblRed.Visible = True
                    '    lblR2.Text = "Data already exists."
                    '    lblG2.Text = ""
                    '    lblG1.Text = ""
                    '    lblR1.Text = ""
                    '    lblRed1.Text = ""
                    '    lblGreen1.Text = ""

                    '    DispGrid()
                    '    Exit Sub
                    'Else
                    El.ref = "Y"
                    BL.InsertSponsorRef(El)
                    lblG2.Text = "Amount refunded  Sucessfully"
                    lblR2.Text = ""
                    lblG1.Text = ""
                    lblR1.Text = ""
                    lblRed1.Text = ""
                    lblGreen1.Text = ""
                    ViewState("PageIndex") = 0
                    GVsponsor.PageIndex = 0
                    GetAmount()
                    DispGrid()
                    Clear()
                    End If
                    'End If

            Catch ex As Exception
                lblR2.Text = "Enter Correct Details."
                lblG2.Text = ""
                lblG1.Text = ""
                lblR1.Text = ""
                lblRed1.Text = ""
                lblGreen1.Text = ""

            End Try
        Else
            lblR1.Text = "You do not belong to this branch, Cannot Refund/transfer amount. "
            lblG1.Text = ""
            lblG2.Text = ""
            lblR2.Text = ""
            lblRed1.Text = ""
            lblGreen1.Text = ""

        End If


    End Sub

    Protected Sub btnTTFee_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnTTFee.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If DDLModeRefund.SelectedValue = 0 Then
                lblR2.Text = "Mode Field is Mandatory."
                lblG2.Text = ""
                lblG1.Text = ""
                lblR1.Text = ""
                lblRed1.Text = ""
                lblGreen1.Text = ""
                DDLModeRefund.Focus()
                Exit Sub
            End If
            Try
                Dim Bal As Double = txtBalance.Text
                Dim SponsorAmt As Double = 0
                Dim amt As Double
                lblG2.Text = ""
                lblR2.Text = ""
                lblG1.Text = ""
                lblR1.Text = ""
                lblRed1.Text = ""
                lblGreen1.Text = ""
                If txtamt.Text = "" Then
                    amt = 0.0
                Else
                    amt = txtamt.Text

                End If
                El.id = 0
                If btnTTFee.Text = "BACK" Then
                    Clear()

                    btnRTOStu.Text = "REFUND TO STUDENT"
                    btnTTFee.Visible = True
                    btnTTFee.Text = "TRANSFER TO FEE"
                    DispGrid()
                    GetAmount()
                Else
                    If Bal > 0 Then
                        If Bal < amt Then
                            lblR2.Text = "Transfer amount cannot be greater Balance Amount."
                            lblG2.Text = ""
                            lblR1.Text = ""
                            lblG1.Text = ""
                            lblRed1.Text = ""
                            lblGreen1.Text = ""
                            Clear()
                            txtamt.Focus()
                            Exit Sub
                        End If

                    Else
                        lblR2.Text = "Amount is balanced, Cannot transfer money to fee."
                        lblG2.Text = ""
                        lblR1.Text = ""
                        lblG1.Text = ""
                        lblRed1.Text = ""
                        lblGreen1.Text = ""
                        Clear()
                        Exit Sub
                    End If

                    dt = BL.DisplayGridview(El.id, HidStudentId.Value)
                    If dt.Rows.Count > 0 Then
                        El.STDID = dt.Rows(0).Item("StdId")
                        El.academic = dt.Rows(0).Item("Academic_Year")
                        El.Batch = dt.Rows(0).Item("Batch")
                        El.SpId = dt.Rows(0).Item("SponsorId")
                        El.date1 = dt.Rows(0).Item("SDate")
                        El.Category = HidCategory.Value
                        El.chqno = chqno.Text
                        El.mode = DDLModeRefund.SelectedValue
                    End If
                    If DDLModeRefund.SelectedItem.Text = "Cheque" Then
                        If chqno.Text = "" Then
                            lblG2.Text = ""
                            lblR2.Text = "Cheque No is Mandatory."
                            lblRed1.Text = ""
                            lblGreen1.Text = ""
                            lblG1.Text = ""
                            lblR1.Text = ""
                            Exit Sub
                        Else
                            El.chqno = chqno.Text
                        End If
                        If chqdate.Text = "" Then
                            chqdate.Text = Format(Today, "dd-MMM-yyyy")
                            El.chqdate = chqdate.Text
                        Else
                            El.chqdate = chqdate.Text
                        End If
                    Else
                        El.chqno = ""
                        chqdate.Text = "01-Jan-3000"
                        El.chqdate = chqdate.Text
                    End If
                    If txtamt.Text = "" Then
                        El.amount = 0.0
                    Else
                        El.amount = txtamt.Text

                    End If
                    For Each rows As GridViewRow In GVsponsor.Rows
                        Dim Label As Label = rows.FindControl("lblamount")
                        SponsorAmt = SponsorAmt + Label.Text
                    Next
                    If SponsorAmt > 0 Then

                        If SponsorAmt < amt Then

                            lblR2.Text = "Transfer amount can't be greater than Sponsor Amount."
                            Exit Sub
                        End If
                    Else
                        lblR2.Text = "No Sponsor amount to  transfer."
                        lblG2.Text = ""
                        lblG1.Text = ""
                        lblR1.Text = ""
                        lblRed1.Text = ""
                        lblGreen1.Text = ""
                        chqno.Text = ""
                        chqdate.Text = ""
                        Exit Sub
                    End If

                    BL.UpdateSponsorTransfer(El)
                    lblG2.Text = "Amount transfered to Fee Sucessfully"
                    lblR2.Text = ""
                    lblG1.Text = ""
                    lblR1.Text = ""
                    lblRed1.Text = ""
                    lblGreen1.Text = ""
                    ViewState("PageIndex") = 0
                    GVsponsor.PageIndex = 0
                    DispGrid()
                    DispGridPaid(ddlbatch1.SelectedValue)
                    DispGridPayable(ddlbatch1.SelectedValue)
                    GetAmount()
                    Clear()
                    End If
            Catch ex As Exception
                lblR2.Text = "Enter Correct Details"
            End Try
        Else
            lblR1.Text = "You do not belong to this branch, Cannot transfer amount to Fee. "
            lblG1.Text = ""
            lblG2.Text = ""
            lblR2.Text = ""
            lblRed1.Text = ""
            lblGreen1.Text = ""

        End If

    End Sub

    Protected Sub GVsponsor_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVsponsor.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        El.id = 0

        dt = BL.DisplayGridview(El.id, HidStudentId.Value)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVsponsor.DataSource = sortedView
        GVsponsor.DataBind()
        GVsponsor.Enabled = True
        GVsponsor.Visible = True
        'LinkButton.Focus()
    End Sub
End Class
