
Partial Class frmAchievementAndAward
    Inherits BasePage
    Dim EL As New ELAchievementAndAward
    Dim BL As New BLAchievementAndAward
    Dim dt As DataTable
    Dim dispId As String

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                EL.EmpStudStatus = RbTYPE.SelectedValue
                EL.Departmentid = ddlDept.SelectedValue
                EL.AchievementDetails = txtAchievement.Text
                If txtDate.Text = "" Then
                    EL.AchievementDate = "1/1/1900"
                Else
                    EL.AchievementDate = txtDate.Text
                End If

                EL.Remarks = txtRemarks.Text
                If btnSave.Text = "UPDATE" Then
                    EL.id = ViewState("Achievement_Id_Auto")
                    'dt = BL.CheckDuplicate(EL)
                    'If dt.Rows.Count > 0 Then
                    '    lblerrmsg.Text = "Data already exists."
                    '    lblmsgifo.Text = " "
                    'Else
                    BL.Update(EL)
                    lblRed.Text = ""
                    lblGreen.Text = "Data Updated Successfully."
                    btnSave.Text = "ADD"
                    GridAchievementAward.Visible = True
                    btnDetails.Text = "VIEW"
                    Clear()
                    GridAchievementAward.PageIndex = ViewState("PageIndex")
                    DispGrid()
                    'End If
                Else
                    Dim i As Integer
                    i = BL.Insert(EL)
                    ViewState("dispId ") = CStr(i) + "," + ViewState("dispId ")

                    lblRed.Text = ""
                    lblGreen.Text = "Data Saved Successfully."
                    btnSave.Text = "ADD"
                    dt = BL.GetAddAchievement(ViewState("dispId "))
                    'dt = BAL.GetEnquiry(enq)
                    GridAchievementAward.Visible = True
                    GridAchievementAward.DataSource = dt
                    GridAchievementAward.DataBind()
                    For Each rows As GridViewRow In GridAchievementAward.Rows
                        If CType(rows.FindControl("lblGVAchievementDate"), Label).Text = "01-Jan-1900" Then
                            CType(rows.FindControl("lblGVAchievementDate"), Label).Text = ""
                        End If
                    Next
                    GridAchievementAward.Enabled = True
                    ViewState("PageIndex") = 0
                    GridAchievementAward.PageIndex = 0
                    'DispGrid()
                    Clear()
                End If
            Catch ex As Exception
                lblRed.Text = "Date Field is not Valid."
                lblGreen.Text = ""
            End Try
        Else
            lblRed.Text = "You do not belong to this branch, Cannot add/update data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If btnDetails.Text = "VIEW" Then
            lblRed.Text = " "
            lblGreen.Text = " "
            ViewState("PageIndex") = 0
            GridAchievementAward.PageIndex = 0
            DispGrid()

        ElseIf btnDetails.Text = "BACK" Then
            GridAchievementAward.Enabled = True
            lblRed.Text = " "
            lblGreen.Text = " "
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            Clear()
            GridAchievementAward.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub
    Sub DispGrid()
        EL.id = 0
        dt = BL.getAchievementAward(EL)
        If dt.Rows.Count > 0 Then
            GridAchievementAward.Enabled = True
            GridAchievementAward.Visible = True
            GridAchievementAward.DataSource = dt
            GridAchievementAward.DataBind()
            For Each rows As GridViewRow In GridAchievementAward.Rows
                If CType(rows.FindControl("lblGVAchievementDate"), Label).Text = "01-Jan-1900" Then
                    CType(rows.FindControl("lblGVAchievementDate"), Label).Text = ""
                End If
            Next
        Else
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
            GridAchievementAward.Visible = False
        End If
    End Sub

    Protected Sub GridAchievementAward_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridAchievementAward.PageIndexChanging
        GridAchievementAward.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridAchievementAward.PageIndex
        DispGrid()
        GridAchievementAward.Visible = True
        lblRed.Text = " "
        lblGreen.Text = " "
    End Sub

    Protected Sub GridAchievementAward_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridAchievementAward.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GridAchievementAward.Rows(e.RowIndex).FindControl("lblID"), HiddenField).Value
            BL.Delete(EL)

            Clear()
            GridAchievementAward.PageIndex = ViewState("PageIndex")
            DispGrid()
            lblRed.Text = " "
            lblGreen.Text = "Data Deleted Successfully."
        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub GridAchievementAward_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridAchievementAward.RowEditing

        lblRed.Text = ""
        lblGreen.Text = ""
        btnSave.Text = "UPDATE"
        btnDetails.Visible = True
        btnDetails.Text = "BACK"
        GridAchievementAward.Visible = True
        ViewState("Achievement_Id_Auto") = CType(GridAchievementAward.Rows(e.NewEditIndex).FindControl("lblID"), HiddenField).Value
        ddlDept.SelectedValue = CType(GridAchievementAward.Rows(e.NewEditIndex).FindControl("lblGVDepartmentID"), Label).Text
        EL.EmpStudStatus = CType(GridAchievementAward.Rows(e.NewEditIndex).FindControl("lblGVStdEmpStatusId"), Label).Text
        txtAchievement.Text = CType(GridAchievementAward.Rows(e.NewEditIndex).FindControl("lblGVAchievementDetails"), Label).Text
        txtDate.Text = CType(GridAchievementAward.Rows(e.NewEditIndex).FindControl("lblGVAchievementDate"), Label).Text
        txtRemarks.Text = CType(GridAchievementAward.Rows(e.NewEditIndex).FindControl("lblGVRemarks"), Label).Text
        If EL.EmpStudStatus = 1 Then
            RbTYPE.SelectedValue = 1
        ElseIf EL.EmpStudStatus = 2 Then
            RbTYPE.SelectedValue = 2
        End If
        EL.id = ViewState("Achievement_Id_Auto")
        dt = BL.getAchievementAward(EL)
        GridAchievementAward.DataSource = dt
        GridAchievementAward.DataBind()
        GridAchievementAward.Enabled = False
        GridAchievementAward.Visible = True
        For Each rows As GridViewRow In GridAchievementAward.Rows
            If CType(rows.FindControl("lblGVAchievementDate"), Label).Text = "01-Jan-9100" Then
                CType(rows.FindControl("lblGVAchievementDate"), Label).Text = ""
            End If
        Next
    End Sub
    Public Sub Clear()
        RbTYPE.SelectedValue = 1
        txtAchievement.Text = ""
        txtDate.Text = Format(Today, "dd-MMM-yyyy")
        txtRemarks.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RbTYPE.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlDept_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDept.SelectedIndexChanged
        ddlDept.Focus()
    End Sub

    Protected Sub GridAchievementAward_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridAchievementAward.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.id = 0
        dt = BL.getAchievementAward(EL)
    
       
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridAchievementAward.DataSource = sortedView
        GridAchievementAward.Enabled = True
        GridAchievementAward.Visible = True
        GridAchievementAward.DataBind()
        For Each rows As GridViewRow In GridAchievementAward.Rows
            If CType(rows.FindControl("lblGVAchievementDate"), Label).Text = "01-Jan-1900" Then
                CType(rows.FindControl("lblGVAchievementDate"), Label).Text = ""
            End If
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
            ViewState("dirState") = value
        End Set
    End Property
End Class
