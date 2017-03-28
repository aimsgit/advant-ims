
Partial Class RptStudentIndividualAdmissionDetails
    Inherits BasePage
    Dim BLL As New RptStudentAdmissionDetailsBL
    Dim dt As DataTable
    'Code written By Ajit
    '07-Mar-2013
   
    Protected Sub Btnreport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnreport.Click
        lblmsg.Text = ValidationMessage(1014)
        msginfo.Text = ValidationMessage(1014)
        Dim QS As String
        Dim AYID As Integer
        Dim CourseID As Integer
        Dim BatchID As Integer
        Dim StudentID As Integer
        Try

            'If ddlAcdemicYear.SelectedValue = "" Then
            '    AYID = 0
            'Else
            '    AYID = ddlAcdemicYear.SelectedValue
            'End If

            If ddlCourse.SelectedValue = "" Then
                CourseID = 0
            Else
                CourseID = ddlCourse.SelectedValue
            End If
            If ddlBatch.SelectedValue = "" Then
                BatchID = 0
            Else
                BatchID = ddlBatch.SelectedValue
            End If
            If ddlStudent.SelectedValue = "" Then
                StudentID = 0
            Else
                StudentID = ddlStudent.SelectedValue
            End If

            QS = Request.QueryString.Get("QS")
            Dim qrystring As String = "RptStudentIndividualAdmissionDetailsV.aspx?" & QueryStr.Querystring() & "&CourseID=" & CourseID & "&BatchID=" & BatchID & "&StudentID=" & StudentID
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
            msginfo.Text = ValidationMessage(1014)
            lblmsg.Text = ValidationMessage(1014)
        Catch ex As Exception
            msginfo.Text = ValidationMessage(1022)
            lblmsg.Text = ValidationMessage(1014)
        End Try
    End Sub
    'Protected Sub ddlAcdemicYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlAcdemicYear.SelectedIndexChanged
    '    ddlAcdemicYear.Focus()
    '    msginfo.Text = ValidationMessage(1014)

    'End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Btnback.Click
        Response.Redirect("Report.aspx")
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub

    Protected Sub ddlBatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlBatch.SelectedIndexChanged
        ddlBatch.Focus()
        msginfo.Text = ValidationMessage(1014)
    End Sub

    Protected Sub ddlCourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlCourse.SelectedIndexChanged
        ddlCourse.Focus()
        msginfo.Text = ValidationMessage(1014)
        Dim AY As String
        Dim Courseid As Integer
        'AY = ddlAcdemicYear.SelectedItem.ToString
        Courseid = ddlCourse.SelectedValue
        dt = BLL.GetBatch(Courseid)
        ddlBatch.Items.Clear()
        If dt.Rows.Count > 0 Then
            ddlBatch.DataSource = dt
            ddlBatch.DataBind()
        End If
    End Sub

    Protected Sub ddlStudent_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStudent.SelectedIndexChanged
        ddlStudent.Focus()
        msginfo.Text = ValidationMessage(1014)
    End Sub
    'Code written fro multilingual by Niraj on 06 Dec 2013
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
