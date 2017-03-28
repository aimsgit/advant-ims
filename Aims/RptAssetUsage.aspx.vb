
Partial Class RptAssetUsage
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable

    Protected Sub ReportViewer1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Load
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim BL As New AssetUsageB
        Dim Course As Integer = CInt(Request.QueryString.Get("Course"))
        Dim Batch As Integer = CInt(Request.QueryString.Get("Batch"))

        QueryStr.GetValue(Page.Request, Prop)
        Dim dt1 As New Data.DataTable
        dt1 = BL.RptAssetUssage(Prop.insID, Prop.brnID, Course, Batch)
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        Me.ReportViewer1.LocalReport.ReportPath = "RptAssetUsage.rdlc"
        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RptAssetUsage", dt1)
        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        ReportViewer1.LocalReport.Refresh()

        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Prop.userID, Prop.insID)
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
