Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Drawing

Partial Class frmStudentMarksEntrybySubject
    Inherits BasePage

    Dim el As New ELNewStdMarksBySub
    Dim b As New BLStdMarksElectiveBySub
    Dim d As New DLStdMarksElectiveBySub
    Dim dt, dt1, dt4, dt5 As New Data.DataTable
    Dim DLNew_StudentMarks As New DLNew_StudentMarks

    Protected Sub btngenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngenerate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'lblAcademicYearAns.Text = ""
            lblBatchAns.Text = ""
            lblSemesterAns.Text = ""

            lblSubjectAns.Text = ""
            lblAssessmentTypeAns.Text = ""
            Try
                If CInt(txtmax.Text) < CInt(txtMin.Text) Then
                    lblerror.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    lblerror.Text = ValidationMessage(1191)
                Else
                    'If ddlA_Year.SelectedValue = 0 Or ddlbatch.SelectedValue = 0 Or ddlsemester.SelectedValue = 0 Or ddlsubject.SelectedValue = 0 Or ddlassesment.SelectedValue = 0 Or ddlclass.SelectedValue = 0 Then
                    '    lblerror.Text = "Subject, Assesment and Class Type Fields are Mandatory"
                    'Else
                    'Dummy comment

                    el.A_Year = 0
                    'el.Batch = ddlbatch.SelectedValue
                    'el.Semester = ddlsemester.SelectedValue
                    'el.Subject = ddlsubject.SelectedValue
                    el.Subject = ddlsubject.SelectedValue
                    dt4 = b.BatchAccess(el)
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
                            el.Batch = str + "," + el.Batch
                            i = i + 1
                            j = j - 1
                        End While
                    Else
                        el.Batch = 0
                    End If

                    dt5 = b.SemAccess(el)
                    i1 = 0
                    j1 = dt5.Rows.Count
                    If j1 > 0 Then

                        While j1 > 0
                            str1 = dt5.Rows(i1).Item("SemesterID").ToString
                            el.Semester = str1 + "," + el.Semester
                            i1 = i1 + 1
                            j1 = j1 - 1
                        End While
                    Else
                        el.Semester = 0
                    End If
                    el.Assesment = ddlassesment.SelectedValue
                    el.AssesmentDate = TxtAssessmentDate.Text

                    el.StdId = ddlStudent.SelectedValue
                    el.Max = txtmax.Text
                    el.Min = txtMin.Text
                    el.SubGrp = ddlSubjectSubGrp.SelectedValue
                    'dt = DLNew_StudentMarks.GetBatchBySub(el)
                    'If dt.Rows(0).Item("Subgrp_Status") = "Y" Then
                    '    If ddlSubjectSubGrp.SelectedValue = 0 Then
                    '        lblerror.Text = ValidationMessage(1192)
                    '        lblmsg.Text = ValidationMessage(1014)
                    '        Exit Sub
                    '    End If
                    'End If
                    If b.InsertStdMarks(el) > 0 Then
                        dt = b.ViewStdMarks(el)
                        If dt.Rows.Count > 0 Then
                            GridView1.Visible = True
                            GridView1.DataSource = dt
                            GridView1.DataBind()
                        
                            For Each grid As GridViewRow In GridView1.Rows
                                'lblAcademicYearAns.Text = ""
                                lblBatchAns.Text = ""
                                lblSemesterAns.Text = ""
                                lblAssessmentDate.Text = ""
                                lblSubjectAns.Text = ""
                                lblAssessmentTypeAns.Text = ""
                                'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                                lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                                lblAssessmentDate.Text = CType(grid.FindControl("lblassessdate"), Label).Text
                                lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text().ToString)
                                lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                                pnllabel.Visible = True
                                CType(grid.FindControl("txtPassFail"), TextBox).Text = ""
                            Next
                            'If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                            '    GridView1.Enabled = False
                            'Else
                            '    GridView1.Enabled = True
                            'End If
                        Else
                            lblerror.Text = ValidationMessage(1014)
                            lblmsg.Text = ValidationMessage(1014)
                            lblerror.Text = ValidationMessage(1023)
                            pnllabel.Visible = False
                            GridView1.Visible = False
                        End If
                        lblerror.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        lblmsg.Text = dt.Rows.Count().ToString + ValidationMessage(1109)
                        GridView1.Enabled = True
                    Else
                        lblerror.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        lblerror.Text = ValidationMessage(1044)
                        pnllabel.Visible = False
                        GridView1.Visible = False
                    End If


                    clear()
                End If
            Catch ex As Exception
                lblerror.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                lblerror.Text = ValidationMessage(1117)
                GridView1.Visible = False
                'ddlA_Year.Focus()
                pnllabel.Visible = False
            End Try
        Else
            lblerror.Text = ValidationMessage(1045)
            lblmsg.Text = ValidationMessage(1014)
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
            'el.Batch = ddlbatch.SelectedValue
            'el.Semester = ddlsemester.SelectedValue
            'el.Subject = ddlsubject.SelectedValue
            el.Subject = ddlsubject.SelectedValue
            dt4 = b.BatchAccess(el)
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
                    el.Batch = str + "," + el.Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                el.Batch = 0
            End If
            dt5 = b.SemAccess(el)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    el.Semester = str1 + "," + el.Semester
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                el.Semester = 0
            End If
            el.Assesment = ddlassesment.SelectedValue
            el.AssesmentDate = TxtAssessmentDate.Text

            el.SubGrp = ddlSubjectSubGrp.SelectedValue
            el.StdId = ddlStudent.SelectedValue
            lblerror.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            'el.Max = txtmax.Text
            'el.Min = txtMin.Text
            dt = b.ViewStdMarks(el)
            If dt.Rows.Count > 0 Then
                GridView1.Visible = True
                GridView1.DataSource = dt
                GridView1.DataBind()
               
                For Each grid As GridViewRow In GridView1.Rows
                    CType(grid.FindControl("ddlExamAttend"), DropDownList).SelectedValue = CType(grid.FindControl("lblEamAttdId"), Label).Text
                    'lblAcademicYearAns.Text = ""
                    lblBatchAns.Text = ""
                    lblSemesterAns.Text = ""
                    lblAssessmentDate.Text = ""
                    lblSubjectAns.Text = ""
                    lblAssessmentTypeAns.Text = ""
                    'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                    lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                    lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                    lblAssessmentDate.Text = CType(grid.FindControl("lblassessdate"), Label).Text
                    lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text().ToString)
                    lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                    pnllabel.Visible = True

                Next


                If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                    GridView1.Enabled = False
                Else
                    GridView1.Enabled = True
                End If
            Else
                lblerror.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                lblerror.Text = ValidationMessage(1023)
                pnllabel.Visible = False
                GridView1.Visible = False
            End If
            'End If
        Catch ex As Exception
            lblerror.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            lblerror.Text = ValidationMessage(1117)
            pnllabel.Visible = False
            GridView1.Visible = False
            'ddlA_Year.Focus()
        End Try
    End Sub

    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                el.A_Year = 0
                'el.Batch = ddlbatch.SelectedValue
                'el.Semester = ddlsemester.SelectedValue
                'el.Subject = ddlsubject.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                dt4 = b.BatchAccess(el)
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
                        el.Batch = str + "," + el.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    el.Batch = 0
                End If
                dt5 = b.SemAccess(el)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        el.Semester = str1 + "," + el.Semester
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    el.Semester = 0
                End If
                el.Assesment = ddlassesment.SelectedValue
                el.AssesmentDate = TxtAssessmentDate.Text
                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                el.StdId = ddlStudent.SelectedValue
                dt = b.ViewStdMarks(el)
                If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                    GridView1.Enabled = False
                    lblerror.Text = ValidationMessage(1099)
                    lblmsg.Text = ValidationMessage(1014)
                    Exit Sub
                Else
                    GridView1.Enabled = True
                End If
                For Each grid As GridViewRow In GridView1.Rows
                    el.Min1 = CType(grid.FindControl("LabelMin"), Label).Text
                    el.Max1 = CType(grid.FindControl("LabelMax"), Label).Text
                Next
                If el.Min <> el.Min1 Or el.Max <> el.Max1 Then
                    'MsgBox("Max Marks or Min Marks has changed.Do you want to go ahead?")
                End If
                If ChkBoxGrade.Checked = True Then


                    If ChkBoxHeader.Checked = True Then
                        lblerror.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        For Each grid As GridViewRow In GridView1.Rows

                            'lblAcademicYearAns.Text = ""
                            lblBatchAns.Text = ""
                            lblSemesterAns.Text = ""

                            lblSubjectAns.Text = ""
                            lblAssessmentTypeAns.Text = ""
                            'If CType(grid.FindControl("txtactmarks"), TextBox).Text <> "" Then
                            el.id = CType(grid.FindControl("lblid"), Label).Text
                            el.A_Marks = IIf(CType(grid.FindControl("txtactmarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtactmarks"), TextBox).Text)
                            If txtmax.Text = "" Then
                                el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                            Else
                                el.Max = txtmax.Text
                            End If
                            If txtMin.Text = "" Then
                                el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                            Else
                                el.Min = txtMin.Text
                            End If

                            'el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                            'el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                            el.Grade = CType(grid.FindControl("txtgrade"), TextBox).Text
                            el.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                            el.Batch = CType(grid.FindControl("Lblbatch"), Label).Text
                            el.ExamAttendance = IIf(CType(grid.FindControl("ddlExamAttend"), DropDownList).Text = "", 0, CType(grid.FindControl("ddlExamAttend"), DropDownList).Text)
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
                        lblmsg.Text = ValidationMessage(1017)
                        el.A_Year = 0
                        'el.Batch = ddlbatch.SelectedValue
                        'el.Semester = ddlsemester.SelectedValue
                        'el.Subject = ddlsubject.SelectedValue
                        el.Subject = ddlsubject.SelectedValue
                        dt4 = b.BatchAccess(el)
                        '   Subject = dt.Rows(i).Item("Subject").ToString
                        i = 0
                        j = dt4.Rows.Count
                        If j > 0 Then
                            While j > 0
                                str = dt4.Rows(i).Item("BatchID").ToString
                                el.Batch = str + "," + el.Batch
                                i = i + 1
                                j = j - 1
                            End While
                        Else
                            el.Batch = 0
                        End If
                        dt5 = b.SemAccess(el)
                        i1 = 0
                        j1 = dt5.Rows.Count
                        If j1 > 0 Then
                            While j1 > 0
                                str1 = dt5.Rows(i1).Item("SemesterID").ToString
                                el.Semester = str1 + "," + el.Semester
                                i1 = i1 + 1
                                j1 = j1 - 1
                            End While
                        Else
                            el.Semester = 0
                        End If
                        el.Assesment = ddlassesment.SelectedValue
                        el.AssesmentDate = TxtAssessmentDate.Text

                        el.SubGrp = ddlSubjectSubGrp.SelectedValue
                        el.StdId = ddlStudent.SelectedValue
                        lblerror.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        'el.Max = txtmax.Text
                        'el.Min = txtMin.Text
                        dt = b.ViewStdMarks(el)
                        If dt.Rows.Count > 0 Then
                            GridView1.Visible = True
                            GridView1.DataSource = dt
                            GridView1.DataBind()
                            
                            lblmsg.Text = ValidationMessage(1017)
                            lblerror.Text = ValidationMessage(1014)
                            If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                                GridView1.Enabled = False
                                lblerror.Text = ValidationMessage(1099)
                                lblmsg.Text = ValidationMessage(1014)
                            Else
                                GridView1.Enabled = True
                            End If
                            For Each grid As GridViewRow In GridView1.Rows
                                CType(grid.FindControl("ddlExamAttend"), DropDownList).SelectedValue = CType(grid.FindControl("lblEamAttdId"), Label).Text
                                'lblAcademicYearAns.Text = ""
                                lblBatchAns.Text = ""
                                lblSemesterAns.Text = ""
                                lblAssessmentDate.Text = ""
                                lblSubjectAns.Text = ""
                                lblAssessmentTypeAns.Text = ""
                                'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                                lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                                lblAssessmentDate.Text = CType(grid.FindControl("lblassessdate"), Label).Text
                                lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text().ToString)
                                lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                                pnllabel.Visible = True
                            Next
                        Else
                            lblerror.Text = ValidationMessage(1014)
                            lblmsg.Text = ValidationMessage(1014)
                            lblerror.Text = ValidationMessage(1023)
                            pnllabel.Visible = False
                            GridView1.Visible = False
                        End If
                    Else
                        lblerror.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        For Each grid As GridViewRow In GridView1.Rows
                            'lblAcademicYearAns.Text = ""
                            lblBatchAns.Text = ""
                            lblSemesterAns.Text = ""

                            lblSubjectAns.Text = ""
                            lblAssessmentTypeAns.Text = ""
                            'If CType(grid.FindControl("txtactmarks"), TextBox).Text <> "" Then
                            el.id = CType(grid.FindControl("lblid"), Label).Text
                            el.A_Marks = IIf(CType(grid.FindControl("txtactmarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtactmarks"), TextBox).Text)
                            If txtmax.Text = "" Then
                                el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                            Else
                                el.Max = txtmax.Text
                            End If
                            If txtMin.Text = "" Then
                                el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                            Else
                                el.Min = txtMin.Text
                            End If
                            'el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                            'el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                            el.Grade = CType(grid.FindControl("txtgrade"), TextBox).Text
                            el.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                            el.Batch = CType(grid.FindControl("Lblbatch"), Label).Text
                            el.Percent = (el.A_Marks / el.Max) * 100
                            el.ExamAttendance = IIf(CType(grid.FindControl("ddlExamAttend"), DropDownList).Text = "", 0, CType(grid.FindControl("ddlExamAttend"), DropDownList).Text)
                            CType(grid.FindControl("txtpassFail"), TextBox).Text = ""
                            b.UpdateMarksFromGrade(el)
                            'End If
                        Next
                        lblmsg.Text = ValidationMessage(1017)
                        el.A_Year = 0
                        'el.Batch = ddlbatch.SelectedValue
                        'el.Semester = ddlsemester.SelectedValue
                        'el.Subject = ddlsubject.SelectedValue
                        el.Subject = ddlsubject.SelectedValue
                        dt4 = b.BatchAccess(el)
                        '   Subject = dt.Rows(i).Item("Subject").ToString

                        i = 0
                        j = dt4.Rows.Count
                        If j > 0 Then
                            While j > 0
                                str = dt4.Rows(i).Item("BatchID").ToString
                                el.Batch = str + "," + el.Batch
                                i = i + 1
                                j = j - 1
                            End While
                        Else
                            el.Batch = 0
                        End If
                        dt5 = b.SemAccess(el)
                        i1 = 0
                        j1 = dt5.Rows.Count
                        If j1 > 0 Then
                            While j1 > 0
                                str1 = dt5.Rows(i1).Item("SemesterID").ToString
                                el.Semester = str1 + "," + el.Semester
                                i1 = i1 + 1
                                j1 = j1 - 1
                            End While
                        Else
                            el.Semester = 0
                        End If
                        el.Assesment = ddlassesment.SelectedValue
                        el.AssesmentDate = TxtAssessmentDate.Text

                        el.SubGrp = ddlSubjectSubGrp.SelectedValue
                        el.StdId = ddlStudent.SelectedValue
                        lblerror.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        'el.Max = txtmax.Text
                        'el.Min = txtMin.Text
                        dt = b.ViewStdMarks(el)
                        If dt.Rows.Count > 0 Then
                            GridView1.Visible = True
                            GridView1.DataSource = dt
                            GridView1.DataBind()
                          
                            lblmsg.Text = ValidationMessage(1017)
                            lblerror.Text = ValidationMessage(1014)
                            If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                                GridView1.Enabled = False
                                lblerror.Text = ValidationMessage(1099)
                                lblmsg.Text = ValidationMessage(1014)
                            Else
                                GridView1.Enabled = True
                            End If
                            For Each grid As GridViewRow In GridView1.Rows
                                CType(grid.FindControl("ddlExamAttend"), DropDownList).SelectedValue = CType(grid.FindControl("lblEamAttdId"), Label).Text
                                'lblAcademicYearAns.Text = ""
                                lblBatchAns.Text = ""
                                lblSemesterAns.Text = ""
                                lblAssessmentDate.Text = ""
                                lblSubjectAns.Text = ""
                                lblAssessmentTypeAns.Text = ""
                                'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                                lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                                lblAssessmentDate.Text = CType(grid.FindControl("lblassessdate"), Label).Text
                                lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text().ToString)
                                lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                                pnllabel.Visible = True
                            Next
                        Else
                            lblerror.Text = ValidationMessage(1014)
                            lblmsg.Text = ValidationMessage(1014)
                            lblerror.Text = ValidationMessage(1023)
                            pnllabel.Visible = False
                            GridView1.Visible = False
                        End If
                    End If
                ElseIf ChkBoxHeader.Checked = True Then
                    lblerror.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)

                    For Each grid As GridViewRow In GridView1.Rows
                        'lblAcademicYearAns.Text = ""
                        lblBatchAns.Text = ""
                        lblSemesterAns.Text = ""
                        lblSubjectAns.Text = ""
                        lblAssessmentTypeAns.Text = ""
                        'If CType(grid.FindControl("txtactmarks"), TextBox).Text <> "" Then
                        el.id = CType(grid.FindControl("lblid"), Label).Text
                        el.A_Marks = IIf(CType(grid.FindControl("txtactmarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtactmarks"), TextBox).Text)
                        If txtmax.Text = "" Then
                            el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                        Else
                            el.Max = txtmax.Text
                        End If
                        If txtMin.Text = "" Then
                            el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                        Else
                            el.Min = txtMin.Text
                        End If
                        'el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                        'el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                        el.Grade = CType(grid.FindControl("txtgrade"), TextBox).Text
                        el.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                        el.Batch = CType(grid.FindControl("Lblbatch"), Label).Text
                        el.Percent = (el.A_Marks / el.Max) * 100
                        el.ExamAttendance = IIf(CType(grid.FindControl("ddlExamAttend"), DropDownList).Text = "", 0, CType(grid.FindControl("ddlExamAttend"), DropDownList).Text)
                        'el.Percent = CType(grid.FindControl("Labelmarks"), Label).Text
                        If el.A_Marks < el.Min Then
                            el.Pass_Fail = "Fail"
                        Else
                            el.Pass_Fail = "Pass"

                        End If

                        b.UpdateMarks(el)
                        'End If
                    Next
                    lblmsg.Text = ValidationMessage(1017)
                    el.A_Year = 0
                    'el.Batch = ddlbatch.SelectedValue
                    'el.Semester = ddlsemester.SelectedValue
                    'el.Subject = ddlsubject.SelectedValue
                    el.Subject = ddlsubject.SelectedValue
                    dt4 = b.BatchAccess(el)
                    '   Subject = dt.Rows(i).Item("Subject").ToString

                    i = 0
                    j = dt4.Rows.Count
                    If j > 0 Then
                        While j > 0
                            str = dt4.Rows(i).Item("BatchID").ToString
                            el.Batch = str + "," + el.Batch
                            i = i + 1
                            j = j - 1
                        End While
                    Else
                        el.Batch = 0
                    End If
                    dt5 = b.SemAccess(el)
                    i1 = 0
                    j1 = dt5.Rows.Count
                    If j1 > 0 Then
                        While j1 > 0
                            str1 = dt5.Rows(i1).Item("SemesterID").ToString
                            el.Semester = str1 + "," + el.Semester
                            i1 = i1 + 1
                            j1 = j1 - 1
                        End While
                    Else
                        el.Semester = 0
                    End If
                    el.Assesment = ddlassesment.SelectedValue
                    el.AssesmentDate = TxtAssessmentDate.Text

                    el.SubGrp = ddlSubjectSubGrp.SelectedValue
                    el.StdId = ddlStudent.SelectedValue
                    lblerror.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    'el.Max = txtmax.Text
                    'el.Min = txtMin.Text
                    dt = b.ViewStdMarks(el)
                    If dt.Rows.Count > 0 Then
                        GridView1.Visible = True
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                      

                        lblmsg.Text = ValidationMessage(1017)
                        lblerror.Text = ValidationMessage(1014)
                        If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                            GridView1.Enabled = False
                            lblerror.Text = ValidationMessage(1099)
                            lblmsg.Text = ValidationMessage(1014)
                        Else
                            GridView1.Enabled = True
                        End If
                        For Each grid As GridViewRow In GridView1.Rows
                            CType(grid.FindControl("ddlExamAttend"), DropDownList).SelectedValue = CType(grid.FindControl("lblEamAttdId"), Label).Text
                            'lblAcademicYearAns.Text = ""
                            lblBatchAns.Text = ""
                            lblSemesterAns.Text = ""
                            lblAssessmentDate.Text = ""
                            lblSubjectAns.Text = ""
                            lblAssessmentTypeAns.Text = ""
                            'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                            lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                            lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                            lblAssessmentDate.Text = CType(grid.FindControl("lblassessdate"), Label).Text
                            lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text().ToString)
                            lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                            pnllabel.Visible = True
                        Next
                    Else
                        lblerror.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        lblerror.Text = ValidationMessage(1023)
                        pnllabel.Visible = False
                        GridView1.Visible = False
                    End If

                Else
                lblerror.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                For Each grid As GridViewRow In GridView1.Rows
                    'lblAcademicYearAns.Text = ""
                    lblBatchAns.Text = ""
                    lblSemesterAns.Text = ""

                    lblSubjectAns.Text = ""
                    lblAssessmentTypeAns.Text = ""
                    'If CType(grid.FindControl("txtactmarks"), TextBox).Text <> "" Then
                    el.id = CType(grid.FindControl("lblid"), Label).Text
                    el.A_Marks = IIf(CType(grid.FindControl("txtactmarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtactmarks"), TextBox).Text)
                    If txtmax.Text = "" Then
                        el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                    Else
                        el.Max = txtmax.Text
                    End If
                    If txtMin.Text = "" Then
                        el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                    Else
                        el.Min = txtMin.Text
                    End If
                    'el.Max = IIf(CType(grid.FindControl("LabelMax"), Label).Text = "", 0, CType(grid.FindControl("LabelMax"), Label).Text)
                    'el.Min = CType(grid.FindControl("LabelMin"), Label).Text
                    el.Grade = CType(grid.FindControl("txtgrade"), TextBox).Text
                    el.Remarks = CType(grid.FindControl("txtRemarks"), TextBox).Text
                    el.Batch = CType(grid.FindControl("Lblbatch"), Label).Text
                    el.Percent = (el.A_Marks / el.Max) * 100
                    el.ExamAttendance = IIf(CType(grid.FindControl("ddlExamAttend"), DropDownList).Text = "", 0, CType(grid.FindControl("ddlExamAttend"), DropDownList).Text)
                    CType(grid.FindControl("txtpassFail"), TextBox).Text = ""
                    b.UpdateMarks(el)
                    'End If
                Next
                lblmsg.Text = ValidationMessage(1017)
                el.A_Year = 0
                'el.Batch = ddlbatch.SelectedValue
                'el.Semester = ddlsemester.SelectedValue
                'el.Subject = ddlsubject.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                dt4 = b.BatchAccess(el)
                '   Subject = dt.Rows(i).Item("Subject").ToString

                i = 0
                j = dt4.Rows.Count
                    If j > 0 Then
                        While j > 0
                            str = dt4.Rows(i).Item("BatchID").ToString
                            el.Batch = str + "," + el.Batch
                            i = i + 1
                            j = j - 1
                        End While
                    Else
                        el.Batch = 0
                    End If
                dt5 = b.SemAccess(el)
                i1 = 0
                    j1 = dt5.Rows.Count
                    If j1 > 0 Then
                        While j1 > 0
                            str1 = dt5.Rows(i1).Item("SemesterID").ToString
                            el.Semester = str1 + "," + el.Semester
                            i1 = i1 + 1
                            j1 = j1 - 1
                        End While
                    Else
                        el.Semester = 0
                    End If
                    el.Assesment = ddlassesment.SelectedValue
                    el.AssesmentDate = TxtAssessmentDate.Text

                    el.SubGrp = ddlSubjectSubGrp.SelectedValue
                    el.StdId = ddlStudent.SelectedValue
                    lblerror.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    'el.Max = txtmax.Text
                    'el.Min = txtMin.Text
                    dt = b.ViewStdMarks(el)
                    If dt.Rows.Count > 0 Then
                        GridView1.Visible = True
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                     
                        lblmsg.Text = ValidationMessage(1017)
                        lblerror.Text = ValidationMessage(1014)
                        If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                            GridView1.Enabled = False
                            lblerror.Text = ValidationMessage(1099)
                            lblmsg.Text = ValidationMessage(1014)
                        Else
                            GridView1.Enabled = True
                        End If
                        For Each grid As GridViewRow In GridView1.Rows
                            CType(grid.FindControl("ddlExamAttend"), DropDownList).SelectedValue = CType(grid.FindControl("lblEamAttdId"), Label).Text
                            'lblAcademicYearAns.Text = ""
                            lblBatchAns.Text = ""
                            lblSemesterAns.Text = ""
                            lblAssessmentDate.Text = ""
                            lblSubjectAns.Text = ""
                            lblAssessmentTypeAns.Text = ""
                            'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                            lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                            lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                            lblAssessmentDate.Text = CType(grid.FindControl("lblassessdate"), Label).Text
                            lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text().ToString)
                            lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                            pnllabel.Visible = True
                        Next
                    Else
                        lblerror.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        lblerror.Text = ValidationMessage(1023)
                        pnllabel.Visible = False
                        GridView1.Visible = False
                    End If
                End If
                txtmax.Text = ""
                txtMin.Text = ""

            Catch ex As Exception
                lblerror.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                lblerror.Text = ValidationMessage(1193)
            End Try
        Else
        lblerror.Text = ValidationMessage(1194)
        lblmsg.Text = ValidationMessage(1014)
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
                'el.Batch = ddlbatch.SelectedValue
                'el.Semester = ddlsemester.SelectedValue
                'el.Subject = ddlsubject.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                dt4 = b.BatchAccess(el)
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
                        el.Batch = str + "," + el.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    el.Batch = 0
                End If
                dt5 = b.SemAccess(el)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        el.Semester = str1 + "," + el.Semester
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    el.Semester = 0
                End If
                el.Assesment = ddlassesment.SelectedValue
                el.AssesmentDate = TxtAssessmentDate.Text

                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                el.StdId = ddlStudent.SelectedValue
                lblerror.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                dt = b.ViewStdMarks(el)
                If dt.Rows(0).Item("Del_Flag") = "G" Then
                    lblerror.Text = ValidationMessage(1195)
                    lblmsg.Text = ValidationMessage(1014)
                    Exit Sub
                End If
                GridView1.DataSource = dt
                GridView1.DataBind()
               
                If dt.Rows.Count > 0 Then
                    lblerror.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    ControlsPanel.Visible = False
                    PasswordPanel.Visible = True
                    txtPassword.Focus()
                    lblpassError.Text = ValidationMessage(1014)
                    Image1.Visible = False
                    Image2.Visible = False
                    For Each grid As GridViewRow In GridView1.Rows
                        CType(grid.FindControl("ddlExamAttend"), DropDownList).SelectedValue = CType(grid.FindControl("lblEamAttdId"), Label).Text
                        'lblAcademicYearAns.Text = ""
                        lblBatchAns.Text = ""
                        lblSemesterAns.Text = ""
                        lblAssessmentDate.Text = ""
                        lblSubjectAns.Text = ""
                        lblAssessmentTypeAns.Text = ""
                        'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                        lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                        lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                        lblAssessmentDate.Text = CType(grid.FindControl("lblassessdate"), Label).Text
                        lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text())
                        lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                        pnllabel.Visible = True
                    Next
                Else
                    clear()
                    lblerror.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    lblerror.Text = ValidationMessage(1105)
                    pnllabel.Visible = False
                    Image1.Visible = True
                    Image2.Visible = True
                End If
                'End If
            Catch ex As Exception
                clear()
                lblerror.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                lblerror.Text = ValidationMessage(1117)
                GridView1.Visible = False
                'ddlA_Year.Focus()
                Image1.Visible = True
                Image2.Visible = True
            End Try
        Else
            lblerror.Text = ValidationMessage(1101)
            lblmsg.Text = ValidationMessage(1014)
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
                'el.Batch = ddlbatch.SelectedValue
                'el.Semester = ddlsemester.SelectedValue
                'el.Subject = ddlsubject.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                dt4 = b.BatchAccess(el)
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
                        el.Batch = str + "," + el.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    el.Batch = 0
                End If
                dt5 = b.SemAccess(el)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        el.Semester = str1 + "," + el.Semester
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    el.Semester = 0
                End If
                el.Assesment = ddlassesment.SelectedValue
                el.AssesmentDate = TxtAssessmentDate.Text

                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                el.StdId = ddlStudent.SelectedValue
                lblerror.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                'el.Max = txtmax.Text
                'el.Min = txtMin.Text
                If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                    lblerror.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    lblerror.Text = ValidationMessage(1098)
                Else
                    Dim clearcount As Integer = b.ClearMarks(el)
                    If clearcount > 0 Then
                        dt = b.ViewStdMarks(el)
                        If dt.Rows.Count > 0 Then
                            GridView1.Visible = True
                            GridView1.DataSource = dt
                            GridView1.DataBind()
                            For Each grid As GridViewRow In GridView1.Rows
                                CType(grid.FindControl("ddlExamAttend"), DropDownList).SelectedValue = CType(grid.FindControl("lblEamAttdId"), Label).Text
                                'lblAcademicYearAns.Text = ""
                                lblBatchAns.Text = ""
                                lblSemesterAns.Text = ""
                                lblAssessmentDate.Text = ""
                                lblSubjectAns.Text = ""
                                lblAssessmentTypeAns.Text = ""
                                'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                                lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                                lblAssessmentDate.Text = CType(grid.FindControl("lblassessdate"), Label).Text
                                lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text().ToString)
                                lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                                pnllabel.Visible = True
                            Next
                        Else
                            lblerror.Text = ValidationMessage(1014)
                            lblmsg.Text = ValidationMessage(1014)
                            lblerror.Text = ValidationMessage(1023)
                            pnllabel.Visible = False
                            GridView1.Visible = False
                        End If
                        lblerror.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        lblmsg.Text = clearcount.ToString + ValidationMessage(1196)
                    End If
                End If
            Catch ex As Exception
                clear()
                lblerror.Text = ValidationMessage(1047)
                GridView1.Visible = False
            End Try
        'End If
        Else
        lblerror.Text = ValidationMessage(1091)
        lblmsg.Text = ValidationMessage(1014)
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
                'el.Batch = ddlbatch.SelectedValue
                'el.Semester = ddlsemester.SelectedValue
                'el.Subject = ddlsubject.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                dt4 = b.BatchAccess(el)
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
                        el.Batch = str + "," + el.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    el.Batch = 0
                End If
                dt5 = b.SemAccess(el)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        el.Semester = str1 + "," + el.Semester
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    el.Semester = 0
                End If
                el.Assesment = ddlassesment.SelectedValue
                el.AssesmentDate = TxtAssessmentDate.Text
                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                el.StdId = ddlStudent.SelectedValue
                lblerror.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                'el.Max = txtmax.Text
                'el.Min = txtMin.Text
                If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "N" Then
                    Dim roweffected As Integer = b.LockStdMarks(el)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        lblerror.Text = ValidationMessage(1014)
                        lblmsg.Text = ValidationMessage(1014)
                        lblmsg.Text = roweffected.ToString + ValidationMessage(1103)
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

                        dt = DLNew_StudentMarks.PostCheckBySub(role)
                        If dt.Rows.Count < 1 Then
                            lblerror.Text = ValidationMessage(1102)
                            lblmsg.Text = ValidationMessage(1014)
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            GridView1.Enabled = False
                            Image1.Visible = True
                            Image2.Visible = True
                        Else
                            check = dt.Rows(0)("Result").ToString.Trim

                            'check = dt.Rows(0)("Result").ToString.Trim
                            If check = "" Then
                                lblerror.Text = ValidationMessage(1102)
                                lblmsg.Text = ValidationMessage(1014)
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
                                    lblerror.Text = ValidationMessage(1014)
                                    lblmsg.Text = ValidationMessage(1014)
                                    lblmsg.Text = roweffected.ToString + ValidationMessage(1103)
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
                            lblerror.Text = ValidationMessage(1014)
                            lblmsg.Text = ValidationMessage(1014)
                            lblmsg.Text = roweffected.ToString + ValidationMessage(1104)
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
                lblerror.Text = ValidationMessage(1106)
                Image1.Visible = True
                Image2.Visible = True
                lblmsg.Text = ValidationMessage(1014)
            End If

        Else
            lblerror.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
        btnlock.Focus()
    End Sub
    Sub DisplayGrid()
        el.A_Year = 0
        'el.Batch = ddlbatch.SelectedValue
        'el.Semester = ddlsemester.SelectedValue
        'el.Subject = ddlsubject.SelectedValue
        el.Subject = ddlsubject.SelectedValue
        dt4 = b.BatchAccess(el)
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
                el.Batch = str + "," + el.Batch
                i = i + 1
                j = j - 1
            End While
        Else
            el.Batch = 0
        End If
        dt5 = b.SemAccess(el)
        i1 = 0
        j1 = dt5.Rows.Count
        If j1 > 0 Then
            While j1 > 0
                str1 = dt5.Rows(i1).Item("SemesterID").ToString
                el.Semester = str1 + "," + el.Semester
                i1 = i1 + 1
                j1 = j1 - 1
            End While
        Else
            el.Semester = 0
        End If
        el.Assesment = ddlassesment.SelectedValue
        el.AssesmentDate = TxtAssessmentDate.Text

        el.SubGrp = ddlSubjectSubGrp.SelectedValue
        el.StdId = ddlStudent.SelectedValue
        lblerror.Text = ValidationMessage(1014)
        lblmsg.Text = ValidationMessage(1014)
        'el.Max = txtmax.Text
        'el.Min = txtMin.Text
        dt = b.ViewStdMarks(el)
        If dt.Rows.Count > 0 Then
            GridView1.Visible = True
            GridView1.DataSource = dt
            GridView1.DataBind()
           
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ddlExamAttend"), DropDownList).SelectedValue = CType(grid.FindControl("lblEamAttdId"), Label).Text
                'lblAcademicYearAns.Text = ""
                lblBatchAns.Text = ""
                lblSemesterAns.Text = ""
                lblAssessmentDate.Text = ""
                lblSubjectAns.Text = ""
                lblAssessmentTypeAns.Text = ""
                'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                lblAssessmentDate.Text = CType(grid.FindControl("lblassessdate"), Label).Text
                lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text().ToString)
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
            lblerror.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            lblerror.Text = ValidationMessage(1023)
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
        If Not IsPostBack Then
            
            TabPanel1.Enabled = True
            TabPanel2.Enabled = False
            TxtAssessmentDate.Text = Format(Today, "dd-MMM-yyyy")
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + Panel2.ClientID + "').style.visibility='visible';", True)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "xyz", "document.getElementById('" + Panel3.ClientID + "').style.visibility='hidden';", True)


        End If
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
        lblmsg.Text = ValidationMessage(1014)
        lblerror.Text = ValidationMessage(1014)
    End Sub



    Protected Sub ddlsemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsemester.SelectedIndexChanged
        Try
            el.A_Year = 0
            'el.Batch = ddlbatch.SelectedValue
            'el.Semester = ddlsemester.SelectedValue
            el.Subject = ddlsubject.SelectedValue
            dt4 = b.BatchAccess(el)
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
                    el.Batch = str + "," + el.Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                el.Batch = 0
            End If
            dt5 = b.SemAccess(el)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    el.Semester = str1 + "," + el.Semester
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                el.Semester = 0
            End If
            If ddlsemester.SelectedValue <> 0 Then

                dt = b.GetSubjectComboBatchPlanner(el.Batch, el.Semester)
                If dt.Rows.Count <= 1 Then
                    lblmsg.Text = ValidationMessage(1014)
                    lblerror.Text = ValidationMessage(1197)
                Else
                    lblmsg.Text = ValidationMessage(1014)
                    lblerror.Text = ValidationMessage(1014)
                End If
            Else
                lblmsg.Text = ValidationMessage(1014)
                lblerror.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1014)
            lblerror.Text = ValidationMessage(1022)
        End Try

    End Sub

    Protected Sub ddlsemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsemester.TextChanged
        ddlsemester.Focus()
    End Sub

    Protected Sub ddlsubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsubject.SelectedIndexChanged
        el.Subject = ddlsubject.SelectedValue
        dt4 = b.BatchAccess(el)
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
                el.Batch = str + "," + el.Batch
                i = i + 1
                j = j - 1
            End While
        Else
            el.Batch = 0
        End If
        dt5 = b.SemAccess(el)
        i1 = 0
        j1 = dt5.Rows.Count
        If j1 > 0 Then
            While j1 > 0
                str1 = dt5.Rows(i1).Item("SemesterID").ToString
                el.Semester = str1 + "," + el.Semester
                i1 = i1 + 1
                j1 = j1 - 1
            End While
        Else
            el.Semester = 0
        End If
        'dt4 = b.BatchAccess(el)
        'If dt4.Rows.Count > 0 Then
        '    ' Subject = dt.Rows(i).Item("Subject").ToString
        '    el.Batch = dt4.Rows(0).Item("BatchID").ToString
        '    el.Semester = dt4.Rows(0).Item("Semester").ToString
        'End If
    End Sub

    Protected Sub ddlsubject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsubject.TextChanged
        ddlsubject.Focus()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            el.id = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("lblid"), Label).Text
            If b.ChangeFlag(el) Then
                lblerror.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1028)
                ddlbatch.Focus()
                GridView1.PageIndex = ViewState("PageIndex")
                el.A_Year = 0
                'el.Batch = ddlbatch.SelectedValue
                'el.Semester = ddlsemester.SelectedValue
                'el.Subject = ddlsubject.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                dt4 = b.BatchAccess(el)
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
                        el.Batch = str + "," + el.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    el.Batch = 0
                End If
                dt5 = b.SemAccess(el)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        el.Semester = str1 + "," + el.Semester
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    el.Semester = 0
                End If
                el.Assesment = ddlassesment.SelectedValue
                el.AssesmentDate = TxtAssessmentDate.Text
                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                el.StdId = ddlStudent.SelectedValue
                dt = b.ViewStdMarks(el)
                GridView1.Visible = True
                GridView1.DataSource = dt
                GridView1.DataBind()
              
                GridView1.Enabled = True
            End If
        Else
            lblerror.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
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
        'el.Batch = ddlbatch.SelectedValue
        'el.Semester = ddlsemester.SelectedValue
        'el.Subject = ddlsubject.SelectedValue
        el.Subject = ddlsubject.SelectedValue
        dt4 = b.BatchAccess(el)
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
                el.Batch = str + "," + el.Batch
                i = i + 1
                j = j - 1
            End While
        Else
            el.Batch = 0
        End If
        dt5 = b.SemAccess(el)
        i1 = 0
        j1 = dt5.Rows.Count
        If j1 > 0 Then
            While j1 > 0
                str1 = dt5.Rows(i1).Item("SemesterID").ToString
                el.Semester = str1 + "," + el.Semester
                i1 = i1 + 1
                j1 = j1 - 1
            End While
        Else
            el.Semester = 0
        End If
        el.Assesment = ddlassesment.SelectedValue
        el.AssesmentDate = TxtAssessmentDate.Text
        el.SubGrp = ddlSubjectSubGrp.SelectedValue
        el.StdId = ddlStudent.SelectedValue
        dt = b.ViewStdMarks(el)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
      
        For Each grid As GridViewRow In GridView1.Rows
            CType(grid.FindControl("ddlExamAttend"), DropDownList).SelectedValue = CType(grid.FindControl("lblEamAttdId"), Label).Text
            'lblAcademicYearAns.Text = ""
            lblBatchAns.Text = ""
            lblSemesterAns.Text = ""

            lblSubjectAns.Text = ""
            lblAssessmentTypeAns.Text = ""
            'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
            lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
            lblSemesterAns.Text = Trim(CType(grid.FindControl("LabelSemester"), Label).Text)

            lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text().ToString)
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
            ViewState("dirState") = value
        End Set
    End Property
    Protected Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        Dim sw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()
 
        Response.Clear()
        Response.ClearHeaders()
        Response.ClearContent()
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254")
        Response.Charset = "windows-1254"
        Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
        Page.Response.AddHeader("content-disposition", "attachment;filename=StudentMarksBySubject.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        GridView1.Parent.Controls.Add(frm)
        frm.Controls.Add(GridView1)
        frm.RenderControl(hw)
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub ReloadCtl_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReloadCtl.Click
        Dim dt As New DataTable
        Dim store As String = hiddencode.Value
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
                'el.Batch = ddlbatch.SelectedValue
                'el.Semester = ddlsemester.SelectedValue
                'el.Subject = ddlsubject.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                dt4 = b.BatchAccess(el)
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
                        el.Batch = str + "," + el.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    el.Batch = 0
                End If
                dt5 = b.SemAccess(el)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        el.Semester = str1 + "," + el.Semester
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    el.Semester = 0
                End If
                el.Assesment = ddlassesment.SelectedValue
                'el.ClassType = ddlclass.SelectedValue
                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                lblerror.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                'el.Max = txtmax.Text
                'el.Min = txtMin.Text
                dt1 = b.ViewStdMarks(el)
                count = dt.Rows.Count
                count1 = dt1.Rows.Count
                '  Dim i As Integer = 0
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

                    GridView1.Visible = True
                    GridView1.DataSource = dt1
                    GridView1.DataBind()
                  

                    For Each grid As GridViewRow In GridView1.Rows
                        'lblAcademicYearAns.Text = ""
                        lblBatchAns.Text = ""
                        lblSemesterAns.Text = ""
                        'lblClassTypeAns.Text = ""
                        lblSubjectAns.Text = ""
                        lblAssessmentTypeAns.Text = ""
                        'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                        lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                        lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                        'lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                        lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text().ToString)
                        lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                        pnllabel.Visible = True
                    Next

                    If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                        GridView1.Enabled = False
                    Else
                        GridView1.Enabled = True
                    End If
                    lblmsg.Text = ValidationMessage(1198)
                    lblerror.Text = ValidationMessage(1014)
                Else
                    lblerror.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    lblerror.Text = ValidationMessage(1023)
                    pnllabel.Visible = False
                    GridView1.Visible = False
                End If
                'End If
            Else
                lblmsg.Text = ValidationMessage(1014)
                lblerror.Text = ValidationMessage(1199)
            End If
        Catch ex As Exception
            lblerror.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            lblerror.Text = ValidationMessage(1200)
            GridView1.Visible = False
            ddlA_Year.Focus()
        End Try
    End Sub

    'Protected Sub linkImport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles linkImport.Click
    Protected Sub Btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnback.Click
        TabContainer1.ActiveTab = TabPanel1
        TabPanel1.Enabled = True
        'GVPRDetails.Visible = "false"
        'lblRed.Text = ""
        'lblGreen.Text = ""
        TabPanel2.Enabled = False
        Try
            Dim dt3 As DataTable
            dt3 = Session("importmarks")
            If dt3.Rows.Count <> 0 Then
                Dim dt As New DataTable
                Dim store As String = hiddencode.Value
                Dim row, col, count, count1, recordupdate As Integer
                dt = Session("importmarks")
                el.A_Year = 0
                'el.Batch = ddlbatch.SelectedValue
                'el.Semester = ddlsemester.SelectedValue
                'el.Subject = ddlsubject.SelectedValue
                el.Subject = ddlsubject.SelectedValue
                dt4 = b.BatchAccess(el)
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
                        el.Batch = str + "," + el.Batch
                        i = i + 1
                        j = j - 1
                    End While
                Else
                    el.Batch = 0
                End If
                dt5 = b.SemAccess(el)
                i1 = 0
                j1 = dt5.Rows.Count
                If j1 > 0 Then
                    While j1 > 0
                        str1 = dt5.Rows(i1).Item("SemesterID").ToString
                        el.Semester = str1 + "," + el.Semester
                        i1 = i1 + 1
                        j1 = j1 - 1
                    End While
                Else
                    el.Semester = 0
                End If
                el.Assesment = ddlassesment.SelectedValue
                'el.ClassType = ddlclass.SelectedValue
                el.SubGrp = ddlSubjectSubGrp.SelectedValue
                lblerror.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                'el.Max = txtmax.Text
                'el.Min = txtMin.Text
                dt1 = b.ViewStdMarks(el)
                count = dt.Rows.Count
                count1 = dt1.Rows.Count
                '    Dim i As Integer = 0
                While count1 > 0
                    ' dt1.Rows(count - 1).Item("StudentCode")
                    count = dt.Rows.Count
                    While count > 0
                        If dt.Rows(count - 1).Item("StudentCode") = Trim(dt1.Rows(count1 - 1).Item("StdCode")) Then
                            dt1.Rows(count1 - 1).Item("ActualMarks") = IIf(dt.Rows(count - 1).Item("ActualMarks") = "", 0, dt.Rows(count - 1).Item("ActualMarks"))
                            recordupdate = recordupdate + 1
                            Exit While
                        Else
                            count = count - 1
                        End If

                    End While

                    count1 = count1 - 1
                End While

                If dt1.Rows.Count > 0 Then
                    GridView1.Visible = True
                    GridView1.DataSource = dt1
                    GridView1.DataBind()

                    For Each grid As GridViewRow In GridView1.Rows
                        'lblAcademicYearAns.Text = ""
                        lblBatchAns.Text = ""
                        lblSemesterAns.Text = ""
                        'lblClassTypeAns.Text = ""
                        lblSubjectAns.Text = ""
                        lblAssessmentTypeAns.Text = ""
                        'lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                        lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                        lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                        'lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                        lblSubjectAns.Text = Trim(CType(grid.FindControl("LabelSubject"), Label).Text().ToString)
                        lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                        pnllabel.Visible = True
                    Next

                    If b.CheckLockMarks(el).Tables(0).Rows(0).Item(0) = "Y" Then
                        GridView1.Enabled = False
                    Else
                        GridView1.Enabled = True
                    End If
                    lblmsg.Text = ValidationMessage(1198)
                    lblerror.Text = ValidationMessage(1014)
                    dt.Clear()
                    dt1.Clear()
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + Panel2.ClientID + "').style.visibility='visible';", True)
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "xyz", "document.getElementById('" + Panel3.ClientID + "').style.visibility='hidden';", True)

                    'Session("importmarks") = ""
                Else
                    lblerror.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    lblerror.Text = ValidationMessage(1023)
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + Panel2.ClientID + "').style.visibility='visible';", True)
                    ScriptManager.RegisterStartupScript(Me, Me.GetType(), "xyz", "document.getElementById('" + Panel3.ClientID + "').style.visibility='hidden';", True)

                    pnllabel.Visible = False
                    GridView1.Visible = False
                End If
            Else
                lblmsg.Text = ValidationMessage(1014)
                lblerror.Text = ValidationMessage(1201)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + Panel2.ClientID + "').style.visibility='visible';", True)
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "xyz", "document.getElementById('" + Panel3.ClientID + "').style.visibility='hidden';", True)

            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1014)
            lblerror.Text = ValidationMessage(1202)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + Panel2.ClientID + "').style.visibility='visible';", True)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "xyz", "document.getElementById('" + Panel3.ClientID + "').style.visibility='hidden';", True)

        End Try
    End Sub
    Protected Sub btnparse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnparse.Click

        Dim dt As New DataTable

        Dim row, col, count, count1, recordupdate As Integer
        recordupdate = recordupdate + 1
        Try
            Dim store As String = txtData.Text
            'Dim rowdata() As String = store.Split("\n")
            Dim rowdata As String() = store.Split(New Char() {vbCrLf})
            ' CChar(vbCrLf)
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
            If dt.Rows.Count > 0 Then
                GridView2.DataSource = dt
                GridView2.DataBind()
               
            Else
                lblRed.Text = ValidationMessage(1203)
            End If
            Session("importmarks") = dt
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + Panel2.ClientID + "').style.visibility='hidden';", True)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "xyz", "document.getElementById('" + Panel3.ClientID + "').style.visibility='visible';", True)

        Catch ex As Exception
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1204)

        End Try
    End Sub
    Protected Sub btnimport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnimport.Click
        If GridView1.Rows.Count > 0 Then
            btnparse.Visible = True
            Btnback.Visible = True
            TabContainer1.ActiveTab = TabPanel2
            TabPanel1.Enabled = True
            TabPanel2.Enabled = True
            'GVPRDetails.Visible = "false"
            lblRed.Text = ValidationMessage(1014)
            lblGreen.Text = ValidationMessage(1014)
            txtData.Text = ""
            GridView2.DataSource = Nothing
            GridView2.DataBind()
            

            'TabPanel1.Enabled = False
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + Panel2.ClientID + "').style.visibility='hidden';", True)
            ScriptManager.RegisterStartupScript(Me, Me.GetType(), "xyz", "document.getElementById('" + Panel3.ClientID + "').style.visibility='visible';", True)

        Else
            lblmsg.Text = ValidationMessage(1014)
            lblerror.Text = ValidationMessage(1202)
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + Panel2.ClientID + "').style.visibility='hidden';", True)
            'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "xyz", "document.getElementById('" + Panel3.ClientID + "').style.visibility='visible';", True)

        End If

    End Sub
    Sub ViewDataStatus()
        Try
            'el.Batch = ddlbatch.SelectedValue
            'el.Semester = ddlsemester.SelectedValue
            'el.Subject = ddlsubject.SelectedValue
            el.Subject = ddlsubject.SelectedValue
            If el.Subject = 0 Then
                lblerror.Text = "Enter Subject Field."
                Exit Sub
            End If
            dt4 = b.BatchAccess(el)
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
                    el.Batch = str + "," + el.Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                el.Batch = 0
            End If
            dt5 = b.SemAccess(el)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    el.Semester = str1 + "," + el.Semester
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                el.Semester = 0
            End If
            Dim qrystring As String = "RptDataStatusBySub.aspx?" & QueryStr.Querystring() & "&Batch=" & el.Batch & "&Semester=" & el.Semester & "&Subject=" & el.Subject
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1014)
            lblerror.Text = ValidationMessage(1022)
        End Try

    End Sub

    Protected Sub TabContainer1_ActiveTabChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabContainer1.ActiveTabChanged
        If TabContainer1.ActiveTab Is TabPanel1 Then
            btnparse.Visible = False
            Btnback.Visible = False
        Else
            btnparse.Visible = True
            Btnback.Visible = True
        End If
    End Sub
    
    ''Retriving the text of controls based on Language

  
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
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
    Protected Sub RptButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RptButton.Click
        Try
            LinkButton.Focus()
            el.A_Year = 0
            'el.Batch = ddlbatch.SelectedValue
            'el.Semester = ddlsemester.SelectedValue
            'el.Subject = ddlsubject.SelectedValue
            el.Subject = ddlsubject.SelectedValue
            dt4 = b.BatchAccess(el)
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
                    el.Batch = str + "," + el.Batch
                    i = i + 1
                    j = j - 1
                End While
            Else
                el.Batch = 0
            End If
            dt5 = b.SemAccess(el)
            i1 = 0
            j1 = dt5.Rows.Count
            If j1 > 0 Then
                While j1 > 0
                    str1 = dt5.Rows(i1).Item("SemesterID").ToString
                    el.Semester = str1 + "," + el.Semester
                    i1 = i1 + 1
                    j1 = j1 - 1
                End While
            Else
                el.Semester = 0
            End If
            el.Assesment = ddlassesment.SelectedValue
            el.AssesmentDate = TxtAssessmentDate.Text

            el.SubGrp = ddlSubjectSubGrp.SelectedValue
            el.StdId = ddlStudent.SelectedValue
            lblerror.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)

            Dim qrystring As String = "RptStudMarksBySub.aspx?" & "&Ayear=" & el.A_Year & "&Batch=" & el.Batch & "&Semester=" & el.Semester & "&Subject=" & el.Subject & "&Assesment=" & el.Assesment & "&AssesmentDate=" & el.AssesmentDate & "&SubGrp=" & el.SubGrp & "&StdId=" & el.StdId
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1022)
            lblerror.Text = ValidationMessage(1014)
        End Try

    End Sub
End Class
