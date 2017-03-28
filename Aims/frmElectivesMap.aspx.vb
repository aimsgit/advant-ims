
Partial Class frmElectivesMap
    Inherits BasePage
    Dim entity As New ElectiveMapEL
    Dim dt As New Data.DataTable
    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ddlCourseName.Focus()
            Dim dt As New DataTable
            entity.CourseId = ddlCourseName.SelectedValue
            entity.BatchId = ddlBatchName.SelectedValue
            entity.SemesterId = ddlSemester.SelectedValue
            entity.ElectiveId = ddlElective.SelectedValue
            entity.SubjectId = ddlElecSubj.SelectedValue
            
            dt = ElectiveMapBL.getduplicate(entity)
            If dt.Rows.Count > 0 Then
                msgS.Text = ValidationMessage(1014)
                msgE.Text = ValidationMessage(1030)
            Else
                Dim roweffected1 As Integer = ElectiveMapBL.generate(entity)
                msgE.Text = ValidationMessage(1014)
                msgS.Text = roweffected1.ToString + ValidationMessage(1109)
                Dispgrid(entity)
            End If
        Else
            msgE.Text = ValidationMessage(1084)
            msgS.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub Dispgrid(ByVal el As ElectiveMapEL)
        Dim dt As New Data.DataTable
        entity.CourseId = ddlCourseName.SelectedValue
        entity.BatchId = ddlBatchName.SelectedValue
        entity.SemesterId = ddlSemester.SelectedValue
        entity.ElectiveId = ddlElective.SelectedValue
        dt = ElectiveMapBL.GetData(el)
        
        If dt.Rows.Count <> 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            
            GridView1.Visible = True
            btnUpdate.Visible = True
            If dt.Rows(0)("LockStatus").ToString() = "N" Then
                GridView1.Enabled = "true"
                
            Else
                GridView1.Enabled = "false"
                
            End If
        Else
            msgS.Text = ValidationMessage(1014)
            msgE.Text = ValidationMessage(1023)
            btnUpdate.Visible = False
            GridView1.Visible = False
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        LinkButton1.Focus()
        msgS.Text = ValidationMessage(1014)
        msgE.Text = ValidationMessage(1014)
        btnUpdate.Visible = True
        entity.CourseId = ddlCourseName.SelectedValue
        entity.BatchId = ddlBatchName.SelectedValue
        entity.SemesterId = ddlSemester.SelectedValue
        entity.ElectiveId = ddlElective.SelectedValue
        Dispgrid(entity)
        'If GridView1.Rows.Count > 0 And GridView1.Visible = True Then
        '    For Each Grid As GridViewRow In GridView1.Rows
        '        CType(Grid.FindControl("ddlSubject"), DropDownList).SelectedValue = CType(Grid.FindControl("Label14"), Label).Text
        '    Next
        'End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                Dim dt As DataTable
                entity.CourseId = ddlCourseName.SelectedValue
                entity.BatchId = ddlBatchName.SelectedValue
                entity.SemesterId = ddlSemester.SelectedValue
                entity.ElectiveId = ddlElective.SelectedValue
                dt = ElectiveMapBL.CheckLock(entity)
                If dt.Rows(0).Item(0) = "N" Then
                    ElectiveMapBL.clear(entity)
                    Dispgrid(entity)
                    msgS.Text = ValidationMessage(1097)
                    msgE.Text = ValidationMessage(1014)
                Else
                    msgE.Text = ValidationMessage(1098)
                    msgS.Text = ValidationMessage(1014)
                End If
            Catch ex As Exception
                msgE.Text = ValidationMessage(1047)
                msgS.Text = ValidationMessage(1014)
            End Try
        Else
            msgE.Text = ValidationMessage(1091)
            msgS.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If GridView1.Visible = True And GridView1.Rows.Count > 0 Then
                Dim dt As DataTable
                Dim Str As String = ""
                Dim ID As String = ""
                entity.CourseId = ddlCourseName.SelectedValue
                entity.BatchId = ddlBatchName.SelectedValue
                entity.SemesterId = ddlSemester.SelectedValue
                entity.ElectiveId = ddlElective.SelectedValue
                entity.SubjectId = ddlElecSubj.SelectedValue
                dt = ElectiveMapBL.CheckLock(entity)
                
                If dt.Rows(0).Item(0) = "N" Then
                    Dim entity1 As New ElectiveMapEL
                    'For Each grid As GridViewRow In GridView1.Rows
                    'entity1.SubjectId = CType(grid.FindControl("ddlSubject"), DropDownList).SelectedItem.Value
                    For Each grid As GridViewRow In GridView1.Rows
                        If CType(grid.FindControl("ChkElective"), CheckBox).Checked = True Then
                            Str = CType(grid.FindControl("IID"), HiddenField).Value
                            ID = Str + "," + ID
                        End If
                    Next
                    'entity1.Id = CType(grid.FindControl("Label13"), Label).Text

                    ElectiveMapBL.Update(entity, ID)
                    msgS.Text = ValidationMessage(1017)
                    msgE.Text = ValidationMessage(1014)
                    Dispgrid(entity)

                Else
                    msgE.Text = ValidationMessage(1099)
                    msgS.Text = ValidationMessage(1014)
                End If
            Else
                msgE.Text = ValidationMessage(1100)
                msgS.Text = ValidationMessage(1014)
            End If
        Else
            msgE.Text = ValidationMessage(1021)
            msgS.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub btnLockUnlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLockUnlock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ControlsPanel.Visible = "false"
            PasswordPanel.Visible = "true"
            
            txtPassword.Focus()
            Image1.Visible = False
            Image2.Visible = False
        Else
            msgE.Text = ValidationMessage(1101)
            msgS.Text = ValidationMessage(1014)
        End If

    End Sub

    'Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If (Session("BranchCode") = Session("ParentBranch")) Then
    '        If txtPassword.Text = Session("Password") Then
    '            entity.CourseId = ddlCourseName.SelectedValue
    '            entity.BatchId = ddlBatchName.SelectedValue
    '            entity.SemesterId = ddlSemester.SelectedValue
    '            entity.ElectiveId = ddlElective.SelectedValue
    '            'ElectiveMapBL.clear(entity)
    '            'Dispgrid(entity)
    '            msgS.Text = ""
    '            msgE.Text = ""
    '            Dim dt As DataTable
    '            dt = ElectiveMapBL.CheckLock(entity)
    '            If dt.Rows.Count > 0 Then
    '                If dt.Rows(0).Item(0) = "N" Then
    '                    Dim roweffected As Integer = ElectiveMapBL.Lock(entity)
    '                    If roweffected > 0 Then
    '                        ControlsPanel.Visible = True
    '                        PasswordPanel.Visible = False
    '                        msgE.Text = ""
    '                        msgS.Text = roweffected.ToString + " records Locked."
    '                        GridView1.Enabled = False
    '                        Image1.Visible = True
    '                        Image2.Visible = True
    '                    End If
    '                Else
    '                    Dim roweffected As Integer = ElectiveMapBL.Lock(entity)
    '                    If roweffected > 0 Then
    '                        ControlsPanel.Visible = True
    '                        PasswordPanel.Visible = False
    '                        msgE.Text = ""
    '                        msgS.Text = roweffected.ToString + " records Unlocked."
    '                        GridView1.Enabled = True
    '                        Image1.Visible = True
    '                        Image2.Visible = True
    '                    End If
    '                End If
    '            Else
    '                ControlsPanel.Visible = True
    '                PasswordPanel.Visible = False
    '                msgE.Text = "No records to Lock / Unlock."
    '                msgS.Text = ""
    '                Image1.Visible = True
    '                Image2.Visible = True
    '            End If
    '        Else
    '            msgS.Text = ""
    '            msgE.Text = "Password Incorrect."
    '            ControlsPanel.Visible = True
    '            PasswordPanel.Visible = False
    '        End If
    '    Else
    '        msgE.Text = "You do not belong to this branch, Cannot delete data."
    '        msgS.Text = ""
    '    End If
    'End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            btnUpdate.Visible = False
            ddlCourseName.Focus()
            
        End If
    End Sub

    Protected Sub ddlBatchName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.TextChanged
        ddlBatchName.Focus()
        msgE.Text = ValidationMessage(1014)
        msgS.Text = ValidationMessage(1014)
    End Sub

    Protected Sub ddlCourseName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourseName.TextChanged
        ddlCourseName.Focus()
        msgE.Text = ValidationMessage(1014)
        msgS.Text = ValidationMessage(1014)
    End Sub

    Protected Sub ddlElective_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlElective.TextChanged
        ddlElective.Focus()
        msgE.Text = ValidationMessage(1014)
        msgS.Text = ValidationMessage(1014)
    End Sub

    Protected Sub ddlSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.TextChanged
        ddlSemester.Focus()
        msgE.Text = ValidationMessage(1014)
        msgS.Text = ValidationMessage(1014)
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Sub CheckAll()
        If CType(GridView1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkElective"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkElective"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        msgE.Text = ValidationMessage(1014)
        msgS.Text = ValidationMessage(1014)
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Dispgrid(entity)
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting

        If (Session("BranchCode") = Session("ParentBranch")) Then
            entity.Id = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("Label13"), Label).Text
            If ElectiveMapDL.ChangeFlag(entity) Then
                msgE.Text = ValidationMessage(1014)
                msgS.Text = ValidationMessage(1028)
                GridView1.PageIndex = ViewState("PageIndex")
                Dispgrid(entity)
                GridView1.Enabled = True
            End If
        Else
            msgE.Text = ValidationMessage(1029)
            msgS.Text = ValidationMessage(1014)
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

        Dim dt As New Data.DataTable
        entity.CourseId = ddlCourseName.SelectedValue
        entity.BatchId = ddlBatchName.SelectedValue
        entity.SemesterId = ddlSemester.SelectedValue
        entity.ElectiveId = ddlElective.SelectedValue
        'Dim el As entity
        dt = ElectiveMapBL.GetData(entity)
        If dt.Rows.Count <> 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            
            GridView1.Visible = True
            btnUpdate.Visible = True
            If dt.Rows(0)("LockStatus").ToString() = "N" Then
                GridView1.Enabled = "true"
            Else
                GridView1.Enabled = "false"
            End If
        Else
            msgS.Text = ValidationMessage(1014)
            msgE.Text = ValidationMessage(1023)
            btnUpdate.Visible = False
            GridView1.Visible = False
        End If
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        
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
    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim check As String
            If txtPassword.Text = Session("Password") Then
                entity.CourseId = ddlCourseName.SelectedValue
                entity.BatchId = ddlBatchName.SelectedValue
                entity.SemesterId = ddlSemester.SelectedValue
                entity.ElectiveId = ddlElective.SelectedValue
                'ElectiveMapBL.clear(entity)
                'Dispgrid(entity)
                msgS.Text = ValidationMessage(1014)
                msgE.Text = ValidationMessage(1014)
                Dim dt As DataTable
                dt = ElectiveMapBL.CheckLock(entity)
                If dt.Rows.Count > 0 Then
                    If dt.Rows(0).Item(0) = "N" Then
                        Dim roweffected As Integer = ElectiveMapBL.Lock(entity)
                        If roweffected > 0 Then
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            msgE.Text = ValidationMessage(1014)
                            msgS.Text = roweffected.ToString + ValidationMessage(1103)
                            GridView1.Enabled = False
                            Image1.Visible = True
                            Image2.Visible = True
                        End If
                    Else
                        Dim role As String
                        role = Session("UserRole")

                        If Session("SecurityCheck") = "Security Check" Then

                            dt = ElectiveMapDL.PostCheck(role)
                            If dt.Rows.Count < 1 Then
                                msgE.Text = ValidationMessage(1102)
                                msgS.Text = ValidationMessage(1014)
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                GridView1.Enabled = False
                                Image1.Visible = True
                                Image2.Visible = True
                            Else
                                check = dt.Rows(0)("Result").ToString.Trim

                                'check = dt.Rows(0)("Result").ToString.Trim
                                If check = "" Then
                                    msgE.Text = ValidationMessage(1102)
                                    msgS.Text = ValidationMessage(1102)
                                    ControlsPanel.Visible = True
                                    PasswordPanel.Visible = False
                                    GridView1.Enabled = False
                                    Image1.Visible = True
                                    Image2.Visible = True
                                Else
                                    Dim roweffected As Integer = ElectiveMapBL.Lock(entity)
                                    If roweffected > 0 Then
                                        ControlsPanel.Visible = True
                                        PasswordPanel.Visible = False
                                        msgE.Text = ValidationMessage(1014)
                                        msgS.Text = roweffected.ToString + ValidationMessage(1104)
                                        GridView1.Enabled = True
                                        Image1.Visible = True
                                        Image2.Visible = True
                                    End If
                                End If
                            End If
                        Else
                            Dim roweffected As Integer = ElectiveMapBL.Lock(entity)
                            If roweffected > 0 Then
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                msgE.Text = ValidationMessage(1014)
                                msgS.Text = roweffected.ToString + ValidationMessage(1104)
                                GridView1.Enabled = True
                                Image1.Visible = True
                                Image2.Visible = True
                                ValidationMessage(1014)
                            End If
                        End If
                    End If
                Else
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    msgE.Text = ValidationMessage(1105)
                    msgS.Text = ValidationMessage(1014)
                    Image1.Visible = True
                    Image2.Visible = True
                End If
            Else
                msgS.Text = ValidationMessage(1014)
                msgE.Text = ValidationMessage(1106)
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
            End If
        Else
            msgE.Text = ValidationMessage(1029)
            msgS.Text = ValidationMessage(1014)
        End If
    End Sub

    Protected Sub BtnGen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGen.Click

        entity.CourseId = ddlCourseName.SelectedValue
        entity.BatchId = ddlBatchName.SelectedValue
        entity.SemesterId = ddlSemester.SelectedValue
        entity.ElectiveId = ddlElective.SelectedValue
        entity.Stdid = ddlStudent.SelectedValue


        dt = ElectiveMapBL.CheckLock(entity)
        If dt.Rows.Count > 0 Then
            If dt.Rows(0).Item(0) = "N" Then

                dt = ElectiveMapBL.getduplicate(entity)
                If dt.Rows.Count <= 0 Then
                    msgS.Text = ValidationMessage(1014)
                    msgE.Text = ValidationMessage(1107)
                Else
                    dt = ElectiveMapDL.getduplicateStd(entity)
                    If dt.Rows.Count > 0 Then
                        msgS.Text = ValidationMessage(1014)
                        msgE.Text = ValidationMessage(1030)
                        Dispgrid(entity)
                    Else
                        ElectiveMapDL.generateInStd(entity)
                        msgE.Text = ValidationMessage(1014)
                        msgS.Text = ValidationMessage(1020)
                        Dispgrid(entity)
                    End If
                End If
            Else
                msgE.Text = ValidationMessage(1108)
                msgS.Text = ValidationMessage(1014)
            End If
        Else
            msgS.Text = ValidationMessage(1014)
            msgE.Text = ValidationMessage(1107)
        End If



    End Sub

    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function

   
   
End Class
