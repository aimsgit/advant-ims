
Partial Class FrmClientContractMaster
    Inherits BasePage
    Dim ClientContract As New ClientCotract
    Dim BLClientContractMaster As New BLClientContractMaster
    Dim DLClientContractMaster As New DLClientContractMaster
    Dim dt As New DataTable
    Dim setup As String
    Dim tempdate As String
    Dim ExpDate As Date

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtAdjusted.Enabled = False
        txtBalance.Enabled = False
        txtAdvance.Enabled = False
        'txtBalance.Text = IIf(txtAdvance.Text = "", 0, txtAdvance.Text) - IIf(txtAdjusted.Text = "", 0, txtAdjusted.Text)
        If Not Page.IsPostBack Then
            txtstdate.Text = Format(Date.Today(), "dd-MMM-yyyy")
        End If
    End Sub
    Protected Sub Gridview1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DispGrid4()
        GridView1.Visible = True
    End Sub
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        'Code For ADD and UPDATE Button by Nitin 12/06/2012
        Try
            lblErrorMsg.Text = ""
            lblmsg.Text = ""
            ClientContract.MyCo_Code = DdlSelectClient.SelectedValue.Trim
            ClientContract.Branch_Code = DdlSelectBranch.SelectedValue
            ClientContract.BillType = DdlBilltype.SelectedValue
            If txtPerStudent.Text = "" Then
                ClientContract.PerStudent = 0.0
            Else
                ClientContract.PerStudent = txtPerStudent.Text
            End If
            If TxtSetupChrge.Text = "" Then
                ClientContract.SetupChrge = 0.0
            Else
                ClientContract.SetupChrge = TxtSetupChrge.Text
            End If
            If Txttsmschrge.Text = "" Then
                ClientContract.SmsCount = 0.0
            Else
                ClientContract.SmsCount = Txttsmschrge.Text
            End If
            If Txtemailchrge.Text = "" Then
                ClientContract.EmailCount = 0.0
            Else
                ClientContract.EmailCount = Txtemailchrge.Text
            End If

            If txtstdate.Text = "" Then
                ClientContract.StartDate = CDate("1/1/1900")
            Else
                ClientContract.StartDate = txtstdate.Text

            End If
            If txtExpdate.Text = "" Then
                ClientContract.ExpiryDate = CDate("1/1/1900")
            Else
                ClientContract.ExpiryDate = txtExpdate.Text
            End If
            If txtOtherCharges.Text = "" Then
                ClientContract.OtherCharges = 0.0
            Else
                ClientContract.OtherCharges = txtOtherCharges.Text
            End If
            If txtAdvance.Text = "" Then
                ClientContract.Advance = 0.0
            Else
                ClientContract.Advance = txtAdvance.Text
            End If

            If txtAdjusted.Text = "" Then
                ClientContract.Adjusted = 0.0
            Else
                ClientContract.Adjusted = txtAdjusted.Text
            End If
            If txtBalance.Text = "" Then
                ClientContract.Balance = 0.0
            Else
                ClientContract.Balance = txtBalance.Text
            End If
            If txtstdcount.Text = "" Then
                ClientContract.StdCount = 0
            Else
                ClientContract.StdCount = txtstdcount.Text
            End If

            If txtDiscount.Text = "" Then
                ClientContract.Discount = 0.0
            Else
                ClientContract.Discount = txtDiscount.Text
            End If
            ClientContract.OpenStatus = ddlOpenClosedStatus.SelectedValue


            If CDate(txtstdate.Text) > CDate(txtExpdate.Text) Then
                lblErrorMsg.Text = "Start date cannot be greater than expiry date."
                lblmsg.Text = ""
            Else
                ClientContract.PKID = ViewState("PKID")
                If DdlSelectClient.SelectedItem.Text = "Select" Then
                    lblErrorMsg.Text = "Select Client Field is Mandatory."
                    lblmsg.Text = ""
                Else
                    If DdlSelectBranch.SelectedItem.Text = "Select" Then
                        lblErrorMsg.Text = "Select Branch Field is Mandatory."
                        lblmsg.Text = ""
                    Else
                        If DdlBilltype.SelectedItem.Text = "Select" Then
                            lblErrorMsg.Text = "Bill Type Field is Mandatory."
                            lblmsg.Text = ""
                        Else
                            tempdate = BLClientContractMaster.GetExpiryDate(ClientContract)
                            ExpDate = CDate(tempdate)
                        End If
                        If btnadd.Text = "ADD" Then
                            lblErrorMsg.Text = ""
                            If txtExpdate.Text > ExpDate Then
                                lblErrorMsg.Text = "Branch expiry date cannot be greater than Institute expiry date."
                                lblmsg.Text = ""
                            Else

                                dt = DLClientContractMaster.GetEmailSmsRate(DdlSelectBranch.SelectedValue)
                                ClientContract.SmsChrge = dt.Rows(0).Item("SMSRate")
                                ClientContract.EmailChrge = dt.Rows(0).Item("EmailRate")
                                BLClientContractMaster.InsertRecord(ClientContract)
                                lblErrorMsg.Text = ""
                                lblmsg.Text = "Data Saved Successfully."
                                ViewState("PageIndex") = 0
                                GridView1.PageIndex = 0
                                DispGrid4()
                                clear()
                            End If
                        ElseIf btnadd.Text = "UPDATE" Then
                            lblErrorMsg.Text = ""
                            If txtExpdate.Text > ExpDate Then
                                lblErrorMsg.Text = "Contract expiry date cannot be greater than institute expiry date."
                                lblmsg.Text = ""
                            Else
                                dt = DLClientContractMaster.GetEmailSmsRate(DdlSelectBranch.SelectedValue)
                                ClientContract.SmsChrge = dt.Rows(0).Item("SMSRate")
                                ClientContract.EmailChrge = dt.Rows(0).Item("EmailRate")
                                BLClientContractMaster.UpdateRecord(ClientContract)
                                lblErrorMsg.Text = ""
                                lblmsg.Text = "Data updated Successfully."
                                btnadd.Text = "ADD"
                                btnview.Text = "VIEW"
                                btnlockunlock.Enabled = True
                                btnReport.Enabled = True
                                Btnsaleinvoice.Enabled = True
                                GridView1.PageIndex = ViewState("PageIndex")
                                'DispGrid3()
                                DispGrid1()
                                clear()
                            End If
                        End If
                    End If
                End If
            End If
            'End If
        Catch ex As Exception
            lblErrorMsg.Text = "Enter SMS and Email charges in Email/SMS Rate."
        End Try
    End Sub
    Sub DispGrid1()
      
        Dim id As Integer
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lbllockstastus"), Label).Text = "Y" Then
                id = CType(rows.FindControl("lblPKID"), Label).Text
                GridView1.Enabled = False
                GridView1.Visible = True
                DispGrid2()
            Else
                id = CType(rows.FindControl("lblPKID"), Label).Text
                GridView1.Visible = True
                DispGrid4()
            End If
        Next
        GridView1.SelectedIndex = -1
    End Sub
    Sub DispGrid2()
  
        ClientContract.MyCo_Code = DdlSelectClient.SelectedValue
        ClientContract.PKID = 0
        dt = BLClientContractMaster.GetClientContract(ClientContract)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = False
            GridView1.Visible = True
        Else
            GridView1.Visible = False
            lblErrorMsg.Text = "No Records Found"
            lblmsg.Text = ""
        End If
    End Sub
    Sub DispGrid3()
        ClientContract.MyCo_Code = DdlSelectClient.SelectedValue
        ClientContract.PKID = ViewState("PKID")
        dt = BLClientContractMaster.GetClientContract(ClientContract)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
        Else
            GridView1.Visible = False
            lblErrorMsg.Text = ""
            lblmsg.Text = ""
        End If
    End Sub

    Sub DispGrid4()
        ClientContract.MyCo_Code = DdlSelectClient.SelectedValue
        ClientContract.PKID = ViewState("PKID")
        dt = BLClientContractMaster.GetClientContract(ClientContract)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
        Else
            GridView1.Visible = False
            lblErrorMsg.Text = "No Records Found"
            lblmsg.Text = ""
        End If
        GridView1.SelectedIndex = -1
    End Sub
    Sub clear()
        txtPerStudent.Text = ""
        TxtSetupChrge.Text = ""
        'txtstdate.Text = ""
        txtExpdate.Text = ""
        txtOtherCharges.Text = ""
        txtAdvance.Text = ""
        txtAdjusted.Text = ""
        txtBalance.Text = ""
        Txttsmschrge.Text = ""
        Txtemailchrge.Text = ""
        txtstdcount.Text = ""
        txtDiscount.Text = ""
    End Sub
    'Code For View Button by Nitin 12/06/2012
    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        lblmsg.Text = ""
        lblErrorMsg.Text = ""
        If btnview.Text = "VIEW" Then
            ViewState("PID") = ""
            If ViewState("PID") = "" Then
                ID = 0
            Else
                ID = ViewState("PID")
            End If
            ClientContract.MyCo_Code = DdlSelectClient.SelectedValue
            ClientContract.Branch_Code = DdlSelectBranch.SelectedValue
            dt = BLClientContractMaster.GetClientContract(ClientContract)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                DispGrid1()
                GridView1.Visible = True
                clear()
            Else
                GridView1.Visible = False
                lblErrorMsg.Text = "No Records Found."
                lblmsg.Text = ""
            End If
        End If
        If btnview.Text = "BACK" Then
            ClientContract.MyCo_Code = 0
            ClientContract.Branch_Code = 0
            btnadd.Text = "ADD"
            btnview.Text = "VIEW"
            btnlockunlock.Enabled = True
            btnReport.Enabled = True
            Btnsaleinvoice.Enabled = True
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid4()
            clear()
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        'Code For Row deleting Button By Nitin 24/07/2012
        lblErrorMsg.Text = ""
        lblmsg.Text = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            BLClientContractMaster.ChangeFlag(CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("lblPKID"), Label).Text)
            GridView1.DataBind()
            lblmsg.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            GridView1.PageIndex = ViewState("PageIndex")
            ClientContract.MyCo_Code = DdlSelectClient.SelectedValue
            ClientContract.PKID = 0
            dt = BLClientContractMaster.GetClientContract(ClientContract)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            clear()
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'Code For Row editing event By Nitin 24/07/2012
        Try
            ViewState("PKID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPKID"), Label).Text
            ViewState("MyCo_Code") = (CType(GridView1.Rows(e.NewEditIndex).FindControl("lblClient"), HiddenField).Value)
            lblErrorMsg.Text = ""
            lblmsg.Text = ""
            ClientContract.MyCo_Code = DdlSelectClient.SelectedValue
            ClientContract.MyCo_Code = ViewState("MyCo_Code")
            ClientContract.PKID = ViewState("PKID")
            btnadd.Text = "UPDATE"
            btnview.Text = "BACK"
            ClientContract.Branch_Code = DdlSelectBranch.SelectedValue
            dt = BLClientContractMaster.GetClientContract(ClientContract)
            If (Session("BranchCode") = Session("ParentBranch")) Then
                'DdlSelectClient.SelectedValue = (CType(GridView1.Rows(e.NewEditIndex).FindControl("lblClient"), HiddenField).Value)
                ' ''ViewState("PKID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblPKID"), Label).Text
                ' ''ViewState("MyCo_Code") = (CType(GridView1.Rows(e.NewEditIndex).FindControl("lblClient"), HiddenField).Value)
                DdlSelectClient.SelectedValue = dt.Rows(0).Item("MyCo_Code")
                DdlSelectBranch.Items.Clear()
                DdlSelectBranch.DataSourceID = "ObjSelectBranch"
                DdlSelectBranch.DataBind()
                DdlSelectBranch.SelectedValue = dt.Rows(0).Item("Branch_Code")
                DdlBilltype.SelectedValue = dt.Rows(0).Item("BIllTypeID")
                txtPerStudent.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblperstd"), Label).Text
                TxtSetupChrge.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblsetupCharge"), Label).Text
                Txttsmschrge.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblsmsCount"), Label).Text
                Txtemailchrge.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblemailCount"), Label).Text
                txtstdate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblstartdate"), Label).Text
                txtExpdate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblexpirydate"), Label).Text
                txtOtherCharges.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblotherCharges"), Label).Text
                txtAdvance.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAdvance"), Label).Text
                txtAdjusted.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAdjusted"), Label).Text
                'txtBalance.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblBalance"), Label).Text
                txtBalance.Text = (CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAdvance"), Label).Text) - (CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAdjusted"), Label).Text)
                txtstdcount.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblstdcount"), Label).Text
                txtDiscount.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDiscount"), Label).Text
                ddlOpenClosedStatus.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblOpenStatus"), Label).Text
                ClientContract.MyCo_Code = DdlSelectClient.SelectedValue
                ClientContract.MyCo_Code = ViewState("MyCo_Code")
                ClientContract.PKID = ViewState("PKID")
                btnadd.Text = "UPDATE"
                btnview.Text = "BACK"
                ClientContract.Branch_Code = DdlSelectBranch.SelectedValue
                dt = BLClientContractMaster.GetClientContract(ClientContract)
                GridView1.DataSource = dt
                GridView1.DataBind()
                DispGrid3()
                GridView1.Enabled = False
                btnlockunlock.Enabled = False
                btnReport.Enabled = False
                Btnsaleinvoice.Enabled = False
                GridView1.Visible = True

            Else
                lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
                lblmsg.Text = ""
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Please Select Client."
        End Try
    End Sub
    'Code For Lock And UnLock Button By Nitin 13/06/2012 
    Protected Sub btnlockunlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlockunlock.Click
        Dim id As Integer
        lblErrorMsg.Text = ""
        lblmsg.Text = ""
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("lbllockstastus"), Label).Text = "N" Then
                id = CType(rows.FindControl("lblPKID"), Label).Text
                ClientContract.PKID = id
                BLClientContractMaster.LOckStatus(ClientContract)
                lblmsg.Text = "Records Locked Successfully."
                lblErrorMsg.Text = ""
                GridView1.Enabled = False
                GridView1.Visible = True
                DispGrid2()
            Else
                id = CType(rows.FindControl("lblPKID"), Label).Text
                ClientContract.PKID = id
                BLClientContractMaster.UnLOckStatus(ClientContract)
                lblmsg.Text = "Records Unlocked Successfully."
                lblErrorMsg.Text = ""
                GridView1.Enabled = True
                DispGrid4()
            End If
        Next

    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        'Code For Report Button By Nitin 24/07/2012
        lblErrorMsg.Text = ""
        lblmsg.Text = ""
        Dim ID As Integer

        'If ViewState("PID") = "" Then
        '    ID = 0
        'Else
        '    ID = ViewState("PID")
        'End If
        'If ID = 0 Then
        '    lblErrorMsg.Text = "Please select a row to view Invoice."
        '    lblmsg.Text = ""
        'Else
        If DdlSelectClient.SelectedItem.Text = "Select" Then
            lblErrorMsg.Text = "Please Select Client."
            lblmsg.Text = ""
        Else
            lblErrorMsg.Text = ""
            lblmsg.Text = ""
            Dim MyCo_Code As String = DdlSelectClient.SelectedValue
            Dim qrystring As String = "RptClientContractV.aspx?" & QueryStr.Querystring() & "&MyCo_Code=" & MyCo_Code
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        End If
        'End If
    End Sub

    Protected Sub DdlSelectClient_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlSelectClient.SelectedIndexChanged
        lblErrorMsg.Text = ""
        lblmsg.Text = ""
        clear()
        GridView1.Visible = False
    End Sub

    Protected Sub DdlSelectBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlSelectBranch.SelectedIndexChanged
        lblErrorMsg.Text = ""
        lblmsg.Text = ""
    End Sub

    Protected Sub DdlBilltype_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlBilltype.SelectedIndexChanged
        lblErrorMsg.Text = ""
    End Sub
    Dim PID As Integer
    Dim BCode As String
    Protected Sub GridView1_SelectedIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSelectEventArgs) Handles GridView1.SelectedIndexChanging
        ViewState("PID") = CType(GridView1.Rows(e.NewSelectedIndex).FindControl("lblPKID"), Label).Text
        ViewState("BCode") = CType(GridView1.Rows(e.NewSelectedIndex).FindControl("lblBranch"), HiddenField).Value
        ViewState("SetupCharge") = CType(GridView1.Rows(e.NewSelectedIndex).FindControl("lblsetupCharge"), Label).Text
        If CType(GridView1.Rows(e.NewSelectedIndex).FindControl("ChkBx"), CheckBox).Checked = True Then
            setup = "True"
        Else
            setup = "False"
        End If
        ViewState("openclosedstatus") = CType(GridView1.Rows(e.NewSelectedIndex).FindControl("lblOpenStatus"), Label).Text
    End Sub
    Protected Sub Btnsaleinvoice_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnsaleinvoice.Click

        Try
            Dim ID As Integer
            Dim BranchCode As String
            Dim setupcharge As Double
            Dim openclosestatus As Integer
            lblErrorMsg.Text = ""
            lblmsg.Text = ""
            setupcharge = ViewState("SetupCharge")
            openclosestatus = ViewState("openclosedstatus")
            If ViewState("PID") = "" Then
                ID = 0
            Else
                ID = ViewState("PID")
            End If

            BranchCode = ViewState("BCode")
            For Each rows As GridViewRow In GridView1.Rows
                '    If CType(rows.FindControl("ChkBx"), CheckBox).Checked = True Then
                '        setup = "True"
                '        Exit For
                '    Else
                '        setup = "False"
                '    End If
                '
                If CType(rows.FindControl("ChkBx"), CheckBox).Checked = True And CType(rows.FindControl("lblPKID"), Label).Text = ViewState("PID") Then
                    setup = "True"
                    Exit For
                Else
                    setup = "False"
                End If
            Next
            If ID = 0 Then
                lblErrorMsg.Text = "Please select a row to view Invoice."
                lblmsg.Text = ""
            Else
                lblErrorMsg.Text = ""
                lblmsg.Text = ""
                Dim qrystring As String = "frmSaleInvoice.aspx?" & QueryStr.Querystring() & "&BranchCode=" & BranchCode & "&ID=" & ID & "&SetUp=" & setup & "&setupcharge=" & setupcharge & "&openclosestatus=" & openclosestatus
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "Message", "<script>openNewWin('" & qrystring & "')</script>", False)
                ViewState("PID") = ""
            End If
        Catch ex As Exception
            lblErrorMsg.Text = "Enter Correct Data"
            lblmsg.Text = ""
        End Try

    End Sub

    Protected Sub DdlBilltype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlBilltype.TextChanged
        DdlBilltype.Focus()
    End Sub

    Protected Sub DdlSelectBranch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlSelectBranch.TextChanged
        DdlSelectBranch.Focus()
    End Sub

    Protected Sub DdlSelectClient_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlSelectClient.TextChanged
        DdlSelectClient.Focus()
    End Sub
End Class



