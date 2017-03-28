
Partial Class RptSemAssessmtBySubjectV
    Inherits System.Web.UI.Page
    Dim DL As New DLRptSemAssessmtBySubject
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt, dt2, ParentDt, ParentDt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Batch, SemesterId As String
        Dim SubId, ReportType, id, StudId, AsstId, id1 As Integer
        Dim FromDate, ToDate As Date
        Dim RepType As String

        Try
          
            Batch = Request.QueryString.Get("Batch")
            SemesterId = Request.QueryString.Get("SemesterId")
            StudId = Request.QueryString.Get("StudId")
            SubId = Request.QueryString.Get("SubId")
            AsstId = Request.QueryString.Get("AsstId")
            ReportType = Request.QueryString.Get("ReportType")
            id = Request.QueryString.Get("id")
            id1 = Request.QueryString.Get("id1")
            FromDate = Request.QueryString.Get("FromDate")
            ToDate = Request.QueryString.Get("ToDate")
            RepType = Request.QueryString.Get("RepType")
            QueryStr.GetValue(Page.Request, Prop)
            dt1 = DLRptSemAssessmtBySubject.GetSemAssessmtRpt(SubId, AsstId, id, Batch, SemesterId, StudId)
            'To display Marks

            If ReportType = 0 Then


                Try
                    If dt1.Rows.Count > 0 Then
                        ReportViewer1.LocalReport.ReportPath = "RptSemAssessmtBySubject.rdlc"
                        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_NewSemAssessmt", dt1)
                        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("id", id, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RepType", RepType, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
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
                        LblError.Text = "No records to display."
                    End If
                Catch ex As Exception
                    LblError.Text = "Error While loading Report, Enter all Mandatory fields and try again."
                End Try
                ' To display Percentage
            ElseIf ReportType = 1 Then

                Try
                    If dt1.Rows.Count > 0 Then
                        ReportViewer1.LocalReport.ReportPath = "RptSemAssessmtBySubject1.rdlc"
                        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_NewSemAssessmt", dt1)
                        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("id", id, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RepType", RepType, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))

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
                        LblError.Text = "No records to display."
                    End If
                Catch ex As Exception
                    LblError.Text = "Error While loading Report, Enter all Mandatory fields and try again."
                End Try
                'To Display Grade
            ElseIf ReportType = 2 Then

                Try
                    If dt1.Rows.Count > 0 Then
                        ReportViewer1.LocalReport.ReportPath = "RptSemAssessmtBySubject2.rdlc"
                        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_NewSemAssessmt", dt1)
                        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                        'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("id", id, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RepType", RepType, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate, False))
                        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))

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
                        LblError.Text = "No records to display."
                    End If
                Catch ex As Exception
                    LblError.Text = "Error While loading Report, Enter all Mandatory fields and try again."
                End Try
            End If
        Catch ex As Exception
            LblError.Text = "No records to display."
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    
End Class
