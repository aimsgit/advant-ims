
Partial Class Rpt_InvoiceStatusV
    Inherits BasePage
    Dim DL As New DLCashBookReport
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt, DT5 As New DataTable

    Protected Sub RptInvoiceStatus_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles RptInvoiceStatus.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim fstartdate As Date = Request.QueryString.Get("FinStartDate")
        Dim fenddate As Date = Request.QueryString.Get("FinEndDate")
        Dim PR As String = Request.QueryString.Get("PR")
        Dim RT As Integer = Request.QueryString.Get("RT")
        dt1 = DL.InvoiceStatus(fstartdate, fenddate)
        If dt1.Rows.Count > 0 Then
            Me.RptInvoiceStatus.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.RptInvoiceStatus.LocalReport.ReportPath = "Rpt_InvoiceStatus.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_InvoiceStatus", dt1)
            RptInvoiceStatus.LocalReport.DataSources.Clear()
            Me.RptInvoiceStatus.LocalReport.DataSources.Add(dm)
            RptInvoiceStatus.LocalReport.Refresh()
            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler RptInvoiceStatus.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblmsg.Text = "No records to display."
        End If
    End Sub
   
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
