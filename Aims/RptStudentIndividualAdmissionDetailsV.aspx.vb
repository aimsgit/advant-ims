Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.IO
Partial Class RptStudentIndividualAdmissionDetailsV
    Inherits BasePage
    Dim ds1, ds2 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable
    Dim StartDate As Date
    Dim EndDAte As Date

    'Code written By Ajit
    '07-Mar-2013

    Protected Sub ReportViewer11_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer11.Init
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim AYID As Integer = Request.QueryString.Get("AYID")
        Dim CourseID As Integer = Request.QueryString.Get("CourseID")
        Dim BatchID As Integer = Request.QueryString.Get("BatchID")
        Dim StudentID As Integer = Request.QueryString.Get("StudentID")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = RptStudentAdmissionDetailsDL.GetStudentAdmissiondetails(CourseID, BatchID, StudentID)
        '    Dim dt As DataTable
        '    dt = selfdetailsDB.RPT_GetDeatilsByBranch(UID).Tables(0)
        'For i As Int16 = 0 To i < dt1.Rows.Count - 1
        '    If dt1.Rows(i)("Std_Photo").ToString <> "" Then
        '        Dim s As String = HttpContext.Current.Server.MapPath(dt1.Rows(i)("Std_Photo").ToString)
        '        If File.Exists(s) Then
        '            LoadImage(dt1.Rows(i), "image_stream", s)
        '        Else
        '            LoadImage(dt1.Rows(i), "image_stream", "~/Images/imageupload.gif")
        '        End If
        '    Else
        '        LoadImage(dt1.Rows(i), "image_stream", "~/Images/imageupload.gif")
        '    End If
        'Next
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 09 Dec 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "StudentIR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim StudentIR, AcademicY, Course, AdmsnDate, FName, AppNo, Code, Category, DOB, Contact, CAddress, BatchN As String
        Dim FatherN, FatherC, FatherE, PassportN, PassportName, PID, PED, FRRO, SPhoto, NIC, Gender, Age, SEmail As String
        Dim PAddress, MName, MContact, MEmail, IssuePlace, VisaNo, VID, VED, HouseName, TCNo, LDate As String
        StudentIR = dt2.Rows(0).Item("Default_Text").ToString()
        'AcademicY = dt2.Rows(1).Item("Default_Text").ToString()
        Course = dt2.Rows(2).Item("Default_Text").ToString()
        FName = dt2.Rows(3).Item("Default_Text").ToString()
        Code = dt2.Rows(4).Item("Default_Text").ToString()
        Category = dt2.Rows(5).Item("Default_Text").ToString()
        DOB = dt2.Rows(6).Item("Default_Text").ToString()
        Contact = dt2.Rows(7).Item("Default_Text").ToString()
        CAddress = dt2.Rows(8).Item("Default_Text").ToString()
        FatherN = dt2.Rows(9).Item("Default_Text").ToString()
        FatherC = dt2.Rows(10).Item("Default_Text").ToString()
        FatherE = dt2.Rows(11).Item("Default_Text").ToString()
        PassportName = dt2.Rows(12).Item("Default_Text").ToString()
        PassportN = dt2.Rows(13).Item("Default_Text").ToString()
        PID = dt2.Rows(14).Item("Default_Text").ToString()
        PED = dt2.Rows(15).Item("Default_Text").ToString()
        FRRO = dt2.Rows(16).Item("Default_Text").ToString()
        AppNo = dt2.Rows(17).Item("Default_Text").ToString()
        AdmsnDate = dt2.Rows(18).Item("Default_Text").ToString()
        SPhoto = dt2.Rows(19).Item("Default_Text").ToString()
        NIC = dt2.Rows(20).Item("Default_Text").ToString()
        Gender = dt2.Rows(21).Item("Default_Text").ToString()
        Age = dt2.Rows(22).Item("Default_Text").ToString()
        SEmail = dt2.Rows(23).Item("Default_Text").ToString()
        PAddress = dt2.Rows(24).Item("Default_Text").ToString()
        MName = dt2.Rows(25).Item("Default_Text").ToString()
        MContact = dt2.Rows(26).Item("Default_Text").ToString()
        MEmail = dt2.Rows(27).Item("Default_Text").ToString()
        IssuePlace = dt2.Rows(28).Item("Default_Text").ToString()
        VisaNo = dt2.Rows(29).Item("Default_Text").ToString()
        VID = dt2.Rows(30).Item("Default_Text").ToString()
        VED = dt2.Rows(31).Item("Default_Text").ToString()
        HouseName = dt2.Rows(32).Item("Default_Text").ToString()
        TCNo = dt2.Rows(33).Item("Default_Text").ToString()
        LDate = dt2.Rows(34).Item("Default_Text").ToString()
        BatchN = dt2.Rows(35).Item("Default_Text").ToString()
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer11.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer11.LocalReport.ReportPath = "RptStudentIndividualAdmissionDetails.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentIndividualReport", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StudentIR", StudentIR, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
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
                ReportViewer11.LocalReport.SetParameters(paramList)
                Me.ReportViewer11.LocalReport.DataSources.Add(dt)
                ReportViewer11.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer11.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Protected Sub LoadImage(ByVal objDataRow As DataRow, ByVal strImageField As String, ByVal FilePath As String)
        Try
            Dim fs As New FileStream(FilePath, FileMode.Open, FileAccess.Read)
            Dim Image(fs.Length) As Byte
            fs.Read(Image, 0, CInt(fs.Length))
            fs.Close()
            objDataRow(strImageField) = Image
        Catch ex As Exception
            'Response.Write("<font color=red>" + ex.Message + "</font>")
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

    ''Code Written for Multilingual By Niraj on 09th Dec 2013
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
