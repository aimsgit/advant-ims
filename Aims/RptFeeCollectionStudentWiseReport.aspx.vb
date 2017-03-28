
Partial Class RptFeeCollectionStudentWiseReport
    Inherits System.Web.UI.Page
    Dim Bl As New FeeCollectionBL
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt As New DataTable
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim AT As String = Request.QueryString.Get("A_Year")
        Dim Bat As String = Request.QueryString.Get("Batch")
        Dim Sem As String = Request.QueryString.Get("Semester")
        Dim StudentCode As Integer = Request.QueryString.Get("StudentCode")

        dt1 = Bl.FeeCollectionStudentWiseReport(AT, Bat, Sem, StudentCode)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptFeeCollectionStudentWiseReport.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_FeeCollectionStudentWiseReport", dt1)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            LblError.Text = "No Records to display."
        End If
    End Sub

End Class
