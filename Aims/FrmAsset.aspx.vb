Partial Class FrmAsset
    Inherits BasePage
    Dim AssetManager As New AssetManager
    Dim Asset As New AssetManager
    Dim Ast As New Asset
    Dim dt As New DataTable
    Sub Splitter(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("Asset_Id") = parts(0).ToString()
            ViewState("Asset_Id1") = parts(0).ToString()
            txtCode.Text = parts(0).ToString()
            txtAssetName.Text = parts(1).ToString()
            'HidECode.Value = parts(2).ToString()
            'ViewState("BookID") = BookID

        Else
            txtCode.AutoPostBack = True
        End If
    End Sub
    Sub Splitter1(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            HidECode.Value = parts(0).ToString()
            txtIssued.Text = parts(1).ToString()
            'txtEmpName.Text = parts(1).ToString()

            'ViewState("EmpID") = EmpID

        Else
            txtIssued.AutoPostBack = True
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        lblDept.Visible = False
        ddlDept.Visible = False
        If IsPostBack = False Then
            lblErrorMsg.Text = ""
            txtIssueDate.Text = Format(Today, "dd-MMM-yyyy")
            txtCode.Focus()
        End If
        If txtCode.Text <> "" Then
            Splitter(txtCode.Text)
        Else
            txtCode.AutoPostBack = True
            txtAssetName.Text = ""
            Splitter(txtCode.Text)
        End If
        If txtIssued.Text <> "" Then
            Splitter1(txtIssued.Text)
        Else
            txtIssued.AutoPostBack = True
            'txtEmpName.Text = ""
            Splitter1(txtIssued.Text)
        End If
        If RBReport.SelectedValue = 0 Then
            lblDept.Visible = False
            ddlDept.Visible = False
            lblIssue.Visible = True
            txtIssued.Visible = True
        Else
            lblIssue.Visible = False
            txtIssued.Visible = False
            lblDept.Visible = True
            ddlDept.Visible = True

        End If
    End Sub

    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        txtCode.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If btnsave.Text = "UPDATE" Then
                    RBReport.Enabled = True
                    Ast.Code = txtCode.Text
                    Ast.Name = txtAssetName.Text
                    Ast.Remarks = txtRemarks.Text
                    If (txtIssueDate.Text = "") Then
                        Ast.IssueDate = "#1/1/3000#"
                    Else
                        Ast.IssueDate = txtIssueDate.Text
                    End If
                    If txtIssueDate.Text > Date.Today Then
                        msginfo.Text = ""
                        lblErrorMsg.Text = "Issue Date should lesser than Current Date."

                        Exit Sub
                    End If

                    If RBReport.SelectedValue = 0 Then
                        Ast.depid = 0
                    Else
                        Ast.depid = ddlDept.SelectedValue
                    End If
                    Dim ID1 As Integer
                    If (txtReturndate.Text = "") Then
                        Ast.ReturnDate = "#1/1/3000#"
                        If RBReport.SelectedValue = 0 Then
                            ID1 = ViewState("Asset_IDAuto")
                        Else
                            ID1 = ViewState("Asset_IDAuto1")
                        End If

                        dt = AssetManager.GetDuplicate(ID1, Ast)

                        If dt.Rows.Count > 0 Then
                            lblErrorMsg.Visible = True
                            lblErrorMsg.Text = "Data already exists."
                            msginfo.Text = ""
                        Else
                            If RBReport.SelectedValue = 0 Then
                                Ast.Asset_ID = ViewState("Asset_ID")
                            Else
                                Ast.Asset_ID = ViewState("Asset_ID1")
                            End If

                            Ast.IssuedTo = HidECode.Value
                            AssetManager.UpdateRecord(Ast)
                            btnsave.Text = "ADD"
                            GridView1.DataBind()
                            GridView1.Visible = True
                            GridView2.DataBind()
                            GridView2.Visible = True
                            btndetails.Text = "VIEW"
                            msginfo.Visible = True
                            lblErrorMsg.Text = ""
                            msginfo.Text = "Data Updated Successfully."
                            btndetails.Text = "VIEW"
                            txtIssueDate.Text = Format(Today, "dd-MMM-yyyy")
                            clear()
                            GridView1.PageIndex = ViewState("PageIndex")
                            GridView2.PageIndex = ViewState("PageIndex")
                            display()
                        End If
                    Else
                        Dim ID2 As Integer
                        Ast.ReturnDate = txtReturndate.Text
                        If RBReport.SelectedValue = 0 Then
                            ID2 = ViewState("Asset_IDAuto")
                        Else
                            ID2 = ViewState("Asset_IDAuto1")
                        End If

                        dt = AssetManager.GetDuplicate(ID2, Ast)

                        If dt.Rows.Count > 0 Then
                            lblErrorMsg.Visible = True
                            lblErrorMsg.Text = "Data already exists."
                            msginfo.Text = ""
                        Else
                            If (CDate(txtIssueDate.Text) > CDate(txtReturndate.Text)) Then
                                lblErrorMsg.Text = " Return date should be greater than Issued date. "
                                txtReturndate.Focus()
                                msginfo.Text = ""
                            Else
                                If RBReport.SelectedValue = 0 Then
                                    Ast.Asset_ID = ViewState("Asset_ID")
                                Else
                                    Ast.Asset_ID = ViewState("Asset_ID1")
                                End If

                                Ast.IssuedTo = HidECode.Value
                                AssetManager.UpdateRecord(Ast)
                                btnsave.Text = "ADD"
                                GridView1.DataBind()
                                GridView1.Visible = True
                                GridView2.DataBind()
                                GridView2.Visible = True
                                btndetails.Text = "VIEW"
                                msginfo.Visible = True
                                lblErrorMsg.Text = ""
                                msginfo.Text = "Data Updated Successfully."
                                btndetails.Text = "VIEW"
                                txtIssueDate.Text = Format(Today, "dd-MMM-yyyy")
                                clear()
                                GridView1.PageIndex = ViewState("PageIndex")
                                display()
                            End If
                        End If
                    End If
                ElseIf btnsave.Text = "ADD" Then

                    Ast.Code = txtCode.Text
                    Ast.Name = txtAssetName.Text
                    Ast.Remarks = txtRemarks.Text

                    If (txtIssueDate.Text = "") Then
                        Ast.IssueDate = "#1/1/3000#"
                    Else
                        Ast.IssueDate = txtIssueDate.Text
                    End If

                    If RBReport.SelectedValue = 0 Then
                        Ast.IssuedTo = HidECode.Value
                        Ast.depid = 0
                    Else
                        If ddlDept.SelectedValue = 0 Then
                            lblErrorMsg.Text = "Department Field is mandatory."
                            msginfo.Text = ""
                            Exit Sub
                        Else
                            Ast.depid = ddlDept.SelectedValue
                            Ast.IssuedTo = ""
                        End If

                    End If
                    Dim ID1 As Integer
                    If (txtReturndate.Text = "") Then
                        Ast.ReturnDate = "#1/1/3000#"
                        If RBReport.SelectedValue = 0 Then
                            ID1 = ViewState("Asset_IDAuto")
                        Else
                            ID1 = ViewState("Asset_IDAuto1")
                        End If


                        dt = AssetManager.GetDuplicate(ID1, Ast)

                        If dt.Rows.Count > 0 Then
                            lblErrorMsg.Visible = True
                            lblErrorMsg.Text = "Data already exists."
                            msginfo.Text = ""
                            btnsave.Text = "ADD"
                            btndetails.Text = "VIEW"
                        Else
                            AssetManager.InsertRecord(Ast)
                            btnsave.Text = "ADD"
                            lblErrorMsg.Text = ""
                            msginfo.Visible = True
                            msginfo.Text = "Data saved Successfully."
                            clear()
                            ViewState("PageIndex") = 0
                            GridView1.PageIndex = 0
                            display()
                        End If
                    Else
                        Ast.ReturnDate = txtReturndate.Text
                        If (CDate(txtIssueDate.Text) > CDate(txtReturndate.Text)) Then
                            lblErrorMsg.Text = "  Return date should be greater than Issued date."
                            txtReturndate.Focus()
                            msginfo.Text = ""
                        Else
                            Dim ID2 As Integer
                            If RBReport.SelectedValue = 0 Then
                                ID2 = ViewState("Asset_IDAuto")
                            Else
                                ID2 = ViewState("Asset_IDAuto1")
                            End If

                            dt = AssetManager.GetDuplicate(ID2, Ast)
                            If dt.Rows.Count > 0 Then
                                lblErrorMsg.Visible = True
                                lblErrorMsg.Text = "Data already exists."
                                msginfo.Text = ""
                                btnsave.Text = "ADD"
                                btndetails.Text = "VIEW"
                            Else
                                AssetManager.InsertRecord(Ast)
                                btnsave.Text = "ADD"
                                lblErrorMsg.Text = ""
                                msginfo.Visible = True
                                msginfo.Text = "Data saved Successfully."
                                clear()
                                ViewState("PageIndex") = 0
                                GridView1.PageIndex = 0
                                display()
                            End If
                        End If
                    End If
                End If
            Catch ex As Exception
                lblErrorMsg.Text = "Enter correct date."
                msginfo.Text = ""
            End Try
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
            msginfo.Text = ""
        End If

    End Sub
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click
        txtCode.Focus()
        RBReport.Enabled = True
        If btndetails.Text = "VIEW" Then
            txtIssueDate.Text = Format(Today, "dd-MMM-yyyy")
            lblErrorMsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            display()
        ElseIf btndetails.Text = "BACK" Then
            btnsave.Text = "ADD"
            btndetails.Text = "VIEW"
            clear()
            GridView1.PageIndex = ViewState("PageIndex")
            display()
            lblErrorMsg.Text = ""
            msginfo.Text = ""
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        display()
        GridView1.Visible = True
        lblErrorMsg.Visible = False
        GridView1.Columns(1).Visible = True
    End Sub
    Sub display()
        Dim dt As New DataTable
        If txtAssetName.Text = "" Then
            Ast.Name = 0
        Else
            Ast.Name = txtAssetName.Text
        End If
        If txtIssued.Text = "" Then
            Ast.IssuedTo = 0
        Else
            Ast.IssuedTo = HidECode.Value
        End If
        If RBReport.SelectedValue = 0 Then
            Ast.Asset_ID = ViewState("Asset_ID")
        Else
            Ast.Asset_ID = ViewState("Asset_ID1")
        End If

        Ast.Asset_ID = 0
        GridView1.Enabled = True
        GridView1.Visible = True
        Ast.depid = RBReport.SelectedValue
        dt = AssetManager.GetCommName(Ast)
        If dt.Rows.Count > 0 Then
            If RBReport.SelectedValue = 0 Then
                GridView2.Visible = False
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Enabled = True
                GridView1.Visible = True
                For Each rows As GridViewRow In GridView1.Rows
                    If CType(rows.FindControl("lblIssuedate"), Label).Text = "01-Jan-3000" Then
                        CType(rows.FindControl("lblIssuedate"), Label).Text = ""
                    End If
                Next
                For Each rows As GridViewRow In GridView1.Rows
                    If CType(rows.FindControl("lblReturndate"), Label).Text = "01-Jan-3000" Then
                        CType(rows.FindControl("lblReturndate"), Label).Text = ""
                    End If
                Next
                L1.Focus()
            Else
                GridView1.Visible = False
                GridView2.DataSource = dt
                GridView2.DataBind()
                GridView2.Enabled = True
                GridView2.Visible = True
                For Each rows As GridViewRow In GridView2.Rows
                    If CType(rows.FindControl("lblIssuedate"), Label).Text = "01-Jan-3000" Then
                        CType(rows.FindControl("lblIssuedate"), Label).Text = ""
                    End If
                Next
                For Each rows As GridViewRow In GridView2.Rows
                    If CType(rows.FindControl("lblReturndate"), Label).Text = "01-Jan-3000" Then
                        CType(rows.FindControl("lblReturndate"), Label).Text = ""
                    End If
                Next
                L1.Focus()
            End If

        Else
            msginfo.Text = ""
            GridView1.Visible = False
            GridView2.Visible = False
            lblErrorMsg.Text = "No records to display."
            lblErrorMsg.Visible = True
        End If
        'GridView1.Enabled = True

    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Asset_ID") = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("RRID"), Label).Text
            Ast.Asset_ID = ViewState("Asset_ID")
            AssetManager.ChangeFlag(Ast.Asset_ID)
            GridView1.DataBind()
            lblErrorMsg.Text = ""
            msginfo.Text = "Data Deleted Successfully."
            txtCode.Focus()
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.PageIndex = ViewState("PageIndex")
            If txtAssetName.Text = "" Then
                Ast.Name = 0
            Else
                Ast.Name = txtAssetName.Text
            End If
            If txtIssued.Text = "" Then
                Ast.IssuedTo = 0
            Else
                Ast.IssuedTo = HidECode.Value
            End If
            Ast.Asset_ID = 0
            GridView1.Enabled = True
            GridView1.Visible = True
            Ast.depid = 0
            dt = AssetManager.GetCommName(Ast)

            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblIssuedate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblIssuedate"), Label).Text = ""
                End If
            Next
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblReturndate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblReturndate"), Label).Text = ""
                End If
            Next
            clear()
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            msginfo.Text = ""
        End If

    End Sub
    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Asset_ID1") = CType(GridView2.Rows(e.RowIndex).Cells(1).FindControl("RRID"), Label).Text
            Ast.Asset_ID = ViewState("Asset_ID1")
            AssetManager.ChangeFlag(Ast.Asset_ID)
            GridView2.DataBind()
            lblErrorMsg.Text = ""
            msginfo.Text = "Data Deleted Successfully."
            txtCode.Focus()
            GridView2.Visible = True
            GridView2.Enabled = True
            GridView2.PageIndex = ViewState("PageIndex")
            If txtAssetName.Text = "" Then
                Ast.Name = 0
            Else
                Ast.Name = txtAssetName.Text
            End If

            Ast.Asset_ID = 0
            GridView2.Enabled = True
            GridView2.Visible = True
            Ast.depid = 1
            Ast.IssuedTo = 0
            dt = AssetManager.GetCommName(Ast)

            GridView2.DataSource = dt
            GridView2.DataBind()
            GridView2.Enabled = True
            GridView2.Visible = True
            For Each rows As GridViewRow In GridView2.Rows
                If CType(rows.FindControl("lblIssuedate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblIssuedate"), Label).Text = ""
                End If
            Next
            For Each rows As GridViewRow In GridView2.Rows
                If CType(rows.FindControl("lblReturndate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblReturndate"), Label).Text = ""
                End If
            Next
            clear()
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            msginfo.Text = ""
        End If

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        RBReport.Enabled = False
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        msginfo.Text = ""
        lblErrorMsg.Text = ""
        txtCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text.Trim
        txtAssetName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        txtRemarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        txtIssued.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCommodityName"), Label).Text.Trim
        txtIssueDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblIssuedate"), Label).Text
        txtReturndate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblReturndate"), Label).Text
        'ddlAsstType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRID"), Label).Text
        ViewState("Asset_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("RRID"), Label).Text
        ViewState("Asset_IDAuto") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
        'ddlDept.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDeptId"), Label).Text
        btnsave.Text = "UPDATE"
        btndetails.Text = "BACK"
        Ast.Asset_ID = ViewState("Asset_ID")
        DisplayEdit()
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'msginfo.Text = ""
        'End If
        'btndetails.Visible = True
    End Sub
    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        RBReport.Enabled = False
        msginfo.Text = ""
        lblErrorMsg.Text = ""
        txtCode.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text.Trim
        txtAssetName.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        txtRemarks.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        'txtIssued.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblCommodityName"), Label).Text.Trim
        txtIssueDate.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblIssuedate"), Label).Text
        txtReturndate.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblReturndate"), Label).Text
        'ddlAsstType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRID"), Label).Text
        ViewState("Asset_ID1") = CType(GridView2.Rows(e.NewEditIndex).FindControl("RRID"), Label).Text
        ViewState("Asset_IDAuto1") = CType(GridView2.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
        'HidECode.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEmpCode"), Label).Text
        ddlDept.SelectedValue = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblDeptId"), Label).Text
        btnsave.Text = "UPDATE"
        btndetails.Text = "BACK"
        Ast.Asset_ID = ViewState("Asset_ID1")
        DisplayEdit1()
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'msginfo.Text = ""
        'End If
        'btndetails.Visible = True
    End Sub
    Sub DisplayEdit()
        Ast.Name = 0
        Ast.IssuedTo = 0
        Dim dt As New DataTable
        dt = AssetManager.GetCommName(Ast)
        GridView1.DataSource = dt
        GridView1.DataBind()
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblIssuedate"), Label).Text = "01-Jan-3000" Then
                CType(rows.FindControl("lblIssuedate"), Label).Text = ""
            End If
        Next
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblReturndate"), Label).Text = "01-Jan-3000" Then
                CType(rows.FindControl("lblReturndate"), Label).Text = ""
            End If
        Next
        GridView1.Enabled = False
    End Sub
    Sub DisplayEdit1()
        Ast.Name = 0
        Ast.IssuedTo = 0
        Ast.depid = RBReport.SelectedValue
        Dim dt As New DataTable
        dt = AssetManager.GetCommName(Ast)
        GridView2.DataSource = dt
        GridView2.DataBind()
        For Each rows As GridViewRow In GridView2.Rows
            If CType(rows.FindControl("lblIssuedate"), Label).Text = "01-Jan-3000" Then
                CType(rows.FindControl("lblIssuedate"), Label).Text = ""
            End If
        Next
        For Each rows As GridViewRow In GridView2.Rows
            If CType(rows.FindControl("lblReturndate"), Label).Text = "01-Jan-3000" Then
                CType(rows.FindControl("lblReturndate"), Label).Text = ""
            End If
        Next
        GridView2.Enabled = False
        GridView2.Visible = True
    End Sub
    Protected Function GetAssetType(ByVal id As Long) As String
        Dim AT As New AssetTypeB
        Dim Ast As AssetType = AT.GetAssetTypeById(id)
        Return Ast.Name
    End Function
    Protected Function GetCommType(ByVal id As Asset) As Data.DataTable
        Return AssetDB.GetCommName(Ast)
    End Function
    Sub Enable()
        GridView1.Enabled = True
        btndetails.Visible = True
    End Sub
    Sub Disable()
        GridView1.Enabled = False
        btndetails.Visible = False
    End Sub
    Sub clear()
        txtAssetName.Text = ""
        txtCode.Text = ""
        txtRemarks.Text = ""
        txtIssued.Text = ""
        'txtIssueDate.Text = ""
        txtReturndate.Text = ""
        'ddlAsstType.SelectedItem.Selected = False
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
        Dim dt As New DataTable
        If txtAssetName.Text = "" Then
            Ast.Name = 0
        Else
            Ast.Name = txtAssetName.Text
        End If
        If txtIssued.Text = "" Then
            Ast.IssuedTo = 0
        Else
            Ast.IssuedTo = HidECode.Value
        End If
        Ast.Asset_ID = ViewState("Asset_ID")
        Ast.Asset_ID = 0
        dt = AssetManager.GetCommName(Ast)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Visible = True
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
        Dim dt As New DataTable
        If txtAssetName.Text = "" Then
            Ast.Name = 0
        Else
            Ast.Name = txtAssetName.Text
        End If

        Ast.Asset_ID = ViewState("Asset_ID1")
        Ast.Asset_ID = 0
        dt = AssetManager.GetCommName(Ast)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView2.DataSource = sortedView
        GridView2.DataBind()
        GridView2.Enabled = True
        GridView2.Visible = True
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

    Protected Sub RBReport_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBReport.SelectedIndexChanged
        msginfo.Text = ""
        lblErrorMsg.Text = ""
        GridView1.Visible = False
        GridView2.Visible = False
        If RBReport.SelectedValue = 0 Then
            lblDept.Visible = False
            ddlDept.Visible = False
            lblIssue.Visible = True
            txtIssued.Visible = True
        Else
            lblIssue.Visible = False
            txtIssued.Visible = False
            lblDept.Visible = True
            ddlDept.Visible = True

        End If
    End Sub
End Class
