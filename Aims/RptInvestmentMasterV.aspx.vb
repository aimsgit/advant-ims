
Partial Class RptInvestmentMasterV
    Inherits BasePage
    Dim ds1 As DataTable
    Dim Prop As New QureyStringP
    Dim obj As New SelfDetailsB
    Dim dt1, dt2 As New DataTable
    'Code written by Niraj for Multilingual on 05 Sep 2013
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim DL As New DLInvestmentMasterReport
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim fromdate As String = Request.QueryString.Get("FromDate")
        Dim todate As String = Request.QueryString.Get("ToDate")
        Dim Investment As String = Request.QueryString.Get("InvestmentType")
        Dim Bank As String = Request.QueryString.Get("Bank")
        Dim ROI As String = Request.QueryString.Get("ROI")
        Dim BalAmt As String = Request.QueryString.Get("BalAmt")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.Rpt_Investment(fromdate, todate, Investment, Bank, ROI, BalAmt)

        Dim LanguageID As Integer
        Dim FormName As String
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "EndowmentDepositMasterR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim EndowmentDepositMasterR, BranchType, BranchName, StartDate, EndDate, SlNo, SourceOfFund, InvstAmount, InvstType As String
        Dim InvstStDate, InvstMaturityDate, Banks, RateOfInterest, InterestAmt, AdminCost, Total, AdminAmount, BalanceAmt, Remarks As String
        EndowmentDepositMasterR = dt2.Rows(0).Item("Default_Text").ToString()
        BranchType = dt2.Rows(1).Item("Default_Text").ToString()
        BranchName = dt2.Rows(2).Item("Default_Text").ToString()
        StartDate = dt2.Rows(3).Item("Default_Text").ToString()
        EndDate = dt2.Rows(4).Item("Default_Text").ToString()
        SlNo = dt2.Rows(5).Item("Default_Text").ToString()
        SourceOfFund = dt2.Rows(6).Item("Default_Text").ToString()
        InvstAmount = dt2.Rows(7).Item("Default_Text").ToString()
        InvstType = dt2.Rows(8).Item("Default_Text").ToString()
        InvstStDate = dt2.Rows(9).Item("Default_Text").ToString()
        InvstMaturityDate = dt2.Rows(10).Item("Default_Text").ToString()
        Banks = dt2.Rows(11).Item("Default_Text").ToString()
        RateOfInterest = dt2.Rows(12).Item("Default_Text").ToString()
        InterestAmt = dt2.Rows(13).Item("Default_Text").ToString()
        AdminCost = dt2.Rows(14).Item("Default_Text").ToString()
        AdminAmount = dt2.Rows(15).Item("Default_Text").ToString()
        BalanceAmt = dt2.Rows(16).Item("Default_Text").ToString()
        Remarks = dt2.Rows(17).Item("Default_Text").ToString()
        Total = dt2.Rows(18).Item("Default_Text").ToString()
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "RptInvestmentMaster.rdlc"
                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_InvestmentMaster", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndowmentDepositMasterR", EndowmentDepositMasterR, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FromDate", fromdate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ToDate", todate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchType", BranchType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BranchName", BranchName, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("StartDate", StartDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndDate", EndDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SourceOfFund", SourceOfFund, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("InvstAmount", InvstAmount, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("InvstType", InvstType, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("InvstStDate", InvstStDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("InvstMaturityDate", InvstMaturityDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Banks", Banks, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("RateOfInterest", RateOfInterest, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("InterestAmt", InterestAmt, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AdminCost", AdminCost, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AdminAmt", AdminAmount, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BalanceAmt", BalanceAmt, False))
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
    ''Code Written for Multilingual By Niraj on 06th sep 2013
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
