Partial Class Rpt_ProductWiseNearestEx
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New Mfg_DLStockAudit

    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim fromdate As DateTime = Request.QueryString.Get("fromdate")
        Dim todate As DateTime = Request.QueryString.Get("todate")
        Dim Product As Integer = Request.QueryString.Get("Product")
        Dim PurchaseInvNo As Integer = Request.QueryString.Get("PurchaseInvNo")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.getProductWiseNearsetEx(fromdate, todate, Product, PurchaseInvNo)
        If dt1.Rows.Count > 0 Then
            Try
                ReportViewer1.LocalReport.ReportPath = "Rpt_ProductWiseNearestEx.rdlc"
                dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_GetProductWiseNearestEx", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("product", Product, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("PurchaseInvNo", PurchaseInvNo, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Fromdate", fromdate, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", todate, False))


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
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub


End Class
