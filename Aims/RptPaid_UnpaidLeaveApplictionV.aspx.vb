
Partial Class RptPaid_UnpaidLeaveApplictionV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim DeptId, EmpId As Integer
        Dim FromDate, ToDate As Date

        DeptId = Request.QueryString.Get("DeptId")
        EmpId = Request.QueryString.Get("EmpId")
        'LeaveType = Request.QueryString.Get("LeaveType")
        'LeaveStatus = Request.QueryString.Get("LeaveStatus")
        FromDate = Request.QueryString.Get("FromDate")
        ToDate = Request.QueryString.Get("ToDate")

        Dim dt As New Data.DataTable
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DLLeaveApplication.GetLeaveDetials(DeptId, EmpId, FromDate, ToDate)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptPaid_UnpaidLeaveAppliction.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_GetPaid_UnpaidLeave", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", FromDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
                ReportViewer1.LocalReport.SetParameters(paramList)


                dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
