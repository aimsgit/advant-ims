
Partial Class RptPrincipledashboardV
    Inherits System.Web.UI.Page
    Dim dt As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm1 As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim dm2 As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim dm3 As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim dm4 As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DL As New DLPrincipalDashboard
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        Dim dt3 As New DataTable
        Dim dt4 As New DataTable
        Dim AID As Integer = Request.QueryString.Get("AID")
     

        dt1 = DL.GetPrincipleDashboardRpt(AID)
        dt2 = DL.GetTotEmpCount()
        dt3 = DL.GetBranchName(AID)
        dt4 = DL.GetStudcategory(AID)

        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "Rpt_PrinipleDashboard.rdlc"
            dm1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_PrincipalDashboard", dt1)
            dm2 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_TotEmpcount", dt2)
            dm3 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_GetBranchName", dt3)
            dm4 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_Getcategorydetails", dt4)
            ReportViewer1.LocalReport.EnableExternalImages = True

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm1)
            Me.ReportViewer1.LocalReport.DataSources.Add(dm2)
            Me.ReportViewer1.LocalReport.DataSources.Add(dm3)
            Me.ReportViewer1.LocalReport.DataSources.Add(dm4)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            lblmsg.Text = ""
        Else
            lblmsg.Text = "No Records to Display."

        End If

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
