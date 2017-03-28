
Partial Class Mfg_FrmPurchaseRequisition
    Inherits BasePage
    Dim el As New ELPurchaseRequisition
    Dim bl As New BLPurchaseRequisition
    Dim dl As New DLPurchaseRequisition
    Dim dt As New DataTable

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim b As New CreateBatch
            el.PurchaseReq_No = txtPurchaseReqNo.Text
            el.Product_Id = DDLProduct.SelectedValue
            el.Unit_Id = ddlUnit.SelectedValue
            el.Quantity = txtQty.Text
            el.Status = ddlstatus.SelectedValue
            If btnSave.Text = "UPDATE" Then
                el.id = ViewState("Id")
                bl.UpdateRecord(el)
                btnSave.Text = "ADD"
                btnDetails.Text = "VIEW"
                Clear()
                GvPruchaseReq.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                lblerrmsg.Text = ""
                lblmsgifo.Text = "Data Updated Successfully."

            ElseIf btnSave.Text = "ADD" Then
                bl.InsertRecord(el)
                lblerrmsg.Text = ""
                ViewState("PageIndex") = 0
                GvPruchaseReq.PageIndex = 0
                DisplayGrid()
                Clear()
                lblerrmsg.Text = ""
                lblmsgifo.Text = "Data Saved Successfully."
            End If
            dt = bl.GetPONo()
            txtPurchaseReqNo.Text = dt.Rows(0).Item("PurchNo")
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add data."
            lblmsgifo.Text = ""
        End If
    End Sub
    Sub Clear()
        txtQty.Text = ""
    End Sub
    Sub DisplayGrid()
        el.id = 0
        dt = bl.GetRecord(el)
        If dt.Rows.Count = 0 Then
            GvPruchaseReq.DataSource = Nothing
            GvPruchaseReq.DataBind()
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
        Else
            GvPruchaseReq.DataSource = dt
            GvPruchaseReq.DataBind()
            GvPruchaseReq.Enabled = True
            GvPruchaseReq.Visible = True
        End If
    End Sub

    Protected Sub Btnposttostock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnposttostock.Click
        Try
            Dim id As String = ""
            Dim check As String = ""
            Dim Count1 As Integer = 0
            For Each Grid As GridViewRow In GvPruchaseReq.Rows
                If CType(Grid.FindControl("ChkPO"), CheckBox).Checked = True Then
                    check = CType(Grid.FindControl("IID"), HiddenField).Value
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
                bl.PostRequest(id)
                lblmsgifo.Text = "Request Sent Successfuly."
                lblerrmsg.Text = ""
                DisplayGrid()
            Else
                lblerrmsg.Text = "Please select the record(s) to Request Sent."
                lblmsgifo.Text = ""
            End If

        Catch ex As Exception
            lblerrmsg.Text = "Please Enter Correct Data."
            lblmsgifo.Text = ""
        End Try
    End Sub
    Sub CheckAll()
        If CType(GvPruchaseReq.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GvPruchaseReq.Rows
                CType(grid.FindControl("ChkPO"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GvPruchaseReq.Rows
                CType(grid.FindControl("ChkPO"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub GvPruchaseReq_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvPruchaseReq.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("id") = CType(GvPruchaseReq.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            el.id = ViewState("Id")
            If bl.DeleteRecord(el.id) Then
                lblerrmsg.Text = ""
                lblmsgifo.Text = "Data Deleted Successfully."

                GvPruchaseReq.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                GvPruchaseReq.Enabled = True
            End If
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        lblmsgifo.Text = ""
        lblerrmsg.Text = ""
        If btnDetails.Text = "VIEW" Then
            DisplayGrid()
            Clear()
        Else
            DisplayGrid()
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            Clear()

        End If
        dt = bl.GetPONo()
        txtPurchaseReqNo.Text = dt.Rows(0).Item("PurchNo")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            dt = bl.GetPONo()
            txtPurchaseReqNo.Text = dt.Rows(0).Item("PurchNo")
        End If
    End Sub

    Protected Sub GvPruchaseReq_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvPruchaseReq.RowEditing
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        btnSave.Text = "UPDATE"
        btnDetails.Text = "BACK"
        GvPruchaseReq.Visible = True
        ViewState("Id") = CType(GvPruchaseReq.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        txtPurchaseReqNo.Text = CType(GvPruchaseReq.Rows(e.NewEditIndex).FindControl("lblPurchNo"), Label).Text
        DDLProduct.SelectedValue = CType(GvPruchaseReq.Rows(e.NewEditIndex).FindControl("ProductId"), Label).Text
        ddlUnit.SelectedValue = CType(GvPruchaseReq.Rows(e.NewEditIndex).FindControl("lblUnitId"), Label).Text
        txtQty.Text = CType(GvPruchaseReq.Rows(e.NewEditIndex).FindControl("lblQuantity"), Label).Text
        ddlstatus.SelectedValue = CType(GvPruchaseReq.Rows(e.NewEditIndex).FindControl("lblStatus"), Label).Text
        el.id = ViewState("Id")
        dt = bl.GetRecord(el)
        GvPruchaseReq.DataSource = dt
        GvPruchaseReq.DataBind()
        GvPruchaseReq.Enabled = False
        GvPruchaseReq.Visible = True
        'lblGreen.Visible = True
        'Else
        'lblRed.Text = "You do not belong to this branch, Cannot edit data."
        'lblGreen.Text = ""
        'End If
    End Sub
End Class
