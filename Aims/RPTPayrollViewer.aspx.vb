Partial Class RPTPayrollViewer
    Inherits System.Web.UI.Page
    Dim dtS As New Data.DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim empID As Int64 = Server.UrlDecode(Request.QueryString("empID"))
        Dim BAL As New BLPayroll
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        ReportViewer1.LocalReport.ReportPath = "RPTPayroll.rdlc"
        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_PayrollMaster", BAL.GetPayrollrpt(Request.QueryString(1), Request.QueryString(0), empID))

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
