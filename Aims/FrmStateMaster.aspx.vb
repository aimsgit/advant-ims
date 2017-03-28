
Partial Class FrmStateMaster
    Inherits BasePage
    Dim EL As New ELStateMaster
    Dim BL As New BLStateMaster
    Dim dt As New DataTable

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        cmbCountry.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.State = txtState.Text
            EL.Country = cmbCountry.SelectedValue
            If BtnSave.Text = "UPDATE" Then
                EL.id = ViewState("StateId")
                txtState.Text = ""
                dt = BL.CheckDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = " "
                Else
                    BL.UpdateRecord(EL)
                    BtnSave.Text = "ADD"
                    clear()
                    msginfo.Text = " "
                    BtnDetails.Text = "VIEW"
                    lblmsg.Text = "Data Updated Successfully."
                    GridView1.PageIndex = ViewState("PageIndex")
                    txtState.Text = ""
                    dispgrid()
                End If
            ElseIf BtnSave.Text = "ADD" Then
                EL.id = 0
                dt = BL.CheckDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = " "
                Else
                    BL.InsertRecord(EL)
                    BtnSave.Text = "ADD"
                    msginfo.Text = " "
                    lblmsg.Text = "Data Saved Successfully."
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    txtState.Text = " "
                    dispgrid()
                    clear()
                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        If BtnDetails.Text = "VIEW" Then
            GridView1.Enabled = True
            lblmsg.Text = ""
            msginfo.Text = ""
            txtState.Text = ""
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            dispgrid()
            'Clear()
        ElseIf BtnDetails.Text = "BACK" Then
            GridView1.Enabled = True
            lblmsg.Text = ""
            txtState.Text = ""
            BtnSave.Text = "ADD"
            BtnDetails.Text = "VIEW"
            clear()
            GridView1.PageIndex = ViewState("PageIndex")
            dispgrid()
        End If
    End Sub
    Sub dispgrid()
        EL.id = 0
        dt = BL.GetState(EL)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
        Else
            'msginfo.Visible = True
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
        End If
    End Sub
    Sub clear()
        txtState.Text = ""
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing

        If (Session("BranchCode") = Session("ParentBranch")) Then

            BtnSave.Text = "UPDATE"
            BtnDetails.Visible = True
            BtnDetails.Text = "BACK"
            GridView1.Visible = True
            ViewState("StateId") = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
            txtState.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
            cmbCountry.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
            EL.id = ViewState("StateId")
            dt = BL.GetState(EL)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            'clear()
        Else
            lblcountry.Text = "You do not belong to this branch, Cannot edit data."
            lblState.Text = ""
        End If
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lblmsg.Text = ""
        msginfo.Text = ""
        txtState.Focus()
    End Sub

End Class
