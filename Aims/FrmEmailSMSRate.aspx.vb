
Partial Class FrmEmailSMSRate
    Inherits BasePage
    Dim ESMSRate As New EmailSMSRate
    Dim ESMSRateBL As New EmailSMSRateBL
    Dim ESMSRateDL As New EmailSMSRateDL
    Dim Dt As New DataTable
    Dim DtVal As New DataTable

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'If Not IsPostBack Then
        '    txtFromDate.Text = Format(Date.Today, "dd-MMM-yyyy")
        'End If
        If Not IsPostBack Then
            Dim CloseDate As Date
            Dim cd As String
            CloseDate = System.DateTime.Now
            cd = CloseDate.ToString("dd-MMM-yyyy")
            txtFromDate.Text = cd
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ESMSRate.InstituteId = DdlSelectClient.SelectedValue
        ESMSRate.BranchId = DdlSelectBranch.SelectedValue
        If txtFromDate.Text = "" Then
            lblMsg.Text = ""
            msginfo.Text = "From Date is Mandatory."
            Exit Sub
        Else
            ESMSRate.FromDate = txtFromDate.Text
        End If
        If txtToDate.Text <> "" Then
            If txtToDate.Text < txtFromDate.Text Then
                lblMsg.Text = ""
                msginfo.Text = "From Date cannot be greater than To Date."
                Exit Sub
            Else
                ESMSRate.ToDate = txtToDate.Text
            End If
        End If


        'If btnAdd.Text = "ADD" Then
        '    ESMSRate.ValId = 0
        'Else
        '    ESMSRate.ValId = 1
        'End If
        DtVal = EmailSMSRateDL.GetData(ESMSRate)
        If btnAdd.Text = "ADD" Then
            If txtSMSRate.Text = "" Then
                lblMsg.Text = ""
                msginfo.Text = "SMS Rate is Mandatory."
            ElseIf TxtEmailRate.Text = "" Then
                lblMsg.Text = ""
                msginfo.Text = "Email Rate is Mandatory."
            ElseIf DtVal.Rows.Count > 0 Then
                lblMsg.Text = ""
                msginfo.Text = "Email and SMS Rate already generated for " + DtVal.Rows(0).Item("MyCo_Name").ToString() + " for above date."
                'ElseIf txtToDate.Text <> "" Then
                '    If txtToDate.Text < txtFromDate.Text Then
                '        lblMsg.Text = ""
                '        msginfo.Text = "From Date cannot be greater than To Date."
                '    End If

            Else
                ESMSRate.InstituteId = DdlSelectClient.SelectedValue
                ESMSRate.BranchId = DdlSelectBranch.SelectedValue
                ESMSRate.FromDate = txtFromDate.Text
                If txtToDate.Text = "" Then
                    ESMSRate.ToDate = "1/1/1900"
                Else
                    ESMSRate.ToDate = txtToDate.Text
                End If

                ESMSRate.SMSRate = txtSMSRate.Text
                ESMSRate.EmailRate = TxtEmailRate.Text
                EmailSMSRateBL.InsertEmailSMSRate(ESMSRate)
                lblMsg.Text = "Data Added Successfully."
                msginfo.Text = ""
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                DisplayGridView()
                Clear()
            End If
        Else
            If txtSMSRate.Text = "" Then
                lblMsg.Text = ""
                msginfo.Text = "SMS Rate is Mandatory."
            ElseIf TxtEmailRate.Text = "" Then
                lblMsg.Text = ""
                msginfo.Text = "Email Rate is Mandatory."
                'ElseIf DtVal.Rows.Count > 0 Then
                '    lblMsg.Text = ""
                '    msginfo.Text = "Email and SMS Rate already generated for " + DtVal.Rows(0).Item("MyCo_Name").ToString() + " for above date."
            Else
                ESMSRate.InstituteId = DdlSelectClient.SelectedValue
                ESMSRate.BranchId = DdlSelectBranch.SelectedValue
                ESMSRate.FromDate = txtFromDate.Text
                If txtToDate.Text = "" Then
                    ESMSRate.ToDate = "1/1/1900"
                Else
                    ESMSRate.ToDate = txtToDate.Text
                End If
                ESMSRate.SMSRate = txtSMSRate.Text
                ESMSRate.EmailRate = TxtEmailRate.Text
                ESMSRate.Id = ViewState("ID")
                EmailSMSRateBL.UpdateEmailSMSRate(ESMSRate)
                lblMsg.Text = "Data Updated Successfully."
                msginfo.Text = ""
                GridView1.PageIndex = ViewState("PageIndex")
                DisplayGridView()
                btnAdd.Text = "ADD"
                BtnView.Text = "VIEW"
                Clear()

            End If
        End If
    End Sub
    Sub DisplayGridView()
        If DdlSelectClient.SelectedValue = "0" Then
            ESMSRate.InstituteId = 0
        Else
            ESMSRate.InstituteId = DdlSelectClient.SelectedValue
        End If
        If DdlSelectBranch.SelectedValue = "0" Then
            ESMSRate.BranchId = 0
        Else
            ESMSRate.BranchId = DdlSelectBranch.SelectedValue
        End If
        If txtFromDate.Text = "" Then
            ESMSRate.FromDate = "1/1/1999"
        Else
            ESMSRate.FromDate = txtFromDate.Text
        End If
        If txtToDate.Text = "" Then
            ESMSRate.ToDate = "1/1/1999"
        Else
            ESMSRate.ToDate = txtToDate.Text
        End If
        Dt = EmailSMSRateBL.EmailSMSRateGridview(ESMSRate)
        If Dt.Rows.Count > 0 Then
            GridView1.Visible = True
            GridView1.DataSource = Dt
            GridView1.DataBind()
            GridView1.Enabled = True
        Else
            GridView1.Visible = False
            msginfo.Text = "No records to Dispaly."
            lblMsg.Text = ""
        End If
    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        lblMsg.Text = ""
        msginfo.Text = ""
        If BtnView.Text = "VIEW" Then
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DisplayGridView()
        ElseIf BtnView.Text = "BACK" Then
            btnAdd.Text = "ADD"
            BtnView.Text = "VIEW"
            GridView1.PageIndex = ViewState("PageIndex")
            DdlSelectClient.Items.Clear()
            DdlSelectClient.DataSourceID = "ObjSelectClient"
            DdlSelectClient.DataBind()
            DdlSelectBranch.Items.Clear()
            DdlSelectBranch.DataSourceID = "ObjSelectBranch"
            DdlSelectBranch.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
            Clear()
        End If

    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGridView()
        GridView1.Visible = True
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim RowsEffected As Integer
        ESMSRate.Id = CType(GridView1.Rows(e.RowIndex).FindControl("lblID"), Label).Text
        RowsEffected = EmailSMSRateBL.DeleteEmailSMSRate(ESMSRate)
        lblMsg.Text = ""
        msginfo.Text = "Data deleted Successfully."
        GridView1.PageIndex = ViewState("PageIndex")

        'Dt = EmailSMSRateBL.EmailSMSRateGridview(ESMSRate)
        'GridView1.DataSource = Dt
        'GridView1.DataBind()
        DisplayGridView()

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblMsg.Text = ""
        msginfo.Text = ""
        Dim Id As Integer
        ViewState("ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblID"), Label).Text
        DdlSelectClient.Items.Clear()
        DdlSelectClient.DataSourceID = "ObjSelectClient"
        DdlSelectClient.DataBind()
        DdlSelectClient.SelectedValue = Trim(CType(GridView1.Rows(e.NewEditIndex).FindControl("LblInstituteCode"), Label).Text)
        DdlSelectBranch.Items.Clear()
        DdlSelectBranch.DataSourceID = "ObjSelectBranch"
        DdlSelectBranch.DataBind()
        DdlSelectBranch.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblBranchCode"), HiddenField).Value
        txtFromDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblFromDate"), Label).Text
        txtToDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblToDate"), Label).Text
        txtSMSRate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblSMSRate"), Label).Text
        TxtEmailRate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblEmailRate"), Label).Text
        btnAdd.Text = "UPDATE"
        BtnView.Text = "BACK"
        Id = ViewState("ID")
        Dt = EmailSMSRateBL.GetSMSRateGridview(Id)
        GridView1.DataSource = Dt
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = False

    End Sub

    Protected Sub DdlSelectBranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlSelectBranch.SelectedIndexChanged
        lblMsg.Text = ""

    End Sub

    Protected Sub DdlSelectClient_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlSelectClient.SelectedIndexChanged
        lblMsg.Text = ""
    End Sub
    Sub Clear()
        txtFromDate.Text = ""
        txtToDate.Text = ""
        TxtEmailRate.Text = ""
        txtSMSRate.Text = ""
    End Sub
End Class
