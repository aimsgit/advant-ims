﻿
Partial Class Mfg_RptPurchaseRequisitionReportV
    Inherits BasePage

    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New DLPurchaseRequisition

    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim StartDate As DateTime = Request.QueryString.Get("StartDate")
        Dim EndDate As DateTime = Request.QueryString.Get("EndDate")
        Dim PurchaseReqNo As String = Request.QueryString.Get("PurchaseReqNo")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DLPurchaseRequisition.GetPurchaseRequisition(StartDate, EndDate, PurchaseReqNo)
        If dt1.Rows.Count > 0 Then
            Try
                ReportViewer1.LocalReport.ReportPath = "Mfg_RptPurchaseRequisition.rdlc"
                dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_Rpt_PurchaseRequisition", dt1)
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
