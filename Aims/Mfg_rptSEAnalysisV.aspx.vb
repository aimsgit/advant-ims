
Partial Class Mfg_rptSEAnalysisV
    Inherits BasePage

    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New Mfg_DLStockAudit

    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim StartDate As DateTime = Request.QueryString.Get("StartDate")
        Dim EndDate As DateTime = Request.QueryString.Get("EndDate")
        Dim SelectId As String = Request.QueryString.Get("SelectId")
        Dim Company As String = Request.QueryString.Get("CompanyId")
        QueryStr.GetValue(Page.Request, Prop)
        If SelectId = 1 Then
            dt1 = Mfg_DLStockAudit.GetSECompanyWise(Company, StartDate, EndDate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Mfg_rptSECompanyWise.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_CompanywiseSale", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
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
        If SelectId = 2 Then
            dt1 = Mfg_DLStockAudit.GetSESupplierWise(StartDate, EndDate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Mfg_rptSESupplierWise.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_RptSupplierwiseSale", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
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
        If SelectId = 3 Then
            dt1 = Mfg_DLStockAudit.GetSEInvoiceWise(StartDate, EndDate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Mfg_rptSEInvoiceWise.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_RptInvoicewiseSale", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
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
        'If SelectId = 4 Then
        '    dt1 = Mfg_DLStockAudit.GetSEDailyWise(SelectId, Company, StartDate, EndDate)

        '    If dt1.Rows.Count > 0 Then
        '        Try
        '            ReportViewer1.LocalReport.ReportPath = "Mfg_rptSEDailyWise.rdlc"
        '            dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_AreaAnalysisReport", dt1)
        '            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
        '            Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
        '            ReportViewer1.LocalReport.Refresh()
        '            ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
        '            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        '            lblErrorMsg.Text = ""
        '        Catch ex As Exception
        '            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        '        End Try
        '    Else
        '        lblErrorMsg.Text = "No Records to Display."
        '    End If
        'End If
        If SelectId = 5 Then
            dt1 = Mfg_DLStockAudit.GetSEProductWise(StartDate, EndDate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Mfg_rptSEProductWise.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_RptProductwiseSale", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
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



