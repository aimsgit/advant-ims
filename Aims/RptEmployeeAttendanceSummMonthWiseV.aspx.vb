
Partial Class RptEmployeeAttendanceSummMonthWiseV
    Inherits BasePage

    Dim DL As New DLEmpAttendanceSummary
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt, dt2, ParentDt, ParentDt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim FromDate As Date
        Dim ToDate As Date

        FromDate = Request.QueryString.Get("FinStartDate")
        ToDate = Request.QueryString.Get("FinEndDate")
        dt1 = DLEmpAttendanceSummary.RptAttendanceSummary(FromDate, ToDate)
        If dt1.Rows.Count > 0 Then

            ReportViewer1.LocalReport.ReportPath = "RptEmployeeAttendanceSummMonthWise.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_EmpAttendanceSummaryMonthWise", dt1)

            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
            ReportViewer1.LocalReport.SetParameters(paramList)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            LblError.Text = ""
        Else
            LblError.Text = "No Records to Display."
        End If
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
