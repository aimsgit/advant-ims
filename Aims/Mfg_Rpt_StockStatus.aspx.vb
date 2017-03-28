
Partial Class Mfg_Rpt_StockStatus
    Inherits System.Web.UI.Page
    Dim Prop As New QureyStringP
    Dim ds1 As DataTable
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New Mfg_DLStockStatus
    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim productId As String = Request.QueryString.Get("productId")
        Dim godownNo As String = Request.QueryString.Get("godownNo")
        Dim rackNo As String = Request.QueryString.Get("rackNo")
        Dim Fromdate As DateTime = Request.QueryString.Get("Fromdate")
        Dim Todate As DateTime = Request.QueryString.Get("Todate")
        Dim Ptype As String = Request.QueryString.Get("Ptype")
        Dim category As Integer = Request.QueryString.Get("category")



        QueryStr.GetValue(Page.Request, Prop)


        dt1 = DL.GetViewdetails(productId, godownNo, rackNo, Fromdate, Todate, Ptype, category)
        If dt1.Rows.Count > 0 Then
            Try

                ReportViewer1.LocalReport.ReportPath = "Mfg_Rpt_StockStatus.rdlc"
                dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_GetStkStatusReport2", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Fromdate", Fromdate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", Todate, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("product", Product, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
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

        'lblErrorMsg.Text = "No Records to Display."

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
