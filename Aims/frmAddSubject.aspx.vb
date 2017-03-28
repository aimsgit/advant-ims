Partial Class frmAddSubject
    Inherits BasePage
    Dim s As New Subject
    Dim bl As New SubjectManager
    Dim dl As New SubjectDB
    Dim dt As New DataTable
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        txtName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            If btnadd.CommandName = "UPDATE" Then

                s.Name = txtName.Text
                s.Code = txtCode.Text
                s.PrincipleSubject = ddlPrincipalSubject.SelectedValue
                s.SubjectCategory = ddlSubCategory.SelectedValue
                s.DeptId = DDLDeptType.SelectedValue
                s.Subgrp = ddloSubGrp.SelectedValue
                s.PreRequisites = txtPre.Text

                s.Id = ViewState("Subject_ID")
                dt = bl.CheckDuplicate(s)
                If dt.Rows.Count > 0 Then
                    lblRed.Text = ValidationMessage(1030)
                    lblGreen.Text = ValidationMessage(1014)
                    'clear()
                Else
                    bl.Update(s)
                    btnadd.CommandName = "ADD"
                    GridView1.Visible = True
                    btnDet.CommandName = "VIEW"
                    'lblGreen.Visible = True
                    lblRed.Text = ValidationMessage(1014)
                    clear()
                    lblGreen.Text = ValidationMessage(1017)
                    txtName.ReadOnly = False
                    txtName.Focus()
                    GridView1.PageIndex = ViewState("PageIndex")
                    DispGrid()
                End If
            ElseIf btnadd.CommandName = "ADD" Then
                s.Name = txtName.Text
                s.Code = txtCode.Text
                s.PrincipleSubject = ddlPrincipalSubject.SelectedValue
                s.SubjectCategory = ddlSubCategory.SelectedValue
                s.DeptId = DDLDeptType.SelectedValue
                s.Subgrp = ddloSubGrp.SelectedValue
                s.PreRequisites = txtPre.Text


                dt = bl.CheckDuplicate(s)
                If dt.Rows.Count > 0 Then
                    'lblRed.Visible = True
                    lblRed.Text = ValidationMessage(1030)
                    lblGreen.Text = ValidationMessage(1014)
                    'clear()
                Else
                    bl.Insert(s)
                    btnadd.CommandName = "ADD"
                    lblRed.Text = ValidationMessage(1014)
                    'lblGreen.Visible = True
                    lblGreen.Text = ValidationMessage(1020)
                    txtName.ReadOnly = False
                    clear()

                End If
                GridView1.Enabled = True
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                DispGrid()
            End If

        Else
            lblRed.Text = ValidationMessage(1021)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub clear()
        txtName.Text = ""
        txtCode.Text = ""
        'txtPrincipleSubject.Text = ""
        txtPre.Text = ""


    End Sub

    Protected Sub btnDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click
        If btnDet.CommandName = "VIEW" Then
            GridView1.Enabled = True
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            'If txtName.Text = "" Then
            '    s.Name = 0
            'Else
            '    s.Name = txtName.Text
            'End If
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DispGrid()
            btnadd.Text = "ADD"
            btnDet.Text = "VIEW"
            'clear()
        ElseIf btnDet.CommandName = "BACK" Then
            GridView1.Enabled = True
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            btnadd.Text = "ADD"
            btnDet.Text = "VIEW"
            clear()
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()
            
        End If
    End Sub
    Sub DispGrid()
        s.Id = 0
        If txtName.Text = "" Then
            s.Name = 0
        Else
            s.Name = txtName.Text
        End If
        If txtCode.Text = "" Then
            s.Code = 0
        Else
            s.Code = txtCode.Text
        End If
        s.DeptId = DDLDeptType.SelectedValue
        dt = bl.getGVSubjectMaster(s)
        If dt.Rows.Count > 0 Then
            GridView1.Enabled = True
            GridView1.Visible = True
            GridView1.DataSource = dt
            GridView1.DataBind()
            LinkButton.Focus()
        Else
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1023)
            GridView1.Visible = False
        End If
        
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DispGrid()
        GridView1.Visible = True
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            s.Id = CType(GridView1.Rows(e.RowIndex).FindControl("IID"), HiddenField).Value
            bl.DeleteGVSubjectMaster(s)
            GridView1.DataBind()
            'lblGreen.Visible = True
            lblRed.Text = ValidationMessage(1014)
            lblGreen.Text = ValidationMessage(1028)
            txtName.Focus()
            clear()
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()
        Else
            lblRed.Text = ValidationMessage(1029)
            lblGreen.Text = ValidationMessage(1014)
        End If
        
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
        btnadd.Text = "UPDATE"
        btnDet.Visible = True
        btnDet.Text = "BACK"
        GridView1.Visible = True
        ViewState("Subject_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        txtName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        txtCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        ddlPrincipalSubject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPrinCode"), Label).Text
        ddlSubCategory.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSubCatCode"), Label).Text
        DDLDeptType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDeptID"), Label).Text
        ddloSubGrp.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSubgrp"), Label).Text
        txtPre.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPreReq"), Label).Text
        s.Id = ViewState("Subject_ID")
        s.Name = 0
        s.Code = 0
        dt = bl.getGVSubjectMaster(s)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
        GridView1.Visible = True
        'lblGreen.Visible = True
        'Else
        'lblRed.Text = "You do not belong to this branch, Cannot edit data."
        'lblGreen.Text = ""
        'End If
        
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String

        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            
        End If
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
        txtName.Focus()
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
        s.Id = 0
        If txtName.Text = "" Then
            s.Name = 0
        Else
            s.Name = txtName.Text
        End If
        If txtCode.Text = "" Then
            s.Code = 0
        Else
            s.Code = txtCode.Text
        End If
        s.DeptId = DDLDeptType.SelectedValue
        dt = bl.getGVSubjectMaster(s)
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
    

    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
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