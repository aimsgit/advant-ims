
Partial Class FrmTransportRegistration
    Inherits BasePage
    Dim GlobalFunction As New GlobalFunction
    Dim TransportReg As New TransportReg
    Dim dt, dt1 As New DataTable
    Dim BLTransportRegB As New BLTransportReg
    Dim ELIssue As New BookIssue
    Dim m As New TransportReg
    Sub Splitter1(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("StdCode") = parts(0).ToString()
            txtStdCode.Text = parts(0).ToString()
            txtStdName.Text = parts(1).ToString()
            HidstdId.Value = parts(2).ToString()
            'ViewState("StdID") = StdID
        Else
            txtStdCode.AutoPostBack = True
        End If
    End Sub
    Sub Splitter2(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            txtEmpCode.Text = parts(0).ToString()
            txtEmpName.Text = parts(1).ToString()
            HidEmp.Value = parts(2).ToString()
            'ViewState("EmpID") = EmpID
        Else
            txtEmpCode.AutoPostBack = True
        End If
    End Sub
    Protected Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        'code for Insert And Update  By NITIN 17/05/2012
        RBUsers.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                msginfo.Text = ""
                lblmsg.Text = ""
                If RBUsers.SelectedValue = "Student" Then
                    ELIssue.StdCode = HidstdId.Value.Replace(",", "")
                    ELIssue.StdCode = ViewState("StdID")
                    ELIssue.StdName = txtStdName.Text
                    ELIssue.EmpCode = 0
                Else
                    ELIssue.EmpCode = HidEmp.Value.Replace(",", "")
                    ELIssue.EmpName = txtEmpName.Text
                    ELIssue.StdCode = 0
                End If
                If txtPickuptime.Text <> "" Then
                    TransportReg.PickUptime = CDate(CDate("1/1/2000 ") + " " + FormatDateTime(CDate(txtPickuptime.Text), DateFormat.ShortTime))
                Else
                    TransportReg.PickUptime = CDate("1/1/1900")
                End If
                TransportReg.TRNO = ViewState("TRNO")
                TransportReg.Acode = ddlacadyear.SelectedValue
                If RBUsers.SelectedValue = "Student" Then
                    TransportReg.Std_ID = HidstdId.Value
                Else
                    TransportReg.EmpId = HidEmp.Value
                End If
                TransportReg.RouteID = DdlRouteName.SelectedValue
                TransportReg.PickUpPoint = DdlPickupPoint.SelectedValue
                If TxtRegistration.Text = "" Then
                    TransportReg.RegistrationDate = "1/1/1900"
                Else
                    TransportReg.RegistrationDate = TxtRegistration.Text
                End If

                TransportReg.Remarks = txtRemarks.Text
                If BtnSave.Text = "ADD" Then
                    If RBUsers.SelectedValue = "Employee" Then
                        dt = BLTransportRegB.CheckDuplicateEmp(TransportReg)
                        If dt.Rows.Count > 0 Then
                            msginfo.Text = "Data already exists."
                            lblmsg.Text = " "
                        Else
                            If DdlRouteName.SelectedValue = 0 Then
                                msginfo.Text = "Route Name Field is Mandatory."
                                DdlRouteName.Focus()
                                lblmsg.Text = " "
                            Else
                                BLTransportRegB.InsertIntoReg(TransportReg)
                                msginfo.Text = ""
                                lblmsg.Text = "Data Saved Successfully."
                                ViewState("PageIndex") = 0
                                GVTransport.PageIndex = 0
                                DisplayGrid1()
                                Clear()
                                regdate()
                            End If
                        End If
                    Else
                        dt = BLTransportRegB.CheckDuplicate(TransportReg)
                        If dt.Rows.Count > 0 Then
                            msginfo.Text = "Data already exists."
                            lblmsg.Text = " "
                        Else
                            BLTransportRegB.InsertIntoReg(TransportReg)
                            lblmsg.Text = "Data Saved Successfully."
                            msginfo.Text = ""
                            'DisplayGrid()
                            ViewState("PageIndex") = 0
                            GVTransport.PageIndex = 0
                            DisplayGrid1()
                            Clear()
                            regdate()
                        End If
                    End If
                ElseIf BtnSave.Text = "UPDATE" Then
                    RBUsers.Enabled = True
                    If RBUsers.SelectedValue = "Employee" Then
                        If txtEmpCode.Text = "" Or txtEmpName.Text = "" Then
                            msginfo.Text = "Enter employee code."
                            lblmsg.Text = ""
                        Else
                            If DdlRouteName.SelectedValue = 0 Then
                                msginfo.Text = "Route Name Field is Mandatory."
                                DdlRouteName.Focus()
                                lblmsg.Text = ""
                            Else
                                BLTransportRegB.Update(TransportReg)
                                lblmsg.Text = "Data Updated Successfully."
                                msginfo.Text = ""
                                BtnSave.Text = "ADD"
                                BtnDetails.Text = "VIEW"
                                GVTransport.PageIndex = ViewState("PageIndex")
                                DisplayGrid1()
                                Clear()
                                regdate()
                            End If
                        End If
                    End If
                    If RBUsers.SelectedValue = "Student" Then
                        BLTransportRegB.Update(TransportReg)
                        lblmsg.Text = "Data Updated Successfully."
                        msginfo.Text = ""
                        BtnSave.Text = "ADD"
                        BtnDetails.Text = "VIEW"
                        GVTransport.PageIndex = ViewState("PageIndex")
                        DisplayGrid1()
                        Clear()
                        regdate()
                    End If
                End If
            Catch ex As Exception
                msginfo.Text = "Please enter the correct data."
                lblmsg.Text = ""
            End Try
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If

    End Sub
    'code for Row Index Changing for Grid Method By NITIN 18/05/2012
    Protected Sub GVTransport_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVTransport.PageIndexChanging
        GVTransport.PageIndex = e.NewPageIndex
        GVTransport.DataBind()
        ViewState("PageIndex") = GVTransport.PageIndex
        DisplayGrid()
        GVTransport.Visible = True
    End Sub
    Sub Clear()
        txtStdCode.Text = ""
        txtPickuptime.Text = ""
        txtRemarks.Text = ""
        txtStdName.Text = ""
        txtEmpCode.Text = ""
        txtEmpName.Text = ""
        ''TxtVehicleNumber.Text = ""
        ''TxtRouteNumber.Text = ""
    End Sub
    Sub Clear1()
        txtStdCode.Text = ""
        txtPickuptime.Text = ""
        txtRemarks.Text = ""
        txtStdName.Text = ""
        txtEmpCode.Text = ""
        txtEmpName.Text = ""
        ddlacadyear.ClearSelection()
        DdlRouteName.ClearSelection()
        DdlPickupPoint.Items.Clear()
        TxtRouteNumber.Text = ""
        TxtVehicleNumber.Text = ""
    End Sub
    Sub DisplayGrid()
        TransportReg.TRNO = 0
        If RBUsers.SelectedValue = "Student" Then
            TransportReg.RBUser = RBUsers.SelectedValue
            If ddlacadyear.SelectedValue = "" Then
                TransportReg.Acode = 0
            Else
                TransportReg.Acode = ddlacadyear.SelectedValue
            End If
            If txtStdCode.Text = "" Then
                TransportReg.Std_Emp = "*"
            Else
                TransportReg.Std_Emp = txtStdCode.Text
            End If
            If txtStdName.Text = "" Then
                TransportReg.StdName = 0
            Else
                TransportReg.StdName = txtStdName.Text
            End If
            TransportReg.EmpName = 0
            If txtEmpCode.Text = "" Then
                TransportReg.EmpCod = "*"
            End If
            If DdlRouteName.SelectedValue = "" Then
                TransportReg.RouteID = 0
            Else
                TransportReg.RouteID = DdlRouteName.SelectedValue
            End If
            For Each rows As GridViewRow In GVTransport.Rows
                If CType(rows.FindControl("lblPickuptime"), Label).Text = "12:00 AM" Then
                    CType(rows.FindControl("lblPickuptime"), Label).Text = ""
                End If
            Next
            GVTransport.Columns(4).Visible = False
            GVTransport.Columns(5).Visible = False
            GVTransport.Columns(3).Visible = True
            GVTransport.Columns(2).Visible = True
            dt = BLTransportRegB.GetTransportReg(TransportReg)
            If dt.Rows.Count > 0 Then
                GVTransport.DataSource = dt
                GVTransport.DataBind()
                GVTransport.Enabled = True
                GVTransport.Visible = True
            Else
                'msginfo.Visible = True
                lblmsg.Text = ""
                msginfo.Visible = True
                msginfo.Text = "No records to display."
                RBUsers.Focus()
                lblmsg.Text = ""
                GVTransport.Visible = False
            End If
        Else
            TransportReg.RBUser = RBUsers.SelectedValue
            If ddlacadyear.SelectedValue = "" Then
                TransportReg.Acode = 0
            Else
                TransportReg.Acode = ddlacadyear.SelectedValue
            End If
            If txtStdCode.Text = "" Then
                TransportReg.Std_Emp = "*"
            Else
                TransportReg.Std_Emp = "*"
            End If
            TransportReg.StdName = 0
            If txtEmpName.Text = "" Then
                TransportReg.EmpName = 0
            Else
                TransportReg.EmpName = txtEmpName.Text
            End If
            If txtEmpCode.Text = "" Then
                TransportReg.EmpCod = "*"
            Else
                TransportReg.EmpCod = txtEmpCode.Text
            End If
            If DdlRouteName.SelectedValue = "" Then
                TransportReg.RouteID = 0
            Else
                TransportReg.RouteID = DdlRouteName.SelectedValue
            End If

            For Each rows As GridViewRow In GVTransport.Rows
                If CType(rows.FindControl("lblPickuptime"), Label).Text = "12:00 AM" Then
                    CType(rows.FindControl("lblPickuptime"), Label).Text = ""
                End If
            Next
            GVTransport.Columns(2).Visible = False
            GVTransport.Columns(3).Visible = False
            GVTransport.Columns(5).Visible = True
            GVTransport.Columns(4).Visible = True
            dt = BLTransportRegB.GetTransportReg(TransportReg)
            If dt.Rows.Count > 0 Then
                GVTransport.DataSource = dt
                GVTransport.DataBind()
                GVTransport.Visible = True
                GVTransport.Enabled = True
            Else
                lblmsg.Text = ""
                msginfo.Visible = True
                msginfo.Text = "No records to display."
                RBUsers.Focus()
                lblmsg.Text = ""
                GVTransport.Visible = False
            End If
        End If
    End Sub
    Sub DisplayGrid1()
        TransportReg.TRNO = 0
        If RBUsers.SelectedValue = "Student" Then
            TransportReg.RBUser = RBUsers.SelectedValue
            If ddlacadyear.SelectedValue <> "" Then
                TransportReg.Acode = 0
            End If
            If txtStdCode.Text <> "" Then
                TransportReg.Std_Emp = "*"
            End If
            If txtStdName.Text <> "" Then
                TransportReg.StdName = 0
            End If
            TransportReg.EmpName = 0
            If txtEmpCode.Text = "" Then
                TransportReg.EmpCod = "*"
            End If
            If DdlRouteName.SelectedValue <> "" Then
                TransportReg.RouteID = 0
            End If
            For Each rows As GridViewRow In GVTransport.Rows
                If CType(rows.FindControl("lblPickuptime"), Label).Text = "12:00 AM" Then
                    CType(rows.FindControl("lblPickuptime"), Label).Text = ""
                End If
            Next
            GVTransport.Columns(4).Visible = False
            GVTransport.Columns(5).Visible = False
            GVTransport.Columns(3).Visible = True
            GVTransport.Columns(2).Visible = True
            dt = BLTransportRegB.GetTransportReg(TransportReg)
            If dt.Rows.Count > 0 Then
                GVTransport.DataSource = dt
                GVTransport.DataBind()
                GVTransport.Enabled = True
                GVTransport.Visible = True
            Else
                'msginfo.Visible = True
                lblmsg.Text = ""
                msginfo.Visible = True
                msginfo.Text = "No records to display."
                RBUsers.Focus()
                lblmsg.Text = ""
                GVTransport.Visible = False
            End If
        Else
            TransportReg.RBUser = RBUsers.SelectedValue
            If ddlacadyear.SelectedValue <> "" Then
                TransportReg.Acode = 0
            End If
            If txtStdCode.Text = "" Then
                TransportReg.Std_Emp = "*"

            End If
            TransportReg.StdName = 0
            If txtEmpName.Text <> "" Then
                TransportReg.EmpName = 0
            End If
            If txtEmpCode.Text <> "" Then
                TransportReg.EmpCod = "*"
            End If
            If DdlRouteName.SelectedValue <> "" Then
                TransportReg.RouteID = 0

            End If

            For Each rows As GridViewRow In GVTransport.Rows
                If CType(rows.FindControl("lblPickuptime"), Label).Text = "12:00 AM" Then
                    CType(rows.FindControl("lblPickuptime"), Label).Text = ""
                End If
            Next
            GVTransport.Columns(2).Visible = False
            GVTransport.Columns(3).Visible = False
            GVTransport.Columns(5).Visible = True
            GVTransport.Columns(4).Visible = True
            dt = BLTransportRegB.GetTransportReg(TransportReg)
            If dt.Rows.Count > 0 Then
                GVTransport.DataSource = dt
                GVTransport.DataBind()
                GVTransport.Visible = True
                GVTransport.Enabled = True
            Else
                lblmsg.Text = ""
                msginfo.Visible = True
                msginfo.Text = "No records to display."
                RBUsers.Focus()
                lblmsg.Text = ""
                GVTransport.Visible = False
            End If
        End If
    End Sub
    Sub DisGrid()
        TransportReg.TRNO = 0
        If RBUsers.SelectedValue = "Student" Then
            TransportReg.RBUser = RBUsers.SelectedValue
            If ddlacadyear.SelectedValue <> "" Then
                TransportReg.Acode = 0
            End If
            If txtStdCode.Text <> "" Then
                TransportReg.Std_Emp = "*"
            End If
            If txtStdName.Text <> "" Then
                TransportReg.StdName = 0
            End If
            TransportReg.EmpName = 0
            TransportReg.EmpCod = 0
            If DdlRouteName.SelectedValue = "" Then
                TransportReg.RouteID = 0
            Else
                TransportReg.RouteID = 0
            End If
            For Each rows As GridViewRow In GVTransport.Rows
                If CType(rows.FindControl("lblPickuptime"), Label).Text = "12:00 AM" Then
                    CType(rows.FindControl("lblPickuptime"), Label).Text = ""
                End If
            Next
            GVTransport.Columns(4).Visible = False
            GVTransport.Columns(5).Visible = False
            GVTransport.Columns(3).Visible = True
            GVTransport.Columns(2).Visible = True
            dt = BLTransportRegB.GetTransportReg(TransportReg)
            If dt.Rows.Count > 0 Then
                GVTransport.DataSource = dt
                GVTransport.DataBind()
                GVTransport.Enabled = True
                GVTransport.Visible = True
            Else
                'msginfo.Visible = True
                lblmsg.Text = ""
                msginfo.Visible = True
                msginfo.Text = "No records to display."
                RBUsers.Focus()
                lblmsg.Text = ""
                GVTransport.Visible = False
            End If
        Else
            TransportReg.RBUser = RBUsers.SelectedValue
            If ddlacadyear.SelectedValue <> "" Then
                TransportReg.Acode = 0
            End If
            TransportReg.Std_Emp = 0
            TransportReg.StdName = 0
            If txtEmpName.Text <> "" Then
                TransportReg.EmpName = 0
            End If
            If txtEmpCode.Text <> "" Then
                TransportReg.EmpCod = "*"
            End If
            If DdlRouteName.SelectedValue = "" Then
                TransportReg.RouteID = 0
            Else
                TransportReg.RouteID = 0
            End If
            For Each rows As GridViewRow In GVTransport.Rows
                If CType(rows.FindControl("lblPickuptime"), Label).Text = "12:00 AM" Then
                    CType(rows.FindControl("lblPickuptime"), Label).Text = ""
                End If
            Next
            GVTransport.Columns(2).Visible = False
            GVTransport.Columns(3).Visible = False
            GVTransport.Columns(5).Visible = True
            GVTransport.Columns(4).Visible = True
            dt = BLTransportRegB.GetTransportReg(TransportReg)
            If dt.Rows.Count > 0 Then
                GVTransport.DataSource = dt
                GVTransport.DataBind()
                GVTransport.Visible = True
                GVTransport.Enabled = True
            Else
                'msginfo.Visible = True
                lblmsg.Text = ""
                msginfo.Visible = True
                msginfo.Text = "No records to display."
                RBUsers.Focus()
                lblmsg.Text = " "
                GVTransport.Visible = False
            End If
        End If
    End Sub
    Protected Sub DdlRouteName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlRouteName.SelectedIndexChanged
        'Code For Auto Fill Route Number And Vehicle No By Nitin 16-05-2012
        If DdlRouteName.SelectedItem.Text = "Select" Then
            TxtRouteNumber.Text = ""
            TxtVehicleNumber.Text = ""
        End If
        msginfo.Text = ""
        TransportReg.RouteID = DdlRouteName.SelectedValue
        dt1 = BLTransportRegB.AutoFilForRutNo(TransportReg)
        If dt1.Rows.Count > 0 Then
            TxtRouteNumber.Text = dt1.Rows(0).Item("RouteNo")
            TxtVehicleNumber.Text = dt1.Rows(0).Item("VehicleRegnNo")
        Else
            lblmsg.Text = ""
        End If
        'Code For Spilt String By Nitin 21-05-2012
        Dim dt As New DataTable
        DdlPickupPoint.Items.Clear()
        Dim RouteID As Integer
        RouteID = DdlRouteName.SelectedValue
        dt = DLTransportReg.GetPickuppointcombo(RouteID)
        If dt.Rows.Count > 0 Then
            Dim parts As String() = dt.Rows(0)("pickuppoint").Split(New Char() {","})
            DdlPickupPoint.DataSource = parts
            DdlPickupPoint.DataBind()
        End If
    End Sub
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnDetails.Click
        LinkButton1.Focus()
        'code for Display Method By Nitin 18-05-2012
        lblmsg.Text = ""
        msginfo.Text = ""
        If BtnDetails.Text = "VIEW" Then
            ViewState("PageIndex") = 0
            GVTransport.PageIndex = 0
            DisplayGrid()
        End If
        If BtnDetails.Text = "BACK" Then
            RBUsers.Enabled = True
            TransportReg.RBUser = RBUsers.SelectedValue
            BtnSave.Text = "ADD"
            BtnDetails.Text = "VIEW"
            msginfo.Text = ""
            lblmsg.Text = ""
            GVTransport.PageIndex = ViewState("PageIndex")
            TransportReg.TRNO = 0
            TransportReg.Acode = 0
            TransportReg.Std_Emp = "*"
            TransportReg.StdName = 0
            TransportReg.EmpName = 0
            TransportReg.EmpCod = "*"
            TransportReg.RouteID = 0
            dt = BLTransportRegB.GetTransportReg(TransportReg)
            If dt.Rows.Count > 0 Then
                GVTransport.DataSource = dt
                GVTransport.DataBind()
                GVTransport.Visible = True
                GVTransport.Enabled = True
            Else
                lblmsg.Text = ""
                msginfo.Visible = True
                msginfo.Text = "No records to display."
                RBUsers.Focus()
                lblmsg.Text = ""
                GVTransport.Visible = False
            End If
            Clear1()
           
        Else
            If txtStdCode.Text = "" And RBUsers.SelectedValue = "Student" Then
                ''msginfo.Text = "Please enter Student Code."
                lblmsg.Text = ""
            ElseIf txtEmpCode.Text = "*" And RBUsers.SelectedValue = "Employee" Then
                lblmsg.Text = ""
            Else
                DisplayGrid()
                ''Clear()
            End If
        End If
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBUsers.SelectedIndexChanged
        msginfo.Text = ""
        lblmsg.Text = ""
        If RBUsers.SelectedItem.Text = "Student" Then
            GVTransport.Visible = False
        Else
            GVTransport.Visible = False
        End If
        If RBUsers.SelectedValue = "Student" Then
            TxtRegistration.Text = Format(Date.Today, "dd-MMM-yyyy")
            lblStdCode.Visible = True
            txtStdCode.Visible = True
            lblStdName.Visible = True
            txtStdName.Visible = True
            lblEmpCode.Visible = False
            txtEmpCode.Visible = False
            lblEmpName.Visible = False
            txtEmpName.Visible = False
            lblAcademicYear.Visible = True
            ddlacadyear.Visible = True
            lblRouteName.Visible = True
            DdlRouteName.Visible = True
            lblRouteNumber.Visible = True
            TxtRouteNumber.Visible = True
            lblPickupPoint.Visible = True
            DdlPickupPoint.Visible = True
            lblVehicleNumber.Visible = True
            TxtVehicleNumber.Visible = True
            lblpickuptime.Visible = True
            txtPickuptime.Visible = True
            lblRegistration.Visible = True
            TxtRegistration.Visible = True
            lblRemarks.Visible = True
            txtRemarks.Visible = True
        Else
            TxtRegistration.Text = Format(Date.Today, "dd-MMM-yyyy")
            lblStdCode.Visible = False
            txtStdCode.Visible = False
            lblStdName.Visible = False
            txtStdName.Visible = False
            lblEmpCode.Visible = True
            txtEmpCode.Visible = True
            lblEmpName.Visible = True
            txtEmpName.Visible = True
            lblAcademicYear.Visible = True
            ddlacadyear.Visible = True
            lblRouteName.Visible = True
            DdlRouteName.Visible = True
            lblRouteNumber.Visible = True
            TxtRouteNumber.Visible = True
            lblPickupPoint.Visible = True
            DdlPickupPoint.Visible = True
            lblVehicleNumber.Visible = True
            TxtVehicleNumber.Visible = True
            lblpickuptime.Visible = True
            txtPickuptime.Visible = True
            lblRegistration.Visible = True
            TxtRegistration.Visible = True
            lblRemarks.Visible = True
            txtRemarks.Visible = True
        End If
    End Sub

    Sub selection()
        If RBUsers.SelectedValue.ToString = "Employee" Then
            AutoCompleteExtender3.ServicePath = "TextBoxExt.asmx"
            AutoCompleteExtender3.ServiceMethod = "getEmpCodeExt1"
        ElseIf RBUsers.SelectedValue.ToString = "Student" Then
            AutoCompleteExtender1.ServicePath = "TextBoxExt.asmx"
            AutoCompleteExtender1.ServiceMethod = "getStudentIdName1"
        End If
    End Sub
    Protected Sub GVTransport_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVTransport.RowDeleting
        'code for Row Deleting By Nitin 18-05-2012
        If (Session("BranchCode") = Session("ParentBranch")) Then
            BLTransportRegB.ChangeFlag(CType(GVTransport.Rows(e.RowIndex).FindControl("lblTranid"), HiddenField).Value())
            TransportReg.TRNO = ViewState("TRNO")
            GVTransport.DataBind()
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            RBUsers.Focus()
            msginfo.Text = " "
            Clear()
            GVTransport.PageIndex = ViewState("PageIndex")
            TransportReg.TRNO = 0
            If RBUsers.SelectedValue = "Student" Then
                TransportReg.RBUser = RBUsers.SelectedValue
                If ddlacadyear.SelectedValue = "" Then
                    TransportReg.Acode = 0
                Else
                    TransportReg.Acode = ddlacadyear.SelectedValue
                End If
                If txtStdCode.Text = "" Then
                    TransportReg.Std_Emp = "*"
                Else
                    TransportReg.Std_Emp = txtStdCode.Text
                End If
                If txtStdName.Text = "" Then
                    TransportReg.StdName = 0
                Else
                    TransportReg.StdName = txtStdName.Text
                End If
                TransportReg.EmpName = 0
                If txtEmpCode.Text = "" Then
                    TransportReg.EmpCod = "*"
                End If
                If DdlRouteName.SelectedValue = "" Then
                    TransportReg.RouteID = 0
                Else
                    TransportReg.RouteID = DdlRouteName.SelectedValue
                End If
                For Each rows As GridViewRow In GVTransport.Rows
                    If CType(rows.FindControl("lblPickuptime"), Label).Text = "12:00 AM" Then
                        CType(rows.FindControl("lblPickuptime"), Label).Text = ""
                    End If
                Next
                GVTransport.Columns(4).Visible = False
                GVTransport.Columns(5).Visible = False
                GVTransport.Columns(3).Visible = True
                GVTransport.Columns(2).Visible = True
                dt = BLTransportRegB.GetTransportReg(TransportReg)

                GVTransport.DataSource = dt
                GVTransport.DataBind()
                GVTransport.Enabled = True
                GVTransport.Visible = True

            Else
                TransportReg.RBUser = RBUsers.SelectedValue
                If ddlacadyear.SelectedValue = "" Then
                    TransportReg.Acode = 0
                Else
                    TransportReg.Acode = ddlacadyear.SelectedValue
                End If
                If txtStdCode.Text = "" Then
                    TransportReg.Std_Emp = "*"
                Else
                    TransportReg.Std_Emp = "*"
                End If
                TransportReg.StdName = 0
                If txtEmpName.Text = "" Then
                    TransportReg.EmpName = 0
                Else
                    TransportReg.EmpName = txtEmpName.Text
                End If
                If txtEmpCode.Text = "" Then
                    TransportReg.EmpCod = "*"
                Else
                    TransportReg.EmpCod = txtEmpCode.Text
                End If
                If DdlRouteName.SelectedValue = "" Then
                    TransportReg.RouteID = 0
                Else
                    TransportReg.RouteID = DdlRouteName.SelectedValue
                End If

                For Each rows As GridViewRow In GVTransport.Rows
                    If CType(rows.FindControl("lblPickuptime"), Label).Text = "12:00 AM" Then
                        CType(rows.FindControl("lblPickuptime"), Label).Text = ""
                    End If
                Next
                GVTransport.Columns(2).Visible = False
                GVTransport.Columns(3).Visible = False
                GVTransport.Columns(5).Visible = True
                GVTransport.Columns(4).Visible = True
                dt = BLTransportRegB.GetTransportReg(TransportReg)

                GVTransport.DataSource = dt
                GVTransport.DataBind()
                GVTransport.Visible = True
                GVTransport.Enabled = True

            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GVTransport_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVTransport.RowEditing
        'code for Row Editing By Nitin 18-05-2012
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        msginfo.Text = ""
        lblmsg.Text = ""
        'TransportReg.TRNO = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblTranid"), HiddenField).Value
        ViewState("TRNO") = CType(GVTransport.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        ddlacadyear.SelectedValue = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblAyear"), Label).Text
        DdlRouteName.SelectedValue = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblRoutName"), Label).Text

        TxtRouteNumber.Text = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblroutenumber"), Label).Text
        txtPickuptime.Text = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblPickuptime"), Label).Text
        TxtRegistration.Text = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblRegdate"), Label).Text
        txtRemarks.Text = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
        TxtVehicleNumber.Text = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblvehicleNo"), Label).Text
        TransportReg.TRNO = ViewState("TRNO")
        Dim dt As New DataTable
        DdlPickupPoint.Items.Clear()
        Dim RouteID As Integer
        RouteID = DdlRouteName.SelectedValue
        TransportReg.StdName = 0
        TransportReg.EmpName = 0
        dt = DLTransportReg.GetPickuppointcombo(RouteID)
        If dt.Rows.Count > 0 Then
            Dim parts As String() = dt.Rows(0)("pickuppoint").Split(New Char() {","})
            DdlPickupPoint.DataSource = parts
            DdlPickupPoint.DataBind()

        End If
        DdlPickupPoint.SelectedValue = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblPickupPoint"), Label).Text
        If RBUsers.SelectedValue = "Student" Then
            HidstdId.Value = CType(GVTransport.Rows(e.NewEditIndex).FindControl("StdHidden"), HiddenField).Value
            txtStdCode.Text = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblStdcode"), Label).Text
            txtStdName.Text = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblStdName"), Label).Text
            TransportReg.Std_Emp = txtStdCode.Text
            TransportReg.EmpCod = 0
            RBUsers.Enabled = False
            'ViewState("ID") = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblID"), Label).Text
        Else
            HidEmp.Value = CType(GVTransport.Rows(e.NewEditIndex).FindControl("EmpIdHidden"), HiddenField).Value
            txtEmpCode.Text = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblEmpCode"), Label).Text
            txtEmpName.Text = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblEmpName"), Label).Text.Trim
            TransportReg.EmpCod = txtEmpCode.Text
            TransportReg.Std_Emp = 0
            RBUsers.Enabled = False
            'ViewState("ID") = CType(GVTransport.Rows(e.NewEditIndex).FindControl("lblIDEmp"), Label).Text
        End If
        TransportReg.RBUser = RBUsers.SelectedValue
        'dt = BLTransportRegB.GetTransportReg(TransportReg)
        'Dim parts1 As String() = dt.Rows(0)("pickuppoint").Split(New Char() {","})
        'DdlPickupPoint.DataSource = parts1
        'DdlPickupPoint.DataBind()
        BtnSave.Text = "UPDATE"
        BtnDetails.Text = "BACK"
        HidTRN.Value = ViewState("TRNO")
        TransportReg.TRNO = ViewState("TRNO")
        TransportReg.RBUser = RBUsers.SelectedValue
        dt = BLTransportRegB.GetTransportReg(TransportReg)
        GVTransport.DataSource = dt
        GVTransport.DataBind()
        GVTransport.Enabled = False
        GVTransport.Visible = True
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub
    Sub regdate()
        TxtRegistration.Text = Format(Date.Today, "dd-MMM-yyyy")
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            regdate()
        End If
        If txtStdCode.Text <> "" Then
            Splitter1(txtStdCode.Text)
        Else
            txtStdCode.AutoPostBack = True
            txtStdName.Text = ""
            Splitter1(txtStdCode.Text)
        End If
        If txtEmpCode.Text <> "" Then
            Splitter2(txtEmpCode.Text)
        Else
            txtEmpCode.AutoPostBack = True
            txtEmpName.Text = ""
            Splitter2(txtEmpCode.Text)
        End If
        RBUsers.Focus()
    End Sub
    Protected Sub DdlRouteName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlRouteName.TextChanged
        DdlRouteName.Focus()
    End Sub

    Protected Sub ddlacadyear_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlacadyear.TextChanged
        ddlacadyear.Focus()
    End Sub
    Protected Sub txtStdCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStdCode.TextChanged
        DdlRouteName.Focus()
    End Sub
    Protected Sub txtEmpCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtEmpCode.TextChanged
        DdlRouteName.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVTransport_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVTransport.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        TransportReg.TRNO = 0
        If RBUsers.SelectedValue = "Student" Then
            TransportReg.RBUser = RBUsers.SelectedValue
            If ddlacadyear.SelectedValue = "" Then
                TransportReg.Acode = 0
            Else
                TransportReg.Acode = ddlacadyear.SelectedValue
            End If
            If txtStdCode.Text = "" Then
                TransportReg.Std_Emp = "*"
            Else
                TransportReg.Std_Emp = txtStdCode.Text
            End If
            If txtStdName.Text = "" Then
                TransportReg.StdName = 0
            Else
                TransportReg.StdName = txtStdName.Text
            End If
            TransportReg.EmpName = 0
            If txtEmpCode.Text = "" Then
                TransportReg.EmpCod = "*"
            End If
            If DdlRouteName.SelectedValue = "" Then
                TransportReg.RouteID = 0
            Else
                TransportReg.RouteID = DdlRouteName.SelectedValue
            End If
            For Each rows As GridViewRow In GVTransport.Rows
                If CType(rows.FindControl("lblPickuptime"), Label).Text = "12:00 AM" Then
                    CType(rows.FindControl("lblPickuptime"), Label).Text = ""
                End If
            Next
            GVTransport.Columns(4).Visible = False
            GVTransport.Columns(5).Visible = False
            GVTransport.Columns(3).Visible = True
            GVTransport.Columns(2).Visible = True
            dt = BLTransportRegB.GetTransportReg(TransportReg)
            If dt.Rows.Count > 0 Then
                Dim sortedView As New DataView(dt)
                sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
                GVTransport.DataSource = sortedView
                GVTransport.DataBind()
                GVTransport.Enabled = True
                GVTransport.Visible = True
            Else
                'msginfo.Visible = True
                lblmsg.Text = ""
                msginfo.Visible = True
                msginfo.Text = "No records to display."
                RBUsers.Focus()
                lblmsg.Text = ""
                GVTransport.Visible = False
            End If
        Else
            TransportReg.RBUser = RBUsers.SelectedValue
            If ddlacadyear.SelectedValue = "" Then
                TransportReg.Acode = 0
            Else
                TransportReg.Acode = ddlacadyear.SelectedValue
            End If
            If txtStdCode.Text = "" Then
                TransportReg.Std_Emp = "*"
            Else
                TransportReg.Std_Emp = "*"
            End If
            TransportReg.StdName = 0
            If txtEmpName.Text = "" Then
                TransportReg.EmpName = 0
            Else
                TransportReg.EmpName = txtEmpName.Text
            End If
            If txtEmpCode.Text = "" Then
                TransportReg.EmpCod = "*"
            Else
                TransportReg.EmpCod = txtEmpCode.Text
            End If
            If DdlRouteName.SelectedValue = "" Then
                TransportReg.RouteID = 0
            Else
                TransportReg.RouteID = DdlRouteName.SelectedValue
            End If

            For Each rows As GridViewRow In GVTransport.Rows
                If CType(rows.FindControl("lblPickuptime"), Label).Text = "12:00 AM" Then
                    CType(rows.FindControl("lblPickuptime"), Label).Text = ""
                End If
            Next
            GVTransport.Columns(2).Visible = False
            GVTransport.Columns(3).Visible = False
            GVTransport.Columns(5).Visible = True
            GVTransport.Columns(4).Visible = True
            dt = BLTransportRegB.GetTransportReg(TransportReg)
            If dt.Rows.Count > 0 Then
                Dim sortedView As New DataView(dt)
                sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
                GVTransport.DataSource = sortedView
                GVTransport.DataBind()
                GVTransport.Enabled = True
                GVTransport.Visible = True
            Else
                lblmsg.Text = ""
                msginfo.Visible = True
                msginfo.Text = "No records to display."
                RBUsers.Focus()
                lblmsg.Text = ""
                GVTransport.Visible = False
            End If
        End If

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
