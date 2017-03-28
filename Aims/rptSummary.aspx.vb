
Partial Class rptSummary
    Inherits System.Web.UI.Page
    Dim bll As New StudentB
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2, dt As New DataTable
    
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub

    Protected Sub RptViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles RptViewer1.Init

        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BatchNo As Integer = Request.QueryString("BatchNo")
        Dim CourseId As Integer = Request.QueryString("CourseId")
        'Dim Ayear As String = Request.QueryString("Ayear")
        Dim DojDob As Integer = Request.QueryString.Get("DojDob")
        Dim FromDate As Date = Request.QueryString.Get("FromDate")
        Dim ToDate As Date = Request.QueryString.Get("ToDate")
        Dim SemID As Integer = Request.QueryString.Get("semid")
        Dim BranchCode As String = Request.QueryString.Get("BranchCode")

        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 03 Dec 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "StudentRegS"
        dt2 = DLReportsR.EnquiryDetailsHeading(FormName, LanguageID)
        Dim StudentRegR, BranchName, BranchType, AcademicY, DOJ, FromDateN, GTotal, ToDateN, SlNo, BatchN, DAdmission, SAdmission, Total, Course As String
        StudentRegR = dt2.Rows(0).Item("Default_Text").ToString()
        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
        'AcademicY = dt2.Rows(3).Item("Default_Text").ToString()
        DOJ = dt2.Rows(4).Item("Default_Text").ToString()
        FromDateN = dt2.Rows(5).Item("Default_Text").ToString()
        ToDateN = dt2.Rows(6).Item("Default_Text").ToString()
        SlNo = dt2.Rows(7).Item("Default_Text").ToString()
        BatchN = dt2.Rows(8).Item("Default_Text").ToString()
        DAdmission = dt2.Rows(9).Item("Default_Text").ToString()
        SAdmission = dt2.Rows(10).Item("Default_Text").ToString()
        Total = dt2.Rows(11).Item("Default_Text").ToString()
        Course = dt2.Rows(12).Item("Default_Text").ToString()
        GTotal = dt2.Rows(13).Item("Default_Text").ToString()
       
        dt1 = bll.GetSummaryRpt(BranchCode, CourseId, BatchNo, DojDob, FromDate, ToDate, SemID)
        If dt1.Rows.Count > 0 Then
            RptViewer1.LocalReport.ReportPath = "rptSummary.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StdSummary", dt1)
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Ayear", Ayear, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StudentRegR", StudentRegR, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DOJ", DOJ, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDateN", FromDateN, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDateN", ToDateN, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DAdmission", DAdmission, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SAdmission", SAdmission, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", Course, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("GTotal", GTotal, False))

            RptViewer1.LocalReport.SetParameters(paramList)
            RptViewer1.LocalReport.DataSources.Clear()
            Me.RptViewer1.LocalReport.DataSources.Add(dm)
            RptViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler RptViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            lblErrorMsg.Text = ValidationMessage(1023)
        End If
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

