Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls

Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Drawing



Partial Class frm_NewStdMarks
    Inherits BasePage
    Dim el As New NewStdMarks
    Dim b As New BLNew_stdMarks
    Dim d As New DLNew_StudentMarks
    Dim dt, dt1 As New Data.DataTable


    Protected Sub btngenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngenerate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'lblAcademicYearAns.Text = ""
            lblBatchAns.Text = ""
            lblSemesterAns.Text = ""
            lblClassTypeAns.Text = ""
            lblSubjectAns.Text = ""
            lblAssessmentTypeAns.Text = ""
            Try
                If CInt(txtmax.Text) < CInt(txtMin.Text) Then
                    lblerror.Text = ""
                    lblmsg.Text = ""
                    lblerror.Text = "Max Marks cannot be lesser than Min Marks."
                Else
                    'If ddlA_Year.SelectedValue = 0 Or ddlbatch.SelectedValue = 0 Or ddlsemester.SelectedValue = 0 Or ddlsubject.SelectedValue = 0 Or ddlassesment.SelectedValue = 0 Or ddlclass.SelectedValue = 0 Then
                    '    lblerror.Text = "Subject, Assesment and Class Type Fields are Mandatory"
                    'Else
                    'Dummy comment

                    el.A_Year = 0
                    el.Batch = ddlbatch.SelectedValue
                    el.Semester = ddlsemester.SelectedValue
                    el.Subject = ddlsubject.SelectedValue
                    el.Assesment = ddlassesment.SelectedValue
                    el.ClassType = ddlclass.SelectedValue
                    el.Max = txtmax.Text
                    el.Min = txtMin.Text
                    el.SubGrp = ddlSubjectSubGrp.SelectedValue
                    dt = b.GetBatch(el)
                    If dt.Rows(0).Item("Subgrp_Status") = "Y" Then
                        If ddlSubjectSubGrp.SelectedValue = 0 Then
                            lblerror.Text = "Please Select Subject Subgroup."
                            lblmsg.Text = ""
                            Exit Sub
                        End If
                    End If
                    If b.InsertStdMarks(el) > 0 Then
                        dt = b.ViewStdMarks(el)
                        If dt.Rows.Count > 0 Then
                            GridView1.DataSource = dt
                            GridView1.DataBind()
                            GridView1.Visible = True
                            For Each grid As GridViewRow In GridView1.Rows
                                'lblAcademicYearAns.Text = ""
                                lblBatchAns.Text = ""
                                lblSemesterAns.Text = ""
                                lblClassTypeAns.Text = ""
                                lblSubjectAns.Text = ""
                                lblAssessmentTypeAns.Text = ""
                                'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                                lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                                lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                                lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                                lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                                pnllabel.Visible = True
                                CType(grid.FindControl("txtPassFail"), TextBox).Text = ""
                            Next
                            If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                                GridView1.Enabled = False
                            Else
                                GridView1.Enabled = True
                            End If
                        Else
                            lblerror.Text = ""
                            lblmsg.Text = ""
                            lblerror.Text = "No records to display."
                            pnllabel.Visible = False
                            GridView1.Visible = False
                        End If
                        lblerror.Text = ""
                        lblmsg.Text = ""
                        lblmsg.Text = dt.Rows.Count().ToString + " records generated."
                    Else
                        lblerror.Text = ""
                        lblmsg.Text = ""
                        lblerror.Text = "Data Already Generated."
                        pnllabel.Visible = False
                        GridView1.Visible = False
                    End If
                    clear()
                End If
            Catch ex As Exception
                lblerror.Text = ""
                lblmsg.Text = ""
                lblerror.Text = "Enter all mandatory fields."
                GridView1.Visible = False
                'ddlA_Year.Focus()
                pnllabel.Visible = False
            End Try
        Else
            lblerror.Text = "You do not belong to this branch, Cannot generate data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        'ddlA_Year.Focus()
        LinkButton.Focus()
        Try
            'If ddlA_Year.SelectedValue = 0 Or ddlbatch.SelectedValue = 0 Or ddlsemester.SelectedValue = 0 Or ddlsubject.SelectedValue = 0 Or ddlassesment.SelectedValue = 0 Or ddlclass.SelectedValue = 0 Then
            '    lblerror.Text = "Subject, Assesment and Class Type Fields are Mandatory."
            'Else
            el.A_Year = 0
            el.Batch = ddlbatch.SelectedValue
            el.Semester = ddlsemester.SelectedValue
            el.Subject = ddlsubject.SelectedValue
            el.Assesment = ddlassesment.SelectedValue
            el.ClassType = ddlclass.SelectedValue
            el.SubGrp = ddlSubjectSubGrp.SelectedValue
            lblerror.Text = ""
            lblmsg.Text = ""
            'el.Max = txtmax.Text
            'el.Min = txtMin.Text
            dt = b.ViewStdMarks(el)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Visible = True
                For Each grid As GridViewRow In GridView1.Rows
                    'lblAcademicYearAns.Text = ""
                    lblBatchAns.Text = ""
                    lblSemesterAns.Text = ""
                    lblClassTypeAns.Text = ""
                    lblSubjectAns.Text = ""
                    lblAssessmentTypeAns.Text = ""
                    'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                    lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                    lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                    lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                    lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                    lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                    pnllabel.Visible = True
                Next

                If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                    GridView1.Enabled = False
                Else
                    GridView1.Enabled = True
                End If
            Else
                lblerror.Text = ""
                lblmsg.Text = ""
                lblerror.Text = "No records to display."
                pnllabel.Visible = False
                GridView1.Visible = False
            End If
            'End If
        Catch ex As Exception
            lblerror.Text = ""
            lblmsg.Text = ""
            lblerror.Text = "Enter all mandatory fields."
            GridView1.Visible = False
            'ddlA_Year.Focus()
        End Try
    End Sub

    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                el.A_Year = 0
                el.Batch = ddlbatch.SelectedValue
                el.Semester = ddlsemester.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                el.Assesment = ddlassesment.SelectedValue
                el.ClassType = ddlclass.SelectedValue
                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                dt = b.ViewStdMarks(el)
                If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                    GridView1.Enabled = False
                    lblerror.Text = "Records are locked, cannot be updated."
                    lblmsg.Text = ""
                    Exit Sub
                Else
                    GridView1.Enabled = True
                End If
                If ChkBoxGrade.Checked = True Then


                    If ChkBoxHeader.Checked = True Then
                        lblerror.Text = ""
                        lblmsg.Text = ""
                        For Each grid As GridViewRow In GridView1.Rows
                            'lblAcademicYearAns.Text = ""
                            lblBatchAns.Text = ""
                            lblSemesterAns.Text = ""
                            lblClassTypeAns.Text = ""
                            lblSubjectAns.Text = ""
                            lblAssessmentTypeAns.Text = ""
                            'If CType(grid.FindControl("txtactmarks"), TextBox).Text <> "" Then
                            el.id = CType(grid.FindControl("lblid"), Label).Text
                            el.A_Marks = IIf(CType(grid.FindControl("txtactmarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtactmarks"), TextBox).Text)
                            el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                            el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                            el.Grade = CType(grid.FindControl("txtgrade"), TextBox).Text
                            el.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                            el.Batch = CType(grid.FindControl("Lblbatch"), Label).Text
                            el.Percent = (el.A_Marks / el.Max) * 100
                            'el.Percent = CType(grid.FindControl("Labelmarks"), Label).Text
                            If el.A_Marks < el.Min Then
                                el.Pass_Fail = "Fail"
                            Else
                                el.Pass_Fail = "Pass"

                            End If

                            b.UpdateMarksFromGrade(el)
                            'End If
                        Next
                        lblmsg.Text = "Data Updated Successfully."
                        el.A_Year = 0
                        el.Batch = ddlbatch.SelectedValue
                        el.Semester = ddlsemester.SelectedValue
                        el.Subject = ddlsubject.SelectedValue
                        el.Assesment = ddlassesment.SelectedValue
                        el.ClassType = ddlclass.SelectedValue
                        el.SubGrp = ddlSubjectSubGrp.SelectedValue
                        lblerror.Text = ""
                        lblmsg.Text = ""
                        'el.Max = txtmax.Text
                        'el.Min = txtMin.Text
                        dt = b.ViewStdMarks(el)
                        If dt.Rows.Count > 0 Then
                            GridView1.DataSource = dt
                            GridView1.DataBind()
                            GridView1.Visible = True
                            lblmsg.Text = "Data Updated Successfully."
                            lblerror.Text = ""
                            If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                                GridView1.Enabled = False
                                lblerror.Text = "Records are locked, cannot be updated."
                                lblmsg.Text = ""
                            Else
                                GridView1.Enabled = True
                            End If
                            For Each grid As GridViewRow In GridView1.Rows
                                'lblAcademicYearAns.Text = ""
                                lblBatchAns.Text = ""
                                lblSemesterAns.Text = ""
                                lblClassTypeAns.Text = ""
                                lblSubjectAns.Text = ""
                                lblAssessmentTypeAns.Text = ""
                                'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                                lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                                lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                                lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                                lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                                pnllabel.Visible = True
                            Next
                        Else
                            lblerror.Text = ""
                            lblmsg.Text = ""
                            lblerror.Text = "No records to display."
                            pnllabel.Visible = False
                            GridView1.Visible = False
                        End If
                    Else
                        lblerror.Text = ""
                        lblmsg.Text = ""
                        For Each grid As GridViewRow In GridView1.Rows
                            'lblAcademicYearAns.Text = ""
                            lblBatchAns.Text = ""
                            lblSemesterAns.Text = ""
                            lblClassTypeAns.Text = ""
                            lblSubjectAns.Text = ""
                            lblAssessmentTypeAns.Text = ""
                            'If CType(grid.FindControl("txtactmarks"), TextBox).Text <> "" Then
                            el.id = CType(grid.FindControl("lblid"), Label).Text
                            el.A_Marks = IIf(CType(grid.FindControl("txtactmarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtactmarks"), TextBox).Text)
                            el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                            el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                            el.Grade = CType(grid.FindControl("txtgrade"), TextBox).Text
                            el.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                            el.Batch = CType(grid.FindControl("Lblbatch"), Label).Text
                            el.Percent = (el.A_Marks / el.Max) * 100
                            CType(grid.FindControl("txtpassFail"), TextBox).Text = ""
                            b.UpdateMarksFromGrade(el)
                            'End If
                        Next
                        lblmsg.Text = "Data Updated Successfully."
                        el.A_Year = 0
                        el.Batch = ddlbatch.SelectedValue
                        el.Semester = ddlsemester.SelectedValue
                        el.Subject = ddlsubject.SelectedValue
                        el.Assesment = ddlassesment.SelectedValue
                        el.ClassType = ddlclass.SelectedValue
                        el.SubGrp = ddlSubjectSubGrp.SelectedValue
                        lblerror.Text = ""
                        lblmsg.Text = ""
                        'el.Max = txtmax.Text
                        'el.Min = txtMin.Text
                        dt = b.ViewStdMarks(el)
                        If dt.Rows.Count > 0 Then
                            GridView1.DataSource = dt
                            GridView1.DataBind()
                            GridView1.Visible = True
                            lblmsg.Text = "Data Updated Successfully."
                            lblerror.Text = ""
                            If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                                GridView1.Enabled = False
                                lblerror.Text = "Records are locked, cannot be updated."
                                lblmsg.Text = ""
                            Else
                                GridView1.Enabled = True
                            End If
                            For Each grid As GridViewRow In GridView1.Rows
                                'lblAcademicYearAns.Text = ""
                                lblBatchAns.Text = ""
                                lblSemesterAns.Text = ""
                                lblClassTypeAns.Text = ""
                                lblSubjectAns.Text = ""
                                lblAssessmentTypeAns.Text = ""
                                'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                                lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                                lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                                lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                                lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                                pnllabel.Visible = True
                            Next
                        Else
                            lblerror.Text = ""
                            lblmsg.Text = ""
                            lblerror.Text = "No records to display."
                            pnllabel.Visible = False
                            GridView1.Visible = False
                        End If
                    End If
                ElseIf ChkBoxHeader.Checked = True Then
                    lblerror.Text = ""
                    lblmsg.Text = ""
                    For Each grid As GridViewRow In GridView1.Rows
                        'lblAcademicYearAns.Text = ""
                        lblBatchAns.Text = ""
                        lblSemesterAns.Text = ""
                        lblClassTypeAns.Text = ""
                        lblSubjectAns.Text = ""
                        lblAssessmentTypeAns.Text = ""
                        'If CType(grid.FindControl("txtactmarks"), TextBox).Text <> "" Then
                        el.id = CType(grid.FindControl("lblid"), Label).Text
                        el.A_Marks = IIf(CType(grid.FindControl("txtactmarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtactmarks"), TextBox).Text)
                        el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                        el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                        el.Grade = CType(grid.FindControl("txtgrade"), TextBox).Text
                        el.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                        el.Batch = CType(grid.FindControl("Lblbatch"), Label).Text
                        el.Percent = (el.A_Marks / el.Max) * 100
                        'el.Percent = CType(grid.FindControl("Labelmarks"), Label).Text
                        If el.A_Marks < el.Min Then
                            el.Pass_Fail = "Fail"
                        Else
                            el.Pass_Fail = "Pass"

                        End If

                        b.UpdateMarks(el)
                        'End If
                    Next
                    lblmsg.Text = "Data Updated Successfully."
                    el.A_Year = 0
                    el.Batch = ddlbatch.SelectedValue
                    el.Semester = ddlsemester.SelectedValue
                    el.Subject = ddlsubject.SelectedValue
                    el.Assesment = ddlassesment.SelectedValue
                    el.ClassType = ddlclass.SelectedValue
                    el.SubGrp = ddlSubjectSubGrp.SelectedValue
                    lblerror.Text = ""
                    lblmsg.Text = ""
                    'el.Max = txtmax.Text
                    'el.Min = txtMin.Text
                    dt = b.ViewStdMarks(el)
                    If dt.Rows.Count > 0 Then
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        GridView1.Visible = True
                        lblmsg.Text = "Data Updated Successfully."
                        lblerror.Text = ""
                        If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                            GridView1.Enabled = False
                            lblerror.Text = "Records are locked, cannot be updated."
                            lblmsg.Text = ""
                        Else
                            GridView1.Enabled = True
                        End If
                        For Each grid As GridViewRow In GridView1.Rows
                            'lblAcademicYearAns.Text = ""
                            lblBatchAns.Text = ""
                            lblSemesterAns.Text = ""
                            lblClassTypeAns.Text = ""
                            lblSubjectAns.Text = ""
                            lblAssessmentTypeAns.Text = ""
                            'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                            lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                            lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                            lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                            lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                            lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                            pnllabel.Visible = True
                        Next
                    Else
                        lblerror.Text = ""
                        lblmsg.Text = ""
                        lblerror.Text = "No records to display."
                        pnllabel.Visible = False
                        GridView1.Visible = False
                    End If

                Else
                    lblerror.Text = ""
                    lblmsg.Text = ""
                    For Each grid As GridViewRow In GridView1.Rows
                        'lblAcademicYearAns.Text = ""
                        lblBatchAns.Text = ""
                        lblSemesterAns.Text = ""
                        lblClassTypeAns.Text = ""
                        lblSubjectAns.Text = ""
                        lblAssessmentTypeAns.Text = ""
                        'If CType(grid.FindControl("txtactmarks"), TextBox).Text <> "" Then
                        el.id = CType(grid.FindControl("lblid"), Label).Text
                        el.A_Marks = IIf(CType(grid.FindControl("txtactmarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtactmarks"), TextBox).Text)
                        el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                        el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                        el.Grade = CType(grid.FindControl("txtgrade"), TextBox).Text
                        el.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                        el.Batch = CType(grid.FindControl("Lblbatch"), Label).Text
                        el.Percent = (el.A_Marks / el.Max) * 100
                        CType(grid.FindControl("txtpassFail"), TextBox).Text = ""
                        b.UpdateMarks(el)
                        'End If
                    Next
                    lblmsg.Text = "Data Updated Successfully."
                    el.A_Year = 0
                    el.Batch = ddlbatch.SelectedValue
                    el.Semester = ddlsemester.SelectedValue
                    el.Subject = ddlsubject.SelectedValue
                    el.Assesment = ddlassesment.SelectedValue
                    el.ClassType = ddlclass.SelectedValue
                    el.SubGrp = ddlSubjectSubGrp.SelectedValue
                    lblerror.Text = ""
                    lblmsg.Text = ""
                    'el.Max = txtmax.Text
                    'el.Min = txtMin.Text
                    dt = b.ViewStdMarks(el)
                    If dt.Rows.Count > 0 Then
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        GridView1.Visible = True
                        lblmsg.Text = "Data Updated Successfully."
                        lblerror.Text = ""
                        If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                            GridView1.Enabled = False
                            lblerror.Text = "Records are locked, cannot be updated."
                            lblmsg.Text = ""
                        Else
                            GridView1.Enabled = True
                        End If
                        For Each grid As GridViewRow In GridView1.Rows
                            'lblAcademicYearAns.Text = ""
                            lblBatchAns.Text = ""
                            lblSemesterAns.Text = ""
                            lblClassTypeAns.Text = ""
                            lblSubjectAns.Text = ""
                            lblAssessmentTypeAns.Text = ""
                            'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                            lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                            lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                            lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                            lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                            lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                            pnllabel.Visible = True
                        Next
                    Else
                        lblerror.Text = ""
                        lblmsg.Text = ""
                        lblerror.Text = "No records to display."
                        pnllabel.Visible = False
                        GridView1.Visible = False
                    End If
                End If


            Catch ex As Exception
                lblerror.Text = ""
                lblmsg.Text = ""
                lblerror.Text = "Enter marks for all Students."
            End Try
        Else
            lblerror.Text = "You do not belong to this branch, Cannot update data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub clear()
        txtmax.Text = ""
        txtMin.Text = ""
        txtPassword.Text = ""
    End Sub
    Protected Sub btnlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                'If ddlA_Year.SelectedValue = 0 Or ddlbatch.SelectedValue = 0 Or ddlsemester.SelectedValue = 0 Or ddlsubject.SelectedValue = 0 Or ddlassesment.SelectedValue = 0 Or ddlclass.SelectedValue = 0 Then
                '    lblerror.Text = "Subject, Assesment and Class Type Fields are Mandatory."
                'Else
                el.A_Year = 0
                el.Batch = ddlbatch.SelectedValue
                el.Semester = ddlsemester.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                el.Assesment = ddlassesment.SelectedValue
                el.ClassType = ddlclass.SelectedValue
                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                lblerror.Text = ""
                lblmsg.Text = ""
                dt = b.ViewStdMarks(el)
                If dt.Rows(0).Item("Del_Flag") = "G" Then
                    lblerror.Text = "Update Marks before you Lock."
                    lblmsg.Text = ""
                    Exit Sub
                End If
                GridView1.DataSource = dt
                GridView1.DataBind()
                If dt.Rows.Count > 0 Then
                    lblerror.Text = ""
                    lblmsg.Text = ""
                    ControlsPanel.Visible = False
                    PasswordPanel.Visible = True
                    txtPassword.Focus()
                    lblpassError.Text = ""
                    Image1.Visible = False
                    Image2.Visible = False
                    For Each grid As GridViewRow In GridView1.Rows
                        'lblAcademicYearAns.Text = ""
                        lblBatchAns.Text = ""
                        lblSemesterAns.Text = ""
                        lblClassTypeAns.Text = ""
                        lblSubjectAns.Text = ""
                        lblAssessmentTypeAns.Text = ""
                        'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                        lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                        lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                        lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                        lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                        lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                        pnllabel.Visible = True
                    Next
                Else
                    clear()
                    lblerror.Text = ""
                    lblmsg.Text = ""
                    lblerror.Text = "No Records to Lock/Unlock."
                    pnllabel.Visible = False
                    Image1.Visible = True
                    Image2.Visible = True
                End If
                'End If
            Catch ex As Exception
                clear()
                lblerror.Text = ""
                lblmsg.Text = ""
                lblerror.Text = "Enter all mandatory fields."
                GridView1.Visible = False
                'ddlA_Year.Focus()
                Image1.Visible = True
                Image2.Visible = True
            End Try
        Else
            lblerror.Text = "You do not belong to this branch, Cannot lock/unlock data."
            lblmsg.Text = ""
        End If
    End Sub

    'Protected Sub ddlA_Year_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlA_Year.SelectedIndexChanged
    '    ddlbatch.Items.Clear()
    '    ddlbatch.DataSourceID = "ObjBatch"
    'End Sub

    Protected Sub ddlbatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.SelectedIndexChanged
        ddlsubject.Items.Clear()
        ddlsubject.DataSourceID = "ObjSubject"
    End Sub

    Protected Sub btnclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclear.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'If ddlA_Year.SelectedValue = 0 Or ddlbatch.SelectedValue = 0 Or ddlsemester.SelectedValue = 0 Or ddlsubject.SelectedValue = 0 Or ddlassesment.SelectedValue = 0 Or ddlclass.SelectedValue = 0 Then
            '    lblerror.Text = "Subject, Assesment and Class Type Fields are Mandatory."
            'Else
            Try
                el.A_Year = 0
                el.Batch = ddlbatch.SelectedValue
                el.Semester = ddlsemester.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                el.Assesment = ddlassesment.SelectedValue
                el.ClassType = ddlclass.SelectedValue
                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                lblerror.Text = ""
                lblmsg.Text = ""
                'el.Max = txtmax.Text
                'el.Min = txtMin.Text
                If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                    lblerror.Text = ""
                    lblmsg.Text = ""
                    lblerror.Text = "Records are locked, cannot be cleared."
                Else
                    Dim clearcount As Integer = b.ClearMarks(el)
                    If clearcount > 0 Then
                        dt = b.ViewStdMarks(el)
                        If dt.Rows.Count > 0 Then
                            GridView1.DataSource = dt
                            GridView1.DataBind()
                            GridView1.Visible = True
                            For Each grid As GridViewRow In GridView1.Rows
                                'lblAcademicYearAns.Text = ""
                                lblBatchAns.Text = ""
                                lblSemesterAns.Text = ""
                                lblClassTypeAns.Text = ""
                                lblSubjectAns.Text = ""
                                lblAssessmentTypeAns.Text = ""
                                'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                                lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                                lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                                lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                                lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                                pnllabel.Visible = True
                            Next
                        Else
                            lblerror.Text = ""
                            lblmsg.Text = ""
                            lblerror.Text = "No records to display."
                            pnllabel.Visible = False
                            GridView1.Visible = False
                        End If
                        lblerror.Text = ""
                        lblmsg.Text = ""
                        lblmsg.Text = clearcount.ToString + " records cleared."
                    End If
                End If
            Catch ex As Exception
                clear()
                lblerror.Text = "Enter all mandatory fields."
                GridView1.Visible = False
            End Try
            'End If
        Else
            lblerror.Text = "You do not belong to this branch, Cannot clear data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim check As String
            If txtPassword.Text = Session("Password") Then
                'If ddlA_Year.SelectedValue = 0 Or ddlbatch.SelectedValue = 0 Or ddlsemester.SelectedValue = 0 Or ddlsubject.SelectedValue = 0 Or ddlassesment.SelectedValue = 0 Or ddlclass.SelectedValue = 0 Then
                '    lblerror.Text = "Subject, Assesment and Class Type Fields are Mandatory."
                'Else
                el.A_Year = 0
                el.Batch = ddlbatch.SelectedValue
                el.Semester = ddlsemester.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                el.Assesment = ddlassesment.SelectedValue
                el.ClassType = ddlclass.SelectedValue
                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                lblerror.Text = ""
                lblmsg.Text = ""
                'el.Max = txtmax.Text
                'el.Min = txtMin.Text
                If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "N" Then
                    Dim roweffected As Integer = b.LockStdMarks(el)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        lblerror.Text = ""
                        lblmsg.Text = ""
                        lblmsg.Text = roweffected.ToString + " records Locked."
                        GridView1.Enabled = False
                        Image1.Visible = True
                        Image2.Visible = True
                    End If
                Else
                    Dim role As String
                    role = Session("UserRole")
                    'Dim checkUnlock As String
                    ' dt1 = DLNew_StudentMarks.CheckUnlockStatus(role)

                    If Session("SecurityCheck") = "Security Check" Then

                        dt = DLNew_StudentMarks.PostCheck(role)
                        If dt.Rows.Count < 1 Then
                            lblerror.Text = "You don't have Unlock Permission."
                            lblmsg.Text = ""
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            GridView1.Enabled = False
                            Image1.Visible = True
                            Image2.Visible = True
                        Else
                            check = dt.Rows(0)("Result").ToString.Trim

                            'check = dt.Rows(0)("Result").ToString.Trim
                            If check = "" Then
                                lblerror.Text = "You don't have Unlock Permission."
                                lblmsg.Text = ""
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                GridView1.Enabled = False
                                Image1.Visible = True
                                Image2.Visible = True
                            Else
                                Dim roweffected As Integer = b.UNLockStdMarks(el)
                                If roweffected > 0 Then
                                    ControlsPanel.Visible = True
                                    PasswordPanel.Visible = False
                                    lblerror.Text = ""
                                    lblmsg.Text = ""
                                    lblmsg.Text = roweffected.ToString + " records Unlocked."
                                    GridView1.Enabled = True
                                    Image1.Visible = True
                                    Image2.Visible = True
                                End If
                            End If
                        End If
                    Else
                        Dim roweffected As Integer = b.UNLockStdMarks(el)
                        If roweffected > 0 Then
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            lblerror.Text = ""
                            lblmsg.Text = ""
                            lblmsg.Text = roweffected.ToString + " records Unlocked."
                            GridView1.Enabled = True
                            Image1.Visible = True
                            Image2.Visible = True
                        End If
                    End If

                    'If dt.Rows.Count > 0 Then

                    'Else
                    '    ControlsPanel.Visible = True
                    '    PasswordPanel.Visible = False
                    '    lblerror.Text = "Not Authorized to Unlock."
                    '    Image1.Visible = True
                    '    Image2.Visible = True
                    '    lblmsg.Text = ""


                    'End If
                End If
                ''End If

            ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                lblerror.Text = "Password Incorrect."
                Image1.Visible = True
                Image2.Visible = True
                lblmsg.Text = ""
            End If

        Else
            lblerror.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
        btnlock.Focus()
    End Sub
    Sub DisplayGrid()
        el.A_Year = 0
        el.Batch = ddlbatch.SelectedValue
        el.Semester = ddlsemester.SelectedValue
        el.Subject = ddlsubject.SelectedValue
        el.Assesment = ddlassesment.SelectedValue
        el.ClassType = ddlclass.SelectedValue
        el.SubGrp = ddlSubjectSubGrp.SelectedValue
        lblerror.Text = ""
        lblmsg.Text = ""
        'el.Max = txtmax.Text
        'el.Min = txtMin.Text
        dt = b.ViewStdMarks(el)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            For Each grid As GridViewRow In GridView1.Rows
                'lblAcademicYearAns.Text = ""
                lblBatchAns.Text = ""
                lblSemesterAns.Text = ""
                lblClassTypeAns.Text = ""
                lblSubjectAns.Text = ""
                lblAssessmentTypeAns.Text = ""
                'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                pnllabel.Visible = True
            Next
            LinkButton.Focus()
            If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                GridView1.Enabled = False
            Else
                GridView1.Enabled = True
            End If
        Else
            lblerror.Text = ""
            lblmsg.Text = ""
            lblerror.Text = "No records to display."
            pnllabel.Visible = False
            GridView1.Visible = False
        End If
    End Sub
    Protected Sub Grdfeehead_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        DisplayGrid()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'ddlA_Year.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading

    End Sub

    'Protected Sub ddlA_Year_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlA_Year.TextChanged
    '    ddlA_Year.Focus()
    '    pnllabel.Visible = False
    '    GridView1.Visible = False
    '    lblmsg.Text = ""
    '    lblerror.Text = ""
    'End Sub

    Protected Sub ddlassesment_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassesment.TextChanged
        ddlassesment.Focus()

    End Sub

    Protected Sub ddlbatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.TextChanged
        ddlbatch.Focus()
        pnllabel.Visible = False
        GridView1.Visible = False
        lblmsg.Text = ""
        lblerror.Text = ""
    End Sub

    Protected Sub ddlclass_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlclass.TextChanged
        ddlclass.Focus()
    End Sub

    Protected Sub ddlsemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsemester.SelectedIndexChanged
        Try
            el.A_Year = 0
            el.Batch = ddlbatch.SelectedValue
            el.Semester = ddlsemester.SelectedValue
            If ddlsemester.SelectedValue <> 0 Then
                dt = b.GetSubjectComboBatchPlanner(el.Batch, el.Semester)
                If dt.Rows.Count <= 1 Then
                    lblmsg.Text = ""
                    lblerror.Text = "You have not been assigned any subject for this Batch/Semester.<br />Kindly check the data in Batch Planner form."
                Else
                    lblmsg.Text = ""
                    lblerror.Text = ""
                End If
            Else
                lblmsg.Text = ""
                lblerror.Text = ""
            End If
        Catch ex As Exception
            lblmsg.Text = ""
            lblerror.Text = "Enter correct data."
        End Try
    End Sub

    Protected Sub ddlsemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsemester.TextChanged
        ddlsemester.Focus()
    End Sub

    Protected Sub ddlsubject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsubject.TextChanged
        ddlsubject.Focus()
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
        el.A_Year = 0
        el.Batch = ddlbatch.SelectedValue
        el.Semester = ddlsemester.SelectedValue
        el.Subject = ddlsubject.SelectedValue
        el.Assesment = ddlassesment.SelectedValue
        el.ClassType = ddlclass.SelectedValue
        el.SubGrp = ddlSubjectSubGrp.SelectedValue
        dt = b.ViewStdMarks(el)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        For Each grid As GridViewRow In GridView1.Rows
            'lblAcademicYearAns.Text = ""
            lblBatchAns.Text = ""
            lblSemesterAns.Text = ""
            lblClassTypeAns.Text = ""
            lblSubjectAns.Text = ""
            lblAssessmentTypeAns.Text = ""
            'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
            lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
            lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
            lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
            lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
            lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
            pnllabel.Visible = True
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
            ViewState("dirState") = Value
        End Set
    End Property
    Protected Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        Dim sw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()

        Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
        Page.Response.AddHeader("content-disposition", "attachment;filename=StudentMarks.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        Controls.Add(frm)
        frm.Controls.Add(GridView1)
        frm.RenderControl(hw)
        Response.Write(style)
        'Response.Write(sw.ToString())
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnUpload_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Dim path1 As String = "~/Files/" & path1
        If FileUpload1.HasFile Then
            Dim FileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            Dim Extension As String = Path.GetExtension(FileUpload1.PostedFile.FileName)
            Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")

            Dim FilePath As String = Server.MapPath(FolderPath + FileName)
            FileUpload1.SaveAs(FilePath)
            Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)
        End If
    End Sub
    Private Sub Import_To_Grid(ByVal FilePath As String, ByVal Extension As String, ByVal isHDR As String)
        Dim conStr As String = ""
        Dim count As Integer, count1 As Integer
        Select Case Extension
            Case ".xls"
                'Excel 97-03
                conStr = ConfigurationManager.ConnectionStrings("Excel03ConString") _
                           .ConnectionString
                Exit Select
            Case ".xlsx"
                'Excel 07
                conStr = ConfigurationManager.ConnectionStrings("Excel07ConString") _
                          .ConnectionString
                Exit Select
        End Select
        conStr = String.Format(conStr, FilePath, isHDR)

        Dim connExcel As New OleDbConnection(conStr)
        Dim cmdExcel As New OleDbCommand()
        Dim oda As New OleDbDataAdapter()
        Dim dt As New DataTable()

        cmdExcel.Connection = connExcel

        'Get the name of First Sheet
        connExcel.Open()
        Dim dtExcelSchema As DataTable
        dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
        Dim SheetName As String = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
        connExcel.Close()

        'Read Data from First Sheet
        connExcel.Open()
        cmdExcel.CommandText = "SELECT * From [" & SheetName & "]"
        oda.SelectCommand = cmdExcel
        oda.Fill(dt)
        connExcel.Close()

        Try
            'If ddlA_Year.SelectedValue = 0 Or ddlbatch.SelectedValue = 0 Or ddlsemester.SelectedValue = 0 Or ddlsubject.SelectedValue = 0 Or ddlassesment.SelectedValue = 0 Or ddlclass.SelectedValue = 0 Then
            '    lblerror.Text = "Subject, Assesment and Class Type Fields are Mandatory."
            'Else
            el.A_Year = ddlA_Year.SelectedValue
            el.Batch = ddlbatch.SelectedValue
            el.Semester = ddlsemester.SelectedValue
            el.Subject = ddlsubject.SelectedValue
            el.Assesment = ddlassesment.SelectedValue
            el.ClassType = ddlclass.SelectedValue
            el.SubGrp = ddlSubjectSubGrp.SelectedValue
            lblerror.Text = ""
            lblmsg.Text = ""
            'el.Max = txtmax.Text
            'el.Min = txtMin.Text
            dt1 = b.ViewStdMarks(el)
            count = dt.Rows.Count
            count1 = dt1.Rows.Count
            Dim i As Integer = 0
            While count1 > 0
                ' dt1.Rows(count - 1).Item("StudentCode")
                count = dt.Rows.Count
                While count > 0
                    If dt.Rows(count - 1).Item("StudentCode") = dt1.Rows(count1 - 1).Item("StdCode") Then
                        dt1.Rows(count1 - 1).Item("ActualMarks") = dt.Rows(count - 1).Item("ActualMarks")
                        Exit While
                    Else
                        count = count - 1
                    End If

                End While

                count1 = count1 - 1
            End While
            FileUpload1.Dispose()
            If FileUpload1.HasFile Then
                FileUpload1.Dispose()
            End If
            If dt1.Rows.Count > 0 Then
                GridView1.DataSource = dt1
                GridView1.DataBind()
                GridView1.Visible = True
                For Each grid As GridViewRow In GridView1.Rows
                    'lblAcademicYearAns.Text = ""
                    lblBatchAns.Text = ""
                    lblSemesterAns.Text = ""
                    lblClassTypeAns.Text = ""
                    lblSubjectAns.Text = ""
                    lblAssessmentTypeAns.Text = ""
                    'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                    lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                    lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                    lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                    lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                    lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                    pnllabel.Visible = True
                Next

                If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                    GridView1.Enabled = False
                Else
                    GridView1.Enabled = True
                End If
            Else
                lblerror.Text = ""
                lblmsg.Text = ""
                lblerror.Text = "No records to display."
                pnllabel.Visible = False
                GridView1.Visible = False
            End If
            'End If
        Catch ex As Exception
            lblerror.Text = ""
            lblmsg.Text = ""
            lblerror.Text = "Enter all mandatory fields."
            GridView1.Visible = False
            ddlA_Year.Focus()
        End Try

        ''Bind Data to GridView
        'GridView1.Caption = Path.GetFileName(FilePath)
        'GridView1.DataSource = dt
        'GridView1.DataBind()
    End Sub
    Protected Sub PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        Dim FolderPath As String = ConfigurationManager.AppSettings("FolderPath")
        Dim FileName As String = GridView1.Caption
        Dim Extension As String = Path.GetExtension(FileName)
        Dim FilePath As String = Server.MapPath(FolderPath + FileName)

        Import_To_Grid(FilePath, Extension, rbHDR.SelectedItem.Text)
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub

    'Protected Sub BtnImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImport.Click
    '    Dim dt As New DataTable
    '    Dim store As String = Trim(TextBox1.Text)
    '    Dim row, col, count, count1 As Integer

    '    'Dim rowdata() As String = store.Split("\n")
    '    Dim rowdata As String() = store.Split(New Char() {vbCrLf})
    '    row = 0

    '    Dim dcID = New DataColumn("StudentCode", GetType(String))
    '    Dim dcName = New DataColumn("ActualMarks", GetType(String))
    '    dt.Columns.Add(dcID)
    '    dt.Columns.Add(dcName)
    '    'For i = 1 To 10
    '    '    dt.Rows.Add(i, "Row #" & i)
    '    'Next
    '    Dim name As String
    '    Dim name1 As String
    '    ' el.BatchId = rowdata(0).ToString
    '    While row <= rowdata.Count - 2
    '        Dim coldata As String = rowdata(row).ToString
    '        Dim coldata1 As String() = coldata.Split(New Char() {vbTab})
    '        col = 0
    '        'Dim count As Integer = coldata1.Count
    '        While col <= coldata1.Count - 1
    '            'Dim coldata As String = rowdata(row - 1).ToString
    '            'Dim coldata1 As String() = coldata.Split(New Char() {vbTab})
    '            name = coldata1(0)
    '            name1 = coldata1(1)

    '            col = col + 1
    '        End While
    '        dt.Rows.Add(name, name1)
    '        row = row + 1
    '    End While


    '    Try
    '        'If ddlA_Year.SelectedValue = 0 Or ddlbatch.SelectedValue = 0 Or ddlsemester.SelectedValue = 0 Or ddlsubject.SelectedValue = 0 Or ddlassesment.SelectedValue = 0 Or ddlclass.SelectedValue = 0 Then
    '        '    lblerror.Text = "Subject, Assesment and Class Type Fields are Mandatory."
    '        'Else
    '        el.A_Year = ddlA_Year.SelectedValue
    '        el.Batch = ddlbatch.SelectedValue
    '        el.Semester = ddlsemester.SelectedValue
    '        el.Subject = ddlsubject.SelectedValue
    '        el.Assesment = ddlassesment.SelectedValue
    '        el.ClassType = ddlclass.SelectedValue
    '        el.SubGrp = ddlSubjectSubGrp.SelectedValue
    '        lblerror.Text = ""
    '        lblmsg.Text = ""
    '        'el.Max = txtmax.Text
    '        'el.Min = txtMin.Text
    '        dt1 = b.ViewStdMarks(el)
    '        count = dt.Rows.Count
    '        count1 = dt1.Rows.Count
    '        Dim i As Integer = 0
    '        While count1 > 0
    '            ' dt1.Rows(count - 1).Item("StudentCode")
    '            count = dt.Rows.Count
    '            While count > 0
    '                If dt.Rows(count - 1).Item("StudentCode") = dt1.Rows(count1 - 1).Item("StdCode") Then
    '                    dt1.Rows(count1 - 1).Item("ActualMarks") = dt.Rows(count - 1).Item("ActualMarks")
    '                    Exit While
    '                Else
    '                    count = count - 1
    '                End If

    '            End While

    '            count1 = count1 - 1
    '        End While

    '        If dt1.Rows.Count > 0 Then
    '            GridView1.DataSource = dt1
    '            GridView1.DataBind()
    '            GridView1.Visible = True
    '            For Each grid As GridViewRow In GridView1.Rows
    '                'lblAcademicYearAns.Text = ""
    '                lblBatchAns.Text = ""
    '                lblSemesterAns.Text = ""
    '                lblClassTypeAns.Text = ""
    '                lblSubjectAns.Text = ""
    '                lblAssessmentTypeAns.Text = ""
    '                'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
    '                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
    '                lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
    '                lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
    '                lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
    '                lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
    '                pnllabel.Visible = True
    '            Next

    '            If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
    '                GridView1.Enabled = False
    '            Else
    '                GridView1.Enabled = True
    '            End If
    '        Else
    '            lblerror.Text = ""
    '            lblmsg.Text = ""
    '            lblerror.Text = "No records to display."
    '            pnllabel.Visible = False
    '            GridView1.Visible = False
    '        End If
    '        'End If
    '    Catch ex As Exception
    '        lblerror.Text = ""
    '        lblmsg.Text = ""
    '        lblerror.Text = "Enter all mandatory fields."
    '        GridView1.Visible = False
    '        ddlA_Year.Focus()
    '    End Try

    'End Sub
    Protected Sub ReloadCtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReloadCtl.Click
        Dim dt As New DataTable
        Dim store As String = hiddencode.value
        Dim row, col, count, count1, recordupdate As Integer
        recordupdate = recordupdate + 1
        Try
            If GridView1.Rows.Count <> 0 Then
                'Dim rowdata() As String = store.Split("\n")
                Dim rowdata As String() = store.Split(New Char() {vbCrLf})
                row = 0

                Dim dcID = New DataColumn("StudentCode", GetType(String))
                Dim dcName = New DataColumn("ActualMarks", GetType(String))
                dt.Columns.Add(dcID)
                dt.Columns.Add(dcName)
                'For i = 1 To 10
                '    dt.Rows.Add(i, "Row #" & i)
                'Next
                Dim name As String
                Dim name1 As String
                ' el.BatchId = rowdata(0).ToString
                While row <= rowdata.Count - 2
                    Dim coldata As String = rowdata(row).ToString
                    Dim coldata1 As String() = coldata.Split(New Char() {vbTab})
                    col = 0
                    'Dim count As Integer = coldata1.Count
                    While col <= coldata1.Count - 1
                        'Dim coldata As String = rowdata(row - 1).ToString
                        'Dim coldata1 As String() = coldata.Split(New Char() {vbTab})
                        name = coldata1(0).Trim
                        name1 = coldata1(1).Trim

                        col = col + 1
                    End While
                    dt.Rows.Add(name, name1)
                    row = row + 1
                End While



                'If ddlA_Year.SelectedValue = 0 Or ddlbatch.SelectedValue = 0 Or ddlsemester.SelectedValue = 0 Or ddlsubject.SelectedValue = 0 Or ddlassesment.SelectedValue = 0 Or ddlclass.SelectedValue = 0 Then
                '    lblerror.Text = "Subject, Assesment and Class Type Fields are Mandatory."
                'Else
                el.A_Year = 0
                el.Batch = ddlbatch.SelectedValue
                el.Semester = ddlsemester.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                el.Assesment = ddlassesment.SelectedValue
                el.ClassType = ddlclass.SelectedValue
                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                lblerror.Text = ""
                lblmsg.Text = ""
                'el.Max = txtmax.Text
                'el.Min = txtMin.Text
                dt1 = b.ViewStdMarks(el)
                count = dt.Rows.Count
                count1 = dt1.Rows.Count
                Dim i As Integer = 0
                While count1 > 0
                    ' dt1.Rows(count - 1).Item("StudentCode")
                    count = dt.Rows.Count
                    While count > 0
                        If dt.Rows(count - 1).Item("StudentCode") = Trim(dt1.Rows(count1 - 1).Item("StdCode")) Then
                            dt1.Rows(count1 - 1).Item("ActualMarks") = dt.Rows(count - 1).Item("ActualMarks")
                            recordupdate = recordupdate + 1
                            Exit While
                        Else
                            count = count - 1
                        End If

                    End While

                    count1 = count1 - 1
                End While

                If dt1.Rows.Count > 0 Then
                    GridView1.DataSource = dt1
                    GridView1.DataBind()
                    GridView1.Visible = True
                    For Each grid As GridViewRow In GridView1.Rows
                        'lblAcademicYearAns.Text = ""
                        lblBatchAns.Text = ""
                        lblSemesterAns.Text = ""
                        lblClassTypeAns.Text = ""
                        lblSubjectAns.Text = ""
                        lblAssessmentTypeAns.Text = ""
                        'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                        lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                        lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                        lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                        lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                        lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                        pnllabel.Visible = True
                    Next

                    If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                        GridView1.Enabled = False
                    Else
                        GridView1.Enabled = True
                    End If
                    lblmsg.Text = "Records copied successfully."
                    lblerror.Text = ""
                Else
                    lblerror.Text = ""
                    lblmsg.Text = ""
                    lblerror.Text = "No records to display."
                    pnllabel.Visible = False
                    GridView1.Visible = False
                End If
                'End If
            Else
                lblmsg.Text = ""
                lblerror.Text = "Generate the Grid data, copy Excel data, and then press Import from excel."
            End If
        Catch ex As Exception
            lblerror.Text = ""
            lblmsg.Text = ""
            lblerror.Text = "Enter all mandatory fields."
            GridView1.Visible = False
            ddlA_Year.Focus()
        End Try
    End Sub

End Class
