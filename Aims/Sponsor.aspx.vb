Imports System.Data.OleDb
Partial Class frmCourseType
    Inherits BasePage
    Dim s As New Sponsor
    Dim dt As New DataTable
    Dim SponsorManager As New SponsorManager

    Protected Sub btnadd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnadd.Click
        txtSprName.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then
            If btnadd.CommandName = "UPDATE" Then
                s.Name = txtSprName.Text
                s.ContactNo = txtContactNumber.Text
                s.Address = txtSprAddress.Text
                s.EMail = txtEmail.Text
                s.Remarks = txtRemarks.Text
                s.Sponsor_ID = ViewState("Sponsor_ID")
                dt = SponsorManager.CheckDuplicate(s)
                If dt.Rows.Count > 0 Then
                    lblErrormsg.Visible = True
                    lblErrormsg.Text = ValidationMessage(1030)
                    lblmsg.Text = ValidationMessage(1014)
                    'clear()
                    'DispGrid()
                Else
                    SponsorManager.UpdateRecord(s)
                    btnadd.CommandName = "ADD"
                    GVSponsor.Visible = True
                    btnview.CommandName = "VIEW"
                    lblErrormsg.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1017)
                    clear()
                    GVSponsor.PageIndex = ViewState("PageIndex")
                    DispGrid()
                End If
            ElseIf btnadd.CommandName = "ADD" Then
                s.Name = txtSprName.Text
                s.ContactNo = txtContactNumber.Text
                s.Address = txtSprAddress.Text
                s.EMail = txtEmail.Text
                s.Remarks = txtRemarks.Text
                dt = SponsorManager.CheckDuplicate(s)
                If dt.Rows.Count > 0 Then
                    lblmsg.Text = ValidationMessage(1014)
                    'lblErrormsg.Visible = True
                    lblErrormsg.Text = ValidationMessage(1030)
                    clear()
                    DispGrid()
                Else
                    s.Name = txtSprName.Text
                    s.ContactNo = txtContactNumber.Text
                    s.Address = txtSprAddress.Text
                    s.EMail = txtEmail.Text
                    s.Remarks = txtRemarks.Text
                    SponsorDB.Insert(s)
                    btnadd.CommandName = "ADD"
                    lblErrormsg.Text = ValidationMessage(1014)
                    'lblmsg.Visible = True
                    lblmsg.Text = ValidationMessage(1020)
                    clear()
                    ViewState("PageIndex") = 0
                    GVSponsor.PageIndex = 0
                    DispGrid()
                End If
            End If
        Else
            lblErrormsg.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If
    End Sub
    Sub clear()
        txtSprName.Text = ""
        txtContactNumber.Text = ""
        txtSprAddress.Text = ""
        txtEmail.Text = ""
        txtRemarks.Text = ""
    End Sub
    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        If btnview.CommandName = "VIEW" Then

            lblmsg.Text = ValidationMessage(1014)
            lblErrormsg.Text = ValidationMessage(1014)
            ViewState("PageIndex") = 0
            GVSponsor.PageIndex = 0
            DispGrid()
        ElseIf btnview.CommandName = "BACK" Then
            btnadd.Text = "ADD"
            btnview.Text = "VIEW"
            lblErrormsg.Text = ValidationMessage(1014)
            clear()
            GVSponsor.PageIndex = ViewState("PageIndex")
            DispGrid()
        End If
    End Sub

    Protected Sub GVSponsor_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVSponsor.PageIndexChanging
        GVSponsor.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVSponsor.PageIndex
        DispGrid()
        GVSponsor.Visible = True
        lblmsg.Text = ValidationMessage(1014)
    End Sub
    '-- =============================================
    '-- Author:      <Kusum>
    '-- Create date: <18-Jan-2013>
    '-- Description: <Below lines of code is commented because the delete option in sponsor form is not required>
    '-- =============================================
    'Protected Sub GVSponsor_RowDeleted(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeletedEventArgs) Handles GVSponsor.RowDeleted
    '    GVSponsor.DataBind()
    'End Sub

    'Protected Sub GVSponsor_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSponsor.RowDeleting
    '    If (Session("BranchCode") = Session("ParentBranch")) Then
    '        SponsorManager.ChangeFlag(CType(GVSponsor.Rows(e.RowIndex).Cells(1).FindControl("SID"), HiddenField).Value)
    '        GVSponsor.DataBind()
    '        lblErrormsg.Text = ""
    '        'lblmsg.Visible = True
    '        clear()
    '        lblErrormsg.Text = ""
    '        lblmsg.Text = "Data Deleted Successfully."
    '        txtSprName.Focus()
    '        GVSponsor.PageIndex = ViewState("PageIndex")
    '        DispGrid()
    '    Else
    '        lblErrormsg.Text = "You do not belong to this branch, Cannot delete data."
    '        lblmsg.Text = ""
    '    End If
    'End Sub

    Protected Sub GVSponsor_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSponsor.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        Dim dt As New DataTable
        btnadd.Text = "UPDATE"
        btnview.Visible = True
        btnview.Text = "BACK"
        lblmsg.Text = ValidationMessage(1014)
        GVSponsor.Visible = True
        lblErrormsg.Text = ValidationMessage(1014)
        ViewState("Sponsor_ID") = CType(GVSponsor.Rows(e.NewEditIndex).FindControl("SID"), HiddenField).Value
        txtSprName.Text = CType(GVSponsor.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        txtContactNumber.Text = CType(GVSponsor.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        txtSprAddress.Text = CType(GVSponsor.Rows(e.NewEditIndex).FindControl("Label1"), Label).Text
        txtEmail.Text = CType(GVSponsor.Rows(e.NewEditIndex).FindControl("Label4"), Label).Text
        txtRemarks.Text = CType(GVSponsor.Rows(e.NewEditIndex).FindControl("Label5"), Label).Text
        s.Sponsor_ID = ViewState("Sponsor_ID")
        dt = SponsorDB.GetSponsor1(s)
        GVSponsor.DataSource = dt
        GVSponsor.DataBind()
        GVSponsor.Visible = True
        GVSponsor.Enabled = False
        'lblmsg.Visible = True
        'Else
        'lblErrormsg.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Sub DispGrid()
        Dim dt As New DataTable
        s.Sponsor_ID = 0
        GVSponsor.Enabled = True
        dt = SponsorDB.GetSponsor1(s)
        If dt.Rows.Count > 0 Then
            GVSponsor.DataSource = dt
            GVSponsor.DataBind()
            LinkButton.Focus()
        Else
            lblmsg.Text = ValidationMessage(1014)
            'lblErrormsg.Visible = True
            lblErrormsg.Text = ValidationMessage(1023)
            clear()
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtSprName.Focus()
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
        If Not IsPostBack Then
        End If
    End Sub

    Protected Sub GVSponsor_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVSponsor.Sorting
        Dim sortingDirection As String = String.Empty
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If
        Dim dt As New DataTable
        s.Sponsor_ID = 0
        GVSponsor.Enabled = True
        dt = SponsorDB.GetSponsor1(s)
        Dim sortedView As New DataView(dt)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GVSponsor.DataSource = sortedView
        GVSponsor.DataBind()
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
    'Code written fro multilingual by Niraj on 10 aug 2013
    ''Retriving the text of controls based on Language
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
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
        Return 0
    End Function
End Class
