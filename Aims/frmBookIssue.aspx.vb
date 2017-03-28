
Partial Class frmBookIssue
    Inherits BasePage
    Dim empno, stdno, BookID As Int64
    'Dim BAL As New BookIssueB
    Dim GlobalFunction As New GlobalFunction
    Dim ELIssue As New BookIssue
    Dim DLIssue As New BookIssueDB
    Dim BLIssue As New BookIssueB
    'Dim StdID As Integer
    'Dim EmpID As Integer
    Dim dt As New DataTable
    Sub Splitter(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("BookCode") = parts(0).ToString()
            txtBookCode.Text = parts(0).ToString()
            txtBookName.Text = parts(1).ToString()
            BookID = parts(2).ToString()
            ViewState("BookID") = BookID
        Else
            txtBookCode.AutoPostBack = True
        End If
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
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        ELIssue.Branch = ddlBranchType.SelectedValue
        ELIssue.Dept = ddlDept.SelectedValue
        If btnDetails.Text = "BACK" Then
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            lblMsg.Text = ""
            lblErrorMsg.Text = ""
            GVBookIssue.PageIndex = ViewState("PageIndex")
            DispGrid(0)
            'GVBookIssue.Visible = True
            clear()
        Else
            If txtStdCode.Text = "" And RBUsers.SelectedValue = "Student" Then
                lblErrorMsg.Text = "Please enter Student Code."
                lblMsg.Text = ""
                txtStdCode.Focus()
            ElseIf txtEmpCode.Text = "" And RBUsers.SelectedValue = "Employee" Then
                'clear()
                lblErrorMsg.Text = "Please enter Employee Code."
                lblMsg.Text = ""
                txtEmpCode.Focus()
            Else
                'clear()
                GVBookIssue.Visible = True
                ViewState("PageIndex") = 0
                GVBookIssue.PageIndex = 0
                DispGrid(0)
            End If
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                ELIssue.Dept = ddlDept.SelectedValue
                lblErrorMsg.Text = ""
                lblMsg.Text = ""
                If txtDueDate.Text = "" Then
                    lblErrorMsg.Text = "Due date Field is Mandatory."

                ElseIf RBUsers.SelectedValue = "Student" Then
                    'txtStdCode.Focus()
                    'ELIssue.StdCode = HidstdId.Value.Replace(",", "")
                    'ELIssue.StdName = txtStdName.Text
                    'ELIssue.StdCode = ViewState("StdID")
                    If StdID.Value = "" Then
                        lblErrorMsg.Text = "Please Enter Correct Student code."
                        txtStdCode.Focus()
                        lblMsg.Text = ""
                        Exit Sub
                    End If
                    ELIssue.StdCode = StdID.Value
                    ELIssue.EmpCode = 0
                    ELIssue.Branch = ddlBranchType.SelectedValue

                Else
                    'txtEmpCode.Focus()
                    'ELIssue.EmpCode = HidEmp.Value.Replace(",", "")
                    'ELIssue.EmpName = txtEmpName.Text
                    'ELIssue.EmpCode = ViewState("EmpID")
                    If EmpId.Value = "" Then
                        lblErrorMsg.Text = "Please Enter Correct Employee code."
                        lblMsg.Text = ""
                        txtEmpCode.Focus()
                        Exit Sub
                    End If
                    ELIssue.EmpCode = EmpId.Value
                    ELIssue.StdCode = 0
                    End If
                    'ELIssue.BookCode = HidBook.Value.Replace(",", "")
                ELIssue.BookCode = ViewState("BookID")
                    ELIssue.BookName = txtBookName.Text
                    ELIssue.Issuedate = txtIssueDate.Text
                    If txtDueDate.Text = "__-___-____" Then
                        ELIssue.Returndate = "01/01/1900"
                    Else
                        ELIssue.Returndate = txtDueDate.Text
                    End If
                    ELIssue.Std_Emp = RBUsers.SelectedValue
                    ELIssue.id = ViewState("ID")
                    If btnSave.Text = "UPDATE" Then
                        'If CDate(txtDueDate.Text) >= CDate(txtIssueDate.Text) Then
                        If txtBookName.Text = "" Then
                            lblErrorMsg.Text = "Enter valid book code."
                        Else
                            If ELIssue.Returndate >= ELIssue.Issuedate Then
                                BLIssue.UpdateRecord(ELIssue)
                                lblErrorMsg.Text = ""
                                lblMsg.Text = "Data updated successfully."
                                clear()
                                GVBookIssue.PageIndex = ViewState("PageIndex")
                                DispGrid(0)
                                GVBookIssue.Visible = True
                                btnSave.Text = "ADD"
                                btnDetails.Text = "VIEW"
                                txtIssueDate.Text = Format(Date.Today, "dd-MMM-yyyy")
                            Else
                                lblErrorMsg.Text = "Due date cannot be less than Issue date."
                                lblMsg.Text = ""
                                txtDueDate.Focus()
                            End If
                        End If
                    ElseIf btnSave.Text = "ADD" Then
                        If RBUsers.SelectedValue = "Employee" Then
                            If txtEmpCode.Text = "" Then
                                lblErrorMsg.Text = "Employee Code Field is Mandatory."
                                lblMsg.Text = ""
                            Else
                                If txtBookCode.Text = "" Then
                                    lblErrorMsg.Text = "Book Code  Field is Mandatory."
                                Else
                                    If txtDueDate.Text = "" Then
                                        lblErrorMsg.Text = "Due date Field is Mandatory."
                                    Else
                                        Dim duplicate As New DataTable
                                        duplicate = BLIssue.duplicate(ELIssue)
                                        If duplicate.Rows.Count > 0 Then
                                            lblErrorMsg.Text = "Book already issued."
                                        Else
                                            'If CDate(txtDueDate.Text) >= CDate(txtIssueDate.Text) Then
                                            If ELIssue.Returndate >= ELIssue.Issuedate Then
                                                BLIssue.InsertRecord(ELIssue)
                                                lblErrorMsg.Text = ""
                                                btnSave.Text = "ADD"
                                                lblMsg.Text = "Data saved successfully."
                                                clear()
                                                ViewState("PageIndex") = 0
                                                GVBookIssue.PageIndex = 0
                                                DispGrid(0)
                                                GVBookIssue.Visible = True
                                                txtIssueDate.Text = Format(Date.Today, "dd-MMM-yyyy")
                                            Else
                                                lblErrorMsg.Text = "Due date cannot be less than Issue date."
                                                lblMsg.Text = ""
                                                txtDueDate.Focus()
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        Else
                            Dim duplicate As New DataTable
                            duplicate = BLIssue.duplicate(ELIssue)
                            If duplicate.Rows.Count > 0 Then
                                lblErrorMsg.Text = "Book already issued."
                            Else
                                If ELIssue.Returndate >= ELIssue.Issuedate Then
                                    BLIssue.InsertRecord(ELIssue)
                                    lblErrorMsg.Text = ""
                                    btnSave.Text = "ADD"
                                    lblMsg.Text = "Data saved successfully."
                                    clear()
                                    ViewState("PageIndex") = 0
                                    GVBookIssue.PageIndex = 0
                                    DispGrid(0)
                                    GVBookIssue.Visible = True
                                    txtIssueDate.Text = Format(Date.Today, "dd-MMM-yyyy")
                                Else
                                    lblErrorMsg.Text = "Due date cannot be less than Issue date."
                                    lblMsg.Text = ""
                                    txtDueDate.Focus()
                                End If
                            End If
                        End If
                    End If
            Catch ex As Exception
                lblErrorMsg.Text = "Enter correct data."
                lblMsg.Text = ""
            End Try
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblMsg.Text = ""
        End If
    End Sub
    Sub clear()
        HidBook.Value = 0
        'txtStdCode.Text = ""
        'txtStdName.Text = ""
        txtBookCode.Text = ""
        txtBookName.Text = ""
        'txtIssueDate.Text = ""
        txtDueDate.Text = ""
    End Sub
    Sub Enable()
    End Sub

    Protected Sub GVBookIssue_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVBookIssue.PageIndexChanging
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        GVBookIssue.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVBookIssue.PageIndex
        DispGrid(0)
        GVBookIssue.Visible = True
        GVBookIssue.Columns(1).Visible = True
    End Sub
    Protected Sub GVBookIssue_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVBookIssue.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        Dim dt As New DataTable

        HidBook.Value = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("BID"), HiddenField).Value
        ViewState("BookID") = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("BID"), HiddenField).Value
        txtBookCode.Text = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblBookCode"), Label).Text
        ViewState("BookCode") = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblBookCode"), Label).Text
        txtBookName.Text = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblBookName"), Label).Text
        txtIssueDate.Text = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblIssueDate"), Label).Text
        txtDueDate.Text = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblReturnDate"), Label).Text
        ViewState("DeptName") = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblDeptid"), Label).Text
        If RBUsers.SelectedValue = "Student" Then
            HidstdId.Value = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("StdHidden"), HiddenField).Value
            'ViewState("StdID") = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("StdHidden"), HiddenField).Value
            StdID.Value = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("StdHidden"), HiddenField).Value
            txtStdCode.Text = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblStuCode"), Label).Text
            ViewState("StdCode") = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblStuCode"), Label).Text
            txtStdName.Text = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblStuName"), Label).Text
            ViewState("ID") = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblID"), Label).Text
        Else
            HidEmp.Value = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("EmpIdHidden"), HiddenField).Value
            'ViewState("EmpID") = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("EmpIdHidden"), HiddenField).Value
            EmpId.Value = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("EmpIdHidden"), HiddenField).Value
            txtEmpCode.Text = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblEmpCode"), Label).Text
            ViewState("EmpCode") = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblEmpCode"), Label).Text
            txtEmpName.Text = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblEmpName"), Label).Text
            ViewState("ID") = CType(GVBookIssue.Rows(e.NewEditIndex).FindControl("lblIDEmp"), Label).Text
        End If
        btnSave.Text = "UPDATE"
        btnDetails.Text = "BACK"
        ELIssue.id = ViewState("ID")
        ELIssue.Std_Emp = RBUsers.SelectedValue
        dt = BLIssue.DisplayByID(ELIssue)
        GVBookIssue.DataSource = dt
        GVBookIssue.DataBind()
        GVBookIssue.Enabled = False
        GVBookIssue.Visible = True

        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblMsg.Text = ""
        'End If

    End Sub
    Public Sub DispGrid(ByVal a As Integer)
        Try
            Dim dt As New DataTable
            ELIssue.Std_Emp = RBUsers.SelectedValue
            ELIssue.Branch = ddlBranchType.SelectedValue
            If RBUsers.SelectedValue = "Student" Then
                ELIssue.Empid = 0
                ' ELIssue.Stdid = ViewState("StdID")
                ELIssue.Stdid = StdID.Value
            Else
                'ELIssue.Empid = ViewState("EmpID")
                ELIssue.Empid = EmpId.Value
                ELIssue.Stdid = 0
            End If
            ELIssue.id = a
            GVBookIssue.Enabled = True
            dt = BLIssue.Display(ELIssue)
            If dt.Rows.Count > 0 Then
                GVBookIssue.DataSource = dt
                GVBookIssue.DataBind()
                GVBookIssue.Visible = True
                LinkButton.Focus()
                If RBUsers.SelectedValue = "Student" Then
                    GVBookIssue.Columns(5).Visible = False
                    GVBookIssue.Columns(4).Visible = False
                    GVBookIssue.Columns(3).Visible = True
                    GVBookIssue.Columns(2).Visible = True
                Else
                    GVBookIssue.Columns(5).Visible = True
                    GVBookIssue.Columns(4).Visible = True
                    GVBookIssue.Columns(3).Visible = False
                    GVBookIssue.Columns(2).Visible = False

                End If
            Else
                lblErrorMsg.Text = "No records to display."
                lblMsg.Text = ""
                GVBookIssue.Visible = False
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct data."
        End Try
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBUsers.SelectedIndexChanged
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        If RBUsers.SelectedValue = "Student" Then
            'txtStdCode.Focus()
            lblStdCode.Visible = True
            txtStdCode.Visible = True
            lblStdName.Visible = True
            txtStdName.Visible = True
            lblBook.Visible = True
            txtBookCode.Visible = True
            lblBookName.Visible = True
            txtBookName.Visible = True
            lblIssue.Visible = True
            txtIssueDate.Visible = True
            lblReturn.Visible = True
            txtDueDate.Visible = True
            lblEmpCode.Visible = False
            txtEmpCode.Visible = False
            lblEmpName.Visible = False
            txtEmpName.Visible = False
            GVBookIssue.Visible = False
            txtStdCode.Text = ""
            txtStdName.Text = ""
            txtEmpCode.Text = ""
            txtEmpName.Text = ""
            txtBookCode.Text = ""
            txtBookName.Text = ""
            txtDueDate.Text = ""
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
        Else
            'txtEmpCode.Focus()
            lblStdCode.Visible = False
            txtStdCode.Visible = False
            lblStdName.Visible = False
            txtStdName.Visible = False
            lblBook.Visible = True
            txtBookCode.Visible = True
            lblBookName.Visible = True
            txtBookName.Visible = True
            lblIssue.Visible = True
            txtIssueDate.Visible = True
            lblReturn.Visible = True
            txtDueDate.Visible = True
            lblEmpCode.Visible = True
            txtEmpCode.Visible = True
            lblEmpName.Visible = True
            txtEmpName.Visible = True
            GVBookIssue.Visible = False
            txtStdCode.Text = ""
            txtStdName.Text = ""
            txtEmpCode.Text = ""
            txtEmpName.Text = ""
            txtBookCode.Text = ""
            txtBookName.Text = ""
            txtDueDate.Text = ""
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtIssueDate.Text = Format(Date.Today, "dd-MMM-yyyy")
            Session("Dept") = 0
        End If
        If RBUsers.SelectedValue = "Student" Then
            txtBookCode.Focus()
            lblEmpCode.Visible = False
            txtEmpCode.Visible = False
            lblEmpName.Visible = False
            txtEmpName.Visible = False
        Else
            'txtEmpCode.Focus()
            lblStdCode.Visible = False
            txtStdCode.Visible = False
            lblStdName.Visible = False
            txtStdName.Visible = False
        End If
        If txtBookCode.Text <> "" Then
            Splitter(txtBookCode.Text)
        Else
            txtBookCode.AutoPostBack = True
            txtBookName.Text = ""
            Splitter(txtBookCode.Text)
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
        If (Session("BookName") <> Nothing) Then
            txtBookName.Text = Session("BookName")
            txtBookCode.Text = Session("BookCode")
            ViewState("BookID") = Session("Book_IDAuto")
            Session("Book_IDAuto") = ""
            Session("BookName") = ""
            Session("BookCode") = ""

        End If
        If Not IsPostBack Then
            ddlBranchType.SelectedValue = Session("BranchCode")
        End If
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Book Issue")
    End Sub

    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
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

    Protected Sub txtBookCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBookCode.TextChanged
        Dim BookCode As String = txtBookCode.Text
        dt = BLIssue.GetBookNameExt(BookCode)
        If dt.Rows.Count > 0 Then
            If txtBookCode.Text = "" Then
                txtBookName.Text = ""
            Else
                txtBookName.Text = dt.Rows(0).Item("BookName")
                ViewState("BookID") = dt.Rows(0).Item("Book_IDAuto")
                lblErrorMsg.Text = ""
            End If
        Else
            txtBookName.Text = ""
            lblErrorMsg.Text = "Enter valid book code."
            lblMsg.Text = ""
        End If
    End Sub

    Protected Sub txtEmpCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpCode.TextChanged
        If txtEmpCode.Text = "" Then
            txtEmpName.Text = ""
        End If
        GVBookIssue.Visible = False
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        If EmpId.Value = "" Then
            lblErrorMsg.Text = "Enter Valid Employee Code."
            lblMsg.Text = ""
            Exit Sub
        End If
    End Sub

    Protected Sub txtStdCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStdCode.TextChanged
        If txtStdCode.Text = "" Then
            txtStdName.Text = ""
        End If
        GVBookIssue.Visible = False
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        If StdID.Value = "" Then
            lblErrorMsg.Text = "Enter Valid Student Code."
            lblMsg.Text = ""
            Exit Sub
        End If
    End Sub

    Protected Sub ddlDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDept.SelectedIndexChanged
        Session("Dept") = ddlDept.SelectedValue
        ddlDept.Focus()
        txtBookCode.Text = ""
        txtBookName.Text = ""
    End Sub

    Protected Sub GVBookIssue_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVBookIssue.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        Try
            Dim dt As New DataTable
            ELIssue.Std_Emp = RBUsers.SelectedValue
            If RBUsers.SelectedValue = "Student" Then
                ELIssue.Empid = 0
                ' ELIssue.Stdid = ViewState("StdID")
                ELIssue.Stdid = StdID.Value
            Else
                'ELIssue.Empid = ViewState("EmpID")
                ELIssue.Empid = EmpId.Value
                ELIssue.Stdid = 0
            End If
            ELIssue.id = 0
            GVBookIssue.Enabled = True
            dt = BLIssue.Display(ELIssue)
            If dt.Rows.Count > 0 Then
                Dim sortedView As New DataView(dt)
                sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
                GVBookIssue.DataSource = sortedView
                GVBookIssue.DataBind()
                GVBookIssue.Visible = True
                LinkButton.Focus()
                If RBUsers.SelectedValue = "Student" Then
                    GVBookIssue.Columns(5).Visible = False
                    GVBookIssue.Columns(4).Visible = False
                    GVBookIssue.Columns(3).Visible = True
                    GVBookIssue.Columns(2).Visible = True
                Else
                    GVBookIssue.Columns(5).Visible = True
                    GVBookIssue.Columns(4).Visible = True
                    GVBookIssue.Columns(3).Visible = False
                    GVBookIssue.Columns(2).Visible = False

                End If
            Else
                lblErrorMsg.Text = "No records to display."
                lblMsg.Text = ""
                GVBookIssue.Visible = False
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct data."
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
End Class
