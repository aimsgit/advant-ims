
Partial Class rptRouteV
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As New DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim RouteManage As New RouteManager
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource

        dt1 = RouteManage.GetRouteRpt()
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptRouteMaster.rdlc"
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_RouteMasterDetails", dt1)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()
            ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            LblError.Text = "No Records to display"
        End If


        'QueryStr.GetValue(Page.Request, Prop)
        'dt1 = RouteManage.GetRouteRpt(Prop.insID, Prop.brnID)
        'Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        'Me.ReportViewer1.LocalReport.ReportPath = "rptRoute.rdlc"
        'dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RouteMaster", dt1)
        'ReportViewer1.LocalReport.DataSources.Clear()
        'Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        'ReportViewer1.LocalReport.Refresh()

        ''ds1 = obj.RPT_GetSelfDeatilsByBranch(Prop.userID, Prop.insID)
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
