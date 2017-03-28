
Partial Class RptAssetAllocationV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLRptAssetAllocation
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim AssetType As String = Request.QueryString.Get("AssetType")
        Dim AssetName As String = Request.QueryString.Get("AssetName")
        Dim fromdate As String = Request.QueryString.Get("fromdate")
        Dim todate As String = Request.QueryString.Get("todate")
        Dim EmpDept As Integer = Request.QueryString.Get("EmpDept")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.GetAssetAllocation(AssetType, AssetName, fromdate, todate, EmpDept)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                If EmpDept = 0 Then
                    Me.ReportViewer1.LocalReport.ReportPath = "RptAssetAllocation.rdlc"
                Else
                    Me.ReportViewer1.LocalReport.ReportPath = "RptAssetAllcatn.rdlc"
                End If

                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_AssetAllocation", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", fromdate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", todate, False))

                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No Records to Display."
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
