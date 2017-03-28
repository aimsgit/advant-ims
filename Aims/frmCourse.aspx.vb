Partial Class frmCourse
    Inherits BasePage
    Dim Course As New Course
    Dim c As New Course
    Dim dt As New DataTable
    Dim CourseManager As New CourseManager
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        cmbcourseType.Focus()
        If txtseats.Text = "" Then
            txtseats.Text = 0
        End If

        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnadd.CommandName = "UPDATE" Then
                c.Name = txtName.Text
                c.Code = txtCode.Text
                c.CourseType = cmbcourseType.SelectedValue
                c.seatNo = txtseats.Text
                c.Stream = DdlStream.SelectedValue
                c.Course_ID = ViewState("Course_ID")
                dt = CourseManager.CheckDuplicate(c)
                If dt.Rows.Count > 0 Then
                    lblerrmsg.Visible = True
                    lblerrmsg.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                    'clear()
                Else
                    CourseManager.UpdateRecord(c)
                    btnadd.CommandName = "ADD"
                    'GridView1.Visible = True
                    btnview.CommandName = "VIEW"
                    lblmsg.Text = ValidationMessage(1017)
                    clear()
                    GridView1.PageIndex = ViewState("PageIndex")
                    DispGrid()
                End If
            ElseIf btnadd.CommandName = "ADD" Then
                c.Name = txtName.Text
                c.Code = txtCode.Text
                c.CourseType = cmbcourseType.SelectedValue
                c.seatNo = txtseats.Text
                c.Stream = DdlStream.SelectedValue
                dt = CourseManager.CheckDuplicate(c)
                If dt.Rows.Count > 0 Then
                    lblerrmsg.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                    btnadd.CommandName = "ADD"
                    btnview.CommandName = "VIEW"
                    'clear()
                Else
                    c.Name = txtName.Text
                    c.Code = txtCode.Text
                    c.CourseType = cmbcourseType.SelectedValue
                    c.seatNo = txtseats.Text
                    c.Stream = DdlStream.SelectedValue
                    Dim i As New Integer
                    i = CourseDB.Insert(c)
                    ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")
                    btnadd.CommandName = "ADD"
                    lblerrmsg.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1020)
                    clear()
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    dt = CourseDB.GetCourseById(ViewState("dispId "))
                    GridView1.Visible = True
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                End If

            End If
        Else
            lblerrmsg.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub clear()
        txtName.Text = ""
        txtCode.Text = ""
        txtseats.Text = ""
        'cmbcourseType.SelectedValue = "Select"
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        If btnview.CommandName = "VIEW" Then
            btnadd.Text = "ADD"
            btnview.Text = "VIEW"
            lblerrmsg.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            'clear()
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DispGrid()
        ElseIf btnview.CommandName = "BACK" Then

            btnadd.CommandName = "ADD"
            btnadd.Text = "ADD"
            btnview.CommandName = "VIEW"
            btnview.Text = "VIEW"
            lblerrmsg.Text = ValidationMessage(1014)
            clear()
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            c.Course_ID = CType(GridView1.Rows(e.RowIndex).FindControl("LblPK"), Label).Text
            CourseManager.ChangeFlag(c)
            GridView1.DataBind()
            'lblmsg.Visible = True
            lblerrmsg.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1028)
            cmbcourseType.Focus()
            clear()
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()
        Else
            lblerrmsg.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Dim dt As New DataTable
        btnadd.CommandName = "UPDATE"
        btnadd.Text = "UPDATE"
        btnview.Visible = True
        btnview.CommandName = "BACK"
        btnview.Text = "BACK"
        lblmsg.Text = ValidationMessage(1014)
        lblerrmsg.Text = ValidationMessage(1014)
        GridView1.Visible = True
        ViewState("Course_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblPK"), Label).Text
        txtName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        txtCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label12"), Label).Text
        Dim d As String = CType(GridView1.Rows(e.NewEditIndex).FindControl("DDL"), Label).Text
        cmbcourseType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("DDL"), Label).Text
        txtseats.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label13"), Label).Text
        DdlStream.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label14"), Label).Text
        c.Course_ID = ViewState("Course_ID")
        dt = CourseDB.GetCourse(c)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
        
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DispGrid()
        GridView1.Visible = True
    End Sub
    Sub DispGrid()
        Dim dt As New DataTable
        c.Course_ID = 0
        GridView1.Enabled = True
        dt = CourseManager.GetCourse(c)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            LinkButton.Focus()
            
        Else
            lblmsg.Text = ValidationMessage(1014)
            lblerrmsg.Text = ValidationMessage(1023)
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbcourseType.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
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
        c.Course_ID = 0
        GridView1.Enabled = True
        dt = CourseManager.GetCourse(c)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
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
    ''Code Written for Multilingual By Ajit Kumar Singh on 12th Aug
    ''Retriving the text of controls based on Language
    
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
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
