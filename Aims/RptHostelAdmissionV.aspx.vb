
Partial Class RptHostelAdmissionV
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DL As New DLHostelRpt
        Dim dt1 As New Data.DataTable
        Dim BranchCode As String = Request.QueryString.Get("BranchCode")
        Dim Hid As Integer = Request.QueryString.Get("HID")
        Dim Rid As Integer = Request.QueryString.Get("RID")
        Dim Status As Integer = Request.QueryString.Get("Status")
        Dim FrmDate As Date = Request.QueryString.Get("FrmDate")
        Dim ToDate As Date = Request.QueryString.Get("ToDate")

        dt1 = DLHostelRpt.GetHostelAdmissionDetailsRpt(Hid, Rid, Status, FrmDate, ToDate, BranchCode)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptHostelAdmission.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_HostelAdmission", dt1)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            lblmsg.Text = ""
        Else
            lblmsg.Text = "No Records to Display."

        End If

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
