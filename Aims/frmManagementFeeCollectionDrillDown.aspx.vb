
Partial Class frmManagementFeeCollectionDrillDown
    Inherits BasePage

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim DL As New DLDashBoard
        Dim dt As New DataTable
        Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        Dim BranchCode As String = Request.QueryString.Get(("Branch_Code"))
        Dim CourseId As Integer = Request.QueryString.Get(("CourseId"))
        ' Dim BatchId As Integer = Request.QueryString.Get(("BatchId"))
        Dim Fromdate As Date = Request.QueryString.Get(("FromDate"))
        Dim Todate As Date = Request.QueryString.Get(("todate"))

        QueryStr.GetValue(Page.Request, Prop)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        dt = DL.DashBoardFeeCollectionDrillDown(BranchCode, CourseId, Fromdate, Todate)
        If dt.Rows.Count > 0 Then
            lblBranchNameBind.Text = dt.Rows(0).Item("BranchName")
            lblBranchtypeBind.Text = dt.Rows(0).Item("BranchTypeName")
            lblCourseBind.Text = dt.Rows(0).Item("CourseName")
            ' lblbatchBind.Text = dt.Rows(0).Item("Batch_No")

            If dt.Rows.Count = 0 Then
                GVDashBoardFeeCollection.DataSource = Nothing
                GVDashBoardFeeCollection.DataBind()
                msginfo.Text = "No records to display."
            Else
                GVDashBoardFeeCollection.DataSource = dt
                GVDashBoardFeeCollection.DataBind()
                Dim sample As Date
                For Each rows As GridViewRow In GVDashBoardFeeCollection.Rows
                    If CType(rows.FindControl("lblChqDate"), Label).Text = "" Then
                        CType(rows.FindControl("lblChqDate"), Label).Text = " "
                    Else
                        sample = CType(rows.FindControl("lblChqDate"), Label).Text
                        If sample = "1/1/9100" Then
                            CType(rows.FindControl("lblChqDate"), Label).Text = " "
                        End If
                    End If

                Next
            End If
        Else
            ' lblBatch.Visible = False
            lblBranchName.Visible = False
            lblBranchtype.Visible = False
            lblCourse.Visible = False
            lblBranchNameBind.Visible = False
            lblBranchtypeBind.Visible = False
            lblCourseBind.Visible = False
            'lblbatchBind.Visible = False
            panNote.Visible = False
            msginfo.Text = "No records to display."
        End If

    End Sub

    Protected Sub GVDashBoardFeeCollection_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVDashBoardFeeCollection.PageIndexChanging
        Dim DL As New DLDashBoard
        Dim dt As New DataTable
        Dim Prop As New QureyStringP
        GVDashBoardFeeCollection.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVDashBoardFeeCollection.PageIndex
        Dim BranchCode As String = Request.QueryString.Get(("Branch_Code"))
        Dim CourseId As Integer = Request.QueryString.Get(("CourseId"))
        ' Dim BatchId As Integer = Request.QueryString.Get(("BatchId"))
        Dim Fromdate As Date = Request.QueryString.Get(("FromDate"))
        Dim Todate As Date = Request.QueryString.Get(("todate"))

        QueryStr.GetValue(Page.Request, Prop)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString

        dt = DL.DashBoardFeeCollectionDrillDown(BranchCode, CourseId, Fromdate, Todate)
        If dt.Rows.Count > 0 Then
            lblBranchNameBind.Text = dt.Rows(0).Item("BranchName")
            lblBranchtypeBind.Text = dt.Rows(0).Item("BranchTypeName")
            lblCourseBind.Text = dt.Rows(0).Item("CourseName")
            ' lblbatchBind.Text = dt.Rows(0).Item("Batch_No")

            If dt.Rows.Count = 0 Then
                GVDashBoardFeeCollection.DataSource = Nothing
                GVDashBoardFeeCollection.DataBind()
                msginfo.Text = "No records to display."
            Else
                GVDashBoardFeeCollection.DataSource = dt
                GVDashBoardFeeCollection.DataBind()
                Dim sample As Date
                For Each rows As GridViewRow In GVDashBoardFeeCollection.Rows
                    If CType(rows.FindControl("lblChqDate"), Label).Text = "" Then
                        CType(rows.FindControl("lblChqDate"), Label).Text = " "
                    Else
                        sample = CType(rows.FindControl("lblChqDate"), Label).Text
                        If sample = "1/1/9100" Then
                            CType(rows.FindControl("lblChqDate"), Label).Text = " "
                        End If
                    End If

                Next
            End If
        Else
            ' lblBatch.Visible = False
            lblBranchName.Visible = False
            lblBranchtype.Visible = False
            lblCourse.Visible = False
            lblBranchNameBind.Visible = False
            lblBranchtypeBind.Visible = False
            lblCourseBind.Visible = False
            'lblbatchBind.Visible = False
            panNote.Visible = False
            msginfo.Text = "No records to display."
        End If
    End Sub
End Class
