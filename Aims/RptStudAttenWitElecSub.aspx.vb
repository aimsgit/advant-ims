
Partial Class RptStudAttenWitElecSub

    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ValidationMessage(1014)
        Dim BR As String = ddlBranch.SelectedValue
        'Dim AY As Integer = cmbAcademic.SelectedValue
        Dim Bat As Integer = cmbBatch.SelectedValue
        Dim Sem As Integer = cmbSemester.SelectedValue
        Dim Subj As Integer = cmbSubject.SelectedValue
        'Dim ES As Integer = ddlElecSub.SelectedValue
        Dim StdId As Integer = ddlStudent.SelectedValue
        Dim Month As Integer = ddlMonth.SelectedValue

        If ddlBranch.SelectedItem.Text = "Select" Or cmbBatch.SelectedItem.Text = "Select" Or Sem = 0 Then
            msginfo.Text = ValidationMessage(1117)

        Else

            Dim qrystring As String = "RptStudAttenWitElecSubV.aspx?" & "&BranchCode=" & BR & "&Batch=" & Bat & "&Semester=" & Sem & "&Subject=" & Subj & "&StudentID=" & StdId & "&Month=" & Month
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ValidationMessage(1014)
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
    'Code written fro multilingual by Niraj on 06 jan 2014
    ''Retriving the text of controls based on Language

    
    Public Function ValidationMessage(ByVal ErrorCode As Integer) As String
        Dim dt2 As DataTable
        'Dim Message As String
        dt2 = Session("ValidationTable")
        Dim X As Integer = dt2.Rows.Count() - 1
        Dim str As String = " "
        For i As Integer = 0 To X
            If (dt2.Rows(i).Item("MessageCode").ToString() = ErrorCode) Then
                Return dt2.Rows(i).Item("MessageText").ToString()
            End If
        Next
        Return 0
    End Function
End Class



