
Partial Class RptFixedAssetsGrant
    Inherits System.Web.UI.Page
    Dim dtS As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim fstartdate As Date = CDate(Server.UrlDecode(Request.QueryString("FinStartDate")))
        Dim fenddate As Date = Server.UrlDecode(Request.QueryString("FinEndDate"))
        Dim BAL As New Depreciation_Rates
        Dim dt As New Data.DataTable
        Dim ds As New DataSet
        Dim DepreiciationRate As New DepreiciationRate
        ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "RptFixedAssetsGrant.rdlc"
        ds = BAL.GetDepreciation_Rates(DepreiciationRate)
        dt = ds.Tables(0)
        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_Depreciation", dt)

        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
        'Insert parameter list
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FinStartDate", fstartdate, False))
        ReportViewer1.LocalReport.SetParameters(paramList)

        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
        ReportViewer1.LocalReport.Refresh()

        'dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
