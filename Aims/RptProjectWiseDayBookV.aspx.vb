
Partial Class RptProjectWiseDayBookV
    Inherits BasePage
    Dim dtS, dt, dt1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim obj As New SelfDetailsB
        Dim DL As New DayBookDB
        Dim Prop As New QureyStringP
        QueryStr.GetValue(Page.Request, Prop)
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim PR As String = Request.QueryString.Get("PR")
        Dim fstartdate As Date = Request.QueryString.Get(("FinStartDate"))
        Dim fenddate As Date = Request.QueryString.Get(("FinEndDate"))
        QueryStr.GetValue(Page.Request, Prop)
        Dim dt4 As New DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        dt1 = DL.ProjectWiseDayBookreport(PR, fstartdate, fenddate)
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "RptProjectWiseDaybook.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Acct_DayBook_RptProjectWise", dt1)

            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)


            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Startdate", fstartdate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Enddate", fenddate, False))
            ReportViewer1.LocalReport.SetParameters(paramList)


            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            lblErrorMsg.Text = "No Records Found."

        End If

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub


End Class
