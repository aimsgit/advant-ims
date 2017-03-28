
Partial Class FrmListofDocumentV
    Inherits System.Web.UI.Page
    Dim Bl As New DLListofSubmitted
    Dim dtM As New Data.DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt, dt2, ParentDt, ParentDt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim ReportType As Integer
        Dim stdid, id1 As String


        'Aid = Request.QueryString.Get("Aid")
      
        stdid = Request.QueryString.Get("stdid")
        ReportType = Request.QueryString.Get("ReportType")
        'id = Request.QueryString.Get("id")
        id1 = Request.QueryString.Get("id1")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = Bl.GetListofDocument(stdid, id1)
        'To display Marks



        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "ListSubDocument.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_GetListSubmitted", dt1)
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()
                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                LblError.Text = "No Records to Display"
            End If
        Catch ex As Exception
            LblError.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class