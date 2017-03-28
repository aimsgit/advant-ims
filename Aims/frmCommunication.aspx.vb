
Partial Class frmCommunication
    Inherits BasePage
    Dim bl As New BLCommunication
    Dim el As New ELCommunication
    Dim CommunicationMode, ID As String
    'Dim GroupType As Integer
    Dim dt As New DataTable
    Dim configvalue As String
    Protected Sub btnPublish_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPublish.Click
        Try
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If HttpContext.Current.Session("BranchCode") = "000000000000" Then
                    If DdlSelectClient.SelectedValue = "0" Then
                        lblError.Text = "Select Client Field is Mandatory."
                        DdlSelectClient.Focus()
                        Exit Sub
                    End If
                    If DdlSelectBranch.SelectedValue = "0" Then
                        lblError.Text = "Select Branch Field is Mandatory."
                        DdlSelectBranch.Focus()
                        Exit Sub
                    End If
                    If ddlGroup.SelectedValue = "7" Or ddlGroup.SelectedValue = "8" Then
                        If CheckSMS.Checked = True Then
                            lblError.Text = "SMS Service is blocked. "
                            Exit Sub
                        End If
                        If CheckNotice.Checked = True Then
                            lblError.Text = "Notice Board Service is blocked. "
                            Exit Sub
                        End If
                    End If
                End If
                If CheckSMS.Checked = True And CheckEmail.Checked = True And CheckNotice.Checked = True Then
                    el.Mode = "1,2,3"
                ElseIf CheckSMS.Checked = True And CheckEmail.Checked = True Then
                    el.Mode = "1,2"
                ElseIf CheckSMS.Checked = True And CheckNotice.Checked = True Then
                    el.Mode = "1,3"
                ElseIf CheckEmail.Checked = True And CheckNotice.Checked = True Then
                    el.Mode = "2,3"
                ElseIf CheckSMS.Checked = True Then
                    el.Mode = "1"
                ElseIf CheckEmail.Checked = True Then
                    el.Mode = "2"
                ElseIf CheckNotice.Checked = True Then
                    el.Mode = "3"
                Else
                    lblError.Text = "Select atleast one mode of communication."
                    Exit Sub
                End If
                If txtmsg.Text = "" Then
                    lblError.Text = "Message Field is Mandatory."
                    Exit Sub
                End If
                Dim EmailService As String = IIf(Session("EmailService") = "N", IIf(CheckEmail.Checked = True, "False", "True"), "True")
                Dim SMSService As String = IIf(Session("SMSService") = "N", IIf(CheckSMS.Checked = True, "False", "True"), "True")
                If EmailService = "False" And SMSService = "False" Then
                    lblError.Text = " SMS and Email Service are blocked. "
                    lblcorrect.Text = ""
                Else
                    If EmailService = "True" Then
                        If SMSService = "True" Then
                            lblError.Text = ""
                            lblcorrect.Text = ""
                            ID = ""
                            Dim GlobalFunction As New GlobalFunction
                            If txtDate.Text <> "" Then
                                If el.Mode <> "" Then
                                    el.date1 = txtDate.Text
                                    If ddlGroup.SelectedValue <> 5 And ddlGroup.SelectedValue <> 7 And ddlGroup.SelectedValue <> 8 Then
                                        For Each grid As GridViewRow In GVName.Rows
                                            If CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = True Then
                                                ID = CType(grid.FindControl("lblID"), Label).Text + "," + ID
                                            End If
                                        Next
                                        Try
                                            If el.Mode.Contains("1") Then
                                                Dim str As String = CStr(GlobalFunction.StripHTML(txtmsg.Text))
                                                If str.Length > 160 Or txtmsg.Text.Contains("IMG") Then
                                                    lblError.Text = " SMS Limit Exceeding 160 Characters. "
                                                    Exit Sub
                                                End If
                                            End If
                                            el.GroupType = ddlGroup.SelectedItem.Text
                                            el.ID = Left(ID, ID.Length - 1)
                                            If el.ID = "" Then
                                                el.ID = 0
                                            End If
                                            'el.ID = 0
                                            'el.Message = txtmsg.HtmlStrippedText 'for sms sending
                                            If (txtUrl.Text.Length <> 0) Then
                                                el.Message = txtmsg.Text + Environment.NewLine + "Attachment :<a href='file:" + txtUrl.Text + "'target='_blank'>" + txtUrl.Text + "</a>" 'for Email sending.
                                            Else
                                                el.Message = txtmsg.Text
                                            End If
                                            el.From = txtFrom.Text
                                            el.Institute = DdlSelectClient.SelectedValue
                                            el.Branch = DdlSelectBranch.SelectedValue
                                        Catch ex As Exception
                                            lblError.Text = "Select atleast one " + ddlGroup.SelectedItem.Text.ToString + "."
                                            lblcorrect.Text = ""
                                            Exit Sub
                                        End Try
                                        bl.InsertCommunication(el)
                                        lblcorrect.Text = "Message sent for approval."
                                        lblError.Text = ""
                                        ddlGroup.SelectedItem.Selected = False
                                        GVName.Visible = False
                                        lblcode.Visible = False
                                        txtcode.Visible = False
                                        lblname.Visible = False
                                        txtname.Visible = False
                                        btnsrch.Visible = False
                                        GVName.Visible = False
                                        clear()
                                    Else
                                        el.GroupType = ddlGroup.SelectedItem.Text
                                        el.ID = 0
                                        'el.ID = Left(ID, ID.Length - 1)
                                        If (txtUrl.Text.Length <> 0) Then
                                            el.Message = txtmsg.Text + Environment.NewLine + "Attachment : <a href='file:" + txtUrl.Text + "'target='_blank'>" + txtUrl.Text + "</a> " 'for Email sending.
                                        Else
                                            el.Message = txtmsg.Text
                                        End If
                                        el.From = txtFrom.Text
                                        el.Institute = DdlSelectClient.SelectedValue
                                        el.Branch = DdlSelectBranch.SelectedValue
                                        bl.InsertCommunication(el)
                                        lblcorrect.Text = "Message sent for approval."
                                        lblError.Text = ""
                                        ddlGroup.SelectedItem.Selected = False
                                        lblcode.Visible = False
                                        txtcode.Visible = False
                                        lblname.Visible = False
                                        txtname.Visible = False
                                        btnsrch.Visible = False
                                        GVName.Visible = False
                                        clear()
                                    End If
                                End If
                            Else
                                lblError.Text = "Date Field is mandatory."
                                lblcorrect.Text = ""
                            End If
                        Else
                            lblError.Text = " SMS Service is blocked. "
                            lblcorrect.Text = ""
                        End If
                    Else
                        lblError.Text = " Email Service is blocked. "
                        lblcorrect.Text = ""
                    End If
                End If
            Else
                lblError.Text = "You do not belong to this branch, Cannot publish."
                lblcorrect.Text = ""
            End If

        Catch ex As Exception
            lblError.Text = "Enter correct date."
            lblcorrect.Text = ""
        End Try
    End Sub
    'Sub ModeCheck()
    '    If CheckSMS.Checked = True And CheckEmail.Checked = True And CheckNotice.Checked = True Then
    '        el.Mode = "1,2,3"
    '    ElseIf CheckSMS.Checked = True And CheckEmail.Checked = True Then
    '        el.Mode = "1,2"
    '    ElseIf CheckSMS.Checked = True And CheckNotice.Checked = True Then
    '        el.Mode = "1,3"
    '    ElseIf CheckEmail.Checked = True And CheckNotice.Checked = True Then
    '        el.Mode = "2,3"
    '    ElseIf CheckSMS.Checked = True Then
    '        el.Mode = "1"
    '    ElseIf CheckEmail.Checked = True Then
    '        el.Mode = "2"
    '    ElseIf CheckNotice.Checked = True Then
    '        el.Mode = "3"
    '    Else
    '        lblError.Text = "Select atleast one mode of communication."
    '        Exit Sub
    '    End If
    'End Sub
    'Function SelectGroup() As Integer
    '    If ddlGroup.SelectedValue = 1 Then
    '        el.IsBatch = "Y"
    '        GroupType = 1
    '    Else
    '        el.IsBatch = "N"
    '    End If
    '    el.From = txtFrom.Text
    '    el.Message = txtmsg.Text
    '    If ddlGroup.SelectedValue = 2 Then
    '        el.IsEmployee = "Y"
    '        GroupType = 2
    '    Else
    '        el.IsEmployee = "N"
    '    End If

    '    If ddlGroup.SelectedValue = 3 Then
    '        el.IsParents = "Y"
    '        GroupType = 3
    '    Else
    '        el.IsParents = "N"
    '    End If

    '    If ddlGroup.SelectedValue = 4 Then
    '        el.IsCourse = "Y"
    '        GroupType = 4
    '    Else
    '        el.IsCourse = "N"
    '    End If

    '    If ddlGroup.SelectedValue = 5 Then
    '        el.IsPublic = "Y"
    '        GroupType = 5
    '    Else
    '        el.IsPublic = "N"
    '    End If

    '    If ddlGroup.SelectedValue = 6 Then
    '        el.IsPublic = "Y"
    '        GroupType = 6
    '    Else
    '        el.IsPublic = "N"
    '    End If
    '    Return GroupType
    'End Function
    Sub CheckAll()
        If CType(GVName.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GVName.Rows
                CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GVName.Rows
                CType(grid.FindControl("ChkIndividual"), CheckBox).Checked = False
            Next
        End If
    End Sub
    Sub clear()
        txtFrom.Text = ""
        txtmsg.Text = ""
        CheckEmail.Checked = False
        CheckNotice.Checked = False
        CheckSMS.Checked = False
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If HttpContext.Current.Session("BranchCode") = "000000000000" Then
            SuperAdminAccess.visible = "true"
        Else
            SuperAdminAccess.visible = "false"
        End If

        If IsPostBack = False Then
            txtFrom.Focus()
            txtDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
        'If Not IsPostBack Then
        '    DdlSelectClient.SelectedValue = "0000"
        'End If
    End Sub

    Protected Sub ddlGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged
        Try
            lblError.Text = ""
            lblcorrect.Text = ""
            txtcode.Text = ""
            txtname.Text = ""
            display()
            If (ddlGroup.SelectedValue = 2) Then
                lblcode.Visible = True
                lblcode.Text = "Emp Code :&nbsp;&nbsp;"
                txtcode.Visible = True
                lblname.Visible = True
                lblname.Text = "Emp Name :&nbsp;&nbsp;"
                txtname.Visible = True
                btnsrch.Visible = True
                txtcode.Text = ""
                txtname.Text = ""
            ElseIf (ddlGroup.SelectedValue = 3) Then
                lblcode.Visible = True
                lblcode.Text = "Std Code :&nbsp;&nbsp;"
                txtcode.Visible = True
                lblname.Visible = True
                lblname.Text = "Std Name :&nbsp;&nbsp;"
                txtname.Visible = True
                btnsrch.Visible = True
                txtcode.Text = ""
                txtname.Text = ""
            Else
                lblcode.Visible = False
                txtcode.Visible = False
                lblname.Visible = False
                txtname.Visible = False
                btnsrch.Visible = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Protected Sub GVName_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVName.PageIndexChanging
        GVName.PageIndex = e.NewPageIndex
        GVName.DataBind()
        display()
    End Sub
    Sub display()
        If Session("BranchCode") = "000000000000" Then
            dt = bl.GetNameComboSuper(ddlGroup.SelectedValue, DdlSelectClient.SelectedValue, DdlSelectBranch.SelectedValue, txtcode.Text, txtname.Text)
            If (dt.Rows.Count > 0) Then
                GVName.DataSource = dt
                GVName.DataBind()
                dt.Dispose()
                GVName.Visible = True
            Else
                lblError.Text = "No records to display."
                lblcorrect.Text = ""
                GVName.Visible = False
            End If
        Else
            dt = bl.GetNameCombo(ddlGroup.SelectedValue, txtcode.Text, txtname.Text)
            If (dt.Rows.Count > 0) Then
                GVName.DataSource = dt
                GVName.DataBind()
                dt.Dispose()
                GVName.Visible = True
            Else
                lblError.Text = "No records to display."
                lblcorrect.Text = ""
                GVName.Visible = False
            End If
        End If
        'dt = bl.GetNameCombo(ddlGroup.SelectedValue)
        'GVName.DataSource = dt
        'GVName.DataBind()
        'dt.Dispose()
        'GVName.Visible = True
    End Sub

    Protected Sub ddlGroup_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlGroup.TextChanged
        ddlGroup.Focus()
    End Sub

    Protected Sub LinkViewStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkViewStatus.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim qrystring As String = "ViewMsgStatusPopUp.aspx?"
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Else
            lblError.Text = "You do not belong to this branch, Cannot view."
            lblcorrect.Text = ""
        End If
    End Sub

    Protected Sub ddlSMSTemplate_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSMSTemplate.SelectedIndexChanged
        Dim SMSID As Integer
        If ddlSMSTemplate.SelectedValue = 0 Then
            txtmsg.Text = ""
        Else
            SMSID = ddlSMSTemplate.SelectedValue
            dt = bl.GetSMSMessage(SMSID)
            txtmsg.Text = dt.Rows(0).Item("Message")
        End If
    End Sub

    'Protected Sub txtUrl_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUrl.TextChanged
    '    If (txtUrl.Text.Length > 0) Then
    '        txtUrl.Text = Replace(txtUrl.Text, "\", "\\")
    '    End If

    'End Sub

    Protected Sub btnsrch_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsrch.Click
        
        display()
    End Sub
End Class
