Imports System.IO
Imports System.Data.DataTable
Imports System.Collections.Generic
Partial Class FrmPayRollDetails
    Inherits BasePage
    Dim dt As New DataTable
    Dim Bl As New PayRollNewBL
    Dim El As New PayRollNewEL
    Dim Dl As New PayRollNewDL

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        cmbEmployee.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnSubmit.CommandName = "ADD" Then
                lblmsg.Text = ""
                If cmbEmployee.SelectedValue = 0 Then
                    lblmsg.Text = ""
                    msginfo.Text = "Select Employee."
                    Exit Sub
                Else
                    El.EmpId = cmbEmployee.SelectedValue
                    msginfo.Text = ""
                End If

                If cmbEarDed.SelectedValue = 0 Then
                    lblmsg.Text = ""
                    msginfo.Text = "Select Earning/Deduction."
                    Exit Sub
                Else
                    El.EarningDeduction = cmbEarDed.SelectedValue
                    msginfo.Text = ""
                End If

                If txtAmount.Text = "" Then
                    lblmsg.Text = ""
                    msginfo.Text = "Enter Amount."
                    Exit Sub
                Else
                    El.Amount = txtAmount.Text
                    msginfo.Text = ""
                End If
                If txtStartDate.Text = "" Then
                    El.FromDate = "01/01/1900"
                Else
                    El.FromDate = txtStartDate.Text
                End If
                If txtEndDate.Text = "" Then
                    El.ToDate = Format(Today, "dd-MMM-yyyy")
                Else
                    El.ToDate = txtEndDate.Text
                End If
                If ChkBoxHeader.Checked = True Then
                    El.StopSalary = "Y"
                Else
                    El.StopSalary = "N"
                End If

                El.Id = ViewState("id")
                dt = Bl.GetDuplicatePayrollDetailsNew(El)

                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ""
                    msginfo.Text = "Data already exists."
                    disp1(ViewState("id"))
                    disp2(ViewState("id"))
                    Exit Sub
                Else

                    Bl.Insert(El)
                    lblmsg.Text = "Data Saved Successfully"
                    ViewState("PageIndex") = 0
                    GVPayRollDetails1.PageIndex = 0
                    GVPayRollDetails2.PageIndex = 0
                    disp1(0)
                    disp2(0)
                    Clear()
                    msginfo.Text = ""
                End If
            ElseIf btnSubmit.CommandName = "UPDATE" Then
                El.Id = ViewState("id")
                El.EmpId = cmbEmployee.SelectedValue
                El.EarningDeduction = cmbEarDed.SelectedValue
                El.Amount = txtAmount.Text
                If txtStartDate.Text = "" Then
                    El.FromDate = "01/01/1900"
                Else
                    El.FromDate = txtStartDate.Text
                End If
                If txtEndDate.Text = "" Then
                    El.ToDate = Format(Today, "dd-MMM-yyyy")
                Else
                    El.ToDate = txtEndDate.Text
                End If
                El.Id = ViewState("id")
                If ChkBoxHeader.Checked = True Then
                    El.StopSalary = "Y"
                Else
                    El.StopSalary = "N"
                End If
                dt = Bl.GetDuplicatePayrollDetailsNew(El)
                lblmsg.Text = ""
                msginfo.Text = ""
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ""
                    msginfo.Text = "Data already exists."
                    disp1(ViewState("id"))
                    disp2(ViewState("id"))
                    Exit Sub
                Else
                    Bl.Update(El)
                    lblmsg.Text = "Data updated Successfully"
                    Clear()
                    msginfo.Text = ""
                    btnSubmit.CommandName = "ADD"
                    btnView.CommandName = "VIEW"
                    btnSubmit.Text = "ADD"
                    btnView.Visible = True
                    btnView.Text = "VIEW"
                    GVPayRollDetails1.PageIndex = ViewState("PageIndex")
                    GVPayRollDetails2.PageIndex = ViewState("PageIndex")
                    disp1(0)
                    disp2(0)
                End If
            End If
        Else
            msginfo.Text = "You do not belong to this branch, Cannot add/update data."
            lblmsg.Text = ""
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbEmployee.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        lblmsg.Text = ""
        msginfo.Text = ""

        If btnView.CommandName <> "BACK" Then
            El.Id = 0
            If cmbEmployee.SelectedValue = 0 Then
                msginfo.Text = "Please Select Employee. "
                Exit Sub
            Else
                El.EmpId = cmbEmployee.SelectedValue
                ViewState("PageIndex") = 0
                GVPayRollDetails1.PageIndex = 0
                GVPayRollDetails2.PageIndex = 0
                disp1(El.Id)
                disp2(El.Id)   
            End If
        Else
            Clear()
            btnSubmit.CommandName = "ADD"
            btnView.CommandName = "VIEW"

            btnSubmit.Text = "ADD"
            btnView.Visible = "True"
            btnView.Text = "VIEW"
            GVPayRollDetails1.PageIndex = ViewState("PageIndex")
            GVPayRollDetails2.PageIndex = ViewState("PageIndex")
            disp1(0)
            disp2(0)
        End If
        Dim dt1 As New DataTable
        Dim dt2 As New DataTable
        dt1 = Bl.DisplayGridview(El.Id, El.EmpId)
        dt2 = Bl.DisplayGridviewDeduction(El.Id, El.EmpId)
        If dt1.Rows.Count = 0 And dt2.Rows.Count = 0 Then

            msginfo.Text = "No records to display"

            Exit Sub

        End If
    End Sub
    Protected Sub GVPayRollDetails1_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVPayRollDetails1.RowEditing

        Dim dt As New DataTable
        btnSubmit.CommandName = "UPDATE"
        btnView.Visible = True
        btnView.CommandName = "BACK"
        btnSubmit.Text = "UPDATE"
        btnView.Visible = True
        btnView.Text = "BACK"
        ViewState("id") = CType(GVPayRollDetails1.Rows(e.NewEditIndex).FindControl("lblid"), Label).Text
        txtAmount.Text = CType(GVPayRollDetails1.Rows(e.NewEditIndex).FindControl("l4"), Label).Text
        cmbEarDed.SelectedValue = CType(GVPayRollDetails1.Rows(e.NewEditIndex).FindControl("lbldat"), Label).Text
        cmbEmployee.SelectedValue = CType(GVPayRollDetails1.Rows(e.NewEditIndex).FindControl("lblEmp"), Label).Text
        If CType(GVPayRollDetails1.Rows(e.NewEditIndex).FindControl("lblFromdate"), Label).Text = "01-Jan-1900" Then
            txtStartDate.Text = ""
        Else
            txtStartDate.Text = CType(GVPayRollDetails1.Rows(e.NewEditIndex).FindControl("lblFromdate"), Label).Text
        End If
        If CType(GVPayRollDetails1.Rows(e.NewEditIndex).FindControl("lblTodate"), Label).Text = "01-Jan-1900" Then
            txtStartDate.Text = ""
        Else
            txtEndDate.Text = CType(GVPayRollDetails1.Rows(e.NewEditIndex).FindControl("lblTodate"), Label).Text
        End If

        If CType(GVPayRollDetails1.Rows(e.NewEditIndex).FindControl("lblsalaryStop"), Label).Text = "N" Then
            ChkBoxHeader.Checked = False
        Else
            ChkBoxHeader.Checked = True
        End If
        El.Id = ViewState("id")
        dt = Bl.DisplayGridview(El.Id, cmbEmployee.SelectedValue)
        GVPayRollDetails1.DataSource = dt
        GVPayRollDetails1.DataBind()
        GVPayRollDetails1.Enabled = False
        lblmsg.Text = ""
        msginfo.Text = ""

    End Sub
    Protected Sub GVPayRollDetails1_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVPayRollDetails1.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim rowsaffected As Integer
            If (Session("BranchCode") = Session("ParentBranch")) Then
                El.Id = (CType(GVPayRollDetails1.Rows(e.RowIndex).FindControl("lblid"), Label).Text)
                rowsaffected = Bl.Delete(El)
                lblmsg.Text = "Data Deleted Sucessfully."
                msginfo.Text = ""

                cmbEmployee.Focus()
                El.EmpId = cmbEmployee.SelectedValue()
                GVPayRollDetails1.PageIndex = ViewState("PageIndex")
                GVPayRollDetails2.PageIndex = ViewState("PageIndex")
                disp1(0)
                dt = Bl.DisplayGridview(El.Id,El.EmpId)
                GVPayRollDetails1.DataSource = dt
                GVPayRollDetails1.DataBind()
                
            End If
        End If
    End Sub
    Protected Sub GVPayRollDetails1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVPayRollDetails1.PageIndexChanging
        GVPayRollDetails1.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVPayRollDetails1.PageIndex
        Dim dt As New DataTable
        dt = Bl.DisplayGridview(0, 0)
        GVPayRollDetails1.DataSource = dt
        GVPayRollDetails1.Visible = True
        GVPayRollDetails1.DataBind()
    End Sub
    Protected Sub GVPayRollDetails2_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVPayRollDetails2.RowEditing

        Dim dt As New DataTable
        btnSubmit.CommandName = "UPDATE"
        btnView.Visible = True
        btnView.CommandName = "BACK"
        btnSubmit.Text = "UPDATE"
        btnView.Visible = True
        btnView.Text = "BACK"
        ViewState("id") = CType(GVPayRollDetails2.Rows(e.NewEditIndex).FindControl("lblid"), Label).Text
        txtAmount.Text = CType(GVPayRollDetails2.Rows(e.NewEditIndex).FindControl("l4"), Label).Text
        cmbEarDed.SelectedValue = CType(GVPayRollDetails2.Rows(e.NewEditIndex).FindControl("lbldat"), Label).Text
        cmbEmployee.SelectedValue = CType(GVPayRollDetails2.Rows(e.NewEditIndex).FindControl("lblEmp"), Label).Text
       
        If CType(GVPayRollDetails2.Rows(e.NewEditIndex).FindControl("lblFromdate1"), Label).Text = "01-Jan-1900" Then
            txtStartDate.Text = ""
        Else
            txtStartDate.Text = CType(GVPayRollDetails2.Rows(e.NewEditIndex).FindControl("lblFromdate1"), Label).Text
        End If
        If CType(GVPayRollDetails2.Rows(e.NewEditIndex).FindControl("lblTodate1"), Label).Text = "01-Jan-1900" Then
            txtStartDate.Text = ""
        Else
            txtEndDate.Text = CType(GVPayRollDetails2.Rows(e.NewEditIndex).FindControl("lblTodate1"), Label).Text
        End If

        If CType(GVPayRollDetails2.Rows(e.NewEditIndex).FindControl("lblsalaryStop1"), Label).Text = "N" Then
            ChkBoxHeader.Checked = False
        Else
            ChkBoxHeader.Checked = True
        End If
        El.Id = ViewState("id")
        dt = Bl.DisplayGridviewDeduction(El.Id, cmbEmployee.SelectedValue)
        GVPayRollDetails2.DataSource = dt
        GVPayRollDetails2.DataBind()
        GVPayRollDetails2.Enabled = False
        lblmsg.Text = ""
        msginfo.Text = ""

    End Sub
    Protected Sub GVPayRollDetails2_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVPayRollDetails2.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Dim rowsaffected As Integer
            If (Session("BranchCode") = Session("ParentBranch")) Then
                El.Id = (CType(GVPayRollDetails2.Rows(e.RowIndex).FindControl("lblid"), Label).Text)
                rowsaffected = Bl.Delete(El)
                lblmsg.Text = "Data Deleted Sucessfully."
                msginfo.Text = ""

                cmbEmployee.Focus()
                El.EmpId = cmbEmployee.SelectedValue()
                GVPayRollDetails1.PageIndex = ViewState("PageIndex")
                GVPayRollDetails2.PageIndex = ViewState("PageIndex")
                disp2(0)
                dt = Bl.DisplayGridviewDeduction(El.Id, El.EmpId)
                GVPayRollDetails2.DataSource = dt
                GVPayRollDetails2.DataBind()   
            End If
        End If
    End Sub

    Protected Sub GVPayRollDetails2_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVPayRollDetails2.PageIndexChanging
        GVPayRollDetails2.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVPayRollDetails2.PageIndex
        Dim dt As New DataTable
        dt = Bl.DisplayGridviewDeduction(0, 0)
        GVPayRollDetails2.DataSource = dt
        GVPayRollDetails2.Visible = True
        GVPayRollDetails2.DataBind()
    End Sub
    Sub disp1(ByVal id As Integer)

        ' Display the data-- by Venkatesh(13-10-2014)

        El.Id = 0
        El.EmpId = cmbEmployee.SelectedValue
        dt = Bl.DisplayGridview(El.Id, El.EmpId)

        If dt.Rows.Count > 0 Then
            GVPayRollDetails1.DataSource = dt
            GVPayRollDetails1.DataBind()

            GVPayRollDetails1.Visible = True
            GVPayRollDetails1.Enabled = True
            LinkButton1.Focus()
        Else
            GVPayRollDetails1.Visible = False
        End If
    End Sub
    Sub disp2(ByVal id As Integer)

        ' Display the data-- by Venkatesh(13-10-2014)

        El.Id = 0
        El.EmpId = cmbEmployee.SelectedValue
        dt = Bl.DisplayGridviewDeduction(El.Id, El.EmpId)

        If dt.Rows.Count > 0 Then
            GVPayRollDetails2.DataSource = dt
            GVPayRollDetails2.DataBind()

            GVPayRollDetails2.Visible = True
            GVPayRollDetails2.Enabled = True
            LinkButton1.Focus()
        Else
            GVPayRollDetails2.Visible = False
        End If
    End Sub
    Sub Clear()
        txtAmount.Text = ""
        txtEndDate.Text = ""
        txtStartDate.Text = ""
        ChkBoxHeader.Checked = False
    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try
            lblmsg.Text = ""
            msginfo.Text = ""
            El.EmpId = cmbEmployee.SelectedValue
            El.EarningDeduction = cmbEarDed.SelectedValue
            Dim qrystring As String = "PayRollDetailsView.aspx?" & "&Employee=" & El.EmpId & "&EarningDeduction=" & El.EarningDeduction
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
        Catch ex As Exception
            lblmsg.Text = ""
            msginfo.Text = "Enter correct data."
        End Try
    End Sub
    Protected Sub GVPayRollDetails1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVPayRollDetails1.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        El.Id = 0
        El.EmpId = cmbEmployee.SelectedValue
        dt =  Bl.DisplayGridview(El.Id, El.EmpId)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVPayRollDetails1.DataSource = sortedView
        GVPayRollDetails1.DataBind()
        GVPayRollDetails1.Enabled = True
        GVPayRollDetails1.Visible = True
        LinkButton1.Focus()
    End Sub
    Protected Sub GVPayRollDetails2_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVPayRollDetails2.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        El.Id = 0
        El.EmpId = cmbEmployee.SelectedValue
        dt = Bl.DisplayGridviewDeduction(El.Id, El.EmpId)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVPayRollDetails2.DataSource = sortedView
        GVPayRollDetails2.DataBind()
        GVPayRollDetails2.Enabled = True
        GVPayRollDetails2.Visible = True
        LinkButton1.Focus()
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


