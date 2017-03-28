Partial Class frmRoomType
    Inherits BasePage
    Dim EL As New RoomTypeE
    Dim BL As New RoomTypeB
    Dim DL As New RoomTypeD
    Dim dt As DataTable

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtRoomType.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                lblerrmsg.Text = ""
                EL.RoomType = txtRoomType.Text
                If txtOccupant.Text = "" Then
                    EL.Occupant = 0
                Else
                    EL.Occupant = txtOccupant.Text
                End If
                EL.Remarks = txtRemarks.Text
                If btnSave.Text = "UPDATE" Then
                    EL.id = ViewState("RoomTypeAuto")
                    dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        lblerrmsg.Text = "Data already exists."
                        lblmsgifo.Text = " "
                    Else

                        BL.UpdateRecord(EL)
                        btnSave.Text = "ADD"
                        btnDetails.Text = "VIEW"
                        Clear()
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Updated Successfully."
                        DisplayGridView()
                        GVRoomType.PageIndex = ViewState("PageIndex")
                        GVRoomType.Enabled = True
                    End If
                ElseIf btnSave.Text = "ADD" Then
                    dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        lblerrmsg.Text = "Data already exists."
                        lblmsgifo.Text = " "
                    Else
                        BL.InsertRecord(EL)
                        lblerrmsg.Text = ""
                        lblmsgifo.Text = "Data Saved Successfully."
                        Clear()
                        DisplayGridView()
                        GVRoomType.Enabled = True
                        ViewState("PageIndex") = 0
                        GVRoomType.PageIndex = 0
                    End If
                    End If
            Catch ex As Exception
                lblerrmsg.Text = "Enter correct data."
                lblmsgifo.Text = ""
            End Try

        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot add data."
            lblmsgifo.Text = ""
        End If
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        If btnDetails.Text <> "BACK" Then
            DisplayGridView()
            ViewState("PageIndex") = 0
            GVRoomType.PageIndex = 0
            Clear()
        Else
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            Clear()
            btnSave.Text = "ADD"
            btnDetails.Text = "VIEW"
            btnDetails.Text = "VIEW"
            btnSave.Text = "ADD"
            GVRoomType.PageIndex = ViewState("PageIndex")
            DisplayGridView()
            GVRoomType.Enabled = True

        End If

    End Sub
    Sub Clear()
        txtRoomType.Text = ""
        txtOccupant.Text = ""
        txtRemarks.Text = ""

    End Sub
    Sub DisplayGridView()
        EL.id = 0
        dt = BL.GetRoomType(EL)
        If dt.Rows.Count = 0 Then
            lblmsgifo.Text = ""
            lblerrmsg.Text = "No records to display."
            GVRoomType.Visible = False
        Else
            GVRoomType.Enabled = True
            GVRoomType.Visible = True
            GVRoomType.DataSource = dt
            GVRoomType.DataBind()
        End If
    End Sub

    Protected Sub GVRoomType_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVRoomType.PageIndexChanging
        GVRoomType.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVRoomType.PageIndex
        DisplayGridView()
        GVRoomType.Visible = True
        lblmsgifo.Text = ""
        lblerrmsg.Text = ""
    End Sub
    Protected Sub GVRoomType_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVRoomType.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.id = CType(GVRoomType.Rows(e.RowIndex).FindControl("id"), Label).Text

            BL.DeleteRecord(EL)
            lblerrmsg.Text = ""
            lblmsgifo.Text = "Data Deleted Successfully."
            DisplayGridView()
            GVRoomType.Visible = True
            GVRoomType.Enabled = True
            GVRoomType.PageIndex = ViewState("PageIndex")
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsgifo.Text = ""
        End If
    End Sub
    Protected Sub GVRoomType_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVRoomType.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then

            btnSave.Text = "UPDATE"
            btnDetails.Text = "BACK"
            lblmsgifo.Text = ""
            lblerrmsg.Text = ""
            btnDetails.Visible = True
            txtRoomType.Text = CType(GVRoomType.Rows(e.NewEditIndex).FindControl("lblRoomType"), Label).Text
            txtOccupant.Text = CType(GVRoomType.Rows(e.NewEditIndex).FindControl("lblOccupant"), Label).Text
            txtRemarks.Text = CType(GVRoomType.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
            ViewState("RoomTypeAuto") = CType(GVRoomType.Rows(e.NewEditIndex).FindControl("id"), Label).Text
            EL.id = ViewState("RoomTypeAuto")
            dt = BL.GetRoomType(EL)
            GVRoomType.DataSource = dt
            GVRoomType.DataBind()
            GVRoomType.Visible = True
            GVRoomType.Enabled = False
        Else
            lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
            lblmsgifo.Text = ""
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtRoomType.Focus()
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
    End Sub
    'Method is for Session exipire 
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
