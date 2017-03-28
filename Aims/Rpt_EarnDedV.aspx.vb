﻿
Partial Class Rpt_EarnDedV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt4 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim DL As New DLRptEarnDed

        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BN As String = Request.QueryString.Get("BN")
        Dim Dept As String = Request.QueryString.Get("Dept")
        Dim ET As String = Request.QueryString.Get("EDType")
        Dim EN As String = Request.QueryString.Get("EmpName")
        Dim YR As Integer = Request.QueryString.Get("Year")
        Dim MN As String = Request.QueryString.Get("month")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DLRptEarnDed.GetEmployeeEarning(BN, Dept, EN, YR, MN)
        
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_EarnDed.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_Rpt_Earn", dt1)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("YR", YR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("MN", MN, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))

                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt4)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class