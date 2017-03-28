
Partial Class RptNewStudReport
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLReport
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.RptStudentReport()
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 09 Dec 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "TwoUSN"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim TwoUSN, SlNo, StdName, OldCode, OldCourse, OldBatch, NewStdCode, NewCourse, NewBatch As String
        
        TwoUSN = dt2.Rows(0).Item("Default_Text").ToString()
        SlNo = dt2.Rows(1).Item("Default_Text").ToString()
        StdName = dt2.Rows(2).Item("Default_Text").ToString()
        OldCode = dt2.Rows(3).Item("Default_Text").ToString()
        OldCourse = dt2.Rows(4).Item("Default_Text").ToString()
        OldBatch = dt2.Rows(5).Item("Default_Text").ToString()
        NewStdCode = dt2.Rows(6).Item("Default_Text").ToString()
        NewCourse = dt2.Rows(7).Item("Default_Text").ToString()
        NewBatch = dt2.Rows(8).Item("Default_Text").ToString()
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptNewStudReport.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudReportWithTwoUSN", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TwoUSN", TwoUSN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("OldCode", OldCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("OldCourse", OldCourse, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("OldBatch", OldBatch, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("NewStdCode", NewStdCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("NewCourse", NewCourse, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("NewBatch", NewBatch, False))

                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                ds1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblmsg.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", ds1)
        e.DataSources.Add(rptDataSource)
    End Sub
  
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
End Class