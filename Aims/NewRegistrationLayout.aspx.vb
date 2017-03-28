
Partial Class NewRegistrationLayout
    Inherits BasePage
    Dim Studentcode, path, path1 As String
    Dim newID As Integer
    Dim ALstore As New ArrayList()
    Dim sql, alt As String
    Dim GlobalFunction As New GlobalFunction
    Dim st_id As String
    Dim quali As New Qualification
    Dim q As New QualificationManager
    Dim sm As New StudentManager
    Dim dt As New DataTable
    Dim s As New Student
    Dim dispId As Integer

    Dim EnquiryManager As New EnquiryManager

    Protected Sub GVDetails_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVDetails.PageIndexChanging
        GVDetails.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVDetails.PageIndex
        DisplayGrid()
        GVDetails.Visible = True
    End Sub

    Sub StdClear()
        texApp.Text = ""
        txtFullName.Text = ""
        Txtbirthplace.Text = ""
        Me.txtCaddr.Text = ""
        txtNicNo.Text = ""
        Me.txtdob.Text = ""
        Me.txtFname.Text = ""
        Me.txtregno.Text = ""
        Me.txtSecondUSN.Text = ""
        CheckSMS.Checked = False
        CheckFSMS.Checked = False
        CheckMail.Checked = False
        CheckFMail.Checked = False
        Me.txt_occupt.Text = ""
        Me.txtIncome.Text = ""
        Me.txtname.Text = ""
        Me.txtperphone.Text = ""
        Me.txtPaddr.Text = ""
        Me.txtCity.Text = ""
        Me.txtPC.Text = ""
        Me.txtdistance.Text = ""
        'Me.txtCountry.Text = ""

        'Me.txtdistrict.Text = ""
        Me.txtddno.Text = ""
        Me.txtreceiptno.Text = ""
        Me.txtprospectusno.Text = ""
        Me.txtage.Text = ""
        Me.txtemail.Text = ""
        txtLeavingDate.Text = ""
        txtemailstd.Text = ""
        txtperphonestd.Text = ""
        ChkTransport.Checked = False
        ChkHostel.Checked = False
        Me.ImageMap1.ImageUrl = "~/Images/imageupload.gif"
        Me.txtAdate.Text = "" ' Format(Date.Today, "dd-MMM-yyyy")
        txtMotheName.Text = ""
        txtFatherEmail.Text = ""
        txtFatherContact.Text = ""
        txtpath.Text = ""
        ViewState("ImageTime") = ""
        txtNameinpassport.Text = ""
        txtPassportNo.Text = ""
        txtPassportIssueDate.Text = ""
        txtVisaExpDate.Text = ""
        txtVisaIssueDate.Text = ""
        txtVisaNo.Text = ""
        txtPlaceofIssue.Text = ""
        txtExpiryDate.Text = ""
        cmbBranch.Text = ""
        txtTCNo.Text = ""
        txtRemarks.Text = ""
        txtMotherTongue.Text = ""
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox4.Checked = False
        CheckBox5.Checked = False
        CheckBox6.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox9.Checked = False
        CheckBox10.Checked = False
        CheckBox11.Checked = False
        CheckBox12.Checked = False
        CheckBox13.Checked = False
        txtFHomeContact.Text = ""
        txtMHomeContact.Text = ""
        txtFBizContact.Text = ""
        txtMBizContact.Text = ""
        txtFatherQualification.Text = ""
        txtMotherQualification.Text = ""
        txtMotherOccupation.Text = ""
        txtReligion.Text = ""
        txtFHomeContact.Text = ""
        txtMHomeContact.Text = ""
        txtFBizContact.Text = ""
        txtMBizContact.Text = ""
        txtFatherQualification.Text = ""
        txtMotherQualification.Text = ""
        txtMotherOccupation.Text = ""
        txtReligion.Text = ""
        txtIndex.Text = ""
        txtlblLName.Text = ""
        txtmidname.Text = ""
        txtcitizen.Text = ""
        txtGDContactNo.Text = ""
        txtGDEmail.Text = ""
        txtGDName.Text = ""
        txtGO.Text = ""
    End Sub
    Sub StdEnb()
        Me.txtCaddr.ReadOnly = True
        Me.txtdob.ReadOnly = True
        Me.txtFname.ReadOnly = True
        Me.txtname.ReadOnly = True
        Me.txtperphone.ReadOnly = True
        Me.txtPaddr.ReadOnly = True
        Me.ddlcategry.Enabled = False
        Me.ddlCourse.Enabled = False
        Me.ddlsponsor.Enabled = False
        Me.ddlgender.Enabled = False
        Me.txtdob.ReadOnly = True
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            If Session("LoginType") = "Others" Then
                If Session("AccessLevel") = "" Then

                    Session("AccessLevel") = "05"
                End If
                If Session("StudentCode") = Session("StudentCode") Then


                    s.Code = Session("StudentCode")
                    dt = StudentDB.studentForParentStd(s)
                    Session("EmpCode") = dt.Rows(0)("EmpCode").ToString
                    ''UserCode instead of userid
                    Session("UserCode") = dt.Rows(0)("UserName").ToString
                    Dim x As String
                    txtname.Text = dt.Rows(0).Item("STD_FullName")
                    txtregno.Text = dt.Rows(0).Item("stdCode").ToString
                    s.Id = dt.Rows(0).Item("StdId")
                    txtcid.Text = dt.Rows(0).Item("StdId")
                    ViewState("StdId") = dt.Rows(0).Item("StdId")
                    txtcid.Text = ViewState("StdId")

                    txtregno.Enabled = False
                    If dt.Rows(0).Item("Hostel") = "N" Then
                        ChkHostel.Checked = False
                    Else
                        ChkHostel.Checked = True
                    End If
                    If dt.Rows(0).Item("Transport") = "N" Then
                        ChkTransport.Checked = False
                    Else
                        ChkTransport.Checked = True
                    End If
                    If dt.Rows(0).Item("SMS") = "B" Then
                        CheckSMS.Checked = True
                        CheckFSMS.Checked = True
                    End If
                    If dt.Rows(0).Item("SMS") = "M" Then
                        CheckSMS.Checked = True
                    End If
                    If dt.Rows(0).Item("SMS") = "F" Then
                        CheckFSMS.Checked = True
                    End If

                    If dt.Rows(0).Item("Mail") = "B" Then
                        CheckMail.Checked = True
                        CheckFMail.Checked = True
                    End If
                    If dt.Rows(0).Item("Mail") = "M" Then
                        CheckMail.Checked = True
                    End If
                    If dt.Rows(0).Item("Mail") = "F" Then
                        CheckFMail.Checked = True
                    End If

                    If dt.Rows(0).Item("ChkDOB") = "Y" Then
                        CheckBox1.Checked = True
                    Else
                        CheckBox1.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkDOB") = "Y" Then
                        CheckBox1.Checked = True
                    Else
                        CheckBox1.Checked = False
                    End If

                    If dt.Rows(0).Item("ChkTc") = "Y" Then
                        CheckBox2.Checked = True
                    Else
                        CheckBox2.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkBachelorDegree") = "Y" Then
                        CheckBox3.Checked = True
                    Else
                        CheckBox3.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkTenth") = "Y" Then
                        CheckBox4.Checked = True
                    Else
                        CheckBox4.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkMigrationCertificate") = "Y" Then
                        CheckBox5.Checked = True
                    Else
                        CheckBox5.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkMasterDegree") = "Y" Then
                        CheckBox6.Checked = True
                    Else
                        CheckBox6.Checked = False
                    End If
                    If dt.Rows(0).Item("Chktwelve") = "Y" Then
                        CheckBox7.Checked = True
                    Else
                        CheckBox7.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkIC") = "Y" Then
                        CheckBox8.Checked = True
                    Else
                        CheckBox8.Checked = False
                    End If
                    ''
                    If dt.Rows(0).Item("ChkIC") = "Y" Then
                        CheckBox9.Checked = True
                    Else
                        CheckBox9.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkIC") = "Y" Then
                        CheckBox10.Checked = True
                    Else
                        CheckBox10.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkIC") = "Y" Then
                        CheckBox11.Checked = True
                    Else
                        CheckBox11.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkIC") = "Y" Then
                        CheckBox12.Checked = True
                    Else
                        CheckBox12.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkIC") = "Y" Then
                        CheckBox13.Checked = True
                    Else
                        CheckBox13.Checked = False
                    End If

                    If dt.Rows(0).Item("ChkLOS").ToString = "Y" Then
                        CheckBox10.Checked = True
                    Else
                        CheckBox10.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkAOR").ToString = "Y" Then
                        CheckBox11.Checked = True
                    Else
                        CheckBox11.Checked = False
                    End If

                    If dt.Rows(0).Item("ChkAOU").ToString = "Y" Then
                        CheckBox12.Checked = True
                    Else
                        CheckBox12.Checked = False
                    End If
                    If dt.Rows(0).Item("ChkCphoto").ToString = "Y" Then
                        CheckBox13.Checked = True
                    Else
                        CheckBox13.Checked = False
                    End If
                    DdlAllocCat.Items.Clear()
                    DdlAllocCat.DataSourceID = "ObjCategory"
                    DdlAllocCat.DataBind()
                    DdlAllocCat.SelectedValue = dt.Rows(0).Item("AllocatedCatId")
                    Txtbirthplace.Text = dt.Rows(0).Item("BirthPlace").ToString
                    TxtPeriod.Text = dt.Rows(0).Item("AddressPeriod").ToString



                    ViewState("ImageTime") = dt.Rows(0).Item("Std_Photo")
                    ddlBranchName.Items.Clear()
                    ddlBranchName.DataSourceID = "ObjBranch"
                    ddlBranchName.DataBind()
                    ddlBranchName.SelectedValue = dt.Rows(0).Item("Course_BranchCode")
                    ddlBranchName.Enabled = False
                    ddlCourse.Items.Clear()
                    ddlCourse.DataSourceID = "ObjectDataSource1"
                    ddlCourse.DataBind()
                    ddlCourse.SelectedValue = dt.Rows(0).Item("CourseId")
                    ddlCourse.Enabled = False
                    cmbBatch.Items.Clear()
                    cmbBatch.DataSourceID = "ObjBatch"
                    cmbBatch.DataBind()
                    cmbBatch.SelectedValue = dt.Rows(0).Item("BatchID")
                    cmbBatch.Enabled = False
                    ddlcategry.Items.Clear()
                    ddlcategry.DataSourceID = "ObjCategory"
                    ddlcategry.DataBind()
                    ddlcategry.SelectedValue = dt.Rows(0).Item("categoryid")
                    DdlAllocCat.Items.Clear()
                    DdlAllocCat.DataSourceID = "ObjCategory"
                    DdlAllocCat.DataBind()
                    DdlAllocCat.SelectedValue = dt.Rows(0).Item("categoryid")
                    ddlsponsor.DataSourceID = "odsSponsor"
                    ddlsponsor.DataBind()
                    Dim sponsor As Integer = dt.Rows(0).Item("Sponsor_ID")
                    ddlsponsor.SelectedValue = sponsor
                    cmbTitle.SelectedValue = dt.Rows(0).Item("Title").ToString
                    txtdob.Text = Format(dt.Rows(0).Item("DOB"), "dd-MMM-yyyy")
                    txtage.Text = dt.Rows(0).Item("StdAge").ToString
                    Txtbirthplace.Text = dt.Rows(0).Item("BirthPlace").ToString
                    ddlgender.SelectedItem.Text = dt.Rows(0).Item("StdSex")
                    txtFname.Text = dt.Rows(0).Item("FatherName").ToString
                    txtPaddr.Text = dt.Rows(0).Item("Perm_Address").ToString
                    txtCity.Text = dt.Rows(0).Item("City").ToString
                    txtPC.Text = dt.Rows(0).Item("PinCode").ToString
                    txtdistance.Text = dt.Rows(0).Item("Distance").ToString
                    ddlCountry.SelectedValue = dt.Rows(0).Item("Country")
                    txtperphone.Text = dt.Rows(0).Item("ContactNo")
                    ddlcaste.SelectedValue = dt.Rows(0).Item("Caste")
                    txtIncome.Text = dt.Rows(0).Item("AnnualIncome")
                    txtreceiptno.Text = dt.Rows(0).Item("Receipt_No")
                    ddladmissiontype.SelectedValue = dt.Rows(0).Item("Admission_Type")
                    ddladmissiontype.Enabled = False
                    txt_occupt.Text = dt.Rows(0).Item("FatherOccupation")
                    txtemail.Text = dt.Rows(0).Item("Std_email")
                    txtddno.Text = dt.Rows(0).Item("DDPayOrderNo")
                    txtprospectusno.Text = dt.Rows(0).Item("Prospectus_No")
                    ddlDistric.SelectedValue = dt.Rows(0).Item("District")
                    'ViewState("ImageTime") = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbphoto"), HiddenField).Value
                    ' ''Dim sid As New Student
                    ' ''txtcid.Text = CType(GVDetails.Rows(e.NewEditIndex).Cells(0).FindControl("EID"), HiddenField).Value
                    ' ''sid.Id = CType(GVDetails.Rows(e.NewEditIndex).Cells(0).FindControl("EID"), HiddenField).Value
                    ' ''ViewState("EID") = CType(GVDetails.Rows(e.NewEditIndex).FindControl("EID"), HiddenField).Value
                    txtLeavingDate.Text = dt.Rows(0).Item("LeavingDate").ToString
                    txtperphonestd.Text = dt.Rows(0).Item("StudentContact").ToString
                    txtemailstd.Text = dt.Rows(0).Item("StudentEmail").ToString
                    txtAdate.Text = Format(dt.Rows(0).Item("AdmissionDate"), "dd-MMM-yyyy")
                    txtAdate.Enabled = False

                    txtMotheName.Text = dt.Rows(0).Item("MotherName").ToString
                    txtFatherEmail.Text = dt.Rows(0).Item("FatherEmail").ToString
                    txtFatherContact.Text = dt.Rows(0).Item("FatherContact").ToString
                    txtFullName.Text = dt.Rows(0).Item("STD_FullName").ToString
                    txtNameinpassport.Text = dt.Rows(0).Item("NameInPassport").ToString
                    txtPlaceofIssue.Text = dt.Rows(0).Item("PlaceofIssue").ToString
                    txtPassportNo.Text = dt.Rows(0).Item("PassportNo").ToString
                    txtExpiryDate.Text = dt.Rows(0).Item("PassportExpiryDate").ToString
                    txtPassportIssueDate.Text = dt.Rows(0).Item("PassportIssueDate").ToString
                    txtVisaExpDate.Text = dt.Rows(0).Item("VisaExpiryDate").ToString
                    txtVisaIssueDate.Text = dt.Rows(0).Item("VisaIssueDate").ToString
                    txtVisaNo.Text = dt.Rows(0).Item("VisaNo").ToString
                    cmbBranch.Text = dt.Rows(0).Item("FRROExpDate").ToString
                    txtMotherTongue.Text = dt.Rows(0).Item("MotherTongue").ToString
                    txtTCNo.Text = dt.Rows(0).Item("TCNo").ToString
                    txtRemarks.Text = dt.Rows(0).Item("Remarks").ToString
                    txtFHomeContact.Text = dt.Rows(0).Item("FatherHomeContact").ToString
                    txtMHomeContact.Text = dt.Rows(0).Item("MontherHomeContact").ToString
                    txtFBizContact.Text = dt.Rows(0).Item("FatherBizOffice").ToString
                    txtMBizContact.Text = dt.Rows(0).Item("MotherBizOffice").ToString
                    txtFatherQualification.Text = dt.Rows(0).Item("FatherQualification").ToString
                    txtMotherQualification.Text = dt.Rows(0).Item("MotherQualification").ToString
                    txtMotherOccupation.Text = dt.Rows(0).Item("MotherOccupation").ToString
                    txtReligion.Text = dt.Rows(0).Item("Religion").ToString
                    txtSecondUSN.Text = dt.Rows(0).Item("SecondStdCode").ToString
                    txtcid.Text = dt.Rows(0).Item("SecondStdCode").ToString

                    TabContainer1.ActiveTab = TabPanel2
                    TabPanel1.Visible = False
                    btnStddet.Text = "UPDATE"
                    btnDetails.Enabled = True
                    btnNext.Enabled = True
                    msginfo.Text = ""


                    'disable for student login
                    ddlenqno.Enabled = False
                    texApp.Enabled = False
                    ddlcategry.Enabled = False
                    txtddno.Enabled = False
                    DdlAllocCat.Enabled = False
                    txtprospectusno.Enabled = False
                    txtreceiptno.Enabled = False
                    ddlfee.Enabled = False
                    txtLeavingDate.Enabled = False
                    ddlMentorName.Enabled = False
                    txtTCNo.Enabled = False
                    ddlMentorCode.Enabled = False
                    ddlsponsor.Enabled = False
                    txtFullName.Enabled = False
                    txtIndex.Enabled = False
                    txtSecondUSN.Enabled = False
                    txtMotherTongue.Enabled = False
                    ddlHomeName.Enabled = False
                    cmbTitle.Enabled = False
                    ddlgender.Enabled = False
                    txtNicNo.Enabled = False
                    txtdob.Enabled = False
                    Txtbirthplace.Enabled = False
                    ChkHostel.Enabled = False
                    ChkTransport.Enabled = False
                    txtNameinpassport.Enabled = False
                    txtVisaNo.Enabled = False
                    txtPassportNo.Enabled = False
                    txtVisaIssueDate.Enabled = False
                    txtPassportIssueDate.Enabled = False
                    txtVisaExpDate.Enabled = False
                    txtExpiryDate.Enabled = False
                    cmbBranch.Enabled = False
                    txtPlaceofIssue.Enabled = False
                    txtRemarks.Enabled = False
                    CheckBox1.Enabled = False
                    CheckBox2.Enabled = False
                    CheckBox3.Enabled = False
                    CheckBox4.Enabled = False
                    CheckBox5.Enabled = False
                    CheckBox6.Enabled = False
                    CheckBox7.Enabled = False
                    CheckBox8.Enabled = False
                    CheckBox9.Enabled = False
                    CheckBox10.Enabled = False
                    CheckBox11.Enabled = False
                    CheckBox12.Enabled = False
                    CheckBox13.Enabled = False
                End If

                Exit Sub
            End If
        End If




        'Try
        '    If Session("LoginType") = "Others" Then
        '        Session("UserName") = dt.Rows(0)("UserName").ToString.Trim
        '        Session("SPassword") = dt.Rows(0)("SPassword")
        '    End If

        'Catch ex As Exception
        '    msginfo.Text = ValidationMessage(1118)
        '    lblMsg.Text = ValidationMessage(1014)
        'End Try

        If Not IsPostBack Then
            dt = EnquiryManager.GetCriteria()
            If dt.Rows.Count <= 0 Then
                TabContainer1.ActiveTab = TabPanel2
                TabPanel1.Visible = False
                TabPanel2.Visible = True
                'TabPanel1.Enabled = True


                'GVCriteria.DataSource = dt
                'GVCriteria.DataBind()
                'For Each Grid As GridViewRow In GVCriteria.Rows
                '    Dim Criteria As String
                '    Criteria = CType(Grid.FindControl("lblCriteriaName"), Label).Text
                '    dt = EnquiryManager.GetCriteriavalue(Criteria)
                '    CType(Grid.FindControl("ddlCriteriavalue"), DropDownList).DataSource = dt
                '    CType(Grid.FindControl("ddlCriteriavalue"), DropDownList).DataBind()
                'Next
                'TabPanel2.Enabled = False
                'End If
            Else
                GVCriteria.DataSource = dt
                GVCriteria.DataBind()
                For Each Grid As GridViewRow In GVCriteria.Rows
                    Dim Criteria As String
                    Criteria = CType(Grid.FindControl("lblCriteriaName"), Label).Text
                    dt = EnquiryManager.GetCriteriavalue(Criteria)
                    CType(Grid.FindControl("ddlCriteriavalue"), DropDownList).DataSource = dt
                    CType(Grid.FindControl("ddlCriteriavalue"), DropDownList).DataBind()
                Next
                TabPanel2.Enabled = True
                TabPanel1.Enabled = False
                TabPanel1.Visible = False
            End If
        End If
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        If Not IsPostBack Then
            'Control_Text_Multilingual()
            Dim dt As DataTable
            dt = StudentDB.GetStdRegCode()
            If dt.Rows.Count > 0 Then
                txtregno.Text = dt.Rows(0).Item("Config_Value")
            Else
                txtregno.Text = ""
            End If
            ddlenqno.Focus()
            'txtAdate.Text = Format(Date.Today, "dd-MMM-yyyy")
            lblTotal.Visible = False
            txtTotal.Visible = False
            txtTotal.Enabled = False
            lblAvailable.Visible = False
            txtAvailable.Visible = False
            txtAvailable.Enabled = False
        End If
        If Not IsPostBack Then
            ddlBranchName.SelectedValue = Session("BranchCode")
        End If
    End Sub

    Protected Sub ddlcategry_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcategry.SelectedIndexChanged
        category()
    End Sub

    Sub category()
        If Me.ddlcategry.SelectedItem.Value = "2" Then
            Me.ddlsponsor.Visible = True
            Me.lblSponsor.Visible = True
        End If
    End Sub

    Protected Sub cmbAcademic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcademic.SelectedIndexChanged
        cmbBatch.Items.Clear()
    End Sub

    Protected Sub btnStddet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStddet.Click
        btnDetails.Enabled = True
        ddlenqno.Focus()


        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                s.Name = txtname.Text.ToString()
                s.Fullname = txtFullName.Text
                s.Code = txtregno.Text.ToUpper
                s.SecondUSN = txtSecondUSN.Text.ToUpper
                s.indexNo = txtIndex.Text


                If txtdob.Text <> "" Then
                    s.DateOfBirth = txtdob.Text.ToString()
                Else
                    s.DateOfBirth = "1/1/3000"
                End If
                s.coursebranchcode = ddlBranchName.SelectedValue
                s.CourseId = ddlCourse.SelectedValue
                s.Category = ddlcategry.Text.ToString()
                s.Alcategory = DdlAllocCat.Text.ToString()
                s.Title = cmbTitle.Text.ToString()
                s.BatchNo = cmbBatch.Text.ToString()
                s.Photo = ViewState("ImageTime")
                s.ApplicationNo = texApp.Text.ToString()
                s.Sex = ddlgender.Text.ToString()
                s.FatherName = txtFname.Text.ToString()
                s.PermanentAddress = txtPaddr.Text.ToString()
                s.BirthPlace = Txtbirthplace.Text.ToString()
                s.City = txtCity.Text.ToString()
                s.PinCode = txtPC.Text.ToString()
                s.State = ddlState.SelectedValue
                s.PassportName = txtNameinpassport.Text
                s.NicNo = txtNicNo.Text.ToUpper
                s.PassportNo = txtPassportNo.Text
                s.Passportissue = txtPlaceofIssue.Text
                s.FatherHomeContact = txtFHomeContact.Text
                s.MontherHomeContact = txtMHomeContact.Text
                s.FatherBizOffice = txtFBizContact.Text
                s.MotherBizOffice = txtMBizContact.Text
                s.FatherQualification = txtFatherQualification.Text
                s.MotherQualification = txtMotherQualification.Text
                s.MotherOccupation = txtMotherOccupation.Text
                s.Religion = txtReligion.Text
                s.ethnicity = ddlethnic.SelectedValue
                s.GuardianRelate = txtgrdnRel.Text
                s.Distance = txtdistance.Text


                If txtPassportIssueDate.Text = "" Then
                    s.PassportIssueDate = "1/1/3000"
                Else
                    s.PassportIssueDate = txtPassportIssueDate.Text
                End If
                If txtVisaExpDate.Text = "" Then
                    s.VisaExpDate = "1/1/3000"
                Else
                    s.VisaExpDate = txtVisaExpDate.Text
                End If
                If txtVisaIssueDate.Text = "" Then
                    s.VisaIssueDate = "1/1/3000"
                Else
                    s.VisaIssueDate = txtVisaIssueDate.Text
                End If
                s.VisaNo = txtVisaNo.Text
                If Me.cmbBranch.Text <> "" Then
                    s.FromBranch = Me.cmbBranch.Text
                Else
                    s.FromBranch = "1/1/3000"
                End If
                If txtExpiryDate.Text = "" Then
                    s.PassportExpirydate = "1/1/3000"
                Else
                    s.PassportExpirydate = txtExpiryDate.Text
                End If
                If txtAdate.Text <> "" Then
                    s.AdmissionDate = txtAdate.Text.ToString()
                Else
                    s.AdmissionDate = "1/1/3000"
                End If

                If Me.txtIncome.Text <> "" Then
                    s.AnnualIncome = Me.txtIncome.Text
                Else
                    s.AnnualIncome = 0.0
                End If
                s.Caste = ddlcaste.SelectedValue
                s.ReceiptNo = txtreceiptno.Text.ToString()
                s.AdmissionType = ddladmissiontype.Text.ToString()
                s.SponsorId = ddlsponsor.SelectedValue
                If txtage.Text <> "" Then
                    s.Age = txtage.Text
                Else
                    s.Age = 0
                End If
                s.BirthPlace = Txtbirthplace.Text.ToString()
                s.HouseId = ddlHomeName.Text.ToString()
                s.Email = txtemail.Text.ToString()
                Dim dt As DataTable
                dt = DLCreateBatch.GetAcademicyear(s.BatchNo)

                s.A_year = dt.Rows(0).Item("AcademicYear")
                's.A_year = cmbAcademic.SelectedValue
                s.FatherOccupation = txt_occupt.Text.ToString()
                s.TemporaryAddress = txtCaddr.Text.ToString()
                s.TemporaryAddressP = TxtPeriod.Text.ToString()
                s.ContactNumber = txtperphone.Text.ToString()
                s.DDNo = txtddno.Text.ToString()
                s.ProspectusNo = txtprospectusno.Text.ToString()
                s.District = ddlDistric.SelectedValue
                s.Country = ddlCountry.SelectedValue
                s.TCNo = txtTCNo.Text
                s.MotherTongue = txtMotherTongue.Text
                s.Remarks = txtRemarks.Text
                s.Session = 0
                Dim feecollected As String = ddlfee.SelectedValue
                s.Feecollected = feecollected
                If txtLeavingDate.Text = "" Then
                    s.LeavingDate = "1/1/3000"
                Else
                    s.LeavingDate = txtLeavingDate.Text
                End If
                s.StdEmail = txtemailstd.Text
                s.StdContact = txtperphonestd.Text
                If ddlenqno.SelectedValue = "Select" Then
                    s.Eno = 0
                Else
                    s.Eno = ddlenqno.SelectedValue
                End If
                s.MotherName = txtMotheName.Text
                s.FatherEmail = txtFatherEmail.Text
                s.FatherContact = txtFatherContact.Text
                If ChkHostel.Checked = True Then
                    s.Hostel = "Y"
                Else
                    s.Hostel = "N"
                End If
                If ChkTransport.Checked = True Then
                    s.Transport = "Y"
                Else
                    s.Transport = "N"
                End If
                If ddlMentorCode.SelectedValue = 0 Then
                    s.MentorId = ddlMentorName.SelectedValue
                Else
                    s.MentorId = ddlMentorCode.SelectedValue
                End If
                If CheckBox1.Checked = True Then
                    s.DOBCertificate = "Y"
                Else
                    s.DOBCertificate = "N"
                End If
                If CheckBox2.Checked = True Then
                    s.TC = "Y"
                Else
                    s.TC = "N"
                End If
                If CheckBox3.Checked = True Then
                    s.BD = "Y"
                Else
                    s.BD = "N"
                End If
                If CheckBox4.Checked = True Then
                    s.TEN = "Y"
                Else
                    s.TEN = "N"
                End If
                If CheckBox5.Checked = True Then
                    s.MigrationCertificate = "Y"
                Else
                    s.MigrationCertificate = "N"
                End If
                If CheckBox6.Checked = True Then
                    s.MasterDegree = "Y"
                Else
                    s.MasterDegree = "N"
                End If
                If CheckBox7.Checked = True Then
                    s.twelve = "Y"
                Else
                    s.twelve = "N"
                End If
                If CheckBox8.Checked = True Then
                    s.IC = "Y"
                Else
                    s.IC = "N"
                End If
                If CheckBox9.Checked = True Then
                    s.SLC = "Y"
                Else
                    s.SLC = "N"
                End If
                If CheckBox10.Checked = True Then
                    s.LOS = "Y"
                Else
                    s.LOS = "N"
                End If
                If CheckBox11.Checked = True Then
                    s.AOR = "Y"
                Else
                    s.AOR = "N"
                End If
                If CheckBox12.Checked = True Then
                    s.AOU = "Y"
                Else
                    s.AOU = "N"
                End If
                If CheckBox13.Checked = True Then
                    s.CPhoto = "Y"
                Else
                    s.CPhoto = "N"
                End If
                If CheckSMS.Checked = True Then
                    s.MotherSMS = "Y"
                Else
                    s.MotherSMS = "N"
                End If
                If CheckMail.Checked = True Then
                    s.MotherMail = "Y"
                Else
                    s.MotherMail = "N"
                End If
                If CheckFSMS.Checked = True Then
                    s.FatherSMS = "Y"
                Else
                    s.FatherSMS = "N"
                End If
                If CheckFMail.Checked = True Then
                    s.FatherMail = "Y"
                Else
                    s.FatherMail = "N"
                End If
                s.LastName = txtlblLName.Text
                s.MName = txtmidname.Text
                s.Citizenship = txtcitizen.Text
                s.GDName = txtGDName.Text
                s.GDContactNo = txtGDContactNo.Text
                s.GDEmailID = txtGDEmail.Text
                s.GDOccupation = txtGO.Text

                Dim ins As New StudentManager
                If btnStddet.Text = "ADD" Then
                    If txtPassportIssueDate.Text <> "" Or txtExpiryDate.Text <> "" Then
                        If CDate(IIf(txtPassportIssueDate.Text = "", "1/1/1000", txtPassportIssueDate.Text)) >= CDate(IIf(txtExpiryDate.Text = "", "1/1/3000", txtExpiryDate.Text)) Then
                            Me.lblMsg.Text = ValidationMessage(1014)
                            Me.msginfo.Text = ValidationMessage(1110)
                        Else
                            If CDate(IIf(txtVisaIssueDate.Text = "", "1/1/1000", txtVisaIssueDate.Text)) >= CDate(IIf(txtVisaExpDate.Text = "", "1/1/3000", txtVisaExpDate.Text)) Then
                                Me.lblMsg.Text = ValidationMessage(1014)
                                Me.msginfo.Text = ValidationMessage(1111)
                            Else
                                If CDate(IIf(txtPassportIssueDate.Text = "", "1/1/1000", txtPassportIssueDate.Text)) >= CDate(IIf(txtVisaIssueDate.Text = "", "1/1/3000", txtVisaIssueDate.Text)) Then
                                    Me.lblMsg.Text = ValidationMessage(1014)
                                    Me.msginfo.Text = ValidationMessage(1112)
                                Else
                                    If CDate(IIf(txtVisaExpDate.Text = "", "1/1/1000", txtVisaExpDate.Text)) >= CDate(IIf(txtExpiryDate.Text = "", "1/1/3000", txtExpiryDate.Text)) Then
                                        Me.lblMsg.Text = ValidationMessage(1014)
                                        Me.msginfo.Text = ValidationMessage(1113)
                                    Else
                                        If ViewState("seats") <> 0 Then
                                            s.Id = 0
                                            If CDate(IIf(txtAdate.Text = "", "1/1/1000", txtAdate.Text)) <= CDate(IIf(txtLeavingDate.Text = "", "1/1/3000", txtLeavingDate.Text)) Then
                                                Dim i As Integer = ins.InsertStudent(s)
                                                If i > 0 Then
                                                    Me.lblMsg.Text = ValidationMessage(1020)
                                                    Dim dt1 As DataTable
                                                    dt1 = StudentDB.GetStdRegCode()
                                                    If dt1.Rows.Count > 0 Then
                                                        txtregno.Text = dt1.Rows(0).Item("Config_Value")
                                                    Else
                                                        txtregno.Text = ""
                                                    End If
                                                    ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")
                                                    ddlenqno.Items.Clear()
                                                    ddlenqno.DataSourceID = "odsEnquiry"
                                                    StdClear()
                                                    msginfo.Text = ValidationMessage(1014)
                                                    ViewState("stdcode") = txtregno.Text.ToUpper
                                                    Dim bid As Long
                                                    Dim a, b As Integer
                                                    dt.Clear()
                                                    If cmbBatch.SelectedValue <> 0 Then
                                                        bid = cmbBatch.SelectedValue
                                                        dt = sm.getTotalseats(bid)
                                                        a = dt.Rows(0)("AvailSeatsCount")
                                                        b = dt.Rows(0)("NoOfSeats")
                                                        txtTotal.Text = b
                                                        ViewState("seats") = b - a
                                                        txtAvailable.Text = ViewState("seats")
                                                    End If
                                                    ViewAddData(ViewState("dispId "))
                                                Else
                                                    Me.msginfo.Text = ValidationMessage(1114)
                                                    lblMsg.Text = ValidationMessage(1014)
                                                End If
                                            Else
                                                Me.msginfo.Text = ValidationMessage(1115)
                                                lblMsg.Text = ValidationMessage(1014)
                                            End If
                                            Me.ddlenqno.Enabled = True
                                        Else
                                            msginfo.Text = ValidationMessage(1116)
                                            lblMsg.Text = ValidationMessage(1014)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If ViewState("seats") <> 0 Then
                            s.Id = 0
                            If CDate(IIf(txtAdate.Text = "", "1/1/1000", txtAdate.Text)) <= CDate(IIf(txtLeavingDate.Text = "", "1/1/3000", txtLeavingDate.Text)) Then
                                'Inserting student details
                                Dim i As Integer = ins.InsertStudent(s)
                                If i > 0 Then
                                    ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")
                                    ddlenqno.Items.Clear()
                                    ddlenqno.DataSourceID = "odsEnquiry"
                                    StdClear()
                                    msginfo.Text = ValidationMessage(1014)
                                    ViewState("stdcode") = txtregno.Text.ToUpper
                                    Dim bid As Long
                                    Dim a, b As Integer
                                    dt.Clear()
                                    If cmbBatch.SelectedValue <> 0 Then
                                        bid = cmbBatch.SelectedValue
                                        dt = sm.getTotalseats(bid)
                                        a = dt.Rows(0)("AvailSeatsCount")
                                        b = dt.Rows(0)("NoOfSeats")
                                        txtTotal.Text = b
                                        ViewState("seats") = b - a
                                        txtAvailable.Text = ViewState("seats")
                                    End If
                                    ViewAddData(ViewState("dispId "))
                                    Me.lblMsg.Text = ValidationMessage(1020)
                                    Dim dt1 As DataTable
                                    dt1 = StudentDB.GetStdRegCode()
                                    If dt1.Rows.Count > 0 Then
                                        txtregno.Text = dt1.Rows(0).Item("Config_Value")
                                    Else
                                        txtregno.Text = ""
                                    End If
                                Else
                                    Me.msginfo.Text = ValidationMessage(1114)
                                    lblMsg.Text = ValidationMessage(1014)
                                End If
                            Else
                                Me.msginfo.Text = ValidationMessage(1115)
                                lblMsg.Text = ValidationMessage(1014)
                            End If
                            Me.ddlenqno.Enabled = True
                        Else
                            msginfo.Text = ValidationMessage(1116)
                            lblMsg.Text = ValidationMessage(1014)
                        End If
                    End If
                ElseIf btnStddet.Text = "UPDATE" Then
                    If txtPassportIssueDate.Text <> "" Or txtExpiryDate.Text <> "" Then
                        If CDate(IIf(txtPassportIssueDate.Text = "", "1/1/1000", txtPassportIssueDate.Text)) >= CDate(IIf(txtExpiryDate.Text = "", "1/1/3000", txtExpiryDate.Text)) Then
                            Me.lblMsg.Text = ValidationMessage(1014)
                            Me.msginfo.Text = ValidationMessage(1110)
                        Else
                            If CDate(IIf(txtVisaIssueDate.Text = "", "1/1/1000", txtVisaIssueDate.Text)) >= CDate(IIf(txtVisaExpDate.Text = "", "1/1/3000", txtVisaExpDate.Text)) Then
                                Me.lblMsg.Text = ValidationMessage(1014)
                                Me.msginfo.Text = ValidationMessage(1111)
                            Else
                                If CDate(IIf(txtPassportIssueDate.Text = "", "1/1/1000", txtPassportIssueDate.Text)) >= CDate(IIf(txtVisaIssueDate.Text = "", "1/1/3000", txtVisaIssueDate.Text)) Then
                                    Me.lblMsg.Text = ValidationMessage(1014)
                                    Me.msginfo.Text = ValidationMessage(1112)
                                Else
                                    If CDate(IIf(txtVisaExpDate.Text = "", "1/1/1000", txtVisaExpDate.Text)) >= CDate(IIf(txtExpiryDate.Text = "", "1/1/3000", txtExpiryDate.Text)) Then
                                        Me.lblMsg.Text = ValidationMessage(1014)
                                        Me.msginfo.Text = ValidationMessage(1113)
                                    Else
                                        s.Id = txtcid.Text
                                        Dim i As New Integer
                                        If CDate(IIf(txtAdate.Text = "", "1/1/1000", txtAdate.Text)) <= CDate(IIf(txtLeavingDate.Text = "", "1/1/3000", txtLeavingDate.Text)) Then
                                            i = ins.UpdateRecord(s)
                                            If i <> 0 Then
                                                ddlenqno.Items.Clear()
                                                ddlenqno.DataSourceID = "odsEnquiry"
                                                msginfo.Text = ValidationMessage(1014)
                                                StdClear()
                                                txtAdate.Text = ""
                                                'End If
                                                
                                                btnStddet.Text = "ADD"
                                                Me.btnNext.Text = "VIEW"
                                                
                                                btnNext.Enabled = True
                                                btnStddet.Enabled = True
                                                Me.ImageMap1.ImageUrl = "~/Images/imageupload.gif"
                                                GVDetails.PageIndex = ViewState("PageIndex")

                                                If ViewState("Button") = "SEARCH" Then
                                                    DisplayGrid1()
                                                Else
                                                    DisplayGrid()
                                                End If
                                                ddlenqno.Items.Clear()
                                                ddlenqno.DataSourceID = "odsEnquiry"
                                                ViewState("stdcode") = txtregno.Text.ToUpper
                                                Me.lblMsg.Text = ValidationMessage(1017)
                                            Else
                                                Me.msginfo.Text = ValidationMessage(1117)
                                                lblMsg.Text = ValidationMessage(1014)
                                            End If
                                        Else
                                            Me.msginfo.Text = ValidationMessage(1115)
                                            lblMsg.Text = ValidationMessage(1014)
                                        End If
                                        Me.ddlenqno.Enabled = True
                                    End If
                                End If
                            End If
                        End If
                    Else
                        If Session("LoginType") = "Others" Then
                            s.Id = ViewState("StdId")
                        Else
                            s.Id = txtcid.Text
                        End If
                        Dim i As New Integer
                        If CDate(IIf(txtAdate.Text = "", "1/1/1000", txtAdate.Text)) <= CDate(IIf(txtLeavingDate.Text = "", "1/1/3000", txtLeavingDate.Text)) Then
                            i = ins.UpdateRecord(s)
                            If i <> 0 Then
                                ddlenqno.Items.Clear()
                                ddlenqno.DataSourceID = "odsEnquiry"
                                msginfo.Text = ValidationMessage(1014)
                                If Session("LoginType") <> "Others" Then
                                    StdClear()
                                    txtAdate.Text = ""
                                End If


                                'End If
                               
                                If Session("LoginType") = "Others" Then
                                    DisplayViewOthers()
                                    Me.btnNext.Text = "VIEW"
                                    Me.lblMsg.Text = ValidationMessage(1017)
                                    Exit Sub
                                End If
                                btnStddet.Text = "ADD"
                                Me.btnNext.Text = "VIEW"
                                
                                btnNext.Enabled = True
                                btnStddet.Enabled = True
                                Me.ImageMap1.ImageUrl = "~/Images/imageupload.gif"
                                GVDetails.PageIndex = ViewState("PageIndex")
                                If Session("LoginType") = "Others" Then
                                    DisplayViewOthers()
                                    Exit Sub
                                End If
                                If ViewState("Button") = "SEARCH" Then
                                    DisplayGrid()
                                Else
                                    DisplayView()
                                End If
                                ddlenqno.Items.Clear()
                                ddlenqno.DataSourceID = "odsEnquiry"
                                ViewState("stdcode") = txtregno.Text.ToUpper
                                Me.lblMsg.Text = ValidationMessage(1017)
                            Else
                                Me.msginfo.Text = ValidationMessage(1117)
                                lblMsg.Text = ValidationMessage(1014)
                            End If
                        Else
                            Me.msginfo.Text = ValidationMessage(1115)
                            lblMsg.Text = ValidationMessage(1014)
                        End If
                        Me.ddlenqno.Enabled = True
                    End If
                End If
            Else
                msginfo.Text = ValidationMessage(1021)
                lblMsg.Text = ValidationMessage(1014)
            End If
            dt.Dispose()
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1118)
            lblMsg.Text = ValidationMessage(1014)
        End Try

    End Sub
    Protected Sub ddlenqno_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlenqno.PreRender
        If ddlenqno.Items.Count > 0 Then
            If ddlenqno.Items(0).Text <> "Select" Then
                ddlenqno.Items.Insert(0, "Select")
            End If
        Else
            ddlenqno.Items.Insert(0, "Select")
        End If
    End Sub
    Sub DisplayView()
        btnDetails.Enabled = True
        s.Name = ""
        s.Code = ""
        s.DateOfBirth = "1/1/3000"
        s.CourseId = 0
        s.Category = 0
        s.BatchNo = 0
        s.ApplicationNo = ""
        s.HouseId = 0
        s.A_year = 0
        s.AdmissionDate = "1/1/3000"
        s.NicNo = txtNicNo.Text.ToUpper
        msginfo.Text = ValidationMessage(1014)
        lblMsg.Text = ValidationMessage(1014)

        dt = StudentDB.GetStudents4(0, s)
        If dt.Rows.Count > 0 Then
            If (ViewState("SortExpression") <> "") Then
                Dim sortedView As New DataView(dt)
                Dim s As String = ViewState("SortExpression") & " " & ViewState("sortingDirection")
                sortedView.Sort = s
                GVDetails.PageIndex = ViewState("PageIndex")
                GVDetails.DataSource = sortedView
                GVDetails.DataBind()
                
            Else
                GVDetails.DataSource = dt
                GVDetails.DataBind()
               
            End If


            GVDetails.Enabled = True
            GVDetails.Visible = True
            LinkButton.Focus()
        Else
            msginfo.Text = ValidationMessage(1023)
            lblMsg.Text = ValidationMessage(1014)
            GVDetails.Visible = False
        End If
    End Sub
    Sub DisplayViewOthers()
        Dim sid As New Student
        sid.Id = ViewState("StdId")
        s.coursebranchcode = ddlBranchName.SelectedValue
        dt = StudentDB.GetStudentsOthers(sid.Id, s)
        If dt.Rows.Count > 0 Then
            If (ViewState("SortExpression") <> "") Then
                Dim sortedView As New DataView(dt)
                Dim s As String = ViewState("SortExpression") & " " & ViewState("sortingDirection")
                sortedView.Sort = s
                GVDetails.PageIndex = ViewState("PageIndex")
                GVDetails.DataSource = sortedView
                GVDetails.DataBind()
                
            Else
                GVDetails.DataSource = dt
                GVDetails.DataBind()
                
            End If


            GVDetails.Enabled = True
            GVDetails.Visible = True
            LinkButton.Focus()
        Else
            msginfo.Text = ValidationMessage(1023)
            lblMsg.Text = ValidationMessage(1014)
            GVDetails.Visible = False
        End If
    End Sub
    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click


        If Session("LoginType") = "Others" Then
            If btnNext.Text = "BACK" Then
                DisplayViewOthers()
                btnNext.Text = "VIEW"
            End If
            DisplayViewOthers()
            Exit Sub
        End If


        btnDetails.Enabled = True
        s.Name = ""
        s.Code = ""
        s.DateOfBirth = "1/1/3000"
        s.coursebranchcode = ddlBranchName.SelectedValue
        s.CourseId = 0
        s.Category = 0
        s.BatchNo = 0
        s.ApplicationNo = ""
        s.HouseId = 0
        s.A_year = 0
        s.AdmissionDate = "1/1/3000"
        s.NicNo = ""
        msginfo.Text = ValidationMessage(1014)
        lblMsg.Text = ValidationMessage(1014)
        If btnNext.Text <> "BACK" Then
            dt = StudentDB.GetStudents4(0, s)
            If dt.Rows.Count > 0 Then
                If (ViewState("SortExpression") <> "") Then
                    Dim sortedView As New DataView(dt)
                    Dim s As String = ViewState("SortExpression") & " " & ViewState("sortingDirection")
                    sortedView.Sort = s
                    GVDetails.PageIndex = ViewState("PageIndex")
                    GVDetails.DataSource = sortedView
                    GVDetails.DataBind()
                   
                Else
                    GVDetails.DataSource = dt
                    GVDetails.DataBind()
                  
                End If

                GVDetails.Enabled = True
                GVDetails.Visible = True
                LinkButton.Focus()
            Else
                msginfo.Text = ValidationMessage(1023)
                lblMsg.Text = ValidationMessage(1014)
                GVDetails.Visible = False
            End If
        Else
            dt = StudentDB.GetStudents4(0, s)
            If dt.Rows.Count > 0 Then
                If (ViewState("SortExpression") <> "") Then
                    Dim sortedView As New DataView(dt)
                    Dim s As String = ViewState("SortExpression") & " " & ViewState("sortingDirection")
                    sortedView.Sort = s
                    GVDetails.PageIndex = ViewState("PageIndex")
                    GVDetails.DataSource = sortedView
                    GVDetails.DataBind()
                   
                Else
                    GVDetails.DataSource = dt
                    GVDetails.DataBind()
                    
                End If

                btnNext.Text = "VIEW"
                btnStddet.Text = "ADD"
                
                StdClear()
                GVDetails.Enabled = True
                GVDetails.Visible = True
                LinkButton.Focus()
            Else
                msginfo.Text = ValidationMessage(1023)
                lblMsg.Text = ValidationMessage(1014)
                GVDetails.Visible = False
            End If
        End If
        ViewState("Button") = "VIEW"
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        ddlenqno.Focus()
        LinkButton.Focus()
        Try
            lblMsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            
            If btnDetails.Text <> "BACK" Then
                GVDetails.PageIndex = ViewState("PageIndex")
                DisplayGrid()
            Else
                StdClear()
                
                btnDetails.Text = "VIEW"
                btnStddet.Text = "ADD"
                ViewState("ImageTime") = "~/Images/" & path
                txtpath.Text = path1
                Me.ImageMap1.ImageUrl = txtpath.Text
                ViewState("PageIndex") = 0
                GVDetails.PageIndex = 0
                DisplayGrid()
                ddlenqno.Enabled = True
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1119)
            msginfo.Visible = True
        End Try
        ViewState("Button") = "SEARCH"
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If FileUpload2.FileName <> "" Then
            If FileUpload2.PostedFile.ContentLength <= 30000 Then
                Try
                    If ViewState("ImageTime") <> Nothing Then
                        Dim Foto As String = Session("Path") + ViewState("ImageTime").ToString.Replace("~/", "")
                        If IO.File.Exists(Foto) Then
                            IO.File.Delete(Foto)
                        End If
                    End If
                    lblMsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1014)
                    path = "S" & Replace(txtregno.Text.Trim.ToString().Replace(" ", ""), "/", "") + TimeOfDay.ToString().Replace("/", "").Replace(":", "") & ".jpg"

                    If (FileUpload2.PostedFile.ContentType.ToLower() = "image/gif" Or FileUpload2.PostedFile.ContentType.ToLower() = "image/jpeg" Or FileUpload2.PostedFile.ContentType.ToLower() = "image/pjpeg" Or FileUpload2.PostedFile.ContentType.ToLower() = "image/tiff" Or FileUpload2.PostedFile.ContentType.ToLower() = "image/x-png" Or FileUpload2.PostedFile.ContentType.ToLower() = "image/jpg" Or FileUpload2.PostedFile.ContentType.ToLower() = "image/bmp" Or FileUpload2.PostedFile.ContentType.ToLower() = "image/tif") Then


                        'path = (Server.MapPath("Images/") + Convert.ToString(Guid.NewGuid()) + FileUpload1.FileName)
                        'FileUpload1.SaveAs(path)
                        Me.FileUpload2.SaveAs(Server.MapPath("~\Images\" & path.Replace("/", "").Replace(":", "")))
                        path1 = "~/Images/" & path.Replace("/", "").Replace(":", "")
                        ViewState("ImageTime") = "~/Images/" & path
                        txtpath.Text = path1
                        Me.ImageMap1.ImageUrl = txtpath.Text
                    Else
                        msginfo.Text = "Photo format should be gif/jpeg/jpg/pjpeg/bmp/x-png/tif/tiff ."
                    End If
                Catch ex As Exception
                    msginfo.Text = ValidationMessage(1120)
                    lblMsg.Text = ValidationMessage(1014)
                End Try
            Else
                msginfo.Text = ValidationMessage(1120)
                lblMsg.Text = ValidationMessage(1014)
            End If
        Else
            msginfo.Text = ValidationMessage(1121)
            lblMsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Sub AlertEnterAllFields()
        alt = "alert('Admission No. already exists.');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", alt, True)
    End Sub

    Protected Sub ddlenqno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlenqno.SelectedIndexChanged
        If Me.ddlenqno.SelectedItem.Text <> "Select" Then
            GetEnqDetails()
            btnStddet.Enabled = True
        Else
            Call Me.StdClear()
        End If
    End Sub
    Sub GetEnqDetails()
        Try
            Dim x As Integer
            If ddlenqno.Items.Count > 0 Then
                Dim BAL As New EnquiryManager
                dt.Clear()
                dt = BAL.Details(ddlenqno.SelectedValue)
                If dt.Rows.Count <> 0 Then
                    Me.txtFullName.Text = dt.Rows(0)("FName").ToString()
                    If txtFullName.Text <> "" Then
                        txtname.Text = GlobalFunction.NameInitial(txtFullName.Text)
                    End If
                    Me.cmbTitle.Text = dt.Rows(0)("Title").ToString()
                    'Me.txtCaddr.Text = dt.Rows(0)("Address").ToString()
                    Me.txtperphonestd.Text = dt.Rows(0)("Mobile").ToString()
                    Me.txtemail.Text = dt.Rows(0)("Email").ToString()
                    Me.ddlcaste.SelectedValue = dt.Rows(0)("Caste").ToString()
                    Me.txtFname.Text = dt.Rows(0)("FatherName").ToString()
                    Me.txt_occupt.Text = dt.Rows(0)("FatherOccupation").ToString()
                    Me.txtNicNo.Text = dt.Rows(0)("NicNo").ToString()
                    'ddlDistric.SelectedValue = dt.Rows(0)("District").ToString()
                    'Txtbirthplace.Text = dt.Rows(0)("BirthPlace").ToString()
                    Try
                        Me.txtdob.Text = dt.Rows(0)("DOB").ToString()
                        Me.txtdob.Text = Format(CDate(Me.txtdob.Text), "dd-MMM-yyyy")
                        Me.txtage.Text = Convert.ToInt32(DateDiff(DateInterval.Year, CDate(Me.txtdob.Text), Today))
                    Catch ex As InvalidCastException
                        Me.txtdob.Text = ""
                        Me.txtage.Text = ""
                    End Try
                    x = dt.Rows(0)("AnnualIncome").ToString()
                    Me.txtIncome.Text = Format(x, "0.00")

                    Me.txtPaddr.Text = dt.Rows(0)("Address").ToString()
                    'Me.txtCaddr.Text = dt.Rows(0)("Address").ToString()
                    Me.txtCity.Text = dt.Rows(0)("City").ToString()
                    Me.txtdistance.Text = dt.Rows(0)("Distance").ToString()
                    Me.txtPC.Text = dt.Rows(0)("PinCode").ToString()
                    'Me.ddlState.SelectedValue = dt.Rows(0)("StateId").ToString()
                    'Me.ddlCountry.SelectedValue = dt.Rows(0)("Country").ToString()
                    If dt.Rows(0)("Hostel").ToString() = "N" Then
                        ChkHostel.Checked = False
                    Else
                        ChkHostel.Checked = True
                    End If
                    If dt.Rows(0)("Transport").ToString() = "N" Then
                        ChkTransport.Checked = False
                    Else
                        ChkTransport.Checked = True
                    End If
                    Me.ddlCourse.SelectedValue = dt.Rows(0)("Course_Id").ToString()
                    Me.ddlBranchName.SelectedValue = dt.Rows(0)("BranchCode").ToString()
                End If
            End If
            dt.Dispose()
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub txtdob_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtdob.TextChanged
        Try
            Me.txtage.Text = Convert.ToInt32(DateDiff(DateInterval.Year, CDate(Me.txtdob.Text), Today))
            txtdob.Focus()
        Catch ex As Exception
            Me.txtage.Text = ""
        End Try
    End Sub

    Sub DisplayGrid()
        Dim idd As New Integer
        dt.Clear()

        s.Name = txtFullName.Text.ToString()
        s.Code = txtregno.Text.ToUpper
        's.Code = ""
        If txtdob.Text <> "" Then
            s.DateOfBirth = txtdob.Text.ToString()
        Else
            s.DateOfBirth = "1/1/3000"
        End If
        s.coursebranchcode = ddlBranchName.SelectedValue
        s.CourseId = ddlCourse.SelectedValue
        s.Category = ddlcategry.Text.ToString()
        s.Alcategory = DdlAllocCat.Text.ToString()
        s.BatchNo = cmbBatch.Text.ToString()
        s.ApplicationNo = texApp.Text.ToString()
        s.HouseId = ddlHomeName.Text.ToString()
        s.A_year = cmbAcademic.SelectedValue
        s.MentorId = ddlMentorName.SelectedValue
        s.MentorId = ddlMentorCode.SelectedValue
        
        If txtAdate.Text <> "" Then
            s.AdmissionDate = txtAdate.Text.ToString()
        Else
            s.AdmissionDate = "1/1/3000"
        End If
        s.NicNo = txtNicNo.Text.ToUpper
        dt = StudentDB.GetStudents4(0, s)
        Try
            If dt.Rows.Count > 0 Then
                If (ViewState("SortExpression") <> "") Then
                    Dim sortedView As New DataView(dt)
                    Dim s As String = ViewState("SortExpression") & " " & ViewState("sortingDirection")
                    sortedView.Sort = s
                    GVDetails.DataSource = sortedView
                    GVDetails.DataBind()
                    
                Else
                    GVDetails.DataSource = dt
                    GVDetails.DataBind()
                    
                End If


                GVDetails.Enabled = True
                GVDetails.Visible = True
                LinkButton.Focus()
            Else
                msginfo.Text = ValidationMessage(1023)
                lblMsg.Text = ValidationMessage(1014)
                GVDetails.Visible = False
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1119)
            msginfo.Visible = True
        End Try
    End Sub
    Sub DisplayGrid1()
        Dim idd As New Integer
        dt.Clear()

        s.Name = ""
        s.Code = ""
        s.DateOfBirth = "1/1/3000"
        s.coursebranchcode = ddlBranchName.SelectedValue
        s.CourseId = 0
        s.Category = 0
        s.BatchNo = 0
        s.ApplicationNo = ""
        s.HouseId = 0
        s.A_year = 0
        s.MentorId = 0
        s.MentorId = 0
        s.AdmissionDate = "1/1/3000"
        s.NicNo = ""
        
        dt = StudentDB.GetStudents4(0, s)
        Try
            If dt.Rows.Count > 0 Then
                If (ViewState("SortExpression") <> "") Then
                    Dim sortedView As New DataView(dt)
                    Dim s As String = ViewState("SortExpression") & " " & ViewState("sortingDirection")
                    sortedView.Sort = s
                    GVDetails.DataSource = sortedView
                    GVDetails.DataBind()
                   
                Else
                    GVDetails.DataSource = dt
                    GVDetails.DataBind()
                   
                End If


                GVDetails.Enabled = True
                GVDetails.Visible = True
                LinkButton.Focus()
            Else
                msginfo.Text = ValidationMessage(1023)
                lblMsg.Text = ValidationMessage(1014)
                GVDetails.Visible = False
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1119)
            msginfo.Visible = True
        End Try
    End Sub
    Sub ViewAddData(ByVal id1 As String)
        Dim dt As Data.DataTable

        dt = StudentDB.getAddRecords(id1)
        Try
            If dt.Rows.Count > 0 Then
                If (ViewState("SortExpression") <> "") Then
                    Dim sortedView As New DataView(dt)
                    Dim s As String = ViewState("SortExpression") & " " & ViewState("sortingDirection")
                    sortedView.Sort = s
                    GVDetails.DataSource = sortedView
                    GVDetails.DataBind()
                    
                Else
                    GVDetails.DataSource = dt
                    GVDetails.DataBind()
                    
                End If
                GVDetails.Enabled = True
                GVDetails.Visible = True
                LinkButton.Focus()
            Else
                msginfo.Text = ValidationMessage(1023)
                lblMsg.Text = ValidationMessage(1014)
                GVDetails.Visible = False
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1119)
            msginfo.Visible = True
        End Try
    End Sub

    Protected Sub GVDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVDetails.RowEditing
        btnDetails.Enabled = False
        Dim x As String
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        'Try
        lblMsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        texApp.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("LabelAPP"), Label).Text
        txtregno.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("LabelAN"), Label).Text
        txtname.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblName"), Label).Text
        ddlBranchName.Items.Clear()
        ddlBranchName.DataSourceID = "ObjBranch"
        ddlBranchName.DataBind()
        x = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblBranchcode"), Label).Text
        ddlBranchName.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblBranchcode"), Label).Text
        ddlCourse.Items.Clear()
        ddlCourse.DataSourceID = "ObjectDataSource1"
        ddlCourse.DataBind()
        x = CType(GVDetails.Rows(e.NewEditIndex).FindControl("LabelCs"), Label).Text
        ddlCourse.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("LabelCs"), Label).Text
        Dim i As New Integer
        cmbBatch.Items.Clear()
        cmbBatch.DataSourceID = "ObjBatch"
        cmbBatch.DataBind()
        cmbBatch.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("labtbh"), Label).Text
        x = CType(GVDetails.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
        If x = "0" Or x = Nothing Then
            ddlHomeName.SelectedValue = 0
        Else
            ddlHomeName.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
        End If
        txtNicNo.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblNicNo"), Label).Text
        ddlfee.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Labelfee"), Label).Text
        ddlCountry.Items.Clear()
        ddlCountry.DataSourceID = "ObjCountry"
        ddlCountry.DataBind()
        ddlCountry.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbctry"), Label).Text
        ddlState.Items.Clear()
        ddlState.DataSourceID = "ObjState"
        ddlState.DataBind()
        ddlState.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbst"), Label).Text
        ddlDistric.Items.Clear()
        ddlDistric.DataSourceID = "ObjDistric"
        ddlDistric.DataBind()
        ddlDistric.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbdist"), HiddenField).Value
        txtCaddr.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("CADD"), Label).Text
        TxtPeriod.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("CADP"), Label).Text
        ddlcategry.Items.Clear()
        ddlcategry.DataSourceID = "ObjCategory"
        ddlcategry.DataBind()
        ddlcategry.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbcaty"), Label).Text
        DdlAllocCat.Items.Clear()
        DdlAllocCat.DataSourceID = "ObjCategory"
        DdlAllocCat.DataBind()
        DdlAllocCat.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbcatA"), Label).Text
        ddlsponsor.DataSourceID = "odsSponsor"
        ddlsponsor.DataBind()
        Dim sponsor As Integer = CType(GVDetails.Rows(e.NewEditIndex).Cells(0).FindControl("hdnspn"), HiddenField).Value
        ddlsponsor.SelectedValue = sponsor
        cmbTitle.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("labtit"), HiddenField).Value
        txtdob.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbldob"), Label).Text
        txtage.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbAg"), Label).Text
        Txtbirthplace.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbBp"), Label).Text
        ddlgender.SelectedItem.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbsx"), Label).Text
        txtFname.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbfn"), Label).Text
        txtPaddr.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbpa"), Label).Text
        txtCity.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbcty"), Label).Text
        txtPC.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbpin"), Label).Text
        txtdistance.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbdis"), Label).Text

        txtperphone.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbphno"), Label).Text
        ddlcaste.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbcst"), Label).Text
        txtIncome.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lba_inc"), HiddenField).Value
        txtreceiptno.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbrno"), Label).Text
        ddladmissiontype.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("addm_typ"), HiddenField).Value
        txt_occupt.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbocc"), HiddenField).Value
        txtemail.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbem"), Label).Text
        txtddno.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbddn"), Label).Text
        txtprospectusno.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbpno"), Label).Text

        ViewState("ImageTime") = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbphoto"), HiddenField).Value
        Dim sid As New Student
        txtcid.Text = CType(GVDetails.Rows(e.NewEditIndex).Cells(0).FindControl("EID"), HiddenField).Value
        sid.Id = CType(GVDetails.Rows(e.NewEditIndex).Cells(0).FindControl("EID"), HiddenField).Value
        ViewState("EID") = CType(GVDetails.Rows(e.NewEditIndex).FindControl("EID"), HiddenField).Value
        txtLeavingDate.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblLeaving"), Label).Text
        txtperphonestd.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblStudentContact"), Label).Text
        txtemailstd.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblStudentEmail"), Label).Text '
        txtAdate.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lbladate"), Label).Text
        txtMotheName.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblMotherName"), Label).Text
        txtFatherEmail.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblFatherEmail"), Label).Text
        txtFatherContact.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblFatherContact"), Label).Text
        txtFullName.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblFullName"), Label).Text
        txtNameinpassport.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblNameInPassport"), Label).Text
        txtPlaceofIssue.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblPlaceofIssue"), Label).Text
        txtPassportNo.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblPassportNo"), Label).Text
        txtExpiryDate.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblPassportExpiryDate"), Label).Text
        txtPassportIssueDate.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblPassportIssueDate"), Label).Text
        txtVisaExpDate.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblVisaExpDate"), Label).Text
        txtVisaIssueDate.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblVisaIssueDate"), Label).Text
        txtVisaNo.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblVisaNo"), Label).Text
        cmbBranch.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblFRROExpDate"), Label).Text
        txtMotherTongue.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblMotherTongue"), Label).Text
        txtTCNo.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblTCNo"), Label).Text
        txtRemarks.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
        txtFHomeContact.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("FatherHomeContact"), Label).Text
        txtMHomeContact.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("MontherHomeContact"), Label).Text
        txtFBizContact.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("FatherBizOffice"), Label).Text
        txtMBizContact.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("MotherBizOffice"), Label).Text
        txtFatherQualification.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("FatherQualification"), Label).Text
        txtMotherQualification.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("MotherQualification"), Label).Text
        txtMotherOccupation.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("MotherOccupation"), Label).Text
        txtReligion.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Religion"), Label).Text
        txtSecondUSN.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblSecondUSN"), Label).Text

        txtmidname.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblMnam"), Label).Text
        txtlblLName.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblLnam"), Label).Text
        txtcitizen.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label34"), Label).Text
        txtGDName.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label32"), Label).Text
        txtGDContactNo.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label33"), Label).Text
        txtGDEmail.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label35"), Label).Text
        txtGO.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label36"), Label).Text
        txtgrdnRel.Text = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label39"), Label).Text
        'ddlCountry.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label36"), Label).Text
        ddlethnic.Items.Clear()
        ddlethnic.DataSourceID = "Objethnic"
        ddlethnic.DataBind()
        ddlethnic.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label38"), Label).Text

        If CType(GVDetails.Rows(e.NewEditIndex).FindControl("SMS"), Label).Text = "B" Then
            CheckSMS.Checked = True
            CheckFSMS.Checked = True
        End If
        If CType(GVDetails.Rows(e.NewEditIndex).FindControl("SMS"), Label).Text = "M" Then
            CheckSMS.Checked = True
        End If
        If CType(GVDetails.Rows(e.NewEditIndex).FindControl("SMS"), Label).Text = "F" Then
            CheckFSMS.Checked = True
        End If

        If CType(GVDetails.Rows(e.NewEditIndex).FindControl("Mail"), Label).Text = "B" Then
            CheckMail.Checked = True
            CheckFMail.Checked = True
        End If
        If CType(GVDetails.Rows(e.NewEditIndex).FindControl("Mail"), Label).Text = "M" Then
            CheckMail.Checked = True
        End If
        If CType(GVDetails.Rows(e.NewEditIndex).FindControl("Mail"), Label).Text = "F" Then
            CheckFMail.Checked = True
        End If

        If CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblHostel"), Label).Text.Trim() = "N" Then
            ChkHostel.Checked = False
        Else
            ChkHostel.Checked = True
        End If
        If CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblTransport"), Label).Text.Trim() = "N" Then
            ChkTransport.Checked = False
        Else
            ChkTransport.Checked = True
        End If
        i = ViewState("EID")
        ddlenqno.Enabled = False
        s.Name = txtname.Text.ToString()
        s.Code = txtregno.Text.ToUpper
        If txtdob.Text <> "" Then
            s.DateOfBirth = txtdob.Text.ToString()
        Else
            s.DateOfBirth = "1/1/3000"
        End If
        s.coursebranchcode = ddlBranchName.SelectedValue
        s.CourseId = ddlCourse.SelectedValue
        s.Category = ddlcategry.Text.ToString()
        s.Alcategory = DdlAllocCat.Text.ToString()
        s.BatchNo = cmbBatch.Text.ToString()
        s.ApplicationNo = texApp.Text.ToString()
        s.HouseId = ddlHomeName.Text.ToString()
        s.A_year = cmbAcademic.SelectedValue
        s.NicNo = txtNicNo.Text.ToUpper
        If txtAdate.Text <> "" Then
            s.AdmissionDate = txtAdate.Text.ToString()
        Else
            s.AdmissionDate = "1/1/3000"
        End If
        ddlMentorName.Items.Clear()
        ddlMentorName.DataSourceID = "objMentorName"
        ddlMentorName.DataBind()
        If CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVMentorId"), Label).Text = "" Then
            ddlMentorName.SelectedValue = 0
        Else
            ddlMentorName.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVMentorId"), Label).Text
        End If
        ddlMentorCode.Items.Clear()
        ddlMentorCode.DataSourceID = "ObjMentorCode"
        ddlMentorCode.DataBind()
        If CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVMentorId"), Label).Text = "" Then
            ddlMentorCode.SelectedValue = 0
        Else
            ddlMentorCode.SelectedValue = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVMentorId"), Label).Text
        End If
        s.DOBCertificate = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVChkDOB"), Label).Text
        If s.DOBCertificate = "Y" Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
        s.TC = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVChkTC"), Label).Text
        If s.TC = "Y" Then
            CheckBox2.Checked = True
        Else
            CheckBox2.Checked = False
        End If
        s.BD = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVChkBachelorDegree"), Label).Text
        If s.BD = "Y" Then
            CheckBox3.Checked = True
        Else
            CheckBox3.Checked = False
        End If
        s.TEN = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVChkTenth"), Label).Text
        If s.TEN = "Y" Then
            CheckBox4.Checked = True
        Else
            CheckBox4.Checked = False
        End If
        s.MigrationCertificate = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVChkMigrationCertificate"), Label).Text
        If s.MigrationCertificate = "Y" Then
            CheckBox5.Checked = True
        Else
            CheckBox5.Checked = False
        End If
        s.MasterDegree = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVChkMasterDegree"), Label).Text
        If s.MasterDegree = "Y" Then
            CheckBox6.Checked = True
        Else
            CheckBox6.Checked = False
        End If
        s.twelve = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVChktwelve"), Label).Text
        If s.twelve = "Y" Then
            CheckBox7.Checked = True
        Else
            CheckBox7.Checked = False
        End If
        s.SLC = CType(GVDetails.Rows(e.NewEditIndex).FindControl("LabeGVChkSLC"), Label).Text
        If s.SLC = "Y" Then
            CheckBox9.Checked = True
        Else
            CheckBox9.Checked = False
        End If
        s.IC = CType(GVDetails.Rows(e.NewEditIndex).FindControl("lblGVChkIC"), Label).Text
        If s.IC = "Y" Then
            CheckBox8.Checked = True
        Else
            CheckBox8.Checked = False
        End If

        s.LOS = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label26"), Label).Text
        If s.LOS = "Y" Then
            CheckBox10.Checked = True
        Else
            CheckBox10.Checked = False
        End If
        s.AOR = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label29"), Label).Text
        If s.AOR = "Y" Then
            CheckBox11.Checked = True
        Else
            CheckBox11.Checked = False
        End If
        s.AOU = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label30"), Label).Text
        If s.AOU = "Y" Then
            CheckBox12.Checked = True
        Else
            CheckBox12.Checked = False
        End If
        s.CPhoto = CType(GVDetails.Rows(e.NewEditIndex).FindControl("Label31"), Label).Text
        If s.CPhoto = "Y" Then
            CheckBox13.Checked = True
        Else
            CheckBox13.Checked = False
        End If
        Dim bid As Long
        Dim a, b As Integer
        dt.Clear()
        If cmbBatch.SelectedValue <> "0" Then
            bid = cmbBatch.SelectedValue
            dt = sm.getTotalseats(bid)
            Try
                a = dt.Rows(0)("AvailSeatsCount")
                b = dt.Rows(0)("NoOfSeats")
                txtTotal.Text = b
                ViewState("seats") = b - a
                txtAvailable.Text = ViewState("seats")
            Catch ex As Exception
                txtTotal.Text = 0
                txtAvailable.Text = 0
            End Try
            lblTotal.Visible = True
            txtTotal.Visible = True
            txtTotal.Enabled = False
            lblAvailable.Visible = True
            txtAvailable.Visible = True
            txtAvailable.Enabled = False
        Else
            lblTotal.Visible = False
            txtTotal.Visible = False
            lblAvailable.Visible = False
            txtAvailable.Visible = False
        End If
        dt.Dispose()
        dt.Clear()
        dt = StudentDB.GetStudents4(sid.Id, s)
        GVDetails.DataSource = dt
        GVDetails.DataBind()
       
        GVDetails.Enabled = False
        GVDetails.Visible = True
        Me.ImageMap1.ImageUrl = ViewState("ImageTime")

        btnStddet.Text = "UPDATE"
        btnNext.Text = "BACK"
        If Session("LoginType") = "Others" Then
            btnDetails.Enabled = True
        End If
        
        'Catch ex As Exception
        '    StdClear()
        '    msginfo.Text = ValidationMessage(1122)
        '    lblMsg.Text = ValidationMessage(1014)
        'End Try
    End Sub

    Protected Sub GVDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVDetails.RowDeleting
        If Session("LoginType") <> "Others" Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim Foto As String = Session("Path") + CType(GVDetails.Rows(e.RowIndex).FindControl("lbphoto"), HiddenField).Value.ToString.Replace("~/", "")
                If IO.File.Exists(Foto) Then
                    IO.File.Delete(Foto)
                End If
                Dim sid As New Student
                sid.Id = CType(GVDetails.Rows(e.RowIndex).FindControl("EID"), HiddenField).Value
                Dim sidd As Integer = sid.Id
                StudentDB.Delete(sidd)
                DisplayGrid()
                Me.lblMsg.Text = ValidationMessage(1028)
                ddlenqno.Focus()
                msginfo.Text = ValidationMessage(1014)
                GVDetails.PageIndex = ViewState("PageIndex")
            Else
                msginfo.Text = ValidationMessage(1029)
                lblMsg.Text = ValidationMessage(1014)
            End If
        Else
            msginfo.Text = "You do not have permission to delete "
            lblMsg.Text = ""
        End If
    End Sub
    Protected Sub cmbBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatch.SelectedIndexChanged
        Try
            Dim bid As Long
            Dim a, b As Integer
            dt.Clear()
            If cmbBatch.SelectedValue <> "0" Then
                bid = cmbBatch.SelectedValue
                dt = sm.getTotalseats(bid)
                a = dt.Rows(0)("AvailSeatsCount")
                b = dt.Rows(0)("NoOfSeats")
                txtTotal.Text = b
                ViewState("seats") = b - a
                txtAvailable.Text = ViewState("seats")
                lblTotal.Visible = True
                txtTotal.Visible = True
                txtTotal.Enabled = False
                lblAvailable.Visible = True
                txtAvailable.Visible = True
                txtAvailable.Enabled = False
            Else
                lblTotal.Visible = False
                txtTotal.Visible = False
                lblAvailable.Visible = False
                txtAvailable.Visible = False
            End If
            dt.Dispose()
        Catch ex As Exception
            txtTotal.Text = 0
            txtAvailable.Text = 0
        End Try
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddladmissiontype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddladmissiontype.TextChanged
        ddladmissiontype.Focus()
    End Sub

    Protected Sub ddlcategry_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcategry.TextChanged
        ddlcategry.Focus()
    End Sub
    Protected Sub DdlAllocCat_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlAllocCat.TextChanged
        DdlAllocCat.Focus()
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        ddlCourse.Focus()
    End Sub

    Protected Sub ddlCourse_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.TextChanged
        ddlCourse.Focus()
    End Sub

    Protected Sub ddlenqno_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlenqno.TextChanged
        ddlenqno.Focus()
    End Sub

    Protected Sub ddlfee_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlfee.TextChanged
        ddlfee.Focus()
    End Sub

    Protected Sub ddlgender_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlgender.TextChanged
        ddlgender.Focus()
    End Sub

    Protected Sub ddlHomeName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHomeName.TextChanged
        ddlHomeName.Focus()
    End Sub

    Protected Sub ddlsponsor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsponsor.TextChanged
        ddlsponsor.Focus()
    End Sub

    Protected Sub ddlState_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlState.TextChanged
        ddlState.Focus()
    End Sub

    Protected Sub cmbAcademic_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcademic.TextChanged
        cmbAcademic.Focus()
    End Sub

    Protected Sub cmbBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatch.TextChanged
        cmbBatch.Focus()
    End Sub

    Protected Sub cmbTitle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTitle.TextChanged
        cmbTitle.Focus()
    End Sub

    Protected Sub txtFullName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFullName.TextChanged
        If txtFullName.Text <> "" Then
            txtname.Text = GlobalFunction.NameInitial(txtFullName.Text)
            txtIndex.Focus()
        End If
    End Sub

    Protected Sub GVDetails_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVDetails.Sorting
        If ViewState("Button") = "SEARCH" Then
            Dim sortingDirection As String = String.Empty
            If dir = SortDirection.Ascending Then
                dir = SortDirection.Descending
                sortingDirection = "Desc"
            Else
                dir = SortDirection.Ascending
                sortingDirection = "Asc"
            End If
            Dim idd As New Integer

            s.Name = txtFullName.Text.ToString()
            s.Code = txtregno.Text.ToUpper
            If txtdob.Text <> "" Then
                s.DateOfBirth = txtdob.Text.ToString()
            Else
                s.DateOfBirth = "1/1/3000"
            End If
            s.CourseId = ddlCourse.SelectedValue
            s.Category = ddlcategry.Text.ToString()
            s.Alcategory = DdlAllocCat.Text.ToString()
            s.BatchNo = cmbBatch.Text.ToString()
            s.ApplicationNo = texApp.Text.ToString()
            s.HouseId = ddlHomeName.Text.ToString()
            s.A_year = cmbAcademic.SelectedValue
            s.coursebranchcode = ddlBranchName.SelectedValue
            If txtAdate.Text <> "" Then
                s.AdmissionDate = txtAdate.Text.ToString()
            Else
                s.AdmissionDate = "1/1/3000"
            End If
            s.NicNo = txtNicNo.Text.ToUpper
            dt = StudentDB.GetStudents4(0, s)
            Dim sortedView As New DataView(dt)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            ViewState("SortExpression") = e.SortExpression
            ViewState("sortingDirection") = sortingDirection
            GVDetails.DataSource = sortedView
            GVDetails.DataBind()
          
        Else
            Dim sortingDirection As String = String.Empty
            If dir = SortDirection.Ascending Then
                dir = SortDirection.Descending
                sortingDirection = "Desc"
            Else
                dir = SortDirection.Ascending
                sortingDirection = "Asc"
            End If
            Dim idd As New Integer
            s.coursebranchcode = ddlBranchName.SelectedValue
            s.Name = ""
            s.Code = ""
            s.DateOfBirth = "1/1/3000"
            s.CourseId = 0
            s.Category = 0
            s.BatchNo = 0
            s.ApplicationNo = ""
            s.HouseId = 0
            s.A_year = 0
            s.AdmissionDate = "1/1/3000"
            s.NicNo = ""
            dt = StudentDB.GetStudents4(0, s)
            Dim sortedView As New DataView(dt)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            ViewState("SortExpression") = e.SortExpression
            ViewState("sortingDirection") = sortingDirection
            GVDetails.DataSource = sortedView
            GVDetails.DataBind()
           
        End If

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

    Protected Sub ddlMentorName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMentorName.SelectedIndexChanged
        ddlMentorName.Focus()
        Dim MentorId As Integer
        If ddlMentorName.SelectedValue <> 0 Then
            MentorId = ddlMentorName.SelectedValue
            ddlMentorName.SelectedValue = MentorId
            ddlMentorName.SelectedValue = 0
            ddlMentorName.Items.Clear()
            ddlMentorName.DataSourceID = "objMentorName"
            ddlMentorName.DataBind()
            ddlMentorName.SelectedValue = MentorId
            ddlMentorCode.SelectedValue = MentorId
        Else
            ddlMentorName.SelectedValue = 0
            ddlMentorCode.SelectedValue = 0
            dt = StudentDB.GetMentorName(MentorId)
            ddlMentorName.Items.Clear()
            ddlMentorName.DataSourceID = "objMentorName"
            ddlMentorName.DataBind()
        End If
    End Sub

    Protected Sub ddlMentorCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMentorCode.SelectedIndexChanged
        Dim MentorId As Integer
        ddlMentorCode.Focus()
        If ddlMentorCode.SelectedValue <> 0 Then
            MentorId = ddlMentorCode.SelectedValue
            ddlMentorCode.SelectedValue = 0
            ddlMentorCode.Items.Clear()
            ddlMentorCode.DataSourceID = "ObjMentorCode"
            ddlMentorCode.DataBind()
            ddlMentorCode.SelectedValue = MentorId
            ddlMentorName.SelectedValue = MentorId
        Else
            ddlMentorCode.SelectedValue = 0
            ddlMentorName.SelectedValue = 0
            ddlMentorCode.Items.Clear()
            ddlMentorCode.DataSourceID = "ObjMentorCode"
            ddlMentorCode.DataBind()
        End If
    End Sub
    'Code written fro multilingual by Niraj on 19 oct 2013
    ''Retriving the text of controls based on Language

    
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        Try


            dt2 = Session("ValidationTable")
            If dt2 Is Nothing Then
                Response.Redirect("LogIn.aspx")
            End If
            Dim X As Integer = dt2.Rows.Count() - 1
            Dim str As String = " "
            For i As Integer = 0 To X
                If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                    Return dt2.Rows(i).Item("MessageText").ToString()
                End If
            Next

        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
        Return 0
    End Function
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub

    Protected Sub BtnGo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGo.Click
        Try
            For Each Grid As GridViewRow In GVCriteria.Rows
                Dim a As String
                a = CType(Grid.FindControl("ddlCriteriavalue"), DropDownList).Text
                If CType(Grid.FindControl("ddlCriteriavalue"), DropDownList).Text = "0" Then
                    lblRed.Text = "You are not eligible."
                    lblGreen.Text = ""
                    TabContainer1.ActiveTab = TabPanel1
                    TabPanel2.Visible = False
                    TabPanel1.Visible = True
                    TabPanel2.Enabled = False
                    Exit Sub
                Else
                    TabContainer1.ActiveTab = TabPanel2
                    TabPanel2.Visible = True
                    TabPanel1.Visible = False
                    TabPanel2.Enabled = True
                End If
            Next

        Catch ex As Exception
            TabContainer1.ActiveTab = TabPanel2
            TabPanel2.Visible = True
            TabPanel1.Visible = False
            TabPanel2.Enabled = True
        End Try
    End Sub


   
End Class

