
Partial Class Rpt_BatchReportCardV
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1, dt2, dt3 As New DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dl As New DLBatchReportCardElect
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BranchCode As String = Request.QueryString.Get("Branch")
        Dim course As Integer = Request.QueryString.Get("course")
        Dim BatchNo As String = Request.QueryString.Get("BatchNo")
        Dim Sem As String = Request.QueryString.Get("SemesterId")
        Dim AsstType As String = Request.QueryString.Get("AssessmentId")
        Dim Subject As String = Request.QueryString.Get("Subjectid")
        'Dim ayear As Integer = Request.QueryString.Get("AYear")
        Dim ReportType As String = Request.QueryString.Get("ReportType")
        Dim SortBy As Integer = Request.QueryString.Get("SortBy")
        Dim id As Integer = Request.QueryString.Get("id")
        Dim FrmMarks As String = Request.QueryString.Get("FrmMarks")
        Dim Tomarks As String = Request.QueryString.Get("Tomarks")
        'Dim BatchName As String = Request.QueryString.Get("BatchName")

        Dim Frm1, Frm2, Frm3, Frm4, To1, To2, To3, To4, RBType As Integer
        Frm1 = Request.QueryString.Get("Frm1")
        Frm2 = Request.QueryString.Get("Frm2")
        Frm3 = Request.QueryString.Get("Frm3")
        Frm4 = Request.QueryString.Get("Frm4")
        To1 = Request.QueryString.Get("To1")
        To2 = Request.QueryString.Get("To2")
        To3 = Request.QueryString.Get("To3")
        To4 = Request.QueryString.Get("To4")
        RBType = Request.QueryString.Get("RBType")



        If (id = 1) Then
            QueryStr.GetValue(Page.Request, Prop)
            dt1 = dl.Rpt_BatchReportCardElect(BranchCode, course, BatchNo, Sem, AsstType, Subject, SortBy, FrmMarks, Tomarks)
            Try
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
                        FormName = "BatchReportCardR"
                        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
                        Dim BatchReportCardR, BranchName, BranchType, CourseN, Batch, Semester, AcademicY As String
                        Dim Total, SubjectCode, AssDate, Passed, AM, LM, HM, Failed, SlNo, Grade, SubjectN, Percentage, PF, Marks, Attendance, Remarks, StdName, StdCode, Min, Max, Assessment As String

                        BatchReportCardR = dt2.Rows(0).Item("Default_Text").ToString()
                        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
                        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
                        CourseN = dt2.Rows(3).Item("Default_Text").ToString()
                        Batch = dt2.Rows(4).Item("Default_Text").ToString()
                        AcademicY = dt2.Rows(5).Item("Default_Text").ToString()
                        Semester = dt2.Rows(6).Item("Default_Text").ToString()
                        SubjectN = dt2.Rows(7).Item("Default_Text").ToString()
                        SubjectCode = dt2.Rows(8).Item("Default_Text").ToString()
                        Assessment = dt2.Rows(9).Item("Default_Text").ToString()
                        AssDate = dt2.Rows(10).Item("Default_Text").ToString()
                        Total = dt2.Rows(11).Item("Default_Text").ToString()
                        Passed = dt2.Rows(12).Item("Default_Text").ToString()
                        Failed = dt2.Rows(13).Item("Default_Text").ToString()
                        SlNo = dt2.Rows(14).Item("Default_Text").ToString()
                        StdCode = dt2.Rows(15).Item("Default_Text").ToString()
                        StdName = dt2.Rows(16).Item("Default_Text").ToString()
                        Max = dt2.Rows(17).Item("Default_Text").ToString()
                        Min = dt2.Rows(18).Item("Default_Text").ToString()
                        Marks = dt2.Rows(19).Item("Default_Text").ToString()
                        Percentage = dt2.Rows(20).Item("Default_Text").ToString()
                        PF = dt2.Rows(21).Item("Default_Text").ToString()
                        Attendance = dt2.Rows(22).Item("Default_Text").ToString()
                        Remarks = dt2.Rows(23).Item("Default_Text").ToString()
                        AM = dt2.Rows(24).Item("Default_Text").ToString()
                        LM = dt2.Rows(25).Item("Default_Text").ToString()
                        HM = dt2.Rows(26).Item("Default_Text").ToString()
                        Grade = dt2.Rows(27).Item("Default_Text").ToString()

                        ReportViewer1.LocalReport.ReportPath = "Rpt_BatchReportCardElecMarksGrade.rdlc"
                        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BatchReportCardElect", dt1)
                        'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ElectiveSubjectName", ElectiveSubjectName, False))
                        'ReportViewer1.LocalReport.SetParameters(paramList)
                        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchReportCardR", BatchReportCardR, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseN", CourseN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectN", SubjectN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectCode", SubjectCode, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assessment", Assessment, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssDate", AssDate, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Passed", Passed, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Failed", Failed, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Max", Max, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Min", Min, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Marks", Marks, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Percentage", Percentage, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("PF", PF, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Attendance", Attendance, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AM", AM, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("LM", LM, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("HM", HM, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Grade", Grade, False))

                        ReportViewer1.LocalReport.SetParameters(paramList)
                        ReportViewer1.LocalReport.DataSources.Clear()
                        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                        ReportViewer1.LocalReport.Refresh()

                        ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

                        'ReportViewer1.LocalReport.SetParameters(paramList)
                        'ReportViewer1.LocalReport.DataSources.Clear()
                        'Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                        'ReportViewer1.LocalReport.Refresh()

                        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    ElseIf ReportType = "Marks" Then
                        Dim LanguageID As Integer
                        Dim FormName As String
                        ''Multilingual Conversion  By: Niraj on 11 Jan 2014
                        If Session("LanguageID") = "" Then
                            LanguageID = 1
                        Else
                            LanguageID = Session("LanguageID")
                        End If
                        FormName = "BatchMarksCardR"
                        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
                        Dim BatchMarksCardR, BranchName, BranchType, CourseN, Batch, AcademicY As String
                        Dim Total, AssDate, Passed, AM, LM, HM, Failed, Semester, SubjectN, SubjectCode, SlNo, Percentage, PF, Marks, Attendance, Remarks, StdName, StdCode, Min, Max, Assessment As String

                        BatchMarksCardR = dt2.Rows(0).Item("Default_Text").ToString()
                        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
                        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
                        CourseN = dt2.Rows(3).Item("Default_Text").ToString()
                        Batch = dt2.Rows(4).Item("Default_Text").ToString()
                        AcademicY = dt2.Rows(5).Item("Default_Text").ToString()
                        Assessment = dt2.Rows(6).Item("Default_Text").ToString()
                        AssDate = dt2.Rows(7).Item("Default_Text").ToString()
                        Total = dt2.Rows(8).Item("Default_Text").ToString()
                        Passed = dt2.Rows(9).Item("Default_Text").ToString()
                        Failed = dt2.Rows(10).Item("Default_Text").ToString()
                        SlNo = dt2.Rows(11).Item("Default_Text").ToString()
                        StdCode = dt2.Rows(12).Item("Default_Text").ToString()
                        StdName = dt2.Rows(13).Item("Default_Text").ToString()
                        Max = dt2.Rows(14).Item("Default_Text").ToString()
                        Min = dt2.Rows(15).Item("Default_Text").ToString()
                        Marks = dt2.Rows(16).Item("Default_Text").ToString()
                        Percentage = dt2.Rows(17).Item("Default_Text").ToString()
                        PF = dt2.Rows(18).Item("Default_Text").ToString()
                        Attendance = dt2.Rows(19).Item("Default_Text").ToString()
                        Remarks = dt2.Rows(20).Item("Default_Text").ToString()
                        AM = dt2.Rows(21).Item("Default_Text").ToString()
                        LM = dt2.Rows(22).Item("Default_Text").ToString()
                        HM = dt2.Rows(23).Item("Default_Text").ToString()
                        Semester = dt2.Rows(24).Item("Default_Text").ToString()
                        SubjectN = dt2.Rows(25).Item("Default_Text").ToString()
                        SubjectCode = dt2.Rows(26).Item("Default_Text").ToString()
                        ReportViewer1.LocalReport.ReportPath = "Rpt_BatchReportCardElecMarks.rdlc"
                        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BatchReportCardElect", dt1)
                        'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ElectiveSubjectName", ElectiveSubjectName, False))
                        'ReportViewer1.LocalReport.SetParameters(paramList)
                        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchMarksCardR", BatchMarksCardR, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseN", CourseN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assessment", Assessment, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssDate", AssDate, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Passed", Passed, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Failed", Failed, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Max", Max, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Min", Min, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Marks", Marks, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Percentage", Percentage, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("PF", PF, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Attendance", Attendance, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AM", AM, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("LM", LM, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("HM", HM, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectN", SubjectN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectCode", SubjectCode, False))

                        ReportViewer1.LocalReport.SetParameters(paramList)
                        ReportViewer1.LocalReport.DataSources.Clear()
                        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                        ReportViewer1.LocalReport.Refresh()

                        ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    ElseIf ReportType = "Remarks" Then
                        Dim LanguageID As Integer
                        Dim FormName As String
                        ''Multilingual Conversion  By: Niraj on 11 Jan 2014
                        If Session("LanguageID") = "" Then
                            LanguageID = 1
                        Else
                            LanguageID = Session("LanguageID")
                        End If
                        FormName = "BatchReportRemarksR"
                        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
                        Dim BatchReportRemarksR, BranchName, BranchType, CourseN, Batch, Semester, AcademicY As String
                        Dim Total, SubjectCode, AssDate, SlNo, SubjectN, Attendance, Remarks, StdName, StdCode, Assessment As String

                        BatchReportRemarksR = dt2.Rows(0).Item("Default_Text").ToString()
                        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
                        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
                        CourseN = dt2.Rows(3).Item("Default_Text").ToString()
                        Batch = dt2.Rows(4).Item("Default_Text").ToString()
                        AcademicY = dt2.Rows(5).Item("Default_Text").ToString()
                        Semester = dt2.Rows(6).Item("Default_Text").ToString()
                        SubjectN = dt2.Rows(7).Item("Default_Text").ToString()
                        SubjectCode = dt2.Rows(8).Item("Default_Text").ToString()
                        Assessment = dt2.Rows(9).Item("Default_Text").ToString()
                        AssDate = dt2.Rows(10).Item("Default_Text").ToString()
                        Total = dt2.Rows(11).Item("Default_Text").ToString()
                        SlNo = dt2.Rows(12).Item("Default_Text").ToString()
                        StdCode = dt2.Rows(13).Item("Default_Text").ToString()
                        StdName = dt2.Rows(14).Item("Default_Text").ToString()
                        Attendance = dt2.Rows(15).Item("Default_Text").ToString()
                        Remarks = dt2.Rows(16).Item("Default_Text").ToString()

                        ReportViewer1.LocalReport.ReportPath = "Rpt_BatchReportCardElectRemarks.rdlc"
                        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BatchReportCardElect", dt1)
                        'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ElectiveSubjectName", ElectiveSubjectName, False))
                        'ReportViewer1.LocalReport.SetParameters(paramList)
                        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchReportRemarksR", BatchReportRemarksR, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseN", CourseN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assessment", Assessment, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssDate", AssDate, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Attendance", Attendance, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))

                        ReportViewer1.LocalReport.SetParameters(paramList)
                        ReportViewer1.LocalReport.DataSources.Clear()
                        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                        ReportViewer1.LocalReport.Refresh()

                        ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    ElseIf ReportType = "Grade" Then
                        Dim LanguageID As Integer
                        Dim FormName As String
                        ''Multilingual Conversion  By: Niraj on 21 Jan 2014
                        If Session("LanguageID") = "" Then
                            LanguageID = 1
                        Else
                            LanguageID = Session("LanguageID")
                        End If
                        FormName = "BatchReportGradeR"
                        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
                        Dim BatchReportRemarksR, BranchName, BranchType, CourseN, Batch, Semester, AcademicY As String
                        Dim Total, SubjectCode, AssDate, SlNo, SubjectN, Attendance, Remarks, Grade, StdName, StdCode, Assessment As String

                        BatchReportRemarksR = dt2.Rows(0).Item("Default_Text").ToString()
                        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
                        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
                        CourseN = dt2.Rows(3).Item("Default_Text").ToString()
                        Batch = dt2.Rows(4).Item("Default_Text").ToString()
                        AcademicY = dt2.Rows(5).Item("Default_Text").ToString()
                        Semester = dt2.Rows(6).Item("Default_Text").ToString()
                        SubjectN = dt2.Rows(7).Item("Default_Text").ToString()
                        SubjectCode = dt2.Rows(8).Item("Default_Text").ToString()
                        Assessment = dt2.Rows(9).Item("Default_Text").ToString()
                        AssDate = dt2.Rows(10).Item("Default_Text").ToString()
                        Total = dt2.Rows(11).Item("Default_Text").ToString()
                        SlNo = dt2.Rows(12).Item("Default_Text").ToString()
                        StdCode = dt2.Rows(13).Item("Default_Text").ToString()
                        StdName = dt2.Rows(14).Item("Default_Text").ToString()
                        Grade = dt2.Rows(15).Item("Default_Text").ToString()
                        Attendance = dt2.Rows(16).Item("Default_Text").ToString()
                        Remarks = dt2.Rows(17).Item("Default_Text").ToString()
                        ReportViewer1.LocalReport.ReportPath = "Rpt_BatchReportCardElecGrade.rdlc"
                        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BatchReportCardElect", dt1)
                        'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ElectiveSubjectName", ElectiveSubjectName, False))
                        'ReportViewer1.LocalReport.SetParameters(paramList)
                        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchReportRemarksR", BatchReportRemarksR, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseN", CourseN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assessment", Assessment, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssDate", AssDate, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Grade", Grade, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Attendance", Attendance, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))

                        ReportViewer1.LocalReport.SetParameters(paramList)

                        ReportViewer1.LocalReport.DataSources.Clear()
                        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                        ReportViewer1.LocalReport.Refresh()

                        ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

                        'End If
                    Else
                        lblmsg.Text = ValidationMessage(1023)
                    End If
                Else
                    lblmsg.Text = ValidationMessage(1023)
                End If
            Catch ex As Exception
                lblmsg.Text = ValidationMessage(1023)
            End Try

        Else
            QueryStr.GetValue(Page.Request, Prop)
            dt3 = dl.Rpt_BatchReportMarksAnalysis(BranchCode, course, BatchNo, Sem, AsstType, Subject, Frm1, Frm2, Frm3, Frm4, To1, To2, To3, To4, RBType)
            Dim LanguageID As Integer
            Dim FormName As String
            ''Multilingual Conversion  By: Niraj on 21 Jan 2014
            If Session("LanguageID") = "" Then
                LanguageID = 1
            Else
                LanguageID = Session("LanguageID")
            End If
            FormName = "BatchMarksAnalysisR"
            dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
            Dim BatchMarksAnalysisR, BranchName, Batch, Semester As String
            Dim Absent, ClassAvg, TotalS, StdCountA, StdCountB, StdCount, SlNo, SubjectN, Assessment As String

            BatchMarksAnalysisR = dt2.Rows(0).Item("Default_Text").ToString()
            BranchName = dt2.Rows(1).Item("Default_Text").ToString()
            Batch = dt2.Rows(2).Item("Default_Text").ToString()
            Semester = dt2.Rows(3).Item("Default_Text").ToString()
            SubjectN = dt2.Rows(4).Item("Default_Text").ToString()
            Assessment = dt2.Rows(5).Item("Default_Text").ToString()
            SlNo = dt2.Rows(6).Item("Default_Text").ToString()
            ClassAvg = dt2.Rows(7).Item("Default_Text").ToString()
            TotalS = dt2.Rows(8).Item("Default_Text").ToString()
            StdCountB = dt2.Rows(9).Item("Default_Text").ToString()
            StdCountA = dt2.Rows(10).Item("Default_Text").ToString()
            StdCount = dt2.Rows(11).Item("Default_Text").ToString()
            Absent = dt2.Rows(12).Item("Default_Text").ToString()
            Dim BatchName As String = Request.QueryString.Get("BatchName")
            If dt2.Rows.Count > 0 Then

                ReportViewer1.LocalReport.ReportPath = "RptBatchMarksAnalysis.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_New_BatMarksAnalysis", dt3)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AsstType", AsstType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Frm1", Frm1, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Frm2", Frm2, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Frm3", Frm3, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Frm4", Frm4, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("To1", To1, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("To2", To2, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("To3", To3, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("To4", To4, False))

                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchMarksAnalysisR", BatchMarksAnalysisR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectN", SubjectN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assessment", Assessment, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ClassAvg", ClassAvg, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalS", TotalS, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCountB", StdCountB, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCountA", StdCountA, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCount", StdCount, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Absent", Absent, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchName", BatchName, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()

                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                lblmsg.Text = ValidationMessage(1014)
            Else

                lblmsg.Text = ValidationMessage(1023)
            End If

        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 21 jan 2014
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
