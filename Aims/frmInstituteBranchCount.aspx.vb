
Partial Class frmInstituteBranchCount
    Inherits BasePage
    Dim BL As New BLInstituteWiseBranchCount
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("BranchCode") <> "000000000000" Then
            Response.Redirect("AccessDenied.aspx")
        Else
            Me.Lblheading.Text = Session("RptFrmTitleName")
            dt = BL.GetInstituteWiseBranch()
            If dt.Rows.Count > 0 Then
                GVInstituteList.DataSource = dt
                GVInstituteList.DataBind()
            Else
                lblError.Text = "No records to display."
            End If
        End If
    End Sub

    Protected Sub GVInstituteList_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVInstituteList.PageIndexChanging
        GVInstituteList.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVInstituteList.PageIndex
        dt.Clear()
        dt = BL.GetInstituteWiseBranch()
        If dt.Rows.Count > 0 Then
            GVInstituteList.DataSource = dt
            GVInstituteList.DataBind()
        Else
            lblError.Text = "No records to display."
        End If
    End Sub

    Protected Sub GVInstituteList_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVInstituteList.RowEditing
        Dim qrystring As String = "FrmInstituteWiseDrillDown.aspx?" & QueryStr.Querystring() & "&HOCode=" & CType(GVInstituteList.Rows(e.NewEditIndex).FindControl("lblHOCode"), Label).Text & "&BranchType=" & "02" & "&BranchName=" & CType(GVInstituteList.Rows(e.NewEditIndex).FindControl("lblInstitute"), Label).Text
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
    End Sub

    Protected Sub GVInstituteList_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVInstituteList.RowDeleting
        Dim qrystring As String = "FrmInstituteWiseDrillDown.aspx?" & QueryStr.Querystring() & "&HOCode=" & CType(GVInstituteList.Rows(e.RowIndex).FindControl("lblHOCode"), Label).Text & "&BranchType=" & "03" & "&BranchName=" & CType(GVInstituteList.Rows(e.RowIndex).FindControl("lblInstitute"), Label).Text
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
    End Sub

    Protected Sub GVInstituteList_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GVInstituteList.RowUpdating
        Dim qrystring As String = "FrmInstituteWiseDrillDown.aspx?" & QueryStr.Querystring() & "&HOCode=" & CType(GVInstituteList.Rows(e.RowIndex).FindControl("lblHOCode"), Label).Text & "&BranchType=" & "04" & "&BranchName=" & CType(GVInstituteList.Rows(e.RowIndex).FindControl("lblInstitute"), Label).Text
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
    End Sub

    Protected Sub GVInstituteList_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GVInstituteList.RowCancelingEdit
        Dim qrystring As String = "FrmInstituteWiseDrillDown.aspx?" & QueryStr.Querystring() & "&HOCode=" & CType(GVInstituteList.Rows(e.RowIndex).FindControl("lblHOCode"), Label).Text & "&BranchType=" & "05" & "&BranchName=" & CType(GVInstituteList.Rows(e.RowIndex).FindControl("lblInstitute"), Label).Text
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=50,top=50,right=50')</script>", False)
    End Sub
End Class
