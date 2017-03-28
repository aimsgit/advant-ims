
Partial Class RptIncomeExpendtr
    Inherits System.Web.UI.Page

    Dim dtS, dt, dt1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim obj As New SelfDetailsB
        Dim DL As New DLIncomeAndExpenditure
        Dim Prop As New QureyStringP
        QueryStr.GetValue(Page.Request, Prop)
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim fstartdate As Date = Request.QueryString.Get(("FinStartDate"))
        Dim fenddate As Date = Request.QueryString.Get(("FinEndDate"))
        Dim PR As String = Request.QueryString.Get("PR")
        QueryStr.GetValue(Page.Request, Prop)
        Dim dt4 As New DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        dt1 = DL.IncomeAndExpenditure(fstartdate, fenddate, PR)
        If PR = 0 Then


            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptIncomeExpenditure.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Acct_IncAndExp_Qry", dt1)

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
                lblErrorMsg.Text = "No records to display."

            End If
        Else
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptIncomeExpenditureProject.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Acct_IncAndExp_Qry", dt1)

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
                lblErrorMsg.Text = "No records to display."

            End If
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
'    Dim BAL As New GlobalDataSetTableAdapters.Test_Acct_Income_QryTableAdapter
'    Dim dt As New Data.DataTable
'    ReportViewer1.LocalReport.ReportPath = "RptIncomeExpenditure.rdlc"
'    dt = BAL.GetData(Request.QueryString(1), Request.QueryString(0), fstartdate, fenddate)
'    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Test_Acct_Income_Qry", dt)

'    ReportViewer1.LocalReport.DataSources.Clear()
'    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
'    ReportViewer1.LocalReport.Refresh()

'    'dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
'    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
'End Sub
'Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
'    Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
'    e.DataSources.Add(rptDataSource)
'End Sub
