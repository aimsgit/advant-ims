
Partial Class Mfg_frmManufacturer
    Inherits BasePage
    Dim Ent As New Mfg_ELmanufacturer
    Dim BLL As New Mfg_BLmanufacturer
    Dim dt As New DataTable

    'Written by Shailesh on 02/08/2012 
    'Method is for Save and Update
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtmanufacturer.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                Ent.Manufacturer = txtmanufacturer.Text
                Ent.Country = txtcountry.Text
                If Chkdislock.Checked = True Then
                    Ent.DisLock = "Y"
                Else
                    Ent.DisLock = "N"
                End If
                If RbTYPE.SelectedValue = "1" Then
                    Ent.Type = "MFG"
                Else
                    Ent.Type = "MKT"
                End If
                If btnSave.Text = "ADD" Then
                    BLL.InsertRecord(Ent)
                    Clear()
                    lblerrmsg.Text = ""
                    lblmsgifo.Text = "Data Saved Successfully."
                    btnSave.Text = "ADD"
                    GridManufacturer.Enabled = True
                    ViewState("PageIndex") = 0
                    GridManufacturer.PageIndex = 0
                    DispGrid()
                ElseIf btnSave.Text = "UPDATE" Then
                    Ent.id = ViewState("ManufAutoNo")
                    BLL.UpdateRecord(Ent)
                    lblerrmsg.Text = ""
                    lblmsgifo.Text = "Data Updated Successfully."
                    btnSave.Text = "ADD"
                    GridManufacturer.Visible = True
                    btnDetails.Text = "VIEW"
                    Clear()
                    GridManufacturer.PageIndex = ViewState("PageIndex")
                    DispGrid()
                End If
            Catch ex As Exception
                lblerrmsg.Text = "Enter correct data."
                lblmsgifo.Text = ""
            End Try

        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add data."
            lblmsgifo.Text = ""
        End If
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is for View and Back Button
   
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        LinkButton1.focus()
        If btnDetails.Text = "VIEW" Then
            GridManufacturer.Enabled = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            'If txtName.Text = "" Then
            '    s.Name = 0
            'Else
            '    s.Name = txtName.Text
            'End If
            GridManufacturer.PageIndex = ViewState("PageIndex")
            DispGrid()
            'clear()
        ElseIf btnDetails.Text = "BACK" Then
            GridManufacturer.Enabled = True

            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            Clear()
            GridManufacturer.PageIndex = 0
            ViewState("PageIndex") = 0
            DispGrid()
        End If
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is to display in Gridview
    Sub DispGrid()
        Ent.id = 0
        If txtmanufacturer.Text = "" Then
            Ent.Manufacturer = 0
        Else
            Ent.Manufacturer = txtmanufacturer.Text
        End If
        If txtcountry.Text = "" Then
            Ent.Country = 0
        Else
            Ent.Country = txtcountry.Text
        End If
        dt = BLL.getManufacturer(Ent)
        If dt.Rows.Count > 0 Then
            GridManufacturer.Enabled = True
            GridManufacturer.Visible = True
            GridManufacturer.DataSource = dt
            GridManufacturer.DataBind()
            LinkButton1.Focus()

            GridManufacturer.Visible = True
        Else
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
            GridManufacturer.Visible = False
        End If
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method to clear field
    Sub Clear()
        txtcountry.Text = ""
        txtmanufacturer.Text = ""
        Chkdislock.Checked = False
        RbTYPE.SelectedValue = "1"
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is for Page indexing
    Protected Sub GridManufacturer_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridManufacturer.PageIndexChanging
        GridManufacturer.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridManufacturer.PageIndex
        DispGrid()
        GridManufacturer.Visible = True
        lblmsgifo.Text = " "
        lblerrmsg.Text = " "
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is for Row Deleting 
    Protected Sub GridManufacturer_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridManufacturer.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Ent.id = CType(GridManufacturer.Rows(e.RowIndex).FindControl("Label5"), HiddenField).Value
            BLL.DeleteManufacturer(Ent)
            GridManufacturer.DataBind()
            'lblGreen.Visible = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = "Data Deleted Successfully."
            ' clear()
            GridManufacturer.PageIndex = ViewState("PageIndex")
            DispGrid()
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is for Page load operation
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        txtmanufacturer.Focus()
    End Sub
   
    'Written by Shailesh on 02/08/2012 
    'Method is for Row Editing
    Protected Sub GridManufacturer_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridManufacturer.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then

            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            btnSave.Text = "UPDATE"
            btnDetails.Visible = True
            btnDetails.Text = "BACK"
            GridManufacturer.Visible = True
            ViewState("ManufAutoNo") = CType(GridManufacturer.Rows(e.NewEditIndex).FindControl("Label5"), HiddenField).Value
            txtmanufacturer.Text = CType(GridManufacturer.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
            txtcountry.Text = CType(GridManufacturer.Rows(e.NewEditIndex).FindControl("lblcountry"), Label).Text
            Ent.DisLock = CType(GridManufacturer.Rows(e.NewEditIndex).FindControl("lblDiscount"), Label).Text
            If Ent.DisLock = "Yes" Then
                Chkdislock.Checked = True
            Else
                Chkdislock.Checked = False
            End If
            Ent.Type = CType(GridManufacturer.Rows(e.NewEditIndex).FindControl("lblType"), Label).Text
            If Ent.Type = "MFG" Then
                RbTYPE.SelectedValue = "1"
            ElseIf Ent.Type = "MKT" Then
                RbTYPE.SelectedValue = "2"
            End If
            Ent.id = ViewState("ManufAutoNo")
            Ent.Manufacturer = 0
            Ent.Country = 0
            dt = BLL.getManufacturer(Ent)
            GridManufacturer.DataSource = dt
            GridManufacturer.DataBind()
            GridManufacturer.Enabled = False
            GridManufacturer.Visible = True

        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
            lblmsgifo.Text = ""
        End If
    End Sub
    'Written by Shailesh on 02/08/2012 
    'Method is for Session exipire 
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Chkdislock_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chkdislock.CheckedChanged
        RbTYPE.Focus()
    End Sub

    Protected Sub RbTYPE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbTYPE.SelectedIndexChanged
        btnSave.Focus()
    End Sub
End Class
