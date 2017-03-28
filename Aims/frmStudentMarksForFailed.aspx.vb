Imports System.IO
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports System.Drawing

Partial Class frmStudentMarksForFailed
    Inherits BasePage
    Dim El As New ELStudentMarksForFailed
    Dim DL As New DLStudentMarksForFailed
    Dim dt, dt1 As New Data.DataTable

    Protected Sub btnview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnview.Click
        ' El.Min = txtMin.Text
        If txtMin.Text = "" Then
            lblerror.Text = "Enter the marks."
            Exit Sub
        End If
        LinkButton.Focus()
        lblmsg.Text = ""
        lblerror.Text = ""

        El.Batch = ddlbatch.SelectedValue
        El.Semester = ddlsemester.SelectedValue
        El.Subject = ddlsubject.SelectedValue
        El.Assesment = ddlassesment.SelectedValue
        El.Min = txtMin.Text
        El.AssesmentDate = TxtAssessmentDate.Text
        dt = DLStudentMarksForFailed.ViewStdMarks(El)
        GridView1.DataSource = dt
        GridView1.DataBind()
        If dt.Rows.Count > 0 Then
            For Each grid As GridViewRow In GridView1.Rows
                lblAssessmentAns.Text = CType(grid.FindControl("LabelAssessment"), Label).Text
                lblSubjectAns.Text = CType(grid.FindControl("LabelSubjectName"), Label).Text
                lblMaxAns.Text = CType(grid.FindControl("LabelMax"), Label).Text
                lblMinAns.Text = CType(grid.FindControl("LabelMin"), Label).Text
                pnllabel.Visible = True
            Next
            'For Each grid As GridViewRow In GridView1.Rows
            '    CType(grid.FindControl("txtactmarks"), TextBox).Text = ""
            'Next
            pnllabel.Visible = True
            GridView1.Visible = True
            BtnUpdate.Enabled = True
            btnclear.Enabled = True
        Else
            lblerror.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
            lblerror.Text = ValidationMessage(1023)
            GridView1.Visible = False
            pnllabel.Visible = False
        End If

    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            TxtAssessmentDate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub

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

    Protected Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        If (Session("BranchCode") = Session("ParentBranch")) Then
            Try
                El.A_Year = 0
                El.Batch = ddlbatch.SelectedValue
                El.Semester = ddlsemester.SelectedValue
                El.Subject = ddlsubject.SelectedValue
                El.Assesment = ddlassesment.SelectedValue
                El.Min = txtMin.Text
                El.AssesmentDate = TxtAssessmentDate.Text
                dt = DLStudentMarksForFailed.ViewStdMarks(El)
                dt1 = DLStudentMarksForFailed.CheckDuplicateaData(El)

                If dt.Rows.Count > 0 Then
                    For Each grid As GridViewRow In GridView1.Rows
                        El.Min1 = CType(grid.FindControl("LabelMin"), Label).Text
                        El.Max1 = CType(grid.FindControl("LabelMax"), Label).Text
                        If CType(grid.FindControl("txtactmarks"), TextBox).Text = "" Then
                            Continue For
                        Else
                            El.A_Marks = CType(grid.FindControl("txtactmarks"), TextBox).Text
                            If El.A_Marks > El.Max1 Then
                                lblerror.Text = "Marks Cannot Be Greater than Maximum Marks."
                                lblerror.Visible = "True"
                                Exit Sub
                            End If
                        End If
                        El.StdId = CType(grid.FindControl("LabelStdId"), Label).Text
                        El.ExamAttend = dt.Rows(0).Item("ExamAttendance")
                        'Code By Jina - Check For duplication of Data
                        'Dim count As Integer

                        If dt1.Rows.Count > 0 Then
                            lblerror.Text = "Data Already Exist on Same Assessment Date."
                            'GridView1.Visible = False
                            'pnllabel.Visible = False
                            Exit Sub
                        Else
                            DLStudentMarksForFailed.UpdateStdMarks(El)
                        End If
                    Next
                    lblerror.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1053)
                    ' pnllabel.Visible = False
                    'GridView1.Visible = False

                Else
                    lblerror.Text = ValidationMessage(1014)
                    lblmsg.Text = ValidationMessage(1014)
                    lblerror.Text = ValidationMessage(1023)
                    pnllabel.Visible = False
                    GridView1.Visible = False
                End If
            Catch ex As Exception
            lblerror.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
                lblerror.Text = ValidationMessage(1023)
                pnllabel.Visible = False
            GridView1.Visible = False
        End Try
        Else
            lblerror.Text = "You do not belong to this branch,update Data."
            GridView1.Visible = False
            pnllabel.Visible = False
        End If
    End Sub

    Protected Sub btnclear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnclear.Click
        El.Batch = ddlbatch.SelectedValue
        El.Semester = ddlsemester.SelectedValue
        El.Subject = ddlsubject.SelectedValue
        El.Assesment = ddlassesment.SelectedValue
        El.Min = txtMin.Text
        El.AssesmentDate = TxtAssessmentDate.Text
        Dim count As Integer
        dt = DLStudentMarksForFailed.ViewStdMarks(El)
        count = 0
        If dt.Rows.Count > 0 Then
            For Each grid As GridViewRow In GridView1.Rows
                If CType(grid.FindControl("txtactmarks"), TextBox).Text = "" Then
                    count = count + 1
                Else
                    CType(grid.FindControl("txtactmarks"), TextBox).Text = ""
                    lblerror.Text = ""
                    lblmsg.Text = ""
                End If
            Next
            If count = dt.Rows.Count Then
                lblerror.Text = "No Data to Clear."
                lblmsg.Text = ""
            End If
        Else
            lblerror.Text = "No Records to Clear."
            lblmsg.Text = ""
            GridView1.Visible = False
        End If
        ' txtMin.Text = ""

    End Sub
    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        CType(PageUpdateProgress.FindControl("lblprocess"), Label).Text = Session("Process")
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
        Dim dt2 As New DataTable
        El.id = 0
        El.Batch = ddlbatch.SelectedValue
        El.Semester = ddlsemester.SelectedValue
        El.Subject = ddlsubject.SelectedValue
        El.Assesment = ddlassesment.SelectedValue
        El.Min = txtMin.Text
        El.AssesmentDate = TxtAssessmentDate.Text
        dt2 = DLStudentMarksForFailed.ViewStdMarks(El)
        Dim sortedView As New DataView(dt2)
        sortedView.Sort = Convert.ToString(e.SortExpression) & " " & sortingDirection
        GridView1.DataSource = sortedView
        GridView1.DataBind()
        GridView1.Visible = True
        GridView1.Enabled = True
        LinkButton.Focus()

    End Sub

    Protected Sub ddlassesment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlassesment.SelectedIndexChanged

        GridView1.Visible = False
        pnllabel.Visible = False
        lblmsg.Text = ""
        lblerror.Text = ""
    End Sub
End Class

