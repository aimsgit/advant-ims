Partial Class frmBatchPerformanceReport
    Inherits BasePage

    Protected Sub btRpt_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btRpt.Click
        lblErrorMsg.Text = ValidationMessage(1014)
        Dim QS As String
        Dim course As Integer = ddlcourse.SelectedValue
        Dim subject As Integer = ddlsubject.SelectedValue
        Dim batch1 As Integer = ddlbatch1.SelectedValue
        Dim batch2 As Integer = ddlbatch2.SelectedValue
        Dim SemId As Integer = ddlSemester.SelectedValue
        Dim AssessmentId As Integer = ddlass.SelectedValue
        Dim Semester As String = ddlSemester.SelectedItem.Text
        Dim AssessmentType As String = ddlass.SelectedItem.Text
        Dim subjectName As String = ddlsubject.SelectedItem.Text
        QS = Request.QueryString.Get("QS")
        If QS = "Rpt4" Then
            If ddlcourse.SelectedValue = 0 Or ddlbatch1.SelectedValue = 0 Or ddlass.SelectedItem.Text = "Select" Then
                lblErrorMsg.Text = ValidationMessage(1100)
            Else
                Dim qrystring As String = "Rpt_BatchPerformanceRpt.aspx?" & QueryStr.Querystring() & "&batch1=" & batch1 & "&batch2=" & batch2 & "&course=" & course & "&subject=" & subject & "&SemId=" & SemId & "&AssessmentId=" & AssessmentId & "&SemName=" & Semester & "&AssessmentType=" & AssessmentType & "&subjectName=" & subjectName
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            End If
        End If
    End Sub
    Protected Sub Page_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        'If Not IsPostBack Then
       
        'End If
        Dim QS As String
        QS = Request.QueryString.Get("QS")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    'Code written fro multilingual by Niraj on 15 jan 2014
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
