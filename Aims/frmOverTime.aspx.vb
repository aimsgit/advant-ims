Imports System.Data
Imports System.Collections.Generic
Imports Microsoft.VisualBasic.Strings

Partial Class frmOverTime
    Inherits BasePage
    Dim EL As New ELOverTime
    Dim BL As New BLOverTime
    Dim dt, dt1 As New DataTable
    'Code by shwettha J K On 12-01-2014
    'Code for Over time entry form

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ddlMonth.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Try
                If btnAdd.Text = "UPDATE" Then
                    EL.ID = ViewState("OT_Id_Auto")

                    EL.Month = ddlMonth.SelectedValue
                    EL.EmpNo = ddlEmpNo.SelectedValue
                    EL.EmpName = txtEmpName.Text
                    EL.DeptName = ddlDept.Text
                    'EL.BasicSal = txtBasicSal.Text
                    EL.OTRate = txtOTRate.Text
                    EL.VoucherNo = txtVoucherNo.Text
                    EL.TotAmount = txtTotalAmount.Text
                    EL.NoOfHours = txtNoOfHours.Text
                    EL.NoOfMinutes = txtNoOfMinutes.Text
                    dt = DLOverTime.GetDupplicateOT(EL)
                    dt1 = DLOverTime.GetDupplicateVoucher(EL)
                    If dt.Rows.Count > 0 Then
                        lblErrorMsg.Visible = True
                        lblErrorMsg.Text = "Data already exists."
                        msginfo.Text = ""
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"

                    ElseIf dt1.Rows.Count > 0 Then
                        lblErrorMsg.Visible = True
                        lblErrorMsg.Text = "Voucher No. already exists."
                        msginfo.Text = ""
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"
                        Exit Sub

                    Else

                        BL.UpdateOT(EL)
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"
                        lblErrorMsg.Text = ""
                        msginfo.Visible = True
                        msginfo.Text = "Data updated successfully."
                        clear()
                        GridView1.PageIndex = ViewState("PageIndex")
                        DisplayOTDetails()

                    End If
                ElseIf btnAdd.Text = "ADD" Then

                    EL.Month = ddlMonth.SelectedValue
                    EL.EmpNo = ddlEmpNo.SelectedValue
                    EL.EmpName = txtEmpName.Text
                    EL.DeptName = ddlDept.Text
                    'EL.BasicSal = txtBasicSal.Text
                    EL.OTRate = txtOTRate.Text
                    EL.VoucherNo = txtVoucherNo.Text
                    EL.TotAmount = txtTotalAmount.Text
                    If (txtNoOfHours.Text = "") Then
                        EL.NoOfHours = 0
                    Else
                        EL.NoOfHours = txtNoOfHours.Text
                    End If
                    If (txtNoOfMinutes.Text = "") Then
                        EL.NoOfMinutes = 0
                    Else
                        EL.NoOfMinutes = txtNoOfMinutes.Text
                    End If

                    dt = DLOverTime.GetDupplicateOT(EL)
                    dt1 = DLOverTime.GetDupplicateVoucher(EL)
                    If dt.Rows.Count > 0 Then
                        lblErrorMsg.Visible = True
                        lblErrorMsg.Text = "Data already exists."
                        msginfo.Text = ""
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"
                    ElseIf dt1.Rows.Count > 0 Then
                        lblErrorMsg.Visible = True
                        lblErrorMsg.Text = "Voucher No. already exists."
                        msginfo.Text = ""
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"
                        Exit Sub

                    Else
                        BL.InsertRecordOT(EL)
                        btnAdd.Text = "ADD"
                        lblErrorMsg.Text = ""
                        msginfo.Visible = True
                        msginfo.Text = "Data saved successfully."
                        clear()
                    End If
                    GridView1.Enabled = True
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    DisplayOTDetails()
                    End If
            Catch ex As Exception

                lblErrorMsg.Text = "Invalid data."
            End Try
        End If

    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click

        LinkButton.Focus()

        If btnView.Text = "VIEW" Then
            GridView1.Enabled = True
            lblErrorMsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            GridView1.PageIndex = ViewState("PageIndex")
            If (ddlEmpNo.SelectedValue = "") Then
                EL.EmpNo = 0
            Else
                EL.EmpNo = ddlEmpNo.SelectedValue
            End If
            DisplayOTDetails()

        ElseIf btnView.Text = "BACK" Then
            GridView1.Enabled = True
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
            clear()
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayOTDetails()
            lblErrorMsg.Text = ""
            msginfo.Text = ""
        End If
    End Sub

    Sub DisplayOTDetails()
        Dim dt As New DataTable
        EL.ID = 0
        EL.DeptName = ddlDept.SelectedValue
        EL.EmpNo = ddlEmpNo.SelectedValue

        dt = BL.GetGridDataOT(EL)

        If dt.Rows.Count > 0 Then

            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.PageIndex = ViewState("PageIndex")
            LinkButton.Focus()
        End If
        If dt.Rows.Count = 0 Then
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "No records to display."
            msginfo.Text = ""
        End If
    End Sub
    Sub clear()
        'txtBasicSal.Text = ""
        txtOTRate.Text = ""
        txtVoucherNo.Text = ""
        txtTotalAmount.Text = ""
        txtNoOfHours.Text = ""
        txtNoOfMinutes.Text = ""
    End Sub

    Protected Sub ddlEmpNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpNo.SelectedIndexChanged
        lblErrorMsg.Text = ""
        msginfo.Text = ""
        EL.EmpNo = ddlEmpNo.SelectedValue
        dt = BL.AutoGenerateNo(EL)
        If (ddlEmpNo.SelectedValue = 0) Then
            txtEmpName.Text = ""
        Else
            txtEmpName.Text = dt.Rows(0).Item("Emp_Name").ToString
        End If

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        msginfo.Text = ""
        lblErrorMsg.Text = ""
        EL.ID = ViewState("OT_Id_Auto")

        txtEmpName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEmpName"), Label).Text
        ViewState("OT_Id_Auto") = CType(GridView1.Rows(e.NewEditIndex).FindControl("OTId"), HiddenField).Value
        'txtBasicSal.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblBasicSalary"), Label).Text
        txtOTRate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblOTRate"), Label).Text
        txtVoucherNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblVoucherNo"), Label).Text
        ddlDept.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDeptId"), Label).Text
        ddlEmpNo.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEmpId"), Label).Text
        ddlMonth.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblMonth"), Label).Text
        txtTotalAmount.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblTotalAmount"), Label).Text
        txtNoOfHours.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblNoOfHours"), Label).Text
        txtNoOfMinutes.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblNoOfMinutes"), Label).Text
        btnAdd.Text = "UPDATE"
        btnView.Text = "BACK"

        EL.ID = ViewState("OT_Id_Auto")
        EL.EmpNo = ddlEmpNo.SelectedValue
        EL.DeptName = ddlDept.SelectedValue
        dt = BL.GetGridDataOT(EL)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("OT_Id_Auto") = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("OTId"), HiddenField).Value
            EL.ID = ViewState("OT_Id_Auto")
            EL.EmpNo = ddlEmpNo.SelectedValue
            BL.ChangeFlagOT(EL)
            DisplayOTDetails()
            GridView1.Visible = True
            lblErrorMsg.Text = ""
            msginfo.Text = "Data Deleted Successfully."
            ddlEmpNo.Focus()
            GridView1.PageIndex = ViewState("PageIndex")

            dt = BL.GetGridDataOT(EL)
            GridView1.DataSource = dt
            GridView1.DataBind()

            GridView1.Enabled = True
            GridView1.Visible = True
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            msginfo.Text = ""
        End If

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayOTDetails()
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
        EL.DeptName = ddlDept.SelectedValue
        EL.EmpNo = ddlEmpNo.SelectedValue
        dt = BL.GetGridDataOT(EL)
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


    Protected Sub txtOTRate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOTRate.TextChanged
        If (txtOTRate.Text = "") Then
            msginfo.Text = ""
            lblErrorMsg.Text = "OT Rate Fied is Mandatory."
            txtOTRate.Focus()

            Exit Sub
            ElseIf (txtNoOfHours.Text = "") Then
            txtNoOfHours.Text = 0
        End If
        If (txtNoOfMinutes.Text = "") Then
            txtNoOfMinutes.Text = 0
        End If
        If (txtNoOfMinutes.Text = 0) Then
            txtTotalAmount.Text = txtOTRate.Text * (txtNoOfHours.Text)
            txtTotalAmount.Text = Math.Round(Convert.ToDecimal(txtTotalAmount.Text), 2)
        ElseIf (txtNoOfHours.Text = 0) Then
            txtTotalAmount.Text = txtOTRate.Text * ((txtNoOfMinutes.Text) / 60)
            txtTotalAmount.Text = Math.Round(Convert.ToDecimal(txtTotalAmount.Text), 2)
        Else
            txtTotalAmount.Text = txtOTRate.Text * (((txtNoOfMinutes.Text) / 60) + (txtNoOfHours.Text))
            txtTotalAmount.Text = Math.Round(Convert.ToDecimal(txtTotalAmount.Text), 2)
        End If
    End Sub

    Protected Sub txtNoOfHours_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoOfHours.TextChanged
        If (txtOTRate.Text = "") Then
            msginfo.Text = ""
            lblErrorMsg.Text = "OT Rate Fied is Mandatory."
            txtOTRate.Focus()
            Exit Sub
        ElseIf (txtNoOfMinutes.Text = "") Then
            txtNoOfMinutes.Text = 0
        End If

        If (txtNoOfMinutes.Text = 0) Then
            txtTotalAmount.Text = txtOTRate.Text * (txtNoOfHours.Text)
            txtTotalAmount.Text = Math.Round(Convert.ToDecimal(txtTotalAmount.Text), 2)
        ElseIf (txtNoOfHours.Text = 0) Then
            txtTotalAmount.Text = txtOTRate.Text * ((txtNoOfMinutes.Text) / 60)
            txtTotalAmount.Text = Math.Round(Convert.ToDecimal(txtTotalAmount.Text), 2)
        Else
            txtTotalAmount.Text = txtOTRate.Text * (((txtNoOfMinutes.Text) / 60) + (txtNoOfHours.Text))
            txtTotalAmount.Text = Math.Round(Convert.ToDecimal(txtTotalAmount.Text), 2)
        End If
    End Sub

    Protected Sub txtNoOfMinutes_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoOfMinutes.TextChanged
        If (txtOTRate.Text = "") Then
            msginfo.Text = ""
            lblErrorMsg.Text = "OT Rate Fied is Mandatory."
            txtOTRate.Focus()
            Exit Sub
        ElseIf (txtNoOfHours.Text = "") Then
            txtNoOfHours.Text = 0
        End If
        If (txtNoOfMinutes.Text = 0) Then
            txtTotalAmount.Text = txtOTRate.Text * (txtNoOfHours.Text)
            txtTotalAmount.Text = Math.Round(Convert.ToDecimal(txtTotalAmount.Text), 2)
        ElseIf (txtNoOfHours.Text = 0) Then

            txtTotalAmount.Text = txtOTRate.Text * ((txtNoOfMinutes.Text) / 60)
             txtTotalAmount.Text = Math.Round(Convert.ToDecimal(txtTotalAmount.Text), 2)
        Else
            txtTotalAmount.Text = txtOTRate.Text * (((txtNoOfMinutes.Text) / 60) + (txtNoOfHours.Text))
             txtTotalAmount.Text = Math.Round(Convert.ToDecimal(txtTotalAmount.Text), 2)
        End If
    End Sub
End Class
