
Partial Class Mfg_Rpt_PurchaseReturnreport
    Inherits System.Web.UI.Page
    Dim Prop As New QureyStringP
    Dim ds1 As DataTable
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New Mfg_DLPurchaseReturn
    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim id As String = Request.QueryString("id")


            QueryStr.GetValue(Page.Request, Prop)


            dt1 = DL.GetPurchaseReturnReport(id)
            If dt1.Rows.Count > 0 Then
                Try

                    ReportViewer1.LocalReport.ReportPath = "Mfg_RptPurchaseReturnReport.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_Rpt_PurchaseReturnReport", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Fromdate", FromDate, False))
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", Todate, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("product", Product, False))
                ReportViewer1.LocalReport.DataSources.Clear()
                'Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                'ReportViewer1.LocalReport.Refresh()

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

        'Catch ex As Exception
        '    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        'End Try

        'lblErrorMsg.Text = "No Records to Display."

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
