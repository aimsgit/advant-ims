
Partial Class AddEvent
    Inherits BasePage
    Dim idd As Integer
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ' Me.SqlDataSource1.ConnectionString = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        'Me.SqlDataSource1.ProviderName = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ProviderName
        ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & FormView1.FindControl("txtname").ClientID & "').focus();</script>")

    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        GridView1.EditIndex = CInt(e.NewEditIndex)
        Dim id As HiddenField = CType(GridView1.Rows(GridView1.EditIndex).Cells(0).FindControl("DID"), HiddenField)
        ' Me.SqlDataSource1.SelectCommand = "Select * from DiaryEvent where DiaryId=" + id.Value + ""

        idd = id.Value
        odsEvent.SelectMethod = "GetDiaryEvent"
        odsEvent.SelectParameters.Clear()
        odsEvent.SelectParameters.Add("id", idd)
        FormView1.DataBind()
        FormView1.ChangeMode(FormViewMode.Edit)
        GridView1.Enabled = False

    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Diary")
    End Sub

    Sub CancelEdit(ByVal sender As Object, ByVal e As System.EventArgs)
        'SqlDataSource1.SelectParameters.Clear()
        Dim idd As Integer = 0
        ' SqlDataSource1.SelectParameters.Add("id", idd)
        GridView1.DataBind()
        GridView1.Enabled = True
    End Sub

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        GridView1.Enabled = True
        odsEvent.SelectParameters.Clear()
        odsEvent.SelectParameters.Add("id", 0)
        GridView1.Enabled = True
        GridView1.DataBind()
    End Sub
    Sub ShowDetails(ByVal sender As Object, ByVal e As System.EventArgs)
        GridView1.DataSourceID = "odsEvent"
        GridView1.DataBind()
        'Me.gvCourseDetails.Visible = True
        ' Panel1.Visible = True
        ' view(sender, e)
    End Sub
    <System.Web.Services.WebMethod()> _
        Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
