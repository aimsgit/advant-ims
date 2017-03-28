Partial Class Rpt_BestPerformanceV
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New DL_RptPerformance

    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim batch As Integer = Request.QueryString.Get("batch")
        Dim subject As Integer = Request.QueryString.Get("subject")
        Dim Assmt As Integer = Request.QueryString.Get("Assmt")
        Dim fromdate As String = Request.QueryString.Get("fromdate")
        Dim todate As String = Request.QueryString.Get("todate")
        Dim Rbid As String = Request.QueryString.Get("Rbid")
        Dim Rbid2 As String = Request.QueryString.Get("Rbid2")
        Dim Batchname As String = Request.QueryString.Get("Batchname")
        Dim subjectname As String = Request.QueryString.Get("subjectname")
        Dim Assmtname As String = Request.QueryString.Get("Assmtname")
        Dim batch2 As String = Request.QueryString.Get("batch2")
        QueryStr.GetValue(Page.Request, Prop)

        If Rbid = "S" And Rbid2 = "A" Then
            dt1 = DL_RptPerformance.StudentPerformanceAtt(batch, subject, Assmt, fromdate, todate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Rpt_BestPerformance.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_StudentPerformAttndModi", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", todate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("batch2", batch2, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If

        End If

        If Rbid = "S" And Rbid2 = "M" Then
            dt1 = DL_RptPerformance.StudentPerformanceMarks(batch, subject, Assmt, fromdate, todate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Rpt_BestPerformanceMarks.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_StudentPerformMarksModi", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", todate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("batch2", batch2, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If

        End If
     
        If Rbid = "F" And Rbid2 = "M" Then
            dt1 = DL_RptPerformance.Bestfacultyonmarks(batch, subject, Assmt, fromdate, todate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Rpt_BestFacultyonAssesMarks.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RptTopFacultywithMarks", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", todate, False))


                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batchname", Batchname, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("subjectname", subjectname, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assmtname", Assmtname, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If

        End If

        If Rbid = "F" And Rbid2 = "A" Then
            dt1 = DL_RptPerformance.BestfacultyonAttend(batch, subject, Assmt, fromdate, todate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Rpt_BestFacultyOnStdAttend.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RptTopFaculty", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", todate, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception

                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If
        End If

        If Rbid = "SB" And Rbid2 = "A" Then
            dt1 = DL_RptPerformance.GetBestSubjAtten(batch, fromdate, todate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "RptBestSubjAtten.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_BestSubject", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", todate, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If

        End If

        If Rbid = "SB" And Rbid2 = "M" Then
            dt1 = DL_RptPerformance.GetBestSubjMarks(batch, fromdate, todate, Assmt)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "RptBestSubjMarks.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_BestSubjectMarks", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", todate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Assmtname", Assmtname, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batchname", Batchname, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If

        End If

        If Rbid = "P" And Rbid2 = "A" Then
            dt1 = DL_RptPerformance.GetBestProgramOnAttend(fromdate, todate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Rpt_BestProgramOnAttend.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BestProgramWithAttend", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", todate, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If

        End If
        If Rbid = "P" And Rbid2 = "M" Then
            dt1 = DL_RptPerformance.GetBestProgramOnMarks(Assmt, fromdate, todate)

            If dt1.Rows.Count > 0 Then
                Try
                    ReportViewer1.LocalReport.ReportPath = "Rpt_BestProgramOnMarks.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BestProgramWithMarks", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", fromdate, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", todate, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If

        End If


    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
