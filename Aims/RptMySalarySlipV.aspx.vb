
Partial Class RptMySalarySlipV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2, dt3 As New DataTable
    Dim Salary As String
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim BL As New BLPayroll
        Dim EL As New EntPayroll
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        EL.Month = Request.QueryString.Get("Month")
        EL.Year = Request.QueryString.Get("Year")
        dt3 = DataMonthlySalary.Salaryslip()
        If dt3.Rows.Count > 0 Then

            Salary = dt3.Rows(0).Item("Config_Value").ToString
        Else
            Salary = "N"
        End If
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = BL.RptMySalSlipNew(EL)
        dt2 = BL.RptMySalSlipNew2(EL)
        If Salary = "Y" Then

            Try
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "RptMySalarySlipNew1.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_MySalarySlip_New", dt1)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = "No records to display."
                End If
            Catch ex As Exception
                lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
            End Try
        Else
            Try
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "RptMySalarySlipNew.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_MySalarySlip_New", dt1)
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblmsg.Text = "No records to display."
                End If
            Catch ex As Exception
                lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
            End Try
        End If
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
            Case "ReportSalarySlipContri1"
                Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_MySalarySlip_New", dt2)
                e.DataSources.Add(rptDataSource)
        End Select
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    
    End Sub
End Class
