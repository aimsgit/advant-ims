
Partial Class RptSubjSubgrpFacultyMapV

    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim BatchId As Integer = Request.QueryString.Get("BatchId")
        Dim SemId As Integer = Request.QueryString.Get("SemId")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DLSubjectSubGrpMapping.RptSubjSubgrpFacultyMap(BatchId, SemId)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 27 Nov 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "SubjectSubFacMapR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim SubjectSubFacMapR, SlNo, Batch, Subject, Semester, SubGroup, Faculty As String

        SubjectSubFacMapR = dt2.Rows(0).Item("Default_Text").ToString()
        Batch = dt2.Rows(1).Item("Default_Text").ToString()
        Semester = dt2.Rows(2).Item("Default_Text").ToString()
        SlNo = dt2.Rows(3).Item("Default_Text").ToString()
        Subject = dt2.Rows(4).Item("Default_Text").ToString()
        SubGroup = dt2.Rows(5).Item("Default_Text").ToString()
        Faculty = dt2.Rows(6).Item("Default_Text").ToString()
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptSubjSubgrpFacultyMap.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SubjSubgrpFacultyMap", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectSubFacMapR", SubjectSubFacMapR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubGroup", SubGroup, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Faculty", Faculty, False))

                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else

                lblmsg.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 27th Nov 2013
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


