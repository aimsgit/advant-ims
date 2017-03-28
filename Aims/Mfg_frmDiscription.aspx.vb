
Partial Class Mfg_frmDiscription
    Inherits BasePage
    Dim EL As New Mfg_ELDescription
    Dim BL As New Mfg_BLDescription
    Dim dt As New DataTable

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        LinkButton1.Focus()
        If btnDetails.Text = "VIEW" Then
            GridDescription.Enabled = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            ViewState("PageIndex") = 0
            GridDescription.PageIndex = 0
            DispGrid()
            'Clear()
        ElseIf btnDetails.Text = "BACK" Then
            GridDescription.Enabled = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            Clear()
            GridDescription.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                EL.Name = txtName.Text


                If btnSave.Text = "ADD" Then
                    EL.id = ViewState(" HiddenField1")
                    EL.Name = txtName.Text

                    'dt = BL.CheckDuplicate(EL)
                    'If dt.Rows.Count > 0 Then
                    '    lblerrmsg.Text = "Data already exists."
                    '    lblmsgifo.Text = " "
                    '    'clear()
                    'Else
                    dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then

                        lblmsgifo.Text = ""
                        lblerrmsg.Text = "Data already exists."
                        'dt = BL.CheckDuplicate(EL)
                        'If dt.Rows.Count > 0 Then
                        '    lblerrmsg.Text = "Data already exists."
                        '    lblmsgifo.Text = " "
                    Else
                        BL.InsertRecord(EL)
                        Clear()
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Saved Successfully."
                        btnSave.Text = "ADD"
                        GridDescription.Enabled = True
                        ViewState("PageIndex") = 0
                        GridDescription.PageIndex = 0
                        DispGrid()
                    End If
                ElseIf btnSave.Text = "UPDATE" Then
                    EL.id = ViewState(" HiddenField1")
                    EL.Name = txtName.Text

                    'dt = BL.CheckDuplicate(EL)
                    'If dt.Rows.Count > 0 Then
                    '    lblerrmsg.Text = "Data already exists."
                    '    lblmsgifo.Text = " "
                    '    'clear()
                    'Else
                    dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        lblmsgifo.Text = ""
                        lblerrmsg.Text = "Data already exists."
                        
                    Else
                        BL.UpdateRecord(EL)
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Updated Successfully."
                        btnSave.Text = "ADD"
                        GridDescription.Visible = True
                        btnDetails.Text = "VIEW"
                        Clear()
                        GridDescription.PageIndex = ViewState("PageIndex")
                        DispGrid()
                        'End If
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

        dt = BL.getDescription(EL)
        If dt.Rows.Count > 0 Then
            GridDescription.Enabled = True
            GridDescription.Visible = True
            GridDescription.DataSource = dt
            GridDescription.DataBind()

        Else
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
            GridDescription.Visible = False
        End If
    End Sub
    Sub Clear()
        txtName.Text = ""
    End Sub

    Protected Sub GridDescription_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridDescription.PageIndexChanging
        GridDescription.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridDescription.PageIndex
        DispGrid()
        GridDescription.Visible = True
        lblmsgifo.Text = " "
        lblerrmsg.Text = " "
    End Sub

    Protected Sub GridDescription_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridDescription.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GridDescription.Rows(e.RowIndex).FindControl("Label5"), HiddenField).Value
            BL.DeleteDescription(EL)
            GridDescription.DataBind()
            'lblGreen.Visible = True
            lblerrmsg.Text = " "
            lblmsgifo.Text = "Data Deleted Successfully."
            Clear()
            GridDescription.PageIndex = ViewState("PageIndex")
            EL.id = ViewState(" HiddenField1")
            DispGrid()
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub GridDescription_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridDescription.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then

            lblerrmsg.Text = ""
            lblmsgifo.Text = ""
            btnSave.Text = "UPDATE"
            btnDetails.Visible = True
            btnDetails.Text = "BACK"
            GridDescription.Visible = True
            ViewState("Desc_Id") = CType(GridDescription.Rows(e.NewEditIndex).FindControl("Label5"), HiddenField).Value
            ViewState(" HiddenField1") = CType(GridDescription.Rows(e.NewEditIndex).FindControl("HiddenField1"), HiddenField).Value
            txtName.Text = CType(GridDescription.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
            EL.id = ViewState("Desc_Id")
            dt = BL.getDescription(EL)
            GridDescription.DataSource = dt
            GridDescription.DataBind()
            GridDescription.Enabled = False
            GridDescription.Visible = True
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        txtName.Focus()
    End Sub
End Class
