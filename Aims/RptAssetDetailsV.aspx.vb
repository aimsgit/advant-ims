
Partial Class RptAssetDetailsV
    Inherits System.Web.UI.Page
    Dim ds1 As Data.DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim dt1 As New Data.DataTable
        Dim BLL As New ProspectusB
        Dim BAL As New AssetDetailsB
        Dim Prop As New QureyStringP

        QueryStr.GetValue(Page.Request, Prop)
        'Dim ins As Integer = CInt(Request.QueryString(1))
        ' Dim brn As Integer = CInt(Request.QueryString(0))
        Dim assettype As Integer = CInt(Request.QueryString.Get("assettype"))
        Dim asset As Integer = CInt(Request.QueryString.Get("asset"))


        'dt1 = BAL.GetReport(Prop.insID, Prop.brnID, assettype, asset)
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        Me.ReportViewer1.LocalReport.ReportPath = "RptAssetDetails.rdlc"
        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_AssetDetailsReport", dt1)
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
