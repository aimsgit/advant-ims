
Partial Class frmMonthlySalary
    Inherits BasePage
    Dim BLL As New BLPayroll

    'Commented by Nethra during Build 13-Apr-2012
    'Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    If Not IsPostBack Then
    '        gvMonthlyDeatilsPayRoll.DataSource = BLL.GetMonthly_Details
    '        gvMonthlyDeatilsPayRoll.DataBind()
    '    End If
    'End Sub

    'Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
    '    Response.Redirect("frmGenerateMontSalarySlip.aspx")
    'End Sub

    'Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    'BLL.Delete()
    '    Dim dt As New DataTable
    '    Dim inst, Brch As Integer
    '    Dim monthlySalary As New Update_Mont_Payroll_Details
    '    Dim monthlySalaryTbl As New GlobalDataSet.Month_Details_PayrollDataTable
    '    For Each row As GridViewRow In gvMonthlyDeatilsPayRoll.Rows
    '        Dim monthlySalaryRow As GlobalDataSet.Month_Details_PayrollRow = monthlySalaryTbl.NewMonth_Details_PayrollRow
    '        monthlySalaryRow.E_ID = gvMonthlyDeatilsPayRoll.DataKeys(row.RowIndex).Value

    '        dt = BLL.GetInstBrch(monthlySalaryRow.E_ID)
    '        inst = dt.Rows(0)("Institute_ID").ToString()
    '        Brch = dt.Rows(0)("Branch_ID").ToString()

    '        monthlySalaryRow.Institute_ID = inst
    '        monthlySalaryRow.Branch_ID = Brch
    '        If CType(row.FindControl("txtWorkDays"), TextBox).Text = "" Then
    '            monthlySalaryRow.WorkDay = 0
    '        Else
    '            monthlySalaryRow.WorkDay = CType(row.FindControl("txtWorkDays"), TextBox).Text
    '        End If

    '        If CType(row.FindControl("txtAdvStlDeduction"), TextBox).Text = "" Then
    '            monthlySalaryRow.AdvStlDeduction = 0
    '        Else
    '            monthlySalaryRow.AdvStlDeduction = CType(row.FindControl("txtAdvStlDeduction"), TextBox).Text
    '        End If

    '        If CType(row.FindControl("txtTaxDeduction"), TextBox).Text = "" Then
    '            monthlySalaryRow.TaxDeduction = 0
    '        Else
    '            monthlySalaryRow.TaxDeduction = CType(row.FindControl("txtTaxDeduction"), TextBox).Text
    '        End If

    '        If CType(row.FindControl("txtITTaxDeduction"), TextBox).Text = "" Then
    '            monthlySalaryRow.ITTaxDeduction = 0
    '        Else
    '            monthlySalaryRow.ITTaxDeduction = CType(row.FindControl("txtITTaxDeduction"), TextBox).Text
    '        End If

    '        If CType(row.FindControl("txtOtherDeduction"), TextBox).Text = "" Then
    '            monthlySalaryRow.OtherDeduction = 0
    '        Else
    '            monthlySalaryRow.OtherDeduction = CType(row.FindControl("txtOtherDeduction"), TextBox).Text
    '        End If

    '        If CType(row.FindControl("txtWorkDays"), TextBox).Text = "" Then
    '            monthlySalaryRow.WorkDay = 0
    '        Else
    '            monthlySalaryRow.WorkDay = CType(row.FindControl("txtWorkDays"), TextBox).Text
    '        End If

    '        If CType(row.FindControl("txtIncentives"), TextBox).Text = "" Then
    '            monthlySalaryRow.Incentives = 0
    '        Else
    '            monthlySalaryRow.Incentives = CType(row.FindControl("txtIncentives"), TextBox).Text
    '        End If


    '        If CType(row.FindControl("txtRemarks"), TextBox).Text = "" Then
    '            monthlySalaryRow.Remarks = 0
    '        Else
    '            monthlySalaryRow.Remarks = CType(row.FindControl("txtRemarks"), TextBox).Text
    '        End If

    '        If CType(row.FindControl("txtOtherPay"), TextBox).Text = "" Then
    '            monthlySalaryRow.OtherPay = 0
    '        Else
    '            monthlySalaryRow.OtherPay = CType(row.FindControl("txtOtherPay"), TextBox).Text
    '        End If

    '        monthlySalaryTbl.AddMonth_Details_PayrollRow(monthlySalaryRow)
    '        DataMonthlySalary.DelMonthlyDetPayroll(monthlySalaryRow.E_ID)
    '    Next

    '    'monthlySalary.UpdateWithTransaction(monthlySalaryTbl)
    '    Dim alert As String = "alert('Successfully Saved ');"
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", alert, True)
    'End Sub
    '<System.Web.Services.WebMethod()> _
    'Public Shared Sub AbandonSession()
    '    Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    'End Sub
End Class
