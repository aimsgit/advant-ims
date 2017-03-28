﻿
Partial Class RptStudAttendanceBySubV
    Inherits BasePage

    Dim DL As New DLStudAttendBySub
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt, dt2, ParentDt, ParentDt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BR As String = ""
        Dim Bat, Sem As String
        Dim Subj, ES, StdId, SortBy, Category As Integer
        Dim fromdate, todate As DateTime
        Dim Min As Integer
        Dim Max As Integer
        Dim categoryname As String
        'Dim  As Integer = Request.QueryString.Get("Batch")
        'Dim  As Integer = Request.QueryString.Get("Semester")
        'Dim  As Integer = Request.QueryString.Get("Subject")
        'Dim  As Integer = Request.QueryString.Get("ClassType")
        'Dim  As DateTime = Request.QueryString.Get("todate")
        'Dim  As Integer = Request.QueryString.Get("StudentID")
        Try
            If Session("LoginType") = "Employee" Then
                BR = Request.QueryString.Get("BranchCode")
                'AT = Request.QueryString.Get("A_Year")
                Bat = Request.QueryString.Get("Batch")
                Sem = Request.QueryString.Get("Semester")
                Subj = Request.QueryString.Get("Subject")
                'ES = Request.QueryString.Get("ElecSub")
                StdId = Request.QueryString.Get("StudentID")
                fromdate = Request.QueryString.Get("fromdate")
                todate = Request.QueryString.Get("todate")
                Min = Request.QueryString.Get("Min")
                Max = Request.QueryString.Get("Max")
                SortBy = Request.QueryString.Get("SortBy")
                Category = Request.QueryString.Get("Category")
                categoryname = Request.QueryString.Get("categoryname")
            ElseIf Session("LoginType") = "Others" Then
                ParentDt = DL.GetStudentDtlsForParent()
                BR = ParentDt.Rows(0).Item("BranchCode").ToString
                Bat = ParentDt.Rows(0).Item("Batch_No").ToString
                ParentDt1 = DL.GetStdSemester(Bat, fromdate, todate)
                'AT = ParentDt1.Rows(0).Item("AcademicYear").ToString
                Sem = ParentDt1.Rows(0).Item("SemesterID").ToString
                Subj = 0
                'ES = 0
                StdId = ParentDt.Rows(0).Item("STD_ID").ToString
                fromdate = ParentDt1.Rows(0).Item("StartDate").ToString
                todate = Format(CDate(Session("FinEndDate")), "dd-MMM-yyyy")
                Min = 0.0
                Max = 1000
                SortBy = Request.QueryString.Get("SortBy")
                Category = Request.QueryString.Get("Category")
                categoryname = Request.QueryString.Get("categoryname")
            End If
            QueryStr.GetValue(Page.Request, Prop)
            dt1 = DL.GetStudentReportWitElecSub(BR, Bat, Sem, Subj, StdId, fromdate, todate, Min, Max, SortBy, Category)
            Try
                If dt1.Rows.Count > 0 Then
                    ReportViewer1.LocalReport.ReportPath = "RptStudAttendanceBySubV.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentAttendanceRptWitSub", dt1)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", todate, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)

                    dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    LblError.Text = ValidationMessage(1023)
                End If
            Catch ex As Exception
                LblError.Text = ValidationMessage(1074)
            End Try
        Catch ex As Exception
            LblError.Text = ValidationMessage(1023)
        End Try
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub

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
