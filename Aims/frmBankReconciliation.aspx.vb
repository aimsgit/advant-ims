
Partial Class frmBankReconciliation
    Inherits BasePage
    Dim el As New BRSEntity
    Dim BRS As New BRS
    Dim dt As New DataTable
   
    Protected Sub btnAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAll.Click
        If Session("Privilages").ToString.Contains("W") Then
            Try
                lblErrorMsg.Text = ""
                msginfo.Text = ""
                lblmsg.Text = ""
                If ddlTable.SelectedValue = 0 Then
                    el.table = "DB"
                Else
                    el.table = "FC"
                End If
                el.StatusFlag = "A"
                ViewState("Status") = el.StatusFlag
                el.FromDate = txtFromDate.Text
                el.ToDate = txtToDate.Text
                dt = BRS.GetBRS(el)
                GridView1.DataSource = dt
                GridView1.DataBind()
                If ddlTable.SelectedValue = 0 Then

                    If dt.Rows.Count > 0 Then
                        For Each rows As GridViewRow In GridView1.Rows
                            Dim a As String
                            a = dt.Rows(0).Item("Particulars").ToString
                            If dt.Rows(0).Item("Particulars").ToString = "Voucher" Then
                                If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                                    'CType(rows.FindControl("StatusFlag1"), Label).Text = "Not Cleared"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                    CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                                End If
                            Else
                                If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                                    'CType(rows.FindControl("StatusFlag1"), Label).Text = "Not Presented"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                    CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                                End If
                            End If
                        Next
                        btnUpdate.Visible = True
                        GridView1.Visible = True
                    Else
                        msginfo.Text = "No records to display."
                        lblmsg.Text = ""
                        btnUpdate.Visible = False
                    End If
                Else
                    If dt.Rows.Count > 0 Then
                        For Each rows As GridViewRow In GridView1.Rows
                            If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                                CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                                'CType(rows.FindControl("StatusFlag1"), Label).Text = "Not Cleared"

                            ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                                CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                            ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                            End If
                        Next
                        btnUpdate.Visible = True
                        GridView1.Visible = True
                    Else
                        msginfo.Text = "No records to display."
                        lblmsg.Text = ""
                        btnUpdate.Visible = False
                    End If
                End If
            Catch ex As Exception
                msginfo.Text = "Date is not valid."
            End Try
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub BtnClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClear.Click
        If Session("Privilages").ToString.Contains("W") Then

            Try
                If (Session("BranchCode") = Session("ParentBranch")) Then
                    lblErrorMsg.Text = ""
                    msginfo.Text = ""
                    lblmsg.Text = ""
                    If ddlTable.SelectedValue = 0 Then
                        el.table = "DB"
                    Else
                        el.table = "FC"
                    End If
                    el.StatusFlag = "C"
                    el.FromDate = txtFromDate.Text
                    el.ToDate = txtToDate.Text
                    ViewState("Status") = el.StatusFlag
                    dt = BRS.GetBRS(el)
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    If dt.Rows.Count > 0 Then
                        For Each rows As GridViewRow In GridView1.Rows
                            If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                                CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                                'CType(rows.FindControl("Clear"), Label).Text = "Not Cleared"

                            ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                                CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                            ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                            End If
                        Next
                        btnUpdate.Visible = True
                        GridView1.Visible = True
                    Else
                        msginfo.Text = "No records to display."
                        lblmsg.Text = ""
                        btnUpdate.Visible = False
                    End If
                Else
                    msginfo.Text = "You do not belong to this branch, cannot clear data."
                    lblmsg.Text = ""
                End If
            Catch ex As Exception
                msginfo.Text = "Date is not valid."
            End Try
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
        End If
    End Sub
    Protected Sub BtnUnclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUnclear.Click
        If Session("Privilages").ToString.Contains("W") Then
            Try
                'If (Session("BranchCode") = Session("ParentBranch")) Then
                lblErrorMsg.Text = ""
                msginfo.Text = ""
                lblmsg.Text = ""
                If ddlTable.SelectedValue = 0 Then
                    el.table = "DB"
                Else
                    el.table = "FC"
                End If
                el.StatusFlag = "U"
                ViewState("Status") = el.StatusFlag
                el.FromDate = txtFromDate.Text
                el.ToDate = txtToDate.Text

                dt = BRS.GetBRS(el)
                GridView1.DataSource = dt
                GridView1.DataBind()

                If ddlTable.SelectedValue = 0 Then
                    If dt.Rows.Count > 0 Then

                        If dt.Rows(0).Item("Amt_Out").ToString = "0.00" Then

                            For Each rows As GridViewRow In GridView1.Rows
                                If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                                    'CType(rows.FindControl("Clear"), Label).Text = "Not Cleared"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                    CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                                End If
                            Next
                            btnUpdate.Visible = True
                            GridView1.Visible = True
                            'Else
                            '    msginfo.Text = "No records to display."
                            '    lblmsg.Text = ""
                            '    btnUpdate.Visible = False
                            'End If
                        Else
                            'If dt.Rows.Count > 0 Then
                            For Each rows As GridViewRow In GridView1.Rows
                                If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                                    'CType(rows.FindControl("Clear"), Label).Text = "Not Presented"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                    CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                                End If
                            Next
                            btnUpdate.Visible = True
                            GridView1.Visible = True
                            'Else
                            '    msginfo.Text = "No records to display."
                            '    lblmsg.Text = ""
                            '    btnUpdate.Visible = False
                            'End If
                        End If
                    Else
                        If dt.Rows.Count > 0 Then
                            For Each rows As GridViewRow In GridView1.Rows
                                If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                                    'CType(rows.FindControl("Clear"), Label).Text = "Not Cleared"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                    CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                                End If
                            Next
                            btnUpdate.Visible = True
                            GridView1.Visible = True
                        Else
                            msginfo.Text = "No records to display."
                            lblmsg.Text = ""
                            btnUpdate.Visible = False
                        End If
                    End If
                    'Else
                    '    msginfo.Text = "You do not belong to this branch, cannot unclear data."
                    '    lblmsg.Text = ""

                Else
                    If dt.Rows.Count > 0 Then
                        For Each rows As GridViewRow In GridView1.Rows
                            If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                                CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                                'CType(rows.FindControl("Clear"), Label).Text = "Not Cleared"

                            ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                                CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                            ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                            End If
                        Next
                        btnUpdate.Visible = True
                        GridView1.Visible = True
                    Else
                        msginfo.Text = "No records to display."
                        lblmsg.Text = ""
                        btnUpdate.Visible = False
                    End If

                End If
            Catch ex As Exception
                msginfo.Text = "Date is not valid."
            End Try
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
        End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Try
            GridView1.PageIndex = e.NewPageIndex

            If ddlTable.SelectedValue = 0 Then
                el.table = "DB"
            Else
                el.table = "FC"
            End If
            el.StatusFlag = ViewState("Status")
            el.FromDate = txtFromDate.Text
            el.ToDate = txtToDate.Text
            dt = BRS.GetBRS(el)
            GridView1.DataSource = dt
            GridView1.DataBind()
            'If ddlTable.SelectedValue = 0 Then

            '    If dt.Rows.Count > 0 Then
            '        If dt.Rows(0).Item("Amt_Out").ToString = "0.00" Then

            '            For Each rows As GridViewRow In GridView1.Rows
            '                If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
            '                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
            '                    'CType(rows.FindControl("Clear"), Label).Text = "Not Cleared"

            '                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
            '                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
            '                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"
            '                End If
            '            Next
            '            btnUpdate.Visible = True
            '            GridView1.Visible = True
            '        Else
            '            msginfo.Text = "No records to display."
            '            lblmsg.Text = ""
            '            btnUpdate.Visible = False
            '        End If
            '    Else
            '        If dt.Rows.Count > 0 Then
            '            For Each rows As GridViewRow In GridView1.Rows
            '                If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
            '                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
            '                    'CType(rows.FindControl("StatusFlag1"), Label).Text = "Not Presented"

            '                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
            '                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
            '                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"
            '                End If
            '            Next
            '            btnUpdate.Visible = True
            '            GridView1.Visible = True
            '        Else
            '            msginfo.Text = "No records to display."
            '            lblmsg.Text = ""
            '            btnUpdate.Visible = False
            '        End If
            '    End If
            'Else
            If dt.Rows.Count > 0 Then
                For Each rows As GridViewRow In GridView1.Rows
                    If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                        CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                        'CType(rows.FindControl("StatusFlag1"), Label).Text = "Not Cleared"

                    ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                        CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                        CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                    ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                        CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                        CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                    End If
                Next
                btnUpdate.Visible = True
                GridView1.Visible = True
            Else
                msginfo.Text = "No records to display."
                lblmsg.Text = ""
                btnUpdate.Visible = False
            End If
            'End If
            btnUpdate.Visible = True
            msginfo.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            msginfo.Text = "Date is not valid."
        End Try
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtFromDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtToDate.Text = Format(Today.Date(), "dd-MMM-yyyy")
            txtStartDate.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            txtEndDate.Text = Format(CDate(Session("FinEndDate")), "dd-MMM-yyyy")
            btnUpdate.Visible = False
        End If
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        If Session("Privilages").ToString.Contains("W") Or Session("Privilages").ToString.Contains("R") Then

            Try
                'Dim B_sheet_qy As New BalanceSheet
                ' B_sheet_qy.BalanceSheetQueries()
                Dim BankId As Integer
                If ddlBank.SelectedItem.Text = "Select" Then
                    lblErrorMsg.Text = "Select a Bank to view Report."
                    msginfo.Text = ""
                    lblmsg.Text = ""
                Else
                    msginfo.Text = ""
                    lblmsg.Text = ""
                    lblErrorMsg.Text = ""
                    BankId = ddlBank.SelectedValue
                    Dim FromDate As Date
                    Dim ToDate As Date
                    If txtStartDate.Text = "" Then
                        FromDate = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
                    Else
                        FromDate = txtStartDate.Text
                        txtStartDate.Text = Format(FromDate, "dd-MMM-yyyy")
                    End If
                    If txtEndDate.Text = "" Then
                        ToDate = Format(CDate(Session("FinEndDate")), "dd-MMM-yyyy")
                    Else
                        ToDate = txtEndDate.Text
                        txtEndDate.Text = Format(ToDate, "dd-MMM-yyyy")
                    End If

                    Dim qrystring As String = "BankReconciliationV.aspx?" & QueryStr.Querystring() & "&FromDate=" & FromDate & "&ToDate=" & ToDate & "&BankId=" & BankId
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                End If
            Catch ex As Exception
                lblErrorMsg.Text = "Date is not valid."
            End Try
        Else
            lblErrorMsg.Text = "You do not have Read Privilage."
        End If
    End Sub

    Protected Sub ddlTable_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTable.SelectedIndexChanged
        lblmsg.Text = ""
        msginfo.Text = ""
        GridView1.Visible = False
        btnUpdate.Visible = False
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                lblErrorMsg.Text = ""
                Dim count As Integer

                count = 0
                If ddlTable.SelectedValue = 0 Then
                    el.table = "DB"
                    For Each rows As GridViewRow In GridView1.Rows
                        If CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False Then
                            el.StatusFlag = "Y"
                            el.ID = CType(rows.FindControl("HidID"), HiddenField).Value
                            If CType(rows.FindControl("txtEndDate"), TextBox).Text = "" Then
                                el.Clearing_Date = "1/1/9100"
                            Else
                                el.Clearing_Date = CType(rows.FindControl("txtEndDate"), TextBox).Text
                            End If
                            If CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True Then
                                el.StatusFlag = "B"
                            End If
                            If CType(rows.FindControl("txtChequeBounceDate"), TextBox).Text = "" Then
                                el.ChequeBounce_Date = "1/1/9100"
                            Else
                                el.ChequeBounce_Date = CType(rows.FindControl("txtChequeBounceDate"), TextBox).Text
                            End If
                            BRS.Update(el)
                        ElseIf CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True Then
                            el.StatusFlag = "N"
                            el.ID = CType(rows.FindControl("HidID"), HiddenField).Value
                            If CType(rows.FindControl("txtEndDate"), TextBox).Text = "" Then
                                el.Clearing_Date = "1/1/9100"
                            Else
                                el.Clearing_Date = CType(rows.FindControl("txtEndDate"), TextBox).Text
                            End If
                            If CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True Then
                                el.StatusFlag = "B"
                            End If
                            If CType(rows.FindControl("txtChequeBounceDate"), TextBox).Text = "" Then
                                el.ChequeBounce_Date = "1/1/9100"
                            Else
                                el.ChequeBounce_Date = CType(rows.FindControl("txtChequeBounceDate"), TextBox).Text
                            End If
                            BRS.Update(el)
                        End If
                    Next
                Else
                    el.table = "FC"
                    For Each rows As GridViewRow In GridView1.Rows
                        If CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False Then
                            el.StatusFlag = "Y"
                            el.ID = CType(rows.FindControl("HidID"), HiddenField).Value
                            If CType(rows.FindControl("txtEndDate"), TextBox).Text = "" Then
                                el.Clearing_Date = "1/1/9100"
                            Else
                                el.Clearing_Date = CType(rows.FindControl("txtEndDate"), TextBox).Text
                            End If
                            If CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True Then
                                el.StatusFlag = "B"
                            End If
                            If CType(rows.FindControl("txtChequeBounceDate"), TextBox).Text = "" Then
                                el.ChequeBounce_Date = "1/1/9100"
                            Else
                                el.ChequeBounce_Date = CType(rows.FindControl("txtChequeBounceDate"), TextBox).Text
                            End If
                            BRS.Update(el)
                        ElseIf CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True Then
                            el.StatusFlag = "N"
                            el.ID = CType(rows.FindControl("HidID"), HiddenField).Value
                            If CType(rows.FindControl("txtEndDate"), TextBox).Text = "" Then
                                el.Clearing_Date = "1/1/9100"
                            Else
                                el.Clearing_Date = CType(rows.FindControl("txtEndDate"), TextBox).Text
                            End If
                            If CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True Then
                                el.StatusFlag = "B"
                            End If
                            If CType(rows.FindControl("txtChequeBounceDate"), TextBox).Text = "" Then
                                el.ChequeBounce_Date = "1/1/9100"
                            Else
                                el.ChequeBounce_Date = CType(rows.FindControl("txtChequeBounceDate"), TextBox).Text
                            End If
                            BRS.Update(el)
                        End If
                    Next
                End If

                If ddlTable.SelectedValue = 0 Then
                    el.table = "DB"
                Else
                    el.table = "FC"
                End If
                el.StatusFlag = "A"
                el.FromDate = txtFromDate.Text
                el.ToDate = txtToDate.Text
                dt = BRS.GetBRS(el)
                GridView1.DataSource = dt
                GridView1.DataBind()
                If ddlTable.SelectedValue = 0 Then


                    If dt.Rows(0).Item("Amt_Out").ToString = "0.00" Then

                        If dt.Rows.Count > 0 Then

                            For Each rows As GridViewRow In GridView1.Rows
                                If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                                    'CType(rows.FindControl("StatusFlag1"), Label).Text = "Not Cleared"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                    CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                                End If
                            Next
                            btnUpdate.Visible = True
                            LinkButton.Focus()
                        Else
                            msginfo.Text = "No records to display."
                            lblmsg.Text = ""
                            btnUpdate.Visible = False
                        End If
                    Else
                        If dt.Rows.Count > 0 Then
                            For Each rows As GridViewRow In GridView1.Rows
                                If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                                    'CType(rows.FindControl("StatusFlag1"), Label).Text = "Not Presented"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                                    CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                                ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                    CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                    CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                                End If
                            Next
                            btnUpdate.Visible = True
                            LinkButton.Focus()
                        Else
                            msginfo.Text = "No records to display."
                            lblmsg.Text = ""
                            btnUpdate.Visible = False
                        End If
                    End If
            Else
                If dt.Rows.Count > 0 Then
                    For Each rows As GridViewRow In GridView1.Rows
                        If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                            CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                            'CType(rows.FindControl("Clear"), Label).Text = "Not Cleared"

                        ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                            CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"
                            ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"
                        End If
                    Next
                    btnUpdate.Visible = True
                    LinkButton.Focus()
                Else
                    msginfo.Text = "No records to display."
                    lblmsg.Text = ""
                    btnUpdate.Visible = False
                End If
            End If
                lblmsg.Text = "Data updated successfully."
                msginfo.Text = ""
            Else
                msginfo.Text = "You do not belong to this branch, cannot update data."
                lblmsg.Text = ""
            End If
        Catch ex As Exception
            msginfo.Text = "Date is not valid."
        End Try
    End Sub
   
    Protected Sub ddlTable_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlTable.TextChanged
        ddlTable.Focus()
    End Sub
    Sub CheckAll()

        If CType(GridView1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkStatus"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkStatus"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Sub CheckAll1()

        If CType(GridView1.HeaderRow.FindControl("ChkAll1"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkStatus1"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkStatus1"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub btncancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncancel.Click
        If Session("Privilages").ToString.Contains("W") Then

            Try
                If (Session("BranchCode") = Session("ParentBranch")) Then
                    lblErrorMsg.Text = ""
                    msginfo.Text = ""
                    lblmsg.Text = ""
                    If ddlTable.SelectedValue = 0 Then
                        el.table = "DB"
                    Else
                        el.table = "FC"
                    End If
                    el.StatusFlag = "CN"
                    el.FromDate = txtFromDate.Text
                    el.ToDate = txtToDate.Text
                    ViewState("Status") = el.StatusFlag
                    dt = BRS.GetBRS(el)
                    GridView1.DataSource = dt
                    GridView1.DataBind()
                    If dt.Rows.Count > 0 Then
                        For Each rows As GridViewRow In GridView1.Rows
                            If CType(rows.FindControl("StatusFlag"), Label).Text = "N" Then
                                CType(rows.FindControl("ChkStatus"), CheckBox).Checked = False
                                'CType(rows.FindControl("Clear"), Label).Text = "Not Cleared"

                            ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "Y" Then
                                CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                CType(rows.FindControl("StatusFlag1"), Label).Text = "Cleared"

                            ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "B" Then
                                CType(rows.FindControl("ChkStatus1"), CheckBox).Checked = True
                                CType(rows.FindControl("StatusFlag1"), Label).Text = "Bounced"

                            ElseIf CType(rows.FindControl("StatusFlag"), Label).Text = "CN" Then
                                CType(rows.FindControl("ChkStatus"), CheckBox).Checked = True
                                CType(rows.FindControl("StatusFlag1"), Label).Text = "Canceled"

                            End If
                        Next
                        btnUpdate.Visible = True
                        GridView1.Visible = True
                    Else
                        lblErrorMsg.Text = "No records to display."
                        lblmsg.Text = ""
                        btnUpdate.Visible = False
                    End If
                Else
                    msginfo.Text = "You do not belong to this branch, cannot clear data."
                    lblmsg.Text = ""
                End If
            Catch ex As Exception
                msginfo.Text = "Date is not valid."
            End Try
        Else
            lblErrorMsg.Text = "You do not have Write Privilage."
        End If
    End Sub
End Class
