
Partial Class Rpt_ItemsummariesV
    Inherits BasePage
    Dim ds1 As Data.DataTable
    Dim dt2, dt4 As New DataTable
    Dim DL As New DLAnnualSalaryStatment
    Protected Sub ReportViewer1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReportViewer1.Init
        Dim dt1 As DataTable
        Dim Prop As New QureyStringP
        Dim obj As New SelfDetailsB
        Dim dt As New Microsoft.Reporting.WebForms.ReportDataSource
        Dim Year As String = Request.QueryString.Get("Year")
        Dim Month As String = Request.QueryString.Get("Month")
        Dim Dept As String = Request.QueryString.Get("Dept")
      
        QueryStr.GetValue(Page.Request, Prop)

        Dim FormName As String
        
        FormName = "ItemSummaryR"
        dt2 = GlobalFunction.GetChangeLabelReport(FormName)
        Dim ItemSummary, BasicP, DA, HRA, MedA, SpclA, Incentives, TransA, Bonus, Reimb, MiscP, OtherMonth As String
        Dim TotalE, PFD, ProfTax, ITTax, AdvSti, LoanD, SalaryAdv, TDSRefund, MiscD, VPF, LOP, OtherD, TotalD, BalSalary As String
        ItemSummary = dt2.Rows(0).Item("Default_Text").ToString()
        BasicP = dt2.Rows(1).Item("Default_Text").ToString()
        DA = dt2.Rows(2).Item("Default_Text").ToString()
        HRA = dt2.Rows(3).Item("Default_Text").ToString()
        MedA = dt2.Rows(4).Item("Default_Text").ToString()
        SpclA = dt2.Rows(5).Item("Default_Text").ToString()
        Incentives = dt2.Rows(6).Item("Default_Text").ToString()
        TransA = dt2.Rows(7).Item("Default_Text").ToString()
        Bonus = dt2.Rows(8).Item("Default_Text").ToString()
        Reimb = dt2.Rows(9).Item("Default_Text").ToString()
        MiscP = dt2.Rows(10).Item("Default_Text").ToString()
        OtherMonth = dt2.Rows(11).Item("Default_Text").ToString()
        TotalE = dt2.Rows(12).Item("Default_Text").ToString()
        PFD = dt2.Rows(13).Item("Default_Text").ToString()
        ProfTax = dt2.Rows(14).Item("Default_Text").ToString()
        ITTax = dt2.Rows(15).Item("Default_Text").ToString()
        AdvSti = dt2.Rows(16).Item("Default_Text").ToString()
        LoanD = dt2.Rows(17).Item("Default_Text").ToString()
        SalaryAdv = dt2.Rows(18).Item("Default_Text").ToString()
        TDSRefund = dt2.Rows(19).Item("Default_Text").ToString()
        MiscD = dt2.Rows(20).Item("Default_Text").ToString()
        VPF = dt2.Rows(21).Item("Default_Text").ToString()
        LOP = dt2.Rows(22).Item("Default_Text").ToString()
        OtherD = dt2.Rows(23).Item("Default_Text").ToString()
        TotalD = dt2.Rows(24).Item("Default_Text").ToString()
        BalSalary = dt2.Rows(25).Item("Default_Text").ToString()
        dt1 = DLAnnualSalaryStatment.Rptitemsummaries(Year, Month, Dept)
        Try
            If dt1.Rows.Count > 0 Then
                Me.ReportViewer1.ProcessingMode = Microsoft.Reporting.WebForms.ProcessingMode.Local
                Me.ReportViewer1.LocalReport.ReportPath = "Rpt_ItemSummaries.rdlc"

                dt = New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_Rpt_Itemsummaries", dt1)

                Dim paramList As New Generic.List(Of Microsoft.Reporting.WebForms.ReportParameter)
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ItemSummary", ItemSummary, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BasicP", BasicP, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("DA", DA, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("HRA", HRA, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("MedA", MedA, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SpclA", SpclA, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Incentives", Incentives, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TransA", TransA, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Bonus", Bonus, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("Reimb", Reimb, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("MiscP", MiscP, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("OtherMonth", OtherMonth, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalE", TotalE, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("PFD", PFD, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ProfTax", ProfTax, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("ITTax", ITTax, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("AdvSti", AdvSti, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("LoanD", LoanD, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("SalaryAdv", SalaryAdv, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TDSRefund", TDSRefund, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("MiscD", MiscD, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("VPF", VPF, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("LOP", LOP, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("OtherD", OtherD, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("TotalD", TotalD, False))
                paramList.Add(New Microsoft.Reporting.WebForms.ReportParameter("BalSalary", BalSalary, False))
                'ReportViewer1.LocalReport.SetParameters(paramList)

                'ReportViewer1.LocalReport.DataSources.Clear()
                'Me.ReportViewer1.LocalReport.DataSources.Add(dm)
                'ReportViewer1.LocalReport.Refresh()

                'dt = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                'AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
                ReportViewer1.LocalReport.SetParameters(paramList)

                ReportViewer1.LocalReport.DataSources.Clear()
                Me.ReportViewer1.LocalReport.DataSources.Add(dt)
                ReportViewer1.LocalReport.Refresh()
                dt4 = obj.RPT_GetSelfDeatilsByBranch(Request.QueryString(1))
                AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEvent
            Else
                lblErrorMsg.Text = "No records to display."
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Error While loading Report, Enter all Mandatory fields and try again. "
        End Try
    End Sub
    Sub SubreportProcessingEvent(ByVal sender As Object, ByVal e As Microsoft.Reporting.WebForms.SubreportProcessingEventArgs)
        Dim rptDataSource As New Microsoft.Reporting.WebForms.ReportDataSource("GlobalDataSet_Proc_RPT_GetSelfDetailByUID", dt4)
        e.DataSources.Add(rptDataSource)
    End Sub
    ''Code Written for Multilingual By Niraj on 07th Sep
    ''Retriving the text of controls based on Language
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt3 As DataTable
        dt3 = Session("ValidationTable")
        If dt3 Is Nothing Then
            Response.Redirect("LogIn.aspx")
        End If
        Dim X As Integer = dt3.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt3.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt3.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
End Class
