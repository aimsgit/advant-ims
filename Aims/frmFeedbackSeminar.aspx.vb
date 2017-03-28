
Partial Class frmFeedbackSeminar

    Inherits BasePage
    ''Created By- Ajit
    ''Date- 25 Mar 2013
    Dim FS As New FeedbackSeminarEL
    Dim FSB As New FeedbackSeminarBL
    Dim dt As DataTable


    Protected Sub ddlEmployee_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmployee.TextChanged
        Splitter(ddlEmployee.SelectedValue.ToString)
        ddlEmployee.Focus()
        lblerrmsg.Text = ""
        lblmsg.Text = ""
    End Sub
    Sub Splitter(ByVal s As String)

        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpID") = CInt(parts(0))
            FS.EmpID = ViewState("EmpID")
            txtDesignation.Text = parts(1).ToString()
        End If
    End Sub
    Protected Sub ddlDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartment.SelectedIndexChanged
        ddlDepartment.Focus()
        lblerrmsg.Text = ""
        lblmsg.Text = ""
    End Sub

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                FS.DeptID = ddlDepartment.SelectedValue
                Splitter(ddlEmployee.SelectedValue.ToString)
                'FS.EmpID = ddlEmployee.SelectedValue
                FS.ProgramTitle = txtProgramTitle.Text
                FS.Location = txtLocation.Text
                If txtFromDate.Text = "" Then
                    FS.FromDate = "1/1/1900"
                Else
                    FS.FromDate = txtFromDate.Text
                End If
                If txtToDate.Text = "" Then
                    FS.ToDate = "1/1/1900"
                Else
                    FS.ToDate = txtToDate.Text
                End If
                If CDate(IIf(txtFromDate.Text <> "", txtFromDate.Text, "1/1/1900")) > CDate(IIf(txtToDate.Text <> "", txtToDate.Text, "1/1/9100")) Then
                    lblerrmsg.Text = "From Date Cannot be greater than To Date."
                    lblmsg.Text = ""
                    Exit Sub
                End If
                FS.TrainingFaculty = txtTFaculty.Text
                FS.ProgramFeedback = txtPFE.Text
                FS.CanYou = ddlCan.SelectedValue
                FS.ProgramEffectiveness = txtHOD.Text

                If btnadd.Text = "UPDATE" Then
                    FS.Id = ViewState("FBAID")
                    FSB.UpdateRecord(FS)
                    btnadd.Text = "ADD"
                    btnview.Text = "VIEW"
                    lblerrmsg.Text = ""
                    lblmsg.Text = "Data Updated Successfully."
                    GridView1.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    GridView1.Enabled = "true"
                    clear()

                ElseIf btnadd.Text = "ADD" Then
                    FSB.InsertRecord(FS)
                    lblerrmsg.Text = ""
                    lblmsg.Text = "Data Saved Successfully."
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    DisplayGrid()
                    clear()
                End If
            Catch ex As Exception
                lblerrmsg.Text = "Date is not valid."
                lblmsg.Text = ""
            End Try
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub clear()
        txtFromDate.Text = ""
        txtToDate.Text = ""
        txtHOD.Text = ""
        txtLocation.Text = ""
        txtPFE.Text = ""
        txtProgramTitle.Text = ""
        txtTFaculty.Text = ""
    End Sub
    Sub DisplayGrid()
        FS.Id = 0
        dt = FSB.GetFeedback(FS)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblFromDate"), Label).Text = ""
                End If
            Next
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblToDate"), Label).Text = ""
                End If
            Next
            GridView1.Visible = "true"
            LinkButton.Focus()
        Else
            lblerrmsg.Text = "No records to display."
            lblmsg.Text = ""
            GridView1.Visible = "False"
        End If

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGrid()
        GridView1.Visible = "true"
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            FS.Id = CType(GridView1.Rows(e.RowIndex).FindControl("lblFBAID"), Label).Text
            FSB.ChangeFlag(FS)
            lblerrmsg.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            GridView1.PageIndex = ViewState("PageIndex")

            Dim dt As New DataTable
            FS.Id = 0
            dt = FSB.GetFeedback(FS)
            GridView1.DataSource = dt
            GridView1.DataBind()
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblFromDate"), Label).Text = ""
                End If
            Next
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblToDate"), Label).Text = ""
                End If
            Next
            GridView1.Visible = "true"
            LinkButton.Focus()
            GridView1.Visible = "true"
            LinkButton.Focus()
            clear()
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblerrmsg.Text = ""
        lblmsg.Text = ""
        GridView1.Enabled = "false"
        'ddlDepartment.Items.Clear()
        'ddlDepartment.DataSourceID = "objDepartment"
        'ddlDepartment.DataBind()
        ddlDepartment.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDeptID"), Label).Text
        Dim EmpID1 As Integer = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEmpID"), Label).Text
        Dim Designation As String = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDesignation"), Label).Text

        ddlEmployee.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEmpID"), Label).Text + ":" + CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDesignation"), Label).Text
        Splitter(ddlEmployee.SelectedValue.ToString)
        txtProgramTitle.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPTitle"), Label).Text
        txtLocation.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblLoc"), Label).Text
        txtFromDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblFromDate"), Label).Text
        txtToDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblToDate"), Label).Text
        txtTFaculty.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblTF"), Label).Text
        txtPFE.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPFE"), Label).Text
        Dim a As Integer
        a = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCan"), Label).Text
        ddlCan.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCan"), Label).Text
        txtHOD.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblHOD"), Label).Text
        ViewState("FBAID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblFBAID"), Label).Text
        btnadd.Text = "UPDATE"
        btnview.Text = "BACK"

        Dim dt As New DataTable
        FS.Id = ViewState("FBAID")
        dt = FSB.GetFeedback(FS)
        GridView1.DataSource = dt
        GridView1.DataBind()
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblFromDate"), Label).Text = ""
            End If
        Next
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblToDate"), Label).Text = ""
            End If
        Next
        GridView1.Visible = "true"
        LinkButton.Focus()

    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        lblerrmsg.Text = ""
        lblmsg.Text = ""
        If btnview.Text = "VIEW" Then
            DisplayGrid()
        Else
            btnview.Text = "VIEW"
            btnadd.Text = "ADD"
            clear()
            DisplayGrid()
            GridView1.Enabled = "True"
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
            ViewState("dirState") = Value
        End Set
    End Property
  

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable

        FS.Id = 0
        dt = FSB.GetFeedback(FS)
        GridView1.DataSource = dt
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblFromDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblFromDate"), Label).Text = ""
            End If
        Next
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lblToDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblToDate"), Label).Text = ""
            End If
        Next
        GridView1.Visible = "true"
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
