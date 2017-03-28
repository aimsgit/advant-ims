
Partial Class frmResourceMaster
    Inherits BasePage
    Dim resource As New ElResourceMaster
    Dim dt As New DataTable
    Dim ResourceMasterB As New ResourceMasterB
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnAdd.CommandName = "UPDATE" Then
                resource.ResourceType = txtresourcetype.Text
                resource.ResourceName = txtresourcename.Text
                If txtcapacity.Text = "" Then
                    resource.Capacity = 0
                Else
                    resource.Capacity = txtcapacity.Text
                End If
                resource.id = ViewState("PKID")
                dt = ResourceMasterB.GetDuplicateResource(resource)
                If dt.Rows.Count > 0 Then
                    lblE.Text = ValidationMessage(1030)
                    lblS.Text = ValidationMessage(1014)
                Else
                    ResourceMasterB.UpdateRecord(resource)
                    btnAdd.CommandName = "ADD"
                    GridResourceMaster.Visible = True
                    btnView.CommandName = "VIEW"
                    lblS.Text = ValidationMessage(1017)
                    lblE.Text = ValidationMessage(1014)
                    clear()
                    GridResourceMaster.PageIndex = ViewState("PageIndex")
                    resource.id = 0
                    DispGrid(resource)
                End If
            Else
                resource.ResourceType = txtresourcetype.Text
                resource.ResourceName = txtresourcename.Text
                If txtcapacity.Text = "" Then
                    resource.Capacity = 0
                Else
                    resource.Capacity = txtcapacity.Text
                End If
                dt = ResourceMasterB.GetDuplicateResource(resource)
                If dt.Rows.Count > 0 Then
                    lblE.Text = ValidationMessage(1030)
                    lblS.Text = ValidationMessage(1014)
                    btnAdd.CommandName = "ADD"
                    btnView.CommandName = "VIEW"
                    clear()
                Else
                    ResourceMasterB.InsertRecord(resource)
                    btnAdd.CommandName = "ADD"
                    lblE.Text = ValidationMessage(1014)
                    lblS.Text = ValidationMessage(1020)
                    clear()
                    ViewState("PageIndex") = 0
                    GridResourceMaster.PageIndex = 0
                    DispGrid(resource)
                End If

            End If
        Else
            lblE.Text = ValidationMessage(1021)
            lblS.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub clear()
        txtresourcetype.Text = ""
        txtresourcename.Text = ""
        txtcapacity.Text = ""

    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        If btnView.CommandName = "VIEW" Then
            lblE.Text = ValidationMessage(1014)
            lblS.Text = ValidationMessage(1014)
            clear()
            ViewState("PageIndex") = 0
            GridResourceMaster.PageIndex = 0
            resource.id = 0
            DispGrid(resource)
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
        Else
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
            lblE.Text = ValidationMessage(1014)
            lblS.Text = ValidationMessage(1014)
            clear()
            GridResourceMaster.PageIndex = ViewState("PageIndex")
            resource.id = 0
            DispGrid(resource)
        End If

    End Sub

    'Protected Sub GridResourceMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridResourceMaster.RowDeleting
    '    If (Session("BranchCode") = Session("ParentBranch")) Then
    '        resource.id = CType(GridResourceMaster.Rows(e.RowIndex).FindControl("LblPK"), Label).Text
    '        ResourceMasterB.ChangeFlag(resource)
    '        resource.id = 0
    '        DispGrid(resource)
    '        lblE.Text = ""
    '        lblS.Text = "Data Deleted Successfully."
    '        clear()
    '        'GridResourceMaster.PageIndex = ViewState("PageIndex")
    '        'GridView1.DataBind()
    '        'lblmsg.Visible = True            
    '        'cmbcourseType.Focus()         

    '    Else
    '        lblE.Text = "You do not belong to this branch, Cannot delete data."
    '        lblS.Text = ""
    '    End If
    'End Sub

    Protected Sub GridResourceMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridResourceMaster.RowEditing

        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Dim dt As New DataTable
        btnAdd.Text = "UPDATE"
        btnView.Visible = True
        btnView.Text = "BACK"
        lblS.Text = ValidationMessage(1014)
        lblE.Text = ValidationMessage(1014)
        GridResourceMaster.Visible = True
        ViewState("PKID") = CType(GridResourceMaster.Rows(e.NewEditIndex).FindControl("LblPK"), Label).Text
        txtresourcetype.Text = CType(GridResourceMaster.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        txtresourcename.Text = CType(GridResourceMaster.Rows(e.NewEditIndex).FindControl("Label7"), Label).Text
        txtcapacity.Text = CType(GridResourceMaster.Rows(e.NewEditIndex).FindControl("lblCapacity"), Label).Text
        resource.id = ViewState("PKID")
        DispGrid(resource)
        GridResourceMaster.Enabled = "False"

        'Else
        'lblE.Text = "You do not belong to this branch, Cannot edit data."
        'lblS.Text = ""
        'End If

    End Sub
    Protected Sub GridResourceMaster_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridResourceMaster.PageIndexChanging
        GridResourceMaster.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridResourceMaster.PageIndex
        DispGrid(resource)
        GridResourceMaster.Visible = True
    End Sub
    Sub DispGrid(ByVal resource As ElResourceMaster)
        Dim dt As New DataTable
        GridResourceMaster.Enabled = True
        dt = ResourceMasterB.GetResource(resource)
        If dt.Rows.Count > 0 Then
            GridResourceMaster.DataSource = dt
            GridResourceMaster.DataBind()
            GridResourceMaster.Visible = True
            LinkButton.Focus()
        Else
            lblS.Text = ValidationMessage(1014)
            lblE.Text = ValidationMessage(1023)
            GridResourceMaster.Visible = False
        End If

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
    End Sub

    Protected Sub GridResourceMaster_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridResourceMaster.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        GridResourceMaster.Enabled = True
        dt = ResourceMasterB.GetResource(resource)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridResourceMaster.DataSource = sortedView
        GridResourceMaster.DataBind()
        GridResourceMaster.Visible = True
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
