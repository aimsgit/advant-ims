
Partial Class FrmSemesterResultTable1
    Inherits BasePage
    Dim EL As New ELSemesterResultTable
    Dim dt As New DataTable
    Dim BL As New BLSemesterResultTable
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'EL.A_Year = cmbAcademic.SelectedValue
            EL.Batch = ddlbatch.SelectedValue
            EL.Semester = cmbSemester.SelectedValue
            If BL.InsertSemesterTable(EL) > 0 Then
                dt = BL.ViewSemesterTable(EL)
                If dt.Rows.Count > 0 Then
                    GVSemmesterResultTable.DataSource = dt
                    GVSemmesterResultTable.DataBind()
                    GVSemmesterResultTable.Visible = True
                    'If BL.CheckLockMarks(EL).Tables(0).Rows(0).Item(0) = "Y" Then
                    '    GVSemmesterResultTable.Enabled = False
                    'Else
                    '    GVSemmesterResultTable.Enabled = True
                    'End If
                Else
                    msginfo.Text = ""
                    lblmsg.Text = ""
                    msginfo.Text = "No records to display."
                    GVSemmesterResultTable.Visible = False
                End If
                msginfo.Text = ""
                lblmsg.Text = ""
                lblmsg.Text = dt.Rows.Count().ToString + " records generated."
            Else
                msginfo.Text = ""
                lblmsg.Text = ""
                msginfo.Text = "Data Already Generated."
                GVSemmesterResultTable.Visible = True
            End If
        Else
            msginfo.Text = "You do not belong to this branch, cannot generate data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        LinkButton1.Focus()
        disp()
    End Sub
    Sub disp()
        EL.Batch = ddlbatch.SelectedValue
        EL.Semester = cmbSemester.SelectedValue
        dt = BL.ViewSemesterTable(EL)
        If dt.Rows.Count > 0 Then
            GVSemmesterResultTable.DataSource = dt
            GVSemmesterResultTable.DataBind()
            GVSemmesterResultTable.Visible = True
            If BL.CheckLockMarks(EL).Tables(0).Rows(0).Item(0) = "Y" Then
                GVSemmesterResultTable.Enabled = False
            Else
                GVSemmesterResultTable.Enabled = True
            End If
            lblmsg.Text = ""
            msginfo.Text = ""
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
            GVSemmesterResultTable.Visible = False
        End If
    End Sub

    Protected Sub btnLock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Batch = ddlbatch.SelectedValue
            EL.Semester = cmbSemester.SelectedValue
            dt = BL.ViewSemesterTable(EL)
            GVSemmesterResultTable.DataSource = dt
            GVSemmesterResultTable.DataBind()
            If dt.Rows.Count > 0 Then
                msginfo.Text = ""
                lblmsg.Text = ""
                ControlsPanel.Visible = False
                PasswordPanel.Visible = True
                txtPassword.Focus()
                lblpassError.Text = ""
                Image1.Visible = False
                Image2.Visible = False
            Else
                msginfo.Text = ""
                lblmsg.Text = ""
                msginfo.Text = "No Records to Lock/Unlock."
                Image1.Visible = True
                Image2.Visible = True
            End If
        Else
            msginfo.Text = "You do not belong to this branch, cannot lock/unlock data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Session("BranchCode") = Session("ParentBranch")) Then

            If txtPassword.Text = Session("Password") Then
                EL.Batch = ddlbatch.SelectedValue
                EL.Semester = cmbSemester.SelectedValue
                dt = BL.ViewSemesterTable(EL)
                If BL.CheckLockMarks(EL).Tables(0).Rows(0).Item(0) = "N" Then
                    Dim roweffected As Integer = BL.LockStdMarks(EL)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        msginfo.Text = ""
                        lblmsg.Text = ""

                        lblmsg.Text = dt.Rows.Count().ToString + " records Locked."
                        BtnAddStd.Enabled = False
                        GVSemmesterResultTable.Enabled = False
                        Image1.Visible = True
                        Image2.Visible = True
                    End If
                Else
                    Dim roweffected As Integer = BL.UNLockStdMarks(EL)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        msginfo.Text = ""
                        lblmsg.Text = ""
                        lblmsg.Text = dt.Rows.Count().ToString + " records Unlocked."
                        BtnAddStd.Enabled = True
                        GVSemmesterResultTable.Enabled = True
                        Image1.Visible = True
                        Image2.Visible = True
                    End If
                End If
                ''End If

            ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                msginfo.Text = "Password Incorrect."
                lblmsg.Text = ""
                Image1.Visible = True
                Image2.Visible = True
            End If

        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
        btnLock.Focus()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVSemmesterResultTable_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSemmesterResultTable.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GVSemmesterResultTable.Rows(e.RowIndex).Cells(1).FindControl("lblId"), Label).Text
            If DLSemesterResultTable.ChangeFlag(EL) Then
                msginfo.Text = ""
                lblmsg.Text = "Data Deleted Successfully."
                GVSemmesterResultTable.PageIndex = ViewState("PageIndex")
                disp()
                GVSemmesterResultTable.Enabled = True
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GVSemmesterResultTable_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVSemmesterResultTable.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        EL.Batch = ddlbatch.SelectedValue
        EL.Semester = cmbSemester.SelectedValue
        dt = BL.ViewSemesterTable(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVSemmesterResultTable.DataSource = sortedView
        GVSemmesterResultTable.DataBind()
        GVSemmesterResultTable.Visible = True
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

    Protected Sub BtnAddStd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddStd.Click
        EL.Batch = ddlbatch.SelectedValue
        EL.Semester = cmbSemester.SelectedValue
        EL.Stdid = ddlStudent.SelectedValue
        If (BL.CheckLockMarks(EL).Tables(0).Rows.Count > 0) Then
            If BL.CheckLockMarks(EL).Tables(0).Rows(0).Item(0) = "N" Then

                dt = DLSemesterResultTable.getduplicate(EL)
                If dt.Rows.Count <= 0 Then
                    lblmsg.Text = ""
                    msginfo.Text = "Records are not generated for the Batch."
                Else
                    EL.Stdid = ddlStudent.SelectedValue
                    dt = DLSemesterResultTable.getduplicateIndStd(EL)
                    If dt.Rows.Count > 0 Then
                        lblmsg.Text = ""
                        msginfo.Text = "Data Already Exists."
                    Else
                        EL.Stdid = ddlStudent.SelectedValue
                        DLSemesterResultTable.InsertSemesterTableIndStd(EL)
                        msginfo.Text = ""
                        lblmsg.Text = "Data Saved Successfully."
                        disp()
                    End If
                End If
            Else
                lblmsg.Text = ""
                msginfo.Text = "Records are locked, cannot add data."
            End If
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records generated."
        End If
    End Sub

    Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
    End Sub
End Class
