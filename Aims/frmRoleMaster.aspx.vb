Imports System.IO
Partial Class frmRoleMaster
    Inherits BasePage
    Dim BLL As New BLRoleMaster
    Dim dt As New DataTable
    Dim a As Integer
    Dim GlobalFunction As New GlobalFunction


    Protected Sub Btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        txtUserRole.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Dim prop As New RoleMaster
                prop.UserRole = txtUserRole.Text
                If Btnadd.Text = "ADD" Then

                    'lblErrorMsg.Visible = True
                    Dim roledt As New DataTable
                    Dim Id As New Integer
                    Id = 0
                    roledt = BLL.GetDuplicateRoleMaster(txtUserRole.Text, Id)
                    If roledt.Rows.Count > 0 Then
                        lblErrorMsg.Text = "Data already exists."
                        lblgreen.Text = ""
                    Else
                        Dim i As Int32 = BLL.InsertRecord(prop)
                        ViewState("PageIndex") = 0
                        GVRoleMaster.PageIndex = 0

                        DispGrid()
                        If i <> 0 Then
                            lblgreen.Text = "Data added successfully."
                            lblErrorMsg.Text = ""
                            txtUserRole.Text = ""
                        Else
                            lblErrorMsg.Text = "Duplicate Entry."
                            lblgreen.Text = ""
                        End If
                    End If
                    ' txtUserRole.Text = ""
                Else
                    Dim roledt As New DataTable
                    Dim Id As New Integer
                    Id = ViewState("ID")
                    roledt = BLL.GetDuplicateRoleMaster(txtUserRole.Text, Id)
                    If roledt.Rows.Count > 0 Then
                        lblErrorMsg.Text = "Data already exists."
                        lblgreen.Text = ""
                    Else
                        Dim i As Int32 = BLL.UpdateRecord(prop)
                        'lblErrorMsg.Visible = True
                        Btnadd.Text = "ADD"
                        BtnView.Text = "VIEW"
                        GVRoleMaster.PageIndex = ViewState("PageIndex")
                        DispGrid()
                        If i <> 0 Then
                            lblgreen.Text = "Data updated successfully."
                            lblErrorMsg.Text = ""
                            txtUserRole.Text = ""
                        Else
                            lblErrorMsg.Text = "Duplicate Entry."
                            lblgreen.Text = ""
                        End If
                        'txtUserRole.Text = ""
                    End If
                End If
            Else
                lblErrorMsg.Text = "No Write Permission!"
                lblgreen.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblgreen.Text = ""
        End If
    End Sub
    Sub DispGrid()
        Dim prop As New RoleMaster
        dt = BLL.GetRoleMasterRecords(prop)
        If dt.Rows.Count > 0 Then
            GVRoleMaster.DataSource = dt
            GVRoleMaster.DataBind()
            GVRoleMaster.Enabled = True
            'txtUserRole.Text = ""
        Else
            lblErrorMsg.Text = "No records to display."
            lblgreen.Text = ""
        End If
    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        LinkButton1.Focus()
        lblErrorMsg.Text = ""
        lblgreen.Text = ""
        a = GlobalFunction.UserPrivilage()
        If a = 1 Or a = 2 Or a = 3 Or a = 4 Then
            If BtnView.Text = "BACK" Then
                Btnadd.Text = "ADD"
                BtnView.Text = "VIEW"
                GVRoleMaster.PageIndex = ViewState("PageIndex")
                DispGrid()
                txtUserRole.Text = ""
            Else
                ViewState("PageIndex") = 0
                GVRoleMaster.PageIndex = 0
                DispGrid()
            End If
        Else
            lblErrorMsg.Text = "No Read Permission!"
            lblgreen.Text = ""
        End If
    End Sub

    Protected Sub GVRoleMaster_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVRoleMaster.PageIndexChanging
        'lblErrorMsg.Visible = False
        'lblgreen.Visible = False
        GVRoleMaster.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVRoleMaster.PageIndex
        DispGrid()
    End Sub

    Protected Sub GVRoleMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVRoleMaster.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Dim Prop As New RoleMaster
                Prop.UserRoleID = CType(GVRoleMaster.Rows(e.RowIndex).FindControl("Label5"), Label).Text
                BLL.DeleteRecord(Prop)
                'lblErrorMsg.Visible = True
                'lblgreen.Visible = True
                GVRoleMaster.PageIndex = ViewState("PageIndex")
                DispGrid()

                lblgreen.Text = "Data deleted successfully."
                txtUserRole.Focus()
                txtUserRole.Text = ""
                lblErrorMsg.Text = ""
                txtUserRole.Text = ""
            Else
                lblErrorMsg.Text = "No Delete Permission!"
                lblgreen.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblgreen.Text = ""
        End If
    End Sub

    Protected Sub GVRoleMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVRoleMaster.RowEditing
        lblErrorMsg.Text = ""
        lblgreen.Text = ""
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        a = GlobalFunction.UserPrivilage()
        If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
            Btnadd.Text = "UPDATE"
            BtnView.Text = "BACK"
            'lblErrorMsg.Visible = False
            Session("UserRoleID") = CType(GVRoleMaster.Rows(e.NewEditIndex).Cells(1).FindControl("Label5"), Label).Text
            ViewState("ID") = CType(GVRoleMaster.Rows(e.NewEditIndex).Cells(1).FindControl("Label5"), Label).Text
            txtUserRole.Text = CType(GVRoleMaster.Rows(e.NewEditIndex).Cells(1).FindControl("lblUserRole"), Label).Text
            Dim prop As New RoleMaster
            prop.UserRoleID = Session("UserRoleID")


            dt = BLL.GetRoleMasterRecords(prop)
            GVRoleMaster.DataSource = dt
            GVRoleMaster.DataBind()
            GVRoleMaster.Enabled = False
        Else
            lblErrorMsg.Text = "No Edit Permission!"
            lblgreen.Text = ""
        End If
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblgreen.Text = ""
        'End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtUserRole.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub
    Protected Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        Dim sw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.Clear()
        Response.ClearHeaders()
        Response.ClearContent()
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254")
        Response.Charset = "windows-1254"

        Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
        Page.Response.AddHeader("content-disposition", "attachment;filename=RoleMaster.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        GVRoleMaster.Parent.Controls.Add(frm)
        frm.Controls.Add(GVRoleMaster)
        frm.RenderControl(hw)
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVRoleMaster_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVRoleMaster.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim prop As New RoleMaster
        dt = BLL.GetRoleMasterRecords(prop)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVRoleMaster.DataSource = sortedView
        GVRoleMaster.DataBind()
        GVRoleMaster.Enabled = True
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
