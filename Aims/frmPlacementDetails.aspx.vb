Partial Class frmPlacementDetails
    Inherits BasePage
    Dim BLL As New PlacementB
    Dim ELL As New PlacementDetails
    Dim GlobalFunction As New GlobalFunction
    Dim cs, bt, stcd As String
    Sub SplitName(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("StdCode") = parts(0).ToString()
            txtStdCode.Text = parts(0).ToString()
            txtName.Text = parts(1).ToString()
            HidstdId.Value = parts(2).ToString()
            'ViewState("StdID") = StdID
        Else
            txtStdCode.AutoPostBack = True
        End If
    End Sub
    Sub SplitName1(ByVal s As String)
        Dim parts As String() = s.Split(New Char() {":"})
        If parts.Length > 1 Then
            ViewState("EmpCode") = parts(0).ToString()
            txtfaculty.Text = parts(0).ToString()
            txtfaculty.Text = parts(1).ToString()
            HidFaculty.Value = parts(2).ToString()
            'ViewState("EmpID") = EmpID
        Else
            txtfaculty.AutoPostBack = True
        End If
    End Sub
    Protected Sub btnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        txtStdCode.Focus()
        If btnDetails.Text = "BACK" Then
            lblmsg.Text = ""
            msginfo.Text = ""
            GridView1.PageIndex = ViewState("PageIndex")
            display()
            clearall()
            GridView1.Visible = True
            btnAdd.Text = "ADD"
            btnDetails.Text = "VIEW"
        Else
            lblmsg.Text = ""
            msginfo.Text = ""
            txtStdCode.Text = ""
            txtName.Text = ""
            ddlcompname.SelectedValue = 0
            txtSalary.Text = ""
            txtstipend.Text = ""
            txtplacementdate.Text = ""
            txtSdate.Text = ""
            txtEnddate.Text = ""
            txtDesignation.Text = ""
            txtfaculty.Text = ""
            txtcontactperson.Text = ""
            txtremarks.Text = ""
            GridView1.Visible = True
            'Disable()
            ViewState("PageIndex") = 0
            GridView1.PageIndex = 0
            display()
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        txtStdCode.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If btnAdd.Text = "UPDATE" Then
                    If RbPlacement.SelectedValue <> "Placement" Then
                        If CType(txtSdate.Text, Date) > CType(txtEnddate.Text, Date) Then
                            lblmsg.Text = ""
                            msginfo.Text = "Start Date should not be Greater than End Date."
                            txtSdate.Focus()
                            Exit Sub
                        End If
                    End If

                    ELL.studid = ViewState("id2")
                    'ELL.studCode = HidstdId.Value
                    ELL.PlacementId = ViewState("id1")
                    ELL.trainingplacement = RbPlacement.SelectedValue
                    ELL.studname = txtName.Text
                    'ELL.studCode = txtStdCode.Text
                    ELL.CompName = ddlcompname.SelectedValue
                    If ELL.trainingplacement = "Placement" Then
                        If txtSalary.Text = "" Then
                            ELL.Salary = 0
                        Else
                            ELL.Salary = txtSalary.Text
                        End If
                        If txtplacementdate.Text = "" Then
                            ELL.PlacementDate = "01/01/9100"
                        ElseIf txtplacementdate.Text.Length < 11 Then
                            msginfo.Text = "Placement Date Must be Minimum of 11 Characters. "
                            lblmsg.Text = ""
                            Exit Sub
                        Else
                            ELL.PlacementDate = txtplacementdate.Text
                        End If
                        If txtEnddate.Text = "" Then
                            ELL.EndDate = "01/01/9100"
                        Else
                            ELL.EndDate = txtEnddate.Text
                        End If
                    Else
                        If txtEnddate.Text = "" Then
                            msginfo.Text = "End Date Field is Mandatory."
                            txtEnddate.Focus()
                        ElseIf txtSdate.Text = "" Then
                            msginfo.Text = "Start Date Field is Mandatory."
                            txtSdate.Focus()
                        End If


                        If txtstipend.Text = "" Then
                            ELL.Salary = 0
                        Else
                            ELL.Salary = txtstipend.Text
                        End If
                        ELL.PlacementDate = txtSdate.Text
                    End If
                    ELL.Designation = txtDesignation.Text
                    ELL.Remark = txtremarks.Text
                    If txtEnddate.Text = "" Then
                        ELL.EndDate = "01/01/9100"
                    Else
                        ELL.EndDate = txtEnddate.Text
                    End If
                    ELL.Faculty_Incharge = HidFaculty.Value
                    ELL.Contact_Person = txtcontactperson.Text
                    BLL.UpdateRecord(ELL)
                    msginfo.Text = ""
                    lblmsg.Text = "Data Updated Successfully."
                    GridView1.PageIndex = ViewState("PageIndex")
                    display()
                    clearall()
                    btnAdd.Text = "ADD"
                    btnDetails.Text = "VIEW"
                Else
                    If RbPlacement.SelectedValue <> "Placement" Then
                        If txtSdate.Text = "" Then
                            msginfo.Text = "Start Date field is mandatory."
                            txtSdate.Focus()
                        ElseIf txtEnddate.Text = "" Then
                            msginfo.Text = "End Date field is mandatory."
                            txtEnddate.Focus()
                        Else
                            If CType(txtSdate.Text, Date) > CType(txtEnddate.Text, Date) Then
                                lblmsg.Text = ""
                                msginfo.Text = "Start Date should not be Greater than End Date."
                                txtSdate.Focus()
                                Exit Sub
                            End If
                        End If
                    End If

                    ELL.trainingplacement = RbPlacement.SelectedValue
                    If ELL.trainingplacement = "Placement" Then
                        ELL.studCode = HidstdId.Value
                        ELL.CompName = ddlcompname.SelectedValue
                        Dim dt As New DataTable

                        dt = PlacementB.CheckDuplicate(ELL)
                        If dt.Rows.Count > 0 Then
                            msginfo.Text = "Data already Exists."
                            lblmsg.Text = ""

                        Else
                            If txtSalary.Text = "" Then
                                ELL.Salary = 0
                            Else
                                ELL.Salary = txtSalary.Text
                            End If
                            If txtplacementdate.Text = "" Then
                                ELL.PlacementDate = "01/01/9100"
                            ElseIf txtplacementdate.Text.Length < 11 Then
                                msginfo.Text = "Placement Date Must be Minimum of 11 Characters. "
                                lblmsg.Text = ""
                                Exit Sub
                            Else
                                ELL.PlacementDate = txtplacementdate.Text
                            End If
                            ELL.EndDate = "01/01/9100"
                            ELL.Designation = txtDesignation.Text
                            ELL.Remark = txtremarks.Text
                            'ELL.Faculty_Incharge = txtfaculty.Text
                            ELL.Faculty_Incharge = HidFaculty.Value
                            ELL.Contact_Person = txtcontactperson.Text
                            BLL.InsertRecord(ELL)
                            msginfo.Text = ""
                            lblmsg.Text = "Data saved Successfully."
                            ViewState("PageIndex") = 0
                            GridView1.PageIndex = 0

                            display()
                            GridView1.Visible = True
                            GridView1.Enabled = True
                            clearall()
                        End If
                    ElseIf ELL.trainingplacement = "Training" Then
                        ELL.studCode = HidstdId.Value
                        ELL.CompName = ddlcompname.SelectedValue
                        Dim dt As New DataTable

                        dt = PlacementB.CheckDuplicate(ELL)
                        If dt.Rows.Count > 0 Then
                            msginfo.Text = "Data already Exists."
                            lblmsg.Text = ""

                        Else
                            If txtSdate.Text = "" Or IsDate(txtSdate.Text) = False Then
                                msginfo.Text = "Start Date Field is Mandatory."
                                txtSdate.Focus()
                            ElseIf txtEnddate.Text = "" Or IsDate(txtEnddate.Text) = False Then
                                msginfo.Text = "End Date Field is Mandatory."
                                txtEnddate.Focus()
                            Else
                                If txtstipend.Text = "" Then
                                    ELL.Salary = 0
                                Else
                                    ELL.Salary = txtstipend.Text
                                End If

                                ELL.PlacementDate = txtSdate.Text
                                ELL.EndDate = txtEnddate.Text
                                ELL.Designation = txtDesignation.Text
                                ELL.Remark = txtremarks.Text
                                'ELL.Faculty_Incharge = txtfaculty.Text
                                ELL.Faculty_Incharge = HidFaculty.Value
                                ELL.Contact_Person = txtcontactperson.Text
                                BLL.InsertRecord(ELL)

                                msginfo.Text = ""
                                lblmsg.Text = "Data saved Successfully."
                                ViewState("PageIndex") = 0
                                GridView1.PageIndex = 0

                                display()
                                GridView1.Visible = True
                                GridView1.Enabled = True
                                clearall()
                            End If
                        End If

                    End If
                End If
            Catch ex As Exception
                msginfo.Text = "Enter correct data."
                lblmsg.Text = ""
            End Try
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If

    End Sub
    Protected Sub GridView1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim bl As New PlacementB
            Dim a As Integer
            a = Convert.ToInt64(GridView1.DataKeys(e.RowIndex).Value)
            bl.ChangeFlag(a)
            GridView1.PageIndex = ViewState("PageIndex")

            lblmsg.Text = "Data Deleted Successfully."
            txtStdCode.Focus()
            msginfo.Text = ""
            Dim dt As New DataTable
            ELL.trainingplacement = RbPlacement.SelectedValue
            ELL.PlacementId = ViewState("Placement_ID")
            dt = BLL.GetPlacementdetailsbyradio(ELL)
            GridView1.Columns(5).Visible = True
            GridView1.Columns(6).Visible = True
            GridView1.Columns(10).Visible = True
            GridView1.Columns(9).Visible = True
            GridView1.Columns(7).Visible = True
            GridView1.Columns(8).Visible = True
            If RbPlacement.SelectedValue = "Placement" Then
                GridView1.Columns(6).Visible = False
                GridView1.Columns(7).Visible = False
                GridView1.Columns(10).Visible = False
                GridView1.Columns(9).Visible = False
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Visible = True
                GridView1.Enabled = True
                For Each rows As GridViewRow In GridView1.Rows
                    If CType(rows.FindControl("Label4"), Label).Text = "01-Jan-9100" Then
                        CType(rows.FindControl("Label4"), Label).Text = ""
                    End If
                Next
            Else
                GridView1.Columns(5).Visible = False
                GridView1.Columns(8).Visible = False
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Visible = True
                GridView1.Enabled = True
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GridView1.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        msginfo.Text = ""
        lblmsg.Text = ""
        Dim iid As String = RbPlacement.SelectedValue
        Dim dt As New DataTable
        If iid = "Placement" Then

            ViewState("id2") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HidstdId"), HiddenField).Value
            ViewState("id1") = CType(GridView1.Rows(e.NewEditIndex).FindControl("hidplacement"), HiddenField).Value
            txtStdCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
            txtName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblname"), Label).Text
            ddlcompname.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Hidcomp"), HiddenField).Value
            txtplacementdate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
            txtSalary.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblsalary"), Label).Text
            txtDesignation.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lbldesignation"), Label).Text
            txtremarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
            ELL.studid = ViewState("id2")
       

        Else
            ViewState("id2") = CType(GridView1.Rows(e.NewEditIndex).FindControl("HidstdId"), HiddenField).Value
            ViewState("id1") = CType(GridView1.Rows(e.NewEditIndex).FindControl("hidplacement"), HiddenField).Value
            txtStdCode.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
            txtName.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblname"), Label).Text
            ddlcompname.SelectedValue = CType(GridView1.Rows(e.NewEditIndex).FindControl("Hidcomp"), HiddenField).Value
            txtstipend.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblsalary"), Label).Text
            txtremarks.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
            txtSdate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("Lblstartdate"), Label).Text
            txtEnddate.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblenddate"), Label).Text
            txtcontactperson.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblcontactperson"), Label).Text
            txtfaculty.Text = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblfacultyincharge"), Label).Text
            ViewState("FacultyID") = CType(GridView1.Rows(e.NewEditIndex).FindControl("lblFacultyID"), Label).Text
            ELL.Faculty_Incharge = ViewState("FacultyID")
            ELL.studid = ViewState("id2")
          
        End If
        btnAdd.Text = "UPDATE"
        btnDetails.Text = "BACK"
        ELL.PlacementId = ViewState("id1")
        ELL.trainingplacement = RbPlacement.SelectedValue
        dt = BLL.GetPlacementdetailsbyradio(ELL)
        
        GridView1.DataSource = dt
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = False
        For Each rows As GridViewRow In GridView1.Rows
            If CType(rows.FindControl("Label4"), Label).Text = "01-Jan-9100" Then
                CType(rows.FindControl("Label4"), Label).Text = ""
            End If
        Next
        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            RbPlacement.Focus()
            GridView1.Visible = False
        End If
        If txtStdCode.Text <> "" Then
            SplitName(txtStdCode.Text)
        Else
            txtStdCode.AutoPostBack = True
            txtName.Text = ""
            SplitName(txtStdCode.Text)
        End If
        If txtfaculty.Text <> "" Then
            SplitName1(txtfaculty.Text)
        Else
            txtfaculty.AutoPostBack = True
            'txtEmpName.Text = ""
            SplitName1(txtfaculty.Text)
        End If
    End Sub

    Protected Sub Page_PreInit(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreInit
        MyBase.ValidateFormView("Placement Details")
    End Sub
    Protected Sub RadioButtonList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPlacement.SelectedIndexChanged
        If RbPlacement.SelectedValue = "Placement" Then
            txtStdCode.Focus()
            lblmsg.Text = ""
            msginfo.Text = ""
            GridView1.Visible = False
            lblsalary.Visible = True
            txtSalary.Visible = True
            lbldate.Visible = True
            txtplacementdate.Visible = True
            lbldesignation.Visible = True
            txtDesignation.Visible = True
            lblstipend.Visible = False
            txtstipend.Visible = False
            lblSdate.Visible = False
            txtSdate.Visible = False
            lblenddate.Visible = False
            txtEnddate.Visible = False
            lblfaculty.Visible = False
            txtfaculty.Visible = False
            lblcontactperson.Visible = False
            txtcontactperson.Visible = False
            btnAdd.Text = "ADD"
            btnDetails.Text = "VIEW"
        Else
            txtStdCode.Focus()
            lblmsg.Text = ""
            msginfo.Text = ""
            GridView1.Visible = False
            lblsalary.Visible = False
            txtSalary.Visible = False
            lbldate.Visible = False
            txtplacementdate.Visible = False
            lbldesignation.Visible = False
            txtDesignation.Visible = False
            lblstipend.Visible = True
            txtstipend.Visible = True
            lblSdate.Visible = True
            txtSdate.Visible = True
            lblenddate.Visible = True
            txtEnddate.Visible = True
            lblfaculty.Visible = True
            txtfaculty.Visible = True
            lblcontactperson.Visible = True
            txtcontactperson.Visible = True
            btnAdd.Text = "ADD"
            btnDetails.Text = "VIEW"
        End If
    End Sub
    Sub AlertEnterAllFields(ByVal str As String)
        lblmsg.Text = str
    End Sub
    Sub clearall()
        txtStdCode.Text = ""
        txtName.Text = ""
        txtremarks.Text = ""
        txtplacementdate.Text = ""
        txtDesignation.Text = ""
        txtEnddate.Text = ""
        txtfaculty.Text = ""
        txtSalary.Text = ""
        txtcontactperson.Text = ""
        txtstipend.Text = ""
        txtSdate.Text = ""
        'ddlcompname.SelectedValue = 0
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Public Sub display()
        LinkButton1.Focus()
        Dim dt As New DataTable
        ELL.trainingplacement = RbPlacement.SelectedValue
        ELL.PlacementId = ViewState("Placement_ID")
        dt = BLL.GetPlacementdetailsbyradio(ELL)
        GridView1.Columns(5).Visible = True
        GridView1.Columns(6).Visible = True
        GridView1.Columns(10).Visible = True
        GridView1.Columns(9).Visible = True
        GridView1.Columns(7).Visible = True
        GridView1.Columns(8).Visible = True
        If RbPlacement.SelectedValue = "Placement" Then
            If dt.Rows.Count > 0 Then
                GridView1.Columns(6).Visible = False
                GridView1.Columns(7).Visible = False
                GridView1.Columns(10).Visible = False
                GridView1.Columns(9).Visible = False
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Visible = True
                GridView1.Enabled = True
                For Each rows As GridViewRow In GridView1.Rows
                    If CType(rows.FindControl("Label4"), Label).Text = "01-Jan-9100" Then
                        CType(rows.FindControl("Label4"), Label).Text = ""
                    End If
                Next
            Else
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                msginfo.Text = "No records to display."
                lblmsg.Text = ""
            End If
        Else
            If dt.Rows.Count = 0 Then
                GridView1.Columns(5).Visible = False
                GridView1.Columns(8).Visible = False
                GridView1.DataSource = Nothing
                GridView1.DataBind()
                msginfo.Text = "No records to display."
                lblmsg.Text = ""
            Else
                GridView1.Columns(5).Visible = False
                GridView1.Columns(8).Visible = False
                GridView1.DataSource = dt
                GridView1.DataBind()
                GridView1.Visible = True
                GridView1.Enabled = True
            End If
        End If
    End Sub
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        GridView1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GridView1.PageIndex
        display()
    End Sub

    Protected Sub ddlcompname_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcompname.TextChanged
        ddlcompname.Focus()
    End Sub

    Protected Sub txtStdCode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStdCode.TextChanged
        lblmsg.Text = ""
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
        ELL.trainingplacement = RbPlacement.SelectedValue
        ELL.PlacementId = ViewState("Placement_ID")
        dt = BLL.GetPlacementdetailsbyradio(ELL)
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
End Class
