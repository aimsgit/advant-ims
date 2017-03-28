Partial Class loanmasterRPT
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DAL As New loanmasterDA

        ReportViewer1.LocalReport.ReportPath = "loanmaster.rdlc"
        'dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_LoanMaster", DAL.GetData(Request.QueryString(1), Request.QueryString(0)))

        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
        ReportViewer1.LocalReport.Refresh()

        'dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class

