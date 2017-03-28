
Partial Class frmBookIssuedV
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim str As String
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim BAL As New BookIssueB
        Dim Cour As Integer
        Dim Btch As Integer

        Cour = CInt(Request.QueryString.Get("Course"))
        Btch = Request.QueryString.Get("Batch")
        str = Request.QueryString.Get("User").ToString

        If str = "Std" Then
            Dim dt1 As New Data.DataTable
            'Commented by Nethra during build on 09-apr-2012
            'dt1 = BAL.RptStdBookIssue(Request.QueryString(1), Request.QueryString(0))
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "BookIssuedStdRpt.rdlc"
            Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_DispGV_BookIssued", dt1)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()
            'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            Dim dt1 As New Data.DataTable
            'Commented by Nethra during build on 09-apr-2012
            'dt1 = BAL.RptEmpBookIssue(Request.QueryString(1), Request.QueryString(0))
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "BookIssuedEmpRpt.rdlc"
            Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_DispGV_BookIssued", dt1)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()
            'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
