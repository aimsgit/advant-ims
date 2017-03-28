Partial Class frmCompany
    Inherits BasePage
    Dim alt As String
    Dim idd As Integer

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Try
            Dim id As HiddenField = CType(GridView1.Rows(e.RowIndex).Cells(2).FindControl("RID"), HiddenField)
            Dim Status As Boolean
            Status = globalcnn.Del_Validation(id.Value, "Company")
            If (Status) = True Then
                lblErrorMsg.Text = "Record already used"
                e.Cancel = True
            Else
                lblErrorMsg.Text = "Data deleted successfully"
            End If
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        Me.Objcompany.SelectParameters.Clear()
        GridView1.EditIndex = CInt(e.NewEditIndex)
        Dim idedit As Integer = GridView1.EditIndex
        Dim id As HiddenField = CType(GridView1.Rows(GridView1.EditIndex).Cells(0).FindControl("RID"), HiddenField)
        idd = id.Value
        Objcompany.SelectParameters.Add("Id", idd)
        Me.FormView1.DataBind()
        Me.FormView1.ChangeMode(FormViewMode.Edit)
        GridView1.Enabled = False
        GridView1.Columns(1).Visible = False
    End Sub
    Protected Sub FormView1_ItemInserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewInsertedEventArgs) Handles FormView1.ItemInserted
        GridView1.DataBind()
    End Sub

    Protected Sub FormView1_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles FormView1.ItemUpdated
        Objcompany.SelectParameters.Clear()
        idd = 0
        Objcompany.SelectParameters.Add("id", idd)
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Columns(1).Visible = True
    End Sub
    Sub cancel1(ByVal sender As Object, ByVal e As System.EventArgs)
        Objcompany.SelectParameters.Clear()
        idd = 0
        Objcompany.SelectParameters.Add("id", idd)
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Columns(1).Visible = True
    End Sub
    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        GridView1.DataSourceID = "Objcompany"
        GridView1.DataBind()
    End Sub
    Protected Sub btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim CM As New CompanyManager
        If CM.GetCompany.Count() <> 0 Then

            'Updated by sendhil-Abishek Type:Formview-UP
            Dim qrystring As String = "rptCompanyViewer.aspx?" & QueryStr.Querystring()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Else
            lblErrorMsg.Text = "No Record to display"
        End If
    End Sub
    Protected Sub btnrecover_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("RecoverForm") = "Company"
        Response.Redirect("Recover.aspx")
    End Sub
    Sub FormviewItemInserted(ByVal sender As Object, ByVal e As FormViewInsertedEventArgs)
        'If Not e.Exception Is Nothing Then
        '    alt = "<script language='javascript'>" + "alert('No Duplicate Entries!');" + "</script>"
        '    ClientScript.RegisterStartupScript(Me.GetType(), "alert", alt)
        '    e.ExceptionHandled = True
        'Else
        lblErrorMsg.Text = "Data saved successfully"
        ' End If
    End Sub

    Sub FormviewItemUpdated(ByVal sender As Object, ByVal e As FormViewUpdatedEventArgs)
        If Not e.Exception Is Nothing Then
            alt = "<script language='javascript'>" + "alert('No Duplicate Entries!');" + "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", alt)
            e.ExceptionHandled = True
        Else
            lblErrorMsg.Text = " Data updated successfully"
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.lblErrorMsg.Text = ""
        ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & FormView1.FindControl("NameTextBox").ClientID & "').focus();</script>")
        ClientScript.RegisterHiddenField("_EVENTTARGET", "btnSave")
    End Sub
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs)

    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Company Details")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
