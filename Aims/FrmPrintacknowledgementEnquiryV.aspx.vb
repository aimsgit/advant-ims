
Partial Class FrmPrintacknowledgementEnquiry
    Inherits BasePage
    Dim ds1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Try
            Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
            Dim dt1 As New DataTable
            Dim Prop As New QureyStringP
            Dim obj As New SelfDetailsB
            Dim dl As New DLInstitute
            Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
            Dim EnqNo As String = Request.QueryString.Get("EnqNo")
            Dim BranchName As String = Request.QueryString.Get("BranchName")
            Dim Name As String = Request.QueryString.Get("Name")
            Dim Phone As String = Request.QueryString.Get("Phone")
            Dim Email As String = Request.QueryString.Get("Email")
            Dim caste As String = Request.QueryString.Get("caste")
            Dim EnqFor As String = Request.QueryString.Get("EnqFor")
            Dim AckDate As DateTime = Now.Date
            Dim DL1 As New DLFeeHeadReport
            QueryStr.GetValue(Page.Request, Prop)
            dt1 = DL1.Rpt_FeeHeads()

            Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
            Me.ReportViewer1.LocalReport.ReportPath = "RPTAcknowledgement.rdlc"
            dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_FeeHeads", dt1)

            Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EnqNo", EnqNo, True))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, True))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Name", Name, True))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Phone", Phone, True))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Email", Email, True))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("caste", caste, True))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AckDate", AckDate, True))
            paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EnqFor", EnqFor, True))
            ReportViewer1.LocalReport.SetParameters(paramList)

            ReportViewer1.LocalReport.DataSources.Clear()
            Me.ReportViewer1.LocalReport.DataSources.Add(dt)
            ReportViewer1.LocalReport.Refresh()
            ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
            AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent

            'modified by Nitin 03/01/2012
        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class

