
Partial Class RptStudentProgress
    Inherits BasePage

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Batch As Integer
        Dim Semester As Integer
        Dim Assessment As Integer
        Dim Student As Integer
        Dim FDate As Date
        Dim EDate As Date
        Try
            Batch = ddlbatch.SelectedValue
            Semester = ddlSemester.SelectedValue
            Assessment = ddlassessment.SelectedValue
            Student = DDLStudent.SelectedValue
            If txtFromDateExt.Text = "" Then
                FDate = "1/1/1900"
            Else
                FDate = txtFromDateExt.Text
            End If
            If txtToDateExt.Text = "" Then
                EDate = "1/1/3000"
            Else
                EDate = txtToDateExt.Text
            End If
            Dim qrystring As String = "RptStudentProgressV.aspx?" & QueryStr.Querystring() & "&Batch=" & Batch & "&Semester=" & Semester & "&Assessment=" & Assessment & "&Student=" & Student & "&FDate=" & FDate & "&EDate=" & EDate & "&AssessmentType=" & ddlassessment.SelectedItem.ToString
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception

        End Try
    End Sub

    Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.SelectedIndexChanged
        ddlSemester.Focus()
        Dim dt As New DataTable
        Dim FrmDate, ToDate As Date
        Dim Bat As String = ddlbatch.SelectedValue
        Dim Sem As String = ddlSemester.SelectedValue
        dt = DLStudentProgress.StudentStartEndDate(Bat, Sem)

        If dt.Rows.Count = 0 Then
            txtToDateExt.Text = ""
            txtFromDateExt.Text = ""
            FrmDate = "01/01/1800"
            ToDate = "01/01/3000"
        Else
            If Bat = 0 Or Sem = 0 Then
                txtToDateExt.Text = ""
                txtFromDateExt.Text = ""
                FrmDate = "01/01/1800"
                ToDate = "01/01/3000"
            Else
                txtFromDateExt.Text = Format(dt.Rows(0).Item("StartDate"), "dd-MMM-yyyy").ToString
                txtToDateExt.Text = Format(dt.Rows(0).Item("EndDate"), "dd-MMM-yyyy").ToString
            End If
        End If
    End Sub
    'Code written fro multilingual by Niraj on 25 jan 2014
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
