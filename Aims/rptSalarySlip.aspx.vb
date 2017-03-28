Partial Class rptPrintSalarySlip
    'Inherits System.Web.UI.Page
    'Dim dt As New DataTable
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim BL As New BLPayroll
        Dim EL As New EntPayroll
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim id As Integer = Request.QueryString.Get("id")
        'Dim startdate As Date = Request.QueryString.Get("startdate")
        'Dim enddate As String = Request.QueryString.Get("enddate")
        EL.Month = Request.QueryString.Get("Month")
        EL.Year = Request.QueryString.Get("Year")

        QueryStr.GetValue(Page.Request, Prop)
        dt1 = BL.RptSalSlip(EL)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "rptSalarySlip.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_PayRoll_SalarySlip", dt1)
                'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", fromdate, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", todate, False))

                'ReportViewer1.LocalReport.SetParameters(paramList)
                'ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                'Else

                '    lblmsg.Text = "No Records to Display"
            End If
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
        'Dim BLL As New BLPayroll
        'Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        'Dim Mon As Integer = CInt(Request.QueryString.Get("Mon"))
        'Dim yea As Integer = CInt(Request.QueryString.Get("Yea"))
        'Dim Empid As Integer = CInt(Request.QueryString.Get("EmpId"))
        'Dim Id As Int16 = CInt(Request.QueryString.Get("Id"))
        'Dim rptpath As String = ""

        'Dim obj As New SelfDetailsB

        'If Id = 0 Then
        '    ReportViewer1.LocalReport.ReportPath = "rptSalarySlip.rdlc"
        '    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_rptSalarySlip", BLL.RptSalSlip(Request.QueryString(1), Request.QueryString(0), Mon, yea, Empid, Id))
        '    'ElseIf Id = 1 Then
        '    '    rptpath = Server.MapPath("rptSalarySlipEmpWise.rpt")
        '    '    dt = BLL.RptSalSlip(Prop.insID, Prop.brnID, Mon, yea, Empid, Id)
        '    'ElseIf Id = 2 Then
        '    '    rptpath = Server.MapPath("rptSalarySlipMonthWise.rpt")
        '    '    dt = BLL.RptSalSlip(Prop.insID, Prop.brnID, Mon, yea, Empid, Id)
        'End If
        'ReportViewer1.LocalReport.DataSources.Clear()
        'Me.ReportViewer1.LocalReport.DataSources.Add(dm)
        'ReportViewer1.LocalReport.Refresh()

        ''dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        'Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
        'e.DataSources.Add(rptDataSource)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class
