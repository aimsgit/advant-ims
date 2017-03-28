
Partial Class frmInstitute
    Inherits BasePage
    Dim alt As String
    Dim idd As Integer
   
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim Contactno As TextBox = CType(fvInstituteDetails.FindControl("txtcontactno"), TextBox)
        'Contactno.Attributes.Add("onKeypress", "javascript:return IsNumber(event);")
        Dim txtName As TextBox = CType(fvInstituteDetails.FindControl("txtName"), TextBox)
        txtName.Focus()
        'If Not IsPostBack Then
        '    Panel1.Visible = False
        'End If
        'ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & fvInstituteDetails.FindControl("txtName").ClientID & "').focus();</script>")
        lblErrorMsg.Text = ""
    End Sub
    Sub Report(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            'If gvInstituteDetails.Rows.Count = 0 Then
            '    lblErrorMsg.Text = "No Records to Display"
            'Else
            Dim qrystring As String = "RptInstituteV.aspx?" & QueryStr.Querystring()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            'End If
        Catch
            lblErrorMsg.Text = "Error Found in Report"
        End Try
    End Sub
    Sub Recover(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Session("RecoverForm") = "frmInstitute"
            Response.Redirect("recover.aspx")
            lblErrorMsg.Text = "Data Recovered Sucessfully"
        Catch
            lblErrorMsg.Text = "Error Found in Recover Operation"
        End Try
    End Sub

    Protected Sub gvInstituteDetails_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvInstituteDetails.RowCancelingEdit
        fvInstituteDetails.Enabled = True
        gvInstituteDetails.Columns(0).Visible = True
    End Sub
    Protected Sub gvInstituteDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvInstituteDetails.RowDeleting
        Try
            Dim id As HiddenField = CType(gvInstituteDetails.Rows(e.RowIndex).Cells(2).FindControl("IID"), HiddenField)
            Dim Status As Boolean
            Status = globalcnn.Del_Validation(id.Value, "Institute")
            If (Status) = True Then
                lblErrorMsg.Text = "Record is already used."
                'alt = "<script language='javascript'>" + "alert('Record is already used.');" + "</script>"
                'ClientScript.RegisterStartupScript(Me.GetType, "alert", alt)
                e.Cancel = True
            Else
                lblErrorMsg.Text = "Data Deleted Successfully."
            End If
        Catch
            lblErrorMsg.Text = "Error Found in Delete Operation"
        End Try
    End Sub
    Protected Sub gvInstituteDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvInstituteDetails.RowEditing
        Me.odsInstitute.SelectParameters.Clear()
        gvInstituteDetails.EditIndex = CInt(e.NewEditIndex)
        Dim idedit As Integer = gvInstituteDetails.EditIndex
        Dim id As HiddenField = CType(gvInstituteDetails.Rows(gvInstituteDetails.EditIndex).Cells(0).FindControl("IID"), HiddenField)
        idd = id.Value
        odsInstitute.SelectParameters.Add("id", idd)
        fvInstituteDetails.DataBind()
        fvInstituteDetails.ChangeMode(FormViewMode.Edit)
        gvInstituteDetails.Columns(0).Visible = False
        gvInstituteDetails.Enabled = False
    End Sub
    Protected Sub fvInstituteDetails_ItemUpdated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewUpdatedEventArgs) Handles fvInstituteDetails.ItemUpdated
        Try
            odsInstitute.SelectParameters.Clear()
            idd = 0
            odsInstitute.SelectParameters.Add("id", idd)
            gvInstituteDetails.DataBind()
            gvInstituteDetails.Enabled = True
            gvInstituteDetails.Columns(0).Visible = True
            lblErrorMsg.Text = "Data Updated Successfully."
        Catch
            lblErrorMsg.Text = "Error Found in Update Operation"
        End Try
        gvInstituteDetails.Visible = False
        'Panel1.Visible = False
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Panel1.Visible = True
        gvInstituteDetails.DataSourceID = "odsInstitute"
        gvInstituteDetails.DataBind()
        gvInstituteDetails.Visible = True
    End Sub
    Sub FormviewItemInserted(ByVal sender As Object, ByVal e As FormViewInsertedEventArgs)
        Try
            If Not e.Exception Is Nothing Then
                'Me.lblmsg.Text = "Duplicate Values!"
                'alt = "<script language='javascript'>" + "alert('No Duplicate Entries!');" + "</script>"
                'ClientScript.RegisterStartupScript(Me.GetType(), "alert", alt)
                e.ExceptionHandled = True
            End If
            lblErrorMsg.Text = "Data Saved Successfully."
        Catch
            lblErrorMsg.Text = "Error Found in Save Operation."
        End Try
    End Sub
    Sub FormviewItemUpdated(ByVal sender As Object, ByVal e As FormViewUpdatedEventArgs)
        If Not e.Exception Is Nothing Then
            'Me.lblmsg.Text = "Duplicate Values!"
            'alt = "<script language='javascript'>" + "alert('No Duplicate Entries!');" + "</script>"
            'ClientScript.RegisterStartupScript(Me.GetType(), "alert", alt)
            e.ExceptionHandled = True
        End If
    End Sub
    Sub viewGridview(ByVal sender As Object, ByVal e As System.EventArgs)
        odsInstitute.SelectParameters.Clear()
        idd = 0
        odsInstitute.SelectParameters.Add("id", idd)
        gvInstituteDetails.DataBind()
        Me.gvInstituteDetails.Enabled = True
        gvInstituteDetails.Columns(0).Visible = True
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        gvInstituteDetails.Enabled = True
        gvInstituteDetails.DataBind()
        gvInstituteDetails.Columns(1).Visible = True
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Institute Details")
    End Sub
End Class
