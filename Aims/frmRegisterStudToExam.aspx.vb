
Partial Class frmRegisterStudToExam
    Inherits BasePage
    Dim El As New ELExamStudRegistration
    Dim BL As New BLExamStudRegistration
    Dim Dt, Dt1, Dt2 As DataTable
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try

                El.ExamBatchId = ddlExamBatch.SelectedValue
                El.BatchId = ddlBatch.SelectedValue
                El.StdId = ddlStudent.SelectedValue
                El.Eligibility = ddlEligibility.SelectedValue
                El.Branchcode = ddlBranch.SelectedValue
                btnPublish.Enabled = True
                If btnSave.Text = "UPDATE" Then
                    El.ID = ViewState("id")
                    Dt1 = DLExamStudRegistration.GetDuplData(El)
                    If Dt1.Rows.Count > 0 Then

                        DisplayGrid(0)
                        lblmsgifo.Text = ""
                        lblerrmsg.Text = "Data already exists."
                        btnSave.Text = "ADD"
                        btnView.Text = "VIEW"
                    Else
                        El.ID = ViewState("id")
                        BL.UpdateRecord(El)
                        btnSave.Text = "ADD"
                        btnView.Text = "VIEW"
                        GrdExamStudRegister.PageIndex = ViewState("PageIndex")
                        DisplayGrid(0)
                        'txtEligibility.Text = ""
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Updated Successfully."
                        ddlBatch.Enabled = True
                        ddlStudent.Enabled = True
                        ddlBranch.Enabled = True
                    End If
                ElseIf btnSave.Text = "ADD" Then
                   

                    El.ID = 0

                    If DLExamStudRegistration.CountData(El.ExamBatchId).Tables(0).Rows(0).Item(0) = "Y" Then

                        'If Dt1.Rows(0).Item("LockUnlock") = "Y" Then
                        lblerrmsg.Text = "This Exam Batch is  Locked,You cann't Add the data."
                        lblmsgifo.Text = ""
                        Exit Sub
                    Else

                        Dt1 = DLExamStudRegistration.GetDuplData(El)
                        If Dt1.Rows.Count > 0 Then

                            DisplayGrid(0)
                            lblmsgifo.Text = ""
                            lblerrmsg.Text = "Data already exists."
                            Exit Sub
                            'GrdExamStudRegister.Enabled = False
                        Else
                            DisplayGrid(0)
                            lblmsgifo.Text = ""
                            lblerrmsg.Text = "Data already exists."
                            'GrdExamStudRegister.Enabled = True
                        End If


                   
                        If El.StdId <> 0 Then
                            El.ID = 1
                        Else
                            El.ID = 0
                        End If
                        'El.ID = 0

                        Dim i As Integer = BL.InsertRecord(El)
                        If i > 0 Then
                            lblerrmsg.Text = ""
                            ViewState("PageIndex") = 0
                            GrdExamStudRegister.PageIndex = 0
                            DisplayGrid(0)
                            lblerrmsg.Text = ""
                            lblmsgifo.Text = "Data Saved Successfully."
                            ddlBatch.Enabled = True
                            ddlStudent.Enabled = True
                            ddlBranch.Enabled = True

                        Else
                            lblerrmsg.Text = "No Records to Generate."
                            lblmsgifo.Text = ""
                        End If

                    End If
                End If
             

            Catch e1 As Exception
                lblerrmsg.Text = "Enter Correct Data."
                lblmsgifo.Text = ""
            End Try
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsgifo.Text = ""
        End If
    End Sub
    Sub DisplayGrid(ByVal Id As Integer)
        Dim ExamBatchId As Integer
        btnPublish.Enabled = True
        El.ExamBatchId = ddlExamBatch.SelectedValue
        ExamBatchId = El.ExamBatchId
        El.BatchId = ddlBatch.SelectedValue
        El.StdId = ddlStudent.SelectedValue
        El.Branchcode = ddlBranch.SelectedValue

        Dt1 = BL.GetGridData(El, Id)
        If Dt1.Rows.Count = 0 Then
            GrdExamStudRegister.DataSource = Nothing
            GrdExamStudRegister.DataBind()
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
        ElseIf Dt1.Rows.Count > 0 Then


            GrdExamStudRegister.DataSource = Dt1
            GrdExamStudRegister.DataBind()
            'GrdExamStudRegister.Enabled = True
            GrdExamStudRegister.Visible = True
            'Dt2 = DLExamStudRegistration.CheckBatchLockStatus(ExamBatchId)

            'If Dt2.Rows.Count > 0 Then
            '    '    GrdExamStudRegister.Enabled = False
            'End If
            LinkButton.Focus()
        End If
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        Try
            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            btnPublish.Enabled = True
            GrdExamStudRegister.Enabled = True

            If btnView.Text <> "BACK" Then
                ViewState("PageIndex") = 0
                GrdExamStudRegister.PageIndex = 0
                El.ExamBatchId = ddlExamBatch.SelectedValue
                If DLExamStudRegistration.CountData(El.ExamBatchId).Tables(0).Rows(0).Item(0) = "Y" Then

                    DisplayGrid(0)
                    ddlBatch.Enabled = True
                    ddlStudent.Enabled = True
                    ddlBranch.Enabled = True
                    GrdExamStudRegister.Visible = True
                    'GrdExamStudRegister.Enabled = True
                Else
                    'GrdExamStudRegister.Enabled = True
                    DisplayGrid(0)
                    ddlBatch.Enabled = True
                    ddlStudent.Enabled = True
                    ddlBranch.Enabled = True
                    GrdExamStudRegister.Visible = True
                End If
            Else
                btnView.Text = "VIEW"
                btnSave.Text = "ADD"
                GrdExamStudRegister.PageIndex = ViewState("PageIndex")

                'GrdExamStudRegister.Enabled = True
                DisplayGrid(0)
                ddlBatch.Enabled = True
                ddlStudent.Enabled = True
                ddlBranch.Enabled = True




            End If
        Catch ex As Exception
            lblerrmsg.Text = "No Records to display."
            GrdExamStudRegister.Visible = False
            lblmsgifo.Text = ""
        End Try

    End Sub
    Protected Sub GrdExamStudRegister_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdExamStudRegister.RowDeleting

        If (Session("BranchCode") = Session("ParentBranch")) Then
            El.ID = CType(GrdExamStudRegister.Rows(e.RowIndex).Cells(1).FindControl("lblId"), Label).Text
            Dim ExamBatchId As Integer
            El.ExamBatchId = ddlExamBatch.SelectedValue
            ExamBatchId = El.ExamBatchId
            
            El.BatchId = ddlBatch.SelectedValue
            El.StdId = ddlStudent.SelectedValue
            El.Branchcode = ddlBranch.SelectedValue

            Dim Id As Integer
            Id = El.ID

            Dt1 = BL.GetGridData(El, Id)

            If Dt1.Rows(0).Item("LockUnlock") = "Y" Then
                lblerrmsg.Text = "This Record is  Locked,You cann't Delete the data"
                lblmsgifo.Text = ""
                Exit Sub


            ElseIf BL.ChangeFlag(El) Then

                lblerrmsg.Text = ""
                lblmsgifo.Text = "Data Deleted Successfully."
                GrdExamStudRegister.PageIndex = ViewState("PageIndex")
                DisplayGrid(0)
                'GrdExamStudRegister.Enabled = True
                ddlBatch.Enabled = True
                ddlStudent.Enabled = True
                ddlBranch.Enabled = True

            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If
    End Sub
    Protected Sub GrdExamStudRegister_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdExamStudRegister.PageIndexChanging
        GrdExamStudRegister.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GrdExamStudRegister.PageIndex
        'DisplayGrid(0)
    End Sub
    Protected Sub GrdExamStudRegister_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdExamStudRegister.RowEditing
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        Dim ExamBatchId As Integer
        El.ExamBatchId = ddlExamBatch.SelectedValue
        ExamBatchId = El.ExamBatchId
        Dt2 = DLExamStudRegistration.CheckBatchLockStatus(ExamBatchId)
        If Dt2.Rows(0).Item("LockUnlock") = "Y" Then
            lblerrmsg.Text = "Record is  Locked"
            lblmsgifo.Text = ""
            Exit Sub
        Else

            ddlExamBatch.SelectedValue = CType(GrdExamStudRegister.Rows(e.NewEditIndex).FindControl("lblExamBatchId"), Label).Text
            ViewState("id") = CType(GrdExamStudRegister.Rows(e.NewEditIndex).FindControl("lblId"), Label).Text
            ddlBranch.SelectedValue = CType(GrdExamStudRegister.Rows(e.NewEditIndex).FindControl("lblBranchCode"), Label).Text
            ddlBatch.Items.Clear()
            ddlBatch.DataSourceID = "ObjBatch"
            ddlBatch.DataBind()
            ddlBatch.SelectedValue = CType(GrdExamStudRegister.Rows(e.NewEditIndex).FindControl("lblBatchId"), Label).Text
            ddlStudent.Items.Clear()
            ddlStudent.DataSourceID = "ObjStudent"
            ddlStudent.DataBind()
            ddlStudent.SelectedValue = CType(GrdExamStudRegister.Rows(e.NewEditIndex).FindControl("lblStdid"), Label).Text
            'txtEligibility.Text = CType(GrdExamStudRegister.Rows(e.NewEditIndex).FindControl("lblEligibility"), Label).Text
            btnSave.Text = "UPDATE"
            btnView.Text = "BACK"
            El.ID = ViewState("id")
            El.ExamBatchId = ddlExamBatch.SelectedValue
            El.BatchId = (ddlBatch.SelectedValue)
            El.StdId = ddlStudent.SelectedValue
            El.Branchcode = ddlBranch.SelectedValue
            Dt1 = BL.GetGridData(El, El.ID)
            GrdExamStudRegister.DataSource = Dt1
            GrdExamStudRegister.DataBind()
            GrdExamStudRegister.Enabled = False
            btnPublish.Enabled = False
            ddlBatch.Enabled = False
            ddlStudent.Enabled = False
            ddlBranch.Enabled = False
        End If

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            ddlBatch.Enabled = True
            ddlStudent.Enabled = True
            ddlBranch.Enabled = True
        End If
    End Sub


    Protected Sub btnPublish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPublish.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            
            Dim msg As String = ""
            'Dim x As String
            If ddlExamBatch.SelectedItem.Text = "Select" Then
                lblmsgifo.Visible = False
                lblerrmsg.Visible = True
                lblerrmsg.Text = "Please select the Exam Batch to Publish the records."
            Else
                El.ExamBatchId = ddlExamBatch.SelectedValue

                '"<Table><tr><td> ResourceName ,  capacity,    ExamBatch,    ResourceType </ td></ tr>"
                'El.ExamBatchId = ddlExamBatch.SelectedValue
                El.BatchId = ddlBatch.SelectedValue
                El.StdId = ddlStudent.SelectedValue
                El.Branchcode = Session("BranchCode")
                Dt1 = DLExamStudRegistration.GetPublishData(El)

                If Dt1.Rows.Count = 0 Then
                    lblmsgifo.Text = ""
                    lblerrmsg.Text = "No records to Publish."
                Else
                    msg = "<p><b>"
                    msg = msg + "Following Students have been registered for examination batch " + ddlExamBatch.SelectedItem.Text + "</p>"
                    msg = msg + "<table><tr> "
                    msg = msg + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + " Exam Batch" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + " Batch" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + " Student Code" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + " Student Name" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + " Exam Time" + "</td>" + "</tr><tr>"
                    For i As Integer = 0 To Dt1.Rows.Count - 1
                        For j As Integer = 0 To Dt1.Columns.Count - 1
                            msg = msg + "<td  style=""border-style: solid; font-weight : normal; border-width: thin"">" + Dt1.Rows(i)(j).ToString + "</td>"
                            BL.ChangeRegFlag(El)
                        Next
                        msg = msg + "</tr><tr style=""border-style: solid: solid; border-width: thin"">"
                      
                    Next
                    msg = Trim(msg + "</tr></table>")
                    DLExamResources.publish(msg)
                    lblmsgifo.Visible = True

                    lblmsgifo.Text = "Data is published in Notice Board."
                    lblerrmsg.Text = ""

                End If
            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot publish data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub ddlStudent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStudent.SelectedIndexChanged
        'If ddlStudent.SelectedValue = 0 Then
        '    txtEligibility.Text = ""
        '    txtEligibility.Enabled = False
        'Else
        '    El.StdId = ddlStudent.SelectedValue
        '    Dt1 = DLExamStudRegistration.GetEligibility(El)
        '    If Dt1.Rows.Count > 0 Then
        '        txtEligibility.Text = Dt1.Rows(0).Item("Eligibility")
        '    Else
        '        txtEligibility.Text = ""
        '    End If

        'End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                El.ExamBatchId = ddlExamBatch.SelectedValue
                El.BatchId = ddlBatch.SelectedValue
                El.StdId = ddlStudent.SelectedValue
                'El.Eligibility = ddlEligibility.SelectedValue
                El.Branchcode = ddlBranch.SelectedValue
                lblerrmsg.Text = ""
                lblmsgifo.Text = ""

                If ddlExamBatch.SelectedValue = 0 Then
                    lblmsgifo.Text = ""
                    lblerrmsg.Text = "Exam Batch field is Mandatory. "
                Else



                    If DLExamStudRegistration.CountData(El.ExamBatchId).Tables(0).Rows.Count > 0 Then

                        If DLExamStudRegistration.CountData(El.ExamBatchId).Tables(0).Rows(0).Item(0) = "Y" Then
                            lblmsgifo.Text = ""
                            lblerrmsg.Text = "Records are locked, cannot be cleared."
                            GrdExamStudRegister.Enabled = False
                        Else
                            Dim clearcount As Integer = DLExamStudRegistration.ClearData(El)
                            If clearcount > 0 Then
                                lblmsgifo.Text = ""
                                lblerrmsg.Text = " Records are cleared."
                                'pnllabel.Visible = False
                                GrdExamStudRegister.Visible = False
                            Else
                                lblmsgifo.Text = ""
                                lblerrmsg.Text = "No records to Clear."
                                GrdExamStudRegister.Visible = False
                            End If

                        End If
                    Else
                        lblmsgifo.Text = ""
                        lblerrmsg.Text = "No records to Clear."
                        GrdExamStudRegister.Visible = False
                    End If
                End If
            Catch ex As Exception
                lblerrmsg.Text = "Exam Batch field is Mandatory."
                GrdExamStudRegister.Visible = False
            End Try
            'End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot clear data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        Dim Check As String
        If txtPassword.Text = Session("Password") Then
            Dim ExamBatchId As Integer
            ExamBatchId = ddlExamBatch.SelectedValue
            lblmsgifo.Text = ""
            lblmsgifo.Text = ""
            '1
            If DLExamStudRegistration.CountData(ExamBatchId).Tables(0).Rows(0).Item(0) = "N" Then
                Dim roweffected As Integer = DLExamStudRegistration.LockData(ExamBatchId)
                If roweffected > 0 Then
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    lblerrmsg.Text = ""
                    lblmsgifo.Text = roweffected.ToString + " Records are Locked."
                    DisplayGrid(0)

                    GrdExamStudRegister.Enabled = False

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

                    Dt1 = DLExamStudRegistration.GetunlockData(role)
                    '3
                    If Dt1.Rows.Count < 1 Then
                        lblerrmsg.Text = "You don't have Unlock Permission."
                        lblmsgifo.Text = ""
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        GrdExamStudRegister.Enabled = False
                        Image1.Visible = True
                        Image2.Visible = True
                    Else
                        Check = Dt1.Rows(0)("Result").ToString.Trim


                        '4
                        If Check = "" Then

                            lblerrmsg.Text = "You don't have Unlock Permission."
                            lblmsgifo.Text = ""
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            GrdExamStudRegister.Enabled = False
                            Image1.Visible = True
                            Image2.Visible = True
                            '4
                        Else
                            Dim roweffected As Integer = DLExamStudRegistration.UnLockData(ExamBatchId)
                            If roweffected > 0 Then
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                lblerrmsg.Text = ""
                                lblmsgifo.Text = roweffected.ToString + " Records Unlocked."
                                DisplayGrid(0)
                                GrdExamStudRegister.Enabled = True
                                'DisplayGrid(0)
                                Image1.Visible = True
                                Image2.Visible = True
                            End If
                            '4
                        End If
                        '3
                    End If
                    '2
                Else
                    Dim roweffected As Integer = DLExamStudRegistration.UnLockData(ExamBatchId)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = roweffected.ToString + " records Unlocked."
                        GrdExamStudRegister.Enabled = True

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
            'lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub btnLockunlk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLockunlk.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim ExamBatchId, Batch As Integer
            ExamBatchId = ddlExamBatch.SelectedValue
            If ddlExamBatch.SelectedItem.Text = "Select" Then
                lblmsgifo.Visible = False
                lblerrmsg.Visible = True
                lblerrmsg.Text = "Please select the Exam Batch to Lock/Unlock the records."
            Else

                Batch = ddlBatch.SelectedValue
                Dim dt3 As DataSet
                dt3 = DLExamStudRegistration.CntData(ExamBatchId, Batch)
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

    Protected Sub GrdExamStudRegister_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GrdExamStudRegister.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        El.ExamBatchId = ddlExamBatch.SelectedValue
        El.BatchId = ddlBatch.SelectedValue
        El.StdId = ddlStudent.SelectedValue
        El.Branchcode = ddlBranch.SelectedValue
        Dim ID As Integer = 0
        Dt1 = BL.GetGridData(El, ID)
        Dim sortedView As New DataView(Dt1)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GrdExamStudRegister.DataSource = sortedView
        GrdExamStudRegister.DataBind()
        'For Each grid As GridViewRow In GrdExamStudRegister.Rows
        '    lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
        '    lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
        '    lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
        '    lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
        '    lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
        '    pnllabel.Visible = True
        'Next
    End Sub
End Class
