
Partial Class RptQnPaperV
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1, dt2 As New DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dl As New DLBatchReportCardElect
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Crs As Integer = Request.QueryString.Get("Crs")
        Dim Batch As Integer = Request.QueryString.Get("Batch")
        Dim Sem As Integer = Request.QueryString.Get("Sem")
        Dim subj As Integer = Request.QueryString.Get("subj")
        dt1 = DLQuestionPaper.RptQnPaperDetails(Crs, Batch, Sem, subj)
        Try
            If dt1.Rows.Count > 0 Then

                ReportViewer1.LocalReport.ReportPath = "RptQnPaper.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_QuestionPaper", dt1)
                'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ElectiveSubjectName", ElectiveSubjectName, False))
                'ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()

                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No Records to Display."
            End If
        Catch ex As Exception
            lblmsg.Text = "No Records to Display."
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
