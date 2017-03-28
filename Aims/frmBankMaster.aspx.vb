
Partial Class frmBankMaster
    Inherits BasePage
    Dim hit, idd, PageIndex As Integer
    Dim sql, alt, alt1 As String
    Dim objBusErrMesg As New busErrorMessage
    Dim BankManager As New BankManager
    Dim Bank As New Bank
    Dim BLL As New BankManager
    Dim dt As New DataTable
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        txtBank.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then

            If btnAdd.CommandName = "UPDATE" Then
                btnAdd.Text = "ADD"
                btnDetails.Text = "VIEW"
                lblErrorMsg.Text = ValidationMessage(1014)
                Bank.Name = txtBank.Text
                Bank.Address = txtBankAdd.Text
                Bank.Remarks = txtRemarks.Text
                Bank.Id = ViewState("Bank_ID")
                dt = BankManager.GetBankDetailsDuplicate(Bank)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    lblErrorMsg.Text = ValidationMessage(1014)
                Else
                    BankManager.UpdateRecord(Bank)
                    btnAdd.CommandName = "ADD"

                    btnDetails.CommandName = "VIEW"

                    clear()
                    lblErrorMsg.Text = ValidationMessage(1017)
                    msginfo.Text = ValidationMessage(1014)
                    Bank.Id = 0
                    GVBank.PageIndex = ViewState("PageIndex")
                    DisplayGridView()
                    GVBank.Enabled = True
                End If
            ElseIf btnAdd.CommandName = "ADD" Then
                Bank.Name = txtBank.Text
                dt = BankManager.GetBankDetailsDuplicate(Bank)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    lblErrorMsg.Text = ValidationMessage(1014)
                    'clear()
                Else
                    lblErrorMsg.Text = ValidationMessage(1014)
                    msginfo.Text = ValidationMessage(1014)
                    Bank.Name = txtBank.Text
                    Bank.Address = txtBankAdd.Text
                    Bank.Remarks = txtRemarks.Text
                    If BankManager.InsertRecord(Bank) > 0 Then
                        GVBank.DataBind()
                        'Enable()
                        GVBank.Visible = True
                        clear()
                        ViewState("PageIndex") = 0
                        GVBank.PageIndex = 0
                        DisplayGridView()
                        lblErrorMsg.Text = ValidationMessage(1020)
                        msginfo.Text = ValidationMessage(1014)
                        Bank.Id = 0
                       
                    End If

                End If

            End If
        Else
            msginfo.Text = ValidationMessage(1021)
            lblErrorMsg.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub GVBank_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVBank.RowDeleting
        ' Deletes data of the selected row-- by Nakul Bharadwaj(12-3-2012)
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim a As Integer

            If GVBank.EditIndex <> -1 Then
                msginfo.Text = ValidationMessage(1063)
            Else
                a = Convert.ToInt64(GVBank.DataKeys(e.RowIndex).Value)
                BankManager.ChangeFlag(a)
                lblErrorMsg.Text = ValidationMessage(1028)
                txtBank.Focus()
                msginfo.Text = ValidationMessage(1014)
                GVBank.PageIndex = ViewState("PageIndex")
                DisplayGridView()
                GVBank.Visible = True
                GVBank.Enabled = True
            End If
        Else
            msginfo.Text = ValidationMessage(1029)
            lblErrorMsg.Text = ValidationMessage(1014)
        End If

    End Sub
    Sub DisplayGridView()
        ' Displays the data-- by Nakul Bharadwaj(12-3-2012)
        Dim dt As New DataTable
        dt = BankManager.getBankDetails(Bank)
        If dt.Rows.Count = 0 Then
            msginfo.Text = ValidationMessage(1023)
            lblErrorMsg.Text = ValidationMessage(1014)
            GVBank.DataSource = Nothing
            GVBank.DataBind()
            
        Else
            GVBank.DataSource = dt
            GVBank.DataBind()
            
        End If
    End Sub

    Protected Sub GVBank_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVBank.RowEditing

        btnAdd.Text = "UPDATE"
        btnDetails.Text = "BACK"

        txtRemarks.Text = PageIndex
        txtBank.Text = CType(GVBank.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        txtBankAdd.Text = CType(GVBank.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        txtRemarks.Text = CType(GVBank.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        ViewState("Bank_ID") = CType(GVBank.Rows(e.NewEditIndex).FindControl("BId"), HiddenField).Value
        btnAdd.CommandName = "UPDATE"
        GVBank.DataSource = dt
        GVBank.DataBind()
        Bank.Id = ViewState("Bank_ID")
        DisplayGridView()
        GVBank.DataBind()
        GVBank.Enabled = False
        GVBank.Visible = True
        btnDetails.CommandName = "BACK"
        btnDetails.Visible = True
        msginfo.Text = ValidationMessage(1014)
        lblErrorMsg.Text = ValidationMessage(1014)
        
    End Sub
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        LinkButton1.Focus()
        If btnDetails.CommandName = "VIEW" Then
            Bank.Id = 0
            GVBank.Visible = True
            ViewState("PageIndex") = 0
            GVBank.PageIndex = 0
            DisplayGridView()
            'clear()
            lblErrorMsg.Text = ValidationMessage(1014)
            GVBank.Enabled = True
        Else
            Bank.Id = 0
            GVBank.Visible = True
            GVBank.PageIndex = ViewState("PageIndex")
            txtBank.Text = ""
            txtBankAdd.Text = ""
            txtRemarks.Text = ""
            btnAdd.CommandName = "ADD"
            btnAdd.Text = "ADD"
            btnDetails.CommandName = "VIEW"
            btnDetails.Text = "VIEW"
            GVBank.Enabled = True
            lblErrorMsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            DisplayGridView()
        End If

    End Sub
    Protected Sub GVBank_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVBank.PageIndexChanging
        GVBank.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVBank.PageIndex
        DisplayGridView()
    End Sub
    Protected Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        GVBank.Enabled = True
        GVBank.DataBind()
        GVBank.Columns(1).Visible = True
        
    End Sub
    Sub clear()

        txtBank.Text = ""
        txtBankAdd.Text = ""
        txtRemarks.Text = ""
        lblErrorMsg.Text = ValidationMessage(1014)
    End Sub
    Sub Enable()
        GVBank.Enabled = True
        btnDetails.Visible = True
    End Sub
    Sub Disable()
        GVBank.Enabled = False
        btnDetails.Visible = False
    End Sub

    <System.Web.Services.WebMethod()> _
    Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtBank.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
           
        End If
    End Sub

    Protected Sub GVBank_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVBank.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        dt = BankManager.getBankDetails(Bank)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVBank.DataSource = sortedView
        GVBank.DataBind()
       
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
    ''Code Written for Multilingual By Ajit Kumar Singh on 12th Aug
    ''Retriving the text of controls based on Language
    
    
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
