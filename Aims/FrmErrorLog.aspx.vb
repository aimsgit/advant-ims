
Partial Class FrmErrorLog
    Inherits BasePage
    Dim El As New ElErrorLog
    Dim Bl As New BLErrorLog
    Dim dt As New DataTable
    'Anchala Verma 01-05-2012
    'Code for view data
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Try

        
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GVErrorLog.PageIndex = 0
            Display()
            If cmbStatus.SelectedItem.Text = "Close" Then
                BtnClose.Enabled = False
            ElseIf cmbStatus.SelectedItem.Text = "Open" Then
                BtnClose.Visible = True
            ElseIf cmbStatus.SelectedItem.Text = "All" Then
                BtnClose.Visible = True
            End If
        Catch ex As Exception
            msginfo.Text = "Date is not valid"
        End Try
    End Sub

    'Anchala Verma 01-05-2012
    'Code for delete data
    Protected Sub GVErrorLog_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVErrorLog.RowDeleting
        El.LogId = CType(GVErrorLog.Rows(e.RowIndex).FindControl("IID"), HiddenField).Value
        Bl.DeleteErrorLog(El)
        lblmsg.Text = "Data Deleted Successfully."
        msginfo.Text = ""
        GVErrorLog.PageIndex = ViewState("PageIndex")
        Display()  
    End Sub
    Sub Display()
        If TxtFromdate.Text = "" Then
            El.EDate = "1/1/3000"

        Else
            El.EDate = TxtFromdate.Text
        End If
        If txtTodate.Text = "" Then
            El.TDate = "1/1/3000"

        Else
            El.TDate = txtTodate.Text

        End If
        If El.EDate = "1/1/3000" Or El.TDate = "1/1/3000" Then
        ElseIf CType(TxtFromdate.Text, Date) > CType(txtTodate.Text, Date) Then
            msginfo.Text = ""
            msginfo.Text = "'From' date should be lesser than 'To' date."
            TxtFromdate.Focus()
            Exit Sub
        End If


        El.Estatus = cmbStatus.SelectedValue
        dt = Bl.ShowLog(El)
        If dt.Rows.Count > 0 Then
            GVErrorLog.DataSource = dt
            GVErrorLog.Visible = True
            GVErrorLog.Enabled = True
            GVErrorLog.DataBind()
            txttotalcount.Text = dt.Rows.Count
            If El.EDate = "1/1/3000" Then
                txtTodate.Text = ""
                TxtFromdate.Text = ""
            End If
        Else
            lblmsg.Text = ""
            msginfo.Text = "No Records to display"
            txttotalcount.Text = dt.Rows.Count
            GVErrorLog.Visible = False
            'txtTodate.Text = ""
            'TxtFromdate.Text = ""
        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("BranchCode") <> "000000000000" Then
            Response.Redirect("AccessDenied.aspx")
        End If
        txttotalcount.Enabled = False
        BtnClose.Visible = True
        If Not Page.IsPostBack Then
            txtTodate.Text = Format(Today(), "dd-MMM-yyyy")
            TxtFromdate.Text = Format(Today(), "dd-MMM-yyyy")
        End If
    End Sub
    Protected Sub GVErrorLog_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVErrorLog.PageIndexChanging
        GVErrorLog.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVErrorLog.PageIndex
        Display()
    End Sub
    'Anchala Verma 01-05-2012
    'Code for update data
    Protected Sub GVErrorLog_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GVErrorLog.RowUpdating
        ViewState("LogId") = CType(GVErrorLog.Rows(e.RowIndex).FindControl("IID"), HiddenField).Value
        El.Estatus = CType(GVErrorLog.Rows(e.RowIndex).FindControl("l5"), Label).Text
        El.LogId = ViewState("LogId")
        Bl.Close(El)
        Display()
    End Sub
    Protected Sub GVErrorLog_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVErrorLog.RowEditing
        Dim qrystring As String = "frmErrorMessageDisplay.aspx?" & "&LogId=" & CType(GVErrorLog.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub

    Protected Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Dim id As String = ""
        Dim check As String = ""
        Dim id1 As String = ""
        Dim count As New Integer
        For Each grid As GridViewRow In GVErrorLog.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = False Then
                lblmsg.Text = ""
                msginfo.Text = "Please select record(s) to close."
            End If
        Next
        For Each grid As GridViewRow In GVErrorLog.Rows
            If CType(grid.FindControl("ChkBx"), CheckBox).Checked = True Then
                check = CType(grid.FindControl("l5"), Label).Text
                If check = "Open" Then
                    ViewState("LogId") = CType(grid.FindControl("IID"), HiddenField).Value
                    El.Estatus = CType(grid.FindControl("l5"), Label).Text
                    'El.Estatus = CType(GVErrorLog.Rows(e.RowIndex).FindControl("l5"), Label).Text
                    El.LogId = ViewState("LogId")
                    msginfo.Text = ""
                    Bl.Close(El)
                    GVErrorLog.PageIndex = ViewState("PageIndex")
                    Display()
                    msginfo.Text = ""
                    lblmsg.Text = "Error message(s) closed successfully."
                    BtnClose.Visible = True

                Else
                    lblmsg.Text = ""
                    msginfo.Text = "Error Message(s) is already closed"

                End If
            End If

        Next



    
    End Sub

    Protected Sub cmbStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        If cmbStatus.SelectedItem.Text = "Close" Then
            BtnClose.Enabled = False
        ElseIf cmbStatus.SelectedItem.Text = "Open" Then
            BtnClose.Enabled = True
            BtnClose.Visible = True
        ElseIf cmbStatus.SelectedItem.Text = "All" Then
            BtnClose.Enabled = True
            BtnClose.Visible = True
        End If
    End Sub
End Class
