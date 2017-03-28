
Partial Class Rpt_BatchReportCard
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As New DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dl As New DLReportsR
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BranchCode As String = Request.QueryString.Get("Branch")
        Dim course As Integer = Request.QueryString.Get("course")
        Dim BatchNo As String = Request.QueryString.Get("BatchNo")
        Dim Sem As String = Request.QueryString.Get("SemesterId")
        'Dim Semester As String = Request.QueryString.Get("SemesterName")
        Dim AsstType As String = Request.QueryString.Get("AssessmentId")
        Dim Subject As String = Request.QueryString.Get("Subjectid")
        'Dim ayear As Integer = Request.QueryString.Get("AYear")
        Dim ClassType As Integer = Request.QueryString.Get("ClassType")
        Dim SortBy As Integer = Request.QueryString.Get("SortBy")
        Dim ReportType As String = Request.QueryString.Get("ReportType")
        'Modified by Niraj on 13 june 2013
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = dl.Rpt_BatchReportCard(BranchCode, course, BatchNo, Sem, AsstType, Subject, ClassType, SortBy)
        Try
            If dt1.Rows.Count > 0 Then
                If ReportType = "Marks And Grade" Then
                    ReportViewer1.LocalReport.ReportPath = "Rpt_BatchReportCard.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BatchReportCard", dt1)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()

                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                ElseIf ReportType = "Marks" Then
                    ReportViewer1.LocalReport.ReportPath = "Rpt_BatchMarksCard.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BatchReportCard", dt1)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()

                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                ElseIf ReportType = "Remarks" Then
                    ReportViewer1.LocalReport.ReportPath = "Rpt_BatchCardRemarks.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BatchReportCard", dt1)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()

                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                ElseIf ReportType = "Grade" Then
                    dt1 = dl.Rpt_BatchReportCard(BranchCode, course, BatchNo, Sem, AsstType, Subject, ClassType, SortBy)
                    ReportViewer1.LocalReport.ReportPath = "Rpt_BatchReportCardGrade.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BatchReportCard", dt1)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()

                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

                End If
            Else
                lblmsg.Text = "No Records to display."
            End If
            'End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
