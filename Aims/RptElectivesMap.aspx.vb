Partial Class RptElectivesMap
    Inherits BasePage
    Dim dt As New Data.DataTable

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim CourseId As Integer
        Dim BatchId As Integer
        Dim SemesterID As Integer
        Dim ElectiveID As Integer
        Try
            CourseId = ddlCourseName.SelectedValue
            BatchId = ddlBatchName.SelectedValue
            SemesterID = ddlSemester.SelectedValue
            ElectiveID = ddlElective.SelectedValue
            QS = Request.QueryString.Get("QS")

            Dim qrystring As String = "RptElectivesMapV.aspx?" & QueryStr.Querystring() & "&CourseId=" & CourseId & "&BatchId=" & BatchId & "&SemesterID=" & SemesterID & "&ElectiveID=" & ElectiveID & "&Sort=" & ddlSort.SelectedValue
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)

        Catch ex As Exception
            msginfo.Text = "Enter correct data."
        End Try

    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            'btnReport.Visible = False
            ddlCourseName.Focus()
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> _
    Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()

    End Sub
    Protected Sub ddlBatchName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatchName.TextChanged
        ddlBatchName.Focus()
    End Sub

    Protected Sub ddlCourseName_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourseName.TextChanged
        ddlCourseName.Focus()
    End Sub

    Protected Sub ddlElective_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlElective.TextChanged
        ddlElective.Focus()
    End Sub

    Protected Sub ddlSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.TextChanged
        ddlSemester.Focus()
    End Sub


End Class
