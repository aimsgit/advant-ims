
Partial Class FrmGradeMaster
    Inherits BasePage
    Dim EL As New ELGradeMaster
    Dim BL As New BLGradeMaster
    Dim dt As New DataTable
    'code by Anchala on 03-09-12
    'method for insert and update
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ddlCourse.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.CourseName = ddlCourse.SelectedValue
            EL.Min = Txtmin.Text
            EL.Max = Txtmax.Text
            EL.Grade = Txtgrade.Text
            EL.Division = txtDivision.Text
            If TxtGradePoint.Text = "" Then
                EL.GradePoint = 0
            Else
                EL.GradePoint = TxtGradePoint.Text
            End If
            If (Txtmax.Text) > 100 Then
                msginfo.Text = ValidationMessage(1043)
                lblmsg.Text = ValidationMessage(1014)
                Exit Sub
            End If
            If CDbl(Txtmax.Text) < CDbl(Txtmin.Text) Then
                msginfo.Text = ValidationMessage(1042)
                lblmsg.Text = ValidationMessage(1014)
                Txtmin.Focus()

                For g As Integer = 0 To 5
                Next
            Else

                If btnAdd.Text <> "UPDATE" Then
                    dt = BL.GetMinMax(EL)
                    For Each grid As GridViewRow In GVGradeMaster.Rows

                        Dim a As Double
                        Dim b As Double
                        Dim c As Integer

                        a = CType(grid.FindControl("Lblmin"), Label).Text
                        b = CType(grid.FindControl("Lblmax"), Label).Text
                        c = CType(grid.FindControl("Lblcourse"), Label).Text
                        'If c = EL.CourseName Then
                        'If a <= EL.Min And a >= EL.Max Then
                        '    msginfo.Text = "Data already exists"
                        '    Exit Sub
                        'ElseIf b <= EL.Max And b >= EL.Min Then
                        '    msginfo.Text = "Data already exists"
                        '    Exit Sub
                        'ElseIf b <= EL.Max And b >= EL.Min And a <= EL.Min And a >= EL.Max Then
                        '    msginfo.Text = "Data already exists"
                        '    Exit Sub
                        'ElseIf b >= EL.Max And b <= EL.Min And a >= EL.Min And a >= EL.Max Then
                        '    msginfo.Text = "Data already exists"
                        '    Exit Sub

                        'Else
                        If a <= EL.Min And a >= EL.Max And c = EL.CourseName Then
                            msginfo.Text = ValidationMessage(1030)
                            Exit Sub
                        ElseIf b >= EL.Max And b <= EL.Min And c = EL.CourseName Then
                            msginfo.Text = ValidationMessage(1030)
                            Exit Sub
                        ElseIf b <= EL.Max And b >= EL.Min And c = EL.CourseName And a <= EL.Min And a >= EL.Max Then
                            msginfo.Text = ValidationMessage(1030)
                            Exit Sub
                        ElseIf b >= EL.Max And b <= EL.Min And c = EL.CourseName And a >= EL.Min And a >= EL.Max Then
                            msginfo.Text = ValidationMessage(1030)
                            Exit Sub
                        End If
                        'End If
                    Next
                    EL.id = 0
                    dt = BL.GetDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        lblmsg.Text = ValidationMessage(1014)
                        msginfo.Text = ValidationMessage(1030)
                        ddlCourse.Focus()
                    Else
                        EL.CourseName = ddlCourse.SelectedValue
                        EL.Min = Txtmin.Text
                        EL.Max = Txtmax.Text
                        EL.Grade = Txtgrade.Text
                        EL.Division = txtDivision.Text
                        If TxtGradePoint.Text = "" Then
                            EL.GradePoint = 0
                        Else
                            EL.GradePoint = TxtGradePoint.Text
                        End If
                        BL.Insert(EL)
                        btnAdd.CommandName = "ADD"
                        lblmsg.Text = ValidationMessage(1020)
                        ddlCourse.Focus()
                        msginfo.Text = ValidationMessage(1014)
                        ViewState("PageIndex") = 0
                        GVGradeMaster.PageIndex = 0
                        DispGrid()
                        clear()
                    End If
                Else
                    dt = BL.GetMinMax(EL)
                    EL.id = ViewState("id")
                    For Each grid As GridViewRow In GVGradeMaster.Rows
                        Dim a As Double
                        Dim b As Double
                        Dim c As Integer
                        Dim d As Integer
                        a = CType(grid.FindControl("Lblmin"), Label).Text
                        b = CType(grid.FindControl("Lblmax"), Label).Text
                        c = CType(grid.FindControl("Lblcourse"), Label).Text
                        d = CType(grid.FindControl("GID"), HiddenField).Value
                        ViewState("id") = d
                        If d = ViewState("id") Then
                            If a <= EL.Min And a >= EL.Max And c = EL.CourseName And ViewState("id") <> d Then
                                msginfo.Text = ValidationMessage(1030)
                                btnAdd.CommandName = "UPDATE"

                                Exit Sub
                            ElseIf b <= EL.Max And b >= EL.Min And c = EL.CourseName And ViewState("id") <> d Then
                                msginfo.Text = ValidationMessage(1030)
                                btnAdd.CommandName = "UPDATE"
                                Exit Sub
                            ElseIf b <= EL.Max And b >= EL.Min And c = EL.CourseName And a <= EL.Min And a >= EL.Max And ViewState("id") <> d Then
                                msginfo.Text = ValidationMessage(1030)
                                btnAdd.CommandName = "UPDATE"
                                Exit Sub
                            ElseIf b >= EL.Max And b >= EL.Min And c = EL.CourseName And a >= EL.Min And a >= EL.Max And ViewState("id") <> d Then
                                msginfo.Text = ValidationMessage(1030)
                                btnAdd.CommandName = "UPDATE"
                                Exit Sub

                            End If
                        Else

                            If a <= EL.Min And a >= EL.Max And c = EL.CourseName Then
                                msginfo.Text = ValidationMessage(1030)
                                btnAdd.CommandName = "UPDATE"
                                Exit Sub
                            ElseIf b <= EL.Max And b >= EL.Min And c = EL.CourseName Then
                                msginfo.Text = ValidationMessage(1030)
                                btnAdd.CommandName = "UPDATE"
                                Exit Sub

                            ElseIf b <= EL.Max And b >= EL.Min And c = EL.CourseName And a <= EL.Min And a >= EL.Max And c = EL.CourseName Then
                                msginfo.Text = ValidationMessage(1030)
                                btnAdd.CommandName = "UPDATE"
                                Exit Sub

                            ElseIf b >= EL.Max And b >= EL.Min And c = EL.CourseName And a >= EL.Min And a >= EL.Max And c = EL.CourseName Then
                                msginfo.Text = ValidationMessage(1030)
                                btnAdd.CommandName = "UPDATE"
                                Exit Sub


                            End If
                        End If
                    Next

                    EL.id = ViewState("id")
                    dt = BL.GetDuplicate(EL)

                    If dt.Rows.Count > 0 Then
                        lblmsg.Text = ValidationMessage(1014)
                        msginfo.Text = ValidationMessage(1030)
                        ddlCourse.Focus()
                    Else
                        BL.Update(EL)
                        btnAdd.CommandName = "ADD"
                        btnView.CommandName = "VIEW"
                        lblmsg.Text = ValidationMessage(1017)
                        ddlCourse.Focus()
                        clear()
                        btnAdd.CommandName = "ADD"
                        GVGradeMaster.PageIndex = ViewState("PageIndex")
                        DispGrid()
                    End If
                End If
            End If

            'Next
        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    'code by Anchala on 03-09-12
    '    'method for display
    Sub DispGrid()
        Dim dt As New DataTable
        EL.id = 0
        GVGradeMaster.Enabled = True
        dt = BL.GetData(EL)
        If dt.Rows.Count > 0 Then
            GVGradeMaster.DataSource = dt
            GVGradeMaster.DataBind()
            LinkButton.Focus()
            
        Else
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1023)
        End If
    End Sub
    Sub clear()
        Txtmin.Text = ""
        Txtmax.Text = ""
        Txtgrade.Text = ""
        TxtGradePoint.Text = ""
        txtDivision.Text = ""
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If btnView.CommandName = "VIEW" Then
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GVGradeMaster.PageIndex = 0
            DispGrid()
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
        ElseIf btnView.CommandName = "BACK" Then

            msginfo.Text = ValidationMessage(1014)
            clear()
            GVGradeMaster.PageIndex = ViewState("PageIndex")
            DispGrid()
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
        End If
    End Sub
    'code by Anchala on 03-09-12
    '    'method for delete
    Protected Sub GVGradeMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVGradeMaster.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GVGradeMaster.Rows(e.RowIndex).FindControl("GID"), HiddenField).Value
            BL.ChangeFlag(EL)
            GVGradeMaster.DataBind()
            'lblmsg.Visible = True
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1028)
            ddlCourse.Focus()
            clear()
            GVGradeMaster.PageIndex = ViewState("PageIndex")
            DispGrid()
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlCourse.Focus()
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
    End Sub
    'code by Anchala on 03-09-12
    'method for edit
    Protected Sub GVGradeMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVGradeMaster.RowEditing
        ddlCourse.Focus()
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Dim dt As New DataTable
        btnAdd.Text = "UPDATE"
        btnView.Visible = True
        btnView.Text = "BACK"
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        GVGradeMaster.Visible = True
        ViewState("id") = CType(GVGradeMaster.Rows(e.NewEditIndex).FindControl("GID"), HiddenField).Value
        ddlCourse.SelectedValue = CType(GVGradeMaster.Rows(e.NewEditIndex).FindControl("Lblcourse"), Label).Text
        Txtmin.Text = CType(GVGradeMaster.Rows(e.NewEditIndex).FindControl("Lblmin"), Label).Text
        Txtmax.Text = CType(GVGradeMaster.Rows(e.NewEditIndex).FindControl("Lblmax"), Label).Text
        Txtgrade.Text = CType(GVGradeMaster.Rows(e.NewEditIndex).FindControl("Lblgrade"), Label).Text
        TxtGradePoint.Text = CType(GVGradeMaster.Rows(e.NewEditIndex).FindControl("LblGradePoint"), Label).Text
        txtDivision.Text = CType(GVGradeMaster.Rows(e.NewEditIndex).FindControl("LblDivision"), Label).Text
        EL.id = ViewState("id")
        dt = BL.GetData(EL)
        GVGradeMaster.DataSource = dt
        GVGradeMaster.DataBind()
        GVGradeMaster.Enabled = False
        
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub GVGradeMaster_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVGradeMaster.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        EL.id = 0
        GVGradeMaster.Enabled = True
        dt = BL.GetData(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVGradeMaster.DataSource = sortedView
        GVGradeMaster.DataBind()
        LinkButton.Focus()
        
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
    ''Code Written for Multilingual By Ajit Kumar Singh on 12th Aug
    ''Retriving the text of controls based on Language
    
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
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
        Return 0
    End Function
End Class
