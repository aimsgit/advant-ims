
Partial Class RptEndowmentDetailsV
    Inherits System.Web.UI.Page
    Dim obj As New SelfDetailsB
    Dim dt1, dt, dt2 As New DataTable
    Dim Prop As New QureyStringP
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init

        Dim DL As New DLEndowment
        Dim dm As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim fromdate As Date = Request.QueryString.Get("fromdate")
        Dim todate As String = Request.QueryString.Get("todate")
        QueryStr.GetValue(Page.Request, Prop)
        dt1 = DL.RptGetEndowmentDetails(fromdate, todate)
        Dim LanguageID As Integer
        Dim FormName As String
        ''Multilingual Conversion  By: Niraj on 11 Sep 2013
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        FormName = "EndowmentDetailsR"
        dt2 = GlobalFunction.EnquiryDetailsHeading(FormName, LanguageID)
        Dim EndowmentDetailsR, FDate, TDate, SlNo, Donor, Contact, DepositAmt As String
        Dim Program, ChequeNo, ProgramStDate, ProgramEndDate, Interest, AdminExp, Balance, Remarks, Total As String

        FDate = dt2.Rows(0).Item("Default_Text").ToString()
        TDate = dt2.Rows(1).Item("Default_Text").ToString()
        SlNo = dt2.Rows(2).Item("Default_Text").ToString()
        Donor = dt2.Rows(3).Item("Default_Text").ToString()
        Contact = dt2.Rows(4).Item("Default_Text").ToString()
        DepositAmt = dt2.Rows(5).Item("Default_Text").ToString()
        Program = dt2.Rows(6).Item("Default_Text").ToString()
        ChequeNo = dt2.Rows(7).Item("Default_Text").ToString()
        ProgramStDate = dt2.Rows(8).Item("Default_Text").ToString()
        ProgramEndDate = dt2.Rows(9).Item("Default_Text").ToString()
        Interest = dt2.Rows(10).Item("Default_Text").ToString()
        AdminExp = dt2.Rows(11).Item("Default_Text").ToString()
        Balance = dt2.Rows(12).Item("Default_Text").ToString()
        Remarks = dt2.Rows(13).Item("Default_Text").ToString()
        Total = dt2.Rows(14).Item("Default_Text").ToString()
        EndowmentDetailsR = dt2.Rows(15).Item("Default_Text").ToString()
        Try
            If dt1.Rows.Count > 0 Then
                ReportViewer1.LocalReport.ReportPath = "RptEndowmentDetails.rdlc"
                dm = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Rpt_EndowmentDetails", dt1)
                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("fromdate", fromdate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("todate", todate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("FDate", FDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TDate", TDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SlNo", SlNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Donor", Donor, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Contact", Contact, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DepositAmt", DepositAmt, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Program", Program, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ChequeNo", ChequeNo, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ProgramStDate", ProgramStDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ProgramEndDate", ProgramEndDate, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Interest", Interest, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AdminExp", AdminExp, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Balance", Balance, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Remarks", Remarks, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Total", Total, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("EndowmentDetailsR", EndowmentDetailsR, False))

                ReportViewer1.LocalReport.SetParameters(paramList)
                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                ReportViewer1.LocalReport.Refresh()

                dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else

                lblmsg.Text = ValidationMessage(1023)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1074)
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt)
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
