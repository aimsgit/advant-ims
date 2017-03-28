
Partial Class RptRoleTestingV
    Inherits System.Web.UI.Page
    Dim ds1 As Data.DataTable
    Dim dt2 As New DataTable
    Dim DL As New RollTestingDL
    

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim rolename As String = Request.QueryString.Get("rolename")
        Dim branch1 As String = Request.QueryString.Get("branch1")
        Dim branch As String = Request.QueryString.Get("branch")
        Dim role As Integer = Request.QueryString.Get("role")

        QueryStr.GetValue(Page.Request, Prop)

        dt1 = RollTestingDL.GetRoleTestingreport(branch, role)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_RoleTestingV.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_proc_RoleTestingReport", dt1)

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("branch1", branch1, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("rolename", rolename, False))
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

            Else
                lblmsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
