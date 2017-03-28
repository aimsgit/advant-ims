
Partial Class StudentIndHostelAddmDetailsV
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable
    Dim obj As New SelfDetailsB
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As New DataTable
        Dim dl As New StudentIndHostelAdmissionDetailsDL
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BranchCode As String = Request.QueryString.Get("BranchCode")
        Dim BranchName As String = Request.QueryString.Get("BranchName")

        Dim Course As Integer = Request.QueryString.Get("Course")
        Dim BatchId As Integer = Request.QueryString.Get("BatchId")
        Dim StudentId As Integer = Request.QueryString.Get("StudentId")
        'Dim id As Integer = Request.QueryString.Get("id")
        dt1 = StudentIndHostelAdmissionDetailsDL.GenerateStudentHostelAddmissionDetailsReports(BranchCode, Course, BatchId, StudentId)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "StudentIndHostelAddmDetailsV.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_GenerateStdHostelAddDetails", dt1)

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", Todate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblMsg.Text = "No Records to Display"
            End If

        Catch ex As Exception
            lblMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try

    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
