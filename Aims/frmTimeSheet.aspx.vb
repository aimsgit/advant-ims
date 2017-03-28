
Partial Class frmTimeSheet
    Inherits BasePage
    Dim TP As New TimeSheetEL
    Dim TPB As New TimeSheetBL
    Dim dt As DataTable

    ''Code written By-Ajit Kumar Singh
    ''Date-20-Feb-2013

    Protected Sub BtnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAdd.Click


        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try

         
                TP.EmpID = ddlEmployeeName.SelectedValue
                TP.BatchID = ddlBatchName.SelectedValue
                TP.SemesterID = ddlSemester.SelectedValue
                TP.SubjectID = ddlSubject.SelectedValue
                TP.TopicID = ddlTopic.SelectedValue
                If txtDate.Text = "" Then
                    TP.Date1 = "1/1/1900"
                ElseIf CDate(txtDate.Text) > Today.Date Then
                    msginfo.Text = ""
                    lblmsg.Text = "Date can not be greater than today's date."
                    Exit Sub
                Else
                    TP.Date1 = txtDate.Text
                End If
                If txtTime.Text = "" Then
                    TP.time = CDate("1/1/1900")
                Else
                    TP.time = CDate(CDate("1/1/1901") + " " + FormatDateTime(CDate(txtTime.Text), DateFormat.ShortTime))
                End If

              
                If txtPeriod.Text = "" Then
                    TP.Period = 0
                Else
                    TP.Period = txtPeriod.Text
                End If
                If txtDuration.Text = "" Then
                    TP.Duration = 0
                Else
                    TP.Duration = txtDuration.Text
                End If
                TP.WorkDescription = txtWorkDescription.Text

                If BtnAdd.Text = "UPDATE" Then
                    TP.ID = ViewState("TPID")
                    TPB.UpdateRecord(TP)
                    BtnAdd.Text = "ADD"
                    BtnView.Text = "VIEW"
                    'clear()
                    lblmsg.Text = ""
                    msginfo.Text = "Data Updated Successfully."
                    GridView1.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    GridView1.Enabled = "true"
                    clear()

                ElseIf BtnAdd.Text = "ADD" Then

                    TPB.InsertRecord(TP)
                    lblmsg.Text = ""
                    msginfo.Text = "Data Saved Successfully."
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    DisplayGrid()
                    clear()
                End If
            Catch ex As Exception
                lblmsg.Text = "Data is not valid."
                msginfo.Text = ""
            End Try
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot add/update data."
            msginfo.Text = ""
        End If
    End Sub
   
    Sub DisplayGrid()
        Try
            TP.ID = 0
            If txtDate.Text = "" Then
                TP.Date1 = "1/1/1900"
            Else
                TP.Date1 = txtDate.Text
            End If
            TP.EmpID = ddlEmployeeName.SelectedValue
            TP.BatchID = ddlBatchName.SelectedValue
            TP.SemesterID = ddlSemester.SelectedValue
            TP.SubjectID = ddlSubject.SelectedValue
            TP.TopicID = ddlTopic.SelectedValue
        Catch ex As Exception
            msginfo.Text = ""
            lblmsg.Text = "Data is not valid."
            Exit Sub
        End Try
        dt = TPB.GetTimeSheet(TP)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblDate1"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblDate1"), Label).Text = ""
                End If
            Next
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblTime"), Label).Text = "12:00 AM" Then
                    CType(rows.FindControl("lblTime"), Label).Text = ""
                End If
            Next
            GridView1.Visible = "true"
            LinkButton1.Focus()
        Else
            lblmsg.Text = "No records to display."
            msginfo.Text = ""
            GridView1.Visible = "False"
        End If

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
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'f.id = CType(Grdfeehead.Rows(e.RowIndex).Cells(1).FindControl("Label5"), Label).Text
            TP.ID = CType(GridView1.Rows(e.RowIndex).FindControl("TPID"), Label).Text
            TPB.ChangeFlag(TP)
            GridView1.DataBind()
            lblmsg.Text = ""
            msginfo.Text = "Data Deleted Successfully."
            GridView1.PageIndex = ViewState("PageIndex")
            'DisplayGrid()
            TP.ID = 0
            If txtDate.Text = "" Then
                TP.Date1 = "1/1/1900"
            Else
                TP.Date1 = txtDate.Text
            End If
            TP.EmpID = ddlEmployeeName.SelectedValue
            TP.BatchID = ddlBatchName.SelectedValue
            TP.SemesterID = ddlSemester.SelectedValue
            TP.SubjectID = ddlSubject.SelectedValue
            TP.TopicID = ddlTopic.SelectedValue
            dt = TPB.GetTimeSheet(TP)

            GridView1.DataSource = dt
            GridView1.DataBind()
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblDate1"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblDate1"), Label).Text = ""
                End If
            Next
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblTime"), Label).Text = "12:00 AM" Then
                    CType(rows.FindControl("lblTime"), Label).Text = ""
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

        msginfo.Text = ""
        lblmsg.Text = ""
        GridView1.Enabled = "false"
        ddlEmployeeName.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEmpID"), Label).Text
        ddlBatchName.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblBatchID"), Label).Text

        ddlSemester.Items.Clear()
        ddlSemester.DataSourceID = "ObjSemester"
        ddlSemester.DataBind()
        ddlSemester.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSemID"), Label).Text
        ddlSubject.Items.Clear()
        ddlSubject.DataSourceID = "ObjSubject"
        ddlSubject.DataBind()
        ddlSubject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSubjectID"), Label).Text
        ddlTopic.Items.Clear()
        ddlTopic.DataSourceID = "ObjTopic"
        ddlTopic.DataBind()
        ddlTopic.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblTopicID"), Label).Text

        txtDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDate1"), Label).Text
        'If date11 = "01-Jan-1900" Then
        '    txtDate.Text = ""
        'Else
        '    txtDate.Text = date11
        'End If
        txtTime.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblTime"), Label).Text
        'If time11 = "12:00 AM" Then
        '    txtTime.Text = ""
        'Else
        '    txtPeriod.Text = time11
        'End If
        txtPeriod.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPeriod1"), Label).Text
        txtDuration.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDuration"), Label).Text
        txtWorkDescription.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblWorkDescription"), Label).Text
        ViewState("TPID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("TPID"), Label).Text
        BtnAdd.Text = "UPDATE"
        BtnView.Text = "BACK"

        Dim dt As New DataTable

        TP.ID = ViewState("TPID")
        If txtDate.Text = "" Then
            TP.Date1 = "1/1/1900"
        Else
            TP.Date1 = txtDate.Text
        End If
        dt = TPB.GetTimeSheet(TP)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Visible = True
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblDate1"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblDate1"), Label).Text = ""
            End If
        Next
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblTime"), Label).Text = "12:00 AM" Then
                CType(rows.FindControl("lblTime"), Label).Text = ""
            End If
        Next
        GridView1.Visible = "true"
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = "False" Then
            txtDate.Text = Format(Date.Today, "dd-MMM-yyyy")
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
        Dim dt As New DataTable
        TP.ID = 0
        If txtDate.Text = "" Then
            TP.Date1 = "1/1/1900"
        Else
            TP.Date1 = txtDate.Text
        End If
        TP.EmpID = ddlEmployeeName.SelectedValue
        TP.BatchID = ddlBatchName.SelectedValue
        TP.SemesterID = ddlSemester.SelectedValue
        TP.SubjectID = ddlSubject.SelectedValue
        TP.TopicID = ddlTopic.SelectedValue
        dt = TPB.GetTimeSheet(TP)
        GridView1.DataSource = dt
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True

        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblDate1"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblDate1"), Label).Text = ""
            End If
        Next
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblTime"), Label).Text = "12:00 AM" Then
                CType(rows.FindControl("lblTime"), Label).Text = ""
            End If
        Next
        GridView1.Visible = "true"
        LinkButton1.Focus()
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

    Protected Sub ddlBatchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
        ddlBatchName.Focus()
    End Sub

    Protected Sub ddlEmployeeName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmployeeName.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
        ddlEmployeeName.Focus()
    End Sub

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

    Protected Sub ddlTopic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTopic.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
        ddlTopic.Focus()
    End Sub
    Public Sub clear()
        txtTime.Text = ""
        txtPeriod.Text = ""
        txtDuration.Text = ""
        txtWorkDescription.Text = ""
        txtDate.Text = ""
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGrid()
    End Sub
End Class
