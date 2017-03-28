Imports BookReturnB
Imports BookReturnP
Partial Class BookReturnM
    Inherits BasePage
    Dim ELBookREturn As New BookReturnP
    Dim blbookreturn As New BookReturnB
    Dim dt As New DataTable
    Sub Splitter1(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("StdCode") = parts(0).ToString()
            txtstuCode.Text = parts(0).ToString()
            txtstuname.Text = parts(1).ToString()
            HIDSTUCODE.Value = parts(2).ToString()
            'ViewState("StdID") = StdID
        Else
            txtstuCode.AutoPostBack = True
        End If
    End Sub
    Sub Splitter2(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            txtEmpCode.Text = parts(0).ToString()
            txtEmpName.Text = parts(1).ToString()
            HIDEMPCODE.Value = parts(2).ToString()
            'ViewState("EmpID") = EmpID
        Else
            txtEmpCode.AutoPostBack = True
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                ELBookREturn.DeptId = ddlDept.SelectedValue
                ELBookREturn.Branch = ddlBranchType.SelectedValue
                If txtstuCode.Text = "" And rdbcode.SelectedValue = "1" Then
                    lblerrmsg.Text = "Student Code field is mandatory."
                    lblmsg.Text = ""
                    GV_BookReturn.Visible = False
                ElseIf txtempcode.Text = "" And rdbcode.SelectedValue = "2" Then
                    lblerrmsg.Text = "Employee Code field is mandatory."
                    lblmsg.Text = ""
                    GV_BookReturn.Visible = False
                ElseIf cmbBookCode.SelectedValue = "0" Then
                    lblerrmsg.Text = "Book Code field is mandatory."
                    lblmsg.Text = ""
                    GV_BookReturn.Visible = False
                ElseIf txtfine.Text <> "" And IsNumeric(txtfine.Text) = False Then
                    lblerrmsg.Text = "Fine should be numeric."
                    lblmsg.Text = ""
                Else
                    If rdbcode.SelectedValue = 1 Then
                        ELBookREturn.EmpID = 0
                        ELBookREturn.STD_ID = HIDSTUCODE.Value
                    Else
                        ELBookREturn.EmpID = HIDEMPCODE.Value
                        ELBookREturn.STD_ID = 0
                    End If
                    ELBookREturn.BookCode = cmbBookCode.SelectedValue
                    ELBookREturn.ReturnDate = txtreturndate.Text
                    If txtDays.Text = "" Then
                        ELBookREturn.Days = 0
                    Else
                        ELBookREturn.Days = txtDays.Text
                    End If
                    If txtFineday.Text = "" Then
                        ELBookREturn.DayFine = 0
                    Else
                        ELBookREturn.DayFine = txtFineday.Text
                    End If
                    If txtfine.Text = "" Then
                        ELBookREturn.Fine = 0
                    Else
                        ELBookREturn.Fine = txtfine.Text
                    End If
                    blbookreturn.UpdateRecord(ELBookREturn)
                    lblerrmsg.Text = ""
                    lblmsg.Text = "Data Submitted Successfully."
                    ViewState("PageIndex") = 0
                    GV_BookReturn.PageIndex = 0
                    displaySubmit()
                    clear()
                End If
            Catch ex As Exception
                lblerrmsg.Text = "Enter correct data."
            End Try
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If

    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        ELBookREturn.DeptId = ddlDept.SelectedValue
        ELBookREturn.Branch = ddlBranchType.SelectedValue
        If txtstuCode.Text = "" And rdbcode.SelectedValue = "1" Then
            lblerrmsg.Text = "Student Code field is mandatory."
            lblmsg.Text = ""
            GV_BookReturn.Visible = False
        ElseIf txtempcode.Text = "" And rdbcode.SelectedValue = "2" Then
            lblerrmsg.Text = "Employee Code field is mandatory."
            lblmsg.Text = ""
            GV_BookReturn.Visible = False
        Else
            lblerrmsg.Text = ""
            lblmsg.Text = ""
            GV_BookReturn.Visible = True
            ViewState("PageIndex") = 0
            GV_BookReturn.PageIndex = 0
            display()
        End If
    End Sub
    Protected Sub GV_BookReturn_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GV_BookReturn.PageIndexChanging
        GV_BookReturn.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GV_BookReturn.PageIndex
        display()
        GV_BookReturn.Visible = True
    End Sub
    Sub clear()
        'txtstuCode.Text = ""
        'txtstuname.Text = ""
        'txtempcode.Text = ""
        'txtempName.Text = ""
        txtbukname.Text = ""
        txtFineday.Text = ""
        txtDays.Text = ""
        cmbBookCode.ClearSelection()
        cmbBookCode.Items.Clear()
        txtduedate.Text = ""
        txtfine.Text = ""
        HIDEMPCODE.Value = 0
        HIDSTUCODE.Value = 0
        ELBookREturn.Branch = ddlBranchType.SelectedValue
        If rdbcode.SelectedValue = "1" Then
            Dim dt As New DataTable
            dt = blbookreturn.GetBookCodecombo(ELBookREturn)
            cmbBookCode.DataSource = dt
            cmbBookCode.DataBind()
        Else
            Dim dt As New DataTable
            dt = blbookreturn.GetBookCodecombo(ELBookREturn)
            cmbBookCode.DataSource = dt
            cmbBookCode.DataBind()
        End If
    End Sub
    Sub displaySubmit()
        ELBookREturn.Branch = ddlBranchType.SelectedValue
        ELBookREturn.id = 0
        ELBookREturn.Std_Emp = rdbcode.SelectedItem.Text
        If rdbcode.SelectedValue = 1 Then
            txtstuCode.Focus()
            ELBookREturn.EmpID = 0
            ELBookREturn.STD_ID = HIDSTUCODE.Value
        Else
            txtempcode.Focus()
            ELBookREturn.EmpID = HIDEMPCODE.Value
            ELBookREturn.STD_ID = 0
        End If
        GV_BookReturn.Enabled = True
        dt = blbookreturn.GetBookReturn(ELBookREturn)
        GV_BookReturn.DataSource = dt
        GV_BookReturn.DataBind()
        LinkButton.Focus()
        If rdbcode.SelectedValue = 1 Then
            GV_BookReturn.Columns(3).Visible = False
            GV_BookReturn.Columns(4).Visible = False
            GV_BookReturn.Columns(2).Visible = True
            GV_BookReturn.Columns(1).Visible = True
        Else
            GV_BookReturn.Columns(2).Visible = False
            GV_BookReturn.Columns(1).Visible = False
            GV_BookReturn.Columns(3).Visible = True
            GV_BookReturn.Columns(4).Visible = True
        End If
    End Sub
    Sub display()
        Try
            ELBookREturn.Branch = ddlBranchType.SelectedValue
            ELBookREturn.id = 0
            ELBookREturn.Std_Emp = rdbcode.SelectedItem.Text
            If rdbcode.SelectedValue = 1 Then
                ELBookREturn.EmpID = 0
                ELBookREturn.STD_ID = HIDSTUCODE.Value
            Else
                ELBookREturn.EmpID = HIDEMPCODE.Value
                ELBookREturn.STD_ID = 0
            End If
            GV_BookReturn.Enabled = True
            dt = blbookreturn.GetBookReturn(ELBookREturn)
            If dt.Rows.Count > 0 Then
                GV_BookReturn.DataSource = dt
                GV_BookReturn.DataBind()
                LinkButton.Focus()
                If rdbcode.SelectedValue = 1 Then
                    GV_BookReturn.Columns(3).Visible = False
                    GV_BookReturn.Columns(4).Visible = False
                    GV_BookReturn.Columns(2).Visible = True
                    GV_BookReturn.Columns(1).Visible = True
                Else
                    GV_BookReturn.Columns(2).Visible = False
                    GV_BookReturn.Columns(1).Visible = False
                    GV_BookReturn.Columns(3).Visible = True
                    GV_BookReturn.Columns(4).Visible = True
                End If

            Else
                lblmsg.Text = ""
                lblerrmsg.Text = "No records to display."
                GV_BookReturn.Visible = False
            End If
        Catch ex As Exception
            lblerrmsg.Text = ""
        End Try
    End Sub
    <System.Web.Services.WebMethod()> _
   Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
    Protected Sub rdbcode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdbcode.SelectedIndexChanged

        If rdbcode.SelectedValue = 1 Then
            txtstuCode.Focus()
            lblstucode.Visible = True
            txtstuCode.Visible = True
            lblstuname.Visible = True
            txtstuname.Visible = True
            lblempcode.Visible = False
            txtempcode.Visible = False
            lblempName.Visible = False
            txtempName.Visible = False
            GV_BookReturn.Visible = False
            lblmsg.Text = ""
            lblerrmsg.Text = ""
            clear()
        Else
            txtempcode.Focus()
            lblstucode.Visible = False
            txtstuCode.Visible = False
            lblstuname.Visible = False
            txtstuname.Visible = False
            lblempcode.Visible = True
            txtempcode.Visible = True
            lblempName.Visible = True
            txtempName.Visible = True
            GV_BookReturn.Visible = False
            lblmsg.Text = ""
            lblerrmsg.Text = ""
            clear()
        End If
    End Sub
    Protected Sub txtempcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtempcode.TextChanged
        ELBookREturn.DeptId = ddlDept.SelectedValue
        ELBookREturn.Branch = ddlBranchType.SelectedValue
        If HIDSTUCODE.Value = "" Then
            ELBookREturn.STD_ID = 0
            'lblerrmsg.Text = "Enter Valid Student Code."
            'lblmsg.Text = ""
            'Exit Sub
        Else
            ELBookREturn.STD_ID = HIDSTUCODE.Value
        End If

        If HIDEMPCODE.Value = "" Then
            ELBookREturn.EmpID = 0
            
        Else
            ELBookREturn.EmpID = HIDEMPCODE.Value
        End If
        If HIDEMPCODE.Value = 0 Then
            lblerrmsg.Text = "Enter Valid Employee Code."
            lblmsg.Text = ""
            Exit Sub
        End If
        Dim dt As New DataTable
        dt = blbookreturn.GetBookCodecombo(ELBookREturn)
        cmbBookCode.DataSource = dt
        cmbBookCode.DataBind()
    End Sub

    Protected Sub txtstuCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtstuCode.TextChanged
        ELBookREturn.DeptId = ddlDept.SelectedValue
        ELBookREturn.Branch = ddlBranchType.SelectedValue
        If HIDSTUCODE.Value = "" Then
            ELBookREturn.STD_ID = 0
            lblerrmsg.Text = "Enter Valid Student Code."
            lblmsg.Text = ""
            Exit Sub
        Else
            ELBookREturn.STD_ID = HIDSTUCODE.Value
        End If

        'If HIDEMPCODE.Value = "" Then
        '    ELBookREturn.EmpID = 0
        '    lblerrmsg.Text = "Enter Valid Employee Code."
        '    lblmsg.Text = ""
        '    Exit Sub
        'Else
        '    ELBookREturn.EmpID = HIDEMPCODE.Value
        'End If
        Dim dt As New DataTable
        dt = blbookreturn.GetBookCodecombo(ELBookREturn)
        cmbBookCode.DataSource = dt
        cmbBookCode.DataBind()
    End Sub
    Protected Sub cmbBookCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBookCode.SelectedIndexChanged
        If cmbBookCode.SelectedValue <> "Select" Then
            Try
                ELBookREturn.Branch = ddlBranchType.SelectedValue
                ELBookREturn.DeptId = ddlDept.SelectedValue
                ELBookREturn.BookCode = cmbBookCode.SelectedValue
                If rdbcode.SelectedValue = 1 Then
                    ELBookREturn.STD_ID = HIDSTUCODE.Value
                    ELBookREturn.EmpID = 0
                Else
                    ELBookREturn.STD_ID = 0
                    ELBookREturn.EmpID = HIDEMPCODE.Value
                End If
                ELBookREturn.BookID = cmbBookCode.SelectedValue


                dt = blbookreturn.GetBookName(ELBookREturn)
                If dt.Rows.Count > 0 Then
                    txtbukname.Text = dt.Rows(0).Item("BookName").ToString
                    ELBookREturn.BookCode = txtbukname.Text
                    Dim returnDate As Date = dt.Rows(0).Item("ReturnDate").ToString
                    txtduedate.Text = Format(returnDate, "dd-MMM-yyyy")
                Else
                    txtbukname.Text = ""
                End If
            Catch ex As Exception
                lblerrmsg.Text = "Please select valid book name."
                lblmsg.Text = ""
            End Try
        End If
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        txtreturndate.Text = Format(Date.Today, "dd-MMM-yyyy")
        txtstuCode.Focus()
        If txtstuCode.Text <> "" Then
            Splitter1(txtstuCode.Text)
        Else
            txtstuCode.AutoPostBack = True
            txtstuname.Text = ""
            Splitter1(txtstuCode.Text)
        End If
        If txtempcode.Text <> "" Then
            Splitter2(txtempcode.Text)
        Else
            txtempcode.AutoPostBack = True
            txtempName.Text = ""
            Splitter2(txtempcode.Text)
        End If
        If Not IsPostBack Then
            ddlBranchType.SelectedValue = Session("BranchCode")
        End If
    End Sub
    'Protected Sub GV_BookReturn_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GV_BookReturn.RowDeleting
    '    ELBookREturn.id = CType(GV_BookReturn.Rows(e.RowIndex).FindControl(""), Label).Text
    '    blbookreturn.ChangeFlag(ELBookREturn)
    '    GV_BookReturn.DataBind()
    '    lblmsg.Text = ""
    '    lblerrmsg.Text = "Data Deleted Successfully."
    '    clear()
    '    display()
    'End Sub

    'Protected Sub GV_BookReturn_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GV_BookReturn.RowEditing
    '    btnSave.Text = "ADD"
    '    btnDetails.Visible = True
    '    btnDetails.Text = "BACK"
    '    lblmsg.Text = ""
    '    lblerrmsg.Text = " "
    '    GV_BookReturn.Visible = True
    '    ViewState("ID") = CType(GV_BookReturn.Rows(e.NewEditIndex).FindControl("HID"), Label).Text
    '    txtstuCode.Text = CType(GV_BookReturn.Rows(e.NewEditIndex).FindControl("lblStucode"), Label).Text
    '    txtstuname.Text = CType(GV_BookReturn.Rows(e.NewEditIndex).FindControl("lblStuname"), Label).Text
    '    txtempcode.Text = CType(GV_BookReturn.Rows(e.NewEditIndex).FindControl("lblEmpcode"), Label).Text
    '    txtempName.Text = CType(GV_BookReturn.Rows(e.NewEditIndex).FindControl("lblEmpname"), Label).Text
    '    lblbukname.Text = CType(GV_BookReturn.Rows(e.NewEditIndex).FindControl("lblbukname"), Label).Text
    '    cmbBookCode.SelectedValue = CType(GV_BookReturn.Rows(e.NewEditIndex).FindControl("lblbukcode"), Label).Text
    '    txtduedate.Text = CType(GV_BookReturn.Rows(e.NewEditIndex).FindControl("lblduedate"), Label).Text
    '    txtreturndate.Text = CType(GV_BookReturn.Rows(e.NewEditIndex).FindControl("lblreturndate"), Label).Text
    '    txtfine.Text = CType(GV_BookReturn.Rows(e.NewEditIndex).FindControl("lblfine"), Label).Text
    '    ELBookREturn.id = ViewState("ID")
    '    dt = blbookreturn.GetBookReturn(ELBookREturn)
    '    GV_BookReturn.DataSource = dt
    '    GV_BookReturn.DataBind()
    '    GV_BookReturn.Enabled = False
    'End Sub

    ' End If

    'ElseIf btnSave.Text = "ADD" Then
    '    ELBookREturn.StudentCode = txtstuCode.Text
    '    ELBookREturn.StudentName = txtstuname.Text
    '    ELBookREturn.EmployeeCode = txtempcode.Text
    '    ELBookREturn.EmployeeName = txtempName.Text
    '    ELBookREturn.BookCode = ddlbookcode.
    '    ELBookREturn.BookName = lblbookname.Text
    '    ELBookREturn.DueDate = txtduedate.Text
    '    ELBookREturn.ReturnDate = txtreturndate.Text
    '    ELBookREturn.Fine = txtfine.Text
    '    dt = blbookreturn.CheckDuplicate(ELBookREturn)
    '    If dt.Rows.Count > 0 Then
    '        lblerrmsg.Text = "Data already Exists."
    '        lblmsg.Text = ""
    '        btnSave.Text = "ADD"
    '        btnDetails.Text = "VIEW"
    '        clear()
    '    Else
    '        ELBookREturn.StudentCode = txtstuCode.Text
    '        ELBookREturn.StudentName = txtstuname.Text
    '        ELBookREturn.EmployeeCode = txtempcode.Text
    '        ELBookREturn.EmployeeName = txtempName.Text
    '    ELBookREturn.BookCode = ddlbookcode.
    '        ELBookREturn.BookName = lblbookname.Text
    '        ELBookREturn.DueDate = txtduedate.Text
    '        ELBookREturn.ReturnDate = txtreturndate.Text
    '        ELBookREturn.Fine = txtfine.Text
    '        blbookreturn.InsertRecord(ELBookREturn)
    '        btnSave.Text = "ADD"
    '        lblerrmsg.Text = ""
    '        lblmsg.Text = "Data Saved Successfully."
    '        clear()

    '    display()
    'End If

    Protected Sub txtFineday_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFineday.TextChanged
        Try
            lblerrmsg.Text = ""
            lblmsg.Text = ""
            If txtDays.Text = "" Then
                ELBookREturn.Days = 0
            Else
                ELBookREturn.Days = txtDays.Text
            End If
            If txtFineday.Text = "" Then
                ELBookREturn.DayFine = 0
            Else
                ELBookREturn.DayFine = txtFineday.Text
            End If
            txtfine.Text = ELBookREturn.Days * ELBookREturn.DayFine
        Catch ex As Exception
            lblerrmsg.Text = "Please enter correct amount."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub ddlDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDept.SelectedIndexChanged
        'txtstuCode.Text = ""
        'txtstuname.Text = ""
        'txtempcode.Text = ""
        'txtempName.Text = ""
        txtbukname.Text = ""
        txtFineday.Text = ""
        txtDays.Text = ""
        cmbBookCode.ClearSelection()
        cmbBookCode.Items.Clear()
        txtduedate.Text = ""
        txtfine.Text = ""
        txtreturndate.Text = ""
        HIDEMPCODE.Value = 0
        HIDSTUCODE.Value = 0
    End Sub

    Protected Sub GV_BookReturn_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GV_BookReturn.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        Try
            ELBookREturn.id = 0
            ELBookREturn.Std_Emp = rdbcode.SelectedItem.Text
            If rdbcode.SelectedValue = 1 Then
                ELBookREturn.EmpID = 0
                ELBookREturn.STD_ID = HIDSTUCODE.Value
            Else
                ELBookREturn.EmpID = HIDEMPCODE.Value
                ELBookREturn.STD_ID = 0
            End If
            GV_BookReturn.Enabled = True
            dt = blbookreturn.GetBookReturn(ELBookREturn)
            If dt.Rows.Count > 0 Then
                Dim sortedView As New DataView(dt)
                sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
                GV_BookReturn.DataSource = sortedView
                GV_BookReturn.DataBind()
                LinkButton.Focus()
                If rdbcode.SelectedValue = 1 Then
                    GV_BookReturn.Columns(3).Visible = False
                    GV_BookReturn.Columns(4).Visible = False
                    GV_BookReturn.Columns(2).Visible = True
                    GV_BookReturn.Columns(1).Visible = True
                Else
                    GV_BookReturn.Columns(2).Visible = False
                    GV_BookReturn.Columns(1).Visible = False
                    GV_BookReturn.Columns(3).Visible = True
                    GV_BookReturn.Columns(4).Visible = True
                End If

            Else
                lblmsg.Text = ""
                lblerrmsg.Text = "No records to display."
                GV_BookReturn.Visible = False
            End If
        Catch ex As Exception
            lblerrmsg.Text = ""
        End Try
        
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
    Sub selection()
        If rdbcode.SelectedValue.ToString = "Employee" Then
            AutoCompleteExtender3.ServicePath = "TextBoxExt.asmx"
            AutoCompleteExtender3.ServiceMethod = "getEmpCodeExt1"
        ElseIf rdbcode.SelectedValue.ToString = "Student" Then
            AutoCompleteExtender1.ServicePath = "TextBoxExt.asmx"
            AutoCompleteExtender1.ServiceMethod = "getStudentIdName1"
        End If
    End Sub
End Class
