
Partial Class AddContact
    Inherits BasePage
    Dim idd As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Page.RegisterStartupScript("SetInitialFocus", "<script>document.getElementbyId('" & FormView1.ClientID & "').focus;</script>")
        If Not IsPostBack Then
        End If
        'Me.SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        'Me.SqlDataSource1.ProviderName = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ProviderName

        ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & FormView1.FindControl("txtFirst").ClientID & "').focus();</script>")

    End Sub

    

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = CInt(e.NewEditIndex)
        Dim id As HiddenField = CType(GridView1.Rows(GridView1.EditIndex).Cells(0).FindControl("CID"), HiddenField)
        'Me.SqlDataSource1.SelectCommand = "Select * from ContactDetails where ContactId=" + id.Value + ""
        idd = id.Value
        odsContact.SelectMethod = "GetContact"
        odsContact.SelectParameters.Add("id", idd)
        FormView1.DataBind()
        FormView1.ChangeMode(FormViewMode.Edit)
        GridView1.Enabled = False
    End Sub

    
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Diary")
    End Sub

  
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        'Dim a As TextBox = CType(FormView1.Row.Cells(0).FindControl("txtFirst"), TextBox)
        'Page.RegisterStartupScript("SetInitialFocus", "<script>document.getElementbyId('" & a.ClientID & "').focus;</script>")
        'a.Attributes.Add("onkeydown", "if(event.which || event.keyCode)" & "{if ((event.which == 9) || (event.keyCode == 9)) " & "{document.getElementById('" & a.ClientID & "').focus();return false;}} else {return true}; ")

    End Sub

    Protected Sub GridView1_RowUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdatedEventArgs) Handles GridView1.RowUpdated

    End Sub

    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        GridView1.Enabled = True
        GridView1.DataBind()
    End Sub

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        GridView1.Enabled = True
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
