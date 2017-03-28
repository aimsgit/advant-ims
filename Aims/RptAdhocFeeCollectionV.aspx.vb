﻿
Partial Class RptAdhocFeeCollectionV
    Inherits System.Web.UI.Page
    Dim bll As New FeePaymentDetailsB
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim bachid As Integer = CInt(Request.QueryString.Get("batch"))
        Dim stdid As String = Request.QueryString.Get("Std")
        Dim ID As String = Request.QueryString.Get("ID")

        dt1 = bll.getAdhocFeeReceipt(stdid, ID)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "rptAdhocReceipt.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_rptAdhocFeeReceipt", dt1)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            lblmsg.Text = "No Records to display"
        End If
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
