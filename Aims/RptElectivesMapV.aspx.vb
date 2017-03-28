
Partial Class RptElectivesMapV
    Inherits BasePage
    Dim dt, dt1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLElectivesMapReport
        Dim obj As New SelfDetailsB
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim CourseId As Integer = Request.QueryString.Get("CourseId")
        Dim BatchId As Integer = Request.QueryString.Get("BatchId")
        Dim SemesterID As Integer = Request.QueryString.Get("SemesterID")
        Dim ElectiveID As Integer = Request.QueryString.Get("ElectiveID")
        Dim Sort As Integer = Request.QueryString.Get("Sort")
        dt1 = DL.Rpt_Electives(CourseId, BatchId, SemesterID, ElectiveID, Sort)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptElectivesMap.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_ElectivesMap", dt1)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()



            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            lblmsg.Text = "No Records to display."
        End If



    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class

