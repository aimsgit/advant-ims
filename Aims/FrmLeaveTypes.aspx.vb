
Partial Class FrmLeaveTypes
    Inherits BasePage
    Dim alt, alt1 As String
    Dim Bl As New LeaveTypes
    Dim dt As New DataTable
    Dim el As New ELLeavTypes

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lblErrorMsg.Text = ""
        'lblErrorMsg.Visible = False
        'Dim txtLeavetype As TextBox = CType(FindControl("txtLeavetype"), TextBox)
        txtLeavetype.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("Privilages").ToString.Contains("W") Then
            txtLeavetype.Focus()
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If btnSave.Text = "UPDATE" Then
                    el.Leave_Type = txtLeavetype.Text
                    el.LeaveDescription = txtDescription.Text
                    el.Paid = ddlpaid.SelectedValue
                    el.Leave_TypeCode = txtleavecode.Text
                    el.LeaveFor = ddlleavefor.SelectedValue
                    el.TY_ID = ViewState("TY_ID")
                    dt = Bl.GetDuplicateLeaveType(el)
                    If dt.Rows.Count > 0 Then
                        lblErrorMsg.Text = "Data already Exists."
                        txtLeavetype.Focus()
                        msgInfo.Text = ""
                    Else
                        Bl.UpdateRecord(el)
                        btnSave.Text = "ADD"
                        ' GridView1.Visible = True
                        btnDetails.Text = "VIEW"
                        lblErrorMsg.Text = ""
                        ' msgInfo.Visible = True
                        msgInfo.Text = "Data Updated Successfully."
                        GridView1.PageIndex = ViewState("PageIndex")
                        DispGrid()
                        clear()
                    End If
                ElseIf btnSave.Text = "ADD" Then
                    msgInfo.Text = ""
                    el.Leave_Type = txtLeavetype.Text
                    el.LeaveDescription = txtDescription.Text
                    el.Leave_TypeCode = txtleavecode.Text
                    el.Paid = ddlpaid.SelectedValue
                    el.LeaveFor = ddlleavefor.SelectedValue
                    dt = Bl.GetDuplicateLeaveType(el)
                    If dt.Rows.Count > 0 Then
                        ' lblErrorMsg.Visible = True
                        lblErrorMsg.Text = "Data already Exists."
                        txtLeavetype.Focus()
                        msgInfo.Text = ""
                        btnSave.Text = "ADD"
                        btnDetails.Text = "VIEW"
                        'clear()
                        'DispGrid()
                    Else
                        el.Leave_Type = txtLeavetype.Text
                        el.LeaveDescription = txtDescription.Text
                        el.Paid = ddlpaid.SelectedValue
                        el.Leave_TypeCode = txtleavecode.Text
                        el.LeaveFor = ddlleavefor.SelectedValue
                        Bl.InsertRecord(el)
                        btnSave.Text = "ADD"
                        clear()
                        'lblErrorMsg.Visible = False
                        'msgInfo.Visible = True
                        lblErrorMsg.Text = ""
                        msgInfo.Text = "Data Saved Successfully."

                    End If
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    DispGrid()
                End If

            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
                msgInfo.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
        End If
    End Sub
   
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then

            If btnDetails.Text = "VIEW" Then
                LinkButton1.Focus()
                msgInfo.Text = ""
                lblErrorMsg.Text = ""
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                DispGrid()
                ' clear()
            ElseIf btnDetails.Text = "BACK" Then
                btnSave.Text = "ADD"
                btnDetails.Text = "VIEW"
                clear()
                GridView1.PageIndex = ViewState("PageIndex")
                DispGrid()
                lblErrorMsg.Text = ""
                msgInfo.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not have Read Privilage."
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then
                el.TY_ID = CType(GridView1.Rows(e.RowIndex).FindControl("LID"), HiddenField).Value
                '  Bl.ChangeFlag(CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl
                Bl.ChangeFlag(el)
                GridView1.DataBind()
                lblErrorMsg.Text = ""
                msgInfo.Text = "Data Deleted Successfully."
                txtLeavetype.Focus()
                GridView1.PageIndex = ViewState("PageIndex")
                DispGrid()
                clear()
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
                msgInfo.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Sub DispGrid()
        el.TY_ID = 0
        GridView1.Enabled = True
        dt = Bl.GetLeavTypes(el)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
        Else
            ' lblErrorMsg.Visible = True
            msgInfo.Text = ""
            lblErrorMsg.Text = "No records to display."
            txtLeavetype.Focus()
        End If
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Leave Type")
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        If Session("Privilages").ToString.Contains("W") Then

            'If (Session("BranchCode") = Session("ParentBranch")) Then
            msgInfo.Text = ""
            lblErrorMsg.Text = ""
            btnSave.Text = "UPDATE"
            btnDetails.Text = "BACK"
            txtLeavetype.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
            txtDescription.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
            ddlpaid.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
            txtleavecode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
            ddlleavefor.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblLeaveFor"), Label).Text
            ViewState("TY_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("LID"), HiddenField).Value
            el.TY_ID = ViewState("TY_ID")
            dt = Bl.GetLeavTypes(el)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = False

            'Else
            'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
            'msgInfo.Text = ""
            'End If
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DispGrid()
        GridView1.Visible = True
        'lblErrorMsg.Visible = False
        'msgInfo.Visible = False
    End Sub
    Sub clear()
        txtLeavetype.Text = ""
        txtDescription.Text = ""
        txtleavecode.Text = ""
        ddlpaid.ClearSelection()
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
        el.TY_ID = 0
        GridView1.Enabled = True
        dt = Bl.GetLeavTypes(el)
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
End Class
