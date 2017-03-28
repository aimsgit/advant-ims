
Partial Class Rpt_StudentPerformanceRpt
    Inherits System.Web.UI.Page
    Dim ds1, dt2 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1, ParentDt As New DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dl As New DLReportsR
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Batch, Semester As Integer
        Dim Student, Subject As String
        Try
            'If Session("LoginType") = "Employee" Then
            '    Batch = Request.QueryString.Get("BatchId")
            '    Student = Request.QueryString.Get("student")
            '    Semester = Request.QueryString.Get("semester")
            '    Subject = Request.QueryString.Get("subject")
            'ElseIf Session("LoginType") = "Others" Then
            '    ParentDt = dl.GetStudentDtlsForParent1()
            '    Batch = ParentDt.Rows(0).Item("BatchID").ToString
            '    Student = ParentDt.Rows(0).Item("StdId").ToString
            '    Semester = ParentDt.Rows(0).Item("SemesterID").ToString
            '    Subject = 0
            'End If
            Dim LanguageID As Integer
            Dim FormName As String
            ''Multilingual Conversion  By: Niraj on 16 Jan 2014
            If Session("LanguageID") = "" Then
                LanguageID = 1
            Else
                LanguageID = Session("LanguageID")
            End If
            FormName = "STDPerformanceR"
            dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
            Dim STDPerformanceR, Name, SemesterN, BatchN, Percentage, Assessment As String
            
            STDPerformanceR = dt2.Rows(0).Item("Default_Text").ToString()
            Name = dt2.Rows(1).Item("Default_Text").ToString()
            SemesterN = dt2.Rows(2).Item("Default_Text").ToString()
            BatchN = dt2.Rows(3).Item("Default_Text").ToString()
            Percentage = dt2.Rows(4).Item("Default_Text").ToString()
            Assessment = dt2.Rows(5).Item("Default_Text").ToString()

            Batch = Request.QueryString.Get("BatchId")
            Student = Request.QueryString.Get("student")
            Semester = Request.QueryString.Get("semester")
            Subject = Request.QueryString.Get("subject")

            QueryStr.GetValue(Page.Request, Prop)
            dt1 = dl.Rpt_StudentPerformanceRpt(Batch, Student, Semester, Subject)
            Try
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "Rpt_StudentPerformanceRpt.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StdPerformance", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDPerformanceR", STDPerformanceR, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Name", Name, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemesterN", SemesterN, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Percentage", Percentage, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assessment", Assessment, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)

                    'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("sem", Sem, False))
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pension", pension, False))
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("month", Month, False))
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("year", Year, False))
                    'ReportViewer1.LocalReport.SetParameters(paramList)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = ValidationMessage(1023)
                End If
                'modified by Nitin 03/01/2012
            Catch ex As Exception
                lblmsg.Text = ValidationMessage(1074)
            End Try
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1023)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 15 jan 2014
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
