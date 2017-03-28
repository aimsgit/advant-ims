
Partial Class BankReconciliationV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim DL As New BRSDB
        Dim FromDate As String = Request.QueryString.Get("FromDate")
        Dim ToDate As String = Request.QueryString.Get("ToDate")
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim fstartdate As Date = CDate(Server.UrlDecode(Request.QueryString("FinStartDate")))
        'Dim fenddate As Date = Server.UrlDecode(Request.QueryString("FinEndDate"))
        Dim BankId As Integer = Request.QueryString.Get(("BankId"))
        'Dim BAL As New GlobalDataSetTableAdapters.Test_BankReconciliationTableAdapter
        Dim dt As New Data.DataTable

        QueryStr.GetValue(Page.Request, Prop)

        dt1 = DL.GetBRSReport(FromDate, ToDate, BankId)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RPT_BankReconciliationt.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Rpt_BankReconciliation", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblMsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again."
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt1)
        e.DataSources.Add(rptDataSource)
    End Sub
    'QueryStr.GetValue(Page.Request, Prop)
    'dt1 = DL.GetSaleInvoice(Branch_Code, SetUp, ID, FromDate, ToDate)

    'ReportViewer1.LocalReport.ReportPath = "BankReconciliation.rdlc"
    ''dt = BAL.GetData(Request.QueryString(1), Request.QueryString(0), fstartdate, fenddate)
    'dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_BankReconciliation", dt)

    'ReportViewer1.LocalReport.DataSources.Clear()
    'Me.ReportViewer1.LocalReport.DataSources.Add(dm)
    'ReportViewer1.LocalReport.Refresh()

    ''dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
    'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
End Class
