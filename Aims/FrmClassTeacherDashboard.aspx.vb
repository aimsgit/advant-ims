
Partial Class FrmClassTeacherDashboard
    Inherits BasePage
    Dim dt, dt1, dt2 As New DataTable
    Dim DL As New DLClassTeacher

    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'GvTimeTable.Columns.Clear()
        LinkButton1.Focus()
        Dim Lecturer As Integer
        'Lecturer = ddlEmpname.SelectedValue
        'Lecturer = Session("EmpID")
        If Session("EmpID") = "" Then
            Lecturer = 0
            Exit Sub
        Else
            Lecturer = Session("EmpID")
        End If

        dt = DL.TeacherDashboard(Lecturer)
        If dt.Rows.Count = 0 Then
            GridclassTeacherDashBoard.DataSource = Nothing
            GridclassTeacherDashBoard.DataBind()
            lblerrmsg.Text = "No records to display."
            lblStudentsta.Visible = False
            lblmsgifo.Text = ""
        Else
            GridclassTeacherDashBoard.DataSource = dt
            GridclassTeacherDashBoard.DataBind()
            GridclassTeacherDashBoard.Visible = True
            lblStudentsta.Visible = True
            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
        End If
        LinkButton1.Focus()
        dt1 = DL.SubjectHours(Lecturer)
        If dt1.Rows.Count = 0 Then
            GVSubjectHours.DataSource = Nothing
            GVSubjectHours.DataBind()
            lblerrmsg.Text = "No records to display."
            lblList.Visible = False
            lblmsgifo.Text = ""
        Else
            GVSubjectHours.DataSource = dt1
            GVSubjectHours.DataBind()
            GVSubjectHours.Visible = True
            lblList.Visible = True
            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
        End If
        LinkButton1.Focus()
        dt2 = DL.TimeTable(Lecturer)
        'If dt1.Rows.Count <> 0 And dt.Rows.Count <> 0 And dt2.Rows.Count <> 0 Then

        If dt2.Rows.Count = 0 Then
            GvTimeTable.DataSource = Nothing
            GvTimeTable.DataBind()
            lblerrmsg.Text = "No records to display."
            lblTimetable.Visible = False
            lblmsgifo.Text = ""
        Else
            GvTimeTable.DataSource = dt2
            GvTimeTable.DataBind()
            LinkButton1.Focus()
            GvTimeTable.Visible = True
            lblTimetable.Visible = True
            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            'End If
        End If
        For Each grid As GridViewRow In GvTimeTable.Rows
            If CType(grid.FindControl("Label3"), Label).Text = "" Then
                CType(grid.FindControl("Label31"), Label).Text = ""
            End If
            If CType(grid.FindControl("Label7"), Label).Text = "" Then
                CType(grid.FindControl("Label32"), Label).Text = ""
            End If
            If CType(grid.FindControl("Label11"), Label).Text = "" Then
                CType(grid.FindControl("Label33"), Label).Text = ""
            End If
            If CType(grid.FindControl("Label15"), Label).Text = "" Then
                CType(grid.FindControl("Label34"), Label).Text = ""
            End If
            If CType(grid.FindControl("Label19"), Label).Text = "" Then
                CType(grid.FindControl("Label35"), Label).Text = ""
            End If
            If CType(grid.FindControl("Label23"), Label).Text = "" Then
                CType(grid.FindControl("Label36"), Label).Text = ""
            End If
            If CType(grid.FindControl("Label27"), Label).Text = "" Then
                CType(grid.FindControl("Label37"), Label).Text = ""
            End If

        Next
        If dt1.Rows.Count <> 0 And dt1.Rows.Count <> 0 And dt1.Rows.Count <> 0 Then
            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
        End If
        'GvTimeTable.Columns.Clear()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim heading As String
            heading = Session("RptFrmTitleName")
            Me.Lblheading.Text = heading
            lblList.Visible = False
            lblStudentsta.Visible = False
            lblTimetable.Visible = False
        Catch ex As Exception
            Response.Redirect("LogIn.aspx")
        End Try
        lblempname1.Text = Session("EmpName")
    End Sub
    Protected Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Response.Redirect("Default2.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    'Protected Sub ddlEmpname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpname.TextChanged
    '    'GvTimeTable.Columns.Clear()
    'End Sub
End Class
