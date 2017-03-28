
Partial Class RptPlacementDetails
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim str As Integer = CInt(Request.QueryString.Get("User"))
        Dim Cour As Integer = CInt(Request.QueryString.Get("Course"))
        Dim Btch As String = Request.QueryString.Get("Batch")
        Dim brch As Integer = Request.QueryString("BrnId")
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BLL As New PlacementB
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt1 As Data.DataTable

        QueryStr.GetValue(Page.Request, Prop)
        'Dim ins As Integer = CInt(Request.QueryString(1))
        'Dim brn As Integer = CInt(Request.QueryString(0))

        If str = 1 Then
            Me.ReportViewer1.LocalReport.ReportPath = "rptPlacement.rdlc"
        Else
            Me.ReportViewer1.LocalReport.ReportPath = "rptPlacement_training.rdlc"
        End If

        'Commented by Nethra during Build 13-Apr-2012
        'dt1 = BLL.GetReport(Prop.insID, Prop.brnID, Cour, Btch, str)
        dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_Placement", dt1)

        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dt)
        ReportViewer1.LocalReport.Refresh()

        'ds1 = obj.RPT_GetSelfDeatilsByBranch(Prop.userID, Prop.insID)
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
