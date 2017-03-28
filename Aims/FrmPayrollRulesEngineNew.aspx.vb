
Partial Class FrmPayrollRulesEngineNew
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
            EL.MonthNo = ddlMonth.SelectedValue
            dt1 = BLL.RptSalSlip4(ell)
            If dt1.Rows.Count > 0 Then
                gvGenSalary.DataSource = dt1
                gvGenSalary.DataBind()
                gvGenSalary.Visible = False
            Else
                lblMsg.Text = "No Records to display."
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
                        dt1 = BLL.RptSalSlip4(ell)
                        If dt1.Rows.Count > 0 Then
                            gvGenSalary.DataSource = dt1
                            gvGenSalary.DataBind()
                            gvGenSalary.Visible = False
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
                                    EL.iMS_id = CType(rows.FindControl("lblEmpId"), Label).Text
                                    EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                    BL.UpdateRecord1(EL)
                                Next
                            End If
                            If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 2 Then
                                EL.OnGross = CType(R1.FindControl("txtGross"), TextBox).Text
                                For Each rows As GridViewRow In gvGenSalary.Rows
                                    EL.iMS_id = CType(rows.FindControl("lblEmpId"), Label).Text
                                    EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                    EL.Fixed1 = CType(R1.FindControl("txtFixed"), TextBox).Text
                                    dt = BLL.GetGrossNet(EL)
                                    If dt.Rows.Count > 0 Then
                                        If dt.Rows(0).Item("TotalEarnings").ToString() <> "" Then
                                            Gross = dt.Rows(0).Item("TotalEarnings")
                                            EL.Fixed = Gross * (EL.OnGross / 100) + EL.Fixed1
                                            BL.UpdateRecord1(EL)
                                        End If
                                    End If

                                Next
                            End If
                            If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 3 Then
                                EL.OnNet = CType(R1.FindControl("txtNet"), TextBox).Text
                                For Each rows As GridViewRow In gvGenSalary.Rows
                                    EL.iMS_id = CType(rows.FindControl("lblEmpId"), Label).Text
                                    EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                    EL.Fixed1 = CType(R1.FindControl("txtFixed"), TextBox).Text
                                    dt = BLL.GetGrossNet(EL)
                                    If dt.Rows.Count > 0 Then
                                        If dt.Rows(0).Item("NetSalary").ToString() <> "" Then
                                            NetSalary = dt.Rows(0).Item("NetSalary")
                                            EL.Fixed = NetSalary * (EL.OnNet / 100) + EL.Fixed1
                                            BL.UpdateRecord1(EL)
                                        End If

                                    End If

                                Next
                            End If
                            If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 4 Then
                                EL.ItemField = CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue
                                EL.ItemValue = CType(R1.FindControl("txtValueOfField"), TextBox).Text
                                For Each rows As GridViewRow In gvGenSalary.Rows
                                    EL.iMS_id = CType(rows.FindControl("lblEmpId"), Label).Text
                                    EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                    EL.Fixed1 = CType(R1.FindControl("txtFixed"), TextBox).Text
                                    dt = BLL.GetAmount(EL)
                                    If dt.Rows.Count > 0 Then
                                        If dt.Rows(0).Item("Amount").ToString() <> "" Then
                                            F1 = dt.Rows(0).Item("Amount")
                                            EL.Fixed = F1 * (EL.ItemValue / 100) + EL.Fixed1
                                            BL.UpdateRecord1(EL)
                                        End If
                                    End If
                                Next
                            End If
                            For Each rows1 As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows1.FindControl("lblEmpId"), Label).Text
                                BL.updateNetGross1(EL)
                            Next

                        Else
                            For Each rows1 As GridViewRow In gvGenSalary.Rows
                                EL.iMS_id = CType(rows1.FindControl("lblEmpId"), Label).Text
                                If CType(R1.FindControl("ddlCriteria"), DropDownList).SelectedValue = "Y" Then
                                    EL.ItemField = CType(R1.FindControl("ddlField"), DropDownList).SelectedValue

                                    If EL.Field = "1" Then
                                        dt = BLL.GetGrossNet(EL)
                                        If dt.Rows.Count > 0 Then
                                            If dt.Rows(0).Item("TotalEarnings").ToString() <> "" Then
                                                F1 = dt.Rows(0).Item("TotalEarnings")
                                            End If
                                        End If
                                    ElseIf EL.Field = "2" Then
                                        dt = BLL.GetGrossNet(EL)
                                        If dt.Rows.Count > 0 Then
                                            If dt.Rows(0).Item("NetSalary").ToString() <> "" Then
                                                F1 = dt.Rows(0).Item("NetSalary")
                                            End If
                                        End If
                                    Else
                                        dt = BLL.GetAmount(EL)
                                        If dt.Rows.Count > 0 Then
                                            If dt.Rows(0).Item("Amount").ToString() <> "" Then
                                                F1 = dt.Rows(0).Item("Amount")
                                            End If
                                        End If
                                    End If

                                End If

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
lbl1s:                          EL.Field = CType(R1.FindControl("ddlSelectF"), DropDownList).SelectedValue
                                If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 1 Then
                                    EL.iMS_id = CType(rows1.FindControl("lblEmpId"), Label).Text
                                    EL.Fixed = CType(R1.FindControl("txtFixed"), TextBox).Text
                                    EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                    BL.UpdateRecord1(EL)

                                End If
                                If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 2 Then
                                    EL.OnGross = CType(R1.FindControl("txtGross"), TextBox).Text
                                    dt = BLL.GetGrossNet(EL)
                                    If dt.Rows.Count > 0 Then
                                        If dt.Rows(0).Item("TotalEarnings").ToString() <> "" Then
                                            Gross = dt.Rows(0).Item("TotalEarnings")
                                            EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                            EL.Fixed = Gross * (EL.OnGross / 100)
                                            BL.UpdateRecord1(EL)
                                        End If

                                    End If

                                End If
                                If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 3 Then
                                    EL.OnNet = CType(R1.FindControl("txtNet"), TextBox).Text
                                    dt = BLL.GetGrossNet(EL)
                                    If dt.Rows.Count > 0 Then
                                        If dt.Rows(0).Item("NetSalary").ToString() <> "" Then
                                            NetSalary = dt.Rows(0).Item("NetSalary")
                                            EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                            EL.Fixed = NetSalary * (EL.OnNet / 100)
                                            BL.UpdateRecord1(EL)
                                        End If

                                    End If

                                End If
                                If CType(R1.FindControl("ddlOption"), DropDownList).SelectedValue = 4 Then
                                    EL.ItemField = CType(R1.FindControl("ddlOfField"), DropDownList).SelectedValue
                                    EL.ItemValue = CType(R1.FindControl("txtValueOfField"), TextBox).Text
                                    dt = BLL.GetAmount(EL)
                                    If dt.Rows.Count > 0 Then
                                        If dt.Rows(0).Item("Amount").ToString() <> "" Then
                                            F1 = dt.Rows(0).Item("Amount")
                                            EL.Grade = CType(R1.FindControl("lblGrade"), Label).Text
                                            EL.Fixed = F1 * (EL.ItemValue / 100)
                                            BL.UpdateRecord1(EL)
                                        End If

                                    End If
                                End If

