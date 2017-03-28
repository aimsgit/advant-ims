Partial Class frmIndividualForm
    Inherits BasePage
    'Dim open As New System.Windows.Forms.OpenFileDialog
    Dim indmaster As New IndividualFormMaster
    Dim individual As New BLIndividualFormMaster
    Dim GlobalFunction As New GlobalFunction
    Dim indmaster1 As New DLIndividualFormMaster
    Dim dt, dt1 As New DataTable
    Dim path, path1, str As String
    Dim dat, nextage, a, tod As Integer
    Dim el As New ELEmpQualification
    Dim ELMed As New ElMedicalDetails
    Sub EntityAssign()

        indmaster.OtherName = txtOthername.Text
        indmaster.Initial = txtInt.Text
        indmaster.PersonalFileNo = txtPFileNo.Text
        If txtDop.Text = "" Then
            indmaster.DOP = "1/1/3000"
        Else
            indmaster.DOP = txtDop.Text
        End If
        If TxtSRDate.Text = "" Then
            indmaster.SalaryRevDate = "01/01/9100"
        Else
            indmaster.SalaryRevDate = TxtSRDate.Text
        End If
        indmaster.ModeOfpayement = ddlpaymentmethod.SelectedValue
        indmaster.PFACCNO = txtPFAcctNo.Text
        'indmaster.DOP = txtDop.Text
        indmaster.Nominee = txtNomi.Text
        indmaster.Race = txtrace.Text
        indmaster.ETF = txtEtf.Text
        indmaster.Distric = ddlDistric.SelectedValue
        indmaster.City = txtCity.Text
        indmaster.StateName = ddlState.SelectedValue
        indmaster.PinCode = txtPC.Text
        indmaster.EmploymentType = RBEmpType.SelectedValue
        indmaster.EmpCategory = txtEmpCategory.Text
        indmaster.EmpType = ddlEmpType.SelectedValue
        indmaster.Emp_Name = txtEmpName.Text
        indmaster.Emp_Code = txtEmpcode.Text
        indmaster.Emp_Address = txtAddress.Text
        indmaster.Country = ddlCountry.SelectedValue
        indmaster.ContactNo = txtContactNo.Text
        indmaster.LandlineNo = txtLandlineNo.Text
        indmaster.Email = txtEmail.Text
        indmaster.PANNO = txtPanNo.Text
        indmaster.Qualification = txtqualification.Text
        indmaster.SalaryGrade = ddlGrade.SelectedValue
        indmaster.ESINo = txtESINo.Text
        indmaster.VDA = txtVDA.Text
        indmaster.Nationality = txtNationality.Text
        indmaster.Ethnicity = txtEthnicity.SelectedValue
        indmaster.Religion = txtReligion.Text
        indmaster.CivilStates = txtCivilStates.Text
        indmaster.Title = cmbTitle.SelectedValue
        indmaster.MiddleName = txtmiddle.Text
        indmaster.StopSalaryReason = txtStopSalaryReason.Text
        indmaster.Remark = txtRemarks.Text
        If ChkStopSalary.Checked = True Then
            indmaster.StopSalary = "Y"
        Else
            indmaster.StopSalary = "N"
        End If
        If txtsalarystop.Text = "" Then
            indmaster.StopSalaryDate = "1/1/2999"
        Else
            indmaster.StopSalaryDate = txtsalarystop.Text
        End If

        If txtDOB.Text = "" Then
            indmaster.DOB = "1/1/2999"
        Else
            indmaster.DOB = txtDOB.Text
        End If
        If txtDOJ.Text = "" Then
            indmaster.DOJ = "1/1/3000"
        Else
            indmaster.DOJ = txtDOJ.Text
        End If
        If txtDOL.Text = "" Then
            indmaster.DOL = "1/1/3100"
        Else
            indmaster.DOL = txtDOL.Text
        End If
        If txtretirement.Text = "" Then
            indmaster.DOR = "1/1/3100"
        Else
            indmaster.DOR = txtretirement.Text
        End If
        If txtDOA.Text = "" Then
            indmaster.DOA = "1/1/3100"
        Else
            indmaster.DOA = txtDOA.Text
        End If
        If txtSalary.Text = "" Then
            indmaster.Salary = 0
        Else
            indmaster.Salary = txtSalary.Text
        End If
        indmaster.Sex = ddlSex.SelectedItem.Text
        indmaster.Designation = ddldesignation.SelectedValue
        indmaster.dpt_Id = ddlDept.SelectedValue
        'indmaster.BranchTypeCode = DDLDeptType.SelectedValue
        indmaster.Branch_Code = Ddldpt.SelectedValue
        indmaster.AccountNo = txtAccountNo.Text
        If HidBankId.Value = "" Then
            indmaster.AgentTypeCode = 0
        Else
            indmaster.AgentTypeCode = HidBankId.Value
        End If
        indmaster.ServicePeriod = txtServicePeriod.Text
        indmaster.HRAEmpCode = HidHRAEmp.Value
        indmaster.FMEmpCode = HidFMEmpCode.Value
        indmaster.RMEmpCode = HidRMEmpCode.Value

        indmaster.NICNO = txtNicNo.Text
        indmaster.Corres_Address = txtCaddr.Text
        If ChkHostel.Checked = True Then
            indmaster.Hostel = "Y"
        Else
            indmaster.Hostel = "N"
        End If
        If ChkTransport.Checked = True Then
            indmaster.Transport = "Y"
        Else
            indmaster.Transport = "N"
        End If
        indmaster.FatherName = txtFname.Text
        indmaster.SpouseName = txtSpouseName.Text
        indmaster.MotherName = txtMothername.Text
        indmaster.NameInPassport = txtNameinpassport.Text
        indmaster.PlaceofIssue = txtPlaceofIssue.Text
        indmaster.PassportNo = txtPassportNo.Text
        indmaster.PFNo = txtPFNo.Text
        If txtPassportIssueDate.Text = "" Then
            indmaster.PassportIssueDate = "1/1/3000"
        Else
            indmaster.PassportIssueDate = txtPassportIssueDate.Text
        End If
        If txtVisaExpDate.Text = "" Then
            indmaster.VisaExpiryDate = "1/1/3000"
        Else
            indmaster.VisaExpiryDate = txtVisaExpDate.Text
        End If
        If txtVisaIssueDate.Text = "" Then
            indmaster.VisaIssueDate = "1/1/3000"
        Else
            indmaster.VisaIssueDate = txtVisaIssueDate.Text
        End If
        indmaster.VisaNo = txtVisaNo.Text
        If Me.txtFRRO.Text <> "" Then
            indmaster.FRROExpDate = Me.txtFRRO.Text
        Else
            indmaster.FRROExpDate = "1/1/3000"
        End If
        If txtExpiryDate.Text = "" Then
            indmaster.PassportExpiryDate = "1/1/3000"
        Else
            indmaster.PassportExpiryDate = txtExpiryDate.Text
        End If
        indmaster.VisaNo = txtVisaNo.Text

        If CheckBox1.Checked = True Then
            If HidEmpCode.Value = "" Then
                indmaster.Delegate1 = 0
            Else
                indmaster.Delegate1 = HidEmpCode.Value
            End If
            indmaster.Delegated = "Y"
        Else
            indmaster.Delegate1 = ""
            indmaster.Delegated = "N"
        End If
        If ViewState("ImageTime") = Nothing Then
            indmaster.Photos = ""
        Else
            indmaster.Photos = ViewState("ImageTime")
        End If
        If ChkGratutity.Checked = True Then
            indmaster.Gratuity = "Y"
        Else
            indmaster.Gratuity = "N"
        End If
        If ChkIncrement.Checked = True Then
            indmaster.Increment = "Y"
        Else
            indmaster.Increment = "N"
        End If
        If ChkPension.Checked = True Then
            indmaster.Pension = "Y"
        Else
            indmaster.Pension = "N"
        End If
        If ChkPromotion.Checked = True Then
            indmaster.Promotion = "Y"
        Else
            indmaster.Promotion = "N"
        End If
        If ChkUniform.Checked = True Then
            indmaster.Uniform = "Y"
        Else
            indmaster.Uniform = "N"
        End If
        If ChkResignation.Checked = True Then
            indmaster.Resignation = "Y"
        Else
            indmaster.Resignation = "N"
        End If
        If ChkSttlmnt.Checked = True Then
            indmaster.Settelement = "Y"
        Else
            indmaster.Settelement = "N"
        End If
        If chkPensionable.Checked = True Then
            indmaster.Pensionable = "Y"
        Else
            indmaster.Pensionable = "N"
        End If





    End Sub

    Protected Sub Btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        Try
            txtEmpcode.Focus()
            If (Session("BranchCode") = Session("ParentBranch")) Then
                'a = GlobalFunction.UserPrivilage()
                a = 1

                If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                    lblmsg.Text = ValidationMessage(1014)
                    lblgreen.Text = ValidationMessage(1014)
                    If txtDOB.Text <> "" Then
                        tod = Year(Today.Date)
                        dat = Year(txtDOB.Text)
                        nextage = (tod - dat) + 1
                    Else
                        nextage = 100
                    End If
                    EntityAssign()

                    If txtDOJ.Text <> "" And indmaster.DOJ > Date.Today Then
                        lblgreen.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1124)
                        txtDOJ.Focus()
                    ElseIf nextage < 18 Then
                        lblgreen.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1125)
                        txtDOB.Focus()
                    Else
                        If Btnadd.CommandName = "ADD" Then
                            dt = individual.CheckDuplicate(indmaster)
                            If dt.Rows.Count > 0 Then
                                lblgreen.Text = ValidationMessage(1014)
                                lblmsg.Text = ValidationMessage(1126)
                                GridView1.Visible = True
                            Else
                                'If txtPassportIssueDate.Text <> "" Or txtExpiryDate.Text <> "" Then
                                If CDate(IIf(txtPassportIssueDate.Text = "", "1/1/1000", txtPassportIssueDate.Text)) >= CDate(IIf(txtExpiryDate.Text = "", "1/1/3000", txtExpiryDate.Text)) Then
                                    Me.lblgreen.Text = ValidationMessage(1014)
                                    Me.lblmsg.Text = ValidationMessage(1110)
                                    Exit Sub
                                End If
                                If CDate(IIf(txtVisaIssueDate.Text = "", "1/1/1000", txtVisaIssueDate.Text)) >= CDate(IIf(txtVisaExpDate.Text = "", "1/1/3000", txtVisaExpDate.Text)) Then
                                    Me.lblgreen.Text = ValidationMessage(1014)
                                    Me.lblmsg.Text = ValidationMessage(1111)
                                    Exit Sub
                                End If
                                If CDate(IIf(txtPassportIssueDate.Text = "", "1/1/1000", txtPassportIssueDate.Text)) >= CDate(IIf(txtVisaIssueDate.Text = "", "1/1/3000", txtVisaIssueDate.Text)) Then
                                    Me.lblgreen.Text = ValidationMessage(1014)
                                    Me.lblmsg.Text = ValidationMessage(1127)
                                    Exit Sub
                                End If
                                If CDate(IIf(txtVisaExpDate.Text = "", "1/1/1000", txtVisaExpDate.Text)) >= CDate(IIf(txtExpiryDate.Text = "", "1/1/3000", txtExpiryDate.Text)) Then
                                    Me.lblgreen.Text = ValidationMessage(1014)
                                    Me.lblmsg.Text = ValidationMessage(1113)
                                    Exit Sub
                                End If

                                If CDate(IIf(txtVisaIssueDate.Text = "", "1/1/1000", txtVisaIssueDate.Text)) >= CDate(IIf(txtExpiryDate.Text = "", "1/1/3000", txtExpiryDate.Text)) Then
                                    Me.lblgreen.Text = ValidationMessage(1014)
                                    Me.lblmsg.Text = ValidationMessage(1128)
                                    Exit Sub
                                End If
                                'If txtDOJ.Text <> "" Then
                                '    If txtDOL.Text <> "" Then
                                If CDate(IIf(txtDOJ.Text = "", "1/1/1000", txtDOJ.Text)) > CDate(IIf(txtDOL.Text = "", "1/1/3000", txtDOL.Text)) Then
                                    lblmsg.Text = ValidationMessage(1129)
                                    Exit Sub
                                End If

                                If CDate(IIf(txtretirement.Text = "", "1/1/3100", txtretirement.Text)) < CDate(IIf(txtDOJ.Text = "", "1/1/1000", txtDOJ.Text)) Then
                                    lblmsg.Text = ValidationMessage(1125)
                                    Exit Sub
                                End If
                                'If CDate(IIf(txtDOA.Text = "", "1/1/3100", txtDOA.Text)) > CDate(IIf(txtDOJ.Text = "", "1/1/1000", txtDOJ.Text)) Then
                                '    'lblmsg.Text = ValidationMessage(1125)
                                '    lblmsg.Text = "DOA should not be greater than DOJ"
                                '    Exit Sub
                                'End If

                                'If txtDOB.Text <> "" Then
                                If CDate(IIf(txtDOB.Text = "", "1/1/1000", txtDOB.Text)) > CDate(IIf(txtDOJ.Text = "", "1/1/3000", txtDOJ.Text)) Then
                                    lblmsg.Text = ValidationMessage(1130)
                                    Exit Sub
                                End If
                                If CDate(IIf(txtDOB.Text = "", "1/1/1000", txtDOB.Text)) > CDate(IIf(txtDOL.Text = "", "1/1/3000", txtDOL.Text)) Then
                                    lblmsg.Text = ValidationMessage(1131)
                                    Exit Sub
                                End If

