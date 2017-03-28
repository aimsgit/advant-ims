
Partial Class Rpt_LoanTypeWiseLoanStatementReportV
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable
    Dim obj As New SelfDetailsB
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As New DataTable
        Dim dl As New DLGenerateHallTicket
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim LoanId As Integer = Request.QueryString.Get("LoanId")
        Dim FDate As DateTime = Request.QueryString.Get("FDate")
        Dim TDate As DateTime = Request.QueryString.Get("TDate")
        dt1 = Rpt_EmpWiseLoanMasterStatementDL.GenerateLoanTypeWiseLoanMasterStatementReport(LoanId, FDate, TDate)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_LoanTypeWiseLoanStatementReportV.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_LoanTypeWiseLoanMasterStatementReport", dt1)

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FDate", FDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TDate", TDate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblErrorMsg.Text = "No Records to Display"
            End If

        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try

    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub


End Class
