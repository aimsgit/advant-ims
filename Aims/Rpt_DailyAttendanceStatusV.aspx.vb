
Partial Class Rpt_DailyAttendanceStatusV
    Inherits BasePage
    Dim DL As New RptDailyAttendanceDL
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt, dt2, ParentDt, ParentDt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BatchId, BatchName As String
        Dim SemId As Integer
        Dim FromDate, ToDate As DateTime
        BatchId = Request.QueryString.Get("BatchId")
        BatchName = Request.QueryString.Get("BatchName")
        SemId = Request.QueryString.Get("Semester")
        FromDate = Request.QueryString.Get("FrmDate")
        ToDate = Request.QueryString.Get("ToDate")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.GetDailyAttendanceReport(BatchId, SemId, FromDate, ToDate)

        If dt1.Rows.Count > 0 Then
            Try
                ReportViewer1.LocalReport.ReportPath = "Rpt_DailyAttendanceStatus.rdlc"
                dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_DailyAttendanceStatus", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("product", Product, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                ReportViewer1.LocalReport.Refresh()
                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                LblError.Text = ""
            Catch ex As Exception
                LblError.Text = ValidationMessage(1074)
            End Try
        Else
            LblError.Text = ValidationMessage(1023)
        End If
    End Sub

    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
End Class
