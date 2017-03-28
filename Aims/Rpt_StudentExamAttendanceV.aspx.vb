﻿
Partial Class Rpt_StudentExamAttendanceV
    Inherits BasePage

    Dim ds1 As DataTable
    Dim dt, dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DL As New DLExamAttendance
        Dim Subject As Integer = Request.QueryString.Get("Subject")
        Dim Exam As String = Request.QueryString.Get("Exam")
        Dim ExamDate As Date = Request.QueryString.Get("ExamDate")
        Dim ExamCenter As Integer = Request.QueryString.Get("ExamCenter")
        ' Dim SemId As Integer = Request.QueryString.Get("SemId")
        dt1 = DL.RptStudentExamAttendanceSheet(Subject, Exam, ExamDate, ExamCenter)
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "Rpt_StudentExamAttendanceV.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudExamAttendance", dt1)

            'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            'ReportViewer1.LocalReport.SetParameters(paramList)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()
            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblmsg.Text = "No Records to Display."

        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class


