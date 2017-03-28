
Partial Class frmVehicleDetails
    Inherits BasePage
    Dim VDetails As New VehicleDetails
    Dim VehicleManager As New VehicleManager
    Dim sdt As New Table
    Dim dt As DataTable

    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        txtVRegNum.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If BtnSave.Text = "UPDATE" Then
                    If RBUsers.SelectedValue <> "Own" Then
                        If CType(txtSDate.Text, Date) > CType(txtEDate.Text, Date) Then
                            lblmsginfo.Text = ""
                            lblErrorMsg.Text = "Start date should not be greater than end date."
                            txtSDate.Focus()
                            Exit Sub
                        End If
                    End If
                    VDetails.VehicleID = TxtVID.Text
                    VDetails.VehicleRegistrationnNo = txtVRegNum.Text
                    VDetails.YearRegistrationnNo = CDate(txtYearRegis.Text)
                    VDetails.VehicleType = txtVType.Text
                    VDetails.VehicleMake = txtVMake.Text
                    VDetails.MakeYear = ddlYear.SelectedItem.Text
                    VDetails.Model = txtModel.Text
                    VDetails.EngineNumber = txtEngineNo.Text
                    VDetails.CharsyNo = txtCharsyNo.Text
                    VDetails.NoOfSeats = txtNoSeats.Text
                    VDetails.FuelType = txtFuelType.Text
                    VDetails.InsuranceCompanyname = txtInsuranceCompanyName.Text
                    VDetails.InsuranceContactNo = txtInsuranceContactNo.Text
                    VDetails.PolicyNo = txtPolicyNo.Text
                    'hhhggg
                    If txtInsuExpiry.Text <> "" Then
                        If CType(txtInsuExpiry.Text, Date) < CType(txtYearRegis.Text, Date) Then
                            lblmsginfo.Text = ""
                            lblErrorMsg.Text = "Insurance Expiry date should not be Less than Registration Date."
                        End If
                    Else

                    End If
                    If txtRenewal.Text <> "" Then
                        If CType(txtRenewal.Text, Date) < CType(txtYearRegis.Text, Date) Then
                            lblmsginfo.Text = ""
                            lblErrorMsg.Text = "Renewal of permit Date should not be Less than Registration Date."
                        End If
                    End If

                    If txtInsuExpiry.Text = "" Then
                        VDetails.InsuranceExpiry = "1/1/1900"
                    Else
                        VDetails.InsuranceExpiry = CDate(txtInsuExpiry.Text)
                    End If
                    If txtRenewal.Text = "" Then
                        VDetails.RenewalOfPermit = "1/1/1900"
                    Else
                        VDetails.RenewalOfPermit = CDate(txtRenewal.Text)
                    End If
                    If txtPrice.Text = "" Then
                        txtPrice.Text = 0
                    Else
                        VDetails.Price = txtPrice.Text
                    End If

                    If RBUsers.SelectedValue.ToString = "Own" Then
                        VDetails.OwnerShipStatus = "Own"
                    Else
                        VDetails.OwnerShipStatus = "Contract"
                    End If

                    VDetails.ContratorName = txtContractName.Text
                    VDetails.contactNumber = txtContactNo.Text
                    VDetails.Address = txtAddr.Text
                    If txtSDate.Text = "" Then
                        VDetails.StartDate = ("1/1/1900")
                    Else
                        VDetails.StartDate = CDate(txtSDate.Text)
                    End If
                    If txtEDate.Text = "" Then
                        VDetails.EndDate = ("1/1/1900")
                    Else
                        VDetails.EndDate = CDate(txtEDate.Text)
                    End If

                    dt = VehicleManager.DuplicateEntry(VDetails) 'Ka04 0234
                    If dt.Rows.Count > 0 Then

                        lblmsginfo.Text = ""
                        'clear()
                        lblErrorMsg.Text = "Data already exists."
                        txtVRegNum.Focus()
                    Else

                        VehicleManager.UpdateRecord(VDetails)
                        BtnSave.Text = "ADD"
                        BtnDetails.Text = "VIEW"
                        clear()
                        GridView1.PageIndex = ViewState("PageIndex")
                        DispGrid()
                        lblErrorMsg.Text = ""
                        lblmsginfo.Text = "Data Updated Successfully."
                        txtVRegNum.Focus()
                        Dim date1 As String
                        date1 = Session("CurrentYear")
                        Dim dt As DataTable
                        dt = QualificationDB.GetYear(date1)
                        Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
                        ddlYear.SelectedValue = value
                    End If

                Else
                    If RBUsers.SelectedValue <> "Own" Then
                        If CType(txtSDate.Text, Date) > CType(txtEDate.Text, Date) Then
                            lblmsginfo.Text = ""
                            lblErrorMsg.Text = "Start date should not be greater than end date."
                            txtSDate.Focus()
                            Exit Sub
                        End If
                    End If
                    VDetails.VehicleRegistrationnNo = txtVRegNum.Text
                    Dim dt As DataTable
                    dt = VehicleManager.DuplicateEntry(VDetails)
                    If dt.Rows.Count > 0 Then
                        DispGrid()
                        lblmsginfo.Text = ""
                        'clear()
                        lblErrorMsg.Text = "Data already exists."
                        txtVRegNum.Focus()
                    Else
                        VDetails.VehicleRegistrationnNo = txtVRegNum.Text
                        VDetails.YearRegistrationnNo = CDate(txtYearRegis.Text)
                        VDetails.VehicleType = txtVType.Text
                        VDetails.VehicleMake = txtVMake.Text
                        VDetails.MakeYear = ddlYear.SelectedItem.Text
                        VDetails.Model = txtModel.Text
                        VDetails.EngineNumber = txtEngineNo.Text
                        VDetails.CharsyNo = txtCharsyNo.Text
                        If txtNoSeats.Text = "" Then
                            txtNoSeats.Text = 0
                        Else
                            VDetails.NoOfSeats = txtNoSeats.Text
                        End If
                        VDetails.FuelType = txtFuelType.Text
                        VDetails.InsuranceCompanyname = txtInsuranceCompanyName.Text
                        VDetails.InsuranceContactNo = txtInsuranceContactNo.Text
                        VDetails.PolicyNo = txtPolicyNo.Text


                        If txtInsuExpiry.Text <> "" Then
                            If CType(txtInsuExpiry.Text, Date) < CType(txtYearRegis.Text, Date) Then
                                lblmsginfo.Text = ""
                                lblErrorMsg.Text = "Insurance Expiry date should not be Less than Registration Date."
                            End If
                        Else

                        End If
                        If txtRenewal.Text <> "" Then
                            If CType(txtRenewal.Text, Date) < CType(txtYearRegis.Text, Date) Then
                                lblmsginfo.Text = ""
                                lblErrorMsg.Text = "Renewal of permit Date should not be Less than Registration Date."
                            End If
                        End If



                        'If CType(txtInsuExpiry.Text, Date) < CType(txtYearRegis.Text, Date) Then
                        '    lblmsginfo.Text = ""
                        '    lblErrorMsg.Text = "Insurance Expiry date should not be Less than Registration Date."
                        'ElseIf CType(txtRenewal.Text, Date) < CType(txtYearRegis.Text, Date) Then
                        '    lblmsginfo.Text = ""
                        '    lblErrorMsg.Text = "Renewal of permit Date should not be Less than Registration Date."

                        'Else
                        If txtInsuExpiry.Text = "" Then
                            VDetails.InsuranceExpiry = "1/1/1900"
                        Else
                            VDetails.InsuranceExpiry = CDate(txtInsuExpiry.Text)
                        End If
                        If txtRenewal.Text = "" Then
                            VDetails.RenewalOfPermit = "1/1/1900"
                        Else
                            VDetails.RenewalOfPermit = CDate(txtRenewal.Text)
                        End If
                        If txtPrice.Text = "" Then
                            txtPrice.Text = 0
                        Else
                            VDetails.Price = txtPrice.Text
                        End If
                        If RBUsers.SelectedValue.ToString = "Own" Then
                            VDetails.OwnerShipStatus = "Own"
                        Else
                            VDetails.OwnerShipStatus = "Contract"

                        End If

                        VDetails.ContratorName = txtContractName.Text
                        VDetails.contactNumber = txtContactNo.Text
                        VDetails.Address = txtAddr.Text
                        If txtSDate.Text = "" Then
                            VDetails.StartDate = ("1/1/1900")
                        Else
                            VDetails.StartDate = CDate(txtSDate.Text)
                        End If
                        If txtEDate.Text = "" Then
                            VDetails.EndDate = ("1/1/1900")
                        Else
                            VDetails.EndDate = CDate(txtEDate.Text)
                        End If
                        VehicleManager.InsertRecord(VDetails)
                        BtnSave.Text = "ADD"
                        ViewState("PageIndex") = 0
                        GridView1.PageIndex = 0
                        DispGrid()
                        lblErrorMsg.Text = ""
                        lblmsginfo.Text = "Data Saved Successfully."
                        clear()
                        txtVRegNum.Focus()
                        Dim date1 As String
                        date1 = Session("CurrentYear")
                        Dim dt2 As DataTable
                        dt2 = QualificationDB.GetYear(date1)
                        Dim value As Integer = dt2.Rows(0).Item("LookUpAutoID")
                        ddlYear.SelectedValue = value
                    End If
                    'End If
                End If
            Catch ex As Exception
                lblErrorMsg.Text = "Enter correct data."
                lblmsginfo.Text = ""
        End Try
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsginfo.Text = ""
        End If


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtSDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
        txtVRegNum.Focus()
        If RBUsers.SelectedValue = "Own" Then
            lblContractorName.Visible = False
            txtContractName.Visible = False
            lblContactNo.Visible = False
            txtContactNo.Visible = False
            lblAddr.Visible = False
            txtAddr.Visible = False
            lblSDate.Visible = False
            txtSDate.Visible = False
            lblEDate.Visible = False
            txtEDate.Visible = False
            If Not Page.IsPostBack Then
                txtYearRegis.Text = Format(Today, "dd-MMM-yyyy")
            End If
        Else
            lblContractorName.Visible = True
            txtContractName.Visible = True
            txtContractName.Enabled = True
            lblContactNo.Visible = True
            txtContactNo.Visible = True
            txtContactNo.Enabled = True
            lblAddr.Visible = True
            txtAddr.Visible = True
            txtAddr.Enabled = True
            lblSDate.Visible = True
            txtSDate.Visible = True
            txtSDate.Enabled = True
            lblEDate.Visible = True
            txtEDate.Visible = True
            txtEDate.Enabled = True
        End If
    End Sub
    Sub DispGrid()
        Dim dt As New DataTable
        VDetails.OwnerShipStatus = RBUsers.SelectedValue
        VDetails.VehicleID = 0
        If txtVRegNum.Text = "" Then
            VDetails.VehicleRegistrationnNo = 0
        Else
            VDetails.VehicleRegistrationnNo = txtVRegNum.Text
        End If

        If txtVType.Text = "" Then
            VDetails.VehicleType = 0
        Else
            VDetails.VehicleType = txtVType.Text
        End If
        If txtVMake.Text = "" Then
            VDetails.VehicleMake = 0
        Else
            VDetails.VehicleMake = txtVMake.Text
        End If
        If txtFuelType.Text = "" Then
            VDetails.FuelType = 0
        Else
            VDetails.FuelType = txtFuelType.Text
        End If

        dt = VehicleManager.GetVehicle(VDetails)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            If RBUsers.SelectedItem.Value = "Own" Then
                GridView1.Columns(18).Visible = False
                GridView1.Columns(19).Visible = False
                GridView1.Columns(20).Visible = False
                GridView1.Columns(21).Visible = False
                GridView1.Columns(22).Visible = False
            Else
                GridView1.Columns(18).Visible = True
                GridView1.Columns(19).Visible = True
                GridView1.Columns(20).Visible = True
                GridView1.Columns(21).Visible = True
                GridView1.Columns(22).Visible = True
            End If
        Else
            lblmsginfo.Text = ""
            lblErrorMsg.Text = "No records to display."
            GridView1.Visible = False
            txtVRegNum.Focus()
        End If
    End Sub
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        LinkButton1.Focus()
        lblErrorMsg.Text = ""
        lblmsginfo.Text = ""
        If txtVRegNum.Text = "" Then
            VDetails.VehicleRegistrationnNo = 0
        Else
            VDetails.VehicleRegistrationnNo = txtVRegNum.Text
        End If

        If txtVType.Text = "" Then
            VDetails.VehicleType = 0
        Else
            VDetails.VehicleType = txtVType.Text
        End If
        If txtVMake.Text = "" Then
            VDetails.VehicleMake = 0
        Else
            VDetails.VehicleMake = txtVMake.Text
        End If
        If txtFuelType.Text = "" Then
            VDetails.FuelType = 0
        Else
            VDetails.FuelType = txtFuelType.Text
        End If
        VDetails.OwnerShipStatus = RBUsers.SelectedValue
        Dim date1 As String
        date1 = Session("CurrentYear")
        Dim dt As DataTable
        dt = QualificationDB.GetYear(date1)
        Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
        ddlYear.SelectedValue = value
        If BtnDetails.Text = "VIEW" Then
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DispGrid()
        ElseIf BtnDetails.Text = "BACK" Then
            BtnSave.Text = "ADD"
            BtnDetails.Text = "VIEW"
            GridView1.PageIndex = ViewState("PageIndex")
            Dissplay()
            clear()
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DispGrid()
    End Sub
    Sub Dissplay()
        Dim dt As New DataTable
        VDetails.OwnerShipStatus = RBUsers.SelectedValue
        VDetails.VehicleID = 0
        If txtVRegNum.Text <> "" Then
            VDetails.VehicleRegistrationnNo = 0
        End If

        If txtVType.Text <> "" Then
            VDetails.VehicleType = 0
        End If

        If txtVMake.Text <> "" Then
            VDetails.VehicleMake = 0
        End If

        If txtFuelType.Text <> "" Then
            VDetails.FuelType = 0
        End If

        dt = VehicleManager.GetVehicle(VDetails)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Enabled = True
            GridView1.Visible = True
            If RBUsers.SelectedItem.Value = "Own" Then
                GridView1.Columns(18).Visible = False
                GridView1.Columns(19).Visible = False
                GridView1.Columns(20).Visible = False
                GridView1.Columns(21).Visible = False
                GridView1.Columns(22).Visible = False
            Else
                GridView1.Columns(18).Visible = True
                GridView1.Columns(19).Visible = True
                GridView1.Columns(20).Visible = True
                GridView1.Columns(21).Visible = True
                GridView1.Columns(22).Visible = True
            End If
        Else
            lblmsginfo.Text = ""
            lblErrorMsg.Text = "No records to display."
            GridView1.Visible = False
            txtVRegNum.Focus()
        End If
    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        lblErrorMsg.Text = ""
        lblmsginfo.Text = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            VDetails.VehicleID = CType(GridView1.Rows(e.RowIndex).Cells(0).FindControl("Label1"), Label).Text
            VDetails.OwnerShipStatus = RBUsers.SelectedValue
            VehicleManager.ChangeFlag(VDetails)
            lblErrorMsg.Text = ""
            lblmsginfo.Text = "Data Deleted Successfully."
            txtVRegNum.Focus()
            GridView1.PageIndex = ViewState("PageIndex")
            'DispGrid()
            Dim dt As New DataTable
            VDetails.OwnerShipStatus = RBUsers.SelectedValue
            VDetails.VehicleID = 0
            If txtVRegNum.Text = "" Then
                VDetails.VehicleRegistrationnNo = 0
            Else
                VDetails.VehicleRegistrationnNo = txtVRegNum.Text
            End If

            If txtVType.Text = "" Then
                VDetails.VehicleType = 0
            Else
                VDetails.VehicleType = txtVType.Text
            End If
            If txtVMake.Text = "" Then
                VDetails.VehicleMake = 0
            Else
                VDetails.VehicleMake = txtVMake.Text
            End If
            If txtFuelType.Text = "" Then
                VDetails.FuelType = 0
            Else
                VDetails.FuelType = txtFuelType.Text
            End If

            dt = VehicleManager.GetVehicle(VDetails)
            If dt.Rows.Count > 0 Then
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Enabled = True
                GridView1.Visible = True
                If RBUsers.SelectedItem.Value = "Own" Then
                    GridView1.Columns(18).Visible = False
                    GridView1.Columns(19).Visible = False
                    GridView1.Columns(20).Visible = False
                    GridView1.Columns(21).Visible = False
                    GridView1.Columns(22).Visible = False
                Else
                    GridView1.Columns(18).Visible = True
                    GridView1.Columns(19).Visible = True
                    GridView1.Columns(20).Visible = True
                    GridView1.Columns(21).Visible = True
                    GridView1.Columns(22).Visible = True
                End If
            Else
                lblmsginfo.Text = "Data Deleted Successfully."
                GridView1.Visible = False
                txtVRegNum.Focus()
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblmsginfo.Text = ""
        End If
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        lblErrorMsg.Text = ""
        lblmsginfo.Text = ""
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        TxtVID.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        txtVRegNum.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        txtYearRegis.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("LabeL3"), Label).Text
        txtVType.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        txtVMake.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text

        Dim date1 As String
        date1 = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label6"), Label).Text
        Dim dt As DataTable
        dt = QualificationDB.GetYear(date1)
        Dim value As Integer = dt.Rows(0).Item("LookUpAutoID")
        ddlYear.SelectedValue = value

        'ddlYear.SelectedItem.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label6"), Label).Text
        txtModel.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label7"), Label).Text
        txtEngineNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labe18"), Label).Text
        txtCharsyNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label9"), Label).Text
        txtNoSeats.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label10"), Label).Text
        txtFuelType.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labe111"), Label).Text
        txtInsuranceCompanyName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label12"), Label).Text
        txtInsuranceContactNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label13"), Label).Text
        txtPolicyNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label14"), Label).Text
        txtInsuExpiry.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label15"), Label).Text
        txtRenewal.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labe1l6"), Label).Text
        txtPrice.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labe1l7"), Label).Text
        VDetails.VehicleRegistrationnNo = txtVRegNum.Text
        VDetails.VehicleType = txtVType.Text
        VDetails.VehicleMake = txtVMake.Text
        VDetails.FuelType = txtFuelType.Text

        If RBUsers.SelectedValue = "Own" Then
            lblContractorName.Visible = False
            txtContractName.Visible = False
            lblContactNo.Visible = False
            txtContactNo.Visible = False
            lblAddr.Visible = False
            txtAddr.Visible = False
            lblSDate.Visible = False
            txtSDate.Visible = False
            lblEDate.Visible = False
            txtEDate.Visible = False
        Else
            lblContractorName.Visible = True
            txtContractName.Visible = True
            lblContactNo.Visible = True
            txtContactNo.Visible = True
            lblAddr.Visible = True
            txtAddr.Visible = True
            lblSDate.Visible = True
            txtSDate.Visible = True
            lblEDate.Visible = True
            txtEDate.Visible = True
            txtContractName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label18"), Label).Text
            txtContactNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label19"), Label).Text
            txtAddr.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labe120"), Label).Text
            txtSDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labe121"), Label).Text
            txtEDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Labe122"), Label).Text
        End If
        BtnSave.Text = "UPDATE"
        BtnDetails.Text = "BACK"
        Dim dt1 As DataTable
        VDetails.VehicleID = TxtVID.Text
        VDetails.OwnerShipStatus = RBUsers.SelectedValue
        dt1 = VehicleManager.GetVehicle(VDetails)
        GridView1.DataSource = dt1
        GridView1.DataBind()
        GridView1.Enabled = False
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsginfo.Text = ""
        'End If
    End Sub

    Sub clear()
        txtVRegNum.Text = ""
        'txtYearRegis.Text = ""
        txtVType.Text = ""
        txtVMake.Text = ""
        'txtYearRelease.Text = ""
        txtModel.Text = ""
        txtEngineNo.Text = ""
        txtCharsyNo.Text = ""
        txtNoSeats.Text = ""
        txtFuelType.Text = ""
        txtInsuranceCompanyName.Text = ""
        txtInsuranceContactNo.Text = ""
        txtPolicyNo.Text = ""
        txtInsuExpiry.Text = ""
        txtRenewal.Text = ""
        txtPrice.Text = ""
        txtContractName.Text = ""
        txtContactNo.Text = ""
        txtAddr.Text = ""
        'txtSDate.Text = ""
        txtEDate.Text = ""
    End Sub
    Sub Enable()
        GridView1.Enabled = True
        BtnDetails.Visible = True
    End Sub
    Sub Disable()
        GridView1.Enabled = False
        BtnDetails.Visible = False
    End Sub

    Protected Sub RBUsers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBUsers.SelectedIndexChanged
        lblmsginfo.Text = ""
        lblErrorMsg.Text = ""
        GridView1.Visible = False
        If RBUsers.SelectedValue = "Own" Then
            lblContractorName.Visible = False
            txtContractName.Visible = False
            lblContactNo.Visible = False
            txtContactNo.Visible = False
            lblAddr.Visible = False
            txtAddr.Visible = False
            lblSDate.Visible = False
            txtSDate.Visible = False
            lblEDate.Visible = False
            txtEDate.Visible = False
        Else
            txtContractName.Focus()
            lblContractorName.Visible = True
            txtContractName.Visible = True
            txtContractName.Enabled = True
            lblContactNo.Visible = True
            txtContactNo.Visible = True
            txtContactNo.Enabled = True
            lblAddr.Visible = True
            txtAddr.Visible = True
            txtAddr.Enabled = True
            lblSDate.Visible = True
            txtSDate.Visible = True
            txtSDate.Enabled = True
            lblEDate.Visible = True
            txtEDate.Visible = True
            txtEDate.Enabled = True
        End If
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
        Dim dt As New DataTable
        VDetails.OwnerShipStatus = RBUsers.SelectedValue
        VDetails.VehicleID = 0
        If txtVRegNum.Text = "" Then
            VDetails.VehicleRegistrationnNo = 0
        Else
            VDetails.VehicleRegistrationnNo = txtVRegNum.Text
        End If

        If txtVType.Text = "" Then
            VDetails.VehicleType = 0
        Else
            VDetails.VehicleType = txtVType.Text
        End If
        If txtVMake.Text = "" Then
            VDetails.VehicleMake = 0
        Else
            VDetails.VehicleMake = txtVMake.Text
        End If
        If txtFuelType.Text = "" Then
            VDetails.FuelType = 0
        Else
            VDetails.FuelType = txtFuelType.Text
        End If

        dt = VehicleManager.GetVehicle(VDetails)
        

        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Enabled = True
        GridView1.Visible = True
        LinkButton1.Focus()
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
