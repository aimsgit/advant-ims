
Partial Class RptExamAttemptV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    
    'Code written By Ajit
    '27-JUN-2013

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim CourseID As String = Request.QueryString.Get("CourseID")
        Dim BatchID As Integer = Request.QueryString.Get("BatchID")
        Dim SemesterID As Integer = Request.QueryString.Get("SemesterID")
        Dim FinalIAID As Integer = Request.QueryString.Get("FinalIAID")
        Dim FinalExam As Integer = Request.QueryString.Get("FinalExam")
        Dim StudentID As Integer = Request.QueryString.Get("StudentID")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DLExamAttempt.GetExamAttempt(BatchID, SemesterID, FinalIAID, FinalExam, StudentID)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptExamAttempt.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SemesterExamAttempts", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseID", CourseID, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No Records to Display."
            End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
