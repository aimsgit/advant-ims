
Partial Class frmAddBlacklist
    Inherits BasePage
    Dim IP As String
    Dim dt As DataTable
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If btnadd.Text = "UPDATE" Then
            IP = txtblackip.Text
            dt = DL_IP.CheckDuplicate(IP, ViewState("IP_ID"))
            If dt.Rows.Count > 0 Then
                lblerrmsg.Visible = True
                lblerrmsg.Text = "Data already Exists."
                lblmsg.Text = ""
            Else
                DL_IP.Update(ViewState("IP_ID"), IP)
                btnadd.Text = "ADD"
                btnview.Text = "VIEW"
                lblerrmsg.Text = ""
                lblmsg.Text = "Data Updated Successfully."
                DispGrid()
                txtblackip.Text = ""
            End If
        ElseIf btnadd.Text = "ADD" Then
            IP = txtblackip.Text
            dt = DL_IP.CheckDuplicate(IP, 0)
            If dt.Rows.Count > 0 Then
                lblerrmsg.Text = "Data already Exists."
                lblmsg.Text = ""
                btnadd.Text = "ADD"
                btnview.Text = "VIEW"

            Else
                IP = txtblackip.Text
                Dim i As New Integer
                i = DL_IP.Insert(IP)
                btnadd.Text = "ADD"
                lblerrmsg.Text = ""
                lblmsg.Text = "Data Saved Successfully."
                DispGrid()
                txtblackip.Text = ""
            End If

        End If

    End Sub

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        If btnview.Text = "VIEW" Then
            lblerrmsg.Text = ""
            lblmsg.Text = ""
            'clear()
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DispGrid()
        ElseIf btnview.Text = "BACK" Then
            txtblackip.Text = ""
            btnadd.Text = "ADD"
            btnview.Text = "VIEW"
            lblerrmsg.Text = ""
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()

        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DispGrid()
        GridView1.Visible = True
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim IP_ID = CType(GridView1.Rows(e.RowIndex).FindControl("id"), Label).Text
        DL_IP.Delete(IP_ID)
        lblerrmsg.Text = ""
        lblmsg.Text = "Data Deleted Successfully."
        GridView1.PageIndex = ViewState("PageIndex")
        DispGrid()
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Dim dt As New DataTable
        btnadd.Text = "UPDATE"
        btnview.Visible = True
        btnview.Text = "BACK"
        lblmsg.Text = ""
        lblerrmsg.Text = " "
        GridView1.Visible = True
        ViewState("IP_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("id"), Label).Text
        txtblackip.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblIP_No"), Label).Text
        dt = DL_IP.GetIP(ViewState("IP_ID"))
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
    End Sub
    Sub DispGrid()
        Dim dt As New DataTable
        Dim IP_No As String = "0"
        GridView1.Enabled = True
        dt = DL_IP.GetIP(IP_No)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
        Else
            lblmsg.Text = ""
            lblerrmsg.Text = "No records to display."
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
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

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        Dim IP_No As String = "0"
        GridView1.Enabled = True
        dt = DL_IP.CheckDuplicate(IP_No, 0)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
    End Sub
End Class
