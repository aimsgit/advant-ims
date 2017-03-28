
Partial Class FrmCompareCourseAcrossBranches
    Inherits BasePage
    Dim BLCompareCourseAcrossBranches As New BLCompareCourseAcrossBranches
    Dim Dt As New DataTable
    Protected Sub BtnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnGenerate.Click
        LinkButton1.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                Dim CourseCode1, CourseCode2, CourseCode3, CourseCode4 As String
                If ddlCourse1.SelectedValue = "Select" Then
                    CourseCode1 = 0
                Else
                    CourseCode1 = ddlCourse1.SelectedValue
                End If
                If ddlCourse2.SelectedValue = "Select" Then
                    CourseCode2 = 0
                Else
                    CourseCode2 = ddlCourse2.SelectedValue
                End If
                If ddlCourse3.SelectedValue = "Select" Then
                    CourseCode3 = 0
                Else
                    CourseCode3 = ddlCourse3.SelectedValue
                End If
                If ddlCourse4.SelectedValue = "Select" Then
                    CourseCode4 = 0
                Else
                    CourseCode4 = ddlCourse4.SelectedValue
                End If

                Dt = BLCompareCourseAcrossBranches.GetGenerateView(CourseCode1, CourseCode2, CourseCode3, CourseCode4)
                If Dt.Rows.Count > 0 Then
                    GridView.DataSource = Dt
                    GridView.DataBind()
                    GridView.Visible = True
                    For Each rows As GridViewRow In GridView.Rows
                        If CType(rows.FindControl("lblMinPercentage"), Label).Text = "" And CType(rows.FindControl("lblMaxPercentage"), Label).Text = "" And CType(rows.FindControl("lblAvgPercentage"), Label).Text = "" And CType(rows.FindControl("lblMinPercentageC2"), Label).Text = "" And CType(rows.FindControl("lblMaxPercentageC2"), Label).Text = "" And CType(rows.FindControl("lblAvgPercentageC2"), Label).Text = "" And CType(rows.FindControl("lblMinPercentageC3"), Label).Text = "" And CType(rows.FindControl("lblMaxPercentageC3"), Label).Text = "" And CType(rows.FindControl("lblAvgPercentageC3"), Label).Text = "" And CType(rows.FindControl("lblMinPercentageC4"), Label).Text = "" And CType(rows.FindControl("lblMaxPercentageC4"), Label).Text = "" And CType(rows.FindControl("lblAvgPercentageC4"), Label).Text = "" Then
                            GridView.Visible = False
                            lblErrorMsg.Text = "No records to display."
                            Exit For
                        End If
                    Next
                Else
                    lblErrorMsg.Text = "No records to display."
                    GridView.Visible = False
                End If
            Catch ex As Exception

            End Try
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
        End If
    End Sub

    Protected Sub ddlCourse1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse1.SelectedIndexChanged
        lblErrorMsg.Text = ""
        GridView.Visible = False
    End Sub

    Protected Sub ddlCourse2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse2.SelectedIndexChanged
        lblErrorMsg.Text = ""
    End Sub

    Protected Sub ddlCourse3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse3.SelectedIndexChanged
        lblErrorMsg.Text = ""
    End Sub

    Protected Sub ddlCourse4_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse4.SelectedIndexChanged
        lblErrorMsg.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub
End Class
