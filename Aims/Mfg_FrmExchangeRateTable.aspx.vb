
Partial Class Mfg_FrmExchangeRateTable
    Inherits BasePage
    Dim EL As New ELExchangeRateTable
    Dim dt As New DataTable
    Dim BL As New BLExchangeRateTable
    'code by Anchala on 04-09-12
    'method for insert and update
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.CName = Txtcname.Text
            EL.CSymbol = Txtsymbol.Text
            EL.BRate = Txtbuyrate.Text
            EL.SRate = Txtsalerate.Text
            EL.Cone = Txtcone.Text
            EL.Ctwo = Txtctwo.Text
            If btnAdd.Text <> "UPDATE" Then
                EL.Id = 0
                dt = BL.GetDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ""
                    msginfo.Text = "Data already exists"
                    Txtcname.Focus()
                Else
                    BL.Insert(EL)
                    btnAdd.Text = "ADD"
                    lblmsg.Text = "Data Saved Successfully."
                    Txtcname.Focus()
                    msginfo.Text = ""
                    ViewState("PageIndex") = 0
                    GVExchangeRate.PageIndex = 0
                    DispGrid()
                    clear()
                End If

            ElseIf btnAdd.Text = "UPDATE" Then

                EL.Id = ViewState("Currency_Code")
                dt = BL.GetDuplicate(EL)

                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ""
                    msginfo.Text = "Data already exists"
                    Txtcname.Focus()
                Else
                    BL.Update(EL)
                    btnAdd.Text = "ADD"
                    btnView.Text = "VIEW"
                    lblmsg.Text = "Data Updated Successfully."
                    msginfo.Text = ""
                    Txtcname.Focus()
                    clear()
                    GVExchangeRate.PageIndex = ViewState("PageIndex")
                    DispGrid()
                End If
            End If


        Else
            msginfo.Text = "You do not belong to this branch, Cannot generate data."
            lblmsg.Text = ""

        End If
    End Sub
    'code by Anchala on 04-09-12
    '    'method for display
    Sub DispGrid()
        Dim dt As New DataTable
        EL.Id = 0
        GVExchangeRate.Enabled = True
        dt = BL.GetData(EL)
        If dt.Rows.Count > 0 Then
            GVExchangeRate.DataSource = dt
            GVExchangeRate.DataBind()
        Else
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
        End If
    End Sub
    Sub clear()
        Txtcname.Text = ""
        Txtsymbol.Text = ""
        Txtbuyrate.Text = ""
        Txtsalerate.Text = ""
        Txtcone.Text = ""
        Txtctwo.Text = ""
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        LinkButton1.Focus()
        If btnView.Text = "VIEW" Then
            msginfo.Text = ""
            lblmsg.Text = ""
            ViewState("PageIndex") = 0
            GVExchangeRate.PageIndex = 0
            DispGrid()
        ElseIf btnView.Text = "BACK" Then
            btnAdd.Text = "ADD"
            btnView.Text = "VIEW"
            msginfo.Text = ""
            clear()
            GVExchangeRate.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub

    Protected Sub GVExchangeRate_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVExchangeRate.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Id = CType(GVExchangeRate.Rows(e.RowIndex).FindControl("GID"), HiddenField).Value
            BL.ChangeFlag(EL)
            GVExchangeRate.DataBind()
            'lblmsg.Visible = True
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            Txtcname.Focus()
            clear()
            GVExchangeRate.PageIndex = ViewState("PageIndex")
            DispGrid()
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GVExchangeRate_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVExchangeRate.RowEditing
        Txtcname.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim dt As New DataTable
            btnAdd.Text = "UPDATE"
            btnView.Visible = True
            btnView.Text = "BACK"
            lblmsg.Text = ""
            msginfo.Text = " "
            GVExchangeRate.Visible = True
            ViewState("Currency_Code") = CType(GVExchangeRate.Rows(e.NewEditIndex).FindControl("GID"), HiddenField).Value
            Txtcname.Text = CType(GVExchangeRate.Rows(e.NewEditIndex).FindControl("Lblcname"), Label).Text
            Txtsymbol.Text = CType(GVExchangeRate.Rows(e.NewEditIndex).FindControl("Lblsymbol"), Label).Text
            Txtbuyrate.Text = CType(GVExchangeRate.Rows(e.NewEditIndex).FindControl("Lblbrate"), Label).Text
            Txtsalerate.Text = CType(GVExchangeRate.Rows(e.NewEditIndex).FindControl("Lblsrate"), Label).Text
            Txtcone.Text = CType(GVExchangeRate.Rows(e.NewEditIndex).FindControl("Lblcone"), Label).Text
            Txtctwo.Text = CType(GVExchangeRate.Rows(e.NewEditIndex).FindControl("Lblctwo"), Label).Text
            EL.Id = ViewState("Currency_Code")
            dt = BL.GetData(EL)
            GVExchangeRate.DataSource = dt
            GVExchangeRate.DataBind()
            GVExchangeRate.Enabled = False
        Else
            msginfo.Text = "You do not belong to this branch, Cannot edit data."
            lblmsg.Text = ""
        End If

    End Sub
  
End Class
