
Partial Class AddTech
    Inherits BasePage

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        lblErrorMsg.Text = ""
        Lblmsg.Text = ""
        If (txtuser.Text.Length = 0) Then
            lblErrorMsg.Text = "Enter Username"
            txtuser.Focus()
            Exit Sub
        End If
        If (txtpass.Text.Length = 0) Then
            lblErrorMsg.Text = "Enter Password"
            txtpass.Focus()
            Exit Sub
        End If
        If (txtrepass.Text.Length = 0) Then
            lblErrorMsg.Text = "Enter Re-Type Password"
            txtrepass.Focus()
            Exit Sub
        End If
        If String.Compare(txtpass.Text, txtrepass.Text) <> 0 Then
            lblErrorMsg.Text = "Enter Correct Re-Type Password"
            txtrepass.Focus()
            Exit Sub
        End If
        Dim password As String = RijndaelSimple.Encrypt(txtpass.Text, _
                                           RijndaelSimple.passPhrase, _
                                           RijndaelSimple.saltValue, _
                                           RijndaelSimple.hashAlgorithm, _
                                           RijndaelSimple.passwordIterations, _
                                           RijndaelSimple.initVector, _
                                           RijndaelSimple.keySize)
        DLDefault.AddTech(txtuser.Text, password)
        lblErrorMsg.Text = ""
        Lblmsg.Text = "Data Added Sucessfully."
        txtpass.Text = ""
        txtrepass.Text = ""
        txtuser.Text = ""

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

    End Sub
End Class
