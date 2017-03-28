
Partial Class FrmBranchSpecificLabel
    Inherits BasePage
    Dim EL As New ELMultilingual
    Dim BL As New BLMultilingual
    Dim dt As New DataTable

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                ddlFormName.Focus()

                EL.Branch = ddlBranchName.SelectedValue
                EL.Control_Type = DdlControl.SelectedValue
                EL.CCName = txtCCName.Text
                EL.Control_Id = TxtCId.Text
                EL.Translation = TxtTrans.Text
                EL.Type = RBType.SelectedItem.Value
                If RBType.SelectedItem.Value = "F" Then
                    EL.moduleId = ddlModuleCustomize.SelectedValue
                    EL.FormId = ddlFormName.SelectedValue
                Else
                    EL.FormId = TxtReport.Text
                End If

                If btnSave.Text = "UPDATE" Then
                    EL.ID = ViewState("BS_Label_AutoID")
                    'dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        BL.UpdateLabelRecord(EL)
                        msginfo.Text = ""
                        btnSave.Text = "ADD"
                        btnDetails.Text = "VIEW"
                        lblmsg.Text = "Data Updated Successfully."
                        DisplayL()
                        GVLabel.PageIndex = ViewState("PageIndex")
                        'Displ()
                        clear()
                    End If
                ElseIf btnSave.Text = "ADD" Then
                    EL.ID = 0
                    'dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        BL.InsertLabelRecord(EL)
                        msginfo.Text = ""
                        btnSave.Text = "ADD"
                        lblmsg.Text = "Data Saved successfully."
                        ViewState("PageIndex") = 0
                        GVLabel.PageIndex = 0
                        DisplayL()
                        clear()
                        DisplayL()
                    End If
                End If
            Catch ex As Exception
                lblmsg.Text = ""
                msginfo.Text = "Enter correct data."
            End Try

        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If

    End Sub
    Sub DisplayL()
        Dim dt As New DataTable
        EL.ID = 0
        EL.Type = RBType.SelectedItem.Value
        EL.Branch = ddlBranchName.SelectedValue
        dt = BL.DisplayLabel(EL)
        GVLabel.DataSource = dt
        GVLabel.DataBind()

        GVLabel.Visible = True
        GVLabel.Enabled = True
        LinkButton.Focus()
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ""

            msginfo.Text = "No records to Display."
            'msginfo.Visible = True
        End If
    End Sub
    Sub clear()
        ddlModuleCustomize.Focus()
        txtCCName.Text = ""
        TxtCId.Text = ""
        TxtTrans.Text = ""
        TxtReport.Text = ""

    End Sub

    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        msginfo.Text = ""
        If btnDetails.Text <> "BACK" Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GVLabel.PageIndex = 0
            DisplayL()
            GVLabel.Visible = True

        Else
            lblmsg.Text = ""
            msginfo.Text = ""
            btnDetails.Text = "VIEW"
            btnSave.Text = "ADD"
            clear()
            GVLabel.Visible = True
            GVLabel.PageIndex = ViewState("PageIndex")
            DisplayL()
        End If
    End Sub

    Protected Sub GVLabel_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVLabel.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("BS_Label_AutoID") = CType(GVLabel.Rows(e.RowIndex).Cells(1).FindControl("ModuleH"), HiddenField).Value
            EL.ID = ViewState("BS_Label_AutoID")
            BL.ChangeLabelFlag(EL)
            DisplayL()
            GVLabel.Visible = True
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            ddlModuleCustomize.Focus()
            GVLabel.PageIndex = ViewState("PageIndex")
            'txtrcvdate.Text = ""
            'EL.ID = 0
            dt = BL.DisplayLabel(EL)
            GVLabel.DataSource = dt
            GVLabel.DataBind()
            GVLabel.Enabled = True
            GVLabel.Visible = True
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub GVLabel_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVLabel.RowEditing
        lblmsg.Text = ""
        msginfo.Text = ""
        EL.ID = ViewState("BS_Label_AutoID")
        If CType(GVLabel.Rows(e.NewEditIndex).FindControl("lblgvRb"), Label).Text = "F" Then

            ddlModuleCustomize.Items.Clear()
            ddlModuleCustomize.DataSourceID = "objModule"
            ddlModuleCustomize.DataBind()

            ddlModuleCustomize.SelectedValue = CType(GVLabel.Rows(e.NewEditIndex).FindControl("lblmodid"), Label).Text
            ddlFormName.Items.Clear()
            ddlFormName.DataSourceID = "ObjFormName"
            ddlFormName.DataBind()
            ddlFormName.SelectedValue = CType(GVLabel.Rows(e.NewEditIndex).FindControl("lblFormid"), Label).Text
            lblModule.Visible = True
            ddlModuleCustomize.Visible = True
            LblForm.Visible = True
            ddlFormName.Visible = True
            LblReport.Visible = False
            TxtReport.Visible = False
            'ddlModuleCustomize.SelectedValue = 0
            'ddlFormName.SelectedValue = 0
            'ddlBranchName.SelectedValue = 0
            DdlControl.SelectedValue = 0
            txtCCName.Text = ""
            TxtCId.Text = ""
            TxtTrans.Text = ""
        Else
            TxtReport.Text = CType(GVLabel.Rows(e.NewEditIndex).FindControl("lblFormid"), Label).Text
            lblModule.Visible = False
            ddlModuleCustomize.Visible = False
            LblForm.Visible = False
            ddlFormName.Visible = False
            LblReport.Visible = True
            TxtReport.Visible = True
            ddlBranchName.SelectedValue = 0
            DdlControl.SelectedValue = 0
            txtCCName.Text = ""
            TxtCId.Text = ""
            TxtTrans.Text = ""
        End If

        ddlBranchName.SelectedValue = CType(GVLabel.Rows(e.NewEditIndex).FindControl("lbllangid"), Label).Text
        DdlControl.SelectedValue = CType(GVLabel.Rows(e.NewEditIndex).FindControl("lblCType"), Label).Text
        txtCCName.Text = CType(GVLabel.Rows(e.NewEditIndex).FindControl("lblCommandName"), Label).Text
        TxtCId.Text = CType(GVLabel.Rows(e.NewEditIndex).FindControl("lblCId"), Label).Text
        TxtTrans.Text = CType(GVLabel.Rows(e.NewEditIndex).FindControl("lblTrans"), Label).Text

        ViewState("BS_Label_AutoID") = CType(GVLabel.Rows(e.NewEditIndex).FindControl("ModuleH"), HiddenField).Value
        btnSave.Text = "UPDATE"
        btnDetails.Text = "BACK"
        EL.ID = ViewState("BS_Label_AutoID")
        EL.Type = RBType.SelectedItem.Value
        EL.Branch = ddlBranchName.SelectedValue
        dt = BL.DisplayLabel(EL)
        GVLabel.DataSource = dt
        GVLabel.DataBind()
        GVLabel.Enabled = False

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If RBType.SelectedItem.Value = "F" Then
            LblReport.Visible = False
            TxtReport.Visible = False
            'txtCCName.Enabled = False
        End If
    End Sub

    Protected Sub GVMulti_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVLabel.PageIndexChanging
        GVLabel.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVLabel.PageIndex
        DisplayL()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVMulti_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVLabel.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        EL.ID = 0
        EL.Type = RBType.SelectedItem.Value
        dt = BL.DisplayLabel(EL)

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVLabel.DataSource = sortedView
        GVLabel.DataBind()

        GVLabel.Visible = True
        GVLabel.Enabled = True
        LinkButton.Focus()
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


    Protected Sub RBType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBType.SelectedIndexChanged
        If RBType.SelectedItem.Value = "R" Then
            lblModule.Visible = False
            ddlModuleCustomize.Visible = False
            LblForm.Visible = False
            ddlFormName.Visible = False
            LblReport.Visible = True
            TxtReport.Visible = True
            ddlBranchName.SelectedValue = 0
            DdlControl.SelectedValue = 0
            txtCCName.Text = ""
            TxtCId.Text = ""
            TxtTrans.Text = ""
            lblmsg.Text = ""
            msginfo.Text = ""
            GVLabel.Visible = False
        ElseIf RBType.SelectedItem.Value = "F" Then
            lblModule.Visible = True
            ddlModuleCustomize.Visible = True
            LblForm.Visible = True
            ddlFormName.Visible = True
            LblReport.Visible = False
            TxtReport.Visible = False
            ddlModuleCustomize.SelectedValue = 0
            ddlFormName.SelectedValue = 0
            ddlBranchName.SelectedValue = 0
            DdlControl.SelectedValue = 0
            txtCCName.Text = ""
            TxtCId.Text = ""
            TxtTrans.Text = ""
            lblmsg.Text = ""
            msginfo.Text = ""
            GVLabel.Visible = False
        End If

    End Sub
End Class
