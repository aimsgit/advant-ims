
Partial Class FrmAssetDetailsView
    Inherits BasePage

    Protected Sub GdAssetDetails_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles GdAssetDetails.RowCommand
        Dim type As String = "Purchase"
        If e.CommandName = "CreditNote" Then
            Dim rowindex As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GdAssetDetails.Rows(rowindex)
            Dim pub_id_lbl As HiddenField = CType(row.FindControl("AID"), HiddenField)
            Dim assetid As String = (pub_id_lbl.Value)
            ' Dim qrystring As String = ConfigurationManager.AppSettings("ReportPath") & "Rptcreditnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            Dim qrystring As String = "Rptcreditnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            'Response.Redirect("Rptcreditnote.aspx?AID=" & assetid & "&a=" & type)
        ElseIf e.CommandName = "DebitNote" Then
            Dim rowindex As Integer = Convert.ToInt32(e.CommandArgument)
            Dim row As GridViewRow = GdAssetDetails.Rows(rowindex)
            Dim pub_id_lbl As HiddenField = CType(row.FindControl("AID"), HiddenField)
            Dim assetid As String = (pub_id_lbl.Value)
            'Dim qrystring As String =  "Rptdebitnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            Dim qrystring As String = "Rptdebitnote.aspx?" & QueryStr.Querystring() & "&AID=" & assetid & "&a=" & type
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            'Response.Redirect("Rptdebitnote.aspx?AID=" & assetid & "&a=" & type)
        End If
    End Sub

    Protected Sub GdAssetDetails_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GdAssetDetails.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim btnView As LinkButton = CType(e.Row.FindControl("ViewChild_Button"), LinkButton)

            If e.Row.DataItem("AssetType_Name").ToString = "Book Asset" Then
                btnView.Visible = True
            Else
                btnView.Visible = False
            End If
        End If
    End Sub

    Protected Sub GdAssetDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GdAssetDetails.RowDeleting
        Dim id As HiddenField = CType(GdAssetDetails.Rows(e.RowIndex).Cells(2).FindControl("BID"), HiddenField)
    End Sub

    Protected Sub GdAssetDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GdAssetDetails.RowEditing
        Dim parent_index As Integer = e.NewEditIndex
        GdAssetDetails.EditIndex = parent_index
        GdAssetDetails.DataBind()
        Dim row As GridViewRow = GdAssetDetails.Rows(parent_index)
        Dim pub_id_lbl As HiddenField = CType(row.FindControl("AID"), HiddenField)
        Session("AssetDet_Id") = Convert.ToInt32(pub_id_lbl.Value)
        Session("ParentGridViewIndex") = parent_index
        If Session("editstatus") = "Edit" Then
            Response.Redirect("FrmAssetDetails.aspx")
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Me.SqlAssetType.ConnectionString = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ConnectionString
        'Me.SqlAssetType.ProviderName = ConfigurationManager.ConnectionStrings("Sahaj_Edu").ProviderName
    End Sub

    Sub AssetDetailsMain(ByVal sender As Object, ByVal e As System.EventArgs)
        Session("editstatus") = "Edit"
    End Sub

    Protected Sub BookGridView_OnRowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs)
        Dim parent_index As Integer = Session("ParentGridViewIndex")
        Dim parent_row As GridViewRow = GdAssetDetails.Rows(parent_index)

        Dim ChildGridiView As GridView = CType(parent_row.FindControl("GrdBookDetails"), GridView)

        Dim child_index As Integer = e.NewEditIndex
        ChildGridiView.EditIndex = child_index
        ChildGridiView.DataBind()
        Dim child_row As GridViewRow = ChildGridiView.Rows(child_index)
        Dim Book_ID_lbl As HiddenField = CType(child_row.FindControl("BID"), HiddenField)
        Session("Book_ID") = Book_ID_lbl.Value
    End Sub

    Protected Sub btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnreport.Click
        Dim instituteid As Integer = Session("InstituteID")
        Dim branchid As Integer = Session("BranchID")
        Dim assettype As Integer
        Dim asset As Integer
        Dim BAL As New AssetDetailsB
        Dim Rdt As New DataTable
        If ddlAsstType.Items.Count <> 0 Then
            assettype = ddlAsstType.SelectedItem.Value
        Else
            assettype = 0
        End If
        If cmbAsset.Items.Count <> 0 Then
            asset = Me.cmbAsset.SelectedItem.Value
        Else
            asset = 0
        End If
        'Rdt = BAL.GetReport(instituteid, branchid, assettype, asset)
        If Rdt.Rows.Count > 0 Then
            'Response.Redirect("RptAssetDetailsV.aspx?Insti=" & instituteid & "&Branch=" & branchid & "&assettype=" & assettype & "&asset=" & asset)
            Dim qrystring As String = "RptAssetDetailsV.aspx?" & QueryStr.Querystring() & "&assettype=" & assettype & "&asset=" & asset
            ClientScript.RegisterStartupScript(Me.GetType, "Startup", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80') </script>")
        Else
            Dim alt As String = "<script language='javascript'>" + "alert('No records to display');" + "</script>"
            ClientScript.RegisterStartupScript(Me.GetType, "alert", alt)
        End If
    End Sub
    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        Response.Redirect("FrmAssetDetails.aspx")
    End Sub

    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
End Class
