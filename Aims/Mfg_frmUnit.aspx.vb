Partial Class Mfg_frmUnit
    Inherits BasePage
    Dim EL As New Mfg_ELUnit
    Dim BL As New Mfg_BLUnit
    Dim dt As New DataTable

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        LinkButton1.Focus()
        If btnDetails.Text = "VIEW" Then
            GridUnit.Enabled = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            ViewState("PageIndex") = 0
            GridUnit.PageIndex = 0
            DispGrid()
            'Clear()
        ElseIf btnDetails.Text = "BACK" Then
            GridUnit.Enabled = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            Clear()
            GridUnit.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                EL.Name = txtName.Text
                EL.Conversion = txtConvrsn.Text

                If btnSave.Text = "ADD" Then
                    dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        lblerrmsg.Text = "Data already exists."
                        lblmsgifo.Text = " "
                    Else
                        BL.InsertRecord(EL)
                        Clear()
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Saved Successfully."
                        btnSave.Text = "ADD"
                        GridUnit.Enabled = True
                        ViewState("PageIndex") = 0
                        GridUnit.PageIndex = 0
                        DispGrid()
                    End If
                ElseIf btnSave.Text = "UPDATE" Then
                    EL.id = ViewState("Unit_ID")

                    dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        lblerrmsg.Text = "Data already exists."
                        lblmsgifo.Text = " "
                        'clear()
                    Else
                        BL.UpdateRecord(EL)
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Updated Successfully."
                        btnSave.Text = "ADD"
                        GridUnit.Visible = True
                        btnDetails.Text = "VIEW"
                        Clear()
                        GridUnit.PageIndex = ViewState("PageIndex")
                        DispGrid()
                    End If
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
    Sub DispGrid()
        EL.id = 0

        dt = BL.getUnit(EL)
        If dt.Rows.Count > 0 Then
            GridUnit.Enabled = True
            GridUnit.Visible = True
            GridUnit.DataSource = dt
            GridUnit.DataBind()

        Else
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
            GridUnit.Visible = False
        End If
    End Sub
    Sub Clear()
        txtName.Text = ""
    End Sub

    Protected Sub GridUnit_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridUnit.PageIndexChanging
        GridUnit.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridUnit.PageIndex
        DispGrid()
        GridUnit.Visible = True
        lblmsgifo.Text = " "
        lblerrmsg.Text = " "
    End Sub

    Protected Sub GridUnit_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridUnit.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GridUnit.Rows(e.RowIndex).FindControl("Label5"), HiddenField).Value
            BL.DeleteUnit(EL)
            GridUnit.DataBind()
            'lblGreen.Visible = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = "Data Deleted Successfully."
            Clear()
            GridUnit.PageIndex = ViewState("PageIndex")
            DispGrid()
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If
    End Sub


    Protected Sub GridUnit_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridUnit.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then

            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            btnSave.Text = "UPDATE"
            btnDetails.Visible = True
            btnDetails.Text = "BACK"
            GridUnit.Visible = True
            ViewState("Unit_ID") = CType(GridUnit.Rows(e.NewEditIndex).FindControl("Label5"), HiddenField).Value
            txtName.Text = CType(GridUnit.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
            txtConvrsn.Text = CType(GridUnit.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
            EL.id = ViewState("Unit_ID")
            dt = BL.getUnit(EL)
            GridUnit.DataSource = dt
            GridUnit.DataBind()
            GridUnit.Enabled = False
            GridUnit.Visible = True
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        txtName.Focus()
        If Not IsPostBack Then

            txtConvrsn.Text = "1"
        End If
    End Sub
End Class

