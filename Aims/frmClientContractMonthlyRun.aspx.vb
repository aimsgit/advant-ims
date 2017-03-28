
Partial Class frmClientContractMonthlyRun
    Inherits BasePage
    Dim DL As New DLCCMonthlyRun
    Dim EL As New ELCCMonthlyRun
    Dim DT, dt1, dt2, dt4 As New DataTable
    Dim ClientId As String
    Dim BranchCode As String
    Dim demail, dtmessage As New DataTable
    Dim Fromdate As String
    Dim ToDate As String
    Dim Yearfrom As String
    Dim YearTo As String
    Dim InvoiceNo As String
    Dim Invdate As Date

    Protected Sub btnGen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGen.Click
        Try
            'If DdlSelectClient.SelectedValue = "0" Or DdlSelectBranch.SelectedValue = "0" Then
            '    lblRed.Text = "Select Mandatory Fields."
            '    lblGreen.Text = ""
            '    Exit Sub
            'End If
            If ddlFrmYear.SelectedValue > ddltoYear.SelectedValue Then
                lblRed.Text = "From Year cannot be Greater than To Year."
                lblGreen.Text = ""
                Exit Sub

            Else
                If ddlFrmYear.SelectedValue = ddltoYear.SelectedValue Then
                    If ddlfrmMonth.SelectedValue > ddltomonth.SelectedValue Then
                        lblRed.Text = "From Month cannot be Greater than To Month."
                        lblGreen.Text = ""
                        GridView1.Visible = False
                        Exit Sub
                    End If
                End If
            End If
            'If ddlfrmMonth.SelectedValue > ddltomonth.SelectedValue Then
            '    lblRed.Text = "From Month Cannot be greater than to month."
            '    lblGreen.Text = ""
            '    Exit Sub
            'End If
            'If ddlFrmYear.SelectedValue > ddltoYear.SelectedValue Then
            '    lblRed.Text = "From Year Cannot be greater than to Year."
            '    lblGreen.Text = ""
            '    Exit Sub
            'End If
            EL.ClientID = DdlSelectClient.SelectedValue
            EL.BranchCode = DdlSelectBranch.SelectedValue
            EL.FromMonth = ddlfrmMonth.SelectedValue
            EL.FromYear = ddlFrmYear.SelectedItem.Text
            EL.ToMonth = ddltomonth.SelectedValue
            EL.ToYear = ddltoYear.SelectedItem.Text

            dt4 = DLCCMonthlyRun.chkactive(EL)
            If dt4.Rows.Count = 0 Then
                lblRed.Text = "Branch has been expired or Inactive."
                lblGreen.Text = ""
                Exit Sub
            End If
            If DL.GetClientcontractmonthlyrun(EL).Rows.Count <= 0 Then
                DT = DL.Clientcontractmonthlyrun(EL)
                If DT.Rows.Count <> 0 Then
                    GridView1.DataSource = DT
                    GridView1.DataBind()
                    GridView1.Visible = True
                    lblRed.Text = ""
                    lblGreen.Text = ""
                    For Each grid As GridViewRow In GridView1.Rows
                        dt2 = DL.AutoGenerateNo(EL)
                        CType(grid.FindControl("txtInvNo"), TextBox).Text = dt2.Rows(0).Item("InvoiceNo").ToString()
                        EL.id = CType(grid.FindControl("lblPKID"), Label).Text
                        'DL.UpdateClientcontractInvoiceNo(EL)
                        EL.InvoiceNo = dt2.Rows(0).Item("InvoiceNo").ToString()
                        DL.UpdateClientcontractInvoiceNo(EL)
                    Next
                Else
                    lblRed.Text = "Data already Exists."
                    lblGreen.Text = ""
                    GridView1.Visible = False
                End If
            Else
                lblRed.Text = "Data already Exists."
                lblGreen.Text = ""
                GridView1.Visible = False
            End If
        Catch ex As Exception
            DT = DL.GetClientcontractmonthlyrun(EL)
            GridView1.DataSource = DT
            GridView1.DataBind()
            GridView1.Visible = True
            lblRed.Text = ""
            lblGreen.Text = ""
            For Each grid As GridViewRow In GridView1.Rows
                DT = DL.AutoGenerateNo(EL)
                EL.InvoiceNo = DT.Rows(0).Item("InvoiceNo").ToString()
                EL.id = CType(grid.FindControl("lblPKID"), Label).Text
                DL.UpdateClientcontractInvoiceNo(EL)
                CType(grid.FindControl("txtInvNo"), TextBox).Text = DT.Rows(0).Item("InvoiceNo").ToString()
            Next
        End Try
        DT = DL.GetClientcontractmonthlyrun(EL)
        GridView1.DataSource = DT
        GridView1.DataBind()
        GridView1.Visible = True
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        'If ddlfrmMonth.SelectedValue > ddltomonth.SelectedValue Then
        '    lblRed.Text = "From Month Cannot be greater than to month."
        '    lblGreen.Text = ""
        '    Exit Sub
        'End If
        'If ddlFrmYear.SelectedValue > ddltoYear.SelectedValue Then
        '    lblRed.Text = "From Year Cannot be greater than to Year."
        '    lblGreen.Text = ""
        '    Exit Sub
        'End If

        If ddlFrmYear.SelectedValue > ddltoYear.SelectedValue Then
            lblRed.Text = "From Year cannot be Greater than To Year."
            lblGreen.Text = ""
            Exit Sub
        Else
            If ddlFrmYear.SelectedValue = ddltoYear.SelectedValue Then
                If ddlfrmMonth.SelectedValue > ddltomonth.SelectedValue Then
                    lblRed.Text = "From Month cannot be Greater than To Month."
                    lblGreen.Text = ""
                    GridView1.Visible = False
                    Exit Sub
                End If
            End If
        End If
        btnLockUnlock.Enabled = True
            EL.ClientID = DdlSelectClient.SelectedValue
            EL.BranchCode = DdlSelectBranch.SelectedValue
            EL.FromMonth = ddlfrmMonth.SelectedValue
            EL.FromYear = ddlFrmYear.SelectedItem.Text
            EL.ToMonth = ddltomonth.SelectedValue
            EL.ToYear = ddltoYear.SelectedItem.Text

            DT = DL.GetClientcontractmonthlyrun(EL)
            If DT.Rows.Count <> 0 Then
                GridView1.DataSource = DT
                GridView1.DataBind()
                For Each grid As GridViewRow In GridView1.Rows
                    If CType(grid.FindControl("lblPreAudit"), Label).Text = "Y" Then
                        CType(grid.FindControl("ChkBx"), CheckBox).Checked = True
                    End If
                Next
                For Each grid As GridViewRow In GridView1.Rows
                    If CType(grid.FindControl("lblReceived"), Label).Text = "Y" Then
                        CType(grid.FindControl("ChkBx1"), CheckBox).Checked = True
                    End If
                Next
                GridView1.Visible = True
                lblRed.Text = ""
            lblGreen.Text = ""
            dt4 = DL.CountData1(EL)
            If dt4.Rows(0).Item("LockUnlock") = "Y" Then
                GridView1.Enabled = False

            End If

        Else
            lblRed.Text = "No records to display."
            lblGreen.Text = ""
            GridView1.Visible = False
        End If

    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click

        For Each grid As GridViewRow In GridView1.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                If CType(grid.FindControl("ChkBx1"), CheckBox).Checked = True Then
                    EL.id = CType(grid.FindControl("lblPKID"), Label).Text
                    EL.InvoiceNo = CType(grid.FindControl("txtInvNo"), TextBox).Text
                    DL.UpdateClientcontractmonthlyrun(EL, "Y", "Y")
                    lblGreen.Text = "Records Updated Successfully."
                    ViewState("Updated") = "True"
                    lblRed.Text = ""
                Else
                    EL.id = CType(grid.FindControl("lblPKID"), Label).Text
                    EL.InvoiceNo = CType(grid.FindControl("txtInvNo"), TextBox).Text
                    DL.UpdateClientcontractmonthlyrun(EL, "Y", "N")
                    lblGreen.Text = "Records Updated Successfully."
                    ViewState("Updated") = "True"
                    lblRed.Text = ""
                End If
                
            Else
                If CType(grid.FindControl("ChkBx1"), CheckBox).Checked = True Then
                    EL.id = CType(grid.FindControl("lblPKID"), Label).Text
                    EL.InvoiceNo = CType(grid.FindControl("txtInvNo"), TextBox).Text
                    DL.UpdateClientcontractmonthlyrun(EL, "N", "Y")
                    lblGreen.Text = "Records Updated Successfully."
                    ViewState("Updated") = "True"
                    lblRed.Text = ""
                Else
                    EL.id = CType(grid.FindControl("lblPKID"), Label).Text
                    EL.InvoiceNo = CType(grid.FindControl("txtInvNo"), TextBox).Text
                    DL.UpdateClientcontractmonthlyrun(EL, "N", "N")
                    lblGreen.Text = "Records Updated Successfully."
                    ViewState("Updated") = "True"
                    lblRed.Text = ""
                End If
            End If
        Next
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        EL.ClientID = DdlSelectClient.SelectedValue
        EL.BranchCode = DdlSelectBranch.SelectedValue
        EL.FromMonth = ddlfrmMonth.SelectedValue
        EL.FromYear = ddlFrmYear.SelectedItem.Text
        EL.ToMonth = ddltomonth.SelectedValue
        EL.ToYear = ddltoYear.SelectedItem.Text
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DT = DL.GetClientcontractmonthlyrun(EL)
        GridView1.DataSource = DT
        GridView1.DataBind()
        GridView1.Visible = True
    End Sub

    Protected Sub btnLockUnlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLockUnlock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.ClientID = DdlSelectClient.SelectedValue
            EL.BranchCode = DdlSelectBranch.SelectedValue
            EL.FromMonth = ddlfrmMonth.SelectedValue
            EL.FromYear = ddlFrmYear.SelectedItem.Text
            EL.ToMonth = ddltomonth.SelectedValue
            EL.ToYear = ddltoYear.SelectedItem.Text
            Dim dt3 As DataTable
            dt3 = DL.GetClientcontractmonthlyrun(EL)
            If dt3.Rows.Count > 0 Then

                panel1.Visible = False
                PasswordPanel.Visible = True
                txtPassword.Focus()
                lblpassError.Text = ""
            
            Else
                panel1.Visible = True
                PasswordPanel.Visible = False
                lblGreen.Text = ""
                lblRed.Text = ""
                lblRed.Text = "No Records to Lock/Unlock."
             

            End If
        Else
            lblRed.Text = "You do not belong to this branch, Cannot Lock/Unlock data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        Dim Check As String
        If txtPassword.Text = Session("Password") Then
            EL.ClientID = DdlSelectClient.SelectedValue
            EL.BranchCode = DdlSelectBranch.SelectedValue
            EL.FromMonth = ddlfrmMonth.SelectedValue
            EL.FromYear = ddlFrmYear.SelectedItem.Text
            EL.ToMonth = ddltomonth.SelectedValue
            EL.ToYear = ddltoYear.SelectedItem.Text
            If DL.CountData(EL).Tables(0).Rows(0).Item(0) = "N" Then
                Dim roweffected As Integer = DLCCMonthlyRun.LockSummary(EL)
                If roweffected > 0 Then
                    panel1.Visible = True
                    PasswordPanel.Visible = False
                    lblRed.Text = ""
                    lblGreen.Text = roweffected.ToString + " Records are Locked."
                    'DisplayGrid(0)
                    GridView1.Enabled = False

                End If
                '1
            Else

                'Dim role As String
                'role = Session("UserRole")
                ''Dim checkUnlock As String
                '' dt1 = DLNew_StudentMarks.CheckUnlockStatus(role)
                ''2
                'If Session("SecurityCheck") = "Security Check" Then

                '    DT = DLCCMonthlyRun.GetunlockData(role)
                '    '3
                '    If DT.Rows.Count < 1 Then
                '        lblRed.Text = "You don't have Unlock Permission."
                '        lblGreen.Text = ""
                '        panel1.Visible = True
                '        PasswordPanel.Visible = False
                '        GridView1.Enabled = False

                '    Else
                '        Check = DT.Rows(0)("Result").ToString.Trim

                '        'check = dt.Rows(0)("Result").ToString.Trim
                '        '4
                '        If Check = "" Then

                '            lblRed.Text = "You don't have Unlock Permission."
                '            lblGreen.Text = ""
                '            panel1.Visible = True
                '            PasswordPanel.Visible = False
                '            GridView1.Enabled = False

                '            '4
                '        Else
                '            Dim roweffected As Integer = DLCCMonthlyRun.Unlock(EL)
                '            If roweffected > 0 Then
                '                panel1.Visible = True
                '                PasswordPanel.Visible = False
                '                lblRed.Text = ""
                '                lblGreen.Text = roweffected.ToString + " Records are  Unlocked."
                '                'DisplayGrid(0)

                '            End If
                '            '4
                '        End If
                '        '3
                '    End If
                '    '2
                'Else
                Dim roweffected As Integer = DLCCMonthlyRun.Unlock(EL)
                If roweffected > 0 Then
                    panel1.Visible = True
                    PasswordPanel.Visible = False
                    GridView1.Visible = True
                    GridView1.Enabled = True
                    lblRed.Text = ""
                    lblGreen.Text = roweffected.ToString + " Records Unlocked."
                    'DisplayGrid(0)

                End If
                '2
            End If
            '1

        ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
        panel1.Visible = True
        PasswordPanel.Visible = False
        lblGreen.Text = ""
        lblRed.Text = ""
        lblRed.Text = "Enter correct password"
        lblGreen.Text = ""
        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        EL.ClientID = DdlSelectClient.SelectedValue
        EL.BranchCode = DdlSelectBranch.SelectedValue
        EL.FromMonth = ddlfrmMonth.SelectedValue
        EL.FromYear = ddlFrmYear.SelectedItem.Text
        EL.ToMonth = ddltomonth.SelectedValue
        EL.ToYear = ddltoYear.SelectedItem.Text
        dt4 = DL.CountData1(EL)
        If dt4.Rows(0).Item("LockUnlock") = "Y" Then
            lblRed.Text = "Record(s) locked, connot be cleared."
            lblGreen.Text = ""
            Exit Sub
        End If
        For Each grid As GridViewRow In GridView1.Rows
            ClientId = DdlSelectClient.SelectedValue
            BranchCode = DdlSelectBranch.SelectedValue
            Fromdate = ddlfrmMonth.SelectedValue
            ToDate = ddltomonth.SelectedValue
            Yearfrom = ddlFrmYear.SelectedItem.Text
            YearTo = ddltoYear.SelectedItem.Text

            InvoiceNo = CType(grid.FindControl("txtInvNo"), TextBox).Text
            'Dim BranchCode As String = Request.QueryString.Get(("BranchCode"))
            'If txtInvoiceNo.Text = "" Then
            '    lblmsg.Text = " Enter Invoice Number."
            '    lblmsgG.Text = ""
            'Else

            If DLCCMonthlyRun.ClearInvoiceData(ClientId, BranchCode, Fromdate, ToDate, Yearfrom, YearTo, InvoiceNo) = 0 Then
                lblRed.Text = "Data connot be cleared."
                lblGreen.Text = ""
                Exit Sub
            Else
                lblGreen.Text = "Data is cleared."
                lblRed.Text = ""
                GridView1.Visible = False
            End If
            'End If
        Next
    End Sub
End Class
