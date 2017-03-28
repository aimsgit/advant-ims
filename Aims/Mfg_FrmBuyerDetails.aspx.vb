
Imports System.IO
Imports System.Collections.Generic
Imports System.Data
Imports System.Web.UI.WebControls.Button
Partial Class Mfg_FrmBuyerDetails
    Inherits BasePage
    Dim alt As String
    Dim idd As Integer
    Dim SB As New Mfg_BLBuyerDetails
    Dim SD As New Mfg_DLBuyerDetails
    Dim SE As New Mfg_ELBuyerDetails
    Dim dt As New DataTable
    Dim SUP As New SupplierManager
    Dim SP As New Supplier

    'code by Anchala on 08-08-12
    'method for insert and update
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        TxtName.Focus()

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try


                SE.Buyer_Name = TxtName.Text
                SE.Buyer_Code = txtcode.Text
                SE.Area = ddlArea.SelectedValue
                If Chkreg.Checked = True Then
                    SE.Registered = "Y"
                Else
                    SE.Registered = "N"
                End If
                SE.Tin = txttin.Text
                SE.CSTNo = Txtcstno.Text
                SE.DLNo = txtdlno.Text
                SE.Buyer_Address = txtAddress.Text
                SE.City = txtcity.Text
                SE.State = ddlState.SelectedValue
                SE.Contact_Person = Txtcntctp.Text
                SE.Contact_Number1 = txtcntct.Text
                SE.FaxNO = txtfaxno.Text
                SE.Email = Txtemail.Text
                SE.SE = DdlSE.SelectedValue
                If ChkSupplier.Checked = True Then
                    SE.Suplier = "Y"
                Else
                    SE.Suplier = "N"

                End If
                If Chklock.Checked = True Then
                    SE.Discountlock = "Y"

                Else
                    SE.Discountlock = "N"
                End If

                AssignEntity()

                If Txtbuyertopay.Text <> "" And txtbuyertorec.Text <> "" Then
                    msginfo.Text = "Please Enter Buyer to Pay or Buyer to Receive."
                    lblmsg.Text = ""
                    Exit Sub
                End If
                SE.OpBalanceDate = CType(txtopeningBal.Text, Date)

                If btnAdd.Text = "UPDATE" Then
                    SE.Buyer_ID = ViewState("Party_Id")
                    dt = SB.GetDuplicateSupplierMaster(SE)

                    If dt.Rows.Count > 0 Then
                        lblmsg.Text = ""
                        msginfo.Text = "Data already exists."


                    Else
                        SB.UpdateRecord(SE)
                        GVSupp.Visible = True
                        btnAdd.Text = "ADD"
                        btnView.Text = "VIEW"
                        clear()
                        msginfo.Text = ""
                        GVSupp.PageIndex = ViewState("PageIndex")
                        display()
                        lblmsg.Text = "Data Updated Successfully."
                        ChkSupplier.Enabled = True
                        display()
                    End If

                ElseIf btnAdd.Text = "ADD" Then

                    dt = SB.GetDuplicateSupplierMaster(SE)
                    If dt.Rows.Count > 0 Then
                        lblmsg.Text = ""
                        msginfo.Text = "Data already exists."

                    Else
                        SE.Buyer_ID = 0
                        SB.InsertRecord(SE)
                        btnAdd.Text = "ADD"
                        display()
                        clear()
                        msginfo.Text = ""
                        ViewState("PageIndex") = 0
                        GVSupp.PageIndex = 0
                        lblmsg.Text = "Data Saved Successfully."



                    End If
                End If
            Catch ex As Exception
                msginfo.Text = "Date is Not valid Date."
            End Try

        Else
            msginfo.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If



    End Sub
    Sub AssignEntity()
        If txtpostalcode.Text = "" Then
            SE.PostalCode = 0
        Else
            SE.PostalCode = txtpostalcode.Text
        End If
        If Txtdiscount.Text = "" Then
            SE.Discount = 0
        Else
            SE.Discount = Txtdiscount.Text
        End If
        If txtcreditbills.Text = "" Then
            SE.credit_Bills = 0
        Else
            SE.credit_Bills = txtcreditbills.Text
        End If
        If txtcreditp.Text = "" Then
            SE.Credit_Period = 0
        Else
            SE.Credit_Period = txtcreditp.Text
        End If
        If txtcreditlimitpays.Text = "" Then
            SE.Credit_Limit = 0
        Else
            SE.Credit_Limit = txtcreditlimitpays.Text
        End If
        If Txtbuyertopay.Text = "" Then
            SE.Opening_Balance_DR = 0
        Else
            SE.Opening_Balance_DR = Txtbuyertopay.Text
        End If
        If txtbuyertorec.Text = "" Then
            SE.Opening_Balance_CR = 0
        Else
            SE.Opening_Balance_CR = txtbuyertorec.Text
        End If


    End Sub
    'code by Anchala on 08-08-12
    'method for display
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        LinkButton1.Focus()
        msginfo.Text = ""
        If btnView.Text <> "BACK" Then
            lblmsg.Text = ""
            ViewState("PageIndex") = 0
            GVSupp.PageIndex = 0
            display()
            ChkSupplier.Enabled = True

        Else
            ChkSupplier.Enabled = True
            display()
            lblmsg.Text = ""
            msginfo.Text = ""
            GVSupp.Enabled = True
            GVSupp.PageIndex = ViewState("PageIndex")
            clear()
            btnView.Text = "VIEW"
            btnAdd.Text = "ADD"
        End If
    End Sub
    'code by Anchala on 08-08-12
    'method for page indexing
    Protected Sub GVSupp_PageIndexChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVSupp.PageIndexChanging
        GVSupp.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVSupp.PageIndex
        display()
        GVSupp.DataBind()
        GVSupp.Visible = True
    End Sub
    'code by Anchala on 08-08-12
    'method for row editing
    Protected Sub GVSupp_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSupp.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("Party_Id") = CType(GVSupp.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
            TxtName.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l1"), Label).Text
            txtcode.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("ll1"), Label).Text
            If CType(GVSupp.Rows(e.NewEditIndex).FindControl("larea"), Label).Text = "" Then
                ddlArea.SelectedValue = 0
            Else
                ddlArea.SelectedValue = CType(GVSupp.Rows(e.NewEditIndex).FindControl("larea"), Label).Text
            End If

            SE.Registered = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l2"), Label).Text
            If SE.Registered = "Y" Then
                Chkreg.Checked = True
            Else
                Chkreg.Checked = False
            End If
            txttin.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l4"), Label).Text
            Txtcstno.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l5"), Label).Text
            txtAddress.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l6"), Label).Text
            txtcity.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l7"), Label).Text
            txtpostalcode.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l8"), Label).Text
            ddlState.SelectedValue = CType(GVSupp.Rows(e.NewEditIndex).FindControl("stateid"), Label).Text
            SE.Discountlock = CType(GVSupp.Rows(e.NewEditIndex).FindControl("ldlck"), Label).Text
            If SE.Discountlock = "Y" Then
                Chklock.Checked = True
            Else
                Chklock.Checked = False
            End If
            txtdlno.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l11"), Label).Text
            Txtcntctp.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l12"), Label).Text
            txtcntct.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l13"), Label).Text
            txtfaxno.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l15"), Label).Text
            Txtemail.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l16"), Label).Text
            txtcreditp.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l17"), Label).Text
            txtcreditlimitpays.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l18"), Label).Text
            Txtbuyertopay.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l19"), Label).Text
            txtbuyertorec.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l20"), Label).Text
            If Txtbuyertopay.Text = "0.00" Then
                Txtbuyertopay.Text = ""
            End If
            If txtbuyertorec.Text = "0.00" Then
                txtbuyertorec.Text = ""
            End If
            If DdlSE.SelectedValue = "0" Then
                DdlSE.SelectedValue = SE.SE
            Else
                DdlSE.SelectedValue = CType(GVSupp.Rows(e.NewEditIndex).FindControl("lse"), Label).Text
            End If
            ChkSupplier.Enabled = False
            txtopeningBal.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l21"), Label).Text
            txtcreditbills.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("lbills"), Label).Text
            Txtdiscount.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("lblGVDiscount"), Label).Text
            ViewState("Party_Id") = CType(GVSupp.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
            btnAdd.Text = "UPDATE"
            SE.Buyer_ID = ViewState("Party_Id")
            SE.Buyer_Name = TxtName.Text
            SE.Buyer_Code = txtcode.Text
            dt = SB.GetBuyerDetails(SE)
            GVSupp.DataSource = dt
            GVSupp.DataBind()
            e.Cancel = True
            ChkSupplier.Enabled = False
            GVSupp.Enabled = False
            btnView.Text = "BACK"
            btnView.Visible = True

        Else
            msginfo.Text = "You do not belong to this branch, Cannot edit data."
            lblmsg.Text = ""
        End If
    End Sub
    'code by Anchala on 08-08-12
    'method for deleting
    Protected Sub GVSupp_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSupp.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Party_Id") = CType(GVSupp.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            SE.Buyer_ID = ViewState("Party_Id")
            SB.DeleteRecord(SE.Buyer_ID)
            lblmsg.Text = "Data Deleted Successfully."
            display()
            TxtName.Focus()
            GVSupp.PageIndex = ViewState("PageIndex")
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If

    End Sub
    'code by Anchala on 08-08-12
    'method for display 
    Sub display()
        SE.Buyer_ID = 0
        SE.Buyer_Name = TxtName.Text
        SE.Buyer_Code = txtcode.Text
        dt = SB.GetBuyerDetails(SE)
        If dt.Rows.Count <> 0 Then
            GVSupp.DataSource = dt
            GVSupp.DataBind()
            GVSupp.Visible = True
            GVSupp.Enabled = True
        Else
            lblmsg.Text = ""
            msginfo.Text = "No Records to display."
            GVSupp.Visible = False
        End If
    End Sub
    Sub clear()
        Txtbuyertopay.Text = ""
        txtbuyertorec.Text = ""
        txtAddress.Text = ""
        txtcreditlimitpays.Text = ""
        txtcode.Text = ""
        Txtcntctp.Text = ""
        txtcreditp.Text = ""
        TxtName.Text = ""
        txtopeningBal.Text = ""
        txttin.Text = ""
        Txtcstno.Text = ""
        txtcity.Text = ""
        Chkreg.Checked = False
        txtpostalcode.Text = ""
        Txtdiscount.Text = ""
        txtcntct.Text = ""
        txtfaxno.Text = ""
        Txtemail.Text = ""
        txtdlno.Text = ""
        txtcreditbills.Text = ""
        Chklock.Checked = False
        ChkSupplier.Checked = False


    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        TxtName.Focus()
        lblmsg.Text = ""
        msginfo.Text = ""
        If Not IsPostBack Then
            txtopeningBal.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
        End If
    End Sub
    <System.Web.Services.WebMethod()> _
   Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

    Protected Sub Chklock_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Chklock.CheckedChanged
        SE.Discountlock = Chklock.Checked
        If SE.Discountlock = True Then
            Txtdiscount.Enabled = False
            Txtdiscount.Text = ""
            txtcreditbills.Focus()

        Else
            Txtdiscount.Enabled = True
            Txtdiscount.Focus()
        End If

    End Sub
End Class
