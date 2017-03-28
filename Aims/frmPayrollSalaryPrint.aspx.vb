
Partial Class frmPayrollSalaryPrint
    Inherits BasePage
    Dim DL As New DLPayRollSalaryPrint
    Dim dt, dt1, dt2, dt3 As DataTable
    Sub CheckAll()
        If CType(GridView1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            GridView1.Visible = True

            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = True
            Next
        Else
            GridView1.Visible = True


            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = False
            Next
        End If

    End Sub

    Protected Sub btnLoad_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        DisplayGrid()
    End Sub
    Sub DisplayGrid()
        Dim month, year As String
        If ddlMonth.SelectedValue = 0 Then
            lblErrorMsg.Text = "Select Month"
            Exit Sub
        Else
            month = ddlMonth.SelectedItem.Text
        End If

        If ddlYear.SelectedValue = 0 Then
            lblErrorMsg.Text = "Select Year"
            Exit Sub
        Else
            year = ddlYear.SelectedItem.Text
        End If
       


        dt = DLPayRollSalaryPrint.GridViewLoadData(month, year)
        If Dt.Rows.Count > 0 Then
            lblMsg.Text = ""
            lblErrorMsg.Text = ""
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataSource = Dt
            GridView1.DataBind()
            dt2 = DLPayRollSalaryPrint.CheckChequeNoLockStatus(month, year)
            If dt2.Rows.Count > 0 Then
                GridView1.Enabled = False
            End If
        Else
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "No records to display."
            GridView1.Visible = False
        End If
    End Sub

    Protected Sub btnGenerate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If ddlMonth.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select month to Generate Cheque No."
        ElseIf ddlYear.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select year to Generate Hall Cheque No."
        ElseIf txtAddChqNo.Text = "" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please enter add Cheque No."
        ElseIf ddlbank.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select bank to Generate Hall Cheque No."
        ElseIf txtAddChqNo.Text = "" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please enter add Cheque Date."
        ElseIf IsNumeric(txtAddChqNo.Text) = True Then
            Dim FromChequeNo As Integer = txtAddChqNo.Text
            Dim month, year As String
            Dim ChequeDate As DateTime
            Dim FromCheque, bank As Integer
            bank = ddlbank.SelectedValue
            month = ddlMonth.SelectedItem.Text
            year = ddlYear.SelectedItem.Text
            ChequeDate = txtChequeDate.Text


            dt1 = DLPayRollSalaryPrint.ViewChequeNo(month, year)
            For i = 0 To dt1.Rows.Count - 1 Step 1

                If IsDBNull(dt1.Rows(i).Item("ChequeNo")) = True Then
                    dt1.Rows(i).Item("ChequeNo") = FromChequeNo 
                    Session("AdmitId") = dt1.Rows(i).Item("Id")
                    FromCheque = FromChequeNo
                    DLPayRollSalaryPrint.UpdateChequeNo(month, year, FromCheque, ChequeDate, bank, Session("AdmitId"))
                    FromChequeNo = FromChequeNo + 1
                ElseIf dt1.Rows(i).Item("ChequeNo") = "" Then
                    dt1.Rows(i).Item("ChequeNo") = FromChequeNo
                    Session("AdmitId") = dt1.Rows(i).Item("Id")
                    FromCheque = FromChequeNo
                    DLPayRollSalaryPrint.UpdateChequeNo(month, year, FromCheque, ChequeDate, bank, Session("AdmitId"))
                End If

            Next
            DisplayGrid()
            lblMsg.Visible = True
            lblErrorMsg.Visible = False
            lblMsg.Text = "Cheque No. Allocated Successfully."
            txtAddChqNo.Text = ""
            txtChequeDate.Text = ""
            ddlbank.SelectedValue = 0
        Else

            lblMsg.Visible = True
            lblErrorMsg.Visible = False
            lblErrorMsg.Text = "Please Enter Numeric value in Add Cheque No."

        End If
    End Sub

    Protected Sub btnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Dim month, year As String

        month = ddlMonth.SelectedItem.Text
        year = ddlYear.SelectedItem.Text
        dt = DLPayRollSalaryPrint.GridViewLoadData(month, year)
        If dt.Rows.Count = 0 Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "No records to Clear."
            Exit Sub
        End If

        dt2 = DLPayRollSalaryPrint.CheckChequeNoLockStatus(month, year)
        If dt2.Rows.Count > 0 Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please unlock the records to Clear."

        Else

            If ddlMonth.SelectedItem.Text = "Select" Or ddlMonth.SelectedItem.Text = "Select" Then
                lblMsg.Visible = False
                lblErrorMsg.Visible = True
                lblErrorMsg.Text = "Please select the Month and Year to clear Cheque No."
            Else

                DLPayRollSalaryPrint.ClearGenerateChequeNo(month, year)
                lblMsg.Visible = True
                lblErrorMsg.Visible = False
                lblMsg.Text = "Cheque No. cleared successfully."
                GridView1.Visible = False
            End If

        End If
    End Sub

    Protected Sub btnLock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLock.Click
        Dim month, year As String
        month = ddlMonth.SelectedItem.Text
        year = ddlYear.SelectedItem.Text
        If ddlMonth.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select the Month to Lock/Unlock the records."
        ElseIf ddlYear.SelectedItem.Text = "Select" Then
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Please select the Year to Lock/Unlock the records."
        Else
            dt2 = DLPayRollSalaryPrint.CountRecordsChequeNo(month, year)

            If dt2.Rows.Count > 0 Then

                ControlsPanel.Visible = False
                PasswordPanel.Visible = True
                txtPassword.Focus()
                lblpassError.Text = ""
                Image1.Visible = False
                Image2.Visible = False
            Else
                ControlsPanel.Visible = True
                PasswordPanel.Visible = False
                lblMsg.Visible = False
                lblErrorMsg.Visible = True
                lblErrorMsg.Text = "No Records to Lock/Unlock."
                Image1.Visible = True
                Image2.Visible = True

            End If
        End If
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPassword.Click
        Dim Check As String
        If txtPassword.Text = Session("Password") Then
            Dim month, year As String
            month = ddlMonth.SelectedItem.Text
            year = ddlYear.SelectedItem.Text
            '1
            If Trim(DLPayRollSalaryPrint.RecordsGenChequeNo(month, year).Tables(0).Rows(0).Item(0)) = "N" Then
                Dim roweffected As Integer = DLPayRollSalaryPrint.LockGenerateChequeNo(month, year)
                If roweffected > 0 Then
                    ControlsPanel.Visible = True
                    PasswordPanel.Visible = False
                    lblErrorMsg.Visible = False
                    lblMsg.Visible = True
                    'lblMsg.Text = roweffected.ToString + " record(s) Locked."
                    lblMsg.Text = " record(s) Locked."
                    GridView1.Enabled = False
                    Image1.Visible = True
                    Image2.Visible = True
                End If
                '1
            Else

                Dim role As String
                role = Session("UserRole")
                'Dim checkUnlock As String
                ' dt1 = DLNew_StudentMarks.CheckUnlockStatus(role)
                '2
                If Session("SecurityCheck") = "Security Check" Then

                    dt = DLPayRollSalaryPrint.UnlockChequeNo(role)
                    '3
                    If dt.Rows.Count < 1 Then
                        lblErrorMsg.Visible = True
                        lblErrorMsg.Text = "You don't have Unlock Permission."
                        lblMsg.Visible = False
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        GridView1.Enabled = False
                        Image1.Visible = True
                        Image2.Visible = True
                    Else
                        Check = dt.Rows(0)("Result").ToString.Trim

                        'check = dt.Rows(0)("Result").ToString.Trim
                        '4
                        If Check = "" Then
                            lblErrorMsg.Visible = True
                            lblErrorMsg.Text = "You don't have Unlock Permission."
                            lblMsg.Visible = False
                            ControlsPanel.Visible = True
                            PasswordPanel.Visible = False
                            GridView1.Enabled = False
                            Image1.Visible = True
                            Image2.Visible = True
                            '4
                        Else
                            Dim roweffected As Integer = DLPayRollSalaryPrint.UnLockGenerateChequeNo(month, year)
                            If roweffected > 0 Then
                                ControlsPanel.Visible = True
                                PasswordPanel.Visible = False
                                lblErrorMsg.Visible = False
                                lblMsg.Visible = True
                                lblMsg.Text = " record(s) Unlocked."
                                'lblMsg.Text = roweffected.ToString + " record(s) Unlocked."
                                GridView1.Enabled = True
                                Image1.Visible = True
                                Image2.Visible = True
                            End If
                            '4
                        End If
                        '3
                    End If
                    '2
                Else
                    Dim roweffected As Integer = DLPayRollSalaryPrint.UnLockGenerateChequeNo(month, year)
                    If roweffected > 0 Then
                        ControlsPanel.Visible = True
                        PasswordPanel.Visible = False
                        lblErrorMsg.Visible = False
                        lblMsg.Visible = True
                        'lblMsg.Text = roweffected.ToString + " record(s) Unlocked."
                        lblMsg.Text = " record(s) Unlocked."
                        GridView1.Enabled = True
                        Image1.Visible = True
                        Image2.Visible = True
                    End If
                    '2
                End If
                '1
            End If
        ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
            ControlsPanel.Visible = True
            PasswordPanel.Visible = False
            lblMsg.Visible = False
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Enter correct password."
            Image1.Visible = True
            Image2.Visible = True
            lblMsg.Text = ""
        End If
    End Sub
    Protected Sub BtnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Dim path, FName As String

        dt = DLPayRollSalaryPrint.GetPrintPath()
        If dt.Rows.Count > 0 Then
            path = dt.Rows(0).Item("Config_Value")
            FName = IO.Path.GetFileName(path)
            If IO.File.Exists(path) Then
                ScriptManager.RegisterStartupScript(Me, Me.GetType(), "callFunctionsStartupScript", "RunExe();", True)
            Else
                lblErrorMsg.Text = "PrintCheque.exe file not found."
            End If
        Else
            lblErrorMsg.Text = "No records to display."
        End If

    End Sub

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim path As String
        dt = DLPayRollSalaryPrint.GetPrintPath()
        path = dt.Rows(0).Item("Config_Value")
        Session("PayrollChequepath") = path
    End Sub
End Class
