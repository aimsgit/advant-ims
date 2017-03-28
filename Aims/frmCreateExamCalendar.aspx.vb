
Partial Class frmCreateExamCalendar
    Inherits BasePage
    Dim EL As New ELCreateExamCalendar
    Dim bl As New BLCreateExamCalendar
    Dim dt, dt1 As DataTable

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.BatchId = ddlExamBatch.SelectedValue
            EL.SubjectId = ddlSubject.SelectedValue
            EL.DOE = txtExamDate.Text
            EL.TOE = txtExamTime.Text
            If btnSubmit.Text = "UPDATE" Then
                EL.Id = ViewState("CreateExamCalendar_Auto_id")
                'dt = BL.CheckDuplicate(EL)
                'If dt.Rows.Count > 0 Then
                '    lblmsg.Text = "Data already exists."
                '    msginfo.Text = " "
                'Else
                bl.Update(EL)
                msginfo.Text = ""
                lblmsg.Text = "Data Updated Successfully."
                btnSubmit.Text = "ADD"
                GridCreateExamCalendar.Visible = True
                btnView.Text = "VIEW"
                Clear()
                GridCreateExamCalendar.PageIndex = ViewState("PageIndex")
                DispGrid()
            ElseIf btnSubmit.Text = "ADD" Then

                'dt = Depreciation_Rates.CheckDuplicate(DepreiciationRate)
                'If dt.Rows.Count > 0 Then
                '    msginfo.Text = "Data already exists."
                '    lblmsg.Text = ""
                '    'clear()
                'Else

                Dim ExamBatchId As Integer
                ExamBatchId = ddlExamBatch.SelectedValue
                '1
                If bl.CountData(ExamBatchId).Tables(0).Rows(0).Item(0) = "Y" Then
                    msginfo.Text = "This Record is Locked,You can't add the data."
                    lblmsg.Text = ""
                    Exit Sub
                Else
                    Dim i As Integer
                    i = bl.Insert(EL)
                    ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")

                    msginfo.Text = ""
                    lblmsg.Text = "Data Saved Successfully."
                    btnSubmit.Text = "ADD"
                    dt = bl.GetAddCreateExamCalender(ViewState("dispId "))
                    GridCreateExamCalendar.Visible = True
                    GridCreateExamCalendar.DataSource = dt
                    GridCreateExamCalendar.DataBind()

                    GridCreateExamCalendar.Enabled = True
                    ViewState("PageIndex") = 0
                    GridCreateExamCalendar.PageIndex = 0
                    'DispGrid()
                    Clear()
                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot Add/Update data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If btnView.Text = "VIEW" Then
            lblmsg.Text = " "
            msginfo.Text = " "
            ViewState("PageIndex") = 0
            GridCreateExamCalendar.PageIndex = 0
            DispGrid()

        ElseIf btnView.Text = "BACK" Then
            GridCreateExamCalendar.Enabled = True
            lblmsg.Text = " "
            msginfo.Text = " "
            btnSubmit.Text = "ADD"
            btnView.Text = "VIEW"
            Clear()
            GridCreateExamCalendar.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub
    Sub DispGrid()
        EL.Id = 0
        Dim ExamBatchId As Integer
        ExamBatchId = ddlExamBatch.SelectedValue
        EL.BatchId = ddlExamBatch.SelectedValue
        dt = bl.GetCreateExamCalender(EL)
        If dt.Rows.Count > 0 Then
            If ExamBatchId = 0 Then
                GridCreateExamCalendar.Enabled = True
                GridCreateExamCalendar.Visible = True
                GridCreateExamCalendar.DataSource = dt
                GridCreateExamCalendar.DataBind()
            Else
                If bl.CountData(ExamBatchId).Tables(0).Rows(0).Item(0) = "Y" Then
                    GridCreateExamCalendar.Enabled = False
                    GridCreateExamCalendar.Visible = True
                    GridCreateExamCalendar.DataSource = dt
                    GridCreateExamCalendar.DataBind()
                Else
                    GridCreateExamCalendar.Enabled = True
                    GridCreateExamCalendar.Visible = True
                    GridCreateExamCalendar.DataSource = dt
                    GridCreateExamCalendar.DataBind()
                End If
            End If
        Else
            lblmsg.Text = ""
            msginfo.Text = "No Records to Display."
            GridCreateExamCalendar.Visible = False

        End If
    End Sub
    Sub Clear()
        txtExamDate.Text = Format(Today, "dd-MMM-yyyy")
        txtExamTime.Text = ""
    End Sub

    Protected Sub GridCreateExamCalendar_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridCreateExamCalendar.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Id = CType(GridCreateExamCalendar.Rows(e.RowIndex).FindControl("lblID"), HiddenField).Value
            dt = bl.GetCreateExamCalender(EL)
            If dt.Rows(0).Item("LockFlag") = "Y" Then
                msginfo.Text = "This Record is  Locked, You can't delete the data."
                lblmsg.Text = ""
                Exit Sub
            Else

                EL.Id = CType(GridCreateExamCalendar.Rows(e.RowIndex).FindControl("lblID"), HiddenField).Value
                bl.Delete(EL)

                Clear()
                GridCreateExamCalendar.PageIndex = ViewState("PageIndex")
                DispGrid()
                msginfo.Text = " "
                lblmsg.Text = "Data Deleted Successfully."
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""

        End If
    End Sub

    Protected Sub GridCreateExamCalendar_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridCreateExamCalendar.RowEditing
        ViewState("CreateExamCalendar_Auto_id") = CType(GridCreateExamCalendar.Rows(e.NewEditIndex).FindControl("lblID"), HiddenField).Value
        EL.Id = ViewState("CreateExamCalendar_Auto_id")
        dt = bl.GetCreateExamCalender(EL)
        If dt.Rows(0).Item("LockFlag") = "Y" Then
            msginfo.Text = "This Record is  Locked,You can't Edit the data."
            lblmsg.Text = ""
            Exit Sub
        Else
            msginfo.Text = ""
            lblmsg.Text = ""
            btnSubmit.Text = "UPDATE"
            btnView.Visible = True
            btnView.Text = "BACK"
            GridCreateExamCalendar.Visible = True
            ViewState("CreateExamCalendar_Auto_id") = CType(GridCreateExamCalendar.Rows(e.NewEditIndex).FindControl("lblID"), HiddenField).Value
            ddlExamBatch.SelectedValue = CType(GridCreateExamCalendar.Rows(e.NewEditIndex).FindControl("lblGVBatch_ID"), Label).Text
            ddlSubject.SelectedValue = CType(GridCreateExamCalendar.Rows(e.NewEditIndex).FindControl("lblGVSubject_Id"), Label).Text
            txtExamDate.Text = CType(GridCreateExamCalendar.Rows(e.NewEditIndex).FindControl("lblGVDOE"), Label).Text
            txtExamTime.Text = CType(GridCreateExamCalendar.Rows(e.NewEditIndex).FindControl("lblGVTOE"), Label).Text

            GridCreateExamCalendar.DataSource = dt
            GridCreateExamCalendar.DataBind()
            GridCreateExamCalendar.Enabled = False
            GridCreateExamCalendar.Visible = True
        End If

    End Sub

    Protected Sub btnPublish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPublish.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Id = 0
            Dim msg As String = ""
            Dim x As String
            '"<Table><tr><td> ResourceName ,  capacity,    ExamBatch,    ResourceType </ td></ tr>"
            EL.BatchId = ddlExamBatch.SelectedValue
            If EL.BatchId = 0 Then
                msginfo.Text = "Select any Batch Field."
                Exit Sub
            End If
            EL.SubjectId = ddlSubject.SelectedValue
            EL.DOE = txtExamDate.Text
            EL.TOE = txtExamTime.Text
            dt = bl.GetPublishCreateExamCalender(EL)
            If dt.Rows.Count = 0 Then
                lblmsg.Text = ""
                msginfo.Text = "No records to Publish."
                GridCreateExamCalendar.Visible = False
            Else

                'EL.BatchId = ddlExamBatch.SelectedValue
                'dt = bl.GetPublishCreateExamCalender(EL)
                'If dt.Rows.Count > 0 Then
                'GridCreateExamCalendar.Enabled = True
                'GridCreateExamCalendar.Visible = True
                'GridCreateExamCalendar.DataSource = dt
                'GridCreateExamCalendar.DataBind()

                msg = "<p><b>"
                msg = msg + "Following Students have been registered for examination batch " + ddlExamBatch.SelectedItem.Text + "</p>"
                msg = "<table><tr style=""border-style: solid; border-width: thin""> " + msg
                msg = msg + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Exam Batch" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Subject Code" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Subject Name" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Date Of Exam" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Time Of Exam" + "</td>" + "</tr><br><tr style=""border-style: solid: solid; border-width: thin"">"
                For i As Integer = 0 To dt.Rows.Count - 1
                    For j As Integer = 0 To dt.Columns.Count - 1

                        msg = msg + "<td  style=""border-style: solid; border-width: thin"">" + dt.Rows(i)(j).ToString + "</td>"

                    Next
                    msg = msg + "</tr><tr style=""border-style: solid: solid; border-width: thin"">"

                Next
                msg = msg + "</table>"
                bl.UpdatePublish(EL)
                DLCreateExamCalendar.publish(msg)

                lblmsg.Text = "Data is published in Notice Board."
                msginfo.Text = ""

            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot Publish Data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            ddlExamBatch.Focus()
            txtExamDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GridCreateExamCalendar_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridCreateExamCalendar.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.Id = 0
        EL.BatchId = ddlExamBatch.SelectedValue
        dt = bl.GetCreateExamCalender(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridCreateExamCalendar.DataSource = sortedView
        GridCreateExamCalendar.Enabled = True
        GridCreateExamCalendar.Visible = True
        GridCreateExamCalendar.DataBind()
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

    Protected Sub btnLockunlk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLockunlk.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim ExamBatchId As Integer
            ExamBatchId = ddlExamBatch.SelectedValue
            If ExamBatchId = 0 Then
                msginfo.Text = "Select any Batch Field."
                Exit Sub
            End If

            Dim dt3 As DataSet
            dt3 = bl.CntData(ExamBatchId)
            If dt3.Tables(0).Rows.Count > 0 Then
                ControlsPanel.Visible = False
                PasswordPanel.Visible = True
                txtPassword.Focus()
                lblpassError.Text = ""
                Image1.Visible = False
                Image2.Visible = False
            Else
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                lblmsg.Text = ""
                msginfo.Text = ""
                msginfo.Text = "No Records to Lock/Unlock."
                Image1.Visible = True
                Image2.Visible = True

            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot Lock/Unlock data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        Dim Check As String
        If txtPassword.Text = Session("Password") Then
            Dim ExamBatchId As Integer
            'ExamBatchId = ddlExamBatch.SelectedValue
            'If ExamBatchId = 0 Then
            '    txtExamTime.Text = 0
            'End If
            ExamBatchId = ddlExamBatch.SelectedValue
            '1
            If bl.CountData(ExamBatchId).Tables(0).Rows(0).Item(0) = "N" Then
                Dim roweffected As Integer = bl.LockData(ExamBatchId)
                If roweffected > 0 Then
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    msginfo.Text = ""
                    lblmsg.Text = roweffected.ToString + " Records are Locked."
                    DispGrid()
                    GridCreateExamCalendar.Enabled = False
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

                    dt1 = bl.GetunlockData(role)
                    '3
                    If dt1.Rows.Count < 1 Then
                        lblmsg.Text = "You don't have Unlock Permission."
                        msginfo.Text = ""
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        GridCreateExamCalendar.Enabled = False
                        Image1.Visible = True
                        Image2.Visible = True
                    Else
                        Check = dt1.Rows(0)("Result").ToString.Trim

                        'check = dt.Rows(0)("Result").ToString.Trim
                        '4
                        If Check = "" Then
                            lblmsg.Text = "You don't have Unlock Permission."
                            msginfo.Text = ""
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            GridCreateExamCalendar.Enabled = False
                            Image1.Visible = True
                            Image2.Visible = True
                            '4
                        Else
                            Dim roweffected As Integer = bl.UnLockData(ExamBatchId)
                            If roweffected > 0 Then
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                msginfo.Text = ""
                                lblmsg.Text = roweffected.ToString + " Records Unlocked."
                                DispGrid()
                                GridCreateExamCalendar.Enabled = True
                                Image1.Visible = True
                                Image2.Visible = True
                            End If
                            '4
                        End If
                        '3
                    End If
                    '2
                Else
                    Dim roweffected As Integer = bl.UnLockData(ExamBatchId)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        lblmsg.Text = ""
                        msginfo.Text = roweffected.ToString + " records Unlocked."
                        GridCreateExamCalendar.Enabled = True
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
            lblmsg.Text = ""
            msginfo.Text = ""
            msginfo.Text = "Enter correct password."
            Image1.Visible = True
            Image2.Visible = True
            lblmsg.Text = ""
        End If
    End Sub
End Class
