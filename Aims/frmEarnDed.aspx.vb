
Partial Class frmEarnDed
    Inherits BasePage
    Dim EL As New ELEarnDed
    Dim BL As New BLEarnDed
    Dim dt As New DataTable
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If btnSave.Text = "UPDATE" Then

                    EL.id = ViewState("LookUpAutoID")
                    EL.Description = txtDesription.Text
                    EL.SubDescription = txtSubDescription.Text
                    EL.EarnDedCode = txtEarnDedCode.Text
                    EL.EarnDedType = ddlEarnDed.SelectedValue
                    EL.Taxable = ddlTaxable.SelectedValue
                    EL.PFApplicable = ddlPFApplicable.SelectedValue
                    If ChkBoxHeader.Checked = True Then
                        EL.StopSalary = "Y"
                    Else
                        EL.StopSalary = "N"
                    End If
                    dt = DLEarnDed.GetDuplData(EL)

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
                        txtDesription.Text = ""
                        txtSubDescription.Text = ""
                        txtEarnDedCode.Text = ""
                        ChkBoxHeader.Checked = False
                        EL.EarnDedCode = txtEarnDedCode.Text
                        DisplayGrid()
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Updated Successfully."
                    End If

                ElseIf btnSave.Text = "ADD" Then

                    EL.Description = txtDesription.Text
                    EL.SubDescription = txtSubDescription.Text
                    EL.EarnDedCode = txtEarnDedCode.Text
                  EL.EarnDedType = ddlEarnDed.SelectedValue
                    EL.Taxable = ddlTaxable.SelectedValue
                    EL.PFApplicable = ddlPFApplicable.SelectedValue
                    If ChkBoxHeader.Checked = True Then
                        EL.StopSalary = "Y"
                    Else
                        EL.StopSalary = "N"
                    End If
                    dt = DLEarnDed.GetDuplData(EL)
                    If dt.Rows.Count > 0 Then
                        DisplayGrid()
                        lblmsgifo.Text = ""
                        lblerrmsg.Text = "Data already exists."
                        btnSave.Text = "ADD"
                        btnView.Text = "VIEW"
                    Else

                        BL.InsertRecord(EL)
                        lblerrmsg.Text = ""
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        DisplayGrid()
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Saved Successfully."
                        txtDesription.Text = ""
                        txtSubDescription.Text = ""
                        txtEarnDedCode.Text = ""
                        ChkBoxHeader.Checked = False
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
        txtDesription.Focus()
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        If (txtEarnDedCode.Text = "") Then
            EL.EarnDedCode = "0"
        Else
            EL.EarnDedCode = txtEarnDedCode.Text
        End If

        If btnView.Text <> "BACK" Then
            If (txtEarnDedCode.Text = "") Then
                EL.EarnDedCode = "0"
            Else
                EL.EarnDedCode = txtEarnDedCode.Text
            End If
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DisplayGrid()
            GridView1.Visible = True
        Else
            btnView.Text = "VIEW"
            btnSave.Text = "ADD"
            txtDesription.Text = ""
            txtSubDescription.Text = ""
            txtEarnDedCode.Text = ""
            ChkBoxHeader.Checked = False
            If (txtEarnDedCode.Text = "") Then
                EL.EarnDedCode = "0"
            Else
                EL.EarnDedCode = txtEarnDedCode.Text
            End If

            GridView1.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        End If
    End Sub
    Sub DisplayGrid()
        EL.id = 0
        If (txtEarnDedCode.Text = "") Then
            EL.EarnDedCode = "0"
        Else
            EL.EarnDedCode = txtEarnDedCode.Text
        End If
        dt = BL.GetGridData(EL)
        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
        Else
            If (txtEarnDedCode.Text = "") Then
                EL.EarnDedCode = "0"
            Else
                EL.EarnDedCode = txtEarnDedCode.Text
            End If
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            LinkButton.Focus()
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("LookUpAutoID") = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("lblId"), Label).Text
            EL.id = ViewState("LookUpAutoID")
            BL.ChangeFlag(EL)
            EL.EarnDedCode = CType(GridView1.Rows(e.RowIndex).FindControl("lblCode"), Label).Text()

            DisplayGrid()
            GridView1.Visible = True
            lblerrmsg.Text = ""
            lblmsgifo.Text = "Data Deleted Successfully."
            txtDesription.Focus()
            GridView1.PageIndex = ViewState("PageIndex")
          
            dt = BL.GetGridData(EL)
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
        EL.id = ViewState("LookUpAutoID")

        txtDesription.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblLongDescription"), Label).Text

        ViewState("LookUpAutoID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblId"), Label).Text
        txtSubDescription.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSubDes"), Label).Text
        txtEarnDedCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCode"), Label).Text
        ddlEarnDed.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblType"), Label).Text
        ddlTaxable.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblTaxable"), Label).Text
        ddlPFApplicable.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPF"), Label).Text
        If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblsalaryStop"), Label).Text = "N" Then
            ChkBoxHeader.Checked = False
        Else
            ChkBoxHeader.Checked = True
        End If
        btnSave.Text = "UPDATE"
        btnView.Text = "BACK"

        EL.id = ViewState("LookUpAutoID")
        If (txtEarnDedCode.Text = "") Then
            EL.EarnDedCode = "0"
        Else
            EL.EarnDedCode = txtEarnDedCode.Text
        End If
        dt = BL.GetGridData(EL)
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
        EL.id = 0
        If (txtEarnDedCode.Text = "") Then
            EL.EarnDedCode = "0"
        Else
            EL.EarnDedCode = txtEarnDedCode.Text
        End If
        dt = BL.GetGridData(EL)

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
