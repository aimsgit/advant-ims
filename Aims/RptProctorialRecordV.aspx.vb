Partial Class RptProctorialRecordV
    Inherits BasePage
    Dim Bl As New StdAttdance
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt As New DataTable
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Batch As Integer = Request.QueryString.Get("Batch")
        Dim Course As Integer = Request.QueryString.Get("Course")
        Dim Student As Integer = Request.QueryString.Get("Student")
        Dim DL As New DLStudentIDCard
        'QueryStr.GetValue(Page.Request, Prop)
        dt1 = DLStudentIDCard.RPT_GetStudentID(Batch, Course, Student)
        If dt1.Rows.Count > 0 Then
            Me.ReportViewer1.LocalReport.ReportPath = "StudentIDCard.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_StudentIDCard", dt1)

            Me.ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dm)
            Me.ReportViewer1.LocalReport.Refresh()

            dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        Else
            lblmsg.Text = "No Records to display."
        End If
    End Sub
End Class
