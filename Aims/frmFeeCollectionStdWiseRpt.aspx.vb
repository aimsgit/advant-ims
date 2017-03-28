
Partial Class frmFeeCollectionStdWiseRpt
    Inherits BasePage 
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim AY As String = cmbAcademic.SelectedValue
        Dim Bat As String = cmbBatch.SelectedValue
        Dim Sem As String = cmbSemester.SelectedValue
        Dim StudentCode As Integer = ddlstucode.SelectedValue

        Dim qrystring As String = "RptFeeCollectionStudentWiseReport.aspx?" & "&A_Year=" & AY & "&Batch=" & Bat & "&Semester=" & Sem & "&StudentCode=" & StudentCode
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Session("GStatus") = ""
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub cmbAcademic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcademic.SelectedIndexChanged
        cmbAcademic.Focus()
    End Sub

    Protected Sub cmbBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatch.SelectedIndexChanged
        cmbBatch.Focus()
    End Sub

    Protected Sub cmbSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.SelectedIndexChanged
        cmbSemester.Focus()
    End Sub

    Protected Sub ddlstucode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlstucode.SelectedIndexChanged
        ddlstucode.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
End Class
