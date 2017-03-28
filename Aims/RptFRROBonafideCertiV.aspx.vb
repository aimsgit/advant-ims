
Partial Class RptFRROBonafideCertiV
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim obj As New SelfDetailsB
        Dim DL As New StudentDB
        Dim dt1 As New DataTable

        Dim BrID As String = Request.QueryString.Get("BrID")
        Dim AID As Integer = Request.QueryString.Get("AID")
        Dim CID As Integer = Request.QueryString.Get("CID")
        Dim BID As Integer = Request.QueryString.Get("BID")
        Dim country As String = Request.QueryString.Get("country")
        Dim Student As Integer = Request.QueryString.Get("Student")

        dt1 = StudentDB.GetIndStudDetailsforBonafideCertiRpt(BrID, AID, CID, BID, country, Student)
        If dt1.Rows.Count > 0 Then
            ReportViewer1.LocalReport.ReportPath = "RptFRROBonafideCerti.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_FRROBonafideCerti", dt1)

            ReportViewer1.LocalReport.EnableExternalImages = True

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
