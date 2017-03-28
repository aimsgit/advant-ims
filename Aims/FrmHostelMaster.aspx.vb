
Partial Class FrmHostelMaster
    Inherits BasePage
    Dim objBusErrMesg As New busErrorMessage
    Dim Dh As New BHostelMaster11
    Dim ElHostelMaster As New EHostelMaster11
    Dim dt As New DataTable

    'code by Anchala on 23-08-12
    '    'method for delete
    Protected Sub GvHostelMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvHostelMaster.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim ElHostelMaster As New EHostelMaster11
            ElHostelMaster.Id = CType(GvHostelMaster.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
            Dh.ChangeFlag(ElHostelMaster)
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            GvHostelMaster.PageIndex = ViewState("PageIndex")
            DisplayhostelMaster()
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GvHostelMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvHostelMaster.RowEditing
        lblmsg.Text = ""
        msginfo.Text = ""
        ElHostelMaster.Id = ViewState("HMID")
        If (Session("BranchCode") = Session("ParentBranch")) Then

            txtHostelCode.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblHostelCode"), Label).Text
            txtHostelName.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblHostelName"), Label).Text
            txtHostelType.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblHostelType"), Label).Text
            txtWarden.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblWarden"), Label).Text
            txtHouseKeeping.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblHouseKeeping"), Label).Text
            txtRemarks.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
            ViewState("HMID") = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
            'txtname.Text = ViewState("HM_ID")
            InsertHostelMaster.Text = "UPDATE"
            ViewHostelMaster.Text = "BACK"
            ElHostelMaster.Id = ViewState("HMID")
            dt = Dh.GetHostelMaster(ElHostelMaster)
            GvHostelMaster.DataSource = dt
            GvHostelMaster.DataBind()
            GvHostelMaster.Enabled = False
        Else
            msginfo.Text = "You do not belong to this branch, Cannot edit data."
            lblmsg.Text = ""
        End If

    End Sub
    'code by Anchala on 25-08-12
    '    'method for insert and update
    Protected Sub InsertHostelMaster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertHostelMaster.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            txtHostelName.Focus()
            ElHostelMaster.HostelCode = txtHostelCode.Text()
            ElHostelMaster.HostelName = txtHostelName.Text()
            ElHostelMaster.HostelType = txtHostelType.Text()
            ElHostelMaster.Warden = txtWarden.Text()
            ElHostelMaster.HouseKeeping = txtHouseKeeping.Text()
            ElHostelMaster.Remarks = txtRemarks.Text()
            If InsertHostelMaster.Text = "UPDATE" Then
                ElHostelMaster.Id = ViewState("HMID")
                dt = Dh.CheckDuplicate(ElHostelMaster)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    Dh.UpdateRecord(ElHostelMaster)
                    msginfo.Text = ""
                    InsertHostelMaster.Text = "ADD"
                    ViewHostelMaster.Text = "VIEW"
                    lblmsg.Text = "Data Updated Successfully."
                    GvHostelMaster.PageIndex = ViewState("PageIndex")
                    DisplayhostelMaster()
                    txtHostelName.Focus()
                    txtHostelCode.Text = ""
                    txtHostelName.Text = ""
                    txtHostelType.Text = ""
                    txtWarden.Text = ""
                    txtHouseKeeping.Text = ""
                    txtRemarks.Text = ""
                End If
            ElseIf InsertHostelMaster.Text = "ADD" Then
                ElHostelMaster.Id = 0
                dt = Dh.CheckDuplicate(ElHostelMaster)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    Dh.InsertRecord(ElHostelMaster)
                    msginfo.Text = ""
                    InsertHostelMaster.Text = "ADD"
                    lblmsg.Text = "Data Saved successfully."
                    ViewState("PageIndex") = 0
                    GvHostelMaster.PageIndex = 0
                    DisplayhostelMaster()
                    txtHostelName.Focus()
                    txtHostelCode.Text = ""
                    txtHostelName.Text = ""
                    txtHostelType.Text = ""
                    txtWarden.Text = ""
                    txtHouseKeeping.Text = ""
                    txtRemarks.Text = ""
                    ClearHostelMaster()
                    'End If
                    DisplayhostelMaster()
                End If
                ' End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GvHostelMaster_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvHostelMaster.PageIndexChanging
        GvHostelMaster.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GvHostelMaster.PageIndex
        DisplayhostelMaster()
    End Sub
    'code by Anchala on 25-08-12
    '    'method for view
    Protected Sub ViewHostelMaster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewHostelMaster.Click
        ' GvHostelMaster.DataSourceID = "ObjectDataSource1"
        'lblmsg.Visible = True
        msginfo.Text = ""
        If ViewHostelMaster.Text <> "BACK" Then
            'Dim CategoryManager As New CategoryManager
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GvHostelMaster.PageIndex = 0
            DisplayhostelMaster()
            GvHostelMaster.Visible = True

        Else
            'ClearHostelMaster()
            'Enable()
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewHostelMaster.Text = "VIEW"
            InsertHostelMaster.Text = "ADD"
            txtHostelCode.Text = ""
            txtHostelName.Text = ""
            txtHostelType.Text = ""
            txtWarden.Text = ""
            txtHouseKeeping.Text = ""
            txtRemarks.Text = ""
            GvHostelMaster.Visible = True
            'Disable()
            GvHostelMaster.PageIndex = ViewState("PageIndex")
            DisplayhostelMaster()
        End If
    End Sub
    Sub DisplayhostelMaster()
        Dim dt As New DataTable
        ElHostelMaster.Id = 0
        dt = Dh.GetHostelMaster(ElHostelMaster)
        GvHostelMaster.DataSource = dt
        GvHostelMaster.DataBind()

        GvHostelMaster.Visible = True
        GvHostelMaster.Enabled = True
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ""

            msginfo.Text = "No records to display."
            'msginfo.Visible = True
        End If
    End Sub


    '<System.Web.Services.WebMethod()> Public Sub AbandonSession()
    'Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    '   Response.Redirect("LogIn.aspx")
    'End Sub
    Sub ClearHostelMaster()
        txtHostelCode.Text = ""
        txtHostelName.Text = ""
        txtHostelType.Text = ""
        txtWarden.Text = ""
        txtHouseKeeping.Text = ""
        txtRemarks.Text = ""
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtHostelName.Focus()
    End Sub
End Class
