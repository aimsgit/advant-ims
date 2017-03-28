Partial Class RptFeeDetails
    Inherits System.Web.UI.Page
    Dim dtS As New Data.DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        'Dim Prop As New QureyStringP
        'Dim obj As New SelfDetailsB
        'Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim Cour As Integer = CInt(Request.QueryString.Get("Course"))
        'Dim Btch As Integer = CInt(Request.QueryString.Get("Batch"))
        'Dim stdID As Integer = CInt(Request.QueryString.Get("Stdid"))
        'Dim semID As Integer = CInt(Request.QueryString.Get("Sem"))
        'Dim BAL As New FeePaymentDetailsB

        'ReportViewer1.LocalReport.ReportPath = "rptFeeDetails.rdlc"
        'QueryStr.GetValue(Page.Request, Prop)
        'Dim dt As New Data.DataTable
        'dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_DispGV_FeeDetails", BAL.FillGrid(Btch, Request.QueryString(1), Request.QueryString(0), Cour, stdID, semID))

        'ReportViewer1.LocalReport.DataSources.Clear()
        'Me.ReportViewer1.LocalReport.DataSources.Add(dm)
        'ReportViewer1.LocalReport.Refresh()
        'dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent



        '------------Kusum
        Dim ds1 As New DataTable
        Dim dt1 As New DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dl As New GlobalDataSetTableAdapters.FeeDetailsDB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Cour As Integer = CInt(Request.QueryString.Get("Course"))
        Dim Btch As Integer = CInt(Request.QueryString.Get("Batch"))
        Dim stdID As Integer = CInt(Request.QueryString.Get("Stdid"))
        Dim semID As Integer = CInt(Request.QueryString.Get("Sem"))
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = dl.FillGrid(Session("batchID"), Session("crsID"), Session("stdID"), Session("semID"))
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "rptFeeDetails.rdlc"
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_DispGV_FeeDetails", dt1)

            'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("cluster", cluster, False))
            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("farmer", farmer, False))
            'ReportViewer1.LocalReport.SetParameters(paramList)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()
            'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            'lblmsg.Text = "No Records to Display"
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
