
Partial Class Rpt_StudentReportCardCriteria
    Inherits BasePage
    Dim alert As String
    Dim BAL As New CourseManager
    Dim GlobalFunction As New GlobalFunction
    Dim shdtls As Boolean
    Dim id1 As String = ""
    Sub GetAssessmentid()
        Dim str As String = ""
        Dim str1 As String = ""

        Dim id2 As String = ""
        Dim items As ListItem
        Dim i As Integer
        Dim j As Integer
        i = 0
        j = ddlass.Items.Count - 1

        If ddlass.Items.Count <> 0 Then
            For Each items In ddlass.Items
                If (ddlass.Items(i).Selected = True) Then
                    str = ddlass.Items(i).Value
                    'str1 = ListBatch.Items(i).Text
                    id1 = str + "," + id1
                    'id2 = str1 + " ,  " + id2

                End If
                i = i + 1
            Next
        End If
    End Sub

    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click

        Dim BranchCode As String = ddlbranch.SelectedValue
        Dim StudentID As Integer = ddlstucode.SelectedValue

        Dim BatchId As Integer = ddlbatch.SelectedValue
        Dim SemId As Integer = ddlsem.SelectedValue
        GetAssessmentid()
        
        Dim assesstype As String = id1
        If assesstype = "0," Or assesstype = "" Then
            assesstype = "0"
        Else
            assesstype = id1
        End If
        'If (ddlass.SelectedValue = "" Or "0") Then
        '    msginfo.Text = "Batch field is Mandatory."
        '    Exit Sub
        'End If
        'Dim assesstype As Integer = ddlass.SelectedValue
        Dim ReportType As String = ddlReportType.SelectedValue
        Dim SortBY As Integer = ddlSort.SelectedValue
        Dim bl As New StdResultB

        If ddlbranch.SelectedItem.Text = "Select" Or ddlcourse.SelectedItem.Text = "Select" Or ddlbatch.SelectedItem.Text = " Select" Then

            msginfo.Text = ValidationMessage(1100)
        Else
            Dim qrystring As String = "Rpt_StudentReportCardV.aspx?" & "&BranchCode=" & BranchCode & "&Batch=" & BatchId & "&Semester=" & SemId & "&StudentCode=" & StudentID & "&AssessmentType=" & assesstype & "&ReportType=" & ReportType & "&SortBy=" & SortBY
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)
            msginfo.Text = ValidationMessage(1014)
        End If
        shdtls = True
    End Sub
    Sub AlertEnterAllFields(ByVal str As String)
        alert = "alert('" & str & "');"
        ScriptManager.RegisterStartupScript(Me, Me.GetType, "alert", alert, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        shdtls = False
        'Dim heading As String
        'heading = Session("RptFrmTitleName")
        'Me.Lblheading.Text = heading
        If Not IsPostBack Then
            
            'If HttpContext.Current.Session("BranchType_ID") = "04" Or HttpContext.Current.Session("BranchType_ID") = "03" Or HttpContext.Current.Session("BranchType_ID") = "02" Or HttpContext.Current.Session("BranchType_ID") = "01" Then
            'Else
            ddlbranch.SelectedValue = HttpContext.Current.Session("BranchCode")
            'End If
        End If

    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    Protected Sub ddlbranch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbranch.SelectedIndexChanged
        ddlbranch.Focus()
    End Sub
    Protected Sub ddlass_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlass.SelectedIndexChanged
        ddlass.Focus()
    End Sub

    Protected Sub ddlbatch_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlbatch.SelectedIndexChanged
        ddlbatch.Focus()
    End Sub


    Protected Sub ddlcourse_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlcourse.SelectedIndexChanged
        ddlcourse.Focus()
    End Sub

    'Protected Sub ddlReportType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlReportType.SelectedIndexChanged
    '    ddlReportType.Focus()

    'End Sub

    Protected Sub ddlsem_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlsem.SelectedIndexChanged
        ddlsem.Focus()
    End Sub

    Protected Sub ddlstucode_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlstucode.SelectedIndexChanged
        ddlstucode.Focus()
    End Sub
    'Code written fro multilingual by Niraj on 11 jan 2014
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
