Imports System.Data.OleDb
Partial Class frmCourseType
    Inherits BasePage
    Dim dt As New DataTable
    Dim c As New CourseType
    Dim CourseTypeB As New CourseTypeB
    Dim CourseType As New CourseType
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        CourseTypeTextBox.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then

            If btnAdd.CommandName = "UPDATE" Then
                CourseType.CourseType = CourseTypeTextBox.Text
                CourseType.CourseType_ID = ViewState("CourseType_ID")
                If ddlDuration.SelectedValue = 0 Then
                    lblmsg.Text = "Select all mindatory field."
                Else
                    CourseType.Duratuion = ddlDuration.SelectedValue
                End If

                CourseType.CourseLevel = TxtCourseLevel.Text
                dt = CourseTypeB.Coursetypeduplicate(CourseType)
                If dt.Rows.Count > 0 Then
                    msginfo.Visible = True
                    lblmsg.Text = ValidationMessage(1030)
                    msginfo.Text = ValidationMessage(1014)
                Else
                    CourseTypeB.UpdateMethod(CourseType)
                    btnAdd.CommandName = "ADD"
                    btnAdd.Text = "ADD"
                    btnView.CommandName = "VIEW"
                    btnView.Text = "VIEW"
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1017)
                    clear()
                    GVCourseType.PageIndex = ViewState("PageIndex")
                    DispGrid()
                End If
            ElseIf btnAdd.CommandName = "ADD" Then
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1014)
                CourseType.CourseType = CourseTypeTextBox.Text
                If ddlDuration.SelectedValue = 0 Then
                    lblmsg.Text = "Select all mindatory field."
                    Exit Sub
                Else
                    CourseType.Duratuion = ddlDuration.SelectedValue
                End If

                CourseType.CourseLevel = TxtCourseLevel.Text
                dt = CourseTypeB.Coursetypeduplicate(CourseType)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1030)
                    msginfo.Text = ValidationMessage(1014)
                    DispGrid()
                    'clear()
                Else
                    CourseType.CourseType = CourseTypeTextBox.Text
                    CourseTypeB.InsertMethod(CourseType)
                    btnAdd.CommandName = "ADD"
                    clear()
                    lblmsg.Text = ValidationMessage(1014)
                    ViewState("PageIndex") = 0
                    GVCourseType.PageIndex = 0
                    DispGrid()
                    msginfo.Text = ValidationMessage(1020)
                End If
            End If

        Else
            lblmsg.Text = ValidationMessage(1021)
            msginfo.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub clear()
        CourseTypeTextBox.Text = ""
        ddlDuration.SelectedValue = 0
        TxtCourseLevel.Text = ""
        btnAdd.CommandName = "ADD"
        btnView.CommandName = "VIEW"
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If btnView.CommandName = "VIEW" Then
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GVCourseType.PageIndex = 0
            DispGrid()
            clear()
        ElseIf btnView.CommandName = "BACK" Then
            btnAdd.CommandName = "ADD"
            btnAdd.Text = "ADD"
            btnView.CommandName = "VIEW"
            btnView.Text = "VIEW"
            lblmsg.Text = ValidationMessage(1014)
            clear()
            GVCourseType.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub

    Protected Sub GVCourseType_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVCourseType.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            CourseTypeB.ChangeFlag(CType(GVCourseType.Rows(e.RowIndex).Cells(1).FindControl("CID"), HiddenField).Value)
            GVCourseType.DataBind()
            msginfo.Text = ValidationMessage(1028)
            CourseTypeTextBox.Focus()
            lblmsg.Text = ValidationMessage(1014)
            GVCourseType.PageIndex = ViewState("PageIndex")
            DispGrid()
        Else
            lblmsg.Text = ValidationMessage(1029)
            msginfo.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GVCourseType_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVCourseType.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        Dim dt As New DataTable
        btnAdd.CommandName = "UPDATE"
        btnAdd.Text = "UPDATE"
        btnView.Visible = True
        btnView.CommandName = "BACK"
        btnView.Text = "BACK"
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        GVCourseType.Visible = True
        ViewState("CourseType_ID") = CType(GVCourseType.Rows(e.NewEditIndex).FindControl("CID"), HiddenField).Value
        CourseTypeTextBox.Text = CType(GVCourseType.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        TxtCourseLevel.Text = CType(GVCourseType.Rows(e.NewEditIndex).FindControl("lblCL"), Label).Text
        If CType(GVCourseType.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text = "" Then
            ddlDuration.SelectedValue = 0
        Else
            ddlDuration.SelectedValue = CType(GVCourseType.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        End If

        c.CourseType_ID = ViewState("CourseType_ID")
        dt = CourseTypeDB.CourseType(c)
        GVCourseType.DataSource = dt
        GVCourseType.DataBind()
        GVCourseType.Enabled = False
        
    End Sub
    Protected Sub GVCourseType_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVCourseType.PageIndexChanging
        GVCourseType.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVCourseType.PageIndex
        DispGrid()
        GVCourseType.Visible = True
    End Sub
    Sub DispGrid()
        Dim dt As New DataTable
        c.CourseType_ID = 0
        GVCourseType.Enabled = True
        dt = CourseTypeDB.CourseType(c)
        If dt.Rows.Count > 0 Then
            GVCourseType.DataSource = dt
            GVCourseType.DataBind()
            GVCourseType.Visible = True
            LinkButton.Focus()
            
        Else
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1023)
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CourseTypeTextBox.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
    End Sub

    Protected Sub GVCourseType_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVCourseType.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        c.CourseType_ID = 0
        GVCourseType.Enabled = True
        dt = CourseTypeDB.CourseType(c)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVCourseType.DataSource = sortedView
        GVCourseType.DataBind()
        GVCourseType.Visible = True
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
