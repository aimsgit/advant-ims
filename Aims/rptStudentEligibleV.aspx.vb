
Partial Class BranchrptV
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim ds As DataTable

        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim brnID As Integer = CInt(Request.QueryString(0))
        Dim insID As Integer = CInt(Request.QueryString(1))
        'Dim DAL As New StudentResult.StdResultB
        QueryStr.GetValue(Page.Request, Prop)
        Dim Crs As Integer = CInt(Request.QueryString.Get("crs"))
        Dim BatchNo As Integer = CInt(Request.QueryString.Get("BatchNo"))
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        'ds = DAL.GetStdEligibleRpt(insID, brnID, Crs, BatchNo)
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        Me.ReportViewer1.LocalReport.ReportPath = "RptStudentEligible.rdlc"
        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_rpt_BatchWiseAtted", ds)
        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        ReportViewer1.LocalReport.Refresh()

        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
End Class
