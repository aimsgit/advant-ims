
Partial Class RptBatchSemesterMap
    Inherits BasePage
    Dim shdtls As Boolean
    Dim GlobalFunction As New GlobalFunction

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        'Code For Back Button[Return to Report Page] by Nitin 09-05-2012
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim QS As String
        Dim BatchId As Integer = ddlbatch.SelectedValue
        Dim Aid As Integer = ddlacadyear.SelectedValue
        Session("BatchId") = ddlbatch.SelectedValue
        QS = Request.QueryString.Get("QS")
        If QS = "Rpt33" Then
            If ddlacadyear.SelectedValue = 0 Then

                msginfo.Text = ValidationMessage(1177)
            Else
                Dim qrystring As String = "RptBatchSemesterMapV.aspx?" & QueryStr.Querystring() & "&Batch=" & BatchId & "&Aid=" & Aid
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                msginfo.Text = ValidationMessage(1014)
            End If
            shdtls = True
        End If
    End Sub

    Protected Sub ddlacadyear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlacadyear.SelectedIndexChanged
        ddlacadyear.Focus()
    End Sub

    Protected Sub ddlbatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.SelectedIndexChanged
        ddlbatch.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    
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
