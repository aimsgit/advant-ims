
Partial Class FrmCadreMgmtUGC
    Inherits BasePage
    Dim dt As New DataTable
    Dim EL As New ELCadreMgmt
    Dim BL As New BLCadreMgmt
    Dim DL As New DLCadreMgmt

    Sub clear()
        'ddlUniversity.Text = "0"
        'ddlProgram.Text = "0"
        'ddlProj.Text = "0"
        'txtDept.Text = ""
        'If (ddlSalCodeGrd.SelectedItem.Text <> "Select") Then
        '    ddlSalCodeGrd.SelectedItem.Text = "Select"
        '    txtYear1.Text = ""
        '    txtNo1.Text = ""
        '    txtYear2.Text = ""
        '    txtNo2.Text = ""
        '    txtRemarks.Text = ""
        '    Exit Sub
        'Else
        '    ddlSalCodeGrd.SelectedItem.Text = "Select"
        '    txtYear1.Text = ""
        '    txtNo1.Text = ""
        '    txtYear2.Text = ""
        '    txtNo2.Text = ""
        '    txtRemarks.Text = ""
        'End If
        'ddlDesig.Text = "0"
        'ddlSalCodeGrd.SelectedItem.Text = " Select"
        txtYear1.Text = ""
        txtNo1.Text = ""
        txtYear2.Text = ""
        txtNo2.Text = ""
        txtRemarks.Text = ""
    End Sub
    Sub DisplayGrid()
        Dim dt As New DataTable
        EL.Id = 0
        'dt = BL.GetCadreMgmt(EL)
        If dt.Rows.Count <> 0 Then
            GvCadreMgmt.DataSource = dt
            GvCadreMgmt.DataBind()
            GvCadreMgmt.Enabled = True
            GvCadreMgmt.Visible = True
        Else
            GvCadreMgmt.Enabled = False
            GvCadreMgmt.Visible = False
            lblMsg.Text = ""
            msginfo.Text = "No records to display."
        End If
    End Sub
    'Protected Sub btnDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click
    '    If btnDet.Text <> "BACK" Then
    '        lblmsg.Text = ""
    '        msginfo.Text = ""
    '        ViewState("PageIndex") = 0
    '        GvCapacity.PageIndex = 0
    '        DisplayGrid()
    '        GvCapacity.Visible = True
    '    Else
    '        lblmsg.Text = ""
    '        msginfo.Text = ""
    '        btnDet.Text = "VIEW"
    '        InsertButton.Text = "ADD"
    '        GvCapacity.PageIndex = ViewState("PageIndex")
    '        DisplayGrid()
    '        clear()
    '    End If
    'End Sub

    'Protected Sub GvCapacity_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvCapacity.RowDeleting
    '    If (Session("BranchCode") = Session("ParentBranch")) Then
    '        EL.Id = CType(GvCapacity.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
    '        BL.ChangeFlag(EL)
    '        lblmsg.Text = "Data deleted successfully."
    '        msginfo.Text = ""
    '        GvCapacity.PageIndex = ViewState("PageIndex")
    '        DisplayGrid()
    '    Else
    '        msginfo.Text = ""
    '        lblmsg.Text = ""
    '    End If
    'End Sub

    'Protected Sub GvCapacity_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvCapacity.RowEditing

    'End Sub

    Protected Sub btnADD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnADD.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If btnADD.CommandName = "UPDATE" Then


                    EL.University = ddlUniversity.SelectedValue
                    EL.Program = ddlProgram.SelectedValue
                    EL.Project = ddlProj.SelectedValue
                    EL.Department = txtDept.Text
                    EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text

                    EL.Designation = ddlDesig.SelectedValue
                    EL.ApprovedYear = txtYear1.Text
                    EL.ApprovedNo = txtNo1.Text
                    EL.RequiredYear = txtYear2.Text
                    EL.RequiredNo = txtNo2.Text
                    EL.Remarks = txtRemarks.Text
                    EL.Id = ViewState("Cadreid")
                    If BL.ChkLockSummary(EL).Tables(0).Rows(0).Item(0) = "Y" Then
                        msginfo.Text = "Record Locked: Can't Edit"
                        lblMsg.Text = ""
                    Else
                        'dt = BL.CheckDuplicate(EL)
                        BL.Update(EL)

                        btnADD.CommandName = "ADD"
                        'GridView1.Visible = True
                        btnView.CommandName = "VIEW"
                        lblMsg.Text = "Data updated successfully"
                        clear()
                        ViewState("PageIndex") = 0
                        DispGrid()
                        btnView.Text = "VIEW"
                        btnADD.Text = "ADD"
                        btnView.CommandName = "VIEW"
                        btnADD.CommandName = "ADD"
                    End If
                ElseIf btnADD.Text = "ADD" Then
                    EL.University = ddlUniversity.SelectedValue
                    EL.Program = ddlProgram.SelectedValue
                    EL.Project = ddlProj.SelectedValue
                    EL.Department = txtDept.Text
                    If (ddlSalCodeGrd.SelectedItem.Text = " Select") Then
                        msginfo.Text = "Salary Code is mandatory field"
                        lblMsg.Text = ""
                        Exit Sub
                    Else
                        EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text
                    End If

                    EL.Designation = ddlDesig.SelectedValue
                    EL.ApprovedYear = txtYear1.Text
                    EL.ApprovedNo = txtNo1.Text
                    EL.RequiredYear = txtYear2.Text
                    EL.RequiredNo = txtNo2.Text
                    EL.Remarks = txtRemarks.Text
                    ''dt = BL.CheckDuplicate(EL)
                    'If dt.Rows.Count > 0 Then
                    '    lblmsg.Text = ""
                    '    msginfo.Text = "Data already exists"
                    '    btnADD.CommandName = "ADD"
                    '    btnView.CommandName = "VIEW"
                    '    'clear()
                    'Else
                    '    EL.University = ddlUniversity.SelectedValue
                    '    EL.Program = ddlProgram.SelectedValue
                    '    EL.Project = ddlProj.SelectedValue
                    '    EL.Department = txtDept.Text
                    '    EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text
                    '    EL.Designation = ddlDesig.SelectedValue
                    '    EL.ApprovedYear = txtYear1.Text
                    '    EL.ApprovedNo = txtNo1.Text
                    '    EL.RequiredYear = txtYear2.Text
                    '    EL.RequiredNo = txtNo2.Text
                    '    EL.Remarks = txtRemarks.Text
                    Dim i As New Integer
                    i = BL.Insert(EL)
                    lblMsg.Text = "Data added successfully"
                    msginfo.Text = ""
                    clear()
                    ViewState("PageIndex") = 0
                    GvCadreMgmt.PageIndex = 0
                    DispGrid()
                    GvCadreMgmt.Visible = True

                End If
            End If


        Catch ex As Exception
            'msginfo.Text = ValidationMessage(1118)
            'lblmsg.Text = ValidationMessage(1014)
        End Try
    End Sub
    Sub DispGrid()
        pnllabel.Visible = True
        GvCadreMgmt.Visible = True
        'If ddlUniversity.SelectedValue = "" Then
        '    ddlUniversity.SelectedValue = 0
        'Else
        '    EL.University = ddlUniversity.SelectedValue
        'End If

        'If ddlProgram.SelectedValue = "" Then
        '    ddlProgram.SelectedValue = 0
        'Else
        '    EL.Program = ddlProgram.SelectedValue
        'End If

        'If ddlProj.SelectedValue = "" Then
        '    ddlProj.SelectedValue = 0
        'Else
        '    EL.Project = ddlProj.SelectedValue
        'End If
        'If ddlSalCodeGrd.SelectedItem.Text = "" Then
        '    ddlSalCodeGrd.SelectedItem.Text = 0
        'Else
        '    EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text
        'End If

        'If ddlDesig.SelectedValue = "" Then
        '    ddlDesig.SelectedValue = 0
        'Else
        '    EL.Designation = ddlDesig.SelectedValue
        'End If



        EL.Id = 0
        EL.Program = ddlProgram.SelectedValue
        EL.University = ddlUniversity.SelectedValue
        EL.Project = ddlProj.SelectedValue
        EL.Department = txtDept.Text
        EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text

        dt = DLCadreMgmt.GetCadreMgmt(EL)
        For Each grid As GridViewRow In GvCadreMgmt.Rows
            'lblAcademicYearAns.Text = CType(grid.FindControl("l1"), Label).Text
            'lblUniv2Q.Text = CType(grid.FindControl("lblUniversityid"), Label).Text
            lblUniv2Ans.Text = CType(grid.FindControl("lblUniversity"), Label).Text
            pnllabel.Visible = True
        Next
        GvCadreMgmt.DataSource = dt
        GvCadreMgmt.DataBind()
        GvCadreMgmt.Enabled = True
        pnllabel.Visible = True
        GvCadreMgmt.Visible = True
        If dt.Rows.Count > 0 Then
            'msginfo.Text = ""
            'lblmsg.Text = ""
            lblUniv2Ans.Text = ""
            For Each grid As GridViewRow In GvCadreMgmt.Rows
                'lblAcademicYearAns.Text = CType(grid.FindControl("l1"), Label).Text
                'lblUniv2Q.Text = CType(grid.FindControl("lblUniversityid"), Label).Text
                lblUniv2Ans.Text = CType(grid.FindControl("lblUniversity"), Label).Text
                pnllabel.Visible = True
            Next
            'CType(grid.FindControl("lblProgram"), Label).Text

            GvCadreMgmt.DataSource = dt
            GvCadreMgmt.DataBind()
            GvCadreMgmt.Enabled = True
            pnllabel.Visible = True
            GvCadreMgmt.Visible = True

        Else
            msginfo.Text = "No records to display"
            lblMsg.Text = ""
            pnllabel.Visible = False
            GvCadreMgmt.Enabled = False
            GvCadreMgmt.Visible = False

        End If

    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If btnView.CommandName = "VIEW" Then
            msginfo.Text = ""
            lblMsg.Text = ""
            'clear()
            ViewState("PageIndex") = 0
            GvCadreMgmt.PageIndex = 0
            DispGrid()
        ElseIf btnView.CommandName = "BACK" Then
            btnADD.CommandName = "ADD"
            btnView.CommandName = "VIEW"
            btnADD.Text = "ADD"
            btnView.Text = "VIEW"
            msginfo.Text = ""
            lblMsg.Text = ""
            clear()
            GvCadreMgmt.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub

    Protected Sub GvCadreMgmt_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvCadreMgmt.PageIndexChanging
        lblMsg.Text = ""
        msginfo.Text = ""
        GvCadreMgmt.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GvCadreMgmt.PageIndex
        DispGrid()
    End Sub

    Protected Sub GvCadreMgmt_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvCadreMgmt.RowDeleting
        EL.ChkID = CType(GvCadreMgmt.Rows(e.RowIndex).FindControl("lblLS"), Label).Text
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If EL.ChkID = "Y" Then
                msginfo.Text = "Record Locked: Can't Delete"
                lblMsg.Text = ""
            Else
                EL.Id = CType(GvCadreMgmt.Rows(e.RowIndex).FindControl("lblCadreMgmtID"), Label).Text
                BL.ChangeFlag(EL)
                lblMsg.Text = "Data deleted successfully."
                msginfo.Text = ""
                GvCadreMgmt.PageIndex = ViewState("PageIndex")
                DispGrid()
            End If
        End If

    End Sub


    Protected Sub GvCadreMgmt_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvCadreMgmt.RowEditing
        msginfo.Text = ""
        'EL.Program = ddlProgram.SelectedValue
        'EL.University = ddlUniversity.SelectedValue
        'EL.Project = ddlProj.SelectedValue
        'EL.Department = txtDept.Text
        'EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text
        'If BL.ChkLockSummary(EL).Tables(0).Rows(0).Item(0) = "Y" Then
        '    msginfo.Text = "Record Locked: Can't Edit"
        '    lblMsg.Text = ""
        'Else

        'EL.Program = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblProgramID"), Label).Text
        'EL.University = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblUniversityid"), Label).Text
        'EL.Project = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblProjectID"), Label).Text
        'EL.Department = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblDepartment"), Label).Text
        'EL.SalaryCode = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblSalaryCodeID"), Label).Text
        EL.ChkID = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblLS"), Label).Text
        If EL.ChkID = "Y" Then
            msginfo.Text = "Record Locked: Can't Edit"
            lblMsg.Text = ""
        Else
            btnView.Text = "BACK"
            btnADD.Text = "UPDATE"
            btnView.CommandName = "BACK"
            btnADD.CommandName = "UPDATE"


            ViewState("Cadreid") = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblCadreMgmtID"), Label).Text

            ddlUniversity.SelectedValue = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblUniversityid"), Label).Text
            ddlProgram.SelectedValue = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblProgramID"), Label).Text
            ddlProj.Items.Clear()
            ddlProj.DataSourceID = "ObjProj"
            ddlProj.DataBind()
            ddlProj.SelectedValue = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblProjectID"), Label).Text
            txtDept.Text = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblDepartment"), Label).Text
            ddlSalCodeGrd.Items.Clear()
            ddlSalCodeGrd.DataSourceID = "ObjDesigSal"
            ddlSalCodeGrd.DataBind()
            ddlSalCodeGrd.SelectedItem.Text = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblSalaryCodeID"), Label).Text
            'If (ddlSalCodeGrd.SelectedItem.Text <> "Select") Then
            '    ddlSalCodeGrd.SelectedItem.Text = "Select"
            'End If
            Dim x As Integer
            x = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblDesignationID"), Label).Text
            ddlDesig.Items.Clear()
            ddlDesig.DataSourceID = "ObjDesignation"
            ddlDesig.DataBind()
            ddlDesig.SelectedValue = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblDesignationID"), Label).Text

            txtYear1.Text = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblApprovedYear"), Label).Text
            txtNo1.Text = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblApprovedNo"), Label).Text

            txtYear2.Text = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblRequiredYear"), Label).Text
            txtNo2.Text = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblRequiredNo"), Label).Text
            txtRemarks.Text = CType(GvCadreMgmt.Rows(e.NewEditIndex).FindControl("lblRemark"), Label).Text


            EL.Id = ViewState("Cadreid")
            EL.Program = ddlProgram.SelectedValue
            EL.University = ddlUniversity.SelectedValue
            EL.Project = ddlProj.SelectedValue
            EL.Department = txtDept.Text
            EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text

            dt = DLCadreMgmt.GetCadreMgmt(EL)

            GvCadreMgmt.DataSource = dt
            GvCadreMgmt.DataBind()
            GvCadreMgmt.Enabled = False
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ddlUniversity.SelectedValue = Session("BranchCode")

        End If
    End Sub

    Protected Sub GvCadreMgmt_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GvCadreMgmt.Sorting


        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        DisplayGrid()
        msginfo.Text = ""
        Dim dt As New DataTable
        EL.Id = 0
        EL.Program = ddlProgram.SelectedValue
        EL.University = ddlUniversity.SelectedValue
        EL.Project = ddlProj.SelectedValue
        EL.Department = txtDept.Text
        EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text
        dt = DLCadreMgmt.GetCadreMgmt(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GvCadreMgmt.DataSource = sortedView
        GvCadreMgmt.DataBind()
        GvCadreMgmt.Visible = True
        GvCadreMgmt.Enabled = True
        
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

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If txtPassword.Text = Session("Password") Then
                EL.Program = ddlProgram.SelectedValue
                EL.University = ddlUniversity.SelectedValue
                EL.Project = ddlProj.SelectedValue
                EL.Department = txtDept.Text
                EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text
                'lblmsg.Text = ""
                'msginfo.Text = ""
                Try
                    If BL.ChkLockSummary1(EL).Tables(0).Rows(0).Item(0) = "N" Then
                        Dim roweffected As Integer = BL.LockSummary(EL)
                        If roweffected > 0 Then
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            msginfo.Text = ""
                            lblMsg.Text = roweffected.ToString + " Approved record(s) Locked."
                            GvCadreMgmt.Enabled = False
                            DispGrid()
                        Else
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            msginfo.Text = "Only Approved Records Can Be Locked"
                            lblMsg.Text = ""
                            DispGrid()
                        End If

                    Else
                        Dim roweffected As Integer = BL.UnLockSummary(EL)
                        If roweffected > 0 Then
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            msginfo.Text = ""
                            lblMsg.Text = roweffected.ToString + " record(s) Unlocked."
                            GvCadreMgmt.Enabled = True
                            DispGrid()
                        Else
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            msginfo.Text = "Only Approved Records Can Be Locked"
                            lblMsg.Text = ""
                            DispGrid()
                        End If
                    End If
                Catch ex As Exception
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    pnllabel.Visible = False
                    msginfo.Text = "Only Approved Records Can Be Locked"
                    lblMsg.Text = ""
                    DispGrid()
                End Try
            ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                msginfo.Text = "Password Incorrect."
                lblMsg.Text = ""
                DispGrid()
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot lock data."
            lblMsg.Text = ""
        End If
        btnLockUnlock.Focus()
    End Sub
    Sub CheckAll()
        If CType(GvCadreMgmt.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GvCadreMgmt.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GvCadreMgmt.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
            Next
        End If
    End Sub
    'Sub Enable()
    '    lblUniversity.Visible = True
    '    lblProgram.Visible = True
    '    lblProj.Visible = True
    '    lblDept.Visible = True
    '    lblSalCode.Visible = True
    '    lblDesig.Visible = True
    '    lblApproved.Visible = True
    '    lblRequired.Visible = True
    '    lblRemarks.Visible = True
    '    lblYear1.Visible = True
    '    lblYear2.Visible = True
    '    lblNo1.Visible = True
    '    lblNo2.Visible = True
    'End Sub

    Protected Sub btnLockUnlock_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLockUnlock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'EL.Id = ViewState("Cadreid")
            EL.Program = ddlProgram.SelectedValue
            EL.University = ddlUniversity.SelectedValue
            EL.Project = ddlProj.SelectedValue
            EL.Department = txtDept.Text
            EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text
            lblMsg.Text = ""
            msginfo.Text = ""
            dt = DLCadreMgmt.GetCadreMgmt(EL)
            GvCadreMgmt.DataSource = dt
            GvCadreMgmt.DataBind()
            'Enable()
            If dt.Rows.Count > 0 Then
                lblMsg.Text = ""
                msginfo.Text = ""
                ControlsPanel.Visible = False
                PasswordPanel.Visible = True
                txtPassword.Focus()
                lblpassError.Text = ""
            Else
                lblMsg.Text = ""
                msginfo.Text = "No Records to Lock/Unlock."
                'Enable()
            End If
            If dt.Rows.Count > 0 Then
                lblMsg.Text = ""
                msginfo.Text = "Enter all mandatory fields."
                GvCadreMgmt.Visible = False
            Else
                lblMsg.Text = ""
                msginfo.Text = "No Records to Lock/Unlock."
                'Enable()
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot lock/unlock data."
            lblMsg.Text = ""
        End If

    End Sub
    '(
    '        If BL.ChkApproveStatusChk(EL).Tables(0).Rows(0).Item(0) = ("N") Then
    '            msginfo.Text = "Data Not Approved"
    '            lblMsg.Text = ""



    '        ElseIf BL.ChkLockStatusChk(EL).Tables(0).Rows(0).Item(0) = "Y" Then
    '            DLCadreMgmt.UnLockToCadre(EL)
    '            lblMsg.Text = "Record UnLocked successfully."
    '            msginfo.Text = ""
    '            DispGrid()
    '        Else
    '            DLCadreMgmt.LockToCadre(EL)
    '            lblMsg.Text = "Record Locked successfully."
    '            msginfo.Text = ""
    '            DispGrid()

    '        End If
    '            Catch ex As Exception
    '            msginfo.Text = "Data Not Approved"
    '            lblMsg.Text = ""

    '        End If
    '    Else
    '        msginfo.Text = "You do not belong to this branch, Cannot Approve data."
    '        lblMsg.Text = ""
    '    End If



    'End Sub

    ')
    '    If (Session("BranchCode") = Session("ParentBranch")) Then
    '        EL.Program = ddlProgram.SelectedValue
    '        EL.University = ddlUniversity.SelectedValue
    '        EL.Project = ddlProj.SelectedValue
    '        EL.Department = txtDept.Text
    '        EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text
    '        Try
    '            If ddlProgram.SelectedValue = 0 Then
    '                msginfo.Text = "Program Field is Mandatory."
    '                lblMsg.Text = ""
    '            ElseIf ddlProj.SelectedValue = 0 Then
    '                msginfo.Text = "Project Field is Mandatory."
    '                lblMsg.Text = ""
    '            ElseIf BL.ChkApproveStatus(EL).Tables(0).Rows(0).Item(0) = "N" Then
    '                msginfo.Text = "Data Not Approved"
    '                lblMsg.Text = ""
    '            Else
    '                'EL.Id = ViewState("Cadreid")
    '                EL.Program = ddlProgram.SelectedValue
    '                EL.University = ddlUniversity.SelectedValue
    '                EL.Project = ddlProj.SelectedValue
    '                EL.Department = txtDept.Text
    '                EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text
    '                lblMsg.Text = ""
    '                msginfo.Text = ""
    '                dt = DLCadreMgmt.GetCadreMgmt(EL)
    '                GvCadreMgmt.DataSource = dt
    '                GvCadreMgmt.DataBind()
    '                'Enable()
    '                If dt.Rows.Count > 0 Then
    '                    lblMsg.Text = ""
    '                    msginfo.Text = ""
    '                    ControlsPanel.Visible = False
    '                    PasswordPanel.Visible = True
    '                    txtPassword.Focus()
    '                    lblpassError.Text = ""
    '                Else
    '                    lblMsg.Text = ""
    '                    msginfo.Text = "No Records to Lock/Unlock."
    '                    'Enable()
    '                End If
    '            End If
    '        Catch ex As Exception
    '            EL.Program = ddlProgram.SelectedValue
    '            EL.University = ddlUniversity.SelectedValue
    '            EL.Project = ddlProj.SelectedValue
    '            EL.Department = txtDept.Text
    '            EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text
    '            lblMsg.Text = ""
    '            msginfo.Text = ""
    '            dt = DLCadreMgmt.GetCadreMgmt(EL)
    '            GvCadreMgmt.DataSource = dt
    '            GvCadreMgmt.DataBind()
    '            'Enable()
    '            If dt.Rows.Count > 0 Then
    '                lblMsg.Text = ""
    '                msginfo.Text = "Enter all mandatory fields."
    '                GvCadreMgmt.Visible = False
    '            Else
    '                lblMsg.Text = ""
    '                msginfo.Text = "No Records to Lock/Unlock."
    '                'Enable()
    '            End If


    '        End Try
    '    Else
    '        msginfo.Text = "You do not belong to this branch, Cannot lock/unlock data."
    '        lblMsg.Text = ""
    '    End If

    'End Sub

    Protected Sub btnApprove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprove.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim id As String = ""
            Dim check As String = ""

            Dim count As New Integer
            count = 0
            For Each grid As GridViewRow In GvCadreMgmt.Rows
                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("lblID"), Label).Text
                    id = check + "," + id
                    count = count + 1
                End If
            Next
            If id = "" Then
                id = "0"
                count = 0
            Else
                id = Left(id, id.Length - 1)
            End If
            Dim role As String
            role = Session("UserRole")
            'dt = DayBookDB.PostCheck(role)
            'If dt.Rows.Count > 0 Then
            If count = 0 Then
                msginfo.Text = "Select Atleast One Record to Approve."
                lblMsg.Text = ""
            Else
                EL.ChkID = id
                Dim roweffected As Integer = DLCadreMgmt.ApproveToCadre(EL)
                lblMsg.Text = roweffected.ToString + " Record(s) Approved successfully."
                msginfo.Text = ""
                DispGrid()
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot Approve data."
            lblMsg.Text = ""
        End If


    End Sub

    Protected Sub btnApprPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnApprPassword.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim id As String = ""
            Dim check As String = ""

            Dim count As New Integer
            count = 0
            For Each grid As GridViewRow In GvCadreMgmt.Rows
                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("lblID"), Label).Text
                    id = check + "," + id
                    count = count + 1
                End If
            Next
            If id = "" Then
                id = "0"
                count = 0
            Else
                id = Left(id, id.Length - 1)
            End If
            Dim role As String
            role = Session("UserRole")
            'dt = DayBookDB.PostCheck(role)
            'If dt.Rows.Count > 0 Then
            If count = 0 Then
                msginfo.Text = "Select Atleast One Record to Approve."
                lblMsg.Text = ""
            Else
                EL.ChkID = id
                DLCadreMgmt.ApproveToCadre(EL)
                lblMsg.Text = "Record Approved successfully."
                msginfo.Text = ""
                DispGrid()
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot post data."
            lblMsg.Text = ""
        End If


    End Sub
    '        If txtApprPassword.Text = Session("Password") Then
    '            EL.Program = ddlProgram.SelectedValue
    '            EL.University = ddlUniversity.SelectedValue
    '            EL.Project = ddlProj.SelectedValue
    '            EL.Department = txtDept.Text
    '            EL.SalaryCode = ddlSalCodeGrd.SelectedItem.Text
    ''lblmsg.Text = ""
    ''msginfo.Text = ""
    '            If BL.ChkLockSummary(EL).Tables(0).Rows(0).Item(0) = "N" Then
    'Dim roweffected As Integer = BL.ApproveCadre(EL)
    '                If roweffected > 0 Then
    '                    ControlsPanel.Visible = True
    '                    ApprPasswordPanel.Visible = False
    '                    msginfo.Text = ""
    '                    lblMsg.Text = roweffected.ToString + " records Approved."
    '                    GvCadreMgmt.Enabled = False
    '                End If
    '            End If
    '        ElseIf txtApprPassword.Text = "" Or txtApprPassword.Text <> Session("Password") Then
    '            ControlsPanel.Visible = True
    '            ApprPasswordPanel.Visible = False
    '            msginfo.Text = "Password Incorrect."
    '            lblMsg.Text = ""
    '        End If
    '    Else
    '        msginfo.Text = "You do not belong to this branch, Cannot lock data."
    '        lblMsg.Text = ""
    '    End If
    '    btnApprove.Focus()
    'End Sub
End Class
