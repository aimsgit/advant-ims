Partial Class frmResetPwd
    Inherits BasePage
    Dim GlobalFunction As New GlobalFunction
    Dim r As New ResetPwd
    Dim blr As New BLResetPwd
    Dim a As Integer
    Dim newp As Integer
    Protected Sub btnResetPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetPassword.Click
        RblLoginType.Focus()
        If String.Compare(validPass.Value, "true") = 0 Then
            If (Session("BranchCode") = Session("ParentBranch")) Then
                a = GlobalFunction.UserPrivilage()
                If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                    If RblLoginType.SelectedValue = 1 Then
                        If txtusername.Text = "" Then
                            lblmsg.Visible = True
                            lblMsginfo.Visible = True
                            lblMsginfo.Text = ""
                            lblmsg.Text = "Enter username."
                            txtusername.Focus()
                        Else
                            Dim str As String = txtusername.Text.Trim.ToLower
                            r.BranchCode = Session("BranchCode")
                            r.UserCode = txtusername.Text.Trim
                            Dim dt As New Data.DataTable
                            dt = blr.getuser(r)
                            If dt.Rows.Count > 0 Then
                                Dim str1 As String
                                str1 = dt.Rows(0).Item("UserName").ToString().ToLower
                                If str = str1 Then
                                    newp = Len(txtNewPassword.Text.Trim)
                                    If newp > 5 And newp < 16 Then
                                        If txtConfmPassword.Text.Trim = txtNewPassword.Text.Trim Then
                                            r.UserCode = txtusername.Text.Trim
                                            r.Password = RijndaelSimple.Encrypt(txtConfmPassword.Text.Trim,
                                                       RijndaelSimple.passPhrase,
                                                       RijndaelSimple.saltValue,
                                                       RijndaelSimple.hashAlgorithm,
                                                       RijndaelSimple.passwordIterations,
                                                       RijndaelSimple.initVector,
                                                       RijndaelSimple.keySize)
                                            blr.Resetpwd(r)
                                            lblmsg.Text = ""
                                            txtConfmPassword.Text = ""
                                            txtNewPassword.Text = ""
                                            txtusername.Text = ""
                                            lblmsg.Visible = True
                                            lblMsginfo.Visible = True
                                            lblMsginfo.Text = "Reset password done successfully."
                                        Else
                                            lblMsginfo.Text = ""
                                            txtConfmPassword.Focus()
                                            txtConfmPassword.Text = ""
                                            txtNewPassword.Text = ""
                                            lblmsg.Visible = True
                                            lblMsginfo.Visible = True
                                            lblmsg.Text = "Confirm password and new password not matching."
                                        End If
                                    Else
                                        lblMsginfo.Text = ""
                                        lblmsg.Text = ""
                                        txtNewPassword.Focus()
                                        lblMsginfo.Text = ""
                                        lblmsg.Visible = True
                                        lblMsginfo.Visible = True
                                        lblmsg.Text = "New Password should have min of 6 characters and maximum of 15 characters."
                                    End If
                                Else 'Advant 
                                    lblMsginfo.Text = ""
                                    lblmsg.Text = ""
                                    txtusername.Focus()
                                    txtusername.Text = ""
                                    lblmsg.Visible = True
                                    lblMsginfo.Visible = True
                                    lblmsg.Text = "Enter the correct username."
                                End If
                            Else
                                lblMsginfo.Text = ""
                                txtusername.Focus()
                                lblMsginfo.Text = ""
                                lblmsg.Visible = True
                                lblMsginfo.Visible = True
                                lblmsg.Text = "This user name does not exists."
                            End If
                        End If
                    ElseIf RblLoginType.SelectedValue = 2 Then
                        'Code For Parent/Student login By Nitin 27/06/2012 
                        If txtusername.Text = "" Then
                            lblMsginfo.Text = ""
                            lblmsg.Visible = True
                            lblMsginfo.Visible = True
                            lblmsg.Text = "Enter username."
                        Else
                            Dim str As String = txtusername.Text.Trim.ToLower
                            r.BranchCode = Session("BranchCode")
                            r.UserCode = txtusername.Text.Trim
                            Dim dt As New Data.DataTable
                            dt = blr.getParentuser(r)
                            If dt.Rows.Count > 0 Then
                                Dim str1 As String
                                str1 = dt.Rows(0).Item("UserName").ToString().ToLower
                                If str = str1 Then
                                    newp = Len(txtNewPassword.Text.Trim)
                                    If newp > 5 And newp < 16 Then
                                        If txtConfmPassword.Text.Trim = txtNewPassword.Text.Trim Then
                                            r.UserCode = txtusername.Text.Trim
                                            r.Password = RijndaelSimple.Encrypt(txtConfmPassword.Text.Trim,
                                                       RijndaelSimple.passPhrase,
                                                       RijndaelSimple.saltValue,
                                                       RijndaelSimple.hashAlgorithm,
                                                       RijndaelSimple.passwordIterations,
                                                       RijndaelSimple.initVector,
                                                       RijndaelSimple.keySize)
                                            blr.ResetParentpwd(r)
                                            lblMsginfo.Text = ""
                                            lblmsg.Text = ""
                                            txtConfmPassword.Text = ""
                                            txtNewPassword.Text = ""
                                            txtusername.Text = ""
                                            lblmsg.Visible = True
                                            lblMsginfo.Visible = True
                                            lblMsginfo.Text = "Reset password done successfully."
                                        Else
                                            lblMsginfo.Text = ""
                                            txtConfmPassword.Focus()
                                            lblMsginfo.Text = ""
                                            txtConfmPassword.Text = ""
                                            lblmsg.Visible = True
                                            lblMsginfo.Visible = True
                                            txtNewPassword.Text = ""
                                            lblmsg.Text = "Confirm password and new password not matching."
                                        End If
                                    Else
                                        lblMsginfo.Text = ""
                                        txtNewPassword.Focus()
                                        lblMsginfo.Text = ""
                                        lblmsg.Visible = True
                                        lblMsginfo.Visible = True
                                        lblmsg.Text = "New Password should have min of 6 characters and maximum of 15 characters."
                                    End If
                                Else 'Advant 
                                    lblMsginfo.Text = ""
                                    txtusername.Focus()
                                    txtusername.Focus()
                                    lblMsginfo.Text = ""
                                    txtusername.Text = ""
                                    lblmsg.Visible = True
                                    lblMsginfo.Visible = True
                                    lblmsg.Text = "Enter the correct username."
                                End If
                            Else
                                lblMsginfo.Text = ""
                                txtusername.Focus()
                                lblMsginfo.Text = ""
                                lblmsg.Visible = True
                                lblMsginfo.Visible = True
                                lblmsg.Text = "This user name does not exists."
                            End If
                        End If
                    ElseIf RblLoginType.SelectedValue = 3 Then
                        'Code For Changing spassword By Kusum 07/03/2013 
                        r.BranchCode = Session("BranchCode")
                        Dim dt As New Data.DataTable
                        newp = Len(txtNewPassword.Text.Trim)
                        If newp > 5 And newp < 16 Then
                            If txtConfmPassword.Text.Trim = txtNewPassword.Text.Trim Then
                                r.Password = RijndaelSimple.Encrypt(txtConfmPassword.Text.Trim,
                                           RijndaelSimple.passPhrase,
                                           RijndaelSimple.saltValue,
                                           RijndaelSimple.hashAlgorithm,
                                           RijndaelSimple.passwordIterations,
                                           RijndaelSimple.initVector,
                                           RijndaelSimple.keySize)
                                'If blr.ResetSParentpwd(r) > 0 Then
                                blr.ResetSParentpwd(r)
                                lblMsginfo.Text = ""
                                lblmsg.Text = ""
                                lblmsg.Text = ""
                                txtConfmPassword.Text = ""
                                txtNewPassword.Text = ""
                                txtusername.Text = ""
                                lblmsg.Visible = True
                                lblMsginfo.Visible = True
                                lblMsginfo.Text = "Reset password done successfully."
                                'Else
                                '    lblMsginfo.Text = ""
                                '    lblmsg.Text = ""
                                '    lblmsg.Visible = True
                                '    lblMsginfo.Visible = True
                                '    lblmsg.Text = "sPassword is not enabled, to enable sPassword please contact Advant Team."
                                'End If
                            Else
                                lblMsginfo.Text = ""
                                lblmsg.Text = ""
                                txtConfmPassword.Focus()
                                lblMsginfo.Text = ""
                                txtConfmPassword.Text = ""
                                txtNewPassword.Text = ""
                                lblmsg.Visible = True
                                lblMsginfo.Visible = True
                                lblmsg.Text = "Confirm password and new password not matching."
                            End If
                        Else
                            lblMsginfo.Text = ""
                            txtNewPassword.Focus()
                            lblMsginfo.Text = ""
                            lblmsg.Visible = True
                            lblMsginfo.Visible = True
                            lblmsg.Text = "New Password should have min of 6 characters and maximum of 15 characters."
                        End If
                    End If
                Else
                    lblMsginfo.Text = ""
                    lblmsg.Text = ""
                    lblMsginfo.Text = ""
                    lblmsg.Visible = True
                    lblMsginfo.Visible = True
                    lblmsg.Text = "No Write Permission!"
                End If
            Else
                lblMsginfo.Text = ""
                lblmsg.Visible = True
                lblMsginfo.Visible = True
                lblmsg.Text = "You do not belong to this branch, Cannot reset data."
            End If
        Else
            lblMsginfo.Text = ""
            txtNewPassword.Focus()
            lblMsginfo.Text = ""
            lblmsg.Visible = True
            lblMsginfo.Visible = True
            lblmsg.Text = "Reset password failed due to invalid password."
        End If
        validPass.Value = ""
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("Default2.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RblLoginType.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub

    Protected Sub RblLoginType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblLoginType.SelectedIndexChanged
        If RblLoginType.SelectedValue = 3 Then
            lblusrname.Visible = False
            txtusername.Visible = False
            lblnpw.Text = "New sPassword* :&nbsp;&nbsp;"
            Lblcpw.Text = "Confirm New sPassword* :&nbsp;&nbsp;"
            lblMsginfo.Text = ""
            lblmsg.Text = ""
        Else
            lblusrname.Visible = True
            txtusername.Visible = True
            lblnpw.Text = "New Password* :&nbsp;&nbsp;"
            Lblcpw.Text = "Confirm New Password* :&nbsp;&nbsp;"
            lblMsginfo.Text = ""
            lblmsg.Text = ""
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
