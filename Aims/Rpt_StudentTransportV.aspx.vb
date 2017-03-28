
Partial Class Rpt_StudentTransportV
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim dt2 As New DataTable
    Dim dt3 As New DataTable
    Dim dt4 As New DataTable
    Dim DS As New DataSet

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLTransportAndroid
        Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim FromDate As Date = Request.QueryString.Get("FromDate")
        Dim ToDate As Date = Request.QueryString.Get("ToDate")
        Dim Route As String = Request.QueryString.Get("Route")
        Dim Student As String = Request.QueryString.Get("Student")

        QueryStr.GetValue(Page.Request, Prop)
        'dt2 = DLClientContractMaster.ChkDuplicateData(InvoiceNo)
        'If dt2.Rows.Count > 0 Then
        '    lblErrorMsg.Text = "Data is already generated."
        'Else
        dt1 = DLTransportAndroid.GetStudentTransport(Route, Student, FromDate, ToDate)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_StudentTransport.rdlc"
                dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_Rptstudenttransport", dt1)
                Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
        'End If


    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
