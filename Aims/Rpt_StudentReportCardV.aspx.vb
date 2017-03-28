
Partial Class Rpt_StudentReportCardV
    Inherits System.Web.UI.Page
    Dim bll As New StdResultB
    Dim dtM, ParentDt As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dl As New DLReportsR
    Dim dtL As New DLStdReportCard
    Dim dt1, dt2, dt As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim bachid As Integer = CInt(Request.QueryString.Get("batch"))
        Dim stdid, BranchCode, ReportType, assesstype As String
        Dim BatchId, SemId, classtype, SortBy As Integer
        
        'Dim StdGradeCardR, StdMarksCardR, StdRemarksCardR, 
       
        Try
            If Session("LoginType") = "Employee" Then
                stdid = Request.QueryString.Get("StudentCode")
                BranchCode = Request.QueryString.Get("BranchCode")
                BatchId = Request.QueryString.Get("Batch")
                SemId = Request.QueryString.Get("Semester")
                assesstype = Request.QueryString.Get("AssessmentType")
                ReportType = Request.QueryString.Get("ReportType")
                SortBy = Request.QueryString.Get("SortBy")
            ElseIf Session("LoginType") = "Others" Then
                ParentDt = dl.GetStudentDtlsForParent()
                stdid = ParentDt.Rows(0).Item("STD_ID").ToString
                BranchCode = ParentDt.Rows(0).Item("BranchCode").ToString
                BatchId = ParentDt.Rows(0).Item("Batch_No").ToString
                ReportType = Request.QueryString.Get("ReportType")
                SortBy = Request.QueryString.Get("SortBy")
                SemId = 0
                assesstype = 0
            End If
            dt1 = DLStdReportCard.GetStudentReportCard(BranchCode, stdid, BatchId, SemId, assesstype, SortBy)
            If dt1.Rows.Count > 0 Then
                If ReportType = "Marks And Grade" Then
                    Dim LanguageID As Integer
                    Dim FormName As String
                    ''Multilingual Conversion  By: Niraj on 11 Jan 2014
                    If Session("LanguageID") = "" Then
                        LanguageID = 1
                    Else
                        LanguageID = Session("LanguageID")
                    End If
                    FormName = "STDReportCardR"
                    dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
                    Dim STDReportCardR, BranchName, BranchType, Course, Batch, Semester, AcademicY As String
                    Dim Total, SubjectName, Grade, Marks, Attendance, Remarks, StdName, StdCode, Min, Max, Obtained, Pass, Assessment As String

                    STDReportCardR = dt2.Rows(0).Item("Default_Text").ToString()
                    StdName = dt2.Rows(1).Item("Default_Text").ToString()
                    StdCode = dt2.Rows(2).Item("Default_Text").ToString()
                    BranchName = dt2.Rows(3).Item("Default_Text").ToString()
                    BranchType = dt2.Rows(4).Item("Default_Text").ToString()
                    Course = dt2.Rows(5).Item("Default_Text").ToString()
                    Batch = dt2.Rows(6).Item("Default_Text").ToString()
                    AcademicY = dt2.Rows(7).Item("Default_Text").ToString()
                    SubjectName = dt2.Rows(8).Item("Default_Text").ToString()
                    Max = dt2.Rows(9).Item("Default_Text").ToString()
                    Min = dt2.Rows(10).Item("Default_Text").ToString()
                    Marks = dt2.Rows(11).Item("Default_Text").ToString()
                    Obtained = dt2.Rows(12).Item("Default_Text").ToString()
                    Grade = dt2.Rows(13).Item("Default_Text").ToString()
                    Pass = dt2.Rows(14).Item("Default_Text").ToString()
                    Attendance = dt2.Rows(15).Item("Default_Text").ToString()
                    Remarks = dt2.Rows(16).Item("Default_Text").ToString()
                    Semester = dt2.Rows(17).Item("Default_Text").ToString()
                    Assessment = dt2.Rows(18).Item("Default_Text").ToString()
                    Total = dt2.Rows(19).Item("Default_Text").ToString()

                    ReportViewer1.LocalReport.ReportPath = "StdReportCardMarksGrade.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentReportCard", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDReportCardR", STDReportCardR, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", Course, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectName", SubjectName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Max", Max, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Min", Min, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Marks", Marks, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Obtained", Obtained, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Grade", Grade, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Pass", Pass, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Attendance", Attendance, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assessment", Assessment, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                ElseIf ReportType = "Marks" Then
                    Dim LanguageID As Integer
                    Dim FormName As String
                    ''Multilingual Conversion  By: Niraj on 11 Jan 2014
                    If Session("LanguageID") = "" Then
                        LanguageID = 1
                    Else
                        LanguageID = Session("LanguageID")
                    End If
                    FormName = "STDMarksCardR"
                    dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
                    Dim STDMarksCardR, BranchName, BranchType, Course, Batch, Semester, AcademicY As String
                    Dim Total, SubjectName, Marks, Attendance, Remarks, StdName, StdCode, Min, Max, Obtained, Pass, Assessment As String

                    STDMarksCardR = dt2.Rows(0).Item("Default_Text").ToString()
                    StdName = dt2.Rows(1).Item("Default_Text").ToString()
                    StdCode = dt2.Rows(2).Item("Default_Text").ToString()
                    BranchName = dt2.Rows(3).Item("Default_Text").ToString()
                    BranchType = dt2.Rows(4).Item("Default_Text").ToString()
                    Course = dt2.Rows(5).Item("Default_Text").ToString()
                    Batch = dt2.Rows(6).Item("Default_Text").ToString()
                    AcademicY = dt2.Rows(7).Item("Default_Text").ToString()
                    SubjectName = dt2.Rows(8).Item("Default_Text").ToString()
                    Max = dt2.Rows(9).Item("Default_Text").ToString()
                    Min = dt2.Rows(10).Item("Default_Text").ToString()
                    Marks = dt2.Rows(11).Item("Default_Text").ToString()
                    Obtained = dt2.Rows(12).Item("Default_Text").ToString()
                    Pass = dt2.Rows(13).Item("Default_Text").ToString()
                    Attendance = dt2.Rows(14).Item("Default_Text").ToString()
                    Remarks = dt2.Rows(15).Item("Default_Text").ToString()
                    Semester = dt2.Rows(16).Item("Default_Text").ToString()
                    Assessment = dt2.Rows(17).Item("Default_Text").ToString()
                    Total = dt2.Rows(18).Item("Default_Text").ToString()
                    ReportViewer1.LocalReport.ReportPath = "StdReportCardMarks.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentReportCard", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDMarksCardR", STDMarksCardR, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", Course, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectName", SubjectName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Max", Max, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Min", Min, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Marks", Marks, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Obtained", Obtained, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Pass", Pass, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Attendance", Attendance, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assessment", Assessment, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                ElseIf ReportType = "Remarks" Then
                    Dim LanguageID As Integer
                    Dim FormName As String
                    ''Multilingual Conversion  By: Niraj on 13 Jan 2014
                    If Session("LanguageID") = "" Then
                        LanguageID = 1
                    Else
                        LanguageID = Session("LanguageID")
                    End If
                    FormName = "STDGradeCardR"
                    dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
                    Dim STDGradeCardR, BranchName, BranchType, Course, Batch, Semester, AcademicY As String
                    Dim SubjectName, Attendance, Remarks, StdName, StdCode, Assessment As String

                    STDGradeCardR = dt2.Rows(0).Item("Default_Text").ToString()
                    BranchName = dt2.Rows(1).Item("Default_Text").ToString()
                    BranchType = dt2.Rows(2).Item("Default_Text").ToString()
                    Course = dt2.Rows(3).Item("Default_Text").ToString()
                    Batch = dt2.Rows(4).Item("Default_Text").ToString()
                    AcademicY = dt2.Rows(5).Item("Default_Text").ToString()
                    SubjectName = dt2.Rows(6).Item("Default_Text").ToString()
                    Attendance = dt2.Rows(7).Item("Default_Text").ToString()
                    Remarks = dt2.Rows(8).Item("Default_Text").ToString()
                    StdName = dt2.Rows(9).Item("Default_Text").ToString()
                    StdCode = dt2.Rows(10).Item("Default_Text").ToString()
                    Semester = dt2.Rows(11).Item("Default_Text").ToString()
                    Assessment = dt2.Rows(12).Item("Default_Text").ToString()

                    ReportViewer1.LocalReport.ReportPath = "StdReportCardRemarks.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentReportCard", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDGradeCardR", STDGradeCardR, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", Course, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectName", SubjectName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Attendance", Attendance, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assessment", Assessment, False))

                    ReportViewer1.LocalReport.SetParameters(paramList)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                ElseIf ReportType = "Grade" Then
                    Dim LanguageID As Integer
                    Dim FormName As String
                    ''Multilingual Conversion  By: Niraj on 13 Jan 2014
                    If Session("LanguageID") = "" Then
                        LanguageID = 1
                    Else
                        LanguageID = Session("LanguageID")
                    End If
                    FormName = "STDReportR"
                    dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
                    Dim STDReportR, BranchName, BranchType, Course, Batch, Semester, AcademicY As String
                    Dim SubjectName, Attendance, Remarks, StdName, StdCode, Grade, Assessment As String

                    STDReportR = dt2.Rows(0).Item("Default_Text").ToString()
                    BranchName = dt2.Rows(1).Item("Default_Text").ToString()
                    BranchType = dt2.Rows(2).Item("Default_Text").ToString()
                    Course = dt2.Rows(3).Item("Default_Text").ToString()
                    Batch = dt2.Rows(4).Item("Default_Text").ToString()
                    AcademicY = dt2.Rows(5).Item("Default_Text").ToString()
                    SubjectName = dt2.Rows(6).Item("Default_Text").ToString()
                    Grade = dt2.Rows(7).Item("Default_Text").ToString()
                    Attendance = dt2.Rows(8).Item("Default_Text").ToString()
                    Remarks = dt2.Rows(9).Item("Default_Text").ToString()
                    StdName = dt2.Rows(10).Item("Default_Text").ToString()
                    StdCode = dt2.Rows(11).Item("Default_Text").ToString()
                    Semester = dt2.Rows(12).Item("Default_Text").ToString()
                    Assessment = dt2.Rows(13).Item("Default_Text").ToString()


                    ReportViewer1.LocalReport.ReportPath = "StdReportCardGrade.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentReportCard", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDReportR", STDReportR, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", Course, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectName", SubjectName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Grade", Grade, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Attendance", Attendance, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assessment", Assessment, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

                End If
            Else
                lblmsg.Text = ValidationMessage(1023)
            End If

        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1023)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 11 jan 2014
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
