
Partial Class FrmInvestmentMaster
    Inherits BasePage
    Dim EL As New ELInvestmentMaster
    Dim BL As New BLInvestmentMaster
    Dim dt As New DataTable
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                cmbSponsor.Focus()
                EL.Sponsor_ID = cmbSponsor.SelectedValue
                EL.InvestmentAmount = TxtInvest.Text
                EL.Currency = cmbCurrency.SelectedValue
                EL.InvestmentType = Txtinvtype.Text
                If Txtstdate.Text = "" Then
                    EL.InvestmentSTDT = "01/01/9000"
                Else
                    EL.InvestmentSTDT = Txtstdate.Text
                End If
                If Txtmdate.Text = "" Then
                    EL.InvestmentMaturityDate = "01/01/9000"
                Else
                    EL.InvestmentMaturityDate = Txtmdate.Text

                End If

                If Txtstdate.Text <> "" And Txtmdate.Text <> "" Then

                    If CType(Txtstdate.Text, Date) > CType(Txtmdate.Text, Date) Then
                        msginfo.Text = ValidationMessage(1054)
                        Exit Sub
                    End If
                End If
                EL.BankID = ddlBank.SelectedValue
                EL.Paymentmethodid = ddlPaymentMethod.SelectedValue

                If Txtroi.Text = "" Then
                    EL.Rateofinterest = 0
                Else
                    EL.Rateofinterest = Txtroi.Text
                End If
                If txtAmt.Text = "" Then
                    EL.InterestAmt = 0
                Else
                    EL.InterestAmt = txtAmt.Text
                End If
                If Txtadmin.Text = "" Then
                    EL.AdminCost = 0
                Else
                    EL.AdminCost = Txtadmin.Text
                End If
                If TxtAdAmt.Text = "" Then
                    EL.AdminAmt = 0
                Else
                    EL.AdminAmt = TxtAdAmt.Text
                End If
                If Txtbal.Text = "" Then
                    EL.BalanceAmt = 0
                Else
                    EL.BalanceAmt = Txtbal.Text
                End If
                EL.Remarks = Txtremark.Text

                If btnadd.CommandName = "UPDATE" Then
                    EL.ID = ViewState("IMAutoID")
                    'dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = ValidationMessage(1030)
                        lblmsg.Text = ValidationMessage(1014)
                    Else
                        BL.UpdateRecord(EL)
                        msginfo.Text = ValidationMessage(1014)
                        btnadd.CommandName = "ADD"
                        btndetails.CommandName = "VIEW"
                        btndetails.Text = "VIEW"
                        btnadd.Text = "ADD"
                        lblmsg.Text = ValidationMessage(1017)
                        DisplayInvestmentMaster()
                        GVInvestment.PageIndex = ViewState("PageIndex")
                        clear()
                    End If
                ElseIf btnadd.CommandName = "ADD" Then
                    EL.ID = 0
                    'dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = ValidationMessage(1030)
                        lblmsg.Text = ValidationMessage(1014)
                    Else
                        BL.InsertRecord(EL)
                        msginfo.Text = ValidationMessage(1014)
                        btnadd.CommandName = "ADD"
                        btndetails.Text = "VIEW"
                        btnadd.Text = "ADD"
                        lblmsg.Text = ValidationMessage(1020)
                        ViewState("PageIndex") = 0
                        GVInvestment.PageIndex = 0
                        DisplayInvestmentMaster()
                        clear()
                        DisplayInvestmentMaster()
                    End If
                End If
            Catch ex As Exception
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1055)
            End Try

        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    Sub DisplayInvestmentMaster()
        Dim dt As New DataTable
        EL.ID = 0
        EL.Sponsor_ID = cmbSponsor.SelectedValue
        dt = BL.Display(EL)
        GVInvestment.DataSource = dt
        GVInvestment.DataBind()

        GVInvestment.Visible = True
        GVInvestment.Enabled = True
        LinkButton.Focus()
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ValidationMessage(1014)

            msginfo.Text = ValidationMessage(1023)
            'msginfo.Visible = True

        End If
        Multilingual()
    End Sub
    Sub clear()
        TxtInvest.Focus()
        TxtInvest.Text = ""
        Txtinvtype.Text = ""
        Txtstdate.Text = Format(Today, "dd-MMM-yyyy")
        Txtmdate.Text = ""
        Txtroi.Text = ""
        txtAmt.Text = ""
        Txtadmin.Text = ""
        Txtbal.Text = ""
        TxtAdAmt.Text = ""
        Txtremark.Text = ""
    End Sub

    Protected Sub GVInvestment_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVInvestment.PageIndexChanging
        GVInvestment.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVInvestment.PageIndex
        DisplayInvestmentMaster()
    End Sub

    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click
        msginfo.Text = ValidationMessage(1014)

        If btndetails.CommandName <> "BACK" Then
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GVInvestment.PageIndex = 0
            DisplayInvestmentMaster()
            GVInvestment.Visible = True
            Multilingual()
        Else
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
            btndetails.CommandName = "VIEW"
            btnadd.CommandName = "ADD"
            btndetails.Text = "VIEW"
            btnadd.Text = "ADD"
            clear()
            GVInvestment.Visible = True
            GVInvestment.PageIndex = ViewState("PageIndex")
            DisplayInvestmentMaster()
            Multilingual()
        End If
    End Sub

    Protected Sub GVInvestment_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVInvestment.RowEditing
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        EL.ID = ViewState("IMAutoID")
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        cmbSponsor.SelectedValue = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lblsponsorid"), Label).Text
        TxtInvest.Text = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lblinvamt"), Label).Text
        cmbCurrency.SelectedValue = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lblcurrency"), Label).Text

        Txtinvtype.Text = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lblinvtype"), Label).Text

        Txtstdate.Text = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lblst"), Label).Text
        Txtmdate.Text = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lblm"), Label).Text
        ddlBank.SelectedValue = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lbl7"), Label).Text
        ddlPaymentMethod.SelectedValue = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("HidP"), HiddenField).Value
        Txtroi.Text = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lblroi1"), Label).Text
        txtAmt.Text = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lbliamt"), Label).Text
        Txtadmin.Text = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lblacost"), Label).Text
        TxtAdAmt.Text = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lbladamt"), Label).Text
        Txtbal.Text = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lblbamt"), Label).Text
        Txtremark.Text = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("Lblrm"), Label).Text
        ViewState("IMAutoID") = CType(GVInvestment.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        btnadd.CommandName = "UPDATE"
        btndetails.CommandName = "BACK"
        btnadd.Text = "UPDATE"
        btndetails.Text = "BACK"
        EL.ID = ViewState("IMAutoID")
        dt = BL.Display(EL)
        GVInvestment.DataSource = dt
        GVInvestment.DataBind()
        GVInvestment.Enabled = False
        Multilingual()
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        cmbSponsor.Focus()
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        Txtstdate.Text = Format(Today, "dd-MMM-yyyy")
        If Not IsPostBack Then
            Control_Text_Multilingual()
            Txtroi.Text = "9.00"

        End If
        TxtAdAmt.Enabled = False
        Txtbal.Enabled = False


    End Sub

    Protected Sub txtAmt_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmt.TextChanged
        If txtAmt.Text = "" Then
            txtAmt.Text = 0
        End If
        If txtAmt.Text <> "" And Txtadmin.Text <> "" Then
            EL.AdminAmt = txtAmt.Text * Txtadmin.Text * 0.01
            TxtAdAmt.Text = EL.AdminAmt
        Else
            EL.AdminAmt = 0
        End If

        If TxtAdAmt.Text <> "" Then
            EL.BalanceAmt = txtAmt.Text - TxtAdAmt.Text
            Txtbal.Text = EL.BalanceAmt
        Else
            EL.BalanceAmt = 0
        End If
        Txtadmin.Focus()
    End Sub

    Protected Sub Txtadmin_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtadmin.TextChanged
        If txtAmt.Text <> "" And Txtadmin.Text <> "" Then
            EL.AdminAmt = txtAmt.Text * Txtadmin.Text * 0.01
            TxtAdAmt.Text = EL.AdminAmt
        Else
            EL.AdminAmt = 0
        End If
        If TxtAdAmt.Text <> "" Then
            EL.BalanceAmt = txtAmt.Text - TxtAdAmt.Text
            Txtbal.Text = EL.BalanceAmt
        Else
            EL.BalanceAmt = 0
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'Protected Sub TxtInvest_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtInvest.TextChanged
    '    If TxtInvest.Text <> "" And Txtroi.Text <> "" Then
    '        EL.InterestAmt = TxtInvest.Text * Txtroi.Text * 0.01
    '        txtAmt.Text = EL.InterestAmt
    '    Else
    '        EL.InterestAmt = 0
    '    End If
    '    cmbCurrency.Focus()
    'End Sub

    'Protected Sub Txtroi_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtroi.TextChanged
    '    If TxtInvest.Text <> "" And Txtroi.Text <> "" Then
    '        EL.InterestAmt = TxtInvest.Text * Txtroi.Text * 0.01
    '        txtAmt.Text = EL.InterestAmt
    '    Else
    '        EL.InterestAmt = 0
    '    End If
    '    If txtAmt.Text = "" Then
    '        txtAmt.Text = 0
    '    End If
    '    If txtAmt.Text <> "" And Txtadmin.Text <> "" Then
    '        EL.AdminAmt = txtAmt.Text * Txtadmin.Text * 0.01
    '        TxtAdAmt.Text = EL.AdminAmt
    '    Else
    '        EL.AdminAmt = 0
    '    End If

    '    If TxtAdAmt.Text <> "" Then
    '        EL.BalanceAmt = txtAmt.Text - TxtAdAmt.Text
    '        Txtbal.Text = EL.BalanceAmt
    '    Else
    '        EL.BalanceAmt = 0
    '    End If
    '    Txtadmin.Focus()
    'End Sub

    Protected Sub Txtbal_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtbal.TextChanged
        Txtremark.Focus()
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

    Protected Sub ddlPaymentMethod_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlPaymentMethod.TextChanged
        ddlPaymentMethod.Focus()
    End Sub

    Protected Sub GVInvestment_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVInvestment.Sorting
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
        EL.Sponsor_ID = cmbSponsor.SelectedValue
        dt = BL.Display(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVInvestment.DataSource = sortedView
        GVInvestment.DataBind()
        GVInvestment.Visible = True
        GVInvestment.Enabled = True
        LinkButton.Focus()
        Multilingual()
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
    'Code written fro multilingual by Niraj on 12 aug 2013
    ''Retriving the text of controls based on Language

    Sub Multilingual()
        Dim j As Integer
        Dim k As Integer
        Dim dtl As DataTable
        'Dim FormName As String = Session("Code")
        'Dim LanguageID As Integer
        'If Session("LanguageID") = "" Then
        '    LanguageID = 0
        'Else
        '    LanguageID = Session("LanguageID")
        'End If
        'If LanguageID <> 0 Then
        'dtl = GlobalFunction.GetChangeLanguage(FormName, LanguageID)
        dtl = Session("Control_Text")
        Dim i As Integer = dtl.Rows.Count
        While (i <> 0)
            If dtl.Rows(i - 1).Item("ControlType") = "Label" Then
                Dim myLabel As Label = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Label)
                myLabel.Text = dtl.Rows(i - 1).Item("Default_Text")
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "Button" Then
                If dtl.Rows(i - 1).Item("ControlCommandName") = btnadd.CommandName Then
                    Dim myButton As Button = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
                    myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
                    i = i - 1
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = btndetails.CommandName Then
                    Dim myButton As Button = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), Button)
                    myButton.Text = dtl.Rows(i - 1).Item("Default_Text")
                    i = i - 1
                Else
                    i = i - 1
                End If

            ElseIf dtl.Rows(i - 1).Item("ControlType") = "GridLabel" Then
                j = GVInvestment.Columns.Count
                While (j <> 0)
                    If GVInvestment.Columns(j - 1).HeaderText = dtl.Rows(i - 1).Item("ControlCommandName") Then
                        GVInvestment.Columns(j - 1).HeaderText = dtl.Rows(i - 1).Item("Default_Text")
                    End If
                    j = j - 1
                End While
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "GridButton" Then
                k = GVInvestment.Rows.Count
                If dtl.Rows(i - 1).Item("ControlCommandName") = "Acknowledge" Then
                    While (k <> 0)
                        Dim lnkCanc As LinkButton = CType(GVInvestment.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                        lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                        k = k - 1
                    End While
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = "Edit" Then
                    k = GVInvestment.Rows.Count
                    While (k <> 0)
                        Dim lnkCanc As LinkButton = CType(GVInvestment.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                        lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                        k = k - 1
                    End While
                ElseIf dtl.Rows(i - 1).Item("ControlCommandName") = "Delete" Then
                    k = GVInvestment.Rows.Count
                    While (k <> 0)
                        Dim lnkCanc As LinkButton = CType(GVInvestment.Rows(k - 1).FindControl(dtl.Rows(i - 1).Item("ControlId")), LinkButton)
                        lnkCanc.Text = dtl.Rows(i - 1).Item("Default_Text")
                        k = k - 1
                    End While
                End If
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "CheckBox" Then
                Dim myCheckbox As CheckBox = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), CheckBox)
                myCheckbox.Text = dtl.Rows(i - 1).Item("Default_Text")
                i = i - 1
            ElseIf dtl.Rows(i - 1).Item("ControlType") = "RadioButtonList" Then
                Dim myRadiobutton As RadioButtonList = CType(Me.UpdatePanel1.FindControl(dtl.Rows(i - 1).Item("ControlId")), RadioButtonList)
                Dim a As Integer = myRadiobutton.Items.Count
                While (a <> 0)
                    For Each li As ListItem In myRadiobutton.Items
                        If li.Value = dtl.Rows(i - 1).Item("ControlCommandName") Then
                            li.Text = dtl.Rows(i - 1).Item("Default_Text")
                        End If
                    Next
                    a = a - 1
                End While
                i = i - 1
            End If
        End While
        'End If
    End Sub
    Public Sub Control_Text_Multilingual()
        Dim dtll As DataTable
        Dim FormName As String = Session("Code")
        Dim LanguageID As Integer
        If Session("LanguageID") = "" Then
            LanguageID = 1
        Else
            LanguageID = Session("LanguageID")
        End If
        If LanguageID <> 0 Then
            dtll = GlobalFunction.GetChangeLanguage(FormName, LanguageID)
            Session("Control_Text") = dtll
            Multilingual()
        End If
    End Sub
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
