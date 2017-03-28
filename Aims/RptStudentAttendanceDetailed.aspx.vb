
Partial Class RptStudentAttendanceDetailed
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim DL As New stdAttndance
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BR As String
        Dim Bat, Sem, Subj, CT, StdId, SortBy As Integer
        Dim fromdate, todate As DateTime

        BR = Request.QueryString.Get("BranchCode")
        'AT = Request.QueryString.Get("A_Year")
        Bat = Request.QueryString.Get("Batch")
        Sem = Request.QueryString.Get("Semester")
        Subj = Request.QueryString.Get("Subject")
        CT = Request.QueryString.Get("ClassType")
        StdId = Request.QueryString.Get("StudentID")
        fromdate = Request.QueryString.Get("fromdate")
        todate = Request.QueryString.Get("todate")
        SortBy = Request.QueryString.Get("SortBy")
        'Dim BAL As New GlobalDataSetTableAdapters.Test_BankReconciliationTableAdapter
        Dim dt As New Data.DataTable

        QueryStr.GetValue(Page.Request, Prop)

        dt1 = DL.GetStudentDetailedReport(BR, Bat, Sem, Subj, CT, StdId, fromdate, todate, SortBy)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptStdAttendanceDetailedReport.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentAttendanceDetailedRpt", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblMsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
