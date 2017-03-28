
Partial Class Mfg_rptAreaAnalysisV
    Inherits BasePage

    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New Mfg_DLStockAudit

    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim Fromdate As Date = Request.QueryString.Get("Fromdate")
        Dim Todate As Date = Request.QueryString.Get("Todate")
        Dim AreaId As String = Request.QueryString.Get("Rbid")
        QueryStr.GetValue(Page.Request, Prop)
        If AreaId = 1 Then
            dt1 = Mfg_DLStockAudit.GetAreaAnalysis(AreaId, Fromdate, Todate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Mfg_rptAreaAnalysis.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_AreaWiseCustomerWiseSale", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Fromdate", Fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", Todate, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If
        End If

        If AreaId = 2 Then
            dt1 = Mfg_DLStockAudit.GetProductwisesale(AreaId, Fromdate, Todate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Mfg_rptProductwiseAreaAnalysis.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_AreaWiseProductWiseSale", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Fromdate", Fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", Todate, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If
        End If

        If AreaId = 3 Then
            dt1 = Mfg_DLStockAudit.Getcustomerwisesalesummary(AreaId, Fromdate, Todate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Mfg_rptAreaAnalysisCustomerSalesSummary.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_AreaWiseCustomerWiseSaleSummary", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Fromdate", Fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", Todate, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If
        End If

           



    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class



