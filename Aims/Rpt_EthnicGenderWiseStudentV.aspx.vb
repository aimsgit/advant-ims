﻿
Partial Class Rpt_EthnicGenderWiseStudentV
    Inherits System.Web.UI.Page
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Dim DS As New DataSet
    Dim DL As New TotalStudentCount
    Dim dr1 As New Microsoft.Reporting.WebForms.ReportDataSource
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim StartDate As DateTime = Request.QueryString.Get("StartDate")
        Dim EndDate As DateTime = Request.QueryString.Get("EndDate")
        Dim BranchCode As String = Request.QueryString.Get("BranchCode")
        Dim BranchCode1 As String = Request.QueryString.Get("BranchCode1")
        Dim Stream As Integer = Request.QueryString.Get("Stream")
        Dim Stream1 As String = Request.QueryString.Get("Stream1")
        QueryStr.GetValue(Page.Request, Prop)

        dt1 = DL.CompositionOfGenderWise(BranchCode, StartDate, EndDate, Stream)
        'If Right(BranchCode, 8) = "00000000" Then
        If dt1.Rows.Count > 0 Then
            Try
                ReportViewer1.LocalReport.ReportPath = "RptCompositionOfGenderDashboard.rdlc"
                dr1 = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_EthnicWiseDashboard", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", StartDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", EndDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchCode", BranchCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchCode1", BranchCode1, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Stream", Stream, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Stream1", Stream1, False))
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
