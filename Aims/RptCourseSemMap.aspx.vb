Partial Class RptCourseSemMap
    Inherits BasePage

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        msginfo.Text = ""
        Dim QS As String
        Dim courseid As Integer
        courseid = cmbCourse.SelectedValue
        QS = Request.QueryString.Get("QS")
        If QS = "RptCSMap" Then
            If cmbCourse.SelectedItem.Text = "Select" Then
                msginfo.Text = ""
            Else
                Dim qrystring As String = "RptCourseSemMapV.aspx?" & QueryStr.Querystring() & "&courseid=" & courseid
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            End If
        End If
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim QS, heading As String
        QS = Request.QueryString.Get("QS")
        'heading = Request.QueryString.Get("heading")
        'Me.Lblheading.Text = heading
        If Not IsPostBack Then
        End If
    End Sub

    Protected Sub cmbCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCourse.SelectedIndexChanged
        cmbCourse.Focus()
    End Sub
    'Code written fro multilingual by Niraj on 23 Nov 2013
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
