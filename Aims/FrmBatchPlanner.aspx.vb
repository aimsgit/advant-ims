
Partial Class FrmBatchPlanner
    Inherits BasePage
    Dim bl As New BLBatchPlanner
    Dim v As New BatchPlanner
    Dim dt1 As New DataTable
    Dim dt, dt2 As New DataTable
    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        'code for View BUTTON by nitin
        DdlBatchPlanner.Focus()
        DdlBatchPlanner.Enabled = True
        btnback.Visible = False
        btnAddDetails.Text = "ADD"

        lblmsg.Text = ValidationMessage(1014)
        lblErrorMsg.Text = ValidationMessage(1014)
        If DdlBatchPlanner.SelectedValue = "Select" Then
           
            lblErrorMsg.Text = ValidationMessage(1079)
            lblmsg.Text = ValidationMessage(1014)
            lblR.Text = ValidationMessage(1014)
            lblG.Text = ValidationMessage(1014)
        Else
            LinkButton1.Focus()
            lblR.Text = ValidationMessage(1014)
            lblG.Text = ValidationMessage(1014)
            If txtGenerate.Text = "Y" Then
                v.id = DdlBatchPlanner.SelectedValue
                v.Gid = 0
                If ddlSemester.SelectedValue = 0 Then
                    v.Semester = 0
                Else
                    v.Semester = ddlSemester.SelectedValue
                End If
                dt = bl.GetBatchPlannerView(v)
                GridView1.DataSource = dt
                GridView1.DataBind()

                GridView1.Visible = True
                GridView1.Enabled = True
                
                For Each Grid As GridViewRow In GridView1.Rows
                    CType(Grid.FindControl("DdlLecture"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer"), Label).Text
                    If CType(Grid.FindControl("LabelElec"), Label).Text = "Y" Then
                        CType(Grid.FindControl("ChkElective"), CheckBox).Checked = True
                    Else
                        CType(Grid.FindControl("ChkElective"), CheckBox).Checked = False
                    End If
                Next
                v.BatchID = DdlBatchPlanner.SelectedValue
                If bl.CheckLockBatchPl(v).Tables(0).Rows(0).Item(0) = "Y" Then
                    GridView1.Enabled = False
                Else
                    GridView1.Enabled = True
                End If
            Else
                                lblErrorMsg.Text = ValidationMessage(1080)
                lblmsg.Text = ValidationMessage(1014)
                lblR.Text = ValidationMessage(1014)
                lblG.Text = ValidationMessage(1014)
            End If
        End If
    End Sub
    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        btnback.Visible = False
        DdlBatchPlanner.Enabled = True
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If DdlBatchPlanner.SelectedValue = "Select" Then
                lblErrorMsg.Text = ValidationMessage(1079)
                lblmsg.Text = ValidationMessage(1014)
            Else
                'code for Generate Plan BUTTON bY NITIN 03/03/2012
                If txtGenerate.Text = "N" Then
                    v.BatchID = DdlBatchPlanner.SelectedValue
                    v.Course = TxtCourse.Text
                    v.AcademicYear = txtAcademicYear.Text
                    v.StartDate = CType(Txtstartdate.Text, String)
                    v.Generatestatus = txtGenerate.Text
                    v.id = DdlBatchPlanner.SelectedValue
                    If txtCredit.Text = "" Then
                        v.Credit = 0
                    Else
                        v.Credit = txtCredit.Text
                    End If
                    Dim generateStatus As New DataTable
                    If txtGenerate.Text <> "Y" Then
                        'If bl.GetBatchPlanner(v) > 0 Then
                        Dim RowCount As Integer
                        RowCount = bl.GetBatchPlanner(v)
                        'bl.GetAcedemicYear(v)
                        If RowCount > 0 Then
                            txtGenerate.Text = "Y"
                            lblErrorMsg.Text = ""
                            v.Semester = 0
                            dt = bl.GetBatchPlannerView(v)
                            lblmsg.Text = dt.Rows.Count.ToString + ValidationMessage(1081)
                            lblErrorMsg.Text = ""
                            lblR.Text = ""
                            lblG.Text = ""
                            GridView1.DataSource = dt

                            GridView1.DataBind()
                            
                            GridView1.Visible = True
                            GridView1.Enabled = True
                            ddlSemester.Items.Clear()
                            ddlSemester.DataSourceID = "ObjSemester"
                            ddlSemester.DataBind()
                            
                        Else
                            lblErrorMsg.Text = ValidationMessage(1082)
                            lblmsg.Text = ValidationMessage(1014)
                            lblR.Text = ValidationMessage(1014)
                            lblG.Text = ValidationMessage(1014)
                        End If

                    Else
                        lblErrorMsg.Text = ValidationMessage(1083)
                        lblmsg.Text = ValidationMessage(1014)
                        lblR.Text = ValidationMessage(1014)
                        lblG.Text = ValidationMessage(1014)
                    End If
                Else
                    lblErrorMsg.Text = ValidationMessage(1083)
                    lblmsg.Text = ValidationMessage(1014)
                    lblR.Text = ValidationMessage(1014)
                    lblG.Text = ValidationMessage(1014)
                End If
            End If
        Else
            lblErrorMsg.Text = ValidationMessage(1084)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    Protected Sub DdlBatchPlanner_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlBatchPlanner.SelectedIndexChanged
        'code for Auto Fill by nitin 18/03/2012
        lblR.Text = ValidationMessage(1014)
        lblG.Text = ValidationMessage(1014)
        btnAddDetails.Text = "ADD"
        
        Try
            lblErrorMsg.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            If DdlBatchPlanner.SelectedValue = "Select" Then
                txtAcademicYear.Text = ""
                txtcomplete.Text = ""
                TxtCourse.Text = ""
                txtGenerate.Text = ""
                Txtstartdate.Text = ""
                GridView1.Visible = False
            Else
                lblErrorMsg.Text = ValidationMessage(1014)
                v.Batch_No = DdlBatchPlanner.SelectedValue
                v.id = v.Batch_No
                ViewState("V") = v.Batch_No
                dt1 = bl.filltextbox(v)
                ViewState("crsid") = dt1.Rows(0).Item("Courseid")
                TxtCourse.Text = dt1.Rows(0).Item("CourseName")
                txtAcademicYear.Text = dt1.Rows(0).Item("AcademicYear")
                Txtstartdate.Text = Format(dt1.Rows(0).Item("StartDate"), "dd-MMM-yyyy")
                txtGenerate.Text = dt1.Rows(0).Item("Generate")
                txtcomplete.Text = dt1.Rows(0).Item("Completon_status")

                GridView1.Visible = False
            End If
        Catch ex As Exception
            lblErrorMsg.Text = ValidationMessage(1014)
        End Try
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        DdlBatchPlanner.Enabled = True
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
       
        v.Gid = 0
        display()
        GridView1.Visible = True
    End Sub

    Protected Sub GridView1_RowCancelingEdit(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCancelEditEventArgs) Handles GridView1.RowCancelingEdit
        GridView1.EditIndex = -1
        v.Gid = 0
        display()
    End Sub
    'code for Row Deleting by nitin
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        btnback.Visible = False
        DdlBatchPlanner.Enabled = True
        If (Session("BranchCode") = Session("ParentBranch")) Then
            bl.DeleteBatchPlanner(CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("Label5"), Label).Text)
            lblmsg.Text = ValidationMessage(1028)
            lblErrorMsg.Text = ValidationMessage(1014)
            lblR.Text = ValidationMessage(1014)
            lblG.Text = ValidationMessage(1014)
            DdlBatchPlanner.Focus()
            v.id = DdlBatchPlanner.SelectedValue
            v.Gid = 0
            v.Semester = ddlSemester.SelectedValue
            dt = bl.GetBatchPlannerView(v)
            GridView1.DataSource = dt
            GridView1.DataBind()
            
            GridView1.Visible = True
            GridView1.Enabled = True
            For Each Grid As GridViewRow In GridView1.Rows
                CType(Grid.FindControl("DdlLecture"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer"), Label).Text
                If CType(Grid.FindControl("LabelElec"), Label).Text = "Y" Then
                    CType(Grid.FindControl("ChkElective"), CheckBox).Checked = True
                Else
                    CType(Grid.FindControl("ChkElective"), CheckBox).Checked = False
                End If
            Next
        Else
            lblErrorMsg.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    'code for Row Edditing by nitin
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        DdlBatchPlanner.Enabled = False
        btnadd.Enabled = False
        btnview.Enabled = False
        btnDelete.Enabled = False
        BtnUpdate.Enabled = False
        btncomplete.Enabled = False
        btnback.Visible = True
       
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        v.id = DdlBatchPlanner.SelectedValue
        v.Gid = 0
        v.Semester = ddlSemester.SelectedValue
        dt = bl.GetBatchPlannerView(v)
        GridView1.DataSource = dt
        GridView1.DataBind()

        GridView1.Visible = True
        GridView1.Enabled = True
        
        For Each Grid As GridViewRow In GridView1.Rows
            CType(Grid.FindControl("DdlLecture"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer"), Label).Text
            If CType(Grid.FindControl("LabelElec"), Label).Text = "Y" Then
                CType(Grid.FindControl("ChkElective"), CheckBox).Checked = True
            Else
                CType(Grid.FindControl("ChkElective"), CheckBox).Checked = False
            End If
        Next
        ViewState("Gid") = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Label5"), Label).Text.Trim
        ViewState("id") = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Label7"), Label).Text.Trim
        ddlSubject.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("lblsubid"), Label).Text
        txtTheory.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("Lbltotalhours"), Label).Text.Trim
        ddlSemester.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("lblsemid"), Label).Text.Trim
        txtCredit.Text = CType(GridView1.Rows(e.NewEditIndex).Cells(1).FindControl("txtCredit"), Label).Text.Trim
        GridView1.Visible = True
        GridView1.Enabled = False

        btnAddDetails.Text = "UPDATE"
        
        lblErrorMsg.Text = ValidationMessage(1014)
        lblmsg.Text = ValidationMessage(1014)
        lblR.Text = ValidationMessage(1014)
        lblG.Text = ValidationMessage(1014)
        v.Gid = ViewState("Gid")
        v.id = DdlBatchPlanner.SelectedValue
        v.Semester = ddlSemester.SelectedValue
        dt = bl.GetBatchPlannerView(v)
        GridView1.DataSource = dt
        GridView1.DataBind()
        
        GridView1.Visible = True
        GridView1.Enabled = True
        For Each Grid As GridViewRow In GridView1.Rows
            CType(Grid.FindControl("DdlLecture"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer"), Label).Text
            If CType(Grid.FindControl("LabelElec"), Label).Text = "Y" Then
                CType(Grid.FindControl("ChkElective"), CheckBox).Checked = True
            Else
                CType(Grid.FindControl("ChkElective"), CheckBox).Checked = False
            End If
        Next
        GridView1.Enabled = False
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub
    'code for Complete Button by nitin
    Protected Sub btncomplete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btncomplete.Click
        btnback.Visible = False
        DdlBatchPlanner.Enabled = True
        DdlBatchPlanner.Focus()
        btnAddDetails.Text = "ADD"
        
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If DdlBatchPlanner.SelectedValue = "Select" Then
                lblErrorMsg.Text = ValidationMessage(1079)
            Else
                v.BatchID = DdlBatchPlanner.SelectedValue
                'v.BatchID = ViewState("D")
                If txtcomplete.Text <> "Y" Then
                    If bl.UpdateBatchPlanner(v) > 0 Then
                        txtcomplete.Text = "Y"
                        lblmsg.Text = ValidationMessage(1085)
                        lblErrorMsg.Text = ValidationMessage(1014)
                        lblR.Text = ValidationMessage(1014)
                        lblG.Text = ValidationMessage(1014)

                    Else
                        lblErrorMsg.Text = ValidationMessage(1086)
                        lblmsg.Text = ValidationMessage(1014)
                        lblR.Text = ValidationMessage(1014)
                        lblG.Text = ValidationMessage(1014)

                    End If
                Else
                    lblErrorMsg.Text = ValidationMessage(1087)
                    lblmsg.Text = ValidationMessage(1014)
                    lblR.Text = ValidationMessage(1014)
                    lblG.Text = ValidationMessage(1014)

                End If
            End If
        Else
            lblErrorMsg.Text = ValidationMessage(1088)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub
    'code for delete button by nitin 18/03/2012
    Protected Sub btnDelete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        btnback.Visible = False
        DdlBatchPlanner.Focus()
        DdlBatchPlanner.Enabled = True
        btnAddDetails.Text = "ADD"
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
               
                If txtGenerate.Text = "N" Then
                    lblErrorMsg.Text = ValidationMessage(1080)
                    lblmsg.Text = ValidationMessage(1014)
                    Exit Sub
                End If
                If GridView1.Enabled = False Then
                    lblErrorMsg.Text = "Please Unlock the Records"
                    lblmsg.Text = ""
                    lblG.Text = ""
                    lblmsg.Text = ""
                    Exit Sub
                End If
                bl.DeleteBatchPlanner1(DdlBatchPlanner.SelectedValue)
                If txtGenerate.Text = "Y" Then
                    txtGenerate.Text = "N"
                End If
                v.Gid = 0
                display()
                lblmsg.Text = ValidationMessage(1089)
                lblErrorMsg.Text = ValidationMessage(1014)
                lblR.Text = ValidationMessage(1014)
                lblG.Text = ValidationMessage(1014)
                DdlBatchPlanner.Focus()
                lblErrorMsg.Text = ValidationMessage(1014)
            Catch ex As Exception
                lblErrorMsg.Text = ValidationMessage(1090)
                lblmsg.Text = ValidationMessage(1014)
                lblR.Text = ValidationMessage(1014)
                lblG.Text = ValidationMessage(1014)
            End Try
        Else
            lblErrorMsg.Text = ValidationMessage(1091)
            lblmsg.Text = ValidationMessage(1014)
        End If


    End Sub
    'code for Display Method by nitin 05/03/2012
    Sub display()
        Dim dt As New DataTable
        v.id = DdlBatchPlanner.SelectedValue
        v.Semester = ddlSemester.SelectedValue
        dt = bl.GetBatchPlannerView(v)
        If dt.Rows.Count <> 0 Then
            GridView1.DataSource = dt
            GridView1.DataBind()
            
            GridView1.Visible = True
            GridView1.Enabled = True
        Else
           
            lblmsg.Visible = True
            lblErrorMsg.Text = ValidationMessage(1023)
            lblmsg.Text = ValidationMessage(1014)
            lblR.Text = ValidationMessage(1014)
            lblG.Text = ValidationMessage(1014)
            GridView1.Visible = False
        End If
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewUpdateEventArgs) Handles GridView1.RowUpdating
        Try


            btnback.Visible = False
            DdlBatchPlanner.Focus()
            DdlBatchPlanner.Enabled = True
            btnAddDetails.Text = "ADD"
            If (Session("BranchCode") = Session("ParentBranch")) Then

                'code for Update Button by nitin 06/03/2012
                v.Batch_No = DdlBatchPlanner.SelectedValue
                ViewState("V") = CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("LabLrecturer"), Label).Text
                ViewState("S") = (CType(GridView1.Rows(e.RowIndex).Cells(1).FindControl("Label5"), Label).Text)
                v.id = ViewState("S")
                ViewState("v.Lecturer") = CType(GridView1.Rows(e.RowIndex).Cells(6).FindControl("DdlLecture"), DropDownList).SelectedItem.Value
                v.Lecturer = ViewState("v.Lecturer")
                v.Sequence = CType(GridView1.FindControl("txtSequence"), TextBox).Text
                v.Credit = CType(GridView1.FindControl("txtCredit"), TextBox).Text
                If CType(GridView1.FindControl("ChkElective"), CheckBox).Checked = True Then
                    v.Elective_Status = "Y"
                Else
                    v.Elective_Status = "N"
                End If
                v.Sequence = ViewState("v.Sequence")
                v.Credit = ViewState("v.Credit")
                Dim dt As New Integer
                dt = bl.GetEmpUpdate(v)
                lblmsg.Text = ValidationMessage(1017)
                lblErrorMsg.Text = ValidationMessage(1014)
                lblR.Text = ValidationMessage(1014)
                lblG.Text = ValidationMessage(1014)
                GridView1.Visible = True
            Else
                lblErrorMsg.Text = ValidationMessage(1021)
                lblmsg.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1014)
            lblErrorMsg.Text = ValidationMessage(1022)
        End Try
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'code for Update Button by nitin 06/03/2012
    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try


            btnback.Visible = False
            DdlBatchPlanner.Enabled = True
            btnAddDetails.Text = "ADD"
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If txtGenerate.Text = "N" Then
                    lblErrorMsg.Text = ValidationMessage(1080)
                    lblmsg.Text = ValidationMessage(1014)
                    Exit Sub
                End If
                For Each grid As GridViewRow In GridView1.Rows
                    v.id = CType(grid.FindControl("Label5"), Label).Text
                    v.Lecturer = CType(grid.FindControl("DdlLecture"), DropDownList).SelectedItem.Value
                    If CType(grid.FindControl("txtSequence"), TextBox).Text = "" Then
                        v.Sequence = 0
                    Else
                        v.Sequence = CType(grid.FindControl("txtSequence"), TextBox).Text
                    End If
                    If CType(grid.FindControl("ChkElective"), CheckBox).Checked = True Then
                        v.Elective_Status = "Y"
                    Else
                        v.Elective_Status = "N"
                    End If
                    bl.GetEmpUpdate(v)
                    lblmsg.Text = ValidationMessage(1017)
                    lblErrorMsg.Text = ValidationMessage(1014)
                    lblR.Text = ValidationMessage(1014)
                    lblG.Text = ValidationMessage(1014)
                Next
            Else
                lblErrorMsg.Text = ValidationMessage(1021)
                lblmsg.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1014)
            lblErrorMsg.Text = ValidationMessage(1022)
        End Try
    End Sub

    Protected Sub DdlBatchPlanner_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DdlBatchPlanner.TextChanged
        DdlBatchPlanner.Focus()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DdlBatchPlanner.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
            btnback.Visible = False
        End If
        If Not Page.IsPostBack Then
            
        End If
        'Dim Config As String
        'dt2 = DLBatchPlanner.getBatchPlannerAceess()
        'If dt2.Rows.Count > 0 Then
        '    Config = dt2.Rows(0)("Config_Value").ToString
        '    ViewState("Config_Value") = Config
        'Else

        'End If
        

    End Sub

    Protected Sub btnAddDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddDetails.Click
        Try


            DdlBatchPlanner.Enabled = True
            If (Session("BranchCode") = Session("ParentBranch")) Then
                If DdlBatchPlanner.SelectedValue = "Select" Then
                    lblR.Text = ValidationMessage(1092)
                    lblG.Text = ValidationMessage(1014)
                Else

                    If btnAddDetails.Text = "ADD" Then
                        If GridView1.Enabled = False Then
                            lblErrorMsg.Text = "Please Unlock the Records"
                            lblmsg.Text = ""
                            lblG.Text = ""
                            lblmsg.Text = ""
                            Exit Sub
                        End If
                        If txtGenerate.Text = "Y" Then
                            Dim dt1 As DataTable
                            v.BatchID = DdlBatchPlanner.SelectedValue
                            v.Subject = ddlSubject.SelectedValue
                            v.Course = TxtCourse.Text
                            If txtTheory.Text = "" Then
                                v.TotalHours = 0
                            Else
                                v.TotalHours = txtTheory.Text
                            End If

                            v.Semester = ddlSemester.SelectedValue
                            v.Course = ViewState("crsid")
                            v.Sequence = ViewState("Sequence")
                            If txtCredit.Text = "" Then
                                v.Credit = 0
                            Else
                                v.Credit = txtCredit.Text
                            End If
                            dt1 = DLBatchPlanner.DuplicateBatchPlanner(v)
                            If dt1.Rows.Count > 0 Then
                                lblR.Text = ValidationMessage(1030)
                                lblG.Text = ValidationMessage(1014)
                            Else

                                DLBatchPlanner.InsertBatchPlanner(v)
                                lblG.Text = ValidationMessage(1093)
                                txtTheory.Text = ""
                                lblR.Text = ValidationMessage(1014)
                                lblErrorMsg.Text = ValidationMessage(1014)
                                lblmsg.Text = ValidationMessage(1014)
                                txtCredit.Text = ""

                                If txtGenerate.Text = "Y" Then
                                    v.id = DdlBatchPlanner.SelectedValue
                                    v.Semester = ddlSemester.SelectedValue
                                    dt = bl.GetBatchPlannerView(v)
                                    GridView1.DataSource = dt
                                    GridView1.DataBind()
                                    
                                    GridView1.Visible = True
                                    GridView1.Enabled = True
                                    For Each Grid As GridViewRow In GridView1.Rows
                                        CType(Grid.FindControl("DdlLecture"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer"), Label).Text
                                        If CType(Grid.FindControl("LabelElec"), Label).Text = "Y" Then
                                            CType(Grid.FindControl("ChkElective"), CheckBox).Checked = True
                                        Else
                                            CType(Grid.FindControl("ChkElective"), CheckBox).Checked = False
                                        End If
                                    Next
                                Else
                                    lblErrorMsg.Text = ValidationMessage(1080)
                                    lblR.Text = ValidationMessage(1014)
                                    lblG.Text = ValidationMessage(1014)
                                    lblmsg.Text = ValidationMessage(1014)
                                End If
                            End If
                        Else
                            lblErrorMsg.Text = ValidationMessage(1080)
                            lblR.Text = ValidationMessage(1014)
                            lblG.Text = ValidationMessage(1014)
                            lblmsg.Text = ValidationMessage(1014)
                        End If


                    Else
                        If ddlSubject.SelectedValue = 0 Then
                            lblR.Text = ValidationMessage(1094)
                            ddlSubject.Focus()
                            lblG.Text = ValidationMessage(1014)
                        ElseIf ddlSemester.SelectedValue = 0 Then
                            lblR.Text = ValidationMessage(1095)
                            ddlSemester.Focus()
                            lblG.Text = ValidationMessage(1014)
                        Else

                            v.id = ViewState("Gid")
                            v.Subject = ddlSubject.SelectedValue
                            If txtTheory.Text = "" Then
                                v.TotalHours = 0
                            Else
                                v.TotalHours = txtTheory.Text
                            End If
                            If txtCredit.Text = "" Then
                                v.Credit = 0
                            Else
                                v.Credit = txtCredit.Text
                            End If
                            v.Semester = ddlSemester.SelectedValue
                            If dt1.Rows.Count > 0 Then
                                lblR.Text = ValidationMessage(1030)
                                lblG.Text = ValidationMessage(1014)
                            Else
                                btnadd.Enabled = True
                                btnview.Enabled = True
                                btnDelete.Enabled = True
                                BtnUpdate.Enabled = True
                                btncomplete.Enabled = True
                                DLBatchPlanner.Updatebatchplannergrid(v)
                                lblR.Text = ValidationMessage(1014)
                                lblG.Text = ValidationMessage(1017)
                                txtTheory.Text = ""
                                lblErrorMsg.Text = ValidationMessage(1014)
                                lblmsg.Text = ValidationMessage(1014)
                                btnback.Visible = False
                                btnAddDetails.Text = "ADD"
                                txtCredit.Text = ""

                                GridView1.PageIndex = ViewState("PageIndex")
                                v.Gid = 0
                                v.id = DdlBatchPlanner.SelectedValue
                                v.Semester = ddlSemester.SelectedValue
                                dt = bl.GetBatchPlannerView(v)
                                GridView1.DataSource = dt
                                GridView1.DataBind()
                                
                                GridView1.Visible = True
                                GridView1.Enabled = True
                                For Each Grid As GridViewRow In GridView1.Rows
                                    CType(Grid.FindControl("DdlLecture"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer"), Label).Text
                                    If CType(Grid.FindControl("LabelElec"), Label).Text = "Y" Then
                                        CType(Grid.FindControl("ChkElective"), CheckBox).Checked = True
                                    Else
                                        CType(Grid.FindControl("ChkElective"), CheckBox).Checked = False
                                    End If
                                Next
                                GridView1.Enabled = True

                            End If
                        End If
                    End If
                End If
            Else
                lblErrorMsg.Text = ValidationMessage(1021)
                lblmsg.Text = ValidationMessage(1014)
            End If
        Catch ex As Exception
            lblmsg.Text = ValidationMessage(1014)
            lblErrorMsg.Text = ValidationMessage(1022)
        End Try

    End Sub

    Protected Sub btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnback.Click
        DdlBatchPlanner.Enabled = True
        btnadd.Enabled = True
        btnview.Enabled = True
        btnDelete.Enabled = True
        BtnUpdate.Enabled = True
        btncomplete.Enabled = True
        btnAddDetails.Text = "ADD"
        txtTheory.Text = ""
        txtCredit.Text = ""
        lblErrorMsg.Text = ValidationMessage(1014)
        lblmsg.Text = ValidationMessage(1014)
        lblR.Text = ValidationMessage(1014)
        lblG.Text = ValidationMessage(1014)
        GridView1.PageIndex = ViewState("PageIndex")
        v.Gid = 0
        v.id = DdlBatchPlanner.SelectedValue
        v.Semester = ddlSemester.SelectedValue
        dt = bl.GetBatchPlannerView(v)
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
        
        For Each Grid As GridViewRow In GridView1.Rows
            CType(Grid.FindControl("DdlLecture"), DropDownList).SelectedValue = CType(Grid.FindControl("LabLrecturer"), Label).Text
            If CType(Grid.FindControl("LabelElec"), Label).Text = "Y" Then
                CType(Grid.FindControl("ChkElective"), CheckBox).Checked = True
            Else
                CType(Grid.FindControl("ChkElective"), CheckBox).Checked = False
            End If
        Next
        
        GridView1.Enabled = True
        btnback.Visible = False
        'btnAddDetails.CommandName = "ADD"
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
        v.id = DdlBatchPlanner.SelectedValue
        v.Gid = 0
        v.Semester = 0
        dt = bl.GetBatchPlannerView(v)
        GridView1.DataSource = dt
        GridView1.DataBind()
        
        GridView1.Enabled = True
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
    Sub CheckAll()
        If CType(GridView1.HeaderRow.FindControl("ChkAll"), CheckBox).Checked = True Then
            v.BatchID = DdlBatchPlanner.SelectedValue
            v.Course = TxtCourse.Text
            v.AcademicYear = txtAcademicYear.Text
            v.Elective_Status = "Y"
            bl.UpdateCollectionVerification(v)
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkElective"), CheckBox).Checked = True
            Next
        Else
            v.BatchID = DdlBatchPlanner.SelectedValue
            v.Course = TxtCourse.Text
            v.AcademicYear = txtAcademicYear.Text
            v.Elective_Status = "N"
            bl.UpdateCollectionVerification(v)
            For Each grid As GridViewRow In GridView1.Rows
                CType(grid.FindControl("ChkElective"), CheckBox).Checked = False
            Next
        End If
    End Sub
    'Code written fro multilingual by Niraj on 15 oct 2013
    ''Retriving the text of controls based on Language

    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        Try
            dt2 = Session("ValidationTable")
            If dt2 Is Nothing Then
                Response.Redirect("LogIn.aspx")
            End If
            Dim X As Integer = dt2.Rows.Count() - 1
            Dim str As String = " "
            For i As Integer = 0 To X
                If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                    Return dt2.Rows(i).Item("MessageText").ToString()
                End If
            Next
        Catch ex As Exception
            Response.Redirect("login.aspx")
        End Try
        Return 0
    End Function
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub

    Protected Sub btnPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim check As String
            If txtPassword.Text = Session("Password") Then
                v.BatchID = DdlBatchPlanner.SelectedValue
                If bl.CheckLockBatchPl(v).Tables(0).Rows(0).Item(0) = "N" Then
                    Dim roweffected As Integer = bl.CheckLockBatchPln(v)
                    If roweffected > 0 Then
                        panel123.Visible = True
                        PasswordPanel.Visible = False
                        panel1.Visible = True
                        lblR.Text = ValidationMessage(1014)
                        lblG.Text = ValidationMessage(1014)
                        lblmsg.Text = ""

                        lblG.Text = roweffected.ToString + ValidationMessage(1103)
                        GridView1.Enabled = False
                        Image1.Visible = True
                        Image2.Visible = True
                    End If
                Else
                    Dim Config As String
                    dt2 = DLBatchPlanner.getBatchPlannerAceess()
                    If dt2.Rows.Count = 0 Then
                        Dim role As String
                        role = Session("UserRole")
                        If Session("SecurityCheck") = "Security Check" Then
                            dt = DLBatchPlanner.PostCheck(role)
                            If dt.Rows.Count < 1 Then
                                lblR.Text = ValidationMessage(1102)
                                lblG.Text = ValidationMessage(1014)
                                panel123.Visible = True
                                PasswordPanel.Visible = False
                                panel1.Visible = True
                                GridView1.Enabled = False
                                Image1.Visible = True
                                Image2.Visible = True
                            Else
                                check = dt.Rows(0)("Result").ToString.Trim

                                'check = dt.Rows(0)("Result").ToString.Trim
                                If check = "" Then
                                    lblR.Text = ValidationMessage(1102)
                                    lblG.Text = ValidationMessage(1014)
                                    panel123.Visible = True
                                    PasswordPanel.Visible = False
                                    GridView1.Enabled = False
                                    Image1.Visible = True
                                    Image2.Visible = True
                                Else
                                    Dim roweffected As Integer = bl.UNLockBatchPl(v)
                                    If roweffected > 0 Then
                                        panel123.Visible = True
                                        panel1.Visible = True
                                        PasswordPanel.Visible = False
                                        lblR.Text = ValidationMessage(1014)
                                        lblG.Text = ValidationMessage(1014)
                                        lblmsg.Text = ""
                                        lblG.Text = roweffected.ToString + ValidationMessage(1104)
                                        GridView1.Enabled = True
                                        Image1.Visible = True
                                        Image2.Visible = True
                                    End If
                                End If
                            End If
                        End If
                    Else

                        Dim roweffected As Integer = bl.UNLockBatchPl(v)
                        If roweffected > 0 Then
                            panel123.Visible = True
                            panel1.Visible = True
                            PasswordPanel.Visible = False
                            lblR.Text = ValidationMessage(1014)
                            lblG.Text = ValidationMessage(1014)
                            lblmsg.Text = ""
                            lblG.Text = roweffected.ToString + ValidationMessage(1104)
                            GridView1.Enabled = True
                            Image1.Visible = True
                            Image2.Visible = True
                        End If
                    End If
                End If

            ElseIf txtPassword.Text = "" Or txtPassword.Text <> Session("Password") Then
                panel123.Visible = True
                panel1.Visible = True
                PasswordPanel.Visible = False
                lblmsg.Text = ""
                lblR.Text = ValidationMessage(1106)
                Image1.Visible = True
                Image2.Visible = True
                lblG.Text = ValidationMessage(1014)

            End If
        Else
                    lblR.Text = ValidationMessage(1029)
                    lblG.Text = ValidationMessage(1014)
        End If
        btnlock.Focus()
    End Sub

    Protected Sub btnlock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnlock.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try

                v.id = DdlBatchPlanner.SelectedValue
                dt = bl.GetBatchPlannerView(v)

                If dt.Rows(0).Item("Del_Flag") = "G" Then
                    lblR.Text = ValidationMessage(1030)
                    lblG.Text = ValidationMessage(1014)
                    Exit Sub
                End If

                GridView1.DataSource = dt
                GridView1.DataBind()
                If dt.Rows.Count > 0 Then
                    lblR.Text = ValidationMessage(1014)
                    lblG.Text = ValidationMessage(1014)
                    lblErrorMsg.Text = ""
                    panel123.Visible = False
                    panel1.Visible = False

                    PasswordPanel.Visible = True
                    txtPassword.Focus()
                    lblpassError.Text = ValidationMessage(1014)
                    Image1.Visible = False
                    Image2.Visible = False
                Else
                    lblR.Text = ValidationMessage(1014)
                    lblG.Text = ValidationMessage(1014)
                    lblR.Text = ValidationMessage(1105)
                    lblErrorMsg.Text = ""
                    GridView1.Visible = False
                End If
              
            Catch ex As Exception

                lblR.Text = ValidationMessage(1047)
                lblErrorMsg.Text = ""
                GridView1.Visible = False
                'ddlA_Year.Focus()
                Image1.Visible = True
                Image2.Visible = True
            End Try
        Else
            lblR.Text = ValidationMessage(1101)
            lblG.Text = ValidationMessage(1014)
            lblErrorMsg.Text = ""
        End If
    End Sub
End Class
