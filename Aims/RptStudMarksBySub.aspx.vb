
Partial Class RptStudMarksBySub
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource
    Dim Dl As New stdAttndanceBySubject
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim AYear As Integer = (Request.QueryString.Get("Ayear"))
        Dim Batch As String = (Request.QueryString.Get("Batch"))
        Dim Semester As String = (Request.QueryString.Get("Semester"))
        Dim Subject As Integer = (Request.QueryString.Get("Subject"))
        Dim Assesment As String = (Request.QueryString.Get("Assesment"))
        Dim AssesmentDate As Date = (Request.QueryString.Get("AssesmentDate"))
        Dim SubGrp As Integer = (Request.QueryString.Get("SubGrp"))
        Dim StdId As Integer = (Request.QueryString.Get("StdId"))


        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DLStdMarksElectiveBySub.ViewStdMarksRpt(AYear, Batch, Semester, Subject, Assesment, AssesmentDate, SubGrp, StdId)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptStudMarksBySub.rdlc"
                dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_New_ViewStudentMarksElectiveBySub", dt1)

                'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Fromdate", Fromdate, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", ToDate, False))
                'ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                ReportViewer1.LocalReport.Refresh()

                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                lblErrorMsg.Text = ""
            Else
                lblErrorMsg.Text = "No Records to Display."

            End If

        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub



End Class
