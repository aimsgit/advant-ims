Partial Class frmPurchaseIdCard
    Inherits BasePage
    Dim dt As New DataTable
    Dim el As New PurchaseIDCard
    Dim bl As New PurchaseIDCardB
    Dim dl As New PurchaseIDCardDB
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        txtreceiptno.Focus()
        'Code For ADD And Update Button By Nitin 14/06/2012
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnadd.Text = "UPDATE" Then
                el.Entrydate = txtDate.Text
                el.PreceiptNO = txtreceiptno.Text
                el.Quantity = txtquantity.Text
                el.Price = txtPrice.Text
                el.Remarks = txtRemarks.Text
                el.Id = ViewState("Id")
                dt = bl.CheckDuplicate(el)
                If dt.Rows.Count > 0 Then
                    lblerrmsg.Text = " Data already exists."
                    lblmsg.Text = ""
                    DispGrid()

                Else

                    bl.UpdateRecord(el)
                    btnadd.Text = "ADD"
                    GVpurchaseidcard.Visible = True
                    btnview.Text = "VIEW"
                    lblmsg.Visible = True
                    clear()
                    lblmsg.Text = " Data Updated Successfully."
                    lblerrmsg.Text = ""
                    GVpurchaseidcard.PageIndex = ViewState("PageIndex")
                    DispGrid()
                End If


            ElseIf btnadd.Text = "ADD" Then
                el.Entrydate = txtDate.Text
                el.PreceiptNO = txtreceiptno.Text
                el.Quantity = txtquantity.Text
                el.Price = txtPrice.Text
                el.Remarks = txtRemarks.Text
                dt = bl.CheckDuplicate(el)
                If dt.Rows.Count > 0 Then
                    lblerrmsg.Text = " Data already exists."
                    lblmsg.Text = ""
                    DispGrid()

                Else
                    el.Entrydate = txtDate.Text
                    el.PreceiptNO = txtreceiptno.Text
                    el.Quantity = txtquantity.Text
                    el.Price = txtPrice.Text
                    el.Remarks = txtRemarks.Text
                    bl.InsertRecord(el)
                    btnadd.Text = "ADD"
                    lblmsg.Visible = True
                    lblmsg.Text = " Data Saved Successfully."
                    lblerrmsg.Text = ""
                    clear()
                    ViewState("PageIndex") = 0
                    GVpurchaseidcard.PageIndex = 0
                    DispGrid()
                End If
            End If
            Else
            lblerrmsg.Text = " You do not belong to this branch, Cannot add/update data."
                lblmsg.Text = ""
            End If

    End Sub
    Sub clear()
        txtquantity.Text = ""
        txtPrice.Text = ""
        txtreceiptno.Text = ""
        txtRemarks.Text = ""
        txtDate.Text = Format(Date.Today, "dd-MMM-yyyy")
    End Sub
    Sub DispGrid()
        LinkButton1.Focus()
        el.Id = 0
        GVpurchaseidcard.Enabled = True
        dt = bl.GetPurchaseIDCard(el)
        If dt.Rows.Count > 0 Then
            GVpurchaseidcard.DataSource = dt
            GVpurchaseidcard.DataBind()
            GVpurchaseidcard.Visible = True
        Else
            lblmsg.Text = ""
            lblerrmsg.Visible = True
            lblerrmsg.Text = "No records to display."
        End If
    End Sub
    'Code For Row Index Change Event By Nitin 14/06/2012
    Protected Sub GVpurchaseidcard_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVpurchaseidcard.PageIndexChanging
        GVpurchaseidcard.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVpurchaseidcard.PageIndex
        DispGrid()
        GVpurchaseidcard.Visible = True
    End Sub
    'Code For Roe Deleteing Event By Nitin 14/06/2012
    Protected Sub GVpurchaseidcard_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVpurchaseidcard.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            bl.ChangeFlag(CType(GVpurchaseidcard.Rows(e.RowIndex).Cells(1).FindControl("PID"), HiddenField).Value)
            GVpurchaseidcard.DataBind()

            txtreceiptno.Focus()
            GVpurchaseidcard.PageIndex = ViewState("PageIndex")
            DispGrid()
            lblerrmsg.Text = ""
            lblmsg.Visible = True
            lblmsg.Text = " Data Deleted Successfully."
        Else
            lblerrmsg.Text = " You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub
    'Code For Row Editing Event By Nitin 14/06/2012
    Protected Sub GVpurchaseidcard_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVpurchaseidcard.RowEditing
        'If Session("BranchCode") = Session("ParentBranch") Then
        lblmsg.Text = ""
        lblerrmsg.Text = ""
        Dim dt As New DataTable
        btnadd.Text = "UPDATE"
        btnview.Text = True
        btnview.Text = "BACK"
        GVpurchaseidcard.Visible = True
        ViewState("Id") = CType(GVpurchaseidcard.Rows(e.NewEditIndex).FindControl("PID"), HiddenField).Value
        txtDate.Text = CType(GVpurchaseidcard.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        txtreceiptno.Text = CType(GVpurchaseidcard.Rows(e.NewEditIndex).FindControl("txtrecptno"), Label).Text
        txtquantity.Text = CType(GVpurchaseidcard.Rows(e.NewEditIndex).FindControl("lblquantity"), Label).Text
        txtPrice.Text = CType(GVpurchaseidcard.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        txtRemarks.Text = CType(GVpurchaseidcard.Rows(e.NewEditIndex).FindControl("Label6"), Label).Text
        el.Id = ViewState("Id")
        dt = bl.GetPurchaseIDCard(el)
        GVpurchaseidcard.DataSource = dt
        GVpurchaseidcard.DataBind()
        GVpurchaseidcard.Enabled = False
        'Else
        'lblerrmsg.Text = " You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'Code For View Button To Display Grid By Nitin 14/06/2012
    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        If btnview.Text = "VIEW" Then
            lblmsg.Text = ""
            lblerrmsg.Text = ""
            ViewState("PageIndex") = 0
            GVpurchaseidcard.PageIndex = 0
            DispGrid()
            'clear()
        ElseIf btnview.Text = "BACK" Then
            btnadd.Text = "ADD"
            btnview.Text = "VIEW"
            lblmsg.Text = ""
            lblerrmsg.Text = ""
            clear()
            GVpurchaseidcard.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If btnadd.Text <> "UPDATE" Then
            txtDate.Text = Format(Date.Today, "dd-MMM-yyyy")
            txtreceiptno.Focus()
        End If
    End Sub

    Protected Sub GVpurchaseidcard_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVpurchaseidcard.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        LinkButton1.Focus()
        el.Id = 0
        GVpurchaseidcard.Enabled = True
        dt = bl.GetPurchaseIDCard(el)
        GVpurchaseidcard.DataSource = dt
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVpurchaseidcard.DataSource = sortedView
        GVpurchaseidcard.DataBind()
        GVpurchaseidcard.Visible = True
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
