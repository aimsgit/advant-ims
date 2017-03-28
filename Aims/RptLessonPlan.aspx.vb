
Partial Class RptLessonPlan
    Inherits BasePage
    ''Created By -->Ajit Kumar Singh
    ''Date-->05-Apr-2013

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        lblmsg.Text = ""
        msginfo.Text = ""
        Dim QS As String
        Dim courseid As Integer
        Dim SemID As Integer
        Dim SubjectID As Integer
        'Dim FromDate As Date
        'Dim ToDate As Date
        Try

            If ddlCourse.SelectedValue = "" Then
                courseid = 0
            Else
                courseid = ddlCourse.SelectedValue
            End If
            If ddlSemester.SelectedValue = "" Then
                SemID = 0
            Else
                SemID = ddlSemester.SelectedValue
            End If
            If ddlSubject.SelectedValue = "" Then
                SubjectID = 0
            Else
                SubjectID = ddlSubject.SelectedValue
            End If
            'If txtFromDate.Text = "" Then
            '    FromDate = "1/1/1900"
            'Else
            '    FromDate = txtFromDate.Text
            'End If
            'If txtToDate.Text = "" Then
            '    ToDate = "1/1/3000"
            'Else
            '    ToDate = txtToDate.Text
            'End If

            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptLessonPlanV.aspx?" & QueryStr.Querystring() & "&courseid=" & courseid & "&SemID=" & SemID & "&SubjectID=" & SubjectID
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
            lblmsg.Text = ""
        Catch ex As Exception
            msginfo.Text = "Enter correct data."
            lblmsg.Text = ""
        End Try
    End Sub

    Protected Sub Btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
