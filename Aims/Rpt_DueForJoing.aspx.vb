
Partial Class Rpt_DueForJoing
    Inherits BasePage
    Dim ds1 As Data.DataTable
    Dim dt2, dt3 As New DataTable
    Dim DL As New DLDueJoining
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Months As Integer = Request.QueryString.Get("Months")
        Dim Year As Integer = Request.QueryString.Get("Year")
        Dim Based As String = Request.QueryString.Get("Based")
        Dim Month As String = Request.QueryString.Get("Month")
        Dim Criteria As String=Request.QueryString.Get("Criteria")


        Dim Based1 As String = Request.QueryString.Get("Based1")
        QueryStr.GetValue(Page.Request, Prop)


        Try
            If Based = "A" Then


                dt1 = DLDueJoining.GetDueJoining(Months, Year, Based)
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "Rpt_DueJoining.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_DueForJoining", dt1)

                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Month", Month, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Year", Year, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()
                    dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblErrorMsg.Text = "No records to display."
                End If
            ElseIf Based = "B" Then


                dt1 = DLDueJoining.GetDueJoining(Months, Year, Based)
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "Rpt_DueRevised.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_DueForJoining", dt1)

                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Month", Month, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Year", Year, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)

                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()
                    dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblErrorMsg.Text = "No records to display."
                End If
            ElseIf Based = "C" Then


                dt1 = DLDueJoining.GetDueJoining(Months, Year, Based)
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "Rpt_DueRetire.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_DueForJoining", dt1)

                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Month", Month, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Year", Year, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)


                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()
                    dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblErrorMsg.Text = "No records to display."
                End If


            Else

                dt3 = DLDueJoining.GetEmpEligibilie(Months, Year, Based, Criteria)
                If dt3.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "RptEmpEligibility.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetEmpEligibile", dt3)

                    Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Month", Month, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Year", Year, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Criteria", Criteria, False))
                    paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Based1", Based1, False))
                    ReportViewer1.LocalReport.SetParameters(paramList)


                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()
                    dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

                Else

                    lblErrorMsg.Text = "No records to display."
                End If
            End If

        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try


    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
