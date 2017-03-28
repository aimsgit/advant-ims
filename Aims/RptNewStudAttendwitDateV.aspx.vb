
Partial Class RptNewStudAttendwitDateV

    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim DL As New stdAttndance
        Dim dm1, dm2 As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BR As String
        Dim Bat, Sem, Subj, SortBy, SubjectSubgrp As Integer
        Dim FromDate, ToDate As Date

        BR = Request.QueryString.Get("BranchCode")
        'AT = Request.QueryString.Get("A_Year")
        Bat = Request.QueryString.Get("Batch")
        Sem = Request.QueryString.Get("Semester")
        Subj = Request.QueryString.Get("Subj")
        FromDate = Request.QueryString.Get("FrmDate")
        ToDate = Request.QueryString.Get("ToDate")
        SortBy = Request.QueryString.Get("SortBy")
        SubjectSubgrp = Request.QueryString.Get("SubjectSubgrp")
       
        Dim LanguageID As Integer
        Dim FormName As String
        '
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "STDAttendanceDateR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim STDAttendanceDateR, Note, Academic, Batch, FromDateN, ToDateN, StdCode As String
        Dim Semester, Subject As String
        STDAttendanceDateR = dt2.Rows(0).Item("Default_Text").ToString()
        Note = dt2.Rows(1).Item("Default_Text").ToString()
        Academic = dt2.Rows(2).Item("Default_Text").ToString()
        Batch = dt2.Rows(3).Item("Default_Text").ToString()
        Semester = dt2.Rows(4).Item("Default_Text").ToString()
        Subject = dt2.Rows(5).Item("Default_Text").ToString()
        FromDateN = dt2.Rows(6).Item("Default_Text").ToString()
        ToDateN = dt2.Rows(7).Item("Default_Text").ToString()
        StdCode = dt2.Rows(8).Item("Default_Text").ToString()
        

        'Dim BAL As New GlobalDataSetTableAdapters.Test_BankReconciliationTableAdapter
        Dim dt As New Data.DataTable

        QueryStr.GetValue(Page.Request, Prop)

        dt1 = DL.GetNewStudentAttendanceReportwitDate(BR, Bat, Sem, Subj, FromDate, ToDate, SortBy, SubjectSubgrp)
        'dt2 = DL.GetNewStudentAttendanceReportwitDate(BR, AT, Bat, Sem, Subj, FromDate, ToDate)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptNewStudAttendwitDate.rdlc"
                dm1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_NewStudAttendancewitDate", dt1)
                'dm2 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_NewStudAttendancewitDate1", dt2)

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDAttendanceDateR", STDAttendanceDateR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Note", Note, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Academic", Academic, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDateN", FromDateN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDateN", ToDateN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm1)
                'Me.ReportViewer1.LocalReport.DataSources.Add(dm2)
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
    ''Code Written for Multilingual By Niraj on 8th jan 2014
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



