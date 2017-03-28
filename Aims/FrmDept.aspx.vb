Imports System.Web.UI.Control
Imports System.Web.UI.WebControls
Partial Class FrmDept
    Inherits BasePage
    Dim sda, sda1, sda2, sda5 As New OleDbDataAdapter()
    Dim sdt, sdt1, sdt2, sdt5 As New DataTable()
    Dim alt As String
    Dim objBusErrMesg As New busErrorMessage
    Dim Dm As New DepartmentManager
    Dim Department As New Department
    Dim dt As New DataTable

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim d As New Department
            d.Id = CType(GridView1.Rows(e.RowIndex).FindControl("DID"), HiddenField).Value
            Dm.ChangeFlag(d)
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1028)
            txtname.Focus()
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

        Dim el As New Department
        txtname.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        txtcode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        ViewState("Dept_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("DID"), HiddenField).Value
        el.Id = ViewState("Dept_ID")
        dt = Dm.GetDepartmentDtls(el)
        GridView1.DataSource = dt
        GridView1.DataBind()
        InsertButton.Text = "UPDATE"
        btnDet.Text = "BACK"
        GridView1.Enabled = False
        msginfo.Text = ValidationMessage(1014)
        lblmsg.Text = ValidationMessage(1014)
        
    End Sub
    Protected Sub InsertButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertButton.Click
        txtname.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If InsertButton.CommandName = "UPDATE" Then
                Department.Name = txtname.Text
                Department.Code = txtcode.Text
                Department.Id = ViewState("Dept_ID")
                dt = Dm.CheckDuplicate(Department)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                Else
                    Dm.UpdateRecord(Department)
                    msginfo.Text = ValidationMessage(1014)
                    InsertButton.CommandName = "ADD"
                    btnDet.CommandName = "VIEW"
                    lblmsg.Text = ValidationMessage(1017)
                    GridView1.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    txtcode.Text = ""
                    txtname.Text = ""
                End If
            ElseIf InsertButton.CommandName = "ADD" Then
                If txtname.Text = "" And txtcode.Text = "" Then
                    msginfo.Text = ValidationMessage(1062)
                    lblmsg.Text = ValidationMessage(1014)
                Else
                    Department.Name = txtname.Text
                    Department.Code = txtcode.Text
                    dt = Dm.CheckDuplicate(Department)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = ValidationMessage(1030)
                        lblmsg.Text = ValidationMessage(1014)
                    Else
                        Department.Id = ViewState("Dept_ID")
                        Dm.InsertRecord(Department)

                        'GridView1.DataBind()
                        msginfo.Text = ValidationMessage(1014)
                        'lblmsg.Visible = True
                        InsertButton.CommandName = "ADD"
                        lblmsg.Text = ValidationMessage(1020)
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        DisplayGrid()
                        txtname.Text = ""
                        txtcode.Text = ""
                        DisplayGrid()
                    End If
                End If
            End If
        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub Grddept_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGrid()
    End Sub
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click
        
        msginfo.Text = ValidationMessage(1014)
        If btnDet.CommandName <> "BACK" Then
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DisplayGrid()
            GridView1.Visible = True
            btnDet.Text = "VIEW"
            InsertButton.Text = "ADD"

        Else
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            btnDet.Text = "VIEW"
            InsertButton.Text = "ADD"
            txtname.Text = ""
            txtcode.Text = ""
            GridView1.Visible = True
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        End If
    End Sub
    Sub DisplayGrid()
        Dim dt As New DataTable
        Department.Id = 0
        dt = Dm.GetDepartmentDtls(Department)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
        LinkButton.Focus()
       
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1023)
        End If
    End Sub

   
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtname.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            
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
        Dim dt As New DataTable
        Department.Id = 0
        dt = Dm.GetDepartmentDtls(Department)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
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
