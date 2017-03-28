
Partial Class Rpt_FeedbackComments
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Try

            Dim CourseId As Integer
            Dim BatchId As Integer
            Dim Facultyid As Integer
            Dim SemId As Integer
            lblmsg.Text = ""
            Dim QS As String


            CourseId = ddlcourse.SelectedValue
            If cmbBatch.SelectedValue = "" Then
                BatchId = 0
            Else
                BatchId = cmbBatch.SelectedValue
            End If
            If ddlsem.SelectedValue = "" Then
                SemId = 0
            Else
                SemId = ddlsem.SelectedValue
            End If
            Facultyid = Ddlfaculty.SelectedValue
            If Ddlfaculty.SelectedValue = "" Then
                Facultyid = 0
            Else
                Facultyid = Ddlfaculty.SelectedValue
            End If
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "Rpt_FeedbackCommentsV.aspx?" & QueryStr.Querystring() & "&CourseId=" & CourseId & "&BatchId=" & BatchId & "&FacultyId=" & Facultyid & "&SemId=" & SemId
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            lblErrorMsg.Text = "Enter correct data."
        End Try

    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    'Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    '    If Not IsPostBack Then
    '        If Session("UserRole") <> "HOD" Or Session("UserRole") <> "Principal" Then

    '            Ddlfaculty.SelectedValue = Session("EmpId")
    '            Ddlfaculty.Enabled = False
    '        Else
    '            Ddlfaculty.SelectedValue = Session("EmpId")
    '            Ddlfaculty.Enabled = True
    '        End If


    '    End If
    'End Sub
End Class
