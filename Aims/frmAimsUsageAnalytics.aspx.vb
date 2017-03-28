
Partial Class frmAimsUsageAnalytics
    Inherits BasePage
    Dim BL As New BLAimsUsageAnalytics
    Dim DT As New DataTable
    Dim DL As New DLAimsUsageAnalytics
    Dim EL As New ELAimsUsageAnalytics


    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                lblMsg.Text = ""
                lblErrorMsg.Text = ""
                EL.InstId = ddlInstitute.SelectedValue
                EL.BranchId = ddlBranch.SelectedValue
                EL.TableId = DDLTableMaster.SelectedValue
                If txtfromdate.Text = "" Then
                    EL.FromDate = "1/1/1900"
                Else
                    EL.FromDate = txtfromdate.Text
                End If
                If txttodate.Text = "" Then
                    EL.ToDate = "1/1/3000"
                Else
                    EL.ToDate = txttodate.Text
                End If
                GVTableDetails.Enabled = True
                DT = BL.GetTableDetails(EL)
                If DT.Rows.Count > 0 Then
                    GVTableDetails.DataSource = DT
                    GVTableDetails.DataBind()
                    GVTableDetails.Visible = True
                    LinkButton1.Focus()

                Else
                    lblMsg.Text = ""
                    lblErrorMsg.Text = "No records to display."
                    GVTableDetails.Visible = False
                End If
            Catch ex As Exception
                lblErrorMsg.Text = "Data is Not Valid."
            End Try
        End If

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            txttodate.Text = Format(Date.Today(), "dd-MMM-yyyy")
            txtfromdate.Text = Format(Date.Today(), "dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                Dim InstId, BranchId, TableId As String
                Dim FromDate, ToDate As DateTime
                InstId = ddlInstitute.SelectedValue
                BranchId = ddlBranch.SelectedValue
                TableId = DDLTableMaster.SelectedValue
                If txtfromdate.Text = "" Then
                    FromDate = "1/1/1900"
                Else
                    FromDate = txtfromdate.Text
                End If
                If txttodate.Text = "" Then
                    ToDate = "1/1/3000"
                Else
                    ToDate = txttodate.Text
                End If

                Dim qrystring As String = "RptAimsUsageAnalyticsV.aspx?" & QueryStr.Querystring() & "&InstId=" & InstId & "&BranchId=" & BranchId & "&TableId=" & TableId & "&FromDate=" & FromDate & "&ToDate=" & ToDate
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            Catch ex As Exception
                lblErrorMsg.Text = "Data is Not Valid."
            End Try
        End If
    End Sub
End Class
