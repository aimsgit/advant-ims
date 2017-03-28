
Partial Class RptBranchMaster
    Inherits BasePage
    Dim bll As New BranchDB
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        dt1 = bll.RptFillBranchCenter()
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptBranchMaster.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_BranchMaster", dt1)
            'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssetTypeCode", AssetTypeCode, False))
            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssetTypeDesc", AssetTypeDesc, False))

            'ReportViewer1.LocalReport.SetParameters(paramList)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            lblmsg.Text = "No Records to display"
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub


End Class

