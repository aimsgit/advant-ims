
Partial Class ManageUserRoles
    Inherits BasePage
    Dim GlobalFunction As New GlobalFunction
    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        RefreshAvailableRolesListBox()
        If ddlUserIDList.Items.Count > 0 AndAlso ddlUserIDList.SelectedIndex <> -1 Then
            RefreshCurrentRolesListBox(ddlUserIDList.SelectedItem.Text)
        End If
    End Sub
    Protected Sub btnAddUserToRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddUserToRole.Click
        If (ddlRolesList.SelectedIndex <> -1) Then
            Dim selectedRole As String = ddlRolesList.SelectedValue
            Dim selectedUserName As String = ddlUserIDList.SelectedItem.Text
            If Not Roles.IsUserInRole(selectedUserName, selectedRole) Then
                Try
                    Roles.AddUserToRole(selectedUserName, selectedRole)
                    RefreshCurrentRolesListBox(selectedUserName)
                Catch ex As Exception
                    lblResults.Text = "Could not add the user to the role: " + Server.HtmlEncode(ex.Message)
                    lblResults.Visible = True
                End Try
            Else
                ddlRolesList.SelectedIndex = -1
            End If
        End If
    End Sub
    Private Sub RefreshAvailableRolesListBox()
        Me.ddlRolesList.SelectedIndex = -1
        ddlRolesList.DataSource = Roles.GetAllRoles
        ddlRolesList.DataBind()
        If (ddlRolesList.Items.Count = 0) Then
            'lblRoleInfoText.Text = "There are currently no roles for this application."
            ddlRolesList.Visible = False
            btnAddUserToRole.Visible = False
        Else
            'lblRoleInfoText.Text = "The list of available roles is shown below."
            ddlRolesList.Visible = True
            btnAddUserToRole.Visible = True
        End If
    End Sub
    Private Sub RefreshCurrentRolesListBox(ByVal UserID As String)
        lbxUserRoles.SelectedIndex = -1
        'Could also call Roles.GetRolesForUser();
        ' lbxUserRoles.DataSource = (CType(UserID, RolePrincipal)).GetRoles
        lbxUserRoles.DataSource = Roles.GetRolesForUser(UserID)
        lbxUserRoles.DataBind()
        If (lbxUserRoles.Items.Count = 0) Then
            lblUserRoleInfoText.Text = "The user currently does not belong to any roles."
            lbxUserRoles.Visible = False
            btnDeleteUserFromRole.Visible = False
        Else
            lblUserRoleInfoText.Text = "The user having following roles."
            lbxUserRoles.Visible = True
            btnDeleteUserFromRole.Visible = True
        End If
        lbxType.DataSource = UserDetailsDB.GetTypeAndBranchByUID(Me.ddlUserIDList.SelectedValue).DefaultView
        lbxType.DataTextField = "Branch"
        lbxType.DataBind()
        lbltype.Text = "The user having following access level."
    End Sub
    Protected Sub ddlUserIDList_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUserIDList.DataBound
        If ddlUserIDList.Items.Count > 0 Then
            ddlUserIDList.SelectedIndex = 0
            Dim selectedUserName As String = ddlUserIDList.SelectedItem.Text
            RefreshCurrentRolesListBox(ddlUserIDList.SelectedItem.Text)
            RefreshCurrentRolesListBox(selectedUserName)
        Else
            lblUserRoleInfoText.Text = "The user currently does not belong to any roles."
            lbxUserRoles.Visible = False
            btnDeleteUserFromRole.Visible = False
        End If
    End Sub
    Protected Sub btnDeleteUserFromRole_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDeleteUserFromRole.Click
        Dim selectedRole As String = lbxUserRoles.SelectedValue
        If (lbxUserRoles.SelectedIndex <> -1) Then
            Try
                Roles.RemoveUserFromRole(ddlUserIDList.SelectedItem.Text, selectedRole)
                RefreshCurrentRolesListBox(ddlUserIDList.SelectedItem.Text)
            Catch ex As Exception
                lblResults.Text = "Could not remove the user from the role: " + Server.HtmlEncode(ex.Message)
                lblResults.Visible = True
            End Try
        End If
    End Sub
    Protected Sub ddlUserIDList_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlUserIDList.SelectedIndexChanged
        If ddlUserIDList.Items.Count > 0 Then
            'ddlUserIDList.SelectedIndex = 0
            'RefreshCurrentRolesListBox(ddlUserIDList.SelectedItem.Text)
            Dim selectedUserName As String = ddlUserIDList.SelectedItem.Text
            ' RefreshCurrentRolesListBox(ddlUserIDList.SelectedItem.Text)
            RefreshCurrentRolesListBox(selectedUserName)
        Else
            lblUserRoleInfoText.Text = "The user currently does not belong to any roles."
            lbxUserRoles.Visible = False
            btnDeleteUserFromRole.Visible = False
        End If
    End Sub
    Protected Sub AutoCompleteExtender2_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoCompleteExtender2.PreRender
        Try
            Session("sesInstitute") = HttpContext.Current.Session("InstituteID")
            Session("sesbranch") = HttpContext.Current.Session("BranchID")
            If txtEmp.Text <> "" Then
                Session("EMPID") = GlobalFunction.IdCutter(txtEmp.Text)
            End If
        Catch
            txtEmp.Text = "Not a valid Employee.Try again."
            txtEmp.ForeColor = Drawing.Color.Red
        End Try
    End Sub
    Protected Sub txtEmp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmp.TextChanged
        'ObjUser.SelectMethod = "GetOnlyUserNames"
        'ObjUser.SelectParameters.Clear()
        'ObjUser.SelectParameters.Add("EMPID", GlobalFunction.IdCutter(txtEmp.Text))
        'ObjUser.DataBind()
        'Me.ddlUserIDList.DataSourceID = "ObjUser"
        ddlUserIDList.Items.Clear()
        Dim eid As Long = GlobalFunction.IdCutter(txtEmp.Text)
        If eid <> 0 Then
            Dim dt As DataTable = UserDetailsDB.GetOnlyUserNames(eid)
            Me.ddlUserIDList.DataSource = dt.DefaultView
            ddlUserIDList.DataTextField = "UserName"
            ddlUserIDList.DataValueField = "UserDetailsID"
            ddlUserIDList.DataBind()
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rocount As Int16 = UserDetailsDB.Update(Me.ddlUserIDList.SelectedValue, Me.ddlInstitute.SelectedValue, Me.ddlBranch.SelectedValue)
        RefreshCurrentRolesListBox(Me.ddlUserIDList.SelectedItem.Text)
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Session("Admin") = 1 Then
                Dim Bll As New EmployeeManager
                Label2.Visible = True
                ddlBranch1.Visible = True
                ddlBranch1.DataSource = Bll.Getbranch()
                ddlBranch1.DataBind()
                Session("NweBranchID") = 0
            Else
                Label2.Visible = False
                ddlBranch1.Visible = False
            End If
        End If
    End Sub
    Protected Sub ddlBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.SelectedIndexChanged
        Session("NewBranchID") = ddlBranch1.SelectedValue
        txtEmp.Text = ""
    End Sub
End Class
