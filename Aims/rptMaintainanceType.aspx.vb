
Partial Class rptMaintainanceType
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Type As Int16 = CInt(Request.QueryString.Get("MaintenanceType"))
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt1 As New Data.DataTable

        Dim ins As Integer = CInt(Request.QueryString(1))
        Dim brn As Integer = CInt(Request.QueryString(0))

        If Type = 5 Then
            Me.ReportViewer1.LocalReport.ReportPath = "rptNeedleReport.rdlc"
            dt1 = MachineMaintenanceDB.GetRPT_MachineMaintenence(ins, brn, Type)
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_DispGV_Maintenance", dt1)
        ElseIf Type = 4 Or Type = 3 Then
            Me.ReportViewer1.LocalReport.ReportPath = "rptBreakDownLogReport.rdlc"
            dt1 = MachineMaintenanceDB.DispGV_MaintenanceRPT(ins, brn, Type)
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_DispGV_Maintenance", dt1)
        Else
            Me.ReportViewer1.LocalReport.ReportPath = "rptMaintenance.rdlc"
            dt1 = MachineMaintenanceDB.DispGV_MaintenanceRPT(ins, brn, Type)
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_DispGV_Maintenance", dt1)
        End If
        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        ReportViewer1.LocalReport.Refresh()

        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
