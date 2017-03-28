
Partial Class FrmMultilingualConversion
    Inherits BasePage
    Dim EL As New ELMultilingual
    Dim BL As New BLMultilingual
    Dim dt As New DataTable

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                ddlFormName.Focus()
                
                EL.Lang_Id = DdlLang.SelectedValue
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
                    EL.ID = ViewState("Multilingual_Auto_Id")
                    'dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        BL.UpdateRecord(EL)
                        msginfo.Text = ""
                        btnSave.Text = "ADD"
                        btnDetails.Text = "VIEW"
                        lblmsg.Text = "Data Updated Successfully."
                        DisplayMul()
                        GVMulti.PageIndex = ViewState("PageIndex")
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
                        BL.InsertRecord(EL)
                        msginfo.Text = ""
                        btnSave.Text = "ADD"
                        lblmsg.Text = "Data Saved successfully."
                        ViewState("PageIndex") = 0
                        GVMulti.PageIndex = 0
                        DisplayMul()
                        clear()
                        DisplayMul()
                    End If
                End If
            Catch ex As Exception
                lblmsg.Text = ""
                msginfo.Text = "Enter correct data."
            End Try

        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblMsg.Text = ""
        End If

    End Sub
    Sub DisplayMul()
        Dim dt As New DataTable
        EL.ID = 0
        EL.Type = RBType.SelectedItem.Value
        dt = BL.Display(EL)
        GVMulti.DataSource = dt
        GVMulti.DataBind()

        GVMulti.Visible = True
        GVMulti.Enabled = True
        LinkButton.Focus()
        If dt.Rows.Count = 0 Then
            lblMsg.Text = ""

            msginfo.Text = "No records to display."
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
        If btndetails.Text <> "BACK" Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GVMulti.PageIndex = 0
            DisplayMul()
            GVMulti.Visible = True

        Else
            lblmsg.Text = ""
            msginfo.Text = ""
            btndetails.Text = "VIEW"
            btnSave.Text = "ADD"
            clear()
            GVMulti.Visible = True
            GVMulti.PageIndex = ViewState("PageIndex")
            DisplayMul()
        End If
    End Sub

    Protected Sub GVMulti_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVMulti.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Multilingual_Auto_Id") = CType(GVMulti.Rows(e.RowIndex).Cells(1).FindControl("ModuleH"), HiddenField).Value
            EL.ID = ViewState("Multilingual_Auto_Id")
            BL.ChangeFlag(EL)
            DisplayMul()
            GVMulti.Visible = True
            msginfo.Text = ""
            lblMsg.Text = "Data Deleted Successfully."
            ddlModuleCustomize.Focus()
            GVMulti.PageIndex = ViewState("PageIndex")
            'txtrcvdate.Text = ""
            'EL.ID = 0
            dt = BL.Display(EL)
            GVMulti.DataSource = dt
            GVMulti.DataBind()
            GVMulti.Enabled = True
            GVMulti.Visible = True
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblMsg.Text = ""
        End If

    End Sub

    Protected Sub GVMulti_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVMulti.RowEditing
        lblmsg.Text = ""
        msginfo.Text = ""
        EL.ID = ViewState("Multilingual_Auto_Id")
        If CType(GVMulti.Rows(e.NewEditIndex).FindControl("lblgvRb"), Label).Text = "F" Then

            ddlModuleCustomize.Items.Clear()
            ddlModuleCustomize.DataSourceID = "objModule"
            ddlModuleCustomize.DataBind()

            ddlModuleCustomize.SelectedValue = CType(GVMulti.Rows(e.NewEditIndex).FindControl("lblmodid"), Label).Text
            ddlFormName.Items.Clear()
            ddlFormName.DataSourceID = "ObjFormName"
            ddlFormName.DataBind()
            ddlFormName.SelectedValue = CType(GVMulti.Rows(e.NewEditIndex).FindControl("lblFormid"), Label).Text
            lblModule.Visible = True
            ddlModuleCustomize.Visible = True
            LblForm.Visible = True
            ddlFormName.Visible = True
            LblReport.Visible = False
            TxtReport.Visible = False
            'ddlModuleCustomize.SelectedValue = 0
            'ddlFormName.SelectedValue = 0
            DdlLang.SelectedValue = 0
            DdlControl.SelectedValue = 0
            txtCCName.Text = ""
            TxtCId.Text = ""
            TxtTrans.Text = ""
        Else
            TxtReport.Text = CType(GVMulti.Rows(e.NewEditIndex).FindControl("lblFormid"), Label).Text
            lblModule.Visible = False
            ddlModuleCustomize.Visible = False
            LblForm.Visible = False
            ddlFormName.Visible = False
            LblReport.Visible = True
            TxtReport.Visible = True
            DdlLang.SelectedValue = 0
            DdlControl.SelectedValue = 0
            txtCCName.Text = ""
            TxtCId.Text = ""
            TxtTrans.Text = ""
        End If

        DdlLang.SelectedValue = CType(GVMulti.Rows(e.NewEditIndex).FindControl("lbllangid"), Label).Text
        DdlControl.SelectedValue = CType(GVMulti.Rows(e.NewEditIndex).FindControl("lblCType"), Label).Text
        txtCCName.Text = CType(GVMulti.Rows(e.NewEditIndex).FindControl("lblCommandName"), Label).Text
        TxtCId.Text = CType(GVMulti.Rows(e.NewEditIndex).FindControl("lblCId"), Label).Text
        TxtTrans.Text = CType(GVMulti.Rows(e.NewEditIndex).FindControl("lblTrans"), Label).Text

        ViewState("Multilingual_Auto_Id") = CType(GVMulti.Rows(e.NewEditIndex).FindControl("ModuleH"), HiddenField).Value
        btnSave.Text = "UPDATE"
        btnDetails.Text = "BACK"
        EL.ID = ViewState("Multilingual_Auto_Id")
        EL.Type = RBType.SelectedItem.Value
        dt = BL.Display(EL)
        GVMulti.DataSource = dt
        GVMulti.DataBind()
        GVMulti.Enabled = False

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

    Protected Sub GVMulti_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVMulti.PageIndexChanging
        GVMulti.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVMulti.PageIndex
        DisplayMul()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVMulti_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVMulti.Sorting
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
        dt = BL.Display(EL)

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVMulti.DataSource = sortedView
        GVMulti.DataBind()

        GVMulti.Visible = True
        GVMulti.Enabled = True
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
            DdlLang.SelectedValue = 0
            DdlControl.SelectedValue = 0
            txtCCName.Text = ""
            TxtCId.Text = ""
            TxtTrans.Text = ""
            lblmsg.Text = ""
            msginfo.Text = ""
            GVMulti.Visible = False
        ElseIf RBType.SelectedItem.Value = "F" Then
            lblModule.Visible = True
            ddlModuleCustomize.Visible = True
            LblForm.Visible = True
            ddlFormName.Visible = True
            LblReport.Visible = False
            TxtReport.Visible = False
            ddlModuleCustomize.SelectedValue = 0
            ddlFormName.SelectedValue = 0
            DdlLang.SelectedValue = 0
            DdlControl.SelectedValue = 0
            txtCCName.Text = ""
            TxtCId.Text = ""
            TxtTrans.Text = ""
            lblmsg.Text = ""
            msginfo.Text = ""
            GVMulti.Visible = False
        End If

    End Sub
    'Protected Sub DdlControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlControl.SelectedIndexChanged
    '    If DdlControl.SelectedValue.ToString = "Button" Then
    '        txtCCName.Enabled = True
    '    Else
    '        txtCCName.Enabled = False
    '    End If
    'End Sub

End Class
