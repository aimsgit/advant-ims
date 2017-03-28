
Partial Class frmLessonPlan
    Inherits BasePage
    Dim LP As New LessonPlanEL
    Dim LPB As New LessonPlanBL
    Dim dt As DataTable

    ''Code written By-Ajit Kumar Singh
    ''Date-20-Feb-2013
    ' Unit&Portion field Added by Siddharth
    'Date-17-Sep-2013

    Protected Sub BtnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Click


        If (Session("BranchCode") = Session("ParentBranch")) Then

            Try
                'LP.EmpID = ddlEmployeeName.SelectedValue
                LP.Courseid = ddlCourse.SelectedValue
                LP.SemesterID = ddlSemester.SelectedValue
                LP.SubjectID = ddlSubject.SelectedValue
                LP.Unit = txtUnit.Text
                If txtPortion.Text = "" Then
                    LP.Portion = 0
                Else
                    LP.Portion = txtPortion.Text
                End If
                If txtFromDate.Text = "" Then
                    LP.FromDate = "1/1/1900"
                Else
                    LP.FromDate = txtFromDate.Text
                End If
                If txtToDate.Text = "" Then
                    LP.ToDate = "1/1/1900"
                Else
                    LP.ToDate = txtToDate.Text
                End If
                If txtFromDate.Text = "" Or txtToDate.Text = "" Then
                Else
                    If CDate(txtFromDate.Text) > CDate(txtToDate.Text) Then
                        lblmsg.Text = "From date can not be greater than to Date."
                        msginfo.Text = ""
                        Exit Sub
                    End If
                End If
                
                LP.Topic = txtTopic.Text

                If txtTopicHours.Text = "" Then
                    LP.TopicHrs = 0
                Else
                    LP.TopicHrs = txtTopicHours.Text
                End If

                LP.Week = txtWeek.Text

                If BtnAdd.Text = "UPDATE" Then
                    LP.ID = ViewState("LPID")
                    LPB.UpdateRecord(LP)
                    BtnAdd.Text = "ADD"
                    BtnView.Text = "VIEW"
                    clear()
                    lblmsg.Text = ""
                    msginfo.Text = "Data Updated Successfully."
                    GridView1.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    GridView1.Enabled = "true"
                ElseIf BtnAdd.Text = "ADD" Then

                    LPB.InsertRecord(LP)
                    lblmsg.Text = ""
                    msginfo.Text = "Data Saved Successfully."
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    DisplayGrid()
                    clear()
                End If
            Catch ex As Exception
                lblmsg.Text = "Date is not valid."
                msginfo.Text = ""
            End Try
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot add/update data."
            msginfo.Text = ""
        End If
    End Sub
    Public Sub clear()
        txtTopic.Text = ""
        txtFromDate.Text = ""
        txtToDate.Text = ""
        txtTopicHours.Text = ""
        txtWeek.Text = ""
        txtPortion.Text = ""
    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        msginfo.Text = ""
        lblmsg.Text = ""
        If BtnView.Text = "VIEW" Then
            DisplayGrid()
            'clear()
        Else
            BtnView.Text = "VIEW"
            BtnAdd.Text = "ADD"
            clear()
            DisplayGrid()
            GridView1.Enabled = "True"
        End If
    End Sub
    Sub DisplayGrid()
        Try

            LP.ID = 0
            'LP.EmpID = ddlEmployeeName.SelectedValue
            LP.Courseid = ddlCourse.SelectedValue
            LP.SemesterID = ddlSemester.SelectedValue
            LP.SubjectID = ddlSubject.SelectedValue
        Catch ex As Exception
            msginfo.Text = ""
            lblmsg.Text = "Date is not valid."
            Exit Sub
        End Try

        dt = LPB.GetLessonPlan(LP)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblFromDate"), Label).Text = ""
                End If
                If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblToDate"), Label).Text = ""
                End If
            Next
            GridView1.Visible = "true"
            LinkButton1.Focus()
        Else
            lblmsg.Text = "No records to display."
            msginfo.Text = ""
            GridView1.Visible = "False"
        End If
        LinkButton1.Focus()
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'f.id = CType(Grdfeehead.Rows(e.RowIndex).Cells(1).FindControl("Label5"), Label).Text
            LP.ID = CType(GridView1.Rows(e.RowIndex).FindControl("LPID"), Label).Text
            LPB.ChangeFlag(LP)
            GridView1.DataBind()
            lblmsg.Text = ""
            msginfo.Text = "Data Deleted Successfully."
            GridView1.PageIndex = ViewState("PageIndex")
            'DisplayGrid()
            LP.ID = 0
            'LP.EmpID = ddlEmployeeName.SelectedValue
            LP.Courseid = ddlCourse.SelectedValue
            LP.SemesterID = ddlSemester.SelectedValue
            LP.SubjectID = ddlSubject.SelectedValue

            dt = LPB.GetLessonPlan(LP)

            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblFromDate"), Label).Text = ""
                End If
                If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblToDate"), Label).Text = ""
                End If
            Next
            GridView1.Visible = "true"
            LinkButton1.Focus()
            clear()
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot delete data."
            msginfo.Text = ""
        End If

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim Todate As String
        Dim Fromdate As String

        msginfo.Text = ""
        lblmsg.Text = ""
        GridView1.Enabled = "false"
        'ddlBatchName.Items.Clear()
        'ddlBatchName.DataSourceID = "ObjBatch"
        'ddlBatchName.DataBind()
        'ddlEmployeeName.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEmpID"), Label).Text
        ddlCourse.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblcourse"), Label).Text

        ddlSemester.Items.Clear()
        ddlSemester.DataSourceID = "ObjSemester"
        ddlSemester.DataBind()
        ddlSemester.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSemID"), Label).Text
        ddlSubject.Items.Clear()
        ddlSubject.DataSourceID = "ObjSubject"
        ddlSubject.DataBind()
        ddlSubject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSubjectID"), Label).Text
        txtTopic.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblTopic"), Label).Text
        txtTopicHours.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblHours"), Label).Text
        txtUnit.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblUnit"), Label).Text
        txtPortion.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPortion"), Label).Text

        Todate = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblToDate"), Label).Text
        If Todate = "01-Jan-1900" Then
            txtToDate.Text = ""
        Else
            txtToDate.Text = Todate
        End If

        Fromdate = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblFromDate"), Label).Text
        If Todate = "01-Jan-1900" Then
            txtFromDate.Text = ""
        Else
            txtFromDate.Text = Fromdate
        End If
        txtWeek.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblWeek"), Label).Text
        ViewState("LPID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("LPID"), Label).Text
        BtnAdd.Text = "UPDATE"
        BtnView.Text = "BACK"

        Dim dt As New DataTable

        LP.ID = ViewState("LPID")
        dt = LPB.GetLessonPlan(LP)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Visible = True
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblFromDate"), Label).Text = ""
            End If
            If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblToDate"), Label).Text = ""
            End If
        Next
        GridView1.Visible = "true"
    End Sub
    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        
        LP.ID = 0
        'LP.EmpID = ddlEmployeeName.SelectedValue
        LP.Courseid = ddlCourse.SelectedValue
        LP.SemesterID = ddlSemester.SelectedValue
        LP.SubjectID = ddlSubject.SelectedValue

        dt = LPB.GetLessonPlan(LP)
        GridView1.DataSource = dt
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblFromDate"), Label).Text = ""
            End If
            If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblToDate"), Label).Text = ""
            End If
        Next
        GridView1.Visible = "true"
       
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

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
        ddlCourse.Focus()
    End Sub

    'Protected Sub ddlEmployeeName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmployeeName.SelectedIndexChanged
    '    msginfo.Text = ""
    '    lblmsg.Text = ""
    '    ddlEmployeeName.Focus()
    'End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
        ddlSemester.Focus()
    End Sub

    Protected Sub ddlSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
        ddlSubject.Focus()
    End Sub
End Class
