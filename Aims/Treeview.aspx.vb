Imports System.Text
Partial Class Treeview
    Inherits BasePage
    Dim BAL As New TreeViewB
    Dim PageIndex As Int32
    Dim nextClick As Int16
    Dim GlobalFunction As New GlobalFunction
    Dim a As Integer
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        'To Delete the records
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Dim Parent_ID As Int32 = CInt(CType(GridView1.Rows(e.RowIndex).FindControl("TextBox1"), TextBox).Text)
                Dim Child_ID As Int32 = CInt(CType(GridView1.Rows(e.RowIndex).FindControl("TextBox2"), TextBox).Text)
                BAL.DeleteChildNode(Parent_ID, Child_ID)
                Response.Redirect("TreeView.aspx")
            Else
                MsgBox("No Delete Permission!", MsgBoxStyle.OkOnly, "Alert")
            End If
        Else
            MsgBox("No Delete Permission!", MsgBoxStyle.OkOnly, "Alert")
        End If
    End Sub
    Protected Sub GridView1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView1.SelectedIndexChanged
        Dim rows As Int32
        Dim selectedrow As Int32 = GridView1.SelectedIndex + 1
        Dim id As Int32 = CType(GridView1.SelectedRow.Cells(1).FindControl("lblId"), HiddenField).Value
        Dim Parent_ID As Int32 = CInt(CType(GridView1.SelectedRow.FindControl("TextBox1"), TextBox).Text)
        Dim Child_ID As Int32 = CInt(CType(GridView1.SelectedRow.FindControl("TextBox2"), TextBox).Text)
        Dim title As String = CType(GridView1.SelectedRow.FindControl("TextBox3"), TextBox).Text
        Dim linkname As String = CType(GridView1.SelectedRow.FindControl("TextBox5"), TextBox).Text
        Dim parentname As String = CType(GridView1.SelectedRow.FindControl("TextBox4"), TextBox).Text
        Dim i As Int16

        Dim flagBreak As Int16 = 0
        For i = selectedrow To GridView1.Rows.Count - 1
            If Child_ID = CInt(CType(GridView1.Rows(i).FindControl("TextBox2"), TextBox).Text) Then
                flagBreak = 1
                Exit For
            End If
        Next

        For i = 0 To selectedrow - 2
            If Child_ID = CInt(CType(GridView1.Rows(i).FindControl("TextBox2"), TextBox).Text) Then
                flagBreak = 1
                Exit For
            End If
        Next
        If flagBreak = 0 Then
            rows = BAL.UpdateTreeView(id, Parent_ID, Child_ID, title, parentname, linkname, 0)
            Label2.ForeColor = Drawing.Color.Black
            Label2.Text = "Update the links in Tree View."
            msginfo.Text = "The child link under parent " & parentname & " is updated Successfully."
        Else
            Label2.ForeColor = Drawing.Color.Red
            Label2.Text = "This id is already in use."
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            PageIndex = 1
            Dim dt As New DataTable
            dt = BAL.GetTreeView(PageIndex)
            GridView1.DataSource = dt
            GridView1.DataBind()
            dt.Clear()
            dt = BAL.GetTreeView1(PageIndex)
            GridView2.DataSource = dt
            GridView2.DataBind()
            Session("NextClick") = 10
            LinkButton12.Visible = False
            LinkButton13.Visible = False
            LinkButton14.Visible = False
            LinkButton15.Visible = False
            LinkButton16.Visible = False
            LinkButton17.Visible = False
            LinkButton18.Visible = False
            LinkButton19.Visible = False
            LinkButton20.Visible = False
            LinkButton21.Visible = False
            LinkButton22.Visible = False
        End If
    End Sub
    Sub FillParentGrid(ByVal Parent_ID As Int32)
        'To fill the gridview
        Dim dt As New DataTable
        dt.Clear()
        dt = BAL.GetTreeView1(Parent_ID)
        GridView2.DataSource = dt
        GridView2.DataBind()
    End Sub
    Sub Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim sButton As String = CType(sender, Button).ID
        Label1.Text = "The Button " & sButton & "was clicked."
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        PageIndex = 1
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        PageIndex = 2
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        PageIndex = 3
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub
    Protected Sub LinkButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
        PageIndex = 4
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub
    Protected Sub LinkButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton5.Click
        PageIndex = 5
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub
    Protected Sub LinkButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton6.Click
        PageIndex = 6
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub
    Protected Sub LinkButton7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton7.Click
        PageIndex = 7
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub
    Protected Sub LinkButton8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton8.Click
        PageIndex = 8
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub
    Protected Sub LinkButton9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton9.Click
        PageIndex = 9
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub
    Protected Sub LinkButton10_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton10.Click
        PageIndex = 10
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub
    Protected Sub LinkButton11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton11.Click
        LinkButton1.Visible = False
        LinkButton2.Visible = False
        LinkButton3.Visible = False
        LinkButton4.Visible = False
        LinkButton5.Visible = False
        LinkButton6.Visible = False
        LinkButton7.Visible = False
        LinkButton8.Visible = False
        LinkButton9.Visible = False
        LinkButton10.Visible = False
        LinkButton11.Visible = False
        LinkButton12.Visible = True
        LinkButton13.Visible = True
        LinkButton14.Visible = True
        LinkButton15.Visible = True
        LinkButton16.Visible = True
        LinkButton17.Visible = True
        LinkButton18.Visible = True
        LinkButton19.Visible = True
        LinkButton20.Visible = True
        LinkButton21.Visible = True
        LinkButton22.Visible = True
        PageIndex = 11
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub

    Protected Sub LinkButton12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton12.Click
        LinkButton1.Visible = True
        LinkButton2.Visible = True
        LinkButton3.Visible = True
        LinkButton4.Visible = True
        LinkButton5.Visible = True
        LinkButton6.Visible = True
        LinkButton7.Visible = True
        LinkButton8.Visible = True
        LinkButton9.Visible = True
        LinkButton10.Visible = True
        LinkButton11.Visible = True
        LinkButton12.Visible = False
        LinkButton13.Visible = False
        LinkButton14.Visible = False
        LinkButton15.Visible = False
        LinkButton16.Visible = False
        LinkButton17.Visible = False
        LinkButton18.Visible = False
        LinkButton19.Visible = False
        LinkButton20.Visible = False
        LinkButton21.Visible = False
        LinkButton22.Visible = False
        PageIndex = 10
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
    End Sub

    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Dim rows As Int16
                Dim Parent_ID As Int32 = CInt(CType(GridView2.Rows(e.RowIndex).FindControl("TextBox1"), TextBox).Text)
                Dim parentname As String = CType(GridView2.Rows(e.RowIndex).FindControl("TextBox4"), TextBox).Text
                rows = BAL.UpdateParentTreeView(Parent_ID, parentname)
                msginfo.Text = "The parent is updated."
            Else
                MsgBox("No Write Permission!", MsgBoxStyle.OkOnly, "Alert")
            End If
        Else
            MsgBox("No Write Permission!", MsgBoxStyle.OkOnly, "Alert")
        End If
    End Sub

    Protected Sub GridView2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridView2.SelectedIndexChanged
        Dim rows As Int16
        Dim Parent_ID As Int32 = CInt(CType(GridView2.SelectedRow.FindControl("TextBox1"), TextBox).Text)
        Dim Child_ID As Int32 = CInt(CType(GridView2.SelectedRow.FindControl("TextBox2"), TextBox).Text)
        Dim title As String = CType(GridView2.SelectedRow.FindControl("TextBox3"), TextBox).Text
        Dim linkname As String = CType(GridView2.SelectedRow.FindControl("TextBox4"), TextBox).Text
        Dim parentname As String = CType(GridView2.SelectedRow.FindControl("TextBox5"), TextBox).Text
        rows = BAL.InsertTreeView(Parent_ID, Child_ID, title, linkname, parentname, 0)
        msginfo.Text = "You have successfully inserted a new link under " & parentname
    End Sub

    Protected Sub LinkButton13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton13.Click
        PageIndex = 11
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub

    Protected Sub LinkButton14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton14.Click
        PageIndex = 12
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub

    Protected Sub LinkButton15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton15.Click
        PageIndex = 13
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

    Protected Sub LinkButton16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton16.Click
        PageIndex = 14
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub

    Protected Sub LinkButton17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton17.Click
        PageIndex = 15
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub

    Protected Sub LinkButton18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton18.Click
        PageIndex = 16
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub

    Protected Sub LinkButton19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton19.Click
        PageIndex = 17
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub

    Protected Sub LinkButton20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton20.Click
        PageIndex = 18
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub

    Protected Sub LinkButton21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton21.Click
        PageIndex = 19
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub

    Protected Sub LinkButton22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton22.Click
        PageIndex = 20
        Dim dt As New DataTable
        dt = BAL.GetTreeView(PageIndex)
        GridView1.DataSource = dt
        GridView1.DataBind()
        FillParentGrid(PageIndex)
        Session("NextClick") = 10
        msginfo.Text = ""
    End Sub
End Class
