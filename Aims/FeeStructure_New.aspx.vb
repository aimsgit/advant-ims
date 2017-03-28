Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Partial Class FeeStructure_New
    'Author--Ajit kumar singh
    'Date-- 05-MAR-2012
    Inherits BasePage
    Dim BAL As New feeStructureBL
    Dim f As New feeStructureE
    Dim DLL As New feeStructureDL
    Dim Dl As New DLFeeStructDup
    Dim Bl As New BLFeeStructDup


    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        ddlacadmeic_year.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then

            Try
                Dim f As New feeStructureE
                f.AcademicYear_id = ddlacadmeic_year.SelectedValue
                f.batchID = ddlbatch.SelectedValue
                f.Semester_ID = ddlsem.SelectedValue
                f.CategoryID = ddlcat.SelectedValue
                f.Feehead_ID = ddlfee_head.SelectedValue
                f.Amount = txtamt.Text
                If txtduedate.Text = "" Then
                    f.DueDate = CType("01-Jan-3000", Date)
                Else
                    f.DueDate = CType(txtduedate.Text, Date)
                End If

                If btnadd.Text = "UPDATE" Then
                    'To check Duplicate 
                    f.id = ViewState("id")
                    Dim duplicate As New DataTable
                    duplicate = Bl.GetDuplicate(f)
                    If duplicate.Rows.Count > 0 Then
                        lblS.Text = ""
                        lblE.Text = "Data already Exists."
                    Else
                        BAL.UpdateRecord(f)
                        btnadd.Text = "ADD"
                        btnview.Text = "VIEW"
                        lblE.Text = ""
                        lblS.Text = "Data Updated Successfully."
                        gvfee_stuct.PageIndex = ViewState("PageIndex")
                        display()
                        gvfee_stuct.Enabled = True
                        gvfee_stuct.Visible = True
                        clear()
                    End If
                ElseIf btnadd.Text = "ADD" Then
                    'To check Duplicate
                    Dim duplicate As New DataTable
                    duplicate = Bl.GetDuplicate(f)
                    If duplicate.Rows.Count > 0 Then
                        lblS.Text = ""
                        lblE.Text = "Data already Exists."
                    Else
                        BAL.InsertRecord(f)
                        lblE.Text = ""
                        lblS.Text = "Data Saved Successfully."
                        Dim dt As New DataTable
                        ViewState("PageIndex") = 0
                        gvfee_stuct.PageIndex = 0
                        display()
                        gvfee_stuct.Enabled = True
                        gvfee_stuct.Visible = True
                        clear()
                    End If
                End If
            Catch ex As Exception
                lblE.Text = "Enter all mandatory fields."
                lblS.Text = ""
            End Try
        Else
            lblE.Text = "You do not belong to this branch, Cannot add/update data."
            lblS.Text = ""
        End If
    End Sub
    Protected Sub clear()
        txtamt.Text = ""
        txtduedate.Text = ""
    End Sub
  
    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        clear()
        lblE.Text = ""
        lblS.Text = ""
        Dim dt As New DataTable
        If btnview.Text = "VIEW" Then
            ViewState("PageIndex") = 0
            gvfee_stuct.PageIndex = 0
            display()
        ElseIf btnview.Text = "BACK" Then
            btnadd.Text = "ADD"
            btnview.Text = "VIEW"
            gvfee_stuct.PageIndex = ViewState("PageIndex")
            display()
        End If
    End Sub

    Protected Sub gvfee_stuct_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles gvfee_stuct.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            BAL.DeleteRecord(CType(gvfee_stuct.Rows(e.RowIndex).Cells(0).FindControl("Lableid"), Label).Text)
            ddlacadmeic_year.Focus()
            Dim dt As New DataTable
            gvfee_stuct.PageIndex = ViewState("PageIndex")
            display()
            gvfee_stuct.Enabled = True
            gvfee_stuct.Visible = True
            lblE.Text = ""
            lblS.Text = "Data Deleted Successfully."
            dt = BAL.GetRecord(f)
            gvfee_stuct.DataSource = dt
            gvfee_stuct.DataBind()
        Else
            lblE.Text = "You do not belong to this branch, Cannot delete data."
            lblS.Text = ""
        End If

    End Sub

    Protected Sub gvfee_stuct_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles gvfee_stuct.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Dim f1 As New feeStructureE
        Dim f2 As New feeStructureE
        Dim f As New feeStructureE
        lblE.Text = ""
        lblS.Text = ""
        ddlacadmeic_year.DataSourceID = "odsaccyear"
        ddlacadmeic_year.DataBind()
        ddlacadmeic_year.SelectedValue = CType(gvfee_stuct.Rows(e.NewEditIndex).FindControl("lblayrs"), Label).Text
        ddlbatch.ClearSelection()
        ddlbatch.DataSourceID = "odsbatch"
        ddlbatch.DataBind()
        ddlbatch.SelectedValue = CType(gvfee_stuct.Rows(e.NewEditIndex).FindControl("lblbatchid"), Label).Text
        Dim dt1 As New DataTable
        If ddlbatch.SelectedValue <> "Select" Then
            f2.batchID = ddlbatch.SelectedValue
            dt1 = BAL.getCourse(f2)
            If dt1.Rows.Count > 0 Then
                txtCourseName.Text = dt1.Rows(0).Item("CourseName").ToString
            Else
                txtCourseName.Text = ""
            End If
        End If
        ddlsem.ClearSelection()
        ddlsem.DataSourceID = "odssemester"
        ddlsem.DataBind()
        ddlsem.SelectedValue = CType(gvfee_stuct.Rows(e.NewEditIndex).FindControl("lblsemid"), Label).Text

        ddlfee_head.SelectedValue = CType(gvfee_stuct.Rows(e.NewEditIndex).FindControl("lblfeeid"), Label).Text

        txtamt.Text = CType(gvfee_stuct.Rows(e.NewEditIndex).FindControl("lblamt"), Label).Text

        txtduedate.Text = CType(gvfee_stuct.Rows(e.NewEditIndex).FindControl("lblduedate"), Label).Text

        ddlcat.SelectedValue = CType(gvfee_stuct.Rows(e.NewEditIndex).FindControl("lblcatid"), Label).Text

        ViewState("id") = CType(gvfee_stuct.Rows(e.NewEditIndex).FindControl("Lableid"), Label).Text
        f.AcademicYear_id = ddlacadmeic_year.SelectedValue
        f.batchID = ddlbatch.SelectedValue
        f.Semester_ID = ddlsem.SelectedValue
        f.CategoryID = ddlcat.SelectedValue
        f.id = ViewState("id")
        Dim dt As New DataTable
        dt = BAL.GetRecord(f)
        gvfee_stuct.DataSource = dt
        gvfee_stuct.DataBind()
        For Each rows As GridViewRow In gvfee_stuct.Rows
            If CType(rows.FindControl("lblduedate"), Label).Text = "01-Jan-3000" Then
                CType(rows.FindControl("lblduedate"), Label).Text = ""
            End If
        Next
        gvfee_stuct.Enabled = False
        gvfee_stuct.Visible = True
        btnadd.Text = "UPDATE"
        'e.Cancel = True
        btnview.Text = "BACK"
        btnview.Visible = True
        'Else
        'lblE.Text = "You do not belong to this branch, Cannot edit data."
        'lblS.Text = ""
        'End If


    End Sub
    Sub display()
        Dim dt As New DataTable
        Dim b As New CreateBatch
        If ddlacadmeic_year.SelectedValue = "" Then
            f.AcademicYear_id = 0
        Else
            f.AcademicYear_id = ddlacadmeic_year.SelectedValue
        End If
        If ddlbatch.SelectedValue = "" Then
            f.batchID = 0
        Else
            f.batchID = ddlbatch.SelectedValue
        End If
        If ddlsem.SelectedValue = 0 Then
            f.Semester_ID = 0
        Else
            f.Semester_ID = ddlsem.SelectedValue
        End If

        If ddlcat.SelectedValue = "" Then
            f.CategoryID = 0
        Else
            f.CategoryID = ddlcat.SelectedValue
        End If
        dt = BAL.GetRecord(f)
        If dt.Rows.Count <> 0 Then
            gvfee_stuct.DataSource = dt
            gvfee_stuct.DataBind()
            For Each rows As GridViewRow In gvfee_stuct.Rows
                If CType(rows.FindControl("lblduedate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblduedate"), Label).Text = ""
                End If
            Next
            gvfee_stuct.Visible = True
            gvfee_stuct.Enabled = True
            LinkButton3.Focus()
        Else
            lblS.Text = ""
            lblE.Text = "No records to display."
            gvfee_stuct.Visible = False
        End If
    End Sub
    Sub displayGrid()
        Dim dt As New DataTable
        Dim b As New CreateBatch
        If ddlacadmeic_year.SelectedValue <> "" Then
            f.AcademicYear_id = 0
        End If
        If ddlbatch.SelectedValue <> "" Then
            f.batchID = 0
        End If
        If ddlsem.SelectedValue <> 0 Then
            f.Semester_ID = 0
        End If

        If ddlcat.SelectedValue <> "" Then
            f.CategoryID = 0
        End If
        dt = BAL.GetRecord(f)
        If dt.Rows.Count <> 0 Then
            gvfee_stuct.DataSource = dt
            gvfee_stuct.DataBind()
            For Each rows As GridViewRow In gvfee_stuct.Rows
                If CType(rows.FindControl("lblduedate"), Label).Text = "01-Jan-3000" Then
                    CType(rows.FindControl("lblduedate"), Label).Text = ""
                End If
            Next
            gvfee_stuct.Visible = True
            gvfee_stuct.Enabled = True
            LinkButton3.Focus()
        Else
            lblS.Text = ""
            lblE.Text = "No records to display."
            gvfee_stuct.Visible = False
        End If
    End Sub
    Protected Sub gvfee_stuct_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles gvfee_stuct.PageIndexChanging
        lblE.Text = ""
        lblS.Text = ""
        gvfee_stuct.PageIndex = e.NewPageIndex
        gvfee_stuct.DataBind()
        ViewState("PageIndex") = gvfee_stuct.PageIndex
        display()
        gvfee_stuct.Visible = True
    End Sub
    Protected Sub ddlbatch_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.PreRender
        If ddlbatch.Items.Count > 0 Then
            'If ddlbatch.Items(0).Text <> "Select" Then
            '    ddlbatch.Items.Insert(0, "Select")
            'End If
        Else
            ddlbatch.Items.Insert(0, "Select")
        End If
    End Sub
    Protected Sub ddlbatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.SelectedIndexChanged
        Dim dt As New DataTable
        If ddlbatch.SelectedValue <> "Select" Then
            f.batchID = ddlbatch.SelectedValue
            dt = BAL.getCourse(f)
            If dt.Rows.Count > 0 Then
                txtCourseName.Text = dt.Rows(0).Item("CourseName").ToString
            Else
                txtCourseName.Text = ""
            End If
        End If
        lblE.Text = ""
        lblS.Text = ""
    End Sub
    Protected Sub ddlacadmeic_year_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlacadmeic_year.SelectedIndexChanged
        If ddlacadmeic_year.SelectedValue = "Select" Then
            ddlbatch.SelectedValue = "Select"
            txtCourseName.Text = ""
        End If
        lblE.Text = ""
        lblS.Text = ""

    End Sub
    Protected Sub ddlacadmeic_year_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlacadmeic_year.TextChanged
        ddlacadmeic_year.Focus()
    End Sub

    Protected Sub ddlbatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.TextChanged
        ddlbatch.Focus()
    End Sub

    Protected Sub ddlcat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcat.SelectedIndexChanged
        lblE.Text = ""
        lblS.Text = ""
    End Sub

    Protected Sub ddlcat_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcat.TextChanged
        ddlcat.Focus()
    End Sub

    Protected Sub ddlfee_head_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlfee_head.SelectedIndexChanged
        lblE.Text = ""
        lblS.Text = ""
    End Sub

    Protected Sub ddlfee_head_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlfee_head.TextChanged
        ddlfee_head.Focus()
    End Sub

    Protected Sub ddlsem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsem.SelectedIndexChanged
        lblE.Text = ""
        lblS.Text = ""
    End Sub

    Protected Sub ddlsem_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsem.TextChanged
        ddlsem.Focus()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ddlacadmeic_year.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub gvfee_stuct_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles gvfee_stuct.Sorting
        Dim sortingDirection As String = String.Empty
        If dir = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        Dim b As New CreateBatch
        If ddlacadmeic_year.SelectedValue <> "" Then
            f.AcademicYear_id = 0
        End If
        If ddlbatch.SelectedValue <> "" Then
            f.batchID = 0
        End If
        If ddlsem.SelectedValue <> 0 Then
            f.Semester_ID = 0
        End If

        If ddlcat.SelectedValue <> "" Then
            f.CategoryID = 0
        End If
        dt = BAL.GetRecord(f)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        gvfee_stuct.DataSource = sortedView
        gvfee_stuct.DataBind()
        For Each rows As GridViewRow In gvfee_stuct.Rows
            If CType(rows.FindControl("lblduedate"), Label).Text = "01-Jan-3000" Then
                CType(rows.FindControl("lblduedate"), Label).Text = ""
            End If
        Next
    End Sub

    Public Property dir() As SortDirection
        Get
            If ViewState("dirState") Is Nothing Then
                ViewState("dirState") = SortDirection.Descending
            End If
            Return DirectCast(ViewState("dirState"), SortDirection)
        End Get
        Set(ByVal value As SortDirection)
            ViewState("dirState") = Value
        End Set
    End Property
End Class
