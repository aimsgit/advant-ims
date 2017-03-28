
Partial Class Mfg_Rpt_PurchaseInvoiceGRN
    Inherits BasePage
    Dim Prop As New QureyStringP
    Dim ds1 As DataTable
    Dim dt2 As New DataTable
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New Mfg_DLPurchaseInvoice
    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim id As String = Request.QueryString.Get("id")
        QueryStr.GetValue(Page.Request, Prop)
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        dt1 = DL.getPurchaseInv2(id)
        'Try
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "Mfg_RptPurchaseInvoicGRN.rdlc"
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_GetGRN_Details", dt1)
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
