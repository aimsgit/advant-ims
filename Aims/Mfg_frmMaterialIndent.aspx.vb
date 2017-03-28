Partial Class Mfg_frmMaterialIndent
    Inherits BasePage
    Dim dt As DataTable
    Dim dt1 As DataTable
    Dim AddMaterial As New MaterialIndentEL
    Dim AddMaterialBL As New MaterialIndentBL
    Dim DL As New MaterialIndentDL
    Sub CheckAll()
        If CType(GridView1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            GridView1.Visible = True

            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = True
            Next
        Else
            GridView1.Visible = True


            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkSelect"), CheckBox).Checked = False
            Next
        End If

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try

        
            lblMsg.Text = ""
            lblErrorMsg.Text = ""
            If txtmino.Text = "" Then
                lblErrorMsg.Text = "Enter Material Indent No."
            Else
                AddMaterial.mino = txtmino.Text
            End If
            If txtMidate.Text = "" Then
                AddMaterial.midate = "01/01/1900"
            Else
                AddMaterial.midate = txtMidate.Text
            End If

            AddMaterial.custmr = ddlPName.SelectedValue
            AddMaterial.party_id = cmbPType.SelectedValue
            AddMaterial.wo_id = ddlWorkOrder.SelectedValue
            AddMaterial.id1 = ViewState("ID1")

            dt = AddMaterialBL.CheckDuplicate(AddMaterial)
            If dt.Rows.Count > 0 Then
                lblErrorMsg.Text = "Record(s) Already Exists."
                lblMsg.Text = ""
            Else

                If btnAdd.Text = "ADD" Then
                    dt1 = AddMaterialBL.CheckMIndentNo(AddMaterial)
                    If dt1.Rows.Count > 0 Then
                        AddMaterial.id = 0
                        AddMaterialBL.InsertMaterialIndentMain(AddMaterial)
                        DisplayGridView()
                        lblMsg.Text = "Record Saved Successfully."
                        lblgreen.Text = ""
                        lblRed.Text = ""
                        lblErrorMsg.Text = ""
                        dt = MaterialIndentDL.MIndentCodeAutofill()
                        txtmino.Text = dt.Rows(0).Item("MINo").ToString
                        clear()
                    Else
                        lblErrorMsg.Text = "Please enter material details first."
                        Exit Sub
                    End If
                Else

                    btnAdd.Text = "ADD"
                    btnView.Text = "VIEW"
                    AddMaterial.id1 = ViewState("ID1")
                    dt = AddMaterialBL.CheckStatus(AddMaterial)
                    If dt.Rows(0).Item("PostToStock") = "N" Then
                        AddMaterialBL.InsertMaterialIndentMain(AddMaterial)
                        DisplayGridView()
                        lblMsg.Text = "Record Updated Successfully."
                        lblgreen.Text = ""
                        lblRed.Text = ""
                        lblErrorMsg.Text = ""
                        dt = MaterialIndentDL.MIndentCodeAutofill()
                        txtmino.Text = dt.Rows(0).Item("MINo").ToString
                        clear()
                    Else
                        lblErrorMsg.Text = "Cannot update posted record."
                        lblMsg.Text = ""
                        lblgreen.Text = ""
                        lblRed.Text = ""
                        btnAdd.Text = "UPDATE"
                        btnView.Text = "BACK"
                    End If
                End If
            End If
            'Else
            'lblErrorMsg.Text = "Please enter material details."
        Catch ex As Exception

        End Try
        'End If
    End Sub
    Sub DisplayGridView()
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        AddMaterial.id1 = 0
        AddMaterial.party_id = cmbPType.SelectedValue
        AddMaterial.custmr = ddlPName.SelectedValue
        Dim dt As DataTable = AddMaterialBL.MaterialIndentMainGridView(AddMaterial)
        GridView1.DataSource = dt
        If dt.Rows.Count > 0 Then
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
        Else
            lblErrorMsg.Text = "No Record(s) To Display."
            GridView1.Visible = False
        End If
    End Sub
    Sub clear()
        txtMidate.Text = Format(Today, "dd-MMM-yyyy")

    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        ViewState("Posted") = ""
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        If btnView.Text = "VIEW" Then
            DisplayGridView()
            clear()
        Else
            DisplayGridView()
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
            btnDetails.Text = "ADD DETAILS"
            btnPost.Text = "POST"
            clear()
            dt = MaterialIndentDL.MIndentCodeAutofill()
            txtmino.Text = dt.Rows(0).Item("MINo").ToString
            txtMidate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim rowsaffected As Integer
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        AddMaterial.id1 = CType(GridView1.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
        dt = AddMaterialBL.CheckStatus(AddMaterial)
        If dt.Rows(0).Item("PostToStock") = "N" Then
            rowsaffected = AddMaterialBL.DeleteMaterialIndentMain(AddMaterial)
            DisplayGridView()
            lblMsg.Text = "Record Deleted Successfully."
            dt = MaterialIndentDL.MIndentCodeAutofill()
            txtmino.Text = dt.Rows(0).Item("MINo").ToString
            txtMidate.Text = Format(Today, "dd-MMM-yyyy")
        Else
            DisplayGridView()
            lblMsg.Text = ""
            lblErrorMsg.Text = "Approved/Rejected data cannot delete."

        End If
        ViewState("Posted") = ""
      
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'Dim ID As Integer
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        ViewState("Posted") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPToStk"), Label).Text
        txtmino.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblMi_No"), Label).Text
        txtMidate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblMi_Date"), Label).Text
        cmbPType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPType_id"), Label).Text
        'ddlPName.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCustomer_id"), Label).Text
        Dim TestId As Integer = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCustomer_id"), Label).Text
        ddlPName.ClearSelection()
        ddlPName.DataSourceID = "ObjParty_Name"
        ddlPName.DataBind()
        ddlPName.SelectedValue = TestId
        ddlWorkOrder.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblWo_Id"), Label).Text
        ViewState("ID1") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
        AddMaterial.id1 = ViewState("ID1")
        AddMaterial.party_id = cmbPType.SelectedValue
        AddMaterial.custmr = ddlPName.SelectedValue
        Dim dt As DataTable = AddMaterialBL.MaterialIndentMainGridView(AddMaterial)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
        GridView1.Visible = True
        'btnActive.Enabled = True
        btnAdd.Text = "UPDATE"
        btnView.Text = "BACK"
        'btnDetails.Text = "ADD DETAILS"
    End Sub

    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Try
            Dim id As String = ""
            Dim check As String = ""
            Dim Count1 As Integer = 0
            For Each Grid As GridViewRow In GridView1.Rows
                If CType(Grid.FindControl("ChkSelect"), CheckBox).Checked = True Then
                    check = CType(Grid.FindControl("HID"), HiddenField).Value
                    id = check + "," + id
                    Count1 = Count1 + 1
                End If
            Next

            If id = "" Then
                id = 0
            Else
                id = Left(id, id.Length - 1)
            End If
            If Count1 > 0 Then
                'MaterialIndentDL.PostMaterialIndentMain(id)
                For Each grid As GridViewRow In GridView1.Rows
                    If CType(grid.FindControl("ChkSelect"), CheckBox).Checked = True Then
                        AddMaterial.id1 = CType(grid.FindControl("HID"), HiddenField).Value.ToString
                        dt = AddMaterialBL.CheckStatus(AddMaterial)
                        If dt.Rows(0).Item("PostToStock") <> "N" Then
                            lblErrorMsg.Text = "Please deselect the record(s) which are already posted."
                            lblMsg.Text = ""
                            Exit Sub
                        End If
                    End If
                Next
                For Each grid As GridViewRow In GridView1.Rows
                    If CType(grid.FindControl("ChkSelect"), CheckBox).Checked = True Then
                        AddMaterial.id = CType(grid.FindControl("HID"), HiddenField).Value.ToString
                        AddMaterialBL.Approve(AddMaterial)
                    End If
                Next
                DisplayGridView()
                lblMsg.Text = "Record(s) Posted Successfully."
                lblErrorMsg.Text = ""
            Else
                lblErrorMsg.Text = "Please select the record(s) to Post."
                lblMsg.Text = ""
            End If
          
        Catch ex As Exception
            lblErrorMsg.Text = "Please Enter Correct Data."
            lblMsg.Text = ""
        End Try
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        Dim dt As DataTable = AddMaterialBL.MaterialIndentMainGridView(AddMaterial)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Visible = True
        GridView1.PageIndex = e.NewPageIndex

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dt = MaterialIndentDL.MIndentCodeAutofill()
            txtmino.Text = dt.Rows(0).Item("MINo").ToString
            txtMidate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        If txtmino.Text <> "" Then

            TabContainer1.ActiveTab = TabPanel2
            'TabPanel2.Enabled = True
            'TabPanel1.Enabled = False
            ddlItemDesc.Focus()
            lblMsg.Text = ""
            lblErrorMsg.Text = ""
        Else
            lblErrorMsg.Text = "Please Select Supplier First."
            lblMsg.Text = ""
            TabPanel2.Enabled = False
        End If
    End Sub

    Protected Sub btnAddDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetails.Click
        If ViewState("Posted") <> "N" And ViewState("Posted") <> Nothing Then
            lblRed.Text = "Cannot update posted record."
            txtQuantity.Text = ""
            Exit Sub
        End If
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        If txtQuantity.Text = "" Then
            lblErrorMsg.Text = "Enter Item Quantity."
        Else
            AddMaterial.quantity = txtQuantity.Text
        End If
        AddMaterial.itemdesc = ddlItemDesc.SelectedValue
        AddMaterial.quantity = txtQuantity.Text
        AddMaterial.mino = txtmino.Text
        AddMaterial.id = ViewState("ID")

        If btnAddDetails.Text = "ADD" Then
            AddMaterial.id = 0
            AddMaterialBL.InsertMaterialIndentDetails(AddMaterial)
            DisplayGridView1()
            lblgreen.Text = "Record Saved Successfully."
            lblRed.Text = ""
            clear1()
            txtMidate.Text = Format(Today, "dd-MMM-yyyy")
        Else
            btnAddDetails.Text = "ADD"
            btnViewDetails.Text = "VIEW"
            AddMaterial.id = ViewState("ID")
            AddMaterialBL.InsertMaterialIndentDetails(AddMaterial)
            DisplayGridView1()
            lblgreen.Text = "Record Updated Successfully."
            lblRed.Text = ""
            clear1()
            txtMidate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
    Sub DisplayGridView1()
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        lblRed.Text = ""
        lblgreen.Text = ""
        'Dim ID As Integer = 0
        AddMaterial.id = 0
        AddMaterial.mino = txtmino.Text
        'AddMaterial.custmr = ddlPName.SelectedValue
        Dim dt As DataTable = AddMaterialBL.MaterialIndentDetailsGridView(AddMaterial)
        GridView2.DataSource = dt
        If dt.Rows.Count > 0 Then
            GridView2.DataBind()
            GridView2.Enabled = True
            GridView2.Visible = True
        Else
            lblRed.Text = "No Record(s) To Display."
            lblgreen.Text = ""
             GridView2.Visible = False
        End If
    End Sub
    Sub clear1()
        txtQuantity.Text = ""
        ddlItemDesc.ClearSelection()
        txtMidate.Text = Format(Today, "dd-MMM-yyyy")
    End Sub

    Protected Sub btnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnViewDetails.Click
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        If btnViewDetails.Text = "VIEW" Then
            DisplayGridView1()
        Else
            DisplayGridView1()
            btnAddDetails.Text = "ADD"
            btnViewDetails.Text = "VIEW"
            btnClose.Text = "CLOSE"
            clear1()
            txtMidate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Dim rowsaffected As Integer
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        AddMaterial.id = CType(GridView2.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
        dt = AddMaterialBL.CheckStatus1(AddMaterial)
        If dt.Rows(0).Item("PostToStock") = "N" Then
            rowsaffected = AddMaterialBL.DeleteMaterialIndentDetails(AddMaterial)
            DisplayGridView1()
            lblgreen.Text = "Record Deleted Successfully."
            lblRed.Text = ""
        Else
            DisplayGridView1()
            lblRed.Text = "Posted data cannot delete."
            lblgreen.Text = ""

        End If
    End Sub
    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        'Dim ID As Integer
        Dim dt1 As New DataTable
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        ViewState("ID") = CType(GridView2.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
        AddMaterial.id = ViewState("ID")
        dt1 = AddMaterialBL.CheckStatus1(AddMaterial)
        If dt1.Rows.Count > 0 Then
            If dt1.Rows(0).Item("PostToStock") <> "N" Then
                lblRed.Text = "Posted record cannot edit."
                lblgreen.Text = ""
                Exit Sub
            End If
        End If
        ddlItemDesc.SelectedValue = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblItemId"), Label).Text
        txtQuantity.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblQty"), Label).Text
        AddMaterial.mino = txtmino.Text
        Dim dt As DataTable = AddMaterialBL.MaterialIndentDetailsGridView(AddMaterial)
        GridView2.DataSource = dt
        GridView2.DataBind()
        GridView2.Enabled = False
        GridView2.Visible = True
        'btnActive.Enabled = True
        btnAddDetails.Text = "UPDATE"
        btnViewDetails.Text = "BACK"
        'btnDetails.Text = "ADD DETAILS"
    End Sub
    Protected Sub GridView2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView2.PageIndexChanging
        Dim dt As DataTable = AddMaterialBL.MaterialIndentDetailsGridView(AddMaterial)
        GridView2.DataSource = dt
        GridView2.DataBind()
        GridView2.Enabled = True
        GridView2.Visible = True
        GridView2.PageIndex = e.NewPageIndex
    End Sub

    Protected Sub btnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnClose.Click
        TabContainer1.ActiveTab = TabPanel1
        TabPanel1.Enabled = True
        GridView2.Visible = "false"
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
    End Sub

    Protected Sub ddlItemDesc_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlItemDesc.SelectedIndexChanged
        Try
            AddMaterial.itemdesc = ddlItemDesc.SelectedValue
            dt = AddMaterialBL.GetUnit(AddMaterial)
            txtUnit.text = dt.Rows(0).Item("Unit")
        Catch ex As Exception
            txtUnit.text = ""
        End Try
    End Sub
End Class
