﻿
Partial Class Rpt_AssetMaintenanceV
    Inherits BasePage
    Dim ds1 As Data.DataTable
    Dim dt2 As New DataTable
    Dim AssetDetailsDB As New AssetDetailsDB

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        'Code for to get Account Head Ledger by Nitin 05/07/2012 
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim FromDate As DateTime = Request.QueryString.Get("FromDate")
        Dim EndDate As DateTime = Request.QueryString.Get("ToDate")
        Dim assetType As String = Request.QueryString.Get("assetType")
        Dim AssetName As String = Request.QueryString.Get("AssetName")

        QueryStr.GetValue(Page.Request, Prop)

        dt1 = AssetDetailsDB.RptAssetMaintenance(assetType, AssetName, FromDate, EndDate)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_AssetMaintenance.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_AssetMaintenance", dt1)

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", EndDate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

            Else
                lblErrorMsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class