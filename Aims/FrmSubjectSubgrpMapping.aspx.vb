'Author-->Anchala Verma
'Date---->18-Apr-2013
Partial Class FrmSubjectSubgrpMapping
    Inherits BasePage
    Dim El As New ELSubjectSubGrpMapping
    Dim BL As New BLSubjectSubGrpMapping

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ddlBatch.Focus()
            Dim dt As New DataTable
            El.BatchId = ddlBatch.SelectedValue
            El.SemesterId = cmbSemester.SelectedValue
            El.SubjectId = cmbSubject.SelectedValue
            dt = BLSubjectSubGrpMapping.getduplicate(El)
            If dt.Rows.Count > 0 Then
                lblGreen.Text = ValidationMessage(1014)
                lblRed.Text = ValidationMessage(1030)
            Else
                Dim roweffected1 As Integer = BLSubjectSubGrpMapping.generate(El)
                lblRed.Text = ValidationMessage(1014)
                lblGreen.Text = roweffected1.ToString + " " + ValidationMessage(1109)
                btnUpdate.Enabled = True
                Dispgrid(El)
            End If
        Else
            lblRed.Text = ValidationMessage(1084)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub Dispgrid(ByVal EL As ELSubjectSubGrpMapping)
        Dim dt As New Data.DataTable
        EL.BatchId = ddlBatch.SelectedValue
        EL.SemesterId = cmbSemester.SelectedValue
        EL.SubjectId = cmbSubject.SelectedValue
        dt = BLSubjectSubGrpMapping.GetData(EL)
        If dt.Rows.Count <> 0 Then
            GVSubjectSubGrpMapping.DataSource = dt
            GVSubjectSubGrpMapping.DataBind()
           
            GVSubjectSubGrpMapping.Visible = True
            btnUpdate.Visible = True
            ddlSubjectSubGrp.Visible = True
            If dt.Rows(0)("LockStatus").ToString() = "N" Then
                GVSubjectSubGrpMapping.Enabled = "true"
            Else
                GVSubjectSubGrpMapping.Enabled = "false"
            End If
        Else
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1023)
            btnUpdate.Enabled = False
          

            'ddlSubjectSubGrp.Visible = False
            GVSubjectSubGrpMapping.Visible = False
        End If
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        'LinkButton1.Focus()
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
        btnUpdate.Enabled = True
        'ddlSubjectSubGrp.Visible = True
        El.BatchId = ddlBatch.SelectedValue
        El.SemesterId = cmbSemester.SelectedValue
        El.SubjectId = cmbSubject.SelectedValue
        Dispgrid(El)
        'If GVSubjectSubGrpMapping.Rows.Count > 0 And GVSubjectSubGrpMapping.Visible = True Then
        '    For Each Grid As GridViewRow In GVSubjectSubGrpMapping.Rows
        '        CType(Grid.FindControl("ddlSubjectSubGrp"), DropDownList).SelectedValue = CType(Grid.FindControl("Label14"), Label).Text
        '    Next
        'End If
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If GVSubjectSubGrpMapping.Visible = True And GVSubjectSubGrpMapping.Rows.Count > 0 Then
                    Dim dt As DataTable
                    Dim Str As String = ""
                    Dim ID As String = ""
                    El.BatchId = ddlBatch.SelectedValue
                    El.SemesterId = cmbSemester.SelectedValue
                    El.SubuGrp = ddlSubjectSubGrp.SelectedValue
                    El.SubjectId = cmbSubject.SelectedValue
                    dt = BLSubjectSubGrpMapping.CheckLock(El)
                    ValidationMessage(1014)
                    If dt.Rows(0).Item(0) = "N" Then
                        Dim entity1 As New ElectiveMapEL
                        'For Each grid As GridViewRow In GVSubjectSubGrpMapping.Rows
                        '    El.SubuGrp = CType(grid.FindControl("ddlSubjectSubGrp"), DropDownList).SelectedItem.Value
                        '    El.Id = CType(grid.FindControl("lblID"), Label).Text

                        '    BLSubjectSubGrpMapping.Update(El)
                        '    lblGreen.Text = "Data Updated Successfully."
                        '    lblRed.Text = ""
                        'Next

                        For Each grid As GridViewRow In GVSubjectSubGrpMapping.Rows
                            If CType(grid.FindControl("ChkElective"), CheckBox).Checked = True Then
                                Str = CType(grid.FindControl("IID"), HiddenField).Value
                                ID = Str + "," + ID
                            End If
                        Next
                        BLSubjectSubGrpMapping.Update(El, ID)
                        lblGreen.Text = ValidationMessage(1017)
                        lblRed.Text = ValidationMessage(1014)
                        Dispgrid(El)

                    Else
                        lblRed.Text = ValidationMessage(1099)
                        lblGreen.Text = ValidationMessage(1014)
                    End If
                Else
                    lblRed.Text = ValidationMessage(1100)
                    lblGreen.Text = ValidationMessage(1014)
                End If
            Catch ex As Exception
                lblRed.Text = ValidationMessage(1099)
                lblGreen.Text = ValidationMessage(1014)
            End Try
        Else
            lblRed.Text = ValidationMessage(1021)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            btnUpdate.Enabled = False

            'ddlSubjectSubGrp.Visible = False
            ddlBatch.Focus()
        End If
    End Sub

    Protected Sub btnLock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ControlsPanel.Visible = "false"
            PasswordPanel.Visible = "true"
            txtPassword.Focus()
            Image1.Visible = False
            Image2.Visible = False
            

        Else
            lblRed.Text = ValidationMessage(1101)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If txtPassword.Text = Session("Password") Then
                Dim check As String = ""
                El.BatchId = ddlBatch.SelectedValue
                El.SemesterId = cmbSemester.SelectedValue
                El.SubjectId = cmbSubject.SelectedValue
                'ElectiveMapBL.clear(entity)
                'Dispgrid(entity)
    
                lblGreen.Text = ValidationMessage(1014)
                lblRed.Text = ValidationMessage(1014)
                Dim dt As DataTable
                dt = BLSubjectSubGrpMapping.CheckLock(El)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item(0) = "N" Then
                        Dim roweffected As Integer = BLSubjectSubGrpMapping.Lock(El)
                        If roweffected > 0 Then
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            lblRed.Text = ValidationMessage(1014)
                            lblGreen.Text = roweffected.ToString + ValidationMessage(1103)
                            GVSubjectSubGrpMapping.Enabled = False
                            Image1.Visible = True
                            Image2.Visible = True
                        End If
                    Else
                        Dim role As String
                        role = Session("UserRole")

                        If Session("SecurityCheck") = "Security Check" Then

                            dt = DLSubjectSubGrpMapping.PostCheck(role)
                            If dt.Rows.Count < 1 Then
                                lblRed.Text = ValidationMessage(1102)
                                lblGreen.Text = ValidationMessage(1014)
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                GVSubjectSubGrpMapping.Enabled = False
                                Image1.Visible = True
                                Image2.Visible = True
                            Else
                                check = dt.Rows(0)("Result").ToString.Trim

                                'check = dt.Rows(0)("Result").ToString.Trim
                                If check = "" Then
                                    lblRed.Text = ValidationMessage(1102)
                                    lblGreen.Text = ValidationMessage(1014)
                                    ControlsPanel.Visible = True
                                    PasswordPanel.Visible = False
                                    GVSubjectSubGrpMapping.Enabled = False
                                    Image1.Visible = True
                                    Image2.Visible = True
                                Else

                                    Dim roweffected As Integer = BLSubjectSubGrpMapping.Lock(El)
                                    If roweffected > 0 Then
                                        ControlsPanel.Visible = True
                                        PasswordPanel.Visible = False
                                        lblRed.Text = ""
                                        lblGreen.Text = roweffected.ToString + ValidationMessage(1104)
                                        GVSubjectSubGrpMapping.Enabled = True
                                        Image1.Visible = True
                                        Image2.Visible = True
                                    End If
                                End If
                            End If
                        Else
                            Dim roweffected As Integer = BLSubjectSubGrpMapping.Lock(El)
                            If roweffected > 0 Then
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                lblRed.Text = ValidationMessage(1014)
                                lblGreen.Text = roweffected.ToString + ValidationMessage(1104)
                                GVSubjectSubGrpMapping.Enabled = True
                                Image1.Visible = True
                                Image2.Visible = True
                            End If
                        End If
                    End If
                Else
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    lblRed.Text = ValidationMessage(1105)
                    lblGreen.Text = ValidationMessage(1014)
                    Image1.Visible = True
                    Image2.Visible = True
                End If
            Else
                lblGreen.Text = ValidationMessage(1014)
                lblRed.Text = ValidationMessage(1106)
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
            End If
        Else
            lblRed.Text = ValidationMessage(1029)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                Dim dt As DataTable
                El.BatchId = ddlBatch.SelectedValue
                El.SemesterId = cmbSemester.SelectedValue
                El.SubjectId = cmbSubject.SelectedValue
                dt = BLSubjectSubGrpMapping.CheckLock(El)

                If dt.Rows(0).Item(0) = "N" Then
                    BLSubjectSubGrpMapping.clear(El)
                    Dispgrid(El)
                    lblGreen.Text = ValidationMessage(1097)
                    lblRed.Text = ValidationMessage(1014)
                Else
                    lblRed.Text = ValidationMessage(1098)
                    lblGreen.Text = ValidationMessage(1014)
                End If
            Catch ex As Exception
                lblRed.Text = ValidationMessage(1090)
                lblGreen.Text = ValidationMessage(1014)
            End Try
        Else
            lblRed.Text = ValidationMessage(1091)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
        GVSubjectSubGrpMapping.Visible = False
        btnUpdate.Enabled = False
        'ddlSubjectSubGrp.Visible = False
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
        cmbSemester.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub cmbSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubject.SelectedIndexChanged
        GVSubjectSubGrpMapping.Visible = False
        btnUpdate.Enabled = False
        'ddlSubjectSubGrp.Visible = False
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)

    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        GVSubjectSubGrpMapping.Visible = False
        btnUpdate.Enabled = False
        'ddlSubjectSubGrp.Visible = False
        lblGreen.Text = ValidationMessage(1014)
        lblRed.Text = ValidationMessage(1014)
        ddlBatch.Focus()
    End Sub

    Protected Sub GVSubjectSubGrpMapping_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSubjectSubGrpMapping.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            El.Id = CType(GVSubjectSubGrpMapping.Rows(e.RowIndex).Cells(1).FindControl("lblID"), Label).Text
            If DLSubjectSubGrpMapping.ChangeFlag(El) Then
                lblRed.Text = ValidationMessage(1014)
                lblGreen.Text = ValidationMessage(1028)
                GVSubjectSubGrpMapping.PageIndex = ViewState("PageIndex")
                Dispgrid(El)
                GVSubjectSubGrpMapping.Enabled = True
            End If
        Else
            lblRed.Text = ValidationMessage(1029)
            lblGreen.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub GVSubjectSubGrpMapping_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVSubjectSubGrpMapping.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New Data.DataTable
        El.BatchId = ddlBatch.SelectedValue
        El.SemesterId = cmbSemester.SelectedValue
        El.SubjectId = cmbSubject.SelectedValue
        dt = BLSubjectSubGrpMapping.GetData(El)
        If dt.Rows.Count <> 0 Then
            Dim sortedView As New DataView(dt)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            GVSubjectSubGrpMapping.DataSource = sortedView
            GVSubjectSubGrpMapping.DataBind()
           
            GVSubjectSubGrpMapping.Visible = True
            btnUpdate.Enabled = True
            'ddlSubjectSubGrp.Visible = True
            If dt.Rows(0)("LockStatus").ToString() = "N" Then
                GVSubjectSubGrpMapping.Enabled = "true"
            Else
                GVSubjectSubGrpMapping.Enabled = "false"
            End If
        Else
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1023)
            btnUpdate.Enabled = False
            'ddlSubjectSubGrp.Visible = False
            GVSubjectSubGrpMapping.Visible = False
        End If

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
    Sub CheckAll()
        If CType(GVSubjectSubGrpMapping.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVSubjectSubGrpMapping.Rows
                CType(grid.FindControl("ChkElective"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVSubjectSubGrpMapping.Rows
                CType(grid.FindControl("ChkElective"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub BtnGen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGen.Click
        Dim dt, dt1 As DataTable
        El.BatchId = ddlBatch.SelectedValue
        El.SemesterId = cmbSemester.SelectedValue
        El.SubjectId = cmbSubject.SelectedValue
        El.Stdid = ddlStudent.SelectedValue

        dt = BLSubjectSubGrpMapping.CheckLock(El)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0) = "N" Then
                dt = BLSubjectSubGrpMapping.getduplicate(El)
                If dt.Rows.Count <= 0 Then
                    lblGreen.Text = ValidationMessage(1014)
                    lblRed.Text = ValidationMessage(1107)
                Else

                    dt1 = DLSubjectSubGrpMapping.getduplicateInStd(El)
                    If dt1.Rows.Count > 0 Then
                        lblGreen.Text = ValidationMessage(1014)
                        lblRed.Text = ValidationMessage(1030)
                    Else

                        DLSubjectSubGrpMapping.generateIndstd(El)
                        lblRed.Text = ValidationMessage(1014)
                        lblGreen.Text = ValidationMessage(1020)
                        Dispgrid(El)
                    End If
                End If
            Else
                lblRed.Text = ValidationMessage(1108)
                lblGreen.Text = ValidationMessage(1014)
            End If
        Else
            lblGreen.Text = ValidationMessage(1014)
            lblRed.Text = ValidationMessage(1107)
        End If


    End Sub
    
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
