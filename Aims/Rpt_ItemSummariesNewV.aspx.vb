
Partial Class Rpt_ItemSummariesNewV
    Inherits BasePage
    Dim ds1 As Data.DataTable
    Dim dt2, dt4 As New DataTable
    Dim DL As New DLAnnualSalaryStatment
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Year As String = Request.QueryString.Get("Year")
        Dim Month As String = Request.QueryString.Get("Month")
        Dim Dept As String = Request.QueryString.Get("Dept")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DLAnnualSalaryStatment.RptitemsummariesNew(Year, Month, Dept)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_ItemSummariesNew1.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_Rpt_ItemsummariesNew", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Year", Year, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Month", Month, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                dt4 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblErrorMsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt4)
        e.DataSources.Add(rptDataSource)
    End Sub
    
End Class
