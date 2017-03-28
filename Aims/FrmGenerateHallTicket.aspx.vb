
Partial Class FrmGenerateHallTicket
    Inherits BasePage
    Dim DLHallTicket As New DLGenerateHallTicket
    Dim Dt, Dt1, Dt2, StdCount As DataTable
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
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        'Dim ExamBatchId As Integer
        'Dim StdCenter As String
        'If ddlExamBatch.SelectedValue = 0 Then
        '    lblErrorMsg.Text = "Please select examination batch."
        'Else
        '    ExamBatchId = ddlExamBatch.SelectedValue
        'End If
        'If ddlStudentCenter.SelectedValue = 0 Then
        '    lblErrorMsg.Text = "Select examination center."
        'Else
        '    StdCenter = ddlStudentCenter.SelectedValue
        'End If
        DisplayGrid()

    End Sub
    Sub DisplayGrid()
        Dim ExamBatchId, SortBy As Integer
        Dim StdCenter, StdCode, StdName As String
        If ddlExamBatch.SelectedValue = 0 Then
            lblErrorMsg.Text = "Select Any Exam Batch"
            Exit Sub
        Else
            ExamBatchId = ddlExamBatch.SelectedValue
        End If

        StdCenter = ddlStudentCenter.SelectedValue
        SortBy = ddlSortBy.SelectedValue

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


        Dt = DLGenerateHallTicket.GridViewGenerateHallTicket(ExamBatchId, StdCenter, StdCode, StdName, SortBy)
        If Dt.Rows.Count > 0 Then
            lblMsg.Text = ""
            lblErrorMsg.Text = ""
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataSource = Dt
            GridView1.DataBind()
            txtCountofStd.Text = Dt.Rows.Count
            Dt2 = DLGenerateHallTicket.CheckHallTicketLockStatus(ExamBatchId)
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

        'Dt2 = DLGenerateHallTicket.GenerateHallTicketLockStatus(ExamBatchId, StdCenter)
        'If Dt2.Rows.Count > 0 Then
        '    GridView1.Enabled = False
        'End If

    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim ExamBatchId As Integer
        Dim StdCenter As String
        ExamBatchId = ddlExamBatch.SelectedValue
        StdCenter = ddlStudentCenter.SelectedValue

        Dt2 = DLGenerateHallTicket.CheckHallTicketLockStatus(ExamBatchId)
        If Dt2.Rows.Count > 0 Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please unlock the records to Clear."

        Else

            If ddlExamBatch.SelectedItem.Text = "Select" Or ddlStudentCenter.SelectedItem.Text = "Select" Then
                lblMsg.Visible = False
                lblErrorMsg.Visible = True
                lblErrorMsg.Text = "Please select the Exam Batch and Student Center to clear Hall Ticket No."
            Else

                DLGenerateHallTicket.ClearGenerateHallTicketNo(ExamBatchId, StdCenter)
                lblMsg.Visible = True
                lblErrorMsg.Visible = False
                lblMsg.Text = "Hall Ticket No. cleared successfully."
                GridView1.Visible = False
            End If

        End If
    End Sub

    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click

        If ddlExamBatch.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select Exam Batch to Generate Hall ticket No."
        ElseIf ddlStudentCenter.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select Student Center to Generate Hall ticket No."
        ElseIf txtFromSerial.Text = "" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please enter from Serial No."
        ElseIf IsNumeric(txtFromSerial.Text) = True Then
            Dim FromSerialNo As String = txtFromSerial.Text
            Dim ExamBatchId, SortBy As Integer
            Dim StdCenter As String
            Dim FromSerial, Prefix As String
            Prefix = txtPrefix.Text
            ExamBatchId = ddlExamBatch.SelectedValue
            StdCenter = ddlStudentCenter.SelectedValue
            SortBy = ddlSortBy.SelectedValue
            Dt1 = DLGenerateHallTicket.ViewHallTicket(ExamBatchId, StdCenter, SortBy)
            For i = 0 To Dt1.Rows.Count - 1 Step 1

                If IsDBNull(Dt1.Rows(i).Item("HallTicketNo")) = True Then
                    Dt1.Rows(i).Item("HallTicketNo") = FromSerialNo
                    Session("AdmitId") = Dt1.Rows(i).Item("RegStudId")
                    FromSerial = FromSerialNo
                    DLGenerateHallTicket.UpdateHallTicketNo(ExamBatchId, StdCenter, FromSerial, Prefix, Session("AdmitId"))
                    FromSerialNo = FromSerialNo + 1
                ElseIf Dt1.Rows(i).Item("HallTicketNo") = "" Then
                    Dt1.Rows(i).Item("HallTicketNo") = FromSerialNo
                    Session("AdmitId") = Dt1.Rows(i).Item("RegStudId")
                    FromSerial = FromSerialNo
                    DLGenerateHallTicket.UpdateHallTicketNo(ExamBatchId, StdCenter, FromSerial, Prefix, Session("AdmitId"))
                End If

            Next
            DisplayGrid()
            lblMsg.Visible = True
            lblErrorMsg.Visible = False
            lblMsg.Text = "Hall Ticket No. allocated Successfully."
            txtPrefix.Text = ""
            txtFromSerial.Text = ""
            txtToSerial.Text = ""
        Else

            lblMsg.Visible = True
            lblErrorMsg.Visible = False
            lblMsg.Text = "Please Enter Numeric value in From Serial No."

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
    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Check As String
        If txtPassword.Text = Session("Password") Then
            Dim ExamBatchId As Integer
            ExamBatchId = ddlExamBatch.SelectedValue
            '1
            If DLGenerateHallTicket.RecordsGenHallTicket(ExamBatchId).Tables(0).Rows(0).Item(0) = "N" Then
                Dim roweffected As Integer = DLGenerateHallTicket.LockGenerateHallTicket(ExamBatchId)
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
                            Dim roweffected As Integer = DLGenerateHallTicket.UnLockGenerateHallTicket(ExamBatchId)
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
                    Dim roweffected As Integer = DLGenerateHallTicket.UnLockGenerateHallTicket(ExamBatchId)
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

    Protected Sub btnLock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLock.Click
        Dim ExamBatchId As Integer
        ExamBatchId = ddlExamBatch.SelectedValue

        If ddlExamBatch.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select the Exam Batch to Lock/Unlock the records."
        Else
            Dt2 = DLGenerateHallTicket.CountRecordsGenHallTicket(ExamBatchId)

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

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        DisplayGrid()
    End Sub

    Protected Sub BtnPublish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPublish.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim Dt3 As DataTable
            Dim msg As String = ""
            Dim ExamBatchId, CountHallTicket As Integer
            ExamBatchId = ddlExamBatch.SelectedValue
            'Dt4 = DLGenerateHallTicket.CheckHallTicketNoForPublish(ExamBatchId)
            If ddlExamBatch.SelectedItem.Text = "Select" Then
                lblMsg.Visible = False
                lblErrorMsg.Visible = True
                lblErrorMsg.Text = "Please select the Exam Batch to Publish Hall Ticket."

            Else
                Dt3 = DLGenerateHallTicket.CheckPublishHallTicket(ExamBatchId)

                CountHallTicket = Dt3.Rows.Count
                If CountHallTicket <> 0 Then
                    'DLGenerateHallTicket.PublishHallTicket(ExamBatchId)
                    'lblMsg.Visible = True
                    'lblErrorMsg.Visible = False
                    'lblMsg.Text = "Hall Ticket Published successfully."

                    msg = "<table><tr>" + msg
                    msg = msg + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Exam Batch" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Student Name" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Student Code" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Batch" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Student Center" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Exam Center" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Hall ticket No" + "</b></td>" + "<td><b>" + "</tr><br><tr>"
                    For i As Integer = 0 To Dt3.Rows.Count - 1
                        For j As Integer = 0 To Dt3.Columns.Count - 1

                            msg = msg + "<td  style=""border-style: solid; border-width: thin"">" + Dt3.Rows(i)(j).ToString + "</td>"

                        Next
                        msg = msg + "</tr><tr style=""border-style: solid: solid; border-width: thin"">"

                    Next
                    msg = msg + "</tr></table>"


                   

                    DLGenerateHallTicket.publish(msg)
                    DLGenerateHallTicket.updatepublishflag(ExamBatchId)

                    lblMsg.Text = "Data is published in Notice Board."
                    lblErrorMsg.Text = ""
                Else
                    lblMsg.Text = ""
                    lblErrorMsg.Text = "No records to display."
                    GridView1.Visible = False
                End If
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot Publish data."
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
        Dim ExamBatchId, SortBy As Integer
        Dim StdCenter, StdCode, StdName As String
        ExamBatchId = ddlExamBatch.SelectedValue
        StdCenter = ddlStudentCenter.SelectedValue
        SortBy = ddlSortBy.SelectedValue

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


        Dt = DLGenerateHallTicket.GridViewGenerateHallTicket(ExamBatchId, StdCenter, StdCode, StdName, SortBy)
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        GridView1.Visible = True
        GridView1.Enabled = True
        GridView1.DataSource = Dt
        GridView1.DataBind()
        txtCountofStd.Text = Dt.Rows.Count
        Dt2 = DLGenerateHallTicket.CheckHallTicketLockStatus(ExamBatchId)
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
    Protected Sub btnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Try
            Dim FromSerialNo, ToSerialNo As String
            Dim ExamBatchId As Integer
            Dim Exam As String
            Dim id As String = ""
            Dim check As String = ""
            ExamBatchId = ddlExamBatch.SelectedValue
            Exam = ddlExamBatch.SelectedItem.Text
            If txtFromSerial.Text.Equals("") Then
                FromSerialNo = 0
            Else
                FromSerialNo = txtFromSerial.Text
            End If
            If txtToSerial.Text.Equals("") Then
                ToSerialNo = 0
            Else
                ToSerialNo = txtToSerial.Text
            End If
            'If ddlExamBatch.SelectedItem.Text = "Select" Then
            '    lblErrorMsg.Text = "Please select Exam Batch."

            If txtFromSerial.Text <> "" And txtToSerial.Text = "" Then
                lblErrorMsg.Text = "Please enter from Serial and To Serial No to print."

            ElseIf txtFromSerial.Text = "" And txtToSerial.Text <> "" Then
                lblErrorMsg.Text = "Please enter from Serial and To Serial No to print."

            ElseIf txtFromSerial.Text <> "" And txtToSerial.Text <> "" Then

                Dim qrystring As String = "RptGenerateHallTicketReportChecked.aspx?" & "&Exam=" & Exam & "&ExamBatchId=" & ExamBatchId & "&FromserialNo=" & FromSerialNo & "&ToSerialNo=" & ToSerialNo & "&id=" & 0
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                lblErrorMsg.Text = ""
            Else

                Dim Count1 As Integer = 0
                For Each Grid As GridViewRow In GridView1.Rows

                    If CType(Grid.FindControl("ChkSelect"), CheckBox).Checked = True Then
                        check = CType(Grid.FindControl("lblADId"), HiddenField).Value
                        id = check + "," + id
                        Count1 = Count1 + 1
                    End If
                Next

                If id = "" Then
                    id = 0
                Else
                    id = Left(id, id.Length - 1)
                End If


                If Count1 > 0 Then

                    Dim qrystring As String = "RptGenerateHallTicketReportChecked.aspx?" & "&Exam=" & Exam & "&ExamBatchId=" & ExamBatchId & "&FromserialNo=" & "" & "&ToSerialNo=" & "" & "&id=" & id
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                    lblErrorMsg.Text = ""

                Else
                    lblErrorMsg.Text = "Please select the records to print."
                    lblMsg.Text = ""
                End If

            End If



        Catch ex As Exception
            lblErrorMsg.Text = "Please Enter Correct Data."
        End Try
    End Sub


End Class
