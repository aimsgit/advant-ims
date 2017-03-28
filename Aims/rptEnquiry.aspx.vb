
Partial Class rptEnquiry
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        'Dim BAL As New EnquiryManager
        Dim Prop As New QureyStringP
        Dim DL As New DLReportsR
        Dim dt1 As New Data.DataTable
        Dim dt2 As New Data.DataTable
        Dim fname As String = Request.QueryString.Get("Name")
        Dim FromDate As DateTime = Request.QueryString.Get("FromDate")
        Dim ToDate As DateTime = Request.QueryString.Get("ToDate")
        Dim BranchCode As String = Request.QueryString.Get("BCode")
        Dim Course As Integer = Request.QueryString.Get("CourseId")
        Dim AdmitFlag As String = Request.QueryString.Get("admitted")
        Dim sourse As String = Request.QueryString.Get("Source")
        Dim ERealatedTo As String = Request.QueryString.Get("ERealatedTo")
        QueryStr.GetValue(Page.Request, Prop)
        'dt1 = BAL.Display(fname, BranchCode, AdmitFlag)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 03 Dec 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "Enquiry_Details"
        dt2 = DLReportsR.EnquiryDetailsHeading(FormName, LanguageID)
        Dim Enquiry_Details, State, MobileNo, Enquiry, Parent, Annual, EnquiryRelated, CourseName, SlNo, Name, Source, Admitted, BranchName, BranchType, TotalEnquired, TotalAdmitted, FDate, TDate As String
        SlNo = dt2.Rows(0).Item("Default_Text").ToString()
        Enquiry_Details = dt2.Rows(1).Item("Default_Text").ToString()
        Name = dt2.Rows(2).Item("Default_Text").ToString()
        State = dt2.Rows(3).Item("Default_Text").ToString()
        MobileNo = dt2.Rows(4).Item("Default_Text").ToString()
        Enquiry = dt2.Rows(5).Item("Default_Text").ToString()
        Parent = dt2.Rows(6).Item("Default_Text").ToString()
        Annual = dt2.Rows(7).Item("Default_Text").ToString()
        EnquiryRelated = dt2.Rows(8).Item("Default_Text").ToString()
        CourseName = dt2.Rows(9).Item("Default_Text").ToString()
        Source = dt2.Rows(10).Item("Default_Text").ToString()
        Admitted = dt2.Rows(11).Item("Default_Text").ToString()
        BranchName = dt2.Rows(12).Item("Default_Text").ToString()
        BranchType = dt2.Rows(13).Item("Default_Text").ToString()
        TotalEnquired = dt2.Rows(14).Item("Default_Text").ToString()
        TotalAdmitted = dt2.Rows(15).Item("Default_Text").ToString()
        FDate = dt2.Rows(16).Item("Default_Text").ToString()
        TDate = dt2.Rows(17).Item("Default_Text").ToString()


        dt1 = DL.EnquiryDetails(FromDate, ToDate, BranchCode, Course, fname, AdmitFlag, sourse, ERealatedTo)
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "rptEnquiry.rdlc"
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_EnquiryDetails", dt1)

            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Name", Name, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Enquiry_Details", Enquiry_Details, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("State", State, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("MobileNo", MobileNo, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Enquiry", Enquiry, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Parent", Parent, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Annual", Annual, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EnquiryRelated", EnquiryRelated, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseName", CourseName, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Source", Source, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Admitted", Admitted, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalEnquired", TotalEnquired, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalAdmitted", TotalAdmitted, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FDate", FDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TDate", TDate, False))

            ReportViewer1.LocalReport.SetParameters(paramList)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()

            ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            LblError.Text = ValidationMessage(1023)
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

    ''Code Written for Multilingual By Niraj on 29th Nov 2013
    ''Retriving the text of controls based on Language
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt5 As DataTable
        dt5 = Session("ValidationTable")
        Dim X As Integer = dt5.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt5.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt5.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
End Class
'iif(Fields!Admitted_Flag.Value="Y", Count(Fields!EId.Value),"0")
'="From Date : " &format(Parameters!FromDate.Value,"dd-MMM-yyyy")
'="To Date : " & format(Parameters!ToDate.Value,"dd-MMM-yyyy")