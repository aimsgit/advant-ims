Imports System.IO
Partial Class frmRolemap
    Inherits BasePage
    Dim role As New Rolemap
    Dim blrole As New BLRolemap
    Dim dt As New DataTable
    Dim a, b As Integer
    Dim GlobalFunction As New GlobalFunction

    Sub DispGrid()
        '25-11-2010 Kusum.C.Akki binding the data to grid'
        Dim role As New Rolemap
        Dim dt As DataTable
        role.RoleCode = DDLuserrole.SelectedValue
        'dt = blrole.Getrolemap(role)
        dt = blrole.Getuserformddl(role)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            For Each grid As GridViewRow In GridView1.Rows
                If CType(grid.FindControl("hidChkbox"), HiddenField).Value = "Y" Then
                    CType(grid.FindControl("ChkBx"), CheckBox).Checked = True
                Else
                    CType(grid.FindControl("ChkBx"), CheckBox).Checked = False

                End If
            Next
            GridView1.Enabled = True
            GridView1.Visible = True
            btnupdate.Enabled = True
        Else
            lblgreen.Text = ""
            lblmsg.Text = "No Records to Display ."
            GridView1.Visible = False
            btnupdate.Enabled = False
        End If
    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        LinkButton1.Focus()
        lblmsg.Text = ""
        lblgreen.Text = ""
        a = GlobalFunction.UserPrivilage()
        If a = 1 Or a = 2 Or a = 3 Or a = 4 Then
            DispGrid()
        Else
            lblgreen.Text = ""
            lblmsg.Text = "No Read Permission!"
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                blrole.Delete(CType(GridView1.Rows(e.RowIndex).FindControl("LabelRMID"), HiddenField).Value)
                lblgreen.Text = "Data Deleted Successfully."
                DDLuserrole.Focus()
                lblmsg.Text = ""
                DispGrid()

            Else
                lblgreen.Text = ""
                lblmsg.Text = "No Delete Permission!"
            End If
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblgreen.Text = ""
        End If
    End Sub

    Protected Sub btnupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim id As String = ""
            Dim check As String = ""
            Dim count As New Integer
            count = 0
            For Each grid As GridViewRow In GridView1.Rows
                If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("hidCode"), HiddenField).Value.ToString
                    id = check + "," + id
                    count = count + 1
                End If
            Next

            If id = "" Then
                id = "0"
                count = 1
            Else
                id = Left(id, id.Length - 1)
            End If


            If count = 0 Then
                lblgreen.Text = ""
                lblmsg.Text = "Select the records"
            Else
                role.RoleCode = DDLuserrole.SelectedValue
                role.ID = id
                blrole.UpdateRecord(role)
                lblgreen.Text = "Data Updated Successfully."
                lblmsg.Text = ""
                DispGrid()
            End If
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot update data."
            lblgreen.Text = ""
        End If
    End Sub

    Sub CheckAll()
        If CType(GridView1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = True
                btnupdate.Focus()
            Next
            btnupdate.Enabled = True
        Else
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = False

            Next
            btnupdate.Enabled = True
        End If
    End Sub

    Protected Sub DDLuserrole_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLuserrole.SelectedIndexChanged
        GridView1.Visible = False

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DDLuserrole.Focus()
        btnupdate.Enabled = False
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
        Page.Response.AddHeader("content-disposition", "attachment;filename=RoleMap.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        GridView1.Parent.Controls.Add(frm)
        frm.Controls.Add(GridView1)
        frm.RenderControl(hw)
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class