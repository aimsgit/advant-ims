Imports System.Data.Sql
Partial Class RptTransportRegV
    Inherits BasePage
    Dim dt As DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DL As New DLReportsR
        Dim dt1 As New Data.DataTable

        Dim A_code As Integer = Request.QueryString.Get("A_code")
        Dim RouteId As Integer = Request.QueryString.Get("RouteId")

        dt1 = DL.TransportRegRpt(A_code, RouteId)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptTransportReg.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_TransportRegistration", dt1)
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
