Imports System.Data.OleDb
Imports System.Data

Partial Class LeaveDetails
    Inherits BasePage
    Dim Emp As String
    Dim leaveid As Integer
    Dim leave As New Leave
    Dim dt As New DataTable
    Dim leaveManager As New LeaveManager
    Dim GlobalFunction As New GlobalFunction
    Sub SplitName(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()

            If parts.Length > 2 Then
                txtEmp.Text = parts(1).ToString() + ":" + parts(2).ToString()
                HidempId.Value = parts(0).ToString()
            Else
                txtEmp.Text = parts(1).ToString()
            End If
            'txtEmpName.Text = parts(1).ToString()

            'ViewState("EmpID") = EmpID
        Else
            txtEmp.AutoPostBack = True
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtEmp.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        'If txtEmp.Text <> "" Then
        '    SplitName(txtEmp.Text)
        'Else
        '    txtEmp.AutoPostBack = True
        '    'txtEmpName.Text = ""
        '    SplitName(txtEmp.Text)
        'End If
    End Sub

    Sub clear()
        txtEmp.Text = ""
        textblanceleav.Text = ""
        txtremark.Text = ""
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGridView()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If Session("Privilages").ToString.Contains("W") Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                msginfo.Text = ""
                lblmsg.Text = ""
                leave.LmId = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("lid"), HiddenField).Value
                leaveManager.Delete(leave)
                lblmsg.Text = "Data Deleted Successfully."
                msginfo.Text = ""
                GridView1.PageIndex = ViewState("PageIndex")
                DisplayGridView()

            Else
                msginfo.Text = "You do not belong to this branch, Cannot delete data."
                lblmsg.Text = ""
            End If
        Else
            msginfo.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        If Session("Privilages").ToString.Contains("W") Then

            'If (Session("BranchCode") = Session("ParentBranch")) Then
            msginfo.Text = ""
            lblmsg.Text = ""
            ddlleav.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("HidLvTpe"), HiddenField).Value
            HidempId.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("HidEmpId"), HiddenField).Value
            txtEmp.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label01"), Label).Text
            textblanceleav.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label301"), Label).Text
            txtremark.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label401"), Label).Text
            ddlYear.Items.Clear()
            ddlYear.DataSourceID = "ObjSelectYear"
            ddlYear.DataBind()

            If CType(GridView1.Rows(e.NewEditIndex).FindControl("Label7"), Label).Text = "" Then
                ddlYear.SelectedValue = 43
            Else
                ddlYear.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label7"), Label).Text
            End If

            ViewState("id1") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lid"), HiddenField).Value
            leave.LmId = ViewState("id1")
            dt = leaveManager.GetLeave(leave)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = False
            BtnSave.Text = "UPDATE"
            btnDetails.Text = "BACK"
            BtnSaveAll.Enabled = False
            'DisplayGridView()

            'Else
            'msginfo.Text = "You do not belong to this branch, Cannot edit data."
            'lblmsg.Text = ""
            'End If
        Else
            msginfo.Text = "You do not have Write Privilage."
        End If
    End Sub

    Sub DisplayGridView()
        LinkButton1.Focus()
        Dim dt As New DataTable
        leave.LmId = 0
        dt = leaveManager.GetLeave(leave)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
        Else
            msginfo.Text = "No records to display."
            lblmsg.Text = ""
            GridView1.Visible = False
        End If
        'clear()
    End Sub

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Session("Privilages").ToString.Contains("W") Then

            txtEmp.Focus()

            If (Session("BranchCode") = Session("ParentBranch")) Then
                Try
                    If BtnSave.Text = "CREDIT" Then

                        Dim leave As New Leave

                        leave.EId = HidempId.Value
                        leave.LeaveType = ddlleav.SelectedValue
                        leave.Year = ddlYear.SelectedItem.Text
                        leave.Dept_Id = ddlDept.SelectedValue
                        dt = leaveManager.GetDuplicateLeaveDetails(leave)
                        If dt.Rows.Count > 0 Then
                            msginfo.Text = "Data already exists."
                            lblmsg.Text = ""
                            DisplayGridView()
                            'clear()
                        Else
                            leave.BalanceLeave = textblanceleav.Text
                            leave.Remarks = txtremark.Text
                            leave.Year = ddlYear.SelectedItem.Text
                            leaveManager.InsertRecord(leave)
                            lblmsg.Text = "Data Saved Successfully."
                            msginfo.Text = ""
                            BtnSaveAll.Enabled = True
                            clear()

                            GridView1.Visible = False
                            GridView1.Enabled = True
                            ViewState("PageIndex") = 0
                            GridView1.PageIndex = 0
                            DisplayGridView()
                        End If
                    ElseIf BtnSave.Text = "UPDATE" Then

                        'Dim s As New Leave
                        's.LmId = ViewState("id1")
                        's.EId = HidempId.Value
                        's.LeaveType = ddlleav.SelectedValue
                        's.BalanceLeave = textblanceleav.Text
                        '    s.Remarks = txtremark.Text
                        '    dt = leaveManager.GetDuplicateLeaveDetails(s)
                        '    If dt.Rows.Count > 0 Then
                        '        msginfo.Text = "Data already exists."
                        '        lblmsg.Text = 

                        Dim leave As New Leave
                        leave.Remarks = txtremark.Text
                        leave.EId = HidempId.Value
                        leave.LeaveType = ddlleav.SelectedValue
                        leave.Year = ddlYear.SelectedItem.Text
                        leave.Dept_Id = ddlDept.SelectedValue
                        leave.LmId = ViewState("id1")
                        dt = leaveManager.GetDuplicateLeaveDetails(leave)
                        If dt.Rows.Count > 0 Then
                            msginfo.Text = "Data already exists."
                            BtnSaveAll.Enabled = True
                            lblmsg.Text = ""
                            leave.LmId = ViewState("id1")
                            dt = leaveManager.GetLeave(leave)
                            GridView1.DataSource = dt
                            GridView1.DataBind()
                            GridView1.Visible = True
                            GridView1.Enabled = False

                            'lblmsg.Text = ""
                            'DisplayGridView()
                        Else
                            leave.BalanceLeave = textblanceleav.Text
                            leave.Year = ddlYear.SelectedItem.Text
                            leaveManager.UpdateRecord(leave)
                            GridView1.PageIndex = ViewState("PageIndex")
                            DisplayGridView()
                            GridView1.Visible = True
                            GridView1.Enabled = True

                            lblmsg.Text = "Data Updated Successfully."
                            msginfo.Text = ""
                            BtnSaveAll.Enabled = True
                            BtnSave.Text = "CREDIT"
                            btnDetails.Text = "VIEW"
                            GridView1.PageIndex = ViewState("PageIndex")
                            DisplayGridView()
                            txtEmp.Text = ""
                            'txtleav.Text = ""
                            textblanceleav.Text = ""
                            txtremark.Text = ""
                        End If
                    End If
                Catch ex As Exception
                    msginfo.Text = "Enter Correct Data."
                    lblmsg.Text = ""
                End Try
            Else
                msginfo.Text = "You do not belong to this branch, Cannot add/update data."
                lblmsg.Text = ""
            End If

        Else
            msginfo.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub btnDetails_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then

            msginfo.Text = ""
            lblmsg.Text = ""
            If btnDetails.Text = "VIEW" Then
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                DisplayGridView()
                BtnSaveAll.Enabled = True
                clear()
            ElseIf btnDetails.Text = "BACK" Then
                BtnSave.Text = "CREDIT"
                btnDetails.Text = "VIEW"
                BtnSaveAll.Enabled = True
                clear()
                GridView1.PageIndex = ViewState("PageIndex")
                DisplayGridView()
                GridView1.Enabled = True
                GridView1.Visible = True
            End If
        Else
            msginfo.Text = "You do not have Read Privilage."
        End If
    End Sub


    Protected Sub BtnSaveAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSaveAll.Click
        'leave.EId = HidempId.Value
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then

                If ddlleav.SelectedValue = 0 Then
                    msginfo.Text = "Leave Type is mandatory."
                    lblmsg.Text = ""
                    ddlleav.Focus()
                    lblmsg.Text = ""
                ElseIf textblanceleav.Text = "" Then
                    msginfo.Text = "No Of Days field is mandatory."
                    textblanceleav.Focus()
                    lblmsg.Text = ""
                Else
                    leave.LeaveType = ddlleav.SelectedValue
                    leave.BalanceLeave = textblanceleav.Text
                    leave.Remarks = txtremark.Text
                    leave.Dept_Id = ddlDept.SelectedValue
                    leaveManager.InsertRecordAll(leave)

                    lblmsg.Text = "Data credited successfully for all employees."
                    msginfo.Text = ""
                    GridView1.Visible = False
                    GridView1.Enabled = True
                    DisplayGridView()
                End If

            Else
                msginfo.Text = "You do not belong to this branch, Cannot add data."
                lblmsg.Text = ""
            End If
        Else
            msginfo.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub ddlleav_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlleav.TextChanged
        ddlleav.Focus()
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
        Dim dt As New DataTable
        leave.LmId = 0
        dt = leaveManager.GetLeave(leave)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
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

    Protected Sub txtEmp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmp.TextChanged
        If txtEmp.Text <> "" Then
            SplitName(txtEmp.Text)
        Else
            txtEmp.AutoPostBack = True
            'txtEmpName.Text = ""
            SplitName(txtEmp.Text)
        End If
    End Sub

    Protected Sub BtnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSearch.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then

            msginfo.Text = ""
            lblmsg.Text = ""
            Dim dt As New DataTable
            If HidempId.Value = "" Then
                leave.EmpId = 0
            Else
                leave.EmpId = HidempId.Value
            End If

            leave.Dept_Id = ddlDept.SelectedValue
            leave.LeaveType = ddlleav.SelectedValue
            dt = LeaveDB.SearchLeave(leave)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Visible = True
                GridView1.Enabled = True
            Else
                msginfo.Text = "No records to display."
                lblmsg.Text = ""
                GridView1.Visible = False
            End If
        Else
            msginfo.Text = "You do not have Read Privilage."
        End If
    End Sub
End Class
