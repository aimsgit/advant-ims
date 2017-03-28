
Partial Class Merge
    Inherits System.Web.UI.Page
    Dim dt, dt1, dt2, dt3, dt21, dt23, dtQ1, dtQ2, dtQ3, dt41, dtF, dte As New DataTable
    Dim fromdate, todate As Date
    Dim obj As New SelfDetailsB
    Dim Bl As New DLQualficationDtsRpt
    Dim BF As New FeeCollectionBL
    Dim Prop As New QureyStringP
    Dim StdCode, StdName As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLStudentLogBook

        Dim BatchId As Integer
        Dim assesstype As Integer
        Dim StudentID As Integer
        Dim StdID, LogID As Integer
        Dim BranchCode As String
        Dim BatchNo, Course As String
        Dim AY As String
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        fromdate = "01-01-1900"
        todate = "01-01-4000"
        'Dim bachid As Integer = CInt(Request.QueryString.Get("batch"))

        dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        ReportViewer1.LocalReport.ReportPath = "Merge.rdlc"

        BatchNo = Request.QueryString.Get("BatchNo")
        Course = Request.QueryString.Get("Course")
        BatchId = Request.QueryString.Get("BatchID")
        StudentID = Request.QueryString.Get("StudentID")
        AY = Request.QueryString.Get("AY")
        dt1 = RptStudentAdmissionDetailsDL.GetStudentAdmissiondetails(0, BatchId, StudentID)

        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 09 Dec 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "StudentIR"
        dte = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim StudentIR, AcademicY, AdmsnDate, FName, AppNo, Code, Category, DOB, Contact, CAddress, BatchN As String
        Dim FatherN, FatherC, FatherE, PassportN, PassportName, PID, PED, FRRO, SPhoto, NIC, Gender, Age, SEmail As String
        Dim PAddress, MName, MContact, MEmail, IssuePlace, VisaNo, VID, VED, HouseName, TCNo, LDate As String
        StudentIR = dte.Rows(0).Item("Default_Text").ToString()
        AcademicY = dte.Rows(1).Item("Default_Text").ToString()
        Course = dte.Rows(2).Item("Default_Text").ToString()
        FName = dte.Rows(3).Item("Default_Text").ToString()
        Code = dte.Rows(4).Item("Default_Text").ToString()
        Category = dte.Rows(5).Item("Default_Text").ToString()
        DOB = dte.Rows(6).Item("Default_Text").ToString()
        Contact = dte.Rows(7).Item("Default_Text").ToString()
        CAddress = dte.Rows(8).Item("Default_Text").ToString()
        FatherN = dte.Rows(9).Item("Default_Text").ToString()
        FatherC = dte.Rows(10).Item("Default_Text").ToString()
        FatherE = dte.Rows(11).Item("Default_Text").ToString()
        PassportName = dte.Rows(12).Item("Default_Text").ToString()
        PassportN = dte.Rows(13).Item("Default_Text").ToString()
        PID = dte.Rows(14).Item("Default_Text").ToString()
        PED = dte.Rows(15).Item("Default_Text").ToString()
        FRRO = dte.Rows(16).Item("Default_Text").ToString()
        AppNo = dte.Rows(17).Item("Default_Text").ToString()
        AdmsnDate = dte.Rows(18).Item("Default_Text").ToString()
        SPhoto = dte.Rows(19).Item("Default_Text").ToString()
        NIC = dte.Rows(20).Item("Default_Text").ToString()
        Gender = dte.Rows(21).Item("Default_Text").ToString()
        Age = dte.Rows(22).Item("Default_Text").ToString()
        SEmail = dte.Rows(23).Item("Default_Text").ToString()
        PAddress = dte.Rows(24).Item("Default_Text").ToString()
        MName = dte.Rows(25).Item("Default_Text").ToString()
        MContact = dte.Rows(26).Item("Default_Text").ToString()
        MEmail = dte.Rows(27).Item("Default_Text").ToString()
        IssuePlace = dte.Rows(28).Item("Default_Text").ToString()
        VisaNo = dte.Rows(29).Item("Default_Text").ToString()
        VID = dte.Rows(30).Item("Default_Text").ToString()
        VED = dte.Rows(31).Item("Default_Text").ToString()
        HouseName = dte.Rows(32).Item("Default_Text").ToString()
        TCNo = dte.Rows(33).Item("Default_Text").ToString()
        LDate = dte.Rows(34).Item("Default_Text").ToString()
        BatchN = dte.Rows(35).Item("Default_Text").ToString()
        BranchCode = (Session("BranchCode"))


        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        
        FormName = "STDReportCardR"
        dt23 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim STDReportCardR, BranchName, BranchType, Batch, Semester As String
        Dim Total, SubjectName, Grade, Marks, Attendance, Remarks, StdName, StdCode, Min, Max, Obtained, Pass, Assessment As String

        STDReportCardR = dt23.Rows(0).Item("Default_Text").ToString()
        StdName = dt23.Rows(1).Item("Default_Text").ToString()
        StdCode = dt23.Rows(2).Item("Default_Text").ToString()
        BranchName = dt23.Rows(3).Item("Default_Text").ToString()
        BranchType = dt23.Rows(4).Item("Default_Text").ToString()
        Course = dt23.Rows(5).Item("Default_Text").ToString()
        Batch = dt23.Rows(6).Item("Default_Text").ToString()
        AcademicY = dt23.Rows(7).Item("Default_Text").ToString()
        SubjectName = dt23.Rows(8).Item("Default_Text").ToString()
        Max = dt23.Rows(9).Item("Default_Text").ToString()
        Min = dt23.Rows(10).Item("Default_Text").ToString()
        Marks = dt23.Rows(11).Item("Default_Text").ToString()
        Obtained = dt23.Rows(12).Item("Default_Text").ToString()
        Grade = dt23.Rows(13).Item("Default_Text").ToString()
        Pass = dt23.Rows(14).Item("Default_Text").ToString()
        Attendance = dt23.Rows(15).Item("Default_Text").ToString()
        Remarks = dt23.Rows(16).Item("Default_Text").ToString()
        Semester = dt23.Rows(17).Item("Default_Text").ToString()
        Assessment = dt23.Rows(18).Item("Default_Text").ToString()
        Total = dt23.Rows(19).Item("Default_Text").ToString()



        dt2 = DLStdReportCard.GetStudentReportCard(BranchCode, StudentID, BatchId, 0, 0, 0)
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "STDLogBookR"
        dt21 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim STDLogBookR, FromDateN, ToDateN, SlNo, DateN, LogType, FacultyN, Feedback As String


        STDLogBookR = dt21.Rows(0).Item("Default_Text").ToString()
        FromDateN = dt21.Rows(1).Item("Default_Text").ToString()
        ToDateN = dt21.Rows(2).Item("Default_Text").ToString()
        SlNo = dt21.Rows(3).Item("Default_Text").ToString()
        DateN = dt21.Rows(4).Item("Default_Text").ToString()
        LogType = dt21.Rows(5).Item("Default_Text").ToString()
        BatchN = dt21.Rows(6).Item("Default_Text").ToString()
        FacultyN = dt21.Rows(7).Item("Default_Text").ToString()
        Feedback = dt21.Rows(8).Item("Default_Text").ToString()
        StdCode = dt21.Rows(9).Item("Default_Text").ToString()
        StdName = dt21.Rows(10).Item("Default_Text").ToString()


        'If Session("LoginType") = "Employee" Then
        '    'BatchId = Request.QueryString.Get("BatchID")
        '    'StdID = Request.QueryString.Get("StdID")
        '    'LogID = Request.QueryString.Get("LogID")
        '    'fromdate = Request.QueryString.Get("FromDate").ToString
        '    'todate = Request.QueryString.Get("ToDate").ToString

        'ElseIf Session("LoginType") = "Others" Then
        '    QueryStr.GetValue(Page.Request, Prop)
        '    dt1 = DL.RptGetStudentParentLog()
        '    StdID = dt1.Rows(0).Item("STD_ID").ToString
        '    BranchCode = dt1.Rows(0).Item("BranchCode").ToString
        '    BatchId = dt1.Rows(0).Item("Batch_No").ToString
        '    LogID = 0
        '    fromdate = "01-01-1900"
        '    todate = "01-01-4000"
        'End If
        QueryStr.GetValue(Page.Request, Prop)
        dt3 = DL.RptGetStudentLog(BatchId, StudentID, 0, fromdate, todate)

        FormName = "QualificationDetailsR"
        dt41 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim QualificationDetailsR, CourseN, Qd, Exam As String
        Dim Board, Submitted, Year, CertiRecvd, Org, ExpD, NoofYear, NatureofJob, CertiName As String
        QualificationDetailsR = dt41.Rows(0).Item("Default_Text").ToString()
        BranchName = dt41.Rows(1).Item("Default_Text").ToString()
        BranchType = dt41.Rows(2).Item("Default_Text").ToString()
        CourseN = dt41.Rows(3).Item("Default_Text").ToString()
        BatchN = dt41.Rows(4).Item("Default_Text").ToString()
        StdName = dt41.Rows(5).Item("Default_Text").ToString()
        Qd = dt41.Rows(6).Item("Default_Text").ToString()
        SlNo = dt41.Rows(7).Item("Default_Text").ToString()
        Exam = dt41.Rows(8).Item("Default_Text").ToString()
        Board = dt41.Rows(9).Item("Default_Text").ToString()
        Year = dt41.Rows(10).Item("Default_Text").ToString()
        Submitted = dt41.Rows(11).Item("Default_Text").ToString()
        Marks = dt41.Rows(12).Item("Default_Text").ToString()
        ExpD = dt41.Rows(13).Item("Default_Text").ToString()
        Org = dt41.Rows(14).Item("Default_Text").ToString()
        NoofYear = dt41.Rows(15).Item("Default_Text").ToString()
        NatureofJob = dt41.Rows(16).Item("Default_Text").ToString()
        CertiRecvd = dt41.Rows(17).Item("Default_Text").ToString()
        CertiName = dt41.Rows(18).Item("Default_Text").ToString()
        Remarks = dt41.Rows(19).Item("Default_Text").ToString()


        dtQ1 = Bl.GetQualificaitonDetailsReportt(StudentID)
        dtQ2 = Bl.GetExperienceDetailsReportt(StudentID)
        dtQ3 = Bl.GetCertificateDetailsReportt(StudentID)

        dtF = BF.FeeCollectionReport(BatchId, 0, 0, StudentID, fromdate, todate, 0)

        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
        'For Student Admission Details
        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", Course, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", BatchNo, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StudentIR", StudentIR, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", Course, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FName", FName, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Code", Code, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Category", Category, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DOB", DOB, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Contact", Contact, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CAddress", CAddress, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FatherN", FatherN, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FatherC", FatherC, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FatherE", FatherE, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("PassportName", PassportName, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("PassportN", PassportN, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("PID", PID, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("PED", PED, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FRRO", FRRO, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AppNo", AppNo, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AdmsnDate", AdmsnDate, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SPhoto", SPhoto, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("NIC", NIC, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Gender", Gender, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Age", Age, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SEmail", SEmail, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("PAddress", PAddress, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("MName", MName, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("MContact", MContact, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("MEmail", MEmail, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("IssuePlace", IssuePlace, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("VisaNo", VisaNo, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("VID", VID, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("VED", VED, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("HouseName", HouseName, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TCNo", TCNo, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("LDate", LDate, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
        'For Student LogBook
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", fromdate, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", todate, False))

        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDLogBookR", STDLogBookR, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDateN", FromDateN, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDateN", ToDateN, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DateN", DateN, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("LogType", LogType, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FacultyN", FacultyN, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Feedback", Feedback, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
        'For StdReportCardMarksGrade 
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

        'For QualificationDetails
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", Course, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("QualificationDetailsR", QualificationDetailsR, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseN", CourseN, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Qd", Qd, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Exam", Exam, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Board", Board, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Year", Year, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Submitted", Submitted, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Marks", Marks, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ExpD", ExpD, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Org", Org, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("NoofYear", NoofYear, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("NatureofJob", NatureofJob, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CertiRecvd", CertiRecvd, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CertiName", CertiName, False))
        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))


        ReportViewer1.LocalReport.SetParameters(paramList)

        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        'If (a.Equals("0")) Then
        '    su()
        'End If

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        'Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        'e.DataSources.Add(rptDataSource)
        Dim rpt = e.ReportPath

        Select Case rpt
            Case "RptStudentIndividualAdmissionDetails"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentIndividualReport", dt1)
                e.DataSources.Add(rptDataSource)
            Case "StdReportCardMarksGrade"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentReportCard", dt2)
                e.DataSources.Add(rptDataSource)
            Case "RptStudentLogBook"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentLogBook", dt3)
                e.DataSources.Add(rptDataSource)
            Case "MasterHeadingL"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
                e.DataSources.Add(rptDataSource)
            Case "MasterHeading"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
                e.DataSources.Add(rptDataSource)
            Case "RptQualificationDetails"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetQualicDetails", dtQ1)
                e.DataSources.Add(rptDataSource)

                Dim rptDataSource1 As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetExperienceDetails", dtQ2)
                e.DataSources.Add(rptDataSource1)

                Dim rptDataSource2 As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetCertiDetails", dtQ3)
                e.DataSources.Add(rptDataSource2)
            Case "RptFeeCollectionReport"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_FeeCollectionReport", dtF)
                e.DataSources.Add(rptDataSource)
        End Select
    End Sub
End Class
