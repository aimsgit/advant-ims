
Partial Class frmBookSearch
    Inherits BasePage
    Dim sda As OleDbDataAdapter
    Dim prop As New BookSearch
    Dim BAl As New BookSearchB
    Dim sdt, sdt1, sdt2, dt, sdt5 As New DataTable()
    Dim sql, Crscode As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        'new_dbconn1.ConnectionString = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & ddlBranchType.ClientID & "').focus();</script>")
        ClientScript.RegisterHiddenField("_EVENTTARGET", "btnSave")
        If Not IsPostBack Then
            ddlBranchType.SelectedValue = Session("BranchCode")
        End If
        lblErrorMsg.Text = ""
        ddlBranchType.Focus()
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        txtBookName.Focus()
        If ddlDept.SelectedValue <> 0 OrElse txtAuthor.Text <> "" OrElse txtBookName.Text <> "" OrElse txtclassification.Text <> "" OrElse txtPublisher.Text <> "" OrElse cmbSubject.SelectedValue <> 0 OrElse txtisbn.Text <> "" Then
            prop.Branch = ddlBranchType.SelectedValue
            prop.Isbno = txtisbn.Text
            prop.Dept = ddlDept.SelectedValue
            prop.BookAuthor = txtAuthor.Text
            prop.BookName = txtBookName.Text
            prop.Classification = txtclassification.Text
            prop.publisher = txtPublisher.Text
            prop.Subject = cmbSubject.SelectedValue
            sdt = BAl.BookSearch(prop)
            If sdt.Rows.Count > 0 Then
                GVBookSearch.DataSource = sdt
                GVBookSearch.DataBind()
                LinkButton.Focus()
            Else
                clear()
                lblErrorMsg.Text = "Book not found."
            End If
        Else
            clear()
            lblErrorMsg.Text = "Enter any one Field."
        End If
    End Sub
    Sub clear()
        sdt.Clear()
        GVBookSearch.DataSource = sdt
        GVBookSearch.DataBind()
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
    Sub display()
        prop.Branch = ddlBranchType.SelectedValue
        prop.Isbno = txtisbn.Text
        prop.Dept = ddlDept.SelectedValue
        prop.BookAuthor = txtAuthor.Text
        prop.BookName = txtBookName.Text
        prop.Classification = txtclassification.Text
        prop.publisher = txtPublisher.Text
        prop.Subject = cmbSubject.SelectedValue
        sdt = BAl.BookSearch(prop)
        GVBookSearch.DataSource = sdt
        GVBookSearch.DataBind()
        GVBookSearch.Visible = True
    End Sub

    
    Protected Sub GVBookSearch_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVBookSearch.PageIndexChanging
        GVBookSearch.PageIndex = e.NewPageIndex
        GVBookSearch.DataBind()
        display()
        GVBookSearch.Visible = True
    End Sub
    Protected Sub GVBookSearch_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVBookSearch.RowEditing
        Session("BookName") = CType(GVBookSearch.Rows(e.NewEditIndex).FindControl("lblBookName"), Label).Text()
        Session("BookCode") = CType(GVBookSearch.Rows(e.NewEditIndex).FindControl("lblBookCode"), Label).Text()
        Session("Book_IDAuto") = CType(GVBookSearch.Rows(e.NewEditIndex).FindControl("lblBookid"), Label).Text()
        Response.Redirect("frmBookIssue.aspx")

    End Sub

    'Protected Sub GVBookSearch_RowIssue(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVBookSearch.RowEditing
    '    Session("BookName") = sdt.Rows(1)("BookName").ToString
    '    Session("BookCode") = sdt.Rows(10)("BookCode").ToString
    'End Sub

   
    Protected Sub GVBookSearch_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVBookSearch.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        prop.Branch = ddlBranchType.SelectedValue
        prop.Isbno = txtisbn.Text
        prop.Dept = ddlDept.SelectedValue
        prop.BookAuthor = txtAuthor.Text
        prop.BookName = txtBookName.Text
        prop.Classification = txtclassification.Text
        prop.publisher = txtPublisher.Text
        sdt = BAl.BookSearch(prop)
        GVBookSearch.DataSource = sdt
        Dim sortedView As New DataView(sdt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVBookSearch.DataSource = sortedView
        GVBookSearch.DataBind()
        GVBookSearch.Visible = True
        
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
