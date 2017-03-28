
Partial Class BankBookV
    Inherits BasePage
    Dim DL As New DLBankBookReport
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt, DT5 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim _debit, _credit As Double
        Dim fstartdate As Date = Request.QueryString.Get("FinStartDate")
        Dim fenddate As Date = Request.QueryString.Get("FinEndDate")
        Dim PR As String = Request.QueryString.Get("PR")
        Dim RT As Integer = Request.QueryString.Get("RT")
        DT5 = DL.BankBookReport(fstartdate, fenddate)
        _debit = DT5.Rows(0)(0)
        _credit = DT5.Rows(0)(1)

        dt1 = DL.BankBookReport1(PR, fstartdate, fenddate, RT)
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "rptBankBook.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Acct_BankBook_Qry", dt1)

            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)

            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ParameterCredit", CStr(_credit), False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ParameterDebit", CStr(_debit), False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StartDate", fstartdate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", fenddate, False))
            ReportViewer1.LocalReport.SetParameters(paramList)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblmsg.Text = "No records to display."
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    '=(( (RunningValue(Fields!Amt_Out.Value,sum,"table1_Group2")+Parameters!ParameterDebit.Value)-(RunningValue(Fields!Amt_In.Value,sum,"table1_Group2")+Parameters!ParameterCredit.Value)))
End Class
