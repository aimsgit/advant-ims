Imports AssetTransfer
Partial Class frmTrainingMtrlTransfer
    Inherits BasePage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Enable()
        End If
        ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & ddlAsset.ClientID & "').focus();</script>")
    End Sub
    Sub Enable()
        Pan1.Enabled = True
        Pan2.Visible = False
        btnInsert.Enabled = False
        btnCancel.Enabled = False
        btnDetails.Enabled = True
    End Sub
    Protected Sub gvAssetDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAssetDetails.SelectedIndexChanged
        If gvAssetDetails.SelectedRow.Cells(7).Text <> 0 Or ddlAsstType.SelectedItem.Value = 2 Then
            txtFromInstitute.Text = CType(gvAssetDetails.SelectedRow.FindControl("lblInstitute"), Label).Text
            txtEntryDate.Text = Format(Date.Today, "dd-MMM-yyyy")
            txtPrice.Text = gvAssetDetails.SelectedRow.Cells(8).Text
            txtPurchaseDate.Text = Format(CDate(gvAssetDetails.SelectedRow.Cells(4).Text), "dd-MMM-yyyy")
            hfQty.Text = gvAssetDetails.SelectedRow.Cells(7).Text
            hfAssetType.Value = CType(gvAssetDetails.SelectedRow.FindControl("hfAssetType"), Label).Text
            hffromdetail.Value = CType(gvAssetDetails.SelectedRow.FindControl("hfAssetDetailId"), Label).Text
            hfReferenc.Value = 0
            Pan1.Enabled = False
            Pan2.Visible = True
            Pan2.Enabled = True
            btnInsert.Enabled = True
            btnCancel.Enabled = True
            btnDetails.Enabled = False
            txtQuantity.Text = 0
            txtTransferDate.Text = Format(Date.Today, "dd-MMM-yyyy")
        Else
            AlertEnterAllFields("No assert.")
        End If
    End Sub
    Sub details(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("frmTrainingMtrlTrDetails.aspx")
    End Sub
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click

        If hfReferenc.Value = 0 Then
            'Dim Prop As AssetTransferP = New AssetTransferP(hfAsset.Value, ddlToBranch.SelectedItem.Value, ddlToInstitute.SelectedItem.Value, hfSupplier.Value, hfManufacturer.Value, hfPIno.Value, hfPurchaseDate.Value, CDate(txtEntryDate.Text), CDate(txtTransferDate.Text), CInt(txtQuantity.Text), CInt(txtPrice.Text), hfBrand.Value, hfMdlNo.Value, hfBroughtBy.Value, hfAssetType.Value, hffromdetail.Value, 0, txtremarks.Text, txtfrom.Text, txtto.Text)
            Dim Prop As AssetTransferP = New AssetTransferP(ddlToBranch.SelectedItem.Value, ddlToInstitute.SelectedItem.Value, CDate(txtEntryDate.Text), CDate(txtTransferDate.Text), CInt(txtQuantity.Text), CInt(txtPrice.Text), hfAssetType.Value, hffromdetail.Value, 0, txtremarks.Text, txtfrom.Text, txtto.Text)
            Dim BAl As New AssetTransferB
            Dim n As Int64 = BAl.InsertRecord(Prop)
        End If
        clearAfterAssetTransfer()
        Enable()
        txtQuantity.Enabled = "True"
        AlertEnterAllFields("Training transfer successful.")
        gvAssetDetails.DataBind()
    End Sub
    Protected Sub Enable(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
        Enable()
        clearAfterAssetTransfer()
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Asset Transfer")
    End Sub
    Sub AlertEnterAllFields(ByVal str As String)
        lblmsg.Text = str
    End Sub
    Sub clearAfterAssetTransfer()
        txtFromInstitute.Text = ""
        txtPrice.Text = ""
        txtPurchaseDate.Text = ""
        txtEntryDate.Text = ""
        txtTransferDate.Text = ""
        txtfrom.Text = ""
        hfQty.Text = ""
        txtQuantity.Text = ""
        txtremarks.Text = ""
        txtto.Text = ""
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
    Protected Sub ddlToInstitute_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlToInstitute.TextChanged
        ddlToBranch.DataSourceID = "OdsBranch"
        OdsBranch.SelectMethod = "GetBranchInstWise"
        OdsBranch.SelectParameters.Clear()
        OdsBranch.SelectParameters.Add("id", ddlToInstitute.SelectedValue)
        ddlToBranch.DataBind()
    End Sub
    Sub FillBranch()
        ddlToBranch.DataSourceID = "OdsBranch"
        OdsBranch.SelectMethod = "GetBranchInstWise"
        OdsBranch.SelectParameters.Clear()
        OdsBranch.SelectParameters.Add("id", ddlToInstitute.SelectedValue)
        ddlToBranch.DataBind()
    End Sub

End Class



