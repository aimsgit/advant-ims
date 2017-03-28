
Partial Class frmExtraCurricularAchivements
    Inherits BasePage
    ''Created By- Ajit
    ''Date- 25 Mar 2013
    Dim ECA As New ExtraCurricularAchievementsEL
    Dim ECAB As New ExtraCurricularAchivementsBL
    Dim dt As DataTable

    Protected Sub ddlDepartment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartment.TextChanged
        ddlDepartment.Focus()
        lblmsg.Text = ""
        lblerrmsg.Text = ""
    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try


                ECA.DeptID = ddlDepartment.SelectedValue
                ECA.NameOfActivity = txtNameofActivity.Text
                If RBUsers.SelectedValue = "Student" Then
                    'txtStdCode.Focus()
                    'ELIssue.StdCode = HidstdId.Value.Replace(",", "")
                    'ELIssue.StdName = txtStdName.Text
                    'ELIssue.StdCode = ViewState("StdID")
                    If StdID.Value = "" Then
                        lblerrmsg.Text = "Please Enter Correct Student code."
                        txtStdCode.Focus()
                        lblmsg.Text = ""
                        Exit Sub
                    End If
                    ECA.StdCode = StdID.Value
                    ECA.EmpCode = 0
                Else
                    'txtEmpCode.Focus()
                    'ELIssue.EmpCode = HidEmp.Value.Replace(",", "")
                    'ELIssue.EmpName = txtEmpName.Text
                    'ELIssue.EmpCode = ViewState("EmpID")
                    If EmpId.Value = "" Then
                        lblerrmsg.Text = "Please Enter Correct Employee code."
                        lblmsg.Text = ""
                        txtEmpCode.Focus()
                        Exit Sub
                    End If
                    ECA.EmpCode = EmpId.Value
                    ECA.StdCode = 0
                End If
                ECA.Std_Emp = RBUsers.SelectedValue

                If txtFromDate.Text = "" Then
                    ECA.FromDate = "1/1/1900"
                Else
                    ECA.FromDate = txtFromDate.Text
                End If
                If txtToDate.Text = "" Then
                    ECA.ToDate = "1/1/1900"
                Else
                    ECA.ToDate = txtToDate.Text
                End If
                If CDate(IIf(txtFromDate.Text <> "", txtFromDate.Text, "1/1/1900")) > CDate(IIf(txtToDate.Text <> "", txtToDate.Text, "1/1/9100")) Then
                    lblerrmsg.Text = "From Date Cannot be greater than To Date."
                    lblmsg.Text = ""
                    Exit Sub
                End If
                ECA.Remarks = txtRemarks.Text

                If btnadd.Text = "UPDATE" Then
                    ECA.Id = ViewState("AID")

                    If RBUsers.SelectedValue = "Student" Then
                        ECA.StdCode = StdID.Value
                        ECA.EmpCode = 0
                    Else
                        ECA.EmpCode = EmpId.Value
                        ECA.StdCode = 0
                    End If


                    ECAB.UpdateRecord(ECA)
                    btnadd.Text = "ADD"
                    btnview.Text = "VIEW"
                    lblerrmsg.Text = ""
                    lblmsg.Text = "Data Updated Successfully."
                    GridView1.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    GridView1.Enabled = "true"
                    clear()

                ElseIf btnadd.Text = "ADD" Then
                    ECAB.InsertRecord(ECA)
                    lblerrmsg.Text = ""
                    lblmsg.Text = "Data Saved Successfully."
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    DisplayGrid()
                    clear()
                End If
            Catch ex As Exception
                lblerrmsg.Text = "Date is not valid."
                lblmsg.Text = ""
            End Try
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub clear()
        txtNameofActivity.Text = ""
        txtFromDate.Text = ""
        txtToDate.Text = ""
        txtRemarks.Text = ""
        txtStdCode.Text = ""
        txtEmpCode.Text = ""
    End Sub
    Sub DisplayGrid()
        ECA.Id = 0
        ECA.DeptID = ddlDepartment.SelectedValue
        ECA.NameOfActivity = txtNameofActivity.Text
        'If RBUsers.SelectedValue = "Student" Then

        'Else

        'End If
        dt = ECAB.GetECA(ECA)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            If RBUsers.SelectedValue = "Student" Then


                GridView1.Columns(7).Visible = True
                GridView1.Columns(6).Visible = True
                GridView1.Columns(5).Visible = True
                GridView1.Columns(4).Visible = True
                GridView1.Columns(3).Visible = False
                GridView1.Columns(2).Visible = True
            Else

                GridView1.Columns(7).Visible = True
                GridView1.Columns(6).Visible = True
                GridView1.Columns(5).Visible = True
                GridView1.Columns(4).Visible = True
                GridView1.Columns(3).Visible = True
                GridView1.Columns(2).Visible = False
            End If
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblFromDate"), Label).Text = ""
                End If
            Next
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblToDate"), Label).Text = ""
                End If
            Next
            GridView1.Visible = "true"
            LinkButton.Focus()
        Else
            lblerrmsg.Text = "No records to display."
            lblmsg.Text = ""
            GridView1.Visible = "False"
        End If

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            ECA.Id = CType(GridView1.Rows(e.RowIndex).FindControl("lblAID"), Label).Text
            ECAB.ChangeFlag(ECA)
            lblerrmsg.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            GridView1.PageIndex = ViewState("PageIndex")

            ECA.Id = 0
            ECA.DeptID = ddlDepartment.SelectedValue
            ECA.NameOfActivity = txtNameofActivity.Text
            dt = ECAB.GetECA(ECA)

            GridView1.DataSource = dt
            GridView1.DataBind()
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblFromDate"), Label).Text = ""
                End If
            Next
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblToDate"), Label).Text = ""
                End If
            Next

            GridView1.Visible = "true"
            LinkButton.Focus()
            clear()
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblerrmsg.Text = ""
        lblmsg.Text = ""
        GridView1.Enabled = "false"
        'ddlDepartment.Items.Clear()
        'ddlDepartment.DataSourceID = "objDepartment"
        'ddlDepartment.DataBind()
        ddlDepartment.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDeptId"), Label).Text
        'StdID.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("stdHidden"), Label).Text

        If RBUsers.SelectedValue = "Student" Then
            txtStdCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("StdCode"), Label).Text
            txtStdName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStuName"), Label).Text
        Else
            txtEmpCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("EmpIdCode"), Label).Text
            txtEmpName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEmpName"), Label).Text
        End If

        txtNameofActivity.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblActivity"), Label).Text
        txtFromDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblFromDate"), Label).Text
        txtToDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblToDate"), Label).Text
        txtRemarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
        ViewState("AID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAID"), Label).Text
        btnadd.Text = "UPDATE"
        btnview.Text = "BACK"

        Dim dt As New DataTable

        ECA.Id = ViewState("AID")
        ECA.DeptID = ddlDepartment.SelectedValue
        ECA.NameOfActivity = txtNameofActivity.Text
        dt = ECAB.GetECA(ECA)
        GridView1.DataSource = dt
        GridView1.DataBind()
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblFromDate"), Label).Text = ""
            End If
        Next
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblToDate"), Label).Text = ""
            End If
        Next
        GridView1.Visible = "true"
    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        lblerrmsg.Text = ""
        lblmsg.Text = ""
        If btnview.Text = "VIEW" Then
            DisplayGrid()
        Else
            btnview.Text = "VIEW"
            btnadd.Text = "ADD"
            clear()
            DisplayGrid()
            GridView1.Enabled = "True"
        End If
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
    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        ECA.Id = 0
        ECA.DeptID = ddlDepartment.SelectedValue
        ECA.NameOfActivity = txtNameofActivity.Text
        dt = ECAB.GetECA(ECA)

        GridView1.DataSource = dt
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblFromDate"), Label).Text = ""
            End If
        Next
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblToDate"), Label).Text = ""
            End If
        Next
        GridView1.Visible = "true"
        LinkButton.Focus()
        clear()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If RBUsers.SelectedValue = "Student" Then
            lblEmpCode.Visible = False
            txtEmpCode.Visible = False
            lblEmpName.Visible = False
            txtEmpName.Visible = False

            lblStdCode.Visible = True
            txtStdCode.Visible = True
            lblStdName.Visible = True
            txtStdName.Visible = True
        Else
            'txtEmpCode.Focus()
            lblStdCode.Visible = False
            txtStdCode.Visible = False
            lblStdName.Visible = False
            txtStdName.Visible = False

            lblEmpCode.Visible = True
            txtEmpCode.Visible = True
            lblEmpName.Visible = True
            txtEmpName.Visible = True
        End If
        If txtStdCode.Text <> "" Then
            Splitter1(txtStdCode.Text)
        Else
            txtStdCode.AutoPostBack = True
            txtStdName.Text = ""
            Splitter1(txtStdCode.Text)
        End If
        If txtEmpCode.Text <> "" Then
            Splitter2(txtEmpCode.Text)
        Else
            txtEmpCode.AutoPostBack = True
            txtEmpName.Text = ""
            Splitter2(txtEmpCode.Text)
        End If
        'If RBUsers.SelectedValue = "Student" Then
        '    For Each rows As GridViewRow In GridView1.Rows
        '        CType(rows.FindControl("lblEmpName"), Label).Visible = False
        '        CType(rows.FindControl("lblStuName"), Label).Visible = True
        '        'Else 
        '    Next
        'Else
        '    For Each rows As GridViewRow In GridView1.Rows
        '        CType(rows.FindControl("lblStuName"), Label).Visible = False
        '        CType(rows.FindControl("lblEmpName"), Label).Visible = True
        '    Next
        'End If
    End Sub
    Sub Splitter1(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("StdCode") = parts(0).ToString()
            txtStdCode.Text = parts(0).ToString()
            txtStdName.Text = parts(1).ToString()
            StdID.Value = parts(2).ToString()
            'ViewState("StdID") = StdID
        Else
            txtStdCode.AutoPostBack = True
        End If
    End Sub
    Sub Splitter2(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            txtEmpCode.Text = parts(0).ToString()
            txtEmpName.Text = parts(1).ToString()
            EmpId.Value = parts(2).ToString()
            'ViewState("EmpID") = EmpID
        Else
            txtEmpCode.AutoPostBack = True
        End If
    End Sub
    Sub selection()
        If RBUsers.SelectedValue.ToString = "Employee" Then
            AutoCompleteExtender3.ServicePath = "TextBoxExt.asmx"
            AutoCompleteExtender3.ServiceMethod = "getEmpCodeExt1"
        ElseIf RBUsers.SelectedValue.ToString = "Student" Then
            AutoCompleteExtender1.ServicePath = "TextBoxExt.asmx"
            AutoCompleteExtender1.ServiceMethod = "getStudentIdName1"
        End If
    End Sub

    Protected Sub txtStdCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStdCode.TextChanged
        If txtStdCode.Text = "" Then
            txtStdName.Text = ""
        End If
        GridView1.Visible = False
        lblerrmsg.Text = ""
        lblmsg.Text = ""
        If StdID.Value = "" Then
            lblerrmsg.Text = "Enter Valid Student Code."
            lblmsg.Text = ""
            Exit Sub
        End If
    End Sub

    Protected Sub txtEmpCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpCode.TextChanged
        If txtEmpCode.Text = "" Then
            txtEmpName.Text = ""
        End If
        GridView1.Visible = False
        lblerrmsg.Text = ""
        lblmsg.Text = ""
        If EmpId.Value = "" Then
            lblerrmsg.Text = "Enter Valid Employee Code."
            lblmsg.Text = ""
            Exit Sub
        End If
    End Sub
End Class
