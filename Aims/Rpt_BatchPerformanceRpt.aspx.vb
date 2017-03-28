
Partial Class Rpt_BatchPerformanceRpt
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1, dt2 As New DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dl As New DLReportsR
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Batch1 As Integer = Request.QueryString.Get("batch1")
        Dim Batch2 As Integer = Request.QueryString.Get("batch2")
        Dim Course As Integer = Request.QueryString.Get("course")
        Dim Subject As Integer = Request.QueryString.Get("subject")
        Dim SemId As Integer = Request.QueryString.Get("SemId")
        Dim AssessmentId As Integer = Request.QueryString.Get("AssessmentId")
        Dim Semester As String = Request.QueryString.Get("SemName")
        Dim AssessmentType As String = Request.QueryString.Get("AssessmentType")
        Dim subjectName As String = Request.QueryString.Get("subjectName")




        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 22 Jan 2014
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "BatchPerfReportR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim BatchPerfReportR, BranchName, BranchType, SemesterN, SemesterB As String
        Dim CourseN, AssessmentN, Percentage As String

        BatchPerfReportR = dt2.Rows(0).Item("Default_Text").ToString()
        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
        CourseN = dt2.Rows(3).Item("Default_Text").ToString()
        SemesterN = dt2.Rows(4).Item("Default_Text").ToString()
        AssessmentN = dt2.Rows(5).Item("Default_Text").ToString()
        Percentage = dt2.Rows(6).Item("Default_Text").ToString()
        SemesterB = dt2.Rows(7).Item("Default_Text").ToString()
        
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = dl.Rpt_BatchPerformanceRpt(Batch1, Batch2, Course, Subject, SemId, AssessmentId)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_BatchPerformanceRpt.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BatchPerformanceRpt", dt1)

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemName", Semester, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssessmentType", AssessmentType, False))

                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchPerfReportR", BatchPerfReportR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseN", CourseN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemesterN", SemesterN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssessmentN", AssessmentN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Percentage", Percentage, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemesterB", SemesterB, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("subjectName", subjectName, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = ValidationMessage(1023)
            End If
            'modified by Nitin 03/01/2012
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 22 jan 2014
    ''Retriving the text of controls based on Language
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
End Class
