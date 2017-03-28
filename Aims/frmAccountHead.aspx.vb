Partial Class frmAccountHead
    Inherits BasePage
    Dim BLL As New AccountHeadManager()
    Dim AccE As New AccountHead
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblmsg.Text = ""
        lblErrorMsg.Text = ""
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            cmbAcctOne_fill(cmbAGOne.SelectedValue)
            cmbAcctTwo_fill(cmbAGTwo.SelectedValue)
            txtAccHead.Focus()
        End If
    End Sub
    Protected Sub cmbAGOne_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAGOne.SelectedIndexChanged
        cmbAcctOne_fill(cmbAGOne.SelectedValue)
    End Sub
    Protected Sub cmbAGTwo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAGTwo.SelectedIndexChanged
        cmbAcctTwo_fill(cmbAGTwo.SelectedValue)
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Session("Privilages").ToString.Contains("W") Then
            txtAccHead.Focus()
            If (Session("BranchCode") = Session("ParentBranch")) Then
                
                If cmbAOT.SelectedValue = cmbATT.SelectedValue Then
                    lblmsg.Text = ""
                    lblErrorMsg.Text = "Account One Treatment and Account Two Treatment cannot be same."
                    cmbAOT.Focus()
                Else
                    lblErrorMsg.Text = ""
                    lblmsg.Text = ""
                    AccE.AccHead = txtAccHead.Text
                    AccE.UserCod = txtUserCod.Text
                    AccE.AGOnevalue = cmbAGOne.SelectedValue
                    AccE.AcctOneValue = cmbAcctOne.SelectedValue
                    AccE.AOTValue = cmbAOT.SelectedValue
                    AccE.AGTwoValue = cmbAGTwo.SelectedValue
                    AccE.AcctTwoValue = cmbAcctTwo.SelectedValue
                    AccE.ATTValue = cmbATT.SelectedValue
                    If txtBudget.Text = "" Then
                        AccE.Budget_Amount = 0
                    Else
                        AccE.Budget_Amount = txtBudget.Text

                    End If




                    If btnSave.Text = "UPDATE" Then
                        AccE.AccHeadID = ViewState("Account_Head_Id")
                        BLL.Update(AccE)
                        btnDetails.Text = "VIEW"
                        btnSave.Text = "ADD"
                        clear()
                        lblErrorMsg.Text = ""
                        GVGridView.PageIndex = ViewState("PageIndex")
                        DispGrid()
                        lblmsg.Text = "Data Updated Successfully."
                    Else

                        BLL.Insert(AccE)
                        ViewState("PageIndex") = 0
                        GVGridView.PageIndex = 0
                        DispGrid()
                        lblErrorMsg.Text = ""
                        lblmsg.Visible = True
                        lblmsg.Text = "Data Saved Successfully."
                        clear()
                    End If
                    GVGridView.Enabled = True
                    btnDetails.Enabled = True
                End If
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
                lblmsg.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
        End If

    End Sub
    Sub clear()
        txtAccCode.Text = ""
        txtUserCod.Text = ""
        txtAccHead.Text = ""
        txtBudget.Text = ""

        cmbAGOne.ClearSelection()
        cmbAGTwo.ClearSelection()
        'cmbAOT.ClearSelection()
        'cmbATT.ClearSelection()
        cmbAcctOne_fill(cmbAGOne.SelectedValue)
        cmbAcctTwo_fill(cmbAGTwo.SelectedValue)
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then
            If btnDetails.Text = "VIEW" Then
                ViewState("PageIndex") = 0
                GVGridView.PageIndex = 0
                DispGrid()
            Else
                GVGridView.PageIndex = ViewState("PageIndex")
                DispGrid()
                clear()
                btnDetails.Text = "VIEW"
                btnSave.Text = "ADD"
            End If
        Else
            lblErrorMsg.Text = "You do not have Read Privilage."
        End If
    End Sub
    Protected Sub GVGridView_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVGridView.PageIndexChanging
        GVGridView.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVGridView.PageIndex
        DispGrid()
    End Sub
    Sub DispGrid()
        Dim dt As New DataTable

        AccE.AccHeadID = "0"
        If txtAccHead.Text = "" Then
            AccE.AccHead = "0"
        Else
            AccE.AccHead = txtAccHead.Text
        End If
        AccE.AGOnevalue = cmbAGOne.SelectedValue
        AccE.AGTwoValue = cmbAGTwo.SelectedValue

        dt = BLL.GetAccountHead1(AccE)
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ""
            lblErrorMsg.Text = "No records to display."
            GVGridView.Visible = False
        Else
            GVGridView.DataSource = dt
            GVGridView.DataBind()
            GVGridView.Visible = True
            GVGridView.Enabled = True
            lblErrorMsg.Text = ""
            lblmsg.Text = ""
            LinkButton.Focus()
        End If
    End Sub
    Protected Sub GVGridView_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVGridView.RowDeleting
        If Session("Privilages").ToString.Contains("W") Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If CType(GVGridView.Rows(e.RowIndex).FindControl("lblBranchCode"), Label).Text = "000000000000" And Session("ParentBranch") <> "000000000000" Then
                    lblErrorMsg.Text = "Cannot delete pre defined account heads."
                    lblmsg.Text = ""
                Else
                    TextBox1.Text = CType(GVGridView.Rows(e.RowIndex).Cells(1).FindControl("AccID"), HiddenField).Value
                    BLL.Delete(TextBox1.Text)
                    'AlertEnterAllFields("Data Deleted Successfully")
                    GVGridView.PageIndex = ViewState("PageIndex")
                    DispGrid()
                    lblmsg.Text = "Data Deleted Successfully."
                    txtAccHead.Focus()
                    lblErrorMsg.Text = ""
                End If
            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
                lblmsg.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub GVGridView_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVGridView.RowEditing
        If Session("Privilages").ToString.Contains("W") Then
            'If (Session("BranchCode") = Session("ParentBranch")) Then
          
            If CType(GVGridView.Rows(e.NewEditIndex).FindControl("lblBranchCode"), Label).Text = "000000000000" And Session("ParentBranch") <> "000000000000" Then
                lblErrorMsg.Text = "Cannot edit pre defined account heads."
                lblmsg.Text = ""
            Else
                lblmsg.Text = ""
                lblErrorMsg.Text = ""
                txtAccHead.Text = CType(GVGridView.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
                txtUserCod.Text = CType(GVGridView.Rows(e.NewEditIndex).FindControl("Label9"), Label).Text
                txtAccCode.Text = CType(GVGridView.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
                cmbAGOne.SelectedValue = Trim(CType(GVGridView.Rows(e.NewEditIndex).FindControl("Label15"), Label).Text)
                cmbAcctOne_fill(cmbAGOne.SelectedValue)
                cmbAcctOne.SelectedValue = Trim(CType(GVGridView.Rows(e.NewEditIndex).FindControl("Label14"), Label).Text)
                cmbAOT.SelectedValue = Trim(CType(GVGridView.Rows(e.NewEditIndex).FindControl("Label13"), Label).Text)
                cmbAGTwo.SelectedValue = Trim(CType(GVGridView.Rows(e.NewEditIndex).FindControl("Label12"), Label).Text)
                cmbAcctTwo_fill(cmbAGTwo.SelectedValue)
                cmbAcctTwo.SelectedValue = Trim(CType(GVGridView.Rows(e.NewEditIndex).FindControl("Label11"), Label).Text)
                cmbATT.SelectedValue = Trim(CType(GVGridView.Rows(e.NewEditIndex).FindControl("Label10"), Label).Text)
                ViewState("Account_Head_Id") = CType(GVGridView.Rows(e.NewEditIndex).FindControl("AccID"), HiddenField).Value
                txtBudget.Text = CType(GVGridView.Rows(e.NewEditIndex).FindControl("lblBudget"), Label).Text
                'txtBudget.Text = Format(dt.Rows(0).Item("BudgetAmount"), "F2").ToString
                btnSave.Text = "UPDATE"
                btnDetails.Text = "BACK"


                AccE.AccHeadID = ViewState("Account_Head_Id")
                AccE.AccHead = "0"
                AccE.AGOnevalue = "0"
                AccE.AGTwoValue = "0"
                dt = BLL.GetAccountHead1(AccE)
                GVGridView.DataSource = dt
                GVGridView.DataBind()
                'btnDetails.Visible = True
                GVGridView.Enabled = False
            End If
            'Else
            'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
            'lblmsg.Text = ""
            'End If
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Sub cmbAcctOne_fill(ByVal Id As Int32)
        If cmbAGOne.SelectedIndex > -1 Then
            cmbAcctOne.DataSource = BLL.GetAcctsubgroupByAcctgroupID(Id)
            cmbAcctOne.DataBind()
        End If
    End Sub
    Sub cmbAcctTwo_fill(ByVal Id As Int32)
        If cmbAGTwo.SelectedIndex > -1 Then
            cmbAcctTwo.DataSource = BLL.GetAcctsubgroupByAcctgroupID(Id)
            cmbAcctTwo.DataBind()
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub cmbAcctOne_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcctOne.TextChanged
        cmbAcctOne.Focus()
    End Sub

    Protected Sub cmbAcctTwo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcctTwo.TextChanged
        cmbAcctTwo.Focus()
    End Sub

    Protected Sub cmbAGOne_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAGOne.TextChanged
        cmbAGOne.Focus()
    End Sub

    Protected Sub cmbAGTwo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAGTwo.TextChanged
        cmbAGTwo.Focus()
    End Sub

    Protected Sub cmbAOT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAOT.TextChanged
        cmbAOT.Focus()
    End Sub

    Protected Sub cmbATT_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbATT.TextChanged
        cmbATT.Focus()
    End Sub

    Protected Sub GVGridView_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVGridView.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        Dim dt As New DataTable

        AccE.AccHeadID = "0"
        If txtAccHead.Text = "" Then
            AccE.AccHead = "0"
        Else
            AccE.AccHead = txtAccHead.Text
        End If
        AccE.AGOnevalue = cmbAGOne.SelectedValue
        AccE.AGTwoValue = cmbAGTwo.SelectedValue

        dt = BLL.GetAccountHead1(AccE)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVGridView.DataSource = sortedView
        GVGridView.DataBind()
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
