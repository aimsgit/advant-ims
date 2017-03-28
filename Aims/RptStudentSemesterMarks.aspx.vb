
Partial Class RptStudentSemesterMarks
    Inherits BasePage

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        Dim Ayear, CourseID, BatchID, Semester, Student As Integer
        'Ayear = DDLAyear.SelectedValue
        CourseID = ddlCourse.SelectedValue
        BatchID = ddlBatchName.SelectedValue
        Semester = DDLSemester.SelectedValue
        Student = DDLStudent.SelectedValue
        If ddlBatchName.SelectedValue = "0" Or DDLSemester.SelectedValue = "0" Or DDLStudent.SelectedValue = "0" Then
            msginfo.Text = ValidationMessage(1212)
        Else
            msginfo.Text = ValidationMessage(1014)
            Dim qrystring As String = "RptStudentSemesterMarksV.aspx?" & QueryStr.Querystring() & "&CourseID=" & CourseID & "&BatchID=" & BatchID & "&Semester=" & Semester & "&Student=" & Student
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    'Protected Sub DDLAyear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLAyear.SelectedIndexChanged
    '    DDLAyear.Focus()
    'End Sub

    Protected Sub ddlBatchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.SelectedIndexChanged
        ddlBatchName.Focus()
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        ddlCourse.Focus()
    End Sub

    Protected Sub DDLSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLSemester.SelectedIndexChanged
        DDLSemester.Focus()
    End Sub

    Protected Sub DDLStudent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DDLStudent.SelectedIndexChanged
        DDLStudent.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'Code written fro multilingual by Niraj on 22 jan 2014
    ''Retriving the text of controls based on Language

    
    
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

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub
End Class
