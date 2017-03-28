
Partial Class rptBatchPlannerB
    Inherits BasePage
    Dim bll As New rptBatchPlannerBL
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2, dt As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim bachid As Integer = CInt(Request.QueryString.Get("batch"))
        Dim BatchId As Integer = Request.QueryString.Get("Batch")
        Dim SemId As Integer = Request.QueryString.Get("Semester")

        dt1 = bll.GetResultByStdCode(BatchId, SemId)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 26 Nov 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "BatchPlanR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim BatchPlanR, BranchName, BranchType, SlNo, AcademicY, Course, Batch, StartDate, Subject, TotalH As String
        Dim SubjectCode, Credit, Staff, Semester, EndDate, Total As String
        BatchPlanR = dt2.Rows(0).Item("Default_Text").ToString()
        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
        Batch = dt2.Rows(3).Item("Default_Text").ToString()
        AcademicY = dt2.Rows(4).Item("Default_Text").ToString()
        Course = dt2.Rows(5).Item("Default_Text").ToString()
        SlNo = dt2.Rows(6).Item("Default_Text").ToString()
        SubjectCode = dt2.Rows(7).Item("Default_Text").ToString()
        Subject = dt2.Rows(8).Item("Default_Text").ToString()
        TotalH = dt2.Rows(9).Item("Default_Text").ToString()
        Credit = dt2.Rows(10).Item("Default_Text").ToString()
        Staff = dt2.Rows(11).Item("Default_Text").ToString()
        Semester = dt2.Rows(12).Item("Default_Text").ToString()
        StartDate = dt2.Rows(13).Item("Default_Text").ToString()
        EndDate = dt2.Rows(14).Item("Default_Text").ToString()
        Total = dt2.Rows(15).Item("Default_Text").ToString()
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "BatchPlanner.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_GetBatchPlannerView", dt1)
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchPlanR", BatchPlanR, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", Course, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectCode", SubjectCode, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalH", TotalH, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Credit", Credit, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Staff", Staff, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StartDate", StartDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", EndDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))


            ReportViewer1.LocalReport.SetParameters(paramList)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            lblmsg.Text = ValidationMessage(1023)
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 26th Nov 2013
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
