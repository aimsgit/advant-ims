
Partial Class frmDepreciation_Rates
    Inherits BasePage
    Dim ConfigProcManager As New ConfigProcManager
    Dim ConfigProcessP As New ConfigProcessP
    Dim GlobalFunction As New GlobalFunction
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If BtnSave.Text = "UPDATE" Then
            ConfigProcessP.ID = txtID.Text
            ConfigProcessP.TableID = cmbTableName.SelectedItem.Value
            ConfigProcessP.TableName = cmbTableName.SelectedItem.Text
            ConfigProcessP.AppReq = cmbApprovalReq.Text
            ConfigProcessP.AppBy = cmbAppBy.SelectedItem.Text
            ConfigProcManager.UpdateRecord(ConfigProcessP)
            ConfigProcManager.UpdateTable(ConfigProcessP)
            BtnSave.Text = "SAVE"
            BtnDetails.Text = "DETAILS"
            clear()
            GridView1.DataBind()
            Enable()
            GridView1.Visible = True
            lblmsg.Text = "Data Updated Successfully."
        ElseIf BtnSave.Text = "SAVE" Then
            ConfigProcessP.TableID = cmbTableName.SelectedItem.Value
            ConfigProcessP.TableName = cmbTableName.SelectedItem.Text
            ConfigProcessP.AppReq = cmbApprovalReq.Text
            ConfigProcessP.AppBy = cmbAppBy.SelectedItem.Text
            ConfigProcManager.InsertRecord(ConfigProcessP)
            ConfigProcManager.UpdateTable(ConfigProcessP)
            BtnSave.Text = "SAVE"
            GridView1.DataBind()
            GridView1.Visible = True
            lblmsg.Text = "Data Saved Successfully."
            clear()
        End If
    End Sub

    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        ' GridView1.DataSourceID = "ObjectDataSource1"
        If BtnDetails.Text <> "CANCEL" Then
            'Dim CategoryManager As New CategoryManager
            Dim dt As New DataTable
            dt = ConfigProcManager.GetConfigProc.Tables(0)
            GridView1.DataSource = dt
            GridView1.DataBind()
        Else
            clear()
            Enable()
            BtnDetails.Text = "DETAILS"
            BtnSave.Text = "SAVE"
        End If
    End Sub
    'kusum commented it.
    '---------------------------
    'Protected Sub BtnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReport.Click
    '    ' Dim DAL As New DesignationManager
    '    Dim dtM As New Data.DataTable
    '    dtM = ConfigProcManager.GetConfigProc.Tables(0)
    '    If dtM.Rows.Count <> 0 Then
    '        'Response.Redirect("rptConfigurationProcessV.aspx")
    '        Dim qrystring As String = "rptConfigurationProcessV.aspx?" & QueryStr.Querystring()
    '        ClientScript.RegisterStartupScript(Me.GetType, "Startup", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80') </script>")

    '    Else
    '        lblmsg.Text = "No Records to Display"
    '    End If
    'End Sub
    '------------------------------
    Protected Sub BtnRecover_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRecover.Click

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        'Dim Depreciation_Rates As New Depreciation_Rates
        ConfigProcManager.ChangeFlag(CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("Label5"), Label).Text)
        GridView1.DataBind()
        lblmsg.Text = "Data Deleted Successfully."
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

        txtID.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        cmbTableName.SelectedItem.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        cmbApprovalReq.SelectedItem.Value = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        cmbAppBy.SelectedItem.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text

        BtnSave.Text = "UPDATE"

        e.Cancel = True
        Disable()
        BtnDetails.Text = "CANCEL"
        BtnDetails.Visible = True
    End Sub
    Sub Enable()
        GridView1.Enabled = True
        BtnDetails.Visible = True
        BtnRecover.Visible = True
        'kusum commented it. BtnReport.Visible = True
    End Sub
    Sub Disable()
        GridView1.Enabled = False
        BtnDetails.Visible = False
        BtnRecover.Visible = False
        'kusum commented it. BtnReport.Visible = False
    End Sub
    Sub clear()
        txtID.Text = ""

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblmsg.Text = ""
        msginfo.Text = ""
        If Not IsPostBack Then
            cmbTableName.DataSource = ConfigProcManager.GetTableName
            cmbTableName.DataValueField = "id"
            cmbTableName.DataTextField = "TableName"
            cmbTableName.DataBind()
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
