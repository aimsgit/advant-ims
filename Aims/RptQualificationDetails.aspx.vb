
Partial Class RptQualificationDetails
    Inherits BasePage

    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click


        Dim CRS As String = ddlCourse.SelectedItem.Text
        Dim Batch As String = ddlBatchName.SelectedItem.Text
        Dim Student As String = DDLStudent.SelectedItem.Text
        Dim stdcode As String = DDLStudent.SelectedValue
        '& "&Std=" & HidStudentId.Value & "&ID=" & id

        Dim qrystring As String = "RptQualificationDetailsV.aspx?" & "&Course=" & CRS & "&Batch=" & Batch & "&Student=" & Student & "&Stdcode=" & stdcode
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)


    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub btnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Session("GStatus") = ""
        Response.Redirect("Report.aspx")
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