Insert:                         individual.InsertRecord(indmaster)
                                If GlobalFunction.ErrorMsg <> "Error" Then
                                    clear()

                                    Btnadd.CommandName = "ADD"
                                    BtnView.CommandName = "VIEW"
                                    lblmsg.Text = ValidationMessage(1014)
                                    ViewState("ImageTime") = ""
                                    lblgreen.Text = ValidationMessage(1020)
                                    ViewState("PageIndex") = 0
                                    GridView1.PageIndex = 0
                                    DispGrid()
                                    GridView1.Visible = True

                                Else
                                    lblgreen.Text = ValidationMessage(1014)
                                    lblmsg.Text = ValidationMessage(1132)
                                End If
                            End If
                        ElseIf Btnadd.CommandName = "UPDATE" Then
                            'If txtPassportIssueDate.Text <> "" Or txtExpiryDate.Text <> "" Then
                            If CDate(IIf(txtPassportIssueDate.Text = "", "1/1/1000", txtPassportIssueDate.Text)) >= CDate(IIf(txtExpiryDate.Text = "", "1/1/3000", txtExpiryDate.Text)) Then
                                Me.lblgreen.Text = ValidationMessage(1014)
                                Me.lblmsg.Text = ValidationMessage(1110)
                                Exit Sub
                            End If
                            If CDate(IIf(txtVisaIssueDate.Text = "", "1/1/1000", txtVisaIssueDate.Text)) >= CDate(IIf(txtVisaExpDate.Text = "", "1/1/3000", txtVisaExpDate.Text)) Then
                                Me.lblgreen.Text = ValidationMessage(1014)
                                Me.lblmsg.Text = ValidationMessage(1111)
                                Exit Sub
                            End If
                            If CDate(IIf(txtPassportIssueDate.Text = "", "1/1/1000", txtPassportIssueDate.Text)) >= CDate(IIf(txtVisaIssueDate.Text = "", "1/1/3000", txtVisaIssueDate.Text)) Then
                                Me.lblgreen.Text = ValidationMessage(1014)
                                Me.lblmsg.Text = ValidationMessage(1127)
                                Exit Sub
                            End If
                            If CDate(IIf(txtVisaExpDate.Text = "", "1/1/1000", txtVisaExpDate.Text)) >= CDate(IIf(txtExpiryDate.Text = "", "1/1/3000", txtExpiryDate.Text)) Then
                                Me.lblgreen.Text = ValidationMessage(1014)
                                Me.lblmsg.Text = ValidationMessage(1113)
                                Exit Sub
                            End If
                            If CDate(IIf(txtVisaIssueDate.Text = "", "1/1/1000", txtVisaIssueDate.Text)) >= CDate(IIf(txtExpiryDate.Text = "", "1/1/3000", txtExpiryDate.Text)) Then
                                Me.lblgreen.Text = ValidationMessage(1014)
                                Me.lblmsg.Text = ValidationMessage(1128)
                                Exit Sub
                            End If
                            'If txtDOJ.Text <> "" Then
                            '    If txtDOL.Text <> "" Then
                            If CDate(IIf(txtDOJ.Text = "", "1/1/1000", txtDOJ.Text)) > CDate(IIf(txtDOL.Text = "", "1/1/3000", txtDOL.Text)) Then
                                lblmsg.Text = ValidationMessage(1129)
                                Exit Sub
                            End If
                            'If txtDOB.Text <> "" Then
                            If CDate(IIf(txtDOB.Text = "", "1/1/1000", txtDOB.Text)) > CDate(IIf(txtDOJ.Text = "", "1/1/3000", txtDOJ.Text)) Then
                                lblmsg.Text = ValidationMessage(1130)
                                Exit Sub
                            End If
                            If CDate(IIf(txtDOB.Text = "", "1/1/1000", txtDOB.Text)) > CDate(IIf(txtDOL.Text = "", "1/1/3000", txtDOL.Text)) Then
                                lblmsg.Text = ValidationMessage(1131)
                                Exit Sub
                            End If
                            If CDate(IIf(txtretirement.Text = "", "1/1/3100", txtretirement.Text)) < CDate(IIf(txtDOJ.Text = "", "1/1/1000", txtDOJ.Text)) Then
                                lblmsg.Text = ValidationMessage(1225)
                                Exit Sub
                            End If
                            'If CDate(IIf(txtDOA.Text = "", "1/1/3100", txtDOA.Text)) > CDate(IIf(txtDOJ.Text = "", "1/1/1000", txtDOJ.Text)) Then
                            '    'lblmsg.Text = ValidationMessage(1125)
                            '    lblmsg.Text = "DOA should not be greater than DOJ"
                            '    Exit Sub
                            'End If
                            Dim Check As Integer = Request.QueryString.Get("check")
