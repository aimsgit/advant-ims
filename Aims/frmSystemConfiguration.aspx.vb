
Partial Class frmSystemConfiguration
    Inherits BasePage
    Dim Config As New SystemConfiguration
    Dim blConfig As New BLSystemConfiguration
    Dim dt As New DataTable
    Dim a As Integer
    Dim GlobalFunction As New GlobalFunction

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                If BtnSave.Text = "ADD" Then
                    If txtDate.Text = "" Then
                        Config.ConfigDate = "1/1/1900"
                    Else
                        Config.ConfigDate = txtDate.Text
                    End If
                    Config.BranchCode = DdlSelectBranch.SelectedValue
                    Config.Name = txtName.Text
                    Config.Value = txtValue.Text
                    Config.Description = txtDescription.Text
                    Config.ReadOnlys = ddlReadOnly.SelectedValue
                    blConfig.InsertRecord(Config)
                    lblmsg.Text = "Data Saved Successfully."
                    lblErrorMsg.Text = ""
                    Clear()
                    DisplayGrid()
                ElseIf BtnSave.Text = "UPDATE" Then
                    If txtDate.Text = "" Then
                        Config.ConfigDate = "1/1/1900"
                    Else
                        Config.ConfigDate = txtDate.Text
                    End If
                    Config.BranchCode = DdlSelectBranch.SelectedValue
                    Config.configID = Session("ConfigID")
                    Config.Name = txtName.Text
                    Config.Value = txtValue.Text
                    Config.Description = txtDescription.Text
                    Config.ReadOnlys = ddlReadOnly.SelectedValue
                    blConfig.UpdateRecord(Config)
                    lblmsg.Text = "Data Updated successfully."
                    lblErrorMsg.Text = ""
                    DdlSelectBranch.Enabled = True
                    DdlSelectClient.Enabled = True
                    lblErrorMsg.Text = ""
                    Config.configID = 0
                    BtnSave.Text = "ADD"
                    BtnView.Text = "VIEW"
                    Clear()
                    DisplayGrid()
                End If
            Else
                lblErrorMsg.Text = "No Write Permission"
                lblmsg.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If

    End Sub
    Sub Clear()
        txtName.Text = ""
        txtValue.Text = ""
        txtDate.Text = ""
        txtDescription.Text = ""
    End Sub
    Sub DisplayGrid()
        Config.BranchCode = DdlSelectBranch.SelectedValue
        dt = blConfig.DisplayRecord(Config)
        GridView1.DataSource = dt
        If dt.Rows.Count = 0 Then
            GridView1.Visible = False
            lblErrorMsg.Text = "No Records to display."
        Else
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataBind()
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("LblDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("LblDate"), Label).Text = ""
                End If
            Next
        End If

    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Clear()
        lblmsg.Text = ""
        lblErrorMsg.Text = ""
        a = GlobalFunction.UserPrivilage()
        If a = 1 Or a = 2 Or a = 3 Or a = 4 Then
            If BtnView.Text = "VIEW" Then
                DisplayGrid()
            ElseIf BtnView.Text = "BACK" Then
                Clear()
                BtnSave.Text = "ADD"
                BtnView.Text = "VIEW"
                Config.configID = 0
                DisplayGrid()
            End If
            DdlSelectBranch.Enabled = True
            DdlSelectClient.Enabled = True
        Else
            lblErrorMsg.Text = "No Read Permission"
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        DisplayGrid()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Config.configID = CType(GridView1.Rows(e.RowIndex).FindControl("LblConfigID"), Label).Text
                If Left(CType(GridView1.Rows(e.RowIndex).FindControl("lblBranch"), Label).Text, 4) <> "0000" Then
                    blConfig.ChangeFlag(Config)
                    Config.configID = 0
                    DisplayGrid()
                    lblmsg.Text = "Data Deleted Successfully."
                    lblErrorMsg.Text = ""
                Else
                    lblErrorMsg.Text = "Cannot delete this data."
                    lblmsg.Text = ""
                End If
            Else
                lblmsg.Text = ""
                lblErrorMsg.Text = "No Delete Permission"
            End If
        Else
            lblmsg.Text = ""
            lblErrorMsg.Text = "No Delete Permission"
        End If
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblmsg.Text = ""
        lblErrorMsg.Text = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                lblErrorMsg.Text = ""
                BtnSave.Visible = True
                BtnSave.Text = "UPDATE"
                BtnView.Text = "BACK"
                Dim str As String = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblDate"), Label).Text
                If str = "1/1/1900" Then
                    txtDate.Text = ""
                Else
                    txtDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblDate"), Label).Text
                End If
                Session("ConfigID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblConfigID"), Label).Text
                txtName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblName"), Label).Text
                txtValue.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblValue"), Label).Text
                txtDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblDate"), Label).Text
                txtDescription.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblDesc"), Label).Text
                ddlReadOnly.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblReadOnly"), Label).Text
                Config.configID = Session("ConfigID")
                Config.BranchCode = DdlSelectBranch.SelectedValue
                dt = blConfig.DisplayRecord(Config)
                'to display all the data in grid
                DisplayGrid()
                DdlSelectBranch.Enabled = False
                DdlSelectClient.Enabled = False
                GridView1.Enabled = False
            Else
                lblErrorMsg.Text = "No Edit Permission"
                lblmsg.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("BranchCode") <> "000000000000" Then
            Response.Redirect("AccessDenied.aspx")
        Else
            'lblErrorMsg.Text = ""
            'lblmsg.Text = ""
            If Not IsPostBack Then
                DdlSelectClient.SelectedValue = "0000"
            End If
        End If
    End Sub

    Protected Sub BtnDefault_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDefault.Click
        Config.BranchCode = DdlSelectBranch.SelectedValue
        DLSystemConfiguration.GetDefault(Config)
        lblmsg.Text = "Default Configuration(s) Saved Successfully."
        lblErrorMsg.Text = ""
        DisplayGrid()
    End Sub
End Class
