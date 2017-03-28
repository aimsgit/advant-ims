

Partial Class RptHostelRoomDetailsV
    Inherits System.Web.UI.Page
    Dim dt As DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DL As New DLHostelRpt
        Dim dt1 As New Data.DataTable

        Dim branchcode As String = Request.QueryString.Get("BranchCode")

        Dim Hid As Integer = Request.QueryString.Get("HID")
        Dim Rid As Integer = Request.QueryString.Get("RID")

        dt1 = DLHostelRpt.GetHostelRoomDetailsRpt(branchcode, Hid, Rid)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptHostelRoomDetails.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_HostelRoommaster", dt1)

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
