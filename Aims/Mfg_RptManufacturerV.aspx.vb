
Partial Class Mfg_RptManufacturerV
    Inherits System.Web.UI.Page
    Dim ds1 As Data.DataTable
    Dim dt2 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        'Code for to get Manufacturer Details by Niraj 18/01/2013 
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim DL As New DLRptManufacturer
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Mfg As String = Request.QueryString.Get("Manufacturer_ID")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.GetManufacturerDetails(Mfg)
        Try

            If dt1.Rows.Count > 0 Then

                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Mfg_RptManufacturer.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_RptManufacturerDetails", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()

                dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
