
Partial Class SalaryGradeV
    Inherits System.Web.UI.Page
    Dim dt2 As DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        'Dim DAl As New CoursePlanner
        Dim dtM, dtS As New Data.DataTable
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        QueryStr.GetValue(Page.Request, Prop)
       
        dtM = DLSalarygrade.GetSalarycode()

        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        Me.ReportViewer1.LocalReport.ReportPath = "SalaryGraderpt.rdlc"
        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_rptGetSalaryGrade", dtM)
        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        ReportViewer1.LocalReport.Refresh()

        dt2 = obj.RPT_GetSelfDeatilsByBranch("")
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub


End Class
