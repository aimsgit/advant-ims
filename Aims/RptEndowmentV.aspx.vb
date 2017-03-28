
Partial Class RptEndowmentV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable

    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLEndowmentReportV
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim sponsor As String = Request.QueryString.Get("SponsorID")
        Dim fromdate As Date = Request.QueryString.Get("fromdate")
        Dim todate As String = Request.QueryString.Get("todate")
        QueryStr.GetValue(Page.Request, Prop)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 11 Sep 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "EndowmentMasterR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim EndowmentMasterR, BranchType, BranchName, FDate, TDate, SlNo, Donor, DonorCode, Amount As String
        Dim Currency, ReceivedDate, ChequeNo, Bank, Remarks, Total As String
        EndowmentMasterR = dt2.Rows(0).Item("Default_Text").ToString()
        BranchType = dt2.Rows(1).Item("Default_Text").ToString()
        BranchName = dt2.Rows(2).Item("Default_Text").ToString()
        FDate = dt2.Rows(3).Item("Default_Text").ToString()
        TDate = dt2.Rows(4).Item("Default_Text").ToString()
        SlNo = dt2.Rows(5).Item("Default_Text").ToString()
        Donor = dt2.Rows(6).Item("Default_Text").ToString()
        DonorCode = dt2.Rows(7).Item("Default_Text").ToString()
        Amount = dt2.Rows(8).Item("Default_Text").ToString()
        Currency = dt2.Rows(9).Item("Default_Text").ToString()
        ReceivedDate = dt2.Rows(10).Item("Default_Text").ToString()
        ChequeNo = dt2.Rows(11).Item("Default_Text").ToString()
        Bank = dt2.Rows(12).Item("Default_Text").ToString()
        Remarks = dt2.Rows(13).Item("Default_Text").ToString()
        Total = dt2.Rows(14).Item("Default_Text").ToString()
        dt1 = DL.Rpt_sponsor(sponsor, fromdate, todate)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptEndowment.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_SponsorEndowment", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndowmentMasterR", EndowmentMasterR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", fromdate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", todate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FDate", FDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TDate", TDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Donor", Donor, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DonorCode", DonorCode, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Amount", Amount, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Currency", Currency, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ReceivedDate", ReceivedDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ChequeNo", ChequeNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Bank", Bank, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))


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
    ''Code Written for Multilingual By Niraj on 11th sep 2013
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
