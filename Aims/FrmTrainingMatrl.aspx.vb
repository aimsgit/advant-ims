
Partial Class FrmTrainingMatrl
    Inherits BasePage
    Dim Sql As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'new_dbconn1.ConnectionString = Application("Strcontent")
        'new_dbconn1.Open()
        If HttpContext.Current.Session("InstituteID") = "" Or HttpContext.Current.Session("BranchID") = "" Then
            Response.Redirect("BranchAndInstitute.aspx")
        End If
        'Me.SqlAssetType.ConnectionString = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        ' Me.SqlAssetType.ProviderName = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ProviderName

        'Me.CmbSuppSql.ConnectionString = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        'Me.CmbSuppSql.ProviderName = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ProviderName

        'Me.cmbManuSql.ConnectionString = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        'Me.cmbManuSql.ProviderName = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ProviderName

        If Session("editstatus") = "Edit" Then
            Session("editstatus") = "Add"
            Dim AssetId As Integer
            AssetId = Session("AssetDet_Id")
            Me.odsInsert.SelectParameters.Clear()
            Me.odsInsert.SelectParameters.Add("AssetDet_Id", AssetId)
            Me.FormView1.ChangeMode(FormViewMode.Edit)
            FormView1.DataBind()
        End If

        If CType(FormView1.FindControl("cmbAsset"), DropDownList).Items.Count > 0 Then
            CType(FormView1.FindControl("hndAsset_Id"), HiddenField).Value = CType(FormView1.FindControl("cmbAsset"), DropDownList).SelectedItem.Value
        End If



        'FormView1.FindControl("ddlInstitute").Focus()
        'ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & FormView1.FindControl("ddlInstitute").ClientID & "').focus();</script>")
        'ClientScript.RegisterHiddenField("_EVENTTARGET", "btnSave")

        Disable()
    End Sub

    Sub Recover(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("RecoverForm") = "AssetDetails"
        Response.Redirect("recover.aspx")
    End Sub

    Sub Fill_Combo(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Branch As DropDownList = CType(FormView1.FindControl("cmbbranch"), DropDownList)
    End Sub

    Sub Preview(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim qrystring As String = "RptAssetDetailsV.aspx?" & QueryStr.Querystring()
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub

    Sub Details(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("FrmTrainingMatrlView.aspx")
    End Sub


    'Sub update(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim da As New OleDbDataAdapter
    '    Dim dt As New DataTable
    '    Dim assetid = Session("Asset_Id")
    '    Dim sql, sql1 As String
    '    sql = "SELECT Asset_Id from AssetDetails where Asset_Id='assetid' and Transfer_Flag= -1"
    '    da = New OleDbDataAdapter(sql, new_dbconn1)
    '    dt.Clear()
    '    da.Fill(dt)
    '    If dt.Rows.Count > 0 Then
    '        sql1 = "UPDATE AssetTransfer set Quantity=?, TransferDate=?, EntryDate=? where Target_Id='assetid'"
    '    End If
    'End Sub

    Protected Sub odsInsert_Inserted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs) Handles odsInsert.Inserted
        Dim DT As New DataTable
        Dim BAL As New AssetDetailsB
        'DT = BAL.GetMaxAssetDetls
        Dim id As Integer = DT.Rows(0)("AssetDet_Id")
        'Dim id As Integer = e.ReturnValue
        If Me.HfAssettype.Value = 2 Then
            Response.Redirect("frmBookMaster.aspx?id=" & id)
        End If
    End Sub

    'Protected Sub odsInsert_Inserting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.ObjectDataSourceMethodEventArgs) Handles odsInsert.Inserting
    '    Dim AssetType As DropDownList = CType(FormView1.FindControl("ddlAsstType"), DropDownList)
    '    Me.HfAssettype.Value = AssetType.SelectedValue.ToString
    '    Dim Quantity As TextBox = CType(FormView1.FindControl("txtQty"), TextBox)
    '    Me.HFQuantity.Value = Quantity.Text
    '    ' odsInsert.InsertParameters.Item("EntryDate").DefaultValue = Today.Date
    '    'e.InputParameters.Item("EntryDate") = Today.Date
    '    Dim Price As TextBox = CType(FormView1.FindControl("txtPrice"), TextBox)
    '    Dim TotVal As String
    '    TotVal = (Quantity.Text * Price.Text)
    '    Dim txttotalval As TextBox = CType(FormView1.FindControl("txttotalval"), TextBox)
    '    txttotalval.Text = TotVal
    '    'odsInsert.InsertParameters.Item("TotalVal").DefaultValue = TotVal
    '    'e.InputParameters.Item("TotalVal") = TotVal
    'End Sub

    Public Sub btnSave_click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim AssetType As DropDownList = CType(FormView1.FindControl("ddlAsstType"), DropDownList)
        Me.HfAssettype.Value = AssetType.SelectedValue.ToString
        Dim Quantity As TextBox = CType(FormView1.FindControl("txtQty"), TextBox)
        Me.HFQuantity.Value = Quantity.Text
        Dim Price As TextBox = CType(FormView1.FindControl("txtPrice"), TextBox)
        Dim TotVal As String
        TotVal = (Quantity.Text * Price.Text)
        Dim txttotalval As TextBox = CType(FormView1.FindControl("txttotalval"), TextBox)
        txttotalval.Text = TotVal
    End Sub
    Public Sub btnupdate_click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Quantity As TextBox = CType(FormView1.FindControl("txtQty"), TextBox)
        Me.HFQuantity.Value = Quantity.Text
        Dim Price As TextBox = CType(FormView1.FindControl("txtPrice"), TextBox)
        Dim TotVal As String
        TotVal = (Quantity.Text * Price.Text)
        Dim txttotalval As TextBox = CType(FormView1.FindControl("txttotalval"), TextBox)
        txttotalval.Text = TotVal
    End Sub


    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Response.Redirect("FrmTrainingMatrl.aspx")
    End Sub

    'Protected Sub Page_Unload1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
    '    new_dbconn1.Close()
    'End Sub
    Protected Sub FormView1_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles FormView1.DataBound
        If FormView1.CurrentMode = FormViewMode.Edit Then
            Dim str As String
            Dim id As Int64
            Dim dr As DropDownList
            If CType(FormView1.FindControl("cmbAsset"), DropDownList).Items.Count > 0 Then
                dr = CType(FormView1.FindControl("cmbAsset"), DropDownList)
                str = CType(FormView1.FindControl("hndAsset_Id"), HiddenField).Value
                id = dr.Items.IndexOf(dr.Items.FindByValue(str))
                dr.SelectedIndex = id
                CType(FormView1.FindControl("cmbAsset"), DropDownList).DataBind()
            End If
        Else
            Dim txtentrydate As TextBox = CType(FormView1.FindControl("txtentrydate"), TextBox)
            txtentrydate.Text = Today.Date.ToShortDateString()
        End If
        Disable()
    End Sub
    Sub Disable()
        Dim AssetType As DropDownList = CType(FormView1.FindControl("ddlAsstType"), DropDownList)
        Dim txtQty As TextBox = CType(FormView1.FindControl("txtQty"), TextBox)
        Dim Label20 As Label = CType(FormView1.FindControl("Label20"), Label)
        Dim Label23 As Label = CType(FormView1.FindControl("Label23"), Label)
        Dim Label28 As Label = CType(FormView1.FindControl("Label28"), Label)
        Dim Label29 As Label = CType(FormView1.FindControl("Label29"), Label)
        Dim txtSerialNo As TextBox = CType(FormView1.FindControl("txtSerialNo"), TextBox)
        Dim txtModel As TextBox = CType(FormView1.FindControl("txtModel"), TextBox)
        Dim Label22 As Label = CType(FormView1.FindControl("Label22"), Label)
        Dim txtbrand As TextBox = CType(FormView1.FindControl("txtbrand"), TextBox)
        Dim Label15 As Label = CType(FormView1.FindControl("Label15"), Label)
        Dim txtPrice As TextBox = CType(FormView1.FindControl("txtPrice"), TextBox)
        Dim txtMotorNo As TextBox = CType(FormView1.FindControl("txtMotorNo"), TextBox)
        Dim RfQty As RequiredFieldValidator = CType(FormView1.FindControl("RfQty"), RequiredFieldValidator)
        Dim RFPrice As RequiredFieldValidator = CType(FormView1.FindControl("RFPrice"), RequiredFieldValidator)
        Dim RequiredFieldValidator3 As RequiredFieldValidator = CType(FormView1.FindControl("RequiredFieldValidator3"), RequiredFieldValidator)

        If AssetType.SelectedValue = "2" Then
            txtQty.Enabled = False
            txtQty.Text = 0.0
            Label20.Enabled = False
            Label23.Enabled = False
            Label28.Enabled = False
            Label29.Enabled = False
            txtSerialNo.Enabled = False
            txtModel.Enabled = False
            Label22.Enabled = False
            txtbrand.Enabled = False
            Label15.Enabled = False
            txtPrice.Enabled = False
            txtPrice.Text = 0.0
            txtMotorNo.Enabled = False
            'RfQty.Enabled = False
            'RFPrice.Enabled = False
            'RequiredFieldValidator3.Enabled = False
        Else
            txtQty.Enabled = True
            ' txtQty.Text = 2
            Label20.Enabled = True
            Label23.Enabled = True
            Label28.Enabled = True
            Label29.Enabled = True
            txtSerialNo.Enabled = True
            txtModel.Enabled = True
            Label22.Enabled = True
            txtbrand.Enabled = True
            Label15.Enabled = True
            txtPrice.Enabled = True
            ' txtPrice.Text = 2
            txtMotorNo.Enabled = True
            'RfQty.Enabled = True
            ' RFPrice.Enabled = True
            ' RequiredFieldValidator3.Enabled = True
        End If
    End Sub

    Protected Sub FormView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.FormViewPageEventArgs)

    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class