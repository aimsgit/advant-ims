
Partial Class frmTableMaster
    Inherits BasePage
    Dim dt As New DataTable
    Dim BLL As New BLTableMaster
    Dim a, b As Integer
    Dim GlobalFunction As New GlobalFunction
    Dim prop As New TableMaster

    Sub DispGrid()
        prop.BranchCode = ddlHO.SelectedValue
        Dim dt2 As New DataTable
        lblErrorMsg.Text = ""
        lblgreen.Text = ""
        dt = BLL.GetTableMasterRecords(prop)
        GVTableMaster.DataSource = dt
        GVTableMaster.DataBind()
        GVTableMaster.Enabled = True
        If dt.Rows.Count = 0 Then
            lblErrorMsg.Text = "No Records to Display."
        End If
    End Sub

    Protected Sub Btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnadd.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Dim prop As New TableMaster
                If Btnadd.Text = "ADD" Then
                    prop.BranchCode = ddlHO.SelectedValue
                    prop.TableName = DDLTableMaster.SelectedItem.Text
                    prop.TableAL = ddlPS.SelectedValue
                    Dim str As String = DDLTableMaster.SelectedValue
                    Session("Table_ID") = DDLTableMaster.SelectedValue
                    prop.TableID = Session("Table_ID")
                    If BLL.InsertRecord(prop) > 0 Then
                        DispGrid()
                        lblErrorMsg.Text = ""
                        lblgreen.Text = "Data Saved Successfully."
                    Else
                        lblgreen.Text = ""
                        lblErrorMsg.Text = "Data already exists."
                    End If
                End If
            Else
                lblErrorMsg.Text = "No Write Permission!"
            End If

        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add data."
            lblgreen.Text = ""
        End If

    End Sub

    Protected Sub BtnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnReport.Click
        a = GlobalFunction.UserPrivilage()
        If a = 1 Or a = 2 Or a = 3 Or a = 4 Then
            If BtnReport.Text = "BACK" Then
                Btnadd.Text = "ADD"
                BtnReport.Text = "VIEW"
                DispGrid()
                DDLTableMaster.SelectedIndex = 0
                ddlPS.SelectedIndex = 0
            Else
                DispGrid()
            End If
        Else
            lblErrorMsg.Text = "No Read Permission!"
        End If
    End Sub
    Protected Sub GVTableMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVTableMaster.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Dim Prop As New TableMaster
                Prop.TableID = CType(GVTableMaster.Rows(e.RowIndex).FindControl("lblTable_ID"), Label).Text
                BLL.DeleteRecord(Prop)
                lblErrorMsg.Visible = True
                DispGrid()
                lblgreen.Text = "Data deleted successfully"
                lblErrorMsg.Text = ""
            Else
                lblgreen.Text = ""
                lblErrorMsg.Text = "No Delete Permission!"
            End If
        Else
            lblgreen.Text = ""
            lblErrorMsg.Text = "No Delete Permission!"
        End If
    End Sub

    Protected Sub GVTableMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVTableMaster.RowEditing
        If (Session("BranchCode") = Session("ParentBranch")) Then
            a = GlobalFunction.UserPrivilage()
            If a = 1 Or a = 2 Or a = 6 Or a = 7 Then
                Btnadd.Text = "UPDATE"
                BtnReport.Text = "BACK"
                lblErrorMsg.Text = ""
                lblgreen.Text = ""
                Session("Table_ID") = CType(GVTableMaster.Rows(e.NewEditIndex).Cells(1).FindControl("Label5"), Label).Text
                DDLTableMaster.SelectedValue = CType(GVTableMaster.Rows(e.NewEditIndex).Cells(1).FindControl("Label5"), Label).Text
                ddlPS.SelectedValue = CType(GVTableMaster.Rows(e.NewEditIndex).Cells(1).FindControl("lblTAL"), Label).Text
                ddlHO.SelectedValue = CType(GVTableMaster.Rows(e.NewEditIndex).Cells(1).FindControl("lblBranchCode"), Label).Text

                Dim prop As New TableMaster
                prop.TableID = Session("Table_ID")
                prop.BranchCode = ddlHO.SelectedValue
                dt = BLL.GetTableMasterRecords(prop)
                GVTableMaster.DataSource = dt
                GVTableMaster.DataBind()
                GVTableMaster.Enabled = False
            Else
                lblgreen.Text = ""
                lblErrorMsg.Text = "No Edit Permission!"
            End If

        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
            lblgreen.Text = ""
        End If

    End Sub

    Protected Sub GVTableMaster_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVTableMaster.PageIndexChanging
        lblErrorMsg.Text = ""
        lblgreen.Text = ""
        GVTableMaster.PageIndex = e.NewPageIndex
        DispGrid()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("BranchCode") <> "000000000000" Then
            Response.Redirect("AccessDenied.aspx")
        Else
            Me.Lblheading.Text = Session("RptFrmTitleName")
        End If
    End Sub
End Class
