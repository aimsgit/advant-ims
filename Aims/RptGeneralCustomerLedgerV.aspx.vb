
Partial Class BankBookV
    Inherits System.Web.UI.Page
    Dim dtS, dt, dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim obj As New SelfDetailsB
        Dim dt2 As New DataTable
        Dim DL As New DLGeneralPartyLedger
        Dim Prop As New QureyStringP
        Dim dt8 As New Microsoft.Reporting.WebForms.ReportDataSource
        QueryStr.GetValue(Page.Request, Prop)
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim fstartdate As Date = Request.QueryString.Get(("FinStartDate"))
        Dim fenddate As Date = Request.QueryString.Get(("FinEndDate"))
        Dim PartyName As String = Request.QueryString.Get(("PartyName"))
        Dim PartyType As String = Request.QueryString.Get(("PartyType"))
        Dim PR As String = Request.QueryString.Get("PR")
        QueryStr.GetValue(Page.Request, Prop)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        dt1 = DL.GeneralPartyLedger(fstartdate, fenddate, PartyName, PartyType, PR)
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "RptGeneralCustLedgerRept.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Acct_GenParty_Ledgers", dt1)

            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)

            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StartDate", fstartdate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", fenddate, False))
            ReportViewer1.LocalReport.SetParameters(paramList)


            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            Label1.Text = "No Records Found."

        End If

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class


















'    Dim obj As New SelfDetailsB
'    Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
'    Dim fstartdate As Date = CDate(Server.UrlDecode(Request.QueryString("FinStartDate")))
'    Dim fenddate As Date = Server.UrlDecode(Request.QueryString("FinEndDate"))
'    Dim dt As New Data.DataTable
'    Dim _debit, _credit As Double
'    Dim sql As String
'    Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
'    sql = "SELECt CASE WHEN SUM([Amt_Out] - [Amt_In]) > 0 THEN SUM([Amt_Out] - [Amt_In]) ELSE 0 END AS Debit, CASE WHEN SUM([Amt_In] - [Amt_Out])>0 THEN SUM([Amt_In] - [Amt_Out]) ELSE 0 END AS Credit FROM Balance_Sheet(" & Request.QueryString(1) & "," & Request.QueryString(0) & ",'" & fstartdate & "','" & fenddate & "') WHERE (Acct_SubGroup_ID=102) AND Balance_Sheet.Bill_Date<'" & Format(fstartdate, "dd-MMM-yyyy") & "'"
'    Dim ds As DataSet = SqlHelper.ExecuteDataset(connectionString, CommandType.Text, Sql)
'    Dim DT1 As New DataTable

'    DT1 = ds.Tables(0)
'    _debit = DT1.Rows(0)(0)
'    _credit = DT1.Rows(0)(1)

'    ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
'    ReportViewer1.LocalReport.ReportPath = "RptGeneralCustLedgerRept.rdlc"
'    dt = PartyLedger.GetGenPartyLedgRpt()
'    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Acct_GenParty_Ledgers", dt)

'    ReportViewer1.LocalReport.DataSources.Clear()
'    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
'    ReportViewer1.LocalReport.Refresh()

'    'dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
'    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
'End Sub
'Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
'    Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
'    e.DataSources.Add(rptDataSource)


