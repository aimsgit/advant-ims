
Partial Class RptPromotionEligibilityV
    Inherits System.Web.UI.Page
    Dim ds1 As New DataTable

   
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim Bll As New OtherPartyB
        Dim ds As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt1 As New DataTable

        QueryStr.GetValue(Page.Request, Prop)
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        QueryStr.GetValue(Page.Request, Prop)
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Batch As Integer = Request.QueryString.Get("Batch")
        Dim sem1 As Integer = Request.QueryString.Get("sem1")
        Dim sem2 As Integer = Request.QueryString.Get("sem2")
        Dim Assisment As Integer = Request.QueryString.Get("Assisment")
        Dim NoofSubject As Integer = Request.QueryString.Get("NoofSubject")
        Dim semname1 As String = Request.QueryString.Get("semname1")
        Dim semname2 As String = Request.QueryString.Get("semname2")

        dt1 = DLEligiblityPromotion.RptPromotionEligibility(Batch, sem1, sem2, Assisment, NoofSubject)
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "RptPromotionEligibility.rdlc"
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RptPromotionAndEligibility", dt1)


            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("sem1", semname1, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("sem2", semname2, False))
            ReportViewer1.LocalReport.SetParameters(paramList)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()

            ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

        Else
            lblErrorMsg.Text = "No records to display."

        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
