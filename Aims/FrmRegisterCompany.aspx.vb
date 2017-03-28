
Partial Class FrmRegisterCompany
    Inherits BasePage
    Dim EL As New ELCompanyRegister
    Dim dt As New DataTable
    Dim BL As New BLCompanyRegister

    Protected Sub InsertCompanyRegister_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertCompanyRegister.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.CompanyRegName = txtCompanyRName.Text
            EL.CompanyRegCode = txtCompanyRCode.Text
            EL.CompanyRegAddress = txtRAddress.Text
            EL.CompanyRegLocation = txtRLocation.Text
            If txtRPostalCode.Text = "" Then
                EL.CompanyRegPostalCode = 0
            Else
                EL.CompanyRegPostalCode = txtRPostalCode.Text
            End If

            EL.CompanyRegDistrict = txtRDistrict.Text
            EL.CompanyRegState = ddlState.SelectedValue
            EL.CompanyRegDwebDetails = txtwebdetails.Text
            EL.CompanyRegActivites = txtRCompanyActivities.Text
            If txtRNOOfEmployee.Text = "" Then
                EL.CompanyRegNoOfEmployee = 0
            Else
                EL.CompanyRegNoOfEmployee = txtRNOOfEmployee.Text
            End If
            If txtRNOOfFreshers.Text = "" Then
                EL.CompanyRegNoOfFresher = 0
            Else
                EL.CompanyRegNoOfFresher = txtRNOOfFreshers.Text
            End If

            EL.CompanyRegCeoName = txtNameofceo.Text
            EL.CompanyRegCeoEmail = txtceoemail.Text
            EL.CompanyRegCeoLandline = txtLandline.Text
            EL.CompanyRegCeoMobile = txtmobile.Text
            If InsertCompanyRegister.Text = "UPDATE" Then
                EL.Id = ViewState("RCID")
                dt = BL.CheckDuplicateCompanyRegister(EL)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    BL.UpdateCompanyRegister(EL)
                    msginfo.Text = ""
                    InsertCompanyRegister.Text = "ADD"
                    ViewCompanyRegister.Text = "VIEW"
                    lblmsg.Text = "Data Updated Successfully."
                    clear()
                    GvCompanyRegister.PageIndex = ViewState("PageIndex")
                    DisplayCompanyRegister()

                   
                End If
            ElseIf InsertCompanyRegister.Text = "ADD" Then
                EL.Id = 0
                dt = BL.CheckDuplicateCompanyRegister(EL)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    BL.InsertCompanyRegister(EL)
                    msginfo.Text = ""
                    InsertCompanyRegister.Text = "ADD"
                    lblmsg.Text = "Data Saved successfully."
                    clear()
                    ViewState("PageIndex") = 0
                    GvCompanyRegister.PageIndex = 0
                    DisplayCompanyRegister()
                End If
                ' End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub DisplayCompanyRegister()
        Dim dt As New DataTable
        EL.Id = 0
        EL.CompanyRegName = txtCompanyRName.Text
        EL.CompanyRegCode = txtCompanyRCode.Text

        EL.CompanyRegLocation = txtRLocation.Text
        dt = BL.GetCompanyRegister(EL)
        GvCompanyRegister.DataSource = dt
        GvCompanyRegister.DataBind()

        GvCompanyRegister.Visible = True
        GvCompanyRegister.Enabled = True
        link23.Focus()
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ""

            msginfo.Text = "No records to display."
            'msginfo.Visible = True
        End If
    End Sub

    Protected Sub ViewCompanyRegister_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewCompanyRegister.Click
        If ViewCompanyRegister.Text <> "BACK" Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GvCompanyRegister.PageIndex = 0
            DisplayCompanyRegister()
            GvCompanyRegister.Visible = True
        Else
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewCompanyRegister.Text = "VIEW"
            InsertCompanyRegister.Text = "ADD"
            GvCompanyRegister.Visible = True
            GvCompanyRegister.PageIndex = ViewState("PageIndex")
            DisplayCompanyRegister()
            clear()
        End If
    End Sub
    Protected Sub GvCompanyRegister_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvCompanyRegister.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Id = CType(GvCompanyRegister.Rows(e.RowIndex).FindControl("CompanyRegID"), HiddenField).Value
            BL.ChangeFlagCompanyRegister(EL)
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            GvCompanyRegister.PageIndex = ViewState("PageIndex")
            Dim dt As New DataTable
            EL.Id = 0
            EL.CompanyRegName = txtCompanyRName.Text
            EL.CompanyRegCode = txtCompanyRCode.Text

            EL.CompanyRegLocation = txtRLocation.Text
            dt = BL.GetCompanyRegister(EL)
            GvCompanyRegister.DataSource = dt
            GvCompanyRegister.DataBind()

            GvCompanyRegister.Visible = True
            GvCompanyRegister.Enabled = True
            link23.Focus()
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GvCompanyRegister_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvCompanyRegister.RowEditing
        lblmsg.Text = ""
        msginfo.Text = ""
        EL.Id = ViewState("RCID")
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        txtCompanyRName.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegName"), Label).Text
        txtCompanyRCode.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegCode"), Label).Text
        txtRAddress.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegAddress"), Label).Text
        txtRPostalCode.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegPCode"), Label).Text
        txtRLocation.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegLocation"), Label).Text
        txtRDistrict.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lbCompanyRegDistrict"), Label).Text
        ddlState.SelectedValue = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegState"), Label).Text
        txtwebdetails.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblWebDetails"), Label).Text
        txtRCompanyActivities.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegActivities"), Label).Text
        txtRNOOfEmployee.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegNoOfEmployee"), Label).Text
        txtRNOOfFreshers.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegNoOfFresher"), Label).Text
        txtNameofceo.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblNameOfCEO"), Label).Text
        ViewState("RCID") = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("CompanyRegID"), HiddenField).Value
        txtceoemail.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegEmail"), Label).Text
        txtLandline.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegLandline"), Label).Text
        txtmobile.Text = CType(GvCompanyRegister.Rows(e.NewEditIndex).FindControl("lblCompanyRegMobile"), Label).Text
        InsertCompanyRegister.Text = "UPDATE"
        ViewCompanyRegister.Text = "BACK"
        EL.Id = ViewState("RCID")
        EL.CompanyRegName = txtCompanyRName.Text
        EL.CompanyRegCode = txtCompanyRCode.Text
        EL.CompanyRegLocation = txtRLocation.Text
        dt = BL.GetCompanyRegister(EL)
        GvCompanyRegister.DataSource = dt
        GvCompanyRegister.DataBind()
        GvCompanyRegister.Enabled = False
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub
    Sub clear()
        txtCompanyRName.Text = ""
        txtCompanyRCode.Text = ""
        txtRAddress.Text = ""
        txtRLocation.Text = ""
        txtRPostalCode.Text = ""
        txtRDistrict.Text = ""
        txtwebdetails.Text = ""
        txtRCompanyActivities.Text = ""
        txtRNOOfEmployee.Text = ""
        txtRNOOfFreshers.Text = ""
        txtceoemail.Text = ""
        txtNameofceo.Text = ""
        txtmobile.Text = ""
        txtLandline.Text = ""
    End Sub

    Protected Sub InsertMKD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertMKD.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.MKDCompanyName = DdlKDMCName.SelectedValue
            EL.MKDName = txtKDMName.Text
            EL.KDMDesignation = txtKDMDeignation.Text
            EL.KDMLandLine = txtKDMLandline.Text
            EL.KDMMobile = txtKDMMobile.Text
            EL.KDMEmail = txtKDMEmail.Text
            'EL.Id = ViewState("RCID")
            If InsertMKD.Text = "UPDATE" Then
                EL.Id = ViewState("RCID")
                dt = BL.CheckKDM(EL)
                If dt.Rows.Count > 0 Then
                    Lblkdmerr.Text = "Data already exists."
                    lblkdmmsg.Text = ""
                Else
                    BL.UpdateKDM(EL)
                    Lblkdmerr.Text = ""
                    InsertMKD.Text = "ADD"
                    ViewMKD.Text = "VIEW"
                    lblkdmmsg.Text = "Data Updated Successfully."
                    DdlKDMCName.Enabled = True
                    clearKDM()
                    GvKDM.PageIndex = ViewState("PageIndex")
                    DisplayKDM()


                End If
            ElseIf InsertCompanyRegister.Text = "ADD" Then
                EL.MKDCompanyName = DdlKDMCName.SelectedValue


                dt = BL.CheckKDM(EL)
                If dt.Rows.Count > 0 Then
                    Lblkdmerr.Text = "Data already exists."
                    lblkdmmsg.Text = ""
                Else
                    BL.InsertKDM(EL)
                    Lblkdmerr.Text = ""
                    InsertCompanyRegister.Text = "ADD"
                    lblkdmmsg.Text = "Data Saved successfully."
                    clearKDM()
                    ViewState("PageIndex") = 0
                    GvKDM.PageIndex = 0
                    DisplayKDM()
                End If
                ' End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblkdmmsg.Text = ""
        End If
    End Sub
    Sub DisplayKDM()
        Dim dt As New DataTable
        EL.Id = 0
        EL.MKDName = ViewState("KeyDecisionName")
        dt = BL.GetKDM(EL)

        GvKDM.DataSource = dt
        GvKDM.DataBind()

        GvKDM.Visible = True
        GvKDM.Enabled = True
        Link22.Focus()
        If dt.Rows.Count = 0 Then
            lblkdmmsg.Text = ""
            Lblkdmerr.Text = "No records to display."
        End If
    End Sub

    Protected Sub ViewMKD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewMKD.Click

      
        If ViewMKD.Text <> "BACK" Then
            lblkdmmsg.Text = ""
            Lblkdmerr.Text = ""
            ViewState("PageIndex") = 0
            GvKDM.PageIndex = 0
            DisplayKDM()
            GvKDM.Visible = True
            
        Else
            lblkdmmsg.Text = ""
            Lblkdmerr.Text = ""
            ViewMKD.Text = "VIEW"
            InsertMKD.Text = "ADD"
            GvKDM.Visible = True
            GvKDM.PageIndex = ViewState("PageIndex")
            DisplayKDM()
            clearKDM()
        End If
        'End If
    End Sub

    Protected Sub GvKDM_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvKDM.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            EL.Id1 = CType(GvKDM.Rows(e.RowIndex).FindControl("KDMID"), HiddenField).Value
            BL.ChangeFlagKDM(EL)
            Lblkdmerr.Text = ""
            lblkdmmsg.Text = "Data Deleted Successfully."
            GvKDM.PageIndex = ViewState("PageIndex")
            Dim dt As New DataTable
            EL.Id = 0
            EL.MKDName = ViewState("KeyDecisionName")
            dt = BL.GetKDM(EL)

            GvKDM.DataSource = dt
            GvKDM.DataBind()

            GvKDM.Visible = True
            GvKDM.Enabled = True
            Link22.Focus()
        Else
            Lblkdmerr.Text = "You do not belong to this branch, Cannot delete data."
            lblkdmmsg.Text = ""
        End If
    End Sub

    Protected Sub GvKDM_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvKDM.RowEditing
        lblkdmmsg.Text = ""
        Lblkdmerr.Text = ""

        'If (Session("BranchCode") = Session("ParentBranch")) Then
        DdlKDMCName.SelectedValue = CType(GvKDM.Rows(e.NewEditIndex).FindControl("lblKDMCName"), Label).Text
        txtKDMName.Text = CType(GvKDM.Rows(e.NewEditIndex).FindControl("lblKDMName"), Label).Text
        txtKDMDeignation.Text = CType(GvKDM.Rows(e.NewEditIndex).FindControl("lblKDMDesignation"), Label).Text
        txtKDMLandline.Text = CType(GvKDM.Rows(e.NewEditIndex).FindControl("lblKDMLandLine"), Label).Text
        txtKDMMobile.Text = CType(GvKDM.Rows(e.NewEditIndex).FindControl("lblKDMMobile"), Label).Text
        txtKDMEmail.Text = CType(GvKDM.Rows(e.NewEditIndex).FindControl("lblKDMEmail"), Label).Text
        ViewState("RCID") = CType(GvKDM.Rows(e.NewEditIndex).FindControl("KDMID"), HiddenField).Value
        InsertMKD.Text = "UPDATE"
        ViewMKD.Text = "BACK"
        EL.Id = ViewState("RCID")
        dt = BL.GetKDM(EL)
        DdlKDMCName.Enabled = False
        GvKDM.DataSource = dt
        GvKDM.DataBind()
        GvKDM.Enabled = False
        'Else
        'Lblkdmerr.Text = "You do not belong to this branch, Cannot edit data."
        'lblkdmmsg.Text = ""
        'End If
    End Sub
    Sub clearKDM()
        txtKDMDeignation.Text = ""
        txtKDMEmail.Text = ""
        txtKDMLandline.Text = ""
        txtKDMMobile.Text = ""
        txtKDMName.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DdlKDMCName.Enabled = True
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub

    Protected Sub InsertSalaryStrcure_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertSalaryStrcure.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.CompanySName = ddlScompanyName.SelectedValue
            EL.CompanySGross = txtSGross.Text
            If txtSCTC.Text = "" Then
                EL.CompanySCTC = 0
            Else
                EL.CompanySCTC = txtSCTC.Text
            End If

            If ChkMedical.Checked = True Then
                EL.SalaryStrMedical = "Y"
            Else
                EL.SalaryStrMedical = "N"
            End If
            EL.SalaryStrMInsurance = "0"
            'If ChkInsurance.Checked = True Then
            '    EL.SalaryStrMInsurance = "Y"
            'Else
            '    EL.SalaryStrMInsurance = "N"
            'End If
            If ChkPf.Checked = True Then
                EL.SalaryStrMPF = "Y"
            Else
                EL.SalaryStrMPF = "N"
            End If
            If ChkLTA.Checked = True Then
                EL.SalaryStrLTA = "Y"
            Else
                EL.SalaryStrLTA = "N"
            End If
            If ChkSubscribedFood.Checked = True Then
                EL.SalaryStrSFood = "Y"
            Else
                EL.SalaryStrSFood = "N"
            End If
            If ChkTransport.Checked = True Then
                EL.SalaryStrMTransport = "Y"
            Else
                EL.SalaryStrMTransport = "N"
            End If
            If ChkAssistance.Checked = True Then
                EL.SalaryStrAssistance = "Y"
            Else
                EL.SalaryStrAssistance = "N"
            End If
            EL.SalaryStrAccommodation = "0"
            'If ChkAccomodation.Checked = True Then
            '    EL.SalaryStrAccommodation = "Y"
            'Else
            '    EL.SalaryStrAccommodation = "N"
            'End If
            ' EL.Id = ViewState("RCID")
            If InsertSalaryStrcure.Text = "UPDATE" Then
                EL.Id = ViewState("RCID")
                dt = BL.CheckDuplicateSalaryStructure(EL)
                If dt.Rows.Count > 0 Then
                    lblSerrmsg.Text = "Data already exists."
                    lblSmsgifo.Text = ""
                Else
                    BL.UpdateSalaryStructure(EL)
                    lblSerrmsg.Text = ""
                    InsertSalaryStrcure.Text = "ADD"
                    ViewSalaryStrcure.Text = "VIEW"
                    lblSmsgifo.Text = "Data Updated Successfully."
                    ddlScompanyName.Enabled = True
                    ClearSalaryStructure()
                    GVSalaryStructure.PageIndex = ViewState("PageIndex")
                    DisplaySalaryStructure()


                End If
            ElseIf InsertSalaryStrcure.Text = "ADD" Then
                EL.CompanySName = ddlScompanyName.SelectedValue

                dt = BL.CheckDuplicateSalaryStructure(EL)
                If dt.Rows.Count > 0 Then
                    lblSerrmsg.Text = "Data already exists."
                    lblSmsgifo.Text = ""
                Else
                    BL.InsertSalaryStructure(EL)
                    lblSerrmsg.Text = ""
                    InsertCompanyRegister.Text = "ADD"
                    lblSmsgifo.Text = "Data Saved successfully."
                    ClearSalaryStructure()
                    ViewState("PageIndex") = 0
                    GVSalaryStructure.PageIndex = 0
                    DisplaySalaryStructure()
                End If
                ' End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblkdmmsg.Text = ""
        End If
    End Sub
    Sub DisplaySalaryStructure()
        Dim dt As New DataTable
        EL.Id = 0

        EL.CompanySGross = ViewState("SalaryStructureGross")
        dt = BL.GetSalaryStructure(EL)

        GVSalaryStructure.DataSource = dt
        GVSalaryStructure.DataBind()
        Link21.Focus()
        GVSalaryStructure.Visible = True
        GVSalaryStructure.Enabled = True
        If dt.Rows.Count = 0 Then
            lblSmsgifo.Text = ""
            lblSerrmsg.Text = "No records to display."
        End If
    End Sub

    Protected Sub ViewSalaryStrcure_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewSalaryStrcure.Click
        If ViewSalaryStrcure.Text <> "BACK" Then
            lblSmsgifo.Text = ""
            lblSerrmsg.Text = ""
            ViewState("PageIndex") = 0
            GVSalaryStructure.PageIndex = 0
            DisplaySalaryStructure()
            GVSalaryStructure.Visible = True
        Else
            lblSmsgifo.Text = ""
            lblSerrmsg.Text = ""
            ViewSalaryStrcure.Text = "VIEW"
            InsertSalaryStrcure.Text = "ADD"
            GVSalaryStructure.Visible = True
            GVSalaryStructure.PageIndex = ViewState("PageIndex")
            DisplaySalaryStructure()
            ClearSalaryStructure()
        End If
    End Sub
    Sub ClearSalaryStructure()
        txtSGross.Text = ""
        txtSCTC.Text = ""
        ChkMedical.Checked = False
        'ChkInsurance.Checked = False
        ChkPf.Checked = False
        ChkLTA.Checked = False
        ChkSubscribedFood.Checked = False
        ChkTransport.Checked = False
        ChkAssistance.Checked = False
        'ChkAccomodation.Checked = False
    End Sub

    Protected Sub GVSalaryStructure_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSalaryStructure.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            EL.Id1 = CType(GVSalaryStructure.Rows(e.RowIndex).FindControl("SSID"), HiddenField).Value
            BL.ChangeFlagSalaryStructure(EL)
            lblSerrmsg.Text = ""
            lblSmsgifo.Text = "Data Deleted Successfully."
            GVSalaryStructure.PageIndex = ViewState("PageIndex")
            Dim dt As New DataTable
            EL.Id = 0

            EL.CompanySGross = ViewState("SalaryStructureGross")
            dt = BL.GetSalaryStructure(EL)

            GVSalaryStructure.DataSource = dt
            GVSalaryStructure.DataBind()
            Link21.Focus()
            GVSalaryStructure.Visible = True
            GVSalaryStructure.Enabled = True
        Else
            lblSerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblSmsgifo.Text = ""
        End If
    End Sub

    Protected Sub GVSalaryStructure_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSalaryStructure.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        ddlScompanyName.SelectedValue = CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("lblSCompanyName"), Label).Text
        txtSGross.Text = CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("lblSGross"), Label).Text
        txtSCTC.Text = CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("lblSCTC"), Label).Text
        EL.SalaryStrMedical = CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("lblMedical"), Label).Text
        If EL.SalaryStrMedical = "Y" Then
            ChkMedical.Checked = True
        Else
            ChkMedical.Checked = False
        End If
        EL.SalaryStrMInsurance = "0"
        'CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("lblInsurance"), Label).Text
        'If EL.SalaryStrMInsurance = "Y" Then
        '    ChkInsurance.Checked = True
        'Else
        '    ChkInsurance.Checked = False
        'End If
        EL.SalaryStrMInsurance = "0"
        EL.SalaryStrMPF = CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("lblPF"), Label).Text
        If EL.SalaryStrMPF = "Y" Then
            ChkPf.Checked = True
        Else
            ChkPf.Checked = False
        End If
        EL.SalaryStrLTA = CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("lblLTA"), Label).Text
        If EL.SalaryStrLTA = "Y" Then
            ChkLTA.Checked = True
        Else
            ChkLTA.Checked = False
        End If
        EL.SalaryStrSFood = CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("lblSubscribedFood"), Label).Text
        If EL.SalaryStrSFood = "Y" Then
            ChkSubscribedFood.Checked = True
        Else
            ChkSubscribedFood.Checked = False
        End If
        EL.SalaryStrMTransport = CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("lblTransport"), Label).Text
        If EL.SalaryStrMTransport = "Y" Then
            ChkTransport.Checked = True
        Else
            ChkTransport.Checked = False
        End If
        EL.SalaryStrAssistance = CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("lblAssistance"), Label).Text
        If EL.SalaryStrAssistance = "Y" Then
            ChkAssistance.Checked = True
        Else
            ChkAssistance.Checked = False
        End If
        EL.SalaryStrAccommodation = "0"
        'CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("lblAccommodation"), Label).Text
        'If EL.SalaryStrAccommodation = "Y" Then
        '    ChkAccomodation.Checked = True
        'Else
        '    ChkAccomodation.Checked = False
        'End If
        EL.SalaryStrAccommodation = "0"
        ViewState("RCID") = CType(GVSalaryStructure.Rows(e.NewEditIndex).FindControl("SSID"), HiddenField).Value
        InsertSalaryStrcure.Text = "UPDATE"
        ViewSalaryStrcure.Text = "BACK"
        EL.Id = ViewState("RCID")
        dt = BL.GetSalaryStructure(EL)

        GVSalaryStructure.DataSource = dt
        GVSalaryStructure.DataBind()
        GVSalaryStructure.Enabled = False
        lblSerrmsg.Text = ""
        lblSmsgifo.Text = ""
        'Else
        'lblSerrmsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblSmsgifo.Text = ""
        'End If
    End Sub

    Protected Sub TabPanel2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPanel2.Load

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
