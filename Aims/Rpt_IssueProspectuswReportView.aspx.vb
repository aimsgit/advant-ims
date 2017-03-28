
Partial Class Rpt_IssueProspectuswReportView
    Inherits System.Web.UI.Page
    Dim ds1, dt4 As New DataTable


    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim DAL As New DLIssuePorspectusReport
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Sdate As String = Request.QueryString.Get("Sdate")
        Dim Edate As String = Request.QueryString.Get("Edate")


        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DLIssuePorspectusReport.Get_Convaction(Sdate, Edate)
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "RptIssueProspectReport.rdlc"
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_ReportProspBalance", dt1)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()
            dt4 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblerror.Text = "No records to display."
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt4)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
