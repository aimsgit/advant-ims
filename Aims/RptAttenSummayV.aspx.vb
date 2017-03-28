
Partial Class RptAttenSummayV
    Inherits BasePage
    Dim dt As DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DL As New DLReportsR
        Dim dt1, dt3, dt4 As New Data.DataTable

        Dim Batch As Integer = Request.QueryString.Get("Batch")
        Dim Semester As Integer = Request.QueryString.Get("Semester")
        Dim Subject As Integer = Request.QueryString.Get("Subject")
        Dim Sort As Integer = Request.QueryString.Get("Sort")


        dt1 = DLAttenSummary.RptAttenSummary(Batch, Semester, Subject, Sort)
            If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptAttenSummary.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_AttenSummary", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                lblmsg.Text = ""
            Else
                lblmsg.Text = "No Records to Display."
            End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
