
Partial Class Rpt_RouteMaterV
    Inherits BasePage

    Dim ds1 As Data.DataTable
    Dim dt2 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        'Code for to get Route Mater details by Nitin 24/08/2012 
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim RouteDB As New RouteDB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = RouteDB.GetRouteRpt()
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RPT_RouteMaster.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_RouteMasterDetails", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()

                dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblErrorMsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class





'Dim RouteDB As New RouteDB
'Dim ds1 As DataTable
'Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
'    Try
'        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
'        Dim Prop As New QureyStringP
'        Dim obj As New SelfDetailsB
'        Dim dt1 As New DataTable

'        QueryStr.GetValue(Page.Request, Prop)
'        dt1 = RouteDB.GetRouteRpt()
'        If dt1.Rows.Count > 0 Then
'            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
'            Me.ReportViewer1.LocalReport.ReportPath = "RPT_RouteMaster.rdlc"
'            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_RouteMasterDetails", dt1)
'            ReportViewer1.LocalReport.DataSources.Clear()
'            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
'            ReportViewer1.LocalReport.Refresh()

'            ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
'            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
'        Else
'            'lblErrorMsg.Text = "No records to display."

'        End If
'    Catch ex As Exception
'        MsgBox(ex.Message.ToString)
'    End Try
'End Sub
'Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
'    Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
'    e.DataSources.Add(rptDataSource)
'End Sub


