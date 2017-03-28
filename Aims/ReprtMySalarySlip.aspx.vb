
Partial Class ReprtMySalarySlip
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim BL As New BLPayroll
        Dim EL As New EntPayroll
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        EL.Month = Request.QueryString.Get("Month")
        EL.Year = Request.QueryString.Get("Year")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = BL.RptMySalSlipNew1(EL)
        dt2 = BL.RptMySalSlipNew2(EL)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "ReportMySalarySlipNew.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_MySalarySlip_New", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and  try again. "
        End Try

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)

        Dim rpt = e.ReportPath

        Select Case rpt
            Case "ReportSalarySlipContri"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_MySalarySlip_New", dt2)
                e.DataSources.Add(rptDataSource)
            Case "MasterHeading"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
                e.DataSources.Add(rptDataSource)
        End Select
    End Sub

End Class
