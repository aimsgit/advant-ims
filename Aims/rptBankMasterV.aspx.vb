Imports System.Data.OleDb
Imports System.Data

Partial Class frmBankRptV
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
         Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Bl As New BankManager
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB

        QueryStr.GetValue(Page.Request, Prop)

        ReportViewer1.LocalReport.ReportPath = "RptBankMaster.rdlc"
        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_BankMaster", Bl.RptBank(Request.QueryString(1), Request.QueryString(0)))

        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
        ReportViewer1.LocalReport.Refresh()

        Dim brch As Integer = CInt(Request.QueryString.Get("Branch"))

        'dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
