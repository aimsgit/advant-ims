
Partial Class rptDBDeleteCount
    Inherits System.Web.UI.Page
    Dim dtM As New Data.DataTable
    Dim dt As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        dt1 = DLDBDeleteCount.GetDeleteCount()
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "DBDeleteCount.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_DeleteAllJunkDataCount", dt1)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            lblmsg.Text = "No Records to display"
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub

    'Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
    '    Dim DL As New VehicleDB
    '    Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
    '    QueryStr.GetValue(Page.Request, Prop)
    '    dt1 = DLDBDeleteCount.GetDeleteCount()

    '    Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & QueryStr.Querystring()
    '    If dt1.Rows.Count > 0 Then
    '        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
    '        Me.ReportViewer1.LocalReport.ReportPath = "DBDeleteCount.rdlc"
    '        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_DeleteAllJunkDataCount", dt1)
    '        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
    '        ReportViewer1.LocalReport.Refresh()
    '        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
    '        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    '    Else
    '        lblmsg.Text = "No Records to Display"
    '    End If

    'End Sub
    'Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
    '    Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
    '    e.DataSources.Add(rptDataSource)
    'End Sub

End Class
