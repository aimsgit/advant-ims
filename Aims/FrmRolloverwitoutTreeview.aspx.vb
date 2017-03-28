Imports System.IO
Imports System.Collections.Generic
Imports System.Data
Imports StudentManager
Partial Class FrmRolloverwitoutTreeview
    Inherits BasePage
    Dim GlobalFunction As New GlobalFunction
    Dim Chk As Boolean = False
    Dim bl As New BLRollOver
    Dim el As New ELRollOver
    Dim dt As New DataTable
    Dim dl As New CourseDB
    Sub Clear()

        GVRollOver.Visible = False
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        'el.TOBRANCH = Session("BranchCode")
        'dt = CourseDB.GetDataCourse(el.TOBRANCH)
        'ddlToCourse.DataSource = dt
        'ddlToCourse.DataBind()
        If IsPostBack = False Then
            ddlFromCourse.Focus()
            msginf.Text = ""
            'btnRollOver.Visible = False
            'btnClear.Visible = False
            'btnLock.Visible = False
            txtDate.Text = Format(Today, "dd-MMM-yyyy")
            txtfrmBranch.Text = Session("BranchName")

            txtDate.Enabled = False
            txtfrmBranch.Enabled = False
            btntransfer.Enabled = False
            ddlToBrch.Enabled = False
            el.TOBRANCH = Session("BranchCode")
            dt = CourseDB.GetDataCourse(el.TOBRANCH)
            ddlToCourse.DataSource = dt
            ddlToCourse.DataBind()
            Image1.Visible = True
            Image2.Visible = True
        End If
    End Sub
    Sub CheckAll()
        If CType(GVRollOver.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVRollOver.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVRollOver.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Sub CheckAll2()
        If CType(GVRollOver2.HeaderRow.FindControl("ChkAll2"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVRollOver2.Rows
                CType(grid.FindControl("ChkRL2"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVRollOver2.Rows
                CType(grid.FindControl("ChkRL2"), CheckBox).Checked = False
            Next
        End If
    End Sub

    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlFromBatch_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFromBatch.PreRender
        If ddlFromBatch.Items.Count > 0 Then
            If ddlFromBatch.Items(0).Text <> "Select" Then
                ddlFromBatch.Items.Insert(0, "Select")
            End If
        Else
            ddlFromBatch.Items.Insert(0, "Select")
        End If
    End Sub

    Protected Sub ddlFromBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFromBatch.SelectedIndexChanged
        lblmsg.Text = ""
        lblpassError.Text = ""
        Dim parts As String() = ddlFromBatch.SelectedValue.Split(New Char() {":"})
        el.BatchId = parts(0).ToString
        If ddlFromBatch.SelectedItem.Text = "Select" Then
            GVRollOver.Visible = False
            Exit Sub
        End If
        dt = bl.GetForumBatch(el)
        If dt.Rows(0).Item("Forum") = "N" Then
            dispgrid()
            GVRollOver.Visible = True
        Else
            dispgrid4()
            GVRollOver.Visible = True
        End If
    End Sub

    Sub dispgrid()
        LinkButton1.Focus()
        Dim dt As New DataTable
        Dim parts As String() = ddlFromBatch.SelectedValue.Split(New Char() {":"})
        el.BatchId = parts(0).ToString

        dt = bl.FromStudentGrid(el)
        If dt.Rows.Count = 0 Then
            GVRollOver.DataSource = Nothing
            GVRollOver.DataBind()
            msginf.Text = "No records to display."
            lblmsg.Text = ""
        Else
            GVRollOver.DataSource = dt
            GVRollOver.DataBind()
            GVRollOver.Visible = True
            msginf.Text = ""
        End If
    End Sub
    Protected Sub btnRollOver_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRollOver.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim id As String = ""
            Dim id1 As String = ""
            Dim check As String = ""
            Dim check1 As String = ""

            Dim count As New Integer
            count = 0
            For Each grid As GridViewRow In GVRollOver.Rows
                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("HiddenField1"), HiddenField).Value.ToString
                    check1 = CType(grid.FindControl("lblStdCode"), Label).Text.ToString

                    id = check + "," + id
                    id1 = check1 + "," + id1
                    count = count + 1
                End If
            Next


            If id = "" Then
                id = "0"
                count = 0
            Else
                id = Left(id, id.Length - 1)
            End If

            If id1 = "" Then
                id1 = "0"
                count = 0
            Else
                id1 = Left(id1, id1.Length - 1)
            End If
            Dim code As String
            code = id1
            If count <= 0 Then

                msginf.Text = "Select the Student(s)."
                lblmsg.Text = ""
            Else
                Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                el.BatchId = parts(0).ToString
                el.Academicyr = parts(1).ToString
                el.StdCode = code
                dt = bl.GetDuplicateRollOver(el)


                lblmsg.Text = ""
                If dt.Rows.Count > 0 Then
                    msginf.Text = "Deselect the Students who have already been Rolled Over."
                    lblmsg.Text = ""

                Else
                    Dim parts1 As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                    el.BatchId = parts1(0).ToString
                    el.Academicyr = parts1(1).ToString
                    el.CourseId = ddlToCourse.SelectedValue
                    el.Id = id
                    bl.RollOver(el)
                    lblmsg.Text = "Student(s) Rolled Over Successfully."
                    msginf.Text = ""
                    dispgrid2()
                    dispgrid()
                    GVRollOver2.Visible = True
                    GVRollOver.Visible = True
                End If
            End If
        Else
            msginf.Text = "You do not belong to this branch, Cannot rollover data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub dispgrid2()
        LinkButton1.Focus()
        Dim dt As New DataTable
        Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
        el.BatchId = parts(0).ToString
        dt = bl.ToStudentGrid(el)

        el.Lock = bl.LockStatus(el)

        If dt.Rows.Count = 0 Then
            GVRollOver2.DataSource = Nothing
            GVRollOver2.DataBind()
            msginf.Text = "No records to display."
            lblmsg.Text = ""
        Else
            msginf.Text = ""
            If el.Lock = "Y" Then
                GVRollOver2.DataSource = dt
                GVRollOver2.DataBind()
                GVRollOver2.Visible = True
                GVRollOver2.Enabled = False
                GVRollOver.Visible = False
            Else
                GVRollOver2.DataSource = dt
                GVRollOver2.DataBind()
                GVRollOver2.Visible = True
                GVRollOver2.Enabled = True
                GVRollOver.Visible = False
            End If
        End If


    End Sub
    Sub dispgrid3()
        LinkButton1.Focus()
        Dim dt As New DataTable
        Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
        el.BatchId = parts(0).ToString
        dt = bl.ToStudentGridForum(el)

        el.Lock = bl.LockStatusForum(el)

        If dt.Rows.Count = 0 Then
            GVRollOver2.DataSource = Nothing
            GVRollOver2.DataBind()
            msginf.Text = "No records to display."
            lblmsg.Text = ""
        Else
            msginf.Text = ""
            If el.Lock = "Y" Then
                GVRollOver2.DataSource = dt
                GVRollOver2.DataBind()
                GVRollOver2.Visible = True
                GVRollOver2.Enabled = False
                GVRollOver.Visible = False
            Else
                GVRollOver2.DataSource = dt
                GVRollOver2.DataBind()
                GVRollOver2.Visible = True
                GVRollOver2.Enabled = True
                GVRollOver.Visible = False
            End If
        End If


    End Sub
    Sub dispgrid4()
        LinkButton1.Focus()
        Dim dt As New DataTable
        Dim parts As String() = ddlFromBatch.SelectedValue.Split(New Char() {":"})
        el.BatchId = parts(0).ToString
        dt = bl.ToStudentGridForum(el)

        el.Lock = bl.LockStatusForum(el)

        If dt.Rows.Count = 0 Then
            GVRollOver2.DataSource = Nothing
            GVRollOver2.DataBind()
            msginf.Text = "No records to display."
            lblmsg.Text = ""
        Else
            msginf.Text = ""
            If el.Lock = "Y" Then
                GVRollOver.DataSource = dt
                GVRollOver.DataBind()
                GVRollOver.Visible = True
                GVRollOver.Enabled = False
                GVRollOver.Visible = False
            Else
                GVRollOver.DataSource = dt
                GVRollOver.DataBind()
                GVRollOver.Visible = True
                GVRollOver.Enabled = True
                GVRollOver.Visible = False
            End If
        End If


    End Sub

    Protected Sub ddlToBatch_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToBatch.PreRender
        If ddlToBatch.Items.Count > 0 Then
            If ddlToBatch.Items(0).Text <> "Select" Then
                ddlToBatch.Items.Insert(0, "Select")
            End If
        Else
            ddlToBatch.Items.Insert(0, "Select")
        End If
    End Sub

    Protected Sub ddlToBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToBatch.SelectedIndexChanged
        lblmsg.Text = ""
        lblpassError.Text = ""
        Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
        el.BatchId = parts(0).ToString
        If ddlToBatch.SelectedItem.Text = "Select" Then
            GVRollOver2.Visible = False
            Exit Sub
        End If
        dt = bl.GetForumBatch(el)
        If dt.Rows(0).Item("Forum") = "N" Then
            dispgrid2()
            GVRollOver.Visible = True
        Else
            dispgrid3()
            GVRollOver.Visible = True
        End If
    End Sub

    Protected Sub btnLock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ControlsPanel.Visible = False
            PasswordPanel.Visible = True
            txtPassword.Focus()
            Image1.Visible = False
            Image2.Visible = False
        Else
            msginf.Text = "You do not belong to this branch, Cannot lock/unlock data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If txtPassword.Text = Session("Password") Then
            Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
            el.BatchId = parts(0).ToString
            el.Lock = bl.lockunlock(el)
            If el.Lock = "N" Then

                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                GVRollOver2.Enabled = True
                msginf.Text = ""
                lblmsg.Text = " Records Unlocked."
                Image1.Visible = True
                Image2.Visible = True
            Else
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                GVRollOver2.Enabled = False
                msginf.Text = ""
                lblmsg.Text = " Records Locked."
                Image1.Visible = True
                Image2.Visible = True
            End If
        ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
            ControlsPanel.Visible = True
            PasswordPanel.Visible = False
            msginf.Text = "Password Incorrect."
            lblmsg.Text = ""
            Image1.Visible = True
            Image2.Visible = True
        End If
        btnLock.Focus()
    End Sub

    Protected Sub btnRollBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRollBack.Click



        If (Session("BranchCode") = Session("ParentBranch")) Then
            If RbTYPE.SelectedValue = "Roll Over" Then
                Dim id As String = ""
                Dim check As String = ""
                Dim count As New Integer
                count = 0
                For Each grid As GridViewRow In GVRollOver2.Rows
                    If CType(grid.FindControl("ChkRL2"), CheckBox).Checked = True Then
                        check = CType(grid.FindControl("stdcode"), Label).Text.ToString
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


                If count <= 0 Then

                    msginf.Text = "Select the Student(s)"
                    lblmsg.Text = ""
                Else
                    Dim parts As String() = ddlFromBatch.SelectedValue.Split(New Char() {":"})
                    el.BatchId = parts(0).ToString

                    el.Id = id
                    Dim parts2 As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                    el.ToBatchId = parts2(0).ToString

                    bl.RollBack(el)

                    dispgrid()
                    dispgrid2()
                    lblmsg.Text = "Student(s) Rolled Back Successfully."
                    msginf.Text = ""
                    GVRollOver.Visible = True
                    GVRollOver2.Visible = True
                End If
            Else

                Dim id As String = ""
                Dim check As String = ""
                Dim count As New Integer
                count = 0
                For Each grid As GridViewRow In GVRollOver2.Rows
                    If CType(grid.FindControl("ChkRL2"), CheckBox).Checked = True Then

                        check = CType(grid.FindControl("STD_ID"), HiddenField).Value.ToString
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


                If count <= 0 Then

                    msginf.Text = "Select the Student(s)"
                    lblmsg.Text = ""
                Else
                    Dim parts As String() = ddlFromBatch.SelectedValue.Split(New Char() {":"})
                    el.ToBatchId = parts(0).ToString

                    el.Id = id
                    Dim parts2 As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                    el.BatchId = parts2(0).ToString
                    el.Id = id
                    dt = bl.GetForumBatch(el)
                    If dt.Rows(0).Item("Forum") = "Y" Then


                        bl.DeleteForum(el)


                        lblmsg.Text = "Student(s) Rolled Back Successfully."
                        msginf.Text = ""
                        dispgrid3()
                        dispgrid()
                        GVRollOver2.Visible = True
                        GVRollOver.Visible = True
                    Else
                        lblmsg.Text = ""
                        msginf.Text = "Please select the forum batch."
                    End If
                End If
            End If
        Else

            msginf.Text = "You do not belong to this branch, Cannot rollback data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub ddlFromCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFromCourse.SelectedIndexChanged
        ddlFromBatch.ClearSelection()
        GVRollOver.Visible = False
    End Sub

    'Protected Sub ddlToCourse_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToCourse.PreRender
    '    If ddlToCourse.Items.Count > 0 Then
    '        If ddlToCourse.Items(0).Text <> "Select" Then
    '            ddlToCourse.Items.Insert(0, "Select")
    '        End If
    '    Else
    '        ddlToCourse.Items.Insert(0, "Select")
    '    End If
    'End Sub

    Protected Sub ddlToCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToCourse.SelectedIndexChanged
        ddlToBatch.ClearSelection()
        GVRollOver2.Visible = False
        lblmsg.Text = ""
        msginf.Text = ""
    End Sub

    Protected Sub GVRollOver_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVRollOver.PageIndexChanging

        GVRollOver.PageIndex = e.NewPageIndex
        dispgrid()

    End Sub

    Protected Sub GVRollOver2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVRollOver2.PageIndexChanging

        GVRollOver2.PageIndex = e.NewPageIndex
        dispgrid2()

    End Sub

    Protected Sub ddlFromBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFromBatch.TextChanged
        ddlFromBatch.Focus()
    End Sub

    Protected Sub ddlFromCourse_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlFromCourse.TextChanged
        ddlFromCourse.Focus()
    End Sub

    Protected Sub ddlToBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToBatch.TextChanged
        ddlToBatch.Focus()
    End Sub

    Protected Sub ddlToCourse_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToCourse.TextChanged
        ddlToCourse.Focus()
    End Sub

    Protected Sub RbTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbTYPE.SelectedIndexChanged
        'GVRollOver.Visible = False
        'GVRollOver2.Visible = False
        'GVRollOver.DataSource = Nothing
        'GVRollOver2.DataSource = Nothing
        'ddlFromCourse.ClearSelection()
        'ddlFromBatch.ClearSelection()
        'ddlToCourse.ClearSelection()
        'ddlToBatch.ClearSelection()
        If RbTYPE.SelectedValue = "Roll Over" Then
            ddlFromCourse.Focus()
            btnLock.Enabled = True
            btnRollBack.Enabled = True
            btnRollOver.Enabled = True
            btntransfer.Enabled = False
            txtDate.Enabled = False
            txtfrmBranch.Enabled = False
            ddlToBrch.Enabled = False
            lblmsg.Text = ""
            msginf.Text = ""
            el.TOBRANCH = Session("BranchCode")
            btnStdBatchTransfer.Enabled = False
            dt = CourseDB.GetDataCourse(el.TOBRANCH)
            ddlToCourse.DataSource = dt
            ddlToCourse.DataBind()
            ddlToBrch.ClearSelection()
            'GVRollOver.Visible = True
            'GVRollOver2.Visible = True
        ElseIf RbTYPE.SelectedValue = "Branch Transfer" Then
            ddlFromCourse.Focus()
            btnLock.Enabled = False
            btnRollBack.Enabled = False
            btnRollOver.Enabled = False
            btntransfer.Enabled = True
            txtDate.Enabled = True
            txtfrmBranch.Enabled = False
            ddlToBrch.Enabled = True
            lblmsg.Text = ""
            msginf.Text = ""
            btnStdBatchTransfer.Enabled = False
            el.TOBRANCH = ddlToBrch.SelectedValue
            dt = CourseDB.GetDataCourse(el.TOBRANCH)
            ddlToCourse.DataSource = dt
            ddlToCourse.DataBind()
            ddlToBrch.ClearSelection()
            'GVRollOver.Visible = True
            'GVRollOver2.Visible = True
        ElseIf RbTYPE.SelectedValue = "Batch Transfer" Then
            ddlFromCourse.Focus()
            btnLock.Enabled = False
            btnRollBack.Enabled = False
            btnRollOver.Enabled = False
            btntransfer.Enabled = False
            txtDate.Enabled = False
            txtfrmBranch.Enabled = False
            ddlToBrch.Enabled = False
            btnStdBatchTransfer.Enabled = True
            lblmsg.Text = ""
            msginf.Text = ""
            ddlToBrch.SelectedValue = Session("BranchCode")
            el.TOBRANCH = ddlToBrch.SelectedValue
            dt = CourseDB.GetDataCourse(el.TOBRANCH)
            ddlToCourse.DataSource = dt
            ddlToCourse.DataBind()
            ddlToBrch.SelectedValue = Session("BranchCode")
            'GVRollOver.Visible = True
            'GVRollOver2.Visible = True
        ElseIf RbTYPE.SelectedValue = "Forum Transfer" Then
            ddlFromCourse.Focus()
            btnLock.Enabled = False
            btnRollBack.Enabled = True
            btnRollOver.Enabled = False
            btntransfer.Enabled = False
            txtDate.Enabled = False
            txtfrmBranch.Enabled = False
            ddlToBrch.Enabled = False
            btnStdBatchTransfer.Enabled = False
            btnforum.Enabled = True
            lblmsg.Text = ""
            msginf.Text = ""
            ddlToBrch.SelectedValue = Session("BranchCode")
            el.TOBRANCH = ddlToBrch.SelectedValue
            dt = CourseDB.GetDataCourse(el.TOBRANCH)
            ddlToCourse.DataSource = dt
            ddlToCourse.DataBind()
            ddlToBrch.SelectedValue = Session("BranchCode")
            'GVRollOver.Visible = True
            'GVRollOver2.Visible = True
        End If
    End Sub

    Protected Sub btntransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btntransfer.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try


                Dim split As String() = ddlToBrch.SelectedItem.Text.Split(New Char() {":"})
                If txtfrmBranch.Text = split(1).ToString() Then
                    msginf.Text = "Please select the different branch."
                Else

                    ddlFromCourse.Focus()
                    Dim id As String = ""
                    Dim id1 As String = ""
                    Dim check As String = ""
                    Dim check1 As String = ""
                    Dim count As New Integer
                    count = 0
                    For Each grid As GridViewRow In GVRollOver.Rows
                        If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                            check = CType(grid.FindControl("HiddenField1"), HiddenField).Value.ToString
                            check1 = CType(grid.FindControl("lblStdCode"), Label).Text.ToString

                            id = check + "," + id
                            id1 = check1 + "," + id1
                            count = count + 1
                        End If
                    Next


                    If id = "" Then
                        id = "0"
                        count = 0
                    Else
                        id = Left(id, id.Length - 1)
                    End If

                    If id1 = "" Then
                        id1 = "0"
                        count = 0
                    Else
                        id1 = Left(id1, id1.Length - 1)
                    End If
                    Dim code As String
                    code = id1
                    If count <= 0 Then

                        msginf.Text = "Select the Student(s)."
                        lblmsg.Text = ""
                    Else
                        Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                        el.BatchId = parts(0).ToString
                        el.Academicyr = parts(1).ToString
                        el.StdCode = code
                        If ddlToBrch.SelectedValue = "Select" Then
                            msginf.Text = "To Branch field is mandatory."
                        Else
                            el.TOBRANCH = ddlToBrch.SelectedValue
                        End If

                        el.FRMBRANCH = txtfrmBranch.Text
                        el.CourseId = ddlToCourse.SelectedValue
                        dt = bl.GetDuplicateTransfer(el)

                        lblmsg.Text = ""
                        If dt.Rows.Count > 0 Then
                            msginf.Text = "Deselect the students who have already been transferred."
                            lblmsg.Text = ""

                        Else
                            Dim parts1 As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                            el.BatchId = parts1(0).ToString
                            el.Academicyr = parts1(1).ToString
                            el.FRMBRANCH = txtfrmBranch.Text
                            el.TOBRANCH = ddlToBrch.SelectedValue

                            el.Tdate = txtDate.Text
                            el.CourseId = ddlToCourse.SelectedValue
                            el.Id = id

                            For Each grid As GridViewRow In GVRollOver.Rows
                                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                                    el.Id = CType(grid.FindControl("HiddenField1"), HiddenField).Value.ToString
                                    bl.InsertRecord(el)
                                End If
                            Next
                            'bl.transfer(el)

                            msginf.Text = ""
                            dispgrid2()
                            dispgrid()
                            GVRollOver2.Visible = True
                            GVRollOver.Visible = True
                            lblmsg.Text = "Student Transfer request sent for approval."
                        End If
                    End If
                End If
            Catch ex As Exception
                msginf.Text = "Enter Valid Date."
            End Try
        Else
            msginf.Text = "You do not belong to this branch, Cannot transfer data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub ddlToBrch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToBrch.SelectedIndexChanged
        ddlToCourse.ClearSelection()
        ddlToBatch.ClearSelection()
        GVRollOver2.Visible = False
        el.TOBRANCH = ddlToBrch.SelectedValue
        dt = CourseDB.GetDataCourse(el.TOBRANCH)
        ddlToCourse.DataSource = dt
        ddlToCourse.DataBind()

    End Sub

    Protected Sub GVRollOver_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVRollOver.Sorting
        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        Dim parts As String() = ddlFromBatch.SelectedValue.Split(New Char() {":"})
        el.BatchId = parts(0).ToString
        dt = bl.FromStudentGrid(el)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVRollOver.DataSource = sortedView
        GVRollOver.DataBind()
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

    Protected Sub btnStdBatchTransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStdBatchTransfer.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim id As String = ""
            Dim id1 As String = ""
            Dim check As String = ""
            Dim check1 As String = ""

            Dim count As New Integer
            count = 0
            For Each grid As GridViewRow In GVRollOver.Rows
                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("HiddenField1"), HiddenField).Value.ToString
                    check1 = CType(grid.FindControl("lblStdCode"), Label).Text.ToString

                    id = check + "," + id
                    id1 = check1 + "," + id1
                    count = count + 1
                End If
            Next


            If id = "" Then
                id = "0"
                count = 0
            Else
                id = Left(id, id.Length - 1)
            End If

            If id1 = "" Then
                id1 = "0"
                count = 0
            Else
                id1 = Left(id1, id1.Length - 1)
            End If
            Dim code As String
            code = id1
            If count <= 0 Then

                msginf.Text = "Select the Student(s)."
                lblmsg.Text = ""
            Else
                Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                el.BatchId = parts(0).ToString
                el.Academicyr = parts(1).ToString
                el.StdCode = code
                'dt = bl.GetDuplicateRollOver(el)


                'lblmsg.Text = ""
                'If dt.Rows.Count > 0 Then
                '    msginf.Text = "Deselect the Students who have already been Rolled Over."
                '    lblmsg.Text = ""

                'Else
                Dim parts1 As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                el.BatchId = parts1(0).ToString
                el.Academicyr = parts1(1).ToString
                el.CourseId = ddlToCourse.SelectedValue
                el.Id = id
                bl.StudentBatchTransfer(el)
                dispgrid2()
                dispgrid()
                lblmsg.Text = "Student(s) Transferred Successfully."
                msginf.Text = ""
                GVRollOver2.Visible = True
                GVRollOver.Visible = True
                'End If
            End If
        Else
            msginf.Text = "You do not belong to this branch, Cannot rollover data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnforum_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnforum.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            btnforum.Enabled = True
            Dim id As String = ""
            Dim id1 As String = ""
            Dim check As String = ""
            Dim check1 As String = ""

            Dim count As New Integer
            count = 0
            For Each grid As GridViewRow In GVRollOver.Rows
                If CType(grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                    check = CType(grid.FindControl("HiddenField1"), HiddenField).Value.ToString
                    check1 = CType(grid.FindControl("lblStdCode"), Label).Text.ToString

                    id = check + "," + id
                    id1 = check1 + "," + id1
                    count = count + 1
                End If
            Next


            If id = "" Then
                id = "0"
                count = 0
            Else
                id = Left(id, id.Length - 1)
            End If

            If id1 = "" Then
                id1 = "0"
                count = 0
            Else
                id1 = Left(id1, id1.Length - 1)
            End If
            Dim code As String
            code = id1
            If count <= 0 Then

                msginf.Text = "Select the Student(s)."
                lblmsg.Text = ""
            Else
                Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                el.BatchId = parts(0).ToString
                el.Academicyr = parts(1).ToString
                el.Id = id
                el.StdCode = code
                dt = bl.GetDuplicateForum(el)


                lblmsg.Text = ""
                If dt.Rows.Count > 0 Then
                    msginf.Text = "Deselect the Students who have already been transferred."
                    lblmsg.Text = ""

                Else
                    Dim parts1 As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                    el.BatchId = parts1(0).ToString
                    el.Academicyr = parts1(1).ToString
                    el.CourseId = ddlToCourse.SelectedValue
                    el.Id = id
                    dt = bl.GetForumBatch(el)
                    If dt.Rows(0).Item("Forum") = "Y" Then
                        bl.Forum(el)
                        lblmsg.Text = "Student(s) transferred to forum batch successfully."
                        msginf.Text = ""
                        dispgrid3()
                        dispgrid()
                        GVRollOver2.Visible = True
                        GVRollOver.Visible = True
                    Else
                        lblmsg.Text = ""
                        msginf.Text = "Please select the forum batch."
                    End If

                End If
            End If
        Else
            msginf.Text = "You do not belong to this branch, Cannot rollover data."
            lblmsg.Text = ""
        End If
    End Sub



End Class
