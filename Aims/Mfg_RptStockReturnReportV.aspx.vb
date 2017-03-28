
Partial Class Mfg_RptStockReturnReportV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DL As New Mfg_DLSaleReturn

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Rbid As Integer = Request.QueryString.Get("Rbid")
        Dim Fromdate As DateTime = Request.QueryString.Get("Fromdate")
        Dim Todate As DateTime = Request.QueryString.Get("Todate")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = Mfg_DLSaleReturn.GetSaleReturnReport(Rbid, Fromdate, Todate)

        If Rbid = "1" Then
            Try
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "Mfg_RptStockReturnReportV.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_StockReturnReport", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Fromdate", Fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", Todate, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    'ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = "No Records to Display."
                End If
            Catch ex As Exception
                lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
            End Try
        Else
            Try
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "Mfg_RptStockReturnReportV2.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_StockReturnReport", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Fromdate", Fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", Todate, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = "No Records to Display."
                End If
            Catch ex As Exception
                lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
            End Try

        End If


    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class