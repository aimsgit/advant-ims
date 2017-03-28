Partial Class Frm_QuestionPaper
    Inherits BasePage
    Dim dt As DataTable
    Dim dt1 As DataTable
    Dim EL As New ELQuestionPaper
    Dim BL As New BLQuestionPaper
    Dim DL As New DLQuestionPaper
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        lblMsg.Text = ValidationMessage(1014)
        lblErrorMsg.Text = ValidationMessage(1014)
        lblupmsg.Text = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If txtdate.Text = "" Then
                lblErrorMsg.Text = ValidationMessage(1055)
            Else
                EL.qdate = txtdate.Text
            End If
            If ddlQuestionNo.SelectedValue = "Select" Then
                lblErrorMsg.Text = "Select question type."
            Else
                EL.Ques_type = ddlQuestionNo.SelectedValue
            End If
            EL.section = txtsection.Text
            EL.course = ddlCourse.SelectedValue
            EL.batch = ddlBatch.SelectedValue
            EL.subject = ddlSubject.SelectedValue
            Dim str As String = ""
            Dim id As String = ""
            Dim items As ListItem
            Dim i As Integer
            i = 0
            If ListBox1.Items.Count <> 0 Then
                'If (ListBox1.Items(i).Selected = True) Then
                For Each items In ListBox1.Items

                    If (ListBox1.Items(i).Selected = True) Then
                        str = ListBox1.Items(i).Value
                        id = str + "," + id

                        'str = str + 1
                        'For i = 0 To ListBox1.Items.Count - 1
                        '    items &= ListBox1.SelectedValue(i) & ","
                        'Next
                    End If
                    i = i + 1

                Next
                If id = "" Then
                    id = "0"
                Else
                    id = Left(id, id.Length - 1)
                End If
                EL.question = id
            End If
            If id = "" Then
                lblErrorMsg.Text = "Select Question First."
                Exit Sub
            End If
            If btnAdd.Text = "ADD" Then
                EL.id = 0
                dt = BL.CheckDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    lblErrorMsg.Text = ValidationMessage(1030)
                    lblMsg.Text = ValidationMessage(1014)
                Else
                    BL.InsertQuestionPaper(EL)
                    DisplayGridView()
                    lblMsg.Text = ValidationMessage(1020)
                    clear()
                End If
            Else

                btnAdd.CommandName = "ADD"
                btnView.CommandName = "VIEW"
                EL.id = ViewState("ID")
                BL.InsertQuestionPaper(EL)
                DisplayGridView()
                lblMsg.Text = ValidationMessage(1017)
                btnUpdate.Visible = True
                clear()
            End If
        Else
            lblErrorMsg.Text = ValidationMessage(1021)
            lblMsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub DisplayGridView()
        lblMsg.Text = ValidationMessage(1014)
        lblErrorMsg.Text = ValidationMessage(1014)
        'Dim ID As Integer = 0
        Dim dt As DataTable = BL.QuestionpaperGridView(EL)
        GridView1.DataSource = dt
        If dt.Rows.Count > 0 Then
            GridView1.DataBind()
            
            GridView1.Enabled = True
            GridView1.Visible = True
            btnUpdate.Visible = True
        Else
            lblErrorMsg.Text = ValidationMessage(1023)
            
        End If
    End Sub
    Sub clear()
        'txtmino.Text = ""
        'txtdate.Text = ""
        ddlCourse.ClearSelection()
        ddlBatch.ClearSelection()
        ddlSubject.ClearSelection()
        ddlQuestionNo.ClearSelection()
        txtsection.Text = ""
        'lblMsg.Text = ValidationMessage(1014)
        'lblErrorMsg.Text = ValidationMessage(1014)
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        lblMsg.Text = ValidationMessage(1014)
        lblErrorMsg.Text = ValidationMessage(1014)
        lblupmsg.Text = ""
        If btnView.CommandName = "VIEW" Then
            DisplayGridView()
        Else
            btnAdd.CommandName = "ADD"
            btnView.CommandName = "VIEW"
            clear()
            DisplayGridView()
            btnUpdate.Visible = True

        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim dt As DataTable = BL.QuestionpaperGridView(EL)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Visible = True
        GridView1.PageIndex = e.NewPageIndex
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim rowsaffected As Integer
        lblMsg.Text = ValidationMessage(1014)
        lblErrorMsg.Text = ValidationMessage(1014)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GridView1.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
            rowsaffected = BL.DeleteQuestionpaper(EL)
            lblMsg.Text = ValidationMessage(1028)
            EL.id = 0
            Dim dt As DataTable = BL.QuestionpaperGridView(EL)
            GridView1.DataSource = dt
            GridView1.DataBind()
            
            GridView1.Enabled = True
            GridView1.Visible = True
            btnUpdate.Visible = True
            'lblMsg.Text = ""
            'lblErrorMsg.Text = ""
        Else
            lblErrorMsg.Text = ValidationMessage(1029)
            lblMsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'Dim ID As Integer
        lblMsg.Text = ValidationMessage(1014)
        lblErrorMsg.Text = ValidationMessage(1014)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            txtdate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblQuesDate"), Label).Text
            ddlCourse.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCourseId"), Label).Text
            ddlBatch.ClearSelection()
            ddlBatch.DataSourceID = "ObjBatch"
            ddlBatch.DataBind()
            ddlBatch.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblBatchId"), Label).Text
            ddlSubject.ClearSelection()
            ddlSubject.DataSourceID = "ObjSubject"
            ddlSubject.DataBind()
            ddlSubject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSubjectId"), Label).Text

            txtsection.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSection"), Label).Text
            'ddlQuestionNo.ClearSelection()
            'ddlQuestionNo.DataSourceID = "ObjQuestionNo"
            'ddlQuestionNo.DataBind()
            ddlQuestionNo.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblQuesType"), Label).Text

            ViewState("ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
            EL.id = ViewState("ID")
            Dim dt As DataTable = BL.QuestionpaperGridView(EL)
            GridView1.DataSource = dt
            GridView1.DataBind()

            GridView1.Enabled = False
            GridView1.Visible = True
            btnAdd.Text = "UPDATE"
            btnView.Text = "BACK"
            
        Else
            lblErrorMsg.Text = ValidationMessage(1024)
            lblMsg.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtdate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        'btnUpdate.Visible = False
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
    End Sub
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
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
    Protected Sub btnEql_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEql.Click
        TabContainer1.ActiveTab = TabPanel2
        Dim dt As New DataTable
        EL.section = txtsection.Text
        EL.course = ddlCourse.SelectedValue
        'EL.batch = ddlBatch.SelectedValue
        EL.subject = ddlSubject.SelectedValue
        EL.Ques_type = ddlQuestionNo.SelectedItem.Text

        dt = DL.GetQuestion(EL)
        'EL.question = dt.Rows.Item("QuesBank_AutoId1").ToString
        If dt.Rows.Count > 0 Then
            lblMsg.Text = ""
            For i As Integer = 0 To dt.Rows.Count - 1

                ListBox1.DataSource = dt
                ListBox1.DataBind()
                ListBox1.Visible = True
                ListBox1.DataTextField = "QuesBank_AutoId1"
                lblMsg.Text = ""
            Next

        Else
            lblErrMsg1.Text = "No Records to Display."
            ListBox1.Items.Clear()
        End If
    End Sub
    Protected Sub btnok_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnok.Click
        TabContainer1.ActiveTab = TabPanel1
        TabPanel1.Enabled = True
        Dim str As String = ""
        Dim id As String = ""
        Dim items As ListItem
        Dim i As Integer
        Dim j As Integer
        i = 0
        j = ListBox1.Items.Count - 1


        If ListBox1.Items.Count <> 0 Then
            'If (ListBox1.Items(i).Selected = True) Then
            For Each items In ListBox1.Items

                If (ListBox1.Items(i).Selected = True) Then
                    str = ListBox1.Items(i).Value
                    id = str + "," + id
                    'str = str + 1
                    'For i = 0 To ListBox1.Items.Count - 1
                    '    items &= ListBox1.SelectedValue(i) & ","
                    'Next
                End If
                i = i + 1
            Next
        End If
        lblErrMsg1.Text = ""

    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                For Each grid As GridViewRow In GridView1.Rows
                    EL.marks = IIf(CType(grid.FindControl("TxtMarks"), TextBox).Text = "", 0, CType(grid.FindControl("TxtMarks"), TextBox).Text)
                    EL.id = CType(grid.FindControl("HID"), HiddenField).Value
                    BL.UpdateQuestionPaperMarks(EL)
                Next
                lblupmsg.Text = "Marks updated successfully."
                lbluperrmsg.Text = ""


            Catch ex As Exception
                lbluperrmsg.Text = ""
                lblupmsg.Text = ""
                lbluperrmsg.Text = "Enter marks for all Students."
            End Try
        Else
            lbluperrmsg.Text = "You do not belong to this branch, Cannot update data."
            lblupmsg.Text = ""
        End If
           
    End Sub
    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        ddlCourse.Focus()
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        ddlBatch.Focus()
    End Sub

    Protected Sub ddlSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.SelectedIndexChanged
        ddlSubject.Focus()
    End Sub
End Class