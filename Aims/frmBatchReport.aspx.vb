
Partial Class frmBatchReport
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""

        Dim Course As Integer = cmbCourse.SelectedValue
        Dim AcademicYear As Integer = cmbAcademic.SelectedValue
 
       
        Dim qrystring As String = "RptBatchReport.aspx?" & QueryStr.Querystring() & "&Course=" & Course & "&AcademicYear=" & AcademicYear
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        
    End Sub

   
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Session("GStatus") = ""
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub cmbAcademic_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbAcademic.SelectedIndexChanged
        cmbAcademic.Focus()
    End Sub

    Protected Sub cmbCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCourse.SelectedIndexChanged
        cmbCourse.Focus()
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'Code written fro multilingual by Niraj on 25 Nov 2013
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
        If Not IsPostBack Then
            
        End If
    End Sub
End Class
