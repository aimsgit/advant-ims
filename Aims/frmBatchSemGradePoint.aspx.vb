Imports System.IO
Partial Class frmBatchSemGradePoint
    Inherits BasePage
    Dim EL As New ELGradePointResult
    Dim dt, dt1, dt2, dtdiv As New DataTable
    Dim bl As New BLGradePointResult
    Dim Grade As String
    Dim Division As String
    Dim M1, M2, M3, M4, M5, M6, M7, M8, M9, M10, M11, M12, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, StdId, Per, Ma1, Ma2, Ma3, Ma4, Ma5, Ma6, Ma7, Ma8, Ma9, Ma10, Ma11, Ma12 As New Double
    Dim C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, Per1, Per2, Per3, Per4, Per5, Per6, Per7, Per8, Per9, Per10, Per11, Per12 As Double
    Sub DisplayGrid()
        Try

        
            Dim Str, subjectlist As String
            Str = ""
            subjectlist = ""
            Dim ID As String = ""
            Dim Course As Integer
            EL.batchId = DdlBatch.SelectedValue
            EL.sem = ddlsemNew.SelectedValue
            EL.Assesmentid = ddlassesment.SelectedValue
            'EL.Batch_No = DdlBatchPlanner.SelectedValue
            'EL.id = EL.Batch_No
            ViewState("V") = EL.batchId
            dt1 = DLGradePointResult.filltextbox(EL)
            Course = dt1.Rows(0).Item("Courseid")
            dt2 = bl.SearchCourse(Course)
            If dt2.Rows(0).Item("GMID") = 0 Then
                Course = 0
            Else
                Course = dt1.Rows(0).Item("Courseid")
            End If
            'dt = bl.DuplicateSemResult(EL)
            'If dt.Rows.Count = 0 Then
            '    dt = bl.GetGridData1(EL.batchId, EL.sem, EL.Assesmentid)
            '    If dt.Rows.Count = 0 Then
            '        GVStdAttd.DataSource = dt
            '        GVStdAttd.DataBind()
            '        lblmsg.Text = ""
            '        msginfo.Text = "No records to display."

            '    Else
            '        GVStdAttd.DataSource = dt
            '        GVStdAttd.DataBind()
            '        GVStdAttd.Enabled = True
            '        GVStdAttd.Visible = True
            '    End If
            'Else
            For Each grid As GridViewRow In Gridsubject.Rows
                If CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True Then
                    If CType(grid.FindControl("Label1"), HiddenField).Value <> 0 Then
                        Str = CType(grid.FindControl("Label1"), HiddenField).Value
                        ID = Str + "," + ID
                    End If
                End If
            Next

            If ID = "0" Then
                msginfo.Text = ValidationMessage(1205)
                lblmsg.Text = ValidationMessage(1014)
            Else
                ID = Left(ID, ID.Length - 1)
                EL.Subject = ID
                dt = bl.GetGridData1(EL.batchId, EL.sem, EL.Assesmentid, EL.Subject)
                If dt.Rows.Count = 0 Then
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1023)
                    GVStdAttd.Visible = False
                Else
                    GVStdAttd.DataSource = dt
                    GVStdAttd.DataBind()
                    GVStdAttd.Visible = True
                    For Each grid As GridViewRow In GVStdAttd.Rows
                        StdId = CType(grid.FindControl("HidStdId"), HiddenField).Value
                        If CType(grid.FindControl("lblcredit1"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit1"), Label).Text = 0
                        Else
                            C1 = CType(grid.FindControl("lblcredit1"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit2"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit2"), Label).Text = 0
                        Else
                            C2 = CType(grid.FindControl("lblcredit2"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit3"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit3"), Label).Text = 0
                        Else
                            C3 = CType(grid.FindControl("lblcredit3"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit4"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit4"), Label).Text = 0
                        Else
                            C4 = CType(grid.FindControl("lblcredit4"), Label).Text
                        End If

                        If CType(grid.FindControl("lblcredit5"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit5"), Label).Text = 0
                        Else
                            C5 = CType(grid.FindControl("lblcredit5"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit6"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit6"), Label).Text = 0
                        Else
                            C6 = CType(grid.FindControl("lblcredit6"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit7"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit7"), Label).Text = 0
                        Else
                            C7 = CType(grid.FindControl("lblcredit7"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit8"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit8"), Label).Text = 0
                        Else
                            C8 = CType(grid.FindControl("lblcredit8"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit9"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit9"), Label).Text = 0
                        Else
                            C9 = CType(grid.FindControl("lblcredit9"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit10"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit10"), Label).Text = 0
                        Else
                            C10 = CType(grid.FindControl("lblcredit10"), Label).Text
                        End If
                        If CType(grid.FindControl("lblpercent"), Label).Text = "" Then
                            CType(grid.FindControl("lblpercent"), Label).Text = 0
                            Per1 = 0
                        Else
                            Per1 = CType(grid.FindControl("lblpercent"), Label).Text
                        End If

                        dt1 = bl.UpdateGrade(Per1, Course)
                        

                        EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("lblsub"), Label).Text = ""
                        Else
                            EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        End If
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("lblsub12"), Label).Text = ""
                        Else
                            'C1 * EL.GradePoint = dt1.Rows(0).Item("lbls12").ToString
                            CType(grid.FindControl("lblsub12"), Label).Text = EL.GradePoint
                        End If
                        If CType(grid.FindControl("lblpercent1"), Label).Text = "" Then
                            CType(grid.FindControl("lblpercent1"), Label).Text = 0
                            Per2 = 0
                        Else
                            Per2 = CType(grid.FindControl("lblpercent1"), Label).Text
                        End If
                        dt1 = bl.UpdateGrade(Per2, Course)
                        EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("lblsub"), Label).Text = ""
                        Else
                            'EL.Division = dt1.Rows(0).Item("lbls1").ToString
                            CType(grid.FindControl("lblsub"), Label).Text = EL.GradePoint
                        End If
                        If CType(grid.FindControl("lblpercent2"), Label).Text = "" Then
                            CType(grid.FindControl("lblpercent2"), Label).Text = 0
                            Per3 = 0
                        Else
                            Per3 = CType(grid.FindControl("lblpercent2"), Label).Text
                        End If
                        dt1 = bl.UpdateGrade(Per3, Course)
                        EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("lblsub1"), Label).Text = ""
                        Else
                            'EL.Division = dt1.Rows(0).Item("lbls1").ToString
                            CType(grid.FindControl("lblsub1"), Label).Text = EL.GradePoint
                        End If
                        If CType(grid.FindControl("lblpercent3"), Label).Text = "" Then
                            CType(grid.FindControl("lblpercent3"), Label).Text = 0
                            Per4 = 0
                        Else
                            Per4 = CType(grid.FindControl("lblpercent3"), Label).Text
                        End If
                        dt1 = bl.UpdateGrade(Per4, Course)
                        EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("lblsub2"), Label).Text = ""
                        Else
                            'EL.Division = dt1.Rows(0).Item("lbls1").ToString
                            CType(grid.FindControl("lblsub2"), Label).Text = EL.GradePoint
                        End If
                        If CType(grid.FindControl("lblpercent4"), Label).Text = "" Then
                            CType(grid.FindControl("lblpercent4"), Label).Text = 0
                            Per5 = 0
                        Else
                            Per5 = CType(grid.FindControl("lblpercent4"), Label).Text
                        End If
                        dt1 = bl.UpdateGrade(Per5, Course)
                        EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("lblsub3"), Label).Text = ""
                        Else
                            'EL.Division = dt1.Rows(0).Item("lbls1").ToString
                            CType(grid.FindControl("lblsub3"), Label).Text = EL.GradePoint
                        End If
                        If CType(grid.FindControl("lblpercent5"), Label).Text = "" Then
                            CType(grid.FindControl("lblpercent5"), Label).Text = 0
                            Per6 = 0
                        Else
                            Per6 = CType(grid.FindControl("lblpercent5"), Label).Text
                        End If
                        dt1 = bl.UpdateGrade(Per6, Course)
                        EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("lblsub4"), Label).Text = ""
                        Else
                            'EL.Division = dt1.Rows(0).Item("lbls1").ToString
                            CType(grid.FindControl("lblsub4"), Label).Text = EL.GradePoint
                        End If
                        If CType(grid.FindControl("lblpercent6"), Label).Text = "" Then
                            CType(grid.FindControl("lblpercent6"), Label).Text = 0
                            Per7 = 0
                        Else
                            Per7 = CType(grid.FindControl("lblpercent6"), Label).Text
                        End If
                        dt1 = bl.UpdateGrade(Per7, Course)
                        EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("lblsub5"), Label).Text = ""
                        Else
                            'EL.Division = dt1.Rows(0).Item("lbls1").ToString
                            CType(grid.FindControl("lblsub5"), Label).Text = EL.GradePoint
                        End If
                        If CType(grid.FindControl("lblpercent7"), Label).Text = "" Then
                            CType(grid.FindControl("lblpercent7"), Label).Text = 0
                            Per8 = 0
                        Else
                            Per8 = CType(grid.FindControl("lblpercent7"), Label).Text
                        End If
                        dt1 = bl.UpdateGrade(Per8, Course)
                        EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("lblsub6"), Label).Text = ""
                        Else
                            'EL.Division = dt1.Rows(0).Item("lbls1").ToString
                            CType(grid.FindControl("lblsub6"), Label).Text = EL.GradePoint
                        End If
                        If CType(grid.FindControl("lblpercent8"), Label).Text = "" Then
                            CType(grid.FindControl("lblpercent8"), Label).Text = 0
                            Per9 = 0
                        Else
                            Per9 = CType(grid.FindControl("lblpercent8"), Label).Text
                        End If
                        dt1 = bl.UpdateGrade(Per9, Course)
                        EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("lblsub7"), Label).Text = ""
                        Else
                            'EL.Division = dt1.Rows(0).Item("lbls1").ToString
                            CType(grid.FindControl("lblsub7"), Label).Text = EL.GradePoint
                        End If
                        If CType(grid.FindControl("lblpercent9"), Label).Text = "" Then
                            CType(grid.FindControl("lblpercent9"), Label).Text = 0
                            Per10 = 0
                        Else
                            Per10 = CType(grid.FindControl("lblpercent9"), Label).Text
                        End If
                        dt1 = bl.UpdateGrade(Per10, Course)
                        EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("lblsub8"), Label).Text = ""
                        Else
                            'EL.Division = dt1.Rows(0).Item("lbls1").ToString
                            CType(grid.FindControl("lblsub8"), Label).Text = EL.GradePoint
                        End If
                        'If CType(grid.FindControl("lblpercent10"), Label).Text = "" Then
                        '    CType(grid.FindControl("lblpercent10"), Label).Text = 0
                        'Else
                        '    Per11 = CType(grid.FindControl("lblpercent10"), Label).Text
                        'End If
                        'dt1 = bl.UpdateGrade(Per2)
                        'EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        'If dt1.Rows.Count = 0 Then
                        '    CType(grid.FindControl("lblsub9"), Label).Text = ""
                        'Else
                        '    'EL.Division = dt1.Rows(0).Item("lbls1").ToString
                        '    CType(grid.FindControl("lblsub9"), Label).Text = C11 * EL.GradePoint
                        'End If
                        'If CType(grid.FindControl("lblpercent11"), Label).Text = "" Then
                        '    CType(grid.FindControl("lblpercent11"), Label).Text = 0
                        'Else
                        '    Per12 = CType(grid.FindControl("lblpercent11"), Label).Text
                        'End If
                        'dt1 = bl.UpdateGrade(Per2)
                        'EL.GradePoint = dt1.Rows(0).Item("GradePoint")
                        'If dt1.Rows.Count = 0 Then
                        '    CType(grid.FindControl("lblsub13"), Label).Text = ""
                        'Else
                        '    'EL.Division = dt1.Rows(0).Item("lbls1").ToString
                        '    CType(grid.FindControl("lblsub13"), Label).Text = C12 * EL.GradePoint
                        'End If
                        'EL.TotalMarks = Math.Round(M1 + M2 + M3 + M4 + M5 + M6 + M7 + M8 + M9 + M10 + M11 + M12)
                        'CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text = EL.TotalMarks
                        'CType(grid.FindControl("txtTotalMarks"), TextBox).Text = EL.TotalMarks
                        'CType(grid.FindControl("txtMaxMarks"), TextBox).Text = (P1 + P2 + P3 + P4 + P5 + P6 + P7 + P8 + P9 + P10 + P11 + P12)


                        'dt1 = bl.UpdateGrade(A)
                        'If dt1.Rows.Count = 0 Then
                        '    CType(grid.FindControl("txtResult"), TextBox).Text = ""
                        'Else
                        '    Grade = dt1.Rows(0).Item("Grade").ToString
                        '    CType(grid.FindControl("txtResult"), TextBox).Text = Grade
                        'End If
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
        'End If
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click

        LinkButton1.Focus()
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
    Protected Sub GVStdAttd_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GVStdAttd.RowDataBound
        ' ''For i As Integer = 0 To GVStdAttd.Columns.Count - 1
        ' ''    Dim row As GridView = GVStdAttd.Columns(i)
        ' ''    If GVStdAttd.Columns(i).Text = "" Then
        ' ''        'If CType(row.FindControl("i"), Label).Text = "" Then
        ' ''        'row.Cells(i).Visible = True
        ' ''        GVStdAttd.Columns(i).Visible = False
        ' ''    End If
        ' ''Next
        'Dim dataExist As New Hashtable
        'For Each row As GridViewRow In GVStdAttd.Rows
        '    For i As Integer = 0 To GVStdAttd.Columns.Count - 1
        '        If row.Cells(i).Text <> "" Then 'for a column if there is data we will mark it in the hashtable 
        '            dataExist(i) = True
        '        End If
        '    Next
        'Next
        'Dim i As New Integer
        'For Each i As GridView In GVStdAttd.Columns
        '    If CType(i.FindControl("lblsub5"), Label).Text = "" Then
        '        CType(i.FindControl("lblsub5"), Label).Visible = False
        '        GVStdAttd.Columns.[i].Visible = False
        '        GVStdAttd.DataBind()
        '    Else
        '        lblmsg.Text = ""
        '        msginfo.Text = "No records to display."
        '    End If
        'Next
        Dim i, s As New Integer
        For Each grid As GridViewRow In GVStdAttd.Rows
            i = CType(grid.FindControl("HidCount"), HiddenField).Value

        Next
        s = (i * 3) + 7
        Dim t As Integer = s - 7
        Dim col As Integer = 36
        While (col > s)
            GVStdAttd.Columns(col + 1).Visible = False
            col = col - 1
        End While
        While (t > 0)
            GVStdAttd.Columns(t - 1).Visible = True
            'GVStdAttd.Columns(22).Visible = True
            'GVStdAttd.Columns(23).Visible = True
            'GVStdAttd.Columns(24).Visible = True
            'GVStdAttd.Columns(25).Visible = True
            t = t - 1
        End While
        GVStdAttd.Columns(32).Visible = True
        GVStdAttd.Columns(33).Visible = True
        GVStdAttd.Columns(34).Visible = True
        GVStdAttd.Columns(35).Visible = True
        GVStdAttd.Columns(36).Visible = True
        GVStdAttd.Columns(37).Visible = True
        'dt1 = bl.Subject(EL.batchId, EL.sem)
        'GVStdAttd.H()
        'GVStdAttd.Columns(col).Visible = False
    End Sub
    'Protected Sub GVStdAttd_RowDataBound(ByVal sender As Object, ByVal e As GridViewRowEventArgs)
    '    'Check whether gridview is in edit mode or nor 
    '    If GVStdAttd.EditIndex >= 0 Then
    '        Return
    '    End If
    '    'Check row state of gridview whether it is data row or not
    '    If (e.Row.RowState = DataControlRowState.Normal OrElse e.Row.RowState = DataControlRowState.Alternate) AndAlso (e.Row.RowType = DataControlRowType.DataRow OrElse e.Row.RowType = DataControlRowType.Header) Then
    '        'Now set the visibility of cell we want to hide to false 
    '        e.Row.Cells(10).Visible = False
    '    End If
    'End Sub
    Protected Sub GVStdAttd_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        GVStdAttd.EditIndex = e.NewEditIndex
        GVStdAttd.DataBind()
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            Dim a As New Double
            If (Session("BranchCode") = Session("ParentBranch")) Then
                msginfo.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                EL.batchId = DdlBatch.SelectedValue
                EL.Assesmentid = ddlassesment.SelectedValue
                EL.sem = cmbSemester.SelectedValue
                EL.sem1 = ddlSem2.SelectedValue
                If EL.batchId = 0 And EL.Assesmentid = 0 And EL.sem = 0 And GVStdAttd.Visible = False Then
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1206)
                    Exit Sub
                End If
                dt = bl.DuplicateSemResult(EL)
                If dt.Rows.Count <> 0 Then
                    'If dt.Rows.Count = 0 Then
                    'For Each grid As GridViewRow In GVStdAttd.Rows
                    '    EL.StdId  CType(grid.FindControl("HidStdId"), HiddenField).Value
                    '    EL.batchId = CType(grid.FindControl("HidBatch"), HiddenField).Value
                    '    EL.sem = CType(grid.FindControl("HidSEmid"), HiddenField).Value
                    '    EL.Assesmentid = CType(grid.FindControl("HidAssesmentId"), HiddenField).Value
                    '    EL.Result = CType(grid.FindControl("txtResult"), TextBox).Text
                    '    bl.UpdateMarks(EL)
                    'Next
                    'Else
                    For Each grid As GridViewRow In GVStdAttd.Rows
                        If CType(grid.FindControl("lblcredit1"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit1"), Label).Text = 0
                        Else
                            C1 = CType(grid.FindControl("lblcredit1"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit2"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit2"), Label).Text = 0
                        Else
                            C2 = CType(grid.FindControl("lblcredit2"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit3"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit3"), Label).Text = 0
                        Else
                            C3 = CType(grid.FindControl("lblcredit3"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit4"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit4"), Label).Text = 0
                        Else
                            C4 = CType(grid.FindControl("lblcredit4"), Label).Text
                        End If

                        If CType(grid.FindControl("lblcredit5"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit5"), Label).Text = 0
                        Else
                            C5 = CType(grid.FindControl("lblcredit5"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit6"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit6"), Label).Text = 0
                        Else
                            C6 = CType(grid.FindControl("lblcredit6"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit7"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit7"), Label).Text = 0
                        Else
                            C7 = CType(grid.FindControl("lblcredit7"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit8"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit8"), Label).Text = 0
                        Else
                            C8 = CType(grid.FindControl("lblcredit8"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit9"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit9"), Label).Text = 0
                        Else
                            C9 = CType(grid.FindControl("lblcredit9"), Label).Text
                        End If
                        If CType(grid.FindControl("lblcredit10"), Label).Text = "" Then
                            CType(grid.FindControl("lblcredit10"), Label).Text = 0
                        Else
                            C10 = CType(grid.FindControl("lblcredit10"), Label).Text
                        End If
                        EL.CreditTotal = ((C1) + (C2) + (C3) + (C4) + (C5) + (C6) + (C7) + (C8) + (C9) + (C10))

                        IIf(CType(grid.FindControl("txtTotalMarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtTotalMarks"), TextBox).Text)
                        EL.batchId = IIf(CType(grid.FindControl("HidBatch"), HiddenField).Value = "", 0, CType(grid.FindControl("HidBatch"), HiddenField).Value)
                        EL.StdId = IIf(CType(grid.FindControl("HidStdId"), HiddenField).Value = "", 0, CType(grid.FindControl("HidStdId"), HiddenField).Value)
                        EL.sem = IIf(CType(grid.FindControl("HidSEmid"), HiddenField).Value = "", 0, CType(grid.FindControl("HidSEmid"), HiddenField).Value)
                        EL.Assesmentid = IIf(CType(grid.FindControl("HidAssesmentId"), HiddenField).Value = "", 0, CType(grid.FindControl("HidAssesmentId"), HiddenField).Value)
                        EL.Result = CType(grid.FindControl("txtPercentage"), TextBox).Text
                        EL.TotalMarks = IIf(CType(grid.FindControl("txtTotalMarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtTotalMarks"), TextBox).Text)
                        EL.Division = CType(grid.FindControl("txtResult"), TextBox).Text
                        EL.Rank = CType(grid.FindControl("txtRank"), TextBox).Text
                        EL.CGPA = CType(grid.FindControl("lblcgpa"), TextBox).Text
                        EL.MaxMarks = CType(grid.FindControl("txtMaxMarks"), TextBox).Text
                        If CType(grid.FindControl("lblcgpa1"), TextBox).Text = "" Then
                            EL.CGPA1 = 0
                        Else
                            EL.CGPA1 = CType(grid.FindControl("lblcgpa1"), TextBox).Text
                        End If
                        If CType(grid.FindControl("txtDivision"), TextBox).Text = "" Then
                            EL.Grade = 0
                        Else
                            EL.Grade = CType(grid.FindControl("txtDivision"), TextBox).Text
                        End If
                        EL.TotalMarkswithGrace = IIf(CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text = "", 0, CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text)
                        a = (CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text / CType(grid.FindControl("txtMaxMarks"), TextBox).Text) * 100
                        CType(grid.FindControl("txtPercentage"), TextBox).Text = Format(a, "0.00")
                        Dim Course As Integer
                        EL.batchId = DdlBatch.SelectedValue
                        EL.sem = cmbSemester.SelectedValue
                        EL.Assesmentid = ddlassesment.SelectedValue
                        'EL.Batch_No = DdlBatchPlanner.SelectedValue
                        'EL.id = EL.Batch_No
                        ViewState("V") = EL.batchId
                        dt1 = DLGradePointResult.filltextbox(EL)
                        Course = dt1.Rows(0).Item("Courseid")
                        dt2 = bl.SearchCourse(Course)
                        If dt2.Rows(0).Item("GMID") = 0 Then
                            Course = 0
                        Else
                            Course = dt1.Rows(0).Item("Courseid")
                        End If
                        dt1 = bl.UpdateGrade(a, Course)
                        If dt1.Rows.Count = 0 Then
                            CType(grid.FindControl("txtResult"), TextBox).Text = ""
                        Else
                            EL.Division = dt1.Rows(0).Item("Grade").ToString
                            CType(grid.FindControl("txtResult"), TextBox).Text = EL.Division
                        End If

                        bl.UpdateResult(EL)
                    Next

                    lblmsg.Text = ValidationMessage(1017)
                    GVStdAttd.Visible = True
                    msginfo.Text = ValidationMessage(1014)
                Else
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1207)
                End If
            Else
                msginfo.Text = ValidationMessage(1194)
                lblmsg.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1022)
            lblmsg.Text = ValidationMessage(1014)
        End Try
    End Sub

    'protected sub GVStdAttd_DataBound(object sender, EventArgs e)
    '    {
    '        GridView gridView = (GridView)sender;
    '        GridViewRowCollection growArr = (GridViewRowCollection)gridView.Rows;

    '        foreach (GridViewRow row in growArr)
    '        {
    '            row.Cells[2].Visible = false;
    '            row.Cells[3].Visible = false;
    '            row.Cells[4].Visible = false;
    '        }

    '    }
    'End Sub


    Protected Sub DdlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlBatch.SelectedIndexChanged
        GVStdAttd.Visible = False
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        Gridsubject.Visible = False
    End Sub

    Protected Sub btnFillTotal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFillTotal.Click
        Try
            Dim Str, subjectlist As String
            Str = ""
            subjectlist = ""
            Dim ID As String = ""
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            EL.batchId = DdlBatch.SelectedValue
            EL.sem = ddlsemNew.SelectedValue
            EL.Assesmentid = ddlassesment.SelectedValue
            For Each grid As GridViewRow In Gridsubject.Rows
                If CType(grid.FindControl("ChkPresent"), CheckBox).Checked = True Then
                    If CType(grid.FindControl("Label1"), HiddenField).Value <> 0 Then
                        Str = CType(grid.FindControl("Label1"), HiddenField).Value
                        ID = Str + "," + ID
                    End If
                End If
            Next
            If ID = "0" Then
                msginfo.Text = ValidationMessage(1205)
                lblmsg.Text = ValidationMessage(1014)
            Else
                ID = Left(ID, ID.Length - 1)
                EL.Subject = ID
                dt = bl.GetTotalCredit(EL.batchId, EL.sem, EL.Subject)
            End If
            If dt.Rows(0).Item("Credit").ToString() = "" Then
                EL.Credit = 0
            Else
                EL.Credit = dt.Rows(0).Item("Credit").ToString()
            End If

            Dim A, b, c As New Double
            'For Each grid As GridViewRow In GVStdAttd.Rows
            '    EL.StdId = IIf(CType(grid.FindControl("HidStdId"), HiddenField).Value = "", 0, CType(grid.FindControl("HidStdId"), HiddenField).Value)
            '    dt = bl.SelectTotalMarks(EL.batchId, EL.sem, EL.StdId, EL.Assesmentid)
            '    If dt.Rows(0).Item("TotalMarks").ToString = "" Then
            '        CType(grid.FindControl("txtTotalMarks"), TextBox).Text = 0
            '    Else
            '        CType(grid.FindControl("txtTotalMarks"), TextBox).Text = dt.Rows(0).Item("TotalMarks").ToString
            '    End If
            '    If dt.Rows(0).Item("MaxMarks").ToString = "" Then
            '        CType(grid.FindControl("txtMaxMarks"), TextBox).Text = 0
            '    Else
            '        CType(grid.FindControl("txtMaxMarks"), TextBox).Text = dt.Rows(0).Item("MaxMarks").ToString
            '    End If
            '    If dt.Rows(0).Item("TotalMarks").ToString = "" Then
            '        CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text = 0
            '    Else
            '        CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text = dt.Rows(0).Item("TotalMarks").ToString
            '    End If
            '    A = (CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text / CType(grid.FindControl("txtMaxMarks"), TextBox).Text) * 100
            '    CType(grid.FindControl("txtPercentage"), TextBox).Text = Format(A, "0.00")
            '    dt1 = bl.UpdateGrade(A)
            '    If dt1.Rows.Count = 0 Then
            '        CType(grid.FindControl("txtResult"), Label).Text = ""
            '    Else
            '        Grade = dt1.Rows(0).Item("Grade").ToString
            '        CType(grid.FindControl("txtResult"), TextBox).Text = Grade
            '    End If
            'Next
            'Else
            'lblmsg.Text = ""
            'msginfo.Text = "No Records To Fill Total."
            'End If
            For Each grid As GridViewRow In GVStdAttd.Rows
                StdId = CType(grid.FindControl("HidStdId"), HiddenField).Value
                If CType(grid.FindControl("lblsub12"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub12"), Label).Text = 0
                Else
                    M1 = CType(grid.FindControl("lblsub12"), Label).Text
                End If
                If CType(grid.FindControl("lblsub"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub"), Label).Text = 0
                Else
                    M2 = CType(grid.FindControl("lblsub"), Label).Text
                End If
                If CType(grid.FindControl("lblsub1"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub1"), Label).Text = 0
                Else
                    M3 = CType(grid.FindControl("lblsub1"), Label).Text
                End If
                If CType(grid.FindControl("lblsub2"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub2"), Label).Text = 0
                Else
                    M4 = CType(grid.FindControl("lblsub2"), Label).Text
                End If

                If CType(grid.FindControl("lblsub3"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub3"), Label).Text = 0
                Else
                    M5 = CType(grid.FindControl("lblsub3"), Label).Text
                End If
                If CType(grid.FindControl("lblsub4"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub4"), Label).Text = 0
                Else
                    M6 = CType(grid.FindControl("lblsub4"), Label).Text
                End If
                If CType(grid.FindControl("lblsub5"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub5"), Label).Text = 0
                Else
                    M7 = CType(grid.FindControl("lblsub5"), Label).Text
                End If
                If CType(grid.FindControl("lblsub6"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub6"), Label).Text = 0
                Else
                    M8 = CType(grid.FindControl("lblsub6"), Label).Text
                End If
                If CType(grid.FindControl("lblsub7"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub7"), Label).Text = 0
                Else
                    M9 = CType(grid.FindControl("lblsub7"), Label).Text
                End If
                If CType(grid.FindControl("lblsub8"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub8"), Label).Text = 0
                Else
                    M10 = CType(grid.FindControl("lblsub8"), Label).Text
                End If

                If CType(grid.FindControl("lblMax12"), Label).Text = "" Then
                    CType(grid.FindControl("lblMax12"), Label).Text = 0
                Else
                    P1 = CType(grid.FindControl("lblMax12"), Label).Text
                End If
                If CType(grid.FindControl("lblMax1"), Label).Text = "" Then
                    CType(grid.FindControl("lblMax1"), Label).Text = 0
                Else
                    P2 = CType(grid.FindControl("lblMax1"), Label).Text
                End If
                If CType(grid.FindControl("lblMax2"), Label).Text = "" Then
                    CType(grid.FindControl("lblMax2"), Label).Text = 0
                Else
                    P3 = CType(grid.FindControl("lblMax2"), Label).Text
                End If
                If CType(grid.FindControl("lblMax3"), Label).Text = "" Then
                    CType(grid.FindControl("lblMax3"), Label).Text = 0
                Else
                    P4 = CType(grid.FindControl("lblMax3"), Label).Text
                End If

                If CType(grid.FindControl("lblMax4"), Label).Text = "" Then
                    CType(grid.FindControl("lblMax4"), Label).Text = 0
                Else
                    P5 = CType(grid.FindControl("lblMax4"), Label).Text
                End If
                If CType(grid.FindControl("lblMax5"), Label).Text = "" Then
                    CType(grid.FindControl("lblMax5"), Label).Text = 0
                Else
                    P6 = CType(grid.FindControl("lblMax5"), Label).Text
                End If
                If CType(grid.FindControl("lblMax6"), Label).Text = "" Then
                    CType(grid.FindControl("lblMax6"), Label).Text = 0
                Else
                    P7 = CType(grid.FindControl("lblsub6"), Label).Text
                End If
                If CType(grid.FindControl("lblMax7"), Label).Text = "" Then
                    CType(grid.FindControl("lblMax7"), Label).Text = 0
                Else
                    P8 = CType(grid.FindControl("lblMax7"), Label).Text
                End If
                If CType(grid.FindControl("lblMax8"), Label).Text = "" Then
                    CType(grid.FindControl("lblMax8"), Label).Text = 0
                Else
                    P9 = CType(grid.FindControl("lblMax8"), Label).Text
                End If
                If CType(grid.FindControl("lblMax9"), Label).Text = "" Then
                    CType(grid.FindControl("lblMax9"), Label).Text = 0
                Else
                    P10 = CType(grid.FindControl("lblMax9"), Label).Text
                End If
                'If CType(grid.FindControl("lblMax10"), Label).Text = "" Then
                '    CType(grid.FindControl("lblMax10"), Label).Text = 0
                'Else
                '    P11 = CType(grid.FindControl("lblMax10"), Label).Text
                'End If
                'If CType(grid.FindControl("lblMax11"), Label).Text = "" Then
                '    CType(grid.FindControl("lblMax11"), Label).Text = 0
                'Else
                '    P12 = CType(grid.FindControl("lblMax11"), Label).Text
                'End If
                If CType(grid.FindControl("lblM1"), Label).Text = "" Then
                    CType(grid.FindControl("lblM1"), Label).Text = 0
                Else
                    Ma1 = CType(grid.FindControl("lblM1"), Label).Text
                End If
                If CType(grid.FindControl("lblM2"), Label).Text = "" Then
                    CType(grid.FindControl("lblM2"), Label).Text = 0
                Else
                    Ma2 = CType(grid.FindControl("lblM2"), Label).Text
                End If
                If CType(grid.FindControl("lblM3"), Label).Text = "" Then
                    CType(grid.FindControl("lblM3"), Label).Text = 0
                Else
                    Ma3 = CType(grid.FindControl("lblM3"), Label).Text
                End If
                If CType(grid.FindControl("lblM4"), Label).Text = "" Then
                    CType(grid.FindControl("lblM4"), Label).Text = 0
                Else
                    Ma4 = CType(grid.FindControl("lblM4"), Label).Text
                End If

                If CType(grid.FindControl("lblM5"), Label).Text = "" Then
                    CType(grid.FindControl("lblM5"), Label).Text = 0
                Else
                    Ma5 = CType(grid.FindControl("lblM5"), Label).Text
                End If
                If CType(grid.FindControl("lblM6"), Label).Text = "" Then
                    CType(grid.FindControl("lblM6"), Label).Text = 0
                Else
                    Ma6 = CType(grid.FindControl("lblM6"), Label).Text
                End If
                If CType(grid.FindControl("lblM7"), Label).Text = "" Then
                    CType(grid.FindControl("lblM7"), Label).Text = 0
                Else
                    Ma7 = CType(grid.FindControl("lblM7"), Label).Text
                End If
                If CType(grid.FindControl("lblM8"), Label).Text = "" Then
                    CType(grid.FindControl("lblM8"), Label).Text = 0
                Else
                    Ma8 = CType(grid.FindControl("lblM8"), Label).Text
                End If
                If CType(grid.FindControl("lblM9"), Label).Text = "" Then
                    CType(grid.FindControl("lblM9"), Label).Text = 0
                Else
                    Ma9 = CType(grid.FindControl("lblM9"), Label).Text
                End If
                If CType(grid.FindControl("lblM10"), Label).Text = "" Then
                    CType(grid.FindControl("lblM10"), Label).Text = 0
                Else
                    Ma10 = CType(grid.FindControl("lblM10"), Label).Text
                End If
                If CType(grid.FindControl("lblcredit1"), Label).Text = "" Then
                    CType(grid.FindControl("lblcredit1"), Label).Text = 0
                Else
                    C1 = CType(grid.FindControl("lblcredit1"), Label).Text
                End If
                If CType(grid.FindControl("lblcredit2"), Label).Text = "" Then
                    CType(grid.FindControl("lblcredit2"), Label).Text = 0
                Else
                    C2 = CType(grid.FindControl("lblcredit2"), Label).Text
                End If
                If CType(grid.FindControl("lblcredit3"), Label).Text = "" Then
                    CType(grid.FindControl("lblcredit3"), Label).Text = 0
                Else
                    C3 = CType(grid.FindControl("lblcredit3"), Label).Text
                End If
                If CType(grid.FindControl("lblcredit4"), Label).Text = "" Then
                    CType(grid.FindControl("lblcredit4"), Label).Text = 0
                Else
                    C4 = CType(grid.FindControl("lblcredit4"), Label).Text
                End If

                If CType(grid.FindControl("lblcredit5"), Label).Text = "" Then
                    CType(grid.FindControl("lblcredit5"), Label).Text = 0
                Else
                    C5 = CType(grid.FindControl("lblcredit5"), Label).Text
                End If
                If CType(grid.FindControl("lblcredit6"), Label).Text = "" Then
                    CType(grid.FindControl("lblcredit6"), Label).Text = 0
                Else
                    C6 = CType(grid.FindControl("lblcredit6"), Label).Text
                End If
                If CType(grid.FindControl("lblcredit7"), Label).Text = "" Then
                    CType(grid.FindControl("lblcredit7"), Label).Text = 0
                Else
                    C7 = CType(grid.FindControl("lblcredit7"), Label).Text
                End If
                If CType(grid.FindControl("lblcredit8"), Label).Text = "" Then
                    CType(grid.FindControl("lblcredit8"), Label).Text = 0
                Else
                    C8 = CType(grid.FindControl("lblcredit8"), Label).Text
                End If
                If CType(grid.FindControl("lblcredit9"), Label).Text = "" Then
                    CType(grid.FindControl("lblcredit9"), Label).Text = 0
                Else
                    C9 = CType(grid.FindControl("lblcredit9"), Label).Text
                End If
                If CType(grid.FindControl("lblcredit10"), Label).Text = "" Then
                    CType(grid.FindControl("lblcredit10"), Label).Text = 0
                Else
                    C10 = CType(grid.FindControl("lblcredit10"), Label).Text
                End If
                EL.TotalMarks = (Ma1 + Ma2 + Ma3 + Ma4 + Ma5 + Ma6 + Ma7 + Ma8 + Ma9 + Ma10)
                CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text = EL.TotalMarks

                EL.CGPA = ((M1 * C1) + (M2 * C2) + (M3 * C3) + (M4 * C4) + (M5 * C5) + (M6 * C6) + (M7 * C7) + (M8 * C8) + (M9 * C9) + (M10 * C10)) / EL.Credit
                If Format(EL.CGPA, "0.00") = "NaN" Then

                    CType(grid.FindControl("lblcgpa"), TextBox).Text = ""
                Else
                    CType(grid.FindControl("lblcgpa"), TextBox).Text = Format(EL.CGPA, "0.00")
                End If
                CType(grid.FindControl("txtTotalMarks"), TextBox).Text = EL.TotalMarks
                CType(grid.FindControl("txtMaxMarks"), TextBox).Text = (P1 + P2 + P3 + P4 + P5 + P6 + P7 + P8 + P9 + P10)
                A = ((CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text / CType(grid.FindControl("txtMaxMarks"), TextBox).Text)) * 100
                CType(grid.FindControl("txtPercentage"), TextBox).Text = Format(A, "0.00")
                If A < 0 Then
                    A = 0
                End If
                Dim Course As Integer
                EL.batchId = DdlBatch.SelectedValue
                EL.sem = ddlsemNew.SelectedValue
                EL.Assesmentid = ddlassesment.SelectedValue
                'EL.Batch_No = DdlBatchPlanner.SelectedValue
                'EL.id = EL.Batch_No
                ViewState("V") = EL.batchId
                dt1 = DLGradePointResult.filltextbox(EL)
                Course = dt1.Rows(0).Item("Courseid")
                dt2 = bl.SearchCourse(Course)
                If dt2.Rows(0).Item("GMID") = 0 Then
                    Course = 0
                Else
                    Course = dt1.Rows(0).Item("Courseid")
                End If
                dt1 = bl.UpdateGrade(A, Course)
                If dt1.Rows.Count = 0 Then
                    CType(grid.FindControl("txtResult"), TextBox).Text = ""
                Else
                    Grade = dt1.Rows(0).Item("Grade").ToString
                    CType(grid.FindControl("txtResult"), TextBox).Text = Grade
                End If
            Next
            lblmsg.Text = ValidationMessage(1187)
            msginfo.Text = ValidationMessage(1014)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            'Control_Text_Multilingual()
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub ddlsemNew_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsemNew.SelectedIndexChanged
        Gridsubject.DataSourceID = "ObjSubject"
        Gridsubject.DataBind()
        'Gridsubject.Rows(0).Visible = False
        Gridsubject.Visible = True
        GVStdAttd.Visible = False
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
    End Sub

    Protected Sub ddlassesment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassesment.SelectedIndexChanged
        GVStdAttd.Visible = False
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
    End Sub

    Protected Sub btncgpa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncgpa.Click
        Try

        
            If cmbSemester.SelectedValue = 0 And ddlSem2.SelectedValue = 0 Then
                msginfo.Text = ValidationMessage(1208)
                lblmsg.Text = ValidationMessage(1014)
                Exit Sub
            End If
            Dim Str As String = ""
            Dim ID As String = ""
            EL.sem = cmbSemester.SelectedValue
            EL.sem1 = ddlSem2.SelectedValue
            EL.batchId = DdlBatch.SelectedValue
            dt = bl.getsem(EL)
            Dim Course As Integer
            EL.Assesmentid = ddlassesment.SelectedValue
            'EL.Batch_No = DdlBatchPlanner.SelectedValue
            'EL.id = EL.Batch_No
            ViewState("V") = EL.batchId
            dt1 = DLGradePointResult.filltextbox(EL)
            Course = dt1.Rows(0).Item("Courseid")
            dt2 = bl.SearchCourse(Course)
            If dt2.Rows(0).Item("GMID") = 0 Then
                Course = 0
            Else
                Course = dt1.Rows(0).Item("Courseid")
            End If
            GVSemResult.DataSource = dt
            GVSemResult.DataBind()
            For Each grid As GridViewRow In GVSemResult.Rows
                Str = CType(grid.FindControl("Label1"), HiddenField).Value
                ID = Str + "," + ID
            Next
            EL.semester = ID
            For Each grid As GridViewRow In GVStdAttd.Rows
                EL.StdId = CType(grid.FindControl("HidStdId"), HiddenField).Value
                dt1 = DLGradePointResult.CGPA(EL)
                GVCredit.DataSource = dt1
                GVCredit.DataBind()
                Dim i, j, count, MUl, Sum, FinalCGPA, Division As Double
                Dim Div As String
                i = 0
                j = 0
                count = 0
                MUl = 0
                Sum = 0
                FinalCGPA = 0
                Division = 0
                count = dt1.Rows.Count
                While count > 0
                    i = dt1.Rows(count - 1).Item("CGPA").ToString * dt1.Rows(count - 1).Item("Credit").ToString
                    j = dt1.Rows(count - 1).Item("Credit").ToString
                    MUl = MUl + i
                    Sum = Sum + j
                    count = count - 1
                End While
                FinalCGPA = MUl / Sum
                CType(grid.FindControl("lblcgpa1"), TextBox).Text = Format(FinalCGPA, "0.00")
                Division = Format(FinalCGPA, "0.00")
                dtdiv = bl.UpdateDivision(Division, Course)
                If dtdiv.Rows.Count = 0 Then
                    CType(grid.FindControl("txtDivision"), TextBox).Text = ""
                Else
                    Div = dtdiv.Rows(0).Item("Division").ToString
                    CType(grid.FindControl("txtDivision"), TextBox).Text = Div
                End If
            Next
            lblmsg.Text = ValidationMessage(1187)
            msginfo.Text = ValidationMessage(1014)
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlSem2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSem2.SelectedIndexChanged
        Dim Str As String = ""
        Dim ID As String = ""
        EL.sem = cmbSemester.SelectedValue
        EL.sem1 = ddlSem2.SelectedValue
        EL.batchId = DdlBatch.SelectedValue
        dt = bl.getsem(EL)
        GVSemResult.DataSource = dt
        GVSemResult.DataBind()
        For Each grid As GridViewRow In GVSemResult.Rows
            Str = CType(grid.FindControl("Label1"), HiddenField).Value
            ID = Str + "," + ID
        Next
        EL.semester = ID
        
    End Sub
    'Code written fro multilingual by Niraj on 24 Dec 2013
    ''Retriving the text of controls based on Language

    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        Try
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
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub

End Class
