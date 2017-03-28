
Partial Class RptPrincipalDashboardforMarksDetailedV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim DL As New DLPrinicipalDashBoard
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim AcademicYear, Course, Category, FromPer, ToPer, AssessmentType, Caste, Sem As Integer


        AcademicYear = Request.QueryString.Get("AcademicYear")
        Course = Request.QueryString.Get("Course")
        Category = Request.QueryString.Get("Category")
        AssessmentType = Request.QueryString.Get("AssessmentType")
        FromPer = Request.QueryString.Get("M_FromPer")
        ToPer = Request.QueryString.Get("M_ToPer")
        Sem = Request.QueryString.Get("Sem")
        Dim StudentCategory As String = Request.QueryString.Get("StudentCategory")
        Caste = Request.QueryString.Get("M_Caste")
        Dim RaceCaste As String = Request.QueryString.Get("RaceCaste")
        Dim dt As New Data.DataTable
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.GetMArksDetails(AcademicYear, Course, Category, FromPer, ToPer, AssessmentType, Sem, Caste)


        If dt1.Rows.Count > 0 Then
            Try
                ReportViewer1.LocalReport.ReportPath = "RptPrinDashMarks.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_PrinicipalDashMarksDetails", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StudentCategory", StudentCategory, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RaceCaste", RaceCaste, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                'ReportViewer1.LocalReport.DataSources.Clear(k)
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Catch ex As Exception
                lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
            End Try
        Else
            lblmsg.Text = "No Records to Display."
        End If



    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
