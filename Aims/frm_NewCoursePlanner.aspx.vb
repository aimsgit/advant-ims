
Partial Class frm_NewCoursePlanner
    Inherits BasePage
    Dim bl As New BLNewCoursePlanner
    Dim p As New NewCoursePlanner
    Dim duplicate As New DataTable
    Protected Sub btnAddGrid_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddGrid.Click
        ddlCourse.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim CrsPlanr As New NewCoursePlanner
            CrsPlanr.Course = Trim(ddlCourse.SelectedValue)
            If txtCredit.Text = "" Then
                CrsPlanr.Credit = 0
            Else
                CrsPlanr.Credit = Trim(txtCredit.Text)
            End If
            'If txtLab.Text = "" Then
            '    CrsPlanr.Lab = 0
            'Else
            '    CrsPlanr.Lab = Trim(txtLab.Text)
            'End If
            'If txtProject.Text = "" Then
            '    CrsPlanr.Project = 0
            'Else
            '    CrsPlanr.Project = Trim(txtProject.Text)
            'End If
            If txtTheory.Text = "" Then
                CrsPlanr.theory = 0
            Else
                CrsPlanr.theory = Trim(txtTheory.Text)
            End If
            CrsPlanr.Semester = Trim(ddlSemester.SelectedValue)
            CrsPlanr.subject = Trim(ddlSubject.SelectedValue)
            CrsPlanr.PrincipalSubject = Trim(ddlPrincipalSubject.SelectedValue)
            CrsPlanr.SubjectCategory = Trim(ddlSubCategory.SelectedValue)
            'CrsPlanr.id = ViewState("id")
            If btnAddGrid.Text = "ADD" Then
                duplicate = bl.DuplicateCoursePlanner(CrsPlanr.id, ddlCourse.SelectedValue, ddlSemester.SelectedValue, ddlSubject.SelectedValue)
                If duplicate.Rows.Count > 0 Then
                    lblErrorMsg.Text = ValidationMessage(1030)
                    ddlCourse.Focus()
                    lblmsg.Text = ValidationMessage(1014)
                Else
                    bl.InsertCoursePlanner(CrsPlanr)
                    lblErrorMsg.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1020)
                    ddlCourse.Focus()
                    ClearAll()
                    ViewState("PageIndex") = 0
                    GVUserMngmnt.PageIndex = ViewState("PageIndex")
                    dispgrid()
                    duplicate.Dispose()
                End If

            Else
                CrsPlanr.id = ViewState("id")
                duplicate = bl.DuplicateCoursePlanner(CrsPlanr.id, ddlCourse.SelectedValue, ddlSemester.SelectedValue, ddlSubject.SelectedValue)
                If duplicate.Rows.Count > 0 Then
                    lblErrorMsg.Text = ValidationMessage(1030)
                    ddlCourse.Focus()
                    lblmsg.Text = ValidationMessage(1014)
                Else
                    bl.UpdateCoursePlanner(CrsPlanr)
                    lblErrorMsg.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1017)
                    ddlCourse.Focus()
                    ClearAll()
                    btnAddGrid.Text = "ADD"
                    duplicate.Dispose()
                    GVUserMngmnt.PageIndex = ViewState("PageIndex")
                    dispgrid()
                    BtnView.Text = "VIEW"
                End If
            End If

        Else
            lblErrorMsg.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub ClearAll()
        'txtLab.Text = ""
        'txtProject.Text = ""
        txtTheory.Text = ""
        txtCredit.Text = ""
        'txtTtlHrs.Text = ""

        'lblErrorMsg.Text = ""
        'lblmsg.Text = ""
        btnAddGrid.Text = "ADD"
        BtnView.Text = "VIEW"
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
    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        Try
            LinkButton1.Focus()
            If BtnView.Text = "BACK" Then
                'btnAddGrid.Text = "ADD"
                'BtnView.Text = "VIEW"
                lblErrorMsg.Text = ValidationMessage(1014)
                lblmsg.Text = ValidationMessage(1014)
                ClearAll()
                GVUserMngmnt.PageIndex = ViewState("PageIndex")
                dispgrid()
            Else
                If ddlCourse.SelectedValue = 0 Then
                    'lblErrorMsg.Text = "Course Field is Mandatory."
                    'lblmsg.Text = ""
                    'GVUserMngmnt.Visible = False
                    lblErrorMsg.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    ViewState("PageIndex") = 0
                    GVUserMngmnt.PageIndex = 0
                    dispgrid()
                Else
                    'ClearAll()
                    lblErrorMsg.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    ViewState("PageIndex") = 0
                    GVUserMngmnt.PageIndex = 0
                    dispgrid()
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Sub dispgrid()
        GVUserMngmnt.Visible = True
        GVUserMngmnt.Enabled = True
        'lblErrorMsg.Text = ""
        Dim dt1 As New DataTable
        dt1 = bl.GetCoursePlanner(0, ddlCourse.SelectedValue, ddlSemester.SelectedValue)
        If dt1.Rows.Count <> 0 Then
            GVUserMngmnt.DataSource = dt1
            GVUserMngmnt.DataBind()
            
        Else
            lblErrorMsg.Text = ValidationMessage(1023)
            ddlCourse.Focus()
            lblmsg.Text = ValidationMessage(1014)
           
            GVUserMngmnt.Visible = False
        End If
    End Sub

    Protected Sub GVUserMngmnt_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVUserMngmnt.PageIndexChanging
        'lblErrorMsg.Visible = False
        GVUserMngmnt.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVUserMngmnt.PageIndex
        dispgrid()
    End Sub

    Protected Sub GVUserMngmnt_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVUserMngmnt.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            p.id = CType(GVUserMngmnt.Rows(e.RowIndex).Cells(1).FindControl("lblid"), Label).Text
            bl.DeleteCoursePlanner(p)
            p.id = 0
            GVUserMngmnt.PageIndex = ViewState("PageIndex")
            dispgrid()
            lblErrorMsg.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1028)
            ddlCourse.Focus()
        Else
            lblErrorMsg.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If
       
    End Sub

    Protected Sub GVUserMngmnt_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVUserMngmnt.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Dim var As Integer
        'Dim dt1 As New DataTable
        'dt1 = bl.GetCoursePlanner(p.id, ddlCourse.SelectedValue, ddlSemester.SelectedValue)
        p.id = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblid"), Label).Text.Trim
        ViewState("id") = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblid"), Label).Text.Trim
        ddlPrincipalSubject.SelectedValue = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblPrinCode"), Label).Text.Trim
        ddlSubCategory.SelectedValue = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblSubCatCode"), Label).Text.Trim
        ddlSubject.Items.Clear()
        ddlSubject.DataSourceID = "ObjSubject"
        var = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblSubCode"), Label).Text.Trim
        ddlSubject.SelectedValue = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblSubCode"), Label).Text.Trim
        txtTheory.Text = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblTheoryHours"), Label).Text.Trim
        'txtLab.Text = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblLabHours"), Label).Text.Trim
        'txtProject.Text = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblProjectHours"), Label).Text.Trim
        'txtTtlHrs.Text = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblTotalHours"), Label).Text.Trim
        ddlSemester.SelectedValue = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("Lblsemcode"), Label).Text.Trim
        ddlCourse.SelectedValue = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("LblCourseCode"), Label).Text.Trim
        txtCredit.Text = CType(GVUserMngmnt.Rows(e.NewEditIndex).Cells(1).FindControl("lblCredit"), Label).Text.Trim
        GVUserMngmnt.Visible = True
        GVUserMngmnt.Enabled = False
        btnAddGrid.Text = "UPDATE"
        BtnView.Text = "BACK"
        lblErrorMsg.Text = ValidationMessage(1014)
        lblmsg.Text = ValidationMessage(1014)
        Dim dt1 As New DataTable
        dt1 = bl.GetCoursePlanner(p.id, ddlCourse.SelectedValue, ddlSemester.SelectedValue)
        GVUserMngmnt.DataSource = dt1
        GVUserMngmnt.DataBind()
        
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub

    'Protected Sub txtProject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProject.TextChanged, txtTheory.TextChanged
    '    Try
    '        'txtTtlHrs.Text = CType(txtLab.Text, Integer) + CType(txtProject.Text, Integer) + CType(txtTheory.Text, Integer)
    '    Catch ex As Exception
    '        'lblErrorMsg.Text = "Please enter all mandatory fields."
    '        'Exit Sub
    '    End Try
    'End Sub

    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'txtTtlHrs.Attributes.Add("OnTextChanged", )
    '    txtProject.Attributes.Add("OnTextChanged", "javascript:Sum()")
    'End Sub

    'Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    Try
    '        txtTtlHrs.Text = CType(txtLab.Text, Integer) + CType(txtProject.Text, Integer) + CType(txtTheory.Text, Integer)
    '    Catch ex As Exception
    '        'lblErrorMsg.Text = "Enter All Fields"
    '        'Exit Sub
    '    End Try
    'End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.TextChanged
        ddlSemester.Focus()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlCourse.Focus()
        Dim heading As String
        If Not IsPostBack Then
            
        End If
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading

    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        lblmsg.Text = ValidationMessage(1014)
        lblErrorMsg.Text = ValidationMessage(1014)

    End Sub

    Protected Sub ddlCourse_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.TextChanged
        lblmsg.Text = ValidationMessage(1014)
        lblErrorMsg.Text = ValidationMessage(1014)
    End Sub

    Protected Sub GVUserMngmnt_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVUserMngmnt.Sorting
        Dim sortingDirection As String = String.Empty
        
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        'Dim en As New Enquiry
        GVUserMngmnt.Visible = True
        GVUserMngmnt.Enabled = True
        'lblErrorMsg.Text = ""
        Dim dt1 As New DataTable
        dt1 = bl.GetCoursePlanner(0, ddlCourse.SelectedValue, ddlSemester.SelectedValue)
        If dt1.Rows.Count <> 0 Then
            GVUserMngmnt.DataSource = dt1
            GVUserMngmnt.DataBind()
            
        Else
            lblErrorMsg.Text = ValidationMessage(1023)
            ddlCourse.Focus()
            lblmsg.Text = ValidationMessage(1014)
            GVUserMngmnt.Visible = False
        End If
        Dim sortedView As New DataView(dt1)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVUserMngmnt.DataSource = sortedView
        GVUserMngmnt.DataBind()
        
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
End Class
