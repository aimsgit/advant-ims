
Partial Class RptAssetDetailsReportV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim DL As New DLNewSemesterMarks
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim AT As String = Request.QueryString.Get("AssetType")
        Dim SUP As Integer = Request.QueryString.Get("Supplier")
        Dim MAN As Integer = Request.QueryString.Get("Manufacturer")
        Dim GRN As String = Request.QueryString.Get("Grnno")
        Dim FromDate As String = Request.QueryString.Get("FromDate")
        Dim ToDate As String = Request.QueryString.Get("ToDate")
       
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = AssetDetailsDB.GetAssetDetailsReport(AT, SUP, MAN, GRN, FromDate, ToDate)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptAssetDetailsReport.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_AssetDetailsReport", dt1)

                'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("id", ID, False))
                'ReportViewer1.LocalReport.SetParameters(paramList)
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else

                lblErrorMsg.Text = "No Records to Display."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again."
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
