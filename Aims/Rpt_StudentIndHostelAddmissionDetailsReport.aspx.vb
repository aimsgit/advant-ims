
Partial Class Rpt_StudentIndHostelAddmissionDetailsReport
    Inherits BasePage

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        Try
            Dim Course, BatchId, StudentId As Integer
            'Dim id As String = ""
            'Dim check As String = ""
            'Course = ddlCourse.SelectedValue
            'BatchId = ddlBatch.SelectedValue
            'StudentId = ddlStudent.SelectedValue
            Dim BranchCode As String
            Dim BranchName As String
            BranchName = ddlBranchName.SelectedItem.Text
            BranchCode = ddlBranchName.SelectedValue


           
            Course = ddlCourse.SelectedValue
            
            BatchId = ddlBatch.SelectedValue
            
            StudentId = ddlStudent.SelectedValue

            Dim qrystring As String = "StudentIndHostelAddmDetailsV.aspx?" & "&BranchCode=" & BranchCode & "&Course=" & Course & "&BatchId=" & BatchId & "&StudentId=" & StudentId & "&BranchName=" & BranchName
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            lblerrmsg.Text = ""






        Catch ex As Exception
            lblerrmsg.Text = "Please Enter Correct Data."
        End Try
    End Sub

    Protected Sub Btnback_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ddlBranchName.SelectedValue = Session("BranchCode")
        End If

    End Sub
End Class

