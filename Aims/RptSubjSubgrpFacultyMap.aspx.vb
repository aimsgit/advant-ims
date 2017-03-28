
Partial Class RptSubjSubgrpFacultyMap

    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        lblErrorMsg.Text = ValidationMessage(1014)
        Dim QS As String
        
        Dim BatchId As Integer = ddlBatch.SelectedValue
        Dim SemId As Integer = cmbSemester.SelectedValue
       

        If ddlBatch.SelectedValue = "0" Then
            lblErrorMsg.Text = ValidationMessage(1178)
            ddlBatch.Focus()
        Else
            Dim qrystring As String = "RptSubjSubgrpFacultyMapV.aspx?" & QueryStr.Querystring() & "&BatchId=" & BatchId & "&SemId=" & SemId
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        End If
        'End If

    End Sub
    Protected Sub btnAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'Code written fro multilingual by Niraj on 26 Nov 2013
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
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        
    End Sub
End Class



