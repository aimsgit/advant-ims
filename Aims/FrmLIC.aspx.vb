
Partial Class FrmLIC
    Inherits BasePage
    Dim EL As New ELLIC
    Dim BL As New BLLIC
    Dim dt As New DataTable

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click

        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                ddlDept.Focus()
                EL.DeptId = ddlDept.SelectedValue
                EL.Lab_Name = txtLab.Text
                If txtCarpet.Text = "" Then
                    EL.Carpet_Area = 0
                Else
                    EL.Carpet_Area = txtCarpet.Text
                End If
                EL.Equipment_Avail = Txtequip.Text
                EL.Remarks = TxtRemarks.Text
                If btnadd.Text = "UPDATE" Then
                    EL.ID = ViewState("Inspection_Id_Auto")
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
                        DisplayLIC()
                        GVLIC.PageIndex = ViewState("PageIndex")
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
                        GVLIC.PageIndex = 0
                        DisplayLIC()
                        clear()
                        DisplayLIC()
                    End If
                End If
            Catch ex As Exception
                lblmsg.Text = ""
                msginfo.Text = "Enter correct data."
            End Try

        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If

    End Sub
    Sub DisplayLIC()
        Dim dt As New DataTable
        EL.ID = 0
        dt = BL.Display(EL)
        GVLIC.DataSource = dt
        GVLIC.DataBind()

        GVLIC.Visible = True
        GVLIC.Enabled = True
        LinkButton.Focus()
        If dt.Rows.Count = 0 Then
            lblmsg.Text = ""

            msginfo.Text = "No records to display."
            'msginfo.Visible = True
        End If
    End Sub
    Sub clear()
        ddlDept.Focus()
        txtLab.Text = ""
        txtCarpet.Text = ""
        Txtequip.Text = ""
        TxtRemarks.Text = ""
    End Sub

    Protected Sub btndetails_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btndetails.Click
        msginfo.Text = ""
        If btndetails.Text <> "BACK" Then
            lblmsg.Text = ""
            msginfo.Text = ""
            ViewState("PageIndex") = 0
            GVLIC.PageIndex = 0
            DisplayLIC()
            GVLIC.Visible = True

        Else
            lblmsg.Text = ""
            msginfo.Text = ""
            btndetails.Text = "VIEW"
            btnadd.Text = "ADD"
            clear()
            GVLIC.Visible = True
            GVLIC.PageIndex = ViewState("PageIndex")
            DisplayLIC()
        End If
    End Sub

    Protected Sub GVLIC_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVLIC.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            ViewState("Inspection_Id_Auto") = CType(GVLIC.Rows(e.RowIndex).Cells(1).FindControl("IID"), HiddenField).Value
            EL.ID = ViewState("Inspection_Id_Auto")
            BL.ChangeFlag(EL)
            DisplayLIC()
            GVLIC.Visible = True
            msginfo.Text = ""
            lblmsg.Text = "Data Deleted Successfully."
            ddlDept.Focus()
            GVLIC.PageIndex = ViewState("PageIndex")
            'txtrcvdate.Text = ""
            'EL.ID = 0
            If txtLab.Text = "" Then
                EL.Lab_Name = 0
            Else
                EL.Lab_Name = txtLab.Text
            End If
            If txtCarpet.Text = "" Then
                EL.Carpet_Area = 0
            Else
                EL.Carpet_Area = txtCarpet.Text
            End If
            If TxtRemarks.Text = "" Then
                EL.Remarks = 0
            Else
                EL.Remarks = TxtRemarks.Text
            End If
            dt = BL.Display(EL)
            GVLIC.DataSource = dt
            GVLIC.DataBind()
            GVLIC.Enabled = True
            GVLIC.Visible = True
        Else
            msginfo.Text = "You do not belong to this branch, Cannot delete data."
            lblmsg.Text = ""
        End If

    End Sub

    Protected Sub GVLIC_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVLIC.RowEditing
        lblmsg.Text = ""
        msginfo.Text = ""
        EL.ID = ViewState("Inspection_Id_Auto")

        ddlDept.SelectedValue = CType(GVLIC.Rows(e.NewEditIndex).FindControl("LblDeptid"), Label).Text
        txtLab.Text = CType(GVLIC.Rows(e.NewEditIndex).FindControl("lbl2"), Label).Text
        txtCarpet.Text = CType(GVLIC.Rows(e.NewEditIndex).FindControl("Lbl3"), Label).Text
        Txtequip.Text = CType(GVLIC.Rows(e.NewEditIndex).FindControl("Lbl4"), Label).Text
        TxtRemarks.Text = CType(GVLIC.Rows(e.NewEditIndex).FindControl("Lbl5"), Label).Text
        ViewState("Inspection_Id_Auto") = CType(GVLIC.Rows(e.NewEditIndex).FindControl("IID"), HiddenField).Value
        btnadd.Text = "UPDATE"
        btndetails.Text = "BACK"
        EL.ID = ViewState("Inspection_Id_Auto")
        dt = BL.Display(EL)
        GVLIC.DataSource = dt
        GVLIC.DataBind()
        GVLIC.Enabled = False

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub

    Protected Sub GVLIC_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVLIC.PageIndexChanging
        GVLIC.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVLIC.PageIndex
        DisplayLIC()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub GVLIC_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVLIC.Sorting
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
        GVLIC.DataSource = sortedView
        GVLIC.DataBind()

        GVLIC.Visible = True
        GVLIC.Enabled = True
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
