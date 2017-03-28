
Partial Class RptMeritListV
    Inherits BasePage
    Dim dtS, dt, dt1, dt2 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Try
            Dim obj As New SelfDetailsB
            Dim Prop As New QureyStringP
            QueryStr.GetValue(Page.Request, Prop)
            Dim dm, dm1 As New Microsoft.Reporting.WebForms.ReportDataSource
            Dim Dl As New DLReportsR

            Dim course As Integer = Request.QueryString.Get("course")
            Dim Batch As String = Request.QueryString.Get("Batch")
            Dim Semester As Integer = Request.QueryString.Get("Semester")
            'Dim Subject As Integer = Request.QueryString.Get("Subject")
            Dim Top As Integer = Request.QueryString.Get("Top")
            Dim Bottom As Integer = Request.QueryString.Get("Bottom")
            Dim Gender As Integer = Request.QueryString.Get("Gender")
            Dim RBType As Integer = Request.QueryString.Get("RBType")
            Dim batName As String = Request.QueryString.Get("batName")
            'Dim AssessmentType As Integer = Request.QueryString.Get("AssessmentType")

            QueryStr.GetValue(Page.Request, Prop)
            Dim dt4 As New DataTable
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("Advant").ConnectionString
            dt1 = Dl.GetTopStudents(Batch, Semester, Top, Bottom, Gender, RBType)
            'dt2 = Dl.GetBottomStuds(Batch, Semester, Subject, AssessmentType, Top, Bottom, Gender)
            If dt1.Rows.Count > 0 Or dt2.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptMeritList.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_MeritListTpBtm", dt1)
                'dm1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_MeritListBottom", dt2)


                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Top", Top, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Bottom", Bottom, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("batName", batName, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                'Me.ReportViewer1.LocalReport.DataSources.Add(dm1)
                ReportViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

            Else
                lblErrorMsg.Text = "No Records to Display."

            End If
        Catch ex As Exception
            lblErrorMsg.Text = "No Records to Display."
        End Try

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
