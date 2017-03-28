
Partial Class RptSubTeacherMapV
    Inherits BasePage
    Dim dtS, dt, dt1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim obj As New SelfDetailsB
        Dim Prop As New QureyStringP
        QueryStr.GetValue(Page.Request, Prop)
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Dl As New DLRptSubTeacherMAp
        Dim id As String = Request.QueryString.Get("id")
       
        QueryStr.GetValue(Page.Request, Prop)
        Dim dt4 As New DataTable
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
        dt1 = Dl.GetTeacherdetails(id)
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "RptSubTeacherMap.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetTeacherDetails", dt1)

            'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate, False))
            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
            'ReportViewer1.LocalReport.SetParameters(paramList)

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


End Class
