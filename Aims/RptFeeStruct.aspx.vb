
Partial Class RptFeeStruct

    Inherits BasePage
    Dim EL As New FeeStructE
    Dim BL As New FeeStructB
    Dim DL As New FeeStructD
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim dt As New Data.DataTable
        Dim Category As New Integer
        Dim AcademicYear As New Integer
        Dim Batch As New Integer
        Dim Semester As New Integer
        AcademicYear = ddlacadmeic_year.SelectedValue
        Batch = ddlbatch.SelectedValue
        Semester = ddlsem.SelectedValue
        Category = ddlcat.SelectedValue

        If ddlacadmeic_year.SelectedItem.Text = "Select" Or ddlbatch.SelectedItem.Text = "Select" Then
            lblmsg.Text = "Select All the Required Fields."
        Else

            dt = BL.finalExamRpt(AcademicYear, Batch, Semester, Category)

            Dim qrystring As String = "rptFeeStructure.aspx?" & QueryStr.Querystring() & "&AcademicYear=" & AcademicYear & "&Batch=" & Batch & "&Semester=" & Semester & "&Category=" & Category

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            lblmsg.Text = ""
        End If
    End Sub

    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub ddlbatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.SelectedIndexChanged
        ddlbatch.Focus()
    End Sub

    Protected Sub ddlacadmeic_year_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlacadmeic_year.SelectedIndexChanged
        ddlacadmeic_year.Focus()
    End Sub

    Protected Sub ddlcat_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcat.SelectedIndexChanged
        ddlcat.Focus()
    End Sub

    Protected Sub ddlsem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsem.SelectedIndexChanged
        ddlsem.Focus()
    End Sub
End Class


