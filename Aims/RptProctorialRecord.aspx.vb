
Partial Class RptProctorialRecord
    Inherits BasePage
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCreate.Click
        Dim Batch As Integer
        Dim BatchNo As String
        Dim Course As String
        Dim Student As String
        Dim dt As DataTable
        'Dim a, b, c As String
        'Dim RType As String
        'Dim AYID As Integer
        'Dim SortBy As Integer
        'Dim BatchId As Integer
        'Dim assesstype As Integer
        'Dim StudentID As Integer
        Dim StdID, LogID As Integer
        Dim fromdate, todate As Date
        Dim AY As String
        fromdate = "01-01-1900"
        todate = "01-01-4000"
        LogID = 0
        'a = 0
        'b = 0
        'c = 0
        ''Code Written by Niraj on 30 Jul 2013
        'For Each li As ListItem In RBUsers.Items
        '    If li.Selected Then
        '        If li.Value = "1" Then
        '            a = "1"
        '        End If
        '        If li.Value = "1" Then
        '            b = "2"
        '        End If
        '        If li.Value = "1" Then
        '            c = "3"
        '        End If
        '    End If
        'Next
        'Dim SemId, classtype As Integer
        'AYID = 0
        'Try
        '    If (Session("BranchCode") = Session("ParentBranch")) Then
        '        RType = RBUsers.SelectedValue
        '        Batch = ddlBatch.SelectedValue
        '        Course = 0
        '        Student = ddlStudent.SelectedValue
        '        If (RType = "RType1") Then
        '            Dim CourseID As Integer

        '            Dim AID As Integer
        '            AID = 0
        '            CourseID = 0

        Batch = ddlBatch.SelectedValue
        BatchNo = ddlBatch.SelectedItem.Text()
        Student = ddlStudent.SelectedValue
        dt = DLLogin.GetCourse(Batch)
        Course = dt.Rows(0)("CourseName").ToString
        AY = dt.Rows(0)("AcademicYear").ToString
        Dim qrystring As String = "Merge.aspx?" & "&BatchID=" & Batch & "&StudentID=" & Student & "&BatchNo=" & BatchNo & "&Course=" & Course & "&AY=" & AY
        ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        'Dim qrystring As String = "RptStudentIndividualAdmissionDetailsV.aspx?" & QueryStr.Querystring() & "&AYID=" & AID & "&CourseID=" & CourseID & "&BatchId=" & Batch & "&StudentID=" & Student
        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        'lblErrorMsg.Text = ""

        '        ElseIf (RType = "RType2") Then
        'Dim BranchCode As String
        'Dim ReportType As String
        'ReportType = "Marks"

        'SortBy = 0

        'assesstype = 0
        'BranchCode = (Session("BranchCode"))
        'Batch = ddlBatch.SelectedValue

        'Dim qrystring As String = "Rpt_StudentReportCardV.aspx?" & "&BranchCode=" & BranchCode & "&Batch=" & Batch & "&Semester=" & SemId & "&StudentCode=" & Student & "&AssessmentType=" & assesstype & "&ReportType=" & ReportType & "&SortBy=" & SortBy
        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=40,top=80')</script>", False)

        '        ElseIf (RType = "RType3") Then
        'Batch = ddlBatch.SelectedValue
        'Dim qrystring As String = "RptStudentLogBookV.aspx?" & QueryStr.Querystring() & "&BatchID=" & Batch & "&StdID=" & Student & "&LogID=" & LogID & "&fromdate=" & fromdate & "&todate=" & todate
        'ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=1050,height=700,left=0,top=0')</script>", False)
        '        End If
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub
End Class