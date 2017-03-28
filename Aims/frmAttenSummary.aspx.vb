Imports System.IO
Partial Class frmAttenSummary
    Inherits BasePage
    Dim El As New ELAttenSummary
    Dim BL As New BLAttenSummary
    Dim DL As New DLAttenSummary
    Dim Dt1, Dt2 As New DataTable

   

    Protected Sub BtnRunsummary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRunsummary.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            El.Bid = ddlBatchName.SelectedValue
            El.Sid = DDLSemester.SelectedValue
            El.SubId = cmbSubject.SelectedValue
            El.AsOnDate = txtAdate.Text
            Dt1 = BL.DuplicateSummary(El)
            If Dt1.Rows.Count > 0 Then
                msginfo.Text = "Data Already Generated."
                lblMsg.Text = ""
                btnUpdate.Enabled = True
            Else
                Dim i As Integer = BL.RunSummary(El)
                If i > 0 Then
                    Dt2 = BL.ViewSummary(El)
                    GridView1.DataSource = Dt2
                    GridView1.DataBind()
                    GridView1.Visible = True
                    btnUpdate.Enabled = True
                    lblMsg.Text = "Records Generated Successfully."
                    msginfo.Text = ""
                    Enable()
                    For Each grid As GridViewRow In GridView1.Rows
                        lblBatchAns.Text = ""
                        lblSemAns.Text = ""
                        lblDateAns.Text = ""
                        lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                        lblSemAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                        lblDateAns.Text = Left(CType(grid.FindControl("LabelAsOnDate"), Label).Text, 11)
                        pnllabel.Visible = True

                    Next
                Else
                    lblMsg.Text = ""
                    msginfo.Text = "No Records To Display."
                    GridView1.Visible = False
                    DisEnable()
                End If

            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot run summary."
            lblMsg.Text = ""
        End If

    End Sub

    Protected Sub btnVeiw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnVeiw.Click
        msginfo.Text = ""
        lblMsg.Text = ""
        El.Bid = ddlBatchName.SelectedValue
        El.Sid = DDLSemester.SelectedValue
        El.AsOnDate = txtAdate.Text
        El.SubId = cmbSubject.SelectedValue
        Dt2 = BL.ViewSummary(El)
        If Dt2.Rows.Count > 0 Then
            GridView1.DataSource = Dt2
            GridView1.DataBind()
            Enable()
            For Each grid As GridViewRow In GridView1.Rows
                lblBatchAns.Text = ""
                lblSemAns.Text = ""
                lblDateAns.Text = ""
                lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                lblSemAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                lblDateAns.Text = Left(CType(grid.FindControl("LabelAsOnDate"), Label).Text, 11)
                pnllabel.Visible = True

            Next

            GridView1.Visible = True
            btnUpdate.Enabled = True
        Else
            DisEnable()
            lblMsg.Text = ""
            msginfo.Text = "No Records to Display."
            GridView1.Visible = False
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If ddlBatchName.SelectedValue = 0 Then
                    msginfo.Text = "Batch Field is Mandatory."
                    lblMsg.Text = ""
                ElseIf DDLSemester.SelectedValue = 0 Then
                    msginfo.Text = "Semester Field is Mandatory."
                    lblMsg.Text = ""
                Else
                    El.Bid = ddlBatchName.SelectedValue
                    El.Sid = DDLSemester.SelectedValue
                    El.SubId = cmbSubject.SelectedValue
                    If BL.ChkLockSummary(El).Tables(0).Rows(0).Item(0) = "Y" Then
                        lblMsg.Text = ""
                        msginfo.Text = "Records are locked, cannot be cleared."
                    Else

                        Dim i As Integer = BL.ClearSummary(El)
                        If i > 0 Then
                            lblMsg.Text = "Records are cleared."
                            msginfo.Text = ""
                            DisEnable()
                            msginfo.Text = ""
                            GridView1.Visible = False
                            btnUpdate.Enabled = False
                        Else
                            lblMsg.Text = ""
                            msginfo.Text = "No Records To Clear."
                            GridView1.Visible = False
                            DisEnable()
                        End If

                    End If
                End If

            Catch ex As Exception
                msginfo.Text = "No Records to Clear."
                lblMsg.Text = ""
            End Try
        Else
            msginfo.Text = "You do not belong to this branch, Cannot clear data."
            lblMsg.Text = ""
        End If
    End Sub

  

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                Dim id, Totatted, ActAtend As Integer
                For Each grid As GridViewRow In GridView1.Rows
                    id = CType(grid.FindControl("lblid"), Label).Text
                    Totatted = CType(grid.FindControl("txtTotAttend"), TextBox).Text

                    If CType(grid.FindControl("txtActAttend"), TextBox).Text = "" Then
                        ActAtend = 0
                    Else
                        ActAtend = CType(grid.FindControl("txtActAttend"), TextBox).Text
                    End If
                    If Totatted < ActAtend Then
                        lblMsg.Text = ""
                        msginfo.Text = "Actual Attendance cannot be greater than Total Attendance."
                        btnUpdate.Enabled = True
                        Exit Sub

                    Else
                        BL.UpdateSummary(id, Totatted, ActAtend)
                    End If
                Next
                lblMsg.Text = "Records Updated Successfully."
                msginfo.Text = ""
                El.Bid = ddlBatchName.SelectedValue
                El.Sid = DDLSemester.SelectedValue
                El.AsOnDate = txtAdate.Text
                Dt2 = BL.ViewSummary(El)
                GridView1.DataSource = Dt2
                GridView1.DataBind()
                Enable()
                For Each grid As GridViewRow In GridView1.Rows
                    lblBatchAns.Text = ""
                    lblSemAns.Text = ""
                    lblDateAns.Text = ""
                    lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                    lblSemAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                    lblDateAns.Text = Left(CType(grid.FindControl("LabelAsOnDate"), Label).Text, 11)
                    pnllabel.Visible = True

                Next
                btnUpdate.Enabled = True

            Catch ex As Exception
                msginfo.Text = "Enter Integer values in Attendance fields."
                lblMsg.Text = ""
                btnUpdate.Enabled = True
            End Try
        Else
            msginfo.Text = "You do not belong to this branch, Cannot update data."
            lblMsg.Text = ""
        End If

    End Sub
    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Session("BranchCode") = Session("ParentBranch")) Then

            If txtPassword.Text = Session("Password") Then

                El.Bid = ddlBatchName.SelectedValue
                El.Sid = DDLSemester.SelectedValue
                El.SubId = cmbSubject.SelectedValue
                El.AsOnDate = txtAdate.Text
                lblMsg.Text = ""
                msginfo.Text = ""
                If BL.ChkLockSummary(El).Tables(0).Rows(0).Item(0) = "N" Then
                    Dim roweffected As Integer = BL.LockSummary(El)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        msginfo.Text = ""
                        lblMsg.Text = roweffected.ToString + " records Locked."
                        GridView1.Enabled = False
                        Image1.Visible = True
                        Image2.Visible = True
                    End If
                Else
                    Dim roweffected As Integer = BL.UnLockSummary(El)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        msginfo.Text = ""
                        lblMsg.Text = roweffected.ToString + " records Unlocked."
                        GridView1.Enabled = True
                        Image1.Visible = True
                        Image2.Visible = True
                        btnUpdate.Enabled = True
                    End If

                End If


            ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                msginfo.Text = "Password Incorrect."
                Image1.Visible = True
                Image2.Visible = True
                lblmsg.Text = ""
            End If

        Else
            msginfo.Text = "You do not belong to this branch, Cannot lock data."
            lblmsg.Text = ""
        End If
        btnlock.Focus()
    End Sub
    Protected Sub btnlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
               
                El.Bid = ddlBatchName.SelectedValue
                El.Sid = DDLSemester.SelectedValue
                El.SubId = cmbSubject.SelectedValue
                El.AsOnDate = txtAdate.Text
                lblMsg.Text = ""
                msginfo.Text = ""
                Dt1 = BL.ViewSummary(El)
                GridView1.DataSource = Dt1
                GridView1.DataBind()
                Enable()
                For Each grid As GridViewRow In GridView1.Rows
                    lblBatchAns.Text = ""
                    lblSemAns.Text = ""
                    lblDateAns.Text = ""
                    lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                    lblSemAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                    lblDateAns.Text = Left(CType(grid.FindControl("LabelAsOnDate"), Label).Text, 11)
                    pnllabel.Visible = True


                Next
                If Dt1.Rows.Count > 0 Then
                    lblMsg.Text = ""
                    msginfo.Text = ""
                    ControlsPanel.Visible = False
                    PasswordPanel.Visible = True
                    txtPassword.Focus()
                    lblpassError.Text = ""
                    Image1.Visible = False
                    Image2.Visible = False
                    'For Each grid As GridViewRow In GridView1.Rows
                    '    lblAcademicYearAns.Text = ""
                    '    lblBatchAns.Text = ""
                    '    lblSemesterAns.Text = ""
                    '    lblClassTypeAns.Text = ""
                    '    lblSubjectAns.Text = ""
                    '    lblAssessmentTypeAns.Text = ""
                    '    lblAcademicYearAns.Text = CType(grid.FindControl("LabelAcademic"), Label).Text
                    '    lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
                    '    lblSemesterAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
                    '    lblClassTypeAns.Text = CType(grid.FindControl("LabelClass"), Label).Text()
                    '    lblSubjectAns.Text = CType(grid.FindControl("LabelSubject"), Label).Text()
                    '    lblAssessmentTypeAns.Text = CType(grid.FindControl("LabelAsst"), Label).Text
                    '    pnllabel.Visible = True
                    'Next
                  
                Else

                    lblMsg.Text = ""
                    msginfo.Text = "No Records to Lock/Unlock."
                    Image1.Visible = True
                    Image2.Visible = True
                    lblBatch.Visible = False
                    lblBatchAns.Visible = False
                    lblDate.Visible = False
                    lblDateAns.Visible = False
                    lblSem.Visible = False
                    lblSemAns.Visible = False
                End If
                'End If
            Catch ex As Exception
                lblMsg.Text = ""
                msginfo.Text = "Enter all mandatory fields."
                GridView1.Visible = False
                Image1.Visible = True
                Image2.Visible = True
            End Try
        Else
            msginfo.Text = "You do not belong to this branch, Cannot lock/unlock data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub BtnExport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExport.Click
        Dim sw As New StringWriter()
        Dim hw As New System.Web.UI.HtmlTextWriter(sw)
        Dim frm As HtmlForm = New HtmlForm()
        Response.Clear()
        Response.ClearHeaders()
        Response.ClearContent()
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1254")
        Response.Charset = "windows-1254"

        Dim style As String = "<style>.text {mso-number-format:\@;}</style>"
        Page.Response.AddHeader("content-disposition", "attachment;filename=StudentAttendanceSummary.xls")
        Page.Response.ContentType = "application/vnd.ms-excel"
        Page.Response.Charset = ""
        Page.EnableViewState = False
        frm.Attributes("runat") = "server"
        GridView1.Parent.Controls.Add(frm)
        frm.Controls.Add(GridView1)
        frm.RenderControl(hw)
        Response.Output.Write(style & sw.ToString())
        Response.Flush()
        Response.End()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        El.Bid = ddlBatchName.SelectedValue
        El.Sid = DDLSemester.SelectedValue
        El.AsOnDate = txtAdate.Text
        El.SubId = cmbSubject.SelectedValue
        lblMsg.Text = ""
        msginfo.Text = ""
        Dt1 = BL.ViewSummary(El)
        GridView1.DataSource = Dt1
        GridView1.DataBind()
        btnUpdate.Enabled = True
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAdate.Text = Format(Today(), "dd-MMM-yyyy")
        btnUpdate.Enabled = False
        'txtAdate.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading

    End Sub

    Sub DisEnable()
        lblBatch.Visible = False
        lblBatchAns.Visible = False
        lblSem.Visible = False
        lblSemAns.Visible = False
        lblDate.Visible = False
        lblDateAns.Visible = False
    End Sub
    Sub Enable()
        lblBatch.Visible = True
        lblBatchAns.Visible = True
        lblSem.Visible = True
        lblSemAns.Visible = True
        lblDate.Visible = True
        lblDateAns.Visible = True
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
        El.Bid = ddlBatchName.SelectedValue
        El.Sid = DDLSemester.SelectedValue
        El.AsOnDate = txtAdate.Text
        Dt1 = BL.ViewSummary(El)
        Dim sortedView As New DataView(Dt1)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        For Each grid As GridViewRow In GridView1.Rows
            lblBatchAns.Text = ""
            lblSemAns.Text = ""
            lblDateAns.Text = ""
            lblBatchAns.Text = CType(grid.FindControl("LabelBatch"), Label).Text
            lblSemAns.Text = CType(grid.FindControl("LabelSemester"), Label).Text
            lblDateAns.Text = Left(CType(grid.FindControl("LabelAsOnDate"), Label).Text, 11)
            pnllabel.Visible = True
        Next
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

End Class
