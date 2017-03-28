
Partial Class RptGenerateHallTicketReportChecked
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable
    Protected Sub ReportViewer2_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer2.Init
        Dim dl As New DLGenerateHallTicket
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim ExamBatch As Integer = Request.QueryString.Get("ExamBatchId")
        Dim Exam As String = Request.QueryString.Get("Exam")
        Dim FromSerialNo As String = Request.QueryString.Get("FromSerialNo")
        Dim ToSerialNo As String = Request.QueryString.Get("ToserialNo")
        Dim id As String = Request.QueryString.Get("id")
        dt1 = DLGenerateHallTicket.GenerateHallTicketReports(ExamBatch, FromSerialNo, ToSerialNo, id)
        dt2 = DLGenerateHallTicket.GenerateHallTicketCalenderReports(ExamBatch)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer2.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer2.LocalReport.ReportPath = "RptGenerateHallTicketReportChecked.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_GenerateHallTicketReportChecked", dt1)

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Exam", Exam, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", Todate, False))
                ReportViewer2.LocalReport.SetParameters(paramList)

                ReportViewer2.LocalReport.DataSources.Clear()
                Me.ReportViewer2.LocalReport.DataSources.Add(dt)
                ReportViewer2.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer2.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblMsg.Text = "No Records to Display"
            End If

        Catch ex As Exception
            lblMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rpt = e.ReportPath

        Select Case rpt
            'Case "RptGenerateHallTicketReportChecked"
            '    Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_GenerateHallTicketReportChecked", dt1)
            '    e.DataSources.Add(rptDataSource)
            Case "RptGeneratehallTicketCalenderReport"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_GenerateHallTicketCalendarChecked", dt2)
                e.DataSources.Add(rptDataSource)
            Case "MasterHeading"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
                e.DataSources.Add(rptDataSource)
        End Select
    End Sub
End Class
