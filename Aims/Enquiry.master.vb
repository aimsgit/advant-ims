
Partial Class Enquiry
    Inherits System.Web.UI.MasterPage
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        dt = DLLogin.GetImage()
        Dim rndNumber As New Random()
        If (dt.Rows.Count > 0) Then
            HeaderPanel.BackImageUrl = dt.Rows(0).Item(0)
        End If
    End Sub

    Protected Sub LinkButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        Session.Clear()
        Session("UserName") = ""
        Session.Abandon()
        Response.CacheControl = "no-cache"
        Response.AddHeader("Pragma", "no-cache")
        Response.Expires = -1
        Response.Buffer = True
        Response.ExpiresAbsolute = Now()
        Response.Expires = 0
        Response.CacheControl = "no-cache"
        FormsAuthentication.SignOut()
        Roles.DeleteCookie()
        FormsAuthentication.RedirectToLoginPage()
    End Sub
End Class

