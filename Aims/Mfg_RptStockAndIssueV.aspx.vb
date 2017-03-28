﻿
Partial Class Mfg_RptStockAndIssueV
    Inherits System.Web.UI.Page

    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, DS1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New Mfg_DLStockAudit
    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim StartDate As DateTime = Request.QueryString.Get("StartDate")
        Dim EndDate As DateTime = Request.QueryString.Get("EndDate")
        Dim CatId As String = Request.QueryString.Get("CatId")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = Mfg_DLStockAudit.GetStockIssue(CatId, StartDate, EndDate)
        If dt1.Rows.Count > 0 Then
            Try
                ReportViewer1.LocalReport.ReportPath = "Mfg_RptStockAndIssue.rdlc"
                dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_GetSaleAndIssue", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StartDate", StartDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", EndDate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                ReportViewer1.LocalReport.Refresh()
                DS1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
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

