
Partial Class RptSemMarksAttendListV1
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim DL As New stdAttndance
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim Bat, Sem, Assessmentid As Integer
        Bat = Request.QueryString.Get("BatchID")
        Sem = Request.QueryString.Get("Semester")
        Assessmentid = Request.QueryString.Get("Assessmentid")
        'Dim BAL As New GlobalDataSetTableAdapters.Test_BankReconciliationTableAdapter
        Dim dt As New Data.DataTable

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.GetNewSemMarksAttendListReport1(Bat, Sem, Assessmentid)

        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptStudMarksAttendList1.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SemMarksAttenMap1", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

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
