﻿
Partial Class Mfg_Rpt_Servicetax
    Inherits System.Web.UI.Page
    Dim Prop As New QureyStringP
    Dim ds1 As DataTable
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New DLClientContractMaster
    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim Fromyear As Integer = Request.QueryString.Get("Fromyear")
        Dim Toyear As Integer = Request.QueryString.Get("Toyear")
        Dim fromMonth As String = Request.QueryString.Get("fromMonth")
        Dim tomonth As String = Request.QueryString.Get("tomonth")

        Try


            QueryStr.GetValue(Page.Request, Prop)


            dt1 = DL.GetServiceTaxReport(Fromyear, Toyear, fromMonth, tomonth)
            If dt1.Rows.Count > 0 Then
                Try

                    ReportViewer1.LocalReport.ReportPath = "Frm_Rpt_ServiceTaxReport.rdlc"
                    dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_taxServiceRpt", dt1)
                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Fromdate", FromDate, False))
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Todate", Todate, False))
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("product", Product, False))
                    Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    lblErrorMsg.Text = ""
                Catch ex As Exception
                    lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
                End Try
            Else
                lblErrorMsg.Text = "No Records to Display."
            End If

        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try

        'lblErrorMsg.Text = "No Records to Display."

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
