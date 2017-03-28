
Partial Class FrmBatchSemAssesmentResult
    Inherits BasePage
    Dim EL As New ELAssesmentResult
    Dim BL As New BLAssesmentResult
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim Grade As String
    Dim TotalMarks As Double
    Dim M1, M2, M3, M4, M5, M6, M7, M8, M9, StdId, P1, P2, P3, P4, P5, P6, P7, P8, P9 As New Double
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        If btnSubmit.Text <> "BACK" Then
            ViewState("PageIndex") = 0
            GVStdAttd.PageIndex = 0
            DisplayGrid()
        Else
            btnSubmit.Text = "VIEW"
            btnUpdate.Text = "UPDATE"
            GVStdAttd.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        End If
    End Sub
    Sub DisplayGrid()
        Dim Str As String = ""
        Dim ID As String = ""
        For Each grid As GridViewRow In GVSemResult.Rows
            If CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True Then
                Str = CType(grid.FindControl("Label1"), HiddenField).Value
                ID = Str + "," + ID
            End If
        Next
        Dim dt4 As DataTable
        dt4 = BL.GetAss(ID)
        EL.batchId = DdlBatch.SelectedValue
        EL.sem = cmbSemester.SelectedValue
        EL.Subject = cmbSubject.SelectedValue
        EL.AssesmentId = ID
        dt3 = BL.CountAssessment(EL.batchId, EL.sem, EL.AssesmentId)
        If dt3.Rows(0).Item("CountAssessment") > 9 Then
            msginfo.Text = ValidationMessage(1181)
            lblmsg.Text = ValidationMessage(1014)
            Exit Sub
        End If
        If ID = "" Then
            msginfo.Text = ValidationMessage(1182)
            lblmsg.Text = ValidationMessage(1014)
        Else
            LinkButton1.Focus()
            EL.batchId = DdlBatch.SelectedValue
            EL.sem = cmbSemester.SelectedValue
            EL.Subject = cmbSubject.SelectedValue
            EL.AssesmentId = ID
            ddlassesment.Items.Clear()
            dt = DLNew_StudentMarks.GetAssesmentComboSelect(ID)
            If dt.Rows.Count > 0 Then
                ddlassesment.DataSource = dt

                ddlassesment.DataBind()
            End If
            If rbSelect.SelectedValue = "2" Then
                dt = BL.GetGridData1(EL.batchId, EL.sem, EL.Subject, EL.AssesmentId)
                If dt.Rows.Count = 0 Then
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1023)
                    GVStdAttd.Visible = False

                Else
                    GVStdAttd.DataSource = dt
                    GVStdAttd.DataBind()
                    GVStdAttd.Visible = True

                End If
            Else
                dt = BL.GetGridData(EL.batchId, EL.sem, EL.Subject, EL.AssesmentId)
                If dt.Rows.Count = 0 Then
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1023)
                    GVStdAttd.Visible = False
                Else
                    GVStdAttd.DataSource = dt
                    GVStdAttd.DataBind()
                    GVStdAttd.Visible = True

                End If

                'For Each grid1 As GridViewRow In GVSemResult.Rows
                '    If CType(grid1.FindControl("ChkPresent"), CheckBox).Checked = True Then
                '        EL.AssesmentId = CType(grid1.FindControl("Label1"), HiddenField).Value
                '    Else
                '        Exit Sub
                '    End If

                'For Each grid As GridViewRow In GVStdAttd.Rows
                '    Try


                '        EL.AssesmentId = 0
                '        EL.id = CType(grid.FindControl("HidStdId"), HiddenField).Value
                '        EL.Subject = CType(grid.FindControl("lblSubjectId"), Label).Text
                '        EL.batchId = DdlBatch.SelectedValue
                '        EL.sem = cmbSemester.SelectedValue
                '        EL.AssesmentId = dt4.Rows(0).Item("AssesmentCode")
                '        CType(grid.FindControl("lbls1"), Label).Text = dt4.Rows(0).Item("AssessmentType")
                '        If CType(grid.FindControl("lblsub"), Label).Text = "" Then
                '            dt = BL.GetMarks(EL)
                '            If dt.Rows.Count <> 0 Then
                '                CType(grid.FindControl("lblsub"), Label).Text = dt.Rows(0).Item("ActualMarks")
                '            End If
                '        End If
                '    Catch ex As Exception

                '    End Try
                'Next
                'For Each grid As GridViewRow In GVStdAttd.Rows
                '    Try


                '        EL.AssesmentId = 0
                '        EL.id = CType(grid.FindControl("HidStdId"), HiddenField).Value
                '        EL.Subject = CType(grid.FindControl("lblSubjectId"), Label).Text
                '        EL.batchId = DdlBatch.SelectedValue
                '        EL.sem = cmbSemester.SelectedValue
                '        EL.AssesmentId = dt4.Rows(1).Item("AssesmentCode")
                '        CType(grid.FindControl("lbls23"), Label).Text = dt4.Rows(1).Item("AssessmentType")
                '        If CType(grid.FindControl("lblsub1"), Label).Text = "" Then
                '            dt = BL.GetMarks(EL)
                '            If dt.Rows.Count <> 0 Then
                '                CType(grid.FindControl("lblsub1"), Label).Text = dt.Rows(0).Item("ActualMarks")
                '            End If
                '        End If
                '    Catch ex As Exception

                '    End Try
                'Next

                'For Each grid As GridViewRow In GVStdAttd.Rows
                '    Try
                '        EL.AssesmentId = 0
                '        EL.id = CType(grid.FindControl("HidStdId"), HiddenField).Value
                '        EL.Subject = CType(grid.FindControl("lblSubjectId"), Label).Text
                '        EL.batchId = DdlBatch.SelectedValue
                '        EL.sem = cmbSemester.SelectedValue

                '        EL.AssesmentId = dt4.Rows(2).Item("AssesmentCode")
                '        CType(grid.FindControl("lbls1"), Label).Text = dt4.Rows(2).Item("AssessmentType")
                '        If CType(grid.FindControl("lblsub1"), Label).Text = "" Then
                '            EL.AssesmentId = 210
                '            dt = BL.GetMarks(EL)
                '            If dt.Rows.Count <> 0 Then
                '                CType(grid.FindControl("lblsub1"), Label).Text = dt.Rows(0).Item("ActualMarks")
                '            End If
                '        End If
                '    Catch ex As Exception

                '    End Try
                'Next
                'For Each grid As GridViewRow In GVStdAttd.Rows
                '    Try
                '        EL.AssesmentId = 0
                '        EL.id = CType(grid.FindControl("HidStdId"), HiddenField).Value
                '        EL.Subject = CType(grid.FindControl("lblSubjectId"), Label).Text
                '        EL.batchId = DdlBatch.SelectedValue
                '        EL.sem = cmbSemester.SelectedValue
                '        CType(grid.FindControl("lbls1"), Label).Text = dt4.Rows(3).Item("AssessmentType")
                '        EL.AssesmentId = dt4.Rows(3).Item("AssesmentCode")
                '        If CType(grid.FindControl("lblsub3"), Label).Text = "" Then
                '            dt = BL.GetMarks(EL)
                '            If dt.Rows.Count <> 0 Then
                '                CType(grid.FindControl("lblsub3"), Label).Text = dt.Rows(0).Item("ActualMarks")
                '            End If
                '        End If
                '    Catch ex As Exception

                '    End Try
                'Next
                'For Each grid As GridViewRow In GVStdAttd.Rows
                '    Try
                '        EL.AssesmentId = 0
                '      EL.id = CType(grid.FindControl("HidStdId"), HiddenField).Value
                '        EL.Subject = CType(grid.FindControl("lblSubjectId"), Label).Text
                '        EL.batchId = DdlBatch.SelectedValue
                '        EL.sem = cmbSemester.SelectedValue
                '        CType(grid.FindControl("lbls1"), Label).Text = dt4.Rows(4).Item("AssessmentType")
                '        EL.AssesmentId = dt4.Rows(4).Item("AssesmentCode")
                '        If CType(grid.FindControl("lblsub4"), Label).Text = "" Then

                '        End If

                '        dt = BL.GetMarks(EL)
                '        If dt.Rows.Count <> 0 Then
                '            CType(grid.FindControl("lblsub4"), Label).Text = dt.Rows(0).Item("ActualMarks")
                '        End If
                '    Catch ex As Exception

                '    End Try
                'Next

                'For Each grid As GridViewRow In GVStdAttd.Rows
                '    Try
                '        EL.AssesmentId = 0
                '        EL.id = CType(grid.FindControl("HidStdId"), HiddenField).Value
                '        EL.Subject = CType(grid.FindControl("lblSubjectId"), Label).Text
                '        EL.batchId = DdlBatch.SelectedValue
                '        EL.sem = cmbSemester.SelectedValue
                '        CType(grid.FindControl("lbls1"), Label).Text = dt4.Rows(5).Item("AssessmentType")
                '        EL.AssesmentId = dt4.Rows(5).Item("AssesmentCode")
                '        If CType(grid.FindControl("lblsub5"), Label).Text = "" Then
                '            dt = BL.GetMarks(EL)
                '            If dt.Rows.Count <> 0 Then
                '                CType(grid.FindControl("lblsub5"), Label).Text = dt.Rows(0).Item("ActualMarks")
                '            End If
                '        End If
                '    Catch ex As Exception

                '    End Try
                'Next

                'For Each grid As GridViewRow In GVStdAttd.Rows
                '    Try
                '        EL.AssesmentId = 0
                '        EL.id = CType(grid.FindControl("HidStdId"), HiddenField).Value
                '        EL.Subject = CType(grid.FindControl("lblSubjectId"), Label).Text
                '        EL.batchId = DdlBatch.SelectedValue
                '        EL.sem = cmbSemester.SelectedValue
                '        CType(grid.FindControl("lbls1"), Label).Text = dt4.Rows(6).Item("AssessmentType")
                '        EL.AssesmentId = dt4.Rows(6).Item("AssesmentCode")
                '        If CType(grid.FindControl("lblsub6"), Label).Text = "" Then
                '            dt = BL.GetMarks(EL)
                '            If dt.Rows.Count <> 0 Then
                '                CType(grid.FindControl("lblsub6"), Label).Text = dt.Rows(0).Item("ActualMarks")
                '            End If
                '        End If
                '    Catch ex As Exception

                '    End Try
                'Next
                'For Each grid As GridViewRow In GVStdAttd.Rows
                '    Try
                '        EL.AssesmentId = 0
                '        EL.id = CType(grid.FindControl("HidStdId"), HiddenField).Value
                '        EL.Subject = CType(grid.FindControl("lblSubjectId"), Label).Text
                '        EL.batchId = DdlBatch.SelectedValue
                '        EL.sem = cmbSemester.SelectedValue
                '        CType(grid.FindControl("lbls1"), Label).Text = dt4.Rows(7).Item("AssessmentType")
                '        EL.AssesmentId = dt4.Rows(7).Item("AssesmentCode")
                '        If CType(grid.FindControl("lblsub7"), Label).Text = "" Then
                '            dt = BL.GetMarks(EL)
                '            If dt.Rows.Count <> 0 Then
                '                CType(grid.FindControl("lblsub7"), Label).Text = dt.Rows(0).Item("ActualMarks")
                '            End If
                '        End If
                '    Catch ex As Exception

                '    End Try
                'Next
                'For Each grid As GridViewRow In GVStdAttd.Rows
                '    Try
                '        EL.AssesmentId = 0
                '        EL.id = CType(grid.FindControl("HidStdId"), HiddenField).Value
                '        EL.Subject = CType(grid.FindControl("lblSubjectId"), Label).Text
                '        EL.batchId = DdlBatch.SelectedValue
                '        EL.sem = cmbSemester.SelectedValue
                '        CType(grid.FindControl("lbls1"), Label).Text = dt4.Rows(8).Item("AssessmentType")
                '        EL.AssesmentId = dt4.Rows(8).Item("AssesmentCode")
                '        If CType(grid.FindControl("lblsub8"), Label).Text = "" Then
                '            dt = BL.GetMarks(EL)
                '            If dt.Rows.Count <> 0 Then
                '                CType(grid.FindControl("lblsub8"), Label).Text = dt.Rows(0).Item("ActualMarks")
                '            End If
                '        End If
                '    Catch ex As Exception

                '    End Try
                'Next
                'Next
            End If
        End If
    End Sub

    Protected Sub DdlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlBatch.SelectedIndexChanged
        DdlBatch.Focus()
        'txtt1.Text = ""
        'txtt2.Text = ""
        'txtt3.Text = ""
        'txtt4.Text = ""
        'txtt5.Text = ""
        'txtt6.Text = ""
        'If DdlBatch.Items.Count > 0 Then
        '    If DdlBatch.Items(0).Text <> "Select" Then
        '        DdlBatch.Items.Insert(0, "Select")
        '    End If
        'Else
        '    DdlBatch.Items.Insert(0, "Select")
        'End If
        If DdlBatch.SelectedValue <> 0 Then
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            Dim dt As New DataTable
            dt = DLSemFinalResult.GetAssesmentCombo1()
            GVSemResult.DataSource = dt
            GVSemResult.DataBind()
            GVSemResult.Visible = True
        Else
            GVSemResult.Visible = False
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
        End If
       

    End Sub
    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try

       
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If ddlassesment.SelectedValue = 0 Then
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1183)
                    Exit Sub
                Else
                    EL.Asses = ddlassesment.SelectedValue

                    EL.batchId = DdlBatch.SelectedValue
                    If ddlAddsem.SelectedValue = 0 Then
                        EL.sem = cmbSemester.SelectedValue
                    Else
                        EL.sem = ddlAddsem.SelectedValue
                    End If
                    dt = BL.AcademicYear(EL)
                    EL.Academicyr = dt.Rows(0).Item("AcademicYear").ToString
                    If ddlAddsem.SelectedValue = 0 Then
                        EL.sem = cmbSemester.SelectedValue
                    Else
                        EL.sem1 = ddlAddsem.SelectedValue
                    End If

                    If txtmaxmarks.Text = "" Then
                        lblmsg.Text = ValidationMessage(1014)
                        msginfo.Text = ValidationMessage(1184)
                        Exit Sub
                    Else
                        EL.MaxMarks = txtmaxmarks.Text
                    End If
                    If txtMinmarks.Text = "" Then
                        lblmsg.Text = ValidationMessage(1014)
                        msginfo.Text = ValidationMessage(1185)
                        Exit Sub
                    Else
                        EL.MinMarks = txtMinmarks.Text
                    End If
                    EL.Subject = cmbSubject.SelectedValue
                    dt = BL.Duplicate(EL)
                    If dt.Rows.Count <> 0 Then
                        lblmsg.Text = ValidationMessage(1014)
                        msginfo.Text = ValidationMessage(1186)
                        Exit Sub
                    End If
                    For Each grid As GridViewRow In GVStdAttd.Rows
                        EL.Subject = CType(grid.FindControl("lblSubjectId"), Label).Text
                        EL.Stdid = CType(grid.FindControl("lblStdId"), Label).Text
                        If CType(grid.FindControl("txtTotalMarks"), Label).Text = "" Then
                            EL.TotalMarks = 0
                        Else
                            EL.TotalMarks = CType(grid.FindControl("txtTotalMarks"), Label).Text
                        End If

                        EL.TotalMarksPer = CType(grid.FindControl("txtTotalMarksPer"), Label).Text
                        EL.Grade = CType(grid.FindControl("txtGrade"), Label).Text

                        BL.Insert(EL)
                    Next
                    lblmsg.Text = ValidationMessage(1017)
                    txtmaxmarks.Text = ""
                    txtMinmarks.Text = ""
                    txtBestOf.Text = ""
                    msginfo.Text = ValidationMessage(1014)
                    GVStdAttd.Visible = True

                End If
            Else
                msginfo.Text = ValidationMessage(1021)
                lblmsg.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1117)
            lblmsg.Text = ValidationMessage(1014)
        End Try
    End Sub

    Protected Sub btnCalculate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Try           
        
            Dim t1, t2, t3, t4, t5, t6, t7, t8, t9 As Double
            Dim BestOF As Integer
            If RBType.SelectedValue = "2" Then
                'Dim Str As String = ""
                'Dim ID As String = ""
                'For Each grid As GridViewRow In GVSemResult.Rows
                '    If CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True Then
                '        Str = CType(grid.FindControl("Label1"), HiddenField).Value
                '        ID = Str + "," + ID
                '    End If
                'Next
                'EL.batchId = DdlBatch.SelectedValue
                'EL.sem = cmbSemester.SelectedValue
                'EL.Subject = cmbSubject.SelectedValue
                'EL.AssesmentId = ID
                'dt = BL.GetGridData1(EL.batchId, EL.sem, EL.Subject, EL.AssesmentId)

                'For Each grid As GridViewRow In GvWeightage.Rows
                '    If CType(grid.FindControl("txtAssmt1"), TextBox).Text = "" Then
                '        EL.Ass1 = 0
                '    Else
                '        EL.Ass1 = CType(grid.FindControl("txtAssmt1"), TextBox).Text
                '    End If
                '    If CType(grid.FindControl("txtAssmt2"), TextBox).Text = "" Then
                '        EL.Ass2 = 0
                '    Else
                '        EL.Ass2 = CType(grid.FindControl("txtAssmt2"), TextBox).Text
                '    End If
                '    If CType(grid.FindControl("txtAssmt3"), TextBox).Text = "" Then
                '        EL.Ass3 = 0
                '    Else
                '        EL.Ass3 = CType(grid.FindControl("txtAssmt3"), TextBox).Text
                '    End If
                '    If CType(grid.FindControl("txtAssmt4"), TextBox).Text = "" Then
                '        EL.Ass4 = 0
                '    Else
                '        EL.Ass4 = CType(grid.FindControl("txtAssmt4"), TextBox).Text
                '    End If
                '    If CType(grid.FindControl("txtAssmt5"), TextBox).Text = "" Then
                '        EL.Ass5 = 0
                '    Else
                '        EL.Ass5 = CType(grid.FindControl("txtAssmt5"), TextBox).Text
                '    End If
                '    If CType(grid.FindControl("txtAssmt6"), TextBox).Text = "" Then
                '        EL.Ass6 = 0
                '    Else
                '        EL.Ass6 = CType(grid.FindControl("txtAssmt6"), TextBox).Text
                '    End If

                'Next
                If txtt1.Text = "" Then
                    t1 = 0
                Else
                    t1 = txtt1.Text
                End If
                If txtt2.Text = "" Then
                    t2 = 0
                Else
                    t2 = txtt2.Text
                End If
                If txtt3.Text = "" Then
                    t3 = 0
                Else
                    t3 = txtt3.Text
                End If
                If txtt4.Text = "" Then
                    t4 = 0
                Else
                    t4 = txtt4.Text
                End If
                If txtt5.Text = "" Then
                    t5 = 0
                Else
                    t5 = txtt5.Text
                End If
                If txtt6.Text = "" Then
                    t6 = 0
                Else
                    t6 = txtt6.Text
                End If
                If txtt7.Text = "" Then
                    t7 = 0
                Else
                    t7 = txtt7.Text
                End If
                If txtt8.Text = "" Then
                    t8 = 0
                Else
                    t8 = txtt8.Text
                End If
                If txtt9.Text = "" Then
                    t9 = 0
                Else
                    t9 = txtt9.Text
                End If
                For Each grid As GridViewRow In GVStdAttd.Rows
                    StdId = CType(grid.FindControl("HidStdId"), HiddenField).Value
                    If CType(grid.FindControl("lblsub"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub"), Label).Text = 0
                    Else
                        P1 = (t1 / 100) * CType(grid.FindControl("lblsub"), Label).Text
                        M1 = CType(grid.FindControl("lblsub"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub1"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub1"), Label).Text = 0
                    Else
                        P2 = (t2 / 100) * CType(grid.FindControl("lblsub1"), Label).Text
                        M2 = CType(grid.FindControl("lblsub1"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub2"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub2"), Label).Text = 0
                    Else
                        P3 = (t3 / 100) * CType(grid.FindControl("lblsub2"), Label).Text
                        M3 = CType(grid.FindControl("lblsub2"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub3"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub3"), Label).Text = 0
                    Else
                        P4 = (t4 / 100) * CType(grid.FindControl("lblsub3"), Label).Text
                        M4 = CType(grid.FindControl("lblsub3"), Label).Text
                    End If

                    If CType(grid.FindControl("lblsub4"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub4"), Label).Text = 0
                    Else
                        P5 = (t5 / 100) * CType(grid.FindControl("lblsub4"), Label).Text
                        M5 = CType(grid.FindControl("lblsub4"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub5"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub5"), Label).Text = 0
                    Else
                        P6 = (t6 / 100) * CType(grid.FindControl("lblsub5"), Label).Text
                        M6 = CType(grid.FindControl("lblsub5"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub6"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub6"), Label).Text = 0
                    Else
                        P7 = (t7 / 100) * CType(grid.FindControl("lblsub6"), Label).Text
                        M7 = CType(grid.FindControl("lblsub6"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub7"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub7"), Label).Text = 0
                    Else
                        P8 = (t8 / 100) * CType(grid.FindControl("lblsub7"), Label).Text
                        M8 = CType(grid.FindControl("lblsub7"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub8"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub8"), Label).Text = 0
                    Else
                        P9 = (t9 / 100) * CType(grid.FindControl("lblsub8"), Label).Text
                        M9 = CType(grid.FindControl("lblsub8"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub"), Label).Text = 0 Then
                        CType(grid.FindControl("lblsub"), Label).Text = ""
                    End If
                    If CType(grid.FindControl("lblsub1"), Label).Text = 0 Then
                        CType(grid.FindControl("lblsub1"), Label).Text = ""
                    End If
                    If CType(grid.FindControl("lblsub2"), Label).Text = 0 Then
                        CType(grid.FindControl("lblsub2"), Label).Text = ""
                    End If
                    If CType(grid.FindControl("lblsub3"), Label).Text = 0 Then
                        CType(grid.FindControl("lblsub3"), Label).Text = ""
                    End If
                    If CType(grid.FindControl("lblsub4"), Label).Text = 0 Then
                        CType(grid.FindControl("lblsub4"), Label).Text = ""
                    End If
                    If CType(grid.FindControl("lblsub5"), Label).Text = 0 Then
                        CType(grid.FindControl("lblsub5"), Label).Text = ""
                    End If
                    If CType(grid.FindControl("lblsub6"), Label).Text = 0 Then
                        CType(grid.FindControl("lblsub6"), Label).Text = ""
                    End If
                    If CType(grid.FindControl("lblsub7"), Label).Text = 0 Then
                        CType(grid.FindControl("lblsub7"), Label).Text = ""
                    End If
                    If CType(grid.FindControl("lblsub8"), Label).Text = 0 Then
                        CType(grid.FindControl("lblsub8"), Label).Text = ""
                    End If
                    EL.TotalMarksPer = (P1 + P2 + P3 + P4 + P5 + P6 + P7 + P8 + P9)
                    EL.TotalMarks = (M1 + M2 + M3 + M4 + M5 + M6 + M7 + M8 + M9)

                    CType(grid.FindControl("txtTotalMarksPer"), Label).Text = Format(EL.TotalMarksPer, "0.00")
                    CType(grid.FindControl("txtTotalMarks"), Label).Text = EL.TotalMarks
                    'dt1 = BL.UpdateGrade(EL)
                    'If dt1.Rows.Count = 0 Then
                    '    CType(grid.FindControl("txtGrade"), Label).Text = ""
                    'Else
                    '    Grade = dt1.Rows(0).Item("Grade").ToString
                    '    CType(grid.FindControl("txtGrade"), Label).Text = Grade
                    'End If
                    P1 = 0
                    P2 = 0
                    P3 = 0
                    P4 = 0
                    P5 = 0
                    P6 = 0
                    P7 = 0
                    P8 = 0
                    P9 = 0
                    M1 = 0
                    M2 = 0
                    M3 = 0
                    M4 = 0
                    M5 = 0
                    M6 = 0
                    M7 = 0
                    M8 = 0
                    M9 = 0
                Next
                lblmsg.Text = ValidationMessage(1187)
                msginfo.Text = ValidationMessage(1014)
                txtt1.Text = ""
                txtt2.Text = ""
                txtt3.Text = ""
                txtt4.Text = ""
                txtt5.Text = ""
                txtt6.Text = ""
                txtt7.Text = ""
                txtt8.Text = ""
                txtt9.Text = ""
            Else
                'EL.batchId = DdlBatch.SelectedValue
                'EL.sem = cmbSemester.SelectedValue
                'EL.Subject = cmbSubject.SelectedValue
                If txtBestOf.Text = "" Then
                    BestOF = 0
                Else
                    BestOF = txtBestOf.Text
                End If
                If txtt1.Text = "" Then
                    t1 = 0
                Else
                    t1 = txtt1.Text
                End If
                If txtt2.Text = "" Then
                    t2 = 0
                Else
                    t2 = txtt2.Text
                End If
                If txtt3.Text = "" Then
                    t3 = 0
                Else
                    t3 = txtt3.Text
                End If
                If txtt4.Text = "" Then
                    t4 = 0
                Else
                    t4 = txtt4.Text
                End If
                If txtt5.Text = "" Then
                    t5 = 0
                Else
                    t5 = txtt5.Text
                End If
                If txtt6.Text = "" Then
                    t6 = 0
                Else
                    t6 = txtt6.Text
                End If
                If txtt7.Text = "" Then
                    t7 = 0
                Else
                    t7 = txtt7.Text
                End If
                If txtt8.Text = "" Then
                    t8 = 0
                Else
                    t8 = txtt8.Text
                End If
                If txtt9.Text = "" Then
                    t9 = 0
                Else
                    t9 = txtt9.Text
                End If
                For Each grid As GridViewRow In GVStdAttd.Rows
                    StdId = CType(grid.FindControl("HidStdId"), HiddenField).Value
                    If CType(grid.FindControl("lblsub"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub"), Label).Text = 0
                    Else
                        P1 = t1 * CType(grid.FindControl("lblsub"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub1"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub1"), Label).Text = 0
                    Else
                        P2 = t2 * CType(grid.FindControl("lblsub1"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub2"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub2"), Label).Text = 0
                    Else
                        P3 = t3 * CType(grid.FindControl("lblsub2"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub3"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub3"), Label).Text = 0
                    Else
                        P4 = t4 * CType(grid.FindControl("lblsub3"), Label).Text
                    End If

                    If CType(grid.FindControl("lblsub4"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub4"), Label).Text = 0
                    Else
                        P5 = t5 * CType(grid.FindControl("lblsub4"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub5"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub5"), Label).Text = 0
                    Else
                        P6 = t6 * CType(grid.FindControl("lblsub5"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub6"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub6"), Label).Text = 0
                    Else
                        P7 = t7 * CType(grid.FindControl("lblsub6"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub7"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub7"), Label).Text = 0
                    Else
                        P8 = t8 * CType(grid.FindControl("lblsub7"), Label).Text
                    End If
                    If CType(grid.FindControl("lblsub8"), Label).Text = "" Then
                        CType(grid.FindControl("lblsub8"), Label).Text = 0
                    Else
                        P9 = t9 * CType(grid.FindControl("lblsub8"), Label).Text
                    End If
                    dt2 = BL.BEstOF(P1, P2, P3, P4, P5, P6, P7, P8, P9, BestOF)
                    If dt2.Rows(0).Item("TotalMarksPer").ToString = "" Then
                        TotalMarks = 0
                    Else
                        TotalMarks = dt2.Rows(0).Item("TotalMarksPer").ToString
                    End If
                    CType(grid.FindControl("txtTotalMarksPer"), Label).Text = Format(TotalMarks, "0.00")
                    If P1 = 0 Then
                        CType(grid.FindControl("lblsub"), Label).Text = ""
                    End If
                    If P2 = 0 Then
                        CType(grid.FindControl("lblsub1"), Label).Text = ""
                    End If
                    If P3 = 0 Then
                        CType(grid.FindControl("lblsub2"), Label).Text = ""
                    End If
                    If P4 = 0 Then
                        CType(grid.FindControl("lblsub3"), Label).Text = ""
                    End If
                    If P5 = 0 Then
                        CType(grid.FindControl("lblsub4"), Label).Text = ""
                    End If
                    If P6 = 0 Then
                        CType(grid.FindControl("lblsub5"), Label).Text = ""
                    End If
                    If P7 = 0 Then
                        CType(grid.FindControl("lblsub6"), Label).Text = ""
                    End If
                    If P8 = 0 Then
                        CType(grid.FindControl("lblsub7"), Label).Text = ""
                    End If
                    If P9 = 0 Then
                        CType(grid.FindControl("lblsub8"), Label).Text = ""
                    End If
                    P1 = 0
                    P2 = 0
                    P3 = 0
                    P4 = 0
                    P5 = 0
                    P6 = 0
                    P7 = 0
                    P8 = 0
                    P9 = 0
                    M1 = 0
                    M2 = 0
                    M3 = 0
                    M4 = 0
                    M5 = 0
                    M6 = 0
                    M7 = 0
                    M8 = 0
                    M9 = 0
                Next
                lblmsg.Text = ValidationMessage(1187)
                msginfo.Text = ValidationMessage(1014)
                txtt1.Text = ""
                txtt2.Text = ""
                txtt3.Text = ""
                txtt4.Text = ""
                txtt5.Text = ""
                txtt6.Text = ""
                txtt7.Text = ""
                txtt8.Text = ""
                txtt9.Text = ""
            End If
        Catch ex As Exception
            'msginfo.Text = "Enter correct data."
            'lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            DdlBatch.Focus()
            dt = DLNew_StudentMarks.GetAssesmentComboSelect(0)
            If dt.Rows.Count > 0 Then
                ddlassesment.DataSource = dt

                ddlassesment.DataBind()
            End If

        End If

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
        cmbSemester.Focus()
        EL.sem = cmbSemester.SelectedValue
        ddlAddsem.SelectedValue = EL.sem
    End Sub
    
    Protected Sub BtnRoundOff_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRoundOff.Click
        For Each grid As GridViewRow In GVStdAttd.Rows
            Dim Tot As Double
            Dim wholePart As Double
            Dim fractionalPart As Double
            Try
                TotalMarks = CType(grid.FindControl("txtTotalMarksPer"), Label).Text
                'Tot = Math.Round(TotalMarks)
                Tot = Math.Round(TotalMarks + 0.5)
                wholePart = Math.Truncate(TotalMarks)
                fractionalPart = TotalMarks - wholePart
                If fractionalPart < "0.50" Then
                    CType(grid.FindControl("txtTotalMarksPer"), Label).Text = Math.Floor(TotalMarks)
                Else
                    CType(grid.FindControl("txtTotalMarksPer"), Label).Text = Tot
                End If
            Catch ex As Exception
                CType(grid.FindControl("txtTotalMarksPer"), Label).Text = ""
            End Try
        Next
        lblmsg.Text = ValidationMessage(1188)
        msginfo.Text = ValidationMessage(1014)
    End Sub
    'Code written fro multilingual by Niraj on 13 Dec 2013
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
End Class
