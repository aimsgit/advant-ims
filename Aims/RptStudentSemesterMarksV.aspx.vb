
Partial Class RptStudentSemesterMarksV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim DL As New DLNewSemesterMarks
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource

        'Dim Ayear As Integer = Request.QueryString.Get("Ayear")
        Dim CourseID As Integer = Request.QueryString.Get("CourseID")
        Dim BatchID As Integer = Request.QueryString.Get("BatchID")
        Dim Semester As String = Request.QueryString.Get("Semester")
        Dim Student As Integer = Request.QueryString.Get("Student")
        QueryStr.GetValue(Page.Request, Prop)

        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 22 Jan 2014
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "STDSemMarksR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim STDSemMarksR, BranchName, BranchType, AcademicY, SemesterN As String
        Dim CourseN, BatchN, StudentN, Max, Percentage, Actual, AssessmentN As String

        STDSemMarksR = dt2.Rows(0).Item("Default_Text").ToString()
        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
        AcademicY = dt2.Rows(3).Item("Default_Text").ToString()
        CourseN = dt2.Rows(4).Item("Default_Text").ToString()
        BatchN = dt2.Rows(5).Item("Default_Text").ToString()
        SemesterN = dt2.Rows(6).Item("Default_Text").ToString()
        StudentN = dt2.Rows(7).Item("Default_Text").ToString()
        AssessmentN = dt2.Rows(8).Item("Default_Text").ToString()
        Max = dt2.Rows(9).Item("Default_Text").ToString()
        Actual = dt2.Rows(10).Item("Default_Text").ToString()
        Percentage = dt2.Rows(11).Item("Default_Text").ToString()

        dt1 = DLNewSemesterMarks.GetNewStudentReport(CourseID, BatchID, Semester, Student)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptNewStudentSemesterMarks.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_StudentsemesterMarks", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)

                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDSemMarksR", STDSemMarksR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicY", AcademicY, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseN", CourseN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemesterN", SemesterN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StudentN", StudentN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssessmentN", AssessmentN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Max", Max, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Actual", Actual, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Percentage", Percentage, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("id", ID, False))
                'ReportViewer1.LocalReport.SetParameters(paramList)
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else

                lblErrorMsg.Text = "No Record Display."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
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
