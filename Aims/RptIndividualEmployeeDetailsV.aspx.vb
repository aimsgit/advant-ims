
Partial Class RptIndividualEmployeeDetailsV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLRptIndividualEmployeeDetails
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BN As String = Request.QueryString.Get("BN")
        Dim Dept As String = Request.QueryString.Get("Dept")
        Dim ET As String = Request.QueryString.Get("EmpType")
        Dim EC As String = Request.QueryString.Get("EmpCat")
        Dim EN As String = Request.QueryString.Get("EmpName")
        Dim DE As Integer = Request.QueryString.Get("Designation")
        Dim QL As String = Request.QueryString.Get("Qualification")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.GetIndividualEmp(BN, Dept, ET, EC, EN, DE, QL)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptIndividualEmployeeDetails.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_IndividualEmployeeDetails", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
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