
Partial Class RptStudAttendWitElecSubDetailedV
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
        Dim Bat, Sem, Subj, ES, StdId, SortBy, Min, Max, Category As Integer
        Dim fromdate, todate As DateTime
        Dim categoryname As String

        BR = Request.QueryString.Get("BranchCode")
        'AT = Request.QueryString.Get("A_Year")
        Bat = Request.QueryString.Get("Batch")
        Sem = Request.QueryString.Get("Semester")
        Subj = Request.QueryString.Get("Subject")
        'ES = Request.QueryString.Get("ElecSub")
        StdId = Request.QueryString.Get("StudentID")
        fromdate = Request.QueryString.Get("fromdate")
        todate = Request.QueryString.Get("todate")
        SortBy = Request.QueryString.Get("SortBy")
        Min = Request.QueryString.Get("Min")
        Max = Request.QueryString.Get("Max")
        Category = Request.QueryString.Get("Category")
        categoryname = Request.QueryString.Get("categoryname")

        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 1 Jan 2014
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "STDAttenDetailsR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim STDAttenDetailsR, BranchName, BranchType, Batch, Semester, MinN, MaxN, SlNo, StdCode, StdName, Attendance, DateN, Subject As String
        Dim Period As String
        STDAttenDetailsR = dt2.Rows(0).Item("Default_Text").ToString()
        BranchName = dt2.Rows(1).Item("Default_Text").ToString()
        BranchType = dt2.Rows(2).Item("Default_Text").ToString()
        Batch = dt2.Rows(3).Item("Default_Text").ToString()
        Semester = dt2.Rows(4).Item("Default_Text").ToString()
        MinN = dt2.Rows(5).Item("Default_Text").ToString()
        MaxN = dt2.Rows(6).Item("Default_Text").ToString()
        SlNo = dt2.Rows(7).Item("Default_Text").ToString()
        StdCode = dt2.Rows(8).Item("Default_Text").ToString()
        StdName = dt2.Rows(9).Item("Default_Text").ToString()
        Attendance = dt2.Rows(10).Item("Default_Text").ToString()
        DateN = dt2.Rows(11).Item("Default_Text").ToString()
        Subject = dt2.Rows(12).Item("Default_Text").ToString()
        Period = dt2.Rows(13).Item("Default_Text").ToString()
        

        'Dim BAL As New GlobalDataSetTableAdapters.Test_BankReconciliationTableAdapter
        Dim dt As New Data.DataTable

        QueryStr.GetValue(Page.Request, Prop)

        dt1 = DL.GetStudentDetailedReportWitElecSub(BR, Bat, Sem, Subj, StdId, fromdate, todate, SortBy, Category)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptStdAttendWitElceSub.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentAttendanceDetailedWitElecSubRpt", dt1)
                categoryname = Request.QueryString.Get("categoryname")
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Min", Min, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Max", Max, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDAttenDetailsR", STDAttenDetailsR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Semester", Semester, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("MinN", MinN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("MaxN", MaxN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Attendance", Attendance, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DateN", DateN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Subject", Subject, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Period", Period, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("categoryname", categoryname, False))
                ReportViewer1.LocalReport.SetParameters(paramList)


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
    ''Code Written for Multilingual By Niraj on 1st jan 2014
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



