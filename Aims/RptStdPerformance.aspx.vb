Partial Class RptStdPerformance
    Inherits System.Web.UI.Page
    Dim dtS As New Data.DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt As New DataTable
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        QueryStr.GetValue(Page.Request, Prop)

        Dim Cour As Integer = Request.QueryString.Get("Course")
        Dim Btch As Integer = Request.QueryString.Get("BatchVal")
        Dim Subj As Integer = Request.QueryString.Get("Subject")
        Dim DAL As New StdResultB
       
        ReportViewer1.LocalReport.ReportPath = "SubjectWiseGraph.rdlc"
        dt = DAL.GetStdPerformance(Request.QueryString(1), Request.QueryString(0), Cour, Btch, Subj)
        Dim dtM As New Data.DataTable
        dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_StdPerformance", DAL.GetStdPerformance(Request.QueryString(1), Request.QueryString(0), Cour, Btch, Subj))
        'dtM = DAL.GetResultByStdCode(Code, sem, Btch, Cour, Prop.brnID, Prop.insID)
        'Dim dtT As New DataTable
        'dtT = dtM.Clone
        'dtT.Clear()

        'Dim i, j As Integer
        'Dim insertflag As Boolean
        'For i = 0 To dtM.Rows.Count - 1
        '    j = 0
        '    insertflag = False
        '    While j <> dtT.Rows.Count
        '        If dtT.Rows(j).Item("Subject_Name") = dtM.Rows(i).Item("Subject_Name") And dtT.Rows(j).Item("AssessmentType") = dtM.Rows(i).Item("AssessmentType") Then
        '            dtT.Rows.RemoveAt(j)
        '            dtT.ImportRow(dtM.Rows(i))
        '            insertflag = True
        '        End If
        '        j = j + 1
        '    End While
        '    If insertflag = False Then
        '        dtT.ImportRow(dtM.Rows(i))
        '    End If
        'Next

        'dtM = dtT

        ReportViewer1.LocalReport.DataSources.Clear()
        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
        ReportViewer1.LocalReport.Refresh()

        'Dim brch As Integer = CInt(Request.QueryString.Get("Branch"))

        'dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
