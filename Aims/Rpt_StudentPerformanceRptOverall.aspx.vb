
Partial Class Rpt_StudentPerformanceRptOverall
    Inherits System.Web.UI.Page
    Dim ds1, dt2 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1, ParentDt As New DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dl As New DLReportsR
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Batch As Integer
        Dim Student As String

        Batch = Request.QueryString.Get("BatchId")
        Student = Request.QueryString.Get("student")

        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 16 Jan 2014
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "STDPerformanceOvrR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim STDPerformanceOvrR, Name, SemesterN, BatchN, Percentage, StdCode As String

        STDPerformanceOvrR = dt2.Rows(0).Item("Default_Text").ToString()
        Name = dt2.Rows(1).Item("Default_Text").ToString()
        StdCode = dt2.Rows(2).Item("Default_Text").ToString()
        BatchN = dt2.Rows(3).Item("Default_Text").ToString()
        Percentage = dt2.Rows(4).Item("Default_Text").ToString()
        SemesterN = dt2.Rows(5).Item("Default_Text").ToString()
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = dl.Rpt_StudentPerformanceRptOverall(Batch, Student)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_StudentPerformanceRptOverall.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentPercentageOverall", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDPerformanceOvrR", STDPerformanceOvrR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Name", Name, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Percentage", Percentage, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemesterN", SemesterN, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                'Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("sem", Sem, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("pension", pension, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("month", Month, False))
                'paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("year", Year, False))
                'ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = "No Records to Display."
            End If
            'modified by Nitin 03/01/2012
        Catch ex As Exception
            lblmsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
End Class

