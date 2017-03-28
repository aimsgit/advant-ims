
Partial Class frmchangepassword
    Inherits BasePage
    Dim c As New changepassword
    Dim blc As New BLchangepassword
    Dim GlobalFunction As New GlobalFunction
    Dim a As Integer
    Dim newp As Integer
    Protected Sub btnChangePassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                If Session("LoginType") = "Employee" Then
                    Dim str As String = txtOldPassword.Text.Trim
                    c.BranchCode = Session("BranchCode")
                    c.UserDetailsID = Session("UserID")
                    Dim dt As New Data.DataTable
                    dt = blc.getRecord(c)
                    Dim str1 As String
                    str1 = RijndaelSimple.Decrypt(dt.Rows(0).Item("Password").ToString(), _
                                               RijndaelSimple.passPhrase, _
                                               RijndaelSimple.saltValue, _
                                               RijndaelSimple.hashAlgorithm, _
                                               RijndaelSimple.passwordIterations, _
                                               RijndaelSimple.initVector, _
                                               RijndaelSimple.keySize)
                    If str = str1 Then
                        newp = Len(txtNewPassword.Text.Trim)
                        If newp > 5 And newp < 16 Then
                            If txtConfmPassword.Text.Trim = txtNewPassword.Text.Trim Then
                                c.BranchCode = Session("BranchCode")
                                c.UserDetailsID = Session("UserID")
                                c.Password = RijndaelSimple.Encrypt(txtConfmPassword.Text.Trim, _
                                               RijndaelSimple.passPhrase, _
                                               RijndaelSimple.saltValue, _
                                               RijndaelSimple.hashAlgorithm, _
                                               RijndaelSimple.passwordIterations, _
                                               RijndaelSimple.initVector, _
                                               RijndaelSimple.keySize)
                                blc.UpdateRecord(c)
                                lblmsg.Text = ""
                                lblgreen.Text = "Your password has been changed."
                                txtConfmPassword.Text = ""
                                txtNewPassword.Text = ""
                                txtOldPassword.Text = ""
                            Else
                                lblmsg.Text = "new password and Confirm password should be same."
                                txtNewPassword.Focus()
                                lblgreen.Text = ""
                                txtConfmPassword.Text = ""
                                txtNewPassword.Text = ""
                            End If
                        Else
                            lblgreen.Text = ""
                            lblmsg.Text = "New Password should be min of 6 characters and max of 15 characters."
                        End If
                    Else 'Advant 
                        lblgreen.Text = ""
                        lblmsg.Text = "Please enter the correct password."
                        txtOldPassword.Focus()
                        txtOldPassword.Text = ""
                    End If
                Else
                    Dim str As String = txtOldPassword.Text.Trim
                    c.BranchCode = Session("BranchCode")
                    c.UserDetailsID = Session("UserID")
                    c.UserName = Session("UserName")
                    Dim dt As New Data.DataTable
                    dt = blc.getParentRecord(c)
                    Dim str1 As String
                    str1 = RijndaelSimple.Decrypt(dt.Rows(0).Item("Password").ToString(), _
                                               RijndaelSimple.passPhrase, _
                                               RijndaelSimple.saltValue, _
                                               RijndaelSimple.hashAlgorithm, _
                                               RijndaelSimple.passwordIterations, _
                                               RijndaelSimple.initVector, _
                                               RijndaelSimple.keySize)
                    If str = str1 Then
                        newp = Len(txtNewPassword.Text.Trim)
                        If newp > 5 And newp < 16 Then
                            If txtConfmPassword.Text.Trim = txtNewPassword.Text.Trim Then
                                c.BranchCode = Session("BranchCode")
                                c.UserDetailsID = Session("UserID")
                                c.UserName = Session("UserName")
                                c.Password = RijndaelSimple.Encrypt(txtConfmPassword.Text.Trim, _
                                               RijndaelSimple.passPhrase, _
                                               RijndaelSimple.saltValue, _
                                               RijndaelSimple.hashAlgorithm, _
                                               RijndaelSimple.passwordIterations, _
                                               RijndaelSimple.initVector, _
                                               RijndaelSimple.keySize)
                                blc.UpdateParentRecord(c)
                                lblmsg.Text = ""
                                lblgreen.Text = "Your password has been changed."
                                txtOldPassword.Focus()
                                txtConfmPassword.Text = ""
                                txtNewPassword.Text = ""
                                txtOldPassword.Text = ""
                            Else
                                lblmsg.Text = "new password and Confirm password should be same."
                                txtNewPassword.Focus()
                                lblgreen.Text = ""
                                txtConfmPassword.Text = ""
                                txtNewPassword.Text = ""
                            End If
                        Else
                            lblgreen.Text = ""
                            lblmsg.Text = "New Password should be min of 6 characters and max of 15 characters."
                        End If
                    Else 'Advant 
                        lblgreen.Text = ""
                        lblmsg.Text = "Please enter the correct password."
                        txtOldPassword.Focus()
                        txtOldPassword.Text = ""
                    End If
                End If
            Else
                lblgreen.Text = ""
                lblmsg.Text = "No Write Permission!"
            End If
        Else
            lblmsg.Text = "You do not belong to this branch, Cannot save data."
            lblgreen.Text = ""
        End If

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("Default2.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtOldPassword.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
