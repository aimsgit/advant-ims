
Partial Class FrmLoanTypeMaster
    Inherits BasePage
    Dim EL As New ELLoanTypeMaster
    Dim BL As New BLLoanTypeMaster
    Dim dt, dt1 As DataTable
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If btnSave.Text = "UPDATE" Then

                    EL.id = ViewState("id")
                    If txtLoancode.Text = "" Then
                        lblerrmsg.Text = "Loan Code field is mandatory."
                        lblmsgifo.Text = ""
                        txtLoancode.Focus()
                        Exit Sub
                    Else
                        EL.LoanCode = txtLoancode.Text

                    End If
                    If txtLoanType.Text = "" Then
                        lblerrmsg.Text = "Loan Type field is mandatory."
                        lblmsgifo.Text = ""
                        txtLoanType.Focus()
                        Exit Sub
                    Else
                        EL.LoanType = txtLoanType.Text
                    End If

                    dt = DLLoanTypeMaster.GetDuplData(EL)
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
                        GridView1.PageIndex = ViewState("PageIndex")
                        DisplayGrid()
                        txtLoancode.Text = ""
                        txtLoanType.Text = ""
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Updated Successfully."
                    End If

                ElseIf btnSave.Text = "ADD" Then
                    If txtLoancode.Text = "" Then
                        lblerrmsg.Text = "Loan Code field is mandatory."
                        lblmsgifo.Text = ""
                        txtLoancode.Focus()
                        Exit Sub
                    Else
                        EL.LoanCode = txtLoancode.Text

                    End If
                    If txtLoanType.Text = "" Then
                        lblerrmsg.Text = "Loan Type field is mandatory."
                        lblmsgifo.Text = ""
                        txtLoanType.Focus()
                        Exit Sub
                    Else
                        EL.LoanType = txtLoanType.Text
                    End If

                    dt = DLLoanTypeMaster.GetDuplData(EL)
                    If dt.Rows.Count > 0 Then
                        DisplayGrid()
                        lblmsgifo.Text = ""
                        lblerrmsg.Text = "Data already exists."
                    Else
                        BL.InsertRecord(EL)
                        lblerrmsg.Text = ""
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        DisplayGrid()
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Saved Successfully."
                        txtLoancode.Text = ""
                        txtLoanType.Text = ""
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
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        txtLoancode.Focus()
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        If btnView.Text <> "BACK" Then
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DisplayGrid()
            GridView1.Visible = True
        Else
            btnView.Text = "VIEW"
            btnSave.Text = "ADD"
            GridView1.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            txtLoancode.Text = ""
            txtLoanType.Text = ""
        End If
    End Sub
    Sub DisplayGrid()
        EL.id = 0
        dt = BL.GetGridData(EL.id)
        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
        Else
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            LinkButton.Focus()
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("LoanMaster_Autoid") = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("lblId"), Label).Text
            EL.id = ViewState("LoanMaster_Autoid")
            BL.ChangeFlag(EL)
            DisplayGrid()
            GridView1.Visible = True
            lblerrmsg.Text = ""
            lblmsgifo.Text = "Data Deleted Successfully."
            txtLoancode.Focus()
            GridView1.PageIndex = ViewState("PageIndex")

            dt = BL.GetGridData(EL.id)
            GridView1.DataSource = dt
            GridView1.DataBind()

            GridView1.Enabled = True
            GridView1.Visible = True
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If

    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        txtLoancode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblLoanCode"), Label).Text
        ViewState("id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblId"), Label).Text
        txtLoanType.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblLoanType"), Label).Text
        btnSave.Text = "UPDATE"
        btnView.Text = "BACK"
        EL.id = ViewState("id")
        dt = BL.GetGridData(EL.id)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGrid()
        GridView1.Visible = True
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
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
        EL.ID = 0
        EL.LoanCode = txtLoancode.Text


        dt = BL.GetGridData(EL.id)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Visible = True
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

End Class




