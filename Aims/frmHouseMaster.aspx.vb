
Partial Class frmHouseMaster
    Inherits BasePage
    Dim s As New HouseMaster
    Dim bl As New BLHouseMaster
    Dim dl As New DLHouseMaster
    Dim dt As New DataTable
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            txtName.Focus()
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            If btnadd.CommandName = "UPDATE" Then
                s.Name = txtName.Text
                s.Id = ViewState("HM_ID")
                dt = bl.CheckDuplicate(s)
                If dt.Rows.Count > 0 Then
                    lblRed.Text = ValidationMessage(1030)
                    lblGreen.Text = ValidationMessage(1014)
                    'clear()
                Else
                    bl.Update(s)
                    btnadd.CommandName = "ADD"
                    btnadd.Text = "ADD"
                    GridView1.Visible = True
                    btnDet.CommandName = "VIEW"
                    btnDet.Text = "VIEW"
                    lblRed.Text = ValidationMessage(1014)
                    clear()
                    GridView1.PageIndex = ViewState("PageIndex")
                    DispGrid()
                    lblRed.Text = ValidationMessage(1014)
                    lblGreen.Text = ValidationMessage(1017)
                    txtName.ReadOnly = False
                End If
            ElseIf btnadd.CommandName = "ADD" Then
                s.Name = txtName.Text
                dt = bl.CheckDuplicate(s)
                If dt.Rows.Count > 0 Then
                    lblRed.Text = ValidationMessage(1030)
                    lblGreen.Text = ValidationMessage(1014)
                    'clear()
                Else
                    bl.Insert(s)
                    btnadd.CommandName = "ADD"
                    lblRed.Text = ValidationMessage(1014)
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
    End Sub

    Sub DispGrid()

        GridView1.Enabled = True
        s.Id = 0
        dt = bl.getGVHouseMaster(s)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            LinkButton.Focus()
        Else
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1023)
        End If
        
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
        btnadd.CommandName = "UPDATE"
        btnadd.Text = "UPDATE"
        btnDet.Visible = True
        btnDet.CommandName = "BACK"
        btnDet.Text = "BACK"
        GridView1.Visible = True
        ViewState("HM_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        txtName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text

        s.Id = ViewState("HM_ID")
        dt = bl.getGVHouseMaster(s)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
        GridView1.Visible = True
        'lblGreen.Visible = True
        
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        s.Id = CType(GridView1.Rows(e.RowIndex).FindControl("IID"), HiddenField).Value
        bl.DeleteGVHouseMaster(s)
        GridView1.DataBind()
        'lblGreen.Visible = True
        lblRed.Text = ValidationMessage(1014)
        lblGreen.Text = ValidationMessage(1028)
        txtName.Focus()
        clear()
        GridView1.PageIndex = ViewState("PageIndex")
        DispGrid()
        
    End Sub


    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DispGrid()
        GridView1.Visible = True
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
        txtName.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click

        If btnDet.CommandName = "VIEW" Then
            GridView1.Enabled = True
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DispGrid()
        ElseIf btnDet.CommandName = "BACK" Then
            btnadd.Text = "ADD"
            btnDet.Text = "VIEW"
            GridView1.Enabled = True
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            btnadd.CommandName = "ADD"
            btnDet.CommandName = "VIEW"
            clear()
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
        

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
        GridView1.Enabled = True
        s.Id = 0
        dt = bl.getGVHouseMaster(s)
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
