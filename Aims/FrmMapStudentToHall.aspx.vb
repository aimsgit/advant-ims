
Partial Class FrmMapStudentToHall
    Inherits BasePage
    Dim DLMapStd As New DLExamhallAllocation
    Dim EL As New ELExamHallAllocation
    Dim BL As New BLExamHallAllocation
    Dim Dt, Dt1, Dt2, StdCount As DataTable
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try

                EL.ExamBatchId = ddlExamBatch.SelectedValue
                EL.SubId = ddlSubject.SelectedValue
                EL.RoomId = ddlExamRoom.SelectedValue
                EL.Fromsl = txtFromSerial.Text
                EL.Tosl = txtToSerial.Text

                If btnAdd.Text = "UPDATE" Then
                    EL.id = ViewState("RoomAutoId")
                    Dt = BL.CheckDuplicate(EL)
                    If Dt.Rows.Count > 0 Then
                        lblErrorMsg.Text = "Data already exists."
                        lblMsg.Text = ""
                        Exit Sub
                    Else
                        BL.UpdateRecord(EL)
                        lblErrorMsg.Text = ""
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"
                        lblMsg.Text = "Data Updated Successfully."
                        DisplayGrid()
                        GridView1.PageIndex = ViewState("PageIndex")
                        clear()
                        End If
                ElseIf btnAdd.Text = "ADD" Then
                        EL.id = 0
                    Dt = BL.CheckDuplicate(EL)
                    If Dt.Rows.Count > 0 Then
                        lblErrorMsg.Text = "Data already exists."
                        lblMsg.Text = ""
                        Exit Sub
                    Else
                        Dim ExamBatchId As Integer
                        ExamBatchId = ddlExamBatch.SelectedValue
                        If DLExamhallAllocation.CountData(ExamBatchId).Tables(0).Rows(0).Item(0) = "Y" Then
                            lblErrorMsg.Text = "This Exam Batch is  Locked,You cann't Add the data."
                            lblMsg.Text = ""

                        Else
                            BL.InsertRecord(EL)
                            lblMsg.Text = ""
                            btnAdd.Text = "ADD"

                            ViewState("PageIndex") = 0
                            GridView1.PageIndex = 0
                            DisplayGrid()
                            clear()
                            DisplayGrid()
                            lblErrorMsg.Text = ""

                            lblMsg.Text = "Data Saved successfully."
                        End If
                    End If
                     End If
            Catch ex As Exception
            lblMsg.Text = ""
            lblErrorMsg.Text = "Enter correct data."
        End Try

        Else
        lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
        lblMsg.Text = ""
        End If

    End Sub
    Sub clear()
        ddlSubject.SelectedValue = 0
        ddlExamBatch.SelectedValue = 0
        ddlExamRoom.SelectedValue = 0
        ddlExamBatch.Focus()
        txtFromSerial.Text = ""
        txtToSerial.Text = ""
    End Sub
    Sub DisplayGrid()
        Dim ExamBatchId As Integer
        ExamBatchId = ddlExamBatch.SelectedValue
        EL.ExamBatchId = ExamBatchId
        Dim dt As New DataTable
        EL.id = 0
        dt = BL.Display(EL)
        GridView1.DataSource = dt
        GridView1.DataBind()

        GridView1.Visible = True
        GridView1.Enabled = True
        If dt.Rows.Count > 0 Then
            'lblMsg.Text = ""
            'lblErrorMsg.Text = ""
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataSource = dt
            GridView1.DataBind()
            'ddlExamBatch.SelectedValue = dt.Rows.Count

            'Dt2 = DLExamhallAllocation.CheckBatchLockStatus(ExamBatchId)

            'If Dt2.Rows.Count > 0 Then
            '    GridView1.Enabled = False
            'End If

        Else

            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "No records to display."
            GridView1.Visible = False

        End If


    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        LinkButton1.Focus()
        EL.ExamBatchId = ddlExamBatch.SelectedValue
        lblErrorMsg.Text = ""
        If btnView.Text <> "BACK" Then
            lblMsg.Text = ""
            lblErrorMsg.Text = ""
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DisplayGrid()
            GridView1.Visible = True

        Else
            lblMsg.Text = ""
            lblErrorMsg.Text = ""
            btnView.Text = "VIEW"
            btnAdd.Text = "ADD"
            clear()
            GridView1.Visible = True
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayGrid()

        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = 0
            EL.id = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            'ViewState("RoomAutoId") = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            'EL.id = ViewState("RoomAutoId")
            Dim ExamBatchId As Integer
            ExamBatchId = ddlExamBatch.SelectedValue
            EL.ExamBatchId = ExamBatchId
            Dim Id As Integer
            Id = EL.id


            Dt = BL.Display(EL)

            If Dt.Rows(0).Item("LockUnlock") = "Y" Then
                lblErrorMsg.Text = "This Record is  Locked,You cann't Delete the data"
                lblMsg.Text = ""
                Exit Sub
            Else
                BL.ChangeFlag(EL)
                DisplayGrid()
                GridView1.Visible = True
                lblErrorMsg.Text = ""
                lblMsg.Text = "Data Deleted Successfully."
                ddlExamBatch.Focus()
                GridView1.PageIndex = ViewState("PageIndex")

                Dt = BL.Display(EL)
                GridView1.DataSource = Dt
                GridView1.DataBind()
                GridView1.Enabled = True
                GridView1.Visible = True
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblMsg.Text = ""
        End If



    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing


        Dim ExamBatchId As Integer
        ExamBatchId = ddlExamBatch.SelectedValue
        EL.ExamBatchId = ExamBatchId
        EL.id = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("IID"), HiddenField).Value
        Dim Id As Integer
        Id = EL.id

        Dt = BL.Display(EL)

        If Dt.Rows(0).Item("LockUnlock") = "Y" Then
            lblErrorMsg.Text = "This Record is  Locked,You cann't Edit the data"
            lblMsg.Text = ""
            Exit Sub
        Else
            EL.id = 0
            EL.id = ViewState("RoomAutoId")
            ddlExamRoom.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblRoomid"), Label).Text
            ddlExamBatch.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblExamBatch"), Label).Text
            ddlSubject.Items.Clear()
            ddlSubject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblsid"), Label).Text
            ddlSubject.DataSourceID = "ObjSubject"
            ddlSubject.DataBind()
            txtFromSerial.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblFrmsl"), Label).Text
            txtToSerial.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblTosl"), Label).Text


            ViewState("RoomAutoId") = CType(GridView1.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
            btnAdd.Text = "UPDATE"
            btnView.Text = "BACK"
            EL.id = ViewState("RoomAutoId")
            Dt = BL.Display(EL)
            GridView1.DataSource = Dt
            GridView1.DataBind()
            GridView1.Enabled = False
            txtCapacity.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            txtCapacity.Enabled = False
            txtCapacity.Text = ""
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGrid()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
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
        Dim dt As New DataTable
        EL.id = 0
        dt = BL.Display(EL)

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()

        GridView1.Visible = True
        GridView1.Enabled = True

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
    Protected Sub ddlExamRoom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlExamRoom.SelectedIndexChanged
        If ddlExamRoom.SelectedValue = "0" Then
            txtCapacity.Text = ""
        Else

            txtCapacity.Enabled = False
            EL.RoomId = ddlExamRoom.SelectedValue
            Dt2 = DLExamhallAllocation.GetCapacityAutoFill(EL)
            If Dt2.Rows.Count > 0 Then

                If Dt2.Rows(0).Item("Capacity").ToString = "" Then
                    txtCapacity.Text = 0
                Else
                    txtCapacity.Text = (Dt2.Rows(0).Item("Capacity"))
                End If
            End If
        End If
    End Sub
    Protected Sub btnPublish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPublish.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Dim msg As String = ""
            If ddlExamBatch.SelectedItem.Text = "Select" Then
                lblMsg.Visible = False
                lblErrorMsg.Visible = True
                lblErrorMsg.Text = "Please select the Exam Batch to Publish the records."
            Else
                EL.ExamBatchId = ddlExamBatch.SelectedValue


                EL.RoomId = ddlExamRoom.SelectedValue
                EL.SubId = ddlSubject.SelectedValue

                Dt1 = DLExamhallAllocation.GetPublishData(EL)

                If Dt1.Rows.Count = 0 Then
                    lblMsg.Text = ""
                    lblErrorMsg.Text = "No records to Publish."
                Else
                    msg = "<p><b>"
                    msg = msg + "Following Rooms are allocated for examination batch " + ddlExamBatch.SelectedItem.Text + "</p>"
                    msg = msg + "<table><tr> "
                    msg = msg + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Exam Batch" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Room" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Subject Name" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Student From" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + "Student To" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + " Exam Time" + "</td>" + "<td  style=""border-style: solid; border-width: thin; font-weight: bold; font-size: small;"">" + " Exam Date" + "</td>" + "</tr><tr>"
                    For i As Integer = 0 To Dt1.Rows.Count - 1
                        For j As Integer = 0 To Dt1.Columns.Count - 1
                            msg = msg + "<td  style=""border-style: solid; font-weight : normal; border-width: thin"">" + Dt1.Rows(i)(j).ToString + "</td>"
                            BL.ChangeFlagMap(EL)
                        Next
                        msg = msg + "</tr><tr style=""border-style: solid: solid; border-width: thin"">"

                    Next

                    msg = Trim(msg + "</tr></table>")
                    DLExamResources.publish(msg)
                    lblMsg.Text = "Data is published in Notice Board."
                    lblMsg.Visible = True
                    lblErrorMsg.Text = ""

                End If

            End If
        Else

            lblErrorMsg.Text = "You do not belong to this branch, Cannot publish data."
            lblMsg.Text = ""
        End If

    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        Dim Check As String
        If txtPassword.Text = Session("Password") Then
            Dim ExamBatchId As Integer
            ExamBatchId = ddlExamBatch.SelectedValue
            '1
            If DLExamhallAllocation.CountData(ExamBatchId).Tables(0).Rows(0).Item(0) = "N" Then
                Dim roweffected As Integer = DLExamhallAllocation.LockData(ExamBatchId)
                If roweffected > 0 Then
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    lblErrorMsg.Visible = False
                    lblMsg.Visible = True
                    lblMsg.Text = roweffected.ToString + " record(s) Locked."
                    DisplayGrid()
                    GridView1.Enabled = False

                    Image1.Visible = True
                    Image2.Visible = True
                End If
                '1
            Else

                Dim i As String
                i = Session("UserRole")
                'Dim checkUnlock As String
                ' dt1 = DLNew_StudentMarks.CheckUnlockStatus(role)
                '2
                If Session("SecurityCheck") = "Security Check" Then

                    Dt = DLExamhallAllocation.GetunlockData(i)
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
                            Dim roweffected As Integer = DLExamhallAllocation.UnLockData(ExamBatchId)
                            If roweffected > 0 Then
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                lblErrorMsg.Visible = False
                                lblMsg.Visible = True
                                lblMsg.Text = roweffected.ToString + " record(s) Unlocked."
                                DisplayGrid()
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
                    Dim roweffected As Integer = DLExamhallAllocation.UnLockData(ExamBatchId)
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

            Dt2 = DLExamhallAllocation.CountData1(ExamBatchId)

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


  
End Class
