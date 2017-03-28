
Partial Class FrmHostelDetails
    Inherits BasePage
    Dim elHostelDetails As New ELHostelDetails
    Dim BLHostelDetails As New BLHostelDetails
    Dim dt As New DataTable
    'code by Anchala on 25-08-12
    '    'method for insert and update
    Protected Sub InsertHostelDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertHostelDetails.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ddlHostelCode.Focus()
            elHostelDetails.Hostel_COde = ddlHostelCode.SelectedValue
            elHostelDetails.Room_No = txtRoomNo1.Text
            elHostelDetails.Room_Type = ddlRoomType1.SelectedValue
            If InsertHostelDetails.Text = "UPDATE" Then
                elHostelDetails.Id = ViewState("HDID")
                dt = BLHostelDetails.CheckDuplicate(elHostelDetails)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    BLHostelDetails.Update(elHostelDetails)
                    msginfo.Text = ""
                    InsertHostelDetails.Text = "ADD"
                    ViewHostelDetails.Text = "VIEW"
                    lblmsg.Text = "Data Updated Successfully."
                    txtOccupants11.Enabled = False
                    TxtHostelName1.Enabled = False
                    GvHostelDetails.PageIndex = ViewState("PageIndex")
                    txtRoomNo1.Text = ""
                    DisplayGrid()
                    ddlHostelCode.Focus()
                End If
            ElseIf InsertHostelDetails.Text = "ADD" Then
                elHostelDetails.Id = 0

                dt = BLHostelDetails.CheckDuplicate(elHostelDetails)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    BLHostelDetails.Insert(elHostelDetails)
                    msginfo.Text = ""
                    InsertHostelDetails.Text = "ADD"
                    lblmsg.Text = "Data Saved successfully."
                    txtOccupants11.Enabled = False
                    TxtHostelName1.Enabled = False
                    ViewState("PageIndex") = 0
                    GvHostelDetails.PageIndex = 0
                    DisplayGrid()
                    ddlHostelCode.Focus()
                    txtRoomNo1.Text = ""
                    DisplayGrid()
                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub DisplayGrid()
        Dim dt As New DataTable
        elHostelDetails.Id = 0
        dt = BLHostelDetails.GetHostelDetails(elHostelDetails)
        GvHostelDetails.DataSource = dt
        GvHostelDetails.DataBind()
        txtOccupants11.Enabled = False
        TxtHostelName1.Enabled = False
        GvHostelDetails.Visible = True
        GvHostelDetails.Enabled = True
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
        End If
    End Sub
    'code by Anchala on 27-08-12
    'method for view
    Protected Sub ViewHostelDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewHostelDetails.Click
        If ViewHostelDetails.Text <> "BACK" Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GvHostelDetails.PageIndex = 0
            DisplayGrid()
            GvHostelDetails.Visible = True
        Else
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewHostelDetails.Text = "VIEW"
            InsertHostelDetails.Text = "ADD"
            txtRoomNo1.Text = ""
            GvHostelDetails.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        End If
    End Sub

    Protected Sub GvHostelDetails_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvHostelDetails.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            elHostelDetails.Id = CType(GvHostelDetails.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
            BLHostelDetails.ChangeFlag(elHostelDetails)
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            GvHostelDetails.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GvHostelDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvHostelDetails.RowEditing
        lblmsg.Text = ""
        msginfo.Text = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ddlHostelCode.SelectedValue = CType(GvHostelDetails.Rows(e.NewEditIndex).FindControl("lblHostelId"), Label).Text
            txtRoomNo1.Text = CType(GvHostelDetails.Rows(e.NewEditIndex).FindControl("lblRoomNo"), Label).Text
            TxtHostelName1.Text = CType(GvHostelDetails.Rows(e.NewEditIndex).FindControl("lblHName"), Label).Text
            txtOccupants11.Text = CType(GvHostelDetails.Rows(e.NewEditIndex).FindControl("lbloccupants"), Label).Text
            ddlRoomType1.SelectedValue = CType(GvHostelDetails.Rows(e.NewEditIndex).FindControl("lblRoomTypelId"), Label).Text
            ViewState("HDID") = CType(GvHostelDetails.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
            'txtname.Text = ViewState("HM_ID")
            InsertHostelDetails.Text = "UPDATE"
            elHostelDetails.Room_Type = ddlRoomType1.SelectedValue
            txtOccupants11.Enabled = False
            TxtHostelName1.Enabled = False
            ViewHostelDetails.Text = "BACK"
            elHostelDetails.Id = ViewState("HDID")
            dt = BLHostelDetails.GetHostelDetails(elHostelDetails)
            GvHostelDetails.DataSource = dt
            GvHostelDetails.DataBind()
            GvHostelDetails.Enabled = False
        Else
            msginfo.Text = "You do not belong to this branch, Cannot edit data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub ddlRoomType1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRoomType1.SelectedIndexChanged
        elHostelDetails.Room_Type = ddlRoomType1.SelectedValue
        If ddlRoomType1.SelectedValue = 0 Then
            ddlRoomType1.Text = ""
        Else
            dt = BLHostelDetails.NoOfOccupants(elHostelDetails)
            ddlRoomType1.Text = dt.Rows(0).Item("NoOfOccupants")
        End If
        ddlRoomType1.Enabled = False
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlHostelCode.Focus()
        txtOccupants11.Enabled = False
        TxtHostelName1.Enabled = False
    End Sub

    Protected Sub ddlHostelCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHostelCode.SelectedIndexChanged
        elHostelDetails.Hostel_COde = ddlHostelCode.SelectedValue
        If ddlHostelCode.SelectedValue = 0 Then
            TxtHostelName1.Text = ""
        Else
            dt = BLHostelDetails.GetHostelName(elHostelDetails)
            TxtHostelName1.Text = dt.Rows(0).Item("HostelName")
        End If
        ddlRoomType1.Enabled = False
    End Sub
End Class
