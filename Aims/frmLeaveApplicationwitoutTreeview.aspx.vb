Imports System.Data.SqlClient
Partial Class frmLeaveApplicationwitoutTreeview
    Inherits BasePage
    Dim BL As New LeaveApplicationBL
    Dim EL As New LeaveApplicationEL
    Dim DL As New LeaveApplicationDL
    Dim dt, dt1 As DataTable
    'Anchala Verma 11-04-2012
    'Code for page load
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        Try
            If Not IsPostBack Then
                RBReport.SelectedValue = 1
                RBReport1.SelectedValue = 2
                If Session("LoginType") = "Employee" Then
                    If Session("EmpName") <> "" Then
                        TxtApplicationDate.Text = Format(Today, "dd-MMM-yyyy")
                        TxtEmpName.Text = Session("EmpName")
                        TxtEmpCode.Text = Session("EmpCode")
                        HidEmpId.Value = Session("EmpID")
                        txtleavefrom.Text = Format(Today, "dd-MMM-yyyy")
                        TxtApplicationDate.Enabled = False
                        TxtEmpCode.Enabled = False
                        TxtEmpName.Enabled = False
                        TxtNoofdaysappl.Enabled = False
                        TxtbalnceLeave.Enabled = False
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
                    Gvleaveapp.Columns(1).HeaderText = "Student Code"
                    Gvleaveapp.Columns(2).HeaderText = "Student Name"
                    Gvleaveapp.Columns(3).Visible = False
                    Gvleaveapp.Columns(9).Visible = False
                    Gvleaveapp.Columns(10).Visible = False

                    TxtEmpCode.Enabled = False
                    TxtEmpName.Enabled = False
                    TxtNoofdaysappl.Enabled = False
                    ddlleavetype.Visible = False
                    Label13.Visible = False
                    TxtbalnceLeave.Visible = False
                    TxtbalnceLeave.Text = "0"
                    Label5.Visible = False

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
    Protected Sub btnsave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        ddlleavetype.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If Session("LoginType") = "Employee" Then
                    TxtEmpName.Text = Session("EmpName")
                    TxtEmpCode.Text = Session("EmpCode")
                    HidEmpId.Value = Session("EmpID")
                    EL.empid = HidEmpId.Value
                    EL.leavetype = ddlleavetype.SelectedValue
                Else
                    TxtApplicationDate.Text = Format(Today, "dd-MMM-yyyy")
                    TxtEmpName.Text = Session("StudentName")
                    Label1.Text = "Student Name :&nbsp;&nbsp;"
                    TxtEmpCode.Text = Session("StudentCode")
                    Label8.Text = "Student Code :&nbsp;&nbsp;"
                    EL.empid = 0
                    HidEmpId.Value = 0
                    EL.leavetype = 0
                End If

                EL.Leavefrom = txtleavefrom.Text
                EL.Leaveto = txtleaveto.Text
                EL.FeedBack = txtRemarks.Text
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
                    dt = LeaveApplicationDL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        lblErrorMsg.Text = "Data already Exists."
                        msginfo.Text = ""
                    Else
                        'generatemsg(EL)
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
                    dt = BL.DispGrid(0)
                    Gvleaveapp.DataSource = dt
                    Gvleaveapp.DataBind()
                    Gvleaveapp.Enabled = True
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
            dt = BL.DispGrid(0)
            If dt.Rows.Count > 0 Then
                Gvleaveapp.DataSource = dt
                Gvleaveapp.DataBind()
                Gvleaveapp.Enabled = True
                msginfo.Text = ""
                lblErrorMsg.Text = ""
            Else
                lblErrorMsg.Text = "No records to display."
                msginfo.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Gvleaveapp_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles Gvleaveapp.PageIndexChanging
        Gvleaveapp.PageIndex = e.NewPageIndex
        Dim dt As New DataTable
        dt = BL.DispGrid(0)
        Gvleaveapp.DataSource = dt
        Gvleaveapp.Visible = True
        Gvleaveapp.DataBind()
    End Sub
    Protected Sub ddlleavetype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlleavetype.SelectedIndexChanged
        TxtbalnceLeave.Text = "0"
        Try
            dt = BL.balanceleave(ddlleavetype.SelectedValue, HidEmpId.Value)
            TxtbalnceLeave.Text = dt.Rows(0).Item("BalanceLeave").ToString
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

            TxtNoofdaysappl.Text = Noofdays
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct date."
            msginfo.Text = ""
        End Try
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    'Sub generatemsg(ByVal el As LeaveApplicationEL)
    '    Dim vm As String
    '    Dim parm_msg, parm_phonesp, parm_msgfrm, parm_date As SqlParameter
    '    dt = BL.DispGrid(0)
    '    dt1 = BL.email()
    '    Try
    '        Dim ToPhone As String
    '        Dim Appdate As String
    '        Dim FromDate As String
    '        Dim ToDate As String
    '        Dim EmpCode As String
    '        Dim Prefix As String
    '        Dim NoOfDays As String
    '        Dim Reason As String
    '        Dim LeaveType As String
    '        Dim Message As String
    '        Dim BalanceLeave As String
    '        Dim Mode As String = "Email"
    '        If Session("EmailService") = "Y" Then
    '            If dt.Rows.Count > 0 Then
    '                ToPhone = Trim(dt1.Rows(0).Item("Email"))
    '                Prefix = TxtEmpName.Text
    '                Appdate = TxtApplicationDate.Text
    '                FromDate = txtleavefrom.Text
    '                ToDate = txtleaveto.Text
    '                LeaveType = ddlleavetype.SelectedItem.Text
    '                EmpCode = TxtEmpCode.Text
    '                NoOfDays = TxtNoofdaysappl.Text
    '                Reason = Txtreason.Text
    '                BalanceLeave = (TxtbalnceLeave.Text - TxtNoofdaysappl.Text)
    '                Message = "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Code : " + EmpCode + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Name : " + Prefix + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave Type : " + LeaveType + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave From : " + FromDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave To : " + ToDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;No of days : " + NoOfDays + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Balance leave : " + BalanceLeave + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Reason for leave : " + Reason
    '                'Message = "I," + Prefix + ", " + Reason + ". I kindly request you to grant me " + NoOfDays + " day(s) leave from " & FromDate & " to " & ToDate & ". Kindly Oblige."

    '                Dim str As String = ""
    '                Dim connection As New SqlClient.SqlConnection()
    '                connection.ConnectionString = ConfigurationManager.ConnectionStrings("Bizcom").ConnectionString
    '                connection.Open()
    '                Dim cmd As New SqlCommand()
    '                vm = "insert into Outbox_tbl (ToPhone,Message,prefix,BranchCode,CommunicationMode) values(@ToPhone,@Message,@Prefix,@BranchCode,@Mode)"

    '                cmd.Connection = connection
    '                cmd.CommandText = vm
    '                parm_phonesp = New SqlParameter
    '                parm_phonesp.ParameterName = "@ToPhone"
    '                parm_phonesp.Value = ToPhone
    '                parm_phonesp.DbType = DbType.String
    '                cmd.Parameters.Add(parm_phonesp)

    '                parm_msg = New SqlParameter
    '                parm_msg.ParameterName = "@Message"
    '                parm_msg.Value = Message
    '                parm_msg.DbType = DbType.String
    '                cmd.Parameters.Add(parm_msg)

    '                parm_msgfrm = New SqlParameter
    '                parm_msgfrm.ParameterName = "@Prefix"
    '                parm_msgfrm.Value = Prefix
    '                parm_msgfrm.DbType = DbType.String
    '                cmd.Parameters.Add(parm_msgfrm)

    '                parm_date = New SqlParameter
    '                parm_date.ParameterName = "@SentDate"
    '                parm_date.Value = CDate(Appdate)
    '                parm_date.DbType = DbType.Date
    '                cmd.Parameters.Add(parm_date)

    '                parm_msgfrm = New SqlParameter
    '                parm_msgfrm.ParameterName = "@BranchCode"
    '                parm_msgfrm.Value = Session("BranchCode")
    '                parm_msgfrm.DbType = DbType.String
    '                cmd.Parameters.Add(parm_msgfrm)

    '                parm_msgfrm = New SqlParameter
    '                parm_msgfrm.ParameterName = "@Mode"
    '                parm_msgfrm.Value = Mode
    '                parm_msgfrm.DbType = DbType.String
    '                cmd.Parameters.Add(parm_msgfrm)

    '                cmd.ExecuteNonQuery()
    '            End If
    '        Else
    '        End If
    '    Catch ex As Exception
    '    End Try
    'End Sub

    Protected Sub Gvleaveapp_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles Gvleaveapp.Sorting
        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        dt = BL.DispGrid(0)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        Gvleaveapp.DataSource = sortedView
        Gvleaveapp.DataBind()
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
