
Partial Class FacultywisefeedbackV
    Inherits System.Web.UI.Page
    Dim ds1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As New DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dl As New FeedbackReportDL
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim BatchId As Integer = Request.QueryString.Get("BatchId")
        'Dim SemId As Integer = Request.QueryString.Get("SemId")

        'Dim EmpId As Integer = Request.QueryString.Get("EmpId")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = dl.FacultywiseFeedBackReport()
        Dim LanguageID As Integer
        Dim FormName As String
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "STDFeedbackR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim STDFeedbackR, BatchN, SemN, SlNo, SubjectCode, FacultyN, Feedback, SubjectName As String
        Dim FacultyScore, SubjectScore, TotalfacultyScorewithWeightage As String

        STDFeedbackR = dt2.Rows(0).Item("Default_Text").ToString()
        BatchN = dt2.Rows(1).Item("Default_Text").ToString()
        SemN = dt2.Rows(2).Item("Default_Text").ToString()
        SlNo = dt2.Rows(3).Item("Default_Text").ToString()
        FacultyN = dt2.Rows(4).Item("Default_Text").ToString()
        Feedback = dt2.Rows(5).Item("Default_Text").ToString()
        SubjectCode = dt2.Rows(6).Item("Default_Text").ToString()
        SubjectName = dt2.Rows(7).Item("Default_Text").ToString()
        SubjectScore = dt2.Rows(8).Item("Default_Text").ToString()
        FacultyScore = dt2.Rows(9).Item("Default_Text").ToString()
        TotalfacultyScorewithWeightage = dt2.Rows(10).Item("Default_Text").ToString()
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptFacultywisefeedback.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_FacultywiseFeedBackReport", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDFeedbackR", STDFeedbackR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemN", SemN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FacultyN", FacultyN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Feedback", Feedback, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectCode", SubjectCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectName", SubjectName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectScore", SubjectScore, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FacultyScore", FacultyScore, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalfacultyScorewithWeightage", TotalfacultyScorewithWeightage, False))
                'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchId", BatchId, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemId", SemId, False))
                'ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.SetParameters(paramList)
                'ReportViewer1.LocalReport.DataSources.Clear()
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

    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
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
