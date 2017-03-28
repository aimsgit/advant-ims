Imports System.Web.UI.Control
Imports System.Web.UI.WebControls

Partial Class frmPropertyLotMaster
    Inherits BasePage
    Dim EL As New ELProperty
    Dim BL As New BLPropertyLot
    Dim DL As New DLPropertyLot
    Dim dt1 As New DataTable
    Protected Sub btnAdds_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdds.Click
        Try

        
            If (Session("BranchCode") = Session("ParentBranch")) Then
                Dim dt1 As New DataTable

                EL.Lot_Number = txtLotNumber.Text
                If txtSaleDate.Text = "" Then
                    EL.SaleDate = Format(Today, "dd-MMM-yyyy")

                Else
                    EL.SaleDate = txtSaleDate.Text
                End If
                'EL.SaleDate = txtSaleDate.Text
                EL.Properties = ddlProject.SelectedValue
                If txtNoOfUnits.Text = "" Then
                    EL.NoofUnits = 0
                Else
                    EL.NoofUnits = txtNoOfUnits.Text
                End If
                If txtAveragePrice.Text = "" Then
                    EL.Avg_price = 0.0
                Else
                    EL.Avg_price = txtAveragePrice.Text
                End If

                EL.Location = txtLocation.Text
                EL.LotStatus = ddlLot.Text.ToString()

                If btnAdds.Text <> "UPDATE" Then
                    EL.ID = 0
                    dt1 = BL.CheckDuplicate(EL)
                    If dt1.Rows.Count > 0 Then
                        lblerrmsg.Text = "data already existes."
                        lblmsg.Text = ""
                        'Clear()
                        'txtdeptname.Focus()
                        Exit Sub
                    Else
                        BL.InsertRecord(EL)
                        Display()
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        lblmsg.Text = "Data saved successfully."
                        lblerrmsg.Text = ""
                        Clear()
                    End If
                Else
                    EL.ID = ViewState("ID")
                    dt1 = BL.CheckDuplicate(EL)
                    If dt1.Rows.Count > 0 Then
                        lblerrmsg.Text = "data already existes."
                        lblmsg.Text = ""
                        'txtdeptname.Focus()
                        Exit Sub
                    End If
                    BL.Update(EL)
                    GridView1.PageIndex = ViewState("PageIndex")
                    Display()
                    lblmsg.Text = "Data updated successfully."
                    lblerrmsg.Text = ""
                    Clear()
                    btnAdds.Text = "ADD"
                    btnviews.Text = "VIEW"
                End If
            Else
                lblerrmsg.Text = "You are not belonging to this branch, can't add data."
                lblmsg.Text = ""
            End If
        Catch ex As Exception
            lblerrmsg.Text = "Please Enter Correct Data"
        End Try
    End Sub
    Protected Sub btnviews_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnviews.Click
        lblmsg.Text = ""
        lblerrmsg.Text = ""
        If btnviews.Text = "BACK" Then
            btnviews.Text = "VIEW"
            btnAdds.Text = "ADD"
            GridView1.PageIndex = ViewState("PageIndex")
            GridView1.Visible = False
            GridView1.Enabled = False
            'Display()
            Clear()
            
        Else
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            Display()

        End If
    End Sub
    Sub Display()
        'Clear()
        lblerrmsg.Text = ""
        lblmsg.Text = ""
        If txtLotNumber.Text = "" Then
            EL.Lot_Number = "0"
        Else
            EL.Lot_Number = txtLotNumber.Text
        End If
        If ddlProject.SelectedValue = 0 Then
            EL.Properties = "0"
        Else
            EL.Properties = ddlProject.SelectedValue
        End If

        Dim dt As New DataTable
        dt = BL.GetRecord(EL)
        If dt.Rows.Count > 0 Then
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataSource = dt
            GridView1.DataBind()

        ElseIf dt.Rows.Count <= 0 Then

            lblerrmsg.Text = "No Records To Dispaly."
            GridView1.Visible = False
            GridView1.Enabled = False
            Clear()

        End If
        
    End Sub
    Sub Clear()
        txtAveragePrice.Text = ""
        txtLocation.Text = ""
        txtLotNumber.Text = ""
        txtNoOfUnits.Text = ""
        txtSaleDate.Text = ""
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Display()
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        lblerrmsg.Text = ""
        lblmsg.Text = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim dt As New DataTable
            EL.ID = CType(GridView1.Rows(e.RowIndex).FindControl("lbl1"), Label).Text
            EL.Lot_Number = txtLotNumber.Text
            EL.Properties = ddlLot.SelectedValue
            BL.Delete(EL)
            dt = BL.GetRecord(EL)
            GridView1.Visible = False
            GridView1.Enabled = False

            GridView1.PageIndex = ViewState("PageIndex")
            'Display()
            lblmsg.Text = "Data Deleted Successfully"
            lblerrmsg.Text = ""

        Else
            lblmsg.Text = "You are not belonging to this branch, can't delete data."
            lblmsg.Text = " "

        End If
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblerrmsg.Text = ""
        lblmsg.Text = ""
        btnAdds.CommandName = "Update"
        btnviews.CommandName = "Back"
        btnAdds.Visible = True
        btnviews.Visible = True
        txtAveragePrice.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl7"), Label).Text
        'txtLocation.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl3"), Label).Text
        txtLotNumber.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl2"), Label).Text
        txtNoOfUnits.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl5"), Label).Text
        txtSaleDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl3"), Label).Text
        ddlLot.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl6"), Label).Text
        ddlProject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl4"), Label).Text
        txtLocation.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl8"), Label).Text
        ViewState("ID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl1"), Label).Text
        Dim dt1 As New DataTable
        EL.ID = ViewState("ID")
        EL.Lot_Number = txtLotNumber.Text
        EL.Properties = ddlLot.SelectedItem.Value
        dt1 = BL.GetRecord(EL)


        GridView1.DataSource = dt1
        GridView1.DataBind()
        btnAdds.Text = "UPDATE"
        btnviews.Text = "BACK"
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        EL.Lot_Number = 0
        EL.Properties = ddlProject.SelectedValue
        dt1.Clear()
        dt1 = BL.GetRecord(EL)
        Dim sortedView As New DataView(dt1)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
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

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'txtSaleDate.Text = Format(Today, "dd-MMM-yyyy")
    End Sub
End Class
