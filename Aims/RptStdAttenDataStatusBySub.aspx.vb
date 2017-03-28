
Partial Class RptStdAttenDataStatusBySub
    Inherits BasePage

    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim BL As New BLDeptDashboard
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim dt As New Data.DataTable
        Dim Batch As String = Request.QueryString.Get("Batch")
        'Dim Semester As Integer = Request.QueryString.Get("Semester")
        'Dim Subject As Integer = Request.QueryString.Get("Subject")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = stdAttndance.ViewDataStatusBySub(Batch)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 27 Dec 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "AttendanceEntryR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim AttendanceEntryR, BatchN, SubjectN, SlNo, DateN, Period, Faculty As String

        AttendanceEntryR = dt2.Rows(0).Item("Default_Text").ToString()
        SlNo = dt2.Rows(1).Item("Default_Text").ToString()
        DateN = dt2.Rows(2).Item("Default_Text").ToString()
        BatchN = dt2.Rows(3).Item("Default_Text").ToString()
        SubjectN = dt2.Rows(4).Item("Default_Text").ToString()
        Period = dt2.Rows(5).Item("Default_Text").ToString()
        Faculty = dt2.Rows(6).Item("Default_Text").ToString()

        If dt1.Rows.Count > 0 Then

            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "RptStdAttenDataStatusBySub.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_ViewAttendDataEntryStatus", dt1)
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AttendanceEntryR", AttendanceEntryR, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DateN", DateN, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectN", SubjectN, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Period", Period, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Faculty", Faculty, False))

            ReportViewer1.LocalReport.SetParameters(paramList)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            lblErrorMsg.Text = ValidationMessage(1014)
        Else
            lblErrorMsg.Text = ValidationMessage(1023)
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt1)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 27th Dec 2013
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
