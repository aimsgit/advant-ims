Imports System.Data.SqlClient
Imports System.Net.Mail.Attachment
'Imports System.Web.Mail
Imports System.Net
Imports System.Net.Mail

Partial Class FrmCRM
    Inherits BasePage
    Dim GlobalFunction As New GlobalFunction
    Dim a As Integer
    Dim El As New ELCRMLead
    'Dim Dl As New DLCRMLead
    Dim Bl As New BLCRMLead
    Dim dt As New DataTable
    Dim ElAppt As New ELAppointmentCRM
    Dim Dl As New DLAppointmentCRM
    Dim path, path1, str As String
    Dim id As New Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Lblheading.Text = Session("RptFrmTitleName")
        If Not IsPostBack Then
            ViewState("ImageTime") = ""
            ddlStatus.SelectedValue = "All"
            DDLDemoStatus.SelectedValue = "Demo"
            ddlProposalStatus.SelectedValue = "Proposal"
            ddlState.SelectedValue = 0
            txtFromDate.Text = Format(Today.Date, "dd-MMM-yyyy")
            txtToDate.Text = Format(Today.Date, "dd-MMM-yyyy")
            txtDemoDate.Text = Format(Today.Date, "dd-MMM-yyyy")
            txtProposalDate.Text = Format(Today.Date, "dd-MMM-yyyy")
            txtApptDate.Text = Format(Today.Date, "dd-MMM-yyyy")
            txtLeadDate.Text = Format(Today.Date, "dd-MMM-yyyy")
        End If
    End Sub
    Sub AssignEntity()
        Try
            El.LeadName = txtlead.Text
            El.Product = ddlproduct.SelectedValue
            El.PropectId = txtProspect.Text
            El.Address = txtAddress.Text
            If txtLeadDate.Text = "" Then
                El.LeadDate = "1/1/1900"
            Else
                El.LeadDate = txtLeadDate.Text
            End If
            El.State = ddlState.SelectedValue
            El.Country = txtCountry.Text
            El.Skypeid = Txtskype.Text
            El.Remarks = TxtRemarks.Text
            El.ContactNo = txtcontact.Text
            El.EmailID = txtEmail.Text
            El.LeadFrom = TxtLeadfrom.Text
            If txtEstimate.Text = "" Then
                El.EstimatedValue = 0.0
            Else
                El.EstimatedValue = txtEstimate.Text
            End If
            If TxtProbability.Text = "" Then
                El.Probability = 0.0
            Else
                El.Probability = TxtProbability.Text
            End If
        Catch ex As Exception
            lblmsginfo.Text = ""
            lblErrorMsg.Text = "Probability is not valid"
            Exit Sub
        End Try
        El.Status = ddlStatus.SelectedValue
    End Sub
    Sub Clear()
        txtlead.Text = ""
        txtLeadDate.Text = ""
        txtCountry.Text = ""
        Txtskype.Text = ""
        TxtRemarks.Text = ""
        ddlproduct.SelectedValue = ""
        txtProspect.Text = ""
        txtAddress.Text = ""
        txtcontact.Text = ""
        txtEmail.Text = ""
        TxtLeadfrom.Text = ""
        txtEstimate.Text = ""
        TxtProbability.Text = ""
        ddlStatus.SelectedValue = ""
        GVCRMLead.Focus()
    End Sub
    Sub Display()
        Try
            AssignEntity()
            dt.Clear()
            El.LeadID = 0
            dt = Bl.Display(El)
            dt = Bl.Display(El)
            If dt.Rows.Count > 0 Then
                GVCRMLead.DataSource = dt
                GVCRMLead.DataBind()
                GVCRMLead.Visible = True
                For Each rows As GridViewRow In GVCRMLead.Rows
                    If CType(rows.FindControl("lblLdDate"), Label).Text = "01-Jan-1900" Then
                        CType(rows.FindControl("lblLdDate"), Label).Text = ""
                    End If
                Next
                GVCRMLead.Visible = "true"
            Else
                lblErrorMsg.Text = "No records to display."
                lblmsginfo.Text = ""
                GVCRMLead.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If btnSave.Text = "ADD" Then
                    AssignEntity()
                    If El.Product = "All" Then
                        lblErrorMsg.Text = "Product field is mandatory."
                        lblmsginfo.Text = ""
                    Else

                        If El.Status = "All" Then
                            lblErrorMsg.Text = "Status should be Lead."
                            lblmsginfo.Text = ""
                        ElseIf El.Status = "Appointment" Then
                            lblErrorMsg.Text = "Status should be Lead."
                            lblmsginfo.Text = ""
                        ElseIf El.Status = "Demo" Then
                            lblErrorMsg.Text = "Status should be Lead."
                            lblmsginfo.Text = ""
                        ElseIf El.Status = "Proposal" Then
                            lblErrorMsg.Text = "Status should be Lead."
                            lblmsginfo.Text = ""
                        ElseIf El.Status = "Work order" Then
                            lblErrorMsg.Text = "Status should be Lead."
                            lblmsginfo.Text = ""
                        ElseIf El.Status = "Rollout" Then
                            lblErrorMsg.Text = "Status should be Lead."
                            lblmsginfo.Text = ""
                        Else
                            El.LeadID = 0
                            If Bl.InsertUpdate(El) > 0 Then
                                lblmsginfo.Text = "Data added successfully."
                                lblErrorMsg.Text = ""

                            Else
                                lblmsginfo.Text = ""
                                lblErrorMsg.Text = "Enter correct data."
                                GVCRMLead.Focus()
                            End If
                            Clear()
                            Display()
                        End If

                    End If
                Else
                    AssignEntity()
                    If El.Product = "All" Then
                        lblErrorMsg.Text = "Product field is mandatory."
                        lblmsginfo.Text = ""
                    Else
                        If El.Status = "All" Then
                            lblErrorMsg.Text = "Status should not be All."
                            lblmsginfo.Text = ""
                            'ElseIf El.Status = "Appointment" Then
                            '    lblErrorMsg.Text = "Status should be Lead."
                            '    lblmsginfo.Text = ""
                            'ElseIf El.Status = "Demo" Then
                            '    lblErrorMsg.Text = "Status should be Lead."
                            '    lblmsginfo.Text = ""
                            'ElseIf El.Status = "Proposal" Then
                            '    lblErrorMsg.Text = "Status should be Lead."
                            '    lblmsginfo.Text = ""
                            'ElseIf El.Status = "Work order" Then
                            '    lblErrorMsg.Text = "Status should be Lead."
                            '    lblmsginfo.Text = ""
                            'ElseIf El.Status = "Rollout" Then
                            '    lblErrorMsg.Text = "Status should be Lead."
                            '    lblmsginfo.Text = ""
                        Else
                            El.LeadID = ViewState("Leadid")
                            If Bl.InsertUpdate(El) > 0 Then
                                lblmsginfo.Text = "Data updated successfully."
                                lblErrorMsg.Text = ""
                            Else
                                lblmsginfo.Text = ""
                                lblErrorMsg.Text = "Enter correct data."
                                GVCRMLead.Focus()
                            End If
                            Clear()
                            Display()
                            GVCRMLead.Enabled = True
                            btnDetails.Text = "VIEW"
                            btnSave.Text = "ADD"
                        End If
                    End If
                End If
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
                lblmsginfo.Text = ""
            End If
        Catch ex As Exception
            lblmsginfo.Text = ""
            lblErrorMsg.Text = "Enter correct data."
            Me.Focus()
        End Try
        btnSave.Focus()
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        lblErrorMsg.Text = ""
        lblmsginfo.Text = ""
        If btnDetails.Text = "VIEW" Then
            Display()
        Else
            btnDetails.Text = "VIEW"
            btnSave.Text = "ADD"
            Display()
            Clear()
            GVCRMLead.Enabled = True
        End If
        btnDetails.Focus()
    End Sub
    Protected Sub GVCRMLead_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVCRMLead.PageIndexChanging
        GVCRMLead.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVCRMLead.PageIndex
        Display()
        GVCRMLead.Visible = True
    End Sub

    Protected Sub GVCRMLead_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVCRMLead.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Bl.Delete(CType(GVCRMLead.Rows(e.RowIndex).FindControl("lblLead_ID"), Label).Text)
                Display()
                lblErrorMsg.Text = ""
                lblmsginfo.Text = "Data deleted successfully."
            Else
                lblErrorMsg.Text = "You do not have permission, Cannot delete data."
                lblmsginfo.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsginfo.Text = ""
        End If
    End Sub

    Protected Sub GVCRMLead_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVCRMLead.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblErrorMsg.Text = ""
            lblmsginfo.Text = ""
            hidLeadid.Value = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblLead_ID"), Label).Text
            ViewState("Leadid") = hidLeadid.Value
            txtlead.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblLeadName"), Label).Text
            ddlproduct.SelectedValue = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblproduct"), Label).Text
            txtProspect.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblProspect"), Label).Text
            txtAddress.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblAddress"), Label).Text
            TxtLeadfrom.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblleadfrm"), Label).Text
            ddlState.SelectedValue = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblstat"), Label).Text
            TxtProbability.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblProbability"), Label).Text
            txtCountry.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblcountry"), Label).Text
            txtcontact.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblcontact"), Label).Text
            txtEmail.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblEmailID"), Label).Text
            txtLeadDate.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblLdDate"), Label).Text
            Txtskype.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblSkypeId"), Label).Text
            TxtRemarks.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblRemark"), Label).Text
            txtEstimate.Text = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblEstimatedValue"), Label).Text
            ddlStatus.SelectedValue = CType(GVCRMLead.Rows(e.NewEditIndex).FindControl("lblStatus1"), Label).Text
            btnDetails.Text = "BACK"
            btnSave.Text = "UPDATE"
            El.LeadID = hidLeadid.Value
            AssignEntity()
            dt.Clear()
            El.LeadID = hidLeadid.Value
            dt = Bl.Display(El)
            If dt.Rows.Count > 0 Then
                GVCRMLead.DataSource = dt
                GVCRMLead.DataBind()
                GVCRMLead.Enabled = False
                txtlead.Focus()
            Else
                lblErrorMsg.Text = "No records to display."
                lblmsginfo.Text = ""
                txtlead.Focus()
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data"
            lblmsginfo.Text = ""
        End If
    End Sub
    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'
    'Appointment Tab
    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'

    Protected Sub btn_Apptadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Apptadd.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then

                ElAppt.Adate = txtApptDate.Text
                ElAppt.Atime = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtApptTime.Text), DateFormat.ShortTime))
                ElAppt.AssingedToId = ddlApptAssignedto.SelectedValue
                ElAppt.Status = ddlApptStatus.SelectedValue
                ElAppt.Remarks = txtmsgAppt.Text
                ElAppt.LeadId = ddlLeadAppt.SelectedValue


                If btn_Apptadd.Text = "ADD" Then
                    Dim dt As New DataTable
                    dt = DLAppointmentCRM.CheckDuplicate(ElAppt)
                    If dt.Rows.Count > 0 Then
                        lblApptErrorMsg.Text = "Data already exists."
                        msgApptinfo.Text = ""
                    Else
                        Dl.Insert(ElAppt)
                        lblApptErrorMsg.Text = ""
                        msgApptinfo.Text = "Data Saved Successfully."
                        ElAppt.Leadname = " Select"
                        ElAppt.Empname = " Select"
                        txtApptTime.Text = ""
                        txtmsgAppt.Text = ""
                        ViewState("PageIndex") = 0
                        GVApptCrm.PageIndex = 0
                        DisplayGrid1()
                        txtApptDate.Text = Format(Today.Date, "dd-MMM-yyyy")
                    End If

                ElseIf btn_Apptadd.Text = "UPDATE" Then
                    ElAppt.Id = ViewState("id")
                    Dim dt As New DataTable
                    dt = DLAppointmentCRM.CheckDuplicate(ElAppt)
                    If dt.Rows.Count > 0 Then
                        lblApptErrorMsg.Text = "Data already exists."
                        msgApptinfo.Text = ""
                    Else
                        DLAppointmentCRM.Update(ElAppt)
                        msgApptinfo.Text = "Data Updated Successfully."
                        ElAppt.Id = 0
                        ElAppt.Leadname = " Select"
                        ElAppt.Empname = " Select"
                        txtApptTime.Text = ""
                        txtmsgAppt.Text = ""
                        lblErrorMsg.Text = ""
                        btn_Apptadd.Text = "ADD"
                        btn_Apptview.Text = "VIEW"
                        GVApptCrm.PageIndex = ViewState("PageIndex")
                        DisplayGrid1()
                        txtApptDate.Text = Format(Today.Date, "dd-MMM-yyyy")
                    End If

                End If
            Else
                lblApptErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
                msgApptinfo.Text = ""
            End If

            btn_Apptadd.Focus()
        Catch ex As Exception
            lblApptErrorMsg.Text = "Enter Correct Date/Time."
            msgApptinfo.Text = ""

        End Try
    End Sub

    Protected Sub btn_Apptview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Apptview.Click
        lblApptErrorMsg.Text = ""
        msgApptinfo.Text = ""
        'ViewState("BMID") = 0

        If btn_Apptview.Text = "VIEW" Then
            ViewState("PageIndex") = 0
            GVApptCrm.PageIndex = 0
            DisplayGrid()
            GVApptCrm.Visible = True
            txtApptTime.Text = ""
            txtmsgAppt.Text = ""
        ElseIf btn_Apptview.Text = "BACK" Then
            btn_Apptadd.Text = "ADD"
            btn_Apptview.Text = "VIEW"
            GVApptCrm.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            GVApptCrm.Visible = True
            txtApptTime.Text = ""
            txtmsgAppt.Text = ""
        End If
        btn_Apptview.Focus()
    End Sub

    Sub DisplayGrid()
        Dim dt As New DataTable
        'Dim Empname As New String
        'Dim Leadname, EmpName As String
        txtApptDate.Text = Format(Today.Date, "dd-MMM-yyyy")
        Calendar1.VisibleDate = Calendar1.TodaysDate
        ElAppt.Id = 0
        ElAppt.Leadname = ddlLeadAppt.SelectedItem.Text
        If ddlApptAssignedto.SelectedItem.Text <> " Select" Then

            Dim parts As String() = ddlApptAssignedto.SelectedItem.Text.Split(New Char() {":"})
            ElAppt.Empname = parts(0).ToString
            'Dim str As String = "ishan,training"
            'str = str.Split(",")(1)
            'Return st
            'Dim parts As String() = ddlFromBatch.SelectedValue.Split(New Char() {":"})
            'El.BatchId = parts(0).ToString
        Else
            ElAppt.Empname = " Select"
        End If

        dt = Dl.GetApptDetails(ElAppt.Id, ElAppt.Leadname, ElAppt.Empname)
        If dt.Rows.Count = 0 Then
            GVApptCrm.DataSource = Nothing
            GVApptCrm.DataBind()
            msgApptinfo.Text = ""
            lblApptErrorMsg.Text = "No records to display."

        Else
            GVApptCrm.DataSource = dt
            GVApptCrm.DataBind()
            GVApptCrm.Enabled = True
            GVApptCrm.Visible = True

        End If

    End Sub
    Sub DisplayGrid1()
        Dim dt As New DataTable
        'Dim Leadname, EmpName As String
        txtApptDate.Text = Format(Today.Date, "dd-MMM-yyyy")
        Calendar1.VisibleDate = Calendar1.TodaysDate
        dt = Dl.GetApptDetails(ElAppt.Id, ElAppt.Leadname, ElAppt.Empname)
        If dt.Rows.Count = 0 Then
            GVApptCrm.DataSource = Nothing
            GVApptCrm.DataBind()
            msgApptinfo.Text = ""
            lblApptErrorMsg.Text = "No records to display."

        Else
            GVApptCrm.DataSource = dt
            GVApptCrm.DataBind()
            GVApptCrm.Enabled = True
            GVApptCrm.Visible = True

        End If

    End Sub

    Protected Sub GVApptCrm_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVApptCrm.PageIndexChanging
        GVApptCrm.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVApptCrm.PageIndex
        DisplayGrid1()
    End Sub

    Protected Sub GVApptCrm_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVApptCrm.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ElAppt.Id = CType(GVApptCrm.Rows(e.RowIndex).Cells(1).FindControl("CAId"), HiddenField).Value
            If DLAppointmentCRM.Delete(ElAppt.Id) Then

                GVApptCrm.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                lblApptErrorMsg.Text = ""
                msgApptinfo.Text = "Data Deleted Successfully."
                GVApptCrm.Enabled = True
                txtApptDate.Text = Format(Today.Date, "dd-MMM-yyyy")
            End If
        Else
            lblApptErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            msgApptinfo.Text = ""
        End If
    End Sub

    Protected Sub GVApptCrm_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVApptCrm.RowEditing

        lblApptErrorMsg.Text = ""
        msgApptinfo.Text = ""
        ddlLeadAppt.SelectedValue = CType(GVApptCrm.Rows(e.NewEditIndex).FindControl("LeadId"), HiddenField).Value
        txtApptDate.Text = CType(GVApptCrm.Rows(e.NewEditIndex).FindControl("lblAdate"), Label).Text
        txtApptTime.Text = CType(GVApptCrm.Rows(e.NewEditIndex).FindControl("lblAtime"), Label).Text
        ddlApptAssignedto.SelectedValue = CType(GVApptCrm.Rows(e.NewEditIndex).FindControl("lblempid"), HiddenField).Value
        ddlApptStatus.SelectedValue = CType(GVApptCrm.Rows(e.NewEditIndex).FindControl("lblStatus"), Label).Text
        txtmsgAppt.Text = CType(GVApptCrm.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
        ViewState("id") = CType(GVApptCrm.Rows(e.NewEditIndex).FindControl("CAId"), HiddenField).Value
        btn_Apptadd.Text = "UPDATE"
        btn_Apptview.Text = "BACK"
        Dim dt As New DataTable
        'Dim Leadname, EmpName As String
        ElAppt.Id = ViewState("id")
        ElAppt.Leadname = ddlLeadAppt.SelectedItem.Text
        ElAppt.Empname = ddlApptAssignedto.SelectedItem.Text
        dt = Dl.GetApptDetails(ElAppt.Id, ElAppt.Leadname, ElAppt.Empname)
        GVApptCrm.DataSource = dt
        GVApptCrm.DataBind()
        GVApptCrm.Enabled = False

    End Sub

    Protected Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calendar1.DayRender
        Dim dt As New DataTable
        Try

            ElAppt.Id = 0
            'Dim Leadname, EmpName As String
            ElAppt.Leadname = ddlLeadAppt.SelectedItem.ToString
            Dim parts As String() = ddlApptAssignedto.SelectedItem.Text.Split(New Char() {":"})
            ElAppt.Empname = parts(0).ToString

            dt = Dl.GetApptDetails(ElAppt.Id, ElAppt.Leadname, ElAppt.Empname)
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("AppointmentDate")) Then
                        e.Cell.BackColor = System.Drawing.Color.Red
                        e.Cell.ForeColor = System.Drawing.Color.White

                        'lb.Text = dt.Rows(i).Item("HolidayName")
                        e.Cell.ToolTip = e.Day.DayNumberText + " " + dt.Rows(i).Item("LeadName")
                        'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))

                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub btn_Apptsendmail_click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_Apptsendmail.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim vm As String
            Dim parm_msg, parm_phonesp, parm_msgfrm, parm_sentdate, parm_mode, parm_branchcode As SqlParameter
            Dim dt As New DataTable
            Dim count As Integer
            count = 0
            Dim id As String
            id = ""
            Try
                For Each grid As GridViewRow In GVApptCrm.Rows
                    If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then

                        id = CType(grid.FindControl("CAId"), HiddenField).Value.ToString + "," + id
                        count = count + 1

                    End If
                Next
                id = Left(id, id.Length - 1)
                dt = Dl.GetCommunication(id)

                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim ToPhone As String
                        Dim Message As String
                        Dim SentDate As Date
                        Dim MsgFrom As String
                        Dim Mode As String
                        Dim branchcode As String

                        SentDate = dt.Rows(i)("Date")
                        Message = dt.Rows(i)("Message")
                        MsgFrom = dt.Rows(i)("MsgFrom")
                        ToPhone = dt.Rows(i)("EmilID")
                        Mode = dt.Rows(i)("Mode")
                        branchcode = dt.Rows(i)("Branchcode")


                        Dim connection As New SqlClient.SqlConnection()
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
                        connection.Open()
                        Dim cmd As New SqlCommand()
                        vm = "insert into Outbox_tbl (ToPhone,Message,prefix,SentDate,CommunicationMode,Branchcode) values(@ToPhone,@Message,@MsgFrom,@SentDate,@Mode,@Branchcode)"

                        cmd.Connection = connection
                        cmd.CommandText = vm
                        parm_phonesp = New SqlParameter
                        parm_phonesp.ParameterName = "@ToPhone"
                        parm_phonesp.Value = ToPhone
                        parm_phonesp.DbType = DbType.String
                        cmd.Parameters.Add(parm_phonesp)

                        parm_msg = New SqlParameter
                        parm_msg.ParameterName = "@Message"
                        parm_msg.Value = Message
                        parm_msg.DbType = DbType.String
                        cmd.Parameters.Add(parm_msg)

                        parm_msgfrm = New SqlParameter
                        parm_msgfrm.ParameterName = "@MsgFrom"
                        parm_msgfrm.Value = MsgFrom
                        parm_msgfrm.DbType = DbType.String
                        cmd.Parameters.Add(parm_msgfrm)

                        parm_sentdate = New SqlParameter
                        parm_sentdate.ParameterName = "@SentDate"
                        parm_sentdate.Value = SentDate
                        parm_sentdate.DbType = DbType.Date
                        cmd.Parameters.Add(parm_sentdate)

                        parm_mode = New SqlParameter
                        parm_mode.ParameterName = "@Mode"
                        parm_mode.Value = Mode
                        parm_mode.DbType = DbType.String
                        cmd.Parameters.Add(parm_mode)

                        parm_branchcode = New SqlParameter
                        parm_branchcode.ParameterName = "@Branchcode"
                        parm_branchcode.Value = branchcode
                        parm_branchcode.DbType = DbType.String
                        cmd.Parameters.Add(parm_branchcode)

                        cmd.ExecuteNonQuery()

                    Next
                    msgApptinfo.Text = "Message Sent Successfully."
                    lblApptErrorMsg.Text = ""
                    For Each grid As GridViewRow In GVApptCrm.Rows
                        CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
                    Next
                Else
                    msgApptinfo.Text = ""
                    lblApptErrorMsg.Text = "Select Atleast one Record to send mail."
                End If
            Catch ex As Exception
                lblApptErrorMsg.Text = "Select Atleast one Record to send mail."
                msgApptinfo.Text = ""

            End Try
        Else
            lblApptErrorMsg.Text = "You do not belong to this branch, Cannot send mail."
            msgApptinfo.Text = ""
        End If

    End Sub

    Protected Sub Calendar1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Calendar1.SelectionChanged
        'Dim str As System.Drawing.Color = Calendar1.SelectedDayStyle.BackColor

        Dim dt As New DataTable
        'Dim Leadname, EmpName As String
        ElAppt.Id = 0
        ElAppt.Leadname = ddlLeadAppt.SelectedItem.Text
        ElAppt.Empname = ddlApptAssignedto.SelectedItem.Text
        ElAppt.Status = ddlApptStatus.SelectedItem.Text
        id = 0

        dt = Dl.GetApptDetails(ElAppt.Id, ElAppt.Leadname, ElAppt.Empname)
        If (dt.Rows.Count > 0) Then
            For i As Integer = 0 To dt.Rows.Count - 1

                If (dt.Rows(i).Item("AppointmentDate")) = Calendar1.SelectedDate Then
                    Dim qrystring As String = "frmApptDrillDown.aspx?" & QueryStr.Querystring() & "&Selecteddate=" & Calendar1.SelectedDate & "&Status=" & ddlApptStatus.SelectedValue & "&id=" & id
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
                End If
            Next
        End If
        'Dim data As Date = Calendar1.SelectedDate
        'Dim qrystring As String = "frmApptDrillDown.aspx?" & QueryStr.Querystring() & "&e.Day.Date=" & Calendar1.SelectedDate
        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
        'End If
    End Sub

    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'
    'Demo Tab
    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'
    Protected Sub DemoCalender_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles DemoCalender.DayRender
        Try
            El.LeadID = 0
            El.DemoDate = Nothing
            El.DemoTime = Nothing
            El.AssignedTo = 0
            El.Status = DDLDemoStatus.SelectedValue
            El.DemoReport = ""
            El.DemoID = 0
            dt = Bl.GetDemoDetails(El)
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If (e.Day.Date = dt.Rows(i).Item("AppointmentDate")) Then
                        e.Cell.BackColor = System.Drawing.Color.Red
                        e.Cell.ForeColor = System.Drawing.Color.White
                        e.Cell.ToolTip = e.Day.DayNumberText + " " + dt.Rows(i).Item("LeadName")
                        'e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("LeadName")
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub AssignEntityDemo()
        El.LeadID = DDLDemoLead.SelectedValue
        If txtDemoDate.Text = "" Then
            El.DemoDate = Nothing
        Else
            El.DemoDate = txtDemoDate.Text
        End If
        If txtDemoTime.Text = "" Then
            El.DemoTime = Nothing
        Else
            El.DemoTime = CStr(Now.Date) + " " + txtDemoTime.Text
        End If
        El.AssignedTo = DDLAssignedTo.SelectedValue
        El.Status = DDLDemoStatus.SelectedValue
        El.DemoReport = txtDemoReport.Text
        El.DemoID = 0
    End Sub
    Sub ClearDemo()
        txtDemoDate.Text = ""
        txtDemoTime.Text = ""
        txtDemoReport.Text = ""
        GVDemo.Focus()
    End Sub
    Sub DisplayDemo()
        Try
            AssignEntityDemo()
            dt.Clear()
            El.DemoID = 0
            dt = Bl.GetDemoDetails(El)
            If dt.Rows.Count > 0 Then
                GVDemo.DataSource = dt
                GVDemo.DataBind()
                GVDemo.Visible = True
                GVDemo.Focus()
            Else
                lblError.Text = "No records to display."
                lblcorrect.Text = ""
                GVDemo.Visible = False
            End If
            GVDemo.Enabled = True
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If btnAdd.Text = "ADD" Then
                    AssignEntityDemo()
                    If Bl.InsertUpdateDemo(El) > 0 Then
                        lblcorrect.Text = "Data added successfully."
                        lblError.Text = ""
                    Else
                        lblcorrect.Text = ""
                        lblError.Text = "Enter correct data."
                        GVDemo.Focus()
                    End If
                    ClearDemo()
                    DisplayDemo()
                Else
                    AssignEntityDemo()
                    El.DemoID = HidDemoID.Value
                    If Bl.InsertUpdateDemo(El) > 0 Then
                        lblcorrect.Text = "Data updated successfully."
                        lblError.Text = ""
                    Else
                        lblcorrect.Text = ""
                        lblError.Text = "Enter correct data."
                        GVDemo.Focus()
                    End If
                    ClearDemo()
                    DisplayDemo()
                End If
                GVCRMLead.Enabled = True
                btnView.Text = "VIEW"
                btnAdd.Text = "ADD"
            Else
                lblError.Text = "You do not belong to this branch, Cannot add/update data."
                lblcorrect.Text = ""
            End If
        Catch ex As Exception
            lblcorrect.Text = ""
            lblError.Text = "Enter correct data."
            Me.Focus()
        End Try
        btnAdd.Focus()
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
            lblError.Text = ""
            lblcorrect.Text = ""
            If btnView.Text = "VIEW" Then
                DisplayDemo()
            Else
                btnView.Text = "VIEW"
                btnAdd.Text = "ADD"
                DisplayDemo()
                ClearDemo()
                GVDemo.Enabled = True
            End If
        Catch ex As Exception

        End Try
        btnView.Focus()
    End Sub

    Protected Sub GVDemo_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVDemo.PageIndexChanging
        GVDemo.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVDemo.PageIndex
        DisplayDemo()
    End Sub

    Protected Sub GVDemo_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVDemo.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                lblcorrect.Text = " "
                lblError.Text = " "
                El.DemoID = CType(GVDemo.Rows(e.RowIndex).FindControl("lblCOAutoId"), Label).Text
                Bl.DeleteDemo(El.DemoID)
                dt.Clear()
                lblcorrect.Text = "Data Deleted Successfully."
                lblError.Text = ""
                AssignEntityDemo()
                dt = Bl.GetDemoDetails(El)
                GVDemo.DataSource = dt
                GVDemo.DataBind()
            Catch ex As Exception

            End Try
        Else
            lblError.Text = "You do not belong to this branch, Cannot delete data."
            lblcorrect.Text = ""
        End If
    End Sub

    Protected Sub GVDemo_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVDemo.RowEditing
        Try
            DDLDemoLead.Text = CType(GVDemo.Rows(e.NewEditIndex).FindControl("lblLead_ID"), Label).Text
            txtDemoDate.Text = CType(GVDemo.Rows(e.NewEditIndex).FindControl("lblDemoDate"), Label).Text
            txtDemoTime.Text = CType(GVDemo.Rows(e.NewEditIndex).FindControl("lblDemoTime"), Label).Text
            DDLAssignedTo.Text = CType(GVDemo.Rows(e.NewEditIndex).FindControl("lblAssignedToID"), Label).Text
            DDLDemoStatus.Text = CType(GVDemo.Rows(e.NewEditIndex).FindControl("lblStatus"), Label).Text
            txtDemoReport.Text = CType(GVDemo.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
            lblcorrect.Text = " "
            lblError.Text = " "
            El.DemoID = CType(GVDemo.Rows(e.NewEditIndex).FindControl("lblCOAutoId"), Label).Text
            HidDemoID.Value = CType(GVDemo.Rows(e.NewEditIndex).FindControl("lblCOAutoId"), Label).Text
            dt.Clear()
            AssignEntityDemo()
            dt = Bl.GetDemoDetails(El)
            GVDemo.DataSource = dt
            GVDemo.DataBind()
            GVDemo.Enabled = False
            btnAdd.Text = "UPDATE"
            btnView.Text = "BACK"
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub DemoCalender_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DemoCalender.SelectionChanged
        Try
            dt.Clear()
            El.LeadID = 0
            El.DemoDate = DemoCalender.SelectedDate
            El.DemoTime = Nothing
            El.AssignedTo = 0
            El.Status = DDLDemoStatus.SelectedValue
            El.DemoReport = ""
            El.DemoID = 0
            id = 1
            dt = Bl.GetDemoDetails(El)
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If (dt.Rows(i).Item("AppointmentDate")) = DemoCalender.SelectedDate Then
                        Session("CRMStatus") = "Demo"
                        Dim qrystring As String = "frmApptDrillDown.aspx?" & QueryStr.Querystring() & "&SelectedDate=" & DemoCalender.SelectedDate & "&Status=" & DDLDemoStatus.SelectedValue & "&id=" & id
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnSendmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendMail.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                Dim vm As String
                Dim parm_msg, parm_phonesp, parm_msgfrm, parm_sentdate, parm_mode, parm_branchcode As SqlParameter
                dt.Clear()
                Dim count As Integer
                count = 0
                Dim id As String
                id = ""
                Try
                    For Each grid As GridViewRow In GVDemo.Rows
                        If CType(grid.FindControl("CAId"), CheckBox).Checked = True Then

                            id = CType(grid.FindControl("lblCOAutoId"), Label).Text.ToString + "," + id
                            count = count + 1

                        End If
                    Next
                    id = Left(id, id.Length - 1)
                    dt = Bl.GetCommunication(id)

                    If dt.Rows.Count > 0 Then
                        For i As Integer = 0 To dt.Rows.Count - 1
                            Dim ToPhone As String
                            Dim Message As String
                            Dim SentDate As Date
                            Dim MsgFrom As String
                            Dim Mode As String
                            Dim branchcode As String

                            SentDate = dt.Rows(i)("Date")
                            Message = dt.Rows(i)("Message")
                            MsgFrom = dt.Rows(i)("MsgFrom")
                            ToPhone = dt.Rows(i)("EmilID")
                            Mode = dt.Rows(i)("Mode")
                            branchcode = dt.Rows(i)("Branchcode")

                            Dim connection As New SqlClient.SqlConnection()
                            connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
                            connection.Open()
                            Dim cmd As New SqlCommand()
                            vm = "insert into Outbox_tbl (ToPhone,Message,prefix,SentDate,CommunicationMode,Branchcode) values(@ToPhone,@Message,@MsgFrom,@SentDate,@Mode,@Branchcode)"

                            cmd.Connection = connection
                            cmd.CommandText = vm
                            parm_phonesp = New SqlParameter
                            parm_phonesp.ParameterName = "@ToPhone"
                            parm_phonesp.Value = ToPhone
                            parm_phonesp.DbType = DbType.String
                            cmd.Parameters.Add(parm_phonesp)

                            parm_msg = New SqlParameter
                            parm_msg.ParameterName = "@Message"
                            parm_msg.Value = Message
                            parm_msg.DbType = DbType.String
                            cmd.Parameters.Add(parm_msg)

                            parm_msgfrm = New SqlParameter
                            parm_msgfrm.ParameterName = "@MsgFrom"
                            parm_msgfrm.Value = MsgFrom
                            parm_msgfrm.DbType = DbType.String
                            cmd.Parameters.Add(parm_msgfrm)

                            parm_sentdate = New SqlParameter
                            parm_sentdate.ParameterName = "@SentDate"
                            parm_sentdate.Value = SentDate
                            parm_sentdate.DbType = DbType.Date
                            cmd.Parameters.Add(parm_sentdate)

                            parm_mode = New SqlParameter
                            parm_mode.ParameterName = "@Mode"
                            parm_mode.Value = Mode
                            parm_mode.DbType = DbType.String
                            cmd.Parameters.Add(parm_mode)

                            parm_branchcode = New SqlParameter
                            parm_branchcode.ParameterName = "@Branchcode"
                            parm_branchcode.Value = branchcode
                            parm_branchcode.DbType = DbType.String
                            cmd.Parameters.Add(parm_branchcode)
                            cmd.ExecuteNonQuery()

                        Next
                        lblcorrect.Text = "Message Sent Successfully."
                        lblError.Text = ""
                        For Each grid As GridViewRow In GVDemo.Rows
                            CType(grid.FindControl("CAId"), CheckBox).Checked = False
                        Next
                    Else
                        lblcorrect.Text = ""
                        lblError.Text = "Select Atleast one Record to send mail."
                    End If
                Catch ex As Exception
                    lblError.Text = "Select Atleast one Record to send mail."
                    lblcorrect.Text = ""
                End Try
            Catch ex As Exception

            End Try
            btnSendMail.Focus()
        Else
            lblError.Text = "You do not belong to this branch, Cannot send mail."
            lblcorrect.Text = ""
        End If
    End Sub
    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'
    'Proposal Tab
    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'
    Sub AssignEntityProposal()
        El.LeadID = ddlProposalLead.SelectedValue
        If txtProposalDate.Text = "" Then
            El.DemoDate = Nothing
        Else
            El.DemoDate = txtProposalDate.Text
        End If
        If txtProposalTime.Text = "" Then
            El.ProposalValue = Nothing
        Else
            El.ProposalValue = txtProposalTime.Text
        End If
        El.AssignedTo = ddlProposalAssignedto.SelectedValue
        El.Status = ddlProposalStatus.SelectedValue
        El.DemoReport = FTBProposalRemarks.Text
        El.Attachment = FileUpload1.FileName
        'El.DemoID = IIf(HidProposal.Value = "", 0, HidProposal.Value)
        If ViewState("ImageTime") = Nothing Then
            El.Attachment = ""
        Else
            El.Attachment = ViewState("ImageTime")
        End If
    End Sub
    Sub ClearProposal()
        txtProposalDate.Text = ""
        txtProposalTime.Text = ""
        FTBProposalRemarks.Text = ""
        GVProposal.Focus()
    End Sub
    Sub DisplayProposal()
        Try
            AssignEntityProposal()
            dt.Clear()
            El.DemoID = 0
            dt = Bl.GetProposalDetails(El)
            If dt.Rows.Count > 0 Then
                GVProposal.DataSource = dt
                GVProposal.DataBind()
                GVProposal.Visible = True
                GVProposal.Focus()
            Else
                lblProposalError.Text = "No records to display."
                lblProposalCorrect.Text = ""
                GVProposal.Visible = False
            End If
            GVDemo.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnProposalAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProposalAdd.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If btnProposalAdd.Text = "ADD" Then
                    AssignEntityProposal()
                    If Bl.InsertUpdateProposal(El) > 0 Then
                        lblProposalCorrect.Text = "Data added successfully."
                        lblProposalError.Text = ""
                    Else
                        lblProposalCorrect.Text = ""
                        lblProposalError.Text = "Enter correct data."
                        GVProposal.Focus()
                    End If
                    ClearProposal()
                    DisplayProposal()
                Else
                    AssignEntityProposal()
                    El.DemoID = HidProposal.Value
                    If Bl.InsertUpdateProposal(El) > 0 Then
                        lblProposalCorrect.Text = "Data updated successfully."
                        lblProposalError.Text = ""
                    Else
                        lblProposalCorrect.Text = ""
                        lblProposalError.Text = "Enter correct data."
                        GVProposal.Focus()
                    End If
                    ClearProposal()
                    DisplayProposal()
                End If
                GVProposal.Enabled = True
                btnProposalView.Text = "VIEW"
                btnProposalAdd.Text = "ADD"
            Else
                lblProposalError.Text = "You do not belong to this branch, Cannot add/update data."
                lblProposalCorrect.Text = ""
            End If
        Catch ex As Exception
            lblProposalCorrect.Text = ""
            lblProposalError.Text = "Enter correct data."
            Me.Focus()
        End Try
        btnProposalAdd.Focus()
    End Sub

    Protected Sub btnProposalView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProposalView.Click
        Try
            lblProposalError.Text = ""
            lblProposalCorrect.Text = ""
            If btnProposalView.Text = "VIEW" Then
                El.DemoID = 0
                DisplayProposal()
            Else
                btnProposalView.Text = "VIEW"
                btnProposalAdd.Text = "ADD"
                DisplayProposal()
                El.DemoID = 0
                ClearProposal()
                GVProposal.Enabled = True
            End If
        Catch ex As Exception

        End Try
        btnProposalView.Focus()
    End Sub

    Protected Sub ProposalCalendar_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles ProposalCalendar.DayRender
        dt.Clear()
        Try
            El.LeadID = 0
            El.DemoDate = Nothing
            El.DemoTime = Nothing
            El.AssignedTo = 0
            El.Status = ddlProposalStatus.SelectedValue
            El.DemoReport = ""
            El.DemoID = 0
            dt = Bl.GetProposalDetails(El)
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If (e.Day.Date = dt.Rows(i).Item("AppointmentDate")) Then
                        e.Cell.BackColor = System.Drawing.Color.Red
                        e.Cell.ForeColor = System.Drawing.Color.White
                        e.Cell.ToolTip = e.Day.DayNumberText + " " + dt.Rows(i).Item("LeadName")
                        'e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("LeadName")
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Protected Sub ProposalCalendar_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProposalCalendar.SelectionChanged
        Try
            dt.Clear()
            El.LeadID = 0
            El.DemoDate = Nothing
            El.DemoTime = Nothing
            El.AssignedTo = 0
            El.Status = ddlProposalStatus.SelectedValue
            El.DemoReport = ""
            El.DemoID = 0
            id = 2
            dt = Bl.GetProposalDetails(El)
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If (dt.Rows(i).Item("AppointmentDate")) = ProposalCalendar.SelectedDate Then
                        Session("CRMStatus") = "Proposal"
                        Dim qrystring As String = "frmApptDrillDown.aspx?" & QueryStr.Querystring() & "&SelectedDate=" & ProposalCalendar.SelectedDate & "&Status=" & ddlProposalStatus.SelectedValue & "&id=" & id
                        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub btnProposalmail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnProposalMail.Click
        Try
            dt.Clear()
            Dim count As Integer
            count = 0
            Dim id As String
            id = ""
            Try
                For Each grid As GridViewRow In GVProposal.Rows
                    If CType(grid.FindControl("CAId"), CheckBox).Checked = True Then

                        id = CType(grid.FindControl("lblCOAutoId1"), Label).Text.ToString + "," + id
                        count = count + 1

                    End If
                Next
                id = Left(id, id.Length - 1)
                dt = Bl.GetCommunication(id)

                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim ToPhone As String
                        Dim Message As String
                        Dim SentDate As Date
                        Dim MsgFrom As String
                        Dim Attachment As String

                        SentDate = dt.Rows(i)("Date")
                        Message = dt.Rows(i)("Message")
                        MsgFrom = dt.Rows(i)("MsgFrom")
                        ToPhone = Trim(dt.Rows(i)("EmilID"))
                        ToPhone = IIf(Left(ToPhone, 1) = ",", Right(ToPhone, ToPhone.Length - 1), ToPhone)
                        ToPhone = IIf(Right(ToPhone, 1) = ",", Left(ToPhone, ToPhone.Length - 1), ToPhone)
                        Attachment = dt.Rows(i)("Attachment")

                        'Try
                        '    Dim SmtpServer As New SmtpClient()
                        '    Dim mail As New System.Net.Mail.MailMessage()
                        '    SmtpServer.Credentials = New NetworkCredential(Session("EmailID"), Session("Password"))
                        '    SmtpServer.Port = 587
                        '    SmtpServer.Host = Session("SMTP")
                        '    mail = New System.Net.Mail.MailMessage()
                        '    mail.From = New MailAddress(ToPhone)
                        '    mail.To.Add(ToPhone)
                        '    mail.Subject = MsgFrom
                        '    mail.Body = Message
                        '    If IO.File.Exists(Server.MapPath(Attachment)) Then
                        '        Dim attach As New System.Net.Mail.Attachment(Server.MapPath(Attachment))
                        '        mail.Attachments.Add(attach)
                        '    End If
                        '    'Dim attach As New MailAttachment(Server.MapPath(Attachment))
                        '    'mail.Attachments.Add(attach)
                        '    SmtpServer.Send(mail)
                        '    lblProposalError.Text = ""
                        '    lblProposalCorrect.Text = "Mail sent successfully."
                        'Catch ex As Exception
                        '    lblProposalError.Text = "Error in sending Mail."
                        '    lblProposalCorrect.Text = ""
                        'End 
                        Try
                            Dim mail As MailMessage = New MailMessage()
                            mail.Bcc.Add(ToPhone)  'To Mail 
                            mail.From = New MailAddress(Session("EmailID"))
                            mail.Subject = MsgFrom
                            mail.Body = Message
                            mail.IsBodyHtml = True
                            Dim smtp As SmtpClient = New SmtpClient()
                            smtp.Host = Session("SMTP")
                            smtp.Port = 587
                            smtp.Credentials = New NetworkCredential(Session("EmailID").ToString, Session("Password").ToString)
                            smtp.EnableSsl = False
                            smtp.Send(mail)
                            lblProposalError.Text = ""
                            lblProposalCorrect.Text = ""
                            lblProposalError.Text = ""
                            lblProposalCorrect.Text = "Mail sent successfully."
                        Catch ex As Exception
                            lblProposalError.Text = ""
                            lblProposalCorrect.Text = ""
                            lblProposalError.Text = "Error in sending Mail."
                            lblProposalCorrect.Text = ""
                        End Try
                    Next
                    For Each grid As GridViewRow In GVProposal.Rows
                        CType(grid.FindControl("CAId"), CheckBox).Checked = False
                    Next
                Else
                    lblProposalCorrect.Text = ""
                    lblProposalError.Text = "Select Atleast one Record to send mail."
                End If
            Catch ex As Exception
                lblProposalError.Text = "Select Atleast one Record to send mail."
                lblProposalCorrect.Text = ""
            End Try
        Catch ex As Exception

        End Try
        btnProposalMail.Focus()
    End Sub

    Protected Sub GVProposal_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVProposal.PageIndexChanging
        If (Session("BranchCode") = Session("ParentBranch")) Then
            GVProposal.PageIndex = e.NewPageIndex
            ViewState("PageIndex") = GVProposal.PageIndex
            DisplayProposal()
        Else
            lblProposalError.Text = "You do not belong to this branch, Cannot add/update data."
            lblProposalCorrect.Text = ""
        End If
    End Sub
    Protected Sub GVProposal_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVProposal.RowDeleting
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                lblcorrect.Text = " "
                lblError.Text = " "
                AssignEntityProposal()
                El.DemoID = CType(GVProposal.Rows(e.RowIndex).FindControl("lblCOAutoId1"), Label).Text
                Bl.DeleteDemo(El.DemoID)
                DisplayProposal()
                lblProposalCorrect.Text = "Data Deleted successfully."
                lblProposalError.Text = ""
            Else
                lblProposalError.Text = "You do not belong to this branch, Cannot add/update data."
                lblProposalCorrect.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GVProposal_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVProposal.RowEditing
        Try
            Dim str As String

            Dim i As Integer = CType(GVProposal.Rows(e.NewEditIndex).FindControl("lblLead_ID"), Label).Text
            ddlProposalLead.SelectedValue = CType(GVProposal.Rows(e.NewEditIndex).FindControl("lblLead_ID"), Label).Text
            txtProposalDate.Text = CType(GVProposal.Rows(e.NewEditIndex).FindControl("lblDemoDate"), Label).Text
            str = CType(GVProposal.Rows(e.NewEditIndex).FindControl("lblDemoTime"), Label).Text
            str = str.Replace(",", "")
            txtProposalTime.Text = str
            ddlProposalAssignedto.SelectedValue = CType(GVProposal.Rows(e.NewEditIndex).FindControl("lblAssignedToID"), Label).Text
            ddlProposalStatus.SelectedValue = CType(GVProposal.Rows(e.NewEditIndex).FindControl("lblStatus"), Label).Text
            FTBProposalRemarks.Text = CType(GVProposal.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
            ViewState("ImageTime") = CType(GVProposal.Rows(e.NewEditIndex).FindControl("lblAttachement"), Label).Text.Trim
            txtPath.Text = CType(GVProposal.Rows(e.NewEditIndex).FindControl("lblAttachement"), Label).Text.Trim
            lblProposalCorrect.Text = " "
            lblProposalError.Text = " "
            dt.Clear()
            AssignEntityProposal()
            HidProposal.Value = CType(GVProposal.Rows(e.NewEditIndex).FindControl("lblCOAutoId1"), Label).Text
            El.DemoID = CType(GVProposal.Rows(e.NewEditIndex).FindControl("lblCOAutoId1"), Label).Text
            dt = Bl.GetProposalDetails(El)
            GVProposal.DataSource = dt
            GVProposal.DataBind()
            GVProposal.Enabled = False
            btnProposalAdd.Text = "UPDATE"
            btnProposalView.Text = "BACK"
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If FileUpload1.FileName <> "" Then
            If FileUpload1.FileName.Contains(".pdf") Then
                Try
                    If ViewState("ImageTime") <> Nothing Then
                        Dim Foto As String = Session("Path") + ViewState("ImageTime").ToString.Replace("~/", "")
                        If IO.File.Exists(Foto) Then
                            IO.File.Delete(Foto)
                        End If
                    End If
                    path = "A" & TimeOfDay.ToString().Replace("/", "").Replace(":", "") & ".pdf"
                    Me.FileUpload1.SaveAs(Server.MapPath("~/Images/" & path))
                    path1 = "~/Images/" & path
                    ViewState("ImageTime") = "~/Images/" & path
                    txtPath.Text = path1
                    lblProposalCorrect.Text = "Document Uploaded successfully."
                    lblProposalError.Text = ""
                Catch ex As Exception
                    lblProposalCorrect.Text = ""
                    lblProposalError.Text = "Error while Uploading Image. Please refresh the page and try once again."
                End Try
            Else
                lblProposalError.Text = "Upload PDF file."
                lblProposalCorrect.Text = ""
            End If
        Else
            lblProposalError.Text = "Browse to upload the file."
            lblProposalCorrect.Text = ""
        End If
        btnUpload.Focus()
    End Sub

    Protected Sub GVDemo_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GVDemo.RowUpdated

    End Sub
    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'
    'Work Order/Purchase Order Tab
    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'
    Protected Sub btnWOupdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWOupdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ElAppt.LeadId = ddlWOLead.SelectedValue
            ElAppt.Status = ddlWOStatus.SelectedValue
            If txtWOValue.Text = "" Then
                ElAppt.EstimatedValue = 0.0
            Else
                ElAppt.EstimatedValue = txtWOValue.Text
            End If
            If txtWOProbability.Text = "" Then
                ElAppt.Probability = 0.0
            Else
                ElAppt.Probability = txtWOProbability.Text
            End If
            If DLAppointmentCRM.UpdateWO(ElAppt) > 0 Then
                lblWOmsginfo.Text = "Data Updated Successfully."
                lblWOErrosmsg.Text = ""
                displayWO("")
                txtWOProbability.Text = ""
                txtWOValue.Text = ""
            Else
                lblWOErrosmsg.Text = "No records found to update."
                lblWOmsginfo.Text = ""
                displayWO("")

            End If
        Else
            lblWOErrosmsg.Text = "You do not belong to this branch, Cannot update data."
            lblWOmsginfo.Text = ""
        End If
        btnWOupdate.Focus()
    End Sub
    Sub displayWO(ByVal lead As String)
        Dim dt As New DataTable
        dt = Dl.GetWODetails(lead)
        If dt.Rows.Count > 0 Then
            GVWorkOrder.DataSource = dt
            GVWorkOrder.DataBind()
            GVWorkOrder.Visible = True
            GVWorkOrder.Focus()
        Else
            lblWOErrosmsg.Text = "No records to display."
            lblWOmsginfo.Text = ""
            GVWorkOrder.Visible = False
        End If
    End Sub

    Protected Sub btnWOview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnWOview.Click
        lblWOErrosmsg.Text = ""
        lblWOmsginfo.Text = ""

        If ddlWOLead.SelectedValue = 0 Then
            El.LeadName = ""
        Else
            El.LeadName = ddlWOLead.SelectedItem.Text
        End If
        displayWO(El.LeadName)
        btnWOview.Focus()

    End Sub

    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'
    'Pipeline Tab
    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'


    Protected Sub PIPELINE_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles PIPELINE.Load
        Dim dt, dt1 As New DataTable
        dt = Dl.GetPipelineDetails()
        dt1 = Dl.GetPipelineTotDetails()
        If dt.Rows.Count > 0 Then
            Dim Totcount As Integer
            Totcount = dt.Rows.Count
            GVPipeline.DataSource = dt
            GVPipeline.DataBind()
            GVPipeline.Visible = True
            GVPipeline.Focus()
            'sum = sum + dt.Rows(cnt).Item("EstimatedValue")
            lblcount.Text = Totcount.ToString
            lblSum.Text = Format(dt1.Rows(0).Item("TotEstValue"), "n2")
            lblPLErrormsg.Text = ""
            lblPLmsg.Text = ""
        Else
            lblPLErrormsg.Text = "No records to display."
            lblPLmsg.Text = ""
            GVPipeline.Visible = False
        End If
    End Sub
    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'
    'Alerts Tab
    '~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~''~~~~~~'

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Try
            Dim FromDate, ToDate As DateTime
            btnShow.Focus()
            dt.Clear()
            If txtFromDate.Text = "" Then
                FromDate = "1/1/1900"
            Else
                FromDate = txtFromDate.Text
            End If
            If txtToDate.Text = "" Then
                ToDate = "1/1/2900"
            Else
                ToDate = txtToDate.Text
            End If

            If CDate(ToDate) < CDate(FromDate) Then
                lblAlertError.Text = "ToDate cannot be less then FromDate."
                lblAlertCorrect.Text = ""
            Else

                dt = Bl.DisplayAlerts(CDate(FromDate), CDate(ToDate))
                If dt.Rows.Count > 0 Then
                    lblAlertError.Text = ""
                    lblAlertCorrect.Text = ""
                    GVAlerts.DataSource = dt
                    GVAlerts.DataBind()
                    GVAlerts.Visible = True
                Else
                    lblAlertError.Text = "No records to display."
                    lblAlertCorrect.Text = ""
                    GVAlerts.Visible = False
                End If
            End If
        Catch ex As Exception
            lblAlertError.Text = "Enter correct date."
            lblAlertCorrect.Text = ""
        End Try
        btnShow.Focus()
    End Sub

    Protected Sub GVAlerts_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVAlerts.RowDeleting
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                btnShow.Focus()
                lblcorrect.Text = " "
                lblError.Text = " "
                El.DemoID = CType(GVAlerts.Rows(e.RowIndex).FindControl("lblLead_ID"), Label).Text
                Bl.CloseAlert(El.DemoID)
                lblAlertError.Text = ""
                lblAlertCorrect.Text = "Status set to Close."
                dt.Clear()
                dt = Bl.DisplayAlerts(CDate(txtFromDate.Text), CDate(txtToDate.Text))
                If dt.Rows.Count > 0 Then
                    GVAlerts.DataSource = dt
                    GVAlerts.DataBind()
                    GVAlerts.Visible = True
                Else
                    GVAlerts.Visible = False
                End If
            Else
                lblAlertError.Text = "You do not belong to this branch, Cannot update data."
                lblAlertCorrect.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVCRMLead_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVCRMLead.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        AssignEntity()
        dt.Clear()
        El.LeadID = 0
        dt = Bl.Display(El)
        GVCRMLead.Visible = True
        GVCRMLead.Visible = "true"
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVCRMLead.DataSource = sortedView
        GVCRMLead.DataBind()

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

    Protected Sub GVApptCrm_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVApptCrm.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        Dim dt As New DataTable
        'Dim Leadname, EmpName As String
        txtApptDate.Text = Format(Today.Date, "dd-MMM-yyyy")
        Calendar1.VisibleDate = Calendar1.TodaysDate
        ElAppt.Id = 0
        ElAppt.Leadname = ddlLeadAppt.SelectedItem.Text
        ElAppt.Empname = ddlApptAssignedto.SelectedItem.Text

        dt = Dl.GetApptDetails(ElAppt.Id, ElAppt.Leadname, ElAppt.Empname)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVApptCrm.DataSource = sortedView
        GVApptCrm.DataBind()
        GVApptCrm.Enabled = True
        GVApptCrm.Visible = True
    End Sub

    Protected Sub GVDemo_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVDemo.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        AssignEntityDemo()
        dt.Clear()
        El.DemoID = 0
        dt = Bl.GetDemoDetails(El)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVDemo.DataSource = sortedView
        GVDemo.DataBind()
        GVDemo.Visible = True
        GVDemo.Focus()
    End Sub

    Protected Sub GVProposal_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVProposal.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        AssignEntityProposal()
        dt.Clear()
        El.DemoID = 0
        dt = Bl.GetProposalDetails(El)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVProposal.DataSource = sortedView
        GVProposal.DataBind()
        GVProposal.Visible = True
        GVProposal.Focus()
    End Sub

    Protected Sub GVWorkOrder_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVWorkOrder.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim LEAD As String
        If ddlWOLead.SelectedValue = 0 Then
            LEAD = ""
        Else
            LEAD = ddlWOLead.SelectedItem.Text
        End If
        Dim dt As New DataTable
        dt = Dl.GetWODetails(LEAD)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVWorkOrder.DataSource = sortedView
        GVWorkOrder.DataBind()
        GVWorkOrder.Visible = True
        GVWorkOrder.Focus()
    End Sub

    Protected Sub GVPipeline_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVPipeline.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt, dt1 As New DataTable
        dt = Dl.GetPipelineDetails()
        dt1 = Dl.GetPipelineTotDetails()
        Dim Totcount As Integer
        Totcount = dt.Rows.Count
        'sum = sum + dt.Rows(cnt).Item("EstimatedValue")
        lblcount.Text = Totcount.ToString
        lblSum.Text = Format(dt1.Rows(0).Item("TotEstValue"), "n2")
        lblPLErrormsg.Text = ""
        lblPLmsg.Text = ""
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVPipeline.DataSource = sortedView
        GVPipeline.DataBind()
        GVPipeline.Visible = True
        GVPipeline.Focus()
    End Sub

    Protected Sub GVAlerts_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVAlerts.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim FromDate, ToDate As DateTime
        btnShow.Focus()
        dt.Clear()
        If txtFromDate.Text = "" Then
            FromDate = "1/1/1900"
        Else
            FromDate = txtFromDate.Text
        End If
        If txtToDate.Text = "" Then
            ToDate = "1/1/2900"
        Else
            ToDate = txtToDate.Text
        End If

        If CDate(ToDate) < CDate(FromDate) Then
            lblAlertError.Text = "ToDate cannot be less then FromDate."
            lblAlertCorrect.Text = ""
        Else

            dt = Bl.DisplayAlerts(CDate(FromDate), CDate(ToDate))
            
        End If

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVAlerts.DataSource = sortedView
        GVAlerts.DataBind()
        GVAlerts.Visible = True
        lblAlertError.Text = ""
        lblAlertCorrect.Text = ""
    End Sub
End Class