Update:                     indmaster.Emp_Id = ViewState("Emp_Id")
                            If Check <> 2 Then
                                individual.UpdateRecord(indmaster)
                            Else
                                individual.UpdateRecordDetails(indmaster)
                            End If

                            If GlobalFunction.ErrorMsg <> "Error" Then

                                If Check <> 2 Then
                                    clear()
                                End If
                               


                                If Check = 2 Then
                                    Btnadd.Text = "UPDATE"
                                    BtnView.Text = "VIEW"
                                Else
                                    Btnadd.Text = "ADD"
                                    BtnView.Text = "VIEW"
                                    Btnadd.CommandName = "ADD"
                                    BtnView.CommandName = "VIEW"
                                End If
                                lblmsg.Text = ValidationMessage(1014)
                                ViewState("ImageTime") = ""
                                lblgreen.Text = ValidationMessage(1017)
                                If Check <> 2 Then
                                    txtEmpcode.Enabled = True
                                End If

                                indmaster.Designation = "0"
                                indmaster.Emp_Name = 0
                                indmaster.EmpCode = "*"
                                indmaster.EmpCategory = ""
                                indmaster.EmploymentType = 0
                                indmaster.BranchTypeCode = 0
                                indmaster.PassportNo = 0
                                indmaster.ContactNo = 0
                                indmaster.LandlineNo = 0
                                indmaster.Email = 0
                                indmaster.Qualification = 0
                                indmaster.Sex = 0
                                indmaster.Country = 0
                                indmaster.DOB = "1/1/2999"
                                indmaster.DOL = "1/1/3100"
                                indmaster.DOJ = "1/1/3000"
                                indmaster.DOR = "1/1/3100"
                                indmaster.DOA = "1/1/3100"
                                indmaster.DeptID = 0
                                indmaster.NICNO = ""
                                indmaster.Emp_Id = 0

                                If Check = 2 Then
                                    indmaster.Emp_Id = ViewState("Emp_Id")
                                Else
                                    indmaster.Emp_Id = 0
                                End If
                                If Check <> 2 Then
                                    dt = individual.GetIndividualFormMaster(indmaster)
                                Else
                                    dt = individual.GetENPLOYEEDetails(indmaster)
                                End If
                                GridView1.DataSource = dt
                                GridView1.DataBind()
                               
                                GridView1.Enabled = True
                                GridView1.Visible = True
                                GridView1.Visible = True
                                GridView1.PageIndex = ViewState("PageIndex")
                                For Each rows As GridViewRow In GridView1.Rows
                                    If CType(rows.FindControl("LabelDOB"), Label).Text = "01-Jan-2999" Then
                                        CType(rows.FindControl("LabelDOB"), Label).Text = ""
                                    End If
                                    If CType(rows.FindControl("LabelDOJ"), Label).Text = "01-Jan-3000" Then
                                        CType(rows.FindControl("LabelDOJ"), Label).Text = ""
                                    End If
                                    If CType(rows.FindControl("LabelDOL"), Label).Text = "01-Jan-3100" Then
                                        CType(rows.FindControl("LabelDOL"), Label).Text = ""
                                    End If
                                    If CType(rows.FindControl("LabelDOR"), Label).Text = "01-Jan-3100" Then
                                        CType(rows.FindControl("LabelDOR"), Label).Text = ""
                                    End If
                                    If CType(rows.FindControl("LabelDOA"), Label).Text = "01-Jan-3100" Then
                                        CType(rows.FindControl("LabelDOA"), Label).Text = ""
                                    End If
                                Next
                            Else
                                lblgreen.Text = ValidationMessage(1014)
                                lblmsg.Text = ValidationMessage(1132)
                            End If
                        End If
                    End If
                Else
                    lblmsg.Text = ValidationMessage(1133)
                    lblgreen.Text = ValidationMessage(1014)
                End If
            Else
                lblmsg.Text = ValidationMessage(1021)
                lblgreen.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1022)
            lblgreen.Text = ValidationMessage(1014)
        End Try
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        'a = GlobalFunction.UserPrivilage()
        a = 1
        If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
            lblmsg.Text = ValidationMessage(1014)
            lblgreen.Text = ValidationMessage(1014)
            Dim Check As Integer = Request.QueryString.Get("check")
           
            If Check = 2 Then
                BtnView.Text = "BACK"
                Btnadd.Text = "UPDATE"
            End If
            BtnView.Text = "BACK"
            Btnadd.Text = "UPDATE"
            BtnView.CommandName = "BACK"
            Btnadd.CommandName = "UPDATE"
            txtEmpcode.Enabled = False
            If Check <> 2 Then
                ViewState("Emp_Id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEmp_Id"), HiddenField).Value
            Else
                ViewState("Emp_Id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEmp_Id2"), HiddenField).Value
            End If


            txtEmpCategory.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEmployeeCategory"), Label).Text
            ddlEmpType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEmployeeType"), Label).Text
            RBEmpType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEmployeeType"), Label).Text
            txtEmpName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEmp_Name"), Label).Text.Trim
            txtEmpcode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEmp_Code"), Label).Text
            txtAddress.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEmp_Address"), Label).Text
            ddlCountry.Items.Clear()
            ddlCountry.DataSourceID = "ObjCountry"
            ddlCountry.DataBind()
            Dim x As String
            x = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelCountry"), Label).Text
            ddlCountry.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelCountry"), Label).Text
            txtContactNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelContactNo"), Label).Text
            txtLandlineNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblLandlineNo"), Label).Text
            txtEmail.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEmail"), Label).Text
            txtDOB.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelDOB"), Label).Text
            txtDOJ.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelDOJ"), Label).Text
            txtDOL.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelDOL"), Label).Text
            'TxtRemarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lblremark"), Label).Text
            txtretirement.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelDOR"), Label).Text
            txtDOA.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelDOA"), Label).Text
            txtPanNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPanNo"), Label).Text
            txtqualification.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblQualification"), Label).Text
            ddlSex.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelGender"), Label).Text
            DDLEmployeeName.Items.Clear()
            DDLEmployeeName.DataSourceID = "ObjEmpName"
            DDLEmployeeName.DataBind()

            x = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEMPDETAILS"), Label).Text
            DDLEmployeeName.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEMPDETAILS"), Label).Text
            DDLEmployeeName1.Items.Clear()
            DDLEmployeeName1.DataSourceID = "ObjectDataSource1"
            DDLEmployeeName1.DataBind()
            DDLEmployeeName1.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEMPDETAILS"), Label).Text
            'CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEmp_Name"), Label).Text.Trim()
            Try
                If CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelDeptId"), Label).Text = "" Then
                    ddlDept.SelectedValue = 0
                Else
                    ddlDept.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelDeptId"), Label).Text
                End If
            Catch ex As Exception

            End Try
            'DDLDeptType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelBranchType_ID"), Label).Text
            Ddldpt.Items.Clear()
            Ddldpt.DataSourceID = "objDept"
            Ddldpt.DataBind()
            Ddldpt.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelBranchMaster_ID"), Label).Text
            ddldesignation.Items.Clear()
            ddldesignation.DataSourceID = "ObjDesignation"
            ddldesignation.DataBind()
            Dim de As String = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelDesignationCode"), Label).Text
            ddldesignation.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelDesignationCode"), Label).Text
            txtSalary.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelSalary"), Label).Text
            txtAccountNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelAccountNo"), Label).Text
            txtAcctBranch.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelBank_Name"), Label).Text
            HidBankId.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelAgentID"), Label).Text
            txtServicePeriod.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lableServicePeriod"), Label).Text
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lbldelegated"), Label).Text = "Y" Then
                CheckBox1.Checked = True
                txtDelegated.Enabled = True
                HidEmpCode.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelDelegate"), Label).Text
                txtDelegated.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelDelegateName"), Label).Text
            End If
            HidHRAEmp.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelHRAEmpCode"), Label).Text
            txtHRAEmp.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelHRAEmpName"), Label).Text
            HidFMEmpCode.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelFMEmpCode"), Label).Text
            txtFMEmpCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelFMEmpName"), Label).Text
            HidRMEmpCode.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelRMEmpCode"), Label).Text
            txtRMEmpCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelRMEEmpName"), Label).Text
            ViewState("ImageTime") = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelPhotos"), Label).Text.Trim
            Image2.ImageUrl = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelPhotos"), Label).Text.Trim

            txtNicNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("NICNO"), Label).Text
            txtCaddr.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Corres_Address"), Label).Text
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("Hostel"), Label).Text = "Y" Then
                ChkHostel.Checked = True
            Else
                ChkHostel.Checked = False
            End If
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("Transport"), Label).Text = "Y" Then
                ChkTransport.Checked = True
            Else
                ChkTransport.Checked = False
            End If
            txtFname.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("FatherName"), Label).Text
            txtMothername.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("MotherName"), Label).Text
            txtSpouseName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("SpouseName"), Label).Text
            txtNameinpassport.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("NameInPassport"), Label).Text
            txtPlaceofIssue.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("PlaceofIssue"), Label).Text
            txtPassportNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("PassportNo"), Label).Text
            txtExpiryDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("PassportExpiryDate"), Label).Text
            txtPassportIssueDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("PassportIssueDate"), Label).Text
            txtVisaIssueDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("VisaIssueDate"), Label).Text
            txtVisaExpDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("VisaExpiryDate"), Label).Text
            txtVisaNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("VisaNo"), Label).Text
            txtPFNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("PFNo"), Label).Text
            txtFRRO.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("FRROExpDate"), Label).Text
            If ddlGrade.SelectedValue = 0 Then

            End If
            ddlGrade.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblGrade"), Label).Text
            txtESINo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblESINo"), Label).Text
            txtVDA.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblVDA"), Label).Text
            txtNationality.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblNationality"), Label).Text
            txtReligion.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblReligion"), Label).Text
            txtEthnicity.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEthnicity"), Label).Text
            txtCivilStates.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCivilStates"), Label).Text

            txtOthername.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblOthername"), Label).Text
            txtInt.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblInitial"), Label).Text
            txtPFileNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblPFileNo"), Label).Text
            txtDop.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblDOP"), Label).Text
            txtNomi.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblNomenee"), Label).Text
            txtrace.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblRace"), Label).Text
            txtEtf.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblETF"), Label).Text


            txtCity.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblCity"), Label).Text
            txtPC.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblPinCode"), Label).Text
            cmbTitle.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblTitle5"), Label).Text
            ddlpaymentmethod.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblModeOfPayment"), Label).Text
            txtPFAcctNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPFACCNO"), Label).Text
            TxtSRDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSalaryRevDate"), Label).Text
            txtmiddle.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblmiddlename"), Label).Text
            txtInt.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblInitial"), Label).Text
            'ddlState.Items.Clear()
            'ddlState.DataSourceID = "ObjState"
            'ddlState.DataBind()
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("LblDOP"), Label).Text = "01-Jan-3000" Then
                txtDop.Text = ""
            End If

            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSalaryRevDate"), Label).Text = "01-Jan-9100" Then
                TxtSRDate.Text = ""
            End If
            x = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSalaryRevDate"), Label).Text
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSalaryRevDate"), Label).Text = "01-Jan-2999" Then
                TxtSRDate.Text = ""
            End If
            ddlState.Items.Clear()
            ddlState.DataSourceID = "ObjState"
            ddlState.DataBind()
            ddlState.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblStateName"), Label).Text
            x = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblDistric"), Label).Text
            ddlDistric.Items.Clear()
            ddlDistric.DataSourceID = "ObjDistric"
            ddlDistric.DataBind()

            ddlDistric.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblDistric"), Label).Text

            If CType(GridView1.Rows(e.NewEditIndex).FindControl("ChkStopSalary"), Label).Text = "Y" Then
                ChkStopSalary.Checked = True
            Else
                ChkStopSalary.Checked = False
            End If

            x = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStopsalaryReason"), Label).Text

            txtStopSalaryReason.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStopsalaryReason"), Label).Text
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStopSalaryDate"), Label).Text = "01-Jan-2999" Then
                txtsalarystop.Text = ""
            Else
                txtsalarystop.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStopSalaryDate"), Label).Text
            End If

            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblChkGratuity"), Label).Text = "Y" Then
                ChkGratutity.Checked = True
            Else
                ChkGratutity.Checked = False
            End If
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblChkIncrement"), Label).Text = "Y" Then
                ChkIncrement.Checked = True
            Else
                ChkIncrement.Checked = False
            End If
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblChkPension"), Label).Text = "Y" Then
                ChkPension.Checked = True
            Else
                ChkPension.Checked = False
            End If
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblChkPromotion"), Label).Text = "Y" Then
                ChkPromotion.Checked = True
            Else
                ChkPromotion.Checked = False
            End If
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblChkResignation"), Label).Text = "Y" Then
                ChkResignation.Checked = True
            Else
                ChkResignation.Checked = False
            End If
            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblChkUniform"), Label).Text = "Y" Then
                ChkUniform.Checked = True
            Else
                ChkUniform.Checked = False
            End If

            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblChkSettelement"), Label).Text = "Y" Then
                ChkSttlmnt.Checked = True
            Else
                ChkSttlmnt.Checked = False
            End If

            If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblChkPensionable"), Label).Text = "Y" Then
                chkPensionable.Checked = True
            Else
                chkPensionable.Checked = False
            End If


            indmaster.Emp_Id = ViewState("Emp_Id")
            indmaster.Designation = "0"
            indmaster.Emp_Name = 0
            indmaster.EmpCode = 0
            indmaster.EmpCategory = txtEmpCategory.Text
            indmaster.EmploymentType = ddlEmpType.SelectedValue
            indmaster.BranchTypeCode = 0
            indmaster.PassportNo = 0
            indmaster.ContactNo = 0
            indmaster.LandlineNo = 0
            indmaster.Email = 0
            indmaster.Qualification = 0
            indmaster.Sex = ddlSex.SelectedValue
            indmaster.Country = ddlCountry.SelectedValue
            indmaster.DOB = "1/1/2999"
            indmaster.DOL = "1/1/3100"
            indmaster.DOJ = "1/1/3000"
            indmaster.DOR = "1/1/3100"
            indmaster.DOA = "1/1/3100"
            indmaster.DeptID = ddlDept.SelectedValue
            indmaster.NICNO = txtNicNo.Text
            If Check <> 2 Then
                dt = individual.GetIndividualFormMaster(indmaster)
            Else
                dt = individual.GetENPLOYEEDetails(indmaster)
            End If

            GridView1.DataSource = dt
            GridView1.DataBind()

            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("LabelDOB"), Label).Text = "01-Jan-2999" Then
                    CType(rows.FindControl("LabelDOB"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOJ"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("LabelDOJ"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOL"), Label).Text = "01-Jan-3100" Then
                    CType(rows.FindControl("LabelDOL"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOR"), Label).Text = "01-Jan-3100" Then
                    CType(rows.FindControl("LabelDOR"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOA"), Label).Text = "01-Jan-3100" Then
                    CType(rows.FindControl("LabelDOA"), Label).Text = ""
                End If
            Next
            GridView1.Enabled = False
            GridView1.Visible = True
        Else
            lblmsg.Text = ValidationMessage(1134)
            lblgreen.Text = ValidationMessage(1014)
        End If
        'Else
        'lblmsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblgreen.Text = ""
        'End If
    End Sub
    Sub clear()

        DDLEmployeeName1.SelectedValue = 0
        DDLEmployeeName.SelectedValue = 0
        txtEmpCategory.Text = ""
        txtStopSalaryReason.Text = ""
        txtEmpName.Text = ""
        txtEmpcode.Text = ""
        txtAddress.Text = ""
        'txtCountry.Text = ""
        txtContactNo.Text = ""
        txtLandlineNo.Text = ""
        txtEmail.Text = ""
        txtDOB.Text = ""
        txtDOJ.Text = ""
        txtDOL.Text = ""
        txtDOA.Text = ""
        txtretirement.Text = ""
        txtAccountNo.Text = ""
        txtSalary.Text = ""
        txtAcctBranch.Text = ""
        lblmsg.Text = ""
        txtPath.Text = ""
        txtDelegated.Text = ""
        txtServicePeriod.Text = ""
        txtPanNo.Text = ""
        CheckBox1.Checked = False
        Image2.ImageUrl = "~\Images\imageupload.gif"
        CheckBox1.Checked = False
        txtDelegated.Enabled = False
        HidBankId.Value = 0
        HidEmpCode.Value = 0
        txtHRAEmp.Text = ""
        HidHRAEmp.Value = 0
        txtFMEmpCode.Text = ""
        HidFMEmpCode.Value = 0
        txtRMEmpCode.Text = ""
        HidRMEmpCode.Value = 0
        txtqualification.Text = ""
        'ViewState("ImageTime") = ""
        txtNicNo.Text = ""
        txtCaddr.Text = ""
        ChkHostel.Checked = False
        ChkTransport.Checked = False
        txtFname.Text = ""
        txtSpouseName.Text = ""
        txtNameinpassport.Text = ""
        txtPlaceofIssue.Text = ""
        txtPassportNo.Text = ""
        txtExpiryDate.Text = ""
        txtPassportIssueDate.Text = ""
        txtVisaIssueDate.Text = ""
        txtVisaExpDate.Text = ""
        txtVisaNo.Text = ""
        txtFRRO.Text = ""
        txtMothername.Text = ""
        txtPFNo.Text = ""
        'txtCountry.Text = ""
        txtESINo.Text = ""
        txtVDA.Text = ""
        txtNationality.Text = ""
        txtReligion.Text = ""
        txtCivilStates.Text = ""
        txtEthnicity.SelectedValue = 0
        txtOthername.Text = ""
        txtInt.Text = ""
        txtPFileNo.Text = ""
        txtDop.Text = ""
        'indmaster.DOP = txtDop.Text
        txtNomi.Text = ""
        txtrace.Text = ""
        txtEtf.Text = ""
        'txtdistrict.Text = ""
        txtCity.Text = ""
        ddlState.SelectedValue = 0
        txtPC.Text = ""
        txtPFAcctNo.Text = ""
        TxtSRDate.Text = ""
        ChkGratutity.Checked = False
        ChkIncrement.Checked = False
        ChkPension.Checked = False
        ChkPromotion.Checked = False
        ChkResignation.Checked = False
        ChkUniform.Checked = False
        ChkSttlmnt.Checked = False
        chkPensionable.Checked = False
        ChkStopSalary.Checked = False
        txtmiddle.Text = ""
        txtsalarystop.Text = ""

    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim Check As Integer = Request.QueryString.Get("check")
        If Check = 2 Then
            lblmsg.Text = "You do not have permission to delete"
            lblgreen.Text = ""
            Exit Sub
        End If


        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Dim Photo As String = Session("Path") + CType(GridView1.Rows(e.RowIndex).FindControl("LabelEmp_Photo"), Image).ImageUrl.Replace("~/", "")
                If IO.File.Exists(Photo) Then
                    IO.File.Delete(Photo)
                End If
                individual.Delete(CType(GridView1.Rows(e.RowIndex).FindControl("LabelEmp_Id"), HiddenField).Value)
                GridView1.PageIndex = ViewState("PageIndex")
                DispGrid()
                lblmsg.Text = ValidationMessage(1014)
                lblgreen.Text = ValidationMessage(1028)
                txtEmpcode.Focus()
            Else
                lblmsg.Text = ValidationMessage(1029)
                lblgreen.Text = ValidationMessage(1014)
            End If
        Else
            lblmsg.Text = ValidationMessage(1029)
            lblgreen.Text = ValidationMessage(1014)
        End If

    End Sub
    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Dim Check As Integer = Request.QueryString.Get("check")
        If Check = 2 Then



            DisplayEmpDetails()
            If BtnView.Text = "BACK" Then
                DisplayEmpDetails()
                BtnView.Text = "VIEW"
            End If
            lblmsg.Text = ValidationMessage(1014)
            lblgreen.Text = ValidationMessage(1014)
            Exit Sub
        End If


        lblmsg.Text = ValidationMessage(1014)
        lblgreen.Text = ValidationMessage(1014)
        If BtnView.Text = "BACK" Then
            lblmsg.Text = ValidationMessage(1014)
            lblgreen.Text = ValidationMessage(1014)

            Btnadd.CommandName = "ADD"
            BtnView.CommandName = "VIEW"
            Btnadd.Text = "ADD"
            BtnView.Text = "VIEW"

            clear()
            GridView1.PageIndex = ViewState("PageIndex")
            txtEmpcode.Enabled = True
            indmaster.Designation = "0"
            indmaster.Emp_Name = 0
            indmaster.EmpCode = "*"
            indmaster.EmpCategory = ""
            indmaster.EmploymentType = 0
            indmaster.BranchTypeCode = 0
            indmaster.PassportNo = 0
            indmaster.ContactNo = 0
            indmaster.LandlineNo = 0
            indmaster.Email = 0
            indmaster.Qualification = 0
            indmaster.Sex = 0
            indmaster.Country = 0
            indmaster.DOB = "1/1/2999"
            indmaster.DOL = "1/1/3100"
            indmaster.DOJ = "1/1/3000"
            indmaster.DOR = "1/1/3000"
            indmaster.DOA = "1/1/3000"
            indmaster.DeptID = 0
            indmaster.NICNO = ""
            dt = individual.GetIndividualFormMaster(indmaster)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()

                GridView1.Enabled = True
                GridView1.Visible = True
                For Each rows As GridViewRow In GridView1.Rows
                    If CType(rows.FindControl("LabelDOB"), Label).Text = "01-Jan-2999" Then
                        CType(rows.FindControl("LabelDOB"), Label).Text = ""
                    End If
                    If CType(rows.FindControl("LabelDOJ"), Label).Text = "01-Jan-3000" Then
                        CType(rows.FindControl("LabelDOJ"), Label).Text = ""
                    End If
                    If CType(rows.FindControl("LabelDOL"), Label).Text = "01-Jan-3100" Then
                        CType(rows.FindControl("LabelDOL"), Label).Text = ""
                    End If
                    If CType(rows.FindControl("LabelDOR"), Label).Text = "01-Jan-3100" Then
                        CType(rows.FindControl("LabelDOR"), Label).Text = ""
                    End If
                    If CType(rows.FindControl("LabelDOA"), Label).Text = "01-Jan-3100" Then
                        CType(rows.FindControl("LabelDOA"), Label).Text = ""
                    End If
                Next
                'LinkButton.Focus()
            Else
                lblgreen.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1023)
                GridView1.Visible = False
            End If
        Else
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DispGrid()
        End If
    End Sub
    Sub DisplayEmpDetails()
        indmaster.Emp_Id = ViewState("Emp_Id")
        dt = individual.GetENPLOYEEDetails(indmaster)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            Dim Check As Integer = Request.QueryString.Get("check")
            

            GridView1.Enabled = True
            GridView1.Visible = True
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("LabelDOB"), Label).Text = "01-Jan-2999" Then
                    CType(rows.FindControl("LabelDOB"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOJ"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("LabelDOJ"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOL"), Label).Text = "01-Jan-3100" Then
                    CType(rows.FindControl("LabelDOL"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOR"), Label).Text = "01-Jan-3100" Then
                    CType(rows.FindControl("LabelDOR"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOA"), Label).Text = "01-Jan-3100" Then
                    CType(rows.FindControl("LabelDOA"), Label).Text = ""
                End If
            Next

            'LinkButton.Focus()
        Else
            lblgreen.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1023)
            GridView1.Visible = False
        End If
    End Sub
    Sub DispGrid()

        If txtEmpName.Text = "" Then
            indmaster.Emp_Name = 0
        Else
            indmaster.Emp_Name = txtEmpName.Text
        End If
        If txtEmpcode.Text = "" Then
            indmaster.EmpCode = "*"
        Else
            indmaster.EmpCode = txtEmpcode.Text
        End If
        If ddldesignation.SelectedValue = "" Then
            indmaster.Designation = 0
        Else
            indmaster.Designation = ddldesignation.SelectedValue
        End If
        'If DDLDeptType.SelectedValue = "Select" Then
        '    indmaster.BranchTypeCode = "0"
        'Else
        '    indmaster.BranchTypeCode = DDLDeptType.SelectedValue
        'End If
        indmaster.Designation = ddldesignation.SelectedValue
        indmaster.Emp_Id = 0
        indmaster.EmpCategory = txtEmpCategory.Text
        indmaster.EmploymentType = ddlEmpType.SelectedValue
        indmaster.NICNO = txtNicNo.Text

        If txtDOB.Text = "" Then
            indmaster.DOB = "1/1/2999"
        Else
            indmaster.DOB = txtDOB.Text
        End If
        If txtDOJ.Text = "" Then
            indmaster.DOJ = "1/1/3000"
        Else
            indmaster.DOJ = txtDOJ.Text
        End If
        If txtretirement.Text = "" Then
            indmaster.DOR = "1/1/3100"
        Else
            indmaster.DOR = txtretirement.Text
        End If
        If txtDOA.Text = "" Then
            indmaster.DOA = "1/1/3000"
        Else
            indmaster.DOA = txtDOA.Text
        End If
        indmaster.DeptID = ddlDept.SelectedValue
        If txtContactNo.Text = "" Then
            indmaster.ContactNo = 0
        Else
            indmaster.ContactNo = txtContactNo.Text
        End If
        If txtLandlineNo.Text = "" Then
            indmaster.LandlineNo = 0
        Else
            indmaster.LandlineNo = txtLandlineNo.Text
        End If
        If txtEmail.Text = "" Then
            indmaster.Email = 0
        Else
            indmaster.Email = txtEmail.Text
        End If
        If txtqualification.Text = "" Then
            indmaster.Qualification = 0
        Else
            indmaster.Qualification = txtqualification.Text
        End If

        If ddlSex.SelectedValue = "Select" Then
            indmaster.Sex = "0"
        Else
            indmaster.Sex = ddlSex.SelectedValue
        End If

        If ddlCountry.SelectedValue = "Select" Then
            indmaster.Country = "0"
        Else
            indmaster.Country = ddlCountry.SelectedValue
        End If

        If txtDOL.Text = "" Then
            indmaster.DOL = "1/1/3100"
        Else
            indmaster.DOL = txtDOL.Text
        End If
        If txtPassportNo.Text = "" Then
            indmaster.PassportNo = 0
        Else
            indmaster.PassportNo = txtPassportNo.Text
        End If

        dt = individual.GetIndividualFormMaster(indmaster)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("LabelDOB"), Label).Text = "01-Jan-2999" Then
                    CType(rows.FindControl("LabelDOB"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOJ"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("LabelDOJ"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOL"), Label).Text = "01-Jan-3100" Then
                    CType(rows.FindControl("LabelDOL"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOR"), Label).Text = "01-Jan-3100" Then
                    CType(rows.FindControl("LabelDOR"), Label).Text = ""
                End If
                If CType(rows.FindControl("LabelDOA"), Label).Text = "01-Jan-3100" Then
                    CType(rows.FindControl("LabelDOA"), Label).Text = ""
                End If
            Next

            'LinkButton.Focus()
        Else
            lblgreen.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1023)
            GridView1.Visible = False
        End If
    End Sub
    Sub SplitBank(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("Bank") = parts(0).ToString()
            HidBankId.Value = parts(0).ToString()
            txtAcctBranch.Text = parts(1).ToString()

        Else
            txtAcctBranch.AutoPostBack = True
        End If
    End Sub
    Sub SplitName2(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            txtDelegated.Text = parts(0).ToString()
            txtDelegated.Text = parts(1).ToString()
            HidEmpCode.Value = parts(2).ToString()
            'ViewState("EmpID") = EmpID
        Else
            txtDelegated.AutoPostBack = True
        End If
    End Sub
    Sub SplitName3(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            txtRMEmpCode.Text = parts(0).ToString()
            txtRMEmpCode.Text = parts(1).ToString()
            HidRMEmpCode.Value = parts(2).ToString()
            'ViewState("EmpID") = EmpID
        Else
            txtRMEmpCode.AutoPostBack = True
        End If
    End Sub
    Sub SplitName4(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            txtFMEmpCode.Text = parts(0).ToString()
            txtFMEmpCode.Text = parts(1).ToString()
            HidFMEmpCode.Value = parts(2).ToString()
            'ViewState("EmpID") = EmpID
        Else
            txtFMEmpCode.AutoPostBack = True
        End If
    End Sub
    Sub SplitName5(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            txtHRAEmp.Text = parts(0).ToString()
            txtHRAEmp.Text = parts(1).ToString()
            HidHRAEmp.Value = parts(2).ToString()
            'ViewState("EmpID") = EmpID
        Else
            txtHRAEmp.AutoPostBack = True
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim min As Integer = 1900
        Dim max As Integer = DateTime.Now.Year - 1
        'RangeValidatorYear.MinimumValue = min.ToString()
        'RangeValidatorYear.MaximumValue = max.ToString()
        'RangeValidatorYear.ErrorMessage = String.Format("Enter Value Between {0} and {1}", min, max)
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading

        TextBox4.Text = Session("FilePath")


        If Session("EmpId") = "" Then
            Dim Check As Integer = Request.QueryString.Get("check")
            If Check = 2 Then
                employeemasterpage2()
                lblmsg.Text = "Not Accessible for Institute Admin."
                Exit Sub
            Else
                employeemasterpage()
            End If
        Else
            Dim Check As Integer = Request.QueryString.Get("check")
            If Check = 2 Then
                If Check = 2 Then
                    employeemasterpage()
                End If
            End If
        End If
        UpdatePanel2.Visible = True
        If Not Page.IsPostBack Then
            TextBox4.Text = ""
            Session("FilePath") = ""
            txtFromDt.Text = Format(Today, "dd-MMM-yyyy")
            txtToDate.Text = Format(Today, "dd-MMM-yyyy")

            'txtDOJ.Text = Format(Today, "dd-MMM-yyyy")
            ViewState("txtExperience") = txtExperience.Text
            txtEmpcode.Focus()
            ViewState("ImageTime") = ""
        End If
        If Image2.ImageUrl = "" Then
            Image2.ImageUrl = "~\Images\imageupload.gif"
        End If
        If txtAcctBranch.Text <> "" Then
            SplitBank(txtAcctBranch.Text)
        Else
            txtAcctBranch.AutoPostBack = True
            'txtBookName.Text = ""
            SplitBank(txtAcctBranch.Text)
        End If
        If txtDelegated.Text <> "" Then
            SplitName2(txtDelegated.Text)
        Else
            txtDelegated.AutoPostBack = True
            'txtStdName.Text = ""
            SplitName2(txtDelegated.Text)
        End If
        If txtRMEmpCode.Text <> "" Then
            SplitName3(txtRMEmpCode.Text)
        Else
            txtRMEmpCode.AutoPostBack = True
            'txtEmpName.Text = ""
            SplitName3(txtRMEmpCode.Text)
        End If
        If txtFMEmpCode.Text <> "" Then
            SplitName4(txtFMEmpCode.Text)
        Else
            txtFMEmpCode.AutoPostBack = True
            'txtEmpName.Text = ""
            SplitName4(txtFMEmpCode.Text)
        End If
        If txtHRAEmp.Text <> "" Then
            SplitName5(txtHRAEmp.Text)
        Else
            txtHRAEmp.AutoPostBack = True
            'txtEmpName.Text = ""
            SplitName5(txtHRAEmp.Text)
        End If
        'If Not IsPostBack Then
        '    Ddldpt.SelectedValue = Session("BranchCode")
        'End If

    End Sub
    Protected Sub Upload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Upload.Click
        '25-11-2010 Kusum.C.Akki upload image to image after browsing the image
        lblmsg.Text = ValidationMessage(1014)
        lblgreen.Text = ValidationMessage(1014)
        If FileUpload1.FileName <> "" Then
            If FileUpload1.PostedFile.ContentLength <= 30000 Then
                Try
                    If ViewState("ImageTime") <> Nothing Then
                        'Dim Foto As String = Replace(ViewState("ImageTime"), "~/", "")
                        Dim Foto As String = Session("Path") + ViewState("ImageTime").ToString.Replace("~/", "")
                        If IO.File.Exists(Foto) Then
                            IO.File.Delete(Foto)
                        End If
                    End If
                    lblmsg.Text = ValidationMessage(1014)
                    lblgreen.Text = ValidationMessage(1014)
                    path = "E" & txtEmpcode.Text.Trim.ToString().Replace(" ", "") + TimeOfDay.ToString().Replace("/", "").Replace(":", "") & ".jpg"
                    If (FileUpload1.PostedFile.ContentType.ToLower() = "image/gif" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/jpeg" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/tiff" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/pjpeg" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/x-png" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/jpg" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/tif" Or FileUpload1.PostedFile.ContentType.ToLower() = "image/bmp") Then


                        'path = (Server.MapPath("Images/") + Convert.ToString(Guid.NewGuid()) + FileUpload1.FileName)
                        'FileUpload1.SaveAs(path)

                        Me.FileUpload1.SaveAs(Server.MapPath("~/Images/" & path))
                        path1 = "~/Images/" & path
                        ViewState("ImageTime") = "~/Images/" & path
                        txtPath.Text = path1
                        Me.Image2.ImageUrl = txtPath.Text
                    Else
                        lblmsg.Text = "Photo format should be gif/jpeg/jpg/pjpeg/bmp/x-png/tif/tiff ."
                    End If
                Catch ex As Exception
                    lblgreen.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1135)
                End Try
            Else
                lblmsg.Text = ValidationMessage(1120)
                lblgreen.Text = ValidationMessage(1014)
            End If
        Else
            lblmsg.Text = ValidationMessage(1121)
            lblgreen.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        lblmsg.Text = ValidationMessage(1014)
        lblgreen.Text = ValidationMessage(1014)
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DispGrid()
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtEmpName.Text <> "" Or txtEmpcode.Text <> "" Or ddlSex.SelectedValue <> "Select" Or ddldesignation.SelectedValue <> "Select" Then
            ViewState("Search") = "Search"
            Search()
            Dim DL As New DLIndividualFormMaster
            dt = DL.GetSearchDetails(indmaster)
            If dt.Rows.Count = 0 Then
                lblgreen.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1136)
                txtEmpcode.Focus()
                GridView1.Visible = False
            Else
                lblgreen.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                GridView1.DataSource = dt
                GridView1.DataBind()
                For Each rows As GridViewRow In GridView1.Rows
                    If CType(rows.FindControl("LabelDOB"), Label).Text = "01-Jan-2999" Then
                        CType(rows.FindControl("LabelDOB"), Label).Text = ""
                    ElseIf CType(rows.FindControl("LabelDOJ"), Label).Text = "01-Jan-3000" Then
                        CType(rows.FindControl("LabelDOJ"), Label).Text = ""
                    ElseIf CType(rows.FindControl("LabelDOL"), Label).Text = "01-Jan-3100" Then
                        CType(rows.FindControl("LabelDOL"), Label).Text = ""
                    End If
                Next
                GridView1.Visible = True
            End If
        Else
            lblmsg.Text = ValidationMessage(1137)
            txtEmpcode.Focus()
            lblgreen.Text = ValidationMessage(1014)
        End If
        'Else
        'lblmsg.Text = "No Read Permission!"
        'End If
    End Sub
    Sub Search()
        If txtEmpName.Text <> "" Then
            indmaster.Emp_Name = txtEmpName.Text
        End If
        If txtEmpcode.Text <> "" Then
            indmaster.EmpCode = txtEmpcode.Text
        End If
        If ddlSex.SelectedValue <> "Select" Then
            indmaster.Sex = ddlSex.SelectedValue
        Else
            indmaster.Sex = "Select"
        End If
        If ddldesignation.Text <> "Select" Then
            indmaster.Designation = ddldesignation.Text
        Else
            indmaster.Designation = "Select"
        End If
        'If DDLDeptType.SelectedValue <> "Select" Then
        '    indmaster.BranchTypeCode = DDLDeptType.SelectedValue
        'Else
        '    indmaster.BranchTypeCode = "Select"
        'End If
        If txtAddress.Text <> "" Then
            indmaster.Emp_Address = txtAddress.Text
        End If
        If txtDOB.Text <> "" Then
            indmaster.DOB = txtDOB.Text
        End If
        If txtDOJ.Text <> "" Then
            indmaster.DOJ = txtDOJ.Text
        End If
        If txtAccountNo.Text <> "" Then
            indmaster.AccountNo = txtAccountNo.Text
        End If
    End Sub

    'Protected Sub DDLDeptType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLDeptType.TextChanged
    '    DDLDeptType.Focus()
    'End Sub

    Protected Sub ddldesignation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddldesignation.TextChanged
        ddldesignation.Focus()
    End Sub

    Protected Sub Ddldpt_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ddldpt.SelectedIndexChanged
        Ddldpt.Focus()
    End Sub

    Protected Sub Ddldpt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ddldpt.TextChanged
        Ddldpt.Focus()
    End Sub

    Protected Sub ddlSex_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSex.TextChanged
        ddlSex.Focus()
    End Sub

    Protected Sub CheckBox1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            txtDelegated.Enabled = True
            txtDelegated.Focus()
        Else
            txtDelegated.Enabled = False
            txtNameinpassport.Focus()
            txtDelegated.Text = ""
            HidEmpCode.Value = 0
        End If
    End Sub
    'Qualification form by kusum on 25-Mar-2013

    Protected Sub btnQualificationAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQualificationAdd.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim DL As New DLEmpQualification
                If btnQualificationAdd.CommandName = "ADD4" Then
                    el.EmployeeName = DDLEmployeeName.SelectedValue
                    el.PKID = 0
                    el.Qualification = txtQualificationf.Text
                    el.QualificationType = DDLQualificationType.Text
                    el.Remarks = txtQualificationRemarks.Text
                    el.Year = ddlYear.SelectedItem.Text
                    el.UniversityQual = txtUniv.Text
                    el.SubjectQual = txtSubj.Text
                    el.CountryQual = ddlcountryQual.SelectedValue

                    If DL.InsertQualification(el) > 0 Then
                        Display()
                        lblQRed.Text = ValidationMessage(1014)
                        lblQGreen.Text = ValidationMessage(1020)
                        QClear()
                        Dim date1 As String
                        date1 = Session("CurrentYear")
                        Dim dt As DataTable
                        dt = QualificationDB.GetYear(date1)
                        Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
                        ddlYear.SelectedValue = value
                    Else
                        lblQRed.Text = ValidationMessage(1022)
                        lblQGreen.Text = ValidationMessage(1014)
                    End If
                Else
                    el.EmployeeName = DDLEmployeeName.SelectedValue
                    el.PKID = HiddenField1.Value
                    el.Qualification = txtQualificationf.Text
                    el.QualificationType = DDLQualificationType.Text
                    el.Remarks = txtQualificationRemarks.Text
                    el.Year = ddlYear.SelectedItem.Text
                    el.UniversityQual = txtUniv.Text
                    el.SubjectQual = txtSubj.Text
                    el.CountryQual = ddlcountryQual.SelectedValue
                    If DL.InsertQualification(el) > 0 Then
                        Display()
                        lblQRed.Text = ValidationMessage(1014)
                        lblQGreen.Text = ValidationMessage(1017)
                        Dim Check As Integer = Request.QueryString.Get("check")
                        If Check = 2 Then
                            btnQualificationAdd.Text = "ADD"
                            btnQualificationView.Text = "VIEW"
                        End If
                        btnQualificationAdd.CommandName = "ADD4"
                        btnQualificationView.CommandName = "VIEW4"
                        btnQualificationAdd.Text = "ADD"
                        btnQualificationView.Text = "VIEW"

                        
                        QClear()
                        Dim date1 As String
                        date1 = Session("CurrentYear")
                        Dim dt As DataTable
                        dt = QualificationDB.GetYear(date1)
                        Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
                        ddlYear.SelectedValue = value
                    Else
                        lblQRed.Text = ValidationMessage(1022)
                        lblQGreen.Text = ValidationMessage(1014)
                    End If
                End If
            Else
                lblQRed.Text = ValidationMessage(1021)
                lblQGreen.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            lblERed.Text = ValidationMessage(1055)
            lblEGreen.Text = ValidationMessage(1014)
        End Try
    End Sub
    Sub QClear()
        txtQualificationf.Text = ""
        txtQualificationRemarks.Text = ""
        'txtYear.Text = ""
    End Sub
    Sub Display()
        Dim dl As New DLEmpQualification
        Dim Check As Integer = Request.QueryString.Get("check")
        el.PKID = 0
        el.EmployeeName = DDLEmployeeName.SelectedValue
        dt = dl.GetEmpQualification(el)
        If dt.Rows.Count > 0 Then
            GVQualification.DataSource = dt
            GVQualification.DataBind()

            
            GVQualification.Enabled = True
            panel1.Visible = True
            GVQualification.Visible = True
        Else
            panel1.Visible = False
            GVQualification.Visible = False
            
            lblQRed.Text = ValidationMessage(1023)
            lblQGreen.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GVQualification_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVQualification.PageIndexChanging
        GVQualification.PageIndex = e.NewPageIndex
        ViewState("PageIndexQ") = GVQualification.PageIndex
        Display()
        GridView1.Visible = True
        lblQGreen.Text = ValidationMessage(1014)
        lblQRed.Text = ValidationMessage(1014)
    End Sub

    Protected Sub GVQualification_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVQualification.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            el.PKID = CType(GVQualification.Rows(e.RowIndex).FindControl("PKID"), Label).Text
            Dim DL As New DLEmpQualification
            DL.DeleteQualification(el)
            lblQRed.Text = ValidationMessage(1014)
            DDLEmployeeName.Focus()
            QClear()
            GVQualification.PageIndex = ViewState("PageIndexQ")
            Display()
            lblQGreen.Text = ValidationMessage(1028)
            lblQRed.Text = ValidationMessage(1014)
        Else
            lblQRed.Text = ValidationMessage(1029)
            lblQGreen.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GVQualification_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVQualification.RowEditing
        Dim Check As Integer = Request.QueryString.Get("check")
        If Check = 2 Then
            btnQualificationAdd.Text = "UPDATE"
            btnQualificationView.Text = "BACK"
        End If
        btnQualificationAdd.CommandName = "UPDATE"
        btnQualificationView.CommandName = "BACK"
        btnQualificationAdd.Text = "UPDATE"
        btnQualificationView.Text = "BACK"
        
        HiddenField1.Value = CType(GVQualification.Rows(e.NewEditIndex).FindControl("PKID"), Label).Text
        'DDLEmployeeName.SelectedValue = CType(GVQualification.Rows(e.NewEditIndex).FindControl("EmpID"), Label).Text
        DDLQualificationType.SelectedValue = CType(GVQualification.Rows(e.NewEditIndex).FindControl("QualificationTypeID"), Label).Text
        txtQualificationf.Text = CType(GVQualification.Rows(e.NewEditIndex).FindControl("Qualification"), Label).Text
        txtQualificationRemarks.Text = CType(GVQualification.Rows(e.NewEditIndex).FindControl("Remarks"), Label).Text
        txtUniv.Text = CType(GVQualification.Rows(e.NewEditIndex).FindControl("lblgvUniversityQual"), Label).Text
        txtSubj.Text = CType(GVQualification.Rows(e.NewEditIndex).FindControl("lblgvSubjQual"), Label).Text
        ddlcountryQual.SelectedValue = CType(GVQualification.Rows(e.NewEditIndex).FindControl("lblgvCountryQualID"), Label).Text

        'txtYear.Text = CType(GVQualification.Rows(e.NewEditIndex).FindControl("Year"), Label).Text
        Dim date1 As String
        date1 = CType(GVQualification.Rows(e.NewEditIndex).FindControl("Year"), Label).Text
        Dim dt As DataTable
        dt = QualificationDB.GetYear(date1)
        Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
        ddlYear.SelectedValue = value
        lblQRed.Text = ValidationMessage(1014)
        lblQGreen.Text = ValidationMessage(1014)
        Dim dl As New DLEmpQualification
        el.PKID = HiddenField1.Value
        el.EmployeeName = DDLEmployeeName.SelectedValue
        dt = dl.GetEmpQualification(el)
        GVQualification.DataSource = dt
        GVQualification.DataBind()
        
        panel1.Visible = True
        GVQualification.Enabled = False
        GVPublication.Visible = False
        GVExperience.Visible = False

        'btnQualificationAdd.CommandName = "UPDATE"
        'btnQualificationView.CommandName = "BACK"
    End Sub

    Protected Sub btnQualificationView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnQualificationView.Click
        Dim Check As Integer = Request.QueryString.Get("check")
        Dim dl As New DLEmpQualification
        el.PKID = 0
        lblQRed.Text = ValidationMessage(1014)
        lblQGreen.Text = ValidationMessage(1014)
        el.EmployeeName = DDLEmployeeName.SelectedValue
        dt = dl.GetEmpQualification(el)
        Dim date1 As String
        date1 = Session("CurrentYear")
        Dim dt1 As DataTable
        dt1 = QualificationDB.GetYear(date1)
        Dim value As Integer = dt1.Rows(0).Item("LookUpAutoID")
        ddlYear.SelectedValue = value
        If dt.Rows.Count > 0 Then
            'GVQualification.DataSource = dt
            'GVQualification.DataBind()
            Display()
            
            panel1.Visible = True
        Else
            lblQRed.Text = ValidationMessage(1023)
            lblQGreen.Text = ValidationMessage(1014)
            panel1.Visible = False
        End If
        If btnQualificationView.CommandName = "BACK" Then
            
            If Check = 2 Then
                btnQualificationAdd.Text = "ADD"
                btnQualificationView.Text = "VIEW"
            End If
            btnQualificationAdd.CommandName = "ADD4"
            btnQualificationView.CommandName = "VIEW4"
            btnQualificationAdd.Text = "ADD"
            btnQualificationView.Text = "VIEW"
            lblQRed.Text = ValidationMessage(1014)
            lblQGreen.Text = ValidationMessage(1014)
            txtQualificationf.Text = ""
            txtQualificationRemarks.Text = ""
        End If
        btnQualificationAdd.CommandName = "ADD4"
        btnQualificationView.CommandName = "VIEW4"
        
        GVQualification.Enabled = True
        GVQualification.Focus()
    End Sub
    'Experience form by kusum on 25-Mar-2013

    Protected Sub btnExperienceAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExperienceAdd.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim DL As New DLEmpQualification


                If btnExperienceAdd.CommandName = "ADD2" Then

                    'If Session("FilePath") <> "" And TextBox4.Text = "" Then
                    '    lblERed.Text = "Please Press Get Link Button"
                    '    TextBox4.Text = ""
                    '    Exit Sub
                    'ElseIf Session("FilePath") <> "" And TextBox4.Text <> "" Then


                    el.EmployeeName = DDLEmployeeName.SelectedValue
                    el.PKIDE = 0
                    el.Experience = txtExperience.Text
                    el.ExperienceType = DDLExperienceType.Text
                    If txtInstitute.Text = "" Then
                        lblERed.Text = "Univeristy/Institute Field is Mandatory."
                        lblEGreen.Text = ""
                        txtInstitute.Focus()
                        Exit Sub
                    Else
                        el.Institute = txtInstitute.Text
                        lblERed.Text = ""
                        lblEGreen.Text = ""
                    End If
                    el.Country = ddlCountryforExp.SelectedValue
                    el.Organization = TextBox3.Text
                    If txtFromDt.Text = "" Then
                        el.FromDate = Nothing
                    Else
                        el.FromDate = txtFromDt.Text
                    End If
                    If txtToDate.Text = "" Then
                        el.ToDate = Nothing
                    Else
                        el.ToDate = txtToDate.Text
                    End If
                    el.RemarksE = txtExperienceRemarks.Text

                    el.Year = ddlYear.SelectedItem.Text
                    el.Certificate = TextBox4.Text
                    If txtFromDt.Text <> "" And txtToDate.Text <> "" Then
                        If CDate(txtFromDt.Text) > CDate(txtToDate.Text) Then
                            lblERed.Text = ValidationMessage(1075)
                            lblEGreen.Text = ValidationMessage(1014)
                            Exit Sub
                        End If
                    End If

                    If DL.InsertExperience(el) > 0 Then
                        EQClear()
                        DisplayE()
                        lblERed.Text = ValidationMessage(1014)
                        lblEGreen.Text = ValidationMessage(1020)
                    Else
                        lblERed.Text = ValidationMessage(1022)
                        lblEGreen.Text = ValidationMessage(1014)
                    End If
                Else
                    el.EmployeeName = DDLEmployeeName.SelectedValue
                    el.PKIDE = txtid.Text
                    el.Experience = txtExperience.Text
                    el.ExperienceType = DDLExperienceType.Text
                    el.Certificate = TextBox4.Text
                    If txtInstitute.Text = "" Then
                        lblERed.Text = "Univeristy/Institute Field is Mandatory."
                        lblEGreen.Text = ""
                        txtInstitute.Focus()
                        Exit Sub
                    Else
                        el.Institute = txtInstitute.Text
                        lblERed.Text = ""
                        lblEGreen.Text = ""
                    End If
                    If txtFromDt.Text = "" Then
                        el.FromDate = Nothing
                    Else
                        el.FromDate = txtFromDt.Text
                    End If
                    If txtToDate.Text = "" Then
                        el.ToDate = Nothing
                    Else
                        el.ToDate = txtToDate.Text
                    End If
                    el.RemarksE = txtExperienceRemarks.Text
                    el.Year = ddlYear.SelectedItem.Text
                    el.Country = ddlCountryforExp.SelectedValue
                    el.Organization = TextBox3.Text
                    If txtFromDt.Text <> "" And txtToDate.Text <> "" Then
                        If CDate(txtFromDt.Text) > CDate(txtToDate.Text) Then
                            lblERed.Text = ValidationMessage(1075)
                            lblEGreen.Text = ValidationMessage(1014)
                            Exit Sub
                        End If
                    End If

                    If DL.InsertExperience(el) > 0 Then
                        EQClear()
                        DisplayE()
                        lblERed.Text = ValidationMessage(1014)
                        lblEGreen.Text = ValidationMessage(1017)
                        Dim Check As Integer = Request.QueryString.Get("check")
                        If Check = 2 Then
                            btnExperienceAdd.Text = "ADD"
                            btnExperienceView.Text = "VIEW"
                        End If
                        btnExperienceAdd.CommandName = "ADD2"
                        btnExperienceView.CommandName = "VIEW2"

                        
                    Else
                        lblERed.Text = ValidationMessage(1022)
                        lblEGreen.Text = ValidationMessage(1014)
                    End If
                End If
            Else
                lblERed.Text = ValidationMessage(1021)
                lblEGreen.Text = ValidationMessage(1014)
            End If
            'End If
        Catch ex As Exception
            lblERed.Text = ValidationMessage(1055)
            lblEGreen.Text = ValidationMessage(1014)
        End Try

    End Sub
    Sub EQClear()
        txtExperience.Text = ""
        txtExperienceRemarks.Text = ""
        txtFromDt.Text = ""
        txtToDate.Text = ""
        Session("FilePath") = ""
        Me.TextBox4.Text = ""

    End Sub
    Sub DisplayE()
        Dim dl As New DLEmpQualification
        Dim Check As Integer = Request.QueryString.Get("check")
        el.PKIDE = 0
        el.EmployeeName = DDLEmployeeName.SelectedValue
        dt = dl.GetEmpExperience(el)
        If dt.Rows.Count > 0 Then
            Dim i As Integer
            For Each row In dt.Rows
                If dt.Rows(i).Item("Country") = "0" Then
                    dt.Rows(i).Item("Country") = ""

                End If
                i = i + 1

            Next
            GVExperience.DataSource = dt
            GVExperience.DataBind()
            
            GVExperience.Enabled = True
            GVExperience.Visible = True
            PExp.Visible = True
            GVExperience.Visible = True
        Else
            GVExperience.Visible = False
            
            lblERed.Text = ValidationMessage(1023)
            lblEGreen.Text = ValidationMessage(1014)
            PExp.Visible = False
        End If
    End Sub

    Protected Sub GVExperience_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVExperience.PageIndexChanging
        GVExperience.PageIndex = e.NewPageIndex
        ViewState("PageIndexE") = GVExperience.PageIndex
        DisplayE()
        GridView1.Visible = True
        lblEGreen.Text = ValidationMessage(1014)
        lblERed.Text = ValidationMessage(1014)
    End Sub

    Protected Sub GVExperience_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVExperience.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            el.PKIDE = CType(GVExperience.Rows(e.RowIndex).FindControl("PKID"), Label).Text
            Dim DL As New DLEmpQualification
            DL.DeleteExperience(el)
            lblERed.Text = ValidationMessage(1014)
            DDLEmployeeName.Focus()
            EQClear()
            GVExperience.PageIndex = ViewState("PageIndexE")
            DisplayE()
            lblEGreen.Text = ValidationMessage(1028)
            lblERed.Text = ValidationMessage(1014)
        Else
            lblERed.Text = ValidationMessage(1029)
            lblEGreen.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GVExperience_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVExperience.RowEditing
        txtid.Text = CType(GVExperience.Rows(e.NewEditIndex).FindControl("PKID"), Label).Text
        'DDLEmployeeName.SelectedValue = CType(GVExperience.Rows(e.NewEditIndex).FindControl("EmpID"), Label).Text
        DDLExperienceType.SelectedValue = CType(GVExperience.Rows(e.NewEditIndex).FindControl("ExperienceTypeID"), Label).Text
        txtExperience.Text = CType(GVExperience.Rows(e.NewEditIndex).FindControl("Experience"), Label).Text
        txtInstitute.Text = CType(GVExperience.Rows(e.NewEditIndex).FindControl("Institute"), Label).Text
        'Dim ax As Integer = CType(GVExperience.Rows(e.NewEditIndex).FindControl("CountryIdforExp"), Label).Text
        ddlCountryforExp.Items.Clear()
        ddlCountryforExp.DataSourceID = "ObjCountryforExp"
        ddlCountryforExp.DataBind()
        ddlCountryforExp.SelectedValue = CType(GVExperience.Rows(e.NewEditIndex).FindControl("CountryIdforExp"), Label).Text
        txtExperienceRemarks.Text = CType(GVExperience.Rows(e.NewEditIndex).FindControl("Remarks"), Label).Text
        TextBox4.Text = CType(GVExperience.Rows(e.NewEditIndex).FindControl("Certificate"), Label).Text
        txtFromDt.Text = CType(GVExperience.Rows(e.NewEditIndex).FindControl("FromDate"), Label).Text
        txtToDate.Text = CType(GVExperience.Rows(e.NewEditIndex).FindControl("ToDate"), Label).Text
        lblERed.Text = ValidationMessage(1014)
        lblEGreen.Text = ValidationMessage(1014)
        Dim dl As New DLEmpQualification
        el.PKID = txtid.Text
        el.EmployeeName = DDLEmployeeName.SelectedValue
        dt = dl.GetEmpExperience(el)
        Dim i As Integer
        For Each row In dt.Rows
            If dt.Rows(i).Item("Country") = "0" Then
                dt.Rows(i).Item("Country") = ""

            End If
            i = i + 1

        Next
        GVExperience.DataSource = dt
        GVExperience.DataBind()
        Dim Check As Integer = Request.QueryString.Get("check")
        
        PExp.Visible = True
        GVExperience.Enabled = False
        GVPublication.Visible = False
        GVQualification.Visible = False

        If Check = 2 Then
            btnExperienceAdd.Text = "UPDATE"
            btnExperienceView.Text = "BACK"
        End If

        btnExperienceAdd.CommandName = "UPDATE"
        btnExperienceView.CommandName = "BACK"
        btnExperienceAdd.Text = "UPDATE"
        btnExperienceView.Text = "BACK"
        
    End Sub

    Protected Sub btnExperienceView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExperienceView.Click
        Dim dl As New DLEmpQualification
        Dim Check As Integer = Request.QueryString.Get("check")
        el.PKID = 0
        lblERed.Text = ValidationMessage(1014)
        lblEGreen.Text = ValidationMessage(1014)
        el.EmployeeName = DDLEmployeeName.SelectedValue
        dt = dl.GetEmpExperience(el)
        If dt.Rows.Count > 0 Then
            DisplayE()

          
            PExp.Visible = True
        Else
            lblERed.Text = ValidationMessage(1023)
            lblEGreen.Text = ValidationMessage(1014)
            PExp.Visible = False
        End If
        If btnExperienceView.CommandName = "BACK" Then
            EQClear()
        End If
        If Check = 2 Then
            btnExperienceAdd.Text = "ADD"
            btnExperienceView.Text = "VIEW"
        End If
        btnExperienceAdd.CommandName = "ADD2"
        btnExperienceView.CommandName = "VIEW2"
        btnExperienceAdd.Text = "ADD"
        btnExperienceView.Text = "VIEW"
       
        GVExperience.Enabled = True
        GVExperience.Focus()
    End Sub

    Protected Sub DDLEmployeeName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLEmployeeName.SelectedIndexChanged
        panel1.Visible = False
        PExp.Visible = False
        PnlP.Visible = False
        'EQClear()
        'QClear()
        lblQRed.Text = ValidationMessage(1014)
        lblQGreen.Text = ValidationMessage(1014)
        lblERed.Text = ValidationMessage(1014)
        lblEGreen.Text = ValidationMessage(1014)
        lblPRed.Text = ValidationMessage(1014)
        lblPGreen.Text = ValidationMessage(1014)
    End Sub

    'Publication form by kusum on 25-Mar-2013

    Protected Sub btnPublicationAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPublicationAdd.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim DL As New DLEmpQualification
                If btnPublicationAdd.CommandName = "ADD3" Then
                    el.EmployeeName = DDLEmployeeName.SelectedValue
                    el.PKIDP = 0
                    el.PublicationTitle = txtTitle.Text
                    el.Publisher = txtName.Text
                    el.Typeofpublish = txttype.Text
                    el.CountryPublish = DropDownList1.SelectedValue
                    el.Author = txtauthor.Text
                    If txtPYear.Text = "" Then
                        el.YearOfPublishing = Nothing
                    Else
                        el.YearOfPublishing = txtPYear.Text
                    End If
                    el.RemarksP = txtPublicationRemarks.Text

                    If DL.InsertPublication(el) > 0 Then
                        PClear()
                        DisplayP()
                        lblPRed.Text = ValidationMessage(1014)
                        lblPGreen.Text = ValidationMessage(1020)
                    Else
                        lblPRed.Text = ValidationMessage(1022)
                        lblPGreen.Text = ValidationMessage(1014)
                    End If
                Else
                    el.EmployeeName = DDLEmployeeName.SelectedValue
                    el.PKIDP = txtPID.Text
                    el.PublicationTitle = txtTitle.Text
                    el.Publisher = txtName.Text
                    el.CountryPublish = DropDownList1.SelectedValue
                    el.Author = txtauthor.Text
                    el.Typeofpublish = txttype.Text
                    If txtPYear.Text = "" Then
                        el.YearOfPublishing = Nothing
                    Else
                        el.YearOfPublishing = txtPYear.Text
                    End If
                    el.RemarksP = txtPublicationRemarks.Text

                    If DL.InsertPublication(el) > 0 Then
                        PClear()
                        DisplayP()
                        lblPRed.Text = ValidationMessage(1014)
                        lblPGreen.Text = ValidationMessage(1017)
                        Dim Check As Integer = Request.QueryString.Get("check")
                        If Check = 2 Then
                            btnPublicationAdd.Text = "ADD"
                            btnPublicationView.Text = "VIEW"
                        End If
                        btnPublicationAdd.CommandName = "ADD3"
                        btnPublicationView.CommandName = "VIEW3"
                        btnPublicationAdd.Text = "ADD"
                        btnPublicationView.Text = "VIEW"
                       
                    End If
                End If
            Else
                lblPRed.Text = ValidationMessage(1021)
                lblPGreen.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            lblPRed.Text = ValidationMessage(1055)
            lblPGreen.Text = ValidationMessage(1014)
        End Try
    End Sub
    Sub PClear()
        txtTitle.Text = ""
        txtPublicationRemarks.Text = ""
        txtPYear.Text = ""
        txtName.Text = ""
    End Sub
    Sub DisplayP()
        Dim dl As New DLEmpQualification
        el.PKIDP = 0
        el.EmployeeName = DDLEmployeeName.SelectedValue
        dt = dl.GetEmpPublication(el)
        If dt.Rows.Count > 0 Then
            GVPublication.DataSource = dt
            GVPublication.DataBind()
            Dim Check As Integer = Request.QueryString.Get("check")
            
            GVPublication.Enabled = True
            GVPublication.Visible = True
            PnlP.Visible = True
            GVPublication.Visible = True
        Else
            GVPublication.Visible = False
            lblPRed.Text = ValidationMessage(1023)
            lblPGreen.Text = ValidationMessage(1014)
            PnlP.Visible = False
        End If
    End Sub

    Protected Sub GVPublication_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVPublication.PageIndexChanging
        GVPublication.PageIndex = e.NewPageIndex
        ViewState("PageIndexP") = GVPublication.PageIndex
        DisplayP()
        GVPublication.Visible = True
        lblPGreen.Text = ValidationMessage(1014)
        lblPRed.Text = ValidationMessage(1014)
    End Sub

    Protected Sub GVPublication_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVPublication.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            el.PKIDP = CType(GVPublication.Rows(e.RowIndex).FindControl("PKID"), Label).Text
            Dim DL As New DLEmpQualification
            DL.DeletePublication(el)
            lblPRed.Text = ValidationMessage(1014)
            DDLEmployeeName.Focus()
            PClear()
            GVPublication.PageIndex = ViewState("PageIndexP")
            DisplayP()
            btnPublicationAdd.Focus()
            lblPGreen.Text = ValidationMessage(1028)
            lblPRed.Text = ValidationMessage(1014)
        Else
            lblPRed.Text = ValidationMessage(1029)
            lblPGreen.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub GVPublication_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVPublication.RowEditing
        Dim Check As Integer = Request.QueryString.Get("check")

        If Check = 2 Then
            btnPublicationAdd.Text = "UPDATE"
            btnPublicationView.Text = "BACK"
        End If


        btnPublicationAdd.CommandName = "UPDATE"
        btnPublicationView.CommandName = "BACK"
        btnPublicationAdd.Text = "UPDATE"
        btnPublicationView.Text = "BACK"

     
        txtPID.Text = CType(GVPublication.Rows(e.NewEditIndex).FindControl("PKID"), Label).Text
        'DDLEmployeeName.SelectedValue = CType(GVPublication.Rows(e.NewEditIndex).FindControl("EmpID"), Label).Text
        txtTitle.Text = CType(GVPublication.Rows(e.NewEditIndex).FindControl("PublicationTitle"), Label).Text
        txtName.Text = CType(GVPublication.Rows(e.NewEditIndex).FindControl("PublisherName"), Label).Text
        txtPublicationRemarks.Text = CType(GVPublication.Rows(e.NewEditIndex).FindControl("Remarks"), Label).Text
        txtPYear.Text = CType(GVPublication.Rows(e.NewEditIndex).FindControl("YearOfPublishing"), Label).Text
        txttype.Text = CType(GVPublication.Rows(e.NewEditIndex).FindControl("typeofpublish1"), Label).Text
        txtauthor.Text = CType(GVPublication.Rows(e.NewEditIndex).FindControl("autor1"), Label).Text
        DropDownList1.SelectedValue = CType(GVPublication.Rows(e.NewEditIndex).FindControl("lblcountrypublishid"), Label).Text
        lblPRed.Text = ValidationMessage(1014)
        lblPGreen.Text = ValidationMessage(1014)
        Dim dl As New DLEmpQualification
        el.PKIDP = txtPID.Text
        el.EmployeeName = DDLEmployeeName.SelectedValue
        dt = dl.GetEmpPublication(el)
        GVPublication.DataSource = dt
        GVPublication.DataBind()
       
        PnlP.Visible = True
        GVPublication.Enabled = False
        GVExperience.Visible = False
        GVQualification.Visible = False
        'btnPublicationAdd.CommandName = "UPDATE"
        'btnPublicationView.CommandName = "BACK"

    End Sub

    Protected Sub btnPublicationView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPublicationView.Click
        Dim dl As New DLEmpQualification
        lblPRed.Text = ValidationMessage(1014)
        lblPGreen.Text = ValidationMessage(1014)
        el.PKIDP = 0
        Dim Check As Integer = Request.QueryString.Get("check")
        
        If Check = 2 Then
            btnPublicationAdd.Text = "ADD"
            btnPublicationView.Text = "VIEW"
        End If

        btnPublicationAdd.CommandName = "ADD3"
        btnPublicationView.CommandName = "VIEW3"
        btnPublicationAdd.Text = "ADD"
        btnPublicationView.Text = "VIEW"
        lblERed.Text = ValidationMessage(1014)
        lblEGreen.Text = ValidationMessage(1014)
        el.EmployeeName = DDLEmployeeName.SelectedValue
        dt = dl.GetEmpPublication(el)
        Dim date1 As String
        date1 = Session("CurrentYear")
        Dim dt1 As DataTable
        dt1 = QualificationDB.GetYear(date1)
        Dim value As Integer = dt1.Rows(0).Item("LookUpAutoID")
        ddlYear.SelectedValue = value
        If dt.Rows.Count > 0 Then
            DisplayP()
            
            PnlP.Visible = True
        Else
            lblPRed.Text = ValidationMessage(1023)
            lblPGreen.Text = ValidationMessage(1014)
            PnlP.Visible = False
        End If
        If btnPublicationView.CommandName = "BACK" Then
            PClear()
        End If

        'btnPublicationAdd.CommandName = "ADD3"
        'btnPublicationView.CommandName = "VIEW3"
        GVPublication.Enabled = True
        GVPublication.Focus()
    End Sub

    Protected Sub txtHRAEmp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHRAEmp.TextChanged
        If Trim(txtHRAEmp.Text) = "" Then
            HidHRAEmp.Value = ""
        Else
            HidHRAEmp.Value = HidHRAEmp.Value
        End If
    End Sub

    Protected Sub txtFMEmpCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFMEmpCode.TextChanged
        If Trim(txtFMEmpCode.Text) = "" Then
            HidFMEmpCode.Value = ""
        Else
            HidFMEmpCode.Value = HidFMEmpCode.Value
        End If
    End Sub

    Protected Sub txtRMEmpCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRMEmpCode.TextChanged
        If Trim(txtRMEmpCode.Text) = "" Then
            HidRMEmpCode.Value = ""
        Else
            HidRMEmpCode.Value = HidRMEmpCode.Value
        End If
    End Sub

    Protected Sub txtAcctBranch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAcctBranch.TextChanged
        If txtAcctBranch.Text = "" Then
            HidBankId.Value = ""
        Else
            HidBankId.Value = HidBankId.Value
        End If
    End Sub

    Sub clearMed()
        HidId.Value = ""
        txtHeight.Text = ""
        txtWeight.Text = ""
        txtHeight.Text = ""
        txtIdentificationMark.Text = ""
        txtBloodGroup.Text = ""
        txtImmunizationRecord.Text = ""
        txtDetailsofanyseriousillness.Text = ""
        txtParticularsofanyallergies.Text = ""
        txtEmergencyContactName.Text = ""
        txtEmergencyContactNumber.Text = ""
        txtDisabilitiesifany.Text = ""
    End Sub

    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click

        Dim Check As Integer = Request.QueryString.Get("check")
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                ELMed.Emp_Id = DDLEmployeeName1.SelectedValue
                ELMed.Id = IIf(HidId.Value = Nothing, 0, HidId.Value)
                ELMed.Height = txtHeight.Text
                ELMed.Weight = txtWeight.Text
                ELMed.Height = txtHeight.Text
                ELMed.IdentificationMark = txtIdentificationMark.Text
                ELMed.BloodGroup = txtBloodGroup.Text
                ELMed.ImmunizationRecord = txtImmunizationRecord.Text
                ELMed.Detailsofanyseriousillness = txtDetailsofanyseriousillness.Text
                ELMed.Particularsofanyallergies = txtParticularsofanyallergies.Text
                ELMed.EmergencyContactName = txtEmergencyContactName.Text
                ELMed.EmergencyContactNumber = txtEmergencyContactNumber.Text
                ELMed.Disabilitiesifany = txtDisabilitiesifany.Text
                ELMed.LoginType = "Employee"
                Dim dt As New DataTable
                dt = DlMedicalDetails.CheckDuplicate(ELMed)
                If dt.Rows.Count > 0 Then
                    'lblRed.Visible = True
                    lblRd.Text = ValidationMessage(1030)
                    lblGrn.Text = ValidationMessage(1014)
                    DisplayMedical(0)
                    Exit Sub
                End If
                If btnInsert.CommandName = "ADD5" Then
                    Dim i As Integer = DlMedicalDetails.InsertEmp(ELMed)
                    If i > 0 Then
                        lblGrn.Text = ValidationMessage(1020)
                        lblRd.Text = ValidationMessage(1014)
                        clearMed()
                    End If
                Else
                    Dim i As Integer = DlMedicalDetails.UpdateEmp(ELMed)
                    If i > 0 Then
                        lblGrn.Text = ValidationMessage(1017)
                        lblRd.Text = ValidationMessage(1014)
                        clearMed()
                        GridMedical.Enabled = True

                        If Check = 2 Then
                            btnInsert.Text = "UPDATE"
                            btnBack.Text = "VIEW"
                        End If
                        btnInsert.CommandName = "ADD5"
                        btnBack.CommandName = "VIEW5"
                        btnInsert.Text = "ADD"
                        btnBack.Text = "VIEW"
                    End If
                End If

                If Check = 2 Then
                    DisplayMedicalDetails()
                    Exit Sub
                Else

                    DisplayMedical(0)
                End If
            Catch ex As Exception
                lblRd.Text = ValidationMessage(1132)
                lblGrn.Text = ValidationMessage(1014)
            End Try
        Else
            lblRd.Text = ValidationMessage(1021)
            lblGrn.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        LinkButton3.Focus()
        Try

            lblRd.Text = ValidationMessage(1014)
            lblGrn.Text = ValidationMessage(1014)
            Dim Check As Integer = Request.QueryString.Get("check")
            If Check = 2 Then

                DisplayMedicalDetails()
                Exit Sub
            Else
            End If
            
            clearMed()
            GridMedical.Enabled = True


            If btnBack.CommandName = "VIEW5" Then
                DisplayMedical(0)
            Else
                DisplayMedical(0)
                btnInsert.CommandName = "ADD5"
                btnBack.CommandName = "VIEW5"
                btnInsert.Text = "ADD"
                btnBack.Text = "VIEW"
                
                clearMed()
                GridMedical.Enabled = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub DisplayMedical(ByVal i As Integer)
        Dim Check As Integer = Request.QueryString.Get("check")
        Dim dt As New DataTable
        ELMed.Id = i
        ELMed.LoginType = "Employee"
        dt = DlMedicalDetails.GetEmpData(ELMed)
        If dt.Rows.Count <> 0 Then
            GridMedical.DataSource = dt
            GridMedical.DataBind()

          


            GridMedical.Visible = True
        Else
            lblRd.Text = ValidationMessage(1023)
            lblGrn.Text = ValidationMessage(1014)
            GridMedical.Visible = False
            
        End If
    End Sub
    Sub DisplayMedicalDetails()
        Dim Check As Integer = Request.QueryString.Get("check")
        Dim dt As New DataTable
        ELMed.Emp_Id = 0
        ELMed.LoginType = "Employee"
        dt = DlMedicalDetails.GetEmpDataDetails(ELMed)
        If dt.Rows.Count <> 0 Then
            GridMedical.DataSource = dt
            GridMedical.DataBind()

            GridMedical.Enabled = True
        Else
            lblRd.Text = ValidationMessage(1023)
            lblGrn.Text = ValidationMessage(1014)
            GridMedical.Visible = False
            
        End If
    End Sub

    Protected Sub GridMedical_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridMedical.PageIndexChanging
        Try
            GridMedical.PageIndex = e.NewPageIndex
            ViewState("PageIndex") = GridMedical.PageIndex
            GridMedical.DataBind()

            DisplayMedical(0)
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub GridMedical_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridMedical.RowDeleting
        Dim Check As Integer = Request.QueryString.Get("check")



        lblRd.Text = ValidationMessage(1014)
        lblGrn.Text = ValidationMessage(1014)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ELMed.Id = CType(GridMedical.Rows(e.RowIndex).Cells(1).FindControl("lblID"), System.Web.UI.WebControls.Label).Text
            DlMedicalDetails.GetDelete(ELMed)
            DisplayMedicalDetails()
            GridMedical.Visible = True

            GridMedical.PageIndex = ViewState("PageIndex")
            DisplayMedicalDetails()
            lblRd.Text = ValidationMessage(1014)
            lblGrn.Text = ValidationMessage(1028)
        Else
            lblRd.Text = ValidationMessage(1029)
            lblGrn.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GridMedical_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridMedical.RowEditing
        lblRd.Text = ValidationMessage(1014)
        lblGrn.Text = ValidationMessage(1014)
        Try
            HidId.Value = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblID"), System.Web.UI.WebControls.Label).Text
            DDLEmployeeName1.SelectedValue = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblEmpId"), System.Web.UI.WebControls.Label).Text
            txtHeight.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblHeight"), System.Web.UI.WebControls.Label).Text
            txtWeight.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblWeight"), System.Web.UI.WebControls.Label).Text
            txtIdentificationMark.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblIdentificationMark1"), System.Web.UI.WebControls.Label).Text
            txtBloodGroup.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblBloodGroup"), System.Web.UI.WebControls.Label).Text
            txtImmunizationRecord.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblImmunizationRecord"), System.Web.UI.WebControls.Label).Text
            txtDetailsofanyseriousillness.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblDetailsofanyseriousillness"), System.Web.UI.WebControls.Label).Text
            txtParticularsofanyallergies.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblParticularsofanyallergies"), System.Web.UI.WebControls.Label).Text
            txtEmergencyContactName.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblEmergencyContactName"), System.Web.UI.WebControls.Label).Text
            txtEmergencyContactNumber.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblEmergencyContactNumber"), System.Web.UI.WebControls.Label).Text
            txtDisabilitiesifany.Text = CType(GridMedical.Rows(e.NewEditIndex).FindControl("lblDisabilitiesifany1"), System.Web.UI.WebControls.Label).Text
            ELMed.Id = HidId.Value
            Dim Check As Integer = Request.QueryString.Get("check")
            If Check = 2 Then
                btnInsert.Text = "UPDATE"
                btnBack.Text = "BACK"
            End If
            btnInsert.CommandName = "UPDATE"
            btnBack.CommandName = "BACK"
            btnInsert.Text = "UPDATE"
            btnBack.Text = "BACK"
          
            Dim dt As New DataTable
            GridMedical.Enabled = False
            If Check = 2 Then

                DisplayMedicalDetails()
                GridMedical.Enabled = False

            Else
                DisplayMedical(ELMed.Id)
            End If
        Catch ex As Exception

            lblGrn.Text = ValidationMessage(1014)
        End Try
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        If txtEmpName.Text = "" Then
            indmaster.Emp_Name = 0
        Else
            indmaster.Emp_Name = txtEmpName.Text
        End If
        If txtEmpcode.Text = "" Then
            indmaster.EmpCode = "*"
        Else
            indmaster.EmpCode = txtEmpcode.Text
        End If
        If ddldesignation.SelectedValue = "" Then
            indmaster.Designation = 0
        Else
            indmaster.Designation = ddldesignation.SelectedValue
        End If
        'If DDLDeptType.SelectedValue = "Select" Then
        '    indmaster.BranchTypeCode = "0"
        'Else
        '    indmaster.BranchTypeCode = DDLDeptType.SelectedValue
        'End If
        indmaster.Designation = ddldesignation.SelectedValue
        indmaster.Emp_Id = 0
        indmaster.EmpCategory = txtEmpCategory.Text
        indmaster.EmploymentType = ddlEmpType.SelectedValue
        indmaster.NICNO = txtNicNo.Text

        If txtDOB.Text = "" Then
            indmaster.DOB = "1/1/2999"
        Else
            indmaster.DOB = txtDOB.Text
        End If
        If txtDOJ.Text = "" Then
            indmaster.DOJ = "1/1/3000"
        Else
            indmaster.DOJ = txtDOJ.Text
        End If
        indmaster.DeptID = ddlDept.SelectedValue
        If txtContactNo.Text = "" Then
            indmaster.ContactNo = 0
        Else
            indmaster.ContactNo = txtContactNo.Text
        End If
        If txtLandlineNo.Text = "" Then
            indmaster.LandlineNo = 0
        Else
            indmaster.LandlineNo = txtLandlineNo.Text
        End If
        If txtEmail.Text = "" Then
            indmaster.Email = 0
        Else
            indmaster.Email = txtEmail.Text
        End If
        If txtqualification.Text = "" Then
            indmaster.Qualification = 0
        Else
            indmaster.Qualification = txtqualification.Text
        End If

        If ddlSex.SelectedValue = "Select" Then
            indmaster.Sex = "0"
        Else
            indmaster.Sex = ddlSex.SelectedValue
        End If
        'If txtCountry.Text = "" Then
        '    indmaster.Country = 0
        'Else
        '    indmaster.Country = txtCountry.Text
        'End If
        indmaster.Country = ddlCountry.SelectedValue
        If txtDOL.Text = "" Then
            indmaster.DOL = "1/1/3100"
        Else
            indmaster.DOL = txtDOL.Text
        End If
        If txtPassportNo.Text = "" Then
            indmaster.PassportNo = 0
        Else
            indmaster.PassportNo = txtPassportNo.Text
        End If
        If txtretirement.Text = "" Then
            indmaster.DOR = "1/1/3100"
        Else
            indmaster.DOR = txtretirement.Text
        End If
        If txtDOA.Text = "" Then
            indmaster.DOA = "1/1/3000"
        Else
            indmaster.DOA = txtDOA.Text
        End If
        dt = individual.GetIndividualFormMaster(indmaster)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        Dim Check As Integer = Request.QueryString.Get("check")
        

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
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
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
        Return 0
    End Function
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub
    Public Sub employeemasterpage()
        If Not IsPostBack Then
            Dim Check As Integer = Request.QueryString.Get("check")
            If Check = 2 Then
                indmaster.Emp_Id = Session("EmpId")
                dt = individual.GetENPLOYEEDetails(indmaster)
                dt1 = individual.GetENPLOYEEDetails2(indmaster)
                'ViewState("Emp_Id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelEmp_Id"), HiddenField).Value
                'ddlempcategory.SelectedValue = dt.Rows(0).Item("EmployeeCategory").ToString
                ViewState("Emp_Id") = Session("EmpId")
                'ddlempcategory.SelectedValue = dt.Rows(0).Item("EmployeeCategory").ToString
                ddlEmpType.SelectedValue = dt.Rows(0).Item("Full_PartTime").ToString
                ddlEmpType.Enabled = False
                txtEmpName.Text = dt.Rows(0).Item("Emp_Name").ToString
                txtmiddle.Text = dt.Rows(0).Item("MiddleName").ToString
                txtEmpName.Enabled = False
                DDLEmployeeName.Items.Clear()
                DDLEmployeeName.DataSourceID = "ObjEmpName"
                DDLEmployeeName.DataBind()
                DDLEmployeeName.SelectedValue = dt.Rows(0).Item("EmpId")
                DDLEmployeeName.Enabled = False
                DDLEmployeeName1.Items.Clear()
                DDLEmployeeName1.DataSourceID = "ObjectDataSource1"
                DDLEmployeeName1.DataBind()
                DDLEmployeeName1.SelectedValue = dt.Rows(0).Item("EmpId")
                DDLEmployeeName1.Enabled = False
                ddlCountry.Items.Clear()
                ddlCountry.DataSourceID = "ObjCountry"
                ddlCountry.DataBind()
                ddlCountry.SelectedValue = dt.Rows(0).Item("Country")
                ddlCountry.Enabled = True
                ddlState.Items.Clear()
                ddlState.DataSourceID = "ObjState"
                ddlState.DataBind()
                ddlState.SelectedValue = dt.Rows(0).Item("StateName")
                'ddlState.Enabled = False
                ddlDistric.Items.Clear()
                ddlDistric.DataSourceID = "ObjDistric"
                ddlDistric.DataBind()
                ddlDistric.SelectedValue = dt.Rows(0).Item("Distric")
                'ddlDistric.Enabled = False
                txtEmpcode.Text = dt.Rows(0).Item("Emp_Code").ToString
                txtEmpcode.Enabled = False
                txtAddress.Text = dt.Rows(0).Item("Emp_Address").ToString
                'txtCountry.Text = dt.Rows(0).Item("Country").ToString
                txtContactNo.Text = dt.Rows(0).Item("ContactNo").ToString
                txtLandlineNo.Text = dt.Rows(0).Item("LandlineNo").ToString
                txtEmail.Text = dt.Rows(0).Item("Email").ToString
                If dt.Rows(0).Item("DOB").ToString = "" Then
                    txtDOB.Text = dt.Rows(0).Item("DOB").ToString
                Else
                    txtDOB.Text = Format(dt.Rows(0).Item("DOB"), "dd-MMM-yyyy")
                End If
                txtDOB.Enabled = False
                If dt.Rows(0).Item("DOJ").ToString = "" Then
                    txtDOJ.Text = dt.Rows(0).Item("DOJ").ToString
                Else
                    txtDOJ.Text = Format(dt.Rows(0).Item("DOJ"), "dd-MMM-yyyy")
                End If
                txtDOJ.Enabled = False


                If dt.Rows(0).Item("DOL").ToString = "" Then
                    txtDOL.Text = dt.Rows(0).Item("DOL").ToString
                Else
                    txtDOL.Text = Format(dt.Rows(0).Item("DOL"), "dd-MMM-yyyy")
                End If
                txtDOL.Enabled = False
                If dt.Rows(0).Item("DOR").ToString = "" Then
                    txtretirement.Text = dt.Rows(0).Item("DOR").ToString
                Else
                    txtretirement.Text = Format(dt.Rows(0).Item("DOR"), "dd-MMM-yyyy")
                End If

                If dt.Rows(0).Item("DOR").ToString = "" Then
                    txtretirement.Text = dt.Rows(0).Item("DOR").ToString
                Else
                    txtretirement.Text = Format(dt.Rows(0).Item("DOR"), "dd-MMM-yyyy")
                End If
                txtretirement.Enabled = False
                If dt.Rows(0).Item("StopSalaryDate").ToString = "" Then
                    txtsalarystop.Text = dt.Rows(0).Item("StopSalaryDate").ToString
                Else
                    txtsalarystop.Text = Format(dt.Rows(0).Item("StopSalaryDate"), "dd-MMM-yyyy")
                End If
                txtsalarystop.Enabled = False

                txtPanNo.Text = dt.Rows(0).Item("PanNo").ToString
                txtPanNo.Enabled = False
                txtqualification.Text = dt.Rows(0).Item("Qualification").ToString
                txtqualification.Enabled = False
                ddlSex.SelectedValue = dt.Rows(0).Item("Gender").ToString
                'If dt.Rows(0).Item("DeptID") = "" Then
                '    ddlDept.SelectedValue = dt.Rows(0).Item("DeptID").ToString
                'Else
                ddlSex.Enabled = False
                ddlDept.SelectedValue = dt.Rows(0).Item("DeptID")
                ddlDept.Enabled = False
                'End If


                ViewState("BranchTypeCode") = dt.Rows(0).Item("BranchTypeCode")
                'DDLDeptType.Items.Clear()
                'DDLDeptType.DataSourceID = "obBranchType"
                'DDLDeptType.DataBind()
                'DDLDeptType.SelectedValue = dt.Rows(0).Item("BranchTypeCode")
                'DDLDeptType.Enabled = False
                Ddldpt.Items.Clear()
                Ddldpt.DataSourceID = "objDept"
                Ddldpt.DataBind()
                Ddldpt.SelectedValue = dt.Rows(0).Item("Branch_Code").ToString
                Ddldpt.Enabled = False
                ddldesignation.Items.Clear()
                ddldesignation.DataSourceID = "ObjDesignation"
                ddldesignation.DataBind()
                ddldesignation.SelectedValue = dt.Rows(0).Item("DesigID").ToString
                ddldesignation.Enabled = False
                txtSalary.Text = dt.Rows(0).Item("Salary").ToString
                txtSalary.Enabled = False
                txtAccountNo.Text = dt.Rows(0).Item("AccountNo").ToString
                txtAccountNo.Enabled = False
                txtAcctBranch.Text = dt.Rows(0).Item("Bank_Name").ToString
                txtAcctBranch.Enabled = False
                HidBankId.Value = dt.Rows(0).Item("Bank_ID").ToString
                txtServicePeriod.Text = dt.Rows(0).Item("ServicePeriod").ToString
                txtServicePeriod.Enabled = False
                If dt.Rows(0).Item("Delegated").ToString() = "Y" Then
                    CheckBox1.Checked = False

                    txtDelegated.Text = dt.Rows(0).Item("DelName").ToString
                End If
                CheckBox1.Enabled = False
                txtDelegated.Enabled = False

                txtHRAEmp.Text = dt.Rows(0).Item("HRAEmpCode").ToString
                txtHRAEmp.Enabled = False
                txtFMEmpCode.Text = dt.Rows(0).Item("FMEmpCode").ToString
                txtFMEmpCode.Enabled = False
                txtRMEmpCode.Text = dt.Rows(0).Item("RMEmpCode").ToString
                txtRMEmpCode.Enabled = False
                ViewState("ImageTime") = dt.Rows(0).Item("Photos").ToString
                txtNicNo.Text = dt.Rows(0).Item("NICNO").ToString
                txtNicNo.Enabled = False
                txtCaddr.Text = dt.Rows(0).Item("Corres_Address").ToString
                'txtCaddr.Enabled = False
                If dt.Rows(0).Item("Hostel").ToString = "Y" Then
                    ChkHostel.Checked = True
                Else
                    ChkHostel.Checked = False
                End If
                ChkHostel.Enabled = False
                If dt.Rows(0).Item("Transport").ToString = "Y" Then
                    ChkTransport.Checked = True
                Else
                    ChkTransport.Checked = False
                End If
                ChkTransport.Enabled = False
                If dt.Rows(0).Item("StopSalary").ToString = "Y" Then
                    ChkStopSalary.Checked = True
                Else
                    ChkStopSalary.Checked = False
                End If
                ChkStopSalary.Enabled = False
                txtFname.Text = dt.Rows(0).Item("FatherName").ToString
                txtFname.Enabled = False
                txtMothername.Text = dt.Rows(0).Item("MotherName").ToString
                txtMothername.Enabled = False
                txtSpouseName.Text = dt.Rows(0).Item("SpouseName").ToString
                txtSpouseName.Enabled = False
                txtNameinpassport.Text = dt.Rows(0).Item("NameInPassport").ToString
                txtNameinpassport.Enabled = False
                txtPlaceofIssue.Text = dt.Rows(0).Item("PlaceofIssue").ToString
                txtPlaceofIssue.Enabled = False
                txtPassportNo.Text = dt.Rows(0).Item("PassportNo").ToString
                txtPassportNo.Enabled = False
                If dt.Rows(0).Item("PassportExpiryDate").ToString = "" Then
                    txtExpiryDate.Text = dt.Rows(0).Item("PassportExpiryDate").ToString
                Else
                    txtExpiryDate.Text = Format(dt.Rows(0).Item("PassportExpiryDate"), "dd-MMM-yyyy")
                End If
                txtExpiryDate.Enabled = False
                If dt.Rows(0).Item("PassportIssueDate").ToString = "" Then
                    txtPassportIssueDate.Text = dt.Rows(0).Item("PassportIssueDate").ToString
                Else
                    txtPassportIssueDate.Text = Format(dt.Rows(0).Item("PassportIssueDate"), "dd-MMM-yyyy")
                End If
                txtPassportIssueDate.Enabled = False
                If dt.Rows(0).Item("VisaIssueDate").ToString = "" Then
                    txtVisaIssueDate.Text = dt.Rows(0).Item("VisaIssueDate").ToString
                Else
                    txtVisaIssueDate.Text = Format(dt.Rows(0).Item("VisaIssueDate"), "dd-MMM-yyyy")
                End If
                txtVisaIssueDate.Enabled = False
                If dt.Rows(0).Item("VisaExpiryDate").ToString = "" Then
                    txtVisaExpDate.Text = dt.Rows(0).Item("VisaExpiryDate").ToString
                Else
                    txtVisaExpDate.Text = Format(dt.Rows(0).Item("VisaExpiryDate"), "dd-MMM-yyyy")
                End If
                txtVisaExpDate.Enabled = False


                txtVisaNo.Text = dt.Rows(0).Item("VisaNo").ToString
                txtVisaNo.Enabled = False
                txtPFNo.Text = dt.Rows(0).Item("PFNo").ToString
                txtPFNo.Enabled = False


                If dt.Rows(0).Item("FRROExpDate").ToString = "" Then
                    txtFRRO.Text = dt.Rows(0).Item("FRROExpDate").ToString
                Else
                    txtFRRO.Text = Format(dt.Rows(0).Item("FRROExpDate"), "dd-MMM-yyyy")
                End If
                txtFRRO.Enabled = False

                ddlGrade.SelectedValue = dt.Rows(0).Item("Grade").ToString
                ddlGrade.Enabled = False
                txtESINo.Text = dt.Rows(0).Item("ESI_No").ToString
                txtESINo.Enabled = False
                txtVDA.Text = dt.Rows(0).Item("VDA").ToString
                txtVDA.Enabled = False
                txtNationality.Text = dt.Rows(0).Item("Nationality").ToString
                txtNationality.Enabled = False
                txtReligion.Text = dt.Rows(0).Item("Religion").ToString
                txtReligion.Enabled = False
                txtEthnicity.Text = dt.Rows(0).Item("Ethnicity").ToString
                txtEthnicity.Enabled = False
                txtCivilStates.Text = dt.Rows(0).Item("CivilStates").ToString
                txtCivilStates.Enabled = False
                txtOthername.Text = dt.Rows(0).Item("OtheName").ToString
                txtOthername.Enabled = False
                txtInt.Text = dt.Rows(0).Item("Initial").ToString
                txtInt.Enabled = False
                txtPFileNo.Text = dt.Rows(0).Item("PFNo").ToString
                txtPFileNo.Enabled = False
                If dt.Rows(0).Item("DOP").ToString = "01-Jan-3000" Then
                    txtDop.Text = ""
                    txtDop.Text = Format(dt.Rows(0).Item("DOP"), "dd-MMM-yyyy")
                ElseIf dt.Rows(0).Item("DOP").ToString = "" Then
                    txtDop.Text = dt.Rows(0).Item("DOP").ToString
                    'txtDop.Text = Format(dt.Rows(0).Item("DOP"), "dd-MMM-yyyy")
                End If
                txtDop.Enabled = False
                txtrace.Text = dt.Rows(0).Item("Race").ToString
                txtrace.Enabled = False
                txtNomi.Text = dt.Rows(0).Item("NomineeName").ToString
                txtNomi.Enabled = False
                txtEtf.Text = dt.Rows(0).Item("ETF").ToString
                txtEtf.Enabled = False
                'txtdistrict.Text = dt.Rows(0).Item("Distric").ToString
                txtPC.Text = dt.Rows(0).Item("PinCode").ToString
                'txtPC.Enabled = False
                txtCity.Text = dt.Rows(0).Item("City").ToString
                ddlState.Items.Clear()
                ddlState.DataSourceID = "ObjState"
                ddlState.DataBind()
                ddlState.SelectedValue = dt.Rows(0).Item("StateName").ToString
                ddlDistric.Items.Clear()
                ddlDistric.DataSourceID = "ObjDistric"
                ddlDistric.DataBind()
                ddlDistric.SelectedValue = dt.Rows(0).Item("Distric").ToString
                cmbTitle.Items.Clear()
                cmbTitle.DataSourceID = "ObjTitle"
                cmbTitle.DataBind()
                cmbTitle.SelectedValue = dt.Rows(0).Item("Title").ToString
                cmbTitle.Enabled = False
                ddlpaymentmethod.SelectedValue = dt.Rows(0).Item("ModeOfPayment").ToString
                ddlpaymentmethod.Enabled = False
                If dt.Rows(0).Item("SalaryRevDate").ToString = "01-Jan-3000" Then
                    TxtSRDate.Text = ""
                    TxtSRDate.Text = Format(dt.Rows(0).Item("SalaryRevDate"), "dd-MMM-yyyy")
                ElseIf dt.Rows(0).Item("SalaryRevDate").ToString = "" Then
                    TxtSRDate.Text = dt.Rows(0).Item("SalaryRevDate").ToString
                    'txtDop.Text = Format(dt.Rows(0).Item("DOP"), "dd-MMM-yyyy")
                End If
                TxtSRDate.Enabled = False
                txtPFAcctNo.Text = dt.Rows(0).Item("PFACCNO").ToString
                txtPFAcctNo.Enabled = False
                If dt.Rows(0).Item("Settelment").ToString = "Y" Then
                    ChkSttlmnt.Checked = True
                Else
                    ChkSttlmnt.Checked = False
                End If
                ChkSttlmnt.Enabled = False
                If dt.Rows(0).Item("Pensionable").ToString = "Y" Then
                    chkPensionable.Checked = True
                Else
                    chkPensionable.Checked = False
                End If
                chkPensionable.Enabled = False
                If dt.Rows(0).Item("Gratuity").ToString = "Y" Then
                    ChkGratutity.Checked = True
                Else
                    ChkGratutity.Checked = False
                End If
                ChkGratutity.Enabled = False
                If dt.Rows(0).Item("Increment").ToString = "Y" Then
                    ChkIncrement.Checked = True
                Else
                    ChkIncrement.Checked = False
                End If
                ChkIncrement.Enabled = False
                If dt.Rows(0).Item("Pension").ToString = "Y" Then
                    ChkPension.Checked = True
                Else
                    ChkPension.Checked = False
                End If
                ChkPension.Enabled = False
                If dt.Rows(0).Item("Resignation").ToString = "Y" Then
                    ChkResignation.Checked = True
                Else
                    ChkResignation.Checked = False
                End If
                ChkResignation.Enabled = False

                If dt.Rows(0).Item("Promotion").ToString = "Y" Then
                    ChkPromotion.Checked = True
                Else
                    ChkPromotion.Checked = False
                End If
                ChkPromotion.Enabled = False
                If dt.Rows(0).Item("Uniform").ToString = "Y" Then
                    ChkUniform.Checked = True
                Else
                    ChkUniform.Checked = False
                End If
                ChkUniform.Enabled = False
                Btnadd.Text = "UPDATE"
                Btnadd.CommandName = "UPDATE"
                btnInsert.Text = "UPDATE"
                btnInsert.CommandName = "UPDATE"
                BtnView.Visible = False
                btnBack.Visible = False
                lblmsg.Text = ""
                If dt1.Rows.Count > 0 Then
                    'If txtHeight.Text = "" Then
                    '    txtHeight.Text = 0
                    'Else
                    '    txtHeight.Text = dt1.Rows(0).Item("Height").ToString
                    'End If
                    'If txtWeight.Text = "" Then
                    '    txtWeight.Text = 0
                    'Else
                    '    txtWeight.Text = dt1.Rows(0).Item("Weight").ToString
                    'End If
                    'If txtBloodGroup.Text = "" Then
                    '    txtBloodGroup.Text = "B+"
                    'Else
                    '    txtBloodGroup.Text = dt1.Rows(0).Item("BG").ToString
                    'End If

                    txtIdentificationMark.Text = dt1.Rows(0).Item("IM").ToString
                    txtImmunizationRecord.Text = dt1.Rows(0).Item("IR").ToString
                    txtDetailsofanyseriousillness.Text = dt1.Rows(0).Item("DI").ToString
                    txtParticularsofanyallergies.Text = dt1.Rows(0).Item("POA").ToString
                    txtEmergencyContactName.Text = dt1.Rows(0).Item("EN").ToString
                    txtEmergencyContactNumber.Text = dt1.Rows(0).Item("EC").ToString
                    txtDisabilitiesifany.Text = dt1.Rows(0).Item("DIS").ToString
                    indmaster.Emp_Id = ViewState("Emp_Id")





                    txtEmpCategory.Enabled = False
                    txtStopSalaryReason.Enabled = False
                    txtEmpName.Enabled = False
                    txtEmpcode.Enabled = False
                    'txtAddress.Enabled = False
                    'txtCountry.Enabled = False
                    txtContactNo.Enabled = False
                    txtLandlineNo.Enabled = False
                    txtEmail.Enabled = False
                    txtDOB.Enabled = False
                    txtDOJ.Enabled = False
                    txtDOL.Enabled = False
                    txtDOA.Enabled = False
                    txtretirement.Enabled = False
                    txtAccountNo.Enabled = False
                    txtSalary.Enabled = False
                    txtAcctBranch.Enabled = False
                    lblmsg.Enabled = False
                    txtPath.Enabled = False
                    txtDelegated.Enabled = False
                    txtServicePeriod.Enabled = False
                    txtPanNo.Enabled = False
                    CheckBox1.Checked = False
                    Image2.ImageUrl = "~\Images\imageupload.gif"
                    CheckBox1.Checked = False
                    txtDelegated.Enabled = False
                    CheckBox1.Enabled = False
                    HidBankId.Value = 0
                    HidEmpCode.Value = 0
                    txtHRAEmp.Text = ""
                    HidHRAEmp.Value = 0
                    txtFMEmpCode.Enabled = False
                    HidFMEmpCode.Value = 0
                    txtRMEmpCode.Enabled = False
                    HidRMEmpCode.Value = 0
                    txtqualification.Enabled = False
                    'ViewState("ImageTime") = ""
                    txtNicNo.Enabled = False
                    txtCaddr.Enabled = False
                    ChkHostel.Checked = False
                    ChkTransport.Checked = False
                    txtFname.Enabled = False
                    txtSpouseName.Enabled = False
                    txtNameinpassport.Enabled = False
                    txtPlaceofIssue.Enabled = False
                    txtPassportNo.Enabled = False
                    txtExpiryDate.Enabled = False
                    txtPassportIssueDate.Enabled = False
                    txtVisaIssueDate.Enabled = False
                    txtVisaExpDate.Enabled = False
                    txtVisaNo.Enabled = False
                    txtFRRO.Enabled = False
                    txtMothername.Enabled = False
                    txtPFNo.Enabled = False
                    'txtCountry.Enabled = False
                    txtESINo.Enabled = False
                    txtVDA.Enabled = False
                    txtNationality.Enabled = False
                    txtReligion.Enabled = False
                    txtCivilStates.Enabled = False
                    txtEthnicity.Enabled = False
                    txtOthername.Enabled = False
                    txtInt.Enabled = False
                    txtPFileNo.Enabled = False
                    txtDop.Enabled = False
                    'indmaster.DOP = txtDop.Text
                    txtNomi.Enabled = False
                    txtrace.Enabled = False
                    txtEtf.Enabled = False
                    'txtdistrict.Enabled = False
                    txtCity.Enabled = False
                    ddlState.SelectedValue = 0
                    txtPC.Enabled = False
                    txtPFAcctNo.Enabled = False
                    TxtSRDate.Enabled = False
                    ChkGratutity.Checked = False
                    ChkIncrement.Checked = False
                    ChkPension.Checked = False
                    ChkPromotion.Checked = False
                    ChkResignation.Checked = False
                    ChkUniform.Checked = False
                    ChkSttlmnt.Checked = False
                    chkPensionable.Checked = False
                    ChkStopSalary.Checked = False
                    txtmiddle.Enabled = False
                    txtsalarystop.Enabled = False
                    Btnadd.Text = "UPDATE"
                    Btnadd.CommandName = "UPDATE"
                    Btnadd.Enabled = False
                    btnInsert.Text = "UPDATE"
                    btnInsert.CommandName = "UPDATE"
                    BtnView.Visible = False
                    btnBack.Visible = False
                    'btnInsert.Enabled = False
                    BtnView.Enabled = False

                    Exit Sub
                End If
            End If
        End If
    End Sub
    Public Sub employeemasterpage2()
        If Not IsPostBack Then
            Dim Check As Integer = Request.QueryString.Get("check")
            If Check = 2 Then


                Btnadd.Text = "UPDATE"
                Btnadd.CommandName = "UPDATE"
                Btnadd.Enabled = False
                btnInsert.Text = "UPDATE"
                btnInsert.CommandName = "UPDATE"
                BtnView.Visible = False
                btnBack.Visible = False
                btnInsert.Enabled = False
                BtnView.Enabled = False
                btnQualificationAdd.Enabled = False
                btnExperienceAdd.Enabled = False
                btnQualificationView.Enabled = False
                btnPublicationAdd.Enabled = False
                btnPublicationView.Enabled = False
                btnExperienceView.Enabled = False


                lblmsg.Text = ""
                Exit Sub

            End If
        End If
    End Sub

    Protected Sub ddlGrade_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGrade.SelectedIndexChanged
        indmaster.SalaryGrade = ddlGrade.SelectedValue
        dt = individual.GetENPLOYEECategory(indmaster)
        If dt.Rows.Count > 0 Then
            txtEmpCategory.Text = dt.Rows(0).Item("EmployeeType").ToString
        Else
            txtEmpCategory.Text = ""
        End If

        'If dt.Rows(0).Item("EmployeeType").ToString = "" Then




    End Sub

    Protected Sub Hyperlink2_DataBinding(ByVal sender As Object, ByVal e As System.EventArgs) Handles Hyperlink2.DataBinding

    End Sub

    Protected Sub Hyperlink2_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Hyperlink2.Init

    End Sub

    Protected Sub Hyperlink2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Hyperlink2.Load

    End Sub

    Protected Sub Hyperlink2_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Hyperlink2.Unload

    End Sub



End Class
