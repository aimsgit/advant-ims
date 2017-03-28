﻿
Partial Class RptCollectSpMoneyV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLcollectSponser
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim Academicyear As Integer = Request.QueryString.Get("Academicyear")
        Dim Batch As Integer = Request.QueryString.Get("Batch")
        Dim student As Integer = Request.QueryString.Get("student")
        Dim payment As Integer = Request.QueryString.Get("payment")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.GetRptCollectSponser(Academicyear, Batch, student, payment)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptCollectSpMoney.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RptCollectSponcerAmount", dt1)
                'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", ReceiveFrom, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ReceiveTo, False))

                'ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
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
