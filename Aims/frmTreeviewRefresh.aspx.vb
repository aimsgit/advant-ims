
Partial Class frmTreeviewRefresh
    Inherits BasePage
    Dim dt As New DataTable
    Dim a, b As Integer
    Dim GlobalFunction As New GlobalFunction

    Protected Sub DDLmodule_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLmodule.SelectedIndexChanged
        DispGrid()
    End Sub
    Sub DispGrid()
        panel1.Visible = True
        Dim Mid As Integer
        Dim dt As DataTable
        Mid = DDLmodule.SelectedValue
        'dt = blrole.Getrolemap(role)
        dt = TreeviewRefresh.Getuserformddl(Mid)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            'For Each grid As GridViewRow In GridView1.Rows
            '    If CType(grid.FindControl("hidChkbox"), HiddenField).Value = "Y" Then
            '        CType(grid.FindControl("ChkBx"), CheckBox).Checked = True
            '    Else
            '        CType(grid.FindControl("ChkBx"), CheckBox).Checked = False

            '    End If
            'Next
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

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            panel1.Visible = False
        End If
    End Sub

    Protected Sub btnupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnupdate.Click
        Dim id As String = ""
        Dim Mid As String = ""
        Dim Cid As String = ""
        Dim Modle As String = ""
        Dim child As String = ""
        Dim count As New Integer
        Dim institute As String = ""
        count = 0
        For Each grid As GridViewRow In GridView1.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                Modle = CType(grid.FindControl("MNIDAuto"), HiddenField).Value.ToString
                Mid = Modle + "," + Mid
                child = CType(grid.FindControl("CNIDAuto"), HiddenField).Value.ToString
                Cid = child + "," + Cid
                count = count + 1
            End If
        Next
        If count = 0 Then
            lblgreen.Text = ""
            lblmsg.Text = "Select the records"
        Else
            Mid = DDLmodule.SelectedValue
            Cid = Left(Cid, Cid.Length - 1)
            institute = DdlSelectClient.SelectedValue
            TreeviewRefresh.AssignModule(Mid, Cid, institute)
            lblgreen.Text = "Module Assigned Successfully."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnrefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        Dim Modle As String = ""
        Dim institute As String = ""
        Modle = DDLmodule.SelectedValue
        institute = DdlSelectClient.SelectedValue
        TreeviewRefresh.RefreshModule(Modle, institute)
        lblgreen.Text = "Module Refreshed Successfully."
        lblmsg.Text = ""
    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        Response.Redirect("Default2.aspx")
    End Sub

    Sub CheckAll()
        If CType(GridView1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkBx"), CheckBox).Checked = False
            Next
        End If
    End Sub
End Class
