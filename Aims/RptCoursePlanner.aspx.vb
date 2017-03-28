
Partial Class RptCoursePlanner
    Inherits System.Web.UI.Page
    Dim Bl As New BLCoursePlanner
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable
    Dim ds1 As New DataTable

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

       
        Dim CRS As String = Request.QueryString.Get("Course")

        dt1 = Bl.GetCoursePlannerReport(CRS)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 22 Nov 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "CoursePlanR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim CoursePlanR, BranchName, BranchType, SlNo, SubjectCode, Subject, TotalHours, Credit As String
        Dim CourseName, Semester, Total As String
        CoursePlanR = dt2.Rows(0).Item("Default_Text").ToString()
        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
        SlNo = dt2.Rows(3).Item("Default_Text").ToString()
        SubjectCode = dt2.Rows(4).Item("Default_Text").ToString()
        Subject = dt2.Rows(5).Item("Default_Text").ToString()
        TotalHours = dt2.Rows(6).Item("Default_Text").ToString()
        Credit = dt2.Rows(7).Item("Default_Text").ToString()
        CourseName = dt2.Rows(8).Item("Default_Text").ToString()
        Semester = dt2.Rows(9).Item("Default_Text").ToString()
        Total = dt2.Rows(10).Item("Default_Text").ToString()
        
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptCoursePlannerNew.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_CoursePlanner", dt1)
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CoursePlanR", CoursePlanR, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectCode", SubjectCode, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalHours", TotalHours, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Credit", Credit, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseName", CourseName, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))

            ReportViewer1.LocalReport.SetParameters(paramList)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(0))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblmsg.Text = ValidationMessage(1023)
        End If
    End Sub
    ''Code Written for Multilingual By Niraj on 23th Nov 2013
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
