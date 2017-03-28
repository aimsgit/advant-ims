
Partial Class Rpt_SaleInvoiceV1


    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLClientContractMaster
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Branch_Code As String = Request.QueryString.Get("Branch_Code")
        Dim SetUp As String = Request.QueryString.Get("setupcharge")
        Dim ID As String = Request.QueryString.Get(("ID"))
        Dim FromDate As String = Request.QueryString.Get(("FromDate"))
        Dim ToDate As String = Request.QueryString.Get(("ToDate"))
        Dim Yearfrom As String = Request.QueryString.Get(("Yearfrom"))
        Dim Yearto As String = Request.QueryString.Get(("YearTo"))
        Dim InvoiceNo As String = Request.QueryString.Get(("InvoiceNo"))
        Dim SetUpFlag As String = Request.QueryString.Get(("SetUp"))
        Dim Invdate As Date = Request.QueryString.Get(("Invdate"))
        Dim ClientId As String = Request.QueryString.Get(("ClientId"))
        QueryStr.GetValue(Page.Request, Prop)

        dt1 = DL.GetSaleInvoice(Branch_Code, SetUp, ID, FromDate, ToDate, Yearfrom, Yearto, InvoiceNo, SetUpFlag, Invdate, ClientId)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptTaxinvoice6.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_GetSaleinvoice", dt1)
                'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("InvoiceNo", InvoiceNo, False))
                'ReportViewer1.LocalReport.SetParameters(paramList)
                'ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class



