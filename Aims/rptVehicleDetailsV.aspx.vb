
Partial Class rptVehicleDetailsV
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        'Dim status As Integer = CInt(Request.QueryString.Get("Ownership"))
        'Dim dt1 As New DataTable
        'Dim Prop As New QureyStringP
        'Dim obj As New SelfDetailsB
        'Dim veh As New VehicleManager
        'Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource


        'QueryStr.GetValue(Page.Request, Prop)

        'If status = 1 Then
        '    Me.ReportViewer1.LocalReport.ReportPath = "rptVehicle_Own.rdlc"
        'Else
        '    Me.ReportViewer1.LocalReport.ReportPath = "rptVehicleDetails.rdlc"
        'End If

        'dt1 = veh.GetVehicleDetailsRpt(Prop.insID, Prop.brnID, status)
        'Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
        ''Me.ReportViewer1.LocalReport.ReportPath = "rptVehicleDetails.rdlc"
        'dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_View_VehicleDetails1", dt1)


        'ReportViewer1.LocalReport.DataSources.Clear()
        'Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        'ReportViewer1.LocalReport.Refresh()


        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Prop.userID, Prop.insID)
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        '-----------Kusum
        Dim ds1 As New DataTable
        Dim dt1 As New DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dl As New GlobalDataSetTableAdapters.FeeDetailsDB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim status As Integer = CInt(Request.QueryString.Get("Ownership"))
        Dim veh As New VehicleManager
        QueryStr.GetValue(Page.Request, Prop)
        If status = 1 Then
            Me.ReportViewer1.LocalReport.ReportPath = "rptVehicle_Own.rdlc"
        Else
            Me.ReportViewer1.LocalReport.ReportPath = "rptVehicleDetails.rdlc"
        End If

        QueryStr.GetValue(Page.Request, Prop)
        'dt1 = veh.GetVehicleDetailsRpt(Prop.insID, Prop.brnID, status)
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            'Me.ReportViewer1.LocalReport.ReportPath = "rptVehicleDetails.rdlc"
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_View_VehicleDetails", dt1)
            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()
            'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            Me.Label1.Text = "No records to display"
            Me.Label1.BackColor = Drawing.Color.Red
            Me.Label1.ForeColor = Drawing.Color.White
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
