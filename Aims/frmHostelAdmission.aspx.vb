Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports Microsoft.VisualBasic.Strings

Partial Class frmHostelAdmission
    Inherits BasePage
    Dim BLL As New HostelAdmissionBL
    Dim ELL As New HostelAdmissionE
    Dim DLL As New HostelAdmissionDL
    Sub Splitter(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("StdCode") = parts(0).ToString()
            txtStudentCode.Text = parts(0).ToString()
            txtStudName.Text = parts(2).ToString()
            txtStudAddr.Text = parts(3).ToString()
            txtAcaYear.Text = parts(4).ToString()
            txtCourse.Text = parts(6).ToString()
            txtStudBatch.Text = parts(8).ToString()
            StdId.Value = parts(1).ToString()
            HCId.Value = parts(7).ToString()
            HBId.Value = parts(9).ToString()
            HAId.Value = parts(5).ToString()
            'ViewState("StdID") = StdId
        Else
            txtStudentCode.AutoPostBack = True
        End If
    End Sub
    Sub selection()
        'If RBUsers.SelectedValue.ToString = "Employee" Then
        '    AutoCompleteExtender3.ServicePath = "TextBoxExt.asmx"
        '    AutoCompleteExtender3.ServiceMethod = "getEmpCodeExt1"
        'ElseIf RBUsers.SelectedValue.ToString = "Student" Then
        AutoCompleteExtender1.ServicePath = "TextBoxExt.asmx"
        AutoCompleteExtender1.ServiceMethod = "getStudentIdName1"
        'End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            txtAdate.Text = Format(Date.Today, "dd-MMM-yyyy")
            txtAdate.Focus()
            panel4.Visible = False
            panel5.Visible = False
            ddlHostelCode.Focus()
            txtOccupants11.Enabled = False
            TxtHostelName1.Enabled = False
        End If
        If txtStudentCode.Text <> "" Then
            Splitter(txtStudentCode.Text)
        Else
            txtStudentCode.AutoPostBack = True
            txtStudName.Text = ""
            Splitter(txtStudentCode.Text)
        End If

        If Not IsPostBack Then
            ddlBranchName.SelectedValue = Session("BranchCode")
        End If
        'cmbHosName.Items.Clear()
    End Sub
    Sub Display()
        Dim dt As New DataTable
        Dim RId As New Integer
        Dim HId As New Integer
        'Dim Id As New Integer
        'Dim Hdid As Integer
        RId = cmbRoomType.SelectedValue
        HId = cmbHosName.SelectedValue
        'Id = ViewState("HAIDAuto")
        'Hdid = ViewState("HDID")
        dt = BLL.GetRoomDetails(RId, HId)
        If dt.Rows.Count > 0 Then
            GVHostelAdmission.DataSource = dt
            GVHostelAdmission.DataBind()
            LinkButton7.Focus()
            GVHostelAdmission.Visible = True
            GVHostelAdmission.Enabled = True
            'GridView1.Visible = False
            lblE.Text = ""
            lblS.Text = ""
           
            For Each rows As GridViewRow In GVHostelAdmission.Rows
                If CType(rows.FindControl("lblOccupant"), Label).Text = "1" Then
                    CType(rows.FindControl("ChkSeatNo1"), CheckBox).Enabled = True
                    CType(rows.FindControl("txtstud1"), TextBox).Enabled = True

                    CType(rows.FindControl("ChkSeatNo2"), CheckBox).Enabled = False
                    CType(rows.FindControl("txtstud2"), TextBox).Enabled = False
                    CType(rows.FindControl("ChkSeatNo3"), CheckBox).Enabled = False
                    CType(rows.FindControl("txtstud3"), TextBox).Enabled = False
                    CType(rows.FindControl("ChkSeatNo4"), CheckBox).Enabled = False
                    CType(rows.FindControl("txtstud4"), TextBox).Enabled = False

                ElseIf CType(rows.FindControl("lblOccupant"), Label).Text = "2" Then
                    CType(rows.FindControl("ChkSeatNo1"), CheckBox).Enabled = True
                    CType(rows.FindControl("txtstud1"), TextBox).Enabled = True

                    CType(rows.FindControl("ChkSeatNo2"), CheckBox).Enabled = True
                    CType(rows.FindControl("txtstud2"), TextBox).Enabled = True

                    CType(rows.FindControl("ChkSeatNo3"), CheckBox).Enabled = False
                    CType(rows.FindControl("txtstud3"), TextBox).Enabled = False
                    CType(rows.FindControl("ChkSeatNo4"), CheckBox).Enabled = False
                    CType(rows.FindControl("txtstud4"), TextBox).Enabled = False

                ElseIf CType(rows.FindControl("lblOccupant"), Label).Text = "3" Then
                    CType(rows.FindControl("ChkSeatNo1"), CheckBox).Enabled = True
                    CType(rows.FindControl("txtstud1"), TextBox).Enabled = True

                    CType(rows.FindControl("ChkSeatNo2"), CheckBox).Enabled = True
                    CType(rows.FindControl("txtstud2"), TextBox).Enabled = True

                    CType(rows.FindControl("ChkSeatNo3"), CheckBox).Enabled = True
                    CType(rows.FindControl("txtstud3"), TextBox).Enabled = True

                    CType(rows.FindControl("ChkSeatNo4"), CheckBox).Enabled = False
                    CType(rows.FindControl("txtstud4"), TextBox).Enabled = False

                ElseIf CType(rows.FindControl("lblOccupant"), Label).Text = "4" Then
                    CType(rows.FindControl("ChkSeatNo1"), CheckBox).Enabled = True
                    CType(rows.FindControl("txtstud1"), TextBox).Enabled = True
                    CType(rows.FindControl("ChkSeatNo2"), CheckBox).Enabled = True
                    CType(rows.FindControl("txtstud2"), TextBox).Enabled = True
                    CType(rows.FindControl("ChkSeatNo3"), CheckBox).Enabled = True
                    CType(rows.FindControl("txtstud3"), TextBox).Enabled = True
                    CType(rows.FindControl("ChkSeatNo4"), CheckBox).Enabled = True
                    CType(rows.FindControl("txtstud4"), TextBox).Enabled = True
                End If

            Next
        Else
            lblE.Text = "No Records To display."
            GVHostelAdmission.Visible = False
        End If

        For Each rows As GridViewRow In GVHostelAdmission.Rows
            If CType(rows.FindControl("txtstud1"), TextBox).Text = "" Then
                CType(rows.FindControl("ChkSeatNo1"), CheckBox).Checked = False

            Else
                CType(rows.FindControl("ChkSeatNo1"), CheckBox).Checked = True
                CType(rows.FindControl("ChkSeatNo1"), CheckBox).Enabled = False
                CType(rows.FindControl("txtstud1"), TextBox).Enabled = False

            End If

            If CType(rows.FindControl("txtstud2"), TextBox).Text = "" Then
                CType(rows.FindControl("ChkSeatNo2"), CheckBox).Checked = False
            Else
                CType(rows.FindControl("ChkSeatNo2"), CheckBox).Checked = True
                CType(rows.FindControl("ChkSeatNo2"), CheckBox).Enabled = False
                CType(rows.FindControl("txtstud2"), TextBox).Enabled = False
            End If
            If CType(rows.FindControl("txtstud3"), TextBox).Text = "" Then
                CType(rows.FindControl("ChkSeatNo3"), CheckBox).Checked = False


            Else
                CType(rows.FindControl("ChkSeatNo3"), CheckBox).Checked = True
                CType(rows.FindControl("ChkSeatNo3"), CheckBox).Enabled = False
                CType(rows.FindControl("txtstud3"), TextBox).Enabled = False
            End If
            If CType(rows.FindControl("txtstud4"), TextBox).Text = "" Then
                CType(rows.FindControl("ChkSeatNo4"), CheckBox).Checked = False


            Else
                CType(rows.FindControl("ChkSeatNo4"), CheckBox).Checked = True
                CType(rows.FindControl("ChkSeatNo4"), CheckBox).Enabled = False
                CType(rows.FindControl("txtstud4"), TextBox).Enabled = False

            End If
        Next
    End Sub

    Protected Sub BtnShow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnShow.Click
        panel1.Visible = True
        panel2.Visible = False
        Display()
        GridView1.Visible = False
    End Sub


    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If BtnUpdate.Text = "SUBMIT" Then
                Try


                    For Each rows As GridViewRow In GVHostelAdmission.Rows
                        If CType(rows.FindControl("ChkSeatNo1"), CheckBox).Checked = True And CType(rows.FindControl("ChkSeatNo1"), CheckBox).Enabled = True Then
                            ELL.StudId1 = StdId.Value
                            ELL.Temp = 1
                            ELL.Hid = CType(rows.FindControl("HDID"), HiddenField).Value
                            ELL.Room_No2 = CType(rows.FindControl("lblRoomNo"), Label).Text
                            ELL.RoomTypeID = cmbRoomType.SelectedValue
                            If txtAdate.Text = "12:00:00 AM" Then
                                ELL.AdmissionDate1 = "1/1/1900"
                            Else
                                ELL.AdmissionDate1 = txtAdate.Text
                            End If
                            ELL.AYear1 = HAId.Value
                            ELL.CId1 = HCId.Value
                            ELL.BId1 = HBId.Value
                            ELL.BloodGroup1 = cmbBloodGroup.SelectedValue
                            ELL.StudAdd1 = txtStudAddr.Text
                            ELL.LGName1 = txtLGName.Text
                            ELL.LGAddress1 = txtLGAddr.Text
                            ELL.LGEmail1 = txtLGEmail.Text
                            ELL.LGContactNumber1 = txtLGPhone.Text
                            Exit For
                        ElseIf CType(rows.FindControl("ChkSeatNo2"), CheckBox).Checked = True And CType(rows.FindControl("ChkSeatNo2"), CheckBox).Enabled = True Then
                            ELL.StudId2 = StdId.Value
                            ELL.Temp = 2
                            ELL.Hid = CType(rows.FindControl("HDID"), HiddenField).Value
                            ELL.Room_No2 = CType(rows.FindControl("lblRoomNo"), Label).Text
                            ELL.RoomTypeID = cmbRoomType.SelectedValue
                            If txtAdate.Text = "12:00:00 AM" Then
                                ELL.AdmissionDate1 = "1/1/1900"
                            Else
                                ELL.AdmissionDate1 = txtAdate.Text
                            End If
                            ELL.AYear1 = HAId.Value
                            ELL.CId1 = HCId.Value
                            ELL.BId1 = HBId.Value
                            ELL.BloodGroup1 = cmbBloodGroup.SelectedValue
                            ELL.StudAdd1 = txtStudAddr.Text
                            ELL.LGName1 = txtLGName.Text
                            ELL.LGAddress1 = txtLGAddr.Text
                            ELL.LGEmail1 = txtLGEmail.Text
                            ELL.LGContactNumber1 = txtLGPhone.Text
                            Exit For

                        ElseIf CType(rows.FindControl("ChkSeatNo3"), CheckBox).Checked = True And CType(rows.FindControl("ChkSeatNo3"), CheckBox).Enabled = True Then
                            ELL.StudId3 = StdId.Value
                            ELL.Temp = 3
                            ELL.Hid = CType(rows.FindControl("HDID"), HiddenField).Value
                            ELL.Room_No2 = CType(rows.FindControl("lblRoomNo"), Label).Text
                            ELL.RoomTypeID = cmbRoomType.SelectedValue
                            If txtAdate.Text = "12:00:00 AM" Then
                                ELL.AdmissionDate1 = "1/1/1900"
                            Else
                                ELL.AdmissionDate1 = txtAdate.Text
                            End If
                            ELL.AYear1 = HAId.Value
                            ELL.CId1 = HCId.Value
                            ELL.BId1 = HBId.Value
                            ELL.BloodGroup1 = cmbBloodGroup.SelectedValue
                            ELL.StudAdd1 = txtStudAddr.Text
                            ELL.LGName1 = txtLGName.Text
                            ELL.LGAddress1 = txtLGAddr.Text
                            ELL.LGEmail1 = txtLGEmail.Text
                            ELL.LGContactNumber1 = txtLGPhone.Text
                            Exit For
                        ElseIf CType(rows.FindControl("ChkSeatNo4"), CheckBox).Checked = True And CType(rows.FindControl("ChkSeatNo4"), CheckBox).Enabled = True Then
                            ELL.StudId4 = StdId.Value
                            ELL.Temp = 4
                            ELL.Hid = CType(rows.FindControl("HDID"), HiddenField).Value
                            ELL.Room_No2 = CType(rows.FindControl("lblRoomNo"), Label).Text
                            ELL.RoomTypeID = cmbRoomType.SelectedValue
                            If txtAdate.Text = "12:00:00 AM" Then
                                ELL.AdmissionDate1 = "1/1/1900"
                            Else
                                ELL.AdmissionDate1 = txtAdate.Text
                            End If
                            ELL.AYear1 = HAId.Value
                            ELL.CId1 = HCId.Value
                            ELL.BId1 = HBId.Value
                            ELL.BloodGroup1 = cmbBloodGroup.SelectedValue
                            ELL.StudAdd1 = txtStudAddr.Text
                            ELL.LGName1 = txtLGName.Text
                            ELL.LGAddress1 = txtLGAddr.Text
                            ELL.LGEmail1 = txtLGEmail.Text
                            ELL.LGContactNumber1 = txtLGPhone.Text
                            Exit For
                        End If


                    Next

                    txtStudentCode.Enabled = True
                    cmbHosName.Enabled = True
                    cmbRoomType.Enabled = True
                    ddl.Enabled = True
                    ELL.HosRegNo = ddl.Text
                    ELL.HostelBranchcode = ddlBranchName.SelectedValue
                    ELL.Hostelid = cmbHosName.SelectedValue
                    Dim dt As DataTable
                    Dim dt1 As DataTable
                    ELL.id = HAId.Value

                    If ELL.StudId1 = 0 And ELL.StudId2 = 0 And ELL.StudId3 = 0 And ELL.StudId4 = 0 Then
                        lblE.Text = "Select Seat Number."
                        lblS.Text = ""
                        Exit Sub
                    Else

                        dt = BLL.CheckDuplicate(ELL)
                        dt1 = HostelAdmissionDL.CheckDuplicate1(ELL)

                        If dt.Rows.Count > 0 Then
                            Display()
                            lblS.Text = ""
                            lblE.Text = "Data already exists."
                        ElseIf dt1.Rows.Count > 0 Then
                            Display()
                            lblS.Text = ""
                            lblE.Text = "Hostel Registration No already exists."
                        Else
                            HostelAdmissionDL.UpdateRecord(ELL)
                            Display()
                            lblS.Text = "Data Submitted Successfully."
                            lblE.Text = ""
                            HosAdmClear()
                            'clear()
                        End If
                    End If
                Catch ex As NullReferenceException
                    lblE.Text = "Select the seat number."
                    lblS.Text = ""
                Catch ex1 As InvalidCastException

                    lblE.Text = "Enter Correct Date."
                    lblS.Text = ""
                End Try
                'End If

            ElseIf BtnUpdate.Text = "UPDATE" Then
                ELL.id = ViewState("HAIDAuto")
                ELL.StudId1 = ViewState("Std_Id")
                ELL.Hid = ViewState("HDIDAuto")
                ELL.RoomTypeID = cmbRoomType.SelectedValue
                If txtAdate.Text = "12:00:00 AM" Then
                    ELL.AdmissionDate1 = "1/1/1900"
                Else
                    ELL.AdmissionDate1 = txtAdate.Text
                End If
                ELL.AYear1 = ViewState("A_Year")
                ELL.CId1 = ViewState("CourseID")
                ELL.BId1 = ViewState("BatchID")
                ELL.BloodGroup1 = cmbBloodGroup.SelectedValue
                ELL.StudAdd1 = txtStudAddr.Text
                ELL.LGName1 = txtLGName.Text
                ELL.LGAddress1 = txtLGAddr.Text
                ELL.LGEmail1 = txtLGEmail.Text
                ELL.LGContactNumber1 = txtLGPhone.Text
                ELL.HosRegNo = ddl.Text
                ELL.HostelBranchcode = ddlBranchName.SelectedValue
                Dim dt As DataTable

                dt = HostelAdmissionDL.CheckDuplicate1(ELL)
                If dt.Rows.Count > 0 Then
                    display1()
                    lblS.Text = ""
                    lblE.Text = "Data already exists."
                Else

                    HostelAdmissionDL.UpdateRecord1(ELL)
                    display1()
                    txtStudentCode.Enabled = True
                    cmbHosName.Enabled = True
                    cmbRoomType.Enabled = True
                    ddl.Enabled = True
                    lblS.Text = "Data Updated Successfully."
                    HosAdmClear()
                    GridView1.PageIndex = ViewState("PageIndex")
                    lblE.Text = ""
                    'clear()
                    BtnUpdate.Text = "SUBMIT"
                    BtnView.Text = "VIEW"

                End If

            End If
        Else
            lblE.Text = "You do not belong to this branch, Cannot submit/update data."
            lblS.Text = ""
        End If

    End Sub

    Protected Sub BtnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnView.Click
        panel1.Visible = False
        panel2.Visible = True
        If cmbHosName.SelectedValue = 0 Then
            lblE.Text = " Select Hostel Name."
            GVHostelAdmission.Visible = False
            GridView1.Visible = False
            lblS.Text = ""
            cmbHosName.Focus()
        ElseIf cmbRoomType.SelectedValue = 0 Then
            lblE.Text = " Select Room Type."
            GVHostelAdmission.Visible = False
            GridView1.Visible = False
            lblS.Text = ""
            cmbRoomType.Focus()
        Else

            If BtnView.Text = "VIEW" Then
                GridView1.Visible = True
                txtStudentCode.Enabled = True
                cmbHosName.Enabled = True
                cmbRoomType.Enabled = True
                ddl.Enabled = True
                txtAdate.Enabled = False
                lblE.Text = ""
                lblS.Text = ""
                ViewState("PageIndex") = 0
                GridView1.PageIndex = 0
                display1()
                GridView1.Enabled = True
                'clear()
            Else
                GridView1.Visible = True
                txtStudentCode.Enabled = True
                cmbHosName.Enabled = True
                cmbRoomType.Enabled = True
                ddl.Enabled = True
                txtAdate.Enabled = False
                GridView1.PageIndex = ViewState("PageIndex")
                display1()
                lblS.Text = ""
                lblE.Text = ""
                BtnUpdate.Text = "SUBMIT"
                BtnView.Text = "VIEW"
                GridView1.Enabled = True
                clear1()
                Clear()
                
            End If

            display1()
        End If
    End Sub

    Sub display1()
        Dim dt As New DataTable
        Dim RId As New Integer
        Dim Id As New Integer
        Dim Hid As New Integer
        RId = cmbRoomType.SelectedValue
        Hid = cmbHosName.SelectedValue
        Id = 0
        dt = BLL.GetRecord(RId, Id, Hid)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            LinkButton6.Focus()
            GridView1.Visible = True
            GridView1.Enabled = True
            GVHostelAdmission.Visible = False
            lblE.Text = ""
            lblS.Text = ""
        Else
            lblE.Text = "No Records to display."
            GVHostelAdmission.Visible = False
            GridView1.Visible = False
            lblS.Text = ""
        End If
    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ELL.id = CType(GridView1.Rows(e.RowIndex).FindControl("HAIDAuto"), HiddenField).Value

            ELL.StudId1 = CType(GridView1.Rows(e.RowIndex).FindControl("StudId"), HiddenField).Value
            BLL.DeleteRecord(ELL.id, ELL.StudId1)
            GridView1.DataBind()
            GridView1.PageIndex = ViewState("PageIndex")
            display1()
            lblE.Text = ""
            lblS.Text = "Data Deleted Successfully."
        Else
            lblE.Text = "You do not belong to this branch, Cannot delete data."
            lblS.Text = ""
        End If
    End Sub
    Protected Sub clear1()

        txtCourse.Text = ""
        txtDOL.Text = ""
        Label5.Text = ""
        txtStudAddr.Text = ""
        txtStudBatch.Text = ""
        txtStudentCode.Text = ""
        txtStudName.Text = ""
        txtLGName.Text = ""
        txtLGAddr.Text = ""
        txtLGEmail.Text = ""
        txtLGPhone.Text = ""
        txtAcaYear.Text = ""
        cmbBloodGroup.SelectedValue = 0
        'cmbHosName.SelectedValue = 0
        'cmbRoomType.SelectedValue = 0
        txtDOL.Text = ""

    End Sub
    Protected Sub cmbBloodGroup_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBloodGroup.TextChanged
        cmbBloodGroup.Focus()

    End Sub

    Protected Sub cmbHosName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbHosName.TextChanged
        cmbHosName.Focus()
    End Sub

    Protected Sub cmbRoomType_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRoomType.TextChanged
        cmbRoomType.Focus()
    End Sub

    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Dim stdid As New Integer

        BtnUpdate.Text = "UPDATE"
        BtnView.Text = "BACK"
        GridView1.Visible = True
        GridView1.Enabled = False
        ViewState("Std_Id") = CType(GridView1.Rows(e.NewEditIndex).FindControl("Stdid1"), HiddenField).Value
        ViewState("CourseID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HCID"), HiddenField).Value
        ViewState("A_Year") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HAID"), HiddenField).Value
        ViewState("BatchID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HBID"), HiddenField).Value
        ViewState("HAIDAuto") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HAIDAuto"), HiddenField).Value
        ViewState("HDIDAuto") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HDIDAuto"), HiddenField).Value
       
        txtAdate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("HAdmissionDate"), HiddenField).Value
        txtAcaYear.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblAYear"), Label).Text
        txtStudentCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStudCode"), Label).Text
        txtStudName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblStudName"), Label).Text
        ddlBranchName.DataSourceID = "ObjBranch"
        ddlBranchName.DataBind()
        ddlBranchName.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblBranchcode"), Label).Text
        txtCourse.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblCrs"), Label).Text
        txtStudBatch.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblBatch"), Label).Text
        cmbBloodGroup.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("HBloodGrp"), HiddenField).Value
        txtStudAddr.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("HStudAddr"), HiddenField).Value
        txtLGName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblLGName"), Label).Text
        txtLGEmail.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblLGEmail"), Label).Text
        txtLGPhone.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblLGContNo"), Label).Text
        txtLGAddr.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblLGAddress"), Label).Text
        Label5.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblHosRegNo"), Label).Text
        cmbRoomType.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("HRoomTypeId"), HiddenField).Value
        cmbHosName.SelectedItem.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblHosName"), Label).Text
        Dim dt As New DataTable
        Dim RId As New Integer
        Dim Id As New Integer
        Dim HId As New Integer
        RId = cmbRoomType.SelectedValue
        Id = ViewState("HAIDAuto")
        HId = cmbHosName.SelectedValue
        dt = BLL.GetRecord(RId, Id, HId)
        If dt.Rows.Count > 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            GridView1.Visible = True
            GridView1.Enabled = False
            GVHostelAdmission.Visible = False
            txtStudentCode.Enabled = False
            cmbHosName.Enabled = False
            cmbRoomType.Enabled = False
            ddl.Enabled = False
            lblE.Text = ""
            lblS.Text = ""
        Else
            lblE.Text = "No Records to display."
            GVHostelAdmission.Visible = False
            GridView1.Visible = False
            lblS.Text = ""
        End If
        'Else

        'lblE.Text = "You do not belong to this branch, Cannot edit data."
        'lblS.Text = ""
        'End If


    End Sub


    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If txtDOL.Text = "" Then
                    lblE.Text = " Select Date Of Leaving Field."
                    lblS.Text = ""
                    txtDOL.Focus()
                Else
                    txtAdate.Enabled = False
                    ELL.AdmissionDate1 = txtAdate.Text
                    ELL.DOL = txtDOL.Text
                    If CType(txtAdate.Text, Date) > CType(txtDOL.Text, Date) Then
                        lblS.Text = ""
                        lblE.Text = "'Admission' date should be lesser than 'Leaving' date."
                        txtDOL.Focus()
                        Exit Sub
                    End If
                    ELL.id = CType(GridView1.Rows(e.RowIndex).FindControl("HAIDAuto"), HiddenField).Value
                    ELL.StudId1 = CType(GridView1.Rows(e.RowIndex).FindControl("StudId"), HiddenField).Value
                    BLL.VacateRecord(ELL.id, ELL.StudId1, ELL.DOL)
                    GridView1.DataBind()
                    GridView1.PageIndex = ViewState("PageIndex")
                    display1()
                    lblE.Text = ""
                    lblS.Text = "Student Vacated Successfully."
                    clear1()
                End If
            Catch ex As Exception
                lblE.Text = "Enter Correct Date."
                lblS.Text = ""
                txtDOL.Focus()
            End Try
        Else
            lblE.Text = "You do not belong to this branch, Cannot vacate student."
            lblS.Text = ""
        End If
    End Sub
    Sub HosAdmClear()
        txtAdate.Text = Format(Date.Today, "dd-MMM-yyyy")
        txtStudentCode.Text = ""
        txtAcaYear.Text = ""
        txtCourse.Text = ""
        txtStudName.Text = ""
        txtStudBatch.Text = ""
        txtStudAddr.Text = ""
        txtLGAddr.Text = ""
        txtLGEmail.Text = ""
        txtLGName.Text = ""
        txtLGPhone.Text = ""
        Label5.Text = ""
        txtDOL.Text = ""
    End Sub

    'RoomType Code
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
                EL.Remarks = txtRemarks1.Text
                If btnSave.Text = "UPDATE" Then
                    EL.id = ViewState("RoomTypeAuto")
                    dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        lblerrmsg.Text = "Data already exists."
                        lblmsgifo.Text = " "
                    Else

                        BL.UpdateRecord(EL)
                        btnSave.Text = "ADD"
                        btnDetails1.Text = "VIEW"
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
            lblerrmsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsgifo.Text = ""
        End If
    End Sub
    'Code By Jinapriya - 10-Mar-2015 [Searching & Sorting]
    Protected Sub btnDetails1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails1.Click
        lblerrmsg.Text = ""
        lblmsgifo.Text = ""
        If btnDetails1.Text <> "BACK" Then
            DisplayGridView()
            ViewState("PageIndex") = 0
            GVRoomType.PageIndex = 0
            Clear()
        Else
            lblerrmsg.Text = " "
            lblmsgifo.Text = " "
            Clear()
            btnSave.Text = "ADD"
            btnDetails1.Text = "VIEW"
            btnDetails1.Text = "VIEW"
            btnSave.Text = "ADD"
            GVRoomType.PageIndex = ViewState("PageIndex")
            DisplayGridView()
            GVRoomType.Enabled = True

        End If

    End Sub
    Sub Clear()
        txtRoomType.Text = ""
        txtOccupant.Text = ""
        txtRemarks1.Text = ""

    End Sub
    Sub DisplayGridView()
        EL.id = 0
        If txtRoomType.Text = "" Then
            EL.RoomType = 0
        Else
            EL.RoomType = txtRoomType.Text
        End If
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
            LinkButton5.Focus()
        End If
    End Sub

    'Sorting For Room Type.
    Protected Sub GVRoomType_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVRoomType.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        Dim EL As New RoomTypeE
        EL.id = 0
        If txtRoomType.Text = "" Then
            EL.RoomType = 0
        Else
            EL.RoomType = txtRoomType.Text
        End If
        dt = BL.GetRoomType(EL)
        GVRoomType.DataSource = dt
        GVRoomType.DataBind()
        LinkButton5.Focus()
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVRoomType.DataSource = sortedView
        GVRoomType.DataBind()
        GVRoomType.Visible = True
        GVRoomType.Enabled = True
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
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        btnSave.Text = "UPDATE"
        btnDetails1.Text = "BACK"
        lblmsgifo.Text = ""
        lblerrmsg.Text = ""
        btnDetails1.Visible = True
        txtRoomType.Text = CType(GVRoomType.Rows(e.NewEditIndex).FindControl("lblRoomType"), Label).Text
        txtOccupant.Text = CType(GVRoomType.Rows(e.NewEditIndex).FindControl("lblOccupant"), Label).Text
        txtRemarks1.Text = CType(GVRoomType.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
        ViewState("RoomTypeAuto") = CType(GVRoomType.Rows(e.NewEditIndex).FindControl("id"), Label).Text
        EL.id = ViewState("RoomTypeAuto")
        EL.RoomType = txtRoomType.Text
        dt = BL.GetRoomType(EL)
        GVRoomType.DataSource = dt
        GVRoomType.DataBind()
        GVRoomType.Visible = True
        GVRoomType.Enabled = False
        'Else
        'lblerrmsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsgifo.Text = ""
        'End If
    End Sub

    'Protected Sub Page_Load3(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    txtRoomType.Focus()
    '    lblerrmsg.Text = ""
    '    lblmsgifo.Text = ""
    'End Sub
    'Method is for Session exipire 
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    'Hostel master Coding


    Dim objBusErrMesg As New busErrorMessage
    Dim Dh As New BHostelMaster11
    Dim ElHostelMaster As New EHostelMaster11


    'code by Anchala on 23-08-12
    '    'method for delete
    Protected Sub GvHostelMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GvHostelMaster.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim ElHostelMaster As New EHostelMaster11
            ElHostelMaster.Id = CType(GvHostelMaster.Rows(e.RowIndex).FindControl("HID"), HiddenField).Value
            Dh.ChangeFlag(ElHostelMaster)
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            GvHostelMaster.PageIndex = ViewState("PageIndex")
            DisplayhostelMaster()
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GvHostelMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvHostelMaster.RowEditing
        lblmsg.Text = ""
        msginfo.Text = ""
        ElHostelMaster.Id = ViewState("HMID")
        'If (Session("BranchCode") = Session("ParentBranch")) Then

        txtHostelCode.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblHostelCode"), Label).Text
        txtHostelName.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblHostelName"), Label).Text
        txtHostelType.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblHostelType"), Label).Text
        txtHostelAddr.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblHostelAddr"), Label).Text
        txtWarden.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblWarden"), Label).Text
        txtHouseKeeping.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblHouseKeeping"), Label).Text
        txtRemarks.Text = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("lblRemarks"), Label).Text
        ViewState("HMID") = CType(GvHostelMaster.Rows(e.NewEditIndex).FindControl("HID"), HiddenField).Value
        'txtname.Text = ViewState("HM_ID")
        InsertHostelMaster.Text = "UPDATE"
        ViewHostelMaster.Text = "BACK"
        ElHostelMaster.Id = ViewState("HMID")
        ElHostelMaster.HostelName = txtHostelName.Text
        dt = Dh.GetHostelMaster(ElHostelMaster)
        GvHostelMaster.DataSource = dt
        GvHostelMaster.DataBind()
        GvHostelMaster.Enabled = False
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If

    End Sub
    'code by Anchala on 25-08-12
    '    'method for insert and update
    Protected Sub InsertHostelMaster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles InsertHostelMaster.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            txtHostelName.Focus()
            ElHostelMaster.HostelCode = txtHostelCode.Text()
            ElHostelMaster.HostelName = txtHostelName.Text()
            ElHostelMaster.HostelType = txtHostelType.Text()
            ElHostelMaster.HostelAddress = txtHostelAddr.Text()
            ElHostelMaster.Warden = txtWarden.Text()
            ElHostelMaster.HouseKeeping = txtHouseKeeping.Text()
            ElHostelMaster.Remarks = txtRemarks.Text()
            If InsertHostelMaster.Text = "UPDATE" Then
                ElHostelMaster.Id = ViewState("HMID")
                dt = Dh.CheckDuplicate(ElHostelMaster)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    Dh.UpdateRecord(ElHostelMaster)
                    msginfo.Text = ""
                    InsertHostelMaster.Text = "ADD"
                    ViewHostelMaster.Text = "VIEW"
                    lblmsg.Text = "Data Updated Successfully."
                    GvHostelMaster.PageIndex = ViewState("PageIndex")
                    DisplayhostelMaster()
                    txtHostelName.Focus()
                    txtHostelCode.Text = ""
                    txtHostelName.Text = ""
                    txtHostelType.Text = ""
                    txtHostelAddr.Text = ""
                    txtWarden.Text = ""
                    txtHouseKeeping.Text = ""
                    txtRemarks.Text = ""
                End If
            ElseIf InsertHostelMaster.Text = "ADD" Then
                ElHostelMaster.Id = 0
                dt = Dh.CheckDuplicate(ElHostelMaster)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = "Data already exists."
                    lblmsg.Text = ""
                Else
                    Dh.InsertRecord(ElHostelMaster)
                    msginfo.Text = ""
                    InsertHostelMaster.Text = "ADD"
                    lblmsg.Text = "Data Saved successfully."
                    ViewState("PageIndex") = 0
                    GvHostelMaster.PageIndex = 0
                    DisplayhostelMaster()
                    txtHostelName.Focus()
                    txtHostelCode.Text = ""
                    txtHostelName.Text = ""
                    txtHostelType.Text = ""
                    txtWarden.Text = ""
                    txtHouseKeeping.Text = ""
                    txtRemarks.Text = ""
                    ClearHostelMaster()
                    'End If
                    DisplayhostelMaster()
                    panel5.Visible = True
                End If
                ' End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GvHostelMaster_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GvHostelMaster.PageIndexChanging
        GvHostelMaster.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GvHostelMaster.PageIndex
        DisplayhostelMaster()
    End Sub
    'code by Anchala on 25-08-12
    '    'method for view
    Protected Sub ViewHostelMaster_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewHostelMaster.Click
        panel5.Visible = True
        'panel4.Visible = True
        ' GvHostelMaster.DataSourceID = "ObjectDataSource1"
        'lblmsg.Visible = True
        msginfo.Text = ""
        If ViewHostelMaster.Text <> "BACK" Then
            'Dim CategoryManager As New CategoryManager
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GvHostelMaster.PageIndex = 0
            DisplayhostelMaster()
            GvHostelMaster.Visible = True

        Else
            'ClearHostelMaster()
            'Enable()
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewHostelMaster.Text = "VIEW"
            InsertHostelMaster.Text = "ADD"
            txtHostelCode.Text = ""
            txtHostelName.Text = ""
            txtHostelType.Text = ""
            txtWarden.Text = ""
            txtHouseKeeping.Text = ""
            txtHostelAddr.Text = ""
            txtRemarks.Text = ""
            GvHostelMaster.Visible = True
            'Disable()
            GvHostelMaster.PageIndex = ViewState("PageIndex")
            DisplayhostelMaster()
        End If
    End Sub
    'Code By Jinapriya for Searching and sorting on 10-Mar-2015 
    Sub DisplayhostelMaster()
        Dim dt As New DataTable
        ElHostelMaster.Id = 0
        If txtHostelName.Text = "" Then
            ElHostelMaster.HostelName = 0
        Else
            ElHostelMaster.HostelName = txtHostelName.Text
        End If
        dt = Dh.GetHostelMaster(ElHostelMaster)
        GvHostelMaster.DataSource = dt
        GvHostelMaster.DataBind()
        LinkButton4.Focus()
        GvHostelMaster.Visible = True
        GvHostelMaster.Enabled = True
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ""
            msginfo.Text = "No records to display."
            'msginfo.Visible = True
        End If
    End Sub


    '<System.Web.Services.WebMethod()> Public Sub AbandonSession()
    'Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    '   Response.Redirect("LogIn.aspx")
    'End Sub
    Sub ClearHostelMaster()
        txtHostelCode.Text = ""
        txtHostelName.Text = ""
        txtHostelType.Text = ""
        txtWarden.Text = ""
        txtHouseKeeping.Text = ""
        txtRemarks.Text = ""
        txtHostelAddr.Text = ""
    End Sub

    'Hostel Details coding

    Dim elHostelDetails As New ELHostelDetails
    Dim BLHostelDetails As New BLHostelDetails

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
                    lblRed.Text = "Data already exists."
                    lblGreen.Text = ""
                Else
                    BLHostelDetails.Update(elHostelDetails)
                    msginfo.Text = ""
                    InsertHostelDetails.Text = "ADD"
                    ViewHostelDetails.Text = "VIEW"
                    lblGreen.Text = "Data Updated Successfully."
                    lblRed.Text = ""
                    txtOccupants11.Enabled = False
                    TxtHostelName1.Enabled = False
                    GvHostelDetails.PageIndex = ViewState("PageIndex")
                    txtRoomNo1.Text = ""
                    ddlHostelCode.SelectedValue = 0
                    ddlRoomType1.SelectedValue = 0
                    TxtHostelName1.Text = ""
                    txtOccupants11.Text = ""
                    DisplayGrid()
                    ddlHostelCode.Focus()
                End If
            ElseIf InsertHostelDetails.Text = "ADD" Then
                elHostelDetails.Id = 0

                dt = BLHostelDetails.CheckDuplicate(elHostelDetails)
                If dt.Rows.Count > 0 Then
                    lblRed.Text = "Data already exists."
                    lblGreen.Text = ""
                Else
                    BLHostelDetails.Insert(elHostelDetails)
                    msginfo.Text = ""
                    InsertHostelDetails.Text = "ADD"
                    lblGreen.Text = "Data Saved successfully."
                    lblRed.Text = ""
                    txtOccupants11.Enabled = False
                    TxtHostelName1.Enabled = False
                    ViewState("PageIndex") = 0
                    GvHostelDetails.PageIndex = 0
                    'DisplayGrid()
                    ddlHostelCode.Focus()
                    txtRoomNo1.Text = ""
                    ddlHostelCode.SelectedValue = 0
                    ddlRoomType1.SelectedValue = 0
                    TxtHostelName1.Text = ""
                    txtOccupants11.Text = ""
                    DisplayGrid()
                    panel4.Visible = True
                End If
            End If
        Else
            lblRed.Text = "You do not belong to this branch, Cannot add/update data."
            lblGreen.Text = ""
        End If
    End Sub

    Sub DisplayGrid()
        Dim dt As New DataTable
        elHostelDetails.Id = 0
        If ddlHostelCode.SelectedValue = 0 Then
            elHostelDetails.Hostel_COde = 0
        Else
            elHostelDetails.Hostel_COde = ddlHostelCode.SelectedValue
        End If
        If ddlRoomType1.SelectedValue = 0 Then
            elHostelDetails.Room_Type = 0
        Else
            elHostelDetails.Room_Type = ddlRoomType1.SelectedValue
        End If

        dt = BLHostelDetails.GetHostelDetails(elHostelDetails)
        GvHostelDetails.DataSource = dt
        GvHostelDetails.DataBind()
        LinkButton7.Focus()
        txtOccupants11.Enabled = False
        TxtHostelName1.Enabled = False
        GvHostelDetails.Visible = True
        GvHostelDetails.Enabled = True
        If dt.Rows.Count = 0 Then
            lblGreen.Text = ""
            lblRed.Text = "No records to display."
        End If
    End Sub
    'code by Anchala on 27-08-12
    'method for view
    Protected Sub ViewHostelDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ViewHostelDetails.Click
        panel4.Visible = True
        'panel5.Visible = True
        If ViewHostelDetails.Text <> "BACK" Then
            lblRed.Text = ""
            lblGreen.Text = ""
            ViewState("PageIndex") = 0
            GvHostelDetails.PageIndex = 0
            DisplayGrid()
            GvHostelDetails.Visible = True
        Else
            lblRed.Text = ""
            lblGreen.Text = ""
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

            lblGreen.Text = "Data Deleted Successfully."
            lblRed.Text = ""
            GvHostelDetails.PageIndex = ViewState("PageIndex")
            DisplayGrid()
        Else
            lblRed.Text = "You do not belong to this branch, Cannot delete data."
            lblGreen.Text = ""
        End If
    End Sub

    Protected Sub GvHostelDetails_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GvHostelDetails.RowEditing
      
        'If (Session("BranchCode") = Session("ParentBranch")) Then
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
        elHostelDetails.Hostel_COde = ddlHostelCode.SelectedValue
        elHostelDetails.Room_Type = ddlRoomType1.SelectedValue
        dt = BLHostelDetails.GetHostelDetails(elHostelDetails)
        GvHostelDetails.DataSource = dt
        GvHostelDetails.DataBind()
        GvHostelDetails.Enabled = False
        lblRed.Text = ""
        lblGreen.Text = ""
        'Else
        'lblRed.Text = "You do not belong to this branch, Cannot edit data."
        'lblGreen.Text = ""
        'End If

    End Sub

    Protected Sub ddlRoomType1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlRoomType1.SelectedIndexChanged
        elHostelDetails.Room_Type = ddlRoomType1.SelectedValue
        If ddlRoomType1.SelectedValue = 0 Then
            'ddlRoomType1.Text = ""
            'lblRed.Text = "Select Room Rype."
            'lblGreen.Text = ""
            txtOccupants11.Text = ""
        Else
            lblRed.Text = ""
            lblGreen.Text = ""
            dt = BLHostelDetails.NoOfOccupants(elHostelDetails)
            txtOccupants11.Text = dt.Rows(0).Item("NoOfOccupants")
        End If
        txtOccupants11.Enabled = False
    End Sub

    'Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    ddlHostelCode.Focus()
    '    txtOccupants11.Enabled = False
    '    TxtHostelName1.Enabled = False
    'End Sub

    Protected Sub ddlHostelCode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlHostelCode.SelectedIndexChanged
        elHostelDetails.Hostel_COde = ddlHostelCode.SelectedValue
        If ddlHostelCode.SelectedValue = 0 Then
            TxtHostelName1.Text = ""
        Else
            dt = BLHostelDetails.GetHostelName(elHostelDetails)
            TxtHostelName1.Text = dt.Rows(0).Item("HostelName")
        End If
        TxtHostelName1.Enabled = False
    End Sub
    'Code by Jinapriya for searching & sorting on 11-Mar-2015
    Protected Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        Dim sortingDirection As String = String.Empty
        If Dir() = SortDirection.Ascending Then
            Dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            Dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        Dim RId As New Integer
        Dim Id As New Integer
        Dim Hid As New Integer
        RId = cmbRoomType.SelectedValue
        Hid = cmbHosName.SelectedValue
        Id = 0
        dt = BLL.GetRecord(RId, Id, Hid)
        LinkButton6.Focus()
        GridView1.Visible = True
        GridView1.Enabled = True
        GVHostelAdmission.Visible = False
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
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

    Protected Sub GvHostelMaster_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GvHostelMaster.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        ElHostelMaster.Id = 0
        If txtHostelName.Text = "" Then
            ElHostelMaster.HostelName = 0
        Else
            ElHostelMaster.HostelName = txtHostelName.Text
        End If
        dt = Dh.GetHostelMaster(ElHostelMaster)
        GvHostelMaster.DataSource = dt
        GvHostelMaster.DataBind()
        LinkButton4.Focus()
        GvHostelMaster.Visible = True
        GvHostelMaster.Enabled = True
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GvHostelMaster.DataSource = sortedView
        GvHostelMaster.DataBind()
    End Sub

    Protected Sub GvHostelDetails_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GvHostelDetails.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        elHostelDetails.Id = 0
        dt = BLHostelDetails.GetHostelDetails(elHostelDetails)
        GvHostelDetails.DataSource = dt
        GvHostelDetails.DataBind()
        LinkButton7.Focus()
        txtOccupants11.Enabled = False
        TxtHostelName1.Enabled = False
        GvHostelDetails.Visible = True
        GvHostelDetails.Enabled = True
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GvHostelDetails.DataSource = sortedView
        GvHostelDetails.DataBind()
    End Sub

  

    Protected Sub ddlBranchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranchName.SelectedIndexChanged
        Session("HostelBranchCode") = ddlBranchName.SelectedValue
    End Sub

   
End Class
