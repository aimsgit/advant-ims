
Partial Class FrmCreateExamBatch
    Inherits BasePage
    Dim EL As New ELCreateExamBatch
    Dim BL As New BLCreateExamBatch
    Dim Dl As New DLCreateExamBatch
    Dim dt, dt1 As DataTable
    Sub CheckAll()
        If CType(GrdExamBatch.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            GrdExamBatch.Visible = True

            For Each grid As GridViewRow In GrdExamBatch.Rows
                CType(grid.FindControl("checkBox1"), CheckBox).Checked = True
            Next
        Else
            GrdExamBatch.Visible = True


            For Each grid As GridViewRow In GrdExamBatch.Rows
                CType(grid.FindControl("checkBox1"), CheckBox).Checked = False
            Next
        End If

    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If btnSave.Text = "UPDATE" Then

                    EL.id = ViewState("id")
                    EL.BatchName = txtExamBatch.Text
                    EL.Remarks = txtRemarks.Text
                    dt = DLCreateExamBatch.GetDuplData(EL)
                    If dt.Rows.Count > 0 Then
                        DisplayGrid()
                        lblmsgifo.Text = ""
                        lblerrmsg.Text = "Data already exists."
                        btnSave.Text = "ADD"
                        btnView.Text = "VIEW"
                    Else

                        BL.UpdateRecord(EL)
                        btnSave.Text = "ADD"
                        btnView.Text = "VIEW"
                        GrdExamBatch.PageIndex = ViewState("PageIndex")
                        DisplayGrid()
                        txtExamBatch.Text = ""
                        txtRemarks.Text = ""
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Updated Successfully."
                    End If
                ElseIf btnSave.Text = "ADD" Then
                    EL.BatchName = txtExamBatch.Text
                    EL.Remarks = txtRemarks.Text
                    dt = DLCreateExamBatch.GetDuplData(EL)
                    If dt.Rows.Count > 0 Then
                        DisplayGrid()
                        lblmsgifo.Text = ""
                        lblerrmsg.Text = "Data already exists."
                    Else
                        BL.InsertRecord(EL)
                        lblerrmsg.Text = ""
                        ViewState("PageIndex") = 0
                        GrdExamBatch.PageIndex = 0
                        DisplayGrid()
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Saved Successfully."
                        txtExamBatch.Text = ""
                        txtRemarks.Text = ""
                    End If
                End If
            Catch e1 As Exception
                lblerrmsg.Text = "Enter Correct Data."
                lblmsgifo.Text = ""
            End Try
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsgifo.Text = ""
        End If
    End Sub
    Sub DisplayGrid()
        EL.id = 0
        If txtExamBatch.Text = "" Then
            EL.BatchName = 0
        Else
            EL.BatchName = txtExamBatch.Text
        End If

        dt = BL.GetGridData(EL.id, EL.BatchName)
        If dt.Rows.Count = 0 Then
            GrdExamBatch.DataSource = Nothing
            GrdExamBatch.DataBind()
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
        Else
            GrdExamBatch.DataSource = dt
            GrdExamBatch.DataBind()
            GrdExamBatch.Enabled = True
            GrdExamBatch.Visible = True
            LinkButton.Focus()
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        txtExamBatch.Focus()
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        If btnView.Text <> "BACK" Then
            ViewState("PageIndex") = 0
            GrdExamBatch.PageIndex = 0
            DisplayGrid()
            GrdExamBatch.Visible = True
        Else
            btnView.Text = "VIEW"
            btnSave.Text = "ADD"
            GrdExamBatch.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            txtExamBatch.Text = ""
            txtRemarks.Text = ""

        End If

    End Sub
    'Protected Sub GrdExamBatch_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdExamBatch.RowDeleting

    '    If (Session("BranchCode") = Session("ParentBranch")) Then
    '        EL.id = CType(GrdExamBatch.Rows(e.RowIndex).Cells(1).FindControl("lblId"), Label).Text
    '        If BL.ChangeFlag(EL) Then
    '            lblerrmsg.Text = ""
    '            lblmsgifo.Text = "Data Deleted Successfully."
    '            txtExamBatch.Focus()
    '            GrdExamBatch.PageIndex = ViewState("PageIndex")
    '            DisplayGrid()
    '            GrdExamBatch.Enabled = True
    '        End If
    '    Else
    '        lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
    '        lblmsgifo.Text = ""
    '    End If
    'End Sub
    Protected Sub GrdExamBatch_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdExamBatch.PageIndexChanging
        GrdExamBatch.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GrdExamBatch.PageIndex
        DisplayGrid()
    End Sub
    Protected Sub GrdExamBatch_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdExamBatch.RowEditing
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        txtExamBatch.Text = CType(GrdExamBatch.Rows(e.NewEditIndex).FindControl("lblExamBatch"), Label).Text
        ViewState("id") = CType(GrdExamBatch.Rows(e.NewEditIndex).FindControl("lblId"), Label).Text
        txtRemarks.Text = CType(GrdExamBatch.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
        btnSave.Text = "UPDATE"
        btnView.Text = "BACK"
        EL.id = ViewState("id")
        EL.BatchName = txtExamBatch.Text
        dt = BL.GetGridData(EL.id, EL.BatchName)
        GrdExamBatch.DataSource = dt
        GrdExamBatch.DataBind()
        GrdExamBatch.Enabled = False
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            txtExamBatch.Focus()
        End If
    End Sub

    Protected Sub GrdExamBatch_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GrdExamBatch.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.id = 0
        If txtExamBatch.Text = "" Then
            EL.BatchName = 0
        Else
            EL.BatchName = txtExamBatch.Text
        End If
        dt = BL.GetGridData(EL.id, EL.BatchName)

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GrdExamBatch.DataSource = sortedView
        GrdExamBatch.DataBind()
        GrdExamBatch.Enabled = True
        GrdExamBatch.Visible = True
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
    

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Dim id As String = ""
        Dim check As String
        Dim ID1 As String = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            'ViewState("ExamBatch_Autoid") = CType(GrdExamBatch.SelectedValue.Cells(1).FindControl("lblId"), HiddenField).Value
            EL.id = ViewState("ExamBatch_Autoid")

            Dim dt As New DataTable

            Dim Count1 As Integer = 0
            For Each Grid As GridViewRow In GrdExamBatch.Rows

                If CType(Grid.FindControl("checkBox1"), CheckBox).Checked = True Then

                    check = CType(Grid.FindControl("lblId"), Label).Text

                    ID1 = check + "," + ID1
                    Count1 = Count1 + 1
                End If
            Next

                    If ID1 = "" Then
                        ID1 = 0
                    Else
                        ID1 = Left(ID1, ID1.Length - 1)
                    End If

            If Count1 > 0 Then
                'EL.id = ID1
                DLCreateExamBatch.ChangeFlagBatch(ID1)
                'If Count1 > 0 Then
                DisplayGrid()
                GrdExamBatch.Visible = True
                lblerrmsg.Text = ""
                lblmsgifo.Text = "Batch closed successfully."

                GrdExamBatch.PageIndex = ViewState("PageIndex")
                If txtExamBatch.Text = "" Then
                    EL.BatchName = 0
                Else
                    EL.BatchName = txtExamBatch.Text
                End If
                dt = BL.GetGridData(EL.id, EL.BatchName)

                GrdExamBatch.DataSource = dt
                GrdExamBatch.DataBind()
            Else
                lblmsgifo.Text = ""
                lblerrmsg.Text = "Please Select the Batch to Close."
            End If
        End If

    End Sub

End Class













