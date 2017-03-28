
Partial Class RptQualificationDetailsV
    Inherits BasePage
    Dim Bl As New DLQualficationDtsRpt
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2, dt3, dt4, dt As New DataTable

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm, dm1, dm2 As New Microsoft.Reporting.WebForms.ReportDataSource


        Dim CRS As String = Request.QueryString.Get("Course")
        Dim Batch As String = Request.QueryString.Get("Batch")
        Dim Student As String = Request.QueryString.Get("Student")
        Dim stdcode As String = Request.QueryString.Get("Stdcode")
        dt1 = Bl.GetQualificaitonDetailsReportt(stdcode)
        dt2 = Bl.GetExperienceDetailsReportt(stdcode)
        dt3 = Bl.GetCertificateDetailsReportt(stdcode)
        Dim LanguageID As Integer
        Dim FormName As String
        
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "QualificationDetailsR"
        dt4 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim QualificationDetailsR, BranchName, BranchType, SlNo, CourseN, Qd, BatchN, StdName, Exam As String
        Dim Board, Submitted, Year, CertiRecvd, Org, Marks, ExpD, NoofYear, NatureofJob, CertiName, Remarks As String
        QualificationDetailsR = dt4.Rows(0).Item("Default_Text").ToString()
        BranchName = dt4.Rows(1).Item("Default_Text").ToString()
        BranchType = dt4.Rows(2).Item("Default_Text").ToString()
        CourseN = dt4.Rows(3).Item("Default_Text").ToString()
        BatchN = dt4.Rows(4).Item("Default_Text").ToString()
        StdName = dt4.Rows(5).Item("Default_Text").ToString()
        Qd = dt4.Rows(6).Item("Default_Text").ToString()
        SlNo = dt4.Rows(7).Item("Default_Text").ToString()
        Exam = dt4.Rows(8).Item("Default_Text").ToString()
        Board = dt4.Rows(9).Item("Default_Text").ToString()
        Year = dt4.Rows(10).Item("Default_Text").ToString()
        Submitted = dt4.Rows(11).Item("Default_Text").ToString()
        Marks = dt4.Rows(12).Item("Default_Text").ToString()
        ExpD = dt4.Rows(13).Item("Default_Text").ToString()
        Org = dt4.Rows(14).Item("Default_Text").ToString()
        NoofYear = dt4.Rows(15).Item("Default_Text").ToString()
        NatureofJob = dt4.Rows(16).Item("Default_Text").ToString()
        CertiRecvd = dt4.Rows(17).Item("Default_Text").ToString()
        CertiName = dt4.Rows(18).Item("Default_Text").ToString()
        Remarks = dt4.Rows(19).Item("Default_Text").ToString()
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptQualificationDetails.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetQualicDetails", dt1)
            dm1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetExperienceDetails", dt2)
            dm2 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetCertiDetails", dt3)


            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)

            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", CRS, False))
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


            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            Me.ReportViewer1.LocalReport.DataSources.Add(dm1)
            Me.ReportViewer1.LocalReport.DataSources.Add(dm2)
            ReportViewer1.LocalReport.Refresh()
            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblmsg.Text = ValidationMessage(1023)
        End If
        'dt2 = Bl.GetExperienceDetailsReportt(stdcode)
        'If dt2.Rows.Count > 0 Then
        '    ReportViewer1.LocalReport.ReportPath = "RptQualificationDetails.rdlc"
        '    dm1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetExperienceDetails", dt2)

        '    'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
        '    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", CRS, False))
        '    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
        '    'ReportViewer1.LocalReport.SetParameters(paramList)

        '    ReportViewer1.LocalReport.DataSources.Clear()
        '    Me.ReportViewer1.LocalReport.DataSources.Add(dm1)
        '    ReportViewer1.LocalReport.Refresh()

        '    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
        '    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        'Else
        '    lblmsg.Text = "No Records to display"
        'End If

        'dt3 = Bl.GetCertificateDetailsReportt(stdcode)
        'If dt3.Rows.Count > 0 Then
        '    ReportViewer1.LocalReport.ReportPath = "RptQualificationDetails.rdlc"
        '    dm2 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetCertiDetails", dt3)
        '    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)

        '    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Course", CRS, False))
        '    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
        '    'ReportViewer1.LocalReport.SetParameters(paramList)
        '    ReportViewer1.LocalReport.DataSources.Clear()
        '    Me.ReportViewer1.LocalReport.DataSources.Add(dm2)
        '    ReportViewer1.LocalReport.Refresh()

        '    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
        '    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        'Else
        '    lblmsg.Text = "No Records to display"
        'End If
    End Sub
   
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