
Partial Class Rpt_TransportRegDetailsV
    Inherits BasePage
    Dim DL As New DLTransportRegDetails
    Dim ds1 As DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Try
            Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource

            Dim Prop As New QureyStringP
            Dim obj As New SelfDetailsB
            Dim dt1 As New DataTable

            QueryStr.GetValue(Page.Request, Prop)
            Dim A_Year As Integer = Request.QueryString.Get("A_Year")
            Dim RouteID As Integer = Request.QueryString.Get("RouteID")
            dt1 = DL.GetReportData(A_Year, RouteID)
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptTransportRegDetails.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_TransportRegDetails", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()

                'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
                'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No records to display."
            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class


