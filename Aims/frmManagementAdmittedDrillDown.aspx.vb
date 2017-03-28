
Partial Class frmManagementAdmittedDrillDown
    Inherits BasePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DL As New DLDashBoard
        Dim dt As New DataTable
        Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        Dim BranchCode As String = Request.QueryString.Get(("Branch_Code"))
        Dim CourseId As Integer = Request.QueryString.Get(("CourseId"))
        'Dim BatchId As Integer = Request.QueryString.Get(("BatchId"))

        QueryStr.GetValue(Page.Request, Prop)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        dt = DL.DashBoardAdmittedDrillDown(BranchCode, CourseId)
        lblBranchNameBind.Text = dt.Rows(0).Item("BranchName")
        lblBranchtypeBind.Text = dt.Rows(0).Item("BranchTypeName")
        lblCourseBind.Text = dt.Rows(0).Item("CourseName")
        'lblbatchBind.Text = dt.Rows(0).Item("Batch_No")

        If dt.Rows.Count = 0 Then
            GVDashBoardAdmitted.DataSource = Nothing
            GVDashBoardAdmitted.DataBind()
            msginfo.Text = "No records to display."
        Else
            GVDashBoardAdmitted.DataSource = dt
            GVDashBoardAdmitted.DataBind()

        End If
    End Sub
    Sub DisplayGrid()
        Dim DL As New DLDashBoard
        Dim dt As New DataTable
        Dim BranchCode As String = Request.QueryString.Get(("Branch_Code"))
        Dim CourseId As Integer = Request.QueryString.Get(("CourseId"))
        'Dim BatchId As Integer = Request.QueryString.Get(("BatchId"))
        dt = DL.DashBoardAdmittedDrillDown(BranchCode, CourseId)
        lblBranchNameBind.Text = dt.Rows(0).Item("BranchName")
        lblBranchtypeBind.Text = dt.Rows(0).Item("BranchTypeName")
        lblCourseBind.Text = dt.Rows(0).Item("CourseName")
        'lblbatchBind.Text = dt.Rows(0).Item("Batch_No")

        If dt.Rows.Count = 0 Then
            GVDashBoardAdmitted.DataSource = Nothing
            GVDashBoardAdmitted.DataBind()
            msginfo.Text = "No records to display."
        Else
            GVDashBoardAdmitted.DataSource = dt
            GVDashBoardAdmitted.DataBind()

        End If
    End Sub

    Protected Sub GVDashBoardAdmitted_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVDashBoardAdmitted.PageIndexChanging
        GVDashBoardAdmitted.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVDashBoardAdmitted.PageIndex
        DisplayGrid()
    End Sub
End Class
