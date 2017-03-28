
Partial Class frmGenerateMontSalarySlip
    Inherits BasePage
    Dim alt As String
    Dim BLL As New BLPayroll
    Dim Prop As New EntPayroll
    Dim mb As New MonthlyPayDetailsB
    Protected Sub btnGenerateMonthSalary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerateMonthSalary.Click
        If Session("Privilages").ToString.Contains("W") Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim month As String
                Dim year As Integer
                Dim Dept As String
                Dim dt, dt1 As New DataTable
                If ddlYear.SelectedValue <> "" And txtWorkingDays.Text <> "" And txtTotalDays.Text <> "" And txtPaymentdate.Text <> "" And txtPaymentrunDate.Text <> "" Then
                    month = ddlMonth.SelectedItem.Text
                    year = ddlYear.SelectedItem.Text
                    Dept = DDLDeptType.SelectedValue
                    dt = mb.getgrid(month, year, Dept)
                    Prop.Year = ddlYear.SelectedItem.Text
                    Prop.Month = ddlMonth.SelectedItem.Text
                    Prop.Dept = DDLDeptType.SelectedValue
                    dt1 = BLL.RptSalSlip(Prop)

                    If CInt(txtTotalDays.Text) < CInt(txtWorkingDays.Text) Then
                        lblmsg.Text = "Working Days Should not be Greater then  Total Days."
                        lblGreen.Text = ""
                        Exit Sub
                    End If

                    If dt.Rows.Count > 0 Then
                        If dt1.Rows.Count > 0 Then
                            lblmsg.Text = "Salary already generated for the month " + ddlMonth.SelectedItem.Text + " and year " + ddlYear.SelectedItem.Text + "."
                            ddlMonth.Focus()
                            lblGreen.Text = ""
                            GVFill()
                            gvGenSalary.Visible = False
                        Else
                            Prop.Month = ddlMonth.SelectedItem.Text
                            Prop.Year = ddlYear.SelectedItem.Text
                            Prop.WD_InMonth = txtWorkingDays.Text
                            Prop.WorkDays = txtTotalDays.Text
                            Prop.PayDate = txtPaymentdate.Text
                            'If BLL.CheckSalary(Prop) Then

                            BLL.GenerateSalary(Prop)
                            lblmsg.Text = ""
                            lblGreen.Text = "Salary Generated for the month " + ddlMonth.SelectedItem.Text + " successfully."
                            txtWorkingDays.Focus()
                            txtWorkingDays.Text = ""
                            txtTotalDays.Text = ""
                            GVFill()
                        End If
                    Else
                        lblmsg.Text = "Salary Not yet generated for the month " + ddlMonth.SelectedItem.Text + " and year " + ddlYear.SelectedItem.Text + "."
                        txtWorkingDays.Focus()
                        lblGreen.Text = ""
                    End If
                Else
                    lblmsg.Text = "Please enter all mandatory(*) fields."
                    lblGreen.Text = ""
                End If
                For Each grid As GridViewRow In gvGenSalary.Rows
                    Prop.Empcode = CType(grid.FindControl("lblEmpId"), Label).Text
                    Prop.MA1 = CType(grid.FindControl("lblLoadDed"), Label).Text
                    BLL.updateloan(Prop)
                Next

            Else
                lblmsg.Text = "You do not belong to this branch, cannot generate data."
                lblGreen.Text = ""
            End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub btnprint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnprint.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("P") Then

            Dim dt As New DataTable
            If ddlYear.SelectedItem.Text <> "" Then
                Prop.Month = ddlMonth.SelectedItem.Text
                Prop.Year = ddlYear.SelectedItem.Text
                dt = BLL.RptSalSlip(Prop)
                If dt.Rows.Count <> 0 Then
                    Dim qrystring As String = "rptSalarySlip.aspx?" & "&Month=" & ddlMonth.SelectedItem.Text & "&Year=" & ddlYear.SelectedItem.Text
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                Else
                    lblmsg.Text = "No Records to display."
                    txtWorkingDays.Focus()
                    lblGreen.Text = ""
                End If
            Else
                lblmsg.Text = "Year field is Mandatory."
                lblGreen.Text = ""
            End If
        Else
            lblmsg.Text = "You do not have Print Privilage."
        End If
    End Sub
    Protected Sub btnClearMonthSalary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClearMonthSalary.Click
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then
                txtWorkingDays.Focus()
                Dim dt As New DataTable
                Prop.Month = ddlMonth.SelectedItem.Text
                If ddlYear.SelectedItem.Text <> "" Then
                    Prop.Year = ddlYear.SelectedItem.Text
                    dt = BLL.RptSalSlip(Prop)
                    If dt.Rows.Count > 0 Then
                        Prop.Year = ddlYear.SelectedItem.Text
                        Prop.Month = ddlMonth.SelectedItem.Text
                        Prop.Lock = BLL.LockStatus(Prop)

                        If Prop.Lock = "Y" Then
                            lblGreen.Text = ""
                            lblmsg.Text = "Records are locked, Cannot be cleared."
                            txtWorkingDays.Focus()
                        Else
                            For Each grid As GridViewRow In gvGenSalary.Rows
                                Prop.Empcode = CType(grid.FindControl("lblEmpId"), Label).Text
                                Prop.MA1 = CType(grid.FindControl("lblLoadDed"), Label).Text
                                BLL.updateloan1(Prop)
                            Next
                            BLL.DeleteSalary(Prop)
                            lblmsg.Text = ""
                            lblGreen.Text = "Salary Cleared for the month " + ddlMonth.SelectedItem.Text + " successfully."
                            txtWorkingDays.Focus()
                            gvGenSalary.Visible = False
                        End If
                    Else
                        lblmsg.Text = "Salary already cleared for the month " + ddlMonth.SelectedItem.Text + " and year " + ddlYear.SelectedItem.Text + "."
                        lblGreen.Text = ""
                    End If
                Else
                    lblmsg.Text = " Year field is Mandatory."
                    lblGreen.Text = ""
                End If

            Else
                lblmsg.Text = "You do not belong to this branch, cannot clear data."
                lblGreen.Text = ""
            End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub btnEditMonth_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEditMonth.Click
        If Session("Privilages").ToString.Contains("W") Then

            Dim qrystring As String = "FormMonthlyPaydetails.aspx?"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            'Response.Redirect("FormMonthlyPaydetails.aspx")
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub btnLockSalary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLockSalary.Click
        If Session("Privilages").ToString.Contains("W") Then

            If (Session("BranchCode") = Session("ParentBranch")) Then
                Prop.Year = ddlYear.SelectedItem.Text
                Prop.Month = ddlMonth.SelectedItem.Text
                Prop.Dept = DDLDeptType.SelectedValue
                Dim dt2 As New DataTable
                dt2 = BLL.RptSalSlip(Prop)
                If dt2.Rows.Count > 0 Then
                    ControlsPanel.Visible = False
                    PasswordPanel.Visible = True
                    txtPassword.Focus()
                    lblpassError.Text = ""
                    GVFill()
                    Image1.Visible = False
                    Image2.Visible = False
                Else
                    lblmsg.Text = "Salary Not yet generated for the month " + ddlMonth.SelectedItem.Text + " and year " + ddlYear.SelectedItem.Text + "."
                    lblGreen.Text = ""
                    gvGenSalary.Visible = False
                    Image1.Visible = True
                    Image2.Visible = True
                End If

                'If gvGenSalary.Visible = True Then
                '    ControlsPanel.Visible = False
                '    PasswordPanel.Visible = True
                '    lblpassError.Text = ""
                '    GVFill()
                'Else
                '    lblmsg.Text = "Salary Not yet generated for the month " + ddlMonth.SelectedItem.Text + " and year " + txtYear.Text + "."
                '    lblGreen.Text = ""
                '    gvGenSalary.Visible = False
                'End If
            Else
                lblmsg.Text = "You do not belong to this branch, cannot lock/unlock data."
                lblGreen.Text = ""
            End If
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            DDLDeptType.Focus()
            txtPaymentdate.Text = Today.Date.ToString("dd-MMM-yyyy")
            txtPaymentrunDate.Text = Today.Date.ToString("dd-MMM-yyyy")
            'txtYear.Text = Today.Year
            ddlMonth.SelectedValue = Today.Month
            lblmsg.Text = ""
        End If
        Image1.Visible = True
        Image2.Visible = True
    End Sub
    Sub GVFill()
        LinkButton1.Focus()
        If ddlYear.SelectedItem.Text <> "" Then
            Prop.Year = ddlYear.SelectedItem.Text
            Prop.Month = ddlMonth.SelectedItem.Text
            Prop.Dept = DDLDeptType.SelectedValue
            Dim dt2 As New DataTable
            'gvGenSalary.DataSource = BLL.GetDetails(Prop)
            dt2 = BLL.RptSalSlip(Prop)
            Prop.Lock = BLL.LockStatus(Prop)

            If dt2.Rows.Count > 0 Then
                If Prop.Lock = "Y" Then

                    gvGenSalary.DataSource = dt2
                    gvGenSalary.DataBind()
                    gvGenSalary.Visible = True
                    gvGenSalary.Enabled = False
                Else
                    gvGenSalary.DataSource = dt2
                    gvGenSalary.DataBind()
                    gvGenSalary.Visible = True
                    gvGenSalary.Enabled = True
                End If

            Else
                lblmsg.Text = "No Records to display"
                lblGreen.Text = ""
                gvGenSalary.Visible = False
            End If

        Else
            lblmsg.Text = " Year field is Mandatory."
            lblGreen.Text = ""
        End If
        'If gvGenSalary.Rows.Count > 0 Then
        '    lblmsg.Text = "No records to display"
        '    lblGreen.Text = ""
        'End If
    End Sub
    Protected Sub ddlMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMonth.SelectedIndexChanged
        GVFill()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then


            lblGreen.Text = ""
            lblmsg.Text = ""
            GVFill()
            txtWorkingDays.Text = ""
            txtTotalDays.Text = ""
        Else
            lblmsg.Text = "You do not have Read Privilage."
        End If
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If Session("Privilages").ToString.Contains("W") Then

            If txtPassword.Text = Session("Password") Then
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                Prop.Year = ddlYear.SelectedItem.Text
                Prop.Month = ddlMonth.SelectedItem.Text
                Prop.Dept = DDLDeptType.SelectedValue
                Prop.Lock = BLL.LockStatus(Prop)

                If Prop.Lock = "Y" Then
                    BLL.LockSalary(Prop)
                    lblmsg.Text = ""
                    lblGreen.Text = "Salary Unlocked for the month " + ddlMonth.SelectedItem.Text + " successfully."
                    gvGenSalary.Enabled = True
                    Image1.Visible = True
                    Image2.Visible = True
                Else
                    BLL.LockSalary(Prop)
                    gvGenSalary.Enabled = False
                    lblmsg.Text = ""
                    lblGreen.Text = "Salary Locked for the month " + ddlMonth.SelectedItem.Text + " successfully."
                    Image1.Visible = True
                    Image2.Visible = True
                End If
                'Else
                '    lblmsg.Text = "Salary Not yet Generated for the month " + ddlMonth.SelectedItem.Text + "."
                '    lblGreen.Text = ""
                'End If

            ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                lblmsg.Text = "Password Incorrect."
                lblGreen.Text = ""
                Image1.Visible = True
                Image2.Visible = True
            End If
            btnLockSalary.Focus()
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub ddlMonth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMonth.TextChanged
        ddlMonth.Focus()
    End Sub

    Protected Sub gvGenSalary_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvGenSalary.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        LinkButton1.Focus()
        Prop.Year = ddlYear.SelectedItem.Text
        Prop.Month = ddlMonth.SelectedItem.Text
        Dim dt2 As New DataTable
        'gvGenSalary.DataSource = BLL.GetDetails(Prop)
        dt2 = BLL.RptSalSlip(Prop)
        Prop.Lock = BLL.LockStatus(Prop)
        Dim sortedView As New DataView(dt2)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        gvGenSalary.DataSource = sortedView
        gvGenSalary.DataBind()

        If Prop.Lock = "Y" Then
            gvGenSalary.Visible = True
            gvGenSalary.Enabled = False
        Else
            gvGenSalary.Visible = True
            gvGenSalary.Enabled = True
        End If

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

    Protected Sub BtnNegativeSalary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnNegativeSalary.Click
        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then


            lblGreen.Text = ""
            lblmsg.Text = ""
            GVFill1()
            txtWorkingDays.Text = ""
            txtTotalDays.Text = ""
        Else
            lblmsg.Text = "You do not have Read Privilage."
        End If
    End Sub
    Sub GVFill1()
        LinkButton1.Focus()
        If ddlYear.SelectedItem.Text <> "" Then
            Prop.Year = ddlYear.SelectedItem.Text
            Prop.Month = ddlMonth.SelectedItem.Text
            Prop.Dept = DDLDeptType.SelectedValue
            Dim dt2 As New DataTable
            'gvGenSalary.DataSource = BLL.GetDetails(Prop)
            dt2 = BLL.RptSalSlip1(Prop)
            Prop.Lock = BLL.LockStatus(Prop)

            If dt2.Rows.Count > 0 Then
                If Prop.Lock = "Y" Then

                    gvGenSalary.DataSource = dt2
                    gvGenSalary.DataBind()
                    gvGenSalary.Visible = True
                    gvGenSalary.Enabled = False
                Else
                    gvGenSalary.DataSource = dt2
                    gvGenSalary.DataBind()
                    gvGenSalary.Visible = True
                    gvGenSalary.Enabled = True
                End If

            Else
                lblmsg.Text = "No Records to display"
                lblGreen.Text = ""
                gvGenSalary.Visible = False
            End If

        Else
            lblmsg.Text = " Year field is Mandatory."
            lblGreen.Text = ""
        End If
        'If gvGenSalary.Rows.Count > 0 Then
        '    lblmsg.Text = "No records to display"
        '    lblGreen.Text = ""
        'End If
    End Sub

    Protected Sub btnCalcPF_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCalcPF.Click
        If Session("Privilages").ToString.Contains("W") Then

            Prop.Year = ddlYear.SelectedItem.Text
            Prop.Month = ddlMonth.SelectedItem.Text
            Prop.Dept = DDLDeptType.SelectedValue

            Dim dt As New DataTable
            Dim Gross, PF, NetSalary As Double
            Dim CalcPF As String
            Dim id As Integer
            dt = BLL.SelectPF(Prop)
            CalcPF = dt.Rows(0).Item("Cal_PfroTax").ToString
            If CalcPF = "Y" Then
                lblmsg.Text = "Prof Tax already calculated."
                lblGreen.Text = ""
                Exit Sub
            End If
            If RbTYPE.SelectedValue = 1 Then
                lblGreen.Text = ""
                lblmsg.Text = ""
                GVFill()
                txtWorkingDays.Text = ""
                txtTotalDays.Text = ""
                For Each rows As GridViewRow In gvGenSalary.Rows

                    Gross = CType(rows.FindControl("lblGSalary"), Label).Text
                    id = CType(rows.FindControl("lblId"), Label).Text
                    If Gross <= 14999 And Gross >= 10000 Then
                        PF = 150
                        NetSalary = CType(rows.FindControl("lblNSalary"), Label).Text - 150
                        CType(rows.FindControl("lblNSalary"), Label).Text = Format(NetSalary, "0.00")

                    ElseIf Gross >= 15000 Then
                        PF = 200
                        NetSalary = CType(rows.FindControl("lblNSalary"), Label).Text - 200
                        CType(rows.FindControl("lblNSalary"), Label).Text = Format(NetSalary, "0.00")

                    Else
                        PF = 0
                        NetSalary = CType(rows.FindControl("lblNSalary"), Label).Text
                        CType(rows.FindControl("lblNSalary"), Label).Text = Format(NetSalary, "0.00")
                    End If
                    BLL.UpdatePF(id, PF, NetSalary)
                    NetSalary = "0.00"
                    PF = "0.00"
                Next

            Else
                lblGreen.Text = ""
                lblmsg.Text = ""
                GVFill()
                txtWorkingDays.Text = ""
                txtTotalDays.Text = ""

                For Each rows As GridViewRow In gvGenSalary.Rows
                    id = CType(rows.FindControl("lblId"), Label).Text
                    NetSalary = CType(rows.FindControl("lblNSalary"), Label).Text
                    If NetSalary <= 14999 And NetSalary >= 10000 Then
                        PF = 150
                        NetSalary = CType(rows.FindControl("lblNSalary"), Label).Text - 150
                        CType(rows.FindControl("lblNSalary"), Label).Text = Format(NetSalary, "0.00")

                    ElseIf NetSalary >= 15000 Then
                        PF = 200
                        NetSalary = CType(rows.FindControl("lblNSalary"), Label).Text - 200
                        CType(rows.FindControl("lblNSalary"), Label).Text = Format(NetSalary, "0.00")
                    Else
                        PF = 0
                        NetSalary = CType(rows.FindControl("lblNSalary"), Label).Text
                        CType(rows.FindControl("lblNSalary"), Label).Text = Format(NetSalary, "0.00")
                    End If
                    BLL.UpdatePF(id, PF, NetSalary)
                    NetSalary = "0.00"
                    PF = "0.00"
                Next
            End If

            GVFill()
            lblGreen.Text = "Prof. tax calculated successfully."
            lblmsg.Text = ""
        Else
            lblmsg.Text = "You do not have Write Privilage."
        End If
    End Sub
End Class