lbl2s:
                                EL.iMS_id = CType(rows1.FindControl("lblEmpId"), Label).Text
                                BL.updateNetGross1(EL)
                            Next

                        End If
                    End If
                Next
            End If
           
            dt = BLL.RptSalSlip2(ell)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Visible = True
                lblGreen.Text = "Run done successfully."
                lblMsg.Text = ""
            Else
                lblMsg.Text = "No Records to display"
                GridView1.Visible = False
                lblGreen.Text = ""
            End If
        Else
            lblMsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        ell.Year = ddlYear.SelectedItem.Text
        ell.Month = ddlMonth.SelectedItem.Text
        ell.Dept = 0
        dt = BLL.RptSalSlip2(ell)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
        Else
            lblMsg.Text = "No Records to display"
            GridView1.Visible = False
            lblGreen.Text = ""
        End If
    End Sub
    Protected Sub GvFormula_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvFormula.PageIndexChanging
        GvFormula.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GvFormula.PageIndex
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
            BL.updateMonthPayClear(EL)
            dt = BLL.RptSalSlip2(ell)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Visible = True
            Else
                lblMsg.Text = "No Records to display."
                GridView1.Visible = False
                lblGreen.Text = ""
            End If
            lblGreen.Text = "Data cleared successfully."
            lblMsg.Text = ""
        Else
            lblMsg.Text = "You do not have Write Privilage."
        End If
        For Each rows As GridViewRow In GridView1.Rows
            EL.iMS_id = CType(rows.FindControl("lblEmpId"), Label).Text
            BL.updateNetGross1(EL)
        Next
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
                CType(Grid.FindControl("ChkPresent"), CheckBox).Checked = True
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
                    CType(Grid.FindControl("ChkPresent"), CheckBox).Checked = True
                Next
                lblMsg.Text = ""
                PasswordPanel.Visible = False
                'Else
                '    lblMsg.Text = "You do not have Read Privilage."
            End If
            If ViewState("Status") = "U" Then
                For Each Grid As GridViewRow In GvFormula.Rows
                    If CType(Grid.FindControl("ChkPresent"), CheckBox).Checked Then
                        EL.Fromula = ddlFormulaGroup.SelectedValue
                        EL.Month = ddlMonth.SelectedItem.Text
                        EL.Year = ddlYear.SelectedItem.Text
                        EL.SelectOption = CType(Grid.FindControl("ddlOption"), DropDownList).SelectedValue
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

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If Dir() = SortDirection.Ascending Then
            Dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            Dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        ell.Year = ddlYear.SelectedItem.Text
        ell.Month = ddlMonth.SelectedItem.Text
        GridView1.Enabled = True
        dt1 = BLL.RptSalSlip2(ell)
        Dim sortedView As New DataView(dt1)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
    End Sub
    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = value
        End Set
    End Property
End Class
