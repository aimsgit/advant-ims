
Partial Class RptStudentAttendanceSummMonthWiseV
    Inherits BasePage

    Dim DL As New DLStudAttendanceSummary
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt, dt2, ParentDt, ParentDt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim SemId, BatchId As Integer
        Dim batchName As String
        BatchId = Request.QueryString.Get("BatchId")
        batchName = Request.QueryString.Get("batchName")
        SemId = Request.QueryString.Get("SemId")

        dt1 = DLStudAttendanceSummary.RptAttendanceSummary(BatchId, SemId)
        If dt1.Rows.Count > 0 Then

            ReportViewer1.LocalReport.ReportPath = "RptStudentAttendanceSummMonthWise.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_AttendanceSummaryMonthWise", dt1)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            LblError.Text = ""
        Else
            LblError.Text = "No Records to Display."
        End If
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
