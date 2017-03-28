
Partial Class frmOtherParty
    Inherits BasePage
    Dim alt As String
    Dim dt As New DataTable
    'Dim GlobalFunction As New GlobalFunction
    'Dim a As Integer
    Dim op As New OtherParty
    Dim opb As New OtherPartyB

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        'GridView1.Visible = True
        If (Session("BranchCode") = Session("ParentBranch")) Then

            ViewState("OPAutoNo") = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            op.Id = ViewState("OPAutoNo")
            opb.ChangeFlag(op)
            lblErrorMsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1028)
            NameTextBox.Focus()
            GridView1.PageIndex = ViewState("PageIndex")
            display()
            GridView1.DataBind()
            GridView1.Enabled = True
        Else
            lblErrorMsg.Text = ValidationMessage(1029)
            msginfo.Text = ValidationMessage(1014)
        End If
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        NameTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl1"), Label).Text
        OpidTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl2"), Label).Text
        AddressTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl3"), Label).Text
        CityTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl4"), Label).Text
        ddlState.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl16"), Label).Text
        PcodeTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl5"), Label).Text
        ContactpersonTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lbl7"), Label).Text
        EmailTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lemail"), Label).Text
        Txtfaxno.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lbl9"), Label).Text
        ContactnoTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lbl8"), Label).Text
        CreditperiodTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lbl10"), Label).Text
        CreditlimitTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lbl11"), Label).Text
        txtpartytopay.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lbl12"), Label).Text
        txtpartytorec.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lbl13"), Label).Text
        If txtpartytopay.Text = "0.00" Then
            txtpartytopay.Text = ""
        End If
        If txtpartytorec.Text = "0.00" Then
            txtpartytorec.Text = ""
        End If
        OpBalanceDateTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lbl14"), Label).Text
        RemarkTextBox.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lbl15"), Label).Text
        ViewState("OPAutoNo") = CType(GridView1.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        btnadd.Text = "UPDATE"
        btndetails.Text = "BACK"
        lblErrorMsg.Text = ""
        msginfo.Text = ""
        Dim dt As New DataTable
        op.Id = ViewState("OPAutoNo")
        op.Name = NameTextBox.Text
        op.Opid = OpidTextBox.Text
        dt = opb.GetDetails(op)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
       
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'msginfo.Text = ""
        'End If
    End Sub

    Public Sub display()
        Dim table As New DataTable
        op.Id = 0
        op.Name = NameTextBox.Text
        op.Opid = OpidTextBox.Text
        table = OtherpartyDB.GetDeatils(op)
        If table.Rows.Count > 0 Then
            GridView1.DataSource = table
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
            
        Else
            msginfo.Text = ValidationMessage(1014)
            lblErrorMsg.Text = ValidationMessage(1023)
            GridView1.Visible = False
            

        End If

    End Sub
    Sub AssignEntity()
        If CreditperiodTextBox.Text = "" Then
            CreditperiodTextBox.Text = 0
        Else
            op.Creditperiod = CreditperiodTextBox.Text
        End If
        If CreditlimitTextBox.Text = "" Then
            CreditlimitTextBox.Text = 0
        Else
            op.Creditlimit = CreditlimitTextBox.Text
        End If
        If txtpartytopay.Text = "" Then
            txtpartytopay.Text = 0
        Else
            op.OpeningBalanceCR = txtpartytopay.Text
        End If
        If txtpartytorec.Text = "" Then
            txtpartytorec.Text = 0
        Else
            op.OpeningBalanceDR = txtpartytorec.Text
        End If
    End Sub
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        NameTextBox.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                op.Name = NameTextBox.Text
                op.Opid = OpidTextBox.Text
                op.Address = AddressTextBox.Text
                op.City = CityTextBox.Text
                op.State = ddlState.SelectedValue
                op.Pcode = PcodeTextBox.Text
                op.Contactperson = ContactpersonTextBox.Text
                op.Contactno = ContactnoTextBox.Text
                op.FaxNO = Txtfaxno.Text
                op.Email = EmailTextBox.Text
                op.OpBalanceDate = OpBalanceDateTextBox.Text
                op.Remark = RemarkTextBox.Text
                If txtpartytorec.Text <> "" And txtpartytopay.Text <> "" Then
                    lblErrorMsg.Text = ValidationMessage(1058)
                    msginfo.Text = ValidationMessage(1014)
                    Exit Sub
                End If
                AssignEntity()
               
                If btnadd.CommandName = "UPDATE" Then
                    Dim dt2 As New DataTable
                    op.Id = ViewState("OPAutoNo")
                    dt2 = opb.GetDuplicateParty(op)
                    If dt2.Rows.Count > 0 Then
                        msginfo.Text = ValidationMessage(1014)
                        lblErrorMsg.Text = ValidationMessage(1030)
                        display()
                        btnadd.CommandName = "ADD"
                        btndetails.CommandName = "VIEW"
                    Else
                        op.Id = ViewState("OPAutoNo")
                        Dim dt1 As New DataTable
                        opb.UpdateRecord(op)
                        btnadd.CommandName = "ADD"
                        btndetails.CommandName = "VIEW"
                        clear()
                        lblErrorMsg.Text = ValidationMessage(1014)
                        msginfo.Text = ValidationMessage(1017)
                        GridView1.PageIndex = ViewState("PageIndex")
                        display()
                        OpBalanceDateTextBox.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
                    End If

                ElseIf btnadd.CommandName = "ADD" Then
                    Dim dt1 As New DataTable
                    dt1 = opb.GetDuplicateParty(op)
                    If dt1.Rows.Count > 0 Then
                        msginfo.Text = ValidationMessage(1014)
                        lblErrorMsg.Text = ValidationMessage(1030)
                        display()
                        'clear()
                    Else
                        opb.Insert(op)
                        btnadd.CommandName = "ADD"
                        GridView1.DataBind()
                        GridView1.Visible = True
                        lblErrorMsg.Text = ValidationMessage(1014)
                        msginfo.Text = ValidationMessage(1020)
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        display()
                        clear()
                        OpBalanceDateTextBox.Text = Format(CDate(Session("FinStartDate")), "dd-MMM-yyyy")
                    End If

                End If
            Catch ex As Exception
                lblErrorMsg.Text = ValidationMessage(1059)
                msginfo.Text = ValidationMessage(1014)
            End Try
        Else
            lblErrorMsg.Text = ValidationMessage(1021)
            msginfo.Text = ValidationMessage(1014)
        End If
           

    End Sub

    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click
        LinkButton1.Focus()
        lblErrorMsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        If btndetails.CommandName <> "BACK" Then
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            display()
            GridView1.Visible = True
            btndetails.Text = "VIEW"
            btnadd.Text = "ADD"

        Else
            clear()
            btndetails.CommandName = "VIEW"
            btnadd.CommandName = "ADD"
            GridView1.PageIndex = ViewState("PageIndex")
            display()

        End If
    End Sub
    Public Sub clear()
        NameTextBox.Text = ""
        OpidTextBox.Text = ""
        AddressTextBox.Text = ""
        CityTextBox.Text = ""

        PcodeTextBox.Text = ""

        ContactpersonTextBox.Text = ""
        ContactnoTextBox.Text = ""
        EmailTextBox.Text = ""
        CreditperiodTextBox.Text = ""
        CreditlimitTextBox.Text = ""
        txtpartytopay.Text = ""
        txtpartytorec.Text = ""
        OpBalanceDateTextBox.Text = ""
        RemarkTextBox.Text = ""
        Txtfaxno.Text = ""
    End Sub


    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        display()
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
        NameTextBox.Focus()
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    'Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
    '    cmbcourseType.Focus()
    '    Dim heading As String
    '    heading = Session("RptFrmTitleName")
    '    Me.Lblheading.Text = heading
    'End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim table As New DataTable
        op.Id = 0
        op.Name = NameTextBox.Text
        op.Opid = OpidTextBox.Text
        table = OtherpartyDB.GetDeatils(op)

        Dim sortedView As New DataView(table)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
        
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
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
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
