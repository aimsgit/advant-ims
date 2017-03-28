
Partial Class RptTimeTablewithattendanceV
    Inherits System.Web.UI.Page
    Dim ds1, dt4 As New DataTable


    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim DAL As New DLTimeTableWithattendance
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Sdate As Date = Request.QueryString.Get("Sdate")
        'Dim Batch As Integer = Request.QueryString.Get("Batch")
        'Dim Semester As Integer = Request.QueryString.Get("Semester")
        'Dim BatchName As String = Request.QueryString.Get("BatchName")
        'Dim SemesterName As String = Request.QueryString.Get("SemesterName")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DLTimeTableWithattendance.GetDetails(Sdate)

        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptTimeTablewithattendance.rdlc"
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_TimeTablewithattendance", dt1)
            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchName", BatchName, False))
            'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemesterName", SemesterName, False))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Sdate", Sdate, False))
            ReportViewer1.LocalReport.SetParameters(paramList)
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()
            ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblerror.Text = "No records to display."
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt4)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class

