﻿
Partial Class Mfg_RptStockReturnNoteV
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim ReturnNo As String = Request.QueryString.Get("ReturnNo")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = Mfg_DLStockReturn.PrintStockReturnNote(ReturnNo)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Mfg_RptStockReturnNote.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_RptStockReturnNote", dt1)
               
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblErrorMsg.Text = "No Records to Display"
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
