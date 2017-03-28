
Partial Class RptSemMarksnAttenListParentLoginV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim DL As New stdAttndance
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

        Dim Bat, Sem, Assessmentid, id, Studid As Integer
        Dim SrtDate, EndDate, AssessmentType As String
        Bat = Request.QueryString.Get("BatchID")
        Sem = Request.QueryString.Get("Semester")
        Assessmentid = Request.QueryString.Get("Assessmentid")
        SrtDate = Request.QueryString.Get("Strtdate")
        EndDate = Request.QueryString.Get("EndDate")
        AssessmentType = Request.QueryString.Get("AssessmentType")
        id = Request.QueryString.Get("id")
        Studid = Request.QueryString.Get("Studid")

        'Dim BAL As New GlobalDataSetTableAdapters.Test_BankReconciliationTableAdapter
        Dim dt As New Data.DataTable

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.GetNewSemMarksAttendListStudLoginReport(Bat, Sem, Assessmentid, id, SrtDate, EndDate, Studid)

        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptStudMarksAttendList.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SemMarksAttenMap", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)

                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssessmentType", AssessmentType, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

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
