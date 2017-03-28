
Partial Class FrmCapacityPlan
    Inherits BasePage
    Dim EL As New ELCapacityPlan
    Dim dt As New DataTable
    Dim BL As New BLCapacityPlan

    Protected Sub InsertButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertButton.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Dept = ddlDept.SelectedValue
            EL.Grade = ddlGrade.SelectedValue
            EL.NosReq = txtNoOfReq.Text
            EL.Year = ddlYear.SelectedItem.Text
            If txtDateReq.Text = "" Then
                EL.Reqdate = "1/1/1900"
            Else
                EL.Reqdate = txtDateReq.Text
            End If
            EL.Remarks = txtRemarks.Text
            If InsertButton.Text = "UPDATE" Then
                EL.Id = ViewState("HID")
                dt = BL.CheckDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    BL.Update(EL)
                    msginfo.Text = ""
                    InsertButton.Text = "ADD"
                    btnDet.Text = "VIEW"
                    lblmsg.Text = "Data Updated Successfully."
                    GvCapacity.PageIndex = ViewState("PageIndex")
                    DisplayGrid()
                    clear()

                End If
            ElseIf InsertButton.Text = "ADD" Then
                EL.Id = 0
                dt = BL.CheckDuplicate(EL)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    BL.Insert(EL)
                    msginfo.Text = ""
                    InsertButton.Text = "ADD"
                    lblmsg.Text = "Data Saved successfully."
                    ViewState("PageIndex") = 0
                    GvCapacity.PageIndex = 0
                    DisplayGrid()
                    clear()
                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add data."
            lblmsg.Text = ""
        End If
    End Sub
    Sub DisplayGrid()
        Dim dt As New DataTable
        EL.Id = 0
        dt = BL.GetCapacityPlan(EL)
        If dt.Rows.Count <> 0 Then
            GvCapacity.DataSource = dt
            GvCapacity.DataBind()
            GvCapacity.Enabled = True
            GvCapacity.Visible = True
        Else
            GvCapacity.Enabled = False
            GvCapacity.Visible = False
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
        End If
    End Sub

    Protected Sub btnDet_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDet.Click
        If btnDet.Text <> "BACK" Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GvCapacity.PageIndex = 0
            DisplayGrid()
            GvCapacity.Visible = True
        Else
            lblmsg.Text = ""
            msginfo.Text = ""
            btnDet.Text = "VIEW"
            InsertButton.Text = "ADD"
            GvCapacity.PageIndex = ViewState("PageIndex")
            DisplayGrid()
            clear()
        End If
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtDateReq.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
    Sub clear()
        txtDateReq.Text = ""
        txtNoOfReq.Text = ""
        txtRemarks.Text = ""
    End Sub

    Protected Sub GvCapacity_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvCapacity.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            EL.Id = CType(GvCapacity.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
            BL.ChangeFlag(EL)
            lblmsg.Text = "Data deleted successfully."
            msginfo.Text = ""
            GvCapacity.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        Else
            msginfo.Text = ""
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub GvCapacity_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvCapacity.RowEditing
        lblmsg.Text = ""
        msginfo.Text = ""
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        ddlDept.SelectedValue = CType(GvCapacity.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        ddlGrade.SelectedValue = CType(GvCapacity.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        txtNoOfReq.Text = CType(GvCapacity.Rows(e.NewEditIndex).FindControl("lblNosReq"), Label).Text
        ddlYear.SelectedItem.Text = CType(GvCapacity.Rows(e.NewEditIndex).FindControl("lblYear"), Label).Text
        txtDateReq.Text = CType(GvCapacity.Rows(e.NewEditIndex).FindControl("lblReqdate"), Label).Text
        txtRemarks.Text = CType(GvCapacity.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
        ViewState("HID") = CType(GvCapacity.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
        InsertButton.Text = "UPDATE"
        btnDet.Text = "BACK"
        EL.Id = ViewState("HID")
        dt = BL.GetCapacityPlan(EL)
        GvCapacity.DataSource = dt
        GvCapacity.DataBind()
        GvCapacity.Enabled = False
        GvCapacity.Visible = True
    End Sub
End Class
