Imports System.Runtime.Serialization.Formatters.Binary
Imports System.io
Imports Attendance
Partial Class RptCertificateViewer
    Inherits System.Web.UI.Page
    Dim ds1 As New DataSet
    Dim dtS As New Data.DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim bl As New CertificateMasterB
        Dim obj As New SelfDetailsB
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Inst As String = Request.QueryString(1)
        Dim Bran As String = Request.QueryString(0)
        Dim Cour As String = Request.QueryString.Get("Course")
        Dim Btch As String = Request.QueryString.Get("BatchVal")
        Dim Code As String = Request.QueryString.Get("StdCode")
        Dim dt1 As New DataTable

        Me.ReportViewer1.LocalReport.ReportPath = "RptCertificate.rdlc"
        
        'dt1 = bl.GetCertificateDetail(Code, Btch, Cour, Inst, Bran)
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Std_marks", dt1)

        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        ReportViewer1.LocalReport.Refresh()

        'dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
