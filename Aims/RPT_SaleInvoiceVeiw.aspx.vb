
Partial Class RPT_SaleInvoiceVeiw
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLClientContractMaster
        Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Branch_Code As String = Request.QueryString.Get("BranchCode")
        Dim InvoiceNo As String = Request.QueryString.Get(("InvoiceNo"))
        Dim Fromdate As String = Request.QueryString.Get(("Fromdate"))
        Dim ToDate As String = Request.QueryString.Get(("ToDate"))
        Dim Yearfrom As String = Request.QueryString.Get(("Yearfrom"))
        Dim YearTo As String = Request.QueryString.Get(("YearTo"))
        Dim Chkid As Integer = Request.QueryString.Get(("Chkid"))
        Dim SetUp As String = Request.QueryString.Get(("SetUp"))
        Dim ClientId As String = Request.QueryString.Get(("ClientId"))
        QueryStr.GetValue(Page.Request, Prop)
        If Chkid = 0 Then


            dt1 = DL.GetInvoiceData(Branch_Code, InvoiceNo, ClientId, Fromdate, ToDate, Yearfrom, YearTo)
            If dt1.Rows.Count > 0 Then
                Try
                    If dt1.Rows(0).Item("SetUp_Flag") = "Y" Then
                        ReportViewer1.LocalReport.ReportPath = "RptinvoiceView3.rdlc"
                        dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_GetinvoiceData", dt1)

                        Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                        ReportViewer1.LocalReport.Refresh()
                        ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                        lblErrorMsg.Text = ""
                    Else
                        ReportViewer1.LocalReport.ReportPath = "RptinvoiceView3.rdlc"
                        dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_GetinvoiceData", dt1)

                        Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                        ReportViewer1.LocalReport.Refresh()
                        ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                        lblErrorMsg.Text = ""
                    End If
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If
        Else
            dt1 = DL.GetInvoiceData(Branch_Code, InvoiceNo, ClientId, Fromdate, ToDate, Yearfrom, YearTo)
            If dt1.Rows.Count > 0 Then
                Try
                    If dt1.Rows(0).Item("SetUp_Flag") = "Y" Then
                        ReportViewer1.LocalReport.ReportPath = "RptinvoiceView3.rdlc"
                        dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_GetinvoiceData", dt1)

                        Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                        ReportViewer1.LocalReport.Refresh()
                        ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                        lblErrorMsg.Text = ""
                    Else
                        ReportViewer1.LocalReport.ReportPath = "RptinvoiceView3.rdlc"
                        dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_GetinvoiceData", dt1)

                        Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                        ReportViewer1.LocalReport.Refresh()
                        ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                        lblErrorMsg.Text = ""
                    End If
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If
        End If
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
