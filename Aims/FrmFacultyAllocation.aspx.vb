'Author Anchala Verma
'Date 03-06-12
Partial Class FrmFacultyAllocation
    Inherits BasePage
    Dim EL As New ELFacultyAllocation
    Dim dt As New DataTable

    Protected Sub btngenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btngenerate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim dt As New DataTable
            EL.CourseID = ddlCourse.SelectedValue
            EL.BatchId = ddlBatch.SelectedValue
            EL.SemesterId = cmbSemester.SelectedValue
            dt = BLFacultyAllocation.getduplicate(EL)
            If dt.Rows.Count > 0 Then
                lblmsg.Text = ""
                lblerror.Text = "Data Already Exists."
                ddlCourse.Focus()
            Else
                Dim roweffected1 As Integer = BLFacultyAllocation.generate(EL)
                lblerror.Text = ""
                lblmsg.Text = roweffected1.ToString + " Rows Are Generated."
                dt = BLFacultyAllocation.GetData(EL)
                If dt.Rows.Count <> 0 Then
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    GridView1.Visible = True
                    If dt.Rows(0)("LockStatus").ToString() = "N" Then
                        GridView1.Enabled = "true"
                    Else
                        GridView1.Enabled = "false"
                    End If
                Else
                    lblmsg.Text = ""
                    lblerror.Text = "No records to generate."
                    ddlCourse.Focus()
                    GridView1.Visible = False
                End If
            End If
        Else
            lblerror.Text = "You do not belong to this branch, cannot generate data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub Dispgrid(ByVal el As ELFacultyAllocation)
        Dim dt As New Data.DataTable
        el.CourseID = ddlCourse.SelectedValue
        el.BatchId = ddlBatch.SelectedValue
        el.SemesterId = cmbSemester.SelectedValue
        dt = BLFacultyAllocation.GetData(el)
        If dt.Rows.Count <> 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            If dt.Rows(0)("LockStatus").ToString() = "N" Then
                GridView1.Enabled = "true"
            Else
                GridView1.Enabled = "false"
            End If
            For Each Grid As GridViewRow In GridView1.Rows
                CType(Grid.FindControl("DdlLecture1"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer1"), Label).Text
                CType(Grid.FindControl("DdlLecture2"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer2"), Label).Text
                CType(Grid.FindControl("DdlLecture3"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer3"), Label).Text
                CType(Grid.FindControl("DdlLecture4"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer4"), Label).Text
            Next
        Else
            lblmsg.Text = ""
            lblerror.Text = "No records to display."
            GridView1.Visible = False
        End If
    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        LinkButton1.Focus()
        lblerror.Text = ""
        lblmsg.Text = ""
        EL.CourseID = ddlCourse.SelectedValue
        EL.BatchId = ddlBatch.SelectedValue
        EL.SemesterId = cmbSemester.SelectedValue
        ViewState("PageIndex") = 0
        GridView1.PageIndex = 0
        Dispgrid(EL)
        If GridView1.Rows.Count > 0 And GridView1.Visible = True Then
            For Each Grid As GridViewRow In GridView1.Rows
                CType(Grid.FindControl("DdlLecture1"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer1"), Label).Text
                CType(Grid.FindControl("DdlLecture2"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer2"), Label).Text
                CType(Grid.FindControl("DdlLecture3"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer3"), Label).Text
                CType(Grid.FindControl("DdlLecture4"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer4"), Label).Text
            Next
        End If

    End Sub

    Protected Sub btnclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclear.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.CourseID = ddlCourse.SelectedValue
            EL.BatchId = ddlBatch.SelectedValue
            EL.SemesterId = cmbSemester.SelectedValue
            For Each grid As GridViewRow In GridView1.Rows
                EL.Lock = CType(grid.FindControl("LblLockStatus"), Label).Text

                If EL.Lock = "N" Then
                    BLFacultyAllocation.clear(EL)
                    Dispgrid(EL)
                    lblmsg.Text = "Records are Cleared."
                    ddlCourse.Focus()
                    lblerror.Text = ""

                Else
                    lblerror.Text = "Records are locked, cannot be cleared."
                    lblmsg.Text = ""
                    ddlCourse.Focus()
                    Image1.Visible = "true"
                    Image2.Visible = "true"
                End If
            Next
        Else
            lblerror.Text = "You do not belong to this branch, cannot clear data."
            lblmsg.Text = ""
        End If
    End Sub

  
    Protected Sub BTNLOCK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BTNLOCK.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Image1.Visible = "False"
            Image2.Visible = "False"
            EL.CourseID = ddlCourse.SelectedValue
            EL.BatchId = ddlBatch.SelectedValue
            EL.SemesterId = cmbSemester.SelectedValue
            dt = BLFacultyAllocation.GetData(EL)
            If dt.Rows.Count > 0 Then
                ControlsPanel.Visible = "false"
                PasswordPanel.Visible = "true"
                txtPassword.Focus()
            Else
                lblmsg.Text = ""
                lblerror.Text = "No records to be Locked."
                lblmsg.Text = ""
                ddlCourse.Focus()
                Image1.Visible = "true"
                Image2.Visible = "true"
            End If

        Else
            lblerror.Text = "You do not belong to this branch, cannot lock/unlock data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If txtPassword.Text = Session("Password") Then
                EL.CourseID = ddlCourse.SelectedValue
                EL.BatchId = ddlBatch.SelectedValue
                EL.SemesterId = cmbSemester.SelectedValue
                For Each grid As GridViewRow In GridView1.Rows
                    EL.Id = CType(grid.FindControl("Label1"), Label).Text
                    EL.Lock = CType(grid.FindControl("LblLockStatus"), Label).Text

                    lblerror.Text = ""
                    lblmsg.Text = ""
                    If EL.Lock = "N" Then
                        BLFacultyAllocation.Lock(EL)
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        lblerror.Text = ""
                        lblmsg.Text = "Records are locked."
                        Image1.Visible = "true"
                        Image2.Visible = "true"
                        ddlCourse.Focus()
                        GridView1.Enabled = False
                        EL.TeacherID1 = CType(grid.FindControl("DdlLecture1"), DropDownList).SelectedItem.Value
                        EL.TeacherID2 = CType(grid.FindControl("DdlLecture2"), DropDownList).SelectedItem.Value
                        EL.TeacherID3 = CType(grid.FindControl("DdlLecture3"), DropDownList).SelectedItem.Value
                        EL.TeacherID4 = CType(grid.FindControl("DdlLecture4"), DropDownList).SelectedItem.Value

                        Dispgrid(EL)


                    Else
                        BLFacultyAllocation.UnLock(EL)
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        lblerror.Text = ""
                        lblmsg.Text = "Records are Unlocked."
                        ddlCourse.Focus()
                        Image1.Visible = "true"
                        Image2.Visible = "true"
                        Dispgrid(EL)
                        GridView1.Enabled = True
                        EL.TeacherID1 = CType(grid.FindControl("DdlLecture1"), DropDownList).SelectedItem.Value
                        EL.TeacherID2 = CType(grid.FindControl("DdlLecture2"), DropDownList).SelectedItem.Value
                        EL.TeacherID3 = CType(grid.FindControl("DdlLecture3"), DropDownList).SelectedItem.Value
                        EL.TeacherID4 = CType(grid.FindControl("DdlLecture4"), DropDownList).SelectedItem.Value

                    End If
                Next
            Else
                lblmsg.Text = ""
                lblerror.Text = "Password Incorrect."
                Image1.Visible = "true"
                Image2.Visible = "true"
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
            End If

        Else
            lblerror.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If

    End Sub


    Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
        GridView1.Visible = False
        lblmsg.Text = ""
        lblerror.Text = ""
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        GridView1.Visible = False
        lblmsg.Text = ""
        lblerror.Text = ""
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        GridView1.Visible = False
        lblmsg.Text = ""
        lblerror.Text = ""
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Dispgrid(EL)
    End Sub

    Protected Sub ddlBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.TextChanged
        ddlBatch.Focus()
    End Sub

    Protected Sub ddlCourse_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.TextChanged
        ddlCourse.Focus()
    End Sub

    Protected Sub cmbSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.TextChanged
        cmbSemester.Focus()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlCourse.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                ViewState("PKID") = CType(GridView1.Rows(e.RowIndex).FindControl("Label1"), Label).Text
                EL.Id = ViewState("PKID")
                Dim a As New Integer
                a = CType(GridView1.Rows(e.RowIndex).FindControl("Lbltotalhours"), Label).Text
                If CType(GridView1.Rows(e.RowIndex).FindControl("Hours1"), TextBox).Text = "" Then
                    EL.Hours1 = 0
                Else
                    EL.Hours1 = CType(GridView1.Rows(e.RowIndex).FindControl("Hours1"), TextBox).Text
                End If

                If CType(GridView1.Rows(e.RowIndex).FindControl("Hours2"), TextBox).Text = "" Then
                    EL.Hours2 = 0
                Else
                    EL.Hours2 = CType(GridView1.Rows(e.RowIndex).FindControl("Hours2"), TextBox).Text
                End If

                If CType(GridView1.Rows(e.RowIndex).FindControl("Hours3"), TextBox).Text = "" Then
                    EL.Hours3 = 0
                Else
                    EL.Hours3 = CType(GridView1.Rows(e.RowIndex).FindControl("Hours3"), TextBox).Text
                End If

                If CType(GridView1.Rows(e.RowIndex).FindControl("Hours4"), TextBox).Text = "" Then
                    EL.Hours4 = 0

                Else
                    EL.Hours4 = CType(GridView1.Rows(e.RowIndex).FindControl("Hours4"), TextBox).Text
                End If
                EL.TeacherID1 = CType(GridView1.Rows(e.RowIndex).FindControl("DdlLecture1"), DropDownList).SelectedValue
                EL.TeacherID2 = CType(GridView1.Rows(e.RowIndex).FindControl("DdlLecture2"), DropDownList).SelectedValue
                EL.TeacherID3 = CType(GridView1.Rows(e.RowIndex).FindControl("DdlLecture3"), DropDownList).SelectedValue
                EL.TeacherID4 = CType(GridView1.Rows(e.RowIndex).FindControl("DdlLecture4"), DropDownList).SelectedValue
                If EL.Hours1 + EL.Hours2 + EL.Hours3 + EL.Hours4 <= a Then
                    BLFacultyAllocation.Update(EL)
                    lblmsg.Text = "Data Updated Successfully."
                    lblerror.Text = ""
                    GridView1.EditIndex = -1
                    Dispgrid(EL)
                Else
                    lblerror.Text = "Hours should not exceed than Total Hours."
                    lblmsg.Text = ""
                End If
            Catch ex As Exception
                lblerror.Text = "Enter Correct Data."
                lblmsg.Text = ""
            End Try
        Else
            lblerror.Text = "You do not belong to this branch, cannot update data."
            lblmsg.Text = ""
        End If
    End Sub
   
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
