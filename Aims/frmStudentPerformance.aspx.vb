Imports System.IO
Imports System.Data
Partial Class frmStudentPerformance
    Inherits BasePage
    Dim dt As New DataTable
    'Dim BLPerf As New StudentPerformanceBL
    Dim DLPerf As New StudentPerformanceDL
    Dim dl As New DLReportsR
    Dim Batch As Integer
    Dim Student As String
    Dim Semester As String
    Dim Subject As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QS As String
        Dim ParentDt As New DataTable
        QS = Request.QueryString.Get("QS")
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        
        If Session("LoginType") = "Others" Then
            RbPerfromance.Visible = False
            lblBatch.Visible = False
            ddlBatch.Visible = False
            lblStudent.Visible = False
            ddlStudent.Visible = False
            lblSubject.Visible = False
            ddlSubject.Visible = False
            btnBack.Visible = False
            ParentDt = dl.GetStudentDtlsForParent1()
            Batch = ParentDt.Rows(0).Item("BatchID").ToString
            Session("BatchID") = Batch
            Semester = ParentDt.Rows(0).Item("SemesterID").ToString
            Student = ParentDt.Rows(0).Item("StdId").ToString
            Subject = 0
            If Not IsPostBack Then
                ddlSemester.SelectedValue = Semester
            Else
                Semester = ddlSemester.SelectedValue
            End If
            ddlStudent.SelectedValue = Student
            ddlSubject.SelectedValue = Subject
            ddlBatch.SelectedValue = Batch
        End If
    End Sub
    Protected Sub btnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        msginfo.Text = ValidationMessage(1014)
        Dim QS As String
        If Session("LoginType") <> "Others" Then
            Batch = ddlBatch.SelectedValue
            Student = ddlStudent.SelectedValue
            Semester = ddlSemester.SelectedValue
            Subject = ddlSubject.SelectedValue
        End If
        
        QS = Request.QueryString.Get("QS")
        If Session("LoginType") <> "Others" Then

            If RbPerfromance.SelectedValue = 1 Then
                If ddlStudent.SelectedItem.Text = "Select" Or ddlSemester.SelectedItem.Text = "Select" Then
                    msginfo.Text = ValidationMessage(1100)
                Else
                    Dim qrystring As String = "Rpt_StudentPerformanceRpt.aspx?" & QueryStr.Querystring() & "&BatchId=" & Batch & "&student=" & Student & "&semester=" & Semester & "&subject=" & Subject
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                End If
            Else
                If ddlStudent.SelectedItem.Text = "Select" Or ddlBatch.SelectedItem.Text = "Select" Then
                    msginfo.Text = ValidationMessage(1100)
                Else
                    Dim qrystring As String = "Rpt_StudentPerformanceRptOverall.aspx?" & QueryStr.Querystring() & "&BatchId=" & Batch & "&student=" & Student
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
                End If
            End If

        Else
            If ddlSemester.SelectedItem.Text = "Select" Then
                msginfo.Text = ValidationMessage(1100)
            Else
                Dim qrystring As String = "Rpt_StudentPerformanceRpt.aspx?" & QueryStr.Querystring() & "&BatchId=" & Batch & "&student=" & Student & "&semester=" & Semester & "&subject=" & Subject
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            End If
        End If
        'If QS = "Rpt3" Then

        'End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub ddlBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.TextChanged
        ddlBatch.Focus()
    End Sub

    Protected Sub ddlStudent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStudent.TextChanged
        ddlStudent.Focus()
    End Sub

    Protected Sub ddlSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.TextChanged
        ddlSemester.Focus()
    End Sub

    Protected Sub ddlSubject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSubject.TextChanged
        ddlSubject.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub RbPerfromance_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbPerfromance.SelectedIndexChanged
        If RbPerfromance.SelectedValue = 1 Then
            lblBatch.Visible = True
            ddlBatch.Visible = True
            lblSemester.Visible = True
            ddlSemester.Visible = True
            lblSubject.Visible = True
            ddlSubject.Visible = True
            lblStudent.Visible = True
            ddlStudent.Visible = True

        Else
            lblBatch.Visible = True
            ddlBatch.Visible = True
            lblSemester.Visible = False
            ddlSemester.Visible = False
            lblSubject.Visible = False
            ddlSubject.Visible = False
            lblStudent.Visible = True
            ddlStudent.Visible = True
        End If
    End Sub
    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
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
