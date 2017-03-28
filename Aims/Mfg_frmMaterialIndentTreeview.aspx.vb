
Partial Class Mfg_frmMaterialIndentTreeview
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
        AddMaterial.id = ViewState("ID")


        'If dt1.Rows.Count > 0 Then
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
                    lblMsg.Text = "Record(s) Saved Successfully."

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
                AddMaterial.id = ViewState("ID")
                AddMaterialBL.InsertMaterialIndentMain(AddMaterial)

                DisplayGridView()
                lblMsg.Text = "Record(s) Updated Successfully."

                dt = MaterialIndentDL.MIndentCodeAutofill()
                txtmino.Text = dt.Rows(0).Item("MINo").ToString
                clear()
            End If
        End If
        'Else
        'lblErrorMsg.Text = "Please enter material details."

        'End If
    End Sub
    Sub DisplayGridView()
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        AddMaterial.id = 0
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
        txtMidate.Text = ""

    End Sub
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
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

        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim rowsaffected As Integer
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        AddMaterial.id = CType(GridView1.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
        rowsaffected = AddMaterialBL.DeleteMaterialIndentMain(AddMaterial)
        DisplayGridView()
        lblMsg.Text = "Record(s) Deleted Successfully."
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'Dim ID As Integer
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
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
        ViewState("ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
        AddMaterial.id = ViewState("ID")
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
                MaterialIndentDL.PostMaterialIndentMain(id)
                lblMsg.Text = "Record(s) Posted Successfuly."
                lblErrorMsg.Text = ""

            Else
                lblErrorMsg.Text = "Please select the record(s) to Post."
                lblMsg.Text = ""
            End If
            For Each grid As GridViewRow In GridView1.Rows
                If CType(grid.FindControl("ChkSelect"), CheckBox).Checked = True Then
                    AddMaterial.id = CType(grid.FindControl("HID"), HiddenField).Value.ToString
                    AddMaterialBL.Approve(AddMaterial)
                End If
            Next
            AddMaterial.party_id = 0
            AddMaterial.custmr = 0
            Dim dt As DataTable = AddMaterialBL.MaterialIndentMainGridView(AddMaterial)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
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
        Try
            If Not IsPostBack Then
                Dim dt As New DataTable
                AddMaterial.party_id = 0
                AddMaterial.custmr = 0
                AddMaterial.id = CInt(Session("RowID"))
                dt = AddMaterialBL.MaterialIndentMainGridView(AddMaterial)
                cmbPType.ClearSelection()
                cmbPType.DataSourceID = "ObjPartyType"
                cmbPType.DataBind()
                cmbPType.SelectedValue = dt.Rows(0).Item("PartyType_Id")
                ddlPName.ClearSelection()
                ddlPName.DataSourceID = "ObjParty_Name"
                ddlPName.DataBind()
                ddlPName.SelectedValue = dt.Rows(0).Item("Party_Id")
                ddlWorkOrder.SelectedValue = dt.Rows(0).Item("SO_Id")
                txtMidate.Text = Format(dt.Rows(0).Item("MI_Date"), "dd-MMM-yyyy")
                txtmino.Text = dt.Rows(0).Item("MI_No")
                btnView.Enabled = False
                cmbPType.Enabled = False
                ddlPName.Enabled = False
                ddlWorkOrder.Enabled = False
                txtmino.Enabled = False
                txtMidate.Enabled = False
                txtQuantity.Enabled = False
                ddlItemDesc.Enabled = False
                btnAdd.Enabled = False
                btnAddDetails.Enabled = False
                btnPost.Enabled = False
            End If
        Catch ex As Exception
            lblErrorMsg.Visible = True
            lblErrorMsg.Text = "Not Accessible for Institute Admin."
            lblMsg.Text = ""
            btnAdd.Enabled = False
            btnAddDetails.Enabled = False
            btnPost.Enabled = False
            cmbPType.Enabled = False
            ddlPName.Enabled = False
            ddlWorkOrder.Enabled = False
            txtmino.Enabled = False
            txtMidate.Enabled = False
            txtQuantity.Enabled = False
            ddlItemDesc.Enabled = False
            btnAdd.Enabled = False
            btnAddDetails.Enabled = False
            btnPost.Enabled = False
            btnView.Enabled = False
        End Try
        'If Not IsPostBack Then
        '    dt = MaterialIndentDL.MIndentCodeAutofill()
        '    txtmino.Text = dt.Rows(0).Item("MINo").ToString
        'End If
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
            lblgreen.Text = "Record(s) Saved Successfully."
            lblRed.Text = ""
            DisplayGridView1()
            clear1()
        Else
            btnAddDetails.Text = "ADD"
            btnViewDetails.Text = "VIEW"
            AddMaterial.id = ViewState("ID")
            AddMaterialBL.InsertMaterialIndentDetails(AddMaterial)
            lblgreen.Text = "Record(s) Updated Successfully."
            lblRed.Text = ""
            DisplayGridView1()
            clear1()
        End If
    End Sub
    Sub DisplayGridView1()
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
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
        End If
    End Sub
    Sub clear1()
        txtQuantity.Text = ""
        ddlItemDesc.ClearSelection()
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
        End If
    End Sub
    Protected Sub GridView2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView2.RowDeleting
        Dim rowsaffected As Integer
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        AddMaterial.id = CType(GridView2.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
        rowsaffected = AddMaterialBL.DeleteMaterialIndentDetails(AddMaterial)
        DisplayGridView1()
        lblgreen.Text = "Record(s) Deleted Successfully."
        lblRed.Text = ""

    End Sub
    Protected Sub GridView2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView2.RowEditing
        'Dim ID As Integer
        lblMsg.Text = ""
        lblErrorMsg.Text = ""
        ddlItemDesc.SelectedValue = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblItemId"), Label).Text
        txtQuantity.Text = CType(GridView2.Rows(e.NewEditIndex).FindControl("lblQty"), Label).Text
        ViewState("ID") = CType(GridView2.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
        AddMaterial.id = ViewState("ID")
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
End Class
