
Partial Class Rpt_PrincipaldashFeesumarry
    Inherits System.Web.UI.Page
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLPrinicipalDashBoard
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim AcademicYear, Category, Course, FCaste As Integer
        Dim CategoryName, Branch, A_Name, FCasteText As String
        AcademicYear = Request.QueryString.Get("AcademicYear")
        Course = Request.QueryString.Get("Course")
        Category = Request.QueryString.Get("Category")
        CategoryName = Request.QueryString.Get("CategoryName")
        Branch = Request.QueryString.Get("Branch")
        A_Name = Request.QueryString.Get("A_Name")
        FCaste = Request.QueryString.Get("FCaste")
        FCasteText = Request.QueryString.Get("FCasteText")

        dt1 = DL.GetFeeCollectionSum(AcademicYear, Course, Category, FCaste)
        Try
            If dt1.Rows.Count > 0 Then
                ReportViewer1.LocalReport.ReportPath = "Rpt_PrincipalDashfeeSummary.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_PrincipalDashFeesummaryReport", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CategoryName", CategoryName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Branch", Branch, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("A_Name", A_Name, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FCasteText", FCasteText, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
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
