Partial Class RptMarksSheet
    Inherits BasePage
    Dim bll As New StdResultB
    Dim dtM, ParentDt As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dl As New DLReportsR
    Dim dt1, dt As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim bachid As Integer = CInt(Request.QueryString.Get("batch"))
        Dim stdid, BranchCode, ReportType As String
        Dim BatchId, assesstype, SemId, classtype As Integer
        Try
            If Session("LoginType") = "Employee" Then
                stdid = Request.QueryString.Get("StudentCode")
                BranchCode = Request.QueryString.Get("BranchCode")
                BatchId = Request.QueryString.Get("Batch")
                SemId = Request.QueryString.Get("Semester")
                assesstype = Request.QueryString.Get("AssessmentType")
                classtype = Request.QueryString.Get("ClassType")
                ReportType = Request.QueryString.Get("ReportType")

            ElseIf Session("LoginType") = "Others" Then
                ParentDt = dl.GetStudentDtlsForParent()
                stdid = ParentDt.Rows(0).Item("STD_ID").ToString
                BranchCode = ParentDt.Rows(0).Item("BranchCode").ToString
                BatchId = ParentDt.Rows(0).Item("Batch_No").ToString
                ReportType = Request.QueryString.Get("ReportType")
                SemId = 0
                assesstype = 0
            End If
            dt1 = bll.GetResultByStdCode(BranchCode, stdid, BatchId, SemId, assesstype, classtype)
            If dt1.Rows.Count > 0 Then
                If ReportType = "Marks And Grade" Then
                    ReportViewer1.LocalReport.ReportPath = "StudentResult.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StdSemesterResult", dt1)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                ElseIf ReportType = "Marks" Then
                    ReportViewer1.LocalReport.ReportPath = "StudentResultMarks.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StdSemesterResult", dt1)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                ElseIf ReportType = "Remarks" Then
                    ReportViewer1.LocalReport.ReportPath = "StudentResultRemarks.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StdSemesterResult", dt1)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                ElseIf ReportType = "Grade" Then
                    dt1 = bll.GetResultByStdCode(BranchCode, stdid, BatchId, SemId, assesstype, classtype)
                    'If dt1.Rows(0).Item("Grade") = "" Then
                    '    ReportViewer1.LocalReport.ReportPath = "StudentResultMarks.rdlc"
                    '    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StdSemesterResult", dt1)

                    '    ReportViewer1.LocalReport.DataSources.Clear()
                    '    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    '    ReportViewer1.LocalReport.Refresh()

                    '    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    '    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    'Else
                    ReportViewer1.LocalReport.ReportPath = "StudentResultGrade.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StdSemesterResult", dt1)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

                End If
            Else
                lblmsg.Text = "No Records to display."
            End If
            'End If
        Catch ex As Exception
            lblmsg.Text = "No Records to display."
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
