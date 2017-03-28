
Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports Attendance
Imports System.Data.SqlClient

    'Author-->Anchala Verma
    'Date---->02-Mar-2012
    Partial Class frmStudAttenwitClasstype
        Inherits BasePage
        Dim dt As New DataTable
    Dim Bl As New StdAttendancewitclasstype
        Dim a As String
        Dim El As New StdAttendanceP
    Dim b As New BLNew_stdMarks
    Dim stdAttndance As New stdAttndance
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            lblmsg.Text = ""
            msginfo.Text = ""
        Try

            btnSubmit.Visible = True
            Session("ButtonType") = ""
            Dim heading As String
            heading = Session("RptFrmTitleName")
            Me.Lblheading.Text = heading
            If Not Page.IsPostBack Then
                TxtAttdate.Text = Format(Today, "dd-MMM-yyyy")
                ViewState("status") = "load"
                'cmbAcademic.Focus()
                ViewState("Updated") = "False"
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

            End If
        Catch ex As Exception

        End Try
        If Not IsPostBack Then
            ddlPeriod.SelectedValue = 1
        End If

        End Sub
        Sub Clear()
        'cmbAcademic.SelectedItem.Selected = False
            cmbBatch.SelectedItem.Selected = False
            cmbBatch.SelectedItem.Selected = False
            cmbSemester.SelectedItem.Selected = False
            ddlClasstype.SelectedItem.Selected = False
            cmbSubject.SelectedItem.Selected = False
        'TxtSessioncount.Text = ""
            ViewState("Updated") = "False"
        End Sub
        Sub AssignEntity()
        If ddlPeriod.SelectedValue = 0 Then
            El.SessionCountDay = ""
        Else
            El.SessionCountDay = ddlPeriod.SelectedValue
        End If
            ViewState("Updated") = "False"
        End Sub

        Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        'cmbAcademic.Focus()

            Try

                If (Session("BranchCode") = Session("ParentBranch")) Then
                    If btnSubmit.Text = "GENERATE" Then
                        btnSendMsg.Enabled = True
                    El.Academic = 0
                        El.Batch = cmbBatch.SelectedValue
                        El.SemesterId = cmbSemester.SelectedValue
                        El.SubjectId = cmbSubject.SelectedValue
                        El.ClassType = ddlClasstype.SelectedValue
                        El.AttendanceDate = Me.TxtAttdate.Text
                    El.SubGrp = ddlSubjectSubGrp.SelectedValue
                    dt = stdAttndance.GetBatch(El)
                    If dt.Rows(0).Item("Subgrp_Status") = "Y" Then
                        If ddlSubjectSubGrp.SelectedValue = 0 Then
                            msginfo.Text = "Please Select Subject Subgroup."
                            lblmsg.Text = ""
                            Exit Sub
                        End If
                    End If
                    AssignEntity()

                    If (El.AttendanceDate > Today()) Then
                        msginfo.Text = "Attendance Date cannot be greater than Today's Date."
                        lblmsg.Text = ""
                    Else

                        dt = Bl.AttendanceduplicateCT(El)
                        If dt.Rows.Count > 0 Then
                            msginfo.Visible = True
                            msginfo.Text = "Data Already Generated."
                            'cmbAcademic.Focus()
                            lblmsg.Text = ""
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

                        Else
                            Session("ButtonType") = "SUBMIT"
                            Bl.InsertAttandanceCT(El)
                            dt = Bl.GetByGVStdAttdCT(El)
                            lblmsg.Text = dt.Rows.Count().ToString + " records generated."
                            msginfo.Text = ""
                            display(El)
                            LinkButton.Focus()
                            'cmbAcademic.Focus()
                            'msginfo.Visible = False
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                        End If
                    End If
                End If
                ViewState("Updated") = "False"
            Else
                msginfo.Text = "You do not belong to this branch, Cannot submit data."
                lblmsg.Text = ""
            End If

            Catch ex As Exception
                msginfo.Text = "date is not valid."
                lblmsg.Text = ""
            End Try
        End Sub
        Sub display(ByVal EL As StdAttendanceP)
            pnllabel.Visible = True
            GVPanel.Visible = True
            Dim dt As New Data.DataTable
        dt = Bl.GetByGVStdAttdCT(EL)
            If dt.Rows.Count = 0 Then
                GVStdAttd.DataSource = Nothing
                GVStdAttd.DataBind()
                msginfo.Text = "No records to display."
                pnllabel.Visible = False
            'cmbAcademic.Focus()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

                lblmsg.Text = ""
                btnUpdate.Enabled = False
                btnLock.Enabled = False
            btnClear.Enabled = False
            btnSendMsg.Enabled = False
            Else
                ViewState("ConcatID") = ""
                Dim count As Integer = 0
                ViewState("CountID") = ""
                For i As Integer = 0 To dt.Rows.Count - 1
                    ViewState("ConcatID") = ViewState("ConcatID") + "," + dt.Rows(i).Item("Id").ToString
                    count = count + 1
                Next
                ViewState("CountID") = count
                If (ViewState("SortExpression") <> "") Then
                    Dim sortedView As New DataView(dt)
                    Dim s As String = ViewState("SortExpression") & " " & ViewState("sortingDirection")
                    sortedView.Sort = s
                    GVStdAttd.DataSource = sortedView
                    GVStdAttd.DataBind()
                Else
                    GVStdAttd.DataSource = dt
                    GVStdAttd.DataBind()
                End If

            lblAcademicYearAns.Text = ""
                lblBatchAns.Text = ""
                lblSemesterAns.Text = ""
                lblClassTypeAns.Text = ""
                lblSubjectAns.Text = ""
            lblAttendanceDateAns.Text = ""

                For Each grid As GridViewRow In GVStdAttd.Rows
                'lblAcademicYearAns.Text = CType(grid.FindControl("l1"), Label).Text
                    lblBatchAns.Text = CType(grid.FindControl("l2"), Label).Text
                    lblSemesterAns.Text = CType(grid.FindControl("l3"), Label).Text
                    lblClassTypeAns.Text = CType(grid.FindControl("l5"), Label).Text()
                    lblSubjectAns.Text = CType(grid.FindControl("l4"), Label).Text
                lblAttendanceDateAns.Text = CType(grid.FindControl("l6"), Label).Text
                    'lblPeriodNo.Text = CType(grid.FindControl("l7"), Label).Text
                    pnllabel.Visible = True

                    If CType(grid.FindControl("LabelPre"), Label).Text = "P" Then
                        CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True
                    Else
                        CType(grid.FindControl("ChkPresent"), CheckBox).Checked = False
                    End If
                Next
            If Bl.CheckLockAttendanceCT(ViewState("ConcatID")) = "Y" Then
                GVStdAttd.Enabled = False
            Else
                GVStdAttd.Enabled = True
            End If
                GVStdAttd.Visible = True
                btnUpdate.Enabled = True
                btnLock.Enabled = True
                btnSendMsg.Enabled = True
            btnClear.Enabled = True
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

            End If
            ViewState("Updated") = "False"
            dt.Dispose()
        End Sub

        <System.Web.Services.WebMethod()> Public Sub AbandonSession()
            Dim i As Int16 = UserDetailsDB.UpdateUserlog()
            Response.Redirect("LogIn.aspx")
        End Sub
        Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
            LinkButton.Focus()
            btnSendMsg.Enabled = True
        El.Academic = 0
            El.Batch = cmbBatch.SelectedValue
            El.SemesterId = cmbSemester.SelectedValue
            El.SubjectId = cmbSubject.SelectedValue
            El.ClassType = ddlClasstype.SelectedValue
            El.AttendanceDate = Me.TxtAttdate.Text
            El.SubGrp = ddlSubjectSubGrp.SelectedValue
            AssignEntity()
            display(El)
            ViewState("Updated") = "False"
        End Sub

        Protected Sub GVStdAttd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVStdAttd.PageIndexChanging
            GVStdAttd.PageIndex = e.NewPageIndex
            ViewState("PageIndex") = GVStdAttd.PageIndex
        El.Academic = 0
            El.Batch = cmbBatch.SelectedValue
            El.SemesterId = cmbSemester.SelectedValue
            El.SubjectId = cmbSubject.SelectedValue
            El.ClassType = ddlClasstype.SelectedValue
            El.AttendanceDate = Me.TxtAttdate.Text
            'If TxtSessioncount.Text = "" Then
            '    El.SessionCountDay = 0
            'Else
        El.SessionCountDay = ddlPeriod.SelectedValue
        'End If

            display(El)
            GVStdAttd.Visible = True
        End Sub
        Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
            If (Session("BranchCode") = Session("ParentBranch")) Then
            If Bl.CheckLockAttendanceCT(ViewState("ConcatID")) = "Y" Then
                msginfo.Text = ""
                lblmsg.Text = ""
                msginfo.Text = "Records are locked, cannot be updated."
                'cmbAcademic.Focus()
            Else
                For Each grid As GridViewRow In GVStdAttd.Rows
                    If CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True Then
                        El.Id = CType(grid.FindControl("IID"), HiddenField).Value
                        El.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                        El.Present = "P"
                        Bl.UpdateRecordCT(El)
                        lblmsg.Text = "Records Updated successfully."
                        ViewState("Updated") = "True"
                        'cmbAcademic.Focus()
                        'lblmsg.Visible = True
                        msginfo.Text = ""
                    Else
                        El.Id = CType(grid.FindControl("IID"), HiddenField).Value
                        El.Present = "A"
                        El.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                        Bl.UpdateRecordCT(El)
                        lblmsg.Text = "Records Updated successfully."
                        ViewState("Updated") = "True"
                        'cmbAcademic.Focus()
                        msginfo.Text = ""
                    End If
                Next
            End If
            Else
                msginfo.Text = "You do not belong to this branch, Cannot update data."
                lblmsg.Text = ""
            End If
        End Sub
        Sub CheckAll()
            If CType(GVStdAttd.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            El.Academic = 0
                El.Batch = cmbBatch.SelectedItem.Value
                El.SemesterId = cmbSemester.SelectedItem.Value
                El.SubjectId = cmbSubject.SelectedItem.Value
                El.ClassType = ddlClasstype.SelectedItem.Value
                El.AttendanceDate = Me.TxtAttdate.Text()
                AssignEntity()
                El.Present = "P"
            Bl.UpdateCollectionVerificationCT(El)
                For Each grid As GridViewRow In GVStdAttd.Rows
                    CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True
                Next
            Else
            El.Academic = 0
                El.Batch = cmbBatch.SelectedItem.Value
                El.SemesterId = cmbSemester.SelectedItem.Value
                El.SubjectId = cmbSubject.SelectedItem.Value
                El.ClassType = ddlClasstype.SelectedItem.Value
                El.AttendanceDate = Me.TxtAttdate.Text()
                AssignEntity()
                El.Present = "P"
            Bl.UpdateCollectionVerificationCT(El)
                For Each grid As GridViewRow In GVStdAttd.Rows
                    CType(grid.FindControl("ChkPresent"), CheckBox).Checked = False
                Next
            End If
        End Sub
        Sub DisplayGrid()
            pnllabel.Visible = True
            GVPanel.Visible = True
        El.Academic = 0
            El.Batch = cmbBatch.SelectedItem.Value
            El.SemesterId = cmbSemester.SelectedItem.Value
            El.SubjectId = cmbSubject.SelectedItem.Value
            El.ClassType = ddlClasstype.SelectedItem.Value
            El.AttendanceDate = Me.TxtAttdate.Text()
            El.SubGrp = ddlSubjectSubGrp.SelectedValue
            AssignEntity()
            Dim dt As New Data.DataTable
        dt = Bl.GetByGVStdAttdCT(El)
            If dt.Rows.Count = 0 Then
                GVStdAttd.DataSource = Nothing
                GVStdAttd.DataBind()
                msginfo.Text = "No records to display."
                pnllabel.Visible = False
                'msginfo.Visible = True
                lblmsg.Text = ""
            Else
                GVStdAttd.DataSource = dt
                GVStdAttd.DataBind()
            lblAcademicYearAns.Text = ""
                lblBatchAns.Text = ""
                lblSemesterAns.Text = ""
                lblClassTypeAns.Text = ""
                lblSubjectAns.Text = ""
            lblAttendanceDateAns.Text = ""
                For Each grid As GridViewRow In GVStdAttd.Rows
                'lblAcademicYearAns.Text = CType(grid.FindControl("l1"), Label).Text
                    lblBatchAns.Text = CType(grid.FindControl("l2"), Label).Text
                    lblSemesterAns.Text = CType(grid.FindControl("l3"), Label).Text
                    lblClassTypeAns.Text = CType(grid.FindControl("l5"), Label).Text()
                    lblSubjectAns.Text = CType(grid.FindControl("l4"), Label).Text
                lblAttendanceDateAns.Text = CType(grid.FindControl("l6"), Label).Text
                    'lblPeriodNo.Text = CType(grid.FindControl("l7"), Label).Text
                    pnllabel.Visible = True

                    If CType(grid.FindControl("LabelPre"), Label).Text = "P" Then
                        CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True
                    Else
                        CType(grid.FindControl("ChkPresent"), CheckBox).Checked = False

                    End If
                Next
                GVStdAttd.Visible = True
                'lblmsg.Visible = False
            End If
        End Sub

        Protected Sub btnLock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLock.Click
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Try
                    ViewState("Updated") = "True"
                El.Academic = 0
                    El.Batch = cmbBatch.SelectedItem.Value
                    El.SemesterId = cmbSemester.SelectedItem.Value
                    El.SubjectId = cmbSubject.SelectedItem.Value
                    El.ClassType = ddlClasstype.SelectedItem.Value
                    El.AttendanceDate = Me.TxtAttdate.Text()
                    El.SubGrp = ddlSubjectSubGrp.SelectedValue
                    AssignEntity()
                dt = Bl.GetByGVStdAttdCT(El)
                If dt.Rows(0).Item("Del_Flag") = "G" Then
                    msginfo.Text = "Update attendance before you Lock."
                    lblmsg.Text = ""
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

                    Exit Sub
                End If
                    If dt.Rows.Count > 0 Then
                        ViewState("ConcatID") = ""
                        For i As Integer = 0 To dt.Rows.Count - 1
                            ViewState("ConcatID") = ViewState("ConcatID") + "," + dt.Rows(i).Item("Id").ToString
                        Next
                        ControlsPanel.Visible = False
                        PasswordPanel.Visible = True
                        txtPassword.Focus()
                        lblpassError.Text = ""
                        Image1.Visible = False
                    Image2.Visible = False
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

                    Else
                        'Clear()
                        msginfo.Text = ""
                        lblmsg.Text = ""
                    msginfo.Text = "No Records to Lock/Unlock."
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                    'cmbAcademic.Focus()
                        Image1.Visible = True
                        Image2.Visible = True
                    End If
                    'End If
                Catch ex As Exception
                    'Clear()
                    msginfo.Text = ""
                    lblmsg.Text = ""
                    msginfo.Text = "Enter all mandatory fields."
                End Try
            Else
                msginfo.Text = "You do not belong to this branch, Cannot lock/unlock data."
                lblmsg.Text = ""
            End If
        End Sub

        Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Try
                    pnllabel.Visible = False
                El.Academic = 0
                    El.Batch = cmbBatch.SelectedItem.Value
                    El.SemesterId = cmbSemester.SelectedItem.Value
                    El.SubjectId = cmbSubject.SelectedItem.Value
                    El.ClassType = ddlClasstype.SelectedItem.Value
                    El.AttendanceDate = Me.TxtAttdate.Text()
                    El.SubGrp = ddlSubjectSubGrp.SelectedValue
                    AssignEntity()
                dt = Bl.GetByGVStdAttdCT(El)
                    If dt.Rows.Count > 0 Then
                        ViewState("ConcatID") = ""
                        For i As Integer = 0 To dt.Rows.Count - 1
                            ViewState("ConcatID") = ViewState("ConcatID") + "," + dt.Rows(i).Item("Id").ToString
                        Next
                    End If

                If Bl.CheckLockAttendanceCT(ViewState("ConcatID")) = "Y" Then
                    msginfo.Text = ""
                    lblmsg.Text = ""
                    msginfo.Text = "Records are locked, cannot be cleared."
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                    'cmbAcademic.Focus()
                    pnllabel.Visible = True
                Else
                    Dim clearcount As Integer = 0
                    Bl.ClearAttendanceCT(ViewState("ConcatID"))
                    dt = Bl.GetByGVStdAttdCT(El)
                    If dt.Rows.Count > 0 Then
                        GVStdAttd.DataSource = dt
                        GVStdAttd.DataBind()
                        GVStdAttd.Visible = True
                    Else
                        msginfo.Text = ""
                        lblmsg.Text = ""
                        msginfo.Text = "No records to display."
                        'cmbAcademic.Focus()
                        GVStdAttd.Visible = False
                    End If
                    msginfo.Text = ""
                    lblmsg.Text = ""
                    btnClear.Enabled = False
                    btnUpdate.Enabled = False
                    btnLock.Enabled = False
                    btnSendMsg.Enabled = False
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

                    lblmsg.Text = ViewState("CountID").ToString + " records cleared."
                End If
                Catch ex As Exception
                    'Clear()
                    msginfo.Text = "Enter all mandatory fields."
                End Try
            Else
                msginfo.Text = "You do not belong to this branch, Cannot clear data."
                lblmsg.Text = ""
            End If
        End Sub

        Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim check As String
            If txtPassword.Text = Session("Password") Then
                If Bl.CheckLockAttendanceCT(ViewState("ConcatID")) = "N" Then
                    Dim roweffected As Integer = Bl.LockAttendanceCT(ViewState("ConcatID"))
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        El.Academic = 0
                        El.Batch = cmbBatch.SelectedValue
                        El.SemesterId = cmbSemester.SelectedValue
                        El.SubjectId = cmbSubject.SelectedValue
                        El.ClassType = ddlClasstype.SelectedValue
                        El.AttendanceDate = Me.TxtAttdate.Text
                        El.SubGrp = ddlSubjectSubGrp.SelectedValue
                        Image1.Visible = True
                        Image2.Visible = True
                        AssignEntity()
                        display(El)
                        msginfo.Text = ""
                        lblmsg.Text = ""
                        lblmsg.Text = ViewState("CountID").ToString + " records Locked."
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                    End If
                Else
                    Dim role As String
                    role = Session("UserRole")
                    'dt = stdAttndance.PostCheck(role)
                    'If dt.Rows.Count > 0 Then

                    If Session("SecurityCheck") = "Security Check" Then
                        dt = StdAttendancewitclasstypeDL.UnlockCheckStdAttendance(role)
                        If dt.Rows.Count < 1 Then
                            msginfo.Text = "You don't have Unlock Permission."
                            lblmsg.Text = ""
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                            Image1.Visible = True
                            Image2.Visible = True
                        Else
                            check = dt.Rows(0)("Result").ToString.Trim
                            If check = "" Then
                                msginfo.Text = "You don't have Unlock Permission."
                                lblmsg.Text = ""
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                GVStdAttd.Enabled = False
                                Image1.Visible = True
                                Image2.Visible = True
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                            Else
                                Dim roweffected As Integer = Bl.UnLockAttendanceCT(ViewState("ConcatID"))
                                If roweffected > 0 Then
                                    ControlsPanel.Visible = True
                                    PasswordPanel.Visible = False
                                    El.Academic = 0
                                    El.Batch = cmbBatch.SelectedValue
                                    El.SemesterId = cmbSemester.SelectedValue
                                    El.SubjectId = cmbSubject.SelectedValue
                                    El.ClassType = ddlClasstype.SelectedValue
                                    El.AttendanceDate = Me.TxtAttdate.Text
                                    El.SubGrp = ddlSubjectSubGrp.SelectedValue
                                    AssignEntity()
                                    display(El)
                                    msginfo.Text = ""
                                    lblmsg.Text = ""
                                    lblmsg.Text = ViewState("CountID").ToString + " records Unlocked."
                                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                                    Image1.Visible = True
                                    Image2.Visible = True
                                End If
                            End If
                        End If
                        'Else
                        '    ControlsPanel.Visible = True
                        '    PasswordPanel.Visible = False
                        '    msginfo.Text = "Not Authorized to Unlock."
                        '    Image1.Visible = True
                        '    Image2.Visible = True
                        '    lblmsg.Text = ""

                    Else
                        Dim roweffected As Integer = Bl.UnLockAttendanceCT(ViewState("ConcatID"))
                        If roweffected > 0 Then
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            El.Academic = 0
                            El.Batch = cmbBatch.SelectedValue
                            El.SemesterId = cmbSemester.SelectedValue
                            El.SubjectId = cmbSubject.SelectedValue
                            El.ClassType = ddlClasstype.SelectedValue
                            El.AttendanceDate = Me.TxtAttdate.Text
                            El.SubGrp = ddlSubjectSubGrp.SelectedValue
                            AssignEntity()
                            display(El)
                            msginfo.Text = ""
                            lblmsg.Text = ""
                            lblmsg.Text = ViewState("CountID").ToString + " records Unlocked."
                            Image1.Visible = True
                            Image2.Visible = True
                        End If
                        'End If
                    End If
                End If
            ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                msginfo.Text = "Password Incorrect."
                Image1.Visible = True
                Image2.Visible = True
                lblmsg.Text = ""
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
        ViewState("Updated") = "True"
        btnLock.Focus()
    End Sub

        Protected Sub btnSendMsg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendMsg.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If Bl.CheckLockAttendanceCT(ViewState("ConcatID")) = "Y" Then
                msginfo.Text = ""
                lblmsg.Text = ""
                msginfo.Text = "Records are locked, cannot Send Message."
                'cmbAcademic.Focus()
                pnllabel.Visible = True
            Else
                If ViewState("Updated") = "True" Then
                    Dim Service As String = IIf(Session("EmailService") = "Y" And Session("SMSService") = "Y", "Both", IIf(Session("EmailService") = "Y", "Email", IIf(Session("SMSService") = "Y", "SMS", "Nothing")))
                    sendmsg(Service)
                Else
                    lblmsg.Text = ""
                    msginfo.Text = " Update attendance before you send message. "
                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot Send Message."
            lblmsg.Text = ""
        End If

    End Sub
        Sub sendmsg(ByVal service As String)
            Dim vm As String
            Dim parm_msg, parm_phonesp, param_Subject As SqlParameter
        El.Academic = 0
            El.Batch = cmbBatch.SelectedItem.Value
            El.SemesterId = cmbSemester.SelectedItem.Value
            El.SubjectId = cmbSubject.SelectedItem.Value
            El.ClassType = ddlClasstype.SelectedItem.Value
            El.AttendanceDate = Me.TxtAttdate.Text()
            El.SubGrp = ddlSubjectSubGrp.SelectedValue
            AssignEntity()
        dt = Bl.GetByGVStdAttdCT(El)
            If dt.Rows.Count > 0 Then
                ViewState("ConcatID") = ""
                For i As Integer = 0 To dt.Rows.Count - 1
                    ViewState("ConcatID") = dt.Rows(i).Item("Id").ToString + "," + ViewState("ConcatID")
                Next
            End If
            dt.Clear()
            If service <> "Nothing" Then
            dt = Bl.SendMessageCT(ViewState("ConcatID"), service)
                If dt.Rows.Count > 0 Then
                    For i As Integer = 0 To dt.Rows.Count - 1
                        Dim ToPhone As String
                        Dim Subject As String
                        Dim Message As String
                        Dim SentDate As Date
                        Dim Mode As String
                        Subject = dt.Rows(i).Item("Subject").ToString
                        ToPhone = dt.Rows(i).Item("contactno").ToString
                        Message = dt.Rows(i).Item("String").ToString.Replace(" , ,", ",") + ", " + dt.Rows(0).Item("AttendanceDate").ToString
                        Message = Message.Replace(" , ,", ",")
                        Message = Message.Replace(", ,", ",")
                        Message = Message.Replace(",,", ",")
                        SentDate = Today.Date
                        If ToPhone.Contains("@") And ToPhone.Contains(".") Then
                            Mode = "Email"
                        Else
                            Mode = "SMS"
                        End If
                        Dim str As String = ""
                        Dim connection As New SqlClient.SqlConnection()
                        connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
                        connection.Open()
                        Dim cmd As New SqlCommand()
                        vm = "insert into Outbox_tbl (ToPhone,Message,prefix,BranchCode,CommunicationMode) values(@ToPhone,@Message,@prefix,@BranchCode,@Mode)"

                        cmd.Connection = connection
                        cmd.CommandText = vm
                        param_Subject = New SqlParameter
                        param_Subject.ParameterName = "@prefix"
                        param_Subject.Value = Subject
                        param_Subject.DbType = DbType.String
                        cmd.Parameters.Add(param_Subject)

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

                        parm_msg = New SqlParameter
                        parm_msg.ParameterName = "@BranchCode"
                        parm_msg.Value = Session("BranchCode")
                        parm_msg.DbType = DbType.String
                        cmd.Parameters.Add(parm_msg)

                        parm_msg = New SqlParameter
                        parm_msg.ParameterName = "@Mode"
                        parm_msg.Value = Mode
                        parm_msg.DbType = DbType.String
                        cmd.Parameters.Add(parm_msg)

                        cmd.ExecuteNonQuery()
                    Next
                    If service = "Both" Then
                        service = "SMS and Email"
                    End If
                    msginfo.Text = ""
                    lblmsg.Text = service + " Sent Successfully."
                    'If service = "Nothing" Then
                    '    service = "SMS and Email"
                    '    msginfo.Text = "SMS and Email are blocked."
                    '    lblmsg.Text = ""
                    'End If
                Else
                    lblmsg.Text = ""
                    msginfo.Text = "All students are present, no message to send."
                End If
            Else
                msginfo.Text = "SMS and Email are blocked."
                lblmsg.Text = ""
            End If
        End Sub
        Protected Sub cmbBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatch.SelectedIndexChanged
            GVStdAttd.Visible = False
            pnllabel.Visible = False
            GVStdAttd.Visible = False
        End Sub

    'Protected Sub cmbAcademic_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcademic.TextChanged
    '    cmbAcademic.Focus()
    '    pnllabel.Visible = False
    '    GVStdAttd.Visible = False
    'End Sub

        Protected Sub cmbBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatch.TextChanged
            cmbBatch.Focus()
        End Sub


    Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
        Try
            El.Academic = 0
            El.Batch = cmbBatch.SelectedItem.Value
            El.SemesterId = cmbSemester.SelectedItem.Value
            If cmbSemester.SelectedValue <> 0 Then
                dt = b.GetSubjectComboBatchPlanner(El.Batch, El.SemesterId)
                If dt.Rows.Count <= 1 Then
                    lblmsg.Text = ""
                    msginfo.Text = "You have not been assigned any subject for this Batch/Semester.<br />Kindly check the data in Batch Planner form."
                Else
                    lblmsg.Text = ""
                    msginfo.Text = ""
                End If
            Else
                lblmsg.Text = ""
                msginfo.Text = ""
            End If
        Catch ex As Exception
            lblmsg.Text = ""
            msginfo.Text = "Enter correct data."
        End Try
    End Sub

        Protected Sub cmbSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.TextChanged
            cmbSemester.Focus()
        End Sub

        Protected Sub cmbSubject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubject.TextChanged
            cmbSubject.Focus()
        End Sub

        Protected Sub ddlClasstype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlClasstype.TextChanged
            ddlClasstype.Focus()
        End Sub

        Protected Sub GVStdAttd_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVStdAttd.Sorting

  

        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        El.Academic = 0
        El.Batch = cmbBatch.SelectedValue
        El.SemesterId = cmbSemester.SelectedValue
        El.SubjectId = cmbSubject.SelectedValue
        El.ClassType = ddlClasstype.SelectedValue
        El.AttendanceDate = Me.TxtAttdate.Text
        El.SubGrp = ddlSubjectSubGrp.SelectedValue
        AssignEntity()
        'display(El)




        Dim dt As New Data.DataTable
        dt = Bl.GetByGVStdAttdCT(El)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        ViewState("SortExpression") = e.SortExpression
        ViewState("sortingDirection") = sortingDirection
        GVStdAttd.DataSource = sortedView
        GVStdAttd.DataBind()
        lblBatchAns.Text = ""
        lblSemesterAns.Text = ""
        lblClassTypeAns.Text = ""
        lblSubjectAns.Text = ""
        lblAttendanceDateAns.Text = ""
        For Each grid As GridViewRow In GVStdAttd.Rows
            'lblAcademicYearAns.Text = CType(grid.FindControl("l1"), Label).Text
            lblBatchAns.Text = CType(grid.FindControl("l2"), Label).Text
            lblSemesterAns.Text = CType(grid.FindControl("l3"), Label).Text
            lblClassTypeAns.Text = CType(grid.FindControl("l5"), Label).Text()
            lblSubjectAns.Text = CType(grid.FindControl("l4"), Label).Text
            lblAttendanceDateAns.Text = CType(grid.FindControl("l6"), Label).Text
            'lblPeriodNo.Text = CType(grid.FindControl("l7"), Label).Text
            pnllabel.Visible = True

            If CType(grid.FindControl("LabelPre"), Label).Text = "P" Then
                CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True
            Else
                CType(grid.FindControl("ChkPresent"), CheckBox).Checked = False

            End If
        Next
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

    Protected Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        Dim sw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()

        Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
        Page.Response.AddHeader("content-disposition", "attachment;filename=StudentAttendance.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        Controls.Add(frm)
        frm.Controls.Add(GVStdAttd)
        frm.RenderControl(hw)
        Response.Write(style)
        'Response.Write(sw.ToString())
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
End Class


