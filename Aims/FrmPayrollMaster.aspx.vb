Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Partial Class FrmPayrollMaster
    Inherits BasePage
    Dim Ent As New EntPayroll
    Dim BLL As New BLPayroll
    Dim Emp As String
    Dim payid As Integer
    Dim GlobalFunction As New GlobalFunction
    Protected Function GetEmpName(ByVal id As Long) As String
        Dim Emp As New EmployeeManager
        Dim d As EmpCombo = Emp.GetEmpID(id)
        Return d.Emp_Name
    End Function

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If Session("Privilages").ToString.Contains("W") Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                ViewState("PM_ID") = CType(GridView1.Rows(e.RowIndex).FindControl("TxtHdnFld"), HiddenField).Value
                Ent.iMS_id = ViewState("PM_ID")
                BLL.ChangeFlag(Ent)
                msginfo.Text = "Data Deleted Sucessfully."
                Ent.iMS_id = 0
                lblmsg.Text = ""
                clear()
                GridView1.PageIndex = ViewState("PageIndex")
                displaygrid()
            Else
                lblmsg.Text = "You do not belong to this branch, Cannot delete data."
                msginfo.Text = ""
            End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Sub AssignEntity()
        If TxtdearAllw.Text = "" Then
            Ent.DearnessAllowance = 0
        Else
            Ent.DearnessAllowance = TxtdearAllw.Text
        End If

        If TxtSpecialAllowance.Text = "" Then
            Ent.SpecialAllowance = 0
        Else
            Ent.SpecialAllowance = TxtSpecialAllowance.Text
        End If

        If TxtHouseRentAllw.Text = "" Then
            Ent.HRA = 0
        Else
            Ent.HRA = TxtHouseRentAllw.Text
        End If

        If TxtmedicalAllw.Text = "" Then
            Ent.Medical = 0
        Else
            Ent.Medical = TxtmedicalAllw.Text
        End If

        If txtOverTime.Text = "" Then
            Ent.OverTime = 0
        Else
            Ent.OverTime = txtOverTime.Text
        End If

        If txtHonorary.Text = "" Then
            Ent.Honorary = 0
        Else
            Ent.Honorary = txtHonorary.Text
        End If

        If TxtTransportAllowance.Text = "" Then
            Ent.TransportAllowance = 0
        Else
            Ent.TransportAllowance = TxtTransportAllowance.Text
        End If

        If TxtfixedIncentive.Text = "" Then
            Ent.FixedIncentive = 0
        Else
            Ent.FixedIncentive = TxtfixedIncentive.Text
        End If

        If txtMiscAllw1.Text = "" Then
            Ent.MA1 = 0
        Else
            Ent.MA1 = txtMiscAllw1.Text
        End If

        If txtMiscAllw2.Text = "" Then
            Ent.MA2 = 0
        Else
            Ent.MA2 = txtMiscAllw2.Text
        End If

        If txtMiscAllw3.Text = "" Then
            Ent.MA3 = 0
        Else
            Ent.MA3 = txtMiscAllw3.Text
        End If

        If txtMiscAllw4.Text = "" Then
            Ent.MA4 = 0
        Else
            Ent.MA4 = txtMiscAllw4.Text
        End If

        If txtMiscAllw5.Text = "" Then
            Ent.MA5 = 0
        Else
            Ent.MA5 = txtMiscAllw5.Text
        End If

        If txtMiscAllw6.Text = "" Then
            Ent.MA6 = 0
        Else
            Ent.MA6 = txtMiscAllw6.Text
        End If

        If txtCityCompAllw.Text = "" Then
            Ent.CityCompAllw = 0
        Else
            Ent.CityCompAllw = txtCityCompAllw.Text
        End If

        If txtMiscAllw7.Text = "" Then
            Ent.MA7 = 0
        Else
            Ent.MA7 = txtMiscAllw7.Text
        End If

        If txtMiscAllw8.Text = "" Then
            Ent.MA8 = 0
        Else
            Ent.MA8 = txtMiscAllw8.Text
        End If

        If txtMiscAllw9.Text = "" Then
            Ent.MA9 = 0
        Else
            Ent.MA9 = txtMiscAllw9.Text
        End If

        If txtpfdeduction.Text = "" Then
            Ent.PF = 0
        Else
            Ent.PF = txtpfdeduction.Text
        End If

        If txtvpf.Text = "" Then
            Ent.VPF = 0
        Else
            Ent.VPF = txtvpf.Text
        End If

        If txtproftaxdedc.Text = "" Then
            Ent.ProfTaxDeduction = 0
        Else
            Ent.ProfTaxDeduction = txtproftaxdedc.Text
        End If

        If Miscded1.Text = "" Then
            Ent.MD1 = 0
        Else
            Ent.MD1 = Miscded1.Text
        End If

        If Miscded2.Text = "" Then
            Ent.MD2 = 0
        Else
            Ent.MD2 = Miscded2.Text
        End If

        If Miscded3.Text = "" Then
            Ent.MD3 = 0
        Else
            Ent.MD3 = Miscded3.Text
        End If

        If Miscded4.Text = "" Then
            Ent.MD4 = 0
        Else
            Ent.MD4 = Miscded4.Text
        End If

        If Miscded5.Text = "" Then
            Ent.MD5 = 0
        Else
            Ent.MD5 = Miscded5.Text
        End If

        If Miscded6.Text = "" Then
            Ent.MD6 = 0
        Else
            Ent.MD6 = Miscded6.Text
        End If

        If Miscded7.Text = "" Then
            Ent.MD7 = 0
        Else
            Ent.MD7 = Miscded7.Text
        End If

        If Miscded8.Text = "" Then
            Ent.MD8 = 0
        Else
            Ent.MD8 = Miscded8.Text
        End If

        If Miscded9.Text = "" Then
            Ent.MD9 = 0
        Else
            Ent.MD9 = Miscded9.Text
        End If

        If Miscded10.Text = "" Then
            Ent.MD10 = 0
        Else
            Ent.MD10 = Miscded10.Text
        End If

        If Miscded11.Text = "" Then
            Ent.MD11 = 0
        Else
            Ent.MD11 = Miscded11.Text
        End If

        If Miscded12.Text = "" Then
            Ent.MD12 = 0
        Else
            Ent.MD12 = Miscded12.Text
        End If

        If Miscded13.Text = "" Then
            Ent.MD13 = 0
        Else
            Ent.MD13 = Miscded13.Text
        End If

        If Miscded14.Text = "" Then
            Ent.MD14 = 0
        Else
            Ent.MD14 = Miscded14.Text
        End If

        If Miscded15.Text = "" Then
            Ent.MD15 = 0
        Else
            Ent.MD15 = Miscded15.Text
        End If

        If Miscded16.Text = "" Then
            Ent.MD16 = 0
        Else
            Ent.MD16 = Miscded16.Text
        End If

        If txtFestAdvance.Text = "" Then
            Ent.FestAdvantce = 0
        Else
            Ent.FestAdvantce = txtFestAdvance.Text
        End If

        Dim tempallow, tempded, tempgross As New Double
        tempallow = (Ent.BasicPay + Ent.DearnessAllowance + Ent.SpecialAllowance + Ent.HRA + Ent.Medical + Ent.TransportAllowance + Ent.FixedIncentive + Ent.OverTime + Ent.Honorary + Ent.MA1 + Ent.MA2 + Ent.MA3 + Ent.MA4 + Ent.MA5 + Ent.MA6 + Ent.MA7 + Ent.MA8 + Ent.MA9 + Ent.CityCompAllw)
        tempded = (Ent.MD1 + Ent.MD2 + Ent.MD3 + Ent.MD4 + Ent.MD5 + Ent.MD6 + Ent.MD7 + Ent.MD8 + Ent.MD9 + Ent.MD10 + Ent.MD11 + Ent.MD12 + Ent.MD13 + Ent.MD14 + Ent.MD15 + Ent.MD16 + Ent.FestAdvantce + Ent.VPF + Ent.PF)
        tempgross = tempallow - tempded

        'If tempgross >= 10000 And tempgross <= 14999 Then
        '    Ent.ProfTaxDeduction = 150
        'ElseIf tempgross >= 15000 Then
        '    Ent.ProfTaxDeduction = 200
        'Else
        '    Ent.ProfTaxDeduction = 0
        'End If
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If Session("Privilages").ToString.Contains("W") Then
            txtEmp.Focus()
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Try
                    If BtnSave.Text = "ADD" Then
                        Ent.EMPid = HidempId.Value
                        If TxtSRDate.Text = "" Then
                            Ent.SRDate = "01/01/9100"
                        Else
                            Ent.SRDate = TxtSRDate.Text
                        End If
                        Ent.BasicPay = Txtbasicpay.Text
                        AssignEntity()
                        Ent.PaymentId = ddlpaymentmethod.SelectedValue
                        Ent.PFAcct = txtPFAcctNo.Text
                        If CheckBox1.Checked = True Then
                            Ent.Settlement = "Y"
                        Else
                            Ent.Settlement = "N"
                        End If
                        If chkPensionable.Checked = True Then
                            Ent.Pensionable = "Y"
                        Else
                            Ent.Pensionable = "N"
                        End If
                        Dim dt As New DataTable
                        Ent.iMS_id = 0
                        dt = BLL.CheckDuplicate(Ent)
                        If dt.Rows.Count > 0 Then
                            'lblRed.Visible = True
                            lblmsg.Text = "Data already exists."
                            msginfo.Text = " "
                        Else
                            BLL.InsertRecord(Ent)
                            lblmsg.Text = ""
                            msginfo.Text = "Data Saved Successfully."
                            ViewState("PageIndex") = 0
                            GridView1.PageIndex = 0
                            displaygrid()
                            clear()
                        End If
                    ElseIf BtnSave.Text = "UPDATE" Then
                        Ent.EMPid = HidempId.Value
                        If TxtSRDate.Text = "" Then
                            Ent.SRDate = "1/1/9100"
                        Else
                            Ent.SRDate = TxtSRDate.Text
                        End If
                        Ent.BasicPay = Txtbasicpay.Text
                        Ent.PaymentId = ddlpaymentmethod.SelectedValue
                        Ent.PFAcct = txtPFAcctNo.Text
                        If CheckBox1.Checked = True Then
                            Ent.Settlement = "Y"
                        Else
                            Ent.Settlement = "N"
                        End If
                        If chkPensionable.Checked = True Then
                            Ent.Pensionable = "Y"
                        Else
                            Ent.Pensionable = "N"
                        End If
                        AssignEntity()
                        Ent.iMS_id = ViewState("PM_ID")
                        Dim dt As New DataTable
                        dt = BLL.CheckDuplicate(Ent)
                        If dt.Rows.Count > 0 Then
                            lblmsg.Text = "Data already exists."
                            msginfo.Text = " "
                        Else
                            BLL.UpdateRecord(Ent)
                            BtnSave.Text = "ADD"
                            btnDetails.Text = "VIEW"
                            lblmsg.Text = ""
                            msginfo.Text = "Data Updated Successfully."
                            clear()
                            Ent.iMS_id = 0
                            GridView1.PageIndex = ViewState("PageIndex")
                            displaygrid()
                            lblSubTot.Visible = False
                            lblTotAllow.Visible = False
                            lblTotDeduc.Visible = False
                        End If
                    End If
                Catch ex As Exception
                    lblmsg.Text = "Enter correct data."
                End Try

            Else
                lblmsg.Text = "You do not belong to this branch, Cannot add/update data."
                msginfo.Text = ""
            End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        displaygrid()
    End Sub
    Protected Sub displaygrid()
        LinkButton1.Focus()
        Dim dt As DataTable
        If txtEmp.Text = "" Then
            Ent.Empcode = "*"
        Else
            Ent.Empcode = txtEmp.Text
        End If
        If txtEmpName.Text = "" Then
            Ent.EmpName = 0
        Else
            Ent.EmpName = txtEmpName.Text
        End If
        dt = BLL.GetPayroll(Ent)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataBind()
            For Each rows As GridViewRow In GridView1.Rows
                If CType(rows.FindControl("Label3"), Label).Text = "01-Jan-9100" Then
                    CType(rows.FindControl("Label3"), Label).Text = ""
                End If
            Next
        Else
            msginfo.Text = ""
            lblmsg.Text = "No Records to display."
            txtEmp.Focus()
            GridView1.Visible = False
        End If
    End Sub
    Protected Sub BtnRecover_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("RecoverForm") = "Payroll"
        Response.Redirect("recover.aspx")
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        If Session("Privilages").ToString.Contains("W") Then

            'If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                lblmsg.Text = ""
                msginfo.Text = ""
                BtnSave.Text = "UPDATE"
                'BtnReport.Visible = True
                ViewState("PM_ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("TxtHdnFld"), HiddenField).Value
                txtEmp.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text

                txtEmpName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3023"), Label).Text
                TxtSRDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
                Txtbasicpay.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
                TxtdearAllw.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
                TxtSpecialAllowance.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label6"), Label).Text
                TxtHouseRentAllw.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label7"), Label).Text
                TxtmedicalAllw.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label8"), Label).Text
                TxtTransportAllowance.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label9"), Label).Text
                TxtfixedIncentive.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label101"), Label).Text
                txtMiscAllw1.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label102"), Label).Text
                txtMiscAllw2.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label103"), Label).Text
                txtMiscAllw3.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label104"), Label).Text
                txtMiscAllw4.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label105"), Label).Text
                txtMiscAllw5.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label106"), Label).Text
                txtMiscAllw6.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label107"), Label).Text
                txtMiscAllw7.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label130"), Label).Text
                txtMiscAllw8.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label131"), Label).Text
                txtMiscAllw9.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label132"), Label).Text
                txtCityCompAllw.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label108"), Label).Text
                txtOverTime.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label109"), Label).Text
                txtHonorary.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label110"), Label).Text
                txtpfdeduction.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label111"), Label).Text

                txtvpf.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label112334"), Label).Text
                txtproftaxdedc.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label112"), Label).Text
                Miscded1.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label113"), Label).Text
                Miscded2.Text = (CType(GridView1.Rows(e.NewEditIndex).FindControl("Label114"), Label).Text)
                Miscded3.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label115"), Label).Text
                Miscded4.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label116"), Label).Text
                Miscded5.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label117"), Label).Text
                Miscded6.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label118"), Label).Text
                Miscded7.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label119"), Label).Text
                Miscded8.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label120"), Label).Text
                Miscded9.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label121"), Label).Text
                Miscded10.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label122"), Label).Text
                Miscded11.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label123"), Label).Text
                Miscded12.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label124"), Label).Text
                Miscded13.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label125"), Label).Text
                Miscded14.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label126"), Label).Text
                Miscded15.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label127"), Label).Text
                Miscded15.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label133"), Label).Text
                txtFestAdvance.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label128"), Label).Text
                txtPFAcctNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPFAcct"), Label).Text
                HidempId.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("empid"), HiddenField).Value
                If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSettlement"), Label).Text = "Y" Then
                    CheckBox1.Checked = True
                Else
                    CheckBox1.Checked = False
                End If
                If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPensionable"), Label).Text = "Y" Then
                    chkPensionable.Checked = True
                Else
                    chkPensionable.Checked = False
                End If
                If CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPaymentId"), Label).Text <> "" Then
                    ddlpaymentmethod.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPaymentId"), Label).Text
                Else
                    ddlpaymentmethod.Items.Clear()
                    ddlpaymentmethod.DataSourceID = "cmbpaymentmethod"
                    ddlpaymentmethod.DataBind()
                End If
                Ent.Empcode = "*"
                Ent.EmpName = 0
                e.Cancel = True
                btnDetails.Text = "BACK"
                Dim dt As DataTable
                Ent.iMS_id = ViewState("PM_ID")
                dt = BLL.GetPayroll(Ent)
                lblSubTot.Visible = True
                lblTotAllow.Visible = True
                lblTotDeduc.Visible = True
                lblTotAllow.Text = Format(dt.Rows(0).Item("TotalAllowance"), "N")
                lblTotDeduc.Text = Format(dt.Rows(0).Item("TotalDeduc"), "N")
                GridView1.DataSource = dt
                GridView1.Visible = True
                GridView1.Enabled = True
                GridView1.DataBind()
                For Each rows As GridViewRow In GridView1.Rows
                    If CType(rows.FindControl("Label3"), Label).Text = "01-Jan-9100" Then
                        CType(rows.FindControl("Label3"), Label).Text = ""
                    End If
                Next
                btnDetails.Visible = True
                'BtnReport.Visible = False
                GridView1.Enabled = False
            Catch ex As Exception
                lblmsg.Text = "Enter correct data."
            End Try

            'Else
            'lblmsg.Text = "You do not belong to this branch, Cannot edit data."
            'msginfo.Text = ""
            'End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then

            If btnDetails.Text <> "BACK" Then
                lblmsg.Text = ""
                msginfo.Text = ""
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                displaygrid()
                ''clear()
                'AssignEntity()
            Else
                clear()
                lblmsg.Text = ""
                msginfo.Text = ""
                btnDetails.Text = "VIEW"
                BtnSave.Text = "ADD"
                GridView1.PageIndex = ViewState("PageIndex")
                displaygrid()
            End If
            lblSubTot.Visible = False
            lblTotAllow.Visible = False
            lblTotDeduc.Visible = False
        Else
            lblmsg.Text = "You do not have Read Privilage."
        End If
    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        txtEmp.Focus()
        Me.ValidateFormView("Payroll Details")
    End Sub
    Sub clear()
        txtEmp.Text = ""
        txtEmpName.Text = ""
        TxtSRDate.Text = ""
        Txtbasicpay.Text = ""
        TxtdearAllw.Text = ""
        TxtSpecialAllowance.Text = ""
        TxtHouseRentAllw.Text = ""
        TxtmedicalAllw.Text = ""
        TxtTransportAllowance.Text = ""
        TxtfixedIncentive.Text = ""
        txtMiscAllw1.Text = ""
        txtMiscAllw2.Text = ""
        txtMiscAllw3.Text = ""
        txtMiscAllw4.Text = ""
        txtMiscAllw5.Text = ""
        txtMiscAllw6.Text = ""
        txtMiscAllw7.Text = ""
        txtMiscAllw8.Text = ""
        txtMiscAllw9.Text = ""
        txtCityCompAllw.Text = ""
        txtOverTime.Text = ""
        txtHonorary.Text = ""
        txtpfdeduction.Text = ""
        txtvpf.Text = ""
        txtproftaxdedc.Text = ""
        Miscded1.Text = ""
        Miscded2.Text = ""
        Miscded3.Text = ""
        Miscded4.Text = ""
        Miscded5.Text = ""
        Miscded6.Text = ""
        Miscded7.Text = ""
        Miscded8.Text = ""
        Miscded9.Text = ""
        Miscded10.Text = ""
        Miscded11.Text = ""
        Miscded12.Text = ""
        Miscded13.Text = ""
        Miscded14.Text = ""
        Miscded15.Text = ""
        Miscded16.Text = ""
        txtFestAdvance.Text = ""
        txtPFAcctNo.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub txtEmp_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmp.TextChanged
        Try
            TxtSRDate.Focus()
            If txtEmp.Text = "" Then
                txtEmpName.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub
    Sub SplitName(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            txtEmp.Text = parts(0).ToString()
            txtEmpName.Text = parts(1).ToString()
            HidempId.Value = parts(2).ToString()
            'ViewState("EmpID") = EmpID
        Else
            txtEmp.AutoPostBack = True
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtEmp.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If txtEmp.Text <> "" Then
            SplitName(txtEmp.Text)
        Else
            txtEmp.AutoPostBack = True
            txtEmpName.Text = ""
            SplitName(txtEmp.Text)
        End If
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        LinkButton1.Focus()
        Dim dt As DataTable
        If txtEmp.Text = "" Then
            Ent.Empcode = "*"
        Else
            Ent.Empcode = txtEmp.Text
        End If
        If txtEmpName.Text = "" Then
            Ent.EmpName = 0
        Else
            Ent.EmpName = txtEmpName.Text
        End If
        dt = BLL.GetPayroll(Ent)

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("Label3"), Label).Text = "01-Jan-9100" Then
                CType(rows.FindControl("Label3"), Label).Text = ""
            End If
        Next

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
