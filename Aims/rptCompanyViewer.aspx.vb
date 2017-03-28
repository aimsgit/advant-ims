
Partial Class rptCompanyViewer
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim BLL As New CompanyManager
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = BLL.RptCompany(Prop.insID, Prop.brnID)
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        Me.ReportViewer1.LocalReport.ReportPath = "rptCompany.rdlc"
        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_PlacementCompany", dt1)
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
