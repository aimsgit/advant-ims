
Partial Class FrmEndowment
    Inherits BasePage
    Dim EL As New ELEndowment
    Dim BL As New BLEndowment
    Dim dt As New DataTable
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                cmbSponsor.Focus()
                EL.SponsorID = cmbSponsor.SelectedValue
                EL.Donor_ID = DonorIdTextBox.Text
                EL.Amount = txtAmt.Text
                EL.Currency = cmbCurrency.SelectedValue

                If TxtRdate.Text = "" Then
                    EL.RcvdDate = "01/01/9000"
                Else
                    EL.RcvdDate = TxtRdate.Text
                End If
                EL.ChqNo = ChqTextBox.Text
                EL.Bank = ddlBank.SelectedValue
                EL.Remarks = TxtRemarks.Text

                If btnadd.CommandName = "UPDATE" Then
                    EL.ID = ViewState("EGMAUTOID")
                    dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = ValidationMessage(1030)
                        lblmsg.Text = ValidationMessage(1014)
                    Else
                        BL.UpdateRecord(EL)
                        msginfo.Text = ValidationMessage(1014)
                        btnadd.CommandName = "ADD"
                        btndetails.CommandName = "VIEW"
                        btnadd.Text = "ADD"
                        btndetails.Text = "VIEW"
                        lblmsg.Text = ValidationMessage(1017)
                        DisplayEndowmentMaster()
                        GVEndowment.PageIndex = ViewState("PageIndex")
                        'Displ()
                        clear()
                    End If
                ElseIf btnadd.CommandName = "ADD" Then
                    EL.ID = 0
                    dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = ValidationMessage(1030)
                        lblmsg.Text = ValidationMessage(1014)
                    Else
                        BL.InsertRecord(EL)
                        msginfo.Text = ValidationMessage(1014)
                        btnadd.CommandName = "ADD"
                        btnadd.Text = "ADD"
                        btndetails.Text = "VIEW"
                        lblmsg.Text = ValidationMessage(1020)
                        ViewState("PageIndex") = 0
                        GVEndowment.PageIndex = 0
                        DisplayEndowmentMaster()
                        clear()

                    End If
                End If
            Catch ex As Exception
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1022)
            End Try

        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    Sub DisplayEndowmentMaster()
        Dim dt As New DataTable
        EL.ID = 0
        EL.SponsorID = cmbSponsor.SelectedValue
        dt = BL.Display(EL)
        GVEndowment.DataSource = dt
        GVEndowment.DataBind()

        GVEndowment.Visible = True
        GVEndowment.Enabled = True
        LinkButton.Focus()
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ValidationMessage(1014)

            msginfo.Text = ValidationMessage(1023)
            'msginfo.Visible = True
        End If

    End Sub
    Sub clear()
        cmbSponsor.Focus()
        'cmbSponsor.SelectedValue = 0
        DonorIdTextBox.Text = ""
        txtAmt.Text = ""
        'cmbCurrency.SelectedValue = 0
        TxtRdate.Text = Format(Today, "dd-MMM-yyyy")
        ChqTextBox.Text = ""
        TxtRemarks.Text = ""
    End Sub

    Protected Sub GVEndowment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVEndowment.PageIndexChanging
        GVEndowment.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVEndowment.PageIndex
        DisplayEndowmentMaster()
    End Sub

    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click
        msginfo.Text = ValidationMessage(1014)
        If btndetails.CommandName <> "BACK" Then
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GVEndowment.PageIndex = 0
            DisplayEndowmentMaster()
            GVEndowment.Visible = True

        Else
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            btndetails.CommandName = "VIEW"
            btnadd.CommandName = "ADD"
            btnadd.Text = "ADD"
            btndetails.Text = "VIEW"
            clear()
            GVEndowment.Visible = True
            GVEndowment.PageIndex = ViewState("PageIndex")
            DisplayEndowmentMaster()
        End If

    End Sub

    Protected Sub GVEndowment_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVEndowment.RowEditing
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        EL.ID = ViewState("EGMAUTOID")
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        cmbSponsor.SelectedValue = CType(GVEndowment.Rows(e.NewEditIndex).FindControl("Lblsponsorid"), Label).Text
        DonorIdTextBox.Text = CType(GVEndowment.Rows(e.NewEditIndex).FindControl("lbl2"), Label).Text
        txtAmt.Text = CType(GVEndowment.Rows(e.NewEditIndex).FindControl("Lbl3"), Label).Text
        cmbCurrency.SelectedValue = CType(GVEndowment.Rows(e.NewEditIndex).FindControl("Lblcurrency"), Label).Text
        TxtRdate.Text = CType(GVEndowment.Rows(e.NewEditIndex).FindControl("Lbl5"), Label).Text
        ChqTextBox.Text = CType(GVEndowment.Rows(e.NewEditIndex).FindControl("Lbl6"), Label).Text
        ddlBank.SelectedValue = CType(GVEndowment.Rows(e.NewEditIndex).FindControl("Lbl7"), Label).Text
        TxtRemarks.Text = CType(GVEndowment.Rows(e.NewEditIndex).FindControl("Lbl8"), Label).Text
        ViewState("EGMAUTOID") = CType(GVEndowment.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value

        btnadd.Text = "UPDATE"
        btndetails.Text = "BACK"
        btnadd.CommandName = "UPDATE"
        btndetails.CommandName = "BACK"
        EL.ID = ViewState("EGMAUTOID")
        dt = BL.Display(EL)
        GVEndowment.DataSource = dt
        GVEndowment.DataBind()
        GVEndowment.Enabled = False

        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then

        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub cmbSponsor_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSponsor.TextChanged
        cmbSponsor.Focus()
    End Sub

    Protected Sub cmbCurrency_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCurrency.TextChanged
        cmbCurrency.Focus()
    End Sub

    Protected Sub ddlBank_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBank.TextChanged
        ddlBank.Focus()
    End Sub

    Protected Sub GVEndowment_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVEndowment.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        EL.ID = 0
        EL.SponsorID = cmbSponsor.SelectedValue
        dt = BL.Display(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVEndowment.DataSource = sortedView
        GVEndowment.DataBind()

        GVEndowment.Visible = True
        GVEndowment.Enabled = True
        LinkButton.Focus()

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
    'Code written fro multilingual by Niraj on 29 aug 2013
    ''Retriving the text of controls based on Language

   
    
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
