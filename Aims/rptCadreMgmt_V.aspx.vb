
Partial Class rptCadreMgmt_V
    Inherits BasePage
    Dim dt1, dt As New DataTable
    Dim BL As New CadreMgmtBL

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim University As String = Request.QueryString.Get("University")
        Dim Program As Integer = Request.QueryString.Get("Program")
        Dim Project As Integer = Request.QueryString.Get("Project")
        dt1 = BL.CadreMgmtRpt(University, Program, Project)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "rptCadreMgmt.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetCadreMgmtGrid", dt1)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = BL.RPT_GetDetailsByID(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblErrorMsg.Text = "No Records to display."
        End If
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
