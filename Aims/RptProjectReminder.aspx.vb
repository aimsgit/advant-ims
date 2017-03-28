
Partial Class RptProjectReminder
    Inherits BasePage

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Dim BN As String = Session("Msg")
        lblProgramStatus.Text = BN.ToString
    End Sub


   
End Class
