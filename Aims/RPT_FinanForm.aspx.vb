Partial Class RPT_FinanForm
    Inherits BasePage
    Dim BLL As New AccountHeadManager
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then
            msginfo.Text = ""
            Dim FromDate As Date
            Dim ToDate As Date
            Dim PR As String
            Dim AC As String

            PR = DDLProjectName.SelectedValue
            FromDate = txtStartDate.Text
            txtStartDate.Text = Format(FromDate, "dd-MMM-yyyy")
            ToDate = txtEndDate.Text
            If FromDate > ToDate Then
                msginfo.Text = "From date should be greater than To date."
                txtEndDate.Focus()
                Exit Sub
            End If
            Dim AH As String
            AH = cmbAGOne.SelectedValue
            AC = cmbAcctOne.SelectedValue
            Dim qrystring As String = "RptGeneralLedgerV.aspx?" & QueryStr.Querystring() & "&AH=" & AH & "&PR=" & PR & "&FinStartDate=" & FromDate & "&FinEndDate=" & ToDate & "&AC=" & AC
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        Else
            msginfo.Text = "You do not have Read Privilage."
        End If
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
  
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub cmbAGOne_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAGOne.SelectedIndexChanged
        cmbAcctOne_fill(cmbAGOne.SelectedValue)
        cmbAcctOne.Focus()
    End Sub
    Sub cmbAcctOne_fill(ByVal Id As Int32)
        If cmbAGOne.SelectedIndex > -1 Then
            cmbAcctOne.DataSource = BLL.GetAcctsubgroupByAcctgroupID(Id)
            cmbAcctOne.DataBind()
        End If
    End Sub
End Class
'Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
'    Dim StartDate As Date = CDate(Me.txtStartDate.Text)
'    Dim EndDate As Date = CDate(Me.txtEndDate.Text)
'    Dim qrystring As String = ""
'    Dim qry_str As String = "&FinStartDate=" & StartDate & "&FinEndDate=" & EndDate & "&BranchCode=" & Session("BranchCode")
'    'If Session("RptFrmTitleName") = "Balance Sheet Report" Then
'    '    qrystring = ConfigurationManager.AppSettings("ReportPath") & "BalanceSheetV.aspx?" & QueryStr.Querystring() & qry_str
'    'ElseIf Session("RptFrmTitleName") = "Bank Book Report" Then
'    '    qrystring = ConfigurationManager.AppSettings("ReportPath") & "BankBookV.aspx?" & QueryStr.Querystring() & qry_str
'    'ElseIf Session("RptFrmTitleName") = "Cash Book Report" Then
'    '    qrystring = ConfigurationManager.AppSettings("ReportPath") & "CashBookV.aspx?" & QueryStr.Querystring() & qry_str
'    'ElseIf Session("RptFrmTitleName") = "GENERAL LEDGER" Then
'    qrystring = ConfigurationManager.AppSettings("ReportPath") & "RptGeneralLedgerV.aspx?" & QueryStr.Querystring() & qry_str
'    'ElseIf Session("RptFrmTitleName") = "General Party Ledger" Then
'    'qrystring = "RptGeneralPartyLedgerV.aspx?" & QueryStr.Querystring() & qry_str
'    'ElseIf Session("RptFrmTitleName") = "Income & Expenditure Report" Then
'    'qrystring = ConfigurationManager.AppSettings("ReportPath") & "RptIncomeExpendtr.aspx?" & QueryStr.Querystring() & qry_str
'    'ElseIf Session("RptFrmTitleName") = "BRS" Then
'    'qrystring = ConfigurationManager.AppSettings("ReportPath") & "frmBankReconciliation.aspx?" & QueryStr.Querystring() & qry_str
'    'End If
'    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
'End Sub