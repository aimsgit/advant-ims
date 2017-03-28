
Partial Class RptSemAssessmt
    Inherits BasePage
    Dim Batch As Integer
    Dim Course, RptType, SortType As Integer
    Dim Student As String
    Dim Semester As Integer
    Dim Subject As Integer
    Dim id1 As String = ""
    Sub GetBatchid()
        Dim str As String = ""
        Dim str1 As String = ""

        Dim id2 As String = ""
        Dim items As ListItem
        Dim i As Integer
        Dim j As Integer
        i = 0
        j = ListBatch.Items.Count - 1

        If ListBatch.Items.Count <> 0 Then
            For Each items In ListBatch.Items
                If (ListBatch.Items(i).Selected = True) Then
                    Str = ListBatch.Items(i).Value
                    str1 = ListBatch.Items(i).Text
                    id1 = str + "," + id1
                    id2 = str1 + " ,  " + id2
                End If
                i = i + 1
            Next
        End If
        ViewState("id1") = id1
        ViewState("id2") = id2
    End Sub
    Protected Sub btnReport_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnReport.Click
        Dim Cid, BId, SId, SubId, AsstId, StudId, id, id1 As Integer
        Dim ReportType As String
       

        If Session("LoginType") = "Others" Then
            Dim dt1 As New DataTable
           
            Cid = ddlcourseName.SelectedValue
            GetBatchid()
            Dim BatchId As String = ViewState("id1")
            Dim batchName As String = ViewState("id2")
            If (ListBatch.SelectedValue = "" Or "0") Then
                lblErrorMsg.Text = "Batch field is Mandatory."
                Exit Sub
            End If
            If ddlSemester.SelectedItem.Text = "Select" Then
                lblErrorMsg.Text = "Semester field is Mandatory"
            Else
                SId = Semester
                SubId = cmbSubject.SelectedValue
                AsstId = ddlass.SelectedValue
                StudId = Student
                ReportType = RptType
                id = SortType
                'id1 is used to identify whether it is parent or student login 
                id1 = 0

                Dim qrystring As String = "RptSemAssessmentV.aspx?" & "&Cid=" & Cid & "&BatchId=" & BatchId & "&SId=" & SId & "&SubId=" & SubId & "&StudId=" & StudId & "&ReportType=" & ReportType & "&id=" & id & "&AsstId=" & AsstId & "&id1=" & id1 & "&batchName=" & batchName
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                lblErrorMsg.Text = ValidationMessage(1014)
            End If

        Else

            'Dim Aid As Integer = ddlYearName.SelectedValue
            Cid = ddlcourseName.SelectedValue
            GetBatchid()
            Dim BatchId As String = ViewState("id1")
            Dim batchName As String = ViewState("id2")
            If (ListBatch.SelectedValue = "" Or "0") Then
                lblErrorMsg.Text = "Batch field is Mandatory."
                Exit Sub
            End If
            If ddlSemester.SelectedItem.Text = "Select" Then
                lblErrorMsg.Text = "Semester field is Mandatory"
            Else

                SId = ddlSemester.SelectedValue
                SubId = cmbSubject.SelectedValue
                AsstId = ddlass.SelectedValue
                StudId = ddlStudent.SelectedValue
                ReportType = ddlSort.SelectedValue
                id = ddlRptType.SelectedValue
                id1 = 0

                Dim qrystring As String = "RptSemAssessmentV.aspx?" & "&Cid=" & Cid & "&BatchId=" & BatchId & "&SId=" & SId & "&SubId=" & SubId & "&StudId=" & StudId & "&ReportType=" & ReportType & "&id=" & id & "&AsstId=" & AsstId & "&id1=" & id1 & "&batchName=" & batchName
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "message", "<script>window.open('" & qrystring & "',null,'toolbar=no,scrollbars=yes,location=no,resizable =yes,width=800,height=600,left=40,top=80')</script>", False)
                lblErrorMsg.Text = ValidationMessage(1014)

            End If
        End If
    End Sub
    
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("LoginType") = "Others" Then

            Dim dt1 As New DataTable
            btnBack.Visible = False
            dt1 = DLReportsR.GetStudentDtlsforStudlogin()
            Course = dt1.Rows(0).Item("CourseCode").ToString
            ddlCourseName.Visible = False
            lblCourse.Visible = False
            Batch = dt1.Rows(0).Item("BatchID").ToString
            ListBatch.Visible = False
            lblBatch.Visible = False
            Semester = dt1.Rows(0).Item("SemesterID").ToString
            Student = dt1.Rows(0).Item("StdId").ToString
            If Not IsPostBack Then
                dt1 = DLReportsR.GetSubject(Batch, Semester)
                cmbSubject.Items.Clear()
                If dt1.Rows.Count > 0 Then
                    cmbSubject.DataSource = dt1
                    cmbSubject.DataBind()
                End If
                ddlStudent.Visible = False
                lblStudent.Visible = False
                ddlRptType.Visible = False
                lblRptType.Visible = False
                ddlSort.Visible = False
                lblSort.Visible = False
                RptType = 0
                SortType = 1


                ddlSemester.SelectedValue = Semester
            Else
                Semester = ddlSemester.SelectedValue
            End If
            ddlCourseName.SelectedValue = Course
            ListBatch.SelectedValue = Batch

        Else
            btnBack.Visible = True
        End If
    End Sub
    <System.Web.Services.WebMethod()> Public Sub AbandonSession()
        Dim i As Int16 = UserDetailsDB.UpdateUserlog()
        Response.Redirect("LogIn.aspx")
    End Sub
    Protected Sub btnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        Response.Redirect("Report.aspx")
    End Sub

    'Protected Sub ddlSemester_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlSemester.SelectedIndexChanged
    '    Dim Batch As Integer, Sem As Integer
    '    Dim dt1 As New DataTable
    '    Batch = Batch
    '    Sem = Semester
    '    dt1 = DLReportsR.GetSubject(Batch, Sem)
    '    ddlSemester.Items.Clear()
    '    If dt1.Rows.Count > 0 Then
    '        ddlSemester.DataSource = dt1
    '        ddlSemester.DataBind()
    '    End If
    'End Sub
    'Code written fro multilingual by Niraj on 24 jan 2014
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
