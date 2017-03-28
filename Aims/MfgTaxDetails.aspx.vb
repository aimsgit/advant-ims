Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Partial Class MfgTaxDetails
    Inherits BasePage
    Dim EL As New Mfg_ELTaxDetails
    Dim BL As New Mfg_BLTaxDetails
    Dim dt As New DataTable
    'Anchala Verma date-01-jul-12
    'code for insert and update.
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        TxtTaxdescrptn.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                EL.TaxDescription = TxtTaxdescrptn.Text
                If txtvat.Text = "" Then
                    EL.vat = 0
                Else
                    EL.vat = txtvat.Text
                End If
                If TxtCST.Text = "" Then
                    EL.cst = 0
                Else
                    EL.cst = TxtCST.Text
                End If
                EL.IE = ddlIE.SelectedValue
                If btnAdd.Text = "UPDATE" Then
                    EL.id = ViewState("Tax_ID")
                    BL.UpdateRecord(EL)
                    btnAdd.Text = "ADD"
                    btnView.Text = "VIEW"
                    DisplayGrid()
                    lblmsg.Text = "Data Updated Successfully."
                    msginfo.Text = ""
                    clear()
                ElseIf btnAdd.Text = "ADD" Then
                    BL.InsertRecord(EL)
                    msginfo.Text = ""
                    ViewState("PageIndex") = 0
                    GrdTaxDetails.PageIndex = 0
                    DisplayGrid()
                    lblmsg.Text = "Data Saved Successfully."
                    msginfo.Text = ""
                    GrdTaxDetails.Visible = True
                    clear()
                End If
            Catch ex As Exception

            End Try
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub DisplayGrid()
        EL.id = 0
        dt = BL.GetGridData(EL.id)
        If dt.Rows.Count = 0 Then
            GrdTaxDetails.DataSource = Nothing
            GrdTaxDetails.DataBind()
            msginfo.Text = "No records to display."
            lblmsg.Text = ""
        Else
            GrdTaxDetails.DataSource = dt
            GrdTaxDetails.DataBind()
            GrdTaxDetails.Enabled = True
            GrdTaxDetails.Visible = True
        End If
    End Sub
    'Anchala Verma date-01-jul-12
    'code for getdata.
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        LinkButton1.Focus()
        lblmsg.Text = ""
        msginfo.Text = ""
        If btnView.Text <> "BACK" Then
            ViewState("PageIndex") = 0
            GrdTaxDetails.PageIndex = 0
            DisplayGrid()
            GrdTaxDetails.Visible = True

        Else

            btnView.Text = "VIEW"
            btnAdd.Text = "ADD"
            GrdTaxDetails.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            clear()
        End If
    End Sub

    'Anchala Verma date-01-jul-12
    'code for delete.
    Protected Sub GrdTaxDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GrdTaxDetails.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Tax_ID") = CType(GrdTaxDetails.Rows(e.RowIndex).FindControl("H1"), HiddenField).Value
            EL.id = ViewState("TaxAutoNo")
            If BL.ChangeFlag(EL) Then
                lblmsg.Text = "Data Deleted Successfully."
                GrdTaxDetails.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                GrdTaxDetails.Enabled = True
            End If
        Else

            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub clear()
        TxtTaxdescrptn.Text = ""
        TxtCST.Text = ""
        txtEvat.Text = ""
        txtvat.Text = ""
        TEcst.Text = ""
    End Sub
    'Anchala Verma date-01-jul-12
    'code for editing.
    Protected Sub GrdTaxDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GrdTaxDetails.RowEditing
        TxtTaxdescrptn.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("Tax_ID") = CType(GrdTaxDetails.Rows(e.NewEditIndex).FindControl("H1"), HiddenField).Value
            TxtTaxdescrptn.Text = CType(GrdTaxDetails.Rows(e.NewEditIndex).FindControl("l1"), Label).Text
            txtvat.Text = CType(GrdTaxDetails.Rows(e.NewEditIndex).FindControl("l2"), Label).Text
            TxtCST.Text = CType(GrdTaxDetails.Rows(e.NewEditIndex).FindControl("l3"), Label).Text
            ddlIE.SelectedValue = CType(GrdTaxDetails.Rows(e.NewEditIndex).FindControl("l4"), Label).Text
            txtEvat.Text = CType(GrdTaxDetails.Rows(e.NewEditIndex).FindControl("l5"), Label).Text
            TEcst.Text = CType(GrdTaxDetails.Rows(e.NewEditIndex).FindControl("l6"), Label).Text
            btnAdd.Text = "UPDATE"
            btnView.Text = "BACK"
            EL.id = ViewState("TaxAutoNo")
            dt = BL.GetGridData(EL.id)
            GrdTaxDetails.DataSource = dt
            GrdTaxDetails.DataBind()
            GrdTaxDetails.Enabled = False
        Else
            msginfo.Text = "You do not belong to this branch, Cannot edit data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtTaxdescrptn.Focus()

        'ddlIE.SelectedValue = "E"

    End Sub
    Protected Sub GrdTaxDetails_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GrdTaxDetails.PageIndexChanging
        GrdTaxDetails.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GrdTaxDetails.PageIndex
        Dim dt As New DataTable
        dt = BL.GetGridData(0)
        GrdTaxDetails.DataSource = dt
        GrdTaxDetails.Visible = True
        GrdTaxDetails.DataBind()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
