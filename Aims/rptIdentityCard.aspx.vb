
Partial Class rptIdentityCard
    Inherits System.Web.UI.Page
    Dim ds1 As New Data.DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim Bran As Integer = CInt(Request.QueryString.Get("Branch"))
        Dim Cour As Integer = CInt(Request.QueryString.Get("Course"))
        Dim Btch As String = Request.QueryString.Get("Batch")
        Dim BLL As New ICardB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim dt1 As New DataTable

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = BLL.GetReport(Prop.insID, Prop.brnID, Cour, Btch)
        Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        Me.ReportViewer1.LocalReport.ReportPath = "rptIdentityCard.rdlc"
        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_IDCardIssuedDetails", dt1)
        Me.ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(dt)
        ReportViewer1.LocalReport.Refresh()

        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Prop.userID, Prop.insID)
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
