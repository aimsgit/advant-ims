Imports BookReturnB
Imports BookReturnP
Partial Class BookPendingV
    Inherits System.Web.UI.Page
    'Commented by Nethra during build on 09-apr-2012

    'Dim prop As New BookReturnP.Disp_GVp
    'Dim bll As New BookReturnB.BookReturnB
    ' ''Dim paramField As New ParameterField()
    ' ''Dim paramFields As New ParameterFields()
    ' ''Dim distVal As New ParameterDiscreteValue()
    'Dim dtS As New Data.DataTable
    ' ''Dim rptSR As New ReportDocument

    'Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
    '    Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource

    '    Dim Prop1 As New QureyStringP
    '    Dim obj As New SelfDetailsB
    '    QueryStr.GetValue(Page.Request, Prop1)

    '    prop.Who = Server.UrlDecode(Request.QueryString("user"))
    '    prop.Todaydate = Date.Today

    '    prop.BranchId = Request.QueryString(0)
    '    prop.InstituteId = Request.QueryString(1)
    '    If prop.Who = "Staff" Then
    '        ReportViewer1.LocalReport.ReportPath = "rptBookPending.rdlc"
    '    Else
    '        ReportViewer1.LocalReport.ReportPath = "rptBookPendingStudent.rdlc"
    '    End If
    '    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_BookReturnQ", (bll.Disp_GVPending(prop)))

    '    ''paramField.ParameterFieldName = "batch"
    '    ''distVal.Value = prop.Rpt

    '    ''paramField.CurrentValues.Add(distVal)
    '    ''paramFields.Add(paramField)

    '    ReportViewer1.LocalReport.DataSources.Clear()
    '    Me.ReportViewer1.LocalReport.DataSources.Add(dm)
    '    ReportViewer1.LocalReport.Refresh()

    '    Dim brch As Integer = CInt(Request.QueryString.Get("Branch"))

    '    ''dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
    '    AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
    'End Sub
    'Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
    '    Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
    '    e.DataSources.Add(rptDataSource)
    'End Sub
End Class
