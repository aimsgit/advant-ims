
Partial Class rptFeeDueStatementV
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
            Dim BatchId As Integer
            Dim SemID As Integer
            Dim StdID As Integer
            Dim CategoryID As Integer
            Dim CourseCode As Integer

            QueryStr.GetValue(Page.Request, Prop)


            Try
                If Session("LoginType") = "Employee" Then
                    BatchId = Request.QueryString.Get("BatchId")
                    SemID = Request.QueryString.Get("SemID")
                    StdID = Request.QueryString.Get("StdID")
                    CategoryID = Request.QueryString.Get("CategoryID")
                    CourseCode = Request.QueryString.Get("CourseCode")
                ElseIf Session("LoginType") = "Others" Then
                    Parentdt = Dl.GetStudentDtlsForParent()
                    BatchId = HttpContext.Current.Session("BatchID")
                    StdID = Parentdt.Rows(0).Item("STD_ID").ToString()
                    Parentdt1 = Dl.GetStdSemester(BatchId)
                    SemID = Parentdt1.Rows(0).Item("SemesterID").ToString()
                    CategoryID = Parentdt.Rows(0).Item("categoryid").ToString()
                    CourseCode = Request.QueryString.Get("CourseCode")
                End If
                dt1 = BLL.FeeDueReport(BatchId, SemID, StdID, CategoryID, CourseCode)
                If dt1.Rows.Count > 0 Then
                    Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                    Me.ReportViewer1.LocalReport.ReportPath = "rptFeeDueStatement.rdlc"
                    dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_FeeDueStatement", dt1)
                    ReportViewer1.LocalReport.DataSources.Clear()
                    Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                    ReportViewer1.LocalReport.Refresh()

                    'ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
                    'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                    ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                Else
                    lblE.Text = "No records to display."
                End If
            Catch ex As Exception
                lblE.Text = "No Records to Display"
            End Try
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
