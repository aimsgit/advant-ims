
Partial Class Rpt_WelfareActivityV
    Inherits BasePage
    Dim ds1 As Data.DataTable
    Dim dt2 As New DataTable
    Dim DL As New WelfareActivityDL
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim batchId As Integer = Request.QueryString.Get("batchId")
        Dim Scholarship As Integer = Request.QueryString.Get("Scholarship")
        

        QueryStr.GetValue(Page.Request, Prop)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Anchala on 28 Sep 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "WelfareActivityR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim WelfareActivityR, Batch, StdCode, Marks, ParentIncome, SlNo, StdName, ScholarshipName As String
        WelfareActivityR = dt2.Rows(0).Item("Default_Text").ToString()
        Batch = dt2.Rows(1).Item("Default_Text").ToString()
        StdCode = dt2.Rows(2).Item("Default_Text").ToString()
        SlNo = dt2.Rows(3).Item("Default_Text").ToString()
        Marks = dt2.Rows(4).Item("Default_Text").ToString()
        ParentIncome = dt2.Rows(5).Item("Default_Text").ToString()
        ScholarshipName = dt2.Rows(6).Item("Default_Text").ToString()
        StdName = dt2.Rows(7).Item("Default_Text").ToString()

        dt1 = WelfareActivityDL.RptWelfareActivity(batchId, Scholarship)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_WelfareActivity.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_WefareActivityReport", dt1)

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("WelfareActivityR", WelfareActivityR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Batch", Batch, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Marks", Marks, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ParentIncome", ParentIncome, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ScholarshipName", ScholarshipName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))

                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                dt2 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblErrorMsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt2)
        e.DataSources.Add(rptDataSource)
    End Sub

End Class
