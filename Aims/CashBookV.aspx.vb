
Partial Class CashBookV
    Inherits BasePage
    Dim DL As New DLCashBookReport
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt, DT5 As New DataTable

    Protected Sub RptCashBook_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles RptCashBook.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim _debit, _credit As Double
        Dim fstartdate As Date = Request.QueryString.Get("FinStartDate")
        Dim fenddate As Date = Request.QueryString.Get("FinEndDate")
        Dim PR As String = Request.QueryString.Get("PR")
        Dim RT As Integer = Request.QueryString.Get("RT")
        DT5 = DL.CashBookReport(fstartdate, fenddate)
        _debit = DT5.Rows(0)(0)
        _credit = DT5.Rows(0)(1)

        dt1 = DL.CashBookReport1(PR, fstartdate, fenddate, RT)
        If dt1.Rows.Count > 0 Then
            Me.RptCashBook.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.RptCashBook.LocalReport.ReportPath = "rptCashBook.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Acct_CashBook_Qry", dt1)

            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ParameterCredit", CStr(_credit), False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ParameterDebit", CStr(_debit), False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StartDate", fstartdate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", fenddate, False))
            RptCashBook.LocalReport.SetParameters(paramList)

            RptCashBook.LocalReport.DataSources.Clear()
            Me.RptCashBook.LocalReport.DataSources.Add(dm)
            RptCashBook.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler RptCashBook.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblmsg.Text = "No records to display."
        End If
    End Sub
    'Protected Sub RptCashBook_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles RptCashBook.Init
    '    'Dim obj As New SelfDetailsB
    '    'Dim dt2 As New DataTable
    '    'Dim DL As New DLCashBookReport
    '    'Dim Prop As New QureyStringP
    '    'Dim dt1 As New DataTable
    '    QueryStr.GetValue(Page.Request, Prop)
    '    Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
    '    Dim fstartdate As Date = Request.QueryString.Get(("FinStartDate"))
    '    Dim fenddate As Date = Request.QueryString.Get(("FinEndDate"))
    '    QueryStr.GetValue(Page.Request, Prop)
    '    Dim dt4 As New DataTable
    '    Dim _debit, _credit As Double
    '    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
    '    Dim sql As String
    '    Dim ds As New DataTable
    '    ds = DL.CashBookReport(fstartdate, fenddate)
    '    sql = ViewState("dt2")
    '    Dim DT5 As New DataTable
    '    DT5 = ds
    '    _debit = DT5.Rows(0)(0)
    '    _credit = DT5.Rows(0)(1)

    '    dt1 = DL.CashBookReport1(fstartdate, fenddate)
    '    If dt1.Rows.Count > 0 Then
    '        Me.RptCashBook.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
    '        Me.RptCashBook.LocalReport.ReportPath = "rptCashBook.rdlc"
    '        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Acct_CashBook_Qry", dt1)

    '        Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)

    '        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ParameterCredit", CStr(_credit), False))
    '        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ParameterDebit", CStr(_debit), False))
    '        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StartDate", fstartdate, False))
    '        paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", fenddate, False))
    '        RptCashBook.LocalReport.SetParameters(paramList)

    '        RptCashBook.LocalReport.DataSources.Clear()
    '        Me.RptCashBook.LocalReport.DataSources.Add(dm)
    '        RptCashBook.LocalReport.Refresh()

    '        dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
    '        AddHandler RptCashBook.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

    '    Else
    '        Response.Write("No Records Found")

    '    End If

    'End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
