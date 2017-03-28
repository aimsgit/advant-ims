Imports AssetTransfer
Partial Class frmAssetTransfer
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
        Pan3.Visible = False
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
            If hfAssetType.Value = 2 Then
                btnInsert.Text = "SHOW"
                hfReferenc.Value = 1
                hfPrice.Value = gvAssetDetails.SelectedRow.Cells(8).Text
            Else
                hfReferenc.Value = 0
            End If
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
    Sub Bind()
        Dim BAL As New AssetTransferB
        Dim Inst, Brch As String
        Inst = Session("InstituteID")
        Brch = Session("BranchID")
        GVBookDetails.DataSource = BAL.BookDetails(Inst, Brch, CInt(hffromdetail.Value))
        GVBookDetails.DataBind()
    End Sub
    Sub details(ByVal sender As Object, ByVal e As EventArgs)
        Response.Redirect("frmAssetTrDetails.aspx")
    End Sub
    Protected Sub GVBookDetails_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GVBookDetails.RowCancelingEdit
        GVBookDetails.EditIndex = -1
        Bind()
    End Sub
    Protected Sub GVBookDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVBookDetails.RowEditing
        GVBookDetails.EditIndex = e.NewEditIndex
        Bind()
    End Sub
    Protected Sub GVBookDetails_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GVBookDetails.RowUpdating
        Dim BkId As Int64 = CInt(GVBookDetails.DataKeys(e.RowIndex).Value)
        Dim BkPrice As Int64 = CInt(CType(GVBookDetails.Rows(e.RowIndex).Cells(6).FindControl("txtprice"), TextBox).Text)
        Dim BkQty As Int32 = CInt(CType(GVBookDetails.Rows(e.RowIndex).Cells(5).FindControl("txtQty"), TextBox).Text)
        Dim OBkQty As Int32 = (CInt(CType(GVBookDetails.Rows(e.RowIndex).Cells(5).FindControl("hfQty"), TextBox).Text)) - BkQty
        If hfReferenc.Value = 1 Then
            'Dim Prop As AssetTransferP = New AssetTransferP(BkId, Bkname, BkCode, BkAuthor, BkPublish, BkEdNo, BkSubId, BkPrice, BkQty, OBkQty, hfAsset.Value, ddlToBranch.SelectedItem.Value, ddlToInstitute.SelectedItem.Value, hfSupplier.Value, hfManufacturer.Value, hfPIno.Value, hfPurchaseDate.Value, CDate(txtEntryDate.Text), CDate(txtTransferDate.Text), CInt(txtQuantity.Text), CInt(txtPrice.Text), hfBrand.Value, hfMdlNo.Value, hfBroughtBy.Value, hfAssetType.Value, hffromdetail.Value, hfReferenc.Value, CInt(hfPrice.Value), txtremarks.Text, txtfrom.Text, txtto.Text)
            Dim Prop As AssetTransferP = New AssetTransferP(BkId, BkPrice, BkQty, OBkQty, ddlToBranch.SelectedItem.Value, ddlToInstitute.SelectedItem.Value, CDate(txtEntryDate.Text), CDate(txtTransferDate.Text), 0, 0.0, hfAssetType.Value, hffromdetail.Value, hfReferenc.Value, 0, txtremarks.Text, txtfrom.Text, txtto.Text)
            Dim BAL As New AssetTransferB
            hfNewAssetDetId.Value = BAL.InsertAssetDetailsBookTransfer(Prop)
        ElseIf hfReferenc.Value = 2 Then
            Dim Prop As AssetTransferP = New AssetTransferP(BkId, BkPrice, BkQty, OBkQty, ddlToBranch.SelectedItem.Value, ddlToInstitute.SelectedItem.Value, hfNewAssetDetId.Value, 0, 0, hffromdetail.Value, hfReferenc.Value, hfPrice.Value)
            Dim BAL As New AssetTransferB
            BAL.InsertBookTransfer(Prop)
        End If
        hfReferenc.Value = 2
        GVBookDetails.EditIndex = -1
        Bind()
    End Sub
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        If btnInsert.Text <> "SHOW" Then
            If hfReferenc.Value = 0 Then
                'Dim Prop As AssetTransferP = New AssetTransferP(hfAsset.Value, ddlToBranch.SelectedItem.Value, ddlToInstitute.SelectedItem.Value, hfSupplier.Value, hfManufacturer.Value, hfPIno.Value, hfPurchaseDate.Value, CDate(txtEntryDate.Text), CDate(txtTransferDate.Text), CInt(txtQuantity.Text), CInt(txtPrice.Text), hfBrand.Value, hfMdlNo.Value, hfBroughtBy.Value, hfAssetType.Value, hffromdetail.Value, 0, txtremarks.Text, txtfrom.Text, txtto.Text)
                Dim Prop As AssetTransferP = New AssetTransferP(ddlToBranch.SelectedItem.Value, ddlToInstitute.SelectedItem.Value, CDate(txtEntryDate.Text), CDate(txtTransferDate.Text), CInt(txtQuantity.Text), CInt(txtPrice.Text), hfAssetType.Value, hffromdetail.Value, 0, txtremarks.Text, txtfrom.Text, txtto.Text)
                Dim BAl As New AssetTransferB
                Dim n As Int64 = BAl.InsertRecord(Prop)
            End If
            clearAfterAssetTransfer()
            Enable()
            txtQuantity.Enabled = "True"
            AlertEnterAllFields("Asset transfer successful.")
        Else
            Bind()
            btnInsert.Text = "CONFIRM"
            txtQuantity.Enabled = "False"
            txtQuantity.Text = 0
            hfReferenc.Value = 1
            txtPrice.Text = 0
            Pan2.Enabled = False
            Pan3.Visible = True
        End If
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
End Class



