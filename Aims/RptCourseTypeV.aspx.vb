﻿
Partial Class RptCourseTypeV
    Inherits System.Web.UI.Page
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim DL As New CourseTypeDB
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim dt2 As New Data.DataTable
        Dim LanguageID As Integer
        Dim FormName As String
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "Course Type"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim CourseType, BranchName, BranchType, SlNo, CoType As String
        CourseType = dt2.Rows(0).Item("Default_Text").ToString()
        BranchType = dt2.Rows(1).Item("Default_Text").ToString()
        BranchName = dt2.Rows(2).Item("Default_Text").ToString()
        SlNo = dt2.Rows(3).Item("Default_Text").ToString()
        CoType = dt2.Rows(4).Item("Default_Text").ToString()
        dt1 = DL.RptCourseType()
        Try
            If dt1.Rows.Count > 0 Then


                ReportViewer1.LocalReport.ReportPath = "RptCourseType.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetCourseTypeDetails", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseType", CourseType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CoType", CoType, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else

                lblmsg.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Ajit Kumar Singh on 12th Aug
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
