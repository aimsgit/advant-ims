
Partial Class rptProjectMasterV
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer2.Init
        Dim status As Integer = CInt(Request.QueryString.Get("Ownership"))
        Dim dt1 As New DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim pro As New ProjectManajer
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource

        QueryStr.GetValue(Page.Request, Prop)
        Me.ReportViewer2.LocalReport.ReportPath = "rptProjectMaster.rdlc"
        dt1 = pro.GetProjectMaster(Prop.insID, Prop.brnID)
        Me.ReportViewer2.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        'Me.ReportViewer1.LocalReport.ReportPath = "rptProjectMasterV.rdlc"
        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_ProjectMaster", dt1)


        ReportViewer2.LocalReport.DataSources.Clear()
        Me.ReportViewer2.LocalReport.DataSources.Add(dt)
        ReportViewer2.LocalReport.Refresh()


        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Prop.userID, Prop.insID)
        AddHandler ReportViewer2.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
