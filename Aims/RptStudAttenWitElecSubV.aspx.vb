
Partial Class RptStudAttenWitElecSubV
  
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim DL As New stdAttndance
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BR As String
        Dim AT, Bat, Sem, Subj, ES, StdId, Month As Integer

        BR = Request.QueryString.Get("BranchCode")
        'AT = Request.QueryString.Get("A_Year")
        Bat = Request.QueryString.Get("Batch")
        Sem = Request.QueryString.Get("Semester")
        Subj = Request.QueryString.Get("Subject")
        'ES = Request.QueryString.Get("ElecSub")
        StdId = Request.QueryString.Get("StudentID")
        Month = Request.QueryString.Get("Month")
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 06 Jan 2014
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "STDAttenDetailsRegR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim STDAttenDetailsRegR, Note, Academic, BranchType, BranchName, Batch As String
        Dim Semester, Subject, MonthN, Period, SlNo, StdName, WD, AD As String
        STDAttenDetailsRegR = dt2.Rows(0).Item("Default_Text").ToString()
        Note = dt2.Rows(1).Item("Default_Text").ToString()
        Academic = dt2.Rows(2).Item("Default_Text").ToString()
        BranchType = dt2.Rows(3).Item("Default_Text").ToString()
        BranchName = dt2.Rows(4).Item("Default_Text").ToString()
        Batch = dt2.Rows(5).Item("Default_Text").ToString()
        Semester = dt2.Rows(6).Item("Default_Text").ToString()
        Subject = dt2.Rows(7).Item("Default_Text").ToString()
        MonthN = dt2.Rows(8).Item("Default_Text").ToString()
        Period = dt2.Rows(9).Item("Default_Text").ToString()
        SlNo = dt2.Rows(10).Item("Default_Text").ToString()
        StdName = dt2.Rows(11).Item("Default_Text").ToString()
        WD = dt2.Rows(12).Item("Default_Text").ToString()
        AD = dt2.Rows(13).Item("Default_Text").ToString()

        'Dim BAL As New GlobalDataSetTableAdapters.Test_BankReconciliationTableAdapter
        Dim dt As New Data.DataTable

        QueryStr.GetValue(Page.Request, Prop)

        dt1 = DL.GetNewStudentAttendanceReportWitElecSub(BR, Bat, Sem, Subj, StdId, Month)

        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptStudAttenWitElecSub.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_NewStudAttendanceWitElecSub1", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDAttenDetailsRegR", STDAttenDetailsRegR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Note", Note, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Academic", Academic, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("MonthN", MonthN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Period", Period, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("WD", WD, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AD", AD, False))

                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt1)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 6th jan 2014
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



