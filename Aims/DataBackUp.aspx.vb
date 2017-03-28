Imports System.Data
Imports System.IO
Imports System.Data.OleDb
Partial Class DataBackUp
    Inherits BasePage
    Dim BLL As New ConfigurationB
    Dim CF As New EntConfiguration
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtDate.Focus()
        lblErrorMsg.Text = ""
        ObjConfig.DataBind()
        If Not IsPostBack Then
        End If
    End Sub

    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        CF.Date_Value = txtDate.Text
        CF.Config_Name = txtName.Text
        CF.Config_ID = txtid.Text
        If txtid.Text = 1 Then
            Session("FinStartDate") = txtDate.Text
        ElseIf txtid.Text = 2 Then
            Session("FinEndDate") = txtDate.Text
        End If
        BLL.UpdateRecord(CF)
        lblErrorMsg.Text = "Data Updated Sucessfully"
        Me.btnEdit.Visible = False
        btnDetails.Text = "DETAILS"
        Me.GVConfig.DataSourceID = "ObjConfig"
        GVConfig.DataBind()
        txtid.Text = 0
        txtName.Text = ""
        txtDate.Text = ""
        Me.GVConfig.Enabled = True
    End Sub
    Protected Sub btnDtls_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If btnDetails.Text = "DETAILS" Then
            Me.GVConfig.DataSourceID = "ObjConfig"
            GVConfig.DataBind()
        Else
            txtid.Text = 0
            txtName.Text = ""
            txtDate.Text = ""
            btnEdit.Visible = False
            btnDetails.Text = "DETAILS"
        End If
        Me.GVConfig.Enabled = True
    End Sub

    Protected Sub GVConfig_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVConfig.RowEditing
        Me.txtid.Text = CType(Me.GVConfig.Rows(e.NewEditIndex).FindControl("config_Id"), HiddenField).Value
        Me.txtName.Text = CType(Me.GVConfig.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        Me.txtDate.Text = CType(Me.GVConfig.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        Me.GVConfig.Enabled = False
        Me.btnDetails.Text = "CANCEL"
        Me.btnEdit.Visible = True
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
