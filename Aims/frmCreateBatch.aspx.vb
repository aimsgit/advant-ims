
Partial Class frmCreateBatch
    Inherits BasePage
    Dim dt As New DataTable
    Dim b As New CreateBatch
    Dim Bl As New BLCreateBatch
    'Code for add Button By Nitin 21-Feb-2012
    'Class Teacher and Associate Teacher Added by Anchala 03-05-2012
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        TextBox1.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                Dim b As New CreateBatch
                b.Batch_No = TextBox1.Text
                b.CourseCode = DropDownList1.SelectedValue
                b.AcademicYear = DropDownList2.SelectedValue
                b.StartDate = CType(TextBox3.Text, Date)
                b.Seat = txtseat.Text
                b.ClassTeacher = ddlClassThr.SelectedValue
                b.AssociatedTeacher = DdlAssociatedThr.SelectedValue
                b.Forum = ddlForum.SelectedValue

                If btnadd.CommandName = "UPDATE" Then
                    b.id = ViewState("id")
                    Dim dt1 As New DataTable
                    dt1 = Bl.CheckDuplicate(b)
                    If dt1.Rows.Count > 0 Then
                        lblmsg.Text = ValidationMessage(1014)
                        lblErrorMsg.Text = ValidationMessage(1030)
                        TextBox1.Focus()

                    Else
                        Bl.UpdateRecord(b)
                        btnadd.CommandName = "ADD"
                        GridView1.DataBind()
                        GridView1.Visible = True
                        btnview.CommandName = "VIEW"
                        lblErrorMsg.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1017)
                        TextBox1.Focus()
                        GridView1.PageIndex = ViewState("PageIndex")
                        displayGrid()
                        clear()
                    End If
                ElseIf btnadd.CommandName = "ADD" Then
                    Dim dt1 As New DataTable
                    dt1 = Bl.CheckDuplicate(b)
                    If dt1.Rows.Count > 0 Then
                        lblmsg.Text = ValidationMessage(1014)
                        lblErrorMsg.Text = ValidationMessage(1030)
                        TextBox1.Focus()

                    Else
                        Bl.InsertRecord(b)
                        btnadd.CommandName = "ADD"
                        GridView1.DataBind()
                        GridView1.Visible = True
                        lblErrorMsg.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1020)
                        TextBox1.Focus()
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        displayGrid()
                        GridView1.Visible = True
                        clear()
                    End If
                End If
            Catch ex As Exception
                lblErrorMsg.Text = ValidationMessage(1077)
            End Try
        Else
            lblErrorMsg.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    Protected Sub clear()
        TextBox1.Text = ""
        TextBox3.Text = ""
        txtseat.Text = ""
        DropDownList1.ClearSelection()
        DropDownList2.ClearSelection()
    End Sub
    'Code for  View Button By Nitin 21-Feb-2012
    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        LinkButton1.Focus()
        lblErrorMsg.Text = ValidationMessage(1014)
        lblmsg.Text = ValidationMessage(1014)
        If btnview.CommandName = "VIEW" Then
            btnadd.Text = "ADD"
            btnview.Text = "VIEW"
            Dim dt As New DataTable
            b.id = 0
            If DropDownList1.SelectedValue = "" Then
                b.CourseCode = 0
            Else
                b.CourseCode = DropDownList1.SelectedValue
            End If

            If DropDownList2.SelectedValue = "" Then
                b.AcademicYear = 0
            Else
                b.AcademicYear = DropDownList2.SelectedValue
            End If
            dt = Bl.GetRecord(b)
            
            If dt.Rows.Count <> 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                
                GridView1.Enabled = True
                GridView1.Visible = True
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                display()
            Else
                
                lblErrorMsg.Text = ValidationMessage(1023)
                TextBox1.Focus()
                lblmsg.Text = ValidationMessage(1014)
                GridView1.Visible = False
            End If
        ElseIf btnview.CommandName = "BACK" Then
            GridView1.PageIndex = ViewState("PageIndex")
            displayGrid()
            btnview.CommandName = "VIEW"
            btnview.Text = "VIEW"
            btnadd.CommandName = "ADD"
            btnadd.Text = "ADD"
            clear()
        End If

    End Sub
    'Code for Display Button By Nitin 21-Feb-2012
    Sub display()
        Dim b As New CreateBatch
        
        If DropDownList1.SelectedValue = "" Then
            b.CourseCode = 0
        Else
            b.CourseCode = DropDownList1.SelectedValue
        End If

        If DropDownList2.SelectedValue = "" Then
            b.AcademicYear = 0
        Else
            b.AcademicYear = DropDownList2.SelectedValue
        End If
        dt = Bl.GetRecord(b)
        If dt.Rows.Count <> 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
            
        Else
            lblmsg.Text = ValidationMessage(1014)
            lblErrorMsg.Text = ValidationMessage(1023)
            TextBox1.Focus()
            GridView1.Visible = False
            
        End If
    End Sub
    Sub displayGrid()
        Dim b As New CreateBatch
        b.id = 0
        If DropDownList1.SelectedValue <> "" Then
            b.CourseCode = 0
        End If
        If DropDownList2.SelectedValue <> "" Then
            b.AcademicYear = 0
        End If
        dt = Bl.GetRecord(b)
        If dt.Rows.Count <> 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            
            GridView1.Visible = True
            GridView1.Enabled = True

        Else
            lblmsg.Text = ValidationMessage(1014)
            lblErrorMsg.Text = ValidationMessage(1023)
            TextBox1.Focus()
            GridView1.Visible = False
            
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        display()
        GridView1.Visible = True
    End Sub
    'Code for Delete Button By Nitin 21-Feb-2012
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Bl.DeleteRecord(CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("Lableid"), Label).Text)
            GridView1.PageIndex = ViewState("PageIndex")
            display()
            GridView1.Visible = True
            lblErrorMsg.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1028)
            TextBox1.Focus()
        Else
            lblErrorMsg.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub
    'Code for Row Editing By Nitin 21-Feb-2012
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim x As String
        Dim y As String
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblErrorMsg.Text = ValidationMessage(1014)
        lblmsg.Text = ValidationMessage(1014)
        TextBox1.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelBatchNo"), Label).Text
        DropDownList1.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelID"), Label).Text
        DropDownList2.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelAcademicyear"), Label).Text
        TextBox3.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelStartdate"), Label).Text
        txtseat.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelSeat"), Label).Text
        ddlForum.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblForum"), Label).Text
        x = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblct"), HiddenField).Value
        If x = "" Then
            ddlClassThr.SelectedValue = 0
        Else
            Try
                ddlClassThr.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblct"), HiddenField).Value
            Catch ex As ArgumentException
                ddlClassThr.SelectedValue = 0
            End Try
        End If
        y = CType(GridView1.Rows(e.NewEditIndex).FindControl("Ldlat"), HiddenField).Value
        If y = "" Then
            DdlAssociatedThr.SelectedValue = 0
        Else
            Try
                DdlAssociatedThr.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Ldlat"), HiddenField).Value
            Catch ex As ArgumentException
                DdlAssociatedThr.SelectedValue = 0
            End Try
        End If
        ViewState("id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lableid"), Label).Text
        b.id = ViewState("id")
        b.AcademicYear = DropDownList2.SelectedValue
        dt = Bl.GetRecord(b)
        GridView1.DataSource = dt
        GridView1.DataBind()

        GridView1.Enabled = False
        btnadd.CommandName = "UPDATE"
        btnadd.Text = "UPDATE"
        e.Cancel = True
        btnview.CommandName = "BACK"
        btnview.Text = "BACK"

        btnview.Visible = True
        
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        lblErrorMsg.Text = ValidationMessage(1014)
        lblmsg.Text = ValidationMessage(1014)
        If Not Page.IsPostBack Then
            
            TextBox3.Text = Format(Date.Today, "dd-MMM-yyy")
            TextBox1.Focus()
        End If
    End Sub

    Protected Sub DdlAssociatedThr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlAssociatedThr.TextChanged
        DdlAssociatedThr.Focus()
    End Sub

    Protected Sub ddlClassThr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlClassThr.TextChanged
        ddlClassThr.Focus()
    End Sub

    Protected Sub DropDownList1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList1.TextChanged
        DropDownList1.Focus()
    End Sub

    Protected Sub DropDownList2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownList2.TextChanged
        DropDownList2.Focus()
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

        Dim b As New CreateBatch
        b.id = 0
        If DropDownList1.SelectedValue <> "" Then
            b.CourseCode = 0
        End If
        If DropDownList2.SelectedValue <> "" Then
            b.AcademicYear = 0
        End If
        dt = Bl.GetRecord(b)
        
        If dt.Rows.Count <> 0 Then
            Dim sortedView As New DataView(dt)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            GridView1.DataSource = sortedView
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
        Else
            lblmsg.Text = ValidationMessage(1014)
            lblErrorMsg.Text = ValidationMessage(1023)
            TextBox1.Focus()
            GridView1.Visible = False
        End If
       
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
    'Code written fro multilingual by Niraj on 23 sep 2013
    ''Retriving the text of controls based on Language

    
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        Try

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

        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
        Return 0
    End Function
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub
End Class
