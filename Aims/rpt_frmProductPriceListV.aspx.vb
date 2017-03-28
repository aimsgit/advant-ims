
Partial Class rpt_frmProductPriceListV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New Mfg_DLStockAudit

    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim ProductId As String = Request.QueryString.Get("ProductId")
        Dim SupplierId As String = Request.QueryString.Get("SupplierId")
        Dim category As String = Request.QueryString.Get("category")
        QueryStr.GetValue(Page.Request, Prop)

        dt1 = Mfg_DLStockAudit.GetProductPriceList(ProductId, category, SupplierId)

        If dt1.Rows.Count > 0 Then
            Try
                ReportViewer1.LocalReport.ReportPath = "rpt_frmProductPriceList.rdlc"
                dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_ProductPriceList", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Product", Product, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Supplier", Supplier, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Manufacturer", Manufacturer, False))
                Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(0))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                lblErrorMsg.Text = ""
            Catch ex As Exception
                lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
            End Try
        Else
            lblErrorMsg.Text = "No Records to Display."
        End If
        'Else

        '    dt1 = Mfg_DLStockAudit.GetSupplierWisePriceList(SupplierId)
        '    If dt1.Rows.Count > 0 Then
        '        Try
        '            ReportViewer1.LocalReport.ReportPath = "rpt_frmSupplierWisePriceList.rdlc"
        '            dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_SupplierWisePriceList", dt1)
        '            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
        '            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Product", Product, False))
        '            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Supplier", Supplier, False))
        '            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Manufacturer", Manufacturer, False))
        '            Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
        '            ReportViewer1.LocalReport.Refresh()
        '            ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(0))
        '            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        '            lblErrorMsg.Text = ""
        '        Catch ex As Exception
        '            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        '        End Try
        '    Else
        '        lblErrorMsg.Text = "No Records to Display."
        '    End If
        'End If
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class



