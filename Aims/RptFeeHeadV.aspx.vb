
Partial Class RptFeeHeadV
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        'Dim bll As New FeeHeadsB
        Dim dt1 As New Data.DataTable
        'Dim DAL As New GlobalDataSetTableAdapters.proc_FeeHeadsTableAdapter

        Dim ins As Integer = CInt(Request.QueryString(1))
        Dim brn As Integer = CInt(Request.QueryString(0))


        'dt1 = bll.GetReportData(ins, brn)
        'dt1 = DAL.GetData(ins, brn)
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        Me.ReportViewer1.LocalReport.ReportPath = "rptFeeHeads.rdlc"
        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_FeeHeads", dt1)
        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        ReportViewer1.LocalReport.Refresh()
        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
