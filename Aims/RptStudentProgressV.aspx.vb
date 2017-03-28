
Partial Class RptStudentProgressV
    Inherits System.Web.UI.Page

    Dim Bl As New StdAttdance
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2, dt As New DataTable
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Batch As Integer = Request.QueryString.Get("Batch")
        Dim Semester As Integer = Request.QueryString.Get("Semester")
        Dim Assessment As Integer = Request.QueryString.Get("Assessment")
        Dim AssessmentType As String = Request.QueryString.Get("AssessmentType")
        Dim Student As Integer = Request.QueryString.Get("Student")
        Dim FDate As String = Request.QueryString.Get("FDate")
        Dim EDate As String = Request.QueryString.Get("EDate")
        'Dim DL As New DLStudentIDCard
        'QueryStr.GetValue(Page.Request, Prop)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 25 Jan 2014
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "STDProgressR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim STDProgressR, BatchN, SemesterN, SlNo, SubjectN, AttendanceN As String
        Dim StdCode, Conduct, StdName, Attend, Max, Score, ClassAvg As String

        STDProgressR = dt2.Rows(0).Item("Default_Text").ToString()
        BatchN = dt2.Rows(1).Item("Default_Text").ToString()
        SemesterN = dt2.Rows(2).Item("Default_Text").ToString()
        StdName = dt2.Rows(3).Item("Default_Text").ToString()
        StdCode = dt2.Rows(4).Item("Default_Text").ToString()
        SlNo = dt2.Rows(5).Item("Default_Text").ToString()
        SubjectN = dt2.Rows(6).Item("Default_Text").ToString()
        AttendanceN = dt2.Rows(7).Item("Default_Text").ToString()
        Conduct = dt2.Rows(8).Item("Default_Text").ToString()
        Attend = dt2.Rows(9).Item("Default_Text").ToString()
        Max = dt2.Rows(10).Item("Default_Text").ToString()
        Score = dt2.Rows(11).Item("Default_Text").ToString()
        ClassAvg = dt2.Rows(12).Item("Default_Text").ToString()

        dt1 = DLStudentProgress.RPT_GetStudentProgress(Batch, Semester, Assessment, Student, FDate, EDate)

        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.LocalReport.ReportPath = "RptStudentProgress.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_StudentProgress", dt1)
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssessmentType", AssessmentType, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FDate", FDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EDate", EDate, False))

            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDProgressR", STDProgressR, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))

            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemesterN", SemesterN, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectN", SubjectN, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AttendanceN", AttendanceN, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Conduct", Conduct, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Attend", Attend, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Max", Max, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Score", Score, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ClassAvg", ClassAvg, False))
            ReportViewer1.LocalReport.SetParameters(paramList)

            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            Me.ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblmsg.Text = ValidationMessage(1023)
        End If
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
