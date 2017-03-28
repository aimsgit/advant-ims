
Partial Class RptStudentAttendanceSheetV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim dt, dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DL As New DLReportStudAtt

        'Dim AYear As Integer = (Request.QueryString.Get("Ayear"))
        Dim Batch As String = (Request.QueryString.Get("Batch"))
        Dim Semester As String = (Request.QueryString.Get("Semester"))
        Dim Subject As Integer = (Request.QueryString.Get("Subject"))
        'Dim AttenDate As Date = (Request.QueryString.Get("AttenDate"))
        'Dim SubGrp As Integer = (Request.QueryString.Get("SubGrp"))
        'Dim SessionCountDay As String = (Request.QueryString.Get("SessionCountDay"))

        'Dim Batch As Integer = Request.QueryString.Get("Batch")
        'Dim SemId As Integer = Request.QueryString.Get("SemId")
        'Dim Subject As Integer = Request.QueryString.Get("Subject")

        Try
            'dt1 = DL.RptStudentAttendanceSheetV(AYear, Batch, Semester, Subject, AttenDate, SubGrp, SessionCountDay)
            dt1 = DL.RptStudentAttendanceSheetV(Batch, Semester, Subject)
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptStudentAttendanceSheetV.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudAttendance1", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()
                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No Records to Display."

            End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
