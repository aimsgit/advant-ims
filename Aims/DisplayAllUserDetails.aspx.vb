
Partial Class DisplayAllUserDetails
    Inherits BasePage

   

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim ds As DataSet
        'ds = UserDetailsDB.GetAllUsers
        'If ds.Tables(0).Rows.Count > 0 Then
        '    GridView1.DataSource = ds.Tables(0).DefaultView
        '    GridView1.DataBind()

        'End If
    End Sub
    <System.Web.Services.WebMethod()> _
        Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
   
End Class
