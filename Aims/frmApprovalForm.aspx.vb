Imports System.Net.Mail
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Data.SqlClient
Partial Class frmApprovalForm
    Inherits BasePage
    Dim approve As New ApprovalForm
    Dim BlApp As New BLApprovalForm
    Dim dt As New DataTable
    Dim strg As String
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        others()
    End Sub
    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        GridView2.PageIndex = e.NewPageIndex
        LeaveApp()
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Session("RowID") = CType(GridView1.Rows(e.RowIndex).FindControl("lblRowId"), Label).Text
        Dim from As String = CType(GridView1.Rows(e.RowIndex).FindControl("LabelFormName"), Label).Text
        If from = "frmleaveapplication.aspx" Then
            Dim sepWin As String = "frmLeaveApplicationwitoutTreeview.aspx?Type=" & 1 & "&RowId" & Session("RowID") & SeperateWindow.SepWindow()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & sepWin & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        End If
        If from = "FrmEmpTransfer.aspx" Then
            Dim sepWin As String = "FrmEmpTransferwitoutTreeview.aspx?Type=" & 1 & "&RowId" & Session("RowID") & SeperateWindow.SepWindow()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & sepWin & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        End If
        If from = "frmAssetTransferNew.aspx" Then
            Dim sepWin As String = "frmAssetTransferwitoutTreeview.aspx?Type=" & 1 & "&RowId" & Session("RowID") & SeperateWindow.SepWindow()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & sepWin & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        End If
        If from = "FrmRollOver.aspx" Then
            Dim sepWin As String = "FrmRolloverwitoutTreeview.aspx?Type=" & 1 & "&RowId" & Session("RowID") & SeperateWindow.SepWindow()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & sepWin & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        End If
        If from = "Mfg_frmMaterialIndent.aspx" Then
            Dim sepWin As String = "Mfg_frmMaterialIndentTreeview.aspx?Type=" & 1 & "&RowId" & Session("RowID") & SeperateWindow.SepWindow()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & sepWin & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        End If
        'Session("RowID") = ""
    End Sub
    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Session("RowID") = CType(GridView2.Rows(e.RowIndex).FindControl("lblRowId"), Label).Text
        Dim from As String = CType(GridView2.Rows(e.RowIndex).FindControl("LabelFormName"), Label).Text
        If from = "frmleaveapplication.aspx" Then
            Dim sepWin As String = "frmLeaveApplicationwitoutTreeview.aspx?Type=" & 1 & "&RowId" & Session("RowID") & SeperateWindow.SepWindow()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & sepWin & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        End If
    End Sub
Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Session("RowID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRowId"), Label).Text
            Dim from As String = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabelFormName"), Label).Text
            Dim dtE As New Data.DataTable
            Dim branch As String = HttpContext.Current.Session("BranchCode")
            strg = "Approve"
            Session("ApproveId") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HiddenId"), HiddenField).Value
            approve.ApproveId = Session("ApproveId")
            approve.Remarks = CType(GridView1.Rows(e.NewEditIndex).FindControl("txtrem"), TextBox).Text
            If from = "Mfg_frmMaterialIndent.aspx" Then
                BlApp.ApprovalPurchase(approve)
            End If
            If from <> "FrmRollOver.aspx" Then
                BlApp.Approval1(approve)
                BlApp.Approval(approve)
            Else
                BlApp.ApprovalStudent(approve)
            End If


            others()
            Session("RowID") = ""
            lblmsg.Text = "Record is approved."
            msginfo.Text = ""
        Else
            msginfo.Text = "You do not belong to this branch, Cannot approve data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Session("RowID") = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblRowId"), Label).Text
            Dim from As String = CType(GridView2.Rows(e.NewEditIndex).FindControl("LabelFormName"), Label).Text
            Dim Row_No As Integer = Session("RowID")
            Dim dtE As New Data.DataTable
            Dim branch As String = HttpContext.Current.Session("BranchCode")
            strg = "Approve"
            Session("ApproveId") = CType(GridView2.Rows(e.NewEditIndex).FindControl("HiddenId"), HiddenField).Value
            approve.ApproveId = Session("ApproveId")
            approve.Remarks = CType(GridView2.Rows(e.NewEditIndex).FindControl("txtrem"), TextBox).Text
            If from = "Mfg_frmMaterialIndent.aspx" Then
                BlApp.ApprovalPurchase(approve)
            End If

            If from <> "FrmRollOver.aspx" Then
                If DLApprovalForm.CheckforCancellation(Row_No).Tables(0).Rows(0).Item(0) = "Y" Then
                    BlApp.ApproveforCancellation(approve)
                Else

                    BlApp.Approval1(approve)
                    BlApp.Approval(approve)
                End If
            Else
                BlApp.ApprovalStudent(approve)
            End If
            Dim EmpId As Integer = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblEmpId"), Label).Text

            If from = "frmleaveapplication.aspx" Then
                Dim Remarks As String = CType(GridView2.Rows(e.NewEditIndex).FindControl("txtrem"), TextBox).Text
                Dim vm As String
                Dim Dmail As String = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblDelgEmail"), Label).Text

                Dim dt3, dt1, dt2, dt4, dt5 As DataTable
                Dim parm_msg, parm_phonesp, parm_msgfrm, parm_date As SqlParameter
                Dim userid As String = Session("UserRole")
                dt3 = LeaveApplicationDL.GetUserRole(userid)
                Dim Str1 As String = dt3.Rows(0).Item("Column1").ToString
                'If Str1.Contains("Leave Role") Then
                '    dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
                'Else
                '    dt = BL.DispGrid(0)
                'End If
                'EmpId = CType(GridView2.Rows(e.RowIndex).FindControl("lblEmpId"), Label).Text
                Dim empid1 As Integer = Session("EmpId")
                dt1 = BlApp.email(EmpId)
                dt2 = BlApp.GetHREmail(EmpId)
                dt4 = BlApp.email1(empid1)
                dt5 = BlApp.Nextemail(EmpId, Session("RowID"))
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
                    Dim DelegateName As String
                    'Dim BalanceLeave As String
                    Dim Mode As String = "Email"
                    If Session("EmailService") = "Y" Then
                        If dt1.Rows.Count > 0 Then
                            If dt2.Rows.Count > 0 And Dmail <> "" Then
                                ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt2.Rows(0).Item("HREmail")) + "," + Trim(dt4.Rows(0).Item("Email")) + "," + Dmail
                            ElseIf Dmail <> "" And dt2.Rows.Count = 0 Then
                                ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt4.Rows(0).Item("Email")) + "," + Dmail
                            ElseIf dt2.Rows.Count > 0 And Dmail = "" Then
                                ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt2.Rows(0).Item("HREmail")) + "," + Trim(dt4.Rows(0).Item("Email"))
                            Else
                                ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt4.Rows(0).Item("Email"))
                            End If
                            Prefix = CType(GridView2.Rows(e.NewEditIndex).FindControl("LabelContriName"), Label).Text
                            Appdate = CType(GridView2.Rows(e.NewEditIndex).FindControl("LabelEntryDate"), Label).Text
                            FromDate = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblLeaveFrom"), Label).Text
                            ToDate = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblLeaveTo"), Label).Text
                            DelegateName = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblDelgName"), Label).Text
                            'LeaveType = CType(GridView2.FindControl("Emp_Name"), Label).Text
                            'NoOfDays = CType(GridView2.FindControl("Emp_Name"), Label).Text
                            'Reason = CType(GridView2.FindControl("Emp_Name"), Label).Text
                            'BalanceLeave = (TxtbalnceLeave.Text - TxtNoofdaysappl.Text)
                            If DLApprovalForm.CheckforCancellation(Row_No).Tables(0).Rows(0).Item(0) = "Y" Then
                                Message = "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Name : " + Prefix + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave From : " + FromDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave To : " + ToDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leaves Cancellation Status : " + " Approved" + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Delegate Name :" + DelegateName

                            Else
                                Message = "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Name : " + Prefix + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave From: " + FromDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave To : " + ToDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Status : " + "Approved" + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Delegate Name :" + DelegateName
                                'Message = "I," + Prefix + ", " + Reason + ". I kindly request you to grant me " + NoOfDays + " day(s) leave from " & FromDate & " to " & ToDate & ". Kindly Oblige."
                            End If
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

                            dt5 = BlApp.Nextemail(EmpId, Session("RowID"))
                            dt = BlApp.GetGrid(ddlform.SelectedItem.Value)
                            If dt5.Rows.Count > 0 Then
                                ToPhone = Trim(dt5.Rows(0).Item("Email"))
                                Prefix = CType(GridView2.Rows(e.NewEditIndex).FindControl("LabelContriName"), Label).Text
                                Appdate = CType(GridView2.Rows(e.NewEditIndex).FindControl("LabelEntryDate"), Label).Text
                                FromDate = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblLeaveFrom"), Label).Text
                                ToDate = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblLeaveTo"), Label).Text
                                LeaveType = dt.Rows(0).Item("Leave_Type").ToString()
                                NoOfDays = dt.Rows(0).Item("DaysApplied").ToString()
                                Reason = dt.Rows(0).Item("Expr1").ToString()
                                EmpCode = dt.Rows(0).Item("Emp_Code").ToString()
                                Message = "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Code : " + EmpCode + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Name : " + Prefix + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave Type : " + LeaveType + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave From : " + FromDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave To : " + ToDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;No of days : " + NoOfDays + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Reason for leave : " + Reason
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
            End If
            LeaveApp()
            Session("RowID") = ""
            lblmsg.Text = "Record is approved."
            msginfo.Text = ""
        Else
            msginfo.Text = "You do not belong to this branch, Cannot approve data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim dtE As New Data.DataTable
            strg = "Reject"
            Session("RowID") = CType(GridView1.Rows(e.RowIndex).FindControl("HiddenId"), HiddenField).Value
            Session("ApproveId") = CType(GridView1.Rows(e.RowIndex).FindControl("HiddenId"), HiddenField).Value
            Dim EmpId As Integer = CType(GridView1.Rows(e.RowIndex).FindControl("lblEmpId"), Label).Text
            Dim from As String = CType(GridView1.Rows(e.RowIndex).FindControl("LabelFormName"), Label).Text
            If CType(GridView1.Rows(e.RowIndex).FindControl("txtrem"), TextBox).Text <> "" Then
                If from = "frmleaveapplication.aspx" Then
                    Dim Remarks As String = CType(GridView1.Rows(e.RowIndex).FindControl("txtrem"), TextBox).Text
                    generatemsg(EmpId)
                    BlApp.RRejection(Remarks)
                    others()
                    msginfo.Text = ""
                    lblmsg.Text = "Leave Application has been Rejected."
                    Session("RowID") = ""
                End If
                If from = "FrmEmpTransfer.aspx" Then
                    Dim Remarks As String = CType(GridView1.Rows(e.RowIndex).FindControl("txtrem"), TextBox).Text
                    BlApp.RRejection(Remarks)
                    others()
                    msginfo.Text = ""
                    lblmsg.Text = "Employee Transfer has been Rejected."
                    Session("RowID") = ""
                End If
                If from = "frmAssetTransferNew.aspx" Then
                    Dim Remarks As String = CType(GridView1.Rows(e.RowIndex).FindControl("txtrem"), TextBox).Text
                    BlApp.RRejection(Remarks)
                    others()
                    msginfo.Text = ""
                    lblmsg.Text = "Asset Transfer has been Rejected."
                    Session("RowID") = ""
                End If
                If from = "FrmRollOver.aspx" Then
                    Dim Remarks As String = CType(GridView1.Rows(e.RowIndex).FindControl("txtrem"), TextBox).Text
                    BlApp.RRejection(Remarks)
                    others()
                    msginfo.Text = ""
                    lblmsg.Text = "Student Transfer has been Rejected."
                    Session("RowID") = ""
                End If
                If from = "Mfg_frmMaterialIndent.aspx" Then
                    Dim Remarks As String = CType(GridView1.Rows(e.RowIndex).FindControl("txtrem"), TextBox).Text
                    BlApp.RRejection(Remarks)
                    others()
                    msginfo.Text = ""
                    lblmsg.Text = "Request has been Rejected."
                    Session("RowID") = ""
                End If
            Else
                msginfo.Text = "Remarks field is mandatory."
                lblmsg.Text = ""
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot reject data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GridView2_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView2.RowUpdating
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim dtE As New Data.DataTable
            strg = "Reject"
            Session("RowID") = CType(GridView2.Rows(e.RowIndex).FindControl("HiddenId"), HiddenField).Value
            Session("ApproveId") = CType(GridView2.Rows(e.RowIndex).FindControl("HiddenId"), HiddenField).Value
            Dim from As String = CType(GridView2.Rows(e.RowIndex).FindControl("LabelFormName"), Label).Text
            Dim EmpId As Integer = CType(GridView2.Rows(e.RowIndex).FindControl("lblEmpId"), Label).Text
            Session("Appremarks") = CType(GridView2.Rows(e.RowIndex).FindControl("lblRowId"), Label).Text
            Dim Row_No As Integer = Session("Appremarks")
            If CType(GridView2.Rows(e.RowIndex).FindControl("txtrem"), TextBox).Text <> "" Then
                If from = "frmleaveapplication.aspx" Then
                    Dim Remarks As String = CType(GridView2.Rows(e.RowIndex).FindControl("txtrem"), TextBox).Text
                    Dim vm As String
                    Dim Dmail As String = CType(GridView2.Rows(e.RowIndex).FindControl("lblDelgEmail"), Label).Text
                    Dim dt3, dt1, dt2, dt4 As DataTable
                    Dim parm_msg, parm_phonesp, parm_msgfrm, parm_date As SqlParameter
                    Dim userid As String = Session("UserRole")
                    dt3 = LeaveApplicationDL.GetUserRole(userid)
                    Dim Str1 As String = dt3.Rows(0).Item("Column1").ToString
                    'If Str1.Contains("Leave Role") Then
                    '    dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
                    'Else
                    '    dt = BL.DispGrid(0)
                    'End If
                    'EmpId = CType(GridView2.Rows(e.RowIndex).FindControl("lblEmpId"), Label).Text
                    Dim empid1 As Integer = Session("EmpId")
                    dt1 = BlApp.email(EmpId)
                    dt2 = BlApp.GetHREmail(EmpId)
                    dt4 = BlApp.email1(empid1)
                    Try
                        Dim ToPhone As String
                        Dim Appdate As String
                        Dim FromDate As String
                        Dim ToDate As String
                        Dim EmpCode As String
                        Dim Prefix As String
                        Dim NoOfDays As String
                        'Dim Reason As String
                        Dim LeaveType As String
                        Dim Message As String
                        Dim DelegateName As String
                        'Dim BalanceLeave As String
                        Dim Mode As String = "Email"
                        If Session("EmailService") = "Y" Then
                            If dt1.Rows.Count > 0 Then

                                If dt2.Rows.Count > 0 And Dmail <> "" Then
                                    ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt2.Rows(0).Item("HREmail")) + "," + Trim(dt4.Rows(0).Item("Email")) + "," + Dmail
                                ElseIf Dmail <> "" And dt2.Rows.Count = 0 Then
                                    ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt4.Rows(0).Item("Email")) + "," + Dmail
                                ElseIf dt2.Rows.Count > 0 And Dmail = "" Then
                                    ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt2.Rows(0).Item("HREmail")) + "," + Trim(dt4.Rows(0).Item("Email"))
                                Else
                                    ToPhone = Trim(dt1.Rows(0).Item("Email")) + "," + Trim(dt4.Rows(0).Item("Email"))
                                End If

                                Prefix = CType(GridView2.Rows(e.RowIndex).FindControl("LabelContriName"), Label).Text
                                Appdate = CType(GridView2.Rows(e.RowIndex).FindControl("LabelEntryDate"), Label).Text
                                FromDate = CType(GridView2.Rows(e.RowIndex).FindControl("lblLeaveFrom"), Label).Text
                                ToDate = CType(GridView2.Rows(e.RowIndex).FindControl("lblLeaveTo"), Label).Text
                                DelegateName = CType(GridView2.Rows(e.RowIndex).FindControl("lblDelgName"), Label).Text
                                'LeaveType = CType(GridView2.FindControl("Leave_Type"), Label).Text
                                'NoOfDays = CType(GridView2.FindControl("DaysApplied"), Label).Text
                                ''Reason = CType(GridView2.FindControl("Emp_Name"), Label).Text
                                'EmpCode
                                'LeaveType = CType(GridView2.Rows(e.RowIndex).FindControl("lblLeaveType"), Label).Text

                                NoOfDays = CType(GridView2.Rows(e.RowIndex).FindControl("lbldaysApplied"), Label).Text
                                EmpCode = CType(GridView2.Rows(e.RowIndex).FindControl("lblEmpCode"), Label).Text
                                'BalanceLeave = (TxtbalnceLeave.Text - TxtNoofdaysappl.Text)
                                If DLApprovalForm.CheckforCancellation(Row_No).Tables(0).Rows(0).Item(0) = "Y" Then
                                    Message = "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Code : " + EmpCode + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Name : " + Prefix + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave From : " + FromDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave To : " + ToDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;No of days : " + NoOfDays + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leaves Cancellation Status : " + "Rejected" + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Delegate Name :" + DelegateName
                                    'Message = "I," + Prefix + ", " + Reason + ". I kindly request you to grant me " + NoOfDays + " day(s) leave from " & FromDate & " to " & ToDate & ". Kindly Oblige."
                                Else
                                    Message = "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Code : " + EmpCode + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Name : " + Prefix + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave From : " + FromDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave To : " + ToDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;No of days : " + NoOfDays + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Status : " + "Rejected" + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Delegate Name :" + DelegateName
                                    'Message = "I," + Prefix + ", " + Reason + ". I kindly request you to grant me " + NoOfDays + " day(s) leave from " & FromDate & " to " & ToDate & ". Kindly Oblige."
                                End If
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
                    If DLApprovalForm.CheckforCancellation(Row_No).Tables(0).Rows(0).Item(0) = "Y" Then
                        BlApp.RejectforCancellation(Remarks)
                    Else
                        BlApp.RRejection(Remarks)
                    End If
                    LeaveApp()
                    msginfo.Text = ""
                    lblmsg.Text = "Leave Application has been Rejected."
                    Session("RowID") = ""
                End If

            Else
                msginfo.Text = "Remarks field is mandatory."
                lblmsg.Text = ""
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot reject data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            LinkButton1.Focus()
            If ddlform.SelectedValue = "Select" Then
                msginfo.Text = "Select Form Name."
                ddlform.Focus()
                lblmsg.Text = ""
            ElseIf ddlform.SelectedValue = 129 Then
                LeaveApp()
            Else

                others()
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot Submit."
            lblmsg.Text = ""
        End If
    End Sub
    Sub others()
        
        dt = BlApp.GetGrid(ddlform.SelectedItem.Value)


        If dt.Rows.Count <> 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView2.Visible = False
            msginfo.Text = ""
            lblmsg.Text = ""
        Else
            GridView1.Visible = False
            GridView2.Visible = False
            msginfo.Text = "No records to display."
            lblmsg.Text = ""
        End If
    End Sub
    Sub LeaveApp()

        dt = BlApp.GetGrid(ddlform.SelectedItem.Value)


        If dt.Rows.Count <> 0 Then
            GridView2.DataSource = dt
            GridView2.DataBind()
            GridView2.Visible = True
            GridView2.Enabled = True
            GridView1.Visible = False
            msginfo.Text = ""
            lblmsg.Text = ""
        Else
            GridView2.Visible = False
            GridView1.Visible = False
            msginfo.Text = "No records to display."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub ddlform_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlform.TextChanged
        ddlform.Focus()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlform.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
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
        dt = BlApp.GetGrid(ddlform.SelectedItem.Value)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
    End Sub
    Protected Sub GridView2_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView2.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        dt = BlApp.GetGrid(ddlform.SelectedItem.Value)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView2.DataSource = sortedView
        GridView2.DataBind()
        GridView2.Visible = True
        GridView2.Enabled = True
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
    Sub generatemsg(ByVal EmpId As Integer)
        Dim vm As String
        Dim dt3, dt1 As DataTable
        Dim parm_msg, parm_phonesp, parm_msgfrm, parm_date As SqlParameter
        Dim userid As String = Session("UserRole")
        dt3 = LeaveApplicationDL.GetUserRole(userid)
        Dim Str1 As String = dt3.Rows(0).Item("Column1").ToString
        'If Str1.Contains("Leave Role") Then
        '    dt = BL.DispGrid1(0, ddlEmpName.SelectedValue)
        'Else
        '    dt = BL.DispGrid(0)
        'End If
        'EmpId = CType(GridView2.Rows(e.RowIndex).FindControl("lblEmpId"), Label).Text
        For Each Grid As GridViewRow In GridView1.Rows
            EmpId = CType(Grid.FindControl("lblEmpId"), Label).Text
        Next
        dt1 = BlApp.email(EmpId)
        Try
            Dim ToPhone As String
            Dim Appdate As String
            Dim FromDate As String
            Dim ToDate As String
            Dim EmpCode As String
            Dim Prefix As String
            'Dim NoOfDays As String
            'Dim Reason As String
            'Dim LeaveType As String
            Dim Message As String
            'Dim BalanceLeave As String
            Dim Mode As String = "Email"
            If Session("EmailService") = "Y" Then
                If dt1.Rows.Count > 0 Then
                    ToPhone = Trim(dt1.Rows(0).Item("Email"))
                    Prefix = CType(GridView2.FindControl("LabelContriName"), Label).Text
                    Appdate = CType(GridView2.FindControl("LabelEntryDate"), Label).Text
                    FromDate = CType(GridView2.FindControl("lblLeaveFrom"), Label).Text
                    ToDate = CType(GridView2.FindControl("lblLeaveTo"), Label).Text
                    'LeaveType = CType(GridView2.FindControl("Emp_Name"), Label).Text
                    EmpCode = CType(GridView2.FindControl("Emp_Name"), Label).Text
                    'NoOfDays = CType(GridView2.FindControl("Emp_Name"), Label).Text
                    'Reason = CType(GridView2.FindControl("Emp_Name"), Label).Text
                    'BalanceLeave = (TxtbalnceLeave.Text - TxtNoofdaysappl.Text)
                    Message = "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Code : " + EmpCode + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Employee Name : " + Prefix + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave Type : " + FromDate + "<BR>&nbsp;&nbsp;&nbsp;&nbsp;Leave To : " + ToDate + "Reject"
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
End Class


