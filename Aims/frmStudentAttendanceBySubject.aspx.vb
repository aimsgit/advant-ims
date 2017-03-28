Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports Attendance1
Imports System.Data.SqlClient

Partial Class frmStudentAttendanceBySubject
    Inherits BasePage
    Dim dt, dt1, dt4, dt5 As New DataTable
    Dim Bl As New BLStdAttdanceBySubject
    Dim a As String
    Dim El As New ELStdAttendancePBySubject
    Dim b As New BLNew_stdMarks
    Dim StudentPerformanceDL As New StudentPerformanceBySubjectDL
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
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
        'ddlElecSub.SelectedItem.Selected = False
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
        'ViewState("Updated") = "False"
    End Sub

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        'cmbAcademic.Focus()
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If btnSubmit.Text = "GENERATE" Then
                    btnSendMsg.Enabled = True
                    El.Academic = 0
                    'El.Batch = cmbBatch.SelectedValue
                    'El.SemesterId = cmbSemester.SelectedValue
                    'El.SubjectId = cmbSubject.SelectedValue
                    El.SubjectId = cmbSubject.SelectedValue
                    dt4 = Bl.BatchAccess(El)
                    If dt4.Rows.Count > 0 Then
                        '   Subject = dt.Rows(i).Item("Subject").ToString
                        If dt4.Rows.Count > 0 Then
                            '   Subject = dt.Rows(i).Item("Subject").ToString
                            Dim str As String = ""
                            Dim str1 As String = ""
                            Dim id As String = ""
                            Dim i, i1 As Integer
                            Dim j, j1 As Integer
                            i = 0
                            j = dt4.Rows.Count
                            If j > 0 Then
                                While j > 0
                                    str = dt4.Rows(i).Item("BatchID").ToString
                                    El.Batch = str + "," + El.Batch
                                    i = i + 1
                                    j = j - 1
                                End While
                            Else
                                El.Batch = 0
                            End If
                            dt5 = Bl.SemAccess(El)
                            i1 = 0
                            j1 = dt5.Rows.Count
                            If j1 > 0 Then
                                While j1 > 0
                                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                                    El.SemesterId = str1 + "," + El.SemesterId
                                    i1 = i1 + 1
                                    j1 = j1 - 1
                                End While
                            Else
                                El.SemesterId = 0
                            End If
                        End If
                        'El.ClassType = ddlClasstype.SelectedValue
                        'El.ElecSub = ddlElecSub.SelectedValue
                        El.AttendanceDate = Me.TxtAttdate.Text
                        El.SubGrp = ddlSubjectSubGrp.SelectedValue
                        'dt = Bl.GetBatch(El)
                        'If dt.Rows(0).Item("Subgrp_Status") = "Y" Then
                        '    If ddlSubjectSubGrp.SelectedValue = 0 Then
                        '        msginfo.Text = ValidationMessage(1192)
                        '        lblmsg.Text = ValidationMessage(1014)
                        '        Exit Sub
                        '    End If
                        'End If
                        AssignEntity()
                        If (El.AttendanceDate > Today()) Then
                            msginfo.Text = ValidationMessage(1209)
                            lblmsg.Text = ValidationMessage(1014)
                        Else
                            dt = Bl.Attendanceduplicate(El)
                            If dt.Rows.Count > 0 Then
                                msginfo.Visible = True
                                msginfo.Text = ValidationMessage(1044)
                                'cmbAcademic.Focus()
                                lblmsg.Text = ValidationMessage(1014)
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

                            Else
                                Session("ButtonType") = "SUBMIT"
                                Bl.InsertAttandance(El)
                                dt = Bl.GetByGVStdAttd(El)
                                lblmsg.Text = dt.Rows.Count().ToString + ValidationMessage(1109)
                                msginfo.Text = ValidationMessage(1014)
                                display(El)
                                LinkButton.Focus()
                                'cmbAcademic.Focus()
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                                'msginfo.Visible = False
                            End If
                        End If
                    End If
                    ViewState("Updated") = "False"
                Else
                    msginfo.Text = ValidationMessage(1210)
                    lblmsg.Text = ValidationMessage(1014)
                End If
            End If

        Catch ex As Exception
            msginfo.Text = ValidationMessage(1059)
            lblmsg.Text = ValidationMessage(1014)
        End Try
    End Sub
    Sub display(ByVal EL As ELStdAttendancePBySubject)
        pnllabel.Visible = True
        GVPanel.Visible = True
        EL.Academic = 0
        'EL.Batch = cmbBatch.SelectedValue
        'EL.SemesterId = cmbSemester.SelectedValue
        'EL.SubjectId = cmbSubject.SelectedValue
        EL.SubjectId = cmbSubject.SelectedValue
        dt4 = Bl.BatchAccess(EL)
        If dt4.Rows.Count > 0 Then
            '   Subject = dt.Rows(i).Item("Subject").ToString
            Dim str As String = ""
            Dim str1 As String = ""
            Dim id As String = ""
            Dim i, i1 As Integer
            Dim j, j1 As Integer
            i = 0
            j = dt4.Rows.Count
            If j > 0 Then
                While j > 0
                    str = dt4.Rows(i).Item("BatchID").ToString
                    EL.Batch = str + "," + EL.Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                EL.Batch = 0
            End If
            dt5 = Bl.SemAccess(EL)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    EL.SemesterId = str1 + "," + EL.SemesterId
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                EL.SemesterId = 0
            End If
        End If
        'El.ClassType = ddlClasstype.SelectedValue
        'El.ElecSub = ddlElecSub.SelectedValue
        EL.AttendanceDate = Me.TxtAttdate.Text
        EL.SubGrp = ddlSubjectSubGrp.SelectedValue
        AssignEntity()
        Dim dt As New Data.DataTable
        dt = Bl.GetByGVStdAttd(EL)
        If dt.Rows.Count = 0 Then
            GVStdAttd.DataSource = Nothing
            GVStdAttd.DataBind()
          
            msginfo.Text = ValidationMessage(1023)
            pnllabel.Visible = False
            'cmbAcademic.Focus()
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

            lblmsg.Text = ValidationMessage(1014)
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

            'lblAcademicYearAns.Text = ""
            lblBatchAns.Text = ""
            lblSemesterAns.Text = ""
            'lblClassTypeAns.Text = ""
            lblSubjectAns.Text = ""
            lblAttendanceDateAns.Text = ""

            For Each grid As GridViewRow In GVStdAttd.Rows
                'lblAcademicYearAns.Text = CType(grid.FindControl("l1"), Label).Text
                lblBatchAns.Text = CType(grid.FindControl("l2"), Label).Text
                lblSemesterAns.Text = CType(grid.FindControl("l3"), Label).Text
                'lblClassTypeAns.Text = CType(grid.FindControl("l5"), Label).Text()
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
            If Bl.CheckLockAttendance(ViewState("ConcatID")) = "Y" Then
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
        Try
            LinkButton.Focus()
            btnSendMsg.Enabled = True
            El.Academic = 0
            'El.Batch = cmbBatch.SelectedValue
            'El.SemesterId = cmbSemester.SelectedValue
            'El.SubjectId = cmbSubject.SelectedValue
            El.SubjectId = cmbSubject.SelectedValue
            dt4 = Bl.BatchAccess(El)
            If dt4.Rows.Count > 0 Then
                '   Subject = dt.Rows(i).Item("Subject").ToString
                Dim str As String = ""
                Dim str1 As String = ""
                Dim id As String = ""
                Dim i, i1 As Integer
                Dim j, j1 As Integer
                i = 0
                j = dt4.Rows.Count
                If j > 0 Then
                    While j > 0
                        str = dt4.Rows(i).Item("BatchID").ToString
                        El.Batch = str + "," + El.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    El.Batch = 0
                End If
                dt5 = Bl.SemAccess(El)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        El.SemesterId = str1 + "," + El.SemesterId
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    El.SemesterId = 0
                End If
                El.AttendanceDate = Me.TxtAttdate.Text
                El.SubGrp = ddlSubjectSubGrp.SelectedValue
                AssignEntity()
                display(El)
                ViewState("Updated") = "False"
            End If
            'El.ClassType = ddlClasstype.SelectedValue
            'El.ElecSub = ddlElecSub.SelectedValue
           
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1022)
            lblmsg.Text = ValidationMessage(1014)
        End Try

    End Sub

    Protected Sub GVStdAttd_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVStdAttd.PageIndexChanging
        GVStdAttd.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVStdAttd.PageIndex
        El.Academic = 0
        'El.Batch = cmbBatch.SelectedValue
        'El.SemesterId = cmbSemester.SelectedValue
        'El.SubjectId = cmbSubject.SelectedValue
        El.SubjectId = cmbSubject.SelectedValue
        dt4 = Bl.BatchAccess(El)
        If dt4.Rows.Count > 0 Then
            '   Subject = dt.Rows(i).Item("Subject").ToString
            Dim str As String = ""
            Dim str1 As String = ""
            Dim id As String = ""
            Dim i, i1 As Integer
            Dim j, j1 As Integer
            i = 0
            j = dt4.Rows.Count
            If j > 0 Then
                While j > 0
                    str = dt4.Rows(i).Item("BatchID").ToString
                    El.Batch = str + "," + El.Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                El.Batch = 0
            End If
            dt5 = Bl.SemAccess(El)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    El.SemesterId = str1 + "," + El.SemesterId
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                El.SemesterId = 0
            End If
        End If
        'El.ClassType = ddlClasstype.SelectedValue
        'El.ElecSub = ddlElecSub.SelectedValue
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

            El.Academic = 0
            'El.Batch = cmbBatch.SelectedItem.Value
            'El.SemesterId = cmbSemester.SelectedItem.Value
            'El.SubjectId = cmbSubject.SelectedItem.Value
            El.SubjectId = cmbSubject.SelectedValue
            dt4 = Bl.BatchAccess(El)
            If dt4.Rows.Count > 0 Then
                '   Subject = dt.Rows(i).Item("Subject").ToString
                Dim str As String = ""
                Dim str1 As String = ""
                Dim id As String = ""
                Dim i, i1 As Integer
                Dim j, j1 As Integer
                i = 0
                j = dt4.Rows.Count
                If j > 0 Then
                    While j > 0
                        str = dt4.Rows(i).Item("BatchID").ToString
                        El.Batch = str + "," + El.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    El.Batch = 0
                End If
                dt5 = Bl.SemAccess(El)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        El.SemesterId = str1 + "," + El.SemesterId
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    El.SemesterId = 0
                End If
            End If
            'El.ElecSub = ddlElecSub.SelectedItem.Value
            El.AttendanceDate = Me.TxtAttdate.Text
            El.SubGrp = ddlSubjectSubGrp.SelectedValue
            AssignEntity()
            For Each grid As GridViewRow In GVStdAttd.Rows
                El.AttendanceDate = CType(grid.FindControl("l6"), Label).Text
                El.SessionCountDay = CType(grid.FindControl("l7"), Label).Text
            Next
            dt = Bl.GetByGVStdAttd(El)
            If dt.Rows.Count > 0 Then
                ViewState("ConcatID") = ""
                For i As Integer = 0 To dt.Rows.Count - 1
                    ViewState("ConcatID") = dt.Rows(i).Item("Id").ToString + "," + ViewState("ConcatID")
                Next
            End If
            If Bl.CheckLockAttendance(ViewState("ConcatID")) = "Y" Then
                msginfo.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1099)
                'cmbAcademic.Focus()
            Else
                El.Academic = 0
                'El.Batch = cmbBatch.SelectedValue
                'El.SemesterId = cmbSemester.SelectedValue
                'El.SubjectId = cmbSubject.SelectedValue
                El.SubjectId = cmbSubject.SelectedValue
                dt4 = Bl.BatchAccess(El)
                If dt4.Rows.Count > 0 Then
                    '   Subject = dt.Rows(i).Item("Subject").ToString
                    Dim str As String = ""
                    Dim str1 As String = ""
                    Dim id As String = ""
                    Dim i, i1 As Integer
                    Dim j, j1 As Integer
                    i = 0
                    j = dt4.Rows.Count
                    If j > 0 Then
                        While j > 0
                            str = dt4.Rows(i).Item("BatchID").ToString
                            El.Batch = str + "," + El.Batch
                            i = i + 1
                            j = j - 1
                        End While
                    Else
                        El.Batch = 0
                    End If
                    dt5 = Bl.SemAccess(El)
                    i1 = 0
                    j1 = dt5.Rows.Count
                    If j1 > 0 Then
                        While j1 > 0
                            str1 = dt5.Rows(i1).Item("SemesterID").ToString
                            El.SemesterId = str1 + "," + El.SemesterId
                            i1 = i1 + 1
                            j1 = j1 - 1
                        End While
                    Else
                        El.SemesterId = 0
                    End If
                End If
                El.AttendanceDate = Me.TxtAttdate.Text
                AssignEntity()
                If (El.AttendanceDate > Today()) Then
                    msginfo.Text = ValidationMessage(1209)
                    lblmsg.Text = ValidationMessage(1014)
                    Exit Sub
                End If
                For Each grid As GridViewRow In GVStdAttd.Rows
                    El.AttendanceDate1 = CType(grid.FindControl("l6"), Label).Text
                    El.SessionCountDay1 = CType(grid.FindControl("l7"), Label).Text
                Next
                If El.SessionCountDay <> El.SessionCountDay1 Or El.AttendanceDate <> El.AttendanceDate1 Then
                    'MsgBox("Period No. or date has changed.Do you want to go ahead?")
                    dt = Bl.Attendanceduplicate(El)
                    If dt.Rows.Count > 0 Then
                        msginfo.Visible = True
                        msginfo.Text = ValidationMessage(1044)
                        Exit Sub
                    End If
                End If
                For Each grid As GridViewRow In GVStdAttd.Rows
                    If CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True Then
                        El.Id = CType(grid.FindControl("IID"), HiddenField).Value
                        El.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                        El.Present = "P"
                        El.AttendanceDate = TxtAttdate.Text
                        AssignEntity()
                        Bl.UpdateRecord(El)
                        lblmsg.Text = ValidationMessage(1053)
                        ViewState("Updated") = "True"
                        'cmbAcademic.Focus()
                        'lblmsg.Visible = True
                        msginfo.Text = ValidationMessage(1014)
                    Else
                        El.Id = CType(grid.FindControl("IID"), HiddenField).Value
                        El.AttendanceDate = TxtAttdate.Text
                        AssignEntity()
                        El.Present = "A"
                        El.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                        Bl.UpdateRecord(El)
                        lblmsg.Text = ValidationMessage(1053)
                        ViewState("Updated") = "True"
                        'cmbAcademic.Focus()
                        msginfo.Text = ValidationMessage(1014)
                    End If
                Next
            End If
            display(El)
            ViewState("Updated") = "True"

        Else
            msginfo.Text = ValidationMessage(1194)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub CheckAll()
        If CType(GVStdAttd.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            El.Academic = 0
            'El.Batch = cmbBatch.SelectedItem.Value
            'El.SemesterId = cmbSemester.SelectedItem.Value
            'El.SubjectId = cmbSubject.SelectedItem.Value
            El.SubjectId = cmbSubject.SelectedValue
            dt4 = Bl.BatchAccess(El)
            If dt4.Rows.Count > 0 Then
                '   Subject = dt.Rows(i).Item("Subject").ToString
                Dim str As String = ""
                Dim str1 As String = ""
                Dim id As String = ""
                Dim i, i1 As Integer
                Dim j, j1 As Integer
                i = 0
                j = dt4.Rows.Count
                If j > 0 Then
                    While j > 0
                        str = dt4.Rows(i).Item("BatchID").ToString
                        El.Batch = str + "," + El.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    El.Batch = 0
                End If
                dt5 = Bl.SemAccess(El)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        El.SemesterId = str1 + "," + El.SemesterId
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    El.SemesterId = 0
                End If
            End If
            'El.ClassType = ddlClasstype.SelectedItem.Value
            'El.ElecSub = ddlElecSub.SelectedValue
            El.AttendanceDate = Me.TxtAttdate.Text()
            AssignEntity()
            El.Present = "P"
            Bl.UpdateCollectionVerification(El)
            For Each grid As GridViewRow In GVStdAttd.Rows
                CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True
            Next
        Else
            El.Academic = 0
            'El.Batch = cmbBatch.SelectedItem.Value
            'El.SemesterId = cmbSemester.SelectedItem.Value
            'El.SubjectId = cmbSubject.SelectedItem.Value
            El.SubjectId = cmbSubject.SelectedValue
            dt4 = Bl.BatchAccess(El)
            If dt4.Rows.Count > 0 Then
                '   Subject = dt.Rows(i).Item("Subject").ToString
                Dim str As String = ""
                Dim str1 As String = ""
                Dim id As String = ""
                Dim i, i1 As Integer
                Dim j, j1 As Integer
                i = 0
                j = dt4.Rows.Count
                If j > 0 Then
                    While j > 0
                        str = dt4.Rows(i).Item("BatchID").ToString
                        El.Batch = str + "," + El.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    El.Batch = 0
                End If
                dt5 = Bl.SemAccess(El)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        El.SemesterId = str1 + "," + El.SemesterId
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    El.SemesterId = 0
                End If
            End If
            'El.ClassType = ddlClasstype.SelectedItem.Value
            'El.ElecSub = ddlElecSub.SelectedItem.Value
            El.AttendanceDate = Me.TxtAttdate.Text()
            AssignEntity()
            El.Present = "P"
            Bl.UpdateCollectionVerification(El)
            For Each grid As GridViewRow In GVStdAttd.Rows
                CType(grid.FindControl("ChkPresent"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Sub DisplayGrid()
        pnllabel.Visible = True
        GVPanel.Visible = True
        El.Academic = 0
        'El.Batch = cmbBatch.SelectedItem.Value
        'El.SemesterId = cmbSemester.SelectedItem.Value
        'El.SubjectId = cmbSubject.SelectedItem.Value
        El.SubjectId = cmbSubject.SelectedValue
        dt4 = Bl.BatchAccess(El)
        If dt4.Rows.Count > 0 Then
            '   Subject = dt.Rows(i).Item("Subject").ToString
            Dim str As String = ""
            Dim str1 As String = ""
            Dim id As String = ""
            Dim i, i1 As Integer
            Dim j, j1 As Integer
            i = 0
            j = dt4.Rows.Count
            If j > 0 Then
                While j > 0
                    str = dt4.Rows(i).Item("BatchID").ToString
                    El.Batch = str + "," + El.Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                El.Batch = 0
            End If
            dt5 = Bl.SemAccess(El)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    El.SemesterId = str1 + "," + El.SemesterId
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                El.SemesterId = 0
            End If
        End If
        'El.ClassType = ddlClasstype.SelectedItem.Value
        'El.ElecSub = ddlElecSub.SelectedItem.Value
        El.AttendanceDate = Me.TxtAttdate.Text()
        El.SubGrp = ddlSubjectSubGrp.SelectedValue
        AssignEntity()
        Dim dt As New Data.DataTable
        dt = Bl.GetByGVStdAttd(El)
        If dt.Rows.Count = 0 Then
            GVStdAttd.DataSource = Nothing
            GVStdAttd.DataBind()
           
            msginfo.Text = ValidationMessage(1023)
            pnllabel.Visible = False
            'msginfo.Visible = True
            lblmsg.Text = ValidationMessage(1014)
        Else
            GVStdAttd.DataSource = dt
            GVStdAttd.DataBind()
         
            'lblAcademicYearAns.Text = ""
            lblBatchAns.Text = ""
            lblSemesterAns.Text = ""
            'lblClassTypeAns.Text = ""
            lblSubjectAns.Text = ""
            lblAttendanceDateAns.Text = ""
            For Each grid As GridViewRow In GVStdAttd.Rows
                'lblAcademicYearAns.Text = CType(grid.FindControl("l1"), Label).Text
                lblBatchAns.Text = CType(grid.FindControl("l2"), Label).Text
                lblSemesterAns.Text = CType(grid.FindControl("l3"), Label).Text
                'lblClassTypeAns.Text = CType(grid.FindControl("l5"), Label).Text()
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
                
                'ViewState("Updated") = "True"
                El.Academic = 0
                'El.Batch = cmbBatch.SelectedItem.Value
                'El.SemesterId = cmbSemester.SelectedItem.Value
                'El.SubjectId = cmbSubject.SelectedItem.Value
                El.SubjectId = cmbSubject.SelectedValue
                dt4 = Bl.BatchAccess(El)
                If dt4.Rows.Count > 0 Then
                    ControlsPanel.Visible = False
                    GVPanel.Visible = False
                    PasswordPanel.Visible = True
                    BtnExport.Visible = False
                    RptAttendanceBtn.Visible = False
                    RptButton.Visible = False
                    lblSubjectAns.Visible = False
                    lblAttendanceDateAns.Visible = False
                    lblAttendanceDate.Visible = False
                    lblSubject1.Visible = False
                    txtPassword.Focus()
                    lblpassError.Text = ""
                    Image2.Visible = False
                    Image3.Visible = False
                    '   Subject = dt.Rows(i).Item("Subject").ToString
                    Dim str As String = ""
                    Dim str1 As String = ""
                    Dim id As String = ""
                    Dim i, i1 As Integer
                    Dim j, j1 As Integer
                    i = 0
                    j = dt4.Rows.Count
                    If j > 0 Then
                        While j > 0
                            str = dt4.Rows(i).Item("BatchID").ToString
                            El.Batch = str + "," + El.Batch
                            i = i + 1
                            j = j - 1
                        End While
                    Else
                        El.Batch = 0
                    End If
                    dt5 = Bl.SemAccess(El)
                    i1 = 0
                    j1 = dt5.Rows.Count
                    If j1 > 0 Then
                        While j1 > 0
                            str1 = dt5.Rows(i1).Item("SemesterID").ToString
                            El.SemesterId = str1 + "," + El.SemesterId
                            i1 = i1 + 1
                            j1 = j1 - 1
                        End While
                    Else
                        El.SemesterId = 0
                    End If
                End If
                'El.ClassType = ddlClasstype.SelectedItem.Value
                El.AttendanceDate = Me.TxtAttdate.Text()
                El.SubGrp = ddlSubjectSubGrp.SelectedValue
                'El.ElecSub = ddlElecSub.SelectedValue
                AssignEntity()
                dt = Bl.GetByGVStdAttd(El)
                If dt.Rows(0).Item("Del_Flag") = "G" Then
                    msginfo.Text = ValidationMessage(1211)
                    lblmsg.Text = ValidationMessage(1014)
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

                    Exit Sub
                End If
                If dt.Rows.Count > 0 Then
                    ViewState("ConcatID") = ""
                    For i As Integer = 0 To dt.Rows.Count - 1
                        ViewState("ConcatID") = ViewState("ConcatID") + "," + dt.Rows(i).Item("Id").ToString
                    Next
                    'ControlsPanel.Visible = False
                    'PasswordPanel.Visible = True
                    'txtPassword.Focus()
                    'lblpassError.Text = ""
                    'Image2.Visible = False
                    'Image3.Visible = False
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

                Else
                    'Clear()
                    
                    msginfo.Text = ValidationMessage(1211)
                    lblmsg.Text = ValidationMessage(1211)
                    msginfo.Text = ValidationMessage(1105)
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                    Image2.Visible = True
                    Image3.Visible = True
                End If

                'End If
            Catch ex As Exception
                'Clear()
                msginfo.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1212)
            End Try
        Else
            
            msginfo.Text = ValidationMessage(1101)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                pnllabel.Visible = False
                El.Academic = 0
                'El.Batch = cmbBatch.SelectedItem.Value
                'El.SemesterId = cmbSemester.SelectedItem.Value
                'El.SubjectId = cmbSubject.SelectedItem.Value
                El.SubjectId = cmbSubject.SelectedValue
                dt4 = Bl.BatchAccess(El)
                If dt4.Rows.Count > 0 Then
                    '   Subject = dt.Rows(i).Item("Subject").ToString
                    Dim str As String = ""
                    Dim str1 As String = ""
                    Dim id As String = ""
                    Dim i, i1 As Integer
                    Dim j, j1 As Integer
                    i = 0
                    j = dt4.Rows.Count
                    If j > 0 Then
                        While j > 0
                            str = dt4.Rows(i).Item("BatchID").ToString
                            El.Batch = str + "," + El.Batch
                            i = i + 1
                            j = j - 1
                        End While
                    Else
                        El.Batch = 0
                    End If
                    dt5 = Bl.SemAccess(El)
                    i1 = 0
                    j1 = dt5.Rows.Count
                    If j1 > 0 Then
                        While j1 > 0
                            str1 = dt5.Rows(i1).Item("SemesterID").ToString
                            El.SemesterId = str1 + "," + El.SemesterId
                            i1 = i1 + 1
                            j1 = j1 - 1
                        End While
                    Else
                        El.SemesterId = 0
                    End If
                End If
                'El.ElecSub = ddlElecSub.SelectedItem.Value
                El.AttendanceDate = Me.TxtAttdate.Text()
                El.SubGrp = ddlSubjectSubGrp.SelectedValue
                AssignEntity()
                dt = Bl.GetByGVStdAttd(El)
                If dt.Rows.Count > 0 Then
                    ViewState("ConcatID") = ""
                    For i As Integer = 0 To dt.Rows.Count - 1
                        ViewState("ConcatID") = ViewState("ConcatID") + "," + dt.Rows(i).Item("Id").ToString
                    Next
                End If

                If Bl.CheckLockAttendance(ViewState("ConcatID")) = "Y" Then
                    msginfo.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1098)
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                    pnllabel.Visible = True
                Else
                    Dim clearcount As Integer = 0
                    Bl.ClearAttendance(ViewState("ConcatID"))
                    dt = Bl.GetByGVStdAttd(El)
                    If dt.Rows.Count > 0 Then
                        GVStdAttd.DataSource = dt
                        GVStdAttd.DataBind()
                       
                        GVStdAttd.Visible = True
                    Else
                        msginfo.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        msginfo.Text = ValidationMessage(1023)
                        'cmbAcademic.Focus()
                        GVStdAttd.Visible = False
                    End If
                    msginfo.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    btnClear.Enabled = False
                    btnUpdate.Enabled = False
                    btnLock.Enabled = False
                    btnSendMsg.Enabled = False
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

                    lblmsg.Text = ViewState("CountID").ToString + ValidationMessage(1196)
                End If
            Catch ex As Exception
                'Clear()
                msginfo.Text = ValidationMessage(1212)
            End Try
        Else
            msginfo.Text = ValidationMessage(1048)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim check As String
            If txtPassword.Text = Session("Password") Then
                If Bl.CheckLockAttendance(ViewState("ConcatID")) = "N" Then
                    Dim roweffected As Integer = Bl.LockAttendance(ViewState("ConcatID"))
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        BtnExport.Visible = False
                        RptAttendanceBtn.Visible = True
                        RptButton.Visible = True
                        lblSubjectAns.Visible = True
                        lblAttendanceDateAns.Visible = True
                        lblAttendanceDate.Visible = True
                        lblSubject1.Visible = True
                        txtPassword.Focus()
                        lblpassError.Text = ""
                        Image2.Visible = False
                        Image3.Visible = False
                        El.Academic = 0
                        'El.Batch = cmbBatch.SelectedValue
                        'El.SemesterId = cmbSemester.SelectedValue
                        'El.SubjectId = cmbSubject.SelectedValue
                        El.SubjectId = cmbSubject.SelectedValue
                        dt4 = Bl.BatchAccess(El)
                        If dt4.Rows.Count > 0 Then
                            '   Subject = dt.Rows(i).Item("Subject").ToString
                            Dim str As String = ""
                            Dim str1 As String = ""
                            Dim id As String = ""
                            Dim i, i1 As Integer
                            Dim j, j1 As Integer
                            i = 0
                            j = dt4.Rows.Count
                            If j > 0 Then
                                While j > 0
                                    str = dt4.Rows(i).Item("BatchID").ToString
                                    El.Batch = str + "," + El.Batch
                                    i = i + 1
                                    j = j - 1
                                End While
                            Else
                                El.Batch = 0
                            End If
                            dt5 = Bl.SemAccess(El)
                            i1 = 0
                            j1 = dt5.Rows.Count
                            If j1 > 0 Then
                                While j1 > 0
                                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                                    El.SemesterId = str1 + "," + El.SemesterId
                                    i1 = i1 + 1
                                    j1 = j1 - 1
                                End While
                            Else
                                El.SemesterId = 0
                            End If
                        End If
                        'El.ElecSub = ddlElecSub.SelectedValue
                        El.AttendanceDate = Me.TxtAttdate.Text
                        El.SubGrp = ddlSubjectSubGrp.SelectedValue
                        Image3.Visible = True
                        Image2.Visible = True
                        AssignEntity()
                        display(El)
                        msginfo.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                        lblmsg.Text = ViewState("CountID").ToString + ValidationMessage(1103)
                    End If
                Else

                    Dim role As String
                    role = Session("UserRole")
                    'dt = stdAttndance.PostCheck(role)
                    'If dt.Rows.Count > 0 Then

                    If Session("SecurityCheck") = "Security Check" Then
                        dt = StdAttendancewitclasstypeDL.UnlockCheckStdAttendance(role)
                        If dt.Rows.Count < 1 Then
                            msginfo.Text = ValidationMessage(1102)
                            lblmsg.Text = ValidationMessage(1014)
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                            Image3.Visible = True
                            Image2.Visible = True
                        Else
                            check = dt.Rows(0)("Result").ToString.Trim
                            If check = "" Then
                                msginfo.Text = ValidationMessage(1102)
                                lblmsg.Text = ValidationMessage(1014)
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                GVStdAttd.Enabled = False
                                Image3.Visible = True
                                Image2.Visible = True
                                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                            Else
                                Dim roweffected As Integer = Bl.UnLockAttendance(ViewState("ConcatID"))
                                If roweffected > 0 Then
                                    ControlsPanel.Visible = True
                                    PasswordPanel.Visible = False
                                    El.Academic = 0
                                    'El.Batch = cmbBatch.SelectedValue
                                    'El.SemesterId = cmbSemester.SelectedValue
                                    'El.SubjectId = cmbSubject.SelectedValue
                                    El.SubjectId = cmbSubject.SelectedValue
                                    dt4 = Bl.BatchAccess(El)
                                    If dt4.Rows.Count > 0 Then
                                        '   Subject = dt.Rows(i).Item("Subject").ToString
                                        Dim str As String = ""
                                        Dim str1 As String = ""
                                        Dim id As String = ""
                                        Dim i, i1 As Integer
                                        Dim j, j1 As Integer
                                        i = 0
                                        j = dt4.Rows.Count
                                        If j > 0 Then
                                            While j > 0
                                                str = dt4.Rows(i).Item("BatchID").ToString
                                                El.Batch = str + "," + El.Batch
                                                i = i + 1
                                                j = j - 1
                                            End While
                                        Else
                                            El.Batch = 0
                                        End If
                                        dt5 = Bl.SemAccess(El)
                                        i1 = 0
                                        j1 = dt5.Rows.Count
                                        If j1 > 0 Then
                                            While j1 > 0
                                                str1 = dt5.Rows(i1).Item("SemesterID").ToString
                                                El.SemesterId = str1 + "," + El.SemesterId
                                                i1 = i1 + 1
                                                j1 = j1 - 1
                                            End While
                                        Else
                                            El.SemesterId = 0
                                        End If
                                    End If
                                    'El.ClassType = ddlClasstype.SelectedValue
                                    El.AttendanceDate = Me.TxtAttdate.Text
                                    El.SubGrp = ddlSubjectSubGrp.SelectedValue
                                    AssignEntity()
                                    display(El)
                                    msginfo.Text = ValidationMessage(1014)
                                    lblmsg.Text = ValidationMessage(1014)
                                    lblmsg.Text = ViewState("CountID").ToString + ValidationMessage(1104)
                                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                                    Image3.Visible = True
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
                        Dim roweffected As Integer = Bl.UnLockAttendance(ViewState("ConcatID"))
                        If roweffected > 0 Then
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            El.Academic = 0
                            'El.Batch = cmbBatch.SelectedValue
                            'El.SemesterId = cmbSemester.SelectedValue
                            'El.SubjectId = cmbSubject.SelectedValue
                            El.SubjectId = cmbSubject.SelectedValue
                            dt4 = Bl.BatchAccess(El)
                            If dt4.Rows.Count > 0 Then
                                '   Subject = dt.Rows(i).Item("Subject").ToString
                                Dim str As String = ""
                                Dim str1 As String = ""
                                Dim id As String = ""
                                Dim i, i1 As Integer
                                Dim j, j1 As Integer
                                i = 0
                                j = dt4.Rows.Count
                                If j > 0 Then
                                    While j > 0
                                        str = dt4.Rows(i).Item("BatchID").ToString
                                        El.Batch = str + "," + El.Batch
                                        i = i + 1
                                        j = j - 1
                                    End While
                                Else
                                    El.Batch = 0
                                End If
                                dt5 = Bl.SemAccess(El)
                                i1 = 0
                                j1 = dt5.Rows.Count
                                If j1 > 0 Then
                                    While j1 > 0
                                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                                        El.SemesterId = str1 + "," + El.SemesterId
                                        i1 = i1 + 1
                                        j1 = j1 - 1
                                    End While
                                Else
                                    El.SemesterId = 0
                                End If
                            End If
                            'El.ClassType = ddlClasstype.SelectedValue
                            El.AttendanceDate = Me.TxtAttdate.Text
                            El.SubGrp = ddlSubjectSubGrp.SelectedValue
                            AssignEntity()
                            display(El)
                            msginfo.Text = ValidationMessage(1014)
                            lblmsg.Text = ValidationMessage(1014)
                            lblmsg.Text = ViewState("CountID").ToString + ValidationMessage(1104)
                            Image3.Visible = True
                            Image2.Visible = True
                        End If
                        'End If
                    End If
                End If
            ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                msginfo.Text = ValidationMessage(1106)
                Image3.Visible = True
                Image2.Visible = True
                lblmsg.Text = ValidationMessage(1014)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

            End If
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
        ViewState("Updated") = "True"
        btnLock.Focus()
    End Sub

    Protected Sub btnSendMsg_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSendMsg.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                El.Academic = 0
                'El.Batch = cmbBatch.SelectedItem.Value
                'El.SemesterId = cmbSemester.SelectedItem.Value
                'El.SubjectId = cmbSubject.SelectedItem.Value
                El.SubjectId = cmbSubject.SelectedValue

                If El.SubjectId = 0 Then
                    msginfo.Text = "Generate Records and then Send Message."
                    Exit Sub
                End If
                dt4 = Bl.BatchAccess(El)
                If dt4.Rows.Count > 0 Then
                    '   Subject = dt.Rows(i).Item("Subject").ToString
                    Dim str As String = ""
                    Dim str1 As String = ""
                    Dim id As String = ""
                    Dim i, i1 As Integer
                    Dim j, j1 As Integer
                    i = 0
                    j = dt4.Rows.Count
                    If j > 0 Then
                        While j > 0
                            str = dt4.Rows(i).Item("BatchID").ToString
                            El.Batch = str + "," + El.Batch
                            i = i + 1
                            j = j - 1
                        End While
                    Else
                        El.Batch = 0
                    End If
                    dt5 = Bl.SemAccess(El)
                    i1 = 0
                    j1 = dt5.Rows.Count
                    If j1 > 0 Then
                        While j1 > 0
                            str1 = dt5.Rows(i1).Item("SemesterID").ToString
                            El.SemesterId = str1 + "," + El.SemesterId
                            i1 = i1 + 1
                            j1 = j1 - 1
                        End While
                    Else
                        El.SemesterId = 0
                    End If
                End If
                'El.ElecSub = ddlElecSub.SelectedItem.Value
                El.AttendanceDate = Me.TxtAttdate.Text
                El.SubGrp = ddlSubjectSubGrp.SelectedValue
                AssignEntity()
                For Each grid As GridViewRow In GVStdAttd.Rows
                    El.AttendanceDate = CType(grid.FindControl("l6"), Label).Text
                    El.SessionCountDay = CType(grid.FindControl("l7"), Label).Text
                Next
                dt = Bl.GetByGVStdAttd(El)
                If dt.Rows.Count > 0 Then
                    ViewState("ConcatID") = ""
                    For i As Integer = 0 To dt.Rows.Count - 1
                        ViewState("ConcatID") = dt.Rows(i).Item("Id").ToString + "," + ViewState("ConcatID")
                    Next
                End If
                If Bl.CheckLockAttendance(ViewState("ConcatID")) = "Y" Then
                    msginfo.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1213)
                    'cmbAcademic.Focus()
                    pnllabel.Visible = True
                Else
                    If ViewState("Updated") = "True" Then
                        Dim Service As String = IIf(Session("EmailService") = "Y" And Session("SMSService") = "Y", "Both", IIf(Session("EmailService") = "Y", "Email", IIf(Session("SMSService") = "Y", "SMS", "Nothing")))
                        sendmsg(Service)
                    Else
                        lblmsg.Text = ValidationMessage(1014)
                        msginfo.Text = ValidationMessage(1214)
                    End If
                End If
            Else
                msginfo.Text = ValidationMessage(1215)
                lblmsg.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub sendmsg(ByVal service As String)
        Dim vm As String
        Dim parm_msg, parm_phonesp, param_Subject As SqlParameter
        El.Academic = 0
        'El.Batch = cmbBatch.SelectedItem.Value
        'El.SemesterId = cmbSemester.SelectedItem.Value
        'El.SubjectId = cmbSubject.SelectedItem.Value
        El.SubjectId = cmbSubject.SelectedValue
        dt4 = Bl.BatchAccess(El)
        If dt4.Rows.Count > 0 Then
            '   Subject = dt.Rows(i).Item("Subject").ToString
            Dim str As String = ""
            Dim str1 As String = ""
            Dim id As String = ""
            Dim i, i1 As Integer
            Dim j, j1 As Integer
            i = 0
            j = dt4.Rows.Count
            If j > 0 Then
                While j > 0
                    str = dt4.Rows(i).Item("BatchID").ToString
                    El.Batch = str + "," + El.Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                El.Batch = 0
            End If
            dt5 = Bl.SemAccess(El)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    El.SemesterId = str1 + "," + El.SemesterId
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                El.SemesterId = 0
            End If
        End If
        'El.ElecSub = ddlElecSub.SelectedItem.Value
        El.AttendanceDate = Me.TxtAttdate.Text()
        El.SubGrp = ddlSubjectSubGrp.SelectedValue
        AssignEntity()
        dt = Bl.GetByGVStdAttd(El)
        If dt.Rows.Count > 0 Then
            ViewState("ConcatID") = ""
            For i As Integer = 0 To dt.Rows.Count - 1
                ViewState("ConcatID") = dt.Rows(i).Item("Id").ToString + "," + ViewState("ConcatID")
            Next
        End If
        dt.Clear()
        If service <> "Nothing" Then
            dt = Bl.SendMessage(ViewState("ConcatID"), service)
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
                msginfo.Text = ValidationMessage(1014)
                lblmsg.Text = service + ValidationMessage(1216)
                'If service = "Nothing" Then
                '    service = "SMS and Email"
                '    msginfo.Text = "SMS and Email are blocked."
                '    lblmsg.Text = ""
                'End If
            Else
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1217)
            End If
        Else
            msginfo.Text = ValidationMessage(1218)
            lblmsg.Text = ValidationMessage(1014)
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
            'El.Academic = cmbAcademic.SelectedValue
            'El.Batch = cmbBatch.SelectedItem.Value
            'El.SemesterId = cmbSemester.SelectedItem.Value
            El.SubjectId = cmbSubject.SelectedValue
            dt4 = Bl.BatchAccess(El)
            If dt4.Rows.Count > 0 Then
                '   Subject = dt.Rows(i).Item("Subject").ToString
                Dim str As String = ""
                Dim str1 As String = ""
                Dim id As String = ""
                Dim i, i1 As Integer
                Dim j, j1 As Integer
                i = 0
                j = dt4.Rows.Count
                If j > 0 Then
                    While j > 0
                        str = dt4.Rows(i).Item("BatchID").ToString
                        El.Batch = str + "," + El.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    El.Batch = 0
                End If
                dt5 = Bl.SemAccess(El)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        El.SemesterId = str1 + "," + El.SemesterId
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    El.SemesterId = 0
                End If
            End If
            If cmbSemester.SelectedValue <> 0 Then
                dt = b.GetSubjectComboBatchPlanner(El.Batch, El.SemesterId)
                If dt.Rows.Count <= 1 Then
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1219)
                Else
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1014)
                End If
            Else
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1022)
        End Try
    End Sub

    Protected Sub cmbSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.TextChanged
        cmbSemester.Focus()
    End Sub

    Protected Sub cmbSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubject.SelectedIndexChanged
        El.SubjectId = cmbSubject.SelectedValue
        dt4 = Bl.BatchAccess(El)
        If dt4.Rows.Count > 0 Then
            '   Subject = dt.Rows(i).Item("Subject").ToString
            Dim str As String = ""
            Dim str1 As String = ""
            Dim id As String = ""
            Dim i, i1 As Integer
            Dim j, j1 As Integer
            i = 0
            j = dt4.Rows.Count
            If j > 0 Then
                While j > 0
                    str = dt4.Rows(i).Item("BatchID").ToString
                    El.Batch = str + "," + El.Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                El.Batch = 0
            End If
            dt5 = Bl.SemAccess(El)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    El.SemesterId = str1 + "," + El.SemesterId
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                El.SemesterId = 0
            End If

        End If
    End Sub

    Protected Sub cmbSubject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubject.TextChanged
        cmbSubject.Focus()
    End Sub

    Protected Sub GVStdAttd_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVStdAttd.RowDeleting
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                El.Id = CType(GVStdAttd.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
                If Bl.ChangeFlag(El) Then
                    msginfo.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1028)
                    cmbBatch.Focus()
                    GVStdAttd.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    GVStdAttd.Enabled = True
                End If
            Else
                msginfo.Text = ValidationMessage(1029)
                msginfo.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception

        End Try
    End Sub

    'Protected Sub ddlClasstype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlClasstype.TextChanged
    '    ddlClasstype.Focus()
    'End Sub

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
        El.SubjectId = cmbSubject.SelectedValue
        dt4 = Bl.BatchAccess(El)
        If dt4.Rows.Count > 0 Then
            '   Subject = dt.Rows(i).Item("Subject").ToString
            Dim str As String = ""
            Dim str1 As String = ""
            Dim id As String = ""
            Dim i, i1 As Integer
            Dim j, j1 As Integer
            i = 0
            j = dt4.Rows.Count
            If j > 0 Then
                While j > 0
                    str = dt4.Rows(i).Item("BatchID").ToString
                    El.Batch = str + "," + El.Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                El.Batch = 0
            End If
            dt5 = Bl.SemAccess(El)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    El.SemesterId = str1 + "," + El.SemesterId
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                El.SemesterId = 0
            End If
        End If
        'El.ElecSub = ddlElecSub.SelectedItem.Value
        El.AttendanceDate = Me.TxtAttdate.Text()
        El.SubGrp = ddlSubjectSubGrp.SelectedValue
        AssignEntity()
        'display(El)




        Dim dt As New Data.DataTable
        dt = Bl.GetByGVStdAttd(El)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        ViewState("SortExpression") = e.SortExpression
        ViewState("sortingDirection") = sortingDirection
        GVStdAttd.DataSource = sortedView
        GVStdAttd.DataBind()
       
        'lblAcademicYearAns.Text = ""
        lblBatchAns.Text = ""
        lblSemesterAns.Text = ""
        'lblClassTypeAns.Text = ""
        lblSubjectAns.Text = ""
        lblAttendanceDateAns.Text = ""

        For Each grid As GridViewRow In GVStdAttd.Rows
            'lblAcademicYearAns.Text = CType(grid.FindControl("l1"), Label).Text
            lblBatchAns.Text = CType(grid.FindControl("l2"), Label).Text
            lblSemesterAns.Text = CType(grid.FindControl("l3"), Label).Text
            'lblClassTypeAns.Text = CType(grid.FindControl("l5"), Label).Text()
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



    Protected Sub BtnAddDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddDetails.Click
        El.Academic = 0
        'El.Batch = cmbBatch.SelectedItem.Value
        'El.SemesterId = cmbSemester.SelectedItem.Value
        'El.SubjectId = cmbSubject.SelectedItem.Value
        El.SubjectId = cmbSubject.SelectedValue
        If El.SubjectId = 0 Then
            msginfo.Text = "Subject field is mandatory."
            Exit Sub
        End If
        dt4 = Bl.BatchAccess(El)
        If dt4.Rows.Count > 0 Then
            '   Subject = dt.Rows(i).Item("Subject").ToString
            Dim str As String = ""
            Dim str1 As String = ""
            Dim id As String = ""
            Dim i, i1 As Integer
            Dim j, j1 As Integer
            i = 0
            j = dt4.Rows.Count
            If j > 0 Then
                While j > 0
                    str = dt4.Rows(i).Item("BatchID").ToString
                    El.Batch = str + "," + El.Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                El.Batch = 0
                End If

                dt5 = Bl.SemAccess(El)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        El.SemesterId = str1 + "," + El.SemesterId
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    El.SemesterId = 0
                End If
            End If

            'El.ElecSub = ddlElecSub.SelectedItem.Value
            El.AttendanceDate = Me.TxtAttdate.Text()
            El.SubGrp = ddlSubjectSubGrp.SelectedValue
            AssignEntity()
            dt1 = Bl.Attendanceduplicate(El)
            If dt1.Rows.Count <= 0 Then
                msginfo.Visible = True
                msginfo.Text = ValidationMessage(1107)
                TabContainer1.ActiveTab = TabPanel1
                TabPanel2.Enabled = True
                TabPanel2.Visible = True
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)
                lblmsg.Text = ValidationMessage(1014)
                Exit Sub
            End If
            dt = Bl.GetByGVStdAttd(El)
            If dt.Rows.Count > 0 Then
                ViewState("ConcatID") = ""
                For i As Integer = 0 To dt.Rows.Count - 1
                    ViewState("ConcatID") = dt.Rows(i).Item("Id").ToString + "," + ViewState("ConcatID")
                Next
            End If
            If Bl.CheckLockAttendance(ViewState("ConcatID")) = "Y" Then
                msginfo.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1220)
                Exit Sub
            End If
            ddlStudent.Focus()
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            lblGreen.Text = ValidationMessage(1014)
            'If cmbBatch.SelectedValue = 0 Then
            '    msginfo.Text = ValidationMessage(1178)
            '    lblmsg.Text = ValidationMessage(1014)
            '    Exit Sub
            'End If
            'If cmbSemester.SelectedValue = 0 Then
            '    msginfo.Text = ValidationMessage(1095)
            '    lblmsg.Text = ValidationMessage(1014)
            '    Exit Sub
            'End If
            If TxtAttdate.Text = "" Then
                msginfo.Text = ValidationMessage(1221)
                lblmsg.Text = ValidationMessage(1014)
                Exit Sub
            End If
            TabContainer1.ActiveTab = TabPanel2
            TabPanel2.Enabled = True
            TabPanel2.Visible = True
            'TabPanel1.Enabled = False
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='hidden';", True)

            'btnAdddet.Enabled = True
            'GVSaleInvoiceDetails.Visible = False
            'El.Batch = cmbBatch.SelectedItem.Value
            'El.SemesterId = cmbSemester.SelectedItem.Value
            'El.SubjectId = cmbSubject.SelectedItem.Value
            El.SubjectId = cmbSubject.SelectedValue
            dt4 = Bl.BatchAccess(El)
            If dt4.Rows.Count > 0 Then
                '   Subject = dt.Rows(i).Item("Subject").ToString
                Dim str As String = ""
                Dim str1 As String = ""
                Dim id As String = ""
                Dim i, i1 As Integer
                Dim j, j1 As Integer
                i = 0
                j = dt4.Rows.Count
                If j > 0 Then
                    While j > 0
                        str = dt4.Rows(i).Item("BatchID").ToString
                        El.Batch = str + "," + El.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    El.Batch = 0
                End If
                dt5 = Bl.SemAccess(El)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        El.SemesterId = str1 + "," + El.SemesterId
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    El.SemesterId = 0
                End If
            End If
            El.AttendanceDate = Me.TxtAttdate.Text()
            El.SubGrp = ddlSubjectSubGrp.SelectedValue
            'ddlStudent.Items.Clear()
            'ddlStudent.DataSourceID = "ObjStudent"
            dt = StudentPerformanceDL.GetStudentNameCombo2(El.Batch, El.SubGrp, El.SubjectId)
            ddlStudent.DataSource = dt
            ddlStudent.DataBind()
            

            'If HidInvoice.Text = "" Then
            '    dt = Bl.GetInvoiceNo()
            '    HidInvoice.Text = dt.Rows(0).Item("InvoiceId").ToString
            '    HidInvoiceNO.Text = dt.Rows(0).Item("InvoiceNo").ToString
            'Else
            '    El.InvoiceID = HidInvoice.Text
            'End If


    End Sub

    Protected Sub BtnGen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGen.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If BtnGen.Text = "ADD" Then
                    btnSendMsg.Enabled = True
                    El.Academic = 0
                    'El.Batch = cmbBatch.SelectedValue
                    'El.SemesterId = cmbSemester.SelectedValue
                    'El.SubjectId = cmbSubject.SelectedValue
                    El.SubjectId = cmbSubject.SelectedValue
                    dt4 = Bl.BatchAccess(El)
                    If dt4.Rows.Count > 0 Then
                        '   Subject = dt.Rows(i).Item("Subject").ToString
                        Dim str As String = ""
                        Dim str1 As String = ""
                        Dim id As String = ""
                        Dim i, i1 As Integer
                        Dim j, j1 As Integer
                        i = 0
                        j = dt4.Rows.Count
                        If j > 0 Then
                            While j > 0
                                str = dt4.Rows(i).Item("BatchID").ToString
                                El.Batch = str + "," + El.Batch
                                i = i + 1
                                j = j - 1
                            End While
                        Else
                            El.Batch = 0
                        End If
                        dt5 = Bl.SemAccess(El)
                        i1 = 0
                        j1 = dt5.Rows.Count
                        If j1 > 0 Then
                            While j1 > 0
                                str1 = dt5.Rows(i1).Item("SemesterID").ToString
                                El.SemesterId = str1 + "," + El.SemesterId
                                i1 = i1 + 1
                                j1 = j1 - 1
                            End While
                        Else
                            El.SemesterId = 0
                        End If
                    End If
                    El.AttendanceDate = Me.TxtAttdate.Text
                    El.SubGrp = ddlSubjectSubGrp.SelectedValue
                    El.StdId = ddlStudent.SelectedValue
                    AssignEntity()
                    dt1 = Bl.Attendanceduplicate(El)
                    If dt1.Rows.Count <= 0 Then
                        msginfo.Visible = True
                        msginfo.Text = ValidationMessage(1107)
                        TabContainer1.ActiveTab = TabPanel1
                        TabPanel2.Enabled = True
                        TabPanel2.Visible = True
                        ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                        'cmbAcademic.Focus()
                        lblmsg.Text = ValidationMessage(1014)
                        Exit Sub
                    End If
                    If (El.AttendanceDate > Today()) Then
                        msginfo.Text = ValidationMessage(1209)
                        lblmsg.Text = ValidationMessage(1014)
                        TabContainer1.ActiveTab = TabPanel1
                        TabPanel2.Enabled = True
                        TabPanel2.Visible = True
                    Else
                        dt = Bl.Attendanceduplicate1(El)
                        If dt.Rows.Count > 0 Then
                            msginfo.Visible = True
                            lblRed.Text = ValidationMessage(1044)
                            'cmbAcademic.Focus()
                            lblGreen.Text = ValidationMessage(1014)
                        Else
                            Session("ButtonType") = "SUBMIT"
                            Bl.InsertAttandance1(El)
                            dt = Bl.GetByGVStdAttd(El)
                            lblmsg.Text = dt.Rows.Count().ToString + ValidationMessage(1109)
                            TabContainer1.ActiveTab = TabPanel1
                            TabPanel2.Enabled = True
                            TabPanel2.Visible = True
                            msginfo.Text = ValidationMessage(1014)
                            display(El)
                            LinkButton.Focus()
                            'cmbAcademic.Focus()

                            'msginfo.Visible = False
                        End If
                    End If
                End If
                ViewState("Updated") = "False"
            Else
                msginfo.Text = ValidationMessage(1210)
                lblmsg.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1059)
            lblmsg.Text = ValidationMessage(1014)
        End Try
    End Sub
    Sub ViewDataStatus()
        Try
            ' El.Batch = cmbBatch.SelectedValue
            'el.Semester = ddlsemester.SelectedValue
            'el.Subject = ddlsubject.SelectedValue
            El.SubjectId = cmbSubject.SelectedValue
            If El.SubjectId = 0 Then
                msginfo.Text = "Select a Subject."
                Exit Sub
            End If
            dt4 = Bl.BatchAccess(El)
            If dt4.Rows.Count > 0 Then
                '   Subject = dt.Rows(i).Item("Subject").ToString
                Dim str As String = ""
                Dim str1 As String = ""
                Dim id As String = ""
                Dim i, i1 As Integer
                Dim j, j1 As Integer
                i = 0
                j = dt4.Rows.Count
                If j > 0 Then
                    While j > 0
                        str = dt4.Rows(i).Item("BatchID").ToString
                        El.Batch = str + "," + El.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    El.Batch = 0
                End If
                dt5 = Bl.SemAccess(El)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        El.SemesterId = str1 + "," + El.SemesterId
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    El.SemesterId = 0
                End If
            End If
            Dim qrystring As String = "RptStdAttenDataStatusBySub.aspx?" & QueryStr.Querystring() & "&Batch=" & El.Batch
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        Catch ex As Exception

        End Try
    End Sub
    
    ''Retriving the text of controls based on Language

   
   
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        Try

            'Dim Message As String
            dt2 = Session("ValidationTable")
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
    Protected Sub RptButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RptButton.Click
        Try
            LinkButton.Focus()
            btnSendMsg.Enabled = True
            El.Academic = 0
            'El.Batch = cmbBatch.SelectedValue
            'El.SemesterId = cmbSemester.SelectedValue
            'El.SubjectId = cmbSubject.SelectedValue
            El.SubjectId = cmbSubject.SelectedValue
            dt4 = Bl.BatchAccess(El)
            If dt4.Rows.Count > 0 Then
                '   Subject = dt.Rows(i).Item("Subject").ToString
                Dim str As String = ""
                Dim str1 As String = ""
                Dim id As String = ""
                Dim i, i1 As Integer
                Dim j, j1 As Integer
                i = 0
                j = dt4.Rows.Count
                If j > 0 Then
                    While j > 0
                        str = dt4.Rows(i).Item("BatchID").ToString
                        El.Batch = str + "," + El.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    El.Batch = 0
                End If
                dt5 = Bl.SemAccess(El)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        El.SemesterId = str1 + "," + El.SemesterId
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    El.SemesterId = 0
                End If
            End If
            'El.ClassType = ddlClasstype.SelectedValue
            'El.ElecSub = ddlElecSub.SelectedValue
            El.AttendanceDate = Me.TxtAttdate.Text
            El.SubGrp = ddlSubjectSubGrp.SelectedValue
            AssignEntity()
            Dim qrystring As String = "RptStudAttenBySub.aspx?" & "&Ayear=" & El.Academic & "&Batch=" & El.Batch & "&Semester=" & El.SemesterId & "&Subject=" & El.SubjectId & "&AttenDate=" & El.AttendanceDate & "&SubGrp=" & El.SubGrp & "&SessionCountDay=" & El.SessionCountDay
            'Updated File --> RptStudAttenBySub.aspx
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1022)
            msginfo.Text = ValidationMessage(1014)
        End Try

    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub

    Protected Sub RptAttendanceBtn_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RptAttendanceBtn.Click
        Try
            LinkButton.Focus()
            btnSendMsg.Enabled = True
            El.Academic = 0
            'El.Batch = cmbBatch.SelectedValue
            'El.SemesterId = cmbSemester.SelectedValue
            'El.SubjectId = cmbSubject.SelectedValue
            El.SubjectId = cmbSubject.SelectedValue
            dt4 = Bl.BatchAccess(El)
            If dt4.Rows.Count > 0 Then
                '   Subject = dt.Rows(i).Item("Subject").ToString
                Dim str As String = ""
                Dim str1 As String = ""
                Dim id As String = ""
                Dim i, i1 As Integer
                Dim j, j1 As Integer
                i = 0
                j = dt4.Rows.Count
                If j > 0 Then
                    While j > 0
                        str = dt4.Rows(i).Item("BatchID").ToString
                        El.Batch = str + "," + El.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    El.Batch = 0
                End If
                dt5 = Bl.SemAccess(El)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        El.SemesterId = str1 + "," + El.SemesterId
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    El.SemesterId = 0
                End If
            End If
            'El.ClassType = ddlClasstype.SelectedValue
            'El.ElecSub = ddlElecSub.SelectedValue
            El.AttendanceDate = Me.TxtAttdate.Text
            El.SubGrp = ddlSubjectSubGrp.SelectedValue
            AssignEntity()
            Dim qrystring As String = "RptStudentAttendanceSheetV.aspx?" & "&Ayear=" & El.Academic & "&Batch=" & El.Batch & "&Semester=" & El.SemesterId & "&Subject=" & El.SubjectId & "&AttenDate=" & El.AttendanceDate & "&SubGrp=" & El.SubGrp & "&SessionCountDay=" & El.SessionCountDay
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1022)
            msginfo.Text = ValidationMessage(1014)
        End Try

    End Sub
End Class
