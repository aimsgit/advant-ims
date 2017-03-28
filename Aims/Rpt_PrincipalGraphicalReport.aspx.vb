
Partial Class Rpt_PrincipalGraphicalReport
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New DLPrincipalDashboard
    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim academic As Integer = Request.QueryString.Get("academic")
        Dim course As Integer = Request.QueryString.Get("course")
        Dim stdcategory As Integer = Request.QueryString.Get("stdcategory")
        Dim branch As String = Request.QueryString.Get("branch")
        Dim aname As String = Request.QueryString.Get("aname")
        Dim cname As String = Request.QueryString.Get("cname")
        Dim catname As String = Request.QueryString.Get("catname")

        QueryStr.GetValue(Page.Request, Prop)

        dt1 = DL.PrincipalDashboard(academic, course, stdcategory)

        If dt1.Rows.Count > 0 Then
            Try
                ReportViewer1.LocalReport.ReportPath = "Rpt_PrincipalGraphicalReport.rdlc"
                dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_PrincipalDashboard", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("branch", branch, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("aname", aname, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("cname", cname, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("catname", catname, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                Me.ReportViewer1.LocalReport.DataSources.Add(dr1)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                lblErrorMsg.Text = ""
            Catch ex As Exception
                lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
            End Try
        Else
            lblErrorMsg.Text = "No Records to Display."
        End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
