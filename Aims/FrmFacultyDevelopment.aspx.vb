
Partial Class FrmFacultyDevelopment
    Inherits BasePage
    Dim EL As New ELFacutlyDevelopment
    Dim BL As New BLFacutlyDevelopment
    Dim dt As New DataTable

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                ddlDept.Focus()
                EL.DeptId = ddlDept.SelectedValue
                EL.Program_Name = txtProgram.Text
                EL.ConductedBy = txtConduct.Text
                If Txtfdate.Text = "" Then
                    EL.FromDate = "01/01/1900"
                Else
                    EL.FromDate = Txtfdate.Text
                End If
                If Txttodate.Text = "" Then
                    EL.ToDate = "01/01/9000"
                Else
                    EL.ToDate = Txttodate.Text
                End If
                EL.Remarks = TxtRemarks.Text
                If CType(Txtfdate.Text, Date) > CType(Txttodate.Text, Date) Then
                    msginfo.Text = "'From Date' cannot be greater than 'To Date'."
                    Exit Sub
                End If

                If btnadd.Text = "UPDATE" Then
                    EL.ID = ViewState("Faculty_Dev_Auto_Id")
                    'dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        BL.UpdateRecord(EL)
                        msginfo.Text = ""
                        btnadd.Text = "ADD"
                        btndetails.Text = "VIEW"
                        lblmsg.Text = "Data Updated Successfully."
                        DisplayFacultyDevelopment()
                        GVfaculty.PageIndex = ViewState("PageIndex")
                        'Displ()
                        clear()
                    End If
                ElseIf btnadd.Text = "ADD" Then
                    EL.ID = 0
                    'dt = BL.CheckDuplicate(EL)
                    If dt.Rows.Count > 0 Then
                        msginfo.Text = "Data already exists."
                        lblmsg.Text = ""
                    Else
                        BL.InsertRecord(EL)
                        msginfo.Text = ""
                        btnadd.Text = "ADD"
                        lblmsg.Text = "Data Saved successfully."
                        ViewState("PageIndex") = 0
                        GVfaculty.PageIndex = 0
                        DisplayFacultyDevelopment()
                        clear()
                        DisplayFacultyDevelopment()
                    End If
                End If
            Catch ex As Exception
            lblmsg.Text = ""
            msginfo.Text = "Enter correct date."
        End Try

        Else
        msginfo.Text = "You do not belong to this branch, Cannot add/update data."
        lblmsg.Text = ""
        End If

    End Sub
    Sub DisplayFacultyDevelopment()
        Dim dt As New DataTable
        EL.ID = 0
        dt = BL.Display(EL)
        GVfaculty.DataSource = dt
        GVfaculty.DataBind()

        GVfaculty.Visible = True
        GVfaculty.Enabled = True
        LinkButton.Focus()
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ""

            msginfo.Text = "No records to display."
            'msginfo.Visible = True
        End If
    End Sub
    Sub clear()
        ddlDept.Focus()
        txtProgram.Text = ""
        txtConduct.Text = ""
        Txtfdate.Text = Format(Today, "dd-MMM-yyyy")
        Txttodate.Text = ""
        TxtRemarks.Text = ""
    End Sub

    Protected Sub GVfaculty_PageIndexChanging1(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVfaculty.PageIndexChanging
        GVfaculty.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVfaculty.PageIndex
        DisplayFacultyDevelopment()
    End Sub

    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click
        msginfo.Text = ""
        If btndetails.Text <> "BACK" Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GVfaculty.PageIndex = 0
            DisplayFacultyDevelopment()
            GVfaculty.Visible = True

        Else
            lblmsg.Text = ""
            msginfo.Text = ""
            btndetails.Text = "VIEW"
            btnadd.Text = "ADD"
            clear()
            GVfaculty.Visible = True
            GVfaculty.PageIndex = ViewState("PageIndex")
            DisplayFacultyDevelopment()
        End If
    End Sub

    Protected Sub GVfaculty_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVfaculty.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Faculty_Dev_Auto_Id") = CType(GVfaculty.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            EL.ID = ViewState("Faculty_Dev_Auto_Id")
            BL.ChangeFlag(EL)
            DisplayFacultyDevelopment()
            GVfaculty.Visible = True
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            ddlDept.Focus()
            GVfaculty.PageIndex = ViewState("PageIndex")
            'txtrcvdate.Text = ""
            'EL.ID = 0
            If txtProgram.Text = "" Then
                EL.Program_Name = 0
            Else
                EL.Program_Name = txtProgram.Text
            End If
            If txtConduct.Text = "" Then
                EL.ConductedBy = 0
            Else
                EL.ConductedBy = txtConduct.Text
            End If
            If Txtfdate.Text = "" Then
                EL.FromDate = "1/1/1900"
            Else
                EL.FromDate = CDate(Txtfdate.Text)
            End If
            If Txttodate.Text = "" Then
                EL.ToDate = "1/1/9000"
            Else
                EL.ToDate = CDate(Txttodate.Text)
            End If
            If TxtRemarks.Text = "" Then
                EL.Remarks = 0
            Else
                EL.Remarks = TxtRemarks.Text
            End If
            dt = BL.Display(EL)
            GVfaculty.DataSource = dt
            GVfaculty.DataBind()
            GVfaculty.Enabled = True
            GVfaculty.Visible = True
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub GVfaculty_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVfaculty.RowEditing
        lblmsg.Text = ""
        msginfo.Text = ""
        EL.ID = ViewState("Faculty_Dev_Auto_Id")

        ddlDept.SelectedValue = CType(GVfaculty.Rows(e.NewEditIndex).FindControl("LblDeptid"), Label).Text
        txtProgram.Text = CType(GVfaculty.Rows(e.NewEditIndex).FindControl("lbl2"), Label).Text
        txtConduct.Text = CType(GVfaculty.Rows(e.NewEditIndex).FindControl("Lbl3"), Label).Text
        Txtfdate.Text = CType(GVfaculty.Rows(e.NewEditIndex).FindControl("Lbl4"), Label).Text
        Txttodate.Text = CType(GVfaculty.Rows(e.NewEditIndex).FindControl("Lbl5"), Label).Text
        TxtRemarks.Text = CType(GVfaculty.Rows(e.NewEditIndex).FindControl("Lbl6"), Label).Text
        ViewState("Faculty_Dev_Auto_Id") = CType(GVfaculty.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        btnadd.Text = "UPDATE"
        btndetails.Text = "BACK"
        EL.ID = ViewState("Faculty_Dev_Auto_Id")
        dt = BL.Display(EL)
        GVfaculty.DataSource = dt
        GVfaculty.DataBind()
        GVfaculty.Enabled = False

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVfaculty_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVfaculty.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        EL.ID = 0
        dt = BL.Display(EL)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVfaculty.DataSource = sortedView
        GVfaculty.DataBind()
        GVfaculty.Visible = True
        GVfaculty.Enabled = True
        LinkButton.Focus()
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
