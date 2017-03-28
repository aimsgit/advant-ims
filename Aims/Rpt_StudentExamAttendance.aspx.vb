
Partial Class Rpt_StudentExamAttendance
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim QS As String
        Dim Subject As Integer = ddlSubjectName.SelectedValue
        Dim Exam As Integer = ddlExamName.SelectedValue
        Dim ExamDate As Date = TxtExamdate.Text
        Dim ExamCenter As Integer = ddlExamCenter.SelectedValue
        QS = Request.QueryString.Get("QS")
        If ddlSubjectName.SelectedItem.Text = "Select" Then 'Or 
            lblMsg.Text = "Please enter all Mandatory Fields."
        Else
            Dim qrystring As String = "Rpt_StudentExamAttendanceV.aspx?" & QueryStr.Querystring() & "&Subject=" & Subject & "&Exam=" & Exam & "&ExamDate=" & ExamDate & "&ExamCenter=" & ExamCenter
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblMsg.Text = ""
        End If

    End Sub

    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            TxtExamdate.Text = Format(Today, "dd-MMM-yyyy")
        End If
    End Sub
End Class
