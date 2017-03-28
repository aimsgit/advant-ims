
Partial Class frmZone
    Inherits BasePage
    Dim alt As String
    Dim idd As Integer
    Dim BLL As New ZoneB
    Dim Prop As New Zone
   
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        'Dim MT As New MaintenanceTypeManager
        'If MT.GetMaintenanceType().Count() <> 0 Then
        '    Dim qrystring As String = "rptMaintenanceTypeViewer.aspx?" & QueryStr.Querystring()
        '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        'Else
        '    Me.lblmsg.Text = "No Record to display"
        'End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblmsg.Text = ""
        ClientScript.RegisterHiddenField("_EVENTTARGET", "btnSave")
        If Not IsPostBack Then
            cmbHO.DataSource = BLL.FillHO()
            cmbHO.DataBind()
            If cmbHO.Items.Count > 0 Then
                cmbHO.SelectedIndex = 0
            End If
        End If
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Maintenance Type")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If btnSave.Text = "UPDATE" Then
            BLL.Update(hfID.Value, txtZone.Text)
            Update()
            BindData()
            lblmsg.Text = "Data updated sucessfully"
        Else

            If txtZone.Text = "" Then
                msginfo.Text = "Please Enter Zone"
            Else
                BLL.Insert(cmbHO.SelectedItem.Value, txtZone.Text)
                lblmsg.Text = "Data saved successfully"
            End If
        End If
        txtZone.Text = ""
    End Sub

    Protected Sub btnDetails_Click1(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        msginfo.Visible = False
        If btnDetails.Text = "CANCEL" Then
            Update()
        Else
            BindData()
        End If
    End Sub
    Sub Update()
        btnDetails.Text = "DETAILS"
        btnSave.Text = "SAVE"
        cmbHO.Enabled = True
        gvZoneMaster.Enabled = True
    End Sub
    Sub BindData()
        gvZoneMaster.DataSource = BLL.getZoneDetails(cmbHO.SelectedItem.Value)
        gvZoneMaster.DataBind()
    End Sub

    Protected Sub gvZoneMaster_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvZoneMaster.PageIndexChanging
        gvZoneMaster.PageIndex = e.NewPageIndex
        BindData()
    End Sub

    Protected Sub gvZoneMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvZoneMaster.RowDeleting
        BLL.Delete(gvZoneMaster.DataKeys(e.RowIndex).Value)
        BindData()
        lblmsg.Text = "Data deleted sucessfully"
    End Sub

    Protected Sub gvZoneMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvZoneMaster.RowEditing
        gvZoneMaster.Enabled = False
        btnSave.Text = "UPDATE"
        btnDetails.Text = "CANCEL"
        cmbHO.Enabled = False
        hfID.Value = gvZoneMaster.DataKeys(e.NewEditIndex).Value
        hfHOid.Value = CType(gvZoneMaster.Rows(e.NewEditIndex).Cells(2).FindControl("HOID"), HiddenField).Value
        cmbHO.SelectedItem.Value = CType(gvZoneMaster.Rows(e.NewEditIndex).Cells(2).FindControl("HOID"), HiddenField).Value
        txtZone.Text = CType(gvZoneMaster.Rows(e.NewEditIndex).Cells(2).FindControl("Label1"), Label).Text
    End Sub
End Class
