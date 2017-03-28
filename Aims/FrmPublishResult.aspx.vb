
Partial Class FrmPublishResult
    Inherits BasePage
    Dim EL As New ELPublishResult
    Dim BL As New BLPublishresult
    Dim dt As New DataTable
    Sub CheckAll()
        If CType(GVPublishResult.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then

            For Each grid As GridViewRow In GVPublishResult.Rows
                CType(grid.FindControl("ChkPublish"), CheckBox).Checked = True
            Next
        Else

            For Each grid As GridViewRow In GVPublishResult.Rows
                CType(grid.FindControl("ChkPublish"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        lblRed.Text = ""
        lblGreen.Text = ""
        ViewState("PageIndex") = 0
        GVPublishResult.PageIndex = 0
        DisplayGrid()
        GVPublishResult.Visible = True
    End Sub
    Sub DisplayGrid()
        EL.Batchid = ddlbatch.SelectedValue
        EL.Semesterid = ddlsemester.SelectedValue
        EL.Subjectid = cmbSubject.SelectedValue
        EL.Assessmentid = ddlass.SelectedValue
        dt = BL.GetGridData(EL)
        If dt.Rows.Count = 0 Then
            GVPublishResult.DataSource = Nothing
            GVPublishResult.DataBind()
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
        Else
            GVPublishResult.DataSource = dt
            GVPublishResult.DataBind()
            GVPublishResult.Enabled = True
            GVPublishResult.Visible = True
            For Each Grid As GridViewRow In GVPublishResult.Rows
                If CType(Grid.FindControl("lblPublishStatus"), Label).Text = "Y" Then
                    CType(Grid.FindControl("ChkPublish"), CheckBox).Checked = True
                Else
                    CType(Grid.FindControl("ChkPublish"), CheckBox).Checked = False
                End If
                BL.UpdateRecord(EL)
            Next
        End If
    End Sub

    Protected Sub BtnPublish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPublish.Click
        EL.Batchid = ddlbatch.SelectedValue
        EL.Semesterid = ddlsemester.SelectedValue
        For Each Grid As GridViewRow In GVPublishResult.Rows

            EL.Subjectid = CType(Grid.FindControl("lblSubjectId"), Label).Text
            EL.Assessmentid = CType(Grid.FindControl("lblAssesmentTypeId"), Label).Text
            If CType(Grid.FindControl("ChkPublish"), CheckBox).Checked = True Then
                EL.Publish_Result = "Y"
            Else
                EL.Publish_Result = "N"
            End If
            BL.UpdateRecord(EL)
        Next
        DisplayGrid()
        lblGreen.Text = "Results Published Successfully."
        lblRed.Text = ""
    End Sub

    Protected Sub GVPublishResult_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GVPublishResult.RowUpdating
        EL.Batchid = ddlbatch.SelectedValue
        EL.Semesterid = ddlsemester.SelectedValue
        EL.Subjectid = CType(GVPublishResult.Rows(e.RowIndex).FindControl("lblSubjectId"), Label).Text
        EL.Assessmentid = CType(GVPublishResult.Rows(e.RowIndex).FindControl("lblAssesmentTypeId"), Label).Text
        If CType(GVPublishResult.Rows(e.RowIndex).FindControl("ChkPublish"), CheckBox).Checked = True Then
            EL.Publish_Result = "Y"
        Else
            EL.Publish_Result = "N"
        End If
        BL.UpdateRecord(EL)

        DisplayGrid()
        lblGreen.Text = "Results Published Successfully."
        lblRed.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub
End Class
