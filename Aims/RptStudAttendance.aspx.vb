
Partial Class RptStudAttendance
    Inherits BasePage
   
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim BR As String = ddlBranch.SelectedValue
        'Dim AY As Integer = cmbAcademic.SelectedValue
        Dim Bat As Integer = cmbBatch.SelectedValue
        Dim Sem As Integer = cmbSemester.SelectedValue
        Dim Subj As Integer = cmbSubject.SelectedValue
        Dim CT As Integer = ddlClasstype.SelectedValue
        Dim StdId As Integer = ddlStudent.SelectedValue
        Dim Month As Integer = ddlMonth.SelectedValue

        If ddlBranch.SelectedItem.Text = "Select" Or cmbBatch.SelectedItem.Text = "Select" Or Sem = 0 Then
            msginfo.Text = "Please Enter the Mandatory Fields"

        Else

            Dim qrystring As String = "RptStudAttendanceV.aspx?" & "&BranchCode=" & BR & "&Batch=" & Bat & "&Semester=" & Sem & "&Subject=" & Subj & "&ClassType=" & CT & "&StudentID=" & StdId & "&Month=" & Month
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ""
        End If
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            ddlBranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If
    End Sub

    Protected Sub cmbBatch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBatch.TextChanged
        cmbBatch.Focus()
    End Sub

    Protected Sub cmbSemester_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSemester.TextChanged
        cmbSemester.Focus()
    End Sub

    Protected Sub ddlClasstype_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlClasstype.TextChanged
        ddlClasstype.Focus()
    End Sub

    Protected Sub ddlBranch_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBranch.TextChanged
        ddlBranch.Focus()
    End Sub

    Protected Sub ddlStudent_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStudent.TextChanged
        ddlStudent.Focus()
    End Sub

    Protected Sub cmbSubject_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbSubject.TextChanged
        cmbSubject.Focus()
    End Sub

    Protected Sub ddlMonth_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMonth.TextChanged
        ddlMonth.Focus()
    End Sub
End Class
