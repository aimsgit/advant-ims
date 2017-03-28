
Partial Class RptPlacementDetailV
    Inherits BasePage
    Dim dt1, ds1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Bl As New BankManager
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Batch As Integer = Request.QueryString.Get("Batch")
        Dim Type As Integer = Request.QueryString.Get("Type")
        Try
            If Type = 0 Then

                QueryStr.GetValue(Page.Request, Prop)
                dt1 = PlacementDB.RptPlacementDetails(Batch, Type)

                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "RptPlacementDetail.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_New_RptPlacementDetails", dt1)
                    'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", ReceiveFrom, False))
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ReceiveTo, False))
                    'ReportViewer1.LocalReport.SetParameters(paramList)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = "No Records to Display."
                End If
            Else
                QueryStr.GetValue(Page.Request, Prop)
                dt1 = PlacementDB.RptTrainingDetails(Batch, Type)

                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "RptTrainingDeatils.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_New_RptTrainingDetails", dt1)
                    'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", ReceiveFrom, False))
                    'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ReceiveTo, False))
                    'ReportViewer1.LocalReport.SetParameters(paramList)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = "No Records to Display."
                End If
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
