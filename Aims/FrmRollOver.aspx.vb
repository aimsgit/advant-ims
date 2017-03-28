Imports System.IO
Imports System.Collections.Generic
Imports System.Data
Imports StudentManager
Partial Class FrmRollOver
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
            msginf.Text = ValidationMessage(1014)
            'btnRollOver.Visible = False
            'btnClear.Visible = False
            'btnLock.Visible = False
            txtDate.Text = Format(Today, "dd-MMM-yyyy")
            txtfrmBranch.Text = Session("BranchName")
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
        'If Not IsPostBack Then

        'End If
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
       dt= bl.GetForumBatch(el)
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
            msginf.Text = ValidationMessage(1023)
            lblmsg.Text = ValidationMessage(1014)
        Else
            GVRollOver.DataSource = dt
            GVRollOver.DataBind()
            GVRollOver.Visible = True
            msginf.Text = ValidationMessage(1014)
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

                msginf.Text = ValidationMessage(1157)
                lblmsg.Text = ValidationMessage(1014)
            Else
                Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                el.BatchId = parts(0).ToString
                el.Academicyr = parts(1).ToString
                el.StdCode = code
                dt = bl.GetDuplicateRollOver(el)


                lblmsg.Text = ValidationMessage(1014)
                If dt.Rows.Count > 0 Then
                    msginf.Text = ValidationMessage(1158)
                    lblmsg.Text = ValidationMessage(1014)

                Else
                    Dim parts1 As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                    el.BatchId = parts1(0).ToString
                    el.Academicyr = parts1(1).ToString
                    el.CourseId = ddlToCourse.SelectedValue
                    el.Tdate = txtDate.Text
                    el.Id = id
                    bl.RollOver(el)
                    lblmsg.Text = ValidationMessage(1159)
                    msginf.Text = ValidationMessage(1014)
                    dispgrid2()
                    dispgrid()
                    GVRollOver2.Visible = True
                    GVRollOver.Visible = True
                End If
            End If
        Else
            msginf.Text = ValidationMessage(1160)
            lblmsg.Text = ValidationMessage(1014)
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
            msginf.Text = ValidationMessage(1023)
            lblmsg.Text = ValidationMessage(1014)
        Else
            msginf.Text = ValidationMessage(1014)
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

            msginf.Text = ValidationMessage(1023)
            lblmsg.Text = ValidationMessage(1014)
        Else
            msginf.Text = ValidationMessage(1014)
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

            msginf.Text = ValidationMessage(1023)
            lblmsg.Text = ValidationMessage(1014)
        Else
            msginf.Text = ValidationMessage(1014)
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
        lblmsg.Text = ValidationMessage(1014)
        lblpassError.Text = ValidationMessage(1014)
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
            msginf.Text = ValidationMessage(1101)
            lblmsg.Text = ValidationMessage(1014)
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
                msginf.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1104)
                Image1.Visible = True
                Image2.Visible = True
            Else
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                GVRollOver2.Enabled = False
                msginf.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1103)
                Image1.Visible = True
                Image2.Visible = True
            End If
        ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
            ControlsPanel.Visible = True
            PasswordPanel.Visible = False
            msginf.Text = ValidationMessage(1106)
            lblmsg.Text = ValidationMessage(1014)
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
                Dim parts As String() = ddlFromBatch.SelectedValue.Split(New Char() {":"})
                el.BatchId = parts(0).ToString

                el.Id = id
                Dim parts2 As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                el.ToBatchId = parts2(0).ToString

                For Each grid As GridViewRow In GVRollOver2.Rows
                    If CType(grid.FindControl("ChkRL2"), CheckBox).Checked = True Then
                        check = CType(grid.FindControl("stdcode"), Label).Text.ToString
                        id = check
                        el.Id = id
                        bl.RollBack(el)
                    End If
                Next

                'If id = "" Then
                '    id = "0"
                '    count = 0
                'Else
                '    id = Left(id, id.Length - 1)
                'End If


                'If count <= 0 Then

                '    msginf.Text = ValidationMessage(1157)
                '    lblmsg.Text = ValidationMessage(1014)
                'Else
                '    Dim parts As String() = ddlFromBatch.SelectedValue.Split(New Char() {":"})
                '    el.BatchId = parts(0).ToString

                'el.Id = id
                'Dim parts2 As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                'el.ToBatchId = parts2(0).ToString

                'bl.RollBack(el)

                dispgrid()
                dispgrid2()
                lblmsg.Text = ValidationMessage(1161)
                msginf.Text = ValidationMessage(1014)
                GVRollOver.Visible = True
                GVRollOver2.Visible = True
                'End If
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

                    msginf.Text = ValidationMessage(1157)
                    lblmsg.Text = ValidationMessage(1014)
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


                        lblmsg.Text = ValidationMessage(1161)
                        msginf.Text = ValidationMessage(1014)
                        dispgrid3()
                        dispgrid()
                        GVRollOver2.Visible = True
                        GVRollOver.Visible = True
                    Else
                        lblmsg.Text = ValidationMessage(1014)
                        msginf.Text = ValidationMessage(1162)
                    End If
                End If
            End If
        Else

            msginf.Text = ValidationMessage(1163)
            lblmsg.Text = ValidationMessage(1014)
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
        lblmsg.Text = ValidationMessage(1014)
        msginf.Text = ValidationMessage(1014)
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

        GVRollOver.Visible = False
        GVRollOver2.Visible = False

        'GVRollOver.DataSource = Nothing
        'GVRollOver2.DataSource = Nothing
        ddlFromCourse.Items.Clear()
        ddlFromCourse.DataSourceID = "ObjCourse2"
        ddlFromCourse.DataBind()
        'ddlFromCourse.SelectedValue = 0
        'ddlFromBatch.SelectedValue = 0
        'ddlToCourse.SelectedValue = 0
        'ddlToBatch.SelectedValue = 0
        If RbTYPE.SelectedValue = "Roll Over" Then
            ddlFromCourse.Focus()
            btnLock.Enabled = True
            btnRollBack.Enabled = True
            btnRollOver.Enabled = True
            btntransfer.Enabled = False
            txtDate.Enabled = True
            txtfrmBranch.Enabled = False
            btncoursetransfer.Enabled = False
            ddlToBrch.Enabled = False
            lblmsg.Text = ValidationMessage(1014)
            msginf.Text = ValidationMessage(1014)
            el.TOBRANCH = Session("BranchCode")
            btnStdBatchTransfer.Enabled = False
            dt = CourseDB.GetDataCourse(el.TOBRANCH)
            ddlToCourse.DataSource = dt
            ddlToCourse.DataBind()
            ddlToBrch.ClearSelection()
            btnforum.Enabled = False
            'GVRollOver.Visible = True
            'GVRollOver2.Visible = True
        ElseIf RbTYPE.SelectedValue = "Branch Transfer" Then
            ddlFromCourse.Focus()
            btnLock.Enabled = True
            btnRollBack.Enabled = False
            btnRollOver.Enabled = False
            btntransfer.Enabled = True
            txtDate.Enabled = True
            txtfrmBranch.Enabled = False
            ddlToBrch.Enabled = True
            lblmsg.Text = ValidationMessage(1014)
            msginf.Text = ValidationMessage(1014)
            btnStdBatchTransfer.Enabled = False
            btncoursetransfer.Enabled = False
            el.TOBRANCH = ddlToBrch.SelectedValue
            dt = CourseDB.GetDataCourse(el.TOBRANCH)
            ddlToCourse.DataSource = dt
            ddlToCourse.DataBind()

            ddlToBrch.ClearSelection()
            btnforum.Enabled = False
            'GVRollOver.Visible = True
            'GVRollOver2.Visible = True
        ElseIf RbTYPE.SelectedValue = "Batch Transfer" Then
            ddlFromCourse.Focus()
            btnLock.Enabled = True
            btnRollBack.Enabled = False
            btnRollOver.Enabled = False
            btntransfer.Enabled = False
            txtDate.Enabled = True
            txtfrmBranch.Enabled = False
            ddlToBrch.Enabled = False
            btnStdBatchTransfer.Enabled = True
            btncoursetransfer.Enabled = False
            lblmsg.Text = ValidationMessage(1014)
            msginf.Text = ValidationMessage(1014)
            ddlToBrch.SelectedValue = Session("BranchCode")
            el.TOBRANCH = ddlToBrch.SelectedValue
            dt = CourseDB.GetDataCourse(el.TOBRANCH)
            ddlToCourse.DataSource = dt
            ddlToCourse.DataBind()
            ddlToBrch.SelectedValue = Session("BranchCode")
            'GVRollOver.Visible = True
            'GVRollOver2.Visible = True
            btnforum.Enabled = False
        ElseIf RbTYPE.SelectedValue = "Add To Forum" Then
            ddlFromCourse.Focus()
            'btnLock.Enabled = True
            btnRollBack.Enabled = True
            btnRollOver.Enabled = False
            btntransfer.Enabled = False
            txtDate.Enabled = True
            txtfrmBranch.Enabled = False
            ddlToBrch.Enabled = False
            btnStdBatchTransfer.Enabled = False
            btncoursetransfer.Enabled = False
            btnforum.Enabled = True
            lblmsg.Text = ValidationMessage(1014)
            msginf.Text = ValidationMessage(1014)
            ddlToBrch.SelectedValue = Session("BranchCode")
            el.TOBRANCH = ddlToBrch.SelectedValue
            dt = CourseDB.GetDataCourse(el.TOBRANCH)
            ddlToCourse.DataSource = dt
            ddlToCourse.DataBind()

            ddlToBrch.SelectedValue = Session("BranchCode")
            'GVRollOver.Visible = True
            'GVRollOver2.Visible = True
        ElseIf RbTYPE.SelectedValue = "Course Transfer" Then
            ddlFromCourse.Focus()
            btnLock.Enabled = True
            btnRollBack.Enabled = False
            btnRollOver.Enabled = False
            btncoursetransfer.Enabled = True
            btntransfer.Enabled = False
            txtDate.Enabled = True
            txtfrmBranch.Enabled = False
            ddlToBrch.Enabled = False
            lblmsg.Text = ValidationMessage(1014)
            msginf.Text = ValidationMessage(1014)
            el.TOBRANCH = Session("BranchCode")
            btnStdBatchTransfer.Enabled = False
            dt = CourseDB.GetDataCourse(el.TOBRANCH)
            ddlToCourse.DataSource = dt
            ddlToCourse.DataBind()

            ddlToBrch.ClearSelection()
            btnforum.Enabled = False
            'GVRollOver.Visible = True
            'GVRollOver2.Visible = True
        End If
    End Sub

    Protected Sub btntransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btntransfer.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try


                Dim split As String() = ddlToBrch.SelectedItem.Text.Split(New Char() {":"})
                If txtfrmBranch.Text = split(1).ToString() Then
                    msginf.Text = ValidationMessage(1170)
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

                        msginf.Text = ValidationMessage(1157)
                        lblmsg.Text = ValidationMessage(1014)
                    Else
                        Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                        el.BatchId = parts(0).ToString
                        el.Academicyr = parts(1).ToString
                        el.StdCode = code
                        If ddlToBrch.SelectedValue = "Select" Then
                            msginf.Text = ValidationMessage(1164)
                        Else
                            el.TOBRANCH = ddlToBrch.SelectedValue
                        End If

                        el.FRMBRANCH = txtfrmBranch.Text
                        el.CourseId = ddlToCourse.SelectedValue
                        dt = bl.GetDuplicateTransfer(el)

                        lblmsg.Text = ValidationMessage(1014)
                        If dt.Rows.Count > 0 Then
                            msginf.Text = ValidationMessage(1165)
                            lblmsg.Text = ValidationMessage(1014)

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

                            msginf.Text = ValidationMessage(1014)
                            dispgrid2()
                            dispgrid()
                            GVRollOver2.Visible = True
                            GVRollOver.Visible = True
                            lblmsg.Text = ValidationMessage(1166)
                        End If
                    End If
                End If
            Catch ex As Exception
                msginf.Text = ValidationMessage(1055)
            End Try
        Else
            msginf.Text = ValidationMessage(1167)
            lblmsg.Text = ValidationMessage(1014)
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
            ViewState("dirState") = Value
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

                msginf.Text = ValidationMessage(1157)
                lblmsg.Text = ValidationMessage(1014)
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
                lblmsg.Text = ValidationMessage(1168)
                msginf.Text = ValidationMessage(1014)
                GVRollOver2.Visible = True
                GVRollOver.Visible = True
                'End If
            End If
        Else
            msginf.Text = ValidationMessage(1160)
            lblmsg.Text = ValidationMessage(1014)
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

                msginf.Text = ValidationMessage(1157)
                lblmsg.Text = ValidationMessage(1014)
            Else
                Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                el.BatchId = parts(0).ToString
                el.Academicyr = parts(1).ToString
                el.Id = id
                el.StdCode = code
                dt = bl.GetDuplicateForum(el)


                lblmsg.Text = ValidationMessage(1014)
                If dt.Rows.Count > 0 Then
                    msginf.Text = ValidationMessage(1165)
                    lblmsg.Text = ValidationMessage(1014)

                Else
                    Dim parts1 As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                    el.BatchId = parts1(0).ToString
                    el.Academicyr = parts1(1).ToString
                    el.CourseId = ddlToCourse.SelectedValue
                    el.Id = id
                    dt = bl.GetForumBatch(el)
                    If dt.Rows(0).Item("Forum") = "Y" Then
                        bl.Forum(el)
                        lblmsg.Text = ValidationMessage(1169)
                        msginf.Text = ValidationMessage(1014)
                        dispgrid3()
                        dispgrid()
                        GVRollOver2.Visible = True
                        GVRollOver.Visible = True
                    Else
                        lblmsg.Text = ValidationMessage(1014)
                        msginf.Text = ValidationMessage(1162)
                    End If
                    
                End If
            End If
        Else
            msginf.Text = ValidationMessage(1160)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub btncoursetransfer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncoursetransfer.Click
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

                msginf.Text = ValidationMessage(1157)
                lblmsg.Text = ValidationMessage(1014)
            Else
                Dim parts As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                el.BatchId = parts(0).ToString
                el.Academicyr = parts(1).ToString
                el.StdCode = code
                dt = bl.GetDuplicateRollOver(el)


                lblmsg.Text = ValidationMessage(1014)
                If dt.Rows.Count > 0 Then
                    msginf.Text = ValidationMessage(1158)
                    lblmsg.Text = ValidationMessage(1014)

                Else
                    Dim parts1 As String() = ddlToBatch.SelectedValue.Split(New Char() {":"})
                    el.BatchId = parts1(0).ToString
                    el.Academicyr = parts1(1).ToString
                    el.CourseId = ddlToCourse.SelectedValue
                    el.Tdate = txtDate.Text
                    el.Id = id
                    bl.CourseTransfer(el)
                    dispgrid2()
                    dispgrid()
                    lblmsg.Text = ValidationMessage(1168)
                    msginf.Text = ValidationMessage(1014)
                    GVRollOver2.Visible = True
                    GVRollOver.Visible = True
                End If
            End If
        Else
            msginf.Text = ValidationMessage(1160)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub
    'Code written fro multilingual by Niraj on 18 Nov 2013
    ''Retriving the text of controls based on Language

    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        Try
            dt2 = Session("ValidationTable")
            If dt2 Is Nothing Then
                Response.Redirect("LogIn.aspx")
            End If
            Dim X As Integer = dt2.Rows.Count() - 1
            Dim str As String = " "
            For i As Integer = 0 To X
                If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                    Return dt2.Rows(i).Item("MessageText").ToString()
                End If
            Next
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
        Return 0
    End Function
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub
End Class
