
Partial Class AccessDenied
    Inherits BasePage

    Protected Sub LinkButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        Response.Redirect("Default.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
     Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
