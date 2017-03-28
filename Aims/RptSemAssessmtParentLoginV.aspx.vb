﻿
Partial Class RptSemAssessmtParentLoginV
    Inherits BasePage
    Dim Bl As New StdAttdance
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt, dt2, ParentDt, ParentDt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim Cid, BId, SId, SubId, StudId, ReportType, id, AsstId As Integer
        Dim batchName As String

        Try
            'Aid = Request.QueryString.Get("Aid")
            Cid = Request.QueryString.Get("Cid")
            BId = Request.QueryString.Get("BId")
            batchName = Request.QueryString.Get("batchName")
            SId = Request.QueryString.Get("SId")
            SubId = Request.QueryString.Get("SubId")
            AsstId = Request.QueryString.Get("AsstId")
            StudId = Request.QueryString.Get("StudId")
            ReportType = Request.QueryString.Get("ReportType")
            id = Request.QueryString.Get("id")

            QueryStr.GetValue(Page.Request, Prop)
            dt1 = Bl.GetSemAssessmtRpt(Cid, BId, SId, SubId, StudId, ReportType, AsstId, id)
            'To display Marks

            If id = 0 Then
                Dim LanguageID As Integer
                Dim FormName As String
                ''Multilingual Conversion  By: Niraj on 24 Jan 2014
                If Session("LanguageID") = "" Then
                    LanguageID = 1
                Else
                    LanguageID = Session("LanguageID")
                End If
                FormName = "SemAssessmentMarksR"
                dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
                Dim SemAssessmentMarksR, BatchN, CourseN, SemN, StdCode, RepType As String

                SemAssessmentMarksR = dt2.Rows(0).Item("Default_Text").ToString()
                CourseN = dt2.Rows(1).Item("Default_Text").ToString()
                BatchN = dt2.Rows(2).Item("Default_Text").ToString()
                SemN = dt2.Rows(3).Item("Default_Text").ToString()
                RepType = dt2.Rows(4).Item("Default_Text").ToString()
                StdCode = dt2.Rows(5).Item("Default_Text").ToString()

                Try
                    If dt1.Rows.Count > 0 Then
                        ReportViewer1.LocalReport.ReportPath = "RptSemAssessmt.rdlc"
                        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SemAssessmt", dt1)
                        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemAssessmentMarksR", SemAssessmentMarksR, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseN", CourseN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemN", SemN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RepType", RepType, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("batchName", batchName, False))

                        ReportViewer1.LocalReport.SetParameters(paramList)
                        'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", id, False))
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", id, False))

                        'ReportViewer1.LocalReport.SetParameters(paramList)

                        ReportViewer1.LocalReport.DataSources.Clear()
                        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                        ReportViewer1.LocalReport.Refresh()
                        dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    Else
                        LblError.Text = "No Records to display."
                    End If
                Catch ex As Exception
                    LblError.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
                ' To display Percentage
            ElseIf id = 1 Then
                Dim LanguageID As Integer
                Dim FormName As String
                ''Multilingual Conversion  By: Niraj on 24 Jan 2014
                If Session("LanguageID") = "" Then
                    LanguageID = 1
                Else
                    LanguageID = Session("LanguageID")
                End If
                FormName = "SemAssessmentMarksR1"
                dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
                Dim SemAssessmentMarksR, BatchN, CourseN, SemN, StdCode, RepType As String

                SemAssessmentMarksR = dt2.Rows(0).Item("Default_Text").ToString()
                CourseN = dt2.Rows(1).Item("Default_Text").ToString()
                BatchN = dt2.Rows(2).Item("Default_Text").ToString()
                SemN = dt2.Rows(3).Item("Default_Text").ToString()
                RepType = dt2.Rows(4).Item("Default_Text").ToString()
                StdCode = dt2.Rows(5).Item("Default_Text").ToString()
                Try
                    If dt1.Rows.Count > 0 Then
                        ReportViewer1.LocalReport.ReportPath = "RptSemAssessmt1.rdlc"
                        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SemAssessmt", dt1)
                        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemAssessmentMarksR", SemAssessmentMarksR, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseN", CourseN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemN", SemN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RepType", RepType, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))

                        ReportViewer1.LocalReport.SetParameters(paramList)
                        'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", id, False))
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", id, False))

                        'ReportViewer1.LocalReport.SetParameters(paramList)
                        ReportViewer1.LocalReport.DataSources.Clear()
                        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                        ReportViewer1.LocalReport.Refresh()
                        dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    Else
                        LblError.Text = "No Records to display."
                    End If
                Catch ex As Exception
                    LblError.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
                'To Display Grade
            ElseIf id = 2 Then
                Dim LanguageID As Integer
                Dim FormName As String
                ''Multilingual Conversion  By: Niraj on 24 Jan 2014
                If Session("LanguageID") = "" Then
                    LanguageID = 1
                Else
                    LanguageID = Session("LanguageID")
                End If
                FormName = "SemAssessmentMarksR2"
                dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
                Dim SemAssessmentMarksR, BatchN, CourseN, SemN, StdCode, RepType As String

                SemAssessmentMarksR = dt2.Rows(0).Item("Default_Text").ToString()
                CourseN = dt2.Rows(1).Item("Default_Text").ToString()
                BatchN = dt2.Rows(2).Item("Default_Text").ToString()
                SemN = dt2.Rows(3).Item("Default_Text").ToString()
                RepType = dt2.Rows(4).Item("Default_Text").ToString()
                StdCode = dt2.Rows(5).Item("Default_Text").ToString()
                Try
                    If dt1.Rows.Count > 0 Then
                        ReportViewer1.LocalReport.ReportPath = "RptSemAssessmt2.rdlc"
                        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SemAssessmt", dt1)
                        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemAssessmentMarksR", SemAssessmentMarksR, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CourseN", CourseN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemN", SemN, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RepType", RepType, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))

                        ReportViewer1.LocalReport.SetParameters(paramList)

                        'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", id, False))
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", id, False))

                        'ReportViewer1.LocalReport.SetParameters(paramList)
                        ReportViewer1.LocalReport.DataSources.Clear()
                        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                        ReportViewer1.LocalReport.Refresh()
                        dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    Else
                        LblError.Text = "No Records to display."
                    End If
                Catch ex As Exception
                    LblError.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            End If
        Catch ex As Exception
            LblError.Text = "No Records to Display."
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub


End Class
