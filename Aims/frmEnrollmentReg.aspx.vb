Imports System.Data
Imports System.IO

Partial Class frmEnrollmentReg
    Inherits BasePage
    Dim estd As New StudentE
    Dim BL As New StudentB
    Dim off As String
    Dim BCode As String
    Dim BNo As Integer

    Dim GlobalFunction As New GlobalFunction
    

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        'If ddlBranchName.Text <> "Select" Or ddlCourseName.Text <> "Select" Or ddlYearName.Text <> "Select" Or ddlBatchName.Text <> "select" Or ddlSemester.Text <> "Select" Then

        Dim dt As New Data.DataTable
        Dim BranchCode As String
        Dim CourseId As New Integer
        Dim AcademicYearId As New Integer
        Dim BatchId As New Integer
        Dim SemesterId As New Integer
        BranchCode = ddlBranchName.SelectedValue
        CourseId = ddlCourseName.SelectedValue
        AcademicYearId = ddlYearName.SelectedValue
        BatchId = ddlBatchName.SelectedValue
        SemesterId = ddlSemester.SelectedValue

        If ddlBranchName.SelectedItem.Text = "Select" Or ddlCourseName.SelectedItem.Text = "Select" Or ddlYearName.SelectedItem.Text = " Select" Or ddlBatchName.SelectedItem.Text = "Select" Then
            lblErrorMsg.Text = "Select All the Required Fields."
        Else

            dt = BL.finalExamRpt(BranchCode, CourseId, AcademicYearId, BatchId, SemesterId)

            Dim qrystring As String = "rptEnrollmentRegV.aspx?" & QueryStr.Querystring() & "&BranchCode=" & BranchCode & "&CourseId=" & CourseId & "&AcademicYearId=" & AcademicYearId & "&BatchId=" & BatchId & "&SemesterId=" & SemesterId

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            lblErrorMsg.Text = ""
        End If
    End Sub

    'Protected Sub txtBranchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBranchName.SelectedIndexChanged
    '    StudentListDB.insertBranch()
    'End Sub

    'Protected Sub txtCourseName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCourseName.SelectedIndexChanged
    '    StudentListDB.insertCourse(txtBranchName.SelectedValue)
    'End Sub

    'Protected Sub txtYearName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtYearName.SelectedIndexChanged
    '    StudentListDB.insertYear(txtCourseName.SelectedValue)
    'End Sub

    'Protected Sub txtBatchName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBatchName.SelectedIndexChanged
    '    StudentListDB.insertBatch(txtYearName.SelectedValue)
    'End Sub
    <System.Web.Services.WebMethod()> _
   Public Shared Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class
