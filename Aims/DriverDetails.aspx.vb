
Partial Class DriverDetails
    Inherits BasePage
    Dim d As New DriverDet
    Dim dd As New DriverDetB
    Dim dt As DataTable

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        lblmsg.Text = ""
        msginfo.Text = ""
        If Not Page.IsPostBack Then
            txtDOJ.Text = Format(Today, "dd-MMM-yyyy")
        End If
        txtDriverName.Focus()
    End Sub

    Protected Sub btn_save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_save.Click
        txtDriverName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btn_save.Text = "ADD" Then
                Try

                    'If txtContactNo.Text = "" Then
                    '    msginfo.Text = "Contact No. is Mandatory."
                    '    lblmsg.Text = ""
                    '    txtContactNo.Focus()
                    'Else
                    d.ContactNo = txtContactNo.Text
                    d.DLNO = txtDrivingLicenseNo.Text

                    lblmsg.Text = ""
                    If dd.GetDuplicateDriverDetails(d).Rows.Count > 0 Then
                        msginfo.Text = "Data already exists."
                        lblmsg.Text = ""
                        'clear()
                    Else
                        d.DriverName = txtDriverName.Text
                        d.Address = txtAddress.Text
                        d.ContactNo = txtContactNo.Text
                        If txtDOB.Text = "" Then
                            d.DOB = "01/01/1900"
                        Else
                            d.DOB = txtDOB.Text
                        End If

                        If txtDOJ.Text = "" Then
                            d.DOJ = "01/01/1900"
                        Else
                            d.DOJ = txtDOJ.Text
                        End If
                        d.DLExpiry = txtDLExpiryDate.Text
                        If d.DOB > d.DOJ Then
                            msginfo.Text = "Date Of Birth cannot be greater than Date Of Joining."
                            txtDOB.Focus()
                        ElseIf d.DLExpiry <= d.DOB Then
                            msginfo.Text = "Driving license Expiry date cannot be less than Date Of Birth."

                        Else
                            d.DLNO = txtDrivingLicenseNo.Text
                            d.BloodGroup = cmbBloodGroup.SelectedItem.Text

                            d.RTOName = txtrtoname.Text
                            d.City = txtcity.Text
                            d.State = ddlstate.SelectedValue
                            dd.InsertRecord(d)
                            lblmsg.Text = "Data Saved Successfully."
                            msginfo.Text = ""
                            GridView1.Visible = False
                            GridView1.Enabled = True
                            ViewState("PageIndex") = 0
                            GridView1.PageIndex = 0
                            DisplayGridView()
                            clear()

                        End If
                    End If
                    'End If
                Catch ex As Exception
                    msginfo.Text = "Enter correct date."
                End Try
            ElseIf btn_save.Text = "UPDATE" Then
                Try

                    'If txtContactNo.Text = "" Then
                    '    msginfo.Text = "Contact No. is Mandatory."
                    '    lblmsg.Text = ""
                    '    txtContactNo.Focus()
                    'Else
                    d.DriverName = txtDriverName.Text
                    d.Address = txtAddress.Text
                    d.ContactNo = txtContactNo.Text
                    If txtDOB.Text = "" Then
                        d.DOB = "01/01/1900"
                    Else
                        d.DOB = txtDOB.Text
                    End If

                    If txtDOJ.Text = "" Then
                        d.DOJ = "01/01/1900"
                    Else
                        d.DOJ = txtDOJ.Text
                    End If
                    d.DLExpiry = txtDLExpiryDate.Text
                    If d.DOB > d.DOJ Then
                        msginfo.Text = "Date Of Birth cannot be greater than Date Of Joining."
                        txtDOB.Focus()
                    ElseIf d.DLExpiry <= d.DOB Then
                        msginfo.Text = "Driving license Expiry date cannot be less than Date Of Birth."
                    Else
                        d.DLNO = txtDrivingLicenseNo.Text
                        d.BloodGroup = cmbBloodGroup.SelectedItem.Text

                        d.RTOName = txtrtoname.Text
                        d.City = txtcity.Text
                        d.State = ddlstate.SelectedValue
                        d.driverid = ViewState("DriverID")
                        dt = dd.GetDuplicateDriverDetails(d)
                        If dt.Rows.Count > 0 Then
                            msginfo.Text = "Data Already Exists."
                        Else
                            dd.UpdateDriverDetails(d)
                            DisplayGridView()

                            GridView1.Visible = True
                            GridView1.Enabled = True

                            lblmsg.Text = "Data Updated Successfully."
                            btn_save.Text = "ADD"
                            btn_details.Text = "VIEW"
                            GridView1.PageIndex = ViewState("PageIndex")
                            DisplayGridView()
                        End If
                    End If
                    'End If
                Catch ex As InvalidCastException
                    msginfo.Text = "Enter correct date."
                End Try
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If

    End Sub
    Sub DisplayGridView()
        Dim dt As New DataTable
        d.driverid = 0
        If txtDriverName.Text = "" Then
            d.DriverName = 0
        Else
            d.DriverName = txtDriverName.Text
        End If

        If txtDrivingLicenseNo.Text = "" Then
            d.DLNO = 0
        Else
            d.DLNO = txtDrivingLicenseNo.Text
        End If
        dt = dd.DispDriverDetails(d)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
            msginfo.Text = ""
        Else
            msginfo.Text = "No records to display."
            txtDriverName.Focus()
            GridView1.Visible = False
            lblmsg.Text = ""
        End If
        clear()
        ddlstate.Text = 0
    End Sub
    Sub clear()
        txtDriverName.Text = ""
        txtAddress.Text = ""
        txtContactNo.Text = ""
        txtDOB.Text = ""
        'txtDOJ.Text = ""
        cmbBloodGroup.SelectedValue = 0
        txtDrivingLicenseNo.Text = ""
        txtDLExpiryDate.Text = ""
        txtrtoname.Text = ""
        txtcity.Text = ""
        ddlstate.SelectedValue = 0
    End Sub
    Protected Sub btn_details_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_details.Click
        LinkButton1.Focus()
        If btn_details.Text = "VIEW" Then
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            DisplayGridView()
            lblmsg.Text = ""
            'msginfo.Text = ""
        ElseIf btn_details.Text = "BACK" Then
            btn_save.Text = "ADD"
            btn_details.Text = "VIEW"
            clear()
            GridView1.PageIndex = ViewState("PageIndex")
            DispGrid()
            GridView1.Enabled = True
            GridView1.Visible = True
        End If
    End Sub
    Sub DispGrid()
        Dim dt As New DataTable
        d.driverid = 0
        If txtDriverName.Text = "" Then
            d.DriverName = 0
        End If

        If txtDrivingLicenseNo.Text = "" Then
            d.DLNO = 0
        End If

        dt = dd.DispDriverDetails(d)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
            msginfo.Text = ""
        Else
            msginfo.Text = "No records to display."
            txtDriverName.Focus()
            GridView1.Visible = False
            lblmsg.Text = ""
        End If
        clear()
        ddlstate.Text = 0
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        DisplayGridView()
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        ViewState("DriverID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HdndrivId"), HiddenField).Value
        txtAddress.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAddress"), Label).Text
        cmbBloodGroup.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblBloodGroup"), Label).Text
        txtContactNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblContactNo"), Label).Text
        txtDLExpiryDate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDLExp"), Label).Text
        txtDOB.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDOB"), Label).Text
        txtDOJ.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDOJ"), Label).Text
        txtDriverName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDriverName"), Label).Text
        txtDrivingLicenseNo.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblDLNo"), Label).Text
        txtrtoname.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblRTOname"), Label).Text
        txtcity.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblcity"), Label).Text
        ddlstate.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("HidState"), HiddenField).Value
        d.DriverName = txtDriverName.Text
        d.DLNO = txtDrivingLicenseNo.Text
        Dim dt As New DataTable
        d.driverid = ViewState("DriverID")
        dt = dd.DispDriverDetails(d)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = False
        lblmsg.Text = ""
        msginfo.Text = ""
        btn_save.Text = "UPDATE"
        btn_details.Text = "BACK"

        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If

    End Sub

    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then

            d.driverid = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("HdndrivId"), HiddenField).Value
            dd.DelDriverDetails(d)
            lblmsg.Text = "Data Deleted Successfully."
            txtDriverName.Focus()
            GridView1.PageIndex = ViewState("PageIndex")
            Dim dt As New DataTable
            d.driverid = 0
            d.DriverName = 0
            d.DLNO = 0
            dt = dd.DispDriverDetails(d)
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = True
            msginfo.Text = ""
            'DisplayGridView()
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub

    'Protected Sub btn_report_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btn_report.Click
    '    Dim qrystring As String = "RptDriverDetails.aspx?" & QueryStr.Querystring()
    '    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    'End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlstate_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlstate.TextChanged
        ddlstate.Focus()
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
        d.driverid = 0
        If txtDriverName.Text = "" Then
            d.DriverName = 0
        End If

        If txtDrivingLicenseNo.Text = "" Then
            d.DLNO = 0
        End If

        dt = dd.DispDriverDetails(d)

        Dim sortedView As New DataView(dt)
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
End Class
