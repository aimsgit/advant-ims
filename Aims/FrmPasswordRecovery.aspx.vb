
Partial Class FrmPasswordRecovery
    Inherits BasePage
    Dim decrtptpassword As String
    Dim password As String

    Protected Sub btnRecovery_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecovery.Click
        password = txtpassword.Text
        decrtptpassword = RijndaelSimple.Decrypt(password, _
                                           RijndaelSimple.passPhrase, _
                                           RijndaelSimple.saltValue, _
                                           RijndaelSimple.hashAlgorithm, _
                                           RijndaelSimple.passwordIterations, _
                                           RijndaelSimple.initVector, _
                                           RijndaelSimple.keySize)
        lblErrorMsg.Text = decrtptpassword

    End Sub
End Class
