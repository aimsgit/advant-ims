﻿
Partial Class RptAimsUsageAnalyticsV
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New DLAimsUsageAnalytics

    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim InstId As String = Request.QueryString.Get("InstId")
        Dim BranchId As String = Request.QueryString.Get("BranchId")
        Dim TableId As Integer = Request.QueryString.Get("TableId")
        Dim FromDate As DateTime = Request.QueryString.Get("FromDate")
        Dim ToDate As DateTime = Request.QueryString.Get("ToDate")
      
        QueryStr.GetValue(Page.Request, Prop)

        dt1 = DLAimsUsageAnalytics.GetTableDetailsReport(InstId, BranchId, TableId, FromDate, ToDate)

        If dt1.Rows.Count > 0 Then
            Try
                ReportViewer1.LocalReport.ReportPath = "RptAimsUsageAnalytics.rdlc"
                dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetTableDetails", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", fromdate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", todate, False))
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





      

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class

