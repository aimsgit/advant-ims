
Partial Class RptStudentLogBookV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLStudentLogBook
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim BatchID, StdId, LogID As Integer
        Dim BranchCode As String
        Dim fromdate, todate As Date
        Try
            Dim LanguageID As Integer
            Dim FormName As String
            ''Multilingual Conversion  By: Niraj on 23 Jan 2014
            If Session("LanguageID") = "" Then
                LanguageID = 1
            Else
                LanguageID = Session("LanguageID")
            End If
            FormName = "STDLogBookR"
            dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
            Dim STDLogBookR, FromDateN, ToDateN, SlNo, DateN, LogType, BatchN, FacultyN, Feedback As String
            Dim StdCode, StdName As String

            STDLogBookR = dt2.Rows(0).Item("Default_Text").ToString()
            FromDateN = dt2.Rows(1).Item("Default_Text").ToString()
            ToDateN = dt2.Rows(2).Item("Default_Text").ToString()
            SlNo = dt2.Rows(3).Item("Default_Text").ToString()
            DateN = dt2.Rows(4).Item("Default_Text").ToString()
            LogType = dt2.Rows(5).Item("Default_Text").ToString()
            BatchN = dt2.Rows(6).Item("Default_Text").ToString()
            FacultyN = dt2.Rows(7).Item("Default_Text").ToString()
            Feedback = dt2.Rows(8).Item("Default_Text").ToString()
            StdCode = dt2.Rows(9).Item("Default_Text").ToString()
            StdName = dt2.Rows(10).Item("Default_Text").ToString()


            If Session("LoginType") = "Employee" Then
                BatchID = Request.QueryString.Get("BatchID")
                StdId = Request.QueryString.Get("StdID")
                LogID = Request.QueryString.Get("LogID")
                fromdate = Request.QueryString.Get("FromDate")
                todate = Request.QueryString.Get("ToDate")

            ElseIf Session("LoginType") = "Others" Then
                QueryStr.GetValue(Page.Request, Prop)
                dt1 = DL.RptGetStudentParentLog()
                StdId = dt1.Rows(0).Item("STD_ID").ToString
                BranchCode = dt1.Rows(0).Item("BranchCode").ToString
                BatchID = dt1.Rows(0).Item("Batch_No").ToString
                LogID = 0
                fromdate = "01-01-1900"
                todate = "01-01-4000"
            End If
            QueryStr.GetValue(Page.Request, Prop)
            dt1 = DL.RptGetStudentLog(BatchID, StdId, LogID, fromdate, todate)
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptStudentLogBook.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_StudentLogBook", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", fromdate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", todate, False))

                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("STDLogBookR", STDLogBookR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDateN", FromDateN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDateN", ToDateN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DateN", DateN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("LogType", LogType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BatchN", BatchN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FacultyN", FacultyN, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Feedback", Feedback, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdCode", StdCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StdName", StdName, False))
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
        'Dim Message As String
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