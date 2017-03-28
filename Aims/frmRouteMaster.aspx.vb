
Partial Class frmRouteMaster
    Inherits BasePage
    Dim RouteM As New RouteMaster
    Dim RouteManage As New RouteManager
    Dim sdt As New Table
    Dim GlobalFunction As New GlobalFunction


    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        RouteNumber.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim dt As DataTable
            If BtnSave.Text = "ADD" Then
                RouteM.RouteNumber = RouteNumber.Text
                RouteM.RouteName = RouteName.Text
                Try
                    If ArrivalTime.Text <> "" Then
                        RouteM.ArrivalTime = CDate(CDate("1/1/2000 ") + " " + FormatDateTime(CDate(ArrivalTime.Text), DateFormat.ShortTime))
                    Else
                        RouteM.ArrivalTime = CDate("1/1/1900")
                    End If
                    If DepartureTime.Text <> "" Then
                        RouteM.DepartureTime = CDate(CDate("1/1/2000 ") + " " + FormatDateTime(CDate(DepartureTime.Text), DateFormat.ShortTime))
                    Else
                        RouteM.DepartureTime = CDate("1/1/1900")
                    End If
                    If RouteM.ArrivalTime < RouteM.DepartureTime Then
                        msginfo.Text = ""
                        lblErrorMsg.Text = "Arrival Time cannot be Lesser than Departure time."
                        ArrivalTime.Focus()
                    Else
                        RouteM.VehicleID = ddlVehicleNo.SelectedValue
                        RouteM.DriverID = ddlDriverName.SelectedValue
                        RouteM.PickUpPoints = PickUpPoint.Text
                        RouteM.Remarks = Remarks.Text
                        'RouteM.RouteID = ViewState("RouteID")
                        dt = RouteManage.CheckDuplicate(RouteM)
                        If dt.Rows.Count > 0 Then
                            lblErrorMsg.Text = "Data already Exists."
                            msginfo.Text = ""
                        Else
                            RouteManage.InsertRecord(RouteM)
                            lblErrorMsg.Text = ""
                            msginfo.Text = "Data saved successfully."
                            'dt = RouteManage.GetRouteDetails(RouteM)
                            'GridView1.DataSource = dt
                            'GridView1.Visible = True
                            'GridView1.Enabled = True
                            'GridView1.DataBind()
                            disp()
                            Clear()
                        End If
                    End If
                Catch ex As Exception
                    lblErrorMsg.Text = "Time not in correct format."
                End Try

            ElseIf BtnSave.Text = "UPDATE" Then
                RouteM.RouteID = ViewState("RouteID")
                RouteM.RouteNumber = RouteNumber.Text
                RouteM.RouteName = RouteName.Text
                Try
                    If ArrivalTime.Text <> "" Then
                        RouteM.ArrivalTime = CDate(CDate("1/1/2000 ") + " " + FormatDateTime(CDate(ArrivalTime.Text), DateFormat.ShortTime))
                    Else
                        RouteM.ArrivalTime = CDate("1/1/1900")
                    End If
                    If DepartureTime.Text <> "" Then
                        RouteM.DepartureTime = CDate(CDate("1/1/2000 ") + " " + FormatDateTime(CDate(DepartureTime.Text), DateFormat.ShortTime))
                    Else
                        RouteM.DepartureTime = CDate("1/1/1900")
                    End If
                    If RouteM.ArrivalTime < RouteM.DepartureTime Then
                        msginfo.Text = ""
                        lblErrorMsg.Text = "Arrival Time cannot be Lesser than Departure time."
                        ArrivalTime.Focus()
                    Else

                        'RouteM.InstituteID = Session("InstituteID")
                        'RouteM.Branch = Session("BranchID")
                        RouteM.VehicleID = ddlVehicleNo.SelectedValue
                        RouteM.DriverID = ddlDriverName.SelectedValue
                        RouteM.PickUpPoints = PickUpPoint.Text
                        RouteM.Remarks = Remarks.Text
                        RouteM.RouteID = ViewState("RouteID")
                        dt = RouteManage.CheckDuplicate(RouteM)
                        If dt.Rows.Count > 0 Then
                            lblErrorMsg.Text = "Data already Exist."
                            msginfo.Text = ""
                        Else
                            BtnSave.Text = "ADD"
                            RouteManage.UpdateRecord(RouteM)

                            Enable()
                            DispGrid()
                            BtnDetails.Text = "VIEW"
                            lblErrorMsg.Text = ""
                            msginfo.Text = "Data Updated Successfully."
                            Clear()
                            dt = RouteManage.GetRouteDetails(RouteM)
                            GridView1.DataSource = dt
                            GridView1.Visible = True
                            GridView1.Enabled = True
                            GridView1.DataBind()
                            disp()
                        End If
                    End If
                Catch ex As Exception
                    msginfo.Text = ""
                    lblErrorMsg.Text = "Time is not valid."
                End Try
            End If
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
            msginfo.Text = ""
        End If

    End Sub

    Sub Clear()
        RouteNumber.Text = ""
        RouteName.Text = ""
        ArrivalTime.Text = ""
        DepartureTime.Text = ""
        PickUpPoint.Text = ""
        Remarks.Text = ""
    End Sub
    Sub Enable()
        GridView1.Enabled = True
        BtnDetails.Visible = True
    End Sub
    Sub Disable()
        GridView1.Enabled = False
        BtnDetails.Visible = False
    End Sub

    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        LinkButton1.Focus()
        Dim dt As New DataTable
        If BtnDetails.Text <> "BACK" Then
            lblErrorMsg.Text = ""
            msginfo.Text = ""
            RouteM.RouteID = 0

            If RouteNumber.Text = "" Then
                RouteM.RouteNumber = 0
            Else
                RouteM.RouteNumber = RouteNumber.Text
            End If

            If ddlVehicleNo.SelectedValue = "" Then
                RouteM.VehicleID = 0
            Else
                RouteM.VehicleID = ddlVehicleNo.SelectedItem.Value()
            End If

            If ddlDriverName.SelectedValue = "" Then
                RouteM.DriverID = 0
            Else
                RouteM.DriverID = ddlDriverName.SelectedItem.Value()
            End If

            If PickUpPoint.Text = "" Then
                RouteM.PickUpPoints = 0
            Else
                RouteM.PickUpPoints = PickUpPoint.Text
            End If
            dt = RouteManage.GetRouteDetails(RouteM)

            GridView1.DataSource = dt
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataBind()
            If dt.Rows.Count = 0 Then
                msginfo.Text = ""
                lblErrorMsg.Text = "No Records to display."
                RouteNumber.Focus()
                GridView1.Visible = False
            End If
            Clear()
        Else
            lblErrorMsg.Text = ""
            msginfo.Text = ""
            BtnDetails.Text = "VIEW"
            BtnSave.Text = "ADD"
            Dispplay()
            Clear()
        End If
    End Sub
    Sub disp()
        Dim dt As New DataTable
        RouteM.RouteID = 0
        RouteM.RouteNumber = 0
        RouteM.VehicleID = 0
        RouteM.DriverID = 0
        RouteM.PickUpPoints = 0
        dt = RouteManage.GetRouteDetails(RouteM)
        GridView1.DataSource = dt
        GridView1.Visible = True
        GridView1.DataBind()

    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            RouteManage.ChangeFlag(CType(GridView1.Rows(e.RowIndex).FindControl("Label1"), Label).Text())
            GridView1.DataBind()
            lblErrorMsg.Text = ""
            msginfo.Text = "Data Deleted Successfully."
            Dim dt As New DataTable
            Dim routeid As Integer
            routeid = Session("RouteID")
            lblErrorMsg.Text = ""


            If RouteNumber.Text = "" Then
                RouteM.RouteNumber = 0
            Else
                RouteM.RouteNumber = RouteNumber.Text
            End If

            If ddlVehicleNo.SelectedValue = "" Then
                RouteM.VehicleID = 0
            Else
                RouteM.VehicleID = ddlVehicleNo.SelectedItem.Value()
            End If

            If ddlDriverName.SelectedValue = "" Then
                RouteM.DriverID = 0
            Else
                RouteM.DriverID = ddlDriverName.SelectedItem.Value()
            End If

            If PickUpPoint.Text = "" Then
                RouteM.PickUpPoints = 0
            Else
                RouteM.PickUpPoints = PickUpPoint.Text
            End If

            dt = RouteManage.GetRouteDetails(RouteM)

            GridView1.DataSource = dt
            GridView1.Visible = True
            GridView1.DataBind()
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            msginfo.Text = ""
        End If

    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblErrorMsg.Text = ""
        msginfo.Text = ""
        BtnSave.Text = "UPDATE"
        'BtnReport.Visible = True
        ViewState("RouteID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        RouteM.RouteID = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        RouteNumber.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        RouteName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        ArrivalTime.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        DepartureTime.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        ddlVehicleNo.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label10"), Label).Text
        ddlDriverName.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label11"), Label).Text
        PickUpPoint.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label8"), Label).Text
        Remarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label9"), Label).Text
        e.Cancel = True
        Disable()
        RouteM.RouteNumber = RouteNumber.Text
        RouteM.VehicleID = ddlVehicleNo.SelectedValue
        RouteM.DriverID = ddlDriverName.SelectedValue
        RouteM.PickUpPoints = PickUpPoint.Text
        ViewState("RouteID") = RouteM.RouteID
        BtnDetails.Text = "BACK"
        Dim d1 As New RouteManager
        Dim dt As New DataTable

        dt = d1.GetRouteDetails(RouteM)
        GridView1.DataSource = dt
        GridView1.DataBind()
        BtnDetails.Visible = True
        'BtnReport.Visible = False
        GridView1.Enabled = False
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'msginfo.Text = ""
        'End If
    End Sub

    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        Dim dt As New DataTable
        dt = RouteManage.GetRouteDetails(RouteM)
        GridView1.DataSource = dt
        GridView1.Visible = True
        GridView1.DataBind()
    End Sub
    Sub DispGrid()
        Dim dt As New DataTable
        Dim routeid As Integer
        routeid = Session("RouteID")
        lblErrorMsg.Text = ""


        If RouteNumber.Text = "" Then
            RouteM.RouteNumber = 0
        Else
            RouteM.RouteNumber = RouteNumber.Text
        End If

        If ddlVehicleNo.SelectedValue = "" Then
            RouteM.VehicleID = 0
        Else
            RouteM.VehicleID = ddlVehicleNo.SelectedItem.Value()
        End If

        If ddlDriverName.SelectedValue = "" Then
            RouteM.DriverID = 0
        Else
            RouteM.DriverID = ddlDriverName.SelectedItem.Value()
        End If

        If PickUpPoint.Text = "" Then
            RouteM.PickUpPoints = 0
        Else
            RouteM.PickUpPoints = PickUpPoint.Text
        End If

        dt = RouteManage.GetRouteDetails(RouteM)

        GridView1.DataSource = dt
        GridView1.Visible = True
        GridView1.DataBind()
        If dt.Rows.Count = 0 Then
            msginfo.Text = ""
            lblErrorMsg.Text = "No records to display."
            RouteNumber.Focus()
            GridView1.Visible = False
        End If
    End Sub
    Sub Dispplay()
        Dim dt As New DataTable
        lblErrorMsg.Text = ""
        msginfo.Text = ""
        RouteM.RouteID = 0
        If RouteNumber.Text <> "" Then
            RouteM.RouteNumber = 0
        End If
        If ddlVehicleNo.SelectedValue <> "" Then
            RouteM.VehicleID = 0
        End If
        If ddlDriverName.SelectedValue <> "" Then
            RouteM.DriverID = 0
        End If
        If PickUpPoint.Text <> "" Then
            RouteM.PickUpPoints = 0
        End If
        dt = RouteManage.GetRouteDetails(RouteM)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.Visible = True
            GridView1.Enabled = True
            GridView1.DataBind()
        Else
            msginfo.Text = ""
            lblErrorMsg.Text = "No records to display."
            RouteNumber.Focus()
            GridView1.Visible = False
        End If
    End Sub
    Protected Sub ddlVehicleNo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlVehicleNo.TextChanged
        ddlVehicleNo.Focus()
        lblErrorMsg.Text = ""
        msginfo.Text = ""
    End Sub

    Protected Sub ddlDriverName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDriverName.TextChanged
        ddlDriverName.Focus()
        lblErrorMsg.Text = ""
        msginfo.Text = ""
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RouteNumber.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
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
        Dim routeid As Integer
        routeid = Session("RouteID")
        lblErrorMsg.Text = ""


        If RouteNumber.Text = "" Then
            RouteM.RouteNumber = 0
        Else
            RouteM.RouteNumber = RouteNumber.Text
        End If

        If ddlVehicleNo.SelectedValue = "" Then
            RouteM.VehicleID = 0
        Else
            RouteM.VehicleID = ddlVehicleNo.SelectedItem.Value()
        End If

        If ddlDriverName.SelectedValue = "" Then
            RouteM.DriverID = 0
        Else
            RouteM.DriverID = ddlDriverName.SelectedItem.Value()
        End If

        If PickUpPoint.Text = "" Then
            RouteM.PickUpPoints = 0
        Else
            RouteM.PickUpPoints = PickUpPoint.Text
        End If

        dt = RouteManage.GetRouteDetails(RouteM)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
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
