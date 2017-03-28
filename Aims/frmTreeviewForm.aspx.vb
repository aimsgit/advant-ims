
'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
'--Author: Kusum.C.Akki
'--Date: 02.01.2013
'--Description: Treeview form to configure the module and its respective child.
'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
Partial Class frmTreeviewForm
    Inherits BasePage
    Dim ELT As New ELTreeviewForm
    Dim BLT As New BLTreeviewForm
    Dim ELTC As New ELTreeviewChildForm
    Dim dt As New DataTable
    '~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
    Protected Sub Btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.Click

        If Btnadd.Text = "ADD" Then
            HidID.Value = 0
            AssignEntity()
            If BLT.GetDuplicateModule(ELT).Rows.Count > 0 Then
                lblGreen.Text = ""
                lblRed.Text = "Data already exists."
            Else
                Dim i As Integer = BLT.Insert(ELT)
                If i > 0 Then
                    lblGreen.Text = "Data added successfully."
                    lblRed.Text = ""
                    TxtClear()
                    DisplayGrid()
                Else
                    lblGreen.Text = ""
                    lblRed.Text = "Error in adding the record."
                End If
            End If
        Else
            AssignEntity()
            If BLT.GetDuplicateModule(ELT).Rows.Count > 0 Then
                lblGreen.Text = ""
                lblRed.Text = "Data already exists."
            Else
                Dim i As Integer = BLT.Insert(ELT)
                If i > 0 Then
                    lblGreen.Text = "Data updated successfully."
                    lblRed.Text = ""
                    TxtClear()
                    ELT.id = 0
                    Btnadd.Text = "ADD"
                    btnView.Text = "VIEW"
                    DisplayGrid()
                Else
                    lblGreen.Text = ""
                    lblRed.Text = "Error in updating the record."
                End If
            End If
        End If

    End Sub
    Sub TxtClear()
        HidID.Value = 0
        txtModuleName.Text = ""
        txtSequenceNo.Text = ""
    End Sub
    Sub AssignEntity()
        ELT.id = HidID.Value
        ELT.ModuleName = txtModuleName.Text
        ELT.SequenceNo = txtSequenceNo.Text
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If btnView.Text = "BACK" Then
            TxtClear()
            DisplayGrid()
            Btnadd.Text = "ADD"
            btnView.Text = "VIEW"
        Else
            DisplayGrid()
        End If
    End Sub
    Sub DisplayGrid()
        dt.Clear()
        dt = BLT.GetModule(ELT)
        If dt.Rows.Count > 0 Then
            panel1.Visible = True
            GVModule.DataSource = dt
            GVModule.DataBind()
            GVModule.Enabled = True
            GVModule.PageIndex = ViewState("PageIndex")
            lblRed.Text = ""
            ' lblGreen.Text = ""
            DDLModule.Items.Clear()
            DDLModule.DataSourceID = "objModule"
        Else
            panel1.Visible = False
            GVModule.Visible = False
            lblRed.Text = "No Records to display."
            lblGreen.Text = ""
        End If
    End Sub
    Protected Sub GVModule_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVModule.PageIndexChanging
        GVModule.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVModule.PageIndex
        DisplayGrid()
    End Sub
    Protected Sub GVModule_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVModule.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ELT.id = CType(GVModule.Rows(e.RowIndex).Cells(1).FindControl("HidMNPKID"), HiddenField).Value
            BLT.Delete(ELT)
            ELT.id = 0
            DisplayGrid()
            lblGreen.Text = "Data Deleted Successfully."
            txtModuleName.Focus()
            lblRed.Text = ""
        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub
    Protected Sub GVModule_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVModule.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            txtModuleName.Text = CType(GVModule.Rows(e.NewEditIndex).FindControl("lblModuleName"), Label).Text
            txtSequenceNo.Text = CType(GVModule.Rows(e.NewEditIndex).FindControl("lblSequenceNo"), Label).Text
            HidID.Value = CType(GVModule.Rows(e.NewEditIndex).FindControl("HidMNPKID"), HiddenField).Value
            AssignEntity()
            GVModule.DataSource = BLT.GetModule(ELT)
            GVModule.DataBind()
            lblGreen.Text = ""
            lblRed.Text = ""
            Btnadd.Text = "UPDATE"
            btnView.Text = "BACK"
            DisplayGrid()
            GVModule.Enabled = False
        Else
            lblRed.Text = "You do not belong to this branch, Cannot edit data."
            lblGreen.Text = ""
        End If
    End Sub
    '~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
    Protected Sub btnChildAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChildAdd.Click
        If btnChildAdd.Text = "ADD" Then
            HidChildID.Value = 0
            AssignEntityChild()
            If BLT.GetDuplicateChild(ELTC).Rows.Count > 0 Then
                lblGreenChild.Text = ""
                lblRedChild.Text = "Data already exists."
            Else
                Dim i As Integer = BLT.InsertChild(ELTC)
                If i > 0 Then
                    lblGreenChild.Text = "Data added successfully."
                    lblRedChild.Text = ""
                    TxtClear()
                    DisplayChildGrid()
                Else
                    lblGreenChild.Text = ""
                    lblRedChild.Text = "Error in adding the record."
                End If
            End If
        Else
            AssignEntityChild()
            If BLT.GetDuplicateChild(ELTC).Rows.Count > 0 Then
                lblGreenChild.Text = ""
                lblRedChild.Text = "Data already exists."
            Else
                Dim i As Integer = BLT.InsertChild(ELTC)
                If i > 0 Then
                    lblGreenChild.Text = "Data updated successfully."
                    lblRedChild.Text = ""
                    TxtChildClear()
                    btnChildAdd.Text = "ADD"
                    btnChildView.Text = "VIEW"
                    DisplayChildGrid()
                Else
                    lblGreenChild.Text = ""
                    lblRedChild.Text = "Error in updating the record."
                End If
            End If
        End If
    End Sub
    Sub AssignEntityChild()
        ELTC.id = HidChildID.Value
        ELTC.Moduleid = DDLModule.SelectedValue
        ELTC.FormName = txtFormName.Text
        ELTC.FormFileName = txtLinkName.Text
        ELTC.SequenceNo = txtFormSequence.Text
    End Sub
    Sub DisplayChildGrid()
        dt.Clear()
        dt = BLT.GetChild(ELTC)
        If dt.Rows.Count > 0 Then
            panel2.Visible = True
            GVChild.DataSource = dt
            GVChild.DataBind()
            GVChild.PageIndex = ViewState("PageIndex")
            GVChild.Enabled = True
            GVChild.Visible = True
            lblRedChild.Text = ""
            'lblGreenChild.Text = ""
        Else
            GVChild.Visible = False
            lblRedChild.Text = "No records to display."
            lblGreenChild.Text = ""
            panel2.Visible = False
        End If
    End Sub
    Sub TxtChildClear()
        'HidChildID.Value = 0
        txtFormName.Text = ""
        txtLinkName.Text = ""
        txtFormSequence.Text = ""
    End Sub
    Protected Sub btnChildView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChildView.Click
        If btnChildView.Text = "BACK" Then
            TxtChildClear()
            ELTC.Moduleid = DDLModule.SelectedValue
            DisplayChildGrid()
            btnChildAdd.Text = "ADD"
            btnChildView.Text = "VIEW"
        Else
            ELTC.Moduleid = DDLModule.SelectedValue
            DisplayChildGrid()
        End If
    End Sub
    Protected Sub GVChild_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVChild.PageIndexChanging
        GVChild.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVChild.PageIndex
        DisplayChildGrid()
    End Sub
    Protected Sub GVChild_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVChild.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ELTC.id = CType(GVChild.Rows(e.RowIndex).Cells(1).FindControl("HidCNPKID"), HiddenField).Value
            BLT.DeleteChild(ELTC)
            ELTC.id = 0
            ELTC.Moduleid = DDLModule.SelectedValue
            DisplayChildGrid()
            lblGreenChild.Text = "Data Deleted Successfully."
            txtModuleName.Focus()
            lblRedChild.Text = ""
        Else
            lblRedChild.Text = "You do not belong to this branch, Cannot delete data."
            lblRedChild.Text = ""
        End If
    End Sub
    Protected Sub GVChild_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVChild.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then

            HidChildID.Value = CType(GVChild.Rows(e.NewEditIndex).FindControl("HidCNPKID"), HiddenField).Value
            DDLModule.Text = CType(GVChild.Rows(e.NewEditIndex).FindControl("HidMNIDAuto"), HiddenField).Value
            txtFormName.Text = CType(GVChild.Rows(e.NewEditIndex).FindControl("lblChildName"), Label).Text
            txtLinkName.Text = CType(GVChild.Rows(e.NewEditIndex).FindControl("lblChildFileName"), Label).Text
            txtFormSequence.Text = CType(GVChild.Rows(e.NewEditIndex).FindControl("lblFormSequenceNo"), Label).Text

            AssignEntityChild()
            GVChild.DataSource = BLT.GetChild(ELTC)
            GVChild.DataBind()
            lblGreenChild.Text = ""
            lblRedChild.Text = ""
            btnChildAdd.Text = "UPDATE"
            btnChildView.Text = "BACK"
            DisplayChildGrid()
            GVChild.Enabled = False
        Else
            lblRedChild.Text = "You do not belong to this branch, Cannot edit data."
            lblRedChild.Text = ""
        End If
    End Sub
    Protected Sub BtnAdd3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd3.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If DdlSelectClient.SelectedValue = 0 Then
                lblRed3.Text = "Institute Field is Mandatory."
                lblGreen3.Text = ""
                Exit Sub
            End If

            ELTC.Institute = DdlSelectClient.SelectedValue
            ELTC.BranchName = DdlSelectBranch.SelectedValue
            ELTC.Moduleid = ddlModuleCustomize.SelectedValue
            ELTC.FormName = ddlFormName.SelectedItem.ToString
            ELTC.FormNames = ddlFormName.SelectedValue
            ELTC.AliasName = txtAliasName.Text
            ELTC.SequenceNo = txtSequenceNo.Text
            ELTC.FormFileName = HidTxtFilename.Text
            ELTC.id = txtCNIDAuto.Text
            If BtnAdd3.Text = "ADD" Then

                dt = BLT.CustomizeDuplicate(ELTC)
                If dt.Rows.Count > 0 Then
                    lblRed3.Text = "Data Already Exits."
                    lblGreen3.Text = ""
                Else
                    BLT.InsertCustomizeTreeview(ELTC)
                   
                    clear3()
                    DisplayCustomizeChildGrid()
                    lblRed3.Text = ""
                    lblGreen3.Text = "Data Saved Successfully."
                End If
            ElseIf BtnAdd3.Text = "UPDATE" Then


                ELTC.CustomizeTreeviewId = CustomizeChildId.Value
                dt = BLT.CustomizeDuplicate(ELTC)
                If dt.Rows.Count > 0 Then
                    lblRed3.Text = "Data Already Exits."
                    lblGreen3.Text = ""
                Else
                    BLT.InsertCustomizeTreeview(ELTC)
                    
                    clear3()
                    DdlSelectClient.Enabled = True
                    DdlSelectBranch.Enabled = True
                    ddlModuleCustomize.Enabled = True
                    ddlFormName.Enabled = True
                    BtnAdd3.Text = "ADD"
                    BtnView3.Text = "VIEW"
                    DisplayCustomizeChildGrid()
                    lblRed3.Text = ""
                    lblGreen3.Text = "Data Updated Successfully."
                End If
            End If
        Else
            lblRed3.Text = "You do not belong to this branch, Cannot edit data."
            lblGreen3.Text = ""
        End If

    End Sub

    Protected Sub ddlFormName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFormName.SelectedIndexChanged
        Dim formname As Integer
        ELTC.Modules = ddlModuleCustomize.SelectedValue
        formname = ddlFormName.SelectedValue
        dt = BLT.GetCustTreeviewDetails(ELTC, formname)
        If dt.Rows.Count > 0 Then
            txtSequenceNo.Text = dt.Rows(0).Item("SequenceNo")
            HidTxtFilename.Text = dt.Rows(0).Item("ChildFileName")
            txtCNIDAuto.Text = dt.Rows(0).Item("CNIDAuto")
        End If
    End Sub

    Protected Sub BtnView3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView3.Click
        If BtnView3.Text = "BACK" Then
            ' TxtChildClear()
            ELTC.Moduleid = ddlModuleCustomize.SelectedValue
            DisplayCustomizeChildGrid()
            BtnAdd3.Text = "ADD"
            BtnView3.Text = "VIEW"
            clear3()
            lblRed3.Text = ""
            lblGreen3.Text = ""
            DdlSelectClient.Enabled = True
            DdlSelectBranch.Enabled = True
            ddlModuleCustomize.Enabled = True
            ddlFormName.Enabled = True

        Else
            ELTC.Moduleid = ddlModuleCustomize.SelectedValue
            DisplayCustomizeChildGrid()
            'lblRed3.Text = ""
            'lblGreen3.Text = ""
        End If
    End Sub
    Sub DisplayCustomizeChildGrid()
        dt.Clear()
        ELTC.Moduleid = ddlModuleCustomize.SelectedValue
        dt = BLT.GetTanentCustomizeTreeview(ELTC)
        If dt.Rows.Count > 0 Then
            panel3.Visible = True
            Grid3.DataSource = dt
            Grid3.DataBind()
            Grid3.PageIndex = ViewState("PageIndex")
            Grid3.Enabled = True
            Grid3.Visible = True
            lblRed3.Text = ""
            lblGreen3.Text = ""
        Else
            Grid3.Visible = False
            lblRed3.Text = "No records to display."
            lblGreen3.Text = ""
            panel3.Visible = False
        End If
    End Sub

    Protected Sub Grid3_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Grid3.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ELTC.CustomizeTreeviewId = CType(Grid3.Rows(e.RowIndex).Cells(1).FindControl("HidGVCustomizeTreeviewId"), HiddenField).Value
            BLT.DeleteCustomizeChild(ELTC)
            ELTC.CustomizeTreeviewId = 0
            ELTC.Moduleid = DDLModule.SelectedValue
            DisplayCustomizeChildGrid()
            lblGreen3.Text = "Data Deleted Successfully."
            DdlSelectClient.Focus()
            lblRed3.Text = ""
        Else
            lblRed3.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen3.Text = ""
        End If
    End Sub

    Protected Sub Grid3_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles Grid3.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then

            'ViewState("CustTreeveiwIDAuto") = CType(GVChild.Rows(e.NewEditIndex).FindControl("HidGVCustomizeTreeviewId"), HiddenField).Value
            CustomizeChildId.Value = CType(Grid3.Rows(e.NewEditIndex).FindControl("HidGVCustomizeTreeviewId"), HiddenField).Value
            'DDLModule.Text = CType(GVChild.Rows(e.NewEditIndex).FindControl("HidMNIDAuto"), HiddenField).Value
            ELTC.CustomizeTreeviewId = CustomizeChildId.Value

            DdlSelectClient.Items.Clear()
            DdlSelectClient.DataSourceID = "ObjSelectClient"
            DdlSelectClient.DataBind()
            ELTC.Institute = RTrim(CType(Grid3.Rows(e.NewEditIndex).FindControl("lblGVInstitute"), Label).Text)
            DdlSelectClient.SelectedValue = ELTC.Institute
            DdlSelectBranch.Items.Clear()

            DdlSelectBranch.DataSourceID = "ObjSelectBranch"
            DdlSelectBranch.DataBind()
            ELTC.BranchName = CType(Grid3.Rows(e.NewEditIndex).FindControl("lblGVBranchCode"), Label).Text
            DdlSelectBranch.SelectedValue = ELTC.BranchName
            ELTC.Moduleid = CType(Grid3.Rows(e.NewEditIndex).FindControl("HidGVMNIDAuto"), HiddenField).Value
            ddlModuleCustomize.SelectedValue = ELTC.Moduleid
            ddlFormName.Items.Clear()
            ddlFormName.DataSourceID = "ObjFormName"
            ddlFormName.DataBind()
            ELTC.FormNames = CType(Grid3.Rows(e.NewEditIndex).FindControl("HidGVChildAutoId"), HiddenField).Value
            ddlFormName.SelectedValue = ELTC.FormNames
            txtAliasName.Text = CType(Grid3.Rows(e.NewEditIndex).FindControl("lblGVAliasName"), Label).Text
            txtSequenceNo.Text = CType(Grid3.Rows(e.NewEditIndex).FindControl("lblSequenceNo"), Label).Text
            HidTxtFilename.Text = CType(Grid3.Rows(e.NewEditIndex).FindControl("lblGVChildFilenameCust"), Label).Text
            txtCNIDAuto.Text = CType(Grid3.Rows(e.NewEditIndex).FindControl("HidGVChildAutoId"), HiddenField).Value
            'ELTC.Institute = DdlSelectClient.SelectedValue
            'ELTC.BranchName = DdlSelectBranch.SelectedValue
            'ELTC.FormName = ddlFormName.SelectedValue
            'ELTC.AliasName = txtAliasName.Text
            ' AssignEntityChild()
            dt = BLT.GetTanentCustomizeTreeview(ELTC)
            Grid3.DataSource = dt
            Grid3.DataBind()
            lblGreen3.Text = ""
            lblRed3.Text = ""
            DdlSelectClient.Enabled = False
            DdlSelectBranch.Enabled = False
            ddlModuleCustomize.Enabled = False
            ddlFormName.Enabled = False
            BtnAdd3.Text = "UPDATE"
            BtnView3.Text = "BACK"
            'DisplayChildGrid()
            Grid3.Enabled = False
        Else
            lblRed3.Text = "You do not belong to this branch, Cannot edit data."
            lblRed3.Text = ""
        End If
    End Sub
    Public Sub clear3()
        CustomizeChildId.Value = 0
        txtAliasName.Text = ""
        'HidTxtFilename.Text = ""
        'txtSequenceNo.Text = ""
        'HidTxtFilename.Text = ""
        'txtCNIDAuto.Text = ""
    End Sub
    '~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'~~~~'
End Class
