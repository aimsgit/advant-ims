
Partial Class FrmQuestionBank
    Inherits BasePage
    Dim sda, sda1, sda2, sda5 As New OleDbDataAdapter()
    Dim sdt, sdt1, sdt2, sdt5 As New DataTable()
    Dim alt As String
    Dim objBusErrMesg As New busErrorMessage
    Dim bl As New BLQuestionBank
    Dim el As New ELQuestionBank
    Dim dt As New DataTable
    Dim path, path1 As String
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then

            txtDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
        If Image2.ImageUrl = "" Then
            Image2.ImageUrl = "~\Images\imageupload.gif"
        End If
    End Sub
    Protected Sub Upload_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Upload.Click
        If FileUpload1.FileName <> "" Then
            If FileUpload1.PostedFile.ContentLength <= 30000 Then
                Try
                    If ViewState("ImageTime") <> Nothing Then
                        'Dim Foto As String = Replace(ViewState("ImageTime"), "~/", "")
                        Dim Foto As String = Session("Path") + ViewState("ImageTime").ToString.Replace("~/", "")
                        If IO.File.Exists(Foto) Then
                            IO.File.Delete(Foto)
                        End If
                    End If

                    lblRed.Text = ValidationMessage(1014)
                    lblGreen.Text = ValidationMessage(1014)
                    path = "E" & txtQNo.Text.Trim.ToString().Replace(" ", "") + TimeOfDay.ToString().Replace("/", "").Replace(":", "") & ".jpg"
                    Me.FileUpload1.SaveAs(Server.MapPath("~/Images/" & path))
                    path1 = "~/Images/" & path
                    ViewState("ImageTime") = "~/Images/" & path
                    txtpath.Text = path1
                    Me.ImageMap1.ImageUrl = txtpath.Text
                Catch ex As Exception
                    lblGreen.Text = ValidationMessage(1014)
                    lblRed.Text = ValidationMessage(1135)
                End Try
            Else
                lblRed.Text = ValidationMessage(1120)
                lblGreen.Text = ValidationMessage(1014)
            End If
        Else
            lblRed.Text = ValidationMessage(1121)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                el.Q_date = txtDate.Text
                el.CourseId = ddlCourse.SelectedValue
                el.SubjectId = ddlSubject.SelectedValue
                el.Q_Type = ddlQType.SelectedValue
                el.Q_No = txtQNo.Text
                el.Ques = txtQuestion.Text
                el.Ans = txtAnswer.Text
                el.Q_SubNo = txtSubQuesNo.Text
                If ViewState("ImageTime") = Nothing Then
                    el.APhoto = ""
                Else
                    el.APhoto = ViewState("ImageTime")

                End If
                If btnadd.CommandName = "UPDATE" Then
                    el.id = ViewState("QuesBank_AutoId")
                    'dt = bl.CheckDuplicate(el)
                    If dt.Rows.Count > 0 Then
                        lblGreen.Text = ValidationMessage(1030)
                        lblRed.Text = ValidationMessage(1014)
                    Else
                        bl.UpdateRecord(el)
                        lblRed.Text = ValidationMessage(1014)
                        btnadd.CommandName = "ADD"
                        btnDet.CommandName = "VIEW"
                        lblGreen.Text = ValidationMessage(1017)
                        GvQuesbank.PageIndex = ViewState("PageIndex")
                        DisplayGrid()
                        clear()
                    End If
                ElseIf btnadd.CommandName = "ADD" Then
                    'dt = bl.CheckDuplicate(el)
                    If dt.Rows.Count > 0 Then
                        lblRed.Visible = True
                        lblRed.Text = ValidationMessage(1030)
                        lblGreen.Text = ValidationMessage(1014)
                    Else
                        'el.Id = ViewState("HM_ID")
                        bl.InsertRecord(el)

                        'GvQuesbank.DataBind()
                        lblRed.Text = ValidationMessage(1014)
                        lblGreen.Visible = True
                        btnadd.CommandName = "ADD"
                        lblGreen.Text = ValidationMessage(1020)
                        ViewState("PageIndex") = 0
                        GvQuesbank.PageIndex = 0
                        DisplayGrid()
                        lblGreen.Visible = True
                        clear()
                        'End If
                        DisplayGrid()
                    End If
                End If
            Catch ex As Exception
                lblRed.Text = ValidationMessage(1022)
                lblGreen.Text = ValidationMessage(1014)
            End Try
        Else
            lblRed.Text = ValidationMessage(1021)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub DisplayGrid()
        Dim dt As New DataTable
        el.id = 0
        dt = bl.getQuestionBank(el)
        GvQuesbank.DataSource = dt
        GvQuesbank.DataBind()
        GvQuesbank.Visible = True
        GvQuesbank.Enabled = True

        If dt.Rows.Count = 0 Then
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1023)
            lblRed.Visible = True
        End If
    End Sub
    Sub clear()
        txtSubQuesNo.Text = ""
        txtQuestion.Text = ""
        txtAnswer.Text = ""
        ImageMap1.ImageUrl = "~\Images\imageupload.gif"
        txtpath.Text = ""
        ViewState("ImageTime") = ""
    End Sub
    Protected Sub btnDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click
        If btnDet.CommandName <> "BACK" Then
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GvQuesbank.PageIndex = 0
            DisplayGrid()
            GvQuesbank.Visible = True
        Else
            clear()
            'Enable()
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1014)
            btnDet.CommandName = "VIEW"
            btnadd.CommandName = "ADD"
            clear()
            GvQuesbank.Visible = True
            'Disable()
            GvQuesbank.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GvQuesbank_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvQuesbank.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            el.id = CType(GvQuesbank.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            bl.ChangeFlag(el)

            lblGreen.Text = ValidationMessage(1028)
            txtDate.Focus()
            lblRed.Text = ValidationMessage(1014)
            GvQuesbank.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        Else
            lblRed.Text = ValidationMessage(1029)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GvQuesbank_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvQuesbank.RowEditing
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
        txtDate.Text = CType(GvQuesbank.Rows(e.NewEditIndex).FindControl("lblDate"), Label).Text
        ddlCourse.SelectedValue = CType(GvQuesbank.Rows(e.NewEditIndex).FindControl("lblCourseId"), Label).Text
        ddlSubject.Items.Clear()
        ddlSubject.DataSourceID = "ObjSubject"
        ddlSubject.DataBind()
        ddlSubject.SelectedValue = CType(GvQuesbank.Rows(e.NewEditIndex).FindControl("lblSubjectId"), Label).Text
        ddlQType.SelectedValue = CType(GvQuesbank.Rows(e.NewEditIndex).FindControl("lblQuesType"), Label).Text
        txtQNo.Text = CType(GvQuesbank.Rows(e.NewEditIndex).FindControl("lblQuesNo"), Label).Text
        txtQuestion.Text = CType(GvQuesbank.Rows(e.NewEditIndex).FindControl("lblQuestion"), Label).Text
        txtAnswer.Text = CType(GvQuesbank.Rows(e.NewEditIndex).FindControl("lblAnswer"), Label).Text
        txtSubQuesNo.Text = CType(GvQuesbank.Rows(e.NewEditIndex).FindControl("lblSubQuesNo"), Label).Text
        ViewState("QuesBank_AutoId") = CType(GvQuesbank.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        ViewState("ImageTime") = CType(GvQuesbank.Rows(e.NewEditIndex).FindControl("LabelPhotos1"), Label).Text.Trim
        ImageMap1.ImageUrl = CType(GvQuesbank.Rows(e.NewEditIndex).FindControl("LabelPhotos1"), Label).Text.Trim

        btnadd.CommandName = "UPDATE"
        btnDet.CommandName = "BACK"
        el.id = ViewState("QuesBank_AutoId")
        dt = bl.getQuestionBank(el)
        GvQuesbank.DataSource = dt
        GvQuesbank.DataBind()
        GvQuesbank.Enabled = False

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
    Sub CheckAll()
        If CType(GvQuesbank.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GvQuesbank.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GvQuesbank.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Protected Sub Btnposttostock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnposttostock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim id As String = ""
            Dim check As String = ""

            Dim count As New Integer
            count = 0
            For Each grid As GridViewRow In GvQuesbank.Rows
                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("IID"), HiddenField).Value
                    id = check + "," + id
                    count = count + 1
                End If
            Next
            If id = "" Then
                id = "0"
                count = 0
            Else
                id = Left(id, id.Length - 1)
            End If
            Dim role As String
            role = Session("UserRole")
            'dt = DayBookDB.PostCheck(role)
            'If dt.Rows.Count > 0 Then
            If count = 0 Then
                lblRed.Text = ValidationMessage(1139)
                lblGreen.Text = ValidationMessage(1014)
            Else
                el.ChkID = id
                bl.PostQuestion(el)
                lblGreen.Text = ValidationMessage(1123)
                lblRed.Text = ValidationMessage(1014)
                DisplayGrid()
            End If
            'Else
            '    lblErrorMsg.Text = "Not Authorized to Post."
            '    Lblmsg.Text = ""
            'End If
        Else
            lblRed.Text = "You do not belong to this branch, Cannot post data."
            lblGreen.Text = ""
        End If
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        ddlCourse.Focus()
    End Sub

    Protected Sub ddlSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.SelectedIndexChanged
        ddlSubject.Focus()
    End Sub
End Class
