Imports AssetTransfer
Partial Class frmTrainingMtrlTrDetails
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
            'Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "Rptcreditnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            Dim qrystring As String = "Rptcreditnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        ElseIf e.CommandName = "DebitNote" Then
            Dim assetid As String = CType(gvAssetDetails.Rows(Convert.ToInt32(e.CommandArgument)).FindControl("TRID"), HiddenField).Value
            'Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "Rptdebitnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            Dim qrystring As String = "Rptdebitnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        End If
    End Sub
    Protected Sub gvAssetDetails_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim Prop As New AssetTransferP
        Dim BAl As New AssetTransferB
        Disable()
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
        btnInsert.Text = "CONFIRM"
        hfRef.Value = 0
    End Sub
    Protected Sub btnInsert_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnInsert.Click
        BAl.UpdateAssettransferDetails(ddlToBranch.SelectedItem.Value, ddlToInstitute.SelectedItem.Value, txtEntryDate.Text, txtQuantity.Text, txtprice.Text, txtTransferDate.Text, txtremarks.Text, txtfrom.Text, txtto.Text, hfTId.Value, hfTrId.Value)
        gvAssetDetails.DataBind()
        Enable()
        clear()
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
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        clear()
        gvAssetDetails.DataBind()
        Enable()
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If gvAssetDetails.EditIndex = -1 Then
            Dim instituteid As Integer = Session("InstituteID")
            Dim branchid As Integer = Session("BranchID")
            Dim assettype, asset As Integer
            Dim BLL As New AssetTransfer.AssetTransferB
            Dim dt As Data.DataTable
            If ddlAsstType.Items.Count <> 0 Then
                AssetType = ddlAsstType.SelectedItem.Value
            Else
                AssetType = 0
            End If
            If ddlAsset.Items.Count <> 0 Then
                Asset = ddlAsset.SelectedItem.Value
            Else
                Asset = 0
            End If
            dt = BLL.TrainingMtrlTransferReport(instituteid, branchid, assettype, asset)
            If dt.Rows.Count > 0 Then
                'Response.Redirect("rptTrainingmtrlTransferV.aspx")
                Dim qrystring As String = "rptTrainingmtrlTransferV.aspx?" & QueryStr.Querystring() & "&assettype=" & assettype & "&asset=" & asset
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            Else
                AlertEnterAllFields("No Records Found.")
            End If
        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("frmTrainingMtrlTransfer.aspx")
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
