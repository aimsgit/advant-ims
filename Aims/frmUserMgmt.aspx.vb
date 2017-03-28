
Partial Class frmUserMgmt
    Inherits BasePage
    Dim gf As New RijndaelSimple
    Dim BLL As New BLUserManagement
    Dim prop As New UserManagement
    Dim dt As New DataTable
    Dim l As Integer
    Sub SplitName(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            HidempId.Value = parts(0).ToString()
            txtemp.Text = parts(1).ToString()
            txtEmpName.Text = parts(2).ToString()
            txtbranch.Text = parts(3).ToString()
            HidBanch.Value = parts(4).ToString()
            'txtEmpName.Text = parts(2).ToString()


            'ViewState("EmpID") = EmpID
        Else
            txtemp.AutoPostBack = True
        End If
    End Sub
    Protected Sub BtnaddRoles_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnaddRoles.Click
        txtuserid.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim StrArray As New ArrayList()
            Dim str As String = ddlRoles.SelectedItem.Text.ToString()
            Dim strIndex As String = ddlRoles.SelectedValue.ToString()
            If str <> "Select" Or strIndex <> "Select" Then
                Dim RoleAdd As Boolean = False
                lblErrorMsg.Text = ""
                If LBRoles.Items.Count > 0 Then
                    Dim i As Int32 = 0
                    For i = 0 To LBRoles.Items.Count - 1 Step 1
                        Dim q As String
                        q = LBRoles.Items(i).Text.ToString()
                        If q = str Then
                            lblErrorMsg.Text = ""
                            lblmsg.Text = ""
                            lblErrorMsg.Text = "This role is already added in the rolelist,duplicates are not allowed."
                            ddlRoles.Focus()
                            i = LBRoles.Items.Count
                            RoleAdd = True
                        End If
                    Next i
                    If RoleAdd = False Then
                        LBRoles.Items.Add(str)
                        RoleAddIndex.Items.Add(strIndex)
                    End If
                Else
                    LBRoles.Items.Add(str)
                    RoleAddIndex.Items.Add(strIndex)
                End If
                btnAddGrid.Focus()
            Else
                lblErrorMsg.Text = ""
                lblErrorMsg.Text = "Please select the Role."
                ddlRoles.Focus()
                lblmsg.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub BtnRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnAddGrid.Text = "ADD" Then
                If LBRoles.SelectedIndex <> -1 Then
                    RoleAddIndex.Items.RemoveAt(LBRoles.SelectedIndex)
                    LBRoles.Items.Remove(LBRoles.SelectedValue.ToString())
                    ddlRoles.SelectedIndex = 0
                    lblErrorMsg.Text = ""
                Else
                    If LBRoles.Items.Count <> 0 Then
                        lblErrorMsg.Text = ""
                        lblErrorMsg.Text = "Please select a role to remove from the list."
                        ddlRoles.Focus()
                        lblmsg.Text = ""
                    Else
                        lblErrorMsg.Text = ""
                        lblErrorMsg.Text = "There are no records in the list to remove."
                        lblmsg.Text = ""
                    End If
                End If
            Else
                If LBRoles.SelectedIndex <> -1 Then
                    LBRoles.Items.Remove(LBRoles.SelectedValue.ToString())
                    ddlRoles.SelectedIndex = 0
                    lblErrorMsg.Text = ""
                Else
                    If LBRoles.Items.Count <> 0 Then
                        lblErrorMsg.Text = ""
                        lblErrorMsg.Text = "Please select a role to remove from the list."
                        ddlRoles.Focus()
                        lblmsg.Text = ""
                    Else
                        lblErrorMsg.Text = ""
                        lblErrorMsg.Text = "There are no records in the list to remove."
                        lblmsg.Text = ""
                    End If
                End If
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot remove data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnAddGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddGrid.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                lblErrorMsg.Text = ""
                lblErrorMsg.Text = ""
                lblmsg.Text = ""
                If btnAddGrid.Text = "ADD" Then
                    If txtpassword.Text <> "" Then
                        If (txtpassword.Text.Contains(" ") Or txtverpass.Text.Contains(" ")) Then
                            lblErrorMsg.Text = "Password or Verify password cannot have Space."
                            txtpassword.Focus()
                            lblmsg.Text = ""
                            lblErrorMsg.Text = ""
                            lblmsg.Text = ""
                        Else
                            If txtpassword.Text = txtverpass.Text Then
                                If txtbranch.Text = "" Then
                                    lblErrorMsg.Text = "Employee's Branch Office is mandatory."
                                    txtbranch.Focus()
                                    lblmsg.Text = ""
                                    lblErrorMsg.Text = ""
                                Else
                                    If LBRoles.Items.Count <> 0 Then
                                        Dim s As String = ""
                                        Dim q As ListItem
                                        For Each q In RoleAddIndex.Items
                                            s = s + q.Text.ToString() + ","
                                        Next
                                        prop.Roles = s.Remove(s.Length - 1)
                                        s = ""
                                        If Chkread.Checked = True Then
                                            s = "R"
                                        End If
                                        If Chkwrite.Checked = True Then
                                            If s <> "" Then
                                                s = s + "," + "W"
                                            Else
                                                s = "W"
                                            End If
                                            If Chkprint.Checked = True Then
                                                If s <> "" Then
                                                    s = s + "," + "P"
                                                Else
                                                    s = "P"
                                                End If
                                            End If
                                        End If
                                        prop.BranchCode = HidBanch.Value
                                        Session("Empnum") = txtemp.Text.ToString()
                                        prop.UserName = txtPrefix.Text + txtuserid.Text
                                        'Begin edit by kusum, 6-12-2011
                                        prop.Password = RijndaelSimple.Encrypt(txtpassword.Text.ToString(), _
                                                           RijndaelSimple.passPhrase, _
                                                           RijndaelSimple.saltValue, _
                                                           RijndaelSimple.hashAlgorithm, _
                                                           RijndaelSimple.passwordIterations, _
                                                           RijndaelSimple.initVector, _
                                                           RijndaelSimple.keySize)
                                        'End edit by kusum, 6-12-2011
                                        prop.AccessLevel = ddlAccessLevel.SelectedValue
                                        prop.Privilages = s
                                        Dim defaultdate, edate As Date
                                        defaultdate = "1-1-2999"
                                        If txtExpDate.Text = "" Then
                                            prop.ExpDate = defaultdate
                                            edate = defaultdate
                                        Else
                                            prop.ExpDate = txtExpDate.Text
                                            edate = txtExpDate.Text
                                        End If
                                        If edate < Date.Today Then
                                            lblErrorMsg.Text = ""
                                            lblmsg.Text = ""
                                            lblErrorMsg.Text = "Expiry date cannot be past date."
                                            txtExpDate.Focus()
                                        ElseIf Chkread.Checked = False And Chkwrite.Checked = False And Chkprint.Checked = False Then
                                            lblErrorMsg.Text = ""
                                            lblmsg.Text = ""
                                            lblErrorMsg.Text = "Please select the privileges."
                                            Chkread.Focus()
                                        Else
                                            len(HidBanch.Value)
                                            If ViewState("access").Contains(ddlAccessLevel.SelectedValue) Then
                                                Dim j As Integer = BLL.InsertRecord(prop)
                                                If j = 1 Then
                                                    ClearAll()
                                                    GVUserMngmnt.PageIndex = ViewState("PageIndex")
                                                    DispGrid()
                                                    lblmsg.Text = ""
                                                    lblErrorMsg.Text = ""
                                                    lblmsg.Text = "Data added successfully."
                                                    RoleAddIndex.Items.Clear()
                                                Else
                                                    lblErrorMsg.Text = ""
                                                    lblmsg.Text = ""
                                                    lblErrorMsg.Text = "LogIn details for selected employee and user name already exist."
                                                End If
                                            Else
                                                lblErrorMsg.Text = ""
                                                lblmsg.Text = ""
                                                lblErrorMsg.Text = "Access level should be higher or equal to Branch selected in Employee Master."
                                                ddlAccessLevel.Focus()
                                            End If
                                        End If
                                    Else
                                        lblmsg.Text = ""
                                        lblmsg.Text = ""
                                        lblErrorMsg.Text = ""
                                        lblErrorMsg.Text = "Please add atleast one role."
                                        ddlRoles.Focus()
                                    End If
                                End If

                            Else
                                lblmsg.Text = ""
                                lblErrorMsg.Text = ""
                                lblErrorMsg.Text = "Password and Verify passwords are not matching."
                                txtpassword.Focus()
                            End If
                        End If

                    Else
                        lblmsg.Text = ""
                        lblErrorMsg.Text = ""
                        lblErrorMsg.Text = "Password and Verify passwords cannot be blank."
                        txtpassword.Focus()
                    End If
                Else
                    If txtpassword.Text <> "" And txtverpass.Text <> "" Then
                        If txtpassword.Text = txtverpass.Text Then
                            If LBRoles.Items.Count <> 0 Then
                                prop.BranchCode = HidBanch.Value
                                Session("Empnum") = txtemp.Text.ToString()
                                prop.UserName = txtPrefix.Text + txtuserid.Text
                                'Begin edit by kusum, 6-12-2011
                                prop.Password = RijndaelSimple.Encrypt(txtpassword.Text.ToString(), _
                                                   RijndaelSimple.passPhrase, _
                                                   RijndaelSimple.saltValue, _
                                                   RijndaelSimple.hashAlgorithm, _
                                                   RijndaelSimple.passwordIterations, _
                                                   RijndaelSimple.initVector, _
                                                   RijndaelSimple.keySize)
                                'End edit by kusum, 6-12-2011
                                prop.AccessLevel = ddlAccessLevel.SelectedValue
                                Dim defaultdate, edate As Date
                                defaultdate = "1-1-2999"
                                If txtExpDate.Text = "" Then
                                    prop.ExpDate = defaultdate
                                    edate = defaultdate
                                Else
                                    prop.ExpDate = txtExpDate.Text
                                    edate = txtExpDate.Text
                                End If
                                prop.UserDetailsID = CType(Session("UMID"), Int32)
                                Dim s As String = ""
                                If Chkread.Checked = True Then
                                    s = "R"
                                End If
                                If Chkwrite.Checked = True Then
                                    If s <> "" Then
                                        s = s + "," + "W"
                                    Else
                                        s = "W"
                                    End If
                                End If
                                If Chkprint.Checked = True Then
                                    If s <> "" Then
                                        s = s + "," + "P"
                                    Else
                                        s = "P"
                                    End If
                                End If

                                prop.Privilages = s
                                s = ""
                                Dim LBS As ListItem
                                For Each LBS In LBRoles.Items
                                    s = s + LBS.Text.ToString() + ","
                                Next
                                prop.Roles = BLL.GetRolesDetailsForUpdate(s.Remove(s.Length - 1))

                                If edate < Date.Today Then
                                    lblErrorMsg.Text = ""
                                    lblErrorMsg.Text = "Expiry date cannot be past date."
                                    txtExpDate.Focus()
                                    lblmsg.Text = ""
                                ElseIf Chkread.Checked = False And Chkwrite.Checked = False And Chkprint.Checked = False Then
                                    lblErrorMsg.Text = ""
                                    lblmsg.Text = ""
                                    lblErrorMsg.Text = "Please select the privileges."
                                    Chkread.Focus()
                                Else
                                    len(HidBanch.Value)
                                    If ViewState("access").Contains(ddlAccessLevel.SelectedValue) Then
                                        Dim j As Integer = BLL.UpdateRecord(prop)
                                        If j <> 0 Then
                                            prop.UserDetailsID = 0
                                            GVUserMngmnt.PageIndex = ViewState("PageIndex")
                                            DispGrid()
                                            ClearAll()
                                            btnAddGrid.Text = "ADD"
                                            BtnView.Text = "VIEW"
                                            lblErrorMsg.Text = ""
                                            lblmsg.Text = ""
                                            lblmsg.Text = "Data updated successfully."
                                            txtemp.Enabled = True
                                            txtuserid.Enabled = True
                                            txtpassword.Enabled = True
                                            txtverpass.Enabled = True
                                        Else
                                            DispGrid()
                                            ClearAll()
                                            lblErrorMsg.Text = ""
                                            lblmsg.Text = ""
                                            lblErrorMsg.Text = "Data cannot be updated."
                                        End If
                                    Else
                                        lblErrorMsg.Text = ""
                                        lblErrorMsg.Text = "Access level should be higher or equal to Branch selected in Employee Master."
                                        ddlAccessLevel.Focus()
                                        lblmsg.Text = ""
                                    End If
                                End If
                            Else
                                lblmsg.Text = ""
                                lblErrorMsg.Text = ""
                                lblmsg.Text = ""
                                lblErrorMsg.Text = "Please add atleast one role."
                                ddlRoles.Focus()
                            End If
                        Else
                            lblmsg.Text = ""
                            lblErrorMsg.Text = ""
                            lblmsg.Text = ""
                            lblErrorMsg.Text = "Password and Verify passwords are not matching."
                            txtpassword.Focus()
                        End If
                    Else
                        lblmsg.Text = ""
                        lblErrorMsg.Text = ""
                        lblmsg.Text = ""
                        lblErrorMsg.Text = "Password and Verify passwords cannot be blank."
                        txtpassword.Focus()
                    End If
                End If
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
                lblmsg.Text = ""
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct date."
            lblmsg.Text = ""
        End Try
    End Sub
    Sub ClearAll()
        txtbranch.Text = ""
        txtemp.Text = ""
        txtEmpName.Text = ""
        lblErrorMsg.Text = ""
        lblmsg.Text = ""
        txtsrchemp.Text = ""
        txtpassword.Attributes.Clear()
        txtverpass.Attributes.Clear()
        ddlRoles.ClearSelection()
        txtsrchuser.Text = ""
        txtuserid.Text = ""
        txtverpass.Text = ""
        Chkprint.Checked = False
        Chkread.Checked = False
        Chkwrite.Checked = False
        LBRoles.Items.Clear()
        ddlAccessLevel.SelectedIndex = 0
        txtExpDate.Text = ""
    End Sub

    Protected Sub GVUserMngmnt_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVUserMngmnt.PageIndexChanging
        lblErrorMsg.Text = ""
        GVUserMngmnt.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVUserMngmnt.PageIndex
        DispGrid()
    End Sub

    Protected Sub GVUserMngmnt_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVUserMngmnt.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If CType(GVUserMngmnt.Rows(e.RowIndex).Cells(1).FindControl("lblEmp_Name"), Label).Text <> "" Then
                prop.UserDetailsID = CType(GVUserMngmnt.Rows(e.RowIndex).Cells(1).FindControl("HidUDID"), Label).Text
                BLL.DeleteRecord(prop)
                prop.UserDetailsID = 0
                GVUserMngmnt.PageIndex = ViewState("PageIndex")
                DispGrid()
                lblErrorMsg.Text = ""
                lblmsg.Text = ""
                lblmsg.Text = "Data deleted successfully."
                lblErrorMsg.Text = ""
            Else
                lblErrorMsg.Text = "You cannot delete Institute admin record."
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GVUserMngmnt_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVUserMngmnt.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Try
            If CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblEmp_Name"), Label).Text <> "" Then
                Session("UMID") = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("HidUDID"), Label).Text
                prop.UserDetailsID = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("HidUDID"), Label).Text
                txtuserid.Text = Right(CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblUserName"), Label).Text, CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblUserName"), Label).Text.Length - txtPrefix.Text.Trim.Length)
                txtuserid.Enabled = False
                'Begin edit by kusum, 6-12-2011
                txtpassword.Text = RijndaelSimple.Decrypt(CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblPassword"), Label).Text, _
                                                   RijndaelSimple.passPhrase, _
                                                   RijndaelSimple.saltValue, _
                                                   RijndaelSimple.hashAlgorithm, _
                                                   RijndaelSimple.passwordIterations, _
                                                   RijndaelSimple.initVector, _
                                                   RijndaelSimple.keySize)
                txtpassword.Attributes.Add("value", txtpassword.Text)
                txtpassword.Enabled = False
                txtverpass.Text = RijndaelSimple.Decrypt(CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblPassword"), Label).Text, _
                                                   RijndaelSimple.passPhrase, _
                                                   RijndaelSimple.saltValue, _
                                                   RijndaelSimple.hashAlgorithm, _
                                                   RijndaelSimple.passwordIterations, _
                                                   RijndaelSimple.initVector, _
                                                   RijndaelSimple.keySize)
                txtverpass.Attributes.Add("value", txtverpass.Text)
                txtverpass.Enabled = False
                'End edit by kusum, 6-12-2011
                txtemp.Text = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblEmpNo"), Label).Text
                txtEmpName.Text = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblEmp_Name"), Label).Text
                txtbranch.Text = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblBranch"), Label).Text
                txtExpDate.Text = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblExpDate"), Label).Text
                ddlAccessLevel.SelectedValue = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblALcode"), Label).Text
                Dim R As String = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblRolesName"), Label).Text
                Dim Privilage As String = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblPrivilages"), Label).Text
                HidBanch.Value = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblCode"), Label).Text
                DispGrid()
                Dim RolesArray As Array = R.Split(",")
                Dim i As Int32 = 0

                For i = 0 To RolesArray.Length - 1 Step 1
                    LBRoles.Items.Add(RolesArray(i))
                Next
                Dim PrivilageArray As Array = Privilage.Split(",")
                Privilage = ""
                For Each Privilage In PrivilageArray
                    If Privilage = "R" Then
                        Chkread.Checked = True
                    End If
                    If Privilage = "P" Then
                        Chkprint.Checked = True
                    End If
                    If Privilage = "W" Then
                        Chkwrite.Checked = True
                    End If
                Next
                GVUserMngmnt.Enabled = False
                txtbranch.Enabled = False
                txtemp.Enabled = False
                txtuserid.Enabled = False
                BtnView.Text = "BACK"
                btnAddGrid.Text = "UPDATE"
            Else
                lblErrorMsg.Text = "You cannot edit Institute admin record."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Add prefix, please contact Advant Technologies Inc. for adding prefix."
        End Try
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtsrchemp.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        Try
            txtPrefix.Text = Session("UserPrefix").ToString
            txtbranch.Enabled = False
            If IsPostBack Then
                If Not String.IsNullOrEmpty(txtpassword.Text.Trim()) Then
                    txtpassword.Attributes.Add("value", txtpassword.Text)
                End If
                If Not String.IsNullOrEmpty(txtverpass.Text.Trim()) Then
                    txtverpass.Attributes.Add("value", txtverpass.Text)
                End If
            End If
            If txtemp.Text <> "" Then
                SplitName(txtemp.Text)
            Else
                txtemp.AutoPostBack = True
                txtEmpName.Text = ""
                SplitName(txtemp.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        LinkButton1.Focus()
        lblmsg.Text = ""
        If BtnView.Text = "BACK" Then
            lblmsg.Text = ""
            lblErrorMsg.Text = ""
            txtuserid.Enabled = True
            txtpassword.Enabled = True
            txtverpass.Enabled = True
            btnAddGrid.Text = "ADD"
            BtnView.Text = "VIEW"
            ClearAll()
            GVUserMngmnt.PageIndex = ViewState("PageIndex")
            DispGrid()
            txtbranch.Enabled = False
            txtemp.Enabled = True
        Else
            'ClearAll()
            lblmsg.Text = ""
            lblErrorMsg.Text = ""
            ViewState("PageIndex") = 0
            GVUserMngmnt.PageIndex = 0
            DispGrid()
        End If
    End Sub
    Sub DispGrid()
        Try
            GVUserMngmnt.Visible = True
            GVUserMngmnt.Enabled = True
            lblErrorMsg.Text = ""
            lblmsg.Text = ""
            Dim dt1 As New DataTable
            dt1 = BLL.GetUserDetails(prop)
            If dt1.Rows.Count <> 0 Or Not dt1 Is Nothing Then
                GVUserMngmnt.DataSource = dt1
                GVUserMngmnt.DataBind()
                'Dim s As String = ""
                For Each row As GridViewRow In GVUserMngmnt.Rows
                    If CType(row.FindControl("lblExpDate"), Label).Text = "01-Jan-2999" Then
                        CType(row.FindControl("lblExpDate"), Label).Text = ""
                    End If
                Next
                GVUserMngmnt.Enabled = True
            Else
                lblErrorMsg.Text = "No records to display."
                lblmsg.Text = ""
                GVUserMngmnt.Visible = False
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "No records to display."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub Btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsearch.Click

        lblmsg.Text = ""
        lblErrorMsg.Text = ""
        If txtsrchuser.Text <> "" Or txtsrchemp.Text <> "" Then
            dt = BLL.GetSearchUserDetails(txtsrchuser.Text, txtsrchemp.Text)
            If dt.Rows.Count > 0 Then
                GVUserMngmnt.DataSource = dt
                GVUserMngmnt.DataBind()
                GVUserMngmnt.Visible = True


            Else
                lblErrorMsg.Text = "No search result found."
                txtsrchemp.Focus()
                lblmsg.Text = ""
                'lblErrorMsg.Text = ""
                lblmsg.Text = ""
                GVUserMngmnt.Visible = False
            End If
        Else
            lblErrorMsg.Text = "Please enter the search criteria."
            txtsrchemp.Focus()
            lblmsg.Text = ""
            lblErrorMsg.Text = ""
        End If

    End Sub

    Sub len(ByVal k As String)
        Dim i As Integer
        For i = k.Length - 1 To 0 Step -1
            If k(i) = "0" Then
                k = k.Remove(i, 1)
            Else
                i = 0
            End If
        Next
        Dim len As Integer = k.Length
        If len = 4 OrElse len = 3 OrElse len = 2 OrElse len = 1 OrElse len = 0 Then
            ViewState("access") = "01"
        ElseIf len = 6 Then
            ViewState("access") = "01,02"
        ElseIf len = 8 OrElse len = 7 Then
            ViewState("access") = "01,02,03"
        ElseIf len = 10 OrElse len = 9 Then
            ViewState("access") = "01,02,03,04"
        ElseIf len = 12 OrElse len = 11 Then
            ViewState("access") = "01,02,03,04,05"
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVUserMngmnt_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVUserMngmnt.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt1 As New DataTable
        dt1 = BLL.GetUserDetails(prop)
        Dim sortedView As New DataView(dt1)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVUserMngmnt.DataSource = sortedView
        GVUserMngmnt.DataBind()
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
