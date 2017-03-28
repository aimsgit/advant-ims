
Partial Class frmFacultyTimeUtilization
    Inherits BasePage
    Dim EL As New ELFaculityTimeUtilization
    Dim BLL As New BLFaculityTimeUtilization
    Dim dt As New DataTable
    Dim GlobalFunction As New GlobalFunction
    'Protected Sub ddlSubject_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.PreRender
    '    If ddlSubject.Items.Count > 0 Then
    '        If ddlSubject.Items(0).Text <> "Select" Then
    '            ddlSubject.Items.Insert(0, "Select")
    '        End If
    '    Else
    '        ddlSubject.Items.Insert(0, "Select")
    '    End If
    'End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtFaculity.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If Session("EmpID") <> "" Then
                Try
                    EL.Faculity = txtFaculity.Text
                    EL.Course = ddlCourseName.SelectedValue
                    EL.Semester = ddlSemester.SelectedValue
                    EL.Batch = ddlBatchName.SelectedValue
                    EL.Subject = ddlSubject.SelectedValue
                    EL.Hours = txtHours.Text

                    If txtDate.Text = "" Then
                        EL.Dates = "1/1/9100"
                    Else
                        EL.Dates = txtDate.Text
                    End If
                    If btnSave.Text = "ADD" Then
                        dt = BLL.CheckDuplicate(EL)
                        If dt.Rows.Count > 0 Then
                            lblerrmsg.Text = "Data already exists."
                            lblmsgifo.Text = " "
                        Else
                            BLL.InsertRecord(EL)
                            Clear()
                            lblerrmsg.Text = ""
                            lblmsgifo.Text = "Data Saved Successfully."
                            btnSave.Text = "ADD"
                            GridFaculity.Enabled = True
                            ViewState("PageIndex") = 0
                            GridFaculity.PageIndex = 0
                            DispGrid()
                        End If
                    ElseIf btnSave.Text = "UPDATE" Then
                        EL.id = ViewState("FTUIDAuto")
                        dt = BLL.CheckDuplicate(EL)
                        If dt.Rows.Count > 0 Then
                            lblerrmsg.Text = "Data already exists."
                            lblmsgifo.Text = " "
                        Else
                            BLL.UpdateRecord(EL)
                            lblerrmsg.Text = ""
                            lblmsgifo.Text = "Data Updated Successfully."
                            btnSave.Text = "ADD"
                            GridFaculity.Visible = True
                            btnDetails.Text = "VIEW"
                            Clear()
                            GridFaculity.PageIndex = ViewState("PageIndex")
                            DispGrid()
                        End If
                    End If
                Catch ex As Exception
                    lblerrmsg.Text = "Enter correct Date."
                    txtDate.Focus()
                    lblmsgifo.Text = ""
                End Try
            Else
                lblerrmsg.Text = "Not Accessible for Institute Admin."
                lblmsgifo.Text = ""
            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If btnDetails.Text = "VIEW" Then
            LinkButton1.Focus()
            txtFaculity.Focus()
            GridFaculity.Enabled = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            'If txtName.Text = "" Then
            '    s.Name = 0
            'Else
            '    s.Name = txtName.Text
            'End If
            ViewState("PageIndex") = 0
            GridFaculity.PageIndex = 0
            DispGrid()
            Clear()
        ElseIf btnDetails.Text = "BACK" Then
            GridFaculity.Enabled = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            Clear()
            GridFaculity.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub

    Sub DispGrid()
        EL.id = 0
        dt = BLL.getFaculityTime(EL)
        If dt.Rows.Count > 0 Then
            GridFaculity.Enabled = True
            GridFaculity.Visible = True
            GridFaculity.DataSource = dt
            GridFaculity.DataBind()
            'For Each rows As GridViewRow In GridFaculity.Rows
            '    If CType(rows.FindControl("lbloffer"), Label).Text = "01-Jan-9100" Then
            '        CType(rows.FindControl("lbloffer"), Label).Text = ""
            '    End If
            'Next
        Else
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
            GridFaculity.Visible = False
        End If
    End Sub
    Sub Clear()

        txtDate.Text = Format(Today, "dd-MMM-yyyy")
        txtHours.Text = ""
    End Sub

    Protected Sub GridFaculity_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridFaculity.PageIndexChanging
        GridFaculity.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridFaculity.PageIndex
        DispGrid()
        GridFaculity.Visible = True
        lblmsgifo.Text = " "
        lblerrmsg.Text = " "
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        Try
            txtFaculity.Text = Session("EmpCode") + " : " + Session("EmpName")
            'txtEmpCode.Text = Session("EmpCode")
            EL.Eid = Session("EmpID")
            'txtFaculity.Focus()
            If IsPostBack = False Then

                txtDate.Text = Format(Today, "dd-MMM-yyyy")
            End If

        Catch ex As Exception
            lblerrmsg.Text = "Not Accessible for Institute Admin"
            lblmsgifo.Text = ""

        End Try
    End Sub

    Protected Sub GridFaculity_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridFaculity.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If Session("EmpID") <> "" Then
                EL.id = CType(GridFaculity.Rows(e.RowIndex).FindControl("Label5"), HiddenField).Value
                BLL.DeleteFaculityTime(EL)

                'lblGreen.Visible = True
                lblerrmsg.Text = " "
                lblmsgifo.Text = "Data Deleted Successfully."
                Clear()
                GridFaculity.PageIndex = ViewState("PageIndex")
                DispGrid()
            Else
                lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
                lblmsgifo.Text = ""
            End If
        Else
            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub GridFaculity_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridFaculity.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        btnSave.Text = "UPDATE"
        btnDetails.Text = "BACK"
        ViewState("FTUIDAuto") = CType(GridFaculity.Rows(e.NewEditIndex).FindControl("Label5"), HiddenField).Value
        'txtFaculity.Text = CType(GridFaculity.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        txtDate.Text = CType(GridFaculity.Rows(e.NewEditIndex).FindControl("lbloffer"), Label).Text

        ddlCourseName.SelectedValue = CType(GridFaculity.Rows(e.NewEditIndex).FindControl("lblCourseID"), Label).Text
        'ddlBatchName.Items.Clear()
        ' ddlBatchName.AppendDataBoundItems = True
        ddlBatchName.DataSourceID = "ObjBatch"
        ddlBatchName.DataBind()
        Dim a As Integer = CInt(CType(GridFaculity.Rows(e.NewEditIndex).FindControl("lblBatchid"), Label).Text)
        ddlBatchName.SelectedValue = CInt(a)
        'If ddlSubject.SelectedValue = "" Then
        ddlSemester.Items.Clear()
        'ddlSemester.AppendDataBoundItems = True
        ddlSemester.DataSourceID = "ObjSemester"
        ddlSemester.DataBind()
        a = CInt(CType(GridFaculity.Rows(e.NewEditIndex).FindControl("lblSemesterID"), Label).Text)
        ddlSemester.SelectedValue = CInt(a)
        ddlSubject.Items.Clear()
        ' ddlSubject.AppendDataBoundItems = True
        ddlSubject.DataSourceID = "ObjSubject"
        ddlSubject.DataBind()
        ''Else
        ddlSubject.SelectedValue = CType(GridFaculity.Rows(e.NewEditIndex).FindControl("lblsubjectid"), Label).Text
        'End If
        txtHours.Text = CType(GridFaculity.Rows(e.NewEditIndex).FindControl("lblHours"), Label).Text
        EL.id = ViewState("FTUIDAuto")
        dt = BLL.getFaculityTime(EL)
        GridFaculity.DataSource = dt
        GridFaculity.DataBind()
        GridFaculity.Enabled = False
        GridFaculity.Visible = True
        'For Each rows As GridViewRow In GridFaculity.Rows
        '    If CType(rows.FindControl("lbloffer"), Label).Text = "01-Jan-9100" Then
        '        CType(rows.FindControl("lbloffer"), Label).Text = ""
        '    End If
        'Next
        'Else
        'lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsgifo.Text = ""
        'End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.SelectedIndexChanged
        ddlBatchName.Focus()
    End Sub

    Protected Sub ddlSubject_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.SelectedIndexChanged
        ddlSubject.Focus()
    End Sub


    Protected Sub ddlCourseName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourseName.SelectedIndexChanged
        ddlCourseName.Focus()
    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.SelectedIndexChanged
        ddlSemester.Focus()
    End Sub

    Protected Sub GridFaculity_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridFaculity.Sorting
        Dim sortingDirection As String = String.Empty
        If Dir() = SortDirection.Ascending Then
            Dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            Dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.id = 0
        dt = BLL.getFaculityTime(EL)

        GridFaculity.Enabled = True
        GridFaculity.Visible = True
        

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridFaculity.DataSource = sortedView
        GridFaculity.DataBind()
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
