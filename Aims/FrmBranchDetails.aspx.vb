
Partial Class FrmBranchDetails
    Inherits BasePage
    Dim BLL As New BranchManager
    Dim EL As New Branch
    Dim GlobalFunction As New GlobalFunction
    Dim a As Integer
    Dim dt As New Data.DataTable
    Dim path, path1, Imgpath, Imgpath1 As String

    Protected Sub ddlBrnType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBrnType.SelectedIndexChanged
        BranchType()
    End Sub
    Sub BranchType()
        'To Fill Report Branch Combo
        lblval.Text = ""
        lblmsg.Text = ""
        'Try
        If Page.IsPostBack Then
            Dim BrCode, BrTypeId As String
            Dim dt, dt1 As New DataTable
            BrCode = ddlBrnType.SelectedItem.Value
            If BrCode = "02" Then
                BrTypeId = "01"
            ElseIf BrCode = "03" Then
                BrTypeId = "02"
            ElseIf BrCode = "04" Then
                BrTypeId = "03"
            ElseIf BrCode = "05" Then
                BrTypeId = "04"
            End If
            ddlRptBrn.Items.Clear()
            dt = BLL.GetRptBrnId(BrTypeId, ddlHO.SelectedValue)
            If dt.Rows.Count > 0 Then
                ddlRptBrn.DataSource = dt
                ddlRptBrn.DataBind()
            Else
                If BrCode = "02" Then
                    Dim ds As New DataSet
                    ds = BLL.FillHO()
                    ddlRptBrn.DataSource = ds.Tables(0)
                    ddlRptBrn.DataBind()
                Else
                    lblval.Text = "Please Create branch in Hierarchy Order."
                    lblmsg.Text = ""
                End If
            End If
        End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try
    End Sub
    Protected Sub Btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        'Code for Add & Update
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                lblval.Text = ""
                lblmsg.Text = ""
                Dim tpno, contn As String
                EL = New Branch
                EL.Website = txtwebsite.Text
                EL.EmailID = txtEmail.Text
                If ViewState("ImageTime") = "" Then
                    EL.Logo = "~\Images\imageupload.gif"
                Else
                    EL.Logo = ViewState("ImageTime")
                End If
                If ViewState("BranchDefaultImg") = "" Then
                    EL.BranchImg = ""
                Else
                    EL.BranchImg = ViewState("BranchDefaultImg")
                End If
                EL.HOCode = ddlHO.SelectedValue
                EL.BrnType = ddlBrnType.SelectedValue
                EL.RptBrn = ddlRptBrn.SelectedValue
                EL.Name = txtBrnName.Text
                EL.SSBCode = txtBrnCode.Text
                EL.Address = txtBrnAddrs.Text
                EL.ContactNo = txtContactNo.Text
                EL.AccountNo = txtacc.Text
                EL.BankCode = ViewState("BankCode")
                EL.BankBranch = ""
                EL.BreakTime = IIf(txtBreakTime.Text = "", 0, txtBreakTime.Text)
                EL.FromEmailID = txtFromEmailID.Text
                EL.SMTPHost = txtSMTPHost.Text
                EL.FromPassword = txtFromPassword.Text
                EL.SMSService = ddlSMSService.SelectedValue
                EL.EmailService = ddlEmailService.SelectedValue
                EL.AffiliatedTo = txtAffiliatedTo.Text
                EL.ApprovedBy = txtApprovedBy.Text
                EL.Accredited = txtAccredited.Text
                EL.BranchRegistationNo = txtBranchRegistationNo.Text
                EL.Biometric = txtbiometric.Text
                EL.PFAcct = txtpfAcct.Text
                If HidBankId.Value = "" Then
                    EL.BankId = 0
                Else
                    EL.BankId = HidBankId.Value
                End If
                If ddldesignation.SelectedValue = "Select" Then
                    EL.Designation = 0
                Else
                    EL.Designation = ddldesignation.SelectedValue
                End If
                EL.ContactPerson = ddlemp.SelectedValue
                EL.SPassword = RijndaelSimple.Encrypt(txtSPassword.Text, _
                                           RijndaelSimple.passPhrase, _
                                           RijndaelSimple.saltValue, _
                                           RijndaelSimple.hashAlgorithm, _
                                           RijndaelSimple.passwordIterations, _
                                           RijndaelSimple.initVector, _
                                           RijndaelSimple.keySize)
                EL.TagLine = txtTagline.Text
                If txtCreationDate.Text = "" Then
                    EL.CreationDate = "1900-01-01"
                Else
                    EL.CreationDate = txtCreationDate.Text
                End If

                EL.Status = DDLStatus.SelectedValue
                If ChkHoName.Checked = True Then
                    EL.IncludeInsName = "Y"
                Else
                    EL.IncludeInsName = "N"
                End If
                If ChkTeacherSubject.Checked = True Then
                    EL.ChkTeacherSubject = "Y"
                Else
                    EL.ChkTeacherSubject = "N"
                End If
                If Btnadd.Text = "ADD" Then
                    If ViewState("ExpiryDate") > Today Then
                        If txtContactNo.Text <> "" Then
                            tpno = txtContactNo.Text
                            'If tpno.Length > 12 Or tpno.Length < 6 Then
                            '    lblmsg.Text = ""
                            '    lblval.Text = "Contact No must be greater than 7 or lesser than 12."
                            'Else
                            '    contn = "proceed"
                            'End If
                            contn = "proceed"
                        Else
                            contn = "proceed"
                        End If
                        If contn = "proceed" And ddlHO.SelectedValue <> "Select" And ddlBrnType.SelectedValue <> "Select" And ddlRptBrn.SelectedValue <> "Select" Then
                            If BLL.InsertRecord(EL) = 0 Then
                                lblval.Text = "Data already exists."
                                lblmsg.Text = ""
                            Else
                                lblval.Text = ""
                                lblmsg.Text = "Data Saved Successfully."
                                clear()
                            End If
                        ElseIf ddlHO.SelectedValue = "Select" Or ddlBrnType.SelectedValue = "Select" Or ddlRptBrn.SelectedValue = "Select" Then
                            lblval.Text = "Enter all the mandatory field."
                            lblmsg.Text = ""
                        End If
                    Else
                        lblval.Text = "Institute has expired cannot create New Branch."
                    End If
                ElseIf Btnadd.Text = "UPDATE" Then
                    EL.Id = txtId.Text
                    If Trim(txtContactNo.Text) <> "" Then
                        tpno = txtContactNo.Text
                        'If tpno.Length > 12 Or tpno.Length < 6 Then
                        '    lblval.Text = "Contact No must be greater than 7 or lesser than 12."
                        '    lblmsg.Text = ""
                        'Else
                        '    contn = "proceed"
                        'End If
                        contn = "proceed"
                    Else
                        contn = "proceed"
                    End If
                    If contn = "proceed" And ddlHO.SelectedValue <> "Select" And ddlBrnType.SelectedValue <> "Select" And ddlRptBrn.SelectedValue <> "Select" Then
                        If BLL.UpdateRecord(EL) = 0 Then
                            lblval.Text = "Data already exists."
                            lblmsg.Text = ""
                            Btnview.Text = "VIEW"
                            Btnadd.Text = "ADD"
                        Else
                            lblval.Text = ""
                            lblmsg.Text = "Data Updated Successfully."
                            clear()
                            Btnadd.Text = "ADD"
                            Btnview.Text = "VIEW"
                            GrdBranch.Enabled = True
                            Dim dt As New DataTable
                            dt = BLL.GetBranchByBranchId(0, ddlHO.SelectedValue)
                            GrdBranch.DataSource = dt
                            GrdBranch.DataBind()
                        End If
                    ElseIf ddlHO.SelectedValue = "Select" Or ddlBrnType.SelectedValue = "Select" Or ddlRptBrn.SelectedValue = "Select" Then
                        lblval.Text = "Enter all the mandatory field."
                        lblmsg.Text = ""
                    End If
                End If
                Dim dt1 As New DataTable
                dt1 = BLL.GetBranchByBranchId(0, ddlHO.SelectedValue)
                GrdBranch.DataSource = dt1
                GrdBranch.DataBind()
                GrdBranch.Enabled = True
            Else
                lblval.Text = "You do not have permission, Cannot add data."
                lblmsg.Text = ""
            End If
        Else
            lblval.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GrdBranch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdBranch.Load
        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "callFunctionsStartupScript", "grid();", True)
    End Sub
    Protected Sub txtAcctBranch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcctBranch.TextChanged
        If txtAcctBranch.Text = "" Then
            HidBankId.Value = ""
        Else
            HidBankId.Value = HidBankId.Value
        End If
    End Sub
    Protected Sub UploadLogo(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload1.Click
        PhotoUpload()
    End Sub
    Sub PhotoUpload()
        If FileUpload1.FileName <> "" Then
            If FileUpload1.PostedFile.ContentLength <= 30000 Then
                Try
                    If ViewState("ImageTime") <> Nothing Then
                        Dim Foto As String = Session("Path") + ViewState("ImageTime").ToString.Replace("~/", "")
                        Foto = Foto.Replace("/", "\")
                        If IO.File.Exists(Foto) Then
                            IO.File.Delete(Foto)
                        End If
                    End If
                    ViewState("ImageTime") = ""
                    lblmsg.Text = ""
                    lblval.Text = ""
                    path = "E" & txtBrnName.Text.Trim.ToString().Replace(" ", "") + TimeOfDay.ToString().Replace("/", "").Replace(":", "") & ".jpg"
                    Me.FileUpload1.SaveAs(Server.MapPath("~/Images/" & path))
                    path1 = "~/Images/" & path
                    ViewState("ImageTime") = "~/Images/" & path
                    Me.ImageMap1.ImageUrl = path1
                Catch ex As Exception
                    lblval.Text = ""
                    lblmsg.Text = "Error while Uploading Logo. Please refresh the page and try once again."
                End Try
            Else
                lblval.Text = "Photo Size should be less than or equal to 30 KB."
                lblmsg.Text = ""
            End If
        Else
            lblval.Text = "Browse to upload the photo."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub UploadImage(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBranchImg.Click
        ImgUpload()
    End Sub

    Sub ImgUpload()
        If FileUpload2.FileName <> "" Then
            Try
                If ViewState("BranchDefaultImg") <> Nothing Then
                    Dim Image As String = Session("Path") + ViewState("ImageTime").ToString.Replace("~/", "")
                    Image = Image.Replace("/", "\")
                    If IO.File.Exists(Image) Then
                        IO.File.Delete(Image)
                    End If
                End If
                ViewState("BranchDefaultImg") = ""
                lblmsg.Text = ""
                lblval.Text = ""
                Imgpath = "E" & txtBrnName.Text.Trim.ToString().Replace(" ", "") + TimeOfDay.ToString().Replace("/", "").Replace(":", "") & ".jpg"
                Me.FileUpload2.SaveAs(Server.MapPath("~/Images/" & Imgpath))
                Imgpath1 = "~/Images/" & Imgpath
                ViewState("BranchDefaultImg") = "~/Images/" & Imgpath
                Me.BranchImg.ImageUrl = Imgpath1
            Catch ex As Exception
                lblval.Text = ""
                lblmsg.Text = "Error while Uploading Logo. Please refresh the page and try once again."
            End Try
        Else
            lblval.Text = "Browse to upload the photo."
            lblmsg.Text = ""
        End If
    End Sub
    Sub clear()
        'To clear the controls
        ImageMap1.ImageUrl = "~/Images/imageupload.gif"
        BranchImg.ImageUrl = "~/Images/Schoolmgmt.jpg"
        ViewState("ImageTime") = ""
        txtBrnName.Text = ""
        txtBrnCode.Text = ""
        txtBrnAddrs.Text = ""
        txtContactNo.Text = ""
        ddldesignation.ClearSelection()
        ddlemp.Items.Clear()
        txtacc.Text = ""
        ddlBrnType.ClearSelection()
        ddlRptBrn.ClearSelection()
        txtBreakTime.Text = ""
        txtFromEmailID.Text = ""
        txtFromPassword.Text = ""
        txtSMTPHost.Text = ""
        ddlSMSService.SelectedValue = ""
        ddlEmailService.SelectedValue = ""
        txtAffiliatedTo.Text = ""
        txtApprovedBy.Text = ""
        txtAccredited.Text = ""
        txtBranchRegistationNo.Text = ""
        txtTagline.Text = ""
        txtSPassword.Text = ""
        ChkHoName.Checked = True
        ChkTeacherSubject.Checked = False
        txtSPassword.Text = ""
        txtTagline.Text = ""
        txtbiometric.Text = ""
        txtpfAcct.Text = ""
        txtAcctBranch.Text = ""
    End Sub

    Protected Sub Btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnview.Click
        LinkButton4.Focus()
        'Code for View & Back
        lblval.Text = ""
        lblmsg.Text = ""
        If Btnview.Text = "VIEW" Then
            Dim dt As New DataTable
            dt = BLL.GetBranchByBranchId(0, ddlHO.SelectedValue)
            GrdBranch.DataSource = dt
            GrdBranch.DataBind()
            GrdBranch.Enabled = True
            ViewState("Button") = "View"
        ElseIf Btnview.Text = "BACK" Then
            GrdBranch.Visible = True
            Btnview.Text = "VIEW"
            Btnadd.Text = "ADD"
            Dim dt As New DataTable
            dt = BLL.GetBranchByBranchId(0, ddlHO.SelectedValue)
            GrdBranch.DataSource = dt
            GrdBranch.DataBind()
            GrdBranch.Enabled = True
            ddlBrnType.SelectedIndex = 0
            ddlHO.SelectedIndex = 0
            ddlemp.Items.Clear()
            ddldesignation.ClearSelection()
            ddlemp.ClearSelection()
            ddlRptBrn.Items.Clear()
            ddlRptBrn.ClearSelection()
            txtBrnName.Text = ""
            txtBrnCode.Text = ""
            txtBrnAddrs.Text = ""
            txtContactNo.Text = ""
            txtacc.Text = ""
            clear()
        End If
        lblmsg.Text = ""
        lblval.Text = ""
        GrdBranch.Visible = True
    End Sub

    Protected Sub GrdBranch_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdBranch.PageIndexChanging
        GrdBranch.PageIndex = e.NewPageIndex
        Dim dt As New DataTable
        lblval.Text = ""
        lblmsg.Text = ""
        If ViewState("Button") = "View" Then
            dt = BLL.GetBranchByBranchId(0, ddlHO.SelectedValue)
            GrdBranch.DataSource = dt
            GrdBranch.DataBind()
        ElseIf ViewState("Button") = "Search" Then
            EL.HOCode = ddlHO.SelectedValue
            EL.BrnType = ddlBrnType.SelectedValue
            EL.RptBrn = ddlRptBrn.SelectedValue
            EL.Name = txtBrnName.Text
            EL.SSBCode = txtBrnCode.Text
            EL.Address = txtBrnAddrs.Text
            EL.ContactNo = txtContactNo.Text
            EL.Designation = ddldesignation.SelectedValue
            EL.ContactPerson = ddlemp.SelectedValue
            EL.AccountNo = txtacc.Text
            EL.BankBranch = ""
            dt = DLBranchDB.GetBranchSearch(EL)
            GrdBranch.DataSource = dt
            GrdBranch.DataBind()
        End If
    End Sub
    Protected Sub GrdBranch_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdBranch.RowDeleting
        'To delete the records in Gridview
        lblval.Text = ""
        lblmsg.Text = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                EL.Id = CType(GrdBranch.Rows(e.RowIndex).FindControl("HidBID"), HiddenField).Value
                Dim dt5 As New DataTable
                dt5 = BLL.GetBranchByBranchId(EL.Id, ddlHO.SelectedValue)
                If dt5.Rows(0)("BranchTypeCode").ToString() = "01" Then
                    lblmsg.Text = ""
                    lblval.Text = "Cannot delete Head Office details."
                Else
                    BLL.ChangeFlag(EL)
                    Dim dt As New DataTable
                    dt = BLL.GetBranchByBranchId(0, ddlHO.SelectedValue)
                    GrdBranch.DataSource = dt
                    GrdBranch.DataBind()
                    lblval.Text = ""
                    lblmsg.Text = "Data Deleted Successfully."
                End If
            Else
                lblval.Text = "You do not have permission, Cannot delete data."
                lblmsg.Text = ""
            End If
        Else
            lblval.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If

    End Sub
    Protected Sub GrdBranch_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdBranch.RowEditing
        'To Edit the records in gridview
        lblval.Text = ""
        lblmsg.Text = ""
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        a = GlobalFunction.UserPrivilage()
        If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
            Dim dt5 As New DataTable
            txtId.Text = CType(GrdBranch.Rows(e.NewEditIndex).FindControl("LabelId"), Label).Text()
            dt5 = BLL.GetBranchByBranchId(txtId.Text, ddlHO.SelectedValue)
            If dt5.Rows(0)("BranchTypeCode").ToString() = "01" Then
                lblmsg.Text = ""
                lblval.Text = "Cannot edit Head Office details."
            Else
                ddlHO.SelectedValue = dt5.Rows(0)("HOCode").ToString()
                ddlBrnType.SelectedValue = dt5.Rows(0)("BranchTypeCode").ToString()
                BranchType()
                ddlRptBrn.SelectedValue = dt5.Rows(0)("ReportBrnCode").ToString()
                txtBrnName.Text = dt5.Rows(0)("BranchName").ToString()
                txtBrnCode.Text = dt5.Rows(0)("SlssbCode").ToString()
                txtBrnAddrs.Text = dt5.Rows(0)("Address").ToString()
                txtContactNo.Text = dt5.Rows(0)("ContactNo").ToString()
                txtBreakTime.Text = dt5.Rows(0)("BreakTime").ToString()
                txtSMTPHost.Text = dt5.Rows(0)("SMTPHost").ToString()
                txtFromEmailID.Text = dt5.Rows(0)("FromEmailID").ToString()
                txtFromPassword.Text = dt5.Rows(0)("FromPassword").ToString()
                ddlSMSService.SelectedValue = dt5.Rows(0)("SMSService").ToString()
                ddlEmailService.SelectedValue = dt5.Rows(0)("EmailService").ToString()
                txtAffiliatedTo.Text = dt5.Rows(0)("AffiliatedTo").ToString()
                txtApprovedBy.Text = dt5.Rows(0)("ApprovedBy").ToString()
                txtAccredited.Text = dt5.Rows(0)("Accredited").ToString()
                txtBranchRegistationNo.Text = dt5.Rows(0)("BranchRegistationNo").ToString()
                txtwebsite.Text = dt5.Rows(0)("Website").ToString()
                txtEmail.Text = dt5.Rows(0)("ContactEmailID").ToString()
                ImageMap1.ImageUrl = dt5.Rows(0)("Logo").ToString.Trim
                ViewState("ImageTime") = dt5.Rows(0)("Logo").ToString.Trim
                DDLStatus.SelectedValue = dt5.Rows(0)("Status").ToString.Trim
                txtTagline.Text = dt5.Rows(0)("Tagline").ToString()
                txtpfAcct.Text = dt5.Rows(0)("PFAcct").ToString()
                txtAcctBranch.Text = dt5.Rows(0)("Bank_Name").ToString()
                HidBankId.Value = dt5.Rows(0)("BankId").ToString()
                BranchImg.ImageUrl = dt5.Rows(0)("BranchImg").ToString.Trim
                ViewState("BranchDefaultImg") = dt5.Rows(0)("BranchImg").ToString.Trim
                If dt5.Rows(0)("Creationdate").ToString.Trim <> "" Then
                    Dim CreationDate As DateTime = dt5.Rows(0)("Creationdate")
                    txtCreationDate.Text = Format(CreationDate, "dd-MMM-yyyy")
                Else
                    txtCreationDate.Text = ""
                End If
                txtSPassword.Text = RijndaelSimple.Decrypt(dt5.Rows(0)("SPassword").ToString.Trim, _
                                                   RijndaelSimple.passPhrase, _
                                                   RijndaelSimple.saltValue, _
                                                   RijndaelSimple.hashAlgorithm, _
                                                   RijndaelSimple.passwordIterations, _
                                                   RijndaelSimple.initVector, _
                                                   RijndaelSimple.keySize)
                txtSPassword.Attributes.Add("value", txtSPassword.Text)
                txtbiometric.Text = dt5.Rows(0)("BiometricDeviceID").ToString.Trim
                If dt5.Rows(0)("IncludeInsName").ToString.Trim = "Y" Then
                    ChkHoName.Checked = True
                Else
                    ChkHoName.Checked = False
                End If
                If dt5.Rows(0)("TeacherSubjectMapping").ToString.Trim = "Y" Then
                    ChkTeacherSubject.Checked = True
                Else
                    ChkTeacherSubject.Checked = False
                End If

                If dt5.Rows(0)("Designation").ToString() = "0" Then
                    ddldesignation.SelectedValue = "Select"
                Else
                    ddldesignation.SelectedValue = dt5.Rows(0)("Designation").ToString()
                End If
                txtacc.Text = dt5.Rows(0)("AccountNo").ToString()
                ddlHO.Enabled = False
                ddlBrnType.Enabled = False
                ddlRptBrn.Enabled = False
                Btnadd.Text = "UPDATE"
                Btnview.Text = "BACK"
                GrdBranch.DataSource = dt5
                GrdBranch.DataBind()
                GrdBranch.Enabled = False
            End If

        Else
            lblval.Text = "You do not have permission, Cannot edit data."
            lblmsg.Text = ""
        End If
        'Else
        'lblval.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        ddlHO.Enabled = True
        ddlBrnType.Enabled = True
        ddlRptBrn.Enabled = True

        If Not IsPostBack Then
            txtCreationDate.Text = Format(Today, "dd-MMM-yyyy")
            If Session("BranchCode") <> "000000000000" Then
                Btnadd.Visible = False
                GrdBranch.Columns(0).Visible = False
                'GrdBranch.Columns(1).Visible = False
                ddlHO.SelectedValue = Session("InstituteCode")
                dt = BLL.GetBranchByBranchId(0, ddlHO.SelectedValue)
                'If dt.Rows(0)("BranchTypeCode").ToString() = "01" Then
                '    lblmsg.Text = ""
                '    lblval.Text = "Cannot edit Head Office details."
                'Else
                ddlHO.SelectedValue = dt.Rows(0)("HOCode").ToString()
                ddlBrnType.SelectedValue = dt.Rows(0)("BranchTypeCode").ToString()
                BranchType()
                ddlRptBrn.SelectedValue = dt.Rows(0)("ReportBrnCode").ToString()
                txtBrnName.Text = dt.Rows(0)("BranchName").ToString()
                txtBrnCode.Text = dt.Rows(0)("SlssbCode").ToString()
                txtBrnAddrs.Text = dt.Rows(0)("Address").ToString()
                txtContactNo.Text = dt.Rows(0)("ContactNo").ToString()
                txtBreakTime.Text = dt.Rows(0)("BreakTime").ToString()
                txtSMTPHost.Text = dt.Rows(0)("SMTPHost").ToString()
                txtFromEmailID.Text = dt.Rows(0)("FromEmailID").ToString()
                txtFromPassword.Text = dt.Rows(0)("FromPassword").ToString()
                ddlSMSService.SelectedValue = dt.Rows(0)("SMSService").ToString()
                ddlEmailService.SelectedValue = dt.Rows(0)("EmailService").ToString()
                txtAffiliatedTo.Text = dt.Rows(0)("AffiliatedTo").ToString()
                txtApprovedBy.Text = dt.Rows(0)("ApprovedBy").ToString()
                txtAccredited.Text = dt.Rows(0)("Accredited").ToString()
                txtBranchRegistationNo.Text = dt.Rows(0)("BranchRegistationNo").ToString()
                txtwebsite.Text = dt.Rows(0)("Website").ToString()
                txtEmail.Text = dt.Rows(0)("ContactEmailID").ToString()
                ImageMap1.ImageUrl = dt.Rows(0)("Logo").ToString.Trim
                ViewState("ImageTime") = dt.Rows(0)("Logo").ToString.Trim
                DDLStatus.SelectedValue = dt.Rows(0)("Status").ToString.Trim
                txtTagline.Text = dt.Rows(0)("Tagline").ToString()
                txtCreationDate.Text = dt.Rows(0)("Creationdate").ToString()
                txtpfAcct.Text = dt.Rows(0)("PFAcct").ToString()
                txtAcctBranch.Text = dt.Rows(0)("Bank_Name").ToString()
                txtSPassword.Text = RijndaelSimple.Decrypt(dt.Rows(0)("SPassword").ToString.Trim, _
                                                   RijndaelSimple.passPhrase, _
                                                   RijndaelSimple.saltValue, _
                                                   RijndaelSimple.hashAlgorithm, _
                                                   RijndaelSimple.passwordIterations, _
                                                   RijndaelSimple.initVector, _
                                                   RijndaelSimple.keySize)
                txtSPassword.Attributes.Add("value", txtSPassword.Text)
                If dt.Rows(0)("IncludeInsName").ToString.Trim = "Y" Then
                    ChkHoName.Checked = True
                Else
                    ChkHoName.Checked = False
                End If
                If dt.Rows(0)("TeacherSubjectMapping").ToString.Trim = "Y" Then
                    ChkTeacherSubject.Checked = True
                Else
                    ChkTeacherSubject.Checked = False
                End If
                If dt.Rows(0)("Designation").ToString() = "0" Then
                    ddldesignation.SelectedValue = "Select"
                Else
                    If ddldesignation.SelectedValue = "Select" Then
                        ddldesignation.SelectedItem.Text = "Select"
                    Else
                        ddldesignation.SelectedValue = dt.Rows(0)("Designation").ToString()
                    End If
                End If
                txtacc.Text = dt.Rows(0)("AccountNo").ToString()
                ddlHO.Enabled = False
                ddlBrnType.Enabled = False
                ddlRptBrn.Enabled = False
                GrdBranch.DataSource = dt
                GrdBranch.DataBind()
                GrdBranch.Enabled = False


                ddlHO.Enabled = False
                ddlBrnType.Enabled = False
                BranchType()
                ddlRptBrn.Enabled = False
                txtBrnName.ReadOnly = True
                txtBrnCode.ReadOnly = True
                txtBrnAddrs.ReadOnly = True
                txtContactNo.ReadOnly = True
                txtBreakTime.ReadOnly = True
                txtSMTPHost.ReadOnly = True
                txtFromEmailID.ReadOnly = True
                txtFromPassword.ReadOnly = True
                ddlSMSService.Enabled = False
                ddlEmailService.Enabled = False
                txtAffiliatedTo.ReadOnly = True
                txtApprovedBy.ReadOnly = True
                txtAccredited.ReadOnly = True
                txtBranchRegistationNo.ReadOnly = True
                txtwebsite.ReadOnly = True
                txtEmail.ReadOnly = True
                DDLStatus.Enabled = False
                txtTagline.ReadOnly = True
                txtSPassword.ReadOnly = True
                ChkHoName.Enabled = False
                ChkTeacherSubject.Enabled = False
                ddldesignation.Enabled = False
                txtacc.ReadOnly = True
                txtpfAcct.ReadOnly = True
                txtAcctBranch.ReadOnly = True
                'End If
            Else
                Btnadd.Visible = True
                GrdBranch.Columns(0).Visible = True
                'GrdBranch.Columns(1).Visible = True
                ddlHO.SelectedValue = "000000000000"
            End If
        End If
        If Not Page.IsPostBack Then
            ImageMap1.ImageUrl = "~\Images\imageupload.gif"
            BranchImg.ImageUrl = "~\Images\Schoolmgmt.jpg"
        End If
    End Sub
    Protected Sub ddldesignation_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddldesignation.SelectedIndexChanged
        FillContactPerson()
        lblval.Text = ""
        lblmsg.Text = ""
        If Btnadd.Text = "UPDATE" Then
            ddlHO.Enabled = False
            ddlBrnType.Enabled = False
            ddlRptBrn.Enabled = False
        End If
    End Sub
    Sub FillContactPerson()
        lblval.Text = ""
        lblmsg.Text = ""
        Dim dt As New Data.DataTable
        EL.Designation = ddldesignation.SelectedValue
        dt = DLBranchDB.GetEmployee(EL)
        ddlemp.DataSource = dt
        ddlemp.DataTextField = "Emp_Name"
        ddlemp.DataValueField = "Emp_Code"
        ddlemp.DataBind()
    End Sub

    Protected Sub btnsearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsearch.Click
        a = GlobalFunction.UserPrivilage()
        If a = 1 Or a = 2 Or a = 3 Or a = 4 Then
            lblval.Text = ""
            lblmsg.Text = ""
            If ddlHO.SelectedValue <> "Select" Or ddlBrnType.SelectedValue <> "Select" Or ddlRptBrn.SelectedValue <> "Select" Or txtBrnName.Text <> "" Or txtBrnCode.Text <> "" Or txtBrnAddrs.Text <> "" Or txtContactNo.Text <> "" Or ddldesignation.SelectedValue <> "Select" Or ddlemp.SelectedValue <> "Select" Or txtacc.Text <> "" Then
                If ddlHO.SelectedValue <> "Select" Then
                    EL.HOCode = ddlHO.SelectedValue
                Else
                    EL.HOCode = "Select"
                End If
                If ddlBrnType.SelectedValue <> "Select" Then
                    EL.BrnType = ddlBrnType.SelectedValue
                Else
                    EL.BrnType = "Select"
                End If
                If ddlRptBrn.SelectedValue <> "Select" Then
                    EL.RptBrn = ddlRptBrn.SelectedValue
                Else
                    EL.RptBrn = "Select"
                End If
                If txtBrnName.Text <> "" Then
                    EL.Name = txtBrnName.Text
                End If
                If txtBrnCode.Text <> "" Then
                    EL.SSBCode = txtBrnCode.Text
                End If
                If txtBrnAddrs.Text <> "" Then
                    EL.Address = txtBrnAddrs.Text
                End If
                If txtContactNo.Text <> "" Then
                    EL.ContactNo = txtContactNo.Text
                End If
                If ddldesignation.SelectedValue <> "Select" Then
                    EL.Designation = ddldesignation.SelectedValue
                Else
                    EL.Designation = "Select"
                End If
                If ddlemp.SelectedValue <> "Select" Then
                    EL.ContactPerson = ddlemp.SelectedValue
                Else
                    EL.ContactPerson = "Select"
                End If
                If txtacc.Text <> "" Then
                    EL.AccountNo = txtacc.Text
                End If
                EL.BankBranch = ""
                dt = DLBranchDB.GetBranchSearch(EL)
                GrdBranch.DataSource = dt
                GrdBranch.DataBind()
                GrdBranch.Visible = True
                ViewState("Button") = "Search"
            Else
                lblmsg.Text = ""
                lblval.Text = "Fill any one Field."
                GrdBranch.Visible = False
            End If
        Else
            lblmsg.Text = ""
            lblval.Text = "No Read Permission!"
        End If
    End Sub

    Protected Sub ddlRptBrn_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRptBrn.PreRender
        If ddlRptBrn.Items.Count > 0 Then
            If ddlRptBrn.Items(0).Text <> "Select" Then
                ddlRptBrn.Items.Insert(0, "Select")
            End If
        Else
            ddlRptBrn.Items.Insert(0, "Select")
        End If
        dt = DLBranchDB.GetExpiryDate(ddlHO.SelectedValue)
        'ViewState("ExpiryDate") = dt.Rows(0)("InstExpiryDate")
    End Sub

    Protected Sub ddlHO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHO.SelectedIndexChanged
        Try
            ddlRptBrn.Items.Clear()
            ddlBrnType.SelectedItem.Selected = False
            dt = DLBranchDB.GetExpiryDate(ddlHO.SelectedValue)
            ViewState("ExpiryDate") = dt.Rows(0)("InstExpiryDate")
        Catch ex As Exception

        End Try
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GrdBranch_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GrdBranch.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        dt = BLL.GetBranchByBranchId(0, ddlHO.SelectedValue)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GrdBranch.DataSource = sortedView
        GrdBranch.DataBind()
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
