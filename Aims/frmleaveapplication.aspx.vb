Imports System.Data.SqlClient

Partial Class frmleaveapplication
    Inherits BasePage
    Dim BL As New LeaveApplicationBL
    Dim EL As New LeaveApplicationEL
    Dim DL As New LeaveApplicationDL
    Dim dt, dt1, dt2, dt3, dt4, dt5 As DataTable
    'Anchala Verma 11-04-2012
    'Code for page load
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        Try
            If Not IsPostBack Then
                'RBReport.SelectedValue = 1
                'RBReport1.SelectedValue = 2
                If Session("LoginType") = "Employee" Then
                    If Session("EmpName") <> "" Then
                        Dim userid As String = Session("UserRole")
                        dt3 = LeaveApplicationDL.GetUserRole(userid)
                        Dim Str As String = dt3.Rows(0).Item("Column1").ToString
                        If Str.Contains("Leave Role") Then
                            TxtEmpCode.Visible = False
                            Label8.Visible = False
                            Label1.Visible = False
                            TxtEmpName.Visible = False
                            Label10.Visible = True
                            ddlEmpName.Visible = True
                            TxtApplicationDate.Text = Format(Today, "dd-MMM-yyyy")
                            TxtApplicationDate.Enabled = False
                            TxtNoofdaysappl.Enabled = False
                            TxtbalnceLeave.Enabled = False
                            txtDelegate.Enabled = False
                            Gvleaveapp.Columns(2).Visible = False

                        Else
                            TxtEmpCode.Visible = True
                            Label8.Visible = True
                            Label1.Visible = True
                            TxtEmpName.Visible = True
                            Label10.Visible = False
                            ddlEmpName.Visible = False
                            TxtApplicationDate.Text = Format(Today, "dd-MMM-yyyy")
                            TxtEmpName.Text = Session("EmpName")
                            TxtEmpCode.Text = Session("EmpCode")
                            HidEmpId.Value = Session("EmpID")
                            txtDelegate.Enabled = False
                            dt = BL.delegatename(HidEmpId.Value)
                            If dt.Rows.Count > 0 Then
                                txtDelegate.Text = dt.Rows(0).Item("Emp_Name").ToString
                            Else
                                txtDelegate.Text = ""
                            End If
                            txtleavefrom.Text = Format(Today, "dd-MMM-yyyy")
                            TxtApplicationDate.Enabled = False
                            TxtEmpCode.Enabled = False
                            TxtEmpName.Enabled = False
                            TxtNoofdaysappl.Enabled = False
                            TxtbalnceLeave.Enabled = False
                            Gvleaveapp.Columns(2).Visible = False
                            End If
                    Else
                            lblErrorMsg.Visible = True
                            lblErrorMsg.Text = "Not Accessible for Institute Admin."
                            msginfo.Text = ""
                            btnsave.Enabled = False

                    End If
                Else
                    TxtApplicationDate.Text = Format(Today, "dd-MMM-yyyy")
                    TxtEmpName.Text = Session("StudentName")
                    Label1.Text = "Student Name :&nbsp;&nbsp;"
                    TxtEmpCode.Text = Session("StudentCode")
                    Label8.Text = "Student Code :&nbsp;&nbsp;"
                    HidEmpId.Value = 0
                    txtleavefrom.Text = Format(Today, "dd-MMM-yyyy")
                    TxtApplicationDate.Enabled = False
                    Gvleaveapp.Columns(2).HeaderText = "Student Code"
                    Gvleaveapp.Columns(2).Visible = False
                    Gvleaveapp.Columns(3).HeaderText = "Student Name"
                    Gvleaveapp.Columns(4).Visible = False
                    Gvleaveapp.Columns(5).Visible = False
                    Gvleaveapp.Columns(10).Visible = False
                    Gvleaveapp.Columns(11).Visible = False
                    TxtEmpCode.Enabled = False
                    TxtEmpName.Enabled = False
                    TxtNoofdaysappl.Enabled = False
                    ddlleavetype.Visible = True
                    'Label13.Visible = False
                    TxtbalnceLeave.Visible = False
                    TxtbalnceLeave.Text = "0"
                    Label5.Visible = False
                    Label10.Visible = False
                    ddlEmpName.Visible = False
                    lblDelegate.Visible = False
                    txtDelegate.Visible = False

                End If
            End If

            If Session("RowID") <> "" Then
                Dim dt As New DataTable
                Lblheading.Text = "LEAVE APPLICATION"
                dt = BL.DispGrid(CInt(Session("RowID")))
                ddlleavetype.SelectedValue = dt.Rows(0).Item("LeaveTypes")
                ddlleavetype.Enabled = False
                txtleavefrom.Text = Format(dt.Rows(0).Item("LeaveFrom"), "dd-MMM-yyyy")
                txtleavefrom.Enabled = False
                txtleaveto.Text = Format(dt.Rows(0).Item("LeaveTo"), "dd-MMM-yyyy")
                txtleaveto.Enabled = False
                Txtreason.Text = dt.Rows(0).Item("Remarks")
                Txtreason.Enabled = False
                txtRemarks.Text = dt.Rows(0).Item("Feedback")
                txtRemarks.Enabled = False
                Dim EmpId As Integer = dt.Rows(0).Item("EmpID")
                TxtEmpName.Text = dt.Rows(0).Item("Emp_Name")
                TxtEmpName.Enabled = False
                TxtEmpCode.Text = dt.Rows(0).Item("Emp_Code")
                TxtEmpCode.Enabled = False
                HidEmpId.Value = EmpId
                dt1 = BL.balanceleave(dt.Rows(0).Item("LeaveTypes"), CInt(EmpId))
                btnDetail.Visible = False
                btnsave.Visible = False
                lblDelegate.Visible = False
                txtDelegate.Visible = False
                'Try
                TxtbalnceLeave.Text = dt1.Rows(0).Item("BalanceLeave").ToString
                TxtNoofdaysappl.Text = dt1.Rows(0).Item("TakenLeaves").ToString
                'TxtNoofdaysappl.Text = Convert.ToInt32(DateDiff(DateInterval.Day, CDate(dt.Rows(0).Item("LeaveFrom")), CDate(dt.Rows(0).Item("LeaveTo")))) + 1
                'Catch ex As Exception
                'End Try
                Session("RowID") = ""
                'Else
                '    btnDetail.Visible = True
                '    btnsave.Visible = True
            End If
            ddlleavetype.Focus()
        Catch ex As Exception
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Not Accessible for Institute Admin."
            msginfo.Text = ""
            btnsave.Enabled = False
        End Try
    End Sub
    'Anchala Verma 10-04-2012
    'Code for inserting data
    'Modified By : Venkatesh Pasupuleti
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        ddlleavetype.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If Session("LoginType") = "Employee" Then
                    Dim userid As String = Session("UserRole")
                    dt3 = LeaveApplicationDL.GetUserRole(userid)
                    Dim Str As String = dt3.Rows(0).Item("Column1").ToString
                    If Str.Contains("Leave Role") Then
                        If ddlEmpName.SelectedValue = 0 Then
                            lblErrorMsg.Text = "Employee Name Field is Mandatory."
                            msginfo.Text = ""
                            ddlEmpName.focus()
                            Exit Sub
                        End If

                        EL.empid = ddlEmpName.SelectedValue
                        EL.leavetype = ddlleavetype.SelectedValue
                        Dim parts As String() = ddlEmpName.SelectedItem.Text.Split(New Char() {":"})
                        TxtEmpName.Text = parts(0).ToString()
                        TxtEmpCode.Text = parts(1).ToString()
                        EL.Emp_Code = TxtEmpCode.Text
                    Else
                        TxtEmpName.Text = Session("EmpName")
                        TxtEmpCode.Text = Session("EmpCode")
                        HidEmpId.Value = Session("EmpID")
                        EL.empid = HidEmpId.Value
                        EL.leavetype = ddlleavetype.SelectedValue
                    End If
                Else
                    EL.leavetype = ddlleavetype.SelectedValue
                    TxtApplicationDate.Text = Format(Today, "dd-MMM-yyyy")
                    TxtEmpName.Text = Session("StudentName")
                    Label1.Text = "Student Name :&nbsp;&nbsp;"
                    TxtEmpCode.Text = Session("StudentCode")
                    Label8.Text = "Student Code :&nbsp;&nbsp;"
                    EL.empid = 0
                    HidEmpId.Value = 0

                End If

                    EL.Leavefrom = txtleavefrom.Text
                    EL.Leaveto = txtleaveto.Text
                EL.FeedBack = txtRemarks.Text
                EL.Emp_Code = TxtEmpCode.Text
                If Session("LoginType") = "Employee" Then
                        If CType(txtleavefrom.Text, Date) > CType(txtleaveto.Text, Date) Then
                            msginfo.Text = ""
                            lblErrorMsg.Text = "'Leave From' date should be lesser than 'Leave To' date."
                            txtleavefrom.Focus()
                            Exit Sub
                        End If
                        If CInt(TxtNoofdaysappl.Text) > CInt(TxtbalnceLeave.Text) Then
                            msginfo.Text = ""
                            lblErrorMsg.Text = "You Don't have sufficient leaves to apply!!!"
                            ddlleavetype.Focus()
                            Exit Sub
                        End If
                End If

                    EL.reason = Txtreason.Text
                    EL.nofdays = TxtNoofdaysappl.Text
                If Session("LoginType") = "Employee" Then
                    Dim userid As String = Session("UserRole")
                    dt3 = LeaveApplicationDL.GetUserRole(userid)
                    Dim Str As String = dt3.Rows(0).Item("Column1").ToString
                    If Str.Contains("Leave Role") Then
                        If EL.empid <> Session("EmpID") Then
                            Dim parts As String() = ddlEmpName.SelectedItem.Text.Split(New Char() {":"})
                            TxtEmpName.Text = parts(0).ToString()
                            TxtEmpCode.Text = parts(1).ToString()
                            EL.Emp_Code = TxtEmpCode.Text

                            dt = LeaveApplicationDL.CheckDuplicateforOtherEmployee(EL)
                            If dt.Rows.Count > 0 Then
                                lblErrorMsg.Text = "Data already Exists."
                                msginfo.Text = ""
                            Else

                                EL.empid = ddlEmpName.SelectedValue

                                BL.InsertRecordforOtherEmployee(EL)
                                generatemsg(EL)
                                dt = BL.balanceleave(ddlleavetype.SelectedValue, ddlEmpName.SelectedValue)
                                Try
                                    TxtbalnceLeave.Text = dt.Rows(0).Item("BalanceLeave").ToString
                                Catch ex As Exception
                                End Try
                                msginfo.Text = "Data saved successfully."
                                lblErrorMsg.Text = ""
                                txtleavefrom.Text = ""
                                txtleaveto.Text = ""
                                TxtNoofdaysappl.Text = ""
                                Txtreason.Text = ""
                                txtRemarks.Text = ""
                                TxtNoofdaysappl.Enabled = False
                                dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
                                Gvleaveapp.DataSource = dt
                                Gvleaveapp.DataBind()
                                Gvleaveapp.Enabled = True
                            End If

                        Else

                            dt = LeaveApplicationDL.CheckDuplicate(EL)
                            If dt.Rows.Count > 0 Then
                                lblErrorMsg.Text = "Data already Exists."
                                msginfo.Text = ""
                            Else
                                BL.InsertRecord(EL)
                                generatemsg(EL)
                                dt = BL.balanceleave(ddlleavetype.SelectedValue, ddlEmpName.SelectedValue)
                                Try
                                    TxtbalnceLeave.Text = dt.Rows(0).Item("BalanceLeave").ToString
                                Catch ex As Exception
                                End Try
                                msginfo.Text = "Data saved successfully."
                                lblErrorMsg.Text = ""
                                txtleavefrom.Text = ""
                                txtleaveto.Text = ""
                                TxtNoofdaysappl.Text = ""
                                Txtreason.Text = ""
                                txtRemarks.Text = ""
                                TxtNoofdaysappl.Enabled = False
                                dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
                                Gvleaveapp.DataSource = dt
                                Gvleaveapp.DataBind()
                                Gvleaveapp.Enabled = True
                            End If
                        End If
                    Else
                        dt = LeaveApplicationDL.CheckDuplicate(EL)
                        If dt.Rows.Count > 0 Then
                            lblErrorMsg.Text = "Data already Exists."
                            msginfo.Text = ""
                        Else
                            generatemsg(EL)
                            BL.InsertRecord(EL)
                            dt = BL.balanceleave(ddlleavetype.SelectedValue, HidEmpId.Value)
                            Try
                                TxtbalnceLeave.Text = dt.Rows(0).Item("BalanceLeave").ToString
                            Catch ex As Exception
                            End Try
                            msginfo.Text = "Data saved successfully."
                            lblErrorMsg.Text = ""
                            txtleavefrom.Text = ""
                            txtleaveto.Text = ""
                            TxtNoofdaysappl.Text = ""
                            Txtreason.Text = ""
                            txtRemarks.Text = ""
                            TxtNoofdaysappl.Enabled = False

                            dt = BL.DispGrid(0)
                            Gvleaveapp.DataSource = dt
                            Gvleaveapp.DataBind()
                            Gvleaveapp.Enabled = True
                        End If
                    End If
                Else

                    EL.Emp_Code = TxtEmpCode.Text
                    dt = LeaveApplicationDL.CheckDuplicateforStudent(EL)
                    If dt.Rows.Count > 0 Then
                        lblErrorMsg.Text = "Data already Exists."
                        msginfo.Text = ""
                    Else
                        BL.InsertRecord(EL)
                        'dt = BL.balanceleave(ddlleavetype.SelectedValue, HidEmpId.Value)
                        'Try
                        '    TxtbalnceLeave.Text = dt.Rows(0).Item("BalanceLeave").ToString
                        'Catch ex As Exception
                        'End Try
                        msginfo.Text = "Data saved successfully."
                        lblErrorMsg.Text = ""
                        txtleavefrom.Text = ""
                        txtleaveto.Text = ""
                        TxtNoofdaysappl.Text = ""
                        Txtreason.Text = ""
                        txtRemarks.Text = ""
                        TxtNoofdaysappl.Enabled = False

                        Dim userid1 As String = Session("UserRole")
                        dt3 = LeaveApplicationDL.GetUserRole(userid1)
                        Dim Str1 As String = dt3.Rows(0).Item("Column1").ToString
                        If Str1.Contains("Leave Role") Then
                            dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)

                            Gvleaveapp.DataSource = dt
                            Gvleaveapp.DataBind()
                            Gvleaveapp.Enabled = True
                        Else

                            dt = BL.DispGrid(0)
                            Gvleaveapp.DataSource = dt
                            Gvleaveapp.DataBind()
                            Gvleaveapp.Enabled = True
                        End If
                    End If
                End If
            Catch ex As Exception
                lblErrorMsg.Text = "You are not allocated with this Leave Type."
                ddlleavetype.Focus()
            End Try
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
            msginfo.Text = ""
        End If
    End Sub
    'Anchala Verma 10-04-2012
    'Code for view data
    Protected Sub btnDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        LinkButton1.Focus()
        Try
            Dim userid As String = Session("UserRole")
            dt3 = LeaveApplicationDL.GetUserRole(userid)
            Dim Str As String = dt3.Rows(0).Item("Column1").ToString
            If Str.Contains("Leave Role") Then
                dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
                If dt.Rows.Count > 0 Then
                    Gvleaveapp.DataSource = dt
                    Gvleaveapp.DataBind()
                    Gvleaveapp.Enabled = True
                    msginfo.Text = ""
                    lblErrorMsg.Text = ""
                    Gvleaveapp.Visible = True
                Else
                    lblErrorMsg.Text = "No records to display."
                    msginfo.Text = ""
                    Gvleaveapp.Visible = False
                End If
            Else

                dt = BL.DispGrid(0)
                If dt.Rows.Count > 0 Then
                    Gvleaveapp.DataSource = dt
                    Gvleaveapp.DataBind()
                    Gvleaveapp.Enabled = True
                    msginfo.Text = ""
                    lblErrorMsg.Text = ""
                    Gvleaveapp.Visible = True
                Else
                    lblErrorMsg.Text = "No records to display."
                    msginfo.Text = ""
                    Gvleaveapp.Visible = False
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    ' Implemented by : Venkatesh Pasupuleti, 21-01-2015
    ' Description    : Code for Cancelling the applied leaves

    Protected Sub Gvleaveapp_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles Gvleaveapp.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If Session("LoginType") = "Employee" Then
                lblErrorMsg.Text = ""
                msginfo.Text = ""
                EL.Id = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("lblid"), Label).Text
                EL.ApproveStatus = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("lblAppStatus"), Label).Text
                EL.nofdays = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label7"), Label).Text
                EL.empid = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("lblEmpid"), Label).Text
                EL.leavetype = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label5"), Label).Text
                EL.Emp_Code = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("lblEmpcode"), Label).Text
                EL.UserCode = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("lblUsercode"), Label).Text
                EL.ApplicantRemarks = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label10"), Label).Text

                If (((EL.ApplicantRemarks = "Applied for leaves cancellation") And (EL.ApproveStatus = "Approved")) Or (EL.ApproveStatus = "Cancelled")) Then
                    lblErrorMsg.Text = "Leaves are already cancelled."
                    msginfo.Text = ""
                    Dim userid As String = Session("UserRole")
                    dt3 = LeaveApplicationDL.GetUserRole(userid)
                    Dim Str As String = dt3.Rows(0).Item("Column1").ToString
                    If Str.Contains("Leave Role") Then
                        Gvleaveapp.PageIndex = ViewState("PageIndex")
                        dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
                        If dt.Rows.Count > 0 Then
                            Gvleaveapp.DataSource = dt
                            Gvleaveapp.DataBind()
                            Gvleaveapp.Enabled = True
                            Gvleaveapp.Visible = True
                        Else
                            lblErrorMsg.Text = "No records to display."
                            msginfo.Text = ""
                            Gvleaveapp.Visible = False
                        End If
                    Else
                        dt2 = BL.balanceleave(ddlleavetype.SelectedValue, HidEmpId.Value)
                        TxtbalnceLeave.Text = dt2.Rows(0).Item("BalanceLeave").ToString

                        Gvleaveapp.PageIndex = ViewState("PageIndex")
                        dt = BL.DispGrid(0)
                        If dt.Rows.Count > 0 Then
                            Gvleaveapp.DataSource = dt
                            Gvleaveapp.DataBind()
                            Gvleaveapp.Enabled = True
                            Gvleaveapp.Visible = True
                        Else
                            lblErrorMsg.Text = "No records to display."
                            msginfo.Text = ""
                            Gvleaveapp.Visible = False
                        End If
                    End If
                ElseIf (((EL.ApplicantRemarks = "Applied for leaves cancellation") And (EL.ApproveStatus = "Rejected")) Or (EL.ApproveStatus = "Rejected")) Then
                    lblErrorMsg.Text = "This leave record was  already rejected by Approver, You cannot cancel it."
                    msginfo.Text = ""
                    Dim userid As String = Session("UserRole")
                    dt3 = LeaveApplicationDL.GetUserRole(userid)
                    Dim Str As String = dt3.Rows(0).Item("Column1").ToString
                    If Str.Contains("Leave Role") Then
                        Gvleaveapp.PageIndex = ViewState("PageIndex")
                        dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
                        If dt.Rows.Count > 0 Then
                            Gvleaveapp.DataSource = dt
                            Gvleaveapp.DataBind()
                            Gvleaveapp.Enabled = True
                            Gvleaveapp.Visible = True
                        Else
                            lblErrorMsg.Text = "No records to display."
                            msginfo.Text = ""
                            Gvleaveapp.Visible = False
                        End If
                    Else
                        Gvleaveapp.PageIndex = ViewState("PageIndex")
                        dt = BL.DispGrid(0)
                        If dt.Rows.Count > 0 Then
                            Gvleaveapp.DataSource = dt
                            Gvleaveapp.DataBind()
                            Gvleaveapp.Enabled = True
                            Gvleaveapp.Visible = True
                        Else
                            lblErrorMsg.Text = "No records to display."
                            msginfo.Text = ""
                            Gvleaveapp.Visible = False
                        End If
                    End If
                ElseIf EL.ApproveStatus = "Sent for approval" Then
                    LeaveApplicationDL.ChangeFlag(EL)
                    lblErrorMsg.Text = ""
                    msginfo.Text = ""
                    Dim userid As String = Session("UserRole")
                    dt3 = LeaveApplicationDL.GetUserRole(userid)
                    Dim Str As String = dt3.Rows(0).Item("Column1").ToString
                    If Str.Contains("Leave Role") Then
                        ddlleavetype.SelectedValue = EL.leavetype
                        ddlEmpName.SelectedValue = EL.empid
                        dt2 = BL.balanceleave(ddlleavetype.SelectedValue, ddlEmpName.SelectedValue)
                        TxtbalnceLeave.Text = dt2.Rows(0).Item("BalanceLeave").ToString

                        Gvleaveapp.PageIndex = ViewState("PageIndex")
                        dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
                        If dt.Rows.Count > 0 Then
                            Gvleaveapp.DataSource = dt
                            Gvleaveapp.DataBind()
                            Gvleaveapp.Enabled = True
                            msginfo.Text = "Leaves cancelled Successfully."
                            lblErrorMsg.Text = ""
                            Gvleaveapp.Visible = True
                        Else
                            lblErrorMsg.Text = "No records to display."
                            msginfo.Text = ""
                            Gvleaveapp.Visible = False
                        End If
                    Else
                        ddlleavetype.SelectedValue = EL.leavetype
                        Dim GEmpId = Session("EmpID")
                        dt2 = BL.balanceleave(ddlleavetype.SelectedValue, GEmpId)
                        TxtbalnceLeave.Text = dt2.Rows(0).Item("BalanceLeave").ToString

                        Gvleaveapp.PageIndex = ViewState("PageIndex")
                        dt = BL.DispGrid(0)
                        If dt.Rows.Count > 0 Then
                            Gvleaveapp.DataSource = dt
                            Gvleaveapp.DataBind()
                            Gvleaveapp.Enabled = True
                            msginfo.Text = "Leaves cancelled Successfully."
                            lblErrorMsg.Text = ""
                            Gvleaveapp.Visible = True
                        Else
                            lblErrorMsg.Text = "No records to display."
                            msginfo.Text = ""
                            Gvleaveapp.Visible = False
                        End If
                    End If
                    Dim vm As String
                    Dim Dmail As String

                    Dim parm_msg, parm_phonesp, parm_msgfrm, parm_date As SqlParameter
                    'Dim userid As String = Session("UserRole")
                    dt3 = LeaveApplicationDL.GetUserRole(userid)
                    Dim Str1 As String = dt3.Rows(0).Item("Column1").ToString
                    If Str1.Contains("Leave Role") Then
                        dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
                    Else
                        dt = BL.DispGrid(0)
                    End If

                    TxtEmpName.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label3"), Label).Text
                    TxtApplicationDate.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label1"), Label).Text
                    txtleavefrom.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label4"), Label).Text
                    txtleaveto.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label6"), Label).Text
                    ddlleavetype.SelectedItem.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label9"), Label).Text
                    TxtEmpCode.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label2"), Label).Text
                    TxtNoofdaysappl.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label7"), Label).Text
                    Txtreason.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label8"), Label).Text
                    txtRemarks.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label10"), Label).Text
                    txtDelegate.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("lblDelegate"), Label).Text
                    Dmail = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("lblDelEmail"), Label).Text

                    EL.empid = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("lblEmpid"), Label).Text
                    dt1 = BL.emailforCancel(el)
                    dt2 = BL.HRemailforCancel(el)
                    Try
                        Dim ToPhone As String
                        Dim Appdate As String
                        Dim FromDate As String
                        Dim ToDate As String
                        Dim EmpCode As String
                        Dim Prefix As String
                        Dim NoOfDays As String
                        Dim Reason As String
                        Dim LeaveType As String
                        Dim Message As String
                        'Dim BalanceLeave As Double
                        Dim AppRemarks As String
                        Dim DelegateName As String

                        Dim Mode As String = "Email"
                        If Session("EmailService") = "Y" Then
                            If dt.Rows.Count > 0 Then
                                If dt2.Rows.Count > 0 And Dmail <> "" Then
                                    ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt2.Rows(0).Item("HREmail")) + "," + Dmail
                                ElseIf dt2.Rows.Count > 0 And Dmail = "" Then
                                    ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt2.Rows(0).Item("HREmail"))
                                ElseIf (Dmail <> "") And (dt2.Rows.Count = 0) Then
                                    ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Dmail
                                Else
                                    ToPhone = Trim(dt1.Rows(0).Item("Email"))
                                End If
                                Prefix = TxtEmpName.Text
                                Appdate = TxtApplicationDate.Text
                                FromDate = txtleavefrom.Text
                                ToDate = txtleaveto.Text
                                LeaveType = ddlleavetype.SelectedItem.Text
                                EmpCode = TxtEmpCode.Text
                                NoOfDays = TxtNoofdaysappl.Text
                                Reason = Txtreason.Text
                                'BalanceLeave = (TxtbalnceLeave.Text - TxtNoofdaysappl.Text)
                                AppRemarks = txtRemarks.Text
                                DelegateName = txtDelegate.Text
                                Message = "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Code : " + EmpCode + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Name : " + Prefix + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave Type : " + LeaveType + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave From : " + FromDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave To : " + ToDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;No of days Applied : " + NoOfDays + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;has withdrawn leave(s)" + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Delegate Name :" + DelegateName

                                'Message = "I," + Prefix + ", " + Reason + ". I kindly request you to grant me " + NoOfDays + " day(s) leave from " & FromDate & " to " & ToDate & ". Kindly Oblige." Applying for :Cancellation

                                'Dim str As String = ""
                                Dim connection As New SqlClient.SqlConnection()
                                connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
                                connection.Open()
                                Dim cmd As New SqlCommand()
                                vm = "insert into Outbox_tbl (ToPhone,Message,prefix,BranchCode,CommunicationMode) values(@ToPhone,@Message,@Prefix,@BranchCode,@Mode)"

                                cmd.Connection = connection
                                cmd.CommandText = vm
                                parm_phonesp = New SqlParameter
                                parm_phonesp.ParameterName = "@ToPhone"
                                parm_phonesp.Value = ToPhone
                                parm_phonesp.DbType = DbType.String
                                cmd.Parameters.Add(parm_phonesp)

                                parm_msg = New SqlParameter
                                parm_msg.ParameterName = "@Message"
                                parm_msg.Value = Message
                                parm_msg.DbType = DbType.String
                                cmd.Parameters.Add(parm_msg)

                                parm_msgfrm = New SqlParameter
                                parm_msgfrm.ParameterName = "@Prefix"
                                parm_msgfrm.Value = Prefix
                                parm_msgfrm.DbType = DbType.String
                                cmd.Parameters.Add(parm_msgfrm)

                                parm_date = New SqlParameter
                                parm_date.ParameterName = "@SentDate"
                                parm_date.Value = CDate(Appdate)
                                parm_date.DbType = DbType.Date
                                cmd.Parameters.Add(parm_date)

                                parm_msgfrm = New SqlParameter
                                parm_msgfrm.ParameterName = "@BranchCode"
                                parm_msgfrm.Value = Session("BranchCode")
                                parm_msgfrm.DbType = DbType.String
                                cmd.Parameters.Add(parm_msgfrm)

                                parm_msgfrm = New SqlParameter
                                parm_msgfrm.ParameterName = "@Mode"
                                parm_msgfrm.Value = Mode
                                parm_msgfrm.DbType = DbType.String
                                cmd.Parameters.Add(parm_msgfrm)

                                cmd.ExecuteNonQuery()
                            End If
                            Else
                            End If
                    Catch ex As Exception
                    End Try

                ElseIf EL.ApproveStatus = "Approved" Then
                    LeaveApplicationDL.ApprovalRequest(EL)
                    lblErrorMsg.Text = ""
                    msginfo.Text = ""
                    Dim userid As String = Session("UserRole")
                    dt3 = LeaveApplicationDL.GetUserRole(userid)
                    Dim Str As String = dt3.Rows(0).Item("Column1").ToString
                    If Str.Contains("Leave Role") Then
                        Gvleaveapp.PageIndex = ViewState("PageIndex")
                        dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
                        If dt.Rows.Count > 0 Then
                            Gvleaveapp.DataSource = dt
                            Gvleaveapp.DataBind()
                            Gvleaveapp.Enabled = True
                            msginfo.Text = "Applied Successfully for cancelling leaves."
                            lblErrorMsg.Text = ""
                            Gvleaveapp.Visible = True
                        Else
                            lblErrorMsg.Text = "No records to display."
                            msginfo.Text = ""
                            Gvleaveapp.Visible = False
                        End If
                    Else
                        Gvleaveapp.PageIndex = ViewState("PageIndex")
                        dt = BL.DispGrid(0)
                        If dt.Rows.Count > 0 Then
                            Gvleaveapp.DataSource = dt
                            Gvleaveapp.DataBind()
                            Gvleaveapp.Enabled = True
                            msginfo.Text = "Applied Successfully for cancelling leaves."
                            lblErrorMsg.Text = ""
                            Gvleaveapp.Visible = True
                        Else
                            lblErrorMsg.Text = "No records to display."
                            msginfo.Text = ""
                            Gvleaveapp.Visible = False
                        End If
                    End If
                    Dim vm As String
                    Dim Dmail As String
                    Dim parm_msg, parm_phonesp, parm_msgfrm, parm_date As SqlParameter
                    'Dim userid As String = Session("UserRole")
                    dt3 = LeaveApplicationDL.GetUserRole(userid)
                    Dim Str1 As String = dt3.Rows(0).Item("Column1").ToString
                    If Str1.Contains("Leave Role") Then
                        dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
                    Else
                        dt = BL.DispGrid(0)
                    End If
                    TxtEmpName.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label3"), Label).Text
                    TxtApplicationDate.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label1"), Label).Text
                    txtleavefrom.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label4"), Label).Text
                    txtleaveto.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label6"), Label).Text
                    ddlleavetype.SelectedItem.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label9"), Label).Text
                    TxtEmpCode.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label2"), Label).Text
                    TxtNoofdaysappl.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label7"), Label).Text
                    Txtreason.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label8"), Label).Text
                    txtRemarks.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("Label10"), Label).Text
                    txtDelegate.Text = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("lblDelegate"), Label).Text
                    Dmail = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("lblDelEmail"), Label).Text

                    EL.empid = CType(Gvleaveapp.Rows(e.RowIndex).FindControl("lblEmpid"), Label).Text
                    dt1 = BL.emailforCancel(el)
                    dt2 = BL.HRemailforCancel(el)
                    Try
                        Dim ToPhone As String
                        Dim Appdate As String
                        Dim FromDate As String
                        Dim ToDate As String
                        Dim EmpCode As String
                        Dim Prefix As String
                        Dim NoOfDays As String
                        Dim Reason As String
                        Dim LeaveType As String
                        Dim Message As String
                        'Dim BalanceLeave As Double
                        Dim AppRemarks As String
                        Dim DelegateName As String
                        Dim Mode As String = "Email"
                        If Session("EmailService") = "Y" Then
                            If dt.Rows.Count > 0 Then
                                If dt2.Rows.Count > 0 And Dmail <> "" Then
                                    ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt2.Rows(0).Item("HREmail")) + "," + Dmail
                                ElseIf dt2.Rows.Count > 0 And Dmail = "" Then
                                    ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt2.Rows(0).Item("HREmail"))
                                ElseIf (Dmail <> "") And (dt2.Rows.Count = 0) Then
                                    ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Dmail
                                Else
                                    ToPhone = Trim(dt1.Rows(0).Item("Email"))
                                End If
                                Prefix = TxtEmpName.Text
                                Appdate = TxtApplicationDate.Text
                                FromDate = txtleavefrom.Text
                                ToDate = txtleaveto.Text
                                LeaveType = ddlleavetype.SelectedItem.Text
                                EmpCode = TxtEmpCode.Text
                                NoOfDays = TxtNoofdaysappl.Text
                                Reason = Txtreason.Text
                                'BalanceLeave = (TxtbalnceLeave.Text - TxtNoofdaysappl.Text)
                                AppRemarks = txtRemarks.Text
                                DelegateName = txtDelegate.Text
                                Message = "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Code : " + EmpCode + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Name : " + Prefix + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave Type : " + LeaveType + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave From : " + FromDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave To : " + ToDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;No of days: " + NoOfDays + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;has Applied for Leaves " + AppRemarks + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Delegate Name :" + DelegateName
                                'Message = "I," + Prefix + ", " + Reason + ". I kindly request you to grant me " + NoOfDays + " day(s) leave from " & FromDate & " to " & ToDate & ". Kindly Oblige." Applying for :Cancellation

                                'Dim str As String = ""
                                Dim connection As New SqlClient.SqlConnection()
                                connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
                                connection.Open()
                                Dim cmd As New SqlCommand()
                                vm = "insert into Outbox_tbl (ToPhone,Message,prefix,BranchCode,CommunicationMode) values(@ToPhone,@Message,@Prefix,@BranchCode,@Mode)"

                                cmd.Connection = connection
                                cmd.CommandText = vm
                                parm_phonesp = New SqlParameter
                                parm_phonesp.ParameterName = "@ToPhone"
                                parm_phonesp.Value = ToPhone
                                parm_phonesp.DbType = DbType.String
                                cmd.Parameters.Add(parm_phonesp)

                                parm_msg = New SqlParameter
                                parm_msg.ParameterName = "@Message"
                                parm_msg.Value = Message
                                parm_msg.DbType = DbType.String
                                cmd.Parameters.Add(parm_msg)

                                parm_msgfrm = New SqlParameter
                                parm_msgfrm.ParameterName = "@Prefix"
                                parm_msgfrm.Value = Prefix
                                parm_msgfrm.DbType = DbType.String
                                cmd.Parameters.Add(parm_msgfrm)

                                parm_date = New SqlParameter
                                parm_date.ParameterName = "@SentDate"
                                parm_date.Value = CDate(Appdate)
                                parm_date.DbType = DbType.Date
                                cmd.Parameters.Add(parm_date)

                                parm_msgfrm = New SqlParameter
                                parm_msgfrm.ParameterName = "@BranchCode"
                                parm_msgfrm.Value = Session("BranchCode")
                                parm_msgfrm.DbType = DbType.String
                                cmd.Parameters.Add(parm_msgfrm)

                                parm_msgfrm = New SqlParameter
                                parm_msgfrm.ParameterName = "@Mode"
                                parm_msgfrm.Value = Mode
                                parm_msgfrm.DbType = DbType.String
                                cmd.Parameters.Add(parm_msgfrm)

                                cmd.ExecuteNonQuery()
                            End If
                        Else
                        End If
                    Catch ex As Exception
                    End Try
                End If
            Else
                lblErrorMsg.Text = ""
                msginfo.Text = ""
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot Cancel the leaves."
            msginfo.Text = ""
        End If
    End Sub
    Protected Sub Gvleaveapp_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Gvleaveapp.PageIndexChanging
        Gvleaveapp.PageIndex = e.NewPageIndex
        Dim dt As New DataTable
        Dim userid As String = Session("UserRole")
        dt3 = LeaveApplicationDL.GetUserRole(userid)
        Dim Str As String = dt3.Rows(0).Item("Column1").ToString
        If Str.Contains("Leave Role") Then
            dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
            Gvleaveapp.DataSource = dt
            Gvleaveapp.DataBind()
            Gvleaveapp.Enabled = True
        Else
            dt = BL.DispGrid(0)
            Gvleaveapp.DataSource = dt
            Gvleaveapp.Visible = True
            Gvleaveapp.DataBind()

        End If

    End Sub
    Protected Sub ddlleavetype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlleavetype.SelectedIndexChanged
        TxtbalnceLeave.Text = "0"
        Try
            Dim userid As String = Session("UserRole")
            dt3 = LeaveApplicationDL.GetUserRole(userid)
            Dim Str As String = dt3.Rows(0).Item("Column1").ToString
            If Str.Contains("Leave Role") Then
                dt = BL.balanceleave(ddlleavetype.SelectedValue, ddlEmpName.SelectedValue)
                TxtbalnceLeave.Text = dt.Rows(0).Item("BalanceLeave").ToString
            Else

                dt = BL.balanceleave(ddlleavetype.SelectedValue, HidEmpId.Value)
                TxtbalnceLeave.Text = dt.Rows(0).Item("BalanceLeave").ToString

            End If
         
        Catch ex As Exception
        End Try
    End Sub
    'Anchala Verma 10-04-2012
    'Code for Autofill 
    Protected Sub txtleaveto_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtleaveto.TextChanged
        Dim Noofdays As Double
        Try
            If CDate(txtleavefrom.Text) = CDate(txtleaveto.Text) Then
                If RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 2 Then
                    Noofdays = 1
                ElseIf (RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 1) Or (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 2) Then
                    Noofdays = 0.5
                ElseIf (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 1) Then
                    lblErrorMsg.Text = "Wrong Selection."
                    msginfo.Text = ""
                End If

            Else
                Noofdays = Convert.ToInt32(DateDiff(DateInterval.Day, CDate(Me.txtleavefrom.Text), CDate(Me.txtleaveto.Text)))
                Noofdays = Noofdays + 1
                If (RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 1) Or (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 2) Then
                    Noofdays = Noofdays - 0.5
                ElseIf (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 1) Then
                    Noofdays = Noofdays - 1
                End If

            End If
            Dim dt1 As New DataTable
            EL.Leavefrom = txtleavefrom.Text
            EL.Leaveto = txtleaveto.Text
            dt1 = LeaveApplicationDL.getHolidayCount(EL)
            Dim HolidayCnt As Integer
            If dt1.Rows.Count > 0 Then
                HolidayCnt = dt1.Rows(0).Item("TotCnt")
            End If
            TxtNoofdaysappl.Text = Noofdays - HolidayCnt
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct date."
            msginfo.Text = ""
        End Try
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Sub generatemsg(ByVal el As LeaveApplicationEL)
        Dim vm As String
        Dim parm_msg, parm_phonesp, parm_msgfrm, parm_date As SqlParameter
        Dim userid As String = Session("UserRole")
        dt3 = LeaveApplicationDL.GetUserRole(userid)
        Dim Str1 As String = dt3.Rows(0).Item("Column1").ToString
        If Str1.Contains("Leave Role") Then
            dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
        Else
            dt = BL.DispGrid(0)
        End If
        Dim userid2 As String = Session("UserRole")
        dt3 = LeaveApplicationDL.GetUserRole(userid2)
        Dim Str2 As String = dt3.Rows(0).Item("Column1").ToString
        If Str2.Contains("Leave Role") Then
            el.empid = ddlEmpName.SelectedValue
            dt5 = BL.delegatename(el.empid)
            If dt5.Rows.Count > 0 Then
                txtDelegate.Text = dt5.Rows(0).Item("Emp_Name").ToString
            Else
                txtDelegate.Text = ""
            End If

        Else
            HidEmpId.Value = Session("EmpID")
            el.empid = HidEmpId.Value
            dt5 = BL.delegatename(el.empid)
            If dt5.Rows.Count > 0 Then
                txtDelegate.Text = dt5.Rows(0).Item("Emp_Name").ToString
            Else
                txtDelegate.Text = ""
            End If

        End If
        dt1 = BL.email(el)
        dt2 = BL.HRemail(el)
        dt4 = BL.DelegateMail(el)
        Try
            Dim ToPhone As String
            Dim Appdate As String
            Dim FromDate As String
            Dim ToDate As String
            Dim EmpCode As String
            Dim Prefix As String
            Dim NoOfDays As String
            Dim Reason As String
            Dim LeaveType As String
            Dim Message As String
            Dim BalanceLeave As String
            Dim DelegateName As String
            Dim Mode As String = "Email"
            If Session("EmailService") = "Y" Then
                If dt.Rows.Count > 0 Then
                    If (dt2.Rows.Count > 0) And (dt4.Rows.Count > 0) Then
                        ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt2.Rows(0).Item("HREmail")) + "," + Trim(dt4.Rows(0).Item("DelegateEmail"))

                    ElseIf (dt2.Rows.Count > 0) And (dt4.Rows.Count = 0) Then
                        ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt2.Rows(0).Item("HREmail"))

                    ElseIf (dt4.Rows.Count > 0) And (dt2.Rows.Count = 0) Then
                        ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt4.Rows(0).Item("DelegateEmail"))

                    Else
                        ToPhone = Trim(dt1.Rows(0).Item("Email"))
                    End If
                    Prefix = TxtEmpName.Text
                    Appdate = TxtApplicationDate.Text
                    FromDate = txtleavefrom.Text
                    ToDate = txtleaveto.Text
                    LeaveType = ddlleavetype.SelectedItem.Text
                    EmpCode = TxtEmpCode.Text
                    NoOfDays = TxtNoofdaysappl.Text
                    Reason = Txtreason.Text
                    BalanceLeave = (TxtbalnceLeave.Text - TxtNoofdaysappl.Text)
                    DelegateName = txtDelegate.Text
                    Message = "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Code : " + EmpCode + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Name : " + Prefix + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave Type : " + LeaveType + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave From : " + FromDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave To : " + ToDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;No of days : " + NoOfDays + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Balance leave : " + BalanceLeave + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Reason for leave : " + Reason + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Delegate Name : " + DelegateName
                    'Message = "I," + Prefix + ", " + Reason + ". I kindly request you to grant me " + NoOfDays + " day(s) leave from " & FromDate & " to " & ToDate & ". Kindly Oblige."

                    Dim str As String = ""
                    Dim connection As New SqlClient.SqlConnection()
                    connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
                    connection.Open()
                    Dim cmd As New SqlCommand()
                    vm = "insert into Outbox_tbl (ToPhone,Message,prefix,BranchCode,CommunicationMode) values(@ToPhone,@Message,@Prefix,@BranchCode,@Mode)"

                    cmd.Connection = connection
                    cmd.CommandText = vm
                    parm_phonesp = New SqlParameter
                    parm_phonesp.ParameterName = "@ToPhone"
                    parm_phonesp.Value = ToPhone
                    parm_phonesp.DbType = DbType.String
                    cmd.Parameters.Add(parm_phonesp)

                    parm_msg = New SqlParameter
                    parm_msg.ParameterName = "@Message"
                    parm_msg.Value = Message
                    parm_msg.DbType = DbType.String
                    cmd.Parameters.Add(parm_msg)

                    parm_msgfrm = New SqlParameter
                    parm_msgfrm.ParameterName = "@Prefix"
                    parm_msgfrm.Value = Prefix
                    parm_msgfrm.DbType = DbType.String
                    cmd.Parameters.Add(parm_msgfrm)

                    parm_date = New SqlParameter
                    parm_date.ParameterName = "@SentDate"
                    parm_date.Value = CDate(Appdate)
                    parm_date.DbType = DbType.Date
                    cmd.Parameters.Add(parm_date)

                    parm_msgfrm = New SqlParameter
                    parm_msgfrm.ParameterName = "@BranchCode"
                    parm_msgfrm.Value = Session("BranchCode")
                    parm_msgfrm.DbType = DbType.String
                    cmd.Parameters.Add(parm_msgfrm)

                    parm_msgfrm = New SqlParameter
                    parm_msgfrm.ParameterName = "@Mode"
                    parm_msgfrm.Value = Mode
                    parm_msgfrm.DbType = DbType.String
                    cmd.Parameters.Add(parm_msgfrm)

                    cmd.ExecuteNonQuery()
                End If
            Else
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub Gvleaveapp_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles Gvleaveapp.Sorting
        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim userid As String = Session("UserRole")
        dt3 = LeaveApplicationDL.GetUserRole(userid)
        Dim Str As String = dt3.Rows(0).Item("Column1").ToString
        If Str.Contains("Leave Role") Then
            dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
            Dim sortedView As New DataView(dt)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            Gvleaveapp.DataSource = sortedView
            Gvleaveapp.DataBind()
        Else
            dt = BL.DispGrid(0)
            Dim sortedView As New DataView(dt)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            Gvleaveapp.DataSource = sortedView
            Gvleaveapp.DataBind()
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

    Protected Sub txtleavefrom_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtleavefrom.TextChanged
        Dim Noofdays As Double
        Try
            If CDate(txtleavefrom.Text) = CDate(txtleaveto.Text) Then
                If RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 2 Then
                    Noofdays = 1
                ElseIf (RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 1) Or (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 2) Then
                    Noofdays = 0.5
                ElseIf (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 1) Then
                    lblErrorMsg.Text = "Wrong Selection."
                    msginfo.Text = ""
                End If

            Else
                Noofdays = Convert.ToInt32(DateDiff(DateInterval.Day, CDate(Me.txtleavefrom.Text), CDate(Me.txtleaveto.Text)))
                Noofdays = Noofdays + 1
                If (RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 1) Or (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 2) Then
                    Noofdays = Noofdays - 0.5
                ElseIf (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 1) Then
                    Noofdays = Noofdays - 1
                End If

            End If
            Dim dt1 As New DataTable
            EL.Leavefrom = txtleavefrom.Text
            EL.Leaveto = txtleaveto.Text
            dt1 = LeaveApplicationDL.getHolidayCount(EL)
            Dim HolidayCnt As Integer
            If dt1.Rows.Count > 0 Then
                HolidayCnt = dt1.Rows(0).Item("TotCnt")
            End If
            TxtNoofdaysappl.Text = Noofdays - HolidayCnt
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct date."
            msginfo.Text = ""
        End Try
    End Sub

    Protected Sub RBReport_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBReport.SelectedIndexChanged
        Dim Noofdays As Double
        Try
            If CDate(txtleavefrom.Text) = CDate(txtleaveto.Text) Then
                If RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 2 Then
                    Noofdays = 1
                ElseIf (RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 1) Or (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 2) Then
                    Noofdays = 0.5
                ElseIf (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 1) Then
                    lblErrorMsg.Text = "Wrong Selection."
                    msginfo.Text = ""
                End If

            Else
                Noofdays = Convert.ToInt32(DateDiff(DateInterval.Day, CDate(Me.txtleavefrom.Text), CDate(Me.txtleaveto.Text)))
                Noofdays = Noofdays + 1
                If (RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 1) Or (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 2) Then
                    Noofdays = Noofdays - 0.5
                ElseIf (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 1) Then
                    Noofdays = Noofdays - 1
                End If

            End If
            Dim dt1 As New DataTable
            EL.Leavefrom = txtleavefrom.Text
            EL.Leaveto = txtleaveto.Text
            dt1 = LeaveApplicationDL.getHolidayCount(EL)
            Dim HolidayCnt As Integer
            If dt1.Rows.Count > 0 Then
                HolidayCnt = dt1.Rows(0).Item("TotCnt")
            End If
            TxtNoofdaysappl.Text = Noofdays - HolidayCnt
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct date."
            msginfo.Text = ""
        End Try
    End Sub

    Protected Sub RBReport1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBReport1.SelectedIndexChanged
        Dim Noofdays As Double
        Try
            If CDate(txtleavefrom.Text) = CDate(txtleaveto.Text) Then
                If RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 2 Then
                    Noofdays = 1
                ElseIf (RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 1) Or (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 2) Then
                    Noofdays = 0.5
                ElseIf (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 1) Then
                    lblErrorMsg.Text = "Wrong Selection."
                    msginfo.Text = ""
                End If

            Else
                Noofdays = Convert.ToInt32(DateDiff(DateInterval.Day, CDate(Me.txtleavefrom.Text), CDate(Me.txtleaveto.Text)))
                Noofdays = Noofdays + 1
                If (RBReport.SelectedValue = 1 And RBReport1.SelectedValue = 1) Or (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 2) Then
                    Noofdays = Noofdays - 0.5
                ElseIf (RBReport.SelectedValue = 2 And RBReport1.SelectedValue = 1) Then
                    Noofdays = Noofdays - 1
                End If

            End If
            Dim dt1 As New DataTable
            EL.Leavefrom = txtleavefrom.Text
            EL.Leaveto = txtleaveto.Text
            dt1 = LeaveApplicationDL.getHolidayCount(EL)
            Dim HolidayCnt As Integer
            If dt1.Rows.Count > 0 Then
                HolidayCnt = dt1.Rows(0).Item("TotCnt")
            End If
            TxtNoofdaysappl.Text = Noofdays - HolidayCnt
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct date."
            msginfo.Text = ""
        End Try
    End Sub

    Protected Sub ddlEmpName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlEmpName.SelectedIndexChanged

        Try
            Dim userid As String = Session("UserRole")
            dt3 = LeaveApplicationDL.GetUserRole(userid)
            Dim Str As String = dt3.Rows(0).Item("Column1").ToString
            If Str.Contains("Leave Role") Then
                dt = BL.delegatename(ddlEmpName.SelectedValue)
                If dt.Rows.Count > 0 Then
                    txtDelegate.Text = dt.Rows(0).Item("Emp_Name").ToString
                Else
                    txtDelegate.Text = ""
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
