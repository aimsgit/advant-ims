Partial Class rptCoursewise
    Inherits System.Web.UI.Page
    Dim Inst, Bran, Cour, Btch, RptVal, rptPath As String
    Dim dtS As New Data.DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Prop As New QureyStringP
        Dim obj1 As New SelfDetailsB
        Dim obj As New StudentDB
        QueryStr.GetValue(Page.Request, Prop)
        Cour = Request.QueryString.Get("Course")
        Btch = Request.QueryString.Get("BatchVal")
        RptVal = Request.QueryString.Get("Type")

        Dim BAL As New CourseManager
        If RptVal = "AllBatch" Then
            ReportViewer1.LocalReport.ReportPath = "rptBatchwise.rdlc"
            'dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_BatchWise", BAL.GetCourseALLBatchRpt(Cour, Request.QueryString(0), Request.QueryString(1)))
        ElseIf RptVal = "BatchWise" Then
            ReportViewer1.LocalReport.ReportPath = "rptBatchwise.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_BatchWise", BAL.GetCourseBatchGDSRpt(Cour, Request.QueryString(0), Request.QueryString(1), Btch))
        ElseIf RptVal = "All" Then
            ReportViewer1.LocalReport.ReportPath = "rptCoursewise.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_CourseWiseGroup", StudentDB.RPT_GetCorswiseStdList(0, 0, 0).Tables(0))
        ElseIf RptVal = "Course" Then
            ReportViewer1.LocalReport.ReportPath = "rptCoursewise.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_CourseWiseGroup", StudentDB.RPT_GetCorswiseStdList(Request.QueryString(1), Request.QueryString(0), 0).Tables(0))
        ElseIf RptVal = "AllCourse" Then
            ReportViewer1.LocalReport.ReportPath = "rptCoursewise.rdlc"
            dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_RPT_CourseWiseGroup", StudentDB.RPT_GetCorswiseStdList(Request.QueryString(1), Request.QueryString(0), Cour).Tables(0))
        Else
            Response.Redirect("StudentList.aspx")
        End If
        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
        ReportViewer1.LocalReport.Refresh()

        Dim brch As Integer = CInt(Request.QueryString.Get("Branch"))

        'dtS = obj1.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
