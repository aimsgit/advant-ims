Imports System.Windows.Forms

Partial Class ProjectMaster
    Inherits BasePage

    Dim ELPM As New ELProjectMaster
    Dim DLPM As New DLProjectMaster
    Dim BLPM As New BLProjectMaster
    Dim idd As Integer
    Dim dt As New DataTable

    Sub DisplayGrid()
        'used for showing data in grid
        Try
            ELPM.ProjectID = ViewState("PMID")
            ELPM.ProjectID = 0
            If txtProjNme.Text = "" Then
                ELPM.ProjectName = 0
            Else
                ELPM.ProjectName = txtProjNme.Text
            End If
            If txtStartDate.Text = "__-___-____" Or txtStartDate.Text = "" Then
                ELPM.StartDate = "01/01/1900"
            Else
                ELPM.StartDate = txtStartDate.Text
            End If
            'If txtStartDate.Text = "" Then
            '    ELPM.StartDate = "01/01/1900"
            'Else
            '    ELPM.StartDate = CDate(txtStartDate.Text)
            'End If
            dt = BLPM.Display(ELPM)
            If dt.Rows.Count > 0 Then

                GVProjectMaster.DataSource = dt
                GVProjectMaster.DataBind()
                GVProjectMaster.Visible = True
                GVProjectMaster.Enabled = True
            Else
                lblErrorMsg.Text = "No records to display."
                GVProjectMaster.Visible = False
                lblMsg.Text = ""
            End If
        Catch ex As InvalidCastException
            lblErrorMsg.Text = "Enter correct data."
            lblMsg.Text = ""
        End Try
        'clear()
    End Sub
    Sub DispGrid()
        'used for showing data in grid
        ELPM.ProjectID = 0
        If txtProjNme.Text <> "" Then
            ELPM.ProjectName = 0
        End If
        If txtStartDate.Text <> "__-___-____" Or txtStartDate.Text = "" Then
            ELPM.StartDate = "01/01/1900"
        Else
            ELPM.StartDate = "01/01/1900"
        End If
        dt = BLPM.Display(ELPM)
        If dt.Rows.Count > 0 Then
            GVProjectMaster.DataSource = dt
            GVProjectMaster.DataBind()
            GVProjectMaster.Visible = True
            GVProjectMaster.Enabled = True
        Else
            lblErrorMsg.Text = "No records to display."
            GVProjectMaster.Visible = 9
            lblMsg.Text = ""
        End If
        'clear()
    End Sub
    'description of view event click
    Protected Sub BtnDetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDetails.Click
        txtProjNme.Focus()
        LinkButton1.Focus()
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        'clear()
        If btnDetails.Text <> "BACK" Then
            lblErrorMsg.Text = ""
            lblMsg.Text = ""
            ViewState("PageIndex") = 0
            GVProjectMaster.PageIndex = 0
            DisplayGrid()
        Else
            btnDetails.Text = "VIEW"
            btnSave.Text = "ADD"
            GVProjectMaster.PageIndex = ViewState("PageIndex")
            DispGrid()
            clear()
        End If
    End Sub
    'description of delete event click
    'Modified By Ajit On 8 JAN 2013
    Protected Sub GVProjectMaster_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVProjectMaster.RowDeleting
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ELPM.ProjectID = CType(GVProjectMaster.Rows(e.RowIndex).Cells(1).FindControl("lblProjID"), System.Web.UI.WebControls.Label).Text
            BLPM.ChangeFlag(ELPM)
            GVProjectMaster.DataBind()
            lblErrorMsg.Text = ""
            lblMsg.Text = "Data Deleted Successfully."
            txtProjNme.Focus()
            GVProjectMaster.PageIndex = ViewState("PageIndex")
            Dim dt As New DataTable
            ELPM.ProjectID = 0
            If txtStartDate.Text = "" Or txtStartDate.Text = "__-___-____" Then
                ELPM.StartDate = "01/01/1900"
            Else
                ELPM.StartDate = txtStartDate.Text
            End If
            If txtProjNme.Text = "" Then
                ELPM.ProjectName = 0
            Else
                ELPM.ProjectName = txtProjNme.Text
            End If
            dt = BLPM.Display(ELPM)
            GVProjectMaster.DataSource = dt
            GVProjectMaster.DataBind()
            GVProjectMaster.Visible = True
            GVProjectMaster.Enabled = True
            clear()
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot delete data."
            lblMsg.Text = ""
        End If

    End Sub
    'description of edit event click
    Protected Sub GVProjectMaster_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVProjectMaster.RowEditing
        lblErrorMsg.Text = ""
        lblMsg.Text = ""
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Try
            txtProjNme.Text = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblProjName"), System.Web.UI.WebControls.Label).Text
            txtDescription.Text = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblDescription"), System.Web.UI.WebControls.Label).Text
            ddlSubmittedBy.SelectedValue = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblSubmit"), HiddenField).Value
            ddlSubmittedBy.SelectedItem.Text = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblSubmittedBy"), System.Web.UI.WebControls.Label).Text.Trim
            txtSubmittedDate.Text = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblSubmittedDate"), System.Web.UI.WebControls.Label).Text
            If CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblApprdBy"), HiddenField).Value = "" Then
                ddlApprovedby.SelectedValue = 0
            Else
                ddlApprovedby.SelectedValue = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblApprdBy"), HiddenField).Value
            End If
            If CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblApprovedBy"), System.Web.UI.WebControls.Label).Text.Trim = "" Then
                ddlApprovedby.SelectedItem.Text = "Select"
            Else
                ddlApprovedby.SelectedItem.Text = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblApprovedBy"), System.Web.UI.WebControls.Label).Text.Trim
            End If

            txtApprovedDate.Text = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblApprovedDate"), System.Web.UI.WebControls.Label).Text
            txtStartDate.Text = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblStartDate"), System.Web.UI.WebControls.Label).Text
            txtEndDate.Text = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblEndDate"), System.Web.UI.WebControls.Label).Text
            ViewState("PMID") = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("lblProjID"), System.Web.UI.WebControls.Label).Text
            If CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value = "" Then
                cmbSponsor.SelectedValue = 0
            Else
                cmbSponsor.SelectedValue = CType(GVProjectMaster.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
            End If

            btnSave.Text = "UPDATE"
            btnDetails.Text = "BACK"
            Dim dt As New DataTable
            ELPM.ProjectID = ViewState("PMID")
            ELPM.ProjectName = 0
            ELPM.StartDate = "01/01/1900"
            dt = BLPM.Display(ELPM)
            GVProjectMaster.DataSource = dt
            GVProjectMaster.DataBind()
            GVProjectMaster.Enabled = False
        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct data."
            lblMsg.Text = ""
        End Try
        'Else
        'lblErrorMsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblMsg.Text = ""
        'End If
    End Sub
    'description of add event as well as update event click
    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        txtProjNme.Focus()
        lblMsg.Text = ""
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                If ddlSubmittedBy.SelectedValue = 0 Then
                    lblErrorMsg.Text = "Submitted By Field is Mandatory."
                    ddlSubmittedBy.Focus()
                    Exit Sub
                End If
                ELPM.ProjectName = txtProjNme.Text
                ELPM.Description = txtDescription.Text
                'If txtSubmittedBy.Text = "" Then
                '    HidSEmpId.Value = 0
                'Else
                '    ELPM.SubmittedBy = HidSEmpId.Value
                'End If
                ELPM.SubmittedBy = ddlSubmittedBy.SelectedValue
                ELPM.SponsorID = cmbSponsor.SelectedValue
                If txtSubmittedDate.Text = "" Then
                    ELPM.SubmittedDate = "1/1/1900"
                Else
                    ELPM.SubmittedDate = txtSubmittedDate.Text
                End If
                'If txtApprovedBy.Text = "" Then
                '    ELPM.ApprovedBy = 0
                'Else
                '    ELPM.ApprovedBy = HidAEmpId.Value
                'End If
                ELPM.ApprovedBy = ddlApprovedby.SelectedValue
                If txtApprovedDate.Text = "__-___-____" Then
                    ELPM.ApprovedDate = "1/1/1900"
                Else
                    ELPM.ApprovedDate = txtApprovedDate.Text
                End If
                If txtStartDate.Text = "__-___-____" Then
                    ELPM.StartDate = "1/1/1900"
                Else
                    ELPM.StartDate = txtStartDate.Text
                End If
                If txtEndDate.Text = "" Then
                    ELPM.EndDate = "1/1/1900"
                Else
                    ELPM.EndDate = txtEndDate.Text
                End If
                ELPM.ProjectID = ViewState("PMID")
                lblMsg.Text = ""
                If btnSave.Text = "UPDATE" Then
                    'If ELPM.EndDate <> "1/1/1900" Then
                    If ddlSubmittedBy.SelectedValue = 0 Then
                        lblErrorMsg.Text = "Submitted By Field is Mandatory."
                        Exit Sub
                        ddlSubmittedBy.Focus()
                    End If
                    'If ELPM.ApprovedDate <> "1/1/1900" Then
                    '    If CType(txtApprovedDate.Text, Date) < CType(txtSubmittedDate.Text, Date) Then
                    '        lblErrorMsg.Text = "Approved Date Can't be Less than Submitted Date."
                    '        txtApprovedDate.Focus()
                    '        Exit Sub
                    '    End If
                    'End If
                    If ELPM.EndDate <> "1/1/1900" And ELPM.EndDate < ELPM.StartDate Then
                        lblErrorMsg.Text = "Project End Date should be greater than Project Start Date."
                        txtEndDate.Focus()
                    Else
                        'If ELPM.EndDate < ELPM.StartDate Then
                        '    lblErrorMsg.Text = "Project End Date should be greater than Project Start Date."
                        '    txtEndDate.Focus()
                        'Else
                        ELPM.ProjectID = ViewState("PMID")
                        BLPM.UpdateRecord(ELPM)
                        btnSave.Text = "ADD"
                        btnDetails.Text = "VIEW"
                        lblMsg.Text = "Data Updated Successfully."
                        lblErrorMsg.Text = ""
                        GVProjectMaster.PageIndex = ViewState("PageIndex")
                        DispGrid()
                        clear1()
                        HidSEmpId.Value = ""
                    End If
                    'End If
                    'End If
                ElseIf btnSave.Text = "ADD" Then
                    ELPM.ProjectName = txtProjNme.Text
                    dt = BLPM.duplicate(ELPM)
                    If dt.Rows.Count > 0 Then
                        lblErrorMsg.Visible = True
                        lblErrorMsg.Text = "Data already exists."
                        lblMsg.Text = ""
                    Else
                        'If ELPM.ApprovedDate <> "1/1/1900" Then
                        '    If txtApprovedDate.Text < txtSubmittedDate.Text Then
                        '        lblErrorMsg.Text = "Approved Date Can't be Less than Submitted Date."
                        '        txtApprovedDate.Focus()
                        '        Exit Sub
                        '    End If
                        'End If
                        If ELPM.EndDate <> "1/1/1900" And ELPM.EndDate < ELPM.StartDate Then
                            lblErrorMsg.Text = "Project End Date should be greater than Project Start Date."
                            txtEndDate.Focus()
                        Else

                            BLPM.InsertRecord(ELPM)
                            btnSave.Text = "ADD"
                            lblMsg.Text = "Data Saved Successfully."
                            lblErrorMsg.Text = ""
                            ViewState("PageIndex") = 0
                            GVProjectMaster.PageIndex = 0
                            DisplayGrid()
                            clear()
                            txtProjNme.Focus()
                            HidSEmpId.Value = ""
                        End If

                        'End If
                    End If
                End If
            Catch ex As Exception
                lblErrorMsg.Text = "Enter correct data."
                lblMsg.Text = ""
            End Try
        Else
            lblErrorMsg.Text = "You do not belong to this branch, Cannot add/update data."
            lblMsg.Text = ""
        End If


    End Sub
    'for clearing text in textbox
    Sub clear()
        txtProjNme.Text = ""
        txtDescription.Text = ""
        'txtSubmittedBy.Text = ""
        txtSubmittedDate.Text = Format(Date.Today, "dd-MMM-yyyy")
        'txtApprovedBy.Text = ""
        HidAEmpId.Value = 0
        txtApprovedDate.Text = Format(Date.Today, "dd-MMM-yyyy")
        txtStartDate.Text = Format(Date.Today, "dd-MMM-yyyy")
        txtEndDate.Text = ""
    End Sub
    Sub clear1()
        txtProjNme.Text = ""
        txtDescription.Text = ""
        'txtSubmittedBy.Text = ""
        txtSubmittedDate.Text = Format(Date.Today, "dd-MMM-yyyy")
        'txtApprovedBy.Text = ""
        HidAEmpId.Value = 0
        txtApprovedDate.Text = Format(Date.Today, "dd-MMM-yyyy")
        txtStartDate.Text = Format(Date.Today, "dd-MMM-yyyy")
        txtEndDate.Text = ""
    End Sub

    'for page indexing one page to another
    Protected Sub GVProjectMaster_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVProjectMaster.PageIndexChanging
        GVProjectMaster.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVProjectMaster.PageIndex
        GVProjectMaster.DataBind()
        DisplayGrid()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub


    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not Page.IsPostBack Then
            txtApprovedDate.Text = Format(Today, "dd-MMM-yyyy")
            txtSubmittedDate.Text = Format(Today, "dd-MMM-yyyy")
            txtStartDate.Text = Format(Today, "dd-MMM-yyyy")
            'txtSubmittedBy.Text = ""
            txtProjNme.Focus()
        End If

    End Sub

    Protected Sub btnStatus_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnStatus.Click
        Dim dt1 As New DataTable
        Dim Msg, Msg1 As String
        Msg1 = ""
        dt1 = DLEndowment.GetEndowmentAlertMsg()
        Dim Counts As Integer = dt1.Rows.Count()
        While (Counts > 0)
            Msg = dt1.Rows(Counts - 1).Item("Diff") + dt1.Rows(Counts - 1).Item("text1").ToString() + dt1.Rows(Counts - 1).Item("project_name") + vbCrLf
            Msg1 = Msg1 + "<br />" + Msg
            Counts = Counts - 1
        End While
        Msg = Msg1
        Session("Msg") = Msg
        If Msg <> "" Then
            Dim qrystring As String = "RptProjectReminder.aspx?" & QueryStr.Querystring()
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=450,height=300,left=300,top=220')</script>", False)

        Else
            lblErrorMsg.Text = "No Program Information Available."
            lblmsg.text = ""
        End If
    End Sub

    Protected Sub GVProjectMaster_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVProjectMaster.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        ELPM.ProjectID = ViewState("PMID")
        ELPM.ProjectID = 0
        If txtProjNme.Text = "" Then
            ELPM.ProjectName = 0
        Else
            ELPM.ProjectName = txtProjNme.Text
        End If
        If txtStartDate.Text = "__-___-____" Or txtStartDate.Text = "" Then
            ELPM.StartDate = "01/01/1900"
        Else
            ELPM.StartDate = txtStartDate.Text
        End If
        'If txtStartDate.Text = "" Then
        '    ELPM.StartDate = "01/01/1900"
        'Else
        '    ELPM.StartDate = CDate(txtStartDate.Text)
        'End If
        dt = BLPM.Display(ELPM)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVProjectMaster.DataSource = sortedView
        GVProjectMaster.DataBind()
        GVProjectMaster.Visible = True
        GVProjectMaster.Enabled = True
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
