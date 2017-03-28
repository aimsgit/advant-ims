
Partial Class DayView
    Inherits BasePage
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        'Me.SqlDataSource1.ProviderName = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ProviderName
        Page.RegisterStartupScript("SetInitialFocus", "<script> document.getElementById('" & FormView1.FindControl("entryTitleTextBox").ClientID & "').focus();</script>")
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Diary")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
