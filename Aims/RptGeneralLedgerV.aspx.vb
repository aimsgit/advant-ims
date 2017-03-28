
Partial Class GeneralLedger
    Inherits System.Web.UI.Page
    Dim dt, dt1 As New Data.DataTable


    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim obj As New SelfDetailsB
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Prop As New QureyStringP
        Dim GeneralLedgerDB As New GeneralLedgerDB
        QueryStr.GetValue(Page.Request, Prop)
        Dim fstartdate As Date = Request.QueryString.Get(("FinStartDate"))
        Dim fenddate As Date = Request.QueryString.Get(("FinEndDate"))
        Dim AH As String = Request.QueryString.Get("AH")
        Dim PR As String = Request.QueryString.Get("PR")
        Dim AC As String = Request.QueryString.Get("AC")
        QueryStr.GetValue(Page.Request, Prop)

        ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local

        dt1 = GeneralLedgerDB.GetGeneralLedgRpt(AH, PR, fstartdate, fenddate, AC)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptGeneralLedger.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Acct_DayBook_Qry", dt1)

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
            lblErrorMsg.Text = "No Records to Display."

        End If

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    'iif((Sum(Fields!Amt_In.Value)-Sum(Fields!Amt_Out.Value))>0,Sum(Fields!Amt_In.Value)-Sum(Fields!Amt_Out.Value),"")
    'iif((Sum(Fields!Amt_Out.Value)-Sum(Fields!Amt_In.Value))>0,Sum(Fields!Amt_Out.Value)-Sum(Fields!Amt_In.Value),"")
End Class

