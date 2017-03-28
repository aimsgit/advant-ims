﻿
Partial Class rptProspectusViewer
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim dt1 As New Data.DataTable
        Dim bal As New ProspectusB

        Dim ins As Integer = CInt(Request.QueryString(1))
        Dim brn As Integer = CInt(Request.QueryString(0))

        'dt1 = bal.GetReport(ins, brn)
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        Me.ReportViewer1.LocalReport.ReportPath = "rptProspectus.rdlc"
        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_Prospectus", dt1)
        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        ReportViewer1.LocalReport.Refresh()

        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
