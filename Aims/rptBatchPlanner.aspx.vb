Imports System.Data
Imports System.IO
Partial Class rptBatchPlanner
    Inherits BasePage
    Dim alert As String
    Dim BAL As New CourseManager
    Dim GlobalFunction As New GlobalFunction
    Dim shdtls As Boolean
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
      
        Dim BatchId As Integer = ddlbatch.SelectedValue
        Dim SemId As Integer = ddlsem.SelectedValue

        Dim bl As New StdResultB

        If ddlacadyear.SelectedValue = "0" Or ddlbatch.SelectedItem.Text = "Select" Then

            msginfo.Text = ValidationMessage(1176)
        Else
            Dim qrystring As String = "rptBatchPlannerB.aspx?" & "&Batch=" & BatchId & "&Semester=" & SemId
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
            msginfo.Text = ""
        End If
        shdtls = True
    End Sub
    'Sub AlertEnterAllFields(ByVal str As String)
    '    alert = "alert('" & str & "');"
    '    ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", alert, True)
    'End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        shdtls = False
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
    '    Response.Redirect("Report.aspx")
    'End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub ddlacadyear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlacadyear.SelectedIndexChanged
        ddlacadyear.Focus()
    End Sub

    Protected Sub ddlbatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.SelectedIndexChanged
        ddlbatch.Focus()
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
