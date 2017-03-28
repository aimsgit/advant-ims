


Partial Class frmEnquiry
    Inherits BasePage
    Dim da As New OleDbDataAdapter()
    Dim dt, dt1 As New DataTable
    Dim BAL As New EnquiryManager

    Dim sql3, sql As String
    Dim Brc As Integer
    Dim flag As Integer
    Dim GlobalFunction As New GlobalFunction
    Dim dispId As String
    Dim enq As New Enquiry

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ddlBranch.Focus()

        Try
            GridView1.SelectedIndex = -1
            If (Session("BranchCode") = Session("ParentBranch")) Then
                lblErrorMsg.Text = ""
                msgInfo.Text = ""
                If (flag = 1) Then
                    Exit Sub
                End If
                If Session("StatusEnquiry") = "In" Then
                    enq.NormalOnlineEnq = 0
                    enq.OnlineEnqId = Session("Enquiry_AutoId")
                Else
                    enq.NormalOnlineEnq = 1
                End If

                enq.EnquiryNo = txtEnqno.Text
                enq.EDate = CDate(txtDate.Text.Trim)
                enq.Title = Me.cmbTitle.SelectedItem.Text.Trim
                enq.Name = Me.txtFName.Text.Trim
                enq.Address = Me.txtAddress.Text.Trim
                enq.City = Me.TxtCity.Text.Trim
                enq.PinCode = Me.TxtPnCode.Text.Trim
                enq.District = Me.TxtDistrict.Text.Trim
                enq.State = Me.ddlState.SelectedItem.Value
                enq.Country = Me.txtCountry.Text.Trim
                enq.Phone = Me.txtPhone.Text.Trim
                enq.Mobile = Me.txtMobile.Text.Trim
                enq.Email = Me.txtEmail.Text.Trim
                enq.Qualification = Me.txtQ.Text.Trim
                enq.Caste = Me.txtcaste.SelectedValue
                enq.CategoryId = ddlcategry.SelectedValue
                enq.Marks = txtmarks.Text
                If txtDOB.Text = "" Then
                    enq.DOB = "01-01-9100"
                Else
                    enq.DOB = Me.txtDOB.Text.Trim
                End If
                enq.ERelates = Me.cmbERelates.SelectedItem.Text.Trim
                If Me.cmbERelates.SelectedItem.Text = "Career" Then
                    enq.CourseType = Nothing
                    enq.Course = Nothing
                Else
                    enq.CourseType = Me.cmbCourseType.SelectedValue
                    enq.Course = Me.ddlCourse.SelectedValue
                End If
                enq.YEnquiry = Me.txtEnquiry.Text.Trim
                enq.Source = Me.ddlSource.SelectedValue
                enq.Branchid = Me.ddlBranch.SelectedItem.Value
                enq.FName = Me.txtfathersname.Text.Trim
                enq.FOccupation = Me.txtoccupation.Text.Trim
                If Me.txtannualincome.Text.Trim <> "" Then
                    enq.AIncome = Me.txtannualincome.Text.Trim
                Else
                    enq.AIncome = 0.0
                End If
                enq.Enquirer = Me.txtenquirer.Text.Trim
                enq.Prospectus = Me.RadioButtonList1.SelectedItem.Value
                If ChkHostel.Checked = True Then
                    enq.Hostel = "Y"
                Else
                    enq.Hostel = "N"
                End If
                If ChkTransport.Checked = True Then
                    enq.Transport = "Y"
                Else
                    enq.Transport = "N"
                End If
                enq.NicNo = txtNicNo.Text
                Dim em As New EnquiryManager
                Dim i As Integer
                If btnSave.Text = "UPDATE" Then
                    'Kusum.C.Akki 21-March-2012
                    'Code For Updating the data
                    enq.Id = ViewState("EID")
                    Dim dt As New DataTable
                    dt = em.GetEnquiryDuplicate(enq)
                    If dt.Rows.Count <= 0 Then
                        i = em.UpdateRecord(enq)
                    Else
                        lblErrorMsg.Text = "Enquiry No already exists."
                        msgInfo.Text = ""
                        Exit Sub
                    End If
                    If CInt(IIf(txtage.Text = "", 0, txtage.Text)) < 0 Then
                        lblErrorMsg.Text = "Date cannot be greater than today."
                        msgInfo.Text = ""
                    Else
                        If i = 0 Then
                            lblErrorMsg.Text = "Data not updated."
                            msgInfo.Text = ""
                        Else
                            msgInfo.Text = "Data updated successfully."
                            lblErrorMsg.Text = ""
                            ChkHostel.Checked = False
                            ChkTransport.Checked = False
                            clear1()
                            'enq.Id = 0
                            'enq.Branchid = 0
                            'enq.FName = 0
                            'enq.ERelates = 0
                            btnSave.Text = "ADD"
                            btnDetails.Text = "VIEW"
                            'ddlCourse.Items.Clear()
                            dt = BAL.GetEnquiry(enq)
                            GridView1.Enabled = True
                            GridView1.Visible = True
                            GridView1.DataSource = dt
                            GridView1.DataBind()
                        End If
                    End If
                Else
                    'Kusum.C.Akki 21-March-2012
                    'Code For inserting the data
                    Dim dt As New DataTable
                    dt = em.GetEnquiryDuplicate(enq)
                    If CInt(IIf(txtage.Text = "", 0, txtage.Text)) < 0 Then
                        lblErrorMsg.Text = "Date cannot be greater than today."
                        msgInfo.Text = ""
                    Else
                        If dt.Rows.Count <= 0 Then
                            i = em.InsertRecord(enq)
                            ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")

                        Else
                            lblErrorMsg.Text = "Enquiry No already exists."
                            msgInfo.Text = ""
                            Exit Sub
                        End If

                        If i = 0 Then
                            Session("GStatus") = ""
                            lblErrorMsg.Text = "Data not saved."
                            msgInfo.Text = ""
                            Clear()
                            RadioButtonList1.SelectedValue = 0
                        Else
                            Session("GStatus") = ""
                            msgInfo.Text = "Data saved successfully."
                            lblErrorMsg.Text = ""
                            ChkHostel.Checked = False
                            ChkTransport.Checked = False
                            clear1()
                            RadioButtonList1.SelectedValue = 0
                        End If
                    End If
                    enq.Id = 0
                    'enq.Branchid = 0
                    'enq.FName = 0
                    'enq.ERelates = 0
                    'ViewAddData(ViewState("dispId "))
                    dt = BAL.GetAddEnquiry(ViewState("dispId "))
                    'dt = BAL.GetEnquiry(enq)
                    GridView1.Visible = True
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    'ddlCourse.Items.Clear()
                End If
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
                msgInfo.Text = ""
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct data."
            msgInfo.Text = ""
        End Try
    End Sub
    Sub DisplayGridValue(ByVal sender As Object, ByVal e As System.EventArgs)
        GridView1.Visible = True
        GridView1.SelectedIndex = -1
        Dim dt As DataTable
        enq.Id = 0
        dt = BAL.GetEnquiry(enq)
        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
        Else
            GridView1.DataSource = dt
            GridView1.DataBind()
        End If
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click

        'LinkButton1.Focus()
        'Dim en As New Enquiry
        If Session("StatusEnquiry") = "In" Then
            enq.OnlineEnqId = Session("Enquiry_AutoId")
        Else
            enq.OnlineEnqId = 0
        End If
        GridView1.SelectedIndex = -1
        lblErrorMsg.Text = ""
        msgInfo.Text = ""
        GridView1.Enabled = True
        If btnDetails.Text.Trim <> "VIEW" Then
            Clear()
            ChkHostel.Checked = False
            ChkTransport.Checked = False
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
        End If
        If ddlBranch.SelectedValue = "0" Then
            enq.Branchid = 0
        Else
            enq.Branchid = ddlBranch.SelectedItem.Value
        End If
        If txtFName.Text = "" Then
            enq.FName = 0
        Else
            enq.FName = txtFName.Text.Trim
        End If

        If cmbERelates.SelectedValue = "0" Then
            enq.ERelates = 0
        Else
            enq.ERelates = cmbERelates.SelectedItem.Text.Trim
        End If
        enq.NicNo = txtNicNo.Text

        Dim dt As New DataTable
        dt = BAL.GetEnquiry(enq)
        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            lblErrorMsg.Text = "No records to display."
            msgInfo.Text = ""
        Else
            msgInfo.Visible = True
            GridView1.Visible = True
            GridView1.DataSource = dt
            GridView1.DataBind()
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       
        If Not IsPostBack Then
            If Page.Request.UrlReferrer.AbsolutePath.Contains("frmEnquiryLogin.aspx") Then
                Session("HF") = "True"
            End If
        End If
        If Session("StatusEnquiry") = "In" Then
            Lblheading.Text = "GENERAL ENQUIRY"
            GridView1.Columns(0).Visible = False
            btnDetails.Visible = True
        Else
            Dim heading As String
            heading = Session("RptFrmTitleName")
            Me.Lblheading.Text = heading
        End If
        Try
            lblErrorMsg.Text = ""
            msgInfo.Text = ""
            If Not IsPostBack Then
                ddlBranch.SelectedValue = Trim(Session("BranchCode"))
                ddlBranch.Focus()
                If Session("GStatus") = "EDIT" Then
                    txtID.Text = Request.QueryString.Get("EID").ToString
                    btnSave.Text = "UPDATE"
                    btnDetails.Text = "CANCEL"
                    ddlBranch.SelectedValue = Session("BranchCode")
                Else
                    txtDate.Text = Format(Today, "dd-MMM-yyyy")
                    Me.lblenquiryno.Visible = False
                    Me.txtenquiryno.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        'If Not IsPostBack Then
        '    If Page.Request.UrlReferrer.AbsolutePath.Contains("frmenquirylogin.aspx") Then
        '        Session("HF") = "True"
        '    End If
        'End If
        'If Session("StatusEnquiry") = "In" Then
        '    Me.MasterPageFile = "~/Enquiry.master"
        'Else
        '    Me.MasterPageFile = "~/Home.master"
        'End If
        ''If Session("HF") = "True" Then
        ''    ' we can select a different master page in the PreInit event

        ''Else


        ''End If
        ''MsgBox(Session("BranchCode"))
        'MyBase.ValidateFormView("Enquiry")
    End Sub
    Protected Sub cmbERelates_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbERelates.SelectedIndexChanged
        lblErrorMsg.Text = ""
        msgInfo.Text = ""
        CmbCourseSelection()
    End Sub
    Sub CmbCourseSelection()
        'Changed by Nakul to disable coursetype and coursename for career selection
        'on 23/7/2012
        If cmbERelates.SelectedItem.Value = "Career" Then
            ddlCourse.Visible = False
            cmbCourseType.Visible = False
            Label11.Visible = False
            Label12.Visible = False

        Else
            cmbCourseType.Visible = True
            ddlCourse.Visible = True
            Label11.Visible = True
            Label12.Visible = True
        End If

    End Sub
    Protected Sub cmbCourseType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCourseType.SelectedIndexChanged
        lblErrorMsg.Text = ""
        msgInfo.Text = ""
        ddlCourse.Items.Clear()
    End Sub
    Sub Enable_CourseType()
        lblErrorMsg.Text = ""
        msgInfo.Text = ""
        cmbCourseType.Visible = True
        ddlCourse.Visible = True
        Label11.Visible = True
        Label12.Visible = True
    End Sub
    Sub Disable_CourseType()
        lblErrorMsg.Text = ""
        msgInfo.Text = ""
        cmbCourseType.Visible = False
        ddlCourse.Visible = False
        Label11.Visible = False
        Label12.Visible = False
    End Sub
    Sub clear1()
        Me.txtDate.Text = Format(Today, "dd-MMM-yyyy")
        txtNicNo.Text = ""
        Me.txtAddress.Text = ""
        Me.TxtCity.Text = ""
        Me.TxtPnCode.Text = ""
        Me.TxtDistrict.Text = ""
        Me.txtCountry.Text = ""
        Me.txtEmail.Text = ""
        Me.txtEnquiry.Text = ""
        Me.txtFName.Text = ""
        Me.txtMobile.Text = ""
        Me.txtPhone.Text = ""
        Me.txtQ.Text = ""
        'Me.txtcaste.Text = ""
        Me.txtenquirer.Text = ""
        Me.txtfathersname.Text = ""
        Me.txtoccupation.Text = ""
        Me.txtannualincome.Text = ""
        Me.txtenquiryno.Text = ""
        txtDOB.Text = ""
        txtage.Text = ""
        txtEnqno.Text = ""
        txtmarks.Text = ""
    End Sub
    Sub Clear()
        Me.txtDate.Text = Format(Today, "dd-MMM-yyyy")
        Me.txtAddress.Text = ""
        Me.TxtCity.Text = ""
        Me.TxtPnCode.Text = ""
        Me.TxtDistrict.Text = ""
        Me.txtCountry.Text = ""
        Me.txtEmail.Text = ""
        Me.txtEnquiry.Text = ""
        Me.txtFName.Text = ""
        Me.txtMobile.Text = ""
        Me.txtPhone.Text = ""
        Me.txtQ.Text = ""
        'Me.txtcaste.Text = ""
        Me.txtenquirer.Text = ""
        Me.txtfathersname.Text = ""
        Me.txtoccupation.Text = ""
        Me.txtannualincome.Text = ""
        Me.txtenquiryno.Text = ""
        txtDOB.Text = ""
        txtage.Text = ""
        txtEnqno.Text = ""
        txtNicNo.Text = ""
        txtmarks.Text = ""
    End Sub

    'Protected Sub GridView1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.Load
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "callFunctionsStartupScript", "grid();", True)
    'End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Try
            'If (Session("BranchCode") = Session("ParentBranch")) Then 'Preeti Dewan
            Dim brc As String = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblBranchCode"), Label).Text
            If Session("BranchCode") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblBranchCode"), Label).Text.Trim Then
                lblErrorMsg.Text = ""
                msgInfo.Text = ""
                Dim s As String = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelBid"), Label).Text.Trim
                ddlBranch.SelectedValue = s
                txtDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbldate"), Label).Text.Trim
                txtEnqno.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label22"), Label).Text.Trim
                cmbTitle.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text.Trim
                txtFName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text.Trim
                txtAddress.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label7"), Label).Text.Trim
                TxtCity.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labelcty"), Label).Text.Trim
                TxtPnCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labelpc"), Label).Text.Trim
                TxtDistrict.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labeldt"), Label).Text.Trim
                ddlState.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labelstt"), Label).Text.Trim
                txtCountry.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text.Trim
                txtPhone.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label9"), Label).Text.Trim
                txtMobile.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelMob"), Label).Text.Trim
                txtcaste.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelCst"), Label).Text.Trim
                txtfathersname.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblfathersname"), Label).Text.Trim
                txtmarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblMarks"), Label).Text.Trim
                ddlcategry.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCategory"), Label).Text.Trim
                If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDOB"), Label).Text = "" Then
                    txtDOB.Text = ""
                    txtage.Text = ""
                Else
                    txtDOB.Text = Format(CDate(CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDOB"), Label).Text.Trim), "dd-MMM-yyyy")
                    txtage.Text = Convert.ToInt32(DateDiff(DateInterval.Year, CDate(Me.txtDOB.Text.Trim), Today))
                End If
                txtenquirer.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("labelcon"), Label).Text.Trim
                txtNicNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblNicNo"), Label).Text.Trim
                txtenquiryno.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("labelenq"), Label).Text.Trim
                txtoccupation.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("labelfat"), Label).Text.Trim
                txtannualincome.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelAnn"), Label).Text.Trim
                txtEmail.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label8"), Label).Text.Trim
                txtQ.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelQual"), Label).Text.Trim
                cmbERelates.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text.Trim
                If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblHostel"), Label).Text.Trim() = "N" Then
                    ChkHostel.Checked = False
                Else
                    ChkHostel.Checked = True
                End If
                If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblTransport"), Label).Text.Trim() = "N" Then
                    ChkTransport.Checked = False
                Else
                    ChkTransport.Checked = True
                End If

                'Changed by Nakul to disable coursetype and coursename for career selection
                'on 23/7/2012
                If cmbERelates.SelectedItem.Value = "Career" Then
                    ddlCourse.Visible = False
                    cmbCourseType.Visible = False
                    Label11.Visible = False
                    Label12.Visible = False

                Else
                    cmbCourseType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelCtt"), Label).Text.Trim
                    ddlCourse.Items.Clear()
                    ddlCourse.DataSourceID = "ObjCourse"
                    ddlCourse.DataBind()
                    ddlCourse.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelCc"), Label).Text.Trim
                    Enable_CourseType()
                End If
                ddlSource.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labelso"), Label).Text.Trim

                txtEnquiry.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label6"), Label).Text.Trim
                If CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelPG"), Label).Text = "Y" Then
                    RadioButtonList1.SelectedValue = -1
                Else
                    RadioButtonList1.SelectedValue = 0
                End If
                ViewState("EID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
                enq.Branchid = s
                enq.FName = txtFName.Text.Trim
                enq.NicNo = txtNicNo.Text
                enq.ERelates = cmbERelates.SelectedItem.Text.Trim
                btnSave.Text = "UPDATE"
                btnDetails.Text = "BACK"
                enq.Id = ViewState("EID")
                Dim dt As New DataTable
                dt = BAL.GetEnquiry(enq)
                GridView1.Visible = True
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Enabled = False
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
                msgInfo.Text = ""
            End If
            'Else
            'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
            'msgInfo.Text = ""
            'End If
        Catch ex As Exception
            lblErrorMsg.Text = "Error in data, cannot be edited."
            msgInfo.Text = ""
        End Try
    End Sub
    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim qrystring As String = "Acknowledgement"
            Dim heading As String = "Acknowledgement"
            Dim EnqNo As String = CType(GridView1.Rows(e.NewSelectedIndex).Cells(2).FindControl("Label22"), Label).Text
            Dim EnqFor As String = CType(GridView1.Rows(e.NewSelectedIndex).Cells(2).FindControl("Label5"), Label).Text
            Dim BranchName As String = CType(GridView1.Rows(e.NewSelectedIndex).Cells(2).FindControl("LabelBranch"), Label).Text
            Dim Name As String = CType(GridView1.Rows(e.NewSelectedIndex).Cells(2).FindControl("Label3"), Label).Text
            Dim Phone As String = CType(GridView1.Rows(e.NewSelectedIndex).Cells(2).FindControl("LabelMob"), Label).Text
            Dim Email As String = CType(GridView1.Rows(e.NewSelectedIndex).Cells(2).FindControl("Label8"), Label).Text
            Dim caste As String = IIf(CType(GridView1.Rows(e.NewSelectedIndex).Cells(2).FindControl("lblcaste"), Label).Text = " ", "-", CType(GridView1.Rows(e.NewSelectedIndex).Cells(2).FindControl("lblcaste"), Label).Text)
            qrystring = "FrmAcknowledgement.aspx?=" & "&EnqNo=" & EnqNo & "&BranchName=" & BranchName & "&Name=" & Name & "&Phone=" & Phone & "&Email=" & Email & "&caste=" & caste & "&EnqFor=" & EnqFor ' & QueryStr.Querystring()
            'Response.Redirect("FrmAcknowledgement.aspx?QS=" & qrystring & "&heading=" & heading & "&EnqNo=" & EnqNo & "&BranchName=" & BranchName & "&Name=" & Name & "&Phone=" & Phone & "&Email=" & Email & "&caste=" & caste)
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=no,location=no,resizable =yes,width=800,height=400,left=200,top=100')</script>", False)
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot Acknowledge data."
            msgInfo.Text = ""
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblErrorMsg.Text = ""
            msgInfo.Text = ""
            'Dim brc As String = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblBranchCode"), Label).Text
            Dim brc As String = (CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("lblBranchCode"), Label).Text)

            If Session("BranchCode") = (CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("lblBranchCode"), Label).Text).Trim Then
                Try
                    GridView1.SelectedIndex = -1
                    'Dim enq As New Enquiry
                    ViewState("EID") = CType(GridView1.Rows(e.RowIndex).Cells(2).FindControl("IID"), HiddenField).Value
                    enq.Id = ViewState("EID")
                    Dim enqry As New EnquiryManager
                    Dim Branchid As String
                    If ddlBranch.SelectedValue = "0" Then
                        Branchid = 0
                    Else
                        Branchid = ddlBranch.SelectedItem.Value
                    End If
                    enqry.ChangeFlag(enq, Branchid)
                    msgInfo.Text = "Data deleted successfully."
                    lblErrorMsg.Text = ""
                    GridView1.Visible = True
                    ddlBranch.Focus()
                    enq.Branchid = ddlBranch.SelectedValue
                    enq.FName = 0
                    enq.ERelates = 0
                    enq.Id = 0
                    enq.NicNo = txtNicNo.Text
                    GridView1.PageIndex = ViewState("PageIndex")
                    Dim dt As New DataTable
                    dt = BAL.GetEnquiry(enq)
                    GridView1.Enabled = True
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    GridView1.Visible = True
                Catch
                    lblErrorMsg.Text = "Error Found in Delete Operation."
                    msgInfo.Text = ""
                End Try
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
                msgInfo.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            msgInfo.Text = ""
        End If
    End Sub
    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        lblErrorMsg.Text = ""
        msgInfo.Text = ""
        GridView1.Columns(1).Visible = True
        GridView1.SelectedIndex = -1
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        lblErrorMsg.Text = ""
        msgInfo.Text = ""
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Dim en As New Enquiry
        GridView1.Enabled = True
        If ddlBranch.SelectedValue = "0" Then
            en.Branchid = 0
        Else
            en.Branchid = ddlBranch.SelectedItem.Value
        End If
        If txtFName.Text = "" Then
            en.FName = 0
        Else
            en.FName = txtFName.Text.Trim
        End If

        If cmbERelates.SelectedValue = "0" Then
            en.ERelates = 0
        Else
            en.ERelates = cmbERelates.SelectedItem.Text.Trim
        End If
        en.NicNo = txtNicNo.Text
        Dim dt As New DataTable
        dt = BAL.GetEnquiry(en)
        GridView1.Visible = True
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.SelectedIndex = -1
    End Sub
    Protected Sub ddlBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.SelectedIndexChanged
        lblErrorMsg.Text = ""
        msgInfo.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub txtDOB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDOB.TextChanged
        Try
            Me.txtage.Text = Convert.ToInt32(DateDiff(DateInterval.Year, CDate(Me.txtDOB.Text.Trim), Today))
        Catch ex As Exception

        End Try
        txtDOB.Focus()
    End Sub
    Protected Sub ddlCourse_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.PreRender
        If ddlCourse.Items.Count > 0 Then
            If ddlCourse.Items(0).Text.Trim <> "Select" Then
                ddlCourse.Items.Insert(0, "Select")
            End If
        Else
            ddlCourse.Items.Insert(0, "Select")
        End If
    End Sub
    Protected Sub ddlBranch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.TextChanged
        ddlBranch.Focus()
    End Sub
    Protected Sub ddlCourse_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.TextChanged
        ddlCourse.Focus()
    End Sub
    Protected Sub ddlState_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlState.TextChanged
        ddlState.Focus()
    End Sub
    Protected Sub cmbCourseType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCourseType.TextChanged
        cmbCourseType.Focus()
    End Sub
    Protected Sub cmbERelates_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbERelates.TextChanged
        cmbERelates.Focus()
    End Sub
    Protected Sub cmbTitle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTitle.TextChanged
        cmbTitle.Focus()
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        RadioButtonList1.Focus()
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

        Dim en As New Enquiry
        GridView1.Enabled = True
        If ddlBranch.SelectedValue = "0" Then
            en.Branchid = 0
        Else
            en.Branchid = ddlBranch.SelectedItem.Value
        End If
        If txtFName.Text = "" Then
            en.FName = 0
        Else
            en.FName = txtFName.Text.Trim
        End If

        If cmbERelates.SelectedValue = "0" Then
            en.ERelates = 0
        Else
            en.ERelates = cmbERelates.SelectedItem.Text.Trim
        End If
        en.NicNo = txtNicNo.Text
        Dim dt As New DataTable
        dt = BAL.GetEnquiry(en)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
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

