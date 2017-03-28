
Partial Class FrmPayrollRulesEngine
    Inherits BasePage
    Dim EL As New ELPayrollRulesEngine
    Dim BL As New BLPayrollRulesEngine
    Dim dt, dt1 As New DataTable
    Dim BLL As New BLPayroll
    Dim ell As New EntPayroll
    Protected Sub btnRunUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRunUpdate.Click
        If Session("Privilages").ToString.Contains("W") Then
            Dim Gross, NetSalary, F1 As Double
            ell.Formula = ddlFormulaGroup.SelectedValue
            dt = BLL.GetPayrollRules(ell)
            ell.Year = ddlYear.SelectedItem.Text
            ell.Month = ddlMonth.SelectedItem.Text
            EL.Year = ddlYear.SelectedItem.Text
            EL.Month = ddlMonth.SelectedItem.Text
            dt1 = BLL.RptSalSlip(ell)
            If dt1.Rows.Count > 0 Then
                gvGenSalary.DataSource = dt1
                gvGenSalary.DataBind()
                gvGenSalary.Visible = True
            Else
                lblMsg.Text = "No Records to display"
                lblGreen.Text = ""
                gvGenSalary.Visible = False
            End If
            If dt.Rows.Count > 0 Then
                For Each R1 As GridViewRow In GvFormula.Rows
                    If CType(R1.FindControl("ChkPresent"), CheckBox).Checked = True Then
                        ell.Year = ddlYear.SelectedItem.Text
                        ell.Month = ddlMonth.SelectedItem.Text
                        EL.Year = ddlYear.SelectedItem.Text
                        EL.Month = ddlMonth.SelectedItem.Text
                        EL.Field = CType(R1.FindControl("ddlSelectF"), DropDownList).SelectedValue
                        dt1 = BLL.RptSalSlip(ell)
                        If dt1.Rows.Count > 0 Then
                            gvGenSalary.DataSource = dt1
                            gvGenSalary.DataBind()
                            gvGenSalary.Visible = True
                        Else
                            lblMsg.Text = "No Records to display"
                            gvGenSalary.Visible = False
                            lblGreen.Text = ""
                        End If
                        If CType(R1.FindControl("ddlCriteria"), DropDownList).SelectedValue = "N" Then
                            If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 1 Then
                                EL.iMS_id = 0
                                EL.Fixed = CType(R1.FindControl("txtFixed"), TextBox).Text
                                For Each rows As GridViewRow In gvGenSalary.Rows
                                    EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                    EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                    BL.UpdateRecord(EL)
                                Next
                            End If
                            If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 2 Then
                                EL.OnGross = CType(R1.FindControl("txtGross"), TextBox).Text
                                For Each rows As GridViewRow In gvGenSalary.Rows
                                    EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                    EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                    Gross = CType(rows.FindControl("lblGSalary"), Label).Text
                                    EL.Fixed = Gross * (EL.OnGross / 100)
                                    BL.UpdateRecord(EL)
                                Next
                            End If
                            If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 3 Then
                                EL.OnNet = CType(R1.FindControl("txtNet"), TextBox).Text
                                For Each rows As GridViewRow In gvGenSalary.Rows
                                    EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                    EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                    NetSalary = CType(rows.FindControl("lblNSalary"), Label).Text
                                    EL.Fixed = NetSalary * (EL.OnNet / 100)
                                    BL.UpdateRecord(EL)
                                Next
                            End If
                            If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 4 Then
                                EL.ItemField = CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue
                                EL.ItemValue = CType(R1.FindControl("txtValueOfField"), TextBox).Text
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "Basicpay" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblBasicPay"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "SpecialAllw" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblSplAllowance"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "HouseRentAllw" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblHRA"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "MedicalAllw" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblMedical"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "TransportAllw" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblTAllowance"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "DearnessAllw" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblDearnessAllw"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "Incentives" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblInc"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "MiscellaneousPay" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblMisPay"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "Bonus" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblBonus"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "Reimbursements" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblReimbursements"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "OtherMonthlyPayments" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblOtherMonthlyPayments"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "SalaryAdv" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblSalaryAdv"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "ProfTaxDed" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblProfTaxDed"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "ITTaxDeduction" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblITTaxDeduction"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "AdvStlDeduction" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblAdvstlDedu"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "OtherDeduction" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblOdeu"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "MiscDeds" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblMiscDeds"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "TransportDed" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblTransportDed"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "LoadDed" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblLoadDed"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "TDSRefund" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblTDSRefund"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "PFDed" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblPFDedc"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "GrossSalary" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblGSalary"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "NetSalary" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblNSalary"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                                If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "LOPay" Then
                                    For Each rows As GridViewRow In gvGenSalary.Rows
                                        EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows.FindControl("lblLOPay"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)
                                    Next
                                End If
                            End If
                            EL.iMS_id = 0
                            BL.updateNetGross(EL)
                        Else
                            For Each rows1 As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows1.FindControl("lblId"), Label).Text
                                Select Case CType(R1.FindControl("ddlCriteria"), DropDownList).SelectedValue = "Y"
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "Basicpay"
                                        F1 = CType(rows1.FindControl("lblBasicPay"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "SpecialAllw"
                                        F1 = CType(rows1.FindControl("lblSplAllowance"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "HouseRentAllw"
                                        F1 = CType(rows1.FindControl("lblHRA"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "MedicalAllw"
                                        F1 = CType(rows1.FindControl("lblMedical"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "TransportAllw"
                                        F1 = CType(rows1.FindControl("lblTAllowance"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "DearnessAllw"
                                        F1 = CType(rows1.FindControl("lblDearnessAllw"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "Incentives"
                                        F1 = CType(rows1.FindControl("lblInc"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "MiscellaneousPay"
                                        F1 = CType(rows1.FindControl("lblMisPay"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "Bonus"
                                        F1 = CType(rows1.FindControl("lblBonus"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "Reimbursements"
                                        F1 = CType(rows1.FindControl("lblReimbursements"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "OtherMonthlyPayments"
                                        F1 = CType(rows1.FindControl("lblOtherMonthlyPayments"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "SalaryAdv"
                                        F1 = CType(rows1.FindControl("lblSalaryAdv"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "ProfTaxDed"
                                        F1 = CType(rows1.FindControl("lblProfTaxDed"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "ITTaxDeduction"
                                        F1 = CType(rows1.FindControl("lblITTaxDeduction"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "AdvStlDeduction"
                                        F1 = CType(rows1.FindControl("lblAdvstlDedu"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "OtherDeduction"
                                        F1 = CType(rows1.FindControl("lblOdeu"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "MiscDeds"
                                        F1 = CType(rows1.FindControl("lblMiscDeds"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "TransportDed"
                                        F1 = CType(rows1.FindControl("lblTransportDed"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "LoadDed"
                                        F1 = CType(rows1.FindControl("lblLoadDed"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "PFDed"
                                        F1 = CType(rows1.FindControl("lblBasicPay"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "GrossSalary"
                                        F1 = CType(rows1.FindControl("lblGSalary"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "NetSalary"
                                        F1 = CType(rows1.FindControl("lblNSalary"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "LOPay"
                                        F1 = CType(rows1.FindControl("lblLOPay"), Label).Text
                                        GoTo lbls
                                    Case CType(R1.FindControl("ddlField"), DropDownList).SelectedValue = "TDSRefund"
                                        F1 = CType(rows1.FindControl("lblTDSRefund"), Label).Text
                                        GoTo lbls
                                End Select

lbls:



                                If CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = ">" And CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = "<" Then
                                    If F1 > CType(R1.FindControl("txtValue1"), TextBox).Text And F1 < CType(R1.FindControl("txtValue2"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                    End If
                                    'End If
                                ElseIf CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = "<" And CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = ">" Then
                                    If F1 < CType(R1.FindControl("txtValue1"), TextBox).Text And F1 > CType(R1.FindControl("txtValue2"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                        'End If
                                    End If
                                ElseIf CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = ">=" And CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = "<=" Then
                                    If F1 >= CType(R1.FindControl("txtValue1"), TextBox).Text And F1 <= CType(R1.FindControl("txtValue2"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                    End If
                                    'End If
                                ElseIf CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = "<=" And CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = ">=" Then
                                    If F1 <= CType(R1.FindControl("txtValue1"), TextBox).Text And F1 >= CType(R1.FindControl("txtValue2"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                        'End If
                                    End If
                                ElseIf CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = "<" And CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = ">=" Then
                                    If F1 < CType(R1.FindControl("txtValue1"), TextBox).Text And F1 >= CType(R1.FindControl("txtValue2"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                        'End If
                                    End If
                                ElseIf CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = "<=" And CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = ">" Then
                                    If F1 <= CType(R1.FindControl("txtValue1"), TextBox).Text And F1 > CType(R1.FindControl("txtValue2"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                    End If
                                    'End If
                                    ''''''
                                ElseIf CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = ">" And CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = "<" Then
                                    If F1 > CType(R1.FindControl("txtValue2"), TextBox).Text And F1 < CType(R1.FindControl("txtValue1"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                        'End If
                                    End If
                                ElseIf CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = "<" And CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = ">" Then
                                    If F1 < CType(R1.FindControl("txtValue2"), TextBox).Text And F1 > CType(R1.FindControl("txtValue1"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                        'End If
                                    End If
                                ElseIf CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = ">=" And CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = "<=" Then
                                    If F1 >= CType(R1.FindControl("txtValue2"), TextBox).Text And F1 <= CType(R1.FindControl("txtValue1"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                        'End If
                                    End If
                                ElseIf CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = "<=" And CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = ">=" Then
                                    If F1 <= CType(R1.FindControl("txtValue2"), TextBox).Text And F1 >= CType(R1.FindControl("txtValue1"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                        'End If
                                    End If
                                ElseIf CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = "<" And CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = ">=" Then
                                    If F1 < CType(R1.FindControl("txtValue2"), TextBox).Text And F1 >= CType(R1.FindControl("txtValue1"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                        'End If
                                    End If
                                ElseIf CType(R1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = "<=" And CType(R1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = ">" Then
                                    If F1 <= CType(R1.FindControl("txtValue2"), TextBox).Text And F1 > CType(R1.FindControl("txtValue1"), TextBox).Text Then
                                        GoTo lbl1s
                                    Else
                                        GoTo lbl2s
                                    End If
                                End If
lbl1s:
                                If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 1 Then
                                    EL.iMS_id = CType(rows1.FindControl("lblId"), Label).Text
                                    EL.Fixed = CType(R1.FindControl("txtFixed"), TextBox).Text
                                    EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                    BL.UpdateRecord(EL)

                                End If
                                If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 2 Then
                                    EL.OnGross = CType(R1.FindControl("txtGross"), TextBox).Text
                                    Gross = CType(rows1.FindControl("lblGSalary"), Label).Text
                                    EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                    EL.Fixed = Gross * (EL.OnGross / 100)
                                    BL.UpdateRecord(EL)

                                End If
                                If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 3 Then
                                    EL.OnNet = CType(R1.FindControl("txtNet"), TextBox).Text
                                    NetSalary = CType(rows1.FindControl("lblNSalary"), Label).Text
                                    EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                    EL.Fixed = NetSalary * (EL.OnNet / 100)
                                    BL.UpdateRecord(EL)

                                End If
                                If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 4 Then
                                    EL.ItemField = CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue
                                    EL.ItemValue = CType(R1.FindControl("txtValueOfField"), TextBox).Text
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "Basicpay" Then
                                        F1 = CType(rows1.FindControl("lblBasicPay"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "SpecialAllw" Then
                                        F1 = CType(rows1.FindControl("lblSplAllowance"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "HouseRentAllw" Then
                                        F1 = CType(rows1.FindControl("lblHRA"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "MedicalAllw" Then
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows1.FindControl("lblMedical"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "TransportAllw" Then
                                        F1 = CType(rows1.FindControl("lblTAllowance"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "DearnessAllw" Then
                                        F1 = CType(rows1.FindControl("lblDearnessAllw"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "Incentives" Then
                                        F1 = CType(rows1.FindControl("lblInc"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "MiscellaneousPay" Then
                                        F1 = CType(rows1.FindControl("lblMisPay"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "Bonus" Then
                                        F1 = CType(rows1.FindControl("lblBonus"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "Reimbursements" Then
                                        F1 = CType(rows1.FindControl("lblReimbursements"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "OtherMonthlyPayments" Then
                                        F1 = CType(rows1.FindControl("lblOtherMonthlyPayments"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "SalaryAdv" Then
                                        F1 = CType(rows1.FindControl("lblSalaryAdv"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "ProfTaxDed" Then
                                        F1 = CType(rows1.FindControl("lblProfTaxDed"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "ITTaxDeduction" Then
                                        F1 = CType(rows1.FindControl("lblITTaxDeduction"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "AdvStlDeduction" Then
                                        F1 = CType(rows1.FindControl("lblAdvstlDedu"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "OtherDeduction" Then
                                        F1 = CType(rows1.FindControl("lblOdeu"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "MiscDeds" Then
                                        F1 = CType(rows1.FindControl("lblMiscDeds"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "TransportDed" Then
                                        F1 = CType(rows1.FindControl("lblTransportDed"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "LoadDed" Then
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        F1 = CType(rows1.FindControl("lblLoadDed"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "TDSRefund" Then
                                        F1 = CType(rows1.FindControl("lblTDSRefund"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "PFDed" Then
                                        F1 = CType(rows1.FindControl("lblPFDedc"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "GrossSalary" Then
                                        F1 = CType(rows1.FindControl("lblGSalary"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue = "NetSalary" Then
                                        F1 = CType(rows1.FindControl("lblNSalary"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                    If ddlOnitem.SelectedValue = "LOPay" Then
                                        F1 = CType(rows1.FindControl("lblLOPay"), Label).Text
                                        EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                        EL.Fixed = F1 * (EL.ItemValue / 100)
                                        BL.UpdateRecord(EL)

                                    End If
                                End If

lbl2s:
                                EL.iMS_id = CType(rows1.FindControl("lblId"), Label).Text
                                BL.updateNetGross(EL)
                            Next

                        End If
                    End If
                Next
            Else

                ell.Year = ddlYear.SelectedItem.Text
                ell.Month = ddlMonth.SelectedItem.Text
                EL.Year = ddlYear.SelectedItem.Text
                EL.Month = ddlMonth.SelectedItem.Text
                EL.Field = ddlItem.SelectedValue
                dt1 = BLL.RptSalSlip(ell)
                If dt1.Rows.Count > 0 Then
                    gvGenSalary.DataSource = dt1
                    gvGenSalary.DataBind()
                    gvGenSalary.Visible = True
                Else
                    lblMsg.Text = "No Records to display"
                    gvGenSalary.Visible = False
                End If
                If CheckCriteria.Checked = False Then
                    If rbSelect.SelectedValue = 1 Then
                        EL.iMS_id = 0
                        If txtFixed.Text = "" Then
                            EL.Fixed = 0
                        Else
                            EL.Fixed = txtFixed.Text
                        End If
                        For Each rows As GridViewRow In gvGenSalary.Rows
                            EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                            BL.UpdateRecord(EL)
                        Next
                    End If
                    If rbSelect.SelectedValue = 2 Then
                        If txtGross.Text = "" Then
                            EL.OnGross = 0
                        Else
                            EL.OnGross = txtGross.Text
                        End If
                        For Each rows As GridViewRow In gvGenSalary.Rows
                            EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                            Gross = CType(rows.FindControl("lblGSalary"), Label).Text
                            EL.Fixed = Gross * (EL.OnGross / 100)
                            BL.UpdateRecord(EL)
                        Next
                    End If
                    If rbSelect.SelectedValue = 3 Then
                        If txtNet.Text = "" Then
                            EL.OnNet = 0
                        Else
                            EL.OnNet = txtNet.Text
                        End If
                        For Each rows As GridViewRow In gvGenSalary.Rows
                            EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                            NetSalary = CType(rows.FindControl("lblNSalary"), Label).Text
                            EL.Fixed = NetSalary * (EL.OnNet / 100)
                            BL.UpdateRecord(EL)
                        Next
                    End If
                    If rbSelect.SelectedValue = 4 Then
                        EL.ItemField = ddlOnitem.SelectedValue
                        If txtItemValue.Text = "" Then
                            EL.ItemValue = 0
                        Else
                            EL.ItemValue = txtItemValue.Text
                        End If
                        If ddlOnitem.SelectedValue = "Basicpay" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblBasicPay"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "SpecialAllw" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblSplAllowance"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "HouseRentAllw" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblHRA"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "MedicalAllw" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblMedical"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "TransportAllw" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblTAllowance"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "DearnessAllw" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblDearnessAllw"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "Incentives" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblInc"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "MiscellaneousPay" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblMisPay"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "Bonus" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblBonus"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "Reimbursements" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblReimbursements"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "OtherMonthlyPayments" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblOtherMonthlyPayments"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "SalaryAdv" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblSalaryAdv"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "ProfTaxDed" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblProfTaxDed"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "ITTaxDeduction" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblITTaxDeduction"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "AdvStlDeduction" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblAdvstlDedu"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "OtherDeduction" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblOdeu"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "MiscDeds" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblMiscDeds"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "TransportDed" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblTransportDed"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "LoadDed" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblLoadDed"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "TDSRefund" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblTDSRefund"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "PFDed" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblPFDedc"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "GrossSalary" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblGSalary"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "NetSalary" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblNSalary"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                        If ddlOnitem.SelectedValue = "LOPay" Then
                            For Each rows As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows.FindControl("lblId"), Label).Text
                                F1 = CType(rows.FindControl("lblLOPay"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)
                            Next
                        End If
                    End If
                    EL.iMS_id = 0
                    BL.updateNetGross(EL)
                Else
                    For Each rows1 As GridViewRow In gvGenSalary.Rows
                        EL.iMS_id = CType(rows1.FindControl("lblId"), Label).Text
                        Select Case CheckCriteria.Checked = True
                            Case ddlC.SelectedValue = "Basicpay"
                                F1 = CType(rows1.FindControl("lblBasicPay"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "SpecialAllw"
                                F1 = CType(rows1.FindControl("lblSplAllowance"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "HouseRentAllw"
                                F1 = CType(rows1.FindControl("lblHRA"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "MedicalAllw"
                                F1 = CType(rows1.FindControl("lblMedical"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "TransportAllw"
                                F1 = CType(rows1.FindControl("lblTAllowance"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "DearnessAllw"
                                F1 = CType(rows1.FindControl("lblDearnessAllw"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "Incentives"
                                F1 = CType(rows1.FindControl("lblInc"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "MiscellaneousPay"
                                F1 = CType(rows1.FindControl("lblMisPay"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "Bonus"
                                F1 = CType(rows1.FindControl("lblBonus"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "Reimbursements"
                                F1 = CType(rows1.FindControl("lblReimbursements"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "OtherMonthlyPayments"
                                F1 = CType(rows1.FindControl("lblOtherMonthlyPayments"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "SalaryAdv"
                                F1 = CType(rows1.FindControl("lblSalaryAdv"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "ProfTaxDed"
                                F1 = CType(rows1.FindControl("lblProfTaxDed"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "ITTaxDeduction"
                                F1 = CType(rows1.FindControl("lblITTaxDeduction"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "AdvStlDeduction"
                                F1 = CType(rows1.FindControl("lblAdvstlDedu"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "OtherDeduction"
                                F1 = CType(rows1.FindControl("lblOdeu"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "MiscDeds"
                                F1 = CType(rows1.FindControl("lblMiscDeds"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "TransportDed"
                                F1 = CType(rows1.FindControl("lblTransportDed"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "LoadDed"
                                F1 = CType(rows1.FindControl("lblLoadDed"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "PFDed"
                                F1 = CType(rows1.FindControl("lblBasicPay"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "GrossSalary"
                                F1 = CType(rows1.FindControl("lblGSalary"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "NetSalary"
                                F1 = CType(rows1.FindControl("lblNSalary"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "LOPay"
                                F1 = CType(rows1.FindControl("lblLOPay"), Label).Text
                                GoTo lbl
                            Case ddlC.SelectedValue = "TDSRefund"
                                F1 = CType(rows1.FindControl("lblTDSRefund"), Label).Text
                                GoTo lbl
                        End Select

lbl:

                        If ddlc1.SelectedItem.Text = ">" And ddlc2.SelectedItem.Text = "<" Then
                            If F1 > txtCvalue1.Text And F1 < txtCvalue2.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                            End If
                            'End If
                        ElseIf ddlc1.SelectedItem.Text = "<" And ddlc2.SelectedItem.Text = ">" Then
                            If F1 < txtCvalue1.Text And F1 > txtCvalue2.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                                'End If
                            End If
                        ElseIf ddlc1.SelectedItem.Text = ">=" And ddlc2.SelectedItem.Text = "<=" Then
                            If F1 >= txtCvalue1.Text And F1 <= txtCvalue2.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                            End If
                            'End If
                        ElseIf ddlc1.SelectedItem.Text = "<=" And ddlc2.SelectedItem.Text = ">=" Then
                            If F1 <= txtCvalue1.Text And F1 >= txtCvalue2.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                                'End If
                            End If
                        ElseIf ddlc1.SelectedItem.Text = "<" And ddlc2.SelectedItem.Text = ">=" Then
                            If F1 < txtCvalue1.Text And F1 >= txtCvalue2.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                                'End If
                            End If
                        ElseIf ddlc1.SelectedItem.Text = "<=" And ddlc2.SelectedItem.Text = ">" Then
                            If F1 <= txtCvalue1.Text And F1 > txtCvalue2.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                            End If
                            'End If
                            ''''''
                        ElseIf ddlc2.SelectedItem.Text = ">" And ddlc1.SelectedItem.Text = "<" Then
                            If F1 > txtCvalue2.Text And F1 < txtCvalue1.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                                'End If
                            End If
                        ElseIf ddlc2.SelectedItem.Text = "<" And ddlc1.SelectedItem.Text = ">" Then
                            If F1 < txtCvalue2.Text And F1 > txtCvalue1.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                                'End If
                            End If
                        ElseIf ddlc2.SelectedItem.Text = ">=" And ddlc1.SelectedItem.Text = "<=" Then
                            If F1 >= txtCvalue2.Text And F1 <= txtCvalue1.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                                'End If
                            End If
                        ElseIf ddlc2.SelectedItem.Text = "<=" And ddlc1.SelectedItem.Text = ">=" Then
                            If F1 <= txtCvalue2.Text And F1 >= txtCvalue1.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                                'End If
                            End If
                        ElseIf ddlc2.SelectedItem.Text = "<" And ddlc1.SelectedItem.Text = ">=" Then
                            If F1 < txtCvalue2.Text And F1 >= txtCvalue1.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                                'End If
                            End If
                        ElseIf ddlc2.SelectedItem.Text = "<=" And ddlc1.SelectedItem.Text = ">" Then
                            If F1 <= txtCvalue2.Text And F1 > txtCvalue1.Text Then
                                GoTo lbl1
                            Else
                                GoTo lbl2
                            End If
                        End If
lbl1:
                        If rbSelect.SelectedValue = 1 Then
                            EL.iMS_id = CType(rows1.FindControl("lblId"), Label).Text
                            If txtFixed.Text = "" Then
                                EL.Fixed = 0
                            Else
                                EL.Fixed = txtFixed.Text
                            End If

                            BL.UpdateRecord(EL)

                        End If
                        If rbSelect.SelectedValue = 2 Then
                            If txtGross.Text = "" Then
                                EL.OnGross = 0
                            Else
                                EL.OnGross = txtGross.Text
                            End If
                            Gross = CType(rows1.FindControl("lblGSalary"), Label).Text
                            EL.Fixed = Gross * (EL.OnGross / 100)
                            BL.UpdateRecord(EL)

                        End If
                        If rbSelect.SelectedValue = 3 Then
                            If txtNet.Text = "" Then
                                EL.OnNet = 0
                            Else
                                EL.OnNet = txtNet.Text
                            End If
                            NetSalary = CType(rows1.FindControl("lblNSalary"), Label).Text
                            EL.Fixed = NetSalary * (EL.OnNet / 100)
                            BL.UpdateRecord(EL)

                        End If
                        If rbSelect.SelectedValue = 4 Then
                            EL.ItemField = ddlOnitem.SelectedValue
                            If txtItemValue.Text = "" Then
                                EL.ItemValue = 0
                            Else
                                EL.ItemValue = txtItemValue.Text
                            End If
                            If ddlOnitem.SelectedValue = "Basicpay" Then
                                F1 = CType(rows1.FindControl("lblBasicPay"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "SpecialAllw" Then
                                F1 = CType(rows1.FindControl("lblSplAllowance"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "HouseRentAllw" Then
                                F1 = CType(rows1.FindControl("lblHRA"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "MedicalAllw" Then

                                F1 = CType(rows1.FindControl("lblMedical"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "TransportAllw" Then
                                F1 = CType(rows1.FindControl("lblTAllowance"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "DearnessAllw" Then
                                F1 = CType(rows1.FindControl("lblDearnessAllw"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "Incentives" Then
                                F1 = CType(rows1.FindControl("lblInc"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "MiscellaneousPay" Then
                                F1 = CType(rows1.FindControl("lblMisPay"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "Bonus" Then
                                F1 = CType(rows1.FindControl("lblBonus"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "Reimbursements" Then
                                F1 = CType(rows1.FindControl("lblReimbursements"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "OtherMonthlyPayments" Then
                                F1 = CType(rows1.FindControl("lblOtherMonthlyPayments"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "SalaryAdv" Then
                                F1 = CType(rows1.FindControl("lblSalaryAdv"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "ProfTaxDed" Then
                                F1 = CType(rows1.FindControl("lblProfTaxDed"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "ITTaxDeduction" Then
                                F1 = CType(rows1.FindControl("lblITTaxDeduction"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "AdvStlDeduction" Then
                                F1 = CType(rows1.FindControl("lblAdvstlDedu"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "OtherDeduction" Then
                                F1 = CType(rows1.FindControl("lblOdeu"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "MiscDeds" Then
                                F1 = CType(rows1.FindControl("lblMiscDeds"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "TransportDed" Then
                                F1 = CType(rows1.FindControl("lblTransportDed"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "LoadDed" Then

                                F1 = CType(rows1.FindControl("lblLoadDed"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "TDSRefund" Then
                                F1 = CType(rows1.FindControl("lblTDSRefund"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "PFDed" Then
                                F1 = CType(rows1.FindControl("lblPFDedc"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "GrossSalary" Then
                                F1 = CType(rows1.FindControl("lblGSalary"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "NetSalary" Then
                                F1 = CType(rows1.FindControl("lblNSalary"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                            If ddlOnitem.SelectedValue = "LOPay" Then
                                F1 = CType(rows1.FindControl("lblLOPay"), Label).Text
                                EL.Fixed = F1 * (EL.ItemValue / 100)
                                BL.UpdateRecord(EL)

                            End If
                        End If

lbl2:
                        EL.iMS_id = CType(rows1.FindControl("lblId"), Label).Text
                        BL.updateNetGross(EL)
                    Next
                End If
            End If
            dt1 = BLL.RptSalSlip(ell)
            If dt1.Rows.Count > 0 Then
                gvGenSalary.DataSource = dt1
                gvGenSalary.DataBind()
                gvGenSalary.Visible = True
            Else
                lblMsg.Text = "No Records to display."
                gvGenSalary.Visible = False
                lblGreen.Text = ""
            End If
        Else
            lblMsg.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub btnClearUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearUpdate.Click
        If Session("Privilages").ToString.Contains("W") Then

            ell.Year = ddlYear.SelectedItem.Text
            ell.Month = ddlMonth.SelectedItem.Text
            ell.Formula = ddlFormulaGroup.SelectedValue
            dt = BLL.GetPayrollRules(ell)
            If dt.Rows.Count > 0 Then
                For Each R1 As GridViewRow In GvFormula.Rows
                    If CType(R1.FindControl("ChkPresent"), CheckBox).Checked = True Then
                        EL.Field = CType(R1.FindControl("ddlSelectF"), DropDownList).SelectedValue
                    End If
                Next
            Else
                EL.Field = ddlItem.SelectedValue
            End If
            EL.Month = ddlMonth.SelectedItem.Text
            EL.Year = ddlYear.SelectedItem.Text
            BL.clearupdate(EL)
            EL.iMS_id = 0
            BL.updateNetGross(EL)
            dt = BLL.RptSalSlip(ell)
            If dt.Rows.Count > 0 Then
                gvGenSalary.DataSource = dt
                gvGenSalary.DataBind()
                gvGenSalary.Visible = True
            Else
                lblMsg.Text = "No Records to display"
                gvGenSalary.Visible = False
                lblGreen.Text = ""
            End If
            lblGreen.Text = "Data cleared successfully."
            lblMsg.Text = ""
        Else
            lblMsg.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub btnsaveFormula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsaveFormula.Click
        If Session("Privilages").ToString.Contains("W") Then

            EL.Month = ddlMonth.SelectedItem.Text
            EL.Year = ddlYear.SelectedItem.Text

            EL.SelectOption = rbSelect.SelectedValue
            EL.Field = ddlItem.SelectedValue
            EL.Fromula = ddlFormulaGroup.SelectedValue
            ell.Formula = ddlFormulaGroup.SelectedValue
            EL.Grade = ddlGrade.SelectedValue
            If txtFixed.Text = "" Then
                EL.Fixed = 0
            Else
                EL.Fixed = txtFixed.Text
            End If
            If txtGross.Text = "" Then
                EL.OnGross = 0
            Else
                EL.OnGross = txtGross.Text
            End If
            If txtNet.Text = "" Then
                EL.OnNet = 0
            Else
                EL.OnNet = txtNet.Text
            End If
            EL.ItemField = ddlOnitem.SelectedValue
            If txtItemValue.Text = "" Then
                EL.ItemValue = 0
            Else
                EL.ItemValue = txtItemValue.Text
            End If
            If CheckCriteria.Checked = True Then
                EL.Criteria = "Y"
            Else
                EL.Criteria = "N"
            End If
            EL.CriteriaField = ddlC.SelectedValue
            EL.Criteria1 = ddlc1.SelectedItem.Text
            EL.Criteria2 = ddlc2.SelectedItem.Text
            If txtCvalue1.Text = "" Then
                EL.CriteriaV1 = 0
            Else
                EL.CriteriaV1 = txtCvalue1.Text
            End If
            If txtCvalue2.Text = "" Then
                EL.CriteriaV2 = 0
            Else
                EL.CriteriaV2 = txtCvalue2.Text
            End If
            BL.SaveFormula(EL)
            lblGreen.Text = "Formula saved successfully."
            lblMsg.Text = ""
            dt = BLL.GetPayrollRules(ell)
            If dt.Rows.Count > 0 Then
                GvFormula.DataSource = dt
                GvFormula.DataBind()
                GvFormula.Visible = True
                btnUpdateFormula.Visible = True
                For Each Grid As GridViewRow In GvFormula.Rows
                    CType(Grid.FindControl("ddlOption"), DropDownList).SelectedValue = CType(Grid.FindControl("lblSelectOption"), Label).Text
                    CType(Grid.FindControl("ddlSelectF"), DropDownList).SelectedValue = CType(Grid.FindControl("lblselectF"), Label).Text
                    CType(Grid.FindControl("ddlOfField"), DropDownList).SelectedValue = CType(Grid.FindControl("lblOfField"), Label).Text
                    CType(Grid.FindControl("ddlCriteria"), DropDownList).SelectedValue = CType(Grid.FindControl("lblCriteria"), Label).Text
                    CType(Grid.FindControl("ddlField"), DropDownList).SelectedValue = CType(Grid.FindControl("lblCriteriaField"), Label).Text
                    CType(Grid.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = CType(Grid.FindControl("lblCriteria1"), Label).Text
                    CType(Grid.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = CType(Grid.FindControl("lblCriteria2"), Label).Text
                    CType(Grid.FindControl("ddlGrade1"), DropDownList).SelectedItem.Text = CType(Grid.FindControl("lblGrade"), Label).Text
                Next
            Else
                lblMsg.Text = "No Records to display"
                GvFormula.Visible = False
                lblGreen.Text = ""
            End If
        Else
            lblMsg.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub btnviewFormula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnviewFormula.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then
            ell.Formula = ddlFormulaGroup.SelectedValue
            dt = BLL.GetPayrollRules(ell)
            If dt.Rows.Count > 0 Then
                GvFormula.DataSource = dt
                GvFormula.DataBind()
                GvFormula.Visible = True
                btnUpdateFormula.Visible = True
            Else
                lblMsg.Text = "No Records to display"
                GvFormula.Visible = False
                lblGreen.Text = ""
            End If
            For Each Grid As GridViewRow In GvFormula.Rows
                CType(Grid.FindControl("ddlOption"), DropDownList).SelectedValue = CType(Grid.FindControl("lblSelectOption"), Label).Text
                CType(Grid.FindControl("ddlSelectF"), DropDownList).SelectedValue = CType(Grid.FindControl("lblselectF"), Label).Text
                CType(Grid.FindControl("ddlOfField"), DropDownList).SelectedValue = CType(Grid.FindControl("lblOfField"), Label).Text
                CType(Grid.FindControl("ddlCriteria"), DropDownList).SelectedValue = CType(Grid.FindControl("lblCriteria"), Label).Text
                CType(Grid.FindControl("ddlField"), DropDownList).SelectedValue = CType(Grid.FindControl("lblCriteriaField"), Label).Text
                CType(Grid.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = CType(Grid.FindControl("lblCriteria1"), Label).Text
                CType(Grid.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = CType(Grid.FindControl("lblCriteria2"), Label).Text
                CType(Grid.FindControl("ddlGrade1"), DropDownList).SelectedValue = CType(Grid.FindControl("lblGrade"), Label).Text
            Next
            lblGreen.Text = ""
            lblMsg.Text = ""
            PasswordPanel.Visible = False
        Else
            lblMsg.Text = "You do not have Read Privilage."
        End If
    End Sub

    Protected Sub btnUpdateFormula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdateFormula.Click
        If Session("Privilages").ToString.Contains("W") Then
            EL.Fromula = ddlFormulaGroup.SelectedValue
            ViewState("Status") = "U"
            PasswordPanel.Visible = True
            Panel3.Visible = False
            txtPassword.Focus()
            lblpassError.Text = ""
            
        Else
            lblMsg.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub GvFormula_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvFormula.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Status") = "D"
            'ControlsPanel.Visible = False
            PasswordPanel.Visible = True
            Panel3.Visible = False
            txtPassword.Focus()
            lblpassError.Text = ""
            'Image2.Visible = False
            'Image3.Visible = False
            ViewState("Id") = CType(GvFormula.Rows(e.RowIndex).FindControl("lblId"), Label).Text
            dt = BLL.GetPayrollRules(ell)
            GvFormula.DataSource = dt
            GvFormula.DataBind()
            GvFormula.Visible = True
            btnUpdateFormula.Visible = True
        Else
            lblMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        If txtPassword.Text = Session("Password") Then
            If ViewState("Status") = "D" Then
                EL.Fromula = ddlFormulaGroup.SelectedValue
                EL.iMS_id = ViewState("Id")
                GvFormula.Enabled = True
                BL.delete(EL)
                Panel3.Visible = True
                lblGreen.Text = "Formula Deleted Successfully."
                lblMsg.Text = ""
                GvFormula.PageIndex = ViewState("PageIndex")
                dt = BLL.GetPayrollRules(ell)
                GvFormula.DataSource = dt
                GvFormula.DataBind()
                GvFormula.Visible = True
                btnUpdateFormula.Visible = True
            End If
            If ViewState("Status") = "U" Then
                For Each Grid As GridViewRow In GvFormula.Rows
                    If CType(Grid.FindControl("ChkPresent"), CheckBox).Checked Then
                        EL.Fromula = ddlFormulaGroup.SelectedValue
                        EL.Month = ddlMonth.SelectedItem.Text
                        EL.Year = ddlYear.SelectedItem.Text
                        EL.SelectOption = CType(Grid.FindControl("lblSelectOption"), Label).Text
                        EL.Field = CType(Grid.FindControl("ddlSelectF"), DropDownList).SelectedValue
                        EL.Fixed = CType(Grid.FindControl("txtFixed"), TextBox).Text
                        EL.OnGross = CType(Grid.FindControl("txtGross"), TextBox).Text
                        EL.OnNet = CType(Grid.FindControl("txtNet"), TextBox).Text
                        EL.ItemField = CType(Grid.FindControl("ddlOfField"), DropDownList).SelectedValue
                        EL.ItemValue = CType(Grid.FindControl("txtValueOfField"), TextBox).Text
                        EL.Criteria = CType(Grid.FindControl("ddlCriteria"), DropDownList).SelectedValue
                        EL.CriteriaField = CType(Grid.FindControl("ddlField"), DropDownList).SelectedValue
                        EL.Criteria1 = CType(Grid.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text
                        EL.Criteria2 = CType(Grid.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text
                        EL.CriteriaV1 = CType(Grid.FindControl("txtValue1"), TextBox).Text
                        EL.CriteriaV2 = CType(Grid.FindControl("txtValue2"), TextBox).Text
                        EL.Grade = CType(Grid.FindControl("ddlGrade1"), DropDownList).SelectedValue
                        EL.iMS_id = CType(Grid.FindControl("lblId"), Label).Text
                        BL.UpdateFormula(EL)
                        Panel3.Visible = True
                        lblGreen.Text = "Formula Updated successfully."
                        lblMsg.Text = ""
                        GvFormula.PageIndex = ViewState("PageIndex")
                        dt = BLL.GetPayrollRules(ell)
                        GvFormula.DataSource = dt
                        GvFormula.DataBind()
                        GvFormula.Visible = True
                        btnUpdateFormula.Visible = True
                        PasswordPanel.Visible = False
                    End If
                Next
                For Each Grid1 As GridViewRow In GvFormula.Rows
                    CType(Grid1.FindControl("ddlOption"), DropDownList).SelectedValue = CType(Grid1.FindControl("lblSelectOption"), Label).Text
                    CType(Grid1.FindControl("ddlSelectF"), DropDownList).SelectedValue = CType(Grid1.FindControl("lblselectF"), Label).Text
                    CType(Grid1.FindControl("ddlOfField"), DropDownList).SelectedValue = CType(Grid1.FindControl("lblOfField"), Label).Text
                    CType(Grid1.FindControl("ddlCriteria"), DropDownList).SelectedValue = CType(Grid1.FindControl("lblCriteria"), Label).Text
                    CType(Grid1.FindControl("ddlField"), DropDownList).SelectedValue = CType(Grid1.FindControl("lblCriteriaField"), Label).Text
                    CType(Grid1.FindControl("ddlCriteria1"), DropDownList).SelectedItem.Text = CType(Grid1.FindControl("lblCriteria1"), Label).Text
                    CType(Grid1.FindControl("ddlCriteria2"), DropDownList).SelectedItem.Text = CType(Grid1.FindControl("lblCriteria2"), Label).Text
                    CType(Grid1.FindControl("ddlGrade1"), DropDownList).SelectedValue = CType(Grid1.FindControl("lblGrade"), Label).Text
                Next
            End If
        Else
            lblpassError.Text = "Incorrect Password."
        End If
    End Sub
End Class
