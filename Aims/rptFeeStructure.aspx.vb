
Partial Class rptFeeStructure
    Inherits BasePage
    Dim bll As New FeeStructB
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim AcademicYear As Integer = Request.QueryString.Get("AcademicYear")
        Dim Batch As Integer = Request.QueryString.Get("Batch")
        Dim Semester As Integer = Request.QueryString.Get("Semester")
        Dim Category As Integer = Request.QueryString.Get("Category")

        dt1 = bll.finalExamRpt(AcademicYear, Batch, Semester, Category)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "rptFeeStructure.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_FeeStructureReport", dt1)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            lblErrorMsg.Text = "No Records to display."
        End If
    End Sub
   
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
