
Partial Class FrmLogOut
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
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

        'FormsAuthentication.RedirectToLoginPage()

    End Sub
End Class
