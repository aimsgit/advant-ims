
Partial Class frmdebitnote
    Inherits System.Web.UI.Page
    Dim dtS As New Data.DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        'Dim type As String = (Request.QueryString.Get("a"))
        'Dim Prop As New QureyStringP
        'Dim obj As New SelfDetailsB
        'Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        'QueryStr.GetValue(Page.Request, Prop)
        'If type = "Transfer" Then
        '    Dim Assetid As String = (Request.QueryString.Get("AID"))
        '    'Dim dll As New GlobalDataSetTableAdapters.Credit_Debit_Note_TransferTableAdapter

        '    ReportViewer1.LocalReport.ReportPath = "rptDebitNoteT.rdlc"
        '    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Credit_Debit_Note_Transfer", dll.GetData(Assetid))

        '    Dim dt As New Data.DataTable
        '    dt = dll.GetData(Assetid)
        '    If dt.Rows.Count <> 0 Then
        '        ReportViewer1.LocalReport.DataSources.Clear()
        '        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
        '        ReportViewer1.LocalReport.Refresh()

        '        'dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        '        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        '    End If
        'Else
        '    Dim Assetid As String = (Request.QueryString.Get("AID"))
        '    Dim dll As New GlobalDataSetTableAdapters.Credit_Debit_NoteTableAdapter
        '    Dim brch As Integer = brch

        '    ReportViewer1.LocalReport.ReportPath = "rptDebitNote.rdlc"
        '    dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Credit_Debit_Note", dll.GetData(Assetid))

        '    Dim dt As New Data.DataTable
        '    dt = dll.GetData(Assetid)
        '    If dt.Rows.Count <> 0 Then
        '        ReportViewer1.LocalReport.DataSources.Clear()
        '        Me.ReportViewer1.LocalReport.DataSources.Add(dm)
        '        ReportViewer1.LocalReport.Refresh()

        '        'dtS = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(2), Request.QueryString(1))
        '        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
        '    Else
        '        Dim alt As String = "<script language='javascript'>" + "alert('Debit note generated on transfer!');" + "</script>"
        '        ClientScript.RegisterStartupScript(Me.GetType, "alert", alt)
        '        Response.Redirect("frmAssetTransfer.aspx")
        '    End If
        'End If
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        'Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dtS)
        'e.DataSources.Add(rptDataSource)
    End Sub
End Class
