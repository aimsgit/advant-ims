
Partial Class RptLoginV
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Dim Dl As New DlLoginReport
    Dim El As New ELLoginReport
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim dt1 As New Data.DataTable

        Dim Institute As String = Request.QueryString.Get("Institute")
        Dim Branch As String = Request.QueryString.Get("Branch")
        Dim FrmDate As DateTime = Request.QueryString.Get("FrmDate")
        Dim ToDate As DateTime = Request.QueryString.Get("ToDate")

        dt1 = DlLoginReport.RptLogin(Institute, Branch, FrmDate, ToDate)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptLogin.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_Logincount", dt1)

            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FrmDate", FrmDate, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
            ReportViewer1.LocalReport.SetParameters(paramList)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            lblmsg.Text = ""
        Else
            lblmsg.Text = "No Records to Display."

        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
