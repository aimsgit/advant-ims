
Partial Class Mfg_FrmPurchaseRequisitionNew
    Inherits BasePage
    Dim el As New ELPurchaseRequisition
    Dim bl As New BLPurchaseRequisition
    Dim dl As New DLPurchaseRequisition
    Dim dt As New DataTable
    Dim HidValue As String

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            txtDate.Text = Format(Today, "dd-MMM-yyyy")
            dt = bl.GetPONo()
            txtPurchaseReqNo.Text = dt.Rows(0).Item("PurchNo")
        End If
    End Sub

    Protected Sub BtnAddDtls_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddDtls.Click
        GVPRDetails.Visible = False
        AddDetails.Visible = True
        msginfo.Text = ""
        lblmsg.Text = ""
        HidValue = txtPurchaseReqNo.Text
    End Sub
    Sub DisplayGrid()
        el.id = 0
        el.PurchaseReq_No = txtPurchaseReqNo.Text
        dt = bl.GetRecord(el)
        If dt.Rows.Count = 0 Then
            GVPRDetails.DataSource = Nothing
            GVPRDetails.DataBind()
            lblmsg2.Text = ""
            msginfo2.Text = "No records to display."
        Else
            GVPRDetails.DataSource = dt
            GVPRDetails.DataBind()
            GVPRDetails.Enabled = True
            GVPRDetails.Visible = True
        End If
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

    Protected Sub BtnADD2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnADD2.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim b As New CreateBatch
            If ViewState("Posted") = "Submited" Then
                msginfo2.Text = "Submitted Record cannot Update."
                lblmsg2.Text = ""
                Exit Sub
            End If
            el.PurchaseReq_No = txtPurchaseReqNo.Text
            el.Product_Id = DDLProduct.SelectedValue
            el.Unit_Id = ddlUnit.SelectedValue
            el.Quantity = txtQty.Text
            el.Status = ddlstatus.SelectedValue
            If BtnADD2.Text = "UPDATE" Then
                If ViewState("Posted") = "Submited" Then
                    msginfo2.Text = "Submitted Record cannot Update."
                    lblmsg2.Text = ""
                    Exit Sub
                End If
                el.id = ViewState("Id")
                bl.UpdateRecord(el)
                BtnADD2.Text = "ADD"
                BtnViewProduct.Text = "VIEW"
                GvPruchaseReq.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                msginfo2.Text = ""
                lblmsg2.Text = "Record Updated Successfully."
                Clear()
            ElseIf BtnADD2.Text = "ADD" Then
                bl.InsertRecord(el)
                msginfo2.Text = ""
                ViewState("PageIndex") = 0
                GvPruchaseReq.PageIndex = 0
                DisplayGrid()
                Clear()
                msginfo2.Text = ""
                lblmsg2.Text = "Record Saved Successfully."
                Clear()
            End If
            DDLProduct.Focus()
        Else
            msginfo2.Text = "You do not belong to this branch, Cannot add Record."
            lblmsg2.Text = ""
        End If
    End Sub
    Sub Clear()
        txtQty.Text = ""
    End Sub
    Protected Sub BtnViewProduct_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnViewProduct.Click
        lblmsg2.Text = ""
        msginfo2.Text = ""
        If BtnViewProduct.Text = "VIEW" Then
            DisplayGrid()
            Clear()
        Else
            DisplayGrid()
            BtnADD2.Text = "ADD"
            BtnViewProduct.Text = "VIEW"
            Clear()
            DDLProduct.Focus()

        End If
    End Sub
    Sub displaygridview2()
        el.id = 0
        dt = bl.GetRecord1(el)
        If dt.Rows.Count = 0 Then
            GvPruchaseReq.DataSource = Nothing
            GvPruchaseReq.DataBind()
            lblmsg2.Text = ""
            msginfo2.Text = "No records to display."
        Else
            GvPruchaseReq.DataSource = dt
            GvPruchaseReq.DataBind()
            GV1Panel.Visible = True
            GvPruchaseReq.Enabled = True
            GvPruchaseReq.Visible = True
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim dt1 As New DataTable
            If btnAdd.Text = "ADD" Then
                el.PurchaseReq_No = txtPurchaseReqNo.Text
                el.Status = ddlstatus.SelectedValue
                el.Reqdate = txtDate.Text
                dt1 = bl.getProductforPurchaseReq(el)
                If dt1.Rows.Count <= 0 Then
                    msginfo.Text = "Enter Product First."
                    lblmsg.Text = ""
                    GVPRDetails.Visible = False
                    Exit Sub
                End If
                'dt = bl.DuplicatePurchaseOrder(el)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Record already exist."
                    lblmsg.Text = ""
                Else
                    bl.InsertRecord1(el)
                    lblmsg.Text = "Record saved Successfully."
                    AddDetails.Visible = False
                    GVPRDetails.Visible = False
                    msginfo.Text = ""
                    el.id = 0
                    displaygridview2()
                    Clear()
                End If
            ElseIf btnAdd.Text = "UPDATE" Then
                el.PurchaseReq_No = ViewState("PostStatus")
                'dt = bl.PostStatus(el)
                'If dt.Rows(0).Item("Posted_To_Stock") = "Y" Then
                '    msginfo.Text = "Cannot update, Record already posted."
                '    lblmsg.Text = ""
                '    Exit Sub
                'End If
                el.PurchaseReq_No = txtPurchaseReqNo.Text
                el.Status = ddlstatus.SelectedValue
                el.Reqdate = txtDate.Text
                el.id = ViewState("Id1")
                'dt = bl.DuplicatePurchaseOrder(el)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Record already exist."
                    lblmsg.Text = ""
                Else
                    'If ViewState("Posted") = "Submited" Then
                    '    msginfo.Text = "Submitted Record cannot Update."
                    '    lblmsg.Text = ""
                    '    Exit Sub
                    'End If
                    el.id = ViewState("Id1")
                    bl.UpdateRecord1(el)
                    displaygridview2()
                    lblmsg.Text = "Record updated Successfully."
                    msginfo.Text = ""
                    el.id = 0
                    btnAdd.Text = "ADD"
                    btnView.Text = "VIEW"
                    GVPRDetails.Visible = False
                    GvPruchaseReq.Enabled = True
                    txtPurchaseReqNo.Enabled = True
                    btnPost.Enabled = True
                    Clear()

                    txtPurchaseReqNo.Enabled = True
                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete Record."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        If btnView.Text = "VIEW" Then
            displaygridview2()
            Clear()
        Else
            displaygridview2()
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
            Clear()
            DDLProduct.Focus()
            ViewState("Posted") = ""
            AddDetails.Visible = False
            GVPRDetails.Visible = False
            GV1Panel.Visible = True
            GvPruchaseReq.Visible = True
            lblmsg.Text = ""
            msginfo.Text = ""
            lblmsg2.Text = ""
            msginfo.Text = ""
        End If
        dt = bl.GetPONo()
        txtPurchaseReqNo.Text = dt.Rows(0).Item("PurchNo")
    End Sub

    Protected Sub GVPRDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVPRDetails.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Id") = CType(GVPRDetails.Rows(e.RowIndex).Cells(1).FindControl("IID1"), HiddenField).Value
            el.id = ViewState("Id")
            'dt = bl.checkSubmit(el)
            'If dt.Rows(0).Item("Post_To_Stock") = "N" Then

            If ViewState("Posted") = "Submited" Then
                msginfo2.Text = "Submitted Record cannot delete."
                lblmsg2.Text = ""
                Exit Sub
            End If
            If bl.DeleteRecord(el.id) Then
                msginfo2.Text = ""
                lblmsg2.Text = "Data Deleted Successfully."
                GvPruchaseReq.PageIndex = ViewState("PageIndex")
                DisplayGrid()
                GvPruchaseReq.Enabled = True
                'End If
            Else
                msginfo2.Text = "Submitted record cannot be deleted."
                lblmsg2.Text = ""
            End If
        Else
            msginfo2.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg2.Text = ""
        End If
    End Sub

    Protected Sub GVPRDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVPRDetails.RowEditing
        msginfo2.Text = ""
        lblmsg2.Text = ""
        BtnADD2.Text = "UPDATE"
        BtnViewProduct.Text = "BACK"
        GVPRDetails.Visible = True
        ViewState("Id") = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("IID1"), HiddenField).Value
        DDLProduct.SelectedValue = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("ProductId"), Label).Text
        ddlUnit.SelectedValue = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("lblUnitId"), Label).Text
        txtQty.Text = CType(GVPRDetails.Rows(e.NewEditIndex).FindControl("lblQuantity"), Label).Text
        el.id = ViewState("Id")
        el.PurchaseReq_No = txtPurchaseReqNo.Text
        dt = bl.GetRecord(el)
        GVPRDetails.DataSource = dt
        GVPRDetails.DataBind()
        GVPRDetails.Enabled = False
        GVPRDetails.Visible = True
        
    End Sub

    Protected Sub GvPruchaseReq_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvPruchaseReq.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Id1") = CType(GvPruchaseReq.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            el.id = ViewState("Id1")
            'dt = bl.checkSubmit(el)
            'If dt.Rows(0).Item("Post_To_Stock") = "N" Then
            ViewState("Posted") = CType(GvPruchaseReq.Rows(e.RowIndex).Cells(1).FindControl("lblPostStatus"), Label).Text
            If ViewState("Posted") = "Submited" Then
                msginfo.Text = "Submitted Record cannot Update."
                lblmsg.Text = ""
                Exit Sub
            End If
            If bl.DeleteRecord1(el.id) Then
                msginfo.Text = ""
                lblmsg.Text = "Data Deleted Successfully."
                GvPruchaseReq.PageIndex = ViewState("PageIndex")
                displaygridview2()
                GvPruchaseReq.Enabled = True
                'End If
            Else
                msginfo.Text = "Submitted record cannot be deleted."
                lblmsg.Text = ""
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GvPruchaseReq_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvPruchaseReq.RowEditing
        msginfo2.Text = ""
        lblmsg2.Text = ""
        
        GV1Panel.Visible = True
        GvPruchaseReq.Visible = True
        ViewState("Id1") = CType(GvPruchaseReq.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        txtPurchaseReqNo.Text = CType(GvPruchaseReq.Rows(e.NewEditIndex).FindControl("lblPurchNo"), Label).Text
        txtDate.Text = CType(GvPruchaseReq.Rows(e.NewEditIndex).FindControl("lblDate"), Label).Text
        ddlstatus.SelectedValue = CType(GvPruchaseReq.Rows(e.NewEditIndex).FindControl("lblStatus"), Label).Text
        ViewState("Posted") = CType(GvPruchaseReq.Rows(e.NewEditIndex).FindControl("lblPostStatus"), Label).Text
        el.id = ViewState("Id1")
        dt = bl.GetRecord1(el)
        GvPruchaseReq.DataSource = dt
        GvPruchaseReq.DataBind()
        GvPruchaseReq.Enabled = False
        GvPruchaseReq.Visible = True
        btnAdd.Text = "UPDATE"
        btnView.Text = "BACK"
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        AddDetails.Visible = False
        GVPRDetails.Visible = False
        GV1Panel.Visible = True
        GvPruchaseReq.Visible = True
        lblmsg.Text = ""
        msginfo.Text = ""
        lblmsg2.Text = ""
        msginfo.Text = ""
    End Sub

    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
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
                lblmsg.Text = "Request Sent Successfully."
                msginfo.Text = ""
                displaygridview2()
            Else
                msginfo.Text = "Please select the record(s) to send request."
                lblmsg.Text = ""
            End If

        Catch ex As Exception
            msginfo.Text = "Please Enter Correct Data."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub DDLProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLProduct.SelectedIndexChanged
        Try
            el.Product_Id = DDLProduct.SelectedValue
            dt = bl.GetUnit(el)
            ddlUnit.SelectedValue = dt.Rows(0).Item("Case_Factor_In_Strip")
        Catch ex As Exception
            ddlUnit.SelectedValue = 0
        End Try
    End Sub
End Class
