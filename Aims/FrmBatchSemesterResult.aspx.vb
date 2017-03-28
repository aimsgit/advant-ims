Imports System.IO
Partial Class FrmBatchSemesterResult
    Inherits BasePage
    Dim EL As New ELBatchSemester
    Dim dt, dt1, dt2, dt3 As New DataTable
    Dim bl As New BLBatchSemester
    Dim BLGradePointResult As New BLGradePointResult
    Dim Grade As String
    Dim M1, M2, M3, M4, M5, M6, M7, M8, M9, M10, M11, M12, P1, P2, P3, P4, P5, P6, P7, P8, P9, P10, P11, P12, StdId, Per As New Double
    Sub DisplayGrid()
        Dim Str, subjectlist As String
        Str = ""
        subjectlist = ""
        Dim ID As String = ""
        'Dim Course As Integer
        EL.batchId = DdlBatch.SelectedValue
        EL.sem = cmbSemester.SelectedValue
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
            msginfo.Text = "Select atleast one Record."
            lblmsg.Text = ""
        Else
            ID = Left(ID, ID.Length - 1)
            EL.Subject = ID
            dt = bl.GetGridData1(EL.batchId, EL.sem, EL.Assesmentid, EL.Subject)
            If dt.Rows.Count = 0 Then
                lblmsg.Text = ""
                msginfo.Text = "No Records to display."
                GVStdAttd.Visible = False
            Else
                GVStdAttd.DataSource = dt
                GVStdAttd.DataBind()
                GVStdAttd.Visible = True
            End If
        End If
        'End If
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
       
        LinkButton1.Focus()
        lblmsg.Text = ""
        msginfo.Text = ""
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
        s = (i * 2) + 6
        Dim t As Integer = s - 6
        Dim col As Integer = 24
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
        GVStdAttd.Columns(22).Visible = True
        GVStdAttd.Columns(23).Visible = True
        GVStdAttd.Columns(24).Visible = True
        GVStdAttd.Columns(25).Visible = True
        GVStdAttd.Columns(26).Visible = True
        GVStdAttd.Columns(27).Visible = True
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
            Dim Course As Integer
            If (Session("BranchCode") = Session("ParentBranch")) Then
                msginfo.Text = ""
                lblmsg.Text = ""
                EL.batchId = DdlBatch.SelectedValue
                EL.Assesmentid = ddlassesment.SelectedValue
                EL.sem = cmbSemester.SelectedValue
                If EL.batchId = 0 And EL.Assesmentid = 0 And EL.sem = 0 And GVStdAttd.Visible = False Then
                    lblmsg.Text = ""
                    msginfo.Text = "Submit the records before update."
                    Exit Sub
                End If
                dt = bl.DuplicateSemResult(EL)
                If dt.Rows.Count <> 0 Then


                    'If dt.Rows.Count = 0 Then
                    'For Each grid As GridViewRow In GVStdAttd.Rows
                    '    EL.StdId = CType(grid.FindControl("HidStdId"), HiddenField).Value
                    '    EL.batchId = CType(grid.FindControl("HidBatch"), HiddenField).Value
                    '    EL.sem = CType(grid.FindControl("HidSEmid"), HiddenField).Value
                    '    EL.Assesmentid = CType(grid.FindControl("HidAssesmentId"), HiddenField).Value
                    '    EL.Result = CType(grid.FindControl("txtResult"), TextBox).Text
                    '    bl.UpdateMarks(EL)
                    'Next
                    'Else
                    For Each grid As GridViewRow In GVStdAttd.Rows
                        IIf(CType(grid.FindControl("txtTotalMarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtTotalMarks"), TextBox).Text)
                        EL.batchId = IIf(CType(grid.FindControl("HidBatch"), HiddenField).Value = "", 0, CType(grid.FindControl("HidBatch"), HiddenField).Value)
                        EL.StdId = IIf(CType(grid.FindControl("HidStdId"), HiddenField).Value = "", 0, CType(grid.FindControl("HidStdId"), HiddenField).Value)
                        EL.sem = IIf(CType(grid.FindControl("HidSEmid"), HiddenField).Value = "", 0, CType(grid.FindControl("HidSEmid"), HiddenField).Value)
                        EL.Assesmentid = IIf(CType(grid.FindControl("HidAssesmentId"), HiddenField).Value = "", 0, CType(grid.FindControl("HidAssesmentId"), HiddenField).Value)
                        EL.Result = CType(grid.FindControl("txtPercentage"), TextBox).Text
                        EL.TotalMarks = IIf(CType(grid.FindControl("txtTotalMarks"), TextBox).Text = "", 0, CType(grid.FindControl("txtTotalMarks"), TextBox).Text)
                        EL.Division = CType(grid.FindControl("txtResult"), TextBox).Text
                        EL.Rank = CType(grid.FindControl("txtRank"), TextBox).Text
                        EL.MaxMarks = CType(grid.FindControl("txtMaxMarks"), TextBox).Text
                        EL.TotalMarkswithGrace = IIf(CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text = "", 0, CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text)
                        a = (CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text / CType(grid.FindControl("txtMaxMarks"), TextBox).Text) * 100
                        CType(grid.FindControl("txtPercentage"), TextBox).Text = Format(a, "0.00")
                        dt1 = DLBatchSemester.filltextbox(EL)
                        Course = dt1.Rows(0).Item("Courseid")
                        dt2 = BLGradePointResult.SearchCourse(Course)
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
                    lblmsg.Text = "Data Updated Successfully."
                    GVStdAttd.Visible = True
                    msginfo.Text = ""
                Else
                    lblmsg.Text = ""
                    msginfo.Text = "Records are locked in Semester Result Table unlock before update."
                End If
            Else
                msginfo.Text = "You do not belong to this branch, Cannot update data."
                lblmsg.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = "Enter correct Data."
            lblmsg.Text = ""
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
        lblmsg.Text = ""
        msginfo.Text = ""
        Gridsubject.Visible = False
    End Sub

    Protected Sub btnFillTotal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnFillTotal.Click

        Try

            Dim Str, subjectlist As String
            Str = ""
            subjectlist = ""
            Dim ID As String = ""
            lblmsg.Text = ""
            msginfo.Text = ""
            EL.batchId = DdlBatch.SelectedValue
            EL.sem = cmbSemester.SelectedValue
            EL.Assesmentid = ddlassesment.SelectedValue
            Dim Course As Integer
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
                If CType(grid.FindControl("lblsub"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub"), Label).Text = 0
                Else
                    M1 = CType(grid.FindControl("lblsub"), Label).Text
                End If
                If CType(grid.FindControl("lblsub1"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub1"), Label).Text = 0
                Else
                    M2 = CType(grid.FindControl("lblsub1"), Label).Text
                End If
                If CType(grid.FindControl("lblsub2"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub2"), Label).Text = 0
                Else
                    M3 = CType(grid.FindControl("lblsub2"), Label).Text
                End If
                If CType(grid.FindControl("lblsub3"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub3"), Label).Text = 0
                Else
                    M4 = CType(grid.FindControl("lblsub3"), Label).Text
                End If

                If CType(grid.FindControl("lblsub4"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub4"), Label).Text = 0
                Else
                    M5 = CType(grid.FindControl("lblsub4"), Label).Text
                End If
                If CType(grid.FindControl("lblsub5"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub5"), Label).Text = 0
                Else
                    M6 = CType(grid.FindControl("lblsub5"), Label).Text
                End If
                If CType(grid.FindControl("lblsub6"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub6"), Label).Text = 0
                Else
                    M7 = CType(grid.FindControl("lblsub6"), Label).Text
                End If
                If CType(grid.FindControl("lblsub7"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub7"), Label).Text = 0
                Else
                    M8 = CType(grid.FindControl("lblsub7"), Label).Text
                End If
                If CType(grid.FindControl("lblsub8"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub8"), Label).Text = 0
                Else
                    M9 = CType(grid.FindControl("lblsub8"), Label).Text
                End If
                If CType(grid.FindControl("lblsub12"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub12"), Label).Text = 0
                Else
                    M10 = CType(grid.FindControl("lblsub12"), Label).Text
                End If
                If CType(grid.FindControl("lblsub8"), Label).Text = "" Then
                    CType(grid.FindControl("lblsub8"), Label).Text = 0
                Else
                    M11 = CType(grid.FindControl("lblsub8"), Label).Text
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
                EL.TotalMarks = Math.Round(M1 + M2 + M3 + M4 + M5 + M6 + M7 + M8 + M9 + M10 + M11 + M12)
                CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text = EL.TotalMarks
                CType(grid.FindControl("txtTotalMarks"), TextBox).Text = EL.TotalMarks
                CType(grid.FindControl("txtMaxMarks"), TextBox).Text = (P1 + P2 + P3 + P4 + P5 + P6 + P7 + P8 + P9 + P10 + P11 + P12)
                A = ((CType(grid.FindControl("txtMarkswithgrace"), TextBox).Text / CType(grid.FindControl("txtMaxMarks"), TextBox).Text)) * 100
                CType(grid.FindControl("txtPercentage"), TextBox).Text = Format(A, "0.00")
                If A < 0 Then
                    A = 0
                End If
                dt1 = DLBatchSemester.filltextbox(EL)
                Course = dt1.Rows(0).Item("Courseid")
                dt2 = BLGradePointResult.SearchCourse(Course)
                If dt2.Rows(0).Item("GMID") = 0 Then
                    Course = 0
                Else
                    Course = dt1.Rows(0).Item("Courseid")
                End If
                dt1 = bl.UpdateGrade(A, Course)
                If dt1.Rows.Count = 0 Then
                    CType(grid.FindControl("txtResult"), TextBox).Text = ""

                Else
                    EL.Division = dt1.Rows(0).Item("Grade").ToString
                    CType(grid.FindControl("txtResult"), TextBox).Text = EL.Division
                End If
            Next
            lblmsg.Text = "Results calculated successfully."
            msginfo.Text = ""
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub


    Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
        Gridsubject.DataSourceID = "ObjSubject"
        Gridsubject.DataBind()
        Gridsubject.Rows(0).Visible = False
        Gridsubject.Visible = True
        GVStdAttd.Visible = False
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub

    Protected Sub ddlassesment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassesment.SelectedIndexChanged
        GVStdAttd.Visible = False
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub
End Class
