
Partial Class Mfg_Rpt_MaterialIndentReport
    Inherits BasePage
    Dim Prop As New QureyStringP
    Dim ds1 As DataTable
    Dim dt2 As New DataTable
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New MaterialIndentDL
    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim Fromdate As DateTime = Request.QueryString.Get("Fromdate")
        Dim Todate As DateTime = Request.QueryString.Get("Todate")
        QueryStr.GetValue(Page.Request, Prop)
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        dt1 = DL.GetMaterialIndentReport(Fromdate, Todate)
        'Try
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "Mfg_Rpt_MaterialIndentReport.rdlc"
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_GetMaterialIndentReport", dt1)
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Fromdate", Fromdate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", Todate, False))
            ReportViewer1.LocalReport.SetParameters(paramList)
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()

            'dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()
            ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(0))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblErrorMsg.Text = "No records to display."
        End If

    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
