
Partial Class TrailBalanceN1
    Inherits BasePage
    Dim DL As New DLTrialBookReport
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, ds1, DT5 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Try


            Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
            Dim _debit, _credit As Double
            Dim fstartdate As Date = Request.QueryString.Get("FinStartDate")
            Dim fenddate As Date = Request.QueryString.Get("FinEndDate")
            DT5 = DL.BankBookReport(fstartdate, fenddate)
            _debit = DT5.Rows(0)(0)
            _credit = DT5.Rows(0)(1)

            dt1 = DL.TrialBookReport12(fstartdate, fenddate)
            If dt1.Rows.Count > 0 Then
                ReportViewer1.LocalReport.ReportPath = "TrialBalance1.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_TrialBalanceSheet1", dt1)


                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Startdate", fstartdate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Enddate", fenddate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblmsg.Text = "Date is Not valid."
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
