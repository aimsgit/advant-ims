Partial Class ChangePassword
    Inherits BasePage

    Protected Sub btnCreate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        If Not Page.IsValid Then Exit Sub

        Dim currentUserInfo As MembershipUser = Membership.GetUser()
        If Me.txtConfmPassword.Text.Trim = Me.txtNewPassword.Text.Trim Then

            Dim success As Boolean = currentUserInfo.ChangePassword(Me.txtOldPassword.Text.Trim, Me.txtConfmPassword.Text.Trim)

            If success Then
                'Show the success Panel
                lblResults.Text = "Password changed successfully."
            Else
                'Invalid password
                lblResults.Text = "Your password is incorrect. Please try again."
            End If
        Else
            lblResults.Text = "Your passwords are not matching. Please try again."
        End If
    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Response.Redirect("Default2.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
