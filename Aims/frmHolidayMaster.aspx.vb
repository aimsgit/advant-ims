Imports System.Web.UI.Control
Imports System.Web.UI.WebControls
Partial Class frmHolidayMaster

    Inherits BasePage
    Dim sda, sda1, sda2, sda5 As New OleDbDataAdapter()
    Dim sdt, sdt1, sdt2, sdt5 As New DataTable()
    Dim alt As String
    Dim objBusErrMesg As New busErrorMessage
    Dim Dh As New BHolidayMaster
    Dim el As New EHolidayMaster
    Dim dt As New DataTable


    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim el As New EHolidayMaster
            el.Id = CType(GridView1.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
            Dh.ChangeFlag(el)
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1028)
            txtName.Focus()
            GridView1.PageIndex = ViewState("PageIndex")

            DisplayGrid()
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        txtname.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        txtdate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        txtShortform.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label9"), Label).Text
        Dim s As String = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label8"), Label).Text

        If CType(GridView1.Rows(e.NewEditIndex).FindControl("Label8"), Label).Text = "Holiday" Then
            RbType.SelectedValue = "H"
        Else
            RbType.SelectedValue = "E"

        End If
        ViewState("HM_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
        'txtname.Text = ViewState("HM_ID")
        InsertButton.CommandName = "UPDATE"
        InsertButton.Text = "UPDATE"
        btnDet.CommandName = "BACK"
        btnDet.Text = "Back"
        el.Id = ViewState("HM_ID")
        dt = Dh.GetHolidayMaster(el)

        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
        
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If

    End Sub
    Protected Sub InsertButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertButton.Click
        txtName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If InsertButton.CommandName = "UPDATE" Then
                    If RbType.SelectedValue = "H" Then
                        el.Rbid = "H"
                    Else
                        el.Rbid = "E"
                    End If
                    el.Name = txtname.Text
                    el.Date1 = txtdate.Text
                    el.Shortname = txtShortform.Text
                    el.Id = ViewState("HM_ID")
                    dt = Dh.CheckDuplicate(el)


                    If dt.Rows.Count > 0 Then
                        msginfo.Text = ValidationMessage(1030)
                        lblmsg.Text = ValidationMessage(1014)
                    Else
                        Dh.UpdateRecord(el)
                        msginfo.Text = ValidationMessage(1014)
                        InsertButton.CommandName = "ADD"
                        InsertButton.Text = "ADD"
                        btnDet.CommandName = "VIEW"
                        btnDet.Text = "VIEW"
                        lblmsg.Text = ValidationMessage(1017)
                        GridView1.PageIndex = ViewState("PageIndex")
                        DisplayGrid()
                        txtdate.Text = ""
                        txtname.Text = ""
                        txtShortform.Text = ""
                    End If
                ElseIf InsertButton.CommandName = "ADD" Then
                    If txtname.Text = "" And txtdate.Text = "" Then
                        msginfo.Text = ValidationMessage(1062)
                        'msginfo.Visible = True
                        lblmsg.Text = ValidationMessage(1014)
                    Else
                        If RbType.SelectedValue = "H" Then
                            el.Rbid = "H"
                        Else
                            el.Rbid = "E"
                        End If
                        el.Name = txtname.Text
                        el.Date1 = txtdate.Text
                        el.Shortname = txtShortform.Text
                        dt = Dh.CheckDuplicate(el)
                        If dt.Rows.Count > 0 Then
                            'msginfo.Visible = True
                            msginfo.Text = ValidationMessage(1030)
                            lblmsg.Text = ValidationMessage(1014)
                        Else
                            'el.Id = ViewState("HM_ID")
                            Dh.InsertRecord(el)

                            'GridView1.DataBind()
                            msginfo.Text = ValidationMessage(1014)
                            'lblmsg.Visible = True
                            InsertButton.CommandName = "ADD"
                            lblmsg.Text = ValidationMessage(1020)
                            ViewState("PageIndex") = 0
                            GridView1.PageIndex = 0
                            DisplayGrid()
                            'lblmsg.Visible = True
                            txtname.Text = ""
                            txtdate.Text = ""
                            txtShortform.Text = ""
                            Clear()
                            'End If
                            DisplayGrid()
                        End If
                    End If
                End If
            Catch ex As Exception
                msginfo.Text = ValidationMessage(1022)
                lblmsg.Text = ValidationMessage(1014)
            End Try


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
        LinkButton1.Focus()
        ' GridView1.DataSourceID = "ObjectDataSource1"
        'lblmsg.Visible = True
        msginfo.Text = ValidationMessage(1014)
        If btnDet.CommandName <> "BACK" Then
            'Dim CategoryManager As New CategoryManager
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DisplayGrid()
            GridView1.Visible = True

        Else
            'clear()
            'Enable()
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            btnDet.CommandName = "VIEW"
            btnDet.Text = "VIEW"
            InsertButton.CommandName = "ADD"
            InsertButton.Text = "ADD"
            txtname.Text = ""
            txtdate.Text = ""
            txtShortform.Text = ""
            GridView1.Visible = True
            'Disable()
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        End If
    End Sub
    Sub DisplayGrid()
        Dim dt As New DataTable
        el.Id = 0
        dt = Dh.GetHolidayMaster(el)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
        
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ValidationMessage(1014)

            msginfo.Text = ValidationMessage(1023)
            'msginfo.Visible = True
        End If
    End Sub


    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Sub Clear()
        txtname.Text = ""
        txtdate.Text = ""
        txtShortform.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtname.Focus()
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
        el.Id = 0
        dt = Dh.GetHolidayMaster(el)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
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

