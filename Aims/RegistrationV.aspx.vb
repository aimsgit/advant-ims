
Partial Class RegistrationV
    Inherits BasePage
    Dim BAL As New StudentB
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2, dt As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Branch As String = Request.QueryString.Get("Branch")
        Dim Course As Integer = Request.QueryString.Get("Course")
        Dim Batch As Integer = Request.QueryString.Get("Batch")
        Dim AYear As Integer = Request.QueryString.Get("AYear")
        Dim Gender As String = Request.QueryString.Get("Gender")
        Dim State As Integer = Request.QueryString.Get("State")
        Dim Feecollected As String = Request.QueryString.Get("Feecollected")
        Dim Country As String = Request.QueryString.Get("Country")
        Dim District As String = Request.QueryString.Get("District")
        Dim FromAge As Integer = Request.QueryString.Get("FromAge")
        Dim ToAge As Integer = Request.QueryString.Get("ToAge")
        Dim categry As Integer = Request.QueryString.Get("categry")
        Dim Sort As Integer = Request.QueryString.Get("Sort")
        Dim Caste As Integer = Request.QueryString.Get("Caste")
        Dim Hostel As String = Request.QueryString.Get("Hostel")
        Dim Transport As String = Request.QueryString.Get("Transport")
        Dim CurrentDate As DateTime = Request.QueryString.Get("CurrentDate")


        If Sort = 0 Then
            dt1 = BAL.GetAdmissionReport(Branch, Course, Batch, AYear, Gender, State, Feecollected, Country, District, FromAge, ToAge, categry, Caste, Hostel, Transport, CurrentDate)

            Dim LanguageID As Integer
            Dim FormName As String
            ''Multilingual Conversion  By: Niraj on 28 Nov 2013
            If Session("LanguageID") = "" Then
                LanguageID = 1
            Else
                LanguageID = Session("LanguageID")
            End If
            FormName = "AdmissionRegisterR"
            dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
            Dim AdmissionRegisterR, BranchName, BranchType, SlNo, StdName, StdCode, AcademicY, Aadhar, Dob, GenderN, AdmnDate, CourseN, BatchN As String
            Dim Address, Mother, Contact, Category, Total As String
            AdmissionRegisterR = dt2.Rows(0).Item("Default_Text").ToString()
            SlNo = dt2.Rows(1).Item("Default_Text").ToString()
            StdCode = dt2.Rows(2).Item("Default_Text").ToString()
            StdName = dt2.Rows(3).Item("Default_Text").ToString()
            Aadhar = dt2.Rows(4).Item("Default_Text").ToString()
            Dob = dt2.Rows(5).Item("Default_Text").ToString()
            GenderN = dt2.Rows(6).Item("Default_Text").ToString()
            AdmnDate = dt2.Rows(7).Item("Default_Text").ToString()
            Address = dt2.Rows(8).Item("Default_Text").ToString()
            Mother = dt2.Rows(9).Item("Default_Text").ToString()
            Contact = dt2.Rows(10).Item("Default_Text").ToString()
            Category = dt2.Rows(11).Item("Default_Text").ToString()
            BranchName = dt2.Rows(12).Item("Default_Text").ToString()
            BranchType = dt2.Rows(13).Item("Default_Text").ToString()
            AcademicY = dt2.Rows(14).Item("Default_Text").ToString()
            Total = dt2.Rows(15).Item("Default_Text").ToString()
            CourseN = dt2.Rows(16).Item("Default_Text").ToString()
            BatchN = dt2.Rows(17).Item("Default_Text").ToString()
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RegistrationDetailsReport.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_AdmissionDetails", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AdmissionRegisterR", AdmissionRegisterR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Aadhar", Aadhar, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Dob", Dob, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("GenderN", GenderN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AdmnDate", AdmnDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Address", Address, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Mother", Mother, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Contact", Contact, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Category", Category, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseN", CourseN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CurrentDate", CurrentDate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                LblError.Text = ValidationMessage(1023)
            End If
        Else
            dt1 = BAL.GetAdmissionReport1(Branch, Course, Batch, AYear, Gender, State, Feecollected, Country, District, FromAge, ToAge, categry, Caste, Hostel, Transport)
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RegistrationDetailsReport1.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_AdmissionDetail", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                LblError.Text = ValidationMessage(1023)
            End If
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 28th Nov 2013
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
