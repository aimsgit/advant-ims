
Partial Class DiaryMain
    Inherits BasePage
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        'Me.SqlDataSource1.ProviderName = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ProviderName
        'Me.SqlDataSource2.ConnectionString = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        'Me.SqlDataSource2.ProviderName = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ProviderName
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit

    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
