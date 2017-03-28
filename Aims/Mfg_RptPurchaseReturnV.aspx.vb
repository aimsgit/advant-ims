
Partial Class Mfg_RptPurchaseReturnV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim StartDate As Date
    Dim EndDAte As Date
    'Code written By Ajit
    '04-Feb-2013
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim SuppID As Integer = Request.QueryString.Get("Supp_ID")
        Dim PurRetID As Integer = Request.QueryString.Get("PR_ID")
        Dim StartDate As Date = Request.QueryString.Get("StartDate")
        Dim EndDAte As Date = Request.QueryString.Get("EndDAte")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = Mfg_RptPurchaseReturnDL.GetPurchaseReturnRpt(SuppID, PurRetID, StartDate, EndDAte)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Mfg_RptPurchaseReturn.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Mfg_Rpt_PurchaseReturn", dt1)
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No Records to Display."
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
