
Partial Class RptPrincipalDashforMarksSummaryV
    Inherits BasePage
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, ds1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim DL As New DLPrinicipalDashBoard
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim AcademicYear, Course, Category, AssessmentType, FromPer, ToPer As Integer
        Dim BranchName As String

        AcademicYear = Request.QueryString.Get("AcademicYear")
        Course = Request.QueryString.Get("Course")
        Category = Request.QueryString.Get("Category")
        AssessmentType = Request.QueryString.Get("AssessmentType")
        FromPer = Request.QueryString.Get("M_FromPer")
        ToPer = Request.QueryString.Get("M_ToPer")
        BranchName = Session("BranchName")



        Dim dt As New Data.DataTable
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.RptMarksSummaryReport(AcademicYear, Course, Category, AssessmentType, FromPer, ToPer)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_MarksSummaryReportV.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_MarksSummaryReportDB", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
