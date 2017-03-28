
Partial Class RptAttendanceDashV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource


    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init


        Dim AcademicYear As Integer = Request.QueryString.Get("AcademicYear")
        Dim Course As Integer = Request.QueryString.Get("Course")
        Dim course2 As String = Request.QueryString.Get("course2")
        Dim percentage As Integer = Request.QueryString.Get("percentage")
        Dim Category As Integer = Request.QueryString.Get("Category")
        Dim Category2 As String = Request.QueryString.Get("Category2")
        Dim percentage2 As String = Request.QueryString.Get("percentage2")
        Dim AcademicYear2 As String = Request.QueryString.Get("AcademicYear2")
        Dim caste As Integer = Request.QueryString.Get("caste")
        Dim caste2 As String = Request.QueryString.Get("caste2")
        Dim R As Integer = Request.QueryString.Get("R")
        QueryStr.GetValue(Page.Request, Prop)

        If R = 2 Then




            dt1 = DLPrinicipalDashBoard.GetWorlFlowReport(AcademicYear, Course, percentage, Category, caste)

            Try
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "RptPrincipalDasAtt.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_AttenDashBoard", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("course2", course2, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("percentage2", percentage2, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Category2", Category2, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicYear2", AcademicYear2, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("caste2", caste2, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = "No records to display."
                End If
            Catch ex As Exception
                lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
            End Try
        Else
            dt1 = DLPrinicipalDashBoard.GetWorlFlowReportSumm(AcademicYear, Course, percentage, Category, caste)

            Try
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "RptAttenDansh.rdlc"
                    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_AttenDashBoardSumm", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("course2", course2, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("percentage2", percentage2, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Category2", Category2, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AcademicYear2", AcademicYear2, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("caste2", caste2, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                    ReportViewer1.LocalReport.Refresh()

                    dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = "No records to display."
                End If
            Catch ex As Exception
                lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
            End Try
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
