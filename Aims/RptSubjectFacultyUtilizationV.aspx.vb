
Partial Class RptSubjectFacultyUtilizationV
    Inherits System.Web.UI.Page
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLSubjectFacultyUtilization
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim EMPID, CourseID, BatchID, SemesterID, SubjectID As Integer
        EMPID = Request.QueryString.Get("EMPID")
        CourseID = Request.QueryString.Get("CourseID")
        BatchID = Request.QueryString.Get("BatchID")
        SemesterID = Request.QueryString.Get("SemesterID")
        SubjectID = Request.QueryString.Get("SubjectID")

        dt1 = DL.GetFacultyReport(EMPID, CourseID, BatchID, SemesterID, SubjectID)
        Try
            If dt1.Rows.Count > 0 Then
                ReportViewer1.LocalReport.ReportPath = "RptSubjectFacultyUtilization.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_StudentWiseFacultyUtilization", dt1)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else

                lblmsg.Text = "No Records to Display."
            End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
