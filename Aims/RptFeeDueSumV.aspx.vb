
Partial Class RptFeeDueSumV
    Inherits BasePage
    Dim BLL As New FeeStructureManager
    Dim ds1 As DataTable
    Dim Dl As New feeCollectionDL
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Try
            Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource

            Dim Prop As New QureyStringP
            Dim obj As New SelfDetailsB
            Dim dt1, Parentdt, Parentdt1 As New DataTable
            Dim AcId As Integer
            Dim SemID As Integer
            Dim CategoryID As Integer
            Dim CourseCode As Integer
            Dim AName As String
            Dim CName As String
            Dim SName As String
            Dim CATName As String

            QueryStr.GetValue(Page.Request, Prop)

            SemID = Request.QueryString.Get("SemID")
            CategoryID = Request.QueryString.Get("CategoryID")
            CourseCode = Request.QueryString.Get("CourseCode")
            AcId = Request.QueryString.Get("AcId")
            AName = Request.QueryString.Get("AName")
            CName = Request.QueryString.Get("CName")
            SName = Request.QueryString.Get("SName")
            CATName = Request.QueryString.Get("CATName")

       
            dt1 = BLL.FeeDueReportSum(SemID, AcId, CategoryID, CourseCode)
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptFeeDueSum.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_FeeDueStatementSum", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AName", AName, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CName", CName, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SName", SName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("CATName", CATName, False))

                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblE.Text = "No records to display."
            End If
        Catch ex As Exception
            lblE.Text = "No Records to Display."
        End Try
        


    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
