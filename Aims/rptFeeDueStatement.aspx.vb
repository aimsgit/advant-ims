
Partial Class rptFeeDueStatement
    Inherits BasePage
    Dim alt As String
    Dim dt As New Data.DataTable
    '    Dim rptDct As New ReportDocument
    Dim BLL As New FeeStructureManager
    'Dim BAL As New AssetTransfer.AssetTransferB
    Dim GlobalFunction As New GlobalFunction
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If ddlbatch1.Items.Count > 0 Then
            Dim BatchId As Integer = ddlbatch1.SelectedValue
            Dim SemID As Integer = ddlAYear.SelectedValue
            Dim StdID As Integer = ddlStudent.SelectedValue
            Dim CategoryID As Integer = ddlcategry.SelectedValue
            Dim CourseCode As Integer = ddlcourse.SelectedValue
            'dt = BLL.FeeDueReport(BatchId, SemID, StdID, CategoryID)
            'If dt.Rows.Count > 0 Then
            'Context.Items("State") = "Report"
            'FeeDueRpt.Crs = GlobalFunction.IdCutter(txtCourse.Text)
            'FeeDueRpt.Batch = GlobalFunction.IdCutter(txtBatch.Text)
            Dim qrystring As String = "rptFeeDueStatementV.aspx?" & QueryStr.Querystring() & "&BatchId=" & BatchId & "&SemID=" & SemID & "&StdID=" & StdID & "&CategoryID=" & CategoryID & "&CourseCode=" & CourseCode
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Else
            'lblE.Text = "No Records Found."
        End If
        'Else
        'AlertEnterAllFields("Select all the required fields.")
        'End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
