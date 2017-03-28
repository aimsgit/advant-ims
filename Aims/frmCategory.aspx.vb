
Partial Class frmDepreciation_Rates
    Inherits BasePage
    Dim CategoryManager As New CategoryManager
    Dim Category As New Category
    Dim dt As New DataTable
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        cmbDept.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim Category As New Category
            If BtnSave.CommandName = "UPDATE" Then
                Category.CategoryId = txtID.Text
                Category.CategoryName = txtName.Text
                Category.DeptId = cmbDept.SelectedValue
                dt = CategoryManager.CheckDuplicate(Category)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                    'clear()
                Else
                    CategoryManager.UpdateRecord(Category)
                    BtnSave.CommandName = "ADD"
                    BtnSave.Text = "ADD"
                    clear()
                    GridView1.DataBind()
                    Enable()
                    GridView1.Visible = True
                    'msginfo.Text = " "
                    'lblmsg.Visible = True

                    BtnDetails.CommandName = "VIEW"
                    BtnDetails.Text = "VIEW"
                    lblmsg.Text = ValidationMessage(1017)
                    msginfo.Text = ValidationMessage(1014)
                    Category.CategoryId = 0
                    GridView1.PageIndex = ViewState("PageIndex")
                    dispgrid()
                End If
            ElseIf BtnSave.CommandName = "ADD" Then

                Category.CategoryName = txtName.Text
                Category.DeptId = cmbDept.SelectedValue

                dt = CategoryManager.CheckDuplicate(Category)
                If dt.Rows.Count > 0 Then
                    'msginfo.Visible = True
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                    'clear()
                Else
                    CategoryManager.InsertRecord(Category)
                    BtnSave.CommandName = "ADD"
                    GridView1.DataBind()
                    GridView1.Visible = True
                    msginfo.Text = ValidationMessage(1014)
                    ' lblmsg.Visible = True
                    lblmsg.Text = ValidationMessage(1020)
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    dispgrid()
                    clear()
                End If
            End If
        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        LinkButton1.Focus()
        ' GridView1.DataSourceID = "ObjectDataSource1"
        If BtnDetails.CommandName = "VIEW" Then
            'Dim CategoryManager As New CategoryManager
            Category.CategoryId = 0
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            dispgrid()
            GridView1.Visible = True
            GridView1.Enabled = True
        Else

            Category.CategoryId = 0
            GridView1.PageIndex = ViewState("PageIndex")
            dispgrid()
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            BtnDetails.CommandName = "VIEW"
            BtnDetails.Text = "VIEW"
            BtnSave.CommandName = "ADD"
            BtnSave.Text = "ADD"
            clear()
            GridView1.Visible = True
            GridView1.Enabled = True
        End If
       
    End Sub
    Sub dispgrid()

        'Dim ins As String = HttpContext.Current.Session("office")
        'Dim bran As String = HttpContext.Current.Session("BranchCode")
        dt = CategoryManager.GetCategory(Category)
        
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            
        Else
            'msginfo.Visible = True
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1023)
            
        End If
    End Sub


    'Protected Sub BtnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReport.Click
    '    Dim qrystring As String = "rptCategoryV.aspx?" & QueryStr.Querystring()
    '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    'End Sub

    Protected Sub BtnRecover_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRecover.Click

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        dispgrid()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        'Dim Depreciation_Rates As New Depreciation_Rates
        If (Session("BranchCode") = Session("ParentBranch")) Then
            CategoryManager.ChangeFlag(CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("Label5"), Label).Text)
            GridView1.DataBind()
            msginfo.Text = ValidationMessage(1014)
            'lblmsg.Visible = True
            lblmsg.Text = ValidationMessage(1028)
            cmbDept.Focus()
            GridView1.PageIndex = ViewState("PageIndex")
            dispgrid()
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
        
    End Sub
    'Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging

    '    GridView1.PageIndex = e.NewPageIndex
    '    dispgrid()
    '    'GridView1.Visible = True
    '    'lblmsge.Visible = False
    '    'lblmsgs.Visible = False
    'End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        txtID.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        txtName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        cmbDept.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        BtnSave.CommandName = "UPDATE"
        BtnSave.Text = "UPDATE"
        BtnSave.Visible = True
        e.Cancel = True
        BtnDetails.CommandName = "BACK"
        BtnDetails.Text = "BACK"
        BtnDetails.Visible = True
        BtnDetails.Enabled = True
        GridView1.DataBind()
        GridView1.Enabled = False
        Category.CategoryId = txtID.Text
        dt = CategoryManager.GetCategory(Category)
        dispgrid()
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
        
    End Sub
    Sub Enable()
        GridView1.Enabled = True
        BtnDetails.Visible = True
        BtnRecover.Visible = True
        'BtnReport.Visible = True
    End Sub
    Sub Disable()
        GridView1.Enabled = False
        BtnDetails.Visible = False
        BtnRecover.Visible = False
        'BtnReport.Visible = False
    End Sub
    Sub clear()
        txtID.Text = ""
        txtName.Text = ""
        cmbDept.ClearSelection()

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbDept.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
    End Sub

    Protected Sub cmbDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDept.SelectedIndexChanged
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
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
        dt = CategoryManager.GetCategory(Category)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        
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
    'Code written fro multilingual by Niraj on 12 aug 2013
    ''Retriving the text of controls based on Language

    
   
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        If dt2 Is Nothing Then
            Response.Redirect("LogIn.aspx")
        End If
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
End Class
