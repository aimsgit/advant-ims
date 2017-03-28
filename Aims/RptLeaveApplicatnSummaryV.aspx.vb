
Partial Class RptLeaveApplicatnSummaryV
    Inherits BasePage
    Dim ds1 As New DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim Dl As New LeaveDB

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim Dept, Emp As Integer
        Dim FrmDate, ToDate As Date

        Dept = Request.QueryString.Get("Dept")
        Emp = Request.QueryString.Get("Emp")
        'LeaveType = Request.QueryString.Get("LeaveType")
        'LeaveStatus = Request.QueryString.Get("LeaveStatus")
        FrmDate = Request.QueryString.Get("FrmDate")
        ToDate = Request.QueryString.Get("ToDate")

        Dim dt As New Data.DataTable
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = Dl.RptLeaveApplcationSummary(Dept, FrmDate, ToDate, Emp)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptLeaveAppicationSummary.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_GetLeaveApplicationSummary", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FrmDate", FrmDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)


                dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class






