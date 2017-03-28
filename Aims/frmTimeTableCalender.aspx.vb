
Partial Class frmTimeTableCalender
    Inherits BasePage
    Dim dt As New DataTable
    Dim El As New TimeTableEL
    Dim bl As New TimeTableBl

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        ViewState("PageIndex") = 0
        GridView1.PageIndex = 0
        DisplayGrid()

    End Sub
    Sub DisplayGrid()
        LinkButton1.Focus()
        El.CourseId = ddlCourseName.SelectedValue
        El.BatchId = ddlBatchName.SelectedValue
        El.SemId = ddlSemester.SelectedValue
        El.TeacherId = ddlTeacher.SelectedValue
        El.SubjectId = ddlSubject.SelectedValue
        Calender1.VisibleDate = Calender1.TodaysDate
        If (El.SubjectId = 0 And El.TeacherId = 0) Then
            dt = bl.ViewRecord(El)
            If dt.Rows.Count = 0 Then
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                msginfo.Text = ""
                lblmsg.Text = "No records to display."
                ddlCourseName.Focus()
            Else
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Enabled = True
                GridView1.Visible = True
            End If
        Else
            dt = bl.ViewRecord1(El)
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If dt.Rows(i).Item("SubjectID1") = 0 And dt.Rows(i).Item("SubjectID2") = 0 And dt.Rows(i).Item("SubjectID3") = 0 And dt.Rows(i).Item("SubjectID4") = 0 And dt.Rows(i).Item("SubjectID5") = 0 And dt.Rows(i).Item("SubjectID6") = 0 And dt.Rows(i).Item("SubjectID7") = 0 Then
                        msginfo.Text = ""
                        lblmsg.Text = "No records to display."
                        GridView1.Visible = False
                        ddlCourseName.Focus()

                    Else
                        GridView1.DataSource = dt
                        GridView1.DataBind()
                        GridView1.Enabled = True
                        GridView1.Visible = True
                        lblmsg.Text = ""
                    End If
                Next
            Else
                msginfo.Text = ""
                lblmsg.Text = "No records to display."
                GridView1.Visible = False
                ddlCourseName.Focus()

            End If

           
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


    Protected Sub Calendar1_DayRender(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DayRenderEventArgs) Handles Calender1.DayRender
        Try

            lblmsg.Text = ""
            msginfo.Text = ""
            dt = bl.ViewHolidayRecord(El)
            Dim lb As New Label
            If (dt.Rows.Count > 0) Then
                For i As Integer = 0 To dt.Rows.Count - 1

                    If (e.Day.Date = dt.Rows(i).Item("HolidayDate")) Then
                        e.Cell.BackColor = System.Drawing.Color.Red
                        e.Cell.ForeColor = System.Drawing.Color.White
                        'lb.Text = dt.Rows(i).Item("HolidayName")
                        e.Cell.Text = e.Day.DayNumberText + " " + dt.Rows(i).Item("HolidayName")
                        'e.Cell.Controls.Add(CType(dt.Rows(i).Item("HolidayName"), Label))
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub ddlBatchName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.TextChanged
        ddlBatchName.Focus()
    End Sub

    Protected Sub ddlCourseName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourseName.TextChanged
        ddlCourseName.Focus()
    End Sub

    Protected Sub ddlSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.TextChanged
        ddlSemester.Focus()
    End Sub

    Protected Sub ddlSubject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.TextChanged
        ddlSubject.Focus()
    End Sub

    Protected Sub ddlTeacher_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTeacher.TextChanged
        ddlTeacher.Focus()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class
