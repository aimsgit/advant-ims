
Partial Class RptAccountHeadV
    Inherits System.Web.UI.Page
    Dim dtS As New DataTable
    'Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
    '    Dim obj As New SelfDetailsB
    '    Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
    '    'Dim BAL As New GlobalDataSetTableAdapters.AcctHead_QryTableAdapter
    '    Dim dt As New Data.DataTable
    '    Dim DL As New AccountHeadDB

    '    ReportViewer1.LocalReport.ReportPath = "rptAccountHead.rdlc"
    '    dt = DL.GetData() '(Request.QueryString(1), Request.QueryString(0))
    '    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_AcctHead_Qry", dt)

    '    ReportViewer1.LocalReport.DataSources.Clear()
    '    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
    '    ReportViewer1.LocalReport.Refresh()

    '    'dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
    '    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    'End Sub
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim DAL As New DesignationManager
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = AccountHeadDB.RptAccountHead(0)
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        Me.ReportViewer1.LocalReport.ReportPath = "rptAccountHead.rdlc"
        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_GetAccountHead", dt1)
        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        ReportViewer1.LocalReport.Refresh()

        dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
