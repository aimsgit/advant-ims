Imports System.Data.OleDb
Imports System.Data
Partial Class DayBookRpt
    Inherits System.Web.UI.Page
    Dim dtS As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim fstartdate As Date = CDate(Server.UrlDecode(Request.QueryString("FinStartDate")))
        Dim fenddate As Date = Server.UrlDecode(Request.QueryString("FinEndDate"))
        Dim BAL As New GlobalDataSetTableAdapters.Test_Acct_DayBook_QryTableAdapter
        Dim dt As New Data.DataTable

        ReportViewer1.LocalReport.ReportPath = "rptDaybook.rdlc"
        'dt = BAL.GetData(Request.QueryString(1), Request.QueryString(0), fstartdate, fenddate)
        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Acct_DayBook_Qry", dt)

        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
        ReportViewer1.LocalReport.Refresh()

        'dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
