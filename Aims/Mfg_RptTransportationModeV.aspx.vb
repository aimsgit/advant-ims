﻿
Partial Class Mfg_RptTransportationModeV
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    'Code written By Niraj
    '23-Jan-2013
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLRptTransportationMode
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Shipping As String = Request.QueryString.Get("Shipping_ID")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.GetTransport(Shipping)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Mfg_RptTransportationMode.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_RptTransportationMode", dt1)
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
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class