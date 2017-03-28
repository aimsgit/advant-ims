
Partial Class frmManagementEmployeeDrillDown
    Inherits BasePage
    Dim DL As New DLDashBoard
    Dim dt, dt1, dt2 As New DataTable
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      
        Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        Dim BranchCode As String = Request.QueryString.Get(("Branch_Code"))

        QueryStr.GetValue(Page.Request, Prop)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        dt1 = DL.DashBoardEmployeeDrillDownCount(BranchCode)
        dt = DL.DashBoardEmployeeDrillDown(BranchCode)
        lblBranchNameBind.Text = dt.Rows(0).Item("BranchName")
        lblBranchtypeBind.Text = dt.Rows(0).Item("BranchTypeName")
        If dt.Rows.Count = 0 Then
            GVDashBoardEmployee.DataSource = Nothing
            GVDashBoardEmployee.DataBind()
            msginfo.Text = "No records to display."
        Else
            GVDashBoardEmployee.DataSource = dt
            GVDashBoardEmployee.DataBind()
            'For making date empty if the defualt value is binding in gridview
            Dim DOB As String
            If dt1.Rows.Count > 0 Then
                lblTStaff.Text = dt1.Rows(0).Item("TeachingStaff").ToString()
                lblNTStaff.Text = dt1.Rows(0).Item("NonTeachingStaff").ToString()
            End If
           For Each rows As GridViewRow In GVDashBoardEmployee.Rows
                DOB = CType(rows.FindControl("lblDOB"), Label).Text
                If DOB = "01-Jan-2999" Then
                    CType(rows.FindControl("lblDOB"), Label).Text = ""
                End If
            Next
            Dim DOJ As String
            For Each rows As GridViewRow In GVDashBoardEmployee.Rows
                DOJ = CType(rows.FindControl("lblDOJ"), Label).Text
                If DOJ = "01-Jan-3000" Then
                    CType(rows.FindControl("lblDOJ"), Label).Text = ""
                End If
            Next
        End If
        dt2 = DL.DashBoardEmployeeDrillDown1(BranchCode)
        If dt2.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            msginfo.Text = "No records to display."
        Else
            GridView1.DataSource = dt2
            GridView1.DataBind()
            'For making date empty if the defualt value is binding in gridview
            Dim DOB As String
            For Each rows As GridViewRow In GridView1.Rows
                DOB = CType(rows.FindControl("lblDOB1"), Label).Text
                If DOB = "01-Jan-2999" Then
                    CType(rows.FindControl("lblDOB1"), Label).Text = ""
                End If
            Next
            Dim DOJ As String
            For Each rows As GridViewRow In GridView1.Rows
                DOJ = CType(rows.FindControl("lblDOJ1"), Label).Text
                If DOJ = "01-Jan-3000" Then
                    CType(rows.FindControl("lblDOJ1"), Label).Text = ""
                End If
            Next
        End If
    End Sub

    Protected Sub GVDashBoardEmployee_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVDashBoardEmployee.PageIndexChanging
        GVDashBoardEmployee.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVDashBoardEmployee.PageIndex
        Dim BranchCode As String = Request.QueryString.Get(("Branch_Code"))
        dt = DL.DashBoardEmployeeDrillDown(BranchCode)
        GVDashBoardEmployee.DataSource = dt
        GVDashBoardEmployee.DataBind()
    End Sub
End Class
