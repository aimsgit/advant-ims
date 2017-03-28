Imports System.IO
Imports System.Data
Imports System.Collections.Generic
Imports Attendance

'Author-->Anchala Verma
'Date---->13-Mar-2012
Partial Class frmSemesterDate
    Inherits BasePage
    Dim dt As New DataTable
    Dim Bl As New SemesterdateBL
    Dim El As New Semester

    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        cmbCourse.Focus()
        If (Session("BranchCode") = Session("ParentBranch")) Then

            If btnSubmit.CommandName = "ADD" Then
                El.Duration = TxtDuration.Text
                El.Sequence = txtSequence.Text
                El.Course = cmbCourse.SelectedValue
                El.SemesterId = cmbSemester.SelectedValue
                If TxtWeeks.Text = "" Then
                    El.Weeks = 0
                Else
                    El.Weeks = TxtWeeks.Text
                End If

                dt = Bl.GetDuplicateSemesterDuration(El)
                lblmsg.Text = ValidationMessage(1014)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    GVSemdate.Visible = True
                    lblmsg.Text = ValidationMessage(1014)
                    'TxtDuration.Text = ""
                    'txtSequence.Text = ""
                    'cmbCourse.SelectedValue = 0
                    'cmbSemester.SelectedValue = 0
                Else
                    Bl.InsertRecord(El)
                    lblmsg.Text = ValidationMessage(1020)
                    msginfo.Text = ValidationMessage(1014)
                    TxtDuration.Text = ""
                    txtSequence.Text = ""
                    TxtWeeks.Text = ""
                    'cmbCourse.SelectedValue = 0
                    'cmbSemester.SelectedValue = 0
                    dt = Bl.DispGrid(0, El.Course)
                    GVSemdate.DataSource = dt
                    ViewState("PageIndex") = 0
                    GVSemdate.PageIndex = 0
                    GVSemdate.DataBind()
               
                    GVSemdate.Enabled = True
                    GVSemdate.Visible = True
                End If
            Else

                El.Duration = TxtDuration.Text
                El.Sequence = txtSequence.Text
                El.Course = cmbCourse.SelectedValue
                El.SemesterId = cmbSemester.SelectedValue
                If TxtWeeks.Text = "" Then
                    El.Weeks = 0
                Else
                    El.Weeks = TxtWeeks.Text
                End If

                El.ID = ViewState("ID")
                dt = Bl.GetDuplicateSemesterDuration(El)
                lblmsg.Text = ValidationMessage(1014)
                If dt.Rows.Count > 0 Then
                    msginfo.Text = ValidationMessage(1030)
                    GVSemdate.Visible = True
                    lblmsg.Text = ValidationMessage(1014)
                    'TxtDuration.Text = ""
                    'txtSequence.Text = ""
                    'cmbCourse.SelectedValue = 0
                    'cmbSemester.SelectedValue = 0
                Else
                    Bl.UpdateSemdate(El)
                    lblmsg.Text = ValidationMessage(1017)
                    msginfo.Text = ValidationMessage(1014)
                    dt = Bl.DispGrid(0, El.Course)
                    GVSemdate.DataSource = dt
                    GVSemdate.PageIndex = ViewState("PageIndex")
                    GVSemdate.DataBind()
                    GVSemdate.Enabled = True
                    btnSubmit.CommandName = "ADD"
                    btnView.CommandName = "VIEW"
              
                    TxtDuration.Text = ""
                    txtSequence.Text = ""
                    TxtWeeks.Text = ""
                    'cmbCourse.SelectedValue = 0
                    'cmbSemester.SelectedValue = 0
                End If
            End If
        Else
            msginfo.Text = ValidationMessage(1021)
            lblmsg.Text = ValidationMessage(1014)
        End If

    End Sub

    Protected Sub btnView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnView.Click
        LinkButton1.Focus()
        If btnView.CommandName = "BACK" Then

            dt = Bl.DispGrid(El.ID, El.Course)
            GVSemdate.DataSource = dt
            GVSemdate.PageIndex = ViewState("PageIndex")
            GVSemdate.DataBind()
            GVSemdate.Enabled = True
            btnView.CommandName = "VIEW"
            btnSubmit.CommandName = "ADD"

            msginfo.Text = ValidationMessage(1014)
            TxtDuration.Text = ""
            txtSequence.Text = ""
            TxtWeeks.Text = ""
            cmbCourse.SelectedValue = 0
            cmbSemester.SelectedValue = 0
        Else

            El.Course = cmbCourse.SelectedValue
            dt = Bl.DispGrid(El.ID, El.Course)
            If dt.Rows.Count = 0 Then
                GVSemdate.DataSource = Nothing
                GVSemdate.DataBind()
              
                msginfo.Text = ValidationMessage(1023)
                lblmsg.Text = ValidationMessage(1014)

            Else
                btnView.Text = "VIEW"
                btnSubmit.Text = "ADD"
                GVSemdate.DataSource = dt
                ViewState("PageIndex") = 0
                GVSemdate.PageIndex = 0
                GVSemdate.DataBind()
                
                GVSemdate.Enabled = True
                GVSemdate.Visible = True
                btnView.CommandName = "VIEW"
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1014)
            End If
        End If
    End Sub

    Protected Sub GVSemdate_RowEditing(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewEditEventArgs) Handles GVSemdate.RowEditing
        'If (Session("BranchCode") = Session("ParentBranch")) Then
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        cmbCourse.SelectedValue = CType(GVSemdate.Rows(e.NewEditIndex).FindControl("Label2"), Label).Text
        Dim de As String = CType(GVSemdate.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        cmbSemester.Items.Clear()
        cmbSemester.DataSourceID = "ObjSemester"
        cmbSemester.SelectedValue = CType(GVSemdate.Rows(e.NewEditIndex).FindControl("Label3"), Label).Text
        TxtDuration.Text = CType(GVSemdate.Rows(e.NewEditIndex).FindControl("l4"), Label).Text
        txtSequence.Text = CType(GVSemdate.Rows(e.NewEditIndex).FindControl("l5"), Label).Text
        TxtWeeks.Text = CType(GVSemdate.Rows(e.NewEditIndex).FindControl("l6"), Label).Text
        ViewState("ID") = CType(GVSemdate.Rows(e.NewEditIndex).FindControl("HFPKID"), HiddenField).Value
        El.ID = ViewState("ID")
        btnSubmit.CommandName = "UPDATE"
        btnSubmit.Text = "UPDATE"
        btnView.CommandName = "BACK"
        btnView.Text = "BACK"
        dt = Bl.DispGrid(El.ID, cmbCourse.SelectedValue)
        GVSemdate.DataSource = dt
        GVSemdate.DataBind()

        GVSemdate.Enabled = False

        'Else
        'msginfo.Text = "You do not belong to this branch, Cannot edit data."
        'lblmsg.Text = ""
        'End If

    End Sub
    Protected Sub GVSemdate_RowDeleting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewDeleteEventArgs) Handles GVSemdate.RowDeleting
        If (Session("BranchCode") = Session("ParentBranch")) Then
    
            ViewState("ID") = CType(GVSemdate.Rows(e.RowIndex).FindControl("HFPKID"), HiddenField).Value
            El.ID = ViewState("ID")
            Bl.DelSemdate(El)

            lblmsg.Text = ValidationMessage(1028)
            cmbCourse.Focus()
            El.Course = cmbCourse.SelectedValue

            msginfo.Text = ValidationMessage(1014)
            dt = Bl.DispGrid(0, El.Course)
            If dt.Rows.Count > 0 Then
                GVSemdate.DataSource = dt
                GVSemdate.Visible = True
                GVSemdate.Enabled = True
                GVSemdate.PageIndex = ViewState("PageIndex")
                GVSemdate.DataBind()
      
            Else
                lblmsg.Text = ValidationMessage(1014)
                msginfo.Text = ValidationMessage(1023)
                GVSemdate.Visible = False

            End If
        Else
            msginfo.Text = ValidationMessage(1029)
            lblmsg.Text = ValidationMessage(1014)
        End If


    End Sub
    Protected Sub GVSemdate_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GVSemdate.PageIndexChanging
        GVSemdate.PageIndex = e.NewPageIndex
        ViewState("PageIndex") = GVSemdate.PageIndex
        Dim dt As New DataTable
        dt = Bl.DispGrid(0, 0)
        GVSemdate.DataSource = dt
        GVSemdate.Visible = True
        GVSemdate.DataBind()
      
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub cmbCourse_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCourse.TextChanged
        cmbCourse.Focus()
    End Sub

    Protected Sub cmbSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.TextChanged
        cmbSemester.Focus()
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbCourse.Focus()
        If Not IsPostBack Then
           
        End If
        Dim heading As String
        heading = Session("RptFrmTitleName")
        Me.Lblheading.Text = heading
    End Sub

    'Protected Sub TxtWeeks_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtWeeks.TextChanged
    '    If TxtWeeks.Text = "" Then
    '        El.Weeks = 0
    '        TxtDuration.Text = ""
    '    Else
    '        El.Weeks = TxtWeeks.Text
    '        TxtDuration.Text = Format(TxtWeeks.Text * 7, "0")
    '        txtSequence.Focus()
    '    End If
    'End Sub

    'Protected Sub TxtDuration_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDuration.TextChanged
    '    If TxtDuration.Text = "" Then
    '        El.Duration = 0
    '        TxtWeeks.Text = ""
    '    Else
    '        El.Duration = TxtDuration.Text
    '        TxtWeeks.Text = Format(TxtDuration.Text / 7, "0")
    '        TxtWeeks.Focus()
    '    End If
    'End Sub

    Protected Sub GVSemdate_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GVSemdate.Sorting
        Dim sortingDirection As String = String.Empty
       
        If dir() = SortDirection.Ascending Then
            dir = SortDirection.Descending
            sortingDirection = "Desc"
        Else
            dir = SortDirection.Ascending
            sortingDirection = "Asc"
        End If

        El.Course = cmbCourse.SelectedValue
        dt = Bl.DispGrid(El.ID, El.Course)
        If dt.Rows.Count = 0 Then
            GVSemdate.DataSource = Nothing
            GVSemdate.DataBind()
           
            msginfo.Text = ValidationMessage(1023)
            lblmsg.Text = ValidationMessage(1014)

        Else
            GVSemdate.DataSource = dt
            ViewState("PageIndex") = 0
            GVSemdate.PageIndex = 0
            Dim sortedView As New DataView(dt)
            sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
            GVSemdate.DataSource = sortedView
            GVSemdate.DataBind()
            
            GVSemdate.Enabled = True
            GVSemdate.Visible = True
            btnView.CommandName = "VIEW"
            lblmsg.Text = ValidationMessage(1014)
            msginfo.Text = ValidationMessage(1014)
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
End Class
