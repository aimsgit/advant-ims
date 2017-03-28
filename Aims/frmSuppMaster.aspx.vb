Imports System.IO
Imports System.Collections.Generic
Imports System.Data
Imports System.Web.UI.WebControls.Button
Partial Class frmSuppMaster
    Inherits BasePage
    Dim alt As String
    Dim idd As Integer
    Dim SB As New SupplierManager
    Dim SD As New SupplierDB
    Dim SE As New Supplier
    Dim dt As New DataTable

    'code by Anchala on 11-08-12
    'method for insert and update
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        TxtName.Focus()

        If (Session("BranchCode") = Session("ParentBranch")) Then
            SE.Supp_Name = TxtName.Text
            SE.Supp_Code = txtcode.Text
            If Chkreg.Checked = True Then
                SE.Registered = "Y"
            Else
                SE.Registered = "N"
            End If
            SE.Tin = txttin.Text
            SE.CSTNo = txtcst.Text
            SE.Supp_Address = txtAddress.Text
            SE.City = txtcity.Text
            SE.PostalCode = txtpostalcode.Text
            SE.State = ddlState.SelectedValue
            SE.Country = txtcountry.Text
            SE.DLNo = txtdlno.Text
            SE.Contact_Number1 = txtcntct1.Text
            SE.Contactno2 = txtcntct2.Text
            SE.Contact_Person = TxtcntctP.Text
            SE.FaxNO = txtfaxno.Text
            SE.Email = txtemail.Text
            If ChkBuyer.Checked = True Then
                SE.Buyer = "Y"
            Else
                SE.Buyer = "N"
            End If
            If txtsuptorec.Text <> "" And txtsuptopay.Text <> "" Then
                If txtsuptorec.Text <> "0.00" And txtsuptopay.Text <> "0.00" Then
                    msginfo.Text = ValidationMessage(1056)
                    lblmsg.Text = ValidationMessage(1014)
                    Exit Sub
                End If
            End If
            AssignEntity()


            SE.OpBalanceDate = CType(txtopeningBal.Text, Date)
            SE.Supp_ID = ViewState("Supp_Id")
            dt = SB.GetDuplicateSupplierMaster(SE)

            If btnAdd.CommandName = "UPDATE" Then
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1030)
                Else
                    SB.UpdateRecord(SE)
                    GVSupp.Visible = True
                    btnAdd.CommandName = "ADD"
                    btnView.CommandName = "VIEW"
                    clear()
                    msginfo.Text = ValidationMessage(1014)
                    GVSupp.PageIndex = ViewState("PageIndex")
                    display()
                    lblmsg.Text = ValidationMessage(1017)
                    txtopeningBal.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
                    display()
                End If

            ElseIf btnAdd.CommandName = "ADD" Then

                dt = SB.GetDuplicateSupplierMaster(SE)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1030)

                Else
                    SB.InsertRecord(SE)
                    btnAdd.CommandName = "ADD"
                    display()
                    clear()
                    msginfo.Text = ValidationMessage(1014)
                    ViewState("PageIndex") = 0
                    GVSupp.PageIndex = 0
                    lblmsg.Text = ValidationMessage(1020)
                    txtopeningBal.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
                End If
            End If


        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If


    End Sub
    Sub AssignEntity()
        If txtcreditlimit.Text = "" Then
            SE.Credit_Limit = 0
        Else
            SE.Credit_Limit = txtcreditlimit.Text
        End If
        If txtcreditP.Text = "" Then
            SE.Credit_Period = 0.0
        Else
            SE.Credit_Period = txtcreditP.Text
        End If
        If txtsuptorec.Text = "" Then
            SE.Opening_Balance_CR = 0
        Else
            SE.Opening_Balance_CR = txtsuptorec.Text
        End If
        If txtsuptopay.Text = "" Then
            SE.Opening_Balance_DR = 0
        Else
            SE.Opening_Balance_DR = txtsuptopay.Text
        End If

        If txttin.Text = "" Then
            SE.Tin = 0
        Else
            SE.Tin = txttin.Text
        End If


    End Sub
    'code by Anchala on 11-08-12
    'method for display
    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        LinkButton1.Focus()
        msginfo.Text = ValidationMessage(1014)
        If btnView.CommandName <> "BACK" Then
            lblmsg.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GVSupp.PageIndex = 0
            display()
            ' GVSupp.Visible = True

        Else

            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            GVSupp.Enabled = True
            ChkBuyer.Enabled = True
            GVSupp.PageIndex = ViewState("PageIndex")
            clear()
            btnView.CommandName = "VIEW"
            btnAdd.CommandName = "ADD"
            display()
        End If
    End Sub
    'code by Anchala on 11-08-12
    'method for page indexing
    Protected Sub GVSupp_PageIndexChanged(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVSupp.PageIndexChanging
        GVSupp.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVSupp.PageIndex
        display()
        GVSupp.DataBind()
        GVSupp.Visible = True
      
    End Sub
    'code by Anchala on 11-08-12
    'method for row editing
    Protected Sub GVSupp_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSupp.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        TxtName.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l1"), Label).Text
        txtcode.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("ll1"), Label).Text
        SE.Registered = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l2"), Label).Text
        ChkBuyer.Enabled = False
        If SE.Registered = "Y" Then
            Chkreg.Checked = True
        Else
            Chkreg.Checked = False
        End If
        txttin.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l4"), Label).Text
        txtcst.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l5"), Label).Text
        txtAddress.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l6"), Label).Text
        txtcity.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l7"), Label).Text
        txtpostalcode.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l8"), Label).Text
        ddlState.SelectedValue = CType(GVSupp.Rows(e.NewEditIndex).FindControl("stateid"), Label).Text
        txtcountry.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l10"), Label).Text
        txtdlno.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l11"), Label).Text
        TxtcntctP.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l12"), Label).Text
        txtcntct1.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l13"), Label).Text
        txtcntct2.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l14"), Label).Text
        txtfaxno.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l15"), Label).Text
        txtemail.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l16"), Label).Text
        txtcreditP.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l17"), Label).Text
        txtcreditlimit.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l18"), Label).Text
        txtsuptorec.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l19"), Label).Text
        txtsuptopay.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l20"), Label).Text
        If txtsuptorec.Text = "0.00" Then
            txtsuptorec.Text = ""
        End If
        If txtsuptopay.Text = "0.00" Then
            txtsuptopay.Text = ""
        End If
        txtopeningBal.Text = CType(GVSupp.Rows(e.NewEditIndex).FindControl("l21"), Label).Text
        ViewState("Supp_Id") = CType(GVSupp.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        btnAdd.CommandName = "UPDATE"
        SE.Supp_ID = ViewState("Supp_Id")
        SE.Supp_Name = TxtName.Text
        SE.Supp_Code = txtcode.Text
        dt = SB.GetSupplierDetails(SE)
        GVSupp.DataSource = dt
        GVSupp.DataBind()
        e.Cancel = True
        GVSupp.Enabled = False
        btnView.CommandName = "BACK"
        btnView.Visible = True
       
    End Sub
    'code by Anchala on 11-08-12
    'method for deleting
    Protected Sub GVSupp_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSupp.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Supp_ID") = CType(GVSupp.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            SE.Supp_ID = ViewState("Supp_ID")
            SB.DeleteRecord(SE.Supp_ID)
            lblmsg.Text = ValidationMessage(1028)
            txtopeningBal.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
            display()
            TxtName.Focus()
            GVSupp.PageIndex = ViewState("PageIndex")
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    'code by Anchala on 11-08-12
    'method for display 
    Sub display()
        SE.Supp_ID = 0
        SE.Supp_Name = TxtName.Text
        SE.Supp_Code = txtcode.Text
        dt = SB.GetSupplierDetails(SE)
        If dt.Rows.Count <> 0 Then
            GVSupp.DataSource = dt
            GVSupp.DataBind()
            GVSupp.Visible = True
            GVSupp.Enabled = True
           
        Else
        
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1023)
            GVSupp.Visible = False
        End If
    End Sub
    Sub clear()
        txtsuptopay.Text = ""
        txtsuptorec.Text = ""
        txtAddress.Text = ""
        txtcreditlimit.Text = ""
        txtcode.Text = ""
        TxtcntctP.Text = ""
        txtcreditP.Text = ""
        TxtName.Text = ""
        txtopeningBal.Text = ""
        txttin.Text = ""
        txtcst.Text = ""
        txtcity.Text = ""
        ddlState.SelectedValue = 0
        Chkreg.Checked = False
        txtpostalcode.Text = ""
        txtcountry.Text = ""
        txtcntct1.Text = ""
        txtcntct2.Text = ""
        txtfaxno.Text = ""
        txtemail.Text = ""
        txtdlno.Text = ""

    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            txtopeningBal.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
           
        End If
        TxtName.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVSupp_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVSupp.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        SE.Supp_ID = 0
        SE.Supp_Name = TxtName.Text
        SE.Supp_Code = txtcode.Text
        dt = SB.GetSupplierDetails(SE)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVSupp.DataSource = sortedView
        GVSupp.DataBind()
        GVSupp.Visible = True
        GVSupp.Enabled = True
       
    End Sub
    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = value
        End Set
    End Property
    '
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        dt2 = Session("ValidationTable")
        If dt2 Is Nothing Then
            Response.Redirect("LogIn.aspx")
        End If
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function

   
End Class
