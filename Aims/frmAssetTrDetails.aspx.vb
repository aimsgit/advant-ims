Imports AssetTransfer
Partial Class frmAssertTrDetails
    Inherits BasePage
    Dim BAl As New AssetTransferB
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Enable()
        End If
        ClientScript.RegisterStartupScript(Me.GetType(), "SetInitialFocus", "<script>document.getElementById('" & ddlAsset.ClientID & "').focus();</script>")
    End Sub
    Protected Sub gvAssetDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvAssetDetails.RowCommand
        Dim type As String = "Transfer"
        If e.CommandName = "CreditNote" Then
            Dim assetid As String = CType(gvAssetDetails.Rows(Convert.ToInt32(e.CommandArgument)).FindControl("TRID"), HiddenField).Value
            'Response.Redirect("Rptcreditnote.aspx?AID=" & assetid & "&a=" & type)
            ' Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "Rptcreditnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            Dim qrystring As String = "Rptcreditnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        ElseIf e.CommandName = "DebitNote" Then
            Dim assetid As String = CType(gvAssetDetails.Rows(Convert.ToInt32(e.CommandArgument)).FindControl("TRID"), HiddenField).Value
            'Response.Redirect("Rptdebitnote.aspx?AID=" & assetid & "&a=" & type)
            'Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "Rptdebitnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            Dim qrystring As String = "Rptdebitnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        End If
    End Sub
    Protected Sub gvAssetDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Prop As New AssetTransferP
        Dim BAl As New AssetTransferB
        Disable()
        'txtFromInstitute.Text = CType(gvAssetDetails.SelectedRow.FindControl("Label6"), Label).Text
        'txtfrombranch.Text = CType(gvAssetDetails.SelectedRow.FindControl("Label4"), Label).Text
        txtEntryDate.Text = Format(Date.Today, "dd-MMM-yyyy")
        txtQuantity.Text = CType(gvAssetDetails.SelectedRow.FindControl("Label2"), Label).Text
        'added price
        txtprice.Text = CType(gvAssetDetails.SelectedRow.FindControl("lblprice"), Label).Text
        txtTransferDate.Text = Format(CDate(CType(gvAssetDetails.SelectedRow.FindControl("Label3"), Label).Text), "dd-MMM-yyyy")
        txtPurDate.Text = Format(CDate(CType(gvAssetDetails.SelectedRow.FindControl("PurchaseDate"), Label).Text), "dd-MMM-yyyy")
        txtremarks.Text = CType(gvAssetDetails.SelectedRow.FindControl("lblremarks"), Label).Text
        txtfrom.Text = CType(gvAssetDetails.SelectedRow.FindControl("lblfrom"), Label).Text
        txtto.Text = CType(gvAssetDetails.SelectedRow.FindControl("lblto"), Label).Text
        ddlToBranch.SelectedValue = CType(gvAssetDetails.SelectedRow.FindControl("hfbrnid"), Label).Text
        ddlToInstitute.DataBind()
        ddlToInstitute.SelectedValue = CType(gvAssetDetails.SelectedRow.FindControl("hfinsid"), Label).Text
        hfQty.Text = CType(gvAssetDetails.SelectedRow.FindControl("hfQty"), Label).Text
        hfTrId.Value = CType(gvAssetDetails.SelectedRow.FindControl("hfTrId"), Label).Text
        hftype.Value = CType(gvAssetDetails.SelectedRow.FindControl("hfAssetType"), Label).Text
        hfTId.Value = CType(gvAssetDetails.SelectedRow.FindControl("hftid"), Label).Text
        hfSid.Value = CType(gvAssetDetails.SelectedRow.FindControl("hfSid"), Label).Text
        If hftype.Value = 2 Then
            hfTPrice.Value = CType(gvAssetDetails.SelectedRow.FindControl("TPrice"), Label).Text
            hfSPrice.Value = CType(gvAssetDetails.SelectedRow.FindControl("SPrice"), Label).Text
            btnInsert.Text = "DETAILS"
            txtQuantity.Enabled = False
        Else
            btnInsert.Text = "CONFIRM"
        End If
        hfRef.Value = 0
    End Sub

    Sub Bind()
        Dim Inst, Brch As String
        Inst = Session("InstituteID")
        Brch = Session("BranchID")
        gvBookDetails.DataSource = BAl.AssetTransferEdit(Inst, Brch, hfTId.Value)
        gvBookDetails.DataBind()
    End Sub
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        If hftype.Value <> 2 Then
            BAl.UpdateAssettransferDetails(ddlToBranch.SelectedItem.Value, ddlToInstitute.SelectedItem.Value, txtEntryDate.Text, txtQuantity.Text, txtprice.Text, txtTransferDate.Text, txtremarks.Text, txtfrom.Text, txtto.Text, hfTId.Value, hfTrId.Value)
            gvAssetDetails.DataBind()
            Enable()
            clear()
        Else
            If hfRef.Value = 0 Then
                Bind()
                btnInsert.Text = "CONFIRM"
                pan2.Enabled = False
                Pan3.Visible = True
                hfRef.Value = 1
            ElseIf hfRef.Value = 1 Then
                'UpdateBrnIns()
                gvAssetDetails.DataBind()
                Enable()
            Else
                gvAssetDetails.DataBind()
                Enable()
            End If
        End If
    End Sub
    Protected Sub gvAssetDetails_DataBound(ByVal sender As Object, ByVal e As System.EventArgs) Handles gvAssetDetails.DataBound
        If gvAssetDetails.Rows.Count <> 0 Then
            hftype.Value = CInt(CType(gvAssetDetails.Rows(0).Cells(1).FindControl("hfAssetType"), Label).Text)
        End If
    End Sub
    Protected Sub gvAssetDetails_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvAssetDetails.PageIndexChanging
        gvAssetDetails.PageIndex = e.NewPageIndex
        gvAssetDetails.DataBind()
    End Sub
    Protected Sub gvAssetDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvAssetDetails.RowDeleting
        If gvAssetDetails.SelectedIndex = -1 Then
            hftype.Value = CInt(CType(gvAssetDetails.Rows(e.RowIndex).Cells("1").FindControl("hfAssetType"), Label).Text)
            Dim SId As Int64 = CInt(CType(gvAssetDetails.Rows(e.RowIndex).FindControl("hftid"), Label).Text)
            BAl.Del_update(SId, hftype.Value)
            gvAssetDetails.DataBind()
        End If
    End Sub
    Protected Sub btnRecover_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnRecover.Click
        If gvBookDetails.EditIndex = -1 And gvAssetDetails.EditIndex = -1 Then
            Session("RecoverForm") = "AssetTr"
            Response.Redirect("recover.aspx")
        End If
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
        gvAssetDetails.DataBind()
        Enable()
    End Sub
    Protected Sub gvBookDetails_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvBookDetails.PageIndexChanging
        If gvBookDetails.EditIndex = -1 Then
            gvBookDetails.PageIndex = e.NewPageIndex
            Bind()
        End If
    End Sub
    Protected Sub gvBookDetails_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles gvBookDetails.RowCancelingEdit
        gvBookDetails.EditIndex = -1
        Bind()
    End Sub
    Protected Sub gvBookDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvBookDetails.RowDeleting
        If gvBookDetails.EditIndex = -1 Then
            Dim BKid As Int64
            BKid = CInt(gvBookDetails.DataKeys(e.RowIndex).Value)
            BAl.Del_Updatebook(BKid)
            Bind()
        End If
    End Sub
    Protected Sub gvBookDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvBookDetails.RowEditing
        gvBookDetails.EditIndex = e.NewEditIndex
        Bind()
    End Sub
    Protected Sub gvBookDetails_RowUpdating1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles gvBookDetails.RowUpdating
        Dim BAL As New AssetTransferB
        Dim Prop As New AssetTransferP
        Prop.Branch_Id = ddlToBranch.SelectedItem.Value
        Prop.Institute_Id = ddlToInstitute.SelectedItem.Value
        Prop.TransferDate = CDate(txtTransferDate.Text)
        Prop.EntryDate = CDate(txtEntryDate.Text)
        Prop.Target_Id = hfTId.Value
        Prop.Book_ID = CInt(gvBookDetails.DataKeys(e.RowIndex).Value)
        Prop.BKQuantity = CInt(CType(gvBookDetails.Rows(e.RowIndex).Cells(4).FindControl("txtQty"), TextBox).Text)
        BAL.AssetBookQtyEdit(Prop, hfRef.Value)
        hfRef.Value = 2
        gvBookDetails.EditIndex = -1
        Bind()
    End Sub
    Protected Sub btnBKRecover_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBKRecover.Click
        If gvBookDetails.EditIndex = -1 Then
            Session("RecoverForm") = "AssetTrBK"
            Response.Redirect("recover.aspx")
        End If
    End Sub
    Protected Sub btnBKReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBKReport.Click
        If gvBookDetails.EditIndex = -1 Then
            Dim instituteid As Integer = Session("InstituteID")
            Dim branchid As Integer = Session("BranchID")
            Dim assettype, asset As Integer
            Dim BLL As New AssetTransfer.AssetTransferB
            If ddlAsstType.Items.Count <> 0 Then
                assettype = ddlAsstType.SelectedItem.Value
            Else
                assettype = 0
            End If
            If ddlAsset.Items.Count <> 0 Then
                asset = ddlAsset.SelectedItem.Value
            Else
                asset = 0
            End If
            Dim dt As New Data.DataTable
            dt = BLL.AssetBookTransferReport(instituteid, branchid, assettype, asset)
            If dt.Rows.Count > 0 Then
                'Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "rptAssetBookTransferV.aspx?" & QueryStr.Querystring() & "&assettype=" & assettype & "&asset=" & asset
                Dim qrystring As String = "rptAssetBookTransferV.aspx?" & QueryStr.Querystring() & "&assettype=" & assettype & "&asset=" & asset
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                'Response.Redirect("rptAssetBookTransferV.aspx")
            Else
                AlertEnterAllFields("No Records Found.")
            End If
        End If
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If gvAssetDetails.EditIndex = -1 Then
            Dim instituteid As Integer = Session("InstituteID")
            Dim branchid As Integer = Session("BranchID")
            Dim assettype, asset As Integer
            Dim BLL As New AssetTransfer.AssetTransferB
            If ddlAsstType.Items.Count <> 0 Then
                assettype = ddlAsstType.SelectedItem.Value
            Else
                assettype = 0
            End If
            If ddlAsset.Items.Count <> 0 Then
                asset = ddlAsset.SelectedItem.Value
            Else
                asset = 0
            End If
            Dim dt As Data.DataTable
            dt = BLL.AssetTransferReport(instituteid, branchid, assettype, asset)
            If dt.Rows.Count > 0 Then
                'Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "rptAssetTransferV.aspx?" & QueryStr.Querystring() & "&assettype=" & assettype & "&asset=" & asset
                Dim qrystring As String = "rptAssetTransferV.aspx?" & QueryStr.Querystring() & "&assettype=" & assettype & "&asset=" & asset
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Else
                AlertEnterAllFields("No Records Found.")
            End If
        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("frmAssetTransfer.aspx")
    End Sub
    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Asset Transfer")
    End Sub
    Sub AlertEnterAllFields(ByVal str As String)
        lblmsg.Text = str
    End Sub
    Sub clear()
        txtEntryDate.Text = ""
        txtTransferDate.Text = ""
        txtprice.Text = ""
        txtfrom.Text = ""
        txtPurDate.Text = ""
        txtQuantity.Text = ""
        txtremarks.Text = ""
        txtto.Text = ""
    End Sub
    Sub Enable()
        Pan1.Enabled = True
        pan2.Enabled = False
        Pan3.Visible = False
        btnRecover.Enabled = True
        btnReport.Enabled = True
        btnInsert.Enabled = False
        btnCancel.Enabled = False
    End Sub
    Sub Disable()
        pan2.Enabled = True
        Pan1.Enabled = False
        btnRecover.Enabled = False
        btnReport.Enabled = False
        btnInsert.Enabled = True
        btnCancel.Enabled = True
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
