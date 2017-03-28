
Partial Class Mfg_FrmStockReturn
    Inherits BasePage
    Dim dt As DataTable
    Dim EL As New Mfg_ELStockReturn
    Dim BLL As New Mfg_BLStockReturn
    Dim DLL As New Mfg_DLStockReturn
    Sub CheckAll()
        If CType(GridStockReturnM.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            For Each grid As GridViewRow In GridStockReturnM.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = True
            Next
        Else
            For Each grid As GridViewRow In GridStockReturnM.Rows
                CType(grid.FindControl("ChkRL"), CheckBox).Checked = False
            Next
        End If
    End Sub

    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click

        TabContainer1.ActiveTab = TabPanel2
        EL.ReturnNo = txtReturnNo.Text
        lblGreen.Text = ""
        lblRed.Text = ""
        lblGreenM.Text = ""
        lblRedM.Text = ""

    End Sub
    Protected Sub btnAdddet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdddet.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                'If ViewState("PostStatus") <> "Posted" Then
                EL.IssueNo = DdlIssueNo.SelectedValue
                EL.ItemDesc = ddlItemDesc.SelectedValue
                EL.ChallanNo = txtChallanNO.Text
               
                EL.BatchId = ddlBatch.SelectedValue
                EL.Qty = txtQty.Text
                EL.ReturnNo = txtReturnNo.Text
                If CInt(txtQty.Text) > CInt(txtQtyIssued.Text) Then
                    lblRed.Text = "Quantity Issued should be greater than Quantity"
                    Exit Sub
                End If

                If btnAdddet.Text = "ADD" Then
                    BLL.Insertrecord(EL)
                    lblGreen.Text = "Data Saved Successfully."
                    lblRed.Text = ""
                    clearS()

                    displayDetails()
                ElseIf btnAdddet.Text = "UPDATE" Then
                    If CInt(txtQty.Text) > CInt(txtQtyIssued.Text) Then
                        lblRed.Text = "Quantity Issued should be greater than Quantity"
                        Exit Sub
                    End If
                    If ViewState("PostStatusDet") = "Y" Then
                        lblRed.Text = "Record is already Posted, so data cannot be Updated."
                        lblGreen.Text = ""
                    Else
                        EL.PID = ViewState("StockReturn_Id")
                        BLL.UpdateRecord(EL)
                        lblGreen.Text = "Data Updated Successfully."
                        lblRed.Text = ""
                        displayDetails()
                        clearS()
                        btnAdddet.Text = "ADD"
                        BtnViewDetails.Text = "VIEW"
                    End If

                    End If

            Catch ex As Exception
            lblRed.Text = "Enter Correct Data"
            lblGreen.Text = ""
        End Try
        Else
        lblRed.Text = "You do not belong to this branch, Cannot add/update data."
        lblGreen.Text = ""
        End If
    End Sub

    Protected Sub BtnViewDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnViewDetails.Click
        If BtnViewDetails.Text = "VIEW" Then
            EL.id = 0
            EL.ReturnNo = txtReturnNo.Text
            lblGreen.Text = ""
            lblRed.Text = ""
            ViewState("PageIndex") = 0
            displayDetails()
            'clearS()

        Else
            EL.id = 0
            displayDetails()
            lblGreen.Text = ""
            lblRed.Text = ""
            GVSRDetails.PageIndex = ViewState("PageIndex")
            btnAdddet.Text = "ADD"
            BtnViewDetails.Text = "VIEW"
            'ddlCurrency.SelectedValue = 0
            ViewState("PostStatusDet") = ""
            lblGreen.Text = ""
            lblRed.Text = ""
         

         

        End If
        clearS()


    End Sub
    <System.Web.Services.WebMethod()> _
 Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub
    Public Sub displayDetails()
        'If HidReturnId.Text = "" Then
        lblGreen.Text = ""
        lblRed.Text = ""
        GVSRDetails.Visible = False
        'Else
        'EL.HidPurchaseReturnId = HidReturnId.Text
        EL.id = 0
        EL.ReturnNo = txtReturnNo.Text
        dt = BLL.GetStockReturnDetails(EL)
        If dt.Rows.Count > 0 Then
            GVSRDetails.Enabled = True
            GVSRDetails.Visible = True
            GVSRDetails.DataSource = dt
            GVSRDetails.DataBind()

        Else
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
            GVSRDetails.Visible = False
        End If
        'End If
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        TabContainer1.ActiveTab = TabPanel1
        TabPanel1.Enabled = True
        GVSRDetails.Visible = "false"
        lblRed.Text = ""
        lblGreen.Text = ""
        lblGreenM.Text = ""
        lblRedM.Text = ""
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                EL.PartyType = cmbPType.SelectedValue
                EL.Party = ddlPName.SelectedValue
                EL.WorkOrder = ddlWorkOrder.SelectedValue
                If HidReturnId.Text = "" Then
                    EL.ReturnId = 0
                Else
                    EL.ReturnId = HidReturnId.Text
                End If
                EL.Remarks = txtRemaks.Text
                If txtReturnDate.Text = "" Then
                    EL.ReturnDate = "01/01/1900"
                Else
                    EL.ReturnDate = txtReturnDate.Text
                End If
                EL.ReturnNo = txtReturnNo.Text

                If btnAdd.Text = "ADD" Then

                    BLL.insert(EL)
                    lblGreenM.Text = "Data Saved Successfully."
                    lblRedM.Text = ""
                    DispGridM()
                    Clear()
                    HidReturnId.Text = ""
                    txtReturnNo.Text = ""
                    GetStockReturnNo()

                ElseIf btnAdd.Text = "UPDATE" Then
                    If ViewState("PostStatusMain") = "Posted" Then
                        lblRedM.Text = "Record is already Posted, so data cannot be Updated."
                        lblGreenM.Text = ""
                    Else

                        EL.id = ViewState("StockReturn_Id")

                        BLL.update(EL)
                        lblGreenM.Text = "Data Updated Successfully."
                        lblRedM.Text = ""
                        btnAdd.Text = "ADD"
                        BtnView.Text = "VIEW"
                        DispGridM()
                        Clear()
                        GetStockReturnNo()
                        HidReturnId.Text = ""
                        txtReturnNo.Text = ""
                        ViewState("PostStatusMain") = ""
                        btnAdddet.Enabled = True
                    End If


                End If
            Catch ex As Exception
                lblRedM.Text = "Enter Correct Data"
                lblGreenM.Text = ""
            End Try
        Else
            lblRedM.Text = "You do not belong to this branch, Cannot add/update data."
            lblGreenM.Text = ""
        End If
    End Sub
    Public Sub DispGridM()
        EL.id = 0

        dt = BLL.GetStockReturnM(EL)
        If dt.Rows.Count > 0 Then
            GridStockReturnM.Enabled = True
            GridStockReturnM.Visible = True
            GridStockReturnM.DataSource = dt
            GridStockReturnM.DataBind()

        Else
            lblGreenM.Text = ""
            lblRedM.Text = "No records to display."
            GridStockReturnM.Visible = False
        End If
    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        If BtnView.Text = "VIEW" Then
            GridStockReturnM.Enabled = True
            lblGreenM.Text = " "
            lblRedM.Text = " "
            ViewState("PageIndex") = 0
            GridStockReturnM.PageIndex = 0
            DispGridM()
            'Clear()
        ElseIf BtnView.Text = "BACK" Then
            GridStockReturnM.Enabled = True
            txtReturnNo.Enabled = True
            lblGreenM.Text = " "
            lblRedM.Text = " "
            ViewState("PageIndex") = 0
            GridStockReturnM.PageIndex = 0
            HidReturnId.Text = ""
            txtReturnNo.Text = ""
            DispGridM()
            btnAdd.Text = "ADD"
            BtnView.Text = "VIEW"
            Clear()
            ViewState("PostStatusMain") = ""
            btnAdddet.Enabled = True
            GridStockReturnM.PageIndex = ViewState("PageIndex")
          GetStockReturnNo()
            txtReturnDate.Text = Format(Today, "dd-MMM-yyyy")

        End If
    End Sub

    Protected Sub GridStockReturnM_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridStockReturnM.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("PostStatusMain") = CType(GridStockReturnM.Rows(e.RowIndex).FindControl("lblGVPost"), Label).Text
            If ViewState("PostStatusMain") = "Posted" Then
                lblRedM.Text = "Record is already Posted, so data cannot be Deleted."
                lblGreenM.Text = ""
                ViewState("PostStatusMain") = ""
            Else
                EL.id = CType(GridStockReturnM.Rows(e.RowIndex).FindControl("ID"), HiddenField).Value
                BLL.DeleteStockReturn(EL)
                GridStockReturnM.DataBind()
                'lblGreen.Visible = True

                Clear()
                GridStockReturnM.PageIndex = ViewState("PageIndex")
                DispGridM()
                lblRedM.Text = " "
                lblGreenM.Text = "Data Deleted Successfully."
                ViewState("PostStatusMain") = ""
            End If
        Else
            lblRedM.Text = "You do not belong to this branch, Cannot delete data."
            lblGreenM.Text = ""
        End If
    End Sub
    Protected Sub GridStockReturnM_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridStockReturnM.RowEditing

        Try
            ViewState("PostStatusMain") = CType(GridStockReturnM.Rows(e.NewEditIndex).FindControl("lblGVPost"), Label).Text
            lblRedM.Text = ""
            lblGreenM.Text = ""
            ViewState("StockReturn_Id") = CType(GridStockReturnM.Rows(e.NewEditIndex).FindControl("ID"), HiddenField).Value

            HidReturnId.Text = CType(GridStockReturnM.Rows(e.NewEditIndex).FindControl("lblReturnId"), Label).Text
            cmbPType.SelectedValue = CType(GridStockReturnM.Rows(e.NewEditIndex).FindControl("lblPartyTypeId"), Label).Text
            ddlPName.Items.Clear()
            ddlPName.DataSourceID = "ObjParty_Name"
            ddlPName.DataBind()
            ddlPName.SelectedValue = CType(GridStockReturnM.Rows(e.NewEditIndex).FindControl("lblPartyId"), Label).Text
            txtReturnNo.Text = CType(GridStockReturnM.Rows(e.NewEditIndex).FindControl("lblReturnNo"), Label).Text
            txtReturnDate.Text = CType(GridStockReturnM.Rows(e.NewEditIndex).FindControl("lblStockReturnDate"), Label).Text
            txtRemaks.Text = CType(GridStockReturnM.Rows(e.NewEditIndex).FindControl("lblRemarksGV"), Label).Text
            EL.id = ViewState("StockReturn_Id")
            dt = BLL.GetStockReturnM(EL)
            GridStockReturnM.DataSource = dt
            GridStockReturnM.DataBind()
            GridStockReturnM.Enabled = False
            GridStockReturnM.Visible = True
            btnAdd.Text = "UPDATE"
            BtnView.Text = "BACK"
            If ViewState("PostStatusMain") = "Posted" Then
                btnAdddet.Enabled = False
            End If
            txtReturnNo.Enabled = False
        Catch ex As Exception
            lblRedM.Text = "Enter Correct Data"
            lblGreenM.Text = ""
        End Try

    End Sub

    Public Sub Clear()
        txtReturnDate.Text = Format(Today, "dd-MMM-yyyy")
        txtRemaks.Text = ""
        HidReturnId.Text = ""
        ddlWorkOrder.SelectedValue = 0
        ddlPName.SelectedValue = 0
        cmbPType.SelectedValue = 0
    End Sub
    Public Sub clearS()

        DdlIssueNo.SelectedValue = 0
        ddlItemDesc.SelectedValue = 0
        ddlBatch.SelectedValue = 0
        txtQtyIssued.Text = ""
        txtChallanNO.Text = ""
        txtQty.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            dt = BLL.GetStockReturnNo(EL)
            txtReturnNo.Text = dt.Rows(0).Item("StockReturnNo")
            txtReturnDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub

    Protected Sub DdlIssueNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlIssueNo.SelectedIndexChanged
        Dim Ch As New DataTable
        Ch = Mfg_DLStockReturn.GetChallanNo(DdlIssueNo.SelectedValue)
        If Ch.Rows.Count > 0 Then
            txtChallanNO.Text = Ch.Rows(0).Item("DCNo").ToString
        Else
            txtChallanNO.Text = ""
        End If

    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        Dim Qty As New DataTable
        Qty = Mfg_DLStockReturn.GetQtyIssued(DdlIssueNo.SelectedValue, ddlItemDesc.SelectedValue, ddlBatch.SelectedValue)
        If Qty.Rows.Count > 0 Then
            txtQtyIssued.Text = Qty.Rows(0).Item("Quantity").ToString
        Else
            txtQtyIssued.Text = ""
        End If
    End Sub

    Protected Sub GVSRDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSRDetails.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("PostStatusDet") = CType(GVSRDetails.Rows(e.RowIndex).FindControl("lblPost"), Label).Text
            If ViewState("PostStatusDet") = "Y" Then
                lblRed.Text = "Record is already Posted, so data cannot be Deleted."
                lblGreen.Text = ""
                ViewState("PostStatusDet") = ""
            Else

                EL.id = CType(GVSRDetails.Rows(e.RowIndex).FindControl("ID"), Label).Text
                BLL.DeleteStockReturnD(EL)
                GVSRDetails.DataBind()
                'lblGreen.Visible = True

                Clear()
                GridStockReturnM.PageIndex = ViewState("PageIndex")
                displayDetails()
                lblRed.Text = " "
                lblGreen.Text = "Data Deleted Successfully."
            End If

        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub GVSRDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSRDetails.RowEditing
        Try
            lblRed.Text = ""
            lblGreen.Text = ""
            ViewState("StockReturn_Id") = CType(GVSRDetails.Rows(e.NewEditIndex).FindControl("ID"), Label).Text
            ViewState("PostStatusDet") = CType(GVSRDetails.Rows(e.NewEditIndex).FindControl("lblPost"), Label).Text
            DdlIssueNo.SelectedValue = CType(GVSRDetails.Rows(e.NewEditIndex).FindControl("GVStockIssueID"), Label).Text
            Dim Ch As New DataTable
            Ch = Mfg_DLStockReturn.GetChallanNo(DdlIssueNo.SelectedValue)
            If Ch.Rows.Count > 0 Then
                txtChallanNO.Text = Ch.Rows(0).Item("DCNo").ToString
            Else
                txtChallanNO.Text = ""
            End If


            ddlItemDesc.Items.Clear()
            ddlItemDesc.DataSourceID = "ObjBatch"
            ddlItemDesc.DataBind()

            ddlItemDesc.SelectedValue = CType(GVSRDetails.Rows(e.NewEditIndex).FindControl("lblItemDescID"), Label).Text
            ddlBatch.Items.Clear()
            ddlBatch.ClearSelection()
            ddlBatch.DataSourceID = "ObjBatch1"
            ddlBatch.DataBind()
            ddlBatch.SelectedValue = CType(GVSRDetails.Rows(e.NewEditIndex).FindControl("lblbatchid"), Label).Text
            Dim Qty As New DataTable
            Qty = Mfg_DLStockReturn.GetQtyIssued(DdlIssueNo.SelectedValue, ddlItemDesc.SelectedValue, ddlBatch.SelectedValue)
            If Qty.Rows.Count > 0 Then
                txtQtyIssued.Text = Qty.Rows(0).Item("Quantity").ToString
            Else
                txtQtyIssued.Text = ""
            End If
            txtQty.Text = CType(GVSRDetails.Rows(e.NewEditIndex).FindControl("GVqty"), Label).Text
            EL.ReturnNo = txtReturnNo.Text
            EL.id = ViewState("StockReturn_Id")
            EL.ReturnNo = txtReturnNo.Text
            dt = BLL.GetStockReturnDetails(EL)
            GVSRDetails.DataSource = dt
            GVSRDetails.DataBind()
            GVSRDetails.Enabled = False
            GVSRDetails.Visible = True
            btnAdddet.Text = "UPDATE"
            BtnViewDetails.Text = "BACK"
        Catch ex As Exception
            lblRed.Text = "Enter Correct Data"
            lblGreen.Text = ""
        End Try
    End Sub
    Protected Sub btnPost_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim Count As Integer = 0

        For Each Grid As GridViewRow In GridStockReturnM.Rows
            If CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                Count = Count + 1
            End If
        Next

        If Count = 0 Then
            lblRedM.Text = "Please select a Record to Post."
            lblGreenM.Text = ""
            Exit Sub
        End If



        For Each Grid As GridViewRow In GridStockReturnM.Rows
            If CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True And CType(Grid.FindControl("lblGVPost"), Label).Text = "Not Posted" Then
                EL.ReturnId = CType(Grid.FindControl("ID"), HiddenField).Value
                BLL.PostToStockReturn(EL)
                lblGreenM.Text = "Record Posted Successfully."
                lblRedM.Text = ""
            ElseIf CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True And CType(Grid.FindControl("lblGVPost"), Label).Text = "Posted" Then
                lblRedM.Text = "Record is already Posted."
                lblGreenM.Text = ""
            End If
        Next

        DispGridM()
    End Sub
    Sub GetStockReturnNo()

        dt = BLL.GetStockReturnNo(EL)
        txtReturnNo.Text = dt.Rows(0).Item("StockReturnNo")
    End Sub
    Protected Sub BtnPrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Dim Count As Integer = 0

        For Each Grid As GridViewRow In GridStockReturnM.Rows
            If CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                Count = Count + 1
            End If
        Next

        If Count = 0 Then
            lblRedM.Text = "Please select a Record to Print Return Note."
            lblGreenM.Text = ""
            Exit Sub
        ElseIf Count > 1 Then
            lblRedM.Text = "Please select only one Record to Print Return Note."
            lblGreenM.Text = ""
            Exit Sub
        End If


        For Each Grid As GridViewRow In GridStockReturnM.Rows
            If CType(Grid.FindControl("ChkRL"), CheckBox).Checked = True Then
                EL.ReturnNo = CType(Grid.FindControl("lblReturnNo"), Label).Text
                Dim qrystring As String = "Mfg_RptStockReturnNoteV.aspx?" & QueryStr.Querystring() & "&ReturnNo=" & EL.ReturnNo
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                lblGreenM.Text = ""
                lblRedM.Text = ""
            End If
        Next
    End Sub
End Class
