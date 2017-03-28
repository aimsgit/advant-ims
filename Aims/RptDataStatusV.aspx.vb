
Partial Class RptDataStatusV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim obj As New SelfDetailsB
        Dim BL As New BLDeptDashboard
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Try
            Dim dt As New Data.DataTable
            Dim Batch As Integer = Request.QueryString.Get("Batch")
            Dim Semester As Integer = Request.QueryString.Get("Semester")
            Dim Subject As Integer = Request.QueryString.Get("Subject")

            QueryStr.GetValue(Page.Request, Prop)
            dt1 = DLStdMarksElective.ViewDataStatus(Batch, Semester, Subject)
            Dim LanguageID As Integer
            Dim FormName As String
            ''Multilingual Conversion  By: Niraj on 23 Dec 2013
            If Session("LanguageID") = "" Then
                LanguageID = 1
            Else
                LanguageID = Session("LanguageID")
            End If
            FormName = "DataEntryR"
            dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
            Dim DataEntryR, BatchN, SemesterN, SubjectN, SlNo, AssmntType, AssmntDate, Lock As String

            DataEntryR = dt2.Rows(0).Item("Default_Text").ToString()
            BatchN = dt2.Rows(1).Item("Default_Text").ToString()
            SemesterN = dt2.Rows(2).Item("Default_Text").ToString()
            SubjectN = dt2.Rows(3).Item("Default_Text").ToString()
            SlNo = dt2.Rows(4).Item("Default_Text").ToString()
            AssmntType = dt2.Rows(5).Item("Default_Text").ToString()
            AssmntDate = dt2.Rows(6).Item("Default_Text").ToString()
            Lock = dt2.Rows(7).Item("Default_Text").ToString()
           
            If dt1.Rows.Count > 0 Then

                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptDataStatus.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_ViewMarksDataEntryStatus", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DataEntryR", DataEntryR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SemesterN", SemesterN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SubjectN", SubjectN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssmntType", AssmntType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AssmntDate", AssmntDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Lock", Lock, False))
                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt1 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                lblErrorMsg.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            lblErrorMsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt1)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 23th Dec 2013
    ''Retriving the text of controls based on Language
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
