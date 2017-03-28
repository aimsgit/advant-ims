
Partial Class frmNoticeBoard
    Inherits BasePage
    Dim dt As New DataTable
    Dim bl As New BLNoticeBoard
    Dim el As New ELCommunication

    Protected Sub btnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnShow.Click
        msginfo.Text = ""
        lblmsg.Text = ""
        dispgrid()
    End Sub

    Sub dispgrid()
        Try
            If ddlPublicNotice.SelectedValue = 0 And ddlBatchNotice.SelectedValue = 0 And ddlCourseNotice.SelectedValue = 0 Then
                msginfo.Text = "Select any one Group."
                ddlPublicNotice.Focus()
            Else
                If txtFrmDate.Text = "" Then
                    el.date1 = "01-01-9100"
                Else
                    el.date1 = txtFrmDate.Text
                End If

                If txtToDate.Text = "" Then
                    el.toDate = "01-01-9100"
                Else
                    el.toDate = txtToDate.Text
                End If

                If el.date1 > el.toDate Then
                    msginfo.Text = "From Date should not be greater than To Date."
                    txtFrmDate.Focus()

                Else
                    'If ddlCourseNotice.SelectedValue = 0 Then
                    '    '    el.GroupType = "Course"
                    '    '    el.ID = ""
                    '    'Else
                    '    el.GroupType = "Course"
                    '    el.ID = ddlCourseNotice.SelectedValue
                    'End If
                    If ddlBatchNotice.SelectedValue = 0 And ddlCourseNotice.SelectedValue = 0 Then

                        If ddlPublicNotice.SelectedValue = 1 Then
                            el.GroupType = "Public"
                            el.ID = 0
                        ElseIf ddlPublicNotice.SelectedValue = 2 Then
                            el.GroupType = "Employees"
                            el.ID = 0
                        ElseIf ddlPublicNotice.SelectedValue = 3 Then
                            el.GroupType = "Parents"
                            el.ID = 0
                        ElseIf ddlPublicNotice.SelectedValue = 4 Then
                            el.GroupType = "Transport"
                            el.ID = 0
                        End If
                    Else
                        If ddlBatchNotice.SelectedValue = 0 Then
                            'el.GroupType = "Batch"
                            'el.ID = ""
                            el.GroupType = "Course"
                            el.ID = ddlCourseNotice.SelectedValue
                        Else
                            el.GroupType = "Batch"
                            el.ID = ddlBatchNotice.SelectedValue
                        End If

                    End If
                    dt = bl.GetNotice(el)
                    If dt.Rows.Count <= 0 Then
                        msginfo.Text = "No records to display."
                        lblmsg.Text = ""
                        GVNoticeBoard.Visible = False
                    Else
                        GVNoticeBoard.DataSource = dt
                        GVNoticeBoard.DataBind()
                        GVNoticeBoard.Visible = True
                        GVNoticeBoard.Enabled = True
                    End If
                End If
            End If
        Catch ex As Exception
            msginfo.Text = "Enter Correct Date."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub ddlBatchNotice_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchNotice.PreRender
        If ddlBatchNotice.Items.Count > 0 Then
            If ddlBatchNotice.Items(0).Text <> "Select Batch" Then
                ddlBatchNotice.Items.Insert(0, "Select Batch")
            End If
        Else
            ddlBatchNotice.Items.Insert(0, "Select Batch")
        End If
    End Sub
    Protected Sub ddlPublicNotice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPublicNotice.SelectedIndexChanged
        ddlCourseNotice.ClearSelection()
        ddlBatchNotice.ClearSelection()
        GVNoticeBoard.Visible = False
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub
    Protected Sub ddlCourseNotice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourseNotice.SelectedIndexChanged
        ddlBatchNotice.ClearSelection()
        ddlPublicNotice.ClearSelection()
        GVNoticeBoard.Visible = False
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub
    Protected Sub ddlBatchNotice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchNotice.SelectedIndexChanged
        ddlPublicNotice.ClearSelection()
        ddlCourseNotice.ClearSelection()
        GVNoticeBoard.Visible = False
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If IsPostBack = False Then
            If Session("LoginType") = "Others" Then
                ddlPublicNotice.Items.RemoveAt(2)
            End If
        End If
        If Not Page.IsPostBack Then
            txtFrmDate.Text = Format(Date.Today, "dd-MMM-yyyy")
            txtToDate.Text = Format(Date.Today, "dd-MMM-yyyy")
            ddlPublicNotice.Focus()
        End If
    End Sub

    Protected Sub ddlBatchNotice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchNotice.TextChanged
        ddlBatchNotice.Focus()
    End Sub

    Protected Sub ddlCourseNotice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourseNotice.TextChanged
        ddlCourseNotice.Focus()
    End Sub

    Protected Sub ddlPublicNotice_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPublicNotice.TextChanged
        ddlPublicNotice.Focus()
    End Sub

    Protected Sub GVNoticeBoard_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVNoticeBoard.PageIndexChanging
        GVNoticeBoard.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVNoticeBoard.PageIndex
        dispgrid()
        GVNoticeBoard.Visible = True
    End Sub
End Class
