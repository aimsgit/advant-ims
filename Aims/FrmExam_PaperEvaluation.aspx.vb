
Partial Class FrmExam_PaperEvaluation
    Inherits BasePage
    Dim EL As New ELExamPaperEvaluation
    Dim DL As New DLExamPaperEvaluation

    Dim dt As New DataTable
    'used for showing data in grid
    Sub DisplayGrid(ByVal id As Integer)
        EL.Batch = ddlExamBatch.SelectedValue
        dt = DLExamPaperEvaluation.ViewData(id, EL.Batch)
        If dt.Rows.Count > 0 Then
            GrdExamPaperEvaluation.DataSource = dt
            GrdExamPaperEvaluation.DataBind()
            GrdExamPaperEvaluation.Visible = True
            GrdExamPaperEvaluation.Enabled = True
            LinkButton.Focus()
            If (ViewState("SortExpression") <> "") Then
                Dim sortedView As New DataView(dt)
                Dim s As String = ViewState("SortExpression") & " " & ViewState("sortingDirection")
                sortedView.Sort = s
                GrdExamPaperEvaluation.DataSource = sortedView
                GrdExamPaperEvaluation.DataBind()
                clear()
            Else
                GrdExamPaperEvaluation.DataSource = dt
                GrdExamPaperEvaluation.DataBind()
                clear()
            End If

        Else
            GrdExamPaperEvaluation.Visible = False


            lblerrmsg.Text = "No records to display."
            lblmsgifo.Text = ""
            GrdExamPaperEvaluation.Visible = False


        End If
    End Sub
    'description of view event click
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click

        'If lblmsg.Visible = True Or msginfo.Visible = True Then
        'lblmsg.Visible = False
        'msginfo.Visible = False
        'End If

        If (ddlExamBatch.SelectedValue) = 0 Then
            lblerrmsg.Text = "Please Select Exam Batch."
            Exit Sub
        Else
            If btnView.Text <> "BACK" Then
                btnLockUnlock.Enabled = True
                lblerrmsg.Text = ""
                lblmsgifo.Text = ""
                ViewState("PageIndex") = 0
                GrdExamPaperEvaluation.PageIndex = 0
                DisplayGrid(0)
                clear()


            Else
                btnView.Text = "VIEW"
                btnSave.Text = "ADD"
                GrdExamPaperEvaluation.PageIndex = ViewState("PageIndex")
                DisplayGrid(0)
                clear()
                lblerrmsg.Text = ""
                lblmsgifo.Text = ""

            End If
        End If
    End Sub
    'description of delete event click
    Protected Sub GrdExamPaperEvaluation_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdExamPaperEvaluation.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            EL.Batch = ddlExamBatch.SelectedValue
            ViewState("PEID") = CType(GrdExamPaperEvaluation.Rows(e.RowIndex).Cells(1).FindControl("lblid"), Label).Text
            dt = DLExamPaperEvaluation.ViewData(ViewState("PEID"), EL.Batch)
            If dt.Rows(0).Item("LockUnlock") = "Y" Then
                lblerrmsg.Text = "This Record is  Locked,You can't Delete the data"
                lblmsgifo.Text = ""
                Exit Sub
            Else
                EL.Id = CType(GrdExamPaperEvaluation.Rows(e.RowIndex).Cells(1).FindControl("lblid"), Label).Text
                DLExamPaperEvaluation.ChangeFlag(EL)
                GrdExamPaperEvaluation.DataBind()
                lblerrmsg.Text = ""
                lblmsgifo.Text = "Data Deleted Successfully."
                GrdExamPaperEvaluation.PageIndex = ViewState("PageIndex")
                DisplayGrid(0)
                clear()
                'End If
            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If

    End Sub
    'description of edit event click
    Protected Sub GrdExamPaperEvaluation_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdExamPaperEvaluation.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            GrdExamPaperEvaluation.Enabled = True
            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            EL.Batch = ddlExamBatch.SelectedValue
            Dim dt As New DataTable
            dt = DLExamPaperEvaluation.ViewData(0, EL.Batch)
            If dt.Rows(0).Item("LockUnlock") = "Y" Then
                lblerrmsg.Text = " This Record is  Locked,You can't Edit the data,"
                lblmsgifo.Text = ""
                Exit Sub
            Else
                ddlExamBatch.SelectedValue = CType(GrdExamPaperEvaluation.Rows(e.NewEditIndex).FindControl("lblExamBatch"), Label).Text
                ddlSubject.Items.Clear()
                ddlSubject.DataSourceID = "ObjExamSUbject"
                ddlSubject.DataBind()
                ddlSubject.SelectedValue = CType(GrdExamPaperEvaluation.Rows(e.NewEditIndex).FindControl("lblSubject"), Label).Text
                ddlFaculty.SelectedValue = CType(GrdExamPaperEvaluation.Rows(e.NewEditIndex).FindControl("lblEmpId"), Label).Text
                txtFrmSrlNo.Text = CType(GrdExamPaperEvaluation.Rows(e.NewEditIndex).FindControl("lblFrmSrlNo"), Label).Text
                txtToSrlNo.Text = CType(GrdExamPaperEvaluation.Rows(e.NewEditIndex).FindControl("lblToSrlNo"), Label).Text
                ViewState("PEID") = CType(GrdExamPaperEvaluation.Rows(e.NewEditIndex).FindControl("lblid"), Label).Text
                dt = DLExamPaperEvaluation.ViewData(ViewState("PEID"), EL.Batch)
                btnSave.Text = "UPDATE"
                btnView.Text = "BACK"
                EL.Id = ViewState("PEID")
                GrdExamPaperEvaluation.DataSource = dt
                GrdExamPaperEvaluation.DataBind()
                GrdExamPaperEvaluation.Enabled = False
            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
            lblmsgifo.Text = ""
            'End If
        End If

    End Sub
    'description of add event as well as update event click
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ddlExamBatch.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Batch = ddlExamBatch.SelectedValue
            EL.Subject = ddlSubject.SelectedValue
            EL.Faculty = ddlFaculty.SelectedValue
            EL.FrmSerialNo = txtFrmSrlNo.Text
            EL.ToSerialNo = txtToSrlNo.Text

            If btnSave.Text = "UPDATE" Then
                'If DL.CheckLockExamPaperEvaluation(ViewState("ExamBatchId")) = "Y" Then
                '    'lblerrmsg.Text = ValidationMessage(1014)
                '    'lblmsgifo.Text = ValidationMessage(1014)
                '    'lblmsgifo.Text = ValidationMessage(1099)
                '    'ScriptManager.RegisterStartupScript(Me, Me.GetType(), "", "document.getElementById('" + ExportPanel.ClientID + "').style.visibility='visible';", True)

                '    GrdExamPaperEvaluation.Enabled = False

                'Else


                EL.Id = ViewState("PEID")
                dt = DLExamPaperEvaluation.GetDuplicateData(EL)
                If dt.Rows.Count > 0 Then
                    lblmsgifo.Text = ""
                    lblerrmsg.Text = "Data already exists."
                    DisplayGrid(ViewState("PEID"))
                Else
                    DLExamPaperEvaluation.Update(EL)
                    btnSave.Text = "ADD"
                    btnView.Text = "VIEW"
                    clear()
                    lblerrmsg.Text = ""
                    lblmsgifo.Text = "Data Updated Successfully."
                    GrdExamPaperEvaluation.PageIndex = ViewState("PageIndex")
                    DisplayGrid(0)
                    clear()
                End If
                'End If

            ElseIf btnSave.Text = "ADD" Then
                EL.Id = 0
                dt = DLExamPaperEvaluation.GetDuplicateData(EL)
                If dt.Rows.Count > 0 Then
                    lblmsgifo.Text = ""
                    lblerrmsg.Text = "Data already exists."
                    DisplayGrid(0)
                    clear()
                Else
                    ViewState("ExamBatchId") = ddlExamBatch.SelectedValue
                    If DLExamPaperEvaluation.CountData(ViewState("ExamBatchId")).Tables(0).Rows(0).Item(0) = "Y" Then
                        lblerrmsg.Text = "This Exam Batch is  Locked,You can't Add the data."
                        lblmsgifo.Text = ""
                        Exit Sub
                    Else
                        DLExamPaperEvaluation.Insert(EL)
                        btnSave.Text = "ADD"
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Saved Successfully."
                        ViewState("PageIndex") = 0
                        GrdExamPaperEvaluation.PageIndex = 0
                        DisplayGrid(0)
                        clear()
                    End If
                End If
            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsgifo.Text = ""
        End If


    End Sub
    'for clearing text in textbox
    Sub clear()

        txtFrmSrlNo.Text = ""
        txtToSrlNo.Text = ""

    End Sub

    'for page indexing one page to another
    Protected Sub Grdfeehead_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdExamPaperEvaluation.PageIndexChanging
        GrdExamPaperEvaluation.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GrdExamPaperEvaluation.PageIndex
        DisplayGrid(0)
        clear()
    End Sub
    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        Dim Check As String
        If txtPassword.Text = Session("Password") Then
            'Dim ExamBatchId As Integer
            ViewState("ExamBatchId") = ddlExamBatch.SelectedValue
            '1
            'ViewState("ExamBatchId") = ddlExamBatch.SelectedValue
            If DLExamPaperEvaluation.CountData(ViewState("ExamBatchId")).Tables(0).Rows(0).Item(0) = "N" Then
                'If DL.CheckLockExamPaperEvaluation(ExamBatchId) = "N" Then
                'If DLExamPaperEvaluation.CountData(ExamBatchId).Tables(0).Rows(0).Item(0) = "N" Then
                Dim roweffected As Integer = DLExamPaperEvaluation.LockData(ViewState("ExamBatchId"))
                If roweffected > 0 Then
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    lblerrmsg.Text = ""
                    lblmsgifo.Text = roweffected.ToString + " Records are Locked."
                    DisplayGrid(0)

                    GrdExamPaperEvaluation.Enabled = False
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

                    dt = DLExamPaperEvaluation.GetunlockData(role)
                    '3
                    If dt.Rows.Count < 1 Then
                        lblerrmsg.Text = "You don't have Unlock Permission."
                        lblmsgifo.Text = ""
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        GrdExamPaperEvaluation.Enabled = False
                        Image1.Visible = True
                        Image2.Visible = True
                    Else
                        Check = dt.Rows(0)("Result").ToString.Trim

                        'check = dt.Rows(0)("Result").ToString.Trim
                        '4
                        If Check = "" Then

                            lblerrmsg.Text = "You don't have Unlock Permission."
                            lblmsgifo.Text = ""
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            GrdExamPaperEvaluation.Enabled = False
                            Image1.Visible = True
                            Image2.Visible = True
                            '4
                        Else
                            Dim roweffected As Integer = DLExamPaperEvaluation.UnLockData(ViewState("ExamBatchId"))
                            If roweffected > 0 Then
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                lblerrmsg.Text = ""
                                lblmsgifo.Text = roweffected.ToString + " Records are  Unlocked."
                                DisplayGrid(0)
                                Image1.Visible = True
                                Image2.Visible = True
                            End If
                            '4
                        End If
                        '3
                    End If
                    '2
                Else
                    Dim roweffected As Integer = DLExamPaperEvaluation.UnLockData(ViewState("ExamBatchId"))
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = roweffected.ToString + " Records Unlocked."
                        DisplayGrid(0)
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
            lblmsgifo.Text = ""
            lblerrmsg.Text = ""
            lblerrmsg.Text = "Enter correct password"
            Image1.Visible = True
            Image2.Visible = True
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub btnLockUnlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLockUnlock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim ExamBatchId, Subject, Faculty As Integer

            ExamBatchId = ddlExamBatch.SelectedValue
            Subject = ddlSubject.SelectedValue
            Faculty = ddlFaculty.SelectedValue
            Dim dt3 As DataSet
            dt3 = DLExamPaperEvaluation.CntData(ExamBatchId, Subject, Faculty)
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
                lblmsgifo.Text = ""
                lblerrmsg.Text = ""
                lblerrmsg.Text = "No Records to Lock/Unlock."
                Image1.Visible = True
                Image2.Visible = True

            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot Lock/Unlock data."
            lblmsgifo.Text = ""
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ddlExamBatch.Focus()
            ViewState("heading") = Session("RptFrmTitleName")
            Me.Lblheading.Text = ViewState("heading")
        End If
    End Sub
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

    Protected Sub GrdExamPaperEvaluation_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GrdExamPaperEvaluation.Sorting

        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If


        EL.Batch = ddlExamBatch.SelectedValue


        Dim dt As New Data.DataTable
        dt = DLExamPaperEvaluation.ViewData(0, EL.Batch)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        ViewState("SortExpression") = e.SortExpression
        ViewState("sortingDirection") = sortingDirection
        GrdExamPaperEvaluation.DataSource = sortedView
        GrdExamPaperEvaluation.DataBind()
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
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
End Class
