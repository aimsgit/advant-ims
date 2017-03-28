
Partial Class RptExamAttempt
    Inherits BasePage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub

    Protected Sub Btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    ''Created By -->Ajit Kumar Singh
    ''Date-->27-Jun-2013
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click

        lblmsg.Text = ""
        msginfo.Text = ""
        Dim QS As String
        Dim CourseID As String
        Dim BatchID As Integer
        Dim SemesterID As Integer
        Dim FinalIAID As Integer
        Dim FinalExam As Integer
        Dim StudentID As Integer
        Try

           
            CourseID = ddlCourse.SelectedItem.ToString

            If ddlBatchName.SelectedValue = "" Then
                BatchID = 0
            Else
                BatchID = ddlBatchName.SelectedValue
            End If
            If DDLSemester.SelectedValue = "" Then
                SemesterID = 0
            Else
                SemesterID = DDLSemester.SelectedValue
            End If
            If ddlFinalIA.SelectedValue = "" Then
                FinalIAID = 0
            Else
                FinalIAID = ddlFinalIA.SelectedValue
            End If
            If ddlFinalExam.SelectedValue = "" Then
                FinalExam = 0
            Else
                FinalExam = ddlFinalExam.SelectedValue
            End If
            If ddlStudent.SelectedValue = "" Then
                StudentID = 0
            Else
                StudentID = ddlStudent.SelectedValue
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptExamAttemptV.aspx?" & QueryStr.Querystring() & "&CourseID=" & CourseID & "&BatchID=" & BatchID & "&SemesterID=" & SemesterID & "&FinalIAID=" & FinalIAID & "&FinalExam=" & FinalExam & "&StudentID=" & StudentID
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub
End Class
