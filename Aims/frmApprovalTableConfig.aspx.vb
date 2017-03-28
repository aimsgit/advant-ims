
Partial Class frmApprovalTableConfig
    Inherits BasePage
    Dim BLL As New BLTableConfiguration
    Dim dt As New DataTable
    Dim prop As New TableConfiguration
    Dim a As Integer
    Dim GlobalFunction As New GlobalFunction
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        DDLTableMaster.Focus()

        If IsPostBack = True Then
            'If txtFrstEmpCode.Text <> "" Then
            '    SplitterEmp(txtFrstEmpCode.Text, 1)
            'Else
            '    txtFrstEmpCode.AutoPostBack = True
            'End If
            'If txtScndEmpCode.Text <> "" Then
            '    SplitterEmp(txtScndEmpCode.Text, 2)
            'Else
            '    txtScndEmpCode.AutoPostBack = True
            'End If
            'If txtThrdEmpCode.Text <> "" Then
            '    SplitterEmp(txtThrdEmpCode.Text, 3)
            'Else
            '    txtThrdEmpCode.AutoPostBack = True
            'End If
            'If txtFrthEmpCode.Text <> "" Then
            '    SplitterEmp(txtFrthEmpCode.Text, 4)
            'Else
            '    txtFrthEmpCode.AutoPostBack = True
            'End If
            'If txtFifthEmpCode.Text <> "" Then
            '    SplitterEmp(txtFifthEmpCode.Text, 5)
            'Else
            '    txtFifthEmpCode.AutoPostBack = True
            'End If
        Else
            ViewState("Empcode2") = ""
            ViewState("Empcode3") = ""
            ViewState("Empcode4") = ""
            ViewState("Empcode5") = ""
            ViewState("Empcode1") = ""
            GVTblConfig.Visible = False
            lblmsg.Text = ""
            lblErrorMsg.Text = ""
        End If
        lblmsg.Text = ""
        lblErrorMsg.Text = ""
    End Sub
    'Sub SplitterEmp(ByVal s As String, ByVal i As Int32)
    '    Dim parts As String() = s.Split(New Char() {":"c})
    '    If i = 1 Then
    '        If parts.Length > 1 Then
    '            ViewState("Empcode1") = parts(1).ToString()
    '            txtFrstEmpCode.Text = parts(0).ToString()
    '        End If
    '    End If
    '    If i = 2 Then
    '        If parts.Length > 1 Then
    '            ViewState("Empcode2") = parts(1).ToString()
    '            txtScndEmpCode.Text = parts(0).ToString()
    '        End If
    '    End If
    '    If i = 3 Then
    '        If parts.Length > 1 Then
    '            ViewState("Empcode3") = parts(1).ToString()
    '            txtThrdEmpCode.Text = parts(0).ToString()
    '        End If
    '    End If
    '    If i = 4 Then
    '        If parts.Length > 1 Then
    '            ViewState("Empcode4") = parts(1).ToString()
    '            txtFrthEmpCode.Text = parts(0).ToString()
    '        End If
    '    End If
    '    If i = 5 Then
    '        If parts.Length > 1 Then
    '            ViewState("Empcode5") = parts(1).ToString()
    '            txtFifthEmpCode.Text = parts(0).ToString()
    '        End If
    '    End If
    'End Sub

    Protected Sub btnAddGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddGrid.Click
        DDLTableMaster.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Try
                    If btnAddGrid.Text = "ADD" Then
                        If DDLTableMaster.SelectedValue = "" Then
                            lblErrorMsg.Text = "Please Select Table Name."
                        Else
                            prop.BranchCode = Session("BranchCode")
                            prop.UserCode = Session("UserCode")
                            prop.EmpCode = Session("EmpCode")
                            prop.Tablecode = DDLTableMaster.SelectedValue
                            If RBType.SelectedValue = 1 Then
                                ddl1st.Focus()
                                prop.FirstApprover = ddl1st.SelectedValue
                                prop.SecApprover = ddl2.SelectedValue
                                prop.ThirdApprover = ddl3.SelectedValue
                                prop.FourthApprover = ddl4.SelectedValue
                                prop.FifthApprover = ddl5.SelectedValue
                                prop.FirstEmpCode = ""
                                prop.SecEmpCode = ""
                                prop.ThirdEmpCode = ""
                                prop.FourthEmpCode = ""
                                prop.FifthEmpCode = ""
                            Else
                                ddlFifthEmpCode.Focus()
                                If ddlFifthEmpCode.SelectedValue = "0" Then
                                    ViewState("Empcode5") = ""
                                Else
                                    ViewState("Empcode5") = ddlFifthEmpCode.SelectedValue
                                End If
                                If ddlFrthEmpCode.SelectedValue = "0" Then
                                    ViewState("Empcode4") = ""
                                Else
                                    ViewState("Empcode4") = ddlFrthEmpCode.SelectedValue
                                End If
                                If ddlThrdEmpCode.SelectedValue = "0" Then
                                    ViewState("Empcode3") = ""
                                Else
                                    ViewState("Empcode3") = ddlThrdEmpCode.SelectedValue
                                End If
                                If ddlScndEmpCode.SelectedValue = "0" Then
                                    ViewState("Empcode2") = ""
                                Else
                                    ViewState("Empcode2") = ddlScndEmpCode.SelectedValue
                                End If
                                If ddlFrstEmpCode.SelectedValue = "0" Then
                                    ViewState("Empcode1") = ""
                                Else
                                    ViewState("Empcode1") = ddlFrstEmpCode.SelectedValue
                                End If
                                prop.FirstEmpCode = ViewState("Empcode5")
                                prop.SecEmpCode = ViewState("Empcode4")
                                prop.ThirdEmpCode = ViewState("Empcode3")
                                prop.FourthEmpCode = ViewState("Empcode2")
                                prop.FifthEmpCode = ViewState("Empcode1")
                                prop.FirstApprover = ""
                                prop.SecApprover = ""
                                prop.ThirdApprover = ""
                                prop.FourthApprover = ""
                                prop.FifthApprover = ""
                            End If
                            If RBType.SelectedValue = 1 Then
                                If ddl1st.SelectedValue = "" Then
                                    lblErrorMsg.Text = "1st Approver is mandatory so select either office or Employee."
                                Else
                                    Dim check As New DataTable
                                    Dim TableName As String = DDLTableMaster.SelectedValue
                                    check = BLL.CheckDuplicate(TableName)
                                    If check.Rows.Count > 0 Then
                                        lblErrorMsg.Text = "Duplicate Entry"
                                    Else
                                        BLL.InsertRecord(prop)
                                        DispGrid()
                                        clearall()
                                        lblmsg.Text = "Data added successfully"
                                    End If
                                End If
                            Else
                                If ViewState("Empcode5") = "" Then
                                    lblErrorMsg.Text = "1st Approver is mandatory so select either office or Employee."
                                Else
                                    Dim check As New DataTable
                                    Dim TableName As String = DDLTableMaster.SelectedValue
                                    check = BLL.CheckDuplicate(TableName)
                                    If check.Rows.Count > 0 Then
                                        lblErrorMsg.Text = "Duplicate Entry"
                                    Else
                                        BLL.InsertRecord(prop)
                                        DispGrid()
                                        clearall()
                                        lblmsg.Text = "Data added successfully"
                                    End If
                                End If
                            End If
                        End If
                    Else

                        If DDLTableMaster.SelectedValue = "" Then
                            lblErrorMsg.Text = "Please Select Table Name"
                        Else
                            prop.BranchCode = Session("BranchCode")
                            prop.UserCode = Session("UserCode")
                            prop.EmpCode = Session("EmpCode")
                            prop.Tablecode = DDLTableMaster.SelectedValue
                            prop.Workflow_ID = CType(Session("TCID"), Int32)
                            If RBType.SelectedValue = 1 Then
                                prop.FirstApprover = ddl1st.SelectedValue
                                prop.SecApprover = ddl2.SelectedValue
                                prop.ThirdApprover = ddl3.SelectedValue
                                prop.FourthApprover = ddl4.SelectedValue
                                prop.FifthApprover = ddl5.SelectedValue
                                prop.FirstEmpCode = ""
                                prop.SecEmpCode = ""
                                prop.ThirdEmpCode = ""
                                prop.FourthEmpCode = ""
                                prop.FifthEmpCode = ""
                            Else
                                If ddlFifthEmpCode.SelectedItem.Text = "Select" Then
                                    ViewState("Empcode5") = ""
                                Else
                                    ViewState("Empcode5") = ddlFifthEmpCode.SelectedValue
                                End If
                                If ddlFrthEmpCode.SelectedValue = "0" Then
                                    ViewState("Empcode4") = ""
                                Else
                                    ViewState("Empcode4") = ddlFrthEmpCode.SelectedValue
                                End If
                                If ddlThrdEmpCode.SelectedValue = "0" Then
                                    ViewState("Empcode3") = ""
                                Else
                                    ViewState("Empcode3") = ddlThrdEmpCode.SelectedValue
                                End If
                                If ddlScndEmpCode.SelectedValue = "0" Then
                                    ViewState("Empcode2") = ""
                                Else
                                    ViewState("Empcode2") = ddlScndEmpCode.SelectedValue
                                End If
                                If ddlFrstEmpCode.SelectedValue = "0" Then
                                    ViewState("Empcode1") = ""
                                Else
                                    ViewState("Empcode1") = ddlFrstEmpCode.SelectedValue
                                End If
                                prop.FirstEmpCode = ViewState("Empcode5")
                                prop.SecEmpCode = ViewState("Empcode4")
                                prop.ThirdEmpCode = ViewState("Empcode3")
                                prop.FourthEmpCode = ViewState("Empcode2")
                                prop.FifthEmpCode = ViewState("Empcode1")
                                prop.FirstApprover = ""
                                prop.SecApprover = ""
                                prop.ThirdApprover = ""
                                prop.FourthApprover = ""
                                prop.FifthApprover = ""
                            End If
                        End If
                        If RBType.SelectedValue = 1 Then
                            If ddl1st.SelectedValue = "" Then
                                lblErrorMsg.Text = "1st Approver is mandatory so select either office or Employee."
                            Else
                                'Dim check As New DataTable
                                'Dim TableName As String = DDLTableMaster.SelectedValue
                                'check = BLL.CheckDuplicate(TableName)
                                'If check.Rows.Count > 0 Then
                                '    lblmsg.Text = "Duplicate Entry"
                                'Else

                                BLL.UpdateRecord(prop)
                                prop.Workflow_ID = 0
                                DispGrid()
                                GVTblConfig.Enabled = True
                                btnAddGrid.Text = "ADD"
                                BtnView.Text = "VIEW"
                                clearall()
                                lblmsg.Text = "Data updated successfully."
                                'End If
                            End If
                        Else
                            If ViewState("Empcode5") = "" Then
                                lblErrorMsg.Text = "1st Approver is mandatory so select either office or Employee"
                            Else
                                'Dim check As New DataTable
                                'Dim TableName As String = DDLTableMaster.SelectedValue
                                'check = BLL.CheckDuplicate(TableName)
                                'If check.Rows.Count > 0 Then
                                '    lblmsg.Text = "Duplicate Entry"
                                'Else
                                BLL.UpdateRecord(prop)
                                prop.Workflow_ID = 0
                                DispGrid()
                                GVTblConfig.Enabled = True
                                btnAddGrid.Text = "ADD"
                                BtnView.Text = "VIEW"
                                clearall()
                                lblmsg.Text = "Data updated successfully."
                                'End If
                            End If
                        End If
                    End If
                Catch ex As Exception
                    lblErrorMsg.Text = "Select all mandatory fields."
                End Try
            Else
                lblErrorMsg.Text = "No Write Permission!"
            End If
        Else
            lblErrorMsg.Text = "No Write Permission!"
        End If
    End Sub

    Sub DispGrid()
        Dim tableCon As New TableConfiguration
        GVTblConfig.Visible = True
        GVTblConfig.Enabled = True
        lblErrorMsg.Text = ""
        Dim dt1 As New DataTable
        dt1 = BLL.GetTableConfigRecords(prop)
        If RBType.SelectedValue = 1 Then
            GVTblConfig.Columns(7).Visible = False
            GVTblConfig.Columns(8).Visible = False
            GVTblConfig.Columns(9).Visible = False
            GVTblConfig.Columns(10).Visible = False
            GVTblConfig.Columns(11).Visible = False

            GVTblConfig.Columns(2).Visible = True
            GVTblConfig.Columns(3).Visible = True
            GVTblConfig.Columns(4).Visible = True
            GVTblConfig.Columns(5).Visible = True
            GVTblConfig.Columns(6).Visible = True
        Else
            GVTblConfig.Columns(7).Visible = True
            GVTblConfig.Columns(8).Visible = True
            GVTblConfig.Columns(9).Visible = True
            GVTblConfig.Columns(10).Visible = True
            GVTblConfig.Columns(11).Visible = True

            GVTblConfig.Columns(2).Visible = False
            GVTblConfig.Columns(3).Visible = False
            GVTblConfig.Columns(4).Visible = False
            GVTblConfig.Columns(5).Visible = False
            GVTblConfig.Columns(6).Visible = False
        End If
        GVTblConfig.DataSource = dt1
        GVTblConfig.DataBind()
        GVTblConfig.Visible = True
    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click

        If DDLTableMaster.SelectedValue = "Select" Then
            ddl1st.Enabled = False
            ddl2.Enabled = False
            ddl3.Enabled = False
            ddl4.Enabled = False
            ddl5.Enabled = False
            ddlFifthEmpCode.Enabled = False
            ddlFrstEmpCode.Enabled = False
            ddlFrthEmpCode.Enabled = False
            ddlScndEmpCode.Enabled = False
            ddlThrdEmpCode.Enabled = False
        End If
        a = GlobalFunction.UserPrivilage()
        LinkButton1.Focus()
        If a = 1 Or a = 2 Or a = 3 Or a = 4 Then
            dt = BLL.GetTableConfigRecords(prop)
            If dt.Rows.Count > 0 Then
                If BtnView.Text = "BACK" Then
                    BtnView.Text = "VIEW"
                    btnAddGrid.Text = "ADD"
                    clearall()
                End If
                DispGrid()
            Else
                lblErrorMsg.Text = "There are no records to display."
            End If

        Else
            lblErrorMsg.Text = "No Read Permission!"
        End If
    End Sub

    Sub clearall()
        ddl1st.SelectedIndex = 0
        ddl2.SelectedIndex = 0
        ddl3.SelectedIndex = 0
        ddl4.SelectedIndex = 0
        ddl5.SelectedIndex = 0
        ddl2.Enabled = False
        ddl3.Enabled = False
        ddl4.Enabled = False
        ddl5.Enabled = False
        ddlFifthEmpCode.SelectedIndex = 0
        ddlFrstEmpCode.SelectedIndex = 0
        ddlFrthEmpCode.SelectedIndex = 0
        ddlScndEmpCode.SelectedIndex = 0
        ddlThrdEmpCode.SelectedIndex = 0
        'DDLTableMaster.SelectedIndex = 0
        lblErrorMsg.Text = ""
        ViewState("Empcode1") = ""
        ViewState("Empcode2") = ""
        ViewState("Empcode3") = ""
        ViewState("Empcode4") = ""
        ViewState("Empcode5") = ""
        'ddlFifthEmpCode.Enabled = False
        ddlFrstEmpCode.Enabled = False
        ddlFrthEmpCode.Enabled = False
        ddlScndEmpCode.Enabled = False
        ddlThrdEmpCode.Enabled = False
    End Sub
    Protected Sub GVTblConfig_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVTblConfig.PageIndexChanging
        lblErrorMsg.Visible = False
        GVTblConfig.PageIndex = e.NewPageIndex
        DispGrid()
    End Sub

    Protected Sub GVTblConfig_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVTblConfig.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                prop.Workflow_ID = CType(GVTblConfig.Rows(e.RowIndex).Cells(1).FindControl("HidUDID"), Label).Text
                BLL.DeleteRecord(prop)
                lblmsg.Text = "Data deleted successfully."
                prop.Workflow_ID = 0
                DispGrid()
                clearall()
                If RBType.SelectedItem.Text = "Office" Then
                    ddl1st.Enabled = True
                Else
                    'txtFifthEmpCode.Enabled = True
                End If
            Else
                lblErrorMsg.Text = "No Delete Permission!"
            End If
        Else
            lblErrorMsg.Text = "No Delete Permission!"
        End If
    End Sub

    Protected Sub GVTblConfig_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVTblConfig.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                clearall()
                Session("TCID") = CType(GVTblConfig.Rows(e.NewEditIndex).Cells(1).FindControl("HidUDID"), Label).Text
                prop.Workflow_ID = CType(GVTblConfig.Rows(e.NewEditIndex).Cells(1).FindControl("HidUDID"), Label).Text
                If RBType.SelectedValue = 1 Then
                    ddl2.Enabled = True
                    ddl3.Enabled = True
                    ddl4.Enabled = True
                    ddl5.Enabled = True
                    ddl1st.Enabled = True
                    DDLTableMaster.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblTablecode"), Label).Text
                    ddl1st.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lbl1stAp"), Label).Text
                    ddl2.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lbl2ndAp"), Label).Text
                    ddl3.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lbl3rdAp"), Label).Text
                    ddl4.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lbl4thAp"), Label).Text
                    ddl5.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lbl5thAp"), Label).Text
                Else
                    ddlFrstEmpCode.Enabled = True
                    ddlScndEmpCode.Enabled = True
                    ddlThrdEmpCode.Enabled = True
                    ddlFrthEmpCode.Enabled = True
                    ddlFifthEmpCode.Enabled = True
                    DDLTableMaster.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblTablecode"), Label).Text
                    ViewState("Empcode5") = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblFiratEmp"), Label).Text.Trim
                    ViewState("Empcode4") = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblSecEmp"), Label).Text.Trim
                    ViewState("Empcode3") = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblThirdEmp"), Label).Text.Trim
                    ViewState("Empcode2") = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblFourthEmp"), Label).Text.Trim
                    ViewState("Empcode1") = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblFifthEmp"), Label).Text.Trim

                    If (CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblFiratEmp"), Label).Text.Trim) = "" Then
                        ddlFifthEmpCode.SelectedValue = 0
                    Else
                        ddlFifthEmpCode.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblFiratEmp"), Label).Text.Trim
                    End If

                    If (CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblSecEmp"), Label).Text.Trim) = "" Then
                        ddlFrthEmpCode.SelectedValue = 0
                    Else
                        ddlFrthEmpCode.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblSecEmp"), Label).Text.Trim
                    End If

                    If (CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblThirdEmp"), Label).Text.Trim) = "" Then
                        ddlThrdEmpCode.SelectedValue = 0
                    Else
                        ddlThrdEmpCode.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblThirdEmp"), Label).Text.Trim
                    End If

                    If (CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblFourthEmp"), Label).Text.Trim) = "" Then
                        ddlScndEmpCode.SelectedValue = 0
                    Else
                        ddlScndEmpCode.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblFourthEmp"), Label).Text.Trim
                    End If

                    If (CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblFifthEmp"), Label).Text.Trim) = "" Then
                        ddlFrstEmpCode.SelectedValue = 0
                    Else
                        ddlFrstEmpCode.SelectedValue = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lblFifthEmp"), Label).Text.Trim
                    End If


                    ddlFifthEmpCode.SelectedItem.Text = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lbl1name"), Label).Text.Trim
                    ddlFrthEmpCode.SelectedItem.Text = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lbl2name"), Label).Text.Trim
                    ddlThrdEmpCode.SelectedItem.Text = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lbl3name"), Label).Text.Trim
                    ddlScndEmpCode.SelectedItem.Text = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lbl4name"), Label).Text.Trim
                    ddlFrstEmpCode.SelectedItem.Text = CType(GVTblConfig.Rows(e.NewEditIndex).FindControl("lbl5name"), Label).Text.Trim
                    If ddlFifthEmpCode.SelectedItem.Text = "" Then
                        ddlFrstEmpCode.Enabled = False
                        ddlScndEmpCode.Enabled = False
                        ddlThrdEmpCode.Enabled = False
                        ddlFrthEmpCode.Enabled = False
                    ElseIf ddlFrthEmpCode.SelectedItem.Text = "" Then
                        ddlFrstEmpCode.Enabled = False
                        ddlScndEmpCode.Enabled = False
                        ddlThrdEmpCode.Enabled = False
                    ElseIf ddlThrdEmpCode.SelectedItem.Text = "" Then
                        ddlFrstEmpCode.Enabled = False
                        ddlScndEmpCode.Enabled = False
                    ElseIf ddlScndEmpCode.SelectedItem.Text = "" Then
                        ddlFrstEmpCode.Enabled = False
                    End If
                End If
                BtnView.Text = "BACK"
                btnAddGrid.Text = "UPDATE"
                DispGrid()
                GVTblConfig.Enabled = False
            Else
                lblErrorMsg.Text = "No Edit Permission!"
                End If
            Else
                lblErrorMsg.Text = "No Edit Permission!"
            End If
    End Sub

    Protected Sub ddl1st_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl1st.SelectedIndexChanged
        If ddl1st.SelectedValue <> "01" Then
            ddl2.Enabled = True
        End If
    End Sub

    Protected Sub ddl2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl2.SelectedIndexChanged
        If ddl2.SelectedValue <> "01" Then
            ddl3.Enabled = True
        End If
    End Sub

    Protected Sub ddl3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl3.SelectedIndexChanged
        If ddl3.SelectedValue <> "01" Then
            ddl4.Enabled = True
        End If
    End Sub

    Protected Sub ddl4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl4.SelectedIndexChanged
        If ddl4.SelectedValue <> "01" Then
            ddl5.Enabled = True
        End If
    End Sub

    Protected Sub DDLTableMaster_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLTableMaster.SelectedIndexChanged
        'RBType.Enabled = True
        If RBType.SelectedValue = 1 Then
            ddl1st.Enabled = True
        Else
            ddlFifthEmpCode.Enabled = True
        End If

        If DDLTableMaster.SelectedValue = "Select" Then
            ddl1st.Enabled = "false"
            ddl2.Enabled = "false"
            ddl3.Enabled = "false"
            ddl4.Enabled = "false"
            ddl5.Enabled = "false"
            ddlFifthEmpCode.Enabled = False
            ddlFrstEmpCode.Enabled = False
            ddlFrthEmpCode.Enabled = False
            ddlScndEmpCode.Enabled = False
            ddlThrdEmpCode.Enabled = False
        End If
    End Sub

    Protected Sub RBType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBType.SelectedIndexChanged
        lblmsg.Text = ""
        lblErrorMsg.Text = ""
        If Session("TCID") = "" Then
            If RBType.SelectedValue = 1 Then
                'ddlFrstEmpCode.SelectedValue = 0
                'ddlScndEmpCode.SelectedValue = 0
                'ddlThrdEmpCode.SelectedValue = 0
                'ddlFrthEmpCode.SelectedValue = 0
                'ddlFifthEmpCode.SelectedValue = 0

                ddlFifthEmpCode.Enabled = False
                ddlFrstEmpCode.Enabled = False
                ddlFrthEmpCode.Enabled = False
                ddlScndEmpCode.Enabled = False
                ddlThrdEmpCode.Enabled = False
                ddl1st.Enabled = True
            Else
                ddl1st.ClearSelection()
                ddl2.ClearSelection()
                ddl3.ClearSelection()
                ddl4.ClearSelection()
                ddl5.ClearSelection()

                ddl1st.Enabled = False
                ddl2.Enabled = False
                ddl3.Enabled = False
                ddl4.Enabled = False
                ddl5.Enabled = False
                ddlFifthEmpCode.Enabled = True
            End If
            GVTblConfig.Visible = False
        Else
            'GVTblConfig.Visible = True
            prop.Workflow_ID = CType(Session("TCID"), Int32)
            If GVTblConfig.Visible = True Then
                DispGrid()
            End If
            'GVTblConfig.Enabled = False
            If RBType.SelectedValue = 1 Then
                'ddlFrstEmpCode.SelectedValue = 0
                'ddlScndEmpCode.SelectedValue = 0
                'ddlThrdEmpCode.SelectedValue = 0
                'ddlFrthEmpCode.SelectedValue = 0
                'ddlFifthEmpCode.SelectedValue = 0

                ddlFifthEmpCode.Enabled = False
                ddlFrstEmpCode.Enabled = False
                ddlFrthEmpCode.Enabled = False
                ddlScndEmpCode.Enabled = False
                ddlThrdEmpCode.Enabled = False
                ddl1st.Enabled = True
            Else
                ddl1st.ClearSelection()
                ddl2.ClearSelection()
                ddl3.ClearSelection()
                ddl4.ClearSelection()
                ddl5.ClearSelection()

                ddl1st.Enabled = False
                ddl2.Enabled = False
                ddl3.Enabled = False
                ddl4.Enabled = False
                ddl5.Enabled = False
                ddlFifthEmpCode.Enabled = True
            End If
        End If
    End Sub

    ''Protected Sub txtFrstEmpCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrstEmpCode.TextChanged
    ''    txtScndEmpCode.Enabled = True
    ''End Sub
    'Protected Sub txtScndEmpCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtScndEmpCode.TextChanged
    '    txtFrstEmpCode.Enabled = True
    'End Sub

    'Protected Sub txtThrdEmpCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtThrdEmpCode.TextChanged
    '    txtScndEmpCode.Enabled = True
    'End Sub

    'Protected Sub txtFrthEmpCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFrthEmpCode.TextChanged
    '    txtThrdEmpCode.Enabled = True
    'End Sub

    'Protected Sub txtFifthEmpCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFifthEmpCode.TextChanged
    '    txtFrthEmpCode.Enabled = True
    'End Sub

    Protected Sub ddl1st_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl1st.TextChanged
        ddl1st.Focus()
    End Sub

    Protected Sub ddl2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl2.TextChanged
        ddl2.Focus()
    End Sub

    Protected Sub ddl3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl3.TextChanged
        ddl3.Focus()
    End Sub

    Protected Sub ddl4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl4.TextChanged
        ddl4.Focus()
    End Sub

    Protected Sub ddl5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddl5.TextChanged
        ddl5.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlScndEmpCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlScndEmpCode.SelectedIndexChanged
        ddlFrstEmpCode.Enabled = True
    End Sub

    Protected Sub ddlThrdEmpCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlThrdEmpCode.SelectedIndexChanged
        ddlScndEmpCode.Enabled = True
    End Sub
    Protected Sub ddlFrthEmpCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFrthEmpCode.SelectedIndexChanged
        ddlThrdEmpCode.Enabled = True
    End Sub
    Protected Sub ddlFifthEmpCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFifthEmpCode.SelectedIndexChanged
        ddlFrthEmpCode.Enabled = True
    End Sub
End Class
