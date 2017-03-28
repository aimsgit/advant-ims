
Partial Class VehicleMaintainence
    Inherits BasePage
    Dim CategoryManager As New CategoryManager
    Dim Category As New Category
    Dim dt As New DataTable
    Dim v As New VehicleMaintenanceB
    Dim vm As New VehicleMaintenanceEn
    Dim GlobalFunction As New GlobalFunction
    Dim prop As New VehicleMaintenanceEn
    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnsave.Click
        ''cmbVehicle.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnsave.Text = "ADD" Then
                Try
                    vm.ServiceDate = txtServiceDate.Text
                    vm.ServiceDetails = txtServiceDetail.Text
                    'vm.VehicleNo = 'cmbVehicle.SelectedValue
                    vm.Amount = txtAmount.Text
                    If txtNextServiceDate.Text = "" Then
                        vm.NextServiceDate = "1/1/1900"
                    Else
                        vm.NextServiceDate = txtNextServiceDate.Text
                    End If
                    vm.AssetId = ddlAssetName.SelectedValue
                    vm.AssetTypeId = ddlassetType.SelectedValue
                    'If CType(txtServiceDate.Text, Date) > CType(txtNextServiceDate.Text, Date) Then
                    '    lblmsg.Text = ""
                    '    msginfo.Text = "Next service date should be greater than service date"
                    '    Exit Sub
                    'End If
                    If txtNextServiceDate.Text <> "" Then
                        If vm.ServiceDate > vm.NextServiceDate Then
                            lblmsg.Text = ""
                            msginfo.Text = "Next service date should be greater than service date."
                            txtNextServiceDate.Focus()
                            Exit Sub
                        End If
                    End If
                    vm.Remarks = txtRemarks.Text
                    dt = v.vechileduplicate(vm)
                    v.InsertRecord(vm)
                    lblmsg.Text = "Data saved successfully."
                    msginfo.Text = ""
                    txtAmount.Text = ""
                    txtNextServiceDate.Text = ""
                    txtRemarks.Text = ""
                    txtServiceDate.Text = ""
                    txtServiceDetail.Text = ""
                    ''cmbVehicle.SelectedValue = 0
                    dt = v.DispGrid(vm)
                    GridView1.DataSource = dt
                    ViewState("PageIndex") = 0
                    GridView1.PageIndex = 0
                    GridView1.DataBind()
                    GridView1.Enabled = True
                Catch ex As Exception
                    msginfo.Text = "Enter correct data."
                    lblmsg.Text = ""
                End Try
            Else
                Try
                    vm.ServiceDate = txtServiceDate.Text
                    If txtNextServiceDate.Text = "" Then
                        vm.NextServiceDate = "1/1/1900"
                    Else
                        vm.NextServiceDate = txtNextServiceDate.Text
                    End If
                    vm.AssetId = ddlAssetName.SelectedValue
                    vm.AssetTypeId = ddlassetType.SelectedValue
                    If txtNextServiceDate.Text <> "" Then
                        If vm.ServiceDate > vm.NextServiceDate Then
                            lblmsg.Text = ""
                            msginfo.Text = "Next service date should be greater than service date."
                            txtNextServiceDate.Focus()
                            Exit Sub
                        End If
                    End If
                    'If CType(txtServiceDate.Text, Date) > CType(txtNextServiceDate.Text, Date) Then
                    '    lblmsg.Text = ""
                    '    msginfo.Text = "Start date should be greater than end date"
                    '    Exit Sub
                    'End If
                    'vm.VehicleNo = 'cmbVehicle.SelectedValue
                    vm.Amount = txtAmount.Text
                    vm.Remarks = txtRemarks.Text
                    vm.ServiceDetails = txtServiceDetail.Text
                    vm.VMID = ViewState("VMID")
                    v.UpdateVehicleDet1(vm)
                    lblmsg.Text = "Data updated successfully."
                    msginfo.Text = ""
                    'cmbVehicle.Focus()
                    msginfo.Text = ""
                    ''dt = v.DispGrid(vm)
                    ''GridView1.DataSource = dt
                    ''GridView1.DataBind()
                    ''GridView1.Enabled = True
                    GridView1.PageIndex = ViewState("PageIndex")
                    DisplayBack()
                    btnsave.Text = "ADD"
                    btnDetail.Text = "VIEW"
                    btnDetail.Enabled = True
                    'Clearing all the textboxes
                    txtAmount.Text = ""
                    txtNextServiceDate.Text = ""
                    txtRemarks.Text = ""
                    txtServiceDate.Text = ""
                    txtServiceDetail.Text = ""
                    'cmbVehicle.SelectedValue = 0
                    ''cmbVehicle.SelectedValue = ""
                Catch ex As Exception
                    msginfo.Text = "Enter correct data."
                    lblmsg.Text = ""
                End Try
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub btnDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetail.Click
        LinkButton1.Focus()
        Try
            If btnDetail.Text = "BACK" Then
                GridView1.PageIndex = ViewState("PageIndex")
                DisplayBack()
                Clear()
                btnDetail.Text = "VIEW"
                btnsave.Text = "ADD"
                Clear()
            ElseIf btnDetail.Text = "VIEW" Then
                lblmsg.Text = ""
                msginfo.Text = ""
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                Display()
                GridView1.Visible = True
            End If
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub
    Sub Display()
        vm.VMID = 0
        ''If 'cmbVehicle.SelectedValue = "" Then
        'vm.VehicleNo = 0
        'Else
        '    vm.VehicleNo = 'cmbVehicle.SelectedValue
        'End If
        vm.AssetId = ddlAssetName.SelectedValue
        vm.AssetTypeId = ddlassetType.SelectedValue
        If txtServiceDate.Text = "" Then
            vm.ServiceDate = "1/1/1900"
        Else
            vm.ServiceDate = txtServiceDate.Text
        End If
        dt = v.DispGrid(vm)
        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            msginfo.Text = "No records to display."
            'cmbVehicle.Focus()
            lblmsg.Text = ""
            msginfo.Visible = True
        Else
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            btnDetail.Text = "VIEW"
        End If
    End Sub
    Sub DisplayBack()
        vm.VMID = 0
        'If 'cmbVehicle.SelectedValue = "" Then
        '    vm.VehicleNo = 0
        'Else
        '    vm.VehicleNo = 0
        'End If
        If txtServiceDate.Text = "" Then
            vm.ServiceDate = "1/1/1900"
        Else
            vm.ServiceDate = "1/1/1900"
        End If
        dt = v.DispGrid(vm)
        If dt.Rows.Count = 0 Then
            GridView1.DataSource = Nothing
            GridView1.DataBind()
            msginfo.Text = "No records to display."
            'cmbVehicle.Focus()
            lblmsg.Text = ""
            msginfo.Visible = True
        Else
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            btnDetail.Text = "VIEW"
        End If
    End Sub
    Sub Clear()
        txtAmount.Text = ""
        txtNextServiceDate.Text = ""
        txtRemarks.Text = ""
        'txtServiceDate.Text = ""
        txtServiceDetail.Text = ""
        'cmbVehicle.SelectedValue = 0
        lblmsg.Text = ""
        msginfo.Text = ""
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblmsg.Text = ""
        msginfo.Text = ""
        'cmbVehicle.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("LblV"), Label).Text
        txtAmount.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl4"), Label).Text
        txtNextServiceDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl6"), Label).Text
        txtRemarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl7"), Label).Text
        txtServiceDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl5"), Label).Text
        txtServiceDetail.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbl3"), Label).Text
        ViewState("VMID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HFVMID"), HiddenField).Value
        vm.VMID = ViewState("VMID")
        DisplayEdit()
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub
    Sub DisplayEdit()
        vm.VehicleNo = 0
        vm.ServiceDate = "1/1/1900"
        vm.VMID = ViewState("VMID")
        dt = v.DispGrid(vm)
        btnsave.Text = "UPDATE"
        btnDetail.Text = "BACK"
        dt = v.DispGrid(vm)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Enabled = False
        GridView1.Visible = True
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        Dim dt As New DataTable
        If (Session("BranchCode") = Session("ParentBranch")) Then
            vm.VMID = CType(GridView1.Rows(e.RowIndex).FindControl("HFVMID"), HiddenField).Value
            v.DelVehicleMaintenance(vm)
            lblmsg.Text = "Data Deleted Successfully."
            msginfo.Text = ""
            'cmbVehicle.Focus()
            GridView1.PageIndex = ViewState("PageIndex")
            vm.VMID = 0
            'If 'cmbVehicle.SelectedValue = "" Then
            '    vm.VehicleNo = 0
            'Else
            '    vm.VehicleNo = 'cmbVehicle.SelectedValue
            'End If
            If txtServiceDate.Text = "" Then
                vm.ServiceDate = "1/1/1900"
            Else
                vm.ServiceDate = txtServiceDate.Text
            End If
            dt = v.DispGrid(vm)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            'btnDetail.Text = "VIEW"
            'Display()
            GridView1.Visible = True
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        Display()
        'Dim dt As New DataTable
        'vm.VMID = ViewState("VMID")
        'vm.ServiceDate = "1/1/1900"
        'dt = v.DispGrid(vm)
        'GridView1.DataSource = dt
        'GridView1.Visible = True

        'GridView1.DataBind()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            txtServiceDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
        'cmbVehicle.Focus()
    End Sub

    'Protected Sub 'cmbVehicle_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles 'cmbVehicle.TextChanged
    '    'cmbVehicle.Focus()
    'End Sub

    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        vm.VMID = 0
        'If 'cmbVehicle.SelectedValue = "" Then
        '    vm.VehicleNo = 0
        'Else
        '    vm.VehicleNo = 'cmbVehicle.SelectedValue
        'End If
        If txtServiceDate.Text = "" Then
            vm.ServiceDate = "1/1/1900"
        Else
            vm.ServiceDate = txtServiceDate.Text
        End If
        dt = v.DispGrid(vm)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Visible = True
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
End Class
