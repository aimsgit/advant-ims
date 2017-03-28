
Partial Class FrmMapStdExamCenter
    Inherits BasePage
    Dim DLMapStd As DLExamHallTicket
    Dim Dt, Dt1, Dt2, StdCount As DataTable
    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim ExamBatchId, RecordCount As Integer
        ExamBatchId = ddlExamBatch.SelectedValue

        If ddlExamBatch.SelectedItem.Text = "Select" Then
            lblMsg.Visible = True
            lblErrorMsg.Visible = False
            lblMsg.Text = "Please select the Exam Batch to generate reocrds."
        Else
            Dt1 = DLExamHallTicket.CheckGenerateStatus(ExamBatchId)
            RecordCount = Dt1.Rows(0).Item("RecordCount").ToString
            If RecordCount > 0 Then
                lblMsg.Visible = False
                lblErrorMsg.Visible = True
                lblErrorMsg.Text = "Records already generated for " + ddlExamBatch.SelectedItem.Text
                GridView1.Visible = False
            Else

                DLExamHallTicket.InsertMapStudentExamCenter(ExamBatchId)
                lblMsg.Visible = True
                lblErrorMsg.Visible = False
                lblMsg.Text = "Records generated successfully."
                txtCountofStd.Text = RecordCount
                DisplayGrid()
            End If

        End If


    End Sub

    Protected Sub btnMap_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnMap.Click
        Dim ExamBatchId, GridRowId As Integer
        Dim ExamCenter, StdCenter As String
        Dim Count1 As Integer = 0
        ExamBatchId = ddlExamBatch.SelectedValue
        StdCenter = ddlStudentCenter.SelectedValue
        ExamCenter = ddlExamCenter.SelectedValue

        If ddlExamBatch.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select Exam Batch to map students."
        ElseIf ddlStudentCenter.SelectedItem.Text = "Select" Or ddlExamCenter.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select Std Center and Exam Center to map students."

        Else

            For Each Grid As GridViewRow In GridView1.Rows
                If CType(Grid.FindControl("ChkSelect"), CheckBox).Checked = True Then
                    Count1 = Count1 + 1
                End If
            Next

            For Each Grid As GridViewRow In GridView1.Rows
                If CType(Grid.FindControl("ChkSelect"), CheckBox).Checked = True Then
                    GridRowId = CType(Grid.FindControl("lblADId"), HiddenField).Value

                    DLExamHallTicket.MapStudentExamCenter(ExamBatchId, StdCenter, ExamCenter, GridRowId)
                    lblMsg.Visible = True
                    lblErrorMsg.Visible = False

                    DisplayGrid()
                    lblMsg.Text = "Mapped to Exam Center successfully."
                ElseIf Count1 = 0 Then
                    lblMsg.Visible = False
                    lblErrorMsg.Visible = True
                    lblErrorMsg.Text = "Please select the records to Map Exam Center."
                End If

            Next

        End If

        'If ddlStudentCenter.SelectedItem.Text = "Select" Or ddlExamCenter.SelectedItem.Text = "Select" Then
        '    lblMsg.Visible = True
        '    lblErrorMsg.Visible = False
        '    lblMsg.Text = "Please select Std Center and Exam Center to map students."

        'Else
        '    DLExamHallTicket.MapStudentExamCenter(ExamBatchId, StdCenter, ExamCenter)
        '    lblMsg.Visible = True
        '    lblErrorMsg.Visible = False
        '    lblMsg.Text = "Mapped to Exam Center successfully."
        '    DisplayGrid()

        'End If


    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim ExamBatchId, HallTicketCount As Integer
        Dim StdCenter As String
        ExamBatchId = ddlExamBatch.SelectedValue
        StdCenter = ddlStudentCenter.SelectedValue

        Dt2 = DLExamHallTicket.CheckStdMapLockStatus(ExamBatchId)
        If Dt2.Rows.Count > 0 Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please unlock the records to Clear"
        Else


            If ddlExamBatch.SelectedItem.Text = "Select" Or ddlStudentCenter.SelectedItem.Text = "Select" Then
                lblMsg.Visible = False
                lblErrorMsg.Visible = True
                lblErrorMsg.Text = "Please select the Batch and Student Center to clear records."
            Else
                Dt2 = DLExamHallTicket.CheckHallTicketGenerationStatus(ExamBatchId, StdCenter)

                HallTicketCount = Dt2.Rows(0).Item("HallTicketCount").ToString
                If HallTicketCount > 0 Then
                    lblMsg.Visible = False
                    lblErrorMsg.Visible = True
                    lblErrorMsg.Text = "Hall Ticket No alrady generated so records cannot be cleared. First Clear from Generate Hall Ticket No"
                    GridView1.Visible = False
                Else
                    DLExamHallTicket.ClearMapStudentExamCenter(ExamBatchId, StdCenter)
                    lblMsg.Visible = True
                    lblErrorMsg.Visible = False
                    lblMsg.Text = "Records cleared successfully."
                    GridView1.Visible = False
                End If
            End If
        End If

    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        DisplayGrid()

    End Sub
    Sub DisplayGrid()
        Dim ExamBatchId As Integer
        Dim StdCenter, ExamCenter, StdCode, StdName As String
        ExamBatchId = ddlExamBatch.SelectedValue
        StdCenter = ddlStudentCenter.SelectedValue
        ExamCenter = ddlExamCenter.SelectedValue
        If txtStdCode.Text = "" Then
            StdCode = 0
        Else
            StdCode = txtStdCode.Text
        End If

        If txtStdName.Text = "" Then
            StdName = 0
        Else
            StdName = txtStdName.Text
        End If


        Dt = DLExamHallTicket.GridViewMapStdExamCenter(ExamBatchId, StdCenter, ExamCenter, StdCode, StdName)
        If Dt.Rows.Count > 0 Then
            lblMsg.Text = ""
            lblErrorMsg.Text = ""
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataSource = Dt
            GridView1.DataBind()
            txtCountofStd.Text = Dt.Rows.Count
            Dt2 = DLExamHallTicket.CheckStdMapLockStatus(ExamBatchId)
            If Dt2.Rows.Count > 0 Then
                GridView1.Enabled = False
            End If
        Else
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "No records to display."
            GridView1.Visible = False
            txtCountofStd.Text = 0

        End If
    End Sub
    Sub CheckAll()
        If CType(GridView1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            GridView1.Visible = True

            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = True
            Next
        Else
            GridView1.Visible = True


            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = False
            Next
        End If
       
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ExamBatchId, RecordCount As Integer
        If IsPostBack = True Then
            If ddlExamBatch.SelectedItem.Text = "Select" Then
                txtCountofStd.Text = 0
            Else
                ExamBatchId = ddlExamBatch.SelectedValue
                Dt1 = DLExamHallTicket.CheckGenerateStatus(ExamBatchId)
                RecordCount = Dt1.Rows(0).Item("RecordCount").ToString
                txtCountofStd.Text = RecordCount
            End If
        End If

    End Sub



    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        DisplayGrid()
    End Sub

    Protected Sub btnLock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLock.Click
        Dim ExamBatchId As Integer
        ExamBatchId = ddlExamBatch.SelectedValue

        If ddlExamBatch.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select the Exam Batch to Lock/Unlock the records."
        Else
            Dt2 = DLExamHallTicket.CountRecordsMapStdExamCenter(ExamBatchId)
            If Dt2.Rows.Count > 0 Then

                ControlsPanel.Visible = False
                PasswordPanel.Visible = True
                txtPassword.Focus()
                lblpassError.Text = ""
                Image1.Visible = False
                Image2.Visible = False
            Else
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                lblMsg.Visible = False
                lblErrorMsg.Visible = True
                lblErrorMsg.Text = "No Records to Lock/Unlock."
                Image1.Visible = True
                Image2.Visible = True

            End If
        End If
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Check As String
        If txtPassword.Text = Session("Password") Then
            Dim ExamBatchId As Integer
            ExamBatchId = ddlExamBatch.SelectedValue
            '1
            If DLExamHallTicket.RecordsMapStudent(ExamBatchId).Tables(0).Rows(0).Item(0) = "N" Then
                Dim roweffected As Integer = DLExamHallTicket.LockMapStdExamCenter(ExamBatchId)
                If roweffected > 0 Then
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    lblErrorMsg.Visible = False
                    lblMsg.Visible = True
                    lblMsg.Text = roweffected.ToString + " record(s) Locked."
                    GridView1.Enabled = False
                    Image1.Visible = True
                    Image2.Visible = True
                End If
                '1
            Else

                Dim role As String
                role = Session("UserRole")
                'Dim checkUnlock As String
                ' dt1 = DLNew_StudentMarks.CheckUnlockStatus(role)
                '2
                If Session("SecurityCheck") = "Security Check" Then

                    Dt = DLExamHallTicket.UnlockExam(role)
                    '3
                    If Dt.Rows.Count < 1 Then
                        lblErrorMsg.Visible = True
                        lblErrorMsg.Text = "You don't have Unlock Permission."
                        lblMsg.Visible = False
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        GridView1.Enabled = False
                        Image1.Visible = True
                        Image2.Visible = True
                    Else
                        Check = Dt.Rows(0)("Result").ToString.Trim

                        'check = dt.Rows(0)("Result").ToString.Trim
                        '4
                        If Check = "" Then
                            lblErrorMsg.Visible = True
                            lblErrorMsg.Text = "You don't have Unlock Permission."
                            lblMsg.Visible = False
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            GridView1.Enabled = False
                            Image1.Visible = True
                            Image2.Visible = True
                            '4
                        Else
                            Dim roweffected As Integer = DLExamHallTicket.UnLockMapStdExamCenter(ExamBatchId)
                            If roweffected > 0 Then
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                lblErrorMsg.Visible = False
                                lblMsg.Visible = True
                                lblMsg.Text = roweffected.ToString + " record(s) Unlocked."
                                GridView1.Enabled = True
                                Image1.Visible = True
                                Image2.Visible = True
                            End If
                            '4
                        End If
                        '3
                    End If
                    '2
                Else
                    Dim roweffected As Integer = DLExamHallTicket.UnLockMapStdExamCenter(ExamBatchId)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        lblErrorMsg.Visible = False
                        lblMsg.Visible = True
                        lblMsg.Text = roweffected.ToString + " record(s) Unlocked."
                        GridView1.Enabled = True
                        Image1.Visible = True
                        Image2.Visible = True
                    End If
                    '2
                End If
                '1
            End If
        ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
            ControlsPanel.Visible = True
            PasswordPanel.Visible = False
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Enter correct password."
            Image1.Visible = True
            Image2.Visible = True
            lblMsg.Text = ""
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
        Dim ExamBatchId As Integer
        Dim StdCenter, ExamCenter, StdCode, StdName As String
        ExamBatchId = ddlExamBatch.SelectedValue
        StdCenter = ddlStudentCenter.SelectedValue
        ExamCenter = ddlExamCenter.SelectedValue
        If txtStdCode.Text = "" Then
            StdCode = 0
        Else
            StdCode = txtStdCode.Text
        End If

        If txtStdName.Text = "" Then
            StdName = 0
        Else
            StdName = txtStdName.Text
        End If
        Dt = DLExamHallTicket.GridViewMapStdExamCenter(ExamBatchId, StdCenter, ExamCenter, StdCode, StdName)
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
       
        txtCountofStd.Text = Dt.Rows.Count
        Dt2 = DLExamHallTicket.CheckStdMapLockStatus(ExamBatchId)
        If Dt2.Rows.Count > 0 Then
            GridView1.Enabled = False
        End If
        Dim sortedView As New DataView(Dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.Visible = True
        'GridView1.DataSource = Dt
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
