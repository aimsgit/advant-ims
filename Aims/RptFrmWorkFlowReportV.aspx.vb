
Partial Class RptFrmWorkFlowReportV
    Inherits BasePage

    Dim dt As DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DL As New DLApprovalForm
        Dim dt1, dt3, dt4 As New Data.DataTable

        Dim FormName As Integer = Request.QueryString.Get("FormName")
        Dim FormName1 As String = Request.QueryString.Get("FormName1")
        Dim StartDate As DateTime = Request.QueryString.Get("StartDate")
        Dim EndDate As DateTime = Request.QueryString.Get("EndDate")
        Dim r As String = Request.QueryString.Get("r")
        Dim emp As Integer = Request.QueryString.Get("emp")


        dt1 = DLApprovalForm.GetWorlFlowReport(FormName, StartDate, EndDate, r, emp)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptFrmWorkFlowReport.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_GetWorlFlowReport", dt1)
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StartDate", StartDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", EndDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FormName1", FormName1, False))
            ReportViewer1.LocalReport.SetParameters(paramList)
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